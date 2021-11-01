Namespace ProjectManagement.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class PurchaseOrderSubmitDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PurchaseOrderSubmitDialog))
            Me.ButtonForm_GetApproval = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_POPrintInfo = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.RadioButtonControlForm_Highest = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlForm_High = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlForm_Normal = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlForm_Low = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlForm_Lowest = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.SuspendLayout()
            '
            'ButtonForm_GetApproval
            '
            Me.ButtonForm_GetApproval.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_GetApproval.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_GetApproval.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_GetApproval.Location = New System.Drawing.Point(205, 64)
            Me.ButtonForm_GetApproval.Name = "ButtonForm_GetApproval"
            Me.ButtonForm_GetApproval.SecurityEnabled = True
            Me.ButtonForm_GetApproval.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_GetApproval.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_GetApproval.TabIndex = 3
            Me.ButtonForm_GetApproval.Text = "Get Approval"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(286, 64)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 4
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'LabelForm_POPrintInfo
            '
            Me.LabelForm_POPrintInfo.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_POPrintInfo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_POPrintInfo.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_POPrintInfo.Name = "LabelForm_POPrintInfo"
            Me.LabelForm_POPrintInfo.Size = New System.Drawing.Size(349, 20)
            Me.LabelForm_POPrintInfo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_POPrintInfo.TabIndex = 0
            Me.LabelForm_POPrintInfo.Text = "Purchase Order cannot be printed until approved."
            '
            'RadioButtonControlForm_Highest
            '
            Me.RadioButtonControlForm_Highest.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlForm_Highest.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlForm_Highest.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlForm_Highest.Location = New System.Drawing.Point(12, 38)
            Me.RadioButtonControlForm_Highest.Name = "RadioButtonControlForm_Highest"
            Me.RadioButtonControlForm_Highest.SecurityEnabled = True
            Me.RadioButtonControlForm_Highest.Size = New System.Drawing.Size(65, 20)
            Me.RadioButtonControlForm_Highest.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlForm_Highest.TabIndex = 5
            Me.RadioButtonControlForm_Highest.TabStop = False
            Me.RadioButtonControlForm_Highest.Text = "Highest"
            '
            'RadioButtonControlForm_High
            '
            Me.RadioButtonControlForm_High.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlForm_High.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlForm_High.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlForm_High.Location = New System.Drawing.Point(83, 38)
            Me.RadioButtonControlForm_High.Name = "RadioButtonControlForm_High"
            Me.RadioButtonControlForm_High.SecurityEnabled = True
            Me.RadioButtonControlForm_High.Size = New System.Drawing.Size(65, 20)
            Me.RadioButtonControlForm_High.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlForm_High.TabIndex = 6
            Me.RadioButtonControlForm_High.TabStop = False
            Me.RadioButtonControlForm_High.Text = "High"
            '
            'RadioButtonControlForm_Normal
            '
            Me.RadioButtonControlForm_Normal.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlForm_Normal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlForm_Normal.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlForm_Normal.Location = New System.Drawing.Point(154, 38)
            Me.RadioButtonControlForm_Normal.Name = "RadioButtonControlForm_Normal"
            Me.RadioButtonControlForm_Normal.SecurityEnabled = True
            Me.RadioButtonControlForm_Normal.Size = New System.Drawing.Size(65, 20)
            Me.RadioButtonControlForm_Normal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlForm_Normal.TabIndex = 7
            Me.RadioButtonControlForm_Normal.TabStop = False
            Me.RadioButtonControlForm_Normal.Text = "Normal"
            '
            'RadioButtonControlForm_Low
            '
            Me.RadioButtonControlForm_Low.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlForm_Low.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlForm_Low.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlForm_Low.Location = New System.Drawing.Point(225, 38)
            Me.RadioButtonControlForm_Low.Name = "RadioButtonControlForm_Low"
            Me.RadioButtonControlForm_Low.SecurityEnabled = True
            Me.RadioButtonControlForm_Low.Size = New System.Drawing.Size(65, 20)
            Me.RadioButtonControlForm_Low.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlForm_Low.TabIndex = 8
            Me.RadioButtonControlForm_Low.TabStop = False
            Me.RadioButtonControlForm_Low.Text = "Low"
            '
            'RadioButtonControlForm_Lowest
            '
            Me.RadioButtonControlForm_Lowest.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlForm_Lowest.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlForm_Lowest.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlForm_Lowest.Location = New System.Drawing.Point(296, 38)
            Me.RadioButtonControlForm_Lowest.Name = "RadioButtonControlForm_Lowest"
            Me.RadioButtonControlForm_Lowest.SecurityEnabled = True
            Me.RadioButtonControlForm_Lowest.Size = New System.Drawing.Size(65, 20)
            Me.RadioButtonControlForm_Lowest.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlForm_Lowest.TabIndex = 9
            Me.RadioButtonControlForm_Lowest.TabStop = False
            Me.RadioButtonControlForm_Lowest.Text = "Lowest"
            '
            'PurchaseOrderSubmitDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(373, 96)
            Me.Controls.Add(Me.RadioButtonControlForm_Lowest)
            Me.Controls.Add(Me.RadioButtonControlForm_Low)
            Me.Controls.Add(Me.RadioButtonControlForm_Normal)
            Me.Controls.Add(Me.RadioButtonControlForm_High)
            Me.Controls.Add(Me.RadioButtonControlForm_Highest)
            Me.Controls.Add(Me.LabelForm_POPrintInfo)
            Me.Controls.Add(Me.ButtonForm_GetApproval)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "PurchaseOrderSubmitDialog"
            Me.Text = "Purchase Order Approval"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_GetApproval As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_POPrintInfo As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents RadioButtonControlForm_Highest As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlForm_High As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlForm_Normal As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlForm_Low As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlForm_Lowest As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
    End Class

End Namespace