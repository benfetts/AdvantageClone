Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class MediaPlanningForm
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaPlanningForm))
            Me.DataGridViewLeftSection_MediaPlans = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Print = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemPrint_FlowChart = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Dashboard = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemDashboard_Edit = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_MasterPlans = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemMasterPlans_View = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemMasterPlans_Setup = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Estimate = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemEstimate_View = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemEstimate_ViewOrderDetails = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemEstimate_Add = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemEstimate_Actualize = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Add = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Update = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Delete = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Copy = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemCopy_WithNewCDP = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_SearchByOrderNumber = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Refresh = New DevComponents.DotNetBar.ButtonItem()
            Me.DataGridViewEstimates_Estimates = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.LabelRightSection_OverallStatus = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ProgressBarRightSection_OverallStatus = New AdvantageFramework.WinForm.Presentation.Controls.ProgressBar()
            Me.PanelForm_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ExpandableSplitterForm_LeftRightSections = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.TabControlForm_Estimates = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelDocumentsTab_Documents = New DevComponents.DotNetBar.TabControlPanel()
            Me.DocumentManagerControlDocuments_Documents = New AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl()
            Me.TabItemReport_DocumentsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelMasterPlansTab_MasterPlans = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewMasterPlans_MasterPlans = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemReport_MasterPlansTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelEstimatesTab_Estimates = New DevComponents.DotNetBar.TabControlPanel()
            Me.TabItemReport_EstimatesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelDashboardTab_Dashboard = New DevComponents.DotNetBar.TabControlPanel()
            Me.DashboardViewerDashboard_Dashboard = New AdvantageFramework.WinForm.Presentation.Controls.DashboardViewerControl()
            Me.TabItemReport_DashboardTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.ToolTipController = New DevExpress.Utils.ToolTipController(Me.components)
            Me.RibbonBarOptions_Documents = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemDocuments_Upload = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemUpload_EmailLink = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemDocuments_Download = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDocuments_OpenURL = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_LeftSection.SuspendLayout()
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_RightSection.SuspendLayout()
            CType(Me.TabControlForm_Estimates, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_Estimates.SuspendLayout()
            Me.TabControlPanelDocumentsTab_Documents.SuspendLayout()
            Me.TabControlPanelMasterPlansTab_MasterPlans.SuspendLayout()
            Me.TabControlPanelEstimatesTab_Estimates.SuspendLayout()
            Me.TabControlPanelDashboardTab_Dashboard.SuspendLayout()
            CType(Me.DashboardViewerDashboard_Dashboard, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'DataGridViewLeftSection_MediaPlans
            '
            Me.DataGridViewLeftSection_MediaPlans.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewLeftSection_MediaPlans.AllowDragAndDrop = False
            Me.DataGridViewLeftSection_MediaPlans.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewLeftSection_MediaPlans.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_MediaPlans.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_MediaPlans.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_MediaPlans.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_MediaPlans.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_MediaPlans.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_MediaPlans.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_MediaPlans.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_MediaPlans.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_MediaPlans.ItemDescription = "Media Plan(s)"
            Me.DataGridViewLeftSection_MediaPlans.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewLeftSection_MediaPlans.MultiSelect = False
            Me.DataGridViewLeftSection_MediaPlans.Name = "DataGridViewLeftSection_MediaPlans"
            Me.DataGridViewLeftSection_MediaPlans.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_MediaPlans.RunStandardValidation = True
            Me.DataGridViewLeftSection_MediaPlans.ShowColumnMenuOnRightClick = False
            Me.DataGridViewLeftSection_MediaPlans.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_MediaPlans.Size = New System.Drawing.Size(307, 609)
            Me.DataGridViewLeftSection_MediaPlans.TabIndex = 1
            Me.DataGridViewLeftSection_MediaPlans.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_MediaPlans.ViewCaptionHeight = -1
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Documents)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Print)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Dashboard)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_MasterPlans)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Estimate)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(28, 181)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(1078, 98)
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Options.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Options.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Options.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 3
            Me.RibbonBarMergeContainerForm_Options.Visible = False
            '
            'RibbonBarOptions_Print
            '
            Me.RibbonBarOptions_Print.AutoOverflowEnabled = False
            Me.RibbonBarOptions_Print.AutoSizeItems = False
            '
            '
            '
            Me.RibbonBarOptions_Print.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Print.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Print.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Print.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Print.DragDropSupport = True
            Me.RibbonBarOptions_Print.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_Print.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemPrint_FlowChart})
            Me.RibbonBarOptions_Print.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Print.Location = New System.Drawing.Point(756, 0)
            Me.RibbonBarOptions_Print.Name = "RibbonBarOptions_Print"
            Me.RibbonBarOptions_Print.SecurityEnabled = True
            Me.RibbonBarOptions_Print.Size = New System.Drawing.Size(92, 98)
            Me.RibbonBarOptions_Print.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Print.TabIndex = 5
            Me.RibbonBarOptions_Print.Text = "Print"
            '
            '
            '
            Me.RibbonBarOptions_Print.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Print.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Print.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemPrint_FlowChart
            '
            Me.ButtonItemPrint_FlowChart.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemPrint_FlowChart.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemPrint_FlowChart.Name = "ButtonItemPrint_FlowChart"
            Me.ButtonItemPrint_FlowChart.RibbonWordWrap = False
            Me.ButtonItemPrint_FlowChart.SecurityEnabled = True
            Me.ButtonItemPrint_FlowChart.SubItemsExpandWidth = 14
            Me.ButtonItemPrint_FlowChart.Text = "Flow Chart"
            '
            'RibbonBarOptions_Dashboard
            '
            Me.RibbonBarOptions_Dashboard.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Dashboard.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Dashboard.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Dashboard.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Dashboard.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Dashboard.DragDropSupport = True
            Me.RibbonBarOptions_Dashboard.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_Dashboard.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDashboard_Edit})
            Me.RibbonBarOptions_Dashboard.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Dashboard.Location = New System.Drawing.Point(691, 0)
            Me.RibbonBarOptions_Dashboard.MinimumSize = New System.Drawing.Size(65, 0)
            Me.RibbonBarOptions_Dashboard.Name = "RibbonBarOptions_Dashboard"
            Me.RibbonBarOptions_Dashboard.SecurityEnabled = True
            Me.RibbonBarOptions_Dashboard.Size = New System.Drawing.Size(65, 98)
            Me.RibbonBarOptions_Dashboard.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Dashboard.TabIndex = 3
            Me.RibbonBarOptions_Dashboard.Text = "Dashboard"
            '
            '
            '
            Me.RibbonBarOptions_Dashboard.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Dashboard.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Dashboard.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemDashboard_Edit
            '
            Me.ButtonItemDashboard_Edit.BeginGroup = True
            Me.ButtonItemDashboard_Edit.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemDashboard_Edit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDashboard_Edit.Name = "ButtonItemDashboard_Edit"
            Me.ButtonItemDashboard_Edit.RibbonWordWrap = False
            Me.ButtonItemDashboard_Edit.SubItemsExpandWidth = 14
            Me.ButtonItemDashboard_Edit.Text = "Edit"
            '
            'RibbonBarOptions_MasterPlans
            '
            Me.RibbonBarOptions_MasterPlans.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_MasterPlans.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_MasterPlans.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_MasterPlans.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_MasterPlans.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_MasterPlans.DragDropSupport = True
            Me.RibbonBarOptions_MasterPlans.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_MasterPlans.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemMasterPlans_View, Me.ButtonItemMasterPlans_Setup})
            Me.RibbonBarOptions_MasterPlans.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_MasterPlans.Location = New System.Drawing.Point(557, 0)
            Me.RibbonBarOptions_MasterPlans.MinimumSize = New System.Drawing.Size(85, 0)
            Me.RibbonBarOptions_MasterPlans.Name = "RibbonBarOptions_MasterPlans"
            Me.RibbonBarOptions_MasterPlans.SecurityEnabled = True
            Me.RibbonBarOptions_MasterPlans.Size = New System.Drawing.Size(134, 98)
            Me.RibbonBarOptions_MasterPlans.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_MasterPlans.TabIndex = 4
            Me.RibbonBarOptions_MasterPlans.Text = "Master Plans"
            '
            '
            '
            Me.RibbonBarOptions_MasterPlans.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_MasterPlans.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_MasterPlans.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemMasterPlans_View
            '
            Me.ButtonItemMasterPlans_View.BeginGroup = True
            Me.ButtonItemMasterPlans_View.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemMasterPlans_View.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemMasterPlans_View.Name = "ButtonItemMasterPlans_View"
            Me.ButtonItemMasterPlans_View.RibbonWordWrap = False
            Me.ButtonItemMasterPlans_View.SubItemsExpandWidth = 14
            Me.ButtonItemMasterPlans_View.Text = "View"
            '
            'ButtonItemMasterPlans_Setup
            '
            Me.ButtonItemMasterPlans_Setup.BeginGroup = True
            Me.ButtonItemMasterPlans_Setup.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemMasterPlans_Setup.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemMasterPlans_Setup.Name = "ButtonItemMasterPlans_Setup"
            Me.ButtonItemMasterPlans_Setup.RibbonWordWrap = False
            Me.ButtonItemMasterPlans_Setup.SubItemsExpandWidth = 14
            Me.ButtonItemMasterPlans_Setup.Text = "Setup"
            '
            'RibbonBarOptions_Estimate
            '
            Me.RibbonBarOptions_Estimate.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Estimate.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Estimate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Estimate.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Estimate.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Estimate.DragDropSupport = True
            Me.RibbonBarOptions_Estimate.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_Estimate.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemEstimate_View, Me.ButtonItemEstimate_ViewOrderDetails, Me.ButtonItemEstimate_Add, Me.ButtonItemEstimate_Actualize})
            Me.RibbonBarOptions_Estimate.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Estimate.Location = New System.Drawing.Point(308, 0)
            Me.RibbonBarOptions_Estimate.MinimumSize = New System.Drawing.Size(65, 0)
            Me.RibbonBarOptions_Estimate.Name = "RibbonBarOptions_Estimate"
            Me.RibbonBarOptions_Estimate.SecurityEnabled = True
            Me.RibbonBarOptions_Estimate.Size = New System.Drawing.Size(249, 98)
            Me.RibbonBarOptions_Estimate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Estimate.TabIndex = 2
            Me.RibbonBarOptions_Estimate.Text = "Estimates"
            '
            '
            '
            Me.RibbonBarOptions_Estimate.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Estimate.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Estimate.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemEstimate_View
            '
            Me.ButtonItemEstimate_View.BeginGroup = True
            Me.ButtonItemEstimate_View.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemEstimate_View.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemEstimate_View.Name = "ButtonItemEstimate_View"
            Me.ButtonItemEstimate_View.RibbonWordWrap = False
            Me.ButtonItemEstimate_View.SubItemsExpandWidth = 14
            Me.ButtonItemEstimate_View.Text = "View"
            '
            'ButtonItemEstimate_ViewOrderDetails
            '
            Me.ButtonItemEstimate_ViewOrderDetails.BeginGroup = True
            Me.ButtonItemEstimate_ViewOrderDetails.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemEstimate_ViewOrderDetails.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemEstimate_ViewOrderDetails.Name = "ButtonItemEstimate_ViewOrderDetails"
            Me.ButtonItemEstimate_ViewOrderDetails.RibbonWordWrap = False
            Me.ButtonItemEstimate_ViewOrderDetails.SubItemsExpandWidth = 14
            Me.ButtonItemEstimate_ViewOrderDetails.Text = "View Order Details"
            '
            'ButtonItemEstimate_Add
            '
            Me.ButtonItemEstimate_Add.BeginGroup = True
            Me.ButtonItemEstimate_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemEstimate_Add.Name = "ButtonItemEstimate_Add"
            Me.ButtonItemEstimate_Add.RibbonWordWrap = False
            Me.ButtonItemEstimate_Add.SubItemsExpandWidth = 14
            Me.ButtonItemEstimate_Add.Text = "Add"
            '
            'ButtonItemEstimate_Actualize
            '
            Me.ButtonItemEstimate_Actualize.BeginGroup = True
            Me.ButtonItemEstimate_Actualize.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemEstimate_Actualize.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemEstimate_Actualize.Name = "ButtonItemEstimate_Actualize"
            Me.ButtonItemEstimate_Actualize.RibbonWordWrap = False
            Me.ButtonItemEstimate_Actualize.SecurityEnabled = True
            Me.ButtonItemEstimate_Actualize.SubItemsExpandWidth = 14
            Me.ButtonItemEstimate_Actualize.Text = "Actualize"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Add, Me.ButtonItemActions_Update, Me.ButtonItemActions_Delete, Me.ButtonItemActions_Copy, Me.ButtonItemActions_SearchByOrderNumber, Me.ButtonItemActions_Refresh})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(308, 98)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 0
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
            'ButtonItemActions_Add
            '
            Me.ButtonItemActions_Add.BeginGroup = True
            Me.ButtonItemActions_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Add.Name = "ButtonItemActions_Add"
            Me.ButtonItemActions_Add.RibbonWordWrap = False
            Me.ButtonItemActions_Add.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Add.Text = "Add"
            '
            'ButtonItemActions_Update
            '
            Me.ButtonItemActions_Update.BeginGroup = True
            Me.ButtonItemActions_Update.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Update.Name = "ButtonItemActions_Update"
            Me.ButtonItemActions_Update.RibbonWordWrap = False
            Me.ButtonItemActions_Update.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Update.Text = "Update"
            '
            'ButtonItemActions_Delete
            '
            Me.ButtonItemActions_Delete.BeginGroup = True
            Me.ButtonItemActions_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Delete.Name = "ButtonItemActions_Delete"
            Me.ButtonItemActions_Delete.RibbonWordWrap = False
            Me.ButtonItemActions_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Delete.Text = "Delete"
            '
            'ButtonItemActions_Copy
            '
            Me.ButtonItemActions_Copy.BeginGroup = True
            Me.ButtonItemActions_Copy.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Copy.Name = "ButtonItemActions_Copy"
            Me.ButtonItemActions_Copy.RibbonWordWrap = False
            Me.ButtonItemActions_Copy.SplitButton = True
            Me.ButtonItemActions_Copy.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemCopy_WithNewCDP})
            Me.ButtonItemActions_Copy.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Copy.Text = "Copy"
            '
            'ButtonItemCopy_WithNewCDP
            '
            Me.ButtonItemCopy_WithNewCDP.Name = "ButtonItemCopy_WithNewCDP"
            Me.ButtonItemCopy_WithNewCDP.Text = "With New C/D/P"
            '
            'ButtonItemActions_SearchByOrderNumber
            '
            Me.ButtonItemActions_SearchByOrderNumber.BeginGroup = True
            Me.ButtonItemActions_SearchByOrderNumber.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_SearchByOrderNumber.Name = "ButtonItemActions_SearchByOrderNumber"
            Me.ButtonItemActions_SearchByOrderNumber.RibbonWordWrap = False
            Me.ButtonItemActions_SearchByOrderNumber.SubItemsExpandWidth = 14
            Me.ButtonItemActions_SearchByOrderNumber.Text = "Search By " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Order Number"
            '
            'ButtonItemActions_Refresh
            '
            Me.ButtonItemActions_Refresh.BeginGroup = True
            Me.ButtonItemActions_Refresh.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Refresh.Name = "ButtonItemActions_Refresh"
            Me.ButtonItemActions_Refresh.RibbonWordWrap = False
            Me.ButtonItemActions_Refresh.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Refresh.Text = "Refresh"
            '
            'DataGridViewEstimates_Estimates
            '
            Me.DataGridViewEstimates_Estimates.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewEstimates_Estimates.AllowDragAndDrop = False
            Me.DataGridViewEstimates_Estimates.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewEstimates_Estimates.AllowSelectGroupHeaderRow = True
            Me.DataGridViewEstimates_Estimates.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewEstimates_Estimates.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewEstimates_Estimates.AutoFilterLookupColumns = False
            Me.DataGridViewEstimates_Estimates.AutoloadRepositoryDatasource = True
            Me.DataGridViewEstimates_Estimates.AutoUpdateViewCaption = True
            Me.DataGridViewEstimates_Estimates.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewEstimates_Estimates.DataSource = Nothing
            Me.DataGridViewEstimates_Estimates.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewEstimates_Estimates.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewEstimates_Estimates.ItemDescription = "Item(s)"
            Me.DataGridViewEstimates_Estimates.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewEstimates_Estimates.MultiSelect = False
            Me.DataGridViewEstimates_Estimates.Name = "DataGridViewEstimates_Estimates"
            Me.DataGridViewEstimates_Estimates.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewEstimates_Estimates.RunStandardValidation = True
            Me.DataGridViewEstimates_Estimates.ShowColumnMenuOnRightClick = False
            Me.DataGridViewEstimates_Estimates.ShowSelectDeselectAllButtons = False
            Me.DataGridViewEstimates_Estimates.Size = New System.Drawing.Size(761, 519)
            Me.DataGridViewEstimates_Estimates.TabIndex = 4
            Me.DataGridViewEstimates_Estimates.UseEmbeddedNavigator = False
            Me.DataGridViewEstimates_Estimates.ViewCaptionHeight = -1
            '
            'LabelRightSection_OverallStatus
            '
            Me.LabelRightSection_OverallStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelRightSection_OverallStatus.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRightSection_OverallStatus.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelRightSection_OverallStatus.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelRightSection_OverallStatus.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelRightSection_OverallStatus.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelRightSection_OverallStatus.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelRightSection_OverallStatus.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelRightSection_OverallStatus.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRightSection_OverallStatus.Location = New System.Drawing.Point(6, 12)
            Me.LabelRightSection_OverallStatus.Name = "LabelRightSection_OverallStatus"
            Me.LabelRightSection_OverallStatus.Size = New System.Drawing.Size(769, 20)
            Me.LabelRightSection_OverallStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRightSection_OverallStatus.TabIndex = 9
            Me.LabelRightSection_OverallStatus.Text = "Overall Status"
            '
            'ProgressBarRightSection_OverallStatus
            '
            Me.ProgressBarRightSection_OverallStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.ProgressBarRightSection_OverallStatus.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ProgressBarRightSection_OverallStatus.ChunkColor = System.Drawing.Color.ForestGreen
            Me.ProgressBarRightSection_OverallStatus.Location = New System.Drawing.Point(6, 38)
            Me.ProgressBarRightSection_OverallStatus.Name = "ProgressBarRightSection_OverallStatus"
            Me.ProgressBarRightSection_OverallStatus.Size = New System.Drawing.Size(769, 23)
            Me.ProgressBarRightSection_OverallStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ProgressBarRightSection_OverallStatus.TabIndex = 10
            Me.ProgressBarRightSection_OverallStatus.Text = "Gross Amount: $0.00"
            Me.ProgressBarRightSection_OverallStatus.TextVisible = True
            '
            'PanelForm_LeftSection
            '
            Me.PanelForm_LeftSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelForm_LeftSection.Appearance.Options.UseBackColor = True
            Me.PanelForm_LeftSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_MediaPlans)
            Me.PanelForm_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelForm_LeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_LeftSection.Name = "PanelForm_LeftSection"
            Me.PanelForm_LeftSection.Size = New System.Drawing.Size(325, 633)
            Me.PanelForm_LeftSection.TabIndex = 11
            '
            'ExpandableSplitterForm_LeftRightSections
            '
            Me.ExpandableSplitterForm_LeftRightSections.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRightSections.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterForm_LeftRightSections.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterForm_LeftRightSections.ExpandableControl = Me.PanelForm_LeftSection
            Me.ExpandableSplitterForm_LeftRightSections.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRightSections.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterForm_LeftRightSections.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRightSections.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterForm_LeftRightSections.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRightSections.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterForm_LeftRightSections.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRightSections.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterForm_LeftRightSections.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRightSections.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRightSections.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterForm_LeftRightSections.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterForm_LeftRightSections.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRightSections.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterForm_LeftRightSections.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRightSections.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterForm_LeftRightSections.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRightSections.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterForm_LeftRightSections.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRightSections.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterForm_LeftRightSections.Location = New System.Drawing.Point(325, 0)
            Me.ExpandableSplitterForm_LeftRightSections.Name = "ExpandableSplitterForm_LeftRightSections"
            Me.ExpandableSplitterForm_LeftRightSections.Size = New System.Drawing.Size(6, 633)
            Me.ExpandableSplitterForm_LeftRightSections.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterForm_LeftRightSections.TabIndex = 12
            Me.ExpandableSplitterForm_LeftRightSections.TabStop = False
            '
            'PanelForm_RightSection
            '
            Me.PanelForm_RightSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelForm_RightSection.Appearance.Options.UseBackColor = True
            Me.PanelForm_RightSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelForm_RightSection.Controls.Add(Me.TabControlForm_Estimates)
            Me.PanelForm_RightSection.Controls.Add(Me.LabelRightSection_OverallStatus)
            Me.PanelForm_RightSection.Controls.Add(Me.ProgressBarRightSection_OverallStatus)
            Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_RightSection.Location = New System.Drawing.Point(331, 0)
            Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
            Me.PanelForm_RightSection.Size = New System.Drawing.Size(787, 633)
            Me.PanelForm_RightSection.TabIndex = 13
            '
            'TabControlForm_Estimates
            '
            Me.TabControlForm_Estimates.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlForm_Estimates.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.TabControlForm_Estimates.CanReorderTabs = False
            Me.TabControlForm_Estimates.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlForm_Estimates.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlForm_Estimates.Controls.Add(Me.TabControlPanelDocumentsTab_Documents)
            Me.TabControlForm_Estimates.Controls.Add(Me.TabControlPanelEstimatesTab_Estimates)
            Me.TabControlForm_Estimates.Controls.Add(Me.TabControlPanelMasterPlansTab_MasterPlans)
            Me.TabControlForm_Estimates.Controls.Add(Me.TabControlPanelDashboardTab_Dashboard)
            Me.TabControlForm_Estimates.Location = New System.Drawing.Point(6, 67)
            Me.TabControlForm_Estimates.Name = "TabControlForm_Estimates"
            Me.TabControlForm_Estimates.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_Estimates.SelectedTabIndex = 0
            Me.TabControlForm_Estimates.Size = New System.Drawing.Size(769, 554)
            Me.TabControlForm_Estimates.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_Estimates.TabIndex = 11
            Me.TabControlForm_Estimates.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_Estimates.Tabs.Add(Me.TabItemReport_EstimatesTab)
            Me.TabControlForm_Estimates.Tabs.Add(Me.TabItemReport_DashboardTab)
            Me.TabControlForm_Estimates.Tabs.Add(Me.TabItemReport_MasterPlansTab)
            Me.TabControlForm_Estimates.Tabs.Add(Me.TabItemReport_DocumentsTab)
            Me.TabControlForm_Estimates.Text = "TabControl1"
            '
            'TabControlPanelDocumentsTab_Documents
            '
            Me.TabControlPanelDocumentsTab_Documents.Controls.Add(Me.DocumentManagerControlDocuments_Documents)
            Me.TabControlPanelDocumentsTab_Documents.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelDocumentsTab_Documents.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelDocumentsTab_Documents.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelDocumentsTab_Documents.Name = "TabControlPanelDocumentsTab_Documents"
            Me.TabControlPanelDocumentsTab_Documents.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelDocumentsTab_Documents.Size = New System.Drawing.Size(769, 527)
            Me.TabControlPanelDocumentsTab_Documents.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelDocumentsTab_Documents.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDocumentsTab_Documents.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelDocumentsTab_Documents.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelDocumentsTab_Documents.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelDocumentsTab_Documents.Style.GradientAngle = 90
            Me.TabControlPanelDocumentsTab_Documents.TabIndex = 10
            Me.TabControlPanelDocumentsTab_Documents.TabItem = Me.TabItemReport_DocumentsTab
            '
            'DocumentManagerControlDocuments_Documents
            '
            Me.DocumentManagerControlDocuments_Documents.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DocumentManagerControlDocuments_Documents.Location = New System.Drawing.Point(4, 4)
            Me.DocumentManagerControlDocuments_Documents.Name = "DocumentManagerControlDocuments_Documents"
            Me.DocumentManagerControlDocuments_Documents.Size = New System.Drawing.Size(761, 519)
            Me.DocumentManagerControlDocuments_Documents.TabIndex = 1
            '
            'TabItemReport_DocumentsTab
            '
            Me.TabItemReport_DocumentsTab.AttachedControl = Me.TabControlPanelDocumentsTab_Documents
            Me.TabItemReport_DocumentsTab.Name = "TabItemReport_DocumentsTab"
            Me.TabItemReport_DocumentsTab.Text = "Documents"
            '
            'TabControlPanelMasterPlansTab_MasterPlans
            '
            Me.TabControlPanelMasterPlansTab_MasterPlans.Controls.Add(Me.DataGridViewMasterPlans_MasterPlans)
            Me.TabControlPanelMasterPlansTab_MasterPlans.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelMasterPlansTab_MasterPlans.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelMasterPlansTab_MasterPlans.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelMasterPlansTab_MasterPlans.Name = "TabControlPanelMasterPlansTab_MasterPlans"
            Me.TabControlPanelMasterPlansTab_MasterPlans.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelMasterPlansTab_MasterPlans.Size = New System.Drawing.Size(769, 527)
            Me.TabControlPanelMasterPlansTab_MasterPlans.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelMasterPlansTab_MasterPlans.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelMasterPlansTab_MasterPlans.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelMasterPlansTab_MasterPlans.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelMasterPlansTab_MasterPlans.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelMasterPlansTab_MasterPlans.Style.GradientAngle = 90
            Me.TabControlPanelMasterPlansTab_MasterPlans.TabIndex = 2
            Me.TabControlPanelMasterPlansTab_MasterPlans.TabItem = Me.TabItemReport_MasterPlansTab
            '
            'DataGridViewMasterPlans_MasterPlans
            '
            Me.DataGridViewMasterPlans_MasterPlans.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewMasterPlans_MasterPlans.AllowDragAndDrop = False
            Me.DataGridViewMasterPlans_MasterPlans.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewMasterPlans_MasterPlans.AllowSelectGroupHeaderRow = True
            Me.DataGridViewMasterPlans_MasterPlans.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewMasterPlans_MasterPlans.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewMasterPlans_MasterPlans.AutoFilterLookupColumns = False
            Me.DataGridViewMasterPlans_MasterPlans.AutoloadRepositoryDatasource = True
            Me.DataGridViewMasterPlans_MasterPlans.AutoUpdateViewCaption = True
            Me.DataGridViewMasterPlans_MasterPlans.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewMasterPlans_MasterPlans.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewMasterPlans_MasterPlans.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewMasterPlans_MasterPlans.ItemDescription = "Master Plan(s)"
            Me.DataGridViewMasterPlans_MasterPlans.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewMasterPlans_MasterPlans.MultiSelect = False
            Me.DataGridViewMasterPlans_MasterPlans.Name = "DataGridViewMasterPlans_MasterPlans"
            Me.DataGridViewMasterPlans_MasterPlans.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewMasterPlans_MasterPlans.RunStandardValidation = True
            Me.DataGridViewMasterPlans_MasterPlans.ShowColumnMenuOnRightClick = False
            Me.DataGridViewMasterPlans_MasterPlans.ShowSelectDeselectAllButtons = False
            Me.DataGridViewMasterPlans_MasterPlans.Size = New System.Drawing.Size(761, 519)
            Me.DataGridViewMasterPlans_MasterPlans.TabIndex = 5
            Me.DataGridViewMasterPlans_MasterPlans.UseEmbeddedNavigator = False
            Me.DataGridViewMasterPlans_MasterPlans.ViewCaptionHeight = -1
            '
            'TabItemReport_MasterPlansTab
            '
            Me.TabItemReport_MasterPlansTab.AttachedControl = Me.TabControlPanelMasterPlansTab_MasterPlans
            Me.TabItemReport_MasterPlansTab.Name = "TabItemReport_MasterPlansTab"
            Me.TabItemReport_MasterPlansTab.Text = "Master Plans"
            '
            'TabControlPanelEstimatesTab_Estimates
            '
            Me.TabControlPanelEstimatesTab_Estimates.Controls.Add(Me.DataGridViewEstimates_Estimates)
            Me.TabControlPanelEstimatesTab_Estimates.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelEstimatesTab_Estimates.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelEstimatesTab_Estimates.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelEstimatesTab_Estimates.Name = "TabControlPanelEstimatesTab_Estimates"
            Me.TabControlPanelEstimatesTab_Estimates.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelEstimatesTab_Estimates.Size = New System.Drawing.Size(769, 527)
            Me.TabControlPanelEstimatesTab_Estimates.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelEstimatesTab_Estimates.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelEstimatesTab_Estimates.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelEstimatesTab_Estimates.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelEstimatesTab_Estimates.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelEstimatesTab_Estimates.Style.GradientAngle = 90
            Me.TabControlPanelEstimatesTab_Estimates.TabIndex = 0
            Me.TabControlPanelEstimatesTab_Estimates.TabItem = Me.TabItemReport_EstimatesTab
            '
            'TabItemReport_EstimatesTab
            '
            Me.TabItemReport_EstimatesTab.AttachedControl = Me.TabControlPanelEstimatesTab_Estimates
            Me.TabItemReport_EstimatesTab.Name = "TabItemReport_EstimatesTab"
            Me.TabItemReport_EstimatesTab.Text = "Estimates"
            '
            'TabControlPanelDashboardTab_Dashboard
            '
            Me.TabControlPanelDashboardTab_Dashboard.Controls.Add(Me.DashboardViewerDashboard_Dashboard)
            Me.TabControlPanelDashboardTab_Dashboard.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelDashboardTab_Dashboard.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelDashboardTab_Dashboard.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelDashboardTab_Dashboard.Name = "TabControlPanelDashboardTab_Dashboard"
            Me.TabControlPanelDashboardTab_Dashboard.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelDashboardTab_Dashboard.Size = New System.Drawing.Size(769, 527)
            Me.TabControlPanelDashboardTab_Dashboard.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelDashboardTab_Dashboard.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDashboardTab_Dashboard.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelDashboardTab_Dashboard.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelDashboardTab_Dashboard.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelDashboardTab_Dashboard.Style.GradientAngle = 90
            Me.TabControlPanelDashboardTab_Dashboard.TabIndex = 1
            Me.TabControlPanelDashboardTab_Dashboard.TabItem = Me.TabItemReport_DashboardTab
            '
            'DashboardViewerDashboard_Dashboard
            '
            Me.DashboardViewerDashboard_Dashboard.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DashboardViewerDashboard_Dashboard.Location = New System.Drawing.Point(4, 4)
            Me.DashboardViewerDashboard_Dashboard.Name = "DashboardViewerDashboard_Dashboard"
            Me.DashboardViewerDashboard_Dashboard.PdfExportOptions.DashboardStatePosition = DevExpress.DashboardCommon.DashboardStateExportPosition.SeparatePage
            Me.DashboardViewerDashboard_Dashboard.PrintPreviewOptions.DashboardStatePosition = DevExpress.DashboardCommon.DashboardStateExportPosition.SeparatePage
            Me.DashboardViewerDashboard_Dashboard.Size = New System.Drawing.Size(761, 519)
            Me.DashboardViewerDashboard_Dashboard.TabIndex = 0
            '
            'TabItemReport_DashboardTab
            '
            Me.TabItemReport_DashboardTab.AttachedControl = Me.TabControlPanelDashboardTab_Dashboard
            Me.TabItemReport_DashboardTab.Name = "TabItemReport_DashboardTab"
            Me.TabItemReport_DashboardTab.Text = "Dashboard"
            '
            'ToolTipController
            '
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
            Me.RibbonBarOptions_Documents.Location = New System.Drawing.Point(848, 0)
            Me.RibbonBarOptions_Documents.Name = "RibbonBarOptions_Documents"
            Me.RibbonBarOptions_Documents.SecurityEnabled = True
            Me.RibbonBarOptions_Documents.Size = New System.Drawing.Size(193, 98)
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
            'MediaPlanningForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1118, 633)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.PanelForm_RightSection)
            Me.Controls.Add(Me.ExpandableSplitterForm_LeftRightSections)
            Me.Controls.Add(Me.PanelForm_LeftSection)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaPlanningForm"
            Me.Text = "Media Planning"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_LeftSection.ResumeLayout(False)
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_RightSection.ResumeLayout(False)
            CType(Me.TabControlForm_Estimates, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_Estimates.ResumeLayout(False)
            Me.TabControlPanelDocumentsTab_Documents.ResumeLayout(False)
            Me.TabControlPanelMasterPlansTab_MasterPlans.ResumeLayout(False)
            Me.TabControlPanelEstimatesTab_Estimates.ResumeLayout(False)
            Me.TabControlPanelDashboardTab_Dashboard.ResumeLayout(False)
            CType(Me.DashboardViewerDashboard_Dashboard, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewLeftSection_MediaPlans As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Add As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Refresh As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Update As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Copy As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Delete As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents DataGridViewEstimates_Estimates As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents LabelRightSection_OverallStatus As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ProgressBarRightSection_OverallStatus As AdvantageFramework.WinForm.Presentation.Controls.ProgressBar
        Friend WithEvents PanelForm_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ExpandableSplitterForm_LeftRightSections As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelForm_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents TabControlForm_Estimates As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelEstimatesTab_Estimates As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemReport_EstimatesTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelDashboardTab_Dashboard As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DashboardViewerDashboard_Dashboard As AdvantageFramework.WinForm.Presentation.Controls.DashboardViewerControl
        Friend WithEvents TabItemReport_DashboardTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents ButtonItemCopy_WithNewCDP As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_Estimate As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemEstimate_ViewOrderDetails As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_Dashboard As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemDashboard_Edit As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_MasterPlans As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemMasterPlans_View As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemMasterPlans_Setup As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents TabControlPanelMasterPlansTab_MasterPlans As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewMasterPlans_MasterPlans As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TabItemReport_MasterPlansTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents ToolTipController As DevExpress.Utils.ToolTipController
        Friend WithEvents ButtonItemEstimate_View As DevComponents.DotNetBar.ButtonItem
        Private WithEvents RibbonBarOptions_Print As WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemPrint_FlowChart As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemEstimate_Add As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_SearchByOrderNumber As DevComponents.DotNetBar.ButtonItem
        Private WithEvents ButtonItemEstimate_Actualize As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents TabControlPanelDocumentsTab_Documents As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemReport_DocumentsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents DocumentManagerControlDocuments_Documents As WinForm.Presentation.Controls.DocumentManagerControl
        Friend WithEvents RibbonBarOptions_Documents As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemDocuments_Upload As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemUpload_EmailLink As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemDocuments_Download As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDocuments_OpenURL As WinForm.Presentation.Controls.ButtonItem
    End Class

End Namespace
