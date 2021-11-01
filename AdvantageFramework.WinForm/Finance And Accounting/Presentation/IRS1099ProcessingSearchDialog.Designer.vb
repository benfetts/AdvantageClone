Namespace FinanceAndAccounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class IRS1099ProcessingSearchDialog
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
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IRS1099ProcessingSearchDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelCheckDate_Starting = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCheckDate_Ending = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxForm_CheckDates = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.DateTimePickerCheckDates_Ending = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerCheckDates_Starting = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.PanelForm_Banks = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.PanelBanks_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ButtonRightSection_RemoveBank = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonRightSection_AddBank = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewRightSection_Banks = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterSection_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelBanks_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_Banks = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            CType(Me.GroupBoxForm_CheckDates, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxForm_CheckDates.SuspendLayout()
            CType(Me.DateTimePickerCheckDates_Ending, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerCheckDates_Starting, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PanelForm_Banks, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Banks.SuspendLayout()
            CType(Me.PanelBanks_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelBanks_RightSection.SuspendLayout()
            CType(Me.PanelBanks_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelBanks_LeftSection.SuspendLayout()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(399, 396)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 2
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(480, 396)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 3
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'LabelCheckDate_Starting
            '
            Me.LabelCheckDate_Starting.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCheckDate_Starting.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCheckDate_Starting.Location = New System.Drawing.Point(5, 24)
            Me.LabelCheckDate_Starting.Name = "LabelCheckDate_Starting"
            Me.LabelCheckDate_Starting.Size = New System.Drawing.Size(63, 20)
            Me.LabelCheckDate_Starting.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCheckDate_Starting.TabIndex = 0
            Me.LabelCheckDate_Starting.Text = "Starting:"
            '
            'LabelCheckDate_Ending
            '
            Me.LabelCheckDate_Ending.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCheckDate_Ending.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCheckDate_Ending.Location = New System.Drawing.Point(5, 50)
            Me.LabelCheckDate_Ending.Name = "LabelCheckDate_Ending"
            Me.LabelCheckDate_Ending.Size = New System.Drawing.Size(63, 20)
            Me.LabelCheckDate_Ending.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCheckDate_Ending.TabIndex = 2
            Me.LabelCheckDate_Ending.Text = "Ending:"
            '
            'GroupBoxForm_CheckDates
            '
            Me.GroupBoxForm_CheckDates.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxForm_CheckDates.Controls.Add(Me.DateTimePickerCheckDates_Ending)
            Me.GroupBoxForm_CheckDates.Controls.Add(Me.DateTimePickerCheckDates_Starting)
            Me.GroupBoxForm_CheckDates.Controls.Add(Me.LabelCheckDate_Ending)
            Me.GroupBoxForm_CheckDates.Controls.Add(Me.LabelCheckDate_Starting)
            Me.GroupBoxForm_CheckDates.Location = New System.Drawing.Point(12, 292)
            Me.GroupBoxForm_CheckDates.Name = "GroupBoxForm_CheckDates"
            Me.GroupBoxForm_CheckDates.Size = New System.Drawing.Size(543, 98)
            Me.GroupBoxForm_CheckDates.TabIndex = 1
            Me.GroupBoxForm_CheckDates.TabStop = True
            Me.GroupBoxForm_CheckDates.Text = "Check Date(s)"
            '
            'DateTimePickerCheckDates_Ending
            '
            Me.DateTimePickerCheckDates_Ending.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerCheckDates_Ending.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerCheckDates_Ending.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerCheckDates_Ending.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerCheckDates_Ending.ButtonDropDown.Visible = True
            Me.DateTimePickerCheckDates_Ending.ButtonFreeText.Checked = True
            Me.DateTimePickerCheckDates_Ending.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerCheckDates_Ending.CustomFormat = ""
            Me.DateTimePickerCheckDates_Ending.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerCheckDates_Ending.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerCheckDates_Ending.FocusHighlightEnabled = True
            Me.DateTimePickerCheckDates_Ending.Format = DevComponents.Editors.eDateTimePickerFormat.Short
            Me.DateTimePickerCheckDates_Ending.FreeTextEntryMode = True
            Me.DateTimePickerCheckDates_Ending.IsPopupCalendarOpen = False
            Me.DateTimePickerCheckDates_Ending.Location = New System.Drawing.Point(74, 50)
            Me.DateTimePickerCheckDates_Ending.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerCheckDates_Ending.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerCheckDates_Ending.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerCheckDates_Ending.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerCheckDates_Ending.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerCheckDates_Ending.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerCheckDates_Ending.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerCheckDates_Ending.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerCheckDates_Ending.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerCheckDates_Ending.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerCheckDates_Ending.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerCheckDates_Ending.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerCheckDates_Ending.MonthCalendar.DisplayMonth = New Date(2013, 9, 1, 0, 0, 0, 0)
            Me.DateTimePickerCheckDates_Ending.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerCheckDates_Ending.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerCheckDates_Ending.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerCheckDates_Ending.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerCheckDates_Ending.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerCheckDates_Ending.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerCheckDates_Ending.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerCheckDates_Ending.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerCheckDates_Ending.Name = "DateTimePickerCheckDates_Ending"
            Me.DateTimePickerCheckDates_Ending.ReadOnly = False
            Me.DateTimePickerCheckDates_Ending.Size = New System.Drawing.Size(104, 20)
            Me.DateTimePickerCheckDates_Ending.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerCheckDates_Ending.TabIndex = 3
            Me.DateTimePickerCheckDates_Ending.Value = New Date(2013, 9, 9, 16, 22, 58, 799)
            '
            'DateTimePickerCheckDates_Starting
            '
            Me.DateTimePickerCheckDates_Starting.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerCheckDates_Starting.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerCheckDates_Starting.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerCheckDates_Starting.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerCheckDates_Starting.ButtonDropDown.Visible = True
            Me.DateTimePickerCheckDates_Starting.ButtonFreeText.Checked = True
            Me.DateTimePickerCheckDates_Starting.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerCheckDates_Starting.CustomFormat = ""
            Me.DateTimePickerCheckDates_Starting.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerCheckDates_Starting.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerCheckDates_Starting.FocusHighlightEnabled = True
            Me.DateTimePickerCheckDates_Starting.Format = DevComponents.Editors.eDateTimePickerFormat.Short
            Me.DateTimePickerCheckDates_Starting.FreeTextEntryMode = True
            Me.DateTimePickerCheckDates_Starting.IsPopupCalendarOpen = False
            Me.DateTimePickerCheckDates_Starting.Location = New System.Drawing.Point(74, 24)
            Me.DateTimePickerCheckDates_Starting.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerCheckDates_Starting.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerCheckDates_Starting.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerCheckDates_Starting.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerCheckDates_Starting.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerCheckDates_Starting.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerCheckDates_Starting.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerCheckDates_Starting.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerCheckDates_Starting.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerCheckDates_Starting.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerCheckDates_Starting.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerCheckDates_Starting.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerCheckDates_Starting.MonthCalendar.DisplayMonth = New Date(2013, 9, 1, 0, 0, 0, 0)
            Me.DateTimePickerCheckDates_Starting.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerCheckDates_Starting.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerCheckDates_Starting.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerCheckDates_Starting.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerCheckDates_Starting.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerCheckDates_Starting.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerCheckDates_Starting.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerCheckDates_Starting.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerCheckDates_Starting.Name = "DateTimePickerCheckDates_Starting"
            Me.DateTimePickerCheckDates_Starting.ReadOnly = False
            Me.DateTimePickerCheckDates_Starting.Size = New System.Drawing.Size(104, 20)
            Me.DateTimePickerCheckDates_Starting.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerCheckDates_Starting.TabIndex = 1
            Me.DateTimePickerCheckDates_Starting.Value = New Date(2013, 9, 9, 16, 22, 58, 799)
            '
            'PanelForm_Banks
            '
            Me.PanelForm_Banks.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelForm_Banks.Controls.Add(Me.PanelBanks_RightSection)
            Me.PanelForm_Banks.Controls.Add(Me.ExpandableSplitterSection_LeftRight)
            Me.PanelForm_Banks.Controls.Add(Me.PanelBanks_LeftSection)
            Me.PanelForm_Banks.Location = New System.Drawing.Point(12, 12)
            Me.PanelForm_Banks.Name = "PanelForm_Banks"
            Me.PanelForm_Banks.Size = New System.Drawing.Size(543, 274)
            Me.PanelForm_Banks.TabIndex = 0
            '
            'PanelBanks_RightSection
            '
            Me.PanelBanks_RightSection.Controls.Add(Me.ButtonRightSection_RemoveBank)
            Me.PanelBanks_RightSection.Controls.Add(Me.ButtonRightSection_AddBank)
            Me.PanelBanks_RightSection.Controls.Add(Me.DataGridViewRightSection_Banks)
            Me.PanelBanks_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelBanks_RightSection.Location = New System.Drawing.Point(208, 2)
            Me.PanelBanks_RightSection.Name = "PanelBanks_RightSection"
            Me.PanelBanks_RightSection.Size = New System.Drawing.Size(333, 270)
            Me.PanelBanks_RightSection.TabIndex = 1
            '
            'ButtonRightSection_RemoveBank
            '
            Me.ButtonRightSection_RemoveBank.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_RemoveBank.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_RemoveBank.Location = New System.Drawing.Point(6, 36)
            Me.ButtonRightSection_RemoveBank.Name = "ButtonRightSection_RemoveBank"
            Me.ButtonRightSection_RemoveBank.SecurityEnabled = True
            Me.ButtonRightSection_RemoveBank.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightSection_RemoveBank.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_RemoveBank.TabIndex = 1
            Me.ButtonRightSection_RemoveBank.Text = "<"
            '
            'ButtonRightSection_AddBank
            '
            Me.ButtonRightSection_AddBank.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_AddBank.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_AddBank.Location = New System.Drawing.Point(6, 10)
            Me.ButtonRightSection_AddBank.Name = "ButtonRightSection_AddBank"
            Me.ButtonRightSection_AddBank.SecurityEnabled = True
            Me.ButtonRightSection_AddBank.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightSection_AddBank.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_AddBank.TabIndex = 0
            Me.ButtonRightSection_AddBank.Text = ">"
            '
            'DataGridViewRightSection_Banks
            '
            Me.DataGridViewRightSection_Banks.AllowSelectGroupHeaderRow = True
            Me.DataGridViewRightSection_Banks.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewRightSection_Banks.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRightSection_Banks.AutoFilterLookupColumns = False
            Me.DataGridViewRightSection_Banks.AutoloadRepositoryDatasource = True
            Me.DataGridViewRightSection_Banks.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewRightSection_Banks.DataSource = Nothing
            Me.DataGridViewRightSection_Banks.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewRightSection_Banks.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRightSection_Banks.ItemDescription = "Selected Bank(s)"
            Me.DataGridViewRightSection_Banks.Location = New System.Drawing.Point(87, 10)
            Me.DataGridViewRightSection_Banks.MultiSelect = True
            Me.DataGridViewRightSection_Banks.Name = "DataGridViewRightSection_Banks"
            Me.DataGridViewRightSection_Banks.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewRightSection_Banks.RunStandardValidation = True
            Me.DataGridViewRightSection_Banks.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRightSection_Banks.Size = New System.Drawing.Size(236, 250)
            Me.DataGridViewRightSection_Banks.TabIndex = 2
            Me.DataGridViewRightSection_Banks.UseEmbeddedNavigator = False
            Me.DataGridViewRightSection_Banks.ViewCaptionHeight = -1
            '
            'ExpandableSplitterSection_LeftRight
            '
            Me.ExpandableSplitterSection_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterSection_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterSection_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterSection_LeftRight.ExpandableControl = Me.PanelBanks_LeftSection
            Me.ExpandableSplitterSection_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterSection_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterSection_LeftRight.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterSection_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterSection_LeftRight.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterSection_LeftRight.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterSection_LeftRight.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterSection_LeftRight.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterSection_LeftRight.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterSection_LeftRight.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterSection_LeftRight.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterSection_LeftRight.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterSection_LeftRight.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterSection_LeftRight.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterSection_LeftRight.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterSection_LeftRight.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterSection_LeftRight.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterSection_LeftRight.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterSection_LeftRight.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterSection_LeftRight.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterSection_LeftRight.Location = New System.Drawing.Point(202, 2)
            Me.ExpandableSplitterSection_LeftRight.Name = "ExpandableSplitterSection_LeftRight"
            Me.ExpandableSplitterSection_LeftRight.Size = New System.Drawing.Size(6, 270)
            Me.ExpandableSplitterSection_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterSection_LeftRight.TabIndex = 14
            Me.ExpandableSplitterSection_LeftRight.TabStop = False
            '
            'PanelBanks_LeftSection
            '
            Me.PanelBanks_LeftSection.Controls.Add(Me.DataGridViewLeftSection_Banks)
            Me.PanelBanks_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelBanks_LeftSection.Location = New System.Drawing.Point(2, 2)
            Me.PanelBanks_LeftSection.Name = "PanelBanks_LeftSection"
            Me.PanelBanks_LeftSection.Size = New System.Drawing.Size(200, 270)
            Me.PanelBanks_LeftSection.TabIndex = 0
            '
            'DataGridViewLeftSection_Banks
            '
            Me.DataGridViewLeftSection_Banks.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_Banks.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_Banks.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_Banks.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_Banks.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_Banks.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.[Default]
            Me.DataGridViewLeftSection_Banks.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_Banks.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_Banks.ItemDescription = "Available Bank(s)"
            Me.DataGridViewLeftSection_Banks.Location = New System.Drawing.Point(5, 10)
            Me.DataGridViewLeftSection_Banks.MultiSelect = True
            Me.DataGridViewLeftSection_Banks.Name = "DataGridViewLeftSection_Banks"
            Me.DataGridViewLeftSection_Banks.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_Banks.RunStandardValidation = True
            Me.DataGridViewLeftSection_Banks.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_Banks.Size = New System.Drawing.Size(189, 250)
            Me.DataGridViewLeftSection_Banks.TabIndex = 0
            Me.DataGridViewLeftSection_Banks.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_Banks.ViewCaptionHeight = -1
            '
            'IRS1099ProcessingSearchDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(567, 428)
            Me.Controls.Add(Me.PanelForm_Banks)
            Me.Controls.Add(Me.GroupBoxForm_CheckDates)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "IRS1099ProcessingSearchDialog"
            Me.Text = "1099 Selection Criteria"
            CType(Me.GroupBoxForm_CheckDates, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxForm_CheckDates.ResumeLayout(False)
            CType(Me.DateTimePickerCheckDates_Ending, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerCheckDates_Starting, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PanelForm_Banks, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Banks.ResumeLayout(False)
            CType(Me.PanelBanks_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelBanks_RightSection.ResumeLayout(False)
            CType(Me.PanelBanks_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelBanks_LeftSection.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelCheckDate_Starting As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCheckDate_Ending As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxForm_CheckDates As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents DateTimePickerCheckDates_Starting As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerCheckDates_Ending As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents PanelForm_Banks As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelBanks_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ButtonRightSection_RemoveBank As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonRightSection_AddBank As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewRightSection_Banks As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ExpandableSplitterSection_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelBanks_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewLeftSection_Banks As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
    End Class

End Namespace