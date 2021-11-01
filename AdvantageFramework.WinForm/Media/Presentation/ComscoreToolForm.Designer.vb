Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class ComscoreToolForm
        Inherits AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseForm

        'Form overrides dispose to clean up the component list.
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ComscoreToolForm))
            Me.LabelComscoreMarket = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.SearchableComboBox_ComscoreStation = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView14 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelComscoreStartDate = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelComscoreStartTime = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.DateTimePickerComscore_StartTime = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerComscore_StartDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.Label1 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.Label2 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.ButtonForm_Submit = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.SearchableComboBox_Market = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox()
            Me.GridView7 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBox_Demo = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox()
            Me.GridView2 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.Label3 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.Label4 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.Label5 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.Label6 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.Label7 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.Label8 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelRating = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelImpressions = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelUE = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelShare = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelSIU = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelElapsedTime = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.ButtonShowJson = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonClipboard = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonShowJsonResponse = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonClipboardResponse = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            CType(Me.SearchableComboBox_ComscoreStation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView14, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerComscore_StartTime, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerComscore_StartDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBox_Market.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView7, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBox_Demo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'LabelComscoreMarket
            '
            Me.LabelComscoreMarket.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelComscoreMarket.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelComscoreMarket.Location = New System.Drawing.Point(12, 12)
            Me.LabelComscoreMarket.Name = "LabelComscoreMarket"
            Me.LabelComscoreMarket.Size = New System.Drawing.Size(63, 20)
            Me.LabelComscoreMarket.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelComscoreMarket.TabIndex = 0
            Me.LabelComscoreMarket.Text = "Market:"
            '
            'SearchableComboBox_ComscoreStation
            '
            Me.SearchableComboBox_ComscoreStation.ActiveFilterString = ""
            Me.SearchableComboBox_ComscoreStation.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBox_ComscoreStation.AutoFillMode = False
            Me.SearchableComboBox_ComscoreStation.BookmarkingEnabled = False
            Me.SearchableComboBox_ComscoreStation.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.ComscoreTVStation
            Me.SearchableComboBox_ComscoreStation.DataSource = Nothing
            Me.SearchableComboBox_ComscoreStation.DisableMouseWheel = False
            Me.SearchableComboBox_ComscoreStation.DisplayName = "Comscore Station"
            Me.SearchableComboBox_ComscoreStation.EnterMoveNextControl = True
            Me.SearchableComboBox_ComscoreStation.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBox_ComscoreStation.Location = New System.Drawing.Point(81, 38)
            Me.SearchableComboBox_ComscoreStation.Name = "SearchableComboBox_ComscoreStation"
            Me.SearchableComboBox_ComscoreStation.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBox_ComscoreStation.Properties.DisplayMember = "Name"
            Me.SearchableComboBox_ComscoreStation.Properties.NullText = "Select TV Station"
            Me.SearchableComboBox_ComscoreStation.Properties.PopupView = Me.GridView14
            Me.SearchableComboBox_ComscoreStation.Properties.ValueMember = "ID"
            Me.SearchableComboBox_ComscoreStation.SecurityEnabled = True
            Me.SearchableComboBox_ComscoreStation.SelectedValue = Nothing
            Me.SearchableComboBox_ComscoreStation.Size = New System.Drawing.Size(318, 20)
            Me.SearchableComboBox_ComscoreStation.TabIndex = 3
            '
            'GridView14
            '
            Me.GridView14.AFActiveFilterString = ""
            Me.GridView14.AllowExtraItemsInGridLookupEdits = True
            Me.GridView14.AutoFilterLookupColumns = False
            Me.GridView14.AutoloadRepositoryDatasource = True
            Me.GridView14.DataSourceClearing = False
            Me.GridView14.EnableDisabledRows = False
            Me.GridView14.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView14.Name = "GridView14"
            Me.GridView14.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView14.OptionsView.ShowGroupPanel = False
            Me.GridView14.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView14.RunStandardValidation = True
            Me.GridView14.SkipAddingControlsOnModifyColumn = False
            Me.GridView14.SkipSettingFontOnModifyColumn = False
            '
            'LabelComscoreStartDate
            '
            Me.LabelComscoreStartDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelComscoreStartDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelComscoreStartDate.Location = New System.Drawing.Point(12, 64)
            Me.LabelComscoreStartDate.Name = "LabelComscoreStartDate"
            Me.LabelComscoreStartDate.Size = New System.Drawing.Size(63, 20)
            Me.LabelComscoreStartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelComscoreStartDate.TabIndex = 4
            Me.LabelComscoreStartDate.Text = "Start Date:"
            '
            'LabelComscoreStartTime
            '
            Me.LabelComscoreStartTime.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelComscoreStartTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelComscoreStartTime.Location = New System.Drawing.Point(168, 64)
            Me.LabelComscoreStartTime.Name = "LabelComscoreStartTime"
            Me.LabelComscoreStartTime.Size = New System.Drawing.Size(63, 20)
            Me.LabelComscoreStartTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelComscoreStartTime.TabIndex = 6
            Me.LabelComscoreStartTime.Text = "Start Time:"
            '
            'DateTimePickerComscore_StartTime
            '
            Me.DateTimePickerComscore_StartTime.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerComscore_StartTime.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerComscore_StartTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerComscore_StartTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerComscore_StartTime.ButtonFreeText.Checked = True
            Me.DateTimePickerComscore_StartTime.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.TimeOnly
            Me.DateTimePickerComscore_StartTime.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.TimeSelector
            Me.DateTimePickerComscore_StartTime.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerComscore_StartTime.DisplayName = "Start Time"
            Me.DateTimePickerComscore_StartTime.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerComscore_StartTime.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerComscore_StartTime.FocusHighlightEnabled = True
            Me.DateTimePickerComscore_StartTime.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime
            Me.DateTimePickerComscore_StartTime.FreeTextEntryMode = True
            Me.DateTimePickerComscore_StartTime.IsPopupCalendarOpen = False
            Me.DateTimePickerComscore_StartTime.Location = New System.Drawing.Point(237, 64)
            Me.DateTimePickerComscore_StartTime.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerComscore_StartTime.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerComscore_StartTime.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerComscore_StartTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerComscore_StartTime.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerComscore_StartTime.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerComscore_StartTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerComscore_StartTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerComscore_StartTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerComscore_StartTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerComscore_StartTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerComscore_StartTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerComscore_StartTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerComscore_StartTime.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerComscore_StartTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerComscore_StartTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerComscore_StartTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerComscore_StartTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerComscore_StartTime.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerComscore_StartTime.MonthCalendar.Visible = False
            Me.DateTimePickerComscore_StartTime.Name = "DateTimePickerComscore_StartTime"
            Me.DateTimePickerComscore_StartTime.ReadOnly = False
            Me.DateTimePickerComscore_StartTime.Size = New System.Drawing.Size(81, 20)
            Me.DateTimePickerComscore_StartTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerComscore_StartTime.TabIndex = 7
            Me.DateTimePickerComscore_StartTime.TabOnEnter = True
            Me.DateTimePickerComscore_StartTime.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time12H
            Me.DateTimePickerComscore_StartTime.Value = New Date(2017, 1, 13, 11, 26, 28, 875)
            '
            'DateTimePickerComscore_StartDate
            '
            Me.DateTimePickerComscore_StartDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerComscore_StartDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerComscore_StartDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerComscore_StartDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerComscore_StartDate.ButtonDropDown.Visible = True
            Me.DateTimePickerComscore_StartDate.ButtonFreeText.Checked = True
            Me.DateTimePickerComscore_StartDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePickerComscore_StartDate.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePickerComscore_StartDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerComscore_StartDate.DisplayName = "Start Date"
            Me.DateTimePickerComscore_StartDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerComscore_StartDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerComscore_StartDate.FocusHighlightEnabled = True
            Me.DateTimePickerComscore_StartDate.FreeTextEntryMode = True
            Me.DateTimePickerComscore_StartDate.IsPopupCalendarOpen = False
            Me.DateTimePickerComscore_StartDate.Location = New System.Drawing.Point(81, 64)
            Me.DateTimePickerComscore_StartDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerComscore_StartDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerComscore_StartDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerComscore_StartDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerComscore_StartDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerComscore_StartDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerComscore_StartDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerComscore_StartDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerComscore_StartDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerComscore_StartDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerComscore_StartDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerComscore_StartDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerComscore_StartDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerComscore_StartDate.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerComscore_StartDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerComscore_StartDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerComscore_StartDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerComscore_StartDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerComscore_StartDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerComscore_StartDate.Name = "DateTimePickerComscore_StartDate"
            Me.DateTimePickerComscore_StartDate.ReadOnly = False
            Me.DateTimePickerComscore_StartDate.Size = New System.Drawing.Size(81, 20)
            Me.DateTimePickerComscore_StartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerComscore_StartDate.TabIndex = 5
            Me.DateTimePickerComscore_StartDate.TabOnEnter = True
            Me.DateTimePickerComscore_StartDate.Value = New Date(2017, 1, 13, 11, 25, 50, 65)
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.Label1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label1.Location = New System.Drawing.Point(12, 38)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(63, 20)
            Me.Label1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label1.TabIndex = 2
            Me.Label1.Text = "Station:"
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.Label2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label2.Location = New System.Drawing.Point(12, 90)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(63, 20)
            Me.Label2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label2.TabIndex = 8
            Me.Label2.Text = "Demo:"
            '
            'ButtonForm_Submit
            '
            Me.ButtonForm_Submit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Submit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Submit.Location = New System.Drawing.Point(81, 116)
            Me.ButtonForm_Submit.Name = "ButtonForm_Submit"
            Me.ButtonForm_Submit.SecurityEnabled = True
            Me.ButtonForm_Submit.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Submit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Submit.TabIndex = 10
            Me.ButtonForm_Submit.Text = "Submit"
            '
            'SearchableComboBox_Market
            '
            Me.SearchableComboBox_Market.ActiveFilterString = ""
            Me.SearchableComboBox_Market.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBox_Market.AutoFillMode = False
            Me.SearchableComboBox_Market.BookmarkingEnabled = False
            Me.SearchableComboBox_Market.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.Type.Market
            Me.SearchableComboBox_Market.DataSource = Nothing
            Me.SearchableComboBox_Market.DisableMouseWheel = True
            Me.SearchableComboBox_Market.DisplayName = ""
            Me.SearchableComboBox_Market.EditValue = ""
            Me.SearchableComboBox_Market.EnterMoveNextControl = True
            Me.SearchableComboBox_Market.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBox_Market.Location = New System.Drawing.Point(81, 12)
            Me.SearchableComboBox_Market.Name = "SearchableComboBox_Market"
            Me.SearchableComboBox_Market.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBox_Market.Properties.DisplayMember = "Description"
            Me.SearchableComboBox_Market.Properties.NullText = "Select Market"
            Me.SearchableComboBox_Market.Properties.PopupView = Me.GridView7
            Me.SearchableComboBox_Market.Properties.ShowClearButton = False
            Me.SearchableComboBox_Market.Properties.ValueMember = "Code"
            Me.SearchableComboBox_Market.SecurityEnabled = True
            Me.SearchableComboBox_Market.SelectedValue = ""
            Me.SearchableComboBox_Market.Size = New System.Drawing.Size(318, 20)
            Me.SearchableComboBox_Market.TabIndex = 1
            '
            'GridView7
            '
            Me.GridView7.AFActiveFilterString = ""
            Me.GridView7.AllowExtraItemsInGridLookupEdits = True
            Me.GridView7.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.AutoFilterLookupColumns = False
            Me.GridView7.AutoloadRepositoryDatasource = True
            Me.GridView7.DataSourceClearing = False
            Me.GridView7.EnableDisabledRows = False
            Me.GridView7.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView7.Name = "GridView7"
            Me.GridView7.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView7.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView7.OptionsBehavior.Editable = False
            Me.GridView7.OptionsCustomization.AllowQuickHideColumns = False
            Me.GridView7.OptionsNavigation.AutoFocusNewRow = True
            Me.GridView7.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView7.OptionsSelection.MultiSelect = True
            Me.GridView7.OptionsView.ColumnAutoWidth = False
            Me.GridView7.OptionsView.ShowGroupPanel = False
            Me.GridView7.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.GridView7.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView7.RunStandardValidation = True
            Me.GridView7.SkipAddingControlsOnModifyColumn = False
            Me.GridView7.SkipSettingFontOnModifyColumn = False
            '
            'SearchableComboBox_Demo
            '
            Me.SearchableComboBox_Demo.ActiveFilterString = ""
            Me.SearchableComboBox_Demo.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBox_Demo.AutoFillMode = False
            Me.SearchableComboBox_Demo.BookmarkingEnabled = False
            Me.SearchableComboBox_Demo.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.Type.MediaDemographic
            Me.SearchableComboBox_Demo.DataSource = Nothing
            Me.SearchableComboBox_Demo.DisableMouseWheel = True
            Me.SearchableComboBox_Demo.DisplayName = ""
            Me.SearchableComboBox_Demo.EditValue = ""
            Me.SearchableComboBox_Demo.EnterMoveNextControl = True
            Me.SearchableComboBox_Demo.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBox_Demo.Location = New System.Drawing.Point(81, 90)
            Me.SearchableComboBox_Demo.Name = "SearchableComboBox_Demo"
            Me.SearchableComboBox_Demo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBox_Demo.Properties.DisplayMember = "Description"
            Me.SearchableComboBox_Demo.Properties.NullText = "Select Demographic"
            Me.SearchableComboBox_Demo.Properties.PopupView = Me.GridView2
            Me.SearchableComboBox_Demo.Properties.ShowClearButton = False
            Me.SearchableComboBox_Demo.Properties.ValueMember = "ID"
            Me.SearchableComboBox_Demo.SecurityEnabled = True
            Me.SearchableComboBox_Demo.SelectedValue = ""
            Me.SearchableComboBox_Demo.Size = New System.Drawing.Size(318, 20)
            Me.SearchableComboBox_Demo.TabIndex = 9
            '
            'GridView2
            '
            Me.GridView2.AFActiveFilterString = ""
            Me.GridView2.AllowExtraItemsInGridLookupEdits = True
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
            Me.GridView2.AutoFilterLookupColumns = False
            Me.GridView2.AutoloadRepositoryDatasource = True
            Me.GridView2.DataSourceClearing = False
            Me.GridView2.EnableDisabledRows = False
            Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
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
            Me.GridView2.RunStandardValidation = True
            Me.GridView2.SkipAddingControlsOnModifyColumn = False
            Me.GridView2.SkipSettingFontOnModifyColumn = False
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.Label3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label3.Location = New System.Drawing.Point(81, 155)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(75, 20)
            Me.Label3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label3.TabIndex = 11
            Me.Label3.Text = "Rating:"
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.Label4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label4.Location = New System.Drawing.Point(81, 181)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(75, 20)
            Me.Label4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label4.TabIndex = 13
            Me.Label4.Text = "Impressions:"
            '
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.Label5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label5.Location = New System.Drawing.Point(81, 207)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(75, 20)
            Me.Label5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label5.TabIndex = 15
            Me.Label5.Text = "UE:"
            '
            'Label6
            '
            Me.Label6.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.Label6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label6.Location = New System.Drawing.Point(81, 233)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(75, 20)
            Me.Label6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label6.TabIndex = 17
            Me.Label6.Text = "Share:"
            '
            'Label7
            '
            Me.Label7.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.Label7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label7.Location = New System.Drawing.Point(81, 259)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(75, 20)
            Me.Label7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label7.TabIndex = 19
            Me.Label7.Text = "SIU:"
            '
            'Label8
            '
            Me.Label8.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.Label8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label8.Location = New System.Drawing.Point(81, 285)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(75, 20)
            Me.Label8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label8.TabIndex = 21
            Me.Label8.Text = "Elapsed Time:"
            '
            'LabelRating
            '
            Me.LabelRating.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRating.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRating.Location = New System.Drawing.Point(162, 155)
            Me.LabelRating.Name = "LabelRating"
            Me.LabelRating.Size = New System.Drawing.Size(75, 20)
            Me.LabelRating.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRating.TabIndex = 12
            '
            'LabelImpressions
            '
            Me.LabelImpressions.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelImpressions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelImpressions.Location = New System.Drawing.Point(162, 181)
            Me.LabelImpressions.Name = "LabelImpressions"
            Me.LabelImpressions.Size = New System.Drawing.Size(75, 20)
            Me.LabelImpressions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelImpressions.TabIndex = 14
            '
            'LabelUE
            '
            Me.LabelUE.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelUE.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelUE.Location = New System.Drawing.Point(162, 207)
            Me.LabelUE.Name = "LabelUE"
            Me.LabelUE.Size = New System.Drawing.Size(75, 20)
            Me.LabelUE.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelUE.TabIndex = 16
            '
            'LabelShare
            '
            Me.LabelShare.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelShare.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelShare.Location = New System.Drawing.Point(162, 233)
            Me.LabelShare.Name = "LabelShare"
            Me.LabelShare.Size = New System.Drawing.Size(75, 20)
            Me.LabelShare.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelShare.TabIndex = 18
            '
            'LabelSIU
            '
            Me.LabelSIU.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSIU.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSIU.Location = New System.Drawing.Point(162, 259)
            Me.LabelSIU.Name = "LabelSIU"
            Me.LabelSIU.Size = New System.Drawing.Size(75, 20)
            Me.LabelSIU.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSIU.TabIndex = 20
            '
            'LabelElapsedTime
            '
            Me.LabelElapsedTime.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelElapsedTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelElapsedTime.Location = New System.Drawing.Point(162, 285)
            Me.LabelElapsedTime.Name = "LabelElapsedTime"
            Me.LabelElapsedTime.Size = New System.Drawing.Size(75, 20)
            Me.LabelElapsedTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelElapsedTime.TabIndex = 22
            '
            'ButtonShowJson
            '
            Me.ButtonShowJson.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonShowJson.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonShowJson.Location = New System.Drawing.Point(81, 311)
            Me.ButtonShowJson.Name = "ButtonShowJson"
            Me.ButtonShowJson.SecurityEnabled = True
            Me.ButtonShowJson.Size = New System.Drawing.Size(156, 20)
            Me.ButtonShowJson.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonShowJson.TabIndex = 25
            Me.ButtonShowJson.Text = "Show JSON Request"
            '
            'ButtonClipboard
            '
            Me.ButtonClipboard.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonClipboard.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonClipboard.Location = New System.Drawing.Point(81, 337)
            Me.ButtonClipboard.Name = "ButtonClipboard"
            Me.ButtonClipboard.SecurityEnabled = True
            Me.ButtonClipboard.Size = New System.Drawing.Size(156, 20)
            Me.ButtonClipboard.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonClipboard.TabIndex = 26
            Me.ButtonClipboard.Text = "Copy JSON to Clipboard"
            Me.ButtonClipboard.Tooltip = "Copy REQUEST to clipboard"
            '
            'ButtonShowJsonResponse
            '
            Me.ButtonShowJsonResponse.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonShowJsonResponse.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonShowJsonResponse.Location = New System.Drawing.Point(243, 311)
            Me.ButtonShowJsonResponse.Name = "ButtonShowJsonResponse"
            Me.ButtonShowJsonResponse.SecurityEnabled = True
            Me.ButtonShowJsonResponse.Size = New System.Drawing.Size(156, 20)
            Me.ButtonShowJsonResponse.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonShowJsonResponse.TabIndex = 27
            Me.ButtonShowJsonResponse.Text = "Show JSON Response"
            '
            'ButtonClipboardResponse
            '
            Me.ButtonClipboardResponse.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonClipboardResponse.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonClipboardResponse.Location = New System.Drawing.Point(243, 337)
            Me.ButtonClipboardResponse.Name = "ButtonClipboardResponse"
            Me.ButtonClipboardResponse.SecurityEnabled = True
            Me.ButtonClipboardResponse.Size = New System.Drawing.Size(156, 20)
            Me.ButtonClipboardResponse.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonClipboardResponse.TabIndex = 28
            Me.ButtonClipboardResponse.Text = "Copy JSON to Clipboard"
            Me.ButtonClipboardResponse.Tooltip = "Copy RESPONSE to clipboard"
            '
            'ComscoreToolForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(814, 421)
            Me.Controls.Add(Me.ButtonClipboardResponse)
            Me.Controls.Add(Me.ButtonShowJsonResponse)
            Me.Controls.Add(Me.ButtonClipboard)
            Me.Controls.Add(Me.ButtonShowJson)
            Me.Controls.Add(Me.LabelElapsedTime)
            Me.Controls.Add(Me.LabelSIU)
            Me.Controls.Add(Me.LabelShare)
            Me.Controls.Add(Me.LabelUE)
            Me.Controls.Add(Me.LabelImpressions)
            Me.Controls.Add(Me.LabelRating)
            Me.Controls.Add(Me.Label8)
            Me.Controls.Add(Me.Label7)
            Me.Controls.Add(Me.Label6)
            Me.Controls.Add(Me.Label5)
            Me.Controls.Add(Me.Label4)
            Me.Controls.Add(Me.Label3)
            Me.Controls.Add(Me.SearchableComboBox_Demo)
            Me.Controls.Add(Me.SearchableComboBox_Market)
            Me.Controls.Add(Me.ButtonForm_Submit)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.LabelComscoreStartDate)
            Me.Controls.Add(Me.LabelComscoreStartTime)
            Me.Controls.Add(Me.DateTimePickerComscore_StartTime)
            Me.Controls.Add(Me.DateTimePickerComscore_StartDate)
            Me.Controls.Add(Me.SearchableComboBox_ComscoreStation)
            Me.Controls.Add(Me.LabelComscoreMarket)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ComscoreToolForm"
            Me.Text = "Comscore Tester"
            CType(Me.SearchableComboBox_ComscoreStation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView14, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerComscore_StartTime, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerComscore_StartDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBox_Market.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView7, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBox_Demo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents LabelComscoreMarket As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents SearchableComboBox_ComscoreStation As WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView14 As WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelComscoreStartDate As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelComscoreStartTime As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents DateTimePickerComscore_StartTime As WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerComscore_StartDate As WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents Label1 As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents Label2 As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents ButtonForm_Submit As WinForm.Presentation.Controls.Button
        Friend WithEvents SearchableComboBox_Market As WinForm.MVC.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView7 As WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBox_Demo As WinForm.MVC.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView2 As WinForm.Presentation.Controls.GridView
        Friend WithEvents Label3 As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents Label4 As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents Label5 As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents Label6 As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents Label7 As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents Label8 As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelRating As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelImpressions As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelUE As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelShare As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelSIU As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelElapsedTime As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents ButtonShowJson As WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonClipboard As WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonShowJsonResponse As WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonClipboardResponse As WinForm.Presentation.Controls.Button
    End Class

End Namespace