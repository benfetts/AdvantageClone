Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ClientBudgetControl
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClientBudgetControl))
            Me.TabControlControl_BudgetDetails = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelBillingIncomeSummary_Details = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewBillingIncomeSummary_Details = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemBudgetDetails_BillingIncomeSummaryTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.PanelControl_DistributionTabs = New System.Windows.Forms.Panel()
            Me.DateTimePickerControl_BudgetDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelControl_BudgetDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.PanelControl_Revision = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.TextBox3 = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelRevision_ModifyDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBox2 = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelRevision_CreateDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBox1 = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelRevision_ModifiedBy = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxRevision_ApprovedRevision = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.TextBoxRevision_CreatedBy = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelRevision_CreateUser = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelRevision_ApprovedRevision = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelRevision_Revision = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxRevision_Revision = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.TextBoxControl_Name = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelControl_Name = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxControl_Employee = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewControl_Vendor = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.CheckBoxForm_Inactive = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelControl_Reference = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelControl_Code = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelControl_Employee = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxControl_Reference = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxControl_Code = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TabItemBudgetDetails_FeeTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelFee_Details = New DevComponents.DotNetBar.TabControlPanel()
            Me.TabItemBudgetDetails_TimeTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelTime_Details = New DevComponents.DotNetBar.TabControlPanel()
            Me.TabItemBudgetDetails_DSCTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelDSC_Details = New DevComponents.DotNetBar.TabControlPanel()
            Me.TabItemBudgetDetails_CommissionTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelCommission_Details = New DevComponents.DotNetBar.TabControlPanel()
            Me.TabItemBudgetDetails_COSTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelCOS_Details = New DevComponents.DotNetBar.TabControlPanel()
            Me.TabItemBudgetDetails_DirectExpenseTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelDirectExpense_Details = New DevComponents.DotNetBar.TabControlPanel()
            Me.TabItemBudgetDetails_ClientOOPTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelClientOOP_Details = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewFee_Details = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.DataGridViewTime_Details = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.DataGridViewDSC_Details = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.DataGridViewCommission_Details = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.DataGridViewCOS_Details = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.DataGridViewDirectExpense_Details = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.DataGridViewClientOOP_Details = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.LabelControl_BudgetPeriod = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBox4 = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            CType(Me.TabControlControl_BudgetDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlControl_BudgetDetails.SuspendLayout()
            Me.TabControlPanelBillingIncomeSummary_Details.SuspendLayout()
            Me.PanelControl_DistributionTabs.SuspendLayout()
            CType(Me.DateTimePickerControl_BudgetDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PanelControl_Revision, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelControl_Revision.SuspendLayout()
            CType(Me.SearchableComboBoxControl_Employee.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewControl_Vendor, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelFee_Details.SuspendLayout()
            Me.TabControlPanelTime_Details.SuspendLayout()
            Me.TabControlPanelDSC_Details.SuspendLayout()
            Me.TabControlPanelCommission_Details.SuspendLayout()
            Me.TabControlPanelCOS_Details.SuspendLayout()
            Me.TabControlPanelDirectExpense_Details.SuspendLayout()
            Me.TabControlPanelClientOOP_Details.SuspendLayout()
            Me.SuspendLayout()
            '
            'TabControlControl_BudgetDetails
            '
            Me.TabControlControl_BudgetDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlControl_BudgetDetails.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
            Me.TabControlControl_BudgetDetails.CanReorderTabs = False
            Me.TabControlControl_BudgetDetails.Controls.Add(Me.TabControlPanelClientOOP_Details)
            Me.TabControlControl_BudgetDetails.Controls.Add(Me.TabControlPanelDirectExpense_Details)
            Me.TabControlControl_BudgetDetails.Controls.Add(Me.TabControlPanelBillingIncomeSummary_Details)
            Me.TabControlControl_BudgetDetails.Controls.Add(Me.TabControlPanelCOS_Details)
            Me.TabControlControl_BudgetDetails.Controls.Add(Me.TabControlPanelCommission_Details)
            Me.TabControlControl_BudgetDetails.Controls.Add(Me.TabControlPanelDSC_Details)
            Me.TabControlControl_BudgetDetails.Controls.Add(Me.TabControlPanelTime_Details)
            Me.TabControlControl_BudgetDetails.Controls.Add(Me.TabControlPanelFee_Details)
            Me.TabControlControl_BudgetDetails.ForeColor = System.Drawing.Color.Black
            Me.TabControlControl_BudgetDetails.Location = New System.Drawing.Point(0, 170)
            Me.TabControlControl_BudgetDetails.Name = "TabControlControl_BudgetDetails"
            Me.TabControlControl_BudgetDetails.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlControl_BudgetDetails.SelectedTabIndex = 0
            Me.TabControlControl_BudgetDetails.Size = New System.Drawing.Size(992, 435)
            Me.TabControlControl_BudgetDetails.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlControl_BudgetDetails.TabIndex = 0
            Me.TabControlControl_BudgetDetails.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlControl_BudgetDetails.Tabs.Add(Me.TabItemBudgetDetails_BillingIncomeSummaryTab)
            Me.TabControlControl_BudgetDetails.Tabs.Add(Me.TabItemBudgetDetails_FeeTab)
            Me.TabControlControl_BudgetDetails.Tabs.Add(Me.TabItemBudgetDetails_TimeTab)
            Me.TabControlControl_BudgetDetails.Tabs.Add(Me.TabItemBudgetDetails_DSCTab)
            Me.TabControlControl_BudgetDetails.Tabs.Add(Me.TabItemBudgetDetails_CommissionTab)
            Me.TabControlControl_BudgetDetails.Tabs.Add(Me.TabItemBudgetDetails_COSTab)
            Me.TabControlControl_BudgetDetails.Tabs.Add(Me.TabItemBudgetDetails_DirectExpenseTab)
            Me.TabControlControl_BudgetDetails.Tabs.Add(Me.TabItemBudgetDetails_ClientOOPTab)
            Me.TabControlControl_BudgetDetails.TabStop = False
            '
            'TabControlPanelBillingIncomeSummary_Details
            '
            Me.TabControlPanelBillingIncomeSummary_Details.Controls.Add(Me.DataGridViewBillingIncomeSummary_Details)
            Me.TabControlPanelBillingIncomeSummary_Details.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelBillingIncomeSummary_Details.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelBillingIncomeSummary_Details.Name = "TabControlPanelBillingIncomeSummary_Details"
            Me.TabControlPanelBillingIncomeSummary_Details.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelBillingIncomeSummary_Details.Size = New System.Drawing.Size(992, 388)
            Me.TabControlPanelBillingIncomeSummary_Details.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelBillingIncomeSummary_Details.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelBillingIncomeSummary_Details.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
            Me.TabControlPanelBillingIncomeSummary_Details.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelBillingIncomeSummary_Details.Style.GradientAngle = 90
            Me.TabControlPanelBillingIncomeSummary_Details.TabIndex = 10
            Me.TabControlPanelBillingIncomeSummary_Details.TabItem = Me.TabItemBudgetDetails_BillingIncomeSummaryTab
            '
            'DataGridViewBillingIncomeSummary_Details
            '
            Me.DataGridViewBillingIncomeSummary_Details.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewBillingIncomeSummary_Details.AllowSelectGroupHeaderRow = True
            Me.DataGridViewBillingIncomeSummary_Details.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewBillingIncomeSummary_Details.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewBillingIncomeSummary_Details.AutoFilterLookupColumns = False
            Me.DataGridViewBillingIncomeSummary_Details.AutoloadRepositoryDatasource = False
            Me.DataGridViewBillingIncomeSummary_Details.AutoUpdateViewCaption = True
            Me.DataGridViewBillingIncomeSummary_Details.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewBillingIncomeSummary_Details.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewBillingIncomeSummary_Details.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewBillingIncomeSummary_Details.ItemDescription = ""
            Me.DataGridViewBillingIncomeSummary_Details.Location = New System.Drawing.Point(3, 4)
            Me.DataGridViewBillingIncomeSummary_Details.MultiSelect = True
            Me.DataGridViewBillingIncomeSummary_Details.Name = "DataGridViewBillingIncomeSummary_Details"
            Me.DataGridViewBillingIncomeSummary_Details.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewBillingIncomeSummary_Details.RunStandardValidation = True
            Me.DataGridViewBillingIncomeSummary_Details.ShowSelectDeselectAllButtons = False
            Me.DataGridViewBillingIncomeSummary_Details.Size = New System.Drawing.Size(986, 380)
            Me.DataGridViewBillingIncomeSummary_Details.TabIndex = 0
            Me.DataGridViewBillingIncomeSummary_Details.UseEmbeddedNavigator = False
            Me.DataGridViewBillingIncomeSummary_Details.ViewCaptionHeight = -1
            '
            'TabItemBudgetDetails_BillingIncomeSummaryTab
            '
            Me.TabItemBudgetDetails_BillingIncomeSummaryTab.AttachedControl = Me.TabControlPanelBillingIncomeSummary_Details
            Me.TabItemBudgetDetails_BillingIncomeSummaryTab.Name = "TabItemBudgetDetails_BillingIncomeSummaryTab"
            Me.TabItemBudgetDetails_BillingIncomeSummaryTab.Text = "Billing / Income Summary"
            '
            'PanelControl_DistributionTabs
            '
            Me.PanelControl_DistributionTabs.Controls.Add(Me.TextBox4)
            Me.PanelControl_DistributionTabs.Controls.Add(Me.LabelControl_BudgetPeriod)
            Me.PanelControl_DistributionTabs.Controls.Add(Me.DateTimePickerControl_BudgetDate)
            Me.PanelControl_DistributionTabs.Controls.Add(Me.LabelControl_BudgetDate)
            Me.PanelControl_DistributionTabs.Controls.Add(Me.PanelControl_Revision)
            Me.PanelControl_DistributionTabs.Controls.Add(Me.TextBoxControl_Name)
            Me.PanelControl_DistributionTabs.Controls.Add(Me.LabelControl_Name)
            Me.PanelControl_DistributionTabs.Controls.Add(Me.SearchableComboBoxControl_Employee)
            Me.PanelControl_DistributionTabs.Controls.Add(Me.CheckBoxForm_Inactive)
            Me.PanelControl_DistributionTabs.Controls.Add(Me.LabelControl_Reference)
            Me.PanelControl_DistributionTabs.Controls.Add(Me.LabelControl_Code)
            Me.PanelControl_DistributionTabs.Controls.Add(Me.LabelControl_Employee)
            Me.PanelControl_DistributionTabs.Controls.Add(Me.TextBoxControl_Reference)
            Me.PanelControl_DistributionTabs.Controls.Add(Me.TextBoxControl_Code)
            Me.PanelControl_DistributionTabs.Controls.Add(Me.TabControlControl_BudgetDetails)
            Me.PanelControl_DistributionTabs.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelControl_DistributionTabs.Location = New System.Drawing.Point(0, 0)
            Me.PanelControl_DistributionTabs.Name = "PanelControl_DistributionTabs"
            Me.PanelControl_DistributionTabs.Size = New System.Drawing.Size(992, 615)
            Me.PanelControl_DistributionTabs.TabIndex = 52
            '
            'DateTimePickerControl_BudgetDate
            '
            Me.DateTimePickerControl_BudgetDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerControl_BudgetDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerControl_BudgetDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerControl_BudgetDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerControl_BudgetDate.ButtonDropDown.Visible = True
            Me.DateTimePickerControl_BudgetDate.ButtonFreeText.Checked = True
            Me.DateTimePickerControl_BudgetDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerControl_BudgetDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerControl_BudgetDate.DisplayName = ""
            Me.DateTimePickerControl_BudgetDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerControl_BudgetDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerControl_BudgetDate.FocusHighlightEnabled = True
            Me.DateTimePickerControl_BudgetDate.FreeTextEntryMode = True
            Me.DateTimePickerControl_BudgetDate.IsPopupCalendarOpen = False
            Me.DateTimePickerControl_BudgetDate.Location = New System.Drawing.Point(87, 78)
            Me.DateTimePickerControl_BudgetDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerControl_BudgetDate.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerControl_BudgetDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerControl_BudgetDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerControl_BudgetDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerControl_BudgetDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerControl_BudgetDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerControl_BudgetDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerControl_BudgetDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerControl_BudgetDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerControl_BudgetDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerControl_BudgetDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerControl_BudgetDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerControl_BudgetDate.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            Me.DateTimePickerControl_BudgetDate.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerControl_BudgetDate.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerControl_BudgetDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerControl_BudgetDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerControl_BudgetDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerControl_BudgetDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerControl_BudgetDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerControl_BudgetDate.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerControl_BudgetDate.Name = "DateTimePickerControl_BudgetDate"
            Me.DateTimePickerControl_BudgetDate.ReadOnly = False
            Me.DateTimePickerControl_BudgetDate.Size = New System.Drawing.Size(103, 20)
            Me.DateTimePickerControl_BudgetDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerControl_BudgetDate.TabIndex = 126
            Me.DateTimePickerControl_BudgetDate.Value = New Date(2014, 3, 27, 12, 0, 0, 0)
            '
            'LabelControl_BudgetDate
            '
            Me.LabelControl_BudgetDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_BudgetDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_BudgetDate.Location = New System.Drawing.Point(0, 77)
            Me.LabelControl_BudgetDate.Name = "LabelControl_BudgetDate"
            Me.LabelControl_BudgetDate.Size = New System.Drawing.Size(81, 20)
            Me.LabelControl_BudgetDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_BudgetDate.TabIndex = 125
            Me.LabelControl_BudgetDate.Text = "Budget Date:"
            '
            'PanelControl_Revision
            '
            Me.PanelControl_Revision.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelControl_Revision.Controls.Add(Me.TextBox3)
            Me.PanelControl_Revision.Controls.Add(Me.LabelRevision_ModifyDate)
            Me.PanelControl_Revision.Controls.Add(Me.TextBox2)
            Me.PanelControl_Revision.Controls.Add(Me.LabelRevision_CreateDate)
            Me.PanelControl_Revision.Controls.Add(Me.TextBox1)
            Me.PanelControl_Revision.Controls.Add(Me.LabelRevision_ModifiedBy)
            Me.PanelControl_Revision.Controls.Add(Me.ComboBoxRevision_ApprovedRevision)
            Me.PanelControl_Revision.Controls.Add(Me.TextBoxRevision_CreatedBy)
            Me.PanelControl_Revision.Controls.Add(Me.LabelRevision_CreateUser)
            Me.PanelControl_Revision.Controls.Add(Me.LabelRevision_ApprovedRevision)
            Me.PanelControl_Revision.Controls.Add(Me.LabelRevision_Revision)
            Me.PanelControl_Revision.Controls.Add(Me.ComboBoxRevision_Revision)
            Me.PanelControl_Revision.Location = New System.Drawing.Point(723, 0)
            Me.PanelControl_Revision.Name = "PanelControl_Revision"
            Me.PanelControl_Revision.Size = New System.Drawing.Size(269, 164)
            Me.PanelControl_Revision.TabIndex = 123
            '
            'TextBox3
            '
            Me.TextBox3.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBox3.Border.Class = "TextBoxBorder"
            Me.TextBox3.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBox3.CheckSpellingOnValidate = False
            Me.TextBox3.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBox3.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBox3.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBox3.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBox3.FocusHighlightEnabled = True
            Me.TextBox3.ForeColor = System.Drawing.Color.Black
            Me.TextBox3.Location = New System.Drawing.Point(112, 130)
            Me.TextBox3.MaxFileSize = CType(0, Long)
            Me.TextBox3.Name = "TextBox3"
            Me.TextBox3.ReadOnly = True
            Me.TextBox3.SecurityEnabled = True
            Me.TextBox3.ShowSpellCheckCompleteMessage = True
            Me.TextBox3.Size = New System.Drawing.Size(148, 20)
            Me.TextBox3.StartingFolderName = Nothing
            Me.TextBox3.TabIndex = 134
            Me.TextBox3.TabOnEnter = True
            Me.TextBox3.TabStop = False
            '
            'LabelRevision_ModifyDate
            '
            Me.LabelRevision_ModifyDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRevision_ModifyDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRevision_ModifyDate.Location = New System.Drawing.Point(0, 130)
            Me.LabelRevision_ModifyDate.Name = "LabelRevision_ModifyDate"
            Me.LabelRevision_ModifyDate.Size = New System.Drawing.Size(106, 20)
            Me.LabelRevision_ModifyDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRevision_ModifyDate.TabIndex = 133
            Me.LabelRevision_ModifyDate.Text = "Modify Date:"
            '
            'TextBox2
            '
            Me.TextBox2.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBox2.Border.Class = "TextBoxBorder"
            Me.TextBox2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBox2.CheckSpellingOnValidate = False
            Me.TextBox2.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBox2.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBox2.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBox2.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBox2.FocusHighlightEnabled = True
            Me.TextBox2.ForeColor = System.Drawing.Color.Black
            Me.TextBox2.Location = New System.Drawing.Point(112, 104)
            Me.TextBox2.MaxFileSize = CType(0, Long)
            Me.TextBox2.Name = "TextBox2"
            Me.TextBox2.ReadOnly = True
            Me.TextBox2.SecurityEnabled = True
            Me.TextBox2.ShowSpellCheckCompleteMessage = True
            Me.TextBox2.Size = New System.Drawing.Size(148, 20)
            Me.TextBox2.StartingFolderName = Nothing
            Me.TextBox2.TabIndex = 132
            Me.TextBox2.TabOnEnter = True
            Me.TextBox2.TabStop = False
            '
            'LabelRevision_CreateDate
            '
            Me.LabelRevision_CreateDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRevision_CreateDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRevision_CreateDate.Location = New System.Drawing.Point(0, 104)
            Me.LabelRevision_CreateDate.Name = "LabelRevision_CreateDate"
            Me.LabelRevision_CreateDate.Size = New System.Drawing.Size(106, 20)
            Me.LabelRevision_CreateDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRevision_CreateDate.TabIndex = 131
            Me.LabelRevision_CreateDate.Text = "Create Date:"
            '
            'TextBox1
            '
            Me.TextBox1.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBox1.Border.Class = "TextBoxBorder"
            Me.TextBox1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBox1.CheckSpellingOnValidate = False
            Me.TextBox1.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBox1.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBox1.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBox1.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBox1.FocusHighlightEnabled = True
            Me.TextBox1.ForeColor = System.Drawing.Color.Black
            Me.TextBox1.Location = New System.Drawing.Point(112, 78)
            Me.TextBox1.MaxFileSize = CType(0, Long)
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.ReadOnly = True
            Me.TextBox1.SecurityEnabled = True
            Me.TextBox1.ShowSpellCheckCompleteMessage = True
            Me.TextBox1.Size = New System.Drawing.Size(148, 20)
            Me.TextBox1.StartingFolderName = Nothing
            Me.TextBox1.TabIndex = 130
            Me.TextBox1.TabOnEnter = True
            Me.TextBox1.TabStop = False
            '
            'LabelRevision_ModifiedBy
            '
            Me.LabelRevision_ModifiedBy.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRevision_ModifiedBy.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRevision_ModifiedBy.Location = New System.Drawing.Point(0, 78)
            Me.LabelRevision_ModifiedBy.Name = "LabelRevision_ModifiedBy"
            Me.LabelRevision_ModifiedBy.Size = New System.Drawing.Size(106, 20)
            Me.LabelRevision_ModifiedBy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRevision_ModifiedBy.TabIndex = 129
            Me.LabelRevision_ModifiedBy.Text = "Modified By:"
            '
            'ComboBoxRevision_ApprovedRevision
            '
            Me.ComboBoxRevision_ApprovedRevision.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxRevision_ApprovedRevision.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxRevision_ApprovedRevision.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxRevision_ApprovedRevision.AutoFindItemInDataSource = False
            Me.ComboBoxRevision_ApprovedRevision.AutoSelectSingleItemDatasource = False
            Me.ComboBoxRevision_ApprovedRevision.BookmarkingEnabled = False
            Me.ComboBoxRevision_ApprovedRevision.ClientCode = ""
            Me.ComboBoxRevision_ApprovedRevision.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.PostPeriod
            Me.ComboBoxRevision_ApprovedRevision.DisableMouseWheel = True
            Me.ComboBoxRevision_ApprovedRevision.DisplayMember = "Description"
            Me.ComboBoxRevision_ApprovedRevision.DisplayName = ""
            Me.ComboBoxRevision_ApprovedRevision.DivisionCode = ""
            Me.ComboBoxRevision_ApprovedRevision.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxRevision_ApprovedRevision.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxRevision_ApprovedRevision.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxRevision_ApprovedRevision.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxRevision_ApprovedRevision.FocusHighlightEnabled = True
            Me.ComboBoxRevision_ApprovedRevision.FormattingEnabled = True
            Me.ComboBoxRevision_ApprovedRevision.ItemHeight = 14
            Me.ComboBoxRevision_ApprovedRevision.Location = New System.Drawing.Point(112, 26)
            Me.ComboBoxRevision_ApprovedRevision.Name = "ComboBoxRevision_ApprovedRevision"
            Me.ComboBoxRevision_ApprovedRevision.PreventEnterBeep = False
            Me.ComboBoxRevision_ApprovedRevision.ReadOnly = False
            Me.ComboBoxRevision_ApprovedRevision.SecurityEnabled = True
            Me.ComboBoxRevision_ApprovedRevision.Size = New System.Drawing.Size(148, 20)
            Me.ComboBoxRevision_ApprovedRevision.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxRevision_ApprovedRevision.TabIndex = 128
            Me.ComboBoxRevision_ApprovedRevision.ValueMember = "Code"
            Me.ComboBoxRevision_ApprovedRevision.WatermarkText = "Select Post Period"
            '
            'TextBoxRevision_CreatedBy
            '
            Me.TextBoxRevision_CreatedBy.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxRevision_CreatedBy.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxRevision_CreatedBy.CheckSpellingOnValidate = False
            Me.TextBoxRevision_CreatedBy.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxRevision_CreatedBy.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxRevision_CreatedBy.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxRevision_CreatedBy.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxRevision_CreatedBy.FocusHighlightEnabled = True
            Me.TextBoxRevision_CreatedBy.ForeColor = System.Drawing.Color.Black
            Me.TextBoxRevision_CreatedBy.Location = New System.Drawing.Point(112, 52)
            Me.TextBoxRevision_CreatedBy.MaxFileSize = CType(0, Long)
            Me.TextBoxRevision_CreatedBy.Name = "TextBoxRevision_CreatedBy"
            Me.TextBoxRevision_CreatedBy.ReadOnly = True
            Me.TextBoxRevision_CreatedBy.SecurityEnabled = True
            Me.TextBoxRevision_CreatedBy.ShowSpellCheckCompleteMessage = True
            Me.TextBoxRevision_CreatedBy.Size = New System.Drawing.Size(148, 20)
            Me.TextBoxRevision_CreatedBy.StartingFolderName = Nothing
            Me.TextBoxRevision_CreatedBy.TabIndex = 127
            Me.TextBoxRevision_CreatedBy.TabOnEnter = True
            Me.TextBoxRevision_CreatedBy.TabStop = False
            '
            'LabelRevision_CreateUser
            '
            Me.LabelRevision_CreateUser.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRevision_CreateUser.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRevision_CreateUser.Location = New System.Drawing.Point(0, 52)
            Me.LabelRevision_CreateUser.Name = "LabelRevision_CreateUser"
            Me.LabelRevision_CreateUser.Size = New System.Drawing.Size(106, 20)
            Me.LabelRevision_CreateUser.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRevision_CreateUser.TabIndex = 126
            Me.LabelRevision_CreateUser.Text = "Created By:"
            '
            'LabelRevision_ApprovedRevision
            '
            Me.LabelRevision_ApprovedRevision.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRevision_ApprovedRevision.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRevision_ApprovedRevision.Location = New System.Drawing.Point(0, 26)
            Me.LabelRevision_ApprovedRevision.Name = "LabelRevision_ApprovedRevision"
            Me.LabelRevision_ApprovedRevision.Size = New System.Drawing.Size(106, 20)
            Me.LabelRevision_ApprovedRevision.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRevision_ApprovedRevision.TabIndex = 125
            Me.LabelRevision_ApprovedRevision.Text = "Approved Revision:"
            '
            'LabelRevision_Revision
            '
            Me.LabelRevision_Revision.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRevision_Revision.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRevision_Revision.Location = New System.Drawing.Point(0, 0)
            Me.LabelRevision_Revision.Name = "LabelRevision_Revision"
            Me.LabelRevision_Revision.Size = New System.Drawing.Size(106, 20)
            Me.LabelRevision_Revision.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRevision_Revision.TabIndex = 124
            Me.LabelRevision_Revision.Text = "Revision:"
            '
            'ComboBoxRevision_Revision
            '
            Me.ComboBoxRevision_Revision.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxRevision_Revision.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxRevision_Revision.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxRevision_Revision.AutoFindItemInDataSource = False
            Me.ComboBoxRevision_Revision.AutoSelectSingleItemDatasource = False
            Me.ComboBoxRevision_Revision.BookmarkingEnabled = False
            Me.ComboBoxRevision_Revision.ClientCode = ""
            Me.ComboBoxRevision_Revision.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.PostPeriod
            Me.ComboBoxRevision_Revision.DisableMouseWheel = True
            Me.ComboBoxRevision_Revision.DisplayMember = "Description"
            Me.ComboBoxRevision_Revision.DisplayName = ""
            Me.ComboBoxRevision_Revision.DivisionCode = ""
            Me.ComboBoxRevision_Revision.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxRevision_Revision.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxRevision_Revision.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxRevision_Revision.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxRevision_Revision.FocusHighlightEnabled = True
            Me.ComboBoxRevision_Revision.FormattingEnabled = True
            Me.ComboBoxRevision_Revision.ItemHeight = 14
            Me.ComboBoxRevision_Revision.Location = New System.Drawing.Point(112, 0)
            Me.ComboBoxRevision_Revision.Name = "ComboBoxRevision_Revision"
            Me.ComboBoxRevision_Revision.PreventEnterBeep = False
            Me.ComboBoxRevision_Revision.ReadOnly = False
            Me.ComboBoxRevision_Revision.SecurityEnabled = True
            Me.ComboBoxRevision_Revision.Size = New System.Drawing.Size(148, 20)
            Me.ComboBoxRevision_Revision.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxRevision_Revision.TabIndex = 123
            Me.ComboBoxRevision_Revision.ValueMember = "Code"
            Me.ComboBoxRevision_Revision.WatermarkText = "Select Post Period"
            '
            'TextBoxControl_Name
            '
            Me.TextBoxControl_Name.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxControl_Name.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxControl_Name.CheckSpellingOnValidate = False
            Me.TextBoxControl_Name.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxControl_Name.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxControl_Name.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxControl_Name.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxControl_Name.FocusHighlightEnabled = True
            Me.TextBoxControl_Name.ForeColor = System.Drawing.Color.Black
            Me.TextBoxControl_Name.Location = New System.Drawing.Point(246, 0)
            Me.TextBoxControl_Name.MaxFileSize = CType(0, Long)
            Me.TextBoxControl_Name.Name = "TextBoxControl_Name"
            Me.TextBoxControl_Name.ReadOnly = True
            Me.TextBoxControl_Name.SecurityEnabled = True
            Me.TextBoxControl_Name.ShowSpellCheckCompleteMessage = True
            Me.TextBoxControl_Name.Size = New System.Drawing.Size(262, 20)
            Me.TextBoxControl_Name.StartingFolderName = Nothing
            Me.TextBoxControl_Name.TabIndex = 115
            Me.TextBoxControl_Name.TabOnEnter = True
            Me.TextBoxControl_Name.TabStop = False
            '
            'LabelControl_Name
            '
            Me.LabelControl_Name.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_Name.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_Name.Location = New System.Drawing.Point(196, -1)
            Me.LabelControl_Name.Name = "LabelControl_Name"
            Me.LabelControl_Name.Size = New System.Drawing.Size(44, 20)
            Me.LabelControl_Name.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_Name.TabIndex = 114
            Me.LabelControl_Name.Text = "Name:"
            '
            'SearchableComboBoxControl_Employee
            '
            Me.SearchableComboBoxControl_Employee.ActiveFilterString = ""
            Me.SearchableComboBoxControl_Employee.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxControl_Employee.AutoFillMode = False
            Me.SearchableComboBoxControl_Employee.BookmarkingEnabled = False
            Me.SearchableComboBoxControl_Employee.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Employee
            Me.SearchableComboBoxControl_Employee.DataSource = Nothing
            Me.SearchableComboBoxControl_Employee.DisableMouseWheel = True
            Me.SearchableComboBoxControl_Employee.DisplayName = ""
            Me.SearchableComboBoxControl_Employee.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxControl_Employee.Location = New System.Drawing.Point(87, 52)
            Me.SearchableComboBoxControl_Employee.Name = "SearchableComboBoxControl_Employee"
            Me.SearchableComboBoxControl_Employee.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxControl_Employee.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxControl_Employee.Properties.NullText = "Select Employee"
            Me.SearchableComboBoxControl_Employee.Properties.ShowClearButton = False
            Me.SearchableComboBoxControl_Employee.Properties.ValueMember = "Code"
            Me.SearchableComboBoxControl_Employee.Properties.View = Me.SearchableComboBoxViewControl_Vendor
            Me.SearchableComboBoxControl_Employee.SecurityEnabled = True
            Me.SearchableComboBoxControl_Employee.SelectedValue = Nothing
            Me.SearchableComboBoxControl_Employee.Size = New System.Drawing.Size(262, 20)
            Me.SearchableComboBoxControl_Employee.TabIndex = 113
            '
            'SearchableComboBoxViewControl_Vendor
            '
            Me.SearchableComboBoxViewControl_Vendor.AFActiveFilterString = ""
            Me.SearchableComboBoxViewControl_Vendor.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewControl_Vendor.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewControl_Vendor.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewControl_Vendor.DataSourceClearing = False
            Me.SearchableComboBoxViewControl_Vendor.EnableDisabledRows = False
            Me.SearchableComboBoxViewControl_Vendor.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewControl_Vendor.Name = "SearchableComboBoxViewControl_Vendor"
            Me.SearchableComboBoxViewControl_Vendor.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewControl_Vendor.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewControl_Vendor.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewControl_Vendor.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewControl_Vendor.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewControl_Vendor.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewControl_Vendor.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewControl_Vendor.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewControl_Vendor.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewControl_Vendor.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewControl_Vendor.RunStandardValidation = True
            '
            'CheckBoxForm_Inactive
            '
            Me.CheckBoxForm_Inactive.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxForm_Inactive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_Inactive.CheckValue = 0
            Me.CheckBoxForm_Inactive.CheckValueChecked = 1
            Me.CheckBoxForm_Inactive.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_Inactive.CheckValueUnchecked = 0
            Me.CheckBoxForm_Inactive.ChildControls = CType(resources.GetObject("CheckBoxForm_Inactive.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Inactive.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_Inactive.Location = New System.Drawing.Point(514, 0)
            Me.CheckBoxForm_Inactive.Name = "CheckBoxForm_Inactive"
            Me.CheckBoxForm_Inactive.OldestSibling = Nothing
            Me.CheckBoxForm_Inactive.SecurityEnabled = True
            Me.CheckBoxForm_Inactive.SiblingControls = CType(resources.GetObject("CheckBoxForm_Inactive.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Inactive.Size = New System.Drawing.Size(66, 20)
            Me.CheckBoxForm_Inactive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_Inactive.TabIndex = 112
            Me.CheckBoxForm_Inactive.Text = "Inactive"
            '
            'LabelControl_Reference
            '
            Me.LabelControl_Reference.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_Reference.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_Reference.Location = New System.Drawing.Point(0, 26)
            Me.LabelControl_Reference.Name = "LabelControl_Reference"
            Me.LabelControl_Reference.Size = New System.Drawing.Size(81, 20)
            Me.LabelControl_Reference.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_Reference.TabIndex = 105
            Me.LabelControl_Reference.Text = "Reference:"
            '
            'LabelControl_Code
            '
            Me.LabelControl_Code.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_Code.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_Code.Location = New System.Drawing.Point(0, 0)
            Me.LabelControl_Code.Name = "LabelControl_Code"
            Me.LabelControl_Code.Size = New System.Drawing.Size(81, 20)
            Me.LabelControl_Code.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_Code.TabIndex = 104
            Me.LabelControl_Code.Text = "Code:"
            '
            'LabelControl_Employee
            '
            Me.LabelControl_Employee.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_Employee.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_Employee.Location = New System.Drawing.Point(0, 51)
            Me.LabelControl_Employee.Name = "LabelControl_Employee"
            Me.LabelControl_Employee.Size = New System.Drawing.Size(81, 20)
            Me.LabelControl_Employee.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_Employee.TabIndex = 109
            Me.LabelControl_Employee.Text = "Employee:"
            '
            'TextBoxControl_Reference
            '
            Me.TextBoxControl_Reference.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxControl_Reference.Border.Class = "TextBoxBorder"
            Me.TextBoxControl_Reference.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxControl_Reference.CheckSpellingOnValidate = False
            Me.TextBoxControl_Reference.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxControl_Reference.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxControl_Reference.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxControl_Reference.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxControl_Reference.FocusHighlightEnabled = True
            Me.TextBoxControl_Reference.ForeColor = System.Drawing.Color.Black
            Me.TextBoxControl_Reference.Location = New System.Drawing.Point(87, 26)
            Me.TextBoxControl_Reference.MaxFileSize = CType(0, Long)
            Me.TextBoxControl_Reference.Name = "TextBoxControl_Reference"
            Me.TextBoxControl_Reference.ReadOnly = True
            Me.TextBoxControl_Reference.SecurityEnabled = True
            Me.TextBoxControl_Reference.ShowSpellCheckCompleteMessage = True
            Me.TextBoxControl_Reference.Size = New System.Drawing.Size(421, 20)
            Me.TextBoxControl_Reference.StartingFolderName = Nothing
            Me.TextBoxControl_Reference.TabIndex = 110
            Me.TextBoxControl_Reference.TabOnEnter = True
            Me.TextBoxControl_Reference.TabStop = False
            '
            'TextBoxControl_Code
            '
            Me.TextBoxControl_Code.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxControl_Code.Border.Class = "TextBoxBorder"
            Me.TextBoxControl_Code.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxControl_Code.CheckSpellingOnValidate = False
            Me.TextBoxControl_Code.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxControl_Code.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxControl_Code.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxControl_Code.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxControl_Code.FocusHighlightEnabled = True
            Me.TextBoxControl_Code.ForeColor = System.Drawing.Color.Black
            Me.TextBoxControl_Code.Location = New System.Drawing.Point(87, 0)
            Me.TextBoxControl_Code.MaxFileSize = CType(0, Long)
            Me.TextBoxControl_Code.Name = "TextBoxControl_Code"
            Me.TextBoxControl_Code.ReadOnly = True
            Me.TextBoxControl_Code.SecurityEnabled = True
            Me.TextBoxControl_Code.ShowSpellCheckCompleteMessage = True
            Me.TextBoxControl_Code.Size = New System.Drawing.Size(103, 20)
            Me.TextBoxControl_Code.StartingFolderName = Nothing
            Me.TextBoxControl_Code.TabIndex = 111
            Me.TextBoxControl_Code.TabOnEnter = True
            Me.TextBoxControl_Code.TabStop = False
            '
            'TabItemBudgetDetails_FeeTab
            '
            Me.TabItemBudgetDetails_FeeTab.AttachedControl = Me.TabControlPanelFee_Details
            Me.TabItemBudgetDetails_FeeTab.Name = "TabItemBudgetDetails_FeeTab"
            Me.TabItemBudgetDetails_FeeTab.Text = "Fee"
            '
            'TabControlPanelFee_Details
            '
            Me.TabControlPanelFee_Details.Controls.Add(Me.DataGridViewFee_Details)
            Me.TabControlPanelFee_Details.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelFee_Details.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelFee_Details.Name = "TabControlPanelFee_Details"
            Me.TabControlPanelFee_Details.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelFee_Details.Size = New System.Drawing.Size(992, 388)
            Me.TabControlPanelFee_Details.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelFee_Details.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelFee_Details.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
            Me.TabControlPanelFee_Details.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelFee_Details.Style.GradientAngle = 90
            Me.TabControlPanelFee_Details.TabIndex = 11
            Me.TabControlPanelFee_Details.TabItem = Me.TabItemBudgetDetails_FeeTab
            '
            'TabItemBudgetDetails_TimeTab
            '
            Me.TabItemBudgetDetails_TimeTab.AttachedControl = Me.TabControlPanelTime_Details
            Me.TabItemBudgetDetails_TimeTab.Name = "TabItemBudgetDetails_TimeTab"
            Me.TabItemBudgetDetails_TimeTab.Text = "Time"
            '
            'TabControlPanelTime_Details
            '
            Me.TabControlPanelTime_Details.Controls.Add(Me.DataGridViewTime_Details)
            Me.TabControlPanelTime_Details.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelTime_Details.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelTime_Details.Name = "TabControlPanelTime_Details"
            Me.TabControlPanelTime_Details.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelTime_Details.Size = New System.Drawing.Size(992, 388)
            Me.TabControlPanelTime_Details.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelTime_Details.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelTime_Details.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
            Me.TabControlPanelTime_Details.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelTime_Details.Style.GradientAngle = 90
            Me.TabControlPanelTime_Details.TabIndex = 12
            Me.TabControlPanelTime_Details.TabItem = Me.TabItemBudgetDetails_TimeTab
            '
            'TabItemBudgetDetails_DSCTab
            '
            Me.TabItemBudgetDetails_DSCTab.AttachedControl = Me.TabControlPanelDSC_Details
            Me.TabItemBudgetDetails_DSCTab.Name = "TabItemBudgetDetails_DSCTab"
            Me.TabItemBudgetDetails_DSCTab.Text = "DSC"
            '
            'TabControlPanelDSC_Details
            '
            Me.TabControlPanelDSC_Details.Controls.Add(Me.DataGridViewDSC_Details)
            Me.TabControlPanelDSC_Details.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelDSC_Details.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelDSC_Details.Name = "TabControlPanelDSC_Details"
            Me.TabControlPanelDSC_Details.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelDSC_Details.Size = New System.Drawing.Size(992, 388)
            Me.TabControlPanelDSC_Details.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelDSC_Details.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelDSC_Details.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
            Me.TabControlPanelDSC_Details.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelDSC_Details.Style.GradientAngle = 90
            Me.TabControlPanelDSC_Details.TabIndex = 13
            Me.TabControlPanelDSC_Details.TabItem = Me.TabItemBudgetDetails_DSCTab
            '
            'TabItemBudgetDetails_CommissionTab
            '
            Me.TabItemBudgetDetails_CommissionTab.AttachedControl = Me.TabControlPanelCommission_Details
            Me.TabItemBudgetDetails_CommissionTab.Name = "TabItemBudgetDetails_CommissionTab"
            Me.TabItemBudgetDetails_CommissionTab.Text = "Commission"
            '
            'TabControlPanelCommission_Details
            '
            Me.TabControlPanelCommission_Details.Controls.Add(Me.DataGridViewCommission_Details)
            Me.TabControlPanelCommission_Details.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelCommission_Details.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelCommission_Details.Name = "TabControlPanelCommission_Details"
            Me.TabControlPanelCommission_Details.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelCommission_Details.Size = New System.Drawing.Size(992, 388)
            Me.TabControlPanelCommission_Details.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelCommission_Details.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelCommission_Details.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
            Me.TabControlPanelCommission_Details.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelCommission_Details.Style.GradientAngle = 90
            Me.TabControlPanelCommission_Details.TabIndex = 14
            Me.TabControlPanelCommission_Details.TabItem = Me.TabItemBudgetDetails_CommissionTab
            '
            'TabItemBudgetDetails_COSTab
            '
            Me.TabItemBudgetDetails_COSTab.AttachedControl = Me.TabControlPanelCOS_Details
            Me.TabItemBudgetDetails_COSTab.Name = "TabItemBudgetDetails_COSTab"
            Me.TabItemBudgetDetails_COSTab.Text = "COS"
            '
            'TabControlPanelCOS_Details
            '
            Me.TabControlPanelCOS_Details.Controls.Add(Me.DataGridViewCOS_Details)
            Me.TabControlPanelCOS_Details.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelCOS_Details.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelCOS_Details.Name = "TabControlPanelCOS_Details"
            Me.TabControlPanelCOS_Details.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelCOS_Details.Size = New System.Drawing.Size(992, 388)
            Me.TabControlPanelCOS_Details.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelCOS_Details.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelCOS_Details.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
            Me.TabControlPanelCOS_Details.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelCOS_Details.Style.GradientAngle = 90
            Me.TabControlPanelCOS_Details.TabIndex = 15
            Me.TabControlPanelCOS_Details.TabItem = Me.TabItemBudgetDetails_COSTab
            '
            'TabItemBudgetDetails_DirectExpenseTab
            '
            Me.TabItemBudgetDetails_DirectExpenseTab.AttachedControl = Me.TabControlPanelDirectExpense_Details
            Me.TabItemBudgetDetails_DirectExpenseTab.Name = "TabItemBudgetDetails_DirectExpenseTab"
            Me.TabItemBudgetDetails_DirectExpenseTab.Text = "Direct Expense"
            '
            'TabControlPanelDirectExpense_Details
            '
            Me.TabControlPanelDirectExpense_Details.Controls.Add(Me.DataGridViewDirectExpense_Details)
            Me.TabControlPanelDirectExpense_Details.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelDirectExpense_Details.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelDirectExpense_Details.Name = "TabControlPanelDirectExpense_Details"
            Me.TabControlPanelDirectExpense_Details.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelDirectExpense_Details.Size = New System.Drawing.Size(992, 388)
            Me.TabControlPanelDirectExpense_Details.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelDirectExpense_Details.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelDirectExpense_Details.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
            Me.TabControlPanelDirectExpense_Details.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelDirectExpense_Details.Style.GradientAngle = 90
            Me.TabControlPanelDirectExpense_Details.TabIndex = 16
            Me.TabControlPanelDirectExpense_Details.TabItem = Me.TabItemBudgetDetails_DirectExpenseTab
            '
            'TabItemBudgetDetails_ClientOOPTab
            '
            Me.TabItemBudgetDetails_ClientOOPTab.AttachedControl = Me.TabControlPanelClientOOP_Details
            Me.TabItemBudgetDetails_ClientOOPTab.Name = "TabItemBudgetDetails_ClientOOPTab"
            Me.TabItemBudgetDetails_ClientOOPTab.Text = "Client OOP"
            '
            'TabControlPanelClientOOP_Details
            '
            Me.TabControlPanelClientOOP_Details.Controls.Add(Me.DataGridViewClientOOP_Details)
            Me.TabControlPanelClientOOP_Details.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelClientOOP_Details.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelClientOOP_Details.Name = "TabControlPanelClientOOP_Details"
            Me.TabControlPanelClientOOP_Details.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelClientOOP_Details.Size = New System.Drawing.Size(992, 408)
            Me.TabControlPanelClientOOP_Details.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelClientOOP_Details.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelClientOOP_Details.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
            Me.TabControlPanelClientOOP_Details.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelClientOOP_Details.Style.GradientAngle = 90
            Me.TabControlPanelClientOOP_Details.TabIndex = 17
            Me.TabControlPanelClientOOP_Details.TabItem = Me.TabItemBudgetDetails_ClientOOPTab
            '
            'DataGridViewFee_Details
            '
            Me.DataGridViewFee_Details.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewFee_Details.AllowSelectGroupHeaderRow = True
            Me.DataGridViewFee_Details.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewFee_Details.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewFee_Details.AutoFilterLookupColumns = False
            Me.DataGridViewFee_Details.AutoloadRepositoryDatasource = False
            Me.DataGridViewFee_Details.AutoUpdateViewCaption = True
            Me.DataGridViewFee_Details.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewFee_Details.DataSource = Nothing
            Me.DataGridViewFee_Details.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewFee_Details.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewFee_Details.ItemDescription = ""
            Me.DataGridViewFee_Details.Location = New System.Drawing.Point(3, 4)
            Me.DataGridViewFee_Details.MultiSelect = True
            Me.DataGridViewFee_Details.Name = "DataGridViewFee_Details"
            Me.DataGridViewFee_Details.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewFee_Details.RunStandardValidation = True
            Me.DataGridViewFee_Details.ShowSelectDeselectAllButtons = False
            Me.DataGridViewFee_Details.Size = New System.Drawing.Size(986, 380)
            Me.DataGridViewFee_Details.TabIndex = 1
            Me.DataGridViewFee_Details.UseEmbeddedNavigator = False
            Me.DataGridViewFee_Details.ViewCaptionHeight = -1
            '
            'DataGridViewTime_Details
            '
            Me.DataGridViewTime_Details.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewTime_Details.AllowSelectGroupHeaderRow = True
            Me.DataGridViewTime_Details.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewTime_Details.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewTime_Details.AutoFilterLookupColumns = False
            Me.DataGridViewTime_Details.AutoloadRepositoryDatasource = False
            Me.DataGridViewTime_Details.AutoUpdateViewCaption = True
            Me.DataGridViewTime_Details.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewTime_Details.DataSource = Nothing
            Me.DataGridViewTime_Details.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewTime_Details.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewTime_Details.ItemDescription = ""
            Me.DataGridViewTime_Details.Location = New System.Drawing.Point(3, 4)
            Me.DataGridViewTime_Details.MultiSelect = True
            Me.DataGridViewTime_Details.Name = "DataGridViewTime_Details"
            Me.DataGridViewTime_Details.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewTime_Details.RunStandardValidation = True
            Me.DataGridViewTime_Details.ShowSelectDeselectAllButtons = False
            Me.DataGridViewTime_Details.Size = New System.Drawing.Size(986, 380)
            Me.DataGridViewTime_Details.TabIndex = 1
            Me.DataGridViewTime_Details.UseEmbeddedNavigator = False
            Me.DataGridViewTime_Details.ViewCaptionHeight = -1
            '
            'DataGridViewDSC_Details
            '
            Me.DataGridViewDSC_Details.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewDSC_Details.AllowSelectGroupHeaderRow = True
            Me.DataGridViewDSC_Details.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewDSC_Details.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewDSC_Details.AutoFilterLookupColumns = False
            Me.DataGridViewDSC_Details.AutoloadRepositoryDatasource = False
            Me.DataGridViewDSC_Details.AutoUpdateViewCaption = True
            Me.DataGridViewDSC_Details.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewDSC_Details.DataSource = Nothing
            Me.DataGridViewDSC_Details.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewDSC_Details.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewDSC_Details.ItemDescription = ""
            Me.DataGridViewDSC_Details.Location = New System.Drawing.Point(3, 4)
            Me.DataGridViewDSC_Details.MultiSelect = True
            Me.DataGridViewDSC_Details.Name = "DataGridViewDSC_Details"
            Me.DataGridViewDSC_Details.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewDSC_Details.RunStandardValidation = True
            Me.DataGridViewDSC_Details.ShowSelectDeselectAllButtons = False
            Me.DataGridViewDSC_Details.Size = New System.Drawing.Size(986, 380)
            Me.DataGridViewDSC_Details.TabIndex = 1
            Me.DataGridViewDSC_Details.UseEmbeddedNavigator = False
            Me.DataGridViewDSC_Details.ViewCaptionHeight = -1
            '
            'DataGridViewCommission_Details
            '
            Me.DataGridViewCommission_Details.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewCommission_Details.AllowSelectGroupHeaderRow = True
            Me.DataGridViewCommission_Details.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewCommission_Details.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewCommission_Details.AutoFilterLookupColumns = False
            Me.DataGridViewCommission_Details.AutoloadRepositoryDatasource = False
            Me.DataGridViewCommission_Details.AutoUpdateViewCaption = True
            Me.DataGridViewCommission_Details.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewCommission_Details.DataSource = Nothing
            Me.DataGridViewCommission_Details.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewCommission_Details.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewCommission_Details.ItemDescription = ""
            Me.DataGridViewCommission_Details.Location = New System.Drawing.Point(3, 4)
            Me.DataGridViewCommission_Details.MultiSelect = True
            Me.DataGridViewCommission_Details.Name = "DataGridViewCommission_Details"
            Me.DataGridViewCommission_Details.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewCommission_Details.RunStandardValidation = True
            Me.DataGridViewCommission_Details.ShowSelectDeselectAllButtons = False
            Me.DataGridViewCommission_Details.Size = New System.Drawing.Size(986, 380)
            Me.DataGridViewCommission_Details.TabIndex = 1
            Me.DataGridViewCommission_Details.UseEmbeddedNavigator = False
            Me.DataGridViewCommission_Details.ViewCaptionHeight = -1
            '
            'DataGridViewCOS_Details
            '
            Me.DataGridViewCOS_Details.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewCOS_Details.AllowSelectGroupHeaderRow = True
            Me.DataGridViewCOS_Details.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewCOS_Details.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewCOS_Details.AutoFilterLookupColumns = False
            Me.DataGridViewCOS_Details.AutoloadRepositoryDatasource = False
            Me.DataGridViewCOS_Details.AutoUpdateViewCaption = True
            Me.DataGridViewCOS_Details.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewCOS_Details.DataSource = Nothing
            Me.DataGridViewCOS_Details.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewCOS_Details.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewCOS_Details.ItemDescription = ""
            Me.DataGridViewCOS_Details.Location = New System.Drawing.Point(3, 4)
            Me.DataGridViewCOS_Details.MultiSelect = True
            Me.DataGridViewCOS_Details.Name = "DataGridViewCOS_Details"
            Me.DataGridViewCOS_Details.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewCOS_Details.RunStandardValidation = True
            Me.DataGridViewCOS_Details.ShowSelectDeselectAllButtons = False
            Me.DataGridViewCOS_Details.Size = New System.Drawing.Size(986, 380)
            Me.DataGridViewCOS_Details.TabIndex = 1
            Me.DataGridViewCOS_Details.UseEmbeddedNavigator = False
            Me.DataGridViewCOS_Details.ViewCaptionHeight = -1
            '
            'DataGridViewDirectExpense_Details
            '
            Me.DataGridViewDirectExpense_Details.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewDirectExpense_Details.AllowSelectGroupHeaderRow = True
            Me.DataGridViewDirectExpense_Details.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewDirectExpense_Details.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewDirectExpense_Details.AutoFilterLookupColumns = False
            Me.DataGridViewDirectExpense_Details.AutoloadRepositoryDatasource = False
            Me.DataGridViewDirectExpense_Details.AutoUpdateViewCaption = True
            Me.DataGridViewDirectExpense_Details.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewDirectExpense_Details.DataSource = Nothing
            Me.DataGridViewDirectExpense_Details.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewDirectExpense_Details.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewDirectExpense_Details.ItemDescription = ""
            Me.DataGridViewDirectExpense_Details.Location = New System.Drawing.Point(3, 4)
            Me.DataGridViewDirectExpense_Details.MultiSelect = True
            Me.DataGridViewDirectExpense_Details.Name = "DataGridViewDirectExpense_Details"
            Me.DataGridViewDirectExpense_Details.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewDirectExpense_Details.RunStandardValidation = True
            Me.DataGridViewDirectExpense_Details.ShowSelectDeselectAllButtons = False
            Me.DataGridViewDirectExpense_Details.Size = New System.Drawing.Size(986, 380)
            Me.DataGridViewDirectExpense_Details.TabIndex = 1
            Me.DataGridViewDirectExpense_Details.UseEmbeddedNavigator = False
            Me.DataGridViewDirectExpense_Details.ViewCaptionHeight = -1
            '
            'DataGridViewClientOOP_Details
            '
            Me.DataGridViewClientOOP_Details.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewClientOOP_Details.AllowSelectGroupHeaderRow = True
            Me.DataGridViewClientOOP_Details.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewClientOOP_Details.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewClientOOP_Details.AutoFilterLookupColumns = False
            Me.DataGridViewClientOOP_Details.AutoloadRepositoryDatasource = False
            Me.DataGridViewClientOOP_Details.AutoUpdateViewCaption = True
            Me.DataGridViewClientOOP_Details.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewClientOOP_Details.DataSource = Nothing
            Me.DataGridViewClientOOP_Details.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewClientOOP_Details.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewClientOOP_Details.ItemDescription = ""
            Me.DataGridViewClientOOP_Details.Location = New System.Drawing.Point(3, 4)
            Me.DataGridViewClientOOP_Details.MultiSelect = True
            Me.DataGridViewClientOOP_Details.Name = "DataGridViewClientOOP_Details"
            Me.DataGridViewClientOOP_Details.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewClientOOP_Details.RunStandardValidation = True
            Me.DataGridViewClientOOP_Details.ShowSelectDeselectAllButtons = False
            Me.DataGridViewClientOOP_Details.Size = New System.Drawing.Size(986, 400)
            Me.DataGridViewClientOOP_Details.TabIndex = 1
            Me.DataGridViewClientOOP_Details.UseEmbeddedNavigator = False
            Me.DataGridViewClientOOP_Details.ViewCaptionHeight = -1
            '
            'LabelControl_BudgetPeriod
            '
            Me.LabelControl_BudgetPeriod.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_BudgetPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_BudgetPeriod.Location = New System.Drawing.Point(0, 103)
            Me.LabelControl_BudgetPeriod.Name = "LabelControl_BudgetPeriod"
            Me.LabelControl_BudgetPeriod.Size = New System.Drawing.Size(81, 20)
            Me.LabelControl_BudgetPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_BudgetPeriod.TabIndex = 127
            Me.LabelControl_BudgetPeriod.Text = "Budget Date:"
            '
            'TextBox4
            '
            Me.TextBox4.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBox4.Border.Class = "TextBoxBorder"
            Me.TextBox4.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBox4.CheckSpellingOnValidate = False
            Me.TextBox4.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBox4.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBox4.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBox4.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBox4.FocusHighlightEnabled = True
            Me.TextBox4.ForeColor = System.Drawing.Color.Black
            Me.TextBox4.Location = New System.Drawing.Point(87, 103)
            Me.TextBox4.MaxFileSize = CType(0, Long)
            Me.TextBox4.Name = "TextBox4"
            Me.TextBox4.ReadOnly = True
            Me.TextBox4.SecurityEnabled = True
            Me.TextBox4.ShowSpellCheckCompleteMessage = True
            Me.TextBox4.Size = New System.Drawing.Size(262, 20)
            Me.TextBox4.StartingFolderName = Nothing
            Me.TextBox4.TabIndex = 128
            Me.TextBox4.TabOnEnter = True
            Me.TextBox4.TabStop = False
            '
            'ClientBudgetControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.AutoScroll = True
            Me.Controls.Add(Me.PanelControl_DistributionTabs)
            Me.Name = "ClientBudgetControl"
            Me.Size = New System.Drawing.Size(992, 615)
            CType(Me.TabControlControl_BudgetDetails, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlControl_BudgetDetails.ResumeLayout(False)
            Me.TabControlPanelBillingIncomeSummary_Details.ResumeLayout(False)
            Me.PanelControl_DistributionTabs.ResumeLayout(False)
            CType(Me.DateTimePickerControl_BudgetDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PanelControl_Revision, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelControl_Revision.ResumeLayout(False)
            CType(Me.SearchableComboBoxControl_Employee.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewControl_Vendor, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelFee_Details.ResumeLayout(False)
            Me.TabControlPanelTime_Details.ResumeLayout(False)
            Me.TabControlPanelDSC_Details.ResumeLayout(False)
            Me.TabControlPanelCommission_Details.ResumeLayout(False)
            Me.TabControlPanelCOS_Details.ResumeLayout(False)
            Me.TabControlPanelDirectExpense_Details.ResumeLayout(False)
            Me.TabControlPanelClientOOP_Details.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents TabControlControl_BudgetDetails As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents PanelControl_DistributionTabs As System.Windows.Forms.Panel
        Friend WithEvents TabControlPanelBillingIncomeSummary_Details As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewBillingIncomeSummary_Details As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TabItemBudgetDetails_BillingIncomeSummaryTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents LabelControl_Reference As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelControl_Code As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelControl_Employee As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxControl_Reference As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxControl_Code As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents CheckBoxForm_Inactive As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents SearchableComboBoxControl_Employee As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewControl_Vendor As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents TextBoxControl_Name As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelControl_Name As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents PanelControl_Revision As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ComboBoxRevision_ApprovedRevision As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents TextBoxRevision_CreatedBy As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelRevision_CreateUser As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelRevision_ApprovedRevision As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelRevision_Revision As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxRevision_Revision As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents TextBox3 As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelRevision_ModifyDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBox2 As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelRevision_CreateDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBox1 As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelRevision_ModifiedBy As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelControl_BudgetDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerControl_BudgetDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents TabControlPanelClientOOP_Details As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemBudgetDetails_ClientOOPTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelDirectExpense_Details As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemBudgetDetails_DirectExpenseTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelCOS_Details As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemBudgetDetails_COSTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelCommission_Details As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemBudgetDetails_CommissionTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelDSC_Details As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemBudgetDetails_DSCTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelTime_Details As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemBudgetDetails_TimeTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelFee_Details As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemBudgetDetails_FeeTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents DataGridViewClientOOP_Details As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewDirectExpense_Details As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewCOS_Details As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewCommission_Details As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewDSC_Details As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewTime_Details As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewFee_Details As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TextBox4 As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelControl_BudgetPeriod As AdvantageFramework.WinForm.Presentation.Controls.Label

    End Class

End Namespace