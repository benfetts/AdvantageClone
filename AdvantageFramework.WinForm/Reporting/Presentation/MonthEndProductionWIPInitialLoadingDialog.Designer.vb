Namespace Reporting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MonthEndProductionWIPInitialLoadingDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MonthEndProductionWIPInitialLoadingDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.PanelForm_TopSection = New System.Windows.Forms.Panel()
            Me.ComboBoxTopSection_ReportSeries = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelTopSection_Report = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTopSection_ReportSeries = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxTopSection_Report = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.TabControlForm_JDA = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlSelectClientsTab_SelectClients = New DevComponents.DotNetBar.TabControlPanel()
            Me.CDPChooserControlSelectClients_SelectClients = New AdvantageFramework.WinForm.Presentation.Controls.CDPChooserControl()
            Me.TabItemJDA_SelectClientsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions = New DevComponents.DotNetBar.TabControlPanel()
            Me.DateTimePickerAgingDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.RadioButtonForm_Invoice = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonForm_InvoiceDueDate = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.LabelForm_AgingOption = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_AgingDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.RadioButtonControl_Orders = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControl_OpenOrdersGLAccountOrders = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControl_ZeroBalanceOrders = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControl_OpenOrdersGLAccountLineOrders = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.RadioButtonControl_OpenOnly = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControl_OpenandClosed = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.Label2 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_StartingPostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_EndPostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.Label1 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemJDA_VersionAndOptionsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelSelectOfficesTab_SelectOffices = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewSelectOffices_Offices = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonSelectOffices_AllOffices = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectOffices_ChooseOffices = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TabItemJDA_SelectOfficesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.PanelForm_Bottom = New System.Windows.Forms.Panel()
            Me.PanelForm_TopSection.SuspendLayout()
            CType(Me.TabControlForm_JDA, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_JDA.SuspendLayout()
            Me.TabControlSelectClientsTab_SelectClients.SuspendLayout()
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.SuspendLayout()
            CType(Me.DateTimePickerAgingDate, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox2.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            Me.TabControlPanelSelectOfficesTab_SelectOffices.SuspendLayout()
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
            Me.PanelForm_TopSection.Controls.Add(Me.ComboBoxTopSection_ReportSeries)
            Me.PanelForm_TopSection.Controls.Add(Me.LabelTopSection_Report)
            Me.PanelForm_TopSection.Controls.Add(Me.LabelTopSection_ReportSeries)
            Me.PanelForm_TopSection.Controls.Add(Me.ComboBoxTopSection_Report)
            Me.PanelForm_TopSection.Dock = System.Windows.Forms.DockStyle.Top
            Me.PanelForm_TopSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_TopSection.Name = "PanelForm_TopSection"
            Me.PanelForm_TopSection.Size = New System.Drawing.Size(1041, 68)
            Me.PanelForm_TopSection.TabIndex = 11
            Me.PanelForm_TopSection.Visible = False
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
            'LabelTopSection_Report
            '
            Me.LabelTopSection_Report.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTopSection_Report.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTopSection_Report.Location = New System.Drawing.Point(12, 39)
            Me.LabelTopSection_Report.Name = "LabelTopSection_Report"
            Me.LabelTopSection_Report.Size = New System.Drawing.Size(106, 20)
            Me.LabelTopSection_Report.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTopSection_Report.TabIndex = 2
            Me.LabelTopSection_Report.Text = "Report:"
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
            Me.ComboBoxTopSection_Report.Location = New System.Drawing.Point(124, 38)
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
            Me.TabControlForm_JDA.Controls.Add(Me.TabControlSelectClientsTab_SelectClients)
            Me.TabControlForm_JDA.Controls.Add(Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions)
            Me.TabControlForm_JDA.Controls.Add(Me.TabControlPanelSelectOfficesTab_SelectOffices)
            Me.TabControlForm_JDA.Location = New System.Drawing.Point(12, 3)
            Me.TabControlForm_JDA.Name = "TabControlForm_JDA"
            Me.TabControlForm_JDA.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_JDA.SelectedTabIndex = 0
            Me.TabControlForm_JDA.Size = New System.Drawing.Size(1017, 567)
            Me.TabControlForm_JDA.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_JDA.TabIndex = 37
            Me.TabControlForm_JDA.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_JDA.Tabs.Add(Me.TabItemJDA_VersionAndOptionsTab)
            Me.TabControlForm_JDA.Tabs.Add(Me.TabItemJDA_SelectOfficesTab)
            Me.TabControlForm_JDA.Tabs.Add(Me.TabItemJDA_SelectClientsTab)
            '
            'TabControlSelectClientsTab_SelectClients
            '
            Me.TabControlSelectClientsTab_SelectClients.Controls.Add(Me.CDPChooserControlSelectClients_SelectClients)
            Me.TabControlSelectClientsTab_SelectClients.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlSelectClientsTab_SelectClients.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlSelectClientsTab_SelectClients.Location = New System.Drawing.Point(0, 27)
            Me.TabControlSelectClientsTab_SelectClients.Name = "TabControlSelectClientsTab_SelectClients"
            Me.TabControlSelectClientsTab_SelectClients.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlSelectClientsTab_SelectClients.Size = New System.Drawing.Size(1017, 540)
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
            Me.CDPChooserControlSelectClients_SelectClients.Size = New System.Drawing.Size(1009, 532)
            Me.CDPChooserControlSelectClients_SelectClients.TabIndex = 1
            '
            'TabItemJDA_SelectClientsTab
            '
            Me.TabItemJDA_SelectClientsTab.AttachedControl = Me.TabControlSelectClientsTab_SelectClients
            Me.TabItemJDA_SelectClientsTab.Name = "TabItemJDA_SelectClientsTab"
            Me.TabItemJDA_SelectClientsTab.Text = "Select Clients"
            Me.TabItemJDA_SelectClientsTab.Visible = False
            '
            'TabControlPanelVersionAndOptionsTab_VersionAndOptions
            '
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.DateTimePickerAgingDate)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.RadioButtonForm_Invoice)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.RadioButtonForm_InvoiceDueDate)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.LabelForm_AgingOption)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.LabelForm_AgingDate)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.GroupBox2)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.GroupBox1)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.Label2)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.LabelForm_StartingPostPeriod)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.ComboBoxForm_EndPostPeriod)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.Label1)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Name = "TabControlPanelVersionAndOptionsTab_VersionAndOptions"
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Size = New System.Drawing.Size(1017, 540)
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
            'DateTimePickerAgingDate
            '
            Me.DateTimePickerAgingDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerAgingDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerAgingDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerAgingDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerAgingDate.ButtonDropDown.Visible = True
            Me.DateTimePickerAgingDate.ButtonFreeText.Checked = True
            Me.DateTimePickerAgingDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerAgingDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerAgingDate.DisplayName = ""
            Me.DateTimePickerAgingDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerAgingDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerAgingDate.FocusHighlightEnabled = True
            Me.DateTimePickerAgingDate.FreeTextEntryMode = True
            Me.DateTimePickerAgingDate.IsPopupCalendarOpen = False
            Me.DateTimePickerAgingDate.Location = New System.Drawing.Point(441, 14)
            Me.DateTimePickerAgingDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerAgingDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerAgingDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerAgingDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerAgingDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerAgingDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerAgingDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerAgingDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerAgingDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerAgingDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerAgingDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerAgingDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerAgingDate.MonthCalendar.DisplayMonth = New Date(2013, 4, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerAgingDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerAgingDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerAgingDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerAgingDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerAgingDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerAgingDate.Name = "DateTimePickerAgingDate"
            Me.DateTimePickerAgingDate.ReadOnly = False
            Me.DateTimePickerAgingDate.Size = New System.Drawing.Size(194, 20)
            Me.DateTimePickerAgingDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerAgingDate.TabIndex = 58
            Me.DateTimePickerAgingDate.TabOnEnter = True
            Me.DateTimePickerAgingDate.Value = New Date(2013, 4, 16, 10, 23, 19, 434)
            Me.DateTimePickerAgingDate.Visible = False
            '
            'RadioButtonForm_Invoice
            '
            Me.RadioButtonForm_Invoice.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonForm_Invoice.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonForm_Invoice.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonForm_Invoice.Checked = True
            Me.RadioButtonForm_Invoice.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonForm_Invoice.CheckValue = "Y"
            Me.RadioButtonForm_Invoice.Location = New System.Drawing.Point(441, 40)
            Me.RadioButtonForm_Invoice.Name = "RadioButtonForm_Invoice"
            Me.RadioButtonForm_Invoice.SecurityEnabled = True
            Me.RadioButtonForm_Invoice.Size = New System.Drawing.Size(68, 20)
            Me.RadioButtonForm_Invoice.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonForm_Invoice.TabIndex = 60
            Me.RadioButtonForm_Invoice.TabOnEnter = True
            Me.RadioButtonForm_Invoice.Text = "Invoice"
            Me.RadioButtonForm_Invoice.Visible = False
            '
            'RadioButtonForm_InvoiceDueDate
            '
            Me.RadioButtonForm_InvoiceDueDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonForm_InvoiceDueDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonForm_InvoiceDueDate.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonForm_InvoiceDueDate.Location = New System.Drawing.Point(515, 40)
            Me.RadioButtonForm_InvoiceDueDate.Name = "RadioButtonForm_InvoiceDueDate"
            Me.RadioButtonForm_InvoiceDueDate.SecurityEnabled = True
            Me.RadioButtonForm_InvoiceDueDate.Size = New System.Drawing.Size(120, 20)
            Me.RadioButtonForm_InvoiceDueDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonForm_InvoiceDueDate.TabIndex = 61
            Me.RadioButtonForm_InvoiceDueDate.TabOnEnter = True
            Me.RadioButtonForm_InvoiceDueDate.TabStop = False
            Me.RadioButtonForm_InvoiceDueDate.Text = "Invoice Due Date"
            Me.RadioButtonForm_InvoiceDueDate.Visible = False
            '
            'LabelForm_AgingOption
            '
            Me.LabelForm_AgingOption.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_AgingOption.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_AgingOption.Location = New System.Drawing.Point(329, 40)
            Me.LabelForm_AgingOption.Name = "LabelForm_AgingOption"
            Me.LabelForm_AgingOption.Size = New System.Drawing.Size(106, 20)
            Me.LabelForm_AgingOption.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_AgingOption.TabIndex = 59
            Me.LabelForm_AgingOption.Text = "Aging Option:"
            Me.LabelForm_AgingOption.Visible = False
            '
            'LabelForm_AgingDate
            '
            Me.LabelForm_AgingDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_AgingDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_AgingDate.Location = New System.Drawing.Point(329, 14)
            Me.LabelForm_AgingDate.Name = "LabelForm_AgingDate"
            Me.LabelForm_AgingDate.Size = New System.Drawing.Size(106, 20)
            Me.LabelForm_AgingDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_AgingDate.TabIndex = 57
            Me.LabelForm_AgingDate.Text = "Aging Date:"
            Me.LabelForm_AgingDate.Visible = False
            '
            'GroupBox2
            '
            Me.GroupBox2.BackColor = System.Drawing.SystemColors.Window
            Me.GroupBox2.Controls.Add(Me.RadioButtonControl_Orders)
            Me.GroupBox2.Controls.Add(Me.RadioButtonControl_OpenOrdersGLAccountOrders)
            Me.GroupBox2.Controls.Add(Me.RadioButtonControl_ZeroBalanceOrders)
            Me.GroupBox2.Controls.Add(Me.RadioButtonControl_OpenOrdersGLAccountLineOrders)
            Me.GroupBox2.Location = New System.Drawing.Point(87, 92)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(208, 46)
            Me.GroupBox2.TabIndex = 56
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Visible = False
            '
            'RadioButtonControl_Orders
            '
            Me.RadioButtonControl_Orders.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControl_Orders.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControl_Orders.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControl_Orders.Location = New System.Drawing.Point(0, 0)
            Me.RadioButtonControl_Orders.Name = "RadioButtonControl_Orders"
            Me.RadioButtonControl_Orders.SecurityEnabled = True
            Me.RadioButtonControl_Orders.Size = New System.Drawing.Size(208, 20)
            Me.RadioButtonControl_Orders.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControl_Orders.TabIndex = 55
            Me.RadioButtonControl_Orders.TabOnEnter = True
            Me.RadioButtonControl_Orders.TabStop = False
            Me.RadioButtonControl_Orders.Text = "Orders"
            '
            'RadioButtonControl_OpenOrdersGLAccountOrders
            '
            Me.RadioButtonControl_OpenOrdersGLAccountOrders.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControl_OpenOrdersGLAccountOrders.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControl_OpenOrdersGLAccountOrders.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControl_OpenOrdersGLAccountOrders.Location = New System.Drawing.Point(0, 52)
            Me.RadioButtonControl_OpenOrdersGLAccountOrders.Name = "RadioButtonControl_OpenOrdersGLAccountOrders"
            Me.RadioButtonControl_OpenOrdersGLAccountOrders.SecurityEnabled = True
            Me.RadioButtonControl_OpenOrdersGLAccountOrders.Size = New System.Drawing.Size(208, 20)
            Me.RadioButtonControl_OpenOrdersGLAccountOrders.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControl_OpenOrdersGLAccountOrders.TabIndex = 52
            Me.RadioButtonControl_OpenOrdersGLAccountOrders.TabOnEnter = True
            Me.RadioButtonControl_OpenOrdersGLAccountOrders.TabStop = False
            Me.RadioButtonControl_OpenOrdersGLAccountOrders.Text = "GL Account Orders"
            Me.RadioButtonControl_OpenOrdersGLAccountOrders.Visible = False
            '
            'RadioButtonControl_ZeroBalanceOrders
            '
            Me.RadioButtonControl_ZeroBalanceOrders.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControl_ZeroBalanceOrders.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControl_ZeroBalanceOrders.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControl_ZeroBalanceOrders.Location = New System.Drawing.Point(0, 26)
            Me.RadioButtonControl_ZeroBalanceOrders.Name = "RadioButtonControl_ZeroBalanceOrders"
            Me.RadioButtonControl_ZeroBalanceOrders.SecurityEnabled = True
            Me.RadioButtonControl_ZeroBalanceOrders.Size = New System.Drawing.Size(208, 20)
            Me.RadioButtonControl_ZeroBalanceOrders.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControl_ZeroBalanceOrders.TabIndex = 54
            Me.RadioButtonControl_ZeroBalanceOrders.TabOnEnter = True
            Me.RadioButtonControl_ZeroBalanceOrders.TabStop = False
            Me.RadioButtonControl_ZeroBalanceOrders.Text = "Zero Balance Orders"
            '
            'RadioButtonControl_OpenOrdersGLAccountLineOrders
            '
            Me.RadioButtonControl_OpenOrdersGLAccountLineOrders.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControl_OpenOrdersGLAccountLineOrders.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControl_OpenOrdersGLAccountLineOrders.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControl_OpenOrdersGLAccountLineOrders.Location = New System.Drawing.Point(0, 78)
            Me.RadioButtonControl_OpenOrdersGLAccountLineOrders.Name = "RadioButtonControl_OpenOrdersGLAccountLineOrders"
            Me.RadioButtonControl_OpenOrdersGLAccountLineOrders.SecurityEnabled = True
            Me.RadioButtonControl_OpenOrdersGLAccountLineOrders.Size = New System.Drawing.Size(208, 20)
            Me.RadioButtonControl_OpenOrdersGLAccountLineOrders.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControl_OpenOrdersGLAccountLineOrders.TabIndex = 53
            Me.RadioButtonControl_OpenOrdersGLAccountLineOrders.TabOnEnter = True
            Me.RadioButtonControl_OpenOrdersGLAccountLineOrders.TabStop = False
            Me.RadioButtonControl_OpenOrdersGLAccountLineOrders.Text = "GL Account/Line Orders"
            Me.RadioButtonControl_OpenOrdersGLAccountLineOrders.Visible = False
            '
            'GroupBox1
            '
            Me.GroupBox1.BackColor = System.Drawing.SystemColors.Window
            Me.GroupBox1.Controls.Add(Me.RadioButtonControl_OpenOnly)
            Me.GroupBox1.Controls.Add(Me.RadioButtonControl_OpenandClosed)
            Me.GroupBox1.Location = New System.Drawing.Point(87, 40)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(170, 46)
            Me.GroupBox1.TabIndex = 55
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Visible = False
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
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.Label2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label2.Location = New System.Drawing.Point(11, 92)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(70, 20)
            Me.Label2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label2.TabIndex = 50
            Me.Label2.Text = "WIP Option:"
            Me.Label2.Visible = False
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
            Me.LabelForm_StartingPostPeriod.Text = "End Period:"
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
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.Label1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label1.Location = New System.Drawing.Point(11, 40)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(70, 20)
            Me.Label1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label1.TabIndex = 43
            Me.Label1.Text = "Order Option:"
            Me.Label1.Visible = False
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
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Size = New System.Drawing.Size(1017, 540)
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
            Me.DataGridViewSelectOffices_Offices.Size = New System.Drawing.Size(1009, 506)
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
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.TabControlForm_JDA)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Panel1.Location = New System.Drawing.Point(0, 68)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(1041, 576)
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
            'MonthEndProductionWIPInitialLoadingDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1041, 687)
            Me.Controls.Add(Me.Panel1)
            Me.Controls.Add(Me.PanelForm_Bottom)
            Me.Controls.Add(Me.PanelForm_TopSection)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MonthEndProductionWIPInitialLoadingDialog"
            Me.Text = "Month End Production WIP Initial Criteria"
            Me.PanelForm_TopSection.ResumeLayout(False)
            CType(Me.TabControlForm_JDA, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_JDA.ResumeLayout(False)
            Me.TabControlSelectClientsTab_SelectClients.ResumeLayout(False)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.ResumeLayout(False)
            CType(Me.DateTimePickerAgingDate, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox2.ResumeLayout(False)
            Me.GroupBox1.ResumeLayout(False)
            Me.TabControlPanelSelectOfficesTab_SelectOffices.ResumeLayout(False)
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
        Friend WithEvents TabControlSelectClientsTab_SelectClients As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents CDPChooserControlSelectClients_SelectClients As WinForm.Presentation.Controls.CDPChooserControl
        Friend WithEvents TabItemJDA_SelectClientsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelSelectOfficesTab_SelectOffices As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewSelectOffices_Offices As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RadioButtonSelectOffices_AllOffices As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSelectOffices_ChooseOffices As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents TabItemJDA_SelectOfficesTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents Panel1 As Windows.Forms.Panel
        Friend WithEvents PanelForm_Bottom As Windows.Forms.Panel
        Friend WithEvents Label1 As WinForm.Presentation.Controls.Label
        Friend WithEvents RadioButtonControl_OpenandClosed As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControl_OpenOnly As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents LabelForm_StartingPostPeriod As WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_EndPostPeriod As WinForm.Presentation.Controls.ComboBox
        Friend WithEvents Label2 As WinForm.Presentation.Controls.Label
        Friend WithEvents RadioButtonControl_ZeroBalanceOrders As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControl_OpenOrdersGLAccountLineOrders As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControl_OpenOrdersGLAccountOrders As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
        Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
        Friend WithEvents RadioButtonControl_Orders As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents ComboBoxTopSection_ReportSeries As WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelTopSection_Report As WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerAgingDate As WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents RadioButtonForm_Invoice As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonForm_InvoiceDueDate As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents LabelForm_AgingOption As WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_AgingDate As WinForm.Presentation.Controls.Label
    End Class

End Namespace