Namespace WinForm.Presentation.BaseForms

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class BaseDevExpressForm
        Inherits DevExpress.XtraBars.Ribbon.RibbonForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
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
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.DefaultLookAndFeelOffice2010Blue = New DevExpress.LookAndFeel.DefaultLookAndFeel()
            Me.SuspendLayout()
            '
            'DefaultLookAndFeelOffice2010Blue
            '
            Me.DefaultLookAndFeelOffice2010Blue.LookAndFeel.SkinName = "Office 2016 Colorful"
            '
            'BaseDevExpressForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1017, 588)
            Me.Name = "BaseDevExpressForm"
            Me.ResumeLayout(False)

        End Sub
        Protected WithEvents DefaultLookAndFeelOffice2010Blue As DevExpress.LookAndFeel.DefaultLookAndFeel
    End Class

End Namespace