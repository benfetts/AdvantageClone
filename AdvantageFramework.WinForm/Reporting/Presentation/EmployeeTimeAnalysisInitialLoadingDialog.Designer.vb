Namespace Reporting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class EmployeeTimeAnalysisInitialLoadingDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmployeeTimeAnalysisInitialLoadingDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.PanelForm_TopSection = New System.Windows.Forms.Panel()
            Me.LabelTopSection_Report = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxTopSection_Report = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxTopSection_ReportSeries = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelTopSection_ReportSeries = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabControlForm_JDA = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions = New DevComponents.DotNetBar.TabControlPanel()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.RadioButtonControl_Day = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControl_Month = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.CheckBoxForm_Actualized = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelForm_To = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_From = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DateTimePickerForm_To = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerForm_From = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.TabItemJDA_VersionAndOptionsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelSelectOfficesTab_SelectOffices = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewSelectOffices_Offices = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonSelectOffices_AllOffices = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectOffices_ChooseOffices = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TabItemJDA_SelectOfficesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanel2 = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewSelectDepartments_Departments = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonSelectDepartments_ChooseDepartments = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectDepartments_AllDepartments = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TabItemJDA_SelectDepartmentsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanel4 = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewSelectEmployees_Employees = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonSelectEmployees_ChooseEmployees = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectEmployees_AllEmployees = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TabItemJDA_SelectEmployeesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.LabelForm_Office = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_Offices = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_Employee = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_Employees = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_StartingPostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_EndPostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.PanelForm_Bottom = New System.Windows.Forms.Panel()
            Me.PanelForm_TopSection.SuspendLayout()
            CType(Me.TabControlForm_JDA, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_JDA.SuspendLayout()
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
            CType(Me.DateTimePickerForm_To, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerForm_From, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelSelectOfficesTab_SelectOffices.SuspendLayout()
            Me.TabControlPanel2.SuspendLayout()
            Me.TabControlPanel4.SuspendLayout()
            Me.Panel1.SuspendLayout()
            Me.PanelForm_Bottom.SuspendLayout()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(872, 11)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 8
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(953, 11)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 9
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'PanelForm_TopSection
            '
            Me.PanelForm_TopSection.Controls.Add(Me.LabelTopSection_Report)
            Me.PanelForm_TopSection.Controls.Add(Me.ComboBoxTopSection_Report)
            Me.PanelForm_TopSection.Dock = System.Windows.Forms.DockStyle.Top
            Me.PanelForm_TopSection.Enabled = False
            Me.PanelForm_TopSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_TopSection.Name = "PanelForm_TopSection"
            Me.PanelForm_TopSection.Size = New System.Drawing.Size(1041, 38)
            Me.PanelForm_TopSection.TabIndex = 11
            Me.PanelForm_TopSection.Visible = False
            '
            'LabelTopSection_Report
            '
            Me.LabelTopSection_Report.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTopSection_Report.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTopSection_Report.Location = New System.Drawing.Point(12, 13)
            Me.LabelTopSection_Report.Name = "LabelTopSection_Report"
            Me.LabelTopSection_Report.Size = New System.Drawing.Size(106, 20)
            Me.LabelTopSection_Report.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTopSection_Report.TabIndex = 2
            Me.LabelTopSection_Report.Text = "Report:"
            '
            'ComboBoxTopSection_Report
            '
            Me.ComboBoxTopSection_Report.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxTopSection_Report.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxTopSection_Report.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxTopSection_Report.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxTopSection_Report.AutoFindItemInDataSource = False
            Me.ComboBoxTopSection_Report.AutoSelectSingleItemDatasource = False
            Me.ComboBoxTopSection_Report.BookmarkingEnabled = False
            Me.ComboBoxTopSection_Report.ClientCode = ""
            Me.ComboBoxTopSection_Report.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumObjects
            Me.ComboBoxTopSection_Report.DisableMouseWheel = False
            Me.ComboBoxTopSection_Report.DisplayMember = "Description"
            Me.ComboBoxTopSection_Report.DisplayName = ""
            Me.ComboBoxTopSection_Report.DivisionCode = ""
            Me.ComboBoxTopSection_Report.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxTopSection_Report.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxTopSection_Report.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxTopSection_Report.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxTopSection_Report.FocusHighlightEnabled = True
            Me.ComboBoxTopSection_Report.FormattingEnabled = True
            Me.ComboBoxTopSection_Report.ItemHeight = 15
            Me.ComboBoxTopSection_Report.Location = New System.Drawing.Point(124, 13)
            Me.ComboBoxTopSection_Report.Name = "ComboBoxTopSection_Report"
            Me.ComboBoxTopSection_Report.ReadOnly = False
            Me.ComboBoxTopSection_Report.SecurityEnabled = True
            Me.ComboBoxTopSection_Report.Size = New System.Drawing.Size(905, 21)
            Me.ComboBoxTopSection_Report.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxTopSection_Report.TabIndex = 1
            Me.ComboBoxTopSection_Report.TabOnEnter = True
            Me.ComboBoxTopSection_Report.ValueMember = "Code"
            Me.ComboBoxTopSection_Report.WatermarkText = "Select"
            '
            'ComboBoxTopSection_ReportSeries
            '
            Me.ComboBoxTopSection_ReportSeries.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxTopSection_ReportSeries.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxTopSection_ReportSeries.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxTopSection_ReportSeries.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxTopSection_ReportSeries.AutoFindItemInDataSource = False
            Me.ComboBoxTopSection_ReportSeries.AutoSelectSingleItemDatasource = False
            Me.ComboBoxTopSection_ReportSeries.BookmarkingEnabled = False
            Me.ComboBoxTopSection_ReportSeries.ClientCode = ""
            Me.ComboBoxTopSection_ReportSeries.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumObjects
            Me.ComboBoxTopSection_ReportSeries.DisableMouseWheel = False
            Me.ComboBoxTopSection_ReportSeries.DisplayMember = "Description"
            Me.ComboBoxTopSection_ReportSeries.DisplayName = ""
            Me.ComboBoxTopSection_ReportSeries.DivisionCode = ""
            Me.ComboBoxTopSection_ReportSeries.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxTopSection_ReportSeries.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxTopSection_ReportSeries.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxTopSection_ReportSeries.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxTopSection_ReportSeries.FocusHighlightEnabled = True
            Me.ComboBoxTopSection_ReportSeries.FormattingEnabled = True
            Me.ComboBoxTopSection_ReportSeries.ItemHeight = 15
            Me.ComboBoxTopSection_ReportSeries.Location = New System.Drawing.Point(124, 13)
            Me.ComboBoxTopSection_ReportSeries.Name = "ComboBoxTopSection_ReportSeries"
            Me.ComboBoxTopSection_ReportSeries.ReadOnly = False
            Me.ComboBoxTopSection_ReportSeries.SecurityEnabled = True
            Me.ComboBoxTopSection_ReportSeries.Size = New System.Drawing.Size(905, 21)
            Me.ComboBoxTopSection_ReportSeries.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxTopSection_ReportSeries.TabIndex = 3
            Me.ComboBoxTopSection_ReportSeries.TabOnEnter = True
            Me.ComboBoxTopSection_ReportSeries.ValueMember = "Code"
            Me.ComboBoxTopSection_ReportSeries.WatermarkText = "Select"
            '
            'LabelTopSection_ReportSeries
            '
            Me.LabelTopSection_ReportSeries.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTopSection_ReportSeries.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTopSection_ReportSeries.Location = New System.Drawing.Point(12, 13)
            Me.LabelTopSection_ReportSeries.Name = "LabelTopSection_ReportSeries"
            Me.LabelTopSection_ReportSeries.Size = New System.Drawing.Size(106, 20)
            Me.LabelTopSection_ReportSeries.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTopSection_ReportSeries.TabIndex = 0
            Me.LabelTopSection_ReportSeries.Text = "Report Series:"
            '
            'TabControlForm_JDA
            '
            Me.TabControlForm_JDA.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlForm_JDA.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
            Me.TabControlForm_JDA.CanReorderTabs = False
            Me.TabControlForm_JDA.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlForm_JDA.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlForm_JDA.Controls.Add(Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions)
            Me.TabControlForm_JDA.Controls.Add(Me.TabControlPanelSelectOfficesTab_SelectOffices)
            Me.TabControlForm_JDA.Controls.Add(Me.TabControlPanel2)
            Me.TabControlForm_JDA.Controls.Add(Me.TabControlPanel4)
            Me.TabControlForm_JDA.Location = New System.Drawing.Point(12, 3)
            Me.TabControlForm_JDA.Name = "TabControlForm_JDA"
            Me.TabControlForm_JDA.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_JDA.SelectedTabIndex = 0
            Me.TabControlForm_JDA.Size = New System.Drawing.Size(1017, 597)
            Me.TabControlForm_JDA.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_JDA.TabIndex = 37
            Me.TabControlForm_JDA.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_JDA.Tabs.Add(Me.TabItemJDA_VersionAndOptionsTab)
            Me.TabControlForm_JDA.Tabs.Add(Me.TabItemJDA_SelectOfficesTab)
            Me.TabControlForm_JDA.Tabs.Add(Me.TabItemJDA_SelectDepartmentsTab)
            Me.TabControlForm_JDA.Tabs.Add(Me.TabItemJDA_SelectEmployeesTab)
            '
            'TabControlPanelVersionAndOptionsTab_VersionAndOptions
            '
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.GroupBox2)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.CheckBoxForm_Actualized)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.LabelForm_To)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.LabelForm_From)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.DateTimePickerForm_To)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.DateTimePickerForm_From)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Name = "TabControlPanelVersionAndOptionsTab_VersionAndOptions"
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Size = New System.Drawing.Size(1017, 570)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Style.GradientAngle = 90
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.TabIndex = 0
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.TabItem = Me.TabItemJDA_VersionAndOptionsTab
            '
            'GroupBox2
            '
            Me.GroupBox2.BackColor = System.Drawing.SystemColors.Window
            Me.GroupBox2.Controls.Add(Me.RadioButtonControl_Day)
            Me.GroupBox2.Controls.Add(Me.RadioButtonControl_Month)
            Me.GroupBox2.Location = New System.Drawing.Point(55, 37)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(330, 41)
            Me.GroupBox2.TabIndex = 60
            Me.GroupBox2.TabStop = False
            '
            'RadioButtonControl_Day
            '
            Me.RadioButtonControl_Day.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControl_Day.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControl_Day.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControl_Day.Location = New System.Drawing.Point(8, 10)
            Me.RadioButtonControl_Day.Name = "RadioButtonControl_Day"
            Me.RadioButtonControl_Day.SecurityEnabled = True
            Me.RadioButtonControl_Day.Size = New System.Drawing.Size(145, 20)
            Me.RadioButtonControl_Day.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControl_Day.TabIndex = 62
            Me.RadioButtonControl_Day.TabOnEnter = True
            Me.RadioButtonControl_Day.TabStop = False
            Me.RadioButtonControl_Day.Text = "Fee Time as Billable"
            '
            'RadioButtonControl_Month
            '
            Me.RadioButtonControl_Month.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControl_Month.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControl_Month.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControl_Month.Location = New System.Drawing.Point(155, 10)
            Me.RadioButtonControl_Month.Name = "RadioButtonControl_Month"
            Me.RadioButtonControl_Month.SecurityEnabled = True
            Me.RadioButtonControl_Month.Size = New System.Drawing.Size(150, 20)
            Me.RadioButtonControl_Month.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControl_Month.TabIndex = 53
            Me.RadioButtonControl_Month.TabOnEnter = True
            Me.RadioButtonControl_Month.TabStop = False
            Me.RadioButtonControl_Month.Text = "Fee Time as Nonbillable"
            '
            'CheckBoxForm_Actualized
            '
            '
            '
            '
            Me.CheckBoxForm_Actualized.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_Actualized.CheckValue = 0
            Me.CheckBoxForm_Actualized.CheckValueChecked = 1
            Me.CheckBoxForm_Actualized.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_Actualized.CheckValueUnchecked = 0
            Me.CheckBoxForm_Actualized.ChildControls = Nothing
            Me.CheckBoxForm_Actualized.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_Actualized.Location = New System.Drawing.Point(408, 8)
            Me.CheckBoxForm_Actualized.Name = "CheckBoxForm_Actualized"
            Me.CheckBoxForm_Actualized.OldestSibling = Nothing
            Me.CheckBoxForm_Actualized.SecurityEnabled = True
            Me.CheckBoxForm_Actualized.SiblingControls = Nothing
            Me.CheckBoxForm_Actualized.Size = New System.Drawing.Size(175, 20)
            Me.CheckBoxForm_Actualized.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_Actualized.TabIndex = 61
            Me.CheckBoxForm_Actualized.TabOnEnter = True
            Me.CheckBoxForm_Actualized.Text = "Include Active Employees Only"
            '
            'LabelForm_To
            '
            Me.LabelForm_To.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_To.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_To.Location = New System.Drawing.Point(194, 8)
            Me.LabelForm_To.Name = "LabelForm_To"
            Me.LabelForm_To.Size = New System.Drawing.Size(31, 20)
            Me.LabelForm_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_To.TabIndex = 27
            Me.LabelForm_To.Text = "To:"
            '
            'LabelForm_From
            '
            Me.LabelForm_From.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_From.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_From.Location = New System.Drawing.Point(10, 8)
            Me.LabelForm_From.Name = "LabelForm_From"
            Me.LabelForm_From.Size = New System.Drawing.Size(37, 20)
            Me.LabelForm_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_From.TabIndex = 25
            Me.LabelForm_From.Text = "From:"
            '
            'DateTimePickerForm_To
            '
            Me.DateTimePickerForm_To.AllowEmptyState = False
            Me.DateTimePickerForm_To.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerForm_To.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerForm_To.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_To.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerForm_To.ButtonDropDown.Visible = True
            Me.DateTimePickerForm_To.ButtonFreeText.Checked = True
            Me.DateTimePickerForm_To.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerForm_To.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerForm_To.DisplayName = ""
            Me.DateTimePickerForm_To.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerForm_To.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerForm_To.FocusHighlightEnabled = True
            Me.DateTimePickerForm_To.FreeTextEntryMode = True
            Me.DateTimePickerForm_To.IsPopupCalendarOpen = False
            Me.DateTimePickerForm_To.Location = New System.Drawing.Point(227, 8)
            Me.DateTimePickerForm_To.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerForm_To.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerForm_To.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerForm_To.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_To.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerForm_To.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerForm_To.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerForm_To.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_To.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerForm_To.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerForm_To.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerForm_To.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerForm_To.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_To.MonthCalendar.DisplayMonth = New Date(2012, 7, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerForm_To.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerForm_To.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_To.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerForm_To.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_To.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerForm_To.Name = "DateTimePickerForm_To"
            Me.DateTimePickerForm_To.ReadOnly = False
            Me.DateTimePickerForm_To.Size = New System.Drawing.Size(124, 20)
            Me.DateTimePickerForm_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_To.TabIndex = 28
            Me.DateTimePickerForm_To.TabOnEnter = True
            Me.DateTimePickerForm_To.Value = New Date(1850, 1, 1, 0, 0, 0, 0)
            '
            'DateTimePickerForm_From
            '
            Me.DateTimePickerForm_From.AllowEmptyState = False
            Me.DateTimePickerForm_From.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerForm_From.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerForm_From.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_From.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerForm_From.ButtonDropDown.Visible = True
            Me.DateTimePickerForm_From.ButtonFreeText.Checked = True
            Me.DateTimePickerForm_From.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerForm_From.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerForm_From.DisplayName = ""
            Me.DateTimePickerForm_From.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerForm_From.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerForm_From.FocusHighlightEnabled = True
            Me.DateTimePickerForm_From.FreeTextEntryMode = True
            Me.DateTimePickerForm_From.IsPopupCalendarOpen = False
            Me.DateTimePickerForm_From.Location = New System.Drawing.Point(55, 8)
            Me.DateTimePickerForm_From.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerForm_From.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerForm_From.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerForm_From.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_From.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerForm_From.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerForm_From.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerForm_From.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_From.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerForm_From.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerForm_From.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerForm_From.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerForm_From.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_From.MonthCalendar.DisplayMonth = New Date(2012, 7, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerForm_From.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerForm_From.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_From.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerForm_From.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_From.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerForm_From.Name = "DateTimePickerForm_From"
            Me.DateTimePickerForm_From.ReadOnly = False
            Me.DateTimePickerForm_From.Size = New System.Drawing.Size(124, 20)
            Me.DateTimePickerForm_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_From.TabIndex = 26
            Me.DateTimePickerForm_From.TabOnEnter = True
            Me.DateTimePickerForm_From.Value = New Date(1850, 1, 1, 0, 0, 0, 0)
            '
            'TabItemJDA_VersionAndOptionsTab
            '
            Me.TabItemJDA_VersionAndOptionsTab.AttachedControl = Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions
            Me.TabItemJDA_VersionAndOptionsTab.Name = "TabItemJDA_VersionAndOptionsTab"
            Me.TabItemJDA_VersionAndOptionsTab.Text = "Report Options"
            '
            'TabControlPanelSelectOfficesTab_SelectOffices
            '
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Controls.Add(Me.DataGridViewSelectOffices_Offices)
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Controls.Add(Me.RadioButtonSelectOffices_AllOffices)
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Controls.Add(Me.RadioButtonSelectOffices_ChooseOffices)
            Me.TabControlPanelSelectOfficesTab_SelectOffices.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Name = "TabControlPanelSelectOfficesTab_SelectOffices"
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Size = New System.Drawing.Size(1017, 570)
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Style.GradientAngle = 90
            Me.TabControlPanelSelectOfficesTab_SelectOffices.TabIndex = 0
            Me.TabControlPanelSelectOfficesTab_SelectOffices.TabItem = Me.TabItemJDA_SelectOfficesTab
            '
            'DataGridViewSelectOffices_Offices
            '
            Me.DataGridViewSelectOffices_Offices.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewSelectOffices_Offices.AllowDragAndDrop = False
            Me.DataGridViewSelectOffices_Offices.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewSelectOffices_Offices.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSelectOffices_Offices.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewSelectOffices_Offices.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSelectOffices_Offices.AutoFilterLookupColumns = False
            Me.DataGridViewSelectOffices_Offices.AutoloadRepositoryDatasource = True
            Me.DataGridViewSelectOffices_Offices.AutoUpdateViewCaption = True
            Me.DataGridViewSelectOffices_Offices.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewSelectOffices_Offices.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewSelectOffices_Offices.Enabled = False
            Me.DataGridViewSelectOffices_Offices.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSelectOffices_Offices.ItemDescription = "Office(s)"
            Me.DataGridViewSelectOffices_Offices.Location = New System.Drawing.Point(3, 30)
            Me.DataGridViewSelectOffices_Offices.MultiSelect = False
            Me.DataGridViewSelectOffices_Offices.Name = "DataGridViewSelectOffices_Offices"
            Me.DataGridViewSelectOffices_Offices.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSelectOffices_Offices.RunStandardValidation = True
            Me.DataGridViewSelectOffices_Offices.ShowColumnMenuOnRightClick = False
            Me.DataGridViewSelectOffices_Offices.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSelectOffices_Offices.Size = New System.Drawing.Size(1009, 536)
            Me.DataGridViewSelectOffices_Offices.TabIndex = 2
            Me.DataGridViewSelectOffices_Offices.UseEmbeddedNavigator = False
            Me.DataGridViewSelectOffices_Offices.ViewCaptionHeight = -1
            '
            'RadioButtonSelectOffices_AllOffices
            '
            Me.RadioButtonSelectOffices_AllOffices.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectOffices_AllOffices.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectOffices_AllOffices.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectOffices_AllOffices.Checked = True
            Me.RadioButtonSelectOffices_AllOffices.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonSelectOffices_AllOffices.CheckValue = "Y"
            Me.RadioButtonSelectOffices_AllOffices.Location = New System.Drawing.Point(4, 4)
            Me.RadioButtonSelectOffices_AllOffices.Name = "RadioButtonSelectOffices_AllOffices"
            Me.RadioButtonSelectOffices_AllOffices.SecurityEnabled = True
            Me.RadioButtonSelectOffices_AllOffices.Size = New System.Drawing.Size(77, 20)
            Me.RadioButtonSelectOffices_AllOffices.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectOffices_AllOffices.TabIndex = 0
            Me.RadioButtonSelectOffices_AllOffices.TabOnEnter = True
            Me.RadioButtonSelectOffices_AllOffices.Text = "All Offices"
            '
            'RadioButtonSelectOffices_ChooseOffices
            '
            Me.RadioButtonSelectOffices_ChooseOffices.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectOffices_ChooseOffices.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectOffices_ChooseOffices.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectOffices_ChooseOffices.Location = New System.Drawing.Point(87, 4)
            Me.RadioButtonSelectOffices_ChooseOffices.Name = "RadioButtonSelectOffices_ChooseOffices"
            Me.RadioButtonSelectOffices_ChooseOffices.SecurityEnabled = True
            Me.RadioButtonSelectOffices_ChooseOffices.Size = New System.Drawing.Size(138, 20)
            Me.RadioButtonSelectOffices_ChooseOffices.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectOffices_ChooseOffices.TabIndex = 1
            Me.RadioButtonSelectOffices_ChooseOffices.TabOnEnter = True
            Me.RadioButtonSelectOffices_ChooseOffices.TabStop = False
            Me.RadioButtonSelectOffices_ChooseOffices.Text = "Choose Offices"
            '
            'TabItemJDA_SelectOfficesTab
            '
            Me.TabItemJDA_SelectOfficesTab.AttachedControl = Me.TabControlPanelSelectOfficesTab_SelectOffices
            Me.TabItemJDA_SelectOfficesTab.Name = "TabItemJDA_SelectOfficesTab"
            Me.TabItemJDA_SelectOfficesTab.Text = "Select Offices"
            '
            'TabControlPanel2
            '
            Me.TabControlPanel2.Controls.Add(Me.DataGridViewSelectDepartments_Departments)
            Me.TabControlPanel2.Controls.Add(Me.RadioButtonSelectDepartments_ChooseDepartments)
            Me.TabControlPanel2.Controls.Add(Me.RadioButtonSelectDepartments_AllDepartments)
            Me.TabControlPanel2.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanel2.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanel2.Name = "TabControlPanel2"
            Me.TabControlPanel2.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanel2.Size = New System.Drawing.Size(1017, 570)
            Me.TabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanel2.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanel2.Style.GradientAngle = 90
            Me.TabControlPanel2.TabIndex = 4
            Me.TabControlPanel2.TabItem = Me.TabItemJDA_SelectDepartmentsTab
            '
            'DataGridViewSelectDepartments_Departments
            '
            Me.DataGridViewSelectDepartments_Departments.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewSelectDepartments_Departments.AllowDragAndDrop = False
            Me.DataGridViewSelectDepartments_Departments.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewSelectDepartments_Departments.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSelectDepartments_Departments.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewSelectDepartments_Departments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSelectDepartments_Departments.AutoFilterLookupColumns = False
            Me.DataGridViewSelectDepartments_Departments.AutoloadRepositoryDatasource = True
            Me.DataGridViewSelectDepartments_Departments.AutoUpdateViewCaption = True
            Me.DataGridViewSelectDepartments_Departments.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewSelectDepartments_Departments.DataSource = Nothing
            Me.DataGridViewSelectDepartments_Departments.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewSelectDepartments_Departments.Enabled = False
            Me.DataGridViewSelectDepartments_Departments.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSelectDepartments_Departments.ItemDescription = "Department(s)"
            Me.DataGridViewSelectDepartments_Departments.Location = New System.Drawing.Point(4, 30)
            Me.DataGridViewSelectDepartments_Departments.MultiSelect = True
            Me.DataGridViewSelectDepartments_Departments.Name = "DataGridViewSelectDepartments_Departments"
            Me.DataGridViewSelectDepartments_Departments.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSelectDepartments_Departments.RunStandardValidation = True
            Me.DataGridViewSelectDepartments_Departments.ShowColumnMenuOnRightClick = False
            Me.DataGridViewSelectDepartments_Departments.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSelectDepartments_Departments.Size = New System.Drawing.Size(1009, 536)
            Me.DataGridViewSelectDepartments_Departments.TabIndex = 3
            Me.DataGridViewSelectDepartments_Departments.UseEmbeddedNavigator = False
            Me.DataGridViewSelectDepartments_Departments.ViewCaptionHeight = -1
            '
            'RadioButtonSelectDepartments_ChooseDepartments
            '
            Me.RadioButtonSelectDepartments_ChooseDepartments.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectDepartments_ChooseDepartments.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectDepartments_ChooseDepartments.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectDepartments_ChooseDepartments.Location = New System.Drawing.Point(111, 4)
            Me.RadioButtonSelectDepartments_ChooseDepartments.Name = "RadioButtonSelectDepartments_ChooseDepartments"
            Me.RadioButtonSelectDepartments_ChooseDepartments.SecurityEnabled = True
            Me.RadioButtonSelectDepartments_ChooseDepartments.Size = New System.Drawing.Size(138, 20)
            Me.RadioButtonSelectDepartments_ChooseDepartments.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectDepartments_ChooseDepartments.TabIndex = 2
            Me.RadioButtonSelectDepartments_ChooseDepartments.TabOnEnter = True
            Me.RadioButtonSelectDepartments_ChooseDepartments.TabStop = False
            Me.RadioButtonSelectDepartments_ChooseDepartments.Text = "Choose Departments"
            '
            'RadioButtonSelectDepartments_AllDepartments
            '
            Me.RadioButtonSelectDepartments_AllDepartments.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectDepartments_AllDepartments.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectDepartments_AllDepartments.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectDepartments_AllDepartments.Checked = True
            Me.RadioButtonSelectDepartments_AllDepartments.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonSelectDepartments_AllDepartments.CheckValue = "Y"
            Me.RadioButtonSelectDepartments_AllDepartments.Location = New System.Drawing.Point(4, 4)
            Me.RadioButtonSelectDepartments_AllDepartments.Name = "RadioButtonSelectDepartments_AllDepartments"
            Me.RadioButtonSelectDepartments_AllDepartments.SecurityEnabled = True
            Me.RadioButtonSelectDepartments_AllDepartments.Size = New System.Drawing.Size(101, 20)
            Me.RadioButtonSelectDepartments_AllDepartments.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectDepartments_AllDepartments.TabIndex = 1
            Me.RadioButtonSelectDepartments_AllDepartments.TabOnEnter = True
            Me.RadioButtonSelectDepartments_AllDepartments.Text = "All Departments"
            '
            'TabItemJDA_SelectDepartmentsTab
            '
            Me.TabItemJDA_SelectDepartmentsTab.AttachedControl = Me.TabControlPanel2
            Me.TabItemJDA_SelectDepartmentsTab.Name = "TabItemJDA_SelectDepartmentsTab"
            Me.TabItemJDA_SelectDepartmentsTab.Text = "Select Departments"
            '
            'TabControlPanel4
            '
            Me.TabControlPanel4.Controls.Add(Me.DataGridViewSelectEmployees_Employees)
            Me.TabControlPanel4.Controls.Add(Me.RadioButtonSelectEmployees_ChooseEmployees)
            Me.TabControlPanel4.Controls.Add(Me.RadioButtonSelectEmployees_AllEmployees)
            Me.TabControlPanel4.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanel4.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanel4.Name = "TabControlPanel4"
            Me.TabControlPanel4.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanel4.Size = New System.Drawing.Size(1017, 570)
            Me.TabControlPanel4.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanel4.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanel4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanel4.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanel4.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanel4.Style.GradientAngle = 90
            Me.TabControlPanel4.TabIndex = 4
            Me.TabControlPanel4.TabItem = Me.TabItemJDA_SelectEmployeesTab
            '
            'DataGridViewSelectEmployees_Employees
            '
            Me.DataGridViewSelectEmployees_Employees.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewSelectEmployees_Employees.AllowDragAndDrop = False
            Me.DataGridViewSelectEmployees_Employees.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewSelectEmployees_Employees.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSelectEmployees_Employees.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewSelectEmployees_Employees.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSelectEmployees_Employees.AutoFilterLookupColumns = False
            Me.DataGridViewSelectEmployees_Employees.AutoloadRepositoryDatasource = True
            Me.DataGridViewSelectEmployees_Employees.AutoUpdateViewCaption = True
            Me.DataGridViewSelectEmployees_Employees.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewSelectEmployees_Employees.DataSource = Nothing
            Me.DataGridViewSelectEmployees_Employees.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewSelectEmployees_Employees.Enabled = False
            Me.DataGridViewSelectEmployees_Employees.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSelectEmployees_Employees.ItemDescription = "Employee(s)"
            Me.DataGridViewSelectEmployees_Employees.Location = New System.Drawing.Point(4, 30)
            Me.DataGridViewSelectEmployees_Employees.MultiSelect = True
            Me.DataGridViewSelectEmployees_Employees.Name = "DataGridViewSelectEmployees_Employees"
            Me.DataGridViewSelectEmployees_Employees.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSelectEmployees_Employees.RunStandardValidation = True
            Me.DataGridViewSelectEmployees_Employees.ShowColumnMenuOnRightClick = False
            Me.DataGridViewSelectEmployees_Employees.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSelectEmployees_Employees.Size = New System.Drawing.Size(1009, 536)
            Me.DataGridViewSelectEmployees_Employees.TabIndex = 3
            Me.DataGridViewSelectEmployees_Employees.UseEmbeddedNavigator = False
            Me.DataGridViewSelectEmployees_Employees.ViewCaptionHeight = -1
            '
            'RadioButtonSelectEmployees_ChooseEmployees
            '
            Me.RadioButtonSelectEmployees_ChooseEmployees.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectEmployees_ChooseEmployees.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectEmployees_ChooseEmployees.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectEmployees_ChooseEmployees.Location = New System.Drawing.Point(111, 4)
            Me.RadioButtonSelectEmployees_ChooseEmployees.Name = "RadioButtonSelectEmployees_ChooseEmployees"
            Me.RadioButtonSelectEmployees_ChooseEmployees.SecurityEnabled = True
            Me.RadioButtonSelectEmployees_ChooseEmployees.Size = New System.Drawing.Size(138, 20)
            Me.RadioButtonSelectEmployees_ChooseEmployees.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectEmployees_ChooseEmployees.TabIndex = 2
            Me.RadioButtonSelectEmployees_ChooseEmployees.TabOnEnter = True
            Me.RadioButtonSelectEmployees_ChooseEmployees.TabStop = False
            Me.RadioButtonSelectEmployees_ChooseEmployees.Text = "Choose Employees"
            '
            'RadioButtonSelectEmployees_AllEmployees
            '
            Me.RadioButtonSelectEmployees_AllEmployees.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectEmployees_AllEmployees.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectEmployees_AllEmployees.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectEmployees_AllEmployees.Checked = True
            Me.RadioButtonSelectEmployees_AllEmployees.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonSelectEmployees_AllEmployees.CheckValue = "Y"
            Me.RadioButtonSelectEmployees_AllEmployees.Location = New System.Drawing.Point(4, 4)
            Me.RadioButtonSelectEmployees_AllEmployees.Name = "RadioButtonSelectEmployees_AllEmployees"
            Me.RadioButtonSelectEmployees_AllEmployees.SecurityEnabled = True
            Me.RadioButtonSelectEmployees_AllEmployees.Size = New System.Drawing.Size(101, 20)
            Me.RadioButtonSelectEmployees_AllEmployees.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectEmployees_AllEmployees.TabIndex = 1
            Me.RadioButtonSelectEmployees_AllEmployees.TabOnEnter = True
            Me.RadioButtonSelectEmployees_AllEmployees.Text = "All Employees"
            '
            'TabItemJDA_SelectEmployeesTab
            '
            Me.TabItemJDA_SelectEmployeesTab.AttachedControl = Me.TabControlPanel4
            Me.TabItemJDA_SelectEmployeesTab.Name = "TabItemJDA_SelectEmployeesTab"
            Me.TabItemJDA_SelectEmployeesTab.Text = "Select Employees"
            '
            'LabelForm_Office
            '
            Me.LabelForm_Office.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Office.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Office.Location = New System.Drawing.Point(11, 66)
            Me.LabelForm_Office.Name = "LabelForm_Office"
            Me.LabelForm_Office.Size = New System.Drawing.Size(70, 20)
            Me.LabelForm_Office.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Office.TabIndex = 65
            Me.LabelForm_Office.Text = "Office:"
            '
            'ComboBoxForm_Offices
            '
            Me.ComboBoxForm_Offices.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Offices.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_Offices.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Offices.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Offices.AutoFindItemInDataSource = False
            Me.ComboBoxForm_Offices.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Offices.BookmarkingEnabled = False
            Me.ComboBoxForm_Offices.ClientCode = ""
            Me.ComboBoxForm_Offices.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Office
            Me.ComboBoxForm_Offices.DisableMouseWheel = False
            Me.ComboBoxForm_Offices.DisplayMember = "Name"
            Me.ComboBoxForm_Offices.DisplayName = ""
            Me.ComboBoxForm_Offices.DivisionCode = ""
            Me.ComboBoxForm_Offices.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Offices.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_Offices.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_Offices.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Offices.FocusHighlightEnabled = True
            Me.ComboBoxForm_Offices.FormattingEnabled = True
            Me.ComboBoxForm_Offices.ItemHeight = 14
            Me.ComboBoxForm_Offices.Location = New System.Drawing.Point(87, 66)
            Me.ComboBoxForm_Offices.Name = "ComboBoxForm_Offices"
            Me.ComboBoxForm_Offices.ReadOnly = False
            Me.ComboBoxForm_Offices.SecurityEnabled = True
            Me.ComboBoxForm_Offices.Size = New System.Drawing.Size(191, 20)
            Me.ComboBoxForm_Offices.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Offices.TabIndex = 64
            Me.ComboBoxForm_Offices.TabOnEnter = True
            Me.ComboBoxForm_Offices.ValueMember = "Code"
            Me.ComboBoxForm_Offices.WatermarkText = "Select Office"
            '
            'LabelForm_Employee
            '
            Me.LabelForm_Employee.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Employee.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Employee.Location = New System.Drawing.Point(11, 40)
            Me.LabelForm_Employee.Name = "LabelForm_Employee"
            Me.LabelForm_Employee.Size = New System.Drawing.Size(70, 20)
            Me.LabelForm_Employee.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Employee.TabIndex = 63
            Me.LabelForm_Employee.Text = "Employee:"
            '
            'ComboBoxForm_Employees
            '
            Me.ComboBoxForm_Employees.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Employees.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_Employees.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Employees.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Employees.AutoFindItemInDataSource = False
            Me.ComboBoxForm_Employees.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Employees.BookmarkingEnabled = False
            Me.ComboBoxForm_Employees.ClientCode = ""
            Me.ComboBoxForm_Employees.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Employee
            Me.ComboBoxForm_Employees.DisableMouseWheel = False
            Me.ComboBoxForm_Employees.DisplayMember = "FullName"
            Me.ComboBoxForm_Employees.DisplayName = ""
            Me.ComboBoxForm_Employees.DivisionCode = ""
            Me.ComboBoxForm_Employees.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Employees.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_Employees.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_Employees.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Employees.FocusHighlightEnabled = True
            Me.ComboBoxForm_Employees.FormattingEnabled = True
            Me.ComboBoxForm_Employees.ItemHeight = 14
            Me.ComboBoxForm_Employees.Location = New System.Drawing.Point(87, 40)
            Me.ComboBoxForm_Employees.Name = "ComboBoxForm_Employees"
            Me.ComboBoxForm_Employees.ReadOnly = False
            Me.ComboBoxForm_Employees.SecurityEnabled = True
            Me.ComboBoxForm_Employees.Size = New System.Drawing.Size(191, 20)
            Me.ComboBoxForm_Employees.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Employees.TabIndex = 62
            Me.ComboBoxForm_Employees.TabOnEnter = True
            Me.ComboBoxForm_Employees.ValueMember = "Code"
            Me.ComboBoxForm_Employees.WatermarkText = "Select Employee"
            '
            'LabelForm_StartingPostPeriod
            '
            Me.LabelForm_StartingPostPeriod.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_StartingPostPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_StartingPostPeriod.Location = New System.Drawing.Point(11, 14)
            Me.LabelForm_StartingPostPeriod.Name = "LabelForm_StartingPostPeriod"
            Me.LabelForm_StartingPostPeriod.Size = New System.Drawing.Size(70, 20)
            Me.LabelForm_StartingPostPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_StartingPostPeriod.TabIndex = 48
            Me.LabelForm_StartingPostPeriod.Text = "Post Period:"
            '
            'ComboBoxForm_EndPostPeriod
            '
            Me.ComboBoxForm_EndPostPeriod.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_EndPostPeriod.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_EndPostPeriod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_EndPostPeriod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_EndPostPeriod.AutoFindItemInDataSource = False
            Me.ComboBoxForm_EndPostPeriod.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_EndPostPeriod.BookmarkingEnabled = False
            Me.ComboBoxForm_EndPostPeriod.ClientCode = ""
            Me.ComboBoxForm_EndPostPeriod.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.PostPeriod
            Me.ComboBoxForm_EndPostPeriod.DisableMouseWheel = False
            Me.ComboBoxForm_EndPostPeriod.DisplayMember = "Description"
            Me.ComboBoxForm_EndPostPeriod.DisplayName = ""
            Me.ComboBoxForm_EndPostPeriod.DivisionCode = ""
            Me.ComboBoxForm_EndPostPeriod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_EndPostPeriod.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_EndPostPeriod.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_EndPostPeriod.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_EndPostPeriod.FocusHighlightEnabled = True
            Me.ComboBoxForm_EndPostPeriod.FormattingEnabled = True
            Me.ComboBoxForm_EndPostPeriod.ItemHeight = 14
            Me.ComboBoxForm_EndPostPeriod.Location = New System.Drawing.Point(87, 14)
            Me.ComboBoxForm_EndPostPeriod.Name = "ComboBoxForm_EndPostPeriod"
            Me.ComboBoxForm_EndPostPeriod.ReadOnly = False
            Me.ComboBoxForm_EndPostPeriod.SecurityEnabled = True
            Me.ComboBoxForm_EndPostPeriod.Size = New System.Drawing.Size(191, 20)
            Me.ComboBoxForm_EndPostPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_EndPostPeriod.TabIndex = 49
            Me.ComboBoxForm_EndPostPeriod.TabOnEnter = True
            Me.ComboBoxForm_EndPostPeriod.ValueMember = "Code"
            Me.ComboBoxForm_EndPostPeriod.WatermarkText = "Select Post Period"
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.TabControlForm_JDA)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Panel1.Location = New System.Drawing.Point(0, 38)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(1041, 606)
            Me.Panel1.TabIndex = 12
            '
            'PanelForm_Bottom
            '
            Me.PanelForm_Bottom.Controls.Add(Me.ButtonForm_OK)
            Me.PanelForm_Bottom.Controls.Add(Me.ButtonForm_Cancel)
            Me.PanelForm_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.PanelForm_Bottom.Location = New System.Drawing.Point(0, 644)
            Me.PanelForm_Bottom.Name = "PanelForm_Bottom"
            Me.PanelForm_Bottom.Size = New System.Drawing.Size(1041, 43)
            Me.PanelForm_Bottom.TabIndex = 13
            '
            'EmployeeTimeAnalysisInitialLoadingDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1041, 687)
            Me.Controls.Add(Me.Panel1)
            Me.Controls.Add(Me.PanelForm_Bottom)
            Me.Controls.Add(Me.PanelForm_TopSection)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "EmployeeTimeAnalysisInitialLoadingDialog"
            Me.Text = "Employee Time Analysis Initial Criteria"
            Me.PanelForm_TopSection.ResumeLayout(False)
            CType(Me.TabControlForm_JDA, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_JDA.ResumeLayout(False)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.ResumeLayout(False)
            Me.GroupBox2.ResumeLayout(False)
            CType(Me.DateTimePickerForm_To, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerForm_From, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelSelectOfficesTab_SelectOffices.ResumeLayout(False)
            Me.TabControlPanel2.ResumeLayout(False)
            Me.TabControlPanel4.ResumeLayout(False)
            Me.Panel1.ResumeLayout(False)
            Me.PanelForm_Bottom.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents PanelForm_TopSection As Windows.Forms.Panel
        Friend WithEvents LabelTopSection_ReportSeries As WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxTopSection_Report As WinForm.Presentation.Controls.ComboBox
        Friend WithEvents TabControlForm_JDA As WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelVersionAndOptionsTab_VersionAndOptions As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemJDA_VersionAndOptionsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelSelectOfficesTab_SelectOffices As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewSelectOffices_Offices As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RadioButtonSelectOffices_AllOffices As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSelectOffices_ChooseOffices As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents TabItemJDA_SelectOfficesTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents Panel1 As Windows.Forms.Panel
        Friend WithEvents PanelForm_Bottom As Windows.Forms.Panel
        Friend WithEvents LabelForm_StartingPostPeriod As WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_EndPostPeriod As WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxTopSection_ReportSeries As WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelTopSection_Report As WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_Employees As WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_Employee As WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Office As WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_Offices As WinForm.Presentation.Controls.ComboBox
        Friend WithEvents DataGridViewSelectDepartments_Departments As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RadioButtonSelectDepartments_ChooseDepartments As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSelectDepartments_AllDepartments As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents TabItemJDA_SelectDepartmentsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanel2 As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabControlPanel4 As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewSelectEmployees_Employees As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RadioButtonSelectEmployees_ChooseEmployees As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSelectEmployees_AllEmployees As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents TabItemJDA_SelectEmployeesTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents LabelForm_To As WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_From As WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerForm_To As WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerForm_From As WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents CheckBoxForm_Actualized As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
        Friend WithEvents RadioButtonControl_Month As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControl_Day As WinForm.Presentation.Controls.RadioButtonControl
    End Class

End Namespace
