Namespace Security.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class LicenseKeySetupForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LicenseKeySetupForm))
            Me.DataGridViewLeftSection_Clients = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.PanelForm_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ExpandableSplitterControlForm_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.PanelRightSection_RightBottomSection = New System.Windows.Forms.Panel()
            Me.DataGridViewRightBottomSection_LicenseKeyHistory = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterControlRightSection_MiddleBottom = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelRightSection_RightMiddleSection = New System.Windows.Forms.Panel()
            Me.LabelRightMiddleSection_ComscoreData = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DataGridViewRightMiddleSection_ClientContacts = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.PanelRightSection_RightTopSection = New System.Windows.Forms.Panel()
            Me.LabelRightTopSection_ClientInformation = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelRightTopSection_ClientAddress = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_ComscoreActions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemComscoreActions_CreateNewLicenseKey = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemComscoreActions_CreateLicenseKeyFile = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_CreateNewLicenseKey = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_CreateLicenseKeyFile = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_RenewLicenseKey = New DevComponents.DotNetBar.ButtonItem()
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_LeftSection.SuspendLayout()
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_RightSection.SuspendLayout()
            Me.PanelRightSection_RightBottomSection.SuspendLayout()
            Me.PanelRightSection_RightMiddleSection.SuspendLayout()
            Me.PanelRightSection_RightTopSection.SuspendLayout()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.SuspendLayout()
            '
            'DataGridViewLeftSection_Clients
            '
            Me.DataGridViewLeftSection_Clients.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewLeftSection_Clients.AllowDragAndDrop = False
            Me.DataGridViewLeftSection_Clients.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewLeftSection_Clients.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_Clients.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_Clients.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_Clients.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_Clients.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_Clients.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_Clients.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_Clients.DataSource = Nothing
            Me.DataGridViewLeftSection_Clients.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_Clients.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_Clients.ItemDescription = ""
            Me.DataGridViewLeftSection_Clients.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewLeftSection_Clients.MultiSelect = True
            Me.DataGridViewLeftSection_Clients.Name = "DataGridViewLeftSection_Clients"
            Me.DataGridViewLeftSection_Clients.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_Clients.RunStandardValidation = True
            Me.DataGridViewLeftSection_Clients.ShowColumnMenuOnRightClick = False
            Me.DataGridViewLeftSection_Clients.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_Clients.Size = New System.Drawing.Size(257, 493)
            Me.DataGridViewLeftSection_Clients.TabIndex = 0
            Me.DataGridViewLeftSection_Clients.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_Clients.ViewCaptionHeight = -1
            '
            'PanelForm_LeftSection
            '
            Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_Clients)
            Me.PanelForm_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelForm_LeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_LeftSection.Name = "PanelForm_LeftSection"
            Me.PanelForm_LeftSection.Size = New System.Drawing.Size(274, 517)
            Me.PanelForm_LeftSection.TabIndex = 9
            '
            'ExpandableSplitterControlForm_LeftRight
            '
            Me.ExpandableSplitterControlForm_LeftRight.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlForm_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControlForm_LeftRight.ExpandableControl = Me.PanelForm_LeftSection
            Me.ExpandableSplitterControlForm_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlForm_LeftRight.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlForm_LeftRight.ForeColor = System.Drawing.Color.Black
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
            Me.ExpandableSplitterControlForm_LeftRight.Location = New System.Drawing.Point(274, 0)
            Me.ExpandableSplitterControlForm_LeftRight.Name = "ExpandableSplitterControlForm_LeftRight"
            Me.ExpandableSplitterControlForm_LeftRight.Size = New System.Drawing.Size(6, 517)
            Me.ExpandableSplitterControlForm_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlForm_LeftRight.TabIndex = 10
            Me.ExpandableSplitterControlForm_LeftRight.TabStop = False
            '
            'PanelForm_RightSection
            '
            Me.PanelForm_RightSection.Controls.Add(Me.PanelRightSection_RightBottomSection)
            Me.PanelForm_RightSection.Controls.Add(Me.ExpandableSplitterControlRightSection_MiddleBottom)
            Me.PanelForm_RightSection.Controls.Add(Me.PanelRightSection_RightMiddleSection)
            Me.PanelForm_RightSection.Controls.Add(Me.PanelRightSection_RightTopSection)
            Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_RightSection.Location = New System.Drawing.Point(280, 0)
            Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
            Me.PanelForm_RightSection.Size = New System.Drawing.Size(898, 517)
            Me.PanelForm_RightSection.TabIndex = 11
            '
            'PanelRightSection_RightBottomSection
            '
            Me.PanelRightSection_RightBottomSection.Controls.Add(Me.DataGridViewRightBottomSection_LicenseKeyHistory)
            Me.PanelRightSection_RightBottomSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelRightSection_RightBottomSection.Location = New System.Drawing.Point(2, 268)
            Me.PanelRightSection_RightBottomSection.Name = "PanelRightSection_RightBottomSection"
            Me.PanelRightSection_RightBottomSection.Size = New System.Drawing.Size(894, 247)
            Me.PanelRightSection_RightBottomSection.TabIndex = 16
            '
            'DataGridViewRightBottomSection_LicenseKeyHistory
            '
            Me.DataGridViewRightBottomSection_LicenseKeyHistory.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewRightBottomSection_LicenseKeyHistory.AllowDragAndDrop = False
            Me.DataGridViewRightBottomSection_LicenseKeyHistory.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewRightBottomSection_LicenseKeyHistory.AllowSelectGroupHeaderRow = True
            Me.DataGridViewRightBottomSection_LicenseKeyHistory.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewRightBottomSection_LicenseKeyHistory.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRightBottomSection_LicenseKeyHistory.AutoFilterLookupColumns = False
            Me.DataGridViewRightBottomSection_LicenseKeyHistory.AutoloadRepositoryDatasource = True
            Me.DataGridViewRightBottomSection_LicenseKeyHistory.AutoUpdateViewCaption = True
            Me.DataGridViewRightBottomSection_LicenseKeyHistory.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewRightBottomSection_LicenseKeyHistory.DataSource = Nothing
            Me.DataGridViewRightBottomSection_LicenseKeyHistory.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewRightBottomSection_LicenseKeyHistory.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRightBottomSection_LicenseKeyHistory.ItemDescription = ""
            Me.DataGridViewRightBottomSection_LicenseKeyHistory.Location = New System.Drawing.Point(4, 3)
            Me.DataGridViewRightBottomSection_LicenseKeyHistory.MultiSelect = True
            Me.DataGridViewRightBottomSection_LicenseKeyHistory.Name = "DataGridViewRightBottomSection_LicenseKeyHistory"
            Me.DataGridViewRightBottomSection_LicenseKeyHistory.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewRightBottomSection_LicenseKeyHistory.RunStandardValidation = True
            Me.DataGridViewRightBottomSection_LicenseKeyHistory.ShowColumnMenuOnRightClick = False
            Me.DataGridViewRightBottomSection_LicenseKeyHistory.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRightBottomSection_LicenseKeyHistory.Size = New System.Drawing.Size(880, 234)
            Me.DataGridViewRightBottomSection_LicenseKeyHistory.TabIndex = 12
            Me.DataGridViewRightBottomSection_LicenseKeyHistory.UseEmbeddedNavigator = False
            Me.DataGridViewRightBottomSection_LicenseKeyHistory.ViewCaptionHeight = -1
            '
            'ExpandableSplitterControlRightSection_MiddleBottom
            '
            Me.ExpandableSplitterControlRightSection_MiddleBottom.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlRightSection_MiddleBottom.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlRightSection_MiddleBottom.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlRightSection_MiddleBottom.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControlRightSection_MiddleBottom.Dock = System.Windows.Forms.DockStyle.Top
            Me.ExpandableSplitterControlRightSection_MiddleBottom.Expandable = False
            Me.ExpandableSplitterControlRightSection_MiddleBottom.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlRightSection_MiddleBottom.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlRightSection_MiddleBottom.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlRightSection_MiddleBottom.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlRightSection_MiddleBottom.ForeColor = System.Drawing.Color.Black
            Me.ExpandableSplitterControlRightSection_MiddleBottom.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlRightSection_MiddleBottom.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlRightSection_MiddleBottom.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlRightSection_MiddleBottom.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlRightSection_MiddleBottom.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControlRightSection_MiddleBottom.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControlRightSection_MiddleBottom.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControlRightSection_MiddleBottom.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControlRightSection_MiddleBottom.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlRightSection_MiddleBottom.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlRightSection_MiddleBottom.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlRightSection_MiddleBottom.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlRightSection_MiddleBottom.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlRightSection_MiddleBottom.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlRightSection_MiddleBottom.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlRightSection_MiddleBottom.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlRightSection_MiddleBottom.Location = New System.Drawing.Point(2, 262)
            Me.ExpandableSplitterControlRightSection_MiddleBottom.Name = "ExpandableSplitterControlRightSection_MiddleBottom"
            Me.ExpandableSplitterControlRightSection_MiddleBottom.Size = New System.Drawing.Size(894, 6)
            Me.ExpandableSplitterControlRightSection_MiddleBottom.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlRightSection_MiddleBottom.TabIndex = 15
            Me.ExpandableSplitterControlRightSection_MiddleBottom.TabStop = False
            '
            'PanelRightSection_RightMiddleSection
            '
            Me.PanelRightSection_RightMiddleSection.Controls.Add(Me.LabelRightMiddleSection_ComscoreData)
            Me.PanelRightSection_RightMiddleSection.Controls.Add(Me.DataGridViewRightMiddleSection_ClientContacts)
            Me.PanelRightSection_RightMiddleSection.Dock = System.Windows.Forms.DockStyle.Top
            Me.PanelRightSection_RightMiddleSection.Location = New System.Drawing.Point(2, 111)
            Me.PanelRightSection_RightMiddleSection.Name = "PanelRightSection_RightMiddleSection"
            Me.PanelRightSection_RightMiddleSection.Size = New System.Drawing.Size(894, 151)
            Me.PanelRightSection_RightMiddleSection.TabIndex = 14
            '
            'LabelRightMiddleSection_ComscoreData
            '
            Me.LabelRightMiddleSection_ComscoreData.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelRightMiddleSection_ComscoreData.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRightMiddleSection_ComscoreData.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRightMiddleSection_ComscoreData.Location = New System.Drawing.Point(4, 3)
            Me.LabelRightMiddleSection_ComscoreData.Name = "LabelRightMiddleSection_ComscoreData"
            Me.LabelRightMiddleSection_ComscoreData.Size = New System.Drawing.Size(880, 20)
            Me.LabelRightMiddleSection_ComscoreData.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRightMiddleSection_ComscoreData.TabIndex = 12
            Me.LabelRightMiddleSection_ComscoreData.Text = "Agency: {0} Comscore Client ID: {1}" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
            Me.LabelRightMiddleSection_ComscoreData.TextLineAlignment = System.Drawing.StringAlignment.Near
            '
            'DataGridViewRightMiddleSection_ClientContacts
            '
            Me.DataGridViewRightMiddleSection_ClientContacts.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewRightMiddleSection_ClientContacts.AllowDragAndDrop = False
            Me.DataGridViewRightMiddleSection_ClientContacts.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewRightMiddleSection_ClientContacts.AllowSelectGroupHeaderRow = True
            Me.DataGridViewRightMiddleSection_ClientContacts.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewRightMiddleSection_ClientContacts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRightMiddleSection_ClientContacts.AutoFilterLookupColumns = False
            Me.DataGridViewRightMiddleSection_ClientContacts.AutoloadRepositoryDatasource = True
            Me.DataGridViewRightMiddleSection_ClientContacts.AutoUpdateViewCaption = True
            Me.DataGridViewRightMiddleSection_ClientContacts.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewRightMiddleSection_ClientContacts.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewRightMiddleSection_ClientContacts.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRightMiddleSection_ClientContacts.ItemDescription = ""
            Me.DataGridViewRightMiddleSection_ClientContacts.Location = New System.Drawing.Point(4, 29)
            Me.DataGridViewRightMiddleSection_ClientContacts.MultiSelect = True
            Me.DataGridViewRightMiddleSection_ClientContacts.Name = "DataGridViewRightMiddleSection_ClientContacts"
            Me.DataGridViewRightMiddleSection_ClientContacts.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewRightMiddleSection_ClientContacts.RunStandardValidation = True
            Me.DataGridViewRightMiddleSection_ClientContacts.ShowColumnMenuOnRightClick = False
            Me.DataGridViewRightMiddleSection_ClientContacts.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRightMiddleSection_ClientContacts.Size = New System.Drawing.Size(880, 119)
            Me.DataGridViewRightMiddleSection_ClientContacts.TabIndex = 11
            Me.DataGridViewRightMiddleSection_ClientContacts.UseEmbeddedNavigator = False
            Me.DataGridViewRightMiddleSection_ClientContacts.ViewCaptionHeight = -1
            '
            'PanelRightSection_RightTopSection
            '
            Me.PanelRightSection_RightTopSection.Controls.Add(Me.LabelRightTopSection_ClientInformation)
            Me.PanelRightSection_RightTopSection.Controls.Add(Me.LabelRightTopSection_ClientAddress)
            Me.PanelRightSection_RightTopSection.Dock = System.Windows.Forms.DockStyle.Top
            Me.PanelRightSection_RightTopSection.Location = New System.Drawing.Point(2, 2)
            Me.PanelRightSection_RightTopSection.Name = "PanelRightSection_RightTopSection"
            Me.PanelRightSection_RightTopSection.Size = New System.Drawing.Size(894, 109)
            Me.PanelRightSection_RightTopSection.TabIndex = 13
            '
            'LabelRightTopSection_ClientInformation
            '
            Me.LabelRightTopSection_ClientInformation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelRightTopSection_ClientInformation.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRightTopSection_ClientInformation.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelRightTopSection_ClientInformation.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelRightTopSection_ClientInformation.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelRightTopSection_ClientInformation.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelRightTopSection_ClientInformation.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelRightTopSection_ClientInformation.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelRightTopSection_ClientInformation.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRightTopSection_ClientInformation.Location = New System.Drawing.Point(4, 10)
            Me.LabelRightTopSection_ClientInformation.Name = "LabelRightTopSection_ClientInformation"
            Me.LabelRightTopSection_ClientInformation.Size = New System.Drawing.Size(880, 20)
            Me.LabelRightTopSection_ClientInformation.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRightTopSection_ClientInformation.TabIndex = 9
            Me.LabelRightTopSection_ClientInformation.Text = "Client Information"
            '
            'LabelRightTopSection_ClientAddress
            '
            Me.LabelRightTopSection_ClientAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelRightTopSection_ClientAddress.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRightTopSection_ClientAddress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRightTopSection_ClientAddress.Location = New System.Drawing.Point(4, 36)
            Me.LabelRightTopSection_ClientAddress.Name = "LabelRightTopSection_ClientAddress"
            Me.LabelRightTopSection_ClientAddress.Size = New System.Drawing.Size(880, 70)
            Me.LabelRightTopSection_ClientAddress.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRightTopSection_ClientAddress.TabIndex = 10
            Me.LabelRightTopSection_ClientAddress.Text = "Address: {0}" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Address 2: {1}" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "County: {2}" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "City: {3} State: {4} Zip: {5}" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Country" &
    ": {6}"
            Me.LabelRightTopSection_ClientAddress.TextLineAlignment = System.Drawing.StringAlignment.Near
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_ComscoreActions)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(280, 0)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(856, 98)
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
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 15
            Me.RibbonBarMergeContainerForm_Options.Visible = False
            '
            'RibbonBarOptions_ComscoreActions
            '
            Me.RibbonBarOptions_ComscoreActions.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_ComscoreActions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ComscoreActions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ComscoreActions.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_ComscoreActions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_ComscoreActions.DragDropSupport = True
            Me.RibbonBarOptions_ComscoreActions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemComscoreActions_CreateNewLicenseKey, Me.ButtonItemComscoreActions_CreateLicenseKeyFile})
            Me.RibbonBarOptions_ComscoreActions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_ComscoreActions.Location = New System.Drawing.Point(383, 0)
            Me.RibbonBarOptions_ComscoreActions.Name = "RibbonBarOptions_ComscoreActions"
            Me.RibbonBarOptions_ComscoreActions.SecurityEnabled = True
            Me.RibbonBarOptions_ComscoreActions.Size = New System.Drawing.Size(265, 98)
            Me.RibbonBarOptions_ComscoreActions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_ComscoreActions.TabIndex = 1
            Me.RibbonBarOptions_ComscoreActions.Text = "Comscore Actions"
            '
            '
            '
            Me.RibbonBarOptions_ComscoreActions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ComscoreActions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ComscoreActions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemComscoreActions_CreateNewLicenseKey
            '
            Me.ButtonItemComscoreActions_CreateNewLicenseKey.BeginGroup = True
            Me.ButtonItemComscoreActions_CreateNewLicenseKey.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemComscoreActions_CreateNewLicenseKey.Name = "ButtonItemComscoreActions_CreateNewLicenseKey"
            Me.ButtonItemComscoreActions_CreateNewLicenseKey.RibbonWordWrap = False
            Me.ButtonItemComscoreActions_CreateNewLicenseKey.SubItemsExpandWidth = 14
            Me.ButtonItemComscoreActions_CreateNewLicenseKey.Text = "Create New License Key"
            '
            'ButtonItemComscoreActions_CreateLicenseKeyFile
            '
            Me.ButtonItemComscoreActions_CreateLicenseKeyFile.BeginGroup = True
            Me.ButtonItemComscoreActions_CreateLicenseKeyFile.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemComscoreActions_CreateLicenseKeyFile.Name = "ButtonItemComscoreActions_CreateLicenseKeyFile"
            Me.ButtonItemComscoreActions_CreateLicenseKeyFile.RibbonWordWrap = False
            Me.ButtonItemComscoreActions_CreateLicenseKeyFile.SubItemsExpandWidth = 14
            Me.ButtonItemComscoreActions_CreateLicenseKeyFile.Text = "Create License Key File"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_CreateNewLicenseKey, Me.ButtonItemActions_RenewLicenseKey, Me.ButtonItemActions_CreateLicenseKeyFile})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(383, 98)
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
            'ButtonItemActions_CreateNewLicenseKey
            '
            Me.ButtonItemActions_CreateNewLicenseKey.BeginGroup = True
            Me.ButtonItemActions_CreateNewLicenseKey.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_CreateNewLicenseKey.Name = "ButtonItemActions_CreateNewLicenseKey"
            Me.ButtonItemActions_CreateNewLicenseKey.RibbonWordWrap = False
            Me.ButtonItemActions_CreateNewLicenseKey.SubItemsExpandWidth = 14
            Me.ButtonItemActions_CreateNewLicenseKey.Text = "Create New License Key"
            '
            'ButtonItemActions_CreateLicenseKeyFile
            '
            Me.ButtonItemActions_CreateLicenseKeyFile.BeginGroup = True
            Me.ButtonItemActions_CreateLicenseKeyFile.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_CreateLicenseKeyFile.Name = "ButtonItemActions_CreateLicenseKeyFile"
            Me.ButtonItemActions_CreateLicenseKeyFile.RibbonWordWrap = False
            Me.ButtonItemActions_CreateLicenseKeyFile.SubItemsExpandWidth = 14
            Me.ButtonItemActions_CreateLicenseKeyFile.Text = "Create License Key File"
            '
            'ButtonItemActions_RenewLicenseKey
            '
            Me.ButtonItemActions_RenewLicenseKey.BeginGroup = True
            Me.ButtonItemActions_RenewLicenseKey.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_RenewLicenseKey.Name = "ButtonItemActions_RenewLicenseKey"
            Me.ButtonItemActions_RenewLicenseKey.RibbonWordWrap = False
            Me.ButtonItemActions_RenewLicenseKey.SubItemsExpandWidth = 14
            Me.ButtonItemActions_RenewLicenseKey.Text = "Renew License Key"
            '
            'LicenseKeySetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1178, 517)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.PanelForm_RightSection)
            Me.Controls.Add(Me.ExpandableSplitterControlForm_LeftRight)
            Me.Controls.Add(Me.PanelForm_LeftSection)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "LicenseKeySetupForm"
            Me.Text = "License Key Setup"
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_LeftSection.ResumeLayout(False)
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_RightSection.ResumeLayout(False)
            Me.PanelRightSection_RightBottomSection.ResumeLayout(False)
            Me.PanelRightSection_RightMiddleSection.ResumeLayout(False)
            Me.PanelRightSection_RightTopSection.ResumeLayout(False)
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewLeftSection_Clients As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents PanelForm_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ExpandableSplitterControlForm_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelForm_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewRightBottomSection_LicenseKeyHistory As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewRightMiddleSection_ClientContacts As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents LabelRightTopSection_ClientAddress As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelRightTopSection_ClientInformation As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_CreateNewLicenseKey As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_CreateLicenseKeyFile As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents PanelRightSection_RightTopSection As System.Windows.Forms.Panel
        Friend WithEvents PanelRightSection_RightBottomSection As System.Windows.Forms.Panel
        Friend WithEvents ExpandableSplitterControlRightSection_MiddleBottom As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelRightSection_RightMiddleSection As System.Windows.Forms.Panel
        Friend WithEvents RibbonBarOptions_ComscoreActions As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemComscoreActions_CreateNewLicenseKey As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemComscoreActions_CreateLicenseKeyFile As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents LabelRightMiddleSection_ComscoreData As WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonItemActions_RenewLicenseKey As DevComponents.DotNetBar.ButtonItem
    End Class

End Namespace