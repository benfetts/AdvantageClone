Namespace Media.Presentation

    Public Class MediaPlanActualizeDialog

#Region " Constants "



#End Region

#Region " Enum "

        Private Enum Actualize
            NoRollFoward
            RollFowardAll
            RollFowardNext
            RollFowardPercent
        End Enum

#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.DigitalCampaignManager.ViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.DigitalCampaignManagerController = Nothing
        Protected _MediaPlanDetailID As Integer = 0

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(MediaPlanDetailID As Integer)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _MediaPlanDetailID = MediaPlanDetailID

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True

            If Me.UserEntryChanged Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = Save()

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function
        Private Sub EnableOrDisableActions()

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged
            ButtonItemActions_Cancel.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub LoadViewModel()

            _ViewModel = _Controller.EstimateDetail_Load(_MediaPlanDetailID)

            Me.Text = _ViewModel.MediaPlanActualizeDialogText

        End Sub
        Private Sub RefreshGrid()

            Dim LayoutLoaded As Boolean = False
            Dim SubItemImageCheckEditControl As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemImageCheckEditControl = Nothing

            Me.DataGridViewForm_EstimateDetail.CurrentView.ViewCaption = "Period Detail"

            LayoutLoaded = AdvantageFramework.WinForm.Presentation.Controls.LoadDataGridViewLayout(DataGridViewForm_EstimateDetail, _ViewModel.EstimateDetailByPeriodGridLayout, RemoveOldColumns:=True)

            DataGridViewForm_EstimateDetail.DataSource = _ViewModel.DigitalEstimateDetails.OrderBy(Function(G) G.RowIndex).ToList

            If DataGridViewForm_EstimateDetail.CurrentView.Columns(AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.MonthString.ToString) IsNot Nothing Then

                DataGridViewForm_EstimateDetail.CurrentView.Columns(AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.MonthString.ToString).SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom

            End If

            If LayoutLoaded Then

                SetColumnVisibility()

            Else

                SetColumnDefaultVisibility()

                DataGridViewForm_EstimateDetail.CurrentView.BestFitColumns()

            End If

            If DataGridViewForm_EstimateDetail.CurrentView.Columns(AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.HasInvoice.ToString) IsNot Nothing Then

                SubItemImageCheckEditControl = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemImageCheckEditControl

                SubItemImageCheckEditControl.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemImageCheckEditControl.Type.YesNoSkip
                SubItemImageCheckEditControl.ReadOnly = True

                If SubItemImageCheckEditControl IsNot Nothing Then

                    SubItemImageCheckEditControl.DisplayValueChecked = "Yes"
                    SubItemImageCheckEditControl.DisplayValueUnchecked = "No"
                    SubItemImageCheckEditControl.DisplayValueGrayed = "NA"

                    SubItemImageCheckEditControl.ValueChecked = CInt(1)
                    SubItemImageCheckEditControl.ValueUnchecked = CInt(0)
                    SubItemImageCheckEditControl.ValueGrayed = -1

                    SubItemImageCheckEditControl.PictureChecked = AdvantageFramework.My.Resources.RoundedGreenButtonImage
                    SubItemImageCheckEditControl.PictureUnchecked = AdvantageFramework.My.Resources.RoundedRedButtonImage
                    SubItemImageCheckEditControl.PictureGrayed = AdvantageFramework.My.Resources.RoundedYellowButtonImage

                    DataGridViewForm_EstimateDetail.GridControl.RepositoryItems.Add(SubItemImageCheckEditControl)

                    DataGridViewForm_EstimateDetail.CurrentView.Columns(AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.HasInvoice.ToString).ColumnEdit = SubItemImageCheckEditControl

                End If

            End If

        End Sub
        Private Function Save() As Boolean

            Dim DigitalEstimateDetails As Generic.List(Of AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail) = Nothing
            Dim ErrorMessage As String = String.Empty
            Dim Saved As Boolean = False
            Dim IssueWarning As Boolean = False
            Dim AllowSave As Boolean = True

            DataGridViewForm_EstimateDetail.CloseGridEditorAndSaveValueToDataSource()

            DigitalEstimateDetails = DataGridViewForm_EstimateDetail.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail).Where(Function(DED) DED.IsDirty = True).ToList

            If _Controller.EstimateDetail_AllowSave(DigitalEstimateDetails, _ViewModel.AllowActualizationToVaryFromLastPlan, IssueWarning) = False Then

                AllowSave = False
                AdvantageFramework.WinForm.MessageBox.Show("At least one or more rows exceeds or is under the last saved plan spend budget.", Title:="Cannot Save")

            ElseIf IssueWarning Then

                If AdvantageFramework.WinForm.MessageBox.Show("At least one or more rows exceeds or is under the last saved plan spend budget." & vbCrLf & "Are you sure you want to continue?", WinForm.MessageBox.MessageBoxButtons.YesNo, "Confirm Save") = WinForm.MessageBox.DialogResults.No Then

                    AllowSave = False

                End If

            End If

            If AllowSave Then

                If _Controller.EstimateDetail_Save(DigitalEstimateDetails, _MediaPlanDetailID, _ViewModel, ErrorMessage) Then

                    SaveGridLayout()

                    RefreshGrid()

                    Me.ClearChanged()

                    EnableOrDisableActions()

                    Saved = True

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Saving failed: " & ErrorMessage, Title:="Error")

                End If

            End If

            Save = Saved

        End Function
        Private Sub SaveGridLayout()

            Dim AFActiveFilterString As String = String.Empty

            AFActiveFilterString = DataGridViewForm_EstimateDetail.CurrentView.AFActiveFilterString

            AdvantageFramework.WinForm.Presentation.Controls.SaveDataGridViewLayout(Me.Session, DataGridViewForm_EstimateDetail, AdvantageFramework.Database.Entities.GridAdvantageType.DigitalCampaignManagerEstimateDetailByPeriod)

            _Controller.Reset_PeriodGridLayout(_ViewModel)

            DataGridViewForm_EstimateDetail.CurrentView.AFActiveFilterString = AFActiveFilterString

        End Sub
        Private Sub SetColumnDefaultVisibility()

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            For Each GridColumn In DataGridViewForm_EstimateDetail.CurrentView.Columns

                If GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.EstimateLine.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.VendorName.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.StartDate.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.EndDate.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.PlanSpend.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.ActualSpend.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.RemainingSpend.ToString Then

                    GridColumn.OptionsColumn.AllowShowHide = False

                End If

                If GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.WeeksRemaining.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.WeeksElapsed.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.MonthsRemaining.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.MonthsElapsed.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.CampaignName.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.HasInvoice.ToString Then

                    GridColumn.Visible = False

                ElseIf GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.PlanRate.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.ActualRate.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.OrderNumber.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.OrderLineNumber.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.MonthString.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.Year.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.CostType.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.IsCPM.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.OrigPlanSpend.ToString Then

                    If GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.MonthString.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.Year.ToString Then

                        GridColumn.Visible = False

                        GridColumn.OptionsColumn.AllowShowHide = True
                        GridColumn.OptionsColumn.ShowInCustomizationForm = True

                    ElseIf GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.OrderNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.OrderLineNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.OrigPlanSpend.ToString Then

                        GridColumn.Visible = False

                        GridColumn.OptionsColumn.AllowShowHide = True
                        GridColumn.OptionsColumn.ShowInCustomizationForm = True

                    Else

                        GridColumn.Visible = True

                        GridColumn.OptionsColumn.AllowShowHide = True
                        GridColumn.OptionsColumn.ShowInCustomizationForm = True

                    End If

                ElseIf GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.Month.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.YearMonth.ToString Then

                    GridColumn.Visible = False

                    GridColumn.OptionsColumn.AllowShowHide = False
                    GridColumn.OptionsColumn.ShowInCustomizationForm = False

                End If

            Next

        End Sub
        Private Sub SetColumnVisibility()

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            For Each GridColumn In DataGridViewForm_EstimateDetail.CurrentView.Columns

                If GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.PlanRate.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.ActualRate.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.OrderNumber.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.OrderLineNumber.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.MonthString.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.Year.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.CostType.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.IsCPM.ToString Then

                    GridColumn.OptionsColumn.AllowShowHide = True
                    GridColumn.OptionsColumn.ShowInCustomizationForm = True

                ElseIf GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.Month.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.YearMonth.ToString Then

                    GridColumn.Visible = False

                    GridColumn.OptionsColumn.AllowShowHide = False
                    GridColumn.OptionsColumn.ShowInCustomizationForm = False

                End If

            Next

        End Sub
        Private Sub ActualizeData(Actualize As Actualize)

            Dim SelectedDigitalEstimateDetails As Generic.List(Of AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail) = Nothing
            Dim [Continue] As Boolean = True

            SelectedDigitalEstimateDetails = DataGridViewForm_EstimateDetail.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail).ToList

            If SelectedDigitalEstimateDetails.Any(Function(DED) DED.ActualSpend <= 0) AndAlso AdvantageFramework.WinForm.MessageBox.Show("One or more rows selected to actualize has zero actuals, are you sure you want to continue?", WinForm.MessageBox.MessageBoxButtons.YesNo, "Confirm") = WinForm.MessageBox.DialogResults.No Then

                [Continue] = False

            End If

            If [Continue] Then

                Select Case Actualize

                    Case Actualize.NoRollFoward

                        _Controller.EstimateDetail_Actualize(SelectedDigitalEstimateDetails)

                    Case Actualize.RollFowardAll

                        _Controller.EstimateDetail_ActualizeRollForwardAll(_ViewModel.DigitalEstimateDetails, SelectedDigitalEstimateDetails)

                    Case Actualize.RollFowardNext

                        _Controller.EstimateDetail_ActualizeRollForwardNext(_ViewModel.DigitalEstimateDetails, SelectedDigitalEstimateDetails)

                    Case Actualize.RollFowardPercent

                        _Controller.EstimateDetail_ActualizeRollForwardPercent(_ViewModel.DigitalEstimateDetails, SelectedDigitalEstimateDetails)

                End Select

                DataGridViewForm_EstimateDetail.CurrentView.RefreshData()

                DataGridViewForm_EstimateDetail.SetUserEntryChanged()

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(MediaPlanDetailID As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaPlanActualizeDialog As AdvantageFramework.Media.Presentation.MediaPlanActualizeDialog = Nothing

            MediaPlanActualizeDialog = New AdvantageFramework.Media.Presentation.MediaPlanActualizeDialog(MediaPlanDetailID)

            ShowFormDialog = MediaPlanActualizeDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaPlanActualizeDialog_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

            AdvantageFramework.MediaPlanning.ClearEstimateLock(Me.Session, _MediaPlanDetailID)

        End Sub
        Private Sub MediaPlanActualizeDialog_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

            If e.CloseReason = Windows.Forms.CloseReason.UserClosing Then

                SaveGridLayout()

            End If

        End Sub
        Private Sub MediaPlanActualizeDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Me.ShowUnsavedChangesOnFormClosing = False

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemActions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage
            ButtonItemActions_Actualize.Image = AdvantageFramework.My.Resources.UpdateImage

            ButtonItemGrid_ChooseColumns.Image = AdvantageFramework.My.Resources.ColumnImage
            ButtonItemGrid_RestoreDefaults.Image = AdvantageFramework.My.Resources.RestoreDefaultsImage

            DataGridViewForm_EstimateDetail.DataSource = New Generic.List(Of AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail)

            _Controller = New AdvantageFramework.Controller.Media.DigitalCampaignManagerController(Me.Session)

        End Sub
        Private Sub MediaPlanActualizeDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            Me.ShowWaitForm("Loading...")

            Me.DataGridViewForm_EstimateDetail.AutoUpdateViewCaption = False

            LoadViewModel()

            RefreshGrid()

            DataGridViewForm_EstimateDetail.CurrentView.SelectAll()

            Me.ClearChanged()

            EnableOrDisableActions()

            Me.FormAction = WinForm.Presentation.FormActions.None

            Me.CloseWaitForm()

        End Sub
        Private Sub MediaPlanActualizeDialog_UserEntryChangedEvent(Control As AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            Me.Close()

        End Sub
        Private Sub ButtonItemActions_ActualizeNoRollFoward_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_ActualizeNoRollFoward.Click

            ActualizeData(Actualize.NoRollFoward)

        End Sub
        Private Sub ButtonItemActions_ActualizeRollFowardAll_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_ActualizeRollFowardAll.Click

            ActualizeData(Actualize.RollFowardAll)

        End Sub
        Private Sub ButtonItemActions_ActualizeRollFowardNext_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_ActualizeRollFowardNext.Click

            ActualizeData(Actualize.RollFowardNext)

        End Sub
        Private Sub ButtonItemActions_ActualizeRollForwardPercent_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_ActualizeRollForwardPercent.Click

            ActualizeData(Actualize.RollFowardPercent)

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            LoadViewModel()

            SaveGridLayout()

            RefreshGrid()

            Me.ClearChanged()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            Save()

        End Sub
        Private Sub ButtonItemGrid_ChooseColumns_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemGrid_ChooseColumns.CheckedChanged

            Try

                If ButtonItemGrid_ChooseColumns.Checked Then

                    If DataGridViewForm_EstimateDetail.CurrentView.CustomizationForm Is Nothing Then

                        DataGridViewForm_EstimateDetail.CurrentView.ShowCustomization()

                    End If

                Else

                    If DataGridViewForm_EstimateDetail.CurrentView.CustomizationForm IsNot Nothing Then

                        DataGridViewForm_EstimateDetail.CurrentView.DestroyCustomization()

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ButtonItemGrid_RestoreDefaults_Click(sender As Object, e As EventArgs) Handles ButtonItemGrid_RestoreDefaults.Click

            Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                AdvantageFramework.Database.Procedures.GridAdvantage.Delete(DataContext, AdvantageFramework.Database.Entities.GridAdvantageType.DigitalCampaignManagerEstimateDetailByPeriod, Session.UserCode)

                _Controller.Reset_PeriodGridLayout(_ViewModel)

            End Using

            DataGridViewForm_EstimateDetail.SetBookmarkColumnIndex(-1)
            DataGridViewForm_EstimateDetail.ClearGridCustomization()
            DataGridViewForm_EstimateDetail.ClearDatasource(New Generic.List(Of AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail))

            RefreshGrid()

            DataGridViewForm_EstimateDetail.CurrentView.BestFitColumns()

        End Sub
        Private Sub DataGridViewForm_EstimateDetail_CellValueChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_EstimateDetail.CellValueChangedEvent

            Dim DigitalEstimateDetail As AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail = Nothing

            If DataGridViewForm_EstimateDetail.HasOnlyOneSelectedRow Then

                DigitalEstimateDetail = DirectCast(DataGridViewForm_EstimateDetail.GetFirstSelectedRowDataBoundItem, AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail)

                If e.Column.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.PlanRate.ToString Then

                    _Controller.EstimateDetail_Recalculate(DigitalEstimateDetail, AdvantageFramework.Controller.Media.DigitalCampaignManagerController.QtyRateAmount.Rate)

                ElseIf e.Column.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.PlanImpressions.ToString Then

                    _Controller.EstimateDetail_Recalculate(DigitalEstimateDetail, AdvantageFramework.Controller.Media.DigitalCampaignManagerController.QtyRateAmount.Quantity)

                ElseIf e.Column.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.PlanSpend.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.PlanNetCharge.ToString Then

                    _Controller.EstimateDetail_Recalculate(DigitalEstimateDetail, AdvantageFramework.Controller.Media.DigitalCampaignManagerController.QtyRateAmount.Amount)

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_EstimateDetail_CustomColumnSortEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs) Handles DataGridViewForm_EstimateDetail.CustomColumnSortEvent

            Dim Value1 As Object = Nothing
            Dim Value2 As Object = Nothing

            If e.Column.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.MonthString.ToString Then

                Value1 = DataGridViewForm_EstimateDetail.CurrentView.GetListSourceRowCellValue(e.ListSourceRowIndex1, AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.Month.ToString)
                Value2 = DataGridViewForm_EstimateDetail.CurrentView.GetListSourceRowCellValue(e.ListSourceRowIndex2, AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.Month.ToString)

                e.Handled = True
                e.Result = System.Collections.Comparer.Default.Compare(Value1, Value2)

            End If

        End Sub
        Private Sub DataGridViewForm_EstimateDetail_HideCustomizationFormEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_EstimateDetail.HideCustomizationFormEvent

            If ButtonItemGrid_ChooseColumns.Checked Then

                ButtonItemGrid_ChooseColumns.Checked = False

            End If

        End Sub
        Private Sub DataGridViewForm_EstimateDetail_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewForm_EstimateDetail.ShowingEditorEvent

            If DataGridViewForm_EstimateDetail.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.PlanImpressions.ToString AndAlso
                    DataGridViewForm_EstimateDetail.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.PlanSpend.ToString AndAlso
                    DataGridViewForm_EstimateDetail.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.PlanNetCharge.ToString AndAlso
                    DataGridViewForm_EstimateDetail.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.PlanRate.ToString Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DataGridViewForm_EstimateDetail_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_EstimateDetail.DataSourceChangedEvent

            AdvantageFramework.Media.Presentation.SetDigitalEstimateDetailSummaryColumns(DataGridViewForm_EstimateDetail)

        End Sub

#End Region

#End Region

    End Class

End Namespace
