Namespace Security.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AdvantageInternalSecuritySetupForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdvantageInternalSecuritySetupForm))
            Me.AdvTreeForm_Modules = New DevComponents.AdvTree.AdvTree()
            Me.NodeConnector1 = New DevComponents.AdvTree.NodeConnector()
            Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle()
            Me.GroupBoxForm_ModuleInformation = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.TextBoxModuleInformation_Code = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelModuleInformation_Code = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxModuleInformation_Description = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelModuleInformation_Description = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxModuleInformation_ImageName = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelModuleInformation_ImageName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxModuleInformation_IsDesktopObject = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxModuleInformation_IsDashboardQuery = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxModuleInformation_IsReport = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxModuleInformation_IsCategory = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxModuleInformation_IsApplication = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxModuleInformation_IsMenuItem = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxModuleInformation_IsInactive = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.RibbonBarMergeContainerRightSection_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_View = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemView_ExpandAll = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemView_CollapseAll = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Add = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_CreateScript = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_EncryptFile = New DevComponents.DotNetBar.ButtonItem()
            Me.AdvTreeForm_Applications = New DevComponents.AdvTree.AdvTree()
            Me.NodeConnector2 = New DevComponents.AdvTree.NodeConnector()
            Me.ElementStyle2 = New DevComponents.DotNetBar.ElementStyle()
            Me.LabelForm_Applications = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ButtonItemActions_DecryptFile = New DevComponents.DotNetBar.ButtonItem()
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.AdvTreeForm_Modules, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxForm_ModuleInformation, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxForm_ModuleInformation.SuspendLayout()
            Me.RibbonBarMergeContainerRightSection_Options.SuspendLayout()
            CType(Me.AdvTreeForm_Applications, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'DefaultLookAndFeelOffice2010Blue
            '
            Me.DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
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
            Me.AdvTreeForm_Modules.DragDropNodeCopyEnabled = False
            Me.AdvTreeForm_Modules.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.AdvTreeForm_Modules.Location = New System.Drawing.Point(12, 12)
            Me.AdvTreeForm_Modules.MultiNodeDragDropAllowed = False
            Me.AdvTreeForm_Modules.MultiSelectRule = DevComponents.AdvTree.eMultiSelectRule.AnyNode
            Me.AdvTreeForm_Modules.Name = "AdvTreeForm_Modules"
            Me.AdvTreeForm_Modules.NodesConnector = Me.NodeConnector1
            Me.AdvTreeForm_Modules.NodeStyle = Me.ElementStyle1
            Me.AdvTreeForm_Modules.PathSeparator = ";"
            Me.AdvTreeForm_Modules.Size = New System.Drawing.Size(382, 365)
            Me.AdvTreeForm_Modules.Styles.Add(Me.ElementStyle1)
            Me.AdvTreeForm_Modules.TabIndex = 16
            '
            'NodeConnector1
            '
            Me.NodeConnector1.LineColor = System.Drawing.SystemColors.ControlText
            '
            'ElementStyle1
            '
            Me.ElementStyle1.Class = ""
            Me.ElementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ElementStyle1.Name = "ElementStyle1"
            Me.ElementStyle1.TextColor = System.Drawing.SystemColors.ControlText
            '
            'GroupBoxForm_ModuleInformation
            '
            Me.GroupBoxForm_ModuleInformation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxForm_ModuleInformation.Controls.Add(Me.TextBoxModuleInformation_Code)
            Me.GroupBoxForm_ModuleInformation.Controls.Add(Me.LabelModuleInformation_Code)
            Me.GroupBoxForm_ModuleInformation.Controls.Add(Me.TextBoxModuleInformation_Description)
            Me.GroupBoxForm_ModuleInformation.Controls.Add(Me.LabelModuleInformation_Description)
            Me.GroupBoxForm_ModuleInformation.Controls.Add(Me.TextBoxModuleInformation_ImageName)
            Me.GroupBoxForm_ModuleInformation.Controls.Add(Me.LabelModuleInformation_ImageName)
            Me.GroupBoxForm_ModuleInformation.Controls.Add(Me.CheckBoxModuleInformation_IsDesktopObject)
            Me.GroupBoxForm_ModuleInformation.Controls.Add(Me.CheckBoxModuleInformation_IsDashboardQuery)
            Me.GroupBoxForm_ModuleInformation.Controls.Add(Me.CheckBoxModuleInformation_IsReport)
            Me.GroupBoxForm_ModuleInformation.Controls.Add(Me.CheckBoxModuleInformation_IsCategory)
            Me.GroupBoxForm_ModuleInformation.Controls.Add(Me.CheckBoxModuleInformation_IsApplication)
            Me.GroupBoxForm_ModuleInformation.Controls.Add(Me.CheckBoxModuleInformation_IsMenuItem)
            Me.GroupBoxForm_ModuleInformation.Controls.Add(Me.CheckBoxModuleInformation_IsInactive)
            Me.GroupBoxForm_ModuleInformation.Location = New System.Drawing.Point(400, 12)
            Me.GroupBoxForm_ModuleInformation.Name = "GroupBoxForm_ModuleInformation"
            Me.GroupBoxForm_ModuleInformation.Size = New System.Drawing.Size(446, 154)
            Me.GroupBoxForm_ModuleInformation.TabIndex = 17
            Me.GroupBoxForm_ModuleInformation.Text = "Module Information"
            '
            'TextBoxModuleInformation_Code
            '
            Me.TextBoxModuleInformation_Code.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxModuleInformation_Code.Border.Class = "TextBoxBorder"
            Me.TextBoxModuleInformation_Code.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxModuleInformation_Code.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxModuleInformation_Code.Enabled = False
            Me.TextBoxModuleInformation_Code.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxModuleInformation_Code.FocusHighlightEnabled = True
            Me.TextBoxModuleInformation_Code.Location = New System.Drawing.Point(91, 77)
            Me.TextBoxModuleInformation_Code.Name = "TextBoxModuleInformation_Code"
            Me.TextBoxModuleInformation_Code.Size = New System.Drawing.Size(348, 20)
            Me.TextBoxModuleInformation_Code.TabIndex = 37
            Me.TextBoxModuleInformation_Code.TabOnEnter = True
            '
            'LabelModuleInformation_Code
            '
            Me.LabelModuleInformation_Code.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelModuleInformation_Code.BackgroundStyle.Class = ""
            Me.LabelModuleInformation_Code.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelModuleInformation_Code.Location = New System.Drawing.Point(5, 77)
            Me.LabelModuleInformation_Code.Name = "LabelModuleInformation_Code"
            Me.LabelModuleInformation_Code.Size = New System.Drawing.Size(80, 20)
            Me.LabelModuleInformation_Code.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelModuleInformation_Code.TabIndex = 36
            Me.LabelModuleInformation_Code.Text = "Code:"
            '
            'TextBoxModuleInformation_Description
            '
            Me.TextBoxModuleInformation_Description.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxModuleInformation_Description.Border.Class = "TextBoxBorder"
            Me.TextBoxModuleInformation_Description.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxModuleInformation_Description.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxModuleInformation_Description.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxModuleInformation_Description.FocusHighlightEnabled = True
            Me.TextBoxModuleInformation_Description.Location = New System.Drawing.Point(91, 103)
            Me.TextBoxModuleInformation_Description.Name = "TextBoxModuleInformation_Description"
            Me.TextBoxModuleInformation_Description.Size = New System.Drawing.Size(348, 20)
            Me.TextBoxModuleInformation_Description.TabIndex = 32
            Me.TextBoxModuleInformation_Description.TabOnEnter = True
            '
            'LabelModuleInformation_Description
            '
            Me.LabelModuleInformation_Description.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelModuleInformation_Description.BackgroundStyle.Class = ""
            Me.LabelModuleInformation_Description.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelModuleInformation_Description.Location = New System.Drawing.Point(5, 103)
            Me.LabelModuleInformation_Description.Name = "LabelModuleInformation_Description"
            Me.LabelModuleInformation_Description.Size = New System.Drawing.Size(80, 20)
            Me.LabelModuleInformation_Description.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelModuleInformation_Description.TabIndex = 31
            Me.LabelModuleInformation_Description.Text = "Description:"
            '
            'TextBoxModuleInformation_ImageName
            '
            Me.TextBoxModuleInformation_ImageName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxModuleInformation_ImageName.Border.Class = "TextBoxBorder"
            Me.TextBoxModuleInformation_ImageName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxModuleInformation_ImageName.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxModuleInformation_ImageName.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxModuleInformation_ImageName.FocusHighlightEnabled = True
            Me.TextBoxModuleInformation_ImageName.Location = New System.Drawing.Point(91, 129)
            Me.TextBoxModuleInformation_ImageName.Name = "TextBoxModuleInformation_ImageName"
            Me.TextBoxModuleInformation_ImageName.Size = New System.Drawing.Size(348, 20)
            Me.TextBoxModuleInformation_ImageName.TabIndex = 28
            Me.TextBoxModuleInformation_ImageName.TabOnEnter = True
            '
            'LabelModuleInformation_ImageName
            '
            Me.LabelModuleInformation_ImageName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelModuleInformation_ImageName.BackgroundStyle.Class = ""
            Me.LabelModuleInformation_ImageName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelModuleInformation_ImageName.Location = New System.Drawing.Point(5, 129)
            Me.LabelModuleInformation_ImageName.Name = "LabelModuleInformation_ImageName"
            Me.LabelModuleInformation_ImageName.Size = New System.Drawing.Size(80, 20)
            Me.LabelModuleInformation_ImageName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelModuleInformation_ImageName.TabIndex = 19
            Me.LabelModuleInformation_ImageName.Text = "Image Name:"
            '
            'CheckBoxModuleInformation_IsDesktopObject
            '
            '
            '
            '
            Me.CheckBoxModuleInformation_IsDesktopObject.BackgroundStyle.Class = ""
            Me.CheckBoxModuleInformation_IsDesktopObject.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxModuleInformation_IsDesktopObject.CheckValue = 0
            Me.CheckBoxModuleInformation_IsDesktopObject.CheckValueChecked = 1
            Me.CheckBoxModuleInformation_IsDesktopObject.CheckValueUnchecked = 0
            Me.CheckBoxModuleInformation_IsDesktopObject.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxModuleInformation_IsDesktopObject.Location = New System.Drawing.Point(193, 51)
            Me.CheckBoxModuleInformation_IsDesktopObject.Name = "CheckBoxModuleInformation_IsDesktopObject"
            Me.CheckBoxModuleInformation_IsDesktopObject.Size = New System.Drawing.Size(108, 20)
            Me.CheckBoxModuleInformation_IsDesktopObject.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxModuleInformation_IsDesktopObject.TabIndex = 18
            Me.CheckBoxModuleInformation_IsDesktopObject.Text = "Is Desktop Object"
            '
            'CheckBoxModuleInformation_IsDashboardQuery
            '
            '
            '
            '
            Me.CheckBoxModuleInformation_IsDashboardQuery.BackgroundStyle.Class = ""
            Me.CheckBoxModuleInformation_IsDashboardQuery.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxModuleInformation_IsDashboardQuery.CheckValue = 0
            Me.CheckBoxModuleInformation_IsDashboardQuery.CheckValueChecked = 1
            Me.CheckBoxModuleInformation_IsDashboardQuery.CheckValueUnchecked = 0
            Me.CheckBoxModuleInformation_IsDashboardQuery.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxModuleInformation_IsDashboardQuery.Location = New System.Drawing.Point(307, 51)
            Me.CheckBoxModuleInformation_IsDashboardQuery.Name = "CheckBoxModuleInformation_IsDashboardQuery"
            Me.CheckBoxModuleInformation_IsDashboardQuery.Size = New System.Drawing.Size(122, 20)
            Me.CheckBoxModuleInformation_IsDashboardQuery.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxModuleInformation_IsDashboardQuery.TabIndex = 17
            Me.CheckBoxModuleInformation_IsDashboardQuery.Text = "Is Dashboard\Query"
            '
            'CheckBoxModuleInformation_IsReport
            '
            '
            '
            '
            Me.CheckBoxModuleInformation_IsReport.BackgroundStyle.Class = ""
            Me.CheckBoxModuleInformation_IsReport.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxModuleInformation_IsReport.CheckValue = 0
            Me.CheckBoxModuleInformation_IsReport.CheckValueChecked = 1
            Me.CheckBoxModuleInformation_IsReport.CheckValueUnchecked = 0
            Me.CheckBoxModuleInformation_IsReport.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxModuleInformation_IsReport.Location = New System.Drawing.Point(99, 51)
            Me.CheckBoxModuleInformation_IsReport.Name = "CheckBoxModuleInformation_IsReport"
            Me.CheckBoxModuleInformation_IsReport.Size = New System.Drawing.Size(88, 20)
            Me.CheckBoxModuleInformation_IsReport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxModuleInformation_IsReport.TabIndex = 16
            Me.CheckBoxModuleInformation_IsReport.Text = "Is Report"
            '
            'CheckBoxModuleInformation_IsCategory
            '
            '
            '
            '
            Me.CheckBoxModuleInformation_IsCategory.BackgroundStyle.Class = ""
            Me.CheckBoxModuleInformation_IsCategory.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxModuleInformation_IsCategory.CheckValue = 0
            Me.CheckBoxModuleInformation_IsCategory.CheckValueChecked = 1
            Me.CheckBoxModuleInformation_IsCategory.CheckValueUnchecked = 0
            Me.CheckBoxModuleInformation_IsCategory.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxModuleInformation_IsCategory.Enabled = False
            Me.CheckBoxModuleInformation_IsCategory.Location = New System.Drawing.Point(193, 25)
            Me.CheckBoxModuleInformation_IsCategory.Name = "CheckBoxModuleInformation_IsCategory"
            Me.CheckBoxModuleInformation_IsCategory.Size = New System.Drawing.Size(81, 20)
            Me.CheckBoxModuleInformation_IsCategory.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxModuleInformation_IsCategory.TabIndex = 15
            Me.CheckBoxModuleInformation_IsCategory.Text = "Is Category"
            '
            'CheckBoxModuleInformation_IsApplication
            '
            '
            '
            '
            Me.CheckBoxModuleInformation_IsApplication.BackgroundStyle.Class = ""
            Me.CheckBoxModuleInformation_IsApplication.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxModuleInformation_IsApplication.CheckValue = 0
            Me.CheckBoxModuleInformation_IsApplication.CheckValueChecked = 1
            Me.CheckBoxModuleInformation_IsApplication.CheckValueUnchecked = 0
            Me.CheckBoxModuleInformation_IsApplication.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxModuleInformation_IsApplication.Location = New System.Drawing.Point(5, 51)
            Me.CheckBoxModuleInformation_IsApplication.Name = "CheckBoxModuleInformation_IsApplication"
            Me.CheckBoxModuleInformation_IsApplication.Size = New System.Drawing.Size(88, 20)
            Me.CheckBoxModuleInformation_IsApplication.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxModuleInformation_IsApplication.TabIndex = 14
            Me.CheckBoxModuleInformation_IsApplication.Text = "Is Application"
            '
            'CheckBoxModuleInformation_IsMenuItem
            '
            '
            '
            '
            Me.CheckBoxModuleInformation_IsMenuItem.BackgroundStyle.Class = ""
            Me.CheckBoxModuleInformation_IsMenuItem.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxModuleInformation_IsMenuItem.CheckValue = 0
            Me.CheckBoxModuleInformation_IsMenuItem.CheckValueChecked = 1
            Me.CheckBoxModuleInformation_IsMenuItem.CheckValueUnchecked = 0
            Me.CheckBoxModuleInformation_IsMenuItem.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxModuleInformation_IsMenuItem.Location = New System.Drawing.Point(99, 25)
            Me.CheckBoxModuleInformation_IsMenuItem.Name = "CheckBoxModuleInformation_IsMenuItem"
            Me.CheckBoxModuleInformation_IsMenuItem.Size = New System.Drawing.Size(88, 20)
            Me.CheckBoxModuleInformation_IsMenuItem.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxModuleInformation_IsMenuItem.TabIndex = 13
            Me.CheckBoxModuleInformation_IsMenuItem.Text = "Is Menu Item"
            '
            'CheckBoxModuleInformation_IsInactive
            '
            '
            '
            '
            Me.CheckBoxModuleInformation_IsInactive.BackgroundStyle.Class = ""
            Me.CheckBoxModuleInformation_IsInactive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxModuleInformation_IsInactive.CheckValue = 0
            Me.CheckBoxModuleInformation_IsInactive.CheckValueChecked = 1
            Me.CheckBoxModuleInformation_IsInactive.CheckValueUnchecked = 0
            Me.CheckBoxModuleInformation_IsInactive.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxModuleInformation_IsInactive.Location = New System.Drawing.Point(5, 25)
            Me.CheckBoxModuleInformation_IsInactive.Name = "CheckBoxModuleInformation_IsInactive"
            Me.CheckBoxModuleInformation_IsInactive.Size = New System.Drawing.Size(88, 20)
            Me.CheckBoxModuleInformation_IsInactive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxModuleInformation_IsInactive.TabIndex = 12
            Me.CheckBoxModuleInformation_IsInactive.Text = "Is Inactive"
            '
            'RibbonBarMergeContainerRightSection_Options
            '
            Me.RibbonBarMergeContainerRightSection_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerRightSection_Options.Controls.Add(Me.RibbonBarOptions_View)
            Me.RibbonBarMergeContainerRightSection_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerRightSection_Options.Location = New System.Drawing.Point(450, 172)
            Me.RibbonBarMergeContainerRightSection_Options.Name = "RibbonBarMergeContainerRightSection_Options"
            Me.RibbonBarMergeContainerRightSection_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerRightSection_Options.Size = New System.Drawing.Size(377, 98)
            '
            '
            '
            Me.RibbonBarMergeContainerRightSection_Options.Style.Class = ""
            Me.RibbonBarMergeContainerRightSection_Options.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerRightSection_Options.StyleMouseDown.Class = ""
            Me.RibbonBarMergeContainerRightSection_Options.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerRightSection_Options.StyleMouseOver.Class = ""
            Me.RibbonBarMergeContainerRightSection_Options.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarMergeContainerRightSection_Options.TabIndex = 18
            Me.RibbonBarMergeContainerRightSection_Options.Visible = False
            '
            'RibbonBarOptions_View
            '
            Me.RibbonBarOptions_View.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_View.BackgroundMouseOverStyle.Class = ""
            Me.RibbonBarOptions_View.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_View.BackgroundStyle.Class = ""
            Me.RibbonBarOptions_View.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_View.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_View.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_View.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemView_ExpandAll, Me.ButtonItemView_CollapseAll})
            Me.RibbonBarOptions_View.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.RibbonBarOptions_View.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_View.Location = New System.Drawing.Point(251, 0)
            Me.RibbonBarOptions_View.Name = "RibbonBarOptions_View"
            Me.RibbonBarOptions_View.Size = New System.Drawing.Size(72, 98)
            Me.RibbonBarOptions_View.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_View.TabIndex = 4
            Me.RibbonBarOptions_View.Text = "View"
            '
            '
            '
            Me.RibbonBarOptions_View.TitleStyle.Class = ""
            Me.RibbonBarOptions_View.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_View.TitleStyleMouseOver.Class = ""
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
            Me.RibbonBarOptions_Actions.BackgroundMouseOverStyle.Class = ""
            Me.RibbonBarOptions_Actions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Actions.BackgroundStyle.Class = ""
            Me.RibbonBarOptions_Actions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Actions.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Actions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Add, Me.ButtonItemActions_CreateScript, Me.ButtonItemActions_EncryptFile, Me.ButtonItemActions_DecryptFile})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(251, 98)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 0
            Me.RibbonBarOptions_Actions.Text = "Actions"
            '
            '
            '
            Me.RibbonBarOptions_Actions.TitleStyle.Class = ""
            Me.RibbonBarOptions_Actions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Actions.TitleStyleMouseOver.Class = ""
            Me.RibbonBarOptions_Actions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Actions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemActions_Add
            '
            Me.ButtonItemActions_Add.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Add.Name = "ButtonItemActions_Add"
            Me.ButtonItemActions_Add.RibbonWordWrap = False
            Me.ButtonItemActions_Add.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Add.Text = "Add"
            '
            'ButtonItemActions_CreateScript
            '
            Me.ButtonItemActions_CreateScript.BeginGroup = True
            Me.ButtonItemActions_CreateScript.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_CreateScript.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_CreateScript.Name = "ButtonItemActions_CreateScript"
            Me.ButtonItemActions_CreateScript.SubItemsExpandWidth = 14
            Me.ButtonItemActions_CreateScript.Text = "Create Script"
            '
            'ButtonItemActions_EncryptFile
            '
            Me.ButtonItemActions_EncryptFile.BeginGroup = True
            Me.ButtonItemActions_EncryptFile.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_EncryptFile.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_EncryptFile.Name = "ButtonItemActions_EncryptFile"
            Me.ButtonItemActions_EncryptFile.SubItemsExpandWidth = 14
            Me.ButtonItemActions_EncryptFile.Text = "Encrypt File"
            '
            'AdvTreeForm_Applications
            '
            Me.AdvTreeForm_Applications.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline
            Me.AdvTreeForm_Applications.AllowDrop = True
            Me.AdvTreeForm_Applications.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.AdvTreeForm_Applications.BackColor = System.Drawing.SystemColors.Window
            '
            '
            '
            Me.AdvTreeForm_Applications.BackgroundStyle.Class = "TreeBorderKey"
            Me.AdvTreeForm_Applications.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.AdvTreeForm_Applications.DragDropEnabled = False
            Me.AdvTreeForm_Applications.DragDropNodeCopyEnabled = False
            Me.AdvTreeForm_Applications.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.AdvTreeForm_Applications.Location = New System.Drawing.Point(400, 198)
            Me.AdvTreeForm_Applications.MultiNodeDragCountVisible = False
            Me.AdvTreeForm_Applications.MultiNodeDragDropAllowed = False
            Me.AdvTreeForm_Applications.Name = "AdvTreeForm_Applications"
            Me.AdvTreeForm_Applications.NodesConnector = Me.NodeConnector2
            Me.AdvTreeForm_Applications.NodeStyle = Me.ElementStyle2
            Me.AdvTreeForm_Applications.PathSeparator = ";"
            Me.AdvTreeForm_Applications.SelectionBoxStyle = DevComponents.AdvTree.eSelectionStyle.FullRowSelect
            Me.AdvTreeForm_Applications.Size = New System.Drawing.Size(446, 179)
            Me.AdvTreeForm_Applications.Styles.Add(Me.ElementStyle2)
            Me.AdvTreeForm_Applications.TabIndex = 20
            Me.AdvTreeForm_Applications.Text = "AdvTree1"
            '
            'NodeConnector2
            '
            Me.NodeConnector2.LineColor = System.Drawing.SystemColors.ControlText
            '
            'ElementStyle2
            '
            Me.ElementStyle2.Class = ""
            Me.ElementStyle2.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ElementStyle2.Name = "ElementStyle2"
            Me.ElementStyle2.TextColor = System.Drawing.SystemColors.ControlText
            '
            'LabelForm_Applications
            '
            Me.LabelForm_Applications.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_Applications.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Applications.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_Applications.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_Applications.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_Applications.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_Applications.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_Applications.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_Applications.BackgroundStyle.Class = ""
            Me.LabelForm_Applications.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Applications.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelForm_Applications.Location = New System.Drawing.Point(400, 172)
            Me.LabelForm_Applications.Name = "LabelForm_Applications"
            Me.LabelForm_Applications.Size = New System.Drawing.Size(446, 20)
            Me.LabelForm_Applications.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Applications.TabIndex = 21
            Me.LabelForm_Applications.Text = "Applications"
            '
            'ButtonItemActions_DecryptFile
            '
            Me.ButtonItemActions_DecryptFile.BeginGroup = True
            Me.ButtonItemActions_DecryptFile.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_DecryptFile.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_DecryptFile.Name = "ButtonItemActions_DecryptFile"
            Me.ButtonItemActions_DecryptFile.SubItemsExpandWidth = 14
            Me.ButtonItemActions_DecryptFile.Text = "Decrypt File"
            '
            'AdvantageInternalSecuritySetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(858, 389)
            Me.Controls.Add(Me.GroupBoxForm_ModuleInformation)
            Me.Controls.Add(Me.RibbonBarMergeContainerRightSection_Options)
            Me.Controls.Add(Me.AdvTreeForm_Modules)
            Me.Controls.Add(Me.AdvTreeForm_Applications)
            Me.Controls.Add(Me.LabelForm_Applications)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "AdvantageInternalSecuritySetupForm"
            Me.Text = "Advantage Internal Security Setup"
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.AdvTreeForm_Modules, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxForm_ModuleInformation, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxForm_ModuleInformation.ResumeLayout(False)
            Me.RibbonBarMergeContainerRightSection_Options.ResumeLayout(False)
            CType(Me.AdvTreeForm_Applications, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents AdvTreeForm_Modules As DevComponents.AdvTree.AdvTree
        Friend WithEvents NodeConnector1 As DevComponents.AdvTree.NodeConnector
        Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
        Friend WithEvents GroupBoxForm_ModuleInformation As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents TextBoxModuleInformation_Code As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelModuleInformation_Code As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxModuleInformation_Description As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelModuleInformation_Description As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxModuleInformation_ImageName As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelModuleInformation_ImageName As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxModuleInformation_IsDesktopObject As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxModuleInformation_IsDashboardQuery As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxModuleInformation_IsReport As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxModuleInformation_IsCategory As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxModuleInformation_IsApplication As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxModuleInformation_IsMenuItem As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxModuleInformation_IsInactive As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents RibbonBarMergeContainerRightSection_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_View As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemView_ExpandAll As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemView_CollapseAll As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Add As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_CreateScript As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents AdvTreeForm_Applications As DevComponents.AdvTree.AdvTree
        Friend WithEvents NodeConnector2 As DevComponents.AdvTree.NodeConnector
        Friend WithEvents ElementStyle2 As DevComponents.DotNetBar.ElementStyle
        Friend WithEvents LabelForm_Applications As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonItemActions_EncryptFile As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_DecryptFile As DevComponents.DotNetBar.ButtonItem
    End Class

End Namespace