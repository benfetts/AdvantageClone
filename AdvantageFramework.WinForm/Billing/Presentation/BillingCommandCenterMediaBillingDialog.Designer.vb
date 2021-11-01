Namespace Billing.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class BillingCommandCenterMediaBillingDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BillingCommandCenterMediaBillingDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_PostingPeriod = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DateTimePickerForm_InvoiceDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelForm_InvoiceDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_PostingPeriod = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            CType(Me.DateTimePickerForm_InvoiceDate, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(130, 71)
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
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(211, 71)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 5
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'LabelForm_PostingPeriod
            '
            Me.LabelForm_PostingPeriod.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_PostingPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_PostingPeriod.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_PostingPeriod.Name = "LabelForm_PostingPeriod"
            Me.LabelForm_PostingPeriod.Size = New System.Drawing.Size(88, 20)
            Me.LabelForm_PostingPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_PostingPeriod.TabIndex = 2
            Me.LabelForm_PostingPeriod.Text = "Posting Period:"
            '
            'DateTimePickerForm_InvoiceDate
            '
            Me.DateTimePickerForm_InvoiceDate.AllowEmptyState = False
            Me.DateTimePickerForm_InvoiceDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerForm_InvoiceDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerForm_InvoiceDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_InvoiceDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerForm_InvoiceDate.ButtonDropDown.Visible = True
            Me.DateTimePickerForm_InvoiceDate.ButtonFreeText.Checked = True
            Me.DateTimePickerForm_InvoiceDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePickerForm_InvoiceDate.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePickerForm_InvoiceDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerForm_InvoiceDate.DisplayName = ""
            Me.DateTimePickerForm_InvoiceDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerForm_InvoiceDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerForm_InvoiceDate.FocusHighlightEnabled = True
            Me.DateTimePickerForm_InvoiceDate.FreeTextEntryMode = True
            Me.DateTimePickerForm_InvoiceDate.IsPopupCalendarOpen = False
            Me.DateTimePickerForm_InvoiceDate.Location = New System.Drawing.Point(106, 12)
            Me.DateTimePickerForm_InvoiceDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerForm_InvoiceDate.MinDate = New Date(1970, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerForm_InvoiceDate.Name = "DateTimePickerForm_InvoiceDate"
            Me.DateTimePickerForm_InvoiceDate.ReadOnly = False
            Me.DateTimePickerForm_InvoiceDate.Size = New System.Drawing.Size(180, 20)
            Me.DateTimePickerForm_InvoiceDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_InvoiceDate.TabIndex = 1
            '
            'LabelForm_InvoiceDate
            '
            Me.LabelForm_InvoiceDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_InvoiceDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_InvoiceDate.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_InvoiceDate.Name = "LabelForm_InvoiceDate"
            Me.LabelForm_InvoiceDate.Size = New System.Drawing.Size(88, 20)
            Me.LabelForm_InvoiceDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_InvoiceDate.TabIndex = 0
            Me.LabelForm_InvoiceDate.Text = "Invoice Date:"
            '
            'ComboBoxForm_PostingPeriod
            '
            Me.ComboBoxForm_PostingPeriod.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_PostingPeriod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_PostingPeriod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_PostingPeriod.AutoFindItemInDataSource = False
            Me.ComboBoxForm_PostingPeriod.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_PostingPeriod.BookmarkingEnabled = False
            Me.ComboBoxForm_PostingPeriod.ClientCode = ""
            Me.ComboBoxForm_PostingPeriod.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.PostPeriod
            Me.ComboBoxForm_PostingPeriod.DisableMouseWheel = True
            Me.ComboBoxForm_PostingPeriod.DisplayMember = "Description"
            Me.ComboBoxForm_PostingPeriod.DisplayName = ""
            Me.ComboBoxForm_PostingPeriod.DivisionCode = ""
            Me.ComboBoxForm_PostingPeriod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_PostingPeriod.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_PostingPeriod.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_PostingPeriod.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_PostingPeriod.FocusHighlightEnabled = True
            Me.ComboBoxForm_PostingPeriod.FormattingEnabled = True
            Me.ComboBoxForm_PostingPeriod.ItemHeight = 14
            Me.ComboBoxForm_PostingPeriod.Location = New System.Drawing.Point(106, 38)
            Me.ComboBoxForm_PostingPeriod.Name = "ComboBoxForm_PostingPeriod"
            Me.ComboBoxForm_PostingPeriod.PreventEnterBeep = False
            Me.ComboBoxForm_PostingPeriod.ReadOnly = False
            Me.ComboBoxForm_PostingPeriod.SecurityEnabled = True
            Me.ComboBoxForm_PostingPeriod.Size = New System.Drawing.Size(180, 20)
            Me.ComboBoxForm_PostingPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_PostingPeriod.TabIndex = 3
            Me.ComboBoxForm_PostingPeriod.ValueMember = "Code"
            Me.ComboBoxForm_PostingPeriod.WatermarkText = "Select Post Period"
            '
            'BillingCommandCenterMediaBillingDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(298, 103)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.LabelForm_InvoiceDate)
            Me.Controls.Add(Me.LabelForm_PostingPeriod)
            Me.Controls.Add(Me.DateTimePickerForm_InvoiceDate)
            Me.Controls.Add(Me.ComboBoxForm_PostingPeriod)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "BillingCommandCenterMediaBillingDialog"
            Me.Text = "Media Billing Information"
            CType(Me.DateTimePickerForm_InvoiceDate, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_PostingPeriod As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerForm_InvoiceDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents LabelForm_InvoiceDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_PostingPeriod As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
    End Class

End Namespace