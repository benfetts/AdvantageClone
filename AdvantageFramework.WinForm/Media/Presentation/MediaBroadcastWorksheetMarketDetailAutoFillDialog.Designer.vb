Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaBroadcastWorksheetMarketDetailAutoFillDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaBroadcastWorksheetMarketDetailAutoFillDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.LabelForm_Daypart = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.ComboBoxForm_Daypart = New AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox()
            Me.NumericInputForm_Length = New AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput()
            Me.LabelForm_Length = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelForm_Days = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.TextBoxForm_Days = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.LabelForm_StartTime = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.TextBoxForm_StartTime = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.LabelForm_EndTime = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.TextBoxForm_EndTime = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.LabelForm_Comments = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.TextBoxForm_Comments = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.CheckBoxForm_AddedValue = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.RadioButtonControlForm_UpdateFromSelected = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlForm_FromBlank = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.ButtonForm_SelectLast = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_SelectNext = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_SelectPrevious = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_SelectFirst = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.CheckBoxForm_DaypartClear = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_LengthClear = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_DaysClear = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_StartTimeClear = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_EndTimeClear = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_CommentsClear = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            CType(Me.NumericInputForm_Length.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(336, 220)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 25
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(417, 220)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 26
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'LabelForm_Daypart
            '
            Me.LabelForm_Daypart.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Daypart.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Daypart.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_Daypart.Name = "LabelForm_Daypart"
            Me.LabelForm_Daypart.Size = New System.Drawing.Size(120, 20)
            Me.LabelForm_Daypart.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Daypart.TabIndex = 2
            Me.LabelForm_Daypart.Text = "Daypart:"
            '
            'ComboBoxForm_Daypart
            '
            Me.ComboBoxForm_Daypart.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Daypart.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_Daypart.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Daypart.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Daypart.AutoFindItemInDataSource = False
            Me.ComboBoxForm_Daypart.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Daypart.BookmarkingEnabled = False
            Me.ComboBoxForm_Daypart.DisableMouseWheel = False
            Me.ComboBoxForm_Daypart.DisplayName = ""
            Me.ComboBoxForm_Daypart.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Daypart.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_Daypart.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_Daypart.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Daypart.FocusHighlightEnabled = True
            Me.ComboBoxForm_Daypart.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxForm_Daypart.FormattingEnabled = True
            Me.ComboBoxForm_Daypart.ItemHeight = 14
            Me.ComboBoxForm_Daypart.Location = New System.Drawing.Point(138, 38)
            Me.ComboBoxForm_Daypart.Name = "ComboBoxForm_Daypart"
            Me.ComboBoxForm_Daypart.ReadOnly = False
            Me.ComboBoxForm_Daypart.SecurityEnabled = True
            Me.ComboBoxForm_Daypart.Size = New System.Drawing.Size(294, 20)
            Me.ComboBoxForm_Daypart.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Daypart.TabIndex = 3
            Me.ComboBoxForm_Daypart.TabOnEnter = True
            Me.ComboBoxForm_Daypart.WatermarkText = "Select Client"
            '
            'NumericInputForm_Length
            '
            Me.NumericInputForm_Length.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputForm_Length.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.NumericInputForm_Length.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput.Type.[Short]
            Me.NumericInputForm_Length.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputForm_Length.EnterMoveNextControl = True
            Me.NumericInputForm_Length.Location = New System.Drawing.Point(138, 64)
            Me.NumericInputForm_Length.Name = "NumericInputForm_Length"
            Me.NumericInputForm_Length.Properties.AllowMouseWheel = False
            Me.NumericInputForm_Length.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputForm_Length.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputForm_Length.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputForm_Length.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputForm_Length.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_Length.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputForm_Length.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_Length.Properties.IsFloatValue = False
            Me.NumericInputForm_Length.Properties.Mask.EditMask = "f0"
            Me.NumericInputForm_Length.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputForm_Length.Properties.MaxValue = New Decimal(New Integer() {32767, 0, 0, 0})
            Me.NumericInputForm_Length.Properties.MinValue = New Decimal(New Integer() {32768, 0, 0, -2147483648})
            Me.NumericInputForm_Length.SecurityEnabled = True
            Me.NumericInputForm_Length.Size = New System.Drawing.Size(294, 20)
            Me.NumericInputForm_Length.TabIndex = 6
            '
            'LabelForm_Length
            '
            Me.LabelForm_Length.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Length.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Length.Location = New System.Drawing.Point(12, 64)
            Me.LabelForm_Length.Name = "LabelForm_Length"
            Me.LabelForm_Length.Size = New System.Drawing.Size(120, 20)
            Me.LabelForm_Length.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Length.TabIndex = 5
            Me.LabelForm_Length.Text = "Length:"
            '
            'LabelForm_Days
            '
            Me.LabelForm_Days.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Days.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Days.Location = New System.Drawing.Point(12, 90)
            Me.LabelForm_Days.Name = "LabelForm_Days"
            Me.LabelForm_Days.Size = New System.Drawing.Size(120, 20)
            Me.LabelForm_Days.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Days.TabIndex = 8
            Me.LabelForm_Days.Text = "Days:"
            '
            'TextBoxForm_Days
            '
            Me.TextBoxForm_Days.AgencyImportPath = Nothing
            Me.TextBoxForm_Days.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxForm_Days.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxForm_Days.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Days.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Days.CheckSpellingOnValidate = False
            Me.TextBoxForm_Days.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Days.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxForm_Days.DisplayName = ""
            Me.TextBoxForm_Days.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxForm_Days.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Days.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Days.FocusHighlightEnabled = True
            Me.TextBoxForm_Days.ForeColor = System.Drawing.Color.Black
            Me.TextBoxForm_Days.Location = New System.Drawing.Point(138, 90)
            Me.TextBoxForm_Days.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Days.Name = "TextBoxForm_Days"
            Me.TextBoxForm_Days.SecurityEnabled = True
            Me.TextBoxForm_Days.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Days.Size = New System.Drawing.Size(294, 20)
            Me.TextBoxForm_Days.StartingFolderName = Nothing
            Me.TextBoxForm_Days.TabIndex = 9
            Me.TextBoxForm_Days.TabOnEnter = True
            '
            'LabelForm_StartTime
            '
            Me.LabelForm_StartTime.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_StartTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_StartTime.Location = New System.Drawing.Point(12, 116)
            Me.LabelForm_StartTime.Name = "LabelForm_StartTime"
            Me.LabelForm_StartTime.Size = New System.Drawing.Size(120, 20)
            Me.LabelForm_StartTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_StartTime.TabIndex = 11
            Me.LabelForm_StartTime.Text = "Start Time:"
            '
            'TextBoxForm_StartTime
            '
            Me.TextBoxForm_StartTime.AgencyImportPath = Nothing
            Me.TextBoxForm_StartTime.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxForm_StartTime.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxForm_StartTime.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_StartTime.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_StartTime.CheckSpellingOnValidate = False
            Me.TextBoxForm_StartTime.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_StartTime.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxForm_StartTime.DisplayName = ""
            Me.TextBoxForm_StartTime.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxForm_StartTime.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_StartTime.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_StartTime.FocusHighlightEnabled = True
            Me.TextBoxForm_StartTime.ForeColor = System.Drawing.Color.Black
            Me.TextBoxForm_StartTime.Location = New System.Drawing.Point(138, 116)
            Me.TextBoxForm_StartTime.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_StartTime.Name = "TextBoxForm_StartTime"
            Me.TextBoxForm_StartTime.SecurityEnabled = True
            Me.TextBoxForm_StartTime.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_StartTime.Size = New System.Drawing.Size(294, 20)
            Me.TextBoxForm_StartTime.StartingFolderName = Nothing
            Me.TextBoxForm_StartTime.TabIndex = 12
            Me.TextBoxForm_StartTime.TabOnEnter = True
            '
            'LabelForm_EndTime
            '
            Me.LabelForm_EndTime.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_EndTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_EndTime.Location = New System.Drawing.Point(12, 142)
            Me.LabelForm_EndTime.Name = "LabelForm_EndTime"
            Me.LabelForm_EndTime.Size = New System.Drawing.Size(120, 20)
            Me.LabelForm_EndTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_EndTime.TabIndex = 14
            Me.LabelForm_EndTime.Text = "End Time:"
            '
            'TextBoxForm_EndTime
            '
            Me.TextBoxForm_EndTime.AgencyImportPath = Nothing
            Me.TextBoxForm_EndTime.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxForm_EndTime.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxForm_EndTime.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_EndTime.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_EndTime.CheckSpellingOnValidate = False
            Me.TextBoxForm_EndTime.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_EndTime.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxForm_EndTime.DisplayName = ""
            Me.TextBoxForm_EndTime.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxForm_EndTime.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_EndTime.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_EndTime.FocusHighlightEnabled = True
            Me.TextBoxForm_EndTime.ForeColor = System.Drawing.Color.Black
            Me.TextBoxForm_EndTime.Location = New System.Drawing.Point(138, 142)
            Me.TextBoxForm_EndTime.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_EndTime.Name = "TextBoxForm_EndTime"
            Me.TextBoxForm_EndTime.SecurityEnabled = True
            Me.TextBoxForm_EndTime.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_EndTime.Size = New System.Drawing.Size(294, 20)
            Me.TextBoxForm_EndTime.StartingFolderName = Nothing
            Me.TextBoxForm_EndTime.TabIndex = 15
            Me.TextBoxForm_EndTime.TabOnEnter = True
            '
            'LabelForm_Comments
            '
            Me.LabelForm_Comments.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Comments.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Comments.Location = New System.Drawing.Point(12, 168)
            Me.LabelForm_Comments.Name = "LabelForm_Comments"
            Me.LabelForm_Comments.Size = New System.Drawing.Size(120, 20)
            Me.LabelForm_Comments.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Comments.TabIndex = 17
            Me.LabelForm_Comments.Text = "Comments:"
            '
            'TextBoxForm_Comments
            '
            Me.TextBoxForm_Comments.AgencyImportPath = Nothing
            Me.TextBoxForm_Comments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxForm_Comments.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxForm_Comments.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Comments.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Comments.CheckSpellingOnValidate = False
            Me.TextBoxForm_Comments.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Comments.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxForm_Comments.DisplayName = ""
            Me.TextBoxForm_Comments.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxForm_Comments.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Comments.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Comments.FocusHighlightEnabled = True
            Me.TextBoxForm_Comments.ForeColor = System.Drawing.Color.Black
            Me.TextBoxForm_Comments.Location = New System.Drawing.Point(138, 168)
            Me.TextBoxForm_Comments.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Comments.Name = "TextBoxForm_Comments"
            Me.TextBoxForm_Comments.SecurityEnabled = True
            Me.TextBoxForm_Comments.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Comments.Size = New System.Drawing.Size(294, 20)
            Me.TextBoxForm_Comments.StartingFolderName = Nothing
            Me.TextBoxForm_Comments.TabIndex = 18
            Me.TextBoxForm_Comments.TabOnEnter = True
            '
            'CheckBoxForm_AddedValue
            '
            Me.CheckBoxForm_AddedValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxForm_AddedValue.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxForm_AddedValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_AddedValue.CheckValue = 0
            Me.CheckBoxForm_AddedValue.CheckValueChecked = 1
            Me.CheckBoxForm_AddedValue.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_AddedValue.CheckValueUnchecked = 0
            Me.CheckBoxForm_AddedValue.ChildControls = Nothing
            Me.CheckBoxForm_AddedValue.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_AddedValue.Location = New System.Drawing.Point(138, 194)
            Me.CheckBoxForm_AddedValue.Name = "CheckBoxForm_AddedValue"
            Me.CheckBoxForm_AddedValue.OldestSibling = Nothing
            Me.CheckBoxForm_AddedValue.SecurityEnabled = True
            Me.CheckBoxForm_AddedValue.SiblingControls = Nothing
            Me.CheckBoxForm_AddedValue.Size = New System.Drawing.Size(354, 20)
            Me.CheckBoxForm_AddedValue.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_AddedValue.TabIndex = 20
            Me.CheckBoxForm_AddedValue.TabOnEnter = True
            Me.CheckBoxForm_AddedValue.Text = "Added Value"
            '
            'RadioButtonControlForm_UpdateFromSelected
            '
            Me.RadioButtonControlForm_UpdateFromSelected.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlForm_UpdateFromSelected.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlForm_UpdateFromSelected.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlForm_UpdateFromSelected.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlForm_UpdateFromSelected.Location = New System.Drawing.Point(138, 12)
            Me.RadioButtonControlForm_UpdateFromSelected.Name = "RadioButtonControlForm_UpdateFromSelected"
            Me.RadioButtonControlForm_UpdateFromSelected.SecurityEnabled = True
            Me.RadioButtonControlForm_UpdateFromSelected.Size = New System.Drawing.Size(354, 20)
            Me.RadioButtonControlForm_UpdateFromSelected.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlForm_UpdateFromSelected.TabIndex = 1
            Me.RadioButtonControlForm_UpdateFromSelected.TabOnEnter = True
            Me.RadioButtonControlForm_UpdateFromSelected.TabStop = False
            Me.RadioButtonControlForm_UpdateFromSelected.Text = "Update from Selected"
            '
            'RadioButtonControlForm_FromBlank
            '
            Me.RadioButtonControlForm_FromBlank.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlForm_FromBlank.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlForm_FromBlank.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlForm_FromBlank.Checked = True
            Me.RadioButtonControlForm_FromBlank.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonControlForm_FromBlank.CheckValue = "Y"
            Me.RadioButtonControlForm_FromBlank.Location = New System.Drawing.Point(12, 12)
            Me.RadioButtonControlForm_FromBlank.Name = "RadioButtonControlForm_FromBlank"
            Me.RadioButtonControlForm_FromBlank.SecurityEnabled = True
            Me.RadioButtonControlForm_FromBlank.Size = New System.Drawing.Size(120, 20)
            Me.RadioButtonControlForm_FromBlank.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlForm_FromBlank.TabIndex = 0
            Me.RadioButtonControlForm_FromBlank.TabOnEnter = True
            Me.RadioButtonControlForm_FromBlank.Text = "Update from New"
            '
            'ButtonForm_SelectLast
            '
            Me.ButtonForm_SelectLast.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_SelectLast.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_SelectLast.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_SelectLast.Location = New System.Drawing.Point(255, 220)
            Me.ButtonForm_SelectLast.Name = "ButtonForm_SelectLast"
            Me.ButtonForm_SelectLast.SecurityEnabled = True
            Me.ButtonForm_SelectLast.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_SelectLast.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_SelectLast.TabIndex = 24
            Me.ButtonForm_SelectLast.Text = "Last"
            '
            'ButtonForm_SelectNext
            '
            Me.ButtonForm_SelectNext.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_SelectNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_SelectNext.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_SelectNext.Location = New System.Drawing.Point(174, 220)
            Me.ButtonForm_SelectNext.Name = "ButtonForm_SelectNext"
            Me.ButtonForm_SelectNext.SecurityEnabled = True
            Me.ButtonForm_SelectNext.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_SelectNext.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_SelectNext.TabIndex = 23
            Me.ButtonForm_SelectNext.Text = "Next"
            '
            'ButtonForm_SelectPrevious
            '
            Me.ButtonForm_SelectPrevious.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_SelectPrevious.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_SelectPrevious.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_SelectPrevious.Location = New System.Drawing.Point(93, 220)
            Me.ButtonForm_SelectPrevious.Name = "ButtonForm_SelectPrevious"
            Me.ButtonForm_SelectPrevious.SecurityEnabled = True
            Me.ButtonForm_SelectPrevious.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_SelectPrevious.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_SelectPrevious.TabIndex = 22
            Me.ButtonForm_SelectPrevious.Text = "Previous"
            '
            'ButtonForm_SelectFirst
            '
            Me.ButtonForm_SelectFirst.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_SelectFirst.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_SelectFirst.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_SelectFirst.Location = New System.Drawing.Point(12, 220)
            Me.ButtonForm_SelectFirst.Name = "ButtonForm_SelectFirst"
            Me.ButtonForm_SelectFirst.SecurityEnabled = True
            Me.ButtonForm_SelectFirst.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_SelectFirst.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_SelectFirst.TabIndex = 21
            Me.ButtonForm_SelectFirst.Text = "First"
            '
            'CheckBoxForm_DaypartClear
            '
            Me.CheckBoxForm_DaypartClear.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxForm_DaypartClear.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxForm_DaypartClear.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_DaypartClear.CheckValue = 0
            Me.CheckBoxForm_DaypartClear.CheckValueChecked = 1
            Me.CheckBoxForm_DaypartClear.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_DaypartClear.CheckValueUnchecked = 0
            Me.CheckBoxForm_DaypartClear.ChildControls = Nothing
            Me.CheckBoxForm_DaypartClear.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_DaypartClear.Location = New System.Drawing.Point(438, 38)
            Me.CheckBoxForm_DaypartClear.Name = "CheckBoxForm_DaypartClear"
            Me.CheckBoxForm_DaypartClear.OldestSibling = Nothing
            Me.CheckBoxForm_DaypartClear.SecurityEnabled = True
            Me.CheckBoxForm_DaypartClear.SiblingControls = Nothing
            Me.CheckBoxForm_DaypartClear.Size = New System.Drawing.Size(54, 20)
            Me.CheckBoxForm_DaypartClear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_DaypartClear.TabIndex = 4
            Me.CheckBoxForm_DaypartClear.TabOnEnter = True
            Me.CheckBoxForm_DaypartClear.Text = "Clear"
            '
            'CheckBoxForm_LengthClear
            '
            Me.CheckBoxForm_LengthClear.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxForm_LengthClear.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxForm_LengthClear.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_LengthClear.CheckValue = 0
            Me.CheckBoxForm_LengthClear.CheckValueChecked = 1
            Me.CheckBoxForm_LengthClear.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_LengthClear.CheckValueUnchecked = 0
            Me.CheckBoxForm_LengthClear.ChildControls = Nothing
            Me.CheckBoxForm_LengthClear.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_LengthClear.Location = New System.Drawing.Point(438, 64)
            Me.CheckBoxForm_LengthClear.Name = "CheckBoxForm_LengthClear"
            Me.CheckBoxForm_LengthClear.OldestSibling = Nothing
            Me.CheckBoxForm_LengthClear.SecurityEnabled = True
            Me.CheckBoxForm_LengthClear.SiblingControls = Nothing
            Me.CheckBoxForm_LengthClear.Size = New System.Drawing.Size(54, 20)
            Me.CheckBoxForm_LengthClear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_LengthClear.TabIndex = 7
            Me.CheckBoxForm_LengthClear.TabOnEnter = True
            Me.CheckBoxForm_LengthClear.Text = "Clear"
            '
            'CheckBoxForm_DaysClear
            '
            Me.CheckBoxForm_DaysClear.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxForm_DaysClear.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxForm_DaysClear.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_DaysClear.CheckValue = 0
            Me.CheckBoxForm_DaysClear.CheckValueChecked = 1
            Me.CheckBoxForm_DaysClear.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_DaysClear.CheckValueUnchecked = 0
            Me.CheckBoxForm_DaysClear.ChildControls = Nothing
            Me.CheckBoxForm_DaysClear.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_DaysClear.Location = New System.Drawing.Point(438, 90)
            Me.CheckBoxForm_DaysClear.Name = "CheckBoxForm_DaysClear"
            Me.CheckBoxForm_DaysClear.OldestSibling = Nothing
            Me.CheckBoxForm_DaysClear.SecurityEnabled = True
            Me.CheckBoxForm_DaysClear.SiblingControls = Nothing
            Me.CheckBoxForm_DaysClear.Size = New System.Drawing.Size(54, 20)
            Me.CheckBoxForm_DaysClear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_DaysClear.TabIndex = 10
            Me.CheckBoxForm_DaysClear.TabOnEnter = True
            Me.CheckBoxForm_DaysClear.Text = "Clear"
            '
            'CheckBoxForm_StartTimeClear
            '
            Me.CheckBoxForm_StartTimeClear.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxForm_StartTimeClear.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxForm_StartTimeClear.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_StartTimeClear.CheckValue = 0
            Me.CheckBoxForm_StartTimeClear.CheckValueChecked = 1
            Me.CheckBoxForm_StartTimeClear.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_StartTimeClear.CheckValueUnchecked = 0
            Me.CheckBoxForm_StartTimeClear.ChildControls = Nothing
            Me.CheckBoxForm_StartTimeClear.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_StartTimeClear.Location = New System.Drawing.Point(438, 116)
            Me.CheckBoxForm_StartTimeClear.Name = "CheckBoxForm_StartTimeClear"
            Me.CheckBoxForm_StartTimeClear.OldestSibling = Nothing
            Me.CheckBoxForm_StartTimeClear.SecurityEnabled = True
            Me.CheckBoxForm_StartTimeClear.SiblingControls = Nothing
            Me.CheckBoxForm_StartTimeClear.Size = New System.Drawing.Size(54, 20)
            Me.CheckBoxForm_StartTimeClear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_StartTimeClear.TabIndex = 13
            Me.CheckBoxForm_StartTimeClear.TabOnEnter = True
            Me.CheckBoxForm_StartTimeClear.Text = "Clear"
            '
            'CheckBoxForm_EndTimeClear
            '
            Me.CheckBoxForm_EndTimeClear.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxForm_EndTimeClear.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxForm_EndTimeClear.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_EndTimeClear.CheckValue = 0
            Me.CheckBoxForm_EndTimeClear.CheckValueChecked = 1
            Me.CheckBoxForm_EndTimeClear.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_EndTimeClear.CheckValueUnchecked = 0
            Me.CheckBoxForm_EndTimeClear.ChildControls = Nothing
            Me.CheckBoxForm_EndTimeClear.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_EndTimeClear.Location = New System.Drawing.Point(438, 142)
            Me.CheckBoxForm_EndTimeClear.Name = "CheckBoxForm_EndTimeClear"
            Me.CheckBoxForm_EndTimeClear.OldestSibling = Nothing
            Me.CheckBoxForm_EndTimeClear.SecurityEnabled = True
            Me.CheckBoxForm_EndTimeClear.SiblingControls = Nothing
            Me.CheckBoxForm_EndTimeClear.Size = New System.Drawing.Size(54, 20)
            Me.CheckBoxForm_EndTimeClear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_EndTimeClear.TabIndex = 16
            Me.CheckBoxForm_EndTimeClear.TabOnEnter = True
            Me.CheckBoxForm_EndTimeClear.Text = "Clear"
            '
            'CheckBoxForm_CommentsClear
            '
            Me.CheckBoxForm_CommentsClear.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxForm_CommentsClear.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxForm_CommentsClear.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_CommentsClear.CheckValue = 0
            Me.CheckBoxForm_CommentsClear.CheckValueChecked = 1
            Me.CheckBoxForm_CommentsClear.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_CommentsClear.CheckValueUnchecked = 0
            Me.CheckBoxForm_CommentsClear.ChildControls = Nothing
            Me.CheckBoxForm_CommentsClear.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_CommentsClear.Location = New System.Drawing.Point(438, 168)
            Me.CheckBoxForm_CommentsClear.Name = "CheckBoxForm_CommentsClear"
            Me.CheckBoxForm_CommentsClear.OldestSibling = Nothing
            Me.CheckBoxForm_CommentsClear.SecurityEnabled = True
            Me.CheckBoxForm_CommentsClear.SiblingControls = Nothing
            Me.CheckBoxForm_CommentsClear.Size = New System.Drawing.Size(54, 20)
            Me.CheckBoxForm_CommentsClear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_CommentsClear.TabIndex = 19
            Me.CheckBoxForm_CommentsClear.TabOnEnter = True
            Me.CheckBoxForm_CommentsClear.Text = "Clear"
            '
            'MediaBroadcastWorksheetMarketDetailAutoFillDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(504, 252)
            Me.Controls.Add(Me.CheckBoxForm_CommentsClear)
            Me.Controls.Add(Me.CheckBoxForm_EndTimeClear)
            Me.Controls.Add(Me.CheckBoxForm_StartTimeClear)
            Me.Controls.Add(Me.CheckBoxForm_DaysClear)
            Me.Controls.Add(Me.CheckBoxForm_LengthClear)
            Me.Controls.Add(Me.CheckBoxForm_DaypartClear)
            Me.Controls.Add(Me.ButtonForm_SelectLast)
            Me.Controls.Add(Me.ButtonForm_SelectNext)
            Me.Controls.Add(Me.ButtonForm_SelectPrevious)
            Me.Controls.Add(Me.ButtonForm_SelectFirst)
            Me.Controls.Add(Me.RadioButtonControlForm_UpdateFromSelected)
            Me.Controls.Add(Me.RadioButtonControlForm_FromBlank)
            Me.Controls.Add(Me.CheckBoxForm_AddedValue)
            Me.Controls.Add(Me.LabelForm_Comments)
            Me.Controls.Add(Me.TextBoxForm_Comments)
            Me.Controls.Add(Me.LabelForm_EndTime)
            Me.Controls.Add(Me.TextBoxForm_EndTime)
            Me.Controls.Add(Me.LabelForm_StartTime)
            Me.Controls.Add(Me.TextBoxForm_StartTime)
            Me.Controls.Add(Me.LabelForm_Days)
            Me.Controls.Add(Me.TextBoxForm_Days)
            Me.Controls.Add(Me.NumericInputForm_Length)
            Me.Controls.Add(Me.LabelForm_Length)
            Me.Controls.Add(Me.LabelForm_Daypart)
            Me.Controls.Add(Me.ComboBoxForm_Daypart)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaBroadcastWorksheetMarketDetailAutoFillDialog"
            Me.Text = "Auto Fill"
            CType(Me.NumericInputForm_Length.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents LabelForm_Daypart As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_Daypart As WinForm.MVC.Presentation.Controls.ComboBox
        Friend WithEvents NumericInputForm_Length As WinForm.MVC.Presentation.Controls.NumericInput
        Friend WithEvents LabelForm_Length As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelForm_Days As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_Days As WinForm.MVC.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_StartTime As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_StartTime As WinForm.MVC.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_EndTime As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_EndTime As WinForm.MVC.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_Comments As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_Comments As WinForm.MVC.Presentation.Controls.TextBox
        Friend WithEvents CheckBoxForm_AddedValue As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents RadioButtonControlForm_UpdateFromSelected As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlForm_FromBlank As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents ButtonForm_SelectLast As WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_SelectNext As WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_SelectPrevious As WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_SelectFirst As WinForm.Presentation.Controls.Button
        Friend WithEvents CheckBoxForm_DaypartClear As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_LengthClear As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_DaysClear As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_StartTimeClear As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_EndTimeClear As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_CommentsClear As WinForm.MVC.Presentation.Controls.CheckBox
    End Class

End Namespace