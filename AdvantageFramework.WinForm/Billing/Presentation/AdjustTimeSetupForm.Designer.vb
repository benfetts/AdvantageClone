Namespace Billing.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AdjustTimeSetupForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdjustTimeSetupForm))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Search = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.SearchableComboBoxSearch_ClientOrEmployee = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBox1ViewSearch_ClientOrEmployee = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxSearch_Job = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBox1ViewSearch_Job = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxSearch_JobComp = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBox1ViewSearch_JobComp = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.DateTimePickerDates_From = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerDates_To = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.ItemContainerSearch_Main = New DevComponents.DotNetBar.ItemContainer()
            Me.ItemContainerMain_Main = New DevComponents.DotNetBar.ItemContainer()
            Me.ItemContainerMain_Top = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemMain_ClientOrEmployee = New DevComponents.DotNetBar.LabelItem()
            Me.ControlContainerItemMain_ClientOrEmployee = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ItemContainerMain_Middle = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemMain_Job = New DevComponents.DotNetBar.LabelItem()
            Me.ControlContainerItemMain_Job = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ItemContainerMain_Bottom = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemMain_JobComp = New DevComponents.DotNetBar.LabelItem()
            Me.ControlContainerItemMain_JobComp = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ItemContainerSearch_Dates = New DevComponents.DotNetBar.ItemContainer()
            Me.ItemContainerDates_Dates = New DevComponents.DotNetBar.ItemContainer()
            Me.ItemContainerDates_Top = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemDates_From = New DevComponents.DotNetBar.LabelItem()
            Me.ControlContainerItemDates_From = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ItemContainerDates_Bottom = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemDates_To = New DevComponents.DotNetBar.LabelItem()
            Me.ControlContainerItemDates_To = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ItemContainer1 = New DevComponents.DotNetBar.ItemContainer()
            Me.CheckBoxItemSearch_IncludeBilledTime = New DevComponents.DotNetBar.CheckBoxItem()
            Me.ButtonItemSearch_Search = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ItemContainerSearch_SearchFilter = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemSearchFilter_ByEmployee = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemSearchFilter_ByJob = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Export = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_MarkBillable = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_MarkNonBillable = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_FeeTime = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemFeeTime_No = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemFeeTime_TimeAgainstFee = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemFeeTime_TimeAgainstCommissionP = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemFeeTime_TimeAgainstCommissionM = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_UpdateRate = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_DeptTeam = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDeptTeam_FromList = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemDeptTeam_FromHRHistory = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_EmployeeTitle = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemEmployeeTitle_FromList = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemEmployeeTitle_FromHRHistory = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_ShowDescriptions = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.DataGridViewMain_TimeRecords = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.DataGridViewForm_Export = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.RibbonBarOptions_Search.SuspendLayout()
            CType(Me.SearchableComboBoxSearch_ClientOrEmployee.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBox1ViewSearch_ClientOrEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxSearch_Job.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBox1ViewSearch_Job, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxSearch_JobComp.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBox1ViewSearch_JobComp, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerDates_From, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerDates_To, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Search)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(5, 29)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(1202, 98)
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
            'RibbonBarOptions_Search
            '
            Me.RibbonBarOptions_Search.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Search.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Search.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Search.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Search.Controls.Add(Me.SearchableComboBoxSearch_ClientOrEmployee)
            Me.RibbonBarOptions_Search.Controls.Add(Me.SearchableComboBoxSearch_Job)
            Me.RibbonBarOptions_Search.Controls.Add(Me.SearchableComboBoxSearch_JobComp)
            Me.RibbonBarOptions_Search.Controls.Add(Me.DateTimePickerDates_From)
            Me.RibbonBarOptions_Search.Controls.Add(Me.DateTimePickerDates_To)
            Me.RibbonBarOptions_Search.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Search.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerSearch_Main, Me.ItemContainerSearch_Dates, Me.ButtonItemSearch_Search, Me.ItemContainerSearch_SearchFilter})
            Me.RibbonBarOptions_Search.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Search.Location = New System.Drawing.Point(618, 0)
            Me.RibbonBarOptions_Search.Name = "RibbonBarOptions_Search"
            Me.RibbonBarOptions_Search.SecurityEnabled = True
            Me.RibbonBarOptions_Search.Size = New System.Drawing.Size(580, 98)
            Me.RibbonBarOptions_Search.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Search.TabIndex = 1
            Me.RibbonBarOptions_Search.Text = "Search"
            '
            '
            '
            Me.RibbonBarOptions_Search.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Search.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Search.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'SearchableComboBoxSearch_ClientOrEmployee
            '
            Me.SearchableComboBoxSearch_ClientOrEmployee.ActiveFilterString = ""
            Me.SearchableComboBoxSearch_ClientOrEmployee.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxSearch_ClientOrEmployee.AutoFillMode = False
            Me.SearchableComboBoxSearch_ClientOrEmployee.BookmarkingEnabled = False
            Me.SearchableComboBoxSearch_ClientOrEmployee.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.[Default]
            Me.SearchableComboBoxSearch_ClientOrEmployee.DataSource = Nothing
            Me.SearchableComboBoxSearch_ClientOrEmployee.DisableMouseWheel = False
            Me.SearchableComboBoxSearch_ClientOrEmployee.DisplayName = ""
            Me.SearchableComboBoxSearch_ClientOrEmployee.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.All
            Me.SearchableComboBoxSearch_ClientOrEmployee.Location = New System.Drawing.Point(72, 8)
            Me.SearchableComboBoxSearch_ClientOrEmployee.Name = "SearchableComboBoxSearch_ClientOrEmployee"
            Me.SearchableComboBoxSearch_ClientOrEmployee.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxSearch_ClientOrEmployee.Properties.NullText = ""
            Me.SearchableComboBoxSearch_ClientOrEmployee.Properties.ShowClearButton = False
            Me.SearchableComboBoxSearch_ClientOrEmployee.Properties.View = Me.SearchableComboBox1ViewSearch_ClientOrEmployee
            Me.SearchableComboBoxSearch_ClientOrEmployee.SecurityEnabled = True
            Me.SearchableComboBoxSearch_ClientOrEmployee.SelectedValue = Nothing
            Me.SearchableComboBoxSearch_ClientOrEmployee.Size = New System.Drawing.Size(179, 20)
            Me.SearchableComboBoxSearch_ClientOrEmployee.TabIndex = 0
            '
            'SearchableComboBox1ViewSearch_ClientOrEmployee
            '
            Me.SearchableComboBox1ViewSearch_ClientOrEmployee.AFActiveFilterString = ""
            Me.SearchableComboBox1ViewSearch_ClientOrEmployee.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBox1ViewSearch_ClientOrEmployee.AutoFilterLookupColumns = False
            Me.SearchableComboBox1ViewSearch_ClientOrEmployee.AutoloadRepositoryDatasource = True
            Me.SearchableComboBox1ViewSearch_ClientOrEmployee.DataSourceClearing = False
            Me.SearchableComboBox1ViewSearch_ClientOrEmployee.EnableDisabledRows = False
            Me.SearchableComboBox1ViewSearch_ClientOrEmployee.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBox1ViewSearch_ClientOrEmployee.Name = "SearchableComboBox1ViewSearch_ClientOrEmployee"
            Me.SearchableComboBox1ViewSearch_ClientOrEmployee.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBox1ViewSearch_ClientOrEmployee.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBox1ViewSearch_ClientOrEmployee.RunStandardValidation = True
            '
            'SearchableComboBoxSearch_Job
            '
            Me.SearchableComboBoxSearch_Job.ActiveFilterString = ""
            Me.SearchableComboBoxSearch_Job.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxSearch_Job.AutoFillMode = False
            Me.SearchableComboBoxSearch_Job.BookmarkingEnabled = False
            Me.SearchableComboBoxSearch_Job.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.[Default]
            Me.SearchableComboBoxSearch_Job.DataSource = Nothing
            Me.SearchableComboBoxSearch_Job.DisableMouseWheel = False
            Me.SearchableComboBoxSearch_Job.DisplayName = ""
            Me.SearchableComboBoxSearch_Job.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.All
            Me.SearchableComboBoxSearch_Job.Location = New System.Drawing.Point(72, 31)
            Me.SearchableComboBoxSearch_Job.Name = "SearchableComboBoxSearch_Job"
            Me.SearchableComboBoxSearch_Job.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxSearch_Job.Properties.NullText = ""
            Me.SearchableComboBoxSearch_Job.Properties.ShowClearButton = False
            Me.SearchableComboBoxSearch_Job.Properties.View = Me.SearchableComboBox1ViewSearch_Job
            Me.SearchableComboBoxSearch_Job.SecurityEnabled = True
            Me.SearchableComboBoxSearch_Job.SelectedValue = Nothing
            Me.SearchableComboBoxSearch_Job.Size = New System.Drawing.Size(179, 20)
            Me.SearchableComboBoxSearch_Job.TabIndex = 1
            '
            'SearchableComboBox1ViewSearch_Job
            '
            Me.SearchableComboBox1ViewSearch_Job.AFActiveFilterString = ""
            Me.SearchableComboBox1ViewSearch_Job.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBox1ViewSearch_Job.AutoFilterLookupColumns = False
            Me.SearchableComboBox1ViewSearch_Job.AutoloadRepositoryDatasource = True
            Me.SearchableComboBox1ViewSearch_Job.DataSourceClearing = False
            Me.SearchableComboBox1ViewSearch_Job.EnableDisabledRows = False
            Me.SearchableComboBox1ViewSearch_Job.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBox1ViewSearch_Job.Name = "SearchableComboBox1ViewSearch_Job"
            Me.SearchableComboBox1ViewSearch_Job.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBox1ViewSearch_Job.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBox1ViewSearch_Job.RunStandardValidation = True
            '
            'SearchableComboBoxSearch_JobComp
            '
            Me.SearchableComboBoxSearch_JobComp.ActiveFilterString = ""
            Me.SearchableComboBoxSearch_JobComp.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxSearch_JobComp.AutoFillMode = False
            Me.SearchableComboBoxSearch_JobComp.BookmarkingEnabled = False
            Me.SearchableComboBoxSearch_JobComp.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.[Default]
            Me.SearchableComboBoxSearch_JobComp.DataSource = Nothing
            Me.SearchableComboBoxSearch_JobComp.DisableMouseWheel = False
            Me.SearchableComboBoxSearch_JobComp.DisplayName = ""
            Me.SearchableComboBoxSearch_JobComp.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.All
            Me.SearchableComboBoxSearch_JobComp.Location = New System.Drawing.Point(72, 54)
            Me.SearchableComboBoxSearch_JobComp.Name = "SearchableComboBoxSearch_JobComp"
            Me.SearchableComboBoxSearch_JobComp.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxSearch_JobComp.Properties.NullText = ""
            Me.SearchableComboBoxSearch_JobComp.Properties.ShowClearButton = False
            Me.SearchableComboBoxSearch_JobComp.Properties.View = Me.SearchableComboBox1ViewSearch_JobComp
            Me.SearchableComboBoxSearch_JobComp.SecurityEnabled = True
            Me.SearchableComboBoxSearch_JobComp.SelectedValue = Nothing
            Me.SearchableComboBoxSearch_JobComp.Size = New System.Drawing.Size(179, 20)
            Me.SearchableComboBoxSearch_JobComp.TabIndex = 2
            '
            'SearchableComboBox1ViewSearch_JobComp
            '
            Me.SearchableComboBox1ViewSearch_JobComp.AFActiveFilterString = ""
            Me.SearchableComboBox1ViewSearch_JobComp.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBox1ViewSearch_JobComp.AutoFilterLookupColumns = False
            Me.SearchableComboBox1ViewSearch_JobComp.AutoloadRepositoryDatasource = True
            Me.SearchableComboBox1ViewSearch_JobComp.DataSourceClearing = False
            Me.SearchableComboBox1ViewSearch_JobComp.EnableDisabledRows = False
            Me.SearchableComboBox1ViewSearch_JobComp.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBox1ViewSearch_JobComp.Name = "SearchableComboBox1ViewSearch_JobComp"
            Me.SearchableComboBox1ViewSearch_JobComp.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBox1ViewSearch_JobComp.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBox1ViewSearch_JobComp.RunStandardValidation = True
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
            Me.DateTimePickerDates_From.Location = New System.Drawing.Point(307, 8)
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
            Me.DateTimePickerDates_From.Size = New System.Drawing.Size(115, 20)
            Me.DateTimePickerDates_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerDates_From.TabIndex = 3
            Me.DateTimePickerDates_From.Value = New Date(2013, 9, 10, 16, 52, 5, 560)
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
            Me.DateTimePickerDates_To.Location = New System.Drawing.Point(307, 31)
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
            Me.DateTimePickerDates_To.Size = New System.Drawing.Size(115, 20)
            Me.DateTimePickerDates_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerDates_To.TabIndex = 4
            Me.DateTimePickerDates_To.Value = New Date(2013, 9, 10, 16, 52, 5, 540)
            '
            'ItemContainerSearch_Main
            '
            '
            '
            '
            Me.ItemContainerSearch_Main.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSearch_Main.Name = "ItemContainerSearch_Main"
            Me.ItemContainerSearch_Main.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerMain_Main})
            '
            '
            '
            Me.ItemContainerSearch_Main.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ItemContainerMain_Main
            '
            '
            '
            '
            Me.ItemContainerMain_Main.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerMain_Main.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerMain_Main.Name = "ItemContainerMain_Main"
            Me.ItemContainerMain_Main.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerMain_Top, Me.ItemContainerMain_Middle, Me.ItemContainerMain_Bottom})
            '
            '
            '
            Me.ItemContainerMain_Main.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ItemContainerMain_Top
            '
            '
            '
            '
            Me.ItemContainerMain_Top.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerMain_Top.Name = "ItemContainerMain_Top"
            Me.ItemContainerMain_Top.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemMain_ClientOrEmployee, Me.ControlContainerItemMain_ClientOrEmployee})
            '
            '
            '
            Me.ItemContainerMain_Top.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemMain_ClientOrEmployee
            '
            Me.LabelItemMain_ClientOrEmployee.Name = "LabelItemMain_ClientOrEmployee"
            Me.LabelItemMain_ClientOrEmployee.Text = "Employee:"
            Me.LabelItemMain_ClientOrEmployee.Width = 65
            '
            'ControlContainerItemMain_ClientOrEmployee
            '
            Me.ControlContainerItemMain_ClientOrEmployee.AllowItemResize = True
            Me.ControlContainerItemMain_ClientOrEmployee.Control = Me.SearchableComboBoxSearch_ClientOrEmployee
            Me.ControlContainerItemMain_ClientOrEmployee.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItemMain_ClientOrEmployee.Name = "ControlContainerItemMain_ClientOrEmployee"
            Me.ControlContainerItemMain_ClientOrEmployee.Text = "ControlContainerItem1"
            '
            'ItemContainerMain_Middle
            '
            '
            '
            '
            Me.ItemContainerMain_Middle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerMain_Middle.Name = "ItemContainerMain_Middle"
            Me.ItemContainerMain_Middle.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemMain_Job, Me.ControlContainerItemMain_Job})
            '
            '
            '
            Me.ItemContainerMain_Middle.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemMain_Job
            '
            Me.LabelItemMain_Job.Name = "LabelItemMain_Job"
            Me.LabelItemMain_Job.Text = "Job:"
            Me.LabelItemMain_Job.Width = 65
            '
            'ControlContainerItemMain_Job
            '
            Me.ControlContainerItemMain_Job.AllowItemResize = True
            Me.ControlContainerItemMain_Job.Control = Me.SearchableComboBoxSearch_Job
            Me.ControlContainerItemMain_Job.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItemMain_Job.Name = "ControlContainerItemMain_Job"
            Me.ControlContainerItemMain_Job.Text = "ControlContainerItem2"
            '
            'ItemContainerMain_Bottom
            '
            '
            '
            '
            Me.ItemContainerMain_Bottom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerMain_Bottom.Name = "ItemContainerMain_Bottom"
            Me.ItemContainerMain_Bottom.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemMain_JobComp, Me.ControlContainerItemMain_JobComp})
            '
            '
            '
            Me.ItemContainerMain_Bottom.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemMain_JobComp
            '
            Me.LabelItemMain_JobComp.Name = "LabelItemMain_JobComp"
            Me.LabelItemMain_JobComp.Text = "Job Comp:"
            Me.LabelItemMain_JobComp.Width = 65
            '
            'ControlContainerItemMain_JobComp
            '
            Me.ControlContainerItemMain_JobComp.AllowItemResize = True
            Me.ControlContainerItemMain_JobComp.Control = Me.SearchableComboBoxSearch_JobComp
            Me.ControlContainerItemMain_JobComp.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItemMain_JobComp.Name = "ControlContainerItemMain_JobComp"
            Me.ControlContainerItemMain_JobComp.Text = "ControlContainerItem1"
            '
            'ItemContainerSearch_Dates
            '
            '
            '
            '
            Me.ItemContainerSearch_Dates.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSearch_Dates.Name = "ItemContainerSearch_Dates"
            Me.ItemContainerSearch_Dates.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerDates_Dates})
            '
            '
            '
            Me.ItemContainerSearch_Dates.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ItemContainerDates_Dates
            '
            '
            '
            '
            Me.ItemContainerDates_Dates.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerDates_Dates.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerDates_Dates.Name = "ItemContainerDates_Dates"
            Me.ItemContainerDates_Dates.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerDates_Top, Me.ItemContainerDates_Bottom, Me.ItemContainer1})
            '
            '
            '
            Me.ItemContainerDates_Dates.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ItemContainerDates_Top
            '
            '
            '
            '
            Me.ItemContainerDates_Top.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerDates_Top.Name = "ItemContainerDates_Top"
            Me.ItemContainerDates_Top.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemDates_From, Me.ControlContainerItemDates_From})
            '
            '
            '
            Me.ItemContainerDates_Top.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemDates_From
            '
            Me.LabelItemDates_From.Name = "LabelItemDates_From"
            Me.LabelItemDates_From.Text = "From:"
            Me.LabelItemDates_From.Width = 50
            '
            'ControlContainerItemDates_From
            '
            Me.ControlContainerItemDates_From.AllowItemResize = True
            Me.ControlContainerItemDates_From.Control = Me.DateTimePickerDates_From
            Me.ControlContainerItemDates_From.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItemDates_From.Name = "ControlContainerItemDates_From"
            Me.ControlContainerItemDates_From.Text = "ControlContainerItem1"
            '
            'ItemContainerDates_Bottom
            '
            '
            '
            '
            Me.ItemContainerDates_Bottom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerDates_Bottom.Name = "ItemContainerDates_Bottom"
            Me.ItemContainerDates_Bottom.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemDates_To, Me.ControlContainerItemDates_To})
            '
            '
            '
            Me.ItemContainerDates_Bottom.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemDates_To
            '
            Me.LabelItemDates_To.Name = "LabelItemDates_To"
            Me.LabelItemDates_To.Text = "To:"
            Me.LabelItemDates_To.Width = 50
            '
            'ControlContainerItemDates_To
            '
            Me.ControlContainerItemDates_To.AllowItemResize = True
            Me.ControlContainerItemDates_To.Control = Me.DateTimePickerDates_To
            Me.ControlContainerItemDates_To.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItemDates_To.Name = "ControlContainerItemDates_To"
            Me.ControlContainerItemDates_To.Text = "ControlContainerItem2"
            '
            'ItemContainer1
            '
            '
            '
            '
            Me.ItemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer1.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Right
            Me.ItemContainer1.Name = "ItemContainer1"
            Me.ItemContainer1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.CheckBoxItemSearch_IncludeBilledTime})
            '
            '
            '
            Me.ItemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'CheckBoxItemSearch_IncludeBilledTime
            '
            Me.CheckBoxItemSearch_IncludeBilledTime.Name = "CheckBoxItemSearch_IncludeBilledTime"
            Me.CheckBoxItemSearch_IncludeBilledTime.Text = "Include Billed Time"
            '
            'ButtonItemSearch_Search
            '
            Me.ButtonItemSearch_Search.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemSearch_Search.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemSearch_Search.Name = "ButtonItemSearch_Search"
            Me.ButtonItemSearch_Search.RibbonWordWrap = False
            Me.ButtonItemSearch_Search.SecurityEnabled = True
            Me.ButtonItemSearch_Search.Stretch = True
            Me.ButtonItemSearch_Search.SubItemsExpandWidth = 14
            Me.ButtonItemSearch_Search.Text = "Search"
            '
            'ItemContainerSearch_SearchFilter
            '
            '
            '
            '
            Me.ItemContainerSearch_SearchFilter.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSearch_SearchFilter.BeginGroup = True
            Me.ItemContainerSearch_SearchFilter.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerSearch_SearchFilter.Name = "ItemContainerSearch_SearchFilter"
            Me.ItemContainerSearch_SearchFilter.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemSearchFilter_ByEmployee, Me.ButtonItemSearchFilter_ByJob})
            '
            '
            '
            Me.ItemContainerSearch_SearchFilter.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemSearchFilter_ByEmployee
            '
            Me.ButtonItemSearchFilter_ByEmployee.AutoCheckOnClick = True
            Me.ButtonItemSearchFilter_ByEmployee.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemSearchFilter_ByEmployee.Name = "ButtonItemSearchFilter_ByEmployee"
            Me.ButtonItemSearchFilter_ByEmployee.OptionGroup = "SearchFilter"
            Me.ButtonItemSearchFilter_ByEmployee.RibbonWordWrap = False
            Me.ButtonItemSearchFilter_ByEmployee.Stretch = True
            Me.ButtonItemSearchFilter_ByEmployee.Text = "By Employee"
            '
            'ButtonItemSearchFilter_ByJob
            '
            Me.ButtonItemSearchFilter_ByJob.AutoCheckOnClick = True
            Me.ButtonItemSearchFilter_ByJob.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemSearchFilter_ByJob.Checked = True
            Me.ButtonItemSearchFilter_ByJob.Name = "ButtonItemSearchFilter_ByJob"
            Me.ButtonItemSearchFilter_ByJob.OptionGroup = "SearchFilter"
            Me.ButtonItemSearchFilter_ByJob.RibbonWordWrap = False
            Me.ButtonItemSearchFilter_ByJob.Stretch = True
            Me.ButtonItemSearchFilter_ByJob.Text = "By Job"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Export, Me.ButtonItemActions_Save, Me.ButtonItemActions_MarkBillable, Me.ButtonItemActions_MarkNonBillable, Me.ButtonItemActions_FeeTime, Me.ButtonItemActions_UpdateRate, Me.ButtonItemActions_DeptTeam, Me.ButtonItemActions_EmployeeTitle, Me.ButtonItemActions_ShowDescriptions})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(618, 98)
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
            Me.RibbonBarOptions_Actions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemActions_Export
            '
            Me.ButtonItemActions_Export.BeginGroup = True
            Me.ButtonItemActions_Export.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Export.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Export.Name = "ButtonItemActions_Export"
            Me.ButtonItemActions_Export.RibbonWordWrap = False
            Me.ButtonItemActions_Export.SecurityEnabled = True
            Me.ButtonItemActions_Export.Stretch = True
            Me.ButtonItemActions_Export.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Export.Text = "Export"
            '
            'ButtonItemActions_Save
            '
            Me.ButtonItemActions_Save.BeginGroup = True
            Me.ButtonItemActions_Save.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Save.Name = "ButtonItemActions_Save"
            Me.ButtonItemActions_Save.RibbonWordWrap = False
            Me.ButtonItemActions_Save.SecurityEnabled = True
            Me.ButtonItemActions_Save.Stretch = True
            Me.ButtonItemActions_Save.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Save.Text = "Save"
            '
            'ButtonItemActions_MarkBillable
            '
            Me.ButtonItemActions_MarkBillable.BeginGroup = True
            Me.ButtonItemActions_MarkBillable.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_MarkBillable.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_MarkBillable.Name = "ButtonItemActions_MarkBillable"
            Me.ButtonItemActions_MarkBillable.RibbonWordWrap = False
            Me.ButtonItemActions_MarkBillable.SecurityEnabled = True
            Me.ButtonItemActions_MarkBillable.Stretch = True
            Me.ButtonItemActions_MarkBillable.SubItemsExpandWidth = 14
            Me.ButtonItemActions_MarkBillable.Text = "Mark Billable"
            Me.ButtonItemActions_MarkBillable.Tooltip = "Marks selected rows 'billable' where applicable"
            '
            'ButtonItemActions_MarkNonBillable
            '
            Me.ButtonItemActions_MarkNonBillable.BeginGroup = True
            Me.ButtonItemActions_MarkNonBillable.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_MarkNonBillable.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_MarkNonBillable.Name = "ButtonItemActions_MarkNonBillable"
            Me.ButtonItemActions_MarkNonBillable.RibbonWordWrap = False
            Me.ButtonItemActions_MarkNonBillable.SecurityEnabled = True
            Me.ButtonItemActions_MarkNonBillable.Stretch = True
            Me.ButtonItemActions_MarkNonBillable.SubItemsExpandWidth = 14
            Me.ButtonItemActions_MarkNonBillable.Text = "Mark Nonbillable "
            Me.ButtonItemActions_MarkNonBillable.Tooltip = "Marks selected rows 'non-billable' where applicable."
            '
            'ButtonItemActions_FeeTime
            '
            Me.ButtonItemActions_FeeTime.AutoExpandOnClick = True
            Me.ButtonItemActions_FeeTime.BeginGroup = True
            Me.ButtonItemActions_FeeTime.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_FeeTime.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_FeeTime.Name = "ButtonItemActions_FeeTime"
            Me.ButtonItemActions_FeeTime.RibbonWordWrap = False
            Me.ButtonItemActions_FeeTime.SecurityEnabled = True
            Me.ButtonItemActions_FeeTime.Stretch = True
            Me.ButtonItemActions_FeeTime.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemFeeTime_No, Me.ButtonItemFeeTime_TimeAgainstFee, Me.ButtonItemFeeTime_TimeAgainstCommissionP, Me.ButtonItemFeeTime_TimeAgainstCommissionM})
            Me.ButtonItemActions_FeeTime.SubItemsExpandWidth = 14
            Me.ButtonItemActions_FeeTime.Text = "Fee Time"
            Me.ButtonItemActions_FeeTime.Tooltip = "Marks selected rows with the Fee Time Flag as indicated where applicable."
            '
            'ButtonItemFeeTime_No
            '
            Me.ButtonItemFeeTime_No.Name = "ButtonItemFeeTime_No"
            Me.ButtonItemFeeTime_No.Text = "No"
            '
            'ButtonItemFeeTime_TimeAgainstFee
            '
            Me.ButtonItemFeeTime_TimeAgainstFee.Name = "ButtonItemFeeTime_TimeAgainstFee"
            Me.ButtonItemFeeTime_TimeAgainstFee.Text = "Time Against Fee"
            '
            'ButtonItemFeeTime_TimeAgainstCommissionP
            '
            Me.ButtonItemFeeTime_TimeAgainstCommissionP.Name = "ButtonItemFeeTime_TimeAgainstCommissionP"
            Me.ButtonItemFeeTime_TimeAgainstCommissionP.Text = "Time Against Commission (P)"
            '
            'ButtonItemFeeTime_TimeAgainstCommissionM
            '
            Me.ButtonItemFeeTime_TimeAgainstCommissionM.Name = "ButtonItemFeeTime_TimeAgainstCommissionM"
            Me.ButtonItemFeeTime_TimeAgainstCommissionM.Text = "Time Against Commission (M)"
            '
            'ButtonItemActions_UpdateRate
            '
            Me.ButtonItemActions_UpdateRate.BeginGroup = True
            Me.ButtonItemActions_UpdateRate.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_UpdateRate.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_UpdateRate.Name = "ButtonItemActions_UpdateRate"
            Me.ButtonItemActions_UpdateRate.RibbonWordWrap = False
            Me.ButtonItemActions_UpdateRate.SecurityEnabled = True
            Me.ButtonItemActions_UpdateRate.Stretch = True
            Me.ButtonItemActions_UpdateRate.SubItemsExpandWidth = 14
            Me.ButtonItemActions_UpdateRate.Text = "Update Rate"
            Me.ButtonItemActions_UpdateRate.Tooltip = "Updates the billing rate and flags of selected rows based on the current settings" & _
        " in the Billing Rate Hierarchy where applicable."
            '
            'ButtonItemActions_DeptTeam
            '
            Me.ButtonItemActions_DeptTeam.AutoExpandOnClick = True
            Me.ButtonItemActions_DeptTeam.BeginGroup = True
            Me.ButtonItemActions_DeptTeam.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_DeptTeam.Name = "ButtonItemActions_DeptTeam"
            Me.ButtonItemActions_DeptTeam.RibbonWordWrap = False
            Me.ButtonItemActions_DeptTeam.SecurityEnabled = True
            Me.ButtonItemActions_DeptTeam.Stretch = True
            Me.ButtonItemActions_DeptTeam.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDeptTeam_FromList, Me.ButtonItemDeptTeam_FromHRHistory})
            Me.ButtonItemActions_DeptTeam.SubItemsExpandWidth = 14
            Me.ButtonItemActions_DeptTeam.Text = "Dept / Team"
            Me.ButtonItemActions_DeptTeam.Tooltip = "Updates the department/team of selected rows where applicable."
            '
            'ButtonItemDeptTeam_FromList
            '
            Me.ButtonItemDeptTeam_FromList.Name = "ButtonItemDeptTeam_FromList"
            Me.ButtonItemDeptTeam_FromList.Text = "From List"
            '
            'ButtonItemDeptTeam_FromHRHistory
            '
            Me.ButtonItemDeptTeam_FromHRHistory.Name = "ButtonItemDeptTeam_FromHRHistory"
            Me.ButtonItemDeptTeam_FromHRHistory.Text = "From H/R History"
            '
            'ButtonItemActions_EmployeeTitle
            '
            Me.ButtonItemActions_EmployeeTitle.AutoExpandOnClick = True
            Me.ButtonItemActions_EmployeeTitle.BeginGroup = True
            Me.ButtonItemActions_EmployeeTitle.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_EmployeeTitle.Name = "ButtonItemActions_EmployeeTitle"
            Me.ButtonItemActions_EmployeeTitle.RibbonWordWrap = False
            Me.ButtonItemActions_EmployeeTitle.SecurityEnabled = True
            Me.ButtonItemActions_EmployeeTitle.Stretch = True
            Me.ButtonItemActions_EmployeeTitle.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemEmployeeTitle_FromList, Me.ButtonItemEmployeeTitle_FromHRHistory})
            Me.ButtonItemActions_EmployeeTitle.SubItemsExpandWidth = 14
            Me.ButtonItemActions_EmployeeTitle.Text = "Employee Title"
            Me.ButtonItemActions_EmployeeTitle.Tooltip = "Updates the title of selected rows where applicable."
            '
            'ButtonItemEmployeeTitle_FromList
            '
            Me.ButtonItemEmployeeTitle_FromList.Name = "ButtonItemEmployeeTitle_FromList"
            Me.ButtonItemEmployeeTitle_FromList.Text = "From List"
            '
            'ButtonItemEmployeeTitle_FromHRHistory
            '
            Me.ButtonItemEmployeeTitle_FromHRHistory.Name = "ButtonItemEmployeeTitle_FromHRHistory"
            Me.ButtonItemEmployeeTitle_FromHRHistory.Text = "From H/R History"
            '
            'ButtonItemActions_ShowDescriptions
            '
            Me.ButtonItemActions_ShowDescriptions.AutoCheckOnClick = True
            Me.ButtonItemActions_ShowDescriptions.BeginGroup = True
            Me.ButtonItemActions_ShowDescriptions.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_ShowDescriptions.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_ShowDescriptions.Name = "ButtonItemActions_ShowDescriptions"
            Me.ButtonItemActions_ShowDescriptions.RibbonWordWrap = False
            Me.ButtonItemActions_ShowDescriptions.SecurityEnabled = True
            Me.ButtonItemActions_ShowDescriptions.Stretch = True
            Me.ButtonItemActions_ShowDescriptions.SubItemsExpandWidth = 14
            Me.ButtonItemActions_ShowDescriptions.Text = "Show Descriptions"
            '
            'DataGridViewMain_TimeRecords
            '
            Me.DataGridViewMain_TimeRecords.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewMain_TimeRecords.AllowSelectGroupHeaderRow = True
            Me.DataGridViewMain_TimeRecords.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewMain_TimeRecords.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewMain_TimeRecords.AutoFilterLookupColumns = False
            Me.DataGridViewMain_TimeRecords.AutoloadRepositoryDatasource = True
            Me.DataGridViewMain_TimeRecords.AutoUpdateViewCaption = True
            Me.DataGridViewMain_TimeRecords.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewMain_TimeRecords.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewMain_TimeRecords.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewMain_TimeRecords.ItemDescription = ""
            Me.DataGridViewMain_TimeRecords.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewMain_TimeRecords.MultiSelect = True
            Me.DataGridViewMain_TimeRecords.Name = "DataGridViewMain_TimeRecords"
            Me.DataGridViewMain_TimeRecords.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewMain_TimeRecords.RunStandardValidation = True
            Me.DataGridViewMain_TimeRecords.ShowSelectDeselectAllButtons = False
            Me.DataGridViewMain_TimeRecords.Size = New System.Drawing.Size(1183, 397)
            Me.DataGridViewMain_TimeRecords.TabIndex = 0
            Me.DataGridViewMain_TimeRecords.UseEmbeddedNavigator = False
            Me.DataGridViewMain_TimeRecords.ViewCaptionHeight = -1
            '
            'DataGridViewForm_Export
            '
            Me.DataGridViewForm_Export.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_Export.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_Export.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_Export.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_Export.AutoFilterLookupColumns = False
            Me.DataGridViewForm_Export.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_Export.AutoUpdateViewCaption = True
            Me.DataGridViewForm_Export.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_Export.DataSource = Nothing
            Me.DataGridViewForm_Export.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_Export.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_Export.ItemDescription = ""
            Me.DataGridViewForm_Export.Location = New System.Drawing.Point(877, 206)
            Me.DataGridViewForm_Export.MultiSelect = True
            Me.DataGridViewForm_Export.Name = "DataGridViewForm_Export"
            Me.DataGridViewForm_Export.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_Export.RunStandardValidation = True
            Me.DataGridViewForm_Export.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_Export.Size = New System.Drawing.Size(297, 187)
            Me.DataGridViewForm_Export.TabIndex = 2
            Me.DataGridViewForm_Export.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Export.ViewCaptionHeight = -1
            Me.DataGridViewForm_Export.Visible = False
            '
            'AdjustTimeSetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1207, 421)
            Me.Controls.Add(Me.DataGridViewForm_Export)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.DataGridViewMain_TimeRecords)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "AdjustTimeSetupForm"
            Me.Text = "Adjust Time"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.RibbonBarOptions_Search.ResumeLayout(False)
            CType(Me.SearchableComboBoxSearch_ClientOrEmployee.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBox1ViewSearch_ClientOrEmployee, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxSearch_Job.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBox1ViewSearch_Job, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxSearch_JobComp.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBox1ViewSearch_JobComp, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerDates_From, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerDates_To, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents RibbonBarOptions_Search As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Save As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemSearchFilter_ByJob As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ItemContainerSearch_SearchFilter As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemSearchFilter_ByEmployee As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents DataGridViewMain_TimeRecords As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents SearchableComboBoxSearch_ClientOrEmployee As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBox1ViewSearch_ClientOrEmployee As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxSearch_Job As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBox1ViewSearch_Job As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents ItemContainerSearch_Main As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ItemContainerMain_Main As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ItemContainerMain_Top As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemMain_ClientOrEmployee As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ControlContainerItemMain_ClientOrEmployee As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ItemContainerMain_Middle As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemMain_Job As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ControlContainerItemMain_Job As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ItemContainerSearch_Dates As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ItemContainerDates_Dates As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ItemContainerDates_Top As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemDates_From As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ControlContainerItemDates_From As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ItemContainerDates_Bottom As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemDates_To As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ControlContainerItemDates_To As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents DateTimePickerDates_To As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerDates_From As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents ButtonItemSearch_Search As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_MarkBillable As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_MarkNonBillable As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_FeeTime As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemFeeTime_No As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemFeeTime_TimeAgainstFee As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemFeeTime_TimeAgainstCommissionP As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemFeeTime_TimeAgainstCommissionM As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_UpdateRate As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_ShowDescriptions As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_DeptTeam As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ItemContainerMain_Bottom As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemMain_JobComp As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ControlContainerItemMain_JobComp As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents SearchableComboBoxSearch_JobComp As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBox1ViewSearch_JobComp As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents ButtonItemActions_Export As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ItemContainer1 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents CheckBoxItemSearch_IncludeBilledTime As DevComponents.DotNetBar.CheckBoxItem
        Friend WithEvents ButtonItemDeptTeam_FromList As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemDeptTeam_FromHRHistory As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_EmployeeTitle As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemEmployeeTitle_FromList As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemEmployeeTitle_FromHRHistory As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents DataGridViewForm_Export As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
    End Class

End Namespace