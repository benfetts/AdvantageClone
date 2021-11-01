Namespace WinForm.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class NumericInputDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NumericInputDialog))
            Me.LabelForm_Message = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.NumericInputForm_Input = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            CType(Me.NumericInputForm_Input.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'LabelForm_Message
            '
            Me.LabelForm_Message.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_Message.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Message.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Message.Location = New System.Drawing.Point(13, 13)
            Me.LabelForm_Message.Margin = New System.Windows.Forms.Padding(4)
            Me.LabelForm_Message.Name = "LabelForm_Message"
            Me.LabelForm_Message.Size = New System.Drawing.Size(299, 55)
            Me.LabelForm_Message.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Message.TabIndex = 0
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(237, 104)
            Me.ButtonForm_Cancel.Margin = New System.Windows.Forms.Padding(4)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 3
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(154, 104)
            Me.ButtonForm_OK.Margin = New System.Windows.Forms.Padding(4)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 2
            Me.ButtonForm_OK.Text = "OK"
            '
            'NumericInputForm_Input
            '
            Me.NumericInputForm_Input.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputForm_Input.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.NumericInputForm_Input.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Default]
            Me.NumericInputForm_Input.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputForm_Input.EnterMoveNextControl = True
            Me.NumericInputForm_Input.Location = New System.Drawing.Point(13, 76)
            Me.NumericInputForm_Input.Margin = New System.Windows.Forms.Padding(4)
            Me.NumericInputForm_Input.Name = "NumericInputForm_Input"
            Me.NumericInputForm_Input.Properties.AllowMouseWheel = False
            Me.NumericInputForm_Input.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control
            Me.NumericInputForm_Input.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputForm_Input.SecurityEnabled = True
            Me.NumericInputForm_Input.Size = New System.Drawing.Size(299, 20)
            Me.NumericInputForm_Input.TabIndex = 1
            '
            'NumericInputDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.AutoSize = True
            Me.ClientSize = New System.Drawing.Size(325, 137)
            Me.Controls.Add(Me.NumericInputForm_Input)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.LabelForm_Message)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
            Me.Name = "NumericInputDialog"
            Me.Text = "NumericInputDialog"
            CType(Me.NumericInputForm_Input.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents LabelForm_Message As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents NumericInputForm_Input As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
    End Class

End Namespace