Namespace Reporting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class RevenueForecastInitialLoadingDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RevenueForecastInitialLoadingDialog))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_ViewReport = New DevComponents.DotNetBar.ButtonItem()
            Me.LabelGroupVersionAndOptions_ReportOptions = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabControlForm_JDA = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions = New DevComponents.DotNetBar.TabControlPanel()
            Me.LabelForm_PostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_Location = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.PanelVersionAndOptions_SummaryOptions = New System.Windows.Forms.Panel()
            Me.RadioButtonSummaryOption_JobComp = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.LabelSummaryOptions_SummaryOptions = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.RadioButtonSummaryOptions_ReportbyWeek = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSummaryOptions_ReportbyMonth = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TabItemJDA_VersionAndOptionsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelSelectOfficesTab_SelectOffices = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewSelectOffices_Offices = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonSelectOffices_AllOffices = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectOffices_ChooseOffices = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TabItemJDA_SelectOfficesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewSelectSalesClasses_SalesClasses = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonSelectSalesClasses_AllSalesClasses = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectSalesClasses_ChooseSalesClasses = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TabItemJDA_SelectSalesClassesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.TabItemJDA_SelectJobsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.RadioButtonSelectJobs_ChooseJobs = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectJobs_AllJobs = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.DataGridViewSelectJobs_Jobs = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.PanelSelectJobs_JobStatus = New System.Windows.Forms.Panel()
            Me.RadioButtonJobStatus_OpenClosedJobs = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonJobStatus_OpenJobs = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TabControlPanelSelectJobsTab_SelectJobs = New DevComponents.DotNetBar.TabControlPanel()
            Me.ButtonForm_View = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_StartingPostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_StartingPostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxForm_EndingPostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_EndingPostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ButtonForm_2YTD = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_2Years = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_YTD = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_1Year = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_MTD = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_CurrentPeriod = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_CurrentPeriod = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.DateTimePickerForm_Actualize = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            CType(Me.TabControlForm_JDA, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_JDA.SuspendLayout()
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.SuspendLayout()
            Me.PanelVersionAndOptions_SummaryOptions.SuspendLayout()
            Me.TabControlPanelSelectOfficesTab_SelectOffices.SuspendLayout()
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.SuspendLayout()
            Me.TabControlPanelSelectJobsTab_SelectJobs.SuspendLayout()
            CType(Me.DateTimePickerForm_Actualize, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(12, 12)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(107, 98)
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_ViewReport})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(81, 98)
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
            'ButtonItemActions_ViewReport
            '
            Me.ButtonItemActions_ViewReport.BeginGroup = True
            Me.ButtonItemActions_ViewReport.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_ViewReport.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_ViewReport.Name = "ButtonItemActions_ViewReport"
            Me.ButtonItemActions_ViewReport.RibbonWordWrap = False
            Me.ButtonItemActions_ViewReport.SubItemsExpandWidth = 14
            Me.ButtonItemActions_ViewReport.Text = "View Report"
            '
            'LabelGroupVersionAndOptions_ReportOptions
            '
            Me.LabelGroupVersionAndOptions_ReportOptions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelGroupVersionAndOptions_ReportOptions.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGroupVersionAndOptions_ReportOptions.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelGroupVersionAndOptions_ReportOptions.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelGroupVersionAndOptions_ReportOptions.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelGroupVersionAndOptions_ReportOptions.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelGroupVersionAndOptions_ReportOptions.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelGroupVersionAndOptions_ReportOptions.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelGroupVersionAndOptions_ReportOptions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGroupVersionAndOptions_ReportOptions.Location = New System.Drawing.Point(4, 4)
            Me.LabelGroupVersionAndOptions_ReportOptions.Name = "LabelGroupVersionAndOptions_ReportOptions"
            Me.LabelGroupVersionAndOptions_ReportOptions.Size = New System.Drawing.Size(792, 20)
            Me.LabelGroupVersionAndOptions_ReportOptions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGroupVersionAndOptions_ReportOptions.TabIndex = 1
            Me.LabelGroupVersionAndOptions_ReportOptions.Text = "Report Options"
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
            Me.TabControlForm_JDA.Controls.Add(Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses)
            Me.TabControlForm_JDA.Controls.Add(Me.TabControlPanelSelectOfficesTab_SelectOffices)
            Me.TabControlForm_JDA.Location = New System.Drawing.Point(12, 12)
            Me.TabControlForm_JDA.Name = "TabControlForm_JDA"
            Me.TabControlForm_JDA.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_JDA.SelectedTabIndex = 0
            Me.TabControlForm_JDA.Size = New System.Drawing.Size(800, 580)
            Me.TabControlForm_JDA.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_JDA.TabIndex = 0
            Me.TabControlForm_JDA.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_JDA.Tabs.Add(Me.TabItemJDA_VersionAndOptionsTab)
            Me.TabControlForm_JDA.Tabs.Add(Me.TabItemJDA_SelectOfficesTab)
            Me.TabControlForm_JDA.Tabs.Add(Me.TabItemJDA_SelectSalesClassesTab)
            '
            'TabControlPanelVersionAndOptionsTab_VersionAndOptions
            '
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.ComboBoxForm_CurrentPeriod)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.LabelForm_CurrentPeriod)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.LabelForm_StartingPostPeriod)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.ComboBoxForm_StartingPostPeriod)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.ComboBoxForm_EndingPostPeriod)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.LabelForm_EndingPostPeriod)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.ButtonForm_2YTD)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.ButtonForm_2Years)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.ButtonForm_YTD)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.ButtonForm_1Year)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.ButtonForm_MTD)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.LabelForm_PostPeriod)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.ComboBoxForm_Location)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.PanelVersionAndOptions_SummaryOptions)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.LabelGroupVersionAndOptions_ReportOptions)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Name = "TabControlPanelVersionAndOptionsTab_VersionAndOptions"
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Size = New System.Drawing.Size(800, 553)
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
            'LabelForm_PostPeriod
            '
            Me.LabelForm_PostPeriod.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_PostPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_PostPeriod.Location = New System.Drawing.Point(4, 187)
            Me.LabelForm_PostPeriod.Name = "LabelForm_PostPeriod"
            Me.LabelForm_PostPeriod.Size = New System.Drawing.Size(103, 20)
            Me.LabelForm_PostPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_PostPeriod.TabIndex = 7
            Me.LabelForm_PostPeriod.Text = "Location:"
            '
            'ComboBoxForm_Location
            '
            Me.ComboBoxForm_Location.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Location.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_Location.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Location.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Location.AutoFindItemInDataSource = False
            Me.ComboBoxForm_Location.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Location.BookmarkingEnabled = False
            Me.ComboBoxForm_Location.ClientCode = ""
            Me.ComboBoxForm_Location.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.PostPeriod
            Me.ComboBoxForm_Location.DisableMouseWheel = False
            Me.ComboBoxForm_Location.DisplayMember = "Description"
            Me.ComboBoxForm_Location.DisplayName = ""
            Me.ComboBoxForm_Location.DivisionCode = ""
            Me.ComboBoxForm_Location.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Location.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_Location.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_Location.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Location.FocusHighlightEnabled = True
            Me.ComboBoxForm_Location.FormattingEnabled = True
            Me.ComboBoxForm_Location.ItemHeight = 14
            Me.ComboBoxForm_Location.Location = New System.Drawing.Point(116, 187)
            Me.ComboBoxForm_Location.Name = "ComboBoxForm_Location"
            Me.ComboBoxForm_Location.ReadOnly = False
            Me.ComboBoxForm_Location.SecurityEnabled = True
            Me.ComboBoxForm_Location.Size = New System.Drawing.Size(237, 20)
            Me.ComboBoxForm_Location.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Location.TabIndex = 8
            Me.ComboBoxForm_Location.TabOnEnter = True
            Me.ComboBoxForm_Location.ValueMember = "Code"
            Me.ComboBoxForm_Location.WatermarkText = "Select Post Period"
            '
            'PanelVersionAndOptions_SummaryOptions
            '
            Me.PanelVersionAndOptions_SummaryOptions.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.PanelVersionAndOptions_SummaryOptions.BackColor = System.Drawing.Color.White
            Me.PanelVersionAndOptions_SummaryOptions.Controls.Add(Me.DateTimePickerForm_Actualize)
            Me.PanelVersionAndOptions_SummaryOptions.Controls.Add(Me.RadioButtonSummaryOption_JobComp)
            Me.PanelVersionAndOptions_SummaryOptions.Controls.Add(Me.LabelSummaryOptions_SummaryOptions)
            Me.PanelVersionAndOptions_SummaryOptions.Controls.Add(Me.RadioButtonSummaryOptions_ReportbyWeek)
            Me.PanelVersionAndOptions_SummaryOptions.Controls.Add(Me.RadioButtonSummaryOptions_ReportbyMonth)
            Me.PanelVersionAndOptions_SummaryOptions.Location = New System.Drawing.Point(4, 108)
            Me.PanelVersionAndOptions_SummaryOptions.Name = "PanelVersionAndOptions_SummaryOptions"
            Me.PanelVersionAndOptions_SummaryOptions.Size = New System.Drawing.Size(511, 73)
            Me.PanelVersionAndOptions_SummaryOptions.TabIndex = 4
            '
            'RadioButtonSummaryOption_JobComp
            '
            Me.RadioButtonSummaryOption_JobComp.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSummaryOption_JobComp.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSummaryOption_JobComp.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSummaryOption_JobComp.Location = New System.Drawing.Point(100, 50)
            Me.RadioButtonSummaryOption_JobComp.Name = "RadioButtonSummaryOption_JobComp"
            Me.RadioButtonSummaryOption_JobComp.SecurityEnabled = True
            Me.RadioButtonSummaryOption_JobComp.Size = New System.Drawing.Size(137, 20)
            Me.RadioButtonSummaryOption_JobComp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSummaryOption_JobComp.TabIndex = 3
            Me.RadioButtonSummaryOption_JobComp.TabOnEnter = True
            Me.RadioButtonSummaryOption_JobComp.TabStop = False
            Me.RadioButtonSummaryOption_JobComp.Text = "Actualize as of date"
            '
            'LabelSummaryOptions_SummaryOptions
            '
            Me.LabelSummaryOptions_SummaryOptions.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSummaryOptions_SummaryOptions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSummaryOptions_SummaryOptions.Location = New System.Drawing.Point(0, 0)
            Me.LabelSummaryOptions_SummaryOptions.Name = "LabelSummaryOptions_SummaryOptions"
            Me.LabelSummaryOptions_SummaryOptions.Size = New System.Drawing.Size(94, 20)
            Me.LabelSummaryOptions_SummaryOptions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSummaryOptions_SummaryOptions.TabIndex = 0
            Me.LabelSummaryOptions_SummaryOptions.Text = "Display Option:"
            '
            'RadioButtonSummaryOptions_ReportbyWeek
            '
            Me.RadioButtonSummaryOptions_ReportbyWeek.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSummaryOptions_ReportbyWeek.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSummaryOptions_ReportbyWeek.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSummaryOptions_ReportbyWeek.Checked = True
            Me.RadioButtonSummaryOptions_ReportbyWeek.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonSummaryOptions_ReportbyWeek.CheckValue = "Y"
            Me.RadioButtonSummaryOptions_ReportbyWeek.Location = New System.Drawing.Point(100, 0)
            Me.RadioButtonSummaryOptions_ReportbyWeek.Name = "RadioButtonSummaryOptions_ReportbyWeek"
            Me.RadioButtonSummaryOptions_ReportbyWeek.SecurityEnabled = True
            Me.RadioButtonSummaryOptions_ReportbyWeek.Size = New System.Drawing.Size(137, 20)
            Me.RadioButtonSummaryOptions_ReportbyWeek.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSummaryOptions_ReportbyWeek.TabIndex = 1
            Me.RadioButtonSummaryOptions_ReportbyWeek.TabOnEnter = True
            Me.RadioButtonSummaryOptions_ReportbyWeek.Text = "Report by Week"
            '
            'RadioButtonSummaryOptions_ReportbyMonth
            '
            Me.RadioButtonSummaryOptions_ReportbyMonth.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSummaryOptions_ReportbyMonth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSummaryOptions_ReportbyMonth.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSummaryOptions_ReportbyMonth.Location = New System.Drawing.Point(100, 26)
            Me.RadioButtonSummaryOptions_ReportbyMonth.Name = "RadioButtonSummaryOptions_ReportbyMonth"
            Me.RadioButtonSummaryOptions_ReportbyMonth.SecurityEnabled = True
            Me.RadioButtonSummaryOptions_ReportbyMonth.Size = New System.Drawing.Size(137, 20)
            Me.RadioButtonSummaryOptions_ReportbyMonth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSummaryOptions_ReportbyMonth.TabIndex = 2
            Me.RadioButtonSummaryOptions_ReportbyMonth.TabOnEnter = True
            Me.RadioButtonSummaryOptions_ReportbyMonth.TabStop = False
            Me.RadioButtonSummaryOptions_ReportbyMonth.Text = "Report by Month"
            '
            'TabItemJDA_VersionAndOptionsTab
            '
            Me.TabItemJDA_VersionAndOptionsTab.AttachedControl = Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions
            Me.TabItemJDA_VersionAndOptionsTab.Name = "TabItemJDA_VersionAndOptionsTab"
            Me.TabItemJDA_VersionAndOptionsTab.Text = "Version / Options"
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
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Size = New System.Drawing.Size(800, 553)
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
            Me.DataGridViewSelectOffices_Offices.Location = New System.Drawing.Point(4, 30)
            Me.DataGridViewSelectOffices_Offices.MultiSelect = False
            Me.DataGridViewSelectOffices_Offices.Name = "DataGridViewSelectOffices_Offices"
            Me.DataGridViewSelectOffices_Offices.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSelectOffices_Offices.RunStandardValidation = True
            Me.DataGridViewSelectOffices_Offices.ShowColumnMenuOnRightClick = False
            Me.DataGridViewSelectOffices_Offices.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSelectOffices_Offices.Size = New System.Drawing.Size(792, 519)
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
            'TabControlPanelSelectSalesClassesTab_SelectSalesClasses
            '
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Controls.Add(Me.DataGridViewSelectSalesClasses_SalesClasses)
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Controls.Add(Me.RadioButtonSelectSalesClasses_AllSalesClasses)
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Controls.Add(Me.RadioButtonSelectSalesClasses_ChooseSalesClasses)
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Name = "TabControlPanelSelectSalesClassesTab_SelectSalesClasses"
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Size = New System.Drawing.Size(800, 553)
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Style.GradientAngle = 90
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.TabIndex = 0
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.TabItem = Me.TabItemJDA_SelectSalesClassesTab
            '
            'DataGridViewSelectSalesClasses_SalesClasses
            '
            Me.DataGridViewSelectSalesClasses_SalesClasses.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewSelectSalesClasses_SalesClasses.AllowDragAndDrop = False
            Me.DataGridViewSelectSalesClasses_SalesClasses.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewSelectSalesClasses_SalesClasses.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSelectSalesClasses_SalesClasses.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewSelectSalesClasses_SalesClasses.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSelectSalesClasses_SalesClasses.AutoFilterLookupColumns = False
            Me.DataGridViewSelectSalesClasses_SalesClasses.AutoloadRepositoryDatasource = True
            Me.DataGridViewSelectSalesClasses_SalesClasses.AutoUpdateViewCaption = True
            Me.DataGridViewSelectSalesClasses_SalesClasses.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewSelectSalesClasses_SalesClasses.DataSource = Nothing
            Me.DataGridViewSelectSalesClasses_SalesClasses.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewSelectSalesClasses_SalesClasses.Enabled = False
            Me.DataGridViewSelectSalesClasses_SalesClasses.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSelectSalesClasses_SalesClasses.ItemDescription = "Sales Class(es)"
            Me.DataGridViewSelectSalesClasses_SalesClasses.Location = New System.Drawing.Point(4, 30)
            Me.DataGridViewSelectSalesClasses_SalesClasses.MultiSelect = False
            Me.DataGridViewSelectSalesClasses_SalesClasses.Name = "DataGridViewSelectSalesClasses_SalesClasses"
            Me.DataGridViewSelectSalesClasses_SalesClasses.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSelectSalesClasses_SalesClasses.RunStandardValidation = True
            Me.DataGridViewSelectSalesClasses_SalesClasses.ShowColumnMenuOnRightClick = False
            Me.DataGridViewSelectSalesClasses_SalesClasses.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSelectSalesClasses_SalesClasses.Size = New System.Drawing.Size(792, 519)
            Me.DataGridViewSelectSalesClasses_SalesClasses.TabIndex = 2
            Me.DataGridViewSelectSalesClasses_SalesClasses.UseEmbeddedNavigator = False
            Me.DataGridViewSelectSalesClasses_SalesClasses.ViewCaptionHeight = -1
            '
            'RadioButtonSelectSalesClasses_AllSalesClasses
            '
            Me.RadioButtonSelectSalesClasses_AllSalesClasses.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectSalesClasses_AllSalesClasses.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectSalesClasses_AllSalesClasses.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectSalesClasses_AllSalesClasses.Checked = True
            Me.RadioButtonSelectSalesClasses_AllSalesClasses.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonSelectSalesClasses_AllSalesClasses.CheckValue = "Y"
            Me.RadioButtonSelectSalesClasses_AllSalesClasses.Location = New System.Drawing.Point(4, 4)
            Me.RadioButtonSelectSalesClasses_AllSalesClasses.Name = "RadioButtonSelectSalesClasses_AllSalesClasses"
            Me.RadioButtonSelectSalesClasses_AllSalesClasses.SecurityEnabled = True
            Me.RadioButtonSelectSalesClasses_AllSalesClasses.Size = New System.Drawing.Size(113, 20)
            Me.RadioButtonSelectSalesClasses_AllSalesClasses.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectSalesClasses_AllSalesClasses.TabIndex = 0
            Me.RadioButtonSelectSalesClasses_AllSalesClasses.TabOnEnter = True
            Me.RadioButtonSelectSalesClasses_AllSalesClasses.Text = "All Sales Classes"
            '
            'RadioButtonSelectSalesClasses_ChooseSalesClasses
            '
            Me.RadioButtonSelectSalesClasses_ChooseSalesClasses.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectSalesClasses_ChooseSalesClasses.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectSalesClasses_ChooseSalesClasses.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectSalesClasses_ChooseSalesClasses.Location = New System.Drawing.Point(123, 4)
            Me.RadioButtonSelectSalesClasses_ChooseSalesClasses.Name = "RadioButtonSelectSalesClasses_ChooseSalesClasses"
            Me.RadioButtonSelectSalesClasses_ChooseSalesClasses.SecurityEnabled = True
            Me.RadioButtonSelectSalesClasses_ChooseSalesClasses.Size = New System.Drawing.Size(164, 20)
            Me.RadioButtonSelectSalesClasses_ChooseSalesClasses.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectSalesClasses_ChooseSalesClasses.TabIndex = 1
            Me.RadioButtonSelectSalesClasses_ChooseSalesClasses.TabOnEnter = True
            Me.RadioButtonSelectSalesClasses_ChooseSalesClasses.TabStop = False
            Me.RadioButtonSelectSalesClasses_ChooseSalesClasses.Text = "Choose Sales Classes"
            '
            'TabItemJDA_SelectSalesClassesTab
            '
            Me.TabItemJDA_SelectSalesClassesTab.AttachedControl = Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses
            Me.TabItemJDA_SelectSalesClassesTab.Name = "TabItemJDA_SelectSalesClassesTab"
            Me.TabItemJDA_SelectSalesClassesTab.Text = "Select Sales Classes"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(737, 598)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 11
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'TabItemJDA_SelectJobsTab
            '
            Me.TabItemJDA_SelectJobsTab.AttachedControl = Me.TabControlPanelSelectJobsTab_SelectJobs
            Me.TabItemJDA_SelectJobsTab.Name = "TabItemJDA_SelectJobsTab"
            Me.TabItemJDA_SelectJobsTab.Text = "Select Jobs"
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
            Me.DataGridViewSelectJobs_Jobs.DataSource = Nothing
            Me.DataGridViewSelectJobs_Jobs.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewSelectJobs_Jobs.Enabled = False
            Me.DataGridViewSelectJobs_Jobs.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSelectJobs_Jobs.ItemDescription = "Job(s)"
            Me.DataGridViewSelectJobs_Jobs.Location = New System.Drawing.Point(4, 56)
            Me.DataGridViewSelectJobs_Jobs.MultiSelect = False
            Me.DataGridViewSelectJobs_Jobs.Name = "DataGridViewSelectJobs_Jobs"
            Me.DataGridViewSelectJobs_Jobs.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSelectJobs_Jobs.RunStandardValidation = True
            Me.DataGridViewSelectJobs_Jobs.ShowColumnMenuOnRightClick = False
            Me.DataGridViewSelectJobs_Jobs.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSelectJobs_Jobs.Size = New System.Drawing.Size(792, 493)
            Me.DataGridViewSelectJobs_Jobs.TabIndex = 3
            Me.DataGridViewSelectJobs_Jobs.UseEmbeddedNavigator = False
            Me.DataGridViewSelectJobs_Jobs.ViewCaptionHeight = -1
            '
            'PanelSelectJobs_JobStatus
            '
            Me.PanelSelectJobs_JobStatus.BackColor = System.Drawing.Color.White
            Me.PanelSelectJobs_JobStatus.Enabled = False
            Me.PanelSelectJobs_JobStatus.Location = New System.Drawing.Point(4, 30)
            Me.PanelSelectJobs_JobStatus.Name = "PanelSelectJobs_JobStatus"
            Me.PanelSelectJobs_JobStatus.Size = New System.Drawing.Size(221, 20)
            Me.PanelSelectJobs_JobStatus.TabIndex = 2
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
            '
            'TabControlPanelSelectJobsTab_SelectJobs
            '
            Me.TabControlPanelSelectJobsTab_SelectJobs.Controls.Add(Me.PanelSelectJobs_JobStatus)
            Me.TabControlPanelSelectJobsTab_SelectJobs.Controls.Add(Me.DataGridViewSelectJobs_Jobs)
            Me.TabControlPanelSelectJobsTab_SelectJobs.Controls.Add(Me.RadioButtonSelectJobs_AllJobs)
            Me.TabControlPanelSelectJobsTab_SelectJobs.Controls.Add(Me.RadioButtonSelectJobs_ChooseJobs)
            Me.TabControlPanelSelectJobsTab_SelectJobs.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSelectJobsTab_SelectJobs.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSelectJobsTab_SelectJobs.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelSelectJobsTab_SelectJobs.Name = "TabControlPanelSelectJobsTab_SelectJobs"
            Me.TabControlPanelSelectJobsTab_SelectJobs.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSelectJobsTab_SelectJobs.Size = New System.Drawing.Size(800, 553)
            Me.TabControlPanelSelectJobsTab_SelectJobs.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelSelectJobsTab_SelectJobs.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSelectJobsTab_SelectJobs.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSelectJobsTab_SelectJobs.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSelectJobsTab_SelectJobs.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSelectJobsTab_SelectJobs.Style.GradientAngle = 90
            Me.TabControlPanelSelectJobsTab_SelectJobs.TabIndex = 0
            Me.TabControlPanelSelectJobsTab_SelectJobs.TabItem = Me.TabItemJDA_SelectJobsTab
            '
            'ButtonForm_View
            '
            Me.ButtonForm_View.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_View.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_View.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_View.Location = New System.Drawing.Point(656, 598)
            Me.ButtonForm_View.Name = "ButtonForm_View"
            Me.ButtonForm_View.SecurityEnabled = True
            Me.ButtonForm_View.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_View.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_View.TabIndex = 10
            Me.ButtonForm_View.Text = "View"
            '
            'LabelForm_StartingPostPeriod
            '
            Me.LabelForm_StartingPostPeriod.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_StartingPostPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_StartingPostPeriod.Location = New System.Drawing.Point(4, 30)
            Me.LabelForm_StartingPostPeriod.Name = "LabelForm_StartingPostPeriod"
            Me.LabelForm_StartingPostPeriod.Size = New System.Drawing.Size(106, 20)
            Me.LabelForm_StartingPostPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_StartingPostPeriod.TabIndex = 10
            Me.LabelForm_StartingPostPeriod.Text = "Starting Post Period:"
            '
            'ComboBoxForm_StartingPostPeriod
            '
            Me.ComboBoxForm_StartingPostPeriod.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_StartingPostPeriod.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_StartingPostPeriod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_StartingPostPeriod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_StartingPostPeriod.AutoFindItemInDataSource = False
            Me.ComboBoxForm_StartingPostPeriod.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_StartingPostPeriod.BookmarkingEnabled = False
            Me.ComboBoxForm_StartingPostPeriod.ClientCode = ""
            Me.ComboBoxForm_StartingPostPeriod.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.PostPeriod
            Me.ComboBoxForm_StartingPostPeriod.DisableMouseWheel = False
            Me.ComboBoxForm_StartingPostPeriod.DisplayMember = "Description"
            Me.ComboBoxForm_StartingPostPeriod.DisplayName = ""
            Me.ComboBoxForm_StartingPostPeriod.DivisionCode = ""
            Me.ComboBoxForm_StartingPostPeriod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_StartingPostPeriod.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_StartingPostPeriod.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_StartingPostPeriod.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_StartingPostPeriod.FocusHighlightEnabled = True
            Me.ComboBoxForm_StartingPostPeriod.FormattingEnabled = True
            Me.ComboBoxForm_StartingPostPeriod.ItemHeight = 14
            Me.ComboBoxForm_StartingPostPeriod.Location = New System.Drawing.Point(116, 30)
            Me.ComboBoxForm_StartingPostPeriod.Name = "ComboBoxForm_StartingPostPeriod"
            Me.ComboBoxForm_StartingPostPeriod.ReadOnly = False
            Me.ComboBoxForm_StartingPostPeriod.SecurityEnabled = True
            Me.ComboBoxForm_StartingPostPeriod.Size = New System.Drawing.Size(237, 20)
            Me.ComboBoxForm_StartingPostPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_StartingPostPeriod.TabIndex = 11
            Me.ComboBoxForm_StartingPostPeriod.TabOnEnter = True
            Me.ComboBoxForm_StartingPostPeriod.ValueMember = "Code"
            Me.ComboBoxForm_StartingPostPeriod.WatermarkText = "Select Post Period"
            '
            'ComboBoxForm_EndingPostPeriod
            '
            Me.ComboBoxForm_EndingPostPeriod.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_EndingPostPeriod.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_EndingPostPeriod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_EndingPostPeriod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_EndingPostPeriod.AutoFindItemInDataSource = False
            Me.ComboBoxForm_EndingPostPeriod.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_EndingPostPeriod.BookmarkingEnabled = False
            Me.ComboBoxForm_EndingPostPeriod.ClientCode = ""
            Me.ComboBoxForm_EndingPostPeriod.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.PostPeriod
            Me.ComboBoxForm_EndingPostPeriod.DisableMouseWheel = False
            Me.ComboBoxForm_EndingPostPeriod.DisplayMember = "Description"
            Me.ComboBoxForm_EndingPostPeriod.DisplayName = ""
            Me.ComboBoxForm_EndingPostPeriod.DivisionCode = ""
            Me.ComboBoxForm_EndingPostPeriod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_EndingPostPeriod.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_EndingPostPeriod.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_EndingPostPeriod.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_EndingPostPeriod.FocusHighlightEnabled = True
            Me.ComboBoxForm_EndingPostPeriod.FormattingEnabled = True
            Me.ComboBoxForm_EndingPostPeriod.ItemHeight = 14
            Me.ComboBoxForm_EndingPostPeriod.Location = New System.Drawing.Point(116, 56)
            Me.ComboBoxForm_EndingPostPeriod.Name = "ComboBoxForm_EndingPostPeriod"
            Me.ComboBoxForm_EndingPostPeriod.ReadOnly = False
            Me.ComboBoxForm_EndingPostPeriod.SecurityEnabled = True
            Me.ComboBoxForm_EndingPostPeriod.Size = New System.Drawing.Size(237, 20)
            Me.ComboBoxForm_EndingPostPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_EndingPostPeriod.TabIndex = 16
            Me.ComboBoxForm_EndingPostPeriod.TabOnEnter = True
            Me.ComboBoxForm_EndingPostPeriod.ValueMember = "Code"
            Me.ComboBoxForm_EndingPostPeriod.WatermarkText = "Select Post Period"
            '
            'LabelForm_EndingPostPeriod
            '
            Me.LabelForm_EndingPostPeriod.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_EndingPostPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_EndingPostPeriod.Location = New System.Drawing.Point(4, 56)
            Me.LabelForm_EndingPostPeriod.Name = "LabelForm_EndingPostPeriod"
            Me.LabelForm_EndingPostPeriod.Size = New System.Drawing.Size(106, 20)
            Me.LabelForm_EndingPostPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_EndingPostPeriod.TabIndex = 15
            Me.LabelForm_EndingPostPeriod.Text = "Ending Post Period:"
            '
            'ButtonForm_2YTD
            '
            Me.ButtonForm_2YTD.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_2YTD.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_2YTD.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_2YTD.Location = New System.Drawing.Point(521, 30)
            Me.ButtonForm_2YTD.Name = "ButtonForm_2YTD"
            Me.ButtonForm_2YTD.SecurityEnabled = True
            Me.ButtonForm_2YTD.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_2YTD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_2YTD.TabIndex = 14
            Me.ButtonForm_2YTD.Text = "2 YTD"
            '
            'ButtonForm_2Years
            '
            Me.ButtonForm_2Years.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_2Years.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_2Years.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_2Years.Location = New System.Drawing.Point(440, 56)
            Me.ButtonForm_2Years.Name = "ButtonForm_2Years"
            Me.ButtonForm_2Years.SecurityEnabled = True
            Me.ButtonForm_2Years.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_2Years.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_2Years.TabIndex = 18
            Me.ButtonForm_2Years.Text = "2 Years"
            '
            'ButtonForm_YTD
            '
            Me.ButtonForm_YTD.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_YTD.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_YTD.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_YTD.Location = New System.Drawing.Point(359, 30)
            Me.ButtonForm_YTD.Name = "ButtonForm_YTD"
            Me.ButtonForm_YTD.SecurityEnabled = True
            Me.ButtonForm_YTD.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_YTD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_YTD.TabIndex = 12
            Me.ButtonForm_YTD.Text = "YTD"
            '
            'ButtonForm_1Year
            '
            Me.ButtonForm_1Year.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_1Year.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_1Year.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_1Year.Location = New System.Drawing.Point(440, 30)
            Me.ButtonForm_1Year.Name = "ButtonForm_1Year"
            Me.ButtonForm_1Year.SecurityEnabled = True
            Me.ButtonForm_1Year.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_1Year.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_1Year.TabIndex = 13
            Me.ButtonForm_1Year.Text = "1 Year"
            '
            'ButtonForm_MTD
            '
            Me.ButtonForm_MTD.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_MTD.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_MTD.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_MTD.Location = New System.Drawing.Point(359, 56)
            Me.ButtonForm_MTD.Name = "ButtonForm_MTD"
            Me.ButtonForm_MTD.SecurityEnabled = True
            Me.ButtonForm_MTD.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_MTD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_MTD.TabIndex = 17
            Me.ButtonForm_MTD.Text = "MTD"
            '
            'LabelForm_CurrentPeriod
            '
            Me.LabelForm_CurrentPeriod.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_CurrentPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_CurrentPeriod.Location = New System.Drawing.Point(4, 82)
            Me.LabelForm_CurrentPeriod.Name = "LabelForm_CurrentPeriod"
            Me.LabelForm_CurrentPeriod.Size = New System.Drawing.Size(106, 20)
            Me.LabelForm_CurrentPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_CurrentPeriod.TabIndex = 19
            Me.LabelForm_CurrentPeriod.Text = "Current Period:"
            '
            'ComboBoxForm_CurrentPeriod
            '
            Me.ComboBoxForm_CurrentPeriod.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_CurrentPeriod.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_CurrentPeriod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_CurrentPeriod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_CurrentPeriod.AutoFindItemInDataSource = False
            Me.ComboBoxForm_CurrentPeriod.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_CurrentPeriod.BookmarkingEnabled = False
            Me.ComboBoxForm_CurrentPeriod.ClientCode = ""
            Me.ComboBoxForm_CurrentPeriod.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.PostPeriod
            Me.ComboBoxForm_CurrentPeriod.DisableMouseWheel = False
            Me.ComboBoxForm_CurrentPeriod.DisplayMember = "Description"
            Me.ComboBoxForm_CurrentPeriod.DisplayName = ""
            Me.ComboBoxForm_CurrentPeriod.DivisionCode = ""
            Me.ComboBoxForm_CurrentPeriod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_CurrentPeriod.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_CurrentPeriod.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_CurrentPeriod.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_CurrentPeriod.FocusHighlightEnabled = True
            Me.ComboBoxForm_CurrentPeriod.FormattingEnabled = True
            Me.ComboBoxForm_CurrentPeriod.ItemHeight = 14
            Me.ComboBoxForm_CurrentPeriod.Location = New System.Drawing.Point(116, 82)
            Me.ComboBoxForm_CurrentPeriod.Name = "ComboBoxForm_CurrentPeriod"
            Me.ComboBoxForm_CurrentPeriod.ReadOnly = False
            Me.ComboBoxForm_CurrentPeriod.SecurityEnabled = True
            Me.ComboBoxForm_CurrentPeriod.Size = New System.Drawing.Size(237, 20)
            Me.ComboBoxForm_CurrentPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_CurrentPeriod.TabIndex = 20
            Me.ComboBoxForm_CurrentPeriod.TabOnEnter = True
            Me.ComboBoxForm_CurrentPeriod.ValueMember = "Code"
            Me.ComboBoxForm_CurrentPeriod.WatermarkText = "Select Post Period"
            '
            'DateTimePickerForm_Actualize
            '
            Me.DateTimePickerForm_Actualize.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerForm_Actualize.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerForm_Actualize.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_Actualize.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerForm_Actualize.ButtonDropDown.Visible = True
            Me.DateTimePickerForm_Actualize.ButtonFreeText.Checked = True
            Me.DateTimePickerForm_Actualize.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePickerForm_Actualize.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePickerForm_Actualize.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerForm_Actualize.DisplayName = ""
            Me.DateTimePickerForm_Actualize.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerForm_Actualize.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerForm_Actualize.FocusHighlightEnabled = True
            Me.DateTimePickerForm_Actualize.FreeTextEntryMode = True
            Me.DateTimePickerForm_Actualize.IsPopupCalendarOpen = False
            Me.DateTimePickerForm_Actualize.Location = New System.Drawing.Point(234, 50)
            Me.DateTimePickerForm_Actualize.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerForm_Actualize.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerForm_Actualize.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerForm_Actualize.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_Actualize.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerForm_Actualize.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerForm_Actualize.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerForm_Actualize.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_Actualize.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerForm_Actualize.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerForm_Actualize.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerForm_Actualize.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerForm_Actualize.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_Actualize.MonthCalendar.DisplayMonth = New Date(2012, 7, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerForm_Actualize.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerForm_Actualize.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_Actualize.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerForm_Actualize.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_Actualize.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerForm_Actualize.Name = "DateTimePickerForm_Actualize"
            Me.DateTimePickerForm_Actualize.ReadOnly = False
            Me.DateTimePickerForm_Actualize.Size = New System.Drawing.Size(124, 20)
            Me.DateTimePickerForm_Actualize.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_Actualize.TabIndex = 10
            Me.DateTimePickerForm_Actualize.TabOnEnter = True
            Me.DateTimePickerForm_Actualize.Value = New Date(2017, 8, 7, 11, 18, 20, 812)
            '
            'RevenueForecastInitialLoadingDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(824, 630)
            Me.Controls.Add(Me.ButtonForm_View)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.TabControlForm_JDA)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "RevenueForecastInitialLoadingDialog"
            Me.Text = "Job Detail Analysis"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            CType(Me.TabControlForm_JDA, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_JDA.ResumeLayout(False)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.ResumeLayout(False)
            Me.PanelVersionAndOptions_SummaryOptions.ResumeLayout(False)
            Me.TabControlPanelSelectOfficesTab_SelectOffices.ResumeLayout(False)
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.ResumeLayout(False)
            Me.TabControlPanelSelectJobsTab_SelectJobs.ResumeLayout(False)
            CType(Me.DateTimePickerForm_Actualize, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_ViewReport As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents LabelGroupVersionAndOptions_ReportOptions As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TabControlForm_JDA As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelVersionAndOptionsTab_VersionAndOptions As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemJDA_VersionAndOptionsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelSelectOfficesTab_SelectOffices As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemJDA_SelectOfficesTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents PanelVersionAndOptions_SummaryOptions As System.Windows.Forms.Panel
        Friend WithEvents LabelSummaryOptions_SummaryOptions As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents RadioButtonSummaryOptions_ReportbyWeek As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSummaryOptions_ReportbyMonth As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSelectOffices_AllOffices As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSelectOffices_ChooseOffices As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents DataGridViewSelectOffices_Offices As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TabControlPanelSelectSalesClassesTab_SelectSalesClasses As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewSelectSalesClasses_SalesClasses As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RadioButtonSelectSalesClasses_AllSalesClasses As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSelectSalesClasses_ChooseSalesClasses As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents TabItemJDA_SelectSalesClassesTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents RadioButtonSummaryOption_JobComp As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents LabelForm_PostPeriod As WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_Location As WinForm.Presentation.Controls.ComboBox
        Friend WithEvents TabItemJDA_SelectJobsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelSelectJobsTab_SelectJobs As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents PanelSelectJobs_JobStatus As Windows.Forms.Panel
        Friend WithEvents DataGridViewSelectJobs_Jobs As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RadioButtonSelectJobs_AllJobs As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSelectJobs_ChooseJobs As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonJobStatus_OpenClosedJobs As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonJobStatus_OpenJobs As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents ButtonForm_View As WinForm.Presentation.Controls.Button
        Friend WithEvents ComboBoxForm_CurrentPeriod As WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_CurrentPeriod As WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_StartingPostPeriod As WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_StartingPostPeriod As WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxForm_EndingPostPeriod As WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_EndingPostPeriod As WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonForm_2YTD As WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_2Years As WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_YTD As WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_1Year As WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_MTD As WinForm.Presentation.Controls.Button
        Friend WithEvents DateTimePickerForm_Actualize As WinForm.Presentation.Controls.DateTimePicker
    End Class

End Namespace