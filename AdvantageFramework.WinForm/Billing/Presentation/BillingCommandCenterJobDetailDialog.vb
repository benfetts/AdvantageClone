Namespace Billing.Presentation

    Public Class BillingCommandCenterJobDetailDialog

#Region " Constants "

        Private Const COLUMN_MIN_WIDTH_FOR_SELECTED_LABEL = 80

#End Region

#Region " Enum "

        Private Enum AdjustToFunction
            EstimateAmount
            BilledAmount
            ApprovedAmount
        End Enum

#End Region

#Region " Variables "

        Private _ProductionSummaryList As IEnumerable(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary) = Nothing
        Private _BillingCommandCenterID As Integer = Nothing
        Private _IncludeContingency As Short = Nothing
        Private _InvoiceTaxFlag As Boolean = False
        Private _ReconcileMode As Boolean = False
        Private _BillingStatus As AdvantageFramework.BillingCommandCenter.Database.Classes.BillingStatus = Nothing
        Private _BillStatus As Integer = Nothing
        Private _AdvanceBillFinalReconciledAndBilled As Boolean = False
        Private _AdvanceBillHasMultipleUnbilledFunctions As Boolean = False
        Private _IsClosing As Boolean = False
        Private _ShowEmployeeTimeTaskCode As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property ProductionSummaryList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary)
            Get
                ProductionSummaryList = _ProductionSummaryList
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal ProductionSummaryList As IEnumerable(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary),
                        ByVal BillingCommandCenterID As Integer, ByVal IncludeContingency As Short, ByVal ReconcileMode As Boolean)

            ' This call is required by the designer.
            InitializeComponent()

            _ProductionSummaryList = ProductionSummaryList
            _BillingCommandCenterID = BillingCommandCenterID
            _IncludeContingency = IncludeContingency
            _ReconcileMode = ReconcileMode

        End Sub
        Private Sub LoadGrid()

            Dim LayoutLoaded As Boolean = False

            DataGridViewLeftSection_Jobs.SetBookmarkColumnIndex(-1)
            DataGridViewLeftSection_Jobs.ClearGridCustomization()
            DataGridViewLeftSection_Jobs.ClearDatasource(New Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.JobDetailJobComponent))

            LayoutLoaded = AdvantageFramework.WinForm.Presentation.Controls.LoadDataGridViewLayout(Session, DataGridViewLeftSection_Jobs, Database.Entities.GridAdvantageType.BillingCommandCenterJobDetailJobComponent)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                If _ProductionSummaryList.Count <> 0 Then

                    DataGridViewLeftSection_Jobs.DataSource = (From PS In _ProductionSummaryList
                                                               Select New AdvantageFramework.BillingCommandCenter.Classes.JobDetailJobComponent(PS)).ToList

                End If

                If LayoutLoaded Then

                    AdvantageFramework.WinForm.Presentation.Controls.SortGridViewBySortedColumns(DataGridViewLeftSection_Jobs)

                Else

                    DataGridViewLeftSection_Jobs.CurrentView.ClearSorting()
                    DataGridViewLeftSection_Jobs.CurrentView.BeginSort()
                    DataGridViewLeftSection_Jobs.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Classes.JobDetailJobComponent.Properties.JobNumber.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Descending
                    DataGridViewLeftSection_Jobs.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Classes.JobDetailJobComponent.Properties.JobComponentNumber.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                    DataGridViewLeftSection_Jobs.CurrentView.EndSort()

                End If

            End Using

            DataGridViewLeftSection_Jobs.CurrentView.BestFitColumns()

            If DataGridViewLeftSection_Jobs.HasOnlyOneSelectedRow Then

                ButtonItemStatus_Adjusted.Checked = DirectCast(DataGridViewLeftSection_Jobs.CurrentView.GetRow(DataGridViewLeftSection_Jobs.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.JobDetailJobComponent).IsAdjusted

            End If

        End Sub
        Private Sub EnableOrDisableActions()

            Dim IsLocked As Boolean = False

            If Not _ReconcileMode AndAlso Me.FormShown Then

                IsLocked = DirectCast(DataGridViewLeftSection_Jobs.CurrentView.GetRow(DataGridViewLeftSection_Jobs.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.JobDetailJobComponent).BillingUser IsNot Nothing

                RibbonBarFilePanel_System.SuspendLayout()
                DataGridViewTop_JobComponentFunctions.SuspendLayout()

                ButtonItemActions_Save.Enabled = DataGridViewEmployeeTime_Details.UserEntryChanged OrElse DataGridViewIncomeOnly_Details.UserEntryChanged OrElse DataGridViewVendor_Details.UserEntryChanged OrElse DataGridViewAdvanceBilling_Details.UserEntryChanged
                ButtonItemActions_Cancel.Enabled = ButtonItemActions_Save.Enabled
                ButtonItemActions_Refresh.Enabled = Not ButtonItemActions_Save.Enabled

                ButtonItemFunctionGrid_ChooseColumns.Enabled = Not ButtonItemActions_Save.Enabled
                ButtonItemFunctionGrid_RestoreDefaults.Enabled = Not ButtonItemActions_Save.Enabled

                If TabControlRightSection_FunctionItems.SelectedTab Is TabItemFunctionItems_AdvanceBilling Then

                    DataGridViewTop_JobComponentFunctions.OptionsCustomization.AllowFilter = True
                    DataGridViewTop_JobComponentFunctions.ShowSelectDeselectAllButtons = True

                    ButtonItemFunctionGrid_SelectAll.Enabled = True

                Else

                    DataGridViewTop_JobComponentFunctions.OptionsCustomization.AllowFilter = Not ButtonItemActions_Save.Enabled
                    DataGridViewTop_JobComponentFunctions.ShowSelectDeselectAllButtons = Not ButtonItemActions_Save.Enabled

                    ButtonItemFunctionGrid_SelectAll.Enabled = Not ButtonItemActions_Save.Enabled

                End If

                If TabControlRightSection_FunctionItems.SelectedTab Is TabItemFunctionItems_EmployeeTime Then

                    ButtonItemEmployeeTime_MarkBillable.Enabled = DataGridViewEmployeeTime_Details.HasASelectedRow AndAlso Not IsLocked
                    ButtonItemEmployeeTime_MarkNonBillable.Enabled = DataGridViewEmployeeTime_Details.HasASelectedRow AndAlso Not IsLocked
                    ButtonItemEmployeeTime_FeeTime.Enabled = DataGridViewEmployeeTime_Details.HasASelectedRow AndAlso Not IsLocked
                    ButtonItemEmployeeTime_UpdateRate.Enabled = DataGridViewEmployeeTime_Details.HasASelectedRow AndAlso Not IsLocked
                    ButtonItemEmployeeTime_MarkupDown.Enabled = DataGridViewEmployeeTime_Details.HasASelectedRow AndAlso Not IsLocked

                    ButtonItemEmployeeTime_BillHold.Enabled = DataGridViewEmployeeTime_Details.HasASelectedRow AndAlso DataGridViewEmployeeTime_Details.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem).All(Function(Entity) Entity.ABFlag.GetValueOrDefault(0) = 0) AndAlso Not IsLocked
                    ButtonItemEmployeeTime_Transfer.Enabled = DataGridViewEmployeeTime_Details.HasASelectedRow AndAlso Not DataGridViewEmployeeTime_Details.UserEntryChanged AndAlso Not IsLocked

                    DataGridViewEmployeeTime_Details.CurrentView.OptionsBehavior.Editable = If(DataGridViewLeftSection_Jobs.Tag = 0, True, False)

                ElseIf TabControlRightSection_FunctionItems.SelectedTab Is TabItemFunctionItems_IncomeOnly Then

                    ButtonItemIncomeOnly_UpdateRate.Enabled = DataGridViewIncomeOnly_Details.HasASelectedRow AndAlso Not IsLocked
                    ButtonItemIncomeOnly_BillHold.Enabled = DataGridViewIncomeOnly_Details.HasASelectedRow AndAlso DataGridViewIncomeOnly_Details.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem).All(Function(Entity) Entity.ABFlag.GetValueOrDefault(0) = 0) AndAlso Not IsLocked
                    ButtonItemIncomeOnly_Transfer.Enabled = DataGridViewIncomeOnly_Details.HasASelectedRow AndAlso Not DataGridViewIncomeOnly_Details.UserEntryChanged AndAlso Not IsLocked

                    DataGridViewIncomeOnly_Details.CurrentView.OptionsBehavior.Editable = If(DataGridViewLeftSection_Jobs.Tag = 0, True, False)

                ElseIf TabControlRightSection_FunctionItems.SelectedTab Is TabItemFunctionItems_Vendor Then

                    If DataGridViewVendor_Details.HasOnlyOneSelectedRow Then

                        If DirectCast(DataGridViewVendor_Details.CurrentView.GetRow(DataGridViewVendor_Details.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem).IsNonBillable.GetValueOrDefault(0) = 1 Then

                            ButtonItemVendor_MarkupDown.Enabled = False
                            ButtonItemVendor_WriteOff.Enabled = False
                            ButtonItemVendor_BillHold.Enabled = False

                        ElseIf DirectCast(DataGridViewVendor_Details.CurrentView.GetRow(DataGridViewVendor_Details.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem).IsBilledReversal Then

                            ButtonItemVendor_MarkupDown.Enabled = False
                            ButtonItemVendor_WriteOff.Enabled = False
                            ButtonItemVendor_BillHold.Enabled = False

                        Else

                            ButtonItemVendor_MarkupDown.Enabled = True AndAlso Not IsLocked
                            ButtonItemVendor_WriteOff.Enabled = True AndAlso Not IsLocked
                            ButtonItemVendor_BillHold.Enabled = (DirectCast(DataGridViewVendor_Details.CurrentView.GetRow(DataGridViewVendor_Details.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem).ABFlag.GetValueOrDefault(0) = 0) AndAlso Not IsLocked

                        End If

                    Else

                        ButtonItemVendor_MarkupDown.Enabled = DataGridViewVendor_Details.HasASelectedRow AndAlso Not IsLocked AndAlso DataGridViewVendor_Details.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem).Where(Function(Entity) Entity.IsBilledReversal = False).Any
                        ButtonItemVendor_WriteOff.Enabled = DataGridViewVendor_Details.HasASelectedRow AndAlso DataGridViewVendor_Details.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem).Where(Function(Entity) Entity.IsNonBillable.GetValueOrDefault(0) = 0).Any AndAlso
                            Not IsLocked AndAlso DataGridViewVendor_Details.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem).Where(Function(Entity) Entity.IsBilledReversal = False).Any
                        ButtonItemVendor_BillHold.Enabled = DataGridViewVendor_Details.HasASelectedRow AndAlso DataGridViewVendor_Details.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem).All(Function(Entity) Entity.IsNonBillable.GetValueOrDefault(0) = 0 AndAlso Entity.ABFlag.GetValueOrDefault(0) = 0) AndAlso
                            Not IsLocked AndAlso DataGridViewVendor_Details.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem).Where(Function(Entity) Entity.IsBilledReversal = False).Any

                    End If

                    ButtonItemVendor_Transfer.Enabled = DataGridViewVendor_Details.HasASelectedRow AndAlso Not DataGridViewVendor_Details.UserEntryChanged AndAlso
                        Not IsLocked AndAlso DataGridViewVendor_Details.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem).Where(Function(Entity) Entity.IsBilledReversal = False).Any

                    DataGridViewVendor_Details.CurrentView.OptionsBehavior.Editable = If(DataGridViewLeftSection_Jobs.Tag = 0, True, False)

                ElseIf TabControlRightSection_FunctionItems.SelectedTab Is TabItemFunctionItems_Documents Then

                    ButtonItemDocuments_Download.Enabled = If(DocumentManagerControlDocuments_Documents.HasOnlyOneSelectedDocument, Not DocumentManagerControlDocuments_Documents.IsSelectedDocumentAURL, DocumentManagerControlDocuments_Documents.HasASelectedDocument)
                    ButtonItemDocuments_OpenURL.Enabled = If(DocumentManagerControlDocuments_Documents.HasOnlyOneSelectedDocument, DocumentManagerControlDocuments_Documents.IsSelectedDocumentAURL, False)

                ElseIf TabControlRightSection_FunctionItems.SelectedTab Is TabItemFunctionItems_AdvanceBilling Then

                    ButtonItemAdvanceBilling_CreateActuals.Enabled = DataGridViewTop_JobComponentFunctions.HasRows AndAlso Not IsLocked
                    ButtonItemAdvanceBilling_CreateActualsOpenPO.Enabled = DataGridViewTop_JobComponentFunctions.HasRows AndAlso Not IsLocked
                    ButtonItemAdvanceBilling_CreateAll.Enabled = DataGridViewTop_JobComponentFunctions.HasRows AndAlso Not IsLocked
                    ButtonItemAdvanceBilling_CreateSelected.Enabled = DataGridViewTop_JobComponentFunctions.HasASelectedRow AndAlso Not IsLocked
                    ButtonItemAdvanceBilling_CreateApproved.Enabled = DataGridViewTop_JobComponentFunctions.HasASelectedRow AndAlso DataGridViewTop_JobComponentFunctions.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail).Where(Function(Entity) Entity.BillingApprovalFunctionAmount IsNot Nothing).Any AndAlso Not IsLocked

                    ButtonItemAdvanceBilling_Delete.Enabled = DataGridViewAdvanceBilling_Details.HasASelectedRow AndAlso Not IsLocked

                    ButtonItemAdvanceBilling_Cancel.Enabled = DataGridViewAdvanceBilling_Details.IsNewItemRow(DataGridViewAdvanceBilling_Details.CurrentView.FocusedRowHandle) AndAlso Not IsLocked

                    DataGridViewAdvanceBilling_Details.CurrentView.OptionsBehavior.Editable = If(DataGridViewLeftSection_Jobs.Tag = 0, True, False) AndAlso Not IsLocked

                    ButtonItemIncomeRecognition_Create.Enabled = ButtonItemIncomeMethod_UponReconciliation.Checked AndAlso Not IsLocked

                End If

                If _BillingStatus IsNot Nothing AndAlso _BillingStatus.IsAssigned.GetValueOrDefault(0) = 1 Then

                    RibbonBarOptions_Actions.Enabled = False
                    RibbonBarOptions_Status.Enabled = False
                    RibbonBarOptions_EmployeeTime.Enabled = False
                    RibbonBarOptions_IncomeOnly.Enabled = False
                    RibbonBarOptions_Vendor.Enabled = False

                    RibbonBarOptions_AdvanceBilling.Enabled = False
                    RibbonBarOptions_IncomeMethod.Tag = False
                    NumericInputControl_PercentOfQuote.Enabled = False
                    RibbonBarOptions_IncomeRecognition.Enabled = False

                    DataGridViewAdvanceBilling_Details.CurrentView.OptionsBehavior.Editable = False
                    DataGridViewEmployeeTime_Details.CurrentView.OptionsBehavior.Editable = False
                    DataGridViewIncomeOnly_Details.CurrentView.OptionsBehavior.Editable = False
                    DataGridViewVendor_Details.CurrentView.OptionsBehavior.Editable = False
                    DataGridViewTop_JobComponentFunctions.CurrentView.OptionsBehavior.Editable = False

                ElseIf _BillStatus = 7 Then

                    RibbonBarOptions_AdvanceBilling.Enabled = False
                    ButtonItemAdvanceBilling_Create.Enabled = False
                    RibbonBarOptions_IncomeRecognition.Enabled = False

                    RibbonBarOptions_IncomeMethod.Tag = False
                    NumericInputControl_PercentOfQuote.Enabled = False
                    DataGridViewAdvanceBilling_Details.CurrentView.OptionsBehavior.Editable = False

                ElseIf _AdvanceBillHasMultipleUnbilledFunctions Then

                    RibbonBarOptions_AdvanceBilling.Enabled = True AndAlso Not IsLocked
                    ButtonItemAdvanceBilling_Create.Enabled = False
                    RibbonBarOptions_IncomeRecognition.Enabled = False

                    RibbonBarOptions_IncomeMethod.Tag = False
                    NumericInputControl_PercentOfQuote.Enabled = False
                    DataGridViewAdvanceBilling_Details.CurrentView.OptionsBehavior.Editable = False

                ElseIf DataGridViewLeftSection_Jobs.Tag <> 0 Then

                    RibbonBarOptions_EmployeeTime.Enabled = False
                    RibbonBarOptions_IncomeOnly.Enabled = False
                    RibbonBarOptions_Vendor.Enabled = False

                    RibbonBarOptions_AdvanceBilling.Enabled = False
                    RibbonBarOptions_IncomeMethod.Tag = False
                    NumericInputControl_PercentOfQuote.Enabled = False
                    RibbonBarOptions_IncomeRecognition.Enabled = False

                Else

                    RibbonBarOptions_Actions.Enabled = True
                    RibbonBarOptions_Status.Enabled = True
                    RibbonBarOptions_EmployeeTime.Enabled = True
                    RibbonBarOptions_IncomeOnly.Enabled = True
                    RibbonBarOptions_Vendor.Enabled = True

                    RibbonBarOptions_AdvanceBilling.Enabled = (Not _AdvanceBillFinalReconciledAndBilled) AndAlso Not IsLocked
                    ButtonItemAdvanceBilling_Create.Enabled = (Not _AdvanceBillFinalReconciledAndBilled) AndAlso Not IsLocked
                    RibbonBarOptions_IncomeMethod.Tag = (Not _AdvanceBillFinalReconciledAndBilled)
                    NumericInputControl_PercentOfQuote.Enabled = (Not _AdvanceBillFinalReconciledAndBilled) AndAlso Not IsLocked
                    DataGridViewAdvanceBilling_Details.CurrentView.OptionsBehavior.Editable = (Not _AdvanceBillFinalReconciledAndBilled) AndAlso Not IsLocked
                    RibbonBarOptions_IncomeRecognition.Enabled = (Not _AdvanceBillFinalReconciledAndBilled) AndAlso Not IsLocked

                End If

                DataGridViewTop_JobComponentFunctions.ResumeLayout()

                RibbonBarFilePanel_System.ResumeLayout()

            ElseIf _ReconcileMode Then

                RibbonBarOptions_ReconcileEmployeeTime.Visible = TabControlRightSection_FunctionItems.SelectedTab Is TabItemFunctionItems_EmployeeTime

                RibbonBarOptions_ReconcileIncomeOnly.Visible = TabControlRightSection_FunctionItems.SelectedTab Is TabItemFunctionItems_IncomeOnly

                RibbonBarOptions_ReconcileVendor.Visible = TabControlRightSection_FunctionItems.SelectedTab Is TabItemFunctionItems_Vendor

            End If

        End Sub
        Private Sub LoadFunctions()

            'objects
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim SelectAll As Boolean = False
            Dim JobNumber As Integer = Nothing
            Dim JobComponentNumber As Short = Nothing
            Dim LayoutLoaded As Boolean = False
            Dim ProductionSummary As AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary = Nothing
            Dim AFActiveFilterString As String = Nothing

            Me.ShowWaitForm()

            AFActiveFilterString = DataGridViewTop_JobComponentFunctions.CurrentView.AFActiveFilterString

            BindingSource = DataGridViewTop_JobComponentFunctions.DataSource

            If BindingSource IsNot Nothing AndAlso BindingSource.DataSource IsNot Nothing Then

                AdvantageFramework.WinForm.Presentation.Controls.SaveDataGridViewLayout(Session, DataGridViewTop_JobComponentFunctions, AdvantageFramework.Database.Entities.GridAdvantageType.BillingCommandCenterJobComponentFunctionDetail)

            End If

            If ButtonItemFunctionGrid_SelectAll.Checked OrElse
                    (DataGridViewTop_JobComponentFunctions.CurrentView.SelectedRowsCount > 1 AndAlso DataGridViewTop_JobComponentFunctions.CurrentView.RowCount = DataGridViewTop_JobComponentFunctions.CurrentView.SelectedRowsCount) Then

                SelectAll = True

            End If

            DataGridViewTop_JobComponentFunctions.SetBookmarkColumnIndex(-1)
            DataGridViewTop_JobComponentFunctions.ClearGridCustomization()
            DataGridViewTop_JobComponentFunctions.ClearDatasource(New Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail))

            If DataGridViewLeftSection_Jobs.HasOnlyOneSelectedRow Then

                JobNumber = DirectCast(DataGridViewLeftSection_Jobs.CurrentView.GetRow(DataGridViewLeftSection_Jobs.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.JobDetailJobComponent).JobNumber
                JobComponentNumber = DirectCast(DataGridViewLeftSection_Jobs.CurrentView.GetRow(DataGridViewLeftSection_Jobs.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.JobDetailJobComponent).JobComponentNumber

                If _ReconcileMode Then

                    ProductionSummary = _ProductionSummaryList.Where(Function(F) F.JobNumber = JobNumber AndAlso F.ComponentNumber = JobComponentNumber).SingleOrDefault

                    If ProductionSummary IsNot Nothing Then

                        DataGridViewTop_JobComponentFunctions.DataSource = (From Entity In ProductionSummary.JobComponentFunctionDetails
                                                                            Where Not (Entity.ActualBillableAmount.GetValueOrDefault(0) = 0 AndAlso
                                                                                       Entity.BilledAmount.GetValueOrDefault(0) = 0 AndAlso
                                                                                       Entity.UnbilledAmount.GetValueOrDefault(0) = 0)
                                                                            Select Entity).OrderBy(Function(JCF) JCF.FunctionType).ThenBy(Function(JCF) JCF.FunctionDescription).ToList

                    End If

                    RefreshColumnOrderAndVisibilityReconcileMode()

                    If DataGridViewTop_JobComponentFunctions.Columns(AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.Reconcile.ToString) Is Nothing Then

                        DataGridViewTop_JobComponentFunctions.Columns.AddVisible(AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.Reconcile.ToString)

                    End If

                    DataGridViewTop_JobComponentFunctions.Columns(AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.Reconcile.ToString).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                    DataGridViewTop_JobComponentFunctions.Columns(AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.Reconcile.ToString).VisibleIndex = 0

                    DataGridViewTop_JobComponentFunctions.CurrentView.OptionsBehavior.Editable = If(ProductionSummary.ReconcileStatus = "2", False, True)

                Else

                    LayoutLoaded = AdvantageFramework.WinForm.Presentation.Controls.LoadDataGridViewLayout(Session, DataGridViewTop_JobComponentFunctions, Database.Entities.GridAdvantageType.BillingCommandCenterJobComponentFunctionDetail)

                    Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        DataGridViewTop_JobComponentFunctions.DataSource = AdvantageFramework.BillingCommandCenter.GetProductionSummaryByFunction(BCCDbContext,
                                        _BillingCommandCenterID, ButtonItemInclude_Contingency.Checked, JobNumber, JobComponentNumber)

                        If LayoutLoaded Then

                            AdvantageFramework.WinForm.Presentation.Controls.SortGridViewBySortedColumns(DataGridViewTop_JobComponentFunctions)

                        Else

                            DataGridViewTop_JobComponentFunctions.CurrentView.ClearSorting()
                            DataGridViewTop_JobComponentFunctions.CurrentView.BeginSort()
                            DataGridViewTop_JobComponentFunctions.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.FunctionType.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                            DataGridViewTop_JobComponentFunctions.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.FunctionDescription.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                            DataGridViewTop_JobComponentFunctions.CurrentView.EndSort()

                            SetColumnDefaultVisibility()

                        End If

                        DataGridViewLeftSection_Jobs.Tag = AdvantageFramework.BillingCommandCenter.GetReconcileStatus(BCCDbContext, JobNumber, JobComponentNumber)

                    End Using

                    DataGridViewTop_JobComponentFunctions.CurrentView.OptionsBehavior.Editable = True

                End If

                If DataGridViewTop_JobComponentFunctions.Columns(AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.BillingApprovalFunctionClientComment.ToString) IsNot Nothing Then

                    AddSubItemMemoItem(DataGridViewTop_JobComponentFunctions, DataGridViewTop_JobComponentFunctions.Columns(AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.BillingApprovalFunctionClientComment.ToString), Me.Session)

                End If

                If DataGridViewTop_JobComponentFunctions.Columns(AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.BillingApprovalFunctionComment.ToString) IsNot Nothing Then

                    AddSubItemMemoItem(DataGridViewTop_JobComponentFunctions, DataGridViewTop_JobComponentFunctions.Columns(AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.BillingApprovalFunctionComment.ToString), Me.Session)

                End If

                If String.IsNullOrWhiteSpace(AFActiveFilterString) = False Then

                    DataGridViewTop_JobComponentFunctions.CurrentView.AFActiveFilterString = AFActiveFilterString

                End If

                If SelectAll OrElse _ReconcileMode Then

                    DataGridViewTop_JobComponentFunctions.SelectAll()
                    ButtonItemFunctionGrid_SelectAll.Checked = True

                End If

                DataGridViewTop_JobComponentFunctions.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True

                If Not LayoutLoaded Then

                    DataGridViewTop_JobComponentFunctions.CurrentView.BestFitColumns()

                End If

                DataGridViewTop_JobComponentFunctions.ValidateAllRows()

                EnableOrDisableActions()

            End If

            If Not (Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem AndAlso (TabControlRightSection_FunctionItems.SelectedTab Is TabItemFunctionItems_AdvanceBilling OrElse
                                                                                                  TabControlRightSection_FunctionItems.SelectedTab Is TabItemFunctionItems_Documents OrElse
                                                                                                  TabControlRightSection_FunctionItems.SelectedTab Is TabItemFunctionItems_OpenPO)) AndAlso
                    Me.FormAction <> WinForm.Presentation.FormActions.Refreshing Then

                SetFunctionTab()

            End If

            Me.CloseWaitForm()

        End Sub
        Private Sub LoadEmployeeTime()

            'objects
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim SelectAll As Boolean = False
            Dim SelectedFunctionCodes As IEnumerable(Of String) = Nothing
            Dim JobNumber As Integer = Nothing
            Dim JobComponentNumber As Short = Nothing
            Dim ProductionSummary As AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary = Nothing
            Dim EmployeeTimeItemList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem) = Nothing
            Dim BillingCommandCenter As AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim LayoutLoaded As Boolean = False

            BindingSource = DataGridViewEmployeeTime_Details.DataSource

            If Not _ReconcileMode AndAlso BindingSource IsNot Nothing AndAlso BindingSource.DataSource IsNot Nothing Then

                AdvantageFramework.WinForm.Presentation.Controls.SaveDataGridViewLayout(Session, DataGridViewEmployeeTime_Details, AdvantageFramework.Database.Entities.GridAdvantageType.BillingCommandCenterJobComponentEmployeeTimeDetail)

            End If

            If DataGridViewEmployeeTime_Details.CurrentView.SelectedRowsCount > 1 AndAlso DataGridViewEmployeeTime_Details.CurrentView.RowCount = DataGridViewEmployeeTime_Details.CurrentView.SelectedRowsCount Then

                SelectAll = True

            End If

            DataGridViewEmployeeTime_Details.SetBookmarkColumnIndex(-1)
            DataGridViewEmployeeTime_Details.ClearGridCustomization()
            DataGridViewEmployeeTime_Details.ClearDatasource(New Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem))

            SelectedFunctionCodes = (From Entity In DataGridViewTop_JobComponentFunctions.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail).ToList
                                     Where Entity.FunctionType = "E"
                                     Select Entity.FunctionCode).ToList

            EmployeeTimeItemList = New Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem)

            JobNumber = DirectCast(DataGridViewLeftSection_Jobs.CurrentView.GetRow(DataGridViewLeftSection_Jobs.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.JobDetailJobComponent).JobNumber
            JobComponentNumber = DirectCast(DataGridViewLeftSection_Jobs.CurrentView.GetRow(DataGridViewLeftSection_Jobs.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.JobDetailJobComponent).JobComponentNumber

            If _ReconcileMode Then

                ProductionSummary = _ProductionSummaryList.Where(Function(PS) PS.JobNumber = JobNumber AndAlso PS.ComponentNumber = JobComponentNumber).FirstOrDefault

                If SelectedFunctionCodes.Count > 0 AndAlso ProductionSummary IsNot Nothing AndAlso ProductionSummary.EmployeeTimeItems IsNot Nothing Then

                    EmployeeTimeItemList.AddRange((From EmployeeTimeItem In ProductionSummary.EmployeeTimeItems
                                                   Where SelectedFunctionCodes.Contains(EmployeeTimeItem.FunctionCode) AndAlso
                                                         EmployeeTimeItem.IsNonBillable.GetValueOrDefault(0) = 0
                                                   Select EmployeeTimeItem).ToList)

                End If

                DataGridViewEmployeeTime_Details.DataSource = EmployeeTimeItemList

                SetColumnDefaultVisibilityEmployeeTimeReconcileMode()

                If DataGridViewEmployeeTime_Details.Columns(AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.Reconcile.ToString) IsNot Nothing Then

                    DataGridViewEmployeeTime_Details.Columns(AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.Reconcile.ToString).VisibleIndex = 0

                End If

                DataGridViewEmployeeTime_Details.CurrentView.OptionsBehavior.Editable = If(ProductionSummary.ReconcileStatus = "2", False, True)

            Else

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        BillingCommandCenter = AdvantageFramework.BillingCommandCenter.Database.Procedures.BillingCommandCenter.LoadByID(BCCDbContext, _BillingCommandCenterID)

                        If BillingCommandCenter IsNot Nothing AndAlso BillingCommandCenter.EmployeeTimeDateCutoff IsNot Nothing Then

                            EmployeeTimeItemList.AddRange(AdvantageFramework.BillingCommandCenter.GetEmployeeTimeItems(BCCDbContext, JobNumber, JobComponentNumber, SelectedFunctionCodes, BillingCommandCenter.EmployeeTimeDateCutoff, BillingCommandCenter.IsProductionSelectionLocked))

                        End If

                    End Using

                End Using

                LayoutLoaded = AdvantageFramework.WinForm.Presentation.Controls.LoadDataGridViewLayout(Session, DataGridViewEmployeeTime_Details, Database.Entities.GridAdvantageType.BillingCommandCenterJobComponentEmployeeTimeDetail)

                DataGridViewEmployeeTime_Details.DataSource = EmployeeTimeItemList.ToList

                If LayoutLoaded Then

                    AdvantageFramework.WinForm.Presentation.Controls.SortGridViewBySortedColumns(DataGridViewEmployeeTime_Details)

                Else

                    SetColumnDefaultVisibilityEmployeeTime(_InvoiceTaxFlag)

                    DataGridViewEmployeeTime_Details.CurrentView.ClearSorting()
                    DataGridViewEmployeeTime_Details.CurrentView.BeginSort()
                    DataGridViewEmployeeTime_Details.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.FunctionDescription.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                    DataGridViewEmployeeTime_Details.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.EmployeeDate.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                    DataGridViewEmployeeTime_Details.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.EmployeeName.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                    DataGridViewEmployeeTime_Details.CurrentView.EndSort()

                End If

                If ButtonItemEmployeeTime_HideNonBillable.Checked Then

                    ApplyEmployeeTimeBillableFilter()

                End If

                If _InvoiceTaxFlag Then

                    For Each GridColumn In DataGridViewEmployeeTime_Details.Columns

                        If GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.SalesTaxCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.TaxCommission.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.TaxCommissionOnly.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.SalesTaxStatePercentage.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.SalesTaxCountyPercentage.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.SalesTaxCityPercentage.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.StateResaleAmount.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.CountyResaleAmount.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.CityResaleAmount.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.IsResaleTax.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.ResaleTax.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.LineTotal.ToString Then

                            GridColumn.Visible = False
                            GridColumn.OptionsColumn.ShowInCustomizationForm = False

                        End If

                    Next

                End If

                For Each GridColumn In DataGridViewEmployeeTime_Details.Columns

                    If GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.BillableRate.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.CommissionPercentage.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.MarkupAmount.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.IsNonBillable.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.IsBillOnHold.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.FeeTimeType.ToString Then

                        GridColumn.OptionsColumn.AllowShowHide = False

                    ElseIf GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.TaskCode.ToString Then

                        GridColumn.Visible = _ShowEmployeeTimeTaskCode
                        GridColumn.OptionsColumn.ShowInCustomizationForm = _ShowEmployeeTimeTaskCode

                    End If

                Next

                If DataGridViewEmployeeTime_Details.Columns(AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.IsNonBillable.ToString) IsNot Nothing Then

                    DataGridViewEmployeeTime_Details.Columns(AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.IsNonBillable.ToString).OptionsFilter.AllowFilter = False

                End If

                ButtonItemEmployeeTime_HideNonBillable.Checked = GetUserSetting(AdvantageFramework.Security.UserSettings.BCCHideNonBillableFunctionsEmployeeTime.ToString)

            End If

            If SelectAll Then

                DataGridViewEmployeeTime_Details.SelectAll()

            End If

            ApplyGroupingEmployeeTime()

            If Not LayoutLoaded Then

                DataGridViewEmployeeTime_Details.CurrentView.BestFitColumns()

            End If

            If DataGridViewEmployeeTime_Details.CurrentView.VisibleColumns.Count >= 1 Then

                DataGridViewEmployeeTime_Details.CurrentView.VisibleColumns(0).Width = COLUMN_MIN_WIDTH_FOR_SELECTED_LABEL

            End If

            DataGridViewEmployeeTime_Details.OptionsMenu.EnableColumnMenu = True

            TabItemFunctionItems_EmployeeTime.Tag = True

        End Sub
        Private Sub ApplyGroupingAP()

            Try

                DataGridViewVendor_Details.OptionsView.ShowGroupedColumns = True
                DataGridViewVendor_Details.Columns(AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.FunctionDescription.ToString).GroupIndex = 0
                DataGridViewVendor_Details.CurrentView.ExpandAllGroups()

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ApplyGroupingEmployeeTime()

            Try

                DataGridViewEmployeeTime_Details.OptionsView.ShowGroupedColumns = True
                DataGridViewEmployeeTime_Details.Columns(AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.FunctionDescription.ToString).GroupIndex = 0
                DataGridViewEmployeeTime_Details.CurrentView.ExpandAllGroups()

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ApplyGroupingIncomeOnly()

            Try

                DataGridViewIncomeOnly_Details.OptionsView.ShowGroupedColumns = True
                DataGridViewIncomeOnly_Details.Columns(AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.FunctionDescription.ToString).GroupIndex = 0
                DataGridViewIncomeOnly_Details.CurrentView.ExpandAllGroups()

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ApplyEmployeeTimeBillableFilter()

            DataGridViewEmployeeTime_Details.Columns(AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.IsNonBillable.ToString).FilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo("[IsNonBillable] IS NULL OR [IsNonBillable] = 0", "Billable = 'Yes'")

        End Sub
        Private Sub ApplyIncomeOnlyBillableFilter()

            DataGridViewIncomeOnly_Details.Columns(AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.IsNonBillable.ToString).FilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo("[IsNonBillable] = False")

        End Sub
        Private Sub ApplyVendorAPBillableFilter()

            DataGridViewVendor_Details.Columns(AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.IsNonBillable.ToString).FilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo("[IsNonBillable] = 0", "Billable = 'Yes'")

        End Sub
        Private Sub LoadVendorAccountPayableProduction()

            'objects
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim SelectAll As Boolean = False
            Dim SelectedFunctionCodes As IEnumerable(Of String) = Nothing
            Dim JobNumber As Integer = Nothing
            Dim JobComponentNumber As Short = Nothing
            Dim ProductionSummary As AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary = Nothing
            Dim AccountPayableProductionItemList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem) = Nothing
            Dim BillingCommandCenter As AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter = Nothing
            Dim LayoutLoaded As Boolean = False

            BindingSource = DataGridViewVendor_Details.DataSource

            If Not _ReconcileMode AndAlso BindingSource IsNot Nothing AndAlso BindingSource.DataSource IsNot Nothing Then

                AdvantageFramework.WinForm.Presentation.Controls.SaveDataGridViewLayout(Session, DataGridViewVendor_Details, AdvantageFramework.Database.Entities.GridAdvantageType.BillingCommandCenterJobComponentVendorDetail)

            End If

            If DataGridViewVendor_Details.CurrentView.SelectedRowsCount > 1 AndAlso DataGridViewVendor_Details.CurrentView.RowCount = DataGridViewVendor_Details.CurrentView.SelectedRowsCount Then

                SelectAll = True

            End If

            DataGridViewVendor_Details.SetBookmarkColumnIndex(-1)
            DataGridViewVendor_Details.ClearGridCustomization()
            DataGridViewVendor_Details.ClearDatasource(New Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem))

            SelectedFunctionCodes = (From Entity In DataGridViewTop_JobComponentFunctions.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail).ToList
                                     Where Entity.FunctionType = "V"
                                     Select Entity.FunctionCode).ToList

            AccountPayableProductionItemList = New Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem)

            JobNumber = DirectCast(DataGridViewLeftSection_Jobs.CurrentView.GetRow(DataGridViewLeftSection_Jobs.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.JobDetailJobComponent).JobNumber
            JobComponentNumber = DirectCast(DataGridViewLeftSection_Jobs.CurrentView.GetRow(DataGridViewLeftSection_Jobs.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.JobDetailJobComponent).JobComponentNumber

            If _ReconcileMode Then

                ProductionSummary = _ProductionSummaryList.Where(Function(PS) PS.JobNumber = JobNumber AndAlso PS.ComponentNumber = JobComponentNumber).FirstOrDefault

                If SelectedFunctionCodes.Count > 0 AndAlso ProductionSummary IsNot Nothing AndAlso ProductionSummary.AccountPayableProductionItems IsNot Nothing Then

                    AccountPayableProductionItemList.AddRange((From AccountPayableProductionItem In ProductionSummary.AccountPayableProductionItems
                                                               Where SelectedFunctionCodes.Contains(AccountPayableProductionItem.FunctionCode) AndAlso
                                                                     AccountPayableProductionItem.IsNonBillable.GetValueOrDefault(0) = 0
                                                               Select AccountPayableProductionItem).ToList)

                End If

                DataGridViewVendor_Details.DataSource = AccountPayableProductionItemList.ToList

                SetColumnDefaultVisibilityVendorAPReconcileMode()

                If DataGridViewVendor_Details.Columns(AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.Reconcile.ToString) IsNot Nothing Then

                    DataGridViewVendor_Details.Columns(AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.Reconcile.ToString).VisibleIndex = 0

                End If

                DataGridViewVendor_Details.CurrentView.OptionsBehavior.Editable = If(ProductionSummary.ReconcileStatus = "2", False, True)

            Else

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        BillingCommandCenter = AdvantageFramework.BillingCommandCenter.Database.Procedures.BillingCommandCenter.LoadByID(BCCDbContext, _BillingCommandCenterID)

                        If BillingCommandCenter IsNot Nothing AndAlso BillingCommandCenter.APPostPeriodCodeCutoff IsNot Nothing Then

                            AccountPayableProductionItemList.AddRange(AdvantageFramework.BillingCommandCenter.GetAccountPayableProductionItems(BCCDbContext, JobNumber, JobComponentNumber, SelectedFunctionCodes, BillingCommandCenter.APPostPeriodCodeCutoff, AdvantageFramework.BillingCommandCenter.Methods.ProductionSelectFor.BCCJobDetailGrid, BillingCommandCenter.IsProductionSelectionLocked))

                        End If

                    End Using

                End Using

                LayoutLoaded = AdvantageFramework.WinForm.Presentation.Controls.LoadDataGridViewLayout(Session, DataGridViewVendor_Details, Database.Entities.GridAdvantageType.BillingCommandCenterJobComponentVendorDetail)

                DataGridViewVendor_Details.DataSource = AccountPayableProductionItemList.ToList

                If ButtonItemVendor_HideNonBillable.Checked Then

                    ApplyVendorAPBillableFilter()

                End If

                If LayoutLoaded Then

                    AdvantageFramework.WinForm.Presentation.Controls.SortGridViewBySortedColumns(DataGridViewVendor_Details)

                Else

                    SetColumnDefaultVisibilityVendorAP(_InvoiceTaxFlag)

                    DataGridViewVendor_Details.CurrentView.ClearSorting()
                    DataGridViewVendor_Details.CurrentView.BeginSort()
                    DataGridViewVendor_Details.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.FunctionDescription.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                    DataGridViewVendor_Details.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.InvoiceDate.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                    DataGridViewVendor_Details.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.LineNumber.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                    DataGridViewVendor_Details.CurrentView.EndSort()

                End If

                If _InvoiceTaxFlag Then

                    For Each GridColumn In DataGridViewVendor_Details.Columns

                        If GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.TaxCommissions.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.TaxCommissionsOnly.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.StateTaxPercent.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.CountyTaxPercent.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.CityTaxPercent.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.ExtendedStateResale.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.ExtendedCountyResale.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.ExtendedCityResale.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.ResaleTax.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.SalesTaxCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.IsResaleTax.ToString Then

                            GridColumn.Visible = False
                            GridColumn.OptionsColumn.ShowInCustomizationForm = False

                        End If

                    Next

                End If

                For Each GridColumn In DataGridViewVendor_Details.CurrentView.Columns

                    If GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.CommissionPercent.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.ExtendedMarkupAmount.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.IsBillOnHold.ToString Then

                        GridColumn.OptionsColumn.AllowShowHide = False

                    End If

                Next

                If DataGridViewVendor_Details.Columns(AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.IsNonBillable.ToString) IsNot Nothing Then

                    DataGridViewVendor_Details.Columns(AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.IsNonBillable.ToString).OptionsFilter.AllowFilter = False

                End If

                ButtonItemVendor_HideNonBillable.Checked = GetUserSetting(AdvantageFramework.Security.UserSettings.BCCHideNonBillableFunctionsVendor.ToString)

            End If

            If SelectAll Then

                DataGridViewVendor_Details.SelectAll()

            End If

            ApplyGroupingAP()

            If Not LayoutLoaded Then

                DataGridViewVendor_Details.CurrentView.BestFitColumns()

            End If

            If DataGridViewVendor_Details.CurrentView.VisibleColumns.Count >= 1 Then

                DataGridViewVendor_Details.CurrentView.VisibleColumns(0).Width = COLUMN_MIN_WIDTH_FOR_SELECTED_LABEL

            End If

            DataGridViewVendor_Details.OptionsMenu.EnableColumnMenu = True

            TabItemFunctionItems_Vendor.Tag = True

        End Sub
        Private Sub LoadIncomeOnly()

            'objects
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim SelectAll As Boolean = False
            Dim SelectedFunctionCodes As IEnumerable(Of String) = Nothing
            Dim JobNumber As Integer = Nothing
            Dim JobComponentNumber As Short = Nothing
            Dim ProductionSummary As AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary = Nothing
            Dim IncomeOnlyItemList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem) = Nothing
            Dim BillingCommandCenter As AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter = Nothing
            Dim LayoutLoaded As Boolean = False

            BindingSource = DataGridViewIncomeOnly_Details.DataSource

            If Not _ReconcileMode AndAlso BindingSource IsNot Nothing AndAlso BindingSource.DataSource IsNot Nothing Then

                AdvantageFramework.WinForm.Presentation.Controls.SaveDataGridViewLayout(Session, DataGridViewIncomeOnly_Details, AdvantageFramework.Database.Entities.GridAdvantageType.BillingCommandCenterJobComponentIncomeOnlyDetail)

            End If

            If DataGridViewIncomeOnly_Details.CurrentView.SelectedRowsCount > 1 AndAlso DataGridViewIncomeOnly_Details.CurrentView.RowCount = DataGridViewIncomeOnly_Details.CurrentView.SelectedRowsCount Then

                SelectAll = True

            End If

            DataGridViewIncomeOnly_Details.SetBookmarkColumnIndex(-1)
            DataGridViewIncomeOnly_Details.ClearGridCustomization()
            DataGridViewIncomeOnly_Details.ClearDatasource(New Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem))

            SelectedFunctionCodes = (From Entity In DataGridViewTop_JobComponentFunctions.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail).ToList
                                     Where Entity.FunctionType = "I"
                                     Select Entity.FunctionCode).ToList

            IncomeOnlyItemList = New Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem)

            JobNumber = DirectCast(DataGridViewLeftSection_Jobs.CurrentView.GetRow(DataGridViewLeftSection_Jobs.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.JobDetailJobComponent).JobNumber
            JobComponentNumber = DirectCast(DataGridViewLeftSection_Jobs.CurrentView.GetRow(DataGridViewLeftSection_Jobs.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.JobDetailJobComponent).JobComponentNumber

            If _ReconcileMode Then

                ProductionSummary = _ProductionSummaryList.Where(Function(PS) PS.JobNumber = JobNumber AndAlso PS.ComponentNumber = JobComponentNumber).FirstOrDefault

                If SelectedFunctionCodes.Count > 0 AndAlso ProductionSummary IsNot Nothing AndAlso ProductionSummary.IncomeOnlyItems IsNot Nothing Then

                    IncomeOnlyItemList.AddRange((From IncomeOnlyItem In ProductionSummary.IncomeOnlyItems
                                                 Where SelectedFunctionCodes.Contains(IncomeOnlyItem.FunctionCode) AndAlso
                                                       IncomeOnlyItem.IsNonBillable = False
                                                 Select IncomeOnlyItem).ToList)

                End If

                DataGridViewIncomeOnly_Details.DataSource = IncomeOnlyItemList.ToList

                SetColumnDefaultVisibilityIncomeOnlyReconcileMode()

                If DataGridViewIncomeOnly_Details.Columns(AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.Reconcile.ToString) IsNot Nothing Then

                    DataGridViewIncomeOnly_Details.Columns(AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.Reconcile.ToString).VisibleIndex = 0

                End If

                DataGridViewIncomeOnly_Details.CurrentView.OptionsBehavior.Editable = If(ProductionSummary.ReconcileStatus = "2", False, True)

            Else

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        BillingCommandCenter = AdvantageFramework.BillingCommandCenter.Database.Procedures.BillingCommandCenter.LoadByID(BCCDbContext, _BillingCommandCenterID)

                        If BillingCommandCenter IsNot Nothing AndAlso BillingCommandCenter.IncomeOnlyDateCutoff IsNot Nothing Then

                            IncomeOnlyItemList.AddRange(AdvantageFramework.BillingCommandCenter.GetIncomeOnlyItems(BCCDbContext, JobNumber, JobComponentNumber, SelectedFunctionCodes, BillingCommandCenter.IncomeOnlyDateCutoff, BillingCommandCenter.IsProductionSelectionLocked, AdvantageFramework.BillingCommandCenter.IncomeOnlySelectFor.BCCJobDetailGrid))

                        End If

                    End Using

                End Using

                LayoutLoaded = AdvantageFramework.WinForm.Presentation.Controls.LoadDataGridViewLayout(Session, DataGridViewIncomeOnly_Details, Database.Entities.GridAdvantageType.BillingCommandCenterJobComponentIncomeOnlyDetail)

                DataGridViewIncomeOnly_Details.DataSource = IncomeOnlyItemList.ToList

                If ButtonItemIncomeOnly_HideNonBillable.Checked Then

                    ApplyIncomeOnlyBillableFilter()

                End If

                If LayoutLoaded Then

                    AdvantageFramework.WinForm.Presentation.Controls.SortGridViewBySortedColumns(DataGridViewIncomeOnly_Details)

                Else

                    SetColumnDefaultVisibilityIncomeOnly(_InvoiceTaxFlag)

                    DataGridViewIncomeOnly_Details.CurrentView.ClearSorting()
                    DataGridViewIncomeOnly_Details.CurrentView.BeginSort()
                    DataGridViewIncomeOnly_Details.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.FunctionDescription.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                    DataGridViewIncomeOnly_Details.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.InvoiceDate.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                    DataGridViewIncomeOnly_Details.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.ID.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                    DataGridViewIncomeOnly_Details.CurrentView.EndSort()

                End If

                If _InvoiceTaxFlag Then

                    For Each GridColumn In DataGridViewIncomeOnly_Details.Columns

                        If GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.SalesTaxCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.TaxCommission.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.TaxCommissionOnly.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.StateTaxPercent.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.CountyTaxPercent.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.CityTaxPercent.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.StateResaleTaxAmount.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.CountyResaleTaxAmount.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.CityResaleTaxAmount.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.IsResaleTax.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.TotalTax.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.LineTotal.ToString Then

                            GridColumn.Visible = False
                            GridColumn.OptionsColumn.ShowInCustomizationForm = False

                        End If

                    Next

                End If

                For Each GridColumn In DataGridViewIncomeOnly_Details.CurrentView.Columns

                    If GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.Rate.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.Amount.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.CommissionPercent.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.MarkupAmount.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.IsNonBillable.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.IsBillOnHold.ToString Then

                        GridColumn.OptionsColumn.AllowShowHide = False

                    End If

                Next

                If DataGridViewIncomeOnly_Details.Columns(AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.IsNonBillable.ToString) IsNot Nothing Then

                    DataGridViewIncomeOnly_Details.Columns(AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.IsNonBillable.ToString).OptionsFilter.AllowFilter = False

                End If

                ButtonItemIncomeOnly_HideNonBillable.Checked = GetUserSetting(AdvantageFramework.Security.UserSettings.BCCHideNonBillableFunctionsIncomeOnly.ToString)

            End If

            If SelectAll Then

                DataGridViewIncomeOnly_Details.SelectAll()

            End If

            ApplyGroupingIncomeOnly()

            If Not LayoutLoaded Then

                DataGridViewIncomeOnly_Details.CurrentView.BestFitColumns()

            End If

            If DataGridViewIncomeOnly_Details.CurrentView.VisibleColumns.Count >= 1 Then

                DataGridViewIncomeOnly_Details.CurrentView.VisibleColumns(0).Width = COLUMN_MIN_WIDTH_FOR_SELECTED_LABEL

            End If

            DataGridViewIncomeOnly_Details.OptionsMenu.EnableColumnMenu = True

            TabItemFunctionItems_IncomeOnly.Tag = True

        End Sub
        Private Sub LoadFunctionItems()

            If DataGridViewLeftSection_Jobs.HasOnlyOneSelectedRow AndAlso TabControlRightSection_FunctionItems.SelectedTab.Tag = False Then

                If TabControlRightSection_FunctionItems.SelectedTab Is TabItemFunctionItems_EmployeeTime Then

                    LoadEmployeeTime()

                ElseIf TabControlRightSection_FunctionItems.SelectedTab Is TabItemFunctionItems_IncomeOnly Then

                    LoadIncomeOnly()

                ElseIf TabControlRightSection_FunctionItems.SelectedTab Is TabItemFunctionItems_Vendor Then

                    LoadVendorAccountPayableProduction()

                ElseIf TabControlRightSection_FunctionItems.SelectedTab Is TabItemFunctionItems_Documents Then

                    LoadDocuments()

                ElseIf TabControlRightSection_FunctionItems.SelectedTab Is TabItemFunctionItems_AdvanceBilling Then

                    LoadAdvanceBilling()

                ElseIf TabControlRightSection_FunctionItems.SelectedTab Is TabItemFunctionItems_OpenPO Then

                    LoadOpenPO()

                End If

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub EmployeeTimeRecalculateRow(ByVal EmployeeTimeItem As AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem,
                                               Optional ByVal BypassMarkupCalculation As Boolean = False)

            'objects
            Dim Amount As Decimal = 0
            Dim TaxableAmount As Decimal = 0

            Amount = FormatNumber(EmployeeTimeItem.BillableRate * EmployeeTimeItem.Hours, 2)

            EmployeeTimeItem.TotalBill = Amount

            If Not BypassMarkupCalculation Then

                EmployeeTimeItem.MarkupAmount = FormatNumber(EmployeeTimeItem.CommissionPercentage * Amount / 100, 2)

            End If

            If EmployeeTimeItem.TaxCommissionOnly.GetValueOrDefault(0) = 1 Then

                TaxableAmount = EmployeeTimeItem.MarkupAmount

            ElseIf EmployeeTimeItem.TaxCommission.GetValueOrDefault(0) = 1 Then

                TaxableAmount = EmployeeTimeItem.MarkupAmount + Amount

            Else

                TaxableAmount = Amount

            End If

            EmployeeTimeItem.StateResaleAmount = FormatNumber(EmployeeTimeItem.SalesTaxStatePercentage * TaxableAmount / 100, 2)
            EmployeeTimeItem.CountyResaleAmount = FormatNumber(EmployeeTimeItem.SalesTaxCountyPercentage * TaxableAmount / 100, 2)
            EmployeeTimeItem.CityResaleAmount = FormatNumber(EmployeeTimeItem.SalesTaxCityPercentage * TaxableAmount / 100, 2)

        End Sub
        Private Function EmployeeTimeGetComment(ByVal EmployeeTimeItem As AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem,
                                                ByVal EmployeeTimeDetail As AdvantageFramework.Database.Entities.EmployeeTimeDetail) As String

            'objects
            Dim Comment As System.Text.StringBuilder = Nothing

            Comment = New System.Text.StringBuilder()

            If String.IsNullOrWhiteSpace(EmployeeTimeDetail.AdjusterComments) = False Then

                Comment.Append(EmployeeTimeDetail.AdjusterComments)

            End If

            If EmployeeTimeDetail.BillableRate.GetValueOrDefault(0) <> EmployeeTimeItem.BillableRate Then

                Comment.Append(String.Format("- Billing rate manually changed from {0} to {1} - {2} by {3}",
                                                                     EmployeeTimeDetail.BillableRate.GetValueOrDefault(0).ToString,
                                                                     EmployeeTimeItem.BillableRate.ToString,
                                                                     Now.ToString,
                                                                     Session.UserCode))

            End If

            If EmployeeTimeDetail.CommissionPercentage.GetValueOrDefault(0) <> EmployeeTimeItem.CommissionPercentage AndAlso EmployeeTimeItem.MarkupPercentChanged Then

                Comment.Append(String.Format("- Markup % adjusted from {0} to {1} - {2} by {3}",
                                                                     EmployeeTimeDetail.CommissionPercentage.GetValueOrDefault(0).ToString,
                                                                     EmployeeTimeItem.CommissionPercentage.ToString,
                                                                     Now.ToString,
                                                                     Session.UserCode))

            End If

            If EmployeeTimeDetail.MarkupAmount.GetValueOrDefault(0) <> EmployeeTimeItem.MarkupAmount AndAlso EmployeeTimeItem.MarkupAmountChanged Then

                Comment.Append(String.Format("- Markup amount adjusted from {0} to {1} - {2} by {3}",
                                                                     EmployeeTimeDetail.MarkupAmount.GetValueOrDefault(0).ToString,
                                                                     EmployeeTimeItem.MarkupAmount.ToString,
                                                                     Now.ToString,
                                                                     Session.UserCode))

            End If

            If EmployeeTimeDetail.SalesTaxCode <> EmployeeTimeItem.SalesTaxCode AndAlso EmployeeTimeItem.TaxCodeChanged Then

                Comment.Append(String.Format("- Tax code changed from {0} to {1} - {2} by {3}",
                                                                     If(EmployeeTimeDetail.SalesTaxCode IsNot Nothing, EmployeeTimeDetail.SalesTaxCode.ToString, ""),
                                                                     If(EmployeeTimeItem.SalesTaxCode IsNot Nothing, EmployeeTimeItem.SalesTaxCode.ToString, ""),
                                                                     Now.ToString,
                                                                     Session.UserCode))

            End If

            If (EmployeeTimeDetail.StateResaleAmount.GetValueOrDefault(0) <> EmployeeTimeItem.StateResaleAmount OrElse
                    EmployeeTimeDetail.CountyResaleAmount.GetValueOrDefault(0) <> EmployeeTimeItem.CountyResaleAmount OrElse
                    EmployeeTimeDetail.CityResaleAmount.GetValueOrDefault(0) <> EmployeeTimeItem.CityResaleAmount) AndAlso
                    EmployeeTimeItem.TaxAmountChanged Then

                Comment.Append(" " & Now.ToShortDateString & " User: " & Session.UserCode & ":- Tax amount changed.")

            End If

            If EmployeeTimeDetail.IsNonBillable.GetValueOrDefault(0) <> EmployeeTimeItem.IsNonBillable.GetValueOrDefault(0) Then

                Comment.Append(String.Format("- Manually changed from {0} to {1} - {2} by {3}",
                                                                     If(EmployeeTimeDetail.IsNonBillable.GetValueOrDefault(0) = 0, "billable", "non-billable"),
                                                                     If(EmployeeTimeItem.IsNonBillable.GetValueOrDefault(0) = 0, "billable", "non-billable"),
                                                                     Now.ToString,
                                                                     Session.UserCode))

            End If

            If EmployeeTimeDetail.FeeTimeType.GetValueOrDefault(0) <> EmployeeTimeItem.FeeTimeType Then

                Comment.Append(" " & Now.ToShortDateString & " User: " & Session.UserCode & ":- Fee time changed.")

            End If

            If EmployeeTimeDetail.IsBillOnHold.GetValueOrDefault(0) <> EmployeeTimeItem.IsBillOnHold.GetValueOrDefault(0) Then

                Comment.Append(" " & Now.ToShortDateString & " User: " & Session.UserCode & ":- Bill hold changed.")

            End If

            EmployeeTimeGetComment = Comment.ToString.Trim

        End Function
        Private Sub SaveEmployeeTime(ByVal DbContext As AdvantageFramework.Database.DbContext)

            'objects 
            Dim JobNumber As Integer = Nothing
            Dim JobComponentNumber As Short = Nothing
            Dim EmployeeTimeItemList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem) = Nothing
            Dim EmployeeTimeDetail As AdvantageFramework.Database.Entities.EmployeeTimeDetail = Nothing
            Dim EmployeeTimeComment As AdvantageFramework.Database.Entities.EmployeeTimeComment = Nothing
            Dim EmployeeTimeSource As String = "D"
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim ABFlag As Nullable(Of Short) = Nothing

            JobNumber = DirectCast(DataGridViewLeftSection_Jobs.CurrentView.GetRow(DataGridViewLeftSection_Jobs.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.JobDetailJobComponent).JobNumber
            JobComponentNumber = DirectCast(DataGridViewLeftSection_Jobs.CurrentView.GetRow(DataGridViewLeftSection_Jobs.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.JobDetailJobComponent).JobComponentNumber

            JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNumber)

            If JobComponent IsNot Nothing Then

                ABFlag = JobComponent.IsAdvanceBilling

            End If

            EmployeeTimeItemList = DataGridViewEmployeeTime_Details.GetAllModifiedRows.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem)().ToList

            For Each EmployeeTimeItem In EmployeeTimeItemList

                EmployeeTimeDetail = (From ET In AdvantageFramework.Database.Procedures.EmployeeTimeDetail.LoadByEmployeeTimeID(DbContext, EmployeeTimeItem.EmployeeTimeID)
                                      Where ET.SequenceNumber = EmployeeTimeItem.SequenceNumber
                                      Select ET).SingleOrDefault

                If EmployeeTimeDetail Is Nothing Then

                    Throw New Exception("Cannot find employee time detail.")

                End If

                If EmployeeTimeDetail.BillableRate.GetValueOrDefault(0) <> EmployeeTimeItem.BillableRate OrElse
                        EmployeeTimeDetail.MarkupAmount.GetValueOrDefault(0) <> EmployeeTimeItem.MarkupAmount OrElse
                        EmployeeTimeDetail.CommissionPercentage.GetValueOrDefault(0) <> EmployeeTimeItem.CommissionPercentage OrElse
                        EmployeeTimeDetail.SalesTaxCode <> EmployeeTimeItem.SalesTaxCode OrElse
                        EmployeeTimeDetail.CityResaleAmount.GetValueOrDefault(0) <> EmployeeTimeItem.CityResaleAmount OrElse
                        EmployeeTimeDetail.StateResaleAmount.GetValueOrDefault(0) <> EmployeeTimeItem.StateResaleAmount OrElse
                        EmployeeTimeDetail.CountyResaleAmount.GetValueOrDefault(0) <> EmployeeTimeItem.CountyResaleAmount OrElse
                        EmployeeTimeDetail.IsNonBillable.GetValueOrDefault(0) <> EmployeeTimeItem.IsNonBillable.GetValueOrDefault(0) OrElse
                        EmployeeTimeDetail.FeeTimeType.GetValueOrDefault(0) <> EmployeeTimeItem.FeeTimeType OrElse
                        EmployeeTimeDetail.IsBillOnHold.GetValueOrDefault(0) <> EmployeeTimeItem.IsBillOnHold.GetValueOrDefault(0) OrElse
                        EmployeeTimeDetail.TaskCode <> EmployeeTimeItem.TaskCode Then

                    EmployeeTimeDetail.IsAdvancedBill = ABFlag

                    EmployeeTimeDetail.AdjusterComments = EmployeeTimeGetComment(EmployeeTimeItem, EmployeeTimeDetail)
                    EmployeeTimeDetail.AdjustmentUserCode = DbContext.UserCode
                    EmployeeTimeDetail.AdjustmentDate = Now

                    EmployeeTimeDetail.BillableRate = EmployeeTimeItem.BillableRate
                    EmployeeTimeDetail.SalesTaxCode = EmployeeTimeItem.SalesTaxCode
                    EmployeeTimeDetail.CommissionPercentage = EmployeeTimeItem.CommissionPercentage
                    EmployeeTimeDetail.SalesTaxStatePercentage = EmployeeTimeItem.SalesTaxStatePercentage
                    EmployeeTimeDetail.SalesTaxCountyPercentage = EmployeeTimeItem.SalesTaxCountyPercentage
                    EmployeeTimeDetail.SalesTaxCityPercentage = EmployeeTimeItem.SalesTaxCityPercentage
                    EmployeeTimeDetail.TaxCommission = EmployeeTimeItem.TaxCommission
                    EmployeeTimeDetail.TaxCommissionOnly = EmployeeTimeItem.TaxCommissionOnly
                    EmployeeTimeDetail.Hours = EmployeeTimeItem.Hours
                    EmployeeTimeDetail.IsNonBillable = EmployeeTimeItem.IsNonBillable
                    EmployeeTimeDetail.EmployeeRateFrom = "Billing Adjustments"

                    EmployeeTimeDetail.MarkupAmount = EmployeeTimeItem.MarkupAmount
                    EmployeeTimeDetail.StateResaleAmount = EmployeeTimeItem.StateResaleAmount
                    EmployeeTimeDetail.CountyResaleAmount = EmployeeTimeItem.CountyResaleAmount
                    EmployeeTimeDetail.CityResaleAmount = EmployeeTimeItem.CityResaleAmount
                    EmployeeTimeDetail.TotalBilledAmount = FormatNumber(EmployeeTimeDetail.Hours * EmployeeTimeDetail.BillableRate, 2)
                    EmployeeTimeDetail.TotalCostAmount = FormatNumber(EmployeeTimeDetail.Hours * EmployeeTimeDetail.CostRate.GetValueOrDefault(0), 2)
                    EmployeeTimeDetail.SalesTaxResale = EmployeeTimeItem.IsResaleTax
                    EmployeeTimeDetail.FeeTimeType = EmployeeTimeItem.FeeTimeType
                    EmployeeTimeDetail.IsBillOnHold = If(EmployeeTimeItem.IsBillOnHold = AdvantageFramework.BillingCommandCenter.ProductionBillHoldStatus.Clear, Nothing, EmployeeTimeItem.IsBillOnHold)

                    EmployeeTimeDetail.TotalAmount = EmployeeTimeDetail.TotalBilledAmount.GetValueOrDefault(0) + EmployeeTimeDetail.MarkupAmount.GetValueOrDefault(0) +
                        EmployeeTimeDetail.StateResaleAmount.GetValueOrDefault(0) + EmployeeTimeDetail.CountyResaleAmount.GetValueOrDefault(0) + EmployeeTimeDetail.CityResaleAmount.GetValueOrDefault(0)

                    EmployeeTimeDetail.TaskCode = EmployeeTimeItem.TaskCode

                    If AdvantageFramework.Database.Procedures.EmployeeTimeDetail.Update(DbContext, EmployeeTimeDetail) = False Then

                        Throw New Exception("Failed to update EmployeeTimeDetail.")

                    End If

                End If

                EmployeeTimeComment = AdvantageFramework.Database.Procedures.EmployeeTimeComment.LoadByEmployeeTimeIDAndEmployeeTimeDetailIDAndSequenceNumberAndEmployeeTimeSource(DbContext, EmployeeTimeItem.EmployeeTimeID, EmployeeTimeItem.EmployeeTimeDetailID, EmployeeTimeItem.SequenceNumber, EmployeeTimeSource)

                If EmployeeTimeComment IsNot Nothing Then

                    If String.IsNullOrWhiteSpace(EmployeeTimeItem.Comment) Then

                        If AdvantageFramework.Database.Procedures.EmployeeTimeComment.Delete(DbContext, EmployeeTimeComment) = False Then

                            Throw New Exception("Failed to delete EmployeeTimeComment.")

                        End If

                    ElseIf EmployeeTimeItem.Comment <> EmployeeTimeComment.EmployeeComments Then

                        EmployeeTimeComment.EmployeeComments = EmployeeTimeItem.Comment

                        If AdvantageFramework.Database.Procedures.EmployeeTimeComment.Update(DbContext, EmployeeTimeComment) = False Then

                            Throw New Exception("Failed to update EmployeeTimeComment.")

                        End If

                    End If

                ElseIf String.IsNullOrWhiteSpace(EmployeeTimeItem.Comment) = False Then

                    EmployeeTimeComment = New AdvantageFramework.Database.Entities.EmployeeTimeComment
                    EmployeeTimeComment.DbContext = DbContext

                    EmployeeTimeComment.EmployeeTimeID = EmployeeTimeItem.EmployeeTimeID
                    EmployeeTimeComment.EmployeeTimeDetailID = EmployeeTimeItem.EmployeeTimeDetailID
                    EmployeeTimeComment.SequenceNumber = EmployeeTimeItem.SequenceNumber
                    EmployeeTimeComment.EmployeeTimeSource = EmployeeTimeSource

                    EmployeeTimeComment.EmployeeComments = EmployeeTimeItem.Comment

                    If AdvantageFramework.Database.Procedures.EmployeeTimeComment.Insert(DbContext, EmployeeTimeComment) = False Then

                        Throw New Exception("Failed to insert EmployeeTimeComment.")

                    End If

                End If

            Next

        End Sub
        Private Function Save(ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Saved As Boolean = False

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Try

                        AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                        Me.ShowWaitForm("Saving...")

                        If TabControlRightSection_FunctionItems.SelectedTab Is TabItemFunctionItems_EmployeeTime Then

                            SaveEmployeeTime(DbContext)

                        ElseIf TabControlRightSection_FunctionItems.SelectedTab Is TabItemFunctionItems_IncomeOnly Then

                            SaveIncomeOnly(DbContext)

                        ElseIf TabControlRightSection_FunctionItems.SelectedTab Is TabItemFunctionItems_Vendor Then

                            SaveVendorAP(DbContext)

                        ElseIf TabControlRightSection_FunctionItems.SelectedTab Is TabItemFunctionItems_AdvanceBilling Then

                            SaveAdvanceBilling(DbContext, BCCDbContext)

                        End If

                        DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.BILLING SET INV_PROCESSED = 0 WHERE BILLING_USER = (SELECT BILLING_USER FROM dbo.BILLING_CMD_CENTER WHERE BCC_ID = {0})", _BillingCommandCenterID))

                        Saved = True

                        LoadBillingStatus()

                    Catch ex As Exception
                        ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                        ErrorMessage += vbCrLf & ex.Message
                    Finally

                        AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                        Me.CloseWaitForm()

                    End Try

                End Using

            End Using

            Save = Saved

        End Function
        Private Function ModifyBillable(ByVal EmployeeTimeItem As AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem, ByVal NonBillable As Boolean) As Boolean

            'objects
            Dim Modified As Boolean = False

            If NonBillable Then

                If EmployeeTimeItem.IsNonBillable <> CShort(1) Then

                    EmployeeTimeItem.IsNonBillable = CShort(1)
                    Modified = True

                End If

            Else

                If EmployeeTimeItem.IsNonBillable <> CShort(0) Then

                    EmployeeTimeItem.IsNonBillable = CShort(0)
                    Modified = True

                End If

                If EmployeeTimeItem.FeeTimeType <> AdvantageFramework.Database.Entities.FeeTimes.No Then

                    EmployeeTimeItem.FeeTimeType = AdvantageFramework.Database.Entities.FeeTimes.No
                    Modified = True

                End If

            End If

            ModifyBillable = Modified

        End Function
        Private Sub ModifyBillables(ByVal Billable As Boolean)

            'objects
            Dim EmployeeTimeItem As AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem = Nothing

            DataGridViewEmployeeTime_Details.CurrentView.CloseEditorForUpdating()

            For Each RowHandlesAndDataBoundItem In DataGridViewEmployeeTime_Details.GetAllSelectedRowsRowHandlesAndDataBoundItems

                Try

                    EmployeeTimeItem = RowHandlesAndDataBoundItem.Value

                Catch ex As Exception
                    EmployeeTimeItem = Nothing
                End Try

                If EmployeeTimeItem IsNot Nothing Then

                    If ModifyBillable(EmployeeTimeItem, Not Billable) Then

                        DataGridViewEmployeeTime_Details.AddToModifiedRows(RowHandlesAndDataBoundItem.Key)

                    End If

                End If

            Next

            DataGridViewEmployeeTime_Details.CurrentView.RefreshData()

            DataGridViewEmployeeTime_Details.SetUserEntryChanged()

            EnableOrDisableActions()

        End Sub
        Private Function ModifyFeeTime(ByVal EmployeeTimeItem As AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem, ByVal FeeTime As AdvantageFramework.Database.Entities.FeeTimes) As Boolean

            'objects
            Dim Modified As Boolean = False

            If EmployeeTimeItem.EmployeeTimeFlag = AdvantageFramework.Database.Classes.NonbilledEmployeeTimeComplex.EmployeeTimeFlags.Unbilled Then

                If EmployeeTimeItem.FeeTimeType <> FeeTime Then

                    EmployeeTimeItem.FeeTimeType = FeeTime

                    Modified = True

                End If

                If FeeTime <> Database.Entities.FeeTimes.No Then

                    EmployeeTimeItem.IsNonBillable = 1

                    Modified = True

                End If

            End If

            ModifyFeeTime = Modified

        End Function
        Private Sub ModifyFeeTimes(ByVal FeeTime As AdvantageFramework.Database.Entities.FeeTimes)

            'objects
            Dim EmployeeTimeItem As AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem = Nothing

            DataGridViewEmployeeTime_Details.CurrentView.CloseEditorForUpdating()

            For Each RowHandlesAndDataBoundItem In DataGridViewEmployeeTime_Details.GetAllSelectedRowsRowHandlesAndDataBoundItems

                Try

                    EmployeeTimeItem = RowHandlesAndDataBoundItem.Value

                Catch ex As Exception
                    EmployeeTimeItem = Nothing
                End Try

                If EmployeeTimeItem IsNot Nothing Then

                    If ModifyFeeTime(EmployeeTimeItem, FeeTime) Then

                        DataGridViewEmployeeTime_Details.AddToModifiedRows(RowHandlesAndDataBoundItem.Key)

                    End If

                End If

            Next

            DataGridViewEmployeeTime_Details.CurrentView.RefreshData()

            DataGridViewEmployeeTime_Details.SetUserEntryChanged()

            EnableOrDisableActions()

        End Sub
        Private Function CalculateResale(ByVal ExtendedAmount As Decimal, ByVal MarkupAmount As Decimal, ByVal TaxPercent As Decimal) As Decimal

            'objects
            Dim ResaleAmount As Decimal = Nothing

            Try

                ResaleAmount = Math.Round((ExtendedAmount + MarkupAmount) * (TaxPercent / 100), 2, MidpointRounding.AwayFromZero)

            Catch ex As Exception
                ResaleAmount = 0
            Finally
                CalculateResale = ResaleAmount
            End Try

        End Function
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True
            Dim ErrorMessage As String = ""

            If AdvantageFramework.WinForm.Presentation.Controls.CheckUserEntryChangedSetting(Me) Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    If IsValidToSave(ErrorMessage) Then

                        Me.ShowWaitForm("Saving...")

                        If Save(ErrorMessage) = False Then

                            IsOkay = False
                            AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                        End If

                        Me.CloseWaitForm()

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    End If

                Else

                    AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function
        Private Sub EmployeeTimeUpdateMarkupRate(ByVal NewMarkupPercent As Decimal)

            'objects
            Dim EmployeeTimeItem As AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem = Nothing

            DataGridViewEmployeeTime_Details.CurrentView.CloseEditorForUpdating()

            For Each RowHandlesAndDataBoundItem In DataGridViewEmployeeTime_Details.GetAllSelectedRowsRowHandlesAndDataBoundItems

                Try

                    EmployeeTimeItem = RowHandlesAndDataBoundItem.Value

                Catch ex As Exception
                    EmployeeTimeItem = Nothing
                End Try

                If EmployeeTimeItem IsNot Nothing Then

                    EmployeeTimeItem.CommissionPercentage = NewMarkupPercent

                    EmployeeTimeRecalculateRow(EmployeeTimeItem)

                    DataGridViewEmployeeTime_Details.AddToModifiedRows(RowHandlesAndDataBoundItem.Key)

                End If

            Next

            DataGridViewEmployeeTime_Details.CurrentView.RefreshData()

            DataGridViewEmployeeTime_Details.SetUserEntryChanged()

            EnableOrDisableActions()

        End Sub
        Private Sub EmployeeTimeModifyBillHoldForSelected(ByVal BillHold As AdvantageFramework.BillingCommandCenter.ProductionBillHoldStatus)

            'objects
            Dim EmployeeTimeItem As AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem = Nothing

            DataGridViewEmployeeTime_Details.CurrentView.CloseEditorForUpdating()

            For Each RowHandlesAndDataBoundItem In DataGridViewEmployeeTime_Details.GetAllSelectedRowsRowHandlesAndDataBoundItems

                Try

                    EmployeeTimeItem = RowHandlesAndDataBoundItem.Value

                Catch ex As Exception
                    EmployeeTimeItem = Nothing
                End Try

                If EmployeeTimeItem IsNot Nothing Then

                    If EmployeeTimeModifyBillHold(EmployeeTimeItem, BillHold) Then

                        DataGridViewEmployeeTime_Details.AddToModifiedRows(RowHandlesAndDataBoundItem.Key)

                    End If

                End If

            Next

            DataGridViewEmployeeTime_Details.CurrentView.RefreshData()

            DataGridViewEmployeeTime_Details.SetUserEntryChanged()

            EnableOrDisableActions()

        End Sub
        Private Function EmployeeTimeModifyBillHold(ByVal EmployeeTimeItem As AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem, ByVal BillHold As AdvantageFramework.BillingCommandCenter.ProductionBillHoldStatus) As Boolean

            'objects
            Dim Modified As Boolean = False

            If BillHold = AdvantageFramework.BillingCommandCenter.ProductionBillHoldStatus.Clear Then

                EmployeeTimeItem.IsBillOnHold = Nothing

                Modified = True

            ElseIf EmployeeTimeItem.IsBillOnHold.GetValueOrDefault(0) <> CShort(BillHold) Then

                EmployeeTimeItem.IsBillOnHold = If(BillHold = 0, Nothing, BillHold)

                Modified = True

            End If

            EmployeeTimeModifyBillHold = Modified

        End Function
        Private Sub VendorAPUpdateMarkupRate(ByVal NewMarkupPercent As Decimal)

            'objects
            Dim AccountPayableProductionItem As AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem = Nothing
            Dim ShowMessage As Boolean = False

            DataGridViewVendor_Details.CurrentView.CloseEditorForUpdating()

            For Each RowHandlesAndDataBoundItem In DataGridViewVendor_Details.GetAllSelectedRowsRowHandlesAndDataBoundItems

                Try

                    AccountPayableProductionItem = RowHandlesAndDataBoundItem.Value

                Catch ex As Exception
                    AccountPayableProductionItem = Nothing
                End Try

                If AccountPayableProductionItem IsNot Nothing AndAlso AccountPayableProductionItem.IsNonBillable.GetValueOrDefault(0) = 0 Then

                    If AccountPayableProductionItem.IsBilledReversal Then

                        ShowMessage = True

                    Else

                        AccountPayableProductionItem.CommissionPercent = NewMarkupPercent

                        AccountPayableProductionItem.MarkupPercentChanged = True

                        AccountPayableProductionItem.ExtendedMarkupAmount = FormatNumber(AccountPayableProductionItem.ExtendedAmount * AccountPayableProductionItem.CommissionPercent / 100, 2)

                        AccountPayableProductionItem.CalculateTax(AccountPayableProductionItem)

                        DataGridViewVendor_Details.AddToModifiedRows(RowHandlesAndDataBoundItem.Key)

                    End If

                End If

            Next

            DataGridViewVendor_Details.CurrentView.RefreshData()
            DataGridViewVendor_Details.CurrentView.UpdateTotalSummary()
            DataGridViewVendor_Details.SetUserEntryChanged()

            EnableOrDisableActions()

            If ShowMessage Then

                AdvantageFramework.WinForm.MessageBox.Show("Billed reversals were skipped.")

            End If

        End Sub
        Private Sub IncomeOnlyRecalculateRow(ByVal IncomeOnlyItem As AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem,
                                             Optional ByVal BypassMarkupCalculation As Boolean = False)

            'objects
            Dim Amount As Decimal = 0
            Dim TaxableAmount As Decimal = 0

            If IncomeOnlyItem.Rate.HasValue AndAlso IncomeOnlyItem.Quantity.HasValue Then

                Amount = FormatNumber(IncomeOnlyItem.Rate.Value * IncomeOnlyItem.Quantity.Value, 2)
                IncomeOnlyItem.Amount = Amount

            Else

                Amount = IncomeOnlyItem.Amount

            End If

            If Not BypassMarkupCalculation Then

                IncomeOnlyItem.MarkupAmount = FormatNumber(IncomeOnlyItem.CommissionPercent * Amount / 100, 2)

            End If

            If IncomeOnlyItem.TaxCommissionOnly Then

                TaxableAmount = IncomeOnlyItem.MarkupAmount

            ElseIf IncomeOnlyItem.TaxCommission Then

                TaxableAmount = IncomeOnlyItem.MarkupAmount + Amount

            Else

                TaxableAmount = Amount

            End If

            IncomeOnlyItem.StateResaleTaxAmount = FormatNumber(IncomeOnlyItem.StateTaxPercent * TaxableAmount / 100, 2)
            IncomeOnlyItem.CountyResaleTaxAmount = FormatNumber(IncomeOnlyItem.CountyTaxPercent * TaxableAmount / 100, 2)
            IncomeOnlyItem.CityResaleTaxAmount = FormatNumber(IncomeOnlyItem.CityTaxPercent * TaxableAmount / 100, 2)

        End Sub
        Private Function VendorAPModifyBillHold(ByVal AccountPayableProductionItem As AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem, ByVal BillHold As AdvantageFramework.BillingCommandCenter.ProductionBillHoldStatus) As Boolean

            'objects
            Dim Modified As Boolean = False

            If BillHold = AdvantageFramework.BillingCommandCenter.ProductionBillHoldStatus.Clear Then

                AccountPayableProductionItem.IsBillOnHold = Nothing

                Modified = True

            ElseIf AccountPayableProductionItem.IsBillOnHold.GetValueOrDefault(0) <> CShort(BillHold) Then

                AccountPayableProductionItem.IsBillOnHold = If(BillHold = 0, Nothing, CShort(BillHold))

                Modified = True

            End If

            VendorAPModifyBillHold = Modified

        End Function
        Private Sub VendorAPModifyBillHoldForSelected(ByVal BillHold As AdvantageFramework.BillingCommandCenter.ProductionBillHoldStatus)

            'objects
            Dim AccountPayableProductionItem As AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem = Nothing
            Dim ShowMessage As Boolean = False

            DataGridViewVendor_Details.CurrentView.CloseEditorForUpdating()

            For Each RowHandlesAndDataBoundItem In DataGridViewVendor_Details.GetAllSelectedRowsRowHandlesAndDataBoundItems

                Try

                    AccountPayableProductionItem = RowHandlesAndDataBoundItem.Value

                Catch ex As Exception
                    AccountPayableProductionItem = Nothing
                End Try

                If AccountPayableProductionItem IsNot Nothing AndAlso AccountPayableProductionItem.IsNonBillable.GetValueOrDefault(0) = 0 Then

                    If AccountPayableProductionItem.IsBilledReversal Then

                        ShowMessage = True

                    ElseIf VendorAPModifyBillHold(AccountPayableProductionItem, BillHold) Then

                        DataGridViewVendor_Details.AddToModifiedRows(RowHandlesAndDataBoundItem.Key)

                    End If

                End If

            Next

            DataGridViewVendor_Details.CurrentView.RefreshData()

            DataGridViewVendor_Details.SetUserEntryChanged()

            EnableOrDisableActions()

            If ShowMessage Then

                AdvantageFramework.WinForm.MessageBox.Show("Billed reversals were skipped.")

            End If

        End Sub
        Private Sub SaveVendorAP(ByVal DbContext As AdvantageFramework.Database.DbContext)

            'objects
            Dim AccountPayableProductionItemList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem) = Nothing
            Dim AccountPayableProduction As AdvantageFramework.Database.Entities.AccountPayableProduction = Nothing
            Dim AccountPayableProductionComment As AdvantageFramework.Database.Entities.AccountPayableProductionComment = Nothing

            AccountPayableProductionItemList = DataGridViewVendor_Details.GetAllModifiedRows.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem)().ToList

            For Each AccountPayableProductionItem In AccountPayableProductionItemList

                AccountPayableProduction = AdvantageFramework.Database.Procedures.AccountPayableProduction.LoadByAccountPayableIDAndLineNumber(DbContext, AccountPayableProductionItem.AccountPayableID, AccountPayableProductionItem.LineNumber)

                If AccountPayableProduction Is Nothing Then

                    Throw New Exception("Cannot find AP Production to update.")

                End If

                If AccountPayableProduction.ExtendedMarkupAmount.GetValueOrDefault(0) <> AccountPayableProductionItem.ExtendedMarkupAmount OrElse
                        AccountPayableProduction.CommissionPercent.GetValueOrDefault(0) <> AccountPayableProductionItem.CommissionPercent OrElse
                        AccountPayableProduction.SalesTaxCode <> AccountPayableProductionItem.SalesTaxCode OrElse
                        AccountPayableProduction.ExtendedCityResale.GetValueOrDefault(0) <> AccountPayableProductionItem.ExtendedCityResale OrElse
                        AccountPayableProduction.ExtendedStateResale.GetValueOrDefault(0) <> AccountPayableProductionItem.ExtendedStateResale OrElse
                        AccountPayableProduction.ExtendedCountyResale.GetValueOrDefault(0) <> AccountPayableProductionItem.ExtendedCountyResale OrElse
                        AccountPayableProduction.BillHoldFlag.GetValueOrDefault(0) <> AccountPayableProductionItem.IsBillOnHold.GetValueOrDefault(0) Then

                    AccountPayableProduction.AdjustmentComments = VendorAPGetComment(AccountPayableProductionItem, AccountPayableProduction)
                    AccountPayableProduction.TransferAdjustmentUserCode = DbContext.UserCode
                    AccountPayableProduction.TransferAdjustmentDate = Now

                    AccountPayableProduction.SalesTaxCode = AccountPayableProductionItem.SalesTaxCode
                    AccountPayableProduction.CommissionPercent = AccountPayableProductionItem.CommissionPercent
                    AccountPayableProduction.StateTaxPercent = AccountPayableProductionItem.StateTaxPercent
                    AccountPayableProduction.CountyTaxPercent = AccountPayableProductionItem.CountyTaxPercent
                    AccountPayableProduction.CityTaxPercent = AccountPayableProductionItem.CityTaxPercent
                    AccountPayableProduction.TaxCommissions = AccountPayableProductionItem.TaxCommissions
                    AccountPayableProduction.TaxCommissionsOnly = AccountPayableProductionItem.TaxCommissionsOnly
                    AccountPayableProduction.IsResaleTax = AccountPayableProductionItem.IsResaleTax
                    AccountPayableProduction.ExtendedAmount = AccountPayableProductionItem.ExtendedAmount
                    AccountPayableProduction.ExtendedMarkupAmount = AccountPayableProductionItem.ExtendedMarkupAmount
                    AccountPayableProduction.ExtendedNonResaleTax = AccountPayableProductionItem.ExtendedNonResaleTax
                    AccountPayableProduction.ExtendedStateResale = AccountPayableProductionItem.ExtendedStateResale
                    AccountPayableProduction.ExtendedCountyResale = AccountPayableProductionItem.ExtendedCountyResale
                    AccountPayableProduction.ExtendedCityResale = AccountPayableProductionItem.ExtendedCityResale
                    AccountPayableProduction.LineTotal = AccountPayableProductionItem.LineTotal
                    AccountPayableProduction.BillHoldFlag = If(AccountPayableProductionItem.IsBillOnHold = AdvantageFramework.BillingCommandCenter.ProductionBillHoldStatus.Clear, Nothing, AccountPayableProductionItem.IsBillOnHold)

                    If AdvantageFramework.Database.Procedures.AccountPayableProduction.Update(DbContext, AccountPayableProduction) = False Then

                        Throw New Exception("Could not update AP.")

                    End If

                End If

                AccountPayableProductionComment = AdvantageFramework.Database.Procedures.AccountPayableProductionComment.LoadByAccountPayableIDLineNumber(DbContext, AccountPayableProductionItem.AccountPayableID, AccountPayableProductionItem.LineNumber)

                If AccountPayableProductionComment IsNot Nothing Then

                    If String.IsNullOrEmpty(AccountPayableProductionItem.Comment) Then

                        If AdvantageFramework.Database.Procedures.AccountPayableProductionComment.Delete(DbContext, AccountPayableProductionComment) = False Then

                            Throw New Exception("Failed to delete AP comment.")

                        End If

                    ElseIf AccountPayableProductionItem.Comment <> AccountPayableProductionComment.Comment Then

                        AccountPayableProductionComment.Comment = AccountPayableProductionItem.Comment

                        If AdvantageFramework.Database.Procedures.AccountPayableProductionComment.Update(DbContext, AccountPayableProductionComment) = False Then

                            Throw New Exception("Failed to Update AP comment.")

                        End If

                    End If

                ElseIf String.IsNullOrWhiteSpace(AccountPayableProductionItem.Comment) = False Then

                    AccountPayableProductionComment = New AdvantageFramework.Database.Entities.AccountPayableProductionComment
                    AccountPayableProductionComment.DbContext = DbContext
                    AccountPayableProductionComment.AccountPayableID = AccountPayableProductionItem.AccountPayableID
                    AccountPayableProductionComment.LineNumber = AccountPayableProductionItem.LineNumber
                    AccountPayableProductionComment.JobNumber = AccountPayableProductionItem.JobNumber
                    AccountPayableProductionComment.JobComponentNumber = AccountPayableProductionItem.JobComponentNumber
                    AccountPayableProductionComment.FunctionCode = AccountPayableProductionItem.FunctionCode
                    AccountPayableProductionComment.Comment = AccountPayableProductionItem.Comment

                    If AdvantageFramework.Database.Procedures.AccountPayableProductionComment.Insert(DbContext, AccountPayableProductionComment) = False Then

                        Throw New Exception("Failed to Insert AP comment.")

                    End If

                End If

            Next

        End Sub
        Private Function VendorAPGetComment(ByVal AccountPayableProductionItem As AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem,
                                            ByVal AccountPayableProduction As AdvantageFramework.Database.Entities.AccountPayableProduction) As String

            'objects
            Dim Comment As System.Text.StringBuilder = Nothing

            Comment = New System.Text.StringBuilder()

            If String.IsNullOrWhiteSpace(AccountPayableProduction.AdjustmentComments) = False Then

                Comment.Append(AccountPayableProduction.AdjustmentComments)

            End If

            If AccountPayableProduction.CommissionPercent.GetValueOrDefault(0) <> AccountPayableProductionItem.CommissionPercent AndAlso AccountPayableProductionItem.MarkupPercentChanged Then

                Comment.Append(" " & Now.ToShortDateString & " User: " & Session.UserCode & ":- Markup % adjusted.")

            End If

            If AccountPayableProduction.ExtendedMarkupAmount.GetValueOrDefault(0) <> AccountPayableProductionItem.ExtendedMarkupAmount AndAlso AccountPayableProductionItem.MarkupAmountChanged Then

                Comment.Append(" " & Now.ToShortDateString & " User: " & Session.UserCode & ":- Markup amount adjusted.")

            End If

            If AccountPayableProduction.SalesTaxCode <> AccountPayableProductionItem.SalesTaxCode AndAlso AccountPayableProductionItem.TaxCodeChanged Then

                Comment.Append(" " & Now.ToShortDateString & " User: " & Session.UserCode & ":- Tax code changed.")

            End If

            If (AccountPayableProduction.ExtendedStateResale.GetValueOrDefault(0) <> AccountPayableProductionItem.ExtendedStateResale OrElse
                    AccountPayableProduction.ExtendedCountyResale.GetValueOrDefault(0) <> AccountPayableProductionItem.ExtendedCountyResale OrElse
                    AccountPayableProduction.ExtendedCityResale.GetValueOrDefault(0) <> AccountPayableProductionItem.ExtendedCityResale) AndAlso
                    AccountPayableProductionItem.TaxAmountChanged Then

                Comment.Append(" " & Now.ToShortDateString & " User: " & Session.UserCode & ":- Tax amount changed.")

            End If

            VendorAPGetComment = Comment.ToString.Trim

        End Function
        Private Function IncomeOnlyGetComment(ByVal IncomeOnlyItem As AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem,
                                              ByVal IncomeOnly As AdvantageFramework.Database.Entities.IncomeOnly) As String

            'objects
            Dim Comment As System.Text.StringBuilder = Nothing

            Comment = New System.Text.StringBuilder()

            If String.IsNullOrWhiteSpace(IncomeOnly.AdjusterComments) = False Then

                Comment.Append(IncomeOnly.AdjusterComments)

            End If

            If IncomeOnly.Rate.Equals(IncomeOnlyItem.Rate) = False Then

                Comment.Append(" " & Now.ToShortDateString & " User: " & Session.UserCode & ":- Billing rate adjusted.")

            End If

            If IncomeOnly.CommissionPercent.GetValueOrDefault(0) <> IncomeOnlyItem.CommissionPercent AndAlso IncomeOnlyItem.MarkupPercentChanged Then

                Comment.Append(" " & Now.ToShortDateString & " User: " & Session.UserCode & ":- Markup % adjusted.")

            End If

            If IncomeOnly.ExtendedMarkupAmount.GetValueOrDefault(0) <> IncomeOnlyItem.MarkupAmount AndAlso IncomeOnlyItem.MarkupAmountChanged Then

                Comment.Append(" " & Now.ToShortDateString & " User: " & Session.UserCode & ":- Markup amount adjusted.")

            End If

            If IncomeOnly.TaxCode <> IncomeOnlyItem.SalesTaxCode AndAlso IncomeOnlyItem.TaxCodeChanged Then

                Comment.Append(" " & Now.ToShortDateString & " User: " & Session.UserCode & ":- Tax code changed.")

            End If

            If (IncomeOnly.ExtendedStateResale.GetValueOrDefault(0) <> IncomeOnlyItem.StateResaleTaxAmount OrElse
                    IncomeOnly.ExtendedCountyResale.GetValueOrDefault(0) <> IncomeOnlyItem.CountyResaleTaxAmount OrElse
                    IncomeOnly.ExtendedCityResale.GetValueOrDefault(0) <> IncomeOnlyItem.CityResaleTaxAmount) AndAlso
                    IncomeOnlyItem.TaxAmountChanged Then

                Comment.Append(" " & Now.ToShortDateString & " User: " & Session.UserCode & ":- Tax amount changed.")

            End If

            IncomeOnlyGetComment = Comment.ToString.Trim

        End Function
        Private Function IncomeOnlyModifyBillHold(ByVal IncomeOnlyItem As AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem, ByVal BillHold As AdvantageFramework.BillingCommandCenter.ProductionBillHoldStatus) As Boolean

            'objects
            Dim Modified As Boolean = False

            If BillHold = AdvantageFramework.BillingCommandCenter.ProductionBillHoldStatus.Clear Then

                IncomeOnlyItem.IsBillOnHold = Nothing

                Modified = True

            ElseIf IncomeOnlyItem.IsBillOnHold.GetValueOrDefault(0) <> CShort(BillHold) Then

                IncomeOnlyItem.IsBillOnHold = If(BillHold = 0, Nothing, BillHold)

                Modified = True

            End If

            IncomeOnlyModifyBillHold = Modified

        End Function
        Private Sub IncomeOnlyModifyBillHoldForSelected(ByVal BillHold As AdvantageFramework.BillingCommandCenter.ProductionBillHoldStatus)

            'objects
            Dim IncomeOnlyItem As AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem = Nothing

            DataGridViewIncomeOnly_Details.CurrentView.CloseEditorForUpdating()

            For Each RowHandlesAndDataBoundItem In DataGridViewIncomeOnly_Details.GetAllSelectedRowsRowHandlesAndDataBoundItems

                Try

                    IncomeOnlyItem = RowHandlesAndDataBoundItem.Value

                Catch ex As Exception
                    IncomeOnlyItem = Nothing
                End Try

                If IncomeOnlyItem IsNot Nothing Then

                    If IncomeOnlyModifyBillHold(IncomeOnlyItem, BillHold) Then

                        DataGridViewIncomeOnly_Details.AddToModifiedRows(RowHandlesAndDataBoundItem.Key)

                    End If

                End If

            Next

            DataGridViewIncomeOnly_Details.CurrentView.RefreshData()

            DataGridViewIncomeOnly_Details.SetUserEntryChanged()

            EnableOrDisableActions()

        End Sub
        Private Sub SaveIncomeOnly(ByVal DbContext As AdvantageFramework.Database.DbContext)

            'objects 
            Dim JobNumber As Integer = Nothing
            Dim JobComponentNumber As Short = Nothing
            Dim IncomeOnlyItemList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem) = Nothing
            Dim IncomeOnly As AdvantageFramework.Database.Entities.IncomeOnly = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim ABFlag As Nullable(Of Short) = Nothing

            JobNumber = DirectCast(DataGridViewLeftSection_Jobs.CurrentView.GetRow(DataGridViewLeftSection_Jobs.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.JobDetailJobComponent).JobNumber
            JobComponentNumber = DirectCast(DataGridViewLeftSection_Jobs.CurrentView.GetRow(DataGridViewLeftSection_Jobs.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.JobDetailJobComponent).JobComponentNumber

            JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNumber)

            If JobComponent IsNot Nothing Then

                ABFlag = JobComponent.IsAdvanceBilling

            End If

            IncomeOnlyItemList = DataGridViewIncomeOnly_Details.GetAllModifiedRows.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem)().ToList

            For Each IncomeOnlyItem In IncomeOnlyItemList

                IncomeOnly = AdvantageFramework.Database.Procedures.IncomeOnly.LoadByIDAndSequenceNumber(DbContext, IncomeOnlyItem.ID, IncomeOnlyItem.SequenceNumber)

                If IncomeOnly Is Nothing Then

                    Throw New Exception("Cannot find Income Only.")

                End If

                If DirectCast(DataGridViewLeftSection_Jobs.CurrentView.GetRow(DataGridViewLeftSection_Jobs.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.JobDetailJobComponent).BillingUser IsNot Nothing AndAlso
                        IncomeOnly.Comment <> IncomeOnlyItem.Comment Then

                    IncomeOnly.Comment = IncomeOnlyItem.Comment

                    If AdvantageFramework.Database.Procedures.IncomeOnly.Update(DbContext, IncomeOnly) = False Then

                        Throw New Exception("Failed to save IncomeOnly.")

                    End If

                Else

                    If IncomeOnly.Rate.GetValueOrDefault(0) <> IncomeOnlyItem.Rate.GetValueOrDefault(0) OrElse
                            IncomeOnly.Amount.GetValueOrDefault(0) <> IncomeOnlyItem.Amount OrElse
                            IncomeOnly.CommissionPercent.GetValueOrDefault(0) <> IncomeOnlyItem.CommissionPercent OrElse
                            IncomeOnly.ExtendedMarkupAmount.GetValueOrDefault(0) <> IncomeOnlyItem.MarkupAmount OrElse
                            IncomeOnly.TaxCode <> IncomeOnlyItem.SalesTaxCode OrElse
                            IncomeOnly.ExtendedStateResale.GetValueOrDefault(0) <> IncomeOnlyItem.StateResaleTaxAmount OrElse
                            IncomeOnly.ExtendedCountyResale.GetValueOrDefault(0) <> IncomeOnlyItem.CountyResaleTaxAmount OrElse
                            IncomeOnly.ExtendedCityResale.GetValueOrDefault(0) <> IncomeOnlyItem.CityResaleTaxAmount OrElse
                            IncomeOnly.BillHoldFlag.GetValueOrDefault(0) <> IncomeOnlyItem.IsBillOnHold.GetValueOrDefault(0) OrElse
                            CBool(IncomeOnly.NonBillable.GetValueOrDefault(0)) <> IncomeOnlyItem.IsNonBillable Then

                        IncomeOnly.Quantity = If(IncomeOnly.Quantity.GetValueOrDefault(0) = 0, Nothing, IncomeOnly.Quantity)
                        IncomeOnly.Rate = If(IncomeOnly.Rate.GetValueOrDefault(0) = 0, Nothing, IncomeOnly.Rate)

                        IncomeOnly.AdvanceBillFlag = ABFlag

                        IncomeOnly.TransferAdjustedDate = Now
                        IncomeOnly.TransferAdjustedUser = DbContext.UserCode
                        IncomeOnly.AdjusterComments = IncomeOnlyGetComment(IncomeOnlyItem, IncomeOnly)

                        IncomeOnly.BillHoldFlag = If(IncomeOnlyItem.IsBillOnHold = AdvantageFramework.BillingCommandCenter.ProductionBillHoldStatus.Clear, Nothing, IncomeOnlyItem.IsBillOnHold)
                        IncomeOnly.TaxResale = IncomeOnlyItem.IsResaleTax
                        IncomeOnly.NonBillable = If(IncomeOnlyItem.IsNonBillable, 1, 0)
                        IncomeOnly.Amount = IncomeOnlyItem.Amount
                        IncomeOnly.CommissionPercent = IncomeOnlyItem.CommissionPercent
                        IncomeOnly.TaxCode = IncomeOnlyItem.SalesTaxCode
                        IncomeOnly.TaxStatePercent = IncomeOnlyItem.StateTaxPercent
                        IncomeOnly.TaxCountyPercent = IncomeOnlyItem.CountyTaxPercent
                        IncomeOnly.TaxCityPercent = IncomeOnlyItem.CityTaxPercent
                        IncomeOnly.TaxCommission = If(IncomeOnlyItem.TaxCommission, 1, 0)
                        IncomeOnly.TaxCommissionOnly = If(IncomeOnlyItem.TaxCommissionOnly, 1, 0)
                        IncomeOnly.ExtendedMarkupAmount = IncomeOnlyItem.MarkupAmount
                        IncomeOnly.ExtendedStateResale = IncomeOnlyItem.StateResaleTaxAmount
                        IncomeOnly.ExtendedCountyResale = IncomeOnlyItem.CountyResaleTaxAmount
                        IncomeOnly.ExtendedCityResale = IncomeOnlyItem.CityResaleTaxAmount
                        IncomeOnly.Rate = IncomeOnlyItem.Rate
                        IncomeOnly.LineTotal = IncomeOnlyItem.LineTotal

                    End If

                    If IncomeOnly.Comment <> IncomeOnlyItem.Comment Then

                        IncomeOnly.Comment = IncomeOnlyItem.Comment

                    End If

                    If AdvantageFramework.Database.Procedures.IncomeOnly.Update(DbContext, IncomeOnly) = False Then

                        Throw New Exception("Failed to save IncomeOnly.")

                    End If

                End If

            Next

        End Sub
        Private Sub SetColumnDefaultVisibility()

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            For Each GridColumn In DataGridViewTop_JobComponentFunctions.CurrentView.Columns

                If GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.EstimateNetAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.EstimateMarkupAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.EstimateResaleTax.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.EstimateTotal.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.ActualBillableNetAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.ActualBillableMarkupAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.ActualBillableResaleTax.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.ActualBillableTotal.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.BilledNet.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.BilledMarkup.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.BilledResaleTax.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.BilledTotal.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.UnbilledNetAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.UnbilledMarkupAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.UnbilledResaleTax.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.UnbilledTotal.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.AdvanceHours.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.AdvanceQuantity.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.AdvanceBilledNetAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.AdvanceBilledMarkupAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.AdvanceBilledResaleTax.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.AdvanceBilledTotal.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.TotalBilledTax.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.TotalBilled.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.UnbilledAdvanceResaleTax.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.UnbilledAdvanceTotal.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.NonBillableNetAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.NonBillableMarkupAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.FeeResaleTax.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.FeeTotal.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.FunctionHeading.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.FunctionConsolidationCode.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.FunctionConsolidationDescription.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.FunctionOrder.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.PercentCompleteAll.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.GrossIncome.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.AdvanceBillingBalance.ToString Then

                    GridColumn.Visible = False

                ElseIf GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.FunctionType.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.FunctionCode.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.FunctionDescription.ToString Then

                    GridColumn.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

                ElseIf GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.AdvanceBillRequested.ToString Then

                    GridColumn.Visible = False
                    GridColumn.OptionsColumn.ShowInCustomizationForm = False

                End If

            Next

        End Sub
        Private Sub SetColumnDefaultVisibilityEmployeeTime(ByVal InvoiceTaxFlag As Boolean)

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            GridColumn = DataGridViewEmployeeTime_Details.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.TaskCode.ToString)

            If GridColumn IsNot Nothing Then

                GridColumn.Visible = False
                GridColumn.OptionsColumn.ShowInCustomizationForm = _ShowEmployeeTimeTaskCode

            End If

            If Not InvoiceTaxFlag Then

                For Each GridColumn In DataGridViewEmployeeTime_Details.CurrentView.Columns

                    If GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.SalesTaxCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.TaxCommission.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.TaxCommissionOnly.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.SalesTaxStatePercentage.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.SalesTaxCountyPercentage.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.SalesTaxCityPercentage.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.StateResaleAmount.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.CountyResaleAmount.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.CityResaleAmount.ToString Then

                        GridColumn.Visible = False

                    End If

                Next

            End If

        End Sub
        Private Sub SetColumnDefaultVisibilityEmployeeTimeReconcileMode()

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            For Each GridColumn In DataGridViewEmployeeTime_Details.CurrentView.Columns

                If GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.EmployeeDate.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.EmployeeName.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.Hours.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.BillableRate.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.TotalBill.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.MarkupAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.Total.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.Instruction.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.NetApprovedAmount.ToString Then

                    GridColumn.Visible = True

                Else

                    GridColumn.Visible = False

                End If

            Next

        End Sub
        Private Sub SetColumnDefaultVisibilityIncomeOnly(ByVal InvoiceTaxFlag As Boolean)

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            If Not InvoiceTaxFlag Then

                For Each GridColumn In DataGridViewIncomeOnly_Details.CurrentView.Columns

                    If GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.SalesTaxCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.TaxCommission.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.TaxCommissionOnly.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.StateTaxPercent.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.CountyTaxPercent.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.CityTaxPercent.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.StateResaleTaxAmount.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.CountyResaleTaxAmount.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.CityResaleTaxAmount.ToString Then

                        GridColumn.Visible = False

                    End If

                Next

            End If

        End Sub
        Private Sub SetColumnDefaultVisibilityIncomeOnlyReconcileMode()

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            For Each GridColumn In DataGridViewIncomeOnly_Details.CurrentView.Columns

                If GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.InvoiceDate.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.InvoiceNumber.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.Description.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.Quantity.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.Rate.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.Amount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.MarkupAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.Total.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.Instruction.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.NetApprovedAmount.ToString Then

                    GridColumn.Visible = True

                Else

                    GridColumn.Visible = False

                End If

            Next

        End Sub
        Private Sub SetColumnDefaultVisibilityOpenPO()

            For Each GridColumn In DataGridViewOpenPO_Details.CurrentView.Columns

                If GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.OpenPOItem.Properties.DetailDescription.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.OpenPOItem.Properties.Detailinstructions.ToString Then

                    GridColumn.Visible = False

                End If

            Next

        End Sub
        Private Sub SetColumnDefaultVisibilityVendorAP(ByVal InvoiceTaxFlag As Boolean)

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            If Not InvoiceTaxFlag Then

                For Each GridColumn In DataGridViewVendor_Details.CurrentView.Columns

                    If GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.SalesTaxCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.TaxCommissions.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.TaxCommissionsOnly.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.StateTaxPercent.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.CountyTaxPercent.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.CityTaxPercent.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.ExtendedStateResale.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.ExtendedCountyResale.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.ExtendedCityResale.ToString Then

                        GridColumn.Visible = False

                    End If

                Next

            End If

        End Sub
        Private Sub SetColumnDefaultVisibilityVendorAPReconcileMode()

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            For Each GridColumn In DataGridViewVendor_Details.CurrentView.Columns

                If GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.InvoiceDate.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.PostPeriod.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.VendorName.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.InvoiceNumber.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.Quantity.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.Rate.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.ExtendedAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.ExtendedMarkupAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.Total.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.Instruction.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.NetApprovedAmount.ToString Then

                    GridColumn.Visible = True

                Else

                    GridColumn.Visible = False

                End If

            Next

        End Sub
        Private Sub LoadDocuments()

            'objects
            Dim SelectedFunctionCodes As IEnumerable(Of String) = Nothing
            Dim JobNumber As Integer = Nothing
            Dim JobComponentNumber As Short = Nothing
            Dim AccountPayableProductionItemList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem) = Nothing
            Dim DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting) = Nothing
            Dim BillingCommandCenter As AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter = Nothing
            Dim AccountPayableIDs As Generic.List(Of Integer) = Nothing
            Dim ExpenseReportDetailIDs As Generic.List(Of Integer) = Nothing

            SelectedFunctionCodes = (From Entity In DataGridViewTop_JobComponentFunctions.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail).ToList
                                     Where Entity.FunctionType = "V"
                                     Select Entity.FunctionCode).ToList

            AccountPayableProductionItemList = New Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    BillingCommandCenter = AdvantageFramework.BillingCommandCenter.Database.Procedures.BillingCommandCenter.LoadByID(BCCDbContext, _BillingCommandCenterID)

                    JobNumber = DirectCast(DataGridViewLeftSection_Jobs.CurrentView.GetRow(DataGridViewLeftSection_Jobs.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.JobDetailJobComponent).JobNumber
                    JobComponentNumber = DirectCast(DataGridViewLeftSection_Jobs.CurrentView.GetRow(DataGridViewLeftSection_Jobs.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.JobDetailJobComponent).JobComponentNumber

                    If BillingCommandCenter IsNot Nothing AndAlso BillingCommandCenter.APPostPeriodCodeCutoff IsNot Nothing Then

                        AccountPayableProductionItemList.AddRange(AdvantageFramework.BillingCommandCenter.GetAccountPayableProductionItems(BCCDbContext, JobNumber, JobComponentNumber, SelectedFunctionCodes, BillingCommandCenter.APPostPeriodCodeCutoff, AdvantageFramework.BillingCommandCenter.Methods.ProductionSelectFor.BCCJobDetailGrid, BillingCommandCenter.IsProductionSelectionLocked))

                    End If

                End Using

            End Using

            DocumentManagerControlDocuments_Documents.ClearControl()

            AccountPayableIDs = AccountPayableProductionItemList.Select(Function(APP) APP.AccountPayableID).Distinct.ToList
            ExpenseReportDetailIDs = AccountPayableProductionItemList.Where(Function(APP) APP.ExpenseReportDetailID.HasValue).Select(Function(APP) APP.ExpenseReportDetailID.Value).Distinct.ToList

            DocumentLevelSettings = New Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting)

            For Each AccountPayableID In AccountPayableIDs

                DocumentLevelSettings.Add(New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.AccountPayableInvoice) With {.AccountPayableID = AccountPayableID})

            Next

            For Each ExpenseReportDetailID In ExpenseReportDetailIDs

                DocumentLevelSettings.Add(New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.ExpenseReceipts, Database.Entities.DocumentSubLevel.ExpenseDetailDocument) With {.ExpenseDetailID = ExpenseReportDetailID})

            Next

            DocumentManagerControlDocuments_Documents.Enabled = DocumentManagerControlDocuments_Documents.LoadControl(Database.Entities.DocumentLevel.AccountPayableInvoice, DocumentLevelSettings, WinForm.Presentation.Controls.DocumentManagerControl.Type.Default, Database.Entities.DocumentSubLevel.Default, True, True)

            DocumentManagerControlDocuments_Documents.DataGridViewForm_Documents.OptionsMenu.EnableColumnMenu = False

            TabItemFunctionItems_Documents.Tag = True

        End Sub
        Private Sub LoadAdvanceBilling()

            'objects
            Dim SelectAll As Boolean = False
            Dim JobComponentFunctionDetails As IEnumerable(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail) = Nothing
            Dim JobNumber As Integer = Nothing
            Dim JobComponentNumber As Short = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim AdvanceBillingItemList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem) = Nothing
            Dim ProductionSummary As AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary = Nothing

            Me.FormAction = WinForm.Presentation.Methods.FormActions.Loading

            If DataGridViewAdvanceBilling_Details.CurrentView.SelectedRowsCount > 1 AndAlso DataGridViewAdvanceBilling_Details.CurrentView.RowCount = DataGridViewAdvanceBilling_Details.CurrentView.SelectedRowsCount Then

                SelectAll = True

            End If

            JobComponentFunctionDetails = DataGridViewTop_JobComponentFunctions.GetAllRowsDataBoundItems().OfType(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail).ToList()

            If JobComponentFunctionDetails IsNot Nothing AndAlso JobComponentFunctionDetails.Count > 0 Then

                LabelItemBillMethod_AdvanceRequested.Visible = JobComponentFunctionDetails.FirstOrDefault.AdvanceBillRequested

            End If

            If JobComponentFunctionDetails.Sum(Function(JCF) JCF.EstimateAmount) <> 0 Then

                LabelItemPctOfQuoteBilled_PCT.Text = FormatNumber(JobComponentFunctionDetails.Sum(Function(JCF) JCF.BilledAmount.GetValueOrDefault(0) + JCF.AdvanceBilledAmount.GetValueOrDefault(0)) /
                                                                  JobComponentFunctionDetails.Sum(Function(JCF) JCF.EstimateAmount) * 100, 2) & "%"

            Else

                LabelItemPctOfQuoteBilled_PCT.Text = FormatNumber(0, 2) & "%"

            End If

            DataGridViewAdvanceBilling_Details.CurrentView.ClearDisabledRows()
            DataGridViewAdvanceBilling_Details.ClearDatasource()
            DataGridViewAdvanceBilling_Details.ItemDescription = "Advance Billing Item(s)"

            AdvanceBillingItemList = New Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    JobNumber = DirectCast(DataGridViewLeftSection_Jobs.CurrentView.GetRow(DataGridViewLeftSection_Jobs.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.JobDetailJobComponent).JobNumber
                    JobComponentNumber = DirectCast(DataGridViewLeftSection_Jobs.CurrentView.GetRow(DataGridViewLeftSection_Jobs.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.JobDetailJobComponent).JobComponentNumber

                    ProductionSummary = AdvantageFramework.BillingCommandCenter.GetProductionSummary(BCCDbContext, _BillingCommandCenterID, ButtonItemInclude_Contingency.Checked, JobNumber, JobComponentNumber).SingleOrDefault

                    _BillStatus = ProductionSummary.BillStatus

                    LabelItemABVertical_MethodDescription.Text = AdvantageFramework.BillingCommandCenter.GetLatestReconcileMethod(DbContext, JobNumber, JobComponentNumber)
                    LabelItemABVertical_MethodDescription.Refresh()

                    JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNumber)

                    If JobComponent IsNot Nothing Then

                        If JobComponent.ProductionAdvancedBillingIncome Is Nothing Then

                            If JobComponent.Job.Office.ProductionAdvancedBillingIncome.GetValueOrDefault(1) = AdvantageFramework.Database.Entities.ProductionAdvancedBillingIncome.UponReconciliation Then

                                ButtonItemIncomeMethod_UponReconciliation.Checked = True

                            ElseIf JobComponent.Job.Office.ProductionAdvancedBillingIncome.GetValueOrDefault(1) = AdvantageFramework.Database.Entities.ProductionAdvancedBillingIncome.InitialBilling Then

                                ButtonItemIncomeMethod_InitialBilling.Checked = True

                            End If

                        ElseIf JobComponent.ProductionAdvancedBillingIncome.GetValueOrDefault(1) = AdvantageFramework.Database.Entities.ProductionAdvancedBillingIncome.UponReconciliation Then

                            ButtonItemIncomeMethod_UponReconciliation.Checked = True

                        ElseIf JobComponent.ProductionAdvancedBillingIncome.GetValueOrDefault(1) = AdvantageFramework.Database.Entities.ProductionAdvancedBillingIncome.InitialBilling Then

                            ButtonItemIncomeMethod_InitialBilling.Checked = True

                        End If

                        AdvanceBillingItemList.AddRange(AdvantageFramework.BillingCommandCenter.GetAdvanceBillingItems(DbContext, JobComponent.JobNumber, JobComponent.Number))

                        If (From EA In AdvantageFramework.Database.Procedures.EstimateApprovalView.Load(DbContext)
                            Where EA.JobNumber = JobComponent.JobNumber AndAlso
                              EA.JobComponentNumber = JobComponent.Number
                            Select EA).Any = False Then

                            NumericInputControl_PercentOfQuote.EditValue = Nothing
                            NumericInputControl_PercentOfQuote.Enabled = False
                            NumericInputControl_PercentOfQuote.ClearChanged()

                        ElseIf AdvanceBillingItemList.Where(Function(ABI) ABI.AdvanceBilling.ID <> 0).FirstOrDefault IsNot Nothing AndAlso
                            AdvanceBillingItemList.Where(Function(ABI) ABI.AdvanceBilling.ID <> 0).FirstOrDefault.AdvanceBilling.CalculatePercent IsNot Nothing Then

                            NumericInputControl_PercentOfQuote.EditValue = AdvanceBillingItemList.Where(Function(ABI) ABI.AdvanceBilling.ID <> 0).FirstOrDefault.AdvanceBilling.CalculatePercent
                            NumericInputControl_PercentOfQuote.Enabled = True
                            NumericInputControl_PercentOfQuote.ClearChanged()

                        Else

                            NumericInputControl_PercentOfQuote.EditValue = Nothing
                            NumericInputControl_PercentOfQuote.Enabled = True
                            NumericInputControl_PercentOfQuote.ClearChanged()

                        End If

                        _AdvanceBillFinalReconciledAndBilled = (From AB In AdvantageFramework.Database.Procedures.AdvanceBilling.Load(DbContext)
                                                                Where AB.JobNumber = JobNumber AndAlso
                                                                  AB.JobComponentNumber = JobComponentNumber AndAlso
                                                                  (AB.ARInvoiceIsVoided Is Nothing OrElse AB.ARInvoiceIsVoided = 0) AndAlso
                                                                  AB.ARInvoiceNumber IsNot Nothing AndAlso
                                                                  AB.FinalAdvanceBillingID IsNot Nothing
                                                                Select AB).Any

                        _AdvanceBillHasMultipleUnbilledFunctions = (From Entity In AdvantageFramework.Database.Procedures.AdvanceBilling.LoadUnbilledByJobNumberAndJobComponentNumberAndFlagIsOneOrTwo(DbContext, JobNumber, JobComponentNumber).ToList
                                                                    Group By Entity.FunctionCode Into ABFGroup = Group
                                                                    Select FunctionCode, TotalRows = ABFGroup.Count).Where(Function(AB) AB.TotalRows > 1).Any

                    End If

                End Using

            End Using

            DataGridViewAdvanceBilling_Details.DataSource = AdvanceBillingItemList

            SortAdvanceBillingGrid()

            If _InvoiceTaxFlag Then

                For Each GridColumn In DataGridViewAdvanceBilling_Details.Columns

                    If GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem.Properties.LineTotal.ToString Then

                        GridColumn.Visible = False
                        GridColumn.OptionsColumn.ShowInCustomizationForm = False

                    End If

                Next

            End If

            If SelectAll Then

                DataGridViewAdvanceBilling_Details.SelectAll()

            End If

            DataGridViewAdvanceBilling_Details.CurrentView.BestFitColumns()

            DataGridViewAdvanceBilling_Details.ValidateAllRows()

            TabItemFunctionItems_AdvanceBilling.Tag = True

            Me.FormAction = WinForm.Presentation.Methods.FormActions.None

        End Sub
        Private Sub LoadOpenPO()

            'objects
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim SelectedFunctionCodes As IEnumerable(Of String) = Nothing
            Dim JobNumber As Integer = Nothing
            Dim JobComponentNumber As Short = Nothing
            Dim OpenPOItemList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.OpenPOItem) = Nothing
            Dim BillingCommandCenter As AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter = Nothing
            Dim LayoutLoaded As Boolean = False

            BindingSource = DataGridViewOpenPO_Details.DataSource

            If Not _ReconcileMode AndAlso BindingSource IsNot Nothing AndAlso BindingSource.DataSource IsNot Nothing Then

                AdvantageFramework.WinForm.Presentation.Controls.SaveDataGridViewLayout(Session, DataGridViewOpenPO_Details, AdvantageFramework.Database.Entities.GridAdvantageType.BillingCommandCenterJobComponentOpenPODetail)

            End If

            DataGridViewOpenPO_Details.SetBookmarkColumnIndex(-1)
            DataGridViewOpenPO_Details.ClearGridCustomization()
            DataGridViewOpenPO_Details.ClearDatasource(New Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.OpenPOItem))

            SelectedFunctionCodes = (From Entity In DataGridViewTop_JobComponentFunctions.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail).ToList
                                     Where Entity.FunctionType = "V"
                                     Select Entity.FunctionCode).ToList

            OpenPOItemList = New Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.OpenPOItem)

            JobNumber = DirectCast(DataGridViewLeftSection_Jobs.CurrentView.GetRow(DataGridViewLeftSection_Jobs.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.JobDetailJobComponent).JobNumber
            JobComponentNumber = DirectCast(DataGridViewLeftSection_Jobs.CurrentView.GetRow(DataGridViewLeftSection_Jobs.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.JobDetailJobComponent).JobComponentNumber

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    BillingCommandCenter = AdvantageFramework.BillingCommandCenter.Database.Procedures.BillingCommandCenter.LoadByID(BCCDbContext, _BillingCommandCenterID)

                    If BillingCommandCenter IsNot Nothing Then

                        OpenPOItemList.AddRange(AdvantageFramework.BillingCommandCenter.GetOpenPO(BCCDbContext, BillingCommandCenter.ID, JobNumber, JobComponentNumber))

                    End If

                End Using

            End Using

            LayoutLoaded = AdvantageFramework.WinForm.Presentation.Controls.LoadDataGridViewLayout(Session, DataGridViewOpenPO_Details, Database.Entities.GridAdvantageType.BillingCommandCenterJobComponentOpenPODetail)

            DataGridViewOpenPO_Details.DataSource = OpenPOItemList

            If LayoutLoaded Then

                AdvantageFramework.WinForm.Presentation.Controls.SortGridViewBySortedColumns(DataGridViewOpenPO_Details)

            Else

                SetColumnDefaultVisibilityOpenPO()

                DataGridViewOpenPO_Details.CurrentView.ClearSorting()
                DataGridViewOpenPO_Details.CurrentView.BeginSort()
                DataGridViewOpenPO_Details.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Classes.OpenPOItem.Properties.PONumber.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Descending
                DataGridViewOpenPO_Details.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Classes.OpenPOItem.Properties.LineNumber.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                DataGridViewOpenPO_Details.CurrentView.EndSort()

            End If

            If Not LayoutLoaded Then

                DataGridViewOpenPO_Details.CurrentView.BestFitColumns()

            End If

            TabItemFunctionItems_OpenPO.Tag = True

        End Sub
        Private Sub SortAdvanceBillingGrid()

            DataGridViewAdvanceBilling_Details.CurrentView.ClearSorting()
            DataGridViewAdvanceBilling_Details.CurrentView.BeginSort()
            DataGridViewAdvanceBilling_Details.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem.Properties.FunctionType.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
            DataGridViewAdvanceBilling_Details.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem.Properties.FunctionDescription.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
            DataGridViewAdvanceBilling_Details.CurrentView.EndSort()

        End Sub
        Private Sub LoadBillingStatus()

            Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                _BillingStatus = AdvantageFramework.BillingCommandCenter.GetBillingStatus(BCCDbContext, _BillingCommandCenterID)

            End Using

        End Sub
        Private Sub AddAdvanceBillingRows(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                          ByVal EstimateApproval As AdvantageFramework.Database.Views.EstimateApproval,
                                          ByVal AdvanceBillPercentToQuote As AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillPercentToQuote)

            Dim JobComponentFunctionDetails As IEnumerable(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail) = Nothing
            Dim AdvanceBillingItemList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem) = Nothing

            JobComponentFunctionDetails = DataGridViewTop_JobComponentFunctions.GetAllSelectedRowsDataBoundItems().OfType(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail).Where(Function(JCF) JCF.FunctionType <> "C").ToList()

            AdvanceBillingItemList = DataGridViewAdvanceBilling_Details.GetAllRowsDataBoundItems().OfType(Of AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem).ToList

            AdvantageFramework.BillingCommandCenter.AddAdvanceBillingRows(DbContext, EstimateApproval, AdvanceBillPercentToQuote, JobComponentFunctionDetails, AdvanceBillingItemList, Session, ButtonItemInclude_Contingency.Checked)

            DataGridViewAdvanceBilling_Details.DataSource = AdvanceBillingItemList

            SortAdvanceBillingGrid()

            DataGridViewAdvanceBilling_Details.CurrentView.BestFitColumns()
            DataGridViewAdvanceBilling_Details.SetUserEntryChanged()

        End Sub
        Private Sub SaveAdvanceBilling(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                       ByVal BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext)

            'objects
            Dim AdvanceBillingItemList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem) = Nothing
            Dim AdvanceBillingItem As AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem = Nothing
            Dim AdvanceBillingID As Integer = 0
            Dim AdvanceBilling As AdvantageFramework.Database.Entities.AdvanceBilling = Nothing
            Dim IncomeRecognize As AdvantageFramework.Database.Entities.IncomeRecognize = Nothing
            Dim JobNumber As Integer = Nothing
            Dim JobComponentNumber As Short = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing

            If TabItemFunctionItems_AdvanceBilling.Tag = True Then

                JobNumber = DirectCast(DataGridViewLeftSection_Jobs.CurrentView.GetRow(DataGridViewLeftSection_Jobs.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.JobDetailJobComponent).JobNumber
                JobComponentNumber = DirectCast(DataGridViewLeftSection_Jobs.CurrentView.GetRow(DataGridViewLeftSection_Jobs.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.JobDetailJobComponent).JobComponentNumber

                AdvanceBillingItemList = DataGridViewAdvanceBilling_Details.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem)().ToList

                AdvanceBillingID = AdvantageFramework.BillingCommandCenter.GetExistingAdvanceBillingID(DbContext, JobNumber, JobComponentNumber)

                For Each AdvanceBillingItem In AdvanceBillingItemList

                    AdvanceBilling = AdvanceBillingItem.AdvanceBilling
                    AdvanceBilling.DbContext = DbContext

                    IncomeRecognize = AdvanceBillingItem.IncomeRecognize
                    IncomeRecognize.DbContext = DbContext

                    If AdvanceBillingItem.IsDeleted Then

                        If AdvanceBilling.ID <> 0 AndAlso AdvanceBilling.SequenceNumber <> 0 AndAlso String.IsNullOrWhiteSpace(AdvanceBilling.FunctionCode) = False Then

                            DbContext.Database.ExecuteSqlCommand("DELETE dbo.ADVANCE_BILLING WHERE AR_INV_NBR IS NULL AND JOB_NUMBER = @JobNumber AND JOB_COMPONENT_NBR = @ComponentNumber AND FNC_CODE = @FunctionCode",
                                                                    New SqlClient.SqlParameter("@JobNumber", AdvanceBilling.JobNumber),
                                                                    New SqlClient.SqlParameter("@ComponentNumber", AdvanceBilling.JobComponentNumber),
                                                                    New SqlClient.SqlParameter("@FunctionCode", AdvanceBilling.FunctionCode))

                        End If

                        If IncomeRecognize.AdvanceBillingID <> 0 AndAlso IncomeRecognize.SequenceNumber <> 0 Then

                            If AdvantageFramework.Database.Procedures.IncomeRecognize.Delete(DbContext, IncomeRecognize) = False Then

                                Throw New Exception("Failed to delete from income recognition.")

                            End If

                        End If

                    Else

                        AdvanceBilling.CalculatePercent = NumericInputControl_PercentOfQuote.EditValue

                        If AdvanceBilling.ID = 0 AndAlso String.IsNullOrWhiteSpace(AdvanceBilling.FunctionCode) = False AndAlso AdvanceBilling.NetAmount.GetValueOrDefault(0) <> 0 Then

                            If AdvanceBilling.ID = 0 AndAlso AdvanceBillingID <> 0 Then

                                AdvanceBilling.ID = AdvanceBillingID

                            End If

                            JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNumber)

                            AdvanceBilling.BillingCommandCenterID = _BillingCommandCenterID
                            AdvanceBilling.BillingUserCode = If(JobComponent IsNot Nothing, JobComponent.BillingUserCode, Nothing)

                            If AdvantageFramework.Database.Procedures.AdvanceBilling.Insert(DbContext, AdvanceBilling) = False Then

                                Throw New Exception("Failed to insert advance billing.")

                            ElseIf AdvanceBillingID = 0 Then

                                AdvanceBillingID = AdvanceBilling.ID

                            End If

                        ElseIf AdvanceBilling.ID <> 0 AndAlso AdvanceBilling.SequenceNumber <> 0 AndAlso String.IsNullOrWhiteSpace(AdvanceBilling.FunctionCode) = False AndAlso AdvanceBilling.NetAmount.GetValueOrDefault(0) <> 0 Then

                            If AdvantageFramework.Database.Procedures.AdvanceBilling.Update(DbContext, AdvanceBilling) = False Then

                                Throw New Exception("Failed to update advance billing.")

                            End If

                        ElseIf AdvanceBilling.ID <> 0 AndAlso AdvanceBilling.SequenceNumber <> 0 AndAlso String.IsNullOrWhiteSpace(AdvanceBilling.FunctionCode) = False AndAlso AdvanceBilling.NetAmount.GetValueOrDefault(0) = 0 Then

                            If AdvantageFramework.Database.Procedures.AdvanceBilling.Delete(DbContext, AdvanceBilling) = False Then

                                Throw New Exception("Failed to delete from advance billing.")

                            End If

                        End If

                        If IncomeRecognize.AdvanceBillingID = 0 AndAlso IncomeRecognize.Amount.GetValueOrDefault(0) <> 0 Then

                            If IncomeRecognize.AdvanceBillingID = 0 AndAlso AdvanceBillingID <> 0 Then

                                IncomeRecognize.AdvanceBillingID = AdvanceBillingID

                            End If

                            IncomeRecognize.FunctionCode = AdvanceBillingItem.FunctionCode
                            IncomeRecognize.BillingCommandCenterID = _BillingCommandCenterID
                            IncomeRecognize.GLACodeSales = AdvantageFramework.BillingCommandCenter.GetIncomeRecognitionSalesGeneralLedgerAccount(BCCDbContext, JobNumber, AdvanceBillingItem.FunctionCode)
                            IncomeRecognize.GLACodeDeferredSales = AdvantageFramework.BillingCommandCenter.GetIncomeRecognitionDeferredSalesGeneralLedgerAccount(DbContext, JobNumber)

                            If AdvantageFramework.Database.Procedures.IncomeRecognize.Insert(DbContext, IncomeRecognize) = False Then

                                Throw New Exception("Failed to insert income rec.")

                            ElseIf AdvanceBillingID = 0 Then

                                AdvanceBillingID = IncomeRecognize.AdvanceBillingID

                            End If

                        ElseIf IncomeRecognize.AdvanceBillingID <> 0 AndAlso IncomeRecognize.SequenceNumber <> 0 AndAlso IncomeRecognize.Amount.GetValueOrDefault(0) <> 0 Then

                            If AdvantageFramework.Database.Procedures.IncomeRecognize.Update(DbContext, IncomeRecognize) = False Then

                                Throw New Exception("Failed to update income rec.")

                            End If

                        ElseIf IncomeRecognize.AdvanceBillingID <> 0 AndAlso IncomeRecognize.SequenceNumber <> 0 AndAlso IncomeRecognize.Amount.GetValueOrDefault(0) = 0 Then

                            If AdvantageFramework.Database.Procedures.IncomeRecognize.Delete(DbContext, IncomeRecognize) = False Then

                                Throw New Exception("Failed to delete income rec.")

                            End If

                        End If

                    End If

                Next

                AdvantageFramework.BillingCommandCenter.UpdateJobComponentBasedOnAdvanceBilling(DbContext, JobNumber, JobComponentNumber, If(ButtonItemIncomeMethod_UponReconciliation.Checked, 1, 2), True)

            End If

        End Sub
        Private Sub RefreshAndKeepIncomeOnlyTabFocused()

            Me.FormAction = WinForm.Presentation.FormActions.Refreshing

            LoadFunctions()

            TabItemFunctionItems_IncomeOnly.Tag = False

            TabControlRightSection_FunctionItems.SelectedTab = TabItemFunctionItems_IncomeOnly

            LoadFunctionItems()

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub RefreshAndKeepVendorTabFocused()

            Me.FormAction = WinForm.Presentation.FormActions.Refreshing

            LoadFunctions()

            TabItemFunctionItems_Vendor.Tag = False

            TabControlRightSection_FunctionItems.SelectedTab = TabItemFunctionItems_Vendor

            LoadFunctionItems()

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub RefreshFunctions()

            If Me.FormShown Then

                Me.ShowWaitForm("Loading...")

                Me.FormAction = WinForm.Presentation.FormActions.Loading

                LoadFunctions()

                Me.FormAction = WinForm.Presentation.FormActions.None

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub CopyFunctionsForAdvanceBilling(ByVal JobComponentFunctionDetails As IEnumerable(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail),
                                                   ByVal IncludeOpenPO As Boolean, ByVal UseApprovedAmount As Boolean, ByVal SkipAmounts As Boolean)

            Dim JobNumber As Integer = 0
            Dim JobComponentNumber As Short = 0
            Dim AdvanceBillingItemList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem) = Nothing
            Dim AdvanceBillingItem As AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem = Nothing
            Dim AdvanceBilling As AdvantageFramework.Database.Entities.AdvanceBilling = Nothing
            Dim BillingApprovalDetail As AdvantageFramework.Database.Entities.BillingApprovalDetail = Nothing

            JobNumber = DirectCast(DataGridViewLeftSection_Jobs.CurrentView.GetRow(DataGridViewLeftSection_Jobs.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.JobDetailJobComponent).JobNumber
            JobComponentNumber = DirectCast(DataGridViewLeftSection_Jobs.CurrentView.GetRow(DataGridViewLeftSection_Jobs.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.JobDetailJobComponent).JobComponentNumber

            AdvanceBillingItemList = DataGridViewAdvanceBilling_Details.GetAllRowsDataBoundItems().OfType(Of AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem).ToList()

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                For Each JobComponentFunctionDetail In JobComponentFunctionDetails.Where(Function(JCF) JCF.FunctionType <> "C")

                    If Not UseApprovedAmount OrElse (UseApprovedAmount AndAlso JobComponentFunctionDetail.BillingApprovalFunctionAmount.GetValueOrDefault(0) <> 0) Then

                        AdvanceBillingItem = AdvanceBillingItemList.Where(Function(ABI) ABI.FunctionCode = JobComponentFunctionDetail.FunctionCode).FirstOrDefault

                        If AdvanceBillingItem Is Nothing Then

                            AdvanceBilling = New AdvantageFramework.Database.Entities.AdvanceBilling
                            AdvanceBilling.BillDate = Now.ToShortDateString
                            AdvanceBilling.AdvanceBillFlag = 2
                            AdvanceBilling.CreateDate = Now.ToShortDateString
                            AdvanceBilling.UserCode = Session.UserCode
                            AdvanceBilling.JobNumber = JobNumber
                            AdvanceBilling.JobComponentNumber = JobComponentNumber
                            AdvanceBilling.FunctionCode = JobComponentFunctionDetail.FunctionCode
                            AdvanceBilling.FunctionType = JobComponentFunctionDetail.FunctionType

                        Else

                            AdvanceBilling = AdvanceBillingItem.AdvanceBilling

                        End If

                        If UseApprovedAmount Then

                            If JobComponentFunctionDetail.BillingApprovalDetailID.HasValue Then

                                BillingApprovalDetail = AdvantageFramework.Database.Procedures.BillingApprovalDetail.LoadByID(DbContext, JobComponentFunctionDetail.BillingApprovalDetailID)

                                If BillingApprovalDetail IsNot Nothing Then

                                    If BillingApprovalDetail.NetAmount.HasValue Then

                                        AdvanceBilling.NetAmount = BillingApprovalDetail.NetAmount

                                    Else

                                        AdvanceBilling.NetAmount = BillingApprovalDetail.ApprovedAmount.GetValueOrDefault(0)

                                    End If

                                    AdvanceBilling.ExtendedMarkupAmount = BillingApprovalDetail.MarkupAmount.GetValueOrDefault(0)
                                    AdvanceBilling.ExtendedNonResaleTax = BillingApprovalDetail.VendorTaxAmount.GetValueOrDefault(0)

                                End If

                            End If

                        Else

                            If Not SkipAmounts Then

                                AdvanceBilling.NetAmount = JobComponentFunctionDetail.UnbilledNetOnly.GetValueOrDefault(0) + If(IncludeOpenPO, JobComponentFunctionDetail.OpenPOAmount.GetValueOrDefault(0), 0)
                                AdvanceBilling.ExtendedMarkupAmount = JobComponentFunctionDetail.UnbilledMarkupAmount

                            End If

                        End If

                        AdvanceBilling.UseContingency = 0

                        If AdvanceBillingItem Is Nothing Then

                            AdvanceBillingItem = New AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem(AdvanceBilling, DbContext)

                            AdvanceBillingItemList.Add(AdvanceBillingItem)

                        End If

                        AdvanceBillingItem.SetAdvanceBillingFunctionCode(DbContext, AdvanceBillingItem.FunctionCode)

                        AdvanceBillingItem.SetBillingRate(DbContext)

                        AdvanceBillingItem.QuantityHours = Nothing
                        AdvanceBillingItem.Rate = Nothing

                        AdvanceBillingItem.CalculateAdvanceBilling(Me.Session, True, True)

                    End If

                Next

                DataGridViewAdvanceBilling_Details.DataSource = AdvanceBillingItemList

                SortAdvanceBillingGrid()

                DataGridViewAdvanceBilling_Details.CurrentView.BestFitColumns()
                DataGridViewAdvanceBilling_Details.SetUserEntryChanged()

            End Using

            EnableOrDisableActions()

        End Sub
        Private Sub ResizeControlToFitParent(ByVal Control As Windows.Forms.Control)

            If Control.Parent.Width >= 8 AndAlso Control.Parent.Height >= 18 Then

                Control.Size = New System.Drawing.Size(Control.Parent.Width - 8, Control.Parent.Height - 18)

            End If

        End Sub
        Private Sub SetFunctionTab()

            Dim JobComponentFunctionDetails As IEnumerable(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail) = Nothing

            JobComponentFunctionDetails = DataGridViewTop_JobComponentFunctions.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail).ToList()

            If JobComponentFunctionDetails.FirstOrDefault IsNot Nothing Then

                Select Case JobComponentFunctionDetails.FirstOrDefault.FunctionType

                    Case "E"

                        TabControlRightSection_FunctionItems.SelectedTab = TabItemFunctionItems_EmployeeTime

                    Case "I"

                        TabControlRightSection_FunctionItems.SelectedTab = TabItemFunctionItems_IncomeOnly

                    Case "V"

                        TabControlRightSection_FunctionItems.SelectedTab = TabItemFunctionItems_Vendor

                End Select

            End If

        End Sub
        Private Function SelectedJobComponentReconcileStatusCheckable() As Boolean

            Dim JobNumber As Integer = Nothing
            Dim JobComponentNumber As Short = Nothing
            Dim ProductionSummary As AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary = Nothing
            Dim Editable As Boolean = False

            JobNumber = DirectCast(DataGridViewLeftSection_Jobs.CurrentView.GetRow(DataGridViewLeftSection_Jobs.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.JobDetailJobComponent).JobNumber
            JobComponentNumber = DirectCast(DataGridViewLeftSection_Jobs.CurrentView.GetRow(DataGridViewLeftSection_Jobs.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.JobDetailJobComponent).JobComponentNumber

            ProductionSummary = _ProductionSummaryList.Where(Function(PS) PS.JobNumber = JobNumber AndAlso PS.ComponentNumber = JobComponentNumber).FirstOrDefault

            If ProductionSummary IsNot Nothing AndAlso String.IsNullOrWhiteSpace(ProductionSummary.ReconcileStatus) = False AndAlso CInt(ProductionSummary.ReconcileStatus) <= 2 Then

                Editable = True

            End If

            SelectedJobComponentReconcileStatusCheckable = Editable

        End Function
        Private Sub SetEmployeeTimeMarkupAmount(ByVal EmployeeTimeItem As AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem, ByVal MarkupAmount As Decimal)

            EmployeeTimeItem.MarkupAmountChanged = True

            If MarkupAmount = 0 Then

                EmployeeTimeItem.CommissionPercentage = 0

            ElseIf (EmployeeTimeItem.Hours * EmployeeTimeItem.BillableRate) <> 0 Then

                EmployeeTimeItem.CommissionPercentage = FormatNumber((MarkupAmount / (EmployeeTimeItem.Hours * EmployeeTimeItem.BillableRate)) * 100, 3)

                If EmployeeTimeItem.CommissionPercentage > 999999.999 Then

                    EmployeeTimeItem.CommissionPercentage = 999999.999

                ElseIf EmployeeTimeItem.CommissionPercentage < -999999.999 Then

                    EmployeeTimeItem.CommissionPercentage = -999999.999

                End If

            End If

        End Sub
        Private Sub AdjustEmployeeMarkupToAmount(ByVal AdjustTo As AdjustToFunction)

            Dim JobComponentFunctionDetails As IEnumerable(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail) = Nothing
            Dim EmployeeTimeItems As IEnumerable(Of AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem) = Nothing
            Dim TotalEmpAmount As Decimal = Nothing
            Dim AdjustmentAmount As Decimal = Nothing
            Dim UserEntryChanged As Boolean = False
            Dim AdjustmentTotal As Decimal = Nothing
            Dim DiffAmt As Decimal = Nothing
            Dim AdjustToAmount As Decimal = Nothing

            DataGridViewEmployeeTime_Details.CurrentView.CloseEditorForUpdating()

            JobComponentFunctionDetails = DataGridViewTop_JobComponentFunctions.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail)().ToList()

            For Each JobComponentFunctionDetail In JobComponentFunctionDetails

                Select Case AdjustTo

                    Case AdjustToFunction.EstimateAmount

                        AdjustToAmount = JobComponentFunctionDetail.EstimateAmount

                    Case AdjustToFunction.ApprovedAmount

                        AdjustToAmount = JobComponentFunctionDetail.BillingApprovalFunctionAmount.GetValueOrDefault(0)

                    Case AdjustToFunction.BilledAmount

                        AdjustToAmount = JobComponentFunctionDetail.TotalBilledAmount

                End Select

                If AdjustTo <> AdjustToFunction.ApprovedAmount OrElse (AdjustTo = AdjustToFunction.ApprovedAmount AndAlso JobComponentFunctionDetail.BillingApprovalFunctionAmount.HasValue) Then

                    EmployeeTimeItems = DataGridViewEmployeeTime_Details.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem)().ToList.Where(Function(ETI) ETI.FunctionCode = JobComponentFunctionDetail.FunctionCode AndAlso ETI.IsNonBillable.GetValueOrDefault(0) = 0).ToList()

                    For Each EmployeeTimeItem In EmployeeTimeItems

                        EmployeeTimeItem.CommissionPercentage = 0

                        EmployeeTimeRecalculateRow(EmployeeTimeItem)

                    Next

                    TotalEmpAmount = EmployeeTimeItems.Sum(Function(ETI) ETI.Total)

                    If EmployeeTimeItems.Count > 0 AndAlso EmployeeTimeItems.Sum(Function(ETI) ETI.Total) <> AdjustToAmount AndAlso TotalEmpAmount <> 0 Then

                        AdjustmentTotal = AdjustToAmount - TotalEmpAmount

                        For Each EmployeeTimeItem In EmployeeTimeItems

                            AdjustmentAmount = FormatNumber(EmployeeTimeItem.Total / TotalEmpAmount * AdjustmentTotal, 2)

                            EmployeeTimeItem.MarkupAmount = EmployeeTimeItem.MarkupAmount + AdjustmentAmount

                            If EmployeeTimeItem.Equals(EmployeeTimeItems(EmployeeTimeItems.Count - 1)) AndAlso EmployeeTimeItems.Sum(Function(ETI) ETI.TotalBill + ETI.MarkupAmount) <> AdjustToAmount Then

                                DiffAmt = EmployeeTimeItems.Sum(Function(ETI) ETI.TotalBill + ETI.MarkupAmount) - AdjustToAmount

                                EmployeeTimeItem.MarkupAmount = EmployeeTimeItem.MarkupAmount - DiffAmt

                            End If

                            SetEmployeeTimeMarkupAmount(EmployeeTimeItem, EmployeeTimeItem.MarkupAmount)

                            EmployeeTimeRecalculateRow(EmployeeTimeItem, True)

                            DataGridViewEmployeeTime_Details.CurrentView.AddToModifiedRows(EmployeeTimeItem)

                            DataGridViewEmployeeTime_Details.CurrentView.RefreshData()

                        Next

                        UserEntryChanged = True

                    End If

                End If

            Next

            If UserEntryChanged Then

                DataGridViewEmployeeTime_Details.SetUserEntryChanged()

                EnableOrDisableActions()

            End If

        End Sub
        Private Function AdvanceBillingIsValid(ByRef IsValid As Boolean) As String

            Dim AdvanceBillingItemList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem) = Nothing
            Dim ErrorText As String = Nothing
            Dim PropertyErrorText As String = Nothing
            Dim FailedOnce As Boolean = False

            AdvanceBillingItemList = DataGridViewAdvanceBilling_Details.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem)().ToList

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                For Each AdvanceBillingItem In AdvanceBillingItemList

                    AdvanceBillingItem.DbContext = DbContext
                    AdvanceBillingItem.DbContext = DbContext

                    PropertyErrorText = AdvanceBillingItem.ValidateEntity(IsValid)

                    If IsValid = False Then

                        ErrorText = IIf(ErrorText = "", PropertyErrorText, ErrorText & Environment.NewLine & PropertyErrorText)

                        FailedOnce = True

                    End If

                Next

            End Using

            IsValid = Not FailedOnce

            AdvanceBillingIsValid = ErrorText

        End Function
        Private Sub CloseCustomizationForms()

            If DataGridViewEmployeeTime_Details.CurrentView.CustomizationForm IsNot Nothing Then

                DataGridViewEmployeeTime_Details.CurrentView.DestroyCustomization()

            End If

            If DataGridViewIncomeOnly_Details.CurrentView.CustomizationForm IsNot Nothing Then

                DataGridViewIncomeOnly_Details.CurrentView.DestroyCustomization()

            End If

            If DataGridViewVendor_Details.CurrentView.CustomizationForm IsNot Nothing Then

                DataGridViewVendor_Details.CurrentView.DestroyCustomization()

            End If

        End Sub
        Private Sub CheckUncheckFunctionsBasedOnEmployeeTimeChecked(ByVal RowHandle As Integer, ByVal Checked As Boolean)

            Dim FunctionCode As String = Nothing
            Dim JobComponentFunctionDetails As IEnumerable(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail) = Nothing
            Dim EmployeeTimeItem As AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem = Nothing

            JobComponentFunctionDetails = DataGridViewTop_JobComponentFunctions.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail).ToList

            FunctionCode = DirectCast(DataGridViewEmployeeTime_Details.CurrentView.GetRow(RowHandle), AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem).FunctionCode

            EmployeeTimeItem = DirectCast(DataGridViewEmployeeTime_Details.CurrentView.GetRow(RowHandle), AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem)
            EmployeeTimeItem.Reconcile = Checked

            If Checked = False Then

                JobComponentFunctionDetails.Where(Function(JC) JC.FunctionCode = FunctionCode).SingleOrDefault.Reconcile = False

            Else

                If (From Entity In DataGridViewEmployeeTime_Details.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem).ToList
                    Where Entity.Equals(EmployeeTimeItem) = False AndAlso
                          Entity.FunctionCode = FunctionCode AndAlso
                          Entity.Reconcile = False
                    Select Entity).Any = False Then

                    JobComponentFunctionDetails.Where(Function(JC) JC.FunctionCode = FunctionCode).SingleOrDefault.Reconcile = True

                End If

            End If

            DataGridViewTop_JobComponentFunctions.CurrentView.RefreshData()

        End Sub
        Private Sub CheckUncheckFunctionsBasedOnIncomeOnlyChecked(ByVal RowHandle As Integer, ByVal Checked As Boolean)

            Dim FunctionCode As String = Nothing
            Dim JobComponentFunctionDetails As IEnumerable(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail) = Nothing
            Dim IncomeOnlyItem As AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem = Nothing

            JobComponentFunctionDetails = DataGridViewTop_JobComponentFunctions.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail).ToList

            FunctionCode = DirectCast(DataGridViewIncomeOnly_Details.CurrentView.GetRow(RowHandle), AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem).FunctionCode

            IncomeOnlyItem = DirectCast(DataGridViewIncomeOnly_Details.CurrentView.GetRow(RowHandle), AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem)
            IncomeOnlyItem.Reconcile = Checked

            If Checked = False Then

                JobComponentFunctionDetails.Where(Function(JC) JC.FunctionCode = FunctionCode).SingleOrDefault.Reconcile = False

            Else

                If (From Entity In DataGridViewIncomeOnly_Details.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem).ToList
                    Where Entity.Equals(IncomeOnlyItem) = False AndAlso
                          Entity.FunctionCode = FunctionCode AndAlso
                          Entity.Reconcile = False
                    Select Entity).Any = False Then

                    JobComponentFunctionDetails.Where(Function(JC) JC.FunctionCode = FunctionCode).SingleOrDefault.Reconcile = True

                End If

            End If

            DataGridViewTop_JobComponentFunctions.CurrentView.RefreshData()

        End Sub
        Private Sub CheckUncheckFunctionsBasedOnVendorChecked(ByVal RowHandle As Integer, ByVal Checked As Boolean)

            Dim FunctionCode As String = Nothing
            Dim JobComponentFunctionDetails As IEnumerable(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail) = Nothing
            Dim AccountPayableProductionItem As AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem = Nothing

            JobComponentFunctionDetails = DataGridViewTop_JobComponentFunctions.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail).ToList

            FunctionCode = DirectCast(DataGridViewVendor_Details.CurrentView.GetRow(RowHandle), AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem).FunctionCode

            AccountPayableProductionItem = DirectCast(DataGridViewVendor_Details.CurrentView.GetRow(RowHandle), AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem)
            AccountPayableProductionItem.Reconcile = Checked

            If Checked = False Then

                JobComponentFunctionDetails.Where(Function(JC) JC.FunctionCode = FunctionCode).SingleOrDefault.Reconcile = False

            Else

                If (From Entity In DataGridViewVendor_Details.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem).ToList
                    Where Entity.Equals(AccountPayableProductionItem) = False AndAlso
                          Entity.FunctionCode = FunctionCode AndAlso
                          Entity.Reconcile = False
                    Select Entity).Any = False Then

                    JobComponentFunctionDetails.Where(Function(JC) JC.FunctionCode = FunctionCode).SingleOrDefault.Reconcile = True

                End If

            End If

            DataGridViewTop_JobComponentFunctions.CurrentView.RefreshData()

        End Sub
        Private Sub CheckUncheckFunctionItemsForReconcile(ByVal RowHandle As Integer, ByVal Checked As Boolean)

            Dim FunctionType As String = Nothing
            Dim EmployeeTimeItems As IEnumerable(Of AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem) = Nothing
            Dim IncomeOnlyItems As IEnumerable(Of AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem) = Nothing
            Dim AccountPayableProductionItems As IEnumerable(Of AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem) = Nothing

            FunctionType = DirectCast(DataGridViewTop_JobComponentFunctions.CurrentView.GetRow(RowHandle), AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail).FunctionType

            If FunctionType = "E" Then

                EmployeeTimeItems = DataGridViewEmployeeTime_Details.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem).ToList

                For Each EmployeeTimeItem In EmployeeTimeItems

                    EmployeeTimeItem.Reconcile = Checked

                Next

                DataGridViewEmployeeTime_Details.CurrentView.RefreshData()

            ElseIf FunctionType = "I" Then

                IncomeOnlyItems = DataGridViewIncomeOnly_Details.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem).ToList

                For Each IncomeOnlyItem In IncomeOnlyItems

                    IncomeOnlyItem.Reconcile = Checked

                Next

                DataGridViewIncomeOnly_Details.CurrentView.RefreshData()

            ElseIf FunctionType = "V" Then

                AccountPayableProductionItems = DataGridViewVendor_Details.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem).ToList

                For Each AccountPayableProductionItem In AccountPayableProductionItems

                    AccountPayableProductionItem.Reconcile = Checked

                Next

                DataGridViewVendor_Details.CurrentView.RefreshData()

            End If

            DataGridViewTop_JobComponentFunctions.CurrentView.RefreshRow(RowHandle)

        End Sub
        Private Function IsValidToSave(ByRef ErrorMessage As String) As Boolean

            Dim IsValid As Boolean = True
            'Dim JobComponentFunctionDetails As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail) = Nothing
            'Dim AdvanceBillingItems As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem) = Nothing

            If Me.Validator Then

                If TabControlRightSection_FunctionItems.SelectedTab Is TabItemFunctionItems_EmployeeTime AndAlso DataGridViewEmployeeTime_Details.HasAnyInvalidRows OrElse
                        TabControlRightSection_FunctionItems.SelectedTab Is TabItemFunctionItems_IncomeOnly AndAlso DataGridViewIncomeOnly_Details.HasAnyInvalidRows OrElse
                        TabControlRightSection_FunctionItems.SelectedTab Is TabItemFunctionItems_Vendor AndAlso DataGridViewVendor_Details.HasAnyInvalidRows Then

                    ErrorMessage = "Fix invalid rows."
                    IsValid = False

                ElseIf TabControlRightSection_FunctionItems.SelectedTab Is TabItemFunctionItems_AdvanceBilling Then

                    ErrorMessage = AdvanceBillingIsValid(IsValid)

                    'JobComponentFunctionDetails = DataGridViewTop_JobComponentFunctions.GetAllRowsDataBoundItems().OfType(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail).ToList()
                    'AdvanceBillingItems = DataGridViewAdvanceBilling_Details.GetAllRowsDataBoundItems().OfType(Of AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem).ToList()

                    'If AdvanceBillingItems.Sum(Function(AB) AB.AmountToRecognize.GetValueOrDefault(0) + AB.PriorIncomeRec) > JobComponentFunctionDetails.Sum(Function(JCF) JCF.EstimateAmount) Then

                    '    ErrorMessage += "Total income to recognize cannot exceed estimate total."

                    'End If

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                IsValid = False

            End If

            IsValidToSave = IsValid

        End Function
        Private Sub AddIncomeRecByPercentCompleteByJob(ByVal TimeOnly As Boolean)

            Dim JobComponentFunctionDetails As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail) = Nothing
            Dim EstimateTotal As Decimal = 0
            Dim PercentComplete As Decimal = 0
            Dim AdvanceBillingItemList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem) = Nothing
            Dim AdvanceBillingItem As AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem = Nothing

            DataGridViewAdvanceBilling_Details.CurrentView.CloseEditorForUpdating()

            If TimeOnly Then

                JobComponentFunctionDetails = DataGridViewTop_JobComponentFunctions.GetAllRowsDataBoundItems().OfType(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail).Where(Function(JCF) JCF.FunctionType = "E").ToList()

            Else

                JobComponentFunctionDetails = DataGridViewTop_JobComponentFunctions.GetAllRowsDataBoundItems().OfType(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail).ToList()

            End If

            EstimateTotal = JobComponentFunctionDetails.Sum(Function(JCF) JCF.EstimateNetAmount + JCF.EstimateMarkupAmount)

            If EstimateTotal <> 0 Then

                PercentComplete = FormatNumber(JobComponentFunctionDetails.Sum(Function(JCF) JCF.ActualBillableNetAmount.GetValueOrDefault(0) +
                                                                                  JCF.ActualBillableMarkupAmount.GetValueOrDefault(0) + JCF.FeeAmount.GetValueOrDefault(0)) / EstimateTotal * 100, 2)

            End If

            If AdvantageFramework.WinForm.Presentation.NumericInputDialog.ShowFormDialog("Confirm/Override % Complete", "% Complete:", PercentComplete, PercentComplete, Nothing, WinForm.Presentation.Controls.NumericInput.Type.Decimal, True, 0, 100.0, "n2") = Windows.Forms.DialogResult.OK Then

                AdvanceBillingItemList = DataGridViewAdvanceBilling_Details.GetAllRowsDataBoundItems().OfType(Of AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem).ToList()

                AdvanceBillingItem = AdvanceBillingItemList.Where(Function(ABI) ABI.FunctionCode Is Nothing).FirstOrDefault

                If AdvanceBillingItem IsNot Nothing Then

                    AdvanceBillingItem.AmountToRecognize = FormatNumber(PercentComplete * EstimateTotal / 100, 2)

                    DataGridViewAdvanceBilling_Details.CurrentView.RefreshData()

                Else

                    AdvanceBillingItem = New AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem

                    AdvanceBillingItem.InitializeIncomeRecognize(Session.UserCode, JobComponentFunctionDetails.FirstOrDefault.JobNumber, JobComponentFunctionDetails.First.ComponentNumber)

                    AdvanceBillingItem.AmountToRecognize = FormatNumber((PercentComplete * EstimateTotal / 100) - AdvanceBillingItem.PriorIncomeRec, 2)

                    AdvanceBillingItemList.Add(AdvanceBillingItem)

                    DataGridViewAdvanceBilling_Details.DataSource = AdvanceBillingItemList

                    SortAdvanceBillingGrid()

                End If

                DataGridViewAdvanceBilling_Details.SetUserEntryChanged()

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub AddIncomeRecByPercentCompleteByJobFunction(ByVal TimeOnly As Boolean)

            Dim JobComponentFunctionDetails As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail) = Nothing
            Dim EstimateTotal As Decimal = 0
            Dim PercentComplete As Decimal = 0
            Dim AdvanceBillingItemList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem) = Nothing
            Dim AdvanceBillingItem As AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem = Nothing
            Dim DataChanged As Boolean = False

            DataGridViewAdvanceBilling_Details.CurrentView.CloseEditorForUpdating()

            If TimeOnly Then

                JobComponentFunctionDetails = DataGridViewTop_JobComponentFunctions.GetAllRowsDataBoundItems().OfType(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail).Where(Function(JCF) JCF.FunctionType = "E").ToList()

            Else

                JobComponentFunctionDetails = DataGridViewTop_JobComponentFunctions.GetAllRowsDataBoundItems().OfType(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail).ToList()

            End If

            If JobComponentFunctionDetails.Sum(Function(JCF) JCF.EstimateNetAmount + JCF.EstimateMarkupAmount) <> 0 Then

                PercentComplete = FormatNumber(JobComponentFunctionDetails.Sum(Function(JCF) JCF.ActualBillableNetAmount.GetValueOrDefault(0) + JCF.ActualBillableMarkupAmount.GetValueOrDefault(0) + JCF.FeeAmount.GetValueOrDefault(0)) _
                                                                                / JobComponentFunctionDetails.Sum(Function(JCF) JCF.EstimateNetAmount + JCF.EstimateMarkupAmount) * 100, 2)

            End If

            If AdvantageFramework.WinForm.Presentation.NumericInputDialog.ShowFormDialog("Confirm/Override % Complete", "% Complete:", PercentComplete, PercentComplete, Nothing, WinForm.Presentation.Controls.NumericInput.Type.Decimal, True, 0, 100.0, "n2") = Windows.Forms.DialogResult.OK Then

                AdvanceBillingItemList = DataGridViewAdvanceBilling_Details.GetAllRowsDataBoundItems().OfType(Of AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem).ToList()

                For Each JobComponentFunctionDetail In JobComponentFunctionDetails

                    EstimateTotal = JobComponentFunctionDetail.EstimateNetAmount + JobComponentFunctionDetail.EstimateMarkupAmount

                    AdvanceBillingItem = AdvanceBillingItemList.Where(Function(ABI) ABI.FunctionCode = JobComponentFunctionDetail.FunctionCode).FirstOrDefault

                    If AdvanceBillingItem IsNot Nothing Then

                        AdvanceBillingItem.AmountToRecognize = FormatNumber((PercentComplete * EstimateTotal / 100) - AdvanceBillingItem.PriorIncomeRec, 2)

                    Else

                        AdvanceBillingItem = New AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem

                        AdvanceBillingItem.InitializeIncomeRecognize(Session.UserCode, JobComponentFunctionDetails.FirstOrDefault.JobNumber, JobComponentFunctionDetails.First.ComponentNumber)

                        AdvanceBillingItem.FunctionCode = JobComponentFunctionDetail.FunctionCode

                        AdvanceBillingItem.AmountToRecognize = FormatNumber(PercentComplete * EstimateTotal / 100, 2)

                        AdvanceBillingItemList.Add(AdvanceBillingItem)

                    End If

                    DataChanged = True

                Next

                If DataChanged Then

                    DataGridViewAdvanceBilling_Details.DataSource = AdvanceBillingItemList

                    SortAdvanceBillingGrid()

                    DataGridViewAdvanceBilling_Details.SetUserEntryChanged()

                    EnableOrDisableActions()

                End If

            End If

        End Sub
        Private Sub RefreshColumnOrderAndVisibilityReconcileMode()

            'objects
            Dim ColumnVisibleIndex As Integer = Nothing

            ColumnVisibleIndex = 1

            DataGridViewTop_JobComponentFunctions.CurrentView.BeginUpdate()

            For Each GridColumn In DataGridViewTop_JobComponentFunctions.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                GridColumn.Visible = False

            Next

            HideOrShowColumn(AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.Reconcile.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.FunctionType.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.FunctionCode.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.FunctionDescription.ToString, ColumnVisibleIndex)

            HideOrShowColumn(AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.EstimateAmount.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.ActualBillableAmount.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.AdvanceBilledAmount.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.BilledAmount.ToString, ColumnVisibleIndex, "Billed/Reconciled" & vbCrLf & "Amount")
            HideOrShowColumn(AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.TotalBilledAmount.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.UnbilledAmount.ToString, ColumnVisibleIndex, "Unbilled/Unreconciled" & vbCrLf & "Amount")
            HideOrShowColumn(AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.AdvanceBillingBalance.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.AmountToReconcile.ToString, ColumnVisibleIndex)

            DataGridViewTop_JobComponentFunctions.CurrentView.EndUpdate()

            DataGridViewTop_JobComponentFunctions.CurrentView.BestFitColumns()

        End Sub
        Private Sub HideOrShowColumn(ByVal FieldName As String, ByRef VisibleIndex As Integer, Optional CaptionOverride As String = Nothing)

            If DataGridViewTop_JobComponentFunctions.CurrentView.Columns(FieldName) IsNot Nothing Then

                Select Case FieldName

                    Case AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.Reconcile.ToString,
                         AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.FunctionType.ToString,
                         AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.FunctionCode.ToString,
                         AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.FunctionDescription.ToString

                        DataGridViewTop_JobComponentFunctions.CurrentView.Columns(FieldName).Visible = True
                        DataGridViewTop_JobComponentFunctions.CurrentView.Columns(FieldName).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

                    Case AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.EstimateAmount.ToString,
                         AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.ActualBillableAmount.ToString,
                         AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.AdvanceBilledAmount.ToString,
                         AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.BilledAmount.ToString,
                         AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.TotalBilledAmount.ToString,
                         AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.UnbilledAmount.ToString,
                         AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.AdvanceBillingBalance.ToString,
                         AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.AmountToReconcile.ToString

                        DataGridViewTop_JobComponentFunctions.CurrentView.Columns(FieldName).Visible = True

                End Select

                DataGridViewTop_JobComponentFunctions.CurrentView.Columns(FieldName).VisibleIndex = VisibleIndex

                VisibleIndex = VisibleIndex + 1

                If CaptionOverride IsNot Nothing Then

                    DataGridViewTop_JobComponentFunctions.CurrentView.Columns(FieldName).Caption = CaptionOverride

                End If

            End If

        End Sub
        Private Sub SaveUserSetting(SettingCode As String, StringValue As String)

            'objects
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing

            If Not _IsClosing Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Try

                        UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, Me.Session.User.ID, SettingCode)

                    Catch ex As Exception
                        UserSetting = Nothing
                    End Try

                    If UserSetting IsNot Nothing Then

                        UserSetting.StringValue = StringValue

                        AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting)

                    ElseIf UserSetting Is Nothing Then

                        AdvantageFramework.Security.Database.Procedures.UserSetting.Insert(SecurityDbContext, Me.Session.User.ID, SettingCode, StringValue, Nothing, Nothing, UserSetting)

                    End If

                End Using

            End If

        End Sub
        Private Function GetUserSetting(SettingCode As String) As Boolean

            'objects
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing
            Dim StringValue As String = "N"

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Try

                    UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, Me.Session.User.ID, SettingCode)

                Catch ex As Exception
                    UserSetting = Nothing
                End Try

                If UserSetting IsNot Nothing AndAlso String.IsNullOrWhiteSpace(UserSetting.StringValue) = False Then

                    StringValue = UserSetting.StringValue

                End If

            End Using

            GetUserSetting = If(StringValue = "Y", True, False)

        End Function
        Private Sub SetAdjusted(Adjusted As Boolean)

            Dim JobNumber As Integer = Nothing
            Dim JobComponentNumber As Short = Nothing
            Dim AdjustUser As String = Nothing
            Dim ProductionSummary As AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary = Nothing

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                JobNumber = DirectCast(DataGridViewLeftSection_Jobs.CurrentView.GetRow(DataGridViewLeftSection_Jobs.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.JobDetailJobComponent).JobNumber
                JobComponentNumber = DirectCast(DataGridViewLeftSection_Jobs.CurrentView.GetRow(DataGridViewLeftSection_Jobs.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.JobDetailJobComponent).JobComponentNumber
                AdjustUser = If(Adjusted, "'" & Session.UserCode & "'", "NULL")

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.JOB_COMPONENT SET ADJUST_USER = {2} WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1}", JobNumber, JobComponentNumber, AdjustUser))

                End Using

                DataGridViewLeftSection_Jobs.CurrentView.SetRowCellValue(DataGridViewLeftSection_Jobs.CurrentView.FocusedRowHandle, AdvantageFramework.BillingCommandCenter.Classes.JobDetailJobComponent.Properties.IsAdjusted.ToString, ButtonItemStatus_Adjusted.Checked)
                DataGridViewLeftSection_Jobs.CurrentView.RefreshRow(DataGridViewLeftSection_Jobs.CurrentView.FocusedRowHandle)

                ProductionSummary = _ProductionSummaryList.Where(Function(PS) PS.JobNumber = JobNumber AndAlso PS.ComponentNumber = JobComponentNumber).FirstOrDefault()

                If ProductionSummary IsNot Nothing Then

                    ProductionSummary.IsAdjusted = Adjusted

                End If

            End If

        End Sub
        Private Function GetRectangleForRow(TotalIndex As Integer, Bounds As System.Drawing.Rectangle, FontHeight As Integer, DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView) As System.Drawing.Rectangle

            'objects
            Dim Rectangle As System.Drawing.Rectangle = Nothing
            Dim GridColumnRectangle As System.Drawing.Rectangle = Nothing
            Dim HorizontalIndent As Integer = 0
            Dim VerticalIndent As Integer = Bounds.Height / 2 '2 = the number of SummaryTypes for the column
            Dim GridViewInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridViewInfo = Nothing

            GridViewInfo = DataGridView.CurrentView.GetViewInfo()

            If DataGridView.CurrentView.VisibleColumns.Count >= 2 AndAlso GridViewInfo.ColumnsInfo(DataGridView.Columns(DataGridView.CurrentView.VisibleColumns(1).Name)) IsNot Nothing Then '1 because we can order the columns, this will put the label to the left of the 2nd most column from the left

                DataGridView.CurrentView.VisibleColumns(0).MinWidth = COLUMN_MIN_WIDTH_FOR_SELECTED_LABEL

                GridColumnRectangle = GridViewInfo.ColumnsInfo(DataGridView.Columns(DataGridView.CurrentView.VisibleColumns(1).Name)).Bounds

                HorizontalIndent = GridColumnRectangle.Left - 50

                Rectangle = New System.Drawing.Rectangle(Bounds.Left + HorizontalIndent, Bounds.Top + VerticalIndent * TotalIndex + (VerticalIndent - FontHeight) / 2, HorizontalIndent, GridColumnRectangle.Height)

            End If

            GetRectangleForRow = Rectangle

        End Function

#Region "  Show Form Methods "

        Public Shared Sub ShowForm(ByVal BaseFormParent As AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm,
                                   ByVal ProductionSummaryList As IEnumerable(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary),
                                   ByVal BillingCommandCenterID As Integer, ByVal IncludeContingency As Short)

            'objects
            Dim BillingCommandCenterJobDetailDialog As AdvantageFramework.Billing.Presentation.BillingCommandCenterJobDetailDialog = Nothing

            BillingCommandCenterJobDetailDialog = New AdvantageFramework.Billing.Presentation.BillingCommandCenterJobDetailDialog(ProductionSummaryList, BillingCommandCenterID, IncludeContingency, False)

            BillingCommandCenterJobDetailDialog.SetBaseFormParent(BaseFormParent, BillingCommandCenterJobDetailDialog)

            BillingCommandCenterJobDetailDialog.Show()

        End Sub
        Public Shared Function ShowFormDialog(ByVal BillingCommandCenterID As Integer, ByVal IncludeContingency As Short, ByRef ProductionSummaryList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary)) As System.Windows.Forms.DialogResult

            'objects
            Dim BillingCommandCenterJobDetailDialog As AdvantageFramework.Billing.Presentation.BillingCommandCenterJobDetailDialog = Nothing

            BillingCommandCenterJobDetailDialog = New AdvantageFramework.Billing.Presentation.BillingCommandCenterJobDetailDialog(ProductionSummaryList, BillingCommandCenterID, IncludeContingency, True)

            ShowFormDialog = BillingCommandCenterJobDetailDialog.ShowDialog()

            ProductionSummaryList = BillingCommandCenterJobDetailDialog.ProductionSummaryList

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub BillingCommandCenterJobDetailDialog_FormClosing(sender As Object, e As Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

            If _ReconcileMode Then

                DataGridViewTop_JobComponentFunctions.CurrentView.CloseEditorForUpdating()
                DataGridViewVendor_Details.CurrentView.CloseEditorForUpdating()
                DataGridViewEmployeeTime_Details.CurrentView.CloseEditorForUpdating()
                DataGridViewIncomeOnly_Details.CurrentView.CloseEditorForUpdating()

            ElseIf e.CloseReason = Windows.Forms.CloseReason.UserClosing Then

                AdvantageFramework.WinForm.Presentation.Controls.SaveDataGridViewLayout(Session, DataGridViewLeftSection_Jobs, AdvantageFramework.Database.Entities.GridAdvantageType.BillingCommandCenterJobDetailJobComponent)

                AdvantageFramework.WinForm.Presentation.Controls.SaveDataGridViewLayout(Session, DataGridViewTop_JobComponentFunctions, AdvantageFramework.Database.Entities.GridAdvantageType.BillingCommandCenterJobComponentFunctionDetail)

                AdvantageFramework.WinForm.Presentation.Controls.SaveDataGridViewLayout(Session, DataGridViewEmployeeTime_Details, AdvantageFramework.Database.Entities.GridAdvantageType.BillingCommandCenterJobComponentEmployeeTimeDetail)
                AdvantageFramework.WinForm.Presentation.Controls.SaveDataGridViewLayout(Session, DataGridViewIncomeOnly_Details, AdvantageFramework.Database.Entities.GridAdvantageType.BillingCommandCenterJobComponentIncomeOnlyDetail)
                AdvantageFramework.WinForm.Presentation.Controls.SaveDataGridViewLayout(Session, DataGridViewVendor_Details, AdvantageFramework.Database.Entities.GridAdvantageType.BillingCommandCenterJobComponentVendorDetail)
                AdvantageFramework.WinForm.Presentation.Controls.SaveDataGridViewLayout(Session, DataGridViewOpenPO_Details, AdvantageFramework.Database.Entities.GridAdvantageType.BillingCommandCenterJobComponentOpenPODetail)

            End If

        End Sub
        Private Sub BillingCommandCenterJobDetailDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemActions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage

            ButtonItemStatus_Adjusted.Image = AdvantageFramework.My.Resources.CheckImage

            ButtonItemFunctionGrid_ChooseColumns.Image = AdvantageFramework.My.Resources.ColumnImage
            ButtonItemFunctionGrid_RestoreDefaults.Image = AdvantageFramework.My.Resources.RestoreDefaultsImage
            ButtonItemFunctionGrid_SelectAll.Image = AdvantageFramework.My.Resources.TableSelectedAllImage
            'ButtonItemFunctionGrid_GroupByType.Image = AdvantageFramework.My.Resources.GroupImage

            ButtonItemInclude_Contingency.Image = AdvantageFramework.My.Resources.PercentageSmallerImage

            ButtonItemEmployeeTime_MarkBillable.Image = AdvantageFramework.My.Resources.BillableImage
            ButtonItemEmployeeTime_MarkNonBillable.Image = AdvantageFramework.My.Resources.NonBillableImage
            ButtonItemEmployeeTime_FeeTime.Image = AdvantageFramework.My.Resources.MaintenanceImage
            ButtonItemEmployeeTime_FeeTime.ImageFixedSize = New System.Drawing.Size(32, 32)
            ButtonItemEmployeeTime_UpdateRate.Image = AdvantageFramework.My.Resources.CalculatorImage
            ButtonItemEmployeeTime_MarkupDown.Image = AdvantageFramework.My.Resources.BillEditImage
            ButtonItemEmployeeTime_BillHold.Image = AdvantageFramework.My.Resources.BillHoldImage
            ButtonItemEmployeeTime_Transfer.Image = AdvantageFramework.My.Resources.TransferMoneyImage
            ButtonItemEmployeeTime_HideNonBillable.Image = AdvantageFramework.My.Resources.FilterImage
            ButtonItemEmployeeTime_ChooseColumns.Image = AdvantageFramework.My.Resources.ColumnImage
            ButtonItemEmployeeTime_RestoreDefaults.Image = AdvantageFramework.My.Resources.RestoreDefaultsImage

            ButtonItemIncomeOnly_UpdateRate.Image = AdvantageFramework.My.Resources.CalculatorImage
            ButtonItemIncomeOnly_BillHold.Image = AdvantageFramework.My.Resources.BillHoldImage
            ButtonItemIncomeOnly_Transfer.Image = AdvantageFramework.My.Resources.TransferMoneyImage
            ButtonItemIncomeOnly_HideNonBillable.Image = AdvantageFramework.My.Resources.FilterImage
            ButtonItemIncomeOnly_ChooseColumns.Image = AdvantageFramework.My.Resources.ColumnImage
            ButtonItemIncomeOnly_RestoreDefaults.Image = AdvantageFramework.My.Resources.RestoreDefaultsImage

            ButtonItemVendor_MarkupDown.Image = AdvantageFramework.My.Resources.BillEditImage
            ButtonItemVendor_WriteOff.Image = AdvantageFramework.My.Resources.WriteoffImage
            ButtonItemVendor_BillHold.Image = AdvantageFramework.My.Resources.BillHoldImage
            ButtonItemVendor_Transfer.Image = AdvantageFramework.My.Resources.TransferMoneyImage
            ButtonItemVendor_HideNonBillable.Image = AdvantageFramework.My.Resources.FilterImage
            ButtonItemVendor_ChooseColumns.Image = AdvantageFramework.My.Resources.ColumnImage
            ButtonItemVendor_RestoreDefaults.Image = AdvantageFramework.My.Resources.RestoreDefaultsImage

            ButtonItemDocuments_Download.Image = AdvantageFramework.My.Resources.DownloadDocument
            ButtonItemDocuments_OpenURL.Image = AdvantageFramework.My.Resources.DocumentURL

            ButtonItemAdvanceBilling_Create.Image = AdvantageFramework.My.Resources.DetailAddImage
            ButtonItemAdvanceBilling_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemAdvanceBilling_Cancel.Image = AdvantageFramework.My.Resources.DetailCancelImage

            ButtonItemIncomeRecognition_Create.Image = AdvantageFramework.My.Resources.DetailAddImage

            ButtonItemOpenPO_ChooseColumns.Image = AdvantageFramework.My.Resources.ColumnImage
            ButtonItemOpenPO_RestoreDefaults.Image = AdvantageFramework.My.Resources.RestoreDefaultsImage

            DataGridViewTop_JobComponentFunctions.ShowSelectDeselectAllButtons = True
            DataGridViewTop_JobComponentFunctions.GridControl.UseDisabledStatePainter = False
            DataGridViewTop_JobComponentFunctions.AddFixedColumnCheckItemsToGridMenu = True
            DataGridViewTop_JobComponentFunctions.OptionsLayout.StoreDataSettings = True
            DataGridViewTop_JobComponentFunctions.OptionsLayout.StoreAppearance = True
            DataGridViewTop_JobComponentFunctions.OptionsLayout.StoreVisualOptions = True

            DataGridViewLeftSection_Jobs.ByPassUserEntryChanged = True
            DataGridViewLeftSection_Jobs.OptionsCustomization.AllowColumnMoving = True
            DataGridViewLeftSection_Jobs.OptionsLayout.StoreDataSettings = True
            DataGridViewLeftSection_Jobs.OptionsLayout.StoreAppearance = True
            DataGridViewLeftSection_Jobs.OptionsLayout.StoreVisualOptions = True

            DataGridViewEmployeeTime_Details.ShowSelectDeselectAllButtons = True
            DataGridViewEmployeeTime_Details.AddFixedColumnCheckItemsToGridMenu = True
            DataGridViewEmployeeTime_Details.OptionsCustomization.AllowColumnMoving = True
            DataGridViewEmployeeTime_Details.OptionsLayout.StoreDataSettings = True
            DataGridViewEmployeeTime_Details.OptionsLayout.StoreAppearance = True
            DataGridViewEmployeeTime_Details.OptionsLayout.StoreVisualOptions = True

            DataGridViewIncomeOnly_Details.ShowSelectDeselectAllButtons = True
            DataGridViewIncomeOnly_Details.AddFixedColumnCheckItemsToGridMenu = True
            DataGridViewIncomeOnly_Details.OptionsCustomization.AllowColumnMoving = True
            DataGridViewIncomeOnly_Details.OptionsLayout.StoreDataSettings = True
            DataGridViewIncomeOnly_Details.OptionsLayout.StoreAppearance = True
            DataGridViewIncomeOnly_Details.OptionsLayout.StoreVisualOptions = True

            DataGridViewVendor_Details.ShowSelectDeselectAllButtons = True
            DataGridViewVendor_Details.AddFixedColumnCheckItemsToGridMenu = True
            DataGridViewVendor_Details.OptionsCustomization.AllowColumnMoving = True
            DataGridViewVendor_Details.OptionsLayout.StoreDataSettings = True
            DataGridViewVendor_Details.OptionsLayout.StoreAppearance = True
            DataGridViewVendor_Details.OptionsLayout.StoreVisualOptions = True

            DataGridViewAdvanceBilling_Details.AutoFilterLookupColumns = True
            DataGridViewAdvanceBilling_Details.CurrentView.EnableDisabledRows = True

            LabelItemPctOfQuoteBilled_PCT.ForeColor = System.Drawing.Color.FromArgb(92, 125, 190)

            For Each TabItem In TabControlRightSection_FunctionItems.Tabs.OfType(Of DevComponents.DotNetBar.TabItem)()

                TabItem.Tag = False

            Next

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            NumericInputControl_PercentOfQuote.SetPropertySettings(AdvantageFramework.Database.Entities.AdvanceBilling.Properties.CalculatePercent)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                _InvoiceTaxFlag = AdvantageFramework.Database.Procedures.Agency.InvoiceTaxFlag(DbContext)

            End Using

            Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.TS_TASK_ONLY.ToString)

                If Setting IsNot Nothing Then

                    _ShowEmployeeTimeTaskCode = CBool(Setting.Value)

                End If

            End Using

            LoadBillingStatus()

            ButtonItemInclude_Contingency.Checked = If(_IncludeContingency = 1, True, False)

            If _ReconcileMode Then

                RibbonBarOptions_IncomeRecognition.Visible = False
                RibbonBarOptions_AdvanceBilling.Visible = False
                RibbonBarOptions_PercentOfQuoteBilled.Visible = False
                RibbonBarOptions_BillMethod.Visible = False
                RibbonBarOptions_IncomeMethod.Visible = False
                RibbonBarOptions_Documents.Visible = False
                RibbonBarOptions_Vendor.Visible = False
                RibbonBarOptions_IncomeOnly.Visible = False
                RibbonBarOptions_EmployeeTime.Visible = False
                RibbonBarOptions_FunctionGrid.Visible = False
                RibbonBarOptions_Include.Visible = False
                RibbonBarOptions_Status.Visible = False
                RibbonBarOptions_Actions.Visible = False

                TabItemFunctionItems_Documents.Visible = False
                TabItemFunctionItems_AdvanceBilling.Visible = False
                TabItemFunctionItems_OpenPO.Visible = False

                DataGridViewTop_JobComponentFunctions.ByPassUserEntryChanged = True
                DataGridViewTop_JobComponentFunctions.ShowSelectDeselectAllButtons = True

                DataGridViewVendor_Details.ByPassUserEntryChanged = True
                DataGridViewEmployeeTime_Details.ByPassUserEntryChanged = True
                DataGridViewIncomeOnly_Details.ByPassUserEntryChanged = True

                Me.Text = "Billing Command Center Reconcile Job Details"

            Else

                ButtonItemFunctionGrid_SelectAll.Checked = True

                RibbonBarOptions_ReconcileFunctions.Visible = False
                RibbonBarOptions_ReconcileEmployeeTime.Visible = False
                RibbonBarOptions_ReconcileIncomeOnly.Visible = False
                RibbonBarOptions_ReconcileVendor.Visible = False

            End If

        End Sub
        Private Sub BillingCommandCenterJobDetailDialog_Resize(sender As Object, e As EventArgs) Handles Me.Resize

            ResizeControlToFitParent(DataGridViewEmployeeTime_Details)
            ResizeControlToFitParent(DataGridViewIncomeOnly_Details)
            ResizeControlToFitParent(DataGridViewVendor_Details)
            ResizeControlToFitParent(DataGridViewAdvanceBilling_Details)
            ResizeControlToFitParent(DataGridViewOpenPO_Details)
            ResizeControlToFitParent(DocumentManagerControlDocuments_Documents)

        End Sub
        Private Sub BillingCommandCenterJobDetailDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            LoadGrid()

            LoadFunctions()

            If _ReconcileMode Then

                LoadEmployeeTime()
                LoadIncomeOnly()
                LoadVendorAccountPayableProduction()

            Else

                LoadFunctionItems()

            End If

            Me.FormAction = WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.ClearChanged()

            TabControlRightSection_FunctionItems.SelectedTab.Tag = False

            LoadFunctionItems()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Refresh.Click

            Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem

            LoadFunctions()

            For Each TabItem In TabControlRightSection_FunctionItems.Tabs.OfType(Of DevComponents.DotNetBar.TabItem)()

                TabItem.Tag = False

            Next

            LoadFunctionItems()

            ButtonItemFunctionGrid_SelectAll.Checked = True

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim TabItem As DevComponents.DotNetBar.TabItem = Nothing
            Dim ErrorMessage As String = ""

            If IsValidToSave(ErrorMessage) Then

                TabItem = TabControlRightSection_FunctionItems.SelectedTab

                If Save(ErrorMessage) Then

                    For Each TabItem In TabControlRightSection_FunctionItems.Tabs.OfType(Of DevComponents.DotNetBar.TabItem)()

                        TabItem.Tag = False

                    Next

                    Me.FormAction = WinForm.Presentation.FormActions.Refreshing

                    LoadFunctions()

                    LoadFunctionItems()

                    Me.FormAction = WinForm.Presentation.FormActions.None

                    Me.ClearChanged()

                    EnableOrDisableActions()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonItemAdvanceBilling_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemAdvanceBilling_Cancel.Click

            DataGridViewAdvanceBilling_Details.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemAdvanceBilling_CreateActuals_Click(sender As Object, e As EventArgs) Handles ButtonItemAdvanceBilling_CreateActuals.Click

            Dim JobComponentFunctionDetails As IEnumerable(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail) = Nothing

            JobComponentFunctionDetails = (From Entity In DataGridViewTop_JobComponentFunctions.GetAllRowsDataBoundItems().OfType(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail).ToList
                                           Where Entity.ActualBillableAmount.GetValueOrDefault(0) <> 0
                                           Select Entity).ToList

            CopyFunctionsForAdvanceBilling(JobComponentFunctionDetails, False, False, False)

        End Sub
        Private Sub ButtonItemAdvanceBilling_CreateActualsOpenPO_Click(sender As Object, e As EventArgs) Handles ButtonItemAdvanceBilling_CreateActualsOpenPO.Click

            Dim JobComponentFunctionDetails As IEnumerable(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail) = Nothing

            JobComponentFunctionDetails = (From Entity In DataGridViewTop_JobComponentFunctions.GetAllRowsDataBoundItems().OfType(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail).ToList
                                           Where Entity.ActualBillableAmount.GetValueOrDefault(0) <> 0 OrElse
                                                 Entity.OpenPOAmount.GetValueOrDefault(0) <> 0
                                           Select Entity).ToList

            CopyFunctionsForAdvanceBilling(JobComponentFunctionDetails, True, False, False)

        End Sub
        Private Sub ButtonItemAdvanceBilling_CreateAll_Click(sender As Object, e As EventArgs) Handles ButtonItemAdvanceBilling_CreateAll.Click

            Dim JobComponentFunctionDetails As IEnumerable(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail) = Nothing

            JobComponentFunctionDetails = DataGridViewTop_JobComponentFunctions.GetAllRowsDataBoundItems().OfType(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail).ToList()

            CopyFunctionsForAdvanceBilling(JobComponentFunctionDetails, False, False, True)

        End Sub
        Private Sub ButtonItemAdvanceBilling_CreateSelected_Click(sender As Object, e As EventArgs) Handles ButtonItemAdvanceBilling_CreateSelected.Click

            Dim JobComponentFunctionDetails As IEnumerable(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail) = Nothing

            JobComponentFunctionDetails = DataGridViewTop_JobComponentFunctions.GetAllSelectedRowsDataBoundItems().OfType(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail).ToList()

            CopyFunctionsForAdvanceBilling(JobComponentFunctionDetails, False, False, True)

        End Sub
        Private Sub ButtonItemAdvanceBilling_CreateApproved_Click(sender As Object, e As EventArgs) Handles ButtonItemAdvanceBilling_CreateApproved.Click

            Dim JobComponentFunctionDetails As IEnumerable(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail) = Nothing

            JobComponentFunctionDetails = DataGridViewTop_JobComponentFunctions.GetAllRowsDataBoundItems().OfType(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail).ToList()

            CopyFunctionsForAdvanceBilling(JobComponentFunctionDetails, False, True, False)

        End Sub
        Private Sub ButtonItemAdvanceBilling_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemAdvanceBilling_Delete.Click

            Dim AdvanceBillingItemDictionary As Dictionary(Of Integer, Object) = Nothing
            Dim AdvanceBillingItem As AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem = Nothing

            DataGridViewAdvanceBilling_Details.CurrentView.CloseEditorForUpdating()

            If DataGridViewAdvanceBilling_Details.HasASelectedRow Then

                AdvanceBillingItemDictionary = DataGridViewAdvanceBilling_Details.GetAllSelectedRowsRowHandlesAndDataBoundItems()

                For Each RowHandlesAndDataBoundItem In AdvanceBillingItemDictionary

                    Try

                        AdvanceBillingItem = RowHandlesAndDataBoundItem.Value

                    Catch ex As Exception
                        AdvanceBillingItem = Nothing
                    End Try

                    If AdvanceBillingItem IsNot Nothing Then

                        If AdvanceBillingItem.AdvanceBilling.SequenceNumber <> 0 OrElse AdvanceBillingItem.IncomeRecognize.SequenceNumber <> 0 Then

                            If DataGridViewAdvanceBilling_Details.CurrentView.DisabledRows.Where(Function(dr) dr.DataSourceRowIndex = DataGridViewAdvanceBilling_Details.CurrentView.GetDataSourceRowIndex(RowHandlesAndDataBoundItem.Key)).Any Then

                                DataGridViewAdvanceBilling_Details.CurrentView.EnableRow(DataGridViewAdvanceBilling_Details.CurrentView.GetDataSourceRowIndex(RowHandlesAndDataBoundItem.Key))
                                AdvanceBillingItem.IsDeleted = False

                            Else

                                DataGridViewAdvanceBilling_Details.CurrentView.DisableRow(DataGridViewAdvanceBilling_Details.CurrentView.GetDataSourceRowIndex(RowHandlesAndDataBoundItem.Key))
                                AdvanceBillingItem.IsDeleted = True

                            End If

                        ElseIf AdvanceBillingItem.WasPreviouslyBilled Then

                            AdvanceBillingItem.AmountToRecognize = Nothing

                            AdvanceBillingItem.ClearAdvanceBillingEntity()

                        Else

                            DataGridViewAdvanceBilling_Details.CurrentView.DeleteFromDataSource(RowHandlesAndDataBoundItem.Value)

                        End If

                        DataGridViewAdvanceBilling_Details.SetUserEntryChanged()

                    End If

                Next

                DataGridViewAdvanceBilling_Details.CurrentView.RefreshData()

                EnableOrDisableActions()

                DataGridViewAdvanceBilling_Details.Focus()

            End If

        End Sub
        Private Sub ButtonItemDocuments_Download_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Download.Click

            DocumentManagerControlDocuments_Documents.DownloadSelectedDocument()

        End Sub
        Private Sub ButtonItemEmployeeTime_Transfer_Click(sender As Object, e As EventArgs) Handles ButtonItemEmployeeTime_Transfer.Click

            'objects
            Dim EmployeeTimeItems As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem) = Nothing
            Dim DistinctFunctionCodes As Integer = 0

            EmployeeTimeItems = New Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem)

            For Each EmployeeTimeItem In DataGridViewEmployeeTime_Details.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem).ToList

                EmployeeTimeItems.Add(EmployeeTimeItem.ShallowCopy)

            Next

            If DataGridViewEmployeeTime_Details.HasOnlyOneSelectedRow Then

                If AdvantageFramework.Billing.Presentation.TransferItemDetailDialog.ShowFormDialog(EmployeeTimeItems.FirstOrDefault, _BillingCommandCenterID) = Windows.Forms.DialogResult.OK Then

                    LoadFunctions()

                    LoadFunctionItems()

                End If

            ElseIf DataGridViewEmployeeTime_Details.HasMultipleSelectedRows Then

                DistinctFunctionCodes = (From Entity In EmployeeTimeItems
                                         Select Entity.FunctionCode).Distinct.Count

                If AdvantageFramework.Billing.Presentation.TransferAllItemsDialog.ShowFormDialog(EmployeeTimeItems, Nothing, Nothing, DistinctFunctionCodes = 1, False, _BillingCommandCenterID) = Windows.Forms.DialogResult.OK Then

                    LoadFunctions()

                    LoadFunctionItems()

                End If

            End If

        End Sub
        Private Sub ButtonItemEmployeeTime_ChooseColumns_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemEmployeeTime_ChooseColumns.CheckedChanged

            Try

                If ButtonItemEmployeeTime_ChooseColumns.Checked Then

                    If DataGridViewEmployeeTime_Details.CurrentView.CustomizationForm Is Nothing Then

                        DataGridViewEmployeeTime_Details.CurrentView.ShowCustomization()

                    End If

                Else

                    If DataGridViewEmployeeTime_Details.CurrentView.CustomizationForm IsNot Nothing Then

                        DataGridViewEmployeeTime_Details.CurrentView.DestroyCustomization()

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ButtonItemEmployeeTime_RestoreDefaults_Click(sender As Object, e As EventArgs) Handles ButtonItemEmployeeTime_RestoreDefaults.Click

            Me.ShowWaitForm("Loading...")

            Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                AdvantageFramework.Database.Procedures.GridAdvantage.Delete(DataContext, AdvantageFramework.Database.Entities.GridAdvantageType.BillingCommandCenterJobComponentEmployeeTimeDetail, Session.UserCode)

            End Using

            DataGridViewEmployeeTime_Details.ClearDatasource()

            LoadEmployeeTime()

            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonItemEmployeeTime_HideNonBillable_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemEmployeeTime_HideNonBillable.CheckedChanged

            If Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                If ButtonItemEmployeeTime_HideNonBillable.Checked Then

                    Me.FormAction = WinForm.Presentation.FormActions.Modifying

                    ApplyEmployeeTimeBillableFilter()

                    Me.FormAction = WinForm.Presentation.FormActions.None

                Else

                    DataGridViewEmployeeTime_Details.Columns(AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.IsNonBillable.ToString).FilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo("", "")

                    DataGridViewEmployeeTime_Details.CurrentView.ExpandAllGroups()

                End If

                SaveUserSetting(AdvantageFramework.Security.UserSettings.BCCHideNonBillableFunctionsEmployeeTime.ToString, If(ButtonItemEmployeeTime_HideNonBillable.Checked, "Y", "N"))

            End If

        End Sub
        Private Sub ButtonItemEmployeeTime_MarkBillable_Click(sender As Object, e As EventArgs) Handles ButtonItemEmployeeTime_MarkBillable.Click

            ModifyBillables(True)

        End Sub
        Private Sub ButtonItemEmployeeTime_MarkNonBillable_Click(sender As Object, e As EventArgs) Handles ButtonItemEmployeeTime_MarkNonBillable.Click

            ModifyBillables(False)

        End Sub
        Private Sub ButtonItemETBillHold_Permanent_Click(sender As Object, e As EventArgs) Handles ButtonItemETBillHold_Permanent.Click

            EmployeeTimeModifyBillHoldForSelected(BillingCommandCenter.ProductionBillHoldStatus.Permanent_Job)

        End Sub
        Private Sub ButtonItemETBillHold_RemoveAll_Click(sender As Object, e As EventArgs) Handles ButtonItemETBillHold_RemoveAll.Click

            EmployeeTimeModifyBillHoldForSelected(BillingCommandCenter.ProductionBillHoldStatus.Clear)

        End Sub
        Private Sub ButtonItemETBillHold_Temporary_Click(sender As Object, e As EventArgs) Handles ButtonItemETBillHold_Temporary.Click

            EmployeeTimeModifyBillHoldForSelected(BillingCommandCenter.ProductionBillHoldStatus.Temporary_Job)

        End Sub
        Private Sub ButtonItemETMarkupDown_SetPercent_Click(sender As Object, e As EventArgs) Handles ButtonItemETMarkupDown_SetPercent.Click

            'objects
            Dim NewMarkupPercent As Decimal = Nothing

            If AdvantageFramework.WinForm.Presentation.NumericInputDialog.ShowFormDialog("Enter Markup %", "Enter new markup percentage [-999,999.999 to 999,999.999]:", 0, NewMarkupPercent, AdvantageFramework.Database.Entities.EmployeeTimeDetail.Properties.CommissionPercentage, WinForm.Presentation.Controls.NumericInput.Type.Decimal, True, -999999.999, 999999.999, "n3", 11) = Windows.Forms.DialogResult.OK Then

                EmployeeTimeUpdateMarkupRate(NewMarkupPercent)

            End If

        End Sub
        Private Sub ButtonItemETMarkupDown_ToApprovedAmountForFunction_Click(sender As Object, e As EventArgs) Handles ButtonItemETMarkupDown_ToApprovedAmountForFunction.Click

            AdjustEmployeeMarkupToAmount(AdjustToFunction.ApprovedAmount)

        End Sub
        Private Sub ButtonItemETMarkupDown_ToApprovedAmountForItem_Click(sender As Object, e As EventArgs) Handles ButtonItemETMarkupDown_ToApprovedAmountForItem.Click

            Dim JobComponentFunctionDetails As IEnumerable(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail) = Nothing
            Dim EmployeeTimeItems As IEnumerable(Of AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem) = Nothing
            Dim UserEntryChanged As Boolean = False

            DataGridViewEmployeeTime_Details.CurrentView.CloseEditorForUpdating()

            JobComponentFunctionDetails = DataGridViewTop_JobComponentFunctions.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail)().ToList()

            For Each JobComponentFunctionDetail In JobComponentFunctionDetails

                EmployeeTimeItems = DataGridViewEmployeeTime_Details.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem)().ToList.Where(Function(ETI) ETI.FunctionCode = JobComponentFunctionDetail.FunctionCode AndAlso ETI.IsNonBillable.GetValueOrDefault(0) = 0).ToList()

                For Each EmployeeTimeItem In EmployeeTimeItems

                    If EmployeeTimeItem.NetApprovedAmount.HasValue Then

                        EmployeeTimeItem.MarkupAmount = EmployeeTimeItem.NetApprovedAmount.GetValueOrDefault(0) - EmployeeTimeItem.TotalBill

                        SetEmployeeTimeMarkupAmount(EmployeeTimeItem, EmployeeTimeItem.MarkupAmount)

                        EmployeeTimeRecalculateRow(EmployeeTimeItem, True)

                        DataGridViewEmployeeTime_Details.CurrentView.AddToModifiedRows(EmployeeTimeItem)

                        UserEntryChanged = True

                    End If

                Next

            Next

            DataGridViewEmployeeTime_Details.CurrentView.RefreshData()

            If UserEntryChanged Then

                DataGridViewEmployeeTime_Details.SetUserEntryChanged()

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemETMarkupDown_ToBilledAmountForFunction_Click(sender As Object, e As EventArgs) Handles ButtonItemETMarkupDown_ToBilledAmountForFunction.Click

            AdjustEmployeeMarkupToAmount(AdjustToFunction.BilledAmount)

        End Sub
        Private Sub ButtonItemETMarkupDown_ToEstimateAmountForFunction_Click(sender As Object, e As EventArgs) Handles ButtonItemETMarkupDown_ToEstimateAmountForFunction.Click

            AdjustEmployeeMarkupToAmount(AdjustToFunction.EstimateAmount)

        End Sub
        Private Sub ButtonItemETMarkupDown_Markdown100_Click(sender As Object, e As EventArgs) Handles ButtonItemETMarkupDown_Markdown100.Click

            EmployeeTimeUpdateMarkupRate(-100)

        End Sub
        Private Sub ButtonItemETUpdateRate_FromHierarchy_Click(sender As Object, e As EventArgs) Handles ButtonItemETUpdateRate_FromHierarchy.Click

            'objects
            Dim BillingRate As AdvantageFramework.Database.Classes.BillingRate = Nothing
            Dim EmployeeTimeItem As AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem = Nothing
            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
            Dim SalesTax As AdvantageFramework.Database.Entities.SalesTax = Nothing
            Dim RateLevel As Integer = Nothing

            Me.ShowWaitForm()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewEmployeeTime_Details.CurrentView.CloseEditorForUpdating()

                For Each RowHandlesAndDataBoundItem In DataGridViewEmployeeTime_Details.GetAllSelectedRowsRowHandlesAndDataBoundItems

                    Try

                        EmployeeTimeItem = RowHandlesAndDataBoundItem.Value

                    Catch ex As Exception
                        EmployeeTimeItem = Nothing
                    End Try

                    Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, EmployeeTimeItem.JobNumber)

                    If EmployeeTimeItem IsNot Nothing AndAlso Job IsNot Nothing AndAlso EmployeeTimeItem.EmployeeTimeFlag = AdvantageFramework.Database.Classes.NonbilledEmployeeTimeComplex.EmployeeTimeFlags.Unbilled Then

                        BillingRate = AdvantageFramework.ExpenseReports.LoadBillingRate(DbContext, EmployeeTimeItem.FunctionCode, Job.ClientCode, Job.DivisionCode, Job.ProductCode, EmployeeTimeItem.JobNumber, EmployeeTimeItem.JobComponentNumber, Job.SalesClassCode, EmployeeTimeItem.EmployeeCode, EmployeeTimeItem.EmployeeDate)

                        If BillingRate IsNot Nothing Then

                            EmployeeTimeItem.BillableRate = FormatNumber(BillingRate.BILLING_RATE.GetValueOrDefault(0), 2)
                            EmployeeTimeItem.IsNonBillable = BillingRate.NOBILL_FLAG.GetValueOrDefault(0)
                            EmployeeTimeItem.FeeTimeType = BillingRate.FEE_TIME_FLAG.GetValueOrDefault(0)
                            EmployeeTimeItem.TaxCommissionOnly = BillingRate.TAX_COMM_ONLY.GetValueOrDefault(0)
                            EmployeeTimeItem.TaxCommission = BillingRate.TAX_COMM.GetValueOrDefault(0)
                            EmployeeTimeItem.CommissionPercentage = BillingRate.COMM.GetValueOrDefault(0)

                            If BillingRate.RATE_LEVEL = 9999 Then

                                EmployeeTimeItem.EmployeeRateFrom = "Approved Estimate"

                            Else

                                RateLevel = CInt(BillingRate.RATE_LEVEL.GetValueOrDefault(0))

                                EmployeeTimeItem.EmployeeRateFrom = (From Entity In AdvantageFramework.Database.Procedures.BillingRateLevel.Load(DbContext)
                                                                     Where Entity.Number = RateLevel
                                                                     Select Entity).FirstOrDefault.Description

                            End If

                            If AdvantageFramework.Database.Procedures.Agency.InvoiceTaxFlag(DbContext) Then

                                EmployeeTimeItem.SalesTaxCode = Nothing
                                EmployeeTimeItem.IsResaleTax = 0
                                EmployeeTimeItem.SalesTaxCityPercentage = 0
                                EmployeeTimeItem.SalesTaxStatePercentage = 0
                                EmployeeTimeItem.SalesTaxCountyPercentage = 0

                            Else

                                SalesTax = AdvantageFramework.Database.Procedures.SalesTax.LoadBySalesTaxCode(DbContext, BillingRate.TAX_CODE)

                                If SalesTax IsNot Nothing Then

                                    EmployeeTimeItem.SalesTaxCode = SalesTax.TaxCode
                                    EmployeeTimeItem.IsResaleTax = SalesTax.Resale.GetValueOrDefault(0)
                                    EmployeeTimeItem.SalesTaxCityPercentage = SalesTax.CityPercent.GetValueOrDefault(0)
                                    EmployeeTimeItem.SalesTaxStatePercentage = SalesTax.StatePercent.GetValueOrDefault(0)
                                    EmployeeTimeItem.SalesTaxCountyPercentage = SalesTax.CountyPercent.GetValueOrDefault(0)

                                End If

                            End If

                            EmployeeTimeRecalculateRow(EmployeeTimeItem)

                            DataGridViewEmployeeTime_Details.AddToModifiedRows(RowHandlesAndDataBoundItem.Key)

                        End If

                    End If

                Next

            End Using

            Me.CloseWaitForm()

            DataGridViewEmployeeTime_Details.CurrentView.RefreshData()

            DataGridViewEmployeeTime_Details.SetUserEntryChanged()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemETUpdateRate_SetRate_Click(sender As Object, e As EventArgs) Handles ButtonItemETUpdateRate_SetRate.Click

            'objects
            Dim NewRate As Decimal = Nothing
            Dim EmployeeTimeItem As AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem = Nothing

            If AdvantageFramework.WinForm.Presentation.NumericInputDialog.ShowFormDialog("Enter Rate", "Enter new billable rate:", 0, NewRate, AdvantageFramework.Database.Entities.EmployeeTimeDetail.Properties.BillableRate, WinForm.Presentation.Controls.NumericInput.Type.Decimal, IsRequired:=True) = Windows.Forms.DialogResult.OK Then

                DataGridViewEmployeeTime_Details.CurrentView.CloseEditorForUpdating()

                For Each RowHandlesAndDataBoundItem In DataGridViewEmployeeTime_Details.GetAllSelectedRowsRowHandlesAndDataBoundItems

                    Try

                        EmployeeTimeItem = RowHandlesAndDataBoundItem.Value

                    Catch ex As Exception
                        EmployeeTimeItem = Nothing
                    End Try

                    If EmployeeTimeItem IsNot Nothing Then

                        EmployeeTimeItem.BillableRate = NewRate

                        EmployeeTimeRecalculateRow(EmployeeTimeItem)

                        DataGridViewEmployeeTime_Details.CurrentView.RefreshRow(RowHandlesAndDataBoundItem.Key)

                        DataGridViewEmployeeTime_Details.AddToModifiedRows(RowHandlesAndDataBoundItem.Key)

                    End If

                Next

                DataGridViewEmployeeTime_Details.SetUserEntryChanged()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemFeeTime_No_Click(sender As Object, e As EventArgs) Handles ButtonItemFeeTime_No.Click

            ModifyFeeTimes(AdvantageFramework.Database.Entities.FeeTimes.No)

        End Sub
        Private Sub ButtonItemFeeTime_TimeAgainstCommissionM_Click(sender As Object, e As EventArgs) Handles ButtonItemFeeTime_TimeAgainstCommissionM.Click

            ModifyFeeTimes(AdvantageFramework.Database.Entities.FeeTimes.TimeAgainstCommissionM)

        End Sub
        Private Sub ButtonItemFeeTime_TimeAgainstCommissionP_Click(sender As Object, e As EventArgs) Handles ButtonItemFeeTime_TimeAgainstCommissionP.Click

            ModifyFeeTimes(AdvantageFramework.Database.Entities.FeeTimes.TimeAgainstCommissionP)

        End Sub
        Private Sub ButtonItemFeeTime_TimeAgainstFee_Click(sender As Object, e As EventArgs) Handles ButtonItemFeeTime_TimeAgainstFee.Click

            ModifyFeeTimes(AdvantageFramework.Database.Entities.FeeTimes.TimeAgainstFee)

        End Sub
        Private Sub ButtonItemFunctionGrid_ChooseColumns_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemFunctionGrid_ChooseColumns.CheckedChanged

            Try

                If ButtonItemFunctionGrid_ChooseColumns.Checked Then

                    If DataGridViewTop_JobComponentFunctions.CurrentView.CustomizationForm Is Nothing Then

                        DataGridViewTop_JobComponentFunctions.CurrentView.ShowCustomization()

                    End If

                Else

                    If DataGridViewTop_JobComponentFunctions.CurrentView.CustomizationForm IsNot Nothing Then

                        DataGridViewTop_JobComponentFunctions.CurrentView.DestroyCustomization()

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub
        'Private Sub ButtonItemFunctionGrid_GroupByType_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemFunctionGrid_GroupByType.CheckedChanged

        '    If Me.FormAction = WinForm.Presentation.FormActions.None AndAlso Me.FormShown Then

        '        ApplyGroupingFunction(ButtonItemFunctionGrid_GroupByType.Checked)

        '    End If

        'End Sub
        Private Sub ButtonItemFunctionGrid_RestoreDefaults_Click(sender As Object, e As EventArgs) Handles ButtonItemFunctionGrid_RestoreDefaults.Click

            Me.ShowWaitForm("Loading...")

            Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                AdvantageFramework.Database.Procedures.GridAdvantage.Delete(DataContext, AdvantageFramework.Database.Entities.GridAdvantageType.BillingCommandCenterJobComponentFunctionDetail, Session.UserCode)

            End Using

            DataGridViewTop_JobComponentFunctions.ClearDatasource()

            LoadFunctions()

            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonItemFunctionGrid_SelectAll_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemFunctionGrid_SelectAll.CheckedChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                If Me.FormShown AndAlso ButtonItemFunctionGrid_SelectAll.Checked Then

                    DataGridViewTop_JobComponentFunctions.SelectAll()

                ElseIf Me.FormShown AndAlso Not ButtonItemFunctionGrid_SelectAll.Checked Then

                    DataGridViewTop_JobComponentFunctions.DeselectAll()

                End If

            End If

        End Sub
        Private Sub ButtonItemIOBillHold_Permanent_Click(sender As Object, e As EventArgs) Handles ButtonItemIOBillHold_Permanent.Click

            IncomeOnlyModifyBillHoldForSelected(BillingCommandCenter.ProductionBillHoldStatus.Permanent_Job)

        End Sub
        Private Sub ButtonItemIOBillHold_RemoveAll_Click(sender As Object, e As EventArgs) Handles ButtonItemIOBillHold_RemoveAll.Click

            IncomeOnlyModifyBillHoldForSelected(BillingCommandCenter.ProductionBillHoldStatus.Clear)

        End Sub
        Private Sub ButtonItemIOBillHold_Temporary_Click(sender As Object, e As EventArgs) Handles ButtonItemIOBillHold_Temporary.Click

            IncomeOnlyModifyBillHoldForSelected(BillingCommandCenter.ProductionBillHoldStatus.Temporary_Job)

        End Sub
        Private Sub ButtonItemIOUpdateRate_FromHierarchy_Click(sender As Object, e As EventArgs) Handles ButtonItemIOUpdateRate_FromHierarchy.Click

            'objects
            Dim BillingRate As AdvantageFramework.Database.Classes.BillingRate = Nothing
            Dim IncomeOnlyItem As AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem = Nothing
            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
            Dim SalesTax As AdvantageFramework.Database.Entities.SalesTax = Nothing
            Dim ExtendedStateResale As Decimal = 0
            Dim ExtendedCityResale As Decimal = 0
            Dim ExtendedCountyResale As Decimal = 0

            Me.ShowWaitForm()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewIncomeOnly_Details.CurrentView.CloseEditorForUpdating()

                For Each RowHandlesAndDataBoundItem In DataGridViewIncomeOnly_Details.GetAllSelectedRowsRowHandlesAndDataBoundItems

                    Try

                        IncomeOnlyItem = RowHandlesAndDataBoundItem.Value

                    Catch ex As Exception
                        IncomeOnlyItem = Nothing
                    End Try

                    Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, IncomeOnlyItem.JobNumber)

                    If IncomeOnlyItem IsNot Nothing AndAlso Job IsNot Nothing Then

                        BillingRate = AdvantageFramework.ExpenseReports.LoadBillingRate(DbContext, IncomeOnlyItem.FunctionCode, Job.ClientCode, Job.DivisionCode, Job.ProductCode, IncomeOnlyItem.JobNumber, IncomeOnlyItem.JobComponentNumber, Job.SalesClassCode, Nothing, Nothing)

                        If BillingRate IsNot Nothing Then

                            If BillingRate.BILLING_RATE.GetValueOrDefault(0) <> 0 Then

                                IncomeOnlyItem.Rate = BillingRate.BILLING_RATE

                            End If

                            IncomeOnlyItem.IsNonBillable = CBool(BillingRate.NOBILL_FLAG.GetValueOrDefault(0))

                            If IncomeOnlyItem.Rate.HasValue Then

                                IncomeOnlyItem.Amount = Math.Round(IncomeOnlyItem.Rate.Value * IncomeOnlyItem.Quantity.Value, 2, MidpointRounding.AwayFromZero)

                            End If

                            If BillingRate.COMM.GetValueOrDefault(0) = 0 Then

                                IncomeOnlyItem.CommissionPercent = 0
                                IncomeOnlyItem.MarkupAmount = 0

                            Else

                                IncomeOnlyItem.CommissionPercent = BillingRate.COMM.GetValueOrDefault(0)
                                IncomeOnlyItem.MarkupAmount = Math.Round(IncomeOnlyItem.Amount * (IncomeOnlyItem.CommissionPercent / 100), 2, MidpointRounding.AwayFromZero)

                            End If

                            If _InvoiceTaxFlag = False Then

                                SalesTax = AdvantageFramework.Database.Procedures.SalesTax.LoadBySalesTaxCode(DbContext, BillingRate.TAX_CODE)

                                If SalesTax IsNot Nothing Then

                                    IncomeOnlyItem.SalesTaxCode = SalesTax.TaxCode
                                    IncomeOnlyItem.CityTaxPercent = SalesTax.CityPercent.GetValueOrDefault(0)
                                    IncomeOnlyItem.StateTaxPercent = SalesTax.StatePercent.GetValueOrDefault(0)
                                    IncomeOnlyItem.CountyTaxPercent = SalesTax.CountyPercent.GetValueOrDefault(0)

                                    If BillingRate.TAX_COMM_ONLY.GetValueOrDefault(0) = 1 Then

                                        ExtendedStateResale = CalculateResale(0, IncomeOnlyItem.MarkupAmount, SalesTax.StatePercent.GetValueOrDefault(0))
                                        ExtendedCityResale = CalculateResale(0, IncomeOnlyItem.MarkupAmount, SalesTax.CityPercent.GetValueOrDefault(0))
                                        ExtendedCountyResale = CalculateResale(0, IncomeOnlyItem.MarkupAmount, SalesTax.CountyPercent.GetValueOrDefault(0))
                                        IncomeOnlyItem.TaxCommissionOnly = CBool(BillingRate.TAX_COMM_ONLY.GetValueOrDefault(0))

                                    ElseIf BillingRate.TAX_COMM.GetValueOrDefault(0) = 1 Then

                                        ExtendedStateResale = CalculateResale(IncomeOnlyItem.Amount, IncomeOnlyItem.MarkupAmount, SalesTax.StatePercent.GetValueOrDefault(0))
                                        ExtendedCityResale = CalculateResale(IncomeOnlyItem.Amount, IncomeOnlyItem.MarkupAmount, SalesTax.CityPercent.GetValueOrDefault(0))
                                        ExtendedCountyResale = CalculateResale(IncomeOnlyItem.Amount, IncomeOnlyItem.MarkupAmount, SalesTax.CountyPercent.GetValueOrDefault(0))
                                        IncomeOnlyItem.TaxCommission = CBool(BillingRate.TAX_COMM.GetValueOrDefault(0))

                                    Else

                                        ExtendedStateResale = CalculateResale(IncomeOnlyItem.Amount, 0, SalesTax.StatePercent.GetValueOrDefault(0))
                                        ExtendedCityResale = CalculateResale(IncomeOnlyItem.Amount, 0, SalesTax.CityPercent.GetValueOrDefault(0))
                                        ExtendedCountyResale = CalculateResale(IncomeOnlyItem.Amount, 0, SalesTax.CountyPercent.GetValueOrDefault(0))

                                    End If

                                Else

                                    IncomeOnlyItem.SalesTaxCode = Nothing
                                    IncomeOnlyItem.CityTaxPercent = 0
                                    IncomeOnlyItem.StateTaxPercent = 0
                                    IncomeOnlyItem.CountyTaxPercent = 0

                                End If

                            Else

                                IncomeOnlyItem.SalesTaxCode = Nothing
                                IncomeOnlyItem.CityTaxPercent = 0
                                IncomeOnlyItem.StateTaxPercent = 0
                                IncomeOnlyItem.CountyTaxPercent = 0

                            End If

                            IncomeOnlyItem.StateResaleTaxAmount = ExtendedStateResale
                            IncomeOnlyItem.CityResaleTaxAmount = ExtendedCityResale
                            IncomeOnlyItem.CountyResaleTaxAmount = ExtendedCountyResale

                            DataGridViewIncomeOnly_Details.AddToModifiedRows(RowHandlesAndDataBoundItem.Key)

                        End If

                    End If

                Next

            End Using

            Me.CloseWaitForm()

            DataGridViewIncomeOnly_Details.CurrentView.RefreshData()
            DataGridViewIncomeOnly_Details.CurrentView.UpdateTotalSummary()
            DataGridViewIncomeOnly_Details.SetUserEntryChanged()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemIOUpdateRate_SetRate_Click(sender As Object, e As EventArgs) Handles ButtonItemIOUpdateRate_SetRate.Click

            'objects
            Dim NewRate As Decimal = Nothing
            Dim IncomeOnlyItem As AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem = Nothing

            If AdvantageFramework.WinForm.Presentation.NumericInputDialog.ShowFormDialog("Enter Rate", "Enter new billable rate:", 0, NewRate, Nothing, WinForm.Presentation.Controls.NumericInput.Type.Decimal, IsRequired:=True, DisplayFormat:="n3", MaxLength:=13, MaxValue:=999999999.999, MinValue:=0) = Windows.Forms.DialogResult.OK Then

                DataGridViewIncomeOnly_Details.CurrentView.CloseEditorForUpdating()

                For Each RowHandlesAndDataBoundItem In DataGridViewIncomeOnly_Details.GetAllSelectedRowsRowHandlesAndDataBoundItems

                    Try

                        IncomeOnlyItem = RowHandlesAndDataBoundItem.Value

                    Catch ex As Exception
                        IncomeOnlyItem = Nothing
                    End Try

                    If IncomeOnlyItem IsNot Nothing Then

                        IncomeOnlyItem.Rate = NewRate

                        IncomeOnlyRecalculateRow(IncomeOnlyItem)

                        DataGridViewIncomeOnly_Details.CurrentView.RefreshRow(RowHandlesAndDataBoundItem.Key)

                        DataGridViewIncomeOnly_Details.AddToModifiedRows(RowHandlesAndDataBoundItem.Key)

                    End If

                Next

                DataGridViewIncomeOnly_Details.SetUserEntryChanged()
                DataGridViewIncomeOnly_Details.CurrentView.UpdateTotalSummary()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemOpenPO_ChooseColumns_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemOpenPO_ChooseColumns.CheckedChanged

            Try

                If ButtonItemOpenPO_ChooseColumns.Checked Then

                    If DataGridViewOpenPO_Details.CurrentView.CustomizationForm Is Nothing Then

                        DataGridViewOpenPO_Details.CurrentView.ShowCustomization()

                    End If

                Else

                    If DataGridViewOpenPO_Details.CurrentView.CustomizationForm IsNot Nothing Then

                        DataGridViewOpenPO_Details.CurrentView.DestroyCustomization()

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ButtonItemOpenPO_RestoreDefaults_Click(sender As Object, e As EventArgs) Handles ButtonItemOpenPO_RestoreDefaults.Click

            Me.ShowWaitForm("Loading...")

            Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                AdvantageFramework.Database.Procedures.GridAdvantage.Delete(DataContext, AdvantageFramework.Database.Entities.GridAdvantageType.BillingCommandCenterJobComponentOpenPODetail, Session.UserCode)

            End Using

            DataGridViewOpenPO_Details.ClearDatasource()

            LoadOpenPO()

            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonItemReconcileEmployeeTime_CheckSelected_Click(sender As Object, e As EventArgs) Handles ButtonItemReconcileEmployeeTime_CheckSelected.Click

            For Each RowHandlesAndDataBoundItem In DataGridViewEmployeeTime_Details.GetAllSelectedRowsRowHandlesAndDataBoundItems()

                DataGridViewEmployeeTime_Details.CurrentView.SetRowCellValue(RowHandlesAndDataBoundItem.Key, AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.Reconcile.ToString, True)

                CheckUncheckFunctionsBasedOnEmployeeTimeChecked(RowHandlesAndDataBoundItem.Key, True)

            Next

        End Sub
        Private Sub ButtonItemReconcileEmployeeTime_UncheckSelected_Click(sender As Object, e As EventArgs) Handles ButtonItemReconcileEmployeeTime_UncheckSelected.Click

            For Each RowHandlesAndDataBoundItem In DataGridViewEmployeeTime_Details.GetAllSelectedRowsRowHandlesAndDataBoundItems()

                DataGridViewEmployeeTime_Details.CurrentView.SetRowCellValue(RowHandlesAndDataBoundItem.Key, AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.Reconcile.ToString, False)

                CheckUncheckFunctionsBasedOnEmployeeTimeChecked(RowHandlesAndDataBoundItem.Key, False)

            Next

        End Sub
        Private Sub ButtonItemReconcileFunctions_CheckSelected_Click(sender As Object, e As EventArgs) Handles ButtonItemReconcileFunctions_CheckSelected.Click

            For Each RowHandlesAndDataBoundItem In DataGridViewTop_JobComponentFunctions.GetAllSelectedRowsRowHandlesAndDataBoundItems()

                DataGridViewTop_JobComponentFunctions.CurrentView.SetRowCellValue(RowHandlesAndDataBoundItem.Key, AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.Reconcile.ToString, True)

                CheckUncheckFunctionItemsForReconcile(RowHandlesAndDataBoundItem.Key, True)

            Next

        End Sub
        Private Sub ButtonItemReconcileFunctions_UncheckSelected_Click(sender As Object, e As EventArgs) Handles ButtonItemReconcileFunctions_UncheckSelected.Click

            For Each RowHandlesAndDataBoundItem In DataGridViewTop_JobComponentFunctions.GetAllSelectedRowsRowHandlesAndDataBoundItems()

                DataGridViewTop_JobComponentFunctions.CurrentView.SetRowCellValue(RowHandlesAndDataBoundItem.Key, AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.Reconcile.ToString, False)

                CheckUncheckFunctionItemsForReconcile(RowHandlesAndDataBoundItem.Key, False)

            Next

        End Sub
        Private Sub ButtonItemReconcileIncomeOnly_CheckSelected_Click(sender As Object, e As EventArgs) Handles ButtonItemReconcileIncomeOnly_CheckSelected.Click

            For Each RowHandlesAndDataBoundItem In DataGridViewIncomeOnly_Details.GetAllSelectedRowsRowHandlesAndDataBoundItems()

                DataGridViewIncomeOnly_Details.CurrentView.SetRowCellValue(RowHandlesAndDataBoundItem.Key, AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.Reconcile.ToString, True)

                CheckUncheckFunctionsBasedOnIncomeOnlyChecked(RowHandlesAndDataBoundItem.Key, True)

            Next

        End Sub
        Private Sub ButtonItemReconcileIncomeOnly_UncheckSelected_Click(sender As Object, e As EventArgs) Handles ButtonItemReconcileIncomeOnly_UncheckSelected.Click

            For Each RowHandlesAndDataBoundItem In DataGridViewIncomeOnly_Details.GetAllSelectedRowsRowHandlesAndDataBoundItems()

                DataGridViewIncomeOnly_Details.CurrentView.SetRowCellValue(RowHandlesAndDataBoundItem.Key, AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.Reconcile.ToString, False)

                CheckUncheckFunctionsBasedOnIncomeOnlyChecked(RowHandlesAndDataBoundItem.Key, False)

            Next

        End Sub
        Private Sub ButtonItemReconcileVendor_CheckSelected_Click(sender As Object, e As EventArgs) Handles ButtonItemReconcileVendor_CheckSelected.Click

            For Each RowHandlesAndDataBoundItem In DataGridViewVendor_Details.GetAllSelectedRowsRowHandlesAndDataBoundItems()

                DataGridViewVendor_Details.CurrentView.SetRowCellValue(RowHandlesAndDataBoundItem.Key, AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.Reconcile.ToString, True)

                CheckUncheckFunctionsBasedOnVendorChecked(RowHandlesAndDataBoundItem.Key, True)

            Next

        End Sub
        Private Sub ButtonItemReconcileVendor_UncheckSelected_Click(sender As Object, e As EventArgs) Handles ButtonItemReconcileVendor_UncheckSelected.Click

            For Each RowHandlesAndDataBoundItem In DataGridViewVendor_Details.GetAllSelectedRowsRowHandlesAndDataBoundItems()

                DataGridViewVendor_Details.CurrentView.SetRowCellValue(RowHandlesAndDataBoundItem.Key, AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.Reconcile.ToString, False)

                CheckUncheckFunctionsBasedOnVendorChecked(RowHandlesAndDataBoundItem.Key, False)

            Next

        End Sub
        Private Sub ButtonItemInclude_Contingency_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemInclude_Contingency.CheckedChanged

            RefreshFunctions()

        End Sub
        Private Sub ButtonItemIncomeMethod_InitialBilling_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemIncomeMethod_InitialBilling.CheckedChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None AndAlso ButtonItemIncomeMethod_InitialBilling.Checked Then

                DataGridViewAdvanceBilling_Details.CancelNewItemRow()

                DataGridViewAdvanceBilling_Details.SetUserEntryChanged()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemIncomeMethod_InitialBilling_OptionGroupChanging(sender As Object, e As DevComponents.DotNetBar.OptionGroupChangingEventArgs) Handles ButtonItemIncomeMethod_InitialBilling.OptionGroupChanging

            If Me.FormAction = WinForm.Presentation.FormActions.None AndAlso RibbonBarOptions_IncomeMethod.Tag = False Then

                e.Cancel = True

            Else

                DataGridViewAdvanceBilling_Details.CurrentView.CloseEditorForUpdating()

                If (DataGridViewAdvanceBilling_Details.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem)().Where(Function(ABI) ABI.WasPreviouslyBilled = True).Any OrElse
                        DataGridViewAdvanceBilling_Details.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem)().Where(Function(ABI) ABI.AmountToRecognize IsNot Nothing).Any) AndAlso
                        Me.FormAction = WinForm.Presentation.FormActions.None Then

                    e.Cancel = True

                End If

            End If

        End Sub
        Private Sub ButtonItemIncomeMethod_UponReconciliation_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemIncomeMethod_UponReconciliation.CheckedChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None AndAlso ButtonItemIncomeMethod_UponReconciliation.Checked Then

                DataGridViewAdvanceBilling_Details.SetUserEntryChanged()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemIncomeMethod_UponReconciliation_OptionGroupChanging(sender As Object, e As DevComponents.DotNetBar.OptionGroupChangingEventArgs) Handles ButtonItemIncomeMethod_UponReconciliation.OptionGroupChanging

            If Me.FormAction = WinForm.Presentation.FormActions.None AndAlso RibbonBarOptions_IncomeMethod.Tag = False Then

                e.Cancel = True

            Else

                If DataGridViewAdvanceBilling_Details.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem)().Where(Function(ABI) ABI.WasPreviouslyBilled = True).Any AndAlso
                        Me.FormAction = WinForm.Presentation.FormActions.None Then

                    e.Cancel = True

                End If

            End If

        End Sub
        Private Sub ButtonItemIncomeOnly_ChooseColumns_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemIncomeOnly_ChooseColumns.CheckedChanged

            Try

                If ButtonItemIncomeOnly_ChooseColumns.Checked Then

                    If DataGridViewIncomeOnly_Details.CurrentView.CustomizationForm Is Nothing Then

                        DataGridViewIncomeOnly_Details.CurrentView.ShowCustomization()

                    End If

                Else

                    If DataGridViewIncomeOnly_Details.CurrentView.CustomizationForm IsNot Nothing Then

                        DataGridViewIncomeOnly_Details.CurrentView.DestroyCustomization()

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ButtonItemIncomeOnly_HideNonBillable_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemIncomeOnly_HideNonBillable.CheckedChanged

            If Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                If ButtonItemIncomeOnly_HideNonBillable.Checked Then

                    Me.FormAction = WinForm.Presentation.FormActions.Modifying

                    ApplyIncomeOnlyBillableFilter()

                    Me.FormAction = WinForm.Presentation.FormActions.None

                Else

                    DataGridViewIncomeOnly_Details.Columns(AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.IsNonBillable.ToString).FilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo("", "")

                    DataGridViewIncomeOnly_Details.CurrentView.ExpandAllGroups()

                End If

                SaveUserSetting(AdvantageFramework.Security.UserSettings.BCCHideNonBillableFunctionsIncomeOnly.ToString, If(ButtonItemIncomeOnly_HideNonBillable.Checked, "Y", "N"))

            End If

        End Sub
        Private Sub ButtonItemIncomeOnly_RestoreDefaults_Click(sender As Object, e As EventArgs) Handles ButtonItemIncomeOnly_RestoreDefaults.Click

            Me.ShowWaitForm("Loading...")

            Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                AdvantageFramework.Database.Procedures.GridAdvantage.Delete(DataContext, AdvantageFramework.Database.Entities.GridAdvantageType.BillingCommandCenterJobComponentIncomeOnlyDetail, Session.UserCode)

            End Using

            DataGridViewIncomeOnly_Details.ClearDatasource()

            LoadIncomeOnly()

            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonItemIncomeOnly_Transfer_Click(sender As Object, e As EventArgs) Handles ButtonItemIncomeOnly_Transfer.Click

            'objects
            Dim IncomeOnlyItems As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem) = Nothing
            Dim DistinctFunctionCodes As Integer = 0

            IncomeOnlyItems = New Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem)

            For Each IncomeOnlyItem In DataGridViewIncomeOnly_Details.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem).ToList

                IncomeOnlyItems.Add(IncomeOnlyItem.ShallowCopy)

            Next

            If DataGridViewIncomeOnly_Details.HasOnlyOneSelectedRow Then

                If AdvantageFramework.Billing.Presentation.TransferItemDetailDialog.ShowFormDialog(IncomeOnlyItems.FirstOrDefault, _BillingCommandCenterID) = Windows.Forms.DialogResult.OK Then

                    RefreshAndKeepIncomeOnlyTabFocused()

                End If

            ElseIf DataGridViewIncomeOnly_Details.HasMultipleSelectedRows Then

                DistinctFunctionCodes = (From Entity In IncomeOnlyItems
                                         Select Entity.FunctionCode).Distinct.Count

                If AdvantageFramework.Billing.Presentation.TransferAllItemsDialog.ShowFormDialog(Nothing, Nothing, IncomeOnlyItems, DistinctFunctionCodes = 1, False, _BillingCommandCenterID) = Windows.Forms.DialogResult.OK Then

                    RefreshAndKeepIncomeOnlyTabFocused()

                End If

            End If

        End Sub
        Private Sub ButtonItemPercentCompleteAll_ByJob_Click(sender As Object, e As EventArgs) Handles ButtonItemPercentCompleteAll_ByJob.Click

            AddIncomeRecByPercentCompleteByJob(False)

        End Sub
        Private Sub ButtonItemPercentCompleteAll_ByJobFunction_Click(sender As Object, e As EventArgs) Handles ButtonItemPercentCompleteAll_ByJobFunction.Click

            AddIncomeRecByPercentCompleteByJobFunction(False)

        End Sub
        Private Sub ButtonItemPercentCompleteTime_ByJob_Click(sender As Object, e As EventArgs) Handles ButtonItemPercentCompleteTime_ByJob.Click

            AddIncomeRecByPercentCompleteByJob(True)

        End Sub
        Private Sub ButtonItemPercentCompleteTime_ByJobFunction_Click(sender As Object, e As EventArgs) Handles ButtonItemPercentCompleteTime_ByJobFunction.Click

            AddIncomeRecByPercentCompleteByJobFunction(True)

        End Sub
        Private Sub ButtonItemStatus_Adjusted_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemStatus_Adjusted.CheckedChanged

            SetAdjusted(ButtonItemStatus_Adjusted.Checked)

        End Sub
        Private Sub ButtonItemVendor_ChooseColumns_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemVendor_ChooseColumns.CheckedChanged

            Try

                If ButtonItemVendor_ChooseColumns.Checked Then

                    If DataGridViewVendor_Details.CurrentView.CustomizationForm Is Nothing Then

                        DataGridViewVendor_Details.CurrentView.ShowCustomization()

                    End If

                Else

                    If DataGridViewVendor_Details.CurrentView.CustomizationForm IsNot Nothing Then

                        DataGridViewVendor_Details.CurrentView.DestroyCustomization()

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ButtonItemVendor_HideNonBillable_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemVendor_HideNonBillable.CheckedChanged

            If Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                If ButtonItemVendor_HideNonBillable.Checked Then

                    Me.FormAction = WinForm.Presentation.FormActions.Modifying

                    ApplyVendorAPBillableFilter()

                    Me.FormAction = WinForm.Presentation.FormActions.None

                Else

                    DataGridViewVendor_Details.Columns(AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.IsNonBillable.ToString).FilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo("", "")

                    DataGridViewVendor_Details.CurrentView.ExpandAllGroups()

                End If

                SaveUserSetting(AdvantageFramework.Security.UserSettings.BCCHideNonBillableFunctionsVendor.ToString, If(ButtonItemVendor_HideNonBillable.Checked, "Y", "N"))

            End If

        End Sub
        Private Sub ButtonItemVendor_RestoreDefaults_Click(sender As Object, e As EventArgs) Handles ButtonItemVendor_RestoreDefaults.Click

            Me.ShowWaitForm("Loading...")

            Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                AdvantageFramework.Database.Procedures.GridAdvantage.Delete(DataContext, AdvantageFramework.Database.Entities.GridAdvantageType.BillingCommandCenterJobComponentVendorDetail, Session.UserCode)

            End Using

            DataGridViewVendor_Details.ClearDatasource()

            LoadVendorAccountPayableProduction()

            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonItemVendor_Transfer_Click(sender As Object, e As EventArgs) Handles ButtonItemVendor_Transfer.Click

            'objects
            Dim AccountPayableProductionItems As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem) = Nothing
            Dim DistinctFunctionCodes As Integer = 0

            AccountPayableProductionItems = New Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem)

            For Each AccountPayableProductionItem In DataGridViewVendor_Details.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem).Where(Function(AP) AP.IsBilledReversal = False).ToList

                AccountPayableProductionItems.Add(AccountPayableProductionItem.ShallowCopy)

            Next

            If AccountPayableProductionItems.Count = 0 Then

                AdvantageFramework.WinForm.MessageBox.Show("Nothing to transfer - cannot transfer reversals.")

            ElseIf AccountPayableProductionItems.Count = 1 Then

                If AdvantageFramework.Billing.Presentation.TransferItemDetailDialog.ShowFormDialog(AccountPayableProductionItems.FirstOrDefault, _BillingCommandCenterID) = Windows.Forms.DialogResult.OK Then

                    RefreshAndKeepVendorTabFocused()

                End If

            Else

                DistinctFunctionCodes = (From Entity In AccountPayableProductionItems
                                         Select Entity.FunctionCode).Distinct.Count

                If AdvantageFramework.Billing.Presentation.TransferAllItemsDialog.ShowFormDialog(Nothing, AccountPayableProductionItems, Nothing, DistinctFunctionCodes = 1, False, _BillingCommandCenterID) = Windows.Forms.DialogResult.OK Then

                    RefreshAndKeepVendorTabFocused()

                End If

            End If

        End Sub
        Private Sub ButtonItemVendor_WriteOff_Click(sender As Object, e As EventArgs) Handles ButtonItemVendor_WriteOff.Click

            Dim IDLineNumbers As IEnumerable(Of String) = Nothing
            Dim AccountPayableWriteoffs As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.AccountPayableWriteoff) = Nothing
            Dim AccountPayableProductions As Generic.List(Of AdvantageFramework.Database.Entities.AccountPayableProduction) = Nothing
            Dim AccountPayableProduction As AdvantageFramework.Database.Entities.AccountPayableProduction = Nothing
            Dim IDLineNumber() As String = Nothing
            Dim ID As Integer = 0
            Dim LineNumber As Short = 0

            Me.ShowWaitForm()

            IDLineNumbers = (From Entity In DataGridViewVendor_Details.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem).ToList
                             Where Entity.IsNonBillable.GetValueOrDefault(0) = 0 AndAlso
                                   Entity.IsBilledReversal = False
                             Select Entity.AccountPayableID & "|" & Entity.LineNumber).ToArray

            AccountPayableWriteoffs = New Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.AccountPayableWriteoff)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                For Each IDLine In IDLineNumbers

                    IDLineNumber = IDLine.Split("|")

                    ID = CInt(IDLineNumber(0))
                    LineNumber = CShort(IDLineNumber(1))

                    AccountPayableProduction = (From Entity In AdvantageFramework.Database.Procedures.AccountPayableProduction.Load(DbContext).Include("Job")
                                                Where Entity.AccountPayableID = ID AndAlso
                                                      Entity.LineNumber = LineNumber
                                                Select Entity).FirstOrDefault

                    If AccountPayableProduction IsNot Nothing Then

                        AccountPayableWriteoffs.Add(New AdvantageFramework.BillingCommandCenter.Classes.AccountPayableWriteoff(DbContext, AccountPayableProduction, Session))

                    End If

                Next

            End Using

            Me.CloseWaitForm()

            If AdvantageFramework.Billing.Presentation.BillingCommandCenterProductionVendorWriteoff.ShowFormDialog(AccountPayableWriteoffs) = Windows.Forms.DialogResult.OK Then

                RefreshAndKeepVendorTabFocused()

            End If

        End Sub
        Private Sub ButtonItemVendorBillHold_Permanent_Click(sender As Object, e As EventArgs) Handles ButtonItemVendorBillHold_Permanent.Click

            VendorAPModifyBillHoldForSelected(BillingCommandCenter.ProductionBillHoldStatus.Permanent_Job)

        End Sub
        Private Sub ButtonItemVendorBillHold_RemoveAll_Click(sender As Object, e As EventArgs) Handles ButtonItemVendorBillHold_RemoveAll.Click

            VendorAPModifyBillHoldForSelected(BillingCommandCenter.ProductionBillHoldStatus.Clear)

        End Sub
        Private Sub ButtonItemVendorBillHold_Temporary_Click(sender As Object, e As EventArgs) Handles ButtonItemVendorBillHold_Temporary.Click

            VendorAPModifyBillHoldForSelected(BillingCommandCenter.ProductionBillHoldStatus.Temporary_Job)

        End Sub
        Private Sub ButtonItemVendorMarkupDown_SetPercent_Click(sender As Object, e As EventArgs) Handles ButtonItemVendorMarkupDown_SetPercent.Click

            'objects
            Dim NewMarkupPercent As Decimal = Nothing

            If AdvantageFramework.WinForm.Presentation.NumericInputDialog.ShowFormDialog("Enter Markup %", "Enter new markup percentage [-999999.999 to 999999.999]:", 0, NewMarkupPercent, AdvantageFramework.Database.Entities.AccountPayableProduction.Properties.CommissionPercent, WinForm.Presentation.Controls.NumericInput.Type.Decimal, True, -999999.999, 999999.999) = Windows.Forms.DialogResult.OK Then

                VendorAPUpdateMarkupRate(NewMarkupPercent)

            End If

        End Sub
        Private Sub ButtonItemVendorMarkupDown_Markdown100_Click(sender As Object, e As EventArgs) Handles ButtonItemVendorMarkupDown_Markdown100.Click

            VendorAPUpdateMarkupRate(-100)

        End Sub
        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            _IsClosing = True
            Me.Close()

        End Sub
        Private Sub CheckBoxItemBillMethod_ExcludeNonBillableFunctions_CheckedChanged(sender As Object, e As DevComponents.DotNetBar.CheckBoxChangeEventArgs) Handles CheckBoxItemBillMethod_ExcludeNonBillableFunctions.CheckedChanged

            If Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                SaveUserSetting(AdvantageFramework.Security.UserSettings.BCCExcludeNonBillableFunctionsAdvanceBilling.ToString, If(e.NewChecked.Checked, "Y", "N"))

            End If

        End Sub
        Private Sub DataGridViewAdvanceBilling_Details_AddNewRowEvent(RowObject As Object) Handles DataGridViewAdvanceBilling_Details.AddNewRowEvent

            DataGridViewAdvanceBilling_Details.SetUserEntryChanged()

        End Sub
        Private Sub DataGridViewAdvanceBilling_Details_BeforeAddNewRowEvent(RowObject As Object, ByRef Cancel As Boolean) Handles DataGridViewAdvanceBilling_Details.BeforeAddNewRowEvent

            Dim AdvanceBillingItemList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem) = Nothing
            Dim FunctionCode As String = Nothing

            FunctionCode = DirectCast(RowObject, AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem).FunctionCode

            AdvanceBillingItemList = DataGridViewAdvanceBilling_Details.GetAllRowsDataBoundItems().OfType(Of AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem).ToList()

            If (FunctionCode IsNot Nothing AndAlso AdvanceBillingItemList.Where(Function(ABI) ABI.FunctionCode = FunctionCode).Any) OrElse
                    (FunctionCode Is Nothing AndAlso AdvanceBillingItemList.Where(Function(ABI) ABI.FunctionCode Is Nothing).Any) Then

                AdvantageFramework.WinForm.MessageBox.Show("Function exists.")
                Cancel = True

            End If

        End Sub
        Private Sub DataGridViewAdvanceBilling_Details_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewAdvanceBilling_Details.CellValueChangedEvent

            Dim AdvanceBillingItem As AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem = Nothing
            Dim SalesTax As AdvantageFramework.Database.Entities.SalesTax = Nothing

            If TypeOf DataGridViewAdvanceBilling_Details.CurrentView.GetRow(e.RowHandle) Is AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem Then

                AdvanceBillingItem = DataGridViewAdvanceBilling_Details.CurrentView.GetRow(e.RowHandle)

                If e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem.Properties.QuantityHours.ToString Then

                    AdvanceBillingItem.QuantityHours = If(e.Value = 0, Nothing, e.Value)

                    If AdvanceBillingItem.QuantityHours Is Nothing Then

                        AdvanceBillingItem.Rate = Nothing

                    ElseIf AdvanceBillingItem.Rate Is Nothing Then

                        Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                            AdvanceBillingItem.SetBillingRate(DbContext)

                        End Using

                    End If

                    AdvantageFramework.BillingCommandCenter.CalculateQuantityRateAndAmount(BillingSystem.QtyRateAmount.Quantity, AdvanceBillingItem)

                    AdvanceBillingItem.CalculateAdvanceBilling(Me.Session, True)

                ElseIf e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem.Properties.Rate.ToString Then

                    AdvanceBillingItem.Rate = If(e.Value = 0, Nothing, e.Value)

                    If AdvanceBillingItem.Rate Is Nothing Then

                        AdvanceBillingItem.QuantityHours = Nothing

                    End If

                    AdvantageFramework.BillingCommandCenter.CalculateQuantityRateAndAmount(BillingSystem.QtyRateAmount.Rate, AdvanceBillingItem)

                    AdvanceBillingItem.CalculateAdvanceBilling(Me.Session, True)

                ElseIf e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem.Properties.NetAmount.ToString Then

                    AdvanceBillingItem.NetAmount = e.Value

                    AdvantageFramework.BillingCommandCenter.CalculateQuantityRateAndAmount(BillingSystem.QtyRateAmount.Amount, AdvanceBillingItem)

                    AdvanceBillingItem.CalculateAdvanceBilling(Me.Session, True)

                ElseIf e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem.Properties.MarkupPercent.ToString Then

                    AdvanceBillingItem.MarkupPercent = e.Value

                    AdvanceBillingItem.CalculateAdvanceBilling(Me.Session, True)

                ElseIf e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem.Properties.ExtendedMarkupAmount.ToString Then

                    AdvanceBillingItem.ExtendedMarkupAmount = e.Value

                    AdvanceBillingItem.CalculateAdvanceBilling(Me.Session, True, True)

                ElseIf e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem.Properties.SalesTaxCode.ToString Then

                    If e.Value IsNot Nothing And e.Value <> "" Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                            SalesTax = AdvantageFramework.Database.Procedures.SalesTax.LoadBySalesTaxCode(DbContext, e.Value)

                        End Using

                        If SalesTax IsNot Nothing Then

                            AdvanceBillingItem.SalesTaxCode = e.Value
                            AdvanceBillingItem.AdvanceBilling.IsResaleTax = SalesTax.Resale.GetValueOrDefault(0)

                            AdvanceBillingItem.AdvanceBilling.CityTaxPercent = SalesTax.CityPercent.GetValueOrDefault(0)
                            AdvanceBillingItem.AdvanceBilling.CountyTaxPercent = SalesTax.CountyPercent.GetValueOrDefault(0)
                            AdvanceBillingItem.AdvanceBilling.StateTaxPercent = SalesTax.StatePercent.GetValueOrDefault(0)

                        End If

                    Else

                        AdvanceBillingItem.SalesTaxCode = Nothing
                        AdvanceBillingItem.AdvanceBilling.IsResaleTax = Nothing

                        AdvanceBillingItem.AdvanceBilling.CityTaxPercent = Nothing
                        AdvanceBillingItem.AdvanceBilling.CountyTaxPercent = Nothing
                        AdvanceBillingItem.AdvanceBilling.StateTaxPercent = Nothing

                    End If

                    AdvanceBillingItem.CalculateAdvanceBilling(Me.Session, True)

                ElseIf e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem.Properties.ExtendedNonResaleTax.ToString Then

                    AdvanceBillingItem.ExtendedNonResaleTax = e.Value

                    AdvanceBillingItem.CalculateAdvanceBilling(Me.Session, False)

                ElseIf e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem.Properties.FunctionCode.ToString Then

                    If String.IsNullOrWhiteSpace(e.Value) Then

                        AdvanceBillingItem.ClearAdvanceBillingEntity()

                        AdvanceBillingItem.FunctionDescription = Nothing
                        AdvanceBillingItem.FunctionType = Nothing

                        AdvanceBillingItem.SetRequiredFields()

                    Else

                        Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                            AdvanceBillingItem.SetAdvanceBillingFunctionCode(DbContext, e.Value)

                            AdvanceBillingItem.SetBillingRate(DbContext)

                        End Using

                        AdvanceBillingItem.CalculateAdvanceBilling(Me.Session, True)

                    End If

                End If

                NumericInputControl_PercentOfQuote.EditValue = Nothing

                DataGridViewAdvanceBilling_Details.CurrentView.UpdateTotalSummary()
                DataGridViewAdvanceBilling_Details.CurrentView.BestFitColumns()

                EnableOrDisableActions()

            End If

        End Sub
        'Private Sub DataGridViewAdvanceBilling_Details_CustomDrawRowIndicatorEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles DataGridViewAdvanceBilling_Details.CustomDrawRowIndicatorEvent

        '    Dim AdvanceBillingItem As AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem = Nothing

        '    AdvanceBillingItem = DirectCast(DataGridViewAdvanceBilling_Details.CurrentView.GetRow(e.RowHandle), AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem)

        '    If AdvanceBillingItem IsNot Nothing AndAlso AdvanceBillingItem.MultipleUnbilledRecordsExist Then

        '        e.Info.ImageIndex = -1
        '        e.Info.DisplayText = "!"

        '        e.Handled = True

        '    End If

        'End Sub
        'Private Sub DataGridViewAdvanceBilling_Details_CustomDrawCellEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles DataGridViewAdvanceBilling_Details.CustomDrawCellEvent

        '    If e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem.Properties.FunctionCode.ToString Then

        '        If DirectCast(DataGridViewAdvanceBilling_Details.CurrentView.GetRow(e.RowHandle), AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem).IsNonBillable Then

        '            e.Appearance.Font.Italic = True

        '        End If

        '    End If

        'End Sub
        Private Sub DataGridViewAdvanceBilling_Details_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewAdvanceBilling_Details.DataSourceChangedEvent

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl = Nothing

            If Not Me.IsFormClosing Then

                DataGridViewAdvanceBilling_Details.CurrentView.OptionsView.ShowFooter = True

                DataGridViewAdvanceBilling_Details.CurrentView.OptionsView.EnableAppearanceOddRow = True
                DataGridViewAdvanceBilling_Details.CurrentView.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)

                For Each GridColumn In DataGridViewAdvanceBilling_Details.Columns

                    If GridColumn.ColumnType Is GetType(System.Decimal) OrElse
                            GridColumn.ColumnType Is GetType(System.Nullable(Of Decimal)) Then

                        If GridColumn.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem.Properties.Rate.ToString AndAlso
                                GridColumn.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem.Properties.MarkupPercent.ToString Then

                            SetColumnAsSumColumn(DataGridViewAdvanceBilling_Details, GridColumn.FieldName)

                        End If

                    End If

                Next

                If _InvoiceTaxFlag AndAlso
                           DataGridViewAdvanceBilling_Details.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem.Properties.ResaleTax.ToString) IsNot Nothing Then

                    DataGridViewAdvanceBilling_Details.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem.Properties.ResaleTax.ToString).Visible = False

                End If

                If DataGridViewAdvanceBilling_Details.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem.Properties.FunctionCode.ToString) IsNot Nothing Then

                    SubItemGridLookUpEditControl = DirectCast(DataGridViewAdvanceBilling_Details.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem.Properties.FunctionCode.ToString).ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl)

                    If SubItemGridLookUpEditControl IsNot Nothing Then

                        Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            SubItemGridLookUpEditControl.DataSource = AdvantageFramework.Database.Procedures.Function.LoadForSubItemGridLookupEditAllActiveBillableTypes(DbContext)

                        End Using

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewAdvanceBilling_Details_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewAdvanceBilling_Details.InitNewRowEvent

            Dim AdvanceBillingItem As AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem = Nothing

            If TypeOf DataGridViewAdvanceBilling_Details.CurrentView.GetRow(e.RowHandle) Is AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem Then

                AdvanceBillingItem = DataGridViewAdvanceBilling_Details.CurrentView.GetRow(e.RowHandle)

                AdvanceBillingItem.InitializeAdvanceBilling(Session.UserCode,
                                                            DirectCast(DataGridViewLeftSection_Jobs.CurrentView.GetRow(DataGridViewLeftSection_Jobs.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.JobDetailJobComponent).JobNumber,
                                                            DirectCast(DataGridViewLeftSection_Jobs.CurrentView.GetRow(DataGridViewLeftSection_Jobs.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.JobDetailJobComponent).JobComponentNumber)

                AdvanceBillingItem.InitializeIncomeRecognize(Session.UserCode,
                                                             DirectCast(DataGridViewLeftSection_Jobs.CurrentView.GetRow(DataGridViewLeftSection_Jobs.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.JobDetailJobComponent).JobNumber,
                                                             DirectCast(DataGridViewLeftSection_Jobs.CurrentView.GetRow(DataGridViewLeftSection_Jobs.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.JobDetailJobComponent).JobComponentNumber)

            End If

        End Sub
        Private Sub DataGridViewAdvanceBilling_Details_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewAdvanceBilling_Details.QueryPopupNeedDatasourceEvent

            Dim AdvanceBillingItem As AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem = Nothing

            AdvanceBillingItem = DirectCast(DataGridViewAdvanceBilling_Details.CurrentView.GetRow(DataGridViewAdvanceBilling_Details.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem)

            If FieldName = AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem.Properties.SalesTaxCode.ToString Then

                OverrideDefaultDatasource = True

                If AdvanceBillingItem Is Nothing OrElse String.IsNullOrWhiteSpace(AdvanceBillingItem.FunctionType) Then

                    Datasource = Nothing

                Else

                    Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        If _InvoiceTaxFlag Then

                            Datasource = AdvantageFramework.Database.Procedures.SalesTax.LoadAllActive(DbContext).Where(Function(ST) ST.Resale Is Nothing OrElse ST.Resale = 0).ToList

                        Else

                            Datasource = AdvantageFramework.Database.Procedures.SalesTax.LoadAllActive(DbContext).ToList

                        End If

                    End Using

                End If

            End If

        End Sub
        Private Sub DataGridViewAdvanceBilling_Details_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewAdvanceBilling_Details.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewAdvanceBilling_Details_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewAdvanceBilling_Details.ShowingEditorEvent

            Dim AdvanceBillingItem As AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem = Nothing

            AdvanceBillingItem = DirectCast(DataGridViewAdvanceBilling_Details.CurrentView.GetRow(DataGridViewAdvanceBilling_Details.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem)

            If DataGridViewAdvanceBilling_Details.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem).Where(Function(AB) AB.AdvanceBilling.FinalAdvanceBillingID IsNot Nothing).Any Then

                e.Cancel = True

            ElseIf DataGridViewAdvanceBilling_Details.CurrentView.FocusedColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem.Properties.ExtendedNonResaleTax.ToString Then

                If AdvanceBillingItem IsNot Nothing AndAlso AdvanceBillingItem.FunctionType <> "V" Then

                    e.Cancel = True

                ElseIf AdvanceBillingItem Is Nothing Then

                    e.Cancel = True

                End If

            ElseIf DataGridViewAdvanceBilling_Details.CurrentView.FocusedColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem.Properties.SalesTaxCode.ToString Then

                If AdvanceBillingItem IsNot Nothing AndAlso AdvanceBillingItem.FunctionType <> "V" AndAlso _InvoiceTaxFlag Then

                    e.Cancel = True

                ElseIf AdvanceBillingItem Is Nothing Then

                    e.Cancel = True

                End If

            ElseIf DataGridViewAdvanceBilling_Details.CurrentView.FocusedColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem.Properties.PriorBilled.ToString Then

                e.Cancel = True

            ElseIf DataGridViewAdvanceBilling_Details.CurrentView.FocusedColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem.Properties.AmountToRecognize.ToString Then

                If ButtonItemIncomeMethod_InitialBilling.Checked Then

                    e.Cancel = True

                End If

            End If

        End Sub
        Private Sub DataGridViewAdvanceBilling_Details_ShownEditorEvent(sender As Object, e As EventArgs) Handles DataGridViewAdvanceBilling_Details.ShownEditorEvent

            Dim GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = Nothing

            If TypeOf DataGridViewAdvanceBilling_Details.CurrentView.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

                If DataGridViewAdvanceBilling_Details.CurrentView.FocusedColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem.Properties.FunctionCode.ToString Then

                    GridLookUpEdit = DataGridViewAdvanceBilling_Details.CurrentView.ActiveEditor

                    If GridLookUpEdit.Properties.View.Columns("Type") IsNot Nothing Then

                        GridLookUpEdit.Properties.View.Columns("Type").Visible = True
                        GridLookUpEdit.Properties.View.Columns("Type").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewAdvanceBilling_Details_ValidatingEditorEvent(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DataGridViewAdvanceBilling_Details.ValidatingEditorEvent

            Dim AdvanceBillingItemList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem) = Nothing

            AdvanceBillingItemList = DataGridViewAdvanceBilling_Details.GetAllRowsDataBoundItems().OfType(Of AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem).ToList()

            If DataGridViewAdvanceBilling_Details.IsNewItemRow(DataGridViewAdvanceBilling_Details.CurrentView.FocusedRowHandle) AndAlso DataGridViewAdvanceBilling_Details.CurrentView.FocusedColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem.Properties.FunctionCode.ToString Then

                If (String.IsNullOrWhiteSpace(e.Value) AndAlso AdvanceBillingItemList.Where(Function(ABI) ABI.FunctionCode Is Nothing).Any) OrElse
                        (Not String.IsNullOrWhiteSpace(e.Value) AndAlso AdvanceBillingItemList.Where(Function(ABI) ABI.FunctionCode = e.Value).Any) Then

                    AdvantageFramework.WinForm.MessageBox.Show("Function exists.")
                    e.Valid = False

                End If

            End If

        End Sub
        Private Sub DataGridViewEmployeeTime_Details_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewEmployeeTime_Details.CellValueChangedEvent

            'objects
            Dim EmployeeTimeItem As AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem = Nothing
            Dim SalesTax As AdvantageFramework.Database.Entities.SalesTax = Nothing
            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
            Dim BillingRate As AdvantageFramework.Database.Classes.BillingRate = Nothing
            Dim TaxableAmount As Decimal = 0

            Try

                EmployeeTimeItem = DirectCast(DataGridViewEmployeeTime_Details.CurrentView.GetRow(e.RowHandle), AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem)

            Catch ex As Exception
                EmployeeTimeItem = Nothing
            End Try

            If EmployeeTimeItem IsNot Nothing Then

                If e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.MarkupAmount.ToString Then

                    SetEmployeeTimeMarkupAmount(EmployeeTimeItem, e.Value)

                ElseIf e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.CommissionPercentage.ToString Then

                    EmployeeTimeItem.MarkupPercentChanged = True

                ElseIf e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.StateResaleAmount.ToString Then

                    EmployeeTimeItem.TaxAmountChanged = True

                    If e.Value = 0 Then

                        EmployeeTimeItem.SalesTaxStatePercentage = 0

                    Else

                        If EmployeeTimeItem.TaxCommissionOnly Then

                            TaxableAmount = EmployeeTimeItem.MarkupAmount

                        ElseIf EmployeeTimeItem.TaxCommission Then

                            TaxableAmount = EmployeeTimeItem.MarkupAmount + EmployeeTimeItem.TotalBill

                        Else

                            TaxableAmount = EmployeeTimeItem.TotalBill

                        End If

                        EmployeeTimeItem.SalesTaxStatePercentage = FormatNumber((e.Value / TaxableAmount) * 100, 3)

                        If EmployeeTimeItem.SalesTaxStatePercentage > 999999.999 Then

                            EmployeeTimeItem.SalesTaxStatePercentage = 999999.999

                        End If

                    End If

                ElseIf e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.CountyResaleAmount.ToString Then

                    EmployeeTimeItem.TaxAmountChanged = True

                    If e.Value = 0 Then

                        EmployeeTimeItem.SalesTaxCountyPercentage = 0

                    Else

                        If EmployeeTimeItem.TaxCommissionOnly Then

                            TaxableAmount = EmployeeTimeItem.MarkupAmount

                        ElseIf EmployeeTimeItem.TaxCommission Then

                            TaxableAmount = EmployeeTimeItem.MarkupAmount + EmployeeTimeItem.TotalBill

                        Else

                            TaxableAmount = EmployeeTimeItem.TotalBill

                        End If

                        EmployeeTimeItem.SalesTaxCountyPercentage = FormatNumber((e.Value / TaxableAmount) * 100, 3)

                        If EmployeeTimeItem.SalesTaxCountyPercentage > 9999.9999 Then

                            EmployeeTimeItem.SalesTaxCountyPercentage = 9999.9999

                        End If

                    End If

                ElseIf e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.CityResaleAmount.ToString Then

                    EmployeeTimeItem.TaxAmountChanged = True

                    If e.Value = 0 Then

                        EmployeeTimeItem.SalesTaxCityPercentage = 0

                    Else

                        If EmployeeTimeItem.TaxCommissionOnly Then

                            TaxableAmount = EmployeeTimeItem.MarkupAmount

                        ElseIf EmployeeTimeItem.TaxCommission Then

                            TaxableAmount = EmployeeTimeItem.MarkupAmount + EmployeeTimeItem.TotalBill

                        Else

                            TaxableAmount = EmployeeTimeItem.TotalBill

                        End If

                        EmployeeTimeItem.SalesTaxCityPercentage = FormatNumber((e.Value / TaxableAmount) * 100, 3)

                        If EmployeeTimeItem.SalesTaxCityPercentage > 9999.9999 Then

                            EmployeeTimeItem.SalesTaxCityPercentage = 9999.9999

                        End If

                    End If

                ElseIf e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.SalesTaxCode.ToString Then

                    EmployeeTimeItem.TaxCodeChanged = True

                    If e.Value Is Nothing Then

                        EmployeeTimeItem.IsResaleTax = Nothing
                        EmployeeTimeItem.TaxCommission = False
                        EmployeeTimeItem.TaxCommissionOnly = False
                        EmployeeTimeItem.SalesTaxStatePercentage = 0
                        EmployeeTimeItem.SalesTaxCountyPercentage = 0
                        EmployeeTimeItem.SalesTaxCityPercentage = 0
                        EmployeeTimeItem.StateResaleAmount = 0
                        EmployeeTimeItem.CountyResaleAmount = 0
                        EmployeeTimeItem.CityResaleAmount = 0

                    Else

                        Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                            SalesTax = AdvantageFramework.Database.Procedures.SalesTax.LoadBySalesTaxCode(DbContext, e.Value)

                            If SalesTax IsNot Nothing Then

                                Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, EmployeeTimeItem.JobNumber)

                                If Job IsNot Nothing Then

                                    BillingRate = AdvantageFramework.ExpenseReports.LoadBillingRate(DbContext, EmployeeTimeItem.FunctionCode, Job.ClientCode,
                                                                                                    Job.DivisionCode, Job.ProductCode, EmployeeTimeItem.JobNumber,
                                                                                                    EmployeeTimeItem.JobComponentNumber, Job.SalesClassCode, EmployeeTimeItem.EmployeeCode, Nothing)

                                    If BillingRate IsNot Nothing Then

                                        EmployeeTimeItem.TaxCommission = BillingRate.TAX_COMM.GetValueOrDefault(0)
                                        EmployeeTimeItem.TaxCommissionOnly = BillingRate.TAX_COMM_ONLY.GetValueOrDefault(0)

                                    End If

                                End If

                                EmployeeTimeItem.IsResaleTax = SalesTax.Resale.GetValueOrDefault(0)
                                EmployeeTimeItem.SalesTaxStatePercentage = SalesTax.StatePercent.GetValueOrDefault(0)
                                EmployeeTimeItem.SalesTaxCountyPercentage = SalesTax.CountyPercent.GetValueOrDefault(0)
                                EmployeeTimeItem.SalesTaxCityPercentage = SalesTax.CityPercent.GetValueOrDefault(0)

                            End If

                        End Using

                    End If

                ElseIf e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.IsNonBillable.ToString Then

                    If ModifyBillable(EmployeeTimeItem, CBool(e.Value)) Then

                        DataGridViewEmployeeTime_Details.AddToModifiedRows(e.RowHandle)

                        DataGridViewEmployeeTime_Details.CurrentView.RefreshData()

                        DataGridViewEmployeeTime_Details.SetUserEntryChanged()

                    End If

                ElseIf e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.FeeTimeType.ToString Then

                    If ModifyFeeTime(EmployeeTimeItem, CShort(e.Value)) Then

                        DataGridViewEmployeeTime_Details.AddToModifiedRows(e.RowHandle)

                        DataGridViewEmployeeTime_Details.CurrentView.RefreshData()

                        DataGridViewEmployeeTime_Details.SetUserEntryChanged()

                    End If

                    If e.Value Is Nothing OrElse e.Value = 0 Then

                        EmployeeTimeItem.FeeTimeType = 0

                        EmployeeTimeItem.ValidateEntityProperty(AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.FeeTimeType.ToString, True, 0)

                        DataGridViewEmployeeTime_Details.CurrentView.RefreshRow(e.RowHandle)

                    End If

                End If

                If e.Column.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.IsNonBillable.ToString AndAlso
                        e.Column.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.FeeTimeType.ToString AndAlso
                        e.Column.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.ResaleTax.ToString AndAlso
                        e.Column.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.TaxCommission.ToString AndAlso
                        e.Column.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.TaxCommissionOnly.ToString AndAlso
                        e.Column.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.Comment.ToString AndAlso
                        e.Column.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.CityResaleAmount.ToString AndAlso
                        e.Column.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.CountyResaleAmount.ToString AndAlso
                        e.Column.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.StateResaleAmount.ToString AndAlso
                        e.Column.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.Reconcile.ToString Then

                    If e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.MarkupAmount.ToString Then

                        EmployeeTimeRecalculateRow(EmployeeTimeItem, True)

                    Else

                        EmployeeTimeRecalculateRow(EmployeeTimeItem)

                    End If

                    DataGridViewEmployeeTime_Details.CurrentView.RefreshRow(e.RowHandle)

                End If

                DataGridViewEmployeeTime_Details.CurrentView.UpdateTotalSummary()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub DataGridViewEmployeeTime_Details_CellValueChangingEvent(ByRef Saved As Boolean, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewEmployeeTime_Details.CellValueChangingEvent

            If e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.IsNonBillable.ToString Then

                If e.Value = 1 Then

                    DirectCast(DataGridViewEmployeeTime_Details.CurrentView.GetRow(e.RowHandle), AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem).IsBillOnHold = Nothing

                End If

                DataGridViewEmployeeTime_Details.CurrentView.RefreshRow(e.RowHandle)
                DataGridViewEmployeeTime_Details.SetUserEntryChanged()

                EnableOrDisableActions()

            ElseIf _ReconcileMode AndAlso e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.Reconcile.ToString Then

                CheckUncheckFunctionsBasedOnEmployeeTimeChecked(e.RowHandle, e.Value)

            End If

        End Sub
        'Private Sub DataGridViewEmployeeTime_Details_ColumnFilterChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewEmployeeTime_Details.ColumnFilterChangedEvent

        '    If Me.FormAction = WinForm.Presentation.FormActions.None AndAlso sender.GetType Is GetType(AdvantageFramework.WinForm.Presentation.Controls.GridView) Then

        '        If DirectCast(sender, AdvantageFramework.WinForm.Presentation.Controls.GridView).AFActiveFilterString.Contains("IsNonBillable") = False Then

        '            ButtonItemEmployeeTime_HideNonBillable.Checked = False

        '        End If

        '    End If

        'End Sub
        Private Sub DataGridViewEmployeeTime_Details_ColumnValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs, ViaCellValueChangedEvent As Boolean) Handles DataGridViewEmployeeTime_Details.ColumnValueChangedEvent

            If e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.IsBillOnHold.ToString Then

                DataGridViewEmployeeTime_Details.CurrentView.CloseEditor()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub DataGridViewEmployeeTime_Details_CustomDrawGroupRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs) Handles DataGridViewEmployeeTime_Details.CustomDrawGroupRowEvent

            Dim GridView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            Dim GridGroupRowInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo = Nothing
            Dim EmployeeTimeItem As AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem = Nothing

            GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            GridGroupRowInfo = TryCast(e.Info, DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo)

            If GridView IsNot Nothing AndAlso GridGroupRowInfo IsNot Nothing Then

                If GridGroupRowInfo.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.FunctionDescription.ToString Then

                    EmployeeTimeItem = DataGridViewEmployeeTime_Details.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem)().Where(Function(Entity) Entity.FunctionCode = GridGroupRowInfo.EditValue).FirstOrDefault

                    If EmployeeTimeItem IsNot Nothing Then

                        GridGroupRowInfo.GroupText = EmployeeTimeItem.FunctionDescription

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewEmployeeTime_Details_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewEmployeeTime_Details.DataSourceChangedEvent

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim GridColumnSummaryItem As DevExpress.XtraGrid.GridColumnSummaryItem = Nothing

            If Not Me.IsFormClosing Then

                DataGridViewEmployeeTime_Details.CurrentView.OptionsView.ShowFooter = True

                DataGridViewEmployeeTime_Details.CurrentView.OptionsView.EnableAppearanceOddRow = True
                DataGridViewEmployeeTime_Details.CurrentView.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)

                For Each GridColumn In DataGridViewEmployeeTime_Details.Columns

                    If GridColumn.ColumnType Is GetType(System.Decimal) OrElse
                            GridColumn.ColumnType Is GetType(System.Nullable(Of Decimal)) Then

                        If GridColumn.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.BillableRate.ToString AndAlso
                                GridColumn.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.CommissionPercentage.ToString AndAlso
                                GridColumn.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.SalesTaxCityPercentage.ToString AndAlso
                                GridColumn.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.SalesTaxCountyPercentage.ToString AndAlso
                                GridColumn.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.SalesTaxStatePercentage.ToString Then

                            SetColumnAsSumColumn(DataGridViewEmployeeTime_Details, GridColumn.FieldName)

                            If Not DataGridViewEmployeeTime_Details.Columns(GridColumn.FieldName).Summary.Where(Function(S) S.SummaryType = DevExpress.Data.SummaryItemType.Custom).Any Then

                                GridColumnSummaryItem = DataGridViewEmployeeTime_Details.Columns(GridColumn.FieldName).Summary.Add(DevExpress.Data.SummaryItemType.Custom)
                                GridColumnSummaryItem.DisplayFormat = "{0:n2}"

                            End If

                        End If

                    End If

                Next

            End If

        End Sub
        Private Sub DataGridViewEmployeeTime_Details_HideCustomizationFormEvent(sender As Object, e As EventArgs) Handles DataGridViewEmployeeTime_Details.HideCustomizationFormEvent

            If ButtonItemEmployeeTime_ChooseColumns.Checked Then

                ButtonItemEmployeeTime_ChooseColumns.Checked = False

            End If

        End Sub
        Private Sub DataGridViewEmployeeTime_Details_PopupMenuShowingEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles DataGridViewEmployeeTime_Details.PopupMenuShowingEvent

            AdvantageFramework.Billing.Presentation.HideGroupByMenuOptions(e)

        End Sub
        Private Sub DataGridViewEmployeeTime_Details_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewEmployeeTime_Details.QueryPopupNeedDatasourceEvent

            If FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.SalesTaxCode.ToString Then

                OverrideDefaultDatasource = True

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Datasource = AdvantageFramework.Database.Procedures.SalesTax.LoadAllActive(DbContext).ToList

                End Using

            ElseIf FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.IsBillOnHold.ToString Then

                OverrideDefaultDatasource = True

                If DirectCast(DataGridViewEmployeeTime_Details.CurrentView.GetRow(DataGridViewEmployeeTime_Details.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem).ABFlag.GetValueOrDefault(0) = 0 AndAlso
                         DirectCast(DataGridViewEmployeeTime_Details.CurrentView.GetRow(DataGridViewEmployeeTime_Details.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem).IsNonBillable.GetValueOrDefault(0) = 0 Then

                    Datasource = From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.BillingCommandCenter.ProductionBillHoldStatus))
                                 Select Entity.Code,
                                        [Description] = Entity.Description

                Else

                    Datasource = From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.BillingCommandCenter.ProductionBillHoldStatus))
                                 Where Entity.Code = AdvantageFramework.BillingCommandCenter.ProductionBillHoldStatus.Clear
                                 Select Entity.Code,
                                        [Description] = Entity.Description

                End If

            End If

        End Sub
        Private Sub DataGridViewEmployeeTime_Details_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewEmployeeTime_Details.SelectionChangedEvent

            EnableOrDisableActions()

            If DataGridViewEmployeeTime_Details.CurrentView.RowCount <> 0 Then

                DataGridViewEmployeeTime_Details.CurrentView.UpdateTotalSummary()

            End If

        End Sub
        Private Sub DataGridViewEmployeeTime_Details_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewEmployeeTime_Details.ShowingEditorEvent

            'objects
            Dim EmployeeTimeItem As AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem = Nothing

            If _ReconcileMode Then

                If SelectedJobComponentReconcileStatusCheckable() = False OrElse DataGridViewEmployeeTime_Details.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.Reconcile.ToString Then

                    e.Cancel = True

                End If

            ElseIf DirectCast(DataGridViewLeftSection_Jobs.CurrentView.GetRow(DataGridViewLeftSection_Jobs.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.JobDetailJobComponent).BillingUser IsNot Nothing Then

                If DataGridViewEmployeeTime_Details.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.Comment.ToString Then

                    e.Cancel = True

                End If

            Else

                EmployeeTimeItem = DirectCast(DataGridViewEmployeeTime_Details.CurrentView.GetRow(DataGridViewEmployeeTime_Details.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem)

                If (DataGridViewEmployeeTime_Details.CurrentView.FocusedColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.CityResaleAmount.ToString OrElse
                        DataGridViewEmployeeTime_Details.CurrentView.FocusedColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.CountyResaleAmount.ToString OrElse
                        DataGridViewEmployeeTime_Details.CurrentView.FocusedColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.StateResaleAmount.ToString) AndAlso
                        EmployeeTimeItem.SalesTaxCode Is Nothing Then

                    e.Cancel = True

                ElseIf DataGridViewEmployeeTime_Details.CurrentView.FocusedColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.SalesTaxCode.ToString Then

                    If _InvoiceTaxFlag = True Then

                        e.Cancel = True

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewIncomeOnly_Details_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewIncomeOnly_Details.CellValueChangedEvent

            'objects
            Dim IncomeOnlyItem As AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem = Nothing
            Dim SalesTax As AdvantageFramework.Database.Entities.SalesTax = Nothing
            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
            Dim BillingRate As AdvantageFramework.Database.Classes.BillingRate = Nothing
            Dim TaxableAmount As Decimal = 0

            Try

                IncomeOnlyItem = DirectCast(DataGridViewIncomeOnly_Details.CurrentView.GetRow(e.RowHandle), AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem)

            Catch ex As Exception
                IncomeOnlyItem = Nothing
            End Try

            If IncomeOnlyItem IsNot Nothing Then

                If e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.MarkupAmount.ToString Then

                    IncomeOnlyItem.MarkupAmountChanged = True

                    If e.Value = 0 Then

                        IncomeOnlyItem.CommissionPercent = 0

                    ElseIf IncomeOnlyItem.Amount <> 0 Then

                        IncomeOnlyItem.CommissionPercent = FormatNumber((e.Value / IncomeOnlyItem.Amount) * 100, 3)

                        If IncomeOnlyItem.CommissionPercent > 999999.999 Then

                            IncomeOnlyItem.CommissionPercent = 999999.999

                        ElseIf IncomeOnlyItem.CommissionPercent < -999999.999 Then

                            IncomeOnlyItem.CommissionPercent = -999999.999

                        End If

                    End If

                ElseIf e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.CommissionPercent.ToString Then

                    IncomeOnlyItem.MarkupPercentChanged = True

                ElseIf e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.StateResaleTaxAmount.ToString Then

                    IncomeOnlyItem.TaxAmountChanged = True

                    If e.Value = 0 Then

                        IncomeOnlyItem.StateTaxPercent = 0

                    Else

                        If IncomeOnlyItem.TaxCommissionOnly Then

                            TaxableAmount = IncomeOnlyItem.MarkupAmount

                        ElseIf IncomeOnlyItem.TaxCommission Then

                            TaxableAmount = IncomeOnlyItem.MarkupAmount + IncomeOnlyItem.Amount

                        Else

                            TaxableAmount = IncomeOnlyItem.Amount

                        End If

                        IncomeOnlyItem.StateTaxPercent = FormatNumber((e.Value / TaxableAmount) * 100, 3)

                        If IncomeOnlyItem.StateTaxPercent > 9999.9999 Then

                            IncomeOnlyItem.StateTaxPercent = 9999.9999

                        End If

                    End If

                ElseIf e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.CountyResaleTaxAmount.ToString Then

                    IncomeOnlyItem.TaxAmountChanged = True

                    If e.Value = 0 Then

                        IncomeOnlyItem.CountyTaxPercent = 0

                    Else

                        If IncomeOnlyItem.TaxCommissionOnly Then

                            TaxableAmount = IncomeOnlyItem.MarkupAmount

                        ElseIf IncomeOnlyItem.TaxCommission Then

                            TaxableAmount = IncomeOnlyItem.MarkupAmount + IncomeOnlyItem.Amount

                        Else

                            TaxableAmount = IncomeOnlyItem.Amount

                        End If

                        IncomeOnlyItem.CountyTaxPercent = FormatNumber((e.Value / TaxableAmount) * 100, 3)

                        If IncomeOnlyItem.CountyTaxPercent > 9999.9999 Then

                            IncomeOnlyItem.CountyTaxPercent = 9999.9999

                        End If

                    End If

                ElseIf e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.CityResaleTaxAmount.ToString Then

                    IncomeOnlyItem.TaxAmountChanged = True

                    If e.Value = 0 Then

                        IncomeOnlyItem.CityTaxPercent = 0

                    Else

                        If IncomeOnlyItem.TaxCommissionOnly Then

                            TaxableAmount = IncomeOnlyItem.MarkupAmount

                        ElseIf IncomeOnlyItem.TaxCommission Then

                            TaxableAmount = IncomeOnlyItem.MarkupAmount + IncomeOnlyItem.Amount

                        Else

                            TaxableAmount = IncomeOnlyItem.Amount

                        End If

                        IncomeOnlyItem.CityTaxPercent = FormatNumber((e.Value / TaxableAmount) * 100, 3)

                        If IncomeOnlyItem.CityTaxPercent > 9999.9999 Then

                            IncomeOnlyItem.CityTaxPercent = 9999.9999

                        End If

                    End If

                ElseIf e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.SalesTaxCode.ToString Then

                    IncomeOnlyItem.TaxCodeChanged = True

                    If e.Value Is Nothing Then

                        IncomeOnlyItem.IsResaleTax = Nothing
                        IncomeOnlyItem.TaxCommission = False
                        IncomeOnlyItem.TaxCommissionOnly = False
                        IncomeOnlyItem.StateTaxPercent = 0
                        IncomeOnlyItem.CountyTaxPercent = 0
                        IncomeOnlyItem.CityTaxPercent = 0
                        IncomeOnlyItem.StateResaleTaxAmount = 0
                        IncomeOnlyItem.CountyResaleTaxAmount = 0
                        IncomeOnlyItem.CityResaleTaxAmount = 0

                    Else

                        Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                            SalesTax = AdvantageFramework.Database.Procedures.SalesTax.LoadBySalesTaxCode(DbContext, e.Value)

                            If SalesTax IsNot Nothing Then

                                Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, IncomeOnlyItem.JobNumber)

                                If Job IsNot Nothing Then

                                    BillingRate = AdvantageFramework.ExpenseReports.LoadBillingRate(DbContext, IncomeOnlyItem.FunctionCode, Job.ClientCode,
                                                                                                    Job.DivisionCode, Job.ProductCode, IncomeOnlyItem.JobNumber,
                                                                                                    IncomeOnlyItem.JobComponentNumber, Job.SalesClassCode, Nothing, Nothing)

                                    If BillingRate IsNot Nothing Then

                                        IncomeOnlyItem.TaxCommission = CBool(BillingRate.TAX_COMM.GetValueOrDefault(0))
                                        IncomeOnlyItem.TaxCommissionOnly = CBool(BillingRate.TAX_COMM_ONLY.GetValueOrDefault(0))

                                    End If

                                End If

                                IncomeOnlyItem.IsResaleTax = SalesTax.Resale.GetValueOrDefault(0)
                                IncomeOnlyItem.StateTaxPercent = SalesTax.StatePercent.GetValueOrDefault(0)
                                IncomeOnlyItem.CountyTaxPercent = SalesTax.CountyPercent.GetValueOrDefault(0)
                                IncomeOnlyItem.CityTaxPercent = SalesTax.CityPercent.GetValueOrDefault(0)

                            End If

                        End Using

                    End If

                End If

                If e.Column.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.Quantity.ToString AndAlso
                        e.Column.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.LineTotal.ToString AndAlso
                        e.Column.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.StateTaxPercent.ToString AndAlso
                        e.Column.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.CountyTaxPercent.ToString AndAlso
                        e.Column.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.CityTaxPercent.ToString AndAlso
                        e.Column.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.TaxCommission.ToString AndAlso
                        e.Column.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.TaxCommissionOnly.ToString AndAlso
                        e.Column.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.Comment.ToString AndAlso
                        e.Column.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.CityResaleTaxAmount.ToString AndAlso
                        e.Column.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.CountyResaleTaxAmount.ToString AndAlso
                        e.Column.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.StateResaleTaxAmount.ToString AndAlso
                        e.Column.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.Reconcile.ToString Then

                    If e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.MarkupAmount.ToString Then

                        IncomeOnlyRecalculateRow(IncomeOnlyItem, True)

                    Else

                        IncomeOnlyRecalculateRow(IncomeOnlyItem)

                    End If

                    DataGridViewIncomeOnly_Details.CurrentView.RefreshRow(e.RowHandle)

                End If

                DataGridViewIncomeOnly_Details.CurrentView.UpdateTotalSummary()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub DataGridViewIncomeOnly_Details_CellValueChangingEvent(ByRef Saved As Boolean, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewIncomeOnly_Details.CellValueChangingEvent

            If e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.IsNonBillable.ToString Then

                If e.Value = True Then

                    DirectCast(DataGridViewIncomeOnly_Details.CurrentView.GetRow(e.RowHandle), AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem).IsBillOnHold = Nothing

                End If

                DataGridViewIncomeOnly_Details.CurrentView.RefreshRow(e.RowHandle)
                DataGridViewIncomeOnly_Details.SetUserEntryChanged()

                EnableOrDisableActions()

            ElseIf _ReconcileMode AndAlso e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.Reconcile.ToString Then

                CheckUncheckFunctionsBasedOnIncomeOnlyChecked(e.RowHandle, e.Value)

            End If

        End Sub
        'Private Sub DataGridViewIncomeOnly_Details_ColumnFilterChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewIncomeOnly_Details.ColumnFilterChangedEvent

        '    If Me.FormAction = WinForm.Presentation.FormActions.None AndAlso sender.GetType Is GetType(AdvantageFramework.WinForm.Presentation.Controls.GridView) Then

        '        If DirectCast(sender, AdvantageFramework.WinForm.Presentation.Controls.GridView).AFActiveFilterString.Contains("IsNonBillable") = False Then

        '            ButtonItemIncomeOnly_HideNonBillable.Checked = False

        '        End If

        '    End If

        'End Sub
        Private Sub DataGridViewIncomeOnly_Details_ColumnValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs, ViaCellValueChangedEvent As Boolean) Handles DataGridViewIncomeOnly_Details.ColumnValueChangedEvent

            If e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.IsBillOnHold.ToString Then

                DataGridViewIncomeOnly_Details.CurrentView.CloseEditor()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub DataGridViewIncomeOnly_Details_CustomDrawGroupRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs) Handles DataGridViewIncomeOnly_Details.CustomDrawGroupRowEvent

            Dim GridView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            Dim GridGroupRowInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo = Nothing
            Dim IncomeOnlyItem As AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem = Nothing

            GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            GridGroupRowInfo = TryCast(e.Info, DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo)

            If GridView IsNot Nothing AndAlso GridGroupRowInfo IsNot Nothing Then

                If GridGroupRowInfo.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.FunctionDescription.ToString Then

                    IncomeOnlyItem = DataGridViewIncomeOnly_Details.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem)().Where(Function(Entity) Entity.FunctionCode = GridGroupRowInfo.EditValue).FirstOrDefault

                    If IncomeOnlyItem IsNot Nothing Then

                        GridGroupRowInfo.GroupText = IncomeOnlyItem.FunctionDescription

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewIncomeOnly_Details_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewIncomeOnly_Details.DataSourceChangedEvent

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim GridColumnSummaryItem As DevExpress.XtraGrid.GridColumnSummaryItem = Nothing

            If Not Me.IsFormClosing Then

                DataGridViewIncomeOnly_Details.CurrentView.OptionsView.ShowFooter = True

                DataGridViewIncomeOnly_Details.CurrentView.OptionsView.EnableAppearanceOddRow = True
                DataGridViewIncomeOnly_Details.CurrentView.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)

                For Each GridColumn In DataGridViewIncomeOnly_Details.Columns

                    If GridColumn.ColumnType Is GetType(System.Decimal) OrElse
                            GridColumn.ColumnType Is GetType(System.Nullable(Of Decimal)) Then

                        If GridColumn.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.Rate.ToString AndAlso
                                GridColumn.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.CommissionPercent.ToString AndAlso
                                GridColumn.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.CityTaxPercent.ToString AndAlso
                                GridColumn.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.CountyTaxPercent.ToString AndAlso
                                GridColumn.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.StateTaxPercent.ToString Then

                            SetColumnAsSumColumn(DataGridViewIncomeOnly_Details, GridColumn.FieldName)

                            If Not DataGridViewIncomeOnly_Details.Columns(GridColumn.FieldName).Summary.Where(Function(S) S.SummaryType = DevExpress.Data.SummaryItemType.Custom).Any Then

                                GridColumnSummaryItem = DataGridViewIncomeOnly_Details.Columns(GridColumn.FieldName).Summary.Add(DevExpress.Data.SummaryItemType.Custom)
                                GridColumnSummaryItem.DisplayFormat = "{0:n2}"

                            End If

                        End If

                    End If

                Next

            End If

        End Sub
        Private Sub DataGridViewIncomeOnly_Details_HideCustomizationFormEvent(sender As Object, e As EventArgs) Handles DataGridViewIncomeOnly_Details.HideCustomizationFormEvent

            If ButtonItemIncomeOnly_ChooseColumns.Checked Then

                ButtonItemIncomeOnly_ChooseColumns.Checked = False

            End If

        End Sub
        Private Sub DataGridViewIncomeOnly_Details_PopupMenuShowingEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles DataGridViewIncomeOnly_Details.PopupMenuShowingEvent

            AdvantageFramework.Billing.Presentation.HideGroupByMenuOptions(e)

        End Sub
        Private Sub DataGridViewIncomeOnly_Details_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewIncomeOnly_Details.QueryPopupNeedDatasourceEvent

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                If FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.SalesTaxCode.ToString Then

                    OverrideDefaultDatasource = True

                    Datasource = AdvantageFramework.Database.Procedures.SalesTax.LoadAllActive(DbContext).ToList

                ElseIf FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.IsBillOnHold.ToString Then

                    OverrideDefaultDatasource = True

                    If DirectCast(DataGridViewIncomeOnly_Details.CurrentView.GetRow(DataGridViewIncomeOnly_Details.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem).ABFlag.GetValueOrDefault(0) = 0 AndAlso
                            DirectCast(DataGridViewIncomeOnly_Details.CurrentView.GetRow(DataGridViewIncomeOnly_Details.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem).IsNonBillable = False Then

                        Datasource = From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.BillingCommandCenter.ProductionBillHoldStatus))
                                     Select Entity.Code,
                                            [Description] = Entity.Description

                    Else

                        Datasource = From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.BillingCommandCenter.ProductionBillHoldStatus))
                                     Where Entity.Code = AdvantageFramework.BillingCommandCenter.ProductionBillHoldStatus.Clear
                                     Select Entity.Code,
                                            [Description] = Entity.Description

                    End If

                End If

            End Using

        End Sub
        Private Sub DataGridViewIncomeOnly_Details_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewIncomeOnly_Details.SelectionChangedEvent

            EnableOrDisableActions()

            If DataGridViewIncomeOnly_Details.CurrentView.RowCount <> 0 Then

                DataGridViewIncomeOnly_Details.CurrentView.UpdateTotalSummary()

            End If

        End Sub
        Private Sub DataGridViewIncomeOnly_Details_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewIncomeOnly_Details.ShowingEditorEvent

            'objects
            Dim IncomeOnlyItem As AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem = Nothing

            If _ReconcileMode Then

                If SelectedJobComponentReconcileStatusCheckable() = False OrElse DataGridViewIncomeOnly_Details.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.Reconcile.ToString Then

                    e.Cancel = True

                End If

            ElseIf DirectCast(DataGridViewLeftSection_Jobs.CurrentView.GetRow(DataGridViewLeftSection_Jobs.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.JobDetailJobComponent).BillingUser IsNot Nothing Then

                If DataGridViewIncomeOnly_Details.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.Comment.ToString Then

                    e.Cancel = True

                End If

            Else

                IncomeOnlyItem = DirectCast(DataGridViewIncomeOnly_Details.CurrentView.GetRow(DataGridViewIncomeOnly_Details.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem)

                If (DataGridViewIncomeOnly_Details.CurrentView.FocusedColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.CityResaleTaxAmount.ToString OrElse
                        DataGridViewIncomeOnly_Details.CurrentView.FocusedColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.CountyResaleTaxAmount.ToString OrElse
                        DataGridViewIncomeOnly_Details.CurrentView.FocusedColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.StateResaleTaxAmount.ToString) AndAlso
                        IncomeOnlyItem.SalesTaxCode Is Nothing Then

                    e.Cancel = True

                ElseIf DataGridViewIncomeOnly_Details.CurrentView.FocusedColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.SalesTaxCode.ToString Then

                    If _InvoiceTaxFlag = True Then

                        e.Cancel = True

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewVendor_Details_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewVendor_Details.CellValueChangedEvent

            'objects
            Dim AccountPayableProductionItem As AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem = Nothing
            Dim SalesTax As AdvantageFramework.Database.Entities.SalesTax = Nothing
            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
            Dim BillingRate As AdvantageFramework.Database.Classes.BillingRate = Nothing
            Dim TaxableAmount As Decimal = 0

            Try

                AccountPayableProductionItem = DirectCast(DataGridViewVendor_Details.CurrentView.GetRow(e.RowHandle), AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem)

            Catch ex As Exception
                AccountPayableProductionItem = Nothing
            End Try

            If AccountPayableProductionItem IsNot Nothing Then

                If e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.ExtendedMarkupAmount.ToString Then

                    AccountPayableProductionItem.MarkupAmountChanged = True

                    If e.Value = 0 Then

                        AccountPayableProductionItem.CommissionPercent = 0

                    ElseIf AccountPayableProductionItem.ExtendedAmount <> 0 Then

                        AccountPayableProductionItem.CommissionPercent = FormatNumber(e.Value / AccountPayableProductionItem.ExtendedAmount * 100, 3)

                        If AccountPayableProductionItem.CommissionPercent > 999999.999 Then

                            AccountPayableProductionItem.CommissionPercent = 999999.999

                        ElseIf AccountPayableProductionItem.CommissionPercent < -999999.999 Then

                            AccountPayableProductionItem.CommissionPercent = -999999.999

                        End If

                    End If

                ElseIf e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.CommissionPercent.ToString Then

                    AccountPayableProductionItem.MarkupPercentChanged = True

                    AccountPayableProductionItem.ExtendedMarkupAmount = FormatNumber(AccountPayableProductionItem.ExtendedAmount *
                                                                                     AccountPayableProductionItem.CommissionPercent / 100, 2)

                ElseIf e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.ExtendedStateResale.ToString Then

                    AccountPayableProductionItem.TaxAmountChanged = True

                    If e.Value = 0 Then

                        AccountPayableProductionItem.StateTaxPercent = 0

                    Else

                        If AccountPayableProductionItem.TaxCommissionsOnly.GetValueOrDefault(0) = 1 Then

                            TaxableAmount = AccountPayableProductionItem.ExtendedMarkupAmount

                        ElseIf AccountPayableProductionItem.TaxCommissions.GetValueOrDefault(0) = 1 Then

                            TaxableAmount = AccountPayableProductionItem.ExtendedMarkupAmount + AccountPayableProductionItem.ExtendedAmount

                        Else

                            TaxableAmount = AccountPayableProductionItem.ExtendedAmount

                        End If

                        If TaxableAmount <> 0 Then

                            AccountPayableProductionItem.StateTaxPercent = FormatNumber((e.Value / TaxableAmount) * 100, 3)

                        End If

                        If AccountPayableProductionItem.StateTaxPercent > 999.9999 Then

                            AccountPayableProductionItem.StateTaxPercent = 999.9999

                        End If

                    End If

                ElseIf e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.ExtendedCountyResale.ToString Then

                    AccountPayableProductionItem.TaxAmountChanged = True

                    If e.Value = 0 Then

                        AccountPayableProductionItem.CountyTaxPercent = 0

                    Else

                        If AccountPayableProductionItem.TaxCommissionsOnly.GetValueOrDefault(0) = 1 Then

                            TaxableAmount = AccountPayableProductionItem.ExtendedMarkupAmount

                        ElseIf AccountPayableProductionItem.TaxCommissions.GetValueOrDefault(0) = 1 Then

                            TaxableAmount = AccountPayableProductionItem.ExtendedMarkupAmount + AccountPayableProductionItem.ExtendedAmount

                        Else

                            TaxableAmount = AccountPayableProductionItem.ExtendedAmount

                        End If

                        If TaxableAmount <> 0 Then

                            AccountPayableProductionItem.CountyTaxPercent = FormatNumber((e.Value / TaxableAmount) * 100, 3)

                        End If

                        If AccountPayableProductionItem.CountyTaxPercent > 999.9999 Then

                            AccountPayableProductionItem.CountyTaxPercent = 999.9999

                        End If

                    End If

                ElseIf e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.ExtendedCityResale.ToString Then

                    AccountPayableProductionItem.TaxAmountChanged = True

                    If e.Value = 0 Then

                        AccountPayableProductionItem.CityTaxPercent = 0

                    Else

                        If AccountPayableProductionItem.TaxCommissionsOnly.GetValueOrDefault(0) = 1 Then

                            TaxableAmount = AccountPayableProductionItem.ExtendedMarkupAmount

                        ElseIf AccountPayableProductionItem.TaxCommissions.GetValueOrDefault(0) = 1 Then

                            TaxableAmount = AccountPayableProductionItem.ExtendedMarkupAmount + AccountPayableProductionItem.ExtendedAmount

                        Else

                            TaxableAmount = AccountPayableProductionItem.ExtendedAmount

                        End If

                        If TaxableAmount <> 0 Then

                            AccountPayableProductionItem.CityTaxPercent = FormatNumber((e.Value / TaxableAmount) * 100, 3)

                        End If

                        If AccountPayableProductionItem.CityTaxPercent > 999.9999 Then

                            AccountPayableProductionItem.CityTaxPercent = 999.9999

                        End If

                    End If

                ElseIf e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.SalesTaxCode.ToString Then

                    AccountPayableProductionItem.TaxCodeChanged = True

                    If e.Value Is Nothing Then

                        AccountPayableProductionItem.IsResaleTax = Nothing
                        AccountPayableProductionItem.TaxCommissions = 0
                        AccountPayableProductionItem.TaxCommissionsOnly = 0
                        AccountPayableProductionItem.StateTaxPercent = 0
                        AccountPayableProductionItem.CountyTaxPercent = 0
                        AccountPayableProductionItem.CityTaxPercent = 0
                        AccountPayableProductionItem.ExtendedStateResale = 0
                        AccountPayableProductionItem.ExtendedCountyResale = 0
                        AccountPayableProductionItem.ExtendedCityResale = 0

                    Else

                        Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                            SalesTax = AdvantageFramework.Database.Procedures.SalesTax.LoadBySalesTaxCode(DbContext, e.Value)

                            If SalesTax IsNot Nothing Then

                                Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, AccountPayableProductionItem.JobNumber)

                                If Job IsNot Nothing Then

                                    BillingRate = AdvantageFramework.ExpenseReports.LoadBillingRate(DbContext, AccountPayableProductionItem.FunctionCode, Job.ClientCode,
                                                                                                    Job.DivisionCode, Job.ProductCode, AccountPayableProductionItem.JobNumber,
                                                                                                    AccountPayableProductionItem.JobComponentNumber, Job.SalesClassCode, Nothing, Nothing)

                                    If BillingRate IsNot Nothing Then

                                        AccountPayableProductionItem.TaxCommissions = BillingRate.TAX_COMM.GetValueOrDefault(0)
                                        AccountPayableProductionItem.TaxCommissionsOnly = BillingRate.TAX_COMM_ONLY.GetValueOrDefault(0)

                                    End If

                                End If

                                AccountPayableProductionItem.IsResaleTax = SalesTax.Resale
                                AccountPayableProductionItem.StateTaxPercent = SalesTax.StatePercent.GetValueOrDefault(0)
                                AccountPayableProductionItem.CountyTaxPercent = SalesTax.CountyPercent.GetValueOrDefault(0)
                                AccountPayableProductionItem.CityTaxPercent = SalesTax.CityPercent.GetValueOrDefault(0)

                            End If

                        End Using

                    End If

                End If

                If e.Column.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.ResaleTax.ToString AndAlso
                        e.Column.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.TaxCommissions.ToString AndAlso
                        e.Column.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.TaxCommissionsOnly.ToString AndAlso
                        e.Column.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.Comment.ToString AndAlso
                        e.Column.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.ExtendedCityResale.ToString AndAlso
                        e.Column.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.ExtendedCountyResale.ToString AndAlso
                        e.Column.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.ExtendedStateResale.ToString AndAlso
                        e.Column.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.Reconcile.ToString Then

                    AccountPayableProductionItem.CalculateTax(AccountPayableProductionItem)

                    DataGridViewVendor_Details.CurrentView.RefreshRow(e.RowHandle)

                End If

                DataGridViewVendor_Details.CurrentView.UpdateTotalSummary()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub DataGridViewVendor_Details_CellValueChangingEvent(ByRef Saved As Boolean, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewVendor_Details.CellValueChangingEvent

            If _ReconcileMode AndAlso e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.Reconcile.ToString Then

                CheckUncheckFunctionsBasedOnVendorChecked(e.RowHandle, e.Value)

            End If

        End Sub
        'Private Sub DataGridViewVendor_Details_ColumnFilterChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewVendor_Details.ColumnFilterChangedEvent

        '    If Me.FormAction = WinForm.Presentation.FormActions.None AndAlso sender.GetType Is GetType(AdvantageFramework.WinForm.Presentation.Controls.GridView) Then

        '        If DirectCast(sender, AdvantageFramework.WinForm.Presentation.Controls.GridView).AFActiveFilterString.Contains("IsNonBillable") = False Then

        '            ButtonItemVendor_HideNonBillable.Checked = False

        '        End If

        '    End If

        'End Sub
        Private Sub DataGridViewVendor_Details_ColumnValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs, ViaCellValueChangedEvent As Boolean) Handles DataGridViewVendor_Details.ColumnValueChangedEvent

            If e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.IsBillOnHold.ToString Then

                DataGridViewVendor_Details.CurrentView.CloseEditor()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub DataGridViewVendor_Details_CustomDrawGroupRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs) Handles DataGridViewVendor_Details.CustomDrawGroupRowEvent

            Dim GridView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            Dim GridGroupRowInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo = Nothing
            Dim AccountPayableProductionItem As AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem = Nothing

            GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            GridGroupRowInfo = TryCast(e.Info, DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo)

            If GridView IsNot Nothing AndAlso GridGroupRowInfo IsNot Nothing Then

                If GridGroupRowInfo.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.FunctionDescription.ToString Then

                    AccountPayableProductionItem = DataGridViewVendor_Details.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem)().Where(Function(Entity) Entity.FunctionCode = GridGroupRowInfo.EditValue).FirstOrDefault

                    If AccountPayableProductionItem IsNot Nothing Then

                        GridGroupRowInfo.GroupText = AccountPayableProductionItem.FunctionDescription

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewVendor_Details_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewVendor_Details.DataSourceChangedEvent

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim GridColumnSummaryItem As DevExpress.XtraGrid.GridColumnSummaryItem = Nothing

            If Not Me.IsFormClosing Then

                DataGridViewVendor_Details.CurrentView.OptionsView.ShowFooter = True

                DataGridViewVendor_Details.CurrentView.OptionsView.EnableAppearanceOddRow = True
                DataGridViewVendor_Details.CurrentView.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)

                For Each GridColumn In DataGridViewVendor_Details.Columns

                    If GridColumn.ColumnType Is GetType(System.Decimal) OrElse
                            GridColumn.ColumnType Is GetType(System.Nullable(Of Decimal)) Then

                        If GridColumn.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.Rate.ToString AndAlso
                                GridColumn.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.CommissionPercent.ToString AndAlso
                                GridColumn.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.CityTaxPercent.ToString AndAlso
                                GridColumn.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.CountyTaxPercent.ToString AndAlso
                                GridColumn.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.StateTaxPercent.ToString Then

                            SetColumnAsSumColumn(DataGridViewVendor_Details, GridColumn.FieldName)

                            If Not DataGridViewVendor_Details.Columns(GridColumn.FieldName).Summary.Where(Function(S) S.SummaryType = DevExpress.Data.SummaryItemType.Custom).Any Then

                                GridColumnSummaryItem = DataGridViewVendor_Details.Columns(GridColumn.FieldName).Summary.Add(DevExpress.Data.SummaryItemType.Custom)
                                GridColumnSummaryItem.DisplayFormat = "{0:n2}"

                            End If

                        End If

                    End If

                Next

            End If

        End Sub
        Private Sub DataGridViewVendor_Details_HideCustomizationFormEvent(sender As Object, e As EventArgs) Handles DataGridViewVendor_Details.HideCustomizationFormEvent

            If ButtonItemVendor_ChooseColumns.Checked Then

                ButtonItemVendor_ChooseColumns.Checked = False

            End If

        End Sub
        Private Sub DataGridViewVendor_Details_PopupMenuShowingEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles DataGridViewVendor_Details.PopupMenuShowingEvent

            AdvantageFramework.Billing.Presentation.HideGroupByMenuOptions(e)

        End Sub
        Private Sub DataGridViewVendor_Details_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewVendor_Details.QueryPopupNeedDatasourceEvent

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                If FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.SalesTaxCode.ToString Then

                    OverrideDefaultDatasource = True

                    Datasource = AdvantageFramework.Database.Procedures.SalesTax.LoadAllActive(DbContext).ToList

                ElseIf FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.IsBillOnHold.ToString Then

                    OverrideDefaultDatasource = True

                    If DirectCast(DataGridViewVendor_Details.CurrentView.GetRow(DataGridViewVendor_Details.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem).ABFlag.GetValueOrDefault(0) = 0 Then

                        Datasource = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.BillingCommandCenter.ProductionBillHoldStatus)).ToList
                                      Select [Code] = CShort(EnumObject.Code),
                                             [Description] = EnumObject.Description).ToList

                    Else

                        Datasource = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.BillingCommandCenter.ProductionBillHoldStatus)).ToList
                                      Where EnumObject.Code = CStr(AdvantageFramework.BillingCommandCenter.ProductionBillHoldStatus.Clear)
                                      Select [Code] = CShort(EnumObject.Code),
                                             [Description] = EnumObject.Description).ToList

                    End If

                End If

            End Using

        End Sub
        Private Sub DataGridViewVendor_Details_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewVendor_Details.SelectionChangedEvent

            EnableOrDisableActions()

            If DataGridViewVendor_Details.CurrentView.RowCount <> 0 Then

                DataGridViewVendor_Details.CurrentView.UpdateTotalSummary()

            End If

        End Sub
        Private Sub DataGridViewVendor_Details_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewVendor_Details.ShowingEditorEvent

            'objects
            Dim AccountPayableProductionItem As AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem = Nothing

            If _ReconcileMode Then

                If SelectedJobComponentReconcileStatusCheckable() = False OrElse DataGridViewVendor_Details.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.Reconcile.ToString Then

                    e.Cancel = True

                End If

            ElseIf DirectCast(DataGridViewLeftSection_Jobs.CurrentView.GetRow(DataGridViewLeftSection_Jobs.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.JobDetailJobComponent).BillingUser IsNot Nothing Then

                If DataGridViewVendor_Details.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.Comment.ToString Then

                    e.Cancel = True

                End If

            Else

                AccountPayableProductionItem = DirectCast(DataGridViewVendor_Details.CurrentView.GetRow(DataGridViewVendor_Details.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem)

                If AccountPayableProductionItem.IsNonBillable.GetValueOrDefault(0) = 1 Then

                    e.Cancel = True

                ElseIf (DataGridViewVendor_Details.CurrentView.FocusedColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.ExtendedCityResale.ToString OrElse
                        DataGridViewVendor_Details.CurrentView.FocusedColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.ExtendedCountyResale.ToString OrElse
                        DataGridViewVendor_Details.CurrentView.FocusedColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.ExtendedStateResale.ToString) AndAlso
                        (AccountPayableProductionItem.SalesTaxCode Is Nothing OrElse AccountPayableProductionItem.IsResaleTax.GetValueOrDefault(0) <> 1) Then

                    e.Cancel = True

                ElseIf DataGridViewVendor_Details.CurrentView.FocusedColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.SalesTaxCode.ToString Then

                    If _InvoiceTaxFlag = True Then

                        e.Cancel = True

                    ElseIf AccountPayableProductionItem.SalesTaxCode IsNot Nothing AndAlso AccountPayableProductionItem.ExtendedNonResaleTax <> 0 Then

                        e.Cancel = True

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewLeftSection_Jobs_LeavingRowEvent(e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_Jobs.LeavingRowEvent

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_Jobs_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewLeftSection_Jobs.SelectionChangedEvent

            If Me.IsFormClosing = False AndAlso Me.FormAction = WinForm.Presentation.FormActions.None AndAlso Not _IsClosing AndAlso DataGridViewLeftSection_Jobs.HasRows Then

                Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem

                If Not _ReconcileMode Then

                    AdvantageFramework.WinForm.Presentation.Controls.SaveDataGridViewLayout(Session, DataGridViewTop_JobComponentFunctions, AdvantageFramework.Database.Entities.GridAdvantageType.BillingCommandCenterJobComponentFunctionDetail)

                    ButtonItemStatus_Adjusted.Checked = DirectCast(DataGridViewLeftSection_Jobs.CurrentView.GetRow(DataGridViewLeftSection_Jobs.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.JobDetailJobComponent).IsAdjusted

                End If

                LoadFunctions()

                For Each TabItem In TabControlRightSection_FunctionItems.Tabs.OfType(Of DevComponents.DotNetBar.TabItem)()

                    TabItem.Tag = False

                Next

                LoadFunctionItems()

                ButtonItemFunctionGrid_SelectAll.Checked = True

                Me.FormAction = WinForm.Presentation.FormActions.None

            End If

        End Sub
        Private Sub DataGridViewTop_JobComponentFunctions_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewTop_JobComponentFunctions.CellValueChangedEvent

            If e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.BillingApprovalFunctionClientComment.ToString Then

                Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    AdvantageFramework.BillingCommandCenter.UpdateBillingApprovalDetailClientComment(BCCDbContext, e.Value, DirectCast(DataGridViewTop_JobComponentFunctions.CurrentView.GetRow(DataGridViewTop_JobComponentFunctions.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail).BillingApprovalDetailID.Value)

                End Using

            End If

        End Sub
        Private Sub DataGridViewTop_JobComponentFunctions_CellValueChangingEvent(ByRef Saved As Boolean, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewTop_JobComponentFunctions.CellValueChangingEvent

            If _ReconcileMode Then

                If e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.Reconcile.ToString Then

                    CheckUncheckFunctionItemsForReconcile(e.RowHandle, e.Value)

                End If

            End If

        End Sub
        Private Sub DataGridViewTop_JobComponentFunctions_CustomDrawCellEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles DataGridViewTop_JobComponentFunctions.CustomDrawCellEvent

            If e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.BillingApprovalFunctionAmount.ToString Then

                If DataGridViewTop_JobComponentFunctions.CurrentView.GetRow(e.RowHandle) IsNot Nothing AndAlso e.CellValue <> DirectCast(DataGridViewTop_JobComponentFunctions.CurrentView.GetRow(e.RowHandle), AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail).AmountToBill Then

                    e.Appearance.ForeColor = System.Drawing.Color.Red

                End If

            End If

        End Sub
        Private Sub DataGridViewTop_JobComponentFunctions_CustomSummaryCalculateEvent(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles DataGridViewTop_JobComponentFunctions.CustomSummaryCalculateEvent

            Dim JobComponentFunctionDetails As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail) = Nothing

            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then

                JobComponentFunctionDetails = DataGridViewTop_JobComponentFunctions.GetAllRowsDataBoundItems().OfType(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail).ToList()

                If e.Item.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.BilledOfEstimate.ToString Then

                    If JobComponentFunctionDetails.Sum(Function(JCF) JCF.EstimateAmount) <> 0 Then

                        e.TotalValue = FormatNumber(JobComponentFunctionDetails.Sum(Function(JCF) JCF.BilledAmount.GetValueOrDefault(0) + JCF.AdvanceBilledAmount.GetValueOrDefault(0)) /
                                                                  JobComponentFunctionDetails.Sum(Function(JCF) JCF.EstimateAmount) * 100, 2)
                    Else

                        e.TotalValue = 0

                    End If

                ElseIf e.Item.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.PercentCompleteTime.ToString OrElse
                        e.Item.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.PercentCompleteAll.ToString Then

                    If e.Item.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.PercentCompleteTime.ToString Then

                        JobComponentFunctionDetails = JobComponentFunctionDetails.Where(Function(JCF) JCF.FunctionType = "E").ToList

                    Else

                        JobComponentFunctionDetails = JobComponentFunctionDetails.ToList

                    End If

                    If JobComponentFunctionDetails.Sum(Function(JCF) JCF.EstimateNetAmount + JCF.EstimateMarkupAmount) <> 0 Then

                        e.TotalValue = FormatNumber(JobComponentFunctionDetails.Sum(Function(JCF) JCF.ActualBillableNetAmount.GetValueOrDefault(0) + JCF.ActualBillableMarkupAmount.GetValueOrDefault(0) + JCF.FeeAmount.GetValueOrDefault(0)) _
                                                    / JobComponentFunctionDetails.Sum(Function(JCF) JCF.EstimateNetAmount + JCF.EstimateMarkupAmount) * 100, 2)

                    Else

                        e.TotalValue = 0

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewTop_JobComponentFunctions_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewTop_JobComponentFunctions.DataSourceChangedEvent

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            If Not Me.IsFormClosing Then

                DataGridViewTop_JobComponentFunctions.CurrentView.OptionsView.ShowFooter = True

                DataGridViewTop_JobComponentFunctions.CurrentView.OptionsView.EnableAppearanceOddRow = True
                DataGridViewTop_JobComponentFunctions.CurrentView.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)

                For Each GridColumn In DataGridViewTop_JobComponentFunctions.Columns

                    If GridColumn.ColumnType Is GetType(System.Decimal) OrElse GridColumn.ColumnType Is GetType(System.Nullable(Of Decimal)) Then

                        If GridColumn.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.BilledOfEstimate.ToString AndAlso
                                GridColumn.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.PercentCompleteTime.ToString AndAlso
                                GridColumn.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.PercentCompleteAll.ToString Then

                            SetColumnAsSumColumn(DataGridViewTop_JobComponentFunctions, GridColumn.FieldName)

                        ElseIf GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.BilledOfEstimate.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.PercentCompleteTime.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.PercentCompleteAll.ToString Then

                            If GridColumn.SummaryItem.SummaryType <> DevExpress.Data.SummaryItemType.Custom Then

                                GridColumn.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom
                                GridColumn.SummaryItem.DisplayFormat = "{0:n2}"

                            End If

                        End If

                    End If

                Next

            End If

        End Sub
        Private Sub DataGridViewTop_JobComponentFunctions_DeselectAllEvent() Handles DataGridViewTop_JobComponentFunctions.DeselectAllEvent

            ButtonItemFunctionGrid_SelectAll.Checked = False

        End Sub
        Private Sub DataGridViewTop_JobComponentFunctions_GridViewKeyDownEvent(sender As Object, e As Windows.Forms.KeyEventArgs) Handles DataGridViewTop_JobComponentFunctions.GridViewKeyDownEvent

            If ButtonItemActions_Save.Enabled AndAlso TabControlRightSection_FunctionItems.SelectedTab IsNot TabItemFunctionItems_AdvanceBilling Then

                e.Handled = True

            End If

        End Sub
        Private Sub DataGridViewTop_JobComponentFunctions_GridViewMouseDownEvent(sender As Object, e As Windows.Forms.MouseEventArgs) Handles DataGridViewTop_JobComponentFunctions.GridViewMouseDownEvent

            If Not _ReconcileMode Then

                If ButtonItemActions_Save.Enabled AndAlso TabControlRightSection_FunctionItems.SelectedTab IsNot TabItemFunctionItems_AdvanceBilling Then

                    DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = True

                End If

            End If

        End Sub
        Private Sub DataGridViewTop_JobComponentFunctions_HideCustomizationFormEvent(sender As Object, e As EventArgs) Handles DataGridViewTop_JobComponentFunctions.HideCustomizationFormEvent

            If ButtonItemFunctionGrid_ChooseColumns.Checked Then

                ButtonItemFunctionGrid_ChooseColumns.Checked = False

            End If

        End Sub
        Private Sub DataGridViewTop_JobComponentFunctions_LeavingRowEvent(e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewTop_JobComponentFunctions.LeavingRowEvent

            If Me.FormAction = WinForm.Presentation.FormActions.None AndAlso TabControlRightSection_FunctionItems.SelectedTab IsNot TabItemFunctionItems_AdvanceBilling Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewTop_JobComponentFunctions_PopupMenuShowingEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles DataGridViewTop_JobComponentFunctions.PopupMenuShowingEvent

            If _ReconcileMode Then

                AdvantageFramework.Billing.Presentation.HideGroupByMenuOptions(e)

            End If

        End Sub
        Private Sub DataGridViewTop_JobComponentFunctions_SelectAllEvent() Handles DataGridViewTop_JobComponentFunctions.SelectAllEvent

            ButtonItemFunctionGrid_SelectAll.Checked = True

        End Sub
        Private Sub DataGridViewTop_JobComponentFunctions_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewTop_JobComponentFunctions.SelectionChangedEvent

            If Me.FormAction <> WinForm.Presentation.FormActions.Loading AndAlso Me.FormAction <> WinForm.Presentation.FormActions.LoadingSelectedItem AndAlso Me.FormAction <> WinForm.Presentation.FormActions.Refreshing AndAlso
                    TabControlRightSection_FunctionItems.SelectedTab IsNot TabItemFunctionItems_AdvanceBilling Then

                For Each TabItem In TabControlRightSection_FunctionItems.Tabs.OfType(Of DevComponents.DotNetBar.TabItem)()

                    TabItem.Tag = False

                Next

                Me.FormAction = WinForm.Presentation.FormActions.Refreshing

                ButtonItemFunctionGrid_SelectAll.Checked = If(DataGridViewTop_JobComponentFunctions.CurrentView.SelectedRowsCount > 1 AndAlso DataGridViewTop_JobComponentFunctions.CurrentView.RowCount = DataGridViewTop_JobComponentFunctions.CurrentView.SelectedRowsCount, True, False)

                Me.FormAction = WinForm.Presentation.FormActions.None

                SetFunctionTab()

                LoadFunctionItems()

            ElseIf Me.FormAction = WinForm.Presentation.FormActions.None AndAlso
                    TabControlRightSection_FunctionItems.SelectedTab Is TabItemFunctionItems_AdvanceBilling Then

                Me.FormAction = WinForm.Presentation.FormActions.Refreshing

                ButtonItemFunctionGrid_SelectAll.Checked = If(DataGridViewTop_JobComponentFunctions.CurrentView.SelectedRowsCount > 1 AndAlso DataGridViewTop_JobComponentFunctions.CurrentView.RowCount = DataGridViewTop_JobComponentFunctions.CurrentView.SelectedRowsCount, True, False)

                Me.FormAction = WinForm.Presentation.FormActions.None

            End If

        End Sub
        Private Sub DataGridViewTop_JobComponentFunctions_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewTop_JobComponentFunctions.ShowingEditorEvent

            If _ReconcileMode Then

                If SelectedJobComponentReconcileStatusCheckable() = False OrElse DataGridViewTop_JobComponentFunctions.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.Reconcile.ToString Then

                    e.Cancel = True

                End If

            ElseIf DataGridViewTop_JobComponentFunctions.CurrentView.FocusedColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.BillingApprovalFunctionClientComment.ToString Then

                If DirectCast(DataGridViewTop_JobComponentFunctions.CurrentView.GetRow(DataGridViewTop_JobComponentFunctions.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail).BillingApprovalDetailID Is Nothing Then

                    e.Cancel = True

                End If

            ElseIf DataGridViewTop_JobComponentFunctions.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.BillingApprovalFunctionComment.ToString Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DataGridViewTop_JobComponentFunctions_ShowCustomizationFormEvent(sender As Object, e As EventArgs) Handles DataGridViewTop_JobComponentFunctions.ShowCustomizationFormEvent

            For Each GridColumn In DataGridViewTop_JobComponentFunctions.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                GridColumn.Caption = GridColumn.Caption.Replace(vbCrLf, " ")

            Next

        End Sub
        'Private Sub NumericInputControl_PercentOfQuote_Click(sender As Object, e As EventArgs) Handles NumericInputControl_PercentOfQuote.Click

        '    Dim JobNumber As Integer = Nothing
        '    Dim JobComponentNumber As Short = Nothing
        '    Dim EstimateApproval As AdvantageFramework.Database.Views.EstimateApproval = Nothing
        '    Dim AdvanceBillPercentToQuote As AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillPercentToQuote = Nothing

        '    If NumericInputControl_PercentOfQuote.Enabled Then

        '        AdvanceBillPercentToQuote = New AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillPercentToQuote(NumericInputControl_PercentOfQuote.GetValue, False)

        '        If DataGridViewLeftSection_Jobs.HasRows AndAlso AdvantageFramework.WinForm.Presentation.GenericPropertyGridDialog.ShowFormDialog("Advance Bill % to Quote", AdvanceBillPercentToQuote, False) = Windows.Forms.DialogResult.OK Then

        '            JobNumber = DirectCast(DataGridViewLeftSection_Jobs.CurrentView.GetRow(DataGridViewLeftSection_Jobs.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.JobDetailJobComponent).JobNumber
        '            JobComponentNumber = DirectCast(DataGridViewLeftSection_Jobs.CurrentView.GetRow(DataGridViewLeftSection_Jobs.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.JobDetailJobComponent).JobComponentNumber

        '            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

        '                EstimateApproval = (From EA In AdvantageFramework.Database.Procedures.EstimateApprovalView.Load(DbContext)
        '                                    Where EA.JobNumber = JobNumber AndAlso
        '                                      EA.JobComponentNumber = JobComponentNumber
        '                                    Select EA).FirstOrDefault

        '                If EstimateApproval IsNot Nothing Then

        '                    NumericInputControl_PercentOfQuote.EditValue = AdvanceBillPercentToQuote.PercentToQuote

        '                    Me.ShowWaitForm()

        '                    AddAdvanceBillingRows(DbContext, EstimateApproval, AdvanceBillPercentToQuote)

        '                    Me.CloseWaitForm()

        '                End If

        '            End Using

        '            EnableOrDisableActions()

        '        End If

        '        DataGridViewAdvanceBilling_Details.Focus()

        '    End If

        'End Sub
        Private Sub NumericInputControl_PercentOfQuote_Leave(sender As Object, e As EventArgs) Handles NumericInputControl_PercentOfQuote.Leave

            Dim JobNumber As Integer = Nothing
            Dim JobComponentNumber As Short = Nothing
            Dim EstimateApproval As AdvantageFramework.Database.Views.EstimateApproval = Nothing
            Dim AdvanceBillPercentToQuote As AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillPercentToQuote = Nothing
            Dim PercentOfQuote As Decimal = 0

            If DataGridViewLeftSection_Jobs.HasRows AndAlso NumericInputControl_PercentOfQuote.EditValue IsNot Nothing Then

                PercentOfQuote = If(NumericInputControl_PercentOfQuote.GetValue > 100, 100, NumericInputControl_PercentOfQuote.GetValue)

                AdvanceBillPercentToQuote = New AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillPercentToQuote(PercentOfQuote, CheckBoxItemBillMethod_ExcludeNonBillableFunctions.Checked)

                JobNumber = DirectCast(DataGridViewLeftSection_Jobs.CurrentView.GetRow(DataGridViewLeftSection_Jobs.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.JobDetailJobComponent).JobNumber
                JobComponentNumber = DirectCast(DataGridViewLeftSection_Jobs.CurrentView.GetRow(DataGridViewLeftSection_Jobs.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.JobDetailJobComponent).JobComponentNumber

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    EstimateApproval = (From EA In AdvantageFramework.Database.Procedures.EstimateApprovalView.Load(DbContext)
                                        Where EA.JobNumber = JobNumber AndAlso
                                              EA.JobComponentNumber = JobComponentNumber
                                        Select EA).FirstOrDefault

                    If EstimateApproval IsNot Nothing Then

                        Me.ShowWaitForm()

                        AddAdvanceBillingRows(DbContext, EstimateApproval, AdvanceBillPercentToQuote)

                        Me.CloseWaitForm()

                    End If

                End Using

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub TabControlRightSection_FunctionItems_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlRightSection_FunctionItems.SelectedTabChanged

            RibbonControlForm_MainRibbon.SuspendLayout()

            If Not _ReconcileMode Then

                RibbonBarOptions_OpenPO.Visible = False
                RibbonBarOptions_IncomeRecognition.Visible = False
                RibbonBarOptions_AdvanceBilling.Visible = False
                RibbonBarOptions_PercentOfQuoteBilled.Visible = False
                RibbonBarOptions_BillMethod.Visible = False
                RibbonBarOptions_IncomeMethod.Visible = False

                RibbonBarOptions_Documents.Visible = False
                RibbonBarOptions_Vendor.Visible = False
                RibbonBarOptions_IncomeOnly.Visible = False
                RibbonBarOptions_EmployeeTime.Visible = False

                If TabControlRightSection_FunctionItems.SelectedTab Is TabItemFunctionItems_EmployeeTime Then

                    RibbonBarOptions_EmployeeTime.Visible = True

                ElseIf TabControlRightSection_FunctionItems.SelectedTab Is TabItemFunctionItems_IncomeOnly Then

                    RibbonBarOptions_IncomeOnly.Visible = True

                ElseIf TabControlRightSection_FunctionItems.SelectedTab Is TabItemFunctionItems_Vendor Then

                    RibbonBarOptions_Vendor.Visible = True

                ElseIf TabControlRightSection_FunctionItems.SelectedTab Is TabItemFunctionItems_Documents Then

                    RibbonBarOptions_Documents.Visible = True

                ElseIf TabControlRightSection_FunctionItems.SelectedTab Is TabItemFunctionItems_AdvanceBilling Then

                    RibbonBarOptions_IncomeMethod.Visible = True
                    RibbonBarOptions_BillMethod.Visible = True
                    RibbonBarOptions_PercentOfQuoteBilled.Visible = True
                    RibbonBarOptions_AdvanceBilling.Visible = True
                    RibbonBarOptions_IncomeRecognition.Visible = True

                ElseIf TabControlRightSection_FunctionItems.SelectedTab Is TabItemFunctionItems_OpenPO Then

                    RibbonBarOptions_OpenPO.Visible = True

                End If

            Else

                RibbonBarOptions_ReconcileVendor.Visible = False
                RibbonBarOptions_ReconcileIncomeOnly.Visible = False
                RibbonBarOptions_ReconcileEmployeeTime.Visible = False

                If TabControlRightSection_FunctionItems.SelectedTab Is TabItemFunctionItems_EmployeeTime Then

                    RibbonBarOptions_ReconcileEmployeeTime.Visible = True

                ElseIf TabControlRightSection_FunctionItems.SelectedTab Is TabItemFunctionItems_IncomeOnly Then

                    RibbonBarOptions_ReconcileIncomeOnly.Visible = True

                ElseIf TabControlRightSection_FunctionItems.SelectedTab Is TabItemFunctionItems_Vendor Then

                    RibbonBarOptions_ReconcileVendor.Visible = True

                End If

            End If

            RibbonControlForm_MainRibbon.ResumeLayout(False)
            RibbonControlForm_MainRibbon.PerformLayout()

            EnableOrDisableActions()

        End Sub
        Private Sub TabControlRightSection_FunctionItems_SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControlRightSection_FunctionItems.SelectedTabChanging

            If Session IsNot Nothing Then

                DataGridViewEmployeeTime_Details.CurrentView.CloseEditorForUpdating()
                DataGridViewIncomeOnly_Details.CurrentView.CloseEditorForUpdating()
                DataGridViewVendor_Details.CurrentView.CloseEditorForUpdating()
                DataGridViewAdvanceBilling_Details.CurrentView.CloseEditorForUpdating()

                e.Cancel = Not CheckForUnsavedChanges()

                If Not e.Cancel Then

                    e.OldTab.Tag = False

                    Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem

                    TabControlRightSection_FunctionItems.SuspendLayout()

                    CloseCustomizationForms()

                    If e.NewTab Is TabItemFunctionItems_EmployeeTime Then

                        If e.NewTab.Tag = False Then

                            LoadEmployeeTime()
                            TabControlPanelEmployeeTimeTab_EmployeeTime.Update()

                        End If

                    ElseIf e.NewTab Is TabItemFunctionItems_IncomeOnly Then

                        If e.NewTab.Tag = False Then

                            LoadIncomeOnly()
                            TabControlPanelIncomeOnlyTab_IncomeOnly.Update()

                        End If

                    ElseIf e.NewTab Is TabItemFunctionItems_Vendor Then

                        If e.NewTab.Tag = False Then

                            LoadVendorAccountPayableProduction()
                            TabControlPanelVendorTab_Vendor.Update()

                        End If

                    ElseIf e.NewTab Is TabItemFunctionItems_Documents Then

                        If e.NewTab.Tag = False Then

                            LoadDocuments()
                            TabControlPanelDocumentsTab_Documents.Update()

                        End If

                    ElseIf e.NewTab Is TabItemFunctionItems_AdvanceBilling Then

                        If e.NewTab.Tag = False Then

                            LoadAdvanceBilling()
                            TabControlPanelAdvanceBillingTab_AdvanceBilling.Update()
                            CheckBoxItemBillMethod_ExcludeNonBillableFunctions.Checked = GetUserSetting(AdvantageFramework.Security.UserSettings.BCCExcludeNonBillableFunctionsAdvanceBilling.ToString)

                        End If

                    ElseIf e.NewTab Is TabItemFunctionItems_OpenPO Then

                        If e.NewTab.Tag = False Then

                            LoadOpenPO()
                            TabControlPanelOpenPOTab_OpenPO.Update()

                        End If

                    End If

                    TabControlRightSection_FunctionItems.ResumeLayout()

                    Me.FormAction = WinForm.Presentation.FormActions.None

                    Me.ClearChanged()

                    EnableOrDisableActions()

                End If

            End If

        End Sub
        Private Sub DataGridViewOpenPO_Details_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewOpenPO_Details.DataSourceChangedEvent

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            If Not Me.IsFormClosing Then

                DataGridViewOpenPO_Details.CurrentView.OptionsView.ShowFooter = True

                DataGridViewOpenPO_Details.CurrentView.OptionsView.EnableAppearanceOddRow = True
                DataGridViewOpenPO_Details.CurrentView.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)

                For Each GridColumn In DataGridViewOpenPO_Details.Columns

                    If GridColumn.ColumnType Is GetType(System.Decimal) Then

                        If GridColumn.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.OpenPOItem.Properties.Rate.ToString Then

                            SetColumnAsSumColumn(DataGridViewOpenPO_Details, GridColumn.FieldName)

                        End If

                    End If

                Next

            End If

        End Sub
        Private Sub DataGridViewLeftSection_Jobs_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewLeftSection_Jobs.ShowingEditorEvent

            If DataGridViewLeftSection_Jobs.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.JobDetailJobComponent.Properties.IsAdjusted.ToString Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DataGridViewLeftSection_Jobs_CellValueChangingEvent(ByRef Saved As Boolean, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewLeftSection_Jobs.CellValueChangingEvent

            If e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobDetailJobComponent.Properties.IsAdjusted.ToString Then

                SetAdjusted(e.Value)

                Me.FormAction = WinForm.Presentation.Methods.FormActions.Refreshing

                ButtonItemStatus_Adjusted.Checked = e.Value

                Me.FormAction = WinForm.Presentation.Methods.FormActions.None

            End If

        End Sub
        Private Sub DataGridViewEmployeeTime_Details_CustomSummaryCalculateEvent(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles DataGridViewEmployeeTime_Details.CustomSummaryCalculateEvent

            Dim EmployeeTimeItems As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem) = Nothing

            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then

                EmployeeTimeItems = DataGridViewEmployeeTime_Details.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem).ToList()

                If e.Item.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.Hours.ToString Then

                    e.TotalValue = EmployeeTimeItems.Sum(Function(ET) ET.Hours)

                ElseIf e.Item.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.TotalBill.ToString Then

                    e.TotalValue = EmployeeTimeItems.Sum(Function(ET) ET.TotalBill)

                ElseIf e.Item.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.MarkupAmount.ToString Then

                    e.TotalValue = EmployeeTimeItems.Sum(Function(ET) ET.MarkupAmount)

                ElseIf e.Item.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.Total.ToString Then

                    e.TotalValue = EmployeeTimeItems.Sum(Function(ET) ET.Total)

                ElseIf e.Item.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.NetApprovedAmount.ToString Then

                    e.TotalValue = EmployeeTimeItems.Sum(Function(ET) ET.NetApprovedAmount)

                End If

            End If

        End Sub
        Private Sub DataGridViewEmployeeTime_Details_CustomDrawFooterEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs) Handles DataGridViewEmployeeTime_Details.CustomDrawFooterEvent

            'objects
            Dim GridViewInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridViewInfo = Nothing

            e.Painter.DrawObject(e.Info)

            GridViewInfo = DataGridViewEmployeeTime_Details.CurrentView.GetViewInfo()

            If DataGridViewEmployeeTime_Details.CurrentView.VisibleColumns IsNot Nothing Then

                e.Graphics.DrawString("Total",
                                      e.Appearance.Font, System.Drawing.Brushes.Black, GetRectangleForRow(0, e.Bounds, e.Appearance.Font.Height, DataGridViewEmployeeTime_Details),
                                      New System.Drawing.StringFormat() With {.LineAlignment = System.Drawing.StringAlignment.Near, .Alignment = System.Drawing.StringAlignment.Near})

                e.Graphics.DrawString("Selected",
                                      e.Appearance.Font, System.Drawing.Brushes.Black, GetRectangleForRow(1, e.Bounds, e.Appearance.Font.Height, DataGridViewEmployeeTime_Details),
                                      New System.Drawing.StringFormat() With {.LineAlignment = System.Drawing.StringAlignment.Near, .Alignment = System.Drawing.StringAlignment.Near})

            End If

            e.Handled = True

        End Sub
        Private Sub DataGridViewIncomeOnly_Details_CustomSummaryCalculateEvent(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles DataGridViewIncomeOnly_Details.CustomSummaryCalculateEvent

            Dim IncomeOnlyItems As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem) = Nothing

            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then

                IncomeOnlyItems = DataGridViewIncomeOnly_Details.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem).ToList()

                If e.Item.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.Quantity.ToString Then

                    e.TotalValue = IncomeOnlyItems.Sum(Function(ET) ET.Quantity)

                ElseIf e.Item.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.Amount.ToString Then

                    e.TotalValue = IncomeOnlyItems.Sum(Function(ET) ET.Amount)

                ElseIf e.Item.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.MarkupAmount.ToString Then

                    e.TotalValue = IncomeOnlyItems.Sum(Function(ET) ET.MarkupAmount)

                ElseIf e.Item.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.Total.ToString Then

                    e.TotalValue = IncomeOnlyItems.Sum(Function(ET) ET.Total)

                ElseIf e.Item.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.NetApprovedAmount.ToString Then

                    e.TotalValue = IncomeOnlyItems.Sum(Function(ET) ET.NetApprovedAmount)

                End If

            End If

        End Sub
        Private Sub DataGridViewIncomeOnly_Details_CustomDrawFooterEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs) Handles DataGridViewIncomeOnly_Details.CustomDrawFooterEvent

            'objects
            Dim GridViewInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridViewInfo = Nothing

            e.Painter.DrawObject(e.Info)

            GridViewInfo = DataGridViewIncomeOnly_Details.CurrentView.GetViewInfo()

            If DataGridViewIncomeOnly_Details.CurrentView.VisibleColumns IsNot Nothing Then

                e.Graphics.DrawString("Total",
                                      e.Appearance.Font, System.Drawing.Brushes.Black, GetRectangleForRow(0, e.Bounds, e.Appearance.Font.Height, DataGridViewIncomeOnly_Details),
                                      New System.Drawing.StringFormat() With {.LineAlignment = System.Drawing.StringAlignment.Near, .Alignment = System.Drawing.StringAlignment.Near})

                e.Graphics.DrawString("Selected",
                                      e.Appearance.Font, System.Drawing.Brushes.Black, GetRectangleForRow(1, e.Bounds, e.Appearance.Font.Height, DataGridViewIncomeOnly_Details),
                                      New System.Drawing.StringFormat() With {.LineAlignment = System.Drawing.StringAlignment.Near, .Alignment = System.Drawing.StringAlignment.Near})

            End If

            e.Handled = True

        End Sub
        Private Sub DataGridViewVendor_Details_CustomSummaryCalculateEvent(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles DataGridViewVendor_Details.CustomSummaryCalculateEvent

            Dim AccountPayableProductionItems As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem) = Nothing

            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then

                AccountPayableProductionItems = DataGridViewVendor_Details.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem).ToList()

                If e.Item.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.Quantity.ToString Then

                    e.TotalValue = AccountPayableProductionItems.Sum(Function(ET) ET.Quantity)

                ElseIf e.Item.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.ExtendedAmount.ToString Then

                    e.TotalValue = AccountPayableProductionItems.Sum(Function(ET) ET.ExtendedAmount)

                ElseIf e.Item.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.ExtendedMarkupAmount.ToString Then

                    e.TotalValue = AccountPayableProductionItems.Sum(Function(ET) ET.ExtendedMarkupAmount)

                ElseIf e.Item.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.ExtendedNonResaleTax.ToString Then

                    e.TotalValue = AccountPayableProductionItems.Sum(Function(ET) ET.ExtendedNonResaleTax)

                ElseIf e.Item.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.Total.ToString Then

                    e.TotalValue = AccountPayableProductionItems.Sum(Function(ET) ET.Total)

                ElseIf e.Item.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.LineTotal.ToString Then

                    e.TotalValue = AccountPayableProductionItems.Sum(Function(ET) ET.LineTotal)

                ElseIf e.Item.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.NetApprovedAmount.ToString Then

                    e.TotalValue = AccountPayableProductionItems.Sum(Function(ET) ET.NetApprovedAmount)

                End If

            End If

        End Sub
        Private Sub DataGridViewVendor_Details_CustomDrawFooterEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs) Handles DataGridViewVendor_Details.CustomDrawFooterEvent

            'objects
            Dim GridViewInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridViewInfo = Nothing

            e.Painter.DrawObject(e.Info)

            GridViewInfo = DataGridViewVendor_Details.CurrentView.GetViewInfo()

            If DataGridViewVendor_Details.CurrentView.VisibleColumns IsNot Nothing Then

                e.Graphics.DrawString("Total",
                                      e.Appearance.Font, System.Drawing.Brushes.Black, GetRectangleForRow(0, e.Bounds, e.Appearance.Font.Height, DataGridViewVendor_Details),
                                      New System.Drawing.StringFormat() With {.LineAlignment = System.Drawing.StringAlignment.Near, .Alignment = System.Drawing.StringAlignment.Near})

                e.Graphics.DrawString("Selected",
                                      e.Appearance.Font, System.Drawing.Brushes.Black, GetRectangleForRow(1, e.Bounds, e.Appearance.Font.Height, DataGridViewVendor_Details),
                                      New System.Drawing.StringFormat() With {.LineAlignment = System.Drawing.StringAlignment.Near, .Alignment = System.Drawing.StringAlignment.Near})

            End If

            e.Handled = True

        End Sub

#End Region

#End Region

    End Class

End Namespace
