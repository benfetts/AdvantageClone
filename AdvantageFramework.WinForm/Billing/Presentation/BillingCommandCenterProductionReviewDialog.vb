Namespace Billing.Presentation

    Public Class BillingCommandCenterProductionReviewDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _BillingCommandCenterID As Integer = 0
        Private WithEvents _ToolTipController As DevExpress.Utils.ToolTipController = Nothing
        Private _BillingStatus As AdvantageFramework.BillingCommandCenter.Database.Classes.BillingStatus = Nothing
        Private _ObjectTypePropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal BillingCommandCenterID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            _BillingCommandCenterID = BillingCommandCenterID

        End Sub
        Private Sub SaveGridLayout()

            Dim AFActiveFilterString As String = Nothing

            AFActiveFilterString = DataGridViewForm_ProductionSummary.CurrentView.AFActiveFilterString

            AdvantageFramework.WinForm.Presentation.Controls.SaveDataGridViewLayout(Session, DataGridViewForm_ProductionSummary, AdvantageFramework.Database.Entities.GridAdvantageType.BillingCommandCenterProductionReview)

            DataGridViewForm_ProductionSummary.CurrentView.AFActiveFilterString = AFActiveFilterString

        End Sub
        Private Sub LoadGrid()

            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim SelectAll As Boolean = False
            Dim SelectedJobComponents As Generic.List(Of String) = Nothing
            Dim LayoutLoaded As Boolean = False
            Dim ProductionSummaryList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary) = Nothing
            Dim ProductionSummary As AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary = Nothing
            Dim AFActiveFilterString As String = Nothing

            Me.ShowWaitForm()

            AFActiveFilterString = DataGridViewForm_ProductionSummary.CurrentView.AFActiveFilterString

            BindingSource = DataGridViewForm_ProductionSummary.DataSource

            If BindingSource IsNot Nothing AndAlso BindingSource.DataSource IsNot Nothing Then

                SaveGridLayout()

            End If

            If DataGridViewForm_ProductionSummary.CurrentView.SelectedRowsCount > 1 AndAlso DataGridViewForm_ProductionSummary.CurrentView.SelectedRowsCount = DataGridViewForm_ProductionSummary.CurrentView.RowCount Then

                SelectAll = True

            ElseIf DataGridViewForm_ProductionSummary.CurrentView.SelectedRowsCount >= 1 Then

                SelectedJobComponents = (From PS In DataGridViewForm_ProductionSummary.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary)()
                                         Select PS.JobNumber & "|" & PS.ComponentNumber).ToList

            End If

            DataGridViewForm_ProductionSummary.SetBookmarkColumnIndex(-1)
            DataGridViewForm_ProductionSummary.ClearGridCustomization()
            DataGridViewForm_ProductionSummary.ClearDatasource(New Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary))
            DataGridViewForm_ProductionSummary.ItemDescription = "Production Summary(ies)"

            LayoutLoaded = AdvantageFramework.WinForm.Presentation.Controls.LoadDataGridViewLayout(Session, DataGridViewForm_ProductionSummary, Database.Entities.GridAdvantageType.BillingCommandCenterProductionReview, RemoveOldColumns:=True)

            Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                ProductionSummaryList = AdvantageFramework.BillingCommandCenter.GetProductionSummary(BCCDbContext, _BillingCommandCenterID, ButtonItemInclude_Contingency.Checked)

                DataGridViewForm_ProductionSummary.DataSource = ProductionSummaryList

            End Using

            If Not LayoutLoaded Then

                SetColumnDefaultVisibility(DataGridViewForm_ProductionSummary)

                DataGridViewForm_ProductionSummary.CurrentView.ClearSorting()
                DataGridViewForm_ProductionSummary.CurrentView.BeginSort()
                DataGridViewForm_ProductionSummary.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.JobNumber.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Descending
                DataGridViewForm_ProductionSummary.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ComponentNumber.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                DataGridViewForm_ProductionSummary.CurrentView.EndSort()

            Else

                RemoveUnusedColumns()

                AdvantageFramework.WinForm.Presentation.Controls.SortGridViewBySortedColumns(DataGridViewForm_ProductionSummary)

            End If

            DataGridViewForm_ProductionSummary.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True

            If DataGridViewForm_ProductionSummary.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.BillStatus.ToString) IsNot Nothing Then

                AddSubItemImageComboBox(DataGridViewForm_ProductionSummary, DataGridViewForm_ProductionSummary.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.BillStatus.ToString))

            End If

            If DataGridViewForm_ProductionSummary.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.BillingApprovalHeaderClientComment.ToString) IsNot Nothing Then

                AddSubItemMemoItem(DataGridViewForm_ProductionSummary, DataGridViewForm_ProductionSummary.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.BillingApprovalHeaderClientComment.ToString), Me.Session)

            End If

            If DataGridViewForm_ProductionSummary.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.BillingApprovalHeaderComment.ToString) IsNot Nothing Then

                AddSubItemMemoItem(DataGridViewForm_ProductionSummary, DataGridViewForm_ProductionSummary.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.BillingApprovalHeaderComment.ToString), Me.Session)

            End If

            If DataGridViewForm_ProductionSummary.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.JobBillComment.ToString) IsNot Nothing Then

                AddSubItemMemoItem(DataGridViewForm_ProductionSummary, DataGridViewForm_ProductionSummary.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.JobBillComment.ToString), Me.Session)

            End If

            If DataGridViewForm_ProductionSummary.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.CampaignComment.ToString) IsNot Nothing Then

                AddSubItemMemoItem(DataGridViewForm_ProductionSummary, DataGridViewForm_ProductionSummary.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.CampaignComment.ToString), Me.Session)

            End If

            If DataGridViewForm_ProductionSummary.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.JobComment.ToString) IsNot Nothing Then

                AddSubItemMemoItem(DataGridViewForm_ProductionSummary, DataGridViewForm_ProductionSummary.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.JobComment.ToString), Me.Session)

            End If

            If DataGridViewForm_ProductionSummary.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.JobComponentComment.ToString) IsNot Nothing Then

                AddSubItemMemoItem(DataGridViewForm_ProductionSummary, DataGridViewForm_ProductionSummary.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.JobComponentComment.ToString), Me.Session)

            End If

            AddFixedLeftColumns(DataGridViewForm_ProductionSummary)

            If SelectAll Then

                DataGridViewForm_ProductionSummary.SelectAll()

            ElseIf SelectedJobComponents IsNot Nothing AndAlso SelectedJobComponents.Count > 0 Then

                DataGridViewForm_ProductionSummary.CurrentView.BeginSelection()

                DataGridViewForm_ProductionSummary.CurrentView.ClearSelection()

                For Each RowHandlesAndDataBoundItem In DataGridViewForm_ProductionSummary.GetAllRowsRowHandlesAndDataBoundItems

                    Try

                        ProductionSummary = RowHandlesAndDataBoundItem.Value

                    Catch ex As Exception
                        ProductionSummary = Nothing
                    End Try

                    If ProductionSummary IsNot Nothing AndAlso SelectedJobComponents.Contains(ProductionSummary.JobNumber & "|" & ProductionSummary.ComponentNumber) Then

                        DataGridViewForm_ProductionSummary.CurrentView.SelectRow(RowHandlesAndDataBoundItem.Key)
                        DataGridViewForm_ProductionSummary.CurrentView.FocusedRowHandle = RowHandlesAndDataBoundItem.Key

                    End If

                Next

                DataGridViewForm_ProductionSummary.CurrentView.EndSelection()

            End If

            DataGridViewForm_ProductionSummary.CurrentView.AFActiveFilterString = AFActiveFilterString

            If Not LayoutLoaded Then

                DataGridViewForm_ProductionSummary.CurrentView.BestFitColumns()

            End If

            Me.CloseWaitForm()

        End Sub
        Private Sub AddFixedLeftColumns(ByVal DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView)

            If DataGridView.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.AmountSelectedforBilling.ToString) IsNot Nothing Then

                DataGridView.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.AmountSelectedforBilling.ToString).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                DataGridView.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.AmountSelectedforBilling.ToString).VisibleIndex = 0

                DataGridView.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.AmountSelectedforBilling.ToString).OptionsColumn.AllowMove = False
                DataGridView.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.AmountSelectedforBilling.ToString).OptionsColumn.AllowShowHide = False

            End If

            If DataGridView.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.IsSelected.ToString) IsNot Nothing Then

                DataGridView.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.IsSelected.ToString).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                DataGridView.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.IsSelected.ToString).VisibleIndex = 0

                DataGridView.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.IsSelected.ToString).OptionsColumn.AllowMove = False
                DataGridView.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.IsSelected.ToString).OptionsColumn.AllowShowHide = False
                DataGridView.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.IsSelected.ToString).OptionsColumn.ShowInCustomizationForm = False
                DataGridView.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.IsSelected.ToString).Caption = "Selected"

                AddSubItemImageCheckBox(DataGridView, DataGridView.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.IsSelected.ToString))

            End If

        End Sub
        Private Sub LoadBillingStatus()

            Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                _BillingStatus = AdvantageFramework.BillingCommandCenter.GetBillingStatus(BCCDbContext, _BillingCommandCenterID)

            End Using

        End Sub
        Private Sub EnableOrDisableActions()

            Dim ProductionSummary As AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary = Nothing

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                If DataGridViewForm_ProductionSummary.HasOnlyOneSelectedRow Then

                    ProductionSummary = DirectCast(DataGridViewForm_ProductionSummary.CurrentView.GetRow(DataGridViewForm_ProductionSummary.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary)

                    Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        ButtonItemView_BillingHistory.Enabled = AdvantageFramework.BillingCommandCenter.GetBillingHistory(BCCDbContext, ProductionSummary.JobNumber, ProductionSummary.ComponentNumber).Any

                    End Using

                Else

                    ButtonItemView_BillingHistory.Enabled = False

                End If

                ButtonItemView_JobDetails.Enabled = DataGridViewForm_ProductionSummary.HasASelectedRow

                If _BillingStatus IsNot Nothing AndAlso _BillingStatus.IsAssigned.GetValueOrDefault(0) = 1 Then

                    ButtonItemActions_AdvanceBill.Enabled = False
                    ButtonItemActions_BillHold.Enabled = False
                    ButtonItemActions_Export.Enabled = False
                    ButtonItemActions_ManageCoop.Enabled = False
                    ButtonItemActions_ProcessControl.Enabled = False
                    ButtonItemActions_Reconcile.Enabled = False
                    ButtonItemActions_Refresh.Enabled = False
                    ButtonItemActions_Transfer.Enabled = False
                    ButtonItemActions_BillingSelection.Enabled = True

                Else

                    ButtonItemActions_AdvanceBill.Enabled = True
                    ButtonItemActions_BillHold.Enabled = DataGridViewForm_ProductionSummary.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary) _
                                                        .Where(Function(Entity) Entity.BillStatus <> 2 AndAlso
                                                                                Entity.BillStatus <> 6 AndAlso
                                                                                Entity.BillStatus <> 7 AndAlso
                                                                                Entity.BillingUser Is Nothing).Any
                    ButtonItemActions_Export.Enabled = True
                    ButtonItemActions_ManageCoop.Enabled = True
                    ButtonItemActions_ProcessControl.Enabled = True
                    ButtonItemActions_Reconcile.Enabled = AdvantageFramework.Billing.Presentation.GetProductionSummaryReconcileable(DataGridViewForm_ProductionSummary.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary)().ToList).Any
                    ButtonItemActions_Refresh.Enabled = True
                    ButtonItemActions_Transfer.Enabled = DataGridViewForm_ProductionSummary.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary) _
                                                        .Where(Function(Entity) Entity.BillStatus <> 6 AndAlso
                                                                                Entity.BillStatus <> 7 AndAlso
                                                                                Entity.BillingUser Is Nothing).Any
                    ButtonItemActions_BillingSelection.Enabled = DataGridViewForm_ProductionSummary.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary) _
                                                                .Where(Function(Entity) Entity.BillStatus <> 3 AndAlso
                                                                                        Entity.BillStatus <> 4).Any

                End If

            End If

        End Sub
        Private Sub SetColumnDefaultVisibility(ByVal DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView)

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            For Each GridColumn In DataGridView.CurrentView.Columns

                If GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.OfficeDescription.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.CampaignID.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.CampaignCode.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.CampaignDescription.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.DivisionName.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ProductDescription.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.JobNumber.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.JobDescription.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ComponentNumber.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ComponentDescription.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.SalesClassDescription.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.BillingCoopCode.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ScheduleStatus.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ScheduleCompletedDate.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.EstimateNetAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.EstimateMarkupAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.EstimateResaleTax.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.EstimateTotal.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ActualBillableNetAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ActualBillableMarkupAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ActualBillableResaleTax.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ActualBillableTotal.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.BilledNet.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.BilledMarkup.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.BilledResaleTax.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.BilledTotal.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.UnbilledNetAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.UnbilledMarkupAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.UnbilledResaleTax.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.UnbilledTotal.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.AdvanceHours.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.AdvanceQuantity.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.AdvanceBilledNetAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.AdvanceBilledMarkupAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.AdvanceBilledResaleTax.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.AdvanceBilledTotal.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.TotalBilledTax.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.TotalBilled.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.UnbilledAdvanceResaleTax.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.UnbilledAdvanceTotal.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.NonBillableNetAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.NonBillableMarkupAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.FeeResaleTax.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.FeeTotal.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.CampaignComment.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.JobComment.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.JobComponentComment.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.GrossIncome.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.JobMediaDateToBill.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.AccountExecutive.ToString Then

                    GridColumn.Visible = False

                ElseIf GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ReconcileMethod.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ReconcileResult.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.BillingSelectionSelect.ToString Then

                    GridColumn.Visible = False
                    GridColumn.OptionsColumn.ShowInCustomizationForm = False

                End If

            Next

        End Sub
        Private Sub RemoveUnusedColumns()

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            For Each GridColumn In DataGridViewForm_ProductionSummary.CurrentView.Columns

                If GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ReconcileMethod.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ReconcileResult.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.BillingSelectionSelect.ToString Then

                    GridColumn.Visible = False
                    GridColumn.OptionsColumn.ShowInCustomizationForm = False

                End If

            Next

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm(ByVal BaseFormParent As AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm, ByVal BillingCommandCenterID As Integer)

            Dim BillingCommandCenterProductionReviewDialog As AdvantageFramework.Billing.Presentation.BillingCommandCenterProductionReviewDialog = Nothing

            BillingCommandCenterProductionReviewDialog = New AdvantageFramework.Billing.Presentation.BillingCommandCenterProductionReviewDialog(BillingCommandCenterID)

            BillingCommandCenterProductionReviewDialog.SetBaseFormParent(BaseFormParent, BillingCommandCenterProductionReviewDialog)

            BillingCommandCenterProductionReviewDialog.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub BillingCommandCenterProductionReviewDialog_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged

            If Me.Enabled Then

                LoadBillingStatus()

                LoadGrid()

            End If

        End Sub
        Private Sub BillingCommandCenterProductionReviewDialog_FormClosing(sender As Object, e As Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

            If e.CloseReason = Windows.Forms.CloseReason.UserClosing Then

                SaveGridLayout()

            End If

        End Sub
        Private Sub BillingCommandCenterProductionReviewDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            ButtonItemGridOptions_ChooseColumns.Image = AdvantageFramework.My.Resources.ColumnImage
            ButtonItemGridOptions_RestoreDefaults.Image = AdvantageFramework.My.Resources.RestoreDefaultsImage

            ButtonItemActions_AdvanceBill.Image = AdvantageFramework.My.Resources.AdjustAndTransferImage
            ButtonItemActions_AdvanceBill.ImageFixedSize = New System.Drawing.Size(32, 32)

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage
            ButtonItemActions_Transfer.Image = AdvantageFramework.My.Resources.TransferMoneyImage
            ButtonItemActions_BillHold.Image = AdvantageFramework.My.Resources.BillHoldImage
            ButtonItemActions_Reconcile.Image = AdvantageFramework.My.Resources.CheckImage
            ButtonItemActions_BillingSelection.Image = AdvantageFramework.My.Resources.BillSelectImage
            ButtonItemActions_ProcessControl.Image = AdvantageFramework.My.Resources.JobProcessControlImage
            ButtonItemActions_ManageCoop.Image = AdvantageFramework.My.Resources.MaintenanceImage

            ButtonItemView_JobDetails.Image = AdvantageFramework.My.Resources.ViewImage
            ButtonItemView_BillingHistory.Image = AdvantageFramework.My.Resources.BillHistoryImage

            ButtonItemInclude_Contingency.Image = AdvantageFramework.My.Resources.PercentageSmallerImage

            ButtonItemReport_Billing.Image = AdvantageFramework.My.Resources.PrintImage

            DataGridViewForm_ProductionSummary.ShowSelectDeselectAllButtons = True

            DataGridViewForm_ProductionSummary.CurrentView.OptionsLayout.StoreDataSettings = True
            DataGridViewForm_ProductionSummary.CurrentView.OptionsLayout.StoreAppearance = True
            DataGridViewForm_ProductionSummary.CurrentView.OptionsLayout.StoreVisualOptions = True

            DataGridViewForm_ProductionSummary.CurrentView.OptionsLayout.Columns.StoreAllOptions = True
            DataGridViewForm_ProductionSummary.CurrentView.OptionsLayout.Columns.StoreAppearance = True

            _ToolTipController = New DevExpress.Utils.ToolTipController()

            DataGridViewForm_ProductionSummary.GridControl.ToolTipController = _ToolTipController
            DataGridViewForm_ProductionSummary.AddFixedColumnCheckItemsToGridMenu = True

            DataGridViewForm_ProductionSummary.CurrentView.OptionsBehavior.Editable = True

            ButtonItemInclude_Contingency.Checked = False

            RibbonBarOptions_Report.Visible = False

        End Sub
        Private Sub BillingCommandCenterProductionReviewDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            LoadBillingStatus()

            LoadGrid()

            Me.FormAction = WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub _ToolTipController_GetActiveObjectInfo(ByVal sender As Object, ByVal e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs) Handles _ToolTipController.GetActiveObjectInfo

            'objects
            Dim ToolTipControlInfo As DevExpress.Utils.ToolTipControlInfo = Nothing
            Dim GridView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            Dim GridHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = Nothing
            Dim RowID As Integer = 0
            Dim ToolTipText As String = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

            If e.SelectedControl Is DataGridViewForm_ProductionSummary.GridControl Then

                Try

                    GridView = CType(DataGridViewForm_ProductionSummary.GridControl.GetViewAt(e.ControlMousePosition), DevExpress.XtraGrid.Views.Grid.GridView)

                    If GridView IsNot Nothing Then

                        GridHitInfo = GridView.CalcHitInfo(e.ControlMousePosition)

                        If GridHitInfo.InRowCell AndAlso GridHitInfo.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.BillStatus.ToString Then

                            Try

                                RowID = DataGridViewForm_ProductionSummary.CurrentView.GetRowCellValue(GridHitInfo.RowHandle, AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.BillStatus.ToString)

                            Catch ex As Exception

                            End Try

                            If RowID > -1 Then

                                Select Case RowID

                                    Case 1

                                        ToolTipText = "Progress Bill"

                                    Case 2

                                        ToolTipText = "Advance Bill"

                                    Case 3

                                        ToolTipText = "Job on Permanent Bill Hold"

                                    Case 4

                                        ToolTipText = "Job on Temporary Bill Hold"

                                    Case 5

                                        ToolTipText = "Job Details on Hold"

                                    Case 6

                                        ToolTipText = "Reconciled - Select for billing and process"

                                    Case 7

                                        ToolTipText = "Final Reconciled w/Pending Advance Bill"

                                End Select

                            End If

                        ElseIf GridHitInfo.InRowCell Then

                            If _ObjectTypePropertyDescriptors Is Nothing Then

                                _ObjectTypePropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary)).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList()

                            End If

                            Try

                                PropertyDescriptor = (From [Property] In _ObjectTypePropertyDescriptors
                                                      Where [Property].Name = GridHitInfo.Column.FieldName
                                                      Select [Property]).SingleOrDefault

                            Catch ex As Exception
                                PropertyDescriptor = Nothing
                            End Try

                            If PropertyDescriptor IsNot Nothing AndAlso PropertyDescriptor.PropertyType Is GetType(String) Then

                                ToolTipText = DataGridViewForm_ProductionSummary.CurrentView.GetRowCellValue(GridHitInfo.RowHandle, GridHitInfo.Column.FieldName)

                            End If

                        End If

                        If String.IsNullOrEmpty(ToolTipText) = False Then

                            ToolTipControlInfo = New DevExpress.Utils.ToolTipControlInfo(RowID, ToolTipText)

                        End If

                    End If

                Catch ex As Exception

                Finally
                    e.Info = ToolTipControlInfo
                End Try

            End If

        End Sub
        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            Me.Close()

        End Sub
        Private Sub ButtonItemActions_AdvanceBillPercentToQuote_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_AdvanceBillPercentToQuote.Click

            Dim AdvanceBillPercentToQuote As AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillPercentToQuote = Nothing
            Dim ProductionSummaryList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary) = Nothing
            Dim AdvanceBillFinalReconciledAndBilled As Boolean = False
            Dim JobNumber As Integer = Nothing
            Dim JobComponentNumber As Short = Nothing
            Dim EstimateApproval As AdvantageFramework.Database.Views.EstimateApproval = Nothing
            Dim JobComponentFunctionDetails As IEnumerable(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail) = Nothing
            Dim AdvanceBillingItemList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem) = Nothing
            Dim Saved As Boolean = False
            Dim AdvanceBillHasMultipleUnbilledFunctions As Boolean = False
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing

            AdvanceBillPercentToQuote = New AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillPercentToQuote(100, False)

            ProductionSummaryList = (From Entity In DataGridViewForm_ProductionSummary.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary).ToList
                                     Where Entity.BillingUser Is Nothing AndAlso
                                           (Entity.BillStatus = 1 OrElse
                                            Entity.BillStatus = 2)
                                     Select Entity).ToList

            If ProductionSummaryList.Count > 0 AndAlso AdvantageFramework.WinForm.Presentation.GenericPropertyGridDialog.ShowFormDialog("Advance Bill % to Quote", AdvanceBillPercentToQuote, False) = Windows.Forms.DialogResult.OK Then

                Me.ShowWaitForm("Saving...")

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        DbContext.Database.Connection.Open()

                        For Each ProductionSummary In ProductionSummaryList

                            JobNumber = ProductionSummary.JobNumber
                            JobComponentNumber = ProductionSummary.ComponentNumber

                            AdvanceBillFinalReconciledAndBilled = (From AB In AdvantageFramework.Database.Procedures.AdvanceBilling.Load(DbContext)
                                                                   Where AB.JobNumber = JobNumber AndAlso
                                                                                 AB.JobComponentNumber = JobComponentNumber AndAlso
                                                                                 (AB.ARInvoiceIsVoided Is Nothing OrElse AB.ARInvoiceIsVoided = 0) AndAlso
                                                                                 AB.ARInvoiceNumber IsNot Nothing AndAlso
                                                                                 AB.FinalAdvanceBillingID IsNot Nothing
                                                                   Select AB).Any

                            AdvanceBillHasMultipleUnbilledFunctions = (From Entity In AdvantageFramework.Database.Procedures.AdvanceBilling.LoadUnbilledByJobNumberAndJobComponentNumberAndFlagIsOneOrTwo(DbContext, JobNumber, JobComponentNumber).ToList
                                                                       Group By Entity.FunctionCode Into ABFGroup = Group
                                                                       Select FunctionCode, TotalRows = ABFGroup.Count).Where(Function(AB) AB.TotalRows > 1).Any

                            If AdvanceBillFinalReconciledAndBilled = False AndAlso AdvanceBillHasMultipleUnbilledFunctions = False AndAlso
                                            AdvantageFramework.BillingCommandCenter.GetReconcileStatus(BCCDbContext, JobNumber, JobComponentNumber) = 0 Then

                                EstimateApproval = (From EA In AdvantageFramework.Database.Procedures.EstimateApprovalView.Load(DbContext)
                                                    Where EA.JobNumber = JobNumber AndAlso
                                                                  EA.JobComponentNumber = JobComponentNumber
                                                    Select EA).FirstOrDefault

                                If EstimateApproval IsNot Nothing Then

                                    JobComponentFunctionDetails = AdvantageFramework.BillingCommandCenter.GetProductionSummaryByFunction(BCCDbContext,
                                                _BillingCommandCenterID, ButtonItemInclude_Contingency.Checked, JobNumber, JobComponentNumber).Where(Function(JCF) JCF.FunctionType <> "C").ToList

                                    If JobComponentFunctionDetails.Count > 0 Then

                                        Try

                                            DbTransaction = DbContext.Database.BeginTransaction

                                            AdvanceBillingItemList = New Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem)

                                            AdvanceBillingItemList.AddRange(AdvantageFramework.BillingCommandCenter.GetAdvanceBillingItems(DbContext, JobNumber, JobComponentNumber))

                                            AdvantageFramework.BillingCommandCenter.AddAdvanceBillingRows(DbContext, EstimateApproval, AdvanceBillPercentToQuote, JobComponentFunctionDetails, AdvanceBillingItemList, Session, ButtonItemInclude_Contingency.Checked)

                                            AdvantageFramework.BillingCommandCenter.SaveAdvanceBilling(DbContext, JobComponentFunctionDetails.FirstOrDefault.JobNumber, JobComponentFunctionDetails.FirstOrDefault.ComponentNumber, AdvanceBillingItemList, _BillingCommandCenterID, AdvanceBillPercentToQuote.PercentToQuote)

                                            DbTransaction.Commit()

                                        Catch ex As Exception
                                            DbTransaction.Rollback()
                                            AdvantageFramework.WinForm.MessageBox.Show("Failed trying to save data to the database. Please contact software support." & vbCrLf & ex.Message)
                                        Finally
                                            DbTransaction.Dispose()
                                        End Try

                                    End If

                                End If

                            End If

                        Next

                        Saved = True

                    End Using

                End Using

                If Saved Then

                    LoadGrid()

                End If

                Me.CloseWaitForm()

            ElseIf ProductionSummaryList.Count = 0 Then

                AdvantageFramework.WinForm.MessageBox.Show("None of the selected job/components qualify.")

            End If

        End Sub
        Private Sub ButtonItemActions_AdvanceBillSetJobAsAdvanceBill_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_AdvanceBillSetJobAsAdvanceBill.Click

            Dim ProductionSummaryList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary) = Nothing
            'Dim OfficeList As Generic.List(Of AdvantageFramework.Database.Entities.Office) = Nothing
            'Dim ABIncomeFlag As Short = Nothing
            Dim JobNumber As Integer = Nothing
            Dim JobComponentNumber As Short = Nothing
            Dim AdvanceBillFinalReconciledAndBilled As Boolean = False
            Dim AdvanceBillHasMultipleUnbilledFunctions As Boolean = False
            Dim AdvanceBillRevenueRecognition As AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillRevenueRecognition = Nothing

            AdvanceBillRevenueRecognition = New BillingCommandCenter.Classes.AdvanceBillRevenueRecognition(Database.Entities.Methods.ProductionAdvancedBillingIncome.InitialBilling)

            ProductionSummaryList = (From PS In DataGridViewForm_ProductionSummary.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary)
                                     Where PS.BillingUser Is Nothing AndAlso
                                           PS.BillStatus = 1
                                     Select PS).ToList

            If ProductionSummaryList.Count = 0 Then

                AdvantageFramework.WinForm.MessageBox.Show("None of the selected job/components qualify.")

            ElseIf AdvantageFramework.WinForm.Presentation.GenericPropertyGridDialog.ShowFormDialog("Advance Bill Income Method", AdvanceBillRevenueRecognition, False) = Windows.Forms.DialogResult.OK Then

                If AdvantageFramework.WinForm.MessageBox.Show("Warning - This change cannot be reversed once processed.  Are you sure you want to continue?", WinForm.MessageBox.MessageBoxButtons.YesNo,, Windows.Forms.MessageBoxIcon.Warning, Windows.Forms.MessageBoxDefaultButton.Button2) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    Me.ShowWaitForm("Updating...")

                    Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                            'OfficeList = AdvantageFramework.Database.Procedures.Office.Load(DbContext).ToList

                            For Each ProductionSummary In ProductionSummaryList

                                JobNumber = ProductionSummary.JobNumber
                                JobComponentNumber = ProductionSummary.ComponentNumber

                                AdvanceBillFinalReconciledAndBilled = (From AB In AdvantageFramework.Database.Procedures.AdvanceBilling.Load(DbContext)
                                                                       Where AB.JobNumber = JobNumber AndAlso
                                                                             AB.JobComponentNumber = JobComponentNumber AndAlso
                                                                             (AB.ARInvoiceIsVoided Is Nothing OrElse AB.ARInvoiceIsVoided = 0) AndAlso
                                                                             AB.ARInvoiceNumber IsNot Nothing AndAlso
                                                                             AB.FinalAdvanceBillingID IsNot Nothing
                                                                       Select AB).Any

                                AdvanceBillHasMultipleUnbilledFunctions = (From Entity In AdvantageFramework.Database.Procedures.AdvanceBilling.LoadUnbilledByJobNumberAndJobComponentNumberAndFlagIsOneOrTwo(DbContext, JobNumber, JobComponentNumber).ToList
                                                                           Group By Entity.FunctionCode Into ABFGroup = Group
                                                                           Select FunctionCode, TotalRows = ABFGroup.Count).Where(Function(AB) AB.TotalRows > 1).Any

                                If AdvanceBillFinalReconciledAndBilled = False AndAlso AdvanceBillHasMultipleUnbilledFunctions = False AndAlso
                                        AdvantageFramework.BillingCommandCenter.GetReconcileStatus(BCCDbContext, JobNumber, JobComponentNumber) = 0 Then

                                    'ABIncomeFlag = OfficeList.Where(Function(O) O.Code = ProductionSummary.OfficeCode).FirstOrDefault.ProductionAdvancedBillingIncome.GetValueOrDefault(0)

                                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.JOB_COMPONENT SET AB_FLAG = 2, PRD_AB_INCOME = {2} WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1}", ProductionSummary.JobNumber, ProductionSummary.ComponentNumber, AdvanceBillRevenueRecognition.IncomeMethod))

                                    AdvantageFramework.BillingCommandCenter.SetAdvanceBillFlagInDetailTables(DbContext, ProductionSummary.JobNumber, ProductionSummary.ComponentNumber)

                                End If

                            Next

                        End Using

                    End Using

                    LoadGrid()

                    Me.CloseWaitForm()

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_BillHold_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_BillHold.Click

            Dim ProductionSummaryList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary) = Nothing

            ProductionSummaryList = (From Entity In DataGridViewForm_ProductionSummary.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary).ToList
                                     Where Entity.BillStatus <> 2 AndAlso
                                           Entity.BillStatus <> 6 AndAlso
                                           Entity.BillStatus <> 7 AndAlso
                                           Entity.BillingUser Is Nothing
                                     Select Entity).ToList

            AdvantageFramework.Billing.Presentation.BillingCommandCenterProductionBillHoldDialog.ShowFormDialog(_BillingCommandCenterID, If(ButtonItemInclude_Contingency.Checked, 1, 0), ProductionSummaryList)

            LoadGrid()

        End Sub
        Private Sub ButtonItemActions_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Refresh.Click

            LoadGrid()

        End Sub
        Private Sub ButtonItemActions_Transfer_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Transfer.Click

            'objects
            Dim ProductionSummaryList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary) = Nothing
            Dim AccountPayableProductionItemList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem) = Nothing
            Dim EmployeeTimeItemList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem) = Nothing
            Dim IncomeOnlyItemList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem) = Nothing
            Dim BillingCommandCenter As AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter = Nothing
            'Dim ShowTransferFunctionTo As Boolean = False

            AccountPayableProductionItemList = New Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem)
            EmployeeTimeItemList = New Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem)
            IncomeOnlyItemList = New Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem)

            ProductionSummaryList = (From PS In DataGridViewForm_ProductionSummary.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary)
                                     Where PS.BillStatus <> 6 AndAlso
                                           PS.BillStatus <> 7 AndAlso
                                           PS.BillingUser Is Nothing
                                     Select PS).ToList

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    BillingCommandCenter = AdvantageFramework.BillingCommandCenter.Database.Procedures.BillingCommandCenter.LoadByID(BCCDbContext, _BillingCommandCenterID)

                    If BillingCommandCenter IsNot Nothing AndAlso BillingCommandCenter.IncomeOnlyDateCutoff IsNot Nothing AndAlso BillingCommandCenter.EmployeeTimeDateCutoff IsNot Nothing AndAlso BillingCommandCenter.APPostPeriodCodeCutoff Then

                        For Each ProductionSummary In ProductionSummaryList

                            AccountPayableProductionItemList.AddRange(AdvantageFramework.BillingCommandCenter.GetAccountPayableProductionItems(BCCDbContext, ProductionSummary.JobNumber, ProductionSummary.ComponentNumber, Nothing, BillingCommandCenter.APPostPeriodCodeCutoff, AdvantageFramework.BillingCommandCenter.Methods.ProductionSelectFor.Transfer, False))

                            EmployeeTimeItemList.AddRange(AdvantageFramework.BillingCommandCenter.GetEmployeeTimeItems(BCCDbContext, ProductionSummary.JobNumber, ProductionSummary.ComponentNumber, Nothing, BillingCommandCenter.EmployeeTimeDateCutoff, False))

                            IncomeOnlyItemList.AddRange(AdvantageFramework.BillingCommandCenter.GetIncomeOnlyItems(BCCDbContext, ProductionSummary.JobNumber, ProductionSummary.ComponentNumber, Nothing, BillingCommandCenter.IncomeOnlyDateCutoff, False, AdvantageFramework.BillingCommandCenter.IncomeOnlySelectFor.Transfer))

                        Next

                    End If

                End Using

            End Using

            If AccountPayableProductionItemList.Count = 0 AndAlso EmployeeTimeItemList.Count = 0 AndAlso IncomeOnlyItemList.Count = 0 Then

                AdvantageFramework.WinForm.MessageBox.Show("Nothing to transfer.")

            Else

                'If (AccountPayableProductionItemList.Count = 0 AndAlso EmployeeTimeItemList.Count = 0) OrElse _
                '        (AccountPayableProductionItemList.Count = 0 AndAlso IncomeOnlyItemList.Count = 0) OrElse _
                '        (EmployeeTimeItemList.Count = 0 AndAlso IncomeOnlyItemList.Count = 0) Then

                '    ShowTransferFunctionTo = True

                'End If

                If AdvantageFramework.Billing.Presentation.TransferAllItemsDialog.ShowFormDialog(EmployeeTimeItemList, AccountPayableProductionItemList, IncomeOnlyItemList, False, ProductionSummaryList.Count > 1, _BillingCommandCenterID) = Windows.Forms.DialogResult.OK Then

                    AdvantageFramework.WinForm.MessageBox.Show("Transfer complete.")

                    LoadGrid()

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Reconcile_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Reconcile.Click

            Dim ProductionSummaryList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary) = Nothing

            ProductionSummaryList = AdvantageFramework.Billing.Presentation.GetProductionSummaryReconcileable(DataGridViewForm_ProductionSummary.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary)().ToList)

            If ProductionSummaryList.Count = 0 Then

                AdvantageFramework.WinForm.MessageBox.Show("No rows meet criteria.")

            Else

                AdvantageFramework.Billing.Presentation.BillingCommandCenterProductionReconcileDialog.ShowFormDialog(_BillingCommandCenterID, If(ButtonItemInclude_Contingency.Checked, 1, 0), ProductionSummaryList)

                LoadGrid()

            End If

        End Sub
        Private Sub ButtonItemActions_BillingSelection_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_BillingSelection.Click

            Dim ProductionSummaryList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary) = Nothing
            Dim IsBatchFinished As Boolean = False

            ProductionSummaryList = (From Entity In DataGridViewForm_ProductionSummary.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary).ToList
                                     Where Entity.BillStatus <> 3 AndAlso
                                           Entity.BillStatus <> 4
                                     Select Entity).ToList

            SaveGridLayout()

            AdvantageFramework.Billing.Presentation.BillingCommandCenterProductionBillingSelectionDialog.ShowFormDialog(_BillingCommandCenterID, ProductionSummaryList, IsBatchFinished)

            If IsBatchFinished Then

                Me.Close()

            Else

                LoadBillingStatus()

                LoadGrid()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemActions_Export_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Export.Click
            'objects
            Dim ProductionSummaryList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary) = Nothing
            Dim LayoutLoaded As Boolean = False

            ProductionSummaryList = DataGridViewForm_ProductionSummary.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary)().ToList

            SaveGridLayout()

            LayoutLoaded = AdvantageFramework.WinForm.Presentation.Controls.LoadDataGridViewLayout(Session, DataGridViewForm_Export, Database.Entities.GridAdvantageType.BillingCommandCenterProductionReview)

            Try

                DataGridViewForm_Export.DataSource = ProductionSummaryList

            Catch ex As Exception

            End Try

            If LayoutLoaded Then

                AdvantageFramework.WinForm.Presentation.Controls.SortGridViewBySortedColumns(DataGridViewForm_Export)

            End If

            AddFixedLeftColumns(DataGridViewForm_Export)

            'https://www.devexpress.com/Support/Center/Question/Details/Q383062
            DataGridViewForm_Export.CurrentView.ClearDocument()
            DevExpress.Utils.Paint.XPaint.ForceGDIPlusPaint()
            DataGridViewForm_Export.CurrentView.OptionsView.ColumnAutoWidth = False
            DataGridViewForm_Export.CurrentView.BestFitColumns()
            DataGridViewForm_Export.CurrentView.OptionsPrint.AutoWidth = False
            DevExpress.Utils.Paint.XPaint.ForceAPIPaint()

            DataGridViewForm_Export.Print(DefaultLookAndFeel.LookAndFeel, "Production Review", UseLandscape:=True)

        End Sub
        Private Sub ButtonItemActions_ManageCoop_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_ManageCoop.Click

            Dim Jobs As IEnumerable(Of Integer) = Nothing

            Jobs = (From PS In DataGridViewForm_ProductionSummary.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary)().ToList
                    Select PS.JobNumber).ToList

            AdvantageFramework.Billing.Presentation.BillingCommandCenterProductionManageCoopDialog.ShowDialog(Jobs, _BillingCommandCenterID)

            LoadGrid()

        End Sub
        Private Sub ButtonItemActions_ProcessControl_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_ProcessControl.Click

            Dim ProductionSummaryList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary) = Nothing

            ProductionSummaryList = DataGridViewForm_ProductionSummary.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary).ToList

            AdvantageFramework.Billing.Presentation.BillingCommandCenterProductionProcessControlDialog.ShowFormDialog(_BillingCommandCenterID, If(ButtonItemInclude_Contingency.Checked, 1, 0), ProductionSummaryList)

            LoadGrid()

        End Sub
        Private Sub ButtonItemView_JobDetails_Click(sender As Object, e As EventArgs) Handles ButtonItemView_JobDetails.Click

            Dim ProductionSummaryList As IEnumerable(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary) = Nothing

            ProductionSummaryList = DataGridViewForm_ProductionSummary.GetAllSelectedRowsDataBoundItems().OfType(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary)().ToList

            AdvantageFramework.Billing.Presentation.BillingCommandCenterJobDetailDialog.ShowForm(Me, ProductionSummaryList, _BillingCommandCenterID, If(ButtonItemInclude_Contingency.Checked, 1, 0))

        End Sub
        Private Sub DataGridViewForm_ProductionSummary_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_ProductionSummary.CellValueChangedEvent

            Dim ProductionSummary As AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary = Nothing

            ProductionSummary = DirectCast(DataGridViewForm_ProductionSummary.CurrentView.GetRow(DataGridViewForm_ProductionSummary.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary)

            If e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.BillingApprovalHeaderClientComment.ToString Then

                AdvantageFramework.BillingCommandCenter.UpdateBillingApprovalHeaderClientComment(Session, e.Value, ProductionSummary.BillingApprovalHeaderID)

                For Each PSUpdate In DataGridViewForm_ProductionSummary.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary)().Where(Function(PS) PS.BillingApprovalHeaderID IsNot Nothing AndAlso PS.BillingApprovalHeaderID = ProductionSummary.BillingApprovalHeaderID).ToList

                    PSUpdate.BillingApprovalHeaderClientComment = e.Value

                Next

            ElseIf e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.CampaignComment.ToString Then

                AdvantageFramework.BillingCommandCenter.UpdateCampaignComment(Session, e.Value, ProductionSummary.CampaignID)

                For Each PSUpdate In DataGridViewForm_ProductionSummary.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary)().Where(Function(PS) PS.CampaignID = ProductionSummary.CampaignID).ToList

                    PSUpdate.CampaignComment = e.Value

                Next

            ElseIf e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.JobComment.ToString Then

                AdvantageFramework.BillingCommandCenter.UpdateJobComment(Session, e.Value, ProductionSummary.JobNumber)

                For Each PSUpdate In DataGridViewForm_ProductionSummary.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary)().Where(Function(PS) PS.JobNumber = ProductionSummary.JobNumber).ToList

                    PSUpdate.JobComment = e.Value

                Next

            ElseIf e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.JobComponentComment.ToString Then

                AdvantageFramework.BillingCommandCenter.UpdateJobComponentComment(Session, e.Value, ProductionSummary.JobNumber, ProductionSummary.ComponentNumber)

            ElseIf e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ClientPO.ToString Then

                AdvantageFramework.BillingCommandCenter.UpdateJobComponentClientPO(Session, e.Value, ProductionSummary.JobNumber, ProductionSummary.ComponentNumber)

            End If

        End Sub
        Private Sub DataGridViewForm_ProductionSummary_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_ProductionSummary.DataSourceChangedEvent

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            If Not Me.IsFormClosing Then

                DataGridViewForm_ProductionSummary.CurrentView.OptionsView.ShowFooter = True

                DataGridViewForm_ProductionSummary.CurrentView.OptionsView.EnableAppearanceOddRow = True
                DataGridViewForm_ProductionSummary.CurrentView.Appearance.OddRow.BackColor = Drawing.Color.FromArgb(240, 240, 240)

                For Each GridColumn In DataGridViewForm_ProductionSummary.Columns

                    If GridColumn.ColumnType Is GetType(System.Decimal) OrElse
                            GridColumn.ColumnType Is GetType(System.Nullable(Of Decimal)) Then

                        If GridColumn.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.BilledOfEstimate.ToString Then

                            AdvantageFramework.Billing.Presentation.SetColumnAsSumColumn(DataGridViewForm_ProductionSummary, GridColumn.FieldName)

                        End If

                    End If

                Next

            End If

        End Sub
        Private Sub DataGridViewForm_ProductionSummary_HideCustomizationFormEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_ProductionSummary.HideCustomizationFormEvent

            If ButtonItemGridOptions_ChooseColumns.Checked Then

                ButtonItemGridOptions_ChooseColumns.Checked = False

            End If

        End Sub
        Private Sub DataGridViewForm_ProductionSummary_PopupMenuShowingEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles DataGridViewForm_ProductionSummary.PopupMenuShowingEvent

            If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Column Then

                If e.HitInfo.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.IsSelected.ToString OrElse
                        e.HitInfo.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.AmountSelectedforBilling.ToString Then

                    For Each MenuItem In e.Menu.Items.OfType(Of DevExpress.Utils.Menu.DXMenuItem)()

                        MenuItem.Visible = False

                    Next

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_ProductionSummary_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_ProductionSummary.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_ProductionSummary_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewForm_ProductionSummary.ShowingEditorEvent

            If DataGridViewForm_ProductionSummary.CurrentView.FocusedColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.BillingApprovalHeaderClientComment.ToString OrElse
                    DataGridViewForm_ProductionSummary.CurrentView.FocusedColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.BillingApprovalHeaderComment.ToString Then

                If DirectCast(DataGridViewForm_ProductionSummary.CurrentView.GetRow(DataGridViewForm_ProductionSummary.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary).BillingApprovalHeaderID Is Nothing Then

                    e.Cancel = True

                End If

            ElseIf DataGridViewForm_ProductionSummary.CurrentView.FocusedColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.CampaignComment.ToString Then

                If DirectCast(DataGridViewForm_ProductionSummary.CurrentView.GetRow(DataGridViewForm_ProductionSummary.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary).CampaignID Is Nothing Then

                    e.Cancel = True

                End If

            ElseIf DataGridViewForm_ProductionSummary.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.JobBillComment.ToString AndAlso
                    DataGridViewForm_ProductionSummary.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.JobComment.ToString AndAlso
                    DataGridViewForm_ProductionSummary.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.JobComponentComment.ToString AndAlso
                    DataGridViewForm_ProductionSummary.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ClientPO.ToString Then

                e.Cancel = True

            End If

        End Sub
        Private Sub ButtonItemGridOptions_ChooseColumns_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemGridOptions_ChooseColumns.CheckedChanged

            Try

                If ButtonItemGridOptions_ChooseColumns.Checked Then

                    If DataGridViewForm_ProductionSummary.CurrentView.CustomizationForm Is Nothing Then

                        DataGridViewForm_ProductionSummary.CurrentView.ShowCustomization()

                    End If

                Else

                    If DataGridViewForm_ProductionSummary.CurrentView.CustomizationForm IsNot Nothing Then

                        DataGridViewForm_ProductionSummary.CurrentView.DestroyCustomization()

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ButtonItemGridOptions_RestoreDefaults_Click(sender As Object, e As EventArgs) Handles ButtonItemGridOptions_RestoreDefaults.Click

            Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                AdvantageFramework.Database.Procedures.GridAdvantage.Delete(DataContext, AdvantageFramework.Database.Entities.GridAdvantageType.BillingCommandCenterProductionReview, Session.UserCode)

            End Using

            DataGridViewForm_ProductionSummary.ClearDatasource()

            LoadGrid()

        End Sub
        Private Sub ButtonItemInclude_Contingency_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemInclude_Contingency.CheckedChanged

            If Me.FormShown Then

                LoadGrid()

            End If

        End Sub
        Private Sub ButtonItemView_BillingHistory_Click(sender As Object, e As EventArgs) Handles ButtonItemView_BillingHistory.Click

            'objects
            Dim ProductionSummary As AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary = Nothing

            If DataGridViewForm_ProductionSummary.HasOnlyOneSelectedRow Then

                ProductionSummary = DataGridViewForm_ProductionSummary.CurrentView.GetRow(DataGridViewForm_ProductionSummary.CurrentView.FocusedRowHandle)

                If ProductionSummary IsNot Nothing Then

                    AdvantageFramework.Billing.Presentation.BillingCommandCenterMediaBillingHistoryDialog.ShowFormDialog(ProductionSummary.JobNumber, ProductionSummary.ComponentNumber, ProductionSummary.JobDescription, ProductionSummary.ComponentDescription)

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_ProductionSummary_ShownEditorEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_ProductionSummary.ShownEditorEvent

            Dim TextEdit As DevExpress.XtraEditors.TextEdit = Nothing

            If DataGridViewForm_ProductionSummary.CurrentView.FocusedRowHandle >= 0 AndAlso DataGridViewForm_ProductionSummary.CurrentView.FocusedColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ClientPO.ToString Then

                TextEdit = DataGridViewForm_ProductionSummary.CurrentView.ActiveEditor

                TextEdit.Properties.MaxLength = 40

            End If

        End Sub
        Private Sub DataGridViewForm_ProductionSummary_ShowCustomizationFormEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_ProductionSummary.ShowCustomizationFormEvent

            For Each GridColumn In DataGridViewForm_ProductionSummary.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                GridColumn.Caption = GridColumn.Caption.Replace(vbCrLf, " ")

            Next

        End Sub

#End Region

#End Region

    End Class

End Namespace