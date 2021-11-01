Namespace FinanceAndAccounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ClientBudgetAddDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClientBudgetAddDialog))
        Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonForm_Add = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.DateTimePickerForm_BudgetDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
        Me.LabelForm_BudgetDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.LabelForm_Name = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.SearchableComboBoxForm_Employee = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
        Me.SearchableComboBoxViewForm_Employee = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
        Me.LabelForm_Code = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.LabelForm_Employee = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.TextBoxForm_Code = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
        Me.TextBoxForm_Name = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
        Me.GroupBoxControl_BudgetPeriod = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
        Me.SearchableComboBoxBudgetPeriod_ToPostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
        Me.GridView2 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
        Me.LabelBudgetPeriod_From = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.LabelBudgetPeriod_To = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.SearchableComboBoxBudgetPeriod_FromPostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
        Me.GridView1 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
        Me.GroupBoxControl_SummaryDetail = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
        Me.RadioButtonSummaryDetail_Detail = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
        Me.RadioButtonSummaryDetail_Summary = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
        Me.GroupBoxControl_CategorySelection = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
        Me.PanelCategorySelection_SalesClass = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
        Me.RadioButtonCategorySalesClass_No = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
        Me.RadioButtonCategorySalesClass_Yes = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
        Me.LabelCategory_SalesClass = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.LabelCategory_Type = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.PanelCategorySelection_Type = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
        Me.RadioButtonCategoryType_No = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
        Me.RadioButtonCategoryType_Yes = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
        CType(Me.DateTimePickerForm_BudgetDate,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.SearchableComboBoxForm_Employee.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.SearchableComboBoxViewForm_Employee,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.GroupBoxControl_BudgetPeriod,System.ComponentModel.ISupportInitialize).BeginInit
        Me.GroupBoxControl_BudgetPeriod.SuspendLayout
        CType(Me.SearchableComboBoxBudgetPeriod_ToPostPeriod.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.GridView2,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.SearchableComboBoxBudgetPeriod_FromPostPeriod.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.GridView1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.GroupBoxControl_SummaryDetail,System.ComponentModel.ISupportInitialize).BeginInit
        Me.GroupBoxControl_SummaryDetail.SuspendLayout
        CType(Me.GroupBoxControl_CategorySelection,System.ComponentModel.ISupportInitialize).BeginInit
        Me.GroupBoxControl_CategorySelection.SuspendLayout
        CType(Me.PanelCategorySelection_SalesClass,System.ComponentModel.ISupportInitialize).BeginInit
        Me.PanelCategorySelection_SalesClass.SuspendLayout
        CType(Me.PanelCategorySelection_Type,System.ComponentModel.ISupportInitialize).BeginInit
        Me.PanelCategorySelection_Type.SuspendLayout
        Me.SuspendLayout
        '
        'ButtonForm_Cancel
        '
        Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonForm_Cancel.Location = New System.Drawing.Point(257, 348)
        Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
        Me.ButtonForm_Cancel.SecurityEnabled = true
        Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
        Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonForm_Cancel.TabIndex = 5
        Me.ButtonForm_Cancel.Text = "Cancel"
        '
        'ButtonForm_Add
        '
        Me.ButtonForm_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonForm_Add.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.ButtonForm_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonForm_Add.Location = New System.Drawing.Point(176, 348)
        Me.ButtonForm_Add.Name = "ButtonForm_Add"
        Me.ButtonForm_Add.SecurityEnabled = true
        Me.ButtonForm_Add.Size = New System.Drawing.Size(75, 20)
        Me.ButtonForm_Add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonForm_Add.TabIndex = 4
        Me.ButtonForm_Add.Text = "Add"
        '
        'DateTimePickerForm_BudgetDate
        '
        Me.DateTimePickerForm_BudgetDate.AutoResolveFreeTextEntries = false
        '
        '
        '
        Me.DateTimePickerForm_BudgetDate.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.DateTimePickerForm_BudgetDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimePickerForm_BudgetDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.DateTimePickerForm_BudgetDate.ButtonDropDown.Visible = true
        Me.DateTimePickerForm_BudgetDate.ButtonFreeText.Checked = true
        Me.DateTimePickerForm_BudgetDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
        Me.DateTimePickerForm_BudgetDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.DateTimePickerForm_BudgetDate.DisplayName = ""
        Me.DateTimePickerForm_BudgetDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.DateTimePickerForm_BudgetDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(230,Byte),Integer), CType(CType(141,Byte),Integer))
        Me.DateTimePickerForm_BudgetDate.FocusHighlightEnabled = true
        Me.DateTimePickerForm_BudgetDate.FreeTextEntryMode = true
        Me.DateTimePickerForm_BudgetDate.IsPopupCalendarOpen = false
        Me.DateTimePickerForm_BudgetDate.Location = New System.Drawing.Point(99, 64)
            Me.DateTimePickerForm_BudgetDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        '
        '
        '
        Me.DateTimePickerForm_BudgetDate.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.DateTimePickerForm_BudgetDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.DateTimePickerForm_BudgetDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimePickerForm_BudgetDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.DateTimePickerForm_BudgetDate.MonthCalendar.ClearButtonVisible = true
        '
        '
        '
        Me.DateTimePickerForm_BudgetDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.DateTimePickerForm_BudgetDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.DateTimePickerForm_BudgetDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.DateTimePickerForm_BudgetDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.DateTimePickerForm_BudgetDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.DateTimePickerForm_BudgetDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.DateTimePickerForm_BudgetDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimePickerForm_BudgetDate.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
        Me.DateTimePickerForm_BudgetDate.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.DateTimePickerForm_BudgetDate.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.DateTimePickerForm_BudgetDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.DateTimePickerForm_BudgetDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.DateTimePickerForm_BudgetDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.DateTimePickerForm_BudgetDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimePickerForm_BudgetDate.MonthCalendar.TodayButtonVisible = true
        Me.DateTimePickerForm_BudgetDate.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.DateTimePickerForm_BudgetDate.Name = "DateTimePickerForm_BudgetDate"
        Me.DateTimePickerForm_BudgetDate.ReadOnly = false
        Me.DateTimePickerForm_BudgetDate.Size = New System.Drawing.Size(90, 20)
        Me.DateTimePickerForm_BudgetDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.DateTimePickerForm_BudgetDate.TabIndex = 134
        Me.DateTimePickerForm_BudgetDate.Value = New Date(2014, 3, 27, 12, 0, 0, 0)
        '
        'LabelForm_BudgetDate
        '
        Me.LabelForm_BudgetDate.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelForm_BudgetDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelForm_BudgetDate.Location = New System.Drawing.Point(12, 64)
        Me.LabelForm_BudgetDate.Name = "LabelForm_BudgetDate"
        Me.LabelForm_BudgetDate.Size = New System.Drawing.Size(81, 20)
        Me.LabelForm_BudgetDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelForm_BudgetDate.TabIndex = 133
        Me.LabelForm_BudgetDate.Text = "Budget Date:"
        '
        'LabelForm_Name
        '
        Me.LabelForm_Name.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelForm_Name.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelForm_Name.Location = New System.Drawing.Point(12, 38)
        Me.LabelForm_Name.Name = "LabelForm_Name"
        Me.LabelForm_Name.Size = New System.Drawing.Size(81, 20)
        Me.LabelForm_Name.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelForm_Name.TabIndex = 131
        Me.LabelForm_Name.Text = "Name:"
        '
        'SearchableComboBoxForm_Employee
        '
        Me.SearchableComboBoxForm_Employee.ActiveFilterString = ""
        Me.SearchableComboBoxForm_Employee.AddInactiveItemsOnSelectedValue = false
        Me.SearchableComboBoxForm_Employee.AutoFillMode = false
        Me.SearchableComboBoxForm_Employee.BookmarkingEnabled = false
        Me.SearchableComboBoxForm_Employee.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Employee
        Me.SearchableComboBoxForm_Employee.DataSource = Nothing
        Me.SearchableComboBoxForm_Employee.DisableMouseWheel = true
        Me.SearchableComboBoxForm_Employee.DisplayName = ""
        Me.SearchableComboBoxForm_Employee.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
        Me.SearchableComboBoxForm_Employee.Location = New System.Drawing.Point(99, 90)
        Me.SearchableComboBoxForm_Employee.Name = "SearchableComboBoxForm_Employee"
        Me.SearchableComboBoxForm_Employee.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SearchableComboBoxForm_Employee.Properties.DisplayMember = "Name"
        Me.SearchableComboBoxForm_Employee.Properties.NullText = "Select Employee"
        Me.SearchableComboBoxForm_Employee.Properties.ShowClearButton = false
        Me.SearchableComboBoxForm_Employee.Properties.ValueMember = "Code"
        Me.SearchableComboBoxForm_Employee.Properties.View = Me.SearchableComboBoxViewForm_Employee
        Me.SearchableComboBoxForm_Employee.SecurityEnabled = true
        Me.SearchableComboBoxForm_Employee.SelectedValue = Nothing
        Me.SearchableComboBoxForm_Employee.Size = New System.Drawing.Size(233, 20)
        Me.SearchableComboBoxForm_Employee.TabIndex = 130
        '
        'SearchableComboBoxViewForm_Employee
        '
        Me.SearchableComboBoxViewForm_Employee.AFActiveFilterString = ""
        Me.SearchableComboBoxViewForm_Employee.AllowExtraItemsInGridLookupEdits = true
        Me.SearchableComboBoxViewForm_Employee.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8!)
        Me.SearchableComboBoxViewForm_Employee.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8!)
        Me.SearchableComboBoxViewForm_Employee.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8!)
        Me.SearchableComboBoxViewForm_Employee.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8!)
        Me.SearchableComboBoxViewForm_Employee.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8!)
        Me.SearchableComboBoxViewForm_Employee.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8!)
        Me.SearchableComboBoxViewForm_Employee.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8!)
        Me.SearchableComboBoxViewForm_Employee.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8!)
        Me.SearchableComboBoxViewForm_Employee.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8!)
        Me.SearchableComboBoxViewForm_Employee.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8!)
        Me.SearchableComboBoxViewForm_Employee.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8!)
        Me.SearchableComboBoxViewForm_Employee.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8!)
        Me.SearchableComboBoxViewForm_Employee.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8!)
        Me.SearchableComboBoxViewForm_Employee.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8!)
        Me.SearchableComboBoxViewForm_Employee.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8!)
        Me.SearchableComboBoxViewForm_Employee.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8!)
        Me.SearchableComboBoxViewForm_Employee.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8!)
        Me.SearchableComboBoxViewForm_Employee.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8!)
        Me.SearchableComboBoxViewForm_Employee.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8!)
        Me.SearchableComboBoxViewForm_Employee.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8!)
        Me.SearchableComboBoxViewForm_Employee.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8!)
        Me.SearchableComboBoxViewForm_Employee.Appearance.Row.Font = New System.Drawing.Font("Arial", 8!)
        Me.SearchableComboBoxViewForm_Employee.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8!)
        Me.SearchableComboBoxViewForm_Employee.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8!)
        Me.SearchableComboBoxViewForm_Employee.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8!)
        Me.SearchableComboBoxViewForm_Employee.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8!)
        Me.SearchableComboBoxViewForm_Employee.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8!)
        Me.SearchableComboBoxViewForm_Employee.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8!)
        Me.SearchableComboBoxViewForm_Employee.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8!)
        Me.SearchableComboBoxViewForm_Employee.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8!)
        Me.SearchableComboBoxViewForm_Employee.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8!)
        Me.SearchableComboBoxViewForm_Employee.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8!)
        Me.SearchableComboBoxViewForm_Employee.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8!)
        Me.SearchableComboBoxViewForm_Employee.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8!)
        Me.SearchableComboBoxViewForm_Employee.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8!)
        Me.SearchableComboBoxViewForm_Employee.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8!)
        Me.SearchableComboBoxViewForm_Employee.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8!)
        Me.SearchableComboBoxViewForm_Employee.AutoFilterLookupColumns = false
        Me.SearchableComboBoxViewForm_Employee.AutoloadRepositoryDatasource = true
        Me.SearchableComboBoxViewForm_Employee.DataSourceClearing = false
        Me.SearchableComboBoxViewForm_Employee.EnableDisabledRows = false
        Me.SearchableComboBoxViewForm_Employee.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchableComboBoxViewForm_Employee.Name = "SearchableComboBoxViewForm_Employee"
        Me.SearchableComboBoxViewForm_Employee.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.SearchableComboBoxViewForm_Employee.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.SearchableComboBoxViewForm_Employee.OptionsBehavior.Editable = false
        Me.SearchableComboBoxViewForm_Employee.OptionsCustomization.AllowQuickHideColumns = false
        Me.SearchableComboBoxViewForm_Employee.OptionsNavigation.AutoFocusNewRow = true
        Me.SearchableComboBoxViewForm_Employee.OptionsSelection.EnableAppearanceFocusedCell = false
        Me.SearchableComboBoxViewForm_Employee.OptionsSelection.MultiSelect = true
        Me.SearchableComboBoxViewForm_Employee.OptionsView.ColumnAutoWidth = false
        Me.SearchableComboBoxViewForm_Employee.OptionsView.ShowGroupPanel = false
        Me.SearchableComboBoxViewForm_Employee.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
        Me.SearchableComboBoxViewForm_Employee.RunStandardValidation = true
        '
        'LabelForm_Code
        '
        Me.LabelForm_Code.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelForm_Code.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelForm_Code.Location = New System.Drawing.Point(12, 12)
        Me.LabelForm_Code.Name = "LabelForm_Code"
        Me.LabelForm_Code.Size = New System.Drawing.Size(81, 20)
        Me.LabelForm_Code.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelForm_Code.TabIndex = 127
        Me.LabelForm_Code.Text = "Code:"
        '
        'LabelForm_Employee
        '
        Me.LabelForm_Employee.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelForm_Employee.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelForm_Employee.Location = New System.Drawing.Point(12, 90)
        Me.LabelForm_Employee.Name = "LabelForm_Employee"
        Me.LabelForm_Employee.Size = New System.Drawing.Size(81, 20)
        Me.LabelForm_Employee.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelForm_Employee.TabIndex = 128
        Me.LabelForm_Employee.Text = "Employee:"
        '
        'TextBoxForm_Code
        '
        Me.TextBoxForm_Code.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxForm_Code.Border.Class = "TextBoxBorder"
        Me.TextBoxForm_Code.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxForm_Code.CheckSpellingOnValidate = false
        Me.TextBoxForm_Code.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
        Me.TextBoxForm_Code.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.TextBoxForm_Code.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
        Me.TextBoxForm_Code.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(230,Byte),Integer), CType(CType(141,Byte),Integer))
        Me.TextBoxForm_Code.FocusHighlightEnabled = true
        Me.TextBoxForm_Code.ForeColor = System.Drawing.Color.Black
        Me.TextBoxForm_Code.Location = New System.Drawing.Point(99, 12)
        Me.TextBoxForm_Code.MaxFileSize = CType(0,Long)
        Me.TextBoxForm_Code.Name = "TextBoxForm_Code"
        Me.TextBoxForm_Code.ReadOnly = true
        Me.TextBoxForm_Code.SecurityEnabled = true
        Me.TextBoxForm_Code.ShowSpellCheckCompleteMessage = true
        Me.TextBoxForm_Code.Size = New System.Drawing.Size(90, 20)
        Me.TextBoxForm_Code.StartingFolderName = Nothing
        Me.TextBoxForm_Code.TabIndex = 129
        Me.TextBoxForm_Code.TabOnEnter = true
        Me.TextBoxForm_Code.TabStop = false
        '
        'TextBoxForm_Name
        '
        Me.TextBoxForm_Name.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxForm_Name.Border.Class = "TextBoxBorder"
        Me.TextBoxForm_Name.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxForm_Name.CheckSpellingOnValidate = false
        Me.TextBoxForm_Name.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
        Me.TextBoxForm_Name.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.TextBoxForm_Name.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
        Me.TextBoxForm_Name.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(230,Byte),Integer), CType(CType(141,Byte),Integer))
        Me.TextBoxForm_Name.FocusHighlightEnabled = true
        Me.TextBoxForm_Name.ForeColor = System.Drawing.Color.Black
        Me.TextBoxForm_Name.Location = New System.Drawing.Point(99, 38)
        Me.TextBoxForm_Name.MaxFileSize = CType(0,Long)
        Me.TextBoxForm_Name.Name = "TextBoxForm_Name"
        Me.TextBoxForm_Name.ReadOnly = true
        Me.TextBoxForm_Name.SecurityEnabled = true
        Me.TextBoxForm_Name.ShowSpellCheckCompleteMessage = true
        Me.TextBoxForm_Name.Size = New System.Drawing.Size(233, 20)
        Me.TextBoxForm_Name.StartingFolderName = Nothing
        Me.TextBoxForm_Name.TabIndex = 135
        Me.TextBoxForm_Name.TabOnEnter = true
        Me.TextBoxForm_Name.TabStop = false
        '
        'GroupBoxControl_BudgetPeriod
        '
        Me.GroupBoxControl_BudgetPeriod.Controls.Add(Me.SearchableComboBoxBudgetPeriod_ToPostPeriod)
        Me.GroupBoxControl_BudgetPeriod.Controls.Add(Me.LabelBudgetPeriod_From)
        Me.GroupBoxControl_BudgetPeriod.Controls.Add(Me.LabelBudgetPeriod_To)
        Me.GroupBoxControl_BudgetPeriod.Controls.Add(Me.SearchableComboBoxBudgetPeriod_FromPostPeriod)
        Me.GroupBoxControl_BudgetPeriod.Location = New System.Drawing.Point(99, 116)
        Me.GroupBoxControl_BudgetPeriod.Name = "GroupBoxControl_BudgetPeriod"
        Me.GroupBoxControl_BudgetPeriod.Size = New System.Drawing.Size(233, 77)
        Me.GroupBoxControl_BudgetPeriod.TabIndex = 136
        Me.GroupBoxControl_BudgetPeriod.Text = "Budget Period"
        '
        'SearchableComboBoxBudgetPeriod_ToPostPeriod
        '
        Me.SearchableComboBoxBudgetPeriod_ToPostPeriod.ActiveFilterString = ""
        Me.SearchableComboBoxBudgetPeriod_ToPostPeriod.AddInactiveItemsOnSelectedValue = false
        Me.SearchableComboBoxBudgetPeriod_ToPostPeriod.AutoFillMode = false
        Me.SearchableComboBoxBudgetPeriod_ToPostPeriod.BookmarkingEnabled = false
        Me.SearchableComboBoxBudgetPeriod_ToPostPeriod.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.PostPeriod
        Me.SearchableComboBoxBudgetPeriod_ToPostPeriod.DataSource = Nothing
        Me.SearchableComboBoxBudgetPeriod_ToPostPeriod.DisableMouseWheel = true
        Me.SearchableComboBoxBudgetPeriod_ToPostPeriod.DisplayName = ""
        Me.SearchableComboBoxBudgetPeriod_ToPostPeriod.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
        Me.SearchableComboBoxBudgetPeriod_ToPostPeriod.Location = New System.Drawing.Point(50, 50)
        Me.SearchableComboBoxBudgetPeriod_ToPostPeriod.Name = "SearchableComboBoxBudgetPeriod_ToPostPeriod"
        Me.SearchableComboBoxBudgetPeriod_ToPostPeriod.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SearchableComboBoxBudgetPeriod_ToPostPeriod.Properties.DisplayMember = "Description"
        Me.SearchableComboBoxBudgetPeriod_ToPostPeriod.Properties.NullText = "Select Post Period"
        Me.SearchableComboBoxBudgetPeriod_ToPostPeriod.Properties.ShowClearButton = false
        Me.SearchableComboBoxBudgetPeriod_ToPostPeriod.Properties.ValueMember = "Code"
        Me.SearchableComboBoxBudgetPeriod_ToPostPeriod.Properties.View = Me.GridView2
        Me.SearchableComboBoxBudgetPeriod_ToPostPeriod.SecurityEnabled = true
        Me.SearchableComboBoxBudgetPeriod_ToPostPeriod.SelectedValue = Nothing
        Me.SearchableComboBoxBudgetPeriod_ToPostPeriod.Size = New System.Drawing.Size(140, 20)
        Me.SearchableComboBoxBudgetPeriod_ToPostPeriod.TabIndex = 118
        '
        'GridView2
        '
        Me.GridView2.AFActiveFilterString = ""
        Me.GridView2.AllowExtraItemsInGridLookupEdits = true
        Me.GridView2.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView2.Appearance.ColumnFilterButton.Options.UseFont = true
        Me.GridView2.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView2.Appearance.ColumnFilterButtonActive.Options.UseFont = true
        Me.GridView2.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView2.Appearance.CustomizationFormHint.Options.UseFont = true
        Me.GridView2.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView2.Appearance.DetailTip.Options.UseFont = true
        Me.GridView2.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView2.Appearance.Empty.Options.UseFont = true
        Me.GridView2.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView2.Appearance.EvenRow.Options.UseFont = true
        Me.GridView2.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView2.Appearance.FilterCloseButton.Options.UseFont = true
        Me.GridView2.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView2.Appearance.FilterPanel.Options.UseFont = true
        Me.GridView2.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView2.Appearance.FixedLine.Options.UseFont = true
        Me.GridView2.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView2.Appearance.FocusedCell.Options.UseFont = true
        Me.GridView2.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView2.Appearance.FocusedRow.Options.UseFont = true
        Me.GridView2.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView2.Appearance.FooterPanel.Options.UseFont = true
        Me.GridView2.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView2.Appearance.GroupButton.Options.UseFont = true
        Me.GridView2.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView2.Appearance.GroupFooter.Options.UseFont = true
        Me.GridView2.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView2.Appearance.GroupPanel.Options.UseFont = true
        Me.GridView2.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView2.Appearance.GroupRow.Options.UseFont = true
        Me.GridView2.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView2.Appearance.HeaderPanel.Options.UseFont = true
        Me.GridView2.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView2.Appearance.HideSelectionRow.Options.UseFont = true
        Me.GridView2.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView2.Appearance.HorzLine.Options.UseFont = true
        Me.GridView2.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView2.Appearance.OddRow.Options.UseFont = true
        Me.GridView2.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView2.Appearance.Preview.Options.UseFont = true
        Me.GridView2.Appearance.Row.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView2.Appearance.Row.Options.UseFont = true
        Me.GridView2.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView2.Appearance.RowSeparator.Options.UseFont = true
        Me.GridView2.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView2.Appearance.SelectedRow.Options.UseFont = true
        Me.GridView2.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView2.Appearance.TopNewRow.Options.UseFont = true
        Me.GridView2.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView2.Appearance.VertLine.Options.UseFont = true
        Me.GridView2.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView2.Appearance.ViewCaption.Options.UseFont = true
        Me.GridView2.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView2.AppearancePrint.EvenRow.Options.UseFont = true
        Me.GridView2.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView2.AppearancePrint.FilterPanel.Options.UseFont = true
        Me.GridView2.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView2.AppearancePrint.FooterPanel.Options.UseFont = true
        Me.GridView2.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView2.AppearancePrint.GroupFooter.Options.UseFont = true
        Me.GridView2.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView2.AppearancePrint.GroupRow.Options.UseFont = true
        Me.GridView2.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView2.AppearancePrint.HeaderPanel.Options.UseFont = true
        Me.GridView2.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView2.AppearancePrint.Lines.Options.UseFont = true
        Me.GridView2.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView2.AppearancePrint.OddRow.Options.UseFont = true
        Me.GridView2.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView2.AppearancePrint.Preview.Options.UseFont = true
        Me.GridView2.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView2.AppearancePrint.Row.Options.UseFont = true
        Me.GridView2.AutoFilterLookupColumns = false
        Me.GridView2.AutoloadRepositoryDatasource = true
        Me.GridView2.DataSourceClearing = false
        Me.GridView2.EnableDisabledRows = false
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView2.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView2.OptionsBehavior.Editable = false
        Me.GridView2.OptionsCustomization.AllowQuickHideColumns = false
        Me.GridView2.OptionsNavigation.AutoFocusNewRow = true
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = false
        Me.GridView2.OptionsSelection.MultiSelect = true
        Me.GridView2.OptionsView.ColumnAutoWidth = false
        Me.GridView2.OptionsView.ShowGroupPanel = false
        Me.GridView2.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
        Me.GridView2.RunStandardValidation = true
        '
        'LabelBudgetPeriod_From
        '
        Me.LabelBudgetPeriod_From.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelBudgetPeriod_From.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelBudgetPeriod_From.Location = New System.Drawing.Point(6, 24)
        Me.LabelBudgetPeriod_From.Name = "LabelBudgetPeriod_From"
        Me.LabelBudgetPeriod_From.Size = New System.Drawing.Size(38, 20)
        Me.LabelBudgetPeriod_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelBudgetPeriod_From.TabIndex = 0
        Me.LabelBudgetPeriod_From.Text = "From:"
        '
        'LabelBudgetPeriod_To
        '
        Me.LabelBudgetPeriod_To.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelBudgetPeriod_To.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelBudgetPeriod_To.Location = New System.Drawing.Point(6, 49)
        Me.LabelBudgetPeriod_To.Name = "LabelBudgetPeriod_To"
        Me.LabelBudgetPeriod_To.Size = New System.Drawing.Size(38, 20)
        Me.LabelBudgetPeriod_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelBudgetPeriod_To.TabIndex = 2
        Me.LabelBudgetPeriod_To.Text = "To:"
        '
        'SearchableComboBoxBudgetPeriod_FromPostPeriod
        '
        Me.SearchableComboBoxBudgetPeriod_FromPostPeriod.ActiveFilterString = ""
        Me.SearchableComboBoxBudgetPeriod_FromPostPeriod.AddInactiveItemsOnSelectedValue = false
        Me.SearchableComboBoxBudgetPeriod_FromPostPeriod.AutoFillMode = false
        Me.SearchableComboBoxBudgetPeriod_FromPostPeriod.BookmarkingEnabled = false
        Me.SearchableComboBoxBudgetPeriod_FromPostPeriod.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.PostPeriod
        Me.SearchableComboBoxBudgetPeriod_FromPostPeriod.DataSource = Nothing
        Me.SearchableComboBoxBudgetPeriod_FromPostPeriod.DisableMouseWheel = true
        Me.SearchableComboBoxBudgetPeriod_FromPostPeriod.DisplayName = ""
        Me.SearchableComboBoxBudgetPeriod_FromPostPeriod.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
        Me.SearchableComboBoxBudgetPeriod_FromPostPeriod.Location = New System.Drawing.Point(50, 24)
        Me.SearchableComboBoxBudgetPeriod_FromPostPeriod.Name = "SearchableComboBoxBudgetPeriod_FromPostPeriod"
        Me.SearchableComboBoxBudgetPeriod_FromPostPeriod.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SearchableComboBoxBudgetPeriod_FromPostPeriod.Properties.DisplayMember = "Description"
        Me.SearchableComboBoxBudgetPeriod_FromPostPeriod.Properties.NullText = "Select Post Period"
        Me.SearchableComboBoxBudgetPeriod_FromPostPeriod.Properties.ShowClearButton = false
        Me.SearchableComboBoxBudgetPeriod_FromPostPeriod.Properties.ValueMember = "Code"
        Me.SearchableComboBoxBudgetPeriod_FromPostPeriod.Properties.View = Me.GridView1
        Me.SearchableComboBoxBudgetPeriod_FromPostPeriod.SecurityEnabled = true
        Me.SearchableComboBoxBudgetPeriod_FromPostPeriod.SelectedValue = Nothing
        Me.SearchableComboBoxBudgetPeriod_FromPostPeriod.Size = New System.Drawing.Size(140, 20)
        Me.SearchableComboBoxBudgetPeriod_FromPostPeriod.TabIndex = 117
        '
        'GridView1
        '
        Me.GridView1.AFActiveFilterString = ""
        Me.GridView1.AllowExtraItemsInGridLookupEdits = true
        Me.GridView1.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView1.Appearance.ColumnFilterButton.Options.UseFont = true
        Me.GridView1.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView1.Appearance.ColumnFilterButtonActive.Options.UseFont = true
        Me.GridView1.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView1.Appearance.CustomizationFormHint.Options.UseFont = true
        Me.GridView1.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView1.Appearance.DetailTip.Options.UseFont = true
        Me.GridView1.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView1.Appearance.Empty.Options.UseFont = true
        Me.GridView1.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView1.Appearance.EvenRow.Options.UseFont = true
        Me.GridView1.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView1.Appearance.FilterCloseButton.Options.UseFont = true
        Me.GridView1.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView1.Appearance.FilterPanel.Options.UseFont = true
        Me.GridView1.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView1.Appearance.FixedLine.Options.UseFont = true
        Me.GridView1.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView1.Appearance.FocusedCell.Options.UseFont = true
        Me.GridView1.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView1.Appearance.FocusedRow.Options.UseFont = true
        Me.GridView1.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView1.Appearance.FooterPanel.Options.UseFont = true
        Me.GridView1.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView1.Appearance.GroupButton.Options.UseFont = true
        Me.GridView1.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView1.Appearance.GroupFooter.Options.UseFont = true
        Me.GridView1.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView1.Appearance.GroupPanel.Options.UseFont = true
        Me.GridView1.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView1.Appearance.GroupRow.Options.UseFont = true
        Me.GridView1.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView1.Appearance.HeaderPanel.Options.UseFont = true
        Me.GridView1.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView1.Appearance.HideSelectionRow.Options.UseFont = true
        Me.GridView1.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView1.Appearance.HorzLine.Options.UseFont = true
        Me.GridView1.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView1.Appearance.OddRow.Options.UseFont = true
        Me.GridView1.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView1.Appearance.Preview.Options.UseFont = true
        Me.GridView1.Appearance.Row.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView1.Appearance.Row.Options.UseFont = true
        Me.GridView1.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView1.Appearance.RowSeparator.Options.UseFont = true
        Me.GridView1.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView1.Appearance.SelectedRow.Options.UseFont = true
        Me.GridView1.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView1.Appearance.TopNewRow.Options.UseFont = true
        Me.GridView1.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView1.Appearance.VertLine.Options.UseFont = true
        Me.GridView1.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView1.Appearance.ViewCaption.Options.UseFont = true
        Me.GridView1.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView1.AppearancePrint.EvenRow.Options.UseFont = true
        Me.GridView1.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView1.AppearancePrint.FilterPanel.Options.UseFont = true
        Me.GridView1.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView1.AppearancePrint.FooterPanel.Options.UseFont = true
        Me.GridView1.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView1.AppearancePrint.GroupFooter.Options.UseFont = true
        Me.GridView1.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView1.AppearancePrint.GroupRow.Options.UseFont = true
        Me.GridView1.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView1.AppearancePrint.HeaderPanel.Options.UseFont = true
        Me.GridView1.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView1.AppearancePrint.Lines.Options.UseFont = true
        Me.GridView1.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView1.AppearancePrint.OddRow.Options.UseFont = true
        Me.GridView1.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView1.AppearancePrint.Preview.Options.UseFont = true
        Me.GridView1.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8!)
        Me.GridView1.AppearancePrint.Row.Options.UseFont = true
        Me.GridView1.AutoFilterLookupColumns = false
        Me.GridView1.AutoloadRepositoryDatasource = true
        Me.GridView1.DataSourceClearing = false
        Me.GridView1.EnableDisabledRows = false
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsBehavior.Editable = false
        Me.GridView1.OptionsCustomization.AllowQuickHideColumns = false
        Me.GridView1.OptionsNavigation.AutoFocusNewRow = true
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = false
        Me.GridView1.OptionsSelection.MultiSelect = true
        Me.GridView1.OptionsView.ColumnAutoWidth = false
        Me.GridView1.OptionsView.ShowGroupPanel = false
        Me.GridView1.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
        Me.GridView1.RunStandardValidation = true
        '
        'GroupBoxControl_SummaryDetail
        '
        Me.GroupBoxControl_SummaryDetail.Controls.Add(Me.RadioButtonSummaryDetail_Detail)
        Me.GroupBoxControl_SummaryDetail.Controls.Add(Me.RadioButtonSummaryDetail_Summary)
        Me.GroupBoxControl_SummaryDetail.Location = New System.Drawing.Point(99, 282)
        Me.GroupBoxControl_SummaryDetail.Name = "GroupBoxControl_SummaryDetail"
        Me.GroupBoxControl_SummaryDetail.Size = New System.Drawing.Size(233, 60)
        Me.GroupBoxControl_SummaryDetail.TabIndex = 138
        Me.GroupBoxControl_SummaryDetail.Text = "Category Selection"
        '
        'RadioButtonSummaryDetail_Detail
        '
        Me.RadioButtonSummaryDetail_Detail.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.RadioButtonSummaryDetail_Detail.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RadioButtonSummaryDetail_Detail.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.RadioButtonSummaryDetail_Detail.Location = New System.Drawing.Point(117, 24)
        Me.RadioButtonSummaryDetail_Detail.Name = "RadioButtonSummaryDetail_Detail"
        Me.RadioButtonSummaryDetail_Detail.SecurityEnabled = true
        Me.RadioButtonSummaryDetail_Detail.Size = New System.Drawing.Size(106, 20)
        Me.RadioButtonSummaryDetail_Detail.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RadioButtonSummaryDetail_Detail.TabIndex = 132
        Me.RadioButtonSummaryDetail_Detail.TabStop = false
        Me.RadioButtonSummaryDetail_Detail.Text = "Detail"
        '
        'RadioButtonSummaryDetail_Summary
        '
        Me.RadioButtonSummaryDetail_Summary.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.RadioButtonSummaryDetail_Summary.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RadioButtonSummaryDetail_Summary.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSummaryDetail_Summary.Checked = True
            Me.RadioButtonSummaryDetail_Summary.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonSummaryDetail_Summary.CheckValue = "Y"
            Me.RadioButtonSummaryDetail_Summary.Location = New System.Drawing.Point(5, 24)
            Me.RadioButtonSummaryDetail_Summary.Name = "RadioButtonSummaryDetail_Summary"
            Me.RadioButtonSummaryDetail_Summary.SecurityEnabled = True
            Me.RadioButtonSummaryDetail_Summary.Size = New System.Drawing.Size(106, 20)
            Me.RadioButtonSummaryDetail_Summary.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSummaryDetail_Summary.TabIndex = 131
            Me.RadioButtonSummaryDetail_Summary.Text = "Summary"
        '
        'GroupBoxControl_CategorySelection
        '
        Me.GroupBoxControl_CategorySelection.Controls.Add(Me.PanelCategorySelection_SalesClass)
        Me.GroupBoxControl_CategorySelection.Controls.Add(Me.LabelCategory_SalesClass)
        Me.GroupBoxControl_CategorySelection.Controls.Add(Me.LabelCategory_Type)
        Me.GroupBoxControl_CategorySelection.Controls.Add(Me.PanelCategorySelection_Type)
        Me.GroupBoxControl_CategorySelection.Location = New System.Drawing.Point(99, 199)
        Me.GroupBoxControl_CategorySelection.Name = "GroupBoxControl_CategorySelection"
        Me.GroupBoxControl_CategorySelection.Size = New System.Drawing.Size(233, 77)
        Me.GroupBoxControl_CategorySelection.TabIndex = 137
        Me.GroupBoxControl_CategorySelection.Text = "Category Selection"
        '
        'PanelCategorySelection_SalesClass
        '
        Me.PanelCategorySelection_SalesClass.Controls.Add(Me.RadioButtonCategorySalesClass_No)
        Me.PanelCategorySelection_SalesClass.Controls.Add(Me.RadioButtonCategorySalesClass_Yes)
        Me.PanelCategorySelection_SalesClass.Location = New System.Drawing.Point(84, 50)
        Me.PanelCategorySelection_SalesClass.Name = "PanelCategorySelection_SalesClass"
        Me.PanelCategorySelection_SalesClass.Size = New System.Drawing.Size(135, 20)
        Me.PanelCategorySelection_SalesClass.TabIndex = 129
        '
        'RadioButtonCategorySalesClass_No
        '
        Me.RadioButtonCategorySalesClass_No.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.RadioButtonCategorySalesClass_No.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RadioButtonCategorySalesClass_No.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.RadioButtonCategorySalesClass_No.Checked = true
        Me.RadioButtonCategorySalesClass_No.CheckState = System.Windows.Forms.CheckState.Checked
        Me.RadioButtonCategorySalesClass_No.CheckValue = "Y"
        Me.RadioButtonCategorySalesClass_No.Location = New System.Drawing.Point(70, 0)
        Me.RadioButtonCategorySalesClass_No.Name = "RadioButtonCategorySalesClass_No"
        Me.RadioButtonCategorySalesClass_No.SecurityEnabled = true
        Me.RadioButtonCategorySalesClass_No.Size = New System.Drawing.Size(65, 20)
        Me.RadioButtonCategorySalesClass_No.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RadioButtonCategorySalesClass_No.TabIndex = 130
        Me.RadioButtonCategorySalesClass_No.Text = "No"
        '
        'RadioButtonCategorySalesClass_Yes
        '
        Me.RadioButtonCategorySalesClass_Yes.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.RadioButtonCategorySalesClass_Yes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RadioButtonCategorySalesClass_Yes.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.RadioButtonCategorySalesClass_Yes.Location = New System.Drawing.Point(0, 0)
        Me.RadioButtonCategorySalesClass_Yes.Name = "RadioButtonCategorySalesClass_Yes"
        Me.RadioButtonCategorySalesClass_Yes.SecurityEnabled = true
        Me.RadioButtonCategorySalesClass_Yes.Size = New System.Drawing.Size(64, 20)
        Me.RadioButtonCategorySalesClass_Yes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RadioButtonCategorySalesClass_Yes.TabIndex = 129
        Me.RadioButtonCategorySalesClass_Yes.TabStop = false
        Me.RadioButtonCategorySalesClass_Yes.Text = "Yes"
        '
        'LabelCategory_SalesClass
        '
        Me.LabelCategory_SalesClass.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelCategory_SalesClass.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelCategory_SalesClass.Location = New System.Drawing.Point(5, 50)
        Me.LabelCategory_SalesClass.Name = "LabelCategory_SalesClass"
        Me.LabelCategory_SalesClass.Size = New System.Drawing.Size(73, 20)
        Me.LabelCategory_SalesClass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelCategory_SalesClass.TabIndex = 130
        Me.LabelCategory_SalesClass.Text = "Sales Class:"
        '
        'LabelCategory_Type
        '
        Me.LabelCategory_Type.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelCategory_Type.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelCategory_Type.Location = New System.Drawing.Point(5, 24)
        Me.LabelCategory_Type.Name = "LabelCategory_Type"
        Me.LabelCategory_Type.Size = New System.Drawing.Size(73, 20)
        Me.LabelCategory_Type.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelCategory_Type.TabIndex = 129
        Me.LabelCategory_Type.Text = "Type:"
        '
        'PanelCategorySelection_Type
        '
        Me.PanelCategorySelection_Type.Controls.Add(Me.RadioButtonCategoryType_No)
        Me.PanelCategorySelection_Type.Controls.Add(Me.RadioButtonCategoryType_Yes)
        Me.PanelCategorySelection_Type.Location = New System.Drawing.Point(84, 24)
        Me.PanelCategorySelection_Type.Name = "PanelCategorySelection_Type"
        Me.PanelCategorySelection_Type.Size = New System.Drawing.Size(135, 20)
        Me.PanelCategorySelection_Type.TabIndex = 128
        '
        'RadioButtonCategoryType_No
        '
        Me.RadioButtonCategoryType_No.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.RadioButtonCategoryType_No.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RadioButtonCategoryType_No.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.RadioButtonCategoryType_No.Checked = true
        Me.RadioButtonCategoryType_No.CheckState = System.Windows.Forms.CheckState.Checked
        Me.RadioButtonCategoryType_No.CheckValue = "Y"
        Me.RadioButtonCategoryType_No.Location = New System.Drawing.Point(70, 0)
        Me.RadioButtonCategoryType_No.Name = "RadioButtonCategoryType_No"
        Me.RadioButtonCategoryType_No.SecurityEnabled = true
        Me.RadioButtonCategoryType_No.Size = New System.Drawing.Size(65, 20)
        Me.RadioButtonCategoryType_No.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RadioButtonCategoryType_No.TabIndex = 130
        Me.RadioButtonCategoryType_No.Text = "No"
        '
        'RadioButtonCategoryType_Yes
        '
        Me.RadioButtonCategoryType_Yes.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.RadioButtonCategoryType_Yes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RadioButtonCategoryType_Yes.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.RadioButtonCategoryType_Yes.Location = New System.Drawing.Point(0, 0)
        Me.RadioButtonCategoryType_Yes.Name = "RadioButtonCategoryType_Yes"
        Me.RadioButtonCategoryType_Yes.SecurityEnabled = true
        Me.RadioButtonCategoryType_Yes.Size = New System.Drawing.Size(64, 20)
        Me.RadioButtonCategoryType_Yes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RadioButtonCategoryType_Yes.TabIndex = 129
        Me.RadioButtonCategoryType_Yes.TabStop = false
        Me.RadioButtonCategoryType_Yes.Text = "Yes"
        '
        'ClientBudgetAddDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(344, 380)
        Me.Controls.Add(Me.GroupBoxControl_SummaryDetail)
        Me.Controls.Add(Me.GroupBoxControl_CategorySelection)
        Me.Controls.Add(Me.GroupBoxControl_BudgetPeriod)
        Me.Controls.Add(Me.TextBoxForm_Name)
        Me.Controls.Add(Me.DateTimePickerForm_BudgetDate)
        Me.Controls.Add(Me.LabelForm_BudgetDate)
        Me.Controls.Add(Me.LabelForm_Name)
        Me.Controls.Add(Me.SearchableComboBoxForm_Employee)
        Me.Controls.Add(Me.LabelForm_Code)
        Me.Controls.Add(Me.LabelForm_Employee)
        Me.Controls.Add(Me.TextBoxForm_Code)
        Me.Controls.Add(Me.ButtonForm_Add)
        Me.Controls.Add(Me.ButtonForm_Cancel)
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.Name = "ClientBudgetAddDialog"
        Me.Text = "New Client Budget"
        CType(Me.DateTimePickerForm_BudgetDate,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.SearchableComboBoxForm_Employee.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.SearchableComboBoxViewForm_Employee,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GroupBoxControl_BudgetPeriod,System.ComponentModel.ISupportInitialize).EndInit
        Me.GroupBoxControl_BudgetPeriod.ResumeLayout(false)
        CType(Me.SearchableComboBoxBudgetPeriod_ToPostPeriod.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GridView2,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.SearchableComboBoxBudgetPeriod_FromPostPeriod.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GridView1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GroupBoxControl_SummaryDetail,System.ComponentModel.ISupportInitialize).EndInit
        Me.GroupBoxControl_SummaryDetail.ResumeLayout(false)
        CType(Me.GroupBoxControl_CategorySelection,System.ComponentModel.ISupportInitialize).EndInit
        Me.GroupBoxControl_CategorySelection.ResumeLayout(false)
        CType(Me.PanelCategorySelection_SalesClass,System.ComponentModel.ISupportInitialize).EndInit
        Me.PanelCategorySelection_SalesClass.ResumeLayout(false)
        CType(Me.PanelCategorySelection_Type,System.ComponentModel.ISupportInitialize).EndInit
        Me.PanelCategorySelection_Type.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Add As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DateTimePickerForm_BudgetDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents LabelForm_BudgetDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Name As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxForm_Employee As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewForm_Employee As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelForm_Code As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Employee As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_Code As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxForm_Name As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents GroupBoxControl_BudgetPeriod As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents SearchableComboBoxBudgetPeriod_ToPostPeriod As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView2 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelBudgetPeriod_From As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelBudgetPeriod_To As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxBudgetPeriod_FromPostPeriod As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView1 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents GroupBoxControl_SummaryDetail As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonSummaryDetail_Detail As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSummaryDetail_Summary As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents GroupBoxControl_CategorySelection As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents PanelCategorySelection_SalesClass As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents RadioButtonCategorySalesClass_No As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonCategorySalesClass_Yes As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents LabelCategory_SalesClass As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCategory_Type As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents PanelCategorySelection_Type As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents RadioButtonCategoryType_No As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonCategoryType_Yes As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
    End Class

End Namespace