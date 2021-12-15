Namespace Media.Presentation

    Public Class MediaManagerReviewDialog

#Region " Constants "



#End Region

#Region " Enum "

        Private Enum CreateAPInvoices
            ByOrderLine
            GroupByVendor
        End Enum

#End Region

#Region " Variables "

        Private _SelectBy As Short = Nothing
        Private _MediaManagerSearchResults As IEnumerable(Of AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult) = Nothing
        Private _ParentForm As Windows.Forms.Form = Nothing
        Private WithEvents _ToolTipController As DevExpress.Utils.ToolTipController = Nothing
        Private _ObjectTypePropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
        Private _HasAccessToVendorRep As Boolean = False
        Private _CanUserUpdateVendorReps As Boolean = False
        Private _CanUserAddVendorReps As Boolean = False
        Private _CanUpdate As Boolean = False
        Private _VCCOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.VCCOrder) = Nothing
        Private _SubItemNumericInputCPL As AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput = Nothing
        Private _SubItemNumericInputCPM As AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput = Nothing
        Private _TimezoneOffset As AdvantageFramework.VCC.Classes.TimezoneOffset = Nothing
        Private _AdServingEnabled As Boolean = False
        Private _ImportWasLaunched As Boolean = False
        Private _AtLeastOneOrderFromWorksheet As Boolean = False
        Private _AtLeastOneFromWorksheetIsNotCable As Boolean = False
        Private _CanUserUpdateCostForBroadcast As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal SelectBy As Short, ByVal MediaManagerSearchResults As IEnumerable(Of AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult),
                        ByVal ParentForm As Windows.Forms.Form)

            ' This call is required by the designer.
            InitializeComponent()

            _SelectBy = SelectBy
            _MediaManagerSearchResults = MediaManagerSearchResults
            _ParentForm = ParentForm

        End Sub
        Private Sub SaveOrderDetailsGridLayout()

            Dim AFActiveFilterString As String = Nothing

            AFActiveFilterString = DataGridViewOrderDetails_OrderDetails.CurrentView.AFActiveFilterString

            AdvantageFramework.WinForm.Presentation.Controls.SaveDataGridViewLayout(Session, DataGridViewOrderDetails_OrderDetails, AdvantageFramework.Database.Entities.GridAdvantageType.MediaManagerMediaManagerReviewOrderDetail)

            DataGridViewOrderDetails_OrderDetails.CurrentView.AFActiveFilterString = AFActiveFilterString

        End Sub
        Private Sub SaveVCCDetailsGridLayout()

            Dim AFActiveFilterString As String = Nothing

            AFActiveFilterString = DataGridViewTopVCCDetails_VCCOrders.CurrentView.AFActiveFilterString

            AdvantageFramework.WinForm.Presentation.Controls.SaveDataGridViewLayout(Session, DataGridViewTopVCCDetails_VCCOrders, AdvantageFramework.Database.Entities.GridAdvantageType.MediaManagerMediaManagerReviewVCCOrderDetail)

            DataGridViewTopVCCDetails_VCCOrders.CurrentView.AFActiveFilterString = AFActiveFilterString

        End Sub
        Private Sub LoadOrderDetailsTab()

            Dim CampaignIDs As IEnumerable(Of Integer) = Nothing
            Dim ClientCodes As IEnumerable(Of String) = Nothing
            Dim ClientDivisionCodes As IEnumerable(Of String) = Nothing
            Dim ClientDivisionProductCodes As IEnumerable(Of String) = Nothing
            Dim JobNumbers As IEnumerable(Of Integer) = Nothing
            Dim JobNumberComponentNumbers As IEnumerable(Of String) = Nothing
            Dim OrderNumbers As IEnumerable(Of Integer) = Nothing
            Dim OrderLines As IEnumerable(Of String) = Nothing
            Dim OrderStatuses As IEnumerable(Of Short) = Nothing
            Dim AEDefaultEmployeeCodes As IEnumerable(Of String) = Nothing
            Dim AEJobEmployeeCodes As IEnumerable(Of String) = Nothing
            Dim VendorCodes As IEnumerable(Of String) = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim LayoutLoaded As Boolean = False
            Dim AFActiveFilterString As String = Nothing
            Dim DictionaryMediaManagerReviewDetail As System.Collections.Generic.Dictionary(Of String, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail) = Nothing
            Dim MediaManagerReviewDetail As AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail = Nothing
            Dim Keys As IEnumerable(Of String) = Nothing
            Dim BuyerEmpCodes As IEnumerable(Of String) = Nothing

            Me.ShowWaitForm()

            Select Case _SelectBy

                Case MediaManagerSelectBy.Buyer

                    BuyerEmpCodes = _MediaManagerSearchResults.Select(Function(Entity) Entity.EmployeeCode).ToList

                Case MediaManagerSelectBy.Campaign

                    CampaignIDs = _MediaManagerSearchResults.Where(Function(Entity) Entity.CampaignID.HasValue).Select(Function(Entity) Entity.CampaignID.Value).ToList

                Case MediaManagerSelectBy.Client

                    ClientCodes = _MediaManagerSearchResults.Select(Function(Entity) Entity.ClientCode).ToList

                Case MediaManagerSelectBy.ClientDivision

                    ClientDivisionCodes = _MediaManagerSearchResults.Select(Function(Entity) Entity.ClientCode + "|" + Entity.DivisionCode).ToList

                Case MediaManagerSelectBy.ClientDivisionProduct

                    ClientDivisionProductCodes = _MediaManagerSearchResults.Select(Function(Entity) Entity.ClientCode + "|" + Entity.DivisionCode + "|" + Entity.ProductCode).ToList

                Case MediaManagerSelectBy.Job

                    JobNumbers = _MediaManagerSearchResults.Select(Function(Entity) Entity.JobNumber.Value).ToList

                Case MediaManagerSelectBy.JobComponent

                    JobNumberComponentNumbers = _MediaManagerSearchResults.Select(Function(Entity) CStr(Entity.JobNumber.Value) + "|" + CStr(Entity.JobComponentNumber.Value)).ToList

                Case MediaManagerSelectBy.Order

                    OrderNumbers = _MediaManagerSearchResults.Select(Function(Entity) Entity.OrderNumber.Value).ToList

                Case MediaManagerSelectBy.OrderStatus

                    OrderStatuses = _MediaManagerSearchResults.Select(Function(Entity) Entity.OrderStatus.GetValueOrDefault(0)).ToList

                Case MediaManagerSelectBy.AccountExecutiveDefault

                    AEDefaultEmployeeCodes = _MediaManagerSearchResults.Select(Function(Entity) Entity.EmployeeCode).ToList

                Case MediaManagerSelectBy.AccountExecutiveJob

                    AEJobEmployeeCodes = _MediaManagerSearchResults.Select(Function(Entity) Entity.EmployeeCode).ToList

                Case MediaManagerSelectBy.Vendor

                    VendorCodes = _MediaManagerSearchResults.Select(Function(Entity) Entity.VendorCode).ToList

                Case MediaManagerSelectBy.LastFour

                    OrderNumbers = _MediaManagerSearchResults.Select(Function(Entity) Entity.OrderNumber.Value).ToList

            End Select

            BindingSource = DataGridViewOrderDetails_OrderDetails.DataSource

            If BindingSource IsNot Nothing AndAlso BindingSource.DataSource IsNot Nothing Then

                AFActiveFilterString = DataGridViewOrderDetails_OrderDetails.CurrentView.AFActiveFilterString

                DictionaryMediaManagerReviewDetail = DataGridViewOrderDetails_OrderDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).ToDictionary(Function(MMRD) MMRD.OrderNumberLineNumber, Function(MMRD) MMRD)

                SaveOrderDetailsGridLayout()

            End If

            DataGridViewOrderDetails_OrderDetails.SetBookmarkColumnIndex(-1)
            DataGridViewOrderDetails_OrderDetails.ClearGridCustomization()
            DataGridViewOrderDetails_OrderDetails.CurrentView.ClearDisabledRows()
            DataGridViewOrderDetails_OrderDetails.ClearDatasource(New Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail))
            DataGridViewOrderDetails_OrderDetails.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True

            ButtonItemOrders_CreateRevision.Checked = False

            LayoutLoaded = AdvantageFramework.WinForm.Presentation.Controls.LoadDataGridViewLayout(Session, DataGridViewOrderDetails_OrderDetails, Database.Entities.GridAdvantageType.MediaManagerMediaManagerReviewOrderDetail)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DataGridViewOrderDetails_OrderDetails.DataSource = AdvantageFramework.MediaManager.LoadMediaManagerReviewDetails(DbContext, CampaignIDs, ClientCodes, ClientDivisionCodes, ClientDivisionProductCodes,
                                                                                                JobNumbers, JobNumberComponentNumbers, OrderNumbers, OrderLines, OrderStatuses, AEDefaultEmployeeCodes, AEJobEmployeeCodes, False, VendorCodes, False, BuyerEmpCodes, False, False)

            End Using

            If Not LayoutLoaded Then

                SetColumnDefaultVisibility()

                DataGridViewOrderDetails_OrderDetails.CurrentView.ClearSorting()
                DataGridViewOrderDetails_OrderDetails.CurrentView.BeginSort()
                DataGridViewOrderDetails_OrderDetails.CurrentView.Columns(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.OrderNumber.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Descending
                DataGridViewOrderDetails_OrderDetails.CurrentView.Columns(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.LineNumber.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                DataGridViewOrderDetails_OrderDetails.CurrentView.EndSort()
                DataGridViewOrderDetails_OrderDetails.CurrentView.BestFitColumns()

            Else

                AdvantageFramework.WinForm.Presentation.Controls.SortGridViewBySortedColumns(DataGridViewOrderDetails_OrderDetails)

            End If

            DataGridViewOrderDetails_OrderDetails.OptionsView.ShowGroupPanel = False

            If DataGridViewOrderDetails_OrderDetails.CurrentView.Columns(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.ForceRevision.ToString) IsNot Nothing Then

                DataGridViewOrderDetails_OrderDetails.CurrentView.Columns(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.ForceRevision.ToString).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None
                DataGridViewOrderDetails_OrderDetails.CurrentView.Columns(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.ForceRevision.ToString).Visible = False
                DataGridViewOrderDetails_OrderDetails.CurrentView.Columns(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.ForceRevision.ToString).OptionsColumn.ShowInCustomizationForm = False

            End If

            DataGridViewOrderDetails_OrderDetails.CurrentView.AFActiveFilterString = AFActiveFilterString

            If DictionaryMediaManagerReviewDetail IsNot Nothing AndAlso DictionaryMediaManagerReviewDetail.Count > 0 Then

                DataGridViewOrderDetails_OrderDetails.CurrentView.BeginSelection()

                DataGridViewOrderDetails_OrderDetails.CurrentView.ClearSelection()

                Keys = (From Entity In DictionaryMediaManagerReviewDetail
                        Select Entity.Key).ToArray

                For Each RowsRowHandlesAndDataBoundItem In DataGridViewOrderDetails_OrderDetails.GetAllRowsRowHandlesAndDataBoundItems

                    If Keys.Contains(DirectCast(RowsRowHandlesAndDataBoundItem.Value, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).OrderNumberLineNumber) Then

                        DataGridViewOrderDetails_OrderDetails.CurrentView.SelectRow(RowsRowHandlesAndDataBoundItem.Key)

                        DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedRowHandle = RowsRowHandlesAndDataBoundItem.Key

                    End If

                Next

                DataGridViewOrderDetails_OrderDetails.CurrentView.EndSelection()

            End If

            DataGridViewOrderDetails_OrderDetails.CurrentView.OptionsCustomization.AllowColumnMoving = True

            DataGridViewOrderDetails_OrderDetails.OptionsMenu.EnableColumnMenu = True

            For RowHandle As Integer = 0 To DataGridViewOrderDetails_OrderDetails.CurrentView.RowCount - 1

                MediaManagerReviewDetail = DirectCast(DataGridViewOrderDetails_OrderDetails.CurrentView.GetRow(RowHandle), AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail)

                MediaManagerReviewDetail.ValidateEntityProperty(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.JobMediaBillDateColumnUpdated.ToString, True, False)

                If MediaManagerReviewDetail.IsOrderClosed OrElse MediaManagerReviewDetail.Cancelled OrElse Not String.IsNullOrWhiteSpace(MediaManagerReviewDetail.BillingUser) Then

                    DataGridViewOrderDetails_OrderDetails.CurrentView.DisableRow(DataGridViewOrderDetails_OrderDetails.CurrentView.GetDataSourceRowIndex(RowHandle), AdvantageFramework.WinForm.Presentation.Controls.Classes.DisabledRow.RowType.Readonly)

                End If

            Next

            Me.CloseWaitForm()

            TabItemReviewItems_OrderDetails.Tag = True

            If Not DataGridViewOrderDetails_OrderDetails.HasRows Then

                TabControlForm_ReviewItems.SelectedTab = TabItemReviewItems_PurchaseOrderDetails

            End If

        End Sub
        Private Sub EnableOrDisableActions()

            Dim IsOneDistinctOrderSelected As Boolean = False
            Dim Left As Integer = 0
            Dim BroadcastSelectedCannotUpdate As Boolean = False

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                RibbonControlForm_MainRibbon.SuspendLayout()

                RibbonBarOptions_GridOptionsVCCDetails.Visible = False
                RibbonBarOptions_GridOptionsOrderDetails.Visible = False
                RibbonBarOptions_MediaPlan.Visible = False
                RibbonBarOptions_SummaryResults.Visible = False
                RibbonBarOptions_Filter.Visible = False
                RibbonBarOptions_Documents.Visible = False
                RibbonBarOptions_BillingApproval.Visible = False
                RibbonBarOptions_VendorReps.Visible = False
                RibbonBarOptions_Vendor.Visible = False
                RibbonBarOptions_VendorPayments.Visible = False
                RibbonBarOptions_VendorInvoices.Visible = False
                RibbonBarOptions_Orders.Visible = False

                ButtonItemActions_Export.Visible = TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_OrderDetails) OrElse
                                        TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_VCCDetails) OrElse
                                        (TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_BillingInvoices) AndAlso MediaBillingHistoryControlBillingInvoices_BillingInvoices.CanExportSelectedTab) OrElse
                                        TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_PurchaseOrderDetails)
                ButtonItemActions_ExportXML.Visible = TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_OrderDetails)
                ButtonItemActions_ExportXMLAsNew.Visible = TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_OrderDetails)
                ButtonItemActions_ExportXML.Enabled = _AtLeastOneOrderFromWorksheet
                ButtonItemActions_ExportXMLAsNew.Enabled = _AtLeastOneFromWorksheetIsNotCable

                ButtonItemActions_Save.Visible = TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_OrderDetails) OrElse
                                       TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_OrderComments) OrElse
                                       TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_LineComments) OrElse
                                       TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_VCCDetails) OrElse
                                       TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_Documents) OrElse
                                       TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_VendorCollectedDetails)

                ButtonItemActions_Cancel.Visible = ButtonItemActions_Save.Visible

                ButtonItemActions_SendReminders.Visible = TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_VCCDetails)
                ButtonItemActions_AutoFill.Visible = TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_OrderDetails) OrElse
                    TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_OrderComments) OrElse TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_LineComments) OrElse
                    TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_VCCDetails)
                ButtonItemActions_FollowUp.Visible = TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_VCCDetails)
                ButtonItemOrders_AdServing.Visible = _AdServingEnabled AndAlso TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_OrderDetails)

                ButtonItemActions_Save.Enabled = DataGridViewLineComments_LineComments.UserEntryChanged OrElse DataGridViewOrderComments_OrderComments.UserEntryChanged OrElse
                            DataGridViewOrderDetails_OrderDetails.UserEntryChanged OrElse DataGridViewTopVCCDetails_VCCOrders.UserEntryChanged OrElse
                            DocumentManagerControlDocuments_Documents.DataGridViewForm_Documents.UserEntryChanged OrElse DataGridViewVendorCollectedDetails_VendorCollectedDetails.UserEntryChanged

                ButtonItemActions_Cancel.Enabled = ButtonItemActions_Save.Enabled
                ButtonItemActions_Refresh.Enabled = Not ButtonItemActions_Save.Enabled

                ButtonItemOrders_GenerateOrders.Enabled = (TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_OrderDetails) AndAlso Not ButtonItemActions_Save.Enabled) OrElse
                                                            (TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_PurchaseOrderDetails) AndAlso Not ButtonItemActions_Save.Enabled AndAlso
                                                             DataGridViewPODetails_PODetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.MediaManager.MediaManagerPODetail).Where(Function(POD) Not String.IsNullOrWhiteSpace(POD.VendorContactEmail)).Any)

                If TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_OrderDetails) Then

                    ButtonItemVendorPayments_CreateVCC.Enabled = Not ButtonItemActions_Save.Enabled AndAlso
                        DataGridViewOrderDetails_OrderDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).Where(Function(MMRD) Not MMRD.Cancelled AndAlso
                        MMRD.VCCCardID Is Nothing AndAlso MMRD.PaymentMethod <> "Check" AndAlso MMRD.IsOrderClosed = False AndAlso MMRD.Quote = False).Any

                ElseIf TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_PurchaseOrderDetails) Then

                    ButtonItemVendorPayments_CreateVCC.Enabled = Not ButtonItemActions_Save.Enabled AndAlso
                        DataGridViewPODetails_PODetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.MediaManager.MediaManagerPODetail).Where(Function(MMPOD) MMPOD.VCCCardPOID Is Nothing AndAlso
                        MMPOD.PaymentMethod <> "Check").Any

                End If

                If DataGridViewOrderDetails_OrderDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).Where(Function(MMRD) {"R", "T"}.Contains(MMRD.MediaFrom.Substring(0, 1))).Any AndAlso
                        _CanUserUpdateCostForBroadcast = False Then

                    BroadcastSelectedCannotUpdate = True

                End If

                ButtonItemOrders_UpdateCost.Enabled = Not ButtonItemActions_Save.Enabled AndAlso
                    DataGridViewOrderDetails_OrderDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).Where(Function(MMRD) Not MMRD.Cancelled AndAlso
                    String.IsNullOrWhiteSpace(MMRD.BillingUser) AndAlso MMRD.IsOrderClosed = False).Any AndAlso BroadcastSelectedCannotUpdate = False

                ButtonItemVendorInvoices_CreateInvoices.Enabled = Not ButtonItemActions_Save.Enabled AndAlso
                    DataGridViewOrderDetails_OrderDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).Where(Function(MMRD) MMRD.BillType <> "Comm Only" AndAlso
                        MMRD.ActualAmountPosted = 0 AndAlso MMRD.Quote = False AndAlso MMRD.Cancelled = False AndAlso MMRD.IsOrderClosed = False).Any

                ButtonItemOrders_WriteUpDown.Enabled = Not ButtonItemActions_Save.Enabled AndAlso
                    DataGridViewOrderDetails_OrderDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).Where(Function(MMRD) Not MMRD.Cancelled AndAlso
                        String.IsNullOrWhiteSpace(MMRD.BillingUser) AndAlso MMRD.BillableAmount <> MMRD.BilledAmount AndAlso MMRD.IsOrderClosed = False).Any

                ButtonItemOrders_CreateRevision.Enabled = DataGridViewOrderDetails_OrderDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).Where(Function(MMRD) Not MMRD.Cancelled).Any

                If TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_OrderDetails) AndAlso
                         (From MMRD In DataGridViewOrderDetails_OrderDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail)
                          Where Not MMRD.Cancelled AndAlso String.IsNullOrWhiteSpace(MMRD.BillingUser) AndAlso MMRD.IsOrderClosed = False
                          Select MMRD.MediaFrom).Distinct.Count = 1 Then

                    ButtonItemActions_AutoFill.Enabled = True

                ElseIf TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_OrderComments) AndAlso
                     (From MMRD In DataGridViewOrderComments_OrderComments.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerOrderComment)
                      Select MMRD.MediaType).Distinct.Count = 1 Then

                    ButtonItemActions_AutoFill.Enabled = True

                ElseIf TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_LineComments) AndAlso
                     (From MMRD In DataGridViewLineComments_LineComments.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerOrderLineComment)
                      Select MMRD.MediaType).Distinct.Count = 1 Then

                    ButtonItemActions_AutoFill.Enabled = True

                ElseIf TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_VCCDetails) AndAlso DataGridViewTopVCCDetails_VCCOrders.HasASelectedRow Then

                    ButtonItemActions_AutoFill.Enabled = True

                Else

                    ButtonItemActions_AutoFill.Enabled = False

                End If

                ButtonItemOrders_ProcessControl.Enabled = Not ButtonItemActions_Save.Enabled

                ButtonItemActions_FollowUp.Enabled = DataGridViewTopVCCDetails_VCCOrders.HasASelectedRow

                ButtonItemVendorInvoices_ApproveInvoices.Enabled = DataGridViewOrderDetails_OrderDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).Where(Function(MMRD) MMRD.APExists).Any

                ButtonItemOrders_AdServing.Enabled = ButtonItemOrders_AdServing.Visible AndAlso
                    DataGridViewOrderDetails_OrderDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).Where(Function(MMRD) MMRD.MediaFrom = "Internet" AndAlso
                                                                                                                                                                                            MMRD.Quote = False AndAlso
                                                                                                                                                                                            MMRD.DCProfileID.HasValue).Select(Function(MMRD) MMRD.DCProfileID.Value).Distinct.Count = 1

                ButtonItemMediaPlan_Actualize.Enabled = DataGridViewOrderDetails_OrderDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).Where(Function(MMRD) MMRD.MediaPlanDetailID IsNot Nothing AndAlso
                                                                                                                                                                                                                 {"I", "M", "N", "O"}.Contains(MMRD.MediaFrom.Substring(0, 1))).Select(Function(MMRD) MMRD.MediaPlanDetailID).Distinct.Count = 1

                RibbonBarOptions_Actions.ResetCachedContentSize()
                RibbonBarOptions_Actions.Refresh()
                RibbonBarOptions_Actions.Width = RibbonBarOptions_Actions.GetAutoSizeWidth
                RibbonBarOptions_Actions.Refresh()

                Left = RibbonBarOptions_Actions.Left + RibbonBarOptions_Actions.Width

                RibbonBarOptions_Orders.Visible = TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_OrderDetails) OrElse TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_PurchaseOrderDetails)

                If RibbonBarOptions_Orders.Visible Then

                    ButtonItemOrders_CreateRevision.Visible = TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_OrderDetails)
                    ButtonItemOrders_AdServing.Visible = TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_OrderDetails)
                    ButtonItemOrders_UpdateCost.Visible = TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_OrderDetails)
                    ButtonItemOrders_WriteUpDown.Visible = TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_OrderDetails)
                    ButtonItemOrders_ProcessControl.Visible = TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_OrderDetails)

                    RibbonBarOptions_Orders.ResetCachedContentSize()
                    RibbonBarOptions_Orders.Refresh()
                    RibbonBarOptions_Orders.Width = RibbonBarOptions_Orders.GetAutoSizeWidth
                    RibbonBarOptions_Orders.Refresh()

                    RibbonBarOptions_Orders.Left = Left
                    Left = Left + RibbonBarOptions_Orders.Width

                End If

                RibbonBarOptions_VendorInvoices.Visible = TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_OrderDetails)

                If RibbonBarOptions_VendorInvoices.Visible Then

                    RibbonBarOptions_VendorInvoices.Left = Left
                    Left = Left + RibbonBarOptions_VendorInvoices.Width

                End If

                RibbonBarOptions_VendorPayments.Visible = TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_OrderDetails) OrElse TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_PurchaseOrderDetails)

                If RibbonBarOptions_VendorPayments.Visible Then

                    RibbonBarOptions_VendorPayments.Left = Left
                    Left = Left + RibbonBarOptions_VendorPayments.Width

                End If

                RibbonBarOptions_Vendor.Visible = TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_VCCDetails) OrElse TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_OrderDetails) OrElse
                    TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_APInvoiceDetail) OrElse TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_VendorReps) OrElse
                    TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_PurchaseOrderDetails)

                If RibbonBarOptions_Vendor.Visible Then

                    RibbonBarOptions_Vendor.Left = Left
                    Left = Left + RibbonBarOptions_Vendor.Width

                End If

                RibbonBarOptions_VendorReps.Visible = TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_VendorReps)

                If RibbonBarOptions_VendorReps.Visible Then

                    RibbonBarOptions_VendorReps.Left = Left
                    Left = Left + RibbonBarOptions_VendorReps.Width

                End If

                RibbonBarOptions_BillingApproval.Visible = TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_OrderDetails)

                If RibbonBarOptions_BillingApproval.Visible Then

                    RibbonBarOptions_BillingApproval.Left = Left
                    Left = Left + RibbonBarOptions_BillingApproval.Width

                End If

                RibbonBarOptions_Documents.Visible = TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_Documents) OrElse
                    (TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_BillingInvoices) AndAlso MediaBillingHistoryControlBillingInvoices_BillingInvoices.SelectedTabIsDocumentsTab) OrElse
                    (TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_APInvoiceDetail) AndAlso ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.IsDocumentsTabSelected)

                If RibbonBarOptions_Documents.Visible Then

                    RibbonBarOptions_Documents.Left = Left
                    Left = Left + RibbonBarOptions_Documents.Width

                End If

                RibbonBarOptions_Filter.Visible = TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_BillingInvoices) AndAlso MediaBillingHistoryControlBillingInvoices_BillingInvoices.SelectedTabIsDocumentsTab

                If RibbonBarOptions_Filter.Visible Then

                    RibbonBarOptions_Filter.Left = Left
                    Left = Left + RibbonBarOptions_Filter.Width

                End If

                RibbonBarOptions_SummaryResults.Visible = TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_VCCDetails)

                If RibbonBarOptions_SummaryResults.Visible Then

                    RibbonBarOptions_SummaryResults.ResetCachedContentSize()
                    RibbonBarOptions_SummaryResults.Refresh()
                    RibbonBarOptions_SummaryResults.Width = RibbonBarOptions_SummaryResults.GetAutoSizeWidth
                    RibbonBarOptions_SummaryResults.Refresh()

                    RibbonBarOptions_SummaryResults.Left = Left
                    Left = Left + RibbonBarOptions_SummaryResults.Width

                End If

                RibbonBarOptions_MediaPlan.Visible = TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_OrderDetails)

                If RibbonBarOptions_MediaPlan.Visible Then

                    RibbonBarOptions_MediaPlan.ResetCachedContentSize()
                    RibbonBarOptions_MediaPlan.Refresh()
                    RibbonBarOptions_MediaPlan.Width = RibbonBarOptions_MediaPlan.GetAutoSizeWidth
                    RibbonBarOptions_MediaPlan.Refresh()

                    RibbonBarOptions_MediaPlan.Left = Left
                    Left = Left + RibbonBarOptions_MediaPlan.Width

                End If

                RibbonBarOptions_GridOptionsOrderDetails.Visible = TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_OrderDetails)

                If RibbonBarOptions_GridOptionsOrderDetails.Visible Then

                    RibbonBarOptions_GridOptionsOrderDetails.Left = Left
                    Left = Left + RibbonBarOptions_GridOptionsOrderDetails.Width

                End If

                RibbonBarOptions_GridOptionsVCCDetails.Visible = TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_VCCDetails)

                If RibbonBarOptions_GridOptionsVCCDetails.Visible Then

                    RibbonBarOptions_GridOptionsVCCDetails.Left = Left
                    Left = Left + RibbonBarOptions_GridOptionsVCCDetails.Width

                End If

                ButtonItemDocuments_UploadOrder.Visible = TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_Documents)
                ButtonItemDocuments_UploadCampaign.Visible = TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_Documents)
                ButtonItemDocuments_UploadJob.Visible = TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_Documents)
                ButtonItemDocuments_UploadJobComponent.Visible = TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_Documents)
                ButtonItemDocuments_Upload.Visible = TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_APInvoiceDetail) AndAlso ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.IsDocumentsTabSelected

                ButtonItemVendor_Edit.Enabled = (TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_VCCDetails) AndAlso DataGridViewTopVCCDetails_VCCOrders.HasASelectedRow) OrElse
                                                    (TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_OrderDetails) AndAlso DataGridViewOrderDetails_OrderDetails.HasASelectedRow) OrElse
                                                    (TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_APInvoiceDetail) AndAlso ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.HasASelectedRow) OrElse
                                                    (TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_VendorReps) AndAlso DataGridViewVendorReps_VendorReps.HasASelectedRow) OrElse
                                                    (TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_PurchaseOrderDetails) AndAlso DataGridViewPODetails_PODetails.HasASelectedRow)

                ButtonItemDocuments_UploadOrder.Enabled = TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_Documents) AndAlso DocumentManagerControlDocuments_Documents.CanUpload
                ButtonItemDocuments_UploadJob.Enabled = TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_Documents) AndAlso DocumentManagerControlDocuments_Documents.CanUpload AndAlso
                        DirectCast(DataGridViewOrderDetails_OrderDetails.CurrentView.GetRow(DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedRowHandle), AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).JobNumber.HasValue
                ButtonItemDocuments_UploadJobComponent.Enabled = TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_Documents) AndAlso DocumentManagerControlDocuments_Documents.CanUpload AndAlso
                        DirectCast(DataGridViewOrderDetails_OrderDetails.CurrentView.GetRow(DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedRowHandle), AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).JobComponentNumber.HasValue
                ButtonItemDocuments_UploadCampaign.Enabled = TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_Documents) AndAlso DocumentManagerControlDocuments_Documents.CanUpload AndAlso
                        DirectCast(DataGridViewOrderDetails_OrderDetails.CurrentView.GetRow(DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedRowHandle), AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).CampaignID.HasValue

                ButtonItemDocuments_Upload.Enabled = ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.IsDocumentsTabSelected AndAlso ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.CanUpload AndAlso
                                        ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.HasASelectedRow

                If TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_Documents) Then

                    ButtonItemDocuments_Download.Enabled = If(DocumentManagerControlDocuments_Documents.HasOnlyOneSelectedDocument, Not DocumentManagerControlDocuments_Documents.IsSelectedDocumentAURL, DocumentManagerControlDocuments_Documents.HasASelectedDocument)
                    ButtonItemDocuments_OpenURL.Enabled = If(DocumentManagerControlDocuments_Documents.HasOnlyOneSelectedDocument, DocumentManagerControlDocuments_Documents.IsSelectedDocumentAURL, False)

                ElseIf TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_BillingInvoices) Then

                    ButtonItemDocuments_Download.Enabled = If(MediaBillingHistoryControlBillingInvoices_BillingInvoices.DocumentManagerControlDocuments_InvoiceDocuments.HasOnlyOneSelectedDocument, Not MediaBillingHistoryControlBillingInvoices_BillingInvoices.DocumentManagerControlDocuments_InvoiceDocuments.IsSelectedDocumentAURL, MediaBillingHistoryControlBillingInvoices_BillingInvoices.DocumentManagerControlDocuments_InvoiceDocuments.HasASelectedDocument)
                    ButtonItemDocuments_OpenURL.Enabled = If(MediaBillingHistoryControlBillingInvoices_BillingInvoices.DocumentManagerControlDocuments_InvoiceDocuments.HasOnlyOneSelectedDocument, MediaBillingHistoryControlBillingInvoices_BillingInvoices.DocumentManagerControlDocuments_InvoiceDocuments.IsSelectedDocumentAURL, False)

                ElseIf TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_APInvoiceDetail) Then

                    If ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.IsDocumentsTabSelected Then

                        ButtonItemDocuments_Download.Enabled = If(ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.HasOnlyOneSelectedDocument, Not ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.IsSelectedDocumentAURL, ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.HasASelectedDocument)
                        ButtonItemDocuments_OpenURL.Enabled = If(ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.HasOnlyOneSelectedDocument, ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.IsSelectedDocumentAURL, False)

                    End If

                Else

                    ButtonItemDocuments_Download.Enabled = False
                    ButtonItemDocuments_OpenURL.Enabled = False

                End If

                ButtonItemBillingApproval_Approve.Enabled = DataGridViewOrderDetails_OrderDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).Where(Function(MMRD) MMRD.HasBillingApprovalStatus = False).Any
                ButtonItemBillingApproval_Unapprove.Enabled = DataGridViewOrderDetails_OrderDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).Where(Function(MMRD) MMRD.HasBillingApprovalStatus = True).Any

                ButtonItemVendorReps_Add.Enabled = _CanUserAddVendorReps
                ButtonItemVendorReps_Edit.Enabled = _HasAccessToVendorRep AndAlso DataGridViewVendorReps_VendorReps.HasOnlyOneSelectedRow
                ButtonItemVendorReps_Delete.Enabled = _CanUserUpdateVendorReps AndAlso DataGridViewVendorReps_VendorReps.HasOnlyOneSelectedRow

                IsOneDistinctOrderSelected = (From MMRD In DataGridViewOrderDetails_OrderDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail)
                                              Select MMRD.OrderNumber).Distinct.Count = 1

                TabItemReviewItems_OrderStatus.Visible = IsOneDistinctOrderSelected

                TabItemReviewItems_VendorCollectedDetails.Visible = DataGridViewOrderDetails_OrderDetails.HasASelectedRow

                TabItemReviewItems_APInvoiceDetail.Visible = IsOneDistinctOrderSelected

                TabItemReviewItems_BillingInvoices.Visible = IsOneDistinctOrderSelected

                TabItemReviewItems_VendorReps.Visible = IsOneDistinctOrderSelected

                TabItemReviewItems_Documents.Visible = DataGridViewOrderDetails_OrderDetails.HasOnlyOneSelectedRow

                RibbonBarOptions_Documents.ResetCachedContentSize()
                RibbonBarOptions_Documents.Refresh()
                RibbonBarOptions_Documents.Width = RibbonBarOptions_Documents.GetAutoSizeWidth
                RibbonBarOptions_Documents.Refresh()

                RibbonControlForm_MainRibbon.ResumeLayout(True)


            End If

        End Sub
        Private Sub SetColumnDefaultVisibility()

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            For Each GridColumn In DataGridViewOrderDetails_OrderDetails.CurrentView.Columns

                If GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.AccountExecutiveJob.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.OfficeCode.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.OfficeDescription.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.DivisionCode.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.DivisionName.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.ProductCode.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.ProductDescription.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.CampaignCode.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.CampaignID.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.CampaignName.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.OrderProcessControl.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.Quote.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.NetGross.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.SalesClassCode.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.SalesClassDescription.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.LinkID.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.MarketCode.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.MarketDescription.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.LinkLineID.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.RevisionNumber.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.Cancelled.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.JobNumber.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.JobComponentNumber.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.Headline.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.Material.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.AdNumber.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.AdSizeCode.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.AdSizeDescription.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.MaterialDate.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.DateToBill.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.Spots.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.BillType.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.NonResaleTax.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.NewspaperCostRate.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.InternetCostType.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.Rate.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.ActualImpressions.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.GuaranteedImpressions.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.ProjectedImpressions.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.JobDescription.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.JobCompDescription.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.ExtendedCloseDate.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.ExtendedMaterialDate.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.InternetType.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.InternetPlacement1.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.InternetPlacement2.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.InternetURL.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.InternetTargetAudience.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.Issue.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.ProductionSize.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.MagazineCirculationQTY.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.NewspaperSection.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.NewspaperCirculationQTY.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.NewspaperCirculation.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.NewspaperColumns.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.NewspaperInches.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.OutdoorType.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.OutdoorLocation.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.OutdoorCopyArea.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.BroadcastStartTime.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.BroadcastEndTime.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.BroadcastProgramming.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.BroadcastNetworkCode.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.BroadcastLength.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.BroadcastRemarks.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.BroadcastDaysofWeek.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.BroadcastSpotsbyWeek.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.BroadcastDatesbyWeek.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.GrossAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.MarkupPercent.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.RebatePercent.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.BillingUser.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.PaymentMethod.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.VendorCollectedQuote.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.APPostedVariance.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.VendorCollectedVariance.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.VCCClearedAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.VCCClearedVariance.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.AdjustedMarkupPercent.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.MarginPercent.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.JobOrMediaDateToBill.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.CampaignStartDate.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.CampaignEndDate.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.AdServerName.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.AdServerPlacementID.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.AdServerPackageID.ToString Then

                    GridColumn.Visible = False

                ElseIf GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.ForceRevision.ToString Then

                    GridColumn.Visible = False
                    GridColumn.OptionsColumn.ShowInCustomizationForm = False

                End If

            Next

        End Sub
        Private Sub SetVCCColumnDefaultVisibility()

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            For Each GridColumn In DataGridViewTopVCCDetails_VCCOrders.CurrentView.Columns

                If GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.VCCOrder.Properties.OrderDescription.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.VCCOrder.Properties.VendorCollected.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.VCCOrder.Properties.CardNumberCVCCode.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.VCCOrder.Properties.NumberOfUses.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.VCCOrder.Properties.ExpirationDate.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.VCCOrder.Properties.Reviewed.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.VCCOrder.Properties.Resolved.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.VCCOrder.Properties.FollowupDate.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.VCCOrder.Properties.LastRefreshedDate.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.VCCOrder.Properties.DateToBill.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.VCCOrder.Properties.LastFour.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.VCCOrder.Properties.JobOrMediaDateToBill.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.VCCOrder.Properties.DeclinedDate.ToString Then

                    GridColumn.Visible = False

                ElseIf GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.VCCOrder.Properties.OrderNumber.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.VCCOrder.Properties.LineNumber.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.VCCOrder.Properties.VendorCode.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.VCCOrder.Properties.VendorCost.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.VCCOrder.Properties.CardAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.VCCOrder.Properties.CardStatus.ToString Then

                    GridColumn.Visible = True
                    GridColumn.OptionsColumn.ShowInCustomizationForm = False

                End If

            Next

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True
            Dim ErrorMessage As String = ""

            If AdvantageFramework.WinForm.Presentation.Controls.CheckUserEntryChangedSetting(Me) Then

                If _CanUpdate AndAlso AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.ShowWaitForm("Saving...")

                    If Save(ErrorMessage) = False Then

                        IsOkay = False
                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    End If

                    Me.CloseWaitForm()

                Else

                    TabControlForm_ReviewItems.SelectedTab.Tag = False

                    AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function
        Private Function Save(ByRef ErrorMessage As String) As Boolean

            'objects
            Dim VCCOrderList As Generic.List(Of AdvantageFramework.MediaManager.Classes.VCCOrder) = Nothing
            Dim APIVCCOrderList As Generic.List(Of AdvantageFramework.MediaManager.Classes.VCCOrder) = Nothing
            Dim VCCCardList As Generic.List(Of AdvantageFramework.Database.Entities.VCCCard) = Nothing
            Dim MediaManagerOrderLineCommentList As Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerOrderLineComment) = Nothing
            Dim MediaManagerOrderCommentList As Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerOrderComment) = Nothing
            Dim Saved As Boolean = False
            Dim VendorCollectedDetailList As Generic.List(Of AdvantageFramework.MediaManager.Classes.VendorCollectedDetail) = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Try

                    If TabControlForm_ReviewItems.SelectedTab Is TabItemReviewItems_VCCDetails Then

                        Me.ShowWaitForm("Saving...")

                        DataGridViewTopVCCDetails_VCCOrders.CurrentView.CloseEditorForUpdating()

                        VCCOrderList = DataGridViewTopVCCDetails_VCCOrders.GetAllModifiedRows.OfType(Of AdvantageFramework.MediaManager.Classes.VCCOrder)().ToList

                        VCCCardList = New Generic.List(Of AdvantageFramework.Database.Entities.VCCCard)

                        AdvantageFramework.MediaManager.SaveCards(DbContext, Me.Session, VCCOrderList, ErrorMessage, VCCCardList)

                        APIVCCOrderList = VCCOrderList.Where(Function(VO) VO.CardAmount <> VO.OriginalCardAmount OrElse VO.CardStatus <> VO.OriginalStatus).ToList

                        If APIVCCOrderList.Count > 0 OrElse VCCCardList.Count > 0 Then

                            If AdvantageFramework.VCC.IsVCCServiceSetup(Session, ErrorMessage) = False Then

                                AdvantageFramework.WinForm.MessageBox.Show("Failed trying to connect to VCC service.  Please check all your VCC settings." & System.Environment.NewLine & ErrorMessage)

                            Else

                                If APIVCCOrderList.Count > 0 AndAlso Not AdvantageFramework.VCC.UpdateVCCCreditCard(Session, APIVCCOrderList, ErrorMessage) Then

                                    Throw New Exception(ErrorMessage)

                                End If

                                If VCCCardList.Count > 0 AndAlso Not AdvantageFramework.VCC.UpdateVCCCreditCard(Session, VCCCardList, ErrorMessage) Then

                                    Throw New Exception(ErrorMessage)

                                End If

                                RefreshVCCOrders(APIVCCOrderList)

                            End If

                        End If

                        Saved = True

                    ElseIf TabControlForm_ReviewItems.SelectedTab Is TabItemReviewItems_LineComments Then

                        Me.ShowWaitForm("Saving...")

                        DataGridViewLineComments_LineComments.CurrentView.CloseEditorForUpdating()

                        MediaManagerOrderLineCommentList = DataGridViewLineComments_LineComments.GetAllModifiedRows.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerOrderLineComment)().ToList

                        AdvantageFramework.MediaManager.SaveOrderLineComments(DbContext, MediaManagerOrderLineCommentList)

                        Saved = True

                    ElseIf TabControlForm_ReviewItems.SelectedTab Is TabItemReviewItems_OrderComments Then

                        Me.ShowWaitForm("Saving...")

                        DataGridViewOrderComments_OrderComments.CurrentView.CloseEditorForUpdating()

                        MediaManagerOrderCommentList = DataGridViewOrderComments_OrderComments.GetAllModifiedRows.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerOrderComment)().ToList

                        AdvantageFramework.MediaManager.SaveOrderComments(DbContext, MediaManagerOrderCommentList)

                        Saved = True

                    ElseIf TabControlForm_ReviewItems.SelectedTab Is TabItemReviewItems_OrderDetails Then

                        DataGridViewOrderDetails_OrderDetails.CurrentView.CloseEditorForUpdating()

                        If DataGridViewOrderDetails_OrderDetails.HasAnyInvalidRows Then

                            AdvantageFramework.WinForm.MessageBox.Show("Fix errors in grid.")

                        Else

                            Me.ShowWaitForm("Saving...")

                            Saved = SaveOrderDetails(DbContext, ErrorMessage)

                        End If

                    ElseIf TabControlForm_ReviewItems.SelectedTab Is TabItemReviewItems_Documents Then

                        DocumentManagerControlDocuments_Documents.DataGridViewForm_Documents.CurrentView.CloseEditorForUpdating()

                        Saved = DocumentManagerControlDocuments_Documents.Save(ErrorMessage)

                    ElseIf TabControlForm_ReviewItems.SelectedTab Is TabItemReviewItems_VendorCollectedDetails Then

                        Me.ShowWaitForm("Saving...")

                        DataGridViewVendorCollectedDetails_VendorCollectedDetails.CurrentView.CloseEditorForUpdating()

                        VendorCollectedDetailList = DataGridViewVendorCollectedDetails_VendorCollectedDetails.GetAllModifiedRows.OfType(Of AdvantageFramework.MediaManager.Classes.VendorCollectedDetail)().ToList

                        AdvantageFramework.MediaManager.SaveVendorCollectedDetails(DbContext, VendorCollectedDetailList)

                        Saved = True

                    End If

                Catch ex As Exception
                    ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                    ErrorMessage += vbCrLf & ex.Message
                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                Finally
                    Me.CloseWaitForm()
                End Try

            End Using

            Save = Saved

        End Function
        Private Sub UpdateCampaigns(DbContext As AdvantageFramework.Database.DbContext, CampaignIDs As IEnumerable(Of Integer), MediaManagerReviewDetails As IEnumerable(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail))

            Dim MediaManagerReviewDetail As AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail = Nothing
            Dim SqlParameterStartDate As SqlClient.SqlParameter = Nothing
            Dim SqlParameterEndDate As SqlClient.SqlParameter = Nothing
            Dim SqlParameterID As SqlClient.SqlParameter = Nothing

            If CampaignIDs IsNot Nothing AndAlso CampaignIDs.Count > 0 Then

                For Each CampaignID In CampaignIDs

                    MediaManagerReviewDetail = MediaManagerReviewDetails.Where(Function(MMRD) MMRD.CampaignID IsNot Nothing AndAlso MMRD.CampaignID = CampaignID).FirstOrDefault

                    If MediaManagerReviewDetail IsNot Nothing Then

                        SqlParameterStartDate = New SqlClient.SqlParameter("@StartDate", SqlDbType.SmallDateTime)
                        SqlParameterEndDate = New SqlClient.SqlParameter("@EndDate", SqlDbType.SmallDateTime)
                        SqlParameterID = New SqlClient.SqlParameter("@ID", SqlDbType.Int)

                        If MediaManagerReviewDetail.CampaignStartDate.HasValue Then

                            SqlParameterStartDate.Value = MediaManagerReviewDetail.CampaignStartDate.Value

                        Else

                            SqlParameterStartDate.Value = System.DBNull.Value

                        End If

                        If MediaManagerReviewDetail.CampaignEndDate.HasValue Then

                            SqlParameterEndDate.Value = MediaManagerReviewDetail.CampaignEndDate.Value

                        Else

                            SqlParameterEndDate.Value = System.DBNull.Value

                        End If

                        SqlParameterID.Value = CampaignID

                        DbContext.Database.ExecuteSqlCommand("UPDATE dbo.CAMPAIGN SET CMP_BEG_DATE = @StartDate, CMP_END_DATE = @EndDate WHERE CMP_IDENTIFIER = @ID",
                                                             SqlParameterStartDate, SqlParameterEndDate, SqlParameterID)

                    End If

                Next

            End If

        End Sub
        Private Function SaveOrderDetails(DbContext As AdvantageFramework.Database.DbContext, ByRef ErrorMessage As String) As Boolean

            Dim VCCCardList As Generic.List(Of AdvantageFramework.Database.Entities.VCCCard) = Nothing
            Dim MediaManagerReviewDetails As IEnumerable(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail) = Nothing
            Dim OrderLines As IEnumerable(Of String) = Nothing
            Dim MMRDWithBillingUsers As IEnumerable(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail) = Nothing
            Dim UpdateToQuoteFailed As Boolean = False
            Dim BillingUserExists As Boolean = False
            Dim InfoMessage As String = ""
            Dim Saved As Boolean = False
            Dim CampaignIDs As IEnumerable(Of Integer) = Nothing

            VCCCardList = New Generic.List(Of AdvantageFramework.Database.Entities.VCCCard)

            MediaManagerReviewDetails = DataGridViewOrderDetails_OrderDetails.GetAllModifiedRows.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail)().ToList

            If MediaManagerReviewDetails IsNot Nothing AndAlso MediaManagerReviewDetails.Count > 0 Then

                OrderLines = MediaManagerReviewDetails.Select(Function(Entity) CStr(Entity.OrderNumber) + "|" + CStr(Entity.LineNumber)).ToList

                MMRDWithBillingUsers = AdvantageFramework.MediaManager.LoadMediaManagerReviewDetails(DbContext, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, OrderLines, Nothing, Nothing, Nothing, False, Nothing, False, Nothing, False, False)

                MMRDWithBillingUsers = MMRDWithBillingUsers.Where(Function(MMRD) String.IsNullOrWhiteSpace(MMRD.BillingUser) = False).ToList

                Try

                    For Each MediaManagerReviewDetail In MediaManagerReviewDetails

                        If MediaManagerReviewDetail.ReviseUpdateOrder Then

                            If MMRDWithBillingUsers.Where(Function(MMRD) MMRD.OrderNumber = MediaManagerReviewDetail.OrderNumber AndAlso MMRD.LineNumber = MediaManagerReviewDetail.LineNumber).Any = False Then

                                If AdvantageFramework.MediaManager.ReviseOrder(Session, False, MediaManagerReviewDetail, ErrorMessage) = False Then

                                    Throw New Exception(ErrorMessage)

                                End If

                            Else

                                BillingUserExists = True

                            End If

                        End If

                        If MediaManagerReviewDetail.QuoteColumnUpdated Then

                            If MediaManagerReviewDetail.Quote Then

                                If MMRDWithBillingUsers.Where(Function(MMRD) MMRD.OrderNumber = MediaManagerReviewDetail.OrderNumber AndAlso MMRD.LineNumber = MediaManagerReviewDetail.LineNumber).Any = True Then

                                    UpdateToQuoteFailed = True

                                ElseIf Not AdvantageFramework.MediaManager.CanOrderChangeToQuote(DbContext, MediaManagerReviewDetail.OrderNumber, MediaManagerReviewDetail.MediaFrom, True) Then

                                    UpdateToQuoteFailed = True

                                End If

                            Else

                                AdvantageFramework.MediaManager.UpdateQuoteToOrder(DbContext, MediaManagerReviewDetail.OrderNumber, MediaManagerReviewDetail.MediaFrom.Substring(0, 1))

                            End If

                        End If

                        If MediaManagerReviewDetail.JobMediaBillDateColumnUpdated AndAlso MediaManagerReviewDetail.JobNumber.HasValue AndAlso MediaManagerReviewDetail.JobComponentNumber.HasValue Then

                            AdvantageFramework.MediaManager.UpdateJobComponentMediaBillDate(DbContext, MediaManagerReviewDetail)

                        End If

                        AdvantageFramework.MediaManager.UpdateCollectedCost(DbContext, Me.Session, MediaManagerReviewDetail.OrderNumber, MediaManagerReviewDetail.LineNumber, MediaManagerReviewDetail.RevisionNumber,
                                            MediaManagerReviewDetail.Quote, MediaManagerReviewDetail.VendorCollected.GetValueOrDefault(0), MediaManagerReviewDetail.VendorCollectedCopy, MediaManagerReviewDetail.VCCCardID, VCCCardList)

                    Next

                    CampaignIDs = MediaManagerReviewDetails.Where(Function(MMRD) MMRD.CampaignID.HasValue).Select(Function(MMRD) MMRD.CampaignID.Value).Distinct.ToArray

                    UpdateCampaigns(DbContext, CampaignIDs, MediaManagerReviewDetails)

                    If VCCCardList.Count > 0 Then

                        If Not AdvantageFramework.VCC.UpdateVCCCreditCard(Me.Session, VCCCardList, ErrorMessage) Then

                            InfoMessage = "One or more virtual credit cards could not be updated through provider." & System.Environment.NewLine & ErrorMessage

                        End If

                    End If

                    Saved = True

                    If UpdateToQuoteFailed Then

                        InfoMessage += "One or more orders could not be changed to a quote." & System.Environment.NewLine

                    End If

                    If BillingUserExists Then

                        InfoMessage += "One or more orders could not be revised due to it being selected for billing."

                    End If

                    If Not String.IsNullOrWhiteSpace(InfoMessage) Then

                        AdvantageFramework.WinForm.MessageBox.Show(InfoMessage)

                    End If

                Catch ex As Exception
                    ErrorMessage = ex.Message
                End Try

            End If

            SaveOrderDetails = Saved

        End Function
        Private Sub LoadTabItems()

            If TabControlForm_ReviewItems.SelectedTab.Tag = False Then

                If TabControlForm_ReviewItems.SelectedTab Is TabItemReviewItems_OrderStatus Then

                    LoadOrderStatusTab()

                ElseIf TabControlForm_ReviewItems.SelectedTab Is TabItemReviewItems_OrderComments Then

                    LoadOrderHeaderCommentsTab()

                ElseIf TabControlForm_ReviewItems.SelectedTab Is TabItemReviewItems_LineComments Then

                    LoadOrderLineCommentsTab()

                ElseIf TabControlForm_ReviewItems.SelectedTab Is TabItemReviewItems_APInvoiceDetail Then

                    LoadAPInvoicesPostedTab()

                ElseIf TabControlForm_ReviewItems.SelectedTab Is TabItemReviewItems_VendorCollectedDetails Then

                    LoadVendorCollectedDetailsTab()

                ElseIf TabControlForm_ReviewItems.SelectedTab Is TabItemReviewItems_BillingInvoices Then

                    LoadBillingInvoicesTab()

                ElseIf TabControlForm_ReviewItems.SelectedTab Is TabItemReviewItems_VendorReps Then

                    LoadVendorRepsTab()

                ElseIf TabControlForm_ReviewItems.SelectedTab Is TabItemReviewItems_Documents Then

                    LoadDocumentsTab()

                ElseIf TabControlForm_ReviewItems.SelectedTab Is TabItemReviewItems_OrderDetails Then

                    LoadOrderDetailsTab()

                ElseIf TabControlForm_ReviewItems.SelectedTab Is TabItemReviewItems_VCCDetails Then

                    LoadVCCDetailsTopTab()

                ElseIf TabControlForm_ReviewItems.SelectedTab Is TabItemReviewItems_PurchaseOrderDetails Then

                    LoadPODetailsTab()

                ElseIf TabControlForm_ReviewItems.SelectedTab Is TabItemReviewItems_PurchaseOrderStatus Then

                    LoadPurchaseOrderStatusTab()

                End If

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub LoadOrderStatusTab()

            Dim MediaManagerReviewDetailList As Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail) = Nothing
            Dim LineNumbers As IEnumerable(Of Integer) = Nothing

            MediaManagerReviewDetailList = DataGridViewOrderDetails_OrderDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).ToList

            If MediaManagerReviewDetailList.Count > 0 Then

                LineNumbers = MediaManagerReviewDetailList.Select(Of Integer)(Function(E) E.LineNumber).ToArray

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    DataGridViewOrderStatus_OrderStatus.DataSource = AdvantageFramework.MediaManager.LoadMediaManagerOrderStatus(DbContext, MediaManagerReviewDetailList.First.MediaFrom,
                        MediaManagerReviewDetailList.First.OrderNumber, MediaManagerReviewDetailList.First.OrderDescription, LineNumbers, _TimezoneOffset)

                End Using

            Else

                DataGridViewOrderStatus_OrderStatus.DataSource = New Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerOrderStatus)

            End If

            DataGridViewOrderStatus_OrderStatus.CurrentView.BestFitColumns()

            TabItemReviewItems_OrderStatus.Tag = True

        End Sub
        Private Sub LoadPurchaseOrderStatusTab()

            'objects
            Dim MediaManagerPODetailList As Generic.List(Of AdvantageFramework.DTO.Media.MediaManager.MediaManagerPODetail) = Nothing
            Dim PONumbers As IEnumerable(Of Integer) = Nothing

            MediaManagerPODetailList = DataGridViewPODetails_PODetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.MediaManager.MediaManagerPODetail).ToList

            If MediaManagerPODetailList.Count > 0 Then

                PONumbers = MediaManagerPODetailList.Select(Of Integer)(Function(E) E.PONumber).ToArray

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    DataGridViewPOStatus_POStatus.DataSource = AdvantageFramework.MediaManager.LoadMediaManagerPurchaseOrderStatus(DbContext, MediaManagerPODetailList.First, PONumbers, _TimezoneOffset)

                End Using

            Else

                DataGridViewPOStatus_POStatus.DataSource = New Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerPurchaseOrderStatus)

            End If

            DataGridViewPOStatus_POStatus.CurrentView.BestFitColumns()

            TabItemReviewItems_PurchaseOrderStatus.Tag = True

        End Sub
        Private Sub LoadOrderHeaderCommentsTab()

            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim AFActiveFilterString As String = Nothing
            Dim Dictionary As System.Collections.Generic.Dictionary(Of Integer, AdvantageFramework.MediaManager.Classes.MediaManagerOrderComment) = Nothing
            Dim OrderNumbers As IEnumerable(Of Integer) = Nothing

            BindingSource = DataGridViewOrderComments_OrderComments.DataSource

            If BindingSource IsNot Nothing AndAlso BindingSource.DataSource IsNot Nothing Then

                AFActiveFilterString = DataGridViewOrderComments_OrderComments.CurrentView.AFActiveFilterString

                Dictionary = DataGridViewOrderComments_OrderComments.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerOrderComment).ToDictionary(Function(MMOC) MMOC.OrderNumber, Function(MMOC) MMOC)

            End If

            OrderNumbers = (From Entity In DataGridViewOrderDetails_OrderDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail)
                            Select Entity.OrderNumber).Distinct.ToList

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DataGridViewOrderComments_OrderComments.DataSource = AdvantageFramework.MediaManager.LoadMediaManagerOrderHeaderComments(DbContext, OrderNumbers)

            End Using

            DataGridViewOrderComments_OrderComments.CurrentView.AFActiveFilterString = AFActiveFilterString

            If Dictionary IsNot Nothing AndAlso Dictionary.Count > 0 Then

                DataGridViewOrderComments_OrderComments.CurrentView.BeginSelection()

                DataGridViewOrderComments_OrderComments.CurrentView.ClearSelection()

                For Each KeyValuePair In Dictionary

                    For Each RowsRowHandlesAndDataBoundItem In DataGridViewOrderComments_OrderComments.GetAllRowsRowHandlesAndDataBoundItems

                        If DirectCast(RowsRowHandlesAndDataBoundItem.Value, AdvantageFramework.MediaManager.Classes.MediaManagerOrderComment).OrderNumber = KeyValuePair.Key Then

                            DataGridViewOrderComments_OrderComments.CurrentView.SelectRow(RowsRowHandlesAndDataBoundItem.Key)

                            DataGridViewOrderComments_OrderComments.CurrentView.FocusedRowHandle = RowsRowHandlesAndDataBoundItem.Key

                            Exit For

                        End If

                    Next

                Next

                DataGridViewOrderComments_OrderComments.CurrentView.EndSelection()

            End If

            DataGridViewOrderComments_OrderComments.CurrentView.BestFitColumns()

            TabItemReviewItems_OrderComments.Tag = True

        End Sub
        Private Sub LoadOrderLineCommentsTab()

            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim AFActiveFilterString As String = Nothing
            Dim Dictionary As System.Collections.Generic.Dictionary(Of String, AdvantageFramework.MediaManager.Classes.MediaManagerOrderLineComment) = Nothing
            Dim OrderNumberLineNumbers As IEnumerable(Of String) = Nothing

            BindingSource = DataGridViewLineComments_LineComments.DataSource

            If BindingSource IsNot Nothing AndAlso BindingSource.DataSource IsNot Nothing Then

                AFActiveFilterString = DataGridViewLineComments_LineComments.CurrentView.AFActiveFilterString

                Dictionary = DataGridViewLineComments_LineComments.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerOrderLineComment).ToDictionary(Function(E) E.OrderNumberLineNumber, Function(E) E)

            End If

            OrderNumberLineNumbers = (From Entity In DataGridViewOrderDetails_OrderDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail)
                                      Select Entity.OrderNumber & "|" & Entity.LineNumber).Distinct.ToList

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DataGridViewLineComments_LineComments.DataSource = AdvantageFramework.MediaManager.LoadMediaManagerOrderLineComments(DbContext, OrderNumberLineNumbers)

            End Using

            DataGridViewLineComments_LineComments.CurrentView.AFActiveFilterString = AFActiveFilterString

            If Dictionary IsNot Nothing AndAlso Dictionary.Count > 0 Then

                DataGridViewLineComments_LineComments.CurrentView.BeginSelection()

                DataGridViewLineComments_LineComments.CurrentView.ClearSelection()

                For Each KeyValuePair In Dictionary

                    For Each RowsRowHandlesAndDataBoundItem In DataGridViewLineComments_LineComments.GetAllRowsRowHandlesAndDataBoundItems

                        If DirectCast(RowsRowHandlesAndDataBoundItem.Value, AdvantageFramework.MediaManager.Classes.MediaManagerOrderLineComment).OrderNumberLineNumber = KeyValuePair.Key Then

                            DataGridViewLineComments_LineComments.CurrentView.SelectRow(RowsRowHandlesAndDataBoundItem.Key)

                            DataGridViewLineComments_LineComments.CurrentView.FocusedRowHandle = RowsRowHandlesAndDataBoundItem.Key

                            Exit For

                        End If

                    Next

                Next

                DataGridViewLineComments_LineComments.CurrentView.EndSelection()

            End If

            DataGridViewLineComments_LineComments.CurrentView.BestFitColumns()

            TabItemReviewItems_LineComments.Tag = True

        End Sub
        Private Sub LoadAPInvoicesPostedTab()

            Dim MediaManagerReviewDetailList As Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail) = Nothing
            Dim LineNumbers As IEnumerable(Of Integer) = Nothing

            If DataGridViewOrderDetails_OrderDetails.HasASelectedRow Then

                MediaManagerReviewDetailList = DataGridViewOrderDetails_OrderDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).ToList

                LineNumbers = (From Entity In MediaManagerReviewDetailList
                               Select Entity.LineNumber).ToList

                ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.LoadControl(MediaManagerReviewDetailList.First.OrderNumber, LineNumbers, MediaManagerReviewDetailList.First.MediaFrom, False)

            End If

            TabItemReviewItems_APInvoiceDetail.Tag = True

        End Sub
        Private Sub LoadVendorCollectedDetailsTab()

            Dim VendorCollectedDetailList As Generic.List(Of AdvantageFramework.MediaManager.Classes.VendorCollectedDetail) = Nothing
            Dim MediaManagerReviewDetailList As Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail) = Nothing
            Dim OrderNumberLineNumbers As IEnumerable(Of String) = Nothing

            VendorCollectedDetailList = New Generic.List(Of AdvantageFramework.MediaManager.Classes.VendorCollectedDetail)

            If DataGridViewOrderDetails_OrderDetails.HasASelectedRow Then

                MediaManagerReviewDetailList = DataGridViewOrderDetails_OrderDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).ToList

                OrderNumberLineNumbers = (From Entity In MediaManagerReviewDetailList
                                          Select CStr(Entity.OrderNumber) + "|" + CStr(Entity.LineNumber)).ToList

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    VendorCollectedDetailList.AddRange(AdvantageFramework.MediaManager.LoadVendorCollectedDetails(DbContext, OrderNumberLineNumbers))

                End Using

            End If

            For Each VendorCollectedDetail In VendorCollectedDetailList

                VendorCollectedDetail.TimezoneOffset = _TimezoneOffset

            Next

            DataGridViewVendorCollectedDetails_VendorCollectedDetails.DataSource = VendorCollectedDetailList

            DataGridViewVendorCollectedDetails_VendorCollectedDetails.CurrentView.BestFitColumns()

            TabItemReviewItems_VendorCollectedDetails.Tag = True

        End Sub
        Private Sub LoadBillingInvoicesTab()

            Dim OrderNumber As Integer = Nothing
            Dim OrderDescription As String = Nothing
            Dim LineNumbers As IEnumerable(Of Integer) = Nothing

            If DataGridViewOrderDetails_OrderDetails.HasASelectedRow Then

                OrderNumber = DataGridViewOrderDetails_OrderDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).FirstOrDefault.OrderNumber
                OrderDescription = DataGridViewOrderDetails_OrderDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).FirstOrDefault.OrderDescription

                LineNumbers = (From Entity In DataGridViewOrderDetails_OrderDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).ToList
                               Select Entity.LineNumber).ToArray

                MediaBillingHistoryControlBillingInvoices_BillingInvoices.LoadControl(OrderNumber, LineNumbers, OrderDescription)

            Else

                MediaBillingHistoryControlBillingInvoices_BillingInvoices.ClearControl()

            End If

            TabItemReviewItems_BillingInvoices.Tag = True

        End Sub
        Private Sub LoadVendorRepsTab()

            Dim VendorRepList As Generic.List(Of AdvantageFramework.MediaManager.Classes.VendorRep) = Nothing
            Dim MediaManagerReviewDetail As AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail = Nothing

            VendorRepList = New Generic.List(Of AdvantageFramework.MediaManager.Classes.VendorRep)

            If DataGridViewOrderDetails_OrderDetails.HasASelectedRow Then

                MediaManagerReviewDetail = DataGridViewOrderDetails_OrderDetails.CurrentView.GetRow(DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedRowHandle)

                VendorRepList.AddRange(AdvantageFramework.MediaManager.LoadVendorReps(Me.Session, MediaManagerReviewDetail.VendorCode, MediaManagerReviewDetail.OrderNumber))
                DataGridViewVendorReps_VendorReps.CurrentView.Tag = MediaManagerReviewDetail.OrderNumber

            End If

            DataGridViewVendorReps_VendorReps.DataSource = VendorRepList

            If DataGridViewVendorReps_VendorReps.Columns(AdvantageFramework.Database.Classes.VendorRep.Properties.Telephone.ToString) IsNot Nothing Then

                DataGridViewVendorReps_VendorReps.Columns(AdvantageFramework.Database.Classes.VendorRep.Properties.Telephone.ToString).VisibleIndex = 9

            End If

            If DataGridViewVendorReps_VendorReps.Columns(AdvantageFramework.Database.Classes.VendorRep.Properties.Email.ToString) IsNot Nothing Then

                DataGridViewVendorReps_VendorReps.Columns(AdvantageFramework.Database.Classes.VendorRep.Properties.Email.ToString).VisibleIndex = 10

            End If

            If DataGridViewVendorReps_VendorReps.Columns(AdvantageFramework.Database.Classes.VendorRep.Properties.IsInactive.ToString) IsNot Nothing Then

                DataGridViewVendorReps_VendorReps.Columns(AdvantageFramework.Database.Classes.VendorRep.Properties.IsInactive.ToString).VisibleIndex = 11

            End If

            DataGridViewVendorReps_VendorReps.CurrentView.BestFitColumns()

            TabItemReviewItems_VendorReps.Tag = True

        End Sub
        Private Sub LoadDocumentsTab()

            'objects
            Dim MediaManagerReviewDetail As AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail = Nothing
            Dim DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting) = Nothing

            DocumentManagerControlDocuments_Documents.ClearControl()

            If DataGridViewOrderDetails_OrderDetails.HasASelectedRow Then

                MediaManagerReviewDetail = DataGridViewOrderDetails_OrderDetails.CurrentView.GetRow(DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedRowHandle)

            End If

            If MediaManagerReviewDetail IsNot Nothing AndAlso TabItemReviewItems_Documents.Visible Then

                DocumentLevelSettings = New Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting)

                DocumentLevelSettings.Add(New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.MediaOrder) With {.OrderNumber = MediaManagerReviewDetail.OrderNumber, .MediaType = MediaManagerReviewDetail.MediaFrom.Substring(0, 1)})

                If MediaManagerReviewDetail.JobNumber.HasValue Then

                    DocumentLevelSettings.Add(New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.Job) With {.JobNumber = MediaManagerReviewDetail.JobNumber.Value})

                End If

                If MediaManagerReviewDetail.JobNumber.HasValue AndAlso MediaManagerReviewDetail.JobComponentNumber.HasValue Then

                    DocumentLevelSettings.Add(New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.JobComponent) With {.JobNumber = MediaManagerReviewDetail.JobNumber.Value, .JobComponentNumber = MediaManagerReviewDetail.JobComponentNumber.Value})

                End If

                If MediaManagerReviewDetail.CampaignID.HasValue Then

                    DocumentLevelSettings.Add(New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.Campaign) With {.CampaignID = MediaManagerReviewDetail.CampaignID.Value})

                End If

                DocumentManagerControlDocuments_Documents.Enabled = DocumentManagerControlDocuments_Documents.LoadControl(Database.Entities.DocumentLevel.AccountReceivableInvoice, DocumentLevelSettings, WinForm.Presentation.Controls.DocumentManagerControl.Type.Default, Database.Entities.DocumentSubLevel.Default, True, True, True)

            End If

            TabItemReviewItems_Documents.Tag = True

        End Sub
        Private Sub GenerateAPInvoices(ByVal CreateAPInvoicesBy As CreateAPInvoices)

            Dim MediaManagerReviewDetailList As Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail) = Nothing
            Dim StagingCreated As Boolean = False
            Dim ErrorMessage As String = ""
            Dim BatchName As String = Nothing

            If IsImportFormOpen() Then

                AdvantageFramework.WinForm.MessageBox.Show("You must first close the Accounts Payable Import Staging tab.")

            Else

                MediaManagerReviewDetailList = (From MMRD In DataGridViewOrderDetails_OrderDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail)()
                                                Where MMRD.BillType <> "Comm Only" AndAlso
                                                      MMRD.ActualAmountPosted = 0 AndAlso
                                                      MMRD.Quote = False AndAlso
                                                      MMRD.Cancelled = False AndAlso
                                                      MMRD.IsOrderClosed = False
                                                Select MMRD).ToList

                If MediaManagerReviewDetailList.Count = 0 Then

                    AdvantageFramework.WinForm.MessageBox.Show("Please select line(s) that are not closed, not cancelled, not 'commission only', not marked as quote, and actual amount posted is zero.")

                Else

                    Try

                        Me.ShowWaitForm()

                        Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                            StagingCreated = AdvantageFramework.MediaManager.CreateAPImportStagingInvoices(DbContext, MediaManagerReviewDetailList, If(CreateAPInvoicesBy = CreateAPInvoices.GroupByVendor, True, False), BatchName)

                        End Using

                        If StagingCreated AndAlso TypeOf _ParentForm.MdiParent Is AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm Then

                            CType(_ParentForm.MdiParent, AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm).OpenModule(AdvantageFramework.Security.Modules.FinanceAccounting_AccountsPayable_AP_ExpenseReport_Import)

                            For Each MdiChildForm In CType(_ParentForm.MdiParent, AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm).MdiChildren

                                If MdiChildForm.GetType Is GetType(AdvantageFramework.Importing.Presentation.ImportForm) Then

                                    DirectCast(MdiChildForm, AdvantageFramework.Importing.Presentation.ImportForm).DisableNavigationDropDowns(BatchName)
                                    DirectCast(MdiChildForm, AdvantageFramework.Importing.Presentation.ImportForm).DeleteBatchOnExit = True

                                    Exit For

                                End If

                            Next

                            _ImportWasLaunched = True

                        End If

                    Catch ex As Exception
                        ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                        ErrorMessage += vbCrLf & ex.Message
                    Finally
                        Me.CloseWaitForm()
                    End Try

                End If

            End If

        End Sub
        Private Sub EditSelectedVendorRep()

            'objects
            Dim VendorCode As String = Nothing
            Dim VendorRepCode As String = Nothing

            If DataGridViewVendorReps_VendorReps.HasOnlyOneSelectedRow Then

                VendorCode = DataGridViewVendorReps_VendorReps.CurrentView.GetRowCellValue(DataGridViewVendorReps_VendorReps.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Classes.VendorRep.Properties.VendorCode.ToString)
                VendorRepCode = DataGridViewVendorReps_VendorReps.CurrentView.GetRowCellValue(DataGridViewVendorReps_VendorReps.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Classes.VendorRep.Properties.Code.ToString)

                AdvantageFramework.Maintenance.Media.Presentation.VendorRepEditDialog.ShowFormDialog(VendorCode, VendorRepCode, True)

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Refreshing

                Try

                    LoadVendorRepsTab()

                Catch ex As Exception

                End Try

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                DataGridViewVendorReps_VendorReps.SelectRow(AdvantageFramework.Database.Classes.VendorRep.Properties.ID.ToString, VendorCode & "|" & VendorRepCode, True)

            End If

        End Sub
        Private Sub SaveVendorRep(Checked As Boolean, VendorRep As AdvantageFramework.MediaManager.Classes.VendorRep, IsRep1 As Boolean, OrderNumber As Integer)

            Dim CurrentRowVendorRep As AdvantageFramework.MediaManager.Classes.VendorRep = Nothing
            Dim HasError As Boolean = False
            Dim DoSave As Boolean = True
            Dim Activate As Boolean = False

            If Checked Then

                For RowHandle = 0 To DataGridViewVendorReps_VendorReps.CurrentView.RowCount - 1

                    CurrentRowVendorRep = DataGridViewVendorReps_VendorReps.CurrentView.GetRow(RowHandle)

                    If IsRep1 AndAlso CurrentRowVendorRep IsNot VendorRep AndAlso CurrentRowVendorRep.IsOrderRep1 Then

                        AdvantageFramework.WinForm.MessageBox.Show("Only one order rep 1 is allowed.")

                        HasError = True

                        Exit For

                    ElseIf IsRep1 = False AndAlso CurrentRowVendorRep IsNot VendorRep AndAlso CurrentRowVendorRep.IsOrderRep2 Then

                        AdvantageFramework.WinForm.MessageBox.Show("Only one order rep 2 is allowed.")

                        HasError = True

                        Exit For

                    End If

                Next

                If HasError = False Then

                    If VendorRep.IsInactive Then

                        If AdvantageFramework.WinForm.MessageBox.Show("This vendor rep is inactive.  Marking this vendor rep as order rep " & IIf(IsRep1, "1", "2") & " will activate the vendor rep. Do you want to continue?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.No Then

                            DoSave = False

                        Else

                            Activate = True

                        End If

                    End If

                End If

            End If

            If DoSave AndAlso Not HasError Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If Activate Then

                        DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.VEN_REP SET VR_INACTIVE_FLAG = 0 WHERE VN_CODE = '{0}' AND VR_CODE = '{1}'", VendorRep.VendorCode, VendorRep.Code))

                    End If

                    DbContext.Database.ExecuteSqlCommand(String.Format("exec dbo.advsp_media_manager_update_order_vendor_rep {0}, {1}, {2}", OrderNumber, IIf(Checked, "'" & VendorRep.Code & "'", "NULL"), IIf(IsRep1, 1, 0)))

                End Using

            End If

        End Sub
        Private Sub UpdateCost(ByVal ReviseOrderTo As AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.ReviseOrderToAmount)

            Dim MediaManagerReviewDetailList As Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail) = Nothing
            Dim TempError As String = ""
            Dim ErrorMessage As String = ""
            Dim HasErrors As Boolean = False

            DataGridViewOrderDetails_OrderDetails.CurrentView.CloseEditorForUpdating()

            MediaManagerReviewDetailList = DataGridViewOrderDetails_OrderDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).Where(Function(MMRD) Not MMRD.Cancelled And String.IsNullOrWhiteSpace(MMRD.BillingUser) AndAlso Not MMRD.IsOrderClosed).ToList

            If MediaManagerReviewDetailList IsNot Nothing AndAlso MediaManagerReviewDetailList.Count > 0 Then

                If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to update and save selected orders?", WinForm.MessageBox.MessageBoxButtons.YesNo, MessageBoxDefaultButton:=Windows.Forms.MessageBoxDefaultButton.Button2) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    For Each MediaManagerReviewDetail In MediaManagerReviewDetailList

                        TempError = String.Empty

                        If ReviseOrderTo = MediaManager.Classes.MediaManagerReviewDetail.ReviseOrderToAmount.ActualAmountPosted Then

                            If AdvantageFramework.MediaManager.ReconcileToActualAmountPosted(Session, MediaManagerReviewDetail, TempError) = False Then

                                ErrorMessage += TempError + vbCrLf
                                HasErrors = True

                            End If

                        Else

                            MediaManagerReviewDetail.ReviseUpdateOrder = True
                            MediaManagerReviewDetail.ForceRevision = True

                            If Not AdvantageFramework.MediaManager.ReviseOrder(Session, False, MediaManagerReviewDetail, TempError, ReviseOrderTo) Then

                                ErrorMessage += TempError + vbCrLf
                                HasErrors = True

                            End If

                        End If

                    Next

                    If HasErrors Then

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    End If

                    LoadOrderDetailsTab()

                    EnableOrDisableActions()

                End If

            End If

        End Sub
        Private Sub RecalculateOrder(MediaManagerReviewDetail As AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail, RowHandle As Integer)

            Dim ErrorMessage As String = ""

            If MediaManagerReviewDetail IsNot Nothing AndAlso String.IsNullOrWhiteSpace(MediaManagerReviewDetail.BillingUser) Then

                If Not AdvantageFramework.MediaManager.ReviseOrder(Session, True, MediaManagerReviewDetail, ErrorMessage) Then

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                Else

                    MediaManagerReviewDetail.ReviseUpdateOrder = True

                    DataGridViewOrderDetails_OrderDetails.CurrentView.RefreshRow(RowHandle)

                    DataGridViewOrderDetails_OrderDetails.AddToModifiedRows(RowHandle)

                    DataGridViewOrderDetails_OrderDetails.SetUserEntryChanged()

                    EnableOrDisableActions()

                End If

            End If

        End Sub
        Private Sub SetVCCOrderStats()

            If _VCCOrders IsNot Nothing Then

                ButtonItemSummaryResults_VCCIssuedAndUpdated.Text = String.Format("<div width='180'><span width='140'>VCC Issued and Updated</span><span width='40' align='right'>{0}</span></div>", _VCCOrders.Where(Function(Entity) Entity.VCCIssuedAndUpdated = True).Count)
                ButtonItemSummaryResults_TransactionsDeclined.Text = String.Format("<div width='180'><span width='140'>Transactions Declined</span><span width='40' align='right'>{0}</span></div>", _VCCOrders.Where(Function(Entity) Entity.TransactionDeclined = True).Count)
                ButtonItemSummaryResults_TransactionsOutOfBalance.Text = String.Format("<div width='180'><span width='140'>Transactions Out of Balance</span><span width='40' align='right'>{0}</span></div>", _VCCOrders.Where(Function(Entity) Entity.TransactionsOutOfBalance = True).Count)
                ButtonItemSummaryResults_TransactionsInBalance.Text = String.Format("<div width='180'><span width='140'>Transactions In Balance</span><span width='40' align='right'>{0}</span></div>", _VCCOrders.Where(Function(Entity) Entity.TransactionsInBalance = True).Count)
                ButtonItemSummaryResults_NoTransactions.Text = String.Format("<div width='180'><span width='140'>No Transactions</span><span width='40' align='right'>{0}</span></div>", _VCCOrders.Where(Function(Entity) Entity.NoTransactions = True).Count)
                ButtonItemSummaryResults_Followup.Text = String.Format("<div width='180'><span width='140'>Follow Up</span><span width='40' align='right'>{0}</span></div>", _VCCOrders.Where(Function(Entity) Entity.FollowupDate.HasValue AndAlso Entity.FollowupDate < Now AndAlso Not Entity.Resolved).Count)

            End If

        End Sub
        Private Sub LoadVCCOrders()

            'objects
            Dim MediaManagerReviewDetails As Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail) = Nothing
            Dim MediaManagerPODetails As Generic.List(Of AdvantageFramework.DTO.Media.MediaManager.MediaManagerPODetail) = Nothing

            LoadOrderDetailsTab()

            If TabItemReviewItems_PurchaseOrderDetails.Tag = False Then

                LoadPODetailsTab()

            End If

            MediaManagerReviewDetails = DataGridViewOrderDetails_OrderDetails.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).ToList

            MediaManagerPODetails = DataGridViewPODetails_PODetails.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.MediaManager.MediaManagerPODetail).ToList

            _VCCOrders = AdvantageFramework.MediaManager.LoadVCCOrders(Me.Session, _TimezoneOffset, MediaManagerReviewDetails, MediaManagerPODetails)

            EnableOrDisableActions()

        End Sub
        Private Sub LoadVCCCardDetailsTab()

            'objects
            Dim VCCOrder As AdvantageFramework.MediaManager.Classes.VCCOrder = Nothing
            Dim VCCDetails As Generic.List(Of AdvantageFramework.MediaManager.Classes.VCCDetail) = Nothing

            VCCDetails = New Generic.List(Of AdvantageFramework.MediaManager.Classes.VCCDetail)

            If DataGridViewTopVCCDetails_VCCOrders.HasOnlyOneSelectedRow Then

                VCCOrder = DataGridViewTopVCCDetails_VCCOrders.GetFirstSelectedRowDataBoundItem

                If VCCOrder.GetVCCCardEntity.VCCCardDetails IsNot Nothing Then

                    VCCDetails.AddRange(From Entity In VCCOrder.GetVCCCardEntity.VCCCardDetails
                                        Select New AdvantageFramework.MediaManager.Classes.VCCDetail(Entity, VCCOrder.GetVCCCardEntity.VCCProviderID, _TimezoneOffset))

                End If

            End If

            DataGridViewBottomVCCDetails_CardDetails.DataSource = VCCDetails

            DataGridViewBottomVCCDetails_CardDetails.CurrentView.BestFitColumns()

            If DataGridViewBottomVCCDetails_CardDetails.CurrentView.Columns(AdvantageFramework.MediaManager.Classes.VCCDetail.Properties.Processed.ToString) IsNot Nothing Then

                DataGridViewBottomVCCDetails_CardDetails.CurrentView.Columns(AdvantageFramework.MediaManager.Classes.VCCDetail.Properties.Processed.ToString).SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom

            End If

            TabItemVCCDetails_VCCDetailsTab.Tag = True

        End Sub
        Private Sub LoadVCCDetailsTopTab()

            ClearFilters()

            LoadVCCOrders()

            SetVCCOrderStats()

            LoadVCCGrid()

            TabItemReviewItems_VCCDetails.Tag = True

        End Sub
        Private Sub LoadVCCGrid()

            'objects
            Dim VCCOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.VCCOrder) = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim LayoutLoaded As Boolean = False
            Dim AFActiveFilterString As String = Nothing
            Dim DictionaryVCCOrder As System.Collections.Generic.Dictionary(Of String, AdvantageFramework.MediaManager.Classes.VCCOrder) = Nothing
            Dim Keys As IEnumerable(Of String) = Nothing

            VCCOrders = _VCCOrders.ToList

            If ButtonItemSummaryResults_VCCIssuedAndUpdated.Checked Then

                VCCOrders = VCCOrders.Where(Function(VCO) VCO.VCCIssuedAndUpdated).ToList

            ElseIf ButtonItemSummaryResults_TransactionsDeclined.Checked Then

                VCCOrders = VCCOrders.Where(Function(VCO) VCO.TransactionDeclined = True).ToList

            ElseIf ButtonItemSummaryResults_TransactionsOutOfBalance.Checked Then

                VCCOrders = VCCOrders.Where(Function(VCO) VCO.TransactionsOutOfBalance = True).ToList

            ElseIf ButtonItemSummaryResults_TransactionsInBalance.Checked Then

                VCCOrders = VCCOrders.Where(Function(VCO) VCO.TransactionsInBalance = True).ToList

            ElseIf ButtonItemSummaryResults_NoTransactions.Checked Then

                VCCOrders = VCCOrders.Where(Function(VCO) VCO.NoTransactions = True).ToList

            ElseIf ButtonItemSummaryResults_Followup.Checked Then

                VCCOrders = VCCOrders.Where(Function(VCO) VCO.FollowupDate.HasValue AndAlso VCO.FollowupDate < Now AndAlso Not VCO.Resolved).ToList

            End If

            BindingSource = DataGridViewTopVCCDetails_VCCOrders.DataSource

            If BindingSource IsNot Nothing AndAlso BindingSource.DataSource IsNot Nothing Then

                AFActiveFilterString = DataGridViewTopVCCDetails_VCCOrders.CurrentView.AFActiveFilterString

                DictionaryVCCOrder = DataGridViewTopVCCDetails_VCCOrders.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.VCCOrder).ToDictionary(Function(V) V.CardNumberCVCCode, Function(V) V)

                SaveVCCDetailsGridLayout()

            End If

            DataGridViewTopVCCDetails_VCCOrders.SetBookmarkColumnIndex(-1)
            DataGridViewTopVCCDetails_VCCOrders.ClearGridCustomization()
            DataGridViewTopVCCDetails_VCCOrders.ClearDatasource(New Generic.List(Of AdvantageFramework.MediaManager.Classes.VCCOrder))
            DataGridViewTopVCCDetails_VCCOrders.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True

            LayoutLoaded = AdvantageFramework.WinForm.Presentation.Controls.LoadDataGridViewLayout(Session, DataGridViewTopVCCDetails_VCCOrders, Database.Entities.GridAdvantageType.MediaManagerMediaManagerReviewVCCOrderDetail)

            DataGridViewTopVCCDetails_VCCOrders.DataSource = VCCOrders

            If Not LayoutLoaded Then

                SetVCCColumnDefaultVisibility()

                DataGridViewTopVCCDetails_VCCOrders.CurrentView.ClearSorting()
                DataGridViewTopVCCDetails_VCCOrders.CurrentView.BeginSort()
                DataGridViewTopVCCDetails_VCCOrders.CurrentView.Columns(AdvantageFramework.MediaManager.Classes.VCCOrder.Properties.OrderNumber.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Descending
                DataGridViewTopVCCDetails_VCCOrders.CurrentView.Columns(AdvantageFramework.MediaManager.Classes.VCCOrder.Properties.LineNumber.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                DataGridViewTopVCCDetails_VCCOrders.CurrentView.EndSort()

            Else

                AdvantageFramework.WinForm.Presentation.Controls.SortGridViewBySortedColumns(DataGridViewTopVCCDetails_VCCOrders)

            End If

            If Not LayoutLoaded Then

                DataGridViewTopVCCDetails_VCCOrders.CurrentView.BestFitColumns()

            End If

            DataGridViewTopVCCDetails_VCCOrders.CurrentView.AFActiveFilterString = AFActiveFilterString

            If DictionaryVCCOrder IsNot Nothing AndAlso DictionaryVCCOrder.Count > 0 Then

                DataGridViewTopVCCDetails_VCCOrders.CurrentView.BeginSelection()

                DataGridViewTopVCCDetails_VCCOrders.CurrentView.ClearSelection()

                Keys = (From Entity In DictionaryVCCOrder
                        Select Entity.Key).ToArray

                For Each RowsRowHandlesAndDataBoundItem In DataGridViewTopVCCDetails_VCCOrders.GetAllRowsRowHandlesAndDataBoundItems

                    If Keys.Contains(DirectCast(RowsRowHandlesAndDataBoundItem.Value, AdvantageFramework.MediaManager.Classes.VCCOrder).CardNumberCVCCode) Then

                        DataGridViewTopVCCDetails_VCCOrders.CurrentView.SelectRow(RowsRowHandlesAndDataBoundItem.Key)

                        DataGridViewTopVCCDetails_VCCOrders.CurrentView.FocusedRowHandle = RowsRowHandlesAndDataBoundItem.Key

                    End If

                Next

                DataGridViewTopVCCDetails_VCCOrders.CurrentView.EndSelection()

            End If

            DataGridViewTopVCCDetails_VCCOrders.CurrentView.OptionsCustomization.AllowColumnMoving = True

            DataGridViewTopVCCDetails_VCCOrders.OptionsMenu.EnableColumnMenu = True
            DataGridViewTopVCCDetails_VCCOrders.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None

            DataGridViewTopVCCDetails_VCCOrders.CurrentView.BestFitColumns()

            TabItemVCCDetails_VCCDetailsTab.Tag = False
            TabItemVCCDetails_NotesTab.Tag = False

            LoadVCCTabItems()

        End Sub
        Private Sub ClearFilters()

            ButtonItemSummaryResults_VCCIssuedAndUpdated.Checked = False
            ButtonItemSummaryResults_TransactionsDeclined.Checked = False
            ButtonItemSummaryResults_TransactionsOutOfBalance.Checked = False
            ButtonItemSummaryResults_TransactionsInBalance.Checked = False
            ButtonItemSummaryResults_NoTransactions.Checked = False
            ButtonItemSummaryResults_Followup.Checked = False

        End Sub
        Private Sub FilterLoadGrid()

            Me.FormAction = WinForm.Presentation.FormActions.Loading
            Me.ShowWaitForm()

            LoadVCCOrders()

            LoadVCCGrid()

            Me.CloseWaitForm()
            Me.FormAction = WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub RefreshVCCOrders(VCCOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.VCCOrder))

            'objects
            Dim Refreshed As Boolean = False
            Dim ErrorMessage As String = ""

            Me.FormAction = WinForm.Presentation.FormActions.Refreshing
            Me.ShowWaitForm("Refreshing...")

            Try

                Refreshed = AdvantageFramework.VCC.RefreshVCCData(Me.Session, VCCOrders, ErrorMessage)

                If Not String.IsNullOrWhiteSpace(ErrorMessage) Then

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Catch ex As Exception
                Refreshed = False
            End Try

            Me.CloseWaitForm()
            Me.FormAction = WinForm.Presentation.FormActions.None

            If Refreshed Then

                LoadVCCDetailsTopTab()

                EnableOrDisableActions()

            ElseIf Not String.IsNullOrWhiteSpace(ErrorMessage) Then

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub LoadVCCNotesTab()

            'objects
            Dim VCCOrder As AdvantageFramework.MediaManager.Classes.VCCOrder = Nothing
            Dim CardID As Integer = 0

            VCCOrder = DataGridViewTopVCCDetails_VCCOrders.GetFirstSelectedRowDataBoundItem

            If VCCOrder IsNot Nothing Then

                Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    CardID = VCCOrder.GetVCCCardEntity.ID

                    If VCCOrder.GetVCCCardEntity.CardType = Database.Interfaces.IVCCCard.EnumCardType.MediaOrder Then

                        DataGridViewBottomVCCDetails_CardNotes.DataSource = (From Entity In AdvantageFramework.Database.Procedures.VCCCardNote.Load(DbContext)
                                                                             Where Entity.VCCCardID = CardID
                                                                             Select Entity).ToList

                    ElseIf VCCOrder.GetVCCCardEntity.CardType = Database.Interfaces.IVCCCard.EnumCardType.PurchaseOrder Then

                        DataGridViewBottomVCCDetails_CardNotes.DataSource = (From Entity In AdvantageFramework.Database.Procedures.VCCCardPONote.Load(DbContext)
                                                                             Where Entity.VCCCardPOID = CardID
                                                                             Select Entity).ToList

                    End If

                End Using

            End If

            DataGridViewBottomVCCDetails_CardNotes.CurrentView.BestFitColumns()

            If DataGridViewBottomVCCDetails_CardNotes.CurrentView.Columns(AdvantageFramework.Database.Interfaces.IVCCCardNote.Properties.Note.ToString) IsNot Nothing Then

                DataGridViewBottomVCCDetails_CardNotes.CurrentView.Columns(AdvantageFramework.Database.Interfaces.IVCCCardNote.Properties.Note.ToString).Width = 300

            End If

            TabItemVCCDetails_NotesTab.Tag = True

        End Sub
        Private Sub LoadVCCTabItems()

            If Me.FormShown AndAlso TabControlVCCDetails_Details.SelectedTab.Tag = False Then

                If TabControlVCCDetails_Details.SelectedTab.Equals(TabItemVCCDetails_VCCDetailsTab) Then

                    LoadVCCCardDetailsTab()

                ElseIf TabControlVCCDetails_Details.SelectedTab.Equals(TabItemVCCDetails_NotesTab) Then

                    LoadVCCNotesTab()

                End If

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ResizeControlToFitParent(ByVal Control As Windows.Forms.Control)

            If Control.Parent.Width >= 8 AndAlso Control.Parent.Height >= 18 Then

                Control.Size = New System.Drawing.Size(Control.Parent.Width - 8, Control.Parent.Height - 18)

            End If

        End Sub
        Private Sub SelectOrderDetailsBasedOnVCCDetails()

            'objects
            Dim OrderSelectedRowHandle As Nullable(Of Integer) = Nothing
            Dim OrderRowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing
            Dim OrderDictionary As System.Collections.Generic.Dictionary(Of Integer, Object) = Nothing

            DataGridViewOrderDetails_OrderDetails.CurrentView.BeginUpdate()

            OrderRowHandlesAndDataBoundItems = DataGridViewOrderDetails_OrderDetails.GetAllSelectedRowsRowHandlesAndDataBoundItems()

            DataGridViewOrderDetails_OrderDetails.HideRowSelection()

            OrderDictionary = DataGridViewOrderDetails_OrderDetails.GetAllRowsRowHandlesAndDataBoundItems()

            For Each VCCOrder In DataGridViewTopVCCDetails_VCCOrders.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.VCCOrder)

                For Each Item In OrderDictionary

                    If DirectCast(Item.Value, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).OrderNumber = VCCOrder.OrderNumber AndAlso
                            DirectCast(Item.Value, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).LineNumber = VCCOrder.LineNumber Then

                        DataGridViewOrderDetails_OrderDetails.CurrentView.SelectRow(Item.Key)

                        If OrderSelectedRowHandle Is Nothing Then

                            For Each RowHandlesAndDataBoundItem In OrderRowHandlesAndDataBoundItems

                                DataGridViewOrderDetails_OrderDetails.CurrentView.UnselectRow(RowHandlesAndDataBoundItem.Key)

                            Next

                            OrderSelectedRowHandle = Item.Key

                        End If

                        DataGridViewOrderDetails_OrderDetails.CurrentView.SelectRow(Item.Key)

                        Exit For

                    End If

                Next

            Next

            DataGridViewOrderDetails_OrderDetails.CurrentView.EndUpdate()

            If OrderSelectedRowHandle IsNot Nothing Then

                DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedRowHandle = OrderSelectedRowHandle
                DataGridViewOrderDetails_OrderDetails.CurrentView.MakeRowVisible(OrderSelectedRowHandle)

            End If

        End Sub
        Private Sub SelectPODetailsBasedOnVCCDetails()

            'objects
            Dim POSelectedRowHandle As Nullable(Of Integer) = Nothing
            Dim PORowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing
            Dim PODictionary As System.Collections.Generic.Dictionary(Of Integer, Object) = Nothing

            DataGridViewPODetails_PODetails.CurrentView.BeginDataUpdate()

            PORowHandlesAndDataBoundItems = DataGridViewPODetails_PODetails.GetAllSelectedRowsRowHandlesAndDataBoundItems()

            DataGridViewPODetails_PODetails.HideRowSelection()

            PODictionary = DataGridViewPODetails_PODetails.GetAllRowsRowHandlesAndDataBoundItems()

            For Each VCCOrder In DataGridViewTopVCCDetails_VCCOrders.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.VCCOrder)

                For Each Item In PODictionary

                    If DirectCast(Item.Value, AdvantageFramework.DTO.Media.MediaManager.MediaManagerPODetail).PONumber = VCCOrder.PONumber Then

                        DataGridViewPODetails_PODetails.CurrentView.SelectRow(Item.Key)

                        If POSelectedRowHandle Is Nothing Then

                            For Each RowHandlesAndDataBoundItem In PORowHandlesAndDataBoundItems

                                DataGridViewPODetails_PODetails.CurrentView.UnselectRow(RowHandlesAndDataBoundItem.Key)

                            Next

                            POSelectedRowHandle = Item.Key

                        End If

                        DataGridViewPODetails_PODetails.CurrentView.SelectRow(Item.Key)

                        Exit For

                    End If

                Next

            Next

            DataGridViewPODetails_PODetails.CurrentView.EndUpdate()

            If POSelectedRowHandle IsNot Nothing Then

                DataGridViewPODetails_PODetails.CurrentView.FocusedRowHandle = POSelectedRowHandle
                DataGridViewPODetails_PODetails.CurrentView.MakeRowVisible(POSelectedRowHandle)

            End If

        End Sub
        Private Sub SelectVCCDetailsBasedOnOrderDetails()

            Dim SelectedRowHandle As Nullable(Of Integer) = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing
            Dim Dictionary As System.Collections.Generic.Dictionary(Of Integer, Object) = Nothing

            DataGridViewTopVCCDetails_VCCOrders.CurrentView.BeginUpdate()

            RowHandlesAndDataBoundItems = DataGridViewTopVCCDetails_VCCOrders.GetAllSelectedRowsRowHandlesAndDataBoundItems()

            DataGridViewTopVCCDetails_VCCOrders.HideRowSelection()

            Dictionary = DataGridViewTopVCCDetails_VCCOrders.GetAllRowsRowHandlesAndDataBoundItems()

            For Each MediaManagerReviewDetail In DataGridViewOrderDetails_OrderDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail)

                For Each Item In Dictionary

                    If DirectCast(Item.Value, AdvantageFramework.MediaManager.Classes.VCCOrder).OrderNumber = MediaManagerReviewDetail.OrderNumber Then

                        DataGridViewTopVCCDetails_VCCOrders.CurrentView.SelectRow(Item.Key)

                        If SelectedRowHandle Is Nothing Then

                            For Each RowHandlesAndDataBoundItem In RowHandlesAndDataBoundItems

                                DataGridViewTopVCCDetails_VCCOrders.CurrentView.UnselectRow(RowHandlesAndDataBoundItem.Key)

                            Next

                            SelectedRowHandle = Item.Key

                        End If

                        DataGridViewTopVCCDetails_VCCOrders.CurrentView.SelectRow(Item.Key)

                        Exit For

                    End If

                Next

            Next

            DataGridViewTopVCCDetails_VCCOrders.CurrentView.EndUpdate()

            If SelectedRowHandle IsNot Nothing Then

                DataGridViewTopVCCDetails_VCCOrders.CurrentView.FocusedRowHandle = SelectedRowHandle
                DataGridViewTopVCCDetails_VCCOrders.CurrentView.MakeRowVisible(SelectedRowHandle)

            End If

            TabControlVCCDetails_Details.SelectedTab.Tag = False

            LoadVCCTabItems()

        End Sub
        Private Sub SelectVCCDetailsBasedOnPODetails()

            Dim SelectedRowHandle As Nullable(Of Integer) = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing
            Dim Dictionary As System.Collections.Generic.Dictionary(Of Integer, Object) = Nothing

            DataGridViewTopVCCDetails_VCCOrders.CurrentView.BeginUpdate()

            RowHandlesAndDataBoundItems = DataGridViewTopVCCDetails_VCCOrders.GetAllSelectedRowsRowHandlesAndDataBoundItems()

            DataGridViewTopVCCDetails_VCCOrders.HideRowSelection()

            Dictionary = DataGridViewTopVCCDetails_VCCOrders.GetAllRowsRowHandlesAndDataBoundItems()

            For Each MediaManagerPODetail In DataGridViewPODetails_PODetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.MediaManager.MediaManagerPODetail)

                For Each Item In Dictionary

                    If DirectCast(Item.Value, AdvantageFramework.MediaManager.Classes.VCCOrder).PONumber = MediaManagerPODetail.PONumber Then

                        DataGridViewTopVCCDetails_VCCOrders.CurrentView.SelectRow(Item.Key)

                        If SelectedRowHandle Is Nothing Then

                            For Each RowHandlesAndDataBoundItem In RowHandlesAndDataBoundItems

                                DataGridViewTopVCCDetails_VCCOrders.CurrentView.UnselectRow(RowHandlesAndDataBoundItem.Key)

                            Next

                            SelectedRowHandle = Item.Key

                        End If

                        DataGridViewTopVCCDetails_VCCOrders.CurrentView.SelectRow(Item.Key)

                        Exit For

                    End If

                Next

            Next

            DataGridViewTopVCCDetails_VCCOrders.CurrentView.EndUpdate()

            If SelectedRowHandle IsNot Nothing Then

                DataGridViewTopVCCDetails_VCCOrders.CurrentView.FocusedRowHandle = SelectedRowHandle
                DataGridViewTopVCCDetails_VCCOrders.CurrentView.MakeRowVisible(SelectedRowHandle)

            End If

            TabControlVCCDetails_Details.SelectedTab.Tag = False

            LoadVCCTabItems()

        End Sub
        Private Sub SetAutoFillDependentProperties(ByVal SelectedItems As IEnumerable)

            Dim UniqueOrderNumbers() As Integer = Nothing
            Dim UniqueJobCompNumbers() As String = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim MediaManagerReviewDetailList As Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail) = Nothing
            Dim MediaManagerReviewDetailJobCompList As Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail) = Nothing
            Dim SelectedMediaManagerReviewDetail As AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail = Nothing
            Dim CampaignList As Generic.List(Of AdvantageFramework.Database.Entities.Campaign) = Nothing
            Dim MarketList As Generic.List(Of AdvantageFramework.Database.Entities.Market) = Nothing
            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing

            UniqueOrderNumbers = (From Entity In SelectedItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail)()
                                  Select Entity.OrderNumber).Distinct.ToArray

            UniqueJobCompNumbers = (From Entity In SelectedItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail)()
                                    Where Entity.JobNumber.HasValue AndAlso
                                          Entity.JobComponentNumber.HasValue
                                    Select Entity.JobNumber.Value & "|" & Entity.JobComponentNumber.Value).Distinct.ToArray

            BindingSource = DataGridViewOrderDetails_OrderDetails.DataSource

            MediaManagerReviewDetailList = BindingSource.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).Where(Function(Entity) Not Entity.Cancelled AndAlso UniqueOrderNumbers.Contains(Entity.OrderNumber)).ToList

            MediaManagerReviewDetailJobCompList = (From Entity In BindingSource.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail)
                                                   Where Not Entity.Cancelled AndAlso
                                                         Not Entity.IsOrderClosed AndAlso
                                                         Entity.JobNumber.HasValue AndAlso
                                                         Entity.JobComponentNumber.HasValue AndAlso
                                                         UniqueJobCompNumbers.Contains(Entity.JobNumber.Value & "|" & Entity.JobComponentNumber.Value)).ToList

            SelectedMediaManagerReviewDetail = DirectCast(SelectedItems(0), AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail)

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                For Each MediaManagerReviewDetail In MediaManagerReviewDetailJobCompList

                    MediaManagerReviewDetail.JobMediaBillDate = SelectedMediaManagerReviewDetail.JobMediaBillDate

                    MediaManagerReviewDetail.DbContext = DbContext
                    MediaManagerReviewDetail.ValidateEntity(Nothing)

                Next

                CampaignList = AdvantageFramework.Database.Procedures.Campaign.Load(DbContext).ToList
                MarketList = AdvantageFramework.Database.Procedures.Market.Load(DbContext).ToList

                For Each MediaManagerReviewDetail In MediaManagerReviewDetailList

                    If MediaManagerReviewDetail.CampaignID.HasValue Then

                        MediaManagerReviewDetail.CampaignCode = CampaignList.Where(Function(Entity) Entity.ID = MediaManagerReviewDetail.CampaignID).Select(Function(Entity) Entity.Code).FirstOrDefault
                        MediaManagerReviewDetail.CampaignName = CampaignList.Where(Function(Entity) Entity.ID = MediaManagerReviewDetail.CampaignID).Select(Function(Entity) Entity.Name).FirstOrDefault
                        MediaManagerReviewDetail.CampaignStartDate = CampaignList.Where(Function(Entity) Entity.ID = MediaManagerReviewDetail.CampaignID).Select(Function(Entity) Entity.StartDate).FirstOrDefault
                        MediaManagerReviewDetail.CampaignEndDate = CampaignList.Where(Function(Entity) Entity.ID = MediaManagerReviewDetail.CampaignID).Select(Function(Entity) Entity.EndDate).FirstOrDefault

                    End If

                    If MediaManagerReviewDetail.JobNumber.HasValue Then

                        Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, MediaManagerReviewDetail.JobNumber.Value)

                        If Job IsNot Nothing Then

                            MediaManagerReviewDetail.JobDescription = Job.Description

                        End If

                    End If

                    If MediaManagerReviewDetail.JobComponentNumber.HasValue Then

                        JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, MediaManagerReviewDetail.JobNumber.Value, MediaManagerReviewDetail.JobComponentNumber.Value)

                        If JobComponent IsNot Nothing Then

                            MediaManagerReviewDetail.JobCompDescription = JobComponent.Description

                        End If

                    End If

                    If Not String.IsNullOrWhiteSpace(MediaManagerReviewDetail.MarketCode) Then

                        MediaManagerReviewDetail.MarketDescription = MarketList.Where(Function(Entity) Entity.Code = MediaManagerReviewDetail.MarketCode).Select(Function(Entity) Entity.Description).FirstOrDefault

                    End If

                    MediaManagerReviewDetail.DbContext = DbContext
                    MediaManagerReviewDetail.ValidateEntity(Nothing)

                Next

            End Using

            DataGridViewOrderDetails_OrderDetails.CurrentView.RefreshData()

            DataGridViewOrderDetails_OrderDetails.SetUserEntryChanged()

            EnableOrDisableActions()

        End Sub
        Private Sub RefreshForm()

            'objects
            Dim VCCOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.VCCOrder) = Nothing

            If TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_VCCDetails) Then

                VCCOrders = DataGridViewTopVCCDetails_VCCOrders.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.VCCOrder).ToList

                RefreshVCCOrders(VCCOrders)

            Else

                TabControlForm_ReviewItems.SelectedTab.Tag = False

                LoadTabItems()

            End If

        End Sub
        Private Sub LoadPODetailsTab()

            'objects
            Dim CampaignIDs As IEnumerable(Of Integer) = Nothing
            Dim ClientCodes As IEnumerable(Of String) = Nothing
            Dim ClientDivisionCodes As IEnumerable(Of String) = Nothing
            Dim ClientDivisionProductCodes As IEnumerable(Of String) = Nothing
            Dim JobNumbers As IEnumerable(Of Integer) = Nothing
            Dim JobNumberComponentNumbers As IEnumerable(Of String) = Nothing
            Dim OrderNumbers As IEnumerable(Of Integer) = Nothing
            Dim OrderStatuses As IEnumerable(Of Short) = Nothing
            Dim AEDefaultEmployeeCodes As IEnumerable(Of String) = Nothing
            Dim AEJobEmployeeCodes As IEnumerable(Of String) = Nothing
            Dim VendorCodes As IEnumerable(Of String) = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim LayoutLoaded As Boolean = False
            Dim AFActiveFilterString As String = Nothing
            Dim DictionaryMediaManagerPODetail As System.Collections.Generic.Dictionary(Of String, AdvantageFramework.DTO.Media.MediaManager.MediaManagerPODetail) = Nothing
            Dim MediaManagerPODetail As AdvantageFramework.DTO.Media.MediaManager.MediaManagerPODetail = Nothing
            Dim Keys As IEnumerable(Of String) = Nothing

            Me.ShowWaitForm()

            Select Case _SelectBy

                Case MediaManagerSelectBy.Campaign

                    CampaignIDs = _MediaManagerSearchResults.Where(Function(Entity) Entity.CampaignID.HasValue).Select(Function(Entity) Entity.CampaignID.Value).ToList

                Case MediaManagerSelectBy.Client

                    ClientCodes = _MediaManagerSearchResults.Select(Function(Entity) Entity.ClientCode).ToList

                Case MediaManagerSelectBy.ClientDivision

                    ClientDivisionCodes = _MediaManagerSearchResults.Select(Function(Entity) Entity.ClientCode + "|" + Entity.DivisionCode).ToList

                Case MediaManagerSelectBy.ClientDivisionProduct

                    ClientDivisionProductCodes = _MediaManagerSearchResults.Select(Function(Entity) Entity.ClientCode + "|" + Entity.DivisionCode + "|" + Entity.ProductCode).ToList

                Case MediaManagerSelectBy.Job

                    JobNumbers = _MediaManagerSearchResults.Select(Function(Entity) Entity.JobNumber.Value).ToList

                Case MediaManagerSelectBy.JobComponent

                    JobNumberComponentNumbers = _MediaManagerSearchResults.Select(Function(Entity) CStr(Entity.JobNumber.Value) + "|" + CStr(Entity.JobComponentNumber.Value)).ToList

                Case MediaManagerSelectBy.Order

                    OrderNumbers = _MediaManagerSearchResults.Select(Function(Entity) Entity.OrderNumber.Value).ToList

                Case MediaManagerSelectBy.OrderStatus

                    OrderStatuses = _MediaManagerSearchResults.Select(Function(Entity) Entity.OrderStatus.GetValueOrDefault(0)).ToList

                Case MediaManagerSelectBy.AccountExecutiveDefault

                    AEDefaultEmployeeCodes = _MediaManagerSearchResults.Select(Function(Entity) Entity.EmployeeCode).ToList

                Case MediaManagerSelectBy.AccountExecutiveJob

                    AEJobEmployeeCodes = _MediaManagerSearchResults.Select(Function(Entity) Entity.EmployeeCode).ToList

                Case MediaManagerSelectBy.Vendor

                    VendorCodes = _MediaManagerSearchResults.Select(Function(Entity) Entity.VendorCode).ToList

                Case MediaManagerSelectBy.LastFour

                    OrderNumbers = _MediaManagerSearchResults.Select(Function(Entity) Entity.OrderNumber.Value).ToList

            End Select

            'BindingSource = DataGridViewPODetails_PODetails.DataSource

            'If BindingSource IsNot Nothing AndAlso BindingSource.DataSource IsNot Nothing Then

            '    AFActiveFilterString = DataGridViewPODetails_PODetails.CurrentView.AFActiveFilterString

            '    DictionaryMediaManagerReviewDetail = DataGridViewPODetails_PODetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).ToDictionary(Function(MMRD) MMRD.OrderNumberLineNumber, Function(MMRD) MMRD)

            '    SaveOrderDetailsGridLayout()

            'End If

            DataGridViewPODetails_PODetails.SetBookmarkColumnIndex(-1)
            DataGridViewPODetails_PODetails.ClearGridCustomization()
            DataGridViewPODetails_PODetails.CurrentView.ClearDisabledRows()
            DataGridViewPODetails_PODetails.ClearDatasource(New Generic.List(Of AdvantageFramework.DTO.Media.MediaManager.MediaManagerPODetail))
            DataGridViewPODetails_PODetails.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True

            'LayoutLoaded = AdvantageFramework.WinForm.Presentation.Controls.LoadDataGridViewLayout(Session, DataGridViewPODetails_PODetails, Database.Entities.GridAdvantageType.MediaManagerMediaManagerReviewOrderDetail)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DataGridViewPODetails_PODetails.DataSource = AdvantageFramework.MediaManager.LoadMediaManagerPODetails(DbContext, CampaignIDs, ClientCodes, ClientDivisionCodes, ClientDivisionProductCodes,
                                                                                                JobNumbers, JobNumberComponentNumbers, OrderNumbers, AEDefaultEmployeeCodes, AEJobEmployeeCodes, VendorCodes, False)

            End Using

            If Not LayoutLoaded Then

                'SetColumnDefaultVisibility()

                DataGridViewPODetails_PODetails.CurrentView.ClearSorting()
                DataGridViewPODetails_PODetails.CurrentView.BeginSort()
                DataGridViewPODetails_PODetails.CurrentView.Columns(AdvantageFramework.DTO.Media.MediaManager.MediaManagerPODetail.Properties.PONumber.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Descending
                DataGridViewPODetails_PODetails.CurrentView.EndSort()
                DataGridViewPODetails_PODetails.CurrentView.BestFitColumns()

            Else

                AdvantageFramework.WinForm.Presentation.Controls.SortGridViewBySortedColumns(DataGridViewPODetails_PODetails)

            End If

            DataGridViewPODetails_PODetails.OptionsView.ShowGroupPanel = False

            DataGridViewPODetails_PODetails.CurrentView.AFActiveFilterString = AFActiveFilterString

            'If DictionaryMediaManagerReviewDetail IsNot Nothing AndAlso DictionaryMediaManagerReviewDetail.Count > 0 Then

            '    DataGridViewPODetails_PODetails.CurrentView.BeginSelection()

            '    DataGridViewPODetails_PODetails.CurrentView.ClearSelection()

            '    Keys = (From Entity In DictionaryMediaManagerReviewDetail
            '            Select Entity.Key).ToArray

            '    For Each RowsRowHandlesAndDataBoundItem In DataGridViewPODetails_PODetails.GetAllRowsRowHandlesAndDataBoundItems

            '        If Keys.Contains(DirectCast(RowsRowHandlesAndDataBoundItem.Value, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).OrderNumberLineNumber) Then

            '            DataGridViewPODetails_PODetails.CurrentView.SelectRow(RowsRowHandlesAndDataBoundItem.Key)

            '            DataGridViewPODetails_PODetails.CurrentView.FocusedRowHandle = RowsRowHandlesAndDataBoundItem.Key

            '        End If

            '    Next

            '    DataGridViewPODetails_PODetails.CurrentView.EndSelection()

            'End If

            DataGridViewPODetails_PODetails.CurrentView.OptionsCustomization.AllowColumnMoving = True

            DataGridViewPODetails_PODetails.OptionsMenu.EnableColumnMenu = True

            'For RowHandle As Integer = 0 To DataGridViewPODetails_PODetails.CurrentView.RowCount - 1

            '    MediaManagerReviewDetail = DirectCast(DataGridViewPODetails_PODetails.CurrentView.GetRow(RowHandle), AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail)

            '    MediaManagerReviewDetail.ValidateEntityProperty(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.JobMediaBillDateColumnUpdated.ToString, True, False)

            '    If MediaManagerReviewDetail.IsOrderClosed OrElse MediaManagerReviewDetail.Cancelled OrElse Not String.IsNullOrWhiteSpace(MediaManagerReviewDetail.BillingUser) Then

            '        DataGridViewPODetails_PODetails.CurrentView.DisableRow(DataGridViewPODetails_PODetails.CurrentView.GetDataSourceRowIndex(RowHandle), AdvantageFramework.WinForm.Presentation.Controls.Classes.DisabledRow.RowType.Readonly)

            '    End If

            'Next

            Me.CloseWaitForm()

            TabItemReviewItems_PurchaseOrderDetails.Tag = True

        End Sub
        Private Sub CreateMediaOrderVirtualCreditCards()

            'objects
            Dim VendorCodes As IEnumerable(Of String) = Nothing
            Dim MediaManagerReviewDetails As Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail) = Nothing
            Dim Vendors As Generic.List(Of AdvantageFramework.Database.Entities.Vendor) = Nothing
            Dim VCCCards As Generic.List(Of AdvantageFramework.Database.Entities.VCCCard) = Nothing
            Dim GenerateOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrder) = Nothing
            Dim CardAmount As Decimal = 0
            Dim VCCCardEntity As AdvantageFramework.Database.Entities.VCCCard = Nothing
            Dim VCCGenerateOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrder) = Nothing

            If DataGridViewOrderDetails_OrderDetails.HasASelectedRow AndAlso
                    AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to create virtual credit cards for selected orders?", WinForm.MessageBox.MessageBoxButtons.YesNo,
                                                               MessageBoxDefaultButton:=Windows.Forms.MessageBoxDefaultButton.Button2) = WinForm.MessageBox.DialogResults.Yes Then

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        VendorCodes = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Vendor).Where(Function(Entity) Entity.VCCStatus.HasValue AndAlso
                                                                                                                                Entity.VCCStatus = AdvantageFramework.Database.Entities.VCCStatuses.Accepted AndAlso
                                                                                                                                Entity.SendVCCWithMediaOrder).Select(Function(Entity) Entity.Code).ToArray

                        MediaManagerReviewDetails = (From Entity In DataGridViewOrderDetails_OrderDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail)
                                                     Where Entity.VCCCardID Is Nothing AndAlso
                                                           VendorCodes.Contains(Entity.VendorCode) AndAlso
                                                           Entity.Cancelled = False AndAlso
                                                           Entity.Quote = False And
                                                           Entity.IsOrderClosed = False
                                                     Select Entity).ToList

                        Vendors = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Vendor).ToList
                        VCCCards = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.VCCCard).ToList

                        GenerateOrders = (From MediaManagerReviewDetail In MediaManagerReviewDetails
                                          From Vendor In Vendors.Where(Function(Entity) Entity.Code = MediaManagerReviewDetail.VendorCode).DefaultIfEmpty
                                          From VCCCard In VCCCards.Where(Function(Entity) Entity.OrderNumber = MediaManagerReviewDetail.OrderNumber AndAlso Entity.LineNumber = MediaManagerReviewDetail.LineNumber).DefaultIfEmpty
                                          Select New With {.MediaManagerReviewDetail = MediaManagerReviewDetail, .Vendor = Vendor, .VCCCard = VCCCard}).
                                       Select(Function(OrderGroup) New AdvantageFramework.MediaManager.Classes.GenerateOrder(DbContext, OrderGroup.MediaManagerReviewDetail, OrderGroup.Vendor, OrderGroup.VCCCard)).ToList

                        VCCGenerateOrders = New Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrder)

                        For Each GenerateOrder In GenerateOrders

                            If GenerateOrder.TotalCostPayableToVendor.GetValueOrDefault(0) > 0 Then

                                CardAmount = GenerateOrder.TotalCostPayableToVendor.GetValueOrDefault(0)

                            ElseIf GenerateOrder.VCCLimit.GetValueOrDefault(0) > 0 Then

                                CardAmount = GenerateOrder.VCCLimit.GetValueOrDefault(0)

                            End If

                            If CardAmount > 0 Then

                                Try

                                    VCCCardEntity = AdvantageFramework.Database.Procedures.VCCCard.Load(DbContext).SingleOrDefault(Function(Entity) Entity.OrderNumber = GenerateOrder.OrderNumber AndAlso Entity.LineNumber = GenerateOrder.LineNumber)

                                Catch ex As Exception
                                    VCCCardEntity = Nothing
                                End Try

                                If VCCCardEntity Is Nothing Then

                                    VCCGenerateOrders.Add(GenerateOrder)

                                End If

                            End If

                        Next

                    End Using

                Catch ex As Exception
                    VCCGenerateOrders = New Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrder)
                End Try

                If VCCGenerateOrders IsNot Nothing AndAlso VCCGenerateOrders.Count > 0 Then

                    If AdvantageFramework.VCC.CreateVCCCreditCard(Session, VCCGenerateOrders, 99) Then

                        TabControlForm_ReviewItems.SelectedTab.Tag = False

                        LoadTabItems()

                    End If

                End If

            End If

        End Sub
        Private Sub CreatePurchaseOrderVirtualCreditCards()

            'objects
            Dim VendorCodes As IEnumerable(Of String) = Nothing
            Dim MediaManagerPODetails As Generic.List(Of AdvantageFramework.DTO.Media.MediaManager.MediaManagerPODetail) = Nothing
            Dim Vendors As Generic.List(Of AdvantageFramework.Database.Entities.Vendor) = Nothing
            Dim VCCCardPOs As Generic.List(Of AdvantageFramework.Database.Entities.VCCCardPO) = Nothing
            Dim MediaManagerGeneratePurchaseOrders As Generic.List(Of AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrder) = Nothing
            Dim VCCCardPOEntity As AdvantageFramework.Database.Entities.VCCCardPO = Nothing
            Dim VCCMediaManagerGeneratePurchaseOrderVendorContacts As Generic.List(Of AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrderVendorContact) = Nothing

            If DataGridViewPODetails_PODetails.HasASelectedRow AndAlso
                    AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to create virtual credit cards for selected purchase orders?", WinForm.MessageBox.MessageBoxButtons.YesNo,
                                                               MessageBoxDefaultButton:=Windows.Forms.MessageBoxDefaultButton.Button2) = WinForm.MessageBox.DialogResults.Yes Then

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        VendorCodes = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Vendor).Where(Function(Entity) Entity.VCCStatus.HasValue AndAlso
                                                                                                                                Entity.VCCStatus = AdvantageFramework.Database.Entities.VCCStatuses.Accepted AndAlso
                                                                                                                                Entity.SendVCCWithMediaOrder).Select(Function(Entity) Entity.Code).ToArray

                        MediaManagerPODetails = (From Entity In DataGridViewPODetails_PODetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.MediaManager.MediaManagerPODetail)
                                                 Where Entity.VCCCardPOID Is Nothing AndAlso
                                                       VendorCodes.Contains(Entity.VendorCode)
                                                 Select Entity).ToList

                        Vendors = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Vendor).ToList
                        VCCCardPOs = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.VCCCardPO).ToList

                        MediaManagerGeneratePurchaseOrders = (From MediaManagerPODetail In MediaManagerPODetails
                                                              From Vendor In Vendors.Where(Function(Entity) Entity.Code = MediaManagerPODetail.VendorCode).DefaultIfEmpty
                                                              From VCCCardPO In VCCCardPOs.Where(Function(Entity) Entity.PONumber = MediaManagerPODetail.PONumber).DefaultIfEmpty
                                                              Select New With {.MediaManagerPODetai = MediaManagerPODetail, .Vendor = Vendor, .VCCCardPO = VCCCardPO}).
                                       Select(Function(OrderGroup) New AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrder(DbContext, OrderGroup.MediaManagerPODetai, OrderGroup.Vendor, OrderGroup.VCCCardPO)).ToList

                        VCCMediaManagerGeneratePurchaseOrderVendorContacts = New Generic.List(Of AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrderVendorContact)

                        For Each MediaManagerGeneratePurchaseOrder In MediaManagerGeneratePurchaseOrders

                            If MediaManagerGeneratePurchaseOrder.POAmount > 0 Then

                                Try

                                    VCCCardPOEntity = AdvantageFramework.Database.Procedures.VCCCardPO.Load(DbContext).SingleOrDefault(Function(Entity) Entity.PONumber = MediaManagerGeneratePurchaseOrder.PONumber)

                                Catch ex As Exception
                                    VCCCardPOEntity = Nothing
                                End Try

                                If VCCCardPOEntity Is Nothing Then

                                    VCCMediaManagerGeneratePurchaseOrderVendorContacts.Add(New AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrderVendorContact(MediaManagerGeneratePurchaseOrder))

                                End If

                            End If

                        Next

                    End Using

                Catch ex As Exception
                    VCCMediaManagerGeneratePurchaseOrderVendorContacts = New Generic.List(Of AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrderVendorContact)
                End Try

                If VCCMediaManagerGeneratePurchaseOrderVendorContacts IsNot Nothing AndAlso VCCMediaManagerGeneratePurchaseOrderVendorContacts.Count > 0 Then

                    If AdvantageFramework.VCC.CreateVCCCreditCard(Session, VCCMediaManagerGeneratePurchaseOrderVendorContacts, 99) Then

                        TabControlForm_ReviewItems.SelectedTab.Tag = False

                        LoadTabItems()

                    End If

                End If

            End If

        End Sub
        Private Function IsImportFormOpen() As Boolean

            'objects
            Dim IsOpen As Boolean = False

            For Each MdiChildForm In CType(_ParentForm.MdiParent, AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm).MdiChildren

                If MdiChildForm.GetType Is GetType(AdvantageFramework.Importing.Presentation.ImportForm) Then

                    IsOpen = True
                    Exit For

                End If

            Next

            IsImportFormOpen = IsOpen

        End Function
        Private Sub ExportXMLFiles(AsNew As Boolean)

            Dim MediaManagerReviewDetails As Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail) = Nothing
            Dim VendorCodes As IEnumerable(Of String) = Nothing
            Dim OrderNumbers As IEnumerable(Of Integer) = Nothing
            Dim Vendors As Generic.List(Of AdvantageFramework.Database.Entities.Vendor) = Nothing
            Dim VCCCards As Generic.List(Of AdvantageFramework.Database.Entities.VCCCard) = Nothing
            Dim GenerateOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrder) = Nothing
            Dim IsAgency As Boolean = False
            Dim Folder As String = Nothing
            Dim ZipFile As Ionic.Zip.ZipFile = Nothing
            Dim Process As Boolean = True
            Dim GenerateOrder As AdvantageFramework.MediaManager.Classes.GenerateOrder = Nothing
            Dim VendorEntity As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim FileName As String = Nothing
            Dim FileStream As System.IO.FileStream = Nothing

            Me.SetFormActionAndShowWaitForm(WinForm.Presentation.Methods.FormActions.Saving)

            MediaManagerReviewDetails = DataGridViewOrderDetails_OrderDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).ToList

            VendorCodes = MediaManagerReviewDetails.Select(Function(Entity) Entity.VendorCode).Distinct.ToArray
            OrderNumbers = MediaManagerReviewDetails.Select(Function(Entity) Entity.OrderNumber).Distinct.ToArray

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    IsAgency = AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

                    Vendors = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Vendor).Where(Function(Entity) VendorCodes.Contains(Entity.Code) = True).ToList
                    VCCCards = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.VCCCard).ToList

                    GenerateOrders = (From MediaManagerReviewDetail In MediaManagerReviewDetails
                                      From Vendor In Vendors.Where(Function(Entity) Entity.Code = MediaManagerReviewDetail.VendorCode).DefaultIfEmpty
                                      From VCCCard In VCCCards.Where(Function(Entity) Entity.OrderNumber = MediaManagerReviewDetail.OrderNumber AndAlso Entity.LineNumber = MediaManagerReviewDetail.LineNumber).DefaultIfEmpty
                                      Select New With {.MediaManagerReviewDetail = MediaManagerReviewDetail, .Vendor = Vendor, .VCCCard = VCCCard}).
                                                       Select(Function(OrderGroup) New AdvantageFramework.MediaManager.Classes.GenerateOrder(DbContext, OrderGroup.MediaManagerReviewDetail, OrderGroup.Vendor, OrderGroup.VCCCard)).ToList

                    If (From Entity In AdvantageFramework.Database.Procedures.BroadcastImportCrossReference.Load(DbContext)
                        Where OrderNumbers.Contains(Entity.OrderNumber) AndAlso
                              Entity.ImportedFrom = "AW").Any Then

                        If IsAgency Then

                            Folder = AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext)

                            Folder = System.IO.Path.Combine(Folder, "Reports", "Media") & "\"

                            If System.IO.Directory.Exists(Folder) = False Then

                                System.IO.Directory.CreateDirectory(Folder)

                            End If

                            ZipFile = New Ionic.Zip.ZipFile

                        Else

                            If AdvantageFramework.WinForm.Presentation.BrowseForFolder(Folder) = False Then

                                Process = False

                            Else

                                Folder = Folder & "\"

                            End If

                        End If

                    End If

                    If Process Then

                        For Each OrderNumber In OrderNumbers

                            GenerateOrder = GenerateOrders.Where(Function(GO) GO.OrderNumber = OrderNumber).FirstOrDefault

                            If GenerateOrder IsNot Nothing AndAlso GenerateOrder.MediaFrom = "TV" Then

                                If (From Entity In AdvantageFramework.Database.Procedures.BroadcastImportCrossReference.Load(DbContext)
                                    Where Entity.OrderNumber = GenerateOrder.OrderNumber AndAlso
                                          Entity.ImportedFrom = "AW").Any Then

                                    'VendorReps.Clear()
                                    'For Each VR In (From Entity In AdvantageFramework.Database.Procedures.MediaManagerGeneratedReportSentInfo.LoadByOrderNumber(DbContext, OrderNumber)
                                    '                Select Entity.VendorCode, Entity.VendorRepresentativeCode).Distinct.ToList
                                    '    VendorReps.Add(New AdvantageFramework.MediaManager.Classes.GenerateOrderVendorRep(VR.VendorCode, VR.VendorRepresentativeCode))
                                    'Next

                                    VendorEntity = Vendors.Where(Function(V) V.Code = GenerateOrder.VendorCode).SingleOrDefault

                                    If VendorEntity IsNot Nothing AndAlso VendorEntity.IsCableSystem AndAlso VendorEntity.NCCTVSyscodeID.HasValue Then

                                        If AsNew = False Then

                                            MemoryStream = AdvantageFramework.Media.BuildXMLFile(Session, DbContext, DataContext, GenerateOrder.OrderNumber, New Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrderVendorRep), GenerateOrder.VendorCode)

                                            FileName = Replace(Replace("Order_" & GenerateOrder.ClientName & "_" & GenerateOrder.Vendor & "_" & GenerateOrder.OrderNumber & ".SCX", "\", ""), "/", "")

                                            If IsAgency Then

                                                If OrderNumbers.Count > 1 Then

                                                    ZipFile.AddEntry(FileName, MemoryStream.ToArray)

                                                Else

                                                    FileStream = New System.IO.FileStream(Folder & FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write)
                                                    MemoryStream.WriteTo(FileStream)
                                                    FileStream.Close()

                                                    SendASPDownloadEmail(Folder & FileName)

                                                End If

                                            Else

                                                FileStream = New System.IO.FileStream(Folder & FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write)
                                                MemoryStream.WriteTo(FileStream)
                                                FileStream.Close()

                                            End If

                                        End If

                                    Else

                                        MemoryStream = AdvantageFramework.Media.BuildBroadcastXMLFile(Session, DbContext, DataContext, GenerateOrder.OrderNumber, GenerateOrder.MediaFrom, Nothing, AsNew)

                                        FileName = Replace(Replace("Order_" & GenerateOrder.ClientName & "_" & GenerateOrder.Vendor & "_" & GenerateOrder.OrderNumber & ".XML", "\", ""), "/", "")

                                        If IsAgency Then

                                            If OrderNumbers.Count > 1 Then

                                                ZipFile.AddEntry(FileName, MemoryStream.ToArray)

                                            Else

                                                FileStream = New System.IO.FileStream(Folder & FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write)
                                                MemoryStream.WriteTo(FileStream)
                                                FileStream.Close()

                                                SendASPDownloadEmail(Folder & FileName)

                                            End If

                                        Else

                                            FileStream = New System.IO.FileStream(Folder & FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write)
                                            MemoryStream.WriteTo(FileStream)
                                            FileStream.Close()

                                        End If

                                    End If

                                End If

                            End If

                        Next

                        If IsAgency AndAlso ZipFile IsNot Nothing AndAlso ZipFile.Entries.Count > 1 Then

                            FileName = Folder & Session.UserCode & Now.ToString("yyyyMMddHmmss") & ".zip"

                            ZipFile.Save(FileName)
                            ZipFile.Dispose()

                            SendASPDownloadEmail(Folder & FileName)

                        End If

                    End If

                End Using

            End Using

            Me.SetFormActionAndShowWaitForm(WinForm.Presentation.Methods.FormActions.None)

        End Sub
        Private Sub SendASPDownloadEmail(FileName As String)

            If Not AdvantageFramework.Email.SendASPReportDownloadEmail(Session, FileName) Then

                AdvantageFramework.WinForm.MessageBox.Show("File exported successfully but email link could not be sent to your email.")

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Export file created successfully and also email link has been sent to you email.")

            End If

        End Sub

#Region "  Show Form Methods "

        'Public Shared Function ShowFormDialog(ByVal SelectBy As Short, ByVal MediaManagerSearchResults As IEnumerable(Of AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult)) As System.Windows.Forms.DialogResult

        '    'objects
        '    Dim MediaManagerReviewDialog As AdvantageFramework.Media.Presentation.MediaManagerReviewDialog = Nothing

        '    MediaManagerReviewDialog = New AdvantageFramework.Media.Presentation.MediaManagerReviewDialog(SelectBy, MediaManagerSearchResults)

        '    ShowFormDialog = MediaManagerReviewDialog.ShowDialog()

        'End Function
        Public Shared Sub ShowForm(ByVal BaseFormParent As AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm,
                                   ByVal SelectBy As Short, ByVal MediaManagerSearchResults As IEnumerable(Of AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult))

            Dim MediaManagerReviewDialog As AdvantageFramework.Media.Presentation.MediaManagerReviewDialog = Nothing

            MediaManagerReviewDialog = New AdvantageFramework.Media.Presentation.MediaManagerReviewDialog(SelectBy, MediaManagerSearchResults, BaseFormParent)

            MediaManagerReviewDialog.SetBaseFormParent(BaseFormParent, MediaManagerReviewDialog)

            MediaManagerReviewDialog.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaManagerReviewDialog_Activated(sender As Object, e As EventArgs) Handles Me.Activated

            If _ImportWasLaunched Then

                If Not IsImportFormOpen() Then

                    _ImportWasLaunched = False

                    If ButtonItemActions_Refresh.Enabled Then

                        ButtonItemActions_Refresh.RaiseClick()

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("Cannot refresh due to active changes.")

                    End If

                End If

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub MediaManagerReviewDialog_ClearChangedEvent() Handles Me.ClearChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub MediaManagerReviewDialog_FormClosing(sender As Object, e As Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing

            If e.CloseReason = Windows.Forms.CloseReason.UserClosing Then

                SaveOrderDetailsGridLayout()

                BindingSource = DataGridViewTopVCCDetails_VCCOrders.DataSource

                If BindingSource IsNot Nothing AndAlso BindingSource.DataSource IsNot Nothing Then

                    SaveVCCDetailsGridLayout()

                End If

            End If

        End Sub
        Private Sub MediaManagerReviewDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Dim DBTimezoneID As String = String.Empty

            ButtonItemGridOptionsOrderDetails_ChooseColumns.Image = AdvantageFramework.My.Resources.ColumnImage
            ButtonItemGridOptionsOrderDetails_RestoreDefaults.Image = AdvantageFramework.My.Resources.RestoreDefaultsImage

            ButtonItemGridOptionsVCCDetails_ChooseColumns.Image = AdvantageFramework.My.Resources.ColumnImage
            ButtonItemGridOptionsVCCDetails_RestoreDefaults.Image = AdvantageFramework.My.Resources.RestoreDefaultsImage

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemActions_SendReminders.Image = AdvantageFramework.My.Resources.EmailNewImage
            ButtonItemActions_AutoFill.Image = AdvantageFramework.My.Resources.AutoFillImage
            ButtonItemActions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage
            ButtonItemActions_FollowUp.Image = AdvantageFramework.My.Resources.ActivityEditImage
            ButtonItemOrders_AdServing.Image = AdvantageFramework.My.Resources.AdServerImage

            ButtonItemOrders_GenerateOrders.Image = AdvantageFramework.My.Resources.MediaAddImage
            ButtonItemOrders_UpdateCost.Image = AdvantageFramework.My.Resources.UpdateImage
            ButtonItemOrders_ProcessControl.Image = AdvantageFramework.My.Resources.JobProcessControlImage
            ButtonItemOrders_WriteUpDown.Image = AdvantageFramework.My.Resources.WriteoffImage
            ButtonItemOrders_CreateRevision.Image = AdvantageFramework.My.Resources.RevisionImage

            ButtonItemVendorInvoices_ApproveInvoices.Image = AdvantageFramework.My.Resources.AccountsPayableLineItemDetailsImage
            ButtonItemVendorInvoices_CreateInvoices.Image = AdvantageFramework.My.Resources.AccountsPayableImage
            ButtonItemVendorInvoices_ImportInvoices.Image = AdvantageFramework.My.Resources.DatabaseImportImage
            ButtonItemVendorInvoices_ImportInvoices.SecurityEnabled = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.FinanceAccounting_AccountsPayable_AP_ExpenseReport_Import)

            ButtonItemVendorPayments_ManageVCC.Image = AdvantageFramework.My.Resources.CreditCardImage
            ButtonItemVendorPayments_CreateVCC.Image = AdvantageFramework.My.Resources.CreditCardAddImage

            ButtonItemBillingApproval_Approve.Image = AdvantageFramework.My.Resources.ApproveImage
            ButtonItemBillingApproval_Unapprove.Image = AdvantageFramework.My.Resources.UnapproveImage

            ButtonItemVendor_Edit.Image = AdvantageFramework.My.Resources.VendorImage

            ButtonItemVendorReps_Add.Image = AdvantageFramework.My.Resources.DetailAddImage
            ButtonItemVendorReps_Edit.Image = AdvantageFramework.My.Resources.EditImage
            ButtonItemVendorReps_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage

            ButtonItemDocuments_Download.Image = AdvantageFramework.My.Resources.DownloadDocument
            ButtonItemDocuments_UploadOrder.Image = AdvantageFramework.My.Resources.UpdateImage
            ButtonItemUploadOrder_EmailLink.Icon = AdvantageFramework.My.Resources.EmailSendIcon
            ButtonItemDocuments_UploadJob.Image = AdvantageFramework.My.Resources.UpdateImage
            ButtonItemUploadJob_EmailLink.Icon = AdvantageFramework.My.Resources.EmailSendIcon
            ButtonItemDocuments_UploadJobComponent.Image = AdvantageFramework.My.Resources.UpdateImage
            ButtonItemUploadJobComponent_EmailLink.Icon = AdvantageFramework.My.Resources.EmailSendIcon
            ButtonItemDocuments_UploadCampaign.Image = AdvantageFramework.My.Resources.UpdateImage
            ButtonItemUploadCampaign_EmailLink.Icon = AdvantageFramework.My.Resources.EmailSendIcon
            ButtonItemDocuments_Upload.Image = AdvantageFramework.My.Resources.UpdateImage
            ButtonItemUpload_EmailLink.Icon = AdvantageFramework.My.Resources.EmailSendIcon
            ButtonItemDocuments_OpenURL.Image = AdvantageFramework.My.Resources.Link

            ButtonItemFilter_All.Image = AdvantageFramework.My.Resources.TableSelectedAllImage
            ButtonItemFilter_SelectedLineItem.Image = AdvantageFramework.My.Resources.TableSelectedRowImage

            ButtonItemFilter_SelectedLineItem.Checked = True

            ButtonItemMediaPlan_Actualize.Image = AdvantageFramework.My.Resources.UpdateImage

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            _ToolTipController = New DevExpress.Utils.ToolTipController()
            DataGridViewOrderDetails_OrderDetails.GridControl.ToolTipController = _ToolTipController

            DataGridViewOrderDetails_OrderDetails.ShowSelectDeselectAllButtons = True

            DataGridViewOrderDetails_OrderDetails.CurrentView.OptionsLayout.StoreDataSettings = True
            DataGridViewOrderDetails_OrderDetails.CurrentView.OptionsLayout.StoreAppearance = True
            DataGridViewOrderDetails_OrderDetails.CurrentView.OptionsLayout.StoreVisualOptions = True

            DataGridViewOrderDetails_OrderDetails.CurrentView.OptionsLayout.Columns.StoreAllOptions = True
            DataGridViewOrderDetails_OrderDetails.CurrentView.OptionsLayout.Columns.StoreAppearance = True

            DataGridViewOrderDetails_OrderDetails.AddFixedColumnCheckItemsToGridMenu = True
            DataGridViewOrderDetails_OrderDetails.CurrentView.EnableDisabledRows = True

            DataGridViewPODetails_PODetails.ShowSelectDeselectAllButtons = True

            DataGridViewOrderStatus_OrderStatus.ClearDatasource(New Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerOrderStatus))
            DataGridViewOrderStatus_OrderStatus.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True

            DataGridViewOrderComments_OrderComments.ShowSelectDeselectAllButtons = True
            DataGridViewLineComments_LineComments.ShowSelectDeselectAllButtons = True

            DataGridViewVendorReps_VendorReps.ByPassUserEntryChanged = True

            DataGridViewTopVCCDetails_VCCOrders.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            DataGridViewTopVCCDetails_VCCOrders.ShowSelectDeselectAllButtons = True

            DataGridViewBottomVCCDetails_CardDetails.DataSource = New Generic.List(Of AdvantageFramework.MediaManager.Classes.VCCDetail)

            DataGridViewBottomVCCDetails_CardNotes.ByPassUserEntryChanged = True
            DataGridViewBottomVCCDetails_CardNotes.UseEmbeddedNavigator = True

            ButtonItemOrders_ProcessControl.SecurityEnabled = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.Media_OrderProcessCtrl)

            _CanUpdate = AdvantageFramework.Security.CanUserUpdateInModule(Me.Session, AdvantageFramework.Security.Modules.Media_MediaManager)

            ButtonItemActions_Save.SecurityEnabled = _CanUpdate
            Me.ShowUnsavedChangesOnFormClosing = _CanUpdate

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) = False Then

                    ButtonItemDocuments_Upload.SubItems.Remove(ButtonItemUpload_EmailLink)
                    ButtonItemDocuments_Upload.SplitButton = False

                    ButtonItemDocuments_UploadOrder.SubItems.Remove(ButtonItemUploadOrder_EmailLink)
                    ButtonItemDocuments_UploadOrder.SplitButton = False

                    ButtonItemDocuments_UploadJob.SubItems.Remove(ButtonItemUploadJob_EmailLink)
                    ButtonItemDocuments_UploadJob.SplitButton = False

                    ButtonItemDocuments_UploadJobComponent.SubItems.Remove(ButtonItemUploadJobComponent_EmailLink)
                    ButtonItemDocuments_UploadJobComponent.SplitButton = False

                    ButtonItemDocuments_UploadCampaign.SubItems.Remove(ButtonItemUploadCampaign_EmailLink)
                    ButtonItemDocuments_UploadCampaign.SplitButton = False

                End If

            End Using

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                _TimezoneOffset = AdvantageFramework.VCC.GetTimezoneOffset(DbContext)

                Try

                    DBTimezoneID = DbContext.Database.SqlQuery(Of String)("SELECT DB_TIMEZONE_ID FROM dbo.AGENCY").FirstOrDefault

                Catch ex As Exception
                    DBTimezoneID = String.Empty
                End Try

            End Using

            Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                _AdServingEnabled = AdvantageFramework.DoubleClick.IsDoubleClickEnabledByAgencyOrAnyClient(DataContext)

            End Using

            ButtonItemVendorInvoices_ApproveInvoices.SecurityEnabled = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.Media_MediaManager_Actions_ApproveInvoices)
            ButtonItemOrders_GenerateOrders.SecurityEnabled = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.Media_MediaManager_Actions_GenerateOrders)
            ButtonItemVendorPayments_CreateVCC.SecurityEnabled = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.Media_MediaManager_Actions_CreateVCC)
            ButtonItemOrders_UpdateCost.SecurityEnabled = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.Media_MediaManager_Actions_UpdateCost)
            ButtonItemVendorInvoices_CreateInvoices.SecurityEnabled = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.Media_MediaManager_Actions_CreateAP)
            ButtonItemVendorPayments_ManageVCC.SecurityEnabled = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.Media_MediaManager_Actions_VirtualCC) AndAlso
                    String.IsNullOrWhiteSpace(DBTimezoneID) = False

            ButtonItemOrders_WriteUpDown.SecurityEnabled = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.Media_MediaManager_Actions_WriteUpDown)
            ButtonItemOrders_AdServing.SecurityEnabled = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.Media_MediaManager_Actions_AdServing)

            RibbonBarOptions_BillingApproval.SecurityEnabled = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.Media_MediaManager_Actions_BillingApproval)
            RibbonBarOptions_VendorReps.SecurityEnabled = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.Maintenance_Media_VendorRep)

            ButtonItemVendor_Edit.SecurityEnabled = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.Maintenance_Accounting_Vendor)

            ButtonItemMediaPlan_Actualize.SecurityEnabled = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.Media_DigitalCampaignManager)

            _HasAccessToVendorRep = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.Maintenance_Media_VendorRep)
            _CanUserUpdateVendorReps = AdvantageFramework.Security.CanUserUpdateInModule(Me.Session, AdvantageFramework.Security.Modules.Maintenance_Media_VendorRep)
            _CanUserAddVendorReps = AdvantageFramework.Security.CanUserAddInModule(Me.Session, AdvantageFramework.Security.Modules.Maintenance_Media_VendorRep)

            _CanUserUpdateCostForBroadcast = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.Media_MediaManager_Actions_UpdateCostForBroadcast)

            ButtonItemVendorInvoices_OneInvoicePerVendor.Visible = False

            TabItemReviewItems_VCCDetails.Visible = False

            If _ObjectTypePropertyDescriptors Is Nothing Then

                _ObjectTypePropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail)).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList()

            End If

            _SubItemNumericInputCPL = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemNumericInput(Me.Session, WinForm.Presentation.Controls.SubItemNumericInput.Type.Decimal, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.NewspaperCirculationQTY.ToString, "n2", True, GetType(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail), Nothing)
            _SubItemNumericInputCPL.SetFormatString("#,###.00")
            _SubItemNumericInputCPL.MinValue = 0
            _SubItemNumericInputCPL.MaxValue = 9999.99

            _SubItemNumericInputCPM = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemNumericInput(Me.Session, WinForm.Presentation.Controls.SubItemNumericInput.Type.Decimal, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.NewspaperCirculationQTY.ToString, "n0", True, GetType(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail), Nothing)
            _SubItemNumericInputCPM.SetFormatString("###,###,###")
            _SubItemNumericInputCPM.MinValue = 0
            _SubItemNumericInputCPM.MaxValue = 999999999

            Me.WindowState = Windows.Forms.FormWindowState.Maximized

        End Sub
        Private Sub MediaManagerReviewDialog_Resize(sender As Object, e As EventArgs) Handles Me.Resize

            ResizeControlToFitParent(DataGridViewBottomVCCDetails_CardDetails)
            ResizeControlToFitParent(DataGridViewBottomVCCDetails_CardNotes)

        End Sub
        Private Sub MediaManagerReviewDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            LoadTabItems()

            Me.FormAction = WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub MediaManagerReviewDialog_UserEntryChangedEvent(Control As AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub _ToolTipController_GetActiveObjectInfo(ByVal sender As Object, ByVal e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs) Handles _ToolTipController.GetActiveObjectInfo

            'objects
            Dim ToolTipControlInfo As DevExpress.Utils.ToolTipControlInfo = Nothing
            Dim GridView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            Dim GridHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = Nothing
            Dim RowValue As Object = Nothing
            Dim ToolTipText As String = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

            If e.SelectedControl Is DataGridViewOrderDetails_OrderDetails.GridControl Then

                Try

                    GridView = CType(DataGridViewOrderDetails_OrderDetails.GridControl.GetViewAt(e.ControlMousePosition), DevExpress.XtraGrid.Views.Grid.GridView)

                    If GridView IsNot Nothing Then

                        GridHitInfo = GridView.CalcHitInfo(e.ControlMousePosition)

                        If GridHitInfo.InRowCell AndAlso DataGridViewOrderDetails_OrderDetails.CurrentView.GetRowCellValue(GridHitInfo.RowHandle, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.IsOrderClosed.ToString) = True Then

                            RowValue = "Order is closed."

                            ToolTipText = RowValue

                        ElseIf GridHitInfo.InRowCell AndAlso DataGridViewOrderDetails_OrderDetails.CurrentView.GetRowCellValue(GridHitInfo.RowHandle, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.Cancelled.ToString) = True Then

                            RowValue = "Order Line is cancelled."

                            ToolTipText = RowValue

                        ElseIf GridHitInfo.InRowCell AndAlso Not String.IsNullOrWhiteSpace(DataGridViewOrderDetails_OrderDetails.CurrentView.GetRowCellValue(GridHitInfo.RowHandle, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.BillingUser.ToString)) Then

                            RowValue = "Order Line is selected for billing."

                            ToolTipText = RowValue

                        ElseIf GridHitInfo.InRowCell AndAlso GridHitInfo.Column.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.HasBillingApprovalStatus.ToString Then

                            Try

                                RowValue = DataGridViewOrderDetails_OrderDetails.CurrentView.GetRowCellValue(GridHitInfo.RowHandle, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.BillingApprovedDateBy.ToString)

                            Catch ex As Exception

                            End Try

                            ToolTipText = RowValue

                        ElseIf GridHitInfo.InRowCell Then

                            If _ObjectTypePropertyDescriptors Is Nothing Then

                                _ObjectTypePropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail)).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList()

                            End If

                            Try

                                PropertyDescriptor = (From [Property] In _ObjectTypePropertyDescriptors
                                                      Where [Property].Name = GridHitInfo.Column.FieldName
                                                      Select [Property]).SingleOrDefault

                            Catch ex As Exception
                                PropertyDescriptor = Nothing
                            End Try

                            If PropertyDescriptor IsNot Nothing AndAlso PropertyDescriptor.PropertyType Is GetType(String) Then

                                RowValue = DataGridViewOrderDetails_OrderDetails.CurrentView.GetRowCellValue(GridHitInfo.RowHandle, GridHitInfo.Column.FieldName)

                            End If

                            ToolTipText = RowValue

                        End If

                        If String.IsNullOrEmpty(ToolTipText) = False Then

                            ToolTipControlInfo = New DevExpress.Utils.ToolTipControlInfo(RowValue, ToolTipText)

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
        Private Sub ApInvoiceControlAPInvoiceDetail_APInvoiceDetail_SelectedDocumentChanged() Handles ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.SelectedDocumentChanged

            EnableOrDisableActions()

        End Sub
        Private Sub ApInvoiceControlAPInvoiceDetail_APInvoiceDetail_SelectedTabChanged() Handles ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.SelectedTabChanged

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemVendorInvoices_ApproveInvoices_Click(sender As Object, e As EventArgs) Handles ButtonItemVendorInvoices_ApproveInvoices.Click

            'objects
            Dim OrderNumberLineNumbers As IEnumerable(Of String) = Nothing
            Dim OrderNumber As Integer? = Nothing
            Dim LineNumber As Short? = Nothing
            Dim DictionaryGrid As Dictionary(Of Integer, Object) = Nothing
            Dim DialogResult As System.Windows.Forms.DialogResult = Windows.Forms.DialogResult.None
            Dim OrderUpdated As Boolean = False

            OrderNumberLineNumbers = (From Entity In DataGridViewOrderDetails_OrderDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail)
                                      Select CStr(Entity.OrderNumber) & "|" & CStr(Entity.LineNumber)).ToArray

            DialogResult = AdvantageFramework.Media.Presentation.MediaManagerApproveInvoicesDialog.ShowFormDialog(OrderNumberLineNumbers, OrderNumber, LineNumber, OrderUpdated)

            If OrderUpdated Then

                RefreshForm()

            End If

            If DialogResult = System.Windows.Forms.DialogResult.Abort Then

                DictionaryGrid = DataGridViewOrderDetails_OrderDetails.GetAllSelectedRowsRowHandlesAndDataBoundItems

                For Each RowItem In DictionaryGrid

                    If DirectCast(RowItem.Value, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).OrderNumber = OrderNumber AndAlso
                            DirectCast(RowItem.Value, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).LineNumber = LineNumber Then

                        DataGridViewOrderDetails_OrderDetails.CurrentView.BeginSelection()

                        DataGridViewOrderDetails_OrderDetails.CurrentView.ClearSelection()
                        DataGridViewOrderDetails_OrderDetails.CurrentView.SelectRow(RowItem.Key)
                        DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedRowHandle = RowItem.Key

                        DataGridViewOrderDetails_OrderDetails.CurrentView.EndSelection()

                        Exit For

                    End If

                Next

            End If

        End Sub
        Private Sub ButtonItemActions_AutoFill_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_AutoFill.Click

            'objects
            Dim SelectedItems As IEnumerable = Nothing
            Dim NotVisibleFieldNames As Generic.List(Of String) = Nothing
            Dim ModifiedDictonary As Generic.Dictionary(Of Integer, Object) = Nothing

            If TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_OrderDetails) Then

                DataGridViewOrderDetails_OrderDetails.CurrentView.CloseEditorForUpdating()

                SelectedItems = DataGridViewOrderDetails_OrderDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).Where(Function(RD) RD.Cancelled = False AndAlso String.IsNullOrWhiteSpace(RD.BillingUser) AndAlso RD.IsOrderClosed = False).ToList

                ModifiedDictonary = DataGridViewOrderDetails_OrderDetails.GetAllSelectedRowsRowHandlesAndDataBoundItems()

                NotVisibleFieldNames = (From Column In DataGridViewOrderDetails_OrderDetails.CurrentView.Columns
                                        Where Column.Visible = False
                                        Select Column.FieldName).ToList

                If (From Entity In SelectedItems
                    Select DirectCast(Entity, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).ClientCode).Distinct.Count > 1 Then

                    NotVisibleFieldNames.Add(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.AdNumber.ToString)

                End If

                If (From Entity In SelectedItems
                    Select DirectCast(Entity, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).ClientCode,
                           DirectCast(Entity, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).DivisionCode,
                           DirectCast(Entity, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).ProductCode).Distinct.Count > 1 Then

                    NotVisibleFieldNames.Add(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.CampaignID.ToString)
                    NotVisibleFieldNames.Add(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.JobNumber.ToString)
                    NotVisibleFieldNames.Add(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.JobComponentNumber.ToString)

                End If

                If AdvantageFramework.WinForm.Presentation.AutoFillDialog.ShowFormDialog(SelectedItems, NotVisibleFieldNames) = Windows.Forms.DialogResult.OK Then

                    Me.ShowWaitForm("Validating ...")

                    For Each KeyValuePair In ModifiedDictonary

                        DataGridViewOrderDetails_OrderDetails.CurrentView.RefreshRow(KeyValuePair.Key)

                        RecalculateOrder(KeyValuePair.Value, KeyValuePair.Key)

                    Next

                    SetAutoFillDependentProperties(SelectedItems)

                    Me.CloseWaitForm()

                End If

            ElseIf TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_OrderComments) Then

                DataGridViewOrderComments_OrderComments.CurrentView.CloseEditorForUpdating()

                SelectedItems = DataGridViewOrderComments_OrderComments.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerOrderComment).ToList

                ModifiedDictonary = DataGridViewOrderComments_OrderComments.GetAllSelectedRowsRowHandlesAndDataBoundItems()

                If AdvantageFramework.WinForm.Presentation.AutoFillDialog.ShowFormDialog(SelectedItems) = Windows.Forms.DialogResult.OK Then

                    Me.ShowWaitForm("Validating ...")

                    For Each KeyValuePair In ModifiedDictonary

                        DataGridViewOrderComments_OrderComments.CurrentView.RefreshRow(KeyValuePair.Key)

                        DataGridViewOrderComments_OrderComments.AddToModifiedRows(KeyValuePair.Key)

                        DataGridViewOrderComments_OrderComments.SetUserEntryChanged()

                    Next

                    Me.CloseWaitForm()

                End If

            ElseIf TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_LineComments) Then

                DataGridViewLineComments_LineComments.CurrentView.CloseEditorForUpdating()

                SelectedItems = DataGridViewLineComments_LineComments.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerOrderLineComment).ToList

                ModifiedDictonary = DataGridViewLineComments_LineComments.GetAllSelectedRowsRowHandlesAndDataBoundItems()

                If DirectCast(SelectedItems(0), AdvantageFramework.MediaManager.Classes.MediaManagerOrderLineComment).MediaType.Substring(0, 1) = "O" OrElse
                        DirectCast(SelectedItems(0), AdvantageFramework.MediaManager.Classes.MediaManagerOrderLineComment).MediaType.Substring(0, 1) = "I" Then

                    NotVisibleFieldNames = (From Column In DataGridViewLineComments_LineComments.CurrentView.Columns
                                            Where Column.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerOrderLineComment.Properties.PositionInformation.ToString OrElse
                                                  Column.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerOrderLineComment.Properties.CloseInformation.ToString OrElse
                                                  Column.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerOrderLineComment.Properties.RateInformation.ToString OrElse
                                                  Column.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerOrderLineComment.Properties.InHouseComments.ToString
                                            Select Column.FieldName).ToList

                ElseIf DirectCast(SelectedItems(0), AdvantageFramework.MediaManager.Classes.MediaManagerOrderLineComment).MediaType.Substring(0, 1) = "R" OrElse
                        DirectCast(SelectedItems(0), AdvantageFramework.MediaManager.Classes.MediaManagerOrderLineComment).MediaType.Substring(0, 1) = "T" Then

                    NotVisibleFieldNames = (From Column In DataGridViewLineComments_LineComments.CurrentView.Columns
                                            Where Column.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerOrderLineComment.Properties.OrderCopy.ToString
                                            Select Column.FieldName).ToList

                End If

                If AdvantageFramework.WinForm.Presentation.AutoFillDialog.ShowFormDialog(SelectedItems, NotVisibleFieldNames) = Windows.Forms.DialogResult.OK Then

                    Me.ShowWaitForm("Validating ...")

                    For Each KeyValuePair In ModifiedDictonary

                        DataGridViewLineComments_LineComments.CurrentView.RefreshRow(KeyValuePair.Key)

                        DataGridViewLineComments_LineComments.AddToModifiedRows(KeyValuePair.Key)

                        DataGridViewLineComments_LineComments.SetUserEntryChanged()

                    Next

                    Me.CloseWaitForm()

                End If

            ElseIf TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_VCCDetails) Then

                DataGridViewTopVCCDetails_VCCOrders.CurrentView.CloseEditorForUpdating()

                SelectedItems = DataGridViewTopVCCDetails_VCCOrders.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.VCCOrder).ToList

                ModifiedDictonary = DataGridViewTopVCCDetails_VCCOrders.GetAllSelectedRowsRowHandlesAndDataBoundItems()

                If AdvantageFramework.WinForm.Presentation.AutoFillDialog.ShowFormDialog(SelectedItems) = Windows.Forms.DialogResult.OK Then

                    Me.ShowWaitForm("Validating ...")

                    For Each KeyValuePair In ModifiedDictonary

                        DataGridViewTopVCCDetails_VCCOrders.CurrentView.RefreshRow(KeyValuePair.Key)

                        DataGridViewTopVCCDetails_VCCOrders.AddToModifiedRows(KeyValuePair.Key)

                        DataGridViewTopVCCDetails_VCCOrders.SetUserEntryChanged()

                    Next

                    Me.CloseWaitForm()

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.ClearChanged()

            TabControlForm_ReviewItems.SelectedTab.Tag = False

            LoadTabItems()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemVendorInvoices_OneInvoicePerOrderLine_Click(sender As Object, e As EventArgs) Handles ButtonItemVendorInvoices_OneInvoicePerOrderLine.Click

            GenerateAPInvoices(CreateAPInvoices.ByOrderLine)

        End Sub
        Private Sub ButtonItemVendorInvoices_OneInvoicePerVendor_Click(sender As Object, e As EventArgs) Handles ButtonItemVendorInvoices_OneInvoicePerVendor.Click

            GenerateAPInvoices(CreateAPInvoices.GroupByVendor)

        End Sub
        Private Sub ButtonItemOrders_CreateRevision_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemOrders_CreateRevision.CheckedChanged

            Dim MediaManagerReviewDetail As AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail = Nothing

            If ButtonItemOrders_CreateRevision.Checked Then

                If DataGridViewOrderDetails_OrderDetails.CurrentView.Columns(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.ForceRevision.ToString) IsNot Nothing Then

                    DataGridViewOrderDetails_OrderDetails.CurrentView.Columns(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.ForceRevision.ToString).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                    DataGridViewOrderDetails_OrderDetails.CurrentView.Columns(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.ForceRevision.ToString).VisibleIndex = 0
                    DataGridViewOrderDetails_OrderDetails.CurrentView.Columns(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.ForceRevision.ToString).OptionsColumn.ShowInCustomizationForm = False
                    DataGridViewOrderDetails_OrderDetails.CurrentView.Columns(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.ForceRevision.ToString).OptionsColumn.AllowMove = False

                End If

                For Each RowHandlesAndDataBoundItem In DataGridViewOrderDetails_OrderDetails.GetAllSelectedRowsRowHandlesAndDataBoundItems

                    Try

                        MediaManagerReviewDetail = RowHandlesAndDataBoundItem.Value

                    Catch ex As Exception
                        MediaManagerReviewDetail = Nothing
                    End Try

                    If MediaManagerReviewDetail IsNot Nothing AndAlso Not MediaManagerReviewDetail.Cancelled AndAlso Not MediaManagerReviewDetail.IsOrderClosed Then

                        MediaManagerReviewDetail.ForceRevision = Not MediaManagerReviewDetail.ForceRevision

                        DataGridViewOrderDetails_OrderDetails.AddToModifiedRows(RowHandlesAndDataBoundItem.Key)

                        DataGridViewOrderDetails_OrderDetails.SetUserEntryChanged()

                        DataGridViewOrderDetails_OrderDetails.CurrentView.RefreshRow(RowHandlesAndDataBoundItem.Key)

                    End If

                Next

            Else

                If DataGridViewOrderDetails_OrderDetails.CurrentView.Columns(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.ForceRevision.ToString) IsNot Nothing Then

                    DataGridViewOrderDetails_OrderDetails.CurrentView.Columns(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.ForceRevision.ToString).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None
                    DataGridViewOrderDetails_OrderDetails.CurrentView.Columns(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.ForceRevision.ToString).Visible = False
                    DataGridViewOrderDetails_OrderDetails.CurrentView.Columns(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.ForceRevision.ToString).OptionsColumn.ShowInCustomizationForm = False

                End If

                For Each RowHandlesAndDataBoundItem In DataGridViewOrderDetails_OrderDetails.GetAllRowsRowHandlesAndDataBoundItems

                    Try

                        MediaManagerReviewDetail = RowHandlesAndDataBoundItem.Value

                    Catch ex As Exception
                        MediaManagerReviewDetail = Nothing
                    End Try

                    If MediaManagerReviewDetail IsNot Nothing AndAlso Not MediaManagerReviewDetail.Cancelled AndAlso Not MediaManagerReviewDetail.IsOrderClosed Then

                        MediaManagerReviewDetail.ForceRevision = False

                        DataGridViewOrderDetails_OrderDetails.AddToModifiedRows(RowHandlesAndDataBoundItem.Key)

                        DataGridViewOrderDetails_OrderDetails.SetUserEntryChanged()

                        DataGridViewOrderDetails_OrderDetails.CurrentView.RefreshRow(RowHandlesAndDataBoundItem.Key)

                    End If

                Next

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemVendorPayments_CreateVCC_Click(sender As Object, e As EventArgs) Handles ButtonItemVendorPayments_CreateVCC.Click

            If TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_OrderDetails) Then

                CreateMediaOrderVirtualCreditCards()

            ElseIf TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_PurchaseOrderDetails) Then

                CreatePurchaseOrderVirtualCreditCards()

            End If

        End Sub
        Private Sub ButtonItemActions_ExportGrid_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_ExportGrid.Click

            If TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_OrderDetails) Then

                'https://www.devexpress.com/Support/Center/Question/Details/Q383062
                DataGridViewOrderDetails_OrderDetails.CurrentView.ClearDocument()
                DevExpress.Utils.Paint.XPaint.ForceGDIPlusPaint()
                DataGridViewOrderDetails_OrderDetails.CurrentView.OptionsView.ColumnAutoWidth = False
                DataGridViewOrderDetails_OrderDetails.CurrentView.BestFitColumns()
                DataGridViewOrderDetails_OrderDetails.CurrentView.OptionsPrint.AutoWidth = False
                DevExpress.Utils.Paint.XPaint.ForceAPIPaint()

                DataGridViewOrderDetails_OrderDetails.Print(DefaultLookAndFeel.LookAndFeel, "Media Manager Review", UseLandscape:=True)

            ElseIf TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_VCCDetails) Then

                'https://www.devexpress.com/Support/Center/Question/Details/Q383062
                DataGridViewTopVCCDetails_VCCOrders.CurrentView.ClearDocument()
                DevExpress.Utils.Paint.XPaint.ForceGDIPlusPaint()
                DataGridViewTopVCCDetails_VCCOrders.CurrentView.OptionsView.ColumnAutoWidth = False
                DataGridViewTopVCCDetails_VCCOrders.CurrentView.BestFitColumns()
                DataGridViewTopVCCDetails_VCCOrders.CurrentView.OptionsPrint.AutoWidth = False
                DevExpress.Utils.Paint.XPaint.ForceAPIPaint()

                DataGridViewTopVCCDetails_VCCOrders.Print(DefaultLookAndFeel.LookAndFeel, "VCC Review", UseLandscape:=True)

            ElseIf TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_BillingInvoices) Then

                MediaBillingHistoryControlBillingInvoices_BillingInvoices.ExportData(Me.DefaultLookAndFeel, "Media Billing History")

            ElseIf TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_PurchaseOrderDetails) Then

                'https://www.devexpress.com/Support/Center/Question/Details/Q383062
                DataGridViewPODetails_PODetails.CurrentView.ClearDocument()
                DevExpress.Utils.Paint.XPaint.ForceGDIPlusPaint()
                DataGridViewPODetails_PODetails.CurrentView.OptionsView.ColumnAutoWidth = False
                DataGridViewPODetails_PODetails.CurrentView.BestFitColumns()
                DataGridViewPODetails_PODetails.CurrentView.OptionsPrint.AutoWidth = False
                DevExpress.Utils.Paint.XPaint.ForceAPIPaint()

                DataGridViewPODetails_PODetails.Print(DefaultLookAndFeel.LookAndFeel, "PO Details", UseLandscape:=True)

            End If

        End Sub
        Private Sub ButtonItemActions_FollowUp_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_FollowUp.Click

            Dim VCCOrder As AdvantageFramework.MediaManager.Classes.VCCOrder = Nothing
            Dim FollowupHours As Decimal = 0

            DataGridViewTopVCCDetails_VCCOrders.CurrentView.CloseEditorForUpdating()

            If AdvantageFramework.WinForm.Presentation.NumericInputDialog.ShowFormDialog("Enter Hours", "Follow up in # hours:", FollowupHours, FollowupHours, Nothing, WinForm.Presentation.Controls.NumericInput.Type.Decimal, True, 0, Nothing, "n2") = Windows.Forms.DialogResult.OK Then

                For Each RowHandlesAndDataBoundItem In DataGridViewTopVCCDetails_VCCOrders.GetAllSelectedRowsRowHandlesAndDataBoundItems

                    Try

                        VCCOrder = RowHandlesAndDataBoundItem.Value

                    Catch ex As Exception
                        VCCOrder = Nothing
                    End Try

                    VCCOrder.FollowupDate = Date.Parse(Now.ToString("MM/dd/yyyy HH:mm")).AddHours(FollowupHours)

                    DataGridViewTopVCCDetails_VCCOrders.CurrentView.RefreshRow(RowHandlesAndDataBoundItem.Key)

                    DataGridViewTopVCCDetails_VCCOrders.AddToModifiedRows(RowHandlesAndDataBoundItem.Key)

                    DataGridViewTopVCCDetails_VCCOrders.SetUserEntryChanged()

                Next

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemOrders_GenerateOrders_Click(sender As Object, e As EventArgs) Handles ButtonItemOrders_GenerateOrders.Click

            'objects
            Dim MediaManagerReviewDetails As Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail) = Nothing
            Dim MediaManagerPODetails As Generic.List(Of AdvantageFramework.DTO.Media.MediaManager.MediaManagerPODetail) = Nothing
            Dim OrderNumbers As IEnumerable(Of Integer) = Nothing
            Dim OrderSubmittedList As Generic.List(Of AdvantageFramework.Classes.Media.OrderSubmitted) = Nothing
            Dim Message As String = String.Empty
            Dim [Continue] As Boolean = True

            If TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_OrderDetails) Then

                If DataGridViewOrderDetails_OrderDetails.HasASelectedRow Then

                    MediaManagerReviewDetails = DataGridViewOrderDetails_OrderDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).ToList

                    OrderNumbers = MediaManagerReviewDetails.Select(Function(MMR) MMR.OrderNumber).Distinct.ToArray

                    Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        OrderSubmittedList = DbContext.Database.SqlQuery(Of AdvantageFramework.Classes.Media.OrderSubmitted)(String.Format("exec advsp_media_order_ok_to_generate NULL, '{0}'", String.Join(",", OrderNumbers.ToArray))).ToList

                    End Using

                    If OrderSubmittedList.Count > 0 And OrderSubmittedList.Where(Function(OS) OS.IsSubmitted = True).Any Then

                        For Each OrderSubmitted In OrderSubmittedList.Where(Function(OS) OS.IsSubmitted = True).ToList

                            Message += OrderSubmitted.VendorCode & " / " & OrderSubmitted.OrderNumber.ToString & vbCrLf

                        Next

                        AdvantageFramework.WinForm.MessageBox.Show("Orders cannot be generated.  There are pending makegoods submitted for the following vendor(s)/order(s): " & vbCrLf & Message)

                        [Continue] = False

                    ElseIf OrderSubmittedList.Count > 0 Then

                        For Each OrderSubmitted In OrderSubmittedList.Where(Function(OS) OS.IsSubmitted = False).ToList

                            Message += OrderSubmitted.VendorCode & " / " & OrderSubmitted.OrderNumber.ToString & vbCrLf

                        Next

                        Message += vbCrLf & "Would you like to proceed and delete that activity?"

                        If AdvantageFramework.WinForm.MessageBox.Show("There are pending makegoods for the following vendor(s)/order(s): " & vbCrLf & Message, WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.No Then

                            [Continue] = False

                        End If

                    End If

                    If [Continue] AndAlso AdvantageFramework.Media.Presentation.MediaManagerGenerateOrdersDialog.ShowFormDialog(MediaManagerReviewDetails, False) = Windows.Forms.DialogResult.OK Then

                        TabControlForm_ReviewItems.SelectedTab.Tag = False

                        LoadTabItems()

                    End If

                End If

            ElseIf TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_PurchaseOrderDetails) Then

                MediaManagerPODetails = DataGridViewPODetails_PODetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.MediaManager.MediaManagerPODetail).Where(Function(POD) Not String.IsNullOrWhiteSpace(POD.VendorContactEmail)).ToList

                If AdvantageFramework.Media.Presentation.MediaManagerGeneratePurchaseOrdersDialog.ShowFormDialog(MediaManagerPODetails) = Windows.Forms.DialogResult.OK Then

                    TabControlForm_ReviewItems.SelectedTab.Tag = False

                    LoadTabItems()

                End If

            End If

        End Sub
        Private Sub ButtonItemVendorPayments_ManageVCC_Click(sender As Object, e As EventArgs) Handles ButtonItemVendorPayments_ManageVCC.Click

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                If CheckForUnsavedChanges() Then

                    If ButtonItemVendorPayments_ManageVCC.Checked Then

                        ButtonItemVendorPayments_ManageVCC.Checked = False

                        TabControlForm_ReviewItems.SelectedTab = TabItemReviewItems_OrderDetails

                        TabItemReviewItems_VCCDetails.Visible = False

                    Else

                        ButtonItemVendorPayments_ManageVCC.Checked = True

                        TabItemReviewItems_VCCDetails.Visible = True

                        TabControlForm_ReviewItems.SelectedTab = TabItemReviewItems_VCCDetails

                        TabControlForm_ReviewItems.SelectedTab.Tag = False

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemOrders_WriteUpDown_Click(sender As Object, e As EventArgs) Handles ButtonItemOrders_WriteUpDown.Click

            Dim MediaManagerReviewDetail As AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail = Nothing
            Dim ErrorMessage As String = Nothing
            Dim AdditionalChargeAmount As Decimal = 0
            Dim Refresh As Boolean = False

            DataGridViewOrderDetails_OrderDetails.CurrentView.CloseEditorForUpdating()

            For Each RowHandlesAndDataBoundItem In DataGridViewOrderDetails_OrderDetails.GetAllSelectedRowsRowHandlesAndDataBoundItems

                Try

                    MediaManagerReviewDetail = RowHandlesAndDataBoundItem.Value

                Catch ex As Exception
                    MediaManagerReviewDetail = Nothing
                End Try

                If MediaManagerReviewDetail IsNot Nothing AndAlso Not MediaManagerReviewDetail.Cancelled AndAlso String.IsNullOrWhiteSpace(MediaManagerReviewDetail.BillingUser) AndAlso
                        MediaManagerReviewDetail.BillableAmount <> MediaManagerReviewDetail.BilledAmount AndAlso Not MediaManagerReviewDetail.IsOrderClosed Then

                    AdditionalChargeAmount = MediaManagerReviewDetail.BilledAmount - MediaManagerReviewDetail.BillableAmount + MediaManagerReviewDetail.AdditionalChargeAmount.GetValueOrDefault(0)

                    If AdvantageFramework.MediaManager.WriteUpDown(Session, MediaManagerReviewDetail, AdditionalChargeAmount, ErrorMessage) = False Then

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    Else

                        Refresh = True

                        'MediaManagerReviewDetail.AdditionalChargeAmount = AdditionalChargeAmount

                        'MediaManagerReviewDetail.BilledAmount = MediaManagerReviewDetail.BilledAmount - MediaManagerReviewDetail.AdditionalChargeAmount

                        'DataGridViewOrderDetails_OrderDetails.CurrentView.RefreshRow(RowHandlesAndDataBoundItem.Key)

                    End If

                    'If Not AdvantageFramework.MediaManager.ReviseOrder(Session, True, MediaManagerReviewDetail, ErrorMessage) Then

                    '    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    'Else

                    '    MediaManagerReviewDetail.ReviseUpdateOrder = True

                    '    DataGridViewOrderDetails_OrderDetails.CurrentView.RefreshRow(RowHandlesAndDataBoundItem.Key)

                    '    DataGridViewOrderDetails_OrderDetails.AddToModifiedRows(RowHandlesAndDataBoundItem.Key)

                    '    DataGridViewOrderDetails_OrderDetails.SetUserEntryChanged()

                    '    EnableOrDisableActions()

                    'End If

                End If

            Next

            If Refresh Then

                RefreshForm()

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemOrders_ProcessControl_Click(sender As Object, e As EventArgs) Handles ButtonItemOrders_ProcessControl.Click

            Dim OrderNumbers As IEnumerable(Of Integer) = Nothing

            OrderNumbers = (From Entity In DataGridViewOrderDetails_OrderDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail)
                            Select Entity.OrderNumber).Distinct.ToArray

            AdvantageFramework.Media.Presentation.MediaManagerOrderProcessControlDialog.ShowFormDialog(OrderNumbers)

            LoadOrderDetailsTab()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Refresh.Click

            RefreshForm()

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim TabItem As DevComponents.DotNetBar.TabItem = Nothing
            Dim ErrorMessage As String = ""

            TabItem = TabControlForm_ReviewItems.SelectedTab

            If Save(ErrorMessage) Then

                Me.FormAction = WinForm.Presentation.FormActions.Refreshing

                TabControlForm_ReviewItems.SelectedTab.Tag = False

                LoadTabItems()

                Me.FormAction = WinForm.Presentation.FormActions.None

                Me.ClearChanged()

                EnableOrDisableActions()

            ElseIf Not String.IsNullOrWhiteSpace(ErrorMessage) Then

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonItemActions_SendReminders_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_SendReminders.Click

            Dim VCCOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.VCCOrder) = Nothing

            VCCOrders = (From VCCOrder In DataGridViewTopVCCDetails_VCCOrders.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.VCCOrder).ToList
                         Where ((VCCOrder.GetVCCCardEntity.CardType = Database.Interfaces.IVCCCard.EnumCardType.MediaOrder AndAlso
                                 VCCOrder.TotalCostPayableToVendor.GetValueOrDefault(0) <> 0) OrElse
                                VCCOrder.GetVCCCardEntity.CardType = Database.Interfaces.IVCCCard.EnumCardType.PurchaseOrder) AndAlso
                               VCCOrder.GetVCCCardEntity.VCCCardDetails.Any(Function(D) D.Action = AdvantageFramework.Database.Entities.VCCAction.PendingTransaction OrElse
                                                                                        D.Action = AdvantageFramework.Database.Entities.VCCAction.ClearedTransaction) = False
                         Select VCCOrder).ToList

            If VCCOrders.Count > 0 AndAlso AdvantageFramework.WinForm.MessageBox.Show("Would you like to refresh cards without pending/cleared transactions?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                RefreshVCCOrders(VCCOrders)

                VCCOrders = (From VCCOrder In DataGridViewTopVCCDetails_VCCOrders.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.VCCOrder).ToList
                             Where ((VCCOrder.GetVCCCardEntity.CardType = Database.Interfaces.IVCCCard.EnumCardType.MediaOrder AndAlso
                                     VCCOrder.TotalCostPayableToVendor.GetValueOrDefault(0) <> 0) OrElse
                                    VCCOrder.GetVCCCardEntity.CardType = Database.Interfaces.IVCCCard.EnumCardType.PurchaseOrder) AndAlso
                                   VCCOrder.GetVCCCardEntity.VCCCardDetails.Any(Function(D) D.Action = AdvantageFramework.Database.Entities.VCCAction.PendingTransaction OrElse
                                                                                            D.Action = AdvantageFramework.Database.Entities.VCCAction.ClearedTransaction) = False
                             Select VCCOrder).ToList

            End If

            VCCOrders = VCCOrders.Where(Function(O) O.Cancelled = False AndAlso O.GetVCCCardEntity.Status = "A").ToList

            If VCCOrders.Count > 0 Then

                AdvantageFramework.Media.Presentation.MediaManagerSendRemindersDialog.ShowFormDialog(VCCOrders)

            Else

                AdvantageFramework.WinForm.MessageBox.Show("All cards have pending or cleared transactions.")

            End If

        End Sub
        Private Sub ButtonItemOrders_UpdateCostToActual_Click(sender As Object, e As EventArgs) Handles ButtonItemOrders_UpdateCostToActual.Click

            UpdateCost(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.ReviseOrderToAmount.ActualAmountPosted)

        End Sub
        Private Sub ButtonItemOrders_UpdateCostToVendorCollected_Click(sender As Object, e As EventArgs) Handles ButtonItemOrders_UpdateCostToVendorCollected.Click

            UpdateCost(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.ReviseOrderToAmount.VendorCollected)

        End Sub
        Private Sub ButtonItemAdServing_DoubleClick_Click(sender As Object, e As EventArgs) Handles ButtonItemAdServing_DoubleClick.Click

            'objects
            Dim OrderNumberLineNumbers As IEnumerable(Of String) = Nothing
            Dim DCProfileID As Long = 0
            Dim DCReportID As Nullable(Of Long) = Nothing

            OrderNumberLineNumbers = (From MMRD In DataGridViewOrderDetails_OrderDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail)
                                      Where MMRD.MediaFrom = "Internet" AndAlso
                                            MMRD.Quote = False AndAlso
                                            MMRD.DCProfileID.HasValue
                                      Select MMRD.OrderNumberLineNumber).ToArray

            DCProfileID = (From MMRD In DataGridViewOrderDetails_OrderDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail)
                           Where MMRD.MediaFrom = "Internet" AndAlso
                                 MMRD.Quote = False AndAlso
                                 MMRD.DCProfileID.HasValue
                           Select MMRD.DCProfileID.Value).Distinct.Single

            If (From MMRD In DataGridViewOrderDetails_OrderDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail)
                Where MMRD.MediaFrom = "Internet" AndAlso
                      MMRD.Quote = False AndAlso
                      MMRD.DCProfileID = DCProfileID AndAlso
                      MMRD.DCReportID.HasValue).Any Then

                DCReportID = (From MMRD In DataGridViewOrderDetails_OrderDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail)
                              Where MMRD.MediaFrom = "Internet" AndAlso
                                    MMRD.Quote = False AndAlso
                                    MMRD.DCProfileID = DCProfileID AndAlso
                                    MMRD.DCReportID.HasValue
                              Select MMRD.DCReportID.Value).FirstOrDefault

            End If

            If OrderNumberLineNumbers IsNot Nothing AndAlso OrderNumberLineNumbers.Count > 0 Then

                AdvantageFramework.Media.Presentation.MediaManagerAdServingDialog.ShowFormDialog(OrderNumberLineNumbers, AdvantageFramework.Database.Entities.AdServerID.DoubleClick, DCProfileID, DCReportID)

                TabControlForm_ReviewItems.SelectedTab.Tag = False

                LoadTabItems()

            End If

        End Sub
        Private Sub ButtonItemBillingApproval_Approve_Click(sender As Object, e As EventArgs) Handles ButtonItemBillingApproval_Approve.Click

            Dim MediaManagerReviewDetailList As Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail) = Nothing

            Me.ShowWaitForm()

            MediaManagerReviewDetailList = DataGridViewOrderDetails_OrderDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).Where(Function(RD) RD.Cancelled = False AndAlso RD.IsOrderClosed = False).ToList

            AdvantageFramework.MediaManager.CreateBillingApprovals(Session, MediaManagerReviewDetailList)

            DataGridViewOrderDetails_OrderDetails.CurrentView.RefreshData()

            TabItemReviewItems_OrderStatus.Tag = False

            EnableOrDisableActions()

            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonItemBillingApproval_Unapprove_Click(sender As Object, e As EventArgs) Handles ButtonItemBillingApproval_Unapprove.Click

            Dim MediaManagerReviewDetailList As Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail) = Nothing

            Me.ShowWaitForm()

            MediaManagerReviewDetailList = DataGridViewOrderDetails_OrderDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).Where(Function(RD) RD.Cancelled = False AndAlso RD.IsOrderClosed = False).ToList

            AdvantageFramework.MediaManager.DeleteBillingApprovals(Session, MediaManagerReviewDetailList)

            DataGridViewOrderDetails_OrderDetails.CurrentView.RefreshData()

            TabItemReviewItems_OrderStatus.Tag = False

            EnableOrDisableActions()

            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonItemDocuments_Download_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Download.Click

            If TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_BillingInvoices) Then

                MediaBillingHistoryControlBillingInvoices_BillingInvoices.DownloadSelectedDocument()

            ElseIf TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_Documents) Then

                DocumentManagerControlDocuments_Documents.DownloadSelectedDocument()

                EnableOrDisableActions()

            ElseIf TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_APInvoiceDetail) Then

                ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.DownloadSelectedDocument()

            End If

        End Sub
        Private Sub ButtonItemDocuments_OpenURL_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_OpenURL.Click

            If TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_Documents) Then

                DocumentManagerControlDocuments_Documents.DownloadSelectedDocument()

                EnableOrDisableActions()

            ElseIf TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_APInvoiceDetail) Then

                ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.DownloadSelectedDocument()

            End If

        End Sub
        Private Sub ButtonItemDocuments_Upload_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Upload.Click

            If ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.IsDocumentsTabSelected Then

                ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.UploadNewDocument()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemUpload_EmailLink_Click(sender As Object, e As EventArgs) Handles ButtonItemUpload_EmailLink.Click

            If ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.IsDocumentsTabSelected Then

                ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.SendASPUploadEmail()

            End If

        End Sub
        Private Sub ButtonItemDocuments_UploadCampaign_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_UploadCampaign.Click

            If TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_Documents) Then

                DocumentManagerControlDocuments_Documents.UploadNewDocument(AdvantageFramework.Database.Entities.DocumentLevel.Campaign)

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemUploadCampaign_EmailLink_Click(sender As Object, e As EventArgs) Handles ButtonItemUploadCampaign_EmailLink.Click

            If TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_Documents) Then

                DocumentManagerControlDocuments_Documents.SendASPUploadEmail(AdvantageFramework.Database.Entities.DocumentLevel.Campaign)

            End If

        End Sub
        Private Sub ButtonItemDocuments_UploadOrder_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_UploadOrder.Click

            If TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_Documents) Then

                DocumentManagerControlDocuments_Documents.UploadNewDocument(AdvantageFramework.Database.Entities.DocumentLevel.MediaOrder)

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemUploadOrder_EmailLink_Click(sender As Object, e As EventArgs) Handles ButtonItemUploadOrder_EmailLink.Click

            If TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_Documents) Then

                DocumentManagerControlDocuments_Documents.SendASPUploadEmail(AdvantageFramework.Database.Entities.DocumentLevel.MediaOrder)

            End If

        End Sub
        Private Sub ButtonItemDocuments_UploadJob_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_UploadJob.Click

            If TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_Documents) Then

                DocumentManagerControlDocuments_Documents.UploadNewDocument(AdvantageFramework.Database.Entities.DocumentLevel.Job)

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemUploadJob_EmailLink_Click(sender As Object, e As EventArgs) Handles ButtonItemUploadJob_EmailLink.Click

            If TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_Documents) Then

                DocumentManagerControlDocuments_Documents.SendASPUploadEmail(AdvantageFramework.Database.Entities.DocumentLevel.Job)

            End If

        End Sub
        Private Sub ButtonItemDocuments_UploadJobComponent_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_UploadJobComponent.Click

            If TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_Documents) Then

                DocumentManagerControlDocuments_Documents.UploadNewDocument(AdvantageFramework.Database.Entities.DocumentLevel.JobComponent)

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemUploadJobComponent_EmailLink_Click(sender As Object, e As EventArgs) Handles ButtonItemUploadJobComponent_EmailLink.Click

            If TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_Documents) Then

                DocumentManagerControlDocuments_Documents.SendASPUploadEmail(AdvantageFramework.Database.Entities.DocumentLevel.JobComponent)

            End If

        End Sub
        Private Sub ButtonItemFilter_All_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemFilter_All.CheckedChanged

            If Me.FormShown AndAlso ButtonItemFilter_All.Checked Then

                ButtonItemFilter_SelectedLineItem.Checked = False

                MediaBillingHistoryControlBillingInvoices_BillingInvoices.RefreshDocumentsTab(True)

            End If

        End Sub
        Private Sub ButtonItemFilter_SelectedLineItem_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemFilter_SelectedLineItem.CheckedChanged

            If Me.FormShown AndAlso ButtonItemFilter_SelectedLineItem.Checked Then

                ButtonItemFilter_All.Checked = False

                MediaBillingHistoryControlBillingInvoices_BillingInvoices.RefreshDocumentsTab(False)

            End If

        End Sub
        Private Sub ButtonItemGridOptionsOrderDetails_ChooseColumns_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemGridOptionsOrderDetails_ChooseColumns.CheckedChanged

            Try

                If ButtonItemGridOptionsOrderDetails_ChooseColumns.Checked Then

                    If DataGridViewOrderDetails_OrderDetails.CurrentView.CustomizationForm Is Nothing Then

                        DataGridViewOrderDetails_OrderDetails.CurrentView.ShowCustomization()

                    End If

                Else

                    If DataGridViewOrderDetails_OrderDetails.CurrentView.CustomizationForm IsNot Nothing Then

                        DataGridViewOrderDetails_OrderDetails.CurrentView.DestroyCustomization()

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ButtonItemGridOptionsOrderDetails_RestoreDefaults_Click(sender As Object, e As EventArgs) Handles ButtonItemGridOptionsOrderDetails_RestoreDefaults.Click

            If CheckForUnsavedChanges() Then

                Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    AdvantageFramework.Database.Procedures.GridAdvantage.Delete(DataContext, AdvantageFramework.Database.Entities.GridAdvantageType.MediaManagerMediaManagerReviewOrderDetail, Session.UserCode)

                End Using

                DataGridViewOrderDetails_OrderDetails.ClearDatasource()

                TabItemReviewItems_OrderDetails.Tag = False

                LoadTabItems()

            End If

        End Sub
        Private Sub ButtonItemGridOptionsVCCDetails_ChooseColumns_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemGridOptionsVCCDetails_ChooseColumns.CheckedChanged

            Try

                If ButtonItemGridOptionsVCCDetails_ChooseColumns.Checked Then

                    If DataGridViewTopVCCDetails_VCCOrders.CurrentView.CustomizationForm Is Nothing Then

                        DataGridViewTopVCCDetails_VCCOrders.CurrentView.ShowCustomization()

                    End If

                Else

                    If DataGridViewTopVCCDetails_VCCOrders.CurrentView.CustomizationForm IsNot Nothing Then

                        DataGridViewTopVCCDetails_VCCOrders.CurrentView.DestroyCustomization()

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ButtonItemGridOptionsVCCDetails_RestoreDefaults_Click(sender As Object, e As EventArgs) Handles ButtonItemGridOptionsVCCDetails_RestoreDefaults.Click

            If CheckForUnsavedChanges() Then

                Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    AdvantageFramework.Database.Procedures.GridAdvantage.Delete(DataContext, AdvantageFramework.Database.Entities.GridAdvantageType.MediaManagerMediaManagerReviewVCCOrderDetail, Session.UserCode)

                End Using

                DataGridViewTopVCCDetails_VCCOrders.ClearDatasource()

                TabItemReviewItems_VCCDetails.Tag = False

                LoadTabItems()

            End If

        End Sub
        Private Sub ButtonItemSummaryResults_Followup_Click(sender As Object, e As EventArgs) Handles ButtonItemSummaryResults_Followup.Click

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                If ButtonItemSummaryResults_Followup.Checked Then

                    ButtonItemSummaryResults_Followup.Checked = False

                Else

                    ClearFilters()
                    ButtonItemSummaryResults_Followup.Checked = True

                End If

                FilterLoadGrid()

            End If

        End Sub
        Private Sub ButtonItemSummaryResults_NoTransactions_Click(sender As Object, e As EventArgs) Handles ButtonItemSummaryResults_NoTransactions.Click

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                If ButtonItemSummaryResults_NoTransactions.Checked Then

                    ButtonItemSummaryResults_NoTransactions.Checked = False

                Else

                    ClearFilters()
                    ButtonItemSummaryResults_NoTransactions.Checked = True

                End If

                FilterLoadGrid()

            End If

        End Sub
        Private Sub ButtonItemSummaryResults_TransactionsDeclined_Click(sender As Object, e As EventArgs) Handles ButtonItemSummaryResults_TransactionsDeclined.Click

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                If ButtonItemSummaryResults_TransactionsDeclined.Checked Then

                    ButtonItemSummaryResults_TransactionsDeclined.Checked = False

                Else

                    ClearFilters()
                    ButtonItemSummaryResults_TransactionsDeclined.Checked = True

                End If

                FilterLoadGrid()

            End If

        End Sub
        Private Sub ButtonItemSummaryResults_TransactionsInBalance_Click(sender As Object, e As EventArgs) Handles ButtonItemSummaryResults_TransactionsInBalance.Click

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                If ButtonItemSummaryResults_TransactionsInBalance.Checked Then

                    ButtonItemSummaryResults_TransactionsInBalance.Checked = False

                Else

                    ClearFilters()
                    ButtonItemSummaryResults_TransactionsInBalance.Checked = True

                End If

                FilterLoadGrid()

            End If

        End Sub
        Private Sub ButtonItemSummaryResults_TransactionsOutOfBalance_Click(sender As Object, e As EventArgs) Handles ButtonItemSummaryResults_TransactionsOutOfBalance.Click

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                If ButtonItemSummaryResults_TransactionsOutOfBalance.Checked Then

                    ButtonItemSummaryResults_TransactionsOutOfBalance.Checked = False

                Else

                    ClearFilters()
                    ButtonItemSummaryResults_TransactionsOutOfBalance.Checked = True

                End If

                FilterLoadGrid()

            End If

        End Sub
        Private Sub ButtonItemSummaryResults_VCCIssuedAndUpdated_Click(sender As Object, e As EventArgs) Handles ButtonItemSummaryResults_VCCIssuedAndUpdated.Click

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                If ButtonItemSummaryResults_VCCIssuedAndUpdated.Checked Then

                    ButtonItemSummaryResults_VCCIssuedAndUpdated.Checked = False

                Else

                    ClearFilters()
                    ButtonItemSummaryResults_VCCIssuedAndUpdated.Checked = True

                End If

                FilterLoadGrid()

            End If

        End Sub
        Private Sub ButtonItemVendor_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemVendor_Edit.Click

            Dim VendorCode As String = Nothing

            If TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_VCCDetails) AndAlso DataGridViewTopVCCDetails_VCCOrders.HasASelectedRow Then

                VendorCode = DirectCast(DataGridViewTopVCCDetails_VCCOrders.GetFirstSelectedRowDataBoundItem, AdvantageFramework.MediaManager.Classes.VCCOrder).VendorCode

            ElseIf TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_OrderDetails) AndAlso DataGridViewOrderDetails_OrderDetails.HasASelectedRow Then

                VendorCode = DirectCast(DataGridViewOrderDetails_OrderDetails.GetFirstSelectedRowDataBoundItem, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).VendorCode

            ElseIf TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_APInvoiceDetail) AndAlso ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.HasASelectedRow Then

                VendorCode = ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.SelectedVendorCode

            ElseIf TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_VendorReps) AndAlso DataGridViewVendorReps_VendorReps.HasASelectedRow Then

                VendorCode = DirectCast(DataGridViewVendorReps_VendorReps.GetFirstSelectedRowDataBoundItem, AdvantageFramework.MediaManager.Classes.VendorRep).VendorCode

            ElseIf TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_PurchaseOrderDetails) AndAlso DataGridViewPODetails_PODetails.HasASelectedRow Then

                VendorCode = DirectCast(DataGridViewPODetails_PODetails.GetFirstSelectedRowDataBoundItem, AdvantageFramework.DTO.Media.MediaManager.MediaManagerPODetail).VendorCode

            End If

            If VendorCode IsNot Nothing Then

                AdvantageFramework.Maintenance.Accounting.Presentation.VendorEditDialog.ShowFormDialog(VendorCode, True)

                If TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_VendorReps) Then

                    TabItemReviewItems_VendorReps.Tag = False

                    LoadTabItems()

                ElseIf TabControlForm_ReviewItems.SelectedTab.Equals(TabItemReviewItems_PurchaseOrderDetails) Then

                    TabItemReviewItems_PurchaseOrderDetails.Tag = False

                    LoadTabItems()

                End If

            End If

        End Sub
        Private Sub ButtonItemVendorReps_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemVendorReps_Add.Click

            'objects
            Dim VendorCode As String = Nothing
            Dim VendorRepCode As String = Nothing

            If DataGridViewVendorReps_VendorReps.HasOnlyOneSelectedRow Then

                VendorCode = DataGridViewVendorReps_VendorReps.CurrentView.GetRowCellValue(DataGridViewVendorReps_VendorReps.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Classes.VendorRep.Properties.VendorCode.ToString)

            ElseIf DataGridViewOrderDetails_OrderDetails.HasOnlyOneSelectedRow Then

                VendorCode = DataGridViewOrderDetails_OrderDetails.CurrentView.GetRowCellValue(DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedRowHandle, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.VendorCode.ToString)

            End If

            If VendorCode IsNot Nothing AndAlso AdvantageFramework.Maintenance.Media.Presentation.VendorRepEditDialog.ShowFormDialog(VendorCode, VendorRepCode, True) = System.Windows.Forms.DialogResult.OK Then

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                Try

                    LoadVendorRepsTab()

                Catch ex As Exception

                End Try

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                DataGridViewVendorReps_VendorReps.SelectRow(AdvantageFramework.Database.Classes.VendorRep.Properties.ID.ToString, VendorCode & "|" & VendorRepCode, True)

            End If

        End Sub
        Private Sub ButtonItemVendorReps_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemVendorReps_Delete.Click

            Dim VendorCode As String = Nothing
            Dim VendorRepCode As String = Nothing
            Dim VendorRepresentative As AdvantageFramework.Database.Entities.VendorRepresentative = Nothing
            Dim Deleted As Boolean = True

            If DataGridViewVendorReps_VendorReps.HasOnlyOneSelectedRow Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete selected vendor rep?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    VendorCode = DataGridViewVendorReps_VendorReps.CurrentView.GetRowCellValue(DataGridViewVendorReps_VendorReps.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Classes.VendorRep.Properties.VendorCode.ToString)
                    VendorRepCode = DataGridViewVendorReps_VendorReps.CurrentView.GetRowCellValue(DataGridViewVendorReps_VendorReps.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Classes.VendorRep.Properties.Code.ToString)

                    Using DataContext As New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        VendorRepresentative = AdvantageFramework.Database.Procedures.VendorRepresentative.LoadByCodeAndVendorCode(DataContext, VendorRepCode, VendorCode)

                        If VendorRepresentative IsNot Nothing Then

                            Deleted = AdvantageFramework.Database.Procedures.VendorRepresentative.Delete(DataContext, VendorRepresentative)

                        End If

                    End Using

                    If Deleted = False Then

                        AdvantageFramework.WinForm.MessageBox.Show("The vendor rep is in use and cannot be deleted.")

                    Else

                        LoadVendorRepsTab()

                    End If

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a vendor rep to delete.")

            End If

        End Sub
        Private Sub ButtonItemVendorReps_Edit_Click(sender As Object, e As EventArgs) Handles ButtonItemVendorReps_Edit.Click

            EditSelectedVendorRep()

        End Sub
        Private Sub DataGridViewBottomVCCDetails_CardDetails_CustomColumnSortEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs) Handles DataGridViewBottomVCCDetails_CardDetails.CustomColumnSortEvent

            Dim Value1 As Object = Nothing
            Dim Value2 As Object = Nothing

            If e.Column.FieldName = AdvantageFramework.MediaManager.Classes.VCCDetail.Properties.Processed.ToString Then

                Value1 = DataGridViewBottomVCCDetails_CardDetails.CurrentView.GetListSourceRowCellValue(e.ListSourceRowIndex1, AdvantageFramework.MediaManager.Classes.VCCDetail.Properties.ProcessDateTime.ToString)
                Value2 = DataGridViewBottomVCCDetails_CardDetails.CurrentView.GetListSourceRowCellValue(e.ListSourceRowIndex2, AdvantageFramework.MediaManager.Classes.VCCDetail.Properties.ProcessDateTime.ToString)

                e.Handled = True
                e.Result = System.Collections.Comparer.Default.Compare(Value1, Value2)

            End If

        End Sub
        Private Sub DataGridViewBottomVCCDetails_CardNotes_AddNewRowEvent(RowObject As Object) Handles DataGridViewBottomVCCDetails_CardNotes.AddNewRowEvent

            'objects
            Dim ErrorMessage As String = Nothing

            If DataGridViewTopVCCDetails_VCCOrders.HasASelectedRow AndAlso TypeOf RowObject Is AdvantageFramework.Database.Interfaces.IVCCCardNote Then

                If Not AdvantageFramework.MediaManager.AddVCCNote(Me.Session, DataGridViewTopVCCDetails_VCCOrders.GetFirstSelectedRowDataBoundItem, RowObject, ErrorMessage) Then

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            End If

        End Sub
        Private Sub DataGridViewBottomVCCDetails_CardNotes_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewBottomVCCDetails_CardNotes.CellValueChangedEvent

            If e.RowHandle >= 0 AndAlso e.Column.FieldName = AdvantageFramework.Database.Interfaces.IVCCCardNote.Properties.Note.ToString AndAlso String.IsNullOrWhiteSpace(e.Value) = False Then

                AdvantageFramework.MediaManager.UpdateVCCNote(Me.Session, DirectCast(DataGridViewBottomVCCDetails_CardNotes.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Interfaces.IVCCCardNote))

            End If

        End Sub
        Private Sub DataGridViewBottomVCCDetails_CardNotes_CustomColumnDisplayTextEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles DataGridViewBottomVCCDetails_CardNotes.CustomColumnDisplayTextEvent

            If e.Column.FieldName = AdvantageFramework.Database.Interfaces.IVCCCardNote.Properties.CreatedDate.ToString Then

                If DataGridViewBottomVCCDetails_CardNotes.CurrentView.GetRowHandle(e.Column.View.GetRowHandle(e.ListSourceRowIndex)) >= 0 Then

                    e.DisplayText = AdvantageFramework.VCC.DisplayLocalDate(_TimezoneOffset, e.Value)

                Else

                    e.DisplayText = Nothing

                End If

            End If

        End Sub
        Private Sub DataGridViewBottomVCCDetails_CardNotes_EmbeddedNavigatorButtonClick(sender As Object, e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs) Handles DataGridViewBottomVCCDetails_CardNotes.EmbeddedNavigatorButtonClick

            'objects
            Dim ErrorMessage As String = ""

            If Not e.Handled Then

                Select Case CType(e.Button.Tag, DevExpress.XtraEditors.NavigatorButtonType)

                    Case DevExpress.XtraEditors.NavigatorButtonType.CancelEdit

                        DataGridViewBottomVCCDetails_CardNotes.CancelNewItemRow()

                        e.Handled = True

                    Case DevExpress.XtraEditors.NavigatorButtonType.Remove

                        If DataGridViewBottomVCCDetails_CardNotes.HasASelectedRow Then

                            DataGridViewBottomVCCDetails_CardNotes.CurrentView.CloseEditorForUpdating()

                            If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete selected note?", WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                                If AdvantageFramework.MediaManager.DeleteVCCNote(Me.Session, DirectCast(DataGridViewBottomVCCDetails_CardNotes.GetRowDataBoundItem(DataGridViewBottomVCCDetails_CardNotes.CurrentView.FocusedRowHandle), AdvantageFramework.Database.Interfaces.IVCCCardNote), ErrorMessage) Then

                                    DataGridViewBottomVCCDetails_CardNotes.CurrentView.DeleteSelectedRows()

                                Else

                                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                                End If

                            End If

                        End If

                        e.Handled = True

                End Select

            End If

        End Sub
        Private Sub DataGridViewBottomVCCDetails_CardNotes_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewBottomVCCDetails_CardNotes.InitNewRowEvent

            If TypeOf DataGridViewBottomVCCDetails_CardNotes.CurrentView.GetRow(e.RowHandle) Is AdvantageFramework.Database.Interfaces.IVCCCardNote Then

                DirectCast(DataGridViewBottomVCCDetails_CardNotes.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Interfaces.IVCCCardNote).CreatedByUserCode = Session.UserCode
                DirectCast(DataGridViewBottomVCCDetails_CardNotes.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Interfaces.IVCCCardNote).CreatedDate = Now

            End If

        End Sub
        Private Sub DataGridViewBottomVCCDetails_CardNotes_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewBottomVCCDetails_CardNotes.ShowingEditorEvent

            If (DataGridViewBottomVCCDetails_CardNotes.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.Database.Interfaces.IVCCCardNote.Properties.Note.ToString) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DataGridViewLineComments_LineComments_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewLineComments_LineComments.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewLineComments_LineComments_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewLineComments_LineComments.ShowingEditorEvent

            If DataGridViewLineComments_LineComments.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerOrderLineComment.Properties.PositionInformation.ToString OrElse
                    DataGridViewLineComments_LineComments.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerOrderLineComment.Properties.CloseInformation.ToString OrElse
                    DataGridViewLineComments_LineComments.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerOrderLineComment.Properties.RateInformation.ToString OrElse
                    DataGridViewLineComments_LineComments.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerOrderLineComment.Properties.InHouseComments.ToString Then

                If DirectCast(DataGridViewLineComments_LineComments.CurrentView.GetRow(DataGridViewLineComments_LineComments.CurrentView.FocusedRowHandle), AdvantageFramework.MediaManager.Classes.MediaManagerOrderLineComment).OrderType = "I" OrElse
                        DirectCast(DataGridViewLineComments_LineComments.CurrentView.GetRow(DataGridViewLineComments_LineComments.CurrentView.FocusedRowHandle), AdvantageFramework.MediaManager.Classes.MediaManagerOrderLineComment).OrderType = "O" Then

                    e.Cancel = True

                End If

            ElseIf DataGridViewLineComments_LineComments.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerOrderLineComment.Properties.OrderCopy.ToString Then

                If DirectCast(DataGridViewLineComments_LineComments.CurrentView.GetRow(DataGridViewLineComments_LineComments.CurrentView.FocusedRowHandle), AdvantageFramework.MediaManager.Classes.MediaManagerOrderLineComment).OrderType = "R" OrElse
                        DirectCast(DataGridViewLineComments_LineComments.CurrentView.GetRow(DataGridViewLineComments_LineComments.CurrentView.FocusedRowHandle), AdvantageFramework.MediaManager.Classes.MediaManagerOrderLineComment).OrderType = "T" Then

                    e.Cancel = True

                End If

            End If

        End Sub
        Private Sub DataGridViewLineComments_LineComments_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewLineComments_LineComments.CellValueChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewOrderComments_OrderComments_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewOrderComments_OrderComments.CellValueChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewOrderDetails_OrderDetails_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewOrderDetails_OrderDetails.CellValueChangedEvent

            Dim MediaManagerReviewDetail As AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail = Nothing
            Dim MediaManagerReviewDetails As IEnumerable(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail) = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim MediaManagerReviewDetailWithCampaign As AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail = Nothing
            Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing
            Dim DictionaryOrderDetails As Dictionary(Of Integer, Object) = Nothing

            MediaManagerReviewDetail = DataGridViewOrderDetails_OrderDetails.GetRowDataBoundItem(e.RowHandle)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                If e.Column.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.CampaignID.ToString Then

                    If e.Value IsNot Nothing Then

                        DictionaryOrderDetails = DataGridViewOrderDetails_OrderDetails.GetAllRowsRowHandlesAndDataBoundItems

                        MediaManagerReviewDetailWithCampaign = DictionaryOrderDetails.Where(Function(KP) KP.Key <> e.RowHandle AndAlso
                                                                                              DirectCast(KP.Value, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).CampaignID.HasValue AndAlso
                                                                                              DirectCast(KP.Value, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).CampaignID = e.Value).Select(Function(KP) DirectCast(KP.Value, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail)).FirstOrDefault

                        If MediaManagerReviewDetailWithCampaign IsNot Nothing Then

                            MediaManagerReviewDetail.CampaignCode = MediaManagerReviewDetailWithCampaign.CampaignCode
                            MediaManagerReviewDetail.CampaignName = MediaManagerReviewDetailWithCampaign.CampaignName
                            MediaManagerReviewDetail.CampaignStartDate = MediaManagerReviewDetailWithCampaign.CampaignStartDate
                            MediaManagerReviewDetail.CampaignEndDate = MediaManagerReviewDetailWithCampaign.CampaignEndDate

                        Else

                            Campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(DbContext, e.Value)

                            If Campaign IsNot Nothing Then

                                MediaManagerReviewDetail.CampaignCode = Campaign.Code
                                MediaManagerReviewDetail.CampaignName = Campaign.Name
                                MediaManagerReviewDetail.CampaignStartDate = Campaign.StartDate
                                MediaManagerReviewDetail.CampaignEndDate = Campaign.EndDate

                            End If

                        End If

                    Else

                        MediaManagerReviewDetail.CampaignCode = Nothing
                        MediaManagerReviewDetail.CampaignName = Nothing
                        MediaManagerReviewDetail.CampaignStartDate = Nothing
                        MediaManagerReviewDetail.CampaignEndDate = Nothing

                    End If

                End If

                If e.Column.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.Quote.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.OrderDescription.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.ClientPO.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.Buyer.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.BuyerEmployeeCode.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.CampaignID.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.MarketCode.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.BillCoopCode.ToString Then

                    MediaManagerReviewDetails = DataGridViewOrderDetails_OrderDetails.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).Where(Function(Entity) Entity.OrderNumber = MediaManagerReviewDetail.OrderNumber AndAlso Entity.Cancelled = False).ToList

                    For Each MMRD In MediaManagerReviewDetails

                        MMRD.Quote = MediaManagerReviewDetail.Quote
                        MMRD.OrderDescription = MediaManagerReviewDetail.OrderDescription
                        MMRD.ClientPO = MediaManagerReviewDetail.ClientPO
                        MMRD.Buyer = MediaManagerReviewDetail.Buyer
                        MMRD.BuyerEmployeeCode = MediaManagerReviewDetail.BuyerEmployeeCode
                        MMRD.CampaignID = MediaManagerReviewDetail.CampaignID
                        MMRD.CampaignCode = MediaManagerReviewDetail.CampaignCode
                        MMRD.CampaignName = MediaManagerReviewDetail.CampaignName
                        MMRD.CampaignStartDate = MediaManagerReviewDetail.CampaignStartDate
                        MMRD.CampaignEndDate = MediaManagerReviewDetail.CampaignEndDate
                        MMRD.MarketCode = MediaManagerReviewDetail.MarketCode
                        MMRD.MarketDescription = MediaManagerReviewDetail.MarketDescription
                        MMRD.BillCoopCode = MediaManagerReviewDetail.BillCoopCode

                        MMRD.DbContext = DbContext
                        MMRD.ValidateEntity(True)

                    Next

                    DataGridViewOrderDetails_OrderDetails.CurrentView.RefreshData()

                ElseIf e.Column.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.CampaignStartDate.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.CampaignEndDate.ToString Then

                    MediaManagerReviewDetails = DataGridViewOrderDetails_OrderDetails.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).Where(Function(Entity) Entity.CampaignID.HasValue AndAlso Entity.CampaignID.Value = MediaManagerReviewDetail.CampaignID.Value).ToList

                    For Each MMRD In MediaManagerReviewDetails

                        MMRD.CampaignStartDate = MediaManagerReviewDetail.CampaignStartDate
                        MMRD.CampaignEndDate = MediaManagerReviewDetail.CampaignEndDate

                        MMRD.DbContext = DbContext
                        MMRD.ValidateEntity(True)

                    Next

                    DataGridViewOrderDetails_OrderDetails.CurrentView.RefreshData()

                ElseIf e.Column.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.AdditionalChargeAmount.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.Rate.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.NetChargeAmount.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.GuaranteedImpressions.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.MarkupPercent.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.RebatePercent.ToString Then

                    RecalculateOrder(MediaManagerReviewDetail, e.RowHandle)

                ElseIf e.Column.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.StartDate.ToString Then

                    If e.Value IsNot Nothing Then

                        If MediaManagerReviewDetail.MediaFrom = "TV" OrElse MediaManagerReviewDetail.MediaFrom = "Radio" Then

                            MediaManagerReviewDetail.MonthYear = AdvantageFramework.MediaManager.GetBroadcastMonthYear(DbContext, e.Value)

                        Else

                            MediaManagerReviewDetail.MonthYear = MonthName(DatePart(DateInterval.Month, e.Value), True).ToUpper & " " & DatePart(DateInterval.Year, e.Value)

                        End If

                        MediaManagerReviewDetail.SetCloseAndMaterialDates(DbContext)

                    End If

                    If MediaManagerReviewDetail.MediaFrom = "Newspaper" OrElse MediaManagerReviewDetail.MediaFrom = "Magazine" Then

                        MediaManagerReviewDetail.EndDate = e.Value

                    ElseIf MediaManagerReviewDetail.MediaFrom = "Radio" OrElse MediaManagerReviewDetail.MediaFrom = "TV" Then

                        If e.Value IsNot Nothing AndAlso MediaManagerReviewDetail.EndDate.HasValue Then

                            MediaManagerReviewDetail.EndDate = Nothing

                            RecalculateOrder(MediaManagerReviewDetail, e.RowHandle)

                        End If

                    End If

                ElseIf e.Column.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.NewspaperColumns.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.NewspaperInches.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.NewspaperCirculation.ToString Then

                    RecalculateOrder(MediaManagerReviewDetail, e.RowHandle)

                ElseIf e.Column.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.NewspaperCirculationQTY.ToString Then

                    If MediaManagerReviewDetail.NewspaperCost = "CPM" Then

                        MediaManagerReviewDetail.NewspaperCirculationQTY = CInt(e.Value)

                    End If

                    RecalculateOrder(MediaManagerReviewDetail, e.RowHandle)

                ElseIf e.Column.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.ProjectedImpressions.ToString Then

                    MediaManagerReviewDetail.GuaranteedImpressions = e.Value

                    RecalculateOrder(MediaManagerReviewDetail, e.RowHandle)

                ElseIf e.Column.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.ActualImpressions.ToString Then

                    RecalculateOrder(MediaManagerReviewDetail, e.RowHandle)

                ElseIf e.Column.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.InternetCostType.ToString Then

                    'If e.Value = "NA" Then

                    '    MediaManagerReviewDetail.Rate = Nothing

                    'End If

                    RecalculateOrder(MediaManagerReviewDetail, e.RowHandle)

                ElseIf e.Column.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.JobMediaBillDate.ToString Then

                    MediaManagerReviewDetail.JobMediaBillDateColumnUpdated = True

                    MediaManagerReviewDetails = DataGridViewOrderDetails_OrderDetails.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).
                                                Where(Function(Entity) Entity.JobNumber.HasValue AndAlso
                                                                       Entity.JobNumber.Value = MediaManagerReviewDetail.JobNumber AndAlso
                                                                       Entity.JobComponentNumber.HasValue AndAlso
                                                                       Entity.JobComponentNumber = MediaManagerReviewDetail.JobComponentNumber).ToList

                    For Each MMRD In MediaManagerReviewDetails

                        MMRD.JobMediaBillDate = MediaManagerReviewDetail.JobMediaBillDate

                        MMRD.DbContext = DbContext
                        MMRD.ValidateEntity(True)

                    Next

                    DataGridViewOrderDetails_OrderDetails.CurrentView.RefreshData()

                ElseIf e.Column.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.JobComponentNumber.ToString Then

                    If e.Value IsNot Nothing Then

                        JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, MediaManagerReviewDetail.JobNumber.Value, e.Value)

                        If JobComponent IsNot Nothing Then

                            MediaManagerReviewDetail.JobMediaBillDate = JobComponent.MediaBillDate

                            DataGridViewOrderDetails_OrderDetails.CurrentView.RefreshRow(e.RowHandle)

                        End If

                    End If

                End If

                If e.Column.FieldName <> AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.Quote.ToString AndAlso
                        e.Column.FieldName <> AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.JobMediaBillDate.ToString Then

                    MediaManagerReviewDetail.ReviseUpdateOrder = True

                End If

                MediaManagerReviewDetail.DbContext = DbContext
                MediaManagerReviewDetail.ValidateEntity(True)

            End Using

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewOrderDetails_OrderDetails_CellValueChangingEvent(ByRef Saved As Boolean, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewOrderDetails_OrderDetails.CellValueChangingEvent

            Dim MediaManagerReviewDetail As AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail = Nothing
            Dim MediaManagerReviewDetails As IEnumerable(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail) = Nothing

            If DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.Quote.ToString Then

                MediaManagerReviewDetail = DataGridViewOrderDetails_OrderDetails.CurrentView.GetRow(DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedRowHandle)

                If e.Value = True Then

                    Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        If String.IsNullOrWhiteSpace(MediaManagerReviewDetail.BillingUser) = False OrElse
                                Not AdvantageFramework.MediaManager.CanOrderChangeToQuote(DbContext, MediaManagerReviewDetail.OrderNumber, MediaManagerReviewDetail.MediaFrom, False) Then

                            AdvantageFramework.WinForm.MessageBox.Show("Order cannot be changed to quote.")

                            DataGridViewOrderDetails_OrderDetails.CurrentView.CloseEditorForUpdating()

                            Saved = True

                        Else

                            MediaManagerReviewDetail.QuoteColumnUpdated = True

                        End If

                    End Using

                Else

                    MediaManagerReviewDetail.QuoteColumnUpdated = True

                End If

                If MediaManagerReviewDetail.QuoteColumnUpdated Then

                    MediaManagerReviewDetails = DataGridViewOrderDetails_OrderDetails.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).Where(Function(MMRD) MMRD.OrderNumber = MediaManagerReviewDetail.OrderNumber).ToList

                    For Each MediaManagerReviewDetail In MediaManagerReviewDetails

                        MediaManagerReviewDetail.Quote = e.Value

                    Next

                    DataGridViewOrderDetails_OrderDetails.CurrentView.RefreshData()

                    DataGridViewOrderDetails_OrderDetails.SetUserEntryChanged()

                    EnableOrDisableActions()

                End If

            ElseIf DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.OrderAccepted.ToString Then

                MediaManagerReviewDetail = DataGridViewOrderDetails_OrderDetails.CurrentView.GetRow(DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedRowHandle)

                If e.Value = True Then

                    AdvantageFramework.MediaManager.CreateOrderAccepted(Session, MediaManagerReviewDetail)

                Else

                    If String.IsNullOrWhiteSpace(MediaManagerReviewDetail.RevisedBy) Then

                        If AdvantageFramework.WinForm.MessageBox.Show("This order/line has been approved by the vendor rep, are you sure you want to remove this approval?", WinForm.MessageBox.MessageBoxButtons.YesNo, MessageBoxDefaultButton:=Windows.Forms.MessageBoxDefaultButton.Button2) = WinForm.MessageBox.DialogResults.Yes Then

                            AdvantageFramework.MediaManager.RemoveOrderAccepted(Session, MediaManagerReviewDetail)

                        Else

                            DataGridViewOrderDetails_OrderDetails.CurrentView.CloseEditorForUpdating()

                        End If

                    Else

                        AdvantageFramework.MediaManager.RemoveOrderAccepted(Session, MediaManagerReviewDetail)

                    End If

                End If

                Saved = True

                DataGridViewOrderDetails_OrderDetails.CurrentView.RefreshData()

                TabItemReviewItems_OrderStatus.Tag = False

            End If

        End Sub
        Private Sub DataGridViewOrderDetails_OrderDetails_CustomRowCellEditEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles DataGridViewOrderDetails_OrderDetails.CustomRowCellEditEvent

            If e.RowHandle >= 0 AndAlso e.Column.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.NewspaperCirculationQTY.ToString Then

                If DirectCast(DataGridViewOrderDetails_OrderDetails.CurrentView.GetRow(e.RowHandle), AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).NewspaperCost = "CPL" Then

                    e.RepositoryItem = _SubItemNumericInputCPL

                ElseIf DirectCast(DataGridViewOrderDetails_OrderDetails.CurrentView.GetRow(e.RowHandle), AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).NewspaperCost = "CPM" Then

                    e.RepositoryItem = _SubItemNumericInputCPM

                End If

            End If

        End Sub
        Private Sub DataGridViewOrderDetails_OrderDetails_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewOrderDetails_OrderDetails.DataSourceChangedEvent

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            If Not Me.IsFormClosing Then

                DataGridViewOrderDetails_OrderDetails.CurrentView.OptionsView.ShowFooter = True

                For Each GridColumn In DataGridViewOrderDetails_OrderDetails.Columns

                    If GridColumn.ColumnType Is GetType(System.Decimal) OrElse
                            GridColumn.ColumnType Is GetType(System.Nullable(Of Decimal)) OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.Spots.ToString Then

                        If GridColumn.FieldName <> AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.Rate.ToString Then

                            AdvantageFramework.Billing.Presentation.SetColumnAsSumColumn(DataGridViewOrderDetails_OrderDetails, GridColumn.FieldName)

                            If GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.Spots.ToString Then

                                GridColumn.SummaryItem.DisplayFormat = "{0:n0}"

                            End If

                        End If

                    End If

                Next

            End If

        End Sub
        Private Sub DataGridViewOrderDetails_OrderDetails_HideCustomizationFormEvent(sender As Object, e As EventArgs) Handles DataGridViewOrderDetails_OrderDetails.HideCustomizationFormEvent

            If ButtonItemGridOptionsOrderDetails_ChooseColumns.Checked Then

                ButtonItemGridOptionsOrderDetails_ChooseColumns.Checked = False

            End If

        End Sub
        Private Sub DataGridViewOrderDetails_OrderDetails_PopupMenuShowingEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles DataGridViewOrderDetails_OrderDetails.PopupMenuShowingEvent

            If e.HitInfo.Column IsNot Nothing AndAlso e.HitInfo.Column.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.ForceRevision.ToString Then

                e.Allow = False

            ElseIf e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Column Then

                For Each DXMenuItem In e.Menu.Items

                    If DXMenuItem.Tag IsNot Nothing AndAlso DXMenuItem.Tag.GetType Is GetType(DevExpress.XtraGrid.Localization.GridStringId) Then

                        If CType(DXMenuItem.Tag, DevExpress.XtraGrid.Localization.GridStringId) = DevExpress.XtraGrid.Localization.GridStringId.MenuColumnGroup OrElse
                                CType(DXMenuItem.Tag, DevExpress.XtraGrid.Localization.GridStringId) = DevExpress.XtraGrid.Localization.GridStringId.MenuColumnGroupBox Then

                            DXMenuItem.Enabled = False

                        End If

                    End If

                Next

            End If

        End Sub
        Private Sub DataGridViewOrderDetails_OrderDetails_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewOrderDetails_OrderDetails.QueryPopupNeedDatasourceEvent

            Dim MediaManagerReviewDetail As AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail = Nothing

            MediaManagerReviewDetail = DataGridViewOrderDetails_OrderDetails.GetRowDataBoundItem(DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedRowHandle)

            If FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.CampaignID.ToString Then

                OverrideDefaultDatasource = True

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Datasource = AdvantageFramework.MediaManager.GetCampaignIDDatasource(DbContext, MediaManagerReviewDetail.ClientCode, MediaManagerReviewDetail.DivisionCode, MediaManagerReviewDetail.ProductCode)

                End Using

            ElseIf FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.JobNumber.ToString Then

                OverrideDefaultDatasource = True

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Datasource = AdvantageFramework.MediaManager.GetJobNumberDatasource(DbContext, MediaManagerReviewDetail.ClientCode, MediaManagerReviewDetail.DivisionCode, MediaManagerReviewDetail.ProductCode)

                End Using

            ElseIf FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.JobComponentNumber.ToString Then

                OverrideDefaultDatasource = True

                If MediaManagerReviewDetail.JobNumber.HasValue Then

                    Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        Datasource = AdvantageFramework.MediaManager.GetJobComponentNumberDatasource(DbContext, MediaManagerReviewDetail.ClientCode, MediaManagerReviewDetail.DivisionCode, MediaManagerReviewDetail.ProductCode, MediaManagerReviewDetail.JobNumber)

                    End Using

                End If

            ElseIf FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.InternetCostType.ToString Then

                OverrideDefaultDatasource = True

                Datasource = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.InternetCostType)).ToList
                              Select [Code] = EnumObject.Code,
                                     [Description] = EnumObject.Description).ToList

            End If

        End Sub
        Private Sub DataGridViewOrderDetails_OrderDetails_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewOrderDetails_OrderDetails.SelectionChangedEvent

            Dim MediaManagerReviewDetails As Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail) = Nothing
            Dim OrderNumbers As IEnumerable(Of Integer) = Nothing
            Dim VendorCodes As IEnumerable(Of String) = Nothing

            _AtLeastOneOrderFromWorksheet = False
            _AtLeastOneFromWorksheetIsNotCable = False

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                For Each TabItem In TabControlForm_ReviewItems.Tabs.OfType(Of DevComponents.DotNetBar.TabItem)()

                    If Not TabItem.Equals(TabItemReviewItems_OrderDetails) AndAlso Not TabItem.Equals(TabItemReviewItems_VCCDetails) Then

                        TabItem.Tag = False

                    End If

                Next

                MediaManagerReviewDetails = DataGridViewOrderDetails_OrderDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).ToList

                If (From MMRD In MediaManagerReviewDetails
                    Where {"T"}.Contains(MMRD.MediaFrom.Substring(0, 1))
                    Select MMRD).Any Then

                    Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        OrderNumbers = MediaManagerReviewDetails.Select(Function(MM) MM.OrderNumber).Distinct.ToArray
                        VendorCodes = MediaManagerReviewDetails.Select(Function(MM) MM.VendorCode).Distinct.ToArray

                        If (From Entity In AdvantageFramework.Database.Procedures.BroadcastImportCrossReference.Load(DbContext)
                            Where OrderNumbers.Contains(Entity.OrderNumber) AndAlso
                                  Entity.ImportedFrom = "AW").Any Then

                            _AtLeastOneOrderFromWorksheet = True

                            If (From Entity In AdvantageFramework.Database.Procedures.Vendor.Load(DbContext)
                                Where VendorCodes.Contains(Entity.Code) AndAlso
                                      Entity.IsCableSystem = False AndAlso
                                      Entity.NCCTVSyscodeID Is Nothing).Any Then

                                _AtLeastOneFromWorksheetIsNotCable = True

                            End If

                        End If

                    End Using

                End If

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub DataGridViewOrderDetails_OrderDetails_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewOrderDetails_OrderDetails.ShowingEditorEvent

            Dim MediaManagerReviewDetail As AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
            Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing

            MediaManagerReviewDetail = DataGridViewOrderDetails_OrderDetails.CurrentView.GetRow(DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedRowHandle)

            If MediaManagerReviewDetail.Cancelled OrElse Not String.IsNullOrWhiteSpace(MediaManagerReviewDetail.BillingUser) OrElse MediaManagerReviewDetail.IsOrderClosed Then

                e.Cancel = True

            ElseIf DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.Spots.ToString Then

                e.Cancel = True

            ElseIf DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.StartDate.ToString OrElse
                   DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.EndDate.ToString OrElse
                   DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.BroadcastProgramming.ToString OrElse
                   DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.BroadcastStartTime.ToString OrElse
                   DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.BroadcastEndTime.ToString OrElse
                   DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.BroadcastLength.ToString OrElse
                   DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.MarketCode.ToString Then
                'DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.Rate.ToString OrElse
                If MediaManagerReviewDetail.ImportedFrom = "AW" Then

                    e.Cancel = True

                End If

            ElseIf DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.InternetType.ToString Then

                If MediaManagerReviewDetail.AdServerPlacementID.HasValue OrElse MediaManagerReviewDetail.MediaFrom <> "Internet" OrElse MediaManagerReviewDetail.AdServerPackageID.HasValue Then

                    e.Cancel = True

                End If

            ElseIf DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.CampaignID.ToString Then

                If MediaManagerReviewDetail.AdServerPlacementID.HasValue OrElse MediaManagerReviewDetail.AdServerPackageID.HasValue Then

                    e.Cancel = True

                End If

            ElseIf (DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.CampaignEndDate.ToString OrElse
                    DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.CampaignStartDate.ToString) Then

                If MediaManagerReviewDetail.CampaignID.HasValue = False Then

                    e.Cancel = True

                End If

            ElseIf DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.EndDate.ToString Then

                If MediaManagerReviewDetail.MediaFrom = "Newspaper" Then

                    e.Cancel = Not MediaManagerReviewDetail.IsDailyNewspaper

                ElseIf MediaManagerReviewDetail.MediaFrom <> "Out Of Home" AndAlso MediaManagerReviewDetail.MediaFrom <> "Internet" Then

                    e.Cancel = True

                End If

            ElseIf (DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.BroadcastProgramming.ToString OrElse
                    DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.BroadcastRemarks.ToString OrElse
                    DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.BroadcastStartTime.ToString OrElse
                    DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.BroadcastEndTime.ToString OrElse
                    DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.BroadcastLength.ToString OrElse
                    DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.Spots.ToString) AndAlso
                    MediaManagerReviewDetail.MediaFrom <> "Radio" AndAlso MediaManagerReviewDetail.MediaFrom <> "TV" Then

                e.Cancel = True

            ElseIf (DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.Headline.ToString OrElse
                    DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.AdSizeCode.ToString OrElse
                    DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.AdSizeDescription.ToString) AndAlso
                    (MediaManagerReviewDetail.MediaFrom = "Radio" OrElse MediaManagerReviewDetail.MediaFrom = "TV") Then

                e.Cancel = True

            ElseIf (DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.InternetCostType.ToString OrElse
                    DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.InternetPlacement1.ToString OrElse
                    DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.InternetPlacement2.ToString OrElse
                    DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.InternetURL.ToString OrElse
                    DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.InternetTargetAudience.ToString) AndAlso
                    MediaManagerReviewDetail.MediaFrom <> "Internet" Then

                e.Cancel = True

            ElseIf (DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.GuaranteedImpressions.ToString OrElse
                    DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.ProjectedImpressions.ToString OrElse
                    DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.ActualImpressions.ToString) AndAlso
                   (MediaManagerReviewDetail.MediaFrom <> "Internet" AndAlso MediaManagerReviewDetail.MediaFrom <> "Out Of Home") Then

                e.Cancel = True

            ElseIf (DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.Issue.ToString OrElse
                    DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.ProductionSize.ToString OrElse
                    DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.Material.ToString) AndAlso
                    MediaManagerReviewDetail.MediaFrom <> "Magazine" AndAlso MediaManagerReviewDetail.MediaFrom <> "Newspaper" Then

                e.Cancel = True

            ElseIf DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.MagazineCirculationQTY.ToString AndAlso
                    MediaManagerReviewDetail.MediaFrom <> "Magazine" Then

                e.Cancel = True

            ElseIf (DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.NewspaperSection.ToString OrElse
                    DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.NewspaperCostRate.ToString) AndAlso
                    MediaManagerReviewDetail.MediaFrom <> "Newspaper" Then

                e.Cancel = True

            ElseIf DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.NewspaperCirculationQTY.ToString Then

                If MediaManagerReviewDetail.MediaFrom <> "Newspaper" OrElse (MediaManagerReviewDetail.MediaFrom = "Newspaper" AndAlso
                        (MediaManagerReviewDetail.NewspaperCost = "NA" OrElse MediaManagerReviewDetail.NewspaperCost = "CPI")) Then

                    e.Cancel = True

                End If

            ElseIf DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.NewspaperColumns.ToString OrElse
                    DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.NewspaperInches.ToString Then

                If MediaManagerReviewDetail.MediaFrom <> "Newspaper" OrElse (MediaManagerReviewDetail.MediaFrom = "Newspaper" AndAlso MediaManagerReviewDetail.NewspaperCost <> "CPI") Then

                    e.Cancel = True

                End If

            ElseIf (DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.OutdoorType.ToString OrElse
                    DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.OutdoorLocation.ToString OrElse
                    DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.OutdoorCopyArea.ToString) AndAlso
                    MediaManagerReviewDetail.MediaFrom <> "Out Of Home" Then

                e.Cancel = True

            ElseIf DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.JobComponentNumber.ToString AndAlso
                    Not MediaManagerReviewDetail.JobNumber.HasValue Then

                e.Cancel = True

            ElseIf DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.MarkupPercent.ToString Then

                If MediaManagerReviewDetail.NetGross <> "Net" Then

                    e.Cancel = True

                End If

            ElseIf DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.RebatePercent.ToString Then

                If MediaManagerReviewDetail.NetGross <> "Gross" Then

                    e.Cancel = True

                End If

            ElseIf DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.JobMediaBillDate.ToString Then

                If Not MediaManagerReviewDetail.JobNumber.HasValue OrElse Not MediaManagerReviewDetail.JobComponentNumber.HasValue Then

                    e.Cancel = True

                End If

            ElseIf DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.Buyer.ToString Then

                If Not String.IsNullOrWhiteSpace(MediaManagerReviewDetail.BuyerEmployeeCode) Then

                    e.Cancel = True

                End If

            Else

                PropertyDescriptor = _ObjectTypePropertyDescriptors.Where(Function(EA) EA.Name = DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName).SingleOrDefault

                If PropertyDescriptor IsNot Nothing Then

                    EntityAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).SingleOrDefault

                    If EntityAttribute IsNot Nothing AndAlso EntityAttribute.IsReadOnlyColumn Then

                        e.Cancel = True

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewOrderDetails_OrderDetails_ShowCustomizationFormEvent(sender As Object, e As EventArgs) Handles DataGridViewOrderDetails_OrderDetails.ShowCustomizationFormEvent

            For Each GridColumn In DataGridViewOrderDetails_OrderDetails.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                GridColumn.Caption = GridColumn.Caption.Replace(vbCrLf, " ")

            Next

        End Sub
        Private Sub DataGridViewOrderDetails_OrderDetails_SubItemTextBoxButtonClickEvent(RowObject As Object) Handles DataGridViewOrderDetails_OrderDetails.SubItemTextBoxButtonClickEvent

            'objects
            Dim MediaManagerReviewDetail As AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail = Nothing
            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
            Dim SelectedClientPOs As IEnumerable = Nothing
            Dim ClientPO As String = Nothing
            Dim SelectedAdNumbers As IEnumerable = Nothing
            Dim AdNumber As String = Nothing
            Dim SelectedAdSizeCodes As IEnumerable = Nothing
            Dim AdSizeCode As String = Nothing

            If DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.ClientPO.ToString Then

                MediaManagerReviewDetail = DataGridViewOrderDetails_OrderDetails.CurrentView.GetRow(DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedRowHandle)

                If MediaManagerReviewDetail IsNot Nothing Then

                    ParameterDictionary = New Generic.Dictionary(Of String, Object)
                    ParameterDictionary.Add("ClientCode", MediaManagerReviewDetail.ClientCode)
                    ParameterDictionary.Add("DivisionCode", MediaManagerReviewDetail.DivisionCode)
                    ParameterDictionary.Add("ProductCode", MediaManagerReviewDetail.ProductCode)

                    If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.ClientPO, True, True, SelectedClientPOs, False, Nothing, False, False, ParameterDictionary) = Windows.Forms.DialogResult.OK Then

                        If SelectedClientPOs IsNot Nothing Then

                            Try

                                ClientPO = (From Entity In SelectedClientPOs
                                            Select Entity.ClientPONumber).FirstOrDefault

                            Catch ex As Exception
                                ClientPO = Nothing
                            End Try

                            If ClientPO IsNot Nothing Then

                                DataGridViewOrderDetails_OrderDetails.CurrentView.SetRowCellValue(DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedRowHandle, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.ClientPO.ToString, ClientPO)

                                DataGridViewOrderDetails_OrderDetails.AddToModifiedRows(DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedRowHandle)

                                DataGridViewOrderDetails_OrderDetails.SetUserEntryChanged()

                            End If

                        End If

                    End If

                End If

            ElseIf DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.AdNumber.ToString Then

                MediaManagerReviewDetail = DataGridViewOrderDetails_OrderDetails.CurrentView.GetRow(DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedRowHandle)

                If MediaManagerReviewDetail IsNot Nothing Then

                    ParameterDictionary = New Generic.Dictionary(Of String, Object)
                    ParameterDictionary.Add("ClientCode", MediaManagerReviewDetail.ClientCode)

                    If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.AdNumber, True, True, SelectedAdNumbers, False, Nothing, False, False, ParameterDictionary) = Windows.Forms.DialogResult.OK Then

                        If SelectedAdNumbers IsNot Nothing Then

                            Try

                                AdNumber = (From Entity In SelectedAdNumbers
                                            Select Entity.Number).FirstOrDefault

                            Catch ex As Exception
                                AdNumber = Nothing
                            End Try

                            If AdNumber IsNot Nothing Then

                                DataGridViewOrderDetails_OrderDetails.CurrentView.SetRowCellValue(DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedRowHandle, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.AdNumber.ToString, AdNumber)

                                DataGridViewOrderDetails_OrderDetails.AddToModifiedRows(DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedRowHandle)

                                DataGridViewOrderDetails_OrderDetails.SetUserEntryChanged()

                            End If

                        End If

                    End If

                End If

            ElseIf DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.AdSizeCode.ToString Then

                MediaManagerReviewDetail = DataGridViewOrderDetails_OrderDetails.CurrentView.GetRow(DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedRowHandle)

                If MediaManagerReviewDetail IsNot Nothing Then

                    ParameterDictionary = New Generic.Dictionary(Of String, Object)
                    ParameterDictionary.Add("MediaType", MediaManagerReviewDetail.MediaFrom.Substring(0, 1))

                    If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.AdSizeCode, True, True, SelectedAdSizeCodes, False, Nothing, False, False, ParameterDictionary) = Windows.Forms.DialogResult.OK Then

                        If SelectedAdSizeCodes IsNot Nothing Then

                            Try

                                AdSizeCode = (From Entity In SelectedAdSizeCodes
                                              Select Entity.Code).FirstOrDefault

                            Catch ex As Exception
                                AdSizeCode = Nothing
                            End Try

                            If AdSizeCode IsNot Nothing Then

                                DataGridViewOrderDetails_OrderDetails.CurrentView.SetRowCellValue(DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedRowHandle, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.AdSizeCode.ToString, AdSizeCode)

                                DataGridViewOrderDetails_OrderDetails.AddToModifiedRows(DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedRowHandle)

                                DataGridViewOrderDetails_OrderDetails.SetUserEntryChanged()

                            End If

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewVendorReps_VendorReps_CellValueChangingEvent(ByRef Saved As Boolean, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewVendorReps_VendorReps.CellValueChangingEvent

            Dim VendorRep As AdvantageFramework.MediaManager.Classes.VendorRep = Nothing

            VendorRep = DataGridViewVendorReps_VendorReps.CurrentView.GetRow(e.RowHandle)

            If VendorRep IsNot Nothing Then

                If e.Column.FieldName = AdvantageFramework.MediaManager.Classes.VendorRep.Properties.IsOrderRep1.ToString Then

                    SaveVendorRep(e.Value, VendorRep, True, DataGridViewVendorReps_VendorReps.CurrentView.Tag)

                ElseIf e.Column.FieldName = AdvantageFramework.MediaManager.Classes.VendorRep.Properties.IsOrderRep2.ToString Then

                    SaveVendorRep(e.Value, VendorRep, False, DataGridViewVendorReps_VendorReps.CurrentView.Tag)

                End If

                LoadVendorRepsTab()

            End If

        End Sub
        Private Sub DataGridViewVendorReps_VendorReps_RowDoubleClickEvent() Handles DataGridViewVendorReps_VendorReps.RowDoubleClickEvent

            If _HasAccessToVendorRep Then

                EditSelectedVendorRep()

            End If

        End Sub
        Private Sub DataGridViewVendorReps_VendorReps_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewVendorReps_VendorReps.ShowingEditorEvent

            If DataGridViewVendorReps_VendorReps.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.MediaManager.Classes.VendorRep.Properties.IsOrderRep1.ToString AndAlso
                    DataGridViewVendorReps_VendorReps.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.MediaManager.Classes.VendorRep.Properties.IsOrderRep2.ToString Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DataGridViewTopVCCDetails_VCCOrders_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewTopVCCDetails_VCCOrders.DataSourceChangedEvent

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            If Not Me.IsFormClosing Then

                DataGridViewTopVCCDetails_VCCOrders.CurrentView.OptionsView.ShowFooter = True

                For Each GridColumn In DataGridViewTopVCCDetails_VCCOrders.Columns

                    If GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.VCCOrder.Properties.CardAmount.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.VCCOrder.Properties.VendorCost.ToString Then

                        AdvantageFramework.Billing.Presentation.SetColumnAsSumColumn(DataGridViewTopVCCDetails_VCCOrders, GridColumn.FieldName)

                    End If

                Next

            End If

        End Sub
        Private Sub DataGridViewTopVCCDetails_VCCOrders_HideCustomizationFormEvent(sender As Object, e As EventArgs) Handles DataGridViewTopVCCDetails_VCCOrders.HideCustomizationFormEvent

            If ButtonItemGridOptionsVCCDetails_ChooseColumns.Checked Then

                ButtonItemGridOptionsVCCDetails_ChooseColumns.Checked = False

            End If

        End Sub
        Private Sub DataGridViewTopVCCDetails_VCCOrders_PopupMenuShowingEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles DataGridViewTopVCCDetails_VCCOrders.PopupMenuShowingEvent

            If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Column Then

                For Each DXMenuItem In e.Menu.Items

                    If DXMenuItem.Tag IsNot Nothing AndAlso DXMenuItem.Tag.GetType Is GetType(DevExpress.XtraGrid.Localization.GridStringId) Then

                        If CType(DXMenuItem.Tag, DevExpress.XtraGrid.Localization.GridStringId) = DevExpress.XtraGrid.Localization.GridStringId.MenuColumnGroup OrElse
                                CType(DXMenuItem.Tag, DevExpress.XtraGrid.Localization.GridStringId) = DevExpress.XtraGrid.Localization.GridStringId.MenuColumnGroupBox Then

                            DXMenuItem.Enabled = False

                        End If

                    End If

                Next

            End If

        End Sub
        Private Sub DataGridViewTopVCCDetails_VCCOrders_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewTopVCCDetails_VCCOrders.QueryPopupNeedDatasourceEvent

            If FieldName = AdvantageFramework.MediaManager.Classes.VCCOrder.Properties.CardStatus.ToString Then

                OverrideDefaultDatasource = True

                Datasource = AdvantageFramework.MediaManager.GetCardStatusDatasource()

            End If

        End Sub
        Private Sub DataGridViewTopVCCDetails_VCCOrders_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewTopVCCDetails_VCCOrders.SelectionChangedEvent

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                For Each TabItem In TabControlVCCDetails_Details.Tabs.OfType(Of DevComponents.DotNetBar.TabItem)()

                    TabItem.Tag = False

                Next

                LoadVCCTabItems()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub DataGridViewTopVCCDetails_VCCOrders_ShowCustomizationFormEvent(sender As Object, e As EventArgs) Handles DataGridViewTopVCCDetails_VCCOrders.ShowCustomizationFormEvent

            For Each GridColumn In DataGridViewTopVCCDetails_VCCOrders.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                GridColumn.Caption = GridColumn.Caption.Replace(vbCrLf, " ")

            Next

        End Sub
        Private Sub DocumentManagerControlDocuments_Documents_SelectedDocumentChanged() Handles DocumentManagerControlDocuments_Documents.SelectedDocumentChanged

            EnableOrDisableActions()

        End Sub
        Private Sub MediaBillingHistoryControlBillingInvoices_BillingInvoices_SelectedTabChanged() Handles MediaBillingHistoryControlBillingInvoices_BillingInvoices.SelectedTabChanged

            EnableOrDisableActions()

        End Sub
        Private Sub MediaBillingHistoryControlBillingInvoices_BillingInvoices_SelectedDocumentChanged() Handles MediaBillingHistoryControlBillingInvoices_BillingInvoices.SelectedDocumentChanged

            EnableOrDisableActions()

        End Sub
        Private Sub TabControlForm_ReviewItems_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlForm_ReviewItems.SelectedTabChanged

            EnableOrDisableActions()

        End Sub
        Private Sub TabControlForm_ReviewItems_SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControlForm_ReviewItems.SelectedTabChanging

            If Session IsNot Nothing AndAlso Me.FormShown AndAlso Not Me.IsFormClosing Then

                DataGridViewTopVCCDetails_VCCOrders.CurrentView.CloseEditorForUpdating()
                DataGridViewOrderDetails_OrderDetails.CurrentView.CloseEditorForUpdating()
                DataGridViewLineComments_LineComments.CurrentView.CloseEditorForUpdating()
                DataGridViewOrderComments_OrderComments.CurrentView.CloseEditorForUpdating()
                DocumentManagerControlDocuments_Documents.DataGridViewForm_Documents.CurrentView.CloseEditorForUpdating()

                e.Cancel = Not CheckForUnsavedChanges()

                If Not e.Cancel Then

                    Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem

                    TabControlForm_ReviewItems.SuspendLayout()

                    If e.NewTab Is TabItemReviewItems_VCCDetails Then

                        For Each TabItem In TabControlForm_ReviewItems.Tabs.OfType(Of DevComponents.DotNetBar.TabItem)()

                            If Not TabItem.Equals(TabItemReviewItems_OrderDetails) AndAlso Not TabItem.Equals(TabItemReviewItems_VCCDetails) Then

                                TabItem.Tag = False

                            End If

                        Next

                        If e.NewTab.Tag = False Then

                            LoadVCCDetailsTopTab()

                            If e.OldTab.Equals(TabItemReviewItems_OrderDetails) Then

                                SelectVCCDetailsBasedOnOrderDetails()

                            ElseIf e.OldTab.Equals(TabItemReviewItems_PurchaseOrderDetails) Then

                                SelectVCCDetailsBasedOnPODetails()

                            End If

                        End If

                    ElseIf e.NewTab Is TabItemReviewItems_OrderDetails Then

                        If e.NewTab.Tag = False Then

                            LoadOrderDetailsTab()

                        End If

                        If e.OldTab.Equals(TabItemReviewItems_VCCDetails) Then

                            SelectOrderDetailsBasedOnVCCDetails()

                        End If

                        If DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedRowHandle >= 0 Then

                            DataGridViewOrderDetails_OrderDetails.CurrentView.MakeRowVisible(DataGridViewOrderDetails_OrderDetails.CurrentView.FocusedRowHandle)

                        End If

                    ElseIf e.NewTab Is TabItemReviewItems_OrderStatus Then

                        If e.NewTab.Tag = False Then

                            LoadOrderStatusTab()

                        End If

                    ElseIf e.NewTab Is TabItemReviewItems_OrderComments Then

                        If e.NewTab.Tag = False Then

                            LoadOrderHeaderCommentsTab()

                        End If

                    ElseIf e.NewTab Is TabItemReviewItems_LineComments Then

                        If e.NewTab.Tag = False Then

                            LoadOrderLineCommentsTab()

                        End If

                    ElseIf e.NewTab Is TabItemReviewItems_APInvoiceDetail Then

                        If e.NewTab.Tag = False Then

                            LoadAPInvoicesPostedTab()

                        End If

                    ElseIf e.NewTab Is TabItemReviewItems_VendorCollectedDetails Then

                        If e.NewTab.Tag = False Then

                            LoadVendorCollectedDetailsTab()

                        End If

                    ElseIf e.NewTab Is TabItemReviewItems_BillingInvoices Then

                        If e.NewTab.Tag = False Then

                            LoadBillingInvoicesTab()

                        End If

                    ElseIf e.NewTab Is TabItemReviewItems_VendorReps Then

                        If e.NewTab.Tag = False Then

                            LoadVendorRepsTab()

                        End If

                    ElseIf e.NewTab Is TabItemReviewItems_Documents Then

                        If e.NewTab.Tag = False Then

                            LoadDocumentsTab()

                        End If

                    ElseIf e.NewTab Is TabItemReviewItems_PurchaseOrderDetails Then

                        If e.NewTab.Tag = False Then

                            LoadPODetailsTab()

                        End If

                        If e.OldTab.Equals(TabItemReviewItems_VCCDetails) Then

                            SelectPODetailsBasedOnVCCDetails()

                        End If

                    ElseIf e.NewTab Is TabItemReviewItems_PurchaseOrderStatus Then

                        If e.NewTab.Tag = False Then

                            LoadPurchaseOrderStatusTab()

                        End If

                    End If

                End If

                TabControlForm_ReviewItems.ResumeLayout()

                Me.FormAction = WinForm.Presentation.FormActions.None

                Me.ClearChanged()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub TabControlVCCDetails_Details_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlVCCDetails_Details.SelectedTabChanged

            LoadVCCTabItems()

        End Sub
        Private Sub ButtonItemVendorInvoices_ImportInvoices_Click(sender As Object, e As EventArgs) Handles ButtonItemVendorInvoices_ImportInvoices.Click

            Me.OpenModuleOnBaseFormParent(Security.Methods.Modules.FinanceAccounting_AccountsPayable_AP_ExpenseReport_Import)

        End Sub
        Private Sub MediaManagerReviewDialog_BaseFormParentFormClosedEvent(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.BaseFormParentFormClosedEvent

            If TypeOf sender Is AdvantageFramework.Importing.Presentation.ImportForm Then

                AddHandler DirectCast(sender, System.Windows.Forms.Form).MdiParent.MdiChildActivate, AddressOf FinishedClosingTab

                RefreshForm()

            End If

        End Sub
        Private Sub FinishedClosingTab(sender As Object, e As EventArgs)

            RemoveHandler DirectCast(sender, System.Windows.Forms.Form).MdiChildActivate, AddressOf FinishedClosingTab

            Me.Show()
            Me.BringToFront()

        End Sub
        Private Sub DataGridViewPODetails_PODetails_CustomColumnDisplayTextEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles DataGridViewPODetails_PODetails.CustomColumnDisplayTextEvent

            If e.Column.FieldName = AdvantageFramework.DTO.Media.MediaManager.MediaManagerPODetail.Properties.PONumber.ToString AndAlso e.Column.View.GetRowHandle(e.ListSourceRowIndex) >= 0 Then

                If IsNumeric(DirectCast(DataGridViewPODetails_PODetails.CurrentView.GetRow(e.Column.View.GetRowHandle(e.ListSourceRowIndex)), AdvantageFramework.DTO.Media.MediaManager.MediaManagerPODetail).DisplayPONumber) = False Then

                    e.DisplayText = DirectCast(DataGridViewPODetails_PODetails.CurrentView.GetRow(e.Column.View.GetRowHandle(e.ListSourceRowIndex)), AdvantageFramework.DTO.Media.MediaManager.MediaManagerPODetail).DisplayPONumber

                End If

            End If

        End Sub
        Private Sub DataGridViewPODetails_PODetails_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewPODetails_PODetails.SelectionChangedEvent

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                For Each TabItem In TabControlVCCDetails_Details.Tabs.OfType(Of DevComponents.DotNetBar.TabItem)()

                    TabItem.Tag = False

                Next

                TabItemReviewItems_PurchaseOrderStatus.Tag = False

                LoadVCCTabItems()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub DataGridViewPODetails_PODetails_ShowCustomizationFormEvent(sender As Object, e As EventArgs) Handles DataGridViewPODetails_PODetails.ShowCustomizationFormEvent

            For Each GridColumn In DataGridViewPODetails_PODetails.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                GridColumn.Caption = GridColumn.Caption.Replace(vbCrLf, " ")

            Next

        End Sub
        Private Sub DataGridViewTopVCCDetails_VCCOrders_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewTopVCCDetails_VCCOrders.ShowingEditorEvent

            If DataGridViewTopVCCDetails_VCCOrders.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.VCCOrder.Properties.VendorCollected.ToString Then

                If DirectCast(DataGridViewTopVCCDetails_VCCOrders.GetRowDataBoundItem(DataGridViewTopVCCDetails_VCCOrders.CurrentView.FocusedRowHandle), AdvantageFramework.MediaManager.Classes.VCCOrder).PONumber IsNot Nothing Then

                    e.Cancel = True

                End If

            ElseIf DataGridViewTopVCCDetails_VCCOrders.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.MediaManager.Classes.VCCOrder.Properties.CardAmount.ToString AndAlso
                    DataGridViewTopVCCDetails_VCCOrders.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.MediaManager.Classes.VCCOrder.Properties.CardStatus.ToString AndAlso
                    DataGridViewTopVCCDetails_VCCOrders.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.MediaManager.Classes.VCCOrder.Properties.Reviewed.ToString AndAlso
                    DataGridViewTopVCCDetails_VCCOrders.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.MediaManager.Classes.VCCOrder.Properties.Resolved.ToString AndAlso
                    DataGridViewTopVCCDetails_VCCOrders.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.MediaManager.Classes.VCCOrder.Properties.FollowupDate.ToString Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DataGridViewOrderStatus_OrderStatus_CustomDrawCellEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles DataGridViewOrderStatus_OrderStatus.CustomDrawCellEvent

            If e.Column.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerOrderStatus.Properties.MonthNumber.ToString AndAlso IsNumeric(e.CellValue) Then

                e.DisplayText = MonthName(e.CellValue, True).ToUpper

            End If

        End Sub
        Private Sub DataGridViewOrderStatus_OrderStatus_ShowCustomizationFormEvent(sender As Object, e As EventArgs) Handles DataGridViewOrderStatus_OrderStatus.ShowCustomizationFormEvent

            For Each GridColumn In DataGridViewOrderStatus_OrderStatus.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                GridColumn.Caption = GridColumn.Caption.Replace(vbCrLf, " ")

            Next

        End Sub
        Private Sub ButtonItemActions_ExportXML_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_ExportXML.Click

            ExportXMLFiles(False)

        End Sub
        Private Sub ButtonItemActions_ExportXMLAsNew_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_ExportXMLAsNew.Click

            ExportXMLFiles(True)

        End Sub
        Private Sub ButtonItemMediaPlan_Actualize_Click(sender As Object, e As EventArgs) Handles ButtonItemMediaPlan_Actualize.Click

            Dim MediaManagerReviewDetail As AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail = Nothing
            Dim Message As String = String.Empty

            If DataGridViewOrderDetails_OrderDetails.HasASelectedRow Then

                MediaManagerReviewDetail = DirectCast(DataGridViewOrderDetails_OrderDetails.GetFirstSelectedRowDataBoundItem, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail)

                If CheckForOpenMediaPlan(_ParentForm.MdiParent, MediaManagerReviewDetail.MediaPlanID, MediaManagerReviewDetail.MediaPlanDetailID) = False Then

                    If AdvantageFramework.MediaPlanning.IsEstimateLocked(Session, MediaManagerReviewDetail.MediaPlanDetailID, Message) Then

                        AdvantageFramework.WinForm.MessageBox.Show(Message)

                    Else

                        AdvantageFramework.Media.Presentation.MediaPlanActualizeDialog.ShowFormDialog(MediaManagerReviewDetail.MediaPlanDetailID)

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("You currently have this estimate open, please close before accessing.")

                End If

            End If

        End Sub
        'Private Sub DataGridViewTopVCCDetails_VCCOrders_CustomColumnDisplayTextEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles DataGridViewTopVCCDetails_VCCOrders.CustomColumnDisplayTextEvent

        '    If e.Column.FieldName = AdvantageFramework.MediaManager.Classes.VCCOrder.Properties.OrderNumber.ToString OrElse
        '            e.Column.FieldName = AdvantageFramework.MediaManager.Classes.VCCOrder.Properties.LineNumber.ToString Then

        '        If e.DisplayText = "0" Then

        '            e.DisplayText = Nothing

        '        End If

        '    End If

        'End Sub

#End Region

#End Region

    End Class

End Namespace
