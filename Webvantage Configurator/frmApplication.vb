Imports System.IO
Imports System.DirectoryServices

Public Class frmApplication
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Text = g_PageTitle
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSetupCancel As System.Windows.Forms.Button
    Friend WithEvents rbSetupWizard As System.Windows.Forms.RadioButton
    Friend WithEvents btnCP As System.Windows.Forms.Button
    Friend WithEvents btnWV As System.Windows.Forms.Button
    Friend WithEvents rbCustomize As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmApplication))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbCustomize = New System.Windows.Forms.RadioButton()
        Me.rbSetupWizard = New System.Windows.Forms.RadioButton()
        Me.btnSetupCancel = New System.Windows.Forms.Button()
        Me.btnCP = New System.Windows.Forms.Button()
        Me.btnWV = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbCustomize)
        Me.GroupBox1.Controls.Add(Me.rbSetupWizard)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(46, 194)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(192, 100)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Setup Selection"
        Me.GroupBox1.Visible = False
        '
        'rbCustomize
        '
        Me.rbCustomize.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbCustomize.Location = New System.Drawing.Point(32, 56)
        Me.rbCustomize.Name = "rbCustomize"
        Me.rbCustomize.Size = New System.Drawing.Size(104, 24)
        Me.rbCustomize.TabIndex = 1
        Me.rbCustomize.Text = "Customize"
        '
        'rbSetupWizard
        '
        Me.rbSetupWizard.Checked = True
        Me.rbSetupWizard.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSetupWizard.Location = New System.Drawing.Point(32, 24)
        Me.rbSetupWizard.Name = "rbSetupWizard"
        Me.rbSetupWizard.Size = New System.Drawing.Size(104, 24)
        Me.rbSetupWizard.TabIndex = 0
        Me.rbSetupWizard.TabStop = True
        Me.rbSetupWizard.Text = "Setup Wizard"
        '
        'btnSetupCancel
        '
        Me.btnSetupCancel.BackColor = System.Drawing.Color.MidnightBlue
        Me.btnSetupCancel.ForeColor = System.Drawing.Color.White
        Me.btnSetupCancel.Location = New System.Drawing.Point(12, 151)
        Me.btnSetupCancel.Name = "btnSetupCancel"
        Me.btnSetupCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnSetupCancel.TabIndex = 3
        Me.btnSetupCancel.Text = "Exit"
        Me.btnSetupCancel.UseVisualStyleBackColor = False
        '
        'btnCP
        '
        Me.btnCP.Location = New System.Drawing.Point(197, 50)
        Me.btnCP.Name = "btnCP"
        Me.btnCP.Size = New System.Drawing.Size(133, 50)
        Me.btnCP.TabIndex = 6
        Me.btnCP.Text = "Client Portal"
        '
        'btnWV
        '
        Me.btnWV.Location = New System.Drawing.Point(49, 50)
        Me.btnWV.Name = "btnWV"
        Me.btnWV.Size = New System.Drawing.Size(133, 50)
        Me.btnWV.TabIndex = 7
        Me.btnWV.Text = "Webvantage"
        '
        'frmApplication
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(395, 177)
        Me.Controls.Add(Me.btnWV)
        Me.Controls.Add(Me.btnCP)
        Me.Controls.Add(Me.btnSetupCancel)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmApplication"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnSetupCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetupCancel.Click
        Close()
    End Sub

    'Private Sub btnSetupNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    Dim frmwebconfig As frmWebConfig = New frmWebConfig
    '    frmwebconfig.isClientPortal = Me.RadioButtonCP.Checked
    '    frmwebconfig.Show()
    '    Me.Hide()
    '    'If Me.rbSetupWizard.Checked Then
    '    '    Dim frmdatabase As frmDatabase = New frmDatabase
    '    '    frmdatabase.Show()
    '    'Else
    '    '    Dim frmwebconfig As frmWebConfig = New frmWebConfig
    '    '    frmwebconfig.Show()
    '    'End If
    '    'Me.Hide()

    'End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub frmWelcome_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnCP_Click(sender As Object, e As System.EventArgs) Handles btnCP.Click
        Dim frmwebconfig As frmWebConfig = New frmWebConfig
        frmwebconfig.isClientPortal = True
        frmwebconfig.Show()
        Me.Hide()
    End Sub

    Private Sub btnWV_Click(sender As Object, e As System.EventArgs) Handles btnWV.Click
        Dim frmwebconfig As frmWebConfig = New frmWebConfig
        frmwebconfig.isClientPortal = False
        frmwebconfig.Show()
        Me.Hide()
    End Sub
End Class
