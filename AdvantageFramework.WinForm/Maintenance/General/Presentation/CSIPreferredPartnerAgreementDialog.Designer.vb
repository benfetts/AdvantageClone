Namespace Maintenance.General.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class CSIPreferredPartnerAgreementDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CSIPreferredPartnerAgreementDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.CheckBoxForm_AcceptAgreement = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.RichEditForm_Agreement = New AdvantageFramework.WinForm.Presentation.Controls.RichEditControl()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(439, 450)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 2
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(520, 450)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 3
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'CheckBoxForm_AcceptAgreement
            '
            Me.CheckBoxForm_AcceptAgreement.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxForm_AcceptAgreement.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_AcceptAgreement.CheckValue = 0
            Me.CheckBoxForm_AcceptAgreement.CheckValueChecked = 1
            Me.CheckBoxForm_AcceptAgreement.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_AcceptAgreement.CheckValueUnchecked = 0
            Me.CheckBoxForm_AcceptAgreement.ChildControls = CType(resources.GetObject("CheckBoxForm_AcceptAgreement.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_AcceptAgreement.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_AcceptAgreement.Location = New System.Drawing.Point(12, 450)
            Me.CheckBoxForm_AcceptAgreement.Name = "CheckBoxForm_AcceptAgreement"
            Me.CheckBoxForm_AcceptAgreement.OldestSibling = Nothing
            Me.CheckBoxForm_AcceptAgreement.SecurityEnabled = True
            Me.CheckBoxForm_AcceptAgreement.SiblingControls = CType(resources.GetObject("CheckBoxForm_AcceptAgreement.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_AcceptAgreement.Size = New System.Drawing.Size(421, 20)
            Me.CheckBoxForm_AcceptAgreement.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_AcceptAgreement.TabIndex = 5
            Me.CheckBoxForm_AcceptAgreement.Text = "I accept terms of the agreement"
            '
            'RichEditForm_Agreement
            '
            Me.RichEditForm_Agreement.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RichEditForm_Agreement.HtmlText = resources.GetString("RichEditForm_Agreement.HtmlText")
            Me.RichEditForm_Agreement.Location = New System.Drawing.Point(12, 12)
            Me.RichEditForm_Agreement.MhtText = resources.GetString("RichEditForm_Agreement.MhtText")
            Me.RichEditForm_Agreement.Name = "RichEditForm_Agreement"
            Me.RichEditForm_Agreement.ReadOnly = True
            Me.RichEditForm_Agreement.RtfText = resources.GetString("RichEditForm_Agreement.RtfText")
            Me.RichEditForm_Agreement.SecurityEnabled = True
            Me.RichEditForm_Agreement.ShowEditButtons = False
            Me.RichEditForm_Agreement.Size = New System.Drawing.Size(583, 432)
            Me.RichEditForm_Agreement.TabIndex = 6
            Me.RichEditForm_Agreement.WordMLText = resources.GetString("RichEditForm_Agreement.WordMLText")
            '
            'CSIPreferredPartnerAgreementDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(607, 482)
            Me.Controls.Add(Me.RichEditForm_Agreement)
            Me.Controls.Add(Me.CheckBoxForm_AcceptAgreement)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "CSIPreferredPartnerAgreementDialog"
            Me.Text = "CSI Preferred Partner Agreement"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents CheckBoxForm_AcceptAgreement As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents RichEditForm_Agreement As AdvantageFramework.WinForm.Presentation.Controls.RichEditControl
    End Class

End Namespace