Namespace Reporting.Presentation

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
	Partial Class JobProjectScheduleSummaryInitialLoadingDialog
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
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(JobProjectScheduleSummaryInitialLoadingDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DateTimePickerForm_From = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.ComboBoxForm_Criteria = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.DateTimePickerForm_To = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelForm_Criteria = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_From = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_To = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ButtonForm_YTD = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_MTD = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_1Year = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_2Years = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.CheckBoxForm_IncludeClosedJobs = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TabControlProduction_Criteria = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelProductionSelectClientsTab_SelectClients = New DevComponents.DotNetBar.TabControlPanel()
            Me.CDPChooserControl_Production = New AdvantageFramework.WinForm.Presentation.Controls.CDPChooserControl()
            Me.TabItemProductionCriteria_SelectClientsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives = New DevComponents.DotNetBar.TabControlPanel()
            Me.AEChooserControl_Production = New AdvantageFramework.WinForm.Presentation.Controls.AEChooserControl()
            Me.TabItemProductionCriteria_SelectAccountExecutivesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses = New DevComponents.DotNetBar.TabControlPanel()
            Me.SalesClassChooserControl1 = New AdvantageFramework.WinForm.Presentation.Controls.SalesClassChooserControl()
            Me.TabItem1 = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelSelectJobTypesTab_SelectJobTypes = New DevComponents.DotNetBar.TabControlPanel()
            Me.JobTypeChooserControl1 = New AdvantageFramework.WinForm.Presentation.Controls.JobTypeChooserControl()
            Me.TabItemJobTypes = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelProductionOptionsTab_Options = New DevComponents.DotNetBar.TabControlPanel()
            Me.TabItemProductionCriteria_OptionsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            CType(Me.DateTimePickerForm_From, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerForm_To, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.TabControlProduction_Criteria, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlProduction_Criteria.SuspendLayout()
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.SuspendLayout()
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.SuspendLayout()
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.SuspendLayout()
            Me.TabControlPanelSelectJobTypesTab_SelectJobTypes.SuspendLayout()
            Me.TabControlPanelProductionOptionsTab_Options.SuspendLayout()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(568, 513)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 14
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(649, 513)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 15
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'DateTimePickerForm_From
            '
            Me.DateTimePickerForm_From.AllowEmptyState = False
            Me.DateTimePickerForm_From.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
            Me.DateTimePickerForm_From.Location = New System.Drawing.Point(56, 30)
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
            Me.DateTimePickerForm_From.Size = New System.Drawing.Size(489, 20)
            Me.DateTimePickerForm_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_From.TabIndex = 3
            Me.DateTimePickerForm_From.TabOnEnter = True
            Me.DateTimePickerForm_From.Value = New Date(1850, 1, 1, 0, 0, 0, 0)
            '
            'ComboBoxForm_Criteria
            '
            Me.ComboBoxForm_Criteria.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Criteria.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
            Me.ComboBoxForm_Criteria.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxForm_Criteria.FormattingEnabled = True
            Me.ComboBoxForm_Criteria.ItemHeight = 14
            Me.ComboBoxForm_Criteria.Location = New System.Drawing.Point(57, 4)
            Me.ComboBoxForm_Criteria.Name = "ComboBoxForm_Criteria"
            Me.ComboBoxForm_Criteria.ReadOnly = False
            Me.ComboBoxForm_Criteria.SecurityEnabled = True
            Me.ComboBoxForm_Criteria.Size = New System.Drawing.Size(651, 20)
            Me.ComboBoxForm_Criteria.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Criteria.TabIndex = 1
            Me.ComboBoxForm_Criteria.TabOnEnter = True
            Me.ComboBoxForm_Criteria.ValueMember = "Value"
            Me.ComboBoxForm_Criteria.WatermarkText = "Select"
            '
            'DateTimePickerForm_To
            '
            Me.DateTimePickerForm_To.AllowEmptyState = False
            Me.DateTimePickerForm_To.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
            Me.DateTimePickerForm_To.Location = New System.Drawing.Point(56, 56)
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
            Me.DateTimePickerForm_To.Size = New System.Drawing.Size(489, 20)
            Me.DateTimePickerForm_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_To.TabIndex = 5
            Me.DateTimePickerForm_To.TabOnEnter = True
            Me.DateTimePickerForm_To.Value = New Date(1850, 1, 1, 0, 0, 0, 0)
            '
            'LabelForm_Criteria
            '
            Me.LabelForm_Criteria.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Criteria.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Criteria.Location = New System.Drawing.Point(5, 5)
            Me.LabelForm_Criteria.Name = "LabelForm_Criteria"
            Me.LabelForm_Criteria.Size = New System.Drawing.Size(45, 20)
            Me.LabelForm_Criteria.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Criteria.TabIndex = 0
            Me.LabelForm_Criteria.Text = "Criteria:"
            '
            'LabelForm_From
            '
            Me.LabelForm_From.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_From.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_From.Location = New System.Drawing.Point(5, 31)
            Me.LabelForm_From.Name = "LabelForm_From"
            Me.LabelForm_From.Size = New System.Drawing.Size(45, 20)
            Me.LabelForm_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_From.TabIndex = 2
            Me.LabelForm_From.Text = "From:"
            '
            'LabelForm_To
            '
            Me.LabelForm_To.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_To.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_To.Location = New System.Drawing.Point(5, 57)
            Me.LabelForm_To.Name = "LabelForm_To"
            Me.LabelForm_To.Size = New System.Drawing.Size(45, 20)
            Me.LabelForm_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_To.TabIndex = 4
            Me.LabelForm_To.Text = "To:"
            '
            'ButtonForm_YTD
            '
            Me.ButtonForm_YTD.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_YTD.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_YTD.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_YTD.Location = New System.Drawing.Point(551, 30)
            Me.ButtonForm_YTD.Name = "ButtonForm_YTD"
            Me.ButtonForm_YTD.SecurityEnabled = True
            Me.ButtonForm_YTD.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_YTD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_YTD.TabIndex = 6
            Me.ButtonForm_YTD.Text = "YTD"
            '
            'ButtonForm_MTD
            '
            Me.ButtonForm_MTD.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_MTD.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_MTD.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_MTD.Location = New System.Drawing.Point(551, 56)
            Me.ButtonForm_MTD.Name = "ButtonForm_MTD"
            Me.ButtonForm_MTD.SecurityEnabled = True
            Me.ButtonForm_MTD.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_MTD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_MTD.TabIndex = 8
            Me.ButtonForm_MTD.Text = "MTD"
            '
            'ButtonForm_1Year
            '
            Me.ButtonForm_1Year.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_1Year.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_1Year.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_1Year.Location = New System.Drawing.Point(632, 30)
            Me.ButtonForm_1Year.Name = "ButtonForm_1Year"
            Me.ButtonForm_1Year.SecurityEnabled = True
            Me.ButtonForm_1Year.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_1Year.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_1Year.TabIndex = 7
            Me.ButtonForm_1Year.Text = "1 Year"
            '
            'ButtonForm_2Years
            '
            Me.ButtonForm_2Years.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_2Years.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_2Years.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_2Years.Location = New System.Drawing.Point(632, 56)
            Me.ButtonForm_2Years.Name = "ButtonForm_2Years"
            Me.ButtonForm_2Years.SecurityEnabled = True
            Me.ButtonForm_2Years.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_2Years.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_2Years.TabIndex = 9
            Me.ButtonForm_2Years.Text = "2 Years"
            '
            'CheckBoxForm_IncludeClosedJobs
            '
            Me.CheckBoxForm_IncludeClosedJobs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxForm_IncludeClosedJobs.BackColor = System.Drawing.Color.White
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
            Me.CheckBoxForm_IncludeClosedJobs.Location = New System.Drawing.Point(5, 82)
            Me.CheckBoxForm_IncludeClosedJobs.Name = "CheckBoxForm_IncludeClosedJobs"
            Me.CheckBoxForm_IncludeClosedJobs.OldestSibling = Nothing
            Me.CheckBoxForm_IncludeClosedJobs.SecurityEnabled = True
            Me.CheckBoxForm_IncludeClosedJobs.SiblingControls = CType(resources.GetObject("CheckBoxForm_IncludeClosedJobs.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_IncludeClosedJobs.Size = New System.Drawing.Size(702, 20)
            Me.CheckBoxForm_IncludeClosedJobs.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_IncludeClosedJobs.TabIndex = 13
            Me.CheckBoxForm_IncludeClosedJobs.TabOnEnter = True
            Me.CheckBoxForm_IncludeClosedJobs.Text = "Include Closed Jobs"
            Me.CheckBoxForm_IncludeClosedJobs.Visible = False
            '
            'TabControlProduction_Criteria
            '
            Me.TabControlProduction_Criteria.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlProduction_Criteria.BackColor = System.Drawing.Color.White
            Me.TabControlProduction_Criteria.CanReorderTabs = True
            Me.TabControlProduction_Criteria.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlProduction_Criteria.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlProduction_Criteria.Controls.Add(Me.TabControlPanelProductionOptionsTab_Options)
            Me.TabControlProduction_Criteria.Controls.Add(Me.TabControlPanelSelectJobTypesTab_SelectJobTypes)
            Me.TabControlProduction_Criteria.Controls.Add(Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses)
            Me.TabControlProduction_Criteria.Controls.Add(Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives)
            Me.TabControlProduction_Criteria.Controls.Add(Me.TabControlPanelProductionSelectClientsTab_SelectClients)
            Me.TabControlProduction_Criteria.ForeColor = System.Drawing.Color.Black
            Me.TabControlProduction_Criteria.Location = New System.Drawing.Point(12, 12)
            Me.TabControlProduction_Criteria.Name = "TabControlProduction_Criteria"
            Me.TabControlProduction_Criteria.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlProduction_Criteria.SelectedTabIndex = 0
            Me.TabControlProduction_Criteria.Size = New System.Drawing.Size(712, 495)
            Me.TabControlProduction_Criteria.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlProduction_Criteria.TabIndex = 16
            Me.TabControlProduction_Criteria.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlProduction_Criteria.Tabs.Add(Me.TabItemProductionCriteria_OptionsTab)
            Me.TabControlProduction_Criteria.Tabs.Add(Me.TabItemProductionCriteria_SelectClientsTab)
            Me.TabControlProduction_Criteria.Tabs.Add(Me.TabItemProductionCriteria_SelectAccountExecutivesTab)
            Me.TabControlProduction_Criteria.Tabs.Add(Me.TabItem1)
            Me.TabControlProduction_Criteria.Tabs.Add(Me.TabItemJobTypes)
            Me.TabControlProduction_Criteria.TabStop = False
            Me.TabControlProduction_Criteria.Text = "TabControl1"
            '
            'TabControlPanelProductionSelectClientsTab_SelectClients
            '
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.Controls.Add(Me.CDPChooserControl_Production)
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.Name = "TabControlPanelProductionSelectClientsTab_SelectClients"
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.Size = New System.Drawing.Size(712, 468)
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.Style.GradientAngle = 90
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.TabIndex = 5
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.TabItem = Me.TabItemProductionCriteria_SelectClientsTab
            '
            'CDPChooserControl_Production
            '
            Me.CDPChooserControl_Production.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CDPChooserControl_Production.BackColor = System.Drawing.Color.Transparent
            Me.CDPChooserControl_Production.Location = New System.Drawing.Point(4, 4)
            Me.CDPChooserControl_Production.Name = "CDPChooserControl_Production"
            Me.CDPChooserControl_Production.Size = New System.Drawing.Size(704, 460)
            Me.CDPChooserControl_Production.TabIndex = 0
            '
            'TabItemProductionCriteria_SelectClientsTab
            '
            Me.TabItemProductionCriteria_SelectClientsTab.AttachedControl = Me.TabControlPanelProductionSelectClientsTab_SelectClients
            Me.TabItemProductionCriteria_SelectClientsTab.Name = "TabItemProductionCriteria_SelectClientsTab"
            Me.TabItemProductionCriteria_SelectClientsTab.Text = "Select Clients"
            '
            'TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives
            '
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.Controls.Add(Me.AEChooserControl_Production)
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.Name = "TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives"
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.Size = New System.Drawing.Size(712, 468)
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.Style.GradientAngle = 90
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.TabIndex = 9
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.TabItem = Me.TabItemProductionCriteria_SelectAccountExecutivesTab
            '
            'AEChooserControl_Production
            '
            Me.AEChooserControl_Production.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.AEChooserControl_Production.BackColor = System.Drawing.Color.Transparent
            Me.AEChooserControl_Production.Location = New System.Drawing.Point(4, 4)
            Me.AEChooserControl_Production.Name = "AEChooserControl_Production"
            Me.AEChooserControl_Production.Size = New System.Drawing.Size(704, 460)
            Me.AEChooserControl_Production.TabIndex = 0
            '
            'TabItemProductionCriteria_SelectAccountExecutivesTab
            '
            Me.TabItemProductionCriteria_SelectAccountExecutivesTab.AttachedControl = Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives
            Me.TabItemProductionCriteria_SelectAccountExecutivesTab.Name = "TabItemProductionCriteria_SelectAccountExecutivesTab"
            Me.TabItemProductionCriteria_SelectAccountExecutivesTab.Text = "Select Account Executives"
            '
            'TabControlPanelSelectSalesClassesTab_SelectSalesClasses
            '
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Controls.Add(Me.SalesClassChooserControl1)
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Name = "TabControlPanelSelectSalesClassesTab_SelectSalesClasses"
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Size = New System.Drawing.Size(712, 468)
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Style.GradientAngle = 90
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.TabIndex = 4
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.TabItem = Me.TabItem1
            '
            'SalesClassChooserControl1
            '
            Me.SalesClassChooserControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SalesClassChooserControl1.BackColor = System.Drawing.Color.Transparent
            Me.SalesClassChooserControl1.Location = New System.Drawing.Point(4, 4)
            Me.SalesClassChooserControl1.Name = "SalesClassChooserControl1"
            Me.SalesClassChooserControl1.Size = New System.Drawing.Size(704, 460)
            Me.SalesClassChooserControl1.TabIndex = 0
            '
            'TabItem1
            '
            Me.TabItem1.AttachedControl = Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses
            Me.TabItem1.Name = "TabItem1"
            Me.TabItem1.Text = "Select Sales Classes"
            '
            'TabControlPanelSelectJobTypesTab_SelectJobTypes
            '
            Me.TabControlPanelSelectJobTypesTab_SelectJobTypes.Controls.Add(Me.JobTypeChooserControl1)
            Me.TabControlPanelSelectJobTypesTab_SelectJobTypes.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSelectJobTypesTab_SelectJobTypes.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSelectJobTypesTab_SelectJobTypes.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelSelectJobTypesTab_SelectJobTypes.Name = "TabControlPanelSelectJobTypesTab_SelectJobTypes"
            Me.TabControlPanelSelectJobTypesTab_SelectJobTypes.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSelectJobTypesTab_SelectJobTypes.Size = New System.Drawing.Size(712, 468)
            Me.TabControlPanelSelectJobTypesTab_SelectJobTypes.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelSelectJobTypesTab_SelectJobTypes.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSelectJobTypesTab_SelectJobTypes.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
            Me.TabControlPanelSelectJobTypesTab_SelectJobTypes.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSelectJobTypesTab_SelectJobTypes.Style.GradientAngle = 90
            Me.TabControlPanelSelectJobTypesTab_SelectJobTypes.TabIndex = 4
            Me.TabControlPanelSelectJobTypesTab_SelectJobTypes.TabItem = Me.TabItemJobTypes
            '
            'JobTypeChooserControl1
            '
            Me.JobTypeChooserControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.JobTypeChooserControl1.BackColor = System.Drawing.Color.Transparent
            Me.JobTypeChooserControl1.Location = New System.Drawing.Point(4, 4)
            Me.JobTypeChooserControl1.Name = "JobTypeChooserControl1"
            Me.JobTypeChooserControl1.Size = New System.Drawing.Size(704, 460)
            Me.JobTypeChooserControl1.TabIndex = 0
            '
            'TabItemJobTypes
            '
            Me.TabItemJobTypes.AttachedControl = Me.TabControlPanelSelectJobTypesTab_SelectJobTypes
            Me.TabItemJobTypes.Name = "TabItemJobTypes"
            Me.TabItemJobTypes.Text = "Select Job Types"
            '
            'TabControlPanelProductionOptionsTab_Options
            '
            Me.TabControlPanelProductionOptionsTab_Options.Controls.Add(Me.LabelForm_Criteria)
            Me.TabControlPanelProductionOptionsTab_Options.Controls.Add(Me.CheckBoxForm_IncludeClosedJobs)
            Me.TabControlPanelProductionOptionsTab_Options.Controls.Add(Me.ComboBoxForm_Criteria)
            Me.TabControlPanelProductionOptionsTab_Options.Controls.Add(Me.ButtonForm_2Years)
            Me.TabControlPanelProductionOptionsTab_Options.Controls.Add(Me.LabelForm_From)
            Me.TabControlPanelProductionOptionsTab_Options.Controls.Add(Me.ButtonForm_1Year)
            Me.TabControlPanelProductionOptionsTab_Options.Controls.Add(Me.DateTimePickerForm_From)
            Me.TabControlPanelProductionOptionsTab_Options.Controls.Add(Me.ButtonForm_MTD)
            Me.TabControlPanelProductionOptionsTab_Options.Controls.Add(Me.LabelForm_To)
            Me.TabControlPanelProductionOptionsTab_Options.Controls.Add(Me.ButtonForm_YTD)
            Me.TabControlPanelProductionOptionsTab_Options.Controls.Add(Me.DateTimePickerForm_To)
            Me.TabControlPanelProductionOptionsTab_Options.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelProductionOptionsTab_Options.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelProductionOptionsTab_Options.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelProductionOptionsTab_Options.Name = "TabControlPanelProductionOptionsTab_Options"
            Me.TabControlPanelProductionOptionsTab_Options.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelProductionOptionsTab_Options.Size = New System.Drawing.Size(712, 468)
            Me.TabControlPanelProductionOptionsTab_Options.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelProductionOptionsTab_Options.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelProductionOptionsTab_Options.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
            Me.TabControlPanelProductionOptionsTab_Options.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelProductionOptionsTab_Options.Style.GradientAngle = 90
            Me.TabControlPanelProductionOptionsTab_Options.TabIndex = 1
            Me.TabControlPanelProductionOptionsTab_Options.TabItem = Me.TabItemProductionCriteria_OptionsTab
            '
            'TabItemProductionCriteria_OptionsTab
            '
            Me.TabItemProductionCriteria_OptionsTab.AttachedControl = Me.TabControlPanelProductionOptionsTab_Options
            Me.TabItemProductionCriteria_OptionsTab.Name = "TabItemProductionCriteria_OptionsTab"
            Me.TabItemProductionCriteria_OptionsTab.Text = "Options"
            '
            'JobProjectScheduleSummaryInitialLoadingDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(736, 545)
            Me.Controls.Add(Me.TabControlProduction_Criteria)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "JobProjectScheduleSummaryInitialLoadingDialog"
            Me.Text = "Set Initial Criteria"
            CType(Me.DateTimePickerForm_From, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerForm_To, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.TabControlProduction_Criteria, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlProduction_Criteria.ResumeLayout(False)
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.ResumeLayout(False)
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.ResumeLayout(False)
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.ResumeLayout(False)
            Me.TabControlPanelSelectJobTypesTab_SelectJobTypes.ResumeLayout(False)
            Me.TabControlPanelProductionOptionsTab_Options.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
		Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
		Friend WithEvents DateTimePickerForm_From As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
		Friend WithEvents ComboBoxForm_Criteria As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
		Friend WithEvents DateTimePickerForm_To As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
		Friend WithEvents LabelForm_Criteria As AdvantageFramework.WinForm.Presentation.Controls.Label
		Friend WithEvents LabelForm_From As AdvantageFramework.WinForm.Presentation.Controls.Label
		Friend WithEvents LabelForm_To As AdvantageFramework.WinForm.Presentation.Controls.Label
		Friend WithEvents ButtonForm_YTD As AdvantageFramework.WinForm.Presentation.Controls.Button
		Friend WithEvents ButtonForm_MTD As AdvantageFramework.WinForm.Presentation.Controls.Button
		Friend WithEvents ButtonForm_1Year As AdvantageFramework.WinForm.Presentation.Controls.Button
		Friend WithEvents ButtonForm_2Years As AdvantageFramework.WinForm.Presentation.Controls.Button
		Friend WithEvents CheckBoxForm_IncludeClosedJobs As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents TabControlProduction_Criteria As WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelProductionOptionsTab_Options As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemProductionCriteria_OptionsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelSelectJobTypesTab_SelectJobTypes As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemJobTypes As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelSelectSalesClassesTab_SelectSalesClasses As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItem1 As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents AEChooserControl_Production As WinForm.Presentation.Controls.AEChooserControl
        Friend WithEvents TabItemProductionCriteria_SelectAccountExecutivesTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelProductionSelectClientsTab_SelectClients As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents CDPChooserControl_Production As WinForm.Presentation.Controls.CDPChooserControl
        Friend WithEvents TabItemProductionCriteria_SelectClientsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents JobTypeChooserControl1 As WinForm.Presentation.Controls.JobTypeChooserControl
        Friend WithEvents SalesClassChooserControl1 As WinForm.Presentation.Controls.SalesClassChooserControl
    End Class

End Namespace