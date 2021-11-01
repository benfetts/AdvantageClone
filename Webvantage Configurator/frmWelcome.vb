Imports System.IO
Imports System.DirectoryServices

Public Class frmWelcome
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
    Friend WithEvents btnSetupNext As System.Windows.Forms.Button
    Friend WithEvents btnSetupCancel As System.Windows.Forms.Button
    Friend WithEvents rbSetupWizard As System.Windows.Forms.RadioButton
    Friend WithEvents rbCustomize As System.Windows.Forms.RadioButton
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmWelcome))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbCustomize = New System.Windows.Forms.RadioButton()
        Me.rbSetupWizard = New System.Windows.Forms.RadioButton()
        Me.btnSetupNext = New System.Windows.Forms.Button()
        Me.btnSetupCancel = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbCustomize)
        Me.GroupBox1.Controls.Add(Me.rbSetupWizard)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(557, 607)
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
        'btnSetupNext
        '
        Me.btnSetupNext.BackColor = System.Drawing.Color.SlateGray
        Me.btnSetupNext.FlatAppearance.BorderSize = 0
        Me.btnSetupNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSetupNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetupNext.ForeColor = System.Drawing.Color.White
        Me.btnSetupNext.Location = New System.Drawing.Point(54, 463)
        Me.btnSetupNext.Name = "btnSetupNext"
        Me.btnSetupNext.Size = New System.Drawing.Size(264, 52)
        Me.btnSetupNext.TabIndex = 2
        Me.btnSetupNext.Text = "Next"
        Me.btnSetupNext.UseVisualStyleBackColor = False
        '
        'btnSetupCancel
        '
        Me.btnSetupCancel.BackColor = System.Drawing.Color.SlateGray
        Me.btnSetupCancel.FlatAppearance.BorderSize = 0
        Me.btnSetupCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSetupCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetupCancel.ForeColor = System.Drawing.Color.White
        Me.btnSetupCancel.Location = New System.Drawing.Point(466, 336)
        Me.btnSetupCancel.Name = "btnSetupCancel"
        Me.btnSetupCancel.Size = New System.Drawing.Size(123, 46)
        Me.btnSetupCancel.TabIndex = 3
        Me.btnSetupCancel.Text = "Exit"
        Me.btnSetupCancel.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.InitialImage = CType(resources.GetObject("PictureBox1.InitialImage"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(599, 400)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.SlateGray
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(12, 336)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(208, 46)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Webvantage"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.SlateGray
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(241, 336)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(208, 46)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "Client Portal"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'frmWelcome
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(601, 394)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnSetupNext)
        Me.Controls.Add(Me.btnSetupCancel)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(617, 433)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(617, 433)
        Me.Name = "frmWelcome"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnSetupCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetupCancel.Click
        Close()
    End Sub

    Private Sub btnSetupNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetupNext.Click

        Dim frmApplication As frmApplication = New frmApplication
        frmApplication.Show()
        Me.Hide()

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub frmWelcome_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim frmwebconfig As frmWebConfig = New frmWebConfig
        frmWebConfig.isClientPortal = False
        frmwebconfig.Show()
        Me.Hide()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim frmwebconfig As frmWebConfig = New frmWebConfig
        frmWebConfig.isClientPortal = True
        frmwebconfig.Show()
        Me.Hide()

    End Sub
End Class
