Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaManagerApproveInvoicesDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaManagerApproveInvoicesDialog))
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_GoToOrder = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_ApprovalStatus = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ComboBoxApprovalStatus_Status = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ItemContainerVertical_MediaStatus = New DevComponents.DotNetBar.ItemContainer()
            Me.ControlContainerItemMediaStatus_JobProcess = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ButtonItemMediaStatus_MarkSelected = New DevComponents.DotNetBar.ButtonItem()
            Me.TabControlPanel_InvoiceItems = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelAPInvoiceDetailTab_APInvoiceDetails = New DevComponents.DotNetBar.TabControlPanel()
            Me.ApInvoiceControlAPInvoiceDetail_APInvoiceDetail = New AdvantageFramework.WinForm.Presentation.Controls.APInvoiceControl()
            Me.TabItemAPInvoiceDetail_APInvoiceDetail = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelInvoiceDetailTab_InvoiceDetails = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelInvoicesBottom = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewInvoiceDetails_InvoiceDetails = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterControlInvoices_TopBottom = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelInvoicesTop = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewInvoices_Orders = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemInvoiceItems_InvoiceDetail = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelInvoiceDetailMatchingTab_InvoiceDetailMatching = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelInvoiceDetailMatching_Bottom = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewInvoiceDetailMatching_InvoiceDetails = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterControlBroadcastDetailVerification_TopBottom = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelInvoiceDetailMatching_Top = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewInvoiceDetailMatching_OrderLines = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemInvoiceItems_InvoiceDetailMatching = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.RibbonBarOptions_Documents = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemDocuments_Upload = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemUpload_EmailLink = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemDocuments_Download = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDocuments_OpenURL = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Filter = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemFilter_HasVariance = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemFilter_Unapproved = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_InvoiceDetail = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemInvoiceDetail_ShowAll = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemInvoiceDetail_ShowWeeks = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemInvoiceDetail_Approve = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemInvoiceDetail_Unapprove = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemInvoiceDetail_AutoFill = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_View = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemView_ShowNet = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemView_ShowGross = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemView_ShowBoth = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_RatingsImps = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainerRatings = New DevComponents.DotNetBar.ItemContainer()
            Me.ItemContainerShowGrpsImps = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemInvoiceDetail_ShowGRPs = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemInvoiceDetail_ShowIMPs = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ItemContainerRatingsDemo = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemRatingsSource = New DevComponents.DotNetBar.LabelItem()
            Me.LabelItemDemographic = New DevComponents.DotNetBar.LabelItem()
            Me.RibbonBarOptions_Amounts = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainerAmounts_Vertical = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemOrderedAmount = New DevComponents.DotNetBar.LabelItem()
            Me.LabelItemOrderedNetAmount = New DevComponents.DotNetBar.LabelItem()
            Me.LabelItemOrderedSpots = New DevComponents.DotNetBar.LabelItem()
            Me.RibbonBarOptions_Spots = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainerSpots_Vertical = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemInvoicedAmount = New DevComponents.DotNetBar.LabelItem()
            Me.LabelItemInvoicedNetAmount = New DevComponents.DotNetBar.LabelItem()
            Me.LabelItemInvoicedSpots = New DevComponents.DotNetBar.LabelItem()
            Me.RibbonBarOptions_SpotDetail = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemSpotDetail_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemSpotDetail_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemInvoiceDetail_Rematch = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.RibbonBarOptions_ApprovalStatus.SuspendLayout()
            CType(Me.TabControlPanel_InvoiceItems, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanel_InvoiceItems.SuspendLayout()
            Me.TabControlPanelAPInvoiceDetailTab_APInvoiceDetails.SuspendLayout()
            Me.TabControlPanelInvoiceDetailTab_InvoiceDetails.SuspendLayout()
            CType(Me.PanelInvoicesBottom, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelInvoicesBottom.SuspendLayout()
            CType(Me.PanelInvoicesTop, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelInvoicesTop.SuspendLayout()
            Me.TabControlPanelInvoiceDetailMatchingTab_InvoiceDetailMatching.SuspendLayout()
            CType(Me.PanelInvoiceDetailMatching_Bottom, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelInvoiceDetailMatching_Bottom.SuspendLayout()
            CType(Me.PanelInvoiceDetailMatching_Top, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelInvoiceDetailMatching_Top.SuspendLayout()
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
            Me.PanelForm_Form.Controls.Add(Me.TabControlPanel_InvoiceItems)
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
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Spots)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Amounts)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_RatingsImps)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_InvoiceDetail)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Documents)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_ApprovalStatus)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Filter)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_View)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_SpotDetail)
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
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_SpotDetail, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_View, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Filter, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_ApprovalStatus, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Documents, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_InvoiceDetail, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_RatingsImps, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Amounts, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Spots, 0)
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
            'Office2007StartButtonMainRibbon_Home
            '
            Me.Office2007StartButtonMainRibbon_Home.ImagePaddingVertical = 0
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Save, Me.ButtonItemActions_Cancel, Me.ButtonItemActions_GoToOrder})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(55, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(52, 92)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 12
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
            'ButtonItemActions_GoToOrder
            '
            Me.ButtonItemActions_GoToOrder.BeginGroup = True
            Me.ButtonItemActions_GoToOrder.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_GoToOrder.Name = "ButtonItemActions_GoToOrder"
            Me.ButtonItemActions_GoToOrder.RibbonWordWrap = False
            Me.ButtonItemActions_GoToOrder.SecurityEnabled = True
            Me.ButtonItemActions_GoToOrder.SubItemsExpandWidth = 14
            Me.ButtonItemActions_GoToOrder.Text = "Go to Order"
            '
            'RibbonBarOptions_ApprovalStatus
            '
            Me.RibbonBarOptions_ApprovalStatus.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_ApprovalStatus.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ApprovalStatus.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ApprovalStatus.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_ApprovalStatus.Controls.Add(Me.ComboBoxApprovalStatus_Status)
            Me.RibbonBarOptions_ApprovalStatus.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_ApprovalStatus.DragDropSupport = True
            Me.RibbonBarOptions_ApprovalStatus.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerVertical_MediaStatus})
            Me.RibbonBarOptions_ApprovalStatus.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_ApprovalStatus.Location = New System.Drawing.Point(302, 0)
            Me.RibbonBarOptions_ApprovalStatus.Name = "RibbonBarOptions_ApprovalStatus"
            Me.RibbonBarOptions_ApprovalStatus.SecurityEnabled = True
            Me.RibbonBarOptions_ApprovalStatus.Size = New System.Drawing.Size(152, 92)
            Me.RibbonBarOptions_ApprovalStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_ApprovalStatus.TabIndex = 15
            Me.RibbonBarOptions_ApprovalStatus.Text = "Approval Status"
            '
            '
            '
            Me.RibbonBarOptions_ApprovalStatus.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ApprovalStatus.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ApprovalStatus.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ComboBoxApprovalStatus_Status
            '
            Me.ComboBoxApprovalStatus_Status.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxApprovalStatus_Status.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxApprovalStatus_Status.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxApprovalStatus_Status.AutoFindItemInDataSource = False
            Me.ComboBoxApprovalStatus_Status.AutoSelectSingleItemDatasource = False
            Me.ComboBoxApprovalStatus_Status.BookmarkingEnabled = False
            Me.ComboBoxApprovalStatus_Status.ClientCode = ""
            Me.ComboBoxApprovalStatus_Status.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumDataTable
            Me.ComboBoxApprovalStatus_Status.DisableMouseWheel = False
            Me.ComboBoxApprovalStatus_Status.DisplayMember = "Name"
            Me.ComboBoxApprovalStatus_Status.DisplayName = "Approval Status"
            Me.ComboBoxApprovalStatus_Status.DivisionCode = ""
            Me.ComboBoxApprovalStatus_Status.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxApprovalStatus_Status.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxApprovalStatus_Status.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.None
            Me.ComboBoxApprovalStatus_Status.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxApprovalStatus_Status.FocusHighlightEnabled = True
            Me.ComboBoxApprovalStatus_Status.FormattingEnabled = True
            Me.ComboBoxApprovalStatus_Status.ItemHeight = 15
            Me.ComboBoxApprovalStatus_Status.Location = New System.Drawing.Point(6, 4)
            Me.ComboBoxApprovalStatus_Status.Name = "ComboBoxApprovalStatus_Status"
            Me.ComboBoxApprovalStatus_Status.ReadOnly = False
            Me.ComboBoxApprovalStatus_Status.SecurityEnabled = True
            Me.ComboBoxApprovalStatus_Status.Size = New System.Drawing.Size(133, 21)
            Me.ComboBoxApprovalStatus_Status.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxApprovalStatus_Status.TabIndex = 7
            Me.ComboBoxApprovalStatus_Status.TabOnEnter = True
            Me.ComboBoxApprovalStatus_Status.ValueMember = "Value"
            Me.ComboBoxApprovalStatus_Status.WatermarkText = "Select"
            '
            'ItemContainerVertical_MediaStatus
            '
            '
            '
            '
            Me.ItemContainerVertical_MediaStatus.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerVertical_MediaStatus.BeginGroup = True
            Me.ItemContainerVertical_MediaStatus.FixedSize = New System.Drawing.Size(140, 0)
            Me.ItemContainerVertical_MediaStatus.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerVertical_MediaStatus.Name = "ItemContainerVertical_MediaStatus"
            Me.ItemContainerVertical_MediaStatus.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ControlContainerItemMediaStatus_JobProcess, Me.ButtonItemMediaStatus_MarkSelected})
            '
            '
            '
            Me.ItemContainerVertical_MediaStatus.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerVertical_MediaStatus.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ControlContainerItemMediaStatus_JobProcess
            '
            Me.ControlContainerItemMediaStatus_JobProcess.AllowItemResize = True
            Me.ControlContainerItemMediaStatus_JobProcess.BeginGroup = True
            Me.ControlContainerItemMediaStatus_JobProcess.Control = Me.ComboBoxApprovalStatus_Status
            Me.ControlContainerItemMediaStatus_JobProcess.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center
            Me.ControlContainerItemMediaStatus_JobProcess.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItemMediaStatus_JobProcess.Name = "ControlContainerItemMediaStatus_JobProcess"
            '
            'ButtonItemMediaStatus_MarkSelected
            '
            Me.ButtonItemMediaStatus_MarkSelected.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center
            Me.ButtonItemMediaStatus_MarkSelected.Name = "ButtonItemMediaStatus_MarkSelected"
            Me.ButtonItemMediaStatus_MarkSelected.Text = "Mark Selected"
            '
            'TabControlPanel_InvoiceItems
            '
            Me.TabControlPanel_InvoiceItems.BackColor = System.Drawing.Color.White
            Me.TabControlPanel_InvoiceItems.CanReorderTabs = False
            Me.TabControlPanel_InvoiceItems.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlPanel_InvoiceItems.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlPanel_InvoiceItems.Controls.Add(Me.TabControlPanelInvoiceDetailTab_InvoiceDetails)
            Me.TabControlPanel_InvoiceItems.Controls.Add(Me.TabControlPanelAPInvoiceDetailTab_APInvoiceDetails)
            Me.TabControlPanel_InvoiceItems.Controls.Add(Me.TabControlPanelInvoiceDetailMatchingTab_InvoiceDetailMatching)
            Me.TabControlPanel_InvoiceItems.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanel_InvoiceItems.ForeColor = System.Drawing.Color.Black
            Me.TabControlPanel_InvoiceItems.Location = New System.Drawing.Point(0, 0)
            Me.TabControlPanel_InvoiceItems.Name = "TabControlPanel_InvoiceItems"
            Me.TabControlPanel_InvoiceItems.SelectedTabFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlPanel_InvoiceItems.SelectedTabIndex = 0
            Me.TabControlPanel_InvoiceItems.Size = New System.Drawing.Size(982, 555)
            Me.TabControlPanel_InvoiceItems.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlPanel_InvoiceItems.TabIndex = 13
            Me.TabControlPanel_InvoiceItems.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlPanel_InvoiceItems.Tabs.Add(Me.TabItemInvoiceItems_InvoiceDetail)
            Me.TabControlPanel_InvoiceItems.Tabs.Add(Me.TabItemAPInvoiceDetail_APInvoiceDetail)
            Me.TabControlPanel_InvoiceItems.Tabs.Add(Me.TabItemInvoiceItems_InvoiceDetailMatching)
            '
            'TabControlPanelAPInvoiceDetailTab_APInvoiceDetails
            '
            Me.TabControlPanelAPInvoiceDetailTab_APInvoiceDetails.Controls.Add(Me.ApInvoiceControlAPInvoiceDetail_APInvoiceDetail)
            Me.TabControlPanelAPInvoiceDetailTab_APInvoiceDetails.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelAPInvoiceDetailTab_APInvoiceDetails.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelAPInvoiceDetailTab_APInvoiceDetails.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelAPInvoiceDetailTab_APInvoiceDetails.Name = "TabControlPanelAPInvoiceDetailTab_APInvoiceDetails"
            Me.TabControlPanelAPInvoiceDetailTab_APInvoiceDetails.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelAPInvoiceDetailTab_APInvoiceDetails.Size = New System.Drawing.Size(982, 528)
            Me.TabControlPanelAPInvoiceDetailTab_APInvoiceDetails.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelAPInvoiceDetailTab_APInvoiceDetails.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelAPInvoiceDetailTab_APInvoiceDetails.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelAPInvoiceDetailTab_APInvoiceDetails.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelAPInvoiceDetailTab_APInvoiceDetails.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelAPInvoiceDetailTab_APInvoiceDetails.Style.GradientAngle = 90
            Me.TabControlPanelAPInvoiceDetailTab_APInvoiceDetails.TabIndex = 9
            Me.TabControlPanelAPInvoiceDetailTab_APInvoiceDetails.TabItem = Me.TabItemAPInvoiceDetail_APInvoiceDetail
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
            'TabItemAPInvoiceDetail_APInvoiceDetail
            '
            Me.TabItemAPInvoiceDetail_APInvoiceDetail.AttachedControl = Me.TabControlPanelAPInvoiceDetailTab_APInvoiceDetails
            Me.TabItemAPInvoiceDetail_APInvoiceDetail.Name = "TabItemAPInvoiceDetail_APInvoiceDetail"
            Me.TabItemAPInvoiceDetail_APInvoiceDetail.Text = "AP Invoice Detail"
            '
            'TabControlPanelInvoiceDetailTab_InvoiceDetails
            '
            Me.TabControlPanelInvoiceDetailTab_InvoiceDetails.Controls.Add(Me.PanelInvoicesBottom)
            Me.TabControlPanelInvoiceDetailTab_InvoiceDetails.Controls.Add(Me.ExpandableSplitterControlInvoices_TopBottom)
            Me.TabControlPanelInvoiceDetailTab_InvoiceDetails.Controls.Add(Me.PanelInvoicesTop)
            Me.TabControlPanelInvoiceDetailTab_InvoiceDetails.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelInvoiceDetailTab_InvoiceDetails.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelInvoiceDetailTab_InvoiceDetails.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelInvoiceDetailTab_InvoiceDetails.Name = "TabControlPanelInvoiceDetailTab_InvoiceDetails"
            Me.TabControlPanelInvoiceDetailTab_InvoiceDetails.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelInvoiceDetailTab_InvoiceDetails.Size = New System.Drawing.Size(982, 528)
            Me.TabControlPanelInvoiceDetailTab_InvoiceDetails.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelInvoiceDetailTab_InvoiceDetails.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelInvoiceDetailTab_InvoiceDetails.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelInvoiceDetailTab_InvoiceDetails.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelInvoiceDetailTab_InvoiceDetails.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelInvoiceDetailTab_InvoiceDetails.Style.GradientAngle = 90
            Me.TabControlPanelInvoiceDetailTab_InvoiceDetails.TabIndex = 1
            Me.TabControlPanelInvoiceDetailTab_InvoiceDetails.TabItem = Me.TabItemInvoiceItems_InvoiceDetail
            '
            'PanelInvoicesBottom
            '
            Me.PanelInvoicesBottom.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelInvoicesBottom.Appearance.Options.UseBackColor = True
            Me.PanelInvoicesBottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelInvoicesBottom.Controls.Add(Me.DataGridViewInvoiceDetails_InvoiceDetails)
            Me.PanelInvoicesBottom.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelInvoicesBottom.Location = New System.Drawing.Point(1, 267)
            Me.PanelInvoicesBottom.Name = "PanelInvoicesBottom"
            Me.PanelInvoicesBottom.Size = New System.Drawing.Size(980, 260)
            Me.PanelInvoicesBottom.TabIndex = 33
            '
            'DataGridViewInvoiceDetails_InvoiceDetails
            '
            Me.DataGridViewInvoiceDetails_InvoiceDetails.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewInvoiceDetails_InvoiceDetails.AllowDragAndDrop = False
            Me.DataGridViewInvoiceDetails_InvoiceDetails.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewInvoiceDetails_InvoiceDetails.AllowSelectGroupHeaderRow = True
            Me.DataGridViewInvoiceDetails_InvoiceDetails.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewInvoiceDetails_InvoiceDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewInvoiceDetails_InvoiceDetails.AutoFilterLookupColumns = True
            Me.DataGridViewInvoiceDetails_InvoiceDetails.AutoloadRepositoryDatasource = True
            Me.DataGridViewInvoiceDetails_InvoiceDetails.AutoUpdateViewCaption = True
            Me.DataGridViewInvoiceDetails_InvoiceDetails.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewInvoiceDetails_InvoiceDetails.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewInvoiceDetails_InvoiceDetails.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewInvoiceDetails_InvoiceDetails.ItemDescription = "Invoice Detail(s)"
            Me.DataGridViewInvoiceDetails_InvoiceDetails.Location = New System.Drawing.Point(3, 3)
            Me.DataGridViewInvoiceDetails_InvoiceDetails.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewInvoiceDetails_InvoiceDetails.MultiSelect = True
            Me.DataGridViewInvoiceDetails_InvoiceDetails.Name = "DataGridViewInvoiceDetails_InvoiceDetails"
            Me.DataGridViewInvoiceDetails_InvoiceDetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewInvoiceDetails_InvoiceDetails.RunStandardValidation = True
            Me.DataGridViewInvoiceDetails_InvoiceDetails.ShowColumnMenuOnRightClick = False
            Me.DataGridViewInvoiceDetails_InvoiceDetails.ShowSelectDeselectAllButtons = False
            Me.DataGridViewInvoiceDetails_InvoiceDetails.Size = New System.Drawing.Size(974, 260)
            Me.DataGridViewInvoiceDetails_InvoiceDetails.TabIndex = 2
            Me.DataGridViewInvoiceDetails_InvoiceDetails.UseEmbeddedNavigator = False
            Me.DataGridViewInvoiceDetails_InvoiceDetails.ViewCaptionHeight = -1
            '
            'ExpandableSplitterControlInvoices_TopBottom
            '
            Me.ExpandableSplitterControlInvoices_TopBottom.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlInvoices_TopBottom.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlInvoices_TopBottom.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControlInvoices_TopBottom.Dock = System.Windows.Forms.DockStyle.Top
            Me.ExpandableSplitterControlInvoices_TopBottom.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlInvoices_TopBottom.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlInvoices_TopBottom.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlInvoices_TopBottom.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlInvoices_TopBottom.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlInvoices_TopBottom.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlInvoices_TopBottom.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlInvoices_TopBottom.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlInvoices_TopBottom.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControlInvoices_TopBottom.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControlInvoices_TopBottom.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControlInvoices_TopBottom.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControlInvoices_TopBottom.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlInvoices_TopBottom.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlInvoices_TopBottom.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlInvoices_TopBottom.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlInvoices_TopBottom.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlInvoices_TopBottom.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlInvoices_TopBottom.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlInvoices_TopBottom.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlInvoices_TopBottom.Location = New System.Drawing.Point(1, 261)
            Me.ExpandableSplitterControlInvoices_TopBottom.Name = "ExpandableSplitterControlInvoices_TopBottom"
            Me.ExpandableSplitterControlInvoices_TopBottom.Size = New System.Drawing.Size(980, 6)
            Me.ExpandableSplitterControlInvoices_TopBottom.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlInvoices_TopBottom.TabIndex = 32
            Me.ExpandableSplitterControlInvoices_TopBottom.TabStop = False
            '
            'PanelInvoicesTop
            '
            Me.PanelInvoicesTop.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelInvoicesTop.Appearance.Options.UseBackColor = True
            Me.PanelInvoicesTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelInvoicesTop.Controls.Add(Me.DataGridViewInvoices_Orders)
            Me.PanelInvoicesTop.Dock = System.Windows.Forms.DockStyle.Top
            Me.PanelInvoicesTop.Location = New System.Drawing.Point(1, 1)
            Me.PanelInvoicesTop.Name = "PanelInvoicesTop"
            Me.PanelInvoicesTop.Size = New System.Drawing.Size(980, 260)
            Me.PanelInvoicesTop.TabIndex = 31
            '
            'DataGridViewInvoices_Orders
            '
            Me.DataGridViewInvoices_Orders.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewInvoices_Orders.AllowDragAndDrop = False
            Me.DataGridViewInvoices_Orders.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewInvoices_Orders.AllowSelectGroupHeaderRow = True
            Me.DataGridViewInvoices_Orders.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewInvoices_Orders.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewInvoices_Orders.AutoFilterLookupColumns = True
            Me.DataGridViewInvoices_Orders.AutoloadRepositoryDatasource = True
            Me.DataGridViewInvoices_Orders.AutoUpdateViewCaption = True
            Me.DataGridViewInvoices_Orders.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewInvoices_Orders.DataSource = Nothing
            Me.DataGridViewInvoices_Orders.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewInvoices_Orders.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewInvoices_Orders.ItemDescription = "Order(s)"
            Me.DataGridViewInvoices_Orders.Location = New System.Drawing.Point(3, 3)
            Me.DataGridViewInvoices_Orders.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewInvoices_Orders.MultiSelect = True
            Me.DataGridViewInvoices_Orders.Name = "DataGridViewInvoices_Orders"
            Me.DataGridViewInvoices_Orders.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewInvoices_Orders.RunStandardValidation = True
            Me.DataGridViewInvoices_Orders.ShowColumnMenuOnRightClick = False
            Me.DataGridViewInvoices_Orders.ShowSelectDeselectAllButtons = False
            Me.DataGridViewInvoices_Orders.Size = New System.Drawing.Size(974, 254)
            Me.DataGridViewInvoices_Orders.TabIndex = 2
            Me.DataGridViewInvoices_Orders.UseEmbeddedNavigator = False
            Me.DataGridViewInvoices_Orders.ViewCaptionHeight = -1
            '
            'TabItemInvoiceItems_InvoiceDetail
            '
            Me.TabItemInvoiceItems_InvoiceDetail.AttachedControl = Me.TabControlPanelInvoiceDetailTab_InvoiceDetails
            Me.TabItemInvoiceItems_InvoiceDetail.Name = "TabItemInvoiceItems_InvoiceDetail"
            Me.TabItemInvoiceItems_InvoiceDetail.Text = "Invoices"
            '
            'TabControlPanelInvoiceDetailMatchingTab_InvoiceDetailMatching
            '
            Me.TabControlPanelInvoiceDetailMatchingTab_InvoiceDetailMatching.Controls.Add(Me.PanelInvoiceDetailMatching_Bottom)
            Me.TabControlPanelInvoiceDetailMatchingTab_InvoiceDetailMatching.Controls.Add(Me.ExpandableSplitterControlBroadcastDetailVerification_TopBottom)
            Me.TabControlPanelInvoiceDetailMatchingTab_InvoiceDetailMatching.Controls.Add(Me.PanelInvoiceDetailMatching_Top)
            Me.TabControlPanelInvoiceDetailMatchingTab_InvoiceDetailMatching.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelInvoiceDetailMatchingTab_InvoiceDetailMatching.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelInvoiceDetailMatchingTab_InvoiceDetailMatching.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelInvoiceDetailMatchingTab_InvoiceDetailMatching.Name = "TabControlPanelInvoiceDetailMatchingTab_InvoiceDetailMatching"
            Me.TabControlPanelInvoiceDetailMatchingTab_InvoiceDetailMatching.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelInvoiceDetailMatchingTab_InvoiceDetailMatching.Size = New System.Drawing.Size(982, 528)
            Me.TabControlPanelInvoiceDetailMatchingTab_InvoiceDetailMatching.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelInvoiceDetailMatchingTab_InvoiceDetailMatching.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelInvoiceDetailMatchingTab_InvoiceDetailMatching.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelInvoiceDetailMatchingTab_InvoiceDetailMatching.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelInvoiceDetailMatchingTab_InvoiceDetailMatching.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelInvoiceDetailMatchingTab_InvoiceDetailMatching.Style.GradientAngle = 90
            Me.TabControlPanelInvoiceDetailMatchingTab_InvoiceDetailMatching.TabIndex = 13
            Me.TabControlPanelInvoiceDetailMatchingTab_InvoiceDetailMatching.TabItem = Me.TabItemInvoiceItems_InvoiceDetailMatching
            '
            'PanelInvoiceDetailMatching_Bottom
            '
            Me.PanelInvoiceDetailMatching_Bottom.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelInvoiceDetailMatching_Bottom.Appearance.Options.UseBackColor = True
            Me.PanelInvoiceDetailMatching_Bottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelInvoiceDetailMatching_Bottom.Controls.Add(Me.DataGridViewInvoiceDetailMatching_InvoiceDetails)
            Me.PanelInvoiceDetailMatching_Bottom.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelInvoiceDetailMatching_Bottom.Location = New System.Drawing.Point(1, 267)
            Me.PanelInvoiceDetailMatching_Bottom.Name = "PanelInvoiceDetailMatching_Bottom"
            Me.PanelInvoiceDetailMatching_Bottom.Size = New System.Drawing.Size(980, 260)
            Me.PanelInvoiceDetailMatching_Bottom.TabIndex = 32
            '
            'DataGridViewInvoiceDetailMatching_InvoiceDetails
            '
            Me.DataGridViewInvoiceDetailMatching_InvoiceDetails.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewInvoiceDetailMatching_InvoiceDetails.AllowDragAndDrop = False
            Me.DataGridViewInvoiceDetailMatching_InvoiceDetails.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewInvoiceDetailMatching_InvoiceDetails.AllowSelectGroupHeaderRow = True
            Me.DataGridViewInvoiceDetailMatching_InvoiceDetails.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewInvoiceDetailMatching_InvoiceDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewInvoiceDetailMatching_InvoiceDetails.AutoFilterLookupColumns = True
            Me.DataGridViewInvoiceDetailMatching_InvoiceDetails.AutoloadRepositoryDatasource = True
            Me.DataGridViewInvoiceDetailMatching_InvoiceDetails.AutoUpdateViewCaption = True
            Me.DataGridViewInvoiceDetailMatching_InvoiceDetails.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewInvoiceDetailMatching_InvoiceDetails.DataSource = Nothing
            Me.DataGridViewInvoiceDetailMatching_InvoiceDetails.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewInvoiceDetailMatching_InvoiceDetails.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewInvoiceDetailMatching_InvoiceDetails.ItemDescription = "Order(s)"
            Me.DataGridViewInvoiceDetailMatching_InvoiceDetails.Location = New System.Drawing.Point(3, 3)
            Me.DataGridViewInvoiceDetailMatching_InvoiceDetails.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewInvoiceDetailMatching_InvoiceDetails.MultiSelect = True
            Me.DataGridViewInvoiceDetailMatching_InvoiceDetails.Name = "DataGridViewInvoiceDetailMatching_InvoiceDetails"
            Me.DataGridViewInvoiceDetailMatching_InvoiceDetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewInvoiceDetailMatching_InvoiceDetails.RunStandardValidation = True
            Me.DataGridViewInvoiceDetailMatching_InvoiceDetails.ShowColumnMenuOnRightClick = False
            Me.DataGridViewInvoiceDetailMatching_InvoiceDetails.ShowSelectDeselectAllButtons = False
            Me.DataGridViewInvoiceDetailMatching_InvoiceDetails.Size = New System.Drawing.Size(974, 260)
            Me.DataGridViewInvoiceDetailMatching_InvoiceDetails.TabIndex = 4
            Me.DataGridViewInvoiceDetailMatching_InvoiceDetails.UseEmbeddedNavigator = False
            Me.DataGridViewInvoiceDetailMatching_InvoiceDetails.ViewCaptionHeight = -1
            '
            'ExpandableSplitterControlBroadcastDetailVerification_TopBottom
            '
            Me.ExpandableSplitterControlBroadcastDetailVerification_TopBottom.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlBroadcastDetailVerification_TopBottom.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlBroadcastDetailVerification_TopBottom.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControlBroadcastDetailVerification_TopBottom.Dock = System.Windows.Forms.DockStyle.Top
            Me.ExpandableSplitterControlBroadcastDetailVerification_TopBottom.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlBroadcastDetailVerification_TopBottom.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlBroadcastDetailVerification_TopBottom.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlBroadcastDetailVerification_TopBottom.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlBroadcastDetailVerification_TopBottom.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlBroadcastDetailVerification_TopBottom.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlBroadcastDetailVerification_TopBottom.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlBroadcastDetailVerification_TopBottom.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlBroadcastDetailVerification_TopBottom.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControlBroadcastDetailVerification_TopBottom.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControlBroadcastDetailVerification_TopBottom.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControlBroadcastDetailVerification_TopBottom.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControlBroadcastDetailVerification_TopBottom.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlBroadcastDetailVerification_TopBottom.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlBroadcastDetailVerification_TopBottom.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlBroadcastDetailVerification_TopBottom.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlBroadcastDetailVerification_TopBottom.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlBroadcastDetailVerification_TopBottom.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlBroadcastDetailVerification_TopBottom.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlBroadcastDetailVerification_TopBottom.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlBroadcastDetailVerification_TopBottom.Location = New System.Drawing.Point(1, 261)
            Me.ExpandableSplitterControlBroadcastDetailVerification_TopBottom.Name = "ExpandableSplitterControlBroadcastDetailVerification_TopBottom"
            Me.ExpandableSplitterControlBroadcastDetailVerification_TopBottom.Size = New System.Drawing.Size(980, 6)
            Me.ExpandableSplitterControlBroadcastDetailVerification_TopBottom.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlBroadcastDetailVerification_TopBottom.TabIndex = 31
            Me.ExpandableSplitterControlBroadcastDetailVerification_TopBottom.TabStop = False
            '
            'PanelInvoiceDetailMatching_Top
            '
            Me.PanelInvoiceDetailMatching_Top.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelInvoiceDetailMatching_Top.Appearance.Options.UseBackColor = True
            Me.PanelInvoiceDetailMatching_Top.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelInvoiceDetailMatching_Top.Controls.Add(Me.DataGridViewInvoiceDetailMatching_OrderLines)
            Me.PanelInvoiceDetailMatching_Top.Dock = System.Windows.Forms.DockStyle.Top
            Me.PanelInvoiceDetailMatching_Top.Location = New System.Drawing.Point(1, 1)
            Me.PanelInvoiceDetailMatching_Top.Name = "PanelInvoiceDetailMatching_Top"
            Me.PanelInvoiceDetailMatching_Top.Size = New System.Drawing.Size(980, 260)
            Me.PanelInvoiceDetailMatching_Top.TabIndex = 30
            '
            'DataGridViewInvoiceDetailMatching_OrderLines
            '
            Me.DataGridViewInvoiceDetailMatching_OrderLines.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewInvoiceDetailMatching_OrderLines.AllowDragAndDrop = False
            Me.DataGridViewInvoiceDetailMatching_OrderLines.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewInvoiceDetailMatching_OrderLines.AllowSelectGroupHeaderRow = True
            Me.DataGridViewInvoiceDetailMatching_OrderLines.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewInvoiceDetailMatching_OrderLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewInvoiceDetailMatching_OrderLines.AutoFilterLookupColumns = True
            Me.DataGridViewInvoiceDetailMatching_OrderLines.AutoloadRepositoryDatasource = True
            Me.DataGridViewInvoiceDetailMatching_OrderLines.AutoUpdateViewCaption = True
            Me.DataGridViewInvoiceDetailMatching_OrderLines.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewInvoiceDetailMatching_OrderLines.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewInvoiceDetailMatching_OrderLines.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewInvoiceDetailMatching_OrderLines.ItemDescription = "Order(s)"
            Me.DataGridViewInvoiceDetailMatching_OrderLines.Location = New System.Drawing.Point(3, 3)
            Me.DataGridViewInvoiceDetailMatching_OrderLines.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewInvoiceDetailMatching_OrderLines.MultiSelect = True
            Me.DataGridViewInvoiceDetailMatching_OrderLines.Name = "DataGridViewInvoiceDetailMatching_OrderLines"
            Me.DataGridViewInvoiceDetailMatching_OrderLines.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewInvoiceDetailMatching_OrderLines.RunStandardValidation = True
            Me.DataGridViewInvoiceDetailMatching_OrderLines.ShowColumnMenuOnRightClick = False
            Me.DataGridViewInvoiceDetailMatching_OrderLines.ShowSelectDeselectAllButtons = False
            Me.DataGridViewInvoiceDetailMatching_OrderLines.Size = New System.Drawing.Size(974, 254)
            Me.DataGridViewInvoiceDetailMatching_OrderLines.TabIndex = 3
            Me.DataGridViewInvoiceDetailMatching_OrderLines.UseEmbeddedNavigator = False
            Me.DataGridViewInvoiceDetailMatching_OrderLines.ViewCaptionHeight = -1
            '
            'TabItemInvoiceItems_InvoiceDetailMatching
            '
            Me.TabItemInvoiceItems_InvoiceDetailMatching.AttachedControl = Me.TabControlPanelInvoiceDetailMatchingTab_InvoiceDetailMatching
            Me.TabItemInvoiceItems_InvoiceDetailMatching.Name = "TabItemInvoiceItems_InvoiceDetailMatching"
            Me.TabItemInvoiceItems_InvoiceDetailMatching.Text = "Invoice Detail Matching"
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
            Me.RibbonBarOptions_Documents.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDocuments_Upload, Me.ButtonItemDocuments_Download, Me.ButtonItemDocuments_OpenURL})
            Me.RibbonBarOptions_Documents.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Documents.Location = New System.Drawing.Point(454, 0)
            Me.RibbonBarOptions_Documents.Name = "RibbonBarOptions_Documents"
            Me.RibbonBarOptions_Documents.SecurityEnabled = True
            Me.RibbonBarOptions_Documents.Size = New System.Drawing.Size(53, 92)
            Me.RibbonBarOptions_Documents.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Documents.TabIndex = 21
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
            Me.RibbonBarOptions_Filter.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemFilter_HasVariance, Me.ButtonItemFilter_Unapproved})
            Me.RibbonBarOptions_Filter.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Filter.Location = New System.Drawing.Point(213, 0)
            Me.RibbonBarOptions_Filter.Name = "RibbonBarOptions_Filter"
            Me.RibbonBarOptions_Filter.SecurityEnabled = True
            Me.RibbonBarOptions_Filter.Size = New System.Drawing.Size(89, 92)
            Me.RibbonBarOptions_Filter.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Filter.TabIndex = 22
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
            '
            'ButtonItemFilter_HasVariance
            '
            Me.ButtonItemFilter_HasVariance.AutoCheckOnClick = True
            Me.ButtonItemFilter_HasVariance.BeginGroup = True
            Me.ButtonItemFilter_HasVariance.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemFilter_HasVariance.Name = "ButtonItemFilter_HasVariance"
            Me.ButtonItemFilter_HasVariance.RibbonWordWrap = False
            Me.ButtonItemFilter_HasVariance.SecurityEnabled = True
            Me.ButtonItemFilter_HasVariance.SubItemsExpandWidth = 14
            Me.ButtonItemFilter_HasVariance.Text = "Has Variance"
            '
            'ButtonItemFilter_Unapproved
            '
            Me.ButtonItemFilter_Unapproved.AutoCheckOnClick = True
            Me.ButtonItemFilter_Unapproved.BeginGroup = True
            Me.ButtonItemFilter_Unapproved.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemFilter_Unapproved.Name = "ButtonItemFilter_Unapproved"
            Me.ButtonItemFilter_Unapproved.RibbonWordWrap = False
            Me.ButtonItemFilter_Unapproved.SecurityEnabled = True
            Me.ButtonItemFilter_Unapproved.SubItemsExpandWidth = 14
            Me.ButtonItemFilter_Unapproved.Text = "Unapproved"
            '
            'RibbonBarOptions_InvoiceDetail
            '
            Me.RibbonBarOptions_InvoiceDetail.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_InvoiceDetail.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_InvoiceDetail.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_InvoiceDetail.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_InvoiceDetail.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_InvoiceDetail.DragDropSupport = True
            Me.RibbonBarOptions_InvoiceDetail.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemInvoiceDetail_ShowAll, Me.ButtonItemInvoiceDetail_ShowWeeks, Me.ButtonItemInvoiceDetail_Approve, Me.ButtonItemInvoiceDetail_Unapprove, Me.ButtonItemInvoiceDetail_AutoFill, Me.ButtonItemInvoiceDetail_Rematch})
            Me.RibbonBarOptions_InvoiceDetail.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_InvoiceDetail.Location = New System.Drawing.Point(507, 0)
            Me.RibbonBarOptions_InvoiceDetail.Name = "RibbonBarOptions_InvoiceDetail"
            Me.RibbonBarOptions_InvoiceDetail.SecurityEnabled = True
            Me.RibbonBarOptions_InvoiceDetail.Size = New System.Drawing.Size(116, 92)
            Me.RibbonBarOptions_InvoiceDetail.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_InvoiceDetail.TabIndex = 24
            Me.RibbonBarOptions_InvoiceDetail.Text = "Invoice Detail"
            '
            '
            '
            Me.RibbonBarOptions_InvoiceDetail.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_InvoiceDetail.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_InvoiceDetail.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemInvoiceDetail_ShowAll
            '
            Me.ButtonItemInvoiceDetail_ShowAll.AutoCheckOnClick = True
            Me.ButtonItemInvoiceDetail_ShowAll.BeginGroup = True
            Me.ButtonItemInvoiceDetail_ShowAll.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemInvoiceDetail_ShowAll.Name = "ButtonItemInvoiceDetail_ShowAll"
            Me.ButtonItemInvoiceDetail_ShowAll.RibbonWordWrap = False
            Me.ButtonItemInvoiceDetail_ShowAll.SecurityEnabled = True
            Me.ButtonItemInvoiceDetail_ShowAll.SubItemsExpandWidth = 14
            Me.ButtonItemInvoiceDetail_ShowAll.Text = "Show All"
            '
            'ButtonItemInvoiceDetail_ShowWeeks
            '
            Me.ButtonItemInvoiceDetail_ShowWeeks.AutoCheckOnClick = True
            Me.ButtonItemInvoiceDetail_ShowWeeks.BeginGroup = True
            Me.ButtonItemInvoiceDetail_ShowWeeks.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemInvoiceDetail_ShowWeeks.Name = "ButtonItemInvoiceDetail_ShowWeeks"
            Me.ButtonItemInvoiceDetail_ShowWeeks.RibbonWordWrap = False
            Me.ButtonItemInvoiceDetail_ShowWeeks.SecurityEnabled = True
            Me.ButtonItemInvoiceDetail_ShowWeeks.SubItemsExpandWidth = 14
            Me.ButtonItemInvoiceDetail_ShowWeeks.Text = "Show Weeks"
            '
            'ButtonItemInvoiceDetail_Approve
            '
            Me.ButtonItemInvoiceDetail_Approve.BeginGroup = True
            Me.ButtonItemInvoiceDetail_Approve.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemInvoiceDetail_Approve.Name = "ButtonItemInvoiceDetail_Approve"
            Me.ButtonItemInvoiceDetail_Approve.RibbonWordWrap = False
            Me.ButtonItemInvoiceDetail_Approve.SecurityEnabled = True
            Me.ButtonItemInvoiceDetail_Approve.SubItemsExpandWidth = 14
            Me.ButtonItemInvoiceDetail_Approve.Text = "Approve"
            '
            'ButtonItemInvoiceDetail_Unapprove
            '
            Me.ButtonItemInvoiceDetail_Unapprove.BeginGroup = True
            Me.ButtonItemInvoiceDetail_Unapprove.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemInvoiceDetail_Unapprove.Name = "ButtonItemInvoiceDetail_Unapprove"
            Me.ButtonItemInvoiceDetail_Unapprove.RibbonWordWrap = False
            Me.ButtonItemInvoiceDetail_Unapprove.SecurityEnabled = True
            Me.ButtonItemInvoiceDetail_Unapprove.SubItemsExpandWidth = 14
            Me.ButtonItemInvoiceDetail_Unapprove.Text = "Unapprove"
            '
            'ButtonItemInvoiceDetail_AutoFill
            '
            Me.ButtonItemInvoiceDetail_AutoFill.BeginGroup = True
            Me.ButtonItemInvoiceDetail_AutoFill.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemInvoiceDetail_AutoFill.Name = "ButtonItemInvoiceDetail_AutoFill"
            Me.ButtonItemInvoiceDetail_AutoFill.RibbonWordWrap = False
            Me.ButtonItemInvoiceDetail_AutoFill.SecurityEnabled = True
            Me.ButtonItemInvoiceDetail_AutoFill.SubItemsExpandWidth = 14
            Me.ButtonItemInvoiceDetail_AutoFill.Text = "Auto Fill"
            '
            'RibbonBarOptions_View
            '
            Me.RibbonBarOptions_View.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_View.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_View.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_View.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_View.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_View.DragDropSupport = True
            Me.RibbonBarOptions_View.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemView_ShowNet, Me.ButtonItemView_ShowGross, Me.ButtonItemView_ShowBoth})
            Me.RibbonBarOptions_View.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_View.Location = New System.Drawing.Point(153, 0)
            Me.RibbonBarOptions_View.Name = "RibbonBarOptions_View"
            Me.RibbonBarOptions_View.SecurityEnabled = True
            Me.RibbonBarOptions_View.Size = New System.Drawing.Size(60, 92)
            Me.RibbonBarOptions_View.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_View.TabIndex = 25
            Me.RibbonBarOptions_View.Text = "View"
            '
            '
            '
            Me.RibbonBarOptions_View.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_View.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_View.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemView_ShowNet
            '
            Me.ButtonItemView_ShowNet.AutoCheckOnClick = True
            Me.ButtonItemView_ShowNet.BeginGroup = True
            Me.ButtonItemView_ShowNet.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemView_ShowNet.Name = "ButtonItemView_ShowNet"
            Me.ButtonItemView_ShowNet.OptionGroup = "View"
            Me.ButtonItemView_ShowNet.RibbonWordWrap = False
            Me.ButtonItemView_ShowNet.SecurityEnabled = True
            Me.ButtonItemView_ShowNet.SubItemsExpandWidth = 14
            Me.ButtonItemView_ShowNet.Text = "Show Net"
            '
            'ButtonItemView_ShowGross
            '
            Me.ButtonItemView_ShowGross.AutoCheckOnClick = True
            Me.ButtonItemView_ShowGross.BeginGroup = True
            Me.ButtonItemView_ShowGross.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemView_ShowGross.Name = "ButtonItemView_ShowGross"
            Me.ButtonItemView_ShowGross.OptionGroup = "View"
            Me.ButtonItemView_ShowGross.RibbonWordWrap = False
            Me.ButtonItemView_ShowGross.SecurityEnabled = True
            Me.ButtonItemView_ShowGross.SubItemsExpandWidth = 14
            Me.ButtonItemView_ShowGross.Text = "Show Gross"
            '
            'ButtonItemView_ShowBoth
            '
            Me.ButtonItemView_ShowBoth.AutoCheckOnClick = True
            Me.ButtonItemView_ShowBoth.BeginGroup = True
            Me.ButtonItemView_ShowBoth.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemView_ShowBoth.Name = "ButtonItemView_ShowBoth"
            Me.ButtonItemView_ShowBoth.OptionGroup = "View"
            Me.ButtonItemView_ShowBoth.RibbonWordWrap = False
            Me.ButtonItemView_ShowBoth.SecurityEnabled = True
            Me.ButtonItemView_ShowBoth.SubItemsExpandWidth = 14
            Me.ButtonItemView_ShowBoth.Text = "Show Both"
            '
            'RibbonBarOptions_RatingsImps
            '
            Me.RibbonBarOptions_RatingsImps.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_RatingsImps.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_RatingsImps.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_RatingsImps.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_RatingsImps.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_RatingsImps.DragDropSupport = True
            Me.RibbonBarOptions_RatingsImps.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerRatings})
            Me.RibbonBarOptions_RatingsImps.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_RatingsImps.Location = New System.Drawing.Point(623, 0)
            Me.RibbonBarOptions_RatingsImps.Name = "RibbonBarOptions_RatingsImps"
            Me.RibbonBarOptions_RatingsImps.SecurityEnabled = True
            Me.RibbonBarOptions_RatingsImps.Size = New System.Drawing.Size(139, 92)
            Me.RibbonBarOptions_RatingsImps.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_RatingsImps.TabIndex = 26
            Me.RibbonBarOptions_RatingsImps.Text = "Ratings"
            '
            '
            '
            Me.RibbonBarOptions_RatingsImps.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_RatingsImps.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_RatingsImps.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ItemContainerRatings
            '
            '
            '
            '
            Me.ItemContainerRatings.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerRatings.BeginGroup = True
            Me.ItemContainerRatings.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerRatings.Name = "ItemContainerRatings"
            Me.ItemContainerRatings.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerShowGrpsImps, Me.ItemContainerRatingsDemo})
            '
            '
            '
            Me.ItemContainerRatings.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerRatings.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ItemContainerShowGrpsImps
            '
            '
            '
            '
            Me.ItemContainerShowGrpsImps.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerShowGrpsImps.Name = "ItemContainerShowGrpsImps"
            Me.ItemContainerShowGrpsImps.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemInvoiceDetail_ShowGRPs, Me.ButtonItemInvoiceDetail_ShowIMPs})
            '
            '
            '
            Me.ItemContainerShowGrpsImps.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerShowGrpsImps.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemInvoiceDetail_ShowGRPs
            '
            Me.ButtonItemInvoiceDetail_ShowGRPs.AutoCheckOnClick = True
            Me.ButtonItemInvoiceDetail_ShowGRPs.Name = "ButtonItemInvoiceDetail_ShowGRPs"
            Me.ButtonItemInvoiceDetail_ShowGRPs.SecurityEnabled = True
            Me.ButtonItemInvoiceDetail_ShowGRPs.Stretch = True
            Me.ButtonItemInvoiceDetail_ShowGRPs.SubItemsExpandWidth = 14
            Me.ButtonItemInvoiceDetail_ShowGRPs.Text = "Show GRPs"
            '
            'ButtonItemInvoiceDetail_ShowIMPs
            '
            Me.ButtonItemInvoiceDetail_ShowIMPs.AutoCheckOnClick = True
            Me.ButtonItemInvoiceDetail_ShowIMPs.BeginGroup = True
            Me.ButtonItemInvoiceDetail_ShowIMPs.Name = "ButtonItemInvoiceDetail_ShowIMPs"
            Me.ButtonItemInvoiceDetail_ShowIMPs.SecurityEnabled = True
            Me.ButtonItemInvoiceDetail_ShowIMPs.Stretch = True
            Me.ButtonItemInvoiceDetail_ShowIMPs.SubItemsExpandWidth = 14
            Me.ButtonItemInvoiceDetail_ShowIMPs.Text = "Show Imps"
            '
            'ItemContainerRatingsDemo
            '
            '
            '
            '
            Me.ItemContainerRatingsDemo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerRatingsDemo.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerRatingsDemo.Name = "ItemContainerRatingsDemo"
            Me.ItemContainerRatingsDemo.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemRatingsSource, Me.LabelItemDemographic})
            '
            '
            '
            Me.ItemContainerRatingsDemo.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerRatingsDemo.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemRatingsSource
            '
            Me.LabelItemRatingsSource.Name = "LabelItemRatingsSource"
            Me.LabelItemRatingsSource.PaddingBottom = 4
            Me.LabelItemRatingsSource.PaddingTop = 4
            Me.LabelItemRatingsSource.Text = "Ratings Source"
            '
            'LabelItemDemographic
            '
            Me.LabelItemDemographic.Name = "LabelItemDemographic"
            Me.LabelItemDemographic.PaddingBottom = 4
            Me.LabelItemDemographic.PaddingTop = 4
            Me.LabelItemDemographic.Text = "Demographic"
            '
            'RibbonBarOptions_Amounts
            '
            Me.RibbonBarOptions_Amounts.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Amounts.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Amounts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Amounts.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Amounts.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Amounts.DragDropSupport = True
            Me.RibbonBarOptions_Amounts.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerAmounts_Vertical})
            Me.RibbonBarOptions_Amounts.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Amounts.Location = New System.Drawing.Point(762, 0)
            Me.RibbonBarOptions_Amounts.Name = "RibbonBarOptions_Amounts"
            Me.RibbonBarOptions_Amounts.SecurityEnabled = True
            Me.RibbonBarOptions_Amounts.Size = New System.Drawing.Size(127, 92)
            Me.RibbonBarOptions_Amounts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Amounts.TabIndex = 27
            Me.RibbonBarOptions_Amounts.Text = "Ordered"
            '
            '
            '
            Me.RibbonBarOptions_Amounts.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Amounts.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Amounts.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ItemContainerAmounts_Vertical
            '
            '
            '
            '
            Me.ItemContainerAmounts_Vertical.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerAmounts_Vertical.BeginGroup = True
            Me.ItemContainerAmounts_Vertical.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerAmounts_Vertical.Name = "ItemContainerAmounts_Vertical"
            Me.ItemContainerAmounts_Vertical.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemOrderedAmount, Me.LabelItemOrderedNetAmount, Me.LabelItemOrderedSpots})
            '
            '
            '
            Me.ItemContainerAmounts_Vertical.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerAmounts_Vertical.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemOrderedAmount
            '
            Me.LabelItemOrderedAmount.Name = "LabelItemOrderedAmount"
            Me.LabelItemOrderedAmount.PaddingTop = 6
            Me.LabelItemOrderedAmount.Text = "Amt:"
            '
            'LabelItemOrderedNetAmount
            '
            Me.LabelItemOrderedNetAmount.Name = "LabelItemOrderedNetAmount"
            Me.LabelItemOrderedNetAmount.PaddingTop = 6
            Me.LabelItemOrderedNetAmount.Text = "Net Amt:"
            '
            'LabelItemOrderedSpots
            '
            Me.LabelItemOrderedSpots.Name = "LabelItemOrderedSpots"
            Me.LabelItemOrderedSpots.PaddingTop = 6
            Me.LabelItemOrderedSpots.Text = "Spots:"
            '
            'RibbonBarOptions_Spots
            '
            Me.RibbonBarOptions_Spots.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Spots.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Spots.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Spots.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Spots.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Spots.DragDropSupport = True
            Me.RibbonBarOptions_Spots.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerSpots_Vertical})
            Me.RibbonBarOptions_Spots.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Spots.Location = New System.Drawing.Point(889, 0)
            Me.RibbonBarOptions_Spots.Name = "RibbonBarOptions_Spots"
            Me.RibbonBarOptions_Spots.SecurityEnabled = True
            Me.RibbonBarOptions_Spots.Size = New System.Drawing.Size(127, 92)
            Me.RibbonBarOptions_Spots.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Spots.TabIndex = 28
            Me.RibbonBarOptions_Spots.Text = "Invoiced"
            '
            '
            '
            Me.RibbonBarOptions_Spots.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Spots.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Spots.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ItemContainerSpots_Vertical
            '
            '
            '
            '
            Me.ItemContainerSpots_Vertical.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSpots_Vertical.BeginGroup = True
            Me.ItemContainerSpots_Vertical.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerSpots_Vertical.Name = "ItemContainerSpots_Vertical"
            Me.ItemContainerSpots_Vertical.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemInvoicedAmount, Me.LabelItemInvoicedNetAmount, Me.LabelItemInvoicedSpots})
            '
            '
            '
            Me.ItemContainerSpots_Vertical.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerSpots_Vertical.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemInvoicedAmount
            '
            Me.LabelItemInvoicedAmount.Name = "LabelItemInvoicedAmount"
            Me.LabelItemInvoicedAmount.PaddingTop = 6
            Me.LabelItemInvoicedAmount.Text = "Amt:"
            '
            'LabelItemInvoicedNetAmount
            '
            Me.LabelItemInvoicedNetAmount.Name = "LabelItemInvoicedNetAmount"
            Me.LabelItemInvoicedNetAmount.PaddingTop = 6
            Me.LabelItemInvoicedNetAmount.Text = "Net Amt:"
            '
            'LabelItemInvoicedSpots
            '
            Me.LabelItemInvoicedSpots.Name = "LabelItemInvoicedSpots"
            Me.LabelItemInvoicedSpots.PaddingTop = 6
            Me.LabelItemInvoicedSpots.Text = "Spots:"
            '
            'RibbonBarOptions_SpotDetail
            '
            Me.RibbonBarOptions_SpotDetail.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarOptions_SpotDetail.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_SpotDetail.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_SpotDetail.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_SpotDetail.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_SpotDetail.DragDropSupport = True
            Me.RibbonBarOptions_SpotDetail.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemSpotDetail_Delete, Me.ButtonItemSpotDetail_Cancel})
            Me.RibbonBarOptions_SpotDetail.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_SpotDetail.Location = New System.Drawing.Point(107, 0)
            Me.RibbonBarOptions_SpotDetail.Name = "RibbonBarOptions_SpotDetail"
            Me.RibbonBarOptions_SpotDetail.SecurityEnabled = True
            Me.RibbonBarOptions_SpotDetail.Size = New System.Drawing.Size(46, 92)
            Me.RibbonBarOptions_SpotDetail.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_SpotDetail.TabIndex = 42
            Me.RibbonBarOptions_SpotDetail.Text = "Spot Detail"
            '
            '
            '
            Me.RibbonBarOptions_SpotDetail.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_SpotDetail.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_SpotDetail.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            Me.RibbonBarOptions_SpotDetail.Visible = False
            '
            'ButtonItemSpotDetail_Delete
            '
            Me.ButtonItemSpotDetail_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemSpotDetail_Delete.Name = "ButtonItemSpotDetail_Delete"
            Me.ButtonItemSpotDetail_Delete.SecurityEnabled = True
            Me.ButtonItemSpotDetail_Delete.Text = "Delete"
            '
            'ButtonItemSpotDetail_Cancel
            '
            Me.ButtonItemSpotDetail_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemSpotDetail_Cancel.Name = "ButtonItemSpotDetail_Cancel"
            Me.ButtonItemSpotDetail_Cancel.SecurityEnabled = True
            Me.ButtonItemSpotDetail_Cancel.Text = "Cancel"
            '
            'ButtonItemInvoiceDetail_Rematch
            '
            Me.ButtonItemInvoiceDetail_Rematch.BeginGroup = True
            Me.ButtonItemInvoiceDetail_Rematch.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemInvoiceDetail_Rematch.Name = "ButtonItemInvoiceDetail_Rematch"
            Me.ButtonItemInvoiceDetail_Rematch.RibbonWordWrap = False
            Me.ButtonItemInvoiceDetail_Rematch.SecurityEnabled = True
            Me.ButtonItemInvoiceDetail_Rematch.SubItemsExpandWidth = 14
            Me.ButtonItemInvoiceDetail_Rematch.Text = "Re-Match"
            '
            'MediaManagerApproveInvoicesDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(992, 730)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaManagerApproveInvoicesDialog"
            Me.Text = "Media Manager Approve Invoices"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            Me.RibbonBarOptions_ApprovalStatus.ResumeLayout(False)
            CType(Me.TabControlPanel_InvoiceItems, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanel_InvoiceItems.ResumeLayout(False)
            Me.TabControlPanelAPInvoiceDetailTab_APInvoiceDetails.ResumeLayout(False)
            Me.TabControlPanelInvoiceDetailTab_InvoiceDetails.ResumeLayout(False)
            CType(Me.PanelInvoicesBottom, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelInvoicesBottom.ResumeLayout(False)
            CType(Me.PanelInvoicesTop, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelInvoicesTop.ResumeLayout(False)
            Me.TabControlPanelInvoiceDetailMatchingTab_InvoiceDetailMatching.ResumeLayout(False)
            CType(Me.PanelInvoiceDetailMatching_Bottom, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelInvoiceDetailMatching_Bottom.ResumeLayout(False)
            CType(Me.PanelInvoiceDetailMatching_Top, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelInvoiceDetailMatching_Top.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Save As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_ApprovalStatus As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ItemContainerVertical_MediaStatus As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ComboBoxApprovalStatus_Status As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ControlContainerItemMediaStatus_JobProcess As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ButtonItemMediaStatus_MarkSelected As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents TabControlPanel_InvoiceItems As WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelInvoiceDetailTab_InvoiceDetails As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewInvoices_Orders As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TabItemInvoiceItems_InvoiceDetail As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelAPInvoiceDetailTab_APInvoiceDetails As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemAPInvoiceDetail_APInvoiceDetail As DevComponents.DotNetBar.TabItem
        Friend WithEvents ApInvoiceControlAPInvoiceDetail_APInvoiceDetail As WinForm.Presentation.Controls.APInvoiceControl
        Friend WithEvents RibbonBarOptions_Documents As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemDocuments_Upload As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDocuments_Download As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDocuments_OpenURL As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Filter As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemFilter_HasVariance As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemFilter_Unapproved As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemUpload_EmailLink As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents TabControlPanelInvoiceDetailMatchingTab_InvoiceDetailMatching As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemInvoiceItems_InvoiceDetailMatching As DevComponents.DotNetBar.TabItem
        Friend WithEvents PanelInvoiceDetailMatching_Bottom As WinForm.Presentation.Controls.Panel
        Friend WithEvents ExpandableSplitterControlBroadcastDetailVerification_TopBottom As WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelInvoiceDetailMatching_Top As WinForm.Presentation.Controls.Panel
        Friend WithEvents RibbonBarOptions_InvoiceDetail As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemInvoiceDetail_Approve As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemInvoiceDetail_Unapprove As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemInvoiceDetail_ShowAll As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_GoToOrder As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents PanelInvoicesTop As WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelInvoicesBottom As WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewInvoiceDetails_InvoiceDetails As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ExpandableSplitterControlInvoices_TopBottom As WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents RibbonBarOptions_View As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemView_ShowGross As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemView_ShowNet As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemView_ShowBoth As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents DataGridViewInvoiceDetailMatching_InvoiceDetails As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewInvoiceDetailMatching_OrderLines As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonItemInvoiceDetail_AutoFill As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemInvoiceDetail_ShowWeeks As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_RatingsImps As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ItemContainerRatings As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ItemContainerShowGrpsImps As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemInvoiceDetail_ShowGRPs As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemInvoiceDetail_ShowIMPs As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ItemContainerRatingsDemo As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemRatingsSource As DevComponents.DotNetBar.LabelItem
        Friend WithEvents LabelItemDemographic As DevComponents.DotNetBar.LabelItem
        Friend WithEvents RibbonBarOptions_Amounts As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ItemContainerAmounts_Vertical As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemOrderedAmount As DevComponents.DotNetBar.LabelItem
        Friend WithEvents LabelItemOrderedSpots As DevComponents.DotNetBar.LabelItem
        Friend WithEvents RibbonBarOptions_Spots As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ItemContainerSpots_Vertical As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemInvoicedAmount As DevComponents.DotNetBar.LabelItem
        Friend WithEvents LabelItemInvoicedSpots As DevComponents.DotNetBar.LabelItem
        Friend WithEvents LabelItemInvoicedNetAmount As DevComponents.DotNetBar.LabelItem
        Friend WithEvents LabelItemOrderedNetAmount As DevComponents.DotNetBar.LabelItem
        Friend WithEvents RibbonBarOptions_SpotDetail As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemSpotDetail_Delete As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemSpotDetail_Cancel As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemInvoiceDetail_Rematch As WinForm.Presentation.Controls.ButtonItem
    End Class

End Namespace
