Namespace Security.Setup.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ModuleAccessForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ModuleAccessForm))
            Me.DataGridViewForm_GroupAccess = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.DataGridViewForm_UserAccess = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.LabelForm_Application = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_Application = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_View = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemView_ExpandAll = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemView_CollapseAll = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_ShowBy = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemShowBy_All = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemShowBy_AllBlocked = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemShowBy_AllUnblocked = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Show = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemShow_Modules = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemShow_Reports = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemShow_DashboardAndQueries = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemShow_DesktopObjects = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarMergeContainerForm_User = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarUser_UserActions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainerUserActions_UserBlocking = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemUserBlocking_BlockAll = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemUserBlocking_UnblockAll = New DevComponents.DotNetBar.ButtonItem()
            Me.ItemContainerUserActions_UserPrinting = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemUserPrinting_AllCanPrint = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemUserPrinting_AllCantPrint = New DevComponents.DotNetBar.ButtonItem()
            Me.ItemContainerUserActions_UserUpdating = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemUserUpdating_AllCanUpdate = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemUserUpdating_AllCantUpdate = New DevComponents.DotNetBar.ButtonItem()
            Me.ItemContainerUserActions_UserAdding = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemUserAdding_AllCanAdd = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemUserAdding_AllCantAdd = New DevComponents.DotNetBar.ButtonItem()
            Me.ItemContainerUserActions_UserCustom1 = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemUserCustom1_AllRightsCustom1 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemUserCustom1_AllNoRightsCustom1 = New DevComponents.DotNetBar.ButtonItem()
            Me.ItemContainerUserActions_UserCustom2 = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemUserCustom2_AllRightsCustom2 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemUserCustom2_AllNoRightsCustom2 = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarMergeContainerForm_Group = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarGroup_GroupActions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainerGroupActions_GroupBlocking = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemGroupBlocking_BlockAll = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemGroupBlocking_UnblockAll = New DevComponents.DotNetBar.ButtonItem()
            Me.ItemContainerGroupActions_GroupPrinting = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemGroupPrinting_AllCanPrint = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemGroupPrinting_AllCantPrint = New DevComponents.DotNetBar.ButtonItem()
            Me.ItemContainerGroupActions_GroupUpdating = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemGroupUpdating_AllCanUpdate = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemGroupUpdating_AllCantUpdate = New DevComponents.DotNetBar.ButtonItem()
            Me.ItemContainerGroupActions_GroupAdding = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemGroupAdding_AllCanAdd = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemGroupAdding_AllCantAdd = New DevComponents.DotNetBar.ButtonItem()
            Me.ItemContainerGroupActions_GroupCustom1 = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemGroupCustom1_AllRightsCustom1 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemGroupCustom1_AllNoRightsCustom1 = New DevComponents.DotNetBar.ButtonItem()
            Me.ItemContainerGroupActions_GroupCustom2 = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemGroupCustom2_AllRightsCustom2 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemGroupCustom2_AllNoRightsCustom2 = New DevComponents.DotNetBar.ButtonItem()
            Me.AdvTreeForm_Modules = New DevComponents.AdvTree.AdvTree()
            Me.NodeConnector1 = New DevComponents.AdvTree.NodeConnector()
            Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle()
            Me.RibbonBarOptions_Employees = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemEmployees_Terminated = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.RibbonBarMergeContainerForm_User.SuspendLayout()
            Me.RibbonBarMergeContainerForm_Group.SuspendLayout()
            CType(Me.AdvTreeForm_Modules, System.ComponentModel.ISupportInitialize).BeginInit()
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
            Me.DataGridViewForm_GroupAccess.Location = New System.Drawing.Point(405, 38)
            Me.DataGridViewForm_GroupAccess.MultiSelect = True
            Me.DataGridViewForm_GroupAccess.Name = "DataGridViewForm_GroupAccess"
            Me.DataGridViewForm_GroupAccess.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_GroupAccess.RunStandardValidation = True
            Me.DataGridViewForm_GroupAccess.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_GroupAccess.Size = New System.Drawing.Size(554, 265)
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
            Me.DataGridViewForm_UserAccess.Size = New System.Drawing.Size(554, 214)
            Me.DataGridViewForm_UserAccess.TabIndex = 8
            Me.DataGridViewForm_UserAccess.UseEmbeddedNavigator = False
            Me.DataGridViewForm_UserAccess.ViewCaptionHeight = -1
            '
            'LabelForm_Application
            '
            Me.LabelForm_Application.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Application.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Application.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_Application.Name = "LabelForm_Application"
            Me.LabelForm_Application.Size = New System.Drawing.Size(59, 20)
            Me.LabelForm_Application.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Application.TabIndex = 9
            Me.LabelForm_Application.Text = "Application:"
            '
            'ComboBoxForm_Application
            '
            Me.ComboBoxForm_Application.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Application.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Application.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Application.AutoFindItemInDataSource = False
            Me.ComboBoxForm_Application.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Application.BookmarkingEnabled = False
            Me.ComboBoxForm_Application.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Application
            Me.ComboBoxForm_Application.DisableMouseWheel = False
            Me.ComboBoxForm_Application.DisplayMember = "Name"
            Me.ComboBoxForm_Application.DisplayName = ""
            Me.ComboBoxForm_Application.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Application.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_Application.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_Application.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Application.FocusHighlightEnabled = True
            Me.ComboBoxForm_Application.ItemHeight = 14
            Me.ComboBoxForm_Application.Location = New System.Drawing.Point(77, 12)
            Me.ComboBoxForm_Application.Name = "ComboBoxForm_Application"
            Me.ComboBoxForm_Application.PreventEnterBeep = False
            Me.ComboBoxForm_Application.ReadOnly = False
            Me.ComboBoxForm_Application.SecurityEnabled = True
            Me.ComboBoxForm_Application.Size = New System.Drawing.Size(317, 20)
            Me.ComboBoxForm_Application.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Application.TabIndex = 1
            Me.ComboBoxForm_Application.ValueMember = "ID"
            Me.ComboBoxForm_Application.WatermarkText = "Select Application"
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_View)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_ShowBy)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Employees)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Show)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(12, 264)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(774, 98)
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
            Me.RibbonBarOptions_View.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemView_ExpandAll, Me.ButtonItemView_CollapseAll})
            Me.RibbonBarOptions_View.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.RibbonBarOptions_View.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_View.Location = New System.Drawing.Point(464, 0)
            Me.RibbonBarOptions_View.Name = "RibbonBarOptions_View"
            Me.RibbonBarOptions_View.Size = New System.Drawing.Size(74, 98)
            Me.RibbonBarOptions_View.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_View.TabIndex = 3
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
            'ButtonItemView_ExpandAll
            '
            Me.ButtonItemView_ExpandAll.Name = "ButtonItemView_ExpandAll"
            Me.ButtonItemView_ExpandAll.Stretch = True
            Me.ButtonItemView_ExpandAll.SubItemsExpandWidth = 14
            Me.ButtonItemView_ExpandAll.Text = "Expand All"
            '
            'ButtonItemView_CollapseAll
            '
            Me.ButtonItemView_CollapseAll.BeginGroup = True
            Me.ButtonItemView_CollapseAll.Name = "ButtonItemView_CollapseAll"
            Me.ButtonItemView_CollapseAll.SubItemsExpandWidth = 14
            Me.ButtonItemView_CollapseAll.Text = "Collapse All"
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
            Me.RibbonBarOptions_ShowBy.Location = New System.Drawing.Point(381, 0)
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
            'RibbonBarOptions_Show
            '
            Me.RibbonBarOptions_Show.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Show.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Show.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Show.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Show.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Show.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemShow_Modules, Me.ButtonItemShow_Reports, Me.ButtonItemShow_DashboardAndQueries, Me.ButtonItemShow_DesktopObjects})
            Me.RibbonBarOptions_Show.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Show.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Show.Name = "RibbonBarOptions_Show"
            Me.RibbonBarOptions_Show.Size = New System.Drawing.Size(305, 98)
            Me.RibbonBarOptions_Show.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Show.TabIndex = 2
            Me.RibbonBarOptions_Show.Text = "Show"
            '
            '
            '
            Me.RibbonBarOptions_Show.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Show.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Show.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemShow_Modules
            '
            Me.ButtonItemShow_Modules.AutoCheckOnClick = True
            Me.ButtonItemShow_Modules.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemShow_Modules.Checked = True
            Me.ButtonItemShow_Modules.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemShow_Modules.Name = "ButtonItemShow_Modules"
            Me.ButtonItemShow_Modules.Stretch = True
            Me.ButtonItemShow_Modules.SubItemsExpandWidth = 14
            Me.ButtonItemShow_Modules.Text = "Modules"
            '
            'ButtonItemShow_Reports
            '
            Me.ButtonItemShow_Reports.AutoCheckOnClick = True
            Me.ButtonItemShow_Reports.BeginGroup = True
            Me.ButtonItemShow_Reports.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemShow_Reports.Checked = True
            Me.ButtonItemShow_Reports.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemShow_Reports.Name = "ButtonItemShow_Reports"
            Me.ButtonItemShow_Reports.SubItemsExpandWidth = 14
            Me.ButtonItemShow_Reports.Text = "Reports"
            '
            'ButtonItemShow_DashboardAndQueries
            '
            Me.ButtonItemShow_DashboardAndQueries.AutoCheckOnClick = True
            Me.ButtonItemShow_DashboardAndQueries.BeginGroup = True
            Me.ButtonItemShow_DashboardAndQueries.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemShow_DashboardAndQueries.Checked = True
            Me.ButtonItemShow_DashboardAndQueries.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemShow_DashboardAndQueries.Name = "ButtonItemShow_DashboardAndQueries"
            Me.ButtonItemShow_DashboardAndQueries.Stretch = True
            Me.ButtonItemShow_DashboardAndQueries.SubItemsExpandWidth = 14
            Me.ButtonItemShow_DashboardAndQueries.Text = "Dashboard / Queries"
            '
            'ButtonItemShow_DesktopObjects
            '
            Me.ButtonItemShow_DesktopObjects.AutoCheckOnClick = True
            Me.ButtonItemShow_DesktopObjects.BeginGroup = True
            Me.ButtonItemShow_DesktopObjects.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemShow_DesktopObjects.Checked = True
            Me.ButtonItemShow_DesktopObjects.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemShow_DesktopObjects.Name = "ButtonItemShow_DesktopObjects"
            Me.ButtonItemShow_DesktopObjects.Stretch = True
            Me.ButtonItemShow_DesktopObjects.SubItemsExpandWidth = 14
            Me.ButtonItemShow_DesktopObjects.Text = "Desktop Objects"
            '
            'RibbonBarMergeContainerForm_User
            '
            Me.RibbonBarMergeContainerForm_User.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_User.Controls.Add(Me.RibbonBarUser_UserActions)
            Me.RibbonBarMergeContainerForm_User.Location = New System.Drawing.Point(400, 12)
            Me.RibbonBarMergeContainerForm_User.Name = "RibbonBarMergeContainerForm_User"
            Me.RibbonBarMergeContainerForm_User.RibbonTabText = "User"
            Me.RibbonBarMergeContainerForm_User.Size = New System.Drawing.Size(560, 98)
            '
            '
            '
            Me.RibbonBarMergeContainerForm_User.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_User.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_User.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarMergeContainerForm_User.TabIndex = 11
            Me.RibbonBarMergeContainerForm_User.Visible = False
            '
            'RibbonBarUser_UserActions
            '
            Me.RibbonBarUser_UserActions.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarUser_UserActions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarUser_UserActions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarUser_UserActions.ContainerControlProcessDialogKey = True
            Me.RibbonBarUser_UserActions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarUser_UserActions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerUserActions_UserBlocking, Me.ItemContainerUserActions_UserPrinting, Me.ItemContainerUserActions_UserUpdating, Me.ItemContainerUserActions_UserAdding, Me.ItemContainerUserActions_UserCustom1, Me.ItemContainerUserActions_UserCustom2})
            Me.RibbonBarUser_UserActions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarUser_UserActions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarUser_UserActions.Name = "RibbonBarUser_UserActions"
            Me.RibbonBarUser_UserActions.Size = New System.Drawing.Size(543, 98)
            Me.RibbonBarUser_UserActions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarUser_UserActions.TabIndex = 5
            Me.RibbonBarUser_UserActions.Text = "User Actions"
            '
            '
            '
            Me.RibbonBarUser_UserActions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarUser_UserActions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarUser_UserActions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
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
            'ItemContainerUserActions_UserPrinting
            '
            '
            '
            '
            Me.ItemContainerUserActions_UserPrinting.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerUserActions_UserPrinting.BeginGroup = True
            Me.ItemContainerUserActions_UserPrinting.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerUserActions_UserPrinting.Name = "ItemContainerUserActions_UserPrinting"
            Me.ItemContainerUserActions_UserPrinting.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemUserPrinting_AllCanPrint, Me.ButtonItemUserPrinting_AllCantPrint})
            '
            '
            '
            Me.ItemContainerUserActions_UserPrinting.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemUserPrinting_AllCanPrint
            '
            Me.ButtonItemUserPrinting_AllCanPrint.Name = "ButtonItemUserPrinting_AllCanPrint"
            Me.ButtonItemUserPrinting_AllCanPrint.SubItemsExpandWidth = 14
            Me.ButtonItemUserPrinting_AllCanPrint.Text = "All Can Print"
            '
            'ButtonItemUserPrinting_AllCantPrint
            '
            Me.ButtonItemUserPrinting_AllCantPrint.BeginGroup = True
            Me.ButtonItemUserPrinting_AllCantPrint.Name = "ButtonItemUserPrinting_AllCantPrint"
            Me.ButtonItemUserPrinting_AllCantPrint.SubItemsExpandWidth = 14
            Me.ButtonItemUserPrinting_AllCantPrint.Text = "All Can't Print"
            '
            'ItemContainerUserActions_UserUpdating
            '
            '
            '
            '
            Me.ItemContainerUserActions_UserUpdating.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerUserActions_UserUpdating.BeginGroup = True
            Me.ItemContainerUserActions_UserUpdating.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerUserActions_UserUpdating.Name = "ItemContainerUserActions_UserUpdating"
            Me.ItemContainerUserActions_UserUpdating.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemUserUpdating_AllCanUpdate, Me.ButtonItemUserUpdating_AllCantUpdate})
            '
            '
            '
            Me.ItemContainerUserActions_UserUpdating.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemUserUpdating_AllCanUpdate
            '
            Me.ButtonItemUserUpdating_AllCanUpdate.Name = "ButtonItemUserUpdating_AllCanUpdate"
            Me.ButtonItemUserUpdating_AllCanUpdate.SubItemsExpandWidth = 14
            Me.ButtonItemUserUpdating_AllCanUpdate.Text = "All Can Update"
            '
            'ButtonItemUserUpdating_AllCantUpdate
            '
            Me.ButtonItemUserUpdating_AllCantUpdate.BeginGroup = True
            Me.ButtonItemUserUpdating_AllCantUpdate.Name = "ButtonItemUserUpdating_AllCantUpdate"
            Me.ButtonItemUserUpdating_AllCantUpdate.SubItemsExpandWidth = 14
            Me.ButtonItemUserUpdating_AllCantUpdate.Text = "All Can't Update"
            '
            'ItemContainerUserActions_UserAdding
            '
            '
            '
            '
            Me.ItemContainerUserActions_UserAdding.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerUserActions_UserAdding.BeginGroup = True
            Me.ItemContainerUserActions_UserAdding.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerUserActions_UserAdding.Name = "ItemContainerUserActions_UserAdding"
            Me.ItemContainerUserActions_UserAdding.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemUserAdding_AllCanAdd, Me.ButtonItemUserAdding_AllCantAdd})
            '
            '
            '
            Me.ItemContainerUserActions_UserAdding.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemUserAdding_AllCanAdd
            '
            Me.ButtonItemUserAdding_AllCanAdd.Name = "ButtonItemUserAdding_AllCanAdd"
            Me.ButtonItemUserAdding_AllCanAdd.SubItemsExpandWidth = 14
            Me.ButtonItemUserAdding_AllCanAdd.Text = "All Can Add"
            '
            'ButtonItemUserAdding_AllCantAdd
            '
            Me.ButtonItemUserAdding_AllCantAdd.BeginGroup = True
            Me.ButtonItemUserAdding_AllCantAdd.Name = "ButtonItemUserAdding_AllCantAdd"
            Me.ButtonItemUserAdding_AllCantAdd.SubItemsExpandWidth = 14
            Me.ButtonItemUserAdding_AllCantAdd.Text = "All Can't Add"
            '
            'ItemContainerUserActions_UserCustom1
            '
            '
            '
            '
            Me.ItemContainerUserActions_UserCustom1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerUserActions_UserCustom1.BeginGroup = True
            Me.ItemContainerUserActions_UserCustom1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerUserActions_UserCustom1.Name = "ItemContainerUserActions_UserCustom1"
            Me.ItemContainerUserActions_UserCustom1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemUserCustom1_AllRightsCustom1, Me.ButtonItemUserCustom1_AllNoRightsCustom1})
            '
            '
            '
            Me.ItemContainerUserActions_UserCustom1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemUserCustom1_AllRightsCustom1
            '
            Me.ButtonItemUserCustom1_AllRightsCustom1.Name = "ButtonItemUserCustom1_AllRightsCustom1"
            Me.ButtonItemUserCustom1_AllRightsCustom1.SubItemsExpandWidth = 14
            Me.ButtonItemUserCustom1_AllRightsCustom1.Text = "All Rights Custom 1"
            '
            'ButtonItemUserCustom1_AllNoRightsCustom1
            '
            Me.ButtonItemUserCustom1_AllNoRightsCustom1.BeginGroup = True
            Me.ButtonItemUserCustom1_AllNoRightsCustom1.Name = "ButtonItemUserCustom1_AllNoRightsCustom1"
            Me.ButtonItemUserCustom1_AllNoRightsCustom1.SubItemsExpandWidth = 14
            Me.ButtonItemUserCustom1_AllNoRightsCustom1.Text = "All No Rights Custom 1"
            '
            'ItemContainerUserActions_UserCustom2
            '
            '
            '
            '
            Me.ItemContainerUserActions_UserCustom2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerUserActions_UserCustom2.BeginGroup = True
            Me.ItemContainerUserActions_UserCustom2.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerUserActions_UserCustom2.Name = "ItemContainerUserActions_UserCustom2"
            Me.ItemContainerUserActions_UserCustom2.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemUserCustom2_AllRightsCustom2, Me.ButtonItemUserCustom2_AllNoRightsCustom2})
            '
            '
            '
            Me.ItemContainerUserActions_UserCustom2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemUserCustom2_AllRightsCustom2
            '
            Me.ButtonItemUserCustom2_AllRightsCustom2.Name = "ButtonItemUserCustom2_AllRightsCustom2"
            Me.ButtonItemUserCustom2_AllRightsCustom2.SubItemsExpandWidth = 14
            Me.ButtonItemUserCustom2_AllRightsCustom2.Text = "All Rights Custom 2"
            '
            'ButtonItemUserCustom2_AllNoRightsCustom2
            '
            Me.ButtonItemUserCustom2_AllNoRightsCustom2.BeginGroup = True
            Me.ButtonItemUserCustom2_AllNoRightsCustom2.Name = "ButtonItemUserCustom2_AllNoRightsCustom2"
            Me.ButtonItemUserCustom2_AllNoRightsCustom2.SubItemsExpandWidth = 14
            Me.ButtonItemUserCustom2_AllNoRightsCustom2.Text = "All No Rights Custom 2"
            '
            'RibbonBarMergeContainerForm_Group
            '
            Me.RibbonBarMergeContainerForm_Group.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Group.Controls.Add(Me.RibbonBarGroup_GroupActions)
            Me.RibbonBarMergeContainerForm_Group.Location = New System.Drawing.Point(12, 399)
            Me.RibbonBarMergeContainerForm_Group.Name = "RibbonBarMergeContainerForm_Group"
            Me.RibbonBarMergeContainerForm_Group.RibbonTabText = "Group"
            Me.RibbonBarMergeContainerForm_Group.Size = New System.Drawing.Size(560, 98)
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Group.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Group.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Group.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarMergeContainerForm_Group.TabIndex = 12
            Me.RibbonBarMergeContainerForm_Group.Visible = False
            '
            'RibbonBarGroup_GroupActions
            '
            Me.RibbonBarGroup_GroupActions.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarGroup_GroupActions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarGroup_GroupActions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarGroup_GroupActions.ContainerControlProcessDialogKey = True
            Me.RibbonBarGroup_GroupActions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarGroup_GroupActions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerGroupActions_GroupBlocking, Me.ItemContainerGroupActions_GroupPrinting, Me.ItemContainerGroupActions_GroupUpdating, Me.ItemContainerGroupActions_GroupAdding, Me.ItemContainerGroupActions_GroupCustom1, Me.ItemContainerGroupActions_GroupCustom2})
            Me.RibbonBarGroup_GroupActions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarGroup_GroupActions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarGroup_GroupActions.Name = "RibbonBarGroup_GroupActions"
            Me.RibbonBarGroup_GroupActions.Size = New System.Drawing.Size(543, 98)
            Me.RibbonBarGroup_GroupActions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarGroup_GroupActions.TabIndex = 5
            Me.RibbonBarGroup_GroupActions.Text = "Group Actions"
            '
            '
            '
            Me.RibbonBarGroup_GroupActions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarGroup_GroupActions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarGroup_GroupActions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
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
            'ItemContainerGroupActions_GroupPrinting
            '
            '
            '
            '
            Me.ItemContainerGroupActions_GroupPrinting.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerGroupActions_GroupPrinting.BeginGroup = True
            Me.ItemContainerGroupActions_GroupPrinting.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerGroupActions_GroupPrinting.Name = "ItemContainerGroupActions_GroupPrinting"
            Me.ItemContainerGroupActions_GroupPrinting.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemGroupPrinting_AllCanPrint, Me.ButtonItemGroupPrinting_AllCantPrint})
            '
            '
            '
            Me.ItemContainerGroupActions_GroupPrinting.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemGroupPrinting_AllCanPrint
            '
            Me.ButtonItemGroupPrinting_AllCanPrint.Name = "ButtonItemGroupPrinting_AllCanPrint"
            Me.ButtonItemGroupPrinting_AllCanPrint.SubItemsExpandWidth = 14
            Me.ButtonItemGroupPrinting_AllCanPrint.Text = "All Can Print"
            '
            'ButtonItemGroupPrinting_AllCantPrint
            '
            Me.ButtonItemGroupPrinting_AllCantPrint.BeginGroup = True
            Me.ButtonItemGroupPrinting_AllCantPrint.Name = "ButtonItemGroupPrinting_AllCantPrint"
            Me.ButtonItemGroupPrinting_AllCantPrint.SubItemsExpandWidth = 14
            Me.ButtonItemGroupPrinting_AllCantPrint.Text = "All Can't Print"
            '
            'ItemContainerGroupActions_GroupUpdating
            '
            '
            '
            '
            Me.ItemContainerGroupActions_GroupUpdating.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerGroupActions_GroupUpdating.BeginGroup = True
            Me.ItemContainerGroupActions_GroupUpdating.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerGroupActions_GroupUpdating.Name = "ItemContainerGroupActions_GroupUpdating"
            Me.ItemContainerGroupActions_GroupUpdating.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemGroupUpdating_AllCanUpdate, Me.ButtonItemGroupUpdating_AllCantUpdate})
            '
            '
            '
            Me.ItemContainerGroupActions_GroupUpdating.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemGroupUpdating_AllCanUpdate
            '
            Me.ButtonItemGroupUpdating_AllCanUpdate.Name = "ButtonItemGroupUpdating_AllCanUpdate"
            Me.ButtonItemGroupUpdating_AllCanUpdate.SubItemsExpandWidth = 14
            Me.ButtonItemGroupUpdating_AllCanUpdate.Text = "All Can Update"
            '
            'ButtonItemGroupUpdating_AllCantUpdate
            '
            Me.ButtonItemGroupUpdating_AllCantUpdate.BeginGroup = True
            Me.ButtonItemGroupUpdating_AllCantUpdate.Name = "ButtonItemGroupUpdating_AllCantUpdate"
            Me.ButtonItemGroupUpdating_AllCantUpdate.SubItemsExpandWidth = 14
            Me.ButtonItemGroupUpdating_AllCantUpdate.Text = "All Can't Update"
            '
            'ItemContainerGroupActions_GroupAdding
            '
            '
            '
            '
            Me.ItemContainerGroupActions_GroupAdding.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerGroupActions_GroupAdding.BeginGroup = True
            Me.ItemContainerGroupActions_GroupAdding.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerGroupActions_GroupAdding.Name = "ItemContainerGroupActions_GroupAdding"
            Me.ItemContainerGroupActions_GroupAdding.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemGroupAdding_AllCanAdd, Me.ButtonItemGroupAdding_AllCantAdd})
            '
            '
            '
            Me.ItemContainerGroupActions_GroupAdding.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemGroupAdding_AllCanAdd
            '
            Me.ButtonItemGroupAdding_AllCanAdd.Name = "ButtonItemGroupAdding_AllCanAdd"
            Me.ButtonItemGroupAdding_AllCanAdd.SubItemsExpandWidth = 14
            Me.ButtonItemGroupAdding_AllCanAdd.Text = "All Can Add"
            '
            'ButtonItemGroupAdding_AllCantAdd
            '
            Me.ButtonItemGroupAdding_AllCantAdd.BeginGroup = True
            Me.ButtonItemGroupAdding_AllCantAdd.Name = "ButtonItemGroupAdding_AllCantAdd"
            Me.ButtonItemGroupAdding_AllCantAdd.SubItemsExpandWidth = 14
            Me.ButtonItemGroupAdding_AllCantAdd.Text = "All Can't Add"
            '
            'ItemContainerGroupActions_GroupCustom1
            '
            '
            '
            '
            Me.ItemContainerGroupActions_GroupCustom1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerGroupActions_GroupCustom1.BeginGroup = True
            Me.ItemContainerGroupActions_GroupCustom1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerGroupActions_GroupCustom1.Name = "ItemContainerGroupActions_GroupCustom1"
            Me.ItemContainerGroupActions_GroupCustom1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemGroupCustom1_AllRightsCustom1, Me.ButtonItemGroupCustom1_AllNoRightsCustom1})
            '
            '
            '
            Me.ItemContainerGroupActions_GroupCustom1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemGroupCustom1_AllRightsCustom1
            '
            Me.ButtonItemGroupCustom1_AllRightsCustom1.Name = "ButtonItemGroupCustom1_AllRightsCustom1"
            Me.ButtonItemGroupCustom1_AllRightsCustom1.SubItemsExpandWidth = 14
            Me.ButtonItemGroupCustom1_AllRightsCustom1.Text = "All Rights Custom 1"
            '
            'ButtonItemGroupCustom1_AllNoRightsCustom1
            '
            Me.ButtonItemGroupCustom1_AllNoRightsCustom1.BeginGroup = True
            Me.ButtonItemGroupCustom1_AllNoRightsCustom1.Name = "ButtonItemGroupCustom1_AllNoRightsCustom1"
            Me.ButtonItemGroupCustom1_AllNoRightsCustom1.SubItemsExpandWidth = 14
            Me.ButtonItemGroupCustom1_AllNoRightsCustom1.Text = "All No Rights Custom 1"
            '
            'ItemContainerGroupActions_GroupCustom2
            '
            '
            '
            '
            Me.ItemContainerGroupActions_GroupCustom2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerGroupActions_GroupCustom2.BeginGroup = True
            Me.ItemContainerGroupActions_GroupCustom2.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerGroupActions_GroupCustom2.Name = "ItemContainerGroupActions_GroupCustom2"
            Me.ItemContainerGroupActions_GroupCustom2.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemGroupCustom2_AllRightsCustom2, Me.ButtonItemGroupCustom2_AllNoRightsCustom2})
            '
            '
            '
            Me.ItemContainerGroupActions_GroupCustom2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemGroupCustom2_AllRightsCustom2
            '
            Me.ButtonItemGroupCustom2_AllRightsCustom2.Name = "ButtonItemGroupCustom2_AllRightsCustom2"
            Me.ButtonItemGroupCustom2_AllRightsCustom2.SubItemsExpandWidth = 14
            Me.ButtonItemGroupCustom2_AllRightsCustom2.Text = "All Rights Custom 2"
            '
            'ButtonItemGroupCustom2_AllNoRightsCustom2
            '
            Me.ButtonItemGroupCustom2_AllNoRightsCustom2.BeginGroup = True
            Me.ButtonItemGroupCustom2_AllNoRightsCustom2.Name = "ButtonItemGroupCustom2_AllNoRightsCustom2"
            Me.ButtonItemGroupCustom2_AllNoRightsCustom2.SubItemsExpandWidth = 14
            Me.ButtonItemGroupCustom2_AllNoRightsCustom2.Text = "All No Rights Custom 2"
            '
            'AdvTreeForm_Modules
            '
            Me.AdvTreeForm_Modules.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline
            Me.AdvTreeForm_Modules.AllowDrop = True
            Me.AdvTreeForm_Modules.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.AdvTreeForm_Modules.BackColor = System.Drawing.SystemColors.Window
            '
            '
            '
            Me.AdvTreeForm_Modules.BackgroundStyle.Class = "TreeBorderKey"
            Me.AdvTreeForm_Modules.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.AdvTreeForm_Modules.DragDropEnabled = False
            Me.AdvTreeForm_Modules.DragDropNodeCopyEnabled = False
            Me.AdvTreeForm_Modules.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.AdvTreeForm_Modules.Location = New System.Drawing.Point(12, 38)
            Me.AdvTreeForm_Modules.MultiSelect = True
            Me.AdvTreeForm_Modules.MultiSelectRule = DevComponents.AdvTree.eMultiSelectRule.AnyNode
            Me.AdvTreeForm_Modules.Name = "AdvTreeForm_Modules"
            Me.AdvTreeForm_Modules.NodesConnector = Me.NodeConnector1
            Me.AdvTreeForm_Modules.NodeStyle = Me.ElementStyle1
            Me.AdvTreeForm_Modules.PathSeparator = ";"
            Me.AdvTreeForm_Modules.Size = New System.Drawing.Size(382, 485)
            Me.AdvTreeForm_Modules.Styles.Add(Me.ElementStyle1)
            Me.AdvTreeForm_Modules.TabIndex = 13
            '
            'NodeConnector1
            '
            Me.NodeConnector1.LineColor = System.Drawing.SystemColors.ControlText
            '
            'ElementStyle1
            '
            Me.ElementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ElementStyle1.Name = "ElementStyle1"
            Me.ElementStyle1.TextColor = System.Drawing.SystemColors.ControlText
            '
            'RibbonBarOptions_Employees
            '
            Me.RibbonBarOptions_Employees.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Employees.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Employees.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Employees.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Employees.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Employees.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemEmployees_Terminated})
            Me.RibbonBarOptions_Employees.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Employees.Location = New System.Drawing.Point(305, 0)
            Me.RibbonBarOptions_Employees.Name = "RibbonBarOptions_Employees"
            Me.RibbonBarOptions_Employees.SecurityEnabled = True
            Me.RibbonBarOptions_Employees.Size = New System.Drawing.Size(76, 98)
            Me.RibbonBarOptions_Employees.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Employees.TabIndex = 7
            Me.RibbonBarOptions_Employees.Text = "Employees"
            '
            '
            '
            Me.RibbonBarOptions_Employees.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Employees.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Employees.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemEmployees_Terminated
            '
            Me.ButtonItemEmployees_Terminated.AutoCheckOnClick = True
            Me.ButtonItemEmployees_Terminated.BeginGroup = True
            Me.ButtonItemEmployees_Terminated.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemEmployees_Terminated.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemEmployees_Terminated.Name = "ButtonItemEmployees_Terminated"
            Me.ButtonItemEmployees_Terminated.RibbonWordWrap = False
            Me.ButtonItemEmployees_Terminated.SecurityEnabled = True
            Me.ButtonItemEmployees_Terminated.Stretch = True
            Me.ButtonItemEmployees_Terminated.SubItemsExpandWidth = 14
            Me.ButtonItemEmployees_Terminated.Text = "Terminated"
            '
            'ModuleAccessForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(971, 535)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_User)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Group)
            Me.Controls.Add(Me.AdvTreeForm_Modules)
            Me.Controls.Add(Me.ComboBoxForm_Application)
            Me.Controls.Add(Me.LabelForm_Application)
            Me.Controls.Add(Me.DataGridViewForm_UserAccess)
            Me.Controls.Add(Me.DataGridViewForm_GroupAccess)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ModuleAccessForm"
            Me.Text = "Module Access"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.RibbonBarMergeContainerForm_User.ResumeLayout(False)
            Me.RibbonBarMergeContainerForm_Group.ResumeLayout(False)
            CType(Me.AdvTreeForm_Modules, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewForm_GroupAccess As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewForm_UserAccess As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents LabelForm_Application As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_Application As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Show As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemShow_Modules As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemShow_Reports As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemShow_DashboardAndQueries As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemShow_DesktopObjects As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_View As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemView_ExpandAll As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemView_CollapseAll As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarMergeContainerForm_User As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarUser_UserActions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ItemContainerUserActions_UserBlocking As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemUserBlocking_BlockAll As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemUserBlocking_UnblockAll As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ItemContainerUserActions_UserPrinting As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemUserPrinting_AllCanPrint As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemUserPrinting_AllCantPrint As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ItemContainerUserActions_UserUpdating As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemUserUpdating_AllCanUpdate As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemUserUpdating_AllCantUpdate As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ItemContainerUserActions_UserAdding As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemUserAdding_AllCanAdd As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemUserAdding_AllCantAdd As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ItemContainerUserActions_UserCustom1 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemUserCustom1_AllRightsCustom1 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemUserCustom1_AllNoRightsCustom1 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ItemContainerUserActions_UserCustom2 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemUserCustom2_AllRightsCustom2 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemUserCustom2_AllNoRightsCustom2 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarMergeContainerForm_Group As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarGroup_GroupActions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ItemContainerGroupActions_GroupBlocking As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemGroupBlocking_BlockAll As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemGroupBlocking_UnblockAll As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ItemContainerGroupActions_GroupPrinting As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemGroupPrinting_AllCanPrint As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemGroupPrinting_AllCantPrint As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ItemContainerGroupActions_GroupUpdating As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemGroupUpdating_AllCanUpdate As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemGroupUpdating_AllCantUpdate As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ItemContainerGroupActions_GroupAdding As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemGroupAdding_AllCanAdd As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemGroupAdding_AllCantAdd As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ItemContainerGroupActions_GroupCustom1 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemGroupCustom1_AllRightsCustom1 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemGroupCustom1_AllNoRightsCustom1 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ItemContainerGroupActions_GroupCustom2 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemGroupCustom2_AllRightsCustom2 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemGroupCustom2_AllNoRightsCustom2 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_ShowBy As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemShowBy_All As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemShowBy_AllBlocked As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemShowBy_AllUnblocked As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents AdvTreeForm_Modules As DevComponents.AdvTree.AdvTree
        Friend WithEvents NodeConnector1 As DevComponents.AdvTree.NodeConnector
        Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
        Friend WithEvents RibbonBarOptions_Employees As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemEmployees_Terminated As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem

    End Class

End Namespace