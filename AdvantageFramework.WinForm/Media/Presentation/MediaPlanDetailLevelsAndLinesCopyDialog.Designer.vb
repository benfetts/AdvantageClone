Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class MediaPlanDetailLevelsAndLinesCopyDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaPlanDetailLevelsAndLinesCopyDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewForm_MediaPlanDetails = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewForm_DetailsLevelLines = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.CheckBoxForm_IncludeData = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_ShowEsitmatesForAllMediaTypes = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.DateTimePickerForm_EndDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerForm_StartDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelForm_EndDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_StartDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ButtonForm_Filter = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.CheckBoxForm_LevelsOnly = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            CType(Me.DateTimePickerForm_EndDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerForm_StartDate, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(631, 499)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 10
            Me.ButtonForm_OK.Text = "OK"
            '
            'DataGridViewForm_MediaPlanDetails
            '
            Me.DataGridViewForm_MediaPlanDetails.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_MediaPlanDetails.AllowDragAndDrop = False
            Me.DataGridViewForm_MediaPlanDetails.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_MediaPlanDetails.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_MediaPlanDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_MediaPlanDetails.AutoFilterLookupColumns = False
            Me.DataGridViewForm_MediaPlanDetails.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_MediaPlanDetails.AutoUpdateViewCaption = True
            Me.DataGridViewForm_MediaPlanDetails.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewForm_MediaPlanDetails.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_MediaPlanDetails.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_MediaPlanDetails.ItemDescription = ""
            Me.DataGridViewForm_MediaPlanDetails.Location = New System.Drawing.Point(12, 38)
            Me.DataGridViewForm_MediaPlanDetails.MultiSelect = False
            Me.DataGridViewForm_MediaPlanDetails.Name = "DataGridViewForm_MediaPlanDetails"
            Me.DataGridViewForm_MediaPlanDetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_MediaPlanDetails.RunStandardValidation = True
            Me.DataGridViewForm_MediaPlanDetails.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_MediaPlanDetails.Size = New System.Drawing.Size(423, 455)
            Me.DataGridViewForm_MediaPlanDetails.TabIndex = 6
            Me.DataGridViewForm_MediaPlanDetails.UseEmbeddedNavigator = False
            Me.DataGridViewForm_MediaPlanDetails.ViewCaptionHeight = -1
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(712, 499)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 11
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'DataGridViewForm_DetailsLevelLines
            '
            Me.DataGridViewForm_DetailsLevelLines.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_DetailsLevelLines.AllowDragAndDrop = False
            Me.DataGridViewForm_DetailsLevelLines.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_DetailsLevelLines.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_DetailsLevelLines.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_DetailsLevelLines.AutoFilterLookupColumns = False
            Me.DataGridViewForm_DetailsLevelLines.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_DetailsLevelLines.AutoUpdateViewCaption = True
            Me.DataGridViewForm_DetailsLevelLines.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewForm_DetailsLevelLines.DataSource = Nothing
            Me.DataGridViewForm_DetailsLevelLines.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_DetailsLevelLines.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_DetailsLevelLines.ItemDescription = "Level/Line(s)"
            Me.DataGridViewForm_DetailsLevelLines.Location = New System.Drawing.Point(441, 38)
            Me.DataGridViewForm_DetailsLevelLines.MultiSelect = True
            Me.DataGridViewForm_DetailsLevelLines.Name = "DataGridViewForm_DetailsLevelLines"
            Me.DataGridViewForm_DetailsLevelLines.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_DetailsLevelLines.RunStandardValidation = True
            Me.DataGridViewForm_DetailsLevelLines.ShowSelectDeselectAllButtons = True
            Me.DataGridViewForm_DetailsLevelLines.Size = New System.Drawing.Size(346, 455)
            Me.DataGridViewForm_DetailsLevelLines.TabIndex = 7
            Me.DataGridViewForm_DetailsLevelLines.UseEmbeddedNavigator = False
            Me.DataGridViewForm_DetailsLevelLines.ViewCaptionHeight = -1
            '
            'CheckBoxForm_IncludeData
            '
            Me.CheckBoxForm_IncludeData.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxForm_IncludeData.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_IncludeData.CheckValue = 0
            Me.CheckBoxForm_IncludeData.CheckValueChecked = 1
            Me.CheckBoxForm_IncludeData.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_IncludeData.CheckValueUnchecked = 0
            Me.CheckBoxForm_IncludeData.ChildControls = CType(resources.GetObject("CheckBoxForm_IncludeData.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_IncludeData.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_IncludeData.Location = New System.Drawing.Point(532, 499)
            Me.CheckBoxForm_IncludeData.Name = "CheckBoxForm_IncludeData"
            Me.CheckBoxForm_IncludeData.OldestSibling = Nothing
            Me.CheckBoxForm_IncludeData.SecurityEnabled = True
            Me.CheckBoxForm_IncludeData.SiblingControls = CType(resources.GetObject("CheckBoxForm_IncludeData.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_IncludeData.Size = New System.Drawing.Size(93, 20)
            Me.CheckBoxForm_IncludeData.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_IncludeData.TabIndex = 9
            Me.CheckBoxForm_IncludeData.Text = "Include Data"
            '
            'CheckBoxForm_ShowEsitmatesForAllMediaTypes
            '
            Me.CheckBoxForm_ShowEsitmatesForAllMediaTypes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxForm_ShowEsitmatesForAllMediaTypes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_ShowEsitmatesForAllMediaTypes.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_ShowEsitmatesForAllMediaTypes.ChildControls = CType(resources.GetObject("CheckBoxForm_ShowEsitmatesForAllMediaTypes.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_ShowEsitmatesForAllMediaTypes.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_ShowEsitmatesForAllMediaTypes.Location = New System.Drawing.Point(357, 12)
            Me.CheckBoxForm_ShowEsitmatesForAllMediaTypes.Name = "CheckBoxForm_ShowEsitmatesForAllMediaTypes"
            Me.CheckBoxForm_ShowEsitmatesForAllMediaTypes.OldestSibling = Nothing
            Me.CheckBoxForm_ShowEsitmatesForAllMediaTypes.SecurityEnabled = True
            Me.CheckBoxForm_ShowEsitmatesForAllMediaTypes.SiblingControls = CType(resources.GetObject("CheckBoxForm_ShowEsitmatesForAllMediaTypes.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_ShowEsitmatesForAllMediaTypes.Size = New System.Drawing.Size(349, 20)
            Me.CheckBoxForm_ShowEsitmatesForAllMediaTypes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_ShowEsitmatesForAllMediaTypes.TabIndex = 4
            Me.CheckBoxForm_ShowEsitmatesForAllMediaTypes.Text = "Show Estimates For All Media Types"
            '
            'DateTimePickerForm_EndDate
            '
            Me.DateTimePickerForm_EndDate.AllowEmptyState = False
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
            Me.DateTimePickerForm_EndDate.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePickerForm_EndDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerForm_EndDate.DisplayName = ""
            Me.DateTimePickerForm_EndDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerForm_EndDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerForm_EndDate.FocusHighlightEnabled = True
            Me.DateTimePickerForm_EndDate.FreeTextEntryMode = True
            Me.DateTimePickerForm_EndDate.IsPopupCalendarOpen = False
            Me.DateTimePickerForm_EndDate.Location = New System.Drawing.Point(251, 12)
            Me.DateTimePickerForm_EndDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
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
            Me.DateTimePickerForm_EndDate.MonthCalendar.DisplayMonth = New Date(2015, 2, 1, 0, 0, 0, 0)
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
            Me.DateTimePickerForm_EndDate.Size = New System.Drawing.Size(100, 20)
            Me.DateTimePickerForm_EndDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_EndDate.TabIndex = 3
            '
            'DateTimePickerForm_StartDate
            '
            Me.DateTimePickerForm_StartDate.AllowEmptyState = False
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
            Me.DateTimePickerForm_StartDate.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePickerForm_StartDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerForm_StartDate.DisplayName = ""
            Me.DateTimePickerForm_StartDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerForm_StartDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerForm_StartDate.FocusHighlightEnabled = True
            Me.DateTimePickerForm_StartDate.FreeTextEntryMode = True
            Me.DateTimePickerForm_StartDate.IsPopupCalendarOpen = False
            Me.DateTimePickerForm_StartDate.Location = New System.Drawing.Point(79, 12)
            Me.DateTimePickerForm_StartDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
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
            Me.DateTimePickerForm_StartDate.MonthCalendar.DisplayMonth = New Date(2015, 2, 1, 0, 0, 0, 0)
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
            Me.DateTimePickerForm_StartDate.Size = New System.Drawing.Size(100, 20)
            Me.DateTimePickerForm_StartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_StartDate.TabIndex = 1
            '
            'LabelForm_EndDate
            '
            Me.LabelForm_EndDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_EndDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_EndDate.Location = New System.Drawing.Point(185, 12)
            Me.LabelForm_EndDate.Name = "LabelForm_EndDate"
            Me.LabelForm_EndDate.Size = New System.Drawing.Size(60, 20)
            Me.LabelForm_EndDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_EndDate.TabIndex = 2
            Me.LabelForm_EndDate.Text = "End Date:"
            '
            'LabelForm_StartDate
            '
            Me.LabelForm_StartDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_StartDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_StartDate.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_StartDate.Name = "LabelForm_StartDate"
            Me.LabelForm_StartDate.Size = New System.Drawing.Size(60, 20)
            Me.LabelForm_StartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_StartDate.TabIndex = 0
            Me.LabelForm_StartDate.Text = "Start Date:"
            '
            'ButtonForm_Filter
            '
            Me.ButtonForm_Filter.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Filter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Filter.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Filter.Location = New System.Drawing.Point(712, 12)
            Me.ButtonForm_Filter.Name = "ButtonForm_Filter"
            Me.ButtonForm_Filter.SecurityEnabled = True
            Me.ButtonForm_Filter.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Filter.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Filter.TabIndex = 5
            Me.ButtonForm_Filter.Text = "Filter"
            '
            'CheckBoxForm_LevelsOnly
            '
            Me.CheckBoxForm_LevelsOnly.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxForm_LevelsOnly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_LevelsOnly.CheckValue = 0
            Me.CheckBoxForm_LevelsOnly.CheckValueChecked = 1
            Me.CheckBoxForm_LevelsOnly.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_LevelsOnly.CheckValueUnchecked = 0
            Me.CheckBoxForm_LevelsOnly.ChildControls = CType(resources.GetObject("CheckBoxForm_LevelsOnly.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_LevelsOnly.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_LevelsOnly.Location = New System.Drawing.Point(441, 499)
            Me.CheckBoxForm_LevelsOnly.Name = "CheckBoxForm_LevelsOnly"
            Me.CheckBoxForm_LevelsOnly.OldestSibling = Nothing
            Me.CheckBoxForm_LevelsOnly.SecurityEnabled = True
            Me.CheckBoxForm_LevelsOnly.SiblingControls = CType(resources.GetObject("CheckBoxForm_LevelsOnly.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_LevelsOnly.Size = New System.Drawing.Size(85, 20)
            Me.CheckBoxForm_LevelsOnly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_LevelsOnly.TabIndex = 8
            Me.CheckBoxForm_LevelsOnly.Text = "Levels Only"
            '
            'MediaPlanDetailLevelsAndLinesCopyDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(799, 531)
            Me.Controls.Add(Me.CheckBoxForm_LevelsOnly)
            Me.Controls.Add(Me.ButtonForm_Filter)
            Me.Controls.Add(Me.LabelForm_StartDate)
            Me.Controls.Add(Me.LabelForm_EndDate)
            Me.Controls.Add(Me.DateTimePickerForm_StartDate)
            Me.Controls.Add(Me.DateTimePickerForm_EndDate)
            Me.Controls.Add(Me.CheckBoxForm_ShowEsitmatesForAllMediaTypes)
            Me.Controls.Add(Me.CheckBoxForm_IncludeData)
            Me.Controls.Add(Me.DataGridViewForm_DetailsLevelLines)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.DataGridViewForm_MediaPlanDetails)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaPlanDetailLevelsAndLinesCopyDialog"
            Me.Text = "Copy Detail Levels\Lines"
            CType(Me.DateTimePickerForm_EndDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerForm_StartDate, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewForm_MediaPlanDetails As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewForm_DetailsLevelLines As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents CheckBoxForm_IncludeData As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_ShowEsitmatesForAllMediaTypes As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents DateTimePickerForm_EndDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerForm_StartDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents LabelForm_EndDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_StartDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonForm_Filter As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents CheckBoxForm_LevelsOnly As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
    End Class

End Namespace