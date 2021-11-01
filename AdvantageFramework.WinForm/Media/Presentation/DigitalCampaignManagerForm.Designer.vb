Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class DigitalCampaignManagerForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DigitalCampaignManagerForm))
            Me.DataGridViewForm_OpenPlanEstimates = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_GridOptions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemGrid_ChooseColumns = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemGrid_RestoreDefaults = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Include = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainer1 = New DevComponents.DotNetBar.ItemContainer()
            Me.CheckBoxItemInclude_Internet = New DevComponents.DotNetBar.CheckBoxItem()
            Me.CheckBoxItemInclude_Magazine = New DevComponents.DotNetBar.CheckBoxItem()
            Me.CheckBoxItemInclude_Newspaper = New DevComponents.DotNetBar.CheckBoxItem()
            Me.ItemContainer2 = New DevComponents.DotNetBar.ItemContainer()
            Me.CheckBoxItemInclude_OutOfHome = New DevComponents.DotNetBar.CheckBoxItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Review = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Refresh = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.SuspendLayout()
            '
            'DataGridViewForm_OpenPlanEstimates
            '
            Me.DataGridViewForm_OpenPlanEstimates.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_OpenPlanEstimates.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_OpenPlanEstimates.AutoUpdateViewCaption = True
            Me.DataGridViewForm_OpenPlanEstimates.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_OpenPlanEstimates.ItemDescription = "Open Plan Estimate(s)"
            Me.DataGridViewForm_OpenPlanEstimates.Location = New System.Drawing.Point(12, 13)
            Me.DataGridViewForm_OpenPlanEstimates.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewForm_OpenPlanEstimates.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewForm_OpenPlanEstimates.ModifyGridRowHeight = False
            Me.DataGridViewForm_OpenPlanEstimates.MultiSelect = False
            Me.DataGridViewForm_OpenPlanEstimates.Name = "DataGridViewForm_OpenPlanEstimates"
            Me.DataGridViewForm_OpenPlanEstimates.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_OpenPlanEstimates.SelectRowsWhenSelectDeselectAllButtonClicked = False
            Me.DataGridViewForm_OpenPlanEstimates.ShowRowSelectionIfHidden = True
            Me.DataGridViewForm_OpenPlanEstimates.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_OpenPlanEstimates.Size = New System.Drawing.Size(789, 395)
            Me.DataGridViewForm_OpenPlanEstimates.TabIndex = 8
            Me.DataGridViewForm_OpenPlanEstimates.UseEmbeddedNavigator = False
            Me.DataGridViewForm_OpenPlanEstimates.ViewCaptionHeight = -1
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_GridOptions)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Include)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(94, 2)
            Me.RibbonBarMergeContainerForm_Options.MergeRibbonGroupName = "RibbonTabGroupDynamicReport"
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(689, 98)
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
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 10
            Me.RibbonBarMergeContainerForm_Options.Visible = False
            '
            'RibbonBarOptions_GridOptions
            '
            Me.RibbonBarOptions_GridOptions.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_GridOptions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_GridOptions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_GridOptions.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_GridOptions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_GridOptions.DragDropSupport = True
            Me.RibbonBarOptions_GridOptions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemGrid_ChooseColumns, Me.ButtonItemGrid_RestoreDefaults})
            Me.RibbonBarOptions_GridOptions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_GridOptions.Location = New System.Drawing.Point(332, 0)
            Me.RibbonBarOptions_GridOptions.Name = "RibbonBarOptions_GridOptions"
            Me.RibbonBarOptions_GridOptions.SecurityEnabled = True
            Me.RibbonBarOptions_GridOptions.Size = New System.Drawing.Size(253, 98)
            Me.RibbonBarOptions_GridOptions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_GridOptions.TabIndex = 38
            Me.RibbonBarOptions_GridOptions.Text = "Grid Options"
            '
            '
            '
            Me.RibbonBarOptions_GridOptions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_GridOptions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_GridOptions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemGrid_ChooseColumns
            '
            Me.ButtonItemGrid_ChooseColumns.AutoCheckOnClick = True
            Me.ButtonItemGrid_ChooseColumns.BeginGroup = True
            Me.ButtonItemGrid_ChooseColumns.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemGrid_ChooseColumns.Name = "ButtonItemGrid_ChooseColumns"
            Me.ButtonItemGrid_ChooseColumns.RibbonWordWrap = False
            Me.ButtonItemGrid_ChooseColumns.SecurityEnabled = True
            Me.ButtonItemGrid_ChooseColumns.SubItemsExpandWidth = 14
            Me.ButtonItemGrid_ChooseColumns.Text = "Choose Columns"
            '
            'ButtonItemGrid_RestoreDefaults
            '
            Me.ButtonItemGrid_RestoreDefaults.BeginGroup = True
            Me.ButtonItemGrid_RestoreDefaults.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemGrid_RestoreDefaults.Name = "ButtonItemGrid_RestoreDefaults"
            Me.ButtonItemGrid_RestoreDefaults.RibbonWordWrap = False
            Me.ButtonItemGrid_RestoreDefaults.SecurityEnabled = True
            Me.ButtonItemGrid_RestoreDefaults.SubItemsExpandWidth = 14
            Me.ButtonItemGrid_RestoreDefaults.Text = "Restore Defaults"
            '
            'RibbonBarOptions_Include
            '
            Me.RibbonBarOptions_Include.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Include.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Include.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Include.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Include.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Include.DragDropSupport = True
            Me.RibbonBarOptions_Include.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer1, Me.ItemContainer2})
            Me.RibbonBarOptions_Include.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Include.Location = New System.Drawing.Point(110, 0)
            Me.RibbonBarOptions_Include.Name = "RibbonBarOptions_Include"
            Me.RibbonBarOptions_Include.SecurityEnabled = True
            Me.RibbonBarOptions_Include.Size = New System.Drawing.Size(222, 98)
            Me.RibbonBarOptions_Include.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Include.TabIndex = 39
            Me.RibbonBarOptions_Include.Text = "Include"
            '
            '
            '
            Me.RibbonBarOptions_Include.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Include.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Include.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ItemContainer1
            '
            '
            '
            '
            Me.ItemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainer1.Name = "ItemContainer1"
            Me.ItemContainer1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.CheckBoxItemInclude_Internet, Me.CheckBoxItemInclude_Magazine, Me.CheckBoxItemInclude_Newspaper})
            '
            '
            '
            Me.ItemContainer1.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'CheckBoxItemInclude_Internet
            '
            Me.CheckBoxItemInclude_Internet.Name = "CheckBoxItemInclude_Internet"
            Me.CheckBoxItemInclude_Internet.Text = "Internet"
            '
            'CheckBoxItemInclude_Magazine
            '
            Me.CheckBoxItemInclude_Magazine.Name = "CheckBoxItemInclude_Magazine"
            Me.CheckBoxItemInclude_Magazine.Text = "Magazine"
            '
            'CheckBoxItemInclude_Newspaper
            '
            Me.CheckBoxItemInclude_Newspaper.Name = "CheckBoxItemInclude_Newspaper"
            Me.CheckBoxItemInclude_Newspaper.Text = "Newspaper"
            '
            'ItemContainer2
            '
            '
            '
            '
            Me.ItemContainer2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer2.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainer2.Name = "ItemContainer2"
            Me.ItemContainer2.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.CheckBoxItemInclude_OutOfHome})
            '
            '
            '
            Me.ItemContainer2.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainer2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'CheckBoxItemInclude_OutOfHome
            '
            Me.CheckBoxItemInclude_OutOfHome.Name = "CheckBoxItemInclude_OutOfHome"
            Me.CheckBoxItemInclude_OutOfHome.Text = "Out of Home"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Review, Me.ButtonItemActions_Refresh})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(110, 98)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 37
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
            'ButtonItemActions_Review
            '
            Me.ButtonItemActions_Review.BeginGroup = True
            Me.ButtonItemActions_Review.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Review.Name = "ButtonItemActions_Review"
            Me.ButtonItemActions_Review.RibbonWordWrap = False
            Me.ButtonItemActions_Review.SecurityEnabled = True
            Me.ButtonItemActions_Review.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Review.Text = "Review"
            '
            'ButtonItemActions_Refresh
            '
            Me.ButtonItemActions_Refresh.BeginGroup = True
            Me.ButtonItemActions_Refresh.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Refresh.Name = "ButtonItemActions_Refresh"
            Me.ButtonItemActions_Refresh.RibbonWordWrap = False
            Me.ButtonItemActions_Refresh.SecurityEnabled = True
            Me.ButtonItemActions_Refresh.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Refresh.Text = "Refresh"
            '
            'DigitalCampaignManagerForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(814, 421)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.DataGridViewForm_OpenPlanEstimates)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "DigitalCampaignManagerForm"
            Me.Text = "Digital and Media Campaign Manager"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewForm_OpenPlanEstimates As WinForm.MVC.Presentation.Controls.DataGridView
        Private WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Private WithEvents RibbonBarOptions_Actions As WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemActions_Review As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_GridOptions As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemGrid_ChooseColumns As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemGrid_RestoreDefaults As WinForm.Presentation.Controls.ButtonItem
        Private WithEvents RibbonBarOptions_Include As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ItemContainer1 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents CheckBoxItemInclude_Internet As DevComponents.DotNetBar.CheckBoxItem
        Friend WithEvents CheckBoxItemInclude_Magazine As DevComponents.DotNetBar.CheckBoxItem
        Friend WithEvents CheckBoxItemInclude_Newspaper As DevComponents.DotNetBar.CheckBoxItem
        Friend WithEvents ItemContainer2 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents CheckBoxItemInclude_OutOfHome As DevComponents.DotNetBar.CheckBoxItem
        Private WithEvents ButtonItemActions_Refresh As WinForm.Presentation.Controls.ButtonItem
    End Class

End Namespace
