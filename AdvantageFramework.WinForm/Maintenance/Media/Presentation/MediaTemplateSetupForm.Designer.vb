Namespace Maintenance.Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaTemplateSetupForm
        Inherits AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseForm

        'Form overrides dispose to clean up the component list.
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaTemplateSetupForm))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_PlanTemplates = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemPlanTemplates_Manage = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemPlanTemplates_Clients = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_EstimateTemplates = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemEstimateTemplates_EnterRates = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemEstimateTemplates_EnterPercent = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemEstimateTemplates_Clients = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Copy = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.TabControlForm_Tabs = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelTemplates_Templates = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewTemplates_Templates = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.TabItemTabs_Templates = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelOutOfHomeTypes_OutOfHomeTypes = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewOutOfHomeTypes_OutOfHomeTypes = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.LabelOutOfHomeTypes_TemplateName = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.TabItemTabs_OutOfHomeTypes = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelDayparts_Dayparts = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewDayparts_Dayparts = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.LabelDayparts_TemplateName = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.TabItemTabs_Dayparts = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelSpotLengths_SpotLengths = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewSpotLengths_SpotLengths = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.LabelSpotLengths_TemplateName = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.TabItemTabs_SpotLengths = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelDemographics_Demographics = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewDemographics_Demographics = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.LabelDemographics_TemplateName = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.TabItemTabs_Demographics = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelMarkets_Markets = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewMarkets_Markets = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.LabelMarkets_TemplateName = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.TabItemTabs_Markets = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelTactics_Tactics = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewTactics_Tactics = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.LabelTactics_TemplateName = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.TabItemTabs_Tactics = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelAdSizes_AdSizes = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewAdSizes_AdSizes = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.LabelAdSizes_TemplateName = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.TabItemTabs_AdSizes = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelRateTypes_RateTypes = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewRateTypes_RateTypes = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.LabelRateTypes_TemplateName = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.TabItemTabs_RateTypes = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelQuarters_Quarters = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewQuarters_Quarters = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.LabelQuarters_TemplateName = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.TabItemTabs_Quarters = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelVendors_Vendors = New DevComponents.DotNetBar.TabControlPanel()
            Me.LabelVendors_TemplateName = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.DataGridViewVendors_Vendors = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.TabItemTabs_Vendors = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            CType(Me.TabControlForm_Tabs, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_Tabs.SuspendLayout()
            Me.TabControlPanelTemplates_Templates.SuspendLayout()
            Me.TabControlPanelOutOfHomeTypes_OutOfHomeTypes.SuspendLayout()
            Me.TabControlPanelDayparts_Dayparts.SuspendLayout()
            Me.TabControlPanelSpotLengths_SpotLengths.SuspendLayout()
            Me.TabControlPanelDemographics_Demographics.SuspendLayout()
            Me.TabControlPanelMarkets_Markets.SuspendLayout()
            Me.TabControlPanelTactics_Tactics.SuspendLayout()
            Me.TabControlPanelAdSizes_AdSizes.SuspendLayout()
            Me.TabControlPanelRateTypes_RateTypes.SuspendLayout()
            Me.TabControlPanelQuarters_Quarters.SuspendLayout()
            Me.TabControlPanelVendors_Vendors.SuspendLayout()
            Me.SuspendLayout()
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_PlanTemplates)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_EstimateTemplates)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(98, 126)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(562, 98)
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
            'RibbonBarOptions_PlanTemplates
            '
            Me.RibbonBarOptions_PlanTemplates.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_PlanTemplates.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_PlanTemplates.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_PlanTemplates.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_PlanTemplates.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_PlanTemplates.DragDropSupport = True
            Me.RibbonBarOptions_PlanTemplates.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemPlanTemplates_Manage, Me.ButtonItemPlanTemplates_Clients})
            Me.RibbonBarOptions_PlanTemplates.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_PlanTemplates.Location = New System.Drawing.Point(354, 0)
            Me.RibbonBarOptions_PlanTemplates.Name = "RibbonBarOptions_PlanTemplates"
            Me.RibbonBarOptions_PlanTemplates.SecurityEnabled = True
            Me.RibbonBarOptions_PlanTemplates.Size = New System.Drawing.Size(115, 98)
            Me.RibbonBarOptions_PlanTemplates.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_PlanTemplates.TabIndex = 1
            Me.RibbonBarOptions_PlanTemplates.Text = "Plan Templates"
            '
            '
            '
            Me.RibbonBarOptions_PlanTemplates.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_PlanTemplates.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_PlanTemplates.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemPlanTemplates_Manage
            '
            Me.ButtonItemPlanTemplates_Manage.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemPlanTemplates_Manage.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemPlanTemplates_Manage.Name = "ButtonItemPlanTemplates_Manage"
            Me.ButtonItemPlanTemplates_Manage.RibbonWordWrap = False
            Me.ButtonItemPlanTemplates_Manage.SecurityEnabled = True
            Me.ButtonItemPlanTemplates_Manage.Stretch = True
            Me.ButtonItemPlanTemplates_Manage.SubItemsExpandWidth = 14
            Me.ButtonItemPlanTemplates_Manage.Text = "Manage"
            '
            'ButtonItemPlanTemplates_Clients
            '
            Me.ButtonItemPlanTemplates_Clients.BeginGroup = True
            Me.ButtonItemPlanTemplates_Clients.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemPlanTemplates_Clients.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemPlanTemplates_Clients.Name = "ButtonItemPlanTemplates_Clients"
            Me.ButtonItemPlanTemplates_Clients.RibbonWordWrap = False
            Me.ButtonItemPlanTemplates_Clients.SecurityEnabled = True
            Me.ButtonItemPlanTemplates_Clients.Stretch = True
            Me.ButtonItemPlanTemplates_Clients.SubItemsExpandWidth = 14
            Me.ButtonItemPlanTemplates_Clients.Text = "Clients"
            '
            'RibbonBarOptions_EstimateTemplates
            '
            Me.RibbonBarOptions_EstimateTemplates.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_EstimateTemplates.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_EstimateTemplates.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_EstimateTemplates.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_EstimateTemplates.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_EstimateTemplates.DragDropSupport = True
            Me.RibbonBarOptions_EstimateTemplates.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemEstimateTemplates_EnterRates, Me.ButtonItemEstimateTemplates_EnterPercent, Me.ButtonItemEstimateTemplates_Clients})
            Me.RibbonBarOptions_EstimateTemplates.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_EstimateTemplates.Location = New System.Drawing.Point(158, 0)
            Me.RibbonBarOptions_EstimateTemplates.Name = "RibbonBarOptions_EstimateTemplates"
            Me.RibbonBarOptions_EstimateTemplates.SecurityEnabled = True
            Me.RibbonBarOptions_EstimateTemplates.Size = New System.Drawing.Size(196, 98)
            Me.RibbonBarOptions_EstimateTemplates.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_EstimateTemplates.TabIndex = 2
            Me.RibbonBarOptions_EstimateTemplates.Text = "Estimate Templates"
            '
            '
            '
            Me.RibbonBarOptions_EstimateTemplates.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_EstimateTemplates.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_EstimateTemplates.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemEstimateTemplates_EnterRates
            '
            Me.ButtonItemEstimateTemplates_EnterRates.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemEstimateTemplates_EnterRates.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemEstimateTemplates_EnterRates.Name = "ButtonItemEstimateTemplates_EnterRates"
            Me.ButtonItemEstimateTemplates_EnterRates.RibbonWordWrap = False
            Me.ButtonItemEstimateTemplates_EnterRates.SecurityEnabled = True
            Me.ButtonItemEstimateTemplates_EnterRates.Stretch = True
            Me.ButtonItemEstimateTemplates_EnterRates.SubItemsExpandWidth = 14
            Me.ButtonItemEstimateTemplates_EnterRates.Text = "Enter Rates"
            '
            'ButtonItemEstimateTemplates_EnterPercent
            '
            Me.ButtonItemEstimateTemplates_EnterPercent.BeginGroup = True
            Me.ButtonItemEstimateTemplates_EnterPercent.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemEstimateTemplates_EnterPercent.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemEstimateTemplates_EnterPercent.Name = "ButtonItemEstimateTemplates_EnterPercent"
            Me.ButtonItemEstimateTemplates_EnterPercent.RibbonWordWrap = False
            Me.ButtonItemEstimateTemplates_EnterPercent.SecurityEnabled = True
            Me.ButtonItemEstimateTemplates_EnterPercent.Stretch = True
            Me.ButtonItemEstimateTemplates_EnterPercent.SubItemsExpandWidth = 14
            Me.ButtonItemEstimateTemplates_EnterPercent.Text = "Enter Percent"
            '
            'ButtonItemEstimateTemplates_Clients
            '
            Me.ButtonItemEstimateTemplates_Clients.BeginGroup = True
            Me.ButtonItemEstimateTemplates_Clients.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemEstimateTemplates_Clients.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemEstimateTemplates_Clients.Name = "ButtonItemEstimateTemplates_Clients"
            Me.ButtonItemEstimateTemplates_Clients.RibbonWordWrap = False
            Me.ButtonItemEstimateTemplates_Clients.SecurityEnabled = True
            Me.ButtonItemEstimateTemplates_Clients.Stretch = True
            Me.ButtonItemEstimateTemplates_Clients.SubItemsExpandWidth = 14
            Me.ButtonItemEstimateTemplates_Clients.Text = "Clients"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Save, Me.ButtonItemActions_Cancel, Me.ButtonItemActions_Delete, Me.ButtonItemActions_Copy})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(158, 98)
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
            Me.RibbonBarOptions_Actions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemActions_Save
            '
            Me.ButtonItemActions_Save.BeginGroup = True
            Me.ButtonItemActions_Save.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Save.Name = "ButtonItemActions_Save"
            Me.ButtonItemActions_Save.RibbonWordWrap = False
            Me.ButtonItemActions_Save.SecurityEnabled = True
            Me.ButtonItemActions_Save.Stretch = True
            Me.ButtonItemActions_Save.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Save.Text = "Save"
            '
            'ButtonItemActions_Cancel
            '
            Me.ButtonItemActions_Cancel.BeginGroup = True
            Me.ButtonItemActions_Cancel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Cancel.Name = "ButtonItemActions_Cancel"
            Me.ButtonItemActions_Cancel.RibbonWordWrap = False
            Me.ButtonItemActions_Cancel.SecurityEnabled = True
            Me.ButtonItemActions_Cancel.Stretch = True
            Me.ButtonItemActions_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Cancel.Text = "Cancel"
            '
            'ButtonItemActions_Delete
            '
            Me.ButtonItemActions_Delete.BeginGroup = True
            Me.ButtonItemActions_Delete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Delete.Name = "ButtonItemActions_Delete"
            Me.ButtonItemActions_Delete.RibbonWordWrap = False
            Me.ButtonItemActions_Delete.SecurityEnabled = True
            Me.ButtonItemActions_Delete.Stretch = True
            Me.ButtonItemActions_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Delete.Text = "Delete"
            '
            'ButtonItemActions_Copy
            '
            Me.ButtonItemActions_Copy.BeginGroup = True
            Me.ButtonItemActions_Copy.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Copy.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Copy.Name = "ButtonItemActions_Copy"
            Me.ButtonItemActions_Copy.RibbonWordWrap = False
            Me.ButtonItemActions_Copy.SecurityEnabled = True
            Me.ButtonItemActions_Copy.Stretch = True
            Me.ButtonItemActions_Copy.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Copy.Text = "Copy"
            '
            'TabControlForm_Tabs
            '
            Me.TabControlForm_Tabs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlForm_Tabs.BackColor = System.Drawing.Color.White
            Me.TabControlForm_Tabs.CanReorderTabs = False
            Me.TabControlForm_Tabs.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlForm_Tabs.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlForm_Tabs.Controls.Add(Me.TabControlPanelTemplates_Templates)
            Me.TabControlForm_Tabs.Controls.Add(Me.TabControlPanelOutOfHomeTypes_OutOfHomeTypes)
            Me.TabControlForm_Tabs.Controls.Add(Me.TabControlPanelDayparts_Dayparts)
            Me.TabControlForm_Tabs.Controls.Add(Me.TabControlPanelSpotLengths_SpotLengths)
            Me.TabControlForm_Tabs.Controls.Add(Me.TabControlPanelDemographics_Demographics)
            Me.TabControlForm_Tabs.Controls.Add(Me.TabControlPanelMarkets_Markets)
            Me.TabControlForm_Tabs.Controls.Add(Me.TabControlPanelTactics_Tactics)
            Me.TabControlForm_Tabs.Controls.Add(Me.TabControlPanelAdSizes_AdSizes)
            Me.TabControlForm_Tabs.Controls.Add(Me.TabControlPanelRateTypes_RateTypes)
            Me.TabControlForm_Tabs.Controls.Add(Me.TabControlPanelQuarters_Quarters)
            Me.TabControlForm_Tabs.Controls.Add(Me.TabControlPanelVendors_Vendors)
            Me.TabControlForm_Tabs.ForeColor = System.Drawing.Color.Black
            Me.TabControlForm_Tabs.Location = New System.Drawing.Point(12, 12)
            Me.TabControlForm_Tabs.Name = "TabControlForm_Tabs"
            Me.TabControlForm_Tabs.SelectedTabFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_Tabs.SelectedTabIndex = 0
            Me.TabControlForm_Tabs.Size = New System.Drawing.Size(689, 397)
            Me.TabControlForm_Tabs.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_Tabs.TabIndex = 5
            Me.TabControlForm_Tabs.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_Tabs.Tabs.Add(Me.TabItemTabs_Templates)
            Me.TabControlForm_Tabs.Tabs.Add(Me.TabItemTabs_Vendors)
            Me.TabControlForm_Tabs.Tabs.Add(Me.TabItemTabs_Tactics)
            Me.TabControlForm_Tabs.Tabs.Add(Me.TabItemTabs_Markets)
            Me.TabControlForm_Tabs.Tabs.Add(Me.TabItemTabs_Demographics)
            Me.TabControlForm_Tabs.Tabs.Add(Me.TabItemTabs_SpotLengths)
            Me.TabControlForm_Tabs.Tabs.Add(Me.TabItemTabs_OutOfHomeTypes)
            Me.TabControlForm_Tabs.Tabs.Add(Me.TabItemTabs_AdSizes)
            Me.TabControlForm_Tabs.Tabs.Add(Me.TabItemTabs_RateTypes)
            Me.TabControlForm_Tabs.Tabs.Add(Me.TabItemTabs_Quarters)
            Me.TabControlForm_Tabs.Tabs.Add(Me.TabItemTabs_Dayparts)
            '
            'TabControlPanelTemplates_Templates
            '
            Me.TabControlPanelTemplates_Templates.Controls.Add(Me.DataGridViewTemplates_Templates)
            Me.TabControlPanelTemplates_Templates.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelTemplates_Templates.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelTemplates_Templates.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelTemplates_Templates.Name = "TabControlPanelTemplates_Templates"
            Me.TabControlPanelTemplates_Templates.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelTemplates_Templates.Size = New System.Drawing.Size(689, 370)
            Me.TabControlPanelTemplates_Templates.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelTemplates_Templates.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelTemplates_Templates.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelTemplates_Templates.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelTemplates_Templates.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelTemplates_Templates.Style.GradientAngle = 90
            Me.TabControlPanelTemplates_Templates.TabIndex = 0
            Me.TabControlPanelTemplates_Templates.TabItem = Me.TabItemTabs_Templates
            '
            'DataGridViewTemplates_Templates
            '
            Me.DataGridViewTemplates_Templates.AllowSelectGroupHeaderRow = True
            Me.DataGridViewTemplates_Templates.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewTemplates_Templates.AutoUpdateViewCaption = True
            Me.DataGridViewTemplates_Templates.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewTemplates_Templates.ItemDescription = "Template(s)"
            Me.DataGridViewTemplates_Templates.Location = New System.Drawing.Point(9, 4)
            Me.DataGridViewTemplates_Templates.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewTemplates_Templates.ModifyGridRowHeight = False
            Me.DataGridViewTemplates_Templates.MultiSelect = False
            Me.DataGridViewTemplates_Templates.Name = "DataGridViewTemplates_Templates"
            Me.DataGridViewTemplates_Templates.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewTemplates_Templates.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewTemplates_Templates.ShowRowSelectionIfHidden = True
            Me.DataGridViewTemplates_Templates.ShowSelectDeselectAllButtons = False
            Me.DataGridViewTemplates_Templates.Size = New System.Drawing.Size(671, 362)
            Me.DataGridViewTemplates_Templates.TabIndex = 6
            Me.DataGridViewTemplates_Templates.UseEmbeddedNavigator = False
            Me.DataGridViewTemplates_Templates.ViewCaptionHeight = -1
            '
            'TabItemTabs_Templates
            '
            Me.TabItemTabs_Templates.AttachedControl = Me.TabControlPanelTemplates_Templates
            Me.TabItemTabs_Templates.Name = "TabItemTabs_Templates"
            Me.TabItemTabs_Templates.Text = "Estimate Templates"
            '
            'TabControlPanelOutOfHomeTypes_OutOfHomeTypes
            '
            Me.TabControlPanelOutOfHomeTypes_OutOfHomeTypes.Controls.Add(Me.DataGridViewOutOfHomeTypes_OutOfHomeTypes)
            Me.TabControlPanelOutOfHomeTypes_OutOfHomeTypes.Controls.Add(Me.LabelOutOfHomeTypes_TemplateName)
            Me.TabControlPanelOutOfHomeTypes_OutOfHomeTypes.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelOutOfHomeTypes_OutOfHomeTypes.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelOutOfHomeTypes_OutOfHomeTypes.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelOutOfHomeTypes_OutOfHomeTypes.Name = "TabControlPanelOutOfHomeTypes_OutOfHomeTypes"
            Me.TabControlPanelOutOfHomeTypes_OutOfHomeTypes.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelOutOfHomeTypes_OutOfHomeTypes.Size = New System.Drawing.Size(689, 370)
            Me.TabControlPanelOutOfHomeTypes_OutOfHomeTypes.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelOutOfHomeTypes_OutOfHomeTypes.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelOutOfHomeTypes_OutOfHomeTypes.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelOutOfHomeTypes_OutOfHomeTypes.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelOutOfHomeTypes_OutOfHomeTypes.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelOutOfHomeTypes_OutOfHomeTypes.Style.GradientAngle = 90
            Me.TabControlPanelOutOfHomeTypes_OutOfHomeTypes.TabIndex = 104
            Me.TabControlPanelOutOfHomeTypes_OutOfHomeTypes.TabItem = Me.TabItemTabs_OutOfHomeTypes
            '
            'DataGridViewOutOfHomeTypes_OutOfHomeTypes
            '
            Me.DataGridViewOutOfHomeTypes_OutOfHomeTypes.AllowSelectGroupHeaderRow = True
            Me.DataGridViewOutOfHomeTypes_OutOfHomeTypes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewOutOfHomeTypes_OutOfHomeTypes.AutoUpdateViewCaption = True
            Me.DataGridViewOutOfHomeTypes_OutOfHomeTypes.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewOutOfHomeTypes_OutOfHomeTypes.ItemDescription = "Out of Home Type(s)"
            Me.DataGridViewOutOfHomeTypes_OutOfHomeTypes.Location = New System.Drawing.Point(9, 30)
            Me.DataGridViewOutOfHomeTypes_OutOfHomeTypes.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewOutOfHomeTypes_OutOfHomeTypes.ModifyGridRowHeight = False
            Me.DataGridViewOutOfHomeTypes_OutOfHomeTypes.MultiSelect = True
            Me.DataGridViewOutOfHomeTypes_OutOfHomeTypes.Name = "DataGridViewOutOfHomeTypes_OutOfHomeTypes"
            Me.DataGridViewOutOfHomeTypes_OutOfHomeTypes.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewOutOfHomeTypes_OutOfHomeTypes.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewOutOfHomeTypes_OutOfHomeTypes.ShowRowSelectionIfHidden = True
            Me.DataGridViewOutOfHomeTypes_OutOfHomeTypes.ShowSelectDeselectAllButtons = False
            Me.DataGridViewOutOfHomeTypes_OutOfHomeTypes.Size = New System.Drawing.Size(671, 336)
            Me.DataGridViewOutOfHomeTypes_OutOfHomeTypes.TabIndex = 18
            Me.DataGridViewOutOfHomeTypes_OutOfHomeTypes.UseEmbeddedNavigator = False
            Me.DataGridViewOutOfHomeTypes_OutOfHomeTypes.ViewCaptionHeight = -1
            '
            'LabelOutOfHomeTypes_TemplateName
            '
            Me.LabelOutOfHomeTypes_TemplateName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelOutOfHomeTypes_TemplateName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelOutOfHomeTypes_TemplateName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelOutOfHomeTypes_TemplateName.Location = New System.Drawing.Point(9, 4)
            Me.LabelOutOfHomeTypes_TemplateName.Name = "LabelOutOfHomeTypes_TemplateName"
            Me.LabelOutOfHomeTypes_TemplateName.Size = New System.Drawing.Size(671, 20)
            Me.LabelOutOfHomeTypes_TemplateName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOutOfHomeTypes_TemplateName.TabIndex = 17
            '
            'TabItemTabs_OutOfHomeTypes
            '
            Me.TabItemTabs_OutOfHomeTypes.AttachedControl = Me.TabControlPanelOutOfHomeTypes_OutOfHomeTypes
            Me.TabItemTabs_OutOfHomeTypes.Name = "TabItemTabs_OutOfHomeTypes"
            Me.TabItemTabs_OutOfHomeTypes.Text = "Out Of Home Types"
            '
            'TabControlPanelDayparts_Dayparts
            '
            Me.TabControlPanelDayparts_Dayparts.Controls.Add(Me.DataGridViewDayparts_Dayparts)
            Me.TabControlPanelDayparts_Dayparts.Controls.Add(Me.LabelDayparts_TemplateName)
            Me.TabControlPanelDayparts_Dayparts.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelDayparts_Dayparts.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelDayparts_Dayparts.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelDayparts_Dayparts.Name = "TabControlPanelDayparts_Dayparts"
            Me.TabControlPanelDayparts_Dayparts.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelDayparts_Dayparts.Size = New System.Drawing.Size(689, 370)
            Me.TabControlPanelDayparts_Dayparts.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelDayparts_Dayparts.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDayparts_Dayparts.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelDayparts_Dayparts.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelDayparts_Dayparts.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelDayparts_Dayparts.Style.GradientAngle = 90
            Me.TabControlPanelDayparts_Dayparts.TabIndex = 67
            Me.TabControlPanelDayparts_Dayparts.TabItem = Me.TabItemTabs_Dayparts
            '
            'DataGridViewDayparts_Dayparts
            '
            Me.DataGridViewDayparts_Dayparts.AllowSelectGroupHeaderRow = True
            Me.DataGridViewDayparts_Dayparts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewDayparts_Dayparts.AutoUpdateViewCaption = True
            Me.DataGridViewDayparts_Dayparts.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewDayparts_Dayparts.ItemDescription = "Daypart(s)"
            Me.DataGridViewDayparts_Dayparts.Location = New System.Drawing.Point(9, 30)
            Me.DataGridViewDayparts_Dayparts.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewDayparts_Dayparts.ModifyGridRowHeight = False
            Me.DataGridViewDayparts_Dayparts.MultiSelect = True
            Me.DataGridViewDayparts_Dayparts.Name = "DataGridViewDayparts_Dayparts"
            Me.DataGridViewDayparts_Dayparts.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewDayparts_Dayparts.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewDayparts_Dayparts.ShowRowSelectionIfHidden = True
            Me.DataGridViewDayparts_Dayparts.ShowSelectDeselectAllButtons = False
            Me.DataGridViewDayparts_Dayparts.Size = New System.Drawing.Size(671, 336)
            Me.DataGridViewDayparts_Dayparts.TabIndex = 18
            Me.DataGridViewDayparts_Dayparts.UseEmbeddedNavigator = False
            Me.DataGridViewDayparts_Dayparts.ViewCaptionHeight = -1
            '
            'LabelDayparts_TemplateName
            '
            Me.LabelDayparts_TemplateName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelDayparts_TemplateName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDayparts_TemplateName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDayparts_TemplateName.Location = New System.Drawing.Point(9, 4)
            Me.LabelDayparts_TemplateName.Name = "LabelDayparts_TemplateName"
            Me.LabelDayparts_TemplateName.Size = New System.Drawing.Size(671, 20)
            Me.LabelDayparts_TemplateName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDayparts_TemplateName.TabIndex = 15
            '
            'TabItemTabs_Dayparts
            '
            Me.TabItemTabs_Dayparts.AttachedControl = Me.TabControlPanelDayparts_Dayparts
            Me.TabItemTabs_Dayparts.Name = "TabItemTabs_Dayparts"
            Me.TabItemTabs_Dayparts.Text = "Dayparts"
            '
            'TabControlPanelSpotLengths_SpotLengths
            '
            Me.TabControlPanelSpotLengths_SpotLengths.Controls.Add(Me.DataGridViewSpotLengths_SpotLengths)
            Me.TabControlPanelSpotLengths_SpotLengths.Controls.Add(Me.LabelSpotLengths_TemplateName)
            Me.TabControlPanelSpotLengths_SpotLengths.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSpotLengths_SpotLengths.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSpotLengths_SpotLengths.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelSpotLengths_SpotLengths.Name = "TabControlPanelSpotLengths_SpotLengths"
            Me.TabControlPanelSpotLengths_SpotLengths.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSpotLengths_SpotLengths.Size = New System.Drawing.Size(689, 370)
            Me.TabControlPanelSpotLengths_SpotLengths.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelSpotLengths_SpotLengths.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSpotLengths_SpotLengths.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSpotLengths_SpotLengths.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSpotLengths_SpotLengths.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSpotLengths_SpotLengths.Style.GradientAngle = 90
            Me.TabControlPanelSpotLengths_SpotLengths.TabIndex = 71
            Me.TabControlPanelSpotLengths_SpotLengths.TabItem = Me.TabItemTabs_SpotLengths
            '
            'DataGridViewSpotLengths_SpotLengths
            '
            Me.DataGridViewSpotLengths_SpotLengths.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSpotLengths_SpotLengths.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSpotLengths_SpotLengths.AutoUpdateViewCaption = True
            Me.DataGridViewSpotLengths_SpotLengths.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSpotLengths_SpotLengths.ItemDescription = "Spot Length(s)"
            Me.DataGridViewSpotLengths_SpotLengths.Location = New System.Drawing.Point(9, 30)
            Me.DataGridViewSpotLengths_SpotLengths.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewSpotLengths_SpotLengths.ModifyGridRowHeight = False
            Me.DataGridViewSpotLengths_SpotLengths.MultiSelect = True
            Me.DataGridViewSpotLengths_SpotLengths.Name = "DataGridViewSpotLengths_SpotLengths"
            Me.DataGridViewSpotLengths_SpotLengths.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewSpotLengths_SpotLengths.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewSpotLengths_SpotLengths.ShowRowSelectionIfHidden = True
            Me.DataGridViewSpotLengths_SpotLengths.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSpotLengths_SpotLengths.Size = New System.Drawing.Size(671, 336)
            Me.DataGridViewSpotLengths_SpotLengths.TabIndex = 16
            Me.DataGridViewSpotLengths_SpotLengths.UseEmbeddedNavigator = False
            Me.DataGridViewSpotLengths_SpotLengths.ViewCaptionHeight = -1
            '
            'LabelSpotLengths_TemplateName
            '
            Me.LabelSpotLengths_TemplateName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelSpotLengths_TemplateName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSpotLengths_TemplateName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSpotLengths_TemplateName.Location = New System.Drawing.Point(9, 4)
            Me.LabelSpotLengths_TemplateName.Name = "LabelSpotLengths_TemplateName"
            Me.LabelSpotLengths_TemplateName.Size = New System.Drawing.Size(671, 20)
            Me.LabelSpotLengths_TemplateName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSpotLengths_TemplateName.TabIndex = 15
            '
            'TabItemTabs_SpotLengths
            '
            Me.TabItemTabs_SpotLengths.AttachedControl = Me.TabControlPanelSpotLengths_SpotLengths
            Me.TabItemTabs_SpotLengths.Name = "TabItemTabs_SpotLengths"
            Me.TabItemTabs_SpotLengths.Text = "Spot Lengths"
            '
            'TabControlPanelDemographics_Demographics
            '
            Me.TabControlPanelDemographics_Demographics.Controls.Add(Me.DataGridViewDemographics_Demographics)
            Me.TabControlPanelDemographics_Demographics.Controls.Add(Me.LabelDemographics_TemplateName)
            Me.TabControlPanelDemographics_Demographics.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelDemographics_Demographics.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelDemographics_Demographics.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelDemographics_Demographics.Name = "TabControlPanelDemographics_Demographics"
            Me.TabControlPanelDemographics_Demographics.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelDemographics_Demographics.Size = New System.Drawing.Size(689, 370)
            Me.TabControlPanelDemographics_Demographics.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelDemographics_Demographics.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDemographics_Demographics.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelDemographics_Demographics.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelDemographics_Demographics.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelDemographics_Demographics.Style.GradientAngle = 90
            Me.TabControlPanelDemographics_Demographics.TabIndex = 75
            Me.TabControlPanelDemographics_Demographics.TabItem = Me.TabItemTabs_Demographics
            '
            'DataGridViewDemographics_Demographics
            '
            Me.DataGridViewDemographics_Demographics.AllowSelectGroupHeaderRow = True
            Me.DataGridViewDemographics_Demographics.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewDemographics_Demographics.AutoUpdateViewCaption = True
            Me.DataGridViewDemographics_Demographics.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewDemographics_Demographics.ItemDescription = "Demographic(s)"
            Me.DataGridViewDemographics_Demographics.Location = New System.Drawing.Point(9, 30)
            Me.DataGridViewDemographics_Demographics.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewDemographics_Demographics.ModifyGridRowHeight = False
            Me.DataGridViewDemographics_Demographics.MultiSelect = True
            Me.DataGridViewDemographics_Demographics.Name = "DataGridViewDemographics_Demographics"
            Me.DataGridViewDemographics_Demographics.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewDemographics_Demographics.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewDemographics_Demographics.ShowRowSelectionIfHidden = True
            Me.DataGridViewDemographics_Demographics.ShowSelectDeselectAllButtons = False
            Me.DataGridViewDemographics_Demographics.Size = New System.Drawing.Size(671, 336)
            Me.DataGridViewDemographics_Demographics.TabIndex = 16
            Me.DataGridViewDemographics_Demographics.UseEmbeddedNavigator = False
            Me.DataGridViewDemographics_Demographics.ViewCaptionHeight = -1
            '
            'LabelDemographics_TemplateName
            '
            Me.LabelDemographics_TemplateName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelDemographics_TemplateName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDemographics_TemplateName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDemographics_TemplateName.Location = New System.Drawing.Point(9, 4)
            Me.LabelDemographics_TemplateName.Name = "LabelDemographics_TemplateName"
            Me.LabelDemographics_TemplateName.Size = New System.Drawing.Size(671, 20)
            Me.LabelDemographics_TemplateName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDemographics_TemplateName.TabIndex = 15
            '
            'TabItemTabs_Demographics
            '
            Me.TabItemTabs_Demographics.AttachedControl = Me.TabControlPanelDemographics_Demographics
            Me.TabItemTabs_Demographics.Name = "TabItemTabs_Demographics"
            Me.TabItemTabs_Demographics.Text = "Demographics"
            '
            'TabControlPanelMarkets_Markets
            '
            Me.TabControlPanelMarkets_Markets.Controls.Add(Me.DataGridViewMarkets_Markets)
            Me.TabControlPanelMarkets_Markets.Controls.Add(Me.LabelMarkets_TemplateName)
            Me.TabControlPanelMarkets_Markets.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelMarkets_Markets.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelMarkets_Markets.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelMarkets_Markets.Name = "TabControlPanelMarkets_Markets"
            Me.TabControlPanelMarkets_Markets.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelMarkets_Markets.Size = New System.Drawing.Size(689, 370)
            Me.TabControlPanelMarkets_Markets.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelMarkets_Markets.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelMarkets_Markets.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelMarkets_Markets.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelMarkets_Markets.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelMarkets_Markets.Style.GradientAngle = 90
            Me.TabControlPanelMarkets_Markets.TabIndex = 63
            Me.TabControlPanelMarkets_Markets.TabItem = Me.TabItemTabs_Markets
            '
            'DataGridViewMarkets_Markets
            '
            Me.DataGridViewMarkets_Markets.AllowSelectGroupHeaderRow = True
            Me.DataGridViewMarkets_Markets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewMarkets_Markets.AutoUpdateViewCaption = True
            Me.DataGridViewMarkets_Markets.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewMarkets_Markets.ItemDescription = "Market(s)"
            Me.DataGridViewMarkets_Markets.Location = New System.Drawing.Point(9, 30)
            Me.DataGridViewMarkets_Markets.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewMarkets_Markets.ModifyGridRowHeight = False
            Me.DataGridViewMarkets_Markets.MultiSelect = True
            Me.DataGridViewMarkets_Markets.Name = "DataGridViewMarkets_Markets"
            Me.DataGridViewMarkets_Markets.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewMarkets_Markets.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewMarkets_Markets.ShowRowSelectionIfHidden = True
            Me.DataGridViewMarkets_Markets.ShowSelectDeselectAllButtons = False
            Me.DataGridViewMarkets_Markets.Size = New System.Drawing.Size(671, 336)
            Me.DataGridViewMarkets_Markets.TabIndex = 15
            Me.DataGridViewMarkets_Markets.UseEmbeddedNavigator = False
            Me.DataGridViewMarkets_Markets.ViewCaptionHeight = -1
            '
            'LabelMarkets_TemplateName
            '
            Me.LabelMarkets_TemplateName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelMarkets_TemplateName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMarkets_TemplateName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMarkets_TemplateName.Location = New System.Drawing.Point(9, 4)
            Me.LabelMarkets_TemplateName.Name = "LabelMarkets_TemplateName"
            Me.LabelMarkets_TemplateName.Size = New System.Drawing.Size(671, 20)
            Me.LabelMarkets_TemplateName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMarkets_TemplateName.TabIndex = 14
            '
            'TabItemTabs_Markets
            '
            Me.TabItemTabs_Markets.AttachedControl = Me.TabControlPanelMarkets_Markets
            Me.TabItemTabs_Markets.Name = "TabItemTabs_Markets"
            Me.TabItemTabs_Markets.Text = "Markets"
            '
            'TabControlPanelTactics_Tactics
            '
            Me.TabControlPanelTactics_Tactics.Controls.Add(Me.DataGridViewTactics_Tactics)
            Me.TabControlPanelTactics_Tactics.Controls.Add(Me.LabelTactics_TemplateName)
            Me.TabControlPanelTactics_Tactics.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelTactics_Tactics.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelTactics_Tactics.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelTactics_Tactics.Name = "TabControlPanelTactics_Tactics"
            Me.TabControlPanelTactics_Tactics.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelTactics_Tactics.Size = New System.Drawing.Size(689, 370)
            Me.TabControlPanelTactics_Tactics.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelTactics_Tactics.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelTactics_Tactics.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelTactics_Tactics.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelTactics_Tactics.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelTactics_Tactics.Style.GradientAngle = 90
            Me.TabControlPanelTactics_Tactics.TabIndex = 59
            Me.TabControlPanelTactics_Tactics.TabItem = Me.TabItemTabs_Tactics
            '
            'DataGridViewTactics_Tactics
            '
            Me.DataGridViewTactics_Tactics.AllowSelectGroupHeaderRow = True
            Me.DataGridViewTactics_Tactics.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewTactics_Tactics.AutoUpdateViewCaption = True
            Me.DataGridViewTactics_Tactics.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewTactics_Tactics.ItemDescription = "Tactic(s)"
            Me.DataGridViewTactics_Tactics.Location = New System.Drawing.Point(9, 30)
            Me.DataGridViewTactics_Tactics.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewTactics_Tactics.ModifyGridRowHeight = False
            Me.DataGridViewTactics_Tactics.MultiSelect = True
            Me.DataGridViewTactics_Tactics.Name = "DataGridViewTactics_Tactics"
            Me.DataGridViewTactics_Tactics.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewTactics_Tactics.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewTactics_Tactics.ShowRowSelectionIfHidden = True
            Me.DataGridViewTactics_Tactics.ShowSelectDeselectAllButtons = False
            Me.DataGridViewTactics_Tactics.Size = New System.Drawing.Size(671, 336)
            Me.DataGridViewTactics_Tactics.TabIndex = 13
            Me.DataGridViewTactics_Tactics.UseEmbeddedNavigator = False
            Me.DataGridViewTactics_Tactics.ViewCaptionHeight = -1
            '
            'LabelTactics_TemplateName
            '
            Me.LabelTactics_TemplateName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelTactics_TemplateName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTactics_TemplateName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTactics_TemplateName.Location = New System.Drawing.Point(9, 4)
            Me.LabelTactics_TemplateName.Name = "LabelTactics_TemplateName"
            Me.LabelTactics_TemplateName.Size = New System.Drawing.Size(671, 20)
            Me.LabelTactics_TemplateName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTactics_TemplateName.TabIndex = 12
            '
            'TabItemTabs_Tactics
            '
            Me.TabItemTabs_Tactics.AttachedControl = Me.TabControlPanelTactics_Tactics
            Me.TabItemTabs_Tactics.Name = "TabItemTabs_Tactics"
            Me.TabItemTabs_Tactics.Text = "Tactics"
            '
            'TabControlPanelAdSizes_AdSizes
            '
            Me.TabControlPanelAdSizes_AdSizes.Controls.Add(Me.DataGridViewAdSizes_AdSizes)
            Me.TabControlPanelAdSizes_AdSizes.Controls.Add(Me.LabelAdSizes_TemplateName)
            Me.TabControlPanelAdSizes_AdSizes.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelAdSizes_AdSizes.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelAdSizes_AdSizes.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelAdSizes_AdSizes.Name = "TabControlPanelAdSizes_AdSizes"
            Me.TabControlPanelAdSizes_AdSizes.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelAdSizes_AdSizes.Size = New System.Drawing.Size(689, 370)
            Me.TabControlPanelAdSizes_AdSizes.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelAdSizes_AdSizes.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelAdSizes_AdSizes.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelAdSizes_AdSizes.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelAdSizes_AdSizes.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelAdSizes_AdSizes.Style.GradientAngle = 90
            Me.TabControlPanelAdSizes_AdSizes.TabIndex = 108
            Me.TabControlPanelAdSizes_AdSizes.TabItem = Me.TabItemTabs_AdSizes
            '
            'DataGridViewAdSizes_AdSizes
            '
            Me.DataGridViewAdSizes_AdSizes.AllowSelectGroupHeaderRow = True
            Me.DataGridViewAdSizes_AdSizes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewAdSizes_AdSizes.AutoUpdateViewCaption = True
            Me.DataGridViewAdSizes_AdSizes.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewAdSizes_AdSizes.ItemDescription = "Ad Size(s)"
            Me.DataGridViewAdSizes_AdSizes.Location = New System.Drawing.Point(9, 30)
            Me.DataGridViewAdSizes_AdSizes.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewAdSizes_AdSizes.ModifyGridRowHeight = False
            Me.DataGridViewAdSizes_AdSizes.MultiSelect = True
            Me.DataGridViewAdSizes_AdSizes.Name = "DataGridViewAdSizes_AdSizes"
            Me.DataGridViewAdSizes_AdSizes.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewAdSizes_AdSizes.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewAdSizes_AdSizes.ShowRowSelectionIfHidden = True
            Me.DataGridViewAdSizes_AdSizes.ShowSelectDeselectAllButtons = False
            Me.DataGridViewAdSizes_AdSizes.Size = New System.Drawing.Size(671, 336)
            Me.DataGridViewAdSizes_AdSizes.TabIndex = 18
            Me.DataGridViewAdSizes_AdSizes.UseEmbeddedNavigator = False
            Me.DataGridViewAdSizes_AdSizes.ViewCaptionHeight = -1
            '
            'LabelAdSizes_TemplateName
            '
            Me.LabelAdSizes_TemplateName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelAdSizes_TemplateName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAdSizes_TemplateName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAdSizes_TemplateName.Location = New System.Drawing.Point(9, 4)
            Me.LabelAdSizes_TemplateName.Name = "LabelAdSizes_TemplateName"
            Me.LabelAdSizes_TemplateName.Size = New System.Drawing.Size(671, 20)
            Me.LabelAdSizes_TemplateName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAdSizes_TemplateName.TabIndex = 17
            '
            'TabItemTabs_AdSizes
            '
            Me.TabItemTabs_AdSizes.AttachedControl = Me.TabControlPanelAdSizes_AdSizes
            Me.TabItemTabs_AdSizes.Name = "TabItemTabs_AdSizes"
            Me.TabItemTabs_AdSizes.Text = "Ad Sizes"
            '
            'TabControlPanelRateTypes_RateTypes
            '
            Me.TabControlPanelRateTypes_RateTypes.Controls.Add(Me.DataGridViewRateTypes_RateTypes)
            Me.TabControlPanelRateTypes_RateTypes.Controls.Add(Me.LabelRateTypes_TemplateName)
            Me.TabControlPanelRateTypes_RateTypes.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelRateTypes_RateTypes.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelRateTypes_RateTypes.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelRateTypes_RateTypes.Name = "TabControlPanelRateTypes_RateTypes"
            Me.TabControlPanelRateTypes_RateTypes.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelRateTypes_RateTypes.Size = New System.Drawing.Size(689, 370)
            Me.TabControlPanelRateTypes_RateTypes.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelRateTypes_RateTypes.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelRateTypes_RateTypes.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelRateTypes_RateTypes.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelRateTypes_RateTypes.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelRateTypes_RateTypes.Style.GradientAngle = 90
            Me.TabControlPanelRateTypes_RateTypes.TabIndex = 127
            Me.TabControlPanelRateTypes_RateTypes.TabItem = Me.TabItemTabs_RateTypes
            '
            'DataGridViewRateTypes_RateTypes
            '
            Me.DataGridViewRateTypes_RateTypes.AllowSelectGroupHeaderRow = True
            Me.DataGridViewRateTypes_RateTypes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRateTypes_RateTypes.AutoUpdateViewCaption = True
            Me.DataGridViewRateTypes_RateTypes.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRateTypes_RateTypes.ItemDescription = "Rate Type(s)"
            Me.DataGridViewRateTypes_RateTypes.Location = New System.Drawing.Point(9, 30)
            Me.DataGridViewRateTypes_RateTypes.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewRateTypes_RateTypes.ModifyGridRowHeight = False
            Me.DataGridViewRateTypes_RateTypes.MultiSelect = True
            Me.DataGridViewRateTypes_RateTypes.Name = "DataGridViewRateTypes_RateTypes"
            Me.DataGridViewRateTypes_RateTypes.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewRateTypes_RateTypes.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewRateTypes_RateTypes.ShowRowSelectionIfHidden = True
            Me.DataGridViewRateTypes_RateTypes.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRateTypes_RateTypes.Size = New System.Drawing.Size(671, 336)
            Me.DataGridViewRateTypes_RateTypes.TabIndex = 18
            Me.DataGridViewRateTypes_RateTypes.UseEmbeddedNavigator = False
            Me.DataGridViewRateTypes_RateTypes.ViewCaptionHeight = -1
            '
            'LabelRateTypes_TemplateName
            '
            Me.LabelRateTypes_TemplateName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelRateTypes_TemplateName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRateTypes_TemplateName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRateTypes_TemplateName.Location = New System.Drawing.Point(9, 4)
            Me.LabelRateTypes_TemplateName.Name = "LabelRateTypes_TemplateName"
            Me.LabelRateTypes_TemplateName.Size = New System.Drawing.Size(671, 20)
            Me.LabelRateTypes_TemplateName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRateTypes_TemplateName.TabIndex = 17
            '
            'TabItemTabs_RateTypes
            '
            Me.TabItemTabs_RateTypes.AttachedControl = Me.TabControlPanelRateTypes_RateTypes
            Me.TabItemTabs_RateTypes.Name = "TabItemTabs_RateTypes"
            Me.TabItemTabs_RateTypes.Text = "Rate Types"
            '
            'TabControlPanelQuarters_Quarters
            '
            Me.TabControlPanelQuarters_Quarters.Controls.Add(Me.DataGridViewQuarters_Quarters)
            Me.TabControlPanelQuarters_Quarters.Controls.Add(Me.LabelQuarters_TemplateName)
            Me.TabControlPanelQuarters_Quarters.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelQuarters_Quarters.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelQuarters_Quarters.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelQuarters_Quarters.Name = "TabControlPanelQuarters_Quarters"
            Me.TabControlPanelQuarters_Quarters.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelQuarters_Quarters.Size = New System.Drawing.Size(689, 370)
            Me.TabControlPanelQuarters_Quarters.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelQuarters_Quarters.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelQuarters_Quarters.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelQuarters_Quarters.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelQuarters_Quarters.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelQuarters_Quarters.Style.GradientAngle = 90
            Me.TabControlPanelQuarters_Quarters.TabIndex = 79
            Me.TabControlPanelQuarters_Quarters.TabItem = Me.TabItemTabs_Quarters
            '
            'DataGridViewQuarters_Quarters
            '
            Me.DataGridViewQuarters_Quarters.AllowSelectGroupHeaderRow = True
            Me.DataGridViewQuarters_Quarters.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewQuarters_Quarters.AutoUpdateViewCaption = True
            Me.DataGridViewQuarters_Quarters.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewQuarters_Quarters.ItemDescription = "Quarter(s)"
            Me.DataGridViewQuarters_Quarters.Location = New System.Drawing.Point(9, 30)
            Me.DataGridViewQuarters_Quarters.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewQuarters_Quarters.ModifyGridRowHeight = False
            Me.DataGridViewQuarters_Quarters.MultiSelect = True
            Me.DataGridViewQuarters_Quarters.Name = "DataGridViewQuarters_Quarters"
            Me.DataGridViewQuarters_Quarters.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewQuarters_Quarters.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewQuarters_Quarters.ShowRowSelectionIfHidden = True
            Me.DataGridViewQuarters_Quarters.ShowSelectDeselectAllButtons = False
            Me.DataGridViewQuarters_Quarters.Size = New System.Drawing.Size(671, 336)
            Me.DataGridViewQuarters_Quarters.TabIndex = 16
            Me.DataGridViewQuarters_Quarters.UseEmbeddedNavigator = False
            Me.DataGridViewQuarters_Quarters.ViewCaptionHeight = -1
            '
            'LabelQuarters_TemplateName
            '
            Me.LabelQuarters_TemplateName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelQuarters_TemplateName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelQuarters_TemplateName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelQuarters_TemplateName.Location = New System.Drawing.Point(9, 4)
            Me.LabelQuarters_TemplateName.Name = "LabelQuarters_TemplateName"
            Me.LabelQuarters_TemplateName.Size = New System.Drawing.Size(671, 20)
            Me.LabelQuarters_TemplateName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelQuarters_TemplateName.TabIndex = 15
            '
            'TabItemTabs_Quarters
            '
            Me.TabItemTabs_Quarters.AttachedControl = Me.TabControlPanelQuarters_Quarters
            Me.TabItemTabs_Quarters.Name = "TabItemTabs_Quarters"
            Me.TabItemTabs_Quarters.Text = "Quarters"
            '
            'TabControlPanelVendors_Vendors
            '
            Me.TabControlPanelVendors_Vendors.Controls.Add(Me.LabelVendors_TemplateName)
            Me.TabControlPanelVendors_Vendors.Controls.Add(Me.DataGridViewVendors_Vendors)
            Me.TabControlPanelVendors_Vendors.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelVendors_Vendors.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelVendors_Vendors.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelVendors_Vendors.Name = "TabControlPanelVendors_Vendors"
            Me.TabControlPanelVendors_Vendors.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelVendors_Vendors.Size = New System.Drawing.Size(689, 370)
            Me.TabControlPanelVendors_Vendors.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelVendors_Vendors.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelVendors_Vendors.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelVendors_Vendors.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelVendors_Vendors.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelVendors_Vendors.Style.GradientAngle = 90
            Me.TabControlPanelVendors_Vendors.TabIndex = 55
            Me.TabControlPanelVendors_Vendors.TabItem = Me.TabItemTabs_Vendors
            '
            'LabelVendors_TemplateName
            '
            Me.LabelVendors_TemplateName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelVendors_TemplateName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelVendors_TemplateName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelVendors_TemplateName.Location = New System.Drawing.Point(9, 4)
            Me.LabelVendors_TemplateName.Name = "LabelVendors_TemplateName"
            Me.LabelVendors_TemplateName.Size = New System.Drawing.Size(671, 20)
            Me.LabelVendors_TemplateName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelVendors_TemplateName.TabIndex = 13
            '
            'DataGridViewVendors_Vendors
            '
            Me.DataGridViewVendors_Vendors.AllowSelectGroupHeaderRow = True
            Me.DataGridViewVendors_Vendors.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewVendors_Vendors.AutoUpdateViewCaption = True
            Me.DataGridViewVendors_Vendors.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewVendors_Vendors.ItemDescription = "Vendor(s)"
            Me.DataGridViewVendors_Vendors.Location = New System.Drawing.Point(9, 30)
            Me.DataGridViewVendors_Vendors.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewVendors_Vendors.ModifyGridRowHeight = False
            Me.DataGridViewVendors_Vendors.MultiSelect = True
            Me.DataGridViewVendors_Vendors.Name = "DataGridViewVendors_Vendors"
            Me.DataGridViewVendors_Vendors.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewVendors_Vendors.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewVendors_Vendors.ShowRowSelectionIfHidden = True
            Me.DataGridViewVendors_Vendors.ShowSelectDeselectAllButtons = False
            Me.DataGridViewVendors_Vendors.Size = New System.Drawing.Size(671, 336)
            Me.DataGridViewVendors_Vendors.TabIndex = 11
            Me.DataGridViewVendors_Vendors.UseEmbeddedNavigator = False
            Me.DataGridViewVendors_Vendors.ViewCaptionHeight = -1
            '
            'TabItemTabs_Vendors
            '
            Me.TabItemTabs_Vendors.AttachedControl = Me.TabControlPanelVendors_Vendors
            Me.TabItemTabs_Vendors.Name = "TabItemTabs_Vendors"
            Me.TabItemTabs_Vendors.Text = "Vendors"
            '
            'MediaTemplateSetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(713, 421)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.TabControlForm_Tabs)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaTemplateSetupForm"
            Me.Text = "Mix and Rate Template"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            CType(Me.TabControlForm_Tabs, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_Tabs.ResumeLayout(False)
            Me.TabControlPanelTemplates_Templates.ResumeLayout(False)
            Me.TabControlPanelOutOfHomeTypes_OutOfHomeTypes.ResumeLayout(False)
            Me.TabControlPanelDayparts_Dayparts.ResumeLayout(False)
            Me.TabControlPanelSpotLengths_SpotLengths.ResumeLayout(False)
            Me.TabControlPanelDemographics_Demographics.ResumeLayout(False)
            Me.TabControlPanelMarkets_Markets.ResumeLayout(False)
            Me.TabControlPanelTactics_Tactics.ResumeLayout(False)
            Me.TabControlPanelAdSizes_AdSizes.ResumeLayout(False)
            Me.TabControlPanelRateTypes_RateTypes.ResumeLayout(False)
            Me.TabControlPanelQuarters_Quarters.ResumeLayout(False)
            Me.TabControlPanelVendors_Vendors.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents TabControlForm_Tabs As WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelVendors_Vendors As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewVendors_Vendors As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents TabItemTabs_Vendors As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelTactics_Tactics As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewTactics_Tactics As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents LabelTactics_TemplateName As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents TabItemTabs_Tactics As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelTemplates_Templates As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewTemplates_Templates As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents TabItemTabs_Templates As DevComponents.DotNetBar.TabItem
        Friend WithEvents LabelVendors_TemplateName As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents ButtonItemActions_Save As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_PlanTemplates As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemPlanTemplates_Manage As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_EstimateTemplates As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemEstimateTemplates_EnterPercent As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents TabControlPanelQuarters_Quarters As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemTabs_Quarters As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelDemographics_Demographics As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemTabs_Demographics As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelSpotLengths_SpotLengths As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemTabs_SpotLengths As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelDayparts_Dayparts As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemTabs_Dayparts As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelMarkets_Markets As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemTabs_Markets As DevComponents.DotNetBar.TabItem
        Friend WithEvents LabelQuarters_TemplateName As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelDemographics_TemplateName As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelSpotLengths_TemplateName As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelDayparts_TemplateName As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelMarkets_TemplateName As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents DataGridViewMarkets_Markets As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewDayparts_Dayparts As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewSpotLengths_SpotLengths As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewDemographics_Demographics As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewQuarters_Quarters As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents TabControlPanelOutOfHomeTypes_OutOfHomeTypes As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewOutOfHomeTypes_OutOfHomeTypes As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents LabelOutOfHomeTypes_TemplateName As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents TabItemTabs_OutOfHomeTypes As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelAdSizes_AdSizes As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewAdSizes_AdSizes As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents LabelAdSizes_TemplateName As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents TabItemTabs_AdSizes As DevComponents.DotNetBar.TabItem
        Friend WithEvents ButtonItemPlanTemplates_Clients As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemEstimateTemplates_Clients As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents TabControlPanelRateTypes_RateTypes As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewRateTypes_RateTypes As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents LabelRateTypes_TemplateName As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents TabItemTabs_RateTypes As DevComponents.DotNetBar.TabItem
        Friend WithEvents ButtonItemEstimateTemplates_EnterRates As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Copy As WinForm.Presentation.Controls.ButtonItem
    End Class

End Namespace

