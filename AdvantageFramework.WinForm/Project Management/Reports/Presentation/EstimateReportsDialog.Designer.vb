Namespace ProjectManagement.Reports.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class EstimateReportsDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EstimateReportsDialog))
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Preview = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewForm_Estimates = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.LabelForm_SelectPurchaseOrders = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabControlForm_ReportOptions = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelSelectionTab_Selection = New DevComponents.DotNetBar.TabControlPanel()
            Me.Label1 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DateTimePickerDates_From = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerDates_To = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelForm_ReportFormats = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemReportOptions_SelectionTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelPrintOptionsTab_PrintOptions = New DevComponents.DotNetBar.TabControlPanel()
            Me.CheckBoxPrintOptions_VendorCode = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.ButtonPrintOptions_LocationOverride = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.SearchableComboBoxPrintOptions_Location = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewPrintOptions_Location = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.DateTimePickerPrintOptions_PrintedDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.CheckBoxPrintOptions_UsePrintedDate = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelPrintOptions_UsePrintedDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPrintOptions_Location = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPrintOptions_Options = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxPrintOptions_ExcludeEmployeeSignature = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxPrintOptions_FunctionDescription = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxPrintOptions_JobDescription = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxPrintOptions_JobNumberAndComponent = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxPrintOptions_ProductName = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxPrintOptions_ClientName = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxPrintOptions_VendorContact = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxPrintOptions_FooterComment = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxPrintOptions_DetailInstructions = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxPrintOptions_DetailDescription = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxPrintOptions_ShippingInstructions = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxPrintOptions_POInstructions = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxPrintOptions_SaveSelections = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelPrintOptions_Other = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPrintOptions_CommentOptions = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemReportOptions_PrintOptionsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.ButtonForm_Clear = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Print = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_SendEmail = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelItemDates_From = New DevComponents.DotNetBar.LabelItem()
            Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
            CType(Me.TabControlForm_ReportOptions, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_ReportOptions.SuspendLayout()
            Me.TabControlPanelSelectionTab_Selection.SuspendLayout()
            CType(Me.DateTimePickerDates_From, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerDates_To, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelPrintOptionsTab_PrintOptions.SuspendLayout()
            CType(Me.SearchableComboBoxPrintOptions_Location.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewPrintOptions_Location, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerPrintOptions_PrintedDate, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(727, 380)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 5
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ButtonForm_Preview
            '
            Me.ButtonForm_Preview.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Preview.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Preview.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Preview.Location = New System.Drawing.Point(646, 380)
            Me.ButtonForm_Preview.Name = "ButtonForm_Preview"
            Me.ButtonForm_Preview.SecurityEnabled = True
            Me.ButtonForm_Preview.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Preview.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Preview.TabIndex = 4
            Me.ButtonForm_Preview.Text = "Preview"
            '
            'DataGridViewForm_Estimates
            '
            Me.DataGridViewForm_Estimates.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_Estimates.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_Estimates.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_Estimates.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_Estimates.AutoFilterLookupColumns = False
            Me.DataGridViewForm_Estimates.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_Estimates.AutoUpdateViewCaption = True
            Me.DataGridViewForm_Estimates.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.[Default]
            Me.DataGridViewForm_Estimates.DataSource = Nothing
            Me.DataGridViewForm_Estimates.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_Estimates.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_Estimates.ItemDescription = ""
            Me.DataGridViewForm_Estimates.Location = New System.Drawing.Point(237, 30)
            Me.DataGridViewForm_Estimates.MultiSelect = False
            Me.DataGridViewForm_Estimates.Name = "DataGridViewForm_Estimates"
            Me.DataGridViewForm_Estimates.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_Estimates.RunStandardValidation = True
            Me.DataGridViewForm_Estimates.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_Estimates.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_Estimates.Size = New System.Drawing.Size(549, 301)
            Me.DataGridViewForm_Estimates.TabIndex = 3
            Me.DataGridViewForm_Estimates.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Estimates.ViewCaptionHeight = -1
            '
            'LabelForm_SelectPurchaseOrders
            '
            Me.LabelForm_SelectPurchaseOrders.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_SelectPurchaseOrders.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_SelectPurchaseOrders.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_SelectPurchaseOrders.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_SelectPurchaseOrders.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelForm_SelectPurchaseOrders.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_SelectPurchaseOrders.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_SelectPurchaseOrders.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_SelectPurchaseOrders.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_SelectPurchaseOrders.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelForm_SelectPurchaseOrders.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_SelectPurchaseOrders.Location = New System.Drawing.Point(237, 4)
            Me.LabelForm_SelectPurchaseOrders.Name = "LabelForm_SelectPurchaseOrders"
            Me.LabelForm_SelectPurchaseOrders.Size = New System.Drawing.Size(549, 20)
            Me.LabelForm_SelectPurchaseOrders.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_SelectPurchaseOrders.TabIndex = 2
            Me.LabelForm_SelectPurchaseOrders.Text = "Select Estimate(s)"
            '
            'TabControlForm_ReportOptions
            '
            Me.TabControlForm_ReportOptions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlForm_ReportOptions.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.TabControlForm_ReportOptions.CanReorderTabs = True
            Me.TabControlForm_ReportOptions.Controls.Add(Me.TabControlPanelSelectionTab_Selection)
            Me.TabControlForm_ReportOptions.Controls.Add(Me.TabControlPanelPrintOptionsTab_PrintOptions)
            Me.TabControlForm_ReportOptions.Location = New System.Drawing.Point(12, 12)
            Me.TabControlForm_ReportOptions.Name = "TabControlForm_ReportOptions"
            Me.TabControlForm_ReportOptions.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_ReportOptions.SelectedTabIndex = 0
            Me.TabControlForm_ReportOptions.Size = New System.Drawing.Size(790, 362)
            Me.TabControlForm_ReportOptions.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_ReportOptions.TabIndex = 0
            Me.TabControlForm_ReportOptions.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_ReportOptions.Tabs.Add(Me.TabItemReportOptions_SelectionTab)
            Me.TabControlForm_ReportOptions.Tabs.Add(Me.TabItemReportOptions_PrintOptionsTab)
            Me.TabControlForm_ReportOptions.Text = "TabControl1"
            '
            'TabControlPanelSelectionTab_Selection
            '
            Me.TabControlPanelSelectionTab_Selection.Controls.Add(Me.Label1)
            Me.TabControlPanelSelectionTab_Selection.Controls.Add(Me.DateTimePickerDates_From)
            Me.TabControlPanelSelectionTab_Selection.Controls.Add(Me.DateTimePickerDates_To)
            Me.TabControlPanelSelectionTab_Selection.Controls.Add(Me.LabelForm_ReportFormats)
            Me.TabControlPanelSelectionTab_Selection.Controls.Add(Me.DataGridViewForm_Estimates)
            Me.TabControlPanelSelectionTab_Selection.Controls.Add(Me.LabelForm_SelectPurchaseOrders)
            Me.TabControlPanelSelectionTab_Selection.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSelectionTab_Selection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSelectionTab_Selection.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelSelectionTab_Selection.Name = "TabControlPanelSelectionTab_Selection"
            Me.TabControlPanelSelectionTab_Selection.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSelectionTab_Selection.Size = New System.Drawing.Size(790, 335)
            Me.TabControlPanelSelectionTab_Selection.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSelectionTab_Selection.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSelectionTab_Selection.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSelectionTab_Selection.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSelectionTab_Selection.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSelectionTab_Selection.Style.GradientAngle = 90
            Me.TabControlPanelSelectionTab_Selection.TabIndex = 1
            Me.TabControlPanelSelectionTab_Selection.TabItem = Me.TabItemReportOptions_SelectionTab
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.Label1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label1.Location = New System.Drawing.Point(5, 30)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(75, 23)
            Me.Label1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label1.TabIndex = 7
            Me.Label1.Text = "From:"
            '
            'DateTimePickerDates_From
            '
            Me.DateTimePickerDates_From.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerDates_From.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerDates_From.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDates_From.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerDates_From.ButtonDropDown.Visible = True
            Me.DateTimePickerDates_From.ButtonFreeText.Checked = True
            Me.DateTimePickerDates_From.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerDates_From.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerDates_From.DisplayName = ""
            Me.DateTimePickerDates_From.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerDates_From.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerDates_From.FocusHighlightEnabled = True
            Me.DateTimePickerDates_From.FreeTextEntryMode = True
            Me.DateTimePickerDates_From.IsPopupCalendarOpen = False
            Me.DateTimePickerDates_From.Location = New System.Drawing.Point(102, 30)
            Me.DateTimePickerDates_From.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerDates_From.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerDates_From.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDates_From.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerDates_From.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerDates_From.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerDates_From.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerDates_From.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerDates_From.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerDates_From.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerDates_From.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerDates_From.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDates_From.MonthCalendar.DisplayMonth = New Date(2013, 9, 1, 0, 0, 0, 0)
            Me.DateTimePickerDates_From.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerDates_From.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerDates_From.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerDates_From.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerDates_From.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerDates_From.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDates_From.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerDates_From.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerDates_From.Name = "DateTimePickerDates_From"
            Me.DateTimePickerDates_From.ReadOnly = False
            Me.DateTimePickerDates_From.Size = New System.Drawing.Size(80, 20)
            Me.DateTimePickerDates_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerDates_From.TabIndex = 5
            Me.DateTimePickerDates_From.Value = New Date(2013, 9, 10, 16, 52, 5, 0)
            '
            'DateTimePickerDates_To
            '
            Me.DateTimePickerDates_To.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerDates_To.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerDates_To.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDates_To.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerDates_To.ButtonDropDown.Visible = True
            Me.DateTimePickerDates_To.ButtonFreeText.Checked = True
            Me.DateTimePickerDates_To.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerDates_To.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerDates_To.DisplayName = ""
            Me.DateTimePickerDates_To.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerDates_To.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerDates_To.FocusHighlightEnabled = True
            Me.DateTimePickerDates_To.FreeTextEntryMode = True
            Me.DateTimePickerDates_To.IsPopupCalendarOpen = False
            Me.DateTimePickerDates_To.Location = New System.Drawing.Point(102, 53)
            Me.DateTimePickerDates_To.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerDates_To.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerDates_To.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDates_To.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerDates_To.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerDates_To.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerDates_To.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerDates_To.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerDates_To.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerDates_To.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerDates_To.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerDates_To.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDates_To.MonthCalendar.DisplayMonth = New Date(2013, 9, 1, 0, 0, 0, 0)
            Me.DateTimePickerDates_To.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerDates_To.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerDates_To.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerDates_To.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerDates_To.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerDates_To.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDates_To.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerDates_To.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerDates_To.Name = "DateTimePickerDates_To"
            Me.DateTimePickerDates_To.ReadOnly = False
            Me.DateTimePickerDates_To.Size = New System.Drawing.Size(80, 20)
            Me.DateTimePickerDates_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerDates_To.TabIndex = 6
            Me.DateTimePickerDates_To.Value = New Date(2013, 9, 10, 16, 52, 5, 0)
            '
            'LabelForm_ReportFormats
            '
            Me.LabelForm_ReportFormats.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_ReportFormats.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_ReportFormats.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_ReportFormats.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelForm_ReportFormats.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_ReportFormats.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_ReportFormats.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_ReportFormats.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_ReportFormats.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelForm_ReportFormats.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_ReportFormats.Location = New System.Drawing.Point(4, 4)
            Me.LabelForm_ReportFormats.Name = "LabelForm_ReportFormats"
            Me.LabelForm_ReportFormats.Size = New System.Drawing.Size(227, 20)
            Me.LabelForm_ReportFormats.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ReportFormats.TabIndex = 0
            Me.LabelForm_ReportFormats.Text = "Filter Options"
            '
            'TabItemReportOptions_SelectionTab
            '
            Me.TabItemReportOptions_SelectionTab.AttachedControl = Me.TabControlPanelSelectionTab_Selection
            Me.TabItemReportOptions_SelectionTab.Name = "TabItemReportOptions_SelectionTab"
            Me.TabItemReportOptions_SelectionTab.Text = "Selection"
            '
            'TabControlPanelPrintOptionsTab_PrintOptions
            '
            Me.TabControlPanelPrintOptionsTab_PrintOptions.Controls.Add(Me.CheckBoxPrintOptions_VendorCode)
            Me.TabControlPanelPrintOptionsTab_PrintOptions.Controls.Add(Me.ButtonPrintOptions_LocationOverride)
            Me.TabControlPanelPrintOptionsTab_PrintOptions.Controls.Add(Me.SearchableComboBoxPrintOptions_Location)
            Me.TabControlPanelPrintOptionsTab_PrintOptions.Controls.Add(Me.DateTimePickerPrintOptions_PrintedDate)
            Me.TabControlPanelPrintOptionsTab_PrintOptions.Controls.Add(Me.CheckBoxPrintOptions_UsePrintedDate)
            Me.TabControlPanelPrintOptionsTab_PrintOptions.Controls.Add(Me.LabelPrintOptions_UsePrintedDate)
            Me.TabControlPanelPrintOptionsTab_PrintOptions.Controls.Add(Me.LabelPrintOptions_Location)
            Me.TabControlPanelPrintOptionsTab_PrintOptions.Controls.Add(Me.LabelPrintOptions_Options)
            Me.TabControlPanelPrintOptionsTab_PrintOptions.Controls.Add(Me.CheckBoxPrintOptions_ExcludeEmployeeSignature)
            Me.TabControlPanelPrintOptionsTab_PrintOptions.Controls.Add(Me.CheckBoxPrintOptions_FunctionDescription)
            Me.TabControlPanelPrintOptionsTab_PrintOptions.Controls.Add(Me.CheckBoxPrintOptions_JobDescription)
            Me.TabControlPanelPrintOptionsTab_PrintOptions.Controls.Add(Me.CheckBoxPrintOptions_JobNumberAndComponent)
            Me.TabControlPanelPrintOptionsTab_PrintOptions.Controls.Add(Me.CheckBoxPrintOptions_ProductName)
            Me.TabControlPanelPrintOptionsTab_PrintOptions.Controls.Add(Me.CheckBoxPrintOptions_ClientName)
            Me.TabControlPanelPrintOptionsTab_PrintOptions.Controls.Add(Me.CheckBoxPrintOptions_VendorContact)
            Me.TabControlPanelPrintOptionsTab_PrintOptions.Controls.Add(Me.CheckBoxPrintOptions_FooterComment)
            Me.TabControlPanelPrintOptionsTab_PrintOptions.Controls.Add(Me.CheckBoxPrintOptions_DetailInstructions)
            Me.TabControlPanelPrintOptionsTab_PrintOptions.Controls.Add(Me.CheckBoxPrintOptions_DetailDescription)
            Me.TabControlPanelPrintOptionsTab_PrintOptions.Controls.Add(Me.CheckBoxPrintOptions_ShippingInstructions)
            Me.TabControlPanelPrintOptionsTab_PrintOptions.Controls.Add(Me.CheckBoxPrintOptions_POInstructions)
            Me.TabControlPanelPrintOptionsTab_PrintOptions.Controls.Add(Me.CheckBoxPrintOptions_SaveSelections)
            Me.TabControlPanelPrintOptionsTab_PrintOptions.Controls.Add(Me.LabelPrintOptions_Other)
            Me.TabControlPanelPrintOptionsTab_PrintOptions.Controls.Add(Me.LabelPrintOptions_CommentOptions)
            Me.TabControlPanelPrintOptionsTab_PrintOptions.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelPrintOptionsTab_PrintOptions.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelPrintOptionsTab_PrintOptions.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelPrintOptionsTab_PrintOptions.Name = "TabControlPanelPrintOptionsTab_PrintOptions"
            Me.TabControlPanelPrintOptionsTab_PrintOptions.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelPrintOptionsTab_PrintOptions.Size = New System.Drawing.Size(790, 335)
            Me.TabControlPanelPrintOptionsTab_PrintOptions.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelPrintOptionsTab_PrintOptions.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelPrintOptionsTab_PrintOptions.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelPrintOptionsTab_PrintOptions.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelPrintOptionsTab_PrintOptions.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelPrintOptionsTab_PrintOptions.Style.GradientAngle = 90
            Me.TabControlPanelPrintOptionsTab_PrintOptions.TabIndex = 2
            Me.TabControlPanelPrintOptionsTab_PrintOptions.TabItem = Me.TabItemReportOptions_PrintOptionsTab
            '
            'CheckBoxPrintOptions_VendorCode
            '
            Me.CheckBoxPrintOptions_VendorCode.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxPrintOptions_VendorCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxPrintOptions_VendorCode.CheckValue = 0
            Me.CheckBoxPrintOptions_VendorCode.CheckValueChecked = 1
            Me.CheckBoxPrintOptions_VendorCode.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxPrintOptions_VendorCode.CheckValueUnchecked = 0
            Me.CheckBoxPrintOptions_VendorCode.ChildControls = CType(resources.GetObject("CheckBoxPrintOptions_VendorCode.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxPrintOptions_VendorCode.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxPrintOptions_VendorCode.Location = New System.Drawing.Point(600, 30)
            Me.CheckBoxPrintOptions_VendorCode.Name = "CheckBoxPrintOptions_VendorCode"
            Me.CheckBoxPrintOptions_VendorCode.OldestSibling = Nothing
            Me.CheckBoxPrintOptions_VendorCode.SecurityEnabled = True
            Me.CheckBoxPrintOptions_VendorCode.SiblingControls = CType(resources.GetObject("CheckBoxPrintOptions_VendorCode.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxPrintOptions_VendorCode.Size = New System.Drawing.Size(186, 20)
            Me.CheckBoxPrintOptions_VendorCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxPrintOptions_VendorCode.TabIndex = 17
            Me.CheckBoxPrintOptions_VendorCode.Text = "Vendor Code"
            '
            'ButtonPrintOptions_LocationOverride
            '
            Me.ButtonPrintOptions_LocationOverride.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonPrintOptions_LocationOverride.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonPrintOptions_LocationOverride.Location = New System.Drawing.Point(382, 30)
            Me.ButtonPrintOptions_LocationOverride.Name = "ButtonPrintOptions_LocationOverride"
            Me.ButtonPrintOptions_LocationOverride.SecurityEnabled = True
            Me.ButtonPrintOptions_LocationOverride.Size = New System.Drawing.Size(20, 20)
            Me.ButtonPrintOptions_LocationOverride.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonPrintOptions_LocationOverride.TabIndex = 3
            Me.ButtonPrintOptions_LocationOverride.Text = "..."
            '
            'SearchableComboBoxPrintOptions_Location
            '
            Me.SearchableComboBoxPrintOptions_Location.ActiveFilterString = ""
            Me.SearchableComboBoxPrintOptions_Location.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxPrintOptions_Location.AutoFillMode = False
            Me.SearchableComboBoxPrintOptions_Location.BookmarkingEnabled = False
            Me.SearchableComboBoxPrintOptions_Location.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Location
            Me.SearchableComboBoxPrintOptions_Location.DataSource = Nothing
            Me.SearchableComboBoxPrintOptions_Location.DisableMouseWheel = False
            Me.SearchableComboBoxPrintOptions_Location.DisplayName = ""
            Me.SearchableComboBoxPrintOptions_Location.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.None
            Me.SearchableComboBoxPrintOptions_Location.Location = New System.Drawing.Point(102, 30)
            Me.SearchableComboBoxPrintOptions_Location.Name = "SearchableComboBoxPrintOptions_Location"
            Me.SearchableComboBoxPrintOptions_Location.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxPrintOptions_Location.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxPrintOptions_Location.Properties.NullText = "Select Location"
            Me.SearchableComboBoxPrintOptions_Location.Properties.ShowClearButton = False
            Me.SearchableComboBoxPrintOptions_Location.Properties.ValueMember = "ID"
            Me.SearchableComboBoxPrintOptions_Location.Properties.View = Me.SearchableComboBoxViewPrintOptions_Location
            Me.SearchableComboBoxPrintOptions_Location.SecurityEnabled = True
            Me.SearchableComboBoxPrintOptions_Location.SelectedValue = Nothing
            Me.SearchableComboBoxPrintOptions_Location.Size = New System.Drawing.Size(274, 20)
            Me.SearchableComboBoxPrintOptions_Location.TabIndex = 2
            '
            'SearchableComboBoxViewPrintOptions_Location
            '
            Me.SearchableComboBoxViewPrintOptions_Location.AFActiveFilterString = ""
            Me.SearchableComboBoxViewPrintOptions_Location.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewPrintOptions_Location.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewPrintOptions_Location.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewPrintOptions_Location.DataSourceClearing = False
            Me.SearchableComboBoxViewPrintOptions_Location.EnableDisabledRows = False
            Me.SearchableComboBoxViewPrintOptions_Location.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewPrintOptions_Location.Name = "SearchableComboBoxViewPrintOptions_Location"
            Me.SearchableComboBoxViewPrintOptions_Location.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewPrintOptions_Location.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewPrintOptions_Location.RunStandardValidation = True
            '
            'DateTimePickerPrintOptions_PrintedDate
            '
            Me.DateTimePickerPrintOptions_PrintedDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerPrintOptions_PrintedDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerPrintOptions_PrintedDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerPrintOptions_PrintedDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerPrintOptions_PrintedDate.ButtonDropDown.Visible = True
            Me.DateTimePickerPrintOptions_PrintedDate.ButtonFreeText.Checked = True
            Me.DateTimePickerPrintOptions_PrintedDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerPrintOptions_PrintedDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerPrintOptions_PrintedDate.DisplayName = ""
            Me.DateTimePickerPrintOptions_PrintedDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerPrintOptions_PrintedDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerPrintOptions_PrintedDate.FocusHighlightEnabled = True
            Me.DateTimePickerPrintOptions_PrintedDate.FreeTextEntryMode = True
            Me.DateTimePickerPrintOptions_PrintedDate.IsPopupCalendarOpen = False
            Me.DateTimePickerPrintOptions_PrintedDate.Location = New System.Drawing.Point(128, 82)
            Me.DateTimePickerPrintOptions_PrintedDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerPrintOptions_PrintedDate.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerPrintOptions_PrintedDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerPrintOptions_PrintedDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerPrintOptions_PrintedDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerPrintOptions_PrintedDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerPrintOptions_PrintedDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerPrintOptions_PrintedDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerPrintOptions_PrintedDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerPrintOptions_PrintedDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerPrintOptions_PrintedDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerPrintOptions_PrintedDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerPrintOptions_PrintedDate.MonthCalendar.DisplayMonth = New Date(2013, 7, 1, 0, 0, 0, 0)
            Me.DateTimePickerPrintOptions_PrintedDate.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerPrintOptions_PrintedDate.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerPrintOptions_PrintedDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerPrintOptions_PrintedDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerPrintOptions_PrintedDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerPrintOptions_PrintedDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerPrintOptions_PrintedDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerPrintOptions_PrintedDate.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerPrintOptions_PrintedDate.Name = "DateTimePickerPrintOptions_PrintedDate"
            Me.DateTimePickerPrintOptions_PrintedDate.ReadOnly = False
            Me.DateTimePickerPrintOptions_PrintedDate.Size = New System.Drawing.Size(111, 20)
            Me.DateTimePickerPrintOptions_PrintedDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerPrintOptions_PrintedDate.TabIndex = 9
            Me.DateTimePickerPrintOptions_PrintedDate.Value = New Date(2013, 7, 19, 15, 41, 39, 794)
            '
            'CheckBoxPrintOptions_UsePrintedDate
            '
            Me.CheckBoxPrintOptions_UsePrintedDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxPrintOptions_UsePrintedDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxPrintOptions_UsePrintedDate.CheckValue = 0
            Me.CheckBoxPrintOptions_UsePrintedDate.CheckValueChecked = 1
            Me.CheckBoxPrintOptions_UsePrintedDate.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxPrintOptions_UsePrintedDate.CheckValueUnchecked = 0
            Me.CheckBoxPrintOptions_UsePrintedDate.ChildControls = CType(resources.GetObject("CheckBoxPrintOptions_UsePrintedDate.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxPrintOptions_UsePrintedDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxPrintOptions_UsePrintedDate.Location = New System.Drawing.Point(102, 82)
            Me.CheckBoxPrintOptions_UsePrintedDate.Name = "CheckBoxPrintOptions_UsePrintedDate"
            Me.CheckBoxPrintOptions_UsePrintedDate.OldestSibling = Nothing
            Me.CheckBoxPrintOptions_UsePrintedDate.SecurityEnabled = True
            Me.CheckBoxPrintOptions_UsePrintedDate.SiblingControls = CType(resources.GetObject("CheckBoxPrintOptions_UsePrintedDate.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxPrintOptions_UsePrintedDate.Size = New System.Drawing.Size(20, 20)
            Me.CheckBoxPrintOptions_UsePrintedDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxPrintOptions_UsePrintedDate.TabIndex = 8
            '
            'LabelPrintOptions_UsePrintedDate
            '
            Me.LabelPrintOptions_UsePrintedDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPrintOptions_UsePrintedDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPrintOptions_UsePrintedDate.Location = New System.Drawing.Point(4, 82)
            Me.LabelPrintOptions_UsePrintedDate.Name = "LabelPrintOptions_UsePrintedDate"
            Me.LabelPrintOptions_UsePrintedDate.Size = New System.Drawing.Size(92, 20)
            Me.LabelPrintOptions_UsePrintedDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPrintOptions_UsePrintedDate.TabIndex = 7
            Me.LabelPrintOptions_UsePrintedDate.Text = "Use Printed Date:"
            '
            'LabelPrintOptions_Location
            '
            Me.LabelPrintOptions_Location.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPrintOptions_Location.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPrintOptions_Location.Location = New System.Drawing.Point(4, 30)
            Me.LabelPrintOptions_Location.Name = "LabelPrintOptions_Location"
            Me.LabelPrintOptions_Location.Size = New System.Drawing.Size(92, 20)
            Me.LabelPrintOptions_Location.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPrintOptions_Location.TabIndex = 1
            Me.LabelPrintOptions_Location.Text = "Location:"
            '
            'LabelPrintOptions_Options
            '
            Me.LabelPrintOptions_Options.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPrintOptions_Options.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelPrintOptions_Options.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelPrintOptions_Options.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelPrintOptions_Options.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelPrintOptions_Options.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelPrintOptions_Options.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelPrintOptions_Options.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPrintOptions_Options.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPrintOptions_Options.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelPrintOptions_Options.Location = New System.Drawing.Point(4, 4)
            Me.LabelPrintOptions_Options.Name = "LabelPrintOptions_Options"
            Me.LabelPrintOptions_Options.Size = New System.Drawing.Size(398, 20)
            Me.LabelPrintOptions_Options.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPrintOptions_Options.TabIndex = 0
            Me.LabelPrintOptions_Options.Text = "Options"
            '
            'CheckBoxPrintOptions_ExcludeEmployeeSignature
            '
            Me.CheckBoxPrintOptions_ExcludeEmployeeSignature.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxPrintOptions_ExcludeEmployeeSignature.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxPrintOptions_ExcludeEmployeeSignature.CheckValue = 0
            Me.CheckBoxPrintOptions_ExcludeEmployeeSignature.CheckValueChecked = 1
            Me.CheckBoxPrintOptions_ExcludeEmployeeSignature.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxPrintOptions_ExcludeEmployeeSignature.CheckValueUnchecked = 0
            Me.CheckBoxPrintOptions_ExcludeEmployeeSignature.ChildControls = CType(resources.GetObject("CheckBoxPrintOptions_ExcludeEmployeeSignature.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxPrintOptions_ExcludeEmployeeSignature.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxPrintOptions_ExcludeEmployeeSignature.Location = New System.Drawing.Point(600, 212)
            Me.CheckBoxPrintOptions_ExcludeEmployeeSignature.Name = "CheckBoxPrintOptions_ExcludeEmployeeSignature"
            Me.CheckBoxPrintOptions_ExcludeEmployeeSignature.OldestSibling = Nothing
            Me.CheckBoxPrintOptions_ExcludeEmployeeSignature.SecurityEnabled = True
            Me.CheckBoxPrintOptions_ExcludeEmployeeSignature.SiblingControls = CType(resources.GetObject("CheckBoxPrintOptions_ExcludeEmployeeSignature.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxPrintOptions_ExcludeEmployeeSignature.Size = New System.Drawing.Size(186, 20)
            Me.CheckBoxPrintOptions_ExcludeEmployeeSignature.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxPrintOptions_ExcludeEmployeeSignature.TabIndex = 24
            Me.CheckBoxPrintOptions_ExcludeEmployeeSignature.Text = "Exclude Employee Signature"
            '
            'CheckBoxPrintOptions_FunctionDescription
            '
            Me.CheckBoxPrintOptions_FunctionDescription.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxPrintOptions_FunctionDescription.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxPrintOptions_FunctionDescription.CheckValue = 0
            Me.CheckBoxPrintOptions_FunctionDescription.CheckValueChecked = 1
            Me.CheckBoxPrintOptions_FunctionDescription.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxPrintOptions_FunctionDescription.CheckValueUnchecked = 0
            Me.CheckBoxPrintOptions_FunctionDescription.ChildControls = CType(resources.GetObject("CheckBoxPrintOptions_FunctionDescription.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxPrintOptions_FunctionDescription.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxPrintOptions_FunctionDescription.Location = New System.Drawing.Point(600, 186)
            Me.CheckBoxPrintOptions_FunctionDescription.Name = "CheckBoxPrintOptions_FunctionDescription"
            Me.CheckBoxPrintOptions_FunctionDescription.OldestSibling = Nothing
            Me.CheckBoxPrintOptions_FunctionDescription.SecurityEnabled = True
            Me.CheckBoxPrintOptions_FunctionDescription.SiblingControls = CType(resources.GetObject("CheckBoxPrintOptions_FunctionDescription.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxPrintOptions_FunctionDescription.Size = New System.Drawing.Size(186, 20)
            Me.CheckBoxPrintOptions_FunctionDescription.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxPrintOptions_FunctionDescription.TabIndex = 23
            Me.CheckBoxPrintOptions_FunctionDescription.Text = "Function Description"
            '
            'CheckBoxPrintOptions_JobDescription
            '
            Me.CheckBoxPrintOptions_JobDescription.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxPrintOptions_JobDescription.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxPrintOptions_JobDescription.CheckValue = 0
            Me.CheckBoxPrintOptions_JobDescription.CheckValueChecked = 1
            Me.CheckBoxPrintOptions_JobDescription.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxPrintOptions_JobDescription.CheckValueUnchecked = 0
            Me.CheckBoxPrintOptions_JobDescription.ChildControls = CType(resources.GetObject("CheckBoxPrintOptions_JobDescription.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxPrintOptions_JobDescription.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxPrintOptions_JobDescription.Location = New System.Drawing.Point(600, 160)
            Me.CheckBoxPrintOptions_JobDescription.Name = "CheckBoxPrintOptions_JobDescription"
            Me.CheckBoxPrintOptions_JobDescription.OldestSibling = Nothing
            Me.CheckBoxPrintOptions_JobDescription.SecurityEnabled = True
            Me.CheckBoxPrintOptions_JobDescription.SiblingControls = CType(resources.GetObject("CheckBoxPrintOptions_JobDescription.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxPrintOptions_JobDescription.Size = New System.Drawing.Size(186, 20)
            Me.CheckBoxPrintOptions_JobDescription.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxPrintOptions_JobDescription.TabIndex = 22
            Me.CheckBoxPrintOptions_JobDescription.Text = "Job Description"
            '
            'CheckBoxPrintOptions_JobNumberAndComponent
            '
            Me.CheckBoxPrintOptions_JobNumberAndComponent.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxPrintOptions_JobNumberAndComponent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxPrintOptions_JobNumberAndComponent.CheckValue = 0
            Me.CheckBoxPrintOptions_JobNumberAndComponent.CheckValueChecked = 1
            Me.CheckBoxPrintOptions_JobNumberAndComponent.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxPrintOptions_JobNumberAndComponent.CheckValueUnchecked = 0
            Me.CheckBoxPrintOptions_JobNumberAndComponent.ChildControls = CType(resources.GetObject("CheckBoxPrintOptions_JobNumberAndComponent.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxPrintOptions_JobNumberAndComponent.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxPrintOptions_JobNumberAndComponent.Location = New System.Drawing.Point(600, 134)
            Me.CheckBoxPrintOptions_JobNumberAndComponent.Name = "CheckBoxPrintOptions_JobNumberAndComponent"
            Me.CheckBoxPrintOptions_JobNumberAndComponent.OldestSibling = Nothing
            Me.CheckBoxPrintOptions_JobNumberAndComponent.SecurityEnabled = True
            Me.CheckBoxPrintOptions_JobNumberAndComponent.SiblingControls = CType(resources.GetObject("CheckBoxPrintOptions_JobNumberAndComponent.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxPrintOptions_JobNumberAndComponent.Size = New System.Drawing.Size(186, 20)
            Me.CheckBoxPrintOptions_JobNumberAndComponent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxPrintOptions_JobNumberAndComponent.TabIndex = 21
            Me.CheckBoxPrintOptions_JobNumberAndComponent.Text = "Job Number / Component"
            '
            'CheckBoxPrintOptions_ProductName
            '
            Me.CheckBoxPrintOptions_ProductName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxPrintOptions_ProductName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxPrintOptions_ProductName.CheckValue = 0
            Me.CheckBoxPrintOptions_ProductName.CheckValueChecked = 1
            Me.CheckBoxPrintOptions_ProductName.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxPrintOptions_ProductName.CheckValueUnchecked = 0
            Me.CheckBoxPrintOptions_ProductName.ChildControls = CType(resources.GetObject("CheckBoxPrintOptions_ProductName.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxPrintOptions_ProductName.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxPrintOptions_ProductName.Location = New System.Drawing.Point(600, 108)
            Me.CheckBoxPrintOptions_ProductName.Name = "CheckBoxPrintOptions_ProductName"
            Me.CheckBoxPrintOptions_ProductName.OldestSibling = Nothing
            Me.CheckBoxPrintOptions_ProductName.SecurityEnabled = True
            Me.CheckBoxPrintOptions_ProductName.SiblingControls = CType(resources.GetObject("CheckBoxPrintOptions_ProductName.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxPrintOptions_ProductName.Size = New System.Drawing.Size(186, 20)
            Me.CheckBoxPrintOptions_ProductName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxPrintOptions_ProductName.TabIndex = 20
            Me.CheckBoxPrintOptions_ProductName.Text = "Product Name"
            '
            'CheckBoxPrintOptions_ClientName
            '
            Me.CheckBoxPrintOptions_ClientName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxPrintOptions_ClientName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxPrintOptions_ClientName.CheckValue = 0
            Me.CheckBoxPrintOptions_ClientName.CheckValueChecked = 1
            Me.CheckBoxPrintOptions_ClientName.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxPrintOptions_ClientName.CheckValueUnchecked = 0
            Me.CheckBoxPrintOptions_ClientName.ChildControls = CType(resources.GetObject("CheckBoxPrintOptions_ClientName.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxPrintOptions_ClientName.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxPrintOptions_ClientName.Location = New System.Drawing.Point(600, 82)
            Me.CheckBoxPrintOptions_ClientName.Name = "CheckBoxPrintOptions_ClientName"
            Me.CheckBoxPrintOptions_ClientName.OldestSibling = Nothing
            Me.CheckBoxPrintOptions_ClientName.SecurityEnabled = True
            Me.CheckBoxPrintOptions_ClientName.SiblingControls = CType(resources.GetObject("CheckBoxPrintOptions_ClientName.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxPrintOptions_ClientName.Size = New System.Drawing.Size(186, 20)
            Me.CheckBoxPrintOptions_ClientName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxPrintOptions_ClientName.TabIndex = 19
            Me.CheckBoxPrintOptions_ClientName.Text = "Client Name"
            '
            'CheckBoxPrintOptions_VendorContact
            '
            Me.CheckBoxPrintOptions_VendorContact.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxPrintOptions_VendorContact.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxPrintOptions_VendorContact.CheckValue = 0
            Me.CheckBoxPrintOptions_VendorContact.CheckValueChecked = 1
            Me.CheckBoxPrintOptions_VendorContact.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxPrintOptions_VendorContact.CheckValueUnchecked = 0
            Me.CheckBoxPrintOptions_VendorContact.ChildControls = CType(resources.GetObject("CheckBoxPrintOptions_VendorContact.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxPrintOptions_VendorContact.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxPrintOptions_VendorContact.Location = New System.Drawing.Point(600, 56)
            Me.CheckBoxPrintOptions_VendorContact.Name = "CheckBoxPrintOptions_VendorContact"
            Me.CheckBoxPrintOptions_VendorContact.OldestSibling = Nothing
            Me.CheckBoxPrintOptions_VendorContact.SecurityEnabled = True
            Me.CheckBoxPrintOptions_VendorContact.SiblingControls = CType(resources.GetObject("CheckBoxPrintOptions_VendorContact.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxPrintOptions_VendorContact.Size = New System.Drawing.Size(186, 20)
            Me.CheckBoxPrintOptions_VendorContact.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxPrintOptions_VendorContact.TabIndex = 18
            Me.CheckBoxPrintOptions_VendorContact.Text = "Vendor Contact"
            '
            'CheckBoxPrintOptions_FooterComment
            '
            Me.CheckBoxPrintOptions_FooterComment.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxPrintOptions_FooterComment.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxPrintOptions_FooterComment.CheckValue = 0
            Me.CheckBoxPrintOptions_FooterComment.CheckValueChecked = 1
            Me.CheckBoxPrintOptions_FooterComment.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxPrintOptions_FooterComment.CheckValueUnchecked = 0
            Me.CheckBoxPrintOptions_FooterComment.ChildControls = CType(resources.GetObject("CheckBoxPrintOptions_FooterComment.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxPrintOptions_FooterComment.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxPrintOptions_FooterComment.Location = New System.Drawing.Point(408, 134)
            Me.CheckBoxPrintOptions_FooterComment.Name = "CheckBoxPrintOptions_FooterComment"
            Me.CheckBoxPrintOptions_FooterComment.OldestSibling = Nothing
            Me.CheckBoxPrintOptions_FooterComment.SecurityEnabled = True
            Me.CheckBoxPrintOptions_FooterComment.SiblingControls = CType(resources.GetObject("CheckBoxPrintOptions_FooterComment.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxPrintOptions_FooterComment.Size = New System.Drawing.Size(186, 20)
            Me.CheckBoxPrintOptions_FooterComment.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxPrintOptions_FooterComment.TabIndex = 15
            Me.CheckBoxPrintOptions_FooterComment.Text = "Footer Comment"
            '
            'CheckBoxPrintOptions_DetailInstructions
            '
            Me.CheckBoxPrintOptions_DetailInstructions.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxPrintOptions_DetailInstructions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxPrintOptions_DetailInstructions.CheckValue = 0
            Me.CheckBoxPrintOptions_DetailInstructions.CheckValueChecked = 1
            Me.CheckBoxPrintOptions_DetailInstructions.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxPrintOptions_DetailInstructions.CheckValueUnchecked = 0
            Me.CheckBoxPrintOptions_DetailInstructions.ChildControls = CType(resources.GetObject("CheckBoxPrintOptions_DetailInstructions.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxPrintOptions_DetailInstructions.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxPrintOptions_DetailInstructions.Location = New System.Drawing.Point(408, 108)
            Me.CheckBoxPrintOptions_DetailInstructions.Name = "CheckBoxPrintOptions_DetailInstructions"
            Me.CheckBoxPrintOptions_DetailInstructions.OldestSibling = Nothing
            Me.CheckBoxPrintOptions_DetailInstructions.SecurityEnabled = True
            Me.CheckBoxPrintOptions_DetailInstructions.SiblingControls = CType(resources.GetObject("CheckBoxPrintOptions_DetailInstructions.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxPrintOptions_DetailInstructions.Size = New System.Drawing.Size(186, 20)
            Me.CheckBoxPrintOptions_DetailInstructions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxPrintOptions_DetailInstructions.TabIndex = 14
            Me.CheckBoxPrintOptions_DetailInstructions.Text = "Detail Instructions"
            '
            'CheckBoxPrintOptions_DetailDescription
            '
            Me.CheckBoxPrintOptions_DetailDescription.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxPrintOptions_DetailDescription.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxPrintOptions_DetailDescription.CheckValue = 0
            Me.CheckBoxPrintOptions_DetailDescription.CheckValueChecked = 1
            Me.CheckBoxPrintOptions_DetailDescription.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxPrintOptions_DetailDescription.CheckValueUnchecked = 0
            Me.CheckBoxPrintOptions_DetailDescription.ChildControls = CType(resources.GetObject("CheckBoxPrintOptions_DetailDescription.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxPrintOptions_DetailDescription.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxPrintOptions_DetailDescription.Location = New System.Drawing.Point(408, 82)
            Me.CheckBoxPrintOptions_DetailDescription.Name = "CheckBoxPrintOptions_DetailDescription"
            Me.CheckBoxPrintOptions_DetailDescription.OldestSibling = Nothing
            Me.CheckBoxPrintOptions_DetailDescription.SecurityEnabled = True
            Me.CheckBoxPrintOptions_DetailDescription.SiblingControls = CType(resources.GetObject("CheckBoxPrintOptions_DetailDescription.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxPrintOptions_DetailDescription.Size = New System.Drawing.Size(186, 20)
            Me.CheckBoxPrintOptions_DetailDescription.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxPrintOptions_DetailDescription.TabIndex = 13
            Me.CheckBoxPrintOptions_DetailDescription.Text = "Detail Description"
            '
            'CheckBoxPrintOptions_ShippingInstructions
            '
            Me.CheckBoxPrintOptions_ShippingInstructions.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxPrintOptions_ShippingInstructions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxPrintOptions_ShippingInstructions.CheckValue = 0
            Me.CheckBoxPrintOptions_ShippingInstructions.CheckValueChecked = 1
            Me.CheckBoxPrintOptions_ShippingInstructions.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxPrintOptions_ShippingInstructions.CheckValueUnchecked = 0
            Me.CheckBoxPrintOptions_ShippingInstructions.ChildControls = CType(resources.GetObject("CheckBoxPrintOptions_ShippingInstructions.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxPrintOptions_ShippingInstructions.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxPrintOptions_ShippingInstructions.Location = New System.Drawing.Point(408, 56)
            Me.CheckBoxPrintOptions_ShippingInstructions.Name = "CheckBoxPrintOptions_ShippingInstructions"
            Me.CheckBoxPrintOptions_ShippingInstructions.OldestSibling = Nothing
            Me.CheckBoxPrintOptions_ShippingInstructions.SecurityEnabled = True
            Me.CheckBoxPrintOptions_ShippingInstructions.SiblingControls = CType(resources.GetObject("CheckBoxPrintOptions_ShippingInstructions.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxPrintOptions_ShippingInstructions.Size = New System.Drawing.Size(186, 20)
            Me.CheckBoxPrintOptions_ShippingInstructions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxPrintOptions_ShippingInstructions.TabIndex = 12
            Me.CheckBoxPrintOptions_ShippingInstructions.Text = "Shipping Instructions"
            '
            'CheckBoxPrintOptions_POInstructions
            '
            Me.CheckBoxPrintOptions_POInstructions.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxPrintOptions_POInstructions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxPrintOptions_POInstructions.CheckValue = 0
            Me.CheckBoxPrintOptions_POInstructions.CheckValueChecked = 1
            Me.CheckBoxPrintOptions_POInstructions.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxPrintOptions_POInstructions.CheckValueUnchecked = 0
            Me.CheckBoxPrintOptions_POInstructions.ChildControls = CType(resources.GetObject("CheckBoxPrintOptions_POInstructions.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxPrintOptions_POInstructions.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxPrintOptions_POInstructions.Location = New System.Drawing.Point(408, 30)
            Me.CheckBoxPrintOptions_POInstructions.Name = "CheckBoxPrintOptions_POInstructions"
            Me.CheckBoxPrintOptions_POInstructions.OldestSibling = Nothing
            Me.CheckBoxPrintOptions_POInstructions.SecurityEnabled = True
            Me.CheckBoxPrintOptions_POInstructions.SiblingControls = CType(resources.GetObject("CheckBoxPrintOptions_POInstructions.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxPrintOptions_POInstructions.Size = New System.Drawing.Size(186, 20)
            Me.CheckBoxPrintOptions_POInstructions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxPrintOptions_POInstructions.TabIndex = 11
            Me.CheckBoxPrintOptions_POInstructions.Text = "PO Instructions"
            '
            'CheckBoxPrintOptions_SaveSelections
            '
            Me.CheckBoxPrintOptions_SaveSelections.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxPrintOptions_SaveSelections.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxPrintOptions_SaveSelections.CheckValue = 0
            Me.CheckBoxPrintOptions_SaveSelections.CheckValueChecked = 1
            Me.CheckBoxPrintOptions_SaveSelections.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxPrintOptions_SaveSelections.CheckValueUnchecked = 0
            Me.CheckBoxPrintOptions_SaveSelections.ChildControls = CType(resources.GetObject("CheckBoxPrintOptions_SaveSelections.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxPrintOptions_SaveSelections.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxPrintOptions_SaveSelections.Location = New System.Drawing.Point(102, 56)
            Me.CheckBoxPrintOptions_SaveSelections.Name = "CheckBoxPrintOptions_SaveSelections"
            Me.CheckBoxPrintOptions_SaveSelections.OldestSibling = Nothing
            Me.CheckBoxPrintOptions_SaveSelections.SecurityEnabled = True
            Me.CheckBoxPrintOptions_SaveSelections.SiblingControls = CType(resources.GetObject("CheckBoxPrintOptions_SaveSelections.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxPrintOptions_SaveSelections.Size = New System.Drawing.Size(300, 20)
            Me.CheckBoxPrintOptions_SaveSelections.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxPrintOptions_SaveSelections.TabIndex = 6
            Me.CheckBoxPrintOptions_SaveSelections.Text = "Save Selections as Defaults"
            '
            'LabelPrintOptions_Other
            '
            Me.LabelPrintOptions_Other.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPrintOptions_Other.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelPrintOptions_Other.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelPrintOptions_Other.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelPrintOptions_Other.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelPrintOptions_Other.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelPrintOptions_Other.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelPrintOptions_Other.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPrintOptions_Other.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPrintOptions_Other.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelPrintOptions_Other.Location = New System.Drawing.Point(600, 4)
            Me.LabelPrintOptions_Other.Name = "LabelPrintOptions_Other"
            Me.LabelPrintOptions_Other.Size = New System.Drawing.Size(186, 20)
            Me.LabelPrintOptions_Other.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPrintOptions_Other.TabIndex = 16
            Me.LabelPrintOptions_Other.Text = "Other"
            '
            'LabelPrintOptions_CommentOptions
            '
            Me.LabelPrintOptions_CommentOptions.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPrintOptions_CommentOptions.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelPrintOptions_CommentOptions.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelPrintOptions_CommentOptions.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelPrintOptions_CommentOptions.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelPrintOptions_CommentOptions.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelPrintOptions_CommentOptions.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelPrintOptions_CommentOptions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPrintOptions_CommentOptions.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPrintOptions_CommentOptions.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelPrintOptions_CommentOptions.Location = New System.Drawing.Point(408, 4)
            Me.LabelPrintOptions_CommentOptions.Name = "LabelPrintOptions_CommentOptions"
            Me.LabelPrintOptions_CommentOptions.Size = New System.Drawing.Size(186, 20)
            Me.LabelPrintOptions_CommentOptions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPrintOptions_CommentOptions.TabIndex = 10
            Me.LabelPrintOptions_CommentOptions.Text = "Comment Options"
            '
            'TabItemReportOptions_PrintOptionsTab
            '
            Me.TabItemReportOptions_PrintOptionsTab.AttachedControl = Me.TabControlPanelPrintOptionsTab_PrintOptions
            Me.TabItemReportOptions_PrintOptionsTab.Name = "TabItemReportOptions_PrintOptionsTab"
            Me.TabItemReportOptions_PrintOptionsTab.Text = "Print Options"
            Me.TabItemReportOptions_PrintOptionsTab.Visible = False
            '
            'ButtonForm_Clear
            '
            Me.ButtonForm_Clear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Clear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Clear.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Clear.Location = New System.Drawing.Point(403, 380)
            Me.ButtonForm_Clear.Name = "ButtonForm_Clear"
            Me.ButtonForm_Clear.SecurityEnabled = True
            Me.ButtonForm_Clear.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Clear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Clear.TabIndex = 1
            Me.ButtonForm_Clear.Text = "Clear"
            '
            'ButtonForm_Print
            '
            Me.ButtonForm_Print.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Print.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Print.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Print.Location = New System.Drawing.Point(565, 380)
            Me.ButtonForm_Print.Name = "ButtonForm_Print"
            Me.ButtonForm_Print.SecurityEnabled = True
            Me.ButtonForm_Print.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Print.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Print.TabIndex = 3
            Me.ButtonForm_Print.Text = "Print"
            '
            'ButtonForm_SendEmail
            '
            Me.ButtonForm_SendEmail.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_SendEmail.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_SendEmail.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_SendEmail.Location = New System.Drawing.Point(484, 380)
            Me.ButtonForm_SendEmail.Name = "ButtonForm_SendEmail"
            Me.ButtonForm_SendEmail.SecurityEnabled = True
            Me.ButtonForm_SendEmail.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_SendEmail.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_SendEmail.TabIndex = 2
            Me.ButtonForm_SendEmail.Text = "Send E-mail"
            '
            'LabelItemDates_From
            '
            Me.LabelItemDates_From.Name = "LabelItemDates_From"
            Me.LabelItemDates_From.Text = "From:"
            Me.LabelItemDates_From.Width = 50
            '
            'LabelItem1
            '
            Me.LabelItem1.Name = "LabelItem1"
            Me.LabelItem1.Text = "From:"
            Me.LabelItem1.Width = 50
            '
            'EstimateReportsDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(814, 412)
            Me.Controls.Add(Me.ButtonForm_SendEmail)
            Me.Controls.Add(Me.ButtonForm_Print)
            Me.Controls.Add(Me.ButtonForm_Clear)
            Me.Controls.Add(Me.TabControlForm_ReportOptions)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.ButtonForm_Preview)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "EstimateReportsDialog"
            Me.Text = "Estimate Reports"
            CType(Me.TabControlForm_ReportOptions, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_ReportOptions.ResumeLayout(False)
            Me.TabControlPanelSelectionTab_Selection.ResumeLayout(False)
            CType(Me.DateTimePickerDates_From, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerDates_To, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelPrintOptionsTab_PrintOptions.ResumeLayout(False)
            CType(Me.SearchableComboBoxPrintOptions_Location.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewPrintOptions_Location, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerPrintOptions_PrintedDate, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewForm_Estimates As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents SearchableComboBoxPrintOptions_Location As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewPrintOptions_Location As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Private WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Private WithEvents ButtonForm_Preview As AdvantageFramework.WinForm.Presentation.Controls.Button
        Private WithEvents LabelForm_SelectPurchaseOrders As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents TabControlForm_ReportOptions As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Private WithEvents TabControlPanelSelectionTab_Selection As DevComponents.DotNetBar.TabControlPanel
        Private WithEvents TabItemReportOptions_SelectionTab As DevComponents.DotNetBar.TabItem
        Private WithEvents TabControlPanelPrintOptionsTab_PrintOptions As DevComponents.DotNetBar.TabControlPanel
        Private WithEvents TabItemReportOptions_PrintOptionsTab As DevComponents.DotNetBar.TabItem
        Private WithEvents LabelPrintOptions_Other As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelPrintOptions_CommentOptions As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents ButtonPrintOptions_LocationOverride As AdvantageFramework.WinForm.Presentation.Controls.Button
        Private WithEvents DateTimePickerPrintOptions_PrintedDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Private WithEvents CheckBoxPrintOptions_UsePrintedDate As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Private WithEvents LabelPrintOptions_UsePrintedDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelPrintOptions_Location As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelPrintOptions_Options As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents CheckBoxPrintOptions_ExcludeEmployeeSignature As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Private WithEvents CheckBoxPrintOptions_FunctionDescription As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Private WithEvents CheckBoxPrintOptions_JobDescription As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Private WithEvents CheckBoxPrintOptions_JobNumberAndComponent As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Private WithEvents CheckBoxPrintOptions_ProductName As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Private WithEvents CheckBoxPrintOptions_ClientName As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Private WithEvents CheckBoxPrintOptions_VendorContact As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Private WithEvents CheckBoxPrintOptions_FooterComment As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Private WithEvents CheckBoxPrintOptions_DetailInstructions As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Private WithEvents CheckBoxPrintOptions_DetailDescription As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Private WithEvents CheckBoxPrintOptions_ShippingInstructions As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Private WithEvents CheckBoxPrintOptions_POInstructions As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Private WithEvents CheckBoxPrintOptions_SaveSelections As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Private WithEvents ButtonForm_Clear As AdvantageFramework.WinForm.Presentation.Controls.Button
        Private WithEvents CheckBoxPrintOptions_VendorCode As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Private WithEvents ButtonForm_Print As AdvantageFramework.WinForm.Presentation.Controls.Button
        Private WithEvents ButtonForm_SendEmail As AdvantageFramework.WinForm.Presentation.Controls.Button
        Private WithEvents LabelForm_ReportFormats As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerDates_From As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerDates_To As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents LabelItemDates_From As DevComponents.DotNetBar.LabelItem
        Friend WithEvents Label1 As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem

    End Class

End Namespace