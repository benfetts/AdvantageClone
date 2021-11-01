Namespace Maintenance.Client.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AccountExecutiveSetupForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AccountExecutiveSetupForm))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Export = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemExport_CurrentView = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemExport_All = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Update = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Copy = New DevComponents.DotNetBar.ButtonItem()
            Me.PanelForm_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_Products = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterForm_LeftMiddle = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.PanelRightSection_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ButtonRightSection_RemoveAccountExecutive = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonRightSection_AddAccountExecutive = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewRightSection_AccountExecutives = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterRightSection_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelRightSection_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewMiddleSection_Employees = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.DataGridViewRightSection_Export = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_LeftSection.SuspendLayout()
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_RightSection.SuspendLayout()
            CType(Me.PanelRightSection_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelRightSection_RightSection.SuspendLayout()
            CType(Me.PanelRightSection_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelRightSection_LeftSection.SuspendLayout()
            Me.SuspendLayout()
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(261, 82)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(155, 95)
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Export, Me.ButtonItemActions_Update, Me.ButtonItemActions_Copy})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(142, 95)
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
            'ButtonItemActions_Export
            '
            Me.ButtonItemActions_Export.AutoExpandOnClick = True
            Me.ButtonItemActions_Export.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Export.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Export.Name = "ButtonItemActions_Export"
            Me.ButtonItemActions_Export.RibbonWordWrap = False
            Me.ButtonItemActions_Export.SplitButton = True
            Me.ButtonItemActions_Export.Stretch = True
            Me.ButtonItemActions_Export.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemExport_CurrentView, Me.ButtonItemExport_All})
            Me.ButtonItemActions_Export.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Export.Text = "Export"
            '
            'ButtonItemExport_CurrentView
            '
            Me.ButtonItemExport_CurrentView.Name = "ButtonItemExport_CurrentView"
            Me.ButtonItemExport_CurrentView.Text = "Current View"
            '
            'ButtonItemExport_All
            '
            Me.ButtonItemExport_All.Name = "ButtonItemExport_All"
            Me.ButtonItemExport_All.Text = "All"
            '
            'ButtonItemActions_Update
            '
            Me.ButtonItemActions_Update.BeginGroup = True
            Me.ButtonItemActions_Update.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Update.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Update.Name = "ButtonItemActions_Update"
            Me.ButtonItemActions_Update.RibbonWordWrap = False
            Me.ButtonItemActions_Update.Stretch = True
            Me.ButtonItemActions_Update.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Update.Text = "Update"
            '
            'ButtonItemActions_Copy
            '
            Me.ButtonItemActions_Copy.BeginGroup = True
            Me.ButtonItemActions_Copy.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Copy.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Copy.Name = "ButtonItemActions_Copy"
            Me.ButtonItemActions_Copy.RibbonWordWrap = False
            Me.ButtonItemActions_Copy.Stretch = True
            Me.ButtonItemActions_Copy.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Copy.Text = "Copy"
            '
            'PanelForm_LeftSection
            '
            Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_Products)
            Me.PanelForm_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelForm_LeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_LeftSection.Name = "PanelForm_LeftSection"
            Me.PanelForm_LeftSection.Size = New System.Drawing.Size(188, 451)
            Me.PanelForm_LeftSection.TabIndex = 4
            '
            'DataGridViewLeftSection_Products
            '
            Me.DataGridViewLeftSection_Products.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_Products.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_Products.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_Products.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_Products.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_Products.ItemDescription = ""
            Me.DataGridViewLeftSection_Products.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewLeftSection_Products.MultiSelect = False
            Me.DataGridViewLeftSection_Products.Name = "DataGridViewLeftSection_Products"
            Me.DataGridViewLeftSection_Products.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_Products.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_Products.Size = New System.Drawing.Size(170, 427)
            Me.DataGridViewLeftSection_Products.TabIndex = 0
            Me.DataGridViewLeftSection_Products.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_Products.ViewCaptionHeight = -1
            '
            'ExpandableSplitterForm_LeftMiddle
            '
            Me.ExpandableSplitterForm_LeftMiddle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterForm_LeftMiddle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterForm_LeftMiddle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterForm_LeftMiddle.ExpandableControl = Me.PanelForm_LeftSection
            Me.ExpandableSplitterForm_LeftMiddle.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterForm_LeftMiddle.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterForm_LeftMiddle.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterForm_LeftMiddle.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterForm_LeftMiddle.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterForm_LeftMiddle.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterForm_LeftMiddle.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterForm_LeftMiddle.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterForm_LeftMiddle.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterForm_LeftMiddle.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterForm_LeftMiddle.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterForm_LeftMiddle.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterForm_LeftMiddle.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterForm_LeftMiddle.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterForm_LeftMiddle.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterForm_LeftMiddle.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterForm_LeftMiddle.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterForm_LeftMiddle.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterForm_LeftMiddle.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterForm_LeftMiddle.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterForm_LeftMiddle.Location = New System.Drawing.Point(188, 0)
            Me.ExpandableSplitterForm_LeftMiddle.Name = "ExpandableSplitterForm_LeftMiddle"
            Me.ExpandableSplitterForm_LeftMiddle.Size = New System.Drawing.Size(6, 451)
            Me.ExpandableSplitterForm_LeftMiddle.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterForm_LeftMiddle.TabIndex = 5
            Me.ExpandableSplitterForm_LeftMiddle.TabStop = False
            '
            'PanelForm_RightSection
            '
            Me.PanelForm_RightSection.Controls.Add(Me.PanelRightSection_RightSection)
            Me.PanelForm_RightSection.Controls.Add(Me.ExpandableSplitterRightSection_LeftRight)
            Me.PanelForm_RightSection.Controls.Add(Me.PanelRightSection_LeftSection)
            Me.PanelForm_RightSection.Controls.Add(Me.DataGridViewRightSection_Export)
            Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_RightSection.Location = New System.Drawing.Point(194, 0)
            Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
            Me.PanelForm_RightSection.Size = New System.Drawing.Size(640, 451)
            Me.PanelForm_RightSection.TabIndex = 6
            '
            'PanelRightSection_RightSection
            '
            Me.PanelRightSection_RightSection.Controls.Add(Me.ButtonRightSection_RemoveAccountExecutive)
            Me.PanelRightSection_RightSection.Controls.Add(Me.ButtonRightSection_AddAccountExecutive)
            Me.PanelRightSection_RightSection.Controls.Add(Me.DataGridViewRightSection_AccountExecutives)
            Me.PanelRightSection_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelRightSection_RightSection.Location = New System.Drawing.Point(208, 2)
            Me.PanelRightSection_RightSection.Name = "PanelRightSection_RightSection"
            Me.PanelRightSection_RightSection.Size = New System.Drawing.Size(430, 447)
            Me.PanelRightSection_RightSection.TabIndex = 15
            '
            'ButtonRightSection_RemoveAccountExecutive
            '
            Me.ButtonRightSection_RemoveAccountExecutive.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_RemoveAccountExecutive.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_RemoveAccountExecutive.Location = New System.Drawing.Point(6, 36)
            Me.ButtonRightSection_RemoveAccountExecutive.Name = "ButtonRightSection_RemoveAccountExecutive"
            Me.ButtonRightSection_RemoveAccountExecutive.SecurityEnabled = True
            Me.ButtonRightSection_RemoveAccountExecutive.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightSection_RemoveAccountExecutive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_RemoveAccountExecutive.TabIndex = 10
            Me.ButtonRightSection_RemoveAccountExecutive.Text = "<"
            '
            'ButtonRightSection_AddAccountExecutive
            '
            Me.ButtonRightSection_AddAccountExecutive.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_AddAccountExecutive.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_AddAccountExecutive.Location = New System.Drawing.Point(6, 10)
            Me.ButtonRightSection_AddAccountExecutive.Name = "ButtonRightSection_AddAccountExecutive"
            Me.ButtonRightSection_AddAccountExecutive.SecurityEnabled = True
            Me.ButtonRightSection_AddAccountExecutive.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightSection_AddAccountExecutive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_AddAccountExecutive.TabIndex = 9
            Me.ButtonRightSection_AddAccountExecutive.Text = ">"
            '
            'DataGridViewRightSection_AccountExecutives
            '
            Me.DataGridViewRightSection_AccountExecutives.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRightSection_AccountExecutives.AutoFilterLookupColumns = False
            Me.DataGridViewRightSection_AccountExecutives.AutoloadRepositoryDatasource = True
            Me.DataGridViewRightSection_AccountExecutives.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewRightSection_AccountExecutives.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRightSection_AccountExecutives.ItemDescription = "AE/Client Manager(s)"
            Me.DataGridViewRightSection_AccountExecutives.Location = New System.Drawing.Point(87, 10)
            Me.DataGridViewRightSection_AccountExecutives.MultiSelect = True
            Me.DataGridViewRightSection_AccountExecutives.Name = "DataGridViewRightSection_AccountExecutives"
            Me.DataGridViewRightSection_AccountExecutives.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewRightSection_AccountExecutives.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRightSection_AccountExecutives.Size = New System.Drawing.Size(333, 427)
            Me.DataGridViewRightSection_AccountExecutives.TabIndex = 1
            Me.DataGridViewRightSection_AccountExecutives.UseEmbeddedNavigator = False
            Me.DataGridViewRightSection_AccountExecutives.ViewCaptionHeight = -1
            '
            'ExpandableSplitterRightSection_LeftRight
            '
            Me.ExpandableSplitterRightSection_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterRightSection_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterRightSection_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterRightSection_LeftRight.ExpandableControl = Me.PanelRightSection_LeftSection
            Me.ExpandableSplitterRightSection_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterRightSection_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterRightSection_LeftRight.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterRightSection_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterRightSection_LeftRight.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterRightSection_LeftRight.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterRightSection_LeftRight.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterRightSection_LeftRight.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterRightSection_LeftRight.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterRightSection_LeftRight.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterRightSection_LeftRight.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterRightSection_LeftRight.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterRightSection_LeftRight.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterRightSection_LeftRight.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterRightSection_LeftRight.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterRightSection_LeftRight.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterRightSection_LeftRight.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterRightSection_LeftRight.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterRightSection_LeftRight.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterRightSection_LeftRight.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterRightSection_LeftRight.Location = New System.Drawing.Point(202, 2)
            Me.ExpandableSplitterRightSection_LeftRight.Name = "ExpandableSplitterRightSection_LeftRight"
            Me.ExpandableSplitterRightSection_LeftRight.Size = New System.Drawing.Size(6, 447)
            Me.ExpandableSplitterRightSection_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterRightSection_LeftRight.TabIndex = 14
            Me.ExpandableSplitterRightSection_LeftRight.TabStop = False
            '
            'PanelRightSection_LeftSection
            '
            Me.PanelRightSection_LeftSection.Controls.Add(Me.DataGridViewMiddleSection_Employees)
            Me.PanelRightSection_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelRightSection_LeftSection.Location = New System.Drawing.Point(2, 2)
            Me.PanelRightSection_LeftSection.Name = "PanelRightSection_LeftSection"
            Me.PanelRightSection_LeftSection.Size = New System.Drawing.Size(200, 447)
            Me.PanelRightSection_LeftSection.TabIndex = 12
            '
            'DataGridViewMiddleSection_Employees
            '
            Me.DataGridViewMiddleSection_Employees.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewMiddleSection_Employees.AutoFilterLookupColumns = False
            Me.DataGridViewMiddleSection_Employees.AutoloadRepositoryDatasource = True
            Me.DataGridViewMiddleSection_Employees.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.[Default]
            Me.DataGridViewMiddleSection_Employees.DataSource = Nothing
            Me.DataGridViewMiddleSection_Employees.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewMiddleSection_Employees.ItemDescription = ""
            Me.DataGridViewMiddleSection_Employees.Location = New System.Drawing.Point(5, 10)
            Me.DataGridViewMiddleSection_Employees.MultiSelect = True
            Me.DataGridViewMiddleSection_Employees.Name = "DataGridViewMiddleSection_Employees"
            Me.DataGridViewMiddleSection_Employees.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewMiddleSection_Employees.ShowSelectDeselectAllButtons = False
            Me.DataGridViewMiddleSection_Employees.Size = New System.Drawing.Size(189, 427)
            Me.DataGridViewMiddleSection_Employees.TabIndex = 0
            Me.DataGridViewMiddleSection_Employees.UseEmbeddedNavigator = False
            Me.DataGridViewMiddleSection_Employees.ViewCaptionHeight = -1
            '
            'DataGridViewRightSection_Export
            '
            Me.DataGridViewRightSection_Export.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRightSection_Export.AutoFilterLookupColumns = False
            Me.DataGridViewRightSection_Export.AutoloadRepositoryDatasource = True
            Me.DataGridViewRightSection_Export.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewRightSection_Export.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRightSection_Export.ItemDescription = "AE/Client Manager(s)"
            Me.DataGridViewRightSection_Export.Location = New System.Drawing.Point(5, 348)
            Me.DataGridViewRightSection_Export.MultiSelect = True
            Me.DataGridViewRightSection_Export.Name = "DataGridViewRightSection_Export"
            Me.DataGridViewRightSection_Export.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewRightSection_Export.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRightSection_Export.Size = New System.Drawing.Size(75, 91)
            Me.DataGridViewRightSection_Export.TabIndex = 11
            Me.DataGridViewRightSection_Export.UseEmbeddedNavigator = False
            Me.DataGridViewRightSection_Export.ViewCaptionHeight = -1
            Me.DataGridViewRightSection_Export.Visible = False
            '
            'AccountExecutiveSetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(834, 451)
            Me.Controls.Add(Me.PanelForm_RightSection)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.ExpandableSplitterForm_LeftMiddle)
            Me.Controls.Add(Me.PanelForm_LeftSection)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "AccountExecutiveSetupForm"
            Me.Text = "AE/Client Manager Maintenance"
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_LeftSection.ResumeLayout(False)
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_RightSection.ResumeLayout(False)
            CType(Me.PanelRightSection_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelRightSection_RightSection.ResumeLayout(False)
            CType(Me.PanelRightSection_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelRightSection_LeftSection.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents PanelForm_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewLeftSection_Products As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ExpandableSplitterForm_LeftMiddle As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelForm_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewMiddleSection_Employees As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonRightSection_AddAccountExecutive As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonRightSection_RemoveAccountExecutive As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonItemActions_Update As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Copy As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents DataGridViewRightSection_Export As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonItemActions_Export As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemExport_CurrentView As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemExport_All As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents PanelRightSection_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewRightSection_AccountExecutives As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ExpandableSplitterRightSection_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelRightSection_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
    End Class

End Namespace

