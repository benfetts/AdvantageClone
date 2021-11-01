Namespace Reporting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AROpenAgedInitialLoadingDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AROpenAgedInitialLoadingDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ComboBoxForm_PeriodCutoff = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_PeriodCutoff = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxForm_IncludeDetails = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelForm_AgingDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_AgingOption = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.RadioButtonForm_Invoice = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonForm_InvoiceDueDate = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.DateTimePickerAgingDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelForm_RecordSource = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_RecordSource = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            CType(Me.DateTimePickerAgingDate, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(162, 145)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 10
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(243, 145)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 11
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ComboBoxForm_PeriodCutoff
            '
            Me.ComboBoxForm_PeriodCutoff.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_PeriodCutoff.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_PeriodCutoff.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_PeriodCutoff.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_PeriodCutoff.AutoFindItemInDataSource = False
            Me.ComboBoxForm_PeriodCutoff.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_PeriodCutoff.BookmarkingEnabled = False
            Me.ComboBoxForm_PeriodCutoff.ClientCode = ""
            Me.ComboBoxForm_PeriodCutoff.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.PostPeriod
            Me.ComboBoxForm_PeriodCutoff.DisableMouseWheel = False
            Me.ComboBoxForm_PeriodCutoff.DisplayMember = "Description"
            Me.ComboBoxForm_PeriodCutoff.DisplayName = ""
            Me.ComboBoxForm_PeriodCutoff.DivisionCode = ""
            Me.ComboBoxForm_PeriodCutoff.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_PeriodCutoff.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_PeriodCutoff.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_PeriodCutoff.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_PeriodCutoff.FocusHighlightEnabled = True
            Me.ComboBoxForm_PeriodCutoff.FormattingEnabled = True
            Me.ComboBoxForm_PeriodCutoff.ItemHeight = 14
            Me.ComboBoxForm_PeriodCutoff.Location = New System.Drawing.Point(124, 12)
            Me.ComboBoxForm_PeriodCutoff.Name = "ComboBoxForm_PeriodCutoff"
            Me.ComboBoxForm_PeriodCutoff.ReadOnly = False
            Me.ComboBoxForm_PeriodCutoff.SecurityEnabled = True
            Me.ComboBoxForm_PeriodCutoff.Size = New System.Drawing.Size(194, 20)
            Me.ComboBoxForm_PeriodCutoff.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_PeriodCutoff.TabIndex = 1
            Me.ComboBoxForm_PeriodCutoff.TabOnEnter = True
            Me.ComboBoxForm_PeriodCutoff.ValueMember = "Code"
            Me.ComboBoxForm_PeriodCutoff.WatermarkText = "Select Post Period"
            '
            'LabelForm_PeriodCutoff
            '
            Me.LabelForm_PeriodCutoff.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_PeriodCutoff.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_PeriodCutoff.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_PeriodCutoff.Name = "LabelForm_PeriodCutoff"
            Me.LabelForm_PeriodCutoff.Size = New System.Drawing.Size(106, 20)
            Me.LabelForm_PeriodCutoff.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_PeriodCutoff.TabIndex = 0
            Me.LabelForm_PeriodCutoff.Text = "Period Cutoff:"
            '
            'CheckBoxForm_IncludeDetails
            '
            '
            '
            '
            Me.CheckBoxForm_IncludeDetails.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_IncludeDetails.CheckValue = 0
            Me.CheckBoxForm_IncludeDetails.CheckValueChecked = 1
            Me.CheckBoxForm_IncludeDetails.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_IncludeDetails.CheckValueUnchecked = 0
            Me.CheckBoxForm_IncludeDetails.ChildControls = CType(resources.GetObject("CheckBoxForm_IncludeDetails.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_IncludeDetails.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_IncludeDetails.Location = New System.Drawing.Point(124, 116)
            Me.CheckBoxForm_IncludeDetails.Name = "CheckBoxForm_IncludeDetails"
            Me.CheckBoxForm_IncludeDetails.OldestSibling = Nothing
            Me.CheckBoxForm_IncludeDetails.SecurityEnabled = True
            Me.CheckBoxForm_IncludeDetails.SiblingControls = CType(resources.GetObject("CheckBoxForm_IncludeDetails.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_IncludeDetails.Size = New System.Drawing.Size(113, 20)
            Me.CheckBoxForm_IncludeDetails.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_IncludeDetails.TabIndex = 9
            Me.CheckBoxForm_IncludeDetails.TabOnEnter = True
            Me.CheckBoxForm_IncludeDetails.Text = "Include Details"
            '
            'LabelForm_AgingDate
            '
            Me.LabelForm_AgingDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_AgingDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_AgingDate.Location = New System.Drawing.Point(12, 64)
            Me.LabelForm_AgingDate.Name = "LabelForm_AgingDate"
            Me.LabelForm_AgingDate.Size = New System.Drawing.Size(106, 20)
            Me.LabelForm_AgingDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_AgingDate.TabIndex = 4
            Me.LabelForm_AgingDate.Text = "Aging Date:"
            '
            'LabelForm_AgingOption
            '
            Me.LabelForm_AgingOption.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_AgingOption.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_AgingOption.Location = New System.Drawing.Point(12, 90)
            Me.LabelForm_AgingOption.Name = "LabelForm_AgingOption"
            Me.LabelForm_AgingOption.Size = New System.Drawing.Size(106, 20)
            Me.LabelForm_AgingOption.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_AgingOption.TabIndex = 6
            Me.LabelForm_AgingOption.Text = "Aging Option:"
            '
            'RadioButtonForm_Invoice
            '
            Me.RadioButtonForm_Invoice.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonForm_Invoice.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonForm_Invoice.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonForm_Invoice.Checked = True
            Me.RadioButtonForm_Invoice.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonForm_Invoice.CheckValue = "Y"
            Me.RadioButtonForm_Invoice.Location = New System.Drawing.Point(124, 90)
            Me.RadioButtonForm_Invoice.Name = "RadioButtonForm_Invoice"
            Me.RadioButtonForm_Invoice.SecurityEnabled = True
            Me.RadioButtonForm_Invoice.Size = New System.Drawing.Size(68, 20)
            Me.RadioButtonForm_Invoice.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonForm_Invoice.TabIndex = 7
            Me.RadioButtonForm_Invoice.TabOnEnter = True
            Me.RadioButtonForm_Invoice.Text = "Invoice"
            '
            'RadioButtonForm_InvoiceDueDate
            '
            Me.RadioButtonForm_InvoiceDueDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonForm_InvoiceDueDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonForm_InvoiceDueDate.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonForm_InvoiceDueDate.Location = New System.Drawing.Point(198, 90)
            Me.RadioButtonForm_InvoiceDueDate.Name = "RadioButtonForm_InvoiceDueDate"
            Me.RadioButtonForm_InvoiceDueDate.SecurityEnabled = True
            Me.RadioButtonForm_InvoiceDueDate.Size = New System.Drawing.Size(120, 20)
            Me.RadioButtonForm_InvoiceDueDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonForm_InvoiceDueDate.TabIndex = 8
            Me.RadioButtonForm_InvoiceDueDate.TabOnEnter = True
            Me.RadioButtonForm_InvoiceDueDate.TabStop = False
            Me.RadioButtonForm_InvoiceDueDate.Text = "Invoice Due Date"
            '
            'DateTimePickerAgingDate
            '
            Me.DateTimePickerAgingDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerAgingDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerAgingDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerAgingDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerAgingDate.ButtonDropDown.Visible = True
            Me.DateTimePickerAgingDate.ButtonFreeText.Checked = True
            Me.DateTimePickerAgingDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerAgingDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerAgingDate.DisplayName = ""
            Me.DateTimePickerAgingDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerAgingDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerAgingDate.FocusHighlightEnabled = True
            Me.DateTimePickerAgingDate.FreeTextEntryMode = True
            Me.DateTimePickerAgingDate.IsPopupCalendarOpen = False
            Me.DateTimePickerAgingDate.Location = New System.Drawing.Point(124, 64)
            Me.DateTimePickerAgingDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerAgingDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerAgingDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerAgingDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerAgingDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerAgingDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerAgingDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerAgingDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerAgingDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerAgingDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerAgingDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerAgingDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerAgingDate.MonthCalendar.DisplayMonth = New Date(2013, 4, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerAgingDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerAgingDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerAgingDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerAgingDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerAgingDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerAgingDate.Name = "DateTimePickerAgingDate"
            Me.DateTimePickerAgingDate.ReadOnly = False
            Me.DateTimePickerAgingDate.Size = New System.Drawing.Size(194, 20)
            Me.DateTimePickerAgingDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerAgingDate.TabIndex = 5
            Me.DateTimePickerAgingDate.TabOnEnter = True
            Me.DateTimePickerAgingDate.Value = New Date(2013, 4, 16, 10, 23, 19, 434)
            '
            'LabelForm_RecordSource
            '
            Me.LabelForm_RecordSource.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_RecordSource.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_RecordSource.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_RecordSource.Name = "LabelForm_RecordSource"
            Me.LabelForm_RecordSource.Size = New System.Drawing.Size(106, 20)
            Me.LabelForm_RecordSource.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_RecordSource.TabIndex = 2
            Me.LabelForm_RecordSource.Text = "Record Source:"
            '
            'ComboBoxForm_RecordSource
            '
            Me.ComboBoxForm_RecordSource.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_RecordSource.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_RecordSource.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_RecordSource.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_RecordSource.AutoFindItemInDataSource = False
            Me.ComboBoxForm_RecordSource.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_RecordSource.BookmarkingEnabled = False
            Me.ComboBoxForm_RecordSource.ClientCode = ""
            Me.ComboBoxForm_RecordSource.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.RecordSource
            Me.ComboBoxForm_RecordSource.DisableMouseWheel = False
            Me.ComboBoxForm_RecordSource.DisplayMember = "Name"
            Me.ComboBoxForm_RecordSource.DisplayName = ""
            Me.ComboBoxForm_RecordSource.DivisionCode = ""
            Me.ComboBoxForm_RecordSource.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_RecordSource.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_RecordSource.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_RecordSource.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_RecordSource.FocusHighlightEnabled = True
            Me.ComboBoxForm_RecordSource.FormattingEnabled = True
            Me.ComboBoxForm_RecordSource.ItemHeight = 14
            Me.ComboBoxForm_RecordSource.Location = New System.Drawing.Point(124, 38)
            Me.ComboBoxForm_RecordSource.Name = "ComboBoxForm_RecordSource"
            Me.ComboBoxForm_RecordSource.ReadOnly = False
            Me.ComboBoxForm_RecordSource.SecurityEnabled = True
            Me.ComboBoxForm_RecordSource.Size = New System.Drawing.Size(194, 20)
            Me.ComboBoxForm_RecordSource.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_RecordSource.TabIndex = 3
            Me.ComboBoxForm_RecordSource.TabOnEnter = True
            Me.ComboBoxForm_RecordSource.ValueMember = "ID"
            Me.ComboBoxForm_RecordSource.WatermarkText = "Select Record Source"
            '
            'AROpenAgedInitialLoadingDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(330, 177)
            Me.Controls.Add(Me.LabelForm_RecordSource)
            Me.Controls.Add(Me.ComboBoxForm_RecordSource)
            Me.Controls.Add(Me.DateTimePickerAgingDate)
            Me.Controls.Add(Me.RadioButtonForm_Invoice)
            Me.Controls.Add(Me.RadioButtonForm_InvoiceDueDate)
            Me.Controls.Add(Me.LabelForm_AgingOption)
            Me.Controls.Add(Me.LabelForm_AgingDate)
            Me.Controls.Add(Me.CheckBoxForm_IncludeDetails)
            Me.Controls.Add(Me.LabelForm_PeriodCutoff)
            Me.Controls.Add(Me.ComboBoxForm_PeriodCutoff)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "AROpenAgedInitialLoadingDialog"
            Me.Text = "AR Open Aged Initial Criteria"
            CType(Me.DateTimePickerAgingDate, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ComboBoxForm_PeriodCutoff As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_PeriodCutoff As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxForm_IncludeDetails As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelForm_AgingDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_AgingOption As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents RadioButtonForm_Invoice As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonForm_InvoiceDueDate As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents DateTimePickerAgingDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents LabelForm_RecordSource As WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_RecordSource As WinForm.Presentation.Controls.ComboBox
    End Class

End Namespace