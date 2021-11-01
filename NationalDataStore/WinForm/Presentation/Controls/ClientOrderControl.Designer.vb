Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class ClientOrderControl
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClientOrderControl))
            Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.CheckBoxControl_IsSuspended = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.DataGridViewControl_Details = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.TextBoxControl_Report = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.DateTimePickerControl_LastChangedDateTime = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.TextBoxControl_ClientAlias = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.LabelControl_ClientAlias = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.NumericInputControl_EndYear = New AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput()
            Me.NumericInputControl_StartYear = New AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput()
            Me.LabelControl_EndYear = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelControl_StartYear = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.NumericInputControl_OrderNumber = New AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput()
            Me.LabelControl_LastChangedDateTime = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.DateTimePickerControl_OrderDateTime = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelControl_Report = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelControl_OrderDuration = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.TextBoxControl_OrderDuration = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.LabelControl_OrderDateTime = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelControl_OrderNumber = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_RightSection.SuspendLayout()
            CType(Me.DateTimePickerControl_LastChangedDateTime, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputControl_EndYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputControl_StartYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputControl_OrderNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerControl_OrderDateTime, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'PanelForm_RightSection
            '
            Me.PanelForm_RightSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelForm_RightSection.Controls.Add(Me.CheckBoxControl_IsSuspended)
            Me.PanelForm_RightSection.Controls.Add(Me.DataGridViewControl_Details)
            Me.PanelForm_RightSection.Controls.Add(Me.TextBoxControl_Report)
            Me.PanelForm_RightSection.Controls.Add(Me.DateTimePickerControl_LastChangedDateTime)
            Me.PanelForm_RightSection.Controls.Add(Me.TextBoxControl_ClientAlias)
            Me.PanelForm_RightSection.Controls.Add(Me.LabelControl_ClientAlias)
            Me.PanelForm_RightSection.Controls.Add(Me.NumericInputControl_EndYear)
            Me.PanelForm_RightSection.Controls.Add(Me.NumericInputControl_StartYear)
            Me.PanelForm_RightSection.Controls.Add(Me.LabelControl_EndYear)
            Me.PanelForm_RightSection.Controls.Add(Me.LabelControl_StartYear)
            Me.PanelForm_RightSection.Controls.Add(Me.NumericInputControl_OrderNumber)
            Me.PanelForm_RightSection.Controls.Add(Me.LabelControl_LastChangedDateTime)
            Me.PanelForm_RightSection.Controls.Add(Me.DateTimePickerControl_OrderDateTime)
            Me.PanelForm_RightSection.Controls.Add(Me.LabelControl_Report)
            Me.PanelForm_RightSection.Controls.Add(Me.LabelControl_OrderDuration)
            Me.PanelForm_RightSection.Controls.Add(Me.TextBoxControl_OrderDuration)
            Me.PanelForm_RightSection.Controls.Add(Me.LabelControl_OrderDateTime)
            Me.PanelForm_RightSection.Controls.Add(Me.LabelControl_OrderNumber)
            Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_RightSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
            Me.PanelForm_RightSection.Size = New System.Drawing.Size(1158, 545)
            Me.PanelForm_RightSection.TabIndex = 0
            '
            'CheckBoxControl_IsSuspended
            '
            '
            '
            '
            Me.CheckBoxControl_IsSuspended.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxControl_IsSuspended.CheckValue = 0
            Me.CheckBoxControl_IsSuspended.CheckValueChecked = 1
            Me.CheckBoxControl_IsSuspended.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxControl_IsSuspended.CheckValueUnchecked = 0
            Me.CheckBoxControl_IsSuspended.ChildControls = CType(resources.GetObject("CheckBoxControl_IsSuspended.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxControl_IsSuspended.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxControl_IsSuspended.Location = New System.Drawing.Point(254, 0)
            Me.CheckBoxControl_IsSuspended.Name = "CheckBoxControl_IsSuspended"
            Me.CheckBoxControl_IsSuspended.OldestSibling = Nothing
            Me.CheckBoxControl_IsSuspended.SecurityEnabled = True
            Me.CheckBoxControl_IsSuspended.SiblingControls = CType(resources.GetObject("CheckBoxControl_IsSuspended.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxControl_IsSuspended.Size = New System.Drawing.Size(103, 20)
            Me.CheckBoxControl_IsSuspended.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxControl_IsSuspended.TabIndex = 21
            Me.CheckBoxControl_IsSuspended.TabOnEnter = True
            Me.CheckBoxControl_IsSuspended.Text = "Is Suspended"
            '
            'DataGridViewControl_Details
            '
            Me.DataGridViewControl_Details.AllowSelectGroupHeaderRow = True
            Me.DataGridViewControl_Details.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewControl_Details.AutoUpdateViewCaption = True
            Me.DataGridViewControl_Details.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewControl_Details.ItemDescription = "Detail(s)"
            Me.DataGridViewControl_Details.Location = New System.Drawing.Point(0, 183)
            Me.DataGridViewControl_Details.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewControl_Details.ModifyGridRowHeight = False
            Me.DataGridViewControl_Details.MultiSelect = True
            Me.DataGridViewControl_Details.Name = "DataGridViewControl_Details"
            Me.DataGridViewControl_Details.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewControl_Details.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewControl_Details.ShowRowSelectionIfHidden = True
            Me.DataGridViewControl_Details.ShowSelectDeselectAllButtons = False
            Me.DataGridViewControl_Details.Size = New System.Drawing.Size(1158, 362)
            Me.DataGridViewControl_Details.TabIndex = 18
            Me.DataGridViewControl_Details.UseEmbeddedNavigator = False
            Me.DataGridViewControl_Details.ViewCaptionHeight = -1
            '
            'TextBoxControl_Report
            '
            Me.TextBoxControl_Report.AgencyImportPath = Nothing
            Me.TextBoxControl_Report.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxControl_Report.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxControl_Report.Border.Class = "TextBoxBorder"
            Me.TextBoxControl_Report.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxControl_Report.CheckSpellingOnValidate = False
            Me.TextBoxControl_Report.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxControl_Report.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxControl_Report.DisplayName = ""
            Me.TextBoxControl_Report.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxControl_Report.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxControl_Report.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxControl_Report.FocusHighlightEnabled = True
            Me.TextBoxControl_Report.ForeColor = System.Drawing.Color.Black
            Me.TextBoxControl_Report.Location = New System.Drawing.Point(109, 130)
            Me.TextBoxControl_Report.MaxFileSize = CType(0, Long)
            Me.TextBoxControl_Report.Name = "TextBoxControl_Report"
            Me.TextBoxControl_Report.SecurityEnabled = True
            Me.TextBoxControl_Report.ShowSpellCheckCompleteMessage = True
            Me.TextBoxControl_Report.Size = New System.Drawing.Size(1048, 21)
            Me.TextBoxControl_Report.StartingFolderName = Nothing
            Me.TextBoxControl_Report.TabIndex = 13
            Me.TextBoxControl_Report.TabOnEnter = True
            '
            'DateTimePickerControl_LastChangedDateTime
            '
            Me.DateTimePickerControl_LastChangedDateTime.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerControl_LastChangedDateTime.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerControl_LastChangedDateTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerControl_LastChangedDateTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerControl_LastChangedDateTime.ButtonDropDown.Visible = True
            Me.DateTimePickerControl_LastChangedDateTime.ButtonFreeText.Checked = True
            Me.DateTimePickerControl_LastChangedDateTime.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDateAndTime
            Me.DateTimePickerControl_LastChangedDateTime.CustomFormat = "M/d/yyyy h:mm tt"
            Me.DateTimePickerControl_LastChangedDateTime.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.Both
            Me.DateTimePickerControl_LastChangedDateTime.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerControl_LastChangedDateTime.DisplayName = "Last Changed"
            Me.DateTimePickerControl_LastChangedDateTime.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerControl_LastChangedDateTime.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerControl_LastChangedDateTime.FocusHighlightEnabled = True
            Me.DateTimePickerControl_LastChangedDateTime.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
            Me.DateTimePickerControl_LastChangedDateTime.FreeTextEntryMode = True
            Me.DateTimePickerControl_LastChangedDateTime.IsPopupCalendarOpen = False
            Me.DateTimePickerControl_LastChangedDateTime.Location = New System.Drawing.Point(109, 52)
            Me.DateTimePickerControl_LastChangedDateTime.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerControl_LastChangedDateTime.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerControl_LastChangedDateTime.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerControl_LastChangedDateTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerControl_LastChangedDateTime.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerControl_LastChangedDateTime.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerControl_LastChangedDateTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerControl_LastChangedDateTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerControl_LastChangedDateTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerControl_LastChangedDateTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerControl_LastChangedDateTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerControl_LastChangedDateTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerControl_LastChangedDateTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerControl_LastChangedDateTime.MonthCalendar.DayClickAutoClosePopup = False
            Me.DateTimePickerControl_LastChangedDateTime.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerControl_LastChangedDateTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerControl_LastChangedDateTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerControl_LastChangedDateTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerControl_LastChangedDateTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerControl_LastChangedDateTime.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerControl_LastChangedDateTime.Name = "DateTimePickerControl_LastChangedDateTime"
            Me.DateTimePickerControl_LastChangedDateTime.ReadOnly = False
            Me.DateTimePickerControl_LastChangedDateTime.Size = New System.Drawing.Size(139, 21)
            Me.DateTimePickerControl_LastChangedDateTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerControl_LastChangedDateTime.TabIndex = 5
            Me.DateTimePickerControl_LastChangedDateTime.TabOnEnter = True
            Me.DateTimePickerControl_LastChangedDateTime.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time12H
            Me.DateTimePickerControl_LastChangedDateTime.Value = New Date(2017, 4, 21, 14, 23, 56, 150)
            '
            'TextBoxControl_ClientAlias
            '
            Me.TextBoxControl_ClientAlias.AgencyImportPath = Nothing
            Me.TextBoxControl_ClientAlias.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxControl_ClientAlias.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxControl_ClientAlias.Border.Class = "TextBoxBorder"
            Me.TextBoxControl_ClientAlias.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxControl_ClientAlias.CheckSpellingOnValidate = False
            Me.TextBoxControl_ClientAlias.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxControl_ClientAlias.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxControl_ClientAlias.DisplayName = ""
            Me.TextBoxControl_ClientAlias.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxControl_ClientAlias.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxControl_ClientAlias.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxControl_ClientAlias.FocusHighlightEnabled = True
            Me.TextBoxControl_ClientAlias.ForeColor = System.Drawing.Color.Black
            Me.TextBoxControl_ClientAlias.Location = New System.Drawing.Point(109, 156)
            Me.TextBoxControl_ClientAlias.MaxFileSize = CType(0, Long)
            Me.TextBoxControl_ClientAlias.Name = "TextBoxControl_ClientAlias"
            Me.TextBoxControl_ClientAlias.SecurityEnabled = True
            Me.TextBoxControl_ClientAlias.ShowSpellCheckCompleteMessage = True
            Me.TextBoxControl_ClientAlias.Size = New System.Drawing.Size(1048, 21)
            Me.TextBoxControl_ClientAlias.StartingFolderName = Nothing
            Me.TextBoxControl_ClientAlias.TabIndex = 15
            Me.TextBoxControl_ClientAlias.TabOnEnter = True
            '
            'LabelControl_ClientAlias
            '
            Me.LabelControl_ClientAlias.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_ClientAlias.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_ClientAlias.Location = New System.Drawing.Point(0, 156)
            Me.LabelControl_ClientAlias.Name = "LabelControl_ClientAlias"
            Me.LabelControl_ClientAlias.Size = New System.Drawing.Size(103, 20)
            Me.LabelControl_ClientAlias.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_ClientAlias.TabIndex = 14
            Me.LabelControl_ClientAlias.Text = "Client Alias:"
            '
            'NumericInputControl_EndYear
            '
            Me.NumericInputControl_EndYear.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputControl_EndYear.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput.Type.[Short]
            Me.NumericInputControl_EndYear.EditValue = New Decimal(New Integer() {2017, 0, 0, 0})
            Me.NumericInputControl_EndYear.EnterMoveNextControl = True
            Me.NumericInputControl_EndYear.Location = New System.Drawing.Point(263, 78)
            Me.NumericInputControl_EndYear.Name = "NumericInputControl_EndYear"
            Me.NumericInputControl_EndYear.Properties.AllowMouseWheel = False
            Me.NumericInputControl_EndYear.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputControl_EndYear.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputControl_EndYear.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputControl_EndYear.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputControl_EndYear.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_EndYear.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputControl_EndYear.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_EndYear.Properties.IsFloatValue = False
            Me.NumericInputControl_EndYear.Properties.Mask.EditMask = "f0"
            Me.NumericInputControl_EndYear.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputControl_EndYear.Properties.MaxValue = New Decimal(New Integer() {32767, 0, 0, 0})
            Me.NumericInputControl_EndYear.Properties.MinValue = New Decimal(New Integer() {32768, 0, 0, -2147483648})
            Me.NumericInputControl_EndYear.SecurityEnabled = True
            Me.NumericInputControl_EndYear.Size = New System.Drawing.Size(81, 20)
            Me.NumericInputControl_EndYear.TabIndex = 9
            '
            'NumericInputControl_StartYear
            '
            Me.NumericInputControl_StartYear.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputControl_StartYear.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput.Type.[Short]
            Me.NumericInputControl_StartYear.EditValue = New Decimal(New Integer() {2017, 0, 0, 0})
            Me.NumericInputControl_StartYear.EnterMoveNextControl = True
            Me.NumericInputControl_StartYear.Location = New System.Drawing.Point(109, 78)
            Me.NumericInputControl_StartYear.Name = "NumericInputControl_StartYear"
            Me.NumericInputControl_StartYear.Properties.AllowMouseWheel = False
            Me.NumericInputControl_StartYear.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputControl_StartYear.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputControl_StartYear.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputControl_StartYear.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputControl_StartYear.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_StartYear.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputControl_StartYear.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_StartYear.Properties.IsFloatValue = False
            Me.NumericInputControl_StartYear.Properties.Mask.EditMask = "f0"
            Me.NumericInputControl_StartYear.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputControl_StartYear.Properties.MaxValue = New Decimal(New Integer() {32767, 0, 0, 0})
            Me.NumericInputControl_StartYear.Properties.MinValue = New Decimal(New Integer() {32768, 0, 0, -2147483648})
            Me.NumericInputControl_StartYear.SecurityEnabled = True
            Me.NumericInputControl_StartYear.Size = New System.Drawing.Size(81, 20)
            Me.NumericInputControl_StartYear.TabIndex = 7
            '
            'LabelControl_EndYear
            '
            Me.LabelControl_EndYear.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_EndYear.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_EndYear.Location = New System.Drawing.Point(196, 78)
            Me.LabelControl_EndYear.Name = "LabelControl_EndYear"
            Me.LabelControl_EndYear.Size = New System.Drawing.Size(61, 20)
            Me.LabelControl_EndYear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_EndYear.TabIndex = 8
            Me.LabelControl_EndYear.Text = "End Year:"
            '
            'LabelControl_StartYear
            '
            Me.LabelControl_StartYear.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_StartYear.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_StartYear.Location = New System.Drawing.Point(0, 78)
            Me.LabelControl_StartYear.Name = "LabelControl_StartYear"
            Me.LabelControl_StartYear.Size = New System.Drawing.Size(103, 20)
            Me.LabelControl_StartYear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_StartYear.TabIndex = 6
            Me.LabelControl_StartYear.Text = "Start Year:"
            '
            'NumericInputControl_OrderNumber
            '
            Me.NumericInputControl_OrderNumber.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputControl_OrderNumber.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputControl_OrderNumber.EditValue = New Decimal(New Integer() {2017, 0, 0, 0})
            Me.NumericInputControl_OrderNumber.EnterMoveNextControl = True
            Me.NumericInputControl_OrderNumber.Location = New System.Drawing.Point(109, 0)
            Me.NumericInputControl_OrderNumber.Name = "NumericInputControl_OrderNumber"
            Me.NumericInputControl_OrderNumber.Properties.AllowMouseWheel = False
            Me.NumericInputControl_OrderNumber.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputControl_OrderNumber.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputControl_OrderNumber.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputControl_OrderNumber.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputControl_OrderNumber.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_OrderNumber.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputControl_OrderNumber.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_OrderNumber.Properties.IsFloatValue = False
            Me.NumericInputControl_OrderNumber.Properties.Mask.EditMask = "f0"
            Me.NumericInputControl_OrderNumber.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputControl_OrderNumber.Properties.MaxValue = New Decimal(New Integer() {2079, 0, 0, 0})
            Me.NumericInputControl_OrderNumber.Properties.MinValue = New Decimal(New Integer() {1980, 0, 0, 0})
            Me.NumericInputControl_OrderNumber.SecurityEnabled = True
            Me.NumericInputControl_OrderNumber.Size = New System.Drawing.Size(139, 20)
            Me.NumericInputControl_OrderNumber.TabIndex = 1
            '
            'LabelControl_LastChangedDateTime
            '
            Me.LabelControl_LastChangedDateTime.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_LastChangedDateTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_LastChangedDateTime.Location = New System.Drawing.Point(0, 52)
            Me.LabelControl_LastChangedDateTime.Name = "LabelControl_LastChangedDateTime"
            Me.LabelControl_LastChangedDateTime.Size = New System.Drawing.Size(103, 20)
            Me.LabelControl_LastChangedDateTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_LastChangedDateTime.TabIndex = 4
            Me.LabelControl_LastChangedDateTime.Text = "Last Changed:"
            '
            'DateTimePickerControl_OrderDateTime
            '
            Me.DateTimePickerControl_OrderDateTime.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerControl_OrderDateTime.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerControl_OrderDateTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerControl_OrderDateTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerControl_OrderDateTime.ButtonDropDown.Visible = True
            Me.DateTimePickerControl_OrderDateTime.ButtonFreeText.Checked = True
            Me.DateTimePickerControl_OrderDateTime.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDateAndTime
            Me.DateTimePickerControl_OrderDateTime.CustomFormat = "M/d/yyyy h:mm tt"
            Me.DateTimePickerControl_OrderDateTime.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.Both
            Me.DateTimePickerControl_OrderDateTime.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerControl_OrderDateTime.DisplayName = "Order Date Time"
            Me.DateTimePickerControl_OrderDateTime.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerControl_OrderDateTime.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerControl_OrderDateTime.FocusHighlightEnabled = True
            Me.DateTimePickerControl_OrderDateTime.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
            Me.DateTimePickerControl_OrderDateTime.FreeTextEntryMode = True
            Me.DateTimePickerControl_OrderDateTime.IsPopupCalendarOpen = False
            Me.DateTimePickerControl_OrderDateTime.Location = New System.Drawing.Point(109, 26)
            Me.DateTimePickerControl_OrderDateTime.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerControl_OrderDateTime.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerControl_OrderDateTime.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerControl_OrderDateTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerControl_OrderDateTime.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerControl_OrderDateTime.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerControl_OrderDateTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerControl_OrderDateTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerControl_OrderDateTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerControl_OrderDateTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerControl_OrderDateTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerControl_OrderDateTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerControl_OrderDateTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerControl_OrderDateTime.MonthCalendar.DayClickAutoClosePopup = False
            Me.DateTimePickerControl_OrderDateTime.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerControl_OrderDateTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerControl_OrderDateTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerControl_OrderDateTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerControl_OrderDateTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerControl_OrderDateTime.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerControl_OrderDateTime.Name = "DateTimePickerControl_OrderDateTime"
            Me.DateTimePickerControl_OrderDateTime.ReadOnly = False
            Me.DateTimePickerControl_OrderDateTime.Size = New System.Drawing.Size(139, 21)
            Me.DateTimePickerControl_OrderDateTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerControl_OrderDateTime.TabIndex = 3
            Me.DateTimePickerControl_OrderDateTime.TabOnEnter = True
            Me.DateTimePickerControl_OrderDateTime.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time12H
            Me.DateTimePickerControl_OrderDateTime.Value = New Date(2017, 4, 21, 14, 23, 56, 150)
            '
            'LabelControl_Report
            '
            Me.LabelControl_Report.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_Report.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_Report.Location = New System.Drawing.Point(0, 130)
            Me.LabelControl_Report.Name = "LabelControl_Report"
            Me.LabelControl_Report.Size = New System.Drawing.Size(103, 20)
            Me.LabelControl_Report.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_Report.TabIndex = 12
            Me.LabelControl_Report.Text = "Report:"
            '
            'LabelControl_OrderDuration
            '
            Me.LabelControl_OrderDuration.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_OrderDuration.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_OrderDuration.Location = New System.Drawing.Point(0, 104)
            Me.LabelControl_OrderDuration.Name = "LabelControl_OrderDuration"
            Me.LabelControl_OrderDuration.Size = New System.Drawing.Size(103, 20)
            Me.LabelControl_OrderDuration.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_OrderDuration.TabIndex = 10
            Me.LabelControl_OrderDuration.Text = "Order Duration:"
            '
            'TextBoxControl_OrderDuration
            '
            Me.TextBoxControl_OrderDuration.AgencyImportPath = Nothing
            Me.TextBoxControl_OrderDuration.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxControl_OrderDuration.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxControl_OrderDuration.Border.Class = "TextBoxBorder"
            Me.TextBoxControl_OrderDuration.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxControl_OrderDuration.CheckSpellingOnValidate = False
            Me.TextBoxControl_OrderDuration.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxControl_OrderDuration.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxControl_OrderDuration.DisplayName = ""
            Me.TextBoxControl_OrderDuration.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxControl_OrderDuration.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxControl_OrderDuration.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxControl_OrderDuration.FocusHighlightEnabled = True
            Me.TextBoxControl_OrderDuration.ForeColor = System.Drawing.Color.Black
            Me.TextBoxControl_OrderDuration.Location = New System.Drawing.Point(109, 104)
            Me.TextBoxControl_OrderDuration.MaxFileSize = CType(0, Long)
            Me.TextBoxControl_OrderDuration.Name = "TextBoxControl_OrderDuration"
            Me.TextBoxControl_OrderDuration.SecurityEnabled = True
            Me.TextBoxControl_OrderDuration.ShowSpellCheckCompleteMessage = True
            Me.TextBoxControl_OrderDuration.Size = New System.Drawing.Size(1048, 21)
            Me.TextBoxControl_OrderDuration.StartingFolderName = Nothing
            Me.TextBoxControl_OrderDuration.TabIndex = 11
            Me.TextBoxControl_OrderDuration.TabOnEnter = True
            '
            'LabelControl_OrderDateTime
            '
            Me.LabelControl_OrderDateTime.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_OrderDateTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_OrderDateTime.Location = New System.Drawing.Point(0, 26)
            Me.LabelControl_OrderDateTime.Name = "LabelControl_OrderDateTime"
            Me.LabelControl_OrderDateTime.Size = New System.Drawing.Size(103, 20)
            Me.LabelControl_OrderDateTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_OrderDateTime.TabIndex = 2
            Me.LabelControl_OrderDateTime.Text = "Order Date Time:"
            '
            'LabelControl_OrderNumber
            '
            Me.LabelControl_OrderNumber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_OrderNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_OrderNumber.Location = New System.Drawing.Point(0, 0)
            Me.LabelControl_OrderNumber.Name = "LabelControl_OrderNumber"
            Me.LabelControl_OrderNumber.Size = New System.Drawing.Size(103, 20)
            Me.LabelControl_OrderNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_OrderNumber.TabIndex = 0
            Me.LabelControl_OrderNumber.Text = "Order Number:"
            '
            'ClientOrderControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.PanelForm_RightSection)
            Me.Name = "ClientOrderControl"
            Me.Size = New System.Drawing.Size(1158, 545)
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_RightSection.ResumeLayout(False)
            CType(Me.DateTimePickerControl_LastChangedDateTime, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputControl_EndYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputControl_StartYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputControl_OrderNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerControl_OrderDateTime, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents PanelForm_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents LabelControl_Report As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelControl_OrderDuration As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents TextBoxControl_OrderDuration As AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox
        Friend WithEvents LabelControl_OrderDateTime As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelControl_OrderNumber As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelControl_LastChangedDateTime As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents DateTimePickerControl_OrderDateTime As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents NumericInputControl_OrderNumber As AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputControl_EndYear As AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputControl_StartYear As AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput
        Friend WithEvents LabelControl_EndYear As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelControl_StartYear As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents TextBoxControl_ClientAlias As AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox
        Friend WithEvents LabelControl_ClientAlias As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents DateTimePickerControl_LastChangedDateTime As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents TextBoxControl_Report As AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox
        Friend WithEvents DataGridViewControl_Details As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents CheckBoxControl_IsSuspended As AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox
    End Class

End Namespace
