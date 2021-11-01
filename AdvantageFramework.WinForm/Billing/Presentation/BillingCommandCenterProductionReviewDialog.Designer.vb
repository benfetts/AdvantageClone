Namespace Billing.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class BillingCommandCenterProductionReviewDialog
        Inherits WinForm.Presentation.BaseForms.BaseRibbonForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
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
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BillingCommandCenterProductionReviewDialog))
            Me.DataGridViewForm_ProductionSummary = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RibbonBarOptions_GridOptions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemGridOptions_ChooseColumns = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemGridOptions_RestoreDefaults = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Export = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_AdvanceBill = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_AdvanceBillPercentToQuote = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_AdvanceBillSetJobAsAdvanceBill = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_BillHold = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Transfer = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Reconcile = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_BillingSelection = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_ProcessControl = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_ManageCoop = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Refresh = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_View = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemView_JobDetails = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemView_BillingHistory = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Include = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemInclude_Contingency = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Report = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemReport_Billing = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.LabelItemAdvanceBilling_PercenToBill = New DevComponents.DotNetBar.LabelItem()
            Me.LabelItemAdvanceBilling_PercentBilled = New DevComponents.DotNetBar.LabelItem()
            Me.ItemContainerBillingSelectionVertical_Top = New DevComponents.DotNetBar.ItemContainer()
            Me.ControlContainerItemBS_InvoiceDate = New DevComponents.DotNetBar.ControlContainerItem()
            Me.DataGridViewForm_Export = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
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
            Me.PanelForm_Form.Controls.Add(Me.DataGridViewForm_Export)
            Me.PanelForm_Form.Controls.Add(Me.DataGridViewForm_ProductionSummary)
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
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_GridOptions)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Report)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Include)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_View)
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
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_View, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Include, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Report, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_GridOptions, 0)
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
            'DataGridViewForm_ProductionSummary
            '
            Me.DataGridViewForm_ProductionSummary.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_ProductionSummary.AllowDragAndDrop = False
            Me.DataGridViewForm_ProductionSummary.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_ProductionSummary.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_ProductionSummary.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_ProductionSummary.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_ProductionSummary.AutoFilterLookupColumns = False
            Me.DataGridViewForm_ProductionSummary.AutoloadRepositoryDatasource = False
            Me.DataGridViewForm_ProductionSummary.AutoUpdateViewCaption = True
            Me.DataGridViewForm_ProductionSummary.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewForm_ProductionSummary.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_ProductionSummary.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_ProductionSummary.ItemDescription = "Production Summary(ies)"
            Me.DataGridViewForm_ProductionSummary.Location = New System.Drawing.Point(4, 5)
            Me.DataGridViewForm_ProductionSummary.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewForm_ProductionSummary.MultiSelect = True
            Me.DataGridViewForm_ProductionSummary.Name = "DataGridViewForm_ProductionSummary"
            Me.DataGridViewForm_ProductionSummary.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_ProductionSummary.RunStandardValidation = True
            Me.DataGridViewForm_ProductionSummary.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_ProductionSummary.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_ProductionSummary.Size = New System.Drawing.Size(974, 546)
            Me.DataGridViewForm_ProductionSummary.TabIndex = 1
            Me.DataGridViewForm_ProductionSummary.UseEmbeddedNavigator = False
            Me.DataGridViewForm_ProductionSummary.ViewCaptionHeight = -1
            '
            'RibbonBarOptions_GridOptions
            '
            Me.RibbonBarOptions_GridOptions.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_GridOptions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_GridOptions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_GridOptions.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_GridOptions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_GridOptions.DragDropSupport = True
            Me.RibbonBarOptions_GridOptions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemGridOptions_ChooseColumns, Me.ButtonItemGridOptions_RestoreDefaults})
            Me.RibbonBarOptions_GridOptions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_GridOptions.Location = New System.Drawing.Point(833, 0)
            Me.RibbonBarOptions_GridOptions.Name = "RibbonBarOptions_GridOptions"
            Me.RibbonBarOptions_GridOptions.SecurityEnabled = True
            Me.RibbonBarOptions_GridOptions.Size = New System.Drawing.Size(97, 92)
            Me.RibbonBarOptions_GridOptions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_GridOptions.TabIndex = 13
            Me.RibbonBarOptions_GridOptions.Text = "Grid Options"
            '
            '
            '
            Me.RibbonBarOptions_GridOptions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_GridOptions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_GridOptions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemGridOptions_ChooseColumns
            '
            Me.ButtonItemGridOptions_ChooseColumns.AutoCheckOnClick = True
            Me.ButtonItemGridOptions_ChooseColumns.BeginGroup = True
            Me.ButtonItemGridOptions_ChooseColumns.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemGridOptions_ChooseColumns.Name = "ButtonItemGridOptions_ChooseColumns"
            Me.ButtonItemGridOptions_ChooseColumns.RibbonWordWrap = False
            Me.ButtonItemGridOptions_ChooseColumns.SecurityEnabled = True
            Me.ButtonItemGridOptions_ChooseColumns.SubItemsExpandWidth = 14
            Me.ButtonItemGridOptions_ChooseColumns.Text = "Choose Columns"
            '
            'ButtonItemGridOptions_RestoreDefaults
            '
            Me.ButtonItemGridOptions_RestoreDefaults.BeginGroup = True
            Me.ButtonItemGridOptions_RestoreDefaults.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemGridOptions_RestoreDefaults.Name = "ButtonItemGridOptions_RestoreDefaults"
            Me.ButtonItemGridOptions_RestoreDefaults.RibbonWordWrap = False
            Me.ButtonItemGridOptions_RestoreDefaults.SecurityEnabled = True
            Me.ButtonItemGridOptions_RestoreDefaults.SubItemsExpandWidth = 14
            Me.ButtonItemGridOptions_RestoreDefaults.Text = "Restore Defaults"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Export, Me.ButtonItemActions_AdvanceBill, Me.ButtonItemActions_BillHold, Me.ButtonItemActions_Transfer, Me.ButtonItemActions_Reconcile, Me.ButtonItemActions_BillingSelection, Me.ButtonItemActions_ProcessControl, Me.ButtonItemActions_ManageCoop, Me.ButtonItemActions_Refresh})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(55, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(552, 92)
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
            Me.ButtonItemActions_Export.BeginGroup = True
            Me.ButtonItemActions_Export.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Export.Name = "ButtonItemActions_Export"
            Me.ButtonItemActions_Export.RibbonWordWrap = False
            Me.ButtonItemActions_Export.SecurityEnabled = True
            Me.ButtonItemActions_Export.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Export.Text = "Export"
            '
            'ButtonItemActions_AdvanceBill
            '
            Me.ButtonItemActions_AdvanceBill.AutoExpandOnClick = True
            Me.ButtonItemActions_AdvanceBill.BeginGroup = True
            Me.ButtonItemActions_AdvanceBill.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_AdvanceBill.Name = "ButtonItemActions_AdvanceBill"
            Me.ButtonItemActions_AdvanceBill.RibbonWordWrap = False
            Me.ButtonItemActions_AdvanceBill.SecurityEnabled = True
            Me.ButtonItemActions_AdvanceBill.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_AdvanceBillPercentToQuote, Me.ButtonItemActions_AdvanceBillSetJobAsAdvanceBill})
            Me.ButtonItemActions_AdvanceBill.SubItemsExpandWidth = 14
            Me.ButtonItemActions_AdvanceBill.Text = "Advance Bill"
            '
            'ButtonItemActions_AdvanceBillPercentToQuote
            '
            Me.ButtonItemActions_AdvanceBillPercentToQuote.Name = "ButtonItemActions_AdvanceBillPercentToQuote"
            Me.ButtonItemActions_AdvanceBillPercentToQuote.Text = "Create Using % to Quote"
            '
            'ButtonItemActions_AdvanceBillSetJobAsAdvanceBill
            '
            Me.ButtonItemActions_AdvanceBillSetJobAsAdvanceBill.Name = "ButtonItemActions_AdvanceBillSetJobAsAdvanceBill"
            Me.ButtonItemActions_AdvanceBillSetJobAsAdvanceBill.Text = "Set Job as Advance Bill"
            '
            'ButtonItemActions_BillHold
            '
            Me.ButtonItemActions_BillHold.BeginGroup = True
            Me.ButtonItemActions_BillHold.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_BillHold.Name = "ButtonItemActions_BillHold"
            Me.ButtonItemActions_BillHold.RibbonWordWrap = False
            Me.ButtonItemActions_BillHold.SecurityEnabled = True
            Me.ButtonItemActions_BillHold.SubItemsExpandWidth = 14
            Me.ButtonItemActions_BillHold.Text = "Bill Hold"
            '
            'ButtonItemActions_Transfer
            '
            Me.ButtonItemActions_Transfer.BeginGroup = True
            Me.ButtonItemActions_Transfer.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Transfer.Name = "ButtonItemActions_Transfer"
            Me.ButtonItemActions_Transfer.RibbonWordWrap = False
            Me.ButtonItemActions_Transfer.SecurityEnabled = True
            Me.ButtonItemActions_Transfer.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Transfer.Text = "Transfer"
            '
            'ButtonItemActions_Reconcile
            '
            Me.ButtonItemActions_Reconcile.BeginGroup = True
            Me.ButtonItemActions_Reconcile.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Reconcile.Name = "ButtonItemActions_Reconcile"
            Me.ButtonItemActions_Reconcile.RibbonWordWrap = False
            Me.ButtonItemActions_Reconcile.SecurityEnabled = True
            Me.ButtonItemActions_Reconcile.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Reconcile.Text = "Reconcile"
            '
            'ButtonItemActions_BillingSelection
            '
            Me.ButtonItemActions_BillingSelection.BeginGroup = True
            Me.ButtonItemActions_BillingSelection.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_BillingSelection.Name = "ButtonItemActions_BillingSelection"
            Me.ButtonItemActions_BillingSelection.RibbonWordWrap = False
            Me.ButtonItemActions_BillingSelection.SecurityEnabled = True
            Me.ButtonItemActions_BillingSelection.SubItemsExpandWidth = 14
            Me.ButtonItemActions_BillingSelection.Text = "Billing Selection"
            '
            'ButtonItemActions_ProcessControl
            '
            Me.ButtonItemActions_ProcessControl.BeginGroup = True
            Me.ButtonItemActions_ProcessControl.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_ProcessControl.Name = "ButtonItemActions_ProcessControl"
            Me.ButtonItemActions_ProcessControl.RibbonWordWrap = False
            Me.ButtonItemActions_ProcessControl.SecurityEnabled = True
            Me.ButtonItemActions_ProcessControl.SubItemsExpandWidth = 14
            Me.ButtonItemActions_ProcessControl.Text = "Process Control"
            '
            'ButtonItemActions_ManageCoop
            '
            Me.ButtonItemActions_ManageCoop.BeginGroup = True
            Me.ButtonItemActions_ManageCoop.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_ManageCoop.Name = "ButtonItemActions_ManageCoop"
            Me.ButtonItemActions_ManageCoop.RibbonWordWrap = False
            Me.ButtonItemActions_ManageCoop.SecurityEnabled = True
            Me.ButtonItemActions_ManageCoop.SubItemsExpandWidth = 14
            Me.ButtonItemActions_ManageCoop.Text = "Manage Co-op"
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
            Me.RibbonBarOptions_View.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemView_JobDetails, Me.ButtonItemView_BillingHistory})
            Me.RibbonBarOptions_View.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_View.Location = New System.Drawing.Point(607, 0)
            Me.RibbonBarOptions_View.Name = "RibbonBarOptions_View"
            Me.RibbonBarOptions_View.SecurityEnabled = True
            Me.RibbonBarOptions_View.Size = New System.Drawing.Size(92, 92)
            Me.RibbonBarOptions_View.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_View.TabIndex = 19
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
            'ButtonItemView_JobDetails
            '
            Me.ButtonItemView_JobDetails.BeginGroup = True
            Me.ButtonItemView_JobDetails.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemView_JobDetails.Name = "ButtonItemView_JobDetails"
            Me.ButtonItemView_JobDetails.RibbonWordWrap = False
            Me.ButtonItemView_JobDetails.SecurityEnabled = True
            Me.ButtonItemView_JobDetails.SubItemsExpandWidth = 14
            Me.ButtonItemView_JobDetails.Text = "Job Details"
            '
            'ButtonItemView_BillingHistory
            '
            Me.ButtonItemView_BillingHistory.BeginGroup = True
            Me.ButtonItemView_BillingHistory.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemView_BillingHistory.Name = "ButtonItemView_BillingHistory"
            Me.ButtonItemView_BillingHistory.RibbonWordWrap = False
            Me.ButtonItemView_BillingHistory.SecurityEnabled = True
            Me.ButtonItemView_BillingHistory.SubItemsExpandWidth = 14
            Me.ButtonItemView_BillingHistory.Text = "Billing History"
            '
            'RibbonBarOptions_Include
            '
            Me.RibbonBarOptions_Include.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Include.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Include.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Include.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Include.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Include.DragDropSupport = True
            Me.RibbonBarOptions_Include.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemInclude_Contingency})
            Me.RibbonBarOptions_Include.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Include.Location = New System.Drawing.Point(699, 0)
            Me.RibbonBarOptions_Include.Name = "RibbonBarOptions_Include"
            Me.RibbonBarOptions_Include.SecurityEnabled = True
            Me.RibbonBarOptions_Include.Size = New System.Drawing.Size(59, 92)
            Me.RibbonBarOptions_Include.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Include.TabIndex = 20
            Me.RibbonBarOptions_Include.Text = "Include"
            '
            '
            '
            Me.RibbonBarOptions_Include.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Include.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Include.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemInclude_Contingency
            '
            Me.ButtonItemInclude_Contingency.AutoCheckOnClick = True
            Me.ButtonItemInclude_Contingency.BeginGroup = True
            Me.ButtonItemInclude_Contingency.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemInclude_Contingency.Name = "ButtonItemInclude_Contingency"
            Me.ButtonItemInclude_Contingency.RibbonWordWrap = False
            Me.ButtonItemInclude_Contingency.SecurityEnabled = True
            Me.ButtonItemInclude_Contingency.SubItemsExpandWidth = 14
            Me.ButtonItemInclude_Contingency.Text = "Contingency"
            '
            'RibbonBarOptions_Report
            '
            Me.RibbonBarOptions_Report.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Report.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Report.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Report.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Report.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Report.DragDropSupport = True
            Me.RibbonBarOptions_Report.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemReport_Billing})
            Me.RibbonBarOptions_Report.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Report.Location = New System.Drawing.Point(758, 0)
            Me.RibbonBarOptions_Report.Name = "RibbonBarOptions_Report"
            Me.RibbonBarOptions_Report.SecurityEnabled = True
            Me.RibbonBarOptions_Report.Size = New System.Drawing.Size(75, 92)
            Me.RibbonBarOptions_Report.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Report.TabIndex = 21
            Me.RibbonBarOptions_Report.Text = "Report"
            '
            '
            '
            Me.RibbonBarOptions_Report.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Report.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Report.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemReport_Billing
            '
            Me.ButtonItemReport_Billing.BeginGroup = True
            Me.ButtonItemReport_Billing.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemReport_Billing.Name = "ButtonItemReport_Billing"
            Me.ButtonItemReport_Billing.RibbonWordWrap = False
            Me.ButtonItemReport_Billing.SecurityEnabled = True
            Me.ButtonItemReport_Billing.SubItemsExpandWidth = 14
            Me.ButtonItemReport_Billing.Text = "Billing"
            '
            'LabelItemAdvanceBilling_PercenToBill
            '
            Me.LabelItemAdvanceBilling_PercenToBill.Name = "LabelItemAdvanceBilling_PercenToBill"
            Me.LabelItemAdvanceBilling_PercenToBill.Text = "% to Bill:"
            Me.LabelItemAdvanceBilling_PercenToBill.Width = 55
            '
            'LabelItemAdvanceBilling_PercentBilled
            '
            Me.LabelItemAdvanceBilling_PercentBilled.Name = "LabelItemAdvanceBilling_PercentBilled"
            Me.LabelItemAdvanceBilling_PercentBilled.Text = "% Billed:"
            Me.LabelItemAdvanceBilling_PercentBilled.Width = 55
            '
            'ItemContainerBillingSelectionVertical_Top
            '
            '
            '
            '
            Me.ItemContainerBillingSelectionVertical_Top.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerBillingSelectionVertical_Top.Name = "ItemContainerBillingSelectionVertical_Top"
            Me.ItemContainerBillingSelectionVertical_Top.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemAdvanceBilling_PercenToBill, Me.ControlContainerItemBS_InvoiceDate})
            '
            '
            '
            Me.ItemContainerBillingSelectionVertical_Top.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ControlContainerItemBS_InvoiceDate
            '
            Me.ControlContainerItemBS_InvoiceDate.AllowItemResize = True
            Me.ControlContainerItemBS_InvoiceDate.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItemBS_InvoiceDate.Name = "ControlContainerItemBS_InvoiceDate"
            Me.ControlContainerItemBS_InvoiceDate.Text = "ControlContainerItem2"
            '
            'DataGridViewForm_Export
            '
            Me.DataGridViewForm_Export.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_Export.AllowDragAndDrop = False
            Me.DataGridViewForm_Export.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_Export.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_Export.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_Export.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_Export.AutoFilterLookupColumns = False
            Me.DataGridViewForm_Export.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_Export.AutoUpdateViewCaption = True
            Me.DataGridViewForm_Export.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_Export.DataSource = Nothing
            Me.DataGridViewForm_Export.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_Export.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_Export.ItemDescription = ""
            Me.DataGridViewForm_Export.Location = New System.Drawing.Point(383, 195)
            Me.DataGridViewForm_Export.MultiSelect = True
            Me.DataGridViewForm_Export.Name = "DataGridViewForm_Export"
            Me.DataGridViewForm_Export.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_Export.RunStandardValidation = True
            Me.DataGridViewForm_Export.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_Export.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_Export.Size = New System.Drawing.Size(217, 324)
            Me.DataGridViewForm_Export.TabIndex = 11
            Me.DataGridViewForm_Export.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Export.ViewCaptionHeight = -1
            Me.DataGridViewForm_Export.Visible = False
            '
            'BillingCommandCenterProductionReviewDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(992, 730)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "BillingCommandCenterProductionReviewDialog"
            Me.Text = "Billing Command Center Production Review"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewForm_ProductionSummary As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarOptions_GridOptions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Reconcile As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_BillingSelection As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_ProcessControl As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_View As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Transfer As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_BillHold As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Include As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemInclude_Contingency As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemView_JobDetails As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemView_BillingHistory As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemGridOptions_ChooseColumns As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemGridOptions_RestoreDefaults As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Report As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemReport_Billing As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Refresh As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ItemContainerBillingSelectionVertical_Top As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ControlContainerItemBS_InvoiceDate As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents LabelItemAdvanceBilling_PercenToBill As DevComponents.DotNetBar.LabelItem
        Friend WithEvents LabelItemAdvanceBilling_PercentBilled As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ButtonItemActions_ManageCoop As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Export As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents DataGridViewForm_Export As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonItemActions_AdvanceBill As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_AdvanceBillSetJobAsAdvanceBill As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_AdvanceBillPercentToQuote As DevComponents.DotNetBar.ButtonItem
    End Class

End Namespace