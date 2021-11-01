Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaPlanMasterPlanControl
        Inherits AdvantageFramework.WinForm.Presentation.Controls.BaseControls.BaseUserControl

        'UserControl overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
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
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.TabControlControl_MasterPlanDetails = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelPlansTab_Plans = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelPlans_PlansRight = New System.Windows.Forms.Panel()
            Me.ButtonPlansRight_AddPlan = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonPlansRight_AddAllPlans = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonPlansRight_RemoveAllPlans = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonPlansRight_RemovePlan = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewPlansRight_SelectedMediaPlans = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterMiddleSection_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelPlans_PlansLeft = New System.Windows.Forms.Panel()
            Me.DataGridViewPlansLeft_MediaPlans = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemMasterPlanDetails_PlansTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelEstimatesTab_Estimates = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewEstimates_Estimates = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemMasterPlanDetails_EstimatesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelDashboardTab_Dashboard = New DevComponents.DotNetBar.TabControlPanel()
            Me.DashboardViewerDashboard_Dashboard = New AdvantageFramework.WinForm.Presentation.Controls.DashboardViewerControl()
            Me.TabItemMasterPlanDetails_DashboardTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.PanelControl_TopSection = New System.Windows.Forms.Panel()
            Me.LabelTopSection_Description = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxTopSection_Description = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxTopSection_Comment = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelTopSection_Comment = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            CType(Me.TabControlControl_MasterPlanDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlControl_MasterPlanDetails.SuspendLayout()
            Me.TabControlPanelPlansTab_Plans.SuspendLayout()
            Me.PanelPlans_PlansRight.SuspendLayout()
            Me.PanelPlans_PlansLeft.SuspendLayout()
            Me.TabControlPanelEstimatesTab_Estimates.SuspendLayout()
            Me.TabControlPanelDashboardTab_Dashboard.SuspendLayout()
            CType(Me.DashboardViewerDashboard_Dashboard, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelControl_TopSection.SuspendLayout()
            Me.SuspendLayout()
            '
            'TabControlControl_MasterPlanDetails
            '
            Me.TabControlControl_MasterPlanDetails.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.TabControlControl_MasterPlanDetails.CanReorderTabs = False
            Me.TabControlControl_MasterPlanDetails.Controls.Add(Me.TabControlPanelPlansTab_Plans)
            Me.TabControlControl_MasterPlanDetails.Controls.Add(Me.TabControlPanelEstimatesTab_Estimates)
            Me.TabControlControl_MasterPlanDetails.Controls.Add(Me.TabControlPanelDashboardTab_Dashboard)
            Me.TabControlControl_MasterPlanDetails.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlControl_MasterPlanDetails.Location = New System.Drawing.Point(0, 124)
            Me.TabControlControl_MasterPlanDetails.Name = "TabControlControl_MasterPlanDetails"
            Me.TabControlControl_MasterPlanDetails.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlControl_MasterPlanDetails.SelectedTabIndex = 0
            Me.TabControlControl_MasterPlanDetails.Size = New System.Drawing.Size(820, 377)
            Me.TabControlControl_MasterPlanDetails.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlControl_MasterPlanDetails.TabIndex = 14
            Me.TabControlControl_MasterPlanDetails.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlControl_MasterPlanDetails.Tabs.Add(Me.TabItemMasterPlanDetails_PlansTab)
            Me.TabControlControl_MasterPlanDetails.Tabs.Add(Me.TabItemMasterPlanDetails_EstimatesTab)
            Me.TabControlControl_MasterPlanDetails.Tabs.Add(Me.TabItemMasterPlanDetails_DashboardTab)
            '
            'TabControlPanelPlansTab_Plans
            '
            Me.TabControlPanelPlansTab_Plans.Controls.Add(Me.PanelPlans_PlansRight)
            Me.TabControlPanelPlansTab_Plans.Controls.Add(Me.ExpandableSplitterMiddleSection_LeftRight)
            Me.TabControlPanelPlansTab_Plans.Controls.Add(Me.PanelPlans_PlansLeft)
            Me.TabControlPanelPlansTab_Plans.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelPlansTab_Plans.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelPlansTab_Plans.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelPlansTab_Plans.Name = "TabControlPanelPlansTab_Plans"
            Me.TabControlPanelPlansTab_Plans.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelPlansTab_Plans.Size = New System.Drawing.Size(820, 350)
            Me.TabControlPanelPlansTab_Plans.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelPlansTab_Plans.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelPlansTab_Plans.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelPlansTab_Plans.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelPlansTab_Plans.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelPlansTab_Plans.Style.GradientAngle = 90
            Me.TabControlPanelPlansTab_Plans.TabIndex = 2
            Me.TabControlPanelPlansTab_Plans.TabItem = Me.TabItemMasterPlanDetails_PlansTab
            '
            'PanelPlans_PlansRight
            '
            Me.PanelPlans_PlansRight.BackColor = System.Drawing.Color.White
            Me.PanelPlans_PlansRight.Controls.Add(Me.ButtonPlansRight_AddPlan)
            Me.PanelPlans_PlansRight.Controls.Add(Me.ButtonPlansRight_AddAllPlans)
            Me.PanelPlans_PlansRight.Controls.Add(Me.ButtonPlansRight_RemoveAllPlans)
            Me.PanelPlans_PlansRight.Controls.Add(Me.ButtonPlansRight_RemovePlan)
            Me.PanelPlans_PlansRight.Controls.Add(Me.DataGridViewPlansRight_SelectedMediaPlans)
            Me.PanelPlans_PlansRight.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelPlans_PlansRight.Location = New System.Drawing.Point(403, 1)
            Me.PanelPlans_PlansRight.Name = "PanelPlans_PlansRight"
            Me.PanelPlans_PlansRight.Size = New System.Drawing.Size(416, 348)
            Me.PanelPlans_PlansRight.TabIndex = 16
            '
            'ButtonPlansRight_AddPlan
            '
            Me.ButtonPlansRight_AddPlan.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonPlansRight_AddPlan.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonPlansRight_AddPlan.Location = New System.Drawing.Point(8, 4)
            Me.ButtonPlansRight_AddPlan.Name = "ButtonPlansRight_AddPlan"
            Me.ButtonPlansRight_AddPlan.SecurityEnabled = True
            Me.ButtonPlansRight_AddPlan.Size = New System.Drawing.Size(75, 20)
            Me.ButtonPlansRight_AddPlan.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonPlansRight_AddPlan.TabIndex = 0
            Me.ButtonPlansRight_AddPlan.Text = "-->"
            '
            'ButtonPlansRight_AddAllPlans
            '
            Me.ButtonPlansRight_AddAllPlans.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonPlansRight_AddAllPlans.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonPlansRight_AddAllPlans.Location = New System.Drawing.Point(8, 32)
            Me.ButtonPlansRight_AddAllPlans.Name = "ButtonPlansRight_AddAllPlans"
            Me.ButtonPlansRight_AddAllPlans.SecurityEnabled = True
            Me.ButtonPlansRight_AddAllPlans.Size = New System.Drawing.Size(75, 20)
            Me.ButtonPlansRight_AddAllPlans.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonPlansRight_AddAllPlans.TabIndex = 1
            Me.ButtonPlansRight_AddAllPlans.Text = "-->>"
            '
            'ButtonPlansRight_RemoveAllPlans
            '
            Me.ButtonPlansRight_RemoveAllPlans.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonPlansRight_RemoveAllPlans.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonPlansRight_RemoveAllPlans.Location = New System.Drawing.Point(8, 86)
            Me.ButtonPlansRight_RemoveAllPlans.Name = "ButtonPlansRight_RemoveAllPlans"
            Me.ButtonPlansRight_RemoveAllPlans.SecurityEnabled = True
            Me.ButtonPlansRight_RemoveAllPlans.Size = New System.Drawing.Size(75, 20)
            Me.ButtonPlansRight_RemoveAllPlans.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonPlansRight_RemoveAllPlans.TabIndex = 3
            Me.ButtonPlansRight_RemoveAllPlans.Text = "<<--"
            '
            'ButtonPlansRight_RemovePlan
            '
            Me.ButtonPlansRight_RemovePlan.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonPlansRight_RemovePlan.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonPlansRight_RemovePlan.Location = New System.Drawing.Point(8, 60)
            Me.ButtonPlansRight_RemovePlan.Name = "ButtonPlansRight_RemovePlan"
            Me.ButtonPlansRight_RemovePlan.SecurityEnabled = True
            Me.ButtonPlansRight_RemovePlan.Size = New System.Drawing.Size(75, 20)
            Me.ButtonPlansRight_RemovePlan.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonPlansRight_RemovePlan.TabIndex = 2
            Me.ButtonPlansRight_RemovePlan.Text = "<--"
            '
            'DataGridViewPlansRight_SelectedMediaPlans
            '
            Me.DataGridViewPlansRight_SelectedMediaPlans.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewPlansRight_SelectedMediaPlans.AllowDragAndDrop = False
            Me.DataGridViewPlansRight_SelectedMediaPlans.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewPlansRight_SelectedMediaPlans.AllowSelectGroupHeaderRow = True
            Me.DataGridViewPlansRight_SelectedMediaPlans.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewPlansRight_SelectedMediaPlans.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewPlansRight_SelectedMediaPlans.AutoFilterLookupColumns = False
            Me.DataGridViewPlansRight_SelectedMediaPlans.AutoloadRepositoryDatasource = True
            Me.DataGridViewPlansRight_SelectedMediaPlans.AutoUpdateViewCaption = True
            Me.DataGridViewPlansRight_SelectedMediaPlans.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewPlansRight_SelectedMediaPlans.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewPlansRight_SelectedMediaPlans.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewPlansRight_SelectedMediaPlans.ItemDescription = "Selected Plan(s)"
            Me.DataGridViewPlansRight_SelectedMediaPlans.Location = New System.Drawing.Point(87, 4)
            Me.DataGridViewPlansRight_SelectedMediaPlans.MultiSelect = True
            Me.DataGridViewPlansRight_SelectedMediaPlans.Name = "DataGridViewPlansRight_SelectedMediaPlans"
            Me.DataGridViewPlansRight_SelectedMediaPlans.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewPlansRight_SelectedMediaPlans.RunStandardValidation = True
            Me.DataGridViewPlansRight_SelectedMediaPlans.ShowColumnMenuOnRightClick = False
            Me.DataGridViewPlansRight_SelectedMediaPlans.ShowSelectDeselectAllButtons = False
            Me.DataGridViewPlansRight_SelectedMediaPlans.Size = New System.Drawing.Size(325, 341)
            Me.DataGridViewPlansRight_SelectedMediaPlans.TabIndex = 4
            Me.DataGridViewPlansRight_SelectedMediaPlans.UseEmbeddedNavigator = False
            Me.DataGridViewPlansRight_SelectedMediaPlans.ViewCaptionHeight = -1
            '
            'ExpandableSplitterMiddleSection_LeftRight
            '
            Me.ExpandableSplitterMiddleSection_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterMiddleSection_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterMiddleSection_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterMiddleSection_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterMiddleSection_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterMiddleSection_LeftRight.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterMiddleSection_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterMiddleSection_LeftRight.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterMiddleSection_LeftRight.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterMiddleSection_LeftRight.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterMiddleSection_LeftRight.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterMiddleSection_LeftRight.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterMiddleSection_LeftRight.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterMiddleSection_LeftRight.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterMiddleSection_LeftRight.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterMiddleSection_LeftRight.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterMiddleSection_LeftRight.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterMiddleSection_LeftRight.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterMiddleSection_LeftRight.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterMiddleSection_LeftRight.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterMiddleSection_LeftRight.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterMiddleSection_LeftRight.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterMiddleSection_LeftRight.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterMiddleSection_LeftRight.Location = New System.Drawing.Point(397, 1)
            Me.ExpandableSplitterMiddleSection_LeftRight.Name = "ExpandableSplitterMiddleSection_LeftRight"
            Me.ExpandableSplitterMiddleSection_LeftRight.Size = New System.Drawing.Size(6, 348)
            Me.ExpandableSplitterMiddleSection_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterMiddleSection_LeftRight.TabIndex = 15
            Me.ExpandableSplitterMiddleSection_LeftRight.TabStop = False
            '
            'PanelPlans_PlansLeft
            '
            Me.PanelPlans_PlansLeft.BackColor = System.Drawing.Color.White
            Me.PanelPlans_PlansLeft.Controls.Add(Me.DataGridViewPlansLeft_MediaPlans)
            Me.PanelPlans_PlansLeft.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelPlans_PlansLeft.Location = New System.Drawing.Point(1, 1)
            Me.PanelPlans_PlansLeft.Name = "PanelPlans_PlansLeft"
            Me.PanelPlans_PlansLeft.Size = New System.Drawing.Size(396, 348)
            Me.PanelPlans_PlansLeft.TabIndex = 14
            '
            'DataGridViewPlansLeft_MediaPlans
            '
            Me.DataGridViewPlansLeft_MediaPlans.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewPlansLeft_MediaPlans.AllowDragAndDrop = False
            Me.DataGridViewPlansLeft_MediaPlans.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewPlansLeft_MediaPlans.AllowSelectGroupHeaderRow = True
            Me.DataGridViewPlansLeft_MediaPlans.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewPlansLeft_MediaPlans.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewPlansLeft_MediaPlans.AutoFilterLookupColumns = False
            Me.DataGridViewPlansLeft_MediaPlans.AutoloadRepositoryDatasource = True
            Me.DataGridViewPlansLeft_MediaPlans.AutoUpdateViewCaption = True
            Me.DataGridViewPlansLeft_MediaPlans.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewPlansLeft_MediaPlans.DataSource = Nothing
            Me.DataGridViewPlansLeft_MediaPlans.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewPlansLeft_MediaPlans.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewPlansLeft_MediaPlans.ItemDescription = "Available Plan(s)"
            Me.DataGridViewPlansLeft_MediaPlans.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewPlansLeft_MediaPlans.MultiSelect = True
            Me.DataGridViewPlansLeft_MediaPlans.Name = "DataGridViewPlansLeft_MediaPlans"
            Me.DataGridViewPlansLeft_MediaPlans.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewPlansLeft_MediaPlans.RunStandardValidation = True
            Me.DataGridViewPlansLeft_MediaPlans.ShowColumnMenuOnRightClick = False
            Me.DataGridViewPlansLeft_MediaPlans.ShowSelectDeselectAllButtons = False
            Me.DataGridViewPlansLeft_MediaPlans.Size = New System.Drawing.Size(386, 341)
            Me.DataGridViewPlansLeft_MediaPlans.TabIndex = 0
            Me.DataGridViewPlansLeft_MediaPlans.UseEmbeddedNavigator = False
            Me.DataGridViewPlansLeft_MediaPlans.ViewCaptionHeight = -1
            '
            'TabItemMasterPlanDetails_PlansTab
            '
            Me.TabItemMasterPlanDetails_PlansTab.AttachedControl = Me.TabControlPanelPlansTab_Plans
            Me.TabItemMasterPlanDetails_PlansTab.Name = "TabItemMasterPlanDetails_PlansTab"
            Me.TabItemMasterPlanDetails_PlansTab.Text = "Plans"
            '
            'TabControlPanelEstimatesTab_Estimates
            '
            Me.TabControlPanelEstimatesTab_Estimates.Controls.Add(Me.DataGridViewEstimates_Estimates)
            Me.TabControlPanelEstimatesTab_Estimates.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelEstimatesTab_Estimates.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelEstimatesTab_Estimates.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelEstimatesTab_Estimates.Name = "TabControlPanelEstimatesTab_Estimates"
            Me.TabControlPanelEstimatesTab_Estimates.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelEstimatesTab_Estimates.Size = New System.Drawing.Size(820, 350)
            Me.TabControlPanelEstimatesTab_Estimates.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelEstimatesTab_Estimates.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelEstimatesTab_Estimates.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelEstimatesTab_Estimates.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelEstimatesTab_Estimates.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelEstimatesTab_Estimates.Style.GradientAngle = 90
            Me.TabControlPanelEstimatesTab_Estimates.TabIndex = 0
            Me.TabControlPanelEstimatesTab_Estimates.TabItem = Me.TabItemMasterPlanDetails_EstimatesTab
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
            Me.DataGridViewEstimates_Estimates.ItemDescription = "Estimate(s)"
            Me.DataGridViewEstimates_Estimates.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewEstimates_Estimates.MultiSelect = False
            Me.DataGridViewEstimates_Estimates.Name = "DataGridViewEstimates_Estimates"
            Me.DataGridViewEstimates_Estimates.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewEstimates_Estimates.RunStandardValidation = True
            Me.DataGridViewEstimates_Estimates.ShowColumnMenuOnRightClick = False
            Me.DataGridViewEstimates_Estimates.ShowSelectDeselectAllButtons = False
            Me.DataGridViewEstimates_Estimates.Size = New System.Drawing.Size(812, 342)
            Me.DataGridViewEstimates_Estimates.TabIndex = 4
            Me.DataGridViewEstimates_Estimates.UseEmbeddedNavigator = False
            Me.DataGridViewEstimates_Estimates.ViewCaptionHeight = -1
            '
            'TabItemMasterPlanDetails_EstimatesTab
            '
            Me.TabItemMasterPlanDetails_EstimatesTab.AttachedControl = Me.TabControlPanelEstimatesTab_Estimates
            Me.TabItemMasterPlanDetails_EstimatesTab.Name = "TabItemMasterPlanDetails_EstimatesTab"
            Me.TabItemMasterPlanDetails_EstimatesTab.Text = "Estimates"
            '
            'TabControlPanelDashboardTab_Dashboard
            '
            Me.TabControlPanelDashboardTab_Dashboard.Controls.Add(Me.DashboardViewerDashboard_Dashboard)
            Me.TabControlPanelDashboardTab_Dashboard.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelDashboardTab_Dashboard.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelDashboardTab_Dashboard.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelDashboardTab_Dashboard.Name = "TabControlPanelDashboardTab_Dashboard"
            Me.TabControlPanelDashboardTab_Dashboard.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelDashboardTab_Dashboard.Size = New System.Drawing.Size(820, 350)
            Me.TabControlPanelDashboardTab_Dashboard.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDashboardTab_Dashboard.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDashboardTab_Dashboard.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelDashboardTab_Dashboard.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelDashboardTab_Dashboard.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelDashboardTab_Dashboard.Style.GradientAngle = 90
            Me.TabControlPanelDashboardTab_Dashboard.TabIndex = 1
            Me.TabControlPanelDashboardTab_Dashboard.TabItem = Me.TabItemMasterPlanDetails_DashboardTab
            '
            'DashboardViewerDashboard_Dashboard
            '
            Me.DashboardViewerDashboard_Dashboard.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DashboardViewerDashboard_Dashboard.Location = New System.Drawing.Point(4, 4)
            Me.DashboardViewerDashboard_Dashboard.Name = "DashboardViewerDashboard_Dashboard"
            Me.DashboardViewerDashboard_Dashboard.PrintPreviewOptions.DashboardStatePosition = DevExpress.DashboardCommon.DashboardStateExportPosition.SeparatePage
            Me.DashboardViewerDashboard_Dashboard.PdfExportOptions.DashboardStatePosition = DevExpress.DashboardCommon.DashboardStateExportPosition.SeparatePage
            Me.DashboardViewerDashboard_Dashboard.Size = New System.Drawing.Size(812, 342)
            Me.DashboardViewerDashboard_Dashboard.TabIndex = 0
            '
            'TabItemMasterPlanDetails_DashboardTab
            '
            Me.TabItemMasterPlanDetails_DashboardTab.AttachedControl = Me.TabControlPanelDashboardTab_Dashboard
            Me.TabItemMasterPlanDetails_DashboardTab.Name = "TabItemMasterPlanDetails_DashboardTab"
            Me.TabItemMasterPlanDetails_DashboardTab.Text = "Dashboard"
            '
            'PanelControl_TopSection
            '
            Me.PanelControl_TopSection.Controls.Add(Me.LabelTopSection_Description)
            Me.PanelControl_TopSection.Controls.Add(Me.TextBoxTopSection_Description)
            Me.PanelControl_TopSection.Controls.Add(Me.TextBoxTopSection_Comment)
            Me.PanelControl_TopSection.Controls.Add(Me.LabelTopSection_Comment)
            Me.PanelControl_TopSection.Dock = System.Windows.Forms.DockStyle.Top
            Me.PanelControl_TopSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelControl_TopSection.Name = "PanelControl_TopSection"
            Me.PanelControl_TopSection.Size = New System.Drawing.Size(820, 124)
            Me.PanelControl_TopSection.TabIndex = 0
            '
            'LabelTopSection_Description
            '
            Me.LabelTopSection_Description.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTopSection_Description.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTopSection_Description.Location = New System.Drawing.Point(0, 0)
            Me.LabelTopSection_Description.Name = "LabelTopSection_Description"
            Me.LabelTopSection_Description.Size = New System.Drawing.Size(80, 20)
            Me.LabelTopSection_Description.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTopSection_Description.TabIndex = 0
            Me.LabelTopSection_Description.Text = "Description:"
            '
            'TextBoxTopSection_Description
            '
            Me.TextBoxTopSection_Description.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxTopSection_Description.Border.Class = "TextBoxBorder"
            Me.TextBoxTopSection_Description.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxTopSection_Description.CheckSpellingOnValidate = False
            Me.TextBoxTopSection_Description.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxTopSection_Description.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxTopSection_Description.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxTopSection_Description.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxTopSection_Description.FocusHighlightEnabled = True
            Me.TextBoxTopSection_Description.Location = New System.Drawing.Point(86, 0)
            Me.TextBoxTopSection_Description.MaxFileSize = CType(0, Long)
            Me.TextBoxTopSection_Description.Name = "TextBoxTopSection_Description"
            Me.TextBoxTopSection_Description.SecurityEnabled = True
            Me.TextBoxTopSection_Description.ShowSpellCheckCompleteMessage = True
            Me.TextBoxTopSection_Description.Size = New System.Drawing.Size(734, 20)
            Me.TextBoxTopSection_Description.StartingFolderName = Nothing
            Me.TextBoxTopSection_Description.TabIndex = 1
            Me.TextBoxTopSection_Description.TabOnEnter = True
            '
            'TextBoxTopSection_Comment
            '
            Me.TextBoxTopSection_Comment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxTopSection_Comment.Border.Class = "TextBoxBorder"
            Me.TextBoxTopSection_Comment.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxTopSection_Comment.CheckSpellingOnValidate = False
            Me.TextBoxTopSection_Comment.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxTopSection_Comment.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxTopSection_Comment.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxTopSection_Comment.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxTopSection_Comment.FocusHighlightEnabled = True
            Me.TextBoxTopSection_Comment.Location = New System.Drawing.Point(86, 26)
            Me.TextBoxTopSection_Comment.MaxFileSize = CType(0, Long)
            Me.TextBoxTopSection_Comment.Multiline = True
            Me.TextBoxTopSection_Comment.Name = "TextBoxTopSection_Comment"
            Me.TextBoxTopSection_Comment.SecurityEnabled = True
            Me.TextBoxTopSection_Comment.ShowSpellCheckCompleteMessage = True
            Me.TextBoxTopSection_Comment.Size = New System.Drawing.Size(734, 92)
            Me.TextBoxTopSection_Comment.StartingFolderName = Nothing
            Me.TextBoxTopSection_Comment.TabIndex = 3
            Me.TextBoxTopSection_Comment.TabOnEnter = False
            '
            'LabelTopSection_Comment
            '
            Me.LabelTopSection_Comment.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTopSection_Comment.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTopSection_Comment.Location = New System.Drawing.Point(0, 26)
            Me.LabelTopSection_Comment.Name = "LabelTopSection_Comment"
            Me.LabelTopSection_Comment.Size = New System.Drawing.Size(80, 20)
            Me.LabelTopSection_Comment.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTopSection_Comment.TabIndex = 2
            Me.LabelTopSection_Comment.Text = "Comment:"
            '
            'MediaPlanMasterPlanControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.TabControlControl_MasterPlanDetails)
            Me.Controls.Add(Me.PanelControl_TopSection)
            Me.Name = "MediaPlanMasterPlanControl"
            Me.Size = New System.Drawing.Size(820, 501)
            CType(Me.TabControlControl_MasterPlanDetails, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlControl_MasterPlanDetails.ResumeLayout(False)
            Me.TabControlPanelPlansTab_Plans.ResumeLayout(False)
            Me.PanelPlans_PlansRight.ResumeLayout(False)
            Me.PanelPlans_PlansLeft.ResumeLayout(False)
            Me.TabControlPanelEstimatesTab_Estimates.ResumeLayout(False)
            Me.TabControlPanelDashboardTab_Dashboard.ResumeLayout(False)
            CType(Me.DashboardViewerDashboard_Dashboard, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelControl_TopSection.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents TabControlControl_MasterPlanDetails As TabControl
        Friend WithEvents TabControlPanelPlansTab_Plans As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents PanelPlans_PlansRight As Windows.Forms.Panel
        Friend WithEvents ButtonPlansRight_AddPlan As Button
        Friend WithEvents ButtonPlansRight_AddAllPlans As Button
        Friend WithEvents ButtonPlansRight_RemoveAllPlans As Button
        Friend WithEvents ButtonPlansRight_RemovePlan As Button
        Friend WithEvents DataGridViewPlansRight_SelectedMediaPlans As DataGridView
        Friend WithEvents ExpandableSplitterMiddleSection_LeftRight As ExpandableSplitterControl
        Friend WithEvents PanelPlans_PlansLeft As Windows.Forms.Panel
        Friend WithEvents DataGridViewPlansLeft_MediaPlans As DataGridView
        Friend WithEvents TabItemMasterPlanDetails_PlansTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelEstimatesTab_Estimates As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewEstimates_Estimates As DataGridView
        Friend WithEvents TabItemMasterPlanDetails_EstimatesTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelDashboardTab_Dashboard As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DashboardViewerDashboard_Dashboard As AdvantageFramework.WinForm.Presentation.Controls.DashboardViewerControl
        Friend WithEvents TabItemMasterPlanDetails_DashboardTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents PanelControl_TopSection As Windows.Forms.Panel
        Friend WithEvents LabelTopSection_Description As Label
        Friend WithEvents TextBoxTopSection_Description As TextBox
        Friend WithEvents TextBoxTopSection_Comment As TextBox
        Friend WithEvents LabelTopSection_Comment As Label
    End Class

End Namespace
