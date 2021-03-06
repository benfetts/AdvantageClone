Namespace WinForm.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class TextBoxInputDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TextBoxInputDialog))
            Me.LabelForm_Message = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_Input = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.SuspendLayout()
            '
            'LabelForm_Message
            '
            Me.LabelForm_Message.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_Message.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Message.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Message.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_Message.Name = "LabelForm_Message"
            Me.LabelForm_Message.Size = New System.Drawing.Size(460, 55)
            Me.LabelForm_Message.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Message.TabIndex = 0
            '
            'TextBoxForm_Input
            '
            Me.TextBoxForm_Input.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxForm_Input.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Input.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Input.CheckSpellingOnValidate = False
            Me.TextBoxForm_Input.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Input.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_Input.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Input.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Input.FocusHighlightEnabled = True
            Me.TextBoxForm_Input.Location = New System.Drawing.Point(12, 73)
            Me.TextBoxForm_Input.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Input.Multiline = True
            Me.TextBoxForm_Input.Name = "TextBoxForm_Input"
            Me.TextBoxForm_Input.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Input.Size = New System.Drawing.Size(460, 151)
            Me.TextBoxForm_Input.TabIndex = 1
            Me.TextBoxForm_Input.TabOnEnter = True
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(397, 230)
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
            Me.ButtonForm_OK.Location = New System.Drawing.Point(316, 230)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 2
            Me.ButtonForm_OK.Text = "OK"
            '
            'TextBoxInputDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(484, 262)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.TextBoxForm_Input)
            Me.Controls.Add(Me.LabelForm_Message)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "TextBoxInputDialog"
            Me.Text = "TextBoxInputDialog"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents LabelForm_Message As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_Input As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
    End Class

End Namespace