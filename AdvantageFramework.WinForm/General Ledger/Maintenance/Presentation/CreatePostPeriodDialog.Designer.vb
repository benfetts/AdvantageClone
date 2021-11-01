Namespace GeneralLedger.Maintenance.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class CreatePostPeriodDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CreatePostPeriodDialog))
            Me.ButtonForm_Add = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_Year = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Header = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.NumericInputForm_Year = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.RadioButtonControlForm_Open = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlForm_Closed = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.LabelForm_DefaultStatus = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Note = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            CType(Me.NumericInputForm_Year.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ButtonForm_Add
            '
            Me.ButtonForm_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Add.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Add.Location = New System.Drawing.Point(182, 120)
            Me.ButtonForm_Add.Name = "ButtonForm_Add"
            Me.ButtonForm_Add.SecurityEnabled = True
            Me.ButtonForm_Add.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Add.TabIndex = 7
            Me.ButtonForm_Add.Text = "Add"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(263, 120)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 8
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'LabelForm_Year
            '
            Me.LabelForm_Year.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Year.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Year.Location = New System.Drawing.Point(12, 42)
            Me.LabelForm_Year.Name = "LabelForm_Year"
            Me.LabelForm_Year.Size = New System.Drawing.Size(77, 20)
            Me.LabelForm_Year.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Year.TabIndex = 1
            Me.LabelForm_Year.Text = "Year:"
            '
            'LabelForm_Header
            '
            Me.LabelForm_Header.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_Header.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Header.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_Header.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.LabelForm_Header.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_Header.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.LabelForm_Header.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_Header.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_Header.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_Header.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Header.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelForm_Header.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_Header.Name = "LabelForm_Header"
            Me.LabelForm_Header.Size = New System.Drawing.Size(326, 24)
            Me.LabelForm_Header.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Header.TabIndex = 0
            Me.LabelForm_Header.Text = "Create a New Group of Posting Periods"
            '
            'NumericInputForm_Year
            '
            Me.NumericInputForm_Year.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputForm_Year.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputForm_Year.Location = New System.Drawing.Point(95, 42)
            Me.NumericInputForm_Year.Name = "NumericInputForm_Year"
            Me.NumericInputForm_Year.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputForm_Year.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputForm_Year.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_Year.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputForm_Year.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_Year.Properties.IsFloatValue = False
            Me.NumericInputForm_Year.Properties.Mask.EditMask = "f0"
            Me.NumericInputForm_Year.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputForm_Year.Properties.MaxLength = 11
            Me.NumericInputForm_Year.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputForm_Year.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputForm_Year.Size = New System.Drawing.Size(75, 20)
            Me.NumericInputForm_Year.TabIndex = 2
            '
            'RadioButtonControlForm_Open
            '
            '
            '
            '
            Me.RadioButtonControlForm_Open.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlForm_Open.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlForm_Open.Location = New System.Drawing.Point(95, 68)
            Me.RadioButtonControlForm_Open.Name = "RadioButtonControlForm_Open"
            Me.RadioButtonControlForm_Open.Size = New System.Drawing.Size(75, 20)
            Me.RadioButtonControlForm_Open.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlForm_Open.TabIndex = 4
            Me.RadioButtonControlForm_Open.TabStop = False
            Me.RadioButtonControlForm_Open.Text = "Open"
            '
            'RadioButtonControlForm_Closed
            '
            '
            '
            '
            Me.RadioButtonControlForm_Closed.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlForm_Closed.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlForm_Closed.Location = New System.Drawing.Point(176, 68)
            Me.RadioButtonControlForm_Closed.Name = "RadioButtonControlForm_Closed"
            Me.RadioButtonControlForm_Closed.Size = New System.Drawing.Size(162, 20)
            Me.RadioButtonControlForm_Closed.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlForm_Closed.TabIndex = 5
            Me.RadioButtonControlForm_Closed.TabStop = False
            Me.RadioButtonControlForm_Closed.Text = "Closed"
            '
            'LabelForm_DefaultStatus
            '
            Me.LabelForm_DefaultStatus.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_DefaultStatus.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_DefaultStatus.Location = New System.Drawing.Point(12, 68)
            Me.LabelForm_DefaultStatus.Name = "LabelForm_DefaultStatus"
            Me.LabelForm_DefaultStatus.Size = New System.Drawing.Size(77, 20)
            Me.LabelForm_DefaultStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_DefaultStatus.TabIndex = 3
            Me.LabelForm_DefaultStatus.Text = "Default Status:"
            '
            'LabelForm_Note
            '
            Me.LabelForm_Note.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_Note.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Note.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Note.ForeColor = System.Drawing.Color.Red
            Me.LabelForm_Note.Location = New System.Drawing.Point(12, 94)
            Me.LabelForm_Note.Name = "LabelForm_Note"
            Me.LabelForm_Note.Size = New System.Drawing.Size(326, 20)
            Me.LabelForm_Note.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Note.TabIndex = 6
            Me.LabelForm_Note.Text = "If any of the posting periods exist, the status will not be changed."
            '
            'CreatePostPeriodDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(350, 152)
            Me.Controls.Add(Me.LabelForm_Note)
            Me.Controls.Add(Me.LabelForm_DefaultStatus)
            Me.Controls.Add(Me.RadioButtonControlForm_Closed)
            Me.Controls.Add(Me.RadioButtonControlForm_Open)
            Me.Controls.Add(Me.NumericInputForm_Year)
            Me.Controls.Add(Me.LabelForm_Header)
            Me.Controls.Add(Me.LabelForm_Year)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.ButtonForm_Add)
            Me.DoubleBuffered = True
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "CreatePostPeriodDialog"
            Me.Text = "Post Period"
            CType(Me.NumericInputForm_Year.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Add As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_Year As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Header As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents NumericInputForm_Year As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents RadioButtonControlForm_Open As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlForm_Closed As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents LabelForm_DefaultStatus As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Note As AdvantageFramework.WinForm.Presentation.Controls.Label
    End Class

End Namespace