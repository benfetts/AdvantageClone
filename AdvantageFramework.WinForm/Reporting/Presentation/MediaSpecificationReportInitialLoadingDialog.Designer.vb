Namespace Reporting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaSpecificationReportInitialLoadingDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaSpecificationReportInitialLoadingDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_2Years = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_1Year = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_MTD = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_YTD = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_To = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_From = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Criteria = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DateTimePickerForm_To = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.ComboBoxForm_Criteria = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.DateTimePickerForm_From = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.Label1 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_Status = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.CheckBoxForm_ShowJobsWithNoDetails = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            CType(Me.DateTimePickerForm_To, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerForm_From, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(186, 141)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 9
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(267, 141)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 10
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ButtonForm_2Years
            '
            Me.ButtonForm_2Years.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_2Years.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_2Years.Location = New System.Drawing.Point(274, 64)
            Me.ButtonForm_2Years.Name = "ButtonForm_2Years"
            Me.ButtonForm_2Years.SecurityEnabled = True
            Me.ButtonForm_2Years.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_2Years.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_2Years.TabIndex = 20
            Me.ButtonForm_2Years.Text = "2 Years"
            '
            'ButtonForm_1Year
            '
            Me.ButtonForm_1Year.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_1Year.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_1Year.Location = New System.Drawing.Point(274, 38)
            Me.ButtonForm_1Year.Name = "ButtonForm_1Year"
            Me.ButtonForm_1Year.SecurityEnabled = True
            Me.ButtonForm_1Year.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_1Year.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_1Year.TabIndex = 18
            Me.ButtonForm_1Year.Text = "1 Year"
            '
            'ButtonForm_MTD
            '
            Me.ButtonForm_MTD.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_MTD.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_MTD.Location = New System.Drawing.Point(193, 64)
            Me.ButtonForm_MTD.Name = "ButtonForm_MTD"
            Me.ButtonForm_MTD.SecurityEnabled = True
            Me.ButtonForm_MTD.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_MTD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_MTD.TabIndex = 19
            Me.ButtonForm_MTD.Text = "MTD"
            '
            'ButtonForm_YTD
            '
            Me.ButtonForm_YTD.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_YTD.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_YTD.Location = New System.Drawing.Point(193, 38)
            Me.ButtonForm_YTD.Name = "ButtonForm_YTD"
            Me.ButtonForm_YTD.SecurityEnabled = True
            Me.ButtonForm_YTD.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_YTD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_YTD.TabIndex = 17
            Me.ButtonForm_YTD.Text = "YTD"
            '
            'LabelForm_To
            '
            Me.LabelForm_To.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_To.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_To.Location = New System.Drawing.Point(12, 64)
            Me.LabelForm_To.Name = "LabelForm_To"
            Me.LabelForm_To.Size = New System.Drawing.Size(45, 20)
            Me.LabelForm_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_To.TabIndex = 15
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
            Me.LabelForm_From.Size = New System.Drawing.Size(45, 20)
            Me.LabelForm_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_From.TabIndex = 13
            Me.LabelForm_From.Text = "From:"
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
            Me.LabelForm_Criteria.TabIndex = 11
            Me.LabelForm_Criteria.Text = "Criteria:"
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
            Me.DateTimePickerForm_To.Location = New System.Drawing.Point(63, 64)
            Me.DateTimePickerForm_To.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerForm_To.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerForm_To.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
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
            Me.DateTimePickerForm_To.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerForm_To.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerForm_To.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerForm_To.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_To.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerForm_To.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_To.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerForm_To.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerForm_To.Name = "DateTimePickerForm_To"
            Me.DateTimePickerForm_To.ReadOnly = False
            Me.DateTimePickerForm_To.Size = New System.Drawing.Size(124, 20)
            Me.DateTimePickerForm_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_To.TabIndex = 16
            Me.DateTimePickerForm_To.TabOnEnter = True
            Me.DateTimePickerForm_To.Value = New Date(1850, 1, 1, 0, 0, 0, 0)
            '
            'ComboBoxForm_Criteria
            '
            Me.ComboBoxForm_Criteria.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Criteria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Criteria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Criteria.AutoFindItemInDataSource = False
            Me.ComboBoxForm_Criteria.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Criteria.BookmarkingEnabled = False
            Me.ComboBoxForm_Criteria.ClientCode = ""
            Me.ComboBoxForm_Criteria.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumDataTable
            Me.ComboBoxForm_Criteria.DisableMouseWheel = False
            Me.ComboBoxForm_Criteria.DisplayMember = "Name"
            Me.ComboBoxForm_Criteria.DisplayName = ""
            Me.ComboBoxForm_Criteria.DivisionCode = ""
            Me.ComboBoxForm_Criteria.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Criteria.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_Criteria.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_Criteria.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Criteria.FocusHighlightEnabled = True
            Me.ComboBoxForm_Criteria.FormattingEnabled = True
            Me.ComboBoxForm_Criteria.ItemHeight = 14
            Me.ComboBoxForm_Criteria.Location = New System.Drawing.Point(63, 12)
            Me.ComboBoxForm_Criteria.Name = "ComboBoxForm_Criteria"
            Me.ComboBoxForm_Criteria.ReadOnly = False
            Me.ComboBoxForm_Criteria.SecurityEnabled = True
            Me.ComboBoxForm_Criteria.Size = New System.Drawing.Size(286, 20)
            Me.ComboBoxForm_Criteria.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Criteria.TabIndex = 12
            Me.ComboBoxForm_Criteria.TabOnEnter = True
            Me.ComboBoxForm_Criteria.ValueMember = "Value"
            Me.ComboBoxForm_Criteria.WatermarkText = "Select"
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
            Me.DateTimePickerForm_From.Location = New System.Drawing.Point(63, 38)
            Me.DateTimePickerForm_From.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerForm_From.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerForm_From.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
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
            Me.DateTimePickerForm_From.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerForm_From.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerForm_From.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerForm_From.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_From.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerForm_From.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_From.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerForm_From.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerForm_From.Name = "DateTimePickerForm_From"
            Me.DateTimePickerForm_From.ReadOnly = False
            Me.DateTimePickerForm_From.Size = New System.Drawing.Size(124, 20)
            Me.DateTimePickerForm_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_From.TabIndex = 14
            Me.DateTimePickerForm_From.TabOnEnter = True
            Me.DateTimePickerForm_From.Value = New Date(1850, 1, 1, 0, 0, 0, 0)
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.Label1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label1.Location = New System.Drawing.Point(12, 90)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(45, 20)
            Me.Label1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label1.TabIndex = 22
            Me.Label1.Text = "Status:"
            '
            'ComboBoxForm_Status
            '
            Me.ComboBoxForm_Status.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Status.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Status.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Status.AutoFindItemInDataSource = False
            Me.ComboBoxForm_Status.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Status.BookmarkingEnabled = False
            Me.ComboBoxForm_Status.ClientCode = ""
            Me.ComboBoxForm_Status.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumDataTable
            Me.ComboBoxForm_Status.DisableMouseWheel = False
            Me.ComboBoxForm_Status.DisplayMember = "Name"
            Me.ComboBoxForm_Status.DisplayName = ""
            Me.ComboBoxForm_Status.DivisionCode = ""
            Me.ComboBoxForm_Status.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Status.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_Status.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_Status.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Status.FocusHighlightEnabled = True
            Me.ComboBoxForm_Status.FormattingEnabled = True
            Me.ComboBoxForm_Status.ItemHeight = 14
            Me.ComboBoxForm_Status.Location = New System.Drawing.Point(63, 90)
            Me.ComboBoxForm_Status.Name = "ComboBoxForm_Status"
            Me.ComboBoxForm_Status.ReadOnly = False
            Me.ComboBoxForm_Status.SecurityEnabled = True
            Me.ComboBoxForm_Status.Size = New System.Drawing.Size(286, 20)
            Me.ComboBoxForm_Status.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Status.TabIndex = 23
            Me.ComboBoxForm_Status.TabOnEnter = True
            Me.ComboBoxForm_Status.ValueMember = "Value"
            Me.ComboBoxForm_Status.WatermarkText = "Select"
            '
            'CheckBoxForm_ShowJobsWithNoDetails
            '
            '
            '
            '
            Me.CheckBoxForm_ShowJobsWithNoDetails.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_ShowJobsWithNoDetails.CheckValue = 0
            Me.CheckBoxForm_ShowJobsWithNoDetails.CheckValueChecked = 1
            Me.CheckBoxForm_ShowJobsWithNoDetails.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_ShowJobsWithNoDetails.CheckValueUnchecked = 0
            Me.CheckBoxForm_ShowJobsWithNoDetails.ChildControls = CType(resources.GetObject("CheckBoxForm_ShowJobsWithNoDetails.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_ShowJobsWithNoDetails.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_ShowJobsWithNoDetails.Location = New System.Drawing.Point(12, 116)
            Me.CheckBoxForm_ShowJobsWithNoDetails.Name = "CheckBoxForm_ShowJobsWithNoDetails"
            Me.CheckBoxForm_ShowJobsWithNoDetails.OldestSibling = Nothing
            Me.CheckBoxForm_ShowJobsWithNoDetails.SecurityEnabled = True
            Me.CheckBoxForm_ShowJobsWithNoDetails.SiblingControls = CType(resources.GetObject("CheckBoxForm_ShowJobsWithNoDetails.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_ShowJobsWithNoDetails.Size = New System.Drawing.Size(175, 20)
            Me.CheckBoxForm_ShowJobsWithNoDetails.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_ShowJobsWithNoDetails.TabIndex = 24
            Me.CheckBoxForm_ShowJobsWithNoDetails.TabOnEnter = True
            Me.CheckBoxForm_ShowJobsWithNoDetails.Text = "Accepted Only"
            Me.CheckBoxForm_ShowJobsWithNoDetails.Visible = False
            '
            'MediaSpecificationReportInitialLoadingDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(354, 173)
            Me.Controls.Add(Me.CheckBoxForm_ShowJobsWithNoDetails)
            Me.Controls.Add(Me.ComboBoxForm_Status)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.ButtonForm_2Years)
            Me.Controls.Add(Me.ButtonForm_1Year)
            Me.Controls.Add(Me.ButtonForm_MTD)
            Me.Controls.Add(Me.ButtonForm_YTD)
            Me.Controls.Add(Me.LabelForm_To)
            Me.Controls.Add(Me.LabelForm_From)
            Me.Controls.Add(Me.LabelForm_Criteria)
            Me.Controls.Add(Me.DateTimePickerForm_To)
            Me.Controls.Add(Me.ComboBoxForm_Criteria)
            Me.Controls.Add(Me.DateTimePickerForm_From)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaSpecificationReportInitialLoadingDialog"
            Me.Text = "Media Specifications Initial Criteria"
            CType(Me.DateTimePickerForm_To, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerForm_From, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_2Years As WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_1Year As WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_MTD As WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_YTD As WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_To As WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_From As WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Criteria As WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerForm_To As WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents ComboBoxForm_Criteria As WinForm.Presentation.Controls.ComboBox
        Friend WithEvents DateTimePickerForm_From As WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents Label1 As WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_Status As WinForm.Presentation.Controls.ComboBox
        Friend WithEvents CheckBoxForm_ShowJobsWithNoDetails As WinForm.Presentation.Controls.CheckBox
    End Class

End Namespace