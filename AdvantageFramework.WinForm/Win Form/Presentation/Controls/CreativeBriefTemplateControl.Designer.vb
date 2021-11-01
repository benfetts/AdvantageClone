Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class CreativeBriefTemplateControl
        Inherits AdvantageFramework.WinForm.Presentation.Controls.BaseControls.BaseUserControl

        'UserControl overrides dispose to clean up the component list.
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CreativeBriefTemplateControl))
            Me.TabControlControl_CreativeBriefTemplateSetup = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelDetailTab_Detail = New DevComponents.DotNetBar.TabControlPanel()
            Me.ButtonDetail_DeleteLevel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonDetail_AddLevel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.TreeListControlDetail_Levels = New AdvantageFramework.WinForm.Presentation.Controls.TreeListControl()
            Me.TabItemCreativeBriefTemplateSetup_DetailTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelHeaderTab_Header = New DevComponents.DotNetBar.TabControlPanel()
            Me.TextBoxHeader_Name = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.CheckBoxHeader_Inactive = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TableLayoutPanelHeader_LevelTable = New System.Windows.Forms.TableLayoutPanel()
            Me.PanelLevelTable_Column4 = New System.Windows.Forms.Panel()
            Me.GroupBoxColumn4_DetailLevelStyle = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.NumericInputDetailLevelStyle_Size = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.CheckBoxDetailLevelStyle_Bullet = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelDetailLevelStyle_Size = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxDetailLevelStyle_Bold = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxDetailLevelStyle_Underline = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxDetailLevelStyle_Italic = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.PanelLevelTable_Column3 = New System.Windows.Forms.Panel()
            Me.GroupBoxColumn3_LevelThreeStyle = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.NumericInputLevelThreeStyle_Size = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.CheckBoxLevelThreeStyle_Bullet = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelLevelThreeStyle_Size = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxLevelThreeStyle_Bold = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxLevelThreeStyle_Underline = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxLevelThreeStyle_Italic = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.PanelLevelTable_Column2 = New System.Windows.Forms.Panel()
            Me.GroupBoxColumn2_LevelTwoStyle = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.NumericInputLevelTwoStyle_Size = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.CheckBoxLevelTwoStyle_Bullet = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelLevelTwoStyle_Size = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxLevelTwoStyle_Bold = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxLevelTwoStyle_Underline = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxLevelTwoStyle_Italic = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.PanelLevelTable_Column1 = New System.Windows.Forms.Panel()
            Me.GroupBoxColumn1_LevelOneStyle = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.NumericInputLevelOneStyle_Size = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.CheckBoxLevelOneStyle_Bullet = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelLevelOneStyle_Size = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxLevelOneStyle_Bold = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxLevelOneStyle_Underline = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxLevelOneStyle_Italic = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.GroupBoxHeader_Options = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.TableLayoutPanelOptions_OptionsTable2 = New System.Windows.Forms.TableLayoutPanel()
            Me.PanelOptionsTable2_Column3 = New System.Windows.Forms.Panel()
            Me.CheckBoxColumn3_OpenedBy = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxColumn3_DueDate = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxColumn3_DepartmentTeam = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.PanelOptionsTable2_Column2 = New System.Windows.Forms.Panel()
            Me.CheckBoxColumn2_RushChargesApproved = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxColumn2_ApprovedEstimateRequired = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxColumn2_Budget = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.PanelOptionsTable2_Column1 = New System.Windows.Forms.Panel()
            Me.CheckBoxColumn1_Campaign = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxColumn1_DateOpened = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TableLayoutPanelOptions_OptionsTable = New System.Windows.Forms.TableLayoutPanel()
            Me.PanelOptionsTable_Column4 = New System.Windows.Forms.Panel()
            Me.CheckBoxColumn4_ClientReference = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxColumn4_ComponentDescription = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxColumn4_JobDescription = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.PanelOptionsTable_Column3 = New System.Windows.Forms.Panel()
            Me.CheckBoxColumn3_AccountExecutive = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxColumn3_ComponentNumber = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxColumn3_JobNumber = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.PanelOptionsTable_Column2 = New System.Windows.Forms.Panel()
            Me.CheckBoxColumn2_ProductAddress = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxColumn2_DivisionAddress = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxColumn2_ClientAddress = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.PanelOptionsTable_Column1 = New System.Windows.Forms.Panel()
            Me.CheckBoxColumn1_Product = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxColumn1_Division = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxColumn1_Client = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelHeader_Name = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxHeader_Code = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelHeader_Code = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemCreativeBriefTemplateSetup_HeaderTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.PanelForm_TopPanel = New System.Windows.Forms.Panel()
            Me.LabelTopPanel_Warning = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.PanelForm_MainPanel = New System.Windows.Forms.Panel()
            CType(Me.TabControlControl_CreativeBriefTemplateSetup, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlControl_CreativeBriefTemplateSetup.SuspendLayout()
            Me.TabControlPanelDetailTab_Detail.SuspendLayout()
            CType(Me.TreeListControlDetail_Levels, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelHeaderTab_Header.SuspendLayout()
            Me.TableLayoutPanelHeader_LevelTable.SuspendLayout()
            Me.PanelLevelTable_Column4.SuspendLayout()
            CType(Me.GroupBoxColumn4_DetailLevelStyle, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxColumn4_DetailLevelStyle.SuspendLayout()
            CType(Me.NumericInputDetailLevelStyle_Size.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelLevelTable_Column3.SuspendLayout()
            CType(Me.GroupBoxColumn3_LevelThreeStyle, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxColumn3_LevelThreeStyle.SuspendLayout()
            CType(Me.NumericInputLevelThreeStyle_Size.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelLevelTable_Column2.SuspendLayout()
            CType(Me.GroupBoxColumn2_LevelTwoStyle, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxColumn2_LevelTwoStyle.SuspendLayout()
            CType(Me.NumericInputLevelTwoStyle_Size.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelLevelTable_Column1.SuspendLayout()
            CType(Me.GroupBoxColumn1_LevelOneStyle, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxColumn1_LevelOneStyle.SuspendLayout()
            CType(Me.NumericInputLevelOneStyle_Size.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxHeader_Options, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxHeader_Options.SuspendLayout()
            Me.TableLayoutPanelOptions_OptionsTable2.SuspendLayout()
            Me.PanelOptionsTable2_Column3.SuspendLayout()
            Me.PanelOptionsTable2_Column2.SuspendLayout()
            Me.PanelOptionsTable2_Column1.SuspendLayout()
            Me.TableLayoutPanelOptions_OptionsTable.SuspendLayout()
            Me.PanelOptionsTable_Column4.SuspendLayout()
            Me.PanelOptionsTable_Column3.SuspendLayout()
            Me.PanelOptionsTable_Column2.SuspendLayout()
            Me.PanelOptionsTable_Column1.SuspendLayout()
            Me.PanelForm_TopPanel.SuspendLayout()
            Me.PanelForm_MainPanel.SuspendLayout()
            Me.SuspendLayout()
            '
            'TabControlControl_CreativeBriefTemplateSetup
            '
            Me.TabControlControl_CreativeBriefTemplateSetup.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.TabControlControl_CreativeBriefTemplateSetup.CanReorderTabs = False
            Me.TabControlControl_CreativeBriefTemplateSetup.Controls.Add(Me.TabControlPanelHeaderTab_Header)
            Me.TabControlControl_CreativeBriefTemplateSetup.Controls.Add(Me.TabControlPanelDetailTab_Detail)
            Me.TabControlControl_CreativeBriefTemplateSetup.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlControl_CreativeBriefTemplateSetup.Location = New System.Drawing.Point(0, 0)
            Me.TabControlControl_CreativeBriefTemplateSetup.Name = "TabControlControl_CreativeBriefTemplateSetup"
            Me.TabControlControl_CreativeBriefTemplateSetup.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlControl_CreativeBriefTemplateSetup.SelectedTabIndex = 0
            Me.TabControlControl_CreativeBriefTemplateSetup.Size = New System.Drawing.Size(602, 407)
            Me.TabControlControl_CreativeBriefTemplateSetup.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlControl_CreativeBriefTemplateSetup.TabIndex = 31
            Me.TabControlControl_CreativeBriefTemplateSetup.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlControl_CreativeBriefTemplateSetup.Tabs.Add(Me.TabItemCreativeBriefTemplateSetup_HeaderTab)
            Me.TabControlControl_CreativeBriefTemplateSetup.Tabs.Add(Me.TabItemCreativeBriefTemplateSetup_DetailTab)
            Me.TabControlControl_CreativeBriefTemplateSetup.Text = "TabControl1"
            '
            'TabControlPanelDetailTab_Detail
            '
            Me.TabControlPanelDetailTab_Detail.Controls.Add(Me.ButtonDetail_DeleteLevel)
            Me.TabControlPanelDetailTab_Detail.Controls.Add(Me.ButtonDetail_AddLevel)
            Me.TabControlPanelDetailTab_Detail.Controls.Add(Me.TreeListControlDetail_Levels)
            Me.TabControlPanelDetailTab_Detail.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelDetailTab_Detail.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelDetailTab_Detail.Name = "TabControlPanelDetailTab_Detail"
            Me.TabControlPanelDetailTab_Detail.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelDetailTab_Detail.Size = New System.Drawing.Size(602, 380)
            Me.TabControlPanelDetailTab_Detail.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDetailTab_Detail.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDetailTab_Detail.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelDetailTab_Detail.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelDetailTab_Detail.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelDetailTab_Detail.Style.GradientAngle = 90
            Me.TabControlPanelDetailTab_Detail.TabIndex = 1
            Me.TabControlPanelDetailTab_Detail.TabItem = Me.TabItemCreativeBriefTemplateSetup_DetailTab
            '
            'ButtonDetail_DeleteLevel
            '
            Me.ButtonDetail_DeleteLevel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonDetail_DeleteLevel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ButtonDetail_DeleteLevel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonDetail_DeleteLevel.Location = New System.Drawing.Point(85, 356)
            Me.ButtonDetail_DeleteLevel.Name = "ButtonDetail_DeleteLevel"
            Me.ButtonDetail_DeleteLevel.SecurityEnabled = True
            Me.ButtonDetail_DeleteLevel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonDetail_DeleteLevel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonDetail_DeleteLevel.TabIndex = 3
            Me.ButtonDetail_DeleteLevel.Text = "Delete Level"
            '
            'ButtonDetail_AddLevel
            '
            Me.ButtonDetail_AddLevel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonDetail_AddLevel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ButtonDetail_AddLevel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonDetail_AddLevel.Location = New System.Drawing.Point(4, 356)
            Me.ButtonDetail_AddLevel.Name = "ButtonDetail_AddLevel"
            Me.ButtonDetail_AddLevel.SecurityEnabled = True
            Me.ButtonDetail_AddLevel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonDetail_AddLevel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonDetail_AddLevel.TabIndex = 2
            Me.ButtonDetail_AddLevel.Text = "Add Level"
            '
            'TreeListControlDetail_Levels
            '
            Me.TreeListControlDetail_Levels.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TreeListControlDetail_Levels.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TreeListControl.Type.Editable
            Me.TreeListControlDetail_Levels.Location = New System.Drawing.Point(4, 4)
            Me.TreeListControlDetail_Levels.Name = "TreeListControlDetail_Levels"
            Me.TreeListControlDetail_Levels.Size = New System.Drawing.Size(594, 346)
            Me.TreeListControlDetail_Levels.TabIndex = 1
            '
            'TabItemCreativeBriefTemplateSetup_DetailTab
            '
            Me.TabItemCreativeBriefTemplateSetup_DetailTab.AttachedControl = Me.TabControlPanelDetailTab_Detail
            Me.TabItemCreativeBriefTemplateSetup_DetailTab.Name = "TabItemCreativeBriefTemplateSetup_DetailTab"
            Me.TabItemCreativeBriefTemplateSetup_DetailTab.Text = "Detail"
            '
            'TabControlPanelHeaderTab_Header
            '
            Me.TabControlPanelHeaderTab_Header.Controls.Add(Me.TextBoxHeader_Name)
            Me.TabControlPanelHeaderTab_Header.Controls.Add(Me.CheckBoxHeader_Inactive)
            Me.TabControlPanelHeaderTab_Header.Controls.Add(Me.TableLayoutPanelHeader_LevelTable)
            Me.TabControlPanelHeaderTab_Header.Controls.Add(Me.GroupBoxHeader_Options)
            Me.TabControlPanelHeaderTab_Header.Controls.Add(Me.LabelHeader_Name)
            Me.TabControlPanelHeaderTab_Header.Controls.Add(Me.TextBoxHeader_Code)
            Me.TabControlPanelHeaderTab_Header.Controls.Add(Me.LabelHeader_Code)
            Me.TabControlPanelHeaderTab_Header.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelHeaderTab_Header.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelHeaderTab_Header.Name = "TabControlPanelHeaderTab_Header"
            Me.TabControlPanelHeaderTab_Header.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelHeaderTab_Header.Size = New System.Drawing.Size(602, 380)
            Me.TabControlPanelHeaderTab_Header.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelHeaderTab_Header.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelHeaderTab_Header.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelHeaderTab_Header.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelHeaderTab_Header.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelHeaderTab_Header.Style.GradientAngle = 90
            Me.TabControlPanelHeaderTab_Header.TabIndex = 2
            Me.TabControlPanelHeaderTab_Header.TabItem = Me.TabItemCreativeBriefTemplateSetup_HeaderTab
            '
            'TextBoxHeader_Name
            '
            Me.TextBoxHeader_Name.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxHeader_Name.Border.Class = "TextBoxBorder"
            Me.TextBoxHeader_Name.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxHeader_Name.CheckSpellingOnValidate = False
            Me.TextBoxHeader_Name.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxHeader_Name.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxHeader_Name.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxHeader_Name.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxHeader_Name.FocusHighlightEnabled = True
            Me.TextBoxHeader_Name.Location = New System.Drawing.Point(176, 4)
            Me.TextBoxHeader_Name.MaxFileSize = CType(0, Long)
            Me.TextBoxHeader_Name.Name = "TextBoxHeader_Name"
            Me.TextBoxHeader_Name.Size = New System.Drawing.Size(343, 20)
            Me.TextBoxHeader_Name.TabIndex = 3
            Me.TextBoxHeader_Name.TabOnEnter = True
            '
            'CheckBoxHeader_Inactive
            '
            Me.CheckBoxHeader_Inactive.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxHeader_Inactive.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxHeader_Inactive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxHeader_Inactive.CheckValue = 0
            Me.CheckBoxHeader_Inactive.CheckValueChecked = 1
            Me.CheckBoxHeader_Inactive.CheckValueUnchecked = 0
            Me.CheckBoxHeader_Inactive.ChildControls = CType(resources.GetObject("CheckBoxHeader_Inactive.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxHeader_Inactive.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxHeader_Inactive.Location = New System.Drawing.Point(525, 4)
            Me.CheckBoxHeader_Inactive.Name = "CheckBoxHeader_Inactive"
            Me.CheckBoxHeader_Inactive.OldestSibling = Nothing
            Me.CheckBoxHeader_Inactive.SecurityEnabled = True
            Me.CheckBoxHeader_Inactive.SiblingControls = CType(resources.GetObject("CheckBoxHeader_Inactive.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxHeader_Inactive.Size = New System.Drawing.Size(73, 20)
            Me.CheckBoxHeader_Inactive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxHeader_Inactive.TabIndex = 4
            Me.CheckBoxHeader_Inactive.Text = "Inactive"
            '
            'TableLayoutPanelHeader_LevelTable
            '
            Me.TableLayoutPanelHeader_LevelTable.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TableLayoutPanelHeader_LevelTable.BackColor = System.Drawing.Color.White
            Me.TableLayoutPanelHeader_LevelTable.ColumnCount = 4
            Me.TableLayoutPanelHeader_LevelTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
            Me.TableLayoutPanelHeader_LevelTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
            Me.TableLayoutPanelHeader_LevelTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
            Me.TableLayoutPanelHeader_LevelTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
            Me.TableLayoutPanelHeader_LevelTable.Controls.Add(Me.PanelLevelTable_Column4, 3, 0)
            Me.TableLayoutPanelHeader_LevelTable.Controls.Add(Me.PanelLevelTable_Column3, 2, 0)
            Me.TableLayoutPanelHeader_LevelTable.Controls.Add(Me.PanelLevelTable_Column2, 1, 0)
            Me.TableLayoutPanelHeader_LevelTable.Controls.Add(Me.PanelLevelTable_Column1, 0, 0)
            Me.TableLayoutPanelHeader_LevelTable.Location = New System.Drawing.Point(4, 226)
            Me.TableLayoutPanelHeader_LevelTable.Name = "TableLayoutPanelHeader_LevelTable"
            Me.TableLayoutPanelHeader_LevelTable.RowCount = 1
            Me.TableLayoutPanelHeader_LevelTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanelHeader_LevelTable.Size = New System.Drawing.Size(594, 154)
            Me.TableLayoutPanelHeader_LevelTable.TabIndex = 6
            '
            'PanelLevelTable_Column4
            '
            Me.PanelLevelTable_Column4.Controls.Add(Me.GroupBoxColumn4_DetailLevelStyle)
            Me.PanelLevelTable_Column4.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelLevelTable_Column4.Location = New System.Drawing.Point(444, 0)
            Me.PanelLevelTable_Column4.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelLevelTable_Column4.Name = "PanelLevelTable_Column4"
            Me.PanelLevelTable_Column4.Size = New System.Drawing.Size(150, 154)
            Me.PanelLevelTable_Column4.TabIndex = 3
            '
            'GroupBoxColumn4_DetailLevelStyle
            '
            Me.GroupBoxColumn4_DetailLevelStyle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxColumn4_DetailLevelStyle.Controls.Add(Me.NumericInputDetailLevelStyle_Size)
            Me.GroupBoxColumn4_DetailLevelStyle.Controls.Add(Me.CheckBoxDetailLevelStyle_Bullet)
            Me.GroupBoxColumn4_DetailLevelStyle.Controls.Add(Me.LabelDetailLevelStyle_Size)
            Me.GroupBoxColumn4_DetailLevelStyle.Controls.Add(Me.CheckBoxDetailLevelStyle_Bold)
            Me.GroupBoxColumn4_DetailLevelStyle.Controls.Add(Me.CheckBoxDetailLevelStyle_Underline)
            Me.GroupBoxColumn4_DetailLevelStyle.Controls.Add(Me.CheckBoxDetailLevelStyle_Italic)
            Me.GroupBoxColumn4_DetailLevelStyle.Location = New System.Drawing.Point(6, 0)
            Me.GroupBoxColumn4_DetailLevelStyle.Name = "GroupBoxColumn4_DetailLevelStyle"
            Me.GroupBoxColumn4_DetailLevelStyle.Size = New System.Drawing.Size(144, 154)
            Me.GroupBoxColumn4_DetailLevelStyle.TabIndex = 0
            Me.GroupBoxColumn4_DetailLevelStyle.Text = "Detail Level Style"
            '
            'NumericInputDetailLevelStyle_Size
            '
            Me.NumericInputDetailLevelStyle_Size.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Short]
            Me.NumericInputDetailLevelStyle_Size.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDetailLevelStyle_Size.Location = New System.Drawing.Point(48, 128)
            Me.NumericInputDetailLevelStyle_Size.Name = "NumericInputDetailLevelStyle_Size"
            Me.NumericInputDetailLevelStyle_Size.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputDetailLevelStyle_Size.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputDetailLevelStyle_Size.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailLevelStyle_Size.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputDetailLevelStyle_Size.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailLevelStyle_Size.Properties.IsFloatValue = False
            Me.NumericInputDetailLevelStyle_Size.Properties.Mask.EditMask = "f0"
            Me.NumericInputDetailLevelStyle_Size.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDetailLevelStyle_Size.Properties.MaxLength = 6
            Me.NumericInputDetailLevelStyle_Size.Properties.MaxValue = New Decimal(New Integer() {32767, 0, 0, 0})
            Me.NumericInputDetailLevelStyle_Size.Properties.MinValue = New Decimal(New Integer() {32768, 0, 0, -2147483648})
            Me.NumericInputDetailLevelStyle_Size.Size = New System.Drawing.Size(91, 20)
            Me.NumericInputDetailLevelStyle_Size.TabIndex = 7
            '
            'CheckBoxDetailLevelStyle_Bullet
            '
            Me.CheckBoxDetailLevelStyle_Bullet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxDetailLevelStyle_Bullet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxDetailLevelStyle_Bullet.CheckValue = 0
            Me.CheckBoxDetailLevelStyle_Bullet.CheckValueChecked = 1
            Me.CheckBoxDetailLevelStyle_Bullet.CheckValueUnchecked = 0
            Me.CheckBoxDetailLevelStyle_Bullet.ChildControls = CType(resources.GetObject("CheckBoxDetailLevelStyle_Bullet.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxDetailLevelStyle_Bullet.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxDetailLevelStyle_Bullet.Location = New System.Drawing.Point(5, 76)
            Me.CheckBoxDetailLevelStyle_Bullet.Name = "CheckBoxDetailLevelStyle_Bullet"
            Me.CheckBoxDetailLevelStyle_Bullet.OldestSibling = Nothing
            Me.CheckBoxDetailLevelStyle_Bullet.SecurityEnabled = True
            Me.CheckBoxDetailLevelStyle_Bullet.SiblingControls = CType(resources.GetObject("CheckBoxDetailLevelStyle_Bullet.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxDetailLevelStyle_Bullet.Size = New System.Drawing.Size(134, 20)
            Me.CheckBoxDetailLevelStyle_Bullet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxDetailLevelStyle_Bullet.TabIndex = 2
            Me.CheckBoxDetailLevelStyle_Bullet.Text = "Bullet"
            '
            'LabelDetailLevelStyle_Size
            '
            Me.LabelDetailLevelStyle_Size.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDetailLevelStyle_Size.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDetailLevelStyle_Size.Location = New System.Drawing.Point(5, 128)
            Me.LabelDetailLevelStyle_Size.Name = "LabelDetailLevelStyle_Size"
            Me.LabelDetailLevelStyle_Size.Size = New System.Drawing.Size(37, 20)
            Me.LabelDetailLevelStyle_Size.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDetailLevelStyle_Size.TabIndex = 4
            Me.LabelDetailLevelStyle_Size.Text = "Size:"
            '
            'CheckBoxDetailLevelStyle_Bold
            '
            Me.CheckBoxDetailLevelStyle_Bold.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxDetailLevelStyle_Bold.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxDetailLevelStyle_Bold.CheckValue = 0
            Me.CheckBoxDetailLevelStyle_Bold.CheckValueChecked = 1
            Me.CheckBoxDetailLevelStyle_Bold.CheckValueUnchecked = 0
            Me.CheckBoxDetailLevelStyle_Bold.ChildControls = CType(resources.GetObject("CheckBoxDetailLevelStyle_Bold.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxDetailLevelStyle_Bold.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxDetailLevelStyle_Bold.Location = New System.Drawing.Point(5, 102)
            Me.CheckBoxDetailLevelStyle_Bold.Name = "CheckBoxDetailLevelStyle_Bold"
            Me.CheckBoxDetailLevelStyle_Bold.OldestSibling = Nothing
            Me.CheckBoxDetailLevelStyle_Bold.SecurityEnabled = True
            Me.CheckBoxDetailLevelStyle_Bold.SiblingControls = CType(resources.GetObject("CheckBoxDetailLevelStyle_Bold.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxDetailLevelStyle_Bold.Size = New System.Drawing.Size(134, 20)
            Me.CheckBoxDetailLevelStyle_Bold.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxDetailLevelStyle_Bold.TabIndex = 3
            Me.CheckBoxDetailLevelStyle_Bold.Text = "Bold"
            '
            'CheckBoxDetailLevelStyle_Underline
            '
            Me.CheckBoxDetailLevelStyle_Underline.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxDetailLevelStyle_Underline.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxDetailLevelStyle_Underline.CheckValue = 0
            Me.CheckBoxDetailLevelStyle_Underline.CheckValueChecked = 1
            Me.CheckBoxDetailLevelStyle_Underline.CheckValueUnchecked = 0
            Me.CheckBoxDetailLevelStyle_Underline.ChildControls = CType(resources.GetObject("CheckBoxDetailLevelStyle_Underline.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxDetailLevelStyle_Underline.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxDetailLevelStyle_Underline.Location = New System.Drawing.Point(5, 50)
            Me.CheckBoxDetailLevelStyle_Underline.Name = "CheckBoxDetailLevelStyle_Underline"
            Me.CheckBoxDetailLevelStyle_Underline.OldestSibling = Nothing
            Me.CheckBoxDetailLevelStyle_Underline.SecurityEnabled = True
            Me.CheckBoxDetailLevelStyle_Underline.SiblingControls = CType(resources.GetObject("CheckBoxDetailLevelStyle_Underline.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxDetailLevelStyle_Underline.Size = New System.Drawing.Size(134, 20)
            Me.CheckBoxDetailLevelStyle_Underline.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxDetailLevelStyle_Underline.TabIndex = 1
            Me.CheckBoxDetailLevelStyle_Underline.Text = "Underline"
            '
            'CheckBoxDetailLevelStyle_Italic
            '
            Me.CheckBoxDetailLevelStyle_Italic.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxDetailLevelStyle_Italic.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxDetailLevelStyle_Italic.CheckValue = 0
            Me.CheckBoxDetailLevelStyle_Italic.CheckValueChecked = 1
            Me.CheckBoxDetailLevelStyle_Italic.CheckValueUnchecked = 0
            Me.CheckBoxDetailLevelStyle_Italic.ChildControls = CType(resources.GetObject("CheckBoxDetailLevelStyle_Italic.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxDetailLevelStyle_Italic.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxDetailLevelStyle_Italic.Location = New System.Drawing.Point(5, 24)
            Me.CheckBoxDetailLevelStyle_Italic.Name = "CheckBoxDetailLevelStyle_Italic"
            Me.CheckBoxDetailLevelStyle_Italic.OldestSibling = Nothing
            Me.CheckBoxDetailLevelStyle_Italic.SecurityEnabled = True
            Me.CheckBoxDetailLevelStyle_Italic.SiblingControls = CType(resources.GetObject("CheckBoxDetailLevelStyle_Italic.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxDetailLevelStyle_Italic.Size = New System.Drawing.Size(134, 20)
            Me.CheckBoxDetailLevelStyle_Italic.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxDetailLevelStyle_Italic.TabIndex = 0
            Me.CheckBoxDetailLevelStyle_Italic.Text = "Italic"
            '
            'PanelLevelTable_Column3
            '
            Me.PanelLevelTable_Column3.Controls.Add(Me.GroupBoxColumn3_LevelThreeStyle)
            Me.PanelLevelTable_Column3.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelLevelTable_Column3.Location = New System.Drawing.Point(296, 0)
            Me.PanelLevelTable_Column3.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelLevelTable_Column3.Name = "PanelLevelTable_Column3"
            Me.PanelLevelTable_Column3.Size = New System.Drawing.Size(148, 154)
            Me.PanelLevelTable_Column3.TabIndex = 2
            '
            'GroupBoxColumn3_LevelThreeStyle
            '
            Me.GroupBoxColumn3_LevelThreeStyle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxColumn3_LevelThreeStyle.Controls.Add(Me.NumericInputLevelThreeStyle_Size)
            Me.GroupBoxColumn3_LevelThreeStyle.Controls.Add(Me.CheckBoxLevelThreeStyle_Bullet)
            Me.GroupBoxColumn3_LevelThreeStyle.Controls.Add(Me.LabelLevelThreeStyle_Size)
            Me.GroupBoxColumn3_LevelThreeStyle.Controls.Add(Me.CheckBoxLevelThreeStyle_Bold)
            Me.GroupBoxColumn3_LevelThreeStyle.Controls.Add(Me.CheckBoxLevelThreeStyle_Underline)
            Me.GroupBoxColumn3_LevelThreeStyle.Controls.Add(Me.CheckBoxLevelThreeStyle_Italic)
            Me.GroupBoxColumn3_LevelThreeStyle.Location = New System.Drawing.Point(4, 0)
            Me.GroupBoxColumn3_LevelThreeStyle.Name = "GroupBoxColumn3_LevelThreeStyle"
            Me.GroupBoxColumn3_LevelThreeStyle.Size = New System.Drawing.Size(144, 154)
            Me.GroupBoxColumn3_LevelThreeStyle.TabIndex = 0
            Me.GroupBoxColumn3_LevelThreeStyle.Text = "Level Three Style"
            '
            'NumericInputLevelThreeStyle_Size
            '
            Me.NumericInputLevelThreeStyle_Size.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Short]
            Me.NumericInputLevelThreeStyle_Size.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputLevelThreeStyle_Size.Location = New System.Drawing.Point(48, 128)
            Me.NumericInputLevelThreeStyle_Size.Name = "NumericInputLevelThreeStyle_Size"
            Me.NumericInputLevelThreeStyle_Size.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputLevelThreeStyle_Size.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputLevelThreeStyle_Size.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputLevelThreeStyle_Size.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputLevelThreeStyle_Size.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputLevelThreeStyle_Size.Properties.IsFloatValue = False
            Me.NumericInputLevelThreeStyle_Size.Properties.Mask.EditMask = "f0"
            Me.NumericInputLevelThreeStyle_Size.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputLevelThreeStyle_Size.Properties.MaxLength = 6
            Me.NumericInputLevelThreeStyle_Size.Properties.MaxValue = New Decimal(New Integer() {32767, 0, 0, 0})
            Me.NumericInputLevelThreeStyle_Size.Properties.MinValue = New Decimal(New Integer() {32768, 0, 0, -2147483648})
            Me.NumericInputLevelThreeStyle_Size.Size = New System.Drawing.Size(91, 20)
            Me.NumericInputLevelThreeStyle_Size.TabIndex = 7
            '
            'CheckBoxLevelThreeStyle_Bullet
            '
            Me.CheckBoxLevelThreeStyle_Bullet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxLevelThreeStyle_Bullet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxLevelThreeStyle_Bullet.CheckValue = 0
            Me.CheckBoxLevelThreeStyle_Bullet.CheckValueChecked = 1
            Me.CheckBoxLevelThreeStyle_Bullet.CheckValueUnchecked = 0
            Me.CheckBoxLevelThreeStyle_Bullet.ChildControls = CType(resources.GetObject("CheckBoxLevelThreeStyle_Bullet.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLevelThreeStyle_Bullet.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxLevelThreeStyle_Bullet.Location = New System.Drawing.Point(5, 76)
            Me.CheckBoxLevelThreeStyle_Bullet.Name = "CheckBoxLevelThreeStyle_Bullet"
            Me.CheckBoxLevelThreeStyle_Bullet.OldestSibling = Nothing
            Me.CheckBoxLevelThreeStyle_Bullet.SecurityEnabled = True
            Me.CheckBoxLevelThreeStyle_Bullet.SiblingControls = CType(resources.GetObject("CheckBoxLevelThreeStyle_Bullet.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLevelThreeStyle_Bullet.Size = New System.Drawing.Size(134, 20)
            Me.CheckBoxLevelThreeStyle_Bullet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxLevelThreeStyle_Bullet.TabIndex = 2
            Me.CheckBoxLevelThreeStyle_Bullet.Text = "Bullet"
            '
            'LabelLevelThreeStyle_Size
            '
            Me.LabelLevelThreeStyle_Size.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelLevelThreeStyle_Size.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelLevelThreeStyle_Size.Location = New System.Drawing.Point(5, 128)
            Me.LabelLevelThreeStyle_Size.Name = "LabelLevelThreeStyle_Size"
            Me.LabelLevelThreeStyle_Size.Size = New System.Drawing.Size(37, 20)
            Me.LabelLevelThreeStyle_Size.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelLevelThreeStyle_Size.TabIndex = 4
            Me.LabelLevelThreeStyle_Size.Text = "Size:"
            '
            'CheckBoxLevelThreeStyle_Bold
            '
            Me.CheckBoxLevelThreeStyle_Bold.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxLevelThreeStyle_Bold.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxLevelThreeStyle_Bold.CheckValue = 0
            Me.CheckBoxLevelThreeStyle_Bold.CheckValueChecked = 1
            Me.CheckBoxLevelThreeStyle_Bold.CheckValueUnchecked = 0
            Me.CheckBoxLevelThreeStyle_Bold.ChildControls = CType(resources.GetObject("CheckBoxLevelThreeStyle_Bold.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLevelThreeStyle_Bold.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxLevelThreeStyle_Bold.Location = New System.Drawing.Point(5, 102)
            Me.CheckBoxLevelThreeStyle_Bold.Name = "CheckBoxLevelThreeStyle_Bold"
            Me.CheckBoxLevelThreeStyle_Bold.OldestSibling = Nothing
            Me.CheckBoxLevelThreeStyle_Bold.SecurityEnabled = True
            Me.CheckBoxLevelThreeStyle_Bold.SiblingControls = CType(resources.GetObject("CheckBoxLevelThreeStyle_Bold.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLevelThreeStyle_Bold.Size = New System.Drawing.Size(134, 20)
            Me.CheckBoxLevelThreeStyle_Bold.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxLevelThreeStyle_Bold.TabIndex = 3
            Me.CheckBoxLevelThreeStyle_Bold.Text = "Bold"
            '
            'CheckBoxLevelThreeStyle_Underline
            '
            Me.CheckBoxLevelThreeStyle_Underline.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxLevelThreeStyle_Underline.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxLevelThreeStyle_Underline.CheckValue = 0
            Me.CheckBoxLevelThreeStyle_Underline.CheckValueChecked = 1
            Me.CheckBoxLevelThreeStyle_Underline.CheckValueUnchecked = 0
            Me.CheckBoxLevelThreeStyle_Underline.ChildControls = CType(resources.GetObject("CheckBoxLevelThreeStyle_Underline.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLevelThreeStyle_Underline.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxLevelThreeStyle_Underline.Location = New System.Drawing.Point(5, 50)
            Me.CheckBoxLevelThreeStyle_Underline.Name = "CheckBoxLevelThreeStyle_Underline"
            Me.CheckBoxLevelThreeStyle_Underline.OldestSibling = Nothing
            Me.CheckBoxLevelThreeStyle_Underline.SecurityEnabled = True
            Me.CheckBoxLevelThreeStyle_Underline.SiblingControls = CType(resources.GetObject("CheckBoxLevelThreeStyle_Underline.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLevelThreeStyle_Underline.Size = New System.Drawing.Size(134, 20)
            Me.CheckBoxLevelThreeStyle_Underline.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxLevelThreeStyle_Underline.TabIndex = 1
            Me.CheckBoxLevelThreeStyle_Underline.Text = "Underline"
            '
            'CheckBoxLevelThreeStyle_Italic
            '
            Me.CheckBoxLevelThreeStyle_Italic.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxLevelThreeStyle_Italic.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxLevelThreeStyle_Italic.CheckValue = 0
            Me.CheckBoxLevelThreeStyle_Italic.CheckValueChecked = 1
            Me.CheckBoxLevelThreeStyle_Italic.CheckValueUnchecked = 0
            Me.CheckBoxLevelThreeStyle_Italic.ChildControls = CType(resources.GetObject("CheckBoxLevelThreeStyle_Italic.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLevelThreeStyle_Italic.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxLevelThreeStyle_Italic.Location = New System.Drawing.Point(5, 24)
            Me.CheckBoxLevelThreeStyle_Italic.Name = "CheckBoxLevelThreeStyle_Italic"
            Me.CheckBoxLevelThreeStyle_Italic.OldestSibling = Nothing
            Me.CheckBoxLevelThreeStyle_Italic.SecurityEnabled = True
            Me.CheckBoxLevelThreeStyle_Italic.SiblingControls = CType(resources.GetObject("CheckBoxLevelThreeStyle_Italic.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLevelThreeStyle_Italic.Size = New System.Drawing.Size(134, 20)
            Me.CheckBoxLevelThreeStyle_Italic.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxLevelThreeStyle_Italic.TabIndex = 0
            Me.CheckBoxLevelThreeStyle_Italic.Text = "Italic"
            '
            'PanelLevelTable_Column2
            '
            Me.PanelLevelTable_Column2.Controls.Add(Me.GroupBoxColumn2_LevelTwoStyle)
            Me.PanelLevelTable_Column2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelLevelTable_Column2.Location = New System.Drawing.Point(148, 0)
            Me.PanelLevelTable_Column2.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelLevelTable_Column2.Name = "PanelLevelTable_Column2"
            Me.PanelLevelTable_Column2.Size = New System.Drawing.Size(148, 154)
            Me.PanelLevelTable_Column2.TabIndex = 1
            '
            'GroupBoxColumn2_LevelTwoStyle
            '
            Me.GroupBoxColumn2_LevelTwoStyle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxColumn2_LevelTwoStyle.Controls.Add(Me.NumericInputLevelTwoStyle_Size)
            Me.GroupBoxColumn2_LevelTwoStyle.Controls.Add(Me.CheckBoxLevelTwoStyle_Bullet)
            Me.GroupBoxColumn2_LevelTwoStyle.Controls.Add(Me.LabelLevelTwoStyle_Size)
            Me.GroupBoxColumn2_LevelTwoStyle.Controls.Add(Me.CheckBoxLevelTwoStyle_Bold)
            Me.GroupBoxColumn2_LevelTwoStyle.Controls.Add(Me.CheckBoxLevelTwoStyle_Underline)
            Me.GroupBoxColumn2_LevelTwoStyle.Controls.Add(Me.CheckBoxLevelTwoStyle_Italic)
            Me.GroupBoxColumn2_LevelTwoStyle.Location = New System.Drawing.Point(2, 0)
            Me.GroupBoxColumn2_LevelTwoStyle.Name = "GroupBoxColumn2_LevelTwoStyle"
            Me.GroupBoxColumn2_LevelTwoStyle.Size = New System.Drawing.Size(144, 154)
            Me.GroupBoxColumn2_LevelTwoStyle.TabIndex = 0
            Me.GroupBoxColumn2_LevelTwoStyle.Text = "Level Two Style"
            '
            'NumericInputLevelTwoStyle_Size
            '
            Me.NumericInputLevelTwoStyle_Size.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Short]
            Me.NumericInputLevelTwoStyle_Size.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputLevelTwoStyle_Size.Location = New System.Drawing.Point(48, 128)
            Me.NumericInputLevelTwoStyle_Size.Name = "NumericInputLevelTwoStyle_Size"
            Me.NumericInputLevelTwoStyle_Size.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputLevelTwoStyle_Size.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputLevelTwoStyle_Size.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputLevelTwoStyle_Size.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputLevelTwoStyle_Size.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputLevelTwoStyle_Size.Properties.IsFloatValue = False
            Me.NumericInputLevelTwoStyle_Size.Properties.Mask.EditMask = "f0"
            Me.NumericInputLevelTwoStyle_Size.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputLevelTwoStyle_Size.Properties.MaxLength = 6
            Me.NumericInputLevelTwoStyle_Size.Properties.MaxValue = New Decimal(New Integer() {32767, 0, 0, 0})
            Me.NumericInputLevelTwoStyle_Size.Properties.MinValue = New Decimal(New Integer() {32768, 0, 0, -2147483648})
            Me.NumericInputLevelTwoStyle_Size.Size = New System.Drawing.Size(91, 20)
            Me.NumericInputLevelTwoStyle_Size.TabIndex = 7
            '
            'CheckBoxLevelTwoStyle_Bullet
            '
            Me.CheckBoxLevelTwoStyle_Bullet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxLevelTwoStyle_Bullet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxLevelTwoStyle_Bullet.CheckValue = 0
            Me.CheckBoxLevelTwoStyle_Bullet.CheckValueChecked = 1
            Me.CheckBoxLevelTwoStyle_Bullet.CheckValueUnchecked = 0
            Me.CheckBoxLevelTwoStyle_Bullet.ChildControls = CType(resources.GetObject("CheckBoxLevelTwoStyle_Bullet.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLevelTwoStyle_Bullet.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxLevelTwoStyle_Bullet.Location = New System.Drawing.Point(4, 76)
            Me.CheckBoxLevelTwoStyle_Bullet.Name = "CheckBoxLevelTwoStyle_Bullet"
            Me.CheckBoxLevelTwoStyle_Bullet.OldestSibling = Nothing
            Me.CheckBoxLevelTwoStyle_Bullet.SecurityEnabled = True
            Me.CheckBoxLevelTwoStyle_Bullet.SiblingControls = CType(resources.GetObject("CheckBoxLevelTwoStyle_Bullet.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLevelTwoStyle_Bullet.Size = New System.Drawing.Size(134, 20)
            Me.CheckBoxLevelTwoStyle_Bullet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxLevelTwoStyle_Bullet.TabIndex = 2
            Me.CheckBoxLevelTwoStyle_Bullet.Text = "Bullet"
            '
            'LabelLevelTwoStyle_Size
            '
            Me.LabelLevelTwoStyle_Size.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelLevelTwoStyle_Size.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelLevelTwoStyle_Size.Location = New System.Drawing.Point(5, 128)
            Me.LabelLevelTwoStyle_Size.Name = "LabelLevelTwoStyle_Size"
            Me.LabelLevelTwoStyle_Size.Size = New System.Drawing.Size(37, 20)
            Me.LabelLevelTwoStyle_Size.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelLevelTwoStyle_Size.TabIndex = 4
            Me.LabelLevelTwoStyle_Size.Text = "Size:"
            '
            'CheckBoxLevelTwoStyle_Bold
            '
            Me.CheckBoxLevelTwoStyle_Bold.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxLevelTwoStyle_Bold.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxLevelTwoStyle_Bold.CheckValue = 0
            Me.CheckBoxLevelTwoStyle_Bold.CheckValueChecked = 1
            Me.CheckBoxLevelTwoStyle_Bold.CheckValueUnchecked = 0
            Me.CheckBoxLevelTwoStyle_Bold.ChildControls = CType(resources.GetObject("CheckBoxLevelTwoStyle_Bold.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLevelTwoStyle_Bold.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxLevelTwoStyle_Bold.Location = New System.Drawing.Point(5, 102)
            Me.CheckBoxLevelTwoStyle_Bold.Name = "CheckBoxLevelTwoStyle_Bold"
            Me.CheckBoxLevelTwoStyle_Bold.OldestSibling = Nothing
            Me.CheckBoxLevelTwoStyle_Bold.SecurityEnabled = True
            Me.CheckBoxLevelTwoStyle_Bold.SiblingControls = CType(resources.GetObject("CheckBoxLevelTwoStyle_Bold.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLevelTwoStyle_Bold.Size = New System.Drawing.Size(134, 20)
            Me.CheckBoxLevelTwoStyle_Bold.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxLevelTwoStyle_Bold.TabIndex = 3
            Me.CheckBoxLevelTwoStyle_Bold.Text = "Bold"
            '
            'CheckBoxLevelTwoStyle_Underline
            '
            Me.CheckBoxLevelTwoStyle_Underline.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxLevelTwoStyle_Underline.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxLevelTwoStyle_Underline.CheckValue = 0
            Me.CheckBoxLevelTwoStyle_Underline.CheckValueChecked = 1
            Me.CheckBoxLevelTwoStyle_Underline.CheckValueUnchecked = 0
            Me.CheckBoxLevelTwoStyle_Underline.ChildControls = CType(resources.GetObject("CheckBoxLevelTwoStyle_Underline.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLevelTwoStyle_Underline.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxLevelTwoStyle_Underline.Location = New System.Drawing.Point(5, 50)
            Me.CheckBoxLevelTwoStyle_Underline.Name = "CheckBoxLevelTwoStyle_Underline"
            Me.CheckBoxLevelTwoStyle_Underline.OldestSibling = Nothing
            Me.CheckBoxLevelTwoStyle_Underline.SecurityEnabled = True
            Me.CheckBoxLevelTwoStyle_Underline.SiblingControls = CType(resources.GetObject("CheckBoxLevelTwoStyle_Underline.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLevelTwoStyle_Underline.Size = New System.Drawing.Size(134, 20)
            Me.CheckBoxLevelTwoStyle_Underline.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxLevelTwoStyle_Underline.TabIndex = 1
            Me.CheckBoxLevelTwoStyle_Underline.Text = "Underline"
            '
            'CheckBoxLevelTwoStyle_Italic
            '
            Me.CheckBoxLevelTwoStyle_Italic.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxLevelTwoStyle_Italic.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxLevelTwoStyle_Italic.CheckValue = 0
            Me.CheckBoxLevelTwoStyle_Italic.CheckValueChecked = 1
            Me.CheckBoxLevelTwoStyle_Italic.CheckValueUnchecked = 0
            Me.CheckBoxLevelTwoStyle_Italic.ChildControls = CType(resources.GetObject("CheckBoxLevelTwoStyle_Italic.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLevelTwoStyle_Italic.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxLevelTwoStyle_Italic.Location = New System.Drawing.Point(5, 24)
            Me.CheckBoxLevelTwoStyle_Italic.Name = "CheckBoxLevelTwoStyle_Italic"
            Me.CheckBoxLevelTwoStyle_Italic.OldestSibling = Nothing
            Me.CheckBoxLevelTwoStyle_Italic.SecurityEnabled = True
            Me.CheckBoxLevelTwoStyle_Italic.SiblingControls = CType(resources.GetObject("CheckBoxLevelTwoStyle_Italic.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLevelTwoStyle_Italic.Size = New System.Drawing.Size(134, 20)
            Me.CheckBoxLevelTwoStyle_Italic.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxLevelTwoStyle_Italic.TabIndex = 0
            Me.CheckBoxLevelTwoStyle_Italic.Text = "Italic"
            '
            'PanelLevelTable_Column1
            '
            Me.PanelLevelTable_Column1.Controls.Add(Me.GroupBoxColumn1_LevelOneStyle)
            Me.PanelLevelTable_Column1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelLevelTable_Column1.Location = New System.Drawing.Point(0, 0)
            Me.PanelLevelTable_Column1.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelLevelTable_Column1.Name = "PanelLevelTable_Column1"
            Me.PanelLevelTable_Column1.Size = New System.Drawing.Size(148, 154)
            Me.PanelLevelTable_Column1.TabIndex = 0
            '
            'GroupBoxColumn1_LevelOneStyle
            '
            Me.GroupBoxColumn1_LevelOneStyle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxColumn1_LevelOneStyle.Controls.Add(Me.NumericInputLevelOneStyle_Size)
            Me.GroupBoxColumn1_LevelOneStyle.Controls.Add(Me.CheckBoxLevelOneStyle_Bullet)
            Me.GroupBoxColumn1_LevelOneStyle.Controls.Add(Me.LabelLevelOneStyle_Size)
            Me.GroupBoxColumn1_LevelOneStyle.Controls.Add(Me.CheckBoxLevelOneStyle_Bold)
            Me.GroupBoxColumn1_LevelOneStyle.Controls.Add(Me.CheckBoxLevelOneStyle_Underline)
            Me.GroupBoxColumn1_LevelOneStyle.Controls.Add(Me.CheckBoxLevelOneStyle_Italic)
            Me.GroupBoxColumn1_LevelOneStyle.Location = New System.Drawing.Point(0, 0)
            Me.GroupBoxColumn1_LevelOneStyle.Name = "GroupBoxColumn1_LevelOneStyle"
            Me.GroupBoxColumn1_LevelOneStyle.Size = New System.Drawing.Size(144, 154)
            Me.GroupBoxColumn1_LevelOneStyle.TabIndex = 0
            Me.GroupBoxColumn1_LevelOneStyle.Text = "Level One Style"
            '
            'NumericInputLevelOneStyle_Size
            '
            Me.NumericInputLevelOneStyle_Size.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Short]
            Me.NumericInputLevelOneStyle_Size.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputLevelOneStyle_Size.Location = New System.Drawing.Point(48, 128)
            Me.NumericInputLevelOneStyle_Size.Name = "NumericInputLevelOneStyle_Size"
            Me.NumericInputLevelOneStyle_Size.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputLevelOneStyle_Size.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputLevelOneStyle_Size.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputLevelOneStyle_Size.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputLevelOneStyle_Size.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputLevelOneStyle_Size.Properties.IsFloatValue = False
            Me.NumericInputLevelOneStyle_Size.Properties.Mask.EditMask = "f0"
            Me.NumericInputLevelOneStyle_Size.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputLevelOneStyle_Size.Properties.MaxLength = 6
            Me.NumericInputLevelOneStyle_Size.Properties.MaxValue = New Decimal(New Integer() {32767, 0, 0, 0})
            Me.NumericInputLevelOneStyle_Size.Properties.MinValue = New Decimal(New Integer() {32768, 0, 0, -2147483648})
            Me.NumericInputLevelOneStyle_Size.Size = New System.Drawing.Size(91, 20)
            Me.NumericInputLevelOneStyle_Size.TabIndex = 6
            '
            'CheckBoxLevelOneStyle_Bullet
            '
            Me.CheckBoxLevelOneStyle_Bullet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxLevelOneStyle_Bullet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxLevelOneStyle_Bullet.CheckValue = 0
            Me.CheckBoxLevelOneStyle_Bullet.CheckValueChecked = 1
            Me.CheckBoxLevelOneStyle_Bullet.CheckValueUnchecked = 0
            Me.CheckBoxLevelOneStyle_Bullet.ChildControls = CType(resources.GetObject("CheckBoxLevelOneStyle_Bullet.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLevelOneStyle_Bullet.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxLevelOneStyle_Bullet.Location = New System.Drawing.Point(5, 76)
            Me.CheckBoxLevelOneStyle_Bullet.Name = "CheckBoxLevelOneStyle_Bullet"
            Me.CheckBoxLevelOneStyle_Bullet.OldestSibling = Nothing
            Me.CheckBoxLevelOneStyle_Bullet.SecurityEnabled = True
            Me.CheckBoxLevelOneStyle_Bullet.SiblingControls = CType(resources.GetObject("CheckBoxLevelOneStyle_Bullet.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLevelOneStyle_Bullet.Size = New System.Drawing.Size(134, 20)
            Me.CheckBoxLevelOneStyle_Bullet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxLevelOneStyle_Bullet.TabIndex = 2
            Me.CheckBoxLevelOneStyle_Bullet.Text = "Bullet"
            '
            'LabelLevelOneStyle_Size
            '
            Me.LabelLevelOneStyle_Size.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelLevelOneStyle_Size.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelLevelOneStyle_Size.Location = New System.Drawing.Point(5, 128)
            Me.LabelLevelOneStyle_Size.Name = "LabelLevelOneStyle_Size"
            Me.LabelLevelOneStyle_Size.Size = New System.Drawing.Size(37, 20)
            Me.LabelLevelOneStyle_Size.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelLevelOneStyle_Size.TabIndex = 4
            Me.LabelLevelOneStyle_Size.Text = "Size:"
            '
            'CheckBoxLevelOneStyle_Bold
            '
            Me.CheckBoxLevelOneStyle_Bold.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxLevelOneStyle_Bold.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxLevelOneStyle_Bold.CheckValue = 0
            Me.CheckBoxLevelOneStyle_Bold.CheckValueChecked = 1
            Me.CheckBoxLevelOneStyle_Bold.CheckValueUnchecked = 0
            Me.CheckBoxLevelOneStyle_Bold.ChildControls = CType(resources.GetObject("CheckBoxLevelOneStyle_Bold.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLevelOneStyle_Bold.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxLevelOneStyle_Bold.Location = New System.Drawing.Point(5, 102)
            Me.CheckBoxLevelOneStyle_Bold.Name = "CheckBoxLevelOneStyle_Bold"
            Me.CheckBoxLevelOneStyle_Bold.OldestSibling = Nothing
            Me.CheckBoxLevelOneStyle_Bold.SecurityEnabled = True
            Me.CheckBoxLevelOneStyle_Bold.SiblingControls = CType(resources.GetObject("CheckBoxLevelOneStyle_Bold.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLevelOneStyle_Bold.Size = New System.Drawing.Size(134, 20)
            Me.CheckBoxLevelOneStyle_Bold.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxLevelOneStyle_Bold.TabIndex = 3
            Me.CheckBoxLevelOneStyle_Bold.Text = "Bold"
            '
            'CheckBoxLevelOneStyle_Underline
            '
            Me.CheckBoxLevelOneStyle_Underline.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxLevelOneStyle_Underline.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxLevelOneStyle_Underline.CheckValue = 0
            Me.CheckBoxLevelOneStyle_Underline.CheckValueChecked = 1
            Me.CheckBoxLevelOneStyle_Underline.CheckValueUnchecked = 0
            Me.CheckBoxLevelOneStyle_Underline.ChildControls = CType(resources.GetObject("CheckBoxLevelOneStyle_Underline.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLevelOneStyle_Underline.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxLevelOneStyle_Underline.Location = New System.Drawing.Point(5, 50)
            Me.CheckBoxLevelOneStyle_Underline.Name = "CheckBoxLevelOneStyle_Underline"
            Me.CheckBoxLevelOneStyle_Underline.OldestSibling = Nothing
            Me.CheckBoxLevelOneStyle_Underline.SecurityEnabled = True
            Me.CheckBoxLevelOneStyle_Underline.SiblingControls = CType(resources.GetObject("CheckBoxLevelOneStyle_Underline.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLevelOneStyle_Underline.Size = New System.Drawing.Size(134, 20)
            Me.CheckBoxLevelOneStyle_Underline.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxLevelOneStyle_Underline.TabIndex = 1
            Me.CheckBoxLevelOneStyle_Underline.Text = "Underline"
            '
            'CheckBoxLevelOneStyle_Italic
            '
            Me.CheckBoxLevelOneStyle_Italic.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxLevelOneStyle_Italic.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxLevelOneStyle_Italic.CheckValue = 0
            Me.CheckBoxLevelOneStyle_Italic.CheckValueChecked = 1
            Me.CheckBoxLevelOneStyle_Italic.CheckValueUnchecked = 0
            Me.CheckBoxLevelOneStyle_Italic.ChildControls = CType(resources.GetObject("CheckBoxLevelOneStyle_Italic.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLevelOneStyle_Italic.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxLevelOneStyle_Italic.Location = New System.Drawing.Point(5, 24)
            Me.CheckBoxLevelOneStyle_Italic.Name = "CheckBoxLevelOneStyle_Italic"
            Me.CheckBoxLevelOneStyle_Italic.OldestSibling = Nothing
            Me.CheckBoxLevelOneStyle_Italic.SecurityEnabled = True
            Me.CheckBoxLevelOneStyle_Italic.SiblingControls = CType(resources.GetObject("CheckBoxLevelOneStyle_Italic.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLevelOneStyle_Italic.Size = New System.Drawing.Size(134, 20)
            Me.CheckBoxLevelOneStyle_Italic.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxLevelOneStyle_Italic.TabIndex = 0
            Me.CheckBoxLevelOneStyle_Italic.Text = "Italic"
            '
            'GroupBoxHeader_Options
            '
            Me.GroupBoxHeader_Options.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxHeader_Options.Controls.Add(Me.TableLayoutPanelOptions_OptionsTable2)
            Me.GroupBoxHeader_Options.Controls.Add(Me.TableLayoutPanelOptions_OptionsTable)
            Me.GroupBoxHeader_Options.Location = New System.Drawing.Point(4, 30)
            Me.GroupBoxHeader_Options.Name = "GroupBoxHeader_Options"
            Me.GroupBoxHeader_Options.Size = New System.Drawing.Size(594, 190)
            Me.GroupBoxHeader_Options.TabIndex = 5
            Me.GroupBoxHeader_Options.Text = "Options"
            '
            'TableLayoutPanelOptions_OptionsTable2
            '
            Me.TableLayoutPanelOptions_OptionsTable2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TableLayoutPanelOptions_OptionsTable2.ColumnCount = 3
            Me.TableLayoutPanelOptions_OptionsTable2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
            Me.TableLayoutPanelOptions_OptionsTable2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
            Me.TableLayoutPanelOptions_OptionsTable2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.0!))
            Me.TableLayoutPanelOptions_OptionsTable2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanelOptions_OptionsTable2.Controls.Add(Me.PanelOptionsTable2_Column3, 2, 0)
            Me.TableLayoutPanelOptions_OptionsTable2.Controls.Add(Me.PanelOptionsTable2_Column2, 1, 0)
            Me.TableLayoutPanelOptions_OptionsTable2.Controls.Add(Me.PanelOptionsTable2_Column1, 0, 0)
            Me.TableLayoutPanelOptions_OptionsTable2.Location = New System.Drawing.Point(5, 112)
            Me.TableLayoutPanelOptions_OptionsTable2.Name = "TableLayoutPanelOptions_OptionsTable2"
            Me.TableLayoutPanelOptions_OptionsTable2.RowCount = 1
            Me.TableLayoutPanelOptions_OptionsTable2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanelOptions_OptionsTable2.Size = New System.Drawing.Size(584, 75)
            Me.TableLayoutPanelOptions_OptionsTable2.TabIndex = 1
            '
            'PanelOptionsTable2_Column3
            '
            Me.PanelOptionsTable2_Column3.Controls.Add(Me.CheckBoxColumn3_OpenedBy)
            Me.PanelOptionsTable2_Column3.Controls.Add(Me.CheckBoxColumn3_DueDate)
            Me.PanelOptionsTable2_Column3.Controls.Add(Me.CheckBoxColumn3_DepartmentTeam)
            Me.PanelOptionsTable2_Column3.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelOptionsTable2_Column3.Location = New System.Drawing.Point(384, 0)
            Me.PanelOptionsTable2_Column3.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelOptionsTable2_Column3.Name = "PanelOptionsTable2_Column3"
            Me.PanelOptionsTable2_Column3.Size = New System.Drawing.Size(200, 75)
            Me.PanelOptionsTable2_Column3.TabIndex = 2
            '
            'CheckBoxColumn3_OpenedBy
            '
            Me.CheckBoxColumn3_OpenedBy.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxColumn3_OpenedBy.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxColumn3_OpenedBy.CheckValue = 0
            Me.CheckBoxColumn3_OpenedBy.CheckValueChecked = 1
            Me.CheckBoxColumn3_OpenedBy.CheckValueUnchecked = 0
            Me.CheckBoxColumn3_OpenedBy.ChildControls = CType(resources.GetObject("CheckBoxColumn3_OpenedBy.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxColumn3_OpenedBy.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxColumn3_OpenedBy.Location = New System.Drawing.Point(3, 52)
            Me.CheckBoxColumn3_OpenedBy.Name = "CheckBoxColumn3_OpenedBy"
            Me.CheckBoxColumn3_OpenedBy.OldestSibling = Nothing
            Me.CheckBoxColumn3_OpenedBy.SecurityEnabled = True
            Me.CheckBoxColumn3_OpenedBy.SiblingControls = CType(resources.GetObject("CheckBoxColumn3_OpenedBy.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxColumn3_OpenedBy.Size = New System.Drawing.Size(197, 20)
            Me.CheckBoxColumn3_OpenedBy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxColumn3_OpenedBy.TabIndex = 2
            Me.CheckBoxColumn3_OpenedBy.Text = "Opened By"
            '
            'CheckBoxColumn3_DueDate
            '
            Me.CheckBoxColumn3_DueDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxColumn3_DueDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxColumn3_DueDate.CheckValue = 0
            Me.CheckBoxColumn3_DueDate.CheckValueChecked = 1
            Me.CheckBoxColumn3_DueDate.CheckValueUnchecked = 0
            Me.CheckBoxColumn3_DueDate.ChildControls = CType(resources.GetObject("CheckBoxColumn3_DueDate.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxColumn3_DueDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxColumn3_DueDate.Location = New System.Drawing.Point(3, 26)
            Me.CheckBoxColumn3_DueDate.Name = "CheckBoxColumn3_DueDate"
            Me.CheckBoxColumn3_DueDate.OldestSibling = Nothing
            Me.CheckBoxColumn3_DueDate.SecurityEnabled = True
            Me.CheckBoxColumn3_DueDate.SiblingControls = CType(resources.GetObject("CheckBoxColumn3_DueDate.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxColumn3_DueDate.Size = New System.Drawing.Size(197, 20)
            Me.CheckBoxColumn3_DueDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxColumn3_DueDate.TabIndex = 1
            Me.CheckBoxColumn3_DueDate.Text = "Due Date"
            '
            'CheckBoxColumn3_DepartmentTeam
            '
            Me.CheckBoxColumn3_DepartmentTeam.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxColumn3_DepartmentTeam.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxColumn3_DepartmentTeam.CheckValue = 0
            Me.CheckBoxColumn3_DepartmentTeam.CheckValueChecked = 1
            Me.CheckBoxColumn3_DepartmentTeam.CheckValueUnchecked = 0
            Me.CheckBoxColumn3_DepartmentTeam.ChildControls = CType(resources.GetObject("CheckBoxColumn3_DepartmentTeam.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxColumn3_DepartmentTeam.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxColumn3_DepartmentTeam.Location = New System.Drawing.Point(3, 0)
            Me.CheckBoxColumn3_DepartmentTeam.Name = "CheckBoxColumn3_DepartmentTeam"
            Me.CheckBoxColumn3_DepartmentTeam.OldestSibling = Nothing
            Me.CheckBoxColumn3_DepartmentTeam.SecurityEnabled = True
            Me.CheckBoxColumn3_DepartmentTeam.SiblingControls = CType(resources.GetObject("CheckBoxColumn3_DepartmentTeam.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxColumn3_DepartmentTeam.Size = New System.Drawing.Size(197, 20)
            Me.CheckBoxColumn3_DepartmentTeam.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxColumn3_DepartmentTeam.TabIndex = 0
            Me.CheckBoxColumn3_DepartmentTeam.Text = "Department / Team"
            '
            'PanelOptionsTable2_Column2
            '
            Me.PanelOptionsTable2_Column2.Controls.Add(Me.CheckBoxColumn2_RushChargesApproved)
            Me.PanelOptionsTable2_Column2.Controls.Add(Me.CheckBoxColumn2_ApprovedEstimateRequired)
            Me.PanelOptionsTable2_Column2.Controls.Add(Me.CheckBoxColumn2_Budget)
            Me.PanelOptionsTable2_Column2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelOptionsTable2_Column2.Location = New System.Drawing.Point(192, 0)
            Me.PanelOptionsTable2_Column2.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelOptionsTable2_Column2.Name = "PanelOptionsTable2_Column2"
            Me.PanelOptionsTable2_Column2.Size = New System.Drawing.Size(192, 75)
            Me.PanelOptionsTable2_Column2.TabIndex = 1
            '
            'CheckBoxColumn2_RushChargesApproved
            '
            Me.CheckBoxColumn2_RushChargesApproved.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxColumn2_RushChargesApproved.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxColumn2_RushChargesApproved.CheckValue = 0
            Me.CheckBoxColumn2_RushChargesApproved.CheckValueChecked = 1
            Me.CheckBoxColumn2_RushChargesApproved.CheckValueUnchecked = 0
            Me.CheckBoxColumn2_RushChargesApproved.ChildControls = CType(resources.GetObject("CheckBoxColumn2_RushChargesApproved.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxColumn2_RushChargesApproved.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxColumn2_RushChargesApproved.Location = New System.Drawing.Point(3, 52)
            Me.CheckBoxColumn2_RushChargesApproved.Name = "CheckBoxColumn2_RushChargesApproved"
            Me.CheckBoxColumn2_RushChargesApproved.OldestSibling = Nothing
            Me.CheckBoxColumn2_RushChargesApproved.SecurityEnabled = True
            Me.CheckBoxColumn2_RushChargesApproved.SiblingControls = CType(resources.GetObject("CheckBoxColumn2_RushChargesApproved.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxColumn2_RushChargesApproved.Size = New System.Drawing.Size(186, 20)
            Me.CheckBoxColumn2_RushChargesApproved.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxColumn2_RushChargesApproved.TabIndex = 2
            Me.CheckBoxColumn2_RushChargesApproved.Text = "Rush Charges Approved"
            '
            'CheckBoxColumn2_ApprovedEstimateRequired
            '
            Me.CheckBoxColumn2_ApprovedEstimateRequired.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxColumn2_ApprovedEstimateRequired.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxColumn2_ApprovedEstimateRequired.CheckValue = 0
            Me.CheckBoxColumn2_ApprovedEstimateRequired.CheckValueChecked = 1
            Me.CheckBoxColumn2_ApprovedEstimateRequired.CheckValueUnchecked = 0
            Me.CheckBoxColumn2_ApprovedEstimateRequired.ChildControls = CType(resources.GetObject("CheckBoxColumn2_ApprovedEstimateRequired.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxColumn2_ApprovedEstimateRequired.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxColumn2_ApprovedEstimateRequired.Location = New System.Drawing.Point(3, 26)
            Me.CheckBoxColumn2_ApprovedEstimateRequired.Name = "CheckBoxColumn2_ApprovedEstimateRequired"
            Me.CheckBoxColumn2_ApprovedEstimateRequired.OldestSibling = Nothing
            Me.CheckBoxColumn2_ApprovedEstimateRequired.SecurityEnabled = True
            Me.CheckBoxColumn2_ApprovedEstimateRequired.SiblingControls = CType(resources.GetObject("CheckBoxColumn2_ApprovedEstimateRequired.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxColumn2_ApprovedEstimateRequired.Size = New System.Drawing.Size(186, 20)
            Me.CheckBoxColumn2_ApprovedEstimateRequired.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxColumn2_ApprovedEstimateRequired.TabIndex = 1
            Me.CheckBoxColumn2_ApprovedEstimateRequired.Text = "Approved Estimate Required"
            '
            'CheckBoxColumn2_Budget
            '
            Me.CheckBoxColumn2_Budget.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxColumn2_Budget.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxColumn2_Budget.CheckValue = 0
            Me.CheckBoxColumn2_Budget.CheckValueChecked = 1
            Me.CheckBoxColumn2_Budget.CheckValueUnchecked = 0
            Me.CheckBoxColumn2_Budget.ChildControls = CType(resources.GetObject("CheckBoxColumn2_Budget.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxColumn2_Budget.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxColumn2_Budget.Location = New System.Drawing.Point(3, 0)
            Me.CheckBoxColumn2_Budget.Name = "CheckBoxColumn2_Budget"
            Me.CheckBoxColumn2_Budget.OldestSibling = Nothing
            Me.CheckBoxColumn2_Budget.SecurityEnabled = True
            Me.CheckBoxColumn2_Budget.SiblingControls = CType(resources.GetObject("CheckBoxColumn2_Budget.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxColumn2_Budget.Size = New System.Drawing.Size(186, 20)
            Me.CheckBoxColumn2_Budget.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxColumn2_Budget.TabIndex = 0
            Me.CheckBoxColumn2_Budget.Text = "Budget"
            '
            'PanelOptionsTable2_Column1
            '
            Me.PanelOptionsTable2_Column1.Controls.Add(Me.CheckBoxColumn1_Campaign)
            Me.PanelOptionsTable2_Column1.Controls.Add(Me.CheckBoxColumn1_DateOpened)
            Me.PanelOptionsTable2_Column1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelOptionsTable2_Column1.Location = New System.Drawing.Point(0, 0)
            Me.PanelOptionsTable2_Column1.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelOptionsTable2_Column1.Name = "PanelOptionsTable2_Column1"
            Me.PanelOptionsTable2_Column1.Size = New System.Drawing.Size(192, 75)
            Me.PanelOptionsTable2_Column1.TabIndex = 0
            '
            'CheckBoxColumn1_Campaign
            '
            Me.CheckBoxColumn1_Campaign.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxColumn1_Campaign.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxColumn1_Campaign.CheckValue = 0
            Me.CheckBoxColumn1_Campaign.CheckValueChecked = 1
            Me.CheckBoxColumn1_Campaign.CheckValueUnchecked = 0
            Me.CheckBoxColumn1_Campaign.ChildControls = CType(resources.GetObject("CheckBoxColumn1_Campaign.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxColumn1_Campaign.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxColumn1_Campaign.Location = New System.Drawing.Point(0, 26)
            Me.CheckBoxColumn1_Campaign.Name = "CheckBoxColumn1_Campaign"
            Me.CheckBoxColumn1_Campaign.OldestSibling = Nothing
            Me.CheckBoxColumn1_Campaign.SecurityEnabled = True
            Me.CheckBoxColumn1_Campaign.SiblingControls = CType(resources.GetObject("CheckBoxColumn1_Campaign.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxColumn1_Campaign.Size = New System.Drawing.Size(189, 20)
            Me.CheckBoxColumn1_Campaign.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxColumn1_Campaign.TabIndex = 2
            Me.CheckBoxColumn1_Campaign.Text = "Campaign"
            '
            'CheckBoxColumn1_DateOpened
            '
            Me.CheckBoxColumn1_DateOpened.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxColumn1_DateOpened.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxColumn1_DateOpened.CheckValue = 0
            Me.CheckBoxColumn1_DateOpened.CheckValueChecked = 1
            Me.CheckBoxColumn1_DateOpened.CheckValueUnchecked = 0
            Me.CheckBoxColumn1_DateOpened.ChildControls = CType(resources.GetObject("CheckBoxColumn1_DateOpened.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxColumn1_DateOpened.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxColumn1_DateOpened.Location = New System.Drawing.Point(0, 0)
            Me.CheckBoxColumn1_DateOpened.Name = "CheckBoxColumn1_DateOpened"
            Me.CheckBoxColumn1_DateOpened.OldestSibling = Nothing
            Me.CheckBoxColumn1_DateOpened.SecurityEnabled = True
            Me.CheckBoxColumn1_DateOpened.SiblingControls = CType(resources.GetObject("CheckBoxColumn1_DateOpened.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxColumn1_DateOpened.Size = New System.Drawing.Size(189, 20)
            Me.CheckBoxColumn1_DateOpened.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxColumn1_DateOpened.TabIndex = 1
            Me.CheckBoxColumn1_DateOpened.Text = "Date Opened"
            '
            'TableLayoutPanelOptions_OptionsTable
            '
            Me.TableLayoutPanelOptions_OptionsTable.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TableLayoutPanelOptions_OptionsTable.ColumnCount = 4
            Me.TableLayoutPanelOptions_OptionsTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
            Me.TableLayoutPanelOptions_OptionsTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
            Me.TableLayoutPanelOptions_OptionsTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
            Me.TableLayoutPanelOptions_OptionsTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
            Me.TableLayoutPanelOptions_OptionsTable.Controls.Add(Me.PanelOptionsTable_Column4, 3, 0)
            Me.TableLayoutPanelOptions_OptionsTable.Controls.Add(Me.PanelOptionsTable_Column3, 2, 0)
            Me.TableLayoutPanelOptions_OptionsTable.Controls.Add(Me.PanelOptionsTable_Column2, 1, 0)
            Me.TableLayoutPanelOptions_OptionsTable.Controls.Add(Me.PanelOptionsTable_Column1, 0, 0)
            Me.TableLayoutPanelOptions_OptionsTable.Location = New System.Drawing.Point(5, 24)
            Me.TableLayoutPanelOptions_OptionsTable.Name = "TableLayoutPanelOptions_OptionsTable"
            Me.TableLayoutPanelOptions_OptionsTable.RowCount = 1
            Me.TableLayoutPanelOptions_OptionsTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanelOptions_OptionsTable.Size = New System.Drawing.Size(584, 75)
            Me.TableLayoutPanelOptions_OptionsTable.TabIndex = 0
            '
            'PanelOptionsTable_Column4
            '
            Me.PanelOptionsTable_Column4.Controls.Add(Me.CheckBoxColumn4_ClientReference)
            Me.PanelOptionsTable_Column4.Controls.Add(Me.CheckBoxColumn4_ComponentDescription)
            Me.PanelOptionsTable_Column4.Controls.Add(Me.CheckBoxColumn4_JobDescription)
            Me.PanelOptionsTable_Column4.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelOptionsTable_Column4.Location = New System.Drawing.Point(438, 0)
            Me.PanelOptionsTable_Column4.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelOptionsTable_Column4.Name = "PanelOptionsTable_Column4"
            Me.PanelOptionsTable_Column4.Size = New System.Drawing.Size(146, 75)
            Me.PanelOptionsTable_Column4.TabIndex = 3
            '
            'CheckBoxColumn4_ClientReference
            '
            Me.CheckBoxColumn4_ClientReference.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxColumn4_ClientReference.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxColumn4_ClientReference.CheckValue = 0
            Me.CheckBoxColumn4_ClientReference.CheckValueChecked = 1
            Me.CheckBoxColumn4_ClientReference.CheckValueUnchecked = 0
            Me.CheckBoxColumn4_ClientReference.ChildControls = CType(resources.GetObject("CheckBoxColumn4_ClientReference.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxColumn4_ClientReference.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxColumn4_ClientReference.Location = New System.Drawing.Point(3, 52)
            Me.CheckBoxColumn4_ClientReference.Name = "CheckBoxColumn4_ClientReference"
            Me.CheckBoxColumn4_ClientReference.OldestSibling = Nothing
            Me.CheckBoxColumn4_ClientReference.SecurityEnabled = True
            Me.CheckBoxColumn4_ClientReference.SiblingControls = CType(resources.GetObject("CheckBoxColumn4_ClientReference.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxColumn4_ClientReference.Size = New System.Drawing.Size(143, 20)
            Me.CheckBoxColumn4_ClientReference.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxColumn4_ClientReference.TabIndex = 2
            Me.CheckBoxColumn4_ClientReference.Text = "Client Reference"
            '
            'CheckBoxColumn4_ComponentDescription
            '
            Me.CheckBoxColumn4_ComponentDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxColumn4_ComponentDescription.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxColumn4_ComponentDescription.CheckValue = 0
            Me.CheckBoxColumn4_ComponentDescription.CheckValueChecked = 1
            Me.CheckBoxColumn4_ComponentDescription.CheckValueUnchecked = 0
            Me.CheckBoxColumn4_ComponentDescription.ChildControls = CType(resources.GetObject("CheckBoxColumn4_ComponentDescription.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxColumn4_ComponentDescription.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxColumn4_ComponentDescription.Location = New System.Drawing.Point(3, 26)
            Me.CheckBoxColumn4_ComponentDescription.Name = "CheckBoxColumn4_ComponentDescription"
            Me.CheckBoxColumn4_ComponentDescription.OldestSibling = Nothing
            Me.CheckBoxColumn4_ComponentDescription.SecurityEnabled = True
            Me.CheckBoxColumn4_ComponentDescription.SiblingControls = CType(resources.GetObject("CheckBoxColumn4_ComponentDescription.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxColumn4_ComponentDescription.Size = New System.Drawing.Size(143, 20)
            Me.CheckBoxColumn4_ComponentDescription.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxColumn4_ComponentDescription.TabIndex = 1
            Me.CheckBoxColumn4_ComponentDescription.Text = "Component Description"
            '
            'CheckBoxColumn4_JobDescription
            '
            Me.CheckBoxColumn4_JobDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxColumn4_JobDescription.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxColumn4_JobDescription.CheckValue = 0
            Me.CheckBoxColumn4_JobDescription.CheckValueChecked = 1
            Me.CheckBoxColumn4_JobDescription.CheckValueUnchecked = 0
            Me.CheckBoxColumn4_JobDescription.ChildControls = CType(resources.GetObject("CheckBoxColumn4_JobDescription.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxColumn4_JobDescription.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxColumn4_JobDescription.Location = New System.Drawing.Point(3, 0)
            Me.CheckBoxColumn4_JobDescription.Name = "CheckBoxColumn4_JobDescription"
            Me.CheckBoxColumn4_JobDescription.OldestSibling = Nothing
            Me.CheckBoxColumn4_JobDescription.SecurityEnabled = True
            Me.CheckBoxColumn4_JobDescription.SiblingControls = CType(resources.GetObject("CheckBoxColumn4_JobDescription.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxColumn4_JobDescription.Size = New System.Drawing.Size(143, 20)
            Me.CheckBoxColumn4_JobDescription.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxColumn4_JobDescription.TabIndex = 0
            Me.CheckBoxColumn4_JobDescription.Text = "Job Description"
            '
            'PanelOptionsTable_Column3
            '
            Me.PanelOptionsTable_Column3.Controls.Add(Me.CheckBoxColumn3_AccountExecutive)
            Me.PanelOptionsTable_Column3.Controls.Add(Me.CheckBoxColumn3_ComponentNumber)
            Me.PanelOptionsTable_Column3.Controls.Add(Me.CheckBoxColumn3_JobNumber)
            Me.PanelOptionsTable_Column3.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelOptionsTable_Column3.Location = New System.Drawing.Point(292, 0)
            Me.PanelOptionsTable_Column3.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelOptionsTable_Column3.Name = "PanelOptionsTable_Column3"
            Me.PanelOptionsTable_Column3.Size = New System.Drawing.Size(146, 75)
            Me.PanelOptionsTable_Column3.TabIndex = 2
            '
            'CheckBoxColumn3_AccountExecutive
            '
            Me.CheckBoxColumn3_AccountExecutive.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxColumn3_AccountExecutive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxColumn3_AccountExecutive.CheckValue = 0
            Me.CheckBoxColumn3_AccountExecutive.CheckValueChecked = 1
            Me.CheckBoxColumn3_AccountExecutive.CheckValueUnchecked = 0
            Me.CheckBoxColumn3_AccountExecutive.ChildControls = CType(resources.GetObject("CheckBoxColumn3_AccountExecutive.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxColumn3_AccountExecutive.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxColumn3_AccountExecutive.Location = New System.Drawing.Point(3, 52)
            Me.CheckBoxColumn3_AccountExecutive.Name = "CheckBoxColumn3_AccountExecutive"
            Me.CheckBoxColumn3_AccountExecutive.OldestSibling = Nothing
            Me.CheckBoxColumn3_AccountExecutive.SecurityEnabled = True
            Me.CheckBoxColumn3_AccountExecutive.SiblingControls = CType(resources.GetObject("CheckBoxColumn3_AccountExecutive.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxColumn3_AccountExecutive.Size = New System.Drawing.Size(140, 20)
            Me.CheckBoxColumn3_AccountExecutive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxColumn3_AccountExecutive.TabIndex = 2
            Me.CheckBoxColumn3_AccountExecutive.Text = "Account Executive"
            '
            'CheckBoxColumn3_ComponentNumber
            '
            Me.CheckBoxColumn3_ComponentNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxColumn3_ComponentNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxColumn3_ComponentNumber.CheckValue = 0
            Me.CheckBoxColumn3_ComponentNumber.CheckValueChecked = 1
            Me.CheckBoxColumn3_ComponentNumber.CheckValueUnchecked = 0
            Me.CheckBoxColumn3_ComponentNumber.ChildControls = CType(resources.GetObject("CheckBoxColumn3_ComponentNumber.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxColumn3_ComponentNumber.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxColumn3_ComponentNumber.Location = New System.Drawing.Point(3, 26)
            Me.CheckBoxColumn3_ComponentNumber.Name = "CheckBoxColumn3_ComponentNumber"
            Me.CheckBoxColumn3_ComponentNumber.OldestSibling = Nothing
            Me.CheckBoxColumn3_ComponentNumber.SecurityEnabled = True
            Me.CheckBoxColumn3_ComponentNumber.SiblingControls = CType(resources.GetObject("CheckBoxColumn3_ComponentNumber.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxColumn3_ComponentNumber.Size = New System.Drawing.Size(140, 20)
            Me.CheckBoxColumn3_ComponentNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxColumn3_ComponentNumber.TabIndex = 1
            Me.CheckBoxColumn3_ComponentNumber.Text = "Component Number"
            '
            'CheckBoxColumn3_JobNumber
            '
            Me.CheckBoxColumn3_JobNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxColumn3_JobNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxColumn3_JobNumber.CheckValue = 0
            Me.CheckBoxColumn3_JobNumber.CheckValueChecked = 1
            Me.CheckBoxColumn3_JobNumber.CheckValueUnchecked = 0
            Me.CheckBoxColumn3_JobNumber.ChildControls = CType(resources.GetObject("CheckBoxColumn3_JobNumber.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxColumn3_JobNumber.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxColumn3_JobNumber.Location = New System.Drawing.Point(3, 0)
            Me.CheckBoxColumn3_JobNumber.Name = "CheckBoxColumn3_JobNumber"
            Me.CheckBoxColumn3_JobNumber.OldestSibling = Nothing
            Me.CheckBoxColumn3_JobNumber.SecurityEnabled = True
            Me.CheckBoxColumn3_JobNumber.SiblingControls = CType(resources.GetObject("CheckBoxColumn3_JobNumber.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxColumn3_JobNumber.Size = New System.Drawing.Size(140, 20)
            Me.CheckBoxColumn3_JobNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxColumn3_JobNumber.TabIndex = 0
            Me.CheckBoxColumn3_JobNumber.Text = "Job Number"
            '
            'PanelOptionsTable_Column2
            '
            Me.PanelOptionsTable_Column2.Controls.Add(Me.CheckBoxColumn2_ProductAddress)
            Me.PanelOptionsTable_Column2.Controls.Add(Me.CheckBoxColumn2_DivisionAddress)
            Me.PanelOptionsTable_Column2.Controls.Add(Me.CheckBoxColumn2_ClientAddress)
            Me.PanelOptionsTable_Column2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelOptionsTable_Column2.Location = New System.Drawing.Point(146, 0)
            Me.PanelOptionsTable_Column2.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelOptionsTable_Column2.Name = "PanelOptionsTable_Column2"
            Me.PanelOptionsTable_Column2.Size = New System.Drawing.Size(146, 75)
            Me.PanelOptionsTable_Column2.TabIndex = 1
            '
            'CheckBoxColumn2_ProductAddress
            '
            Me.CheckBoxColumn2_ProductAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxColumn2_ProductAddress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxColumn2_ProductAddress.CheckValue = 0
            Me.CheckBoxColumn2_ProductAddress.CheckValueChecked = 1
            Me.CheckBoxColumn2_ProductAddress.CheckValueUnchecked = 0
            Me.CheckBoxColumn2_ProductAddress.ChildControls = CType(resources.GetObject("CheckBoxColumn2_ProductAddress.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxColumn2_ProductAddress.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxColumn2_ProductAddress.Location = New System.Drawing.Point(3, 52)
            Me.CheckBoxColumn2_ProductAddress.Name = "CheckBoxColumn2_ProductAddress"
            Me.CheckBoxColumn2_ProductAddress.OldestSibling = Nothing
            Me.CheckBoxColumn2_ProductAddress.SecurityEnabled = True
            Me.CheckBoxColumn2_ProductAddress.SiblingControls = CType(resources.GetObject("CheckBoxColumn2_ProductAddress.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxColumn2_ProductAddress.Size = New System.Drawing.Size(140, 20)
            Me.CheckBoxColumn2_ProductAddress.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxColumn2_ProductAddress.TabIndex = 2
            Me.CheckBoxColumn2_ProductAddress.Text = "Product Address"
            '
            'CheckBoxColumn2_DivisionAddress
            '
            Me.CheckBoxColumn2_DivisionAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxColumn2_DivisionAddress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxColumn2_DivisionAddress.CheckValue = 0
            Me.CheckBoxColumn2_DivisionAddress.CheckValueChecked = 1
            Me.CheckBoxColumn2_DivisionAddress.CheckValueUnchecked = 0
            Me.CheckBoxColumn2_DivisionAddress.ChildControls = CType(resources.GetObject("CheckBoxColumn2_DivisionAddress.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxColumn2_DivisionAddress.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxColumn2_DivisionAddress.Location = New System.Drawing.Point(3, 26)
            Me.CheckBoxColumn2_DivisionAddress.Name = "CheckBoxColumn2_DivisionAddress"
            Me.CheckBoxColumn2_DivisionAddress.OldestSibling = Nothing
            Me.CheckBoxColumn2_DivisionAddress.SecurityEnabled = True
            Me.CheckBoxColumn2_DivisionAddress.SiblingControls = CType(resources.GetObject("CheckBoxColumn2_DivisionAddress.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxColumn2_DivisionAddress.Size = New System.Drawing.Size(140, 20)
            Me.CheckBoxColumn2_DivisionAddress.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxColumn2_DivisionAddress.TabIndex = 1
            Me.CheckBoxColumn2_DivisionAddress.Text = "Division Address"
            '
            'CheckBoxColumn2_ClientAddress
            '
            Me.CheckBoxColumn2_ClientAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxColumn2_ClientAddress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxColumn2_ClientAddress.CheckValue = 0
            Me.CheckBoxColumn2_ClientAddress.CheckValueChecked = 1
            Me.CheckBoxColumn2_ClientAddress.CheckValueUnchecked = 0
            Me.CheckBoxColumn2_ClientAddress.ChildControls = CType(resources.GetObject("CheckBoxColumn2_ClientAddress.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxColumn2_ClientAddress.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxColumn2_ClientAddress.Location = New System.Drawing.Point(3, 0)
            Me.CheckBoxColumn2_ClientAddress.Name = "CheckBoxColumn2_ClientAddress"
            Me.CheckBoxColumn2_ClientAddress.OldestSibling = Nothing
            Me.CheckBoxColumn2_ClientAddress.SecurityEnabled = True
            Me.CheckBoxColumn2_ClientAddress.SiblingControls = CType(resources.GetObject("CheckBoxColumn2_ClientAddress.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxColumn2_ClientAddress.Size = New System.Drawing.Size(140, 20)
            Me.CheckBoxColumn2_ClientAddress.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxColumn2_ClientAddress.TabIndex = 0
            Me.CheckBoxColumn2_ClientAddress.Text = "Client Address"
            '
            'PanelOptionsTable_Column1
            '
            Me.PanelOptionsTable_Column1.Controls.Add(Me.CheckBoxColumn1_Product)
            Me.PanelOptionsTable_Column1.Controls.Add(Me.CheckBoxColumn1_Division)
            Me.PanelOptionsTable_Column1.Controls.Add(Me.CheckBoxColumn1_Client)
            Me.PanelOptionsTable_Column1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelOptionsTable_Column1.Location = New System.Drawing.Point(0, 0)
            Me.PanelOptionsTable_Column1.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelOptionsTable_Column1.Name = "PanelOptionsTable_Column1"
            Me.PanelOptionsTable_Column1.Size = New System.Drawing.Size(146, 75)
            Me.PanelOptionsTable_Column1.TabIndex = 0
            '
            'CheckBoxColumn1_Product
            '
            Me.CheckBoxColumn1_Product.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxColumn1_Product.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxColumn1_Product.CheckValue = 0
            Me.CheckBoxColumn1_Product.CheckValueChecked = 1
            Me.CheckBoxColumn1_Product.CheckValueUnchecked = 0
            Me.CheckBoxColumn1_Product.ChildControls = CType(resources.GetObject("CheckBoxColumn1_Product.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxColumn1_Product.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxColumn1_Product.Location = New System.Drawing.Point(0, 52)
            Me.CheckBoxColumn1_Product.Name = "CheckBoxColumn1_Product"
            Me.CheckBoxColumn1_Product.OldestSibling = Nothing
            Me.CheckBoxColumn1_Product.SecurityEnabled = True
            Me.CheckBoxColumn1_Product.SiblingControls = CType(resources.GetObject("CheckBoxColumn1_Product.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxColumn1_Product.Size = New System.Drawing.Size(143, 20)
            Me.CheckBoxColumn1_Product.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxColumn1_Product.TabIndex = 3
            Me.CheckBoxColumn1_Product.Text = "Product"
            '
            'CheckBoxColumn1_Division
            '
            Me.CheckBoxColumn1_Division.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxColumn1_Division.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxColumn1_Division.CheckValue = 0
            Me.CheckBoxColumn1_Division.CheckValueChecked = 1
            Me.CheckBoxColumn1_Division.CheckValueUnchecked = 0
            Me.CheckBoxColumn1_Division.ChildControls = CType(resources.GetObject("CheckBoxColumn1_Division.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxColumn1_Division.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxColumn1_Division.Location = New System.Drawing.Point(0, 26)
            Me.CheckBoxColumn1_Division.Name = "CheckBoxColumn1_Division"
            Me.CheckBoxColumn1_Division.OldestSibling = Nothing
            Me.CheckBoxColumn1_Division.SecurityEnabled = True
            Me.CheckBoxColumn1_Division.SiblingControls = CType(resources.GetObject("CheckBoxColumn1_Division.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxColumn1_Division.Size = New System.Drawing.Size(143, 20)
            Me.CheckBoxColumn1_Division.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxColumn1_Division.TabIndex = 2
            Me.CheckBoxColumn1_Division.Text = "Division"
            '
            'CheckBoxColumn1_Client
            '
            Me.CheckBoxColumn1_Client.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxColumn1_Client.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxColumn1_Client.CheckValue = 0
            Me.CheckBoxColumn1_Client.CheckValueChecked = 1
            Me.CheckBoxColumn1_Client.CheckValueUnchecked = 0
            Me.CheckBoxColumn1_Client.ChildControls = CType(resources.GetObject("CheckBoxColumn1_Client.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxColumn1_Client.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxColumn1_Client.Location = New System.Drawing.Point(0, 0)
            Me.CheckBoxColumn1_Client.Name = "CheckBoxColumn1_Client"
            Me.CheckBoxColumn1_Client.OldestSibling = Nothing
            Me.CheckBoxColumn1_Client.SecurityEnabled = True
            Me.CheckBoxColumn1_Client.SiblingControls = CType(resources.GetObject("CheckBoxColumn1_Client.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxColumn1_Client.Size = New System.Drawing.Size(143, 20)
            Me.CheckBoxColumn1_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxColumn1_Client.TabIndex = 1
            Me.CheckBoxColumn1_Client.Text = "Client"
            '
            'LabelHeader_Name
            '
            Me.LabelHeader_Name.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelHeader_Name.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelHeader_Name.Location = New System.Drawing.Point(133, 4)
            Me.LabelHeader_Name.Name = "LabelHeader_Name"
            Me.LabelHeader_Name.Size = New System.Drawing.Size(37, 20)
            Me.LabelHeader_Name.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelHeader_Name.TabIndex = 2
            Me.LabelHeader_Name.Text = "Name:"
            '
            'TextBoxHeader_Code
            '
            '
            '
            '
            Me.TextBoxHeader_Code.Border.Class = "TextBoxBorder"
            Me.TextBoxHeader_Code.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxHeader_Code.CheckSpellingOnValidate = False
            Me.TextBoxHeader_Code.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxHeader_Code.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxHeader_Code.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxHeader_Code.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxHeader_Code.FocusHighlightEnabled = True
            Me.TextBoxHeader_Code.Location = New System.Drawing.Point(47, 4)
            Me.TextBoxHeader_Code.MaxFileSize = CType(0, Long)
            Me.TextBoxHeader_Code.Name = "TextBoxHeader_Code"
            Me.TextBoxHeader_Code.Size = New System.Drawing.Size(80, 20)
            Me.TextBoxHeader_Code.TabIndex = 1
            Me.TextBoxHeader_Code.TabOnEnter = True
            '
            'LabelHeader_Code
            '
            Me.LabelHeader_Code.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelHeader_Code.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelHeader_Code.Location = New System.Drawing.Point(4, 4)
            Me.LabelHeader_Code.Name = "LabelHeader_Code"
            Me.LabelHeader_Code.Size = New System.Drawing.Size(37, 20)
            Me.LabelHeader_Code.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelHeader_Code.TabIndex = 0
            Me.LabelHeader_Code.Text = "Code:"
            '
            'TabItemCreativeBriefTemplateSetup_HeaderTab
            '
            Me.TabItemCreativeBriefTemplateSetup_HeaderTab.AttachedControl = Me.TabControlPanelHeaderTab_Header
            Me.TabItemCreativeBriefTemplateSetup_HeaderTab.Name = "TabItemCreativeBriefTemplateSetup_HeaderTab"
            Me.TabItemCreativeBriefTemplateSetup_HeaderTab.Text = "Header"
            '
            'PanelForm_TopPanel
            '
            Me.PanelForm_TopPanel.Controls.Add(Me.LabelTopPanel_Warning)
            Me.PanelForm_TopPanel.Dock = System.Windows.Forms.DockStyle.Top
            Me.PanelForm_TopPanel.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_TopPanel.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelForm_TopPanel.Name = "PanelForm_TopPanel"
            Me.PanelForm_TopPanel.Size = New System.Drawing.Size(602, 26)
            Me.PanelForm_TopPanel.TabIndex = 32
            '
            'LabelTopPanel_Warning
            '
            Me.LabelTopPanel_Warning.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTopPanel_Warning.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTopPanel_Warning.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelTopPanel_Warning.ForeColor = System.Drawing.Color.Red
            Me.LabelTopPanel_Warning.Location = New System.Drawing.Point(4, 3)
            Me.LabelTopPanel_Warning.Name = "LabelTopPanel_Warning"
            Me.LabelTopPanel_Warning.Size = New System.Drawing.Size(594, 20)
            Me.LabelTopPanel_Warning.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTopPanel_Warning.TabIndex = 0
            Me.LabelTopPanel_Warning.Text = "Warning: Editing this template will affect all creative briefs using this templat" & _
        "e."
            '
            'PanelForm_MainPanel
            '
            Me.PanelForm_MainPanel.Controls.Add(Me.TabControlControl_CreativeBriefTemplateSetup)
            Me.PanelForm_MainPanel.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_MainPanel.Location = New System.Drawing.Point(0, 26)
            Me.PanelForm_MainPanel.Name = "PanelForm_MainPanel"
            Me.PanelForm_MainPanel.Size = New System.Drawing.Size(602, 407)
            Me.PanelForm_MainPanel.TabIndex = 33
            '
            'CreativeBriefTemplateControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.PanelForm_MainPanel)
            Me.Controls.Add(Me.PanelForm_TopPanel)
            Me.Name = "CreativeBriefTemplateControl"
            Me.Size = New System.Drawing.Size(602, 433)
            CType(Me.TabControlControl_CreativeBriefTemplateSetup, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlControl_CreativeBriefTemplateSetup.ResumeLayout(False)
            Me.TabControlPanelDetailTab_Detail.ResumeLayout(False)
            CType(Me.TreeListControlDetail_Levels, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelHeaderTab_Header.ResumeLayout(False)
            Me.TableLayoutPanelHeader_LevelTable.ResumeLayout(False)
            Me.PanelLevelTable_Column4.ResumeLayout(False)
            CType(Me.GroupBoxColumn4_DetailLevelStyle, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxColumn4_DetailLevelStyle.ResumeLayout(False)
            CType(Me.NumericInputDetailLevelStyle_Size.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelLevelTable_Column3.ResumeLayout(False)
            CType(Me.GroupBoxColumn3_LevelThreeStyle, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxColumn3_LevelThreeStyle.ResumeLayout(False)
            CType(Me.NumericInputLevelThreeStyle_Size.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelLevelTable_Column2.ResumeLayout(False)
            CType(Me.GroupBoxColumn2_LevelTwoStyle, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxColumn2_LevelTwoStyle.ResumeLayout(False)
            CType(Me.NumericInputLevelTwoStyle_Size.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelLevelTable_Column1.ResumeLayout(False)
            CType(Me.GroupBoxColumn1_LevelOneStyle, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxColumn1_LevelOneStyle.ResumeLayout(False)
            CType(Me.NumericInputLevelOneStyle_Size.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxHeader_Options, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxHeader_Options.ResumeLayout(False)
            Me.TableLayoutPanelOptions_OptionsTable2.ResumeLayout(False)
            Me.PanelOptionsTable2_Column3.ResumeLayout(False)
            Me.PanelOptionsTable2_Column2.ResumeLayout(False)
            Me.PanelOptionsTable2_Column1.ResumeLayout(False)
            Me.TableLayoutPanelOptions_OptionsTable.ResumeLayout(False)
            Me.PanelOptionsTable_Column4.ResumeLayout(False)
            Me.PanelOptionsTable_Column3.ResumeLayout(False)
            Me.PanelOptionsTable_Column2.ResumeLayout(False)
            Me.PanelOptionsTable_Column1.ResumeLayout(False)
            Me.PanelForm_TopPanel.ResumeLayout(False)
            Me.PanelForm_MainPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents TabControlControl_CreativeBriefTemplateSetup As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelHeaderTab_Header As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemCreativeBriefTemplateSetup_HeaderTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelDetailTab_Detail As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemCreativeBriefTemplateSetup_DetailTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents GroupBoxHeader_Options As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents TableLayoutPanelOptions_OptionsTable2 As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents PanelOptionsTable2_Column3 As System.Windows.Forms.Panel
        Friend WithEvents CheckBoxColumn3_OpenedBy As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxColumn3_DueDate As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxColumn3_DepartmentTeam As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents PanelOptionsTable2_Column2 As System.Windows.Forms.Panel
        Friend WithEvents CheckBoxColumn2_RushChargesApproved As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxColumn2_ApprovedEstimateRequired As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxColumn2_Budget As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents PanelOptionsTable2_Column1 As System.Windows.Forms.Panel
        Friend WithEvents CheckBoxColumn1_Campaign As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxColumn1_DateOpened As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents TableLayoutPanelOptions_OptionsTable As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents PanelOptionsTable_Column4 As System.Windows.Forms.Panel
        Friend WithEvents CheckBoxColumn4_ClientReference As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxColumn4_ComponentDescription As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxColumn4_JobDescription As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents PanelOptionsTable_Column3 As System.Windows.Forms.Panel
        Friend WithEvents CheckBoxColumn3_AccountExecutive As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxColumn3_ComponentNumber As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxColumn3_JobNumber As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents PanelOptionsTable_Column2 As System.Windows.Forms.Panel
        Friend WithEvents CheckBoxColumn2_ProductAddress As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxColumn2_DivisionAddress As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxColumn2_ClientAddress As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents PanelOptionsTable_Column1 As System.Windows.Forms.Panel
        Friend WithEvents CheckBoxColumn1_Product As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxColumn1_Division As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxColumn1_Client As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents TextBoxHeader_Name As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents CheckBoxHeader_Inactive As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelHeader_Name As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxHeader_Code As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelHeader_Code As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TableLayoutPanelHeader_LevelTable As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents PanelLevelTable_Column4 As System.Windows.Forms.Panel
        Friend WithEvents GroupBoxColumn4_DetailLevelStyle As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents LabelDetailLevelStyle_Size As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxDetailLevelStyle_Bold As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxDetailLevelStyle_Underline As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxDetailLevelStyle_Italic As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents PanelLevelTable_Column3 As System.Windows.Forms.Panel
        Friend WithEvents GroupBoxColumn3_LevelThreeStyle As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents LabelLevelThreeStyle_Size As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxLevelThreeStyle_Bold As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxLevelThreeStyle_Underline As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxLevelThreeStyle_Italic As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents PanelLevelTable_Column2 As System.Windows.Forms.Panel
        Friend WithEvents GroupBoxColumn2_LevelTwoStyle As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents LabelLevelTwoStyle_Size As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxLevelTwoStyle_Bold As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxLevelTwoStyle_Underline As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxLevelTwoStyle_Italic As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents PanelLevelTable_Column1 As System.Windows.Forms.Panel
        Friend WithEvents GroupBoxColumn1_LevelOneStyle As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents LabelLevelOneStyle_Size As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxLevelOneStyle_Bold As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxLevelOneStyle_Underline As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxLevelOneStyle_Italic As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxDetailLevelStyle_Bullet As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxLevelThreeStyle_Bullet As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxLevelTwoStyle_Bullet As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxLevelOneStyle_Bullet As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents NumericInputDetailLevelStyle_Size As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputLevelThreeStyle_Size As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputLevelTwoStyle_Size As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputLevelOneStyle_Size As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents PanelForm_TopPanel As System.Windows.Forms.Panel
        Friend WithEvents LabelTopPanel_Warning As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents PanelForm_MainPanel As System.Windows.Forms.Panel
        Friend WithEvents TreeListControlDetail_Levels As AdvantageFramework.WinForm.Presentation.Controls.TreeListControl
        Friend WithEvents ButtonDetail_DeleteLevel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonDetail_AddLevel As AdvantageFramework.WinForm.Presentation.Controls.Button

    End Class

End Namespace
