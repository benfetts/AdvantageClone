Namespace Maintenance.General.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class DocumentsSetupForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DocumentsSetupForm))
            Me.TabControlForm_AgencySetup = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelSystemAndAlertOptionsTab_SystemAndAlertOptions = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.PictureBox1 = New System.Windows.Forms.PictureBox()
            Me.CheckBoxOptions_LabelInactive = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.DevCompColor = New DevComponents.DotNetBar.ColorPickerButton()
            Me.LabelContactInformation_FirstName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxLabelInformation_Description = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelContactInformation_LastName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxLabelInformation_Name = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelContactInformation_Title = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ExpandableSplitterControlForm_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelForm_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.CheckBoxOptions_ShowInactive = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.RadTreeViewRightSection_DivisionProducts = New Telerik.WinControls.UI.RadTreeView()
            Me.TabItemDocumentsSetup_Labels = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelInformationTab_Information = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewForm_Types = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemDocumentsSetup_Types = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Export = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Add = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Save = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Delete = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Cancel = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            CType(Me.TabControlForm_AgencySetup, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_AgencySetup.SuspendLayout()
            Me.TabControlPanelSystemAndAlertOptionsTab_SystemAndAlertOptions.SuspendLayout()
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_RightSection.SuspendLayout()
            CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_LeftSection.SuspendLayout()
            CType(Me.RadTreeViewRightSection_DivisionProducts, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelInformationTab_Information.SuspendLayout()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.SuspendLayout()
            '
            'TabControlForm_AgencySetup
            '
            Me.TabControlForm_AgencySetup.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlForm_AgencySetup.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
            Me.TabControlForm_AgencySetup.CanReorderTabs = False
            Me.TabControlForm_AgencySetup.Controls.Add(Me.TabControlPanelSystemAndAlertOptionsTab_SystemAndAlertOptions)
            Me.TabControlForm_AgencySetup.Controls.Add(Me.TabControlPanelInformationTab_Information)
            Me.TabControlForm_AgencySetup.ForeColor = System.Drawing.Color.Black
            Me.TabControlForm_AgencySetup.Location = New System.Drawing.Point(12, 12)
            Me.TabControlForm_AgencySetup.Name = "TabControlForm_AgencySetup"
            Me.TabControlForm_AgencySetup.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_AgencySetup.SelectedTabIndex = 0
            Me.TabControlForm_AgencySetup.Size = New System.Drawing.Size(1021, 573)
            Me.TabControlForm_AgencySetup.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_AgencySetup.TabIndex = 22
            Me.TabControlForm_AgencySetup.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_AgencySetup.Tabs.Add(Me.TabItemDocumentsSetup_Types)
            Me.TabControlForm_AgencySetup.Tabs.Add(Me.TabItemDocumentsSetup_Labels)
            '
            'TabControlPanelSystemAndAlertOptionsTab_SystemAndAlertOptions
            '
            Me.TabControlPanelSystemAndAlertOptionsTab_SystemAndAlertOptions.AutoScroll = True
            Me.TabControlPanelSystemAndAlertOptionsTab_SystemAndAlertOptions.Controls.Add(Me.PanelForm_RightSection)
            Me.TabControlPanelSystemAndAlertOptionsTab_SystemAndAlertOptions.Controls.Add(Me.ExpandableSplitterControlForm_LeftRight)
            Me.TabControlPanelSystemAndAlertOptionsTab_SystemAndAlertOptions.Controls.Add(Me.PanelForm_LeftSection)
            Me.TabControlPanelSystemAndAlertOptionsTab_SystemAndAlertOptions.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSystemAndAlertOptionsTab_SystemAndAlertOptions.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSystemAndAlertOptionsTab_SystemAndAlertOptions.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelSystemAndAlertOptionsTab_SystemAndAlertOptions.Name = "TabControlPanelSystemAndAlertOptionsTab_SystemAndAlertOptions"
            Me.TabControlPanelSystemAndAlertOptionsTab_SystemAndAlertOptions.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSystemAndAlertOptionsTab_SystemAndAlertOptions.Size = New System.Drawing.Size(1021, 546)
            Me.TabControlPanelSystemAndAlertOptionsTab_SystemAndAlertOptions.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSystemAndAlertOptionsTab_SystemAndAlertOptions.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSystemAndAlertOptionsTab_SystemAndAlertOptions.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSystemAndAlertOptionsTab_SystemAndAlertOptions.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSystemAndAlertOptionsTab_SystemAndAlertOptions.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSystemAndAlertOptionsTab_SystemAndAlertOptions.Style.GradientAngle = 90
            Me.TabControlPanelSystemAndAlertOptionsTab_SystemAndAlertOptions.TabIndex = 2
            Me.TabControlPanelSystemAndAlertOptionsTab_SystemAndAlertOptions.TabItem = Me.TabItemDocumentsSetup_Labels
            '
            'PanelForm_RightSection
            '
            Me.PanelForm_RightSection.Controls.Add(Me.PictureBox1)
            Me.PanelForm_RightSection.Controls.Add(Me.CheckBoxOptions_LabelInactive)
            Me.PanelForm_RightSection.Controls.Add(Me.DevCompColor)
            Me.PanelForm_RightSection.Controls.Add(Me.LabelContactInformation_FirstName)
            Me.PanelForm_RightSection.Controls.Add(Me.TextBoxLabelInformation_Description)
            Me.PanelForm_RightSection.Controls.Add(Me.LabelContactInformation_LastName)
            Me.PanelForm_RightSection.Controls.Add(Me.TextBoxLabelInformation_Name)
            Me.PanelForm_RightSection.Controls.Add(Me.LabelContactInformation_Title)
            Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_RightSection.Location = New System.Drawing.Point(324, 1)
            Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
            Me.PanelForm_RightSection.Size = New System.Drawing.Size(696, 544)
            Me.PanelForm_RightSection.TabIndex = 8
            '
            'PictureBox1
            '
            Me.PictureBox1.BackColor = System.Drawing.Color.White
            Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.PictureBox1.Location = New System.Drawing.Point(82, 61)
            Me.PictureBox1.Name = "PictureBox1"
            Me.PictureBox1.Size = New System.Drawing.Size(125, 21)
            Me.PictureBox1.TabIndex = 15
            Me.PictureBox1.TabStop = False
            '
            'CheckBoxOptions_LabelInactive
            '
            Me.CheckBoxOptions_LabelInactive.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxOptions_LabelInactive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxOptions_LabelInactive.CheckValue = 0
            Me.CheckBoxOptions_LabelInactive.CheckValueChecked = 1
            Me.CheckBoxOptions_LabelInactive.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxOptions_LabelInactive.CheckValueUnchecked = 0
            Me.CheckBoxOptions_LabelInactive.ChildControls = CType(resources.GetObject("CheckBoxOptions_LabelInactive.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxOptions_LabelInactive.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxOptions_LabelInactive.Location = New System.Drawing.Point(598, 5)
            Me.CheckBoxOptions_LabelInactive.Name = "CheckBoxOptions_LabelInactive"
            Me.CheckBoxOptions_LabelInactive.OldestSibling = Nothing
            Me.CheckBoxOptions_LabelInactive.SecurityEnabled = True
            Me.CheckBoxOptions_LabelInactive.SiblingControls = CType(resources.GetObject("CheckBoxOptions_LabelInactive.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxOptions_LabelInactive.Size = New System.Drawing.Size(93, 20)
            Me.CheckBoxOptions_LabelInactive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxOptions_LabelInactive.TabIndex = 12
            Me.CheckBoxOptions_LabelInactive.TabOnEnter = True
            Me.CheckBoxOptions_LabelInactive.Text = "Active"
            '
            'DevCompColor
            '
            Me.DevCompColor.AccessibleRole = System.Windows.Forms.AccessibleRole.Text
            Me.DevCompColor.DisplayMoreColors = False
            Me.DevCompColor.DisplayThemeColors = False
            Me.DevCompColor.Location = New System.Drawing.Point(210, 61)
            Me.DevCompColor.Name = "DevCompColor"
            Me.DevCompColor.Size = New System.Drawing.Size(14, 21)
            Me.DevCompColor.SplitButton = True
            Me.DevCompColor.TabIndex = 13
            '
            'LabelContactInformation_FirstName
            '
            Me.LabelContactInformation_FirstName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelContactInformation_FirstName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelContactInformation_FirstName.Location = New System.Drawing.Point(6, 5)
            Me.LabelContactInformation_FirstName.Name = "LabelContactInformation_FirstName"
            Me.LabelContactInformation_FirstName.Size = New System.Drawing.Size(70, 21)
            Me.LabelContactInformation_FirstName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelContactInformation_FirstName.TabIndex = 1
            Me.LabelContactInformation_FirstName.Text = "Name:"
            '
            'TextBoxLabelInformation_Description
            '
            Me.TextBoxLabelInformation_Description.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxLabelInformation_Description.Border.Class = "TextBoxBorder"
            Me.TextBoxLabelInformation_Description.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxLabelInformation_Description.CheckSpellingOnValidate = False
            Me.TextBoxLabelInformation_Description.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxLabelInformation_Description.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxLabelInformation_Description.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxLabelInformation_Description.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxLabelInformation_Description.FocusHighlightEnabled = True
            Me.TextBoxLabelInformation_Description.Location = New System.Drawing.Point(82, 32)
            Me.TextBoxLabelInformation_Description.MaxFileSize = CType(0, Long)
            Me.TextBoxLabelInformation_Description.MaxLength = 100
            Me.TextBoxLabelInformation_Description.Name = "TextBoxLabelInformation_Description"
            Me.TextBoxLabelInformation_Description.SecurityEnabled = True
            Me.TextBoxLabelInformation_Description.ShowSpellCheckCompleteMessage = True
            Me.TextBoxLabelInformation_Description.Size = New System.Drawing.Size(510, 21)
            Me.TextBoxLabelInformation_Description.StartingFolderName = Nothing
            Me.TextBoxLabelInformation_Description.TabIndex = 6
            Me.TextBoxLabelInformation_Description.TabOnEnter = True
            '
            'LabelContactInformation_LastName
            '
            Me.LabelContactInformation_LastName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelContactInformation_LastName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelContactInformation_LastName.Location = New System.Drawing.Point(5, 32)
            Me.LabelContactInformation_LastName.Name = "LabelContactInformation_LastName"
            Me.LabelContactInformation_LastName.Size = New System.Drawing.Size(64, 21)
            Me.LabelContactInformation_LastName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelContactInformation_LastName.TabIndex = 5
            Me.LabelContactInformation_LastName.Text = "Description:"
            '
            'TextBoxLabelInformation_Name
            '
            Me.TextBoxLabelInformation_Name.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxLabelInformation_Name.Border.Class = "TextBoxBorder"
            Me.TextBoxLabelInformation_Name.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxLabelInformation_Name.CheckSpellingOnValidate = False
            Me.TextBoxLabelInformation_Name.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxLabelInformation_Name.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxLabelInformation_Name.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxLabelInformation_Name.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxLabelInformation_Name.FocusHighlightEnabled = True
            Me.TextBoxLabelInformation_Name.Location = New System.Drawing.Point(82, 5)
            Me.TextBoxLabelInformation_Name.MaxFileSize = CType(0, Long)
            Me.TextBoxLabelInformation_Name.MaxLength = 30
            Me.TextBoxLabelInformation_Name.Name = "TextBoxLabelInformation_Name"
            Me.TextBoxLabelInformation_Name.SecurityEnabled = True
            Me.TextBoxLabelInformation_Name.ShowSpellCheckCompleteMessage = True
            Me.TextBoxLabelInformation_Name.Size = New System.Drawing.Size(510, 21)
            Me.TextBoxLabelInformation_Name.StartingFolderName = Nothing
            Me.TextBoxLabelInformation_Name.TabIndex = 2
            Me.TextBoxLabelInformation_Name.TabOnEnter = True
            '
            'LabelContactInformation_Title
            '
            Me.LabelContactInformation_Title.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelContactInformation_Title.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelContactInformation_Title.Location = New System.Drawing.Point(6, 59)
            Me.LabelContactInformation_Title.Name = "LabelContactInformation_Title"
            Me.LabelContactInformation_Title.Size = New System.Drawing.Size(70, 20)
            Me.LabelContactInformation_Title.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelContactInformation_Title.TabIndex = 7
            Me.LabelContactInformation_Title.Text = "Color:"
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
            Me.ExpandableSplitterControlForm_LeftRight.Location = New System.Drawing.Point(318, 1)
            Me.ExpandableSplitterControlForm_LeftRight.Name = "ExpandableSplitterControlForm_LeftRight"
            Me.ExpandableSplitterControlForm_LeftRight.Size = New System.Drawing.Size(6, 544)
            Me.ExpandableSplitterControlForm_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlForm_LeftRight.TabIndex = 9
            Me.ExpandableSplitterControlForm_LeftRight.TabStop = False
            '
            'PanelForm_LeftSection
            '
            Me.PanelForm_LeftSection.Controls.Add(Me.CheckBoxOptions_ShowInactive)
            Me.PanelForm_LeftSection.Controls.Add(Me.RadTreeViewRightSection_DivisionProducts)
            Me.PanelForm_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelForm_LeftSection.Location = New System.Drawing.Point(1, 1)
            Me.PanelForm_LeftSection.Name = "PanelForm_LeftSection"
            Me.PanelForm_LeftSection.Size = New System.Drawing.Size(317, 544)
            Me.PanelForm_LeftSection.TabIndex = 5
            '
            'CheckBoxOptions_ShowInactive
            '
            Me.CheckBoxOptions_ShowInactive.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxOptions_ShowInactive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxOptions_ShowInactive.CheckValue = 0
            Me.CheckBoxOptions_ShowInactive.CheckValueChecked = 1
            Me.CheckBoxOptions_ShowInactive.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxOptions_ShowInactive.CheckValueUnchecked = 0
            Me.CheckBoxOptions_ShowInactive.ChildControls = CType(resources.GetObject("CheckBoxOptions_ShowInactive.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxOptions_ShowInactive.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxOptions_ShowInactive.Location = New System.Drawing.Point(5, 519)
            Me.CheckBoxOptions_ShowInactive.Name = "CheckBoxOptions_ShowInactive"
            Me.CheckBoxOptions_ShowInactive.OldestSibling = Nothing
            Me.CheckBoxOptions_ShowInactive.SecurityEnabled = True
            Me.CheckBoxOptions_ShowInactive.SiblingControls = CType(resources.GetObject("CheckBoxOptions_ShowInactive.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxOptions_ShowInactive.Size = New System.Drawing.Size(306, 20)
            Me.CheckBoxOptions_ShowInactive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxOptions_ShowInactive.TabIndex = 11
            Me.CheckBoxOptions_ShowInactive.TabOnEnter = True
            Me.CheckBoxOptions_ShowInactive.Text = "Show Inactive"
            '
            'RadTreeViewRightSection_DivisionProducts
            '
            Me.RadTreeViewRightSection_DivisionProducts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadTreeViewRightSection_DivisionProducts.AutoCheckChildNodes = False
            Me.RadTreeViewRightSection_DivisionProducts.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
            Me.RadTreeViewRightSection_DivisionProducts.Cursor = System.Windows.Forms.Cursors.Default
            Me.RadTreeViewRightSection_DivisionProducts.Font = New System.Drawing.Font("Segoe UI", 8.25!)
            Me.RadTreeViewRightSection_DivisionProducts.ForeColor = System.Drawing.Color.Black
            Me.RadTreeViewRightSection_DivisionProducts.HideSelection = False
            Me.RadTreeViewRightSection_DivisionProducts.Location = New System.Drawing.Point(6, 6)
            Me.RadTreeViewRightSection_DivisionProducts.Name = "RadTreeViewRightSection_DivisionProducts"
            Me.RadTreeViewRightSection_DivisionProducts.RightToLeft = System.Windows.Forms.RightToLeft.No
            '
            '
            '
            Me.RadTreeViewRightSection_DivisionProducts.RootElement.AccessibleDescription = Nothing
            Me.RadTreeViewRightSection_DivisionProducts.RootElement.AccessibleName = Nothing
            Me.RadTreeViewRightSection_DivisionProducts.RootElement.ControlBounds = New System.Drawing.Rectangle(6, 6, 150, 250)
            Me.RadTreeViewRightSection_DivisionProducts.Size = New System.Drawing.Size(305, 510)
            Me.RadTreeViewRightSection_DivisionProducts.SpacingBetweenNodes = -1
            Me.RadTreeViewRightSection_DivisionProducts.TabIndex = 0
            Me.RadTreeViewRightSection_DivisionProducts.Text = "RadTreeView1"
            '
            'TabItemDocumentsSetup_Labels
            '
            Me.TabItemDocumentsSetup_Labels.AttachedControl = Me.TabControlPanelSystemAndAlertOptionsTab_SystemAndAlertOptions
            Me.TabItemDocumentsSetup_Labels.Name = "TabItemDocumentsSetup_Labels"
            Me.TabItemDocumentsSetup_Labels.Text = "Labels"
            '
            'TabControlPanelInformationTab_Information
            '
            Me.TabControlPanelInformationTab_Information.Controls.Add(Me.DataGridViewForm_Types)
            Me.TabControlPanelInformationTab_Information.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelInformationTab_Information.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelInformationTab_Information.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelInformationTab_Information.Name = "TabControlPanelInformationTab_Information"
            Me.TabControlPanelInformationTab_Information.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelInformationTab_Information.Size = New System.Drawing.Size(1021, 546)
            Me.TabControlPanelInformationTab_Information.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelInformationTab_Information.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelInformationTab_Information.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelInformationTab_Information.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelInformationTab_Information.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelInformationTab_Information.Style.GradientAngle = 90
            Me.TabControlPanelInformationTab_Information.TabIndex = 1
            Me.TabControlPanelInformationTab_Information.TabItem = Me.TabItemDocumentsSetup_Types
            '
            'DataGridViewForm_Types
            '
            Me.DataGridViewForm_Types.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_Types.AllowDragAndDrop = False
            Me.DataGridViewForm_Types.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_Types.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_Types.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_Types.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_Types.AutoFilterLookupColumns = False
            Me.DataGridViewForm_Types.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_Types.AutoUpdateViewCaption = True
            Me.DataGridViewForm_Types.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_Types.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_Types.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_Types.ItemDescription = "Type(s)"
            Me.DataGridViewForm_Types.Location = New System.Drawing.Point(7, 7)
            Me.DataGridViewForm_Types.MultiSelect = True
            Me.DataGridViewForm_Types.Name = "DataGridViewForm_Types"
            Me.DataGridViewForm_Types.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewForm_Types.RunStandardValidation = True
            Me.DataGridViewForm_Types.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_Types.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_Types.Size = New System.Drawing.Size(1006, 536)
            Me.DataGridViewForm_Types.TabIndex = 5
            Me.DataGridViewForm_Types.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Types.ViewCaptionHeight = -1
            '
            'TabItemDocumentsSetup_Types
            '
            Me.TabItemDocumentsSetup_Types.AttachedControl = Me.TabControlPanelInformationTab_Information
            Me.TabItemDocumentsSetup_Types.Name = "TabItemDocumentsSetup_Types"
            Me.TabItemDocumentsSetup_Types.Text = "Types"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Export, Me.ButtonItemActions_Add, Me.ButtonItemActions_Save, Me.ButtonItemActions_Delete, Me.ButtonItemActions_Cancel})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(197, 98)
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
            'ButtonItemActions_Export
            '
            Me.ButtonItemActions_Export.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Export.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Export.Name = "ButtonItemActions_Export"
            Me.ButtonItemActions_Export.RibbonWordWrap = False
            Me.ButtonItemActions_Export.Stretch = True
            Me.ButtonItemActions_Export.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Export.Text = "Export"
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
            Me.ButtonItemActions_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Save.Name = "ButtonItemActions_Save"
            Me.ButtonItemActions_Save.RibbonWordWrap = False
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
            'ButtonItemActions_Cancel
            '
            Me.ButtonItemActions_Cancel.BeginGroup = True
            Me.ButtonItemActions_Cancel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Cancel.Enabled = False
            Me.ButtonItemActions_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Cancel.Name = "ButtonItemActions_Cancel"
            Me.ButtonItemActions_Cancel.RibbonWordWrap = False
            Me.ButtonItemActions_Cancel.Stretch = True
            Me.ButtonItemActions_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Cancel.Text = "Cancel"
            Me.ButtonItemActions_Cancel.Tooltip = "Cancel adding new row"
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(560, 362)
            Me.RibbonBarMergeContainerForm_Options.MergeRibbonGroupName = "RibbonTabGroupDynamicReport"
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(400, 98)
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
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 23
            Me.RibbonBarMergeContainerForm_Options.Visible = False
            '
            'DocumentsSetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1045, 597)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.TabControlForm_AgencySetup)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "DocumentsSetupForm"
            Me.Text = "Documents Maintenance"
            CType(Me.TabControlForm_AgencySetup, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_AgencySetup.ResumeLayout(False)
            Me.TabControlPanelSystemAndAlertOptionsTab_SystemAndAlertOptions.ResumeLayout(False)
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_RightSection.ResumeLayout(False)
            CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_LeftSection.ResumeLayout(False)
            CType(Me.RadTreeViewRightSection_DivisionProducts, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelInformationTab_Information.ResumeLayout(False)
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents TabControlForm_AgencySetup As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelSystemAndAlertOptionsTab_SystemAndAlertOptions As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemDocumentsSetup_Labels As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelInformationTab_Information As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemDocumentsSetup_Types As DevComponents.DotNetBar.TabItem
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Save As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents DataGridViewForm_Types As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonItemActions_Delete As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Add As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents PanelForm_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelForm_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Private WithEvents RadTreeViewRightSection_DivisionProducts As Telerik.WinControls.UI.RadTreeView
        Friend WithEvents TextBoxLabelInformation_Description As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxLabelInformation_Name As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelContactInformation_Title As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelContactInformation_LastName As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelContactInformation_FirstName As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxOptions_ShowInactive As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents ExpandableSplitterControlForm_LeftRight As WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents ButtonItemActions_Cancel As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Export As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents CheckBoxOptions_LabelInactive As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents DevCompColor As DevComponents.DotNetBar.ColorPickerButton
        Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
    End Class

End Namespace

