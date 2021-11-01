Namespace WinForm.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ComplexExpressionEditorDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ComplexExpressionEditorDialog))
        Me.TextBoxForm_Caption = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
        Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.LabelForm_Caption = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.LabelForm_Expression = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.TextBoxForm_Expression = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
        Me.ButtonForm_ExpressionEdit = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.LabelForm_Type = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.ComboBoxForm_Type = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
        Me.NumericInputForm_NumberOfDecimalPlaces = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
        Me.LabelForm_NumberOfDecimalPlaces = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.LabelForm_Format = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.RadioButtonForm_Currency = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
        Me.RadioButtonForm_Percent = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
        Me.RadioButtonForm_Default = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
        CType(Me.NumericInputForm_NumberOfDecimalPlaces.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'TextBoxForm_Caption
        '
        Me.TextBoxForm_Caption.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.TextBoxForm_Caption.Border.Class = "TextBoxBorder"
        Me.TextBoxForm_Caption.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxForm_Caption.CheckSpellingOnValidate = false
        Me.TextBoxForm_Caption.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
        Me.TextBoxForm_Caption.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.TextBoxForm_Caption.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
        Me.TextBoxForm_Caption.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(230,Byte),Integer), CType(CType(141,Byte),Integer))
        Me.TextBoxForm_Caption.FocusHighlightEnabled = true
        Me.TextBoxForm_Caption.Location = New System.Drawing.Point(89, 12)
        Me.TextBoxForm_Caption.MaxFileSize = CType(0,Long)
        Me.TextBoxForm_Caption.Name = "TextBoxForm_Caption"
        Me.TextBoxForm_Caption.Size = New System.Drawing.Size(361, 20)
        Me.TextBoxForm_Caption.TabIndex = 1
        Me.TextBoxForm_Caption.TabOnEnter = true
        '
        'ButtonForm_Cancel
        '
        Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonForm_Cancel.Location = New System.Drawing.Point(375, 117)
        Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
        Me.ButtonForm_Cancel.SecurityEnabled = true
        Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
        Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonForm_Cancel.TabIndex = 14
        Me.ButtonForm_Cancel.Text = "Cancel"
        '
        'ButtonForm_OK
        '
        Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonForm_OK.Location = New System.Drawing.Point(294, 117)
        Me.ButtonForm_OK.Name = "ButtonForm_OK"
        Me.ButtonForm_OK.SecurityEnabled = true
        Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
        Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonForm_OK.TabIndex = 13
        Me.ButtonForm_OK.Text = "OK"
        '
        'LabelForm_Caption
        '
        Me.LabelForm_Caption.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelForm_Caption.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelForm_Caption.Location = New System.Drawing.Point(12, 12)
        Me.LabelForm_Caption.Name = "LabelForm_Caption"
        Me.LabelForm_Caption.Size = New System.Drawing.Size(71, 20)
        Me.LabelForm_Caption.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelForm_Caption.TabIndex = 0
        Me.LabelForm_Caption.Text = "Caption:"
        '
        'LabelForm_Expression
        '
        Me.LabelForm_Expression.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelForm_Expression.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelForm_Expression.Location = New System.Drawing.Point(12, 65)
        Me.LabelForm_Expression.Name = "LabelForm_Expression"
        Me.LabelForm_Expression.Size = New System.Drawing.Size(71, 20)
        Me.LabelForm_Expression.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelForm_Expression.TabIndex = 4
        Me.LabelForm_Expression.Text = "Expression:"
        '
        'TextBoxForm_Expression
        '
        Me.TextBoxForm_Expression.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.TextBoxForm_Expression.Border.Class = "TextBoxBorder"
        Me.TextBoxForm_Expression.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxForm_Expression.CheckSpellingOnValidate = false
        Me.TextBoxForm_Expression.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
        Me.TextBoxForm_Expression.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.TextBoxForm_Expression.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
        Me.TextBoxForm_Expression.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(230,Byte),Integer), CType(CType(141,Byte),Integer))
        Me.TextBoxForm_Expression.FocusHighlightEnabled = true
        Me.TextBoxForm_Expression.Location = New System.Drawing.Point(89, 65)
        Me.TextBoxForm_Expression.MaxFileSize = CType(0,Long)
        Me.TextBoxForm_Expression.Name = "TextBoxForm_Expression"
        Me.TextBoxForm_Expression.ReadOnly = true
        Me.TextBoxForm_Expression.Size = New System.Drawing.Size(280, 20)
        Me.TextBoxForm_Expression.TabIndex = 5
        Me.TextBoxForm_Expression.TabOnEnter = true
        '
        'ButtonForm_ExpressionEdit
        '
        Me.ButtonForm_ExpressionEdit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonForm_ExpressionEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.ButtonForm_ExpressionEdit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonForm_ExpressionEdit.Location = New System.Drawing.Point(375, 65)
        Me.ButtonForm_ExpressionEdit.Name = "ButtonForm_ExpressionEdit"
        Me.ButtonForm_ExpressionEdit.SecurityEnabled = true
        Me.ButtonForm_ExpressionEdit.Size = New System.Drawing.Size(75, 20)
        Me.ButtonForm_ExpressionEdit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonForm_ExpressionEdit.TabIndex = 6
        Me.ButtonForm_ExpressionEdit.Text = "Edit"
        '
        'LabelForm_Type
        '
        Me.LabelForm_Type.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelForm_Type.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelForm_Type.Location = New System.Drawing.Point(12, 38)
        Me.LabelForm_Type.Name = "LabelForm_Type"
        Me.LabelForm_Type.Size = New System.Drawing.Size(71, 20)
        Me.LabelForm_Type.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelForm_Type.TabIndex = 2
        Me.LabelForm_Type.Text = "Type:"
        '
        'ComboBoxForm_Type
        '
        Me.ComboBoxForm_Type.AddInactiveItemsOnSelectedValue = false
        Me.ComboBoxForm_Type.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.ComboBoxForm_Type.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboBoxForm_Type.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxForm_Type.AutoFindItemInDataSource = false
        Me.ComboBoxForm_Type.AutoSelectSingleItemDatasource = false
        Me.ComboBoxForm_Type.BookmarkingEnabled = false
        Me.ComboBoxForm_Type.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumDataTable
        Me.ComboBoxForm_Type.DisableMouseWheel = false
        Me.ComboBoxForm_Type.DisplayMember = "Name"
        Me.ComboBoxForm_Type.DisplayName = ""
        Me.ComboBoxForm_Type.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxForm_Type.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.ComboBoxForm_Type.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
        Me.ComboBoxForm_Type.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(230,Byte),Integer), CType(CType(141,Byte),Integer))
        Me.ComboBoxForm_Type.FocusHighlightEnabled = true
        Me.ComboBoxForm_Type.FormattingEnabled = true
        Me.ComboBoxForm_Type.ItemHeight = 14
        Me.ComboBoxForm_Type.Location = New System.Drawing.Point(89, 38)
        Me.ComboBoxForm_Type.Name = "ComboBoxForm_Type"
        Me.ComboBoxForm_Type.PreventEnterBeep = False
        Me.ComboBoxForm_Type.ReadOnly = false
        Me.ComboBoxForm_Type.Size = New System.Drawing.Size(361, 20)
        Me.ComboBoxForm_Type.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBoxForm_Type.TabIndex = 3
        Me.ComboBoxForm_Type.ValueMember = "Value"
        Me.ComboBoxForm_Type.WatermarkText = "Select"
        '
        'NumericInputForm_NumberOfDecimalPlaces
        '
        Me.NumericInputForm_NumberOfDecimalPlaces.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
        Me.NumericInputForm_NumberOfDecimalPlaces.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumericInputForm_NumberOfDecimalPlaces.Location = New System.Drawing.Point(401, 91)
        Me.NumericInputForm_NumberOfDecimalPlaces.Name = "NumericInputForm_NumberOfDecimalPlaces"
        Me.NumericInputForm_NumberOfDecimalPlaces.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.NumericInputForm_NumberOfDecimalPlaces.Properties.DisplayFormat.FormatString = "f0"
        Me.NumericInputForm_NumberOfDecimalPlaces.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.NumericInputForm_NumberOfDecimalPlaces.Properties.EditFormat.FormatString = "f0"
        Me.NumericInputForm_NumberOfDecimalPlaces.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.NumericInputForm_NumberOfDecimalPlaces.Properties.IsFloatValue = false
        Me.NumericInputForm_NumberOfDecimalPlaces.Properties.Mask.EditMask = "f0"
        Me.NumericInputForm_NumberOfDecimalPlaces.Properties.Mask.UseMaskAsDisplayFormat = true
        Me.NumericInputForm_NumberOfDecimalPlaces.Properties.MaxLength = 11
        Me.NumericInputForm_NumberOfDecimalPlaces.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.NumericInputForm_NumberOfDecimalPlaces.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
        Me.NumericInputForm_NumberOfDecimalPlaces.Size = New System.Drawing.Size(49, 20)
        Me.NumericInputForm_NumberOfDecimalPlaces.TabIndex = 12
        '
        'LabelForm_NumberOfDecimalPlaces
        '
        Me.LabelForm_NumberOfDecimalPlaces.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelForm_NumberOfDecimalPlaces.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelForm_NumberOfDecimalPlaces.Location = New System.Drawing.Point(306, 91)
        Me.LabelForm_NumberOfDecimalPlaces.Name = "LabelForm_NumberOfDecimalPlaces"
        Me.LabelForm_NumberOfDecimalPlaces.Size = New System.Drawing.Size(89, 20)
        Me.LabelForm_NumberOfDecimalPlaces.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelForm_NumberOfDecimalPlaces.TabIndex = 11
        Me.LabelForm_NumberOfDecimalPlaces.Text = "Decimal Places:"
        '
        'LabelForm_Format
        '
        Me.LabelForm_Format.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelForm_Format.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelForm_Format.Location = New System.Drawing.Point(12, 91)
        Me.LabelForm_Format.Name = "LabelForm_Format"
        Me.LabelForm_Format.Size = New System.Drawing.Size(72, 20)
        Me.LabelForm_Format.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelForm_Format.TabIndex = 7
        Me.LabelForm_Format.Text = "Format:"
        '
        'RadioButtonForm_Currency
        '
        '
        '
        '
        Me.RadioButtonForm_Currency.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RadioButtonForm_Currency.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.RadioButtonForm_Currency.Location = New System.Drawing.Point(158, 91)
        Me.RadioButtonForm_Currency.Name = "RadioButtonForm_Currency"
        Me.RadioButtonForm_Currency.Size = New System.Drawing.Size(73, 20)
        Me.RadioButtonForm_Currency.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RadioButtonForm_Currency.TabIndex = 9
        Me.RadioButtonForm_Currency.TabStop = false
        Me.RadioButtonForm_Currency.Text = "Currency"
        '
        'RadioButtonForm_Percent
        '
        '
        '
        '
        Me.RadioButtonForm_Percent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RadioButtonForm_Percent.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.RadioButtonForm_Percent.Location = New System.Drawing.Point(237, 91)
        Me.RadioButtonForm_Percent.Name = "RadioButtonForm_Percent"
        Me.RadioButtonForm_Percent.Size = New System.Drawing.Size(64, 20)
        Me.RadioButtonForm_Percent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RadioButtonForm_Percent.TabIndex = 10
        Me.RadioButtonForm_Percent.TabStop = false
        Me.RadioButtonForm_Percent.Text = "Percent"
        '
        'RadioButtonForm_Default
        '
        '
        '
        '
        Me.RadioButtonForm_Default.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RadioButtonForm_Default.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.RadioButtonForm_Default.Checked = true
        Me.RadioButtonForm_Default.CheckState = System.Windows.Forms.CheckState.Checked
        Me.RadioButtonForm_Default.CheckValue = "Y"
        Me.RadioButtonForm_Default.Location = New System.Drawing.Point(90, 91)
        Me.RadioButtonForm_Default.Name = "RadioButtonForm_Default"
        Me.RadioButtonForm_Default.Size = New System.Drawing.Size(62, 20)
        Me.RadioButtonForm_Default.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RadioButtonForm_Default.TabIndex = 8
        Me.RadioButtonForm_Default.Text = "Default"
        '
        'ComplexExpressionEditorDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(462, 149)
        Me.Controls.Add(Me.RadioButtonForm_Default)
        Me.Controls.Add(Me.RadioButtonForm_Percent)
        Me.Controls.Add(Me.RadioButtonForm_Currency)
        Me.Controls.Add(Me.NumericInputForm_NumberOfDecimalPlaces)
        Me.Controls.Add(Me.LabelForm_NumberOfDecimalPlaces)
        Me.Controls.Add(Me.LabelForm_Format)
        Me.Controls.Add(Me.ComboBoxForm_Type)
        Me.Controls.Add(Me.LabelForm_Type)
        Me.Controls.Add(Me.ButtonForm_ExpressionEdit)
        Me.Controls.Add(Me.LabelForm_Expression)
        Me.Controls.Add(Me.TextBoxForm_Expression)
        Me.Controls.Add(Me.LabelForm_Caption)
        Me.Controls.Add(Me.ButtonForm_OK)
        Me.Controls.Add(Me.ButtonForm_Cancel)
        Me.Controls.Add(Me.TextBoxForm_Caption)
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.Name = "ComplexExpressionEditorDialog"
        Me.Text = "Expression Editor"
        CType(Me.NumericInputForm_NumberOfDecimalPlaces.Properties,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
        Friend WithEvents TextBoxForm_Caption As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_Caption As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Expression As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_Expression As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents ButtonForm_ExpressionEdit As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_Type As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_Type As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents NumericInputForm_NumberOfDecimalPlaces As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents LabelForm_NumberOfDecimalPlaces As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Format As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents RadioButtonForm_Currency As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonForm_Percent As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonForm_Default As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
    End Class

End Namespace