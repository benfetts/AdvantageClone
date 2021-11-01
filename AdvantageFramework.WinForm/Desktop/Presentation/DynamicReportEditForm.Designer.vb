Namespace Desktop.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class DynamicReportEditForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DynamicReportEditForm))
            Me.DataGridViewReport_Report = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Refresh = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemDataset_Refresh = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Data = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemData_Load = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_QuickText = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemQuickText_Edit = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Dashboard = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemDashboard_Edit = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Filter = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemFilter_ShowFilterEditor = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemFilter_ShowAutoFilterRow = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_View = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainerView_ViewLeft = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemViewLeft_AllowCellMerging = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemViewLeft_ShowViewCaption = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemViewLeft_ShowGroupByBox = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_UnboundColumns = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemUnboundColumns_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_QuickCustomize = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemQuickCustomize_Columns = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Report = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainerReport_Report = New DevComponents.DotNetBar.ItemContainer()
            Me.ComboBoxItemReport_DynamicReport = New DevComponents.DotNetBar.ComboBoxItem()
            Me.ButtonItemReport_LoadTemplate = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemReport_Templates = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemReport_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemReport_SaveAs = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemReport_Schedule = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.LabelItemData_Refresh = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.RibbonBarMergeContainerForm_Printing = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarPrinting_HeaderFooterImages = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemHeaderFooterImages_Manage = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarPrinting_Options = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainerOptions_OptionsLeft = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemOptionsLeft_AutoSizeColumnsToPage = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemOptionsLeft_PrintFilterInfo = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ItemContainerOptions_OptionsMiddle = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemOptionsMiddle_PrintHeader = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemOptionsMiddle_PrintFooter = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemOptionsMiddle_PrintGroupFooter = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ItemContainerOptions_OptionsRight = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemOptionsRight_PrintSelectedRowsOnly = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarPrinting_Printing = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemPrinting_Print = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.TabControlForm_Report = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelReportTab_Report = New DevComponents.DotNetBar.TabControlPanel()
            Me.TabItemReport_ReportTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelDashboardTab_Dashboard = New DevComponents.DotNetBar.TabControlPanel()
            Me.DashboardViewerDashboard_Dashboard = New AdvantageFramework.WinForm.Presentation.Controls.DashboardViewerControl()
            Me.TabItemReport_DashboardTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelQuickTextTab_QuickText = New DevComponents.DotNetBar.TabControlPanel()
            Me.SnapControlQuickText_Report = New DevExpress.Snap.SnapControl()
            Me.TabItemReport_QuickTextTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.LabelItemDataset_LastUpdated = New DevComponents.DotNetBar.LabelItem()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.RibbonBarMergeContainerForm_Printing.SuspendLayout()
            CType(Me.TabControlForm_Report, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_Report.SuspendLayout()
            Me.TabControlPanelReportTab_Report.SuspendLayout()
            Me.TabControlPanelDashboardTab_Dashboard.SuspendLayout()
            CType(Me.DashboardViewerDashboard_Dashboard, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelQuickTextTab_QuickText.SuspendLayout()
            Me.SuspendLayout()
            '
            'DataGridViewReport_Report
            '
            Me.DataGridViewReport_Report.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewReport_Report.AllowDragAndDrop = False
            Me.DataGridViewReport_Report.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewReport_Report.AllowSelectGroupHeaderRow = True
            Me.DataGridViewReport_Report.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewReport_Report.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewReport_Report.AutoFilterLookupColumns = False
            Me.DataGridViewReport_Report.AutoloadRepositoryDatasource = True
            Me.DataGridViewReport_Report.AutoUpdateViewCaption = True
            Me.DataGridViewReport_Report.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.DynamicReport
            Me.DataGridViewReport_Report.DataSource = Nothing
            Me.DataGridViewReport_Report.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewReport_Report.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewReport_Report.ItemDescription = "Item(s)"
            Me.DataGridViewReport_Report.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewReport_Report.MultiSelect = True
            Me.DataGridViewReport_Report.Name = "DataGridViewReport_Report"
            Me.DataGridViewReport_Report.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewReport_Report.RunStandardValidation = True
            Me.DataGridViewReport_Report.ShowColumnMenuOnRightClick = False
            Me.DataGridViewReport_Report.ShowSelectDeselectAllButtons = False
            Me.DataGridViewReport_Report.Size = New System.Drawing.Size(1547, 396)
            Me.DataGridViewReport_Report.TabIndex = 0
            Me.DataGridViewReport_Report.UseEmbeddedNavigator = False
            Me.DataGridViewReport_Report.ViewCaptionHeight = -1
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Refresh)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Data)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_QuickText)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Dashboard)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Filter)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_View)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_UnboundColumns)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_QuickCustomize)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Report)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(12, 12)
            Me.RibbonBarMergeContainerForm_Options.MergeRibbonGroupName = "DynamicReport"
            Me.RibbonBarMergeContainerForm_Options.MergeRibbonTabItemIndex = 2
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(1487, 98)
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
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 1
            Me.RibbonBarMergeContainerForm_Options.Visible = False
            '
            'RibbonBarOptions_Refresh
            '
            Me.RibbonBarOptions_Refresh.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Refresh.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Refresh.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Refresh.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Refresh.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Refresh.DragDropSupport = True
            Me.RibbonBarOptions_Refresh.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDataset_Refresh, Me.LabelItemDataset_LastUpdated})
            Me.RibbonBarOptions_Refresh.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Refresh.Location = New System.Drawing.Point(1206, 0)
            Me.RibbonBarOptions_Refresh.Name = "RibbonBarOptions_Refresh"
            Me.RibbonBarOptions_Refresh.SecurityEnabled = True
            Me.RibbonBarOptions_Refresh.Size = New System.Drawing.Size(164, 98)
            Me.RibbonBarOptions_Refresh.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Refresh.TabIndex = 5
            Me.RibbonBarOptions_Refresh.Text = "Dataset"
            '
            '
            '
            Me.RibbonBarOptions_Refresh.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Refresh.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Refresh.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemDataset_Refresh
            '
            Me.ButtonItemDataset_Refresh.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemDataset_Refresh.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDataset_Refresh.Name = "ButtonItemDataset_Refresh"
            Me.ButtonItemDataset_Refresh.RibbonWordWrap = False
            Me.ButtonItemDataset_Refresh.SecurityEnabled = True
            Me.ButtonItemDataset_Refresh.Stretch = True
            Me.ButtonItemDataset_Refresh.SubItemsExpandWidth = 14
            Me.ButtonItemDataset_Refresh.Text = "Refresh"
            '
            'RibbonBarOptions_Data
            '
            Me.RibbonBarOptions_Data.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Data.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Data.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Data.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Data.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Data.DragDropSupport = True
            Me.RibbonBarOptions_Data.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemData_Load})
            Me.RibbonBarOptions_Data.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Data.Location = New System.Drawing.Point(1141, 0)
            Me.RibbonBarOptions_Data.Name = "RibbonBarOptions_Data"
            Me.RibbonBarOptions_Data.SecurityEnabled = True
            Me.RibbonBarOptions_Data.Size = New System.Drawing.Size(65, 98)
            Me.RibbonBarOptions_Data.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Data.TabIndex = 5
            Me.RibbonBarOptions_Data.Text = "Data"
            '
            '
            '
            Me.RibbonBarOptions_Data.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Data.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Data.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemData_Load
            '
            Me.ButtonItemData_Load.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemData_Load.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemData_Load.Name = "ButtonItemData_Load"
            Me.ButtonItemData_Load.RibbonWordWrap = False
            Me.ButtonItemData_Load.SecurityEnabled = True
            Me.ButtonItemData_Load.Stretch = True
            Me.ButtonItemData_Load.SubItemsExpandWidth = 14
            Me.ButtonItemData_Load.Text = "Load"
            '
            'RibbonBarOptions_QuickText
            '
            Me.RibbonBarOptions_QuickText.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_QuickText.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_QuickText.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_QuickText.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_QuickText.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_QuickText.DragDropSupport = True
            Me.RibbonBarOptions_QuickText.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_QuickText.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemQuickText_Edit})
            Me.RibbonBarOptions_QuickText.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_QuickText.Location = New System.Drawing.Point(1076, 0)
            Me.RibbonBarOptions_QuickText.MinimumSize = New System.Drawing.Size(65, 0)
            Me.RibbonBarOptions_QuickText.Name = "RibbonBarOptions_QuickText"
            Me.RibbonBarOptions_QuickText.SecurityEnabled = True
            Me.RibbonBarOptions_QuickText.Size = New System.Drawing.Size(65, 98)
            Me.RibbonBarOptions_QuickText.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_QuickText.TabIndex = 13
            Me.RibbonBarOptions_QuickText.Text = "QuickText"
            '
            '
            '
            Me.RibbonBarOptions_QuickText.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_QuickText.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_QuickText.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemQuickText_Edit
            '
            Me.ButtonItemQuickText_Edit.BeginGroup = True
            Me.ButtonItemQuickText_Edit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemQuickText_Edit.Name = "ButtonItemQuickText_Edit"
            Me.ButtonItemQuickText_Edit.RibbonWordWrap = False
            Me.ButtonItemQuickText_Edit.SecurityEnabled = True
            Me.ButtonItemQuickText_Edit.SubItemsExpandWidth = 14
            Me.ButtonItemQuickText_Edit.Text = "Edit"
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
            Me.RibbonBarOptions_Dashboard.Location = New System.Drawing.Point(1011, 0)
            Me.RibbonBarOptions_Dashboard.MinimumSize = New System.Drawing.Size(65, 0)
            Me.RibbonBarOptions_Dashboard.Name = "RibbonBarOptions_Dashboard"
            Me.RibbonBarOptions_Dashboard.SecurityEnabled = True
            Me.RibbonBarOptions_Dashboard.Size = New System.Drawing.Size(65, 98)
            Me.RibbonBarOptions_Dashboard.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Dashboard.TabIndex = 12
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
            Me.ButtonItemDashboard_Edit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDashboard_Edit.Name = "ButtonItemDashboard_Edit"
            Me.ButtonItemDashboard_Edit.RibbonWordWrap = False
            Me.ButtonItemDashboard_Edit.SecurityEnabled = True
            Me.ButtonItemDashboard_Edit.SubItemsExpandWidth = 14
            Me.ButtonItemDashboard_Edit.Text = "Edit"
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
            Me.RibbonBarOptions_Filter.Location = New System.Drawing.Point(838, 0)
            Me.RibbonBarOptions_Filter.Name = "RibbonBarOptions_Filter"
            Me.RibbonBarOptions_Filter.SecurityEnabled = True
            Me.RibbonBarOptions_Filter.Size = New System.Drawing.Size(173, 98)
            Me.RibbonBarOptions_Filter.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Filter.TabIndex = 3
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
            Me.ButtonItemFilter_ShowFilterEditor.SecurityEnabled = True
            Me.ButtonItemFilter_ShowFilterEditor.SubItemsExpandWidth = 14
            Me.ButtonItemFilter_ShowFilterEditor.Text = "Show Filter Editor"
            '
            'ButtonItemFilter_ShowAutoFilterRow
            '
            Me.ButtonItemFilter_ShowAutoFilterRow.AutoCheckOnClick = True
            Me.ButtonItemFilter_ShowAutoFilterRow.Name = "ButtonItemFilter_ShowAutoFilterRow"
            Me.ButtonItemFilter_ShowAutoFilterRow.SecurityEnabled = True
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
            Me.RibbonBarOptions_View.Location = New System.Drawing.Point(693, 0)
            Me.RibbonBarOptions_View.Name = "RibbonBarOptions_View"
            Me.RibbonBarOptions_View.SecurityEnabled = True
            Me.RibbonBarOptions_View.Size = New System.Drawing.Size(145, 98)
            Me.RibbonBarOptions_View.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_View.TabIndex = 2
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
            Me.ItemContainerView_ViewLeft.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerView_ViewLeft.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemViewLeft_AllowCellMerging
            '
            Me.ButtonItemViewLeft_AllowCellMerging.AutoCheckOnClick = True
            Me.ButtonItemViewLeft_AllowCellMerging.Name = "ButtonItemViewLeft_AllowCellMerging"
            Me.ButtonItemViewLeft_AllowCellMerging.SecurityEnabled = True
            Me.ButtonItemViewLeft_AllowCellMerging.Stretch = True
            Me.ButtonItemViewLeft_AllowCellMerging.SubItemsExpandWidth = 14
            Me.ButtonItemViewLeft_AllowCellMerging.Text = "Allow Cell Merging"
            '
            'ButtonItemViewLeft_ShowViewCaption
            '
            Me.ButtonItemViewLeft_ShowViewCaption.AutoCheckOnClick = True
            Me.ButtonItemViewLeft_ShowViewCaption.Checked = True
            Me.ButtonItemViewLeft_ShowViewCaption.Name = "ButtonItemViewLeft_ShowViewCaption"
            Me.ButtonItemViewLeft_ShowViewCaption.SecurityEnabled = True
            Me.ButtonItemViewLeft_ShowViewCaption.SubItemsExpandWidth = 14
            Me.ButtonItemViewLeft_ShowViewCaption.Text = "Show View Caption"
            '
            'ButtonItemViewLeft_ShowGroupByBox
            '
            Me.ButtonItemViewLeft_ShowGroupByBox.AutoCheckOnClick = True
            Me.ButtonItemViewLeft_ShowGroupByBox.Name = "ButtonItemViewLeft_ShowGroupByBox"
            Me.ButtonItemViewLeft_ShowGroupByBox.SecurityEnabled = True
            Me.ButtonItemViewLeft_ShowGroupByBox.Stretch = True
            Me.ButtonItemViewLeft_ShowGroupByBox.SubItemsExpandWidth = 14
            Me.ButtonItemViewLeft_ShowGroupByBox.Text = "Show Group By Box"
            '
            'RibbonBarOptions_UnboundColumns
            '
            Me.RibbonBarOptions_UnboundColumns.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_UnboundColumns.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_UnboundColumns.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_UnboundColumns.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_UnboundColumns.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_UnboundColumns.DragDropSupport = True
            Me.RibbonBarOptions_UnboundColumns.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_UnboundColumns.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemUnboundColumns_Add})
            Me.RibbonBarOptions_UnboundColumns.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_UnboundColumns.Location = New System.Drawing.Point(596, 0)
            Me.RibbonBarOptions_UnboundColumns.MinimumSize = New System.Drawing.Size(97, 0)
            Me.RibbonBarOptions_UnboundColumns.Name = "RibbonBarOptions_UnboundColumns"
            Me.RibbonBarOptions_UnboundColumns.SecurityEnabled = True
            Me.RibbonBarOptions_UnboundColumns.Size = New System.Drawing.Size(97, 98)
            Me.RibbonBarOptions_UnboundColumns.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_UnboundColumns.TabIndex = 14
            Me.RibbonBarOptions_UnboundColumns.Text = "Unbound Columns"
            '
            '
            '
            Me.RibbonBarOptions_UnboundColumns.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_UnboundColumns.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_UnboundColumns.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemUnboundColumns_Add
            '
            Me.ButtonItemUnboundColumns_Add.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemUnboundColumns_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemUnboundColumns_Add.Name = "ButtonItemUnboundColumns_Add"
            Me.ButtonItemUnboundColumns_Add.RibbonWordWrap = False
            Me.ButtonItemUnboundColumns_Add.SecurityEnabled = True
            Me.ButtonItemUnboundColumns_Add.Stretch = True
            Me.ButtonItemUnboundColumns_Add.SubItemsExpandWidth = 14
            Me.ButtonItemUnboundColumns_Add.Text = "Add"
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
            Me.RibbonBarOptions_QuickCustomize.Location = New System.Drawing.Point(506, 0)
            Me.RibbonBarOptions_QuickCustomize.MinimumSize = New System.Drawing.Size(90, 0)
            Me.RibbonBarOptions_QuickCustomize.Name = "RibbonBarOptions_QuickCustomize"
            Me.RibbonBarOptions_QuickCustomize.SecurityEnabled = True
            Me.RibbonBarOptions_QuickCustomize.Size = New System.Drawing.Size(90, 98)
            Me.RibbonBarOptions_QuickCustomize.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_QuickCustomize.TabIndex = 1
            Me.RibbonBarOptions_QuickCustomize.Text = "Quick Customize"
            '
            '
            '
            Me.RibbonBarOptions_QuickCustomize.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_QuickCustomize.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_QuickCustomize.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemQuickCustomize_Columns
            '
            Me.ButtonItemQuickCustomize_Columns.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemQuickCustomize_Columns.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemQuickCustomize_Columns.Name = "ButtonItemQuickCustomize_Columns"
            Me.ButtonItemQuickCustomize_Columns.SecurityEnabled = True
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
            Me.RibbonBarOptions_Report.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerReport_Report, Me.ButtonItemReport_LoadTemplate, Me.ButtonItemReport_Templates, Me.ButtonItemReport_Save, Me.ButtonItemReport_SaveAs, Me.ButtonItemReport_Schedule})
            Me.RibbonBarOptions_Report.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Report.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Report.Name = "RibbonBarOptions_Report"
            Me.RibbonBarOptions_Report.SecurityEnabled = True
            Me.RibbonBarOptions_Report.Size = New System.Drawing.Size(506, 98)
            Me.RibbonBarOptions_Report.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Report.TabIndex = 0
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
            'ItemContainerReport_Report
            '
            '
            '
            '
            Me.ItemContainerReport_Report.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerReport_Report.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerReport_Report.Name = "ItemContainerReport_Report"
            Me.ItemContainerReport_Report.ResizeItemsToFit = False
            Me.ItemContainerReport_Report.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ComboBoxItemReport_DynamicReport})
            '
            '
            '
            Me.ItemContainerReport_Report.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerReport_Report.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerReport_Report.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ComboBoxItemReport_DynamicReport
            '
            Me.ComboBoxItemReport_DynamicReport.ComboWidth = 200
            Me.ComboBoxItemReport_DynamicReport.DisplayMember = "Value"
            Me.ComboBoxItemReport_DynamicReport.DropDownHeight = 106
            Me.ComboBoxItemReport_DynamicReport.Enabled = False
            Me.ComboBoxItemReport_DynamicReport.Name = "ComboBoxItemReport_DynamicReport"
            Me.ComboBoxItemReport_DynamicReport.Stretch = True
            Me.ComboBoxItemReport_DynamicReport.WatermarkFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ComboBoxItemReport_DynamicReport.WatermarkText = "Select Report"
            '
            'ButtonItemReport_LoadTemplate
            '
            Me.ButtonItemReport_LoadTemplate.BeginGroup = True
            Me.ButtonItemReport_LoadTemplate.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemReport_LoadTemplate.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemReport_LoadTemplate.Name = "ButtonItemReport_LoadTemplate"
            Me.ButtonItemReport_LoadTemplate.RibbonWordWrap = False
            Me.ButtonItemReport_LoadTemplate.SecurityEnabled = True
            Me.ButtonItemReport_LoadTemplate.SubItemsExpandWidth = 14
            Me.ButtonItemReport_LoadTemplate.Text = "Load Template"
            Me.ButtonItemReport_LoadTemplate.Visible = False
            '
            'ButtonItemReport_Templates
            '
            Me.ButtonItemReport_Templates.BeginGroup = True
            Me.ButtonItemReport_Templates.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemReport_Templates.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemReport_Templates.Name = "ButtonItemReport_Templates"
            Me.ButtonItemReport_Templates.RibbonWordWrap = False
            Me.ButtonItemReport_Templates.SecurityEnabled = True
            Me.ButtonItemReport_Templates.SubItemsExpandWidth = 14
            Me.ButtonItemReport_Templates.Text = "Templates"
            Me.ButtonItemReport_Templates.Visible = False
            '
            'ButtonItemReport_Save
            '
            Me.ButtonItemReport_Save.BeginGroup = True
            Me.ButtonItemReport_Save.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemReport_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemReport_Save.Name = "ButtonItemReport_Save"
            Me.ButtonItemReport_Save.RibbonWordWrap = False
            Me.ButtonItemReport_Save.SecurityEnabled = True
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
            Me.ButtonItemReport_SaveAs.SecurityEnabled = True
            Me.ButtonItemReport_SaveAs.SubItemsExpandWidth = 14
            Me.ButtonItemReport_SaveAs.Text = "Save As..."
            '
            'ButtonItemReport_Schedule
            '
            Me.ButtonItemReport_Schedule.BeginGroup = True
            Me.ButtonItemReport_Schedule.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemReport_Schedule.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemReport_Schedule.Name = "ButtonItemReport_Schedule"
            Me.ButtonItemReport_Schedule.RibbonWordWrap = False
            Me.ButtonItemReport_Schedule.SecurityEnabled = True
            Me.ButtonItemReport_Schedule.SubItemsExpandWidth = 14
            Me.ButtonItemReport_Schedule.Text = "Schedule"
            '
            'LabelItemData_Refresh
            '
            Me.LabelItemData_Refresh.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelItemData_Refresh.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelItemData_Refresh.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.LabelItemData_Refresh.Location = New System.Drawing.Point(0, 0)
            Me.LabelItemData_Refresh.Name = "LabelItemData_Refresh"
            Me.LabelItemData_Refresh.Size = New System.Drawing.Size(0, 20)
            Me.LabelItemData_Refresh.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelItemData_Refresh.TabIndex = 0
            Me.LabelItemData_Refresh.Text = "Testing"
            '
            'RibbonBarMergeContainerForm_Printing
            '
            Me.RibbonBarMergeContainerForm_Printing.AutoActivateTab = False
            Me.RibbonBarMergeContainerForm_Printing.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Printing.Controls.Add(Me.RibbonBarPrinting_HeaderFooterImages)
            Me.RibbonBarMergeContainerForm_Printing.Controls.Add(Me.RibbonBarPrinting_Options)
            Me.RibbonBarMergeContainerForm_Printing.Controls.Add(Me.RibbonBarPrinting_Printing)
            Me.RibbonBarMergeContainerForm_Printing.Location = New System.Drawing.Point(12, 316)
            Me.RibbonBarMergeContainerForm_Printing.MergeRibbonGroupName = "Printing"
            Me.RibbonBarMergeContainerForm_Printing.MergeRibbonTabItemIndex = 3
            Me.RibbonBarMergeContainerForm_Printing.Name = "RibbonBarMergeContainerForm_Printing"
            Me.RibbonBarMergeContainerForm_Printing.RibbonTabText = "Printing"
            Me.RibbonBarMergeContainerForm_Printing.Size = New System.Drawing.Size(815, 98)
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Printing.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Printing.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Printing.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarMergeContainerForm_Printing.TabIndex = 2
            Me.RibbonBarMergeContainerForm_Printing.Visible = False
            '
            'RibbonBarPrinting_HeaderFooterImages
            '
            Me.RibbonBarPrinting_HeaderFooterImages.AutoOverflowEnabled = False
            Me.RibbonBarPrinting_HeaderFooterImages.AutoSizeItems = False
            '
            '
            '
            Me.RibbonBarPrinting_HeaderFooterImages.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarPrinting_HeaderFooterImages.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarPrinting_HeaderFooterImages.ContainerControlProcessDialogKey = True
            Me.RibbonBarPrinting_HeaderFooterImages.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarPrinting_HeaderFooterImages.DragDropSupport = True
            Me.RibbonBarPrinting_HeaderFooterImages.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarPrinting_HeaderFooterImages.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemHeaderFooterImages_Manage})
            Me.RibbonBarPrinting_HeaderFooterImages.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.RibbonBarPrinting_HeaderFooterImages.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarPrinting_HeaderFooterImages.Location = New System.Drawing.Point(482, 0)
            Me.RibbonBarPrinting_HeaderFooterImages.MinimumSize = New System.Drawing.Size(120, 0)
            Me.RibbonBarPrinting_HeaderFooterImages.Name = "RibbonBarPrinting_HeaderFooterImages"
            Me.RibbonBarPrinting_HeaderFooterImages.SecurityEnabled = True
            Me.RibbonBarPrinting_HeaderFooterImages.Size = New System.Drawing.Size(120, 98)
            Me.RibbonBarPrinting_HeaderFooterImages.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarPrinting_HeaderFooterImages.TabIndex = 4
            Me.RibbonBarPrinting_HeaderFooterImages.Text = "Header/Footer Images"
            '
            '
            '
            Me.RibbonBarPrinting_HeaderFooterImages.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarPrinting_HeaderFooterImages.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarPrinting_HeaderFooterImages.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemHeaderFooterImages_Manage
            '
            Me.ButtonItemHeaderFooterImages_Manage.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemHeaderFooterImages_Manage.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemHeaderFooterImages_Manage.Name = "ButtonItemHeaderFooterImages_Manage"
            Me.ButtonItemHeaderFooterImages_Manage.RibbonWordWrap = False
            Me.ButtonItemHeaderFooterImages_Manage.SecurityEnabled = True
            Me.ButtonItemHeaderFooterImages_Manage.SubItemsExpandWidth = 14
            Me.ButtonItemHeaderFooterImages_Manage.Text = "Manage"
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
            Me.RibbonBarPrinting_Options.Location = New System.Drawing.Point(100, 0)
            Me.RibbonBarPrinting_Options.Name = "RibbonBarPrinting_Options"
            Me.RibbonBarPrinting_Options.SecurityEnabled = True
            Me.RibbonBarPrinting_Options.Size = New System.Drawing.Size(382, 98)
            Me.RibbonBarPrinting_Options.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarPrinting_Options.TabIndex = 3
            Me.RibbonBarPrinting_Options.Text = "Options"
            '
            '
            '
            Me.RibbonBarPrinting_Options.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarPrinting_Options.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarPrinting_Options.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
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
            Me.ItemContainerOptions_OptionsLeft.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerOptions_OptionsLeft.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemOptionsLeft_AutoSizeColumnsToPage
            '
            Me.ButtonItemOptionsLeft_AutoSizeColumnsToPage.AutoCheckOnClick = True
            Me.ButtonItemOptionsLeft_AutoSizeColumnsToPage.Checked = True
            Me.ButtonItemOptionsLeft_AutoSizeColumnsToPage.Name = "ButtonItemOptionsLeft_AutoSizeColumnsToPage"
            Me.ButtonItemOptionsLeft_AutoSizeColumnsToPage.SecurityEnabled = True
            Me.ButtonItemOptionsLeft_AutoSizeColumnsToPage.Text = "Auto Size Columns To Page"
            '
            'ButtonItemOptionsLeft_PrintFilterInfo
            '
            Me.ButtonItemOptionsLeft_PrintFilterInfo.AutoCheckOnClick = True
            Me.ButtonItemOptionsLeft_PrintFilterInfo.Name = "ButtonItemOptionsLeft_PrintFilterInfo"
            Me.ButtonItemOptionsLeft_PrintFilterInfo.SecurityEnabled = True
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
            Me.ItemContainerOptions_OptionsMiddle.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
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
            Me.ButtonItemOptionsMiddle_PrintHeader.SecurityEnabled = True
            Me.ButtonItemOptionsMiddle_PrintHeader.Text = "Print Header"
            '
            'ButtonItemOptionsMiddle_PrintFooter
            '
            Me.ButtonItemOptionsMiddle_PrintFooter.AutoCheckOnClick = True
            Me.ButtonItemOptionsMiddle_PrintFooter.Checked = True
            Me.ButtonItemOptionsMiddle_PrintFooter.Name = "ButtonItemOptionsMiddle_PrintFooter"
            Me.ButtonItemOptionsMiddle_PrintFooter.SecurityEnabled = True
            Me.ButtonItemOptionsMiddle_PrintFooter.Text = "Print Footer"
            '
            'ButtonItemOptionsMiddle_PrintGroupFooter
            '
            Me.ButtonItemOptionsMiddle_PrintGroupFooter.AutoCheckOnClick = True
            Me.ButtonItemOptionsMiddle_PrintGroupFooter.Checked = True
            Me.ButtonItemOptionsMiddle_PrintGroupFooter.Name = "ButtonItemOptionsMiddle_PrintGroupFooter"
            Me.ButtonItemOptionsMiddle_PrintGroupFooter.SecurityEnabled = True
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
            Me.ItemContainerOptions_OptionsRight.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerOptions_OptionsRight.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemOptionsRight_PrintSelectedRowsOnly
            '
            Me.ButtonItemOptionsRight_PrintSelectedRowsOnly.AutoCheckOnClick = True
            Me.ButtonItemOptionsRight_PrintSelectedRowsOnly.Name = "ButtonItemOptionsRight_PrintSelectedRowsOnly"
            Me.ButtonItemOptionsRight_PrintSelectedRowsOnly.SecurityEnabled = True
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
            Me.RibbonBarPrinting_Printing.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarPrinting_Printing.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemPrinting_Print})
            Me.RibbonBarPrinting_Printing.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.RibbonBarPrinting_Printing.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarPrinting_Printing.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarPrinting_Printing.Name = "RibbonBarPrinting_Printing"
            Me.RibbonBarPrinting_Printing.SecurityEnabled = True
            Me.RibbonBarPrinting_Printing.Size = New System.Drawing.Size(100, 98)
            Me.RibbonBarPrinting_Printing.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarPrinting_Printing.TabIndex = 2
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
            'ButtonItemPrinting_Print
            '
            Me.ButtonItemPrinting_Print.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemPrinting_Print.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemPrinting_Print.Name = "ButtonItemPrinting_Print"
            Me.ButtonItemPrinting_Print.RibbonWordWrap = False
            Me.ButtonItemPrinting_Print.SecurityEnabled = True
            Me.ButtonItemPrinting_Print.SubItemsExpandWidth = 14
            Me.ButtonItemPrinting_Print.Text = "Print"
            '
            'TabControlForm_Report
            '
            Me.TabControlForm_Report.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlForm_Report.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.TabControlForm_Report.CanReorderTabs = False
            Me.TabControlForm_Report.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlForm_Report.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlForm_Report.Controls.Add(Me.TabControlPanelReportTab_Report)
            Me.TabControlForm_Report.Controls.Add(Me.TabControlPanelDashboardTab_Dashboard)
            Me.TabControlForm_Report.Controls.Add(Me.TabControlPanelQuickTextTab_QuickText)
            Me.TabControlForm_Report.ForeColor = System.Drawing.Color.Black
            Me.TabControlForm_Report.Location = New System.Drawing.Point(12, 12)
            Me.TabControlForm_Report.Name = "TabControlForm_Report"
            Me.TabControlForm_Report.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_Report.SelectedTabIndex = 0
            Me.TabControlForm_Report.Size = New System.Drawing.Size(1555, 431)
            Me.TabControlForm_Report.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_Report.TabIndex = 7
            Me.TabControlForm_Report.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_Report.Tabs.Add(Me.TabItemReport_ReportTab)
            Me.TabControlForm_Report.Tabs.Add(Me.TabItemReport_DashboardTab)
            Me.TabControlForm_Report.Tabs.Add(Me.TabItemReport_QuickTextTab)
            '
            'TabControlPanelReportTab_Report
            '
            Me.TabControlPanelReportTab_Report.Controls.Add(Me.DataGridViewReport_Report)
            Me.TabControlPanelReportTab_Report.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelReportTab_Report.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelReportTab_Report.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelReportTab_Report.Name = "TabControlPanelReportTab_Report"
            Me.TabControlPanelReportTab_Report.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelReportTab_Report.Size = New System.Drawing.Size(1555, 404)
            Me.TabControlPanelReportTab_Report.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelReportTab_Report.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelReportTab_Report.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelReportTab_Report.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelReportTab_Report.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelReportTab_Report.Style.GradientAngle = 90
            Me.TabControlPanelReportTab_Report.TabIndex = 2
            Me.TabControlPanelReportTab_Report.TabItem = Me.TabItemReport_ReportTab
            '
            'TabItemReport_ReportTab
            '
            Me.TabItemReport_ReportTab.AttachedControl = Me.TabControlPanelReportTab_Report
            Me.TabItemReport_ReportTab.Name = "TabItemReport_ReportTab"
            Me.TabItemReport_ReportTab.Text = "Report"
            '
            'TabControlPanelDashboardTab_Dashboard
            '
            Me.TabControlPanelDashboardTab_Dashboard.Controls.Add(Me.DashboardViewerDashboard_Dashboard)
            Me.TabControlPanelDashboardTab_Dashboard.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelDashboardTab_Dashboard.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelDashboardTab_Dashboard.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelDashboardTab_Dashboard.Name = "TabControlPanelDashboardTab_Dashboard"
            Me.TabControlPanelDashboardTab_Dashboard.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelDashboardTab_Dashboard.Size = New System.Drawing.Size(1555, 404)
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
            Me.DashboardViewerDashboard_Dashboard.Size = New System.Drawing.Size(1547, 396)
            Me.DashboardViewerDashboard_Dashboard.TabIndex = 0
            '
            'TabItemReport_DashboardTab
            '
            Me.TabItemReport_DashboardTab.AttachedControl = Me.TabControlPanelDashboardTab_Dashboard
            Me.TabItemReport_DashboardTab.Name = "TabItemReport_DashboardTab"
            Me.TabItemReport_DashboardTab.Text = "Dashboard"
            '
            'TabControlPanelQuickTextTab_QuickText
            '
            Me.TabControlPanelQuickTextTab_QuickText.Controls.Add(Me.SnapControlQuickText_Report)
            Me.TabControlPanelQuickTextTab_QuickText.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelQuickTextTab_QuickText.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelQuickTextTab_QuickText.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelQuickTextTab_QuickText.Name = "TabControlPanelQuickTextTab_QuickText"
            Me.TabControlPanelQuickTextTab_QuickText.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelQuickTextTab_QuickText.Size = New System.Drawing.Size(1555, 404)
            Me.TabControlPanelQuickTextTab_QuickText.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelQuickTextTab_QuickText.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelQuickTextTab_QuickText.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelQuickTextTab_QuickText.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelQuickTextTab_QuickText.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelQuickTextTab_QuickText.Style.GradientAngle = 90
            Me.TabControlPanelQuickTextTab_QuickText.TabIndex = 3
            Me.TabControlPanelQuickTextTab_QuickText.TabItem = Me.TabItemReport_QuickTextTab
            '
            'SnapControlQuickText_Report
            '
            Me.SnapControlQuickText_Report.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SnapControlQuickText_Report.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Twip
            Me.SnapControlQuickText_Report.Location = New System.Drawing.Point(4, 4)
            Me.SnapControlQuickText_Report.Name = "SnapControlQuickText_Report"
            Me.SnapControlQuickText_Report.Options.SnapMailMergeVisualOptions.DataSourceName = Nothing
            Me.SnapControlQuickText_Report.ReadOnly = True
            Me.SnapControlQuickText_Report.Size = New System.Drawing.Size(1547, 396)
            Me.SnapControlQuickText_Report.TabIndex = 0
            '
            'TabItemReport_QuickTextTab
            '
            Me.TabItemReport_QuickTextTab.AttachedControl = Me.TabControlPanelQuickTextTab_QuickText
            Me.TabItemReport_QuickTextTab.Name = "TabItemReport_QuickTextTab"
            Me.TabItemReport_QuickTextTab.Text = "Quick Text"
            '
            'LabelItemDataset_LastUpdated
            '
            Me.LabelItemDataset_LastUpdated.Name = "LabelItemDataset_LastUpdated"
            Me.LabelItemDataset_LastUpdated.Text = "LabelItem1"
            Me.LabelItemDataset_LastUpdated.Width = 250
            '
            'DynamicReportEditForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1579, 455)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Printing)
            Me.Controls.Add(Me.TabControlForm_Report)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "DynamicReportEditForm"
            Me.Text = "Report Writer"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.RibbonBarMergeContainerForm_Printing.ResumeLayout(False)
            CType(Me.TabControlForm_Report, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_Report.ResumeLayout(False)
            Me.TabControlPanelReportTab_Report.ResumeLayout(False)
            Me.TabControlPanelDashboardTab_Dashboard.ResumeLayout(False)
            CType(Me.DashboardViewerDashboard_Dashboard, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelQuickTextTab_QuickText.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewReport_Report As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Report As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents RibbonBarOptions_View As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents RibbonBarOptions_QuickCustomize As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemQuickCustomize_Columns As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ItemContainerReport_Report As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ComboBoxItemReport_DynamicReport As DevComponents.DotNetBar.ComboBoxItem
        Friend WithEvents ButtonItemReport_Save As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemReport_SaveAs As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarMergeContainerForm_Printing As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarPrinting_Printing As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemPrinting_Print As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarPrinting_Options As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ItemContainerOptions_OptionsLeft As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemOptionsLeft_AutoSizeColumnsToPage As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemOptionsLeft_PrintFilterInfo As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ItemContainerOptions_OptionsMiddle As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemOptionsMiddle_PrintHeader As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemOptionsMiddle_PrintFooter As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemOptionsMiddle_PrintGroupFooter As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ItemContainerOptions_OptionsRight As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemOptionsRight_PrintSelectedRowsOnly As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Filter As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemFilter_ShowFilterEditor As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemFilter_ShowAutoFilterRow As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ItemContainerView_ViewLeft As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemViewLeft_AllowCellMerging As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemViewLeft_ShowViewCaption As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemViewLeft_ShowGroupByBox As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Data As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents RibbonBarOptions_Refresh As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemData_Load As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDataset_Refresh As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents LabelItemData_Refresh As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TabControlForm_Report As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelReportTab_Report As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemReport_ReportTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelDashboardTab_Dashboard As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DashboardViewerDashboard_Dashboard As AdvantageFramework.WinForm.Presentation.Controls.DashboardViewerControl
        Friend WithEvents TabItemReport_DashboardTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents RibbonBarOptions_Dashboard As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemDashboard_Edit As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents TabControlPanelQuickTextTab_QuickText As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents SnapControlQuickText_Report As DevExpress.Snap.SnapControl
        Friend WithEvents TabItemReport_QuickTextTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents RibbonBarOptions_QuickText As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemQuickText_Edit As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_UnboundColumns As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemUnboundColumns_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarPrinting_HeaderFooterImages As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemHeaderFooterImages_Manage As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemReport_LoadTemplate As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemReport_Templates As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemReport_Schedule As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents LabelItemDataset_LastUpdated As DevComponents.DotNetBar.LabelItem
    End Class

End Namespace