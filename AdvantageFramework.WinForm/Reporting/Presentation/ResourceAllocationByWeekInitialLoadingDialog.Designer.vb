Namespace Reporting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class ResourceAllocationByWeekInitialLoadingDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ResourceAllocationByWeekInitialLoadingDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_From = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.Label1 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DateTimePickerStartingWeek = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.ComboBox_Week = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_Type = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.RadioButtonForm_Detail = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonForm_Summary = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            CType(Me.DateTimePickerStartingWeek, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(298, 117)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 11
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(379, 117)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 12
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'LabelForm_From
            '
            Me.LabelForm_From.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_From.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_From.Location = New System.Drawing.Point(10, 65)
            Me.LabelForm_From.Name = "LabelForm_From"
            Me.LabelForm_From.Size = New System.Drawing.Size(78, 20)
            Me.LabelForm_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_From.TabIndex = 2
            Me.LabelForm_From.Text = "No. of Weeks:"
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.Label1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label1.Location = New System.Drawing.Point(10, 39)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(78, 20)
            Me.Label1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label1.TabIndex = 13
            Me.Label1.Text = "Starting Week:"
            '
            'DateTimePickerStartingWeek
            '
            Me.DateTimePickerStartingWeek.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerStartingWeek.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerStartingWeek.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerStartingWeek.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerStartingWeek.ButtonDropDown.Visible = True
            Me.DateTimePickerStartingWeek.ButtonFreeText.Checked = True
            Me.DateTimePickerStartingWeek.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerStartingWeek.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerStartingWeek.DisplayName = ""
            Me.DateTimePickerStartingWeek.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerStartingWeek.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerStartingWeek.FocusHighlightEnabled = True
            Me.DateTimePickerStartingWeek.FreeTextEntryMode = True
            Me.DateTimePickerStartingWeek.IsPopupCalendarOpen = False
            Me.DateTimePickerStartingWeek.Location = New System.Drawing.Point(94, 39)
            Me.DateTimePickerStartingWeek.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerStartingWeek.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerStartingWeek.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.DateTimePickerStartingWeek.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerStartingWeek.MonthCalendar.DisplayMonth = New Date(2018, 2, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerStartingWeek.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerStartingWeek.Name = "DateTimePickerStartingWeek"
            Me.DateTimePickerStartingWeek.ReadOnly = False
            Me.DateTimePickerStartingWeek.Size = New System.Drawing.Size(100, 20)
            Me.DateTimePickerStartingWeek.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerStartingWeek.TabIndex = 46
            Me.DateTimePickerStartingWeek.TabOnEnter = True
            Me.DateTimePickerStartingWeek.Value = New Date(2018, 2, 8, 10, 5, 42, 546)
            '
            'ComboBox_Week
            '
            Me.ComboBox_Week.AddInactiveItemsOnSelectedValue = False
            Me.ComboBox_Week.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBox_Week.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBox_Week.AutoFindItemInDataSource = False
            Me.ComboBox_Week.AutoSelectSingleItemDatasource = False
            Me.ComboBox_Week.BookmarkingEnabled = False
            Me.ComboBox_Week.ClientCode = ""
            Me.ComboBox_Week.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumDataTable
            Me.ComboBox_Week.DisableMouseWheel = False
            Me.ComboBox_Week.DisplayMember = "Week"
            Me.ComboBox_Week.DisplayName = ""
            Me.ComboBox_Week.DivisionCode = ""
            Me.ComboBox_Week.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBox_Week.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBox_Week.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBox_Week.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBox_Week.FocusHighlightEnabled = True
            Me.ComboBox_Week.FormattingEnabled = True
            Me.ComboBox_Week.ItemHeight = 14
            Me.ComboBox_Week.Location = New System.Drawing.Point(94, 65)
            Me.ComboBox_Week.Name = "ComboBox_Week"
            Me.ComboBox_Week.ReadOnly = False
            Me.ComboBox_Week.SecurityEnabled = True
            Me.ComboBox_Week.Size = New System.Drawing.Size(100, 20)
            Me.ComboBox_Week.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBox_Week.TabIndex = 47
            Me.ComboBox_Week.TabOnEnter = True
            Me.ComboBox_Week.ValueMember = "Value"
            Me.ComboBox_Week.WatermarkText = "Select"
            '
            'LabelForm_Type
            '
            Me.LabelForm_Type.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Type.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Type.Location = New System.Drawing.Point(10, 12)
            Me.LabelForm_Type.Name = "LabelForm_Type"
            Me.LabelForm_Type.Size = New System.Drawing.Size(78, 20)
            Me.LabelForm_Type.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Type.TabIndex = 48
            Me.LabelForm_Type.Text = "View:"
            '
            'RadioButtonForm_Detail
            '
            Me.RadioButtonForm_Detail.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonForm_Detail.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonForm_Detail.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonForm_Detail.Location = New System.Drawing.Point(187, 12)
            Me.RadioButtonForm_Detail.Name = "RadioButtonForm_Detail"
            Me.RadioButtonForm_Detail.SecurityEnabled = True
            Me.RadioButtonForm_Detail.Size = New System.Drawing.Size(143, 20)
            Me.RadioButtonForm_Detail.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonForm_Detail.TabIndex = 50
            Me.RadioButtonForm_Detail.TabOnEnter = True
            Me.RadioButtonForm_Detail.TabStop = False
            Me.RadioButtonForm_Detail.Text = "Detail"
            '
            'RadioButtonForm_Summary
            '
            Me.RadioButtonForm_Summary.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonForm_Summary.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonForm_Summary.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonForm_Summary.Checked = True
            Me.RadioButtonForm_Summary.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonForm_Summary.CheckValue = "Y"
            Me.RadioButtonForm_Summary.Location = New System.Drawing.Point(94, 12)
            Me.RadioButtonForm_Summary.Name = "RadioButtonForm_Summary"
            Me.RadioButtonForm_Summary.SecurityEnabled = True
            Me.RadioButtonForm_Summary.Size = New System.Drawing.Size(87, 20)
            Me.RadioButtonForm_Summary.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonForm_Summary.TabIndex = 49
            Me.RadioButtonForm_Summary.TabOnEnter = True
            Me.RadioButtonForm_Summary.Text = "Summary"
            '
            'ResourceAllocationByWeekInitialLoadingDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(466, 149)
            Me.Controls.Add(Me.LabelForm_Type)
            Me.Controls.Add(Me.RadioButtonForm_Detail)
            Me.Controls.Add(Me.RadioButtonForm_Summary)
            Me.Controls.Add(Me.ComboBox_Week)
            Me.Controls.Add(Me.DateTimePickerStartingWeek)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.LabelForm_From)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ResourceAllocationByWeekInitialLoadingDialog"
            Me.Text = "Set Initial Criteria"
            CType(Me.DateTimePickerStartingWeek, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_From As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents Label1 As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerStartingWeek As WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents ComboBox_Week As WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_Type As WinForm.Presentation.Controls.Label
        Friend WithEvents RadioButtonForm_Detail As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonForm_Summary As WinForm.Presentation.Controls.RadioButtonControl
    End Class

End Namespace