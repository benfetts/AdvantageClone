Namespace FinanceAndAccounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ServiceFeeReconciliationReportForm
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseRibbonForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ServiceFeeReconciliationReportForm))
            Me.RibbonBarOptions_Navigation = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemNavigation_First = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemNavigation_Previous = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemNavigation_Next = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemNavigation_Last = New DevComponents.DotNetBar.ButtonItem()
            Me.LabelForm_ProductCommissionVariance = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_StandardFeeVariance = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_MediaCommissionVariance = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_TotalsVariance = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_TotalsTimePosted = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_MediaCommissionTimePosted = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_ProductCommissionTimePosted = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_StandardFeeTimePosted = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_TotalsFeeBilled = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_MediaCommissionFeeBuild = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_ProductCommissionFeeBilled = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_StandardFeeBilled = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_RowTotals = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_RowMediaCommission = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_RowProductCommission = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_RowStandardFee = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_ColumnVariance = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_ColumnTimePosted = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_ColumnFeeBilled = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_ProductDescription = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_DivisionDescription = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_ClientDescription = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Product = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Division = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Client = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_FeeTimePosted = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DataGridViewForm_ServiceFees = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.LabelForm_FeesBilled = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.PanelForm_ReportSummary = New System.Windows.Forms.Panel()
            Me.LabelForm_ReconcileIndicator = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.RibbonBarOptions_Filter = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemFilter_ShowFilterEditor = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemFilter_ShowAutoFilterRow = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_View = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainerView_ViewLeft = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemViewLeft_AllowCellMerging = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemViewLeft_ShowViewCaption = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemViewLeft_ShowGroupByBox = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_QuickCustomize = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemQuickCustomize_Columns = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Report = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemReport_LoadTemplate = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemReport_Templates = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemReport_Save = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemReport_SaveAs = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonTabItemMainRibbon_Printing = New DevComponents.DotNetBar.RibbonTabItem()
            Me.RibbonPanelPrinting_PrintingPanel = New DevComponents.DotNetBar.RibbonPanel()
            Me.RibbonBarPrinting_Options = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainerOptions_OptionsLeft = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemOptionsLeft_AutoSizeColumnsToPage = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemOptionsLeft_PrintFilterInfo = New DevComponents.DotNetBar.ButtonItem()
            Me.ItemContainerOptions_OptionsMiddle = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemOptionsMiddle_PrintHeader = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemOptionsMiddle_PrintFooter = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemOptionsMiddle_PrintGroupFooter = New DevComponents.DotNetBar.ButtonItem()
            Me.ItemContainerOptions_OptionsRight = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemOptionsRight_PrintSelectedRowsOnly = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarPrinting_Printing = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemPrinting_PrintGrid = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemPrinting_PrintSelectedReport = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemPrinting_PrintFullReport = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarFilePanel_Reconcile = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemReconcile_Reconcile = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemReconcile_Unreconcile = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemReconcile_SelectAll = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemReconcile_DeselectAll = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_ReportSummary.SuspendLayout()
            Me.RibbonPanelPrinting_PrintingPanel.SuspendLayout()
            Me.SuspendLayout()
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Controls.Add(Me.RibbonPanelPrinting_PrintingPanel)
            Me.RibbonControlForm_MainRibbon.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.RibbonTabItemMainRibbon_Printing})
            Me.RibbonControlForm_MainRibbon.Margin = New System.Windows.Forms.Padding(4)
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(1064, 154)
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
            Me.RibbonControlForm_MainRibbon.Controls.SetChildIndex(Me.RibbonPanelPrinting_PrintingPanel, 0)
            Me.RibbonControlForm_MainRibbon.Controls.SetChildIndex(Me.RibbonPanelFile_FilePanel, 0)
            '
            'RibbonPanelFile_FilePanel
            '
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Filter)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_View)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_QuickCustomize)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Report)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarFilePanel_Reconcile)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Navigation)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Margin = New System.Windows.Forms.Padding(4)
            Me.RibbonPanelFile_FilePanel.Padding = New System.Windows.Forms.Padding(4, 0, 4, 4)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(1064, 95)
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
            Me.RibbonPanelFile_FilePanel.Visible = True
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFilePanel_System, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Navigation, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFilePanel_Reconcile, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Report, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_QuickCustomize, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_View, 0)
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
            Me.RibbonBarFilePanel_System.Location = New System.Drawing.Point(4, 0)
            Me.RibbonBarFilePanel_System.Margin = New System.Windows.Forms.Padding(4)
            Me.RibbonBarFilePanel_System.Size = New System.Drawing.Size(55, 91)
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
            'PanelForm_Form
            '
            Me.PanelForm_Form.Controls.Add(Me.DataGridViewForm_ServiceFees)
            Me.PanelForm_Form.Controls.Add(Me.PanelForm_ReportSummary)
            Me.PanelForm_Form.Size = New System.Drawing.Size(1064, 283)
            '
            'BarForm_StatusBar
            '
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 438)
            Me.BarForm_StatusBar.Margin = New System.Windows.Forms.Padding(4)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(1064, 18)
            '
            'RibbonBarOptions_Navigation
            '
            Me.RibbonBarOptions_Navigation.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Navigation.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Navigation.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Navigation.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Navigation.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Navigation.DragDropSupport = True
            Me.RibbonBarOptions_Navigation.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemNavigation_First, Me.ButtonItemNavigation_Previous, Me.ButtonItemNavigation_Next, Me.ButtonItemNavigation_Last})
            Me.RibbonBarOptions_Navigation.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Navigation.Location = New System.Drawing.Point(59, 0)
            Me.RibbonBarOptions_Navigation.Name = "RibbonBarOptions_Navigation"
            Me.RibbonBarOptions_Navigation.SecurityEnabled = True
            Me.RibbonBarOptions_Navigation.Size = New System.Drawing.Size(179, 91)
            Me.RibbonBarOptions_Navigation.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Navigation.TabIndex = 4
            Me.RibbonBarOptions_Navigation.Text = "Navigation"
            '
            '
            '
            Me.RibbonBarOptions_Navigation.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Navigation.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Navigation.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemNavigation_First
            '
            Me.ButtonItemNavigation_First.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemNavigation_First.Enabled = False
            Me.ButtonItemNavigation_First.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemNavigation_First.Name = "ButtonItemNavigation_First"
            Me.ButtonItemNavigation_First.RibbonWordWrap = False
            Me.ButtonItemNavigation_First.Stretch = True
            Me.ButtonItemNavigation_First.SubItemsExpandWidth = 14
            Me.ButtonItemNavigation_First.Text = "First"
            '
            'ButtonItemNavigation_Previous
            '
            Me.ButtonItemNavigation_Previous.BeginGroup = True
            Me.ButtonItemNavigation_Previous.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemNavigation_Previous.Enabled = False
            Me.ButtonItemNavigation_Previous.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemNavigation_Previous.Name = "ButtonItemNavigation_Previous"
            Me.ButtonItemNavigation_Previous.RibbonWordWrap = False
            Me.ButtonItemNavigation_Previous.Stretch = True
            Me.ButtonItemNavigation_Previous.SubItemsExpandWidth = 14
            Me.ButtonItemNavigation_Previous.Text = "Previous"
            '
            'ButtonItemNavigation_Next
            '
            Me.ButtonItemNavigation_Next.BeginGroup = True
            Me.ButtonItemNavigation_Next.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemNavigation_Next.Enabled = False
            Me.ButtonItemNavigation_Next.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemNavigation_Next.Name = "ButtonItemNavigation_Next"
            Me.ButtonItemNavigation_Next.RibbonWordWrap = False
            Me.ButtonItemNavigation_Next.Stretch = True
            Me.ButtonItemNavigation_Next.SubItemsExpandWidth = 14
            Me.ButtonItemNavigation_Next.Text = "Next"
            '
            'ButtonItemNavigation_Last
            '
            Me.ButtonItemNavigation_Last.BeginGroup = True
            Me.ButtonItemNavigation_Last.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemNavigation_Last.Enabled = False
            Me.ButtonItemNavigation_Last.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemNavigation_Last.Name = "ButtonItemNavigation_Last"
            Me.ButtonItemNavigation_Last.RibbonWordWrap = False
            Me.ButtonItemNavigation_Last.Stretch = True
            Me.ButtonItemNavigation_Last.SubItemsExpandWidth = 14
            Me.ButtonItemNavigation_Last.Text = "Last"
            '
            'LabelForm_ProductCommissionVariance
            '
            Me.LabelForm_ProductCommissionVariance.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_ProductCommissionVariance.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_ProductCommissionVariance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_ProductCommissionVariance.Location = New System.Drawing.Point(916, 58)
            Me.LabelForm_ProductCommissionVariance.Name = "LabelForm_ProductCommissionVariance"
            Me.LabelForm_ProductCommissionVariance.Size = New System.Drawing.Size(144, 20)
            Me.LabelForm_ProductCommissionVariance.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ProductCommissionVariance.TabIndex = 67
            Me.LabelForm_ProductCommissionVariance.Text = "0.00"
            Me.LabelForm_ProductCommissionVariance.TextAlignment = System.Drawing.StringAlignment.Far
            '
            'LabelForm_StandardFeeVariance
            '
            Me.LabelForm_StandardFeeVariance.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_StandardFeeVariance.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_StandardFeeVariance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_StandardFeeVariance.Location = New System.Drawing.Point(916, 32)
            Me.LabelForm_StandardFeeVariance.Name = "LabelForm_StandardFeeVariance"
            Me.LabelForm_StandardFeeVariance.Size = New System.Drawing.Size(144, 20)
            Me.LabelForm_StandardFeeVariance.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_StandardFeeVariance.TabIndex = 66
            Me.LabelForm_StandardFeeVariance.Text = "0.00"
            Me.LabelForm_StandardFeeVariance.TextAlignment = System.Drawing.StringAlignment.Far
            '
            'LabelForm_MediaCommissionVariance
            '
            Me.LabelForm_MediaCommissionVariance.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_MediaCommissionVariance.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_MediaCommissionVariance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_MediaCommissionVariance.Location = New System.Drawing.Point(916, 84)
            Me.LabelForm_MediaCommissionVariance.Name = "LabelForm_MediaCommissionVariance"
            Me.LabelForm_MediaCommissionVariance.Size = New System.Drawing.Size(144, 20)
            Me.LabelForm_MediaCommissionVariance.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_MediaCommissionVariance.TabIndex = 65
            Me.LabelForm_MediaCommissionVariance.Text = "0.00"
            Me.LabelForm_MediaCommissionVariance.TextAlignment = System.Drawing.StringAlignment.Far
            '
            'LabelForm_TotalsVariance
            '
            Me.LabelForm_TotalsVariance.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_TotalsVariance.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_TotalsVariance.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_TotalsVariance.BackgroundStyle.BorderTopColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_TotalsVariance.BackgroundStyle.BorderTopWidth = 1
            Me.LabelForm_TotalsVariance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_TotalsVariance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelForm_TotalsVariance.Location = New System.Drawing.Point(916, 110)
            Me.LabelForm_TotalsVariance.Name = "LabelForm_TotalsVariance"
            Me.LabelForm_TotalsVariance.Size = New System.Drawing.Size(144, 20)
            Me.LabelForm_TotalsVariance.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_TotalsVariance.TabIndex = 64
            Me.LabelForm_TotalsVariance.Text = "0.00"
            Me.LabelForm_TotalsVariance.TextAlignment = System.Drawing.StringAlignment.Far
            '
            'LabelForm_TotalsTimePosted
            '
            Me.LabelForm_TotalsTimePosted.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_TotalsTimePosted.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_TotalsTimePosted.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_TotalsTimePosted.BackgroundStyle.BorderTopColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_TotalsTimePosted.BackgroundStyle.BorderTopWidth = 1
            Me.LabelForm_TotalsTimePosted.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_TotalsTimePosted.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelForm_TotalsTimePosted.Location = New System.Drawing.Point(766, 110)
            Me.LabelForm_TotalsTimePosted.Name = "LabelForm_TotalsTimePosted"
            Me.LabelForm_TotalsTimePosted.Size = New System.Drawing.Size(144, 20)
            Me.LabelForm_TotalsTimePosted.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_TotalsTimePosted.TabIndex = 63
            Me.LabelForm_TotalsTimePosted.Text = "0.00"
            Me.LabelForm_TotalsTimePosted.TextAlignment = System.Drawing.StringAlignment.Far
            '
            'LabelForm_MediaCommissionTimePosted
            '
            Me.LabelForm_MediaCommissionTimePosted.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_MediaCommissionTimePosted.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_MediaCommissionTimePosted.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_MediaCommissionTimePosted.Location = New System.Drawing.Point(766, 84)
            Me.LabelForm_MediaCommissionTimePosted.Name = "LabelForm_MediaCommissionTimePosted"
            Me.LabelForm_MediaCommissionTimePosted.Size = New System.Drawing.Size(144, 20)
            Me.LabelForm_MediaCommissionTimePosted.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_MediaCommissionTimePosted.TabIndex = 62
            Me.LabelForm_MediaCommissionTimePosted.Text = "0.00"
            Me.LabelForm_MediaCommissionTimePosted.TextAlignment = System.Drawing.StringAlignment.Far
            '
            'LabelForm_ProductCommissionTimePosted
            '
            Me.LabelForm_ProductCommissionTimePosted.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_ProductCommissionTimePosted.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_ProductCommissionTimePosted.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_ProductCommissionTimePosted.Location = New System.Drawing.Point(766, 58)
            Me.LabelForm_ProductCommissionTimePosted.Name = "LabelForm_ProductCommissionTimePosted"
            Me.LabelForm_ProductCommissionTimePosted.Size = New System.Drawing.Size(144, 20)
            Me.LabelForm_ProductCommissionTimePosted.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ProductCommissionTimePosted.TabIndex = 61
            Me.LabelForm_ProductCommissionTimePosted.Text = "0.00"
            Me.LabelForm_ProductCommissionTimePosted.TextAlignment = System.Drawing.StringAlignment.Far
            '
            'LabelForm_StandardFeeTimePosted
            '
            Me.LabelForm_StandardFeeTimePosted.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_StandardFeeTimePosted.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_StandardFeeTimePosted.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_StandardFeeTimePosted.Location = New System.Drawing.Point(766, 32)
            Me.LabelForm_StandardFeeTimePosted.Name = "LabelForm_StandardFeeTimePosted"
            Me.LabelForm_StandardFeeTimePosted.Size = New System.Drawing.Size(144, 20)
            Me.LabelForm_StandardFeeTimePosted.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_StandardFeeTimePosted.TabIndex = 60
            Me.LabelForm_StandardFeeTimePosted.Text = "0.00"
            Me.LabelForm_StandardFeeTimePosted.TextAlignment = System.Drawing.StringAlignment.Far
            '
            'LabelForm_TotalsFeeBilled
            '
            Me.LabelForm_TotalsFeeBilled.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_TotalsFeeBilled.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_TotalsFeeBilled.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_TotalsFeeBilled.BackgroundStyle.BorderTopColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_TotalsFeeBilled.BackgroundStyle.BorderTopWidth = 1
            Me.LabelForm_TotalsFeeBilled.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_TotalsFeeBilled.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelForm_TotalsFeeBilled.Location = New System.Drawing.Point(616, 110)
            Me.LabelForm_TotalsFeeBilled.Name = "LabelForm_TotalsFeeBilled"
            Me.LabelForm_TotalsFeeBilled.Size = New System.Drawing.Size(144, 20)
            Me.LabelForm_TotalsFeeBilled.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_TotalsFeeBilled.TabIndex = 59
            Me.LabelForm_TotalsFeeBilled.Text = "0.00"
            Me.LabelForm_TotalsFeeBilled.TextAlignment = System.Drawing.StringAlignment.Far
            '
            'LabelForm_MediaCommissionFeeBuild
            '
            Me.LabelForm_MediaCommissionFeeBuild.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_MediaCommissionFeeBuild.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_MediaCommissionFeeBuild.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_MediaCommissionFeeBuild.Location = New System.Drawing.Point(616, 84)
            Me.LabelForm_MediaCommissionFeeBuild.Name = "LabelForm_MediaCommissionFeeBuild"
            Me.LabelForm_MediaCommissionFeeBuild.Size = New System.Drawing.Size(144, 20)
            Me.LabelForm_MediaCommissionFeeBuild.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_MediaCommissionFeeBuild.TabIndex = 58
            Me.LabelForm_MediaCommissionFeeBuild.Text = "0.00"
            Me.LabelForm_MediaCommissionFeeBuild.TextAlignment = System.Drawing.StringAlignment.Far
            '
            'LabelForm_ProductCommissionFeeBilled
            '
            Me.LabelForm_ProductCommissionFeeBilled.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_ProductCommissionFeeBilled.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_ProductCommissionFeeBilled.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_ProductCommissionFeeBilled.Location = New System.Drawing.Point(616, 58)
            Me.LabelForm_ProductCommissionFeeBilled.Name = "LabelForm_ProductCommissionFeeBilled"
            Me.LabelForm_ProductCommissionFeeBilled.Size = New System.Drawing.Size(144, 20)
            Me.LabelForm_ProductCommissionFeeBilled.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ProductCommissionFeeBilled.TabIndex = 57
            Me.LabelForm_ProductCommissionFeeBilled.Text = "0.00"
            Me.LabelForm_ProductCommissionFeeBilled.TextAlignment = System.Drawing.StringAlignment.Far
            '
            'LabelForm_StandardFeeBilled
            '
            Me.LabelForm_StandardFeeBilled.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_StandardFeeBilled.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_StandardFeeBilled.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_StandardFeeBilled.Location = New System.Drawing.Point(616, 32)
            Me.LabelForm_StandardFeeBilled.Name = "LabelForm_StandardFeeBilled"
            Me.LabelForm_StandardFeeBilled.Size = New System.Drawing.Size(144, 20)
            Me.LabelForm_StandardFeeBilled.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_StandardFeeBilled.TabIndex = 56
            Me.LabelForm_StandardFeeBilled.Text = "0.00"
            Me.LabelForm_StandardFeeBilled.TextAlignment = System.Drawing.StringAlignment.Far
            '
            'LabelForm_RowTotals
            '
            Me.LabelForm_RowTotals.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_RowTotals.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_RowTotals.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_RowTotals.BackgroundStyle.BorderTopColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_RowTotals.BackgroundStyle.BorderTopWidth = 1
            Me.LabelForm_RowTotals.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_RowTotals.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelForm_RowTotals.Location = New System.Drawing.Point(466, 110)
            Me.LabelForm_RowTotals.Name = "LabelForm_RowTotals"
            Me.LabelForm_RowTotals.Size = New System.Drawing.Size(144, 20)
            Me.LabelForm_RowTotals.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_RowTotals.TabIndex = 55
            Me.LabelForm_RowTotals.Text = "Totals:"
            Me.LabelForm_RowTotals.TextAlignment = System.Drawing.StringAlignment.Far
            '
            'LabelForm_RowMediaCommission
            '
            Me.LabelForm_RowMediaCommission.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_RowMediaCommission.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_RowMediaCommission.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_RowMediaCommission.Location = New System.Drawing.Point(466, 84)
            Me.LabelForm_RowMediaCommission.Name = "LabelForm_RowMediaCommission"
            Me.LabelForm_RowMediaCommission.Size = New System.Drawing.Size(144, 20)
            Me.LabelForm_RowMediaCommission.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_RowMediaCommission.TabIndex = 54
            Me.LabelForm_RowMediaCommission.Text = "Media Commission:"
            Me.LabelForm_RowMediaCommission.TextAlignment = System.Drawing.StringAlignment.Far
            '
            'LabelForm_RowProductCommission
            '
            Me.LabelForm_RowProductCommission.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_RowProductCommission.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_RowProductCommission.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_RowProductCommission.Location = New System.Drawing.Point(466, 58)
            Me.LabelForm_RowProductCommission.Name = "LabelForm_RowProductCommission"
            Me.LabelForm_RowProductCommission.Size = New System.Drawing.Size(144, 20)
            Me.LabelForm_RowProductCommission.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_RowProductCommission.TabIndex = 53
            Me.LabelForm_RowProductCommission.Text = "Production Commission:"
            Me.LabelForm_RowProductCommission.TextAlignment = System.Drawing.StringAlignment.Far
            '
            'LabelForm_RowStandardFee
            '
            Me.LabelForm_RowStandardFee.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_RowStandardFee.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_RowStandardFee.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_RowStandardFee.Location = New System.Drawing.Point(466, 32)
            Me.LabelForm_RowStandardFee.Name = "LabelForm_RowStandardFee"
            Me.LabelForm_RowStandardFee.Size = New System.Drawing.Size(144, 20)
            Me.LabelForm_RowStandardFee.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_RowStandardFee.TabIndex = 52
            Me.LabelForm_RowStandardFee.Text = "Standard Fee:"
            Me.LabelForm_RowStandardFee.TextAlignment = System.Drawing.StringAlignment.Far
            '
            'LabelForm_ColumnVariance
            '
            Me.LabelForm_ColumnVariance.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_ColumnVariance.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_ColumnVariance.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_ColumnVariance.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_ColumnVariance.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_ColumnVariance.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_ColumnVariance.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_ColumnVariance.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_ColumnVariance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_ColumnVariance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelForm_ColumnVariance.Location = New System.Drawing.Point(916, 6)
            Me.LabelForm_ColumnVariance.Name = "LabelForm_ColumnVariance"
            Me.LabelForm_ColumnVariance.Size = New System.Drawing.Size(144, 20)
            Me.LabelForm_ColumnVariance.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ColumnVariance.TabIndex = 51
            Me.LabelForm_ColumnVariance.Text = "Variance"
            Me.LabelForm_ColumnVariance.TextAlignment = System.Drawing.StringAlignment.Far
            '
            'LabelForm_ColumnTimePosted
            '
            Me.LabelForm_ColumnTimePosted.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_ColumnTimePosted.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_ColumnTimePosted.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_ColumnTimePosted.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_ColumnTimePosted.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_ColumnTimePosted.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_ColumnTimePosted.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_ColumnTimePosted.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_ColumnTimePosted.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_ColumnTimePosted.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelForm_ColumnTimePosted.Location = New System.Drawing.Point(766, 6)
            Me.LabelForm_ColumnTimePosted.Name = "LabelForm_ColumnTimePosted"
            Me.LabelForm_ColumnTimePosted.Size = New System.Drawing.Size(144, 20)
            Me.LabelForm_ColumnTimePosted.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ColumnTimePosted.TabIndex = 50
            Me.LabelForm_ColumnTimePosted.Text = "Time Posted"
            Me.LabelForm_ColumnTimePosted.TextAlignment = System.Drawing.StringAlignment.Far
            '
            'LabelForm_ColumnFeeBilled
            '
            Me.LabelForm_ColumnFeeBilled.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_ColumnFeeBilled.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_ColumnFeeBilled.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_ColumnFeeBilled.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_ColumnFeeBilled.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_ColumnFeeBilled.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_ColumnFeeBilled.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_ColumnFeeBilled.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_ColumnFeeBilled.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_ColumnFeeBilled.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelForm_ColumnFeeBilled.Location = New System.Drawing.Point(616, 6)
            Me.LabelForm_ColumnFeeBilled.Name = "LabelForm_ColumnFeeBilled"
            Me.LabelForm_ColumnFeeBilled.Size = New System.Drawing.Size(144, 20)
            Me.LabelForm_ColumnFeeBilled.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ColumnFeeBilled.TabIndex = 49
            Me.LabelForm_ColumnFeeBilled.Text = "Fee Billed"
            Me.LabelForm_ColumnFeeBilled.TextAlignment = System.Drawing.StringAlignment.Far
            '
            'LabelForm_ProductDescription
            '
            Me.LabelForm_ProductDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_ProductDescription.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_ProductDescription.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_ProductDescription.Location = New System.Drawing.Point(56, 110)
            Me.LabelForm_ProductDescription.Name = "LabelForm_ProductDescription"
            Me.LabelForm_ProductDescription.Size = New System.Drawing.Size(404, 20)
            Me.LabelForm_ProductDescription.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ProductDescription.TabIndex = 48
            '
            'LabelForm_DivisionDescription
            '
            Me.LabelForm_DivisionDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_DivisionDescription.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_DivisionDescription.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_DivisionDescription.Location = New System.Drawing.Point(56, 84)
            Me.LabelForm_DivisionDescription.Name = "LabelForm_DivisionDescription"
            Me.LabelForm_DivisionDescription.Size = New System.Drawing.Size(404, 20)
            Me.LabelForm_DivisionDescription.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_DivisionDescription.TabIndex = 47
            '
            'LabelForm_ClientDescription
            '
            Me.LabelForm_ClientDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_ClientDescription.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_ClientDescription.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_ClientDescription.Location = New System.Drawing.Point(56, 58)
            Me.LabelForm_ClientDescription.Name = "LabelForm_ClientDescription"
            Me.LabelForm_ClientDescription.Size = New System.Drawing.Size(404, 20)
            Me.LabelForm_ClientDescription.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ClientDescription.TabIndex = 46
            '
            'LabelForm_Product
            '
            Me.LabelForm_Product.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Product.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Product.Location = New System.Drawing.Point(4, 110)
            Me.LabelForm_Product.Name = "LabelForm_Product"
            Me.LabelForm_Product.Size = New System.Drawing.Size(46, 20)
            Me.LabelForm_Product.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Product.TabIndex = 45
            Me.LabelForm_Product.Text = "Product:"
            '
            'LabelForm_Division
            '
            Me.LabelForm_Division.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Division.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Division.Location = New System.Drawing.Point(4, 84)
            Me.LabelForm_Division.Name = "LabelForm_Division"
            Me.LabelForm_Division.Size = New System.Drawing.Size(46, 20)
            Me.LabelForm_Division.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Division.TabIndex = 44
            Me.LabelForm_Division.Text = "Division:"
            '
            'LabelForm_Client
            '
            Me.LabelForm_Client.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Client.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Client.Location = New System.Drawing.Point(4, 58)
            Me.LabelForm_Client.Name = "LabelForm_Client"
            Me.LabelForm_Client.Size = New System.Drawing.Size(46, 20)
            Me.LabelForm_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Client.TabIndex = 43
            Me.LabelForm_Client.Text = "Client:"
            '
            'LabelForm_FeeTimePosted
            '
            Me.LabelForm_FeeTimePosted.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_FeeTimePosted.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_FeeTimePosted.Location = New System.Drawing.Point(4, 32)
            Me.LabelForm_FeeTimePosted.Name = "LabelForm_FeeTimePosted"
            Me.LabelForm_FeeTimePosted.Size = New System.Drawing.Size(287, 20)
            Me.LabelForm_FeeTimePosted.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_FeeTimePosted.TabIndex = 42
            Me.LabelForm_FeeTimePosted.Text = "Fee Time Posted from {0} to {1}"
            '
            'DataGridViewForm_ServiceFees
            '
            Me.DataGridViewForm_ServiceFees.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_ServiceFees.AllowDragAndDrop = False
            Me.DataGridViewForm_ServiceFees.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_ServiceFees.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_ServiceFees.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_ServiceFees.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_ServiceFees.AutoFilterLookupColumns = False
            Me.DataGridViewForm_ServiceFees.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_ServiceFees.AutoUpdateViewCaption = True
            Me.DataGridViewForm_ServiceFees.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewForm_ServiceFees.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_ServiceFees.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
            Me.DataGridViewForm_ServiceFees.ItemDescription = ""
            Me.DataGridViewForm_ServiceFees.Location = New System.Drawing.Point(4, 142)
            Me.DataGridViewForm_ServiceFees.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewForm_ServiceFees.MultiSelect = True
            Me.DataGridViewForm_ServiceFees.Name = "DataGridViewForm_ServiceFees"
            Me.DataGridViewForm_ServiceFees.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_ServiceFees.RunStandardValidation = True
            Me.DataGridViewForm_ServiceFees.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_ServiceFees.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_ServiceFees.Size = New System.Drawing.Size(1056, 137)
            Me.DataGridViewForm_ServiceFees.TabIndex = 41
            Me.DataGridViewForm_ServiceFees.UseEmbeddedNavigator = False
            Me.DataGridViewForm_ServiceFees.ViewCaptionHeight = -1
            '
            'LabelForm_FeesBilled
            '
            Me.LabelForm_FeesBilled.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_FeesBilled.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_FeesBilled.Location = New System.Drawing.Point(4, 6)
            Me.LabelForm_FeesBilled.Name = "LabelForm_FeesBilled"
            Me.LabelForm_FeesBilled.Size = New System.Drawing.Size(287, 20)
            Me.LabelForm_FeesBilled.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_FeesBilled.TabIndex = 40
            Me.LabelForm_FeesBilled.Text = "Fees Billed from {0} to {1}"
            '
            'PanelForm_ReportSummary
            '
            Me.PanelForm_ReportSummary.Controls.Add(Me.LabelForm_ReconcileIndicator)
            Me.PanelForm_ReportSummary.Controls.Add(Me.LabelForm_FeesBilled)
            Me.PanelForm_ReportSummary.Controls.Add(Me.LabelForm_FeeTimePosted)
            Me.PanelForm_ReportSummary.Controls.Add(Me.LabelForm_ColumnVariance)
            Me.PanelForm_ReportSummary.Controls.Add(Me.LabelForm_Client)
            Me.PanelForm_ReportSummary.Controls.Add(Me.LabelForm_ProductCommissionVariance)
            Me.PanelForm_ReportSummary.Controls.Add(Me.LabelForm_Division)
            Me.PanelForm_ReportSummary.Controls.Add(Me.LabelForm_StandardFeeVariance)
            Me.PanelForm_ReportSummary.Controls.Add(Me.LabelForm_Product)
            Me.PanelForm_ReportSummary.Controls.Add(Me.LabelForm_MediaCommissionVariance)
            Me.PanelForm_ReportSummary.Controls.Add(Me.LabelForm_ClientDescription)
            Me.PanelForm_ReportSummary.Controls.Add(Me.LabelForm_TotalsVariance)
            Me.PanelForm_ReportSummary.Controls.Add(Me.LabelForm_DivisionDescription)
            Me.PanelForm_ReportSummary.Controls.Add(Me.LabelForm_TotalsTimePosted)
            Me.PanelForm_ReportSummary.Controls.Add(Me.LabelForm_ProductDescription)
            Me.PanelForm_ReportSummary.Controls.Add(Me.LabelForm_MediaCommissionTimePosted)
            Me.PanelForm_ReportSummary.Controls.Add(Me.LabelForm_ColumnFeeBilled)
            Me.PanelForm_ReportSummary.Controls.Add(Me.LabelForm_ProductCommissionTimePosted)
            Me.PanelForm_ReportSummary.Controls.Add(Me.LabelForm_ColumnTimePosted)
            Me.PanelForm_ReportSummary.Controls.Add(Me.LabelForm_StandardFeeTimePosted)
            Me.PanelForm_ReportSummary.Controls.Add(Me.LabelForm_RowStandardFee)
            Me.PanelForm_ReportSummary.Controls.Add(Me.LabelForm_TotalsFeeBilled)
            Me.PanelForm_ReportSummary.Controls.Add(Me.LabelForm_RowProductCommission)
            Me.PanelForm_ReportSummary.Controls.Add(Me.LabelForm_MediaCommissionFeeBuild)
            Me.PanelForm_ReportSummary.Controls.Add(Me.LabelForm_RowMediaCommission)
            Me.PanelForm_ReportSummary.Controls.Add(Me.LabelForm_ProductCommissionFeeBilled)
            Me.PanelForm_ReportSummary.Controls.Add(Me.LabelForm_RowTotals)
            Me.PanelForm_ReportSummary.Controls.Add(Me.LabelForm_StandardFeeBilled)
            Me.PanelForm_ReportSummary.Dock = System.Windows.Forms.DockStyle.Top
            Me.PanelForm_ReportSummary.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_ReportSummary.Name = "PanelForm_ReportSummary"
            Me.PanelForm_ReportSummary.Size = New System.Drawing.Size(1064, 139)
            Me.PanelForm_ReportSummary.TabIndex = 69
            '
            'LabelForm_ReconcileIndicator
            '
            Me.LabelForm_ReconcileIndicator.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_ReconcileIndicator.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_ReconcileIndicator.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_ReconcileIndicator.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelForm_ReconcileIndicator.Location = New System.Drawing.Point(297, 6)
            Me.LabelForm_ReconcileIndicator.Name = "LabelForm_ReconcileIndicator"
            Me.LabelForm_ReconcileIndicator.Size = New System.Drawing.Size(314, 20)
            Me.LabelForm_ReconcileIndicator.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ReconcileIndicator.TabIndex = 68
            Me.LabelForm_ReconcileIndicator.TextAlignment = System.Drawing.StringAlignment.Far
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
            Me.RibbonBarOptions_Filter.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemFilter_ShowFilterEditor, Me.ButtonItemFilter_ShowAutoFilterRow})
            Me.RibbonBarOptions_Filter.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.RibbonBarOptions_Filter.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Filter.Location = New System.Drawing.Point(966, 0)
            Me.RibbonBarOptions_Filter.Name = "RibbonBarOptions_Filter"
            Me.RibbonBarOptions_Filter.SecurityEnabled = True
            Me.RibbonBarOptions_Filter.Size = New System.Drawing.Size(120, 91)
            Me.RibbonBarOptions_Filter.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Filter.TabIndex = 9
            Me.RibbonBarOptions_Filter.Text = "Filter"
            '
            '
            '
            Me.RibbonBarOptions_Filter.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Filter.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Filter.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemFilter_ShowFilterEditor
            '
            Me.ButtonItemFilter_ShowFilterEditor.Name = "ButtonItemFilter_ShowFilterEditor"
            Me.ButtonItemFilter_ShowFilterEditor.SubItemsExpandWidth = 14
            Me.ButtonItemFilter_ShowFilterEditor.Text = "Show Filter Editor"
            '
            'ButtonItemFilter_ShowAutoFilterRow
            '
            Me.ButtonItemFilter_ShowAutoFilterRow.AutoCheckOnClick = True
            Me.ButtonItemFilter_ShowAutoFilterRow.Name = "ButtonItemFilter_ShowAutoFilterRow"
            Me.ButtonItemFilter_ShowAutoFilterRow.Stretch = True
            Me.ButtonItemFilter_ShowAutoFilterRow.SubItemsExpandWidth = 14
            Me.ButtonItemFilter_ShowAutoFilterRow.Text = "Show Auto Filter Row"
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
            Me.RibbonBarOptions_View.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerView_ViewLeft})
            Me.RibbonBarOptions_View.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_View.Location = New System.Drawing.Point(853, 0)
            Me.RibbonBarOptions_View.Name = "RibbonBarOptions_View"
            Me.RibbonBarOptions_View.SecurityEnabled = True
            Me.RibbonBarOptions_View.Size = New System.Drawing.Size(113, 91)
            Me.RibbonBarOptions_View.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_View.TabIndex = 8
            Me.RibbonBarOptions_View.Text = "View"
            '
            '
            '
            Me.RibbonBarOptions_View.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_View.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ItemContainerView_ViewLeft
            '
            '
            '
            '
            Me.ItemContainerView_ViewLeft.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerView_ViewLeft.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerView_ViewLeft.Name = "ItemContainerView_ViewLeft"
            Me.ItemContainerView_ViewLeft.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemViewLeft_AllowCellMerging, Me.ButtonItemViewLeft_ShowViewCaption, Me.ButtonItemViewLeft_ShowGroupByBox})
            '
            '
            '
            Me.ItemContainerView_ViewLeft.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemViewLeft_AllowCellMerging
            '
            Me.ButtonItemViewLeft_AllowCellMerging.AutoCheckOnClick = True
            Me.ButtonItemViewLeft_AllowCellMerging.Name = "ButtonItemViewLeft_AllowCellMerging"
            Me.ButtonItemViewLeft_AllowCellMerging.Stretch = True
            Me.ButtonItemViewLeft_AllowCellMerging.SubItemsExpandWidth = 14
            Me.ButtonItemViewLeft_AllowCellMerging.Text = "Allow Cell Merging"
            '
            'ButtonItemViewLeft_ShowViewCaption
            '
            Me.ButtonItemViewLeft_ShowViewCaption.AutoCheckOnClick = True
            Me.ButtonItemViewLeft_ShowViewCaption.Checked = True
            Me.ButtonItemViewLeft_ShowViewCaption.Name = "ButtonItemViewLeft_ShowViewCaption"
            Me.ButtonItemViewLeft_ShowViewCaption.SubItemsExpandWidth = 14
            Me.ButtonItemViewLeft_ShowViewCaption.Text = "Show View Caption"
            '
            'ButtonItemViewLeft_ShowGroupByBox
            '
            Me.ButtonItemViewLeft_ShowGroupByBox.AutoCheckOnClick = True
            Me.ButtonItemViewLeft_ShowGroupByBox.Name = "ButtonItemViewLeft_ShowGroupByBox"
            Me.ButtonItemViewLeft_ShowGroupByBox.Stretch = True
            Me.ButtonItemViewLeft_ShowGroupByBox.SubItemsExpandWidth = 14
            Me.ButtonItemViewLeft_ShowGroupByBox.Text = "Show Group By Box"
            '
            'RibbonBarOptions_QuickCustomize
            '
            Me.RibbonBarOptions_QuickCustomize.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_QuickCustomize.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_QuickCustomize.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_QuickCustomize.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_QuickCustomize.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_QuickCustomize.DragDropSupport = True
            Me.RibbonBarOptions_QuickCustomize.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_QuickCustomize.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemQuickCustomize_Columns})
            Me.RibbonBarOptions_QuickCustomize.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_QuickCustomize.Location = New System.Drawing.Point(753, 0)
            Me.RibbonBarOptions_QuickCustomize.Name = "RibbonBarOptions_QuickCustomize"
            Me.RibbonBarOptions_QuickCustomize.SecurityEnabled = True
            Me.RibbonBarOptions_QuickCustomize.Size = New System.Drawing.Size(100, 91)
            Me.RibbonBarOptions_QuickCustomize.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_QuickCustomize.TabIndex = 7
            Me.RibbonBarOptions_QuickCustomize.Text = "Quick Customize"
            '
            '
            '
            Me.RibbonBarOptions_QuickCustomize.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_QuickCustomize.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_QuickCustomize.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemQuickCustomize_Columns
            '
            Me.ButtonItemQuickCustomize_Columns.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemQuickCustomize_Columns.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemQuickCustomize_Columns.Name = "ButtonItemQuickCustomize_Columns"
            Me.ButtonItemQuickCustomize_Columns.SubItemsExpandWidth = 14
            Me.ButtonItemQuickCustomize_Columns.Text = "Columns"
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
            Me.RibbonBarOptions_Report.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemReport_LoadTemplate, Me.ButtonItemReport_Templates, Me.ButtonItemReport_Save, Me.ButtonItemReport_SaveAs})
            Me.RibbonBarOptions_Report.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Report.Location = New System.Drawing.Point(505, 0)
            Me.RibbonBarOptions_Report.Name = "RibbonBarOptions_Report"
            Me.RibbonBarOptions_Report.SecurityEnabled = True
            Me.RibbonBarOptions_Report.Size = New System.Drawing.Size(248, 91)
            Me.RibbonBarOptions_Report.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Report.TabIndex = 6
            Me.RibbonBarOptions_Report.Text = "Report"
            '
            '
            '
            Me.RibbonBarOptions_Report.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Report.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Report.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemReport_LoadTemplate
            '
            Me.ButtonItemReport_LoadTemplate.BeginGroup = True
            Me.ButtonItemReport_LoadTemplate.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemReport_LoadTemplate.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemReport_LoadTemplate.Name = "ButtonItemReport_LoadTemplate"
            Me.ButtonItemReport_LoadTemplate.RibbonWordWrap = False
            Me.ButtonItemReport_LoadTemplate.SubItemsExpandWidth = 14
            Me.ButtonItemReport_LoadTemplate.Text = "Load Template"
            '
            'ButtonItemReport_Templates
            '
            Me.ButtonItemReport_Templates.BeginGroup = True
            Me.ButtonItemReport_Templates.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemReport_Templates.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemReport_Templates.Name = "ButtonItemReport_Templates"
            Me.ButtonItemReport_Templates.RibbonWordWrap = False
            Me.ButtonItemReport_Templates.SubItemsExpandWidth = 14
            Me.ButtonItemReport_Templates.Text = "Templates"
            '
            'ButtonItemReport_Save
            '
            Me.ButtonItemReport_Save.BeginGroup = True
            Me.ButtonItemReport_Save.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemReport_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemReport_Save.Name = "ButtonItemReport_Save"
            Me.ButtonItemReport_Save.RibbonWordWrap = False
            Me.ButtonItemReport_Save.SubItemsExpandWidth = 14
            Me.ButtonItemReport_Save.Text = "Save"
            '
            'ButtonItemReport_SaveAs
            '
            Me.ButtonItemReport_SaveAs.BeginGroup = True
            Me.ButtonItemReport_SaveAs.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemReport_SaveAs.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemReport_SaveAs.Name = "ButtonItemReport_SaveAs"
            Me.ButtonItemReport_SaveAs.RibbonWordWrap = False
            Me.ButtonItemReport_SaveAs.SubItemsExpandWidth = 14
            Me.ButtonItemReport_SaveAs.Text = "Save As..."
            '
            'RibbonTabItemMainRibbon_Printing
            '
            Me.RibbonTabItemMainRibbon_Printing.Name = "RibbonTabItemMainRibbon_Printing"
            Me.RibbonTabItemMainRibbon_Printing.Panel = Me.RibbonPanelPrinting_PrintingPanel
            Me.RibbonTabItemMainRibbon_Printing.Text = "Printing"
            '
            'RibbonPanelPrinting_PrintingPanel
            '
            Me.RibbonPanelPrinting_PrintingPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonPanelPrinting_PrintingPanel.Controls.Add(Me.RibbonBarPrinting_Options)
            Me.RibbonPanelPrinting_PrintingPanel.Controls.Add(Me.RibbonBarPrinting_Printing)
            Me.RibbonPanelPrinting_PrintingPanel.Dock = System.Windows.Forms.DockStyle.Fill
            Me.RibbonPanelPrinting_PrintingPanel.Location = New System.Drawing.Point(0, 54)
            Me.RibbonPanelPrinting_PrintingPanel.Name = "RibbonPanelPrinting_PrintingPanel"
            Me.RibbonPanelPrinting_PrintingPanel.Padding = New System.Windows.Forms.Padding(3, 0, 3, 3)
            Me.RibbonPanelPrinting_PrintingPanel.Size = New System.Drawing.Size(1094, 98)
            '
            '
            '
            Me.RibbonPanelPrinting_PrintingPanel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonPanelPrinting_PrintingPanel.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonPanelPrinting_PrintingPanel.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonPanelPrinting_PrintingPanel.TabIndex = 2
            Me.RibbonPanelPrinting_PrintingPanel.Visible = False
            '
            'RibbonBarPrinting_Options
            '
            Me.RibbonBarPrinting_Options.AutoOverflowEnabled = False
            Me.RibbonBarPrinting_Options.AutoSizeItems = False
            '
            '
            '
            Me.RibbonBarPrinting_Options.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarPrinting_Options.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarPrinting_Options.ContainerControlProcessDialogKey = True
            Me.RibbonBarPrinting_Options.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarPrinting_Options.DragDropSupport = True
            Me.RibbonBarPrinting_Options.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerOptions_OptionsLeft, Me.ItemContainerOptions_OptionsMiddle, Me.ItemContainerOptions_OptionsRight})
            Me.RibbonBarPrinting_Options.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarPrinting_Options.Location = New System.Drawing.Point(283, 0)
            Me.RibbonBarPrinting_Options.Name = "RibbonBarPrinting_Options"
            Me.RibbonBarPrinting_Options.SecurityEnabled = True
            Me.RibbonBarPrinting_Options.Size = New System.Drawing.Size(382, 95)
            Me.RibbonBarPrinting_Options.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarPrinting_Options.TabIndex = 5
            Me.RibbonBarPrinting_Options.Text = "Options"
            '
            '
            '
            Me.RibbonBarPrinting_Options.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarPrinting_Options.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ItemContainerOptions_OptionsLeft
            '
            '
            '
            '
            Me.ItemContainerOptions_OptionsLeft.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerOptions_OptionsLeft.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerOptions_OptionsLeft.Name = "ItemContainerOptions_OptionsLeft"
            Me.ItemContainerOptions_OptionsLeft.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemOptionsLeft_AutoSizeColumnsToPage, Me.ButtonItemOptionsLeft_PrintFilterInfo})
            '
            '
            '
            Me.ItemContainerOptions_OptionsLeft.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerOptions_OptionsLeft.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemOptionsLeft_AutoSizeColumnsToPage
            '
            Me.ButtonItemOptionsLeft_AutoSizeColumnsToPage.AutoCheckOnClick = True
            Me.ButtonItemOptionsLeft_AutoSizeColumnsToPage.Checked = True
            Me.ButtonItemOptionsLeft_AutoSizeColumnsToPage.Name = "ButtonItemOptionsLeft_AutoSizeColumnsToPage"
            Me.ButtonItemOptionsLeft_AutoSizeColumnsToPage.Text = "Auto Size Columns To Page"
            '
            'ButtonItemOptionsLeft_PrintFilterInfo
            '
            Me.ButtonItemOptionsLeft_PrintFilterInfo.AutoCheckOnClick = True
            Me.ButtonItemOptionsLeft_PrintFilterInfo.Name = "ButtonItemOptionsLeft_PrintFilterInfo"
            Me.ButtonItemOptionsLeft_PrintFilterInfo.Text = "Print Filter Info"
            '
            'ItemContainerOptions_OptionsMiddle
            '
            '
            '
            '
            Me.ItemContainerOptions_OptionsMiddle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerOptions_OptionsMiddle.BeginGroup = True
            Me.ItemContainerOptions_OptionsMiddle.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerOptions_OptionsMiddle.Name = "ItemContainerOptions_OptionsMiddle"
            Me.ItemContainerOptions_OptionsMiddle.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemOptionsMiddle_PrintHeader, Me.ButtonItemOptionsMiddle_PrintFooter, Me.ButtonItemOptionsMiddle_PrintGroupFooter})
            '
            '
            '
            Me.ItemContainerOptions_OptionsMiddle.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemOptionsMiddle_PrintHeader
            '
            Me.ButtonItemOptionsMiddle_PrintHeader.AutoCheckOnClick = True
            Me.ButtonItemOptionsMiddle_PrintHeader.Checked = True
            Me.ButtonItemOptionsMiddle_PrintHeader.Name = "ButtonItemOptionsMiddle_PrintHeader"
            Me.ButtonItemOptionsMiddle_PrintHeader.Text = "Print Header"
            '
            'ButtonItemOptionsMiddle_PrintFooter
            '
            Me.ButtonItemOptionsMiddle_PrintFooter.AutoCheckOnClick = True
            Me.ButtonItemOptionsMiddle_PrintFooter.Checked = True
            Me.ButtonItemOptionsMiddle_PrintFooter.Name = "ButtonItemOptionsMiddle_PrintFooter"
            Me.ButtonItemOptionsMiddle_PrintFooter.Text = "Print Footer"
            '
            'ButtonItemOptionsMiddle_PrintGroupFooter
            '
            Me.ButtonItemOptionsMiddle_PrintGroupFooter.AutoCheckOnClick = True
            Me.ButtonItemOptionsMiddle_PrintGroupFooter.Checked = True
            Me.ButtonItemOptionsMiddle_PrintGroupFooter.Name = "ButtonItemOptionsMiddle_PrintGroupFooter"
            Me.ButtonItemOptionsMiddle_PrintGroupFooter.Text = "Print Group Footer"
            '
            'ItemContainerOptions_OptionsRight
            '
            '
            '
            '
            Me.ItemContainerOptions_OptionsRight.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerOptions_OptionsRight.BeginGroup = True
            Me.ItemContainerOptions_OptionsRight.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerOptions_OptionsRight.Name = "ItemContainerOptions_OptionsRight"
            Me.ItemContainerOptions_OptionsRight.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemOptionsRight_PrintSelectedRowsOnly})
            '
            '
            '
            Me.ItemContainerOptions_OptionsRight.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerOptions_OptionsRight.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemOptionsRight_PrintSelectedRowsOnly
            '
            Me.ButtonItemOptionsRight_PrintSelectedRowsOnly.AutoCheckOnClick = True
            Me.ButtonItemOptionsRight_PrintSelectedRowsOnly.Name = "ButtonItemOptionsRight_PrintSelectedRowsOnly"
            Me.ButtonItemOptionsRight_PrintSelectedRowsOnly.Text = "Print Selected Rows Only"
            '
            'RibbonBarPrinting_Printing
            '
            Me.RibbonBarPrinting_Printing.AutoOverflowEnabled = False
            Me.RibbonBarPrinting_Printing.AutoSizeItems = False
            '
            '
            '
            Me.RibbonBarPrinting_Printing.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarPrinting_Printing.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarPrinting_Printing.ContainerControlProcessDialogKey = True
            Me.RibbonBarPrinting_Printing.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarPrinting_Printing.DragDropSupport = True
            Me.RibbonBarPrinting_Printing.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemPrinting_PrintGrid, Me.ButtonItemPrinting_PrintSelectedReport, Me.ButtonItemPrinting_PrintFullReport})
            Me.RibbonBarPrinting_Printing.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarPrinting_Printing.Location = New System.Drawing.Point(3, 0)
            Me.RibbonBarPrinting_Printing.Name = "RibbonBarPrinting_Printing"
            Me.RibbonBarPrinting_Printing.SecurityEnabled = True
            Me.RibbonBarPrinting_Printing.Size = New System.Drawing.Size(280, 95)
            Me.RibbonBarPrinting_Printing.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarPrinting_Printing.TabIndex = 4
            Me.RibbonBarPrinting_Printing.Text = "Printing"
            '
            '
            '
            Me.RibbonBarPrinting_Printing.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarPrinting_Printing.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarPrinting_Printing.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemPrinting_PrintGrid
            '
            Me.ButtonItemPrinting_PrintGrid.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemPrinting_PrintGrid.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemPrinting_PrintGrid.Name = "ButtonItemPrinting_PrintGrid"
            Me.ButtonItemPrinting_PrintGrid.RibbonWordWrap = False
            Me.ButtonItemPrinting_PrintGrid.SubItemsExpandWidth = 14
            Me.ButtonItemPrinting_PrintGrid.Text = "Print Grid"
            '
            'ButtonItemPrinting_PrintSelectedReport
            '
            Me.ButtonItemPrinting_PrintSelectedReport.BeginGroup = True
            Me.ButtonItemPrinting_PrintSelectedReport.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemPrinting_PrintSelectedReport.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemPrinting_PrintSelectedReport.Name = "ButtonItemPrinting_PrintSelectedReport"
            Me.ButtonItemPrinting_PrintSelectedReport.RibbonWordWrap = False
            Me.ButtonItemPrinting_PrintSelectedReport.SubItemsExpandWidth = 14
            Me.ButtonItemPrinting_PrintSelectedReport.Text = "Print Selected Report"
            '
            'ButtonItemPrinting_PrintFullReport
            '
            Me.ButtonItemPrinting_PrintFullReport.BeginGroup = True
            Me.ButtonItemPrinting_PrintFullReport.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemPrinting_PrintFullReport.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemPrinting_PrintFullReport.Name = "ButtonItemPrinting_PrintFullReport"
            Me.ButtonItemPrinting_PrintFullReport.RibbonWordWrap = False
            Me.ButtonItemPrinting_PrintFullReport.SubItemsExpandWidth = 14
            Me.ButtonItemPrinting_PrintFullReport.Text = "Print Full Report"
            '
            'RibbonBarFilePanel_Reconcile
            '
            Me.RibbonBarFilePanel_Reconcile.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarFilePanel_Reconcile.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_Reconcile.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_Reconcile.ContainerControlProcessDialogKey = True
            Me.RibbonBarFilePanel_Reconcile.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarFilePanel_Reconcile.DragDropSupport = True
            Me.RibbonBarFilePanel_Reconcile.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemReconcile_Reconcile, Me.ButtonItemReconcile_Unreconcile, Me.ButtonItemReconcile_SelectAll, Me.ButtonItemReconcile_DeselectAll})
            Me.RibbonBarFilePanel_Reconcile.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarFilePanel_Reconcile.Location = New System.Drawing.Point(238, 0)
            Me.RibbonBarFilePanel_Reconcile.Name = "RibbonBarFilePanel_Reconcile"
            Me.RibbonBarFilePanel_Reconcile.SecurityEnabled = True
            Me.RibbonBarFilePanel_Reconcile.Size = New System.Drawing.Size(267, 91)
            Me.RibbonBarFilePanel_Reconcile.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarFilePanel_Reconcile.TabIndex = 10
            Me.RibbonBarFilePanel_Reconcile.Text = "Reconcile"
            '
            '
            '
            Me.RibbonBarFilePanel_Reconcile.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_Reconcile.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_Reconcile.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemReconcile_Reconcile
            '
            Me.ButtonItemReconcile_Reconcile.BeginGroup = True
            Me.ButtonItemReconcile_Reconcile.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemReconcile_Reconcile.Enabled = False
            Me.ButtonItemReconcile_Reconcile.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemReconcile_Reconcile.Name = "ButtonItemReconcile_Reconcile"
            Me.ButtonItemReconcile_Reconcile.RibbonWordWrap = False
            Me.ButtonItemReconcile_Reconcile.SubItemsExpandWidth = 14
            Me.ButtonItemReconcile_Reconcile.Text = "Reconcile"
            '
            'ButtonItemReconcile_Unreconcile
            '
            Me.ButtonItemReconcile_Unreconcile.BeginGroup = True
            Me.ButtonItemReconcile_Unreconcile.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemReconcile_Unreconcile.Enabled = False
            Me.ButtonItemReconcile_Unreconcile.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemReconcile_Unreconcile.Name = "ButtonItemReconcile_Unreconcile"
            Me.ButtonItemReconcile_Unreconcile.RibbonWordWrap = False
            Me.ButtonItemReconcile_Unreconcile.SubItemsExpandWidth = 14
            Me.ButtonItemReconcile_Unreconcile.Text = "Un-Reconcile"
            '
            'ButtonItemReconcile_SelectAll
            '
            Me.ButtonItemReconcile_SelectAll.BeginGroup = True
            Me.ButtonItemReconcile_SelectAll.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemReconcile_SelectAll.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemReconcile_SelectAll.Name = "ButtonItemReconcile_SelectAll"
            Me.ButtonItemReconcile_SelectAll.RibbonWordWrap = False
            Me.ButtonItemReconcile_SelectAll.SubItemsExpandWidth = 14
            Me.ButtonItemReconcile_SelectAll.Text = "Select All"
            '
            'ButtonItemReconcile_DeselectAll
            '
            Me.ButtonItemReconcile_DeselectAll.BeginGroup = True
            Me.ButtonItemReconcile_DeselectAll.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemReconcile_DeselectAll.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemReconcile_DeselectAll.Name = "ButtonItemReconcile_DeselectAll"
            Me.ButtonItemReconcile_DeselectAll.RibbonWordWrap = False
            Me.ButtonItemReconcile_DeselectAll.SubItemsExpandWidth = 14
            Me.ButtonItemReconcile_DeselectAll.Text = "Deselect All"
            '
            'ServiceFeeReconciliationReportForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1074, 458)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(4)
            Me.Name = "ServiceFeeReconciliationReportForm"
            Me.Text = "Service Fee Reconciliation Report"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_ReportSummary.ResumeLayout(False)
            Me.RibbonPanelPrinting_PrintingPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarOptions_Navigation As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemNavigation_First As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemNavigation_Previous As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemNavigation_Next As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemNavigation_Last As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents LabelForm_ProductCommissionVariance As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_StandardFeeVariance As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_MediaCommissionVariance As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_TotalsVariance As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_TotalsTimePosted As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_MediaCommissionTimePosted As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_ProductCommissionTimePosted As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_StandardFeeTimePosted As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_TotalsFeeBilled As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_MediaCommissionFeeBuild As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_ProductCommissionFeeBilled As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_StandardFeeBilled As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_RowTotals As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_RowMediaCommission As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_RowProductCommission As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_RowStandardFee As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_ColumnVariance As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_ColumnTimePosted As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_ColumnFeeBilled As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_ProductDescription As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_DivisionDescription As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_ClientDescription As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Product As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Division As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Client As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_FeeTimePosted As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DataGridViewForm_ServiceFees As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents LabelForm_FeesBilled As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents PanelForm_ReportSummary As System.Windows.Forms.Panel
        Friend WithEvents RibbonPanelPrinting_PrintingPanel As DevComponents.DotNetBar.RibbonPanel
        Friend WithEvents RibbonTabItemMainRibbon_Printing As DevComponents.DotNetBar.RibbonTabItem
        Friend WithEvents RibbonBarOptions_Filter As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemFilter_ShowFilterEditor As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemFilter_ShowAutoFilterRow As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_View As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ItemContainerView_ViewLeft As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemViewLeft_AllowCellMerging As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemViewLeft_ShowViewCaption As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemViewLeft_ShowGroupByBox As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_QuickCustomize As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemQuickCustomize_Columns As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_Report As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemReport_LoadTemplate As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemReport_Templates As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemReport_Save As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemReport_SaveAs As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarPrinting_Options As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ItemContainerOptions_OptionsLeft As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemOptionsLeft_AutoSizeColumnsToPage As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemOptionsLeft_PrintFilterInfo As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ItemContainerOptions_OptionsMiddle As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemOptionsMiddle_PrintHeader As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemOptionsMiddle_PrintFooter As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemOptionsMiddle_PrintGroupFooter As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ItemContainerOptions_OptionsRight As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemOptionsRight_PrintSelectedRowsOnly As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarPrinting_Printing As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemPrinting_PrintGrid As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarFilePanel_Reconcile As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemReconcile_Reconcile As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemReconcile_Unreconcile As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemReconcile_SelectAll As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemReconcile_DeselectAll As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemPrinting_PrintSelectedReport As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemPrinting_PrintFullReport As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents LabelForm_ReconcileIndicator As AdvantageFramework.WinForm.Presentation.Controls.Label
    End Class

End Namespace