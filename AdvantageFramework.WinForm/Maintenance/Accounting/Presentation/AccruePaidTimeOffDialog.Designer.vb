Namespace Maintenance.Accounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AccruePaidTimeOffDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AccruePaidTimeOffDialog))
            Me.ButtonForm_Close = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Process = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_ProcessMonth = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_LastAccrual = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_MonthToAccrue = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.NumericInputForm_Year = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.ComboBoxForm_Month = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_ProcessYear = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_AccrualsNeverProcessed = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SuspendLayout()
            '
            'ButtonForm_Close
            '
            Me.ButtonForm_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Close.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Close.Location = New System.Drawing.Point(351, 90)
            Me.ButtonForm_Close.Name = "ButtonForm_Close"
            Me.ButtonForm_Close.SecurityEnabled = True
            Me.ButtonForm_Close.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Close.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Close.TabIndex = 7
            Me.ButtonForm_Close.Text = "Close"
            '
            'ButtonForm_Process
            '
            Me.ButtonForm_Process.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Process.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Process.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Process.Location = New System.Drawing.Point(270, 90)
            Me.ButtonForm_Process.Name = "ButtonForm_Process"
            Me.ButtonForm_Process.SecurityEnabled = True
            Me.ButtonForm_Process.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Process.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Process.TabIndex = 6
            Me.ButtonForm_Process.Text = "Process"
            '
            'LabelForm_ProcessMonth
            '
            Me.LabelForm_ProcessMonth.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_ProcessMonth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_ProcessMonth.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_ProcessMonth.Name = "LabelForm_ProcessMonth"
            Me.LabelForm_ProcessMonth.Size = New System.Drawing.Size(84, 20)
            Me.LabelForm_ProcessMonth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ProcessMonth.TabIndex = 1
            Me.LabelForm_ProcessMonth.Text = "Process Month:"
            '
            'LabelForm_LastAccrual
            '
            Me.LabelForm_LastAccrual.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_LastAccrual.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_LastAccrual.Location = New System.Drawing.Point(12, 64)
            Me.LabelForm_LastAccrual.Name = "LabelForm_LastAccrual"
            Me.LabelForm_LastAccrual.Size = New System.Drawing.Size(414, 20)
            Me.LabelForm_LastAccrual.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_LastAccrual.TabIndex = 7
            Me.LabelForm_LastAccrual.Text = "Accruals were last processed for MM/YYYY by 'UNAME' on MM/DD/YYYY"
            '
            'LabelForm_MonthToAccrue
            '
            Me.LabelForm_MonthToAccrue.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_MonthToAccrue.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_MonthToAccrue.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_MonthToAccrue.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelForm_MonthToAccrue.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_MonthToAccrue.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_MonthToAccrue.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_MonthToAccrue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_MonthToAccrue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelForm_MonthToAccrue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_MonthToAccrue.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_MonthToAccrue.Name = "LabelForm_MonthToAccrue"
            Me.LabelForm_MonthToAccrue.Size = New System.Drawing.Size(414, 20)
            Me.LabelForm_MonthToAccrue.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_MonthToAccrue.TabIndex = 0
            Me.LabelForm_MonthToAccrue.Text = "Month To Accrue"
            '
            'IntegerInputForm_Year
            '
            Me.NumericInputForm_Year.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputForm_Year.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputForm_Year.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputForm_Year.EnterMoveNextControl = True
            Me.NumericInputForm_Year.Location = New System.Drawing.Point(312, 38)
            Me.NumericInputForm_Year.Name = "IntegerInputForm_Year"
            Me.NumericInputForm_Year.Properties.DisplayFormat.FormatString = "0000"
            Me.NumericInputForm_Year.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_Year.Properties.EditFormat.FormatString = "0000"
            Me.NumericInputForm_Year.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_Year.Properties.IsFloatValue = False
            Me.NumericInputForm_Year.Properties.Mask.EditMask = "0000"
            Me.NumericInputForm_Year.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputForm_Year.Properties.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
            Me.NumericInputForm_Year.SecurityEnabled = True
            Me.NumericInputForm_Year.Size = New System.Drawing.Size(114, 20)
            Me.NumericInputForm_Year.TabIndex = 4
            '
            'ComboBoxForm_Month
            '
            Me.ComboBoxForm_Month.AddInactiveItemsOnSelectedValue = False
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
            Me.ComboBoxForm_Month.Location = New System.Drawing.Point(102, 38)
            Me.ComboBoxForm_Month.Name = "ComboBoxForm_Month"
            Me.ComboBoxForm_Month.ReadOnly = False
            Me.ComboBoxForm_Month.SecurityEnabled = True
            Me.ComboBoxForm_Month.Size = New System.Drawing.Size(114, 20)
            Me.ComboBoxForm_Month.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Month.TabIndex = 2
            Me.ComboBoxForm_Month.TabOnEnter = True
            Me.ComboBoxForm_Month.ValueMember = "Key"
            Me.ComboBoxForm_Month.WatermarkText = "Select Month"
            '
            'LabelForm_ProcessYear
            '
            Me.LabelForm_ProcessYear.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_ProcessYear.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_ProcessYear.Location = New System.Drawing.Point(222, 38)
            Me.LabelForm_ProcessYear.Name = "LabelForm_ProcessYear"
            Me.LabelForm_ProcessYear.Size = New System.Drawing.Size(84, 20)
            Me.LabelForm_ProcessYear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ProcessYear.TabIndex = 3
            Me.LabelForm_ProcessYear.Text = "Process Year:"
            '
            'LabelForm_AccrualsNeverProcessed
            '
            Me.LabelForm_AccrualsNeverProcessed.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_AccrualsNeverProcessed.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_AccrualsNeverProcessed.Location = New System.Drawing.Point(12, 64)
            Me.LabelForm_AccrualsNeverProcessed.Name = "LabelForm_AccrualsNeverProcessed"
            Me.LabelForm_AccrualsNeverProcessed.Size = New System.Drawing.Size(414, 20)
            Me.LabelForm_AccrualsNeverProcessed.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_AccrualsNeverProcessed.TabIndex = 5
            Me.LabelForm_AccrualsNeverProcessed.Text = "Accruals have never been processed before."
            '
            'AccruePaidTimeOffDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(438, 122)
            Me.Controls.Add(Me.LabelForm_AccrualsNeverProcessed)
            Me.Controls.Add(Me.LabelForm_ProcessYear)
            Me.Controls.Add(Me.ComboBoxForm_Month)
            Me.Controls.Add(Me.LabelForm_MonthToAccrue)
            Me.Controls.Add(Me.LabelForm_ProcessMonth)
            Me.Controls.Add(Me.NumericInputForm_Year)
            Me.Controls.Add(Me.ButtonForm_Close)
            Me.Controls.Add(Me.ButtonForm_Process)
            Me.Controls.Add(Me.LabelForm_LastAccrual)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "AccruePaidTimeOffDialog"
            Me.Text = "Accrue Paid Time Off"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Close As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Process As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_ProcessMonth As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_LastAccrual As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_MonthToAccrue As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents NumericInputForm_Year As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents ComboBoxForm_Month As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_ProcessYear As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_AccrualsNeverProcessed As AdvantageFramework.WinForm.Presentation.Controls.Label
    End Class

End Namespace