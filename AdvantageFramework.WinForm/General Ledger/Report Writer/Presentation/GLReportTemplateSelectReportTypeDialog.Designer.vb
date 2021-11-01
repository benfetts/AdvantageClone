Namespace GeneralLedger.ReportWriter.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class GLReportTemplateSelectReportTypeDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GLReportTemplateSelectReportTypeDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_IncomeStatement = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_BalanceSheet = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Other = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(168, 118)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 7
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(249, 118)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 16
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ButtonForm_IncomeStatement
            '
            Me.ButtonForm_IncomeStatement.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_IncomeStatement.AutoCheckOnClick = True
            Me.ButtonForm_IncomeStatement.Checked = True
            Me.ButtonForm_IncomeStatement.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_IncomeStatement.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonForm_IncomeStatement.Location = New System.Drawing.Point(12, 12)
            Me.ButtonForm_IncomeStatement.Name = "ButtonForm_IncomeStatement"
            Me.ButtonForm_IncomeStatement.SecurityEnabled = True
            Me.ButtonForm_IncomeStatement.Size = New System.Drawing.Size(100, 100)
            Me.ButtonForm_IncomeStatement.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_IncomeStatement.TabIndex = 17
            Me.ButtonForm_IncomeStatement.Text = "Income Statement"
            '
            'ButtonForm_BalanceSheet
            '
            Me.ButtonForm_BalanceSheet.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_BalanceSheet.AutoCheckOnClick = True
            Me.ButtonForm_BalanceSheet.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_BalanceSheet.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonForm_BalanceSheet.Location = New System.Drawing.Point(118, 12)
            Me.ButtonForm_BalanceSheet.Name = "ButtonForm_BalanceSheet"
            Me.ButtonForm_BalanceSheet.SecurityEnabled = True
            Me.ButtonForm_BalanceSheet.Size = New System.Drawing.Size(100, 100)
            Me.ButtonForm_BalanceSheet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_BalanceSheet.TabIndex = 18
            Me.ButtonForm_BalanceSheet.Text = "Balance Sheet"
            '
            'ButtonForm_Other
            '
            Me.ButtonForm_Other.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Other.AutoCheckOnClick = True
            Me.ButtonForm_Other.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Other.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonForm_Other.Location = New System.Drawing.Point(224, 12)
            Me.ButtonForm_Other.Name = "ButtonForm_Other"
            Me.ButtonForm_Other.SecurityEnabled = True
            Me.ButtonForm_Other.Size = New System.Drawing.Size(100, 100)
            Me.ButtonForm_Other.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Other.TabIndex = 19
            Me.ButtonForm_Other.Text = "Other"
            '
            'GLReportTemplateSelectReportTypeDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(336, 150)
            Me.Controls.Add(Me.ButtonForm_Other)
            Me.Controls.Add(Me.ButtonForm_BalanceSheet)
            Me.Controls.Add(Me.ButtonForm_IncomeStatement)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "GLReportTemplateSelectReportTypeDialog"
            Me.Text = "Select Report Type"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_IncomeStatement As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_BalanceSheet As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Other As AdvantageFramework.WinForm.Presentation.Controls.Button
    End Class

End Namespace