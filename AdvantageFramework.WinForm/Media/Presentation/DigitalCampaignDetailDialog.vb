Namespace Media.Presentation

    Public Class DigitalCampaignDetailDialog

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
        Protected _OpenPlanEstimateList As Generic.List(Of AdvantageFramework.DTO.Media.DigitalCampaignManager.OpenPlanEstimate) = Nothing
        Protected _PeriodAllSelected As Boolean = False
        Protected _PeriodAFActiveFilterString As String = Nothing
        Protected _FlightAFActiveFilterString As String = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(OpenPlanEstimateList As Generic.List(Of AdvantageFramework.DTO.Media.DigitalCampaignManager.OpenPlanEstimate))

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _OpenPlanEstimateList = OpenPlanEstimateList

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

            ButtonItemActions_Actualize.Enabled = ButtonItemView_Periods.Checked AndAlso (_OpenPlanEstimateList.Count = 1)

            ButtonItemActions_ActualizeRollForwardPercent.Enabled = True
            ButtonItemActions_ActualizeRollFowardAll.Enabled = True
            ButtonItemActions_ActualizeRollFowardNext.Enabled = True

            If DataGridViewForm_EstimateDetail.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail).Any(Function(DED) DED.SalesClassType <> "I") = True Then

                ButtonItemActions_ActualizeRollForwardPercent.Enabled = False
                ButtonItemActions_ActualizeRollFowardAll.Enabled = False
                ButtonItemActions_ActualizeRollFowardNext.Enabled = False

            End If

            ButtonItemActions_ReviseOrders.Enabled = Me.UserEntryChanged = False AndAlso ButtonItemView_Periods.Checked AndAlso (_OpenPlanEstimateList.Count = 1) AndAlso
                DataGridViewForm_EstimateDetail.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail).Where(Function(DED) DED.OrderLineNumber.HasValue).Select(Function(Entity) Entity.MediaPlanDetailID).Distinct.Count = 1

            DataGridViewForm_EstimateDetail.OptionsBehavior.Editable = ButtonItemView_Periods.Checked

        End Sub
        Private Sub LoadViewModel()

            _ViewModel = _Controller.EstimateDetail_Load(_OpenPlanEstimateList)

            If _OpenPlanEstimateList.Count > 1 Then

                Me.Text = "Digital Campaign Manager - Multiple Estimates Selected"

            Else

                Me.Text = "Digital Campaign Manager - [Media Plan - " & _OpenPlanEstimateList.First.PlanDescription & " (" & _OpenPlanEstimateList.First.EstimateName & ") - " & _ViewModel.CDPDescription & "]"

            End If

        End Sub
        Private Sub RefreshGrid(Optional ByVal ClearFilter As Boolean = False)

            Dim LayoutLoaded As Boolean = False
            Dim SubItemImageCheckEditControl As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemImageCheckEditControl = Nothing
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing

            If ButtonItemView_Flight.Checked Then

                LayoutLoaded = AdvantageFramework.WinForm.Presentation.Controls.LoadDataGridViewLayout(DataGridViewForm_EstimateDetail, _ViewModel.EstimateDetailByFlightGridLayout, RemoveOldColumns:=True)

                DataGridViewForm_EstimateDetail.DataSource = (From Entity In _ViewModel.DigitalEstimateDetails
                                                              Group By
                                                                  Entity.RowIndex,
                                                                  Entity.VendorName,
                                                                  Entity.Type,
                                                                  Entity.Tactic,
                                                                  Entity.CampaignName,
                                                                  Entity.MediaPlanID,
                                                                  Entity.PlanDescription,
                                                                  Entity.MediaPlanDetailID,
                                                                  Entity.EstimateName,
                                                                  Entity.EstimateBuyer,
                                                                  Entity.ClientName,
                                                                  Entity.DivisionName,
                                                                  Entity.ProductName,
                                                                  Entity.CostType,
                                                                  Entity.IsGross
                                                              Into Group = Group
                                                              Select New DTO.Media.DigitalCampaignManager.DigitalEstimateDetail With {
                                                                  .RowIndex = RowIndex,
                                                                  .VendorName = VendorName,
                                                                  .Type = Type,
                                                                  .Tactic = Tactic,
                                                                  .CampaignName = CampaignName,
                                                                  .MediaPlanID = MediaPlanID,
                                                                  .PlanDescription = PlanDescription,
                                                                  .MediaPlanDetailID = MediaPlanDetailID,
                                                                  .EstimateName = EstimateName,
                                                                  .EstimateBuyer = EstimateBuyer,
                                                                  .ClientName = ClientName,
                                                                  .DivisionName = DivisionName,
                                                                  .ProductName = ProductName,
                                                                  .CostType = CostType,
                                                                  .IsGross = IsGross,
                                                                  .StartDate = Group.Min(Function(G) G.StartDate),
                                                                  .EndDate = Group.Max(Function(G) G.EndDate),
                                                                  .PlanImpressions = Group.Sum(Function(G) G.PlanImpressions),
                                                                  .PlanRevenue = Group.Sum(Function(G) G.PlanRevenue),
                                                                  .PlanSpend = Group.Sum(Function(G) G.PlanSpend),
                                                                  .PlanNetCharge = Group.Sum(Function(G) G.PlanNetCharge),
                                                                  .ActualImpressions = Group.Sum(Function(G) G.ActualImpressions),
                                                                  .ActualRevenue = Group.Sum(Function(G) G.ActualRevenue),
                                                                  .ActualSpend = Group.Sum(Function(G) G.ActualSpend),
                                                                  .ActualNetCharge = Group.Sum(Function(G) G.ActualNetCharge),
                                                                  .OrigPlanSpend = Group.Sum(Function(G) G.OrigPlanSpend)
                                                                  }).OrderBy(Function(G) G.RowIndex).ToList

                Me.DataGridViewForm_EstimateDetail.CurrentView.ViewCaption = Me.DataGridViewForm_EstimateDetail.CurrentView.RowCount.ToString & " Flight Detail(s)"

            ElseIf ButtonItemView_Periods.Checked Then

                LayoutLoaded = AdvantageFramework.WinForm.Presentation.Controls.LoadDataGridViewLayout(DataGridViewForm_EstimateDetail, _ViewModel.EstimateDetailByPeriodGridLayout, RemoveOldColumns:=True)

                DataGridViewForm_EstimateDetail.DataSource = _ViewModel.DigitalEstimateDetails.OrderBy(Function(G) G.MediaPlanDetailID).ThenBy(Function(G) G.RowIndex).ThenBy(Function(Entity) Entity.EstimateLine).ThenBy(Function(Entity) Entity.StartDate).ToList

                Me.DataGridViewForm_EstimateDetail.CurrentView.ViewCaption = DataGridViewForm_EstimateDetail.CurrentView.RowCount.ToString & " Period Detail(s)"

                If _PeriodAllSelected = False Then

                    DataGridViewForm_EstimateDetail.CurrentView.SelectAll()

                    _PeriodAllSelected = True

                End If

                If DataGridViewForm_EstimateDetail.CurrentView.Columns(AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.MonthString.ToString) IsNot Nothing Then

                    DataGridViewForm_EstimateDetail.CurrentView.Columns(AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.MonthString.ToString).SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom

                End If

            End If

            If LayoutLoaded Then

                SetColumnVisibility()

            Else

                SetColumnDefaultVisibility()

                DataGridViewForm_EstimateDetail.CurrentView.BestFitColumns()

            End If

            If ClearFilter = False Then

                If ButtonItemView_Flight.Checked Then

                    DataGridViewForm_EstimateDetail.CurrentView.AFActiveFilterString = _FlightAFActiveFilterString

                ElseIf ButtonItemView_Periods.Checked Then

                    DataGridViewForm_EstimateDetail.CurrentView.AFActiveFilterString = _PeriodAFActiveFilterString

                End If

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

            If DataGridViewForm_EstimateDetail.CurrentView.Columns(AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.CostType.ToString) IsNot Nothing Then

                SubItemGridLookUpEditControl = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl

                SubItemGridLookUpEditControl.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.Type.Default

                SubItemGridLookUpEditControl.NullText = ""
                SubItemGridLookUpEditControl.DisplayMember = "Display"
                SubItemGridLookUpEditControl.ValueMember = "Value"

                SubItemGridLookUpEditControl.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Value", False, "Value"))
                SubItemGridLookUpEditControl.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Display", , "Cost Type"))

                BindingSource = New System.Windows.Forms.BindingSource

                BindingSource.DataSource = _ViewModel.RepositoryCostTypes

                SubItemGridLookUpEditControl.DataSource = BindingSource

                DataGridViewForm_EstimateDetail.GridControl.RepositoryItems.Add(SubItemGridLookUpEditControl)

                DataGridViewForm_EstimateDetail.Columns(AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.CostType.ToString).ColumnEdit = SubItemGridLookUpEditControl

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

                If _Controller.EstimateDetail_Save(DigitalEstimateDetails, _OpenPlanEstimateList.First.MediaPlanDetailID, _ViewModel, ErrorMessage) Then

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

            If ButtonItemView_Flight.Checked Then

                AdvantageFramework.WinForm.Presentation.Controls.SaveDataGridViewLayout(Me.Session, DataGridViewForm_EstimateDetail, AdvantageFramework.Database.Entities.GridAdvantageType.DigitalCampaignManagerEstimateDetailByFlight)

                _Controller.Reset_FlightGridLayout(_ViewModel)

            ElseIf ButtonItemView_Periods.Checked Then

                AdvantageFramework.WinForm.Presentation.Controls.SaveDataGridViewLayout(Me.Session, DataGridViewForm_EstimateDetail, AdvantageFramework.Database.Entities.GridAdvantageType.DigitalCampaignManagerEstimateDetailByPeriod)

                _Controller.Reset_PeriodGridLayout(_ViewModel)

            End If

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
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.HasInvoice.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.MediaPlanDetailID.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.EstimateName.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.EstimateBuyer.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.MediaPlanID.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.PlanDescription.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.ClientName.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.DivisionName.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.ProductName.ToString Then

                    GridColumn.Visible = False

                ElseIf GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.PlanRate.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.ActualRate.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.OrderNumber.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.OrderLineNumber.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.MonthString.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.Year.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.CostType.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.IsCPM.ToString Then

                    If Me.ButtonItemView_Flight.Checked Then

                        GridColumn.Visible = False

                        GridColumn.OptionsColumn.AllowShowHide = False
                        GridColumn.OptionsColumn.ShowInCustomizationForm = False

                    ElseIf GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.MonthString.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.Year.ToString Then

                        GridColumn.Visible = False

                        GridColumn.OptionsColumn.AllowShowHide = True
                        GridColumn.OptionsColumn.ShowInCustomizationForm = True

                    ElseIf GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.OrderNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.OrderLineNumber.ToString Then

                        GridColumn.Visible = False

                        GridColumn.OptionsColumn.AllowShowHide = True
                        GridColumn.OptionsColumn.ShowInCustomizationForm = True

                    Else

                        GridColumn.Visible = True

                        GridColumn.OptionsColumn.AllowShowHide = True
                        GridColumn.OptionsColumn.ShowInCustomizationForm = True

                    End If

                ElseIf GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.OrigPlanSpend.ToString Then

                    GridColumn.Visible = False

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

                    If Me.ButtonItemView_Flight.Checked Then

                        GridColumn.OptionsColumn.AllowShowHide = False
                        GridColumn.OptionsColumn.ShowInCustomizationForm = False

                    Else

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
        Private Sub UpdateAllChartsGauges()

            UpdateImpressionsGauge()
            UpdateSpendGauge()
            UpdateRevenueGauge()

            UpdateImpressionChart()
            UpdateSpendChart()
            UpdateRevenueChart()

        End Sub
        Private Sub UpdateRevenueGauge()

            Dim DigitalEstimateDetails As Generic.List(Of AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail) = Nothing
            Dim SumPlanRevenue As Decimal = 0
            Dim RevenuePercent As Integer = 0

            DigitalEstimateDetails = DataGridViewForm_EstimateDetail.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail).ToList

            SumPlanRevenue = DigitalEstimateDetails.Sum(Function(D) D.PlanRevenue)

            If SumPlanRevenue = 0 Then

                LabelComponent1.Text = "0%"
                ArcScaleComponent1.Value = 0

            Else

                RevenuePercent = FormatNumber(DigitalEstimateDetails.Sum(Function(D) D.ActualRevenue) / SumPlanRevenue * 100, 0)

                LabelComponent1.Text = RevenuePercent.ToString & "%"

                ArcScaleComponent1.Value = RevenuePercent

            End If

            LabelComponent2.Text = FormatNumber(DigitalEstimateDetails.Sum(Function(D) D.ActualRevenue), 2).ToString & vbCrLf & "of " & FormatNumber(SumPlanRevenue, 2).ToString

            GaugeControlForm_RevenueGoal.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder

        End Sub
        Private Sub UpdateSpendGauge()

            Dim DigitalEstimateDetails As Generic.List(Of AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail) = Nothing
            Dim SumPlanSpend As Decimal = 0
            Dim SpendPercent As Integer = 0

            DigitalEstimateDetails = DataGridViewForm_EstimateDetail.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail).ToList

            SumPlanSpend = DigitalEstimateDetails.Sum(Function(D) D.PlanSpend)

            If SumPlanSpend = 0 Then

                LabelComponent3.Text = "0%"
                ArcScaleComponent2.Value = 0

            Else

                SpendPercent = FormatNumber(DigitalEstimateDetails.Sum(Function(D) D.ActualSpend) / SumPlanSpend * 100, 0)

                LabelComponent3.Text = SpendPercent.ToString & "%"

                ArcScaleComponent2.Value = SpendPercent

            End If

            LabelComponent4.Text = FormatNumber(DigitalEstimateDetails.Sum(Function(D) D.ActualSpend), 2).ToString & vbCrLf & "of " & FormatNumber(SumPlanSpend, 2).ToString

            GaugeControlForm_SpendGoal.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder

        End Sub
        Private Sub UpdateImpressionsGauge()

            Dim DigitalEstimateDetails As Generic.List(Of AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail) = Nothing
            Dim SumPlanImpressions As Decimal = 0
            Dim ImpressionsPercent As Integer = 0
            Dim SumActualImpressions As Decimal = 0

            DigitalEstimateDetails = DataGridViewForm_EstimateDetail.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail).ToList

            If ButtonItemChartView_Clicks.Checked Then

                SumPlanImpressions += DigitalEstimateDetails.Where(Function(D) D.CostType = "CPC").Sum(Function(D) D.PlanImpressions)
                SumActualImpressions += DigitalEstimateDetails.Where(Function(D) D.CostType = "CPC").Sum(Function(D) D.ActualImpressions)

            End If

            If ButtonItemChartView_Impressions.Checked Then

                SumPlanImpressions += DigitalEstimateDetails.Where(Function(D) D.CostType = "CPI").Sum(Function(D) D.PlanImpressions)
                SumActualImpressions += DigitalEstimateDetails.Where(Function(D) D.CostType = "CPI").Sum(Function(D) D.ActualImpressions)

            End If

            If ButtonItemChartView_Units.Checked Then

                SumPlanImpressions += DigitalEstimateDetails.Where(Function(D) D.CostType = "CPA").Sum(Function(D) D.PlanImpressions)
                SumActualImpressions += DigitalEstimateDetails.Where(Function(D) D.CostType = "CPA").Sum(Function(D) D.ActualImpressions)

            End If

            If SumPlanImpressions = 0 Then

                LabelComponent5.Text = "0%"
                ArcScaleComponent3.Value = 0

            Else

                ImpressionsPercent = FormatNumber(SumActualImpressions / SumPlanImpressions * 100, 0)

                LabelComponent5.Text = ImpressionsPercent.ToString & "%"

                ArcScaleComponent3.Value = ImpressionsPercent

            End If

            LabelComponent6.Text = FormatNumber(SumActualImpressions, 0).ToString & vbCrLf & "of " & FormatNumber(SumPlanImpressions, 0).ToString

            If ButtonItemView_Periods.Checked AndAlso DigitalEstimateDetails.Count > 0 AndAlso DigitalEstimateDetails.Select(Function(DED) DED.CostType).Distinct.Count = 1 Then

                If DigitalEstimateDetails.First.CostType = "CPI" Then

                    LabelComponent7.Text = "IMPRESSIONS"

                ElseIf DigitalEstimateDetails.First.CostType = "CPA" Then

                    LabelComponent7.Text = "UNITS"

                ElseIf DigitalEstimateDetails.First.CostType = "CPC" Then

                    LabelComponent7.Text = "CLICKS"

                End If

            ElseIf (ButtonItemChartView_Clicks.Checked AndAlso ButtonItemChartView_Impressions.Checked) OrElse (ButtonItemChartView_Impressions.Checked AndAlso ButtonItemChartView_Units.Checked) OrElse
                    (ButtonItemChartView_Clicks.Checked AndAlso ButtonItemChartView_Units.Checked) Then

                LabelComponent7.Text = "IMPRESSIONS"

            ElseIf ButtonItemChartView_Clicks.Checked Then

                LabelComponent7.Text = "CLICKS"

            ElseIf ButtonItemChartView_Units.Checked Then

                LabelComponent7.Text = "UNITS"

            Else

                LabelComponent7.Text = "IMPRESSIONS"

            End If

            GaugeControlForm_ImpressionsGoal.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder

        End Sub
        Private Sub UpdateRevenueChart()

            Dim ChartTitle As DevExpress.XtraCharts.ChartTitle = Nothing
            Dim XYDiagram As DevExpress.XtraCharts.XYDiagram = Nothing
            Dim Font As System.Drawing.Font = Nothing

            Font = New System.Drawing.Font("Segoe UI", 9, Drawing.FontStyle.Bold)

            ChartTitle = New DevExpress.XtraCharts.ChartTitle()
            ChartTitle.Text = "REVENUE"
            ChartTitle.Alignment = Drawing.StringAlignment.Center
            ChartTitle.Dock = DevExpress.XtraCharts.ChartTitleDockStyle.Top
            ChartTitle.Font = Font
            ChartTitle.TextColor = System.Drawing.Color.Black

            Me.ChartControlCharts_Revenue.DataSource = (From Entity In DataGridViewForm_EstimateDetail.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail).ToList
                                                        Group By Entity.RowIndex, Entity.VendorName
                                                        Into GRP = Group
                                                        Select New AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail With {
                                                            .RowIndex = RowIndex,
                                                            .VendorName = VendorName,
                                                            .PlanRevenue = GRP.Sum(Function(E) E.PlanRevenue),
                                                            .ActualRevenue = GRP.Sum(Function(E) E.ActualRevenue)}).OrderBy(Function(E) E.RowIndex).ToList

            Me.ChartControlCharts_Revenue.Titles.Clear()

            Me.ChartControlCharts_Revenue.Titles.Add(ChartTitle)

            If ChartControlCharts_Revenue.Series.Count = 2 Then

                DirectCast(ChartControlCharts_Revenue.Series(1).View, DevExpress.XtraCharts.LineSeriesView).LineStyle.Thickness = 5
                DirectCast(ChartControlCharts_Revenue.Series(1).View, DevExpress.XtraCharts.LineSeriesView).LineStyle.DashStyle = DevExpress.XtraCharts.DashStyle.Dot

            End If

            Me.ChartControlCharts_Revenue.Series(0).CrosshairLabelPattern = "{S} : {V:n2}"
            Me.ChartControlCharts_Revenue.Series(1).CrosshairLabelPattern = "{S} : {V:n2}"
            Me.ChartControlCharts_Revenue.CrosshairOptions.GroupHeaderPattern = "Vendor: {HINT}"

            XYDiagram = DirectCast(ChartControlCharts_Revenue.Diagram, DevExpress.XtraCharts.XYDiagram)
            XYDiagram.AxisY.Label.TextPattern = "{V:n2}"

            XYDiagram.AxisX.Label.Angle = -30

        End Sub
        Private Sub UpdateSpendChart()

            Dim ChartTitle As DevExpress.XtraCharts.ChartTitle = Nothing
            Dim XYDiagram As DevExpress.XtraCharts.XYDiagram = Nothing
            Dim Font As System.Drawing.Font = Nothing

            Font = New System.Drawing.Font("Segoe UI", 9, Drawing.FontStyle.Bold)

            ChartTitle = New DevExpress.XtraCharts.ChartTitle()
            ChartTitle.Text = "SPEND"
            ChartTitle.Alignment = Drawing.StringAlignment.Center
            ChartTitle.Dock = DevExpress.XtraCharts.ChartTitleDockStyle.Top
            ChartTitle.Font = Font
            ChartTitle.TextColor = System.Drawing.Color.Black

            Me.ChartControlCharts_Spend.DataSource = (From Entity In DataGridViewForm_EstimateDetail.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail).ToList
                                                      Group By Entity.RowIndex, Entity.VendorName
                                                      Into GRP = Group
                                                      Select New AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail With {
                                                            .RowIndex = RowIndex,
                                                            .VendorName = VendorName,
                                                            .PlanSpend = GRP.Sum(Function(E) E.PlanSpend),
                                                            .ActualSpend = GRP.Sum(Function(E) E.ActualSpend)}).OrderBy(Function(E) E.RowIndex).ToList

            Me.ChartControlCharts_Spend.Titles.Clear()

            Me.ChartControlCharts_Spend.Titles.Add(ChartTitle)

            If ChartControlCharts_Spend.Series.Count = 2 Then

                DirectCast(ChartControlCharts_Spend.Series(1).View, DevExpress.XtraCharts.LineSeriesView).LineStyle.Thickness = 5
                DirectCast(ChartControlCharts_Spend.Series(1).View, DevExpress.XtraCharts.LineSeriesView).LineStyle.DashStyle = DevExpress.XtraCharts.DashStyle.Dot

            End If

            Me.ChartControlCharts_Spend.Series(0).CrosshairLabelPattern = "{S} : {V:n2}"
            Me.ChartControlCharts_Spend.Series(1).CrosshairLabelPattern = "{S} : {V:n2}"
            Me.ChartControlCharts_Spend.CrosshairOptions.GroupHeaderPattern = "Vendor: {HINT}"

            XYDiagram = DirectCast(ChartControlCharts_Spend.Diagram, DevExpress.XtraCharts.XYDiagram)
            XYDiagram.AxisY.Label.TextPattern = "{V:n2}"

            XYDiagram.AxisX.Label.Angle = -30

        End Sub
        Private Sub UpdateImpressionChart()

            Dim ChartTitle As DevExpress.XtraCharts.ChartTitle = Nothing
            Dim XYDiagram As DevExpress.XtraCharts.XYDiagram = Nothing
            Dim Font As System.Drawing.Font = Nothing
            Dim DigitalEstimateDetails As Generic.List(Of AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail) = Nothing
            Dim ActualUnitsString As String = Nothing
            Dim PlanUnitsString As String = Nothing
            Dim CostTypes As Generic.List(Of String) = Nothing

            DigitalEstimateDetails = DataGridViewForm_EstimateDetail.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail).ToList

            Font = New System.Drawing.Font("Segoe UI", 9, Drawing.FontStyle.Bold)

            ChartTitle = New DevExpress.XtraCharts.ChartTitle()
            ChartTitle.Alignment = Drawing.StringAlignment.Center
            ChartTitle.Dock = DevExpress.XtraCharts.ChartTitleDockStyle.Top
            ChartTitle.Font = Font
            ChartTitle.TextColor = System.Drawing.Color.Black

            If ButtonItemView_Periods.Checked AndAlso DigitalEstimateDetails.Count > 0 AndAlso DigitalEstimateDetails.Select(Function(DED) DED.CostType).Distinct.Count = 1 Then

                If DigitalEstimateDetails.First.CostType = "CPI" Then

                    ChartTitle.Text = "IMPRESSIONS"
                    ActualUnitsString = "Actual Impressions"
                    PlanUnitsString = "Plan Impressions"

                ElseIf DigitalEstimateDetails.First.CostType = "CPA" Then

                    ChartTitle.Text = "UNITS"
                    ActualUnitsString = "Actual Units"
                    PlanUnitsString = "Plan Units"

                ElseIf DigitalEstimateDetails.First.CostType = "CPC" Then

                    ChartTitle.Text = "CLICKS"
                    ActualUnitsString = "Actual Clicks"
                    PlanUnitsString = "Plan Clicks"

                End If

            ElseIf (ButtonItemChartView_Clicks.Checked AndAlso ButtonItemChartView_Impressions.Checked) OrElse (ButtonItemChartView_Impressions.Checked AndAlso ButtonItemChartView_Units.Checked) OrElse
                    (ButtonItemChartView_Clicks.Checked AndAlso ButtonItemChartView_Units.Checked) Then

                ChartTitle.Text = "IMPRESSIONS"
                ActualUnitsString = "Actual Impressions"
                PlanUnitsString = "Plan Impressions"

            ElseIf ButtonItemChartView_Clicks.Checked Then

                ChartTitle.Text = "CLICKS"
                ActualUnitsString = "Actual Clicks"
                PlanUnitsString = "Plan Clicks"

            ElseIf ButtonItemChartView_Units.Checked Then

                ChartTitle.Text = "UNITS"
                ActualUnitsString = "Actual Units"
                PlanUnitsString = "Plan Units"

            Else

                ChartTitle.Text = "IMPRESSIONS"
                ActualUnitsString = "Actual Impressions"
                PlanUnitsString = "Plan Impressions"

            End If

            CostTypes = New Generic.List(Of String)

            If ButtonItemChartView_Clicks.Checked Then

                CostTypes.Add("CPC")

            End If

            If ButtonItemChartView_Impressions.Checked Then

                CostTypes.Add("CPI")

            End If

            If ButtonItemChartView_Units.Checked Then

                CostTypes.Add("CPA")

            End If

            Me.ChartControlCharts_Impressions.DataSource = (From Entity In DigitalEstimateDetails
                                                            Where CostTypes.Contains(Entity.CostType)
                                                            Group By Entity.RowIndex, Entity.VendorName
                                                                Into GRP = Group
                                                            Select New AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail With {
                                                                .RowIndex = RowIndex,
                                                                .VendorName = VendorName,
                                                                .PlanImpressions = GRP.Sum(Function(E) E.PlanImpressions),
                                                                .ActualImpressions = GRP.Sum(Function(E) E.ActualImpressions)}).OrderBy(Function(E) E.RowIndex).ToList

            Me.ChartControlCharts_Impressions.Titles.Clear()

            Me.ChartControlCharts_Impressions.Titles.Add(ChartTitle)

            If ChartControlCharts_Impressions.Series.Count = 2 Then

                DirectCast(ChartControlCharts_Impressions.Series(1).View, DevExpress.XtraCharts.LineSeriesView).LineStyle.Thickness = 5
                DirectCast(ChartControlCharts_Impressions.Series(1).View, DevExpress.XtraCharts.LineSeriesView).LineStyle.DashStyle = DevExpress.XtraCharts.DashStyle.Dot

            End If

            Me.ChartControlCharts_Impressions.Series(0).CrosshairLabelPattern = ActualUnitsString & " : {V:n0}"
            Me.ChartControlCharts_Impressions.Series(1).CrosshairLabelPattern = PlanUnitsString & " : {V:n0}"
            Me.ChartControlCharts_Impressions.CrosshairOptions.GroupHeaderPattern = "Vendor: {HINT}"

            XYDiagram = DirectCast(ChartControlCharts_Impressions.Diagram, DevExpress.XtraCharts.XYDiagram)
            XYDiagram.AxisY.Label.TextPattern = "{V:n0}"

            XYDiagram.AxisX.Label.Angle = -30

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
        Private Sub AddImagesToZipfile(ZipFile As Ionic.Zip.ZipFile)

            Dim MemoryStream As System.IO.MemoryStream = Nothing

            MemoryStream = New System.IO.MemoryStream
            GaugeControlForm_ImpressionsGoal.ExportToImage(MemoryStream, Drawing.Imaging.ImageFormat.Png)
            ZipFile.AddEntry("Gauge_Impressions.png", MemoryStream.ToArray)

            MemoryStream = New System.IO.MemoryStream
            GaugeControlForm_RevenueGoal.ExportToImage(MemoryStream, Drawing.Imaging.ImageFormat.Png)
            ZipFile.AddEntry("Gauge_Revenue.png", MemoryStream.ToArray)

            MemoryStream = New System.IO.MemoryStream
            GaugeControlForm_SpendGoal.ExportToImage(MemoryStream, Drawing.Imaging.ImageFormat.Png)
            ZipFile.AddEntry("Gauge_Spend.png", MemoryStream.ToArray)

            MemoryStream = New System.IO.MemoryStream
            ChartControlCharts_Impressions.ExportToImage(MemoryStream, Drawing.Imaging.ImageFormat.Png)
            ZipFile.AddEntry("Chart_Impressions.png", MemoryStream.ToArray)

            MemoryStream = New System.IO.MemoryStream
            ChartControlCharts_Revenue.ExportToImage(MemoryStream, Drawing.Imaging.ImageFormat.Png)
            ZipFile.AddEntry("Chart_Revenue.png", MemoryStream.ToArray)

            MemoryStream = New System.IO.MemoryStream
            ChartControlCharts_Spend.ExportToImage(MemoryStream, Drawing.Imaging.ImageFormat.Png)
            ZipFile.AddEntry("Chart_Spend.png", MemoryStream.ToArray)

            ZipFile.Save()
            ZipFile.Dispose()

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(OpenPlanEstimateList As Generic.List(Of AdvantageFramework.DTO.Media.DigitalCampaignManager.OpenPlanEstimate)) As System.Windows.Forms.DialogResult

            'objects
            Dim DigitalCampaignDetailDialog As AdvantageFramework.Media.Presentation.DigitalCampaignDetailDialog = Nothing

            DigitalCampaignDetailDialog = New AdvantageFramework.Media.Presentation.DigitalCampaignDetailDialog(OpenPlanEstimateList)

            ShowFormDialog = DigitalCampaignDetailDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub DigitalCampaignDetailDialog_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

            AdvantageFramework.MediaPlanning.ClearEstimateLock(Me.Session, _OpenPlanEstimateList.First.MediaPlanDetailID)

        End Sub
        Private Sub DigitalCampaignDetailDialog_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

            If e.CloseReason = Windows.Forms.CloseReason.UserClosing Then

                SaveGridLayout()

            End If

        End Sub
        Private Sub DigitalCampaignDetailDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Me.ShowUnsavedChangesOnFormClosing = False

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemActions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage
            ButtonItemActions_Actualize.Image = AdvantageFramework.My.Resources.UpdateImage
            ButtonItemActions_ReviseOrders.Image = AdvantageFramework.My.Resources.CreateForSelectedRowsImage

            ButtonItemGrid_ChooseColumns.Image = AdvantageFramework.My.Resources.ColumnImage
            ButtonItemGrid_RestoreDefaults.Image = AdvantageFramework.My.Resources.RestoreDefaultsImage

            ButtonItemView_Flight.Image = AdvantageFramework.My.Resources.DateTimeImage
            ButtonItemView_Periods.Image = AdvantageFramework.My.Resources.MonthImage

            ButtonItemView_Flight.Checked = True

            ButtonItemChartView_Impressions.Checked = True
            ButtonItemChartView_Clicks.Checked = True
            ButtonItemChartView_Units.Checked = True

            DataGridViewForm_EstimateDetail.DataSource = New Generic.List(Of AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail)

            _Controller = New AdvantageFramework.Controller.Media.DigitalCampaignManagerController(Me.Session)

        End Sub
        Private Sub DigitalCampaignDetailDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            Me.ShowWaitForm("Loading...")

            Me.DataGridViewForm_EstimateDetail.AutoUpdateViewCaption = False

            If _OpenPlanEstimateList.Count = 1 Then

                Me.TextBoxForm_Buyer.Text = _OpenPlanEstimateList.First.EstimateBuyer
                Me.TextBoxForm_Estimate.Text = _OpenPlanEstimateList.First.MediaPlanDetailID.ToString & " - " & _OpenPlanEstimateList.First.EstimateName
                Me.TextBoxForm_Campaign.Text = _OpenPlanEstimateList.First.EstimateCampaign

            Else

                Me.TextBoxForm_Buyer.Text = "Multi"
                Me.TextBoxForm_Estimate.Text = "Multi"
                Me.TextBoxForm_Campaign.Text = "Multi"

            End If

            LoadViewModel()

            RefreshGrid()

            DataGridViewForm_EstimateDetail.CurrentView.SelectAll()

            Me.ClearChanged()

            EnableOrDisableActions()

            Me.FormAction = WinForm.Presentation.FormActions.None

            Me.CloseWaitForm()

        End Sub
        Private Sub DigitalCampaignDetailDialog_UserEntryChangedEvent(Control As AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

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

            If ButtonItemView_Flight.Checked Then

                _FlightAFActiveFilterString = DataGridViewForm_EstimateDetail.CurrentView.AFActiveFilterString

            ElseIf ButtonItemView_Periods.Checked Then

                _PeriodAFActiveFilterString = DataGridViewForm_EstimateDetail.CurrentView.AFActiveFilterString

            End If

            LoadViewModel()

            SaveGridLayout()

            RefreshGrid()

            Me.ClearChanged()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_ReviseOrders_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_ReviseOrders.Click

            Dim SelectedDigitalEstimateDetails As Generic.List(Of AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail) = Nothing
            Dim MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan = Nothing
            Dim DataFilter As AdvantageFramework.Exporting.DataFilterClasses.MediaPlanningData = Nothing
            Dim CreateOrderOption As AdvantageFramework.MediaPlanning.CreateOrderOptions = AdvantageFramework.MediaPlanning.Methods.CreateOrderOptions.Default
            Dim DataTable As System.Data.DataTable = Nothing
            Dim OrderGroupingLevelLinesDataTable As System.Data.DataTable = Nothing
            Dim EstimateMediaPlanOrderGrouping As AdvantageFramework.Exporting.MediaPlanOrderGroupings = Nothing
            Dim CreateOrderBroadcastCalendarType As AdvantageFramework.MediaPlanning.CreateOrderBroadcastCalendarType = Nothing
            Dim DoesHaveCustomDates As Boolean = False
            Dim MediaPlanningDataList As Generic.List(Of AdvantageFramework.Exporting.DataClasses.MediaPlanningData) = Nothing
            Dim ErrorMessage As String = Nothing
            Dim ImportOrderList As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder) = Nothing

            SelectedDigitalEstimateDetails = DataGridViewForm_EstimateDetail.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail).Where(Function(DED) DED.OrderLineNumber.HasValue).ToList

            If SelectedDigitalEstimateDetails.Select(Function(Entity) Entity.MediaPlanDetailID).Distinct.Count = 1 Then

                MediaPlan = New AdvantageFramework.MediaPlanning.Classes.MediaPlan(Me.Session.ConnectionString, Me.Session.UserCode, SelectedDigitalEstimateDetails.First.MediaPlanID)

                MediaPlan.SelectMediaPlanEstimateByMediaPlanDetailID(SelectedDigitalEstimateDetails.First.MediaPlanDetailID)

                If MediaPlan.IsAttachedToBroadcastWorksheet = False Then

                    If MediaPlan.HasPendingOrders = False Then

                        If MediaPlan.MediaPlanEstimate IsNot Nothing AndAlso MediaPlan.MediaPlanEstimate.ID > 0 Then

                            DataFilter = New AdvantageFramework.Exporting.DataFilterClasses.MediaPlanningData(MediaPlan.ID, MediaPlan.MediaPlanEstimate.ID)

                            CreateOrderOption = MediaPlan.MediaPlanEstimate.CreateOrderOption

                            If AdvantageFramework.Media.Presentation.MediaPlanOrderBillDialog.ShowFormDialog(MediaPlan.ID, MediaPlan.MediaPlanEstimate.ID, DataFilter, DataTable,
                                                                                                             OrderGroupingLevelLinesDataTable, EstimateMediaPlanOrderGrouping,
                                                                                                             CreateOrderBroadcastCalendarType, CreateOrderOption, DoesHaveCustomDates, SelectedDigitalEstimateDetails.Select(Function(DED) DED.RowIndex).Distinct.ToArray) = Windows.Forms.DialogResult.OK Then

                                Me.FormAction = WinForm.Presentation.FormActions.Loading
                                Me.ShowWaitForm("Loading...")

                                If AdvantageFramework.Media.Presentation.OkayToCreateMediaPlanOrders(DataTable, OrderGroupingLevelLinesDataTable, EstimateMediaPlanOrderGrouping, MediaPlanningDataList, ErrorMessage) Then

                                    ImportOrderList = GetImportOrderList(Me.Session, MediaPlan, DataFilter, OrderGroupingLevelLinesDataTable, MediaPlanningDataList, EstimateMediaPlanOrderGrouping, CreateOrderBroadcastCalendarType)

                                    AdvantageFramework.Media.Presentation.MediaPlanCreateOrders(ImportOrderList, CreateOrderOption, MediaPlan, EstimateMediaPlanOrderGrouping, MediaPlanningDataList, OrderGroupingLevelLinesDataTable)

                                ElseIf String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                                End If

                                Me.FormAction = WinForm.Presentation.FormActions.None
                                Me.CloseWaitForm()

                            End If

                        End If

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("There are pending orders needing to be processed before this plan can create\revise any orders.")

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Orders cannot be created from this plan estimate because it is attached to a broadcast worksheet.")

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            If ButtonItemView_Flight.Checked Then

                _FlightAFActiveFilterString = DataGridViewForm_EstimateDetail.CurrentView.AFActiveFilterString

            ElseIf ButtonItemView_Periods.Checked Then

                _PeriodAFActiveFilterString = DataGridViewForm_EstimateDetail.CurrentView.AFActiveFilterString

            End If

            Save()

        End Sub
        Private Sub ButtonItemExport_Grid_Click(sender As Object, e As EventArgs) Handles ButtonItemExport_Grid.Click

            DataGridViewForm_EstimateDetail.Print(Me.Session, DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("Dialog", ""))

        End Sub
        Private Sub ButtonItemExport_Images_Click(sender As Object, e As EventArgs) Handles ButtonItemExport_Images.Click

            Dim SelectedPath As String = Nothing
            Dim ZipFile As Ionic.Zip.ZipFile = Nothing
            Dim FilePrefix As String = Nothing

            If _ViewModel.IsAgencyASP Then

                If String.IsNullOrWhiteSpace(_ViewModel.HostedPath) = False AndAlso System.IO.Directory.Exists(_ViewModel.HostedPath) Then

                    SelectedPath = _ViewModel.HostedPath

                    If _OpenPlanEstimateList.Count = 1 Then

                        SelectedPath += _OpenPlanEstimateList.First.MediaPlanDetailID.ToString & "_DCM_Images"

                    Else

                        SelectedPath += "MULTI_DCM_Images"

                    End If

                    If System.IO.File.Exists(SelectedPath & ".zip") Then

                        System.IO.File.Delete(SelectedPath & ".zip")

                    End If

                    ZipFile = New Ionic.Zip.ZipFile(SelectedPath & ".zip")

                    AddImagesToZipfile(ZipFile)

                    If Not AdvantageFramework.Email.SendASPReportDownloadEmail(Session, ZipFile.Name) Then

                        AdvantageFramework.WinForm.MessageBox.Show("File exported successfully but email link could not be sent to your email.")

                    Else

                        Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                            If _ViewModel.IsAgencyASP AndAlso
                                    AdvantageFramework.Agency.LoadSendFilesAsOneTimeLink(DataContext) Then

                                AdvantageFramework.WinForm.MessageBox.Show("Images email link has been sent to your email.")

                            Else

                                AdvantageFramework.WinForm.MessageBox.Show("Images zipped, exported and also email link has been sent to your email.")

                            End If

                        End Using

                    End If

                End If

            ElseIf FolderBrowserDialogExport.ShowDialog() = Windows.Forms.DialogResult.OK Then

                SelectedPath = FolderBrowserDialogExport.SelectedPath

                If SelectedPath.EndsWith("\") = False Then

                    SelectedPath += "\"

                End If

                If _OpenPlanEstimateList.Count = 1 Then

                    SelectedPath += _OpenPlanEstimateList.First.MediaPlanDetailID.ToString & "_DCM_Images"

                Else

                    SelectedPath += "MULTI_DCM_Images"

                End If

                If System.IO.File.Exists(SelectedPath & ".zip") Then

                    System.IO.File.Delete(SelectedPath & ".zip")

                End If

                ZipFile = New Ionic.Zip.ZipFile(SelectedPath & ".zip")

                AddImagesToZipfile(ZipFile)

                AdvantageFramework.WinForm.MessageBox.Show("Images zipped and exported.")

            End If

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

                If ButtonItemView_Flight.Checked Then

                    AdvantageFramework.Database.Procedures.GridAdvantage.Delete(DataContext, AdvantageFramework.Database.Entities.GridAdvantageType.DigitalCampaignManagerEstimateDetailByFlight, Session.UserCode)

                    _Controller.Reset_FlightGridLayout(_ViewModel)

                ElseIf ButtonItemView_Periods.Checked Then

                    AdvantageFramework.Database.Procedures.GridAdvantage.Delete(DataContext, AdvantageFramework.Database.Entities.GridAdvantageType.DigitalCampaignManagerEstimateDetailByPeriod, Session.UserCode)

                    _Controller.Reset_PeriodGridLayout(_ViewModel)

                End If

            End Using

            DataGridViewForm_EstimateDetail.SetBookmarkColumnIndex(-1)
            DataGridViewForm_EstimateDetail.ClearGridCustomization()
            DataGridViewForm_EstimateDetail.ClearDatasource(New Generic.List(Of AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail))

            RefreshGrid(True)

            DataGridViewForm_EstimateDetail.CurrentView.BestFitColumns()

        End Sub
        Private Sub ButtonItemView_Flight_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemView_Flight.CheckedChanged

            If Me.FormShown AndAlso ButtonItemView_Flight.Checked Then

                RefreshGrid()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemView_Periods_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemView_Periods.CheckedChanged

            If Me.FormShown AndAlso ButtonItemView_Periods.Checked Then

                RefreshGrid()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemView_OptionGroupChanging(sender As Object, e As DevComponents.DotNetBar.OptionGroupChangingEventArgs) Handles ButtonItemView_Flight.OptionGroupChanging, ButtonItemView_Periods.OptionGroupChanging

            If Me.FormShown Then

                If Me.UserEntryChanged Then

                    e.Cancel = Not CheckForUnsavedChanges()

                End If

                If e.Cancel = False Then

                    If e.OldChecked.Name = "ButtonItemView_Flight" Then

                        _FlightAFActiveFilterString = DataGridViewForm_EstimateDetail.CurrentView.AFActiveFilterString

                    ElseIf e.OldChecked.Name = "ButtonItemView_Periods" Then

                        _PeriodAFActiveFilterString = DataGridViewForm_EstimateDetail.CurrentView.AFActiveFilterString

                    End If

                    SaveGridLayout()

                    If ButtonItemGrid_ChooseColumns.Checked Then

                        ButtonItemGrid_ChooseColumns.Checked = False

                    End If

                    Me.ClearChanged()

                    EnableOrDisableActions()

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_EstimateDetail_CellValueChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_EstimateDetail.CellValueChangedEvent

            Dim DigitalEstimateDetail As AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail = Nothing

            If DataGridViewForm_EstimateDetail.HasOnlyOneSelectedRow Then

                DigitalEstimateDetail = DirectCast(DataGridViewForm_EstimateDetail.GetFirstSelectedRowDataBoundItem, AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail)

                If e.Column.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.PlanRate.ToString Then

                    _Controller.EstimateDetail_Recalculate(DigitalEstimateDetail, AdvantageFramework.Controller.Media.DigitalCampaignManagerController.QtyRateAmount.Rate)

                ElseIf e.Column.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.PlanImpressions.ToString Then

                    If e.Value Is Nothing Then

                        DigitalEstimateDetail.CostType = "NA"

                    End If

                    _Controller.EstimateDetail_Recalculate(DigitalEstimateDetail, AdvantageFramework.Controller.Media.DigitalCampaignManagerController.QtyRateAmount.Quantity)

                ElseIf e.Column.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.PlanSpend.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.PlanNetCharge.ToString Then

                    _Controller.EstimateDetail_Recalculate(DigitalEstimateDetail, AdvantageFramework.Controller.Media.DigitalCampaignManagerController.QtyRateAmount.Amount)

                ElseIf e.Column.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.CostType.ToString Then

                    DigitalEstimateDetail.IsDirty = True

                    If e.Value = "NA" Then

                        DigitalEstimateDetail.PlanImpressions = Nothing

                    End If

                End If

                UpdateAllChartsGauges()

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
        Private Sub DataGridViewForm_EstimateDetail_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_EstimateDetail.SelectionChangedEvent

            UpdateAllChartsGauges()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_EstimateDetail_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewForm_EstimateDetail.ShowingEditorEvent

            If DataGridViewForm_EstimateDetail.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.CostType.ToString Then

                If DirectCast(DataGridViewForm_EstimateDetail.CurrentView.GetRow(DataGridViewForm_EstimateDetail.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail).SalesClassType <> "I" Then

                    e.Cancel = True

                End If

            ElseIf DataGridViewForm_EstimateDetail.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.PlanImpressions.ToString Then

                If DirectCast(DataGridViewForm_EstimateDetail.CurrentView.GetRow(DataGridViewForm_EstimateDetail.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail).CostType = "NA" Then

                    e.Cancel = True

                End If

            ElseIf DataGridViewForm_EstimateDetail.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.PlanSpend.ToString AndAlso
                    DataGridViewForm_EstimateDetail.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.PlanNetCharge.ToString AndAlso
                    DataGridViewForm_EstimateDetail.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.PlanRate.ToString Then

                e.Cancel = True

            End If

        End Sub
        Private Sub ButtonItemChartView_Clicks_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemChartView_Clicks.CheckedChanged

            UpdateImpressionChart()
            UpdateImpressionsGauge()

        End Sub
        Private Sub ButtonItemChartView_Impressions_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemChartView_Impressions.CheckedChanged

            UpdateImpressionChart()
            UpdateImpressionsGauge()

        End Sub
        Private Sub ButtonItemChartView_Units_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemChartView_Units.CheckedChanged

            UpdateImpressionChart()
            UpdateImpressionsGauge()

        End Sub
        Private Sub DataGridViewForm_EstimateDetail_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_EstimateDetail.DataSourceChangedEvent

            AdvantageFramework.Media.Presentation.SetDigitalEstimateDetailSummaryColumns(DataGridViewForm_EstimateDetail)

        End Sub
        Private Sub DataGridViewForm_EstimateDetail_RepositoryDataSourceLoadingEvent(FieldName As String, ByRef Datasource As Object) Handles DataGridViewForm_EstimateDetail.RepositoryDataSourceLoadingEvent

            If FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.CostType.ToString Then

                Datasource = _ViewModel.RepositoryCostTypes

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
