Namespace Media.Presentation

    Public Class MediaBroadcastWorksheetMarketDetailTotalsDialog

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum UnboundColumns
            Totals
        End Enum

#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController = Nothing
        Protected _DetailsForm As Media.Presentation.MediaBroadcastWorksheetMarketDetailForm = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Sub New(ByRef DetailsForm As Media.Presentation.MediaBroadcastWorksheetMarketDetailForm,
                       ByRef Controller As AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController,
                       ByRef ViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsViewModel)

            ' This call is required by the designer.
            InitializeComponent()

            _DetailsForm = DetailsForm
            _Controller = Controller
            _ViewModel = ViewModel

        End Sub
        Private Sub LoadGrid()

            DataGridViewForm_Totals.OptionsView.ShowFooter = False

            DataGridViewForm_Totals.ClearDatasource()

            DataGridViewForm_Totals.CurrentView.ClearGrouping()

            DataGridViewForm_Totals.ClearColumns()

            DataGridViewForm_Totals.CurrentView.BeginUpdate()

            If RadioButtonForm_MarketSummary.Checked Then

                DataGridViewForm_Totals.DataSource = _ViewModel.RowTotalsDataTable

                FormatGridMarketSummaries()

                Me.Text = RadioButtonForm_MarketSummary.Text

            ElseIf RadioButtonForm_MarketMonthlySummary.Checked Then

                DataGridViewForm_Totals.DataSource = _ViewModel.MarketMonthlySummaryDataTable

                FormatGridMarketSummaries()

                Me.Text = RadioButtonForm_MarketMonthlySummary.Text

            ElseIf RadioButtonForm_DaypartSummary.Checked Then

                DataGridViewForm_Totals.DataSource = _ViewModel.DaypartSummaryDataTable

                Me.Text = RadioButtonForm_DaypartSummary.Text

                HideReachFrequencyColumns()

            ElseIf RadioButtonForm_DaypartWeeklyDailySpendSummary.Checked Then

                DataGridViewForm_Totals.DataSource = _ViewModel.DaypartWeeklyDailySummaryDataTable

                Me.Text = RadioButtonForm_DaypartWeeklyDailySpendSummary.Text

            ElseIf RadioButtonForm_DaypartWeeklyDailyGRPSummary.Checked Then

                DataGridViewForm_Totals.DataSource = _ViewModel.DaypartGRPWeeklyDailySummaryDataTable

                Me.Text = RadioButtonForm_DaypartWeeklyDailyGRPSummary.Text

            ElseIf RadioButtonForm_StationSummary.Checked Then

                DataGridViewForm_Totals.DataSource = _ViewModel.StationSummaryDataTable

                Me.Text = RadioButtonForm_StationSummary.Text

                HideReachFrequencyColumns()

            ElseIf RadioButtonForm_StationMonthlySummary.Checked Then

                DataGridViewForm_Totals.DataSource = _ViewModel.StationMonthlySummaryDataTable

                Me.Text = RadioButtonForm_StationMonthlySummary.Text

            ElseIf RadioButtonForm_LengthSummary.Checked Then

                DataGridViewForm_Totals.DataSource = _ViewModel.LengthSummaryDataTable

                Me.Text = RadioButtonForm_LengthSummary.Text

            ElseIf RadioButtonForm_DaypartLengthSummary.Checked Then

                DataGridViewForm_Totals.DataSource = _ViewModel.DaypartLengthSummaryDataTable

                Me.Text = RadioButtonForm_DaypartLengthSummary.Text

                HideReachFrequencyColumns()

            End If

            DataGridViewForm_Totals.CurrentView.EndUpdate()

            If RadioButtonForm_MarketSummary.Checked OrElse
                    RadioButtonForm_MarketMonthlySummary.Checked Then

                FormatGridMarketSummaries()

                DataGridViewForm_Totals.CurrentView.ExpandAllGroups()

            ElseIf RadioButtonForm_DaypartSummary.Checked Then

                DataGridViewForm_Totals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.ID.ToString).Visible = False

                If DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.Spots.ToString) IsNot Nothing Then

                    AddSummaryItemToColumn(DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.Spots.ToString),
                                           "{0:n0}", DevExpress.Data.SummaryItemType.Sum, Nothing)

                End If

                If DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.Cost.ToString) IsNot Nothing Then

                    DataGridViewForm_Totals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.Cost.ToString).Caption = "Cost"
                    AddSummaryItemToColumn(DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.Cost.ToString),
                                           "{0:c2}", DevExpress.Data.SummaryItemType.Sum, Nothing)

                End If

                If DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.CostPercentageOfTotal.ToString) IsNot Nothing Then

                    DataGridViewForm_Totals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.CostPercentageOfTotal.ToString).Caption = "% of Total Cost"

                End If

                If DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.CPP.ToString) IsNot Nothing Then

                    AddSummaryItemToColumn(DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.CPP.ToString),
                                           "{0:c2}", DevExpress.Data.SummaryItemType.Custom, Nothing)

                End If

                If DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.GRP.ToString) IsNot Nothing Then

                    AddSummaryItemToColumn(DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.GRP.ToString),
                                           "{0:n2}", DevExpress.Data.SummaryItemType.Sum, Nothing)

                End If

                If DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.GIMP.ToString) IsNot Nothing Then

                    AddSummaryItemToColumn(DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.GIMP.ToString),
                                           "{0:n0}", DevExpress.Data.SummaryItemType.Sum, Nothing)

                End If

                If DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.PercentOfTotalGIMP.ToString) IsNot Nothing Then

                    DataGridViewForm_Totals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.PercentOfTotalGIMP.ToString).Caption = "% of Total GIMP"

                    'AddSummaryItemToColumn(DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.PercentOfTotalGIMP.ToString),
                    '                       "{0:p0}", DevExpress.Data.SummaryItemType.Sum, Nothing)

                End If

                If DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.CPM.ToString) IsNot Nothing Then

                    AddSummaryItemToColumn(DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.CPM.ToString),
                                           "{0:c2}", DevExpress.Data.SummaryItemType.Custom, Nothing)

                End If

                If DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.Budget.ToString) IsNot Nothing Then

                    AddSummaryItemToColumn(DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.Budget.ToString),
                                           "{0:c2}", DevExpress.Data.SummaryItemType.Sum, Nothing)

                End If

                If DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.GoalGRP.ToString) IsNot Nothing Then

                    AddSummaryItemToColumn(DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.GoalGRP.ToString),
                                           "{0:n2}", DevExpress.Data.SummaryItemType.Sum, Nothing)

                End If

                If DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.PercentOfBudget.ToString) IsNot Nothing Then

                    DataGridViewForm_Totals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.PercentOfBudget.ToString).Caption = "Cost %"

                    AddSummaryItemToColumn(DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.PercentOfBudget.ToString),
                                           "{0:p0}", DevExpress.Data.SummaryItemType.Custom, Nothing)

                End If

                If DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.PercentOfGRP.ToString) IsNot Nothing Then

                    DataGridViewForm_Totals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.PercentOfGRP.ToString).Caption = "GRP %"

                    AddSummaryItemToColumn(DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.PercentOfGRP.ToString),
                                           "{0:p0}", DevExpress.Data.SummaryItemType.Custom, Nothing)

                End If

                If DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.Reach.ToString) IsNot Nothing Then

                    AddSummaryItemToColumn(DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.Reach.ToString),
                                           "{0:p1}", DevExpress.Data.SummaryItemType.Custom, Nothing)

                End If

                If DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.Frequency.ToString) IsNot Nothing Then

                    AddSummaryItemToColumn(DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.Frequency.ToString),
                                           "{0:n1}", DevExpress.Data.SummaryItemType.Custom, Nothing)

                End If

                DataGridViewForm_Totals.OptionsView.ShowFooter = True
                DataGridViewForm_Totals.OptionsCustomization.AllowSort = True

            ElseIf RadioButtonForm_DaypartWeeklyDailySpendSummary.Checked Then

                DataGridViewForm_Totals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartWeeklyDailySummaryColumns.ID.ToString).Visible = False

                For Each GridColumn In DataGridViewForm_Totals.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).Where(Function(GC) _ViewModel.DetailDates.ContainsValue(GC.FieldName))

                    AddSummaryItemToColumn(GridColumn, "{0:c2}", DevExpress.Data.SummaryItemType.Sum, Nothing)

                Next

                If DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartWeeklyDailySummaryColumns.Totals.ToString) IsNot Nothing Then

                    AddSummaryItemToColumn(DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartWeeklyDailySummaryColumns.Totals.ToString),
                                           "{0:c2}", DevExpress.Data.SummaryItemType.Sum, Nothing)

                End If

                DataGridViewForm_Totals.OptionsView.ShowFooter = True
                DataGridViewForm_Totals.OptionsCustomization.AllowSort = False

            ElseIf RadioButtonForm_DaypartWeeklyDailyGRPSummary.Checked Then

                DataGridViewForm_Totals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartGRPWeeklyDailySummaryColumns.ID.ToString).Visible = False

                For Each GridColumn In DataGridViewForm_Totals.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).Where(Function(GC) _ViewModel.DetailDates.ContainsValue(GC.FieldName))

                    AddSummaryItemToColumn(GridColumn, "{0:n2}", DevExpress.Data.SummaryItemType.Sum, Nothing)

                Next

                If DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartGRPWeeklyDailySummaryColumns.Totals.ToString) IsNot Nothing Then

                    AddSummaryItemToColumn(DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartGRPWeeklyDailySummaryColumns.Totals.ToString),
                                           "{0:n2}", DevExpress.Data.SummaryItemType.Sum, Nothing)

                End If

                DataGridViewForm_Totals.OptionsView.ShowFooter = True
                DataGridViewForm_Totals.OptionsCustomization.AllowSort = False

            ElseIf RadioButtonForm_StationSummary.Checked Then

                DataGridViewForm_Totals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_StationSummaryColumns.ID.ToString).Visible = False

                If DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_StationSummaryColumns.Spots.ToString) IsNot Nothing Then

                    AddSummaryItemToColumn(DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_StationSummaryColumns.Spots.ToString),
                                           "{0:n0}", DevExpress.Data.SummaryItemType.Sum, Nothing)

                End If

                If DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_StationSummaryColumns.Cost.ToString) IsNot Nothing Then

                    AddSummaryItemToColumn(DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_StationSummaryColumns.Cost.ToString),
                                           "{0:c2}", DevExpress.Data.SummaryItemType.Sum, Nothing)

                End If

                If DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_StationSummaryColumns.CostPercentageOfTotal.ToString) IsNot Nothing Then

                    DataGridViewForm_Totals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_StationSummaryColumns.CostPercentageOfTotal.ToString).Caption = "% of Total Cost"

                End If

                If DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_StationSummaryColumns.GRP.ToString) IsNot Nothing Then

                    AddSummaryItemToColumn(DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_StationSummaryColumns.GRP.ToString),
                                           "{0:n2}", DevExpress.Data.SummaryItemType.Sum, Nothing)

                End If

                If DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_StationSummaryColumns.CPP.ToString) IsNot Nothing Then

                    AddSummaryItemToColumn(DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_StationSummaryColumns.CPP.ToString),
                                           "{0:c2}", DevExpress.Data.SummaryItemType.Custom, Nothing)

                End If

                If DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_StationSummaryColumns.GIMP.ToString) IsNot Nothing Then

                    AddSummaryItemToColumn(DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_StationSummaryColumns.GIMP.ToString),
                                           "{0:n0}", DevExpress.Data.SummaryItemType.Sum, Nothing)

                End If

                If DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_StationSummaryColumns.CPM.ToString) IsNot Nothing Then

                    AddSummaryItemToColumn(DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_StationSummaryColumns.CPM.ToString),
                                           "{0:c2}", DevExpress.Data.SummaryItemType.Custom, Nothing)

                End If

                If DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_StationSummaryColumns.Reach.ToString) IsNot Nothing Then

                    AddSummaryItemToColumn(DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_StationSummaryColumns.Reach.ToString),
                                           "{0:p1}", DevExpress.Data.SummaryItemType.Custom, Nothing)

                End If

                If DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_StationSummaryColumns.Frequency.ToString) IsNot Nothing Then

                    AddSummaryItemToColumn(DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_StationSummaryColumns.Frequency.ToString),
                                           "{0:n1}", DevExpress.Data.SummaryItemType.Custom, Nothing)

                End If

                DataGridViewForm_Totals.OptionsView.ShowFooter = True
                DataGridViewForm_Totals.OptionsCustomization.AllowSort = True

            ElseIf RadioButtonForm_StationMonthlySummary.Checked Then

                FormatGridStationMonthly()

                DataGridViewForm_Totals.CurrentView.ExpandAllGroups()

            ElseIf RadioButtonForm_LengthSummary.Checked Then

                DataGridViewForm_Totals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_LengthSummaryColumns.ID.ToString).Visible = False

                If DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_LengthSummaryColumns.Spots.ToString) IsNot Nothing Then

                    AddSummaryItemToColumn(DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_LengthSummaryColumns.Spots.ToString),
                                           "{0:n0}", DevExpress.Data.SummaryItemType.Sum, Nothing)

                End If

                If DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_LengthSummaryColumns.Cost.ToString) IsNot Nothing Then

                    AddSummaryItemToColumn(DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_LengthSummaryColumns.Cost.ToString),
                                           "{0:c2}", DevExpress.Data.SummaryItemType.Sum, Nothing)

                End If

                If DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_LengthSummaryColumns.CostPercentageOfTotal.ToString) IsNot Nothing Then

                    DataGridViewForm_Totals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_LengthSummaryColumns.CostPercentageOfTotal.ToString).Caption = "% of Total Cost"

                End If

                If DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_LengthSummaryColumns.GRP.ToString) IsNot Nothing Then

                    AddSummaryItemToColumn(DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_LengthSummaryColumns.GRP.ToString),
                                           "{0:n2}", DevExpress.Data.SummaryItemType.Sum, Nothing)

                End If

                If DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_LengthSummaryColumns.CPP.ToString) IsNot Nothing Then

                    AddSummaryItemToColumn(DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_LengthSummaryColumns.CPP.ToString),
                                           "{0:c2}", DevExpress.Data.SummaryItemType.Custom, Nothing)

                End If

                If DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_LengthSummaryColumns.GIMP.ToString) IsNot Nothing Then

                    AddSummaryItemToColumn(DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_LengthSummaryColumns.GIMP.ToString),
                                           "{0:n0}", DevExpress.Data.SummaryItemType.Sum, Nothing)

                End If

                If DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_LengthSummaryColumns.CPM.ToString) IsNot Nothing Then

                    AddSummaryItemToColumn(DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_LengthSummaryColumns.CPM.ToString),
                                           "{0:c2}", DevExpress.Data.SummaryItemType.Custom, Nothing)

                End If

                DataGridViewForm_Totals.OptionsView.ShowFooter = True
                DataGridViewForm_Totals.OptionsCustomization.AllowSort = True

            ElseIf RadioButtonForm_DaypartLengthSummary.Checked Then

                DataGridViewForm_Totals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartLengthSummaryColumns.ID.ToString).Visible = False

                If DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartLengthSummaryColumns.Spots.ToString) IsNot Nothing Then

                    AddSummaryItemToColumn(DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartLengthSummaryColumns.Spots.ToString),
                                           "{0:n0}", DevExpress.Data.SummaryItemType.Sum, Nothing)

                End If

                If DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartLengthSummaryColumns.Cost.ToString) IsNot Nothing Then

                    AddSummaryItemToColumn(DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartLengthSummaryColumns.Cost.ToString),
                                           "{0:c2}", DevExpress.Data.SummaryItemType.Sum, Nothing)

                End If

                If DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartLengthSummaryColumns.CostPercentageOfTotal.ToString) IsNot Nothing Then

                    DataGridViewForm_Totals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartLengthSummaryColumns.CostPercentageOfTotal.ToString).Caption = "% of Total Cost"

                End If

                If DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartLengthSummaryColumns.GRP.ToString) IsNot Nothing Then

                    AddSummaryItemToColumn(DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartLengthSummaryColumns.GRP.ToString),
                                           "{0:n2}", DevExpress.Data.SummaryItemType.Sum, Nothing)

                End If

                If DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartLengthSummaryColumns.CPP.ToString) IsNot Nothing Then

                    AddSummaryItemToColumn(DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartLengthSummaryColumns.CPP.ToString),
                                           "{0:c2}", DevExpress.Data.SummaryItemType.Custom, Nothing)

                End If

                If DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartLengthSummaryColumns.GIMP.ToString) IsNot Nothing Then

                    AddSummaryItemToColumn(DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartLengthSummaryColumns.GIMP.ToString),
                                           "{0:n0}", DevExpress.Data.SummaryItemType.Sum, Nothing)

                End If

                If DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartLengthSummaryColumns.CPM.ToString) IsNot Nothing Then

                    AddSummaryItemToColumn(DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartLengthSummaryColumns.CPM.ToString),
                                           "{0:c2}", DevExpress.Data.SummaryItemType.Custom, Nothing)

                End If

                If DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartLengthSummaryColumns.Reach.ToString) IsNot Nothing Then

                    AddSummaryItemToColumn(DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartLengthSummaryColumns.Reach.ToString),
                                           "{0:p1}", DevExpress.Data.SummaryItemType.Custom, Nothing)

                End If

                If DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartLengthSummaryColumns.Frequency.ToString) IsNot Nothing Then

                    AddSummaryItemToColumn(DataGridViewForm_Totals.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartLengthSummaryColumns.Frequency.ToString),
                                           "{0:n1}", DevExpress.Data.SummaryItemType.Custom, Nothing)

                End If

                DataGridViewForm_Totals.OptionsView.ShowFooter = True
                DataGridViewForm_Totals.OptionsCustomization.AllowSort = True

            End If

            DataGridViewForm_Totals.CurrentView.BestFitColumns()

        End Sub
        Private Sub FormatGridMarketSummaries()

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            DataGridViewForm_Totals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalColumns.RowTotalsGroup.ToString).Group()
            DataGridViewForm_Totals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalColumns.RowTotalsGroup.ToString).SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom

            DataGridViewForm_Totals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalColumns.ID.ToString).Visible = False
            DataGridViewForm_Totals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalColumns.ID.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Ascending

            DataGridViewForm_Totals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalColumns.RowTotalsDescription.ToString).Caption = ""
            DataGridViewForm_Totals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalColumns.RowTotalsDescription.ToString).OptionsColumn.ShowCaption = False

            DataGridViewForm_Totals.OptionsCustomization.AllowSort = False

            DataGridViewForm_Totals.CurrentView.GroupFormat = "{1}"

            If DataGridViewForm_Totals.CurrentView.Columns.Any(Function(GC) GC.FieldName = UnboundColumns.Totals.ToString AndAlso GC.UnboundType = DevExpress.Data.UnboundColumnType.Decimal) = False Then

                GridColumn = DataGridViewForm_Totals.Columns.AddField(UnboundColumns.Totals.ToString)

                GridColumn.VisibleIndex = DataGridViewForm_Totals.CurrentView.VisibleColumns.Count
                GridColumn.UnboundType = DevExpress.Data.UnboundColumnType.Decimal
                GridColumn.AppearanceHeader.FontStyleDelta = System.Drawing.FontStyle.Bold
                GridColumn.AppearanceHeader.Font = New System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold)

            End If

        End Sub
        Private Sub FormatGridStationMonthly()

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            DataGridViewForm_Totals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_StationMonthlySummaryColumns.Station.ToString).Group()
            DataGridViewForm_Totals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_StationMonthlySummaryColumns.Station.ToString).SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom

            DataGridViewForm_Totals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_StationMonthlySummaryColumns.ID.ToString).Visible = False
            DataGridViewForm_Totals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_StationMonthlySummaryColumns.ID.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Ascending

            DataGridViewForm_Totals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_StationMonthlySummaryColumns.DataType.ToString).Caption = ""
            DataGridViewForm_Totals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_StationMonthlySummaryColumns.DataType.ToString).OptionsColumn.ShowCaption = False

            DataGridViewForm_Totals.OptionsCustomization.AllowSort = False

            DataGridViewForm_Totals.CurrentView.GroupFormat = "{1}"

        End Sub
        Private Sub AddSummaryItemToColumn(GridColumn As DevExpress.XtraGrid.Columns.GridColumn, DisplayFormat As String, SummaryType As DevExpress.Data.SummaryItemType, Tag As Object)

            'objects
            Dim GridColumnSummaryItem As DevExpress.XtraGrid.GridColumnSummaryItem = Nothing

            GridColumnSummaryItem = New DevExpress.XtraGrid.GridColumnSummaryItem(SummaryType)

            GridColumnSummaryItem.FieldName = GridColumn.FieldName
            GridColumnSummaryItem.DisplayFormat = DisplayFormat
            GridColumnSummaryItem.Tag = Tag

            GridColumn.Summary.Add(GridColumnSummaryItem)

        End Sub
        Private Sub SetControlPropertySettings()

            DataGridViewForm_Totals.OptionsBehavior.Editable = False

            DataGridViewForm_Totals.OptionsCustomization.AllowColumnMoving = False
            DataGridViewForm_Totals.OptionsCustomization.AllowFilter = False
            DataGridViewForm_Totals.OptionsCustomization.AllowGroup = False
            DataGridViewForm_Totals.OptionsCustomization.AllowQuickHideColumns = False
            DataGridViewForm_Totals.OptionsCustomization.AllowRowSizing = False

            DataGridViewForm_Totals.OptionsMenu.EnableColumnMenu = True
            DataGridViewForm_Totals.OptionsMenu.EnableFooterMenu = False
            DataGridViewForm_Totals.OptionsMenu.EnableGroupPanelMenu = False

            DataGridViewForm_Totals.OptionsView.ShowGroupPanel = False
            DataGridViewForm_Totals.OptionsView.ShowViewCaption = False

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            If _ViewModel.Worksheet IsNot Nothing AndAlso _ViewModel.Worksheet.MediaBroadcastWorksheetDateTypeID = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.DateTypes.Weekly Then

                RadioButtonForm_MarketSummary.Text = String.Format(RadioButtonForm_MarketSummary.Text, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.DateTypes.Weekly.ToString)
                RadioButtonForm_DaypartWeeklyDailySpendSummary.Text = String.Format(RadioButtonForm_DaypartWeeklyDailySpendSummary.Text, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.DateTypes.Weekly.ToString)
                RadioButtonForm_DaypartWeeklyDailyGRPSummary.Text = String.Format(RadioButtonForm_DaypartWeeklyDailyGRPSummary.Text, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.DateTypes.Weekly.ToString)

            ElseIf _ViewModel.Worksheet IsNot Nothing AndAlso _ViewModel.Worksheet.MediaBroadcastWorksheetDateTypeID = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.DateTypes.Daily Then

                RadioButtonForm_MarketSummary.Text = String.Format(RadioButtonForm_MarketSummary.Text, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.DateTypes.Daily.ToString)
                RadioButtonForm_DaypartWeeklyDailySpendSummary.Text = String.Format(RadioButtonForm_DaypartWeeklyDailySpendSummary.Text, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.DateTypes.Daily.ToString)
                RadioButtonForm_DaypartWeeklyDailyGRPSummary.Text = String.Format(RadioButtonForm_DaypartWeeklyDailyGRPSummary.Text, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.DateTypes.Daily.ToString)

            End If

        End Sub
        Private Sub RefreshMediaBroadcastWorksheetMarketDetailForm()

            _DetailsForm.TotalsFormHiding()

        End Sub
        Private Function CreateTextBrick(X As Integer, Y As Integer, Width As Integer, Height As Integer, OutputString As String) As DevExpress.XtraPrinting.TextBrick

            'objects
            Dim TextBrick As DevExpress.XtraPrinting.TextBrick = Nothing

            TextBrick = New DevExpress.XtraPrinting.TextBrick

            TextBrick.Rect = New System.Drawing.Rectangle(X, Y, Width, Height)
            TextBrick.BackColor = System.Drawing.Color.White
            TextBrick.BorderWidth = 0
            TextBrick.BorderStyle = DevExpress.XtraPrinting.BrickBorderStyle.Inset
            TextBrick.Font = New System.Drawing.Font("Tahoma", TextBrick.Font.Size)

            TextBrick.Text = OutputString

            CreateTextBrick = TextBrick

        End Function
        Public Sub RefreshLabels()

            LabelForm_ClientName.Text = _ViewModel.Worksheet.ClientName
            LabelForm_WorksheetName.Text = _ViewModel.Worksheet.Name

            If _ViewModel.SelectedWorksheetMarket IsNot Nothing Then

                LabelForm_MarketName.Text = _ViewModel.SelectedWorksheetMarket.MarketDescription

            Else

                LabelForm_MarketName.Text = String.Empty

            End If

            LabelForm_DemoName.Text = _ViewModel.Worksheet.PrimaryMediaDemographicDescription
            LabelForm_FilterString.Text = _ViewModel.FilterString

            If LabelForm_FilterString.Text.StartsWith("(") Then

                LabelForm_FilterString.Text = LabelForm_FilterString.Text.Substring(1)

            End If

            If LabelForm_FilterString.Text.EndsWith(")") AndAlso LabelForm_FilterString.Text.Contains("In (") = False Then

                LabelForm_FilterString.Text = LabelForm_FilterString.Text.Substring(0, LabelForm_FilterString.Text.Length - 1)

            End If

            If LabelForm_FilterString.Text.Contains("]") Then

                LabelForm_FilterString.Text = LabelForm_FilterString.Text.Replace("]", "")

            End If

            If LabelForm_FilterString.Text.Contains("[") Then

                LabelForm_FilterString.Text = LabelForm_FilterString.Text.Replace("[", "")

            End If

            If LabelForm_FilterString.Text = String.Empty Then

                LabelForm_Filter.Text = ""

            Else

                LabelForm_Filter.Text = "Filter:"

            End If

        End Sub
        Public Sub RefreshData()

            Me.ShowOverlay()

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Me.CloseOverlay()

        End Sub
        Public Sub BeginDataUpdate()

            DataGridViewForm_Totals.CurrentView.BeginDataUpdate()

        End Sub
        Public Sub EndDataUpdate()

            DataGridViewForm_Totals.CurrentView.EndDataUpdate()

        End Sub
        Private Sub HideReachFrequencyColumns()

            If _ViewModel.Worksheet.RatingsServiceID = Nielsen.Database.Entities.RatingsServiceID.NielsenPuertoRico Then

                If DataGridViewForm_Totals.CurrentView.Columns("Reach") IsNot Nothing Then

                    DataGridViewForm_Totals.CurrentView.Columns("Reach").Visible = False

                End If

                If DataGridViewForm_Totals.CurrentView.Columns("Frequency") IsNot Nothing Then

                    DataGridViewForm_Totals.CurrentView.Columns("Frequency").Visible = False

                End If

            End If

        End Sub

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

        Private Sub MediaBroadcastWorksheetMarketDetailTotalsDialog_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

            If e.CloseReason = System.Windows.Forms.CloseReason.UserClosing Then

                e.Cancel = True

                Me.Hide()

                RefreshMediaBroadcastWorksheetMarketDetailForm()

            End If

        End Sub
        Private Sub MediaBroadcastWorksheetMarketDetailTotalsDialog_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            SetControlPropertySettings()

        End Sub
        Private Sub MediaBroadcastWorksheetMarketDetailTotalsDialog_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

            LoadGrid()

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            DataGridViewForm_Totals.CurrentView.ExpandAllGroups()

            DataGridViewForm_Totals.CurrentView.BestFitColumns()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Export_Click(sender As Object, e As EventArgs) Handles ButtonForm_Export.Click

            For Each GridColumn In DataGridViewForm_Totals.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                If GridColumn.RealColumnEdit IsNot Nothing Then

                    CType(GridColumn.RealColumnEdit, DevExpress.XtraEditors.Repository.RepositoryItem).ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText

                End If

            Next

            Me.TopMost = False

            DataGridViewForm_Totals.Print(Me.DefaultLookAndFeel.LookAndFeel, Me.Text, _Controller.GetAgency, _Controller.Session)

            Me.TopMost = True

        End Sub
        Private Sub DataGridViewForm_Totals_CustomColumnDisplayTextEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles DataGridViewForm_Totals.CustomColumnDisplayTextEvent

            If e.Column IsNot Nothing Then

                If RadioButtonForm_MarketSummary.Checked OrElse RadioButtonForm_MarketMonthlySummary.Checked Then

                    If e.Column.FieldName.StartsWith("Date") Then

                        If e.ListSourceRowIndex = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.TotalSpots Then

                            e.DisplayText = FormatNumber(e.Value, 0)

                        ElseIf e.ListSourceRowIndex = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.TotalRatings Then

                            e.DisplayText = FormatNumber(e.Value, 2)

                        ElseIf e.ListSourceRowIndex = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.TotalImpressions Then

                            e.DisplayText = FormatNumber(e.Value, 0)

                        ElseIf e.ListSourceRowIndex = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.TotalDollars Then

                            e.DisplayText = FormatCurrency(e.Value, 2)

                        ElseIf e.ListSourceRowIndex = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.TotalReach Then

                            If e.Value = 0 Then

                                e.DisplayText = "-"

                            Else

                                e.DisplayText = FormatPercent(e.Value, 1)

                            End If

                        ElseIf e.ListSourceRowIndex = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.TotalFrequency Then

                            e.DisplayText = FormatNumber(e.Value, 1)

                        ElseIf e.ListSourceRowIndex = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.GoalRatings Then

                            e.DisplayText = FormatNumber(e.Value, 2)

                        ElseIf e.ListSourceRowIndex = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.GoalDollars Then

                            e.DisplayText = FormatCurrency(e.Value, 2)

                        ElseIf e.ListSourceRowIndex = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.VarianceRatings Then

                            e.DisplayText = FormatNumber(e.Value, 2, Microsoft.VisualBasic.TriState.UseDefault, Microsoft.VisualBasic.TriState.True)

                        ElseIf e.ListSourceRowIndex = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.VarianceDollars Then

                            e.DisplayText = FormatCurrency(e.Value, 2)

                        ElseIf e.ListSourceRowIndex = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.VarianceRatingsPercent Then

                            If e.Value Is System.DBNull.Value OrElse e.Value = 0 Then

                                e.DisplayText = "-"

                            Else

                                e.DisplayText = FormatPercent(e.Value, 0)

                            End If

                        ElseIf e.ListSourceRowIndex = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.VarianceDollarsPercent Then

                            If e.Value Is System.DBNull.Value OrElse e.Value = 0 Then

                                e.DisplayText = "-"

                            Else

                                e.DisplayText = FormatPercent(e.Value, 0)

                            End If

                        End If

                    ElseIf e.Column IsNot Nothing AndAlso e.Column.FieldName = UnboundColumns.Totals.ToString Then

                        If e.ListSourceRowIndex = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.TotalSpots Then

                            e.DisplayText = FormatNumber(e.Value, 0)

                        ElseIf e.ListSourceRowIndex = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.TotalRatings Then

                            e.DisplayText = FormatNumber(e.Value, 2)

                        ElseIf e.ListSourceRowIndex = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.TotalImpressions Then

                            e.DisplayText = FormatNumber(e.Value, 0)

                        ElseIf e.ListSourceRowIndex = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.TotalDollars Then

                            e.DisplayText = FormatCurrency(e.Value, 2)

                        ElseIf e.ListSourceRowIndex = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.TotalReach Then

                            If e.Value = 0 Then

                                e.DisplayText = "-"

                            Else

                                e.DisplayText = FormatPercent(e.Value, 1)

                            End If

                        ElseIf e.ListSourceRowIndex = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.TotalFrequency Then

                            e.DisplayText = FormatNumber(e.Value, 1)

                        ElseIf e.ListSourceRowIndex = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.GoalRatings Then

                            e.DisplayText = FormatNumber(e.Value, 2)

                        ElseIf e.ListSourceRowIndex = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.GoalDollars Then

                            e.DisplayText = FormatCurrency(e.Value, 2)

                        ElseIf e.ListSourceRowIndex = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.VarianceRatings Then

                            e.DisplayText = FormatNumber(e.Value, 2, Microsoft.VisualBasic.TriState.UseDefault, Microsoft.VisualBasic.TriState.True)

                        ElseIf e.ListSourceRowIndex = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.VarianceDollars Then

                            e.DisplayText = FormatCurrency(e.Value, 2)

                        ElseIf e.ListSourceRowIndex = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.VarianceRatingsPercent Then

                            e.DisplayText = FormatPercent(e.Value, 0)

                        ElseIf e.ListSourceRowIndex = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.VarianceDollarsPercent Then

                            e.DisplayText = FormatPercent(e.Value, 0)

                        End If

                    End If

                ElseIf RadioButtonForm_DaypartSummary.Checked Then

                    If e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.Spots.ToString Then

                        e.DisplayText = FormatNumber(e.Value, 0)

                    ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.Cost.ToString Then

                        e.DisplayText = FormatCurrency(e.Value, 2)

                    ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.CostPercentageOfTotal.ToString Then

                        If e.Value Is System.DBNull.Value OrElse e.Value = 0 Then

                            e.DisplayText = "-"

                        Else

                            e.DisplayText = FormatPercent(e.Value, 0)

                        End If

                    ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.GRP.ToString Then

                        e.DisplayText = FormatNumber(e.Value, 2)

                    ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.CPP.ToString Then

                        e.DisplayText = FormatCurrency(e.Value, 2)

                    ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.GIMP.ToString Then

                        e.DisplayText = FormatNumber(e.Value, 0)

                    ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.PercentOfTotalGIMP.ToString Then

                        If e.Value Is System.DBNull.Value OrElse e.Value = 0 Then

                            e.DisplayText = "-"

                        Else

                            e.DisplayText = FormatPercent(e.Value, 0)

                        End If

                    ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.CPM.ToString Then

                        e.DisplayText = FormatCurrency(e.Value, 2)

                    ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.Budget.ToString Then

                        e.DisplayText = FormatCurrency(e.Value, 2)

                    ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.GoalGRP.ToString Then

                        e.DisplayText = FormatNumber(e.Value, 2)

                    ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.PercentOfBudget.ToString Then

                        If e.Value Is System.DBNull.Value OrElse e.Value = 0 Then

                            e.DisplayText = "-"

                        Else

                            e.DisplayText = FormatPercent(e.Value, 0)

                        End If

                    ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.PercentOfGRP.ToString Then

                        If e.Value Is System.DBNull.Value OrElse e.Value = 0 Then

                            e.DisplayText = "-"

                        Else

                            e.DisplayText = FormatPercent(e.Value, 0)

                        End If

                    ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.Reach.ToString Then

                        If e.Value = 0 Then

                            e.DisplayText = "-"

                        Else

                            e.DisplayText = FormatPercent(e.Value, 1)

                        End If

                    ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.Frequency.ToString Then

                        e.DisplayText = FormatNumber(e.Value, 1)

                    End If

                ElseIf RadioButtonForm_DaypartWeeklyDailySpendSummary.Checked Then

                    If _ViewModel.DetailDates.ContainsValue(e.Column.FieldName) Then

                        e.DisplayText = FormatCurrency(e.Value, 2)

                    ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartWeeklyDailySummaryColumns.Totals.ToString Then

                        e.DisplayText = FormatCurrency(e.Value, 2)

                    End If

                ElseIf RadioButtonForm_DaypartWeeklyDailyGRPSummary.Checked Then

                    If _ViewModel.DetailDates.ContainsValue(e.Column.FieldName) Then

                        e.DisplayText = FormatNumber(e.Value, 2)

                    ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartGRPWeeklyDailySummaryColumns.Totals.ToString Then

                        e.DisplayText = FormatNumber(e.Value, 2)

                    End If

                ElseIf RadioButtonForm_StationSummary.Checked Then

                    If e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_StationSummaryColumns.Spots.ToString Then

                        e.DisplayText = FormatNumber(e.Value, 0)

                    ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_StationSummaryColumns.Cost.ToString Then

                        e.DisplayText = FormatCurrency(e.Value, 2)

                    ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_StationSummaryColumns.CostPercentageOfTotal.ToString Then

                        If e.Value Is System.DBNull.Value OrElse e.Value = 0 Then

                            e.DisplayText = "-"

                        Else

                            e.DisplayText = FormatPercent(e.Value, 0)

                        End If

                    ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_StationSummaryColumns.GRP.ToString Then

                        e.DisplayText = FormatNumber(e.Value, 2)

                    ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_StationSummaryColumns.CPP.ToString Then

                        e.DisplayText = FormatCurrency(e.Value, 2)

                    ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_StationSummaryColumns.GIMP.ToString Then

                        e.DisplayText = FormatNumber(e.Value, 0)

                    ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_StationSummaryColumns.CPM.ToString Then

                        e.DisplayText = FormatCurrency(e.Value, 2)

                    ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_StationSummaryColumns.Reach.ToString Then

                        If e.Value = 0 Then

                            e.DisplayText = "-"

                        Else

                            e.DisplayText = FormatPercent(e.Value, 1)

                        End If

                    ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_StationSummaryColumns.Frequency.ToString Then

                        e.DisplayText = FormatNumber(e.Value, 1)

                    End If

                ElseIf RadioButtonForm_LengthSummary.Checked Then

                    If e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_LengthSummaryColumns.Spots.ToString Then

                        e.DisplayText = FormatNumber(e.Value, 0)

                    ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_LengthSummaryColumns.Cost.ToString Then

                        e.DisplayText = FormatCurrency(e.Value, 2)

                    ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_LengthSummaryColumns.CostPercentageOfTotal.ToString Then

                        If e.Value Is System.DBNull.Value OrElse e.Value = 0 Then

                            e.DisplayText = "-"

                        Else

                            e.DisplayText = FormatPercent(e.Value, 0)

                        End If

                    ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_LengthSummaryColumns.GRP.ToString Then

                        e.DisplayText = FormatNumber(e.Value, 2)

                    ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_LengthSummaryColumns.CPP.ToString Then

                        e.DisplayText = FormatCurrency(e.Value, 2)

                    ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_LengthSummaryColumns.GIMP.ToString Then

                        e.DisplayText = FormatNumber(e.Value, 0)

                    ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_LengthSummaryColumns.CPM.ToString Then

                        e.DisplayText = FormatCurrency(e.Value, 2)

                    End If

                ElseIf RadioButtonForm_DaypartLengthSummary.Checked Then

                    If e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartLengthSummaryColumns.Spots.ToString Then

                        e.DisplayText = FormatNumber(e.Value, 0)

                    ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartLengthSummaryColumns.Cost.ToString Then

                        e.DisplayText = FormatCurrency(e.Value, 2)

                    ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartLengthSummaryColumns.CostPercentageOfTotal.ToString Then

                        If e.Value Is System.DBNull.Value OrElse e.Value = 0 Then

                            e.DisplayText = "-"

                        Else

                            e.DisplayText = FormatPercent(e.Value, 0)

                        End If

                    ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartLengthSummaryColumns.GRP.ToString Then

                        e.DisplayText = FormatNumber(e.Value, 2)

                    ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartLengthSummaryColumns.CPP.ToString Then

                        e.DisplayText = FormatCurrency(e.Value, 2)

                    ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartLengthSummaryColumns.GIMP.ToString Then

                        e.DisplayText = FormatNumber(e.Value, 0)

                    ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartLengthSummaryColumns.CPM.ToString Then

                        e.DisplayText = FormatCurrency(e.Value, 2)

                    ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartLengthSummaryColumns.Reach.ToString Then

                        If e.Value = 0 Then

                            e.DisplayText = "-"

                        Else

                            e.DisplayText = FormatPercent(e.Value, 1)

                        End If

                    ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartLengthSummaryColumns.Frequency.ToString Then

                        e.DisplayText = FormatNumber(e.Value, 1)

                    End If

                ElseIf RadioButtonForm_StationMonthlySummary.Checked Then

                    If e.Column.FieldName.StartsWith("Date") OrElse e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_StationMonthlySummaryColumns.Totals.ToString Then

                        If DataGridViewForm_Totals.CurrentView.GetRowCellValue(e.ListSourceRowIndex, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_StationMonthlySummaryColumns.DataType.ToString) = "Cost" Then

                            e.DisplayText = FormatCurrency(e.Value, 2)

                        ElseIf DataGridViewForm_Totals.CurrentView.GetRowCellValue(e.ListSourceRowIndex, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_StationMonthlySummaryColumns.DataType.ToString) = "GRP" Then

                            e.DisplayText = FormatNumber(e.Value, 2)

                        ElseIf DataGridViewForm_Totals.CurrentView.GetRowCellValue(e.ListSourceRowIndex, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_StationMonthlySummaryColumns.DataType.ToString) = "Spots" Then

                            e.DisplayText = FormatNumber(e.Value, 0)

                        ElseIf DataGridViewForm_Totals.CurrentView.GetRowCellValue(e.ListSourceRowIndex, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_StationMonthlySummaryColumns.DataType.ToString) = "CPP" Then

                            e.DisplayText = FormatCurrency(e.Value, 2)

                        ElseIf DataGridViewForm_Totals.CurrentView.GetRowCellValue(e.ListSourceRowIndex, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_StationMonthlySummaryColumns.DataType.ToString) = "GIMP" Then

                            e.DisplayText = FormatNumber(e.Value, 0)

                        ElseIf DataGridViewForm_Totals.CurrentView.GetRowCellValue(e.ListSourceRowIndex, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_StationMonthlySummaryColumns.DataType.ToString) = "CPM" Then

                            e.DisplayText = FormatCurrency(e.Value, 2)

                        ElseIf DataGridViewForm_Totals.CurrentView.GetRowCellValue(e.ListSourceRowIndex, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_StationMonthlySummaryColumns.DataType.ToString) = "Reach" Then

                            If e.Value = 0 Then

                                e.DisplayText = "-"

                            Else

                                e.DisplayText = FormatPercent(e.Value, 1)

                            End If

                        ElseIf DataGridViewForm_Totals.CurrentView.GetRowCellValue(e.ListSourceRowIndex, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_StationMonthlySummaryColumns.DataType.ToString) = "Frequency" Then

                            e.DisplayText = FormatNumber(e.Value, 1)

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Totals_CustomColumnGroupEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs) Handles DataGridViewForm_Totals.CustomColumnGroupEvent

            If e.Value1 = e.Value2 Then

                e.Result = 0

            Else

                e.Result = 1

            End If

            e.Handled = True

        End Sub
        Private Sub DataGridViewForm_Totals_CustomColumnSortEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs) Handles DataGridViewForm_Totals.CustomColumnSortEvent

            e.Result = 0

            e.Handled = True

        End Sub
        Private Sub DataGridViewForm_Totals_PopupMenuShowingEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles DataGridViewForm_Totals.PopupMenuShowingEvent

            If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Column Then

                For Each MenuItem As DevExpress.Utils.Menu.DXMenuItem In e.Menu.Items

                    Select Case MenuItem.Tag

                        Case DevExpress.XtraGrid.Localization.GridStringId.MenuColumnBestFit,
                                 DevExpress.XtraGrid.Localization.GridStringId.MenuColumnBestFitAllColumns

                            MenuItem.Visible = True

                        Case Else

                            MenuItem.Visible = False

                    End Select

                Next

            End If

        End Sub
        Private Sub DataGridViewForm_Totals_CustomUnboundColumnDataEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles DataGridViewForm_Totals.CustomUnboundColumnDataEvent

            'objects
            Dim Totals As Decimal = 0
            Dim TotalDollars As Decimal = 0
            Dim TotalGoalDollars As Decimal = 0
            Dim TotalRating As Decimal = 0
            Dim TotalGoalRating As Decimal = 0

            If RadioButtonForm_MarketSummary.Checked OrElse RadioButtonForm_MarketMonthlySummary.Checked Then

                If e.Column IsNot Nothing AndAlso e.Column.FieldName = UnboundColumns.Totals.ToString AndAlso e.IsGetData Then

                    If e.ListSourceRowIndex = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.VarianceDollarsPercent Then

                        TotalDollars = DataGridViewForm_Totals.CurrentView.GetRowCellValue(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.TotalDollars, e.Column)
                        TotalGoalDollars = DataGridViewForm_Totals.CurrentView.GetRowCellValue(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.GoalDollars, e.Column)

                        If TotalGoalDollars <> 0 Then

                            Totals = TotalDollars / TotalGoalDollars

                        End If

                    ElseIf e.ListSourceRowIndex = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.VarianceRatingsPercent Then

                        TotalRating = DataGridViewForm_Totals.CurrentView.GetRowCellValue(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.TotalRatings, e.Column)
                        TotalGoalRating = DataGridViewForm_Totals.CurrentView.GetRowCellValue(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.GoalRatings, e.Column)

                        If TotalGoalRating <> 0 Then

                            Totals = TotalRating / TotalGoalRating

                        End If

                    ElseIf e.ListSourceRowIndex = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.TotalReach Then

                        Totals = _Controller.MarketDetails_CalculateReachTotal(_ViewModel, String.Empty, True, String.Empty)

                    ElseIf e.ListSourceRowIndex = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.TotalFrequency Then

                        Totals = _Controller.MarketDetails_CalculateFrequencyTotal(_ViewModel, String.Empty, True, String.Empty)

                    Else

                        For Each GridColumn In DataGridViewForm_Totals.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).Where(Function(GC) GC.FieldName.StartsWith("Date"))

                            Totals += DataGridViewForm_Totals.CurrentView.GetListSourceRowCellValue(e.ListSourceRowIndex, GridColumn)

                        Next

                    End If

                    e.Value = Totals

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Totals_RowCellStyleEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles DataGridViewForm_Totals.RowCellStyleEvent

            If RadioButtonForm_MarketSummary.Checked OrElse RadioButtonForm_MarketMonthlySummary.Checked OrElse RadioButtonForm_StationMonthlySummary.Checked Then

                If e.Column.FieldName = UnboundColumns.Totals.ToString Then

                    e.Appearance.BackColor = System.Drawing.Color.FromArgb(155, 200, 230)
                    e.Appearance.BackColor2 = System.Drawing.Color.White
                    e.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
                    e.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Totals_CustomDrawColumnHeaderEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs) Handles DataGridViewForm_Totals.CustomDrawColumnHeaderEvent

            If RadioButtonForm_MarketSummary.Checked OrElse RadioButtonForm_DaypartWeeklyDailySpendSummary.Checked OrElse RadioButtonForm_DaypartWeeklyDailyGRPSummary.Checked Then

                If e.Column IsNot Nothing AndAlso _ViewModel IsNot Nothing AndAlso _ViewModel.DetailDates.ContainsValue(e.Column.FieldName) AndAlso _ViewModel.HiatusDataTable.Rows.Count > 0 Then

                    If _ViewModel.HiatusDataTable.Rows(0)(e.Column.FieldName) = True Then

                        e.Appearance.ForeColor = System.Drawing.Color.Red

                        e.DefaultDraw()

                        e.Handled = True

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Totals_CreateReportHeaderAreaEvent(sender As Object, e As DevExpress.XtraPrinting.CreateAreaEventArgs) Handles DataGridViewForm_Totals.CreateReportHeaderAreaEvent

            'objects
            Dim TextBrick As DevExpress.XtraPrinting.TextBrick = Nothing
            Dim VeritcalLocation As Integer = 0

            '=========================================
            TextBrick = CreateTextBrick(0, VeritcalLocation, e.Graph.ClientPageSize.Width, 15, LabelForm_Client.Text & " " & LabelForm_ClientName.Text)

            e.Graph.DrawBrick(TextBrick)

            VeritcalLocation += 15
            '=========================================
            TextBrick = CreateTextBrick(0, VeritcalLocation, e.Graph.ClientPageSize.Width, 15, LabelForm_Worksheet.Text & " " & LabelForm_WorksheetName.Text)

            e.Graph.DrawBrick(TextBrick)

            VeritcalLocation += 15
            '=========================================
            TextBrick = CreateTextBrick(0, VeritcalLocation, e.Graph.ClientPageSize.Width, 15, LabelForm_Market.Text & " " & LabelForm_MarketName.Text)

            e.Graph.DrawBrick(TextBrick)

            VeritcalLocation += 15
            '=========================================
            TextBrick = CreateTextBrick(0, VeritcalLocation, e.Graph.ClientPageSize.Width, 15, LabelForm_Demo.Text & " " & LabelForm_DemoName.Text)

            e.Graph.DrawBrick(TextBrick)

            VeritcalLocation += 15
            '=========================================
            TextBrick = CreateTextBrick(0, VeritcalLocation, e.Graph.ClientPageSize.Width, 15, LabelForm_Filter.Text & " " & LabelForm_FilterString.Text)

            e.Graph.DrawBrick(TextBrick)

            VeritcalLocation += 15

        End Sub
        Private Sub DataGridViewForm_Totals_CustomSummaryCalculateEvent(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles DataGridViewForm_Totals.CustomSummaryCalculateEvent

            'objects
            Dim DataRow As System.Data.DataRow = Nothing
            Dim GridColumnSummaryItem As DevExpress.XtraGrid.GridColumnSummaryItem = Nothing
            Dim GridGroupSummaryItem As DevExpress.XtraGrid.GridGroupSummaryItem = Nothing

            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then

                e.TotalValueReady = True

            End If

            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then

                If e.IsTotalSummary Then

                    GridColumnSummaryItem = CType(e.Item, DevExpress.XtraGrid.GridColumnSummaryItem)

                    If RadioButtonForm_DaypartSummary.Checked Then

                        If GridColumnSummaryItem.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.PercentOfBudget.ToString Then

                            e.TotalValue = _Controller.MarketDetails_CalculateDaypartSummaryCostPercentage(_ViewModel)

                        ElseIf GridColumnSummaryItem.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.PercentOfGRP.ToString Then

                            e.TotalValue = _Controller.MarketDetails_CalculateDaypartSummaryGRPPercentage(_ViewModel)

                        ElseIf GridColumnSummaryItem.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.CPP.ToString Then

                            e.TotalValue = _Controller.MarketDetails_CalculateDaypartSummaryCPP(_ViewModel)

                        ElseIf GridColumnSummaryItem.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.CPM.ToString Then

                            e.TotalValue = _Controller.MarketDetails_CalculateDaypartSummaryCPM(_ViewModel)

                        ElseIf GridColumnSummaryItem.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.Reach.ToString Then

                            e.TotalValue = _Controller.MarketDetails_CalculateReachTotal(_ViewModel, String.Empty, True, String.Empty)

                        ElseIf GridColumnSummaryItem.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartSummaryColumns.Frequency.ToString Then

                            e.TotalValue = _Controller.MarketDetails_CalculateFrequencyTotal(_ViewModel, String.Empty, True, String.Empty)

                        End If

                    ElseIf RadioButtonForm_StationSummary.Checked Then

                        If GridColumnSummaryItem.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_StationSummaryColumns.CPP.ToString Then

                            e.TotalValue = _Controller.MarketDetails_CalculateStationSummaryCPP(_ViewModel)

                        ElseIf GridColumnSummaryItem.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_StationSummaryColumns.CPM.ToString Then

                            e.TotalValue = _Controller.MarketDetails_CalculateStationSummaryCPM(_ViewModel)

                        ElseIf GridColumnSummaryItem.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_StationSummaryColumns.Reach.ToString Then

                            e.TotalValue = _Controller.MarketDetails_CalculateReachTotal(_ViewModel, String.Empty, True, String.Empty)

                        ElseIf GridColumnSummaryItem.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_StationSummaryColumns.Frequency.ToString Then

                            e.TotalValue = _Controller.MarketDetails_CalculateFrequencyTotal(_ViewModel, String.Empty, True, String.Empty)

                        End If

                    ElseIf RadioButtonForm_LengthSummary.Checked Then

                        If GridColumnSummaryItem.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_LengthSummaryColumns.CPP.ToString Then

                            e.TotalValue = _Controller.MarketDetails_CalculateLengthSummaryCPP(_ViewModel)

                        ElseIf GridColumnSummaryItem.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_LengthSummaryColumns.CPM.ToString Then

                            e.TotalValue = _Controller.MarketDetails_CalculateLengthSummaryCPM(_ViewModel)

                        End If

                    ElseIf RadioButtonForm_DaypartLengthSummary.Checked Then

                        If GridColumnSummaryItem.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartLengthSummaryColumns.CPP.ToString Then

                            e.TotalValue = _Controller.MarketDetails_CalculateDaypartLengthSummaryCPP(_ViewModel)

                        ElseIf GridColumnSummaryItem.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartLengthSummaryColumns.CPM.ToString Then

                            e.TotalValue = _Controller.MarketDetails_CalculateDaypartLengthSummaryCPM(_ViewModel)

                        ElseIf GridColumnSummaryItem.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartLengthSummaryColumns.Reach.ToString Then

                            e.TotalValue = _Controller.MarketDetails_CalculateReachTotal(_ViewModel, String.Empty, True, String.Empty)

                        ElseIf GridColumnSummaryItem.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_DaypartLengthSummaryColumns.Frequency.ToString Then

                            e.TotalValue = _Controller.MarketDetails_CalculateFrequencyTotal(_ViewModel, String.Empty, True, String.Empty)

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub ToolTipController_GetActiveObjectInfo(sender As Object, e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs) Handles ToolTipController.GetActiveObjectInfo

            'objects
            Dim ToolTipControlInfo As DevExpress.Utils.ToolTipControlInfo = Nothing

            If e.Info Is Nothing Then

                If e.SelectedControl Is RadioButtonForm_MarketSummary Then

                    ToolTipControlInfo = New DevExpress.Utils.ToolTipControlInfo(RadioButtonForm_MarketSummary.Name, "Market Summary")

                ElseIf e.SelectedControl Is RadioButtonForm_MarketMonthlySummary Then

                    ToolTipControlInfo = New DevExpress.Utils.ToolTipControlInfo(RadioButtonForm_MarketMonthlySummary.Name, "Market Monthly Summary")

                ElseIf e.SelectedControl Is RadioButtonForm_DaypartSummary Then

                    ToolTipControlInfo = New DevExpress.Utils.ToolTipControlInfo(RadioButtonForm_DaypartSummary.Name, "Daypart Summary")

                ElseIf e.SelectedControl Is RadioButtonForm_DaypartWeeklyDailySpendSummary Then

                    ToolTipControlInfo = New DevExpress.Utils.ToolTipControlInfo(RadioButtonForm_DaypartWeeklyDailySpendSummary.Name, "Daypart Weekly Spend Summary")

                ElseIf e.SelectedControl Is RadioButtonForm_DaypartWeeklyDailyGRPSummary Then

                    ToolTipControlInfo = New DevExpress.Utils.ToolTipControlInfo(RadioButtonForm_DaypartWeeklyDailyGRPSummary.Name, "Daypart Weekly GRP Summary")

                ElseIf e.SelectedControl Is RadioButtonForm_StationSummary Then

                    ToolTipControlInfo = New DevExpress.Utils.ToolTipControlInfo(RadioButtonForm_StationSummary.Name, "Station Summary")

                ElseIf e.SelectedControl Is RadioButtonForm_StationMonthlySummary Then

                    ToolTipControlInfo = New DevExpress.Utils.ToolTipControlInfo(RadioButtonForm_StationMonthlySummary.Name, "Station Monthly Summary")

                ElseIf e.SelectedControl Is RadioButtonForm_LengthSummary Then

                    ToolTipControlInfo = New DevExpress.Utils.ToolTipControlInfo(RadioButtonForm_LengthSummary.Name, "Length Summary")

                ElseIf e.SelectedControl Is RadioButtonForm_DaypartLengthSummary Then

                    ToolTipControlInfo = New DevExpress.Utils.ToolTipControlInfo(RadioButtonForm_DaypartLengthSummary.Name, "Daypart / Length Summary")

                End If

                If ToolTipControlInfo IsNot Nothing Then

                    e.Info = ToolTipControlInfo

                End If

            End If

        End Sub
        Private Sub RadioButtonForm_MarketSummary_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonForm_MarketSummary.CheckedChanged

            If Me.FormShown AndAlso RadioButtonForm_MarketSummary.Checked Then

                Me.ShowOverlay()

                Try

                    _ViewModel.SelectedScheduleSummary = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.ScheduleSummaries.Default

                    _Controller.MarketDetails_LoadSummaryDataTables(_ViewModel)

                    LoadGrid()

                Catch ex As Exception

                End Try

                Me.CloseOverlay()

            End If

        End Sub
        Private Sub RadioButtonForm_MarketMonthlySummary_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonForm_MarketMonthlySummary.CheckedChanged

            If Me.FormShown AndAlso RadioButtonForm_MarketMonthlySummary.Checked Then

                Me.ShowOverlay()

                Try

                    _ViewModel.SelectedScheduleSummary = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.ScheduleSummaries.MarketMonthly

                    _Controller.MarketDetails_LoadSummaryDataTables(_ViewModel)

                    LoadGrid()

                Catch ex As Exception

                End Try

                Me.CloseOverlay()

            End If

        End Sub
        Private Sub RadioButtonForm_DaypartSummary_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonForm_DaypartSummary.CheckedChanged

            If Me.FormShown AndAlso RadioButtonForm_DaypartSummary.Checked Then

                Me.ShowOverlay()

                Try

                    _ViewModel.SelectedScheduleSummary = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.ScheduleSummaries.Daypart

                    _Controller.MarketDetails_LoadSummaryDataTables(_ViewModel)

                    LoadGrid()

                Catch ex As Exception

                End Try

                Me.CloseOverlay()

            End If

        End Sub
        Private Sub RadioButtonForm_DaypartWeeklyDailySpendSummary_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonForm_DaypartWeeklyDailySpendSummary.CheckedChanged

            If Me.FormShown AndAlso RadioButtonForm_DaypartWeeklyDailySpendSummary.Checked Then

                Me.ShowOverlay()

                Try

                    _ViewModel.SelectedScheduleSummary = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.ScheduleSummaries.DaypartWeeklyDaily

                    _Controller.MarketDetails_LoadSummaryDataTables(_ViewModel)

                    LoadGrid()

                Catch ex As Exception

                End Try

                Me.CloseOverlay()

            End If

        End Sub
        Private Sub RadioButtonForm_DaypartWeeklyDailyGRPSummary_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonForm_DaypartWeeklyDailyGRPSummary.CheckedChanged

            If Me.FormShown AndAlso RadioButtonForm_DaypartWeeklyDailyGRPSummary.Checked Then

                Me.ShowOverlay()

                Try

                    _ViewModel.SelectedScheduleSummary = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.ScheduleSummaries.DaypartGRPWeeklyDaily

                    _Controller.MarketDetails_LoadSummaryDataTables(_ViewModel)

                    LoadGrid()

                Catch ex As Exception

                End Try

                Me.CloseOverlay()

            End If

        End Sub
        Private Sub RadioButtonForm_StationSummary_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonForm_StationSummary.CheckedChanged

            If Me.FormShown AndAlso RadioButtonForm_StationSummary.Checked Then

                Me.ShowOverlay()

                Try

                    _ViewModel.SelectedScheduleSummary = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.ScheduleSummaries.Station

                    _Controller.MarketDetails_LoadSummaryDataTables(_ViewModel)

                    LoadGrid()

                Catch ex As Exception

                End Try

                Me.CloseOverlay()

            End If

        End Sub
        Private Sub RadioButtonForm_StationMonthlySummary_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonForm_StationMonthlySummary.CheckedChanged

            If Me.FormShown AndAlso RadioButtonForm_StationMonthlySummary.Checked Then

                Me.ShowOverlay()

                Try

                    _ViewModel.SelectedScheduleSummary = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.ScheduleSummaries.StationMonthly

                    _Controller.MarketDetails_LoadSummaryDataTables(_ViewModel)

                    LoadGrid()

                Catch ex As Exception

                End Try

                Me.CloseOverlay()

            End If

        End Sub
        Private Sub RadioButtonForm_LengthSummary_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonForm_LengthSummary.CheckedChanged

            If Me.FormShown AndAlso RadioButtonForm_LengthSummary.Checked Then

                Me.ShowOverlay()

                Try

                    _ViewModel.SelectedScheduleSummary = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.ScheduleSummaries.Length

                    _Controller.MarketDetails_LoadSummaryDataTables(_ViewModel)

                    LoadGrid()

                Catch ex As Exception

                End Try

                Me.CloseOverlay()

            End If

        End Sub
        Private Sub RadioButtonForm_DaypartLengthSummary_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonForm_DaypartLengthSummary.CheckedChanged

            If Me.FormShown AndAlso RadioButtonForm_DaypartLengthSummary.Checked Then

                Me.ShowOverlay()

                Try

                    _ViewModel.SelectedScheduleSummary = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.ScheduleSummaries.DaypartLength

                    _Controller.MarketDetails_LoadSummaryDataTables(_ViewModel)

                    LoadGrid()

                Catch ex As Exception

                End Try

                Me.CloseOverlay()

            End If

        End Sub
        Private Sub DataGridViewForm_Totals_CustomRowFilterEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowFilterEventArgs) Handles DataGridViewForm_Totals.CustomRowFilterEvent

            'objects
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim DataRowView As System.Data.DataRowView = Nothing

            If _ViewModel.Worksheet.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.NielsenPuertoRico AndAlso
                    (RadioButtonForm_MarketSummary.Checked OrElse RadioButtonForm_MarketMonthlySummary.Checked) Then

                Try

                    BindingSource = DataGridViewForm_Totals.DataSource

                Catch ex As Exception

                End Try

                If BindingSource IsNot Nothing Then

                    If BindingSource(e.ListSourceRow) IsNot Nothing Then

                        If TypeOf BindingSource(e.ListSourceRow) Is System.Data.DataRowView Then

                            DataRowView = BindingSource(e.ListSourceRow)

                            If (RadioButtonForm_MarketSummary.Checked OrElse RadioButtonForm_MarketMonthlySummary.Checked) AndAlso DataRowView.Row.Table.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalColumns.RowTotalsGroup.ToString) IsNot Nothing AndAlso
                                    DataRowView.Row.Table.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalColumns.RowTotalsDescription.ToString) IsNot Nothing AndAlso
                                    DataRowView.Row(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalColumns.RowTotalsGroup.ToString) = "Worksheet" AndAlso
                                    (DataRowView.Row(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalColumns.RowTotalsDescription.ToString) = "Reach" OrElse
                                     DataRowView.Row(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalColumns.RowTotalsDescription.ToString) = "Frequency") Then

                                e.Visible = False
                                e.Handled = True

                            End If

                        End If

                    End If

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
