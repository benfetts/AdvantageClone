Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class PopupContainerEditControl
        Inherits AdvantageFramework.WinForm.Presentation.Controls.BaseControls.BaseUserControl

        'UserControl overrides dispose to clean up the component list.
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
            Me.PopupContainerEditMain_PoupContainerEdit = New DevExpress.XtraEditors.PopupContainerEdit()
            CType(Me.PopupContainerEditMain_PoupContainerEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'PopupContainerEditMain_PoupContainerEdit
            '
            Me.PopupContainerEditMain_PoupContainerEdit.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PopupContainerEditMain_PoupContainerEdit.Location = New System.Drawing.Point(0, 0)
            Me.PopupContainerEditMain_PoupContainerEdit.Name = "PopupContainerEditMain_PoupContainerEdit"
            Me.PopupContainerEditMain_PoupContainerEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.PopupContainerEditMain_PoupContainerEdit.Size = New System.Drawing.Size(354, 20)
            Me.PopupContainerEditMain_PoupContainerEdit.TabIndex = 0
            '
            'PopupContainerEditControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.PopupContainerEditMain_PoupContainerEdit)
            Me.Name = "PopupContainerEditControl"
            Me.Size = New System.Drawing.Size(354, 20)
            CType(Me.PopupContainerEditMain_PoupContainerEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents PopupContainerEditMain_PoupContainerEdit As DevExpress.XtraEditors.PopupContainerEdit

    End Class

End Namespace