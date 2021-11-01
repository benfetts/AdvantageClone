Namespace Security.Setup.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class UserDefinedReportAccessForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserDefinedReportAccessForm))
            Me.DataGridViewForm_GroupAccess = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.DataGridViewForm_UserAccess = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_GroupActions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainerGroupActions_GroupBlocking = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemGroupBlocking_BlockAll = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemGroupBlocking_UnblockAll = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_UserActions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainerUserActions_UserBlocking = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemUserBlocking_BlockAll = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemUserBlocking_UnblockAll = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_ShowBy = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemShowBy_All = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemShowBy_AllBlocked = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemShowBy_AllUnblocked = New DevComponents.DotNetBar.ButtonItem()
            Me.DataGridViewForm_UserDefinedReports = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.SuspendLayout()
            '
            'DataGridViewForm_GroupAccess
            '
            Me.DataGridViewForm_GroupAccess.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_GroupAccess.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_GroupAccess.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_GroupAccess.AutoFilterLookupColumns = False
            Me.DataGridViewForm_GroupAccess.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_GroupAccess.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_GroupAccess.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_GroupAccess.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_GroupAccess.ItemDescription = "Group Access"
            Me.DataGridViewForm_GroupAccess.Location = New System.Drawing.Point(405, 12)
            Me.DataGridViewForm_GroupAccess.MultiSelect = True
            Me.DataGridViewForm_GroupAccess.Name = "DataGridViewForm_GroupAccess"
            Me.DataGridViewForm_GroupAccess.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_GroupAccess.RunStandardValidation = True
            Me.DataGridViewForm_GroupAccess.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_GroupAccess.Size = New System.Drawing.Size(755, 291)
            Me.DataGridViewForm_GroupAccess.TabIndex = 7
            Me.DataGridViewForm_GroupAccess.UseEmbeddedNavigator = False
            Me.DataGridViewForm_GroupAccess.ViewCaptionHeight = -1
            '
            'DataGridViewForm_UserAccess
            '
            Me.DataGridViewForm_UserAccess.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_UserAccess.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_UserAccess.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_UserAccess.AutoFilterLookupColumns = False
            Me.DataGridViewForm_UserAccess.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_UserAccess.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_UserAccess.DataSource = Nothing
            Me.DataGridViewForm_UserAccess.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_UserAccess.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_UserAccess.ItemDescription = "User Access"
            Me.DataGridViewForm_UserAccess.Location = New System.Drawing.Point(405, 309)
            Me.DataGridViewForm_UserAccess.MultiSelect = True
            Me.DataGridViewForm_UserAccess.Name = "DataGridViewForm_UserAccess"
            Me.DataGridViewForm_UserAccess.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_UserAccess.RunStandardValidation = True
            Me.DataGridViewForm_UserAccess.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_UserAccess.Size = New System.Drawing.Size(755, 306)
            Me.DataGridViewForm_UserAccess.TabIndex = 8
            Me.DataGridViewForm_UserAccess.UseEmbeddedNavigator = False
            Me.DataGridViewForm_UserAccess.ViewCaptionHeight = -1
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_GroupActions)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_UserActions)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_ShowBy)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(720, 264)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(269, 98)
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
            'RibbonBarOptions_GroupActions
            '
            Me.RibbonBarOptions_GroupActions.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_GroupActions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_GroupActions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_GroupActions.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_GroupActions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_GroupActions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerGroupActions_GroupBlocking})
            Me.RibbonBarOptions_GroupActions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_GroupActions.Location = New System.Drawing.Point(155, 0)
            Me.RibbonBarOptions_GroupActions.MinimumSize = New System.Drawing.Size(80, 0)
            Me.RibbonBarOptions_GroupActions.Name = "RibbonBarOptions_GroupActions"
            Me.RibbonBarOptions_GroupActions.Size = New System.Drawing.Size(80, 98)
            Me.RibbonBarOptions_GroupActions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_GroupActions.TabIndex = 7
            Me.RibbonBarOptions_GroupActions.Text = "Group Actions"
            '
            '
            '
            Me.RibbonBarOptions_GroupActions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_GroupActions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_GroupActions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ItemContainerGroupActions_GroupBlocking
            '
            '
            '
            '
            Me.ItemContainerGroupActions_GroupBlocking.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerGroupActions_GroupBlocking.BeginGroup = True
            Me.ItemContainerGroupActions_GroupBlocking.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerGroupActions_GroupBlocking.Name = "ItemContainerGroupActions_GroupBlocking"
            Me.ItemContainerGroupActions_GroupBlocking.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemGroupBlocking_BlockAll, Me.ButtonItemGroupBlocking_UnblockAll})
            '
            '
            '
            Me.ItemContainerGroupActions_GroupBlocking.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemGroupBlocking_BlockAll
            '
            Me.ButtonItemGroupBlocking_BlockAll.Name = "ButtonItemGroupBlocking_BlockAll"
            Me.ButtonItemGroupBlocking_BlockAll.SubItemsExpandWidth = 14
            Me.ButtonItemGroupBlocking_BlockAll.Text = "Block All"
            '
            'ButtonItemGroupBlocking_UnblockAll
            '
            Me.ButtonItemGroupBlocking_UnblockAll.BeginGroup = True
            Me.ButtonItemGroupBlocking_UnblockAll.Name = "ButtonItemGroupBlocking_UnblockAll"
            Me.ButtonItemGroupBlocking_UnblockAll.SubItemsExpandWidth = 14
            Me.ButtonItemGroupBlocking_UnblockAll.Text = "Unblock All"
            '
            'RibbonBarOptions_UserActions
            '
            Me.RibbonBarOptions_UserActions.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_UserActions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_UserActions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_UserActions.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_UserActions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_UserActions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerUserActions_UserBlocking})
            Me.RibbonBarOptions_UserActions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_UserActions.Location = New System.Drawing.Point(83, 0)
            Me.RibbonBarOptions_UserActions.Name = "RibbonBarOptions_UserActions"
            Me.RibbonBarOptions_UserActions.Size = New System.Drawing.Size(72, 98)
            Me.RibbonBarOptions_UserActions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_UserActions.TabIndex = 6
            Me.RibbonBarOptions_UserActions.Text = "User Actions"
            '
            '
            '
            Me.RibbonBarOptions_UserActions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_UserActions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_UserActions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ItemContainerUserActions_UserBlocking
            '
            '
            '
            '
            Me.ItemContainerUserActions_UserBlocking.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerUserActions_UserBlocking.BeginGroup = True
            Me.ItemContainerUserActions_UserBlocking.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerUserActions_UserBlocking.Name = "ItemContainerUserActions_UserBlocking"
            Me.ItemContainerUserActions_UserBlocking.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemUserBlocking_BlockAll, Me.ButtonItemUserBlocking_UnblockAll})
            '
            '
            '
            Me.ItemContainerUserActions_UserBlocking.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemUserBlocking_BlockAll
            '
            Me.ButtonItemUserBlocking_BlockAll.Name = "ButtonItemUserBlocking_BlockAll"
            Me.ButtonItemUserBlocking_BlockAll.SubItemsExpandWidth = 14
            Me.ButtonItemUserBlocking_BlockAll.Text = "Block All"
            '
            'ButtonItemUserBlocking_UnblockAll
            '
            Me.ButtonItemUserBlocking_UnblockAll.BeginGroup = True
            Me.ButtonItemUserBlocking_UnblockAll.Name = "ButtonItemUserBlocking_UnblockAll"
            Me.ButtonItemUserBlocking_UnblockAll.SubItemsExpandWidth = 14
            Me.ButtonItemUserBlocking_UnblockAll.Text = "Unblock All"
            '
            'RibbonBarOptions_ShowBy
            '
            Me.RibbonBarOptions_ShowBy.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_ShowBy.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ShowBy.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ShowBy.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_ShowBy.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_ShowBy.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemShowBy_All, Me.ButtonItemShowBy_AllBlocked, Me.ButtonItemShowBy_AllUnblocked})
            Me.RibbonBarOptions_ShowBy.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.RibbonBarOptions_ShowBy.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_ShowBy.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_ShowBy.Name = "RibbonBarOptions_ShowBy"
            Me.RibbonBarOptions_ShowBy.Size = New System.Drawing.Size(83, 98)
            Me.RibbonBarOptions_ShowBy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_ShowBy.TabIndex = 4
            Me.RibbonBarOptions_ShowBy.Text = "Show By"
            '
            '
            '
            Me.RibbonBarOptions_ShowBy.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ShowBy.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ShowBy.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemShowBy_All
            '
            Me.ButtonItemShowBy_All.AutoCheckOnClick = True
            Me.ButtonItemShowBy_All.Checked = True
            Me.ButtonItemShowBy_All.Name = "ButtonItemShowBy_All"
            Me.ButtonItemShowBy_All.OptionGroup = "ShowBy"
            Me.ButtonItemShowBy_All.Stretch = True
            Me.ButtonItemShowBy_All.SubItemsExpandWidth = 14
            Me.ButtonItemShowBy_All.Text = "All"
            '
            'ButtonItemShowBy_AllBlocked
            '
            Me.ButtonItemShowBy_AllBlocked.AutoCheckOnClick = True
            Me.ButtonItemShowBy_AllBlocked.BeginGroup = True
            Me.ButtonItemShowBy_AllBlocked.Name = "ButtonItemShowBy_AllBlocked"
            Me.ButtonItemShowBy_AllBlocked.OptionGroup = "ShowBy"
            Me.ButtonItemShowBy_AllBlocked.SubItemsExpandWidth = 14
            Me.ButtonItemShowBy_AllBlocked.Text = "All Blocked"
            '
            'ButtonItemShowBy_AllUnblocked
            '
            Me.ButtonItemShowBy_AllUnblocked.AutoCheckOnClick = True
            Me.ButtonItemShowBy_AllUnblocked.BeginGroup = True
            Me.ButtonItemShowBy_AllUnblocked.Name = "ButtonItemShowBy_AllUnblocked"
            Me.ButtonItemShowBy_AllUnblocked.OptionGroup = "ShowBy"
            Me.ButtonItemShowBy_AllUnblocked.SubItemsExpandWidth = 14
            Me.ButtonItemShowBy_AllUnblocked.Text = "All Unblocked"
            '
            'DataGridViewForm_UserDefinedReports
            '
            Me.DataGridViewForm_UserDefinedReports.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_UserDefinedReports.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_UserDefinedReports.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_UserDefinedReports.AutoFilterLookupColumns = False
            Me.DataGridViewForm_UserDefinedReports.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_UserDefinedReports.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewForm_UserDefinedReports.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_UserDefinedReports.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_UserDefinedReports.ItemDescription = ""
            Me.DataGridViewForm_UserDefinedReports.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewForm_UserDefinedReports.MultiSelect = True
            Me.DataGridViewForm_UserDefinedReports.Name = "DataGridViewForm_UserDefinedReports"
            Me.DataGridViewForm_UserDefinedReports.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_UserDefinedReports.RunStandardValidation = True
            Me.DataGridViewForm_UserDefinedReports.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_UserDefinedReports.Size = New System.Drawing.Size(387, 603)
            Me.DataGridViewForm_UserDefinedReports.TabIndex = 11
            Me.DataGridViewForm_UserDefinedReports.UseEmbeddedNavigator = False
            Me.DataGridViewForm_UserDefinedReports.ViewCaptionHeight = -1
            '
            'UserDefinedReportAccessForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1172, 627)
            Me.Controls.Add(Me.DataGridViewForm_UserDefinedReports)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.DataGridViewForm_UserAccess)
            Me.Controls.Add(Me.DataGridViewForm_GroupAccess)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "UserDefinedReportAccessForm"
            Me.Text = "User Defined Report Access"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewForm_GroupAccess As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewForm_UserAccess As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_ShowBy As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemShowBy_All As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemShowBy_AllBlocked As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemShowBy_AllUnblocked As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_GroupActions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ItemContainerGroupActions_GroupBlocking As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemGroupBlocking_BlockAll As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemGroupBlocking_UnblockAll As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_UserActions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ItemContainerUserActions_UserBlocking As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemUserBlocking_BlockAll As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemUserBlocking_UnblockAll As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents DataGridViewForm_UserDefinedReports As AdvantageFramework.WinForm.Presentation.Controls.DataGridView

    End Class

End Namespace