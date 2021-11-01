Namespace WinForm.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class BrowserForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BrowserForm))
            Me.WebBrowserForm_Browser = New AxSHDocVw.AxWebBrowser()
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.WebBrowserForm_Browser, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'DefaultLookAndFeelOffice2010Blue
            '
            Me.DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
            '
            'WebBrowserForm_Browser
            '
            Me.WebBrowserForm_Browser.Dock = System.Windows.Forms.DockStyle.Fill
            Me.WebBrowserForm_Browser.Enabled = True
            Me.WebBrowserForm_Browser.Location = New System.Drawing.Point(0, 0)
            Me.WebBrowserForm_Browser.OcxState = CType(resources.GetObject("WebBrowserForm_Browser.OcxState"), System.Windows.Forms.AxHost.State)
            Me.WebBrowserForm_Browser.Size = New System.Drawing.Size(621, 412)
            Me.WebBrowserForm_Browser.TabIndex = 1
            '
            'BrowserForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(621, 412)
            Me.Controls.Add(Me.WebBrowserForm_Browser)
            Me.DoubleBuffered = True
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "BrowserForm"
            Me.Text = "BrowserForm"
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.WebBrowserForm_Browser, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents WebBrowserForm_Browser As AxSHDocVw.AxWebBrowser

    End Class

End Namespace
