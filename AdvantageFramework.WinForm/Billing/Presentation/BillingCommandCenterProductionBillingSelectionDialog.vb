Namespace Billing.Presentation

    Public Class BillingCommandCenterProductionBillingSelectionDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _BillingCommandCenterID As Integer = 0
        Private _ProductionSummaryBillingSelectionList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary) = Nothing
        Private _BillingUser As String = Nothing
        Private _BillingStatus As AdvantageFramework.BillingCommandCenter.Database.Classes.BillingStatus = Nothing
        Private _BatchFinished As Boolean = False
        Private WithEvents _ToolTipController As DevExpress.Utils.ToolTipController = Nothing
        Private _ObjectTypePropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
        Private _IsMultiCurrencyEnabled As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property BatchFinished As Boolean
            Get
                BatchFinished = _BatchFinished
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal BillingCommandCenterID As Integer, ByVal ProductionSummaryList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary))

            ' This call is required by the designer.
            InitializeComponent()

            _BillingCommandCenterID = BillingCommandCenterID

            _ProductionSummaryBillingSelectionList = ProductionSummaryList

        End Sub
        Private Sub LoadBillingSelection()

            Dim BillingCommandCenter As AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter = Nothing
            Dim BillingCommandCenterInvoiceDatePostPeriod As AdvantageFramework.BillingCommandCenter.Database.Classes.BillingCommandCenterInvoiceDatePostPeriod = Nothing

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                BillingCommandCenter = AdvantageFramework.BillingCommandCenter.Database.Procedures.BillingCommandCenter.LoadByID(BCCDbContext, _BillingCommandCenterID)

                If BillingCommandCenter IsNot Nothing Then

                    _BillingUser = BillingCommandCenter.BillingUser

                    _BillingStatus = AdvantageFramework.BillingCommandCenter.GetBillingStatus(BCCDbContext, BillingCommandCenter.ID)

                    Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        ComboBoxBS_PostingPeriod.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllActiveARPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList

                    End Using

                    BillingCommandCenterInvoiceDatePostPeriod = AdvantageFramework.BillingCommandCenter.GetBillingCommandCenterInvoiceDatePostPeriod(BCCDbContext, BillingCommandCenter.BillingUser)

                    If BillingCommandCenterInvoiceDatePostPeriod IsNot Nothing Then

                        DateTimePickerBS_InvoiceDate.Value = BillingCommandCenterInvoiceDatePostPeriod.InvoiceDate

                        ComboBoxBS_PostingPeriod.SelectedValue = BillingCommandCenterInvoiceDatePostPeriod.PostPeriodCode

                    End If

                    LoadGrid()

                End If

            End Using

            Me.ClearChanged()

            Me.FormAction = WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub LoadGrid()

            Dim LayoutLoaded As Boolean = False

            For Each ProductionSummaryBillingSelection In _ProductionSummaryBillingSelectionList

                ProductionSummaryBillingSelection.BillingSelectionSelect = If(ProductionSummaryBillingSelection.BillingUser IsNot Nothing, True, False)

            Next

            DataGridViewForm_BillingSelection.SetBookmarkColumnIndex(-1)
            DataGridViewForm_BillingSelection.ClearGridCustomization()
            DataGridViewForm_BillingSelection.ClearDatasource(New Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary))
            DataGridViewForm_BillingSelection.ItemDescription = "row(s) Available for Billing Selection"

            LayoutLoaded = AdvantageFramework.WinForm.Presentation.Controls.LoadDataGridViewLayout(Session, DataGridViewForm_BillingSelection, Database.Entities.GridAdvantageType.BillingCommandCenterProductionReview)

            DataGridViewForm_BillingSelection.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True

            DataGridViewForm_BillingSelection.DataSource = _ProductionSummaryBillingSelectionList

            If Not LayoutLoaded Then

                SetColumnDefaultVisibility(DataGridViewForm_BillingSelection)

                DataGridViewForm_BillingSelection.CurrentView.ClearSorting()
                DataGridViewForm_BillingSelection.CurrentView.BeginSort()
                DataGridViewForm_BillingSelection.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.JobNumber.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Descending
                DataGridViewForm_BillingSelection.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ComponentNumber.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                DataGridViewForm_BillingSelection.CurrentView.EndSort()

            Else

                AdvantageFramework.WinForm.Presentation.Controls.SortGridViewBySortedColumns(DataGridViewForm_BillingSelection)

            End If

            If DataGridViewForm_BillingSelection.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.BillStatus.ToString) IsNot Nothing Then

                AddSubItemImageComboBox(DataGridViewForm_BillingSelection, DataGridViewForm_BillingSelection.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.BillStatus.ToString))

            End If

            If DataGridViewForm_BillingSelection.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.IsSelected.ToString) IsNot Nothing Then

                DataGridViewForm_BillingSelection.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.IsSelected.ToString).Visible = False

            End If

            If DataGridViewForm_BillingSelection.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.AmountSelectedforBilling.ToString) IsNot Nothing Then

                DataGridViewForm_BillingSelection.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.AmountSelectedforBilling.ToString).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                DataGridViewForm_BillingSelection.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.AmountSelectedforBilling.ToString).VisibleIndex = 0

            End If

            If DataGridViewForm_BillingSelection.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.BillingSelectionSelect.ToString) IsNot Nothing Then

                DataGridViewForm_BillingSelection.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.BillingSelectionSelect.ToString).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                DataGridViewForm_BillingSelection.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.BillingSelectionSelect.ToString).VisibleIndex = 0
                DataGridViewForm_BillingSelection.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.BillingSelectionSelect.ToString).Caption = "Select"

            End If

            DataGridViewForm_BillingSelection.CurrentView.OptionsBehavior.Editable = True
            DataGridViewForm_BillingSelection.ShowColumnMenuOnRightClick = False

            If Not LayoutLoaded Then

                DataGridViewForm_BillingSelection.CurrentView.BestFitColumns()

            End If

            DataGridViewForm_BillingSelection.CurrentView.FocusedColumn = DataGridViewForm_BillingSelection.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.BillingSelectionSelect.ToString)

            DataGridViewForm_BillingSelection.ClearChanged()

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonItemBillingSelectionActions_Save.Enabled = DataGridViewForm_BillingSelection.UserEntryChanged OrElse DateTimePickerBS_InvoiceDate.UserEntryChanged OrElse ComboBoxBS_PostingPeriod.UserEntryChanged
            ButtonItemBillingSelectionActions_Cancel.Enabled = DataGridViewForm_BillingSelection.UserEntryChanged OrElse DateTimePickerBS_InvoiceDate.UserEntryChanged OrElse ComboBoxBS_PostingPeriod.UserEntryChanged

            ButtonItemProcessInvoices_Process.Enabled = _BillingUser IsNot Nothing AndAlso Not Me.CheckUserEntryChangedSetting AndAlso _BillingStatus IsNot Nothing AndAlso _BillingStatus.IsProcessed = False
            ButtonItemProcessInvoices_CoopSplits.Enabled = _BillingUser IsNot Nothing AndAlso Not Me.CheckUserEntryChangedSetting AndAlso _BillingStatus IsNot Nothing AndAlso _BillingStatus.IsProcessed AndAlso _BillingStatus.HasCoopJobs AndAlso _BillingStatus.IsAssigned.GetValueOrDefault(0) = 0
            ButtonItemProcessInvoices_Draft.Enabled = _BillingUser IsNot Nothing AndAlso Not Me.CheckUserEntryChangedSetting AndAlso _BillingStatus IsNot Nothing AndAlso _BillingStatus.IsProcessed AndAlso _BillingStatus.IsPrinted = 0

            If _BillingUser IsNot Nothing AndAlso _BillingStatus IsNot Nothing AndAlso _BillingStatus.IsAssigned = 1 Then

                ButtonItemProcessInvoices_Assign.Enabled = True
                ButtonItemProcessInvoices_Assign.Image = AdvantageFramework.My.Resources.InvoiceAssignedImage

                RibbonBarOptions_BillingSelectionActions.Enabled = False

                DataGridViewForm_BillingSelection.Enabled = False
                ComboBoxBS_PostingPeriod.Enabled = False
                DateTimePickerBS_InvoiceDate.Enabled = False
                ButtonItemProcessInvoices_Draft.Enabled = False

                Me.ClearChanged()

            Else

                ButtonItemProcessInvoices_Assign.Enabled = _BillingUser IsNot Nothing AndAlso Not Me.CheckUserEntryChangedSetting AndAlso _BillingStatus IsNot Nothing AndAlso _BillingStatus.IsProcessed AndAlso _BillingStatus.IsAssigned = 0
                ButtonItemProcessInvoices_Assign.Image = AdvantageFramework.My.Resources.InvoiceNewImage

            End If

            ButtonItemProcessInvoices_Currency.Enabled = _BillingUser IsNot Nothing AndAlso Not Me.CheckUserEntryChangedSetting AndAlso _BillingStatus IsNot Nothing AndAlso _BillingStatus.IsProcessed AndAlso _BillingStatus.IsAssigned = 0

            ButtonItemProcessInvoices_Print.Enabled = _BillingUser IsNot Nothing AndAlso _BillingStatus IsNot Nothing AndAlso _BillingStatus.IsProcessed AndAlso _BillingStatus.IsAssigned = 1
            ButtonItemProcessInvoices_Finish.Enabled = _BillingUser IsNot Nothing AndAlso _BillingStatus IsNot Nothing AndAlso _BillingStatus.IsProcessed AndAlso _BillingStatus.IsAssigned = 1
            ButtonItemProcessInvoices_FinishDelete.Enabled = _BillingUser IsNot Nothing AndAlso _BillingStatus IsNot Nothing AndAlso _BillingStatus.IsProcessed AndAlso _BillingStatus.IsAssigned = 1

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
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.IsSelected.ToString Then

                    GridColumn.Visible = False

                End If

            Next

        End Sub
        Private Sub SelectAllRows()

            For Each ProductionSummary In DataGridViewForm_BillingSelection.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary).ToList

                ProductionSummary.BillingSelectionSelect = True

            Next

            DataGridViewForm_BillingSelection.CurrentView.RefreshData()
            DataGridViewForm_BillingSelection.SetUserEntryChanged()

            EnableOrDisableActions()

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal BillingCommandCenterID As Integer, ByVal ProductionSummaryList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary),
                                              ByRef IsBatchFinished As Boolean) As System.Windows.Forms.DialogResult

            'objects
            Dim BillingCommandCenterProductionBillingSelectionDialog As AdvantageFramework.Billing.Presentation.BillingCommandCenterProductionBillingSelectionDialog = Nothing

            BillingCommandCenterProductionBillingSelectionDialog = New AdvantageFramework.Billing.Presentation.BillingCommandCenterProductionBillingSelectionDialog(BillingCommandCenterID, ProductionSummaryList)

            ShowFormDialog = BillingCommandCenterProductionBillingSelectionDialog.ShowDialog()

            IsBatchFinished = BillingCommandCenterProductionBillingSelectionDialog.BatchFinished

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub BillingCommandCenterProductionBillingSelectionDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            ButtonItemBillingSelectionActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemBillingSelectionActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemProcessInvoices_Process.Image = AdvantageFramework.My.Resources.ProcessImage
            ButtonItemProcessInvoices_CoopSplits.Image = AdvantageFramework.My.Resources.InvoiceCoopImage
            ButtonItemProcessInvoices_Currency.Image = AdvantageFramework.My.Resources.CurrencyDollarImage
            ButtonItemProcessInvoices_Draft.Image = AdvantageFramework.My.Resources.PrintImage
            ButtonItemProcessInvoices_Assign.Image = AdvantageFramework.My.Resources.InvoiceNewImage
            ButtonItemProcessInvoices_Print.Image = AdvantageFramework.My.Resources.PrintImage
            ButtonItemProcessInvoices_Finish.Image = AdvantageFramework.My.Resources.FinishImage
            ButtonItemProcessInvoices_FinishDelete.Image = AdvantageFramework.My.Resources.FinishDeleteImage

            _ToolTipController = New DevExpress.Utils.ToolTipController()

            DataGridViewForm_BillingSelection.GridControl.ToolTipController = _ToolTipController
            DataGridViewForm_BillingSelection.ShowSelectDeselectAllButtons = True
            DataGridViewForm_BillingSelection.MultiSelect = False

            DateTimePickerBS_InvoiceDate.ByPassUserEntryChanged = False
            ComboBoxBS_PostingPeriod.ByPassUserEntryChanged = False

            DateTimePickerBS_InvoiceDate.SetRequired(True)
            ComboBoxBS_PostingPeriod.SetRequired(True)
            ComboBoxBS_PostingPeriod.DisableMouseWheel = True

            LoadBillingSelection()

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                _IsMultiCurrencyEnabled = AdvantageFramework.Database.Procedures.Agency.IsMultiCurrencyEnabled(DbContext)

            End Using

            ButtonItemProcessInvoices_Currency.Visible = _IsMultiCurrencyEnabled

            Me.ClearChanged()

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub BillingCommandCenterProductionBillingSelectionDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            Dim ProductionSummaryList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary) = Nothing

            ProductionSummaryList = DataGridViewForm_BillingSelection.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary).ToList

            If ProductionSummaryList.Where(Function(PS) PS.IsSelected = True).Any = False Then

                SelectAllRows()

            End If

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

            If e.SelectedControl Is DataGridViewForm_BillingSelection.GridControl Then

                Try

                    GridView = CType(DataGridViewForm_BillingSelection.GridControl.GetViewAt(e.ControlMousePosition), DevExpress.XtraGrid.Views.Grid.GridView)

                    If GridView IsNot Nothing Then

                        GridHitInfo = GridView.CalcHitInfo(e.ControlMousePosition)

                        If GridHitInfo.InRowCell AndAlso GridHitInfo.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.BillStatus.ToString Then

                            Try

                                RowID = DataGridViewForm_BillingSelection.CurrentView.GetRowCellValue(GridHitInfo.RowHandle, AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.BillStatus.ToString)

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

                                ToolTipText = DataGridViewForm_BillingSelection.CurrentView.GetRowCellValue(GridHitInfo.RowHandle, GridHitInfo.Column.FieldName)

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
        Private Sub ButtonItemBillingSelectionActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemBillingSelectionActions_Cancel.Click

            LoadBillingSelection()

        End Sub
        Private Sub ButtonItemBillingSelectionActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemBillingSelectionActions_Save.Click

            'objects
            Dim BillingCommandCenter As AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter = Nothing
            Dim ErrorMessage As String = ""
            Dim Result As Integer = Nothing
            Dim SetupIncomplete As Boolean = False

            If AdvantageFramework.BillingCommandCenter.ValidateBillingSelectionCriteria(Me.Session, DateTimePickerBS_InvoiceDate.GetValue, ComboBoxBS_PostingPeriod.GetSelectedValue, ErrorMessage) Then

                Me.ShowWaitForm("Saving...")

                DataGridViewForm_BillingSelection.CurrentView.CloseEditorForUpdating()

                _ProductionSummaryBillingSelectionList = DataGridViewForm_BillingSelection.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary).ToList()

                Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    BillingCommandCenter = AdvantageFramework.BillingCommandCenter.Database.Procedures.BillingCommandCenter.LoadByID(BCCDbContext, _BillingCommandCenterID)

                    If BillingCommandCenter IsNot Nothing Then

                        AdvantageFramework.BillingCommandCenter.UpdateBillingSelectionInvoiceDatePostPeriodCode(BCCDbContext, DateTimePickerBS_InvoiceDate.GetValue, ComboBoxBS_PostingPeriod.SelectedValue, BillingCommandCenter.BillingUser)

                        For Each ProductionSummary In _ProductionSummaryBillingSelectionList

                            If ProductionSummary.BillingUser IsNot Nothing AndAlso ProductionSummary.BillingSelectionSelect = False Then

                                If AdvantageFramework.BillingCommandCenter.BillingSelectUnmarkJobComponent(BCCDbContext, BillingCommandCenter.BillingUser, ProductionSummary.JobNumber, ProductionSummary.ComponentNumber, ProductionSummary.BillingSelectionResult) = 0 Then

                                    ProductionSummary.BillingUser = Nothing
                                    ProductionSummary.BillingSelectionSelect = False
                                    ProductionSummary.AmountSelectedforBilling = 0

                                End If

                            ElseIf ProductionSummary.BillingUser Is Nothing AndAlso ProductionSummary.BillingSelectionSelect Then

                                Result = AdvantageFramework.BillingCommandCenter.BillingSelectMarkJobComponent(BCCDbContext, BillingCommandCenter, DateTimePickerBS_InvoiceDate.GetValue, ComboBoxBS_PostingPeriod.SelectedValue, ProductionSummary.JobNumber, ProductionSummary.ComponentNumber, ProductionSummary.BillingSelectionResult)

                                If Result = 0 Then

                                    ProductionSummary.BillingUser = Mid(BillingCommandCenter.BillingUser, 1, BillingCommandCenter.BillingUser.Length - 2)
                                    ProductionSummary.BillingSelectionSelect = True
                                    ProductionSummary.AmountSelectedforBilling = BCCDbContext.Database.SqlQuery(Of Decimal)(String.Format("SELECT dbo.advfn_get_prod_sel_amt({0}, {1})", ProductionSummary.JobNumber, ProductionSummary.ComponentNumber)).FirstOrDefault

                                Else

                                    ProductionSummary.BillingSelectionSelect = False

                                    If Result = -7 Then

                                        SetupIncomplete = True

                                    End If

                                End If

                            End If

                        Next

                        AdvantageFramework.BillingCommandCenter.UpdateBillingSetInvoicesProcessedFlag(BCCDbContext, BillingCommandCenter.BillingUser, False)

                        ' update/delete BILLING row if no production/media jobs/orders are selected for billing
                        AdvantageFramework.BillingCommandCenter.DeleteBillingSelection(BCCDbContext, BillingCommandCenter.BillingUser)

                        LoadBillingSelection()

                    End If

                End Using

                If SetupIncomplete Then

                    AdvantageFramework.WinForm.MessageBox.Show("One or more records has not been selected for billing because billing setup has not been completed.")

                End If

                Me.CloseWaitForm()

            Else

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonItemProcessInvoices_Assign_Click(sender As Object, e As EventArgs) Handles ButtonItemProcessInvoices_Assign.Click

            Dim BillingCommandCenter As AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter = Nothing

            If AdvantageFramework.Billing.Presentation.OkayToAssignInvoices(Session, _BillingCommandCenterID, _BillingStatus, BillingCommandCenter) Then

                Me.ShowWaitForm()

                AdvantageFramework.Billing.Presentation.AssignInvoices(Me.Session, BillingCommandCenter, _BillingStatus)

                Me.CloseWaitForm()

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemProcessInvoices_CoopSplits_Click(sender As Object, e As EventArgs) Handles ButtonItemProcessInvoices_CoopSplits.Click

            AdvantageFramework.Billing.Presentation.BillingCommandCenterProductionCoopDialog.ShowDialog(_BillingUser, _BillingCommandCenterID)

        End Sub
        Private Sub ButtonItemProcessInvoices_Currency_Click(sender As Object, e As EventArgs) Handles ButtonItemProcessInvoices_Currency.Click

            AdvantageFramework.Billing.Presentation.BillingCommandCenterCurrencyDialog.ShowDialog(_BillingUser)

        End Sub
        Private Sub ButtonItemProcessInvoices_Draft_Click(sender As Object, e As EventArgs) Handles ButtonItemProcessInvoices_Draft.Click

            AdvantageFramework.Billing.Presentation.DraftInvoices(Me.Session, _BillingUser)

        End Sub
        Private Sub ButtonItemProcessInvoices_Finish_Click(sender As Object, e As EventArgs) Handles ButtonItemProcessInvoices_Finish.Click

            If AdvantageFramework.Billing.Presentation.FinishBatch(Me.Session, _BillingCommandCenterID) Then

                Me.DialogResult = Windows.Forms.DialogResult.OK

            End If

        End Sub
        Private Sub ButtonItemProcessInvoices_FinishDelete_Click(sender As Object, e As EventArgs) Handles ButtonItemProcessInvoices_FinishDelete.Click

            If AdvantageFramework.Billing.Presentation.FinishDeleteBatch(Me.Session, _BillingCommandCenterID) Then

                _BatchFinished = True
                Me.DialogResult = Windows.Forms.DialogResult.OK

            End If

        End Sub
        Private Sub ButtonItemProcessInvoices_Print_Click(sender As Object, e As EventArgs) Handles ButtonItemProcessInvoices_Print.Click

            AdvantageFramework.Billing.Presentation.PrintInvoices(Me.Session, _BillingUser)

        End Sub
        Private Sub ButtonItemProcessInvoices_Process_Click(sender As Object, e As EventArgs) Handles ButtonItemProcessInvoices_Process.Click

            Dim ErrorMessage As String = ""

            If AdvantageFramework.BillingCommandCenter.ValidateBillingSelectionCriteria(Me.Session, DateTimePickerBS_InvoiceDate.GetValue, ComboBoxBS_PostingPeriod.GetSelectedValue, ErrorMessage) Then

                If AdvantageFramework.Billing.Presentation.ProcessInvoices(Me.Session, _BillingCommandCenterID, _BillingStatus, False) Then

                    LoadBillingSelection()

                End If

                EnableOrDisableActions()

            Else

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ComboBoxBS_PostingPeriod_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxBS_PostingPeriod.SelectedValueChanged

            If Me.Session IsNot Nothing AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub DataGridViewForm_BillingSelection_CellValueChangingEvent(ByRef Saved As Boolean, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_BillingSelection.CellValueChangingEvent

            If e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.BillingSelectionSelect.ToString Then

                DataGridViewForm_BillingSelection.SetUserEntryChanged()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub DataGridViewForm_BillingSelection_DeselectAllEvent() Handles DataGridViewForm_BillingSelection.DeselectAllEvent

            For Each ProductionSummary In DataGridViewForm_BillingSelection.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary).ToList

                ProductionSummary.BillingSelectionSelect = False

            Next

            DataGridViewForm_BillingSelection.CurrentView.RefreshData()
            DataGridViewForm_BillingSelection.SetUserEntryChanged()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_BillingSelection_PopupMenuShowingEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles DataGridViewForm_BillingSelection.PopupMenuShowingEvent

            AdvantageFramework.Billing.Presentation.HideGroupByMenuOptions(e)

        End Sub
        Private Sub DataGridViewForm_BillingSelection_SelectAllEvent() Handles DataGridViewForm_BillingSelection.SelectAllEvent

            SelectAllRows()

        End Sub
        Private Sub DataGridViewForm_BillingSelection_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewForm_BillingSelection.ShowingEditorEvent

            If DataGridViewForm_BillingSelection.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.BillingSelectionSelect.ToString Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DateTimePickerBS_InvoiceDate_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerBS_InvoiceDate.ValueChanged

            If Me.Session IsNot Nothing AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                EnableOrDisableActions()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
