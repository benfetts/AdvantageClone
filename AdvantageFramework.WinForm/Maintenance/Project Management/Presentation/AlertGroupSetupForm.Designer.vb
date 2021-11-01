Namespace Maintenance.ProjectManagement.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AlertGroupSetupForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AlertGroupSetupForm))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Export = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemExport_CurrentView = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemExport_All = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Add = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Delete = New DevComponents.DotNetBar.ButtonItem()
            Me.PanelForm_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_AlertGroup = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterForm_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.PanelRightSection_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewRightSection_AllAlertGroupEmployees = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ButtonRightSection_RemoveFromAlertGroup = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonRightSection_AddEmployeeToGroup = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewRightSection_AlertGroupEmployees = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterRightSection_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelRightSection_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_Employees = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.PanelRightSection_TopSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.TextBoxTopSection_AlertGroup = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelTopSection_AlertGroup = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxTopSection_Inactive = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
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
            CType(Me.PanelRightSection_TopSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelRightSection_TopSection.SuspendLayout()
            Me.SuspendLayout()
            '
            'DefaultLookAndFeelOffice2010Blue
            '
            Me.DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(261, 82)
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Export, Me.ButtonItemActions_Add, Me.ButtonItemActions_Delete})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(230, 95)
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
            'ButtonItemActions_Add
            '
            Me.ButtonItemActions_Add.BeginGroup = True
            Me.ButtonItemActions_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Add.Name = "ButtonItemActions_Add"
            Me.ButtonItemActions_Add.RibbonWordWrap = False
            Me.ButtonItemActions_Add.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Add.Text = "Add"
            '
            'ButtonItemActions_Delete
            '
            Me.ButtonItemActions_Delete.BeginGroup = True
            Me.ButtonItemActions_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Delete.Name = "ButtonItemActions_Delete"
            Me.ButtonItemActions_Delete.RibbonWordWrap = False
            Me.ButtonItemActions_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Delete.Text = "Delete"
            '
            'PanelForm_LeftSection
            '
            Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_AlertGroup)
            Me.PanelForm_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelForm_LeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_LeftSection.Name = "PanelForm_LeftSection"
            Me.PanelForm_LeftSection.Size = New System.Drawing.Size(188, 460)
            Me.PanelForm_LeftSection.TabIndex = 4
            '
            'DataGridViewLeftSection_AlertGroup
            '
            Me.DataGridViewLeftSection_AlertGroup.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_AlertGroup.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_AlertGroup.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_AlertGroup.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_AlertGroup.DataSource = Nothing
            Me.DataGridViewLeftSection_AlertGroup.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_AlertGroup.ItemDescription = ""
            Me.DataGridViewLeftSection_AlertGroup.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewLeftSection_AlertGroup.MultiSelect = True
            Me.DataGridViewLeftSection_AlertGroup.Name = "DataGridViewLeftSection_AlertGroup"
            Me.DataGridViewLeftSection_AlertGroup.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_AlertGroup.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_AlertGroup.Size = New System.Drawing.Size(170, 436)
            Me.DataGridViewLeftSection_AlertGroup.TabIndex = 5
            Me.DataGridViewLeftSection_AlertGroup.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_AlertGroup.ViewCaptionHeight = -1
            '
            'ExpandableSplitterForm_LeftRight
            '
            Me.ExpandableSplitterForm_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterForm_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterForm_LeftRight.ExpandableControl = Me.PanelForm_LeftSection
            Me.ExpandableSplitterForm_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterForm_LeftRight.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterForm_LeftRight.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRight.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterForm_LeftRight.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRight.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterForm_LeftRight.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRight.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRight.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterForm_LeftRight.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterForm_LeftRight.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRight.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterForm_LeftRight.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRight.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterForm_LeftRight.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRight.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterForm_LeftRight.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRight.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterForm_LeftRight.Location = New System.Drawing.Point(188, 0)
            Me.ExpandableSplitterForm_LeftRight.Name = "ExpandableSplitterForm_LeftRight"
            Me.ExpandableSplitterForm_LeftRight.Size = New System.Drawing.Size(6, 460)
            Me.ExpandableSplitterForm_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterForm_LeftRight.TabIndex = 5
            Me.ExpandableSplitterForm_LeftRight.TabStop = False
            '
            'PanelForm_RightSection
            '
            Me.PanelForm_RightSection.Controls.Add(Me.PanelRightSection_RightSection)
            Me.PanelForm_RightSection.Controls.Add(Me.ExpandableSplitterRightSection_LeftRight)
            Me.PanelForm_RightSection.Controls.Add(Me.PanelRightSection_LeftSection)
            Me.PanelForm_RightSection.Controls.Add(Me.PanelRightSection_TopSection)
            Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_RightSection.Location = New System.Drawing.Point(194, 0)
            Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
            Me.PanelForm_RightSection.Size = New System.Drawing.Size(537, 460)
            Me.PanelForm_RightSection.TabIndex = 9
            '
            'PanelRightSection_RightSection
            '
            Me.PanelRightSection_RightSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelRightSection_RightSection.Controls.Add(Me.DataGridViewRightSection_AllAlertGroupEmployees)
            Me.PanelRightSection_RightSection.Controls.Add(Me.ButtonRightSection_RemoveFromAlertGroup)
            Me.PanelRightSection_RightSection.Controls.Add(Me.ButtonRightSection_AddEmployeeToGroup)
            Me.PanelRightSection_RightSection.Controls.Add(Me.DataGridViewRightSection_AlertGroupEmployees)
            Me.PanelRightSection_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelRightSection_RightSection.Location = New System.Drawing.Point(255, 35)
            Me.PanelRightSection_RightSection.Name = "PanelRightSection_RightSection"
            Me.PanelRightSection_RightSection.Size = New System.Drawing.Size(280, 423)
            Me.PanelRightSection_RightSection.TabIndex = 26
            '
            'DataGridViewRightSection_AllAlertGroupEmployees
            '
            Me.DataGridViewRightSection_AllAlertGroupEmployees.AutoFilterLookupColumns = False
            Me.DataGridViewRightSection_AllAlertGroupEmployees.AutoloadRepositoryDatasource = True
            Me.DataGridViewRightSection_AllAlertGroupEmployees.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewRightSection_AllAlertGroupEmployees.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRightSection_AllAlertGroupEmployees.ItemDescription = ""
            Me.DataGridViewRightSection_AllAlertGroupEmployees.Location = New System.Drawing.Point(6, 58)
            Me.DataGridViewRightSection_AllAlertGroupEmployees.MultiSelect = True
            Me.DataGridViewRightSection_AllAlertGroupEmployees.Name = "DataGridViewRightSection_AllAlertGroupEmployees"
            Me.DataGridViewRightSection_AllAlertGroupEmployees.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewRightSection_AllAlertGroupEmployees.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRightSection_AllAlertGroupEmployees.Size = New System.Drawing.Size(73, 355)
            Me.DataGridViewRightSection_AllAlertGroupEmployees.TabIndex = 25
            Me.DataGridViewRightSection_AllAlertGroupEmployees.UseEmbeddedNavigator = False
            Me.DataGridViewRightSection_AllAlertGroupEmployees.ViewCaptionHeight = -1
            Me.DataGridViewRightSection_AllAlertGroupEmployees.Visible = False
            '
            'ButtonRightSection_RemoveFromAlertGroup
            '
            Me.ButtonRightSection_RemoveFromAlertGroup.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_RemoveFromAlertGroup.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_RemoveFromAlertGroup.Location = New System.Drawing.Point(6, 32)
            Me.ButtonRightSection_RemoveFromAlertGroup.Name = "ButtonRightSection_RemoveFromAlertGroup"
            Me.ButtonRightSection_RemoveFromAlertGroup.SecurityEnabled = True
            Me.ButtonRightSection_RemoveFromAlertGroup.Size = New System.Drawing.Size(73, 20)
            Me.ButtonRightSection_RemoveFromAlertGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_RemoveFromAlertGroup.TabIndex = 24
            Me.ButtonRightSection_RemoveFromAlertGroup.Text = "<"
            '
            'ButtonRightSection_AddEmployeeToGroup
            '
            Me.ButtonRightSection_AddEmployeeToGroup.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_AddEmployeeToGroup.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_AddEmployeeToGroup.Location = New System.Drawing.Point(6, 6)
            Me.ButtonRightSection_AddEmployeeToGroup.Name = "ButtonRightSection_AddEmployeeToGroup"
            Me.ButtonRightSection_AddEmployeeToGroup.SecurityEnabled = True
            Me.ButtonRightSection_AddEmployeeToGroup.Size = New System.Drawing.Size(73, 20)
            Me.ButtonRightSection_AddEmployeeToGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_AddEmployeeToGroup.TabIndex = 22
            Me.ButtonRightSection_AddEmployeeToGroup.Text = ">"
            '
            'DataGridViewRightSection_AlertGroupEmployees
            '
            Me.DataGridViewRightSection_AlertGroupEmployees.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRightSection_AlertGroupEmployees.AutoFilterLookupColumns = False
            Me.DataGridViewRightSection_AlertGroupEmployees.AutoloadRepositoryDatasource = True
            Me.DataGridViewRightSection_AlertGroupEmployees.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewRightSection_AlertGroupEmployees.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRightSection_AlertGroupEmployees.ItemDescription = ""
            Me.DataGridViewRightSection_AlertGroupEmployees.Location = New System.Drawing.Point(85, 6)
            Me.DataGridViewRightSection_AlertGroupEmployees.MultiSelect = True
            Me.DataGridViewRightSection_AlertGroupEmployees.Name = "DataGridViewRightSection_AlertGroupEmployees"
            Me.DataGridViewRightSection_AlertGroupEmployees.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewRightSection_AlertGroupEmployees.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRightSection_AlertGroupEmployees.Size = New System.Drawing.Size(185, 407)
            Me.DataGridViewRightSection_AlertGroupEmployees.TabIndex = 21
            Me.DataGridViewRightSection_AlertGroupEmployees.UseEmbeddedNavigator = False
            Me.DataGridViewRightSection_AlertGroupEmployees.ViewCaptionHeight = -1
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
            Me.ExpandableSplitterRightSection_LeftRight.Location = New System.Drawing.Point(249, 35)
            Me.ExpandableSplitterRightSection_LeftRight.Name = "ExpandableSplitterRightSection_LeftRight"
            Me.ExpandableSplitterRightSection_LeftRight.Size = New System.Drawing.Size(6, 423)
            Me.ExpandableSplitterRightSection_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterRightSection_LeftRight.TabIndex = 28
            Me.ExpandableSplitterRightSection_LeftRight.TabStop = False
            '
            'PanelRightSection_LeftSection
            '
            Me.PanelRightSection_LeftSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelRightSection_LeftSection.Controls.Add(Me.DataGridViewLeftSection_Employees)
            Me.PanelRightSection_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelRightSection_LeftSection.Location = New System.Drawing.Point(2, 35)
            Me.PanelRightSection_LeftSection.Name = "PanelRightSection_LeftSection"
            Me.PanelRightSection_LeftSection.Size = New System.Drawing.Size(247, 423)
            Me.PanelRightSection_LeftSection.TabIndex = 25
            '
            'DataGridViewLeftSection_Employees
            '
            Me.DataGridViewLeftSection_Employees.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_Employees.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_Employees.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_Employees.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_Employees.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_Employees.ItemDescription = "Available Employee(s)"
            Me.DataGridViewLeftSection_Employees.Location = New System.Drawing.Point(4, 6)
            Me.DataGridViewLeftSection_Employees.MultiSelect = True
            Me.DataGridViewLeftSection_Employees.Name = "DataGridViewLeftSection_Employees"
            Me.DataGridViewLeftSection_Employees.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_Employees.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_Employees.Size = New System.Drawing.Size(237, 407)
            Me.DataGridViewLeftSection_Employees.TabIndex = 23
            Me.DataGridViewLeftSection_Employees.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_Employees.ViewCaptionHeight = -1
            '
            'PanelRightSection_TopSection
            '
            Me.PanelRightSection_TopSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelRightSection_TopSection.Controls.Add(Me.TextBoxTopSection_AlertGroup)
            Me.PanelRightSection_TopSection.Controls.Add(Me.LabelTopSection_AlertGroup)
            Me.PanelRightSection_TopSection.Controls.Add(Me.CheckBoxTopSection_Inactive)
            Me.PanelRightSection_TopSection.Dock = System.Windows.Forms.DockStyle.Top
            Me.PanelRightSection_TopSection.Location = New System.Drawing.Point(2, 2)
            Me.PanelRightSection_TopSection.Name = "PanelRightSection_TopSection"
            Me.PanelRightSection_TopSection.Size = New System.Drawing.Size(533, 33)
            Me.PanelRightSection_TopSection.TabIndex = 27
            '
            'TextBoxTopSection_AlertGroup
            '
            Me.TextBoxTopSection_AlertGroup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxTopSection_AlertGroup.Border.Class = "TextBoxBorder"
            Me.TextBoxTopSection_AlertGroup.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxTopSection_AlertGroup.CheckSpellingOnValidate = False
            Me.TextBoxTopSection_AlertGroup.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxTopSection_AlertGroup.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxTopSection_AlertGroup.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxTopSection_AlertGroup.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxTopSection_AlertGroup.FocusHighlightEnabled = True
            Me.TextBoxTopSection_AlertGroup.Location = New System.Drawing.Point(76, 10)
            Me.TextBoxTopSection_AlertGroup.Name = "TextBoxTopSection_AlertGroup"
            Me.TextBoxTopSection_AlertGroup.Size = New System.Drawing.Size(374, 20)
            Me.TextBoxTopSection_AlertGroup.TabIndex = 22
            Me.TextBoxTopSection_AlertGroup.TabOnEnter = True
            '
            'LabelTopSection_AlertGroup
            '
            Me.LabelTopSection_AlertGroup.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTopSection_AlertGroup.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTopSection_AlertGroup.Location = New System.Drawing.Point(4, 10)
            Me.LabelTopSection_AlertGroup.Name = "LabelTopSection_AlertGroup"
            Me.LabelTopSection_AlertGroup.Size = New System.Drawing.Size(66, 20)
            Me.LabelTopSection_AlertGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTopSection_AlertGroup.TabIndex = 17
            Me.LabelTopSection_AlertGroup.Text = "Alert Group:"
            '
            'CheckBoxTopSection_Inactive
            '
            Me.CheckBoxTopSection_Inactive.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxTopSection_Inactive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxTopSection_Inactive.CheckValue = 0
            Me.CheckBoxTopSection_Inactive.CheckValueChecked = 1
            Me.CheckBoxTopSection_Inactive.CheckValueUnchecked = 0
            Me.CheckBoxTopSection_Inactive.ChildControls = CType(resources.GetObject("CheckBoxTopSection_Inactive.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTopSection_Inactive.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxTopSection_Inactive.Location = New System.Drawing.Point(456, 10)
            Me.CheckBoxTopSection_Inactive.Name = "CheckBoxTopSection_Inactive"
            Me.CheckBoxTopSection_Inactive.OldestSibling = Nothing
            Me.CheckBoxTopSection_Inactive.SecurityEnabled = True
            Me.CheckBoxTopSection_Inactive.SiblingControls = CType(resources.GetObject("CheckBoxTopSection_Inactive.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTopSection_Inactive.Size = New System.Drawing.Size(67, 20)
            Me.CheckBoxTopSection_Inactive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxTopSection_Inactive.TabIndex = 18
            Me.CheckBoxTopSection_Inactive.Text = "Inactive"
            '
            'AlertGroupSetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(731, 460)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.PanelForm_RightSection)
            Me.Controls.Add(Me.ExpandableSplitterForm_LeftRight)
            Me.Controls.Add(Me.PanelForm_LeftSection)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "AlertGroupSetupForm"
            Me.Text = "Alert Group Maintenance"
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
            CType(Me.PanelRightSection_TopSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelRightSection_TopSection.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents PanelForm_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ExpandableSplitterForm_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents DataGridViewLeftSection_AlertGroup As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonItemActions_Add As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents PanelForm_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents CheckBoxTopSection_Inactive As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents DataGridViewLeftSection_Employees As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonRightSection_RemoveFromAlertGroup As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewRightSection_AlertGroupEmployees As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonRightSection_AddEmployeeToGroup As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents PanelRightSection_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ExpandableSplitterRightSection_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelRightSection_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelRightSection_TopSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents TextBoxTopSection_AlertGroup As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelTopSection_AlertGroup As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonItemActions_Delete As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents DataGridViewRightSection_AllAlertGroupEmployees As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonItemActions_Export As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemExport_CurrentView As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemExport_All As DevComponents.DotNetBar.ButtonItem
    End Class

End Namespace

