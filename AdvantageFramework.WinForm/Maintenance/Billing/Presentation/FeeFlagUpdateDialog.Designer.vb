Namespace Maintenance.Billing.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FeeFlagUpdateDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FeeFlagUpdateDialog))
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_Client = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Select = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Division = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Product = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_Client = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxForm_Division = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxForm_Product = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ButtonForm_Ok = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.Label1 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.Label2 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DateTimePickerForm_DateFrom = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerForm_DateTo = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerForm_DateFrom, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerForm_DateTo, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(266, 168)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 12
            Me.ButtonForm_Cancel.Text = "Cancel"
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
            Me.LabelForm_Client.Size = New System.Drawing.Size(84, 20)
            Me.LabelForm_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Client.TabIndex = 1
            Me.LabelForm_Client.Text = "Client:"
            '
            'LabelForm_Select
            '
            Me.LabelForm_Select.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_Select.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Select.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_Select.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_Select.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelForm_Select.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_Select.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_Select.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_Select.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Select.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelForm_Select.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_Select.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_Select.Name = "LabelForm_Select"
            Me.LabelForm_Select.Size = New System.Drawing.Size(329, 20)
            Me.LabelForm_Select.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Select.TabIndex = 0
            Me.LabelForm_Select.Text = "Select"
            '
            'LabelForm_Division
            '
            Me.LabelForm_Division.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Division.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Division.Location = New System.Drawing.Point(12, 64)
            Me.LabelForm_Division.Name = "LabelForm_Division"
            Me.LabelForm_Division.Size = New System.Drawing.Size(84, 20)
            Me.LabelForm_Division.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Division.TabIndex = 3
            Me.LabelForm_Division.Text = "Division:"
            '
            'LabelForm_Product
            '
            Me.LabelForm_Product.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Product.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Product.Location = New System.Drawing.Point(12, 90)
            Me.LabelForm_Product.Name = "LabelForm_Product"
            Me.LabelForm_Product.Size = New System.Drawing.Size(84, 20)
            Me.LabelForm_Product.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Product.TabIndex = 5
            Me.LabelForm_Product.Text = "Product:"
            '
            'ComboBoxForm_Client
            '
            Me.ComboBoxForm_Client.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Client.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_Client.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Client.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Client.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Client.BookmarkingEnabled = False
            Me.ComboBoxForm_Client.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Client
            Me.ComboBoxForm_Client.DisableMouseWheel = False
            Me.ComboBoxForm_Client.DisplayMember = "Name"
            Me.ComboBoxForm_Client.DisplayName = ""
            Me.ComboBoxForm_Client.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Client.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_Client.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_Client.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Client.FocusHighlightEnabled = True
            Me.ComboBoxForm_Client.FormattingEnabled = True
            Me.ComboBoxForm_Client.ItemHeight = 14
            Me.ComboBoxForm_Client.Location = New System.Drawing.Point(102, 38)
            Me.ComboBoxForm_Client.Name = "ComboBoxForm_Client"
            Me.ComboBoxForm_Client.PreventEnterBeep = False
            Me.ComboBoxForm_Client.ReadOnly = False
            Me.ComboBoxForm_Client.Size = New System.Drawing.Size(239, 20)
            Me.ComboBoxForm_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Client.TabIndex = 2
            Me.ComboBoxForm_Client.ValueMember = "Code"
            Me.ComboBoxForm_Client.WatermarkText = "Select Client"
            '
            'ComboBoxForm_Division
            '
            Me.ComboBoxForm_Division.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Division.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_Division.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Division.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Division.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Division.BookmarkingEnabled = False
            Me.ComboBoxForm_Division.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Division
            Me.ComboBoxForm_Division.DisableMouseWheel = False
            Me.ComboBoxForm_Division.DisplayMember = "Description"
            Me.ComboBoxForm_Division.DisplayName = ""
            Me.ComboBoxForm_Division.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Division.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_Division.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_Division.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Division.FocusHighlightEnabled = True
            Me.ComboBoxForm_Division.FormattingEnabled = True
            Me.ComboBoxForm_Division.ItemHeight = 14
            Me.ComboBoxForm_Division.Location = New System.Drawing.Point(102, 64)
            Me.ComboBoxForm_Division.Name = "ComboBoxForm_Division"
            Me.ComboBoxForm_Division.PreventEnterBeep = False
            Me.ComboBoxForm_Division.ReadOnly = False
            Me.ComboBoxForm_Division.Size = New System.Drawing.Size(239, 20)
            Me.ComboBoxForm_Division.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Division.TabIndex = 4
            Me.ComboBoxForm_Division.ValueMember = "Code"
            Me.ComboBoxForm_Division.WatermarkText = "Select Division"
            '
            'ComboBoxForm_Product
            '
            Me.ComboBoxForm_Product.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Product.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_Product.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Product.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Product.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Product.BookmarkingEnabled = False
            Me.ComboBoxForm_Product.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Product
            Me.ComboBoxForm_Product.DisableMouseWheel = False
            Me.ComboBoxForm_Product.DisplayMember = "Name"
            Me.ComboBoxForm_Product.DisplayName = ""
            Me.ComboBoxForm_Product.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Product.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_Product.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_Product.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Product.FocusHighlightEnabled = True
            Me.ComboBoxForm_Product.FormattingEnabled = True
            Me.ComboBoxForm_Product.ItemHeight = 14
            Me.ComboBoxForm_Product.Location = New System.Drawing.Point(102, 90)
            Me.ComboBoxForm_Product.Name = "ComboBoxForm_Product"
            Me.ComboBoxForm_Product.PreventEnterBeep = False
            Me.ComboBoxForm_Product.ReadOnly = False
            Me.ComboBoxForm_Product.Size = New System.Drawing.Size(239, 20)
            Me.ComboBoxForm_Product.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Product.TabIndex = 6
            Me.ComboBoxForm_Product.ValueMember = "Code"
            Me.ComboBoxForm_Product.WatermarkText = "Select Product"
            '
            'ButtonForm_Ok
            '
            Me.ButtonForm_Ok.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Ok.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Ok.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Ok.Location = New System.Drawing.Point(185, 168)
            Me.ButtonForm_Ok.Name = "ButtonForm_Ok"
            Me.ButtonForm_Ok.SecurityEnabled = True
            Me.ButtonForm_Ok.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Ok.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Ok.TabIndex = 11
            Me.ButtonForm_Ok.Text = "Ok"
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.Label1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label1.Location = New System.Drawing.Point(12, 116)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(84, 20)
            Me.Label1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label1.TabIndex = 7
            Me.Label1.Text = "Emp Date From:"
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.Label2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label2.Location = New System.Drawing.Point(12, 142)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(84, 20)
            Me.Label2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label2.TabIndex = 9
            Me.Label2.Text = "Emp Date To:"
            '
            'DateTimePickerForm_DateFrom
            '
            Me.DateTimePickerForm_DateFrom.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerForm_DateFrom.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerForm_DateFrom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_DateFrom.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerForm_DateFrom.ButtonDropDown.Visible = True
            Me.DateTimePickerForm_DateFrom.ButtonFreeText.Checked = True
            Me.DateTimePickerForm_DateFrom.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerForm_DateFrom.CustomFormat = ""
            Me.DateTimePickerForm_DateFrom.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerForm_DateFrom.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerForm_DateFrom.FocusHighlightEnabled = True
            Me.DateTimePickerForm_DateFrom.Format = DevComponents.Editors.eDateTimePickerFormat.Short
            Me.DateTimePickerForm_DateFrom.FreeTextEntryMode = True
            Me.DateTimePickerForm_DateFrom.IsPopupCalendarOpen = False
            Me.DateTimePickerForm_DateFrom.Location = New System.Drawing.Point(102, 116)
            Me.DateTimePickerForm_DateFrom.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerForm_DateFrom.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerForm_DateFrom.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_DateFrom.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerForm_DateFrom.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerForm_DateFrom.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerForm_DateFrom.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_DateFrom.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerForm_DateFrom.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerForm_DateFrom.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerForm_DateFrom.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerForm_DateFrom.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_DateFrom.MonthCalendar.DisplayMonth = New Date(2013, 2, 1, 0, 0, 0, 0)
            Me.DateTimePickerForm_DateFrom.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerForm_DateFrom.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerForm_DateFrom.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerForm_DateFrom.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_DateFrom.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerForm_DateFrom.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_DateFrom.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerForm_DateFrom.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerForm_DateFrom.Name = "DateTimePickerForm_DateFrom"
            Me.DateTimePickerForm_DateFrom.ReadOnly = False
            Me.DateTimePickerForm_DateFrom.Size = New System.Drawing.Size(135, 20)
            Me.DateTimePickerForm_DateFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_DateFrom.TabIndex = 8
            '
            'DateTimePickerForm_DateTo
            '
            Me.DateTimePickerForm_DateTo.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerForm_DateTo.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerForm_DateTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_DateTo.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerForm_DateTo.ButtonDropDown.Visible = True
            Me.DateTimePickerForm_DateTo.ButtonFreeText.Checked = True
            Me.DateTimePickerForm_DateTo.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerForm_DateTo.CustomFormat = ""
            Me.DateTimePickerForm_DateTo.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerForm_DateTo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerForm_DateTo.FocusHighlightEnabled = True
            Me.DateTimePickerForm_DateTo.Format = DevComponents.Editors.eDateTimePickerFormat.Short
            Me.DateTimePickerForm_DateTo.FreeTextEntryMode = True
            Me.DateTimePickerForm_DateTo.IsPopupCalendarOpen = False
            Me.DateTimePickerForm_DateTo.Location = New System.Drawing.Point(102, 142)
            Me.DateTimePickerForm_DateTo.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerForm_DateTo.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerForm_DateTo.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_DateTo.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerForm_DateTo.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerForm_DateTo.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerForm_DateTo.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_DateTo.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerForm_DateTo.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerForm_DateTo.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerForm_DateTo.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerForm_DateTo.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_DateTo.MonthCalendar.DisplayMonth = New Date(2013, 2, 1, 0, 0, 0, 0)
            Me.DateTimePickerForm_DateTo.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerForm_DateTo.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerForm_DateTo.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerForm_DateTo.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_DateTo.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerForm_DateTo.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_DateTo.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerForm_DateTo.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerForm_DateTo.Name = "DateTimePickerForm_DateTo"
            Me.DateTimePickerForm_DateTo.ReadOnly = False
            Me.DateTimePickerForm_DateTo.Size = New System.Drawing.Size(135, 20)
            Me.DateTimePickerForm_DateTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_DateTo.TabIndex = 10
            '
            'FeeFlagUpdateDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(353, 200)
            Me.Controls.Add(Me.DateTimePickerForm_DateTo)
            Me.Controls.Add(Me.DateTimePickerForm_DateFrom)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.ButtonForm_Ok)
            Me.Controls.Add(Me.ComboBoxForm_Product)
            Me.Controls.Add(Me.ComboBoxForm_Division)
            Me.Controls.Add(Me.ComboBoxForm_Client)
            Me.Controls.Add(Me.LabelForm_Product)
            Me.Controls.Add(Me.LabelForm_Division)
            Me.Controls.Add(Me.LabelForm_Select)
            Me.Controls.Add(Me.LabelForm_Client)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "FeeFlagUpdateDialog"
            Me.Text = "Fee Flag Update"
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerForm_DateFrom, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerForm_DateTo, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_Client As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Select As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Division As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Product As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_Client As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxForm_Division As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxForm_Product As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ButtonForm_Ok As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents Label1 As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents Label2 As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerForm_DateFrom As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerForm_DateTo As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
    End Class

End Namespace