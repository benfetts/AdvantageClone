Namespace Billing.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AvaTaxProcessDialog
        Inherits System.Windows.Forms.Form

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
            Me.ProgressBarForm_Progress = New System.Windows.Forms.ProgressBar()
            Me.SuspendLayout()
            '
            'ProgressBarForm_Progress
            '
            Me.ProgressBarForm_Progress.Location = New System.Drawing.Point(12, 32)
            Me.ProgressBarForm_Progress.Name = "ProgressBarForm_Progress"
            Me.ProgressBarForm_Progress.Size = New System.Drawing.Size(648, 23)
            Me.ProgressBarForm_Progress.TabIndex = 0
            '
            'AvaTaxProcessDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(672, 86)
            Me.ControlBox = False
            Me.Controls.Add(Me.ProgressBarForm_Progress)
            Me.DoubleBuffered = True
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.Name = "AvaTaxProcessDialog"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Calculating AvaTax"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ProgressBarForm_Progress As System.Windows.Forms.ProgressBar
    End Class

End Namespace