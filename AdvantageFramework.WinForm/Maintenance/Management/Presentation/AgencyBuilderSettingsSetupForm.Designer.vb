Namespace Maintenance.Management.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AgencyBuilderSettingsSetupForm
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseSettingsForm

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
            components = New System.ComponentModel.Container
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Name = "AgencyBuilderSettingsSetupForm"
            Me.Text = "Agency Builder"
        End Sub
    End Class

End Namespace