Namespace Maintenance.Client.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class SortOptionsDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SortOptionsDialog))
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Add = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_SortOption = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_SortOption = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'DefaultLookAndFeelOffice2010Blue
            '
            Me.DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(285, 38)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 3
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ButtonForm_Add
            '
            Me.ButtonForm_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Add.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Add.Location = New System.Drawing.Point(204, 38)
            Me.ButtonForm_Add.Name = "ButtonForm_Add"
            Me.ButtonForm_Add.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Add.TabIndex = 2
            Me.ButtonForm_Add.Text = "Add"
            '
            'LabelForm_SortOption
            '
            Me.LabelForm_SortOption.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_SortOption.BackgroundStyle.Class = ""
            Me.LabelForm_SortOption.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_SortOption.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_SortOption.Name = "LabelForm_SortOption"
            Me.LabelForm_SortOption.Size = New System.Drawing.Size(72, 20)
            Me.LabelForm_SortOption.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_SortOption.TabIndex = 0
            Me.LabelForm_SortOption.Text = "Sort Option:"
            '
            'TextBoxForm_SortOption
            '
            '
            '
            '
            Me.TextBoxForm_SortOption.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_SortOption.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_SortOption.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_SortOption.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_SortOption.FocusHighlightEnabled = True
            Me.TextBoxForm_SortOption.Location = New System.Drawing.Point(90, 12)
            Me.TextBoxForm_SortOption.Name = "TextBoxForm_SortOption"
            Me.TextBoxForm_SortOption.Size = New System.Drawing.Size(270, 20)
            Me.TextBoxForm_SortOption.TabIndex = 1
            Me.TextBoxForm_SortOption.TabOnEnter = True
            '
            'SortOptionsDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(372, 70)
            Me.Controls.Add(Me.TextBoxForm_SortOption)
            Me.Controls.Add(Me.LabelForm_SortOption)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.ButtonForm_Add)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "SortOptionsDialog"
            Me.Text = "Add Sort Option"
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Add As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_SortOption As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_SortOption As AdvantageFramework.WinForm.Presentation.Controls.TextBox
    End Class

End Namespace