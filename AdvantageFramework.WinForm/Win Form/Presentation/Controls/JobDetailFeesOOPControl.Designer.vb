Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class JobDetailFeesOOPControl
        Inherits AdvantageFramework.WinForm.Presentation.Controls.BaseControls.BaseUserControl

        'UserControl overrides dispose to clean up the component list.
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(JobDetailFeesOOPControl))
            Me.GroupBoxControl_Cutoffs = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelCutoffs_IncomeOnlyDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxProductionCutoffs_APPostingPeriod = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelCutoffs_EmployeeDateTime = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCutoffs_APPostingPeriod = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBox4 = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.DateTimePicker1 = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.Label1 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBox1 = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.DateTimePicker2 = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.Label2 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.Label3 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBox1 = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxForm_IncludeClosedJobs = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_ShowJobsWithNoDetails = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
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
            Me.GroupBox6 = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.DateTimePicker3 = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.Label4 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBox2 = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.DateTimePicker4 = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.Label5 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.Label6 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            CType(Me.GroupBoxControl_Cutoffs, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxControl_Cutoffs.SuspendLayout()
            CType(Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerProductionCutoffs_EmployeeTimeDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox4.SuspendLayout()
            CType(Me.DateTimePicker1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePicker2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox1.SuspendLayout()
            CType(Me.DateTimePickerForm_To, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerForm_From, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBox6, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox6.SuspendLayout()
            CType(Me.DateTimePicker3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePicker4, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'GroupBoxControl_Cutoffs
            '
            Me.GroupBoxControl_Cutoffs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxControl_Cutoffs.Appearance.BackColor = System.Drawing.Color.Transparent
            Me.GroupBoxControl_Cutoffs.Appearance.Options.UseBackColor = True
            Me.GroupBoxControl_Cutoffs.Controls.Add(Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate)
            Me.GroupBoxControl_Cutoffs.Controls.Add(Me.LabelCutoffs_IncomeOnlyDate)
            Me.GroupBoxControl_Cutoffs.Controls.Add(Me.ComboBoxProductionCutoffs_APPostingPeriod)
            Me.GroupBoxControl_Cutoffs.Controls.Add(Me.DateTimePickerProductionCutoffs_EmployeeTimeDate)
            Me.GroupBoxControl_Cutoffs.Controls.Add(Me.LabelCutoffs_EmployeeDateTime)
            Me.GroupBoxControl_Cutoffs.Controls.Add(Me.LabelCutoffs_APPostingPeriod)
            Me.GroupBoxControl_Cutoffs.Location = New System.Drawing.Point(0, 166)
            Me.GroupBoxControl_Cutoffs.Name = "GroupBoxControl_Cutoffs"
            Me.GroupBoxControl_Cutoffs.Size = New System.Drawing.Size(573, 107)
            Me.GroupBoxControl_Cutoffs.TabIndex = 1
            Me.GroupBoxControl_Cutoffs.Text = "Cutoffs"
            '
            'DateTimePickerProductionCutoffs_IncomeOnlyTimeDate
            '
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.ButtonDropDown.Visible = True
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.ButtonFreeText.Checked = True
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.DisplayName = ""
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.FocusHighlightEnabled = True
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.FreeTextEntryMode = True
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.IsPopupCalendarOpen = False
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.Location = New System.Drawing.Point(131, 50)
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.MinDate = New Date(1980, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.Name = "DateTimePickerProductionCutoffs_IncomeOnlyTimeDate"
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.ReadOnly = False
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.Size = New System.Drawing.Size(272, 21)
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.TabIndex = 1
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.TabOnEnter = True
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.Value = New Date(2014, 5, 29, 9, 35, 2, 204)
            '
            'LabelCutoffs_IncomeOnlyDate
            '
            Me.LabelCutoffs_IncomeOnlyDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCutoffs_IncomeOnlyDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCutoffs_IncomeOnlyDate.Location = New System.Drawing.Point(5, 50)
            Me.LabelCutoffs_IncomeOnlyDate.Name = "LabelCutoffs_IncomeOnlyDate"
            Me.LabelCutoffs_IncomeOnlyDate.Size = New System.Drawing.Size(120, 20)
            Me.LabelCutoffs_IncomeOnlyDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCutoffs_IncomeOnlyDate.TabIndex = 0
            Me.LabelCutoffs_IncomeOnlyDate.Text = "Income Only Date:"
            '
            'ComboBoxProductionCutoffs_APPostingPeriod
            '
            Me.ComboBoxProductionCutoffs_APPostingPeriod.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxProductionCutoffs_APPostingPeriod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxProductionCutoffs_APPostingPeriod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxProductionCutoffs_APPostingPeriod.AutoFindItemInDataSource = False
            Me.ComboBoxProductionCutoffs_APPostingPeriod.AutoSelectSingleItemDatasource = False
            Me.ComboBoxProductionCutoffs_APPostingPeriod.BookmarkingEnabled = False
            Me.ComboBoxProductionCutoffs_APPostingPeriod.ClientCode = ""
            Me.ComboBoxProductionCutoffs_APPostingPeriod.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.PostPeriod
            Me.ComboBoxProductionCutoffs_APPostingPeriod.DisableMouseWheel = True
            Me.ComboBoxProductionCutoffs_APPostingPeriod.DisplayMember = "Description"
            Me.ComboBoxProductionCutoffs_APPostingPeriod.DisplayName = ""
            Me.ComboBoxProductionCutoffs_APPostingPeriod.DivisionCode = ""
            Me.ComboBoxProductionCutoffs_APPostingPeriod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxProductionCutoffs_APPostingPeriod.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxProductionCutoffs_APPostingPeriod.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxProductionCutoffs_APPostingPeriod.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxProductionCutoffs_APPostingPeriod.FocusHighlightEnabled = True
            Me.ComboBoxProductionCutoffs_APPostingPeriod.FormattingEnabled = True
            Me.ComboBoxProductionCutoffs_APPostingPeriod.ItemHeight = 16
            Me.ComboBoxProductionCutoffs_APPostingPeriod.Location = New System.Drawing.Point(131, 76)
            Me.ComboBoxProductionCutoffs_APPostingPeriod.Name = "ComboBoxProductionCutoffs_APPostingPeriod"
            Me.ComboBoxProductionCutoffs_APPostingPeriod.ReadOnly = False
            Me.ComboBoxProductionCutoffs_APPostingPeriod.SecurityEnabled = True
            Me.ComboBoxProductionCutoffs_APPostingPeriod.Size = New System.Drawing.Size(272, 22)
            Me.ComboBoxProductionCutoffs_APPostingPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxProductionCutoffs_APPostingPeriod.TabIndex = 2
            Me.ComboBoxProductionCutoffs_APPostingPeriod.TabOnEnter = True
            Me.ComboBoxProductionCutoffs_APPostingPeriod.ValueMember = "Code"
            Me.ComboBoxProductionCutoffs_APPostingPeriod.WatermarkText = "Select Post Period"
            '
            'DateTimePickerProductionCutoffs_EmployeeTimeDate
            '
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.ButtonDropDown.Visible = True
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.ButtonFreeText.Checked = True
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.DisplayName = ""
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.FocusHighlightEnabled = True
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.FreeTextEntryMode = True
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.IsPopupCalendarOpen = False
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.Location = New System.Drawing.Point(131, 24)
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.MinDate = New Date(1980, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.Name = "DateTimePickerProductionCutoffs_EmployeeTimeDate"
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.ReadOnly = False
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.Size = New System.Drawing.Size(272, 21)
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.TabIndex = 0
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.TabOnEnter = True
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.Value = New Date(2014, 5, 29, 9, 35, 2, 267)
            '
            'LabelCutoffs_EmployeeDateTime
            '
            Me.LabelCutoffs_EmployeeDateTime.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCutoffs_EmployeeDateTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCutoffs_EmployeeDateTime.Location = New System.Drawing.Point(5, 24)
            Me.LabelCutoffs_EmployeeDateTime.Name = "LabelCutoffs_EmployeeDateTime"
            Me.LabelCutoffs_EmployeeDateTime.Size = New System.Drawing.Size(120, 20)
            Me.LabelCutoffs_EmployeeDateTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCutoffs_EmployeeDateTime.TabIndex = 0
            Me.LabelCutoffs_EmployeeDateTime.Text = "Employee Time Date:"
            '
            'LabelCutoffs_APPostingPeriod
            '
            Me.LabelCutoffs_APPostingPeriod.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCutoffs_APPostingPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCutoffs_APPostingPeriod.Location = New System.Drawing.Point(5, 76)
            Me.LabelCutoffs_APPostingPeriod.Name = "LabelCutoffs_APPostingPeriod"
            Me.LabelCutoffs_APPostingPeriod.Size = New System.Drawing.Size(120, 20)
            Me.LabelCutoffs_APPostingPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCutoffs_APPostingPeriod.TabIndex = 4
            Me.LabelCutoffs_APPostingPeriod.Text = "A/P Posting Period:"
            '
            'GroupBox4
            '
            Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBox4.Appearance.BackColor = System.Drawing.Color.Transparent
            Me.GroupBox4.Appearance.Options.UseBackColor = True
            Me.GroupBox4.Controls.Add(Me.DateTimePicker1)
            Me.GroupBox4.Controls.Add(Me.Label1)
            Me.GroupBox4.Controls.Add(Me.ComboBox1)
            Me.GroupBox4.Controls.Add(Me.DateTimePicker2)
            Me.GroupBox4.Controls.Add(Me.Label2)
            Me.GroupBox4.Controls.Add(Me.Label3)
            Me.GroupBox4.Location = New System.Drawing.Point(0, 102)
            Me.GroupBox4.Name = "GroupBox4"
            Me.GroupBox4.Size = New System.Drawing.Size(573, 107)
            Me.GroupBox4.TabIndex = 0
            Me.GroupBox4.Text = "Cutoffs"
            '
            'DateTimePicker1
            '
            Me.DateTimePicker1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DateTimePicker1.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePicker1.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePicker1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePicker1.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePicker1.ButtonDropDown.Visible = True
            Me.DateTimePicker1.ButtonFreeText.Checked = True
            Me.DateTimePicker1.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePicker1.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePicker1.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePicker1.DisplayName = ""
            Me.DateTimePicker1.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePicker1.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePicker1.FocusHighlightEnabled = True
            Me.DateTimePicker1.FreeTextEntryMode = True
            Me.DateTimePicker1.IsPopupCalendarOpen = False
            Me.DateTimePicker1.Location = New System.Drawing.Point(131, 50)
            Me.DateTimePicker1.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePicker1.MinDate = New Date(1980, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePicker1.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePicker1.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePicker1.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePicker1.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePicker1.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePicker1.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePicker1.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePicker1.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePicker1.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePicker1.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePicker1.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePicker1.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePicker1.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePicker1.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePicker1.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePicker1.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePicker1.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePicker1.Name = "DateTimePicker1"
            Me.DateTimePicker1.ReadOnly = False
            Me.DateTimePicker1.Size = New System.Drawing.Size(414, 21)
            Me.DateTimePicker1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePicker1.TabIndex = 3
            Me.DateTimePicker1.TabOnEnter = True
            Me.DateTimePicker1.Value = New Date(2014, 5, 29, 9, 35, 2, 204)
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.Label1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label1.Location = New System.Drawing.Point(5, 50)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(120, 20)
            Me.Label1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Income Only Date:"
            '
            'ComboBox1
            '
            Me.ComboBox1.AddInactiveItemsOnSelectedValue = False
            Me.ComboBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBox1.AutoFindItemInDataSource = False
            Me.ComboBox1.AutoSelectSingleItemDatasource = False
            Me.ComboBox1.BookmarkingEnabled = False
            Me.ComboBox1.ClientCode = ""
            Me.ComboBox1.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.PostPeriod
            Me.ComboBox1.DisableMouseWheel = True
            Me.ComboBox1.DisplayMember = "Description"
            Me.ComboBox1.DisplayName = ""
            Me.ComboBox1.DivisionCode = ""
            Me.ComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBox1.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBox1.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBox1.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBox1.FocusHighlightEnabled = True
            Me.ComboBox1.FormattingEnabled = True
            Me.ComboBox1.ItemHeight = 16
            Me.ComboBox1.Location = New System.Drawing.Point(131, 76)
            Me.ComboBox1.Name = "ComboBox1"
            Me.ComboBox1.ReadOnly = False
            Me.ComboBox1.SecurityEnabled = True
            Me.ComboBox1.Size = New System.Drawing.Size(414, 22)
            Me.ComboBox1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBox1.TabIndex = 5
            Me.ComboBox1.TabOnEnter = True
            Me.ComboBox1.ValueMember = "Code"
            Me.ComboBox1.WatermarkText = "Select Post Period"
            '
            'DateTimePicker2
            '
            Me.DateTimePicker2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DateTimePicker2.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePicker2.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePicker2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePicker2.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePicker2.ButtonDropDown.Visible = True
            Me.DateTimePicker2.ButtonFreeText.Checked = True
            Me.DateTimePicker2.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePicker2.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePicker2.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePicker2.DisplayName = ""
            Me.DateTimePicker2.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePicker2.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePicker2.FocusHighlightEnabled = True
            Me.DateTimePicker2.FreeTextEntryMode = True
            Me.DateTimePicker2.IsPopupCalendarOpen = False
            Me.DateTimePicker2.Location = New System.Drawing.Point(131, 24)
            Me.DateTimePicker2.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePicker2.MinDate = New Date(1980, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePicker2.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePicker2.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePicker2.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePicker2.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePicker2.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePicker2.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePicker2.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePicker2.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePicker2.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePicker2.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePicker2.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePicker2.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePicker2.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePicker2.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePicker2.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePicker2.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePicker2.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePicker2.Name = "DateTimePicker2"
            Me.DateTimePicker2.ReadOnly = False
            Me.DateTimePicker2.Size = New System.Drawing.Size(414, 21)
            Me.DateTimePicker2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePicker2.TabIndex = 1
            Me.DateTimePicker2.TabOnEnter = True
            Me.DateTimePicker2.Value = New Date(2014, 5, 29, 9, 35, 2, 267)
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.Label2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label2.Location = New System.Drawing.Point(5, 24)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(120, 20)
            Me.Label2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label2.TabIndex = 0
            Me.Label2.Text = "Employee Time Date:"
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.Label3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label3.Location = New System.Drawing.Point(5, 76)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(120, 20)
            Me.Label3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label3.TabIndex = 0
            Me.Label3.Text = "A/P Posting Period:"
            '
            'GroupBox1
            '
            Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBox1.Appearance.BackColor = System.Drawing.Color.Transparent
            Me.GroupBox1.Appearance.Options.UseBackColor = True
            Me.GroupBox1.Controls.Add(Me.CheckBoxForm_IncludeClosedJobs)
            Me.GroupBox1.Controls.Add(Me.CheckBoxForm_ShowJobsWithNoDetails)
            Me.GroupBox1.Controls.Add(Me.ButtonForm_2Years)
            Me.GroupBox1.Controls.Add(Me.ButtonForm_1Year)
            Me.GroupBox1.Controls.Add(Me.ButtonForm_MTD)
            Me.GroupBox1.Controls.Add(Me.ButtonForm_YTD)
            Me.GroupBox1.Controls.Add(Me.LabelForm_To)
            Me.GroupBox1.Controls.Add(Me.LabelForm_From)
            Me.GroupBox1.Controls.Add(Me.LabelForm_Criteria)
            Me.GroupBox1.Controls.Add(Me.DateTimePickerForm_To)
            Me.GroupBox1.Controls.Add(Me.ComboBoxForm_Criteria)
            Me.GroupBox1.Controls.Add(Me.DateTimePickerForm_From)
            Me.GroupBox1.Location = New System.Drawing.Point(0, 3)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(573, 157)
            Me.GroupBox1.TabIndex = 0
            Me.GroupBox1.Text = "Date Options"
            '
            'CheckBoxForm_IncludeClosedJobs
            '
            '
            '
            '
            Me.CheckBoxForm_IncludeClosedJobs.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_IncludeClosedJobs.CheckValue = 0
            Me.CheckBoxForm_IncludeClosedJobs.CheckValueChecked = 1
            Me.CheckBoxForm_IncludeClosedJobs.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_IncludeClosedJobs.CheckValueUnchecked = 0
            Me.CheckBoxForm_IncludeClosedJobs.ChildControls = CType(resources.GetObject("CheckBoxForm_IncludeClosedJobs.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_IncludeClosedJobs.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_IncludeClosedJobs.Location = New System.Drawing.Point(5, 129)
            Me.CheckBoxForm_IncludeClosedJobs.Name = "CheckBoxForm_IncludeClosedJobs"
            Me.CheckBoxForm_IncludeClosedJobs.OldestSibling = Nothing
            Me.CheckBoxForm_IncludeClosedJobs.SecurityEnabled = True
            Me.CheckBoxForm_IncludeClosedJobs.SiblingControls = CType(resources.GetObject("CheckBoxForm_IncludeClosedJobs.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_IncludeClosedJobs.Size = New System.Drawing.Size(421, 20)
            Me.CheckBoxForm_IncludeClosedJobs.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_IncludeClosedJobs.TabIndex = 8
            Me.CheckBoxForm_IncludeClosedJobs.TabOnEnter = True
            Me.CheckBoxForm_IncludeClosedJobs.Text = "Include Closed Jobs (option is disabled when no date criteria is selected)"
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
            Me.CheckBoxForm_ShowJobsWithNoDetails.Location = New System.Drawing.Point(5, 103)
            Me.CheckBoxForm_ShowJobsWithNoDetails.Name = "CheckBoxForm_ShowJobsWithNoDetails"
            Me.CheckBoxForm_ShowJobsWithNoDetails.OldestSibling = Nothing
            Me.CheckBoxForm_ShowJobsWithNoDetails.SecurityEnabled = True
            Me.CheckBoxForm_ShowJobsWithNoDetails.SiblingControls = CType(resources.GetObject("CheckBoxForm_ShowJobsWithNoDetails.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_ShowJobsWithNoDetails.Size = New System.Drawing.Size(175, 20)
            Me.CheckBoxForm_ShowJobsWithNoDetails.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_ShowJobsWithNoDetails.TabIndex = 7
            Me.CheckBoxForm_ShowJobsWithNoDetails.TabOnEnter = True
            Me.CheckBoxForm_ShowJobsWithNoDetails.Text = "Show Jobs With No Details"
            '
            'ButtonForm_2Years
            '
            Me.ButtonForm_2Years.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_2Years.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_2Years.Location = New System.Drawing.Point(267, 76)
            Me.ButtonForm_2Years.Name = "ButtonForm_2Years"
            Me.ButtonForm_2Years.SecurityEnabled = True
            Me.ButtonForm_2Years.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_2Years.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_2Years.TabIndex = 6
            Me.ButtonForm_2Years.Text = "2 Years"
            '
            'ButtonForm_1Year
            '
            Me.ButtonForm_1Year.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_1Year.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_1Year.Location = New System.Drawing.Point(267, 50)
            Me.ButtonForm_1Year.Name = "ButtonForm_1Year"
            Me.ButtonForm_1Year.SecurityEnabled = True
            Me.ButtonForm_1Year.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_1Year.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_1Year.TabIndex = 3
            Me.ButtonForm_1Year.Text = "1 Year"
            '
            'ButtonForm_MTD
            '
            Me.ButtonForm_MTD.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_MTD.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_MTD.Location = New System.Drawing.Point(186, 76)
            Me.ButtonForm_MTD.Name = "ButtonForm_MTD"
            Me.ButtonForm_MTD.SecurityEnabled = True
            Me.ButtonForm_MTD.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_MTD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_MTD.TabIndex = 5
            Me.ButtonForm_MTD.Text = "MTD"
            '
            'ButtonForm_YTD
            '
            Me.ButtonForm_YTD.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_YTD.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_YTD.Location = New System.Drawing.Point(186, 50)
            Me.ButtonForm_YTD.Name = "ButtonForm_YTD"
            Me.ButtonForm_YTD.SecurityEnabled = True
            Me.ButtonForm_YTD.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_YTD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_YTD.TabIndex = 2
            Me.ButtonForm_YTD.Text = "YTD"
            '
            'LabelForm_To
            '
            Me.LabelForm_To.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_To.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_To.Location = New System.Drawing.Point(5, 76)
            Me.LabelForm_To.Name = "LabelForm_To"
            Me.LabelForm_To.Size = New System.Drawing.Size(45, 20)
            Me.LabelForm_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_To.TabIndex = 0
            Me.LabelForm_To.Text = "To:"
            '
            'LabelForm_From
            '
            Me.LabelForm_From.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_From.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_From.Location = New System.Drawing.Point(5, 50)
            Me.LabelForm_From.Name = "LabelForm_From"
            Me.LabelForm_From.Size = New System.Drawing.Size(45, 20)
            Me.LabelForm_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_From.TabIndex = 8
            Me.LabelForm_From.Text = "From:"
            '
            'LabelForm_Criteria
            '
            Me.LabelForm_Criteria.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Criteria.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Criteria.Location = New System.Drawing.Point(5, 24)
            Me.LabelForm_Criteria.Name = "LabelForm_Criteria"
            Me.LabelForm_Criteria.Size = New System.Drawing.Size(45, 20)
            Me.LabelForm_Criteria.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Criteria.TabIndex = 0
            Me.LabelForm_Criteria.Text = "Criteria:"
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
            Me.DateTimePickerForm_To.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePickerForm_To.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePickerForm_To.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerForm_To.DisplayName = ""
            Me.DateTimePickerForm_To.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerForm_To.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerForm_To.FocusHighlightEnabled = True
            Me.DateTimePickerForm_To.FreeTextEntryMode = True
            Me.DateTimePickerForm_To.IsPopupCalendarOpen = False
            Me.DateTimePickerForm_To.Location = New System.Drawing.Point(56, 76)
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
            Me.DateTimePickerForm_To.Size = New System.Drawing.Size(124, 21)
            Me.DateTimePickerForm_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_To.TabIndex = 4
            Me.DateTimePickerForm_To.TabOnEnter = True
            Me.DateTimePickerForm_To.Value = New Date(2017, 8, 7, 11, 18, 28, 763)
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
            Me.ComboBoxForm_Criteria.ItemHeight = 16
            Me.ComboBoxForm_Criteria.Location = New System.Drawing.Point(56, 24)
            Me.ComboBoxForm_Criteria.Name = "ComboBoxForm_Criteria"
            Me.ComboBoxForm_Criteria.ReadOnly = False
            Me.ComboBoxForm_Criteria.SecurityEnabled = True
            Me.ComboBoxForm_Criteria.Size = New System.Drawing.Size(347, 22)
            Me.ComboBoxForm_Criteria.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Criteria.TabIndex = 0
            Me.ComboBoxForm_Criteria.TabOnEnter = True
            Me.ComboBoxForm_Criteria.ValueMember = "Value"
            Me.ComboBoxForm_Criteria.WatermarkText = "Select"
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
            Me.DateTimePickerForm_From.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePickerForm_From.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePickerForm_From.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerForm_From.DisplayName = ""
            Me.DateTimePickerForm_From.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerForm_From.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerForm_From.FocusHighlightEnabled = True
            Me.DateTimePickerForm_From.FreeTextEntryMode = True
            Me.DateTimePickerForm_From.IsPopupCalendarOpen = False
            Me.DateTimePickerForm_From.Location = New System.Drawing.Point(56, 50)
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
            Me.DateTimePickerForm_From.Size = New System.Drawing.Size(124, 21)
            Me.DateTimePickerForm_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_From.TabIndex = 1
            Me.DateTimePickerForm_From.TabOnEnter = True
            Me.DateTimePickerForm_From.Value = New Date(2017, 8, 7, 11, 18, 20, 812)
            '
            'GroupBox6
            '
            Me.GroupBox6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBox6.Appearance.BackColor = System.Drawing.Color.Transparent
            Me.GroupBox6.Appearance.Options.UseBackColor = True
            Me.GroupBox6.Controls.Add(Me.DateTimePicker3)
            Me.GroupBox6.Controls.Add(Me.Label4)
            Me.GroupBox6.Controls.Add(Me.ComboBox2)
            Me.GroupBox6.Controls.Add(Me.DateTimePicker4)
            Me.GroupBox6.Controls.Add(Me.Label5)
            Me.GroupBox6.Controls.Add(Me.Label6)
            Me.GroupBox6.Location = New System.Drawing.Point(0, 102)
            Me.GroupBox6.Name = "GroupBox6"
            Me.GroupBox6.Size = New System.Drawing.Size(573, 107)
            Me.GroupBox6.TabIndex = 0
            Me.GroupBox6.Text = "Cutoffs"
            '
            'DateTimePicker3
            '
            Me.DateTimePicker3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DateTimePicker3.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePicker3.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePicker3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePicker3.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePicker3.ButtonDropDown.Visible = True
            Me.DateTimePicker3.ButtonFreeText.Checked = True
            Me.DateTimePicker3.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePicker3.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePicker3.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePicker3.DisplayName = ""
            Me.DateTimePicker3.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePicker3.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePicker3.FocusHighlightEnabled = True
            Me.DateTimePicker3.FreeTextEntryMode = True
            Me.DateTimePicker3.IsPopupCalendarOpen = False
            Me.DateTimePicker3.Location = New System.Drawing.Point(131, 50)
            Me.DateTimePicker3.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePicker3.MinDate = New Date(1980, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePicker3.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePicker3.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePicker3.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePicker3.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePicker3.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePicker3.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePicker3.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePicker3.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePicker3.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePicker3.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePicker3.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePicker3.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePicker3.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePicker3.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePicker3.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePicker3.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePicker3.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePicker3.Name = "DateTimePicker3"
            Me.DateTimePicker3.ReadOnly = False
            Me.DateTimePicker3.Size = New System.Drawing.Size(414, 21)
            Me.DateTimePicker3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePicker3.TabIndex = 3
            Me.DateTimePicker3.TabOnEnter = True
            Me.DateTimePicker3.Value = New Date(2014, 5, 29, 9, 35, 2, 204)
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.Label4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label4.Location = New System.Drawing.Point(5, 50)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(120, 20)
            Me.Label4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label4.TabIndex = 2
            Me.Label4.Text = "Income Only Date:"
            '
            'ComboBox2
            '
            Me.ComboBox2.AddInactiveItemsOnSelectedValue = False
            Me.ComboBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBox2.AutoFindItemInDataSource = False
            Me.ComboBox2.AutoSelectSingleItemDatasource = False
            Me.ComboBox2.BookmarkingEnabled = False
            Me.ComboBox2.ClientCode = ""
            Me.ComboBox2.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.PostPeriod
            Me.ComboBox2.DisableMouseWheel = True
            Me.ComboBox2.DisplayMember = "Description"
            Me.ComboBox2.DisplayName = ""
            Me.ComboBox2.DivisionCode = ""
            Me.ComboBox2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBox2.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBox2.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBox2.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBox2.FocusHighlightEnabled = True
            Me.ComboBox2.FormattingEnabled = True
            Me.ComboBox2.ItemHeight = 16
            Me.ComboBox2.Location = New System.Drawing.Point(131, 76)
            Me.ComboBox2.Name = "ComboBox2"
            Me.ComboBox2.ReadOnly = False
            Me.ComboBox2.SecurityEnabled = True
            Me.ComboBox2.Size = New System.Drawing.Size(414, 22)
            Me.ComboBox2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBox2.TabIndex = 5
            Me.ComboBox2.TabOnEnter = True
            Me.ComboBox2.ValueMember = "Code"
            Me.ComboBox2.WatermarkText = "Select Post Period"
            '
            'DateTimePicker4
            '
            Me.DateTimePicker4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DateTimePicker4.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePicker4.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePicker4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePicker4.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePicker4.ButtonDropDown.Visible = True
            Me.DateTimePicker4.ButtonFreeText.Checked = True
            Me.DateTimePicker4.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePicker4.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePicker4.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePicker4.DisplayName = ""
            Me.DateTimePicker4.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePicker4.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePicker4.FocusHighlightEnabled = True
            Me.DateTimePicker4.FreeTextEntryMode = True
            Me.DateTimePicker4.IsPopupCalendarOpen = False
            Me.DateTimePicker4.Location = New System.Drawing.Point(131, 24)
            Me.DateTimePicker4.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePicker4.MinDate = New Date(1980, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePicker4.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePicker4.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePicker4.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePicker4.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePicker4.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePicker4.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePicker4.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePicker4.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePicker4.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePicker4.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePicker4.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePicker4.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePicker4.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePicker4.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePicker4.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePicker4.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePicker4.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePicker4.Name = "DateTimePicker4"
            Me.DateTimePicker4.ReadOnly = False
            Me.DateTimePicker4.Size = New System.Drawing.Size(414, 21)
            Me.DateTimePicker4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePicker4.TabIndex = 1
            Me.DateTimePicker4.TabOnEnter = True
            Me.DateTimePicker4.Value = New Date(2014, 5, 29, 9, 35, 2, 267)
            '
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.Label5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label5.Location = New System.Drawing.Point(5, 24)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(120, 20)
            Me.Label5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label5.TabIndex = 0
            Me.Label5.Text = "Employee Time Date:"
            '
            'Label6
            '
            Me.Label6.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.Label6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label6.Location = New System.Drawing.Point(5, 76)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(120, 20)
            Me.Label6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label6.TabIndex = 0
            Me.Label6.Text = "A/P Posting Period:"
            '
            'JobDetailFeesOOPControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.GroupBox1)
            Me.Controls.Add(Me.GroupBoxControl_Cutoffs)
            Me.Name = "JobDetailFeesOOPControl"
            Me.Size = New System.Drawing.Size(573, 509)
            CType(Me.GroupBoxControl_Cutoffs, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxControl_Cutoffs.ResumeLayout(False)
            CType(Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerProductionCutoffs_EmployeeTimeDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox4.ResumeLayout(False)
            CType(Me.DateTimePicker1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePicker2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox1.ResumeLayout(False)
            CType(Me.DateTimePickerForm_To, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerForm_From, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBox6, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox6.ResumeLayout(False)
            CType(Me.DateTimePicker3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePicker4, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents LabelCutoffs_APPostingPeriod As Label
        Friend WithEvents LabelCutoffs_EmployeeDateTime As Label
        Friend WithEvents DateTimePickerProductionCutoffs_EmployeeTimeDate As DateTimePicker
        Friend WithEvents ComboBoxProductionCutoffs_APPostingPeriod As ComboBox
        Friend WithEvents LabelCutoffs_IncomeOnlyDate As Label
        Friend WithEvents DateTimePickerProductionCutoffs_IncomeOnlyTimeDate As DateTimePicker
        Friend WithEvents GroupBoxControl_Cutoffs As GroupBox
        Friend WithEvents GroupBox1 As GroupBox
        Friend WithEvents LabelForm_To As Label
        Friend WithEvents LabelForm_From As Label
        Friend WithEvents LabelForm_Criteria As Label
        Friend WithEvents DateTimePickerForm_To As DateTimePicker
        Friend WithEvents ComboBoxForm_Criteria As ComboBox
        Friend WithEvents DateTimePickerForm_From As DateTimePicker
        Friend WithEvents ButtonForm_2Years As Button
        Friend WithEvents ButtonForm_1Year As Button
        Friend WithEvents ButtonForm_MTD As Button
        Friend WithEvents ButtonForm_YTD As Button
        Friend WithEvents CheckBoxForm_IncludeClosedJobs As CheckBox
        Friend WithEvents CheckBoxForm_ShowJobsWithNoDetails As CheckBox
        Friend WithEvents GroupBox4 As GroupBox
        Friend WithEvents DateTimePicker1 As DateTimePicker
        Friend WithEvents Label1 As Label
        Friend WithEvents ComboBox1 As ComboBox
        Friend WithEvents DateTimePicker2 As DateTimePicker
        Friend WithEvents Label2 As Label
        Friend WithEvents Label3 As Label
        Friend WithEvents GroupBox6 As GroupBox
        Friend WithEvents DateTimePicker3 As DateTimePicker
        Friend WithEvents Label4 As Label
        Friend WithEvents ComboBox2 As ComboBox
        Friend WithEvents DateTimePicker4 As DateTimePicker
        Friend WithEvents Label5 As Label
        Friend WithEvents Label6 As Label
    End Class

End Namespace