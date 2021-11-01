Namespace Maintenance.Client.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class DiaryAddDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DiaryAddDialog))
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_Subject = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_Subject = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_Body = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ButtonForm_Add = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.TextBoxForm_Body = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.ButtonForm_Update = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.SuspendLayout()
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(520, 289)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 5
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'LabelForm_Subject
            '
            Me.LabelForm_Subject.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Subject.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Subject.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_Subject.Name = "LabelForm_Subject"
            Me.LabelForm_Subject.Size = New System.Drawing.Size(69, 20)
            Me.LabelForm_Subject.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Subject.TabIndex = 0
            Me.LabelForm_Subject.Text = "Subject:"
            '
            'TextBoxForm_Subject
            '
            '
            '
            '
            Me.TextBoxForm_Subject.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Subject.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Subject.CheckSpellingOnValidate = False
            Me.TextBoxForm_Subject.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Subject.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_Subject.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Subject.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Subject.FocusHighlightEnabled = True
            Me.TextBoxForm_Subject.Location = New System.Drawing.Point(87, 12)
            Me.TextBoxForm_Subject.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Subject.Name = "TextBoxForm_Subject"
            Me.TextBoxForm_Subject.ShortcutsEnabled = True
            Me.TextBoxForm_Subject.Size = New System.Drawing.Size(508, 20)
            Me.TextBoxForm_Subject.TabIndex = 1
            Me.TextBoxForm_Subject.TabOnEnter = True
            '
            'LabelForm_Body
            '
            Me.LabelForm_Body.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Body.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Body.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_Body.Name = "LabelForm_Body"
            Me.LabelForm_Body.Size = New System.Drawing.Size(69, 20)
            Me.LabelForm_Body.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Body.TabIndex = 2
            Me.LabelForm_Body.Text = "Body:"
            '
            'ButtonForm_Add
            '
            Me.ButtonForm_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Add.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Add.Location = New System.Drawing.Point(439, 289)
            Me.ButtonForm_Add.Name = "ButtonForm_Add"
            Me.ButtonForm_Add.SecurityEnabled = True
            Me.ButtonForm_Add.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Add.TabIndex = 4
            Me.ButtonForm_Add.Text = "Add"
            '
            'TextBoxForm_Body
            '
            '
            '
            '
            Me.TextBoxForm_Body.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Body.CheckSpellingOnValidate = False
            Me.TextBoxForm_Body.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Body.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_Body.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Body.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Body.FocusHighlightEnabled = True
            Me.TextBoxForm_Body.Location = New System.Drawing.Point(87, 38)
            Me.TextBoxForm_Body.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Body.Multiline = True
            Me.TextBoxForm_Body.Name = "TextBoxForm_Body"
            Me.TextBoxForm_Body.ShortcutsEnabled = True
            Me.TextBoxForm_Body.Size = New System.Drawing.Size(508, 245)
            Me.TextBoxForm_Body.TabIndex = 3
            Me.TextBoxForm_Body.TabOnEnter = True
            '
            'ButtonForm_Update
            '
            Me.ButtonForm_Update.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Update.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Update.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Update.Location = New System.Drawing.Point(439, 289)
            Me.ButtonForm_Update.Name = "ButtonForm_Update"
            Me.ButtonForm_Update.SecurityEnabled = True
            Me.ButtonForm_Update.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Update.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Update.TabIndex = 6
            Me.ButtonForm_Update.Text = "Update"
            '
            'DiaryAddDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(607, 321)
            Me.Controls.Add(Me.ButtonForm_Update)
            Me.Controls.Add(Me.TextBoxForm_Body)
            Me.Controls.Add(Me.ButtonForm_Add)
            Me.Controls.Add(Me.LabelForm_Body)
            Me.Controls.Add(Me.LabelForm_Subject)
            Me.Controls.Add(Me.TextBoxForm_Subject)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.DoubleBuffered = True
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "DiaryAddDialog"
            Me.Text = "Diary"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_Subject As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_Subject As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_Body As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonForm_Add As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents TextBoxForm_Body As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents ButtonForm_Update As AdvantageFramework.WinForm.Presentation.Controls.Button
    End Class

End Namespace