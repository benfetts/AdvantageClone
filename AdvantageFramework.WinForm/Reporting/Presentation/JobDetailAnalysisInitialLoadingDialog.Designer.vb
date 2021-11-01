Namespace Reporting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class JobDetailAnalysisInitialLoadingDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(JobDetailAnalysisInitialLoadingDialog))
            Me.DataGridViewVersionAndOptions_Versions = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_ViewReport = New DevComponents.DotNetBar.ButtonItem()
            Me.LabelGroupVersionAndOptions_ReportOptions = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabControlForm_JDA = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions = New DevComponents.DotNetBar.TabControlPanel()
            Me.CheckBoxVersionAndOptions_SuppressZeroMUDown = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelForm_PostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_PostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.CheckBoxVersionAndOptions_SaveReportOptions = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxVersionAndOptions_ExcludeNonBillableHours = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.PanelVersionAndOptions_SummaryOptions = New System.Windows.Forms.Panel()
            Me.RadioButtonSummaryOption_JobComp = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.LabelSummaryOptions_SummaryOptions = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.RadioButtonSummaryOptions_SummaryByFunction = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSummaryOptions_DetailByFunction = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.PanelVersionAndOptions_Include = New System.Windows.Forms.Panel()
            Me.LabelInclude_Include = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.RadioButtonInclude_OpenJobsOnly = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonInclude_OpenAndClosedJobs = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.PanelVersionAndOptions_SortBy = New System.Windows.Forms.Panel()
            Me.LabelSortBy_SortBy = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.RadioButtonSortBy_ClientDivisionProduct = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSortBy_AccountExecutive = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TabItemJDA_VersionAndOptionsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlSelectClientsTab_SelectClients = New DevComponents.DotNetBar.TabControlPanel()
            Me.CDPChooserControlSelectClients_SelectClients = New AdvantageFramework.WinForm.Presentation.Controls.CDPChooserControl()
            Me.TabItemJDA_SelectClientsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelSelectJobsTab_SelectJobs = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelSelectJobs_JobStatus = New System.Windows.Forms.Panel()
            Me.RadioButtonJobStatus_OpenJobs = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonJobStatus_OpenClosedJobs = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.DataGridViewSelectJobs_Jobs = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonSelectJobs_AllJobs = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectJobs_ChooseJobs = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TabItemJDA_SelectJobsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelSelectOfficesTab_SelectOffices = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewSelectOffices_Offices = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonSelectOffices_AllOffices = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectOffices_ChooseOffices = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TabItemJDA_SelectOfficesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelSelectAccountExecutivesTab_SelectAccountExecutives = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewSelectAccountExecutives_AccountExecutives = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonSelectAccountExecutives_AllAccountExecutives = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectAccountExecutives_ChooseAccountExecutives = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TabItemJDA_SelectAccountExecutivesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewSelectSalesClasses_SalesClasses = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonSelectSalesClasses_AllSalesClasses = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectSalesClasses_ChooseSalesClasses = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TabItemJDA_SelectSalesClassesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.ButtonForm_View = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            CType(Me.TabControlForm_JDA, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_JDA.SuspendLayout()
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.SuspendLayout()
            Me.PanelVersionAndOptions_SummaryOptions.SuspendLayout()
            Me.PanelVersionAndOptions_Include.SuspendLayout()
            Me.PanelVersionAndOptions_SortBy.SuspendLayout()
            Me.TabControlSelectClientsTab_SelectClients.SuspendLayout()
            Me.TabControlPanelSelectJobsTab_SelectJobs.SuspendLayout()
            Me.PanelSelectJobs_JobStatus.SuspendLayout()
            Me.TabControlPanelSelectOfficesTab_SelectOffices.SuspendLayout()
            Me.TabControlPanelSelectAccountExecutivesTab_SelectAccountExecutives.SuspendLayout()
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.SuspendLayout()
            Me.SuspendLayout()
            '
            'DataGridViewVersionAndOptions_Versions
            '
            Me.DataGridViewVersionAndOptions_Versions.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewVersionAndOptions_Versions.AllowDragAndDrop = False
            Me.DataGridViewVersionAndOptions_Versions.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewVersionAndOptions_Versions.AllowSelectGroupHeaderRow = True
            Me.DataGridViewVersionAndOptions_Versions.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewVersionAndOptions_Versions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewVersionAndOptions_Versions.AutoFilterLookupColumns = False
            Me.DataGridViewVersionAndOptions_Versions.AutoloadRepositoryDatasource = True
            Me.DataGridViewVersionAndOptions_Versions.AutoUpdateViewCaption = True
            Me.DataGridViewVersionAndOptions_Versions.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewVersionAndOptions_Versions.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewVersionAndOptions_Versions.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewVersionAndOptions_Versions.ItemDescription = "Version(s)"
            Me.DataGridViewVersionAndOptions_Versions.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewVersionAndOptions_Versions.MultiSelect = False
            Me.DataGridViewVersionAndOptions_Versions.Name = "DataGridViewVersionAndOptions_Versions"
            Me.DataGridViewVersionAndOptions_Versions.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewVersionAndOptions_Versions.RunStandardValidation = True
            Me.DataGridViewVersionAndOptions_Versions.ShowColumnMenuOnRightClick = False
            Me.DataGridViewVersionAndOptions_Versions.ShowSelectDeselectAllButtons = False
            Me.DataGridViewVersionAndOptions_Versions.Size = New System.Drawing.Size(792, 427)
            Me.DataGridViewVersionAndOptions_Versions.TabIndex = 0
            Me.DataGridViewVersionAndOptions_Versions.UseEmbeddedNavigator = False
            Me.DataGridViewVersionAndOptions_Versions.ViewCaptionHeight = -1
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
            Me.LabelGroupVersionAndOptions_ReportOptions.Location = New System.Drawing.Point(4, 437)
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
            Me.TabControlForm_JDA.Controls.Add(Me.TabControlSelectClientsTab_SelectClients)
            Me.TabControlForm_JDA.Controls.Add(Me.TabControlPanelSelectJobsTab_SelectJobs)
            Me.TabControlForm_JDA.Controls.Add(Me.TabControlPanelSelectOfficesTab_SelectOffices)
            Me.TabControlForm_JDA.Controls.Add(Me.TabControlPanelSelectAccountExecutivesTab_SelectAccountExecutives)
            Me.TabControlForm_JDA.Controls.Add(Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses)
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
            Me.TabControlForm_JDA.Tabs.Add(Me.TabItemJDA_SelectClientsTab)
            Me.TabControlForm_JDA.Tabs.Add(Me.TabItemJDA_SelectJobsTab)
            Me.TabControlForm_JDA.Tabs.Add(Me.TabItemJDA_SelectAccountExecutivesTab)
            Me.TabControlForm_JDA.Tabs.Add(Me.TabItemJDA_SelectSalesClassesTab)
            '
            'TabControlPanelVersionAndOptionsTab_VersionAndOptions
            '
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.CheckBoxVersionAndOptions_SuppressZeroMUDown)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.LabelForm_PostPeriod)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.ComboBoxForm_PostPeriod)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.CheckBoxVersionAndOptions_SaveReportOptions)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.CheckBoxVersionAndOptions_ExcludeNonBillableHours)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.PanelVersionAndOptions_SummaryOptions)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.PanelVersionAndOptions_Include)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.PanelVersionAndOptions_SortBy)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.DataGridViewVersionAndOptions_Versions)
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
            'CheckBoxVersionAndOptions_SuppressZeroMUDown
            '
            Me.CheckBoxVersionAndOptions_SuppressZeroMUDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxVersionAndOptions_SuppressZeroMUDown.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxVersionAndOptions_SuppressZeroMUDown.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxVersionAndOptions_SuppressZeroMUDown.CheckValue = 0
            Me.CheckBoxVersionAndOptions_SuppressZeroMUDown.CheckValueChecked = 1
            Me.CheckBoxVersionAndOptions_SuppressZeroMUDown.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxVersionAndOptions_SuppressZeroMUDown.CheckValueUnchecked = 0
            Me.CheckBoxVersionAndOptions_SuppressZeroMUDown.ChildControls = CType(resources.GetObject("CheckBoxVersionAndOptions_SuppressZeroMUDown.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxVersionAndOptions_SuppressZeroMUDown.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxVersionAndOptions_SuppressZeroMUDown.Location = New System.Drawing.Point(643, 490)
            Me.CheckBoxVersionAndOptions_SuppressZeroMUDown.Name = "CheckBoxVersionAndOptions_SuppressZeroMUDown"
            Me.CheckBoxVersionAndOptions_SuppressZeroMUDown.OldestSibling = Nothing
            Me.CheckBoxVersionAndOptions_SuppressZeroMUDown.SecurityEnabled = True
            Me.CheckBoxVersionAndOptions_SuppressZeroMUDown.SiblingControls = CType(resources.GetObject("CheckBoxVersionAndOptions_SuppressZeroMUDown.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxVersionAndOptions_SuppressZeroMUDown.Size = New System.Drawing.Size(153, 20)
            Me.CheckBoxVersionAndOptions_SuppressZeroMUDown.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxVersionAndOptions_SuppressZeroMUDown.TabIndex = 9
            Me.CheckBoxVersionAndOptions_SuppressZeroMUDown.TabOnEnter = True
            Me.CheckBoxVersionAndOptions_SuppressZeroMUDown.Text = "Suppress Zero MU/Down"
            '
            'LabelForm_PostPeriod
            '
            Me.LabelForm_PostPeriod.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_PostPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_PostPeriod.Location = New System.Drawing.Point(4, 520)
            Me.LabelForm_PostPeriod.Name = "LabelForm_PostPeriod"
            Me.LabelForm_PostPeriod.Size = New System.Drawing.Size(103, 20)
            Me.LabelForm_PostPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_PostPeriod.TabIndex = 7
            Me.LabelForm_PostPeriod.Text = "Month / Year Cutoff:"
            '
            'ComboBoxForm_PostPeriod
            '
            Me.ComboBoxForm_PostPeriod.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_PostPeriod.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_PostPeriod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_PostPeriod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_PostPeriod.AutoFindItemInDataSource = False
            Me.ComboBoxForm_PostPeriod.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_PostPeriod.BookmarkingEnabled = False
            Me.ComboBoxForm_PostPeriod.ClientCode = ""
            Me.ComboBoxForm_PostPeriod.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.PostPeriod
            Me.ComboBoxForm_PostPeriod.DisableMouseWheel = False
            Me.ComboBoxForm_PostPeriod.DisplayMember = "Description"
            Me.ComboBoxForm_PostPeriod.DisplayName = ""
            Me.ComboBoxForm_PostPeriod.DivisionCode = ""
            Me.ComboBoxForm_PostPeriod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_PostPeriod.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_PostPeriod.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_PostPeriod.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_PostPeriod.FocusHighlightEnabled = True
            Me.ComboBoxForm_PostPeriod.FormattingEnabled = True
            Me.ComboBoxForm_PostPeriod.ItemHeight = 14
            Me.ComboBoxForm_PostPeriod.Location = New System.Drawing.Point(113, 520)
            Me.ComboBoxForm_PostPeriod.Name = "ComboBoxForm_PostPeriod"
            Me.ComboBoxForm_PostPeriod.ReadOnly = False
            Me.ComboBoxForm_PostPeriod.SecurityEnabled = True
            Me.ComboBoxForm_PostPeriod.Size = New System.Drawing.Size(237, 20)
            Me.ComboBoxForm_PostPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_PostPeriod.TabIndex = 8
            Me.ComboBoxForm_PostPeriod.TabOnEnter = True
            Me.ComboBoxForm_PostPeriod.ValueMember = "Code"
            Me.ComboBoxForm_PostPeriod.WatermarkText = "Select Post Period"
            '
            'CheckBoxVersionAndOptions_SaveReportOptions
            '
            Me.CheckBoxVersionAndOptions_SaveReportOptions.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxVersionAndOptions_SaveReportOptions.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxVersionAndOptions_SaveReportOptions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxVersionAndOptions_SaveReportOptions.CheckValue = 0
            Me.CheckBoxVersionAndOptions_SaveReportOptions.CheckValueChecked = 1
            Me.CheckBoxVersionAndOptions_SaveReportOptions.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxVersionAndOptions_SaveReportOptions.CheckValueUnchecked = 0
            Me.CheckBoxVersionAndOptions_SaveReportOptions.ChildControls = CType(resources.GetObject("CheckBoxVersionAndOptions_SaveReportOptions.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxVersionAndOptions_SaveReportOptions.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxVersionAndOptions_SaveReportOptions.Location = New System.Drawing.Point(643, 516)
            Me.CheckBoxVersionAndOptions_SaveReportOptions.Name = "CheckBoxVersionAndOptions_SaveReportOptions"
            Me.CheckBoxVersionAndOptions_SaveReportOptions.OldestSibling = Nothing
            Me.CheckBoxVersionAndOptions_SaveReportOptions.SecurityEnabled = True
            Me.CheckBoxVersionAndOptions_SaveReportOptions.SiblingControls = CType(resources.GetObject("CheckBoxVersionAndOptions_SaveReportOptions.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxVersionAndOptions_SaveReportOptions.Size = New System.Drawing.Size(153, 20)
            Me.CheckBoxVersionAndOptions_SaveReportOptions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxVersionAndOptions_SaveReportOptions.TabIndex = 6
            Me.CheckBoxVersionAndOptions_SaveReportOptions.TabOnEnter = True
            Me.CheckBoxVersionAndOptions_SaveReportOptions.Text = "Save Report Options"
            '
            'CheckBoxVersionAndOptions_ExcludeNonBillableHours
            '
            Me.CheckBoxVersionAndOptions_ExcludeNonBillableHours.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxVersionAndOptions_ExcludeNonBillableHours.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxVersionAndOptions_ExcludeNonBillableHours.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxVersionAndOptions_ExcludeNonBillableHours.CheckValue = 0
            Me.CheckBoxVersionAndOptions_ExcludeNonBillableHours.CheckValueChecked = 1
            Me.CheckBoxVersionAndOptions_ExcludeNonBillableHours.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxVersionAndOptions_ExcludeNonBillableHours.CheckValueUnchecked = 0
            Me.CheckBoxVersionAndOptions_ExcludeNonBillableHours.ChildControls = CType(resources.GetObject("CheckBoxVersionAndOptions_ExcludeNonBillableHours.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxVersionAndOptions_ExcludeNonBillableHours.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxVersionAndOptions_ExcludeNonBillableHours.Location = New System.Drawing.Point(644, 463)
            Me.CheckBoxVersionAndOptions_ExcludeNonBillableHours.Name = "CheckBoxVersionAndOptions_ExcludeNonBillableHours"
            Me.CheckBoxVersionAndOptions_ExcludeNonBillableHours.OldestSibling = Nothing
            Me.CheckBoxVersionAndOptions_ExcludeNonBillableHours.SecurityEnabled = True
            Me.CheckBoxVersionAndOptions_ExcludeNonBillableHours.SiblingControls = CType(resources.GetObject("CheckBoxVersionAndOptions_ExcludeNonBillableHours.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxVersionAndOptions_ExcludeNonBillableHours.Size = New System.Drawing.Size(153, 20)
            Me.CheckBoxVersionAndOptions_ExcludeNonBillableHours.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxVersionAndOptions_ExcludeNonBillableHours.TabIndex = 5
            Me.CheckBoxVersionAndOptions_ExcludeNonBillableHours.TabOnEnter = True
            Me.CheckBoxVersionAndOptions_ExcludeNonBillableHours.Text = "Exclude Non Billable Hours"
            '
            'PanelVersionAndOptions_SummaryOptions
            '
            Me.PanelVersionAndOptions_SummaryOptions.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.PanelVersionAndOptions_SummaryOptions.BackColor = System.Drawing.Color.White
            Me.PanelVersionAndOptions_SummaryOptions.Controls.Add(Me.RadioButtonSummaryOption_JobComp)
            Me.PanelVersionAndOptions_SummaryOptions.Controls.Add(Me.LabelSummaryOptions_SummaryOptions)
            Me.PanelVersionAndOptions_SummaryOptions.Controls.Add(Me.RadioButtonSummaryOptions_SummaryByFunction)
            Me.PanelVersionAndOptions_SummaryOptions.Controls.Add(Me.RadioButtonSummaryOptions_DetailByFunction)
            Me.PanelVersionAndOptions_SummaryOptions.Location = New System.Drawing.Point(400, 463)
            Me.PanelVersionAndOptions_SummaryOptions.Name = "PanelVersionAndOptions_SummaryOptions"
            Me.PanelVersionAndOptions_SummaryOptions.Size = New System.Drawing.Size(237, 73)
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
            Me.RadioButtonSummaryOption_JobComp.Text = "Summary by Job Comp"
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
            Me.LabelSummaryOptions_SummaryOptions.Text = "Summary Options:"
            '
            'RadioButtonSummaryOptions_SummaryByFunction
            '
            Me.RadioButtonSummaryOptions_SummaryByFunction.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSummaryOptions_SummaryByFunction.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSummaryOptions_SummaryByFunction.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSummaryOptions_SummaryByFunction.Checked = True
            Me.RadioButtonSummaryOptions_SummaryByFunction.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonSummaryOptions_SummaryByFunction.CheckValue = "Y"
            Me.RadioButtonSummaryOptions_SummaryByFunction.Location = New System.Drawing.Point(100, 0)
            Me.RadioButtonSummaryOptions_SummaryByFunction.Name = "RadioButtonSummaryOptions_SummaryByFunction"
            Me.RadioButtonSummaryOptions_SummaryByFunction.SecurityEnabled = True
            Me.RadioButtonSummaryOptions_SummaryByFunction.Size = New System.Drawing.Size(137, 20)
            Me.RadioButtonSummaryOptions_SummaryByFunction.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSummaryOptions_SummaryByFunction.TabIndex = 1
            Me.RadioButtonSummaryOptions_SummaryByFunction.TabOnEnter = True
            Me.RadioButtonSummaryOptions_SummaryByFunction.Text = "Summary By Function "
            '
            'RadioButtonSummaryOptions_DetailByFunction
            '
            Me.RadioButtonSummaryOptions_DetailByFunction.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSummaryOptions_DetailByFunction.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSummaryOptions_DetailByFunction.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSummaryOptions_DetailByFunction.Location = New System.Drawing.Point(100, 26)
            Me.RadioButtonSummaryOptions_DetailByFunction.Name = "RadioButtonSummaryOptions_DetailByFunction"
            Me.RadioButtonSummaryOptions_DetailByFunction.SecurityEnabled = True
            Me.RadioButtonSummaryOptions_DetailByFunction.Size = New System.Drawing.Size(137, 20)
            Me.RadioButtonSummaryOptions_DetailByFunction.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSummaryOptions_DetailByFunction.TabIndex = 2
            Me.RadioButtonSummaryOptions_DetailByFunction.TabOnEnter = True
            Me.RadioButtonSummaryOptions_DetailByFunction.TabStop = False
            Me.RadioButtonSummaryOptions_DetailByFunction.Text = "Detail By Function"
            '
            'PanelVersionAndOptions_Include
            '
            Me.PanelVersionAndOptions_Include.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.PanelVersionAndOptions_Include.BackColor = System.Drawing.Color.White
            Me.PanelVersionAndOptions_Include.Controls.Add(Me.LabelInclude_Include)
            Me.PanelVersionAndOptions_Include.Controls.Add(Me.RadioButtonInclude_OpenJobsOnly)
            Me.PanelVersionAndOptions_Include.Controls.Add(Me.RadioButtonInclude_OpenAndClosedJobs)
            Me.PanelVersionAndOptions_Include.Location = New System.Drawing.Point(210, 463)
            Me.PanelVersionAndOptions_Include.Name = "PanelVersionAndOptions_Include"
            Me.PanelVersionAndOptions_Include.Size = New System.Drawing.Size(184, 54)
            Me.PanelVersionAndOptions_Include.TabIndex = 3
            '
            'LabelInclude_Include
            '
            Me.LabelInclude_Include.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelInclude_Include.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelInclude_Include.Location = New System.Drawing.Point(0, 0)
            Me.LabelInclude_Include.Name = "LabelInclude_Include"
            Me.LabelInclude_Include.Size = New System.Drawing.Size(42, 20)
            Me.LabelInclude_Include.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelInclude_Include.TabIndex = 0
            Me.LabelInclude_Include.Text = "Include:"
            '
            'RadioButtonInclude_OpenJobsOnly
            '
            Me.RadioButtonInclude_OpenJobsOnly.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonInclude_OpenJobsOnly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonInclude_OpenJobsOnly.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonInclude_OpenJobsOnly.Checked = True
            Me.RadioButtonInclude_OpenJobsOnly.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonInclude_OpenJobsOnly.CheckValue = "Y"
            Me.RadioButtonInclude_OpenJobsOnly.Location = New System.Drawing.Point(48, 0)
            Me.RadioButtonInclude_OpenJobsOnly.Name = "RadioButtonInclude_OpenJobsOnly"
            Me.RadioButtonInclude_OpenJobsOnly.SecurityEnabled = True
            Me.RadioButtonInclude_OpenJobsOnly.Size = New System.Drawing.Size(134, 20)
            Me.RadioButtonInclude_OpenJobsOnly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonInclude_OpenJobsOnly.TabIndex = 1
            Me.RadioButtonInclude_OpenJobsOnly.TabOnEnter = True
            Me.RadioButtonInclude_OpenJobsOnly.Text = "Open Jobs Only"
            '
            'RadioButtonInclude_OpenAndClosedJobs
            '
            Me.RadioButtonInclude_OpenAndClosedJobs.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonInclude_OpenAndClosedJobs.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonInclude_OpenAndClosedJobs.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonInclude_OpenAndClosedJobs.Location = New System.Drawing.Point(48, 26)
            Me.RadioButtonInclude_OpenAndClosedJobs.Name = "RadioButtonInclude_OpenAndClosedJobs"
            Me.RadioButtonInclude_OpenAndClosedJobs.SecurityEnabled = True
            Me.RadioButtonInclude_OpenAndClosedJobs.Size = New System.Drawing.Size(136, 20)
            Me.RadioButtonInclude_OpenAndClosedJobs.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonInclude_OpenAndClosedJobs.TabIndex = 2
            Me.RadioButtonInclude_OpenAndClosedJobs.TabOnEnter = True
            Me.RadioButtonInclude_OpenAndClosedJobs.TabStop = False
            Me.RadioButtonInclude_OpenAndClosedJobs.Text = "Open And Closed Jobs"
            '
            'PanelVersionAndOptions_SortBy
            '
            Me.PanelVersionAndOptions_SortBy.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.PanelVersionAndOptions_SortBy.BackColor = System.Drawing.Color.White
            Me.PanelVersionAndOptions_SortBy.Controls.Add(Me.LabelSortBy_SortBy)
            Me.PanelVersionAndOptions_SortBy.Controls.Add(Me.RadioButtonSortBy_ClientDivisionProduct)
            Me.PanelVersionAndOptions_SortBy.Controls.Add(Me.RadioButtonSortBy_AccountExecutive)
            Me.PanelVersionAndOptions_SortBy.Location = New System.Drawing.Point(4, 463)
            Me.PanelVersionAndOptions_SortBy.Name = "PanelVersionAndOptions_SortBy"
            Me.PanelVersionAndOptions_SortBy.Size = New System.Drawing.Size(200, 54)
            Me.PanelVersionAndOptions_SortBy.TabIndex = 2
            '
            'LabelSortBy_SortBy
            '
            Me.LabelSortBy_SortBy.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSortBy_SortBy.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSortBy_SortBy.Location = New System.Drawing.Point(0, 0)
            Me.LabelSortBy_SortBy.Name = "LabelSortBy_SortBy"
            Me.LabelSortBy_SortBy.Size = New System.Drawing.Size(42, 20)
            Me.LabelSortBy_SortBy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSortBy_SortBy.TabIndex = 0
            Me.LabelSortBy_SortBy.Text = "Sort By:"
            '
            'RadioButtonSortBy_ClientDivisionProduct
            '
            Me.RadioButtonSortBy_ClientDivisionProduct.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSortBy_ClientDivisionProduct.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSortBy_ClientDivisionProduct.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSortBy_ClientDivisionProduct.Checked = True
            Me.RadioButtonSortBy_ClientDivisionProduct.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonSortBy_ClientDivisionProduct.CheckValue = "Y"
            Me.RadioButtonSortBy_ClientDivisionProduct.Location = New System.Drawing.Point(48, 0)
            Me.RadioButtonSortBy_ClientDivisionProduct.Name = "RadioButtonSortBy_ClientDivisionProduct"
            Me.RadioButtonSortBy_ClientDivisionProduct.SecurityEnabled = True
            Me.RadioButtonSortBy_ClientDivisionProduct.Size = New System.Drawing.Size(152, 20)
            Me.RadioButtonSortBy_ClientDivisionProduct.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSortBy_ClientDivisionProduct.TabIndex = 1
            Me.RadioButtonSortBy_ClientDivisionProduct.TabOnEnter = True
            Me.RadioButtonSortBy_ClientDivisionProduct.Text = "Client / Division / Product"
            '
            'RadioButtonSortBy_AccountExecutive
            '
            Me.RadioButtonSortBy_AccountExecutive.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSortBy_AccountExecutive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSortBy_AccountExecutive.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSortBy_AccountExecutive.Location = New System.Drawing.Point(48, 26)
            Me.RadioButtonSortBy_AccountExecutive.Name = "RadioButtonSortBy_AccountExecutive"
            Me.RadioButtonSortBy_AccountExecutive.SecurityEnabled = True
            Me.RadioButtonSortBy_AccountExecutive.Size = New System.Drawing.Size(152, 20)
            Me.RadioButtonSortBy_AccountExecutive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSortBy_AccountExecutive.TabIndex = 2
            Me.RadioButtonSortBy_AccountExecutive.TabOnEnter = True
            Me.RadioButtonSortBy_AccountExecutive.TabStop = False
            Me.RadioButtonSortBy_AccountExecutive.Text = "Account Executive"
            '
            'TabItemJDA_VersionAndOptionsTab
            '
            Me.TabItemJDA_VersionAndOptionsTab.AttachedControl = Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions
            Me.TabItemJDA_VersionAndOptionsTab.Name = "TabItemJDA_VersionAndOptionsTab"
            Me.TabItemJDA_VersionAndOptionsTab.Text = "Version / Options"
            '
            'TabControlSelectClientsTab_SelectClients
            '
            Me.TabControlSelectClientsTab_SelectClients.Controls.Add(Me.CDPChooserControlSelectClients_SelectClients)
            Me.TabControlSelectClientsTab_SelectClients.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlSelectClientsTab_SelectClients.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlSelectClientsTab_SelectClients.Location = New System.Drawing.Point(0, 27)
            Me.TabControlSelectClientsTab_SelectClients.Name = "TabControlSelectClientsTab_SelectClients"
            Me.TabControlSelectClientsTab_SelectClients.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlSelectClientsTab_SelectClients.Size = New System.Drawing.Size(800, 553)
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
            Me.CDPChooserControlSelectClients_SelectClients.Size = New System.Drawing.Size(792, 545)
            Me.CDPChooserControlSelectClients_SelectClients.TabIndex = 1
            '
            'TabItemJDA_SelectClientsTab
            '
            Me.TabItemJDA_SelectClientsTab.AttachedControl = Me.TabControlSelectClientsTab_SelectClients
            Me.TabItemJDA_SelectClientsTab.Name = "TabItemJDA_SelectClientsTab"
            Me.TabItemJDA_SelectClientsTab.Text = "Select Clients"
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
            Me.TabItemJDA_SelectJobsTab.AttachedControl = Me.TabControlPanelSelectJobsTab_SelectJobs
            Me.TabItemJDA_SelectJobsTab.Name = "TabItemJDA_SelectJobsTab"
            Me.TabItemJDA_SelectJobsTab.Text = "Select Jobs"
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
            Me.DataGridViewSelectOffices_Offices.DataSource = Nothing
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
            'TabControlPanelSelectAccountExecutivesTab_SelectAccountExecutives
            '
            Me.TabControlPanelSelectAccountExecutivesTab_SelectAccountExecutives.Controls.Add(Me.DataGridViewSelectAccountExecutives_AccountExecutives)
            Me.TabControlPanelSelectAccountExecutivesTab_SelectAccountExecutives.Controls.Add(Me.RadioButtonSelectAccountExecutives_AllAccountExecutives)
            Me.TabControlPanelSelectAccountExecutivesTab_SelectAccountExecutives.Controls.Add(Me.RadioButtonSelectAccountExecutives_ChooseAccountExecutives)
            Me.TabControlPanelSelectAccountExecutivesTab_SelectAccountExecutives.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSelectAccountExecutivesTab_SelectAccountExecutives.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSelectAccountExecutivesTab_SelectAccountExecutives.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelSelectAccountExecutivesTab_SelectAccountExecutives.Name = "TabControlPanelSelectAccountExecutivesTab_SelectAccountExecutives"
            Me.TabControlPanelSelectAccountExecutivesTab_SelectAccountExecutives.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSelectAccountExecutivesTab_SelectAccountExecutives.Size = New System.Drawing.Size(800, 553)
            Me.TabControlPanelSelectAccountExecutivesTab_SelectAccountExecutives.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelSelectAccountExecutivesTab_SelectAccountExecutives.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSelectAccountExecutivesTab_SelectAccountExecutives.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSelectAccountExecutivesTab_SelectAccountExecutives.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSelectAccountExecutivesTab_SelectAccountExecutives.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSelectAccountExecutivesTab_SelectAccountExecutives.Style.GradientAngle = 90
            Me.TabControlPanelSelectAccountExecutivesTab_SelectAccountExecutives.TabIndex = 0
            Me.TabControlPanelSelectAccountExecutivesTab_SelectAccountExecutives.TabItem = Me.TabItemJDA_SelectAccountExecutivesTab
            '
            'DataGridViewSelectAccountExecutives_AccountExecutives
            '
            Me.DataGridViewSelectAccountExecutives_AccountExecutives.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewSelectAccountExecutives_AccountExecutives.AllowDragAndDrop = False
            Me.DataGridViewSelectAccountExecutives_AccountExecutives.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewSelectAccountExecutives_AccountExecutives.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSelectAccountExecutives_AccountExecutives.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewSelectAccountExecutives_AccountExecutives.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSelectAccountExecutives_AccountExecutives.AutoFilterLookupColumns = False
            Me.DataGridViewSelectAccountExecutives_AccountExecutives.AutoloadRepositoryDatasource = True
            Me.DataGridViewSelectAccountExecutives_AccountExecutives.AutoUpdateViewCaption = True
            Me.DataGridViewSelectAccountExecutives_AccountExecutives.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewSelectAccountExecutives_AccountExecutives.DataSource = Nothing
            Me.DataGridViewSelectAccountExecutives_AccountExecutives.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewSelectAccountExecutives_AccountExecutives.Enabled = False
            Me.DataGridViewSelectAccountExecutives_AccountExecutives.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSelectAccountExecutives_AccountExecutives.ItemDescription = "Account Executive(s)"
            Me.DataGridViewSelectAccountExecutives_AccountExecutives.Location = New System.Drawing.Point(4, 30)
            Me.DataGridViewSelectAccountExecutives_AccountExecutives.MultiSelect = False
            Me.DataGridViewSelectAccountExecutives_AccountExecutives.Name = "DataGridViewSelectAccountExecutives_AccountExecutives"
            Me.DataGridViewSelectAccountExecutives_AccountExecutives.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSelectAccountExecutives_AccountExecutives.RunStandardValidation = True
            Me.DataGridViewSelectAccountExecutives_AccountExecutives.ShowColumnMenuOnRightClick = False
            Me.DataGridViewSelectAccountExecutives_AccountExecutives.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSelectAccountExecutives_AccountExecutives.Size = New System.Drawing.Size(792, 519)
            Me.DataGridViewSelectAccountExecutives_AccountExecutives.TabIndex = 2
            Me.DataGridViewSelectAccountExecutives_AccountExecutives.UseEmbeddedNavigator = False
            Me.DataGridViewSelectAccountExecutives_AccountExecutives.ViewCaptionHeight = -1
            '
            'RadioButtonSelectAccountExecutives_AllAccountExecutives
            '
            Me.RadioButtonSelectAccountExecutives_AllAccountExecutives.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectAccountExecutives_AllAccountExecutives.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectAccountExecutives_AllAccountExecutives.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectAccountExecutives_AllAccountExecutives.Checked = True
            Me.RadioButtonSelectAccountExecutives_AllAccountExecutives.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonSelectAccountExecutives_AllAccountExecutives.CheckValue = "Y"
            Me.RadioButtonSelectAccountExecutives_AllAccountExecutives.Location = New System.Drawing.Point(4, 4)
            Me.RadioButtonSelectAccountExecutives_AllAccountExecutives.Name = "RadioButtonSelectAccountExecutives_AllAccountExecutives"
            Me.RadioButtonSelectAccountExecutives_AllAccountExecutives.SecurityEnabled = True
            Me.RadioButtonSelectAccountExecutives_AllAccountExecutives.Size = New System.Drawing.Size(136, 20)
            Me.RadioButtonSelectAccountExecutives_AllAccountExecutives.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectAccountExecutives_AllAccountExecutives.TabIndex = 0
            Me.RadioButtonSelectAccountExecutives_AllAccountExecutives.TabOnEnter = True
            Me.RadioButtonSelectAccountExecutives_AllAccountExecutives.Text = "All Account Executives"
            '
            'RadioButtonSelectAccountExecutives_ChooseAccountExecutives
            '
            Me.RadioButtonSelectAccountExecutives_ChooseAccountExecutives.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectAccountExecutives_ChooseAccountExecutives.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectAccountExecutives_ChooseAccountExecutives.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectAccountExecutives_ChooseAccountExecutives.Location = New System.Drawing.Point(146, 4)
            Me.RadioButtonSelectAccountExecutives_ChooseAccountExecutives.Name = "RadioButtonSelectAccountExecutives_ChooseAccountExecutives"
            Me.RadioButtonSelectAccountExecutives_ChooseAccountExecutives.SecurityEnabled = True
            Me.RadioButtonSelectAccountExecutives_ChooseAccountExecutives.Size = New System.Drawing.Size(164, 20)
            Me.RadioButtonSelectAccountExecutives_ChooseAccountExecutives.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectAccountExecutives_ChooseAccountExecutives.TabIndex = 1
            Me.RadioButtonSelectAccountExecutives_ChooseAccountExecutives.TabOnEnter = True
            Me.RadioButtonSelectAccountExecutives_ChooseAccountExecutives.TabStop = False
            Me.RadioButtonSelectAccountExecutives_ChooseAccountExecutives.Text = "Choose Account Executives"
            '
            'TabItemJDA_SelectAccountExecutivesTab
            '
            Me.TabItemJDA_SelectAccountExecutivesTab.AttachedControl = Me.TabControlPanelSelectAccountExecutivesTab_SelectAccountExecutives
            Me.TabItemJDA_SelectAccountExecutivesTab.Name = "TabItemJDA_SelectAccountExecutivesTab"
            Me.TabItemJDA_SelectAccountExecutivesTab.Text = "Select Account Executives"
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
            'JobDetailAnalysisInitialLoadingDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(824, 630)
            Me.Controls.Add(Me.ButtonForm_View)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.TabControlForm_JDA)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "JobDetailAnalysisInitialLoadingDialog"
            Me.Text = "Job Detail Analysis"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            CType(Me.TabControlForm_JDA, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_JDA.ResumeLayout(False)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.ResumeLayout(False)
            Me.PanelVersionAndOptions_SummaryOptions.ResumeLayout(False)
            Me.PanelVersionAndOptions_Include.ResumeLayout(False)
            Me.PanelVersionAndOptions_SortBy.ResumeLayout(False)
            Me.TabControlSelectClientsTab_SelectClients.ResumeLayout(False)
            Me.TabControlPanelSelectJobsTab_SelectJobs.ResumeLayout(False)
            Me.PanelSelectJobs_JobStatus.ResumeLayout(False)
            Me.TabControlPanelSelectOfficesTab_SelectOffices.ResumeLayout(False)
            Me.TabControlPanelSelectAccountExecutivesTab_SelectAccountExecutives.ResumeLayout(False)
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewVersionAndOptions_Versions As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_ViewReport As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents LabelGroupVersionAndOptions_ReportOptions As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TabControlForm_JDA As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelVersionAndOptionsTab_VersionAndOptions As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents RadioButtonSortBy_AccountExecutive As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSortBy_ClientDivisionProduct As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents TabItemJDA_VersionAndOptionsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlSelectClientsTab_SelectClients As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemJDA_SelectClientsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelSelectOfficesTab_SelectOffices As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemJDA_SelectOfficesTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents PanelVersionAndOptions_SortBy As System.Windows.Forms.Panel
        Friend WithEvents LabelSortBy_SortBy As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxVersionAndOptions_SaveReportOptions As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxVersionAndOptions_ExcludeNonBillableHours As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents PanelVersionAndOptions_SummaryOptions As System.Windows.Forms.Panel
        Friend WithEvents LabelSummaryOptions_SummaryOptions As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents RadioButtonSummaryOptions_SummaryByFunction As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSummaryOptions_DetailByFunction As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents PanelVersionAndOptions_Include As System.Windows.Forms.Panel
        Friend WithEvents LabelInclude_Include As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents RadioButtonInclude_OpenJobsOnly As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonInclude_OpenAndClosedJobs As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSelectOffices_AllOffices As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSelectOffices_ChooseOffices As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents DataGridViewSelectOffices_Offices As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TabControlPanelSelectJobsTab_SelectJobs As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents PanelSelectJobs_JobStatus As System.Windows.Forms.Panel
        Friend WithEvents RadioButtonJobStatus_OpenJobs As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonJobStatus_OpenClosedJobs As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents DataGridViewSelectJobs_Jobs As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RadioButtonSelectJobs_AllJobs As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSelectJobs_ChooseJobs As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents TabItemJDA_SelectJobsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelSelectSalesClassesTab_SelectSalesClasses As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewSelectSalesClasses_SalesClasses As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RadioButtonSelectSalesClasses_AllSalesClasses As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSelectSalesClasses_ChooseSalesClasses As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents TabItemJDA_SelectSalesClassesTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelSelectAccountExecutivesTab_SelectAccountExecutives As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewSelectAccountExecutives_AccountExecutives As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RadioButtonSelectAccountExecutives_AllAccountExecutives As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSelectAccountExecutives_ChooseAccountExecutives As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents TabItemJDA_SelectAccountExecutivesTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents ButtonForm_View As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents RadioButtonSummaryOption_JobComp As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents CDPChooserControlSelectClients_SelectClients As WinForm.Presentation.Controls.CDPChooserControl
        Friend WithEvents LabelForm_PostPeriod As WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_PostPeriod As WinForm.Presentation.Controls.ComboBox
        Friend WithEvents CheckBoxVersionAndOptions_SuppressZeroMUDown As WinForm.Presentation.Controls.CheckBox
    End Class

End Namespace