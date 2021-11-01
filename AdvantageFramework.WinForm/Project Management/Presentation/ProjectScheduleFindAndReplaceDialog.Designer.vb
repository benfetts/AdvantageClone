Namespace ProjectManagement.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ProjectScheduleFindAndReplaceDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProjectScheduleFindAndReplaceDialog))
            Me.ButtonForm_Close = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_Field = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_SearchFor = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ButtonForm_ReplaceAll = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_ReplaceWith = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DateTimePickerForm_SearchForDateFrom = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerForm_ReplaceWithDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerForm_SearchForDateTo = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelForm_To = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_FieldName = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_Task = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxForm_Task = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView5 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxForm_ReplaceWith = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView1 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxForm_SearchFor = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView2 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.TextBoxForm_SearchFor = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxForm_ReplaceWith = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxForm_Log = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.PanelForm_Form = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.PanelForm_TopSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.PanelForm_BottomSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            CType(Me.DateTimePickerForm_SearchForDateFrom, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerForm_ReplaceWithDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerForm_SearchForDateTo, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxForm_Task.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxForm_ReplaceWith.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxForm_SearchFor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            CType(Me.PanelForm_TopSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_TopSection.SuspendLayout()
            CType(Me.PanelForm_BottomSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_BottomSection.SuspendLayout()
            Me.SuspendLayout()
            '
            'ButtonForm_Close
            '
            Me.ButtonForm_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Close.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Close.Location = New System.Drawing.Point(256, 202)
            Me.ButtonForm_Close.Name = "ButtonForm_Close"
            Me.ButtonForm_Close.SecurityEnabled = True
            Me.ButtonForm_Close.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Close.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Close.TabIndex = 14
            Me.ButtonForm_Close.Text = "Close"
            '
            'LabelForm_Field
            '
            Me.LabelForm_Field.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Field.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Field.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_Field.Name = "LabelForm_Field"
            Me.LabelForm_Field.Size = New System.Drawing.Size(78, 20)
            Me.LabelForm_Field.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Field.TabIndex = 0
            Me.LabelForm_Field.Text = "Field:"
            '
            'LabelForm_SearchFor
            '
            Me.LabelForm_SearchFor.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_SearchFor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_SearchFor.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_SearchFor.Name = "LabelForm_SearchFor"
            Me.LabelForm_SearchFor.Size = New System.Drawing.Size(78, 20)
            Me.LabelForm_SearchFor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_SearchFor.TabIndex = 2
            Me.LabelForm_SearchFor.Text = "Search for:"
            '
            'ButtonForm_ReplaceAll
            '
            Me.ButtonForm_ReplaceAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_ReplaceAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_ReplaceAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_ReplaceAll.Location = New System.Drawing.Point(175, 202)
            Me.ButtonForm_ReplaceAll.Name = "ButtonForm_ReplaceAll"
            Me.ButtonForm_ReplaceAll.SecurityEnabled = True
            Me.ButtonForm_ReplaceAll.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_ReplaceAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_ReplaceAll.TabIndex = 13
            Me.ButtonForm_ReplaceAll.Text = "Replace All"
            '
            'LabelForm_ReplaceWith
            '
            Me.LabelForm_ReplaceWith.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_ReplaceWith.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_ReplaceWith.Location = New System.Drawing.Point(12, 64)
            Me.LabelForm_ReplaceWith.Name = "LabelForm_ReplaceWith"
            Me.LabelForm_ReplaceWith.Size = New System.Drawing.Size(78, 20)
            Me.LabelForm_ReplaceWith.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ReplaceWith.TabIndex = 8
            Me.LabelForm_ReplaceWith.Text = "Replace with:"
            '
            'DateTimePickerForm_SearchForDateFrom
            '
            Me.DateTimePickerForm_SearchForDateFrom.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerForm_SearchForDateFrom.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerForm_SearchForDateFrom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_SearchForDateFrom.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerForm_SearchForDateFrom.ButtonDropDown.Visible = True
            Me.DateTimePickerForm_SearchForDateFrom.ButtonFreeText.Checked = True
            Me.DateTimePickerForm_SearchForDateFrom.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerForm_SearchForDateFrom.CustomFormat = ""
            Me.DateTimePickerForm_SearchForDateFrom.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerForm_SearchForDateFrom.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerForm_SearchForDateFrom.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerForm_SearchForDateFrom.FocusHighlightEnabled = True
            Me.DateTimePickerForm_SearchForDateFrom.Format = DevComponents.Editors.eDateTimePickerFormat.Short
            Me.DateTimePickerForm_SearchForDateFrom.FreeTextEntryMode = True
            Me.DateTimePickerForm_SearchForDateFrom.IsPopupCalendarOpen = False
            Me.DateTimePickerForm_SearchForDateFrom.Location = New System.Drawing.Point(96, 38)
            Me.DateTimePickerForm_SearchForDateFrom.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerForm_SearchForDateFrom.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerForm_SearchForDateFrom.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_SearchForDateFrom.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerForm_SearchForDateFrom.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerForm_SearchForDateFrom.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerForm_SearchForDateFrom.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_SearchForDateFrom.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerForm_SearchForDateFrom.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerForm_SearchForDateFrom.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerForm_SearchForDateFrom.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerForm_SearchForDateFrom.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_SearchForDateFrom.MonthCalendar.DisplayMonth = New Date(2013, 12, 1, 0, 0, 0, 0)
            Me.DateTimePickerForm_SearchForDateFrom.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerForm_SearchForDateFrom.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerForm_SearchForDateFrom.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerForm_SearchForDateFrom.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_SearchForDateFrom.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerForm_SearchForDateFrom.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_SearchForDateFrom.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerForm_SearchForDateFrom.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerForm_SearchForDateFrom.Name = "DateTimePickerForm_SearchForDateFrom"
            Me.DateTimePickerForm_SearchForDateFrom.ReadOnly = False
            Me.DateTimePickerForm_SearchForDateFrom.Size = New System.Drawing.Size(102, 20)
            Me.DateTimePickerForm_SearchForDateFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_SearchForDateFrom.TabIndex = 3
            Me.DateTimePickerForm_SearchForDateFrom.Value = New Date(2013, 12, 16, 16, 1, 13, 120)
            '
            'DateTimePickerForm_ReplaceWithDate
            '
            Me.DateTimePickerForm_ReplaceWithDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerForm_ReplaceWithDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerForm_ReplaceWithDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_ReplaceWithDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerForm_ReplaceWithDate.ButtonDropDown.Visible = True
            Me.DateTimePickerForm_ReplaceWithDate.ButtonFreeText.Checked = True
            Me.DateTimePickerForm_ReplaceWithDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerForm_ReplaceWithDate.CustomFormat = ""
            Me.DateTimePickerForm_ReplaceWithDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerForm_ReplaceWithDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerForm_ReplaceWithDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerForm_ReplaceWithDate.FocusHighlightEnabled = True
            Me.DateTimePickerForm_ReplaceWithDate.Format = DevComponents.Editors.eDateTimePickerFormat.Short
            Me.DateTimePickerForm_ReplaceWithDate.FreeTextEntryMode = True
            Me.DateTimePickerForm_ReplaceWithDate.IsPopupCalendarOpen = False
            Me.DateTimePickerForm_ReplaceWithDate.Location = New System.Drawing.Point(96, 64)
            Me.DateTimePickerForm_ReplaceWithDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerForm_ReplaceWithDate.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerForm_ReplaceWithDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_ReplaceWithDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerForm_ReplaceWithDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerForm_ReplaceWithDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerForm_ReplaceWithDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_ReplaceWithDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerForm_ReplaceWithDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerForm_ReplaceWithDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerForm_ReplaceWithDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerForm_ReplaceWithDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_ReplaceWithDate.MonthCalendar.DisplayMonth = New Date(2013, 12, 1, 0, 0, 0, 0)
            Me.DateTimePickerForm_ReplaceWithDate.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerForm_ReplaceWithDate.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerForm_ReplaceWithDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerForm_ReplaceWithDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_ReplaceWithDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerForm_ReplaceWithDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_ReplaceWithDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerForm_ReplaceWithDate.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerForm_ReplaceWithDate.Name = "DateTimePickerForm_ReplaceWithDate"
            Me.DateTimePickerForm_ReplaceWithDate.ReadOnly = False
            Me.DateTimePickerForm_ReplaceWithDate.Size = New System.Drawing.Size(102, 20)
            Me.DateTimePickerForm_ReplaceWithDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_ReplaceWithDate.TabIndex = 9
            Me.DateTimePickerForm_ReplaceWithDate.Value = New Date(2013, 12, 16, 16, 1, 13, 138)
            '
            'DateTimePickerForm_SearchForDateTo
            '
            Me.DateTimePickerForm_SearchForDateTo.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerForm_SearchForDateTo.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerForm_SearchForDateTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_SearchForDateTo.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerForm_SearchForDateTo.ButtonDropDown.Visible = True
            Me.DateTimePickerForm_SearchForDateTo.ButtonFreeText.Checked = True
            Me.DateTimePickerForm_SearchForDateTo.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerForm_SearchForDateTo.CustomFormat = ""
            Me.DateTimePickerForm_SearchForDateTo.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerForm_SearchForDateTo.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerForm_SearchForDateTo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerForm_SearchForDateTo.FocusHighlightEnabled = True
            Me.DateTimePickerForm_SearchForDateTo.Format = DevComponents.Editors.eDateTimePickerFormat.Short
            Me.DateTimePickerForm_SearchForDateTo.FreeTextEntryMode = True
            Me.DateTimePickerForm_SearchForDateTo.IsPopupCalendarOpen = False
            Me.DateTimePickerForm_SearchForDateTo.Location = New System.Drawing.Point(229, 38)
            Me.DateTimePickerForm_SearchForDateTo.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerForm_SearchForDateTo.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerForm_SearchForDateTo.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_SearchForDateTo.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerForm_SearchForDateTo.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerForm_SearchForDateTo.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerForm_SearchForDateTo.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_SearchForDateTo.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerForm_SearchForDateTo.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerForm_SearchForDateTo.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerForm_SearchForDateTo.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerForm_SearchForDateTo.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_SearchForDateTo.MonthCalendar.DisplayMonth = New Date(2013, 12, 1, 0, 0, 0, 0)
            Me.DateTimePickerForm_SearchForDateTo.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerForm_SearchForDateTo.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerForm_SearchForDateTo.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerForm_SearchForDateTo.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_SearchForDateTo.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerForm_SearchForDateTo.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_SearchForDateTo.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerForm_SearchForDateTo.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerForm_SearchForDateTo.Name = "DateTimePickerForm_SearchForDateTo"
            Me.DateTimePickerForm_SearchForDateTo.ReadOnly = False
            Me.DateTimePickerForm_SearchForDateTo.Size = New System.Drawing.Size(102, 20)
            Me.DateTimePickerForm_SearchForDateTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_SearchForDateTo.TabIndex = 5
            Me.DateTimePickerForm_SearchForDateTo.Value = New Date(2013, 12, 16, 16, 1, 13, 155)
            '
            'LabelForm_To
            '
            Me.LabelForm_To.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_To.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_To.Location = New System.Drawing.Point(204, 38)
            Me.LabelForm_To.Name = "LabelForm_To"
            Me.LabelForm_To.Size = New System.Drawing.Size(19, 20)
            Me.LabelForm_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_To.TabIndex = 4
            Me.LabelForm_To.Text = "to"
            '
            'ComboBoxForm_FieldName
            '
            Me.ComboBoxForm_FieldName.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_FieldName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_FieldName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_FieldName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_FieldName.AutoFindItemInDataSource = False
            Me.ComboBoxForm_FieldName.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_FieldName.BookmarkingEnabled = False
            Me.ComboBoxForm_FieldName.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumDataTable
            Me.ComboBoxForm_FieldName.DisableMouseWheel = False
            Me.ComboBoxForm_FieldName.DisplayMember = "Name"
            Me.ComboBoxForm_FieldName.DisplayName = ""
            Me.ComboBoxForm_FieldName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_FieldName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_FieldName.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_FieldName.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_FieldName.FocusHighlightEnabled = True
            Me.ComboBoxForm_FieldName.FormattingEnabled = True
            Me.ComboBoxForm_FieldName.ItemHeight = 14
            Me.ComboBoxForm_FieldName.Location = New System.Drawing.Point(96, 12)
            Me.ComboBoxForm_FieldName.Name = "ComboBoxForm_FieldName"
            Me.ComboBoxForm_FieldName.PreventEnterBeep = False
            Me.ComboBoxForm_FieldName.ReadOnly = False
            Me.ComboBoxForm_FieldName.SecurityEnabled = True
            Me.ComboBoxForm_FieldName.Size = New System.Drawing.Size(235, 20)
            Me.ComboBoxForm_FieldName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_FieldName.TabIndex = 1
            Me.ComboBoxForm_FieldName.ValueMember = "Value"
            Me.ComboBoxForm_FieldName.WatermarkText = "Select"
            '
            'LabelForm_Task
            '
            Me.LabelForm_Task.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Task.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Task.Location = New System.Drawing.Point(0, 0)
            Me.LabelForm_Task.Name = "LabelForm_Task"
            Me.LabelForm_Task.Size = New System.Drawing.Size(78, 20)
            Me.LabelForm_Task.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Task.TabIndex = 0
            Me.LabelForm_Task.Text = "Task:"
            '
            'SearchableComboBoxForm_Task
            '
            Me.SearchableComboBoxForm_Task.ActiveFilterString = ""
            Me.SearchableComboBoxForm_Task.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxForm_Task.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxForm_Task.BookmarkingEnabled = False
            Me.SearchableComboBoxForm_Task.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.[Default]
            Me.SearchableComboBoxForm_Task.DataSource = Nothing
            Me.SearchableComboBoxForm_Task.DisableMouseWheel = False
            Me.SearchableComboBoxForm_Task.DisplayName = ""
            Me.SearchableComboBoxForm_Task.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxForm_Task.Location = New System.Drawing.Point(84, 0)
            Me.SearchableComboBoxForm_Task.Name = "SearchableComboBoxForm_Task"
            Me.SearchableComboBoxForm_Task.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxForm_Task.Properties.NullText = ""
            Me.SearchableComboBoxForm_Task.Properties.ShowClearButton = False
            Me.SearchableComboBoxForm_Task.Properties.View = Me.GridView5
            Me.SearchableComboBoxForm_Task.SecurityEnabled = True
            Me.SearchableComboBoxForm_Task.SelectedValue = Nothing
            Me.SearchableComboBoxForm_Task.Size = New System.Drawing.Size(235, 20)
            Me.SearchableComboBoxForm_Task.TabIndex = 1
            '
            'GridView5
            '
            Me.GridView5.AFActiveFilterString = ""
            Me.GridView5.AllowExtraItemsInGridLookupEdits = True
            Me.GridView5.AutoFilterLookupColumns = False
            Me.GridView5.AutoloadRepositoryDatasource = True
            Me.GridView5.DataSourceClearing = False
            Me.GridView5.EnableDisabledRows = False
            Me.GridView5.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView5.Name = "GridView5"
            Me.GridView5.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView5.OptionsView.ShowGroupPanel = False
            Me.GridView5.RunStandardValidation = True
            '
            'SearchableComboBoxForm_ReplaceWith
            '
            Me.SearchableComboBoxForm_ReplaceWith.ActiveFilterString = ""
            Me.SearchableComboBoxForm_ReplaceWith.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxForm_ReplaceWith.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxForm_ReplaceWith.BookmarkingEnabled = False
            Me.SearchableComboBoxForm_ReplaceWith.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Employee
            Me.SearchableComboBoxForm_ReplaceWith.DataSource = Nothing
            Me.SearchableComboBoxForm_ReplaceWith.DisableMouseWheel = False
            Me.SearchableComboBoxForm_ReplaceWith.DisplayName = ""
            Me.SearchableComboBoxForm_ReplaceWith.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxForm_ReplaceWith.Location = New System.Drawing.Point(96, 64)
            Me.SearchableComboBoxForm_ReplaceWith.Name = "SearchableComboBoxForm_ReplaceWith"
            Me.SearchableComboBoxForm_ReplaceWith.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxForm_ReplaceWith.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxForm_ReplaceWith.Properties.NullText = "Select Employee"
            Me.SearchableComboBoxForm_ReplaceWith.Properties.ShowClearButton = False
            Me.SearchableComboBoxForm_ReplaceWith.Properties.ValueMember = "Code"
            Me.SearchableComboBoxForm_ReplaceWith.Properties.View = Me.GridView1
            Me.SearchableComboBoxForm_ReplaceWith.SecurityEnabled = True
            Me.SearchableComboBoxForm_ReplaceWith.SelectedValue = Nothing
            Me.SearchableComboBoxForm_ReplaceWith.Size = New System.Drawing.Size(235, 20)
            Me.SearchableComboBoxForm_ReplaceWith.TabIndex = 10
            '
            'GridView1
            '
            Me.GridView1.AFActiveFilterString = ""
            Me.GridView1.AllowExtraItemsInGridLookupEdits = True
            Me.GridView1.AutoFilterLookupColumns = False
            Me.GridView1.AutoloadRepositoryDatasource = True
            Me.GridView1.DataSourceClearing = False
            Me.GridView1.EnableDisabledRows = False
            Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView1.Name = "GridView1"
            Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView1.OptionsView.ShowGroupPanel = False
            Me.GridView1.RunStandardValidation = True
            '
            'SearchableComboBoxForm_SearchFor
            '
            Me.SearchableComboBoxForm_SearchFor.ActiveFilterString = ""
            Me.SearchableComboBoxForm_SearchFor.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxForm_SearchFor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxForm_SearchFor.BookmarkingEnabled = False
            Me.SearchableComboBoxForm_SearchFor.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Employee
            Me.SearchableComboBoxForm_SearchFor.DataSource = Nothing
            Me.SearchableComboBoxForm_SearchFor.DisableMouseWheel = False
            Me.SearchableComboBoxForm_SearchFor.DisplayName = ""
            Me.SearchableComboBoxForm_SearchFor.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxForm_SearchFor.Location = New System.Drawing.Point(96, 38)
            Me.SearchableComboBoxForm_SearchFor.Name = "SearchableComboBoxForm_SearchFor"
            Me.SearchableComboBoxForm_SearchFor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxForm_SearchFor.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxForm_SearchFor.Properties.NullText = "Select Employee"
            Me.SearchableComboBoxForm_SearchFor.Properties.ShowClearButton = False
            Me.SearchableComboBoxForm_SearchFor.Properties.ValueMember = "Code"
            Me.SearchableComboBoxForm_SearchFor.Properties.View = Me.GridView2
            Me.SearchableComboBoxForm_SearchFor.SecurityEnabled = True
            Me.SearchableComboBoxForm_SearchFor.SelectedValue = Nothing
            Me.SearchableComboBoxForm_SearchFor.Size = New System.Drawing.Size(235, 20)
            Me.SearchableComboBoxForm_SearchFor.TabIndex = 6
            '
            'GridView2
            '
            Me.GridView2.AFActiveFilterString = ""
            Me.GridView2.AllowExtraItemsInGridLookupEdits = True
            Me.GridView2.AutoFilterLookupColumns = False
            Me.GridView2.AutoloadRepositoryDatasource = True
            Me.GridView2.DataSourceClearing = False
            Me.GridView2.EnableDisabledRows = False
            Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView2.Name = "GridView2"
            Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView2.OptionsView.ShowGroupPanel = False
            Me.GridView2.RunStandardValidation = True
            '
            'TextBoxForm_SearchFor
            '
            Me.TextBoxForm_SearchFor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxForm_SearchFor.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_SearchFor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_SearchFor.CheckSpellingOnValidate = False
            Me.TextBoxForm_SearchFor.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_SearchFor.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_SearchFor.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_SearchFor.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_SearchFor.FocusHighlightEnabled = True
            Me.TextBoxForm_SearchFor.Location = New System.Drawing.Point(96, 38)
            Me.TextBoxForm_SearchFor.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_SearchFor.Name = "TextBoxForm_SearchFor"
            Me.TextBoxForm_SearchFor.PreventEnterBeep = False
            Me.TextBoxForm_SearchFor.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_SearchFor.Size = New System.Drawing.Size(235, 20)
            Me.TextBoxForm_SearchFor.StartingFolderName = Nothing
            Me.TextBoxForm_SearchFor.TabIndex = 7
            Me.TextBoxForm_SearchFor.TabOnEnter = True
            '
            'TextBoxForm_ReplaceWith
            '
            Me.TextBoxForm_ReplaceWith.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxForm_ReplaceWith.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_ReplaceWith.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_ReplaceWith.CheckSpellingOnValidate = False
            Me.TextBoxForm_ReplaceWith.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_ReplaceWith.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_ReplaceWith.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_ReplaceWith.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_ReplaceWith.FocusHighlightEnabled = True
            Me.TextBoxForm_ReplaceWith.Location = New System.Drawing.Point(96, 64)
            Me.TextBoxForm_ReplaceWith.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_ReplaceWith.Name = "TextBoxForm_ReplaceWith"
            Me.TextBoxForm_ReplaceWith.PreventEnterBeep = False
            Me.TextBoxForm_ReplaceWith.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_ReplaceWith.Size = New System.Drawing.Size(235, 20)
            Me.TextBoxForm_ReplaceWith.StartingFolderName = Nothing
            Me.TextBoxForm_ReplaceWith.TabIndex = 11
            Me.TextBoxForm_ReplaceWith.TabOnEnter = True
            '
            'TextBoxForm_Log
            '
            '
            '
            '
            Me.TextBoxForm_Log.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Log.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Log.CheckSpellingOnValidate = False
            Me.TextBoxForm_Log.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Log.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TextBoxForm_Log.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_Log.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Log.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Log.FocusHighlightEnabled = True
            Me.TextBoxForm_Log.Location = New System.Drawing.Point(0, 0)
            Me.TextBoxForm_Log.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Log.Multiline = True
            Me.TextBoxForm_Log.Name = "TextBoxForm_Log"
            Me.TextBoxForm_Log.PreventEnterBeep = False
            Me.TextBoxForm_Log.ReadOnly = True
            Me.TextBoxForm_Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.TextBoxForm_Log.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Log.Size = New System.Drawing.Size(319, 80)
            Me.TextBoxForm_Log.StartingFolderName = Nothing
            Me.TextBoxForm_Log.TabIndex = 0
            Me.TextBoxForm_Log.TabOnEnter = True
            '
            'PanelForm_Form
            '
            Me.PanelForm_Form.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelForm_Form.Controls.Add(Me.PanelForm_BottomSection)
            Me.PanelForm_Form.Controls.Add(Me.PanelForm_TopSection)
            Me.PanelForm_Form.Location = New System.Drawing.Point(12, 90)
            Me.PanelForm_Form.Name = "PanelForm_Form"
            Me.PanelForm_Form.Size = New System.Drawing.Size(319, 106)
            Me.PanelForm_Form.TabIndex = 12
            '
            'PanelForm_TopSection
            '
            Me.PanelForm_TopSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelForm_TopSection.Controls.Add(Me.LabelForm_Task)
            Me.PanelForm_TopSection.Controls.Add(Me.SearchableComboBoxForm_Task)
            Me.PanelForm_TopSection.Dock = System.Windows.Forms.DockStyle.Top
            Me.PanelForm_TopSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_TopSection.Name = "PanelForm_TopSection"
            Me.PanelForm_TopSection.Size = New System.Drawing.Size(319, 26)
            Me.PanelForm_TopSection.TabIndex = 0
            '
            'PanelForm_BottomSection
            '
            Me.PanelForm_BottomSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelForm_BottomSection.Controls.Add(Me.TextBoxForm_Log)
            Me.PanelForm_BottomSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_BottomSection.Location = New System.Drawing.Point(0, 26)
            Me.PanelForm_BottomSection.Name = "PanelForm_BottomSection"
            Me.PanelForm_BottomSection.Size = New System.Drawing.Size(319, 80)
            Me.PanelForm_BottomSection.TabIndex = 1
            '
            'ProjectScheduleFindAndReplaceDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(343, 234)
            Me.Controls.Add(Me.PanelForm_Form)
            Me.Controls.Add(Me.TextBoxForm_ReplaceWith)
            Me.Controls.Add(Me.TextBoxForm_SearchFor)
            Me.Controls.Add(Me.SearchableComboBoxForm_SearchFor)
            Me.Controls.Add(Me.SearchableComboBoxForm_ReplaceWith)
            Me.Controls.Add(Me.ComboBoxForm_FieldName)
            Me.Controls.Add(Me.LabelForm_To)
            Me.Controls.Add(Me.DateTimePickerForm_SearchForDateTo)
            Me.Controls.Add(Me.DateTimePickerForm_ReplaceWithDate)
            Me.Controls.Add(Me.DateTimePickerForm_SearchForDateFrom)
            Me.Controls.Add(Me.LabelForm_ReplaceWith)
            Me.Controls.Add(Me.ButtonForm_ReplaceAll)
            Me.Controls.Add(Me.LabelForm_SearchFor)
            Me.Controls.Add(Me.LabelForm_Field)
            Me.Controls.Add(Me.ButtonForm_Close)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ProjectScheduleFindAndReplaceDialog"
            Me.Text = "Search and Replace"
            CType(Me.DateTimePickerForm_SearchForDateFrom, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerForm_ReplaceWithDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerForm_SearchForDateTo, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxForm_Task.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxForm_ReplaceWith.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxForm_SearchFor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            CType(Me.PanelForm_TopSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_TopSection.ResumeLayout(False)
            CType(Me.PanelForm_BottomSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_BottomSection.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Close As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_Field As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_SearchFor As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonForm_ReplaceAll As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_ReplaceWith As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerForm_SearchForDateFrom As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerForm_ReplaceWithDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerForm_SearchForDateTo As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents LabelForm_To As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_FieldName As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_Task As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxForm_Task As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView5 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxForm_ReplaceWith As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView1 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxForm_SearchFor As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView2 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents TextBoxForm_SearchFor As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxForm_ReplaceWith As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxForm_Log As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents PanelForm_Form As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelForm_BottomSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelForm_TopSection As AdvantageFramework.WinForm.Presentation.Controls.Panel

    End Class

End Namespace