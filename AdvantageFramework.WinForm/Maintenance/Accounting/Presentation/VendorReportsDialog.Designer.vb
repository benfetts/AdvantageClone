Namespace Maintenance.Accounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class VendorReportsDialog
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
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VendorReportsDialog))
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_ReportFormats = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_PrintOptions = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DataGridViewForm_Vendors = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ListBoxForm_Reports = New AdvantageFramework.WinForm.Presentation.Controls.ListBox()
            Me.RadioButtonControlSortBy_CategoryVendorCode = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlSortBy_VendorCode = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.LabelSortBy_SortBy = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.PanelForm_PrintOptions = New System.Windows.Forms.Panel()
            Me.RadioButtonControlSortBy_OfficeVendorCode = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.LabelForm_SelectVendors = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxVendorHistory_User = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelVendorHistory_User = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DateTimePickerVendorHistory_DateTo = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerVendorHistory_DateFrom = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelVendorHistory_DateTo = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelVendorHistory_DateFrom = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.PanelForm_VendorHistoryPrintOptions = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.CheckBoxVendorHistory_NewRecordsOnly = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_Export = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.DataGridViewForm_Export = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            CType(Me.ListBoxForm_Reports, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_PrintOptions.SuspendLayout()
            CType(Me.DateTimePickerVendorHistory_DateTo, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerVendorHistory_DateFrom, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PanelForm_VendorHistoryPrintOptions, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_VendorHistoryPrintOptions.SuspendLayout()
            Me.SuspendLayout()
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(727, 407)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 11
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(646, 407)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 10
            Me.ButtonForm_OK.Text = "OK"
            '
            'LabelForm_ReportFormats
            '
            Me.LabelForm_ReportFormats.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_ReportFormats.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_ReportFormats.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_ReportFormats.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelForm_ReportFormats.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_ReportFormats.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_ReportFormats.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_ReportFormats.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_ReportFormats.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelForm_ReportFormats.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_ReportFormats.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_ReportFormats.Name = "LabelForm_ReportFormats"
            Me.LabelForm_ReportFormats.Size = New System.Drawing.Size(237, 20)
            Me.LabelForm_ReportFormats.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ReportFormats.TabIndex = 0
            Me.LabelForm_ReportFormats.Text = "Report Formats"
            '
            'LabelForm_PrintOptions
            '
            Me.LabelForm_PrintOptions.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_PrintOptions.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_PrintOptions.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_PrintOptions.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelForm_PrintOptions.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_PrintOptions.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_PrintOptions.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_PrintOptions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_PrintOptions.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelForm_PrintOptions.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_PrintOptions.Location = New System.Drawing.Point(12, 276)
            Me.LabelForm_PrintOptions.Name = "LabelForm_PrintOptions"
            Me.LabelForm_PrintOptions.Size = New System.Drawing.Size(237, 20)
            Me.LabelForm_PrintOptions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_PrintOptions.TabIndex = 6
            Me.LabelForm_PrintOptions.Text = "Print Options"
            '
            'DataGridViewForm_Vendors
            '
            Me.DataGridViewForm_Vendors.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_Vendors.AllowDragAndDrop = False
            Me.DataGridViewForm_Vendors.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_Vendors.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_Vendors.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_Vendors.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_Vendors.AutoFilterLookupColumns = False
            Me.DataGridViewForm_Vendors.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_Vendors.AutoUpdateViewCaption = True
            Me.DataGridViewForm_Vendors.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.[Default]
            Me.DataGridViewForm_Vendors.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_Vendors.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_Vendors.ItemDescription = ""
            Me.DataGridViewForm_Vendors.Location = New System.Drawing.Point(255, 38)
            Me.DataGridViewForm_Vendors.MultiSelect = True
            Me.DataGridViewForm_Vendors.Name = "DataGridViewForm_Vendors"
            Me.DataGridViewForm_Vendors.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_Vendors.RunStandardValidation = True
            Me.DataGridViewForm_Vendors.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_Vendors.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_Vendors.Size = New System.Drawing.Size(547, 363)
            Me.DataGridViewForm_Vendors.TabIndex = 0
            Me.DataGridViewForm_Vendors.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Vendors.ViewCaptionHeight = -1
            '
            'ListBoxForm_Reports
            '
            Me.ListBoxForm_Reports.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ListBox.Type.Report
            Me.ListBoxForm_Reports.Cursor = System.Windows.Forms.Cursors.Default
            Me.ListBoxForm_Reports.DisplayMember = "Description"
            Me.ListBoxForm_Reports.ExtraListBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ListBox.ExtraListBoxItems.[Nothing]
            Me.ListBoxForm_Reports.ExtraListBoxItemDisplayText = Nothing
            Me.ListBoxForm_Reports.ExtraListBoxItemValueObject = Nothing
            Me.ListBoxForm_Reports.Location = New System.Drawing.Point(12, 38)
            Me.ListBoxForm_Reports.Name = "ListBoxForm_Reports"
            Me.ListBoxForm_Reports.Size = New System.Drawing.Size(237, 232)
            Me.ListBoxForm_Reports.TabIndex = 1
            Me.ListBoxForm_Reports.ValueMember = "Code"
            '
            'RadioButtonControlSortBy_CategoryVendorCode
            '
            Me.RadioButtonControlSortBy_CategoryVendorCode.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlSortBy_CategoryVendorCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlSortBy_CategoryVendorCode.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlSortBy_CategoryVendorCode.Location = New System.Drawing.Point(51, 26)
            Me.RadioButtonControlSortBy_CategoryVendorCode.Name = "RadioButtonControlSortBy_CategoryVendorCode"
            Me.RadioButtonControlSortBy_CategoryVendorCode.SecurityEnabled = True
            Me.RadioButtonControlSortBy_CategoryVendorCode.Size = New System.Drawing.Size(184, 20)
            Me.RadioButtonControlSortBy_CategoryVendorCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlSortBy_CategoryVendorCode.TabIndex = 2
            Me.RadioButtonControlSortBy_CategoryVendorCode.TabOnEnter = True
            Me.RadioButtonControlSortBy_CategoryVendorCode.TabStop = False
            Me.RadioButtonControlSortBy_CategoryVendorCode.Text = "Category / Vendor Code"
            '
            'RadioButtonControlSortBy_VendorCode
            '
            Me.RadioButtonControlSortBy_VendorCode.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlSortBy_VendorCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlSortBy_VendorCode.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlSortBy_VendorCode.Location = New System.Drawing.Point(51, 0)
            Me.RadioButtonControlSortBy_VendorCode.Name = "RadioButtonControlSortBy_VendorCode"
            Me.RadioButtonControlSortBy_VendorCode.SecurityEnabled = True
            Me.RadioButtonControlSortBy_VendorCode.Size = New System.Drawing.Size(184, 20)
            Me.RadioButtonControlSortBy_VendorCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlSortBy_VendorCode.TabIndex = 1
            Me.RadioButtonControlSortBy_VendorCode.TabOnEnter = True
            Me.RadioButtonControlSortBy_VendorCode.TabStop = False
            Me.RadioButtonControlSortBy_VendorCode.Text = "Vendor Code"
            '
            'LabelSortBy_SortBy
            '
            Me.LabelSortBy_SortBy.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSortBy_SortBy.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSortBy_SortBy.Location = New System.Drawing.Point(-1, 0)
            Me.LabelSortBy_SortBy.Name = "LabelSortBy_SortBy"
            Me.LabelSortBy_SortBy.Size = New System.Drawing.Size(46, 20)
            Me.LabelSortBy_SortBy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSortBy_SortBy.TabIndex = 0
            Me.LabelSortBy_SortBy.Text = "Sort By:"
            '
            'PanelForm_PrintOptions
            '
            Me.PanelForm_PrintOptions.BackColor = System.Drawing.Color.White
            Me.PanelForm_PrintOptions.Controls.Add(Me.RadioButtonControlSortBy_OfficeVendorCode)
            Me.PanelForm_PrintOptions.Controls.Add(Me.LabelSortBy_SortBy)
            Me.PanelForm_PrintOptions.Controls.Add(Me.RadioButtonControlSortBy_VendorCode)
            Me.PanelForm_PrintOptions.Controls.Add(Me.RadioButtonControlSortBy_CategoryVendorCode)
            Me.PanelForm_PrintOptions.Location = New System.Drawing.Point(12, 302)
            Me.PanelForm_PrintOptions.Name = "PanelForm_PrintOptions"
            Me.PanelForm_PrintOptions.Size = New System.Drawing.Size(237, 99)
            Me.PanelForm_PrintOptions.TabIndex = 8
            '
            'RadioButtonControlSortBy_OfficeVendorCode
            '
            Me.RadioButtonControlSortBy_OfficeVendorCode.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlSortBy_OfficeVendorCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlSortBy_OfficeVendorCode.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlSortBy_OfficeVendorCode.Location = New System.Drawing.Point(51, 52)
            Me.RadioButtonControlSortBy_OfficeVendorCode.Name = "RadioButtonControlSortBy_OfficeVendorCode"
            Me.RadioButtonControlSortBy_OfficeVendorCode.SecurityEnabled = True
            Me.RadioButtonControlSortBy_OfficeVendorCode.Size = New System.Drawing.Size(184, 20)
            Me.RadioButtonControlSortBy_OfficeVendorCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlSortBy_OfficeVendorCode.TabIndex = 3
            Me.RadioButtonControlSortBy_OfficeVendorCode.TabOnEnter = True
            Me.RadioButtonControlSortBy_OfficeVendorCode.TabStop = False
            Me.RadioButtonControlSortBy_OfficeVendorCode.Text = "Office / Vendor Code"
            '
            'LabelForm_SelectVendors
            '
            Me.LabelForm_SelectVendors.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_SelectVendors.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_SelectVendors.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_SelectVendors.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_SelectVendors.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelForm_SelectVendors.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_SelectVendors.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_SelectVendors.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_SelectVendors.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_SelectVendors.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelForm_SelectVendors.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_SelectVendors.Location = New System.Drawing.Point(255, 12)
            Me.LabelForm_SelectVendors.Name = "LabelForm_SelectVendors"
            Me.LabelForm_SelectVendors.Size = New System.Drawing.Size(547, 20)
            Me.LabelForm_SelectVendors.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_SelectVendors.TabIndex = 9
            Me.LabelForm_SelectVendors.Text = "Select Vendor(s)"
            '
            'TextBoxVendorHistory_User
            '
            '
            '
            '
            Me.TextBoxVendorHistory_User.Border.Class = "TextBoxBorder"
            Me.TextBoxVendorHistory_User.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxVendorHistory_User.CheckSpellingOnValidate = False
            Me.TextBoxVendorHistory_User.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxVendorHistory_User.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxVendorHistory_User.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxVendorHistory_User.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxVendorHistory_User.FocusHighlightEnabled = True
            Me.TextBoxVendorHistory_User.Location = New System.Drawing.Point(72, 52)
            Me.TextBoxVendorHistory_User.MaxFileSize = CType(0, Long)
            Me.TextBoxVendorHistory_User.Name = "TextBoxVendorHistory_User"
            Me.TextBoxVendorHistory_User.SecurityEnabled = True
            Me.TextBoxVendorHistory_User.ShowSpellCheckCompleteMessage = True
            Me.TextBoxVendorHistory_User.Size = New System.Drawing.Size(163, 21)
            Me.TextBoxVendorHistory_User.StartingFolderName = Nothing
            Me.TextBoxVendorHistory_User.TabIndex = 7
            Me.TextBoxVendorHistory_User.TabOnEnter = True
            '
            'LabelVendorHistory_User
            '
            Me.LabelVendorHistory_User.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelVendorHistory_User.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelVendorHistory_User.Location = New System.Drawing.Point(0, 52)
            Me.LabelVendorHistory_User.Name = "LabelVendorHistory_User"
            Me.LabelVendorHistory_User.Size = New System.Drawing.Size(66, 20)
            Me.LabelVendorHistory_User.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelVendorHistory_User.TabIndex = 6
            Me.LabelVendorHistory_User.Text = "User:"
            '
            'DateTimePickerVendorHistory_DateTo
            '
            Me.DateTimePickerVendorHistory_DateTo.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerVendorHistory_DateTo.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerVendorHistory_DateTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerVendorHistory_DateTo.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerVendorHistory_DateTo.ButtonDropDown.Visible = True
            Me.DateTimePickerVendorHistory_DateTo.ButtonFreeText.Checked = True
            Me.DateTimePickerVendorHistory_DateTo.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerVendorHistory_DateTo.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerVendorHistory_DateTo.DisplayName = ""
            Me.DateTimePickerVendorHistory_DateTo.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerVendorHistory_DateTo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerVendorHistory_DateTo.FocusHighlightEnabled = True
            Me.DateTimePickerVendorHistory_DateTo.FreeTextEntryMode = True
            Me.DateTimePickerVendorHistory_DateTo.IsPopupCalendarOpen = False
            Me.DateTimePickerVendorHistory_DateTo.Location = New System.Drawing.Point(72, 26)
            Me.DateTimePickerVendorHistory_DateTo.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerVendorHistory_DateTo.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerVendorHistory_DateTo.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerVendorHistory_DateTo.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerVendorHistory_DateTo.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerVendorHistory_DateTo.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerVendorHistory_DateTo.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerVendorHistory_DateTo.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerVendorHistory_DateTo.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerVendorHistory_DateTo.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerVendorHistory_DateTo.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerVendorHistory_DateTo.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerVendorHistory_DateTo.MonthCalendar.DisplayMonth = New Date(2013, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerVendorHistory_DateTo.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerVendorHistory_DateTo.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerVendorHistory_DateTo.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerVendorHistory_DateTo.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerVendorHistory_DateTo.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerVendorHistory_DateTo.Name = "DateTimePickerVendorHistory_DateTo"
            Me.DateTimePickerVendorHistory_DateTo.ReadOnly = False
            Me.DateTimePickerVendorHistory_DateTo.Size = New System.Drawing.Size(163, 21)
            Me.DateTimePickerVendorHistory_DateTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerVendorHistory_DateTo.TabIndex = 5
            Me.DateTimePickerVendorHistory_DateTo.TabOnEnter = True
            Me.DateTimePickerVendorHistory_DateTo.Value = New Date(2016, 8, 30, 13, 20, 32, 868)
            '
            'DateTimePickerVendorHistory_DateFrom
            '
            Me.DateTimePickerVendorHistory_DateFrom.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerVendorHistory_DateFrom.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerVendorHistory_DateFrom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerVendorHistory_DateFrom.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerVendorHistory_DateFrom.ButtonDropDown.Visible = True
            Me.DateTimePickerVendorHistory_DateFrom.ButtonFreeText.Checked = True
            Me.DateTimePickerVendorHistory_DateFrom.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerVendorHistory_DateFrom.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerVendorHistory_DateFrom.DisplayName = ""
            Me.DateTimePickerVendorHistory_DateFrom.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerVendorHistory_DateFrom.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerVendorHistory_DateFrom.FocusHighlightEnabled = True
            Me.DateTimePickerVendorHistory_DateFrom.FreeTextEntryMode = True
            Me.DateTimePickerVendorHistory_DateFrom.IsPopupCalendarOpen = False
            Me.DateTimePickerVendorHistory_DateFrom.Location = New System.Drawing.Point(72, 0)
            Me.DateTimePickerVendorHistory_DateFrom.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerVendorHistory_DateFrom.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerVendorHistory_DateFrom.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerVendorHistory_DateFrom.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerVendorHistory_DateFrom.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerVendorHistory_DateFrom.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerVendorHistory_DateFrom.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerVendorHistory_DateFrom.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerVendorHistory_DateFrom.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerVendorHistory_DateFrom.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerVendorHistory_DateFrom.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerVendorHistory_DateFrom.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerVendorHistory_DateFrom.MonthCalendar.DisplayMonth = New Date(2013, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerVendorHistory_DateFrom.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerVendorHistory_DateFrom.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerVendorHistory_DateFrom.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerVendorHistory_DateFrom.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerVendorHistory_DateFrom.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerVendorHistory_DateFrom.Name = "DateTimePickerVendorHistory_DateFrom"
            Me.DateTimePickerVendorHistory_DateFrom.ReadOnly = False
            Me.DateTimePickerVendorHistory_DateFrom.Size = New System.Drawing.Size(163, 21)
            Me.DateTimePickerVendorHistory_DateFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerVendorHistory_DateFrom.TabIndex = 4
            Me.DateTimePickerVendorHistory_DateFrom.TabOnEnter = True
            Me.DateTimePickerVendorHistory_DateFrom.Value = New Date(2016, 8, 30, 13, 20, 32, 900)
            '
            'LabelVendorHistory_DateTo
            '
            Me.LabelVendorHistory_DateTo.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelVendorHistory_DateTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelVendorHistory_DateTo.Location = New System.Drawing.Point(0, 26)
            Me.LabelVendorHistory_DateTo.Name = "LabelVendorHistory_DateTo"
            Me.LabelVendorHistory_DateTo.Size = New System.Drawing.Size(66, 20)
            Me.LabelVendorHistory_DateTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelVendorHistory_DateTo.TabIndex = 3
            Me.LabelVendorHistory_DateTo.Text = "Date To:"
            '
            'LabelVendorHistory_DateFrom
            '
            Me.LabelVendorHistory_DateFrom.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelVendorHistory_DateFrom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelVendorHistory_DateFrom.Location = New System.Drawing.Point(0, 0)
            Me.LabelVendorHistory_DateFrom.Name = "LabelVendorHistory_DateFrom"
            Me.LabelVendorHistory_DateFrom.Size = New System.Drawing.Size(66, 20)
            Me.LabelVendorHistory_DateFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelVendorHistory_DateFrom.TabIndex = 2
            Me.LabelVendorHistory_DateFrom.Text = "Date From:"
            '
            'PanelForm_VendorHistoryPrintOptions
            '
            Me.PanelForm_VendorHistoryPrintOptions.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelForm_VendorHistoryPrintOptions.Controls.Add(Me.CheckBoxVendorHistory_NewRecordsOnly)
            Me.PanelForm_VendorHistoryPrintOptions.Controls.Add(Me.CheckBoxForm_Export)
            Me.PanelForm_VendorHistoryPrintOptions.Controls.Add(Me.LabelVendorHistory_DateFrom)
            Me.PanelForm_VendorHistoryPrintOptions.Controls.Add(Me.TextBoxVendorHistory_User)
            Me.PanelForm_VendorHistoryPrintOptions.Controls.Add(Me.LabelVendorHistory_DateTo)
            Me.PanelForm_VendorHistoryPrintOptions.Controls.Add(Me.LabelVendorHistory_User)
            Me.PanelForm_VendorHistoryPrintOptions.Controls.Add(Me.DateTimePickerVendorHistory_DateFrom)
            Me.PanelForm_VendorHistoryPrintOptions.Controls.Add(Me.DateTimePickerVendorHistory_DateTo)
            Me.PanelForm_VendorHistoryPrintOptions.Location = New System.Drawing.Point(12, 302)
            Me.PanelForm_VendorHistoryPrintOptions.Name = "PanelForm_VendorHistoryPrintOptions"
            Me.PanelForm_VendorHistoryPrintOptions.Size = New System.Drawing.Size(237, 99)
            Me.PanelForm_VendorHistoryPrintOptions.TabIndex = 12
            '
            'CheckBoxVendorHistory_NewRecordsOnly
            '
            Me.CheckBoxVendorHistory_NewRecordsOnly.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxVendorHistory_NewRecordsOnly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxVendorHistory_NewRecordsOnly.CheckValue = 0
            Me.CheckBoxVendorHistory_NewRecordsOnly.CheckValueChecked = 1
            Me.CheckBoxVendorHistory_NewRecordsOnly.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxVendorHistory_NewRecordsOnly.CheckValueUnchecked = 0
            Me.CheckBoxVendorHistory_NewRecordsOnly.ChildControls = Nothing
            Me.CheckBoxVendorHistory_NewRecordsOnly.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxVendorHistory_NewRecordsOnly.Location = New System.Drawing.Point(0, 76)
            Me.CheckBoxVendorHistory_NewRecordsOnly.Name = "CheckBoxVendorHistory_NewRecordsOnly"
            Me.CheckBoxVendorHistory_NewRecordsOnly.OldestSibling = Nothing
            Me.CheckBoxVendorHistory_NewRecordsOnly.SecurityEnabled = True
            Me.CheckBoxVendorHistory_NewRecordsOnly.SiblingControls = Nothing
            Me.CheckBoxVendorHistory_NewRecordsOnly.Size = New System.Drawing.Size(164, 20)
            Me.CheckBoxVendorHistory_NewRecordsOnly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxVendorHistory_NewRecordsOnly.TabIndex = 8
            Me.CheckBoxVendorHistory_NewRecordsOnly.TabOnEnter = True
            Me.CheckBoxVendorHistory_NewRecordsOnly.Text = "Include New Records Only"
            '
            'CheckBoxForm_Export
            '
            Me.CheckBoxForm_Export.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxForm_Export.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_Export.CheckValue = 0
            Me.CheckBoxForm_Export.CheckValueChecked = 1
            Me.CheckBoxForm_Export.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_Export.CheckValueUnchecked = 0
            Me.CheckBoxForm_Export.ChildControls = Nothing
            Me.CheckBoxForm_Export.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_Export.Location = New System.Drawing.Point(170, 76)
            Me.CheckBoxForm_Export.Name = "CheckBoxForm_Export"
            Me.CheckBoxForm_Export.OldestSibling = Nothing
            Me.CheckBoxForm_Export.SecurityEnabled = True
            Me.CheckBoxForm_Export.SiblingControls = Nothing
            Me.CheckBoxForm_Export.Size = New System.Drawing.Size(64, 20)
            Me.CheckBoxForm_Export.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_Export.TabIndex = 15
            Me.CheckBoxForm_Export.TabOnEnter = True
            Me.CheckBoxForm_Export.Text = "Export"
            '
            'DataGridViewForm_Export
            '
            Me.DataGridViewForm_Export.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_Export.AllowDragAndDrop = False
            Me.DataGridViewForm_Export.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_Export.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_Export.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_Export.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_Export.AutoFilterLookupColumns = False
            Me.DataGridViewForm_Export.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_Export.AutoUpdateViewCaption = True
            Me.DataGridViewForm_Export.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.[Default]
            Me.DataGridViewForm_Export.DataSource = Nothing
            Me.DataGridViewForm_Export.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_Export.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_Export.ItemDescription = ""
            Me.DataGridViewForm_Export.Location = New System.Drawing.Point(295, 119)
            Me.DataGridViewForm_Export.MultiSelect = True
            Me.DataGridViewForm_Export.Name = "DataGridViewForm_Export"
            Me.DataGridViewForm_Export.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_Export.RunStandardValidation = True
            Me.DataGridViewForm_Export.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_Export.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_Export.Size = New System.Drawing.Size(167, 216)
            Me.DataGridViewForm_Export.TabIndex = 14
            Me.DataGridViewForm_Export.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Export.ViewCaptionHeight = -1
            Me.DataGridViewForm_Export.Visible = False
            '
            'VendorReportsDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(814, 439)
            Me.Controls.Add(Me.DataGridViewForm_Vendors)
            Me.Controls.Add(Me.DataGridViewForm_Export)
            Me.Controls.Add(Me.PanelForm_PrintOptions)
            Me.Controls.Add(Me.PanelForm_VendorHistoryPrintOptions)
            Me.Controls.Add(Me.LabelForm_PrintOptions)
            Me.Controls.Add(Me.ListBoxForm_Reports)
            Me.Controls.Add(Me.LabelForm_ReportFormats)
            Me.Controls.Add(Me.LabelForm_SelectVendors)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "VendorReportsDialog"
            Me.Text = "Vendor Reports"
            CType(Me.ListBoxForm_Reports, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_PrintOptions.ResumeLayout(False)
            CType(Me.DateTimePickerVendorHistory_DateTo, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerVendorHistory_DateFrom, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PanelForm_VendorHistoryPrintOptions, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_VendorHistoryPrintOptions.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_ReportFormats As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_PrintOptions As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DataGridViewForm_Vendors As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ListBoxForm_Reports As AdvantageFramework.WinForm.Presentation.Controls.ListBox
        Friend WithEvents RadioButtonControlSortBy_CategoryVendorCode As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlSortBy_VendorCode As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents LabelSortBy_SortBy As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents PanelForm_PrintOptions As System.Windows.Forms.Panel
        Friend WithEvents LabelForm_SelectVendors As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents RadioButtonControlSortBy_OfficeVendorCode As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents TextBoxVendorHistory_User As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelVendorHistory_User As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerVendorHistory_DateTo As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerVendorHistory_DateFrom As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents LabelVendorHistory_DateTo As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelVendorHistory_DateFrom As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents PanelForm_VendorHistoryPrintOptions As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents CheckBoxVendorHistory_NewRecordsOnly As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents DataGridViewForm_Export As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents CheckBoxForm_Export As WinForm.Presentation.Controls.CheckBox
    End Class

End Namespace