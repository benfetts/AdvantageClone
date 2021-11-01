Namespace FinanceAndAccounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AccountsPayableInitialLoadingDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AccountsPayableInitialLoadingDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DateTimePickerPanelDates_From = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.ComboBoxForm_Criteria = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.DateTimePickerPanelDates_To = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelForm_Criteria = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPanelDates_From = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPanelDates_To = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ButtonPanelDates_YTD = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonPanelDates_MTD = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonPanelDates_1Year = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonPanelDates_2Years = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.PanelForm_Dates = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.SearchableComboBoxForm_Criteria = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
			Me.SearchableComboBoxViewCriteria_Criteria = New AdvantageFramework.WinForm.Presentation.Controls.GridView(True)
			Me.TextBoxForm_Criteria = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
			Me.NumericInputForm_Criteria = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelForm_Equals = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_CriteriaSelection = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            CType(Me.DateTimePickerPanelDates_From, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerPanelDates_To, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PanelForm_Dates, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Dates.SuspendLayout()
            CType(Me.SearchableComboBoxForm_Criteria.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewCriteria_Criteria, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputForm_Criteria.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(193, 106)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 3
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(274, 106)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 4
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'DateTimePickerPanelDates_From
            '
            Me.DateTimePickerPanelDates_From.AllowEmptyState = False
            Me.DateTimePickerPanelDates_From.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerPanelDates_From.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerPanelDates_From.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerPanelDates_From.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerPanelDates_From.ButtonDropDown.Visible = True
            Me.DateTimePickerPanelDates_From.ButtonFreeText.Checked = True
            Me.DateTimePickerPanelDates_From.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerPanelDates_From.CustomFormat = ""
            Me.DateTimePickerPanelDates_From.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerPanelDates_From.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerPanelDates_From.FocusHighlightEnabled = True
            Me.DateTimePickerPanelDates_From.Format = DevComponents.Editors.eDateTimePickerFormat.Short
            Me.DateTimePickerPanelDates_From.FreeTextEntryMode = True
            Me.DateTimePickerPanelDates_From.IsPopupCalendarOpen = False
            Me.DateTimePickerPanelDates_From.Location = New System.Drawing.Point(60, 5)
            Me.DateTimePickerPanelDates_From.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerPanelDates_From.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerPanelDates_From.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerPanelDates_From.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerPanelDates_From.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerPanelDates_From.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerPanelDates_From.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerPanelDates_From.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerPanelDates_From.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerPanelDates_From.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerPanelDates_From.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerPanelDates_From.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerPanelDates_From.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerPanelDates_From.MonthCalendar.DisplayMonth = New Date(2012, 7, 1, 0, 0, 0, 0)
            Me.DateTimePickerPanelDates_From.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerPanelDates_From.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerPanelDates_From.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerPanelDates_From.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerPanelDates_From.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerPanelDates_From.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerPanelDates_From.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerPanelDates_From.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerPanelDates_From.Name = "DateTimePickerPanelDates_From"
            Me.DateTimePickerPanelDates_From.ReadOnly = False
            Me.DateTimePickerPanelDates_From.Size = New System.Drawing.Size(124, 20)
            Me.DateTimePickerPanelDates_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerPanelDates_From.TabIndex = 1
            Me.DateTimePickerPanelDates_From.Value = New Date(1850, 1, 1, 0, 0, 0, 0)
            '
            'ComboBoxForm_Criteria
            '
            Me.ComboBoxForm_Criteria.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Criteria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Criteria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Criteria.AutoFindItemInDataSource = False
            Me.ComboBoxForm_Criteria.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Criteria.BookmarkingEnabled = False
            Me.ComboBoxForm_Criteria.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumDataTable
            Me.ComboBoxForm_Criteria.DisableMouseWheel = False
            Me.ComboBoxForm_Criteria.DisplayMember = "Name"
            Me.ComboBoxForm_Criteria.DisplayName = ""
            Me.ComboBoxForm_Criteria.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Criteria.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_Criteria.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_Criteria.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Criteria.FocusHighlightEnabled = True
            Me.ComboBoxForm_Criteria.FormattingEnabled = True
            Me.ComboBoxForm_Criteria.ItemHeight = 14
            Me.ComboBoxForm_Criteria.Location = New System.Drawing.Point(63, 12)
            Me.ComboBoxForm_Criteria.Name = "ComboBoxForm_Criteria"
            Me.ComboBoxForm_Criteria.PreventEnterBeep = False
            Me.ComboBoxForm_Criteria.ReadOnly = False
            Me.ComboBoxForm_Criteria.SecurityEnabled = True
            Me.ComboBoxForm_Criteria.Size = New System.Drawing.Size(286, 20)
            Me.ComboBoxForm_Criteria.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Criteria.TabIndex = 1
            Me.ComboBoxForm_Criteria.ValueMember = "Value"
            Me.ComboBoxForm_Criteria.WatermarkText = "Select"
            '
            'DateTimePickerPanelDates_To
            '
            Me.DateTimePickerPanelDates_To.AllowEmptyState = False
            Me.DateTimePickerPanelDates_To.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerPanelDates_To.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerPanelDates_To.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerPanelDates_To.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerPanelDates_To.ButtonDropDown.Visible = True
            Me.DateTimePickerPanelDates_To.ButtonFreeText.Checked = True
            Me.DateTimePickerPanelDates_To.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerPanelDates_To.CustomFormat = ""
            Me.DateTimePickerPanelDates_To.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerPanelDates_To.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerPanelDates_To.FocusHighlightEnabled = True
            Me.DateTimePickerPanelDates_To.Format = DevComponents.Editors.eDateTimePickerFormat.Short
            Me.DateTimePickerPanelDates_To.FreeTextEntryMode = True
            Me.DateTimePickerPanelDates_To.IsPopupCalendarOpen = False
            Me.DateTimePickerPanelDates_To.Location = New System.Drawing.Point(60, 31)
            Me.DateTimePickerPanelDates_To.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerPanelDates_To.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerPanelDates_To.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerPanelDates_To.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerPanelDates_To.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerPanelDates_To.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerPanelDates_To.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerPanelDates_To.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerPanelDates_To.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerPanelDates_To.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerPanelDates_To.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerPanelDates_To.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerPanelDates_To.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerPanelDates_To.MonthCalendar.DisplayMonth = New Date(2012, 7, 1, 0, 0, 0, 0)
            Me.DateTimePickerPanelDates_To.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerPanelDates_To.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerPanelDates_To.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerPanelDates_To.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerPanelDates_To.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerPanelDates_To.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerPanelDates_To.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerPanelDates_To.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerPanelDates_To.Name = "DateTimePickerPanelDates_To"
            Me.DateTimePickerPanelDates_To.ReadOnly = False
            Me.DateTimePickerPanelDates_To.Size = New System.Drawing.Size(124, 20)
            Me.DateTimePickerPanelDates_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerPanelDates_To.TabIndex = 3
            Me.DateTimePickerPanelDates_To.Value = New Date(1850, 1, 1, 0, 0, 0, 0)
            '
            'LabelForm_Criteria
            '
            Me.LabelForm_Criteria.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Criteria.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Criteria.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_Criteria.Name = "LabelForm_Criteria"
            Me.LabelForm_Criteria.Size = New System.Drawing.Size(45, 20)
            Me.LabelForm_Criteria.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Criteria.TabIndex = 0
            Me.LabelForm_Criteria.Text = "Criteria:"
            '
            'LabelPanelDates_From
            '
            Me.LabelPanelDates_From.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPanelDates_From.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPanelDates_From.Location = New System.Drawing.Point(9, 5)
            Me.LabelPanelDates_From.Name = "LabelPanelDates_From"
            Me.LabelPanelDates_From.Size = New System.Drawing.Size(45, 20)
            Me.LabelPanelDates_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPanelDates_From.TabIndex = 0
            Me.LabelPanelDates_From.Text = "From:"
            '
            'LabelPanelDates_To
            '
            Me.LabelPanelDates_To.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPanelDates_To.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPanelDates_To.Location = New System.Drawing.Point(9, 31)
            Me.LabelPanelDates_To.Name = "LabelPanelDates_To"
            Me.LabelPanelDates_To.Size = New System.Drawing.Size(45, 20)
            Me.LabelPanelDates_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPanelDates_To.TabIndex = 2
            Me.LabelPanelDates_To.Text = "To:"
            '
            'ButtonPanelDates_YTD
            '
            Me.ButtonPanelDates_YTD.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonPanelDates_YTD.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonPanelDates_YTD.Location = New System.Drawing.Point(190, 5)
            Me.ButtonPanelDates_YTD.Name = "ButtonPanelDates_YTD"
            Me.ButtonPanelDates_YTD.SecurityEnabled = True
            Me.ButtonPanelDates_YTD.Size = New System.Drawing.Size(75, 20)
            Me.ButtonPanelDates_YTD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonPanelDates_YTD.TabIndex = 4
            Me.ButtonPanelDates_YTD.Text = "YTD"
            '
            'ButtonPanelDates_MTD
            '
            Me.ButtonPanelDates_MTD.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonPanelDates_MTD.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonPanelDates_MTD.Location = New System.Drawing.Point(190, 31)
            Me.ButtonPanelDates_MTD.Name = "ButtonPanelDates_MTD"
            Me.ButtonPanelDates_MTD.SecurityEnabled = True
            Me.ButtonPanelDates_MTD.Size = New System.Drawing.Size(75, 20)
            Me.ButtonPanelDates_MTD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonPanelDates_MTD.TabIndex = 6
            Me.ButtonPanelDates_MTD.Text = "MTD"
            '
            'ButtonPanelDates_1Year
            '
            Me.ButtonPanelDates_1Year.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonPanelDates_1Year.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonPanelDates_1Year.Location = New System.Drawing.Point(271, 5)
            Me.ButtonPanelDates_1Year.Name = "ButtonPanelDates_1Year"
            Me.ButtonPanelDates_1Year.SecurityEnabled = True
            Me.ButtonPanelDates_1Year.Size = New System.Drawing.Size(75, 20)
            Me.ButtonPanelDates_1Year.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonPanelDates_1Year.TabIndex = 5
            Me.ButtonPanelDates_1Year.Text = "1 Year"
            '
            'ButtonPanelDates_2Years
            '
            Me.ButtonPanelDates_2Years.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonPanelDates_2Years.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonPanelDates_2Years.Location = New System.Drawing.Point(271, 31)
            Me.ButtonPanelDates_2Years.Name = "ButtonPanelDates_2Years"
            Me.ButtonPanelDates_2Years.SecurityEnabled = True
            Me.ButtonPanelDates_2Years.Size = New System.Drawing.Size(75, 20)
            Me.ButtonPanelDates_2Years.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonPanelDates_2Years.TabIndex = 7
            Me.ButtonPanelDates_2Years.Text = "2 Years"
            '
            'PanelForm_Dates
            '
            Me.PanelForm_Dates.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.PanelForm_Dates.Appearance.Options.UseBackColor = True
            Me.PanelForm_Dates.Controls.Add(Me.ButtonPanelDates_2Years)
            Me.PanelForm_Dates.Controls.Add(Me.DateTimePickerPanelDates_To)
            Me.PanelForm_Dates.Controls.Add(Me.ButtonPanelDates_1Year)
            Me.PanelForm_Dates.Controls.Add(Me.DateTimePickerPanelDates_From)
            Me.PanelForm_Dates.Controls.Add(Me.ButtonPanelDates_MTD)
            Me.PanelForm_Dates.Controls.Add(Me.LabelPanelDates_From)
            Me.PanelForm_Dates.Controls.Add(Me.ButtonPanelDates_YTD)
            Me.PanelForm_Dates.Controls.Add(Me.LabelPanelDates_To)
            Me.PanelForm_Dates.Location = New System.Drawing.Point(3, 33)
            Me.PanelForm_Dates.Name = "PanelForm_Dates"
            Me.PanelForm_Dates.Size = New System.Drawing.Size(353, 67)
            Me.PanelForm_Dates.TabIndex = 2
            '
            'SearchableComboBoxForm_Criteria
            '
            Me.SearchableComboBoxForm_Criteria.ActiveFilterString = ""
            Me.SearchableComboBoxForm_Criteria.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxForm_Criteria.BookmarkingEnabled = False
            Me.SearchableComboBoxForm_Criteria.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Vendor
            Me.SearchableComboBoxForm_Criteria.DataSource = Nothing
            Me.SearchableComboBoxForm_Criteria.DisableMouseWheel = True
            Me.SearchableComboBoxForm_Criteria.DisplayName = ""
            Me.SearchableComboBoxForm_Criteria.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxForm_Criteria.Location = New System.Drawing.Point(63, 38)
            Me.SearchableComboBoxForm_Criteria.Name = "SearchableComboBoxForm_Criteria"
            Me.SearchableComboBoxForm_Criteria.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxForm_Criteria.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxForm_Criteria.Properties.NullText = "Select Vendor"
            Me.SearchableComboBoxForm_Criteria.Properties.ShowClearButton = False
            Me.SearchableComboBoxForm_Criteria.Properties.ValueMember = "Code"
            Me.SearchableComboBoxForm_Criteria.Properties.View = Me.SearchableComboBoxViewCriteria_Criteria
            Me.SearchableComboBoxForm_Criteria.SelectedValue = Nothing
            Me.SearchableComboBoxForm_Criteria.Size = New System.Drawing.Size(286, 20)
            Me.SearchableComboBoxForm_Criteria.TabIndex = 2
            '
            'SearchableComboBoxViewCriteria_Criteria
            '
            Me.SearchableComboBoxViewCriteria_Criteria.AFActiveFilterString = ""
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewCriteria_Criteria.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewCriteria_Criteria.DataSourceClearing = False
            Me.SearchableComboBoxViewCriteria_Criteria.EnableDisabledRows = False
            Me.SearchableComboBoxViewCriteria_Criteria.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewCriteria_Criteria.Name = "SearchableComboBoxViewCriteria_Criteria"
            Me.SearchableComboBoxViewCriteria_Criteria.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewCriteria_Criteria.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewCriteria_Criteria.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewCriteria_Criteria.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewCriteria_Criteria.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewCriteria_Criteria.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewCriteria_Criteria.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewCriteria_Criteria.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewCriteria_Criteria.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewCriteria_Criteria.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewCriteria_Criteria.RunStandardValidation = True
            '
            'TextBoxForm_Criteria
            '
            '
            '
            '
            Me.TextBoxForm_Criteria.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Criteria.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Criteria.CheckSpellingOnValidate = False
            Me.TextBoxForm_Criteria.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Criteria.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_Criteria.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Criteria.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Criteria.FocusHighlightEnabled = True
            Me.TextBoxForm_Criteria.Location = New System.Drawing.Point(63, 39)
            Me.TextBoxForm_Criteria.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Criteria.Name = "TextBoxForm_Criteria"
            Me.TextBoxForm_Criteria.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Criteria.Size = New System.Drawing.Size(286, 20)
            Me.TextBoxForm_Criteria.TabIndex = 2
            Me.TextBoxForm_Criteria.TabOnEnter = True
            '
            'NumericInputForm_Criteria
            '
            Me.NumericInputForm_Criteria.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputForm_Criteria.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputForm_Criteria.Location = New System.Drawing.Point(63, 38)
            Me.NumericInputForm_Criteria.Name = "NumericInputForm_Criteria"
            Me.NumericInputForm_Criteria.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputForm_Criteria.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputForm_Criteria.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputForm_Criteria.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_Criteria.Properties.EditFormat.FormatString = "f"
            Me.NumericInputForm_Criteria.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_Criteria.Properties.Mask.EditMask = "f"
            Me.NumericInputForm_Criteria.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputForm_Criteria.Size = New System.Drawing.Size(286, 20)
            Me.NumericInputForm_Criteria.TabIndex = 2
            '
            'LabelForm_Equals
            '
            Me.LabelForm_Equals.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Equals.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Equals.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_Equals.Name = "LabelForm_Equals"
            Me.LabelForm_Equals.Size = New System.Drawing.Size(45, 20)
            Me.LabelForm_Equals.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Equals.TabIndex = 29
            Me.LabelForm_Equals.Text = "Equals:"
            '
            'ComboBoxForm_CriteriaSelection
            '
            Me.ComboBoxForm_CriteriaSelection.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_CriteriaSelection.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_CriteriaSelection.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_CriteriaSelection.AutoFindItemInDataSource = False
            Me.ComboBoxForm_CriteriaSelection.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_CriteriaSelection.BookmarkingEnabled = False
            Me.ComboBoxForm_CriteriaSelection.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumDataTable
            Me.ComboBoxForm_CriteriaSelection.DisableMouseWheel = False
            Me.ComboBoxForm_CriteriaSelection.DisplayMember = "Name"
            Me.ComboBoxForm_CriteriaSelection.DisplayName = ""
            Me.ComboBoxForm_CriteriaSelection.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_CriteriaSelection.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_CriteriaSelection.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_CriteriaSelection.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_CriteriaSelection.FocusHighlightEnabled = True
            Me.ComboBoxForm_CriteriaSelection.FormattingEnabled = True
            Me.ComboBoxForm_CriteriaSelection.ItemHeight = 14
            Me.ComboBoxForm_CriteriaSelection.Location = New System.Drawing.Point(63, 38)
            Me.ComboBoxForm_CriteriaSelection.Name = "ComboBoxForm_CriteriaSelection"
            Me.ComboBoxForm_CriteriaSelection.PreventEnterBeep = False
            Me.ComboBoxForm_CriteriaSelection.ReadOnly = False
            Me.ComboBoxForm_CriteriaSelection.SecurityEnabled = True
            Me.ComboBoxForm_CriteriaSelection.Size = New System.Drawing.Size(286, 20)
            Me.ComboBoxForm_CriteriaSelection.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_CriteriaSelection.TabIndex = 2
            Me.ComboBoxForm_CriteriaSelection.ValueMember = "Value"
            Me.ComboBoxForm_CriteriaSelection.WatermarkText = "Select"
            '
            'AccountsPayableInitialLoadingDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(361, 138)
            Me.Controls.Add(Me.PanelForm_Dates)
            Me.Controls.Add(Me.LabelForm_Equals)
            Me.Controls.Add(Me.LabelForm_Criteria)
            Me.Controls.Add(Me.ComboBoxForm_CriteriaSelection)
            Me.Controls.Add(Me.TextBoxForm_Criteria)
            Me.Controls.Add(Me.ComboBoxForm_Criteria)
            Me.Controls.Add(Me.SearchableComboBoxForm_Criteria)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.NumericInputForm_Criteria)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "AccountsPayableInitialLoadingDialog"
            Me.Text = "Set Initial Criteria"
            CType(Me.DateTimePickerPanelDates_From, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerPanelDates_To, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PanelForm_Dates, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Dates.ResumeLayout(False)
            CType(Me.SearchableComboBoxForm_Criteria.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewCriteria_Criteria, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputForm_Criteria.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DateTimePickerPanelDates_From As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents ComboBoxForm_Criteria As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents DateTimePickerPanelDates_To As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents LabelForm_Criteria As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelPanelDates_From As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelPanelDates_To As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonPanelDates_YTD As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonPanelDates_MTD As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonPanelDates_1Year As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonPanelDates_2Years As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents PanelForm_Dates As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents SearchableComboBoxForm_Criteria As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewCriteria_Criteria As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents TextBoxForm_Criteria As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents NumericInputForm_Criteria As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents LabelForm_Equals As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_CriteriaSelection As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
    End Class

End Namespace