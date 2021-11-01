Namespace Billing.Presentation

    Public Class BillingCommandCenterProductionReconcileDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _BillingCommandCenterID As Integer = 0
        Private _IncludeContingency As Short = 0
        Private _ProductionSummaryList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary) = Nothing
        Private _ProductionSummaryListToProcess As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary) = Nothing
        Private WithEvents _ToolTipController As DevExpress.Utils.ToolTipController = Nothing
        Private _ObjectTypePropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal BillingCommandCenterID As Integer, ByVal IncludeContingency As Short, ByVal ProductionSummaryList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary))

            ' This call is required by the designer.
            InitializeComponent()

            _BillingCommandCenterID = BillingCommandCenterID
            _IncludeContingency = IncludeContingency
            _ProductionSummaryList = ProductionSummaryList

            For Each ProductionSummary In _ProductionSummaryList

                ProductionSummary.ReconcileResult = ""

            Next

        End Sub
        Private Sub LoadGrid()

            'objects
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim LayoutLoaded As Boolean = False
            Dim AdvanceBillings As Generic.List(Of AdvantageFramework.Database.Entities.AdvanceBilling) = Nothing

            BindingSource = DataGridViewForm_ProductionReconcileRecognize.DataSource

            If BindingSource IsNot Nothing AndAlso BindingSource.DataSource IsNot Nothing Then

                AdvantageFramework.WinForm.Presentation.Controls.SaveDataGridViewLayout(Session, DataGridViewForm_ProductionReconcileRecognize, AdvantageFramework.Database.Entities.GridAdvantageType.BillingCommandCenterReconcileRecognize)

            End If

            DataGridViewForm_ProductionReconcileRecognize.SetBookmarkColumnIndex(-1)
            DataGridViewForm_ProductionReconcileRecognize.ClearGridCustomization()
            DataGridViewForm_ProductionReconcileRecognize.ClearDatasource(New Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary))
            DataGridViewForm_ProductionReconcileRecognize.ItemDescription = "Reconciliation Item(s)"

            LayoutLoaded = AdvantageFramework.WinForm.Presentation.Controls.LoadDataGridViewLayout(Session, DataGridViewForm_ProductionReconcileRecognize, Database.Entities.GridAdvantageType.BillingCommandCenterReconcileRecognize)

            _ProductionSummaryListToProcess = Nothing

            _ProductionSummaryListToProcess = _ProductionSummaryList

            DataGridViewForm_ProductionReconcileRecognize.DataSource = _ProductionSummaryListToProcess

            If Not LayoutLoaded Then

                SetColumnDefaultVisibility()

                DataGridViewForm_ProductionReconcileRecognize.CurrentView.ClearSorting()
                DataGridViewForm_ProductionReconcileRecognize.CurrentView.BeginSort()
                DataGridViewForm_ProductionReconcileRecognize.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.JobNumber.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Descending
                DataGridViewForm_ProductionReconcileRecognize.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ComponentNumber.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                DataGridViewForm_ProductionReconcileRecognize.CurrentView.EndSort()

            Else

                AdvantageFramework.WinForm.Presentation.Controls.SortGridViewBySortedColumns(DataGridViewForm_ProductionReconcileRecognize)

            End If

            If DataGridViewForm_ProductionReconcileRecognize.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.BilledAmount.ToString) IsNot Nothing Then

                DataGridViewForm_ProductionReconcileRecognize.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.BilledAmount.ToString).Caption = "Billed/Reconciled" & vbCrLf & "Amount"

            End If

            If DataGridViewForm_ProductionReconcileRecognize.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.UnbilledAmount.ToString) IsNot Nothing Then

                DataGridViewForm_ProductionReconcileRecognize.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.UnbilledAmount.ToString).Caption = "Unbilled/Unreconciled" & vbCrLf & "Amount"

            End If

            DataGridViewForm_ProductionReconcileRecognize.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True

            If DataGridViewForm_ProductionReconcileRecognize.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.BillStatus.ToString) IsNot Nothing Then

                AddSubItemImageComboBox(DataGridViewForm_ProductionReconcileRecognize, DataGridViewForm_ProductionReconcileRecognize.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.BillStatus.ToString))

            End If

            If DataGridViewForm_ProductionReconcileRecognize.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ReconcileResult.ToString) IsNot Nothing Then

                DataGridViewForm_ProductionReconcileRecognize.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ReconcileResult.ToString).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                DataGridViewForm_ProductionReconcileRecognize.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ReconcileResult.ToString).VisibleIndex = 0

                DataGridViewForm_ProductionReconcileRecognize.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ReconcileResult.ToString).OptionsColumn.AllowMove = False
                DataGridViewForm_ProductionReconcileRecognize.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ReconcileResult.ToString).OptionsColumn.AllowShowHide = False

            End If

            If DataGridViewForm_ProductionReconcileRecognize.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ReconcileMethod.ToString) IsNot Nothing Then

                DataGridViewForm_ProductionReconcileRecognize.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ReconcileMethod.ToString).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                DataGridViewForm_ProductionReconcileRecognize.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ReconcileMethod.ToString).VisibleIndex = 0

                DataGridViewForm_ProductionReconcileRecognize.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ReconcileMethod.ToString).OptionsColumn.AllowMove = False
                DataGridViewForm_ProductionReconcileRecognize.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ReconcileMethod.ToString).OptionsColumn.AllowShowHide = False

            End If

            If DataGridViewForm_ProductionReconcileRecognize.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.AmountToReconcile.ToString) IsNot Nothing Then

                DataGridViewForm_ProductionReconcileRecognize.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.AmountToReconcile.ToString).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                DataGridViewForm_ProductionReconcileRecognize.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.AmountToReconcile.ToString).VisibleIndex = 0

                DataGridViewForm_ProductionReconcileRecognize.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.AmountToReconcile.ToString).OptionsColumn.AllowMove = False
                DataGridViewForm_ProductionReconcileRecognize.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.AmountToReconcile.ToString).OptionsColumn.AllowShowHide = False

            End If

            If DataGridViewForm_ProductionReconcileRecognize.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ReconcileStatus.ToString) IsNot Nothing Then

                DataGridViewForm_ProductionReconcileRecognize.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ReconcileStatus.ToString).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                DataGridViewForm_ProductionReconcileRecognize.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ReconcileStatus.ToString).VisibleIndex = 0

                DataGridViewForm_ProductionReconcileRecognize.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ReconcileStatus.ToString).OptionsColumn.AllowMove = False
                DataGridViewForm_ProductionReconcileRecognize.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ReconcileStatus.ToString).OptionsColumn.AllowShowHide = False

            End If

            If DataGridViewForm_ProductionReconcileRecognize.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ReconcileStatus.ToString) IsNot Nothing Then

                AddSubItemGridLookupEdit(Session, DataGridViewForm_ProductionReconcileRecognize, DataGridViewForm_ProductionReconcileRecognize.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ReconcileStatus.ToString), GetType(String), GetType(AdvantageFramework.BillingCommandCenter.ProductionReconcileStatus))

            End If

            DataGridViewForm_ProductionReconcileRecognize.CurrentView.OptionsView.ShowFooter = True

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                For Each ProductionSummary In DataGridViewForm_ProductionReconcileRecognize.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary)()

                    AdvanceBillings = AdvantageFramework.Database.Procedures.AdvanceBilling.LoadAllUnbilledByJobNumberAndJobComponentNumber(DbContext, ProductionSummary.JobNumber, ProductionSummary.ComponentNumber).ToList

                    If AdvanceBillings.Where(Function(AB) AB.AdvanceBillFlag = 6).Any Then

                        ProductionSummary.ReconcileResult = "Interim Reconciled"

                        ProductionSummary.AmountToReconcile = AdvanceBillings.Sum(Function(AB) AB.NetAmount.GetValueOrDefault(0) + AB.ExtendedNonResaleTax.GetValueOrDefault(0) + AB.ExtendedMarkupAmount.GetValueOrDefault(0))

                    ElseIf AdvanceBillings.Where(Function(AB) AB.FinalAdvanceBillingID IsNot Nothing).Any Then

                        ProductionSummary.ReconcileResult = AdvanceBillings.Where(Function(AB) AB.FinalAdvanceBillingID IsNot Nothing).OrderByDescending(Function(AB) AB.MethodDescription).FirstOrDefault.MethodDescription

                    End If

                Next

            End Using

            If Not LayoutLoaded Then

                DataGridViewForm_ProductionReconcileRecognize.CurrentView.BestFitColumns()

            End If

            DataGridViewForm_ProductionReconcileRecognize.OptionsMenu.EnableColumnMenu = True

        End Sub
        Private Sub AddSubItemGridLookupEdit(ByVal Session As AdvantageFramework.Security.Session, ByVal DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView,
                                             ByVal GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByVal ValueType As System.Type, ByVal EnumType As System.Type)

            'objects
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl = Nothing

            Try

                SubItemGridLookUpEditControl = New AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl

                SubItemGridLookUpEditControl.ValueType = ValueType
                SubItemGridLookUpEditControl.EnumType = EnumType

                SubItemGridLookUpEditControl.Session = Session
                SubItemGridLookUpEditControl.ControlType = WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.ProductionReconcileStatus

            Catch ex As Exception
                SubItemGridLookUpEditControl = Nothing
            End Try

            If SubItemGridLookUpEditControl IsNot Nothing Then

                SubItemGridLookUpEditControl.ExtraComboBoxItem = WinForm.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.None
                SubItemGridLookUpEditControl.LoadDefaultDataSourceView()

                DataGridView.GridControl.RepositoryItems.Add(SubItemGridLookUpEditControl)

                GridColumn.ColumnEdit = SubItemGridLookUpEditControl

                AddHandler SubItemGridLookUpEditControl.EditValueChanged, AddressOf SubItemGridLookUpEditControl_EditValueChanged

            End If

        End Sub
        Protected Sub SubItemGridLookUpEditControl_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)

            EnableOrDisableActions()

        End Sub
        Private Sub EnableOrDisableActions()

            DataGridViewForm_ProductionReconcileRecognize.CurrentView.CloseEditorForUpdating()

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged AndAlso DataGridViewForm_ProductionReconcileRecognize.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary).Where(Function(PS) PS.ReconcileStatus IsNot Nothing).Any
            ButtonItemActions_Cancel.Enabled = ButtonItemActions_Save.Enabled
            ButtonItemActions_ProcessReconciliations.Enabled = Not ButtonItemActions_Save.Enabled AndAlso
                DataGridViewForm_ProductionReconcileRecognize.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary).Where(Function(PS) PS.BillStatus = 6 OrElse (PS.BillStatus <> 6 AndAlso PS.AmountToReconcile <> 0)).Any

            ButtonItemGridOptions_ChooseColumns.Enabled = Not Me.UserEntryChanged
            ButtonItemGridOptions_RestoreDefaults.Enabled = Not Me.UserEntryChanged

            ButtonItemReconcile_Delete.Enabled = DataGridViewForm_ProductionReconcileRecognize.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary).Where(Function(PS) PS.BillStatus = 6).Any

            ButtonItemReconcile_JobDetails.Enabled = DataGridViewForm_ProductionReconcileRecognize.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary).Where(Function(PS) PS.ReconcileStatus IsNot Nothing AndAlso (PS.ReconcileStatus = "1" OrElse PS.ReconcileStatus = "2")).Any

            ButtonItemReconcile_MarkSelected.Enabled = DataGridViewForm_ProductionReconcileRecognize.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary).Where(Function(PS) PS.BillStatus <> 6).Any

        End Sub
        Private Sub SetColumnDefaultVisibility()

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            For Each GridColumn In DataGridViewForm_ProductionReconcileRecognize.CurrentView.Columns

                If GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.OfficeDescription.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.IsAdjusted.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.CampaignID.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.CampaignCode.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.CampaignDescription.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.DivisionCode.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.DivisionName.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ProductCode.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ProductDescription.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.JobNumber.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.JobDescription.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ComponentNumber.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ComponentDescription.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.SalesClassCode.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.SalesClassDescription.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ClientPO.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ClientReference.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.BillingCoopCode.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ScheduleStatus.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ScheduleCompletedDate.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.EstimateNumberComponentQuoteRevision.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.EstimateApprovedDate.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.EstimateHours.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.EstimateQuantity.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.EstimateNetAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.EstimateMarkupAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.EstimateResaleTax.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.EstimateTotal.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.AmountToBill.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ActualBillableHours.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ActualBillableQuantity.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ActualBillableNetAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ActualBillableMarkupAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ActualBillableResaleTax.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ActualBillableTotal.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.BilledHours.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.BilledQuantity.ToString OrElse
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
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.TotalBilledAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.UnbilledAdvanceResaleTax.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.UnbilledAdvanceTotal.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.UnbilledHours.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.UnbilledQuantity.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.NonBillableHours.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.NonBillableQuantity.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.NonBillableNetAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.NonBillableMarkupAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.BillHoldAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.FlatIncomeToRecognize.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.FeeResaleTax.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.FeeTotal.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.BillingApprovalHeaderClientComment.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.AdvanceBillRequested.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.JobBillHoldRequested.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ProcessControlDescription.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.BilledOfEstimate.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.JobBillComment.ToString Then

                    GridColumn.Visible = False

                ElseIf GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.IsSelected.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.BillingSelectionSelect.ToString Then

                    GridColumn.Visible = False
                    GridColumn.OptionsColumn.ShowInCustomizationForm = False

                ElseIf GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ReconcileStatus.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.AmountToReconcile.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ReconcileMethod.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ReconcileResult.ToString Then

                    GridColumn.Visible = True

                End If

            Next

        End Sub
        Private Sub SetNewReconcile(ByVal NewReconcileStatus As String)

            'objects
            Dim BillingCommandCenter As AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim DataChanged As Boolean = False

            DataGridViewForm_ProductionReconcileRecognize.CurrentView.CloseEditorForUpdating()

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    BillingCommandCenter = AdvantageFramework.BillingCommandCenter.Database.Procedures.BillingCommandCenter.LoadByID(BCCDbContext, _BillingCommandCenterID)

                    If BillingCommandCenter IsNot Nothing Then

                        For Each ProductionSummary In DataGridViewForm_ProductionReconcileRecognize.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary).ToList()

                            If ProductionSummary.BillStatus <> 6 Then

                                If NewReconcileStatus = "1" OrElse NewReconcileStatus = "2" Then

                                    JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, ProductionSummary.JobNumber, ProductionSummary.ComponentNumber)

                                    If JobComponent IsNot Nothing Then

                                        If JobComponent.ProductionAdvancedBillingIncome <> AdvantageFramework.Database.Entities.ProductionAdvancedBillingIncome.InitialBilling Then

                                            ProductionSummary.ReconcileStatus = NewReconcileStatus

                                            ProductionSummary.PopulateReconcileDetails(BCCDbContext, BillingCommandCenter, _IncludeContingency)

                                            DataChanged = True

                                        Else

                                            ProductionSummary.ReconcileResult = "Income recognition is initial billing."

                                        End If

                                    End If

                                Else

                                    ProductionSummary.ReconcileStatus = NewReconcileStatus

                                    ProductionSummary.PopulateReconcileDetails(BCCDbContext, BillingCommandCenter, _IncludeContingency)

                                    DataChanged = True

                                End If

                            End If

                        Next

                    End If

                End Using

            End Using

            If DataChanged Then

                DataGridViewForm_ProductionReconcileRecognize.SetUserEntryChanged()

            End If

            DataGridViewForm_ProductionReconcileRecognize.CurrentView.RefreshData()

            DataGridViewForm_ProductionReconcileRecognize.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ReconcileStatus.ToString).BestFit()
            DataGridViewForm_ProductionReconcileRecognize.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ReconcileResult.ToString).BestFit()

            EnableOrDisableActions()

        End Sub
        Private Sub ReloadProductionSummaryList(ByVal BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext)

            Dim JobComponents As Generic.List(Of String) = Nothing
            Dim JobComponent() As String = Nothing

            JobComponents = (From PS In _ProductionSummaryList
                             Select PS.JobNumber & "|" & PS.ComponentNumber).ToList

            _ProductionSummaryList.Clear()

            For Each JC In JobComponents

                JobComponent = JC.Split("|")

                _ProductionSummaryList.AddRange(AdvantageFramework.BillingCommandCenter.GetProductionSummary(BCCDbContext, _BillingCommandCenterID, _IncludeContingency, JobComponent(0), JobComponent(1)))

            Next

            _ProductionSummaryList = AdvantageFramework.Billing.Presentation.GetProductionSummaryReconcileable(_ProductionSummaryList)

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal BillingCommandCenterID As Integer, ByVal IncludeContingency As Short, ByVal ProductionSummaryList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary)) As System.Windows.Forms.DialogResult

            'objects
            Dim BillingCommandCenterProductionReconcileDialog As AdvantageFramework.Billing.Presentation.BillingCommandCenterProductionReconcileDialog = Nothing

            BillingCommandCenterProductionReconcileDialog = New AdvantageFramework.Billing.Presentation.BillingCommandCenterProductionReconcileDialog(BillingCommandCenterID, IncludeContingency, ProductionSummaryList)

            ShowFormDialog = BillingCommandCenterProductionReconcileDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub BillingCommandCenterProductionReconcileDialog_FormClosing(sender As Object, e As Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl = Nothing

            If DataGridViewForm_ProductionReconcileRecognize.Columns.Count > 0 AndAlso TypeOf DataGridViewForm_ProductionReconcileRecognize.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ReconcileStatus.ToString).ColumnEdit Is AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl Then

                SubItemGridLookUpEditControl = DataGridViewForm_ProductionReconcileRecognize.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ReconcileStatus.ToString).ColumnEdit

                If SubItemGridLookUpEditControl IsNot Nothing Then

                    RemoveHandler SubItemGridLookUpEditControl.EditValueChanged, AddressOf SubItemGridLookUpEditControl_EditValueChanged

                End If

            End If

            If e.CloseReason = Windows.Forms.CloseReason.UserClosing AndAlso Session IsNot Nothing Then

                AdvantageFramework.WinForm.Presentation.Controls.SaveDataGridViewLayout(Session, DataGridViewForm_ProductionReconcileRecognize, AdvantageFramework.Database.Entities.GridAdvantageType.BillingCommandCenterReconcileRecognize)

            End If

        End Sub
        Private Sub BillingCommandCenterProductionReconcileDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemActions_ProcessReconciliations.Image = AdvantageFramework.My.Resources.ProcessImage

            ButtonItemReconcile_JobDetails.Image = AdvantageFramework.My.Resources.ViewImage
            ButtonItemReconcile_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage

            ButtonItemGridOptions_ChooseColumns.Image = AdvantageFramework.My.Resources.ColumnImage
            ButtonItemGridOptions_RestoreDefaults.Image = AdvantageFramework.My.Resources.RestoreDefaultsImage

            ComboBoxReconcile_Reconcile.ByPassUserEntryChanged = True
            ComboBoxReconcile_Reconcile.ExtraComboBoxItem = WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.None

            ComboBoxReconcile_Reconcile.DataSource = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.BillingCommandCenter.ProductionReconcileStatus)).ToList
                                                      Select [Code] = CShort(EnumObject.Code),
                                                             [Description] = EnumObject.Description).ToList

            DataGridViewForm_ProductionReconcileRecognize.CurrentView.OptionsLayout.StoreDataSettings = True
            DataGridViewForm_ProductionReconcileRecognize.CurrentView.OptionsLayout.StoreAppearance = True
            DataGridViewForm_ProductionReconcileRecognize.CurrentView.OptionsLayout.StoreVisualOptions = True

            DataGridViewForm_ProductionReconcileRecognize.CurrentView.OptionsLayout.Columns.StoreAllOptions = True
            DataGridViewForm_ProductionReconcileRecognize.CurrentView.OptionsLayout.Columns.StoreAppearance = True

            DataGridViewForm_ProductionReconcileRecognize.AutoloadRepositoryDatasource = True
            DataGridViewForm_ProductionReconcileRecognize.AddFixedColumnCheckItemsToGridMenu = True

            DataGridViewForm_ProductionReconcileRecognize.OptionsCustomization.AllowGroup = True
            DataGridViewForm_ProductionReconcileRecognize.OptionsCustomization.AllowSort = True
            DataGridViewForm_ProductionReconcileRecognize.OptionsCustomization.AllowFilter = True
            DataGridViewForm_ProductionReconcileRecognize.OptionsCustomization.AllowColumnMoving = True

            DataGridViewForm_ProductionReconcileRecognize.ShowSelectDeselectAllButtons = True

            _ToolTipController = New DevExpress.Utils.ToolTipController()

            DataGridViewForm_ProductionReconcileRecognize.GridControl.ToolTipController = _ToolTipController

            LoadGrid()

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

            If e.SelectedControl Is DataGridViewForm_ProductionReconcileRecognize.GridControl Then

                Try

                    GridView = CType(DataGridViewForm_ProductionReconcileRecognize.GridControl.GetViewAt(e.ControlMousePosition), DevExpress.XtraGrid.Views.Grid.GridView)

                    If GridView IsNot Nothing Then

                        GridHitInfo = GridView.CalcHitInfo(e.ControlMousePosition)

                        If GridHitInfo.InRowCell AndAlso GridHitInfo.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.BillStatus.ToString Then

                            Try

                                RowID = DataGridViewForm_ProductionReconcileRecognize.CurrentView.GetRowCellValue(GridHitInfo.RowHandle, AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.BillStatus.ToString)

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

                                        ToolTipText = "Job Details Bill Hold"

                                    Case 6

                                        ToolTipText = "Reconciled - Select for billing and process"

                                End Select

                            End If

                        ElseIf GridHitInfo.InRowCell AndAlso GridHitInfo.Column.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ReconcileStatus.ToString Then

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

                                ToolTipText = DataGridViewForm_ProductionReconcileRecognize.CurrentView.GetRowCellValue(GridHitInfo.RowHandle, GridHitInfo.Column.FieldName)

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
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            For Each ProductionSummary In _ProductionSummaryListToProcess

                ProductionSummary.ReconcileStatus = Nothing
                ProductionSummary.ClearReconcileDetails()

            Next

            LoadGrid()

            Me.ClearChanged()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_ProcessReconciliations_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_ProcessReconciliations.Click

            Dim ProductionSummaryList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary) = Nothing
            Dim BillingCommandCenter As AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter = Nothing
            Dim BillingCommandCenterInvoiceDatePostPeriod As AdvantageFramework.BillingCommandCenter.Database.Classes.BillingCommandCenterInvoiceDatePostPeriod = Nothing
            Dim BillingSelectionCriteria As AdvantageFramework.BillingCommandCenter.Classes.BillingSelectionCriteria = Nothing
            Dim BillingStatus As AdvantageFramework.BillingCommandCenter.Database.Classes.BillingStatus = Nothing
            Dim Result As Integer = Nothing
            Dim SetupIncomplete As Boolean = False
            'Dim ErrorMessage As String = ""

            If AdvantageFramework.WinForm.MessageBox.Show("You are about to process, assign, and finish reconciled jobs as well as other selected jobs and orders in this current batch.  Are you sure you want to continue?", WinForm.MessageBox.MessageBoxButtons.YesNo, "", Windows.Forms.MessageBoxIcon.Warning, Windows.Forms.MessageBoxDefaultButton.Button2) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                Me.ShowWaitForm()

                ProductionSummaryList = DataGridViewForm_ProductionReconcileRecognize.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary).Where(Function(PS) PS.BillStatus = 6).ToList

                Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    BillingCommandCenter = AdvantageFramework.BillingCommandCenter.Database.Procedures.BillingCommandCenter.LoadByID(BCCDbContext, _BillingCommandCenterID)

                    If BillingCommandCenter IsNot Nothing Then

                        BillingCommandCenterInvoiceDatePostPeriod = AdvantageFramework.BillingCommandCenter.GetBillingCommandCenterInvoiceDatePostPeriod(BCCDbContext, BillingCommandCenter.BillingUser)

                        If BillingCommandCenterInvoiceDatePostPeriod IsNot Nothing Then

                            BillingSelectionCriteria = New AdvantageFramework.BillingCommandCenter.Classes.BillingSelectionCriteria(BillingCommandCenterInvoiceDatePostPeriod)

                            If AdvantageFramework.WinForm.Presentation.GenericPropertyGridDialog.ShowFormDialog("Confirm Options", BillingSelectionCriteria, False) = Windows.Forms.DialogResult.OK Then

                                AdvantageFramework.BillingCommandCenter.UpdateBillingSelectionInvoiceDatePostPeriodCode(BCCDbContext, BillingSelectionCriteria.InvoiceDate, BillingSelectionCriteria.PostPeriodCode, BillingCommandCenter.BillingUser, BillingSelectionCriteria)

                                For Each ProductionSummary In ProductionSummaryList

                                    If ProductionSummary.BillingUser Is Nothing Then

                                        Result = AdvantageFramework.BillingCommandCenter.BillingSelectMarkJobComponent(BCCDbContext, BillingCommandCenter, BillingSelectionCriteria.InvoiceDate.Value, BillingSelectionCriteria.PostPeriodCode, ProductionSummary.JobNumber, ProductionSummary.ComponentNumber, ProductionSummary.BillingSelectionResult)

                                        If Result = 0 Then

                                            ProductionSummary.BillingUser = Mid(BillingCommandCenter.BillingUser, 1, BillingCommandCenter.BillingUser.Length - 2)

                                        ElseIf Result = -7 Then

                                            SetupIncomplete = True

                                        End If

                                    End If

                                Next

                                If SetupIncomplete Then

                                    AdvantageFramework.WinForm.MessageBox.Show("One or more records has not been selected for billing because billing setup has not been completed.")

                                Else

                                    AdvantageFramework.BillingCommandCenter.UpdateBillingSetInvoicesProcessedFlag(BCCDbContext, BillingCommandCenter.BillingUser, False)

                                    ' update/delete BILLING row if no production/media jobs/orders are selected for billing
                                    AdvantageFramework.BillingCommandCenter.DeleteBillingSelection(BCCDbContext, BillingCommandCenter.BillingUser)

                                    'process
                                    If AdvantageFramework.Billing.Presentation.ProcessInvoices(Me.Session, _BillingCommandCenterID, BillingStatus, True) Then

                                        'assign
                                        If AdvantageFramework.Billing.Presentation.OkayToAssignInvoices(Session, _BillingCommandCenterID, BillingStatus, BillingCommandCenter, True) Then

                                            If AdvantageFramework.Billing.Presentation.AssignInvoices(Me.Session, BillingCommandCenter, BillingStatus, False) Then

                                                'finish
                                                If AdvantageFramework.Billing.Presentation.FinishBatch(Me.Session, _BillingCommandCenterID) Then

                                                    Me.Close()

                                                End If

                                            End If

                                        End If

                                    End If

                                End If

                            End If

                        End If

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ProductionSummaryList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary) = Nothing
            Dim ProductionReconcileInterimDetails As Generic.List(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionReconcileInterimDetail) = Nothing
            Dim BillingCommandCenter As AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim BillingApprovalID As Nullable(Of Integer) = Nothing
            'Dim Result As String = Nothing
            'Dim ResultDictionary As Dictionary(Of String, String) = Nothing
            Dim ChosenDictionary As Dictionary(Of String, String) = Nothing
            Dim DictionaryGrid As Dictionary(Of Integer, Object) = Nothing
            Dim ProductionSummary As AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary = Nothing
            Dim ReconcileMethod As String = Nothing
            Dim EnumObjectAttribute As AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute = Nothing
            Dim AllowContinue As Boolean = True

            'ResultDictionary = New Dictionary(Of String, String)
            ChosenDictionary = New Dictionary(Of String, String)

            DataGridViewForm_ProductionReconcileRecognize.CurrentView.CloseEditorForUpdating()

            ProductionSummaryList = DataGridViewForm_ProductionReconcileRecognize.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary)().ToList

            If ProductionSummaryList.Where(Function(PS) PS.OpenPOAmount.GetValueOrDefault(0) <> 0 AndAlso
                                                        (PS.ReconcileStatus = AdvantageFramework.BillingCommandCenter.ProductionReconcileStatus.Final_Reconcile_To_Actual OrElse
                                                         PS.ReconcileStatus = AdvantageFramework.BillingCommandCenter.ProductionReconcileStatus.Final_Reconcile_To_Billed OrElse
                                                         PS.ReconcileStatus = AdvantageFramework.BillingCommandCenter.ProductionReconcileStatus.Final_Reconcile_To_Quote)).Any Then

                If AdvantageFramework.WinForm.MessageBox.Show("One or more jobs have open PO's, do you want to continue?", WinForm.MessageBox.MessageBoxButtons.YesNo, MessageBoxDefaultButton:=Windows.Forms.MessageBoxDefaultButton.Button2) = WinForm.MessageBox.DialogResults.No Then

                    AllowContinue = False

                End If

            End If

            If AllowContinue Then

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        BillingCommandCenter = AdvantageFramework.BillingCommandCenter.Database.Procedures.BillingCommandCenter.LoadByID(BCCDbContext, _BillingCommandCenterID)

                        If BillingCommandCenter IsNot Nothing Then

                            For Each ProductionSummary In ProductionSummaryList

                                AllowContinue = True

                                If AdvantageFramework.Database.Procedures.AdvanceBilling.LoadAllUnbilledByJobNumberAndJobComponentNumber(DbContext, ProductionSummary.JobNumber, ProductionSummary.ComponentNumber).Any OrElse
                                            AdvantageFramework.Database.Procedures.IncomeRecognize.LoadAllUnbilledByJobNumberAndJobComponentNumber(DbContext, ProductionSummary.JobNumber, ProductionSummary.ComponentNumber).Any Then

                                    AllowContinue = False

                                End If

                                If AllowContinue Then

                                    If ProductionSummary.ReconcileStatus = AdvantageFramework.BillingCommandCenter.ProductionReconcileStatus.Interim_Reconcile_All OrElse
                                            ProductionSummary.ReconcileStatus = AdvantageFramework.BillingCommandCenter.ProductionReconcileStatus.Interim_Reconcile_Approved Then

                                        JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, ProductionSummary.JobNumber, ProductionSummary.ComponentNumber)

                                        If JobComponent IsNot Nothing Then

                                            BillingApprovalID = JobComponent.SelectedBillingApprovalID

                                        Else

                                            BillingApprovalID = Nothing

                                        End If

                                        For Each AccountPayableProductionItem In ProductionSummary.AccountPayableProductionItems.Where(Function(Entity) Entity.Reconcile = True).ToList

                                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.AP_PRODUCTION SET AB_FLAG = 6 WHERE AP_ID = {0} AND LINE_NUMBER = {1}", AccountPayableProductionItem.AccountPayableID, AccountPayableProductionItem.LineNumber))

                                        Next

                                        For Each EmployeeTimeItem In ProductionSummary.EmployeeTimeItems.Where(Function(Entity) Entity.Reconcile = True).ToList

                                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.EMP_TIME_DTL SET AB_FLAG = 6 WHERE ET_ID = {0} AND SEQ_NBR = {1}", EmployeeTimeItem.EmployeeTimeID, EmployeeTimeItem.SequenceNumber))

                                        Next

                                        For Each IncomeOnlyItem In ProductionSummary.IncomeOnlyItems.Where(Function(Entity) Entity.Reconcile = True).ToList

                                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.INCOME_ONLY SET AB_FLAG = 6 WHERE IO_ID = {0} AND SEQ_NBR = {1}", IncomeOnlyItem.ID, IncomeOnlyItem.SequenceNumber))

                                        Next

                                        If ProductionSummary.ReconcileStatus = AdvantageFramework.BillingCommandCenter.ProductionReconcileStatus.Interim_Reconcile_All Then

                                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.JOB_COMPONENT SET SELECTED_BA_ID = NULL, BA_BATCH_ID = NULL WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1}", ProductionSummary.JobNumber, ProductionSummary.ComponentNumber))

                                            ProductionReconcileInterimDetails = AdvantageFramework.BillingCommandCenter.GetProductionReconcileInterimDetail(BCCDbContext,
                                                ProductionSummary.JobNumber, ProductionSummary.ComponentNumber, Nothing,
                                                BillingCommandCenter.EmployeeTimeDateCutoff, BillingCommandCenter.IncomeOnlyDateCutoff, BillingCommandCenter.APPostPeriodCodeCutoff).ToList

                                        Else

                                            ProductionReconcileInterimDetails = AdvantageFramework.BillingCommandCenter.GetProductionReconcileInterimDetail(BCCDbContext,
                                                    ProductionSummary.JobNumber, ProductionSummary.ComponentNumber, BillingApprovalID, Nothing, Nothing, Nothing).ToList

                                        End If

                                        For Each ProductionReconcileInterimDetail In ProductionReconcileInterimDetails

                                            AdvantageFramework.BillingCommandCenter.InterimReconcile(BCCDbContext, ProductionReconcileInterimDetail, ProductionSummary.JobNumber, ProductionSummary.ComponentNumber)

                                            'If Result <> "" AndAlso ResultDictionary.ContainsKey(ProductionSummary.JobNumber & "|" & ProductionSummary.ComponentNumber) = False Then

                                            '    ResultDictionary.Add(ProductionSummary.JobNumber & "|" & ProductionSummary.ComponentNumber, Result)

                                            'End If

                                        Next

                                    ElseIf ProductionSummary.ReconcileStatus = AdvantageFramework.BillingCommandCenter.ProductionReconcileStatus.Final_Reconcile_To_Actual Then

                                        AdvantageFramework.BillingCommandCenter.AdvanceBillReconcile(BCCDbContext, ProductionSummary.JobNumber, ProductionSummary.ComponentNumber, 1, BillingCommandCenter.ID)

                                    ElseIf ProductionSummary.ReconcileStatus = AdvantageFramework.BillingCommandCenter.ProductionReconcileStatus.Final_Reconcile_To_Quote Then

                                        AdvantageFramework.BillingCommandCenter.AdvanceBillReconcile(BCCDbContext, ProductionSummary.JobNumber, ProductionSummary.ComponentNumber, 2, BillingCommandCenter.ID)

                                    ElseIf ProductionSummary.ReconcileStatus = AdvantageFramework.BillingCommandCenter.ProductionReconcileStatus.Final_Reconcile_To_Billed Then

                                        AdvantageFramework.BillingCommandCenter.AdvanceBillReconcile(BCCDbContext, ProductionSummary.JobNumber, ProductionSummary.ComponentNumber, 4, BillingCommandCenter.ID)

                                    End If

                                End If

                                If ChosenDictionary.ContainsKey(ProductionSummary.JobNumber & "|" & ProductionSummary.ComponentNumber) = False Then

                                    ChosenDictionary.Add(ProductionSummary.JobNumber & "|" & ProductionSummary.ComponentNumber, ProductionSummary.ReconcileStatus)

                                End If

                            Next

                        End If

                        ReloadProductionSummaryList(BCCDbContext)

                    End Using

                End Using

                LoadGrid()

                DictionaryGrid = DataGridViewForm_ProductionReconcileRecognize.GetAllRowsRowHandlesAndDataBoundItems()

                For Each RowItem In DictionaryGrid

                    ProductionSummary = DirectCast(RowItem.Value, AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary)

                    'If ResultDictionary.ContainsKey(ProductionSummary.JobNumber & "|" & ProductionSummary.ComponentNumber) AndAlso ResultDictionary.Item(ProductionSummary.JobNumber & "|" & ProductionSummary.ComponentNumber) IsNot Nothing Then

                    '    DataGridViewForm_ProductionReconcileRecognize.CurrentView.SelectRow(RowItem.Key)

                    '    DataGridViewForm_ProductionReconcileRecognize.CurrentView.SetColumnError(DataGridViewForm_ProductionReconcileRecognize.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ReconcileStatus.ToString), ResultDictionary.Item(ProductionSummary.JobNumber & "|" & ProductionSummary.ComponentNumber))

                    'End If

                    If ChosenDictionary.ContainsKey(ProductionSummary.JobNumber & "|" & ProductionSummary.ComponentNumber) AndAlso ChosenDictionary.Item(ProductionSummary.JobNumber & "|" & ProductionSummary.ComponentNumber) IsNot Nothing Then

                        DataGridViewForm_ProductionReconcileRecognize.CurrentView.SelectRow(RowItem.Key)

                        EnumObjectAttribute = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.BillingCommandCenter.ProductionReconcileStatus)).ToList
                                               Where EnumObject.Code = CShort(ChosenDictionary.Item(ProductionSummary.JobNumber & "|" & ProductionSummary.ComponentNumber))
                                               Select EnumObject).FirstOrDefault

                        If EnumObjectAttribute IsNot Nothing Then

                            ReconcileMethod = EnumObjectAttribute.Description

                        Else

                            ReconcileMethod = "None"

                        End If

                        If String.IsNullOrWhiteSpace(ProductionSummary.ReconcileResult) Then

                            DataGridViewForm_ProductionReconcileRecognize.CurrentView.SetRowCellValue(RowItem.Key, DataGridViewForm_ProductionReconcileRecognize.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ReconcileResult.ToString), "Nothing to Reconcile")

                            'Else

                            '    ReconcileMethod = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.BillingCommandCenter.ProductionReconcileStatus)).ToList _
                            '                       Where EnumObject.Code = CShort(ChosenDictionary.Item(ProductionSummary.JobNumber & "|" & ProductionSummary.ComponentNumber))
                            '                       Select EnumObject).FirstOrDefault.Description

                        End If

                        DataGridViewForm_ProductionReconcileRecognize.CurrentView.SetRowCellValue(RowItem.Key, DataGridViewForm_ProductionReconcileRecognize.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ReconcileMethod.ToString), ReconcileMethod)

                    End If

                Next

                DataGridViewForm_ProductionReconcileRecognize.CurrentView.BestFitColumns()

                Me.ClearChanged()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemGridOptions_ChooseColumns_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemGridOptions_ChooseColumns.CheckedChanged

            Try

                If ButtonItemGridOptions_ChooseColumns.Checked Then

                    If DataGridViewForm_ProductionReconcileRecognize.CurrentView.CustomizationForm Is Nothing Then

                        DataGridViewForm_ProductionReconcileRecognize.CurrentView.ShowCustomization()

                    End If

                Else

                    If DataGridViewForm_ProductionReconcileRecognize.CurrentView.CustomizationForm IsNot Nothing Then

                        DataGridViewForm_ProductionReconcileRecognize.CurrentView.DestroyCustomization()

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ButtonItemGridOptions_RestoreDefaults_Click(sender As Object, e As EventArgs) Handles ButtonItemGridOptions_RestoreDefaults.Click

            Me.ShowWaitForm("Loading...")

            Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                AdvantageFramework.Database.Procedures.GridAdvantage.Delete(DataContext, AdvantageFramework.Database.Entities.GridAdvantageType.BillingCommandCenterReconcileRecognize, Session.UserCode)

            End Using

            DataGridViewForm_ProductionReconcileRecognize.SetBookmarkColumnIndex(-1)
            DataGridViewForm_ProductionReconcileRecognize.Columns.Clear()

            DataGridViewForm_ProductionReconcileRecognize.ClearDatasource()

            LoadGrid()

            Me.ClearChanged()

            EnableOrDisableActions()

            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonItemReconcile_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemReconcile_Delete.Click

            If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete pending reconciliations?", WinForm.MessageBox.MessageBoxButtons.YesNo, "") = WinForm.MessageBox.DialogResults.Yes Then

                Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    For Each ProductionSummary In DataGridViewForm_ProductionReconcileRecognize.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary)()

                        If ProductionSummary.BillStatus = 6 Then

                            BCCDbContext.Database.ExecuteSqlCommand(String.Format("exec dbo.advsp_bcc_delete_reconciliation {0}, {1}", ProductionSummary.JobNumber, ProductionSummary.ComponentNumber))

                        End If

                    Next

                    ReloadProductionSummaryList(BCCDbContext)

                End Using

                LoadGrid()

            End If

        End Sub
        Private Sub ButtonItemReconcile_JobDetails_Click(sender As Object, e As EventArgs) Handles ButtonItemReconcile_JobDetails.Click

            DataGridViewForm_ProductionReconcileRecognize.CurrentView.CloseEditorForUpdating()

            _ProductionSummaryListToProcess = (From PS In DataGridViewForm_ProductionReconcileRecognize.GetAllSelectedRowsDataBoundItems().OfType(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary)().ToList
                                               Where PS.ReconcileStatus = "1" OrElse
                                                     PS.ReconcileStatus = "2"
                                               Select PS).ToList

            For Each ProductionSummary In _ProductionSummaryListToProcess

                If ProductionSummary.AccountPayableProductionItems Is Nothing Then

                    ProductionSummary.PopulateReconcileDetails(Session, _BillingCommandCenterID, _IncludeContingency)

                End If

            Next

            AdvantageFramework.Billing.Presentation.BillingCommandCenterJobDetailDialog.ShowFormDialog(_BillingCommandCenterID, _IncludeContingency, _ProductionSummaryListToProcess)

            DataGridViewForm_ProductionReconcileRecognize.CurrentView.RefreshData()

        End Sub
        Private Sub ButtonItemReconcile_MarkSelected_Click(sender As Object, e As EventArgs) Handles ButtonItemReconcile_MarkSelected.Click

            Me.ShowWaitForm()

            SetNewReconcile(ComboBoxReconcile_Reconcile.GetSelectedValue)

            Me.CloseWaitForm()

        End Sub
        Private Sub ComboBoxReconcile_Reconcile_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxReconcile_Reconcile.SelectedValueChanged

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_ProductionReconcileRecognize_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_ProductionReconcileRecognize.CellValueChangedEvent

            If e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ReconcileStatus.ToString Then

                Me.ShowWaitForm()

                If e.Value IsNot Nothing Then

                    DirectCast(DataGridViewForm_ProductionReconcileRecognize.CurrentView.GetRow(DataGridViewForm_ProductionReconcileRecognize.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary).PopulateReconcileDetails(Session, _BillingCommandCenterID, _IncludeContingency)

                Else

                    DirectCast(DataGridViewForm_ProductionReconcileRecognize.CurrentView.GetRow(DataGridViewForm_ProductionReconcileRecognize.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary).ClearReconcileDetails()

                End If

                DataGridViewForm_ProductionReconcileRecognize.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ReconcileStatus.ToString).BestFit()

                Me.CloseWaitForm()

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_ProductionReconcileRecognize_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_ProductionReconcileRecognize.DataSourceChangedEvent

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            If Not Me.IsFormClosing Then

                DataGridViewForm_ProductionReconcileRecognize.CurrentView.OptionsView.ShowFooter = True

                DataGridViewForm_ProductionReconcileRecognize.CurrentView.OptionsView.EnableAppearanceOddRow = True
                DataGridViewForm_ProductionReconcileRecognize.CurrentView.Appearance.OddRow.BackColor = Drawing.Color.FromArgb(240, 240, 240)

                For Each GridColumn In DataGridViewForm_ProductionReconcileRecognize.Columns

                    If GridColumn.ColumnType Is GetType(System.Decimal) OrElse
                            GridColumn.ColumnType Is GetType(System.Nullable(Of Decimal)) Then

                        If GridColumn.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.BilledOfEstimate.ToString Then

                            AdvantageFramework.Billing.Presentation.SetColumnAsSumColumn(DataGridViewForm_ProductionReconcileRecognize, GridColumn.FieldName)

                        End If

                    End If

                Next

            End If

        End Sub
        Private Sub DataGridViewForm_ProductionReconcileRecognize_HideCustomizationFormEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_ProductionReconcileRecognize.HideCustomizationFormEvent

            If ButtonItemGridOptions_ChooseColumns.Checked Then

                ButtonItemGridOptions_ChooseColumns.Checked = False

            End If

        End Sub
        Private Sub DataGridViewForm_ProductionReconcileRecognize_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_ProductionReconcileRecognize.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_ProductionReconcileRecognize_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewForm_ProductionReconcileRecognize.ShowingEditorEvent

            If DataGridViewForm_ProductionReconcileRecognize.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ReconcileStatus.ToString AndAlso
                    DataGridViewForm_ProductionReconcileRecognize.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.BillingApprovalHeaderComment.ToString AndAlso
                    DataGridViewForm_ProductionReconcileRecognize.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.JobBillComment.ToString AndAlso
                    DataGridViewForm_ProductionReconcileRecognize.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.JobCompDescription.ToString Then

                e.Cancel = True

            ElseIf DataGridViewForm_ProductionReconcileRecognize.CurrentView.FocusedColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ReconcileStatus.ToString AndAlso
                    DirectCast(DataGridViewForm_ProductionReconcileRecognize.CurrentView.GetRow(DataGridViewForm_ProductionReconcileRecognize.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary).BillStatus = 6 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DataGridViewForm_ProductionReconcileRecognize_ShownEditorEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_ProductionReconcileRecognize.ShownEditorEvent

            Dim GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim ProductionSummary As AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary = Nothing

            If TypeOf DataGridViewForm_ProductionReconcileRecognize.CurrentView.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

                GridLookUpEdit = DataGridViewForm_ProductionReconcileRecognize.CurrentView.ActiveEditor

                If DataGridViewForm_ProductionReconcileRecognize.CurrentView.FocusedColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ReconcileStatus.ToString Then

                    ProductionSummary = DataGridViewForm_ProductionReconcileRecognize.GetRowDataBoundItem(DataGridViewForm_ProductionReconcileRecognize.CurrentView.FocusedRowHandle)

                    If ProductionSummary IsNot Nothing Then

                        Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                            JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, ProductionSummary.JobNumber, ProductionSummary.ComponentNumber)

                            If JobComponent IsNot Nothing AndAlso JobComponent.ProductionAdvancedBillingIncome = 2 Then

                                BindingSource = New System.Windows.Forms.BindingSource
                                BindingSource.DataSource = From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.BillingCommandCenter.ProductionReconcileStatus))
                                                           Where Entity.Code <> "1" AndAlso
                                                                  Entity.Code <> "2"
                                                           Select Entity.Code,
                                                                  [Description] = Entity.Description

                                GridLookUpEdit.Properties.DataSource = BindingSource

                                AdvantageFramework.WinForm.Presentation.Controls.AddComboItemToExistingDataSource(GridLookUpEdit.Properties.DataSource, "Description", "Code",
                                                                                                                    "[None]", -3, True, True, Nothing)

                            End If

                        End Using

                    End If

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace