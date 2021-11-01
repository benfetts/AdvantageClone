Namespace Reporting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class JobForecastInitialLoadingDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(JobForecastInitialLoadingDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ComboBoxForm_Month = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_Month = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxForm_BreakoutPostPeriods = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelForm_Year = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_Year = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(106, 95)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 8
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(187, 95)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 9
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ComboBoxForm_Month
            '
            Me.ComboBoxForm_Month.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Month.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_Month.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Month.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Month.AutoFindItemInDataSource = False
            Me.ComboBoxForm_Month.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Month.BookmarkingEnabled = False
            Me.ComboBoxForm_Month.ClientCode = ""
            Me.ComboBoxForm_Month.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Month
            Me.ComboBoxForm_Month.DisableMouseWheel = False
            Me.ComboBoxForm_Month.DisplayMember = "Value"
            Me.ComboBoxForm_Month.DisplayName = ""
            Me.ComboBoxForm_Month.DivisionCode = ""
            Me.ComboBoxForm_Month.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Month.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_Month.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_Month.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Month.FocusHighlightEnabled = True
            Me.ComboBoxForm_Month.FormattingEnabled = True
            Me.ComboBoxForm_Month.ItemHeight = 14
            Me.ComboBoxForm_Month.Location = New System.Drawing.Point(69, 12)
            Me.ComboBoxForm_Month.Name = "ComboBoxForm_Month"
            Me.ComboBoxForm_Month.ReadOnly = False
            Me.ComboBoxForm_Month.SecurityEnabled = True
            Me.ComboBoxForm_Month.Size = New System.Drawing.Size(193, 20)
            Me.ComboBoxForm_Month.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Month.TabIndex = 1
            Me.ComboBoxForm_Month.TabOnEnter = True
            Me.ComboBoxForm_Month.ValueMember = "Key"
            Me.ComboBoxForm_Month.WatermarkText = "Select Month"
            '
            'LabelForm_Month
            '
            Me.LabelForm_Month.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Month.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Month.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_Month.Name = "LabelForm_Month"
            Me.LabelForm_Month.Size = New System.Drawing.Size(51, 20)
            Me.LabelForm_Month.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Month.TabIndex = 0
            Me.LabelForm_Month.Text = "Month:"
            '
            'CheckBoxForm_BreakoutPostPeriods
            '
            Me.CheckBoxForm_BreakoutPostPeriods.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxForm_BreakoutPostPeriods.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_BreakoutPostPeriods.CheckValue = 0
            Me.CheckBoxForm_BreakoutPostPeriods.CheckValueChecked = 1
            Me.CheckBoxForm_BreakoutPostPeriods.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_BreakoutPostPeriods.CheckValueUnchecked = 0
            Me.CheckBoxForm_BreakoutPostPeriods.ChildControls = Nothing
            Me.CheckBoxForm_BreakoutPostPeriods.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_BreakoutPostPeriods.Location = New System.Drawing.Point(69, 64)
            Me.CheckBoxForm_BreakoutPostPeriods.Name = "CheckBoxForm_BreakoutPostPeriods"
            Me.CheckBoxForm_BreakoutPostPeriods.OldestSibling = Nothing
            Me.CheckBoxForm_BreakoutPostPeriods.SecurityEnabled = True
            Me.CheckBoxForm_BreakoutPostPeriods.SiblingControls = Nothing
            Me.CheckBoxForm_BreakoutPostPeriods.Size = New System.Drawing.Size(193, 20)
            Me.CheckBoxForm_BreakoutPostPeriods.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_BreakoutPostPeriods.TabIndex = 10
            Me.CheckBoxForm_BreakoutPostPeriods.TabOnEnter = True
            Me.CheckBoxForm_BreakoutPostPeriods.Text = "Breakout Forecast Post Periods"
            '
            'LabelForm_Year
            '
            Me.LabelForm_Year.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Year.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Year.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_Year.Name = "LabelForm_Year"
            Me.LabelForm_Year.Size = New System.Drawing.Size(51, 20)
            Me.LabelForm_Year.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Year.TabIndex = 11
            Me.LabelForm_Year.Text = "Year:"
            '
            'ComboBoxForm_Year
            '
            Me.ComboBoxForm_Year.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Year.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_Year.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Year.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Year.AutoFindItemInDataSource = False
            Me.ComboBoxForm_Year.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Year.BookmarkingEnabled = False
            Me.ComboBoxForm_Year.ClientCode = ""
            Me.ComboBoxForm_Year.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.ShortNumeric
            Me.ComboBoxForm_Year.DisableMouseWheel = False
            Me.ComboBoxForm_Year.DisplayMember = "Number"
            Me.ComboBoxForm_Year.DisplayName = ""
            Me.ComboBoxForm_Year.DivisionCode = ""
            Me.ComboBoxForm_Year.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Year.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_Year.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_Year.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Year.FocusHighlightEnabled = True
            Me.ComboBoxForm_Year.FormattingEnabled = True
            Me.ComboBoxForm_Year.ItemHeight = 14
            Me.ComboBoxForm_Year.Location = New System.Drawing.Point(69, 38)
            Me.ComboBoxForm_Year.Name = "ComboBoxForm_Year"
            Me.ComboBoxForm_Year.ReadOnly = False
            Me.ComboBoxForm_Year.SecurityEnabled = True
            Me.ComboBoxForm_Year.Size = New System.Drawing.Size(193, 20)
            Me.ComboBoxForm_Year.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Year.TabIndex = 12
            Me.ComboBoxForm_Year.TabOnEnter = True
            Me.ComboBoxForm_Year.ValueMember = "Number"
            Me.ComboBoxForm_Year.WatermarkText = "Select"
            '
            'JobForecastInitialLoadingDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(274, 127)
            Me.Controls.Add(Me.ComboBoxForm_Year)
            Me.Controls.Add(Me.LabelForm_Year)
            Me.Controls.Add(Me.CheckBoxForm_BreakoutPostPeriods)
            Me.Controls.Add(Me.LabelForm_Month)
            Me.Controls.Add(Me.ComboBoxForm_Month)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "JobForecastInitialLoadingDialog"
            Me.Text = "Job Forecast Initial Criteria"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ComboBoxForm_Month As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_Month As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxForm_BreakoutPostPeriods As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelForm_Year As WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_Year As WinForm.Presentation.Controls.ComboBox
    End Class

End Namespace