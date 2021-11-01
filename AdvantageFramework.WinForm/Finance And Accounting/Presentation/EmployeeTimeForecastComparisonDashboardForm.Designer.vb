Namespace FinanceAndAccounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class EmployeeTimeForecastComparisonDashboardForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmployeeTimeForecastComparisonDashboardForm))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_View = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainerView_ETF = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemETF_ExpandAll = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemETF_CollapseAll = New DevComponents.DotNetBar.ButtonItem()
            Me.ItemContainerView_Office = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemOffice_ExpandOfficeLevel = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemOffice_CollapseOfficeLevel = New DevComponents.DotNetBar.ButtonItem()
            Me.ItemContainerView_Client = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemClient_ExpandClientLevel = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemClient_CollapseClientLevel = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainerSearch_LeftSection = New DevComponents.DotNetBar.ItemContainer()
            Me.ItemContainerLeftSection_TopSection = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemTopSection_Month = New DevComponents.DotNetBar.LabelItem()
            Me.ComboBoxItemTopSection_Month = New DevComponents.DotNetBar.ComboBoxItem()
            Me.ItemContainerLeftSection_BottomSection = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemBottomSection_Year = New DevComponents.DotNetBar.LabelItem()
            Me.ComboBoxItemBottomSection_Year = New DevComponents.DotNetBar.ComboBoxItem()
            Me.ItemContainerSearch_RightSection = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemRightSection_ShowForecastedUtilization = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemRightSection_ShowResultsForForecastedProjectsOnly = New DevComponents.DotNetBar.ButtonItem()
            Me.LabelItemActions_Actualized = New DevComponents.DotNetBar.LabelItem()
            Me.LabelItemActions_Forecasted = New DevComponents.DotNetBar.LabelItem()
            Me.TreeListForm_ComparisonDashboard = New DevExpress.XtraTreeList.TreeList()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            CType(Me.TreeListForm_ComparisonDashboard, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_View)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(12, 218)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(942, 98)
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
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 19
            Me.RibbonBarMergeContainerForm_Options.Visible = False
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
            Me.RibbonBarOptions_View.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerView_ETF, Me.ItemContainerView_Office, Me.ItemContainerView_Client})
            Me.RibbonBarOptions_View.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_View.Location = New System.Drawing.Point(707, 0)
            Me.RibbonBarOptions_View.Name = "RibbonBarOptions_View"
            Me.RibbonBarOptions_View.SecurityEnabled = True
            Me.RibbonBarOptions_View.Size = New System.Drawing.Size(299, 98)
            Me.RibbonBarOptions_View.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_View.TabIndex = 1
            Me.RibbonBarOptions_View.Text = "View"
            '
            '
            '
            Me.RibbonBarOptions_View.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_View.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_View.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ItemContainerView_ETF
            '
            '
            '
            '
            Me.ItemContainerView_ETF.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerView_ETF.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerView_ETF.Name = "ItemContainerView_ETF"
            Me.ItemContainerView_ETF.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemETF_ExpandAll, Me.ButtonItemETF_CollapseAll})
            '
            '
            '
            Me.ItemContainerView_ETF.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerView_ETF.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerView_ETF.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemETF_ExpandAll
            '
            Me.ButtonItemETF_ExpandAll.Name = "ButtonItemETF_ExpandAll"
            Me.ButtonItemETF_ExpandAll.Stretch = True
            Me.ButtonItemETF_ExpandAll.SubItemsExpandWidth = 14
            Me.ButtonItemETF_ExpandAll.Text = "Expand All"
            '
            'ButtonItemETF_CollapseAll
            '
            Me.ButtonItemETF_CollapseAll.BeginGroup = True
            Me.ButtonItemETF_CollapseAll.Name = "ButtonItemETF_CollapseAll"
            Me.ButtonItemETF_CollapseAll.SubItemsExpandWidth = 14
            Me.ButtonItemETF_CollapseAll.Text = "Collapse All"
            '
            'ItemContainerView_Office
            '
            '
            '
            '
            Me.ItemContainerView_Office.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerView_Office.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerView_Office.Name = "ItemContainerView_Office"
            Me.ItemContainerView_Office.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemOffice_ExpandOfficeLevel, Me.ButtonItemOffice_CollapseOfficeLevel})
            '
            '
            '
            Me.ItemContainerView_Office.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerView_Office.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerView_Office.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemOffice_ExpandOfficeLevel
            '
            Me.ButtonItemOffice_ExpandOfficeLevel.Name = "ButtonItemOffice_ExpandOfficeLevel"
            Me.ButtonItemOffice_ExpandOfficeLevel.Stretch = True
            Me.ButtonItemOffice_ExpandOfficeLevel.SubItemsExpandWidth = 14
            Me.ButtonItemOffice_ExpandOfficeLevel.Text = "Expand Office Level"
            '
            'ButtonItemOffice_CollapseOfficeLevel
            '
            Me.ButtonItemOffice_CollapseOfficeLevel.BeginGroup = True
            Me.ButtonItemOffice_CollapseOfficeLevel.Name = "ButtonItemOffice_CollapseOfficeLevel"
            Me.ButtonItemOffice_CollapseOfficeLevel.SubItemsExpandWidth = 14
            Me.ButtonItemOffice_CollapseOfficeLevel.Text = "Collapse Office Level"
            '
            'ItemContainerView_Client
            '
            '
            '
            '
            Me.ItemContainerView_Client.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerView_Client.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerView_Client.Name = "ItemContainerView_Client"
            Me.ItemContainerView_Client.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemClient_ExpandClientLevel, Me.ButtonItemClient_CollapseClientLevel})
            '
            '
            '
            Me.ItemContainerView_Client.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerView_Client.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerView_Client.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemClient_ExpandClientLevel
            '
            Me.ButtonItemClient_ExpandClientLevel.Name = "ButtonItemClient_ExpandClientLevel"
            Me.ButtonItemClient_ExpandClientLevel.Stretch = True
            Me.ButtonItemClient_ExpandClientLevel.SubItemsExpandWidth = 14
            Me.ButtonItemClient_ExpandClientLevel.Text = "Expand Client Level"
            '
            'ButtonItemClient_CollapseClientLevel
            '
            Me.ButtonItemClient_CollapseClientLevel.BeginGroup = True
            Me.ButtonItemClient_CollapseClientLevel.Name = "ButtonItemClient_CollapseClientLevel"
            Me.ButtonItemClient_CollapseClientLevel.SubItemsExpandWidth = 14
            Me.ButtonItemClient_CollapseClientLevel.Text = "Collapse Client Level"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerSearch_LeftSection, Me.ItemContainerSearch_RightSection, Me.LabelItemActions_Actualized, Me.LabelItemActions_Forecasted})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(707, 98)
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
            'ItemContainerSearch_LeftSection
            '
            '
            '
            '
            Me.ItemContainerSearch_LeftSection.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSearch_LeftSection.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerSearch_LeftSection.Name = "ItemContainerSearch_LeftSection"
            Me.ItemContainerSearch_LeftSection.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerLeftSection_TopSection, Me.ItemContainerLeftSection_BottomSection})
            '
            '
            '
            Me.ItemContainerSearch_LeftSection.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerSearch_LeftSection.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSearch_LeftSection.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ItemContainerLeftSection_TopSection
            '
            '
            '
            '
            Me.ItemContainerLeftSection_TopSection.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerLeftSection_TopSection.Name = "ItemContainerLeftSection_TopSection"
            Me.ItemContainerLeftSection_TopSection.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemTopSection_Month, Me.ComboBoxItemTopSection_Month})
            '
            '
            '
            Me.ItemContainerLeftSection_TopSection.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerLeftSection_TopSection.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemTopSection_Month
            '
            Me.LabelItemTopSection_Month.Name = "LabelItemTopSection_Month"
            Me.LabelItemTopSection_Month.Text = "Actualize prior to:"
            Me.LabelItemTopSection_Month.Width = 87
            '
            'ComboBoxItemTopSection_Month
            '
            Me.ComboBoxItemTopSection_Month.ComboWidth = 125
            Me.ComboBoxItemTopSection_Month.DropDownHeight = 106
            Me.ComboBoxItemTopSection_Month.Name = "ComboBoxItemTopSection_Month"
            Me.ComboBoxItemTopSection_Month.Text = "ComboBoxItem1"
            '
            'ItemContainerLeftSection_BottomSection
            '
            '
            '
            '
            Me.ItemContainerLeftSection_BottomSection.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerLeftSection_BottomSection.Name = "ItemContainerLeftSection_BottomSection"
            Me.ItemContainerLeftSection_BottomSection.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemBottomSection_Year, Me.ComboBoxItemBottomSection_Year})
            '
            '
            '
            Me.ItemContainerLeftSection_BottomSection.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerLeftSection_BottomSection.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemBottomSection_Year
            '
            Me.LabelItemBottomSection_Year.Name = "LabelItemBottomSection_Year"
            Me.LabelItemBottomSection_Year.Text = "Year: "
            Me.LabelItemBottomSection_Year.Width = 87
            '
            'ComboBoxItemBottomSection_Year
            '
            Me.ComboBoxItemBottomSection_Year.ComboWidth = 125
            Me.ComboBoxItemBottomSection_Year.DropDownHeight = 106
            Me.ComboBoxItemBottomSection_Year.Name = "ComboBoxItemBottomSection_Year"
            Me.ComboBoxItemBottomSection_Year.Text = "ComboBoxItem2"
            '
            'ItemContainerSearch_RightSection
            '
            '
            '
            '
            Me.ItemContainerSearch_RightSection.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSearch_RightSection.BeginGroup = True
            Me.ItemContainerSearch_RightSection.Name = "ItemContainerSearch_RightSection"
            Me.ItemContainerSearch_RightSection.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemRightSection_ShowForecastedUtilization, Me.ButtonItemRightSection_ShowResultsForForecastedProjectsOnly})
            '
            '
            '
            Me.ItemContainerSearch_RightSection.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerSearch_RightSection.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSearch_RightSection.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemRightSection_ShowForecastedUtilization
            '
            Me.ButtonItemRightSection_ShowForecastedUtilization.AutoCheckOnClick = True
            Me.ButtonItemRightSection_ShowForecastedUtilization.BeginGroup = True
            Me.ButtonItemRightSection_ShowForecastedUtilization.Name = "ButtonItemRightSection_ShowForecastedUtilization"
            Me.ButtonItemRightSection_ShowForecastedUtilization.RibbonWordWrap = False
            Me.ButtonItemRightSection_ShowForecastedUtilization.SubItemsExpandWidth = 14
            Me.ButtonItemRightSection_ShowForecastedUtilization.Text = "When actualized, " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "show Forecasted Utilization"
            '
            'ButtonItemRightSection_ShowResultsForForecastedProjectsOnly
            '
            Me.ButtonItemRightSection_ShowResultsForForecastedProjectsOnly.AutoCheckOnClick = True
            Me.ButtonItemRightSection_ShowResultsForForecastedProjectsOnly.BeginGroup = True
            Me.ButtonItemRightSection_ShowResultsForForecastedProjectsOnly.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.TextOnlyAlways
            Me.ButtonItemRightSection_ShowResultsForForecastedProjectsOnly.Name = "ButtonItemRightSection_ShowResultsForForecastedProjectsOnly"
            Me.ButtonItemRightSection_ShowResultsForForecastedProjectsOnly.RibbonWordWrap = False
            Me.ButtonItemRightSection_ShowResultsForForecastedProjectsOnly.SubItemsExpandWidth = 14
            Me.ButtonItemRightSection_ShowResultsForForecastedProjectsOnly.Text = "Show results for " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Forecasted Projects only"
            '
            'LabelItemActions_Actualized
            '
            Me.LabelItemActions_Actualized.BackColor = System.Drawing.Color.White
            Me.LabelItemActions_Actualized.BeginGroup = True
            Me.LabelItemActions_Actualized.Name = "LabelItemActions_Actualized"
            Me.LabelItemActions_Actualized.Text = "Actualized"
            '
            'LabelItemActions_Forecasted
            '
            Me.LabelItemActions_Forecasted.BackColor = System.Drawing.Color.LightYellow
            Me.LabelItemActions_Forecasted.Name = "LabelItemActions_Forecasted"
            Me.LabelItemActions_Forecasted.Text = "Forecasted"
            '
            'TreeListForm_ComparisonDashboard
            '
            Me.TreeListForm_ComparisonDashboard.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TreeListForm_ComparisonDashboard.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.TreeListForm_ComparisonDashboard.KeyFieldName = "OfficeCode"
            Me.TreeListForm_ComparisonDashboard.Location = New System.Drawing.Point(12, 12)
            Me.TreeListForm_ComparisonDashboard.Name = "TreeListForm_ComparisonDashboard"
            Me.TreeListForm_ComparisonDashboard.OptionsBehavior.Editable = False
            Me.TreeListForm_ComparisonDashboard.OptionsBehavior.PopulateServiceColumns = True
            Me.TreeListForm_ComparisonDashboard.OptionsMenu.EnableColumnMenu = False
            Me.TreeListForm_ComparisonDashboard.OptionsMenu.EnableFooterMenu = False
            Me.TreeListForm_ComparisonDashboard.OptionsSelection.EnableAppearanceFocusedRow = False
            Me.TreeListForm_ComparisonDashboard.OptionsView.AutoWidth = False
            Me.TreeListForm_ComparisonDashboard.OptionsView.BestFitNodes = DevExpress.XtraTreeList.TreeListBestFitNodes.Visible
            Me.TreeListForm_ComparisonDashboard.ParentFieldName = "ParentOfficeCode"
            Me.TreeListForm_ComparisonDashboard.RootValue = ""
            Me.TreeListForm_ComparisonDashboard.Size = New System.Drawing.Size(942, 510)
            Me.TreeListForm_ComparisonDashboard.TabIndex = 20
            '
            'EmployeeTimeForecastComparisonDashboardForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(966, 534)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.TreeListForm_ComparisonDashboard)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "EmployeeTimeForecastComparisonDashboardForm"
            Me.Text = "Comparison Dashboard"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            CType(Me.TreeListForm_ComparisonDashboard, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents RibbonBarOptions_View As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ItemContainerView_ETF As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemETF_ExpandAll As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemETF_CollapseAll As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ItemContainerView_Office As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemOffice_ExpandOfficeLevel As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemOffice_CollapseOfficeLevel As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ItemContainerView_Client As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemClient_ExpandClientLevel As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemClient_CollapseClientLevel As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents TreeListForm_ComparisonDashboard As DevExpress.XtraTreeList.TreeList
        Friend WithEvents ItemContainerSearch_LeftSection As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ItemContainerLeftSection_TopSection As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemTopSection_Month As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ComboBoxItemTopSection_Month As DevComponents.DotNetBar.ComboBoxItem
        Friend WithEvents ItemContainerLeftSection_BottomSection As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemBottomSection_Year As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ComboBoxItemBottomSection_Year As DevComponents.DotNetBar.ComboBoxItem
        Friend WithEvents ItemContainerSearch_RightSection As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemRightSection_ShowForecastedUtilization As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemRightSection_ShowResultsForForecastedProjectsOnly As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents LabelItemActions_Actualized As DevComponents.DotNetBar.LabelItem
        Friend WithEvents LabelItemActions_Forecasted As DevComponents.DotNetBar.LabelItem
    End Class

End Namespace