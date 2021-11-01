Namespace Media.Presentation

    Public Class MediaBroadcastWorksheetMarketGoalDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketGoalsViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController = Nothing
        Protected _MediaBroadcastWorksheetID As Integer = 0
        Protected _MediaBroadcastWorksheetMarketID As Integer = 0

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(MediaBroadcastWorksheetID As Integer, MediaBroadcastWorksheetMarketID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            _MediaBroadcastWorksheetID = MediaBroadcastWorksheetID
            _MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarketID

        End Sub
        Private Sub LoadViewModel()

            _ViewModel = _Controller.MarketGoals_Load(_MediaBroadcastWorksheetID, _MediaBroadcastWorksheetMarketID)

        End Sub
        Private Sub LoadGrid()

            DataGridViewForm_Goals.DataSource = _ViewModel.DataTable

        End Sub
        Private Sub FormatGrid()

            'objects
            Dim GridColumnSummaryItem As DevExpress.XtraGrid.GridColumnSummaryItem = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            DataGridViewForm_Goals.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.ID.ToString)
            DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.ID.ToString).OptionsColumn.AllowMove = False
            DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.ID.ToString).OptionsColumn.ShowInCustomizationForm = False
            DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.ID.ToString).OptionsColumn.ShowInExpressionEditor = False
            DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.ID.ToString).OptionsColumn.AllowShowHide = False
            DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.ID.ToString).OptionsFilter.AllowFilter = False

            DataGridViewForm_Goals.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.WorksheetMarketGoalID.ToString)
            DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.WorksheetMarketGoalID.ToString).OptionsColumn.AllowMove = False
            DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.WorksheetMarketGoalID.ToString).OptionsColumn.ShowInCustomizationForm = False
            DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.WorksheetMarketGoalID.ToString).OptionsColumn.ShowInExpressionEditor = False
            DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.WorksheetMarketGoalID.ToString).OptionsColumn.AllowShowHide = False
            DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.WorksheetMarketGoalID.ToString).OptionsFilter.AllowFilter = False

            DataGridViewForm_Goals.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.WasRateImported.ToString)
            DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.WasRateImported.ToString).OptionsColumn.AllowMove = False
            DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.WasRateImported.ToString).OptionsColumn.ShowInCustomizationForm = False
            DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.WasRateImported.ToString).OptionsColumn.ShowInExpressionEditor = False
            DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.WasRateImported.ToString).OptionsColumn.AllowShowHide = False
            DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.WasRateImported.ToString).OptionsFilter.AllowFilter = False

            DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.Daypart.ToString).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.Daypart.ToString).OptionsColumn.AllowMove = False
            DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.Daypart.ToString).OptionsColumn.ShowInCustomizationForm = False
            DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.Daypart.ToString).OptionsColumn.AllowShowHide = False

            DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.Length.ToString).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.Length.ToString).OptionsColumn.AllowMove = False
            DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.Length.ToString).OptionsColumn.ShowInCustomizationForm = False
            DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.Length.ToString).OptionsColumn.AllowShowHide = False

            DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.GRP.ToString).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.GRP.ToString).OptionsColumn.AllowMove = False
            DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.GRP.ToString).OptionsColumn.ShowInCustomizationForm = False
            DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.GRP.ToString).OptionsColumn.AllowShowHide = False
            DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.GRP.ToString).Summary.Add(New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum,
                                                                                                                                                                                                            DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.GRP.ToString).FieldName,
                                                                                                                                                                                                            "{0:f1}"))

            DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.CPP.ToString).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.CPP.ToString).OptionsColumn.AllowMove = False
            DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.CPP.ToString).OptionsColumn.ShowInCustomizationForm = False
            DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.CPP.ToString).OptionsColumn.AllowShowHide = False
            DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.CPP.ToString).Summary.Add(New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom,
                                                                                                                                                                                                            DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.CPP.ToString).FieldName,
                                                                                                                                                                                                            "{0:c2}"))

            DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.Budget.ToString).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.Budget.ToString).OptionsColumn.AllowMove = False
            DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.Budget.ToString).OptionsColumn.ShowInCustomizationForm = False
            DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.Budget.ToString).OptionsColumn.AllowShowHide = False
            DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.Budget.ToString).Summary.Add(New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum,
                                                                                                                                                                                                               DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.Budget.ToString).FieldName,
                                                                                                                                                                                                               "{0:c2}"))

            DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.Percentage.ToString).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.Percentage.ToString).OptionsColumn.AllowEdit = False
            DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.Percentage.ToString).OptionsColumn.AllowMove = False
            DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.Percentage.ToString).OptionsColumn.ShowInCustomizationForm = False
            DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.Percentage.ToString).OptionsColumn.AllowShowHide = False
            DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.Percentage.ToString).Summary.Add(New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum,
                                                                                                                                                                                                                   DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.Percentage.ToString).FieldName,
                                                                                                                                                                                                                   "{0:p0}"))

            GridColumnSummaryItem = New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)

            GridColumnSummaryItem.Tag = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.CPP.ToString
            GridColumnSummaryItem.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.Percentage.ToString

            DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.Percentage.ToString).Summary.Add(GridColumnSummaryItem)

            GridColumnSummaryItem = New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)

            GridColumnSummaryItem.Tag = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.Budget.ToString
            GridColumnSummaryItem.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.Percentage.ToString

            DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.Percentage.ToString).Summary.Add(GridColumnSummaryItem)

            For Each GoalDate In _ViewModel.GoalDates.Keys.OfType(Of Date).OrderBy(Function(GD) GD)

                GridColumn = DataGridViewForm_Goals.Columns(_ViewModel.GoalDates(GoalDate).ToString)

                GridColumnSummaryItem = New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)

                GridColumnSummaryItem.FieldName = GridColumn.FieldName
                GridColumnSummaryItem.DisplayFormat = "{0:f1}"

                GridColumn.Summary.Add(GridColumnSummaryItem)

                GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridColumn.DisplayFormat.FormatString = "f1"
                GridColumn.OptionsColumn.AllowMove = False
                GridColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False
                GridColumn.OptionsColumn.ShowInCustomizationForm = False
                GridColumn.OptionsColumn.ShowInExpressionEditor = False
                GridColumn.OptionsColumn.AllowShowHide = False
                GridColumn.OptionsFilter.AllowFilter = False
                GridColumn.OptionsColumn.AllowFocus = Not _ViewModel.HiatusDataTable.Rows(0)(GridColumn.FieldName)

            Next

            For Each GoalDate In _ViewModel.GoalDates.Keys.OfType(Of Date).OrderBy(Function(GD) GD)

                GridColumn = DataGridViewForm_Goals.Columns(_ViewModel.GoalDates(GoalDate).ToString)

                GridColumnSummaryItem = New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom)

                GridColumnSummaryItem.Tag = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.CPP.ToString
                GridColumnSummaryItem.FieldName = GridColumn.FieldName
                GridColumnSummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom
                GridColumnSummaryItem.DisplayFormat = "{0:c2}"

                GridColumn.Summary.Add(GridColumnSummaryItem)

            Next

            For Each GoalDate In _ViewModel.GoalDates.Keys.OfType(Of Date).OrderBy(Function(GD) GD)

                GridColumn = DataGridViewForm_Goals.Columns(_ViewModel.GoalDates(GoalDate).ToString)

                GridColumnSummaryItem = New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom)

                GridColumnSummaryItem.Tag = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.Budget.ToString
                GridColumnSummaryItem.FieldName = GridColumn.FieldName
                GridColumnSummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom
                GridColumnSummaryItem.DisplayFormat = "{0:c2}"

                GridColumn.Summary.Add(GridColumnSummaryItem)

            Next

        End Sub
        Private Sub RefreshViewModel(ReloadMarkets As Boolean, RefreshData As Boolean)

            'objects
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            ButtonItemActions_Save.Enabled = _ViewModel.SaveEnabled
            ButtonItemActions_Cancel.Enabled = _ViewModel.CancelEnabled
            ButtonItemActions_CopyToAnotherMarket.Enabled = _ViewModel.CopyToAnotherMarketEnabled
            ButtonItemActions_CopyFromAnotherMarket.Enabled = _ViewModel.CopyToAnotherMarketEnabled

            ButtonItemGoals_Add.Enabled = _ViewModel.AddEnabled
            ButtonItemGoals_Delete.Enabled = _ViewModel.DeleteEnabled
            ButtonItemGoals_Copy.Enabled = _ViewModel.CopyEnabled
            ButtonItemGoals_EnterByPercentage.Enabled = _ViewModel.EnterByPercentageEnabled
            ButtonItemGoals_EnterByPercentage.Checked = _ViewModel.EnterByPercentageChecked

            ButtonItemMediaPlan_LoadGoals.SecurityEnabled = _ViewModel.MediaPlan_LoadGoalsEnabled

            NumericInputForm_TotalGRPs.SecurityEnabled = (_ViewModel.HasBeenImportFromMediaPlan = False)
            NumericInputForm_TotalBudget.SecurityEnabled = (_ViewModel.HasBeenImportFromMediaPlan = False)

            LabelForm_VarianceGRPs.Text = String.Format("Variance GRPs: {0}", FormatNumber(_ViewModel.VarianceGRPs, 1, UseParensForNegativeNumbers:=TriState.True))
            LabelForm_VarianceBudget.Text = String.Format("Variance Budget: {0}", FormatCurrency(_ViewModel.VarianceBudget, 2))

            If DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.Percentage.ToString) IsNot Nothing Then

                If _ViewModel.EnterByPercentageChecked Then

                    DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.Percentage.ToString).OptionsColumn.AllowEdit = True

                    ' If NumericInputForm_TotalGRPs.EditValue > 0 AndAlso NumericInputForm_TotalBudget.EditValue > 0 Then

                    DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.GRP.ToString).OptionsColumn.AllowEdit = False
                    DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.Budget.ToString).OptionsColumn.AllowEdit = False
                    DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.CPP.ToString).OptionsColumn.AllowEdit = False

                    For Each GoalDate In _ViewModel.GoalDates.Keys.OfType(Of Date).OrderBy(Function(GD) GD)

                        GridColumn = DataGridViewForm_Goals.Columns(_ViewModel.GoalDates(GoalDate).ToString)

                        GridColumn.OptionsColumn.AllowEdit = False

                    Next

                    'ElseIf NumericInputForm_TotalGRPs.EditValue = 0 AndAlso NumericInputForm_TotalBudget.EditValue > 0 Then

                    '    DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.GRP.ToString).OptionsColumn.AllowEdit = True
                    '    DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.Budget.ToString).OptionsColumn.AllowEdit = False
                    '    DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.CPP.ToString).OptionsColumn.AllowEdit = True

                    'ElseIf NumericInputForm_TotalGRPs.EditValue > 0 AndAlso NumericInputForm_TotalBudget.EditValue = 0 Then

                    '    DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.GRP.ToString).OptionsColumn.AllowEdit = False
                    '    DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.Budget.ToString).OptionsColumn.AllowEdit = True
                    '    DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.CPP.ToString).OptionsColumn.AllowEdit = True

                    'End If

                Else

                    DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.Percentage.ToString).OptionsColumn.AllowEdit = False
                    DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.GRP.ToString).OptionsColumn.AllowEdit = True
                    DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.Budget.ToString).OptionsColumn.AllowEdit = True
                    DataGridViewForm_Goals.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.CPP.ToString).OptionsColumn.AllowEdit = True

                    For Each GoalDate In _ViewModel.GoalDates.Keys.OfType(Of Date).OrderBy(Function(GD) GD)

                        GridColumn = DataGridViewForm_Goals.Columns(_ViewModel.GoalDates(GoalDate).ToString)

                        GridColumn.OptionsColumn.AllowEdit = True

                    Next

                End If

            End If

            If RefreshData Then

                NumericInputForm_TotalGRPs.Value = _ViewModel.TotalGRPs
                NumericInputForm_TotalBudget.Value = _ViewModel.TotalBudget

            End If

            If ReloadMarkets Then

                BindingSource = New System.Windows.Forms.BindingSource

                BindingSource.DataSource = _Controller.MarketGoals_LoadMarketSelection(_ViewModel)

                ComboBoxItemMarkets_Markets.ComboBoxEx.DataSource = BindingSource

            End If

            If _ViewModel.HasASelectedWorksheetMarket Then

                ComboBoxItemMarkets_Markets.ComboBoxEx.SelectedValue = _ViewModel.SelectedWorksheetMarket.ID

            Else

                ComboBoxItemMarkets_Markets.ComboBoxEx.SelectedValue = 0

            End If

        End Sub
        Private Sub SetControlPropertySettings()

            DataGridViewForm_Goals.SetupForEditableGrid()

            DataGridViewForm_Goals.OptionsCustomization.AllowGroup = False
            DataGridViewForm_Goals.OptionsCustomization.AllowQuickHideColumns = False
            DataGridViewForm_Goals.OptionsCustomization.AllowColumnMoving = False

            DataGridViewForm_Goals.OptionsBehavior.AutoSelectAllInEditor = True
            DataGridViewForm_Goals.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp
            DataGridViewForm_Goals.OptionsNavigation.AutoMoveRowFocus = True
            DataGridViewForm_Goals.OptionsNavigation.EnterMoveNextColumn = True
            DataGridViewForm_Goals.OptionsNavigation.UseOfficePageNavigation = True
            DataGridViewForm_Goals.OptionsNavigation.UseTabKey = True

            DataGridViewForm_Goals.OptionsView.ShowGroupPanel = False
            DataGridViewForm_Goals.OptionsView.ShowFooter = True

            DataGridViewForm_Goals.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None

            DataGridViewForm_Goals.OptionsSelection.MultiSelect = True
            DataGridViewForm_Goals.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect

            DataGridViewForm_Goals.ItemDescription = "Goal(s)"

            ComboBoxItemMarkets_Markets.ComboBoxEx.DisplayMember = "MarketDescription"
            ComboBoxItemMarkets_Markets.ComboBoxEx.ValueMember = "ID"

            NumericInputForm_TotalGRPs.Properties.MinValue = 0
            NumericInputForm_TotalBudget.Properties.MinValue = 0

            NumericInputForm_TotalGRPs.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default
            NumericInputForm_TotalBudget.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default

        End Sub
        Private Function HasNoErrors() As Boolean

            'objects
            Dim HasErrors As Boolean = False

            HasErrors = _ViewModel.DataTable.HasErrors

            If HasErrors Then

                AdvantageFramework.WinForm.MessageBox.Show("Please fix data entry errors before continuing.")

            End If

            HasNoErrors = Not HasErrors

        End Function
        Private Sub CloseGridEditorAndSaveValueToDataSource()

            If DataGridViewForm_Goals.CurrentView.PostEditor() Then

                DataGridViewForm_Goals.CurrentView.UpdateCurrentRow()

            End If

        End Sub
        'Private Sub RepositoryItemDaypart_EditValueChanged(sender As Object, e As EventArgs)

        '	'objects
        '	Dim WarnUser As Boolean = False

        '	_Controller.MarketGoals_DaypartValueChanging(_ViewModel,
        '												 DataGridViewForm_Goals.CurrentView.GetDataSourceRowIndex(DataGridViewForm_Goals.CurrentView.FocusedRowHandle),
        '												 CType(sender, DevExpress.XtraEditors.LookUpEdit).EditValue,
        '												 WarnUser)

        '	If WarnUser Then

        '		AdvantageFramework.WinForm.MessageBox.Show("WARNING: Duplicate daypart\length entry is not allowed.")

        '		CType(sender, DevExpress.XtraEditors.LookUpEdit).EditValue = CType(sender, DevExpress.XtraEditors.LookUpEdit).OldEditValue

        '	Else

        '		RefreshViewModel(False)

        '	End If

        'End Sub
        'Private Sub RepositoryItemLength_EditValueChanged(sender As Object, e As EventArgs)

        '	'objects
        '	Dim WarnUser As Boolean = False

        '	_Controller.MarketGoals_LengthValueChanging(_ViewModel,
        '												DataGridViewForm_Goals.CurrentView.GetDataSourceRowIndex(DataGridViewForm_Goals.CurrentView.FocusedRowHandle),
        '												CType(sender, DevExpress.XtraEditors.SpinEdit).EditValue,
        '												WarnUser)

        '	If WarnUser Then

        '		AdvantageFramework.WinForm.MessageBox.Show("WARNING: Duplicate daypart\length entry is not allowed.")

        '		CType(sender, DevExpress.XtraEditors.SpinEdit).EditValue = CType(sender, DevExpress.XtraEditors.SpinEdit).OldEditValue

        '	Else

        '		RefreshViewModel(False)

        '	End If

        'End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(MediaBroadcastWorksheetID As Integer, MediaBroadcastWorksheetMarketID As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaBroadcastWorksheetMarketGoalDialog As MediaBroadcastWorksheetMarketGoalDialog = Nothing

            MediaBroadcastWorksheetMarketGoalDialog = New MediaBroadcastWorksheetMarketGoalDialog(MediaBroadcastWorksheetID, MediaBroadcastWorksheetMarketID)

            ShowFormDialog = MediaBroadcastWorksheetMarketGoalDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaBroadcastWorksheetMarketGoalDialog_BeforeFormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.BeforeFormClosing

            If Me.DialogResult = System.Windows.Forms.DialogResult.Cancel AndAlso _ViewModel.HasGoalsBeenModified Then

                Me.DialogResult = Windows.Forms.DialogResult.OK

            End If

        End Sub
        Private Sub MediaBroadcastWorksheetMarketGoalDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim Bitmap As System.Drawing.Bitmap = Nothing

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemActions_CopyToAnotherMarket.Image = AdvantageFramework.My.Resources.QuickManageImage
            ButtonItemActions_CopyFromAnotherMarket.Image = AdvantageFramework.My.Resources.QuickManageImage

            ButtonItemGoals_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemGoals_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemGoals_Copy.Image = AdvantageFramework.My.Resources.CopyImage

            Bitmap = New System.Drawing.Bitmap(AdvantageFramework.My.Resources.PercentageImage, New System.Drawing.Size(32, 32))

            ButtonItemGoals_EnterByPercentage.Image = Bitmap

            ButtonItemMediaPlan_LoadGoals.Image = AdvantageFramework.My.Resources.DatabaseImportImage

            _Controller = New AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController(Me.Session)

            SetControlPropertySettings()

        End Sub
        Private Sub MediaBroadcastWorksheetMarketGoalDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

            LoadViewModel()

            DataGridViewForm_Goals.CurrentView.BeginUpdate()

            LoadGrid()

            FormatGrid()

            RefreshViewModel(True, True)

            DataGridViewForm_Goals.CurrentView.EndUpdate()

            DataGridViewForm_Goals.CurrentView.BestFitColumns()

            RibbonBarFilePanel_Actions.ResetCachedContentSize()

            RibbonBarFilePanel_Actions.Refresh()

            RibbonBarFilePanel_Actions.Width = RibbonBarFilePanel_Actions.GetAutoSizeWidth

            RibbonBarFilePanel_Actions.Refresh()

            Me.Text = "Market Goals - " & _Controller.MarketGoals_LoadWorksheetFullName(_ViewModel)

            Me.ClearChanged()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            Me.CloseWaitForm()

        End Sub
        Private Sub MediaBroadcastWorksheetMarketGoalDialog_UserEntryChangedEvent(Control As AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            If _ViewModel IsNot Nothing Then

                _Controller.MarketGoals_UserEntryChanged(_ViewModel)

                RefreshViewModel(False, False)

            End If

        End Sub
        Private Sub MediaBroadcastWorksheetMarketGoalDialog_ClearChangedEvent() Handles Me.ClearChangedEvent

            If _ViewModel IsNot Nothing Then

                _Controller.MarketGoals_ClearChanged(_ViewModel)

                RefreshViewModel(False, False)

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            If _ViewModel IsNot Nothing AndAlso _ViewModel.HasGoalsBeenModified Then

                Me.DialogResult = System.Windows.Forms.DialogResult.OK

            Else

                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel

            End If

            Me.Close()

        End Sub
        Private Sub ComboBoxItemMarkets_Markets_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxItemMarkets_Markets.SelectedIndexChanged

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            CloseGridEditorAndSaveValueToDataSource()

            DataGridViewForm_Goals.ValidateAllRows()

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso HasNoErrors() Then

                If _ViewModel.SaveEnabled Then

                    If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes before switching.  Do you want to save your changes now?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                        _Controller.MarketGoals_Save(_ViewModel)

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.RaiseClearChanged()

                    End If

                End If

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                _Controller.MarketGoals_SelectedWorksheetMarketChanged(_ViewModel, ComboBoxItemMarkets_Markets.ComboBoxEx.SelectedValue)

                LoadGrid()

                For Each GoalDate In _ViewModel.GoalDates.Keys.OfType(Of Date).OrderBy(Function(GD) GD)

                    GridColumn = DataGridViewForm_Goals.Columns(_ViewModel.GoalDates(GoalDate).ToString)

                    GridColumn.OptionsColumn.AllowFocus = Not _ViewModel.HiatusDataTable.Rows(0)(GridColumn.FieldName)

                Next

                RefreshViewModel(False, True)

                DataGridViewForm_Goals.CurrentView.BestFitColumns()

                Me.Text = "Market Goals - " & _Controller.MarketGoals_LoadWorksheetFullName(_ViewModel)

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                Me.ClearChanged()

            Else

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Refreshing

                ComboBoxItemMarkets_Markets.ComboBoxEx.SelectedValue = _ViewModel.SelectedWorksheetMarket.ID

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            CloseGridEditorAndSaveValueToDataSource()

            DataGridViewForm_Goals.ValidateAllRows()

            If HasNoErrors() Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                _Controller.MarketGoals_Save(_ViewModel)

                Me.ClearChanged()

                RefreshViewModel(False, False)

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                Me.RaiseClearChanged()

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            CloseGridEditorAndSaveValueToDataSource()

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

            _Controller.MarketGoals_SelectedWorksheetMarketChanged(_ViewModel, ComboBoxItemMarkets_Markets.ComboBoxEx.SelectedValue)

            LoadGrid()

            RefreshViewModel(False, True)

            If _ViewModel.SelectedWorksheetMarket IsNot Nothing Then

                Me.Text = "Broadcast Worksheet Goals - " & _ViewModel.Worksheet.Name & " (" & _ViewModel.SelectedWorksheetMarket.MarketDescription & ")"

            Else

                Me.Text = "Broadcast Worksheet Goals - " & _ViewModel.Worksheet.Name

            End If

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            Me.ClearChanged()

        End Sub
        Private Sub ButtonItemActions_CopyToAnotherMarket_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_CopyToAnotherMarket.Click

            'objects
            Dim Message As String = String.Empty
            Dim ProceedToCopy As Boolean = False
            Dim MediaBroadcastWorksheetMarketGoalsCopyToViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketGoalsCopyToViewModel = Nothing

            CloseGridEditorAndSaveValueToDataSource()

            MediaBroadcastWorksheetMarketGoalsCopyToViewModel = _Controller.MarketGoalsCopyTo_Load(_ViewModel)

            If MediaBroadcastWorksheetMarketGoalsCopyToDialog.ShowFormDialog(MediaBroadcastWorksheetMarketGoalsCopyToViewModel, _ViewModel) = System.Windows.Forms.DialogResult.OK Then

                If _Controller.MarketGoalsCopyTo_CheckAllSelectedMarkets(MediaBroadcastWorksheetMarketGoalsCopyToViewModel, Message) Then

                    ProceedToCopy = True

                Else

                    If AdvantageFramework.WinForm.MessageBox.Show(Message, AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Override?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                        ProceedToCopy = True

                    End If

                End If

                If ProceedToCopy Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Modifying)

                    _Controller.MarketGoalsCopyTo_CopyTo(MediaBroadcastWorksheetMarketGoalsCopyToViewModel, _ViewModel)

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_CopyFromAnotherMarket_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_CopyFromAnotherMarket.Click

            'objects
            Dim Message As String = String.Empty
            Dim ProceedToCopy As Boolean = False
            Dim MediaBroadcastWorksheetMarketGoalsCopyFromViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketGoalsCopyFromViewModel = Nothing

            CloseGridEditorAndSaveValueToDataSource()

            MediaBroadcastWorksheetMarketGoalsCopyFromViewModel = _Controller.MarketGoalsCopyFrom_Load(_ViewModel)

            If _Controller.MarketGoalsCopyFrom_CheckCurrentMarket(_ViewModel, Message) Then

                ProceedToCopy = True

            Else

                If AdvantageFramework.WinForm.MessageBox.Show(Message, AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Override?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    ProceedToCopy = True

                End If

            End If

            If ProceedToCopy Then

                If MediaBroadcastWorksheetMarketGoalsCopyFromDialog.ShowFormDialog(MediaBroadcastWorksheetMarketGoalsCopyFromViewModel, _ViewModel) = System.Windows.Forms.DialogResult.OK Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Modifying)

                    _Controller.MarketGoalsCopyFrom_CopyFrom(MediaBroadcastWorksheetMarketGoalsCopyFromViewModel, _ViewModel)

                    RefreshViewModel(False, False)

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    DataGridViewForm_Goals.SetUserEntryChanged()

                End If

            End If

        End Sub
        Private Sub ButtonItemGoals_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemGoals_Add.Click

            CloseGridEditorAndSaveValueToDataSource()

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding)

            _Controller.MarketGoals_AddNewDataEntryRow(_ViewModel)

            RefreshViewModel(False, False)

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            DataGridViewForm_Goals.SetUserEntryChanged()

        End Sub
        Private Sub ButtonItemGoals_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemGoals_Delete.Click

            'objects
            Dim RowIndexes As Generic.List(Of Integer) = Nothing

            CloseGridEditorAndSaveValueToDataSource()

            If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete this row?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting)

                RowIndexes = New Generic.List(Of Integer)

                For Each RowHandle In DataGridViewForm_Goals.CurrentView.GetSelectedRows

                    RowIndexes.Add(DataGridViewForm_Goals.CurrentView.GetDataSourceRowIndex(RowHandle))

                Next

                DataGridViewForm_Goals.CurrentView.BeginUpdate()

                _Controller.MarketGoals_DeleteDataEntryRow(_ViewModel, RowIndexes.ToArray)

                DataGridViewForm_Goals.CurrentView.EndUpdate()

                RefreshViewModel(False, False)

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                DataGridViewForm_Goals.SetUserEntryChanged()

            End If

        End Sub
        Private Sub ButtonItemGoals_Copy_Click(sender As Object, e As EventArgs) Handles ButtonItemGoals_Copy.Click

            'objects
            Dim RowIndexes As Generic.List(Of Integer) = Nothing

            CloseGridEditorAndSaveValueToDataSource()

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Copying)

            RowIndexes = New Generic.List(Of Integer)

            For Each RowHandle In DataGridViewForm_Goals.CurrentView.GetSelectedRows

                RowIndexes.Add(DataGridViewForm_Goals.CurrentView.GetDataSourceRowIndex(RowHandle))

            Next

            _Controller.MarketGoals_CopyDataEntryRow(_ViewModel, RowIndexes.ToArray)

            RefreshViewModel(False, False)

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            DataGridViewForm_Goals.SetUserEntryChanged()

            DataGridViewForm_Goals.ValidateAllRows()

        End Sub
        Private Sub ButtonItemMediaPlan_LoadGoals_Click(sender As Object, e As EventArgs) Handles ButtonItemMediaPlan_LoadGoals.Click

            'objects
            Dim UserMessage As String = String.Empty
            Dim [Continue] As Boolean = False
            Dim MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate = Nothing
            Dim MediaPlanEstimates As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate) = Nothing
            Dim MediaBroadcastWorksheetMarketGoalsSelectMediaPlanEstimateViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketGoalsSelectMediaPlanEstimateViewModel = Nothing

            CloseGridEditorAndSaveValueToDataSource()

            If _ViewModel.DataTable.Rows.Count > 0 Then

                If AdvantageFramework.WinForm.MessageBox.Show("WARNING: Updated Goals from the media plan will write over all current goals in this grid." & System.Environment.NewLine & System.Environment.NewLine & "Are you sure you want to continue?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    [Continue] = True

                End If

            Else

                [Continue] = True

            End If

            If [Continue] Then

                MediaPlanEstimates = _Controller.MarketGoals_LoadMediaPlanEstimates(_ViewModel)

                If MediaPlanEstimates IsNot Nothing AndAlso MediaPlanEstimates.Count > 0 Then

                    If MediaPlanEstimates.Count = 1 Then

                        MediaPlanEstimate = MediaPlanEstimates(0)

                    Else

                        MediaBroadcastWorksheetMarketGoalsSelectMediaPlanEstimateViewModel = _Controller.MarketGoalsSelectMediaPlanEstimate_Load(_ViewModel, MediaPlanEstimates)

                        If AdvantageFramework.Media.Presentation.MediaBroadcastWorksheetMarketGoalsSelectMediaPlanEstimateDialog.ShowFormDialog(MediaBroadcastWorksheetMarketGoalsSelectMediaPlanEstimateViewModel, _ViewModel) = Windows.Forms.DialogResult.OK Then

                            MediaPlanEstimate = _Controller.MarketGoalsSelectMediaPlanEstimate_Select(MediaBroadcastWorksheetMarketGoalsSelectMediaPlanEstimateViewModel, MediaPlanEstimates)

                        End If

                    End If

                    If MediaPlanEstimate IsNot Nothing Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Modifying)

                        DataGridViewForm_Goals.CurrentView.BeginUpdate()

                        _Controller.MarketGoals_ImportMediaPlanData(_ViewModel, MediaPlanEstimate, UserMessage)

                        DataGridViewForm_Goals.CurrentView.EndUpdate()

                        RefreshViewModel(False, True)

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    End If

                Else

                    UserMessage = "Media plan does not contain data to import."

                End If

                If String.IsNullOrWhiteSpace(UserMessage) = False Then

                    AdvantageFramework.WinForm.MessageBox.Show(UserMessage)

                Else

                    DataGridViewForm_Goals.SetUserEntryChanged()

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Goals_CustomRowCellEditForEditingEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles DataGridViewForm_Goals.CustomRowCellEditForEditingEvent

            'objects
            'Dim RepositoryItemLookUpEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit = Nothing
            'Dim RepositoryItemTimeEdit As DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit = Nothing

            'If e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.Daypart.ToString Then

            '	RepositoryItemLookUpEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit

            '	RepositoryItemLookUpEdit.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code"))
            '	RepositoryItemLookUpEdit.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Description"))
            '	RepositoryItemLookUpEdit.DisplayMember = "Code"
            '	RepositoryItemLookUpEdit.ValueMember = "Code"

            '	RepositoryItemLookUpEdit.DataSource = _ViewModel.Dayparts

            '	e.RepositoryItem = RepositoryItemLookUpEdit

            'End If

        End Sub
        Private Sub DataGridViewForm_Goals_CustomRowCellEditEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles DataGridViewForm_Goals.CustomRowCellEditEvent

            'objects
            Dim RepositoryItemSpinEdit As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit = Nothing
            Dim RepositoryItemLookUpEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit = Nothing

            If _ViewModel.GoalDates.ContainsValue(e.Column.FieldName) Then

                RepositoryItemSpinEdit = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit

                RepositoryItemSpinEdit.AllowMouseWheel = False
                RepositoryItemSpinEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
                RepositoryItemSpinEdit.EditMask = "f1"
                RepositoryItemSpinEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                RepositoryItemSpinEdit.DisplayFormat.FormatString = "f1"
                RepositoryItemSpinEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                RepositoryItemSpinEdit.EditFormat.FormatString = "f1"
                RepositoryItemSpinEdit.Mask.UseMaskAsDisplayFormat = True
                RepositoryItemSpinEdit.Mask.EditMask = "f1"
                RepositoryItemSpinEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
                RepositoryItemSpinEdit.IsFloatValue = True
                RepositoryItemSpinEdit.MinValue = 0
                RepositoryItemSpinEdit.MaxValue = 9999999.9
                RepositoryItemSpinEdit.MaxLength = 9
                RepositoryItemSpinEdit.Buttons.Clear()

                e.RepositoryItem = RepositoryItemSpinEdit

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.Length.ToString Then

                RepositoryItemSpinEdit = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit

                RepositoryItemSpinEdit.AllowMouseWheel = False
                RepositoryItemSpinEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
                RepositoryItemSpinEdit.EditMask = "f0"
                RepositoryItemSpinEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                RepositoryItemSpinEdit.DisplayFormat.FormatString = "f0"
                RepositoryItemSpinEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                RepositoryItemSpinEdit.EditFormat.FormatString = "f0"
                RepositoryItemSpinEdit.Mask.UseMaskAsDisplayFormat = True
                RepositoryItemSpinEdit.Mask.EditMask = "f0"
                RepositoryItemSpinEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
                RepositoryItemSpinEdit.IsFloatValue = False
                RepositoryItemSpinEdit.MinValue = 0
                RepositoryItemSpinEdit.MaxValue = 999
                RepositoryItemSpinEdit.MaxLength = 3
                RepositoryItemSpinEdit.Buttons.Clear()

                'AddHandler RepositoryItemSpinEdit.EditValueChanged, AddressOf RepositoryItemLength_EditValueChanged

                e.RepositoryItem = RepositoryItemSpinEdit

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.CPP.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.Budget.ToString Then

                RepositoryItemSpinEdit = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit

                RepositoryItemSpinEdit.AllowMouseWheel = False
                RepositoryItemSpinEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
                RepositoryItemSpinEdit.EditMask = "c2"
                RepositoryItemSpinEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                RepositoryItemSpinEdit.DisplayFormat.FormatString = "c2"
                RepositoryItemSpinEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                RepositoryItemSpinEdit.EditFormat.FormatString = "c2"
                RepositoryItemSpinEdit.Mask.UseMaskAsDisplayFormat = True
                RepositoryItemSpinEdit.Mask.EditMask = "c2"
                RepositoryItemSpinEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
                RepositoryItemSpinEdit.IsFloatValue = True
                RepositoryItemSpinEdit.MinValue = 0
                RepositoryItemSpinEdit.MaxValue = 999999.99
                RepositoryItemSpinEdit.MaxLength = 9
                RepositoryItemSpinEdit.Buttons.Clear()

                e.RepositoryItem = RepositoryItemSpinEdit

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.GRP.ToString Then

                RepositoryItemSpinEdit = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit

                RepositoryItemSpinEdit.AllowMouseWheel = False
                RepositoryItemSpinEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
                RepositoryItemSpinEdit.EditMask = "f1"
                RepositoryItemSpinEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                RepositoryItemSpinEdit.DisplayFormat.FormatString = "f1"
                RepositoryItemSpinEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                RepositoryItemSpinEdit.EditFormat.FormatString = "f1"
                RepositoryItemSpinEdit.Mask.UseMaskAsDisplayFormat = True
                RepositoryItemSpinEdit.Mask.EditMask = "f1"
                RepositoryItemSpinEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
                RepositoryItemSpinEdit.IsFloatValue = True
                RepositoryItemSpinEdit.MinValue = 0
                RepositoryItemSpinEdit.MaxValue = 9999999.9
                RepositoryItemSpinEdit.MaxLength = 9
                RepositoryItemSpinEdit.Buttons.Clear()

                e.RepositoryItem = RepositoryItemSpinEdit

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.Percentage.ToString Then

                RepositoryItemSpinEdit = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit

                RepositoryItemSpinEdit.AllowMouseWheel = False
                RepositoryItemSpinEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
                RepositoryItemSpinEdit.EditMask = "p0"
                RepositoryItemSpinEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                RepositoryItemSpinEdit.DisplayFormat.FormatString = "p0"
                RepositoryItemSpinEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                RepositoryItemSpinEdit.EditFormat.FormatString = "p0"
                RepositoryItemSpinEdit.Mask.UseMaskAsDisplayFormat = True
                RepositoryItemSpinEdit.Mask.EditMask = "p0"
                RepositoryItemSpinEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
                RepositoryItemSpinEdit.IsFloatValue = True
                RepositoryItemSpinEdit.MinValue = 0
                RepositoryItemSpinEdit.MaxValue = 100.0
                RepositoryItemSpinEdit.MaxLength = 5
                RepositoryItemSpinEdit.Buttons.Clear()

                e.RepositoryItem = RepositoryItemSpinEdit

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Daypart.ToString Then

                RepositoryItemLookUpEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit

                RepositoryItemLookUpEdit.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code"))
                RepositoryItemLookUpEdit.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Description"))
                RepositoryItemLookUpEdit.DisplayMember = "Code"
                RepositoryItemLookUpEdit.ValueMember = "Code"

                RepositoryItemLookUpEdit.DataSource = _ViewModel.Dayparts

                'AddHandler RepositoryItemLookUpEdit.EditValueChanged, AddressOf RepositoryItemDaypart_EditValueChanged

                e.RepositoryItem = RepositoryItemLookUpEdit

            End If

        End Sub
        Private Sub DataGridViewForm_Goals_MouseDownEvent(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles DataGridViewForm_Goals.MouseDownEvent

            'objects
            Dim GridHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = Nothing
            Dim ContinueSettingHiatus As Boolean = False
            Dim RecalculateGRP As Boolean = False

            If e.Clicks = 2 Then

                GridHitInfo = DataGridViewForm_Goals.CurrentView.CalcHitInfo(e.Location)

                If GridHitInfo IsNot Nothing AndAlso GridHitInfo.InColumnPanel AndAlso
                        GridHitInfo.Column IsNot Nothing AndAlso _ViewModel.GoalDates.ContainsValue(GridHitInfo.Column.FieldName) Then

                    If _ViewModel.HiatusDataTable.Rows(0)(GridHitInfo.Column.FieldName) = False Then

                        If _ViewModel.DataTable.Rows.OfType(Of System.Data.DataRow).Any(Function(DR) DR(GridHitInfo.Column.FieldName) <> 0) Then

                            RecalculateGRP = True

                            If AdvantageFramework.WinForm.MessageBox.Show("WARNING: Setting Hiatus will clear all data in this range in Goals and the Schedule." & vbNewLine & vbNewLine & "Do you want to continue?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                                ContinueSettingHiatus = True

                            End If

                        Else

                            ContinueSettingHiatus = True

                        End If

                    Else

                        ContinueSettingHiatus = True

                    End If

                    If ContinueSettingHiatus Then

                        _Controller.MarketGoals_HiatusValueChanged(_ViewModel, GridHitInfo.Column.FieldName, RecalculateGRP)

                        If _ViewModel.HiatusDataTable.Rows(0)(GridHitInfo.Column.FieldName) = True Then

                            DataGridViewForm_Goals.Columns(GridHitInfo.Column.FieldName).OptionsColumn.AllowFocus = False

                        Else

                            DataGridViewForm_Goals.Columns(GridHitInfo.Column.FieldName).OptionsColumn.AllowFocus = True

                        End If

                        DataGridViewForm_Goals.SetUserEntryChanged()

                        RefreshViewModel(False, False)

                        DataGridViewForm_Goals.CurrentView.RefreshData()

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Goals_CellValueChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_Goals.CellValueChangedEvent

            DataGridViewForm_Goals.CurrentView.BeginUpdate()

            If _ViewModel.GoalDates.ContainsValue(e.Column.FieldName) Then

                _Controller.MarketGoals_GoalDateValueChanged(_ViewModel, DataGridViewForm_Goals.CurrentView.GetDataSourceRowIndex(e.RowHandle))
                DataGridViewForm_Goals.CurrentView.UpdateTotalSummary()

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.Daypart.ToString Then

                _Controller.MarketGoals_DaypartValueChanged(_ViewModel)
                _Controller.MarketGoals_ValidateAllDataRows(_ViewModel)

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.GRP.ToString Then

                _Controller.MarketGoals_GRPValueChanged(_ViewModel, DataGridViewForm_Goals.CurrentView.GetDataSourceRowIndex(e.RowHandle))
                DataGridViewForm_Goals.CurrentView.UpdateTotalSummary()

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.Length.ToString Then

                _Controller.MarketGoals_LengthValueChanged(_ViewModel)
                _Controller.MarketGoals_ValidateAllDataRows(_ViewModel)

                DataGridViewForm_Goals.CurrentView.UpdateTotalSummary()

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.CPP.ToString Then

                _Controller.MarketGoals_CPPValueChanged(_ViewModel, DataGridViewForm_Goals.CurrentView.GetDataSourceRowIndex(e.RowHandle))
                DataGridViewForm_Goals.CurrentView.UpdateTotalSummary()

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.Budget.ToString Then

                _Controller.MarketGoals_BudgetValueChanged(_ViewModel, DataGridViewForm_Goals.CurrentView.GetDataSourceRowIndex(e.RowHandle))
                DataGridViewForm_Goals.CurrentView.UpdateTotalSummary()

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.Percentage.ToString Then

                _Controller.MarketGoals_PercentageValueChanged(_ViewModel, DataGridViewForm_Goals.CurrentView.GetDataSourceRowIndex(e.RowHandle))
                DataGridViewForm_Goals.CurrentView.UpdateTotalSummary()

            End If

            DataGridViewForm_Goals.CurrentView.EndUpdate()

            RefreshViewModel(False, False)

        End Sub
        Private Sub DataGridViewForm_Goals_CustomDrawCellEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles DataGridViewForm_Goals.CustomDrawCellEvent

            If _ViewModel.GoalDates.ContainsValue(e.Column.FieldName) Then

                If _ViewModel.HiatusDataTable.Rows(0)(e.Column.FieldName) = True Then

                    e.Appearance.BackColor = System.Drawing.Color.WhiteSmoke

                    e.Appearance.DrawBackground(e.Cache, e.Bounds)

                    e.Handled = True

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Goals_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewForm_Goals.ShowingEditorEvent

            If _ViewModel.GoalDates.ContainsValue(DataGridViewForm_Goals.CurrentView.FocusedColumn.FieldName) Then

                If _ViewModel.HiatusDataTable.Rows(0)(DataGridViewForm_Goals.CurrentView.FocusedColumn.FieldName) = True Then

                    e.Cancel = True

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Goals_PopupMenuShowingEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles DataGridViewForm_Goals.PopupMenuShowingEvent

            If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Column Then

                For Each MenuItem As DevExpress.Utils.Menu.DXMenuItem In e.Menu.Items

                    Select Case MenuItem.Tag

                        Case DevExpress.XtraGrid.Localization.GridStringId.MenuColumnAutoFilterRowHide,
                         DevExpress.XtraGrid.Localization.GridStringId.MenuColumnAutoFilterRowShow,
                         DevExpress.XtraGrid.Localization.GridStringId.MenuColumnAverageSummaryTypeDescription,
                         DevExpress.XtraGrid.Localization.GridStringId.MenuColumnGroup,
                         DevExpress.XtraGrid.Localization.GridStringId.MenuColumnGroupBox,
                         DevExpress.XtraGrid.Localization.GridStringId.MenuColumnUnGroup,
                         DevExpress.XtraGrid.Localization.GridStringId.MenuColumnSortGroupBySummaryMenu,
                         DevExpress.XtraGrid.Localization.GridStringId.MenuColumnFindFilterHide,
                         DevExpress.XtraGrid.Localization.GridStringId.MenuColumnFindFilterShow,
                         DevExpress.XtraGrid.Localization.GridStringId.MenuColumnRemoveColumn

                            MenuItem.Visible = False

                    End Select

                Next

            ElseIf e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Summary Then

                For Each MenuItem As DevExpress.Utils.Menu.DXMenuItem In e.Menu.Items

                    MenuItem.Visible = False

                Next

            End If

        End Sub
        Private Sub DataGridViewForm_Goals_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_Goals.SelectionChangedEvent

            'objects
            Dim RowIndexes As Generic.List(Of Integer) = Nothing

            RowIndexes = New Generic.List(Of Integer)

            For Each RowHandle In DataGridViewForm_Goals.CurrentView.GetSelectedRows

                RowIndexes.Add(DataGridViewForm_Goals.CurrentView.GetDataSourceRowIndex(RowHandle))

            Next

            _Controller.MarketGoals_SelectedChanged(_ViewModel, DataGridViewForm_Goals.HasASelectedRow, RowIndexes)

            RefreshViewModel(False, False)

        End Sub
        Private Sub DataGridViewForm_Goals_CustomSummaryCalculateEvent(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles DataGridViewForm_Goals.CustomSummaryCalculateEvent

            'objects
            Dim GridColumnSummaryItem As DevExpress.XtraGrid.GridColumnSummaryItem = Nothing

            If e.IsTotalSummary Then

                GridColumnSummaryItem = e.Item

                If GridColumnSummaryItem.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.CPP.ToString Then

                    e.TotalValue = _Controller.MarketGoals_CalculateCPPTotal(_ViewModel, DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(DataGridViewForm_Goals.CurrentView.ActiveFilterCriteria))

                Else

                    If GridColumnSummaryItem.Tag = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.CPP.ToString Then

                        e.TotalValue = _Controller.MarketGoals_CalculateWeeklyCPP(_ViewModel, GridColumnSummaryItem.FieldName, DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(DataGridViewForm_Goals.CurrentView.ActiveFilterCriteria))

                    ElseIf GridColumnSummaryItem.Tag = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.Budget.ToString Then

                        e.TotalValue = _Controller.MarketGoals_CalculateBudgetByDate(_ViewModel, GridColumnSummaryItem.FieldName, DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(DataGridViewForm_Goals.CurrentView.ActiveFilterCriteria))

                    End If

                End If

                e.TotalValueReady = True

            End If

        End Sub
        Private Sub DataGridViewForm_Goals_CustomDrawColumnHeaderEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs) Handles DataGridViewForm_Goals.CustomDrawColumnHeaderEvent

            If e.Column IsNot Nothing AndAlso _ViewModel IsNot Nothing AndAlso _ViewModel.GoalDates.ContainsValue(e.Column.FieldName) Then

                If _ViewModel.HiatusDataTable.Rows(0)(e.Column.FieldName) = True Then

                    e.Appearance.ForeColor = System.Drawing.Color.Red

                    e.DefaultDraw()

                    e.Handled = True

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Goals_FocusedColumnChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles DataGridViewForm_Goals.FocusedColumnChangedEvent

            If _ViewModel IsNot Nothing AndAlso DataGridViewForm_Goals.CurrentView.RowCount > 0 AndAlso DataGridViewForm_Goals.CurrentView.SelectedRowsCount > 0 Then

                If _ViewModel.HiatusDataTable.Columns.Contains(e.FocusedColumn.FieldName) Then

                    If _ViewModel.HiatusDataTable.Rows(0)(e.FocusedColumn.FieldName) = True Then

                        If e.FocusedColumn.VisibleIndex = DataGridViewForm_Goals.CurrentView.VisibleColumns.Count - 1 Then

                            If DataGridViewForm_Goals.CurrentView.FocusedRowHandle <> DataGridViewForm_Goals.CurrentView.RowCount - 1 Then

                                DataGridViewForm_Goals.CurrentView.MoveNext()

                            Else

                                DataGridViewForm_Goals.CurrentView.MoveFirst()

                            End If

                        Else

                            DataGridViewForm_Goals.CurrentView.FocusedColumn = DataGridViewForm_Goals.CurrentView.VisibleColumns(e.FocusedColumn.VisibleIndex + 1)

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Goals_ColumnFilterChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_Goals.ColumnFilterChangedEvent

            DataGridViewForm_Goals.CurrentView.UpdateTotalSummary()

        End Sub
        Private Sub DataGridViewForm_Goals_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewForm_Goals.ValidateRowEvent

            _Controller.MarketGoals_ValidateAllDataRows(_ViewModel)

            e.Valid = True

        End Sub
        Private Sub DataGridViewForm_Goals_ProcessGridKeyEvent(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles DataGridViewForm_Goals.ProcessGridKeyEvent

            If DataGridViewForm_Goals.HasASelectedRow Then

                If e.KeyCode = System.Windows.Forms.Keys.Insert Then

                    If e.Control Then

                        ButtonItemGoals_Copy.RaiseClick()

                    Else

                        ButtonItemGoals_Add.RaiseClick()

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Goals_CustomDrawFooterCellEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs) Handles DataGridViewForm_Goals.CustomDrawFooterCellEvent

            If e.Column IsNot Nothing Then

                If e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.Percentage.ToString Then

                    If e.Info.SummaryItem.Tag = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.CPP.ToString Then

                        e.Appearance.BackColor = System.Drawing.Color.FromArgb(255, 240, 240, 240)

                        e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                        e.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center

                        e.Appearance.FillRectangle(e.Cache, e.Bounds)

                        e.Appearance.DrawString(e.Cache, "CPP", e.Bounds)

                        e.Handled = True

                    ElseIf e.Info.SummaryItem.Tag = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketGoalsColumns.Budget.ToString Then

                        e.Appearance.BackColor = System.Drawing.Color.FromArgb(255, 240, 240, 240)

                        e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                        e.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center

                        e.Appearance.FillRectangle(e.Cache, e.Bounds)

                        e.Appearance.DrawString(e.Cache, "Budget", e.Bounds)

                        e.Handled = True

                    End If

                End If

            End If

        End Sub
        Private Sub NumericInputForm_TotalGRPs_ValueChanged(sender As Object, e As EventArgs) Handles NumericInputForm_TotalGRPs.ValueChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                _Controller.MarketGoals_TotalGRPsChanged(_ViewModel, NumericInputForm_TotalGRPs.EditValue)
                RefreshViewModel(False, False)

            End If

        End Sub
        Private Sub NumericInputForm_TotalBudget_ValueChanged(sender As Object, e As EventArgs) Handles NumericInputForm_TotalBudget.ValueChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                _Controller.MarketGoals_TotalBudgetChanged(_ViewModel, NumericInputForm_TotalBudget.EditValue)
                RefreshViewModel(False, False)

            End If

        End Sub
        Private Sub ButtonItemGoals_EnterByPercentage_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemGoals_EnterByPercentage.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                _Controller.MarketGoals_EnterByPercentageChanged(_ViewModel, ButtonItemGoals_EnterByPercentage.Checked)
                RefreshViewModel(False, False)

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
