Namespace GeneralLedger.Reports.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class GeneralLedgerReportDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GeneralLedgerReportDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.TabControlForm_OptionsPresets = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelOptionsTab_Options = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelOptions_Main = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ComboBoxOptions_RecordSource = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ButtonOptions_2Years = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonOptions_1Year = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonOptions_MTD = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonOptions_YTD = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelOptions_RecordSource = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelOptions_PostPeriodStart = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxOptions_PostPeriodStart = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelOptions_PostPeriodEnd = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxOptions_PostPeriodEnd = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.PanelOptions_Left = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.LabelOptions_Report = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ListBoxOptions_Reports = New AdvantageFramework.WinForm.Presentation.Controls.ListBox()
            Me.TabItemOptionsPresets_OptionsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelTypesTab_Types = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelTypes_Types = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.PanelTypes_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ButtonTypesRightSection_Add = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonTypesRightSection_AddAll = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonTypesRightSection_RemoveAll = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonTypesRightSection_Remove = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewRightSection_SelectedTypes = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterControl3 = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelTypes_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_AvailableTypes = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemReportTemplatePresets_TypesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelOtherTab_Other = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelOther_Other = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.PanelOther_OtherRightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ButtonOtherRightSection_Add = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonOtherRightSection_AddAll = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonOtherRightSection_RemoveAll = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonOtherRightSection_Remove = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewOtherRightSection_Other = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterControl2 = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelOther_OtherLeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewOtherLeftSection_Other = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemReportTemplatePresets_OtherTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelBaseTab_Bae = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelBase_Base = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.PanelBase_BaseRightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ButtonBaseRightSection_Add = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonBaseRightSection_AddAll = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonBaseRightSection_RemoveAll = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonBaseRightSection_Remove = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewBaseRightSection_Base = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterControl1 = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelBase_BaseLeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewBaseLeftSection_Base = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemReportTemplatePresets_BaseTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelOfficeTab_Office = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelOffice_Office = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.PanelOffice_OfficeRightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ButtonOfficeRightSection_Add = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonOfficeRightSection_AddAll = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewOfficeRightSection_Presets = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ButtonOfficeRightSection_Remove = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonOfficeRightSection_RemoveAll = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ExpandableSplitterOffice_OfficeLeftRightSection = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelOffice_OfficeLeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewOfficeLeftSection_Offices = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemReportTemplatePresets_OfficeTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelDepartmentTeamTab_DepartmentTeam = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelDepartmentTeam_DepartmentTeam = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.PanelDepartmentTeam_DTRightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ButtonDTRightSection_Add = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonDTRightSection_AddAll = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonDTRightSection_RemoveAll = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonDTRightSection_Remove = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewDTRightSection_Presets = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelDepartmentTeam_DTLeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewDTLeftSection_DepartmentTeams = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemReportTemplatePresets_DepartmentTeamTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            CType(Me.TabControlForm_OptionsPresets, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_OptionsPresets.SuspendLayout()
            Me.TabControlPanelOptionsTab_Options.SuspendLayout()
            CType(Me.PanelOptions_Main, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelOptions_Main.SuspendLayout()
            CType(Me.PanelOptions_Left, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelOptions_Left.SuspendLayout()
            CType(Me.ListBoxOptions_Reports, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelTypesTab_Types.SuspendLayout()
            CType(Me.PanelTypes_Types, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelTypes_Types.SuspendLayout()
            CType(Me.PanelTypes_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelTypes_RightSection.SuspendLayout()
            CType(Me.PanelTypes_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelTypes_LeftSection.SuspendLayout()
            Me.TabControlPanelOtherTab_Other.SuspendLayout()
            CType(Me.PanelOther_Other, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelOther_Other.SuspendLayout()
            CType(Me.PanelOther_OtherRightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelOther_OtherRightSection.SuspendLayout()
            CType(Me.PanelOther_OtherLeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelOther_OtherLeftSection.SuspendLayout()
            Me.TabControlPanelBaseTab_Bae.SuspendLayout()
            CType(Me.PanelBase_Base, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelBase_Base.SuspendLayout()
            CType(Me.PanelBase_BaseRightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelBase_BaseRightSection.SuspendLayout()
            CType(Me.PanelBase_BaseLeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelBase_BaseLeftSection.SuspendLayout()
            Me.TabControlPanelOfficeTab_Office.SuspendLayout()
            CType(Me.PanelOffice_Office, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelOffice_Office.SuspendLayout()
            CType(Me.PanelOffice_OfficeRightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelOffice_OfficeRightSection.SuspendLayout()
            CType(Me.PanelOffice_OfficeLeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelOffice_OfficeLeftSection.SuspendLayout()
            Me.TabControlPanelDepartmentTeamTab_DepartmentTeam.SuspendLayout()
            CType(Me.PanelDepartmentTeam_DepartmentTeam, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelDepartmentTeam_DepartmentTeam.SuspendLayout()
            CType(Me.PanelDepartmentTeam_DTRightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelDepartmentTeam_DTRightSection.SuspendLayout()
            CType(Me.PanelDepartmentTeam_DTLeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelDepartmentTeam_DTLeftSection.SuspendLayout()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(646, 360)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 2
            Me.ButtonForm_OK.Text = "OK"
            '
            'TabControlForm_OptionsPresets
            '
            Me.TabControlForm_OptionsPresets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlForm_OptionsPresets.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.TabControlForm_OptionsPresets.CanReorderTabs = False
            Me.TabControlForm_OptionsPresets.Controls.Add(Me.TabControlPanelOptionsTab_Options)
            Me.TabControlForm_OptionsPresets.Controls.Add(Me.TabControlPanelTypesTab_Types)
            Me.TabControlForm_OptionsPresets.Controls.Add(Me.TabControlPanelOtherTab_Other)
            Me.TabControlForm_OptionsPresets.Controls.Add(Me.TabControlPanelBaseTab_Bae)
            Me.TabControlForm_OptionsPresets.Controls.Add(Me.TabControlPanelOfficeTab_Office)
            Me.TabControlForm_OptionsPresets.Controls.Add(Me.TabControlPanelDepartmentTeamTab_DepartmentTeam)
            Me.TabControlForm_OptionsPresets.Location = New System.Drawing.Point(12, 12)
            Me.TabControlForm_OptionsPresets.Name = "TabControlForm_OptionsPresets"
            Me.TabControlForm_OptionsPresets.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_OptionsPresets.SelectedTabIndex = 0
            Me.TabControlForm_OptionsPresets.Size = New System.Drawing.Size(790, 342)
            Me.TabControlForm_OptionsPresets.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_OptionsPresets.TabIndex = 0
            Me.TabControlForm_OptionsPresets.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_OptionsPresets.Tabs.Add(Me.TabItemOptionsPresets_OptionsTab)
            Me.TabControlForm_OptionsPresets.Tabs.Add(Me.TabItemReportTemplatePresets_OfficeTab)
            Me.TabControlForm_OptionsPresets.Tabs.Add(Me.TabItemReportTemplatePresets_DepartmentTeamTab)
            Me.TabControlForm_OptionsPresets.Tabs.Add(Me.TabItemReportTemplatePresets_TypesTab)
            Me.TabControlForm_OptionsPresets.Tabs.Add(Me.TabItemReportTemplatePresets_OtherTab)
            Me.TabControlForm_OptionsPresets.Tabs.Add(Me.TabItemReportTemplatePresets_BaseTab)
            Me.TabControlForm_OptionsPresets.Text = "TabControl1"
            '
            'TabControlPanelOptionsTab_Options
            '
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.PanelOptions_Main)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.PanelOptions_Left)
            Me.TabControlPanelOptionsTab_Options.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelOptionsTab_Options.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelOptionsTab_Options.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelOptionsTab_Options.Name = "TabControlPanelOptionsTab_Options"
            Me.TabControlPanelOptionsTab_Options.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelOptionsTab_Options.Size = New System.Drawing.Size(790, 315)
            Me.TabControlPanelOptionsTab_Options.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelOptionsTab_Options.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelOptionsTab_Options.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelOptionsTab_Options.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelOptionsTab_Options.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelOptionsTab_Options.Style.GradientAngle = 90
            Me.TabControlPanelOptionsTab_Options.TabIndex = 0
            Me.TabControlPanelOptionsTab_Options.TabItem = Me.TabItemOptionsPresets_OptionsTab
            '
            'PanelOptions_Main
            '
            Me.PanelOptions_Main.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelOptions_Main.Appearance.Options.UseBackColor = True
            Me.PanelOptions_Main.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelOptions_Main.Controls.Add(Me.ComboBoxOptions_RecordSource)
            Me.PanelOptions_Main.Controls.Add(Me.ButtonOptions_2Years)
            Me.PanelOptions_Main.Controls.Add(Me.ButtonOptions_1Year)
            Me.PanelOptions_Main.Controls.Add(Me.ButtonOptions_MTD)
            Me.PanelOptions_Main.Controls.Add(Me.ButtonOptions_YTD)
            Me.PanelOptions_Main.Controls.Add(Me.LabelOptions_RecordSource)
            Me.PanelOptions_Main.Controls.Add(Me.LabelOptions_PostPeriodStart)
            Me.PanelOptions_Main.Controls.Add(Me.ComboBoxOptions_PostPeriodStart)
            Me.PanelOptions_Main.Controls.Add(Me.LabelOptions_PostPeriodEnd)
            Me.PanelOptions_Main.Controls.Add(Me.ComboBoxOptions_PostPeriodEnd)
            Me.PanelOptions_Main.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelOptions_Main.Location = New System.Drawing.Point(267, 1)
            Me.PanelOptions_Main.Name = "PanelOptions_Main"
            Me.PanelOptions_Main.Size = New System.Drawing.Size(522, 313)
            Me.PanelOptions_Main.TabIndex = 29
            '
            'ComboBoxOptions_RecordSource
            '
            Me.ComboBoxOptions_RecordSource.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxOptions_RecordSource.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxOptions_RecordSource.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxOptions_RecordSource.AutoFindItemInDataSource = False
            Me.ComboBoxOptions_RecordSource.AutoSelectSingleItemDatasource = False
            Me.ComboBoxOptions_RecordSource.BookmarkingEnabled = False
            Me.ComboBoxOptions_RecordSource.ClientCode = ""
            Me.ComboBoxOptions_RecordSource.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.RecordSource
            Me.ComboBoxOptions_RecordSource.DisableMouseWheel = False
            Me.ComboBoxOptions_RecordSource.DisplayMember = "Name"
            Me.ComboBoxOptions_RecordSource.DisplayName = ""
            Me.ComboBoxOptions_RecordSource.DivisionCode = ""
            Me.ComboBoxOptions_RecordSource.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxOptions_RecordSource.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxOptions_RecordSource.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxOptions_RecordSource.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxOptions_RecordSource.FocusHighlightEnabled = True
            Me.ComboBoxOptions_RecordSource.FormattingEnabled = True
            Me.ComboBoxOptions_RecordSource.ItemHeight = 15
            Me.ComboBoxOptions_RecordSource.Location = New System.Drawing.Point(124, 56)
            Me.ComboBoxOptions_RecordSource.Name = "ComboBoxOptions_RecordSource"
            Me.ComboBoxOptions_RecordSource.ReadOnly = False
            Me.ComboBoxOptions_RecordSource.SecurityEnabled = True
            Me.ComboBoxOptions_RecordSource.Size = New System.Drawing.Size(201, 21)
            Me.ComboBoxOptions_RecordSource.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxOptions_RecordSource.TabIndex = 26
            Me.ComboBoxOptions_RecordSource.TabOnEnter = True
            Me.ComboBoxOptions_RecordSource.ValueMember = "ID"
            Me.ComboBoxOptions_RecordSource.WatermarkText = "Select Record Source"
            '
            'ButtonOptions_2Years
            '
            Me.ButtonOptions_2Years.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonOptions_2Years.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonOptions_2Years.Location = New System.Drawing.Point(412, 30)
            Me.ButtonOptions_2Years.Name = "ButtonOptions_2Years"
            Me.ButtonOptions_2Years.SecurityEnabled = True
            Me.ButtonOptions_2Years.Size = New System.Drawing.Size(75, 20)
            Me.ButtonOptions_2Years.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonOptions_2Years.TabIndex = 25
            Me.ButtonOptions_2Years.Text = "2 Years"
            '
            'ButtonOptions_1Year
            '
            Me.ButtonOptions_1Year.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonOptions_1Year.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonOptions_1Year.Location = New System.Drawing.Point(412, 4)
            Me.ButtonOptions_1Year.Name = "ButtonOptions_1Year"
            Me.ButtonOptions_1Year.SecurityEnabled = True
            Me.ButtonOptions_1Year.Size = New System.Drawing.Size(75, 20)
            Me.ButtonOptions_1Year.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonOptions_1Year.TabIndex = 23
            Me.ButtonOptions_1Year.Text = "1 Year"
            '
            'ButtonOptions_MTD
            '
            Me.ButtonOptions_MTD.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonOptions_MTD.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonOptions_MTD.Location = New System.Drawing.Point(331, 30)
            Me.ButtonOptions_MTD.Name = "ButtonOptions_MTD"
            Me.ButtonOptions_MTD.SecurityEnabled = True
            Me.ButtonOptions_MTD.Size = New System.Drawing.Size(75, 20)
            Me.ButtonOptions_MTD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonOptions_MTD.TabIndex = 24
            Me.ButtonOptions_MTD.Text = "MTD"
            '
            'ButtonOptions_YTD
            '
            Me.ButtonOptions_YTD.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonOptions_YTD.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonOptions_YTD.Location = New System.Drawing.Point(331, 4)
            Me.ButtonOptions_YTD.Name = "ButtonOptions_YTD"
            Me.ButtonOptions_YTD.SecurityEnabled = True
            Me.ButtonOptions_YTD.Size = New System.Drawing.Size(75, 20)
            Me.ButtonOptions_YTD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonOptions_YTD.TabIndex = 22
            Me.ButtonOptions_YTD.Text = "YTD"
            '
            'LabelOptions_RecordSource
            '
            Me.LabelOptions_RecordSource.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelOptions_RecordSource.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelOptions_RecordSource.Location = New System.Drawing.Point(4, 56)
            Me.LabelOptions_RecordSource.Name = "LabelOptions_RecordSource"
            Me.LabelOptions_RecordSource.Size = New System.Drawing.Size(114, 20)
            Me.LabelOptions_RecordSource.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOptions_RecordSource.TabIndex = 20
            Me.LabelOptions_RecordSource.Text = "Record Source:"
            '
            'LabelOptions_PostPeriodStart
            '
            Me.LabelOptions_PostPeriodStart.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelOptions_PostPeriodStart.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelOptions_PostPeriodStart.Location = New System.Drawing.Point(4, 4)
            Me.LabelOptions_PostPeriodStart.Name = "LabelOptions_PostPeriodStart"
            Me.LabelOptions_PostPeriodStart.Size = New System.Drawing.Size(114, 20)
            Me.LabelOptions_PostPeriodStart.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOptions_PostPeriodStart.TabIndex = 0
            Me.LabelOptions_PostPeriodStart.Text = "Starting Post Period:"
            '
            'ComboBoxOptions_PostPeriodStart
            '
            Me.ComboBoxOptions_PostPeriodStart.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxOptions_PostPeriodStart.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxOptions_PostPeriodStart.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxOptions_PostPeriodStart.AutoFindItemInDataSource = False
            Me.ComboBoxOptions_PostPeriodStart.AutoSelectSingleItemDatasource = False
            Me.ComboBoxOptions_PostPeriodStart.BookmarkingEnabled = False
            Me.ComboBoxOptions_PostPeriodStart.ClientCode = ""
            Me.ComboBoxOptions_PostPeriodStart.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.PostPeriod
            Me.ComboBoxOptions_PostPeriodStart.DisableMouseWheel = False
            Me.ComboBoxOptions_PostPeriodStart.DisplayMember = "Description"
            Me.ComboBoxOptions_PostPeriodStart.DisplayName = ""
            Me.ComboBoxOptions_PostPeriodStart.DivisionCode = ""
            Me.ComboBoxOptions_PostPeriodStart.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxOptions_PostPeriodStart.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxOptions_PostPeriodStart.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxOptions_PostPeriodStart.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxOptions_PostPeriodStart.FocusHighlightEnabled = True
            Me.ComboBoxOptions_PostPeriodStart.FormattingEnabled = True
            Me.ComboBoxOptions_PostPeriodStart.ItemHeight = 15
            Me.ComboBoxOptions_PostPeriodStart.Location = New System.Drawing.Point(124, 4)
            Me.ComboBoxOptions_PostPeriodStart.Name = "ComboBoxOptions_PostPeriodStart"
            Me.ComboBoxOptions_PostPeriodStart.ReadOnly = False
            Me.ComboBoxOptions_PostPeriodStart.SecurityEnabled = True
            Me.ComboBoxOptions_PostPeriodStart.Size = New System.Drawing.Size(201, 21)
            Me.ComboBoxOptions_PostPeriodStart.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxOptions_PostPeriodStart.TabIndex = 1
            Me.ComboBoxOptions_PostPeriodStart.TabOnEnter = True
            Me.ComboBoxOptions_PostPeriodStart.ValueMember = "Code"
            Me.ComboBoxOptions_PostPeriodStart.WatermarkText = "Select Post Period"
            '
            'LabelOptions_PostPeriodEnd
            '
            Me.LabelOptions_PostPeriodEnd.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelOptions_PostPeriodEnd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelOptions_PostPeriodEnd.Location = New System.Drawing.Point(4, 30)
            Me.LabelOptions_PostPeriodEnd.Name = "LabelOptions_PostPeriodEnd"
            Me.LabelOptions_PostPeriodEnd.Size = New System.Drawing.Size(114, 20)
            Me.LabelOptions_PostPeriodEnd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOptions_PostPeriodEnd.TabIndex = 2
            Me.LabelOptions_PostPeriodEnd.Text = "Ending Post Period:"
            '
            'ComboBoxOptions_PostPeriodEnd
            '
            Me.ComboBoxOptions_PostPeriodEnd.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxOptions_PostPeriodEnd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxOptions_PostPeriodEnd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxOptions_PostPeriodEnd.AutoFindItemInDataSource = False
            Me.ComboBoxOptions_PostPeriodEnd.AutoSelectSingleItemDatasource = False
            Me.ComboBoxOptions_PostPeriodEnd.BookmarkingEnabled = False
            Me.ComboBoxOptions_PostPeriodEnd.ClientCode = ""
            Me.ComboBoxOptions_PostPeriodEnd.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.PostPeriod
            Me.ComboBoxOptions_PostPeriodEnd.DisableMouseWheel = False
            Me.ComboBoxOptions_PostPeriodEnd.DisplayMember = "Description"
            Me.ComboBoxOptions_PostPeriodEnd.DisplayName = ""
            Me.ComboBoxOptions_PostPeriodEnd.DivisionCode = ""
            Me.ComboBoxOptions_PostPeriodEnd.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxOptions_PostPeriodEnd.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxOptions_PostPeriodEnd.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxOptions_PostPeriodEnd.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxOptions_PostPeriodEnd.FocusHighlightEnabled = True
            Me.ComboBoxOptions_PostPeriodEnd.FormattingEnabled = True
            Me.ComboBoxOptions_PostPeriodEnd.ItemHeight = 15
            Me.ComboBoxOptions_PostPeriodEnd.Location = New System.Drawing.Point(124, 30)
            Me.ComboBoxOptions_PostPeriodEnd.Name = "ComboBoxOptions_PostPeriodEnd"
            Me.ComboBoxOptions_PostPeriodEnd.ReadOnly = False
            Me.ComboBoxOptions_PostPeriodEnd.SecurityEnabled = True
            Me.ComboBoxOptions_PostPeriodEnd.Size = New System.Drawing.Size(201, 21)
            Me.ComboBoxOptions_PostPeriodEnd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxOptions_PostPeriodEnd.TabIndex = 3
            Me.ComboBoxOptions_PostPeriodEnd.TabOnEnter = True
            Me.ComboBoxOptions_PostPeriodEnd.ValueMember = "Code"
            Me.ComboBoxOptions_PostPeriodEnd.WatermarkText = "Select Post Period"
            '
            'PanelOptions_Left
            '
            Me.PanelOptions_Left.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelOptions_Left.Appearance.Options.UseBackColor = True
            Me.PanelOptions_Left.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelOptions_Left.Controls.Add(Me.LabelOptions_Report)
            Me.PanelOptions_Left.Controls.Add(Me.ListBoxOptions_Reports)
            Me.PanelOptions_Left.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelOptions_Left.Location = New System.Drawing.Point(1, 1)
            Me.PanelOptions_Left.Name = "PanelOptions_Left"
            Me.PanelOptions_Left.Size = New System.Drawing.Size(266, 313)
            Me.PanelOptions_Left.TabIndex = 28
            '
            'LabelOptions_Report
            '
            Me.LabelOptions_Report.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelOptions_Report.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelOptions_Report.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelOptions_Report.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelOptions_Report.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelOptions_Report.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelOptions_Report.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelOptions_Report.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelOptions_Report.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelOptions_Report.Location = New System.Drawing.Point(4, 4)
            Me.LabelOptions_Report.Name = "LabelOptions_Report"
            Me.LabelOptions_Report.Size = New System.Drawing.Size(262, 20)
            Me.LabelOptions_Report.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOptions_Report.TabIndex = 0
            Me.LabelOptions_Report.Text = "Report Formats"
            '
            'ListBoxOptions_Reports
            '
            Me.ListBoxOptions_Reports.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ListBox.Type.Report
            Me.ListBoxOptions_Reports.DisplayMember = "Description"
            Me.ListBoxOptions_Reports.ExtraListBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ListBox.ExtraListBoxItems.[Nothing]
            Me.ListBoxOptions_Reports.ExtraListBoxItemDisplayText = Nothing
            Me.ListBoxOptions_Reports.ExtraListBoxItemValueObject = Nothing
            Me.ListBoxOptions_Reports.Location = New System.Drawing.Point(4, 30)
            Me.ListBoxOptions_Reports.Name = "ListBoxOptions_Reports"
            Me.ListBoxOptions_Reports.Size = New System.Drawing.Size(262, 103)
            Me.ListBoxOptions_Reports.TabIndex = 1
            Me.ListBoxOptions_Reports.ValueMember = "Code"
            '
            'TabItemOptionsPresets_OptionsTab
            '
            Me.TabItemOptionsPresets_OptionsTab.AttachedControl = Me.TabControlPanelOptionsTab_Options
            Me.TabItemOptionsPresets_OptionsTab.Name = "TabItemOptionsPresets_OptionsTab"
            Me.TabItemOptionsPresets_OptionsTab.Text = "Options"
            '
            'TabControlPanelTypesTab_Types
            '
            Me.TabControlPanelTypesTab_Types.Controls.Add(Me.PanelTypes_Types)
            Me.TabControlPanelTypesTab_Types.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelTypesTab_Types.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelTypesTab_Types.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelTypesTab_Types.Name = "TabControlPanelTypesTab_Types"
            Me.TabControlPanelTypesTab_Types.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelTypesTab_Types.Size = New System.Drawing.Size(790, 315)
            Me.TabControlPanelTypesTab_Types.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelTypesTab_Types.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelTypesTab_Types.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelTypesTab_Types.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelTypesTab_Types.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelTypesTab_Types.Style.GradientAngle = 90
            Me.TabControlPanelTypesTab_Types.TabIndex = 3
            Me.TabControlPanelTypesTab_Types.TabItem = Me.TabItemReportTemplatePresets_TypesTab
            '
            'PanelTypes_Types
            '
            Me.PanelTypes_Types.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelTypes_Types.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelTypes_Types.Appearance.Options.UseBackColor = True
            Me.PanelTypes_Types.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelTypes_Types.Controls.Add(Me.PanelTypes_RightSection)
            Me.PanelTypes_Types.Controls.Add(Me.ExpandableSplitterControl3)
            Me.PanelTypes_Types.Controls.Add(Me.PanelTypes_LeftSection)
            Me.PanelTypes_Types.Location = New System.Drawing.Point(4, 4)
            Me.PanelTypes_Types.Name = "PanelTypes_Types"
            Me.PanelTypes_Types.Size = New System.Drawing.Size(782, 307)
            Me.PanelTypes_Types.TabIndex = 2
            '
            'PanelTypes_RightSection
            '
            Me.PanelTypes_RightSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelTypes_RightSection.Appearance.Options.UseBackColor = True
            Me.PanelTypes_RightSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelTypes_RightSection.Controls.Add(Me.ButtonTypesRightSection_Add)
            Me.PanelTypes_RightSection.Controls.Add(Me.ButtonTypesRightSection_AddAll)
            Me.PanelTypes_RightSection.Controls.Add(Me.ButtonTypesRightSection_RemoveAll)
            Me.PanelTypes_RightSection.Controls.Add(Me.ButtonTypesRightSection_Remove)
            Me.PanelTypes_RightSection.Controls.Add(Me.DataGridViewRightSection_SelectedTypes)
            Me.PanelTypes_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelTypes_RightSection.Location = New System.Drawing.Point(309, 0)
            Me.PanelTypes_RightSection.Name = "PanelTypes_RightSection"
            Me.PanelTypes_RightSection.Size = New System.Drawing.Size(473, 307)
            Me.PanelTypes_RightSection.TabIndex = 2
            '
            'ButtonTypesRightSection_Add
            '
            Me.ButtonTypesRightSection_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonTypesRightSection_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonTypesRightSection_Add.Location = New System.Drawing.Point(6, 0)
            Me.ButtonTypesRightSection_Add.Name = "ButtonTypesRightSection_Add"
            Me.ButtonTypesRightSection_Add.SecurityEnabled = True
            Me.ButtonTypesRightSection_Add.Size = New System.Drawing.Size(75, 20)
            Me.ButtonTypesRightSection_Add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonTypesRightSection_Add.TabIndex = 0
            Me.ButtonTypesRightSection_Add.Text = ">"
            '
            'ButtonTypesRightSection_AddAll
            '
            Me.ButtonTypesRightSection_AddAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonTypesRightSection_AddAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonTypesRightSection_AddAll.Location = New System.Drawing.Point(6, 26)
            Me.ButtonTypesRightSection_AddAll.Name = "ButtonTypesRightSection_AddAll"
            Me.ButtonTypesRightSection_AddAll.SecurityEnabled = True
            Me.ButtonTypesRightSection_AddAll.Size = New System.Drawing.Size(75, 20)
            Me.ButtonTypesRightSection_AddAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonTypesRightSection_AddAll.TabIndex = 1
            Me.ButtonTypesRightSection_AddAll.Text = ">>"
            '
            'ButtonTypesRightSection_RemoveAll
            '
            Me.ButtonTypesRightSection_RemoveAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonTypesRightSection_RemoveAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonTypesRightSection_RemoveAll.Location = New System.Drawing.Point(6, 78)
            Me.ButtonTypesRightSection_RemoveAll.Name = "ButtonTypesRightSection_RemoveAll"
            Me.ButtonTypesRightSection_RemoveAll.SecurityEnabled = True
            Me.ButtonTypesRightSection_RemoveAll.Size = New System.Drawing.Size(75, 20)
            Me.ButtonTypesRightSection_RemoveAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonTypesRightSection_RemoveAll.TabIndex = 3
            Me.ButtonTypesRightSection_RemoveAll.Text = "<<"
            '
            'ButtonTypesRightSection_Remove
            '
            Me.ButtonTypesRightSection_Remove.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonTypesRightSection_Remove.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonTypesRightSection_Remove.Location = New System.Drawing.Point(6, 52)
            Me.ButtonTypesRightSection_Remove.Name = "ButtonTypesRightSection_Remove"
            Me.ButtonTypesRightSection_Remove.SecurityEnabled = True
            Me.ButtonTypesRightSection_Remove.Size = New System.Drawing.Size(75, 20)
            Me.ButtonTypesRightSection_Remove.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonTypesRightSection_Remove.TabIndex = 2
            Me.ButtonTypesRightSection_Remove.Text = "<"
            '
            'DataGridViewRightSection_SelectedTypes
            '
            Me.DataGridViewRightSection_SelectedTypes.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewRightSection_SelectedTypes.AllowDragAndDrop = False
            Me.DataGridViewRightSection_SelectedTypes.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewRightSection_SelectedTypes.AllowSelectGroupHeaderRow = True
            Me.DataGridViewRightSection_SelectedTypes.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewRightSection_SelectedTypes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRightSection_SelectedTypes.AutoFilterLookupColumns = False
            Me.DataGridViewRightSection_SelectedTypes.AutoloadRepositoryDatasource = True
            Me.DataGridViewRightSection_SelectedTypes.AutoUpdateViewCaption = True
            Me.DataGridViewRightSection_SelectedTypes.BackColor = System.Drawing.Color.White
            Me.DataGridViewRightSection_SelectedTypes.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewRightSection_SelectedTypes.DataSource = Nothing
            Me.DataGridViewRightSection_SelectedTypes.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewRightSection_SelectedTypes.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRightSection_SelectedTypes.ItemDescription = ""
            Me.DataGridViewRightSection_SelectedTypes.Location = New System.Drawing.Point(87, 0)
            Me.DataGridViewRightSection_SelectedTypes.MultiSelect = True
            Me.DataGridViewRightSection_SelectedTypes.Name = "DataGridViewRightSection_SelectedTypes"
            Me.DataGridViewRightSection_SelectedTypes.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewRightSection_SelectedTypes.RunStandardValidation = True
            Me.DataGridViewRightSection_SelectedTypes.ShowColumnMenuOnRightClick = False
            Me.DataGridViewRightSection_SelectedTypes.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRightSection_SelectedTypes.Size = New System.Drawing.Size(386, 307)
            Me.DataGridViewRightSection_SelectedTypes.TabIndex = 4
            Me.DataGridViewRightSection_SelectedTypes.UseEmbeddedNavigator = False
            Me.DataGridViewRightSection_SelectedTypes.ViewCaptionHeight = -1
            '
            'ExpandableSplitterControl3
            '
            Me.ExpandableSplitterControl3.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl3.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl3.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControl3.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl3.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl3.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControl3.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControl3.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControl3.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControl3.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControl3.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControl3.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControl3.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControl3.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControl3.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControl3.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl3.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl3.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControl3.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControl3.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl3.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl3.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControl3.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControl3.Location = New System.Drawing.Point(303, 0)
            Me.ExpandableSplitterControl3.Name = "ExpandableSplitterControl3"
            Me.ExpandableSplitterControl3.Size = New System.Drawing.Size(6, 307)
            Me.ExpandableSplitterControl3.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControl3.TabIndex = 1
            Me.ExpandableSplitterControl3.TabStop = False
            '
            'PanelTypes_LeftSection
            '
            Me.PanelTypes_LeftSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelTypes_LeftSection.Appearance.Options.UseBackColor = True
            Me.PanelTypes_LeftSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelTypes_LeftSection.Controls.Add(Me.DataGridViewLeftSection_AvailableTypes)
            Me.PanelTypes_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelTypes_LeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelTypes_LeftSection.Name = "PanelTypes_LeftSection"
            Me.PanelTypes_LeftSection.Size = New System.Drawing.Size(303, 307)
            Me.PanelTypes_LeftSection.TabIndex = 0
            '
            'DataGridViewLeftSection_AvailableTypes
            '
            Me.DataGridViewLeftSection_AvailableTypes.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewLeftSection_AvailableTypes.AllowDragAndDrop = False
            Me.DataGridViewLeftSection_AvailableTypes.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewLeftSection_AvailableTypes.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_AvailableTypes.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_AvailableTypes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_AvailableTypes.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_AvailableTypes.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_AvailableTypes.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_AvailableTypes.BackColor = System.Drawing.Color.White
            Me.DataGridViewLeftSection_AvailableTypes.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_AvailableTypes.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_AvailableTypes.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_AvailableTypes.ItemDescription = ""
            Me.DataGridViewLeftSection_AvailableTypes.Location = New System.Drawing.Point(0, 0)
            Me.DataGridViewLeftSection_AvailableTypes.MultiSelect = True
            Me.DataGridViewLeftSection_AvailableTypes.Name = "DataGridViewLeftSection_AvailableTypes"
            Me.DataGridViewLeftSection_AvailableTypes.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_AvailableTypes.RunStandardValidation = True
            Me.DataGridViewLeftSection_AvailableTypes.ShowColumnMenuOnRightClick = False
            Me.DataGridViewLeftSection_AvailableTypes.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_AvailableTypes.Size = New System.Drawing.Size(297, 307)
            Me.DataGridViewLeftSection_AvailableTypes.TabIndex = 0
            Me.DataGridViewLeftSection_AvailableTypes.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_AvailableTypes.ViewCaptionHeight = -1
            '
            'TabItemReportTemplatePresets_TypesTab
            '
            Me.TabItemReportTemplatePresets_TypesTab.AttachedControl = Me.TabControlPanelTypesTab_Types
            Me.TabItemReportTemplatePresets_TypesTab.Name = "TabItemReportTemplatePresets_TypesTab"
            Me.TabItemReportTemplatePresets_TypesTab.Text = "Types"
            '
            'TabControlPanelOtherTab_Other
            '
            Me.TabControlPanelOtherTab_Other.Controls.Add(Me.PanelOther_Other)
            Me.TabControlPanelOtherTab_Other.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelOtherTab_Other.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelOtherTab_Other.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelOtherTab_Other.Name = "TabControlPanelOtherTab_Other"
            Me.TabControlPanelOtherTab_Other.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelOtherTab_Other.Size = New System.Drawing.Size(790, 315)
            Me.TabControlPanelOtherTab_Other.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelOtherTab_Other.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelOtherTab_Other.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelOtherTab_Other.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelOtherTab_Other.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelOtherTab_Other.Style.GradientAngle = 90
            Me.TabControlPanelOtherTab_Other.TabIndex = 1
            Me.TabControlPanelOtherTab_Other.TabItem = Me.TabItemReportTemplatePresets_OtherTab
            '
            'PanelOther_Other
            '
            Me.PanelOther_Other.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelOther_Other.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelOther_Other.Appearance.Options.UseBackColor = True
            Me.PanelOther_Other.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelOther_Other.Controls.Add(Me.PanelOther_OtherRightSection)
            Me.PanelOther_Other.Controls.Add(Me.ExpandableSplitterControl2)
            Me.PanelOther_Other.Controls.Add(Me.PanelOther_OtherLeftSection)
            Me.PanelOther_Other.Location = New System.Drawing.Point(4, 4)
            Me.PanelOther_Other.Name = "PanelOther_Other"
            Me.PanelOther_Other.Size = New System.Drawing.Size(782, 307)
            Me.PanelOther_Other.TabIndex = 1
            '
            'PanelOther_OtherRightSection
            '
            Me.PanelOther_OtherRightSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelOther_OtherRightSection.Appearance.Options.UseBackColor = True
            Me.PanelOther_OtherRightSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelOther_OtherRightSection.Controls.Add(Me.ButtonOtherRightSection_Add)
            Me.PanelOther_OtherRightSection.Controls.Add(Me.ButtonOtherRightSection_AddAll)
            Me.PanelOther_OtherRightSection.Controls.Add(Me.ButtonOtherRightSection_RemoveAll)
            Me.PanelOther_OtherRightSection.Controls.Add(Me.ButtonOtherRightSection_Remove)
            Me.PanelOther_OtherRightSection.Controls.Add(Me.DataGridViewOtherRightSection_Other)
            Me.PanelOther_OtherRightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelOther_OtherRightSection.Location = New System.Drawing.Point(309, 0)
            Me.PanelOther_OtherRightSection.Name = "PanelOther_OtherRightSection"
            Me.PanelOther_OtherRightSection.Size = New System.Drawing.Size(473, 307)
            Me.PanelOther_OtherRightSection.TabIndex = 2
            '
            'ButtonOtherRightSection_Add
            '
            Me.ButtonOtherRightSection_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonOtherRightSection_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonOtherRightSection_Add.Location = New System.Drawing.Point(6, 0)
            Me.ButtonOtherRightSection_Add.Name = "ButtonOtherRightSection_Add"
            Me.ButtonOtherRightSection_Add.SecurityEnabled = True
            Me.ButtonOtherRightSection_Add.Size = New System.Drawing.Size(75, 20)
            Me.ButtonOtherRightSection_Add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonOtherRightSection_Add.TabIndex = 0
            Me.ButtonOtherRightSection_Add.Text = ">"
            '
            'ButtonOtherRightSection_AddAll
            '
            Me.ButtonOtherRightSection_AddAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonOtherRightSection_AddAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonOtherRightSection_AddAll.Location = New System.Drawing.Point(6, 26)
            Me.ButtonOtherRightSection_AddAll.Name = "ButtonOtherRightSection_AddAll"
            Me.ButtonOtherRightSection_AddAll.SecurityEnabled = True
            Me.ButtonOtherRightSection_AddAll.Size = New System.Drawing.Size(75, 20)
            Me.ButtonOtherRightSection_AddAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonOtherRightSection_AddAll.TabIndex = 1
            Me.ButtonOtherRightSection_AddAll.Text = ">>"
            '
            'ButtonOtherRightSection_RemoveAll
            '
            Me.ButtonOtherRightSection_RemoveAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonOtherRightSection_RemoveAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonOtherRightSection_RemoveAll.Location = New System.Drawing.Point(6, 78)
            Me.ButtonOtherRightSection_RemoveAll.Name = "ButtonOtherRightSection_RemoveAll"
            Me.ButtonOtherRightSection_RemoveAll.SecurityEnabled = True
            Me.ButtonOtherRightSection_RemoveAll.Size = New System.Drawing.Size(75, 20)
            Me.ButtonOtherRightSection_RemoveAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonOtherRightSection_RemoveAll.TabIndex = 3
            Me.ButtonOtherRightSection_RemoveAll.Text = "<<"
            '
            'ButtonOtherRightSection_Remove
            '
            Me.ButtonOtherRightSection_Remove.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonOtherRightSection_Remove.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonOtherRightSection_Remove.Location = New System.Drawing.Point(6, 52)
            Me.ButtonOtherRightSection_Remove.Name = "ButtonOtherRightSection_Remove"
            Me.ButtonOtherRightSection_Remove.SecurityEnabled = True
            Me.ButtonOtherRightSection_Remove.Size = New System.Drawing.Size(75, 20)
            Me.ButtonOtherRightSection_Remove.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonOtherRightSection_Remove.TabIndex = 2
            Me.ButtonOtherRightSection_Remove.Text = "<"
            '
            'DataGridViewOtherRightSection_Other
            '
            Me.DataGridViewOtherRightSection_Other.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewOtherRightSection_Other.AllowDragAndDrop = False
            Me.DataGridViewOtherRightSection_Other.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewOtherRightSection_Other.AllowSelectGroupHeaderRow = True
            Me.DataGridViewOtherRightSection_Other.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewOtherRightSection_Other.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewOtherRightSection_Other.AutoFilterLookupColumns = False
            Me.DataGridViewOtherRightSection_Other.AutoloadRepositoryDatasource = True
            Me.DataGridViewOtherRightSection_Other.AutoUpdateViewCaption = True
            Me.DataGridViewOtherRightSection_Other.BackColor = System.Drawing.Color.White
            Me.DataGridViewOtherRightSection_Other.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewOtherRightSection_Other.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewOtherRightSection_Other.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewOtherRightSection_Other.ItemDescription = ""
            Me.DataGridViewOtherRightSection_Other.Location = New System.Drawing.Point(87, 0)
            Me.DataGridViewOtherRightSection_Other.MultiSelect = True
            Me.DataGridViewOtherRightSection_Other.Name = "DataGridViewOtherRightSection_Other"
            Me.DataGridViewOtherRightSection_Other.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewOtherRightSection_Other.RunStandardValidation = True
            Me.DataGridViewOtherRightSection_Other.ShowColumnMenuOnRightClick = False
            Me.DataGridViewOtherRightSection_Other.ShowSelectDeselectAllButtons = False
            Me.DataGridViewOtherRightSection_Other.Size = New System.Drawing.Size(386, 307)
            Me.DataGridViewOtherRightSection_Other.TabIndex = 4
            Me.DataGridViewOtherRightSection_Other.UseEmbeddedNavigator = False
            Me.DataGridViewOtherRightSection_Other.ViewCaptionHeight = -1
            '
            'ExpandableSplitterControl2
            '
            Me.ExpandableSplitterControl2.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl2.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl2.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControl2.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl2.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl2.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControl2.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControl2.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControl2.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControl2.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControl2.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControl2.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControl2.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControl2.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControl2.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControl2.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl2.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl2.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControl2.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControl2.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl2.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl2.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControl2.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControl2.Location = New System.Drawing.Point(303, 0)
            Me.ExpandableSplitterControl2.Name = "ExpandableSplitterControl2"
            Me.ExpandableSplitterControl2.Size = New System.Drawing.Size(6, 307)
            Me.ExpandableSplitterControl2.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControl2.TabIndex = 1
            Me.ExpandableSplitterControl2.TabStop = False
            '
            'PanelOther_OtherLeftSection
            '
            Me.PanelOther_OtherLeftSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelOther_OtherLeftSection.Appearance.Options.UseBackColor = True
            Me.PanelOther_OtherLeftSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelOther_OtherLeftSection.Controls.Add(Me.DataGridViewOtherLeftSection_Other)
            Me.PanelOther_OtherLeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelOther_OtherLeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelOther_OtherLeftSection.Name = "PanelOther_OtherLeftSection"
            Me.PanelOther_OtherLeftSection.Size = New System.Drawing.Size(303, 307)
            Me.PanelOther_OtherLeftSection.TabIndex = 0
            '
            'DataGridViewOtherLeftSection_Other
            '
            Me.DataGridViewOtherLeftSection_Other.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewOtherLeftSection_Other.AllowDragAndDrop = False
            Me.DataGridViewOtherLeftSection_Other.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewOtherLeftSection_Other.AllowSelectGroupHeaderRow = True
            Me.DataGridViewOtherLeftSection_Other.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewOtherLeftSection_Other.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewOtherLeftSection_Other.AutoFilterLookupColumns = False
            Me.DataGridViewOtherLeftSection_Other.AutoloadRepositoryDatasource = True
            Me.DataGridViewOtherLeftSection_Other.AutoUpdateViewCaption = True
            Me.DataGridViewOtherLeftSection_Other.BackColor = System.Drawing.Color.White
            Me.DataGridViewOtherLeftSection_Other.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewOtherLeftSection_Other.DataSource = Nothing
            Me.DataGridViewOtherLeftSection_Other.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewOtherLeftSection_Other.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewOtherLeftSection_Other.ItemDescription = ""
            Me.DataGridViewOtherLeftSection_Other.Location = New System.Drawing.Point(0, 0)
            Me.DataGridViewOtherLeftSection_Other.MultiSelect = True
            Me.DataGridViewOtherLeftSection_Other.Name = "DataGridViewOtherLeftSection_Other"
            Me.DataGridViewOtherLeftSection_Other.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewOtherLeftSection_Other.RunStandardValidation = True
            Me.DataGridViewOtherLeftSection_Other.ShowColumnMenuOnRightClick = False
            Me.DataGridViewOtherLeftSection_Other.ShowSelectDeselectAllButtons = False
            Me.DataGridViewOtherLeftSection_Other.Size = New System.Drawing.Size(297, 307)
            Me.DataGridViewOtherLeftSection_Other.TabIndex = 0
            Me.DataGridViewOtherLeftSection_Other.UseEmbeddedNavigator = False
            Me.DataGridViewOtherLeftSection_Other.ViewCaptionHeight = -1
            '
            'TabItemReportTemplatePresets_OtherTab
            '
            Me.TabItemReportTemplatePresets_OtherTab.AttachedControl = Me.TabControlPanelOtherTab_Other
            Me.TabItemReportTemplatePresets_OtherTab.Name = "TabItemReportTemplatePresets_OtherTab"
            Me.TabItemReportTemplatePresets_OtherTab.Text = "Other"
            '
            'TabControlPanelBaseTab_Bae
            '
            Me.TabControlPanelBaseTab_Bae.Controls.Add(Me.PanelBase_Base)
            Me.TabControlPanelBaseTab_Bae.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelBaseTab_Bae.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelBaseTab_Bae.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelBaseTab_Bae.Name = "TabControlPanelBaseTab_Bae"
            Me.TabControlPanelBaseTab_Bae.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelBaseTab_Bae.Size = New System.Drawing.Size(790, 315)
            Me.TabControlPanelBaseTab_Bae.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelBaseTab_Bae.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelBaseTab_Bae.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelBaseTab_Bae.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelBaseTab_Bae.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelBaseTab_Bae.Style.GradientAngle = 90
            Me.TabControlPanelBaseTab_Bae.TabIndex = 2
            Me.TabControlPanelBaseTab_Bae.TabItem = Me.TabItemReportTemplatePresets_BaseTab
            '
            'PanelBase_Base
            '
            Me.PanelBase_Base.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelBase_Base.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelBase_Base.Appearance.Options.UseBackColor = True
            Me.PanelBase_Base.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelBase_Base.Controls.Add(Me.PanelBase_BaseRightSection)
            Me.PanelBase_Base.Controls.Add(Me.ExpandableSplitterControl1)
            Me.PanelBase_Base.Controls.Add(Me.PanelBase_BaseLeftSection)
            Me.PanelBase_Base.Location = New System.Drawing.Point(4, 4)
            Me.PanelBase_Base.Name = "PanelBase_Base"
            Me.PanelBase_Base.Size = New System.Drawing.Size(782, 307)
            Me.PanelBase_Base.TabIndex = 1
            '
            'PanelBase_BaseRightSection
            '
            Me.PanelBase_BaseRightSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelBase_BaseRightSection.Appearance.Options.UseBackColor = True
            Me.PanelBase_BaseRightSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelBase_BaseRightSection.Controls.Add(Me.ButtonBaseRightSection_Add)
            Me.PanelBase_BaseRightSection.Controls.Add(Me.ButtonBaseRightSection_AddAll)
            Me.PanelBase_BaseRightSection.Controls.Add(Me.ButtonBaseRightSection_RemoveAll)
            Me.PanelBase_BaseRightSection.Controls.Add(Me.ButtonBaseRightSection_Remove)
            Me.PanelBase_BaseRightSection.Controls.Add(Me.DataGridViewBaseRightSection_Base)
            Me.PanelBase_BaseRightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelBase_BaseRightSection.Location = New System.Drawing.Point(309, 0)
            Me.PanelBase_BaseRightSection.Name = "PanelBase_BaseRightSection"
            Me.PanelBase_BaseRightSection.Size = New System.Drawing.Size(473, 307)
            Me.PanelBase_BaseRightSection.TabIndex = 2
            '
            'ButtonBaseRightSection_Add
            '
            Me.ButtonBaseRightSection_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonBaseRightSection_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonBaseRightSection_Add.Location = New System.Drawing.Point(6, 0)
            Me.ButtonBaseRightSection_Add.Name = "ButtonBaseRightSection_Add"
            Me.ButtonBaseRightSection_Add.SecurityEnabled = True
            Me.ButtonBaseRightSection_Add.Size = New System.Drawing.Size(75, 20)
            Me.ButtonBaseRightSection_Add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonBaseRightSection_Add.TabIndex = 0
            Me.ButtonBaseRightSection_Add.Text = ">"
            '
            'ButtonBaseRightSection_AddAll
            '
            Me.ButtonBaseRightSection_AddAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonBaseRightSection_AddAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonBaseRightSection_AddAll.Location = New System.Drawing.Point(6, 26)
            Me.ButtonBaseRightSection_AddAll.Name = "ButtonBaseRightSection_AddAll"
            Me.ButtonBaseRightSection_AddAll.SecurityEnabled = True
            Me.ButtonBaseRightSection_AddAll.Size = New System.Drawing.Size(75, 20)
            Me.ButtonBaseRightSection_AddAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonBaseRightSection_AddAll.TabIndex = 1
            Me.ButtonBaseRightSection_AddAll.Text = ">>"
            '
            'ButtonBaseRightSection_RemoveAll
            '
            Me.ButtonBaseRightSection_RemoveAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonBaseRightSection_RemoveAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonBaseRightSection_RemoveAll.Location = New System.Drawing.Point(6, 78)
            Me.ButtonBaseRightSection_RemoveAll.Name = "ButtonBaseRightSection_RemoveAll"
            Me.ButtonBaseRightSection_RemoveAll.SecurityEnabled = True
            Me.ButtonBaseRightSection_RemoveAll.Size = New System.Drawing.Size(75, 20)
            Me.ButtonBaseRightSection_RemoveAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonBaseRightSection_RemoveAll.TabIndex = 3
            Me.ButtonBaseRightSection_RemoveAll.Text = "<<"
            '
            'ButtonBaseRightSection_Remove
            '
            Me.ButtonBaseRightSection_Remove.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonBaseRightSection_Remove.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonBaseRightSection_Remove.Location = New System.Drawing.Point(6, 52)
            Me.ButtonBaseRightSection_Remove.Name = "ButtonBaseRightSection_Remove"
            Me.ButtonBaseRightSection_Remove.SecurityEnabled = True
            Me.ButtonBaseRightSection_Remove.Size = New System.Drawing.Size(75, 20)
            Me.ButtonBaseRightSection_Remove.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonBaseRightSection_Remove.TabIndex = 2
            Me.ButtonBaseRightSection_Remove.Text = "<"
            '
            'DataGridViewBaseRightSection_Base
            '
            Me.DataGridViewBaseRightSection_Base.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewBaseRightSection_Base.AllowDragAndDrop = False
            Me.DataGridViewBaseRightSection_Base.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewBaseRightSection_Base.AllowSelectGroupHeaderRow = True
            Me.DataGridViewBaseRightSection_Base.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewBaseRightSection_Base.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewBaseRightSection_Base.AutoFilterLookupColumns = False
            Me.DataGridViewBaseRightSection_Base.AutoloadRepositoryDatasource = True
            Me.DataGridViewBaseRightSection_Base.AutoUpdateViewCaption = True
            Me.DataGridViewBaseRightSection_Base.BackColor = System.Drawing.Color.White
            Me.DataGridViewBaseRightSection_Base.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewBaseRightSection_Base.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewBaseRightSection_Base.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewBaseRightSection_Base.ItemDescription = ""
            Me.DataGridViewBaseRightSection_Base.Location = New System.Drawing.Point(87, 0)
            Me.DataGridViewBaseRightSection_Base.MultiSelect = True
            Me.DataGridViewBaseRightSection_Base.Name = "DataGridViewBaseRightSection_Base"
            Me.DataGridViewBaseRightSection_Base.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewBaseRightSection_Base.RunStandardValidation = True
            Me.DataGridViewBaseRightSection_Base.ShowColumnMenuOnRightClick = False
            Me.DataGridViewBaseRightSection_Base.ShowSelectDeselectAllButtons = False
            Me.DataGridViewBaseRightSection_Base.Size = New System.Drawing.Size(386, 307)
            Me.DataGridViewBaseRightSection_Base.TabIndex = 4
            Me.DataGridViewBaseRightSection_Base.UseEmbeddedNavigator = False
            Me.DataGridViewBaseRightSection_Base.ViewCaptionHeight = -1
            '
            'ExpandableSplitterControl1
            '
            Me.ExpandableSplitterControl1.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControl1.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl1.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControl1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControl1.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControl1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControl1.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControl1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControl1.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControl1.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControl1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControl1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControl1.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl1.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControl1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControl1.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl1.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControl1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControl1.Location = New System.Drawing.Point(303, 0)
            Me.ExpandableSplitterControl1.Name = "ExpandableSplitterControl1"
            Me.ExpandableSplitterControl1.Size = New System.Drawing.Size(6, 307)
            Me.ExpandableSplitterControl1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControl1.TabIndex = 1
            Me.ExpandableSplitterControl1.TabStop = False
            '
            'PanelBase_BaseLeftSection
            '
            Me.PanelBase_BaseLeftSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelBase_BaseLeftSection.Appearance.Options.UseBackColor = True
            Me.PanelBase_BaseLeftSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelBase_BaseLeftSection.Controls.Add(Me.DataGridViewBaseLeftSection_Base)
            Me.PanelBase_BaseLeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelBase_BaseLeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelBase_BaseLeftSection.Name = "PanelBase_BaseLeftSection"
            Me.PanelBase_BaseLeftSection.Size = New System.Drawing.Size(303, 307)
            Me.PanelBase_BaseLeftSection.TabIndex = 0
            '
            'DataGridViewBaseLeftSection_Base
            '
            Me.DataGridViewBaseLeftSection_Base.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewBaseLeftSection_Base.AllowDragAndDrop = False
            Me.DataGridViewBaseLeftSection_Base.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewBaseLeftSection_Base.AllowSelectGroupHeaderRow = True
            Me.DataGridViewBaseLeftSection_Base.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewBaseLeftSection_Base.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewBaseLeftSection_Base.AutoFilterLookupColumns = False
            Me.DataGridViewBaseLeftSection_Base.AutoloadRepositoryDatasource = True
            Me.DataGridViewBaseLeftSection_Base.AutoUpdateViewCaption = True
            Me.DataGridViewBaseLeftSection_Base.BackColor = System.Drawing.Color.White
            Me.DataGridViewBaseLeftSection_Base.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewBaseLeftSection_Base.DataSource = Nothing
            Me.DataGridViewBaseLeftSection_Base.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewBaseLeftSection_Base.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewBaseLeftSection_Base.ItemDescription = ""
            Me.DataGridViewBaseLeftSection_Base.Location = New System.Drawing.Point(0, 0)
            Me.DataGridViewBaseLeftSection_Base.MultiSelect = True
            Me.DataGridViewBaseLeftSection_Base.Name = "DataGridViewBaseLeftSection_Base"
            Me.DataGridViewBaseLeftSection_Base.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewBaseLeftSection_Base.RunStandardValidation = True
            Me.DataGridViewBaseLeftSection_Base.ShowColumnMenuOnRightClick = False
            Me.DataGridViewBaseLeftSection_Base.ShowSelectDeselectAllButtons = False
            Me.DataGridViewBaseLeftSection_Base.Size = New System.Drawing.Size(297, 307)
            Me.DataGridViewBaseLeftSection_Base.TabIndex = 0
            Me.DataGridViewBaseLeftSection_Base.UseEmbeddedNavigator = False
            Me.DataGridViewBaseLeftSection_Base.ViewCaptionHeight = -1
            '
            'TabItemReportTemplatePresets_BaseTab
            '
            Me.TabItemReportTemplatePresets_BaseTab.AttachedControl = Me.TabControlPanelBaseTab_Bae
            Me.TabItemReportTemplatePresets_BaseTab.Name = "TabItemReportTemplatePresets_BaseTab"
            Me.TabItemReportTemplatePresets_BaseTab.Text = "Base"
            '
            'TabControlPanelOfficeTab_Office
            '
            Me.TabControlPanelOfficeTab_Office.Controls.Add(Me.PanelOffice_Office)
            Me.TabControlPanelOfficeTab_Office.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelOfficeTab_Office.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelOfficeTab_Office.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelOfficeTab_Office.Name = "TabControlPanelOfficeTab_Office"
            Me.TabControlPanelOfficeTab_Office.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelOfficeTab_Office.Size = New System.Drawing.Size(790, 315)
            Me.TabControlPanelOfficeTab_Office.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelOfficeTab_Office.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelOfficeTab_Office.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelOfficeTab_Office.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelOfficeTab_Office.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelOfficeTab_Office.Style.GradientAngle = 90
            Me.TabControlPanelOfficeTab_Office.TabIndex = 0
            Me.TabControlPanelOfficeTab_Office.TabItem = Me.TabItemReportTemplatePresets_OfficeTab
            '
            'PanelOffice_Office
            '
            Me.PanelOffice_Office.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelOffice_Office.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelOffice_Office.Appearance.Options.UseBackColor = True
            Me.PanelOffice_Office.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelOffice_Office.Controls.Add(Me.PanelOffice_OfficeRightSection)
            Me.PanelOffice_Office.Controls.Add(Me.ExpandableSplitterOffice_OfficeLeftRightSection)
            Me.PanelOffice_Office.Controls.Add(Me.PanelOffice_OfficeLeftSection)
            Me.PanelOffice_Office.Location = New System.Drawing.Point(4, 4)
            Me.PanelOffice_Office.Name = "PanelOffice_Office"
            Me.PanelOffice_Office.Size = New System.Drawing.Size(782, 307)
            Me.PanelOffice_Office.TabIndex = 0
            '
            'PanelOffice_OfficeRightSection
            '
            Me.PanelOffice_OfficeRightSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelOffice_OfficeRightSection.Appearance.Options.UseBackColor = True
            Me.PanelOffice_OfficeRightSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelOffice_OfficeRightSection.Controls.Add(Me.ButtonOfficeRightSection_Add)
            Me.PanelOffice_OfficeRightSection.Controls.Add(Me.ButtonOfficeRightSection_AddAll)
            Me.PanelOffice_OfficeRightSection.Controls.Add(Me.DataGridViewOfficeRightSection_Presets)
            Me.PanelOffice_OfficeRightSection.Controls.Add(Me.ButtonOfficeRightSection_Remove)
            Me.PanelOffice_OfficeRightSection.Controls.Add(Me.ButtonOfficeRightSection_RemoveAll)
            Me.PanelOffice_OfficeRightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelOffice_OfficeRightSection.Location = New System.Drawing.Point(309, 0)
            Me.PanelOffice_OfficeRightSection.Name = "PanelOffice_OfficeRightSection"
            Me.PanelOffice_OfficeRightSection.Size = New System.Drawing.Size(473, 307)
            Me.PanelOffice_OfficeRightSection.TabIndex = 2
            '
            'ButtonOfficeRightSection_Add
            '
            Me.ButtonOfficeRightSection_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonOfficeRightSection_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonOfficeRightSection_Add.Location = New System.Drawing.Point(6, 0)
            Me.ButtonOfficeRightSection_Add.Name = "ButtonOfficeRightSection_Add"
            Me.ButtonOfficeRightSection_Add.SecurityEnabled = True
            Me.ButtonOfficeRightSection_Add.Size = New System.Drawing.Size(75, 20)
            Me.ButtonOfficeRightSection_Add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonOfficeRightSection_Add.TabIndex = 0
            Me.ButtonOfficeRightSection_Add.Text = ">"
            '
            'ButtonOfficeRightSection_AddAll
            '
            Me.ButtonOfficeRightSection_AddAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonOfficeRightSection_AddAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonOfficeRightSection_AddAll.Location = New System.Drawing.Point(6, 26)
            Me.ButtonOfficeRightSection_AddAll.Name = "ButtonOfficeRightSection_AddAll"
            Me.ButtonOfficeRightSection_AddAll.SecurityEnabled = True
            Me.ButtonOfficeRightSection_AddAll.Size = New System.Drawing.Size(75, 20)
            Me.ButtonOfficeRightSection_AddAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonOfficeRightSection_AddAll.TabIndex = 1
            Me.ButtonOfficeRightSection_AddAll.Text = ">>"
            '
            'DataGridViewOfficeRightSection_Presets
            '
            Me.DataGridViewOfficeRightSection_Presets.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewOfficeRightSection_Presets.AllowDragAndDrop = False
            Me.DataGridViewOfficeRightSection_Presets.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewOfficeRightSection_Presets.AllowSelectGroupHeaderRow = True
            Me.DataGridViewOfficeRightSection_Presets.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewOfficeRightSection_Presets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewOfficeRightSection_Presets.AutoFilterLookupColumns = False
            Me.DataGridViewOfficeRightSection_Presets.AutoloadRepositoryDatasource = True
            Me.DataGridViewOfficeRightSection_Presets.AutoUpdateViewCaption = True
            Me.DataGridViewOfficeRightSection_Presets.BackColor = System.Drawing.Color.White
            Me.DataGridViewOfficeRightSection_Presets.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewOfficeRightSection_Presets.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewOfficeRightSection_Presets.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewOfficeRightSection_Presets.ItemDescription = ""
            Me.DataGridViewOfficeRightSection_Presets.Location = New System.Drawing.Point(87, 0)
            Me.DataGridViewOfficeRightSection_Presets.MultiSelect = True
            Me.DataGridViewOfficeRightSection_Presets.Name = "DataGridViewOfficeRightSection_Presets"
            Me.DataGridViewOfficeRightSection_Presets.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewOfficeRightSection_Presets.RunStandardValidation = True
            Me.DataGridViewOfficeRightSection_Presets.ShowColumnMenuOnRightClick = False
            Me.DataGridViewOfficeRightSection_Presets.ShowSelectDeselectAllButtons = False
            Me.DataGridViewOfficeRightSection_Presets.Size = New System.Drawing.Size(386, 307)
            Me.DataGridViewOfficeRightSection_Presets.TabIndex = 4
            Me.DataGridViewOfficeRightSection_Presets.UseEmbeddedNavigator = False
            Me.DataGridViewOfficeRightSection_Presets.ViewCaptionHeight = -1
            '
            'ButtonOfficeRightSection_Remove
            '
            Me.ButtonOfficeRightSection_Remove.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonOfficeRightSection_Remove.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonOfficeRightSection_Remove.Location = New System.Drawing.Point(6, 52)
            Me.ButtonOfficeRightSection_Remove.Name = "ButtonOfficeRightSection_Remove"
            Me.ButtonOfficeRightSection_Remove.SecurityEnabled = True
            Me.ButtonOfficeRightSection_Remove.Size = New System.Drawing.Size(75, 20)
            Me.ButtonOfficeRightSection_Remove.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonOfficeRightSection_Remove.TabIndex = 2
            Me.ButtonOfficeRightSection_Remove.Text = "<"
            '
            'ButtonOfficeRightSection_RemoveAll
            '
            Me.ButtonOfficeRightSection_RemoveAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonOfficeRightSection_RemoveAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonOfficeRightSection_RemoveAll.Location = New System.Drawing.Point(6, 78)
            Me.ButtonOfficeRightSection_RemoveAll.Name = "ButtonOfficeRightSection_RemoveAll"
            Me.ButtonOfficeRightSection_RemoveAll.SecurityEnabled = True
            Me.ButtonOfficeRightSection_RemoveAll.Size = New System.Drawing.Size(75, 20)
            Me.ButtonOfficeRightSection_RemoveAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonOfficeRightSection_RemoveAll.TabIndex = 3
            Me.ButtonOfficeRightSection_RemoveAll.Text = "<<"
            '
            'ExpandableSplitterOffice_OfficeLeftRightSection
            '
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.Location = New System.Drawing.Point(303, 0)
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.Name = "ExpandableSplitterOffice_OfficeLeftRightSection"
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.Size = New System.Drawing.Size(6, 307)
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.TabIndex = 1
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.TabStop = False
            '
            'PanelOffice_OfficeLeftSection
            '
            Me.PanelOffice_OfficeLeftSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelOffice_OfficeLeftSection.Appearance.Options.UseBackColor = True
            Me.PanelOffice_OfficeLeftSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelOffice_OfficeLeftSection.Controls.Add(Me.DataGridViewOfficeLeftSection_Offices)
            Me.PanelOffice_OfficeLeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelOffice_OfficeLeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelOffice_OfficeLeftSection.Name = "PanelOffice_OfficeLeftSection"
            Me.PanelOffice_OfficeLeftSection.Size = New System.Drawing.Size(303, 307)
            Me.PanelOffice_OfficeLeftSection.TabIndex = 0
            '
            'DataGridViewOfficeLeftSection_Offices
            '
            Me.DataGridViewOfficeLeftSection_Offices.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewOfficeLeftSection_Offices.AllowDragAndDrop = False
            Me.DataGridViewOfficeLeftSection_Offices.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewOfficeLeftSection_Offices.AllowSelectGroupHeaderRow = True
            Me.DataGridViewOfficeLeftSection_Offices.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewOfficeLeftSection_Offices.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewOfficeLeftSection_Offices.AutoFilterLookupColumns = False
            Me.DataGridViewOfficeLeftSection_Offices.AutoloadRepositoryDatasource = True
            Me.DataGridViewOfficeLeftSection_Offices.AutoUpdateViewCaption = True
            Me.DataGridViewOfficeLeftSection_Offices.BackColor = System.Drawing.Color.White
            Me.DataGridViewOfficeLeftSection_Offices.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewOfficeLeftSection_Offices.DataSource = Nothing
            Me.DataGridViewOfficeLeftSection_Offices.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewOfficeLeftSection_Offices.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewOfficeLeftSection_Offices.ItemDescription = "Office(s)"
            Me.DataGridViewOfficeLeftSection_Offices.Location = New System.Drawing.Point(0, 0)
            Me.DataGridViewOfficeLeftSection_Offices.MultiSelect = True
            Me.DataGridViewOfficeLeftSection_Offices.Name = "DataGridViewOfficeLeftSection_Offices"
            Me.DataGridViewOfficeLeftSection_Offices.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewOfficeLeftSection_Offices.RunStandardValidation = True
            Me.DataGridViewOfficeLeftSection_Offices.ShowColumnMenuOnRightClick = False
            Me.DataGridViewOfficeLeftSection_Offices.ShowSelectDeselectAllButtons = False
            Me.DataGridViewOfficeLeftSection_Offices.Size = New System.Drawing.Size(297, 307)
            Me.DataGridViewOfficeLeftSection_Offices.TabIndex = 0
            Me.DataGridViewOfficeLeftSection_Offices.UseEmbeddedNavigator = False
            Me.DataGridViewOfficeLeftSection_Offices.ViewCaptionHeight = -1
            '
            'TabItemReportTemplatePresets_OfficeTab
            '
            Me.TabItemReportTemplatePresets_OfficeTab.AttachedControl = Me.TabControlPanelOfficeTab_Office
            Me.TabItemReportTemplatePresets_OfficeTab.Name = "TabItemReportTemplatePresets_OfficeTab"
            Me.TabItemReportTemplatePresets_OfficeTab.Text = "Office"
            '
            'TabControlPanelDepartmentTeamTab_DepartmentTeam
            '
            Me.TabControlPanelDepartmentTeamTab_DepartmentTeam.Controls.Add(Me.PanelDepartmentTeam_DepartmentTeam)
            Me.TabControlPanelDepartmentTeamTab_DepartmentTeam.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelDepartmentTeamTab_DepartmentTeam.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelDepartmentTeamTab_DepartmentTeam.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelDepartmentTeamTab_DepartmentTeam.Name = "TabControlPanelDepartmentTeamTab_DepartmentTeam"
            Me.TabControlPanelDepartmentTeamTab_DepartmentTeam.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelDepartmentTeamTab_DepartmentTeam.Size = New System.Drawing.Size(790, 315)
            Me.TabControlPanelDepartmentTeamTab_DepartmentTeam.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDepartmentTeamTab_DepartmentTeam.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDepartmentTeamTab_DepartmentTeam.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelDepartmentTeamTab_DepartmentTeam.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelDepartmentTeamTab_DepartmentTeam.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelDepartmentTeamTab_DepartmentTeam.Style.GradientAngle = 90
            Me.TabControlPanelDepartmentTeamTab_DepartmentTeam.TabIndex = 0
            Me.TabControlPanelDepartmentTeamTab_DepartmentTeam.TabItem = Me.TabItemReportTemplatePresets_DepartmentTeamTab
            '
            'PanelDepartmentTeam_DepartmentTeam
            '
            Me.PanelDepartmentTeam_DepartmentTeam.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelDepartmentTeam_DepartmentTeam.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelDepartmentTeam_DepartmentTeam.Appearance.Options.UseBackColor = True
            Me.PanelDepartmentTeam_DepartmentTeam.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelDepartmentTeam_DepartmentTeam.Controls.Add(Me.PanelDepartmentTeam_DTRightSection)
            Me.PanelDepartmentTeam_DepartmentTeam.Controls.Add(Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection)
            Me.PanelDepartmentTeam_DepartmentTeam.Controls.Add(Me.PanelDepartmentTeam_DTLeftSection)
            Me.PanelDepartmentTeam_DepartmentTeam.Location = New System.Drawing.Point(4, 4)
            Me.PanelDepartmentTeam_DepartmentTeam.Name = "PanelDepartmentTeam_DepartmentTeam"
            Me.PanelDepartmentTeam_DepartmentTeam.Size = New System.Drawing.Size(782, 307)
            Me.PanelDepartmentTeam_DepartmentTeam.TabIndex = 0
            '
            'PanelDepartmentTeam_DTRightSection
            '
            Me.PanelDepartmentTeam_DTRightSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelDepartmentTeam_DTRightSection.Appearance.Options.UseBackColor = True
            Me.PanelDepartmentTeam_DTRightSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelDepartmentTeam_DTRightSection.Controls.Add(Me.ButtonDTRightSection_Add)
            Me.PanelDepartmentTeam_DTRightSection.Controls.Add(Me.ButtonDTRightSection_AddAll)
            Me.PanelDepartmentTeam_DTRightSection.Controls.Add(Me.ButtonDTRightSection_RemoveAll)
            Me.PanelDepartmentTeam_DTRightSection.Controls.Add(Me.ButtonDTRightSection_Remove)
            Me.PanelDepartmentTeam_DTRightSection.Controls.Add(Me.DataGridViewDTRightSection_Presets)
            Me.PanelDepartmentTeam_DTRightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelDepartmentTeam_DTRightSection.Location = New System.Drawing.Point(309, 0)
            Me.PanelDepartmentTeam_DTRightSection.Name = "PanelDepartmentTeam_DTRightSection"
            Me.PanelDepartmentTeam_DTRightSection.Size = New System.Drawing.Size(473, 307)
            Me.PanelDepartmentTeam_DTRightSection.TabIndex = 2
            '
            'ButtonDTRightSection_Add
            '
            Me.ButtonDTRightSection_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonDTRightSection_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonDTRightSection_Add.Location = New System.Drawing.Point(6, 0)
            Me.ButtonDTRightSection_Add.Name = "ButtonDTRightSection_Add"
            Me.ButtonDTRightSection_Add.SecurityEnabled = True
            Me.ButtonDTRightSection_Add.Size = New System.Drawing.Size(75, 20)
            Me.ButtonDTRightSection_Add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonDTRightSection_Add.TabIndex = 0
            Me.ButtonDTRightSection_Add.Text = ">"
            '
            'ButtonDTRightSection_AddAll
            '
            Me.ButtonDTRightSection_AddAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonDTRightSection_AddAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonDTRightSection_AddAll.Location = New System.Drawing.Point(6, 26)
            Me.ButtonDTRightSection_AddAll.Name = "ButtonDTRightSection_AddAll"
            Me.ButtonDTRightSection_AddAll.SecurityEnabled = True
            Me.ButtonDTRightSection_AddAll.Size = New System.Drawing.Size(75, 20)
            Me.ButtonDTRightSection_AddAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonDTRightSection_AddAll.TabIndex = 1
            Me.ButtonDTRightSection_AddAll.Text = ">>"
            '
            'ButtonDTRightSection_RemoveAll
            '
            Me.ButtonDTRightSection_RemoveAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonDTRightSection_RemoveAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonDTRightSection_RemoveAll.Location = New System.Drawing.Point(6, 78)
            Me.ButtonDTRightSection_RemoveAll.Name = "ButtonDTRightSection_RemoveAll"
            Me.ButtonDTRightSection_RemoveAll.SecurityEnabled = True
            Me.ButtonDTRightSection_RemoveAll.Size = New System.Drawing.Size(75, 20)
            Me.ButtonDTRightSection_RemoveAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonDTRightSection_RemoveAll.TabIndex = 3
            Me.ButtonDTRightSection_RemoveAll.Text = "<<"
            '
            'ButtonDTRightSection_Remove
            '
            Me.ButtonDTRightSection_Remove.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonDTRightSection_Remove.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonDTRightSection_Remove.Location = New System.Drawing.Point(6, 52)
            Me.ButtonDTRightSection_Remove.Name = "ButtonDTRightSection_Remove"
            Me.ButtonDTRightSection_Remove.SecurityEnabled = True
            Me.ButtonDTRightSection_Remove.Size = New System.Drawing.Size(75, 20)
            Me.ButtonDTRightSection_Remove.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonDTRightSection_Remove.TabIndex = 2
            Me.ButtonDTRightSection_Remove.Text = "<"
            '
            'DataGridViewDTRightSection_Presets
            '
            Me.DataGridViewDTRightSection_Presets.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewDTRightSection_Presets.AllowDragAndDrop = False
            Me.DataGridViewDTRightSection_Presets.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewDTRightSection_Presets.AllowSelectGroupHeaderRow = True
            Me.DataGridViewDTRightSection_Presets.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewDTRightSection_Presets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewDTRightSection_Presets.AutoFilterLookupColumns = False
            Me.DataGridViewDTRightSection_Presets.AutoloadRepositoryDatasource = True
            Me.DataGridViewDTRightSection_Presets.AutoUpdateViewCaption = True
            Me.DataGridViewDTRightSection_Presets.BackColor = System.Drawing.Color.White
            Me.DataGridViewDTRightSection_Presets.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewDTRightSection_Presets.DataSource = Nothing
            Me.DataGridViewDTRightSection_Presets.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewDTRightSection_Presets.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewDTRightSection_Presets.ItemDescription = ""
            Me.DataGridViewDTRightSection_Presets.Location = New System.Drawing.Point(87, 0)
            Me.DataGridViewDTRightSection_Presets.MultiSelect = True
            Me.DataGridViewDTRightSection_Presets.Name = "DataGridViewDTRightSection_Presets"
            Me.DataGridViewDTRightSection_Presets.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewDTRightSection_Presets.RunStandardValidation = True
            Me.DataGridViewDTRightSection_Presets.ShowColumnMenuOnRightClick = False
            Me.DataGridViewDTRightSection_Presets.ShowSelectDeselectAllButtons = False
            Me.DataGridViewDTRightSection_Presets.Size = New System.Drawing.Size(386, 307)
            Me.DataGridViewDTRightSection_Presets.TabIndex = 4
            Me.DataGridViewDTRightSection_Presets.UseEmbeddedNavigator = False
            Me.DataGridViewDTRightSection_Presets.ViewCaptionHeight = -1
            '
            'ExpandableSplitterDepartmentTeam_DTLeftRightSection
            '
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.Location = New System.Drawing.Point(303, 0)
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.Name = "ExpandableSplitterDepartmentTeam_DTLeftRightSection"
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.Size = New System.Drawing.Size(6, 307)
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.TabIndex = 1
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.TabStop = False
            '
            'PanelDepartmentTeam_DTLeftSection
            '
            Me.PanelDepartmentTeam_DTLeftSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelDepartmentTeam_DTLeftSection.Appearance.Options.UseBackColor = True
            Me.PanelDepartmentTeam_DTLeftSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelDepartmentTeam_DTLeftSection.Controls.Add(Me.DataGridViewDTLeftSection_DepartmentTeams)
            Me.PanelDepartmentTeam_DTLeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelDepartmentTeam_DTLeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelDepartmentTeam_DTLeftSection.Name = "PanelDepartmentTeam_DTLeftSection"
            Me.PanelDepartmentTeam_DTLeftSection.Size = New System.Drawing.Size(303, 307)
            Me.PanelDepartmentTeam_DTLeftSection.TabIndex = 0
            '
            'DataGridViewDTLeftSection_DepartmentTeams
            '
            Me.DataGridViewDTLeftSection_DepartmentTeams.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewDTLeftSection_DepartmentTeams.AllowDragAndDrop = False
            Me.DataGridViewDTLeftSection_DepartmentTeams.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewDTLeftSection_DepartmentTeams.AllowSelectGroupHeaderRow = True
            Me.DataGridViewDTLeftSection_DepartmentTeams.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewDTLeftSection_DepartmentTeams.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewDTLeftSection_DepartmentTeams.AutoFilterLookupColumns = False
            Me.DataGridViewDTLeftSection_DepartmentTeams.AutoloadRepositoryDatasource = True
            Me.DataGridViewDTLeftSection_DepartmentTeams.AutoUpdateViewCaption = True
            Me.DataGridViewDTLeftSection_DepartmentTeams.BackColor = System.Drawing.Color.White
            Me.DataGridViewDTLeftSection_DepartmentTeams.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewDTLeftSection_DepartmentTeams.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewDTLeftSection_DepartmentTeams.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewDTLeftSection_DepartmentTeams.ItemDescription = ""
            Me.DataGridViewDTLeftSection_DepartmentTeams.Location = New System.Drawing.Point(0, 0)
            Me.DataGridViewDTLeftSection_DepartmentTeams.MultiSelect = True
            Me.DataGridViewDTLeftSection_DepartmentTeams.Name = "DataGridViewDTLeftSection_DepartmentTeams"
            Me.DataGridViewDTLeftSection_DepartmentTeams.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewDTLeftSection_DepartmentTeams.RunStandardValidation = True
            Me.DataGridViewDTLeftSection_DepartmentTeams.ShowColumnMenuOnRightClick = False
            Me.DataGridViewDTLeftSection_DepartmentTeams.ShowSelectDeselectAllButtons = False
            Me.DataGridViewDTLeftSection_DepartmentTeams.Size = New System.Drawing.Size(297, 307)
            Me.DataGridViewDTLeftSection_DepartmentTeams.TabIndex = 0
            Me.DataGridViewDTLeftSection_DepartmentTeams.UseEmbeddedNavigator = False
            Me.DataGridViewDTLeftSection_DepartmentTeams.ViewCaptionHeight = -1
            '
            'TabItemReportTemplatePresets_DepartmentTeamTab
            '
            Me.TabItemReportTemplatePresets_DepartmentTeamTab.AttachedControl = Me.TabControlPanelDepartmentTeamTab_DepartmentTeam
            Me.TabItemReportTemplatePresets_DepartmentTeamTab.Name = "TabItemReportTemplatePresets_DepartmentTeamTab"
            Me.TabItemReportTemplatePresets_DepartmentTeamTab.Text = "Department / Teams"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(727, 359)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 3
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'GeneralLedgerReportDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(814, 392)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.TabControlForm_OptionsPresets)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "GeneralLedgerReportDialog"
            Me.Text = "General Ledger Reports"
            CType(Me.TabControlForm_OptionsPresets, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_OptionsPresets.ResumeLayout(False)
            Me.TabControlPanelOptionsTab_Options.ResumeLayout(False)
            CType(Me.PanelOptions_Main, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelOptions_Main.ResumeLayout(False)
            CType(Me.PanelOptions_Left, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelOptions_Left.ResumeLayout(False)
            CType(Me.ListBoxOptions_Reports, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelTypesTab_Types.ResumeLayout(False)
            CType(Me.PanelTypes_Types, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelTypes_Types.ResumeLayout(False)
            CType(Me.PanelTypes_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelTypes_RightSection.ResumeLayout(False)
            CType(Me.PanelTypes_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelTypes_LeftSection.ResumeLayout(False)
            Me.TabControlPanelOtherTab_Other.ResumeLayout(False)
            CType(Me.PanelOther_Other, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelOther_Other.ResumeLayout(False)
            CType(Me.PanelOther_OtherRightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelOther_OtherRightSection.ResumeLayout(False)
            CType(Me.PanelOther_OtherLeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelOther_OtherLeftSection.ResumeLayout(False)
            Me.TabControlPanelBaseTab_Bae.ResumeLayout(False)
            CType(Me.PanelBase_Base, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelBase_Base.ResumeLayout(False)
            CType(Me.PanelBase_BaseRightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelBase_BaseRightSection.ResumeLayout(False)
            CType(Me.PanelBase_BaseLeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelBase_BaseLeftSection.ResumeLayout(False)
            Me.TabControlPanelOfficeTab_Office.ResumeLayout(False)
            CType(Me.PanelOffice_Office, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelOffice_Office.ResumeLayout(False)
            CType(Me.PanelOffice_OfficeRightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelOffice_OfficeRightSection.ResumeLayout(False)
            CType(Me.PanelOffice_OfficeLeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelOffice_OfficeLeftSection.ResumeLayout(False)
            Me.TabControlPanelDepartmentTeamTab_DepartmentTeam.ResumeLayout(False)
            CType(Me.PanelDepartmentTeam_DepartmentTeam, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelDepartmentTeam_DepartmentTeam.ResumeLayout(False)
            CType(Me.PanelDepartmentTeam_DTRightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelDepartmentTeam_DTRightSection.ResumeLayout(False)
            CType(Me.PanelDepartmentTeam_DTLeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelDepartmentTeam_DTLeftSection.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents TabControlForm_OptionsPresets As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelDepartmentTeamTab_DepartmentTeam As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemReportTemplatePresets_DepartmentTeamTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelOfficeTab_Office As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemReportTemplatePresets_OfficeTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelOptionsTab_Options As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemOptionsPresets_OptionsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents ComboBoxOptions_PostPeriodStart As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelOptions_PostPeriodStart As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents PanelOffice_Office As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelOffice_OfficeRightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewOfficeRightSection_Presets As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ExpandableSplitterOffice_OfficeLeftRightSection As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelOffice_OfficeLeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewOfficeLeftSection_Offices As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonOfficeRightSection_Add As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonOfficeRightSection_AddAll As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonOfficeRightSection_RemoveAll As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonOfficeRightSection_Remove As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents PanelDepartmentTeam_DepartmentTeam As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelDepartmentTeam_DTRightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ButtonDTRightSection_Add As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonDTRightSection_AddAll As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonDTRightSection_RemoveAll As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonDTRightSection_Remove As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewDTRightSection_Presets As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ExpandableSplitterDepartmentTeam_DTLeftRightSection As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelDepartmentTeam_DTLeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewDTLeftSection_DepartmentTeams As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents LabelOptions_Report As WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxOptions_PostPeriodEnd As WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelOptions_PostPeriodEnd As WinForm.Presentation.Controls.Label
        Friend WithEvents ListBoxOptions_Reports As WinForm.Presentation.Controls.ListBox
        Friend WithEvents TabControlPanelOtherTab_Other As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemReportTemplatePresets_OtherTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelBaseTab_Bae As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemReportTemplatePresets_BaseTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents PanelOther_Other As WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelOther_OtherRightSection As WinForm.Presentation.Controls.Panel
        Friend WithEvents ButtonOtherRightSection_Add As WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonOtherRightSection_AddAll As WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonOtherRightSection_RemoveAll As WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonOtherRightSection_Remove As WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewOtherRightSection_Other As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ExpandableSplitterControl2 As WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelOther_OtherLeftSection As WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewOtherLeftSection_Other As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents PanelBase_Base As WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelBase_BaseRightSection As WinForm.Presentation.Controls.Panel
        Friend WithEvents ButtonBaseRightSection_Add As WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonBaseRightSection_AddAll As WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonBaseRightSection_RemoveAll As WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonBaseRightSection_Remove As WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewBaseRightSection_Base As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ExpandableSplitterControl1 As WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelBase_BaseLeftSection As WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewBaseLeftSection_Base As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents PanelOptions_Main As WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelOptions_Left As WinForm.Presentation.Controls.Panel
        Friend WithEvents LabelOptions_RecordSource As WinForm.Presentation.Controls.Label
        Friend WithEvents TabControlPanelTypesTab_Types As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents PanelTypes_Types As WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelTypes_RightSection As WinForm.Presentation.Controls.Panel
        Friend WithEvents ButtonTypesRightSection_Add As WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonTypesRightSection_AddAll As WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonTypesRightSection_RemoveAll As WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonTypesRightSection_Remove As WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewRightSection_SelectedTypes As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ExpandableSplitterControl3 As WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelTypes_LeftSection As WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewLeftSection_AvailableTypes As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TabItemReportTemplatePresets_TypesTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents ButtonOptions_2Years As WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonOptions_1Year As WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonOptions_MTD As WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonOptions_YTD As WinForm.Presentation.Controls.Button
        Friend WithEvents ComboBoxOptions_RecordSource As WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ButtonForm_Cancel As WinForm.Presentation.Controls.Button
    End Class

End Namespace