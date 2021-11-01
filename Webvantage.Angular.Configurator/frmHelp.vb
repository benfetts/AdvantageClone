Public Class frmHelp
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents tbhelp As System.Windows.Forms.TabControl
    Friend WithEvents tbrssrvpolicy As System.Windows.Forms.TabPage
    Friend WithEvents tbreportserverfolder As System.Windows.Forms.TabPage
    Friend WithEvents tbreportserverrole As System.Windows.Forms.TabPage
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnClose = New System.Windows.Forms.Button
        Me.tbhelp = New System.Windows.Forms.TabControl
        Me.tbrssrvpolicy = New System.Windows.Forms.TabPage
        Me.tbreportserverfolder = New System.Windows.Forms.TabPage
        Me.tbreportserverrole = New System.Windows.Forms.TabPage
        Me.tbhelp.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(264, 432)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.TabIndex = 0
        Me.btnClose.Text = "Close"
        '
        'tbhelp
        '
        Me.tbhelp.Controls.Add(Me.tbrssrvpolicy)
        Me.tbhelp.Controls.Add(Me.tbreportserverfolder)
        Me.tbhelp.Controls.Add(Me.tbreportserverrole)
        Me.tbhelp.Location = New System.Drawing.Point(8, 8)
        Me.tbhelp.Name = "tbhelp"
        Me.tbhelp.SelectedIndex = 0
        Me.tbhelp.Size = New System.Drawing.Size(648, 416)
        Me.tbhelp.TabIndex = 1
        '
        'tbrssrvpolicy
        '
        Me.tbrssrvpolicy.Location = New System.Drawing.Point(4, 22)
        Me.tbrssrvpolicy.Name = "tbrssrvpolicy"
        Me.tbrssrvpolicy.Size = New System.Drawing.Size(640, 390)
        Me.tbrssrvpolicy.TabIndex = 0
        Me.tbrssrvpolicy.Text = "Help Screen 1"
        '
        'tbreportserverfolder
        '
        Me.tbreportserverfolder.Location = New System.Drawing.Point(4, 22)
        Me.tbreportserverfolder.Name = "tbreportserverfolder"
        Me.tbreportserverfolder.Size = New System.Drawing.Size(640, 390)
        Me.tbreportserverfolder.TabIndex = 1
        Me.tbreportserverfolder.Text = "Help Screen 2"
        '
        'tbreportserverrole
        '
        Me.tbreportserverrole.Location = New System.Drawing.Point(4, 22)
        Me.tbreportserverrole.Name = "tbreportserverrole"
        Me.tbreportserverrole.Size = New System.Drawing.Size(640, 390)
        Me.tbreportserverrole.TabIndex = 2
        Me.tbreportserverrole.Text = "Help Screen 3"
        '
        'frmHelp
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(672, 469)
        Me.Controls.Add(Me.tbhelp)
        Me.Controls.Add(Me.btnClose)
        Me.Name = "frmHelp"
        Me.Text = "frmHelp"
        Me.tbhelp.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmHelp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub RichTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class
