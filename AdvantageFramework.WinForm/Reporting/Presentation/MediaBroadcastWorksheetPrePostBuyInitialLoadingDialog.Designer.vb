Namespace Reporting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaBroadcastWorksheetPrePostBuyInitialLoadingDialog
        Inherits AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaBroadcastWorksheetPrePostBuyInitialLoadingDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.TabItemMediaBroadcastWorksheetCriteria_DemographicsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelMediaBroadcastWorksheetCriteriaDemographicsTab_Demographics = New DevComponents.DotNetBar.TabControlPanel()
            Me.GroupBoxDemographics_Selection = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.GroupBoxForm_StartDateRange = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.LabelStartDateRange_FromDate = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.DateTimePickerStartDateRange_FromDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerStartDateRange_ToDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelStartDateRange_ToDate = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.SearchableComboBoxForm_Client = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox()
            Me.GridView2 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.GridView()
            Me.LabelForm_Client = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.DataGridViewForm_Markets = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.LabelForm_Source = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.ComboBoxForm_Source = New AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox()
            Me.DataGridViewForm_Vendors = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.TabControlPanelMediaBroadcastWorksheetCriteriaDemographicsTab_Demographics.SuspendLayout()
            CType(Me.GroupBoxDemographics_Selection, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxForm_StartDateRange, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxForm_StartDateRange.SuspendLayout()
            CType(Me.DateTimePickerStartDateRange_FromDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerStartDateRange_ToDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxForm_Client.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(789, 718)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 6
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(870, 718)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 7
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'TabItemMediaBroadcastWorksheetCriteria_DemographicsTab
            '
            Me.TabItemMediaBroadcastWorksheetCriteria_DemographicsTab.AttachedControl = Me.TabControlPanelMediaBroadcastWorksheetCriteriaDemographicsTab_Demographics
            Me.TabItemMediaBroadcastWorksheetCriteria_DemographicsTab.Name = "TabItemMediaBroadcastWorksheetCriteria_DemographicsTab"
            Me.TabItemMediaBroadcastWorksheetCriteria_DemographicsTab.Text = "Demographics"
            Me.TabItemMediaBroadcastWorksheetCriteria_DemographicsTab.Visible = False
            '
            'TabControlPanelMediaBroadcastWorksheetCriteriaDemographicsTab_Demographics
            '
            Me.TabControlPanelMediaBroadcastWorksheetCriteriaDemographicsTab_Demographics.Controls.Add(Me.GroupBoxDemographics_Selection)
            Me.TabControlPanelMediaBroadcastWorksheetCriteriaDemographicsTab_Demographics.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelMediaBroadcastWorksheetCriteriaDemographicsTab_Demographics.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelMediaBroadcastWorksheetCriteriaDemographicsTab_Demographics.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelMediaBroadcastWorksheetCriteriaDemographicsTab_Demographics.Name = "TabControlPanelMediaBroadcastWorksheetCriteriaDemographicsTab_Demographics"
            Me.TabControlPanelMediaBroadcastWorksheetCriteriaDemographicsTab_Demographics.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelMediaBroadcastWorksheetCriteriaDemographicsTab_Demographics.Size = New System.Drawing.Size(960, 511)
            Me.TabControlPanelMediaBroadcastWorksheetCriteriaDemographicsTab_Demographics.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelMediaBroadcastWorksheetCriteriaDemographicsTab_Demographics.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelMediaBroadcastWorksheetCriteriaDemographicsTab_Demographics.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelMediaBroadcastWorksheetCriteriaDemographicsTab_Demographics.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelMediaBroadcastWorksheetCriteriaDemographicsTab_Demographics.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelMediaBroadcastWorksheetCriteriaDemographicsTab_Demographics.Style.GradientAngle = 90
            Me.TabControlPanelMediaBroadcastWorksheetCriteriaDemographicsTab_Demographics.TabIndex = 30
            Me.TabControlPanelMediaBroadcastWorksheetCriteriaDemographicsTab_Demographics.TabItem = Me.TabItemMediaBroadcastWorksheetCriteria_DemographicsTab
            '
            'GroupBoxDemographics_Selection
            '
            Me.GroupBoxDemographics_Selection.Location = New System.Drawing.Point(4, 4)
            Me.GroupBoxDemographics_Selection.Name = "GroupBoxDemographics_Selection"
            Me.GroupBoxDemographics_Selection.Size = New System.Drawing.Size(662, 298)
            Me.GroupBoxDemographics_Selection.TabIndex = 15
            '
            'GroupBoxForm_StartDateRange
            '
            Me.GroupBoxForm_StartDateRange.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxForm_StartDateRange.Controls.Add(Me.LabelStartDateRange_FromDate)
            Me.GroupBoxForm_StartDateRange.Controls.Add(Me.DateTimePickerStartDateRange_FromDate)
            Me.GroupBoxForm_StartDateRange.Controls.Add(Me.DateTimePickerStartDateRange_ToDate)
            Me.GroupBoxForm_StartDateRange.Controls.Add(Me.LabelStartDateRange_ToDate)
            Me.GroupBoxForm_StartDateRange.Location = New System.Drawing.Point(320, 12)
            Me.GroupBoxForm_StartDateRange.Name = "GroupBoxForm_StartDateRange"
            Me.GroupBoxForm_StartDateRange.Size = New System.Drawing.Size(625, 46)
            Me.GroupBoxForm_StartDateRange.TabIndex = 4
            Me.GroupBoxForm_StartDateRange.Text = "Date Range"
            '
            'LabelStartDateRange_FromDate
            '
            Me.LabelStartDateRange_FromDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelStartDateRange_FromDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelStartDateRange_FromDate.Location = New System.Drawing.Point(5, 20)
            Me.LabelStartDateRange_FromDate.Name = "LabelStartDateRange_FromDate"
            Me.LabelStartDateRange_FromDate.Size = New System.Drawing.Size(70, 21)
            Me.LabelStartDateRange_FromDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelStartDateRange_FromDate.TabIndex = 0
            Me.LabelStartDateRange_FromDate.Text = "From Date:"
            '
            'DateTimePickerStartDateRange_FromDate
            '
            Me.DateTimePickerStartDateRange_FromDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerStartDateRange_FromDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerStartDateRange_FromDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerStartDateRange_FromDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerStartDateRange_FromDate.ButtonDropDown.Visible = True
            Me.DateTimePickerStartDateRange_FromDate.ButtonFreeText.Checked = True
            Me.DateTimePickerStartDateRange_FromDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePickerStartDateRange_FromDate.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePickerStartDateRange_FromDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerStartDateRange_FromDate.DisplayName = "Aging Date"
            Me.DateTimePickerStartDateRange_FromDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerStartDateRange_FromDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerStartDateRange_FromDate.FocusHighlightEnabled = True
            Me.DateTimePickerStartDateRange_FromDate.FreeTextEntryMode = True
            Me.DateTimePickerStartDateRange_FromDate.IsPopupCalendarOpen = False
            Me.DateTimePickerStartDateRange_FromDate.Location = New System.Drawing.Point(81, 20)
            Me.DateTimePickerStartDateRange_FromDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerStartDateRange_FromDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerStartDateRange_FromDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerStartDateRange_FromDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerStartDateRange_FromDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerStartDateRange_FromDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerStartDateRange_FromDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerStartDateRange_FromDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerStartDateRange_FromDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerStartDateRange_FromDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerStartDateRange_FromDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerStartDateRange_FromDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerStartDateRange_FromDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerStartDateRange_FromDate.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerStartDateRange_FromDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerStartDateRange_FromDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerStartDateRange_FromDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerStartDateRange_FromDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerStartDateRange_FromDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerStartDateRange_FromDate.Name = "DateTimePickerStartDateRange_FromDate"
            Me.DateTimePickerStartDateRange_FromDate.ReadOnly = False
            Me.DateTimePickerStartDateRange_FromDate.Size = New System.Drawing.Size(95, 21)
            Me.DateTimePickerStartDateRange_FromDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerStartDateRange_FromDate.TabIndex = 1
            Me.DateTimePickerStartDateRange_FromDate.TabOnEnter = True
            '
            'DateTimePickerStartDateRange_ToDate
            '
            Me.DateTimePickerStartDateRange_ToDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerStartDateRange_ToDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerStartDateRange_ToDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerStartDateRange_ToDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerStartDateRange_ToDate.ButtonDropDown.Visible = True
            Me.DateTimePickerStartDateRange_ToDate.ButtonFreeText.Checked = True
            Me.DateTimePickerStartDateRange_ToDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePickerStartDateRange_ToDate.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePickerStartDateRange_ToDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerStartDateRange_ToDate.DisplayName = "Aging Date"
            Me.DateTimePickerStartDateRange_ToDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerStartDateRange_ToDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerStartDateRange_ToDate.FocusHighlightEnabled = True
            Me.DateTimePickerStartDateRange_ToDate.FreeTextEntryMode = True
            Me.DateTimePickerStartDateRange_ToDate.IsPopupCalendarOpen = False
            Me.DateTimePickerStartDateRange_ToDate.Location = New System.Drawing.Point(258, 20)
            Me.DateTimePickerStartDateRange_ToDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerStartDateRange_ToDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerStartDateRange_ToDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerStartDateRange_ToDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerStartDateRange_ToDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerStartDateRange_ToDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerStartDateRange_ToDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerStartDateRange_ToDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerStartDateRange_ToDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerStartDateRange_ToDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerStartDateRange_ToDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerStartDateRange_ToDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerStartDateRange_ToDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerStartDateRange_ToDate.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerStartDateRange_ToDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerStartDateRange_ToDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerStartDateRange_ToDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerStartDateRange_ToDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerStartDateRange_ToDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerStartDateRange_ToDate.Name = "DateTimePickerStartDateRange_ToDate"
            Me.DateTimePickerStartDateRange_ToDate.ReadOnly = False
            Me.DateTimePickerStartDateRange_ToDate.Size = New System.Drawing.Size(95, 21)
            Me.DateTimePickerStartDateRange_ToDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerStartDateRange_ToDate.TabIndex = 3
            Me.DateTimePickerStartDateRange_ToDate.TabOnEnter = True
            '
            'LabelStartDateRange_ToDate
            '
            Me.LabelStartDateRange_ToDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelStartDateRange_ToDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelStartDateRange_ToDate.Location = New System.Drawing.Point(182, 20)
            Me.LabelStartDateRange_ToDate.Name = "LabelStartDateRange_ToDate"
            Me.LabelStartDateRange_ToDate.Size = New System.Drawing.Size(70, 21)
            Me.LabelStartDateRange_ToDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelStartDateRange_ToDate.TabIndex = 2
            Me.LabelStartDateRange_ToDate.Text = "To Date:"
            '
            'SearchableComboBoxForm_Client
            '
            Me.SearchableComboBoxForm_Client.ActiveFilterString = ""
            Me.SearchableComboBoxForm_Client.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxForm_Client.AutoFillMode = False
            Me.SearchableComboBoxForm_Client.BookmarkingEnabled = False
            Me.SearchableComboBoxForm_Client.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.Type.Client
            Me.SearchableComboBoxForm_Client.DataSource = Nothing
            Me.SearchableComboBoxForm_Client.DisableMouseWheel = True
            Me.SearchableComboBoxForm_Client.DisplayName = ""
            Me.SearchableComboBoxForm_Client.EditValue = ""
            Me.SearchableComboBoxForm_Client.EnterMoveNextControl = True
            Me.SearchableComboBoxForm_Client.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxForm_Client.Location = New System.Drawing.Point(88, 38)
            Me.SearchableComboBoxForm_Client.Name = "SearchableComboBoxForm_Client"
            Me.SearchableComboBoxForm_Client.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxForm_Client.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxForm_Client.Properties.NullText = "Select Client"
            Me.SearchableComboBoxForm_Client.Properties.PopupView = Me.GridView2
            Me.SearchableComboBoxForm_Client.Properties.ShowClearButton = False
            Me.SearchableComboBoxForm_Client.Properties.ValueMember = "Code"
            Me.SearchableComboBoxForm_Client.SecurityEnabled = True
            Me.SearchableComboBoxForm_Client.SelectedValue = ""
            Me.SearchableComboBoxForm_Client.Size = New System.Drawing.Size(226, 20)
            Me.SearchableComboBoxForm_Client.TabIndex = 3
            '
            'GridView2
            '
            Me.GridView2.AFActiveFilterString = ""
            Me.GridView2.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.EnableDisabledRows = False
            Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView2.ModifyColumnSettingsOnEachDataSource = True
            Me.GridView2.ModifyGridRowHeight = False
            Me.GridView2.Name = "GridView2"
            Me.GridView2.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView2.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView2.OptionsBehavior.Editable = False
            Me.GridView2.OptionsCustomization.AllowQuickHideColumns = False
            Me.GridView2.OptionsNavigation.AutoFocusNewRow = True
            Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView2.OptionsSelection.MultiSelect = True
            Me.GridView2.OptionsView.ColumnAutoWidth = False
            Me.GridView2.OptionsView.ShowGroupPanel = False
            Me.GridView2.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.GridView2.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView2.SkipAddingControlsOnModifyColumn = False
            Me.GridView2.SkipSettingFontOnModifyColumn = False
            '
            'LabelForm_Client
            '
            Me.LabelForm_Client.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Client.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Client.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_Client.Name = "LabelForm_Client"
            Me.LabelForm_Client.Size = New System.Drawing.Size(70, 20)
            Me.LabelForm_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Client.TabIndex = 2
            Me.LabelForm_Client.Text = "Client:"
            '
            'DataGridViewForm_Markets
            '
            Me.DataGridViewForm_Markets.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_Markets.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_Markets.AutoUpdateViewCaption = True
            Me.DataGridViewForm_Markets.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_Markets.ItemDescription = "Market(s)"
            Me.DataGridViewForm_Markets.Location = New System.Drawing.Point(12, 64)
            Me.DataGridViewForm_Markets.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewForm_Markets.ModifyGridRowHeight = False
            Me.DataGridViewForm_Markets.MultiSelect = True
            Me.DataGridViewForm_Markets.Name = "DataGridViewForm_Markets"
            Me.DataGridViewForm_Markets.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_Markets.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewForm_Markets.ShowRowSelectionIfHidden = True
            Me.DataGridViewForm_Markets.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_Markets.Size = New System.Drawing.Size(933, 321)
            Me.DataGridViewForm_Markets.TabIndex = 5
            Me.DataGridViewForm_Markets.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Markets.ViewCaptionHeight = -1
            '
            'LabelForm_Source
            '
            Me.LabelForm_Source.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Source.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Source.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_Source.Name = "LabelForm_Source"
            Me.LabelForm_Source.Size = New System.Drawing.Size(70, 20)
            Me.LabelForm_Source.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Source.TabIndex = 0
            Me.LabelForm_Source.Text = "Source:"
            '
            'ComboBoxForm_Source
            '
            Me.ComboBoxForm_Source.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Source.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
            Me.ComboBoxForm_Source.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Source.AutoFindItemInDataSource = True
            Me.ComboBoxForm_Source.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Source.BookmarkingEnabled = False
            Me.ComboBoxForm_Source.DisableMouseWheel = True
            Me.ComboBoxForm_Source.DisplayMember = "Display"
            Me.ComboBoxForm_Source.DisplayName = "Source"
            Me.ComboBoxForm_Source.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Source.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_Source.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_Source.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Source.FocusHighlightEnabled = True
            Me.ComboBoxForm_Source.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxForm_Source.FormattingEnabled = True
            Me.ComboBoxForm_Source.ItemHeight = 15
            Me.ComboBoxForm_Source.Location = New System.Drawing.Point(88, 12)
            Me.ComboBoxForm_Source.Name = "ComboBoxForm_Source"
            Me.ComboBoxForm_Source.ReadOnly = False
            Me.ComboBoxForm_Source.SecurityEnabled = True
            Me.ComboBoxForm_Source.Size = New System.Drawing.Size(226, 21)
            Me.ComboBoxForm_Source.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Source.TabIndex = 1
            Me.ComboBoxForm_Source.TabOnEnter = True
            Me.ComboBoxForm_Source.ValueMember = "Value"
            Me.ComboBoxForm_Source.WatermarkText = "Select Month"
            '
            'DataGridViewForm_Vendors
            '
            Me.DataGridViewForm_Vendors.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_Vendors.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_Vendors.AutoUpdateViewCaption = True
            Me.DataGridViewForm_Vendors.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_Vendors.ItemDescription = "Vendor(s)"
            Me.DataGridViewForm_Vendors.Location = New System.Drawing.Point(12, 391)
            Me.DataGridViewForm_Vendors.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewForm_Vendors.ModifyGridRowHeight = False
            Me.DataGridViewForm_Vendors.MultiSelect = True
            Me.DataGridViewForm_Vendors.Name = "DataGridViewForm_Vendors"
            Me.DataGridViewForm_Vendors.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_Vendors.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewForm_Vendors.ShowRowSelectionIfHidden = True
            Me.DataGridViewForm_Vendors.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_Vendors.Size = New System.Drawing.Size(933, 321)
            Me.DataGridViewForm_Vendors.TabIndex = 8
            Me.DataGridViewForm_Vendors.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Vendors.ViewCaptionHeight = -1
            '
            'MediaBroadcastWorksheetPrePostBuyInitialLoadingDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(957, 750)
            Me.Controls.Add(Me.DataGridViewForm_Vendors)
            Me.Controls.Add(Me.DataGridViewForm_Markets)
            Me.Controls.Add(Me.GroupBoxForm_StartDateRange)
            Me.Controls.Add(Me.SearchableComboBoxForm_Client)
            Me.Controls.Add(Me.LabelForm_Client)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.ComboBoxForm_Source)
            Me.Controls.Add(Me.LabelForm_Source)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaBroadcastWorksheetPrePostBuyInitialLoadingDialog"
            Me.Text = "Broadcast Worksheet Pre Buy Criteria"
            Me.TabControlPanelMediaBroadcastWorksheetCriteriaDemographicsTab_Demographics.ResumeLayout(False)
            CType(Me.GroupBoxDemographics_Selection, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxForm_StartDateRange, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxForm_StartDateRange.ResumeLayout(False)
            CType(Me.DateTimePickerStartDateRange_FromDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerStartDateRange_ToDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxForm_Client.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents TabItemMediaBroadcastWorksheetCriteria_DemographicsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelMediaBroadcastWorksheetCriteriaDemographicsTab_Demographics As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents GroupBoxDemographics_Selection As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents GroupBoxForm_StartDateRange As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents LabelStartDateRange_FromDate As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents DateTimePickerStartDateRange_FromDate As WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerStartDateRange_ToDate As WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents LabelStartDateRange_ToDate As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxForm_Client As WinForm.MVC.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView2 As WinForm.MVC.Presentation.Controls.GridView
        Friend WithEvents LabelForm_Client As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents DataGridViewForm_Markets As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents LabelForm_Source As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_Source As WinForm.MVC.Presentation.Controls.ComboBox
        Friend WithEvents DataGridViewForm_Vendors As WinForm.MVC.Presentation.Controls.DataGridView
    End Class

End Namespace