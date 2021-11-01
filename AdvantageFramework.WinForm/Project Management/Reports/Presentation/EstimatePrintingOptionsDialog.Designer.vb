Namespace ProjectManagement.Reports.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class EstimatePrintingOptionsDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EstimatePrintingOptionsDialog))
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Export = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Save = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Cancel = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_SaveOptions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemSaveOptions_Agency = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem_User = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemSaveOptions_Clients = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemSaveOptions_Products = New DevComponents.DotNetBar.ButtonItem()
            Me.TabControlForm_Options = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel()
            Me.VerticalGridProduction_Settings = New DevExpress.XtraVerticalGrid.VGridControl()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.RepositoryItemDateEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
            Me.category = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowUseLocationPrintOptions = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowLocationCode = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowCustomEstimate = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowShowWatermark = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category2 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowReportTitle = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category14 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.category3 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowAddressBlockType = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowPrintClientName = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowPrintDivisionName = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowPrintProductDescription = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowShowCodes = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowPrintContactAfterAddress = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowContactType = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category4 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowIncludeClientReference = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowIncludeAccountExecutive = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowIncludeSalesClass = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowIncludeJobDueDate = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowIncludeAdNumber = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowIncludeEstimateQuantity = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowHideRevisionInfo = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowIncludeCostPerUnit = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowIncludeCostPerThousand = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category5 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowIncludeEstimateComment = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowIncludeEstimateComponentComment = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowIncludeEstimateQuoteComment = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowIncludeEstimateRevisionComment = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowIncludeEstimateFunctionComment = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowIncludeEstimateSuppliedByNotes = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category1 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowHideJobDescription = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowHideComponentDescription = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category6 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.category7 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowReportFormatType = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowIncludeQuantityHoursEst = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowIncludeQuantityHoursTotal = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowDisplayQuantity = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowDisplayHours = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowIncludeRate = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowIncludeRateMarkup = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowIncludeNonbillableActuals = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowIncludeContingency = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowSummaryLevel = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category8 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowGroupingOptionType = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowGroupingOptionInsideDescription = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowGroupingOptionOutsideDescription = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category13 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowSortOption = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowPrintFunctionType = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowSuppressZeroFunctions = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowExcludeEmployeeTimeFunctions = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowExcludeVendorFunctions = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowExcludeIncomeOnlyFunctions = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowExcludeNonBillableFunctions = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowOverrideFunctions = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category10 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.category11 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowTotalsShowTaxSeparately = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowIndicateTaxableFunctions = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowTotalsShowCommissionSeparately = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowIndicateCommissionFunctions = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowTotalsShowContingencySeparately = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowSubtotalsOnly = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category12 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowIncludeDefaultFooterComment = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category9 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowSignature = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowExcludeEmployeeSignature = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category15 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowIncludeCampaignSummary = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowIncludeVendorDescription = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowIncludeFunctionComment = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.TabItem_Estimate = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.rowOverrideConsolidation = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowUseEmployeeSignature = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowUsePrintedDate = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowDate = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.LabelForm_Format = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_FormatLabel = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.rowExcludeDateFromSignature = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.TabControlForm_Options, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_Options.SuspendLayout()
            Me.TabControlPanel1.SuspendLayout()
            CType(Me.VerticalGridProduction_Settings, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
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
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_Format)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_FormatLabel)
            Me.PanelForm_Form.Controls.Add(Me.TabControlForm_Options)
            Me.PanelForm_Form.LookAndFeel.SkinName = "Office 2013"
            Me.PanelForm_Form.LookAndFeel.UseDefaultLookAndFeel = False
            Me.PanelForm_Form.Size = New System.Drawing.Size(613, 524)
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Margin = New System.Windows.Forms.Padding(4)
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(613, 154)
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
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_SaveOptions)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Margin = New System.Windows.Forms.Padding(4)
            Me.RibbonPanelFile_FilePanel.Padding = New System.Windows.Forms.Padding(4, 0, 4, 2)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(613, 94)
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
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Actions, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_SaveOptions, 0)
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
            Me.RibbonBarFilePanel_System.Size = New System.Drawing.Size(100, 92)
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
            Me.Office2007StartButtonMainRibbon_Home.Image = CType(resources.GetObject("Office2007StartButtonMainRibbon_Home.Image"), System.Drawing.Image)
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
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 679)
            Me.BarForm_StatusBar.Margin = New System.Windows.Forms.Padding(4)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(613, 18)
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Export, Me.ButtonItemActions_Save, Me.ButtonItemActions_Cancel})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(104, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(142, 92)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 13
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
            'ButtonItemActions_Save
            '
            Me.ButtonItemActions_Save.BeginGroup = True
            Me.ButtonItemActions_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Save.Name = "ButtonItemActions_Save"
            Me.ButtonItemActions_Save.RibbonWordWrap = False
            Me.ButtonItemActions_Save.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Save.Text = "Save"
            '
            'ButtonItemActions_Cancel
            '
            Me.ButtonItemActions_Cancel.BeginGroup = True
            Me.ButtonItemActions_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Cancel.Name = "ButtonItemActions_Cancel"
            Me.ButtonItemActions_Cancel.RibbonWordWrap = False
            Me.ButtonItemActions_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Cancel.Text = "Cancel"
            '
            'RibbonBarOptions_SaveOptions
            '
            Me.RibbonBarOptions_SaveOptions.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_SaveOptions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_SaveOptions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_SaveOptions.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_SaveOptions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_SaveOptions.DragDropSupport = True
            Me.RibbonBarOptions_SaveOptions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemSaveOptions_Agency, Me.ButtonItem_User, Me.ButtonItemSaveOptions_Clients, Me.ButtonItemSaveOptions_Products})
            Me.RibbonBarOptions_SaveOptions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_SaveOptions.Location = New System.Drawing.Point(246, 0)
            Me.RibbonBarOptions_SaveOptions.Name = "RibbonBarOptions_SaveOptions"
            Me.RibbonBarOptions_SaveOptions.SecurityEnabled = True
            Me.RibbonBarOptions_SaveOptions.Size = New System.Drawing.Size(177, 92)
            Me.RibbonBarOptions_SaveOptions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_SaveOptions.TabIndex = 14
            Me.RibbonBarOptions_SaveOptions.Text = "Save Options"
            '
            '
            '
            Me.RibbonBarOptions_SaveOptions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_SaveOptions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_SaveOptions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemSaveOptions_Agency
            '
            Me.ButtonItemSaveOptions_Agency.AutoCheckOnClick = True
            Me.ButtonItemSaveOptions_Agency.BeginGroup = True
            Me.ButtonItemSaveOptions_Agency.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemSaveOptions_Agency.Name = "ButtonItemSaveOptions_Agency"
            Me.ButtonItemSaveOptions_Agency.RibbonWordWrap = False
            Me.ButtonItemSaveOptions_Agency.SubItemsExpandWidth = 14
            Me.ButtonItemSaveOptions_Agency.Text = "Agency"
            '
            'ButtonItem_User
            '
            Me.ButtonItem_User.AutoCheckOnClick = True
            Me.ButtonItem_User.BeginGroup = True
            Me.ButtonItem_User.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItem_User.Name = "ButtonItem_User"
            Me.ButtonItem_User.RibbonWordWrap = False
            Me.ButtonItem_User.SubItemsExpandWidth = 14
            Me.ButtonItem_User.Text = "User"
            '
            'ButtonItemSaveOptions_Clients
            '
            Me.ButtonItemSaveOptions_Clients.AutoCheckOnClick = True
            Me.ButtonItemSaveOptions_Clients.BeginGroup = True
            Me.ButtonItemSaveOptions_Clients.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemSaveOptions_Clients.Name = "ButtonItemSaveOptions_Clients"
            Me.ButtonItemSaveOptions_Clients.RibbonWordWrap = False
            Me.ButtonItemSaveOptions_Clients.SubItemsExpandWidth = 14
            Me.ButtonItemSaveOptions_Clients.Text = "Clients"
            '
            'ButtonItemSaveOptions_Products
            '
            Me.ButtonItemSaveOptions_Products.AutoCheckOnClick = True
            Me.ButtonItemSaveOptions_Products.BeginGroup = True
            Me.ButtonItemSaveOptions_Products.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemSaveOptions_Products.Name = "ButtonItemSaveOptions_Products"
            Me.ButtonItemSaveOptions_Products.RibbonWordWrap = False
            Me.ButtonItemSaveOptions_Products.SubItemsExpandWidth = 14
            Me.ButtonItemSaveOptions_Products.Text = "Products"
            '
            'TabControlForm_Options
            '
            Me.TabControlForm_Options.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlForm_Options.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.TabControlForm_Options.CanReorderTabs = True
            Me.TabControlForm_Options.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlForm_Options.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlForm_Options.Controls.Add(Me.TabControlPanel1)
            Me.TabControlForm_Options.ForeColor = System.Drawing.Color.Black
            Me.TabControlForm_Options.Location = New System.Drawing.Point(12, 38)
            Me.TabControlForm_Options.Name = "TabControlForm_Options"
            Me.TabControlForm_Options.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_Options.SelectedTabIndex = 1
            Me.TabControlForm_Options.Size = New System.Drawing.Size(589, 479)
            Me.TabControlForm_Options.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_Options.TabIndex = 2
            Me.TabControlForm_Options.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_Options.Tabs.Add(Me.TabItem_Estimate)
            '
            'TabControlPanel1
            '
            Me.TabControlPanel1.Controls.Add(Me.VerticalGridProduction_Settings)
            Me.TabControlPanel1.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanel1.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanel1.Name = "TabControlPanel1"
            Me.TabControlPanel1.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanel1.Size = New System.Drawing.Size(589, 452)
            Me.TabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanel1.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanel1.Style.GradientAngle = 90
            Me.TabControlPanel1.TabIndex = 1
            Me.TabControlPanel1.TabItem = Me.TabItem_Estimate
            '
            'VerticalGridProduction_Settings
            '
            Me.VerticalGridProduction_Settings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.VerticalGridProduction_Settings.Appearance.RowHeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.VerticalGridProduction_Settings.Appearance.RowHeaderPanel.Options.UseFont = True
            Me.VerticalGridProduction_Settings.Cursor = System.Windows.Forms.Cursors.Default
            Me.VerticalGridProduction_Settings.CustomizationFormBounds = New System.Drawing.Rectangle(1704, 698, 216, 265)
            Me.VerticalGridProduction_Settings.DataSource = Me.BindingSource
            Me.VerticalGridProduction_Settings.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView
            Me.VerticalGridProduction_Settings.Location = New System.Drawing.Point(4, 4)
            Me.VerticalGridProduction_Settings.Name = "VerticalGridProduction_Settings"
            Me.VerticalGridProduction_Settings.OptionsBehavior.UseEnterAsTab = True
            Me.VerticalGridProduction_Settings.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemDateEdit1})
            Me.VerticalGridProduction_Settings.Rows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.category, Me.category2, Me.category14, Me.category1, Me.category6, Me.category10, Me.category15})
            Me.VerticalGridProduction_Settings.ShowButtonMode = DevExpress.XtraVerticalGrid.ShowButtonModeEnum.ShowAlways
            Me.VerticalGridProduction_Settings.Size = New System.Drawing.Size(581, 444)
            Me.VerticalGridProduction_Settings.TabIndex = 2
            Me.VerticalGridProduction_Settings.TreeButtonStyle = DevExpress.XtraVerticalGrid.TreeButtonStyle.TreeView
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting)
            '
            'RepositoryItemDateEdit1
            '
            Me.RepositoryItemDateEdit1.AutoHeight = False
            Me.RepositoryItemDateEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.RepositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.RepositoryItemDateEdit1.Name = "RepositoryItemDateEdit1"
            '
            'category
            '
            Me.category.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowUseLocationPrintOptions, Me.rowLocationCode, Me.rowCustomEstimate, Me.rowShowWatermark})
            Me.category.Height = 17
            Me.category.Name = "category"
            Me.category.Properties.Caption = "Output Options"
            '
            'rowUseLocationPrintOptions
            '
            Me.rowUseLocationPrintOptions.Name = "rowUseLocationPrintOptions"
            Me.rowUseLocationPrintOptions.Properties.Caption = "Use Location Print Options"
            Me.rowUseLocationPrintOptions.Properties.FieldName = "UseLocationOptions"
            '
            'rowLocationCode
            '
            Me.rowLocationCode.Height = 17
            Me.rowLocationCode.Name = "rowLocationCode"
            Me.rowLocationCode.Properties.Caption = "Location"
            Me.rowLocationCode.Properties.FieldName = "LocationCode"
            '
            'rowCustomEstimate
            '
            Me.rowCustomEstimate.Name = "rowCustomEstimate"
            Me.rowCustomEstimate.Properties.Caption = "Custom Estimate"
            Me.rowCustomEstimate.Properties.FieldName = "CustomEstimateID"
            '
            'rowShowWatermark
            '
            Me.rowShowWatermark.Name = "rowShowWatermark"
            Me.rowShowWatermark.Properties.Caption = "Show as Draft until Approved"
            Me.rowShowWatermark.Properties.FieldName = "ShowWatermark"
            '
            'category2
            '
            Me.category2.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowReportTitle})
            Me.category2.Height = 17
            Me.category2.Name = "category2"
            Me.category2.Properties.Caption = "Header Options"
            '
            'rowReportTitle
            '
            Me.rowReportTitle.Height = 17
            Me.rowReportTitle.Name = "rowReportTitle"
            Me.rowReportTitle.Properties.Caption = "Report Title"
            Me.rowReportTitle.Properties.FieldName = "ReportTitle"
            '
            'category14
            '
            Me.category14.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.category3, Me.category4, Me.category5})
            Me.category14.Name = "category14"
            Me.category14.Properties.Caption = "Header"
            '
            'category3
            '
            Me.category3.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowAddressBlockType, Me.rowPrintClientName, Me.rowPrintDivisionName, Me.rowPrintProductDescription, Me.rowShowCodes, Me.rowPrintContactAfterAddress, Me.rowContactType})
            Me.category3.Name = "category3"
            Me.category3.Properties.Caption = "Address Block"
            '
            'rowAddressBlockType
            '
            Me.rowAddressBlockType.Name = "rowAddressBlockType"
            Me.rowAddressBlockType.Properties.Caption = "Address Block Type"
            Me.rowAddressBlockType.Properties.FieldName = "CDPAddressOption"
            '
            'rowPrintClientName
            '
            Me.rowPrintClientName.Name = "rowPrintClientName"
            Me.rowPrintClientName.Properties.Caption = "Print Client Name"
            Me.rowPrintClientName.Properties.FieldName = "PrintClientName"
            '
            'rowPrintDivisionName
            '
            Me.rowPrintDivisionName.Name = "rowPrintDivisionName"
            Me.rowPrintDivisionName.Properties.Caption = "Print Division Name"
            Me.rowPrintDivisionName.Properties.FieldName = "PrintDivisionName"
            '
            'rowPrintProductDescription
            '
            Me.rowPrintProductDescription.Name = "rowPrintProductDescription"
            Me.rowPrintProductDescription.Properties.Caption = "Print Product Name"
            Me.rowPrintProductDescription.Properties.FieldName = "PrintProductDescription"
            '
            'rowShowCodes
            '
            Me.rowShowCodes.Name = "rowShowCodes"
            Me.rowShowCodes.Properties.Caption = "Show Codes"
            Me.rowShowCodes.Properties.FieldName = "ShowCodes"
            '
            'rowPrintContactAfterAddress
            '
            Me.rowPrintContactAfterAddress.Name = "rowPrintContactAfterAddress"
            Me.rowPrintContactAfterAddress.Properties.Caption = "Print Contact After Address"
            Me.rowPrintContactAfterAddress.Properties.FieldName = "PrintContactAfterAddress"
            '
            'rowContactType
            '
            Me.rowContactType.Name = "rowContactType"
            Me.rowContactType.Properties.Caption = "Contact Type"
            Me.rowContactType.Properties.FieldName = "ContactType"
            '
            'category4
            '
            Me.category4.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowIncludeClientReference, Me.rowIncludeAccountExecutive, Me.rowIncludeSalesClass, Me.rowIncludeJobDueDate, Me.rowIncludeAdNumber, Me.rowIncludeEstimateQuantity, Me.rowHideRevisionInfo, Me.rowIncludeCostPerUnit, Me.rowIncludeCostPerThousand})
            Me.category4.Name = "category4"
            Me.category4.Properties.Caption = "Include Fields"
            '
            'rowIncludeClientReference
            '
            Me.rowIncludeClientReference.Name = "rowIncludeClientReference"
            Me.rowIncludeClientReference.Properties.Caption = "Client Reference"
            Me.rowIncludeClientReference.Properties.FieldName = "IncludeClientReference"
            '
            'rowIncludeAccountExecutive
            '
            Me.rowIncludeAccountExecutive.Name = "rowIncludeAccountExecutive"
            Me.rowIncludeAccountExecutive.Properties.Caption = "Account Executive"
            Me.rowIncludeAccountExecutive.Properties.FieldName = "IncludeAccountExecutive"
            '
            'rowIncludeSalesClass
            '
            Me.rowIncludeSalesClass.Name = "rowIncludeSalesClass"
            Me.rowIncludeSalesClass.Properties.Caption = "Sales Class"
            Me.rowIncludeSalesClass.Properties.FieldName = "IncludeSalesClass"
            '
            'rowIncludeJobDueDate
            '
            Me.rowIncludeJobDueDate.Name = "rowIncludeJobDueDate"
            Me.rowIncludeJobDueDate.Properties.Caption = "Job Due Date"
            Me.rowIncludeJobDueDate.Properties.FieldName = "IncludeJobDueDate"
            '
            'rowIncludeAdNumber
            '
            Me.rowIncludeAdNumber.Name = "rowIncludeAdNumber"
            Me.rowIncludeAdNumber.Properties.Caption = "Include Ad Number"
            Me.rowIncludeAdNumber.Properties.FieldName = "PrintAdNumber"
            '
            'rowIncludeEstimateQuantity
            '
            Me.rowIncludeEstimateQuantity.Name = "rowIncludeEstimateQuantity"
            Me.rowIncludeEstimateQuantity.Properties.Caption = "Estimate Quantity"
            Me.rowIncludeEstimateQuantity.Properties.FieldName = "IncludeJobQuantity"
            '
            'rowHideRevisionInfo
            '
            Me.rowHideRevisionInfo.Name = "rowHideRevisionInfo"
            Me.rowHideRevisionInfo.Properties.Caption = "Hide Revision Info"
            Me.rowHideRevisionInfo.Properties.FieldName = "HideRevision"
            '
            'rowIncludeCostPerUnit
            '
            Me.rowIncludeCostPerUnit.Name = "rowIncludeCostPerUnit"
            Me.rowIncludeCostPerUnit.Properties.Caption = "Include Cost Per Unit"
            Me.rowIncludeCostPerUnit.Properties.FieldName = "IncludeCPU"
            '
            'rowIncludeCostPerThousand
            '
            Me.rowIncludeCostPerThousand.Name = "rowIncludeCostPerThousand"
            Me.rowIncludeCostPerThousand.Properties.Caption = "Include Cost Per Thousand"
            Me.rowIncludeCostPerThousand.Properties.FieldName = "IncludeCPM"
            '
            'category5
            '
            Me.category5.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowIncludeEstimateComment, Me.rowIncludeEstimateComponentComment, Me.rowIncludeEstimateQuoteComment, Me.rowIncludeEstimateRevisionComment, Me.rowIncludeEstimateFunctionComment, Me.rowIncludeEstimateSuppliedByNotes})
            Me.category5.Name = "category5"
            Me.category5.Properties.Caption = "Comments"
            '
            'rowIncludeEstimateComment
            '
            Me.rowIncludeEstimateComment.Name = "rowIncludeEstimateComment"
            Me.rowIncludeEstimateComment.Properties.Caption = "Estimate Comment"
            Me.rowIncludeEstimateComment.Properties.FieldName = "IncludeEstimateComment"
            '
            'rowIncludeEstimateComponentComment
            '
            Me.rowIncludeEstimateComponentComment.Name = "rowIncludeEstimateComponentComment"
            Me.rowIncludeEstimateComponentComment.Properties.Caption = "Estimate Component Comment"
            Me.rowIncludeEstimateComponentComment.Properties.FieldName = "IncludeEstimateComponentComment"
            '
            'rowIncludeEstimateQuoteComment
            '
            Me.rowIncludeEstimateQuoteComment.Name = "rowIncludeEstimateQuoteComment"
            Me.rowIncludeEstimateQuoteComment.Properties.Caption = "Quote Comment"
            Me.rowIncludeEstimateQuoteComment.Properties.FieldName = "IncludeEstimateQuoteComment"
            '
            'rowIncludeEstimateRevisionComment
            '
            Me.rowIncludeEstimateRevisionComment.Name = "rowIncludeEstimateRevisionComment"
            Me.rowIncludeEstimateRevisionComment.Properties.Caption = "Revision Comment"
            Me.rowIncludeEstimateRevisionComment.Properties.FieldName = "IncludeEstimateRevisionComment"
            '
            'rowIncludeEstimateFunctionComment
            '
            Me.rowIncludeEstimateFunctionComment.Name = "rowIncludeEstimateFunctionComment"
            Me.rowIncludeEstimateFunctionComment.Properties.Caption = "Function Comment"
            Me.rowIncludeEstimateFunctionComment.Properties.FieldName = "IncludeEstimateFunctionComment"
            '
            'rowIncludeEstimateSuppliedByNotes
            '
            Me.rowIncludeEstimateSuppliedByNotes.Name = "rowIncludeEstimateSuppliedByNotes"
            Me.rowIncludeEstimateSuppliedByNotes.Properties.Caption = "Supplied By Notes"
            Me.rowIncludeEstimateSuppliedByNotes.Properties.FieldName = "IncludeSuppliedByNotes"
            '
            'category1
            '
            Me.category1.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowHideJobDescription, Me.rowHideComponentDescription})
            Me.category1.Height = 17
            Me.category1.Name = "category1"
            Me.category1.Properties.Caption = "Job Options"
            '
            'rowHideJobDescription
            '
            Me.rowHideJobDescription.Name = "rowHideJobDescription"
            Me.rowHideJobDescription.Properties.Caption = "Hide Job Number and Description"
            Me.rowHideJobDescription.Properties.FieldName = "HideJobDescription"
            '
            'rowHideComponentDescription
            '
            Me.rowHideComponentDescription.Name = "rowHideComponentDescription"
            Me.rowHideComponentDescription.OptionsRow.AllowMove = False
            Me.rowHideComponentDescription.OptionsRow.AllowMoveToCustomizationForm = False
            Me.rowHideComponentDescription.Properties.Caption = "Hide Component Number And Description"
            Me.rowHideComponentDescription.Properties.FieldName = "HideComponentDescription"
            '
            'category6
            '
            Me.category6.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.category7, Me.category8, Me.category13})
            Me.category6.Name = "category6"
            Me.category6.Properties.Caption = "Detail, Sorting & Grouping"
            '
            'category7
            '
            Me.category7.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowReportFormatType, Me.rowIncludeQuantityHoursEst, Me.rowIncludeQuantityHoursTotal, Me.rowDisplayQuantity, Me.rowDisplayHours, Me.rowIncludeRate, Me.rowIncludeRateMarkup, Me.rowIncludeNonbillableActuals, Me.rowIncludeContingency, Me.rowSummaryLevel})
            Me.category7.Name = "category7"
            Me.category7.Properties.Caption = "Report Format Options"
            '
            'rowReportFormatType
            '
            Me.rowReportFormatType.Name = "rowReportFormatType"
            Me.rowReportFormatType.Properties.Caption = "Format Type"
            Me.rowReportFormatType.Properties.FieldName = "ReportFormat"
            '
            'rowIncludeQuantityHoursEst
            '
            Me.rowIncludeQuantityHoursEst.Name = "rowIncludeQuantityHoursEst"
            Me.rowIncludeQuantityHoursEst.Properties.Caption = "Include Quantity/Hours"
            Me.rowIncludeQuantityHoursEst.Properties.FieldName = "IncludeQuantityHours"
            '
            'rowIncludeQuantityHoursTotal
            '
            Me.rowIncludeQuantityHoursTotal.Name = "rowIncludeQuantityHoursTotal"
            Me.rowIncludeQuantityHoursTotal.Properties.Caption = "Include Quantity/Hours Total"
            Me.rowIncludeQuantityHoursTotal.Properties.FieldName = "PrintQuantityTotals"
            '
            'rowDisplayQuantity
            '
            Me.rowDisplayQuantity.Name = "rowDisplayQuantity"
            Me.rowDisplayQuantity.Properties.Caption = "Display Quantity/Hours as Quantity"
            Me.rowDisplayQuantity.Properties.FieldName = "DisplayQuantity"
            '
            'rowDisplayHours
            '
            Me.rowDisplayHours.Name = "rowDisplayHours"
            Me.rowDisplayHours.Properties.Caption = "Display Quantity/Hours as Hours"
            Me.rowDisplayHours.Properties.FieldName = "DisplayHours"
            '
            'rowIncludeRate
            '
            Me.rowIncludeRate.Name = "rowIncludeRate"
            Me.rowIncludeRate.Properties.Caption = "Include Rate"
            Me.rowIncludeRate.Properties.FieldName = "IncludeRate"
            '
            'rowIncludeRateMarkup
            '
            Me.rowIncludeRateMarkup.Name = "rowIncludeRateMarkup"
            Me.rowIncludeRateMarkup.Properties.Caption = "Inlcude Rate w/Markup"
            Me.rowIncludeRateMarkup.Properties.FieldName = "IncludeRateMarkup"
            '
            'rowIncludeNonbillableActuals
            '
            Me.rowIncludeNonbillableActuals.Name = "rowIncludeNonbillableActuals"
            Me.rowIncludeNonbillableActuals.Properties.Caption = "Include Non Billable Actuals"
            Me.rowIncludeNonbillableActuals.Properties.FieldName = "IncludeNonBillable"
            '
            'rowIncludeContingency
            '
            Me.rowIncludeContingency.Name = "rowIncludeContingency"
            Me.rowIncludeContingency.Properties.Caption = "Include Contingency"
            Me.rowIncludeContingency.Properties.FieldName = "TotalsIncludeContingency"
            '
            'rowSummaryLevel
            '
            Me.rowSummaryLevel.Name = "rowSummaryLevel"
            Me.rowSummaryLevel.Properties.Caption = "Summary Level"
            Me.rowSummaryLevel.Properties.FieldName = "SummaryLevel"
            '
            'category8
            '
            Me.category8.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowGroupingOptionType, Me.rowGroupingOptionInsideDescription, Me.rowGroupingOptionOutsideDescription})
            Me.category8.Name = "category8"
            Me.category8.Properties.Caption = "Grouping Options"
            '
            'rowGroupingOptionType
            '
            Me.rowGroupingOptionType.Name = "rowGroupingOptionType"
            Me.rowGroupingOptionType.Properties.Caption = "Option"
            Me.rowGroupingOptionType.Properties.FieldName = "GroupingOptionGroupOption"
            '
            'rowGroupingOptionInsideDescription
            '
            Me.rowGroupingOptionInsideDescription.Name = "rowGroupingOptionInsideDescription"
            Me.rowGroupingOptionInsideDescription.Properties.Caption = "Inside Description"
            Me.rowGroupingOptionInsideDescription.Properties.FieldName = "GroupingOptionInsideDescription"
            '
            'rowGroupingOptionOutsideDescription
            '
            Me.rowGroupingOptionOutsideDescription.Name = "rowGroupingOptionOutsideDescription"
            Me.rowGroupingOptionOutsideDescription.Properties.Caption = "Outside Description"
            Me.rowGroupingOptionOutsideDescription.Properties.FieldName = "GroupingOptionOutsideDescription"
            '
            'category13
            '
            Me.category13.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowSortOption, Me.rowPrintFunctionType, Me.rowSuppressZeroFunctions, Me.rowExcludeEmployeeTimeFunctions, Me.rowExcludeVendorFunctions, Me.rowExcludeIncomeOnlyFunctions, Me.rowExcludeNonBillableFunctions, Me.rowOverrideFunctions})
            Me.category13.Name = "category13"
            Me.category13.Properties.Caption = "Function Options"
            '
            'rowSortOption
            '
            Me.rowSortOption.Name = "rowSortOption"
            Me.rowSortOption.Properties.Caption = "Sort Option"
            Me.rowSortOption.Properties.FieldName = "GroupingOptionSortOption"
            '
            'rowPrintFunctionType
            '
            Me.rowPrintFunctionType.Name = "rowPrintFunctionType"
            Me.rowPrintFunctionType.Properties.Caption = "Print Option"
            Me.rowPrintFunctionType.Properties.FieldName = "GroupingOptionFunctionOption"
            '
            'rowSuppressZeroFunctions
            '
            Me.rowSuppressZeroFunctions.Name = "rowSuppressZeroFunctions"
            Me.rowSuppressZeroFunctions.Properties.Caption = "Show Zero Function Amounts"
            Me.rowSuppressZeroFunctions.Properties.FieldName = "SuppressZeroFunctions"
            '
            'rowExcludeEmployeeTimeFunctions
            '
            Me.rowExcludeEmployeeTimeFunctions.Name = "rowExcludeEmployeeTimeFunctions"
            Me.rowExcludeEmployeeTimeFunctions.Properties.Caption = "Exclude Employee Time Functions"
            Me.rowExcludeEmployeeTimeFunctions.Properties.FieldName = "ExcludeEmployeeTime"
            '
            'rowExcludeVendorFunctions
            '
            Me.rowExcludeVendorFunctions.Name = "rowExcludeVendorFunctions"
            Me.rowExcludeVendorFunctions.Properties.Caption = "Exclude Vendor Functions"
            Me.rowExcludeVendorFunctions.Properties.FieldName = "ExcludeVendor"
            '
            'rowExcludeIncomeOnlyFunctions
            '
            Me.rowExcludeIncomeOnlyFunctions.Name = "rowExcludeIncomeOnlyFunctions"
            Me.rowExcludeIncomeOnlyFunctions.Properties.Caption = "Exclude Income Only Functions"
            Me.rowExcludeIncomeOnlyFunctions.Properties.FieldName = "ExcludeIncomeOnly"
            '
            'rowExcludeNonBillableFunctions
            '
            Me.rowExcludeNonBillableFunctions.Name = "rowExcludeNonBillableFunctions"
            Me.rowExcludeNonBillableFunctions.Properties.Caption = "Exclude Non Billable Functions"
            Me.rowExcludeNonBillableFunctions.Properties.FieldName = "ExcludeNonbillable"
            '
            'rowOverrideFunctions
            '
            Me.rowOverrideFunctions.Name = "rowOverrideFunctions"
            Me.rowOverrideFunctions.Properties.Caption = "Override Consolidation"
            Me.rowOverrideFunctions.Properties.FieldName = "ConsolidationOverride"
            '
            'category10
            '
            Me.category10.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.category11, Me.category12, Me.category9})
            Me.category10.Name = "category10"
            Me.category10.Properties.Caption = "Totals and Footer"
            '
            'category11
            '
            Me.category11.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowTotalsShowTaxSeparately, Me.rowIndicateTaxableFunctions, Me.rowTotalsShowCommissionSeparately, Me.rowIndicateCommissionFunctions, Me.rowTotalsShowContingencySeparately, Me.rowSubtotalsOnly})
            Me.category11.Name = "category11"
            Me.category11.Properties.Caption = "Total Options"
            '
            'rowTotalsShowTaxSeparately
            '
            Me.rowTotalsShowTaxSeparately.Name = "rowTotalsShowTaxSeparately"
            Me.rowTotalsShowTaxSeparately.Properties.Caption = "Show Tax Separately"
            Me.rowTotalsShowTaxSeparately.Properties.FieldName = "TotalsShowTaxSeparately"
            '
            'rowIndicateTaxableFunctions
            '
            Me.rowIndicateTaxableFunctions.Name = "rowIndicateTaxableFunctions"
            Me.rowIndicateTaxableFunctions.Properties.Caption = "Indicate Taxable Functions"
            Me.rowIndicateTaxableFunctions.Properties.FieldName = "IndicateTaxableFunctions"
            '
            'rowTotalsShowCommissionSeparately
            '
            Me.rowTotalsShowCommissionSeparately.Name = "rowTotalsShowCommissionSeparately"
            Me.rowTotalsShowCommissionSeparately.Properties.Caption = "Show Commission Separately"
            Me.rowTotalsShowCommissionSeparately.Properties.FieldName = "TotalsShowCommissionSeparately"
            '
            'rowIndicateCommissionFunctions
            '
            Me.rowIndicateCommissionFunctions.Name = "rowIndicateCommissionFunctions"
            Me.rowIndicateCommissionFunctions.Properties.Caption = "Indicate Commission Functions"
            Me.rowIndicateCommissionFunctions.Properties.FieldName = "IndicateCommissionFunctions"
            '
            'rowTotalsShowContingencySeparately
            '
            Me.rowTotalsShowContingencySeparately.Name = "rowTotalsShowContingencySeparately"
            Me.rowTotalsShowContingencySeparately.Properties.Caption = "Show Contingency Separately"
            Me.rowTotalsShowContingencySeparately.Properties.FieldName = "TotalsShowContingencySeparately"
            '
            'rowSubtotalsOnly
            '
            Me.rowSubtotalsOnly.Name = "rowSubtotalsOnly"
            Me.rowSubtotalsOnly.Properties.Caption = "Subtotals Only"
            Me.rowSubtotalsOnly.Properties.FieldName = "SubtotalsOnly"
            '
            'category12
            '
            Me.category12.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowIncludeDefaultFooterComment})
            Me.category12.Name = "category12"
            Me.category12.Properties.Caption = "Footer Comments"
            '
            'rowIncludeDefaultFooterComment
            '
            Me.rowIncludeDefaultFooterComment.Name = "rowIncludeDefaultFooterComment"
            Me.rowIncludeDefaultFooterComment.Properties.Caption = "Default Footer Comment"
            Me.rowIncludeDefaultFooterComment.Properties.FieldName = "DefaultFooterComment"
            '
            'category9
            '
            Me.category9.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowSignature, Me.rowExcludeEmployeeSignature, Me.rowExcludeDateFromSignature})
            Me.category9.Height = 17
            Me.category9.Name = "category9"
            Me.category9.Properties.Caption = "Signature"
            '
            'rowSignature
            '
            Me.rowSignature.Name = "rowSignature"
            Me.rowSignature.Properties.Caption = "Signature"
            Me.rowSignature.Properties.FieldName = "Signature"
            '
            'rowExcludeEmployeeSignature
            '
            Me.rowExcludeEmployeeSignature.Name = "rowExcludeEmployeeSignature"
            Me.rowExcludeEmployeeSignature.Properties.Caption = "Exclude Employee Signature"
            Me.rowExcludeEmployeeSignature.Properties.FieldName = "ExcludeSignatures"
            '
            'category15
            '
            Me.category15.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowIncludeCampaignSummary, Me.rowIncludeVendorDescription, Me.rowIncludeFunctionComment})
            Me.category15.Name = "category15"
            Me.category15.Properties.Caption = "Custom Options"
            Me.category15.Visible = False
            '
            'rowIncludeCampaignSummary
            '
            Me.rowIncludeCampaignSummary.Name = "rowIncludeCampaignSummary"
            Me.rowIncludeCampaignSummary.Properties.Caption = "Include Campaign Summary"
            Me.rowIncludeCampaignSummary.Properties.FieldName = "IncludeCampaignSummary"
            '
            'rowIncludeVendorDescription
            '
            Me.rowIncludeVendorDescription.Name = "rowIncludeVendorDescription"
            Me.rowIncludeVendorDescription.Properties.Caption = "Include Vendor Description"
            Me.rowIncludeVendorDescription.Properties.FieldName = "IncludeVendorDescription"
            '
            'rowIncludeFunctionComment
            '
            Me.rowIncludeFunctionComment.Name = "rowIncludeFunctionComment"
            Me.rowIncludeFunctionComment.Properties.Caption = "Include Function Comment"
            Me.rowIncludeFunctionComment.Properties.FieldName = "IncludeFunctionComment"
            '
            'TabItem_Estimate
            '
            Me.TabItem_Estimate.AttachedControl = Me.TabControlPanel1
            Me.TabItem_Estimate.Name = "TabItem_Estimate"
            Me.TabItem_Estimate.Text = "Estimate"
            '
            'rowOverrideConsolidation
            '
            Me.rowOverrideConsolidation.Appearance.Options.UseTextOptions = True
            Me.rowOverrideConsolidation.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
            Me.rowOverrideConsolidation.Height = 17
            Me.rowOverrideConsolidation.Name = "rowOverrideConsolidation"
            Me.rowOverrideConsolidation.Properties.Caption = "Override product consolidation"
            Me.rowOverrideConsolidation.Properties.FieldName = "ConsolidationOverride"
            '
            'rowUseEmployeeSignature
            '
            Me.rowUseEmployeeSignature.Name = "rowUseEmployeeSignature"
            Me.rowUseEmployeeSignature.Properties.Caption = "Use Employee Signature"
            Me.rowUseEmployeeSignature.Properties.FieldName = "UseEmployeeSignature"
            '
            'rowUsePrintedDate
            '
            Me.rowUsePrintedDate.Name = "rowUsePrintedDate"
            Me.rowUsePrintedDate.Properties.Caption = "Use Printed Date"
            Me.rowUsePrintedDate.Properties.FieldName = "DateToPrint"
            '
            'rowDate
            '
            Me.rowDate.Name = "rowDate"
            Me.rowDate.Properties.Caption = "Date"
            Me.rowDate.Properties.FieldName = "DatePrint"
            Me.rowDate.Properties.Format.FormatString = "d"
            Me.rowDate.Properties.Format.FormatType = DevExpress.Utils.FormatType.DateTime
            Me.rowDate.Properties.RowEdit = Me.RepositoryItemDateEdit1
            '
            'LabelForm_Format
            '
            Me.LabelForm_Format.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_Format.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Format.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Format.Location = New System.Drawing.Point(71, 12)
            Me.LabelForm_Format.Name = "LabelForm_Format"
            Me.LabelForm_Format.Size = New System.Drawing.Size(530, 20)
            Me.LabelForm_Format.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Format.TabIndex = 4
            '
            'LabelForm_FormatLabel
            '
            Me.LabelForm_FormatLabel.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_FormatLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_FormatLabel.Location = New System.Drawing.Point(14, 12)
            Me.LabelForm_FormatLabel.Name = "LabelForm_FormatLabel"
            Me.LabelForm_FormatLabel.Size = New System.Drawing.Size(51, 20)
            Me.LabelForm_FormatLabel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_FormatLabel.TabIndex = 3
            Me.LabelForm_FormatLabel.Text = "Format:"
            '
            'rowExcludeDateFromSignature
            '
            Me.rowExcludeDateFromSignature.Name = "rowExcludeDateFromSignature"
            Me.rowExcludeDateFromSignature.Properties.Caption = "Exclude Date from Signature"
            Me.rowExcludeDateFromSignature.Properties.FieldName = "ExcludeDateFromSignature"
            '
            'EstimatePrintingOptionsDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(623, 699)
            Me.CloseButtonVisible = False
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(4)
            Me.Name = "EstimatePrintingOptionsDialog"
            Me.Text = "Estimate Printing Options"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.TabControlForm_Options, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_Options.ResumeLayout(False)
            Me.TabControlPanel1.ResumeLayout(False)
            CType(Me.VerticalGridProduction_Settings, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemActions_Save As DevComponents.DotNetBar.ButtonItem
        Private WithEvents ButtonItemActions_Cancel As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Private WithEvents RibbonBarOptions_SaveOptions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemSaveOptions_Agency As DevComponents.DotNetBar.ButtonItem
        Private WithEvents ButtonItemSaveOptions_Clients As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents TabControlForm_Options As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents VerticalGridProduction_Settings As DevExpress.XtraVerticalGrid.VGridControl
        Friend WithEvents rowOverrideConsolidation As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowUseEmployeeSignature As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents TabItem_Estimate As DevComponents.DotNetBar.TabItem
        Private WithEvents ButtonItemSaveOptions_Products As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents rowUsePrintedDate As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowDate As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents RepositoryItemDateEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
        Friend WithEvents LabelForm_Format As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_FormatLabel As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents ButtonItem_User As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Export As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents category As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowUseLocationPrintOptions As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowLocationCode As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowCustomEstimate As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowShowWatermark As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category2 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowReportTitle As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category14 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents category3 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowAddressBlockType As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrintClientName As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrintDivisionName As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrintProductDescription As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowShowCodes As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrintContactAfterAddress As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowContactType As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category4 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowIncludeClientReference As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowIncludeAccountExecutive As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowIncludeSalesClass As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowIncludeJobDueDate As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowIncludeAdNumber As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowIncludeEstimateQuantity As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowHideRevisionInfo As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowIncludeCostPerUnit As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowIncludeCostPerThousand As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category5 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowIncludeEstimateComment As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowIncludeEstimateComponentComment As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowIncludeEstimateQuoteComment As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowIncludeEstimateRevisionComment As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowIncludeEstimateFunctionComment As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowIncludeEstimateSuppliedByNotes As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category1 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowHideJobDescription As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowHideComponentDescription As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category6 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents category7 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowReportFormatType As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowIncludeQuantityHoursEst As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowIncludeQuantityHoursTotal As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowDisplayQuantity As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowDisplayHours As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowIncludeRate As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowIncludeRateMarkup As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowIncludeNonbillableActuals As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowIncludeContingency As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowSummaryLevel As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category8 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowGroupingOptionType As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowGroupingOptionInsideDescription As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowGroupingOptionOutsideDescription As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category13 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowSortOption As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrintFunctionType As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowSuppressZeroFunctions As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowExcludeEmployeeTimeFunctions As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowExcludeVendorFunctions As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowExcludeIncomeOnlyFunctions As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowExcludeNonBillableFunctions As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowOverrideFunctions As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category10 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents category11 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowTotalsShowTaxSeparately As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowIndicateTaxableFunctions As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTotalsShowCommissionSeparately As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowIndicateCommissionFunctions As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTotalsShowContingencySeparately As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowSubtotalsOnly As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category12 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowIncludeDefaultFooterComment As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category9 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowSignature As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowExcludeEmployeeSignature As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category15 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowIncludeCampaignSummary As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowIncludeVendorDescription As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowIncludeFunctionComment As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowExcludeDateFromSignature As DevExpress.XtraVerticalGrid.Rows.EditorRow
    End Class

End Namespace

