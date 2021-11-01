Namespace Billing.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class BillingCommandCenterBillingHistoryDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BillingCommandCenterBillingHistoryDialog))
            Me.LabelPanel_JobComponent = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPanel_Job = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPanel_JobValue = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPanel_JobComponentValue = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.RibbonBarOptions_Filter = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemFilter_All = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemFilter_SelectedLineItem = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Documents = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemDocuments_Download = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Export = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.TabControlPanel_BillingSummary = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelJournalEntriesTab_JournalEntries = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewPanel_JournalEntries = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemBillingSummary_JournalEntries = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelInvoicesTab_Invoices = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewForm_Export = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.DataGridViewPanel_Invoices = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemBillingSummary_InvoicesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelDocumentsTab_Documents = New DevComponents.DotNetBar.TabControlPanel()
            Me.DocumentManagerControlDocuments_InvoiceDocuments = New AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl()
            Me.TabItemBillingSummary_DocumentsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.TabControlPanel_BillingSummary, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanel_BillingSummary.SuspendLayout()
            Me.TabControlPanelJournalEntriesTab_JournalEntries.SuspendLayout()
            Me.TabControlPanelInvoicesTab_Invoices.SuspendLayout()
            Me.TabControlPanelDocumentsTab_Documents.SuspendLayout()
            Me.SuspendLayout()
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
            Me.RibbonControlForm_MainRibbon.TabIndex = 0
            Me.RibbonControlForm_MainRibbon.Controls.SetChildIndex(Me.RibbonPanelFile_FilePanel, 0)
            '
            'RibbonPanelFile_FilePanel
            '
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Filter)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Documents)
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
            Me.RibbonPanelFile_FilePanel.TabIndex = 0
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFilePanel_System, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Actions, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Documents, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Filter, 0)
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
            'PanelForm_Form
            '
            Me.PanelForm_Form.Controls.Add(Me.TabControlPanel_BillingSummary)
            Me.PanelForm_Form.Controls.Add(Me.LabelPanel_JobComponentValue)
            Me.PanelForm_Form.Controls.Add(Me.LabelPanel_JobValue)
            Me.PanelForm_Form.Controls.Add(Me.LabelPanel_JobComponent)
            Me.PanelForm_Form.Controls.Add(Me.LabelPanel_Job)
            Me.PanelForm_Form.Size = New System.Drawing.Size(982, 555)
            Me.PanelForm_Form.TabIndex = 1
            '
            'BarForm_StatusBar
            '
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 710)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(982, 18)
            '
            'LabelPanel_JobComponent
            '
            Me.LabelPanel_JobComponent.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPanel_JobComponent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPanel_JobComponent.Location = New System.Drawing.Point(4, 32)
            Me.LabelPanel_JobComponent.Name = "LabelPanel_JobComponent"
            Me.LabelPanel_JobComponent.Size = New System.Drawing.Size(90, 20)
            Me.LabelPanel_JobComponent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPanel_JobComponent.TabIndex = 2
            Me.LabelPanel_JobComponent.Text = "Job Component:"
            '
            'LabelPanel_Job
            '
            Me.LabelPanel_Job.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPanel_Job.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPanel_Job.Location = New System.Drawing.Point(4, 6)
            Me.LabelPanel_Job.Name = "LabelPanel_Job"
            Me.LabelPanel_Job.Size = New System.Drawing.Size(90, 20)
            Me.LabelPanel_Job.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPanel_Job.TabIndex = 0
            Me.LabelPanel_Job.Text = "Job:"
            '
            'LabelPanel_JobValue
            '
            Me.LabelPanel_JobValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelPanel_JobValue.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPanel_JobValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPanel_JobValue.Location = New System.Drawing.Point(100, 6)
            Me.LabelPanel_JobValue.Name = "LabelPanel_JobValue"
            Me.LabelPanel_JobValue.Size = New System.Drawing.Size(878, 20)
            Me.LabelPanel_JobValue.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPanel_JobValue.TabIndex = 1
            Me.LabelPanel_JobValue.Text = "{}"
            '
            'LabelPanel_JobComponentValue
            '
            Me.LabelPanel_JobComponentValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelPanel_JobComponentValue.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPanel_JobComponentValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPanel_JobComponentValue.Location = New System.Drawing.Point(100, 32)
            Me.LabelPanel_JobComponentValue.Name = "LabelPanel_JobComponentValue"
            Me.LabelPanel_JobComponentValue.Size = New System.Drawing.Size(878, 20)
            Me.LabelPanel_JobComponentValue.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPanel_JobComponentValue.TabIndex = 3
            Me.LabelPanel_JobComponentValue.Text = "{}"
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
            Me.RibbonBarOptions_Filter.Location = New System.Drawing.Point(183, 0)
            Me.RibbonBarOptions_Filter.Name = "RibbonBarOptions_Filter"
            Me.RibbonBarOptions_Filter.SecurityEnabled = True
            Me.RibbonBarOptions_Filter.Size = New System.Drawing.Size(150, 92)
            Me.RibbonBarOptions_Filter.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Filter.TabIndex = 2
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
            Me.RibbonBarOptions_Documents.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDocuments_Download})
            Me.RibbonBarOptions_Documents.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Documents.Location = New System.Drawing.Point(114, 0)
            Me.RibbonBarOptions_Documents.Name = "RibbonBarOptions_Documents"
            Me.RibbonBarOptions_Documents.SecurityEnabled = True
            Me.RibbonBarOptions_Documents.Size = New System.Drawing.Size(69, 92)
            Me.RibbonBarOptions_Documents.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Documents.TabIndex = 1
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
            Me.RibbonBarOptions_Documents.Visible = False
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Export})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(55, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(59, 92)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 3
            Me.RibbonBarOptions_Actions.Text = "Actions"
            '
            '
            '
            Me.RibbonBarOptions_Actions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Actions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Actions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
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
            'TabControlPanel_BillingSummary
            '
            Me.TabControlPanel_BillingSummary.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlPanel_BillingSummary.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
            Me.TabControlPanel_BillingSummary.CanReorderTabs = False
            Me.TabControlPanel_BillingSummary.Controls.Add(Me.TabControlPanelInvoicesTab_Invoices)
            Me.TabControlPanel_BillingSummary.Controls.Add(Me.TabControlPanelJournalEntriesTab_JournalEntries)
            Me.TabControlPanel_BillingSummary.Controls.Add(Me.TabControlPanelDocumentsTab_Documents)
            Me.TabControlPanel_BillingSummary.ForeColor = System.Drawing.Color.Black
            Me.TabControlPanel_BillingSummary.Location = New System.Drawing.Point(3, 58)
            Me.TabControlPanel_BillingSummary.Name = "TabControlPanel_BillingSummary"
            Me.TabControlPanel_BillingSummary.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlPanel_BillingSummary.SelectedTabIndex = 0
            Me.TabControlPanel_BillingSummary.Size = New System.Drawing.Size(975, 494)
            Me.TabControlPanel_BillingSummary.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlPanel_BillingSummary.TabIndex = 5
            Me.TabControlPanel_BillingSummary.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlPanel_BillingSummary.Tabs.Add(Me.TabItemBillingSummary_InvoicesTab)
            Me.TabControlPanel_BillingSummary.Tabs.Add(Me.TabItemBillingSummary_JournalEntries)
            Me.TabControlPanel_BillingSummary.Tabs.Add(Me.TabItemBillingSummary_DocumentsTab)
            Me.TabControlPanel_BillingSummary.TabStop = False
            '
            'TabControlPanelJournalEntriesTab_JournalEntries
            '
            Me.TabControlPanelJournalEntriesTab_JournalEntries.Controls.Add(Me.DataGridViewPanel_JournalEntries)
            Me.TabControlPanelJournalEntriesTab_JournalEntries.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelJournalEntriesTab_JournalEntries.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelJournalEntriesTab_JournalEntries.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelJournalEntriesTab_JournalEntries.Name = "TabControlPanelJournalEntriesTab_JournalEntries"
            Me.TabControlPanelJournalEntriesTab_JournalEntries.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelJournalEntriesTab_JournalEntries.Size = New System.Drawing.Size(975, 467)
            Me.TabControlPanelJournalEntriesTab_JournalEntries.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelJournalEntriesTab_JournalEntries.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelJournalEntriesTab_JournalEntries.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelJournalEntriesTab_JournalEntries.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelJournalEntriesTab_JournalEntries.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelJournalEntriesTab_JournalEntries.Style.GradientAngle = 90
            Me.TabControlPanelJournalEntriesTab_JournalEntries.TabIndex = 12
            Me.TabControlPanelJournalEntriesTab_JournalEntries.TabItem = Me.TabItemBillingSummary_JournalEntries
            '
            'DataGridViewPanel_JournalEntries
            '
            Me.DataGridViewPanel_JournalEntries.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewPanel_JournalEntries.AllowDragAndDrop = False
            Me.DataGridViewPanel_JournalEntries.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewPanel_JournalEntries.AllowSelectGroupHeaderRow = True
            Me.DataGridViewPanel_JournalEntries.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewPanel_JournalEntries.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewPanel_JournalEntries.AutoFilterLookupColumns = False
            Me.DataGridViewPanel_JournalEntries.AutoloadRepositoryDatasource = True
            Me.DataGridViewPanel_JournalEntries.AutoUpdateViewCaption = True
            Me.DataGridViewPanel_JournalEntries.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewPanel_JournalEntries.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewPanel_JournalEntries.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewPanel_JournalEntries.ItemDescription = "Invoice(s)"
            Me.DataGridViewPanel_JournalEntries.Location = New System.Drawing.Point(3, 4)
            Me.DataGridViewPanel_JournalEntries.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewPanel_JournalEntries.MultiSelect = True
            Me.DataGridViewPanel_JournalEntries.Name = "DataGridViewPanel_JournalEntries"
            Me.DataGridViewPanel_JournalEntries.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewPanel_JournalEntries.RunStandardValidation = True
            Me.DataGridViewPanel_JournalEntries.ShowColumnMenuOnRightClick = False
            Me.DataGridViewPanel_JournalEntries.ShowSelectDeselectAllButtons = False
            Me.DataGridViewPanel_JournalEntries.Size = New System.Drawing.Size(969, 459)
            Me.DataGridViewPanel_JournalEntries.TabIndex = 6
            Me.DataGridViewPanel_JournalEntries.UseEmbeddedNavigator = False
            Me.DataGridViewPanel_JournalEntries.ViewCaptionHeight = -1
            '
            'TabItemBillingSummary_JournalEntries
            '
            Me.TabItemBillingSummary_JournalEntries.AttachedControl = Me.TabControlPanelJournalEntriesTab_JournalEntries
            Me.TabItemBillingSummary_JournalEntries.Name = "TabItemBillingSummary_JournalEntries"
            Me.TabItemBillingSummary_JournalEntries.Text = "Journal Entries"
            '
            'TabControlPanelInvoicesTab_Invoices
            '
            Me.TabControlPanelInvoicesTab_Invoices.Controls.Add(Me.DataGridViewForm_Export)
            Me.TabControlPanelInvoicesTab_Invoices.Controls.Add(Me.DataGridViewPanel_Invoices)
            Me.TabControlPanelInvoicesTab_Invoices.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelInvoicesTab_Invoices.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelInvoicesTab_Invoices.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelInvoicesTab_Invoices.Name = "TabControlPanelInvoicesTab_Invoices"
            Me.TabControlPanelInvoicesTab_Invoices.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelInvoicesTab_Invoices.Size = New System.Drawing.Size(975, 467)
            Me.TabControlPanelInvoicesTab_Invoices.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelInvoicesTab_Invoices.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelInvoicesTab_Invoices.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelInvoicesTab_Invoices.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelInvoicesTab_Invoices.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelInvoicesTab_Invoices.Style.GradientAngle = 90
            Me.TabControlPanelInvoicesTab_Invoices.TabIndex = 3
            Me.TabControlPanelInvoicesTab_Invoices.TabItem = Me.TabItemBillingSummary_InvoicesTab
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
            Me.DataGridViewForm_Export.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewForm_Export.DataSource = Nothing
            Me.DataGridViewForm_Export.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_Export.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_Export.ItemDescription = ""
            Me.DataGridViewForm_Export.Location = New System.Drawing.Point(379, 74)
            Me.DataGridViewForm_Export.MultiSelect = True
            Me.DataGridViewForm_Export.Name = "DataGridViewForm_Export"
            Me.DataGridViewForm_Export.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_Export.RunStandardValidation = True
            Me.DataGridViewForm_Export.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_Export.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_Export.Size = New System.Drawing.Size(217, 319)
            Me.DataGridViewForm_Export.TabIndex = 12
            Me.DataGridViewForm_Export.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Export.ViewCaptionHeight = -1
            Me.DataGridViewForm_Export.Visible = False
            '
            'DataGridViewPanel_Invoices
            '
            Me.DataGridViewPanel_Invoices.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewPanel_Invoices.AllowDragAndDrop = False
            Me.DataGridViewPanel_Invoices.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewPanel_Invoices.AllowSelectGroupHeaderRow = True
            Me.DataGridViewPanel_Invoices.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewPanel_Invoices.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewPanel_Invoices.AutoFilterLookupColumns = False
            Me.DataGridViewPanel_Invoices.AutoloadRepositoryDatasource = True
            Me.DataGridViewPanel_Invoices.AutoUpdateViewCaption = True
            Me.DataGridViewPanel_Invoices.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewPanel_Invoices.DataSource = Nothing
            Me.DataGridViewPanel_Invoices.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewPanel_Invoices.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewPanel_Invoices.ItemDescription = "Invoice(s)"
            Me.DataGridViewPanel_Invoices.Location = New System.Drawing.Point(3, 4)
            Me.DataGridViewPanel_Invoices.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewPanel_Invoices.MultiSelect = True
            Me.DataGridViewPanel_Invoices.Name = "DataGridViewPanel_Invoices"
            Me.DataGridViewPanel_Invoices.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewPanel_Invoices.RunStandardValidation = True
            Me.DataGridViewPanel_Invoices.ShowColumnMenuOnRightClick = False
            Me.DataGridViewPanel_Invoices.ShowSelectDeselectAllButtons = False
            Me.DataGridViewPanel_Invoices.Size = New System.Drawing.Size(969, 459)
            Me.DataGridViewPanel_Invoices.TabIndex = 5
            Me.DataGridViewPanel_Invoices.UseEmbeddedNavigator = False
            Me.DataGridViewPanel_Invoices.ViewCaptionHeight = -1
            '
            'TabItemBillingSummary_InvoicesTab
            '
            Me.TabItemBillingSummary_InvoicesTab.AttachedControl = Me.TabControlPanelInvoicesTab_Invoices
            Me.TabItemBillingSummary_InvoicesTab.Name = "TabItemBillingSummary_InvoicesTab"
            Me.TabItemBillingSummary_InvoicesTab.Text = "Invoices"
            '
            'TabControlPanelDocumentsTab_Documents
            '
            Me.TabControlPanelDocumentsTab_Documents.Controls.Add(Me.DocumentManagerControlDocuments_InvoiceDocuments)
            Me.TabControlPanelDocumentsTab_Documents.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelDocumentsTab_Documents.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelDocumentsTab_Documents.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelDocumentsTab_Documents.Name = "TabControlPanelDocumentsTab_Documents"
            Me.TabControlPanelDocumentsTab_Documents.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelDocumentsTab_Documents.Size = New System.Drawing.Size(975, 467)
            Me.TabControlPanelDocumentsTab_Documents.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDocumentsTab_Documents.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDocumentsTab_Documents.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelDocumentsTab_Documents.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelDocumentsTab_Documents.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelDocumentsTab_Documents.Style.GradientAngle = 90
            Me.TabControlPanelDocumentsTab_Documents.TabIndex = 11
            Me.TabControlPanelDocumentsTab_Documents.TabItem = Me.TabItemBillingSummary_DocumentsTab
            '
            'DocumentManagerControlDocuments_InvoiceDocuments
            '
            Me.DocumentManagerControlDocuments_InvoiceDocuments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DocumentManagerControlDocuments_InvoiceDocuments.Location = New System.Drawing.Point(3, 4)
            Me.DocumentManagerControlDocuments_InvoiceDocuments.Margin = New System.Windows.Forms.Padding(4)
            Me.DocumentManagerControlDocuments_InvoiceDocuments.Name = "DocumentManagerControlDocuments_InvoiceDocuments"
            Me.DocumentManagerControlDocuments_InvoiceDocuments.Size = New System.Drawing.Size(969, 459)
            Me.DocumentManagerControlDocuments_InvoiceDocuments.TabIndex = 1
            '
            'TabItemBillingSummary_DocumentsTab
            '
            Me.TabItemBillingSummary_DocumentsTab.AttachedControl = Me.TabControlPanelDocumentsTab_Documents
            Me.TabItemBillingSummary_DocumentsTab.Name = "TabItemBillingSummary_DocumentsTab"
            Me.TabItemBillingSummary_DocumentsTab.Text = "Documents"
            '
            'BillingCommandCenterBillingHistoryDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(992, 730)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "BillingCommandCenterBillingHistoryDialog"
            Me.Text = "Billing History"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.TabControlPanel_BillingSummary, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanel_BillingSummary.ResumeLayout(False)
            Me.TabControlPanelJournalEntriesTab_JournalEntries.ResumeLayout(False)
            Me.TabControlPanelInvoicesTab_Invoices.ResumeLayout(False)
            Me.TabControlPanelDocumentsTab_Documents.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents LabelPanel_JobComponentValue As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelPanel_JobValue As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelPanel_JobComponent As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelPanel_Job As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents RibbonBarOptions_Filter As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemFilter_All As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemFilter_SelectedLineItem As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Documents As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemDocuments_Download As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents TabControlPanel_BillingSummary As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelInvoicesTab_Invoices As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewPanel_Invoices As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TabItemBillingSummary_InvoicesTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelDocumentsTab_Documents As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DocumentManagerControlDocuments_InvoiceDocuments As AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl
        Friend WithEvents TabItemBillingSummary_DocumentsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents ButtonItemActions_Export As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents DataGridViewForm_Export As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TabControlPanelJournalEntriesTab_JournalEntries As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemBillingSummary_JournalEntries As DevComponents.DotNetBar.TabItem
        Friend WithEvents DataGridViewPanel_JournalEntries As WinForm.Presentation.Controls.DataGridView
    End Class

End Namespace