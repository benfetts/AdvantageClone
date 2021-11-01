<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SplashScreen
    Inherits DevExpress.XtraSplashScreen.SplashScreen

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
        Me.LabelLoading = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.SuspendLayout()
        '
        'LabelLoading
        '
        Me.LabelLoading.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelLoading.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelLoading.ForeColor = System.Drawing.Color.White
        Me.LabelLoading.Location = New System.Drawing.Point(142, 197)
        Me.LabelLoading.Name = "LabelLoading"
        Me.LabelLoading.Size = New System.Drawing.Size(214, 20)
        Me.LabelLoading.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelLoading.TabIndex = 15
        Me.LabelLoading.Text = "Loading"
        '
        'SplashScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(498, 298)
        Me.Controls.Add(Me.LabelLoading)
        Me.ForeColor = System.Drawing.Color.Transparent
        Me.MaximumSize = New System.Drawing.Size(498, 298)
        Me.MinimumSize = New System.Drawing.Size(498, 298)
        Me.Name = "SplashScreen"
        Me.ShowMode = DevExpress.XtraSplashScreen.ShowMode.Image
        Me.SplashImageOptions.Image = Global.Advantage.My.Resources.Resources.AquaNewSplashImage
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelLoading As AdvantageFramework.WinForm.Presentation.Controls.Label
End Class
