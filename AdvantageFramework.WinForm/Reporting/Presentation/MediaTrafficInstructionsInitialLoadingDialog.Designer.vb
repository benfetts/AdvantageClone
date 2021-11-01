Namespace Reporting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaTrafficInstructionsInitialLoadingDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaTrafficInstructionsInitialLoadingDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.TabItemMediaBroadcastWorksheetCriteria_DemographicsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelMediaBroadcastWorksheetCriteriaDemographicsTab_Demographics = New DevComponents.DotNetBar.TabControlPanel()
            Me.GroupBoxDemographics_Selection = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.GroupBoxForm_TrafficStartingDateRange = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.LabelStartDateRange_FromDate = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.DateTimePickerStartDateRange_FromDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerStartDateRange_ToDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelStartDateRange_ToDate = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.DataGridViewForm_MediaBroadcastWorksheets = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.CheckBoxForm_IncludeInactiveWorksheets = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_IncludeAllMediaTrafficRevisions = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TabControlPanelMediaBroadcastWorksheetCriteriaDemographicsTab_Demographics.SuspendLayout()
            CType(Me.GroupBoxDemographics_Selection, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxForm_TrafficStartingDateRange, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxForm_TrafficStartingDateRange.SuspendLayout()
            CType(Me.DateTimePickerStartDateRange_FromDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerStartDateRange_ToDate, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(789, 556)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 4
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(870, 556)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 5
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
            'GroupBoxForm_TrafficStartingDateRange
            '
            Me.GroupBoxForm_TrafficStartingDateRange.Controls.Add(Me.LabelStartDateRange_FromDate)
            Me.GroupBoxForm_TrafficStartingDateRange.Controls.Add(Me.DateTimePickerStartDateRange_FromDate)
            Me.GroupBoxForm_TrafficStartingDateRange.Controls.Add(Me.DateTimePickerStartDateRange_ToDate)
            Me.GroupBoxForm_TrafficStartingDateRange.Controls.Add(Me.LabelStartDateRange_ToDate)
            Me.GroupBoxForm_TrafficStartingDateRange.Location = New System.Drawing.Point(12, 12)
            Me.GroupBoxForm_TrafficStartingDateRange.Name = "GroupBoxForm_TrafficStartingDateRange"
            Me.GroupBoxForm_TrafficStartingDateRange.Size = New System.Drawing.Size(366, 46)
            Me.GroupBoxForm_TrafficStartingDateRange.TabIndex = 0
            Me.GroupBoxForm_TrafficStartingDateRange.Text = "Traffic Starting Date Range"
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
            Me.DateTimePickerStartDateRange_FromDate.DisplayName = "From Date"
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
            Me.DateTimePickerStartDateRange_FromDate.Value = New Date(2014, 8, 6, 0, 0, 0, 0)
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
            Me.DateTimePickerStartDateRange_ToDate.DisplayName = "To Date"
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
            Me.DateTimePickerStartDateRange_ToDate.Value = New Date(2014, 8, 6, 0, 0, 0, 0)
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
            'DataGridViewForm_MediaBroadcastWorksheets
            '
            Me.DataGridViewForm_MediaBroadcastWorksheets.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_MediaBroadcastWorksheets.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_MediaBroadcastWorksheets.AutoUpdateViewCaption = True
            Me.DataGridViewForm_MediaBroadcastWorksheets.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_MediaBroadcastWorksheets.ItemDescription = "Media Broadcast Worksheet(s)"
            Me.DataGridViewForm_MediaBroadcastWorksheets.Location = New System.Drawing.Point(12, 64)
            Me.DataGridViewForm_MediaBroadcastWorksheets.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewForm_MediaBroadcastWorksheets.ModifyGridRowHeight = False
            Me.DataGridViewForm_MediaBroadcastWorksheets.MultiSelect = True
            Me.DataGridViewForm_MediaBroadcastWorksheets.Name = "DataGridViewForm_MediaBroadcastWorksheets"
            Me.DataGridViewForm_MediaBroadcastWorksheets.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_MediaBroadcastWorksheets.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewForm_MediaBroadcastWorksheets.ShowRowSelectionIfHidden = True
            Me.DataGridViewForm_MediaBroadcastWorksheets.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_MediaBroadcastWorksheets.Size = New System.Drawing.Size(933, 486)
            Me.DataGridViewForm_MediaBroadcastWorksheets.TabIndex = 3
            Me.DataGridViewForm_MediaBroadcastWorksheets.UseEmbeddedNavigator = False
            Me.DataGridViewForm_MediaBroadcastWorksheets.ViewCaptionHeight = -1
            '
            'CheckBoxForm_IncludeInactiveWorksheets
            '
            Me.CheckBoxForm_IncludeInactiveWorksheets.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxForm_IncludeInactiveWorksheets.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_IncludeInactiveWorksheets.CheckValue = 0
            Me.CheckBoxForm_IncludeInactiveWorksheets.CheckValueChecked = 1
            Me.CheckBoxForm_IncludeInactiveWorksheets.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_IncludeInactiveWorksheets.CheckValueUnchecked = 0
            Me.CheckBoxForm_IncludeInactiveWorksheets.ChildControls = CType(resources.GetObject("CheckBoxForm_IncludeInactiveWorksheets.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_IncludeInactiveWorksheets.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_IncludeInactiveWorksheets.Location = New System.Drawing.Point(384, 12)
            Me.CheckBoxForm_IncludeInactiveWorksheets.Name = "CheckBoxForm_IncludeInactiveWorksheets"
            Me.CheckBoxForm_IncludeInactiveWorksheets.OldestSibling = Nothing
            Me.CheckBoxForm_IncludeInactiveWorksheets.SecurityEnabled = True
            Me.CheckBoxForm_IncludeInactiveWorksheets.SiblingControls = CType(resources.GetObject("CheckBoxForm_IncludeInactiveWorksheets.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_IncludeInactiveWorksheets.Size = New System.Drawing.Size(561, 20)
            Me.CheckBoxForm_IncludeInactiveWorksheets.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_IncludeInactiveWorksheets.TabIndex = 1
            Me.CheckBoxForm_IncludeInactiveWorksheets.TabOnEnter = True
            Me.CheckBoxForm_IncludeInactiveWorksheets.Text = "Include Inactive Media Broadcast Worksheets"
            '
            'CheckBoxForm_IncludeAllMediaTrafficRevisions
            '
            Me.CheckBoxForm_IncludeAllMediaTrafficRevisions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxForm_IncludeAllMediaTrafficRevisions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_IncludeAllMediaTrafficRevisions.CheckValue = 0
            Me.CheckBoxForm_IncludeAllMediaTrafficRevisions.CheckValueChecked = 1
            Me.CheckBoxForm_IncludeAllMediaTrafficRevisions.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_IncludeAllMediaTrafficRevisions.CheckValueUnchecked = 0
            Me.CheckBoxForm_IncludeAllMediaTrafficRevisions.ChildControls = CType(resources.GetObject("CheckBoxForm_IncludeAllMediaTrafficRevisions.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_IncludeAllMediaTrafficRevisions.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_IncludeAllMediaTrafficRevisions.Location = New System.Drawing.Point(384, 38)
            Me.CheckBoxForm_IncludeAllMediaTrafficRevisions.Name = "CheckBoxForm_IncludeAllMediaTrafficRevisions"
            Me.CheckBoxForm_IncludeAllMediaTrafficRevisions.OldestSibling = Nothing
            Me.CheckBoxForm_IncludeAllMediaTrafficRevisions.SecurityEnabled = True
            Me.CheckBoxForm_IncludeAllMediaTrafficRevisions.SiblingControls = CType(resources.GetObject("CheckBoxForm_IncludeAllMediaTrafficRevisions.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_IncludeAllMediaTrafficRevisions.Size = New System.Drawing.Size(561, 20)
            Me.CheckBoxForm_IncludeAllMediaTrafficRevisions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_IncludeAllMediaTrafficRevisions.TabIndex = 2
            Me.CheckBoxForm_IncludeAllMediaTrafficRevisions.TabOnEnter = True
            Me.CheckBoxForm_IncludeAllMediaTrafficRevisions.Text = "Include All Media Traffic Revisions"
            '
            'MediaTrafficInstructionsInitialLoadingDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(957, 588)
            Me.Controls.Add(Me.CheckBoxForm_IncludeAllMediaTrafficRevisions)
            Me.Controls.Add(Me.CheckBoxForm_IncludeInactiveWorksheets)
            Me.Controls.Add(Me.DataGridViewForm_MediaBroadcastWorksheets)
            Me.Controls.Add(Me.GroupBoxForm_TrafficStartingDateRange)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaTrafficInstructionsInitialLoadingDialog"
            Me.Text = "Media Traffic Instructions Criteria"
            Me.TabControlPanelMediaBroadcastWorksheetCriteriaDemographicsTab_Demographics.ResumeLayout(False)
            CType(Me.GroupBoxDemographics_Selection, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxForm_TrafficStartingDateRange, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxForm_TrafficStartingDateRange.ResumeLayout(False)
            CType(Me.DateTimePickerStartDateRange_FromDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerStartDateRange_ToDate, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents TabItemMediaBroadcastWorksheetCriteria_DemographicsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelMediaBroadcastWorksheetCriteriaDemographicsTab_Demographics As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents GroupBoxDemographics_Selection As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents GroupBoxForm_TrafficStartingDateRange As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents LabelStartDateRange_FromDate As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents DateTimePickerStartDateRange_FromDate As WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerStartDateRange_ToDate As WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents LabelStartDateRange_ToDate As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents DataGridViewForm_MediaBroadcastWorksheets As WinForm.MVC.Presentation.Controls.DataGridView
        Private WithEvents CheckBoxForm_IncludeInactiveWorksheets As WinForm.Presentation.Controls.CheckBox
        Private WithEvents CheckBoxForm_IncludeAllMediaTrafficRevisions As WinForm.Presentation.Controls.CheckBox
    End Class

End Namespace