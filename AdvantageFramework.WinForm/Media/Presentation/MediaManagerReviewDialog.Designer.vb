Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaManagerReviewDialog
        Inherits WinForm.Presentation.BaseForms.BaseRibbonForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaManagerReviewDialog))
            Me.RibbonBarOptions_GridOptionsOrderDetails = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemGridOptionsOrderDetails_ChooseColumns = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemGridOptionsOrderDetails_RestoreDefaults = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Export = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_ExportGrid = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_ExportXML = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_ExportXMLAsNew = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_SendReminders = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_FollowUp = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_AutoFill = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Refresh = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.TabControlForm_ReviewItems = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelDetailsTab_VCCDetails = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelVCCDetails_Bottom = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.TabControlVCCDetails_Details = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelVCCDetailsTab_VCCDetails = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewBottomVCCDetails_CardDetails = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemVCCDetails_VCCDetailsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelOrderInfoTab_OrderInfo = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewBottomVCCDetails_CardNotes = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemVCCDetails_NotesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.ExpandableSplitterVCCDetails_TopBottom = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelVCCDetails_Top = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewTopVCCDetails_VCCOrders = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemReviewItems_VCCDetails = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelDetailsTab_OrderDetails = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewOrderDetails_OrderDetails = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemReviewItems_OrderDetails = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelPurchaseOrderStatusHistoryTab_PurchaseOrderStatusHistory = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewPOStatus_POStatus = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemReviewItems_PurchaseOrderStatus = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelOrderStatusHistoryTab_OrderStatusHistory = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewOrderStatus_OrderStatus = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemReviewItems_OrderStatus = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelPODetails_PODetails = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewPODetails_PODetails = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemReviewItems_PurchaseOrderDetails = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelVendorRepsTab_VendorReps = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewVendorReps_VendorReps = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemReviewItems_VendorReps = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelBillingInvoicesTab_BillingInvoices = New DevComponents.DotNetBar.TabControlPanel()
            Me.MediaBillingHistoryControlBillingInvoices_BillingInvoices = New AdvantageFramework.WinForm.Presentation.Controls.MediaBillingHistoryControl()
            Me.TabItemReviewItems_BillingInvoices = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelAPInvoicesPostedTab_APInvoicesPosted = New DevComponents.DotNetBar.TabControlPanel()
            Me.ApInvoiceControlAPInvoiceDetail_APInvoiceDetail = New AdvantageFramework.WinForm.Presentation.Controls.APInvoiceControl()
            Me.TabItemReviewItems_APInvoiceDetail = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelPaymentDetailsTab_VendorCollectedDetails = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewVendorCollectedDetails_VendorCollectedDetails = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemReviewItems_VendorCollectedDetails = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelLineCommentsTab_LineComments = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewLineComments_LineComments = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemReviewItems_LineComments = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelDocumentsTab_Documents = New DevComponents.DotNetBar.TabControlPanel()
            Me.DocumentManagerControlDocuments_Documents = New AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl()
            Me.TabItemReviewItems_Documents = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelOrderCommentsTab_OrderComments = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewOrderComments_OrderComments = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemReviewItems_OrderComments = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.RibbonBarOptions_Documents = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemDocuments_UploadOrder = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemUploadOrder_EmailLink = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemDocuments_UploadJob = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemUploadJob_EmailLink = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemDocuments_UploadJobComponent = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemUploadJobComponent_EmailLink = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemDocuments_UploadCampaign = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemUploadCampaign_EmailLink = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemDocuments_Upload = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemUpload_EmailLink = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemDocuments_Download = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDocuments_OpenURL = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Filter = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemFilter_All = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemFilter_SelectedLineItem = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_BillingApproval = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemBillingApproval_Approve = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemBillingApproval_Unapprove = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_VendorReps = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemVendorReps_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemVendorReps_Edit = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemVendorReps_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Vendor = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemVendor_Edit = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_GridOptionsVCCDetails = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemGridOptionsVCCDetails_ChooseColumns = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemGridOptionsVCCDetails_RestoreDefaults = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_SummaryResults = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainerSummaryResults_Far = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemSummaryResults_VCCIssuedAndUpdated = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemSummaryResults_TransactionsDeclined = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemSummaryResults_TransactionsOutOfBalance = New DevComponents.DotNetBar.ButtonItem()
            Me.ItemContainerSummaryResults_Splitter1 = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
            Me.ItemContainerSummaryResults_Center = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemSummaryResults_TransactionsInBalance = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemSummaryResults_NoTransactions = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemSummaryResults_Followup = New DevComponents.DotNetBar.ButtonItem()
            Me.ItemContainerSummaryResults_Splitter2 = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
            Me.RibbonBarOptions_Orders = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemOrders_GenerateOrders = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemOrders_CreateRevision = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemOrders_AdServing = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemAdServing_DoubleClick = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemOrders_UpdateCost = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemOrders_UpdateCostToActual = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemOrders_UpdateCostToVendorCollected = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemOrders_WriteUpDown = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemOrders_ProcessControl = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_VendorInvoices = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemVendorInvoices_CreateInvoices = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemVendorInvoices_OneInvoicePerOrderLine = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemVendorInvoices_OneInvoicePerVendor = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemVendorInvoices_ImportInvoices = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemVendorInvoices_ApproveInvoices = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_VendorPayments = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemVendorPayments_ManageVCC = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemVendorPayments_CreateVCC = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_MediaPlan = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemMediaPlan_Actualize = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.TabControlForm_ReviewItems, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_ReviewItems.SuspendLayout()
            Me.TabControlPanelDetailsTab_VCCDetails.SuspendLayout()
            CType(Me.PanelVCCDetails_Bottom, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelVCCDetails_Bottom.SuspendLayout()
            CType(Me.TabControlVCCDetails_Details, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlVCCDetails_Details.SuspendLayout()
            Me.TabControlPanelVCCDetailsTab_VCCDetails.SuspendLayout()
            Me.TabControlPanelOrderInfoTab_OrderInfo.SuspendLayout()
            CType(Me.PanelVCCDetails_Top, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelVCCDetails_Top.SuspendLayout()
            Me.TabControlPanelDetailsTab_OrderDetails.SuspendLayout()
            Me.TabControlPanelPurchaseOrderStatusHistoryTab_PurchaseOrderStatusHistory.SuspendLayout()
            Me.TabControlPanelOrderStatusHistoryTab_OrderStatusHistory.SuspendLayout()
            Me.TabControlPanelPODetails_PODetails.SuspendLayout()
            Me.TabControlPanelVendorRepsTab_VendorReps.SuspendLayout()
            Me.TabControlPanelBillingInvoicesTab_BillingInvoices.SuspendLayout()
            Me.TabControlPanelAPInvoicesPostedTab_APInvoicesPosted.SuspendLayout()
            Me.TabControlPanelPaymentDetailsTab_VendorCollectedDetails.SuspendLayout()
            Me.TabControlPanelLineCommentsTab_LineComments.SuspendLayout()
            Me.TabControlPanelDocumentsTab_Documents.SuspendLayout()
            Me.TabControlPanelOrderCommentsTab_OrderComments.SuspendLayout()
            Me.SuspendLayout()
            '
            '_DefaultLookAndFeel
            '
            Me._DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
            '
            'PanelForm_Form
            '
            Me.PanelForm_Form.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelForm_Form.Appearance.Options.UseBackColor = True
            Me.PanelForm_Form.Controls.Add(Me.TabControlForm_ReviewItems)
            Me.PanelForm_Form.LookAndFeel.SkinName = "Office 2013"
            Me.PanelForm_Form.LookAndFeel.UseDefaultLookAndFeel = False
            Me.PanelForm_Form.Size = New System.Drawing.Size(982, 555)
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(982, 154)
            Me.RibbonControlForm_MainRibbon.SystemText.MaximizeRibbonText = "&Maximize the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatAddItemText = "&Add to Quick Access Toolbar"
            Me.RibbonControlForm_MainRibbon.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>"
            Me.RibbonControlForm_MainRibbon.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar..."
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogAddButton = "&Add >>"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogCancelButton = "Cancel"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogCaption = "Customize Quick Access Toolbar"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogCategoriesLabel = "&Choose commands from:"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogOkButton = "OK"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogRemoveButton = "&Remove"
            Me.RibbonControlForm_MainRibbon.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar"
            Me.RibbonControlForm_MainRibbon.Controls.SetChildIndex(Me.RibbonPanelFile_FilePanel, 0)
            '
            'RibbonPanelFile_FilePanel
            '
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_GridOptionsVCCDetails)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_GridOptionsOrderDetails)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_MediaPlan)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_SummaryResults)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Filter)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Documents)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_BillingApproval)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_VendorReps)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Vendor)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_VendorPayments)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_VendorInvoices)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Orders)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(982, 94)
            '
            '
            '
            Me.RibbonPanelFile_FilePanel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonPanelFile_FilePanel.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonPanelFile_FilePanel.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFilePanel_System, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Actions, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Orders, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_VendorInvoices, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_VendorPayments, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Vendor, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_VendorReps, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_BillingApproval, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Documents, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Filter, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_SummaryResults, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_MediaPlan, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_GridOptionsOrderDetails, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_GridOptionsVCCDetails, 0)
            '
            'RibbonBarFilePanel_System
            '
            '
            '
            '
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.BorderColor = System.Drawing.Color.DarkGray
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.BorderColor2 = System.Drawing.Color.DarkGray
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.BorderRightWidth = 2
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_System.BackgroundStyle.BorderColor = System.Drawing.Color.DarkGray
            Me.RibbonBarFilePanel_System.BackgroundStyle.BorderColor2 = System.Drawing.Color.DarkGray
            Me.RibbonBarFilePanel_System.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.RibbonBarFilePanel_System.BackgroundStyle.BorderRightWidth = 2
            Me.RibbonBarFilePanel_System.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_System.Size = New System.Drawing.Size(52, 92)
            '
            '
            '
            Me.RibbonBarFilePanel_System.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_System.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemSystem_Close
            '
            Me.ButtonItemSystem_Close.Image = CType(resources.GetObject("ButtonItemSystem_Close.Image"), System.Drawing.Image)
            '
            'ProgressBarItemStatusBar_ProgressBar
            '
            '
            '
            '
            Me.ProgressBarItemStatusBar_ProgressBar.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'BarForm_StatusBar
            '
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 710)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(982, 18)
            '
            'RibbonBarOptions_GridOptionsOrderDetails
            '
            Me.RibbonBarOptions_GridOptionsOrderDetails.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_GridOptionsOrderDetails.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_GridOptionsOrderDetails.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_GridOptionsOrderDetails.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_GridOptionsOrderDetails.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_GridOptionsOrderDetails.DragDropSupport = True
            Me.RibbonBarOptions_GridOptionsOrderDetails.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemGridOptionsOrderDetails_ChooseColumns, Me.ButtonItemGridOptionsOrderDetails_RestoreDefaults})
            Me.RibbonBarOptions_GridOptionsOrderDetails.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_GridOptionsOrderDetails.Location = New System.Drawing.Point(1913, 0)
            Me.RibbonBarOptions_GridOptionsOrderDetails.Name = "RibbonBarOptions_GridOptionsOrderDetails"
            Me.RibbonBarOptions_GridOptionsOrderDetails.SecurityEnabled = True
            Me.RibbonBarOptions_GridOptionsOrderDetails.Size = New System.Drawing.Size(220, 92)
            Me.RibbonBarOptions_GridOptionsOrderDetails.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_GridOptionsOrderDetails.TabIndex = 13
            Me.RibbonBarOptions_GridOptionsOrderDetails.Text = "Grid Options"
            '
            '
            '
            Me.RibbonBarOptions_GridOptionsOrderDetails.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_GridOptionsOrderDetails.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_GridOptionsOrderDetails.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemGridOptionsOrderDetails_ChooseColumns
            '
            Me.ButtonItemGridOptionsOrderDetails_ChooseColumns.AutoCheckOnClick = True
            Me.ButtonItemGridOptionsOrderDetails_ChooseColumns.BeginGroup = True
            Me.ButtonItemGridOptionsOrderDetails_ChooseColumns.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemGridOptionsOrderDetails_ChooseColumns.Name = "ButtonItemGridOptionsOrderDetails_ChooseColumns"
            Me.ButtonItemGridOptionsOrderDetails_ChooseColumns.RibbonWordWrap = False
            Me.ButtonItemGridOptionsOrderDetails_ChooseColumns.SecurityEnabled = True
            Me.ButtonItemGridOptionsOrderDetails_ChooseColumns.SubItemsExpandWidth = 14
            Me.ButtonItemGridOptionsOrderDetails_ChooseColumns.Text = "Choose Columns"
            '
            'ButtonItemGridOptionsOrderDetails_RestoreDefaults
            '
            Me.ButtonItemGridOptionsOrderDetails_RestoreDefaults.BeginGroup = True
            Me.ButtonItemGridOptionsOrderDetails_RestoreDefaults.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemGridOptionsOrderDetails_RestoreDefaults.Name = "ButtonItemGridOptionsOrderDetails_RestoreDefaults"
            Me.ButtonItemGridOptionsOrderDetails_RestoreDefaults.RibbonWordWrap = False
            Me.ButtonItemGridOptionsOrderDetails_RestoreDefaults.SecurityEnabled = True
            Me.ButtonItemGridOptionsOrderDetails_RestoreDefaults.SubItemsExpandWidth = 14
            Me.ButtonItemGridOptionsOrderDetails_RestoreDefaults.Text = "Restore Defaults"
            '
            'RibbonBarOptions_Actions
            '
            Me.RibbonBarOptions_Actions.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Actions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Actions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Actions.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Actions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Actions.DragDropSupport = True
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Export, Me.ButtonItemActions_Save, Me.ButtonItemActions_Cancel, Me.ButtonItemActions_SendReminders, Me.ButtonItemActions_FollowUp, Me.ButtonItemActions_AutoFill, Me.ButtonItemActions_Refresh})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(55, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(141, 92)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 18
            Me.RibbonBarOptions_Actions.Text = "Actions"
            '
            '
            '
            Me.RibbonBarOptions_Actions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Actions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Actions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemActions_Export
            '
            Me.ButtonItemActions_Export.AutoExpandOnClick = True
            Me.ButtonItemActions_Export.BeginGroup = True
            Me.ButtonItemActions_Export.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Export.Name = "ButtonItemActions_Export"
            Me.ButtonItemActions_Export.RibbonWordWrap = False
            Me.ButtonItemActions_Export.SecurityEnabled = True
            Me.ButtonItemActions_Export.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_ExportGrid, Me.ButtonItemActions_ExportXML, Me.ButtonItemActions_ExportXMLAsNew})
            Me.ButtonItemActions_Export.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Export.Text = "Export"
            '
            'ButtonItemActions_ExportGrid
            '
            Me.ButtonItemActions_ExportGrid.Name = "ButtonItemActions_ExportGrid"
            Me.ButtonItemActions_ExportGrid.Text = "Grid"
            '
            'ButtonItemActions_ExportXML
            '
            Me.ButtonItemActions_ExportXML.Name = "ButtonItemActions_ExportXML"
            Me.ButtonItemActions_ExportXML.Text = "TV Schedule"
            '
            'ButtonItemActions_ExportXMLAsNew
            '
            Me.ButtonItemActions_ExportXMLAsNew.Name = "ButtonItemActions_ExportXMLAsNew"
            Me.ButtonItemActions_ExportXMLAsNew.Text = "TV Schedule as New"
            '
            'ButtonItemActions_Save
            '
            Me.ButtonItemActions_Save.BeginGroup = True
            Me.ButtonItemActions_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Save.Name = "ButtonItemActions_Save"
            Me.ButtonItemActions_Save.RibbonWordWrap = False
            Me.ButtonItemActions_Save.SecurityEnabled = True
            Me.ButtonItemActions_Save.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Save.Text = "Save"
            '
            'ButtonItemActions_Cancel
            '
            Me.ButtonItemActions_Cancel.BeginGroup = True
            Me.ButtonItemActions_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Cancel.Name = "ButtonItemActions_Cancel"
            Me.ButtonItemActions_Cancel.RibbonWordWrap = False
            Me.ButtonItemActions_Cancel.SecurityEnabled = True
            Me.ButtonItemActions_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Cancel.Text = "Cancel"
            '
            'ButtonItemActions_SendReminders
            '
            Me.ButtonItemActions_SendReminders.BeginGroup = True
            Me.ButtonItemActions_SendReminders.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_SendReminders.Name = "ButtonItemActions_SendReminders"
            Me.ButtonItemActions_SendReminders.RibbonWordWrap = False
            Me.ButtonItemActions_SendReminders.SecurityEnabled = True
            Me.ButtonItemActions_SendReminders.SubItemsExpandWidth = 14
            Me.ButtonItemActions_SendReminders.Text = "Send Reminders"
            '
            'ButtonItemActions_FollowUp
            '
            Me.ButtonItemActions_FollowUp.BeginGroup = True
            Me.ButtonItemActions_FollowUp.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_FollowUp.Name = "ButtonItemActions_FollowUp"
            Me.ButtonItemActions_FollowUp.RibbonWordWrap = False
            Me.ButtonItemActions_FollowUp.SecurityEnabled = True
            Me.ButtonItemActions_FollowUp.SubItemsExpandWidth = 14
            Me.ButtonItemActions_FollowUp.Text = "Follow Up"
            '
            'ButtonItemActions_AutoFill
            '
            Me.ButtonItemActions_AutoFill.BeginGroup = True
            Me.ButtonItemActions_AutoFill.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_AutoFill.Name = "ButtonItemActions_AutoFill"
            Me.ButtonItemActions_AutoFill.RibbonWordWrap = False
            Me.ButtonItemActions_AutoFill.SecurityEnabled = True
            Me.ButtonItemActions_AutoFill.SubItemsExpandWidth = 14
            Me.ButtonItemActions_AutoFill.Text = "Auto Fill"
            '
            'ButtonItemActions_Refresh
            '
            Me.ButtonItemActions_Refresh.BeginGroup = True
            Me.ButtonItemActions_Refresh.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Refresh.Name = "ButtonItemActions_Refresh"
            Me.ButtonItemActions_Refresh.RibbonWordWrap = False
            Me.ButtonItemActions_Refresh.SecurityEnabled = True
            Me.ButtonItemActions_Refresh.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Refresh.Text = "Refresh"
            '
            'TabControlForm_ReviewItems
            '
            Me.TabControlForm_ReviewItems.BackColor = System.Drawing.Color.White
            Me.TabControlForm_ReviewItems.CanReorderTabs = False
            Me.TabControlForm_ReviewItems.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlForm_ReviewItems.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlForm_ReviewItems.Controls.Add(Me.TabControlPanelDetailsTab_VCCDetails)
            Me.TabControlForm_ReviewItems.Controls.Add(Me.TabControlPanelDetailsTab_OrderDetails)
            Me.TabControlForm_ReviewItems.Controls.Add(Me.TabControlPanelPurchaseOrderStatusHistoryTab_PurchaseOrderStatusHistory)
            Me.TabControlForm_ReviewItems.Controls.Add(Me.TabControlPanelOrderStatusHistoryTab_OrderStatusHistory)
            Me.TabControlForm_ReviewItems.Controls.Add(Me.TabControlPanelPODetails_PODetails)
            Me.TabControlForm_ReviewItems.Controls.Add(Me.TabControlPanelVendorRepsTab_VendorReps)
            Me.TabControlForm_ReviewItems.Controls.Add(Me.TabControlPanelBillingInvoicesTab_BillingInvoices)
            Me.TabControlForm_ReviewItems.Controls.Add(Me.TabControlPanelAPInvoicesPostedTab_APInvoicesPosted)
            Me.TabControlForm_ReviewItems.Controls.Add(Me.TabControlPanelPaymentDetailsTab_VendorCollectedDetails)
            Me.TabControlForm_ReviewItems.Controls.Add(Me.TabControlPanelLineCommentsTab_LineComments)
            Me.TabControlForm_ReviewItems.Controls.Add(Me.TabControlPanelDocumentsTab_Documents)
            Me.TabControlForm_ReviewItems.Controls.Add(Me.TabControlPanelOrderCommentsTab_OrderComments)
            Me.TabControlForm_ReviewItems.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlForm_ReviewItems.ForeColor = System.Drawing.Color.Black
            Me.TabControlForm_ReviewItems.Location = New System.Drawing.Point(0, 0)
            Me.TabControlForm_ReviewItems.Name = "TabControlForm_ReviewItems"
            Me.TabControlForm_ReviewItems.SelectedTabFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_ReviewItems.SelectedTabIndex = 0
            Me.TabControlForm_ReviewItems.Size = New System.Drawing.Size(982, 555)
            Me.TabControlForm_ReviewItems.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_ReviewItems.TabIndex = 12
            Me.TabControlForm_ReviewItems.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_ReviewItems.Tabs.Add(Me.TabItemReviewItems_VCCDetails)
            Me.TabControlForm_ReviewItems.Tabs.Add(Me.TabItemReviewItems_OrderDetails)
            Me.TabControlForm_ReviewItems.Tabs.Add(Me.TabItemReviewItems_OrderStatus)
            Me.TabControlForm_ReviewItems.Tabs.Add(Me.TabItemReviewItems_OrderComments)
            Me.TabControlForm_ReviewItems.Tabs.Add(Me.TabItemReviewItems_LineComments)
            Me.TabControlForm_ReviewItems.Tabs.Add(Me.TabItemReviewItems_VendorCollectedDetails)
            Me.TabControlForm_ReviewItems.Tabs.Add(Me.TabItemReviewItems_APInvoiceDetail)
            Me.TabControlForm_ReviewItems.Tabs.Add(Me.TabItemReviewItems_BillingInvoices)
            Me.TabControlForm_ReviewItems.Tabs.Add(Me.TabItemReviewItems_VendorReps)
            Me.TabControlForm_ReviewItems.Tabs.Add(Me.TabItemReviewItems_Documents)
            Me.TabControlForm_ReviewItems.Tabs.Add(Me.TabItemReviewItems_PurchaseOrderDetails)
            Me.TabControlForm_ReviewItems.Tabs.Add(Me.TabItemReviewItems_PurchaseOrderStatus)
            '
            'TabControlPanelDetailsTab_VCCDetails
            '
            Me.TabControlPanelDetailsTab_VCCDetails.Controls.Add(Me.PanelVCCDetails_Bottom)
            Me.TabControlPanelDetailsTab_VCCDetails.Controls.Add(Me.ExpandableSplitterVCCDetails_TopBottom)
            Me.TabControlPanelDetailsTab_VCCDetails.Controls.Add(Me.PanelVCCDetails_Top)
            Me.TabControlPanelDetailsTab_VCCDetails.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelDetailsTab_VCCDetails.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelDetailsTab_VCCDetails.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelDetailsTab_VCCDetails.Name = "TabControlPanelDetailsTab_VCCDetails"
            Me.TabControlPanelDetailsTab_VCCDetails.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelDetailsTab_VCCDetails.Size = New System.Drawing.Size(982, 528)
            Me.TabControlPanelDetailsTab_VCCDetails.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelDetailsTab_VCCDetails.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDetailsTab_VCCDetails.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelDetailsTab_VCCDetails.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelDetailsTab_VCCDetails.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelDetailsTab_VCCDetails.Style.GradientAngle = 90
            Me.TabControlPanelDetailsTab_VCCDetails.TabIndex = 14
            Me.TabControlPanelDetailsTab_VCCDetails.TabItem = Me.TabItemReviewItems_VCCDetails
            '
            'PanelVCCDetails_Bottom
            '
            Me.PanelVCCDetails_Bottom.Appearance.BackColor = System.Drawing.Color.Transparent
            Me.PanelVCCDetails_Bottom.Appearance.Options.UseBackColor = True
            Me.PanelVCCDetails_Bottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelVCCDetails_Bottom.Controls.Add(Me.TabControlVCCDetails_Details)
            Me.PanelVCCDetails_Bottom.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelVCCDetails_Bottom.Location = New System.Drawing.Point(1, 171)
            Me.PanelVCCDetails_Bottom.Margin = New System.Windows.Forms.Padding(2)
            Me.PanelVCCDetails_Bottom.Name = "PanelVCCDetails_Bottom"
            Me.PanelVCCDetails_Bottom.Size = New System.Drawing.Size(980, 356)
            Me.PanelVCCDetails_Bottom.TabIndex = 22
            '
            'TabControlVCCDetails_Details
            '
            Me.TabControlVCCDetails_Details.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlVCCDetails_Details.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.TabControlVCCDetails_Details.CanReorderTabs = True
            Me.TabControlVCCDetails_Details.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlVCCDetails_Details.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlVCCDetails_Details.Controls.Add(Me.TabControlPanelVCCDetailsTab_VCCDetails)
            Me.TabControlVCCDetails_Details.Controls.Add(Me.TabControlPanelOrderInfoTab_OrderInfo)
            Me.TabControlVCCDetails_Details.ForeColor = System.Drawing.Color.Black
            Me.TabControlVCCDetails_Details.Location = New System.Drawing.Point(11, 6)
            Me.TabControlVCCDetails_Details.Name = "TabControlVCCDetails_Details"
            Me.TabControlVCCDetails_Details.SelectedTabFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlVCCDetails_Details.SelectedTabIndex = 0
            Me.TabControlVCCDetails_Details.Size = New System.Drawing.Size(958, 344)
            Me.TabControlVCCDetails_Details.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlVCCDetails_Details.TabIndex = 3
            Me.TabControlVCCDetails_Details.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlVCCDetails_Details.Tabs.Add(Me.TabItemVCCDetails_VCCDetailsTab)
            Me.TabControlVCCDetails_Details.Tabs.Add(Me.TabItemVCCDetails_NotesTab)
            '
            'TabControlPanelVCCDetailsTab_VCCDetails
            '
            Me.TabControlPanelVCCDetailsTab_VCCDetails.Controls.Add(Me.DataGridViewBottomVCCDetails_CardDetails)
            Me.TabControlPanelVCCDetailsTab_VCCDetails.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelVCCDetailsTab_VCCDetails.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelVCCDetailsTab_VCCDetails.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelVCCDetailsTab_VCCDetails.Name = "TabControlPanelVCCDetailsTab_VCCDetails"
            Me.TabControlPanelVCCDetailsTab_VCCDetails.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelVCCDetailsTab_VCCDetails.Size = New System.Drawing.Size(958, 317)
            Me.TabControlPanelVCCDetailsTab_VCCDetails.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelVCCDetailsTab_VCCDetails.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelVCCDetailsTab_VCCDetails.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelVCCDetailsTab_VCCDetails.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelVCCDetailsTab_VCCDetails.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelVCCDetailsTab_VCCDetails.Style.GradientAngle = 90
            Me.TabControlPanelVCCDetailsTab_VCCDetails.TabIndex = 1
            Me.TabControlPanelVCCDetailsTab_VCCDetails.TabItem = Me.TabItemVCCDetails_VCCDetailsTab
            '
            'DataGridViewBottomVCCDetails_CardDetails
            '
            Me.DataGridViewBottomVCCDetails_CardDetails.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewBottomVCCDetails_CardDetails.AllowDragAndDrop = False
            Me.DataGridViewBottomVCCDetails_CardDetails.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewBottomVCCDetails_CardDetails.AllowSelectGroupHeaderRow = True
            Me.DataGridViewBottomVCCDetails_CardDetails.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewBottomVCCDetails_CardDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewBottomVCCDetails_CardDetails.AutoFilterLookupColumns = False
            Me.DataGridViewBottomVCCDetails_CardDetails.AutoloadRepositoryDatasource = False
            Me.DataGridViewBottomVCCDetails_CardDetails.AutoUpdateViewCaption = True
            Me.DataGridViewBottomVCCDetails_CardDetails.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewBottomVCCDetails_CardDetails.DataSource = Nothing
            Me.DataGridViewBottomVCCDetails_CardDetails.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewBottomVCCDetails_CardDetails.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewBottomVCCDetails_CardDetails.ItemDescription = "VCC Detail(s)"
            Me.DataGridViewBottomVCCDetails_CardDetails.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewBottomVCCDetails_CardDetails.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewBottomVCCDetails_CardDetails.MultiSelect = True
            Me.DataGridViewBottomVCCDetails_CardDetails.Name = "DataGridViewBottomVCCDetails_CardDetails"
            Me.DataGridViewBottomVCCDetails_CardDetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewBottomVCCDetails_CardDetails.RunStandardValidation = True
            Me.DataGridViewBottomVCCDetails_CardDetails.ShowColumnMenuOnRightClick = False
            Me.DataGridViewBottomVCCDetails_CardDetails.ShowSelectDeselectAllButtons = False
            Me.DataGridViewBottomVCCDetails_CardDetails.Size = New System.Drawing.Size(950, 317)
            Me.DataGridViewBottomVCCDetails_CardDetails.TabIndex = 3
            Me.DataGridViewBottomVCCDetails_CardDetails.UseEmbeddedNavigator = False
            Me.DataGridViewBottomVCCDetails_CardDetails.ViewCaptionHeight = -1
            '
            'TabItemVCCDetails_VCCDetailsTab
            '
            Me.TabItemVCCDetails_VCCDetailsTab.AttachedControl = Me.TabControlPanelVCCDetailsTab_VCCDetails
            Me.TabItemVCCDetails_VCCDetailsTab.Name = "TabItemVCCDetails_VCCDetailsTab"
            Me.TabItemVCCDetails_VCCDetailsTab.Text = " Details"
            '
            'TabControlPanelOrderInfoTab_OrderInfo
            '
            Me.TabControlPanelOrderInfoTab_OrderInfo.Controls.Add(Me.DataGridViewBottomVCCDetails_CardNotes)
            Me.TabControlPanelOrderInfoTab_OrderInfo.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelOrderInfoTab_OrderInfo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelOrderInfoTab_OrderInfo.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelOrderInfoTab_OrderInfo.Name = "TabControlPanelOrderInfoTab_OrderInfo"
            Me.TabControlPanelOrderInfoTab_OrderInfo.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelOrderInfoTab_OrderInfo.Size = New System.Drawing.Size(958, 317)
            Me.TabControlPanelOrderInfoTab_OrderInfo.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelOrderInfoTab_OrderInfo.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelOrderInfoTab_OrderInfo.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelOrderInfoTab_OrderInfo.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelOrderInfoTab_OrderInfo.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelOrderInfoTab_OrderInfo.Style.GradientAngle = 90
            Me.TabControlPanelOrderInfoTab_OrderInfo.TabIndex = 2
            Me.TabControlPanelOrderInfoTab_OrderInfo.TabItem = Me.TabItemVCCDetails_NotesTab
            '
            'DataGridViewBottomVCCDetails_CardNotes
            '
            Me.DataGridViewBottomVCCDetails_CardNotes.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewBottomVCCDetails_CardNotes.AllowDragAndDrop = False
            Me.DataGridViewBottomVCCDetails_CardNotes.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewBottomVCCDetails_CardNotes.AllowSelectGroupHeaderRow = True
            Me.DataGridViewBottomVCCDetails_CardNotes.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewBottomVCCDetails_CardNotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewBottomVCCDetails_CardNotes.AutoFilterLookupColumns = False
            Me.DataGridViewBottomVCCDetails_CardNotes.AutoloadRepositoryDatasource = False
            Me.DataGridViewBottomVCCDetails_CardNotes.AutoUpdateViewCaption = True
            Me.DataGridViewBottomVCCDetails_CardNotes.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewBottomVCCDetails_CardNotes.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewBottomVCCDetails_CardNotes.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewBottomVCCDetails_CardNotes.ItemDescription = "VCC Note(s)"
            Me.DataGridViewBottomVCCDetails_CardNotes.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewBottomVCCDetails_CardNotes.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewBottomVCCDetails_CardNotes.MultiSelect = False
            Me.DataGridViewBottomVCCDetails_CardNotes.Name = "DataGridViewBottomVCCDetails_CardNotes"
            Me.DataGridViewBottomVCCDetails_CardNotes.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewBottomVCCDetails_CardNotes.RunStandardValidation = True
            Me.DataGridViewBottomVCCDetails_CardNotes.ShowColumnMenuOnRightClick = False
            Me.DataGridViewBottomVCCDetails_CardNotes.ShowSelectDeselectAllButtons = False
            Me.DataGridViewBottomVCCDetails_CardNotes.Size = New System.Drawing.Size(950, 317)
            Me.DataGridViewBottomVCCDetails_CardNotes.TabIndex = 4
            Me.DataGridViewBottomVCCDetails_CardNotes.UseEmbeddedNavigator = False
            Me.DataGridViewBottomVCCDetails_CardNotes.ViewCaptionHeight = -1
            '
            'TabItemVCCDetails_NotesTab
            '
            Me.TabItemVCCDetails_NotesTab.AttachedControl = Me.TabControlPanelOrderInfoTab_OrderInfo
            Me.TabItemVCCDetails_NotesTab.Name = "TabItemVCCDetails_NotesTab"
            Me.TabItemVCCDetails_NotesTab.Text = "Notes"
            '
            'ExpandableSplitterVCCDetails_TopBottom
            '
            Me.ExpandableSplitterVCCDetails_TopBottom.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterVCCDetails_TopBottom.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterVCCDetails_TopBottom.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterVCCDetails_TopBottom.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterVCCDetails_TopBottom.Cursor = System.Windows.Forms.Cursors.HSplit
            Me.ExpandableSplitterVCCDetails_TopBottom.Dock = System.Windows.Forms.DockStyle.Top
            Me.ExpandableSplitterVCCDetails_TopBottom.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterVCCDetails_TopBottom.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterVCCDetails_TopBottom.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterVCCDetails_TopBottom.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterVCCDetails_TopBottom.ForeColor = System.Drawing.Color.Black
            Me.ExpandableSplitterVCCDetails_TopBottom.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterVCCDetails_TopBottom.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterVCCDetails_TopBottom.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterVCCDetails_TopBottom.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterVCCDetails_TopBottom.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterVCCDetails_TopBottom.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterVCCDetails_TopBottom.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterVCCDetails_TopBottom.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterVCCDetails_TopBottom.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterVCCDetails_TopBottom.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterVCCDetails_TopBottom.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterVCCDetails_TopBottom.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterVCCDetails_TopBottom.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterVCCDetails_TopBottom.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterVCCDetails_TopBottom.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterVCCDetails_TopBottom.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterVCCDetails_TopBottom.Location = New System.Drawing.Point(1, 165)
            Me.ExpandableSplitterVCCDetails_TopBottom.Name = "ExpandableSplitterVCCDetails_TopBottom"
            Me.ExpandableSplitterVCCDetails_TopBottom.Size = New System.Drawing.Size(980, 6)
            Me.ExpandableSplitterVCCDetails_TopBottom.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterVCCDetails_TopBottom.TabIndex = 21
            Me.ExpandableSplitterVCCDetails_TopBottom.TabStop = False
            '
            'PanelVCCDetails_Top
            '
            Me.PanelVCCDetails_Top.Appearance.BackColor = System.Drawing.Color.Transparent
            Me.PanelVCCDetails_Top.Appearance.Options.UseBackColor = True
            Me.PanelVCCDetails_Top.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelVCCDetails_Top.Controls.Add(Me.DataGridViewTopVCCDetails_VCCOrders)
            Me.PanelVCCDetails_Top.Dock = System.Windows.Forms.DockStyle.Top
            Me.PanelVCCDetails_Top.Location = New System.Drawing.Point(1, 1)
            Me.PanelVCCDetails_Top.Margin = New System.Windows.Forms.Padding(2)
            Me.PanelVCCDetails_Top.Name = "PanelVCCDetails_Top"
            Me.PanelVCCDetails_Top.Size = New System.Drawing.Size(980, 164)
            Me.PanelVCCDetails_Top.TabIndex = 20
            '
            'DataGridViewTopVCCDetails_VCCOrders
            '
            Me.DataGridViewTopVCCDetails_VCCOrders.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewTopVCCDetails_VCCOrders.AllowDragAndDrop = False
            Me.DataGridViewTopVCCDetails_VCCOrders.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewTopVCCDetails_VCCOrders.AllowSelectGroupHeaderRow = True
            Me.DataGridViewTopVCCDetails_VCCOrders.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewTopVCCDetails_VCCOrders.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewTopVCCDetails_VCCOrders.AutoFilterLookupColumns = False
            Me.DataGridViewTopVCCDetails_VCCOrders.AutoloadRepositoryDatasource = True
            Me.DataGridViewTopVCCDetails_VCCOrders.AutoUpdateViewCaption = True
            Me.DataGridViewTopVCCDetails_VCCOrders.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewTopVCCDetails_VCCOrders.DataSource = Nothing
            Me.DataGridViewTopVCCDetails_VCCOrders.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewTopVCCDetails_VCCOrders.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewTopVCCDetails_VCCOrders.ItemDescription = "VCC(s)"
            Me.DataGridViewTopVCCDetails_VCCOrders.Location = New System.Drawing.Point(11, 6)
            Me.DataGridViewTopVCCDetails_VCCOrders.MultiSelect = True
            Me.DataGridViewTopVCCDetails_VCCOrders.Name = "DataGridViewTopVCCDetails_VCCOrders"
            Me.DataGridViewTopVCCDetails_VCCOrders.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewTopVCCDetails_VCCOrders.RunStandardValidation = True
            Me.DataGridViewTopVCCDetails_VCCOrders.ShowColumnMenuOnRightClick = False
            Me.DataGridViewTopVCCDetails_VCCOrders.ShowSelectDeselectAllButtons = False
            Me.DataGridViewTopVCCDetails_VCCOrders.Size = New System.Drawing.Size(958, 152)
            Me.DataGridViewTopVCCDetails_VCCOrders.TabIndex = 5
            Me.DataGridViewTopVCCDetails_VCCOrders.UseEmbeddedNavigator = False
            Me.DataGridViewTopVCCDetails_VCCOrders.ViewCaptionHeight = -1
            '
            'TabItemReviewItems_VCCDetails
            '
            Me.TabItemReviewItems_VCCDetails.AttachedControl = Me.TabControlPanelDetailsTab_VCCDetails
            Me.TabItemReviewItems_VCCDetails.Name = "TabItemReviewItems_VCCDetails"
            Me.TabItemReviewItems_VCCDetails.Text = "VCC Details"
            '
            'TabControlPanelDetailsTab_OrderDetails
            '
            Me.TabControlPanelDetailsTab_OrderDetails.Controls.Add(Me.DataGridViewOrderDetails_OrderDetails)
            Me.TabControlPanelDetailsTab_OrderDetails.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelDetailsTab_OrderDetails.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelDetailsTab_OrderDetails.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelDetailsTab_OrderDetails.Name = "TabControlPanelDetailsTab_OrderDetails"
            Me.TabControlPanelDetailsTab_OrderDetails.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelDetailsTab_OrderDetails.Size = New System.Drawing.Size(982, 528)
            Me.TabControlPanelDetailsTab_OrderDetails.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelDetailsTab_OrderDetails.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDetailsTab_OrderDetails.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelDetailsTab_OrderDetails.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelDetailsTab_OrderDetails.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelDetailsTab_OrderDetails.Style.GradientAngle = 90
            Me.TabControlPanelDetailsTab_OrderDetails.TabIndex = 1
            Me.TabControlPanelDetailsTab_OrderDetails.TabItem = Me.TabItemReviewItems_OrderDetails
            '
            'DataGridViewOrderDetails_OrderDetails
            '
            Me.DataGridViewOrderDetails_OrderDetails.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewOrderDetails_OrderDetails.AllowDragAndDrop = False
            Me.DataGridViewOrderDetails_OrderDetails.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewOrderDetails_OrderDetails.AllowSelectGroupHeaderRow = True
            Me.DataGridViewOrderDetails_OrderDetails.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewOrderDetails_OrderDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewOrderDetails_OrderDetails.AutoFilterLookupColumns = True
            Me.DataGridViewOrderDetails_OrderDetails.AutoloadRepositoryDatasource = True
            Me.DataGridViewOrderDetails_OrderDetails.AutoUpdateViewCaption = True
            Me.DataGridViewOrderDetails_OrderDetails.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewOrderDetails_OrderDetails.DataSource = Nothing
            Me.DataGridViewOrderDetails_OrderDetails.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewOrderDetails_OrderDetails.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewOrderDetails_OrderDetails.ItemDescription = ""
            Me.DataGridViewOrderDetails_OrderDetails.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewOrderDetails_OrderDetails.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewOrderDetails_OrderDetails.MultiSelect = True
            Me.DataGridViewOrderDetails_OrderDetails.Name = "DataGridViewOrderDetails_OrderDetails"
            Me.DataGridViewOrderDetails_OrderDetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewOrderDetails_OrderDetails.RunStandardValidation = True
            Me.DataGridViewOrderDetails_OrderDetails.ShowColumnMenuOnRightClick = False
            Me.DataGridViewOrderDetails_OrderDetails.ShowSelectDeselectAllButtons = False
            Me.DataGridViewOrderDetails_OrderDetails.Size = New System.Drawing.Size(974, 520)
            Me.DataGridViewOrderDetails_OrderDetails.TabIndex = 2
            Me.DataGridViewOrderDetails_OrderDetails.UseEmbeddedNavigator = False
            Me.DataGridViewOrderDetails_OrderDetails.ViewCaptionHeight = -1
            '
            'TabItemReviewItems_OrderDetails
            '
            Me.TabItemReviewItems_OrderDetails.AttachedControl = Me.TabControlPanelDetailsTab_OrderDetails
            Me.TabItemReviewItems_OrderDetails.Name = "TabItemReviewItems_OrderDetails"
            Me.TabItemReviewItems_OrderDetails.Text = "Order Details"
            '
            'TabControlPanelPurchaseOrderStatusHistoryTab_PurchaseOrderStatusHistory
            '
            Me.TabControlPanelPurchaseOrderStatusHistoryTab_PurchaseOrderStatusHistory.Controls.Add(Me.DataGridViewPOStatus_POStatus)
            Me.TabControlPanelPurchaseOrderStatusHistoryTab_PurchaseOrderStatusHistory.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelPurchaseOrderStatusHistoryTab_PurchaseOrderStatusHistory.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelPurchaseOrderStatusHistoryTab_PurchaseOrderStatusHistory.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelPurchaseOrderStatusHistoryTab_PurchaseOrderStatusHistory.Name = "TabControlPanelPurchaseOrderStatusHistoryTab_PurchaseOrderStatusHistory"
            Me.TabControlPanelPurchaseOrderStatusHistoryTab_PurchaseOrderStatusHistory.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelPurchaseOrderStatusHistoryTab_PurchaseOrderStatusHistory.Size = New System.Drawing.Size(982, 528)
            Me.TabControlPanelPurchaseOrderStatusHistoryTab_PurchaseOrderStatusHistory.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelPurchaseOrderStatusHistoryTab_PurchaseOrderStatusHistory.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelPurchaseOrderStatusHistoryTab_PurchaseOrderStatusHistory.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelPurchaseOrderStatusHistoryTab_PurchaseOrderStatusHistory.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelPurchaseOrderStatusHistoryTab_PurchaseOrderStatusHistory.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelPurchaseOrderStatusHistoryTab_PurchaseOrderStatusHistory.Style.GradientAngle = 90
            Me.TabControlPanelPurchaseOrderStatusHistoryTab_PurchaseOrderStatusHistory.TabIndex = 73
            Me.TabControlPanelPurchaseOrderStatusHistoryTab_PurchaseOrderStatusHistory.TabItem = Me.TabItemReviewItems_PurchaseOrderStatus
            '
            'DataGridViewPOStatus_POStatus
            '
            Me.DataGridViewPOStatus_POStatus.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewPOStatus_POStatus.AllowDragAndDrop = False
            Me.DataGridViewPOStatus_POStatus.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewPOStatus_POStatus.AllowSelectGroupHeaderRow = True
            Me.DataGridViewPOStatus_POStatus.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewPOStatus_POStatus.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewPOStatus_POStatus.AutoFilterLookupColumns = False
            Me.DataGridViewPOStatus_POStatus.AutoloadRepositoryDatasource = False
            Me.DataGridViewPOStatus_POStatus.AutoUpdateViewCaption = True
            Me.DataGridViewPOStatus_POStatus.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewPOStatus_POStatus.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewPOStatus_POStatus.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewPOStatus_POStatus.ItemDescription = ""
            Me.DataGridViewPOStatus_POStatus.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewPOStatus_POStatus.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewPOStatus_POStatus.MultiSelect = True
            Me.DataGridViewPOStatus_POStatus.Name = "DataGridViewPOStatus_POStatus"
            Me.DataGridViewPOStatus_POStatus.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewPOStatus_POStatus.RunStandardValidation = True
            Me.DataGridViewPOStatus_POStatus.ShowColumnMenuOnRightClick = False
            Me.DataGridViewPOStatus_POStatus.ShowSelectDeselectAllButtons = False
            Me.DataGridViewPOStatus_POStatus.Size = New System.Drawing.Size(974, 520)
            Me.DataGridViewPOStatus_POStatus.TabIndex = 4
            Me.DataGridViewPOStatus_POStatus.UseEmbeddedNavigator = False
            Me.DataGridViewPOStatus_POStatus.ViewCaptionHeight = -1
            '
            'TabItemReviewItems_PurchaseOrderStatus
            '
            Me.TabItemReviewItems_PurchaseOrderStatus.AttachedControl = Me.TabControlPanelPurchaseOrderStatusHistoryTab_PurchaseOrderStatusHistory
            Me.TabItemReviewItems_PurchaseOrderStatus.Name = "TabItemReviewItems_PurchaseOrderStatus"
            Me.TabItemReviewItems_PurchaseOrderStatus.Text = "PO Status"
            '
            'TabControlPanelOrderStatusHistoryTab_OrderStatusHistory
            '
            Me.TabControlPanelOrderStatusHistoryTab_OrderStatusHistory.Controls.Add(Me.DataGridViewOrderStatus_OrderStatus)
            Me.TabControlPanelOrderStatusHistoryTab_OrderStatusHistory.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelOrderStatusHistoryTab_OrderStatusHistory.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelOrderStatusHistoryTab_OrderStatusHistory.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelOrderStatusHistoryTab_OrderStatusHistory.Name = "TabControlPanelOrderStatusHistoryTab_OrderStatusHistory"
            Me.TabControlPanelOrderStatusHistoryTab_OrderStatusHistory.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelOrderStatusHistoryTab_OrderStatusHistory.Size = New System.Drawing.Size(982, 528)
            Me.TabControlPanelOrderStatusHistoryTab_OrderStatusHistory.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelOrderStatusHistoryTab_OrderStatusHistory.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelOrderStatusHistoryTab_OrderStatusHistory.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelOrderStatusHistoryTab_OrderStatusHistory.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelOrderStatusHistoryTab_OrderStatusHistory.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelOrderStatusHistoryTab_OrderStatusHistory.Style.GradientAngle = 90
            Me.TabControlPanelOrderStatusHistoryTab_OrderStatusHistory.TabIndex = 6
            Me.TabControlPanelOrderStatusHistoryTab_OrderStatusHistory.TabItem = Me.TabItemReviewItems_OrderStatus
            '
            'DataGridViewOrderStatus_OrderStatus
            '
            Me.DataGridViewOrderStatus_OrderStatus.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewOrderStatus_OrderStatus.AllowDragAndDrop = False
            Me.DataGridViewOrderStatus_OrderStatus.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewOrderStatus_OrderStatus.AllowSelectGroupHeaderRow = True
            Me.DataGridViewOrderStatus_OrderStatus.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewOrderStatus_OrderStatus.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewOrderStatus_OrderStatus.AutoFilterLookupColumns = False
            Me.DataGridViewOrderStatus_OrderStatus.AutoloadRepositoryDatasource = False
            Me.DataGridViewOrderStatus_OrderStatus.AutoUpdateViewCaption = True
            Me.DataGridViewOrderStatus_OrderStatus.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewOrderStatus_OrderStatus.DataSource = Nothing
            Me.DataGridViewOrderStatus_OrderStatus.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewOrderStatus_OrderStatus.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewOrderStatus_OrderStatus.ItemDescription = ""
            Me.DataGridViewOrderStatus_OrderStatus.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewOrderStatus_OrderStatus.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewOrderStatus_OrderStatus.MultiSelect = True
            Me.DataGridViewOrderStatus_OrderStatus.Name = "DataGridViewOrderStatus_OrderStatus"
            Me.DataGridViewOrderStatus_OrderStatus.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewOrderStatus_OrderStatus.RunStandardValidation = True
            Me.DataGridViewOrderStatus_OrderStatus.ShowColumnMenuOnRightClick = False
            Me.DataGridViewOrderStatus_OrderStatus.ShowSelectDeselectAllButtons = False
            Me.DataGridViewOrderStatus_OrderStatus.Size = New System.Drawing.Size(974, 520)
            Me.DataGridViewOrderStatus_OrderStatus.TabIndex = 3
            Me.DataGridViewOrderStatus_OrderStatus.UseEmbeddedNavigator = False
            Me.DataGridViewOrderStatus_OrderStatus.ViewCaptionHeight = -1
            '
            'TabItemReviewItems_OrderStatus
            '
            Me.TabItemReviewItems_OrderStatus.AttachedControl = Me.TabControlPanelOrderStatusHistoryTab_OrderStatusHistory
            Me.TabItemReviewItems_OrderStatus.Name = "TabItemReviewItems_OrderStatus"
            Me.TabItemReviewItems_OrderStatus.Text = "Order Status"
            '
            'TabControlPanelPODetails_PODetails
            '
            Me.TabControlPanelPODetails_PODetails.Controls.Add(Me.DataGridViewPODetails_PODetails)
            Me.TabControlPanelPODetails_PODetails.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelPODetails_PODetails.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelPODetails_PODetails.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelPODetails_PODetails.Name = "TabControlPanelPODetails_PODetails"
            Me.TabControlPanelPODetails_PODetails.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelPODetails_PODetails.Size = New System.Drawing.Size(982, 528)
            Me.TabControlPanelPODetails_PODetails.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelPODetails_PODetails.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelPODetails_PODetails.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelPODetails_PODetails.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelPODetails_PODetails.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelPODetails_PODetails.Style.GradientAngle = 90
            Me.TabControlPanelPODetails_PODetails.TabIndex = 42
            Me.TabControlPanelPODetails_PODetails.TabItem = Me.TabItemReviewItems_PurchaseOrderDetails
            '
            'DataGridViewPODetails_PODetails
            '
            Me.DataGridViewPODetails_PODetails.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewPODetails_PODetails.AllowDragAndDrop = False
            Me.DataGridViewPODetails_PODetails.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewPODetails_PODetails.AllowSelectGroupHeaderRow = True
            Me.DataGridViewPODetails_PODetails.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewPODetails_PODetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewPODetails_PODetails.AutoFilterLookupColumns = False
            Me.DataGridViewPODetails_PODetails.AutoloadRepositoryDatasource = False
            Me.DataGridViewPODetails_PODetails.AutoUpdateViewCaption = True
            Me.DataGridViewPODetails_PODetails.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewPODetails_PODetails.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewPODetails_PODetails.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewPODetails_PODetails.ItemDescription = ""
            Me.DataGridViewPODetails_PODetails.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewPODetails_PODetails.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewPODetails_PODetails.MultiSelect = True
            Me.DataGridViewPODetails_PODetails.Name = "DataGridViewPODetails_PODetails"
            Me.DataGridViewPODetails_PODetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewPODetails_PODetails.RunStandardValidation = True
            Me.DataGridViewPODetails_PODetails.ShowColumnMenuOnRightClick = False
            Me.DataGridViewPODetails_PODetails.ShowSelectDeselectAllButtons = False
            Me.DataGridViewPODetails_PODetails.Size = New System.Drawing.Size(974, 520)
            Me.DataGridViewPODetails_PODetails.TabIndex = 7
            Me.DataGridViewPODetails_PODetails.UseEmbeddedNavigator = False
            Me.DataGridViewPODetails_PODetails.ViewCaptionHeight = -1
            '
            'TabItemReviewItems_PurchaseOrderDetails
            '
            Me.TabItemReviewItems_PurchaseOrderDetails.AttachedControl = Me.TabControlPanelPODetails_PODetails
            Me.TabItemReviewItems_PurchaseOrderDetails.Name = "TabItemReviewItems_PurchaseOrderDetails"
            Me.TabItemReviewItems_PurchaseOrderDetails.Text = "PO Details"
            '
            'TabControlPanelVendorRepsTab_VendorReps
            '
            Me.TabControlPanelVendorRepsTab_VendorReps.Controls.Add(Me.DataGridViewVendorReps_VendorReps)
            Me.TabControlPanelVendorRepsTab_VendorReps.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelVendorRepsTab_VendorReps.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelVendorRepsTab_VendorReps.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelVendorRepsTab_VendorReps.Name = "TabControlPanelVendorRepsTab_VendorReps"
            Me.TabControlPanelVendorRepsTab_VendorReps.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelVendorRepsTab_VendorReps.Size = New System.Drawing.Size(982, 528)
            Me.TabControlPanelVendorRepsTab_VendorReps.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelVendorRepsTab_VendorReps.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelVendorRepsTab_VendorReps.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelVendorRepsTab_VendorReps.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelVendorRepsTab_VendorReps.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelVendorRepsTab_VendorReps.Style.GradientAngle = 90
            Me.TabControlPanelVendorRepsTab_VendorReps.TabIndex = 12
            Me.TabControlPanelVendorRepsTab_VendorReps.TabItem = Me.TabItemReviewItems_VendorReps
            '
            'DataGridViewVendorReps_VendorReps
            '
            Me.DataGridViewVendorReps_VendorReps.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewVendorReps_VendorReps.AllowDragAndDrop = False
            Me.DataGridViewVendorReps_VendorReps.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewVendorReps_VendorReps.AllowSelectGroupHeaderRow = True
            Me.DataGridViewVendorReps_VendorReps.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewVendorReps_VendorReps.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewVendorReps_VendorReps.AutoFilterLookupColumns = False
            Me.DataGridViewVendorReps_VendorReps.AutoloadRepositoryDatasource = False
            Me.DataGridViewVendorReps_VendorReps.AutoUpdateViewCaption = True
            Me.DataGridViewVendorReps_VendorReps.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewVendorReps_VendorReps.DataSource = Nothing
            Me.DataGridViewVendorReps_VendorReps.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewVendorReps_VendorReps.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewVendorReps_VendorReps.ItemDescription = ""
            Me.DataGridViewVendorReps_VendorReps.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewVendorReps_VendorReps.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewVendorReps_VendorReps.MultiSelect = False
            Me.DataGridViewVendorReps_VendorReps.Name = "DataGridViewVendorReps_VendorReps"
            Me.DataGridViewVendorReps_VendorReps.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewVendorReps_VendorReps.RunStandardValidation = True
            Me.DataGridViewVendorReps_VendorReps.ShowColumnMenuOnRightClick = False
            Me.DataGridViewVendorReps_VendorReps.ShowSelectDeselectAllButtons = False
            Me.DataGridViewVendorReps_VendorReps.Size = New System.Drawing.Size(974, 520)
            Me.DataGridViewVendorReps_VendorReps.TabIndex = 6
            Me.DataGridViewVendorReps_VendorReps.UseEmbeddedNavigator = False
            Me.DataGridViewVendorReps_VendorReps.ViewCaptionHeight = -1
            '
            'TabItemReviewItems_VendorReps
            '
            Me.TabItemReviewItems_VendorReps.AttachedControl = Me.TabControlPanelVendorRepsTab_VendorReps
            Me.TabItemReviewItems_VendorReps.Name = "TabItemReviewItems_VendorReps"
            Me.TabItemReviewItems_VendorReps.Text = "Vendor Reps"
            '
            'TabControlPanelBillingInvoicesTab_BillingInvoices
            '
            Me.TabControlPanelBillingInvoicesTab_BillingInvoices.Controls.Add(Me.MediaBillingHistoryControlBillingInvoices_BillingInvoices)
            Me.TabControlPanelBillingInvoicesTab_BillingInvoices.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelBillingInvoicesTab_BillingInvoices.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelBillingInvoicesTab_BillingInvoices.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelBillingInvoicesTab_BillingInvoices.Name = "TabControlPanelBillingInvoicesTab_BillingInvoices"
            Me.TabControlPanelBillingInvoicesTab_BillingInvoices.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelBillingInvoicesTab_BillingInvoices.Size = New System.Drawing.Size(982, 528)
            Me.TabControlPanelBillingInvoicesTab_BillingInvoices.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelBillingInvoicesTab_BillingInvoices.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelBillingInvoicesTab_BillingInvoices.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelBillingInvoicesTab_BillingInvoices.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelBillingInvoicesTab_BillingInvoices.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelBillingInvoicesTab_BillingInvoices.Style.GradientAngle = 90
            Me.TabControlPanelBillingInvoicesTab_BillingInvoices.TabIndex = 13
            Me.TabControlPanelBillingInvoicesTab_BillingInvoices.TabItem = Me.TabItemReviewItems_BillingInvoices
            '
            'MediaBillingHistoryControlBillingInvoices_BillingInvoices
            '
            Me.MediaBillingHistoryControlBillingInvoices_BillingInvoices.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.MediaBillingHistoryControlBillingInvoices_BillingInvoices.Location = New System.Drawing.Point(4, 4)
            Me.MediaBillingHistoryControlBillingInvoices_BillingInvoices.Name = "MediaBillingHistoryControlBillingInvoices_BillingInvoices"
            Me.MediaBillingHistoryControlBillingInvoices_BillingInvoices.Size = New System.Drawing.Size(974, 520)
            Me.MediaBillingHistoryControlBillingInvoices_BillingInvoices.TabIndex = 0
            '
            'TabItemReviewItems_BillingInvoices
            '
            Me.TabItemReviewItems_BillingInvoices.AttachedControl = Me.TabControlPanelBillingInvoicesTab_BillingInvoices
            Me.TabItemReviewItems_BillingInvoices.Name = "TabItemReviewItems_BillingInvoices"
            Me.TabItemReviewItems_BillingInvoices.Text = "Billing/Invoices"
            '
            'TabControlPanelAPInvoicesPostedTab_APInvoicesPosted
            '
            Me.TabControlPanelAPInvoicesPostedTab_APInvoicesPosted.Controls.Add(Me.ApInvoiceControlAPInvoiceDetail_APInvoiceDetail)
            Me.TabControlPanelAPInvoicesPostedTab_APInvoicesPosted.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelAPInvoicesPostedTab_APInvoicesPosted.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelAPInvoicesPostedTab_APInvoicesPosted.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelAPInvoicesPostedTab_APInvoicesPosted.Name = "TabControlPanelAPInvoicesPostedTab_APInvoicesPosted"
            Me.TabControlPanelAPInvoicesPostedTab_APInvoicesPosted.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelAPInvoicesPostedTab_APInvoicesPosted.Size = New System.Drawing.Size(982, 528)
            Me.TabControlPanelAPInvoicesPostedTab_APInvoicesPosted.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelAPInvoicesPostedTab_APInvoicesPosted.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelAPInvoicesPostedTab_APInvoicesPosted.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelAPInvoicesPostedTab_APInvoicesPosted.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelAPInvoicesPostedTab_APInvoicesPosted.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelAPInvoicesPostedTab_APInvoicesPosted.Style.GradientAngle = 90
            Me.TabControlPanelAPInvoicesPostedTab_APInvoicesPosted.TabIndex = 9
            Me.TabControlPanelAPInvoicesPostedTab_APInvoicesPosted.TabItem = Me.TabItemReviewItems_APInvoiceDetail
            '
            'ApInvoiceControlAPInvoiceDetail_APInvoiceDetail
            '
            Me.ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.Location = New System.Drawing.Point(4, 4)
            Me.ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.Name = "ApInvoiceControlAPInvoiceDetail_APInvoiceDetail"
            Me.ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.Size = New System.Drawing.Size(974, 520)
            Me.ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.TabIndex = 0
            '
            'TabItemReviewItems_APInvoiceDetail
            '
            Me.TabItemReviewItems_APInvoiceDetail.AttachedControl = Me.TabControlPanelAPInvoicesPostedTab_APInvoicesPosted
            Me.TabItemReviewItems_APInvoiceDetail.Name = "TabItemReviewItems_APInvoiceDetail"
            Me.TabItemReviewItems_APInvoiceDetail.Text = "AP Invoice Detail"
            '
            'TabControlPanelPaymentDetailsTab_VendorCollectedDetails
            '
            Me.TabControlPanelPaymentDetailsTab_VendorCollectedDetails.Controls.Add(Me.DataGridViewVendorCollectedDetails_VendorCollectedDetails)
            Me.TabControlPanelPaymentDetailsTab_VendorCollectedDetails.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelPaymentDetailsTab_VendorCollectedDetails.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelPaymentDetailsTab_VendorCollectedDetails.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelPaymentDetailsTab_VendorCollectedDetails.Name = "TabControlPanelPaymentDetailsTab_VendorCollectedDetails"
            Me.TabControlPanelPaymentDetailsTab_VendorCollectedDetails.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelPaymentDetailsTab_VendorCollectedDetails.Size = New System.Drawing.Size(982, 528)
            Me.TabControlPanelPaymentDetailsTab_VendorCollectedDetails.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelPaymentDetailsTab_VendorCollectedDetails.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelPaymentDetailsTab_VendorCollectedDetails.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelPaymentDetailsTab_VendorCollectedDetails.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelPaymentDetailsTab_VendorCollectedDetails.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelPaymentDetailsTab_VendorCollectedDetails.Style.GradientAngle = 90
            Me.TabControlPanelPaymentDetailsTab_VendorCollectedDetails.TabIndex = 10
            Me.TabControlPanelPaymentDetailsTab_VendorCollectedDetails.TabItem = Me.TabItemReviewItems_VendorCollectedDetails
            '
            'DataGridViewVendorCollectedDetails_VendorCollectedDetails
            '
            Me.DataGridViewVendorCollectedDetails_VendorCollectedDetails.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewVendorCollectedDetails_VendorCollectedDetails.AllowDragAndDrop = False
            Me.DataGridViewVendorCollectedDetails_VendorCollectedDetails.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewVendorCollectedDetails_VendorCollectedDetails.AllowSelectGroupHeaderRow = True
            Me.DataGridViewVendorCollectedDetails_VendorCollectedDetails.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewVendorCollectedDetails_VendorCollectedDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewVendorCollectedDetails_VendorCollectedDetails.AutoFilterLookupColumns = False
            Me.DataGridViewVendorCollectedDetails_VendorCollectedDetails.AutoloadRepositoryDatasource = False
            Me.DataGridViewVendorCollectedDetails_VendorCollectedDetails.AutoUpdateViewCaption = True
            Me.DataGridViewVendorCollectedDetails_VendorCollectedDetails.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewVendorCollectedDetails_VendorCollectedDetails.DataSource = Nothing
            Me.DataGridViewVendorCollectedDetails_VendorCollectedDetails.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewVendorCollectedDetails_VendorCollectedDetails.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewVendorCollectedDetails_VendorCollectedDetails.ItemDescription = ""
            Me.DataGridViewVendorCollectedDetails_VendorCollectedDetails.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewVendorCollectedDetails_VendorCollectedDetails.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewVendorCollectedDetails_VendorCollectedDetails.MultiSelect = True
            Me.DataGridViewVendorCollectedDetails_VendorCollectedDetails.Name = "DataGridViewVendorCollectedDetails_VendorCollectedDetails"
            Me.DataGridViewVendorCollectedDetails_VendorCollectedDetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewVendorCollectedDetails_VendorCollectedDetails.RunStandardValidation = True
            Me.DataGridViewVendorCollectedDetails_VendorCollectedDetails.ShowColumnMenuOnRightClick = False
            Me.DataGridViewVendorCollectedDetails_VendorCollectedDetails.ShowSelectDeselectAllButtons = False
            Me.DataGridViewVendorCollectedDetails_VendorCollectedDetails.Size = New System.Drawing.Size(974, 520)
            Me.DataGridViewVendorCollectedDetails_VendorCollectedDetails.TabIndex = 6
            Me.DataGridViewVendorCollectedDetails_VendorCollectedDetails.UseEmbeddedNavigator = False
            Me.DataGridViewVendorCollectedDetails_VendorCollectedDetails.ViewCaptionHeight = -1
            '
            'TabItemReviewItems_VendorCollectedDetails
            '
            Me.TabItemReviewItems_VendorCollectedDetails.AttachedControl = Me.TabControlPanelPaymentDetailsTab_VendorCollectedDetails
            Me.TabItemReviewItems_VendorCollectedDetails.Name = "TabItemReviewItems_VendorCollectedDetails"
            Me.TabItemReviewItems_VendorCollectedDetails.Text = "Vendor Collected Details"
            '
            'TabControlPanelLineCommentsTab_LineComments
            '
            Me.TabControlPanelLineCommentsTab_LineComments.Controls.Add(Me.DataGridViewLineComments_LineComments)
            Me.TabControlPanelLineCommentsTab_LineComments.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelLineCommentsTab_LineComments.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelLineCommentsTab_LineComments.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelLineCommentsTab_LineComments.Name = "TabControlPanelLineCommentsTab_LineComments"
            Me.TabControlPanelLineCommentsTab_LineComments.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelLineCommentsTab_LineComments.Size = New System.Drawing.Size(982, 528)
            Me.TabControlPanelLineCommentsTab_LineComments.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelLineCommentsTab_LineComments.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelLineCommentsTab_LineComments.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelLineCommentsTab_LineComments.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelLineCommentsTab_LineComments.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelLineCommentsTab_LineComments.Style.GradientAngle = 90
            Me.TabControlPanelLineCommentsTab_LineComments.TabIndex = 8
            Me.TabControlPanelLineCommentsTab_LineComments.TabItem = Me.TabItemReviewItems_LineComments
            '
            'DataGridViewLineComments_LineComments
            '
            Me.DataGridViewLineComments_LineComments.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewLineComments_LineComments.AllowDragAndDrop = False
            Me.DataGridViewLineComments_LineComments.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewLineComments_LineComments.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLineComments_LineComments.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLineComments_LineComments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLineComments_LineComments.AutoFilterLookupColumns = False
            Me.DataGridViewLineComments_LineComments.AutoloadRepositoryDatasource = False
            Me.DataGridViewLineComments_LineComments.AutoUpdateViewCaption = True
            Me.DataGridViewLineComments_LineComments.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewLineComments_LineComments.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLineComments_LineComments.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLineComments_LineComments.ItemDescription = ""
            Me.DataGridViewLineComments_LineComments.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewLineComments_LineComments.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewLineComments_LineComments.MultiSelect = True
            Me.DataGridViewLineComments_LineComments.Name = "DataGridViewLineComments_LineComments"
            Me.DataGridViewLineComments_LineComments.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLineComments_LineComments.RunStandardValidation = True
            Me.DataGridViewLineComments_LineComments.ShowColumnMenuOnRightClick = False
            Me.DataGridViewLineComments_LineComments.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLineComments_LineComments.Size = New System.Drawing.Size(974, 520)
            Me.DataGridViewLineComments_LineComments.TabIndex = 5
            Me.DataGridViewLineComments_LineComments.UseEmbeddedNavigator = False
            Me.DataGridViewLineComments_LineComments.ViewCaptionHeight = -1
            '
            'TabItemReviewItems_LineComments
            '
            Me.TabItemReviewItems_LineComments.AttachedControl = Me.TabControlPanelLineCommentsTab_LineComments
            Me.TabItemReviewItems_LineComments.Name = "TabItemReviewItems_LineComments"
            Me.TabItemReviewItems_LineComments.Text = "Line Comments"
            '
            'TabControlPanelDocumentsTab_Documents
            '
            Me.TabControlPanelDocumentsTab_Documents.Controls.Add(Me.DocumentManagerControlDocuments_Documents)
            Me.TabControlPanelDocumentsTab_Documents.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelDocumentsTab_Documents.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelDocumentsTab_Documents.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelDocumentsTab_Documents.Name = "TabControlPanelDocumentsTab_Documents"
            Me.TabControlPanelDocumentsTab_Documents.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelDocumentsTab_Documents.Size = New System.Drawing.Size(982, 528)
            Me.TabControlPanelDocumentsTab_Documents.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelDocumentsTab_Documents.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDocumentsTab_Documents.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelDocumentsTab_Documents.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelDocumentsTab_Documents.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelDocumentsTab_Documents.Style.GradientAngle = 90
            Me.TabControlPanelDocumentsTab_Documents.TabIndex = 5
            Me.TabControlPanelDocumentsTab_Documents.TabItem = Me.TabItemReviewItems_Documents
            '
            'DocumentManagerControlDocuments_Documents
            '
            Me.DocumentManagerControlDocuments_Documents.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DocumentManagerControlDocuments_Documents.Location = New System.Drawing.Point(4, 4)
            Me.DocumentManagerControlDocuments_Documents.Name = "DocumentManagerControlDocuments_Documents"
            Me.DocumentManagerControlDocuments_Documents.Size = New System.Drawing.Size(974, 520)
            Me.DocumentManagerControlDocuments_Documents.TabIndex = 0
            '
            'TabItemReviewItems_Documents
            '
            Me.TabItemReviewItems_Documents.AttachedControl = Me.TabControlPanelDocumentsTab_Documents
            Me.TabItemReviewItems_Documents.Name = "TabItemReviewItems_Documents"
            Me.TabItemReviewItems_Documents.Text = "Documents"
            '
            'TabControlPanelOrderCommentsTab_OrderComments
            '
            Me.TabControlPanelOrderCommentsTab_OrderComments.Controls.Add(Me.DataGridViewOrderComments_OrderComments)
            Me.TabControlPanelOrderCommentsTab_OrderComments.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelOrderCommentsTab_OrderComments.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelOrderCommentsTab_OrderComments.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelOrderCommentsTab_OrderComments.Name = "TabControlPanelOrderCommentsTab_OrderComments"
            Me.TabControlPanelOrderCommentsTab_OrderComments.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelOrderCommentsTab_OrderComments.Size = New System.Drawing.Size(982, 528)
            Me.TabControlPanelOrderCommentsTab_OrderComments.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelOrderCommentsTab_OrderComments.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelOrderCommentsTab_OrderComments.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelOrderCommentsTab_OrderComments.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelOrderCommentsTab_OrderComments.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelOrderCommentsTab_OrderComments.Style.GradientAngle = 90
            Me.TabControlPanelOrderCommentsTab_OrderComments.TabIndex = 7
            Me.TabControlPanelOrderCommentsTab_OrderComments.TabItem = Me.TabItemReviewItems_OrderComments
            '
            'DataGridViewOrderComments_OrderComments
            '
            Me.DataGridViewOrderComments_OrderComments.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewOrderComments_OrderComments.AllowDragAndDrop = False
            Me.DataGridViewOrderComments_OrderComments.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewOrderComments_OrderComments.AllowSelectGroupHeaderRow = True
            Me.DataGridViewOrderComments_OrderComments.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewOrderComments_OrderComments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewOrderComments_OrderComments.AutoFilterLookupColumns = False
            Me.DataGridViewOrderComments_OrderComments.AutoloadRepositoryDatasource = False
            Me.DataGridViewOrderComments_OrderComments.AutoUpdateViewCaption = True
            Me.DataGridViewOrderComments_OrderComments.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewOrderComments_OrderComments.DataSource = Nothing
            Me.DataGridViewOrderComments_OrderComments.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewOrderComments_OrderComments.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewOrderComments_OrderComments.ItemDescription = ""
            Me.DataGridViewOrderComments_OrderComments.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewOrderComments_OrderComments.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewOrderComments_OrderComments.MultiSelect = True
            Me.DataGridViewOrderComments_OrderComments.Name = "DataGridViewOrderComments_OrderComments"
            Me.DataGridViewOrderComments_OrderComments.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewOrderComments_OrderComments.RunStandardValidation = True
            Me.DataGridViewOrderComments_OrderComments.ShowColumnMenuOnRightClick = False
            Me.DataGridViewOrderComments_OrderComments.ShowSelectDeselectAllButtons = False
            Me.DataGridViewOrderComments_OrderComments.Size = New System.Drawing.Size(974, 520)
            Me.DataGridViewOrderComments_OrderComments.TabIndex = 4
            Me.DataGridViewOrderComments_OrderComments.UseEmbeddedNavigator = False
            Me.DataGridViewOrderComments_OrderComments.ViewCaptionHeight = -1
            '
            'TabItemReviewItems_OrderComments
            '
            Me.TabItemReviewItems_OrderComments.AttachedControl = Me.TabControlPanelOrderCommentsTab_OrderComments
            Me.TabItemReviewItems_OrderComments.Name = "TabItemReviewItems_OrderComments"
            Me.TabItemReviewItems_OrderComments.Text = "Order Comments"
            '
            'RibbonBarOptions_Documents
            '
            Me.RibbonBarOptions_Documents.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Documents.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Documents.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Documents.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Documents.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Documents.DragDropSupport = True
            Me.RibbonBarOptions_Documents.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDocuments_UploadOrder, Me.ButtonItemDocuments_UploadJob, Me.ButtonItemDocuments_UploadJobComponent, Me.ButtonItemDocuments_UploadCampaign, Me.ButtonItemDocuments_Upload, Me.ButtonItemDocuments_Download, Me.ButtonItemDocuments_OpenURL})
            Me.RibbonBarOptions_Documents.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Documents.Location = New System.Drawing.Point(1174, 0)
            Me.RibbonBarOptions_Documents.Name = "RibbonBarOptions_Documents"
            Me.RibbonBarOptions_Documents.SecurityEnabled = True
            Me.RibbonBarOptions_Documents.Size = New System.Drawing.Size(123, 92)
            Me.RibbonBarOptions_Documents.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Documents.TabIndex = 20
            Me.RibbonBarOptions_Documents.Text = "Documents"
            '
            '
            '
            Me.RibbonBarOptions_Documents.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Documents.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Documents.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemDocuments_UploadOrder
            '
            Me.ButtonItemDocuments_UploadOrder.BeginGroup = True
            Me.ButtonItemDocuments_UploadOrder.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDocuments_UploadOrder.Name = "ButtonItemDocuments_UploadOrder"
            Me.ButtonItemDocuments_UploadOrder.RibbonWordWrap = False
            Me.ButtonItemDocuments_UploadOrder.SecurityEnabled = True
            Me.ButtonItemDocuments_UploadOrder.SplitButton = True
            Me.ButtonItemDocuments_UploadOrder.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemUploadOrder_EmailLink})
            Me.ButtonItemDocuments_UploadOrder.SubItemsExpandWidth = 14
            Me.ButtonItemDocuments_UploadOrder.Text = "Upload Order"
            '
            'ButtonItemUploadOrder_EmailLink
            '
            Me.ButtonItemUploadOrder_EmailLink.Name = "ButtonItemUploadOrder_EmailLink"
            Me.ButtonItemUploadOrder_EmailLink.Text = "Email Link"
            '
            'ButtonItemDocuments_UploadJob
            '
            Me.ButtonItemDocuments_UploadJob.BeginGroup = True
            Me.ButtonItemDocuments_UploadJob.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDocuments_UploadJob.Name = "ButtonItemDocuments_UploadJob"
            Me.ButtonItemDocuments_UploadJob.RibbonWordWrap = False
            Me.ButtonItemDocuments_UploadJob.SecurityEnabled = True
            Me.ButtonItemDocuments_UploadJob.SplitButton = True
            Me.ButtonItemDocuments_UploadJob.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemUploadJob_EmailLink})
            Me.ButtonItemDocuments_UploadJob.SubItemsExpandWidth = 14
            Me.ButtonItemDocuments_UploadJob.Text = "Upload Job"
            '
            'ButtonItemUploadJob_EmailLink
            '
            Me.ButtonItemUploadJob_EmailLink.Name = "ButtonItemUploadJob_EmailLink"
            Me.ButtonItemUploadJob_EmailLink.Text = "Email Link"
            '
            'ButtonItemDocuments_UploadJobComponent
            '
            Me.ButtonItemDocuments_UploadJobComponent.BeginGroup = True
            Me.ButtonItemDocuments_UploadJobComponent.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDocuments_UploadJobComponent.Name = "ButtonItemDocuments_UploadJobComponent"
            Me.ButtonItemDocuments_UploadJobComponent.RibbonWordWrap = False
            Me.ButtonItemDocuments_UploadJobComponent.SecurityEnabled = True
            Me.ButtonItemDocuments_UploadJobComponent.SplitButton = True
            Me.ButtonItemDocuments_UploadJobComponent.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemUploadJobComponent_EmailLink})
            Me.ButtonItemDocuments_UploadJobComponent.SubItemsExpandWidth = 14
            Me.ButtonItemDocuments_UploadJobComponent.Text = "Upload Job Comp"
            '
            'ButtonItemUploadJobComponent_EmailLink
            '
            Me.ButtonItemUploadJobComponent_EmailLink.Name = "ButtonItemUploadJobComponent_EmailLink"
            Me.ButtonItemUploadJobComponent_EmailLink.Text = "Email Link"
            '
            'ButtonItemDocuments_UploadCampaign
            '
            Me.ButtonItemDocuments_UploadCampaign.BeginGroup = True
            Me.ButtonItemDocuments_UploadCampaign.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDocuments_UploadCampaign.Name = "ButtonItemDocuments_UploadCampaign"
            Me.ButtonItemDocuments_UploadCampaign.RibbonWordWrap = False
            Me.ButtonItemDocuments_UploadCampaign.SecurityEnabled = True
            Me.ButtonItemDocuments_UploadCampaign.SplitButton = True
            Me.ButtonItemDocuments_UploadCampaign.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemUploadCampaign_EmailLink})
            Me.ButtonItemDocuments_UploadCampaign.SubItemsExpandWidth = 14
            Me.ButtonItemDocuments_UploadCampaign.Text = "Upload Campaign"
            '
            'ButtonItemUploadCampaign_EmailLink
            '
            Me.ButtonItemUploadCampaign_EmailLink.Name = "ButtonItemUploadCampaign_EmailLink"
            Me.ButtonItemUploadCampaign_EmailLink.Text = "Email Link"
            '
            'ButtonItemDocuments_Upload
            '
            Me.ButtonItemDocuments_Upload.BeginGroup = True
            Me.ButtonItemDocuments_Upload.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDocuments_Upload.Name = "ButtonItemDocuments_Upload"
            Me.ButtonItemDocuments_Upload.RibbonWordWrap = False
            Me.ButtonItemDocuments_Upload.SecurityEnabled = True
            Me.ButtonItemDocuments_Upload.SplitButton = True
            Me.ButtonItemDocuments_Upload.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemUpload_EmailLink})
            Me.ButtonItemDocuments_Upload.SubItemsExpandWidth = 14
            Me.ButtonItemDocuments_Upload.Text = "Upload"
            '
            'ButtonItemUpload_EmailLink
            '
            Me.ButtonItemUpload_EmailLink.Name = "ButtonItemUpload_EmailLink"
            Me.ButtonItemUpload_EmailLink.Text = "Email Link"
            '
            'ButtonItemDocuments_Download
            '
            Me.ButtonItemDocuments_Download.BeginGroup = True
            Me.ButtonItemDocuments_Download.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDocuments_Download.Name = "ButtonItemDocuments_Download"
            Me.ButtonItemDocuments_Download.RibbonWordWrap = False
            Me.ButtonItemDocuments_Download.SecurityEnabled = True
            Me.ButtonItemDocuments_Download.SubItemsExpandWidth = 14
            Me.ButtonItemDocuments_Download.Text = "Download"
            '
            'ButtonItemDocuments_OpenURL
            '
            Me.ButtonItemDocuments_OpenURL.BeginGroup = True
            Me.ButtonItemDocuments_OpenURL.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDocuments_OpenURL.Name = "ButtonItemDocuments_OpenURL"
            Me.ButtonItemDocuments_OpenURL.RibbonWordWrap = False
            Me.ButtonItemDocuments_OpenURL.SecurityEnabled = True
            Me.ButtonItemDocuments_OpenURL.SubItemsExpandWidth = 14
            Me.ButtonItemDocuments_OpenURL.Text = "Open URL"
            '
            'RibbonBarOptions_Filter
            '
            Me.RibbonBarOptions_Filter.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Filter.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Filter.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Filter.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Filter.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Filter.DragDropSupport = True
            Me.RibbonBarOptions_Filter.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemFilter_All, Me.ButtonItemFilter_SelectedLineItem})
            Me.RibbonBarOptions_Filter.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Filter.Location = New System.Drawing.Point(1297, 0)
            Me.RibbonBarOptions_Filter.Name = "RibbonBarOptions_Filter"
            Me.RibbonBarOptions_Filter.SecurityEnabled = True
            Me.RibbonBarOptions_Filter.Size = New System.Drawing.Size(147, 92)
            Me.RibbonBarOptions_Filter.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Filter.TabIndex = 21
            Me.RibbonBarOptions_Filter.Text = "Filter"
            '
            '
            '
            Me.RibbonBarOptions_Filter.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Filter.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Filter.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            Me.RibbonBarOptions_Filter.Visible = False
            '
            'ButtonItemFilter_All
            '
            Me.ButtonItemFilter_All.AutoCheckOnClick = True
            Me.ButtonItemFilter_All.BeginGroup = True
            Me.ButtonItemFilter_All.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemFilter_All.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemFilter_All.Name = "ButtonItemFilter_All"
            Me.ButtonItemFilter_All.RibbonWordWrap = False
            Me.ButtonItemFilter_All.SecurityEnabled = True
            Me.ButtonItemFilter_All.Stretch = True
            Me.ButtonItemFilter_All.SubItemsExpandWidth = 14
            Me.ButtonItemFilter_All.Text = "All"
            '
            'ButtonItemFilter_SelectedLineItem
            '
            Me.ButtonItemFilter_SelectedLineItem.AutoCheckOnClick = True
            Me.ButtonItemFilter_SelectedLineItem.BeginGroup = True
            Me.ButtonItemFilter_SelectedLineItem.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemFilter_SelectedLineItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemFilter_SelectedLineItem.Name = "ButtonItemFilter_SelectedLineItem"
            Me.ButtonItemFilter_SelectedLineItem.RibbonWordWrap = False
            Me.ButtonItemFilter_SelectedLineItem.SecurityEnabled = True
            Me.ButtonItemFilter_SelectedLineItem.Stretch = True
            Me.ButtonItemFilter_SelectedLineItem.SubItemsExpandWidth = 14
            Me.ButtonItemFilter_SelectedLineItem.Text = "Selected Line Item(s)"
            '
            'RibbonBarOptions_BillingApproval
            '
            Me.RibbonBarOptions_BillingApproval.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_BillingApproval.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_BillingApproval.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_BillingApproval.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_BillingApproval.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_BillingApproval.DragDropSupport = True
            Me.RibbonBarOptions_BillingApproval.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemBillingApproval_Approve, Me.ButtonItemBillingApproval_Unapprove})
            Me.RibbonBarOptions_BillingApproval.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_BillingApproval.Location = New System.Drawing.Point(1044, 0)
            Me.RibbonBarOptions_BillingApproval.Name = "RibbonBarOptions_BillingApproval"
            Me.RibbonBarOptions_BillingApproval.SecurityEnabled = True
            Me.RibbonBarOptions_BillingApproval.Size = New System.Drawing.Size(130, 92)
            Me.RibbonBarOptions_BillingApproval.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_BillingApproval.TabIndex = 22
            Me.RibbonBarOptions_BillingApproval.Text = "Billing Approval"
            '
            '
            '
            Me.RibbonBarOptions_BillingApproval.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_BillingApproval.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_BillingApproval.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemBillingApproval_Approve
            '
            Me.ButtonItemBillingApproval_Approve.BeginGroup = True
            Me.ButtonItemBillingApproval_Approve.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemBillingApproval_Approve.Name = "ButtonItemBillingApproval_Approve"
            Me.ButtonItemBillingApproval_Approve.RibbonWordWrap = False
            Me.ButtonItemBillingApproval_Approve.SecurityEnabled = True
            Me.ButtonItemBillingApproval_Approve.SubItemsExpandWidth = 14
            Me.ButtonItemBillingApproval_Approve.Text = "Approve"
            '
            'ButtonItemBillingApproval_Unapprove
            '
            Me.ButtonItemBillingApproval_Unapprove.BeginGroup = True
            Me.ButtonItemBillingApproval_Unapprove.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemBillingApproval_Unapprove.Name = "ButtonItemBillingApproval_Unapprove"
            Me.ButtonItemBillingApproval_Unapprove.RibbonWordWrap = False
            Me.ButtonItemBillingApproval_Unapprove.SecurityEnabled = True
            Me.ButtonItemBillingApproval_Unapprove.SubItemsExpandWidth = 14
            Me.ButtonItemBillingApproval_Unapprove.Text = "Unapprove"
            '
            'RibbonBarOptions_VendorReps
            '
            Me.RibbonBarOptions_VendorReps.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_VendorReps.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_VendorReps.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_VendorReps.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_VendorReps.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_VendorReps.DragDropSupport = True
            Me.RibbonBarOptions_VendorReps.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemVendorReps_Add, Me.ButtonItemVendorReps_Edit, Me.ButtonItemVendorReps_Delete})
            Me.RibbonBarOptions_VendorReps.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_VendorReps.Location = New System.Drawing.Point(912, 0)
            Me.RibbonBarOptions_VendorReps.Name = "RibbonBarOptions_VendorReps"
            Me.RibbonBarOptions_VendorReps.SecurityEnabled = True
            Me.RibbonBarOptions_VendorReps.Size = New System.Drawing.Size(132, 92)
            Me.RibbonBarOptions_VendorReps.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_VendorReps.TabIndex = 23
            Me.RibbonBarOptions_VendorReps.Text = "Vendor Reps"
            '
            '
            '
            Me.RibbonBarOptions_VendorReps.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_VendorReps.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_VendorReps.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemVendorReps_Add
            '
            Me.ButtonItemVendorReps_Add.BeginGroup = True
            Me.ButtonItemVendorReps_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemVendorReps_Add.Name = "ButtonItemVendorReps_Add"
            Me.ButtonItemVendorReps_Add.RibbonWordWrap = False
            Me.ButtonItemVendorReps_Add.SecurityEnabled = True
            Me.ButtonItemVendorReps_Add.SubItemsExpandWidth = 14
            Me.ButtonItemVendorReps_Add.Text = "Add"
            '
            'ButtonItemVendorReps_Edit
            '
            Me.ButtonItemVendorReps_Edit.BeginGroup = True
            Me.ButtonItemVendorReps_Edit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemVendorReps_Edit.Name = "ButtonItemVendorReps_Edit"
            Me.ButtonItemVendorReps_Edit.RibbonWordWrap = False
            Me.ButtonItemVendorReps_Edit.SecurityEnabled = True
            Me.ButtonItemVendorReps_Edit.SubItemsExpandWidth = 14
            Me.ButtonItemVendorReps_Edit.Text = "Edit"
            '
            'ButtonItemVendorReps_Delete
            '
            Me.ButtonItemVendorReps_Delete.BeginGroup = True
            Me.ButtonItemVendorReps_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemVendorReps_Delete.Name = "ButtonItemVendorReps_Delete"
            Me.ButtonItemVendorReps_Delete.RibbonWordWrap = False
            Me.ButtonItemVendorReps_Delete.SecurityEnabled = True
            Me.ButtonItemVendorReps_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemVendorReps_Delete.Text = "Delete"
            '
            'RibbonBarOptions_Vendor
            '
            Me.RibbonBarOptions_Vendor.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarOptions_Vendor.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Vendor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Vendor.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Vendor.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Vendor.DragDropSupport = True
            Me.RibbonBarOptions_Vendor.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemVendor_Edit})
            Me.RibbonBarOptions_Vendor.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Vendor.Location = New System.Drawing.Point(851, 0)
            Me.RibbonBarOptions_Vendor.Name = "RibbonBarOptions_Vendor"
            Me.RibbonBarOptions_Vendor.SecurityEnabled = True
            Me.RibbonBarOptions_Vendor.Size = New System.Drawing.Size(61, 92)
            Me.RibbonBarOptions_Vendor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Vendor.TabIndex = 25
            Me.RibbonBarOptions_Vendor.Text = "Vendor"
            '
            '
            '
            Me.RibbonBarOptions_Vendor.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Vendor.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Vendor.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemVendor_Edit
            '
            Me.ButtonItemVendor_Edit.BeginGroup = True
            Me.ButtonItemVendor_Edit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemVendor_Edit.Name = "ButtonItemVendor_Edit"
            Me.ButtonItemVendor_Edit.RibbonWordWrap = False
            Me.ButtonItemVendor_Edit.SecurityEnabled = True
            Me.ButtonItemVendor_Edit.SubItemsExpandWidth = 14
            Me.ButtonItemVendor_Edit.Text = "Edit"
            '
            'RibbonBarOptions_GridOptionsVCCDetails
            '
            Me.RibbonBarOptions_GridOptionsVCCDetails.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_GridOptionsVCCDetails.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_GridOptionsVCCDetails.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_GridOptionsVCCDetails.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_GridOptionsVCCDetails.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_GridOptionsVCCDetails.DragDropSupport = True
            Me.RibbonBarOptions_GridOptionsVCCDetails.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemGridOptionsVCCDetails_ChooseColumns, Me.ButtonItemGridOptionsVCCDetails_RestoreDefaults})
            Me.RibbonBarOptions_GridOptionsVCCDetails.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_GridOptionsVCCDetails.Location = New System.Drawing.Point(2133, 0)
            Me.RibbonBarOptions_GridOptionsVCCDetails.Name = "RibbonBarOptions_GridOptionsVCCDetails"
            Me.RibbonBarOptions_GridOptionsVCCDetails.SecurityEnabled = True
            Me.RibbonBarOptions_GridOptionsVCCDetails.Size = New System.Drawing.Size(205, 92)
            Me.RibbonBarOptions_GridOptionsVCCDetails.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_GridOptionsVCCDetails.TabIndex = 26
            Me.RibbonBarOptions_GridOptionsVCCDetails.Text = "Grid Options"
            '
            '
            '
            Me.RibbonBarOptions_GridOptionsVCCDetails.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_GridOptionsVCCDetails.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_GridOptionsVCCDetails.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemGridOptionsVCCDetails_ChooseColumns
            '
            Me.ButtonItemGridOptionsVCCDetails_ChooseColumns.AutoCheckOnClick = True
            Me.ButtonItemGridOptionsVCCDetails_ChooseColumns.BeginGroup = True
            Me.ButtonItemGridOptionsVCCDetails_ChooseColumns.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemGridOptionsVCCDetails_ChooseColumns.Name = "ButtonItemGridOptionsVCCDetails_ChooseColumns"
            Me.ButtonItemGridOptionsVCCDetails_ChooseColumns.RibbonWordWrap = False
            Me.ButtonItemGridOptionsVCCDetails_ChooseColumns.SecurityEnabled = True
            Me.ButtonItemGridOptionsVCCDetails_ChooseColumns.SubItemsExpandWidth = 14
            Me.ButtonItemGridOptionsVCCDetails_ChooseColumns.Text = "Choose Columns"
            '
            'ButtonItemGridOptionsVCCDetails_RestoreDefaults
            '
            Me.ButtonItemGridOptionsVCCDetails_RestoreDefaults.BeginGroup = True
            Me.ButtonItemGridOptionsVCCDetails_RestoreDefaults.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemGridOptionsVCCDetails_RestoreDefaults.Name = "ButtonItemGridOptionsVCCDetails_RestoreDefaults"
            Me.ButtonItemGridOptionsVCCDetails_RestoreDefaults.RibbonWordWrap = False
            Me.ButtonItemGridOptionsVCCDetails_RestoreDefaults.SecurityEnabled = True
            Me.ButtonItemGridOptionsVCCDetails_RestoreDefaults.SubItemsExpandWidth = 14
            Me.ButtonItemGridOptionsVCCDetails_RestoreDefaults.Text = "Restore Defaults"
            '
            'RibbonBarOptions_SummaryResults
            '
            Me.RibbonBarOptions_SummaryResults.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_SummaryResults.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_SummaryResults.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_SummaryResults.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_SummaryResults.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_SummaryResults.DragDropSupport = True
            Me.RibbonBarOptions_SummaryResults.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerSummaryResults_Far, Me.ItemContainerSummaryResults_Splitter1, Me.ItemContainerSummaryResults_Center, Me.ItemContainerSummaryResults_Splitter2})
            Me.RibbonBarOptions_SummaryResults.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_SummaryResults.Location = New System.Drawing.Point(1444, 0)
            Me.RibbonBarOptions_SummaryResults.Name = "RibbonBarOptions_SummaryResults"
            Me.RibbonBarOptions_SummaryResults.SecurityEnabled = True
            Me.RibbonBarOptions_SummaryResults.Size = New System.Drawing.Size(339, 92)
            Me.RibbonBarOptions_SummaryResults.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_SummaryResults.TabIndex = 27
            Me.RibbonBarOptions_SummaryResults.Text = "Summary Results Filter"
            '
            '
            '
            Me.RibbonBarOptions_SummaryResults.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_SummaryResults.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_SummaryResults.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ItemContainerSummaryResults_Far
            '
            '
            '
            '
            Me.ItemContainerSummaryResults_Far.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSummaryResults_Far.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerSummaryResults_Far.Name = "ItemContainerSummaryResults_Far"
            Me.ItemContainerSummaryResults_Far.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemSummaryResults_VCCIssuedAndUpdated, Me.ButtonItemSummaryResults_TransactionsDeclined, Me.ButtonItemSummaryResults_TransactionsOutOfBalance})
            '
            '
            '
            Me.ItemContainerSummaryResults_Far.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerSummaryResults_Far.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemSummaryResults_VCCIssuedAndUpdated
            '
            Me.ButtonItemSummaryResults_VCCIssuedAndUpdated.Name = "ButtonItemSummaryResults_VCCIssuedAndUpdated"
            Me.ButtonItemSummaryResults_VCCIssuedAndUpdated.NotificationMarkColor = System.Drawing.Color.LightSkyBlue
            Me.ButtonItemSummaryResults_VCCIssuedAndUpdated.NotificationMarkOffset = New System.Drawing.Point(10, 0)
            Me.ButtonItemSummaryResults_VCCIssuedAndUpdated.NotificationMarkPosition = DevComponents.DotNetBar.eNotificationMarkPosition.BottomRight
            Me.ButtonItemSummaryResults_VCCIssuedAndUpdated.SubItemsExpandWidth = 14
            Me.ButtonItemSummaryResults_VCCIssuedAndUpdated.Text = "VCC Issued and Updated<span width=""10""></span>"
            '
            'ButtonItemSummaryResults_TransactionsDeclined
            '
            Me.ButtonItemSummaryResults_TransactionsDeclined.Name = "ButtonItemSummaryResults_TransactionsDeclined"
            Me.ButtonItemSummaryResults_TransactionsDeclined.NotificationMarkColor = System.Drawing.Color.LightSkyBlue
            Me.ButtonItemSummaryResults_TransactionsDeclined.NotificationMarkOffset = New System.Drawing.Point(10, 0)
            Me.ButtonItemSummaryResults_TransactionsDeclined.NotificationMarkPosition = DevComponents.DotNetBar.eNotificationMarkPosition.BottomRight
            Me.ButtonItemSummaryResults_TransactionsDeclined.SubItemsExpandWidth = 14
            Me.ButtonItemSummaryResults_TransactionsDeclined.Text = "Transactions Declined<span width=""10""></span>"
            '
            'ButtonItemSummaryResults_TransactionsOutOfBalance
            '
            Me.ButtonItemSummaryResults_TransactionsOutOfBalance.Name = "ButtonItemSummaryResults_TransactionsOutOfBalance"
            Me.ButtonItemSummaryResults_TransactionsOutOfBalance.NotificationMarkColor = System.Drawing.Color.LightSkyBlue
            Me.ButtonItemSummaryResults_TransactionsOutOfBalance.NotificationMarkOffset = New System.Drawing.Point(10, 0)
            Me.ButtonItemSummaryResults_TransactionsOutOfBalance.NotificationMarkPosition = DevComponents.DotNetBar.eNotificationMarkPosition.BottomRight
            Me.ButtonItemSummaryResults_TransactionsOutOfBalance.SubItemsExpandWidth = 14
            Me.ButtonItemSummaryResults_TransactionsOutOfBalance.Text = "Transactions Out of Balance<span width=""10""></span>"
            '
            'ItemContainerSummaryResults_Splitter1
            '
            '
            '
            '
            Me.ItemContainerSummaryResults_Splitter1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSummaryResults_Splitter1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerSummaryResults_Splitter1.Name = "ItemContainerSummaryResults_Splitter1"
            Me.ItemContainerSummaryResults_Splitter1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1})
            '
            '
            '
            Me.ItemContainerSummaryResults_Splitter1.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerSummaryResults_Splitter1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItem1
            '
            Me.LabelItem1.Name = "LabelItem1"
            Me.LabelItem1.Text = "<span width=""15"">  </span>"
            '
            'ItemContainerSummaryResults_Center
            '
            '
            '
            '
            Me.ItemContainerSummaryResults_Center.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSummaryResults_Center.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerSummaryResults_Center.Name = "ItemContainerSummaryResults_Center"
            Me.ItemContainerSummaryResults_Center.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemSummaryResults_TransactionsInBalance, Me.ButtonItemSummaryResults_NoTransactions, Me.ButtonItemSummaryResults_Followup})
            '
            '
            '
            Me.ItemContainerSummaryResults_Center.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerSummaryResults_Center.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemSummaryResults_TransactionsInBalance
            '
            Me.ButtonItemSummaryResults_TransactionsInBalance.Name = "ButtonItemSummaryResults_TransactionsInBalance"
            Me.ButtonItemSummaryResults_TransactionsInBalance.NotificationMarkColor = System.Drawing.Color.LightSkyBlue
            Me.ButtonItemSummaryResults_TransactionsInBalance.NotificationMarkOffset = New System.Drawing.Point(10, 0)
            Me.ButtonItemSummaryResults_TransactionsInBalance.NotificationMarkPosition = DevComponents.DotNetBar.eNotificationMarkPosition.BottomRight
            Me.ButtonItemSummaryResults_TransactionsInBalance.SubItemsExpandWidth = 14
            Me.ButtonItemSummaryResults_TransactionsInBalance.Text = "Transactions In Balance<span width=""10""></span>"
            '
            'ButtonItemSummaryResults_NoTransactions
            '
            Me.ButtonItemSummaryResults_NoTransactions.Name = "ButtonItemSummaryResults_NoTransactions"
            Me.ButtonItemSummaryResults_NoTransactions.NotificationMarkColor = System.Drawing.Color.LightSkyBlue
            Me.ButtonItemSummaryResults_NoTransactions.NotificationMarkOffset = New System.Drawing.Point(10, 0)
            Me.ButtonItemSummaryResults_NoTransactions.NotificationMarkPosition = DevComponents.DotNetBar.eNotificationMarkPosition.BottomRight
            Me.ButtonItemSummaryResults_NoTransactions.SubItemsExpandWidth = 14
            Me.ButtonItemSummaryResults_NoTransactions.Text = "No Transactions<span width=""10""></span>"
            '
            'ButtonItemSummaryResults_Followup
            '
            Me.ButtonItemSummaryResults_Followup.Name = "ButtonItemSummaryResults_Followup"
            Me.ButtonItemSummaryResults_Followup.NotificationMarkColor = System.Drawing.Color.LightSkyBlue
            Me.ButtonItemSummaryResults_Followup.NotificationMarkOffset = New System.Drawing.Point(10, 0)
            Me.ButtonItemSummaryResults_Followup.NotificationMarkPosition = DevComponents.DotNetBar.eNotificationMarkPosition.BottomRight
            Me.ButtonItemSummaryResults_Followup.SubItemsExpandWidth = 14
            Me.ButtonItemSummaryResults_Followup.Text = "Follow Up<span width=""10""></span>"
            '
            'ItemContainerSummaryResults_Splitter2
            '
            '
            '
            '
            Me.ItemContainerSummaryResults_Splitter2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSummaryResults_Splitter2.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerSummaryResults_Splitter2.Name = "ItemContainerSummaryResults_Splitter2"
            Me.ItemContainerSummaryResults_Splitter2.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem2})
            '
            '
            '
            Me.ItemContainerSummaryResults_Splitter2.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerSummaryResults_Splitter2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItem2
            '
            Me.LabelItem2.Name = "LabelItem2"
            Me.LabelItem2.Text = "<span width=""15"">  </span>"
            '
            'RibbonBarOptions_Orders
            '
            Me.RibbonBarOptions_Orders.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarOptions_Orders.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Orders.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Orders.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Orders.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Orders.DragDropSupport = True
            Me.RibbonBarOptions_Orders.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemOrders_GenerateOrders, Me.ButtonItemOrders_CreateRevision, Me.ButtonItemOrders_AdServing, Me.ButtonItemOrders_UpdateCost, Me.ButtonItemOrders_WriteUpDown, Me.ButtonItemOrders_ProcessControl})
            Me.RibbonBarOptions_Orders.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Orders.Location = New System.Drawing.Point(196, 0)
            Me.RibbonBarOptions_Orders.Name = "RibbonBarOptions_Orders"
            Me.RibbonBarOptions_Orders.SecurityEnabled = True
            Me.RibbonBarOptions_Orders.Size = New System.Drawing.Size(508, 92)
            Me.RibbonBarOptions_Orders.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Orders.TabIndex = 19
            Me.RibbonBarOptions_Orders.Text = "Orders"
            '
            '
            '
            Me.RibbonBarOptions_Orders.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Orders.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Orders.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemOrders_GenerateOrders
            '
            Me.ButtonItemOrders_GenerateOrders.BeginGroup = True
            Me.ButtonItemOrders_GenerateOrders.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemOrders_GenerateOrders.Name = "ButtonItemOrders_GenerateOrders"
            Me.ButtonItemOrders_GenerateOrders.RibbonWordWrap = False
            Me.ButtonItemOrders_GenerateOrders.SecurityEnabled = True
            Me.ButtonItemOrders_GenerateOrders.SubItemsExpandWidth = 14
            Me.ButtonItemOrders_GenerateOrders.Text = "Generate Orders"
            '
            'ButtonItemOrders_CreateRevision
            '
            Me.ButtonItemOrders_CreateRevision.AutoCheckOnClick = True
            Me.ButtonItemOrders_CreateRevision.BeginGroup = True
            Me.ButtonItemOrders_CreateRevision.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemOrders_CreateRevision.Name = "ButtonItemOrders_CreateRevision"
            Me.ButtonItemOrders_CreateRevision.RibbonWordWrap = False
            Me.ButtonItemOrders_CreateRevision.SecurityEnabled = True
            Me.ButtonItemOrders_CreateRevision.SubItemsExpandWidth = 14
            Me.ButtonItemOrders_CreateRevision.Text = "Create Revision"
            '
            'ButtonItemOrders_AdServing
            '
            Me.ButtonItemOrders_AdServing.AutoExpandOnClick = True
            Me.ButtonItemOrders_AdServing.BeginGroup = True
            Me.ButtonItemOrders_AdServing.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemOrders_AdServing.Name = "ButtonItemOrders_AdServing"
            Me.ButtonItemOrders_AdServing.RibbonWordWrap = False
            Me.ButtonItemOrders_AdServing.SecurityEnabled = True
            Me.ButtonItemOrders_AdServing.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemAdServing_DoubleClick})
            Me.ButtonItemOrders_AdServing.SubItemsExpandWidth = 14
            Me.ButtonItemOrders_AdServing.Text = "Ad Serving"
            '
            'ButtonItemAdServing_DoubleClick
            '
            Me.ButtonItemAdServing_DoubleClick.Name = "ButtonItemAdServing_DoubleClick"
            Me.ButtonItemAdServing_DoubleClick.Text = "DoubleClick"
            '
            'ButtonItemOrders_UpdateCost
            '
            Me.ButtonItemOrders_UpdateCost.AutoExpandOnClick = True
            Me.ButtonItemOrders_UpdateCost.BeginGroup = True
            Me.ButtonItemOrders_UpdateCost.ImageFixedSize = New System.Drawing.Size(32, 32)
            Me.ButtonItemOrders_UpdateCost.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemOrders_UpdateCost.Name = "ButtonItemOrders_UpdateCost"
            Me.ButtonItemOrders_UpdateCost.RibbonWordWrap = False
            Me.ButtonItemOrders_UpdateCost.SecurityEnabled = True
            Me.ButtonItemOrders_UpdateCost.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemOrders_UpdateCostToActual, Me.ButtonItemOrders_UpdateCostToVendorCollected})
            Me.ButtonItemOrders_UpdateCost.SubItemsExpandWidth = 14
            Me.ButtonItemOrders_UpdateCost.Text = "Update Cost"
            '
            'ButtonItemOrders_UpdateCostToActual
            '
            Me.ButtonItemOrders_UpdateCostToActual.Name = "ButtonItemOrders_UpdateCostToActual"
            Me.ButtonItemOrders_UpdateCostToActual.Text = "To Actual"
            '
            'ButtonItemOrders_UpdateCostToVendorCollected
            '
            Me.ButtonItemOrders_UpdateCostToVendorCollected.Name = "ButtonItemOrders_UpdateCostToVendorCollected"
            Me.ButtonItemOrders_UpdateCostToVendorCollected.Text = "To Vendor Collected"
            '
            'ButtonItemOrders_WriteUpDown
            '
            Me.ButtonItemOrders_WriteUpDown.BeginGroup = True
            Me.ButtonItemOrders_WriteUpDown.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemOrders_WriteUpDown.Name = "ButtonItemOrders_WriteUpDown"
            Me.ButtonItemOrders_WriteUpDown.RibbonWordWrap = False
            Me.ButtonItemOrders_WriteUpDown.SecurityEnabled = True
            Me.ButtonItemOrders_WriteUpDown.SubItemsExpandWidth = 14
            Me.ButtonItemOrders_WriteUpDown.Text = "Write Up/Down"
            '
            'ButtonItemOrders_ProcessControl
            '
            Me.ButtonItemOrders_ProcessControl.BeginGroup = True
            Me.ButtonItemOrders_ProcessControl.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemOrders_ProcessControl.Name = "ButtonItemOrders_ProcessControl"
            Me.ButtonItemOrders_ProcessControl.RibbonWordWrap = False
            Me.ButtonItemOrders_ProcessControl.SecurityEnabled = True
            Me.ButtonItemOrders_ProcessControl.SubItemsExpandWidth = 14
            Me.ButtonItemOrders_ProcessControl.Text = "Process Control"
            '
            'RibbonBarOptions_VendorInvoices
            '
            Me.RibbonBarOptions_VendorInvoices.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarOptions_VendorInvoices.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_VendorInvoices.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_VendorInvoices.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_VendorInvoices.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_VendorInvoices.DragDropSupport = True
            Me.RibbonBarOptions_VendorInvoices.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemVendorInvoices_CreateInvoices, Me.ButtonItemVendorInvoices_ImportInvoices, Me.ButtonItemVendorInvoices_ApproveInvoices})
            Me.RibbonBarOptions_VendorInvoices.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_VendorInvoices.Location = New System.Drawing.Point(704, 0)
            Me.RibbonBarOptions_VendorInvoices.Name = "RibbonBarOptions_VendorInvoices"
            Me.RibbonBarOptions_VendorInvoices.SecurityEnabled = True
            Me.RibbonBarOptions_VendorInvoices.Size = New System.Drawing.Size(70, 92)
            Me.RibbonBarOptions_VendorInvoices.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_VendorInvoices.TabIndex = 20
            Me.RibbonBarOptions_VendorInvoices.Text = "Vendor Invoices"
            '
            '
            '
            Me.RibbonBarOptions_VendorInvoices.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_VendorInvoices.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_VendorInvoices.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemVendorInvoices_CreateInvoices
            '
            Me.ButtonItemVendorInvoices_CreateInvoices.AutoExpandOnClick = True
            Me.ButtonItemVendorInvoices_CreateInvoices.BeginGroup = True
            Me.ButtonItemVendorInvoices_CreateInvoices.ImageFixedSize = New System.Drawing.Size(32, 32)
            Me.ButtonItemVendorInvoices_CreateInvoices.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemVendorInvoices_CreateInvoices.Name = "ButtonItemVendorInvoices_CreateInvoices"
            Me.ButtonItemVendorInvoices_CreateInvoices.RibbonWordWrap = False
            Me.ButtonItemVendorInvoices_CreateInvoices.SecurityEnabled = True
            Me.ButtonItemVendorInvoices_CreateInvoices.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemVendorInvoices_OneInvoicePerOrderLine, Me.ButtonItemVendorInvoices_OneInvoicePerVendor})
            Me.ButtonItemVendorInvoices_CreateInvoices.SubItemsExpandWidth = 14
            Me.ButtonItemVendorInvoices_CreateInvoices.Text = "Create Invoices"
            '
            'ButtonItemVendorInvoices_OneInvoicePerOrderLine
            '
            Me.ButtonItemVendorInvoices_OneInvoicePerOrderLine.Name = "ButtonItemVendorInvoices_OneInvoicePerOrderLine"
            Me.ButtonItemVendorInvoices_OneInvoicePerOrderLine.Text = "One Invoice per Order/Line"
            '
            'ButtonItemVendorInvoices_OneInvoicePerVendor
            '
            Me.ButtonItemVendorInvoices_OneInvoicePerVendor.Name = "ButtonItemVendorInvoices_OneInvoicePerVendor"
            Me.ButtonItemVendorInvoices_OneInvoicePerVendor.Text = "One Invoice per Vendor"
            '
            'ButtonItemVendorInvoices_ImportInvoices
            '
            Me.ButtonItemVendorInvoices_ImportInvoices.BeginGroup = True
            Me.ButtonItemVendorInvoices_ImportInvoices.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemVendorInvoices_ImportInvoices.Name = "ButtonItemVendorInvoices_ImportInvoices"
            Me.ButtonItemVendorInvoices_ImportInvoices.RibbonWordWrap = False
            Me.ButtonItemVendorInvoices_ImportInvoices.SecurityEnabled = True
            Me.ButtonItemVendorInvoices_ImportInvoices.SubItemsExpandWidth = 14
            Me.ButtonItemVendorInvoices_ImportInvoices.Text = "Import Invoices"
            '
            'ButtonItemVendorInvoices_ApproveInvoices
            '
            Me.ButtonItemVendorInvoices_ApproveInvoices.BeginGroup = True
            Me.ButtonItemVendorInvoices_ApproveInvoices.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemVendorInvoices_ApproveInvoices.Name = "ButtonItemVendorInvoices_ApproveInvoices"
            Me.ButtonItemVendorInvoices_ApproveInvoices.RibbonWordWrap = False
            Me.ButtonItemVendorInvoices_ApproveInvoices.SecurityEnabled = True
            Me.ButtonItemVendorInvoices_ApproveInvoices.SubItemsExpandWidth = 14
            Me.ButtonItemVendorInvoices_ApproveInvoices.Text = "Approve Invoices"
            '
            'RibbonBarOptions_VendorPayments
            '
            Me.RibbonBarOptions_VendorPayments.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarOptions_VendorPayments.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_VendorPayments.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_VendorPayments.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_VendorPayments.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_VendorPayments.DragDropSupport = True
            Me.RibbonBarOptions_VendorPayments.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemVendorPayments_ManageVCC, Me.ButtonItemVendorPayments_CreateVCC})
            Me.RibbonBarOptions_VendorPayments.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_VendorPayments.Location = New System.Drawing.Point(774, 0)
            Me.RibbonBarOptions_VendorPayments.Name = "RibbonBarOptions_VendorPayments"
            Me.RibbonBarOptions_VendorPayments.SecurityEnabled = True
            Me.RibbonBarOptions_VendorPayments.Size = New System.Drawing.Size(77, 92)
            Me.RibbonBarOptions_VendorPayments.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_VendorPayments.TabIndex = 21
            Me.RibbonBarOptions_VendorPayments.Text = "Vendor Payments"
            '
            '
            '
            Me.RibbonBarOptions_VendorPayments.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_VendorPayments.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_VendorPayments.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemVendorPayments_ManageVCC
            '
            Me.ButtonItemVendorPayments_ManageVCC.BeginGroup = True
            Me.ButtonItemVendorPayments_ManageVCC.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemVendorPayments_ManageVCC.Name = "ButtonItemVendorPayments_ManageVCC"
            Me.ButtonItemVendorPayments_ManageVCC.RibbonWordWrap = False
            Me.ButtonItemVendorPayments_ManageVCC.SecurityEnabled = True
            Me.ButtonItemVendorPayments_ManageVCC.SubItemsExpandWidth = 14
            Me.ButtonItemVendorPayments_ManageVCC.Text = "Manage VCC"
            '
            'ButtonItemVendorPayments_CreateVCC
            '
            Me.ButtonItemVendorPayments_CreateVCC.BeginGroup = True
            Me.ButtonItemVendorPayments_CreateVCC.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemVendorPayments_CreateVCC.Name = "ButtonItemVendorPayments_CreateVCC"
            Me.ButtonItemVendorPayments_CreateVCC.RibbonWordWrap = False
            Me.ButtonItemVendorPayments_CreateVCC.SecurityEnabled = True
            Me.ButtonItemVendorPayments_CreateVCC.SubItemsExpandWidth = 14
            Me.ButtonItemVendorPayments_CreateVCC.Text = "Create VCC"
            '
            'RibbonBarOptions_MediaPlan
            '
            Me.RibbonBarOptions_MediaPlan.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_MediaPlan.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_MediaPlan.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_MediaPlan.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_MediaPlan.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_MediaPlan.DragDropSupport = True
            Me.RibbonBarOptions_MediaPlan.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemMediaPlan_Actualize})
            Me.RibbonBarOptions_MediaPlan.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_MediaPlan.Location = New System.Drawing.Point(1783, 0)
            Me.RibbonBarOptions_MediaPlan.Name = "RibbonBarOptions_MediaPlan"
            Me.RibbonBarOptions_MediaPlan.SecurityEnabled = True
            Me.RibbonBarOptions_MediaPlan.Size = New System.Drawing.Size(130, 92)
            Me.RibbonBarOptions_MediaPlan.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_MediaPlan.TabIndex = 28
            Me.RibbonBarOptions_MediaPlan.Text = "Media Plan"
            '
            '
            '
            Me.RibbonBarOptions_MediaPlan.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_MediaPlan.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_MediaPlan.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemMediaPlan_Actualize
            '
            Me.ButtonItemMediaPlan_Actualize.BeginGroup = True
            Me.ButtonItemMediaPlan_Actualize.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemMediaPlan_Actualize.Name = "ButtonItemMediaPlan_Actualize"
            Me.ButtonItemMediaPlan_Actualize.RibbonWordWrap = False
            Me.ButtonItemMediaPlan_Actualize.SecurityEnabled = True
            Me.ButtonItemMediaPlan_Actualize.SubItemsExpandWidth = 14
            Me.ButtonItemMediaPlan_Actualize.Text = "Actualize"
            '
            'MediaManagerReviewDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(992, 730)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaManagerReviewDialog"
            Me.Text = "Media Manager Review"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.TabControlForm_ReviewItems, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_ReviewItems.ResumeLayout(False)
            Me.TabControlPanelDetailsTab_VCCDetails.ResumeLayout(False)
            CType(Me.PanelVCCDetails_Bottom, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelVCCDetails_Bottom.ResumeLayout(False)
            CType(Me.TabControlVCCDetails_Details, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlVCCDetails_Details.ResumeLayout(False)
            Me.TabControlPanelVCCDetailsTab_VCCDetails.ResumeLayout(False)
            Me.TabControlPanelOrderInfoTab_OrderInfo.ResumeLayout(False)
            CType(Me.PanelVCCDetails_Top, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelVCCDetails_Top.ResumeLayout(False)
            Me.TabControlPanelDetailsTab_OrderDetails.ResumeLayout(False)
            Me.TabControlPanelPurchaseOrderStatusHistoryTab_PurchaseOrderStatusHistory.ResumeLayout(False)
            Me.TabControlPanelOrderStatusHistoryTab_OrderStatusHistory.ResumeLayout(False)
            Me.TabControlPanelPODetails_PODetails.ResumeLayout(False)
            Me.TabControlPanelVendorRepsTab_VendorReps.ResumeLayout(False)
            Me.TabControlPanelBillingInvoicesTab_BillingInvoices.ResumeLayout(False)
            Me.TabControlPanelAPInvoicesPostedTab_APInvoicesPosted.ResumeLayout(False)
            Me.TabControlPanelPaymentDetailsTab_VendorCollectedDetails.ResumeLayout(False)
            Me.TabControlPanelLineCommentsTab_LineComments.ResumeLayout(False)
            Me.TabControlPanelDocumentsTab_Documents.ResumeLayout(False)
            Me.TabControlPanelOrderCommentsTab_OrderComments.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarOptions_GridOptionsOrderDetails As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemGridOptionsOrderDetails_ChooseColumns As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemGridOptionsOrderDetails_RestoreDefaults As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Export As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents TabControlForm_ReviewItems As WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelDocumentsTab_Documents As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DocumentManagerControlDocuments_Documents As WinForm.Presentation.Controls.DocumentManagerControl
        Friend WithEvents TabItemReviewItems_Documents As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelDetailsTab_OrderDetails As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemReviewItems_OrderDetails As DevComponents.DotNetBar.TabItem
        Friend WithEvents RibbonBarOptions_Documents As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemDocuments_Download As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDocuments_OpenURL As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDocuments_UploadJob As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents TabControlPanelOrderStatusHistoryTab_OrderStatusHistory As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemReviewItems_OrderStatus As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelVendorRepsTab_VendorReps As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemReviewItems_VendorReps As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelPaymentDetailsTab_VendorCollectedDetails As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemReviewItems_VendorCollectedDetails As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelAPInvoicesPostedTab_APInvoicesPosted As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemReviewItems_APInvoiceDetail As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelLineCommentsTab_LineComments As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemReviewItems_LineComments As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelOrderCommentsTab_OrderComments As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemReviewItems_OrderComments As DevComponents.DotNetBar.TabItem
        Friend WithEvents DataGridViewOrderDetails_OrderDetails As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewLineComments_LineComments As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewOrderComments_OrderComments As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewVendorReps_VendorReps As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewVendorCollectedDetails_VendorCollectedDetails As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonItemActions_Save As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Cancel As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents TabControlPanelBillingInvoicesTab_BillingInvoices As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemReviewItems_BillingInvoices As DevComponents.DotNetBar.TabItem
        Friend WithEvents RibbonBarOptions_Filter As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemFilter_All As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemFilter_SelectedLineItem As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents MediaBillingHistoryControlBillingInvoices_BillingInvoices As WinForm.Presentation.Controls.MediaBillingHistoryControl
        Friend WithEvents ButtonItemDocuments_UploadJobComponent As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDocuments_UploadCampaign As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_BillingApproval As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemBillingApproval_Approve As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemBillingApproval_Unapprove As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents DataGridViewOrderStatus_OrderStatus As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonItemActions_Refresh As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_VendorReps As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemVendorReps_Add As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemVendorReps_Edit As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemVendorReps_Delete As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDocuments_Upload As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_SendReminders As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents TabControlPanelDetailsTab_VCCDetails As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemReviewItems_VCCDetails As DevComponents.DotNetBar.TabItem
        Protected Friend WithEvents PanelVCCDetails_Top As WinForm.Presentation.Controls.Panel
        Friend WithEvents ExpandableSplitterVCCDetails_TopBottom As WinForm.Presentation.Controls.ExpandableSplitterControl
        Protected Friend WithEvents PanelVCCDetails_Bottom As WinForm.Presentation.Controls.Panel
        Friend WithEvents TabControlVCCDetails_Details As WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelVCCDetailsTab_VCCDetails As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewBottomVCCDetails_CardDetails As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TabItemVCCDetails_VCCDetailsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelOrderInfoTab_OrderInfo As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemVCCDetails_NotesTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents RibbonBarOptions_Vendor As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemVendor_Edit As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_GridOptionsVCCDetails As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemGridOptionsVCCDetails_ChooseColumns As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemGridOptionsVCCDetails_RestoreDefaults As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents DataGridViewBottomVCCDetails_CardNotes As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewTopVCCDetails_VCCOrders As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonItemSummaryResults_TransactionsOutOfBalance As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ItemContainerSummaryResults_Splitter2 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemSummaryResults_TransactionsInBalance As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ItemContainerSummaryResults_Center As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ItemContainerSummaryResults_Splitter1 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemSummaryResults_TransactionsDeclined As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemSummaryResults_VCCIssuedAndUpdated As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ItemContainerSummaryResults_Far As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents RibbonBarOptions_SummaryResults As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_AutoFill As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemSummaryResults_NoTransactions As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_FollowUp As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemSummaryResults_Followup As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ApInvoiceControlAPInvoiceDetail_APInvoiceDetail As WinForm.Presentation.Controls.APInvoiceControl
        Friend WithEvents ButtonItemUploadJob_EmailLink As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemUploadJobComponent_EmailLink As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemUploadCampaign_EmailLink As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemUpload_EmailLink As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemDocuments_UploadOrder As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemUploadOrder_EmailLink As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_Orders As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemOrders_GenerateOrders As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemOrders_CreateRevision As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemOrders_UpdateCost As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemOrders_UpdateCostToActual As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemOrders_UpdateCostToVendorCollected As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemOrders_WriteUpDown As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemOrders_ProcessControl As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_VendorInvoices As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemVendorInvoices_ApproveInvoices As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemVendorInvoices_ImportInvoices As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_VendorPayments As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemVendorPayments_CreateVCC As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemVendorInvoices_CreateInvoices As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemVendorInvoices_OneInvoicePerOrderLine As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemVendorInvoices_OneInvoicePerVendor As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemVendorPayments_ManageVCC As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemOrders_AdServing As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemAdServing_DoubleClick As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents TabControlPanelPODetails_PODetails As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewPODetails_PODetails As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TabItemReviewItems_PurchaseOrderDetails As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelPurchaseOrderStatusHistoryTab_PurchaseOrderStatusHistory As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewPOStatus_POStatus As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TabItemReviewItems_PurchaseOrderStatus As DevComponents.DotNetBar.TabItem
        Friend WithEvents ButtonItemActions_ExportGrid As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_ExportXML As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_ExportXMLAsNew As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_MediaPlan As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemMediaPlan_Actualize As WinForm.Presentation.Controls.ButtonItem
    End Class

End Namespace
