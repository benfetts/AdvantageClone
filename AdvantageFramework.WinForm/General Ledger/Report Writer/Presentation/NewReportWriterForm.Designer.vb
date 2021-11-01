Namespace GeneralLedger.ReportWriter.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class NewReportWriterForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NewReportWriterForm))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ComboBoxPostPeriod_PostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.TextBoxReportName_ReportName = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.DateTimePickerReportDate_ReportDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.ItemContainerActions_Report = New DevComponents.DotNetBar.ItemContainer()
            Me.ItemContainerReport_ReportName = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemReportName_ReportName = New DevComponents.DotNetBar.LabelItem()
            Me.ControlContainerItemReportName_ReportName = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ItemContainerReport_PostPeriod = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemPostPeriod_PostPeriod = New DevComponents.DotNetBar.LabelItem()
            Me.ControlContainerItemPostPeriod_PostPeriod = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ItemContainerReport_ReportDate = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemReportDate_ReportDate = New DevComponents.DotNetBar.LabelItem()
            Me.ControlContainerItemReportDate_ReportDate = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ButtonItemActions_View = New DevComponents.DotNetBar.ButtonItem()
            Me.PivotGridForm_GLReport = New AdvantageFramework.WinForm.Presentation.Controls.PivotGridControl()
            Me.RibbonBarOptions_ReportTypes = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemReportTypes_Income = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemReportTypes_BalanceSheet = New DevComponents.DotNetBar.ButtonItem()
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.RibbonBarOptions_Actions.SuspendLayout()
            CType(Me.DateTimePickerReportDate_ReportDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PivotGridForm_GLReport, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_ReportTypes)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(12, 311)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(662, 98)
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
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 1
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
            Me.RibbonBarOptions_Actions.Controls.Add(Me.ComboBoxPostPeriod_PostPeriod)
            Me.RibbonBarOptions_Actions.Controls.Add(Me.TextBoxReportName_ReportName)
            Me.RibbonBarOptions_Actions.Controls.Add(Me.DateTimePickerReportDate_ReportDate)
            Me.RibbonBarOptions_Actions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerActions_Report, Me.ButtonItemActions_View})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(359, 98)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 1
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
            'ComboBoxPostPeriod_PostPeriod
            '
            Me.ComboBoxPostPeriod_PostPeriod.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxPostPeriod_PostPeriod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxPostPeriod_PostPeriod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxPostPeriod_PostPeriod.AutoSelectSingleItemDatasource = False
            Me.ComboBoxPostPeriod_PostPeriod.BookmarkingEnabled = False
            Me.ComboBoxPostPeriod_PostPeriod.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.PostPeriod
            Me.ComboBoxPostPeriod_PostPeriod.DisableMouseWheel = False
            Me.ComboBoxPostPeriod_PostPeriod.DisplayMember = "Description"
            Me.ComboBoxPostPeriod_PostPeriod.DisplayName = ""
            Me.ComboBoxPostPeriod_PostPeriod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxPostPeriod_PostPeriod.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxPostPeriod_PostPeriod.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxPostPeriod_PostPeriod.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxPostPeriod_PostPeriod.FocusHighlightEnabled = True
            Me.ComboBoxPostPeriod_PostPeriod.FormattingEnabled = True
            Me.ComboBoxPostPeriod_PostPeriod.ItemHeight = 14
            Me.ComboBoxPostPeriod_PostPeriod.Location = New System.Drawing.Point(82, 38)
            Me.ComboBoxPostPeriod_PostPeriod.Name = "ComboBoxPostPeriod_PostPeriod"
            Me.ComboBoxPostPeriod_PostPeriod.PreventEnterBeep = True
            Me.ComboBoxPostPeriod_PostPeriod.ReadOnly = False
            Me.ComboBoxPostPeriod_PostPeriod.Size = New System.Drawing.Size(213, 20)
            Me.ComboBoxPostPeriod_PostPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxPostPeriod_PostPeriod.TabIndex = 1
            Me.ComboBoxPostPeriod_PostPeriod.ValueMember = "Code"
            Me.ComboBoxPostPeriod_PostPeriod.WatermarkText = "Select Post Period"
            '
            'TextBoxReportName_ReportName
            '
            '
            '
            '
            Me.TextBoxReportName_ReportName.Border.Class = "TextBoxBorder"
            Me.TextBoxReportName_ReportName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxReportName_ReportName.CheckSpellingOnValidate = False
            Me.TextBoxReportName_ReportName.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxReportName_ReportName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxReportName_ReportName.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxReportName_ReportName.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxReportName_ReportName.FocusHighlightEnabled = True
            Me.TextBoxReportName_ReportName.Location = New System.Drawing.Point(82, 16)
            Me.TextBoxReportName_ReportName.Name = "TextBoxReportName_ReportName"
            Me.TextBoxReportName_ReportName.Size = New System.Drawing.Size(200, 20)
            Me.TextBoxReportName_ReportName.TabIndex = 2
            Me.TextBoxReportName_ReportName.TabOnEnter = True
            '
            'DateTimePickerReportDate_ReportDate
            '
            Me.DateTimePickerReportDate_ReportDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerReportDate_ReportDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerReportDate_ReportDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerReportDate_ReportDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerReportDate_ReportDate.ButtonDropDown.Visible = True
            Me.DateTimePickerReportDate_ReportDate.ButtonFreeText.Checked = True
            Me.DateTimePickerReportDate_ReportDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerReportDate_ReportDate.CustomFormat = ""
            Me.DateTimePickerReportDate_ReportDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerReportDate_ReportDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerReportDate_ReportDate.FocusHighlightEnabled = True
            Me.DateTimePickerReportDate_ReportDate.Format = DevComponents.Editors.eDateTimePickerFormat.Short
            Me.DateTimePickerReportDate_ReportDate.FreeTextEntryMode = True
            Me.DateTimePickerReportDate_ReportDate.IsPopupCalendarOpen = False
            Me.DateTimePickerReportDate_ReportDate.Location = New System.Drawing.Point(82, 60)
            Me.DateTimePickerReportDate_ReportDate.MinDate = New Date(1850, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerReportDate_ReportDate.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerReportDate_ReportDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerReportDate_ReportDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerReportDate_ReportDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerReportDate_ReportDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerReportDate_ReportDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerReportDate_ReportDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerReportDate_ReportDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerReportDate_ReportDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerReportDate_ReportDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerReportDate_ReportDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerReportDate_ReportDate.MonthCalendar.DisplayMonth = New Date(2012, 12, 1, 0, 0, 0, 0)
            Me.DateTimePickerReportDate_ReportDate.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerReportDate_ReportDate.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerReportDate_ReportDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerReportDate_ReportDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerReportDate_ReportDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerReportDate_ReportDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerReportDate_ReportDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerReportDate_ReportDate.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerReportDate_ReportDate.Name = "DateTimePickerReportDate_ReportDate"
            Me.DateTimePickerReportDate_ReportDate.ReadOnly = False
            Me.DateTimePickerReportDate_ReportDate.Size = New System.Drawing.Size(100, 20)
            Me.DateTimePickerReportDate_ReportDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerReportDate_ReportDate.TabIndex = 2
            '
            'ItemContainerActions_Report
            '
            '
            '
            '
            Me.ItemContainerActions_Report.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerActions_Report.BeginGroup = True
            Me.ItemContainerActions_Report.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerActions_Report.Name = "ItemContainerActions_Report"
            Me.ItemContainerActions_Report.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerReport_ReportName, Me.ItemContainerReport_PostPeriod, Me.ItemContainerReport_ReportDate})
            '
            '
            '
            Me.ItemContainerActions_Report.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ItemContainerReport_ReportName
            '
            '
            '
            '
            Me.ItemContainerReport_ReportName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerReport_ReportName.Name = "ItemContainerReport_ReportName"
            Me.ItemContainerReport_ReportName.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemReportName_ReportName, Me.ControlContainerItemReportName_ReportName})
            '
            '
            '
            Me.ItemContainerReport_ReportName.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemReportName_ReportName
            '
            Me.LabelItemReportName_ReportName.Name = "LabelItemReportName_ReportName"
            Me.LabelItemReportName_ReportName.Text = "Report Name:"
            Me.LabelItemReportName_ReportName.Width = 75
            '
            'ControlContainerItemReportName_ReportName
            '
            Me.ControlContainerItemReportName_ReportName.AllowItemResize = True
            Me.ControlContainerItemReportName_ReportName.Control = Me.TextBoxReportName_ReportName
            Me.ControlContainerItemReportName_ReportName.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItemReportName_ReportName.Name = "ControlContainerItemReportName_ReportName"
            '
            'ItemContainerReport_PostPeriod
            '
            '
            '
            '
            Me.ItemContainerReport_PostPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerReport_PostPeriod.Name = "ItemContainerReport_PostPeriod"
            Me.ItemContainerReport_PostPeriod.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemPostPeriod_PostPeriod, Me.ControlContainerItemPostPeriod_PostPeriod})
            '
            '
            '
            Me.ItemContainerReport_PostPeriod.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemPostPeriod_PostPeriod
            '
            Me.LabelItemPostPeriod_PostPeriod.Name = "LabelItemPostPeriod_PostPeriod"
            Me.LabelItemPostPeriod_PostPeriod.Text = "Post Period:"
            Me.LabelItemPostPeriod_PostPeriod.Width = 75
            '
            'ControlContainerItemPostPeriod_PostPeriod
            '
            Me.ControlContainerItemPostPeriod_PostPeriod.AllowItemResize = True
            Me.ControlContainerItemPostPeriod_PostPeriod.Control = Me.ComboBoxPostPeriod_PostPeriod
            Me.ControlContainerItemPostPeriod_PostPeriod.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItemPostPeriod_PostPeriod.Name = "ControlContainerItemPostPeriod_PostPeriod"
            '
            'ItemContainerReport_ReportDate
            '
            '
            '
            '
            Me.ItemContainerReport_ReportDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerReport_ReportDate.Name = "ItemContainerReport_ReportDate"
            Me.ItemContainerReport_ReportDate.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemReportDate_ReportDate, Me.ControlContainerItemReportDate_ReportDate})
            '
            '
            '
            Me.ItemContainerReport_ReportDate.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemReportDate_ReportDate
            '
            Me.LabelItemReportDate_ReportDate.Name = "LabelItemReportDate_ReportDate"
            Me.LabelItemReportDate_ReportDate.Text = "Date:"
            Me.LabelItemReportDate_ReportDate.Width = 75
            '
            'ControlContainerItemReportDate_ReportDate
            '
            Me.ControlContainerItemReportDate_ReportDate.AllowItemResize = True
            Me.ControlContainerItemReportDate_ReportDate.Control = Me.DateTimePickerReportDate_ReportDate
            Me.ControlContainerItemReportDate_ReportDate.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItemReportDate_ReportDate.Name = "ControlContainerItemReportDate_ReportDate"
            '
            'ButtonItemActions_View
            '
            Me.ButtonItemActions_View.BeginGroup = True
            Me.ButtonItemActions_View.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_View.Name = "ButtonItemActions_View"
            Me.ButtonItemActions_View.RibbonWordWrap = False
            Me.ButtonItemActions_View.SubItemsExpandWidth = 14
            Me.ButtonItemActions_View.Text = "View"
            '
            'PivotGridForm_GLReport
            '
            Me.PivotGridForm_GLReport.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PivotGridForm_GLReport.Location = New System.Drawing.Point(12, 12)
            Me.PivotGridForm_GLReport.Name = "PivotGridForm_GLReport"
            Me.PivotGridForm_GLReport.OptionsBehavior.ApplyBestFitOnFieldDragging = True
            Me.PivotGridForm_GLReport.OptionsCustomization.AllowHideFields = DevExpress.XtraPivotGrid.AllowHideFieldsType.Always
            Me.PivotGridForm_GLReport.Size = New System.Drawing.Size(689, 397)
            Me.PivotGridForm_GLReport.TabIndex = 0
            '
            'RibbonBarOptions_ReportTypes
            '
            Me.RibbonBarOptions_ReportTypes.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_ReportTypes.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ReportTypes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ReportTypes.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_ReportTypes.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_ReportTypes.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemReportTypes_Income, Me.ButtonItemReportTypes_BalanceSheet})
            Me.RibbonBarOptions_ReportTypes.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_ReportTypes.Location = New System.Drawing.Point(359, 0)
            Me.RibbonBarOptions_ReportTypes.Name = "RibbonBarOptions_ReportTypes"
            Me.RibbonBarOptions_ReportTypes.Size = New System.Drawing.Size(148, 98)
            Me.RibbonBarOptions_ReportTypes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_ReportTypes.TabIndex = 2
            Me.RibbonBarOptions_ReportTypes.Text = "Report Types"
            '
            '
            '
            Me.RibbonBarOptions_ReportTypes.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ReportTypes.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ReportTypes.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemReportTypes_Income
            '
            Me.ButtonItemReportTypes_Income.AutoCheckOnClick = True
            Me.ButtonItemReportTypes_Income.BeginGroup = True
            Me.ButtonItemReportTypes_Income.Checked = True
            Me.ButtonItemReportTypes_Income.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemReportTypes_Income.Name = "ButtonItemReportTypes_Income"
            Me.ButtonItemReportTypes_Income.OptionGroup = "ReportTypes"
            Me.ButtonItemReportTypes_Income.RibbonWordWrap = False
            Me.ButtonItemReportTypes_Income.SubItemsExpandWidth = 14
            Me.ButtonItemReportTypes_Income.Text = "Income"
            '
            'ButtonItemReportTypes_BalanceSheet
            '
            Me.ButtonItemReportTypes_BalanceSheet.AutoCheckOnClick = True
            Me.ButtonItemReportTypes_BalanceSheet.BeginGroup = True
            Me.ButtonItemReportTypes_BalanceSheet.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemReportTypes_BalanceSheet.Name = "ButtonItemReportTypes_BalanceSheet"
            Me.ButtonItemReportTypes_BalanceSheet.OptionGroup = "ReportTypes"
            Me.ButtonItemReportTypes_BalanceSheet.RibbonWordWrap = False
            Me.ButtonItemReportTypes_BalanceSheet.SubItemsExpandWidth = 14
            Me.ButtonItemReportTypes_BalanceSheet.Text = "Balance Sheet"
            '
            'NewReportWriterForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(713, 421)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.PivotGridForm_GLReport)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "NewReportWriterForm"
            Me.Text = "General Ledger Report Writer"
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.RibbonBarOptions_Actions.ResumeLayout(False)
            CType(Me.DateTimePickerReportDate_ReportDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PivotGridForm_GLReport, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents PivotGridForm_GLReport As AdvantageFramework.WinForm.Presentation.Controls.PivotGridControl
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ComboBoxPostPeriod_PostPeriod As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents DateTimePickerReportDate_ReportDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents ItemContainerReport_ReportName As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemReportName_ReportName As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ControlContainerItemReportName_ReportName As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ItemContainerActions_Report As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ItemContainerReport_PostPeriod As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemPostPeriod_PostPeriod As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ControlContainerItemPostPeriod_PostPeriod As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ItemContainerReport_ReportDate As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemReportDate_ReportDate As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ControlContainerItemReportDate_ReportDate As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ButtonItemActions_View As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents TextBoxReportName_ReportName As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents RibbonBarOptions_ReportTypes As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemReportTypes_Income As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemReportTypes_BalanceSheet As DevComponents.DotNetBar.ButtonItem
    End Class

End Namespace

