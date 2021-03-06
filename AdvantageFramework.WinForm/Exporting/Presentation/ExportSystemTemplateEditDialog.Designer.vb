Namespace Exporting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ExportSystemTemplateEditDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExportSystemTemplateEditDialog))
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Update = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_DefaultDirectory = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_DefaultDirectory = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.SuspendLayout()
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(504, 39)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 5
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ButtonForm_Update
            '
            Me.ButtonForm_Update.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Update.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Update.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Update.Location = New System.Drawing.Point(423, 39)
            Me.ButtonForm_Update.Name = "ButtonForm_Update"
            Me.ButtonForm_Update.SecurityEnabled = True
            Me.ButtonForm_Update.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Update.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Update.TabIndex = 4
            Me.ButtonForm_Update.Text = "Update"
            '
            'LabelForm_DefaultDirectory
            '
            Me.LabelForm_DefaultDirectory.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_DefaultDirectory.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_DefaultDirectory.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_DefaultDirectory.Name = "LabelForm_DefaultDirectory"
            Me.LabelForm_DefaultDirectory.Size = New System.Drawing.Size(96, 20)
            Me.LabelForm_DefaultDirectory.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_DefaultDirectory.TabIndex = 0
            Me.LabelForm_DefaultDirectory.Text = "Default Directory:"
            '
            'TextBoxForm_DefaultDirectory
            '
            Me.TextBoxForm_DefaultDirectory.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxForm_DefaultDirectory.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxForm_DefaultDirectory.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_DefaultDirectory.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_DefaultDirectory.ButtonCustom.Visible = True
            Me.TextBoxForm_DefaultDirectory.CheckSpellingOnValidate = False
            Me.TextBoxForm_DefaultDirectory.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.Folder
            Me.TextBoxForm_DefaultDirectory.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_DefaultDirectory.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_DefaultDirectory.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_DefaultDirectory.FocusHighlightEnabled = True
            Me.TextBoxForm_DefaultDirectory.ForeColor = System.Drawing.Color.Black
            Me.TextBoxForm_DefaultDirectory.Location = New System.Drawing.Point(114, 12)
            Me.TextBoxForm_DefaultDirectory.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_DefaultDirectory.Name = "TextBoxForm_DefaultDirectory"
            Me.TextBoxForm_DefaultDirectory.SecurityEnabled = True
            Me.TextBoxForm_DefaultDirectory.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_DefaultDirectory.Size = New System.Drawing.Size(465, 20)
            Me.TextBoxForm_DefaultDirectory.StartingFolderName = Nothing
            Me.TextBoxForm_DefaultDirectory.TabIndex = 1
            Me.TextBoxForm_DefaultDirectory.TabOnEnter = True
            '
            'ExportSystemTemplateEditDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(591, 71)
            Me.Controls.Add(Me.TextBoxForm_DefaultDirectory)
            Me.Controls.Add(Me.LabelForm_DefaultDirectory)
            Me.Controls.Add(Me.ButtonForm_Update)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ExportSystemTemplateEditDialog"
            Me.Text = "Edit System Template"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Create As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Update As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_DefaultDirectory As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_DefaultDirectory As AdvantageFramework.WinForm.Presentation.Controls.TextBox
    End Class

End Namespace