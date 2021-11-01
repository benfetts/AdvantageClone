Namespace Media.Presentation

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
	Partial Class MediaPlanDetailLevelLineDataDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaPlanDetailLevelLineDataDialog))
            Me.DataGridViewForm_LevelLineData = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DateTimePickerForm_To = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerForm_From = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelForm_To = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_From = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Line = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_LineData = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ButtonForm_Update = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonItemUpdate_AllRows = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemUpdate_SelectedRows = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonForm_Allocate = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonItemAllocate_AllRows = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemAllocate_SelectedRows = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonForm_Copy = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_SelectAll = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonItemSelectAll_Sunday = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemSelectAll_Monday = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemSelectAll_Tuesday = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemSelectAll_Wednesday = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemSelectAll_Thursday = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemSelectAll_Friday = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemSelectAll_Saturday = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonForm_DeselectAll = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonItemDeselectAll_Sunday = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemDeselectAll_Monday = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemDeselectAll_Tuesday = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemDeselectAll_Wednesday = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemDeselectAll_Thursday = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemDeselectAll_Friday = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemDeselectAll_Saturday = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonForm_Update4WeekStartDate = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_AddRow = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_PeriodType = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            CType(Me.DateTimePickerForm_To, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerForm_From, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'DataGridViewForm_LevelLineData
            '
            Me.DataGridViewForm_LevelLineData.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_LevelLineData.AllowDragAndDrop = False
            Me.DataGridViewForm_LevelLineData.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_LevelLineData.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_LevelLineData.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_LevelLineData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_LevelLineData.AutoFilterLookupColumns = False
            Me.DataGridViewForm_LevelLineData.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_LevelLineData.AutoUpdateViewCaption = True
            Me.DataGridViewForm_LevelLineData.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_LevelLineData.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_LevelLineData.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_LevelLineData.ItemDescription = "Data Line(s)"
            Me.DataGridViewForm_LevelLineData.Location = New System.Drawing.Point(12, 64)
            Me.DataGridViewForm_LevelLineData.MultiSelect = True
            Me.DataGridViewForm_LevelLineData.Name = "DataGridViewForm_LevelLineData"
            Me.DataGridViewForm_LevelLineData.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_LevelLineData.RunStandardValidation = True
            Me.DataGridViewForm_LevelLineData.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_LevelLineData.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_LevelLineData.Size = New System.Drawing.Size(689, 319)
            Me.DataGridViewForm_LevelLineData.TabIndex = 8
            Me.DataGridViewForm_LevelLineData.UseEmbeddedNavigator = False
            Me.DataGridViewForm_LevelLineData.ViewCaptionHeight = -1
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(626, 389)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 14
            Me.ButtonForm_OK.Text = "OK"
            '
            'DateTimePickerForm_To
            '
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
            Me.DateTimePickerForm_To.Location = New System.Drawing.Point(198, 38)
            Me.DateTimePickerForm_To.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerForm_To.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
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
            Me.DateTimePickerForm_To.MonthCalendar.DisplayMonth = New Date(2012, 12, 1, 0, 0, 0, 0)
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
            Me.DateTimePickerForm_To.Size = New System.Drawing.Size(100, 20)
            Me.DateTimePickerForm_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_To.TabIndex = 5
            Me.DateTimePickerForm_To.TabOnEnter = True
            Me.DateTimePickerForm_To.Value = New Date(2015, 4, 7, 10, 20, 51, 91)
            '
            'DateTimePickerForm_From
            '
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
            Me.DateTimePickerForm_From.Location = New System.Drawing.Point(52, 38)
            Me.DateTimePickerForm_From.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerForm_From.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
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
            Me.DateTimePickerForm_From.MonthCalendar.DisplayMonth = New Date(2012, 12, 1, 0, 0, 0, 0)
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
            Me.DateTimePickerForm_From.Size = New System.Drawing.Size(100, 20)
            Me.DateTimePickerForm_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_From.TabIndex = 3
            Me.DateTimePickerForm_From.TabOnEnter = True
            Me.DateTimePickerForm_From.Value = New Date(2015, 4, 7, 10, 20, 51, 128)
            '
            'LabelForm_To
            '
            Me.LabelForm_To.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_To.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_To.Location = New System.Drawing.Point(158, 38)
            Me.LabelForm_To.Name = "LabelForm_To"
            Me.LabelForm_To.Size = New System.Drawing.Size(34, 20)
            Me.LabelForm_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_To.TabIndex = 4
            Me.LabelForm_To.Text = "To:"
            '
            'LabelForm_From
            '
            Me.LabelForm_From.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_From.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_From.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_From.Name = "LabelForm_From"
            Me.LabelForm_From.Size = New System.Drawing.Size(34, 20)
            Me.LabelForm_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_From.TabIndex = 2
            Me.LabelForm_From.Text = "From:"
            '
            'LabelForm_Line
            '
            Me.LabelForm_Line.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Line.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Line.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_Line.Name = "LabelForm_Line"
            Me.LabelForm_Line.Size = New System.Drawing.Size(34, 20)
            Me.LabelForm_Line.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Line.TabIndex = 0
            Me.LabelForm_Line.Text = "Line:"
            '
            'LabelForm_LineData
            '
            Me.LabelForm_LineData.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_LineData.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_LineData.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_LineData.Location = New System.Drawing.Point(52, 12)
            Me.LabelForm_LineData.Name = "LabelForm_LineData"
            Me.LabelForm_LineData.Size = New System.Drawing.Size(649, 20)
            Me.LabelForm_LineData.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_LineData.TabIndex = 1
            '
            'ButtonForm_Update
            '
            Me.ButtonForm_Update.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Update.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Update.AutoExpandOnClick = True
            Me.ButtonForm_Update.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Update.Location = New System.Drawing.Point(93, 389)
            Me.ButtonForm_Update.Name = "ButtonForm_Update"
            Me.ButtonForm_Update.SecurityEnabled = True
            Me.ButtonForm_Update.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Update.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Update.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemUpdate_AllRows, Me.ButtonItemUpdate_SelectedRows})
            Me.ButtonForm_Update.TabIndex = 10
            Me.ButtonForm_Update.Text = "Update"
            '
            'ButtonItemUpdate_AllRows
            '
            Me.ButtonItemUpdate_AllRows.GlobalItem = False
            Me.ButtonItemUpdate_AllRows.Name = "ButtonItemUpdate_AllRows"
            Me.ButtonItemUpdate_AllRows.Text = "All Rows"
            '
            'ButtonItemUpdate_SelectedRows
            '
            Me.ButtonItemUpdate_SelectedRows.GlobalItem = False
            Me.ButtonItemUpdate_SelectedRows.Name = "ButtonItemUpdate_SelectedRows"
            Me.ButtonItemUpdate_SelectedRows.Text = "Selected Rows"
            '
            'ButtonForm_Allocate
            '
            Me.ButtonForm_Allocate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Allocate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Allocate.AutoExpandOnClick = True
            Me.ButtonForm_Allocate.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Allocate.Location = New System.Drawing.Point(12, 389)
            Me.ButtonForm_Allocate.Name = "ButtonForm_Allocate"
            Me.ButtonForm_Allocate.SecurityEnabled = True
            Me.ButtonForm_Allocate.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Allocate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Allocate.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemAllocate_AllRows, Me.ButtonItemAllocate_SelectedRows})
            Me.ButtonForm_Allocate.TabIndex = 9
            Me.ButtonForm_Allocate.Text = "Allocate"
            '
            'ButtonItemAllocate_AllRows
            '
            Me.ButtonItemAllocate_AllRows.GlobalItem = False
            Me.ButtonItemAllocate_AllRows.Name = "ButtonItemAllocate_AllRows"
            Me.ButtonItemAllocate_AllRows.Text = "All Rows"
            '
            'ButtonItemAllocate_SelectedRows
            '
            Me.ButtonItemAllocate_SelectedRows.GlobalItem = False
            Me.ButtonItemAllocate_SelectedRows.Name = "ButtonItemAllocate_SelectedRows"
            Me.ButtonItemAllocate_SelectedRows.Text = "Selected Rows"
            '
            'ButtonForm_Copy
            '
            Me.ButtonForm_Copy.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Copy.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Copy.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Copy.Location = New System.Drawing.Point(174, 389)
            Me.ButtonForm_Copy.Name = "ButtonForm_Copy"
            Me.ButtonForm_Copy.SecurityEnabled = True
            Me.ButtonForm_Copy.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Copy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Copy.TabIndex = 11
            Me.ButtonForm_Copy.Text = "Copy"
            '
            'ButtonForm_SelectAll
            '
            Me.ButtonForm_SelectAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_SelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_SelectAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_SelectAll.Location = New System.Drawing.Point(545, 38)
            Me.ButtonForm_SelectAll.Name = "ButtonForm_SelectAll"
            Me.ButtonForm_SelectAll.SecurityEnabled = True
            Me.ButtonForm_SelectAll.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_SelectAll.SplitButton = True
            Me.ButtonForm_SelectAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_SelectAll.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemSelectAll_Sunday, Me.ButtonItemSelectAll_Monday, Me.ButtonItemSelectAll_Tuesday, Me.ButtonItemSelectAll_Wednesday, Me.ButtonItemSelectAll_Thursday, Me.ButtonItemSelectAll_Friday, Me.ButtonItemSelectAll_Saturday})
            Me.ButtonForm_SelectAll.TabIndex = 6
            Me.ButtonForm_SelectAll.Text = "Select All"
            '
            'ButtonItemSelectAll_Sunday
            '
            Me.ButtonItemSelectAll_Sunday.GlobalItem = False
            Me.ButtonItemSelectAll_Sunday.Name = "ButtonItemSelectAll_Sunday"
            Me.ButtonItemSelectAll_Sunday.Text = "Sunday"
            '
            'ButtonItemSelectAll_Monday
            '
            Me.ButtonItemSelectAll_Monday.GlobalItem = False
            Me.ButtonItemSelectAll_Monday.Name = "ButtonItemSelectAll_Monday"
            Me.ButtonItemSelectAll_Monday.Text = "Monday"
            '
            'ButtonItemSelectAll_Tuesday
            '
            Me.ButtonItemSelectAll_Tuesday.GlobalItem = False
            Me.ButtonItemSelectAll_Tuesday.Name = "ButtonItemSelectAll_Tuesday"
            Me.ButtonItemSelectAll_Tuesday.Text = "Tuesday"
            '
            'ButtonItemSelectAll_Wednesday
            '
            Me.ButtonItemSelectAll_Wednesday.GlobalItem = False
            Me.ButtonItemSelectAll_Wednesday.Name = "ButtonItemSelectAll_Wednesday"
            Me.ButtonItemSelectAll_Wednesday.Text = "Wednesday"
            '
            'ButtonItemSelectAll_Thursday
            '
            Me.ButtonItemSelectAll_Thursday.GlobalItem = False
            Me.ButtonItemSelectAll_Thursday.Name = "ButtonItemSelectAll_Thursday"
            Me.ButtonItemSelectAll_Thursday.Text = "Thursday"
            '
            'ButtonItemSelectAll_Friday
            '
            Me.ButtonItemSelectAll_Friday.GlobalItem = False
            Me.ButtonItemSelectAll_Friday.Name = "ButtonItemSelectAll_Friday"
            Me.ButtonItemSelectAll_Friday.Text = "Friday"
            '
            'ButtonItemSelectAll_Saturday
            '
            Me.ButtonItemSelectAll_Saturday.GlobalItem = False
            Me.ButtonItemSelectAll_Saturday.Name = "ButtonItemSelectAll_Saturday"
            Me.ButtonItemSelectAll_Saturday.Text = "Saturday"
            '
            'ButtonForm_DeselectAll
            '
            Me.ButtonForm_DeselectAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_DeselectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_DeselectAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_DeselectAll.Location = New System.Drawing.Point(626, 38)
            Me.ButtonForm_DeselectAll.Name = "ButtonForm_DeselectAll"
            Me.ButtonForm_DeselectAll.SecurityEnabled = True
            Me.ButtonForm_DeselectAll.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_DeselectAll.SplitButton = True
            Me.ButtonForm_DeselectAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_DeselectAll.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDeselectAll_Sunday, Me.ButtonItemDeselectAll_Monday, Me.ButtonItemDeselectAll_Tuesday, Me.ButtonItemDeselectAll_Wednesday, Me.ButtonItemDeselectAll_Thursday, Me.ButtonItemDeselectAll_Friday, Me.ButtonItemDeselectAll_Saturday})
            Me.ButtonForm_DeselectAll.TabIndex = 7
            Me.ButtonForm_DeselectAll.Text = "Deselect All"
            '
            'ButtonItemDeselectAll_Sunday
            '
            Me.ButtonItemDeselectAll_Sunday.GlobalItem = False
            Me.ButtonItemDeselectAll_Sunday.Name = "ButtonItemDeselectAll_Sunday"
            Me.ButtonItemDeselectAll_Sunday.Text = "Sunday"
            '
            'ButtonItemDeselectAll_Monday
            '
            Me.ButtonItemDeselectAll_Monday.GlobalItem = False
            Me.ButtonItemDeselectAll_Monday.Name = "ButtonItemDeselectAll_Monday"
            Me.ButtonItemDeselectAll_Monday.Text = "Monday"
            '
            'ButtonItemDeselectAll_Tuesday
            '
            Me.ButtonItemDeselectAll_Tuesday.GlobalItem = False
            Me.ButtonItemDeselectAll_Tuesday.Name = "ButtonItemDeselectAll_Tuesday"
            Me.ButtonItemDeselectAll_Tuesday.Text = "Tuesday"
            '
            'ButtonItemDeselectAll_Wednesday
            '
            Me.ButtonItemDeselectAll_Wednesday.GlobalItem = False
            Me.ButtonItemDeselectAll_Wednesday.Name = "ButtonItemDeselectAll_Wednesday"
            Me.ButtonItemDeselectAll_Wednesday.Text = "Wednesday"
            '
            'ButtonItemDeselectAll_Thursday
            '
            Me.ButtonItemDeselectAll_Thursday.GlobalItem = False
            Me.ButtonItemDeselectAll_Thursday.Name = "ButtonItemDeselectAll_Thursday"
            Me.ButtonItemDeselectAll_Thursday.Text = "Thursday"
            '
            'ButtonItemDeselectAll_Friday
            '
            Me.ButtonItemDeselectAll_Friday.GlobalItem = False
            Me.ButtonItemDeselectAll_Friday.Name = "ButtonItemDeselectAll_Friday"
            Me.ButtonItemDeselectAll_Friday.Text = "Friday"
            '
            'ButtonItemDeselectAll_Saturday
            '
            Me.ButtonItemDeselectAll_Saturday.GlobalItem = False
            Me.ButtonItemDeselectAll_Saturday.Name = "ButtonItemDeselectAll_Saturday"
            Me.ButtonItemDeselectAll_Saturday.Text = "Saturday"
            '
            'ButtonForm_Update4WeekStartDate
            '
            Me.ButtonForm_Update4WeekStartDate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Update4WeekStartDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Update4WeekStartDate.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Update4WeekStartDate.Location = New System.Drawing.Point(336, 389)
            Me.ButtonForm_Update4WeekStartDate.Name = "ButtonForm_Update4WeekStartDate"
            Me.ButtonForm_Update4WeekStartDate.SecurityEnabled = True
            Me.ButtonForm_Update4WeekStartDate.Size = New System.Drawing.Size(155, 20)
            Me.ButtonForm_Update4WeekStartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Update4WeekStartDate.TabIndex = 13
            Me.ButtonForm_Update4WeekStartDate.Text = "Update 4 Week Start Date"
            '
            'ButtonForm_AddRow
            '
            Me.ButtonForm_AddRow.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_AddRow.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_AddRow.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_AddRow.Location = New System.Drawing.Point(255, 389)
            Me.ButtonForm_AddRow.Name = "ButtonForm_AddRow"
            Me.ButtonForm_AddRow.SecurityEnabled = True
            Me.ButtonForm_AddRow.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_AddRow.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_AddRow.TabIndex = 12
            Me.ButtonForm_AddRow.Text = "Add Row"
            '
            'LabelForm_PeriodType
            '
            Me.LabelForm_PeriodType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_PeriodType.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_PeriodType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_PeriodType.Location = New System.Drawing.Point(304, 38)
            Me.LabelForm_PeriodType.Name = "LabelForm_PeriodType"
            Me.LabelForm_PeriodType.Size = New System.Drawing.Size(235, 20)
            Me.LabelForm_PeriodType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_PeriodType.TabIndex = 15
            Me.LabelForm_PeriodType.Text = "Period Type: {0}"
            '
            'MediaPlanDetailLevelLineDataDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(713, 421)
            Me.Controls.Add(Me.LabelForm_PeriodType)
            Me.Controls.Add(Me.ButtonForm_AddRow)
            Me.Controls.Add(Me.ButtonForm_Update4WeekStartDate)
            Me.Controls.Add(Me.ButtonForm_DeselectAll)
            Me.Controls.Add(Me.ButtonForm_SelectAll)
            Me.Controls.Add(Me.ButtonForm_Copy)
            Me.Controls.Add(Me.ButtonForm_Update)
            Me.Controls.Add(Me.ButtonForm_Allocate)
            Me.Controls.Add(Me.LabelForm_LineData)
            Me.Controls.Add(Me.LabelForm_Line)
            Me.Controls.Add(Me.DateTimePickerForm_To)
            Me.Controls.Add(Me.DateTimePickerForm_From)
            Me.Controls.Add(Me.LabelForm_To)
            Me.Controls.Add(Me.LabelForm_From)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.DataGridViewForm_LevelLineData)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaPlanDetailLevelLineDataDialog"
            Me.Text = "Data Lines"
            CType(Me.DateTimePickerForm_To, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerForm_From, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewForm_LevelLineData As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
		Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
		Friend WithEvents DateTimePickerForm_To As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
		Friend WithEvents DateTimePickerForm_From As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
		Friend WithEvents LabelForm_To As AdvantageFramework.WinForm.Presentation.Controls.Label
		Friend WithEvents LabelForm_From As AdvantageFramework.WinForm.Presentation.Controls.Label
		Friend WithEvents LabelForm_Line As AdvantageFramework.WinForm.Presentation.Controls.Label
		Friend WithEvents LabelForm_LineData As AdvantageFramework.WinForm.Presentation.Controls.Label
		Friend WithEvents ButtonForm_Update As AdvantageFramework.WinForm.Presentation.Controls.Button
		Friend WithEvents ButtonItemUpdate_AllRows As DevComponents.DotNetBar.ButtonItem
		Friend WithEvents ButtonItemUpdate_SelectedRows As DevComponents.DotNetBar.ButtonItem
		Friend WithEvents ButtonForm_Allocate As AdvantageFramework.WinForm.Presentation.Controls.Button
		Friend WithEvents ButtonItemAllocate_AllRows As DevComponents.DotNetBar.ButtonItem
		Friend WithEvents ButtonItemAllocate_SelectedRows As DevComponents.DotNetBar.ButtonItem
		Friend WithEvents ButtonForm_Copy As AdvantageFramework.WinForm.Presentation.Controls.Button
		Friend WithEvents ButtonForm_SelectAll As AdvantageFramework.WinForm.Presentation.Controls.Button
		Friend WithEvents ButtonItemSelectAll_Sunday As DevComponents.DotNetBar.ButtonItem
		Friend WithEvents ButtonItemSelectAll_Monday As DevComponents.DotNetBar.ButtonItem
		Friend WithEvents ButtonItemSelectAll_Tuesday As DevComponents.DotNetBar.ButtonItem
		Friend WithEvents ButtonItemSelectAll_Wednesday As DevComponents.DotNetBar.ButtonItem
		Friend WithEvents ButtonItemSelectAll_Thursday As DevComponents.DotNetBar.ButtonItem
		Friend WithEvents ButtonItemSelectAll_Friday As DevComponents.DotNetBar.ButtonItem
		Friend WithEvents ButtonItemSelectAll_Saturday As DevComponents.DotNetBar.ButtonItem
		Friend WithEvents ButtonForm_DeselectAll As AdvantageFramework.WinForm.Presentation.Controls.Button
		Friend WithEvents ButtonItemDeselectAll_Sunday As DevComponents.DotNetBar.ButtonItem
		Friend WithEvents ButtonItemDeselectAll_Monday As DevComponents.DotNetBar.ButtonItem
		Friend WithEvents ButtonItemDeselectAll_Tuesday As DevComponents.DotNetBar.ButtonItem
		Friend WithEvents ButtonItemDeselectAll_Wednesday As DevComponents.DotNetBar.ButtonItem
		Friend WithEvents ButtonItemDeselectAll_Thursday As DevComponents.DotNetBar.ButtonItem
		Friend WithEvents ButtonItemDeselectAll_Friday As DevComponents.DotNetBar.ButtonItem
		Friend WithEvents ButtonItemDeselectAll_Saturday As DevComponents.DotNetBar.ButtonItem
		Friend WithEvents ButtonForm_Update4WeekStartDate As WinForm.Presentation.Controls.Button
		Friend WithEvents ButtonForm_AddRow As WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_PeriodType As WinForm.Presentation.Controls.Label
    End Class

End Namespace

