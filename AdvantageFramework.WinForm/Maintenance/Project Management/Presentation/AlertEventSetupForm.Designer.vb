Namespace Maintenance.ProjectManagement.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AlertEventSetupForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AlertEventSetupForm))
            Me.PivotGridForm_AlertEvents = New AdvantageFramework.WinForm.Presentation.Controls.PivotGridControl()
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_AlertCategory = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainerCategory_Check = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemCategoryCheck_CheckAll = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemCategoryCheck_UncheckAll = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_AlertGroup = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainerAlertGroup_Check = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemCheck_CheckAll = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemCheck_UncheckAll = New DevComponents.DotNetBar.ButtonItem()
            Me.PivotGridForm_AlertEventSettings = New AdvantageFramework.WinForm.Presentation.Controls.PivotGridControl()
            Me.RibbonBarOptions_View = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemView_Inactive = New DevComponents.DotNetBar.ButtonItem()
            CType(Me.PivotGridForm_AlertEvents, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            CType(Me.PivotGridForm_AlertEventSettings, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'PivotGridForm_AlertEvents
            '
            Me.PivotGridForm_AlertEvents.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PivotGridForm_AlertEvents.Location = New System.Drawing.Point(12, 12)
            Me.PivotGridForm_AlertEvents.Name = "PivotGridForm_AlertEvents"
            Me.PivotGridForm_AlertEvents.OptionsCustomization.AllowCustomizationForm = False
            Me.PivotGridForm_AlertEvents.OptionsCustomization.AllowDrag = False
            Me.PivotGridForm_AlertEvents.OptionsCustomization.AllowDragInCustomizationForm = False
            Me.PivotGridForm_AlertEvents.OptionsCustomization.AllowFilter = False
            Me.PivotGridForm_AlertEvents.OptionsCustomization.AllowFilterBySummary = False
            Me.PivotGridForm_AlertEvents.OptionsCustomization.AllowResizing = False
            Me.PivotGridForm_AlertEvents.OptionsCustomization.AllowSort = False
            Me.PivotGridForm_AlertEvents.OptionsCustomization.AllowSortBySummary = False
            Me.PivotGridForm_AlertEvents.OptionsCustomization.AllowSortInCustomizationForm = True
            Me.PivotGridForm_AlertEvents.OptionsView.ShowColumnGrandTotals = False
            Me.PivotGridForm_AlertEvents.OptionsView.ShowColumnHeaders = False
            Me.PivotGridForm_AlertEvents.OptionsView.ShowColumnTotals = False
            Me.PivotGridForm_AlertEvents.OptionsView.ShowDataHeaders = False
            Me.PivotGridForm_AlertEvents.OptionsView.ShowFilterHeaders = False
            Me.PivotGridForm_AlertEvents.OptionsView.ShowRowGrandTotals = False
            Me.PivotGridForm_AlertEvents.OptionsView.ShowRowTotals = False
            Me.PivotGridForm_AlertEvents.RetrieveFieldsOnLoadDataSource = True
            Me.PivotGridForm_AlertEvents.Size = New System.Drawing.Size(707, 354)
            Me.PivotGridForm_AlertEvents.TabIndex = 1
            Me.PivotGridForm_AlertEvents.WriteEditValueToAllDataSourceItems = False
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_AlertCategory)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_AlertGroup)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_View)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(199, 183)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(332, 95)
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
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 4
            Me.RibbonBarMergeContainerForm_Options.Visible = False
            '
            'RibbonBarOptions_AlertCategory
            '
            Me.RibbonBarOptions_AlertCategory.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_AlertCategory.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_AlertCategory.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_AlertCategory.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_AlertCategory.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_AlertCategory.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerCategory_Check})
            Me.RibbonBarOptions_AlertCategory.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_AlertCategory.Location = New System.Drawing.Point(154, 0)
            Me.RibbonBarOptions_AlertCategory.Name = "RibbonBarOptions_AlertCategory"
            Me.RibbonBarOptions_AlertCategory.Size = New System.Drawing.Size(78, 95)
            Me.RibbonBarOptions_AlertCategory.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_AlertCategory.TabIndex = 1
            Me.RibbonBarOptions_AlertCategory.Text = "Alert Category"
            '
            '
            '
            Me.RibbonBarOptions_AlertCategory.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_AlertCategory.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_AlertCategory.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ItemContainerCategory_Check
            '
            '
            '
            '
            Me.ItemContainerCategory_Check.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerCategory_Check.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerCategory_Check.Name = "ItemContainerCategory_Check"
            Me.ItemContainerCategory_Check.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemCategoryCheck_CheckAll, Me.ButtonItemCategoryCheck_UncheckAll})
            '
            '
            '
            Me.ItemContainerCategory_Check.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerCategory_Check.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemCategoryCheck_CheckAll
            '
            Me.ButtonItemCategoryCheck_CheckAll.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemCategoryCheck_CheckAll.Name = "ButtonItemCategoryCheck_CheckAll"
            Me.ButtonItemCategoryCheck_CheckAll.Stretch = True
            Me.ButtonItemCategoryCheck_CheckAll.SubItemsExpandWidth = 14
            Me.ButtonItemCategoryCheck_CheckAll.Text = "Check All"
            '
            'ButtonItemCategoryCheck_UncheckAll
            '
            Me.ButtonItemCategoryCheck_UncheckAll.BeginGroup = True
            Me.ButtonItemCategoryCheck_UncheckAll.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemCategoryCheck_UncheckAll.Name = "ButtonItemCategoryCheck_UncheckAll"
            Me.ButtonItemCategoryCheck_UncheckAll.SubItemsExpandWidth = 14
            Me.ButtonItemCategoryCheck_UncheckAll.Text = "Uncheck All"
            '
            'RibbonBarOptions_AlertGroup
            '
            Me.RibbonBarOptions_AlertGroup.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_AlertGroup.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_AlertGroup.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_AlertGroup.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_AlertGroup.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_AlertGroup.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerAlertGroup_Check})
            Me.RibbonBarOptions_AlertGroup.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_AlertGroup.Location = New System.Drawing.Point(76, 0)
            Me.RibbonBarOptions_AlertGroup.Name = "RibbonBarOptions_AlertGroup"
            Me.RibbonBarOptions_AlertGroup.Size = New System.Drawing.Size(78, 95)
            Me.RibbonBarOptions_AlertGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_AlertGroup.TabIndex = 0
            Me.RibbonBarOptions_AlertGroup.Text = "Alert Group"
            '
            '
            '
            Me.RibbonBarOptions_AlertGroup.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_AlertGroup.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_AlertGroup.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ItemContainerAlertGroup_Check
            '
            '
            '
            '
            Me.ItemContainerAlertGroup_Check.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerAlertGroup_Check.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerAlertGroup_Check.Name = "ItemContainerAlertGroup_Check"
            Me.ItemContainerAlertGroup_Check.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemCheck_CheckAll, Me.ButtonItemCheck_UncheckAll})
            '
            '
            '
            Me.ItemContainerAlertGroup_Check.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerAlertGroup_Check.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemCheck_CheckAll
            '
            Me.ButtonItemCheck_CheckAll.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemCheck_CheckAll.Name = "ButtonItemCheck_CheckAll"
            Me.ButtonItemCheck_CheckAll.Stretch = True
            Me.ButtonItemCheck_CheckAll.SubItemsExpandWidth = 14
            Me.ButtonItemCheck_CheckAll.Text = "Check All"
            '
            'ButtonItemCheck_UncheckAll
            '
            Me.ButtonItemCheck_UncheckAll.BeginGroup = True
            Me.ButtonItemCheck_UncheckAll.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemCheck_UncheckAll.Name = "ButtonItemCheck_UncheckAll"
            Me.ButtonItemCheck_UncheckAll.SubItemsExpandWidth = 14
            Me.ButtonItemCheck_UncheckAll.Text = "Uncheck All"
            '
            'PivotGridForm_AlertEventSettings
            '
            Me.PivotGridForm_AlertEventSettings.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PivotGridForm_AlertEventSettings.Location = New System.Drawing.Point(12, 372)
            Me.PivotGridForm_AlertEventSettings.Name = "PivotGridForm_AlertEventSettings"
            Me.PivotGridForm_AlertEventSettings.OptionsCustomization.AllowCustomizationForm = False
            Me.PivotGridForm_AlertEventSettings.OptionsCustomization.AllowDrag = False
            Me.PivotGridForm_AlertEventSettings.OptionsCustomization.AllowDragInCustomizationForm = False
            Me.PivotGridForm_AlertEventSettings.OptionsCustomization.AllowFilter = False
            Me.PivotGridForm_AlertEventSettings.OptionsCustomization.AllowFilterBySummary = False
            Me.PivotGridForm_AlertEventSettings.OptionsCustomization.AllowResizing = False
            Me.PivotGridForm_AlertEventSettings.OptionsCustomization.AllowSort = False
            Me.PivotGridForm_AlertEventSettings.OptionsCustomization.AllowSortBySummary = False
            Me.PivotGridForm_AlertEventSettings.OptionsCustomization.AllowSortInCustomizationForm = True
            Me.PivotGridForm_AlertEventSettings.OptionsView.ShowColumnGrandTotals = False
            Me.PivotGridForm_AlertEventSettings.OptionsView.ShowColumnHeaders = False
            Me.PivotGridForm_AlertEventSettings.OptionsView.ShowColumnTotals = False
            Me.PivotGridForm_AlertEventSettings.OptionsView.ShowDataHeaders = False
            Me.PivotGridForm_AlertEventSettings.OptionsView.ShowFilterHeaders = False
            Me.PivotGridForm_AlertEventSettings.OptionsView.ShowRowGrandTotals = False
            Me.PivotGridForm_AlertEventSettings.OptionsView.ShowRowHeaders = False
            Me.PivotGridForm_AlertEventSettings.OptionsView.ShowRowTotals = False
            Me.PivotGridForm_AlertEventSettings.RetrieveFieldsOnLoadDataSource = True
            Me.PivotGridForm_AlertEventSettings.Size = New System.Drawing.Size(707, 76)
            Me.PivotGridForm_AlertEventSettings.TabIndex = 5
            Me.PivotGridForm_AlertEventSettings.WriteEditValueToAllDataSourceItems = False
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
            Me.RibbonBarOptions_View.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemView_Inactive})
            Me.RibbonBarOptions_View.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_View.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_View.Name = "RibbonBarOptions_View"
            Me.RibbonBarOptions_View.Size = New System.Drawing.Size(76, 95)
            Me.RibbonBarOptions_View.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_View.TabIndex = 7
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
            'ButtonItemView_Inactive
            '
            Me.ButtonItemView_Inactive.AutoCheckOnClick = True
            Me.ButtonItemView_Inactive.BeginGroup = True
            Me.ButtonItemView_Inactive.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemView_Inactive.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemView_Inactive.Name = "ButtonItemView_Inactive"
            Me.ButtonItemView_Inactive.RibbonWordWrap = False
            Me.ButtonItemView_Inactive.Stretch = True
            Me.ButtonItemView_Inactive.SubItemsExpandWidth = 14
            Me.ButtonItemView_Inactive.Text = "Inactive"
            '
            'AlertEventSetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(731, 460)
            Me.Controls.Add(Me.PivotGridForm_AlertEventSettings)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.PivotGridForm_AlertEvents)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "AlertEventSetupForm"
            Me.Text = "Alert Event Settings"
            CType(Me.PivotGridForm_AlertEvents, System.ComponentModel.ISupportInitialize).EndInit()
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            CType(Me.PivotGridForm_AlertEventSettings, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents PivotGridForm_AlertEvents As AdvantageFramework.WinForm.Presentation.Controls.PivotGridControl
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_AlertGroup As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents RibbonBarOptions_AlertCategory As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ItemContainerCategory_Check As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemCategoryCheck_CheckAll As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemCategoryCheck_UncheckAll As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ItemContainerAlertGroup_Check As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemCheck_CheckAll As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemCheck_UncheckAll As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents PivotGridForm_AlertEventSettings As AdvantageFramework.WinForm.Presentation.Controls.PivotGridControl
        Friend WithEvents RibbonBarOptions_View As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemView_Inactive As DevComponents.DotNetBar.ButtonItem
    End Class

End Namespace

