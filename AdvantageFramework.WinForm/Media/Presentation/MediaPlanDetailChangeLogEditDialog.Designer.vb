Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class MediaPlanDetailChangeLogEditDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaPlanDetailChangeLogEditDialog))
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Add = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ComboBoxForm_Estimate = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_Date = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Estimate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxForm_Comment = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.TextBoxComment_Comment = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.ButtonForm_Update = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DateTimePickerForm_Date = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            CType(Me.GroupBoxForm_Comment, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxForm_Comment.SuspendLayout()
            CType(Me.DateTimePickerForm_Date, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(330, 389)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 7
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ButtonForm_Add
            '
            Me.ButtonForm_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Add.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Add.Location = New System.Drawing.Point(249, 389)
            Me.ButtonForm_Add.Name = "ButtonForm_Add"
            Me.ButtonForm_Add.SecurityEnabled = True
            Me.ButtonForm_Add.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Add.TabIndex = 5
            Me.ButtonForm_Add.Text = "Add"
            '
            'ComboBoxForm_Estimate
            '
            Me.ComboBoxForm_Estimate.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Estimate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_Estimate.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Estimate.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Estimate.AutoFindItemInDataSource = False
            Me.ComboBoxForm_Estimate.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Estimate.BookmarkingEnabled = False
            Me.ComboBoxForm_Estimate.ClientCode = ""
            Me.ComboBoxForm_Estimate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.[Default]
            Me.ComboBoxForm_Estimate.DisableMouseWheel = False
            Me.ComboBoxForm_Estimate.DisplayMember = "Name"
            Me.ComboBoxForm_Estimate.DisplayName = ""
            Me.ComboBoxForm_Estimate.DivisionCode = ""
            Me.ComboBoxForm_Estimate.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Estimate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_Estimate.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_Estimate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Estimate.FocusHighlightEnabled = True
            Me.ComboBoxForm_Estimate.FormattingEnabled = True
            Me.ComboBoxForm_Estimate.ItemHeight = 14
            Me.ComboBoxForm_Estimate.Location = New System.Drawing.Point(85, 12)
            Me.ComboBoxForm_Estimate.Name = "ComboBoxForm_Estimate"
            Me.ComboBoxForm_Estimate.PreventEnterBeep = False
            Me.ComboBoxForm_Estimate.ReadOnly = False
            Me.ComboBoxForm_Estimate.SecurityEnabled = True
            Me.ComboBoxForm_Estimate.Size = New System.Drawing.Size(320, 20)
            Me.ComboBoxForm_Estimate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Estimate.TabIndex = 1
            Me.ComboBoxForm_Estimate.ValueMember = "ID"
            '
            'LabelForm_Date
            '
            Me.LabelForm_Date.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Date.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Date.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_Date.Name = "LabelForm_Date"
            Me.LabelForm_Date.Size = New System.Drawing.Size(67, 20)
            Me.LabelForm_Date.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Date.TabIndex = 2
            Me.LabelForm_Date.Text = "Date:"
            '
            'LabelForm_Estimate
            '
            Me.LabelForm_Estimate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Estimate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Estimate.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_Estimate.Name = "LabelForm_Estimate"
            Me.LabelForm_Estimate.Size = New System.Drawing.Size(67, 20)
            Me.LabelForm_Estimate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Estimate.TabIndex = 0
            Me.LabelForm_Estimate.Text = "Estimate:"
            '
            'GroupBoxForm_Comment
            '
            Me.GroupBoxForm_Comment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxForm_Comment.Controls.Add(Me.TextBoxComment_Comment)
            Me.GroupBoxForm_Comment.Location = New System.Drawing.Point(12, 64)
            Me.GroupBoxForm_Comment.Name = "GroupBoxForm_Comment"
            Me.GroupBoxForm_Comment.Size = New System.Drawing.Size(393, 319)
            Me.GroupBoxForm_Comment.TabIndex = 4
            Me.GroupBoxForm_Comment.Text = "Comment"
            '
            'TextBoxComment_Comment
            '
            Me.TextBoxComment_Comment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxComment_Comment.Border.Class = "TextBoxBorder"
            Me.TextBoxComment_Comment.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxComment_Comment.CheckSpellingOnValidate = False
            Me.TextBoxComment_Comment.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxComment_Comment.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxComment_Comment.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxComment_Comment.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxComment_Comment.FocusHighlightEnabled = True
            Me.TextBoxComment_Comment.Location = New System.Drawing.Point(5, 24)
            Me.TextBoxComment_Comment.MaxFileSize = CType(0, Long)
            Me.TextBoxComment_Comment.Multiline = True
            Me.TextBoxComment_Comment.Name = "TextBoxComment_Comment"
            Me.TextBoxComment_Comment.SecurityEnabled = True
            Me.TextBoxComment_Comment.ShowSpellCheckCompleteMessage = False
            Me.TextBoxComment_Comment.Size = New System.Drawing.Size(383, 290)
            Me.TextBoxComment_Comment.StartingFolderName = Nothing
            Me.TextBoxComment_Comment.TabIndex = 0
            Me.TextBoxComment_Comment.TabOnEnter = False
            '
            'ButtonForm_Update
            '
            Me.ButtonForm_Update.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Update.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Update.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Update.Location = New System.Drawing.Point(249, 389)
            Me.ButtonForm_Update.Name = "ButtonForm_Update"
            Me.ButtonForm_Update.SecurityEnabled = True
            Me.ButtonForm_Update.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Update.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Update.TabIndex = 6
            Me.ButtonForm_Update.Text = "Update"
            '
            'DateTimePickerForm_Date
            '
            Me.DateTimePickerForm_Date.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerForm_Date.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerForm_Date.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_Date.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerForm_Date.ButtonDropDown.Visible = True
            Me.DateTimePickerForm_Date.ButtonFreeText.Checked = True
            Me.DateTimePickerForm_Date.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePickerForm_Date.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePickerForm_Date.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerForm_Date.DisplayName = ""
            Me.DateTimePickerForm_Date.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerForm_Date.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerForm_Date.FocusHighlightEnabled = True
            Me.DateTimePickerForm_Date.FreeTextEntryMode = True
            Me.DateTimePickerForm_Date.IsPopupCalendarOpen = False
            Me.DateTimePickerForm_Date.Location = New System.Drawing.Point(85, 38)
            Me.DateTimePickerForm_Date.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerForm_Date.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerForm_Date.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_Date.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerForm_Date.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerForm_Date.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerForm_Date.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_Date.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerForm_Date.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerForm_Date.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerForm_Date.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerForm_Date.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_Date.MonthCalendar.DisplayMonth = New Date(2014, 8, 1, 0, 0, 0, 0)
            Me.DateTimePickerForm_Date.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerForm_Date.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerForm_Date.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerForm_Date.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_Date.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerForm_Date.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_Date.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerForm_Date.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerForm_Date.Name = "DateTimePickerForm_Date"
            Me.DateTimePickerForm_Date.ReadOnly = False
            Me.DateTimePickerForm_Date.Size = New System.Drawing.Size(100, 20)
            Me.DateTimePickerForm_Date.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_Date.TabIndex = 3
            Me.DateTimePickerForm_Date.Value = New Date(2014, 8, 19, 9, 14, 37, 465)
            '
            'MediaPlanDetailChangeLogEditDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(417, 421)
            Me.Controls.Add(Me.DateTimePickerForm_Date)
            Me.Controls.Add(Me.GroupBoxForm_Comment)
            Me.Controls.Add(Me.ComboBoxForm_Estimate)
            Me.Controls.Add(Me.LabelForm_Date)
            Me.Controls.Add(Me.LabelForm_Estimate)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.ButtonForm_Add)
            Me.Controls.Add(Me.ButtonForm_Update)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaPlanDetailChangeLogEditDialog"
            Me.Text = "Change Log"
            CType(Me.GroupBoxForm_Comment, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxForm_Comment.ResumeLayout(False)
            CType(Me.DateTimePickerForm_Date, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Add As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ComboBoxForm_Estimate As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_Date As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Estimate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxForm_Comment As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents TextBoxComment_Comment As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents ButtonForm_Update As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DateTimePickerForm_Date As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
    End Class

End Namespace
