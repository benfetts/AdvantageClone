Namespace Reporting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class DirectTimeInitialLoadingDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DirectTimeInitialLoadingDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.PanelForm_TopSection = New System.Windows.Forms.Panel()
            Me.LabelTopSection_Report = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxTopSection_Report = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.TabControlForm_JDA = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions = New DevComponents.DotNetBar.TabControlPanel()
            Me.CheckBox_OnlyActiveEmployees = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.ComboBoxForm_Criteria = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.CheckBoxFrom_IncludeMarkup = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.ButtonInvoiceDate_2Year = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonInvoiceDate_1Year = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonInvoiceDate_MTD = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonInvoiceDate_YTD = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_To = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_From = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DateTimePickerForm_To = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerForm_From = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelForm_DateType = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemJDA_VersionAndOptionsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanel5 = New DevComponents.DotNetBar.TabControlPanel()
            Me.TabControlPanel7 = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridView_Functions = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonControl_AllFunctions = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControl_ChooseFunctions = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TabItemJDA_SelectFunctionsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanel4 = New DevComponents.DotNetBar.TabControlPanel()
            Me.TabControlPanel6 = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridView_Employees = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonControl_AllEmployees = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControl_ChooseEmployees = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TabItemJDA_SelectEmployeesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanel3 = New DevComponents.DotNetBar.TabControlPanel()
            Me.TabControlPanelSelectAccountExecutivesTab_SelectAccountExecutives = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewSelectDepartments_Departments = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonSelectDepartments_AllDepartments = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectDepartments_ChooseDepartments = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TabItemJDA_SelectDepartmentsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlSelectClientsTab_SelectClients = New DevComponents.DotNetBar.TabControlPanel()
            Me.CDPChooserControlSelectClients_SelectClients = New AdvantageFramework.WinForm.Presentation.Controls.CDPChooserControl()
            Me.TabItemJDA_SelectClientsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel()
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridView_Campaigns = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonSelectCampaigns_AllCampaigns = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectCampaigns_ChooseCampaigns = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TabItemJDA_SelectCampaignsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanel2 = New DevComponents.DotNetBar.TabControlPanel()
            Me.TabControlPanelSelectJobsTab_SelectJobs = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelSelectJobs_JobStatus = New System.Windows.Forms.Panel()
            Me.RadioButtonJobStatus_OpenJobs = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonJobStatus_OpenClosedJobs = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.DataGridViewSelectJobs_Jobs = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonSelectJobs_AllJobs = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectJobs_ChooseJobs = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TabItemJDA_SelectJobsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.PanelForm_Bottom = New System.Windows.Forms.Panel()
            Me.PanelForm_TopSection.SuspendLayout()
            CType(Me.TabControlForm_JDA, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_JDA.SuspendLayout()
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.SuspendLayout()
            CType(Me.DateTimePickerForm_To, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerForm_From, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanel5.SuspendLayout()
            Me.TabControlPanel7.SuspendLayout()
            Me.TabControlPanel4.SuspendLayout()
            Me.TabControlPanel6.SuspendLayout()
            Me.TabControlPanel3.SuspendLayout()
            Me.TabControlPanelSelectAccountExecutivesTab_SelectAccountExecutives.SuspendLayout()
            Me.TabControlSelectClientsTab_SelectClients.SuspendLayout()
            Me.TabControlPanel1.SuspendLayout()
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.SuspendLayout()
            Me.TabControlPanel2.SuspendLayout()
            Me.TabControlPanelSelectJobsTab_SelectJobs.SuspendLayout()
            Me.PanelSelectJobs_JobStatus.SuspendLayout()
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
            Me.PanelForm_TopSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_TopSection.Name = "PanelForm_TopSection"
            Me.PanelForm_TopSection.Size = New System.Drawing.Size(1041, 37)
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
            Me.LabelTopSection_Report.Location = New System.Drawing.Point(12, 12)
            Me.LabelTopSection_Report.Name = "LabelTopSection_Report"
            Me.LabelTopSection_Report.Size = New System.Drawing.Size(106, 20)
            Me.LabelTopSection_Report.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTopSection_Report.TabIndex = 0
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
            Me.ComboBoxTopSection_Report.Location = New System.Drawing.Point(124, 12)
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
            Me.TabControlForm_JDA.Controls.Add(Me.TabControlPanel5)
            Me.TabControlForm_JDA.Controls.Add(Me.TabControlPanel4)
            Me.TabControlForm_JDA.Controls.Add(Me.TabControlPanel3)
            Me.TabControlForm_JDA.Controls.Add(Me.TabControlSelectClientsTab_SelectClients)
            Me.TabControlForm_JDA.Controls.Add(Me.TabControlPanel1)
            Me.TabControlForm_JDA.Controls.Add(Me.TabControlPanel2)
            Me.TabControlForm_JDA.Location = New System.Drawing.Point(12, 3)
            Me.TabControlForm_JDA.Name = "TabControlForm_JDA"
            Me.TabControlForm_JDA.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_JDA.SelectedTabIndex = 0
            Me.TabControlForm_JDA.Size = New System.Drawing.Size(1017, 598)
            Me.TabControlForm_JDA.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_JDA.TabIndex = 37
            Me.TabControlForm_JDA.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_JDA.Tabs.Add(Me.TabItemJDA_VersionAndOptionsTab)
            Me.TabControlForm_JDA.Tabs.Add(Me.TabItemJDA_SelectClientsTab)
            Me.TabControlForm_JDA.Tabs.Add(Me.TabItemJDA_SelectCampaignsTab)
            Me.TabControlForm_JDA.Tabs.Add(Me.TabItemJDA_SelectJobsTab)
            Me.TabControlForm_JDA.Tabs.Add(Me.TabItemJDA_SelectDepartmentsTab)
            Me.TabControlForm_JDA.Tabs.Add(Me.TabItemJDA_SelectEmployeesTab)
            Me.TabControlForm_JDA.Tabs.Add(Me.TabItemJDA_SelectFunctionsTab)
            '
            'TabControlPanelVersionAndOptionsTab_VersionAndOptions
            '
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.CheckBox_OnlyActiveEmployees)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.ComboBoxForm_Criteria)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.CheckBoxFrom_IncludeMarkup)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.ButtonInvoiceDate_2Year)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.ButtonInvoiceDate_1Year)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.ButtonInvoiceDate_MTD)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.ButtonInvoiceDate_YTD)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.LabelForm_To)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.LabelForm_From)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.DateTimePickerForm_To)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.DateTimePickerForm_From)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.LabelForm_DateType)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Name = "TabControlPanelVersionAndOptionsTab_VersionAndOptions"
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Size = New System.Drawing.Size(1017, 571)
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
            'CheckBox_OnlyActiveEmployees
            '
            Me.CheckBox_OnlyActiveEmployees.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBox_OnlyActiveEmployees.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBox_OnlyActiveEmployees.CheckValue = 0
            Me.CheckBox_OnlyActiveEmployees.CheckValueChecked = 1
            Me.CheckBox_OnlyActiveEmployees.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBox_OnlyActiveEmployees.CheckValueUnchecked = 0
            Me.CheckBox_OnlyActiveEmployees.ChildControls = Nothing
            Me.CheckBox_OnlyActiveEmployees.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBox_OnlyActiveEmployees.Location = New System.Drawing.Point(237, 93)
            Me.CheckBox_OnlyActiveEmployees.Name = "CheckBox_OnlyActiveEmployees"
            Me.CheckBox_OnlyActiveEmployees.OldestSibling = Nothing
            Me.CheckBox_OnlyActiveEmployees.SecurityEnabled = True
            Me.CheckBox_OnlyActiveEmployees.SiblingControls = Nothing
            Me.CheckBox_OnlyActiveEmployees.Size = New System.Drawing.Size(136, 20)
            Me.CheckBox_OnlyActiveEmployees.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBox_OnlyActiveEmployees.TabIndex = 44
            Me.CheckBox_OnlyActiveEmployees.TabOnEnter = True
            Me.CheckBox_OnlyActiveEmployees.Text = "Only Active Employees"
            '
            'ComboBoxForm_Criteria
            '
            Me.ComboBoxForm_Criteria.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Criteria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Criteria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Criteria.AutoFindItemInDataSource = False
            Me.ComboBoxForm_Criteria.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Criteria.BookmarkingEnabled = False
            Me.ComboBoxForm_Criteria.ClientCode = ""
            Me.ComboBoxForm_Criteria.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumDataTable
            Me.ComboBoxForm_Criteria.DisableMouseWheel = False
            Me.ComboBoxForm_Criteria.DisplayMember = "Name"
            Me.ComboBoxForm_Criteria.DisplayName = ""
            Me.ComboBoxForm_Criteria.DivisionCode = ""
            Me.ComboBoxForm_Criteria.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Criteria.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_Criteria.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_Criteria.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Criteria.FocusHighlightEnabled = True
            Me.ComboBoxForm_Criteria.FormattingEnabled = True
            Me.ComboBoxForm_Criteria.ItemHeight = 14
            Me.ComboBoxForm_Criteria.Location = New System.Drawing.Point(87, 14)
            Me.ComboBoxForm_Criteria.Name = "ComboBoxForm_Criteria"
            Me.ComboBoxForm_Criteria.ReadOnly = False
            Me.ComboBoxForm_Criteria.SecurityEnabled = True
            Me.ComboBoxForm_Criteria.Size = New System.Drawing.Size(286, 20)
            Me.ComboBoxForm_Criteria.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Criteria.TabIndex = 43
            Me.ComboBoxForm_Criteria.TabOnEnter = True
            Me.ComboBoxForm_Criteria.ValueMember = "Value"
            Me.ComboBoxForm_Criteria.WatermarkText = "Select"
            '
            'CheckBoxFrom_IncludeMarkup
            '
            Me.CheckBoxFrom_IncludeMarkup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxFrom_IncludeMarkup.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxFrom_IncludeMarkup.CheckValue = 0
            Me.CheckBoxFrom_IncludeMarkup.CheckValueChecked = 1
            Me.CheckBoxFrom_IncludeMarkup.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxFrom_IncludeMarkup.CheckValueUnchecked = 0
            Me.CheckBoxFrom_IncludeMarkup.ChildControls = Nothing
            Me.CheckBoxFrom_IncludeMarkup.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxFrom_IncludeMarkup.Location = New System.Drawing.Point(11, 93)
            Me.CheckBoxFrom_IncludeMarkup.Name = "CheckBoxFrom_IncludeMarkup"
            Me.CheckBoxFrom_IncludeMarkup.OldestSibling = Nothing
            Me.CheckBoxFrom_IncludeMarkup.SecurityEnabled = True
            Me.CheckBoxFrom_IncludeMarkup.SiblingControls = Nothing
            Me.CheckBoxFrom_IncludeMarkup.Size = New System.Drawing.Size(107, 20)
            Me.CheckBoxFrom_IncludeMarkup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxFrom_IncludeMarkup.TabIndex = 42
            Me.CheckBoxFrom_IncludeMarkup.TabOnEnter = True
            Me.CheckBoxFrom_IncludeMarkup.Text = "Include Markup"
            '
            'ButtonInvoiceDate_2Year
            '
            Me.ButtonInvoiceDate_2Year.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonInvoiceDate_2Year.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonInvoiceDate_2Year.Location = New System.Drawing.Point(298, 66)
            Me.ButtonInvoiceDate_2Year.Name = "ButtonInvoiceDate_2Year"
            Me.ButtonInvoiceDate_2Year.SecurityEnabled = True
            Me.ButtonInvoiceDate_2Year.Size = New System.Drawing.Size(75, 20)
            Me.ButtonInvoiceDate_2Year.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonInvoiceDate_2Year.TabIndex = 41
            Me.ButtonInvoiceDate_2Year.Text = "2 Years"
            '
            'ButtonInvoiceDate_1Year
            '
            Me.ButtonInvoiceDate_1Year.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonInvoiceDate_1Year.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonInvoiceDate_1Year.Location = New System.Drawing.Point(298, 40)
            Me.ButtonInvoiceDate_1Year.Name = "ButtonInvoiceDate_1Year"
            Me.ButtonInvoiceDate_1Year.SecurityEnabled = True
            Me.ButtonInvoiceDate_1Year.Size = New System.Drawing.Size(75, 20)
            Me.ButtonInvoiceDate_1Year.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonInvoiceDate_1Year.TabIndex = 39
            Me.ButtonInvoiceDate_1Year.Text = "1 Year"
            '
            'ButtonInvoiceDate_MTD
            '
            Me.ButtonInvoiceDate_MTD.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonInvoiceDate_MTD.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonInvoiceDate_MTD.Location = New System.Drawing.Point(217, 66)
            Me.ButtonInvoiceDate_MTD.Name = "ButtonInvoiceDate_MTD"
            Me.ButtonInvoiceDate_MTD.SecurityEnabled = True
            Me.ButtonInvoiceDate_MTD.Size = New System.Drawing.Size(75, 20)
            Me.ButtonInvoiceDate_MTD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonInvoiceDate_MTD.TabIndex = 40
            Me.ButtonInvoiceDate_MTD.Text = "MTD"
            '
            'ButtonInvoiceDate_YTD
            '
            Me.ButtonInvoiceDate_YTD.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonInvoiceDate_YTD.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonInvoiceDate_YTD.Location = New System.Drawing.Point(217, 40)
            Me.ButtonInvoiceDate_YTD.Name = "ButtonInvoiceDate_YTD"
            Me.ButtonInvoiceDate_YTD.SecurityEnabled = True
            Me.ButtonInvoiceDate_YTD.Size = New System.Drawing.Size(75, 20)
            Me.ButtonInvoiceDate_YTD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonInvoiceDate_YTD.TabIndex = 38
            Me.ButtonInvoiceDate_YTD.Text = "YTD"
            '
            'LabelForm_To
            '
            Me.LabelForm_To.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_To.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_To.Location = New System.Drawing.Point(11, 66)
            Me.LabelForm_To.Name = "LabelForm_To"
            Me.LabelForm_To.Size = New System.Drawing.Size(70, 20)
            Me.LabelForm_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_To.TabIndex = 35
            Me.LabelForm_To.Text = "To:"
            '
            'LabelForm_From
            '
            Me.LabelForm_From.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_From.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_From.Location = New System.Drawing.Point(11, 40)
            Me.LabelForm_From.Name = "LabelForm_From"
            Me.LabelForm_From.Size = New System.Drawing.Size(70, 20)
            Me.LabelForm_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_From.TabIndex = 33
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
            Me.DateTimePickerForm_To.Location = New System.Drawing.Point(87, 66)
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
            Me.DateTimePickerForm_To.TabIndex = 36
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
            Me.DateTimePickerForm_From.Location = New System.Drawing.Point(87, 40)
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
            Me.DateTimePickerForm_From.TabIndex = 34
            Me.DateTimePickerForm_From.TabOnEnter = True
            Me.DateTimePickerForm_From.Value = New Date(1850, 1, 1, 0, 0, 0, 0)
            '
            'LabelForm_DateType
            '
            Me.LabelForm_DateType.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_DateType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_DateType.Location = New System.Drawing.Point(11, 14)
            Me.LabelForm_DateType.Name = "LabelForm_DateType"
            Me.LabelForm_DateType.Size = New System.Drawing.Size(83, 20)
            Me.LabelForm_DateType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_DateType.TabIndex = 0
            Me.LabelForm_DateType.Text = "Criteria:"
            '
            'TabItemJDA_VersionAndOptionsTab
            '
            Me.TabItemJDA_VersionAndOptionsTab.AttachedControl = Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions
            Me.TabItemJDA_VersionAndOptionsTab.Name = "TabItemJDA_VersionAndOptionsTab"
            Me.TabItemJDA_VersionAndOptionsTab.Text = "Report Options"
            '
            'TabControlPanel5
            '
            Me.TabControlPanel5.Controls.Add(Me.TabControlPanel7)
            Me.TabControlPanel5.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanel5.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanel5.Name = "TabControlPanel5"
            Me.TabControlPanel5.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanel5.Size = New System.Drawing.Size(1017, 571)
            Me.TabControlPanel5.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanel5.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanel5.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanel5.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanel5.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanel5.Style.GradientAngle = 90
            Me.TabControlPanel5.TabIndex = 41
            Me.TabControlPanel5.TabItem = Me.TabItemJDA_SelectFunctionsTab
            '
            'TabControlPanel7
            '
            Me.TabControlPanel7.Controls.Add(Me.DataGridView_Functions)
            Me.TabControlPanel7.Controls.Add(Me.RadioButtonControl_AllFunctions)
            Me.TabControlPanel7.Controls.Add(Me.RadioButtonControl_ChooseFunctions)
            Me.TabControlPanel7.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanel7.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanel7.Location = New System.Drawing.Point(1, 1)
            Me.TabControlPanel7.Name = "TabControlPanel7"
            Me.TabControlPanel7.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanel7.Size = New System.Drawing.Size(1015, 569)
            Me.TabControlPanel7.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanel7.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanel7.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanel7.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanel7.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanel7.Style.GradientAngle = 90
            Me.TabControlPanel7.TabIndex = 12
            '
            'DataGridView_Functions
            '
            Me.DataGridView_Functions.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridView_Functions.AllowDragAndDrop = False
            Me.DataGridView_Functions.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridView_Functions.AllowSelectGroupHeaderRow = True
            Me.DataGridView_Functions.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridView_Functions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridView_Functions.AutoFilterLookupColumns = False
            Me.DataGridView_Functions.AutoloadRepositoryDatasource = True
            Me.DataGridView_Functions.AutoUpdateViewCaption = True
            Me.DataGridView_Functions.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridView_Functions.DataSource = Nothing
            Me.DataGridView_Functions.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridView_Functions.Enabled = False
            Me.DataGridView_Functions.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridView_Functions.ItemDescription = "Function(s)"
            Me.DataGridView_Functions.Location = New System.Drawing.Point(4, 30)
            Me.DataGridView_Functions.MultiSelect = True
            Me.DataGridView_Functions.Name = "DataGridView_Functions"
            Me.DataGridView_Functions.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridView_Functions.RunStandardValidation = True
            Me.DataGridView_Functions.ShowColumnMenuOnRightClick = False
            Me.DataGridView_Functions.ShowSelectDeselectAllButtons = False
            Me.DataGridView_Functions.Size = New System.Drawing.Size(1007, 535)
            Me.DataGridView_Functions.TabIndex = 2
            Me.DataGridView_Functions.UseEmbeddedNavigator = False
            Me.DataGridView_Functions.ViewCaptionHeight = -1
            '
            'RadioButtonControl_AllFunctions
            '
            Me.RadioButtonControl_AllFunctions.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControl_AllFunctions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControl_AllFunctions.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControl_AllFunctions.Checked = True
            Me.RadioButtonControl_AllFunctions.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonControl_AllFunctions.CheckValue = "Y"
            Me.RadioButtonControl_AllFunctions.Location = New System.Drawing.Point(4, 4)
            Me.RadioButtonControl_AllFunctions.Name = "RadioButtonControl_AllFunctions"
            Me.RadioButtonControl_AllFunctions.SecurityEnabled = True
            Me.RadioButtonControl_AllFunctions.Size = New System.Drawing.Size(136, 20)
            Me.RadioButtonControl_AllFunctions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControl_AllFunctions.TabIndex = 0
            Me.RadioButtonControl_AllFunctions.TabOnEnter = True
            Me.RadioButtonControl_AllFunctions.Text = "All Functions"
            '
            'RadioButtonControl_ChooseFunctions
            '
            Me.RadioButtonControl_ChooseFunctions.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControl_ChooseFunctions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControl_ChooseFunctions.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControl_ChooseFunctions.Location = New System.Drawing.Point(146, 4)
            Me.RadioButtonControl_ChooseFunctions.Name = "RadioButtonControl_ChooseFunctions"
            Me.RadioButtonControl_ChooseFunctions.SecurityEnabled = True
            Me.RadioButtonControl_ChooseFunctions.Size = New System.Drawing.Size(164, 20)
            Me.RadioButtonControl_ChooseFunctions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControl_ChooseFunctions.TabIndex = 1
            Me.RadioButtonControl_ChooseFunctions.TabOnEnter = True
            Me.RadioButtonControl_ChooseFunctions.TabStop = False
            Me.RadioButtonControl_ChooseFunctions.Text = "Choose Functions"
            '
            'TabItemJDA_SelectFunctionsTab
            '
            Me.TabItemJDA_SelectFunctionsTab.AttachedControl = Me.TabControlPanel5
            Me.TabItemJDA_SelectFunctionsTab.Name = "TabItemJDA_SelectFunctionsTab"
            Me.TabItemJDA_SelectFunctionsTab.Text = "Select Functions"
            '
            'TabControlPanel4
            '
            Me.TabControlPanel4.Controls.Add(Me.TabControlPanel6)
            Me.TabControlPanel4.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanel4.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanel4.Name = "TabControlPanel4"
            Me.TabControlPanel4.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanel4.Size = New System.Drawing.Size(1017, 571)
            Me.TabControlPanel4.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanel4.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanel4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanel4.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanel4.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanel4.Style.GradientAngle = 90
            Me.TabControlPanel4.TabIndex = 37
            Me.TabControlPanel4.TabItem = Me.TabItemJDA_SelectEmployeesTab
            '
            'TabControlPanel6
            '
            Me.TabControlPanel6.Controls.Add(Me.DataGridView_Employees)
            Me.TabControlPanel6.Controls.Add(Me.RadioButtonControl_AllEmployees)
            Me.TabControlPanel6.Controls.Add(Me.RadioButtonControl_ChooseEmployees)
            Me.TabControlPanel6.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanel6.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanel6.Location = New System.Drawing.Point(1, 1)
            Me.TabControlPanel6.Name = "TabControlPanel6"
            Me.TabControlPanel6.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanel6.Size = New System.Drawing.Size(1015, 569)
            Me.TabControlPanel6.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanel6.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanel6.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanel6.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanel6.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanel6.Style.GradientAngle = 90
            Me.TabControlPanel6.TabIndex = 8
            '
            'DataGridView_Employees
            '
            Me.DataGridView_Employees.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridView_Employees.AllowDragAndDrop = False
            Me.DataGridView_Employees.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridView_Employees.AllowSelectGroupHeaderRow = True
            Me.DataGridView_Employees.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridView_Employees.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridView_Employees.AutoFilterLookupColumns = False
            Me.DataGridView_Employees.AutoloadRepositoryDatasource = True
            Me.DataGridView_Employees.AutoUpdateViewCaption = True
            Me.DataGridView_Employees.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridView_Employees.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridView_Employees.Enabled = False
            Me.DataGridView_Employees.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridView_Employees.ItemDescription = "Employee(s)"
            Me.DataGridView_Employees.Location = New System.Drawing.Point(4, 30)
            Me.DataGridView_Employees.MultiSelect = True
            Me.DataGridView_Employees.Name = "DataGridView_Employees"
            Me.DataGridView_Employees.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridView_Employees.RunStandardValidation = True
            Me.DataGridView_Employees.ShowColumnMenuOnRightClick = False
            Me.DataGridView_Employees.ShowSelectDeselectAllButtons = False
            Me.DataGridView_Employees.Size = New System.Drawing.Size(1007, 535)
            Me.DataGridView_Employees.TabIndex = 2
            Me.DataGridView_Employees.UseEmbeddedNavigator = False
            Me.DataGridView_Employees.ViewCaptionHeight = -1
            '
            'RadioButtonControl_AllEmployees
            '
            Me.RadioButtonControl_AllEmployees.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControl_AllEmployees.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControl_AllEmployees.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControl_AllEmployees.Checked = True
            Me.RadioButtonControl_AllEmployees.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonControl_AllEmployees.CheckValue = "Y"
            Me.RadioButtonControl_AllEmployees.Location = New System.Drawing.Point(4, 4)
            Me.RadioButtonControl_AllEmployees.Name = "RadioButtonControl_AllEmployees"
            Me.RadioButtonControl_AllEmployees.SecurityEnabled = True
            Me.RadioButtonControl_AllEmployees.Size = New System.Drawing.Size(136, 20)
            Me.RadioButtonControl_AllEmployees.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControl_AllEmployees.TabIndex = 0
            Me.RadioButtonControl_AllEmployees.TabOnEnter = True
            Me.RadioButtonControl_AllEmployees.Text = "All Employees"
            '
            'RadioButtonControl_ChooseEmployees
            '
            Me.RadioButtonControl_ChooseEmployees.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControl_ChooseEmployees.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControl_ChooseEmployees.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControl_ChooseEmployees.Location = New System.Drawing.Point(146, 4)
            Me.RadioButtonControl_ChooseEmployees.Name = "RadioButtonControl_ChooseEmployees"
            Me.RadioButtonControl_ChooseEmployees.SecurityEnabled = True
            Me.RadioButtonControl_ChooseEmployees.Size = New System.Drawing.Size(164, 20)
            Me.RadioButtonControl_ChooseEmployees.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControl_ChooseEmployees.TabIndex = 1
            Me.RadioButtonControl_ChooseEmployees.TabOnEnter = True
            Me.RadioButtonControl_ChooseEmployees.TabStop = False
            Me.RadioButtonControl_ChooseEmployees.Text = "Choose Employees"
            '
            'TabItemJDA_SelectEmployeesTab
            '
            Me.TabItemJDA_SelectEmployeesTab.AttachedControl = Me.TabControlPanel4
            Me.TabItemJDA_SelectEmployeesTab.Name = "TabItemJDA_SelectEmployeesTab"
            Me.TabItemJDA_SelectEmployeesTab.Text = "Select Employees"
            '
            'TabControlPanel3
            '
            Me.TabControlPanel3.Controls.Add(Me.TabControlPanelSelectAccountExecutivesTab_SelectAccountExecutives)
            Me.TabControlPanel3.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanel3.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanel3.Name = "TabControlPanel3"
            Me.TabControlPanel3.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanel3.Size = New System.Drawing.Size(1017, 571)
            Me.TabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanel3.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanel3.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanel3.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanel3.Style.GradientAngle = 90
            Me.TabControlPanel3.TabIndex = 33
            Me.TabControlPanel3.TabItem = Me.TabItemJDA_SelectDepartmentsTab
            '
            'TabControlPanelSelectAccountExecutivesTab_SelectAccountExecutives
            '
            Me.TabControlPanelSelectAccountExecutivesTab_SelectAccountExecutives.Controls.Add(Me.DataGridViewSelectDepartments_Departments)
            Me.TabControlPanelSelectAccountExecutivesTab_SelectAccountExecutives.Controls.Add(Me.RadioButtonSelectDepartments_AllDepartments)
            Me.TabControlPanelSelectAccountExecutivesTab_SelectAccountExecutives.Controls.Add(Me.RadioButtonSelectDepartments_ChooseDepartments)
            Me.TabControlPanelSelectAccountExecutivesTab_SelectAccountExecutives.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSelectAccountExecutivesTab_SelectAccountExecutives.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSelectAccountExecutivesTab_SelectAccountExecutives.Location = New System.Drawing.Point(1, 1)
            Me.TabControlPanelSelectAccountExecutivesTab_SelectAccountExecutives.Name = "TabControlPanelSelectAccountExecutivesTab_SelectAccountExecutives"
            Me.TabControlPanelSelectAccountExecutivesTab_SelectAccountExecutives.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSelectAccountExecutivesTab_SelectAccountExecutives.Size = New System.Drawing.Size(1015, 569)
            Me.TabControlPanelSelectAccountExecutivesTab_SelectAccountExecutives.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelSelectAccountExecutivesTab_SelectAccountExecutives.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSelectAccountExecutivesTab_SelectAccountExecutives.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSelectAccountExecutivesTab_SelectAccountExecutives.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSelectAccountExecutivesTab_SelectAccountExecutives.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSelectAccountExecutivesTab_SelectAccountExecutives.Style.GradientAngle = 90
            Me.TabControlPanelSelectAccountExecutivesTab_SelectAccountExecutives.TabIndex = 4
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
            Me.DataGridViewSelectDepartments_Departments.ItemDescription = "Department/Team(s)"
            Me.DataGridViewSelectDepartments_Departments.Location = New System.Drawing.Point(4, 30)
            Me.DataGridViewSelectDepartments_Departments.MultiSelect = True
            Me.DataGridViewSelectDepartments_Departments.Name = "DataGridViewSelectDepartments_Departments"
            Me.DataGridViewSelectDepartments_Departments.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSelectDepartments_Departments.RunStandardValidation = True
            Me.DataGridViewSelectDepartments_Departments.ShowColumnMenuOnRightClick = False
            Me.DataGridViewSelectDepartments_Departments.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSelectDepartments_Departments.Size = New System.Drawing.Size(1007, 535)
            Me.DataGridViewSelectDepartments_Departments.TabIndex = 2
            Me.DataGridViewSelectDepartments_Departments.UseEmbeddedNavigator = False
            Me.DataGridViewSelectDepartments_Departments.ViewCaptionHeight = -1
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
            Me.RadioButtonSelectDepartments_AllDepartments.Size = New System.Drawing.Size(136, 20)
            Me.RadioButtonSelectDepartments_AllDepartments.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectDepartments_AllDepartments.TabIndex = 0
            Me.RadioButtonSelectDepartments_AllDepartments.TabOnEnter = True
            Me.RadioButtonSelectDepartments_AllDepartments.Text = "All Department/Team"
            '
            'RadioButtonSelectDepartments_ChooseDepartments
            '
            Me.RadioButtonSelectDepartments_ChooseDepartments.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectDepartments_ChooseDepartments.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectDepartments_ChooseDepartments.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectDepartments_ChooseDepartments.Location = New System.Drawing.Point(146, 4)
            Me.RadioButtonSelectDepartments_ChooseDepartments.Name = "RadioButtonSelectDepartments_ChooseDepartments"
            Me.RadioButtonSelectDepartments_ChooseDepartments.SecurityEnabled = True
            Me.RadioButtonSelectDepartments_ChooseDepartments.Size = New System.Drawing.Size(164, 20)
            Me.RadioButtonSelectDepartments_ChooseDepartments.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectDepartments_ChooseDepartments.TabIndex = 1
            Me.RadioButtonSelectDepartments_ChooseDepartments.TabOnEnter = True
            Me.RadioButtonSelectDepartments_ChooseDepartments.TabStop = False
            Me.RadioButtonSelectDepartments_ChooseDepartments.Text = "Choose Department/Team"
            '
            'TabItemJDA_SelectDepartmentsTab
            '
            Me.TabItemJDA_SelectDepartmentsTab.AttachedControl = Me.TabControlPanel3
            Me.TabItemJDA_SelectDepartmentsTab.Name = "TabItemJDA_SelectDepartmentsTab"
            Me.TabItemJDA_SelectDepartmentsTab.Text = "Select Department/Team"
            '
            'TabControlSelectClientsTab_SelectClients
            '
            Me.TabControlSelectClientsTab_SelectClients.Controls.Add(Me.CDPChooserControlSelectClients_SelectClients)
            Me.TabControlSelectClientsTab_SelectClients.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlSelectClientsTab_SelectClients.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlSelectClientsTab_SelectClients.Location = New System.Drawing.Point(0, 27)
            Me.TabControlSelectClientsTab_SelectClients.Name = "TabControlSelectClientsTab_SelectClients"
            Me.TabControlSelectClientsTab_SelectClients.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlSelectClientsTab_SelectClients.Size = New System.Drawing.Size(1017, 571)
            Me.TabControlSelectClientsTab_SelectClients.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlSelectClientsTab_SelectClients.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlSelectClientsTab_SelectClients.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlSelectClientsTab_SelectClients.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlSelectClientsTab_SelectClients.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlSelectClientsTab_SelectClients.Style.GradientAngle = 90
            Me.TabControlSelectClientsTab_SelectClients.TabIndex = 3
            Me.TabControlSelectClientsTab_SelectClients.TabItem = Me.TabItemJDA_SelectClientsTab
            '
            'CDPChooserControlSelectClients_SelectClients
            '
            Me.CDPChooserControlSelectClients_SelectClients.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CDPChooserControlSelectClients_SelectClients.BackColor = System.Drawing.Color.Transparent
            Me.CDPChooserControlSelectClients_SelectClients.Location = New System.Drawing.Point(4, 4)
            Me.CDPChooserControlSelectClients_SelectClients.Name = "CDPChooserControlSelectClients_SelectClients"
            Me.CDPChooserControlSelectClients_SelectClients.Size = New System.Drawing.Size(1009, 563)
            Me.CDPChooserControlSelectClients_SelectClients.TabIndex = 1
            '
            'TabItemJDA_SelectClientsTab
            '
            Me.TabItemJDA_SelectClientsTab.AttachedControl = Me.TabControlSelectClientsTab_SelectClients
            Me.TabItemJDA_SelectClientsTab.Name = "TabItemJDA_SelectClientsTab"
            Me.TabItemJDA_SelectClientsTab.Text = "Select Clients"
            '
            'TabControlPanel1
            '
            Me.TabControlPanel1.Controls.Add(Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses)
            Me.TabControlPanel1.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanel1.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanel1.Name = "TabControlPanel1"
            Me.TabControlPanel1.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanel1.Size = New System.Drawing.Size(1017, 571)
            Me.TabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanel1.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanel1.Style.GradientAngle = 90
            Me.TabControlPanel1.TabIndex = 10
            Me.TabControlPanel1.TabItem = Me.TabItemJDA_SelectCampaignsTab
            '
            'TabControlPanelSelectSalesClassesTab_SelectSalesClasses
            '
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Controls.Add(Me.DataGridView_Campaigns)
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Controls.Add(Me.RadioButtonSelectCampaigns_AllCampaigns)
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Controls.Add(Me.RadioButtonSelectCampaigns_ChooseCampaigns)
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Location = New System.Drawing.Point(1, 1)
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Name = "TabControlPanelSelectSalesClassesTab_SelectSalesClasses"
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Size = New System.Drawing.Size(1015, 569)
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Style.GradientAngle = 90
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.TabIndex = 8
            '
            'DataGridView_Campaigns
            '
            Me.DataGridView_Campaigns.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridView_Campaigns.AllowDragAndDrop = False
            Me.DataGridView_Campaigns.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridView_Campaigns.AllowSelectGroupHeaderRow = True
            Me.DataGridView_Campaigns.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridView_Campaigns.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridView_Campaigns.AutoFilterLookupColumns = False
            Me.DataGridView_Campaigns.AutoloadRepositoryDatasource = True
            Me.DataGridView_Campaigns.AutoUpdateViewCaption = True
            Me.DataGridView_Campaigns.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridView_Campaigns.DataSource = Nothing
            Me.DataGridView_Campaigns.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridView_Campaigns.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridView_Campaigns.ItemDescription = "Campaign(s)"
            Me.DataGridView_Campaigns.Location = New System.Drawing.Point(2, 30)
            Me.DataGridView_Campaigns.MultiSelect = True
            Me.DataGridView_Campaigns.Name = "DataGridView_Campaigns"
            Me.DataGridView_Campaigns.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridView_Campaigns.RunStandardValidation = True
            Me.DataGridView_Campaigns.ShowColumnMenuOnRightClick = False
            Me.DataGridView_Campaigns.ShowSelectDeselectAllButtons = False
            Me.DataGridView_Campaigns.Size = New System.Drawing.Size(1009, 537)
            Me.DataGridView_Campaigns.TabIndex = 16
            Me.DataGridView_Campaigns.UseEmbeddedNavigator = False
            Me.DataGridView_Campaigns.ViewCaptionHeight = -1
            '
            'RadioButtonSelectCampaigns_AllCampaigns
            '
            Me.RadioButtonSelectCampaigns_AllCampaigns.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectCampaigns_AllCampaigns.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectCampaigns_AllCampaigns.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectCampaigns_AllCampaigns.Checked = True
            Me.RadioButtonSelectCampaigns_AllCampaigns.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonSelectCampaigns_AllCampaigns.CheckValue = "Y"
            Me.RadioButtonSelectCampaigns_AllCampaigns.Location = New System.Drawing.Point(4, 4)
            Me.RadioButtonSelectCampaigns_AllCampaigns.Name = "RadioButtonSelectCampaigns_AllCampaigns"
            Me.RadioButtonSelectCampaigns_AllCampaigns.SecurityEnabled = True
            Me.RadioButtonSelectCampaigns_AllCampaigns.Size = New System.Drawing.Size(113, 20)
            Me.RadioButtonSelectCampaigns_AllCampaigns.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectCampaigns_AllCampaigns.TabIndex = 0
            Me.RadioButtonSelectCampaigns_AllCampaigns.TabOnEnter = True
            Me.RadioButtonSelectCampaigns_AllCampaigns.Text = "All Campaigns"
            '
            'RadioButtonSelectCampaigns_ChooseCampaigns
            '
            Me.RadioButtonSelectCampaigns_ChooseCampaigns.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectCampaigns_ChooseCampaigns.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectCampaigns_ChooseCampaigns.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectCampaigns_ChooseCampaigns.Location = New System.Drawing.Point(123, 4)
            Me.RadioButtonSelectCampaigns_ChooseCampaigns.Name = "RadioButtonSelectCampaigns_ChooseCampaigns"
            Me.RadioButtonSelectCampaigns_ChooseCampaigns.SecurityEnabled = True
            Me.RadioButtonSelectCampaigns_ChooseCampaigns.Size = New System.Drawing.Size(164, 20)
            Me.RadioButtonSelectCampaigns_ChooseCampaigns.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectCampaigns_ChooseCampaigns.TabIndex = 1
            Me.RadioButtonSelectCampaigns_ChooseCampaigns.TabOnEnter = True
            Me.RadioButtonSelectCampaigns_ChooseCampaigns.TabStop = False
            Me.RadioButtonSelectCampaigns_ChooseCampaigns.Text = "Choose Campaigns"
            '
            'TabItemJDA_SelectCampaignsTab
            '
            Me.TabItemJDA_SelectCampaignsTab.AttachedControl = Me.TabControlPanel1
            Me.TabItemJDA_SelectCampaignsTab.Name = "TabItemJDA_SelectCampaignsTab"
            Me.TabItemJDA_SelectCampaignsTab.Text = "Select Campaigns"
            '
            'TabControlPanel2
            '
            Me.TabControlPanel2.Controls.Add(Me.TabControlPanelSelectJobsTab_SelectJobs)
            Me.TabControlPanel2.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanel2.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanel2.Name = "TabControlPanel2"
            Me.TabControlPanel2.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanel2.Size = New System.Drawing.Size(1017, 571)
            Me.TabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanel2.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanel2.Style.GradientAngle = 90
            Me.TabControlPanel2.TabIndex = 20
            Me.TabControlPanel2.TabItem = Me.TabItemJDA_SelectJobsTab
            '
            'TabControlPanelSelectJobsTab_SelectJobs
            '
            Me.TabControlPanelSelectJobsTab_SelectJobs.Controls.Add(Me.PanelSelectJobs_JobStatus)
            Me.TabControlPanelSelectJobsTab_SelectJobs.Controls.Add(Me.DataGridViewSelectJobs_Jobs)
            Me.TabControlPanelSelectJobsTab_SelectJobs.Controls.Add(Me.RadioButtonSelectJobs_AllJobs)
            Me.TabControlPanelSelectJobsTab_SelectJobs.Controls.Add(Me.RadioButtonSelectJobs_ChooseJobs)
            Me.TabControlPanelSelectJobsTab_SelectJobs.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSelectJobsTab_SelectJobs.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSelectJobsTab_SelectJobs.Location = New System.Drawing.Point(1, 1)
            Me.TabControlPanelSelectJobsTab_SelectJobs.Name = "TabControlPanelSelectJobsTab_SelectJobs"
            Me.TabControlPanelSelectJobsTab_SelectJobs.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSelectJobsTab_SelectJobs.Size = New System.Drawing.Size(1015, 569)
            Me.TabControlPanelSelectJobsTab_SelectJobs.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelSelectJobsTab_SelectJobs.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSelectJobsTab_SelectJobs.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSelectJobsTab_SelectJobs.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSelectJobsTab_SelectJobs.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSelectJobsTab_SelectJobs.Style.GradientAngle = 90
            Me.TabControlPanelSelectJobsTab_SelectJobs.TabIndex = 4
            Me.TabControlPanelSelectJobsTab_SelectJobs.TabItem = Me.TabItemJDA_SelectJobsTab
            '
            'PanelSelectJobs_JobStatus
            '
            Me.PanelSelectJobs_JobStatus.BackColor = System.Drawing.Color.White
            Me.PanelSelectJobs_JobStatus.Controls.Add(Me.RadioButtonJobStatus_OpenJobs)
            Me.PanelSelectJobs_JobStatus.Controls.Add(Me.RadioButtonJobStatus_OpenClosedJobs)
            Me.PanelSelectJobs_JobStatus.Enabled = False
            Me.PanelSelectJobs_JobStatus.Location = New System.Drawing.Point(4, 30)
            Me.PanelSelectJobs_JobStatus.Name = "PanelSelectJobs_JobStatus"
            Me.PanelSelectJobs_JobStatus.Size = New System.Drawing.Size(221, 20)
            Me.PanelSelectJobs_JobStatus.TabIndex = 2
            '
            'RadioButtonJobStatus_OpenJobs
            '
            Me.RadioButtonJobStatus_OpenJobs.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonJobStatus_OpenJobs.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonJobStatus_OpenJobs.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonJobStatus_OpenJobs.Checked = True
            Me.RadioButtonJobStatus_OpenJobs.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonJobStatus_OpenJobs.CheckValue = "Y"
            Me.RadioButtonJobStatus_OpenJobs.Location = New System.Drawing.Point(0, 0)
            Me.RadioButtonJobStatus_OpenJobs.Name = "RadioButtonJobStatus_OpenJobs"
            Me.RadioButtonJobStatus_OpenJobs.SecurityEnabled = True
            Me.RadioButtonJobStatus_OpenJobs.Size = New System.Drawing.Size(77, 20)
            Me.RadioButtonJobStatus_OpenJobs.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonJobStatus_OpenJobs.TabIndex = 0
            Me.RadioButtonJobStatus_OpenJobs.TabOnEnter = True
            Me.RadioButtonJobStatus_OpenJobs.Text = "Open Jobs"
            '
            'RadioButtonJobStatus_OpenClosedJobs
            '
            Me.RadioButtonJobStatus_OpenClosedJobs.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonJobStatus_OpenClosedJobs.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonJobStatus_OpenClosedJobs.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonJobStatus_OpenClosedJobs.Location = New System.Drawing.Point(83, 0)
            Me.RadioButtonJobStatus_OpenClosedJobs.Name = "RadioButtonJobStatus_OpenClosedJobs"
            Me.RadioButtonJobStatus_OpenClosedJobs.SecurityEnabled = True
            Me.RadioButtonJobStatus_OpenClosedJobs.Size = New System.Drawing.Size(138, 20)
            Me.RadioButtonJobStatus_OpenClosedJobs.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonJobStatus_OpenClosedJobs.TabIndex = 1
            Me.RadioButtonJobStatus_OpenClosedJobs.TabOnEnter = True
            Me.RadioButtonJobStatus_OpenClosedJobs.TabStop = False
            Me.RadioButtonJobStatus_OpenClosedJobs.Text = "Open/Closed Jobs "
            '
            'DataGridViewSelectJobs_Jobs
            '
            Me.DataGridViewSelectJobs_Jobs.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewSelectJobs_Jobs.AllowDragAndDrop = False
            Me.DataGridViewSelectJobs_Jobs.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewSelectJobs_Jobs.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSelectJobs_Jobs.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewSelectJobs_Jobs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSelectJobs_Jobs.AutoFilterLookupColumns = False
            Me.DataGridViewSelectJobs_Jobs.AutoloadRepositoryDatasource = True
            Me.DataGridViewSelectJobs_Jobs.AutoUpdateViewCaption = True
            Me.DataGridViewSelectJobs_Jobs.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewSelectJobs_Jobs.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewSelectJobs_Jobs.Enabled = False
            Me.DataGridViewSelectJobs_Jobs.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSelectJobs_Jobs.ItemDescription = "Job(s)"
            Me.DataGridViewSelectJobs_Jobs.Location = New System.Drawing.Point(4, 56)
            Me.DataGridViewSelectJobs_Jobs.MultiSelect = True
            Me.DataGridViewSelectJobs_Jobs.Name = "DataGridViewSelectJobs_Jobs"
            Me.DataGridViewSelectJobs_Jobs.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSelectJobs_Jobs.RunStandardValidation = True
            Me.DataGridViewSelectJobs_Jobs.ShowColumnMenuOnRightClick = False
            Me.DataGridViewSelectJobs_Jobs.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSelectJobs_Jobs.Size = New System.Drawing.Size(1007, 509)
            Me.DataGridViewSelectJobs_Jobs.TabIndex = 3
            Me.DataGridViewSelectJobs_Jobs.UseEmbeddedNavigator = False
            Me.DataGridViewSelectJobs_Jobs.ViewCaptionHeight = -1
            '
            'RadioButtonSelectJobs_AllJobs
            '
            Me.RadioButtonSelectJobs_AllJobs.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectJobs_AllJobs.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectJobs_AllJobs.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectJobs_AllJobs.Checked = True
            Me.RadioButtonSelectJobs_AllJobs.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonSelectJobs_AllJobs.CheckValue = "Y"
            Me.RadioButtonSelectJobs_AllJobs.Location = New System.Drawing.Point(4, 4)
            Me.RadioButtonSelectJobs_AllJobs.Name = "RadioButtonSelectJobs_AllJobs"
            Me.RadioButtonSelectJobs_AllJobs.SecurityEnabled = True
            Me.RadioButtonSelectJobs_AllJobs.Size = New System.Drawing.Size(77, 20)
            Me.RadioButtonSelectJobs_AllJobs.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectJobs_AllJobs.TabIndex = 0
            Me.RadioButtonSelectJobs_AllJobs.TabOnEnter = True
            Me.RadioButtonSelectJobs_AllJobs.Text = "All Jobs"
            '
            'RadioButtonSelectJobs_ChooseJobs
            '
            Me.RadioButtonSelectJobs_ChooseJobs.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectJobs_ChooseJobs.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectJobs_ChooseJobs.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectJobs_ChooseJobs.Location = New System.Drawing.Point(87, 4)
            Me.RadioButtonSelectJobs_ChooseJobs.Name = "RadioButtonSelectJobs_ChooseJobs"
            Me.RadioButtonSelectJobs_ChooseJobs.SecurityEnabled = True
            Me.RadioButtonSelectJobs_ChooseJobs.Size = New System.Drawing.Size(138, 20)
            Me.RadioButtonSelectJobs_ChooseJobs.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectJobs_ChooseJobs.TabIndex = 1
            Me.RadioButtonSelectJobs_ChooseJobs.TabOnEnter = True
            Me.RadioButtonSelectJobs_ChooseJobs.TabStop = False
            Me.RadioButtonSelectJobs_ChooseJobs.Text = "Choose Jobs"
            '
            'TabItemJDA_SelectJobsTab
            '
            Me.TabItemJDA_SelectJobsTab.AttachedControl = Me.TabControlPanel2
            Me.TabItemJDA_SelectJobsTab.Name = "TabItemJDA_SelectJobsTab"
            Me.TabItemJDA_SelectJobsTab.Text = "Select Jobs"
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.TabControlForm_JDA)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Panel1.Location = New System.Drawing.Point(0, 37)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(1041, 607)
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
            'DirectTimeInitialLoadingDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1041, 687)
            Me.Controls.Add(Me.Panel1)
            Me.Controls.Add(Me.PanelForm_Bottom)
            Me.Controls.Add(Me.PanelForm_TopSection)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "DirectTimeInitialLoadingDialog"
            Me.Text = "Direct Time Initial Criteria"
            Me.PanelForm_TopSection.ResumeLayout(False)
            CType(Me.TabControlForm_JDA, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_JDA.ResumeLayout(False)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.ResumeLayout(False)
            CType(Me.DateTimePickerForm_To, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerForm_From, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanel5.ResumeLayout(False)
            Me.TabControlPanel7.ResumeLayout(False)
            Me.TabControlPanel4.ResumeLayout(False)
            Me.TabControlPanel6.ResumeLayout(False)
            Me.TabControlPanel3.ResumeLayout(False)
            Me.TabControlPanelSelectAccountExecutivesTab_SelectAccountExecutives.ResumeLayout(False)
            Me.TabControlSelectClientsTab_SelectClients.ResumeLayout(False)
            Me.TabControlPanel1.ResumeLayout(False)
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.ResumeLayout(False)
            Me.TabControlPanel2.ResumeLayout(False)
            Me.TabControlPanelSelectJobsTab_SelectJobs.ResumeLayout(False)
            Me.PanelSelectJobs_JobStatus.ResumeLayout(False)
            Me.Panel1.ResumeLayout(False)
            Me.PanelForm_Bottom.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents PanelForm_TopSection As Windows.Forms.Panel
        Friend WithEvents LabelTopSection_Report As WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxTopSection_Report As WinForm.Presentation.Controls.ComboBox
        Friend WithEvents TabControlForm_JDA As WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelVersionAndOptionsTab_VersionAndOptions As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents LabelForm_To As WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_From As WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerForm_To As WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerForm_From As WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents LabelForm_DateType As WinForm.Presentation.Controls.Label
        Friend WithEvents TabItemJDA_VersionAndOptionsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlSelectClientsTab_SelectClients As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents CDPChooserControlSelectClients_SelectClients As WinForm.Presentation.Controls.CDPChooserControl
        Friend WithEvents TabItemJDA_SelectClientsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents Panel1 As Windows.Forms.Panel
        Friend WithEvents ButtonInvoiceDate_2Year As WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonInvoiceDate_1Year As WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonInvoiceDate_MTD As WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonInvoiceDate_YTD As WinForm.Presentation.Controls.Button
        Friend WithEvents CheckBoxFrom_IncludeMarkup As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents PanelForm_Bottom As Windows.Forms.Panel
        Friend WithEvents ComboBoxForm_Criteria As WinForm.Presentation.Controls.ComboBox
        Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemJDA_SelectCampaignsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelSelectSalesClassesTab_SelectSalesClasses As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridView_Campaigns As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RadioButtonSelectCampaigns_AllCampaigns As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSelectCampaigns_ChooseCampaigns As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents TabControlPanel2 As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemJDA_SelectJobsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelSelectJobsTab_SelectJobs As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents PanelSelectJobs_JobStatus As Windows.Forms.Panel
        Friend WithEvents RadioButtonJobStatus_OpenJobs As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonJobStatus_OpenClosedJobs As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents DataGridViewSelectJobs_Jobs As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RadioButtonSelectJobs_AllJobs As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSelectJobs_ChooseJobs As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents TabControlPanel3 As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemJDA_SelectDepartmentsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanel5 As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemJDA_SelectFunctionsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanel4 As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemJDA_SelectEmployeesTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelSelectAccountExecutivesTab_SelectAccountExecutives As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewSelectDepartments_Departments As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RadioButtonSelectDepartments_AllDepartments As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSelectDepartments_ChooseDepartments As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents TabControlPanel7 As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridView_Functions As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RadioButtonControl_AllFunctions As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControl_ChooseFunctions As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents TabControlPanel6 As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridView_Employees As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RadioButtonControl_AllEmployees As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControl_ChooseEmployees As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents CheckBox_OnlyActiveEmployees As WinForm.Presentation.Controls.CheckBox
    End Class

End Namespace