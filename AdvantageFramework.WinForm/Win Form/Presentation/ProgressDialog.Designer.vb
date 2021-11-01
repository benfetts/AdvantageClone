Namespace WinForm.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ProgressDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProgressDialog))
            Me.ProgressBarForm_Progress = New AdvantageFramework.WinForm.Presentation.Controls.ProgressBar()
            Me.LabelForm_Status = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.SuspendLayout()
            '
            'pbForm_Progress
            '
            Me.ProgressBarForm_Progress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ProgressBarForm_Progress.Location = New System.Drawing.Point(12, 12)
            Me.ProgressBarForm_Progress.Name = "ProgressBarForm_Progress"
            Me.ProgressBarForm_Progress.Size = New System.Drawing.Size(494, 20)
            Me.ProgressBarForm_Progress.TabIndex = 0
            '
            'lblForm_Status
            '
            Me.LabelForm_Status.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_Status.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_Status.Name = "LabelForm_Status"
            Me.LabelForm_Status.Size = New System.Drawing.Size(413, 20)
            Me.LabelForm_Status.TabIndex = 1
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(431, 38)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.TabIndex = 2
            Me.ButtonForm_Cancel.Text = "Cancel"
            Me.ButtonForm_Cancel.Visible = False
            '
            'ProgressDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(518, 70)
            Me.ControlBox = False
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.LabelForm_Status)
            Me.Controls.Add(Me.ProgressBarForm_Progress)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "ProgressDialog"
            Me.Text = "Progress..."
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ProgressBarForm_Progress As AdvantageFramework.WinForm.Presentation.Controls.ProgressBar
        Friend WithEvents LabelForm_Status As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
    End Class

End Namespace