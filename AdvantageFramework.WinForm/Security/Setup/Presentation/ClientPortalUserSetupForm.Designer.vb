Namespace Security.Setup.Presentation

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
	Partial Class ClientPortalUserSetupForm
		Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm

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
			Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClientPortalUserSetupForm))
			Me.DataGridViewLeftSection_ClientPortalUsers = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
			Me.RibbonBarMergeContainerRightSection_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
			Me.RibbonBarOptions_View = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.ButtonItemView_ExpandAll = New DevComponents.DotNetBar.ButtonItem()
			Me.ButtonItemView_CollapseAll = New DevComponents.DotNetBar.ButtonItem()
			Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.ButtonItemActions_Add = New DevComponents.DotNetBar.ButtonItem()
			Me.ButtonItemActions_Update = New DevComponents.DotNetBar.ButtonItem()
			Me.ButtonItemActions_Delete = New DevComponents.DotNetBar.ButtonItem()
			Me.ButtonItemActions_ChangePassword = New DevComponents.DotNetBar.ButtonItem()
			Me.ButtonItemActions_RefreshCDPAccess = New DevComponents.DotNetBar.ButtonItem()
			Me.PanelForm_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
			Me.ExpandableSplitterControlForm_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
			Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
			Me.TextBoxForm_Email = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
			Me.LabelForm_Email = New AdvantageFramework.WinForm.Presentation.Controls.Label()
			Me.TextBoxForm_Name = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
			Me.LabelForm_FullName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
			Me.TabControlRightSection_ClientPortalUserDetails = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
			Me.TabControlPanelConceptShareTab_ConceptShare = New DevComponents.DotNetBar.TabControlPanel()
			Me.ButtonConceptShare_RemoveUser = New AdvantageFramework.WinForm.Presentation.Controls.Button()
			Me.CheckBoxConceptShare_ShowPassword = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
			Me.CheckBoxConceptShare_IsActive = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
			Me.ButtonConceptShare_UpdateUser = New AdvantageFramework.WinForm.Presentation.Controls.Button()
			Me.ButtonConceptShare_CreateUser = New AdvantageFramework.WinForm.Presentation.Controls.Button()
			Me.TextBoxConceptShare_Password = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
			Me.LabelConceptShare_Password = New AdvantageFramework.WinForm.Presentation.Controls.Label()
			Me.TabItemClientPortalUserDetails_ConceptShareTab = New DevComponents.DotNetBar.TabItem(Me.components)
			Me.TabControlPanelClientDivisionProductAccessTab_ClientDivisionProductAccess = New DevComponents.DotNetBar.TabControlPanel()
			Me.DataGridViewClientDivisionProductAccess_ClientDivisionProductAccess = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
			Me.TabItemClientPortalUserDetails_ClientDivisionProductAccessTab = New DevComponents.DotNetBar.TabItem(Me.components)
			Me.TabControlPanelModuleAccessTab_ModuleAccess = New DevComponents.DotNetBar.TabControlPanel()
			Me.CheckBoxModuleAccess_IsBlockedFromClientPortal = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
			Me.AdvTreeModuleAccess_Modules = New DevComponents.AdvTree.AdvTree()
			Me.NodeConnector1 = New DevComponents.AdvTree.NodeConnector()
			Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle()
			Me.LabelModuleAccess_Options = New AdvantageFramework.WinForm.Presentation.Controls.Label()
			Me.CheckBoxModuleAccess_IsBlocked = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
			Me.TabItemClientPortalUserDetails_ModuleAccessTab = New DevComponents.DotNetBar.TabItem(Me.components)
			Me.RibbonBarMergeContainerRightSection_Options.SuspendLayout()
			CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.PanelForm_LeftSection.SuspendLayout()
			CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.PanelForm_RightSection.SuspendLayout()
			CType(Me.TabControlRightSection_ClientPortalUserDetails, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.TabControlRightSection_ClientPortalUserDetails.SuspendLayout()
			Me.TabControlPanelConceptShareTab_ConceptShare.SuspendLayout()
			Me.TabControlPanelClientDivisionProductAccessTab_ClientDivisionProductAccess.SuspendLayout()
			Me.TabControlPanelModuleAccessTab_ModuleAccess.SuspendLayout()
			CType(Me.AdvTreeModuleAccess_Modules, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			'
			'DataGridViewLeftSection_ClientPortalUsers
			'
			Me.DataGridViewLeftSection_ClientPortalUsers.AddFixedColumnCheckItemsToGridMenu = False
			Me.DataGridViewLeftSection_ClientPortalUsers.AllowDragAndDrop = False
			Me.DataGridViewLeftSection_ClientPortalUsers.AllowExtraItemsInGridLookupEdits = True
			Me.DataGridViewLeftSection_ClientPortalUsers.AllowSelectGroupHeaderRow = True
			Me.DataGridViewLeftSection_ClientPortalUsers.AlwaysForceShowRowSelectionOnUserInput = True
			Me.DataGridViewLeftSection_ClientPortalUsers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.DataGridViewLeftSection_ClientPortalUsers.AutoFilterLookupColumns = False
			Me.DataGridViewLeftSection_ClientPortalUsers.AutoloadRepositoryDatasource = True
			Me.DataGridViewLeftSection_ClientPortalUsers.AutoUpdateViewCaption = True
			Me.DataGridViewLeftSection_ClientPortalUsers.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
			Me.DataGridViewLeftSection_ClientPortalUsers.DataSource = Nothing
			Me.DataGridViewLeftSection_ClientPortalUsers.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
			Me.DataGridViewLeftSection_ClientPortalUsers.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
			Me.DataGridViewLeftSection_ClientPortalUsers.ItemDescription = ""
			Me.DataGridViewLeftSection_ClientPortalUsers.Location = New System.Drawing.Point(12, 12)
			Me.DataGridViewLeftSection_ClientPortalUsers.MultiSelect = True
			Me.DataGridViewLeftSection_ClientPortalUsers.Name = "DataGridViewLeftSection_ClientPortalUsers"
			Me.DataGridViewLeftSection_ClientPortalUsers.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
			Me.DataGridViewLeftSection_ClientPortalUsers.RunStandardValidation = True
			Me.DataGridViewLeftSection_ClientPortalUsers.ShowColumnMenuOnRightClick = False
			Me.DataGridViewLeftSection_ClientPortalUsers.ShowSelectDeselectAllButtons = False
			Me.DataGridViewLeftSection_ClientPortalUsers.Size = New System.Drawing.Size(258, 516)
			Me.DataGridViewLeftSection_ClientPortalUsers.TabIndex = 0
			Me.DataGridViewLeftSection_ClientPortalUsers.UseEmbeddedNavigator = False
			Me.DataGridViewLeftSection_ClientPortalUsers.ViewCaptionHeight = -1
			'
			'RibbonBarMergeContainerRightSection_Options
			'
			Me.RibbonBarMergeContainerRightSection_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RibbonBarMergeContainerRightSection_Options.Controls.Add(Me.RibbonBarOptions_View)
			Me.RibbonBarMergeContainerRightSection_Options.Controls.Add(Me.RibbonBarOptions_Actions)
			Me.RibbonBarMergeContainerRightSection_Options.Location = New System.Drawing.Point(50, 302)
			Me.RibbonBarMergeContainerRightSection_Options.Name = "RibbonBarMergeContainerRightSection_Options"
			Me.RibbonBarMergeContainerRightSection_Options.RibbonTabText = "Options"
			Me.RibbonBarMergeContainerRightSection_Options.Size = New System.Drawing.Size(580, 98)
			'
			'
			'
			Me.RibbonBarMergeContainerRightSection_Options.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarMergeContainerRightSection_Options.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarMergeContainerRightSection_Options.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarMergeContainerRightSection_Options.TabIndex = 2
			Me.RibbonBarMergeContainerRightSection_Options.Visible = False
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
			Me.RibbonBarOptions_View.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemView_ExpandAll, Me.ButtonItemView_CollapseAll})
			Me.RibbonBarOptions_View.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
			Me.RibbonBarOptions_View.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
			Me.RibbonBarOptions_View.Location = New System.Drawing.Point(341, 0)
			Me.RibbonBarOptions_View.Name = "RibbonBarOptions_View"
			Me.RibbonBarOptions_View.SecurityEnabled = True
			Me.RibbonBarOptions_View.Size = New System.Drawing.Size(72, 98)
			Me.RibbonBarOptions_View.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RibbonBarOptions_View.TabIndex = 4
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
			Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Add, Me.ButtonItemActions_Update, Me.ButtonItemActions_Delete, Me.ButtonItemActions_ChangePassword, Me.ButtonItemActions_RefreshCDPAccess})
			Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
			Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
			Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
			Me.RibbonBarOptions_Actions.SecurityEnabled = True
			Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(341, 98)
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
			Me.ButtonItemActions_Add.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
			Me.ButtonItemActions_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemActions_Add.Name = "ButtonItemActions_Add"
			Me.ButtonItemActions_Add.RibbonWordWrap = False
			Me.ButtonItemActions_Add.SubItemsExpandWidth = 14
			Me.ButtonItemActions_Add.Text = "Add"
			'
			'ButtonItemActions_Update
			'
			Me.ButtonItemActions_Update.BeginGroup = True
			Me.ButtonItemActions_Update.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
			Me.ButtonItemActions_Update.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemActions_Update.Name = "ButtonItemActions_Update"
			Me.ButtonItemActions_Update.RibbonWordWrap = False
			Me.ButtonItemActions_Update.SubItemsExpandWidth = 14
			Me.ButtonItemActions_Update.Text = "Update"
			'
			'ButtonItemActions_Delete
			'
			Me.ButtonItemActions_Delete.BeginGroup = True
			Me.ButtonItemActions_Delete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
			Me.ButtonItemActions_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemActions_Delete.Name = "ButtonItemActions_Delete"
			Me.ButtonItemActions_Delete.RibbonWordWrap = False
			Me.ButtonItemActions_Delete.SubItemsExpandWidth = 14
			Me.ButtonItemActions_Delete.Text = "Delete"
			'
			'ButtonItemActions_ChangePassword
			'
			Me.ButtonItemActions_ChangePassword.BeginGroup = True
			Me.ButtonItemActions_ChangePassword.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
			Me.ButtonItemActions_ChangePassword.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemActions_ChangePassword.Name = "ButtonItemActions_ChangePassword"
			Me.ButtonItemActions_ChangePassword.RibbonWordWrap = False
			Me.ButtonItemActions_ChangePassword.SubItemsExpandWidth = 14
			Me.ButtonItemActions_ChangePassword.Text = "Change Password"
			'
			'ButtonItemActions_RefreshCDPAccess
			'
			Me.ButtonItemActions_RefreshCDPAccess.BeginGroup = True
			Me.ButtonItemActions_RefreshCDPAccess.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
			Me.ButtonItemActions_RefreshCDPAccess.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemActions_RefreshCDPAccess.Name = "ButtonItemActions_RefreshCDPAccess"
			Me.ButtonItemActions_RefreshCDPAccess.RibbonWordWrap = False
			Me.ButtonItemActions_RefreshCDPAccess.SubItemsExpandWidth = 14
			Me.ButtonItemActions_RefreshCDPAccess.Text = "Refresh C/D/P Access"
			'
			'PanelForm_LeftSection
			'
			Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_ClientPortalUsers)
			Me.PanelForm_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
			Me.PanelForm_LeftSection.Location = New System.Drawing.Point(0, 0)
			Me.PanelForm_LeftSection.Name = "PanelForm_LeftSection"
			Me.PanelForm_LeftSection.Size = New System.Drawing.Size(275, 540)
			Me.PanelForm_LeftSection.TabIndex = 12
			'
			'ExpandableSplitterControlForm_LeftRight
			'
			Me.ExpandableSplitterControlForm_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
			Me.ExpandableSplitterControlForm_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
			Me.ExpandableSplitterControlForm_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
			Me.ExpandableSplitterControlForm_LeftRight.ExpandableControl = Me.PanelForm_LeftSection
			Me.ExpandableSplitterControlForm_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
			Me.ExpandableSplitterControlForm_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
			Me.ExpandableSplitterControlForm_LeftRight.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
			Me.ExpandableSplitterControlForm_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
			Me.ExpandableSplitterControlForm_LeftRight.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
			Me.ExpandableSplitterControlForm_LeftRight.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
			Me.ExpandableSplitterControlForm_LeftRight.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
			Me.ExpandableSplitterControlForm_LeftRight.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
			Me.ExpandableSplitterControlForm_LeftRight.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
			Me.ExpandableSplitterControlForm_LeftRight.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
			Me.ExpandableSplitterControlForm_LeftRight.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
			Me.ExpandableSplitterControlForm_LeftRight.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
			Me.ExpandableSplitterControlForm_LeftRight.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
			Me.ExpandableSplitterControlForm_LeftRight.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
			Me.ExpandableSplitterControlForm_LeftRight.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
			Me.ExpandableSplitterControlForm_LeftRight.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
			Me.ExpandableSplitterControlForm_LeftRight.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
			Me.ExpandableSplitterControlForm_LeftRight.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
			Me.ExpandableSplitterControlForm_LeftRight.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
			Me.ExpandableSplitterControlForm_LeftRight.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
			Me.ExpandableSplitterControlForm_LeftRight.Location = New System.Drawing.Point(275, 0)
			Me.ExpandableSplitterControlForm_LeftRight.Name = "ExpandableSplitterControlForm_LeftRight"
			Me.ExpandableSplitterControlForm_LeftRight.Size = New System.Drawing.Size(6, 540)
			Me.ExpandableSplitterControlForm_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
			Me.ExpandableSplitterControlForm_LeftRight.TabIndex = 13
			Me.ExpandableSplitterControlForm_LeftRight.TabStop = False
			'
			'PanelForm_RightSection
			'
			Me.PanelForm_RightSection.Controls.Add(Me.TextBoxForm_Email)
			Me.PanelForm_RightSection.Controls.Add(Me.LabelForm_Email)
			Me.PanelForm_RightSection.Controls.Add(Me.TextBoxForm_Name)
			Me.PanelForm_RightSection.Controls.Add(Me.LabelForm_FullName)
			Me.PanelForm_RightSection.Controls.Add(Me.TabControlRightSection_ClientPortalUserDetails)
			Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
			Me.PanelForm_RightSection.Location = New System.Drawing.Point(281, 0)
			Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
			Me.PanelForm_RightSection.Size = New System.Drawing.Size(491, 540)
			Me.PanelForm_RightSection.TabIndex = 14
			'
			'TextBoxForm_Email
			'
			Me.TextBoxForm_Email.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			'
			'
			'
			Me.TextBoxForm_Email.Border.Class = "TextBoxBorder"
			Me.TextBoxForm_Email.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.TextBoxForm_Email.CheckSpellingOnValidate = False
			Me.TextBoxForm_Email.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
			Me.TextBoxForm_Email.Enabled = False
			Me.TextBoxForm_Email.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
			Me.TextBoxForm_Email.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
			Me.TextBoxForm_Email.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
			Me.TextBoxForm_Email.FocusHighlightEnabled = True
			Me.TextBoxForm_Email.Location = New System.Drawing.Point(81, 39)
			Me.TextBoxForm_Email.MaxFileSize = CType(0, Long)
			Me.TextBoxForm_Email.Name = "TextBoxForm_Email"
			Me.TextBoxForm_Email.ReadOnly = True
			Me.TextBoxForm_Email.SecurityEnabled = True
			Me.TextBoxForm_Email.ShowSpellCheckCompleteMessage = True
			Me.TextBoxForm_Email.Size = New System.Drawing.Size(398, 21)
			Me.TextBoxForm_Email.StartingFolderName = Nothing
			Me.TextBoxForm_Email.TabIndex = 17
			Me.TextBoxForm_Email.TabOnEnter = True
			'
			'LabelForm_Email
			'
			Me.LabelForm_Email.BackColor = System.Drawing.Color.White
			'
			'
			'
			Me.LabelForm_Email.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.LabelForm_Email.Location = New System.Drawing.Point(6, 39)
			Me.LabelForm_Email.Name = "LabelForm_Email"
			Me.LabelForm_Email.Size = New System.Drawing.Size(69, 21)
			Me.LabelForm_Email.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.LabelForm_Email.TabIndex = 16
			Me.LabelForm_Email.Text = "Email:"
			'
			'TextBoxForm_Name
			'
			Me.TextBoxForm_Name.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			'
			'
			'
			Me.TextBoxForm_Name.Border.Class = "TextBoxBorder"
			Me.TextBoxForm_Name.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.TextBoxForm_Name.CheckSpellingOnValidate = False
			Me.TextBoxForm_Name.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
			Me.TextBoxForm_Name.Enabled = False
			Me.TextBoxForm_Name.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
			Me.TextBoxForm_Name.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
			Me.TextBoxForm_Name.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
			Me.TextBoxForm_Name.FocusHighlightEnabled = True
			Me.TextBoxForm_Name.Location = New System.Drawing.Point(81, 12)
			Me.TextBoxForm_Name.MaxFileSize = CType(0, Long)
			Me.TextBoxForm_Name.Name = "TextBoxForm_Name"
			Me.TextBoxForm_Name.ReadOnly = True
			Me.TextBoxForm_Name.SecurityEnabled = True
			Me.TextBoxForm_Name.ShowSpellCheckCompleteMessage = True
			Me.TextBoxForm_Name.Size = New System.Drawing.Size(398, 21)
			Me.TextBoxForm_Name.StartingFolderName = Nothing
			Me.TextBoxForm_Name.TabIndex = 15
			Me.TextBoxForm_Name.TabOnEnter = True
			'
			'LabelForm_FullName
			'
			Me.LabelForm_FullName.BackColor = System.Drawing.Color.White
			'
			'
			'
			Me.LabelForm_FullName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.LabelForm_FullName.Location = New System.Drawing.Point(6, 12)
			Me.LabelForm_FullName.Name = "LabelForm_FullName"
			Me.LabelForm_FullName.Size = New System.Drawing.Size(69, 21)
			Me.LabelForm_FullName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.LabelForm_FullName.TabIndex = 14
			Me.LabelForm_FullName.Text = "Full Name:"
			'
			'TabControlRightSection_ClientPortalUserDetails
			'
			Me.TabControlRightSection_ClientPortalUserDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.TabControlRightSection_ClientPortalUserDetails.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
			Me.TabControlRightSection_ClientPortalUserDetails.CanReorderTabs = False
			Me.TabControlRightSection_ClientPortalUserDetails.ColorScheme.TabBackground = System.Drawing.Color.White
			Me.TabControlRightSection_ClientPortalUserDetails.ColorScheme.TabPanelBackground = System.Drawing.Color.White
			Me.TabControlRightSection_ClientPortalUserDetails.Controls.Add(Me.TabControlPanelConceptShareTab_ConceptShare)
			Me.TabControlRightSection_ClientPortalUserDetails.Controls.Add(Me.TabControlPanelModuleAccessTab_ModuleAccess)
			Me.TabControlRightSection_ClientPortalUserDetails.Controls.Add(Me.TabControlPanelClientDivisionProductAccessTab_ClientDivisionProductAccess)
			Me.TabControlRightSection_ClientPortalUserDetails.Location = New System.Drawing.Point(6, 66)
			Me.TabControlRightSection_ClientPortalUserDetails.Name = "TabControlRightSection_ClientPortalUserDetails"
			Me.TabControlRightSection_ClientPortalUserDetails.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
			Me.TabControlRightSection_ClientPortalUserDetails.SelectedTabIndex = 0
			Me.TabControlRightSection_ClientPortalUserDetails.Size = New System.Drawing.Size(473, 462)
			Me.TabControlRightSection_ClientPortalUserDetails.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
			Me.TabControlRightSection_ClientPortalUserDetails.TabIndex = 12
			Me.TabControlRightSection_ClientPortalUserDetails.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
			Me.TabControlRightSection_ClientPortalUserDetails.Tabs.Add(Me.TabItemClientPortalUserDetails_ModuleAccessTab)
			Me.TabControlRightSection_ClientPortalUserDetails.Tabs.Add(Me.TabItemClientPortalUserDetails_ClientDivisionProductAccessTab)
			Me.TabControlRightSection_ClientPortalUserDetails.Tabs.Add(Me.TabItemClientPortalUserDetails_ConceptShareTab)
			'
			'TabControlPanelConceptShareTab_ConceptShare
			'
			Me.TabControlPanelConceptShareTab_ConceptShare.Controls.Add(Me.ButtonConceptShare_RemoveUser)
			Me.TabControlPanelConceptShareTab_ConceptShare.Controls.Add(Me.CheckBoxConceptShare_ShowPassword)
			Me.TabControlPanelConceptShareTab_ConceptShare.Controls.Add(Me.CheckBoxConceptShare_IsActive)
			Me.TabControlPanelConceptShareTab_ConceptShare.Controls.Add(Me.ButtonConceptShare_UpdateUser)
			Me.TabControlPanelConceptShareTab_ConceptShare.Controls.Add(Me.ButtonConceptShare_CreateUser)
			Me.TabControlPanelConceptShareTab_ConceptShare.Controls.Add(Me.TextBoxConceptShare_Password)
			Me.TabControlPanelConceptShareTab_ConceptShare.Controls.Add(Me.LabelConceptShare_Password)
			Me.TabControlPanelConceptShareTab_ConceptShare.DisabledBackColor = System.Drawing.Color.Empty
			Me.TabControlPanelConceptShareTab_ConceptShare.Dock = System.Windows.Forms.DockStyle.Fill
			Me.TabControlPanelConceptShareTab_ConceptShare.Location = New System.Drawing.Point(0, 27)
			Me.TabControlPanelConceptShareTab_ConceptShare.Name = "TabControlPanelConceptShareTab_ConceptShare"
			Me.TabControlPanelConceptShareTab_ConceptShare.Padding = New System.Windows.Forms.Padding(1)
			Me.TabControlPanelConceptShareTab_ConceptShare.Size = New System.Drawing.Size(473, 435)
			Me.TabControlPanelConceptShareTab_ConceptShare.Style.BackColor1.Color = System.Drawing.Color.White
			Me.TabControlPanelConceptShareTab_ConceptShare.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
			Me.TabControlPanelConceptShareTab_ConceptShare.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
			Me.TabControlPanelConceptShareTab_ConceptShare.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
			Me.TabControlPanelConceptShareTab_ConceptShare.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
			Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
			Me.TabControlPanelConceptShareTab_ConceptShare.Style.GradientAngle = 90
			Me.TabControlPanelConceptShareTab_ConceptShare.TabIndex = 0
			Me.TabControlPanelConceptShareTab_ConceptShare.TabItem = Me.TabItemClientPortalUserDetails_ConceptShareTab
			'
			'ButtonConceptShare_RemoveUser
			'
			Me.ButtonConceptShare_RemoveUser.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
			Me.ButtonConceptShare_RemoveUser.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
			Me.ButtonConceptShare_RemoveUser.Location = New System.Drawing.Point(166, 4)
			Me.ButtonConceptShare_RemoveUser.Name = "ButtonConceptShare_RemoveUser"
			Me.ButtonConceptShare_RemoveUser.SecurityEnabled = True
			Me.ButtonConceptShare_RemoveUser.Size = New System.Drawing.Size(75, 20)
			Me.ButtonConceptShare_RemoveUser.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.ButtonConceptShare_RemoveUser.TabIndex = 2
			Me.ButtonConceptShare_RemoveUser.Text = "Remove User"
			'
			'CheckBoxConceptShare_ShowPassword
			'
			Me.CheckBoxConceptShare_ShowPassword.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.CheckBoxConceptShare_ShowPassword.BackColor = System.Drawing.Color.White
			'
			'
			'
			Me.CheckBoxConceptShare_ShowPassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.CheckBoxConceptShare_ShowPassword.CheckValue = 0
			Me.CheckBoxConceptShare_ShowPassword.CheckValueChecked = 1
			Me.CheckBoxConceptShare_ShowPassword.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
			Me.CheckBoxConceptShare_ShowPassword.CheckValueUnchecked = 0
			Me.CheckBoxConceptShare_ShowPassword.ChildControls = CType(resources.GetObject("CheckBoxConceptShare_ShowPassword.ChildControls"), System.Collections.Generic.List(Of Object))
			Me.CheckBoxConceptShare_ShowPassword.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
			Me.CheckBoxConceptShare_ShowPassword.Location = New System.Drawing.Point(369, 30)
			Me.CheckBoxConceptShare_ShowPassword.Name = "CheckBoxConceptShare_ShowPassword"
			Me.CheckBoxConceptShare_ShowPassword.OldestSibling = Nothing
			Me.CheckBoxConceptShare_ShowPassword.SecurityEnabled = True
			Me.CheckBoxConceptShare_ShowPassword.SiblingControls = CType(resources.GetObject("CheckBoxConceptShare_ShowPassword.SiblingControls"), System.Collections.Generic.List(Of Object))
			Me.CheckBoxConceptShare_ShowPassword.Size = New System.Drawing.Size(100, 21)
			Me.CheckBoxConceptShare_ShowPassword.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.CheckBoxConceptShare_ShowPassword.TabIndex = 5
			Me.CheckBoxConceptShare_ShowPassword.TabOnEnter = True
			Me.CheckBoxConceptShare_ShowPassword.Text = "Show Password"
			'
			'CheckBoxConceptShare_IsActive
			'
			Me.CheckBoxConceptShare_IsActive.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.CheckBoxConceptShare_IsActive.BackColor = System.Drawing.Color.White
			'
			'
			'
			Me.CheckBoxConceptShare_IsActive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.CheckBoxConceptShare_IsActive.CheckValue = 0
			Me.CheckBoxConceptShare_IsActive.CheckValueChecked = 1
			Me.CheckBoxConceptShare_IsActive.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
			Me.CheckBoxConceptShare_IsActive.CheckValueUnchecked = 0
			Me.CheckBoxConceptShare_IsActive.ChildControls = CType(resources.GetObject("CheckBoxConceptShare_IsActive.ChildControls"), System.Collections.Generic.List(Of Object))
			Me.CheckBoxConceptShare_IsActive.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
			Me.CheckBoxConceptShare_IsActive.Location = New System.Drawing.Point(85, 57)
			Me.CheckBoxConceptShare_IsActive.Name = "CheckBoxConceptShare_IsActive"
			Me.CheckBoxConceptShare_IsActive.OldestSibling = Nothing
			Me.CheckBoxConceptShare_IsActive.SecurityEnabled = True
			Me.CheckBoxConceptShare_IsActive.SiblingControls = CType(resources.GetObject("CheckBoxConceptShare_IsActive.SiblingControls"), System.Collections.Generic.List(Of Object))
			Me.CheckBoxConceptShare_IsActive.Size = New System.Drawing.Size(384, 21)
			Me.CheckBoxConceptShare_IsActive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.CheckBoxConceptShare_IsActive.TabIndex = 6
			Me.CheckBoxConceptShare_IsActive.TabOnEnter = True
			Me.CheckBoxConceptShare_IsActive.Text = "Is Active"
			'
			'ButtonConceptShare_UpdateUser
			'
			Me.ButtonConceptShare_UpdateUser.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
			Me.ButtonConceptShare_UpdateUser.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
			Me.ButtonConceptShare_UpdateUser.Location = New System.Drawing.Point(85, 4)
			Me.ButtonConceptShare_UpdateUser.Name = "ButtonConceptShare_UpdateUser"
			Me.ButtonConceptShare_UpdateUser.SecurityEnabled = True
			Me.ButtonConceptShare_UpdateUser.Size = New System.Drawing.Size(75, 20)
			Me.ButtonConceptShare_UpdateUser.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.ButtonConceptShare_UpdateUser.TabIndex = 1
			Me.ButtonConceptShare_UpdateUser.Text = "Update User"
			'
			'ButtonConceptShare_CreateUser
			'
			Me.ButtonConceptShare_CreateUser.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
			Me.ButtonConceptShare_CreateUser.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
			Me.ButtonConceptShare_CreateUser.Location = New System.Drawing.Point(4, 4)
			Me.ButtonConceptShare_CreateUser.Name = "ButtonConceptShare_CreateUser"
			Me.ButtonConceptShare_CreateUser.SecurityEnabled = True
			Me.ButtonConceptShare_CreateUser.Size = New System.Drawing.Size(75, 20)
			Me.ButtonConceptShare_CreateUser.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.ButtonConceptShare_CreateUser.TabIndex = 0
			Me.ButtonConceptShare_CreateUser.Text = "Create User"
			'
			'TextBoxConceptShare_Password
			'
			Me.TextBoxConceptShare_Password.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.TextBoxConceptShare_Password.BackColor = System.Drawing.Color.White
			'
			'
			'
			Me.TextBoxConceptShare_Password.Border.Class = "TextBoxBorder"
			Me.TextBoxConceptShare_Password.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.TextBoxConceptShare_Password.CheckSpellingOnValidate = False
			Me.TextBoxConceptShare_Password.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
			Me.TextBoxConceptShare_Password.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
			Me.TextBoxConceptShare_Password.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
			Me.TextBoxConceptShare_Password.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
			Me.TextBoxConceptShare_Password.FocusHighlightEnabled = True
			Me.TextBoxConceptShare_Password.ForeColor = System.Drawing.Color.Black
			Me.TextBoxConceptShare_Password.Location = New System.Drawing.Point(85, 30)
			Me.TextBoxConceptShare_Password.MaxFileSize = CType(0, Long)
			Me.TextBoxConceptShare_Password.Name = "TextBoxConceptShare_Password"
			Me.TextBoxConceptShare_Password.SecurityEnabled = True
			Me.TextBoxConceptShare_Password.ShowSpellCheckCompleteMessage = True
			Me.TextBoxConceptShare_Password.Size = New System.Drawing.Size(278, 21)
			Me.TextBoxConceptShare_Password.StartingFolderName = Nothing
			Me.TextBoxConceptShare_Password.TabIndex = 4
			Me.TextBoxConceptShare_Password.TabOnEnter = True
			Me.TextBoxConceptShare_Password.UseSystemPasswordChar = True
			'
			'LabelConceptShare_Password
			'
			Me.LabelConceptShare_Password.BackColor = System.Drawing.Color.White
			'
			'
			'
			Me.LabelConceptShare_Password.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.LabelConceptShare_Password.Location = New System.Drawing.Point(4, 30)
			Me.LabelConceptShare_Password.Name = "LabelConceptShare_Password"
			Me.LabelConceptShare_Password.Size = New System.Drawing.Size(75, 21)
			Me.LabelConceptShare_Password.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.LabelConceptShare_Password.TabIndex = 3
			Me.LabelConceptShare_Password.Text = "Password:"
			'
			'TabItemClientPortalUserDetails_ConceptShareTab
			'
			Me.TabItemClientPortalUserDetails_ConceptShareTab.AttachedControl = Me.TabControlPanelConceptShareTab_ConceptShare
			Me.TabItemClientPortalUserDetails_ConceptShareTab.Name = "TabItemClientPortalUserDetails_ConceptShareTab"
			Me.TabItemClientPortalUserDetails_ConceptShareTab.Text = "ConceptShare"
			'
			'TabControlPanelClientDivisionProductAccessTab_ClientDivisionProductAccess
			'
			Me.TabControlPanelClientDivisionProductAccessTab_ClientDivisionProductAccess.Controls.Add(Me.DataGridViewClientDivisionProductAccess_ClientDivisionProductAccess)
			Me.TabControlPanelClientDivisionProductAccessTab_ClientDivisionProductAccess.DisabledBackColor = System.Drawing.Color.Empty
			Me.TabControlPanelClientDivisionProductAccessTab_ClientDivisionProductAccess.Dock = System.Windows.Forms.DockStyle.Fill
			Me.TabControlPanelClientDivisionProductAccessTab_ClientDivisionProductAccess.Location = New System.Drawing.Point(0, 27)
			Me.TabControlPanelClientDivisionProductAccessTab_ClientDivisionProductAccess.Name = "TabControlPanelClientDivisionProductAccessTab_ClientDivisionProductAccess"
			Me.TabControlPanelClientDivisionProductAccessTab_ClientDivisionProductAccess.Padding = New System.Windows.Forms.Padding(1)
			Me.TabControlPanelClientDivisionProductAccessTab_ClientDivisionProductAccess.Size = New System.Drawing.Size(473, 435)
			Me.TabControlPanelClientDivisionProductAccessTab_ClientDivisionProductAccess.Style.BackColor1.Color = System.Drawing.Color.White
			Me.TabControlPanelClientDivisionProductAccessTab_ClientDivisionProductAccess.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
			Me.TabControlPanelClientDivisionProductAccessTab_ClientDivisionProductAccess.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
			Me.TabControlPanelClientDivisionProductAccessTab_ClientDivisionProductAccess.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
			Me.TabControlPanelClientDivisionProductAccessTab_ClientDivisionProductAccess.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
			Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
			Me.TabControlPanelClientDivisionProductAccessTab_ClientDivisionProductAccess.Style.GradientAngle = 90
			Me.TabControlPanelClientDivisionProductAccessTab_ClientDivisionProductAccess.TabIndex = 4
			Me.TabControlPanelClientDivisionProductAccessTab_ClientDivisionProductAccess.TabItem = Me.TabItemClientPortalUserDetails_ClientDivisionProductAccessTab
			'
			'DataGridViewClientDivisionProductAccess_ClientDivisionProductAccess
			'
			Me.DataGridViewClientDivisionProductAccess_ClientDivisionProductAccess.AddFixedColumnCheckItemsToGridMenu = False
			Me.DataGridViewClientDivisionProductAccess_ClientDivisionProductAccess.AllowDragAndDrop = False
			Me.DataGridViewClientDivisionProductAccess_ClientDivisionProductAccess.AllowExtraItemsInGridLookupEdits = True
			Me.DataGridViewClientDivisionProductAccess_ClientDivisionProductAccess.AllowSelectGroupHeaderRow = True
			Me.DataGridViewClientDivisionProductAccess_ClientDivisionProductAccess.AlwaysForceShowRowSelectionOnUserInput = True
			Me.DataGridViewClientDivisionProductAccess_ClientDivisionProductAccess.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.DataGridViewClientDivisionProductAccess_ClientDivisionProductAccess.AutoFilterLookupColumns = False
			Me.DataGridViewClientDivisionProductAccess_ClientDivisionProductAccess.AutoloadRepositoryDatasource = True
			Me.DataGridViewClientDivisionProductAccess_ClientDivisionProductAccess.AutoUpdateViewCaption = True
			Me.DataGridViewClientDivisionProductAccess_ClientDivisionProductAccess.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
			Me.DataGridViewClientDivisionProductAccess_ClientDivisionProductAccess.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
			Me.DataGridViewClientDivisionProductAccess_ClientDivisionProductAccess.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
			Me.DataGridViewClientDivisionProductAccess_ClientDivisionProductAccess.ItemDescription = ""
			Me.DataGridViewClientDivisionProductAccess_ClientDivisionProductAccess.Location = New System.Drawing.Point(4, 4)
			Me.DataGridViewClientDivisionProductAccess_ClientDivisionProductAccess.MultiSelect = True
			Me.DataGridViewClientDivisionProductAccess_ClientDivisionProductAccess.Name = "DataGridViewClientDivisionProductAccess_ClientDivisionProductAccess"
			Me.DataGridViewClientDivisionProductAccess_ClientDivisionProductAccess.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
			Me.DataGridViewClientDivisionProductAccess_ClientDivisionProductAccess.RunStandardValidation = True
			Me.DataGridViewClientDivisionProductAccess_ClientDivisionProductAccess.ShowColumnMenuOnRightClick = False
			Me.DataGridViewClientDivisionProductAccess_ClientDivisionProductAccess.ShowSelectDeselectAllButtons = False
			Me.DataGridViewClientDivisionProductAccess_ClientDivisionProductAccess.Size = New System.Drawing.Size(465, 427)
			Me.DataGridViewClientDivisionProductAccess_ClientDivisionProductAccess.TabIndex = 0
			Me.DataGridViewClientDivisionProductAccess_ClientDivisionProductAccess.UseEmbeddedNavigator = False
			Me.DataGridViewClientDivisionProductAccess_ClientDivisionProductAccess.ViewCaptionHeight = -1
			'
			'TabItemClientPortalUserDetails_ClientDivisionProductAccessTab
			'
			Me.TabItemClientPortalUserDetails_ClientDivisionProductAccessTab.AttachedControl = Me.TabControlPanelClientDivisionProductAccessTab_ClientDivisionProductAccess
			Me.TabItemClientPortalUserDetails_ClientDivisionProductAccessTab.Name = "TabItemClientPortalUserDetails_ClientDivisionProductAccessTab"
			Me.TabItemClientPortalUserDetails_ClientDivisionProductAccessTab.Text = "C\D\P Access"
			'
			'TabControlPanelModuleAccessTab_ModuleAccess
			'
			Me.TabControlPanelModuleAccessTab_ModuleAccess.Controls.Add(Me.CheckBoxModuleAccess_IsBlockedFromClientPortal)
			Me.TabControlPanelModuleAccessTab_ModuleAccess.Controls.Add(Me.AdvTreeModuleAccess_Modules)
			Me.TabControlPanelModuleAccessTab_ModuleAccess.Controls.Add(Me.LabelModuleAccess_Options)
			Me.TabControlPanelModuleAccessTab_ModuleAccess.Controls.Add(Me.CheckBoxModuleAccess_IsBlocked)
			Me.TabControlPanelModuleAccessTab_ModuleAccess.DisabledBackColor = System.Drawing.Color.Empty
			Me.TabControlPanelModuleAccessTab_ModuleAccess.Dock = System.Windows.Forms.DockStyle.Fill
			Me.TabControlPanelModuleAccessTab_ModuleAccess.Location = New System.Drawing.Point(0, 27)
			Me.TabControlPanelModuleAccessTab_ModuleAccess.Name = "TabControlPanelModuleAccessTab_ModuleAccess"
			Me.TabControlPanelModuleAccessTab_ModuleAccess.Padding = New System.Windows.Forms.Padding(1)
			Me.TabControlPanelModuleAccessTab_ModuleAccess.Size = New System.Drawing.Size(473, 435)
			Me.TabControlPanelModuleAccessTab_ModuleAccess.Style.BackColor1.Color = System.Drawing.Color.White
			Me.TabControlPanelModuleAccessTab_ModuleAccess.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
			Me.TabControlPanelModuleAccessTab_ModuleAccess.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
			Me.TabControlPanelModuleAccessTab_ModuleAccess.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
			Me.TabControlPanelModuleAccessTab_ModuleAccess.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
			Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
			Me.TabControlPanelModuleAccessTab_ModuleAccess.Style.GradientAngle = 90
			Me.TabControlPanelModuleAccessTab_ModuleAccess.TabIndex = 3
			Me.TabControlPanelModuleAccessTab_ModuleAccess.TabItem = Me.TabItemClientPortalUserDetails_ModuleAccessTab
			'
			'CheckBoxModuleAccess_IsBlockedFromClientPortal
			'
			Me.CheckBoxModuleAccess_IsBlockedFromClientPortal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.CheckBoxModuleAccess_IsBlockedFromClientPortal.BackColor = System.Drawing.Color.White
			'
			'
			'
			Me.CheckBoxModuleAccess_IsBlockedFromClientPortal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.CheckBoxModuleAccess_IsBlockedFromClientPortal.CheckValue = 0
			Me.CheckBoxModuleAccess_IsBlockedFromClientPortal.CheckValueChecked = 1
			Me.CheckBoxModuleAccess_IsBlockedFromClientPortal.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
			Me.CheckBoxModuleAccess_IsBlockedFromClientPortal.CheckValueUnchecked = 0
			Me.CheckBoxModuleAccess_IsBlockedFromClientPortal.ChildControls = CType(resources.GetObject("CheckBoxModuleAccess_IsBlockedFromClientPortal.ChildControls"), System.Collections.Generic.List(Of Object))
			Me.CheckBoxModuleAccess_IsBlockedFromClientPortal.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
			Me.CheckBoxModuleAccess_IsBlockedFromClientPortal.Location = New System.Drawing.Point(4, 4)
			Me.CheckBoxModuleAccess_IsBlockedFromClientPortal.Name = "CheckBoxModuleAccess_IsBlockedFromClientPortal"
			Me.CheckBoxModuleAccess_IsBlockedFromClientPortal.OldestSibling = Nothing
			Me.CheckBoxModuleAccess_IsBlockedFromClientPortal.SecurityEnabled = True
			Me.CheckBoxModuleAccess_IsBlockedFromClientPortal.SiblingControls = CType(resources.GetObject("CheckBoxModuleAccess_IsBlockedFromClientPortal.SiblingControls"), System.Collections.Generic.List(Of Object))
			Me.CheckBoxModuleAccess_IsBlockedFromClientPortal.Size = New System.Drawing.Size(378, 20)
			Me.CheckBoxModuleAccess_IsBlockedFromClientPortal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.CheckBoxModuleAccess_IsBlockedFromClientPortal.TabIndex = 16
			Me.CheckBoxModuleAccess_IsBlockedFromClientPortal.TabOnEnter = True
			Me.CheckBoxModuleAccess_IsBlockedFromClientPortal.Text = "Is Blocked From Client Portal"
			'
			'AdvTreeModuleAccess_Modules
			'
			Me.AdvTreeModuleAccess_Modules.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline
			Me.AdvTreeModuleAccess_Modules.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.AdvTreeModuleAccess_Modules.BackColor = System.Drawing.SystemColors.Window
			'
			'
			'
			Me.AdvTreeModuleAccess_Modules.BackgroundStyle.Class = "TreeBorderKey"
			Me.AdvTreeModuleAccess_Modules.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.AdvTreeModuleAccess_Modules.DragDropEnabled = False
			Me.AdvTreeModuleAccess_Modules.DragDropNodeCopyEnabled = False
			Me.AdvTreeModuleAccess_Modules.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
			Me.AdvTreeModuleAccess_Modules.Location = New System.Drawing.Point(4, 30)
			Me.AdvTreeModuleAccess_Modules.MultiSelect = True
			Me.AdvTreeModuleAccess_Modules.MultiSelectRule = DevComponents.AdvTree.eMultiSelectRule.AnyNode
			Me.AdvTreeModuleAccess_Modules.Name = "AdvTreeModuleAccess_Modules"
			Me.AdvTreeModuleAccess_Modules.NodesConnector = Me.NodeConnector1
			Me.AdvTreeModuleAccess_Modules.NodeStyle = Me.ElementStyle1
			Me.AdvTreeModuleAccess_Modules.PathSeparator = ";"
			Me.AdvTreeModuleAccess_Modules.Size = New System.Drawing.Size(378, 401)
			Me.AdvTreeModuleAccess_Modules.Styles.Add(Me.ElementStyle1)
			Me.AdvTreeModuleAccess_Modules.TabIndex = 15
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
			'LabelModuleAccess_Options
			'
			Me.LabelModuleAccess_Options.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.LabelModuleAccess_Options.BackColor = System.Drawing.Color.White
			'
			'
			'
			Me.LabelModuleAccess_Options.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
			Me.LabelModuleAccess_Options.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
			Me.LabelModuleAccess_Options.BackgroundStyle.BorderBottomWidth = 1
			Me.LabelModuleAccess_Options.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
			Me.LabelModuleAccess_Options.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
			Me.LabelModuleAccess_Options.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
			Me.LabelModuleAccess_Options.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.LabelModuleAccess_Options.Location = New System.Drawing.Point(388, 30)
			Me.LabelModuleAccess_Options.Name = "LabelModuleAccess_Options"
			Me.LabelModuleAccess_Options.Size = New System.Drawing.Size(81, 20)
			Me.LabelModuleAccess_Options.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.LabelModuleAccess_Options.TabIndex = 3
			Me.LabelModuleAccess_Options.Text = "Options"
			'
			'CheckBoxModuleAccess_IsBlocked
			'
			Me.CheckBoxModuleAccess_IsBlocked.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.CheckBoxModuleAccess_IsBlocked.BackColor = System.Drawing.Color.White
			'
			'
			'
			Me.CheckBoxModuleAccess_IsBlocked.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.CheckBoxModuleAccess_IsBlocked.CheckValue = 0
			Me.CheckBoxModuleAccess_IsBlocked.CheckValueChecked = 1
			Me.CheckBoxModuleAccess_IsBlocked.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
			Me.CheckBoxModuleAccess_IsBlocked.CheckValueUnchecked = 0
			Me.CheckBoxModuleAccess_IsBlocked.ChildControls = CType(resources.GetObject("CheckBoxModuleAccess_IsBlocked.ChildControls"), System.Collections.Generic.List(Of Object))
			Me.CheckBoxModuleAccess_IsBlocked.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
			Me.CheckBoxModuleAccess_IsBlocked.Location = New System.Drawing.Point(388, 56)
			Me.CheckBoxModuleAccess_IsBlocked.Name = "CheckBoxModuleAccess_IsBlocked"
			Me.CheckBoxModuleAccess_IsBlocked.OldestSibling = Nothing
			Me.CheckBoxModuleAccess_IsBlocked.SecurityEnabled = True
			Me.CheckBoxModuleAccess_IsBlocked.SiblingControls = CType(resources.GetObject("CheckBoxModuleAccess_IsBlocked.SiblingControls"), System.Collections.Generic.List(Of Object))
			Me.CheckBoxModuleAccess_IsBlocked.Size = New System.Drawing.Size(81, 20)
			Me.CheckBoxModuleAccess_IsBlocked.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.CheckBoxModuleAccess_IsBlocked.TabIndex = 4
			Me.CheckBoxModuleAccess_IsBlocked.TabOnEnter = True
			Me.CheckBoxModuleAccess_IsBlocked.Text = "Is Blocked"
			'
			'TabItemClientPortalUserDetails_ModuleAccessTab
			'
			Me.TabItemClientPortalUserDetails_ModuleAccessTab.AttachedControl = Me.TabControlPanelModuleAccessTab_ModuleAccess
			Me.TabItemClientPortalUserDetails_ModuleAccessTab.Name = "TabItemClientPortalUserDetails_ModuleAccessTab"
			Me.TabItemClientPortalUserDetails_ModuleAccessTab.Text = "Module Access"
			'
			'ClientPortalUserSetupForm
			'
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(772, 540)
			Me.Controls.Add(Me.RibbonBarMergeContainerRightSection_Options)
			Me.Controls.Add(Me.PanelForm_RightSection)
			Me.Controls.Add(Me.ExpandableSplitterControlForm_LeftRight)
			Me.Controls.Add(Me.PanelForm_LeftSection)
			Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
			Me.Name = "ClientPortalUserSetupForm"
			Me.Text = "Client Portal User Setup"
			Me.RibbonBarMergeContainerRightSection_Options.ResumeLayout(False)
			CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
			Me.PanelForm_LeftSection.ResumeLayout(False)
			CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
			Me.PanelForm_RightSection.ResumeLayout(False)
			CType(Me.TabControlRightSection_ClientPortalUserDetails, System.ComponentModel.ISupportInitialize).EndInit()
			Me.TabControlRightSection_ClientPortalUserDetails.ResumeLayout(False)
			Me.TabControlPanelConceptShareTab_ConceptShare.ResumeLayout(False)
			Me.TabControlPanelClientDivisionProductAccessTab_ClientDivisionProductAccess.ResumeLayout(False)
			Me.TabControlPanelModuleAccessTab_ModuleAccess.ResumeLayout(False)
			CType(Me.AdvTreeModuleAccess_Modules, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		Friend WithEvents DataGridViewLeftSection_ClientPortalUsers As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
		Friend WithEvents RibbonBarMergeContainerRightSection_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
		Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
		Friend WithEvents ButtonItemActions_Add As DevComponents.DotNetBar.ButtonItem
		Friend WithEvents ButtonItemActions_Update As DevComponents.DotNetBar.ButtonItem
		Friend WithEvents ButtonItemActions_Delete As DevComponents.DotNetBar.ButtonItem
		Friend WithEvents PanelForm_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
		Friend WithEvents ExpandableSplitterControlForm_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
		Friend WithEvents PanelForm_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
		Friend WithEvents TabControlRightSection_ClientPortalUserDetails As AdvantageFramework.WinForm.Presentation.Controls.TabControl
		Friend WithEvents TabControlPanelModuleAccessTab_ModuleAccess As DevComponents.DotNetBar.TabControlPanel
		Friend WithEvents LabelModuleAccess_Options As AdvantageFramework.WinForm.Presentation.Controls.Label
		Friend WithEvents CheckBoxModuleAccess_IsBlocked As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
		Friend WithEvents TabItemClientPortalUserDetails_ModuleAccessTab As DevComponents.DotNetBar.TabItem
		Friend WithEvents RibbonBarOptions_View As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
		Friend WithEvents ButtonItemView_ExpandAll As DevComponents.DotNetBar.ButtonItem
		Friend WithEvents ButtonItemView_CollapseAll As DevComponents.DotNetBar.ButtonItem
		Friend WithEvents AdvTreeModuleAccess_Modules As DevComponents.AdvTree.AdvTree
		Friend WithEvents NodeConnector1 As DevComponents.AdvTree.NodeConnector
		Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
		Friend WithEvents CheckBoxModuleAccess_IsBlockedFromClientPortal As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
		Friend WithEvents ButtonItemActions_ChangePassword As DevComponents.DotNetBar.ButtonItem
		Friend WithEvents TabControlPanelClientDivisionProductAccessTab_ClientDivisionProductAccess As DevComponents.DotNetBar.TabControlPanel
		Friend WithEvents DataGridViewClientDivisionProductAccess_ClientDivisionProductAccess As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
		Friend WithEvents TabItemClientPortalUserDetails_ClientDivisionProductAccessTab As DevComponents.DotNetBar.TabItem
		Friend WithEvents ButtonItemActions_RefreshCDPAccess As DevComponents.DotNetBar.ButtonItem
		Friend WithEvents TabControlPanelConceptShareTab_ConceptShare As DevComponents.DotNetBar.TabControlPanel
		Friend WithEvents TabItemClientPortalUserDetails_ConceptShareTab As DevComponents.DotNetBar.TabItem
		Friend WithEvents CheckBoxConceptShare_IsActive As WinForm.Presentation.Controls.CheckBox
		Friend WithEvents ButtonConceptShare_UpdateUser As WinForm.Presentation.Controls.Button
		Friend WithEvents ButtonConceptShare_CreateUser As WinForm.Presentation.Controls.Button
		Friend WithEvents TextBoxConceptShare_Password As WinForm.Presentation.Controls.TextBox
		Friend WithEvents LabelConceptShare_Password As WinForm.Presentation.Controls.Label
		Friend WithEvents TextBoxForm_Email As WinForm.Presentation.Controls.TextBox
		Friend WithEvents LabelForm_Email As WinForm.Presentation.Controls.Label
		Friend WithEvents TextBoxForm_Name As WinForm.Presentation.Controls.TextBox
		Friend WithEvents LabelForm_FullName As WinForm.Presentation.Controls.Label
		Friend WithEvents ButtonConceptShare_RemoveUser As WinForm.Presentation.Controls.Button
		Friend WithEvents CheckBoxConceptShare_ShowPassword As WinForm.Presentation.Controls.CheckBox
	End Class

End Namespace