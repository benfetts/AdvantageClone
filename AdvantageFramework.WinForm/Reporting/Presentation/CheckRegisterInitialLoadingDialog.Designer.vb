Namespace Reporting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class CheckRegisterInitialLoadingDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CheckRegisterInitialLoadingDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.PanelForm_TopSection = New System.Windows.Forms.Panel()
            Me.LabelTopSection_Report = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxTopSection_Report = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.TabControlForm_JDA = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions = New DevComponents.DotNetBar.TabControlPanel()
            Me.GroupBox2 = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxIncludeInvoiceDetails = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.Label1 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelOptions_SelectBy = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.PanelOptions_Dates = New System.Windows.Forms.Panel()
            Me.RadioButtonDates_Standard = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonDates_PostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.PostPeriod_ToMonth = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.PostPeriod_FromMonth = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelOptions_PostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPostPeriod_To = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPostPeriod_From = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBox1 = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxVoidedChecks = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxOutstandingChecks = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxClearedChecks = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.GroupBoxControl_Cutoffs = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxComputerGeneratedChecks = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxManualChecks = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxVoidComments = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.ButtonInvoiceDate_2Year = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonInvoiceDate_1Year = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonInvoiceDate_MTD = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonInvoiceDate_YTD = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_To = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_From = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DateTimePickerForm_To = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerForm_From = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.TabItemJDA_VersionAndOptionsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelSelectVendorsTab_SelectVendor = New DevComponents.DotNetBar.TabControlPanel()
            Me.TabControlPanelSelectVendorsTab_SelectVendors = New DevComponents.DotNetBar.TabControlPanel()
            Me.CheckBoxSelectByPayToVendor = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.DataGridViewSelectVendors_Vendors = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonSelectVendors_AllVendors = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectVendors_ChooseVendors = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TabItemJDA_SelectVendorsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelSelectBanksTab_SelectBanks = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewSelectBanks_Banks = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonSelectBanks_AllBanks = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectBanks_ChooseBanks = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TabItemJDA_SelectBanksTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelSelectOfficesTab_SelectOffices = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewSelectOffices_Offices = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonSelectOffices_AllOffices = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectOffices_ChooseOffices = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TabItemJDA_SelectOfficesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlSelectClientsTab_SelectClients = New DevComponents.DotNetBar.TabControlPanel()
            Me.CDPChooserControlSelectClients_SelectClients = New AdvantageFramework.WinForm.Presentation.Controls.CDPChooserControl()
            Me.TabItemJDA_SelectClientsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.PanelForm_Bottom = New System.Windows.Forms.Panel()
            Me.PanelForm_TopSection.SuspendLayout()
            CType(Me.TabControlForm_JDA, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_JDA.SuspendLayout()
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.SuspendLayout()
            CType(Me.GroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox2.SuspendLayout()
            Me.PanelOptions_Dates.SuspendLayout()
            CType(Me.GroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox1.SuspendLayout()
            CType(Me.GroupBoxControl_Cutoffs, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxControl_Cutoffs.SuspendLayout()
            CType(Me.DateTimePickerForm_To, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerForm_From, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelSelectVendorsTab_SelectVendor.SuspendLayout()
            Me.TabControlPanelSelectVendorsTab_SelectVendors.SuspendLayout()
            Me.TabControlPanelSelectBanksTab_SelectBanks.SuspendLayout()
            Me.TabControlPanelSelectOfficesTab_SelectOffices.SuspendLayout()
            Me.TabControlSelectClientsTab_SelectClients.SuspendLayout()
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
            Me.TabControlForm_JDA.Controls.Add(Me.TabControlPanelSelectVendorsTab_SelectVendor)
            Me.TabControlForm_JDA.Controls.Add(Me.TabControlPanelSelectBanksTab_SelectBanks)
            Me.TabControlForm_JDA.Controls.Add(Me.TabControlPanelSelectOfficesTab_SelectOffices)
            Me.TabControlForm_JDA.Controls.Add(Me.TabControlSelectClientsTab_SelectClients)
            Me.TabControlForm_JDA.Location = New System.Drawing.Point(12, 3)
            Me.TabControlForm_JDA.Name = "TabControlForm_JDA"
            Me.TabControlForm_JDA.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_JDA.SelectedTabIndex = 0
            Me.TabControlForm_JDA.Size = New System.Drawing.Size(1017, 511)
            Me.TabControlForm_JDA.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_JDA.TabIndex = 37
            Me.TabControlForm_JDA.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_JDA.Tabs.Add(Me.TabItemJDA_VersionAndOptionsTab)
            Me.TabControlForm_JDA.Tabs.Add(Me.TabItemJDA_SelectBanksTab)
            Me.TabControlForm_JDA.Tabs.Add(Me.TabItemJDA_SelectOfficesTab)
            Me.TabControlForm_JDA.Tabs.Add(Me.TabItemJDA_SelectClientsTab)
            Me.TabControlForm_JDA.Tabs.Add(Me.TabItemJDA_SelectVendorsTab)
            '
            'TabControlPanelVersionAndOptionsTab_VersionAndOptions
            '
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.GroupBox2)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.Label1)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.LabelOptions_SelectBy)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.PanelOptions_Dates)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.PostPeriod_ToMonth)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.PostPeriod_FromMonth)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.LabelOptions_PostPeriod)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.LabelPostPeriod_To)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.LabelPostPeriod_From)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.GroupBox1)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.GroupBoxControl_Cutoffs)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.ButtonInvoiceDate_2Year)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.ButtonInvoiceDate_1Year)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.ButtonInvoiceDate_MTD)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.ButtonInvoiceDate_YTD)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.LabelForm_To)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.LabelForm_From)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.DateTimePickerForm_To)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.DateTimePickerForm_From)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Name = "TabControlPanelVersionAndOptionsTab_VersionAndOptions"
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Size = New System.Drawing.Size(1017, 484)
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
            Me.GroupBox2.Appearance.BackColor = System.Drawing.Color.Transparent
            Me.GroupBox2.Appearance.Options.UseBackColor = True
            Me.GroupBox2.Controls.Add(Me.CheckBoxIncludeInvoiceDetails)
            Me.GroupBox2.Location = New System.Drawing.Point(347, 257)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(327, 52)
            Me.GroupBox2.TabIndex = 52
            Me.GroupBox2.Text = "Invoice Details"
            Me.GroupBox2.Visible = False
            '
            'CheckBoxIncludeInvoiceDetails
            '
            Me.CheckBoxIncludeInvoiceDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxIncludeInvoiceDetails.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxIncludeInvoiceDetails.CheckValue = 0
            Me.CheckBoxIncludeInvoiceDetails.CheckValueChecked = 1
            Me.CheckBoxIncludeInvoiceDetails.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxIncludeInvoiceDetails.CheckValueUnchecked = 0
            Me.CheckBoxIncludeInvoiceDetails.ChildControls = Nothing
            Me.CheckBoxIncludeInvoiceDetails.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxIncludeInvoiceDetails.Location = New System.Drawing.Point(5, 24)
            Me.CheckBoxIncludeInvoiceDetails.Name = "CheckBoxIncludeInvoiceDetails"
            Me.CheckBoxIncludeInvoiceDetails.OldestSibling = Nothing
            Me.CheckBoxIncludeInvoiceDetails.SecurityEnabled = True
            Me.CheckBoxIncludeInvoiceDetails.SiblingControls = Nothing
            Me.CheckBoxIncludeInvoiceDetails.Size = New System.Drawing.Size(175, 20)
            Me.CheckBoxIncludeInvoiceDetails.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxIncludeInvoiceDetails.TabIndex = 47
            Me.CheckBoxIncludeInvoiceDetails.TabOnEnter = True
            Me.CheckBoxIncludeInvoiceDetails.Text = "Include Invoice Details"
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.Label1.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.Label1.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.Label1.BackgroundStyle.BorderBottomWidth = 1
            Me.Label1.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.Label1.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.Label1.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.Label1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label1.Location = New System.Drawing.Point(18, 82)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(323, 20)
            Me.Label1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label1.TabIndex = 61
            Me.Label1.Text = "Check Date Range"
            '
            'LabelOptions_SelectBy
            '
            Me.LabelOptions_SelectBy.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.LabelOptions_SelectBy.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelOptions_SelectBy.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelOptions_SelectBy.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelOptions_SelectBy.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelOptions_SelectBy.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelOptions_SelectBy.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelOptions_SelectBy.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelOptions_SelectBy.Location = New System.Drawing.Point(15, 13)
            Me.LabelOptions_SelectBy.Name = "LabelOptions_SelectBy"
            Me.LabelOptions_SelectBy.Size = New System.Drawing.Size(326, 20)
            Me.LabelOptions_SelectBy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOptions_SelectBy.TabIndex = 60
            Me.LabelOptions_SelectBy.Text = "Select By"
            '
            'PanelOptions_Dates
            '
            Me.PanelOptions_Dates.BackColor = System.Drawing.Color.Transparent
            Me.PanelOptions_Dates.Controls.Add(Me.RadioButtonDates_Standard)
            Me.PanelOptions_Dates.Controls.Add(Me.RadioButtonDates_PostPeriod)
            Me.PanelOptions_Dates.Location = New System.Drawing.Point(16, 39)
            Me.PanelOptions_Dates.Name = "PanelOptions_Dates"
            Me.PanelOptions_Dates.Size = New System.Drawing.Size(325, 35)
            Me.PanelOptions_Dates.TabIndex = 59
            '
            'RadioButtonDates_Standard
            '
            Me.RadioButtonDates_Standard.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.RadioButtonDates_Standard.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonDates_Standard.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonDates_Standard.Checked = True
            Me.RadioButtonDates_Standard.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonDates_Standard.CheckValue = "Y"
            Me.RadioButtonDates_Standard.Location = New System.Drawing.Point(6, 6)
            Me.RadioButtonDates_Standard.Name = "RadioButtonDates_Standard"
            Me.RadioButtonDates_Standard.SecurityEnabled = True
            Me.RadioButtonDates_Standard.Size = New System.Drawing.Size(96, 20)
            Me.RadioButtonDates_Standard.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonDates_Standard.TabIndex = 0
            Me.RadioButtonDates_Standard.TabOnEnter = True
            Me.RadioButtonDates_Standard.Text = "Check Date"
            '
            'RadioButtonDates_PostPeriod
            '
            Me.RadioButtonDates_PostPeriod.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.RadioButtonDates_PostPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonDates_PostPeriod.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonDates_PostPeriod.Location = New System.Drawing.Point(111, 6)
            Me.RadioButtonDates_PostPeriod.Name = "RadioButtonDates_PostPeriod"
            Me.RadioButtonDates_PostPeriod.SecurityEnabled = True
            Me.RadioButtonDates_PostPeriod.Size = New System.Drawing.Size(96, 20)
            Me.RadioButtonDates_PostPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonDates_PostPeriod.TabIndex = 1
            Me.RadioButtonDates_PostPeriod.TabOnEnter = True
            Me.RadioButtonDates_PostPeriod.TabStop = False
            Me.RadioButtonDates_PostPeriod.Text = "Post Period"
            '
            'PostPeriod_ToMonth
            '
            Me.PostPeriod_ToMonth.AddInactiveItemsOnSelectedValue = False
            Me.PostPeriod_ToMonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.PostPeriod_ToMonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.PostPeriod_ToMonth.AutoFindItemInDataSource = False
            Me.PostPeriod_ToMonth.AutoSelectSingleItemDatasource = False
            Me.PostPeriod_ToMonth.BookmarkingEnabled = False
            Me.PostPeriod_ToMonth.ClientCode = ""
            Me.PostPeriod_ToMonth.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Month
            Me.PostPeriod_ToMonth.DisableMouseWheel = False
            Me.PostPeriod_ToMonth.DisplayMember = "Value"
            Me.PostPeriod_ToMonth.DisplayName = ""
            Me.PostPeriod_ToMonth.DivisionCode = ""
            Me.PostPeriod_ToMonth.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.PostPeriod_ToMonth.Enabled = False
            Me.PostPeriod_ToMonth.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.PostPeriod_ToMonth.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.PostPeriod_ToMonth.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.PostPeriod_ToMonth.FocusHighlightEnabled = True
            Me.PostPeriod_ToMonth.FormattingEnabled = True
            Me.PostPeriod_ToMonth.ItemHeight = 14
            Me.PostPeriod_ToMonth.Location = New System.Drawing.Point(120, 222)
            Me.PostPeriod_ToMonth.Name = "PostPeriod_ToMonth"
            Me.PostPeriod_ToMonth.ReadOnly = False
            Me.PostPeriod_ToMonth.SecurityEnabled = True
            Me.PostPeriod_ToMonth.Size = New System.Drawing.Size(139, 20)
            Me.PostPeriod_ToMonth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.PostPeriod_ToMonth.TabIndex = 57
            Me.PostPeriod_ToMonth.TabOnEnter = True
            Me.PostPeriod_ToMonth.ValueMember = "Key"
            Me.PostPeriod_ToMonth.WatermarkText = "Select Period"
            '
            'PostPeriod_FromMonth
            '
            Me.PostPeriod_FromMonth.AddInactiveItemsOnSelectedValue = False
            Me.PostPeriod_FromMonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.PostPeriod_FromMonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.PostPeriod_FromMonth.AutoFindItemInDataSource = False
            Me.PostPeriod_FromMonth.AutoSelectSingleItemDatasource = False
            Me.PostPeriod_FromMonth.BookmarkingEnabled = False
            Me.PostPeriod_FromMonth.ClientCode = ""
            Me.PostPeriod_FromMonth.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Month
            Me.PostPeriod_FromMonth.DisableMouseWheel = False
            Me.PostPeriod_FromMonth.DisplayMember = "Value"
            Me.PostPeriod_FromMonth.DisplayName = ""
            Me.PostPeriod_FromMonth.DivisionCode = ""
            Me.PostPeriod_FromMonth.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.PostPeriod_FromMonth.Enabled = False
            Me.PostPeriod_FromMonth.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.PostPeriod_FromMonth.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.PostPeriod_FromMonth.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.PostPeriod_FromMonth.FocusHighlightEnabled = True
            Me.PostPeriod_FromMonth.FormattingEnabled = True
            Me.PostPeriod_FromMonth.ItemHeight = 14
            Me.PostPeriod_FromMonth.Location = New System.Drawing.Point(120, 196)
            Me.PostPeriod_FromMonth.Name = "PostPeriod_FromMonth"
            Me.PostPeriod_FromMonth.ReadOnly = False
            Me.PostPeriod_FromMonth.SecurityEnabled = True
            Me.PostPeriod_FromMonth.Size = New System.Drawing.Size(139, 20)
            Me.PostPeriod_FromMonth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.PostPeriod_FromMonth.TabIndex = 54
            Me.PostPeriod_FromMonth.TabOnEnter = True
            Me.PostPeriod_FromMonth.ValueMember = "Key"
            Me.PostPeriod_FromMonth.WatermarkText = "Select Period"
            '
            'LabelOptions_PostPeriod
            '
            Me.LabelOptions_PostPeriod.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.LabelOptions_PostPeriod.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelOptions_PostPeriod.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelOptions_PostPeriod.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelOptions_PostPeriod.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelOptions_PostPeriod.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelOptions_PostPeriod.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelOptions_PostPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelOptions_PostPeriod.Enabled = False
            Me.LabelOptions_PostPeriod.Location = New System.Drawing.Point(18, 168)
            Me.LabelOptions_PostPeriod.Name = "LabelOptions_PostPeriod"
            Me.LabelOptions_PostPeriod.Size = New System.Drawing.Size(323, 20)
            Me.LabelOptions_PostPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOptions_PostPeriod.TabIndex = 52
            Me.LabelOptions_PostPeriod.Text = "Post Period Range"
            '
            'LabelPostPeriod_To
            '
            Me.LabelPostPeriod_To.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.LabelPostPeriod_To.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPostPeriod_To.Enabled = False
            Me.LabelPostPeriod_To.Location = New System.Drawing.Point(18, 220)
            Me.LabelPostPeriod_To.Name = "LabelPostPeriod_To"
            Me.LabelPostPeriod_To.Size = New System.Drawing.Size(96, 20)
            Me.LabelPostPeriod_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPostPeriod_To.TabIndex = 56
            Me.LabelPostPeriod_To.Text = "To Post Period:"
            '
            'LabelPostPeriod_From
            '
            Me.LabelPostPeriod_From.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.LabelPostPeriod_From.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPostPeriod_From.Enabled = False
            Me.LabelPostPeriod_From.Location = New System.Drawing.Point(18, 194)
            Me.LabelPostPeriod_From.Name = "LabelPostPeriod_From"
            Me.LabelPostPeriod_From.Size = New System.Drawing.Size(96, 20)
            Me.LabelPostPeriod_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPostPeriod_From.TabIndex = 53
            Me.LabelPostPeriod_From.Text = "From Post Period:"
            '
            'GroupBox1
            '
            Me.GroupBox1.Appearance.BackColor = System.Drawing.Color.Transparent
            Me.GroupBox1.Appearance.Options.UseBackColor = True
            Me.GroupBox1.Controls.Add(Me.CheckBoxVoidedChecks)
            Me.GroupBox1.Controls.Add(Me.CheckBoxOutstandingChecks)
            Me.GroupBox1.Controls.Add(Me.CheckBoxClearedChecks)
            Me.GroupBox1.Location = New System.Drawing.Point(14, 365)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(327, 102)
            Me.GroupBox1.TabIndex = 51
            Me.GroupBox1.Text = "Limit To"
            '
            'CheckBoxVoidedChecks
            '
            Me.CheckBoxVoidedChecks.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxVoidedChecks.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxVoidedChecks.CheckValue = 0
            Me.CheckBoxVoidedChecks.CheckValueChecked = 1
            Me.CheckBoxVoidedChecks.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxVoidedChecks.CheckValueUnchecked = 0
            Me.CheckBoxVoidedChecks.ChildControls = Nothing
            Me.CheckBoxVoidedChecks.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxVoidedChecks.Location = New System.Drawing.Point(5, 24)
            Me.CheckBoxVoidedChecks.Name = "CheckBoxVoidedChecks"
            Me.CheckBoxVoidedChecks.OldestSibling = Nothing
            Me.CheckBoxVoidedChecks.SecurityEnabled = True
            Me.CheckBoxVoidedChecks.SiblingControls = Nothing
            Me.CheckBoxVoidedChecks.Size = New System.Drawing.Size(175, 20)
            Me.CheckBoxVoidedChecks.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxVoidedChecks.TabIndex = 47
            Me.CheckBoxVoidedChecks.TabOnEnter = True
            Me.CheckBoxVoidedChecks.Text = "Voided Checks"
            '
            'CheckBoxOutstandingChecks
            '
            Me.CheckBoxOutstandingChecks.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxOutstandingChecks.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxOutstandingChecks.CheckValue = 0
            Me.CheckBoxOutstandingChecks.CheckValueChecked = 1
            Me.CheckBoxOutstandingChecks.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxOutstandingChecks.CheckValueUnchecked = 0
            Me.CheckBoxOutstandingChecks.ChildControls = Nothing
            Me.CheckBoxOutstandingChecks.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxOutstandingChecks.Location = New System.Drawing.Point(5, 50)
            Me.CheckBoxOutstandingChecks.Name = "CheckBoxOutstandingChecks"
            Me.CheckBoxOutstandingChecks.OldestSibling = Nothing
            Me.CheckBoxOutstandingChecks.SecurityEnabled = True
            Me.CheckBoxOutstandingChecks.SiblingControls = Nothing
            Me.CheckBoxOutstandingChecks.Size = New System.Drawing.Size(261, 20)
            Me.CheckBoxOutstandingChecks.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxOutstandingChecks.TabIndex = 48
            Me.CheckBoxOutstandingChecks.TabOnEnter = True
            Me.CheckBoxOutstandingChecks.Text = "Outstanding Checks"
            '
            'CheckBoxClearedChecks
            '
            Me.CheckBoxClearedChecks.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxClearedChecks.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxClearedChecks.CheckValue = 0
            Me.CheckBoxClearedChecks.CheckValueChecked = 1
            Me.CheckBoxClearedChecks.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxClearedChecks.CheckValueUnchecked = 0
            Me.CheckBoxClearedChecks.ChildControls = Nothing
            Me.CheckBoxClearedChecks.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxClearedChecks.Location = New System.Drawing.Point(5, 76)
            Me.CheckBoxClearedChecks.Name = "CheckBoxClearedChecks"
            Me.CheckBoxClearedChecks.OldestSibling = Nothing
            Me.CheckBoxClearedChecks.SecurityEnabled = True
            Me.CheckBoxClearedChecks.SiblingControls = Nothing
            Me.CheckBoxClearedChecks.Size = New System.Drawing.Size(228, 20)
            Me.CheckBoxClearedChecks.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxClearedChecks.TabIndex = 49
            Me.CheckBoxClearedChecks.TabOnEnter = True
            Me.CheckBoxClearedChecks.Text = "Cleared Checks"
            '
            'GroupBoxControl_Cutoffs
            '
            Me.GroupBoxControl_Cutoffs.Appearance.BackColor = System.Drawing.Color.Transparent
            Me.GroupBoxControl_Cutoffs.Appearance.Options.UseBackColor = True
            Me.GroupBoxControl_Cutoffs.Controls.Add(Me.CheckBoxComputerGeneratedChecks)
            Me.GroupBoxControl_Cutoffs.Controls.Add(Me.CheckBoxManualChecks)
            Me.GroupBoxControl_Cutoffs.Controls.Add(Me.CheckBoxVoidComments)
            Me.GroupBoxControl_Cutoffs.Location = New System.Drawing.Point(14, 257)
            Me.GroupBoxControl_Cutoffs.Name = "GroupBoxControl_Cutoffs"
            Me.GroupBoxControl_Cutoffs.Size = New System.Drawing.Size(327, 102)
            Me.GroupBoxControl_Cutoffs.TabIndex = 50
            Me.GroupBoxControl_Cutoffs.Text = "Include"
            '
            'CheckBoxComputerGeneratedChecks
            '
            Me.CheckBoxComputerGeneratedChecks.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxComputerGeneratedChecks.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxComputerGeneratedChecks.CheckValue = 0
            Me.CheckBoxComputerGeneratedChecks.CheckValueChecked = 1
            Me.CheckBoxComputerGeneratedChecks.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxComputerGeneratedChecks.CheckValueUnchecked = 0
            Me.CheckBoxComputerGeneratedChecks.ChildControls = Nothing
            Me.CheckBoxComputerGeneratedChecks.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxComputerGeneratedChecks.Location = New System.Drawing.Point(5, 24)
            Me.CheckBoxComputerGeneratedChecks.Name = "CheckBoxComputerGeneratedChecks"
            Me.CheckBoxComputerGeneratedChecks.OldestSibling = Nothing
            Me.CheckBoxComputerGeneratedChecks.SecurityEnabled = True
            Me.CheckBoxComputerGeneratedChecks.SiblingControls = Nothing
            Me.CheckBoxComputerGeneratedChecks.Size = New System.Drawing.Size(271, 20)
            Me.CheckBoxComputerGeneratedChecks.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxComputerGeneratedChecks.TabIndex = 43
            Me.CheckBoxComputerGeneratedChecks.TabOnEnter = True
            Me.CheckBoxComputerGeneratedChecks.Text = "Computer Generated Checks"
            '
            'CheckBoxManualChecks
            '
            Me.CheckBoxManualChecks.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxManualChecks.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxManualChecks.CheckValue = 0
            Me.CheckBoxManualChecks.CheckValueChecked = 1
            Me.CheckBoxManualChecks.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxManualChecks.CheckValueUnchecked = 0
            Me.CheckBoxManualChecks.ChildControls = Nothing
            Me.CheckBoxManualChecks.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxManualChecks.Location = New System.Drawing.Point(5, 50)
            Me.CheckBoxManualChecks.Name = "CheckBoxManualChecks"
            Me.CheckBoxManualChecks.OldestSibling = Nothing
            Me.CheckBoxManualChecks.SecurityEnabled = True
            Me.CheckBoxManualChecks.SiblingControls = Nothing
            Me.CheckBoxManualChecks.Size = New System.Drawing.Size(259, 20)
            Me.CheckBoxManualChecks.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxManualChecks.TabIndex = 44
            Me.CheckBoxManualChecks.TabOnEnter = True
            Me.CheckBoxManualChecks.Text = "Manual Checks"
            '
            'CheckBoxVoidComments
            '
            Me.CheckBoxVoidComments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxVoidComments.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxVoidComments.CheckValue = 0
            Me.CheckBoxVoidComments.CheckValueChecked = 1
            Me.CheckBoxVoidComments.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxVoidComments.CheckValueUnchecked = 0
            Me.CheckBoxVoidComments.ChildControls = Nothing
            Me.CheckBoxVoidComments.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxVoidComments.Location = New System.Drawing.Point(5, 76)
            Me.CheckBoxVoidComments.Name = "CheckBoxVoidComments"
            Me.CheckBoxVoidComments.OldestSibling = Nothing
            Me.CheckBoxVoidComments.SecurityEnabled = True
            Me.CheckBoxVoidComments.SiblingControls = Nothing
            Me.CheckBoxVoidComments.Size = New System.Drawing.Size(253, 20)
            Me.CheckBoxVoidComments.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxVoidComments.TabIndex = 45
            Me.CheckBoxVoidComments.TabOnEnter = True
            Me.CheckBoxVoidComments.Text = "Void Comments"
            '
            'ButtonInvoiceDate_2Year
            '
            Me.ButtonInvoiceDate_2Year.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonInvoiceDate_2Year.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonInvoiceDate_2Year.Location = New System.Drawing.Point(281, 137)
            Me.ButtonInvoiceDate_2Year.Name = "ButtonInvoiceDate_2Year"
            Me.ButtonInvoiceDate_2Year.SecurityEnabled = True
            Me.ButtonInvoiceDate_2Year.Size = New System.Drawing.Size(60, 20)
            Me.ButtonInvoiceDate_2Year.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonInvoiceDate_2Year.TabIndex = 41
            Me.ButtonInvoiceDate_2Year.Text = "2 Years"
            '
            'ButtonInvoiceDate_1Year
            '
            Me.ButtonInvoiceDate_1Year.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonInvoiceDate_1Year.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonInvoiceDate_1Year.Location = New System.Drawing.Point(281, 111)
            Me.ButtonInvoiceDate_1Year.Name = "ButtonInvoiceDate_1Year"
            Me.ButtonInvoiceDate_1Year.SecurityEnabled = True
            Me.ButtonInvoiceDate_1Year.Size = New System.Drawing.Size(60, 20)
            Me.ButtonInvoiceDate_1Year.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonInvoiceDate_1Year.TabIndex = 39
            Me.ButtonInvoiceDate_1Year.Text = "1 Year"
            '
            'ButtonInvoiceDate_MTD
            '
            Me.ButtonInvoiceDate_MTD.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonInvoiceDate_MTD.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonInvoiceDate_MTD.Location = New System.Drawing.Point(228, 137)
            Me.ButtonInvoiceDate_MTD.Name = "ButtonInvoiceDate_MTD"
            Me.ButtonInvoiceDate_MTD.SecurityEnabled = True
            Me.ButtonInvoiceDate_MTD.Size = New System.Drawing.Size(47, 20)
            Me.ButtonInvoiceDate_MTD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonInvoiceDate_MTD.TabIndex = 40
            Me.ButtonInvoiceDate_MTD.Text = "MTD"
            '
            'ButtonInvoiceDate_YTD
            '
            Me.ButtonInvoiceDate_YTD.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonInvoiceDate_YTD.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonInvoiceDate_YTD.Location = New System.Drawing.Point(228, 111)
            Me.ButtonInvoiceDate_YTD.Name = "ButtonInvoiceDate_YTD"
            Me.ButtonInvoiceDate_YTD.SecurityEnabled = True
            Me.ButtonInvoiceDate_YTD.Size = New System.Drawing.Size(47, 20)
            Me.ButtonInvoiceDate_YTD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonInvoiceDate_YTD.TabIndex = 38
            Me.ButtonInvoiceDate_YTD.Text = "YTD"
            '
            'LabelForm_To
            '
            Me.LabelForm_To.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.LabelForm_To.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_To.Location = New System.Drawing.Point(16, 135)
            Me.LabelForm_To.Name = "LabelForm_To"
            Me.LabelForm_To.Size = New System.Drawing.Size(98, 20)
            Me.LabelForm_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_To.TabIndex = 35
            Me.LabelForm_To.Text = "Invoice To Date:"
            '
            'LabelForm_From
            '
            Me.LabelForm_From.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.LabelForm_From.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_From.Location = New System.Drawing.Point(16, 109)
            Me.LabelForm_From.Name = "LabelForm_From"
            Me.LabelForm_From.Size = New System.Drawing.Size(98, 20)
            Me.LabelForm_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_From.TabIndex = 33
            Me.LabelForm_From.Text = "Invoice From Date:"
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
            Me.DateTimePickerForm_To.Location = New System.Drawing.Point(120, 137)
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
            Me.DateTimePickerForm_To.Size = New System.Drawing.Size(103, 20)
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
            Me.DateTimePickerForm_From.Location = New System.Drawing.Point(120, 111)
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
            Me.DateTimePickerForm_From.Size = New System.Drawing.Size(103, 20)
            Me.DateTimePickerForm_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_From.TabIndex = 34
            Me.DateTimePickerForm_From.TabOnEnter = True
            Me.DateTimePickerForm_From.Value = New Date(1850, 1, 1, 0, 0, 0, 0)
            '
            'TabItemJDA_VersionAndOptionsTab
            '
            Me.TabItemJDA_VersionAndOptionsTab.AttachedControl = Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions
            Me.TabItemJDA_VersionAndOptionsTab.Name = "TabItemJDA_VersionAndOptionsTab"
            Me.TabItemJDA_VersionAndOptionsTab.Text = "Report Options"
            '
            'TabControlPanelSelectVendorsTab_SelectVendor
            '
            Me.TabControlPanelSelectVendorsTab_SelectVendor.Controls.Add(Me.TabControlPanelSelectVendorsTab_SelectVendors)
            Me.TabControlPanelSelectVendorsTab_SelectVendor.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSelectVendorsTab_SelectVendor.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSelectVendorsTab_SelectVendor.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelSelectVendorsTab_SelectVendor.Name = "TabControlPanelSelectVendorsTab_SelectVendor"
            Me.TabControlPanelSelectVendorsTab_SelectVendor.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSelectVendorsTab_SelectVendor.Size = New System.Drawing.Size(1017, 484)
            Me.TabControlPanelSelectVendorsTab_SelectVendor.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelSelectVendorsTab_SelectVendor.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSelectVendorsTab_SelectVendor.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSelectVendorsTab_SelectVendor.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSelectVendorsTab_SelectVendor.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSelectVendorsTab_SelectVendor.Style.GradientAngle = 90
            Me.TabControlPanelSelectVendorsTab_SelectVendor.TabIndex = 17
            Me.TabControlPanelSelectVendorsTab_SelectVendor.TabItem = Me.TabItemJDA_SelectVendorsTab
            '
            'TabControlPanelSelectVendorsTab_SelectVendors
            '
            Me.TabControlPanelSelectVendorsTab_SelectVendors.Controls.Add(Me.CheckBoxSelectByPayToVendor)
            Me.TabControlPanelSelectVendorsTab_SelectVendors.Controls.Add(Me.DataGridViewSelectVendors_Vendors)
            Me.TabControlPanelSelectVendorsTab_SelectVendors.Controls.Add(Me.RadioButtonSelectVendors_AllVendors)
            Me.TabControlPanelSelectVendorsTab_SelectVendors.Controls.Add(Me.RadioButtonSelectVendors_ChooseVendors)
            Me.TabControlPanelSelectVendorsTab_SelectVendors.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSelectVendorsTab_SelectVendors.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSelectVendorsTab_SelectVendors.Location = New System.Drawing.Point(1, 1)
            Me.TabControlPanelSelectVendorsTab_SelectVendors.Name = "TabControlPanelSelectVendorsTab_SelectVendors"
            Me.TabControlPanelSelectVendorsTab_SelectVendors.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSelectVendorsTab_SelectVendors.Size = New System.Drawing.Size(1015, 482)
            Me.TabControlPanelSelectVendorsTab_SelectVendors.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelSelectVendorsTab_SelectVendors.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSelectVendorsTab_SelectVendors.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSelectVendorsTab_SelectVendors.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSelectVendorsTab_SelectVendors.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSelectVendorsTab_SelectVendors.Style.GradientAngle = 90
            Me.TabControlPanelSelectVendorsTab_SelectVendors.TabIndex = 4
            '
            'CheckBoxSelectByPayToVendor
            '
            Me.CheckBoxSelectByPayToVendor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxSelectByPayToVendor.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.CheckBoxSelectByPayToVendor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxSelectByPayToVendor.CheckValue = 0
            Me.CheckBoxSelectByPayToVendor.CheckValueChecked = 1
            Me.CheckBoxSelectByPayToVendor.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxSelectByPayToVendor.CheckValueUnchecked = 0
            Me.CheckBoxSelectByPayToVendor.ChildControls = Nothing
            Me.CheckBoxSelectByPayToVendor.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxSelectByPayToVendor.Location = New System.Drawing.Point(326, 4)
            Me.CheckBoxSelectByPayToVendor.Name = "CheckBoxSelectByPayToVendor"
            Me.CheckBoxSelectByPayToVendor.OldestSibling = Nothing
            Me.CheckBoxSelectByPayToVendor.SecurityEnabled = True
            Me.CheckBoxSelectByPayToVendor.SiblingControls = Nothing
            Me.CheckBoxSelectByPayToVendor.Size = New System.Drawing.Size(140, 20)
            Me.CheckBoxSelectByPayToVendor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxSelectByPayToVendor.TabIndex = 46
            Me.CheckBoxSelectByPayToVendor.TabOnEnter = True
            Me.CheckBoxSelectByPayToVendor.Text = "Select by Pay To Vendor"
            '
            'DataGridViewSelectVendors_Vendors
            '
            Me.DataGridViewSelectVendors_Vendors.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewSelectVendors_Vendors.AllowDragAndDrop = False
            Me.DataGridViewSelectVendors_Vendors.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewSelectVendors_Vendors.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSelectVendors_Vendors.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewSelectVendors_Vendors.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSelectVendors_Vendors.AutoFilterLookupColumns = False
            Me.DataGridViewSelectVendors_Vendors.AutoloadRepositoryDatasource = True
            Me.DataGridViewSelectVendors_Vendors.AutoUpdateViewCaption = True
            Me.DataGridViewSelectVendors_Vendors.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewSelectVendors_Vendors.DataSource = Nothing
            Me.DataGridViewSelectVendors_Vendors.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewSelectVendors_Vendors.Enabled = False
            Me.DataGridViewSelectVendors_Vendors.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSelectVendors_Vendors.ItemDescription = "Vendor(s)"
            Me.DataGridViewSelectVendors_Vendors.Location = New System.Drawing.Point(4, 30)
            Me.DataGridViewSelectVendors_Vendors.MultiSelect = True
            Me.DataGridViewSelectVendors_Vendors.Name = "DataGridViewSelectVendors_Vendors"
            Me.DataGridViewSelectVendors_Vendors.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSelectVendors_Vendors.RunStandardValidation = True
            Me.DataGridViewSelectVendors_Vendors.ShowColumnMenuOnRightClick = False
            Me.DataGridViewSelectVendors_Vendors.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSelectVendors_Vendors.Size = New System.Drawing.Size(1007, 448)
            Me.DataGridViewSelectVendors_Vendors.TabIndex = 2
            Me.DataGridViewSelectVendors_Vendors.UseEmbeddedNavigator = False
            Me.DataGridViewSelectVendors_Vendors.ViewCaptionHeight = -1
            '
            'RadioButtonSelectVendors_AllVendors
            '
            Me.RadioButtonSelectVendors_AllVendors.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectVendors_AllVendors.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectVendors_AllVendors.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectVendors_AllVendors.Checked = True
            Me.RadioButtonSelectVendors_AllVendors.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonSelectVendors_AllVendors.CheckValue = "Y"
            Me.RadioButtonSelectVendors_AllVendors.Location = New System.Drawing.Point(4, 4)
            Me.RadioButtonSelectVendors_AllVendors.Name = "RadioButtonSelectVendors_AllVendors"
            Me.RadioButtonSelectVendors_AllVendors.SecurityEnabled = True
            Me.RadioButtonSelectVendors_AllVendors.Size = New System.Drawing.Size(89, 20)
            Me.RadioButtonSelectVendors_AllVendors.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectVendors_AllVendors.TabIndex = 0
            Me.RadioButtonSelectVendors_AllVendors.TabOnEnter = True
            Me.RadioButtonSelectVendors_AllVendors.Text = "All Vendors"
            '
            'RadioButtonSelectVendors_ChooseVendors
            '
            Me.RadioButtonSelectVendors_ChooseVendors.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectVendors_ChooseVendors.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectVendors_ChooseVendors.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectVendors_ChooseVendors.Location = New System.Drawing.Point(99, 4)
            Me.RadioButtonSelectVendors_ChooseVendors.Name = "RadioButtonSelectVendors_ChooseVendors"
            Me.RadioButtonSelectVendors_ChooseVendors.SecurityEnabled = True
            Me.RadioButtonSelectVendors_ChooseVendors.Size = New System.Drawing.Size(125, 20)
            Me.RadioButtonSelectVendors_ChooseVendors.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectVendors_ChooseVendors.TabIndex = 1
            Me.RadioButtonSelectVendors_ChooseVendors.TabOnEnter = True
            Me.RadioButtonSelectVendors_ChooseVendors.TabStop = False
            Me.RadioButtonSelectVendors_ChooseVendors.Text = "Choose Vendors"
            '
            'TabItemJDA_SelectVendorsTab
            '
            Me.TabItemJDA_SelectVendorsTab.AttachedControl = Me.TabControlPanelSelectVendorsTab_SelectVendor
            Me.TabItemJDA_SelectVendorsTab.Name = "TabItemJDA_SelectVendorsTab"
            Me.TabItemJDA_SelectVendorsTab.Text = "Select Vendors"
            '
            'TabControlPanelSelectBanksTab_SelectBanks
            '
            Me.TabControlPanelSelectBanksTab_SelectBanks.Controls.Add(Me.DataGridViewSelectBanks_Banks)
            Me.TabControlPanelSelectBanksTab_SelectBanks.Controls.Add(Me.RadioButtonSelectBanks_AllBanks)
            Me.TabControlPanelSelectBanksTab_SelectBanks.Controls.Add(Me.RadioButtonSelectBanks_ChooseBanks)
            Me.TabControlPanelSelectBanksTab_SelectBanks.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSelectBanksTab_SelectBanks.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSelectBanksTab_SelectBanks.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelSelectBanksTab_SelectBanks.Name = "TabControlPanelSelectBanksTab_SelectBanks"
            Me.TabControlPanelSelectBanksTab_SelectBanks.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSelectBanksTab_SelectBanks.Size = New System.Drawing.Size(1017, 484)
            Me.TabControlPanelSelectBanksTab_SelectBanks.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelSelectBanksTab_SelectBanks.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSelectBanksTab_SelectBanks.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSelectBanksTab_SelectBanks.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSelectBanksTab_SelectBanks.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSelectBanksTab_SelectBanks.Style.GradientAngle = 90
            Me.TabControlPanelSelectBanksTab_SelectBanks.TabIndex = 0
            Me.TabControlPanelSelectBanksTab_SelectBanks.TabItem = Me.TabItemJDA_SelectBanksTab
            '
            'DataGridViewSelectBanks_Banks
            '
            Me.DataGridViewSelectBanks_Banks.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewSelectBanks_Banks.AllowDragAndDrop = False
            Me.DataGridViewSelectBanks_Banks.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewSelectBanks_Banks.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSelectBanks_Banks.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewSelectBanks_Banks.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSelectBanks_Banks.AutoFilterLookupColumns = False
            Me.DataGridViewSelectBanks_Banks.AutoloadRepositoryDatasource = True
            Me.DataGridViewSelectBanks_Banks.AutoUpdateViewCaption = True
            Me.DataGridViewSelectBanks_Banks.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewSelectBanks_Banks.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewSelectBanks_Banks.Enabled = False
            Me.DataGridViewSelectBanks_Banks.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSelectBanks_Banks.ItemDescription = "Bank(s)"
            Me.DataGridViewSelectBanks_Banks.Location = New System.Drawing.Point(3, 30)
            Me.DataGridViewSelectBanks_Banks.MultiSelect = False
            Me.DataGridViewSelectBanks_Banks.Name = "DataGridViewSelectBanks_Banks"
            Me.DataGridViewSelectBanks_Banks.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSelectBanks_Banks.RunStandardValidation = True
            Me.DataGridViewSelectBanks_Banks.ShowColumnMenuOnRightClick = False
            Me.DataGridViewSelectBanks_Banks.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSelectBanks_Banks.Size = New System.Drawing.Size(1009, 450)
            Me.DataGridViewSelectBanks_Banks.TabIndex = 2
            Me.DataGridViewSelectBanks_Banks.UseEmbeddedNavigator = False
            Me.DataGridViewSelectBanks_Banks.ViewCaptionHeight = -1
            '
            'RadioButtonSelectBanks_AllBanks
            '
            Me.RadioButtonSelectBanks_AllBanks.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectBanks_AllBanks.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectBanks_AllBanks.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectBanks_AllBanks.Checked = True
            Me.RadioButtonSelectBanks_AllBanks.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonSelectBanks_AllBanks.CheckValue = "Y"
            Me.RadioButtonSelectBanks_AllBanks.Location = New System.Drawing.Point(4, 4)
            Me.RadioButtonSelectBanks_AllBanks.Name = "RadioButtonSelectBanks_AllBanks"
            Me.RadioButtonSelectBanks_AllBanks.SecurityEnabled = True
            Me.RadioButtonSelectBanks_AllBanks.Size = New System.Drawing.Size(77, 20)
            Me.RadioButtonSelectBanks_AllBanks.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectBanks_AllBanks.TabIndex = 0
            Me.RadioButtonSelectBanks_AllBanks.TabOnEnter = True
            Me.RadioButtonSelectBanks_AllBanks.Text = "All Banks"
            '
            'RadioButtonSelectBanks_ChooseBanks
            '
            Me.RadioButtonSelectBanks_ChooseBanks.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectBanks_ChooseBanks.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectBanks_ChooseBanks.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectBanks_ChooseBanks.Location = New System.Drawing.Point(87, 4)
            Me.RadioButtonSelectBanks_ChooseBanks.Name = "RadioButtonSelectBanks_ChooseBanks"
            Me.RadioButtonSelectBanks_ChooseBanks.SecurityEnabled = True
            Me.RadioButtonSelectBanks_ChooseBanks.Size = New System.Drawing.Size(138, 20)
            Me.RadioButtonSelectBanks_ChooseBanks.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectBanks_ChooseBanks.TabIndex = 1
            Me.RadioButtonSelectBanks_ChooseBanks.TabOnEnter = True
            Me.RadioButtonSelectBanks_ChooseBanks.TabStop = False
            Me.RadioButtonSelectBanks_ChooseBanks.Text = "Choose Banks"
            '
            'TabItemJDA_SelectBanksTab
            '
            Me.TabItemJDA_SelectBanksTab.AttachedControl = Me.TabControlPanelSelectBanksTab_SelectBanks
            Me.TabItemJDA_SelectBanksTab.Name = "TabItemJDA_SelectBanksTab"
            Me.TabItemJDA_SelectBanksTab.Text = "Select Banks"
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
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Size = New System.Drawing.Size(1017, 484)
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
            Me.DataGridViewSelectOffices_Offices.Size = New System.Drawing.Size(1009, 450)
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
            Me.TabItemJDA_SelectOfficesTab.Visible = False
            '
            'TabControlSelectClientsTab_SelectClients
            '
            Me.TabControlSelectClientsTab_SelectClients.Controls.Add(Me.CDPChooserControlSelectClients_SelectClients)
            Me.TabControlSelectClientsTab_SelectClients.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlSelectClientsTab_SelectClients.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlSelectClientsTab_SelectClients.Location = New System.Drawing.Point(0, 27)
            Me.TabControlSelectClientsTab_SelectClients.Name = "TabControlSelectClientsTab_SelectClients"
            Me.TabControlSelectClientsTab_SelectClients.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlSelectClientsTab_SelectClients.Size = New System.Drawing.Size(1017, 484)
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
            Me.CDPChooserControlSelectClients_SelectClients.Size = New System.Drawing.Size(1009, 476)
            Me.CDPChooserControlSelectClients_SelectClients.TabIndex = 1
            '
            'TabItemJDA_SelectClientsTab
            '
            Me.TabItemJDA_SelectClientsTab.AttachedControl = Me.TabControlSelectClientsTab_SelectClients
            Me.TabItemJDA_SelectClientsTab.Name = "TabItemJDA_SelectClientsTab"
            Me.TabItemJDA_SelectClientsTab.Text = "Select Clients"
            Me.TabItemJDA_SelectClientsTab.Visible = False
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.TabControlForm_JDA)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Panel1.Location = New System.Drawing.Point(0, 37)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(1041, 520)
            Me.Panel1.TabIndex = 12
            '
            'PanelForm_Bottom
            '
            Me.PanelForm_Bottom.Controls.Add(Me.ButtonForm_OK)
            Me.PanelForm_Bottom.Controls.Add(Me.ButtonForm_Cancel)
            Me.PanelForm_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.PanelForm_Bottom.Location = New System.Drawing.Point(0, 557)
            Me.PanelForm_Bottom.Name = "PanelForm_Bottom"
            Me.PanelForm_Bottom.Size = New System.Drawing.Size(1041, 43)
            Me.PanelForm_Bottom.TabIndex = 13
            '
            'CheckRegisterInitialLoadingDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1041, 600)
            Me.Controls.Add(Me.Panel1)
            Me.Controls.Add(Me.PanelForm_Bottom)
            Me.Controls.Add(Me.PanelForm_TopSection)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "CheckRegisterInitialLoadingDialog"
            Me.Text = "Check Register Initial Criteria"
            Me.PanelForm_TopSection.ResumeLayout(False)
            CType(Me.TabControlForm_JDA, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_JDA.ResumeLayout(False)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.ResumeLayout(False)
            CType(Me.GroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox2.ResumeLayout(False)
            Me.PanelOptions_Dates.ResumeLayout(False)
            CType(Me.GroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox1.ResumeLayout(False)
            CType(Me.GroupBoxControl_Cutoffs, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxControl_Cutoffs.ResumeLayout(False)
            CType(Me.DateTimePickerForm_To, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerForm_From, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelSelectVendorsTab_SelectVendor.ResumeLayout(False)
            Me.TabControlPanelSelectVendorsTab_SelectVendors.ResumeLayout(False)
            Me.TabControlPanelSelectBanksTab_SelectBanks.ResumeLayout(False)
            Me.TabControlPanelSelectOfficesTab_SelectOffices.ResumeLayout(False)
            Me.TabControlSelectClientsTab_SelectClients.ResumeLayout(False)
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
        Friend WithEvents TabItemJDA_VersionAndOptionsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlSelectClientsTab_SelectClients As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents CDPChooserControlSelectClients_SelectClients As WinForm.Presentation.Controls.CDPChooserControl
        Friend WithEvents TabItemJDA_SelectClientsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelSelectOfficesTab_SelectOffices As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabControlPanelSelectBanksTab_SelectBanks As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewSelectOffices_Offices As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RadioButtonSelectOffices_AllOffices As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSelectOffices_ChooseOffices As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents DataGridViewSelectBanks_Banks As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RadioButtonSelectBanks_AllBanks As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSelectBanks_ChooseBanks As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents TabItemJDA_SelectOfficesTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabItemJDA_SelectBanksTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents Panel1 As Windows.Forms.Panel
        Friend WithEvents ButtonInvoiceDate_2Year As WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonInvoiceDate_1Year As WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonInvoiceDate_MTD As WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonInvoiceDate_YTD As WinForm.Presentation.Controls.Button
        Friend WithEvents PanelForm_Bottom As Windows.Forms.Panel
        Friend WithEvents CheckBoxClearedChecks As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxOutstandingChecks As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxVoidedChecks As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxVoidComments As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxManualChecks As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxComputerGeneratedChecks As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents GroupBox1 As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents GroupBoxControl_Cutoffs As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents PostPeriod_ToMonth As WinForm.Presentation.Controls.ComboBox
        Friend WithEvents PostPeriod_FromMonth As WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelOptions_PostPeriod As WinForm.Presentation.Controls.Label
        Friend WithEvents LabelPostPeriod_To As WinForm.Presentation.Controls.Label
        Friend WithEvents LabelPostPeriod_From As WinForm.Presentation.Controls.Label
        Friend WithEvents LabelOptions_SelectBy As WinForm.Presentation.Controls.Label
        Friend WithEvents PanelOptions_Dates As Windows.Forms.Panel
        Friend WithEvents RadioButtonDates_Standard As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonDates_PostPeriod As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents Label1 As WinForm.Presentation.Controls.Label
        Friend WithEvents TabControlPanelSelectVendorsTab_SelectVendor As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemJDA_SelectVendorsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelSelectVendorsTab_SelectVendors As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewSelectVendors_Vendors As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RadioButtonSelectVendors_AllVendors As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSelectVendors_ChooseVendors As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents CheckBoxSelectByPayToVendor As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents GroupBox2 As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents CheckBoxIncludeInvoiceDetails As WinForm.Presentation.Controls.CheckBox
    End Class

End Namespace
