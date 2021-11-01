Namespace Employee.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ExpenseReportPrintOptionsDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExpenseReportPrintOptionsDialog))
            Me.ButtonForm_Print = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.CheckBoxForm_PrintSupervisiorName = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_ExcludeEmployeeSignature = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxIncludeReceipts = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.SuspendLayout()
            '
            'ButtonForm_Print
            '
            Me.ButtonForm_Print.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Print.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Print.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Print.Location = New System.Drawing.Point(109, 110)
            Me.ButtonForm_Print.Name = "ButtonForm_Print"
            Me.ButtonForm_Print.SecurityEnabled = True
            Me.ButtonForm_Print.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Print.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Print.TabIndex = 2
            Me.ButtonForm_Print.Text = "Print"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(190, 110)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 3
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'CheckBoxForm_PrintSupervisiorName
            '
            '
            '
            '
            Me.CheckBoxForm_PrintSupervisiorName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_PrintSupervisiorName.CheckValue = 0
            Me.CheckBoxForm_PrintSupervisiorName.CheckValueChecked = 1
            Me.CheckBoxForm_PrintSupervisiorName.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_PrintSupervisiorName.CheckValueUnchecked = 0
            Me.CheckBoxForm_PrintSupervisiorName.ChildControls = CType(resources.GetObject("CheckBoxForm_PrintSupervisiorName.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_PrintSupervisiorName.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_PrintSupervisiorName.Location = New System.Drawing.Point(12, 12)
            Me.CheckBoxForm_PrintSupervisiorName.Name = "CheckBoxForm_PrintSupervisiorName"
            Me.CheckBoxForm_PrintSupervisiorName.OldestSibling = Nothing
            Me.CheckBoxForm_PrintSupervisiorName.SecurityEnabled = True
            Me.CheckBoxForm_PrintSupervisiorName.SiblingControls = CType(resources.GetObject("CheckBoxForm_PrintSupervisiorName.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_PrintSupervisiorName.Size = New System.Drawing.Size(253, 20)
            Me.CheckBoxForm_PrintSupervisiorName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_PrintSupervisiorName.TabIndex = 4
            Me.CheckBoxForm_PrintSupervisiorName.TabOnEnter = True
            Me.CheckBoxForm_PrintSupervisiorName.Text = "Print Supervisor Name Below Signature Line"
            '
            'CheckBoxForm_ExcludeEmployeeSignature
            '
            '
            '
            '
            Me.CheckBoxForm_ExcludeEmployeeSignature.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_ExcludeEmployeeSignature.CheckValue = 0
            Me.CheckBoxForm_ExcludeEmployeeSignature.CheckValueChecked = 1
            Me.CheckBoxForm_ExcludeEmployeeSignature.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_ExcludeEmployeeSignature.CheckValueUnchecked = 0
            Me.CheckBoxForm_ExcludeEmployeeSignature.ChildControls = CType(resources.GetObject("CheckBoxForm_ExcludeEmployeeSignature.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_ExcludeEmployeeSignature.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_ExcludeEmployeeSignature.Location = New System.Drawing.Point(12, 38)
            Me.CheckBoxForm_ExcludeEmployeeSignature.Name = "CheckBoxForm_ExcludeEmployeeSignature"
            Me.CheckBoxForm_ExcludeEmployeeSignature.OldestSibling = Nothing
            Me.CheckBoxForm_ExcludeEmployeeSignature.SecurityEnabled = True
            Me.CheckBoxForm_ExcludeEmployeeSignature.SiblingControls = CType(resources.GetObject("CheckBoxForm_ExcludeEmployeeSignature.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_ExcludeEmployeeSignature.Size = New System.Drawing.Size(253, 20)
            Me.CheckBoxForm_ExcludeEmployeeSignature.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_ExcludeEmployeeSignature.TabIndex = 5
            Me.CheckBoxForm_ExcludeEmployeeSignature.TabOnEnter = True
            Me.CheckBoxForm_ExcludeEmployeeSignature.Text = "Exclude Employee Signature"
            '
            'CheckBoxIncludeReceipts
            '
            '
            '
            '
            Me.CheckBoxIncludeReceipts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxIncludeReceipts.CheckValue = 0
            Me.CheckBoxIncludeReceipts.CheckValueChecked = 1
            Me.CheckBoxIncludeReceipts.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxIncludeReceipts.CheckValueUnchecked = 0
            Me.CheckBoxIncludeReceipts.ChildControls = CType(resources.GetObject("CheckBoxIncludeReceipts.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxIncludeReceipts.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxIncludeReceipts.Location = New System.Drawing.Point(12, 64)
            Me.CheckBoxIncludeReceipts.Name = "CheckBoxIncludeReceipts"
            Me.CheckBoxIncludeReceipts.OldestSibling = Nothing
            Me.CheckBoxIncludeReceipts.SecurityEnabled = True
            Me.CheckBoxIncludeReceipts.SiblingControls = CType(resources.GetObject("CheckBoxIncludeReceipts.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxIncludeReceipts.Size = New System.Drawing.Size(253, 20)
            Me.CheckBoxIncludeReceipts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxIncludeReceipts.TabIndex = 6
            Me.CheckBoxIncludeReceipts.TabOnEnter = True
            Me.CheckBoxIncludeReceipts.Text = "Include Receipts"
            '
            'ExpenseReportPrintOptionsDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(277, 142)
            Me.Controls.Add(Me.CheckBoxIncludeReceipts)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.CheckBoxForm_PrintSupervisiorName)
            Me.Controls.Add(Me.ButtonForm_Print)
            Me.Controls.Add(Me.CheckBoxForm_ExcludeEmployeeSignature)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ExpenseReportPrintOptionsDialog"
            Me.Text = "Expense Report"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Print As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents CheckBoxForm_PrintSupervisiorName As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_ExcludeEmployeeSignature As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxIncludeReceipts As WinForm.Presentation.Controls.CheckBox
    End Class

End Namespace