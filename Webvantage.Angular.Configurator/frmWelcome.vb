Imports System.IO
Imports System.DirectoryServices
Imports System.ServiceProcess

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
    Friend WithEvents ButtonWebvantage As System.Windows.Forms.Button
    Friend WithEvents ButtonMobileDataServices As System.Windows.Forms.Button
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents LabelConfigDataServices As Label
    Friend WithEvents LabelConfigure As Label
    Friend WithEvents ButtonClientPortal As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmWelcome))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbCustomize = New System.Windows.Forms.RadioButton()
        Me.rbSetupWizard = New System.Windows.Forms.RadioButton()
        Me.btnSetupNext = New System.Windows.Forms.Button()
        Me.btnSetupCancel = New System.Windows.Forms.Button()
        Me.ButtonWebvantage = New System.Windows.Forms.Button()
        Me.ButtonMobileDataServices = New System.Windows.Forms.Button()
        Me.ButtonClientPortal = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.LabelConfigDataServices = New System.Windows.Forms.Label()
        Me.LabelConfigure = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbCustomize)
        Me.GroupBox1.Controls.Add(Me.rbSetupWizard)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(645, 540)
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
        Me.btnSetupNext.BackColor = System.Drawing.Color.MidnightBlue
        Me.btnSetupNext.ForeColor = System.Drawing.Color.White
        Me.btnSetupNext.Location = New System.Drawing.Point(271, 564)
        Me.btnSetupNext.Name = "btnSetupNext"
        Me.btnSetupNext.Size = New System.Drawing.Size(75, 23)
        Me.btnSetupNext.TabIndex = 2
        Me.btnSetupNext.Text = "Next"
        Me.btnSetupNext.UseVisualStyleBackColor = False
        '
        'btnSetupCancel
        '
        Me.btnSetupCancel.BackColor = System.Drawing.Color.MidnightBlue
        Me.btnSetupCancel.ForeColor = System.Drawing.Color.White
        Me.btnSetupCancel.Location = New System.Drawing.Point(364, 564)
        Me.btnSetupCancel.Name = "btnSetupCancel"
        Me.btnSetupCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnSetupCancel.TabIndex = 3
        Me.btnSetupCancel.Text = "Exit"
        Me.btnSetupCancel.UseVisualStyleBackColor = False
        '
        'ButtonWebvantage
        '
        Me.ButtonWebvantage.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.ButtonWebvantage.FlatAppearance.BorderSize = 0
        Me.ButtonWebvantage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonWebvantage.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonWebvantage.ForeColor = System.Drawing.Color.White
        Me.ButtonWebvantage.Location = New System.Drawing.Point(35, 364)
        Me.ButtonWebvantage.Name = "ButtonWebvantage"
        Me.ButtonWebvantage.Size = New System.Drawing.Size(157, 38)
        Me.ButtonWebvantage.TabIndex = 4
        Me.ButtonWebvantage.Text = "Webvantage"
        Me.ButtonWebvantage.UseVisualStyleBackColor = False
        Me.ButtonWebvantage.Visible = False
        '
        'ButtonMobileDataServices
        '
        Me.ButtonMobileDataServices.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.ButtonMobileDataServices.FlatAppearance.BorderSize = 0
        Me.ButtonMobileDataServices.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonMobileDataServices.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonMobileDataServices.ForeColor = System.Drawing.Color.White
        Me.ButtonMobileDataServices.Location = New System.Drawing.Point(12, 135)
        Me.ButtonMobileDataServices.Name = "ButtonMobileDataServices"
        Me.ButtonMobileDataServices.Size = New System.Drawing.Size(179, 38)
        Me.ButtonMobileDataServices.TabIndex = 5
        Me.ButtonMobileDataServices.Text = "OK"
        Me.ButtonMobileDataServices.UseVisualStyleBackColor = False
        '
        'ButtonClientPortal
        '
        Me.ButtonClientPortal.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.ButtonClientPortal.FlatAppearance.BorderSize = 0
        Me.ButtonClientPortal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonClientPortal.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonClientPortal.ForeColor = System.Drawing.Color.White
        Me.ButtonClientPortal.Location = New System.Drawing.Point(240, 413)
        Me.ButtonClientPortal.Name = "ButtonClientPortal"
        Me.ButtonClientPortal.Size = New System.Drawing.Size(150, 38)
        Me.ButtonClientPortal.TabIndex = 6
        Me.ButtonClientPortal.Text = "Client Portal"
        Me.ButtonClientPortal.UseVisualStyleBackColor = False
        Me.ButtonClientPortal.Visible = False
        '
        'ButtonCancel
        '
        Me.ButtonCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.ButtonCancel.FlatAppearance.BorderSize = 0
        Me.ButtonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCancel.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonCancel.ForeColor = System.Drawing.Color.White
        Me.ButtonCancel.Location = New System.Drawing.Point(197, 135)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(179, 38)
        Me.ButtonCancel.TabIndex = 7
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = False
        '
        'LabelConfigDataServices
        '
        Me.LabelConfigDataServices.AutoSize = True
        Me.LabelConfigDataServices.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelConfigDataServices.Location = New System.Drawing.Point(67, 74)
        Me.LabelConfigDataServices.Name = "LabelConfigDataServices"
        Me.LabelConfigDataServices.Size = New System.Drawing.Size(241, 39)
        Me.LabelConfigDataServices.TabIndex = 8
        Me.LabelConfigDataServices.Text = "Proofing Tool?"
        '
        'LabelConfigure
        '
        Me.LabelConfigure.AutoSize = True
        Me.LabelConfigure.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelConfigure.Location = New System.Drawing.Point(102, 24)
        Me.LabelConfigure.Name = "LabelConfigure"
        Me.LabelConfigure.Size = New System.Drawing.Size(167, 39)
        Me.LabelConfigure.TabIndex = 9
        Me.LabelConfigure.Text = "Configure"
        '
        'frmWelcome
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(389, 185)
        Me.Controls.Add(Me.LabelConfigure)
        Me.Controls.Add(Me.LabelConfigDataServices)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonClientPortal)
        Me.Controls.Add(Me.ButtonMobileDataServices)
        Me.Controls.Add(Me.ButtonWebvantage)
        Me.Controls.Add(Me.btnSetupNext)
        Me.Controls.Add(Me.btnSetupCancel)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmWelcome"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub frmWelcome_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Text = ""

        Try
            If CheckForASPNET() = False Then
                If MessageBox.Show("ASP.NET 4.0 not installed. Continue anyway?", "Warning.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = System.Windows.Forms.DialogResult.No Then
                    Application.Exit()
                End If
            End If
        Catch ex As Exception
        End Try
        Try
            If CheckVersionOfIIS().StartsWith("7") Then
                If CheckForCompatabilityMode() = False Then
                    If MessageBox.Show("IIS 6 Management Compatibility not installed. Continue anyway?", "Warning.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = System.Windows.Forms.DialogResult.No Then
                        Application.Exit()
                    End If
                End If
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub ButtonWebvantage_Click(sender As Object, e As EventArgs) Handles ButtonWebvantage.Click

        Dim frmwebconfig As frmWebConfig = New frmWebConfig
        frmwebconfig.SelectedApplication = ProofingConfigurator.frmWebConfig.App.Webvantage
        frmwebconfig.Show()
        Me.Hide()

    End Sub
    Private Sub ButtonClientPortal_Click(sender As Object, e As EventArgs) Handles ButtonClientPortal.Click

        Dim frmwebconfig As frmWebConfig = New frmWebConfig
        frmwebconfig.SelectedApplication = ProofingConfigurator.frmWebConfig.App.ClientPortal
        frmwebconfig.Show()
        Me.Hide()

    End Sub
    Private Sub ButtonMobileDataServices_Click(sender As Object, e As EventArgs) Handles ButtonMobileDataServices.Click

        Dim frmwebconfig As frmWebConfig = New frmWebConfig
        frmwebconfig.SelectedApplication = ProofingConfigurator.frmWebConfig.App.MobileDataservices
        frmwebconfig.Show()
        Me.Hide()

    End Sub

    Public Shared Function CheckVersionOfIIS() As String
        Try
            ' FileVersionInfo verinfo = FileVersionInfo.GetVersionInfo(System.Environment.SystemDirectory & @"\inetsrv\inetinfo.exe"); 
            Dim sReturn As String = "0"
            If Directory.Exists(System.Environment.SystemDirectory & "\inetsrv\") Then
                If File.Exists(System.Environment.SystemDirectory & "\inetsrv\w3wp.exe") Then
                    Dim VerInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(System.Environment.SystemDirectory & "\inetsrv\w3wp.exe")
                    sReturn = VerInfo.FileVersion().ToString()
                End If
                If File.Exists(System.Environment.SystemDirectory & "\inetsrv\inetinfo.exe") Then
                    Dim VerInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(System.Environment.SystemDirectory & "\inetsrv\inetinfo.exe")
                    sReturn = VerInfo.FileVersion().ToString()
                End If
            End If
            Return sReturn

        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Function CheckForASPNET() As Boolean
        'HKLM\Software\Microsoft\ASP.NET\2.0.50727.0
        'Check to see if we have asp.net 2.0 installed.
        Try
            Dim bReturn As Boolean = False
            Dim sValue As String
            Try
                sValue = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\ASP.NET\4.0.30319.0", "Path", Nothing)
                If Not IsNothing(sValue) Then
                    bReturn = True
                End If
            Catch x As Exception
            End Try
            Return bReturn
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function CheckForCompatabilityMode() As Boolean
        Try
            'HKLM\Software\Microsoft\ASP.NET\2.0.50727.0
            'Check to see if we have asp.net 2.0 installed.
            Dim bReturn As Boolean = False
            Dim sValue As String
            Try
                sValue = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\InetStp\Components\", "Metabase", Nothing)
                If Not IsNothing(sValue) Then
                    If Not (sValue = 0) Then
                        bReturn = True
                    End If
                End If
            Catch x As Exception

            End Try
            Return bReturn
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click

        Me.Close()
        Application.Exit()

    End Sub
End Class
