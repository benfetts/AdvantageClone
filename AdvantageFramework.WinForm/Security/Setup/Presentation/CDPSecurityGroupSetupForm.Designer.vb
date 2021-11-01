Namespace Security.Setup.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class CDPSecurityGroupSetupForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CDPSecurityGroupSetupForm))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Add = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Save = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Delete = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Refresh = New DevComponents.DotNetBar.ButtonItem()
            Me.PanelForm_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_CDPSecurityGroups = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterControlForm_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.TabControlRightSection_CDPsAndEmployees = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelCDPs_CDPs = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelCDPs_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ButtonCDPs_RemoveCDPs = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonCDPs_AddCDPs = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.DataGridViewCDPs_SelectedCDPs = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterCDPs_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelCDPs_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewCDPs_AvailableCDPs = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.TabItemCDPsAndEmployees_CDPs = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelEmployees_Employees = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelEmployees_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ButtonEmployees_RemoveEmployees = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonEmployees_AddEmployees = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.DataGridViewEmployees_SelectedEmployees = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterEmployees_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelEmployees_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewEmployees_AvailableEmployees = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.TabItemCDPsAndEmployees_Employees = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TextBoxRightSection_Name = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.LabelRightSection_Name = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.ButtonItemActions_Cancel = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_LeftSection.SuspendLayout()
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_RightSection.SuspendLayout()
            CType(Me.TabControlRightSection_CDPsAndEmployees, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlRightSection_CDPsAndEmployees.SuspendLayout()
            Me.TabControlPanelCDPs_CDPs.SuspendLayout()
            CType(Me.PanelCDPs_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelCDPs_RightSection.SuspendLayout()
            CType(Me.PanelCDPs_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelCDPs_LeftSection.SuspendLayout()
            Me.TabControlPanelEmployees_Employees.SuspendLayout()
            CType(Me.PanelEmployees_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelEmployees_RightSection.SuspendLayout()
            CType(Me.PanelEmployees_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelEmployees_LeftSection.SuspendLayout()
            Me.SuspendLayout()
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(5, 144)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(239, 95)
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
            Me.RibbonBarOptions_Actions.DragDropSupport = True
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Add, Me.ButtonItemActions_Save, Me.ButtonItemActions_Cancel, Me.ButtonItemActions_Delete, Me.ButtonItemActions_Refresh})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(217, 95)
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
            'ButtonItemActions_Add
            '
            Me.ButtonItemActions_Add.BeginGroup = True
            Me.ButtonItemActions_Add.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Add.Name = "ButtonItemActions_Add"
            Me.ButtonItemActions_Add.RibbonWordWrap = False
            Me.ButtonItemActions_Add.Stretch = True
            Me.ButtonItemActions_Add.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Add.Text = "Add"
            '
            'ButtonItemActions_Save
            '
            Me.ButtonItemActions_Save.BeginGroup = True
            Me.ButtonItemActions_Save.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Save.Name = "ButtonItemActions_Save"
            Me.ButtonItemActions_Save.RibbonWordWrap = False
            Me.ButtonItemActions_Save.Stretch = True
            Me.ButtonItemActions_Save.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Save.Text = "Save"
            '
            'ButtonItemActions_Delete
            '
            Me.ButtonItemActions_Delete.BeginGroup = True
            Me.ButtonItemActions_Delete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Delete.Name = "ButtonItemActions_Delete"
            Me.ButtonItemActions_Delete.RibbonWordWrap = False
            Me.ButtonItemActions_Delete.Stretch = True
            Me.ButtonItemActions_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Delete.Text = "Delete"
            '
            'ButtonItemActions_Refresh
            '
            Me.ButtonItemActions_Refresh.BeginGroup = True
            Me.ButtonItemActions_Refresh.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Refresh.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Refresh.Name = "ButtonItemActions_Refresh"
            Me.ButtonItemActions_Refresh.RibbonWordWrap = False
            Me.ButtonItemActions_Refresh.Stretch = True
            Me.ButtonItemActions_Refresh.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Refresh.Text = "Refresh"
            Me.ButtonItemActions_Refresh.Visible = False
            '
            'PanelForm_LeftSection
            '
            Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_CDPSecurityGroups)
            Me.PanelForm_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelForm_LeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_LeftSection.Name = "PanelForm_LeftSection"
            Me.PanelForm_LeftSection.Size = New System.Drawing.Size(292, 503)
            Me.PanelForm_LeftSection.TabIndex = 4
            '
            'DataGridViewLeftSection_CDPSecurityGroups
            '
            Me.DataGridViewLeftSection_CDPSecurityGroups.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_CDPSecurityGroups.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_CDPSecurityGroups.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_CDPSecurityGroups.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_CDPSecurityGroups.ItemDescription = "CDP Group(s)"
            Me.DataGridViewLeftSection_CDPSecurityGroups.Location = New System.Drawing.Point(13, 12)
            Me.DataGridViewLeftSection_CDPSecurityGroups.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewLeftSection_CDPSecurityGroups.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewLeftSection_CDPSecurityGroups.ModifyGridRowHeight = False
            Me.DataGridViewLeftSection_CDPSecurityGroups.MultiSelect = True
            Me.DataGridViewLeftSection_CDPSecurityGroups.Name = "DataGridViewLeftSection_CDPSecurityGroups"
            Me.DataGridViewLeftSection_CDPSecurityGroups.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_CDPSecurityGroups.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewLeftSection_CDPSecurityGroups.ShowRowSelectionIfHidden = True
            Me.DataGridViewLeftSection_CDPSecurityGroups.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_CDPSecurityGroups.Size = New System.Drawing.Size(272, 479)
            Me.DataGridViewLeftSection_CDPSecurityGroups.TabIndex = 12
            Me.DataGridViewLeftSection_CDPSecurityGroups.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_CDPSecurityGroups.ViewCaptionHeight = -1
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
            Me.ExpandableSplitterControlForm_LeftRight.Location = New System.Drawing.Point(292, 0)
            Me.ExpandableSplitterControlForm_LeftRight.Name = "ExpandableSplitterControlForm_LeftRight"
            Me.ExpandableSplitterControlForm_LeftRight.Size = New System.Drawing.Size(6, 503)
            Me.ExpandableSplitterControlForm_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlForm_LeftRight.TabIndex = 5
            Me.ExpandableSplitterControlForm_LeftRight.TabStop = False
            '
            'PanelForm_RightSection
            '
            Me.PanelForm_RightSection.Appearance.BackColor = System.Drawing.Color.Transparent
            Me.PanelForm_RightSection.Appearance.Options.UseBackColor = True
            Me.PanelForm_RightSection.Controls.Add(Me.TabControlRightSection_CDPsAndEmployees)
            Me.PanelForm_RightSection.Controls.Add(Me.TextBoxRightSection_Name)
            Me.PanelForm_RightSection.Controls.Add(Me.LabelRightSection_Name)
            Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_RightSection.Location = New System.Drawing.Point(298, 0)
            Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
            Me.PanelForm_RightSection.Size = New System.Drawing.Size(611, 503)
            Me.PanelForm_RightSection.TabIndex = 7
            '
            'TabControlRightSection_CDPsAndEmployees
            '
            Me.TabControlRightSection_CDPsAndEmployees.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlRightSection_CDPsAndEmployees.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.TabControlRightSection_CDPsAndEmployees.CanReorderTabs = False
            Me.TabControlRightSection_CDPsAndEmployees.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlRightSection_CDPsAndEmployees.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlRightSection_CDPsAndEmployees.Controls.Add(Me.TabControlPanelCDPs_CDPs)
            Me.TabControlRightSection_CDPsAndEmployees.Controls.Add(Me.TabControlPanelEmployees_Employees)
            Me.TabControlRightSection_CDPsAndEmployees.ForeColor = System.Drawing.Color.Black
            Me.TabControlRightSection_CDPsAndEmployees.Location = New System.Drawing.Point(6, 39)
            Me.TabControlRightSection_CDPsAndEmployees.Name = "TabControlRightSection_CDPsAndEmployees"
            Me.TabControlRightSection_CDPsAndEmployees.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlRightSection_CDPsAndEmployees.SelectedTabIndex = 0
            Me.TabControlRightSection_CDPsAndEmployees.Size = New System.Drawing.Size(593, 452)
            Me.TabControlRightSection_CDPsAndEmployees.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlRightSection_CDPsAndEmployees.TabIndex = 8
            Me.TabControlRightSection_CDPsAndEmployees.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlRightSection_CDPsAndEmployees.Tabs.Add(Me.TabItemCDPsAndEmployees_CDPs)
            Me.TabControlRightSection_CDPsAndEmployees.Tabs.Add(Me.TabItemCDPsAndEmployees_Employees)
            Me.TabControlRightSection_CDPsAndEmployees.Text = "TabControlForm"
            '
            'TabControlPanelCDPs_CDPs
            '
            Me.TabControlPanelCDPs_CDPs.Controls.Add(Me.PanelCDPs_RightSection)
            Me.TabControlPanelCDPs_CDPs.Controls.Add(Me.ExpandableSplitterCDPs_LeftRight)
            Me.TabControlPanelCDPs_CDPs.Controls.Add(Me.PanelCDPs_LeftSection)
            Me.TabControlPanelCDPs_CDPs.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelCDPs_CDPs.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelCDPs_CDPs.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelCDPs_CDPs.Name = "TabControlPanelCDPs_CDPs"
            Me.TabControlPanelCDPs_CDPs.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelCDPs_CDPs.Size = New System.Drawing.Size(593, 425)
            Me.TabControlPanelCDPs_CDPs.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelCDPs_CDPs.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelCDPs_CDPs.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelCDPs_CDPs.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelCDPs_CDPs.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelCDPs_CDPs.Style.GradientAngle = 90
            Me.TabControlPanelCDPs_CDPs.TabIndex = 0
            Me.TabControlPanelCDPs_CDPs.TabItem = Me.TabItemCDPsAndEmployees_CDPs
            '
            'PanelCDPs_RightSection
            '
            Me.PanelCDPs_RightSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelCDPs_RightSection.Appearance.Options.UseBackColor = True
            Me.PanelCDPs_RightSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelCDPs_RightSection.Controls.Add(Me.ButtonCDPs_RemoveCDPs)
            Me.PanelCDPs_RightSection.Controls.Add(Me.ButtonCDPs_AddCDPs)
            Me.PanelCDPs_RightSection.Controls.Add(Me.DataGridViewCDPs_SelectedCDPs)
            Me.PanelCDPs_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelCDPs_RightSection.Location = New System.Drawing.Point(254, 1)
            Me.PanelCDPs_RightSection.Name = "PanelCDPs_RightSection"
            Me.PanelCDPs_RightSection.Size = New System.Drawing.Size(338, 423)
            Me.PanelCDPs_RightSection.TabIndex = 37
            '
            'ButtonCDPs_RemoveCDPs
            '
            Me.ButtonCDPs_RemoveCDPs.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonCDPs_RemoveCDPs.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonCDPs_RemoveCDPs.Location = New System.Drawing.Point(6, 29)
            Me.ButtonCDPs_RemoveCDPs.Name = "ButtonCDPs_RemoveCDPs"
            Me.ButtonCDPs_RemoveCDPs.SecurityEnabled = True
            Me.ButtonCDPs_RemoveCDPs.Size = New System.Drawing.Size(73, 20)
            Me.ButtonCDPs_RemoveCDPs.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonCDPs_RemoveCDPs.TabIndex = 24
            Me.ButtonCDPs_RemoveCDPs.Text = "<"
            '
            'ButtonCDPs_AddCDPs
            '
            Me.ButtonCDPs_AddCDPs.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonCDPs_AddCDPs.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonCDPs_AddCDPs.Location = New System.Drawing.Point(6, 3)
            Me.ButtonCDPs_AddCDPs.Name = "ButtonCDPs_AddCDPs"
            Me.ButtonCDPs_AddCDPs.SecurityEnabled = True
            Me.ButtonCDPs_AddCDPs.Size = New System.Drawing.Size(73, 20)
            Me.ButtonCDPs_AddCDPs.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonCDPs_AddCDPs.TabIndex = 22
            Me.ButtonCDPs_AddCDPs.Text = ">"
            '
            'DataGridViewCDPs_SelectedCDPs
            '
            Me.DataGridViewCDPs_SelectedCDPs.AllowSelectGroupHeaderRow = True
            Me.DataGridViewCDPs_SelectedCDPs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewCDPs_SelectedCDPs.AutoUpdateViewCaption = True
            Me.DataGridViewCDPs_SelectedCDPs.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewCDPs_SelectedCDPs.ItemDescription = "Selected CDP(s)"
            Me.DataGridViewCDPs_SelectedCDPs.Location = New System.Drawing.Point(85, 3)
            Me.DataGridViewCDPs_SelectedCDPs.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewCDPs_SelectedCDPs.ModifyGridRowHeight = False
            Me.DataGridViewCDPs_SelectedCDPs.MultiSelect = True
            Me.DataGridViewCDPs_SelectedCDPs.Name = "DataGridViewCDPs_SelectedCDPs"
            Me.DataGridViewCDPs_SelectedCDPs.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewCDPs_SelectedCDPs.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewCDPs_SelectedCDPs.ShowRowSelectionIfHidden = True
            Me.DataGridViewCDPs_SelectedCDPs.ShowSelectDeselectAllButtons = True
            Me.DataGridViewCDPs_SelectedCDPs.Size = New System.Drawing.Size(250, 417)
            Me.DataGridViewCDPs_SelectedCDPs.TabIndex = 21
            Me.DataGridViewCDPs_SelectedCDPs.UseEmbeddedNavigator = False
            Me.DataGridViewCDPs_SelectedCDPs.ViewCaptionHeight = -1
            '
            'ExpandableSplitterCDPs_LeftRight
            '
            Me.ExpandableSplitterCDPs_LeftRight.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterCDPs_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterCDPs_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterCDPs_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterCDPs_LeftRight.ExpandableControl = Me.PanelCDPs_LeftSection
            Me.ExpandableSplitterCDPs_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterCDPs_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterCDPs_LeftRight.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterCDPs_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterCDPs_LeftRight.ForeColor = System.Drawing.Color.Black
            Me.ExpandableSplitterCDPs_LeftRight.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterCDPs_LeftRight.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterCDPs_LeftRight.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterCDPs_LeftRight.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterCDPs_LeftRight.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterCDPs_LeftRight.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterCDPs_LeftRight.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterCDPs_LeftRight.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterCDPs_LeftRight.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterCDPs_LeftRight.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterCDPs_LeftRight.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterCDPs_LeftRight.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterCDPs_LeftRight.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterCDPs_LeftRight.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterCDPs_LeftRight.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterCDPs_LeftRight.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterCDPs_LeftRight.Location = New System.Drawing.Point(248, 1)
            Me.ExpandableSplitterCDPs_LeftRight.Name = "ExpandableSplitterCDPs_LeftRight"
            Me.ExpandableSplitterCDPs_LeftRight.Size = New System.Drawing.Size(6, 423)
            Me.ExpandableSplitterCDPs_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterCDPs_LeftRight.TabIndex = 38
            Me.ExpandableSplitterCDPs_LeftRight.TabStop = False
            '
            'PanelCDPs_LeftSection
            '
            Me.PanelCDPs_LeftSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelCDPs_LeftSection.Appearance.Options.UseBackColor = True
            Me.PanelCDPs_LeftSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelCDPs_LeftSection.Controls.Add(Me.DataGridViewCDPs_AvailableCDPs)
            Me.PanelCDPs_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelCDPs_LeftSection.Location = New System.Drawing.Point(1, 1)
            Me.PanelCDPs_LeftSection.Name = "PanelCDPs_LeftSection"
            Me.PanelCDPs_LeftSection.Size = New System.Drawing.Size(247, 423)
            Me.PanelCDPs_LeftSection.TabIndex = 36
            '
            'DataGridViewCDPs_AvailableCDPs
            '
            Me.DataGridViewCDPs_AvailableCDPs.AllowSelectGroupHeaderRow = True
            Me.DataGridViewCDPs_AvailableCDPs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewCDPs_AvailableCDPs.AutoUpdateViewCaption = True
            Me.DataGridViewCDPs_AvailableCDPs.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewCDPs_AvailableCDPs.ItemDescription = "Available CDP(s)"
            Me.DataGridViewCDPs_AvailableCDPs.Location = New System.Drawing.Point(3, 3)
            Me.DataGridViewCDPs_AvailableCDPs.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewCDPs_AvailableCDPs.ModifyGridRowHeight = False
            Me.DataGridViewCDPs_AvailableCDPs.MultiSelect = True
            Me.DataGridViewCDPs_AvailableCDPs.Name = "DataGridViewCDPs_AvailableCDPs"
            Me.DataGridViewCDPs_AvailableCDPs.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewCDPs_AvailableCDPs.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewCDPs_AvailableCDPs.ShowRowSelectionIfHidden = True
            Me.DataGridViewCDPs_AvailableCDPs.ShowSelectDeselectAllButtons = True
            Me.DataGridViewCDPs_AvailableCDPs.Size = New System.Drawing.Size(238, 417)
            Me.DataGridViewCDPs_AvailableCDPs.TabIndex = 23
            Me.DataGridViewCDPs_AvailableCDPs.UseEmbeddedNavigator = False
            Me.DataGridViewCDPs_AvailableCDPs.ViewCaptionHeight = -1
            '
            'TabItemCDPsAndEmployees_CDPs
            '
            Me.TabItemCDPsAndEmployees_CDPs.AttachedControl = Me.TabControlPanelCDPs_CDPs
            Me.TabItemCDPsAndEmployees_CDPs.Name = "TabItemCDPsAndEmployees_CDPs"
            Me.TabItemCDPsAndEmployees_CDPs.Text = "CDPs"
            '
            'TabControlPanelEmployees_Employees
            '
            Me.TabControlPanelEmployees_Employees.Controls.Add(Me.PanelEmployees_RightSection)
            Me.TabControlPanelEmployees_Employees.Controls.Add(Me.ExpandableSplitterEmployees_LeftRight)
            Me.TabControlPanelEmployees_Employees.Controls.Add(Me.PanelEmployees_LeftSection)
            Me.TabControlPanelEmployees_Employees.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelEmployees_Employees.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelEmployees_Employees.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelEmployees_Employees.Name = "TabControlPanelEmployees_Employees"
            Me.TabControlPanelEmployees_Employees.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelEmployees_Employees.Size = New System.Drawing.Size(593, 425)
            Me.TabControlPanelEmployees_Employees.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelEmployees_Employees.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelEmployees_Employees.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelEmployees_Employees.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelEmployees_Employees.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelEmployees_Employees.Style.GradientAngle = 90
            Me.TabControlPanelEmployees_Employees.TabIndex = 1
            Me.TabControlPanelEmployees_Employees.TabItem = Me.TabItemCDPsAndEmployees_Employees
            '
            'PanelEmployees_RightSection
            '
            Me.PanelEmployees_RightSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelEmployees_RightSection.Appearance.Options.UseBackColor = True
            Me.PanelEmployees_RightSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelEmployees_RightSection.Controls.Add(Me.ButtonEmployees_RemoveEmployees)
            Me.PanelEmployees_RightSection.Controls.Add(Me.ButtonEmployees_AddEmployees)
            Me.PanelEmployees_RightSection.Controls.Add(Me.DataGridViewEmployees_SelectedEmployees)
            Me.PanelEmployees_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelEmployees_RightSection.Location = New System.Drawing.Point(254, 1)
            Me.PanelEmployees_RightSection.Name = "PanelEmployees_RightSection"
            Me.PanelEmployees_RightSection.Size = New System.Drawing.Size(338, 423)
            Me.PanelEmployees_RightSection.TabIndex = 34
            '
            'ButtonEmployees_RemoveEmployees
            '
            Me.ButtonEmployees_RemoveEmployees.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonEmployees_RemoveEmployees.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonEmployees_RemoveEmployees.Location = New System.Drawing.Point(6, 29)
            Me.ButtonEmployees_RemoveEmployees.Name = "ButtonEmployees_RemoveEmployees"
            Me.ButtonEmployees_RemoveEmployees.SecurityEnabled = True
            Me.ButtonEmployees_RemoveEmployees.Size = New System.Drawing.Size(73, 20)
            Me.ButtonEmployees_RemoveEmployees.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonEmployees_RemoveEmployees.TabIndex = 24
            Me.ButtonEmployees_RemoveEmployees.Text = "<"
            '
            'ButtonEmployees_AddEmployees
            '
            Me.ButtonEmployees_AddEmployees.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonEmployees_AddEmployees.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonEmployees_AddEmployees.Location = New System.Drawing.Point(6, 3)
            Me.ButtonEmployees_AddEmployees.Name = "ButtonEmployees_AddEmployees"
            Me.ButtonEmployees_AddEmployees.SecurityEnabled = True
            Me.ButtonEmployees_AddEmployees.Size = New System.Drawing.Size(73, 20)
            Me.ButtonEmployees_AddEmployees.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonEmployees_AddEmployees.TabIndex = 22
            Me.ButtonEmployees_AddEmployees.Text = ">"
            '
            'DataGridViewEmployees_SelectedEmployees
            '
            Me.DataGridViewEmployees_SelectedEmployees.AllowSelectGroupHeaderRow = True
            Me.DataGridViewEmployees_SelectedEmployees.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewEmployees_SelectedEmployees.AutoUpdateViewCaption = True
            Me.DataGridViewEmployees_SelectedEmployees.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewEmployees_SelectedEmployees.ItemDescription = "Selected Employee(s)"
            Me.DataGridViewEmployees_SelectedEmployees.Location = New System.Drawing.Point(85, 3)
            Me.DataGridViewEmployees_SelectedEmployees.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewEmployees_SelectedEmployees.ModifyGridRowHeight = False
            Me.DataGridViewEmployees_SelectedEmployees.MultiSelect = True
            Me.DataGridViewEmployees_SelectedEmployees.Name = "DataGridViewEmployees_SelectedEmployees"
            Me.DataGridViewEmployees_SelectedEmployees.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewEmployees_SelectedEmployees.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewEmployees_SelectedEmployees.ShowRowSelectionIfHidden = True
            Me.DataGridViewEmployees_SelectedEmployees.ShowSelectDeselectAllButtons = False
            Me.DataGridViewEmployees_SelectedEmployees.Size = New System.Drawing.Size(250, 417)
            Me.DataGridViewEmployees_SelectedEmployees.TabIndex = 21
            Me.DataGridViewEmployees_SelectedEmployees.UseEmbeddedNavigator = False
            Me.DataGridViewEmployees_SelectedEmployees.ViewCaptionHeight = -1
            '
            'ExpandableSplitterEmployees_LeftRight
            '
            Me.ExpandableSplitterEmployees_LeftRight.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterEmployees_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterEmployees_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterEmployees_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterEmployees_LeftRight.ExpandableControl = Me.PanelEmployees_LeftSection
            Me.ExpandableSplitterEmployees_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterEmployees_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterEmployees_LeftRight.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterEmployees_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterEmployees_LeftRight.ForeColor = System.Drawing.Color.Black
            Me.ExpandableSplitterEmployees_LeftRight.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterEmployees_LeftRight.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterEmployees_LeftRight.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterEmployees_LeftRight.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterEmployees_LeftRight.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterEmployees_LeftRight.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterEmployees_LeftRight.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterEmployees_LeftRight.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterEmployees_LeftRight.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterEmployees_LeftRight.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterEmployees_LeftRight.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterEmployees_LeftRight.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterEmployees_LeftRight.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterEmployees_LeftRight.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterEmployees_LeftRight.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterEmployees_LeftRight.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterEmployees_LeftRight.Location = New System.Drawing.Point(248, 1)
            Me.ExpandableSplitterEmployees_LeftRight.Name = "ExpandableSplitterEmployees_LeftRight"
            Me.ExpandableSplitterEmployees_LeftRight.Size = New System.Drawing.Size(6, 423)
            Me.ExpandableSplitterEmployees_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterEmployees_LeftRight.TabIndex = 35
            Me.ExpandableSplitterEmployees_LeftRight.TabStop = False
            '
            'PanelEmployees_LeftSection
            '
            Me.PanelEmployees_LeftSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelEmployees_LeftSection.Appearance.Options.UseBackColor = True
            Me.PanelEmployees_LeftSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelEmployees_LeftSection.Controls.Add(Me.DataGridViewEmployees_AvailableEmployees)
            Me.PanelEmployees_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelEmployees_LeftSection.Location = New System.Drawing.Point(1, 1)
            Me.PanelEmployees_LeftSection.Name = "PanelEmployees_LeftSection"
            Me.PanelEmployees_LeftSection.Size = New System.Drawing.Size(247, 423)
            Me.PanelEmployees_LeftSection.TabIndex = 33
            '
            'DataGridViewEmployees_AvailableEmployees
            '
            Me.DataGridViewEmployees_AvailableEmployees.AllowSelectGroupHeaderRow = True
            Me.DataGridViewEmployees_AvailableEmployees.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewEmployees_AvailableEmployees.AutoUpdateViewCaption = True
            Me.DataGridViewEmployees_AvailableEmployees.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewEmployees_AvailableEmployees.ItemDescription = "Available Employee(s)"
            Me.DataGridViewEmployees_AvailableEmployees.Location = New System.Drawing.Point(3, 3)
            Me.DataGridViewEmployees_AvailableEmployees.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewEmployees_AvailableEmployees.ModifyGridRowHeight = False
            Me.DataGridViewEmployees_AvailableEmployees.MultiSelect = True
            Me.DataGridViewEmployees_AvailableEmployees.Name = "DataGridViewEmployees_AvailableEmployees"
            Me.DataGridViewEmployees_AvailableEmployees.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewEmployees_AvailableEmployees.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewEmployees_AvailableEmployees.ShowRowSelectionIfHidden = True
            Me.DataGridViewEmployees_AvailableEmployees.ShowSelectDeselectAllButtons = False
            Me.DataGridViewEmployees_AvailableEmployees.Size = New System.Drawing.Size(238, 417)
            Me.DataGridViewEmployees_AvailableEmployees.TabIndex = 23
            Me.DataGridViewEmployees_AvailableEmployees.UseEmbeddedNavigator = False
            Me.DataGridViewEmployees_AvailableEmployees.ViewCaptionHeight = -1
            '
            'TabItemCDPsAndEmployees_Employees
            '
            Me.TabItemCDPsAndEmployees_Employees.AttachedControl = Me.TabControlPanelEmployees_Employees
            Me.TabItemCDPsAndEmployees_Employees.Name = "TabItemCDPsAndEmployees_Employees"
            Me.TabItemCDPsAndEmployees_Employees.Text = "Employees"
            '
            'TextBoxRightSection_Name
            '
            Me.TextBoxRightSection_Name.AgencyImportPath = Nothing
            Me.TextBoxRightSection_Name.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxRightSection_Name.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxRightSection_Name.Border.Class = "TextBoxBorder"
            Me.TextBoxRightSection_Name.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxRightSection_Name.CheckSpellingOnValidate = False
            Me.TextBoxRightSection_Name.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxRightSection_Name.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxRightSection_Name.DisplayName = ""
            Me.TextBoxRightSection_Name.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxRightSection_Name.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxRightSection_Name.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxRightSection_Name.FocusHighlightEnabled = True
            Me.TextBoxRightSection_Name.ForeColor = System.Drawing.Color.Black
            Me.TextBoxRightSection_Name.Location = New System.Drawing.Point(93, 12)
            Me.TextBoxRightSection_Name.MaxFileSize = CType(0, Long)
            Me.TextBoxRightSection_Name.Name = "TextBoxRightSection_Name"
            Me.TextBoxRightSection_Name.SecurityEnabled = True
            Me.TextBoxRightSection_Name.ShowSpellCheckCompleteMessage = True
            Me.TextBoxRightSection_Name.Size = New System.Drawing.Size(506, 21)
            Me.TextBoxRightSection_Name.StartingFolderName = Nothing
            Me.TextBoxRightSection_Name.TabIndex = 7
            Me.TextBoxRightSection_Name.TabOnEnter = True
            '
            'LabelRightSection_Name
            '
            Me.LabelRightSection_Name.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRightSection_Name.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRightSection_Name.Location = New System.Drawing.Point(6, 12)
            Me.LabelRightSection_Name.Name = "LabelRightSection_Name"
            Me.LabelRightSection_Name.Size = New System.Drawing.Size(81, 21)
            Me.LabelRightSection_Name.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRightSection_Name.TabIndex = 6
            Me.LabelRightSection_Name.Text = "Name:"
            '
            'ButtonItemActions_Cancel
            '
            Me.ButtonItemActions_Cancel.BeginGroup = True
            Me.ButtonItemActions_Cancel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Cancel.Name = "ButtonItemActions_Cancel"
            Me.ButtonItemActions_Cancel.RibbonWordWrap = False
            Me.ButtonItemActions_Cancel.Stretch = True
            Me.ButtonItemActions_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Cancel.Text = "Cancel"
            '
            'CDPSecurityGroupSetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(909, 503)
            Me.Controls.Add(Me.PanelForm_RightSection)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.ExpandableSplitterControlForm_LeftRight)
            Me.Controls.Add(Me.PanelForm_LeftSection)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "CDPSecurityGroupSetupForm"
            Me.Text = "CDP Security Groups Maintenance"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_LeftSection.ResumeLayout(False)
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_RightSection.ResumeLayout(False)
            CType(Me.TabControlRightSection_CDPsAndEmployees, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlRightSection_CDPsAndEmployees.ResumeLayout(False)
            Me.TabControlPanelCDPs_CDPs.ResumeLayout(False)
            CType(Me.PanelCDPs_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelCDPs_RightSection.ResumeLayout(False)
            CType(Me.PanelCDPs_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelCDPs_LeftSection.ResumeLayout(False)
            Me.TabControlPanelEmployees_Employees.ResumeLayout(False)
            CType(Me.PanelEmployees_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelEmployees_RightSection.ResumeLayout(False)
            CType(Me.PanelEmployees_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelEmployees_LeftSection.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Add As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Delete As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents PanelForm_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ExpandableSplitterControlForm_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelForm_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ButtonItemActions_Refresh As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Save As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents DataGridViewLeftSection_CDPSecurityGroups As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents TextBoxRightSection_Name As WinForm.MVC.Presentation.Controls.TextBox
        Friend WithEvents LabelRightSection_Name As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents TabControlRightSection_CDPsAndEmployees As WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelEmployees_Employees As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemCDPsAndEmployees_Employees As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelCDPs_CDPs As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemCDPsAndEmployees_CDPs As DevComponents.DotNetBar.TabItem
        Friend WithEvents PanelEmployees_RightSection As WinForm.Presentation.Controls.Panel
        Friend WithEvents ButtonEmployees_RemoveEmployees As WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ButtonEmployees_AddEmployees As WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents DataGridViewEmployees_SelectedEmployees As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents ExpandableSplitterEmployees_LeftRight As WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelEmployees_LeftSection As WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewEmployees_AvailableEmployees As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents PanelCDPs_RightSection As WinForm.Presentation.Controls.Panel
        Friend WithEvents ButtonCDPs_RemoveCDPs As WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ButtonCDPs_AddCDPs As WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents DataGridViewCDPs_SelectedCDPs As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents ExpandableSplitterCDPs_LeftRight As WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelCDPs_LeftSection As WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewCDPs_AvailableCDPs As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents ButtonItemActions_Cancel As DevComponents.DotNetBar.ButtonItem
    End Class

End Namespace

