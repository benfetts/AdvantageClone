Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaPlanDetailLevelLineTagAddDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaPlanDetailLevelLineTagAddDialog))
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.LabelForm_Description = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.TextBoxForm_Description = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.LabelForm_Code = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.TextBoxForm_Code = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.SuspendLayout()
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(457, 70)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 5
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(376, 70)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 4
            Me.ButtonForm_OK.Text = "OK"
            '
            'LabelForm_Description
            '
            Me.LabelForm_Description.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Description.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Description.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_Description.Name = "LabelForm_Description"
            Me.LabelForm_Description.Size = New System.Drawing.Size(76, 20)
            Me.LabelForm_Description.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Description.TabIndex = 2
            Me.LabelForm_Description.Text = "Description:"
            '
            'TextBoxForm_Description
            '
            Me.TextBoxForm_Description.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxForm_Description.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Description.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Description.CheckSpellingOnValidate = False
            Me.TextBoxForm_Description.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Description.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_Description.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Description.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Description.FocusHighlightEnabled = True
            Me.TextBoxForm_Description.Location = New System.Drawing.Point(94, 37)
            Me.TextBoxForm_Description.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Description.Name = "TextBoxForm_Description"
            Me.TextBoxForm_Description.PreventEnterBeep = True
            Me.TextBoxForm_Description.SecurityEnabled = True
            Me.TextBoxForm_Description.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Description.Size = New System.Drawing.Size(438, 20)
            Me.TextBoxForm_Description.StartingFolderName = Nothing
            Me.TextBoxForm_Description.TabIndex = 3
            Me.TextBoxForm_Description.TabOnEnter = True
            '
            'LabelForm_Code
            '
            Me.LabelForm_Code.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Code.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Code.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_Code.Name = "LabelForm_Code"
            Me.LabelForm_Code.Size = New System.Drawing.Size(76, 20)
            Me.LabelForm_Code.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Code.TabIndex = 0
            Me.LabelForm_Code.Text = "Code:"
            '
            'TextBoxForm_Code
            '
            '
            '
            '
            Me.TextBoxForm_Code.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Code.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Code.CheckSpellingOnValidate = False
            Me.TextBoxForm_Code.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Code.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_Code.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Code.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Code.FocusHighlightEnabled = True
            Me.TextBoxForm_Code.Location = New System.Drawing.Point(94, 12)
            Me.TextBoxForm_Code.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Code.Name = "TextBoxForm_Code"
            Me.TextBoxForm_Code.PreventEnterBeep = True
            Me.TextBoxForm_Code.SecurityEnabled = True
            Me.TextBoxForm_Code.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Code.Size = New System.Drawing.Size(438, 20)
            Me.TextBoxForm_Code.StartingFolderName = Nothing
            Me.TextBoxForm_Code.TabIndex = 1
            Me.TextBoxForm_Code.TabOnEnter = True
            '
            'MediaPlanDetailLevelLineTagAddDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(544, 102)
            Me.Controls.Add(Me.LabelForm_Description)
            Me.Controls.Add(Me.TextBoxForm_Description)
            Me.Controls.Add(Me.LabelForm_Code)
            Me.Controls.Add(Me.TextBoxForm_Code)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaPlanDetailLevelLineTagAddDialog"
            Me.Text = "Media Plan Detail Level Tag Add"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents LabelForm_Description As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_Description As WinForm.MVC.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_Code As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_Code As WinForm.MVC.Presentation.Controls.TextBox
    End Class

End Namespace