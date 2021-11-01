Namespace WinForm.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class WaitForm
        Inherits DevExpress.XtraWaitForm.WaitForm

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
            Me.ProgressPanel = New DevExpress.XtraWaitForm.ProgressPanel()
            Me.TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
            Me.SuspendLayout()
            '
            'ProgressPanel
            '
            Me.ProgressPanel.Appearance.BackColor = System.Drawing.Color.White
            Me.ProgressPanel.Appearance.Options.UseBackColor = True
            Me.ProgressPanel.AppearanceCaption.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
            Me.ProgressPanel.AppearanceCaption.Options.UseFont = True
            Me.ProgressPanel.AppearanceDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
            Me.ProgressPanel.AppearanceDescription.Options.UseFont = True
            Me.ProgressPanel.Dock = System.Windows.Forms.DockStyle.Fill
            Me.ProgressPanel.ImageHorzOffset = 20
            Me.ProgressPanel.Location = New System.Drawing.Point(0, 0)
            Me.ProgressPanel.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
            Me.ProgressPanel.Name = "ProgressPanel"
            Me.ProgressPanel.Size = New System.Drawing.Size(246, 73)
            Me.ProgressPanel.TabIndex = 0
            Me.ProgressPanel.Text = ""
            '
            'tableLayoutPanel1
            '
            Me.TableLayoutPanel.AutoSize = True
            Me.TableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.TableLayoutPanel.BackColor = System.Drawing.Color.White
            Me.TableLayoutPanel.ColumnCount = 1
            Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 246.0!))
            Me.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.TableLayoutPanel.Name = "TableLayoutPanel"
            Me.TableLayoutPanel.Padding = New System.Windows.Forms.Padding(0, 14, 0, 14)
            Me.TableLayoutPanel.RowCount = 1
            Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanel.Size = New System.Drawing.Size(246, 73)
            Me.TableLayoutPanel.TabIndex = 1
            '
            'WaitForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.AutoSize = True
            Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.ClientSize = New System.Drawing.Size(246, 73)
            Me.Controls.Add(Me.ProgressPanel)
            Me.Controls.Add(Me.TableLayoutPanel)
            Me.DoubleBuffered = True
            Me.TargetLookAndFeel.SkinName = "Office 2016 Colorful"
            Me.TargetLookAndFeel.UseDefaultLookAndFeel = False
            Me.MaximumSize = New System.Drawing.Size(246, 73)
            Me.MinimumSize = New System.Drawing.Size(246, 0)
            Me.Name = "WaitForm"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
            Me.Text = ""
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Private WithEvents ProgressPanel As DevExpress.XtraWaitForm.ProgressPanel
        Private WithEvents TableLayoutPanel As System.Windows.Forms.TableLayoutPanel
    End Class

End Namespace
