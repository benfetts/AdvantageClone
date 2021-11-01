Namespace Reporting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class BillingApprovalInitialLoadingDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BillingApprovalInitialLoadingDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.PanelForm_TopSection = New System.Windows.Forms.Panel()
            Me.LabelTopSection_Report = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxTopSection_Report = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.TabControlPanel2 = New DevComponents.DotNetBar.TabControlPanel()
            Me.TabControlPanelSelectJobsTab_SelectJobs = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelSelectJobs_JobStatus = New System.Windows.Forms.Panel()
            Me.RadioButtonJobStatus_OpenJobs = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonJobStatus_OpenClosedJobs = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.DataGridViewSelectJobs_Jobs = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonSelectJobs_AllJobs = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectJobs_ChooseJobs = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TabItemJDA_SelectJobsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.PanelForm_Bottom = New System.Windows.Forms.Panel()
            Me.TabControlForm_JDA = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives = New DevComponents.DotNetBar.TabControlPanel()
            Me.AEChooserControl_Production = New AdvantageFramework.WinForm.Presentation.Controls.AEChooserControl()
            Me.TabItemProductionCriteria_SelectAccountExecutivesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions = New DevComponents.DotNetBar.TabControlPanel()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.RadioButtonControl_OpenOnly = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControl_OpenandClosed = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.Label1 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.PanelForm_DataOption = New System.Windows.Forms.Panel()
            Me.RadioButtonControl_Unbilled = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonDataOption_Billed = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonDataOption_All = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
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
            Me.TabControlSelectClientsTab_SelectClients = New DevComponents.DotNetBar.TabControlPanel()
            Me.CDPChooserControlSelectClients_SelectClients = New AdvantageFramework.WinForm.Presentation.Controls.CDPChooserControl()
            Me.TabItemJDA_SelectClientsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.PanelForm_TopSection.SuspendLayout()
            Me.TabControlPanel2.SuspendLayout()
            Me.TabControlPanelSelectJobsTab_SelectJobs.SuspendLayout()
            Me.PanelSelectJobs_JobStatus.SuspendLayout()
            Me.PanelForm_Bottom.SuspendLayout()
            CType(Me.TabControlForm_JDA, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_JDA.SuspendLayout()
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.SuspendLayout()
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            Me.PanelForm_DataOption.SuspendLayout()
            CType(Me.DateTimePickerForm_To, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerForm_From, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlSelectClientsTab_SelectClients.SuspendLayout()
            Me.Panel1.SuspendLayout()
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
            Me.TabControlForm_JDA.Controls.Add(Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives)
            Me.TabControlForm_JDA.Controls.Add(Me.TabControlPanel2)
            Me.TabControlForm_JDA.Controls.Add(Me.TabControlSelectClientsTab_SelectClients)
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
            Me.TabControlForm_JDA.Tabs.Add(Me.TabItemJDA_SelectJobsTab)
            Me.TabControlForm_JDA.Tabs.Add(Me.TabItemProductionCriteria_SelectAccountExecutivesTab)
            '
            'TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives
            '
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.Controls.Add(Me.AEChooserControl_Production)
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.Name = "TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives"
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.Size = New System.Drawing.Size(1017, 571)
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.Style.GradientAngle = 90
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.TabIndex = 9
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.TabItem = Me.TabItemProductionCriteria_SelectAccountExecutivesTab
            '
            'AEChooserControl_Production
            '
            Me.AEChooserControl_Production.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.AEChooserControl_Production.BackColor = System.Drawing.Color.Transparent
            Me.AEChooserControl_Production.Location = New System.Drawing.Point(4, 4)
            Me.AEChooserControl_Production.Name = "AEChooserControl_Production"
            Me.AEChooserControl_Production.Size = New System.Drawing.Size(906, 473)
            Me.AEChooserControl_Production.TabIndex = 0
            '
            'TabItemProductionCriteria_SelectAccountExecutivesTab
            '
            Me.TabItemProductionCriteria_SelectAccountExecutivesTab.AttachedControl = Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives
            Me.TabItemProductionCriteria_SelectAccountExecutivesTab.Name = "TabItemProductionCriteria_SelectAccountExecutivesTab"
            Me.TabItemProductionCriteria_SelectAccountExecutivesTab.Text = "Select Account Executives"
            '
            'TabControlPanelVersionAndOptionsTab_VersionAndOptions
            '
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.GroupBox1)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.Label1)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.PanelForm_DataOption)
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
            'GroupBox1
            '
            Me.GroupBox1.BackColor = System.Drawing.SystemColors.Window
            Me.GroupBox1.Controls.Add(Me.RadioButtonControl_OpenOnly)
            Me.GroupBox1.Controls.Add(Me.RadioButtonControl_OpenandClosed)
            Me.GroupBox1.Location = New System.Drawing.Point(88, 92)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(170, 46)
            Me.GroupBox1.TabIndex = 57
            Me.GroupBox1.TabStop = False
            '
            'RadioButtonControl_OpenOnly
            '
            Me.RadioButtonControl_OpenOnly.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControl_OpenOnly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControl_OpenOnly.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControl_OpenOnly.Location = New System.Drawing.Point(0, 0)
            Me.RadioButtonControl_OpenOnly.Name = "RadioButtonControl_OpenOnly"
            Me.RadioButtonControl_OpenOnly.SecurityEnabled = True
            Me.RadioButtonControl_OpenOnly.Size = New System.Drawing.Size(170, 20)
            Me.RadioButtonControl_OpenOnly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControl_OpenOnly.TabIndex = 46
            Me.RadioButtonControl_OpenOnly.TabOnEnter = True
            Me.RadioButtonControl_OpenOnly.TabStop = False
            Me.RadioButtonControl_OpenOnly.Text = "Open Only"
            '
            'RadioButtonControl_OpenandClosed
            '
            Me.RadioButtonControl_OpenandClosed.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControl_OpenandClosed.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControl_OpenandClosed.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControl_OpenandClosed.Location = New System.Drawing.Point(0, 26)
            Me.RadioButtonControl_OpenandClosed.Name = "RadioButtonControl_OpenandClosed"
            Me.RadioButtonControl_OpenandClosed.SecurityEnabled = True
            Me.RadioButtonControl_OpenandClosed.Size = New System.Drawing.Size(170, 20)
            Me.RadioButtonControl_OpenandClosed.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControl_OpenandClosed.TabIndex = 47
            Me.RadioButtonControl_OpenandClosed.TabOnEnter = True
            Me.RadioButtonControl_OpenandClosed.TabStop = False
            Me.RadioButtonControl_OpenandClosed.Text = "Open and Closed"
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.Label1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label1.Location = New System.Drawing.Point(12, 92)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(70, 20)
            Me.Label1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label1.TabIndex = 56
            Me.Label1.Text = "Job Option:"
            '
            'PanelForm_DataOption
            '
            Me.PanelForm_DataOption.BackColor = System.Drawing.Color.White
            Me.PanelForm_DataOption.Controls.Add(Me.RadioButtonControl_Unbilled)
            Me.PanelForm_DataOption.Controls.Add(Me.RadioButtonDataOption_Billed)
            Me.PanelForm_DataOption.Controls.Add(Me.RadioButtonDataOption_All)
            Me.PanelForm_DataOption.Location = New System.Drawing.Point(87, 9)
            Me.PanelForm_DataOption.Name = "PanelForm_DataOption"
            Me.PanelForm_DataOption.Size = New System.Drawing.Size(286, 25)
            Me.PanelForm_DataOption.TabIndex = 44
            '
            'RadioButtonControl_Unbilled
            '
            Me.RadioButtonControl_Unbilled.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControl_Unbilled.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControl_Unbilled.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControl_Unbilled.Location = New System.Drawing.Point(130, 2)
            Me.RadioButtonControl_Unbilled.Name = "RadioButtonControl_Unbilled"
            Me.RadioButtonControl_Unbilled.SecurityEnabled = True
            Me.RadioButtonControl_Unbilled.Size = New System.Drawing.Size(68, 20)
            Me.RadioButtonControl_Unbilled.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControl_Unbilled.TabIndex = 2
            Me.RadioButtonControl_Unbilled.TabOnEnter = True
            Me.RadioButtonControl_Unbilled.TabStop = False
            Me.RadioButtonControl_Unbilled.Text = "Unbilled"
            '
            'RadioButtonDataOption_Billed
            '
            Me.RadioButtonDataOption_Billed.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonDataOption_Billed.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonDataOption_Billed.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonDataOption_Billed.Location = New System.Drawing.Point(56, 3)
            Me.RadioButtonDataOption_Billed.Name = "RadioButtonDataOption_Billed"
            Me.RadioButtonDataOption_Billed.SecurityEnabled = True
            Me.RadioButtonDataOption_Billed.Size = New System.Drawing.Size(68, 20)
            Me.RadioButtonDataOption_Billed.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonDataOption_Billed.TabIndex = 1
            Me.RadioButtonDataOption_Billed.TabOnEnter = True
            Me.RadioButtonDataOption_Billed.TabStop = False
            Me.RadioButtonDataOption_Billed.Text = "Billed"
            '
            'RadioButtonDataOption_All
            '
            Me.RadioButtonDataOption_All.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonDataOption_All.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonDataOption_All.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonDataOption_All.Checked = True
            Me.RadioButtonDataOption_All.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonDataOption_All.CheckValue = "Y"
            Me.RadioButtonDataOption_All.Location = New System.Drawing.Point(0, 3)
            Me.RadioButtonDataOption_All.Name = "RadioButtonDataOption_All"
            Me.RadioButtonDataOption_All.SecurityEnabled = True
            Me.RadioButtonDataOption_All.Size = New System.Drawing.Size(50, 20)
            Me.RadioButtonDataOption_All.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonDataOption_All.TabIndex = 0
            Me.RadioButtonDataOption_All.TabOnEnter = True
            Me.RadioButtonDataOption_All.Text = "All"
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
            Me.LabelForm_DateType.Text = "Include:"
            '
            'TabItemJDA_VersionAndOptionsTab
            '
            Me.TabItemJDA_VersionAndOptionsTab.AttachedControl = Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions
            Me.TabItemJDA_VersionAndOptionsTab.Name = "TabItemJDA_VersionAndOptionsTab"
            Me.TabItemJDA_VersionAndOptionsTab.Text = "Report Options"
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
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.TabControlForm_JDA)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Panel1.Location = New System.Drawing.Point(0, 37)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(1041, 607)
            Me.Panel1.TabIndex = 12
            '
            'BillingApprovalInitialLoadingDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1041, 687)
            Me.Controls.Add(Me.Panel1)
            Me.Controls.Add(Me.PanelForm_Bottom)
            Me.Controls.Add(Me.PanelForm_TopSection)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "BillingApprovalInitialLoadingDialog"
            Me.Text = "Billing Approval Initial Criteria"
            Me.PanelForm_TopSection.ResumeLayout(False)
            Me.TabControlPanel2.ResumeLayout(False)
            Me.TabControlPanelSelectJobsTab_SelectJobs.ResumeLayout(False)
            Me.PanelSelectJobs_JobStatus.ResumeLayout(False)
            Me.PanelForm_Bottom.ResumeLayout(False)
            CType(Me.TabControlForm_JDA, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_JDA.ResumeLayout(False)
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.ResumeLayout(False)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.ResumeLayout(False)
            Me.GroupBox1.ResumeLayout(False)
            Me.PanelForm_DataOption.ResumeLayout(False)
            CType(Me.DateTimePickerForm_To, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerForm_From, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlSelectClientsTab_SelectClients.ResumeLayout(False)
            Me.Panel1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents PanelForm_TopSection As Windows.Forms.Panel
        Friend WithEvents LabelTopSection_Report As WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxTopSection_Report As WinForm.Presentation.Controls.ComboBox
        Friend WithEvents PanelForm_Bottom As Windows.Forms.Panel
        Friend WithEvents TabControlPanel2 As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabControlPanelSelectJobsTab_SelectJobs As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents PanelSelectJobs_JobStatus As Windows.Forms.Panel
        Friend WithEvents RadioButtonJobStatus_OpenJobs As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonJobStatus_OpenClosedJobs As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents DataGridViewSelectJobs_Jobs As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RadioButtonSelectJobs_AllJobs As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSelectJobs_ChooseJobs As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents TabItemJDA_SelectJobsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlForm_JDA As WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlSelectClientsTab_SelectClients As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents CDPChooserControlSelectClients_SelectClients As WinForm.Presentation.Controls.CDPChooserControl
        Friend WithEvents TabItemJDA_SelectClientsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelVersionAndOptionsTab_VersionAndOptions As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents ButtonInvoiceDate_2Year As WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonInvoiceDate_1Year As WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonInvoiceDate_MTD As WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonInvoiceDate_YTD As WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_To As WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_From As WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerForm_To As WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerForm_From As WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents LabelForm_DateType As WinForm.Presentation.Controls.Label
        Friend WithEvents TabItemJDA_VersionAndOptionsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents Panel1 As Windows.Forms.Panel
        Friend WithEvents TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents AEChooserControl_Production As WinForm.Presentation.Controls.AEChooserControl
        Friend WithEvents TabItemProductionCriteria_SelectAccountExecutivesTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents PanelForm_DataOption As Windows.Forms.Panel
        Friend WithEvents RadioButtonDataOption_Billed As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonDataOption_All As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControl_Unbilled As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
        Friend WithEvents RadioButtonControl_OpenOnly As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControl_OpenandClosed As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents Label1 As WinForm.Presentation.Controls.Label
    End Class

End Namespace
