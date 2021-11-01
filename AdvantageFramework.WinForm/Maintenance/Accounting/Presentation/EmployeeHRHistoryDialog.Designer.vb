Namespace Maintenance.Accounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class EmployeeHRHistoryDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseRibbonForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmployeeHRHistoryDialog))
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.LabelForm_StartDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DateTimePickerForm_StartDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerForm_EndDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelForm_EndDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_DepartmentTeam = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_EmployeeTitle = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_EmployeeTitle = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_AnnualSalary = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.NumericInputForm_AnnualSalary = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputForm_MonthlySalary = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelForm_MonthlySalary = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.NumericInputForm_CostRate = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelForm_CostRate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxForm_DepartmentTeam = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxForm_DepartmentTeamView = New AdvantageFramework.WinForm.Presentation.Controls.GridView(True)
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerForm_StartDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerForm_EndDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputForm_AnnualSalary.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputForm_MonthlySalary.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputForm_CostRate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxForm_DepartmentTeam.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxForm_DepartmentTeamView, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(350, 154)
            Me.RibbonControlForm_MainRibbon.SystemText.MaximizeRibbonText = "&Maximize the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatAddItemText = "&Add to Quick Access Toolbar"
            Me.RibbonControlForm_MainRibbon.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>"
            Me.RibbonControlForm_MainRibbon.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar..."
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogAddButton = "&Add >>"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogCancelButton = "Cancel"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogCaption = "Customize Quick Access Toolbar"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogCategoriesLabel = "&Choose commands from:"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogOkButton = "OK"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogRemoveButton = "&Remove"
            Me.RibbonControlForm_MainRibbon.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar"
            Me.RibbonControlForm_MainRibbon.Controls.SetChildIndex(Me.RibbonPanelFile_FilePanel, 0)
            '
            'RibbonPanelFile_FilePanel
            '
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(350, 95)
            '
            '
            '
            Me.RibbonPanelFile_FilePanel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonPanelFile_FilePanel.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonPanelFile_FilePanel.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFilePanel_System, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Actions, 0)
            '
            'RibbonBarFilePanel_System
            '
            '
            '
            '
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_System.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_System.Size = New System.Drawing.Size(10, 92)
            '
            '
            '
            Me.RibbonBarFilePanel_System.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_System.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemSystem_Close
            '
            Me.ButtonItemSystem_Close.Image = AdvantageFramework.My.Resources.ExitImage
            '
            'PanelForm_Form
            '
            Me.PanelForm_Form.Controls.Add(Me.SearchableComboBoxForm_DepartmentTeam)
            Me.PanelForm_Form.Controls.Add(Me.NumericInputForm_CostRate)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_CostRate)
            Me.PanelForm_Form.Controls.Add(Me.NumericInputForm_MonthlySalary)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_MonthlySalary)
            Me.PanelForm_Form.Controls.Add(Me.NumericInputForm_AnnualSalary)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_AnnualSalary)
            Me.PanelForm_Form.Controls.Add(Me.ComboBoxForm_EmployeeTitle)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_EmployeeTitle)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_DepartmentTeam)
            Me.PanelForm_Form.Controls.Add(Me.DateTimePickerForm_EndDate)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_EndDate)
            Me.PanelForm_Form.Controls.Add(Me.DateTimePickerForm_StartDate)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_StartDate)
            Me.PanelForm_Form.Size = New System.Drawing.Size(350, 236)
            Me.PanelForm_Form.TabIndex = 0
            '
            'BarForm_StatusBar
            '
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 391)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(350, 18)
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Add, Me.ButtonItemActions_Save, Me.ButtonItemActions_Cancel})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(13, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(124, 92)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 10
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
            'ButtonItemActions_Add
            '
            Me.ButtonItemActions_Add.BeginGroup = True
            Me.ButtonItemActions_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Add.Name = "ButtonItemActions_Add"
            Me.ButtonItemActions_Add.RibbonWordWrap = False
            Me.ButtonItemActions_Add.SecurityEnabled = True
            Me.ButtonItemActions_Add.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Add.Text = "Add"
            '
            'ButtonItemActions_Save
            '
            Me.ButtonItemActions_Save.BeginGroup = True
            Me.ButtonItemActions_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Save.Name = "ButtonItemActions_Save"
            Me.ButtonItemActions_Save.RibbonWordWrap = False
            Me.ButtonItemActions_Save.SecurityEnabled = True
            Me.ButtonItemActions_Save.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Save.Text = "Save"
            '
            'ButtonItemActions_Cancel
            '
            Me.ButtonItemActions_Cancel.BeginGroup = True
            Me.ButtonItemActions_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Cancel.Name = "ButtonItemActions_Cancel"
            Me.ButtonItemActions_Cancel.RibbonWordWrap = False
            Me.ButtonItemActions_Cancel.SecurityEnabled = True
            Me.ButtonItemActions_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Cancel.Text = "Cancel"
            '
            'LabelForm_StartDate
            '
            Me.LabelForm_StartDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_StartDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_StartDate.Location = New System.Drawing.Point(12, 6)
            Me.LabelForm_StartDate.Name = "LabelForm_StartDate"
            Me.LabelForm_StartDate.Size = New System.Drawing.Size(98, 20)
            Me.LabelForm_StartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_StartDate.TabIndex = 0
            Me.LabelForm_StartDate.Text = "Start Date:"
            '
            'DateTimePickerForm_StartDate
            '
            Me.DateTimePickerForm_StartDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DateTimePickerForm_StartDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerForm_StartDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerForm_StartDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_StartDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerForm_StartDate.ButtonDropDown.Visible = True
            Me.DateTimePickerForm_StartDate.ButtonFreeText.Checked = True
            Me.DateTimePickerForm_StartDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePickerForm_StartDate.CustomFormat = ""
            Me.DateTimePickerForm_StartDate.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePickerForm_StartDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerForm_StartDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerForm_StartDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerForm_StartDate.FocusHighlightEnabled = True
            Me.DateTimePickerForm_StartDate.Format = DevComponents.Editors.eDateTimePickerFormat.Short
            Me.DateTimePickerForm_StartDate.FreeTextEntryMode = True
            Me.DateTimePickerForm_StartDate.IsPopupCalendarOpen = False
            Me.DateTimePickerForm_StartDate.Location = New System.Drawing.Point(116, 6)
            Me.DateTimePickerForm_StartDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerForm_StartDate.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerForm_StartDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_StartDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerForm_StartDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerForm_StartDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerForm_StartDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_StartDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerForm_StartDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerForm_StartDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerForm_StartDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerForm_StartDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_StartDate.MonthCalendar.DisplayMonth = New Date(2013, 12, 1, 0, 0, 0, 0)
            Me.DateTimePickerForm_StartDate.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerForm_StartDate.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerForm_StartDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerForm_StartDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_StartDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerForm_StartDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_StartDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerForm_StartDate.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerForm_StartDate.Name = "DateTimePickerForm_StartDate"
            Me.DateTimePickerForm_StartDate.ReadOnly = False
            Me.DateTimePickerForm_StartDate.Size = New System.Drawing.Size(222, 20)
            Me.DateTimePickerForm_StartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_StartDate.TabIndex = 1
            Me.DateTimePickerForm_StartDate.Value = New Date(2013, 12, 18, 16, 4, 1, 817)
            '
            'DateTimePickerForm_EndDate
            '
            Me.DateTimePickerForm_EndDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DateTimePickerForm_EndDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerForm_EndDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerForm_EndDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_EndDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerForm_EndDate.ButtonDropDown.Visible = True
            Me.DateTimePickerForm_EndDate.ButtonFreeText.Checked = True
            Me.DateTimePickerForm_EndDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePickerForm_EndDate.CustomFormat = ""
            Me.DateTimePickerForm_EndDate.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePickerForm_EndDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerForm_EndDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerForm_EndDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerForm_EndDate.FocusHighlightEnabled = True
            Me.DateTimePickerForm_EndDate.Format = DevComponents.Editors.eDateTimePickerFormat.Short
            Me.DateTimePickerForm_EndDate.FreeTextEntryMode = True
            Me.DateTimePickerForm_EndDate.IsPopupCalendarOpen = False
            Me.DateTimePickerForm_EndDate.Location = New System.Drawing.Point(116, 32)
            Me.DateTimePickerForm_EndDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerForm_EndDate.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerForm_EndDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_EndDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerForm_EndDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerForm_EndDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerForm_EndDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_EndDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerForm_EndDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerForm_EndDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerForm_EndDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerForm_EndDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_EndDate.MonthCalendar.DisplayMonth = New Date(2013, 12, 1, 0, 0, 0, 0)
            Me.DateTimePickerForm_EndDate.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerForm_EndDate.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerForm_EndDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerForm_EndDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_EndDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerForm_EndDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_EndDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerForm_EndDate.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerForm_EndDate.Name = "DateTimePickerForm_EndDate"
            Me.DateTimePickerForm_EndDate.ReadOnly = False
            Me.DateTimePickerForm_EndDate.Size = New System.Drawing.Size(222, 20)
            Me.DateTimePickerForm_EndDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_EndDate.TabIndex = 3
            Me.DateTimePickerForm_EndDate.Value = New Date(2013, 12, 18, 16, 4, 1, 817)
            '
            'LabelForm_EndDate
            '
            Me.LabelForm_EndDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_EndDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_EndDate.Location = New System.Drawing.Point(12, 32)
            Me.LabelForm_EndDate.Name = "LabelForm_EndDate"
            Me.LabelForm_EndDate.Size = New System.Drawing.Size(98, 20)
            Me.LabelForm_EndDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_EndDate.TabIndex = 2
            Me.LabelForm_EndDate.Text = "End Date:"
            '
            'LabelForm_DepartmentTeam
            '
            Me.LabelForm_DepartmentTeam.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_DepartmentTeam.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_DepartmentTeam.Location = New System.Drawing.Point(12, 58)
            Me.LabelForm_DepartmentTeam.Name = "LabelForm_DepartmentTeam"
            Me.LabelForm_DepartmentTeam.Size = New System.Drawing.Size(98, 20)
            Me.LabelForm_DepartmentTeam.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_DepartmentTeam.TabIndex = 4
            Me.LabelForm_DepartmentTeam.Text = "Department/Team:"
            '
            'ComboBoxForm_EmployeeTitle
            '
            Me.ComboBoxForm_EmployeeTitle.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_EmployeeTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_EmployeeTitle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_EmployeeTitle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_EmployeeTitle.AutoFindItemInDataSource = False
            Me.ComboBoxForm_EmployeeTitle.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_EmployeeTitle.BookmarkingEnabled = False
            Me.ComboBoxForm_EmployeeTitle.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EmployeeTitle
            Me.ComboBoxForm_EmployeeTitle.DisableMouseWheel = False
            Me.ComboBoxForm_EmployeeTitle.DisplayMember = "Description"
            Me.ComboBoxForm_EmployeeTitle.DisplayName = ""
            Me.ComboBoxForm_EmployeeTitle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_EmployeeTitle.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_EmployeeTitle.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.None
            Me.ComboBoxForm_EmployeeTitle.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_EmployeeTitle.FocusHighlightEnabled = True
            Me.ComboBoxForm_EmployeeTitle.FormattingEnabled = True
            Me.ComboBoxForm_EmployeeTitle.ItemHeight = 14
            Me.ComboBoxForm_EmployeeTitle.Location = New System.Drawing.Point(116, 84)
            Me.ComboBoxForm_EmployeeTitle.Name = "ComboBoxForm_EmployeeTitle"
            Me.ComboBoxForm_EmployeeTitle.PreventEnterBeep = False
            Me.ComboBoxForm_EmployeeTitle.ReadOnly = False
            Me.ComboBoxForm_EmployeeTitle.SecurityEnabled = True
            Me.ComboBoxForm_EmployeeTitle.Size = New System.Drawing.Size(222, 20)
            Me.ComboBoxForm_EmployeeTitle.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_EmployeeTitle.TabIndex = 7
            Me.ComboBoxForm_EmployeeTitle.ValueMember = "ID"
            Me.ComboBoxForm_EmployeeTitle.WatermarkText = "Select Employee Title"
            '
            'LabelForm_EmployeeTitle
            '
            Me.LabelForm_EmployeeTitle.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_EmployeeTitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_EmployeeTitle.Location = New System.Drawing.Point(12, 84)
            Me.LabelForm_EmployeeTitle.Name = "LabelForm_EmployeeTitle"
            Me.LabelForm_EmployeeTitle.Size = New System.Drawing.Size(98, 20)
            Me.LabelForm_EmployeeTitle.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_EmployeeTitle.TabIndex = 6
            Me.LabelForm_EmployeeTitle.Text = "Employee Title:"
            '
            'LabelForm_AnnualSalary
            '
            Me.LabelForm_AnnualSalary.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_AnnualSalary.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_AnnualSalary.Location = New System.Drawing.Point(12, 110)
            Me.LabelForm_AnnualSalary.Name = "LabelForm_AnnualSalary"
            Me.LabelForm_AnnualSalary.Size = New System.Drawing.Size(98, 20)
            Me.LabelForm_AnnualSalary.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_AnnualSalary.TabIndex = 8
            Me.LabelForm_AnnualSalary.Text = "Annual Salary:"
            '
            'NumericInputForm_AnnualSalary
            '
            Me.NumericInputForm_AnnualSalary.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputForm_AnnualSalary.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.NumericInputForm_AnnualSalary.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Default]
            Me.NumericInputForm_AnnualSalary.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputForm_AnnualSalary.Location = New System.Drawing.Point(116, 110)
            Me.NumericInputForm_AnnualSalary.Name = "NumericInputForm_AnnualSalary"
            Me.NumericInputForm_AnnualSalary.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputForm_AnnualSalary.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputForm_AnnualSalary.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputForm_AnnualSalary.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_AnnualSalary.Properties.EditFormat.FormatString = "f"
            Me.NumericInputForm_AnnualSalary.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_AnnualSalary.Properties.Mask.EditMask = "f"
            Me.NumericInputForm_AnnualSalary.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputForm_AnnualSalary.Size = New System.Drawing.Size(222, 20)
            Me.NumericInputForm_AnnualSalary.TabIndex = 9
            '
            'NumericInputForm_MonthlySalary
            '
            Me.NumericInputForm_MonthlySalary.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputForm_MonthlySalary.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.NumericInputForm_MonthlySalary.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Default]
            Me.NumericInputForm_MonthlySalary.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputForm_MonthlySalary.Location = New System.Drawing.Point(116, 136)
            Me.NumericInputForm_MonthlySalary.Name = "NumericInputForm_MonthlySalary"
            Me.NumericInputForm_MonthlySalary.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputForm_MonthlySalary.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputForm_MonthlySalary.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputForm_MonthlySalary.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_MonthlySalary.Properties.EditFormat.FormatString = "f"
            Me.NumericInputForm_MonthlySalary.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_MonthlySalary.Properties.Mask.EditMask = "f"
            Me.NumericInputForm_MonthlySalary.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputForm_MonthlySalary.Size = New System.Drawing.Size(222, 20)
            Me.NumericInputForm_MonthlySalary.TabIndex = 11
            '
            'LabelForm_MonthlySalary
            '
            Me.LabelForm_MonthlySalary.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_MonthlySalary.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_MonthlySalary.Location = New System.Drawing.Point(12, 136)
            Me.LabelForm_MonthlySalary.Name = "LabelForm_MonthlySalary"
            Me.LabelForm_MonthlySalary.Size = New System.Drawing.Size(98, 20)
            Me.LabelForm_MonthlySalary.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_MonthlySalary.TabIndex = 10
            Me.LabelForm_MonthlySalary.Text = "Monthly Salary:"
            '
            'NumericInputForm_CostRate
            '
            Me.NumericInputForm_CostRate.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputForm_CostRate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.NumericInputForm_CostRate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Default]
            Me.NumericInputForm_CostRate.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputForm_CostRate.Location = New System.Drawing.Point(116, 162)
            Me.NumericInputForm_CostRate.Name = "NumericInputForm_CostRate"
            Me.NumericInputForm_CostRate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputForm_CostRate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputForm_CostRate.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputForm_CostRate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_CostRate.Properties.EditFormat.FormatString = "f"
            Me.NumericInputForm_CostRate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_CostRate.Properties.Mask.EditMask = "f"
            Me.NumericInputForm_CostRate.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputForm_CostRate.Size = New System.Drawing.Size(222, 20)
            Me.NumericInputForm_CostRate.TabIndex = 13
            '
            'LabelForm_CostRate
            '
            Me.LabelForm_CostRate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_CostRate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_CostRate.Location = New System.Drawing.Point(12, 162)
            Me.LabelForm_CostRate.Name = "LabelForm_CostRate"
            Me.LabelForm_CostRate.Size = New System.Drawing.Size(98, 20)
            Me.LabelForm_CostRate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_CostRate.TabIndex = 12
            Me.LabelForm_CostRate.Text = "Cost Rate:"
            '
            'SearchableComboBoxForm_DepartmentTeam
            '
            Me.SearchableComboBoxForm_DepartmentTeam.ActiveFilterString = ""
            Me.SearchableComboBoxForm_DepartmentTeam.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxForm_DepartmentTeam.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxForm_DepartmentTeam.BookmarkingEnabled = False
            Me.SearchableComboBoxForm_DepartmentTeam.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.DepartmentTeam
            Me.SearchableComboBoxForm_DepartmentTeam.DataSource = Nothing
            Me.SearchableComboBoxForm_DepartmentTeam.DisableMouseWheel = False
            Me.SearchableComboBoxForm_DepartmentTeam.DisplayName = ""
            Me.SearchableComboBoxForm_DepartmentTeam.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.None
            Me.SearchableComboBoxForm_DepartmentTeam.Location = New System.Drawing.Point(116, 58)
            Me.SearchableComboBoxForm_DepartmentTeam.Name = "SearchableComboBoxForm_DepartmentTeam"
            Me.SearchableComboBoxForm_DepartmentTeam.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxForm_DepartmentTeam.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxForm_DepartmentTeam.Properties.NullText = "Select Department / Team"
            Me.SearchableComboBoxForm_DepartmentTeam.Properties.ShowClearButton = False
            Me.SearchableComboBoxForm_DepartmentTeam.Properties.ValueMember = "Code"
            Me.SearchableComboBoxForm_DepartmentTeam.Properties.View = Me.SearchableComboBoxForm_DepartmentTeamView
            Me.SearchableComboBoxForm_DepartmentTeam.SecurityEnabled = True
            Me.SearchableComboBoxForm_DepartmentTeam.SelectedValue = Nothing
            Me.SearchableComboBoxForm_DepartmentTeam.Size = New System.Drawing.Size(222, 20)
            Me.SearchableComboBoxForm_DepartmentTeam.TabIndex = 5
            '
            'SearchableComboBoxForm_DepartmentTeamView
            '
            Me.SearchableComboBoxForm_DepartmentTeamView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxForm_DepartmentTeamView.Name = "SearchableComboBoxForm_DepartmentTeamView"
            Me.SearchableComboBoxForm_DepartmentTeamView.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxForm_DepartmentTeamView.OptionsView.ShowGroupPanel = False
            '
            'EmployeeHRHistoryDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(360, 411)
            Me.CloseButtonVisible = False
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "EmployeeHRHistoryDialog"
            Me.Text = "Employee H/R History"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerForm_StartDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerForm_EndDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputForm_AnnualSalary.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputForm_MonthlySalary.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputForm_CostRate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxForm_DepartmentTeam.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxForm_DepartmentTeamView, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Save As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents NumericInputForm_AnnualSalary As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents LabelForm_AnnualSalary As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_EmployeeTitle As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_EmployeeTitle As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_DepartmentTeam As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerForm_EndDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents LabelForm_EndDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerForm_StartDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents LabelForm_StartDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents NumericInputForm_CostRate As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents LabelForm_CostRate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents NumericInputForm_MonthlySalary As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents LabelForm_MonthlySalary As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxForm_DepartmentTeam As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxForm_DepartmentTeamView As AdvantageFramework.WinForm.Presentation.Controls.GridView

    End Class

End Namespace