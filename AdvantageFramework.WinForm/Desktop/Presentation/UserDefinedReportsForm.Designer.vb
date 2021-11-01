Namespace Desktop.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class UserDefinedReportsForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserDefinedReportsForm))
            Me.DataGridViewAdvancedReportWriter_Reports = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_View = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Add = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_EditReport = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_UpdateInfo = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Delete = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Copy = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Refresh = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_ReportCategory = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainerReportCategory_ReportCategory = New DevComponents.DotNetBar.ItemContainer()
            Me.ComboBoxItemReportCategory_ReportCategory = New DevComponents.DotNetBar.ComboBoxItem()
            Me.TabControlForm_ReportTypes = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelAdvancedReportWriterTab_AdvancedReportWriter = New DevComponents.DotNetBar.TabControlPanel()
            Me.TabItemReportTypes_AdvancedReportWriterTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelDynamicTab_Dynamic = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewDynamic_Reports = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemReportTypes_DynamicTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.ButtonItemActions_Export = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            CType(Me.TabControlForm_ReportTypes, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_ReportTypes.SuspendLayout()
            Me.TabControlPanelAdvancedReportWriterTab_AdvancedReportWriter.SuspendLayout()
            Me.TabControlPanelDynamicTab_Dynamic.SuspendLayout()
            Me.SuspendLayout()
            '
            'DataGridViewAdvancedReportWriter_Reports
            '
            Me.DataGridViewAdvancedReportWriter_Reports.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewAdvancedReportWriter_Reports.AllowDragAndDrop = False
            Me.DataGridViewAdvancedReportWriter_Reports.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewAdvancedReportWriter_Reports.AllowSelectGroupHeaderRow = True
            Me.DataGridViewAdvancedReportWriter_Reports.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewAdvancedReportWriter_Reports.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewAdvancedReportWriter_Reports.AutoFilterLookupColumns = False
            Me.DataGridViewAdvancedReportWriter_Reports.AutoloadRepositoryDatasource = True
            Me.DataGridViewAdvancedReportWriter_Reports.AutoUpdateViewCaption = True
            Me.DataGridViewAdvancedReportWriter_Reports.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewAdvancedReportWriter_Reports.DataSource = Nothing
            Me.DataGridViewAdvancedReportWriter_Reports.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewAdvancedReportWriter_Reports.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewAdvancedReportWriter_Reports.ItemDescription = "Report(s)"
            Me.DataGridViewAdvancedReportWriter_Reports.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewAdvancedReportWriter_Reports.MultiSelect = False
            Me.DataGridViewAdvancedReportWriter_Reports.Name = "DataGridViewAdvancedReportWriter_Reports"
            Me.DataGridViewAdvancedReportWriter_Reports.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewAdvancedReportWriter_Reports.RunStandardValidation = True
            Me.DataGridViewAdvancedReportWriter_Reports.ShowColumnMenuOnRightClick = False
            Me.DataGridViewAdvancedReportWriter_Reports.ShowSelectDeselectAllButtons = False
            Me.DataGridViewAdvancedReportWriter_Reports.Size = New System.Drawing.Size(668, 373)
            Me.DataGridViewAdvancedReportWriter_Reports.TabIndex = 1
            Me.DataGridViewAdvancedReportWriter_Reports.UseEmbeddedNavigator = False
            Me.DataGridViewAdvancedReportWriter_Reports.ViewCaptionHeight = -1
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_ReportCategory)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(12, 12)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(676, 98)
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_View, Me.ButtonItemActions_Add, Me.ButtonItemActions_EditReport, Me.ButtonItemActions_UpdateInfo, Me.ButtonItemActions_Delete, Me.ButtonItemActions_Copy, Me.ButtonItemActions_Refresh, Me.ButtonItemActions_Export})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(211, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(416, 98)
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
            'ButtonItemActions_View
            '
            Me.ButtonItemActions_View.BeginGroup = True
            Me.ButtonItemActions_View.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_View.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_View.Name = "ButtonItemActions_View"
            Me.ButtonItemActions_View.RibbonWordWrap = False
            Me.ButtonItemActions_View.SubItemsExpandWidth = 14
            Me.ButtonItemActions_View.Text = "View"
            '
            'ButtonItemActions_Add
            '
            Me.ButtonItemActions_Add.BeginGroup = True
            Me.ButtonItemActions_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Add.Name = "ButtonItemActions_Add"
            Me.ButtonItemActions_Add.RibbonWordWrap = False
            Me.ButtonItemActions_Add.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Add.Text = "Add"
            Me.ButtonItemActions_Add.Visible = False
            '
            'ButtonItemActions_EditReport
            '
            Me.ButtonItemActions_EditReport.BeginGroup = True
            Me.ButtonItemActions_EditReport.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_EditReport.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_EditReport.Name = "ButtonItemActions_EditReport"
            Me.ButtonItemActions_EditReport.RibbonWordWrap = False
            Me.ButtonItemActions_EditReport.SubItemsExpandWidth = 14
            Me.ButtonItemActions_EditReport.Text = "Edit Report"
            Me.ButtonItemActions_EditReport.Visible = False
            '
            'ButtonItemActions_UpdateInfo
            '
            Me.ButtonItemActions_UpdateInfo.BeginGroup = True
            Me.ButtonItemActions_UpdateInfo.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_UpdateInfo.Name = "ButtonItemActions_UpdateInfo"
            Me.ButtonItemActions_UpdateInfo.RibbonWordWrap = False
            Me.ButtonItemActions_UpdateInfo.SubItemsExpandWidth = 14
            Me.ButtonItemActions_UpdateInfo.Text = "Update Info"
            Me.ButtonItemActions_UpdateInfo.Visible = False
            '
            'ButtonItemActions_Delete
            '
            Me.ButtonItemActions_Delete.BeginGroup = True
            Me.ButtonItemActions_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Delete.Name = "ButtonItemActions_Delete"
            Me.ButtonItemActions_Delete.RibbonWordWrap = False
            Me.ButtonItemActions_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Delete.Text = "Delete"
            Me.ButtonItemActions_Delete.Visible = False
            '
            'ButtonItemActions_Copy
            '
            Me.ButtonItemActions_Copy.BeginGroup = True
            Me.ButtonItemActions_Copy.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Copy.Name = "ButtonItemActions_Copy"
            Me.ButtonItemActions_Copy.RibbonWordWrap = False
            Me.ButtonItemActions_Copy.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Copy.Text = "Copy"
            Me.ButtonItemActions_Copy.Visible = False
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
            'RibbonBarOptions_ReportCategory
            '
            Me.RibbonBarOptions_ReportCategory.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_ReportCategory.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ReportCategory.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ReportCategory.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_ReportCategory.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_ReportCategory.DragDropSupport = True
            Me.RibbonBarOptions_ReportCategory.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_ReportCategory.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerReportCategory_ReportCategory})
            Me.RibbonBarOptions_ReportCategory.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_ReportCategory.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_ReportCategory.Name = "RibbonBarOptions_ReportCategory"
            Me.RibbonBarOptions_ReportCategory.SecurityEnabled = True
            Me.RibbonBarOptions_ReportCategory.Size = New System.Drawing.Size(211, 98)
            Me.RibbonBarOptions_ReportCategory.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_ReportCategory.TabIndex = 2
            Me.RibbonBarOptions_ReportCategory.Text = "Report Category"
            '
            '
            '
            Me.RibbonBarOptions_ReportCategory.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ReportCategory.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ReportCategory.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ItemContainerReportCategory_ReportCategory
            '
            '
            '
            '
            Me.ItemContainerReportCategory_ReportCategory.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerReportCategory_ReportCategory.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerReportCategory_ReportCategory.Name = "ItemContainerReportCategory_ReportCategory"
            Me.ItemContainerReportCategory_ReportCategory.ResizeItemsToFit = False
            Me.ItemContainerReportCategory_ReportCategory.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ComboBoxItemReportCategory_ReportCategory})
            '
            '
            '
            Me.ItemContainerReportCategory_ReportCategory.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerReportCategory_ReportCategory.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerReportCategory_ReportCategory.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ComboBoxItemReportCategory_ReportCategory
            '
            Me.ComboBoxItemReportCategory_ReportCategory.ComboWidth = 200
            Me.ComboBoxItemReportCategory_ReportCategory.DisplayMember = "Value"
            Me.ComboBoxItemReportCategory_ReportCategory.DropDownHeight = 106
            Me.ComboBoxItemReportCategory_ReportCategory.Name = "ComboBoxItemReportCategory_ReportCategory"
            Me.ComboBoxItemReportCategory_ReportCategory.Stretch = True
            Me.ComboBoxItemReportCategory_ReportCategory.WatermarkFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ComboBoxItemReportCategory_ReportCategory.WatermarkText = "Select Report"
            '
            'TabControlForm_ReportTypes
            '
            Me.TabControlForm_ReportTypes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlForm_ReportTypes.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.TabControlForm_ReportTypes.CanReorderTabs = False
            Me.TabControlForm_ReportTypes.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlForm_ReportTypes.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlForm_ReportTypes.Controls.Add(Me.TabControlPanelAdvancedReportWriterTab_AdvancedReportWriter)
            Me.TabControlForm_ReportTypes.Controls.Add(Me.TabControlPanelDynamicTab_Dynamic)
            Me.TabControlForm_ReportTypes.ForeColor = System.Drawing.Color.Black
            Me.TabControlForm_ReportTypes.Location = New System.Drawing.Point(12, 12)
            Me.TabControlForm_ReportTypes.Name = "TabControlForm_ReportTypes"
            Me.TabControlForm_ReportTypes.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_ReportTypes.SelectedTabIndex = 0
            Me.TabControlForm_ReportTypes.Size = New System.Drawing.Size(676, 408)
            Me.TabControlForm_ReportTypes.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_ReportTypes.TabIndex = 5
            Me.TabControlForm_ReportTypes.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_ReportTypes.Tabs.Add(Me.TabItemReportTypes_AdvancedReportWriterTab)
            Me.TabControlForm_ReportTypes.Tabs.Add(Me.TabItemReportTypes_DynamicTab)
            Me.TabControlForm_ReportTypes.Text = "TabControl1"
            '
            'TabControlPanelAdvancedReportWriterTab_AdvancedReportWriter
            '
            Me.TabControlPanelAdvancedReportWriterTab_AdvancedReportWriter.Controls.Add(Me.DataGridViewAdvancedReportWriter_Reports)
            Me.TabControlPanelAdvancedReportWriterTab_AdvancedReportWriter.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelAdvancedReportWriterTab_AdvancedReportWriter.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelAdvancedReportWriterTab_AdvancedReportWriter.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelAdvancedReportWriterTab_AdvancedReportWriter.Name = "TabControlPanelAdvancedReportWriterTab_AdvancedReportWriter"
            Me.TabControlPanelAdvancedReportWriterTab_AdvancedReportWriter.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelAdvancedReportWriterTab_AdvancedReportWriter.Size = New System.Drawing.Size(676, 381)
            Me.TabControlPanelAdvancedReportWriterTab_AdvancedReportWriter.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelAdvancedReportWriterTab_AdvancedReportWriter.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelAdvancedReportWriterTab_AdvancedReportWriter.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelAdvancedReportWriterTab_AdvancedReportWriter.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelAdvancedReportWriterTab_AdvancedReportWriter.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelAdvancedReportWriterTab_AdvancedReportWriter.Style.GradientAngle = 90
            Me.TabControlPanelAdvancedReportWriterTab_AdvancedReportWriter.TabIndex = 0
            Me.TabControlPanelAdvancedReportWriterTab_AdvancedReportWriter.TabItem = Me.TabItemReportTypes_AdvancedReportWriterTab
            '
            'TabItemReportTypes_AdvancedReportWriterTab
            '
            Me.TabItemReportTypes_AdvancedReportWriterTab.AttachedControl = Me.TabControlPanelAdvancedReportWriterTab_AdvancedReportWriter
            Me.TabItemReportTypes_AdvancedReportWriterTab.Name = "TabItemReportTypes_AdvancedReportWriterTab"
            Me.TabItemReportTypes_AdvancedReportWriterTab.Text = "Advanced Report Writer"
            '
            'TabControlPanelDynamicTab_Dynamic
            '
            Me.TabControlPanelDynamicTab_Dynamic.Controls.Add(Me.DataGridViewDynamic_Reports)
            Me.TabControlPanelDynamicTab_Dynamic.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelDynamicTab_Dynamic.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelDynamicTab_Dynamic.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelDynamicTab_Dynamic.Name = "TabControlPanelDynamicTab_Dynamic"
            Me.TabControlPanelDynamicTab_Dynamic.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelDynamicTab_Dynamic.Size = New System.Drawing.Size(676, 381)
            Me.TabControlPanelDynamicTab_Dynamic.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelDynamicTab_Dynamic.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDynamicTab_Dynamic.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelDynamicTab_Dynamic.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelDynamicTab_Dynamic.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelDynamicTab_Dynamic.Style.GradientAngle = 90
            Me.TabControlPanelDynamicTab_Dynamic.TabIndex = 1
            Me.TabControlPanelDynamicTab_Dynamic.TabItem = Me.TabItemReportTypes_DynamicTab
            '
            'DataGridViewDynamic_Reports
            '
            Me.DataGridViewDynamic_Reports.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewDynamic_Reports.AllowDragAndDrop = False
            Me.DataGridViewDynamic_Reports.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewDynamic_Reports.AllowSelectGroupHeaderRow = True
            Me.DataGridViewDynamic_Reports.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewDynamic_Reports.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewDynamic_Reports.AutoFilterLookupColumns = False
            Me.DataGridViewDynamic_Reports.AutoloadRepositoryDatasource = True
            Me.DataGridViewDynamic_Reports.AutoUpdateViewCaption = True
            Me.DataGridViewDynamic_Reports.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewDynamic_Reports.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewDynamic_Reports.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewDynamic_Reports.ItemDescription = "Report(s)"
            Me.DataGridViewDynamic_Reports.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewDynamic_Reports.MultiSelect = False
            Me.DataGridViewDynamic_Reports.Name = "DataGridViewDynamic_Reports"
            Me.DataGridViewDynamic_Reports.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewDynamic_Reports.RunStandardValidation = True
            Me.DataGridViewDynamic_Reports.ShowColumnMenuOnRightClick = False
            Me.DataGridViewDynamic_Reports.ShowSelectDeselectAllButtons = False
            Me.DataGridViewDynamic_Reports.Size = New System.Drawing.Size(668, 373)
            Me.DataGridViewDynamic_Reports.TabIndex = 6
            Me.DataGridViewDynamic_Reports.UseEmbeddedNavigator = False
            Me.DataGridViewDynamic_Reports.ViewCaptionHeight = -1
            '
            'TabItemReportTypes_DynamicTab
            '
            Me.TabItemReportTypes_DynamicTab.AttachedControl = Me.TabControlPanelDynamicTab_Dynamic
            Me.TabItemReportTypes_DynamicTab.Name = "TabItemReportTypes_DynamicTab"
            Me.TabItemReportTypes_DynamicTab.Text = "Dynamic"
            '
            'ButtonItemActions_Export
            '
            Me.ButtonItemActions_Export.BeginGroup = True
            Me.ButtonItemActions_Export.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Export.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Export.Name = "ButtonItemActions_Export"
            Me.ButtonItemActions_Export.RibbonWordWrap = False
            Me.ButtonItemActions_Export.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Export.Text = "Export"
            '
            'UserDefinedReportsForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(700, 432)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.TabControlForm_ReportTypes)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "UserDefinedReportsForm"
            Me.Text = "User Defined Reports"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            CType(Me.TabControlForm_ReportTypes, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_ReportTypes.ResumeLayout(False)
            Me.TabControlPanelAdvancedReportWriterTab_AdvancedReportWriter.ResumeLayout(False)
            Me.TabControlPanelDynamicTab_Dynamic.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewAdvancedReportWriter_Reports As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_View As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents TabControlForm_ReportTypes As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelAdvancedReportWriterTab_AdvancedReportWriter As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemReportTypes_AdvancedReportWriterTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelDynamicTab_Dynamic As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemReportTypes_DynamicTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents DataGridViewDynamic_Reports As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonItemActions_Copy As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Delete As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Add As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_ReportCategory As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ItemContainerReportCategory_ReportCategory As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ComboBoxItemReportCategory_ReportCategory As DevComponents.DotNetBar.ComboBoxItem
        Friend WithEvents ButtonItemActions_UpdateInfo As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_EditReport As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Refresh As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Export As DevComponents.DotNetBar.ButtonItem
    End Class

End Namespace