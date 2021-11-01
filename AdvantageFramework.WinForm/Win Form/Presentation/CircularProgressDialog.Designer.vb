Namespace WinForm.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class CircularProgressDialog
        Inherits DevComponents.DotNetBar.Office2007Form

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
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CircularProgressDialog))
            Me.CircularProgress = New DevComponents.DotNetBar.Controls.CircularProgress()
            Me.StyleManager = New DevComponents.DotNetBar.StyleManager(Me.components)
            Me.LabelForm_Text = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SuspendLayout()
            '
            'CircularProgress
            '
            '
            '
            '
            Me.CircularProgress.BackgroundStyle.Class = ""
            Me.CircularProgress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CircularProgress.FocusCuesEnabled = False
            Me.CircularProgress.Location = New System.Drawing.Point(12, 12)
            Me.CircularProgress.Name = "CircularProgress"
            Me.CircularProgress.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot
            Me.CircularProgress.ProgressColor = System.Drawing.Color.DarkOrange
            Me.CircularProgress.Size = New System.Drawing.Size(85, 89)
            Me.CircularProgress.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CircularProgress.TabIndex = 1
            Me.CircularProgress.TabStop = False
            Me.CircularProgress.Value = 100
            '
            'StyleManager
            '
            Me.StyleManager.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2013
            '
            'LabelForm_Text
            '
            Me.LabelForm_Text.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Text.BackgroundStyle.Class = ""
            Me.LabelForm_Text.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Text.Location = New System.Drawing.Point(103, 43)
            Me.LabelForm_Text.Name = "LabelForm_Text"
            Me.LabelForm_Text.Size = New System.Drawing.Size(320, 23)
            Me.LabelForm_Text.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Text.TabIndex = 2
            '
            'CircularProgressDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(435, 113)
            Me.ControlBox = False
            Me.Controls.Add(Me.LabelForm_Text)
            Me.Controls.Add(Me.CircularProgress)
            Me.DoubleBuffered = True
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "CircularProgressDialog"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.TopMost = True
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents CircularProgress As DevComponents.DotNetBar.Controls.CircularProgress
        Friend WithEvents LabelForm_Text As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents StyleManager As DevComponents.DotNetBar.StyleManager
    End Class

End Namespace