Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class MediaPlanMasterPlanSetupForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaPlanMasterPlanSetupForm))
            Me.DataGridViewLeftSection_MasterPlans = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Dashboard = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemDashboard_Edit = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_PrintingOptions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemPrintingOptions_ShowHiatusDates = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemPrintingOptions_AddColumnsHeadersToAllEstimates = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemPrintingOptions_GroupByMediaTypes = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Add = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Delete = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Print = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Refresh = New DevComponents.DotNetBar.ButtonItem()
            Me.PanelForm_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ExpandableSplitterForm_LeftRightSections = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.MediaPlanMasterPlanRightSide_MasterPlan = New AdvantageFramework.WinForm.Presentation.Controls.MediaPlanMasterPlanControl()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_LeftSection.SuspendLayout()
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_RightSection.SuspendLayout()
            Me.SuspendLayout()
            '
            'DataGridViewLeftSection_MasterPlans
            '
            Me.DataGridViewLeftSection_MasterPlans.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewLeftSection_MasterPlans.AllowDragAndDrop = False
            Me.DataGridViewLeftSection_MasterPlans.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewLeftSection_MasterPlans.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_MasterPlans.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_MasterPlans.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_MasterPlans.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_MasterPlans.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_MasterPlans.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_MasterPlans.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_MasterPlans.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_MasterPlans.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_MasterPlans.ItemDescription = "Master Plan(s)"
            Me.DataGridViewLeftSection_MasterPlans.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewLeftSection_MasterPlans.MultiSelect = False
            Me.DataGridViewLeftSection_MasterPlans.Name = "DataGridViewLeftSection_MasterPlans"
            Me.DataGridViewLeftSection_MasterPlans.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_MasterPlans.RunStandardValidation = True
            Me.DataGridViewLeftSection_MasterPlans.ShowColumnMenuOnRightClick = False
            Me.DataGridViewLeftSection_MasterPlans.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_MasterPlans.Size = New System.Drawing.Size(307, 531)
            Me.DataGridViewLeftSection_MasterPlans.TabIndex = 1
            Me.DataGridViewLeftSection_MasterPlans.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_MasterPlans.ViewCaptionHeight = -1
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Dashboard)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_PrintingOptions)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(424, 300)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(559, 98)
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
            Me.RibbonBarOptions_Dashboard.Location = New System.Drawing.Point(485, 0)
            Me.RibbonBarOptions_Dashboard.MinimumSize = New System.Drawing.Size(65, 0)
            Me.RibbonBarOptions_Dashboard.Name = "RibbonBarOptions_Dashboard"
            Me.RibbonBarOptions_Dashboard.SecurityEnabled = True
            Me.RibbonBarOptions_Dashboard.Size = New System.Drawing.Size(65, 98)
            Me.RibbonBarOptions_Dashboard.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Dashboard.TabIndex = 8
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
            'RibbonBarOptions_PrintingOptions
            '
            Me.RibbonBarOptions_PrintingOptions.AutoOverflowEnabled = False
            Me.RibbonBarOptions_PrintingOptions.AutoSizeItems = False
            '
            '
            '
            Me.RibbonBarOptions_PrintingOptions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_PrintingOptions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_PrintingOptions.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_PrintingOptions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_PrintingOptions.DragDropSupport = True
            Me.RibbonBarOptions_PrintingOptions.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_PrintingOptions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemPrintingOptions_ShowHiatusDates, Me.ButtonItemPrintingOptions_AddColumnsHeadersToAllEstimates, Me.ButtonItemPrintingOptions_GroupByMediaTypes})
            Me.RibbonBarOptions_PrintingOptions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_PrintingOptions.Location = New System.Drawing.Point(194, 0)
            Me.RibbonBarOptions_PrintingOptions.MinimumSize = New System.Drawing.Size(120, 0)
            Me.RibbonBarOptions_PrintingOptions.Name = "RibbonBarOptions_PrintingOptions"
            Me.RibbonBarOptions_PrintingOptions.SecurityEnabled = True
            Me.RibbonBarOptions_PrintingOptions.Size = New System.Drawing.Size(291, 98)
            Me.RibbonBarOptions_PrintingOptions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_PrintingOptions.TabIndex = 7
            Me.RibbonBarOptions_PrintingOptions.Text = "Printing Options"
            '
            '
            '
            Me.RibbonBarOptions_PrintingOptions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_PrintingOptions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_PrintingOptions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemPrintingOptions_ShowHiatusDates
            '
            Me.ButtonItemPrintingOptions_ShowHiatusDates.AutoCheckOnClick = True
            Me.ButtonItemPrintingOptions_ShowHiatusDates.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemPrintingOptions_ShowHiatusDates.Checked = True
            Me.ButtonItemPrintingOptions_ShowHiatusDates.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemPrintingOptions_ShowHiatusDates.Name = "ButtonItemPrintingOptions_ShowHiatusDates"
            Me.ButtonItemPrintingOptions_ShowHiatusDates.RibbonWordWrap = False
            Me.ButtonItemPrintingOptions_ShowHiatusDates.SubItemsExpandWidth = 14
            Me.ButtonItemPrintingOptions_ShowHiatusDates.Text = "<span width=""15""></span>Show<br></br>Hiatus Dates"
            '
            'ButtonItemPrintingOptions_AddColumnsHeadersToAllEstimates
            '
            Me.ButtonItemPrintingOptions_AddColumnsHeadersToAllEstimates.AutoCheckOnClick = True
            Me.ButtonItemPrintingOptions_AddColumnsHeadersToAllEstimates.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemPrintingOptions_AddColumnsHeadersToAllEstimates.Checked = True
            Me.ButtonItemPrintingOptions_AddColumnsHeadersToAllEstimates.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemPrintingOptions_AddColumnsHeadersToAllEstimates.Name = "ButtonItemPrintingOptions_AddColumnsHeadersToAllEstimates"
            Me.ButtonItemPrintingOptions_AddColumnsHeadersToAllEstimates.RibbonWordWrap = False
            Me.ButtonItemPrintingOptions_AddColumnsHeadersToAllEstimates.SubItemsExpandWidth = 14
            Me.ButtonItemPrintingOptions_AddColumnsHeadersToAllEstimates.Text = "Add Column Headers<br></br><span width=""10""></span>To All Estimates"
            '
            'ButtonItemPrintingOptions_GroupByMediaTypes
            '
            Me.ButtonItemPrintingOptions_GroupByMediaTypes.AutoCheckOnClick = True
            Me.ButtonItemPrintingOptions_GroupByMediaTypes.BeginGroup = True
            Me.ButtonItemPrintingOptions_GroupByMediaTypes.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemPrintingOptions_GroupByMediaTypes.ImageFixedSize = New System.Drawing.Size(32, 32)
            Me.ButtonItemPrintingOptions_GroupByMediaTypes.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemPrintingOptions_GroupByMediaTypes.Name = "ButtonItemPrintingOptions_GroupByMediaTypes"
            Me.ButtonItemPrintingOptions_GroupByMediaTypes.RibbonWordWrap = False
            Me.ButtonItemPrintingOptions_GroupByMediaTypes.SubItemsExpandWidth = 14
            Me.ButtonItemPrintingOptions_GroupByMediaTypes.Text = "<span width=""5""></span>Group By<br></br>Media Types"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Add, Me.ButtonItemActions_Save, Me.ButtonItemActions_Delete, Me.ButtonItemActions_Print, Me.ButtonItemActions_Refresh})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(194, 98)
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
            'ButtonItemActions_Delete
            '
            Me.ButtonItemActions_Delete.BeginGroup = True
            Me.ButtonItemActions_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Delete.Name = "ButtonItemActions_Delete"
            Me.ButtonItemActions_Delete.RibbonWordWrap = False
            Me.ButtonItemActions_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Delete.Text = "Delete"
            '
            'ButtonItemActions_Print
            '
            Me.ButtonItemActions_Print.BeginGroup = True
            Me.ButtonItemActions_Print.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Print.Name = "ButtonItemActions_Print"
            Me.ButtonItemActions_Print.RibbonWordWrap = False
            Me.ButtonItemActions_Print.SecurityEnabled = True
            Me.ButtonItemActions_Print.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Print.Text = "Print"
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
            'PanelForm_LeftSection
            '
            Me.PanelForm_LeftSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelForm_LeftSection.Appearance.Options.UseBackColor = True
            Me.PanelForm_LeftSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_MasterPlans)
            Me.PanelForm_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelForm_LeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_LeftSection.Name = "PanelForm_LeftSection"
            Me.PanelForm_LeftSection.Size = New System.Drawing.Size(325, 555)
            Me.PanelForm_LeftSection.TabIndex = 0
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
            Me.ExpandableSplitterForm_LeftRightSections.Size = New System.Drawing.Size(6, 555)
            Me.ExpandableSplitterForm_LeftRightSections.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterForm_LeftRightSections.TabIndex = 1
            Me.ExpandableSplitterForm_LeftRightSections.TabStop = False
            '
            'PanelForm_RightSection
            '
            Me.PanelForm_RightSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelForm_RightSection.Appearance.Options.UseBackColor = True
            Me.PanelForm_RightSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelForm_RightSection.Controls.Add(Me.MediaPlanMasterPlanRightSide_MasterPlan)
            Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_RightSection.Location = New System.Drawing.Point(331, 0)
            Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
            Me.PanelForm_RightSection.Size = New System.Drawing.Size(787, 555)
            Me.PanelForm_RightSection.TabIndex = 2
            '
            'MediaPlanMasterPlanRightSide_MasterPlan
            '
            Me.MediaPlanMasterPlanRightSide_MasterPlan.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.MediaPlanMasterPlanRightSide_MasterPlan.Location = New System.Drawing.Point(6, 12)
            Me.MediaPlanMasterPlanRightSide_MasterPlan.Name = "MediaPlanMasterPlanRightSide_MasterPlan"
            Me.MediaPlanMasterPlanRightSide_MasterPlan.Size = New System.Drawing.Size(769, 531)
            Me.MediaPlanMasterPlanRightSide_MasterPlan.TabIndex = 0
            '
            'MediaPlanMasterPlanSetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1118, 555)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.PanelForm_RightSection)
            Me.Controls.Add(Me.ExpandableSplitterForm_LeftRightSections)
            Me.Controls.Add(Me.PanelForm_LeftSection)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaPlanMasterPlanSetupForm"
            Me.Text = "Media Planning - Master Plans"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_LeftSection.ResumeLayout(False)
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_RightSection.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewLeftSection_MasterPlans As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Add As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Delete As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents PanelForm_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ExpandableSplitterForm_LeftRightSections As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelForm_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ButtonItemActions_Print As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Save As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents RibbonBarOptions_PrintingOptions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemPrintingOptions_ShowHiatusDates As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemPrintingOptions_AddColumnsHeadersToAllEstimates As DevComponents.DotNetBar.ButtonItem
        Private WithEvents ButtonItemPrintingOptions_GroupByMediaTypes As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_Dashboard As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemDashboard_Edit As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Refresh As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents MediaPlanMasterPlanRightSide_MasterPlan As WinForm.Presentation.Controls.MediaPlanMasterPlanControl
    End Class

End Namespace