Namespace FinanceAndAccounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AccountsPayableBatchReportDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
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
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AccountsPayableBatchReportDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelFormDates_From = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelFormDates_To = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxForm_Format = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.RadioButtonFormat_DetailPageBreak = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonFormat_Summary = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonFormat_DetailNoPageBreak = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.DateTimePickerForm_From = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerForm_To = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.GroupBoxForm_Selection = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.RadioButtonSelection_ImportBatch = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelection_Import = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelection_DateRange = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelection_Batch = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.LabelForm_User = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_User = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_Batch = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_Batch = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.RadioButtonFormat_SummaryDataEntryOrder = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            CType(Me.GroupBoxForm_Format, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxForm_Format.SuspendLayout()
            CType(Me.DateTimePickerForm_From, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerForm_To, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxForm_Selection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxForm_Selection.SuspendLayout()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(130, 325)
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
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(211, 325)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 9
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'LabelFormDates_From
            '
            Me.LabelFormDates_From.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelFormDates_From.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelFormDates_From.Location = New System.Drawing.Point(12, 269)
            Me.LabelFormDates_From.Name = "LabelFormDates_From"
            Me.LabelFormDates_From.Size = New System.Drawing.Size(45, 20)
            Me.LabelFormDates_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelFormDates_From.TabIndex = 4
            Me.LabelFormDates_From.Text = "From:"
            '
            'LabelFormDates_To
            '
            Me.LabelFormDates_To.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelFormDates_To.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelFormDates_To.Location = New System.Drawing.Point(12, 295)
            Me.LabelFormDates_To.Name = "LabelFormDates_To"
            Me.LabelFormDates_To.Size = New System.Drawing.Size(45, 20)
            Me.LabelFormDates_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelFormDates_To.TabIndex = 6
            Me.LabelFormDates_To.Text = "To:"
            '
            'GroupBoxForm_Format
            '
            Me.GroupBoxForm_Format.Controls.Add(Me.RadioButtonFormat_SummaryDataEntryOrder)
            Me.GroupBoxForm_Format.Controls.Add(Me.RadioButtonFormat_DetailPageBreak)
            Me.GroupBoxForm_Format.Controls.Add(Me.RadioButtonFormat_Summary)
            Me.GroupBoxForm_Format.Controls.Add(Me.RadioButtonFormat_DetailNoPageBreak)
            Me.GroupBoxForm_Format.Location = New System.Drawing.Point(12, 102)
            Me.GroupBoxForm_Format.Name = "GroupBoxForm_Format"
            Me.GroupBoxForm_Format.Size = New System.Drawing.Size(274, 135)
            Me.GroupBoxForm_Format.TabIndex = 1
            Me.GroupBoxForm_Format.Text = "Format"
            '
            'RadioButtonFormat_DetailPageBreak
            '
            Me.RadioButtonFormat_DetailPageBreak.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonFormat_DetailPageBreak.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonFormat_DetailPageBreak.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonFormat_DetailPageBreak.Location = New System.Drawing.Point(5, 51)
            Me.RadioButtonFormat_DetailPageBreak.Name = "RadioButtonFormat_DetailPageBreak"
            Me.RadioButtonFormat_DetailPageBreak.SecurityEnabled = True
            Me.RadioButtonFormat_DetailPageBreak.Size = New System.Drawing.Size(264, 20)
            Me.RadioButtonFormat_DetailPageBreak.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonFormat_DetailPageBreak.TabIndex = 1
            Me.RadioButtonFormat_DetailPageBreak.TabOnEnter = True
            Me.RadioButtonFormat_DetailPageBreak.TabStop = False
            Me.RadioButtonFormat_DetailPageBreak.Text = "Detail - Page Break"
            '
            'RadioButtonFormat_Summary
            '
            Me.RadioButtonFormat_Summary.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonFormat_Summary.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonFormat_Summary.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonFormat_Summary.Location = New System.Drawing.Point(5, 77)
            Me.RadioButtonFormat_Summary.Name = "RadioButtonFormat_Summary"
            Me.RadioButtonFormat_Summary.SecurityEnabled = True
            Me.RadioButtonFormat_Summary.Size = New System.Drawing.Size(264, 20)
            Me.RadioButtonFormat_Summary.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonFormat_Summary.TabIndex = 2
            Me.RadioButtonFormat_Summary.TabOnEnter = True
            Me.RadioButtonFormat_Summary.TabStop = False
            Me.RadioButtonFormat_Summary.Text = "Summary"
            '
            'RadioButtonFormat_DetailNoPageBreak
            '
            Me.RadioButtonFormat_DetailNoPageBreak.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonFormat_DetailNoPageBreak.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonFormat_DetailNoPageBreak.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonFormat_DetailNoPageBreak.Checked = True
            Me.RadioButtonFormat_DetailNoPageBreak.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonFormat_DetailNoPageBreak.CheckValue = "Y"
            Me.RadioButtonFormat_DetailNoPageBreak.Location = New System.Drawing.Point(5, 25)
            Me.RadioButtonFormat_DetailNoPageBreak.Name = "RadioButtonFormat_DetailNoPageBreak"
            Me.RadioButtonFormat_DetailNoPageBreak.SecurityEnabled = True
            Me.RadioButtonFormat_DetailNoPageBreak.Size = New System.Drawing.Size(264, 20)
            Me.RadioButtonFormat_DetailNoPageBreak.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonFormat_DetailNoPageBreak.TabIndex = 0
            Me.RadioButtonFormat_DetailNoPageBreak.TabOnEnter = True
            Me.RadioButtonFormat_DetailNoPageBreak.Text = "Detail - No Page Break"
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
            Me.DateTimePickerForm_From.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePickerForm_From.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePickerForm_From.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerForm_From.DisplayName = ""
            Me.DateTimePickerForm_From.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerForm_From.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerForm_From.FocusHighlightEnabled = True
            Me.DateTimePickerForm_From.FreeTextEntryMode = True
            Me.DateTimePickerForm_From.IsPopupCalendarOpen = False
            Me.DateTimePickerForm_From.Location = New System.Drawing.Point(63, 269)
            Me.DateTimePickerForm_From.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerForm_From.MinDate = New Date(1970, 1, 1, 0, 0, 0, 0)
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
            Me.DateTimePickerForm_From.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
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
            Me.DateTimePickerForm_From.Size = New System.Drawing.Size(223, 20)
            Me.DateTimePickerForm_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_From.TabIndex = 5
            Me.DateTimePickerForm_From.TabOnEnter = True
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
            Me.DateTimePickerForm_To.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePickerForm_To.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePickerForm_To.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerForm_To.DisplayName = ""
            Me.DateTimePickerForm_To.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerForm_To.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerForm_To.FocusHighlightEnabled = True
            Me.DateTimePickerForm_To.FreeTextEntryMode = True
            Me.DateTimePickerForm_To.IsPopupCalendarOpen = False
            Me.DateTimePickerForm_To.Location = New System.Drawing.Point(63, 295)
            Me.DateTimePickerForm_To.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerForm_To.MinDate = New Date(1970, 1, 1, 0, 0, 0, 0)
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
            Me.DateTimePickerForm_To.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
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
            Me.DateTimePickerForm_To.Size = New System.Drawing.Size(223, 20)
            Me.DateTimePickerForm_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_To.TabIndex = 7
            Me.DateTimePickerForm_To.TabOnEnter = True
            '
            'GroupBoxForm_Selection
            '
            Me.GroupBoxForm_Selection.Controls.Add(Me.RadioButtonSelection_ImportBatch)
            Me.GroupBoxForm_Selection.Controls.Add(Me.RadioButtonSelection_Import)
            Me.GroupBoxForm_Selection.Controls.Add(Me.RadioButtonSelection_DateRange)
            Me.GroupBoxForm_Selection.Controls.Add(Me.RadioButtonSelection_Batch)
            Me.GroupBoxForm_Selection.Location = New System.Drawing.Point(12, 12)
            Me.GroupBoxForm_Selection.Name = "GroupBoxForm_Selection"
            Me.GroupBoxForm_Selection.Size = New System.Drawing.Size(274, 84)
            Me.GroupBoxForm_Selection.TabIndex = 0
            Me.GroupBoxForm_Selection.Text = "Selection"
            '
            'RadioButtonSelection_ImportBatch
            '
            Me.RadioButtonSelection_ImportBatch.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelection_ImportBatch.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelection_ImportBatch.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelection_ImportBatch.Location = New System.Drawing.Point(136, 24)
            Me.RadioButtonSelection_ImportBatch.Name = "RadioButtonSelection_ImportBatch"
            Me.RadioButtonSelection_ImportBatch.SecurityEnabled = True
            Me.RadioButtonSelection_ImportBatch.Size = New System.Drawing.Size(133, 20)
            Me.RadioButtonSelection_ImportBatch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelection_ImportBatch.TabIndex = 3
            Me.RadioButtonSelection_ImportBatch.TabOnEnter = True
            Me.RadioButtonSelection_ImportBatch.TabStop = False
            Me.RadioButtonSelection_ImportBatch.Text = "Import Batch"
            '
            'RadioButtonSelection_Import
            '
            Me.RadioButtonSelection_Import.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelection_Import.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelection_Import.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelection_Import.Location = New System.Drawing.Point(136, 51)
            Me.RadioButtonSelection_Import.Name = "RadioButtonSelection_Import"
            Me.RadioButtonSelection_Import.SecurityEnabled = True
            Me.RadioButtonSelection_Import.Size = New System.Drawing.Size(133, 20)
            Me.RadioButtonSelection_Import.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelection_Import.TabIndex = 2
            Me.RadioButtonSelection_Import.TabOnEnter = True
            Me.RadioButtonSelection_Import.TabStop = False
            Me.RadioButtonSelection_Import.Text = "Import"
            '
            'RadioButtonSelection_DateRange
            '
            Me.RadioButtonSelection_DateRange.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelection_DateRange.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelection_DateRange.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelection_DateRange.Location = New System.Drawing.Point(5, 51)
            Me.RadioButtonSelection_DateRange.Name = "RadioButtonSelection_DateRange"
            Me.RadioButtonSelection_DateRange.SecurityEnabled = True
            Me.RadioButtonSelection_DateRange.Size = New System.Drawing.Size(125, 20)
            Me.RadioButtonSelection_DateRange.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelection_DateRange.TabIndex = 1
            Me.RadioButtonSelection_DateRange.TabOnEnter = True
            Me.RadioButtonSelection_DateRange.TabStop = False
            Me.RadioButtonSelection_DateRange.Text = "Date Range"
            '
            'RadioButtonSelection_Batch
            '
            Me.RadioButtonSelection_Batch.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelection_Batch.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelection_Batch.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelection_Batch.Checked = True
            Me.RadioButtonSelection_Batch.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonSelection_Batch.CheckValue = "Y"
            Me.RadioButtonSelection_Batch.Location = New System.Drawing.Point(5, 25)
            Me.RadioButtonSelection_Batch.Name = "RadioButtonSelection_Batch"
            Me.RadioButtonSelection_Batch.SecurityEnabled = True
            Me.RadioButtonSelection_Batch.Size = New System.Drawing.Size(125, 20)
            Me.RadioButtonSelection_Batch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelection_Batch.TabIndex = 0
            Me.RadioButtonSelection_Batch.TabOnEnter = True
            Me.RadioButtonSelection_Batch.Text = "Batch"
            '
            'LabelForm_User
            '
            Me.LabelForm_User.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_User.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_User.Location = New System.Drawing.Point(12, 243)
            Me.LabelForm_User.Name = "LabelForm_User"
            Me.LabelForm_User.Size = New System.Drawing.Size(45, 20)
            Me.LabelForm_User.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_User.TabIndex = 2
            Me.LabelForm_User.Text = "User:"
            '
            'ComboBoxForm_User
            '
            Me.ComboBoxForm_User.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_User.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_User.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_User.AutoFindItemInDataSource = False
            Me.ComboBoxForm_User.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_User.BookmarkingEnabled = False
            Me.ComboBoxForm_User.ClientCode = ""
            Me.ComboBoxForm_User.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.User
            Me.ComboBoxForm_User.DisableMouseWheel = True
            Me.ComboBoxForm_User.DisplayMember = "Name"
            Me.ComboBoxForm_User.DisplayName = ""
            Me.ComboBoxForm_User.DivisionCode = ""
            Me.ComboBoxForm_User.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_User.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_User.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_User.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_User.FocusHighlightEnabled = True
            Me.ComboBoxForm_User.FormattingEnabled = True
            Me.ComboBoxForm_User.ItemHeight = 14
            Me.ComboBoxForm_User.Location = New System.Drawing.Point(63, 243)
            Me.ComboBoxForm_User.Name = "ComboBoxForm_User"
            Me.ComboBoxForm_User.ReadOnly = False
            Me.ComboBoxForm_User.SecurityEnabled = True
            Me.ComboBoxForm_User.Size = New System.Drawing.Size(223, 20)
            Me.ComboBoxForm_User.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_User.TabIndex = 3
            Me.ComboBoxForm_User.TabOnEnter = True
            Me.ComboBoxForm_User.ValueMember = "Name"
            Me.ComboBoxForm_User.WatermarkText = "Select User"
            '
            'LabelForm_Batch
            '
            Me.LabelForm_Batch.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Batch.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Batch.Location = New System.Drawing.Point(12, 269)
            Me.LabelForm_Batch.Name = "LabelForm_Batch"
            Me.LabelForm_Batch.Size = New System.Drawing.Size(45, 20)
            Me.LabelForm_Batch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Batch.TabIndex = 5
            Me.LabelForm_Batch.Text = "Batch:"
            '
            'ComboBoxForm_Batch
            '
            Me.ComboBoxForm_Batch.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Batch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Batch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Batch.AutoFindItemInDataSource = False
            Me.ComboBoxForm_Batch.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Batch.BookmarkingEnabled = False
            Me.ComboBoxForm_Batch.ClientCode = ""
            Me.ComboBoxForm_Batch.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.[Date]
            Me.ComboBoxForm_Batch.DisableMouseWheel = True
            Me.ComboBoxForm_Batch.DisplayMember = "Date"
            Me.ComboBoxForm_Batch.DisplayName = "Batch"
            Me.ComboBoxForm_Batch.DivisionCode = ""
            Me.ComboBoxForm_Batch.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Batch.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_Batch.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_Batch.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Batch.FocusHighlightEnabled = True
            Me.ComboBoxForm_Batch.FormattingEnabled = True
            Me.ComboBoxForm_Batch.ItemHeight = 14
            Me.ComboBoxForm_Batch.Location = New System.Drawing.Point(63, 269)
            Me.ComboBoxForm_Batch.Name = "ComboBoxForm_Batch"
            Me.ComboBoxForm_Batch.ReadOnly = False
            Me.ComboBoxForm_Batch.SecurityEnabled = True
            Me.ComboBoxForm_Batch.Size = New System.Drawing.Size(223, 20)
            Me.ComboBoxForm_Batch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Batch.TabIndex = 6
            Me.ComboBoxForm_Batch.TabOnEnter = True
            Me.ComboBoxForm_Batch.ValueMember = "Date"
            Me.ComboBoxForm_Batch.WatermarkText = "Select"
            '
            'RadioButtonFormat_SummaryDataEntryOrder
            '
            Me.RadioButtonFormat_SummaryDataEntryOrder.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonFormat_SummaryDataEntryOrder.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonFormat_SummaryDataEntryOrder.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonFormat_SummaryDataEntryOrder.Location = New System.Drawing.Point(5, 103)
            Me.RadioButtonFormat_SummaryDataEntryOrder.Name = "RadioButtonFormat_SummaryDataEntryOrder"
            Me.RadioButtonFormat_SummaryDataEntryOrder.SecurityEnabled = True
            Me.RadioButtonFormat_SummaryDataEntryOrder.Size = New System.Drawing.Size(264, 20)
            Me.RadioButtonFormat_SummaryDataEntryOrder.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonFormat_SummaryDataEntryOrder.TabIndex = 3
            Me.RadioButtonFormat_SummaryDataEntryOrder.TabOnEnter = True
            Me.RadioButtonFormat_SummaryDataEntryOrder.TabStop = False
            Me.RadioButtonFormat_SummaryDataEntryOrder.Text = "Summary - Data Entry Order"
            '
            'AccountsPayableBatchReportDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(298, 357)
            Me.Controls.Add(Me.GroupBoxForm_Selection)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.ComboBoxForm_User)
            Me.Controls.Add(Me.DateTimePickerForm_To)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.GroupBoxForm_Format)
            Me.Controls.Add(Me.LabelForm_User)
            Me.Controls.Add(Me.LabelFormDates_To)
            Me.Controls.Add(Me.LabelFormDates_From)
            Me.Controls.Add(Me.LabelForm_Batch)
            Me.Controls.Add(Me.DateTimePickerForm_From)
            Me.Controls.Add(Me.ComboBoxForm_Batch)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "AccountsPayableBatchReportDialog"
            Me.Text = "AP Batch Report Criteria"
            CType(Me.GroupBoxForm_Format, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxForm_Format.ResumeLayout(False)
            CType(Me.DateTimePickerForm_From, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerForm_To, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxForm_Selection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxForm_Selection.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelFormDates_From As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelFormDates_To As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxForm_Format As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonFormat_Summary As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonFormat_DetailNoPageBreak As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents DateTimePickerForm_From As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerForm_To As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents GroupBoxForm_Selection As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonSelection_DateRange As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSelection_Batch As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents LabelForm_User As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_User As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_Batch As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_Batch As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents RadioButtonSelection_Import As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonFormat_DetailPageBreak As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSelection_ImportBatch As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonFormat_SummaryDataEntryOrder As WinForm.Presentation.Controls.RadioButtonControl
    End Class

End Namespace