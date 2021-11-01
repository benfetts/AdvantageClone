Imports System.IO
Imports System.DirectoryServices
Public Class frmVirtualDirectory

    Inherits System.Windows.Forms.Form
    Dim bnLoad As Boolean
    Dim oWebSite As nsWebsites.Website
    Dim oWebSites As nsWebsites.WebSites = New nsWebsites.WebSites
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()
        bnLoad = True
        'This call is required by the Windows Form Designer.
        InitializeComponent()

        LoadWebSitesCollection("localhost")

        Try
            With drpIISWebsite
                .DataSource = oWebSites
                .DisplayMember = "Name"
                .ValueMember = "PhysicalPath"
                .SelectedIndex = 0
            End With

        Catch ex As Exception
            MsgBox("Error:  Loading IIS")
        End Try


        Me.chkVirtualDirectory.Checked = True
        Me.txtVirtualDirectory.Text = "webvantage2005"
        Me.txtVirtualDirectory.Enabled = True

        Me.btnSetupVirtDirNext.Enabled = True
        'Add any initialization after the InitializeComponent() call
        bnLoad = False
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
    Friend WithEvents grpApplicationAuthentication As System.Windows.Forms.GroupBox
    Friend WithEvents rbSqlAuthentication As System.Windows.Forms.RadioButton
    Friend WithEvents rbNTAuthentication As System.Windows.Forms.RadioButton
    Friend WithEvents grpCreateWebVirtDir As System.Windows.Forms.GroupBox
    Friend WithEvents btnLoadWebsites As System.Windows.Forms.Button
    Friend WithEvents drpIISWebsite As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtIISServer As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtPhysicalPath As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtVirtualDirectory As System.Windows.Forms.TextBox
    Friend WithEvents lblWebconfig As System.Windows.Forms.Label
    Friend WithEvents btnSetupVirtDirNext As System.Windows.Forms.Button
    Friend WithEvents btnVirtualDirCancel As System.Windows.Forms.Button
    Friend WithEvents chkVirtualDirectory As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpApplicationAuthentication = New System.Windows.Forms.GroupBox
        Me.rbSqlAuthentication = New System.Windows.Forms.RadioButton
        Me.rbNTAuthentication = New System.Windows.Forms.RadioButton
        Me.grpCreateWebVirtDir = New System.Windows.Forms.GroupBox
        Me.chkVirtualDirectory = New System.Windows.Forms.CheckBox
        Me.btnLoadWebsites = New System.Windows.Forms.Button
        Me.drpIISWebsite = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtIISServer = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtPhysicalPath = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtVirtualDirectory = New System.Windows.Forms.TextBox
        Me.lblWebconfig = New System.Windows.Forms.Label
        Me.btnSetupVirtDirNext = New System.Windows.Forms.Button
        Me.btnVirtualDirCancel = New System.Windows.Forms.Button
        Me.grpApplicationAuthentication.SuspendLayout()
        Me.grpCreateWebVirtDir.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpApplicationAuthentication
        '
        Me.grpApplicationAuthentication.Controls.Add(Me.rbSqlAuthentication)
        Me.grpApplicationAuthentication.Controls.Add(Me.rbNTAuthentication)
        Me.grpApplicationAuthentication.Location = New System.Drawing.Point(8, 296)
        Me.grpApplicationAuthentication.Name = "grpApplicationAuthentication"
        Me.grpApplicationAuthentication.Size = New System.Drawing.Size(376, 56)
        Me.grpApplicationAuthentication.TabIndex = 8
        Me.grpApplicationAuthentication.TabStop = False
        Me.grpApplicationAuthentication.Text = "Application Authentication"
        '
        'rbSqlAuthentication
        '
        Me.rbSqlAuthentication.Checked = True
        Me.rbSqlAuthentication.Location = New System.Drawing.Point(16, 24)
        Me.rbSqlAuthentication.Name = "rbSqlAuthentication"
        Me.rbSqlAuthentication.Size = New System.Drawing.Size(128, 24)
        Me.rbSqlAuthentication.TabIndex = 1
        Me.rbSqlAuthentication.TabStop = True
        Me.rbSqlAuthentication.Text = "SQL Authentication"
        '
        'rbNTAuthentication
        '
        Me.rbNTAuthentication.Location = New System.Drawing.Point(176, 24)
        Me.rbNTAuthentication.Name = "rbNTAuthentication"
        Me.rbNTAuthentication.Size = New System.Drawing.Size(128, 24)
        Me.rbNTAuthentication.TabIndex = 0
        Me.rbNTAuthentication.Text = "NT Authentication"
        '
        'grpCreateWebVirtDir
        '
        Me.grpCreateWebVirtDir.Controls.Add(Me.chkVirtualDirectory)
        Me.grpCreateWebVirtDir.Controls.Add(Me.btnLoadWebsites)
        Me.grpCreateWebVirtDir.Controls.Add(Me.drpIISWebsite)
        Me.grpCreateWebVirtDir.Controls.Add(Me.Label12)
        Me.grpCreateWebVirtDir.Controls.Add(Me.txtIISServer)
        Me.grpCreateWebVirtDir.Controls.Add(Me.Label10)
        Me.grpCreateWebVirtDir.Controls.Add(Me.txtPhysicalPath)
        Me.grpCreateWebVirtDir.Controls.Add(Me.Label9)
        Me.grpCreateWebVirtDir.Controls.Add(Me.txtVirtualDirectory)
        Me.grpCreateWebVirtDir.Controls.Add(Me.lblWebconfig)
        Me.grpCreateWebVirtDir.Location = New System.Drawing.Point(8, 11)
        Me.grpCreateWebVirtDir.Name = "grpCreateWebVirtDir"
        Me.grpCreateWebVirtDir.Size = New System.Drawing.Size(376, 277)
        Me.grpCreateWebVirtDir.TabIndex = 7
        Me.grpCreateWebVirtDir.TabStop = False
        Me.grpCreateWebVirtDir.Text = "Web Virtual Directory"
        '
        'chkVirtualDirectory
        '
        Me.chkVirtualDirectory.Location = New System.Drawing.Point(24, 136)
        Me.chkVirtualDirectory.Name = "chkVirtualDirectory"
        Me.chkVirtualDirectory.Size = New System.Drawing.Size(232, 24)
        Me.chkVirtualDirectory.TabIndex = 11
        Me.chkVirtualDirectory.Text = "Create Virtual Directory"
        '
        'btnLoadWebsites
        '
        Me.btnLoadWebsites.Location = New System.Drawing.Point(200, 48)
        Me.btnLoadWebsites.Name = "btnLoadWebsites"
        Me.btnLoadWebsites.Size = New System.Drawing.Size(120, 23)
        Me.btnLoadWebsites.TabIndex = 10
        Me.btnLoadWebsites.Text = "Load Web Sites"
        '
        'drpIISWebsite
        '
        Me.drpIISWebsite.Location = New System.Drawing.Point(24, 104)
        Me.drpIISWebsite.Name = "drpIISWebsite"
        Me.drpIISWebsite.Size = New System.Drawing.Size(312, 21)
        Me.drpIISWebsite.TabIndex = 9
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(24, 80)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(232, 16)
        Me.Label12.TabIndex = 8
        Me.Label12.Text = "IIS Web Site:"
        '
        'txtIISServer
        '
        Me.txtIISServer.Location = New System.Drawing.Point(24, 48)
        Me.txtIISServer.Name = "txtIISServer"
        Me.txtIISServer.Size = New System.Drawing.Size(144, 20)
        Me.txtIISServer.TabIndex = 1
        Me.txtIISServer.Text = "localhost"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(24, 24)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(232, 16)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "IIS Server IP Address or Server Name:"
        '
        'txtPhysicalPath
        '
        Me.txtPhysicalPath.Location = New System.Drawing.Point(24, 248)
        Me.txtPhysicalPath.Name = "txtPhysicalPath"
        Me.txtPhysicalPath.Size = New System.Drawing.Size(312, 20)
        Me.txtPhysicalPath.TabIndex = 4
        Me.txtPhysicalPath.Text = "C:\Inetpub\wwwroot\webvantage"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(24, 224)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(232, 16)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Copy files to::"
        '
        'txtVirtualDirectory
        '
        Me.txtVirtualDirectory.Location = New System.Drawing.Point(24, 192)
        Me.txtVirtualDirectory.Name = "txtVirtualDirectory"
        Me.txtVirtualDirectory.Size = New System.Drawing.Size(312, 20)
        Me.txtVirtualDirectory.TabIndex = 3
        Me.txtVirtualDirectory.Text = "Webvantage"
        '
        'lblWebconfig
        '
        Me.lblWebconfig.Location = New System.Drawing.Point(24, 168)
        Me.lblWebconfig.Name = "lblWebconfig"
        Me.lblWebconfig.Size = New System.Drawing.Size(232, 16)
        Me.lblWebconfig.TabIndex = 2
        Me.lblWebconfig.Text = "Virtual Directory:"
        '
        'btnSetupVirtDirNext
        '
        Me.btnSetupVirtDirNext.Location = New System.Drawing.Point(216, 368)
        Me.btnSetupVirtDirNext.Name = "btnSetupVirtDirNext"
        Me.btnSetupVirtDirNext.TabIndex = 9
        Me.btnSetupVirtDirNext.Text = "Next"
        '
        'btnVirtualDirCancel
        '
        Me.btnVirtualDirCancel.Location = New System.Drawing.Point(304, 368)
        Me.btnVirtualDirCancel.Name = "btnVirtualDirCancel"
        Me.btnVirtualDirCancel.TabIndex = 10
        Me.btnVirtualDirCancel.Text = "Cancel"
        '
        'frmVirtualDirectory
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(392, 405)
        Me.Controls.Add(Me.btnVirtualDirCancel)
        Me.Controls.Add(Me.grpApplicationAuthentication)
        Me.Controls.Add(Me.grpCreateWebVirtDir)
        Me.Controls.Add(Me.btnSetupVirtDirNext)
        Me.Name = "frmVirtualDirectory"
        Me.grpApplicationAuthentication.ResumeLayout(False)
        Me.grpCreateWebVirtDir.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnVirtualDirCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVirtualDirCancel.Click
        Close()
        Application.Exit()
    End Sub

    Private Sub btnSetupVirtDirNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetupVirtDirNext.Click
        Dim strConnString As String = ""
        If Me.txtPhysicalPath.Text.Trim = "" Then
            MsgBox("Please enter a valid Physical Path.", MsgBoxStyle.Critical, "Setup Virtual Directory")
            Me.txtPhysicalPath.Focus()
            Exit Sub
        End If
        If Me.txtIISServer.Text.Trim = "" Then
            MsgBox("Please enter a valid IIS Server Name.", MsgBoxStyle.Critical, "Setup Virtual Directory")
            Me.txtIISServer.Focus()
            Exit Sub
        End If

        Dim oApplication As cApplication = New cApplication(strConnString)

        Me.Cursor.Current = Cursors.WaitCursor


        'copy file to inetpub.
        Try
            Directory.CreateDirectory(Me.txtPhysicalPath.Text.Trim)
            oApplication.CopyDirectory(Application.StartupPath, Me.txtPhysicalPath.Text.Trim)
        Catch
            'directory already exists.
        End Try

        Me.Cursor.Current = Cursors.Default

        'Create Virtual Directory.
        If Me.chkVirtualDirectory.Checked Then
            oApplication.set_WebVirtDir(Me.txtVirtualDirectory.Text.Trim, Me.txtPhysicalPath.Text.Trim, oWebSites(Me.drpIISWebsite.SelectedIndex).WebSitePath)

            If Err.Number <> 0 Then
                MsgBox("An error occurred while installing the Virtual Directory - " & vbCrLf & _
                    "     - Error Details: " & Err.Description & " [Number:" & _
                    Hex(Err.Number) & "]", vbCritical, g_PageTitle)
                Exit Sub
            End If
        End If

        'Copy webnt.config or websql.config to web.config

        oApplication.CopyWebConfig(Me.rbNTAuthentication.Checked, Me.txtPhysicalPath.Text.Trim)

        MsgBox("Web Virtual Directory Created!", MsgBoxStyle.OKOnly, "Create Web Virtual Directory")
        oApplication.strWebsitePhysicalPath = Me.txtPhysicalPath.Text.Trim
        'Dim frmreportingservices As frmreportingservices = New frmReportingServices(oApplication)
        'frmreportingservices.Show()
        Me.Hide()
    End Sub

    Private Sub btnLoadWebsites_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadWebsites.Click

        LoadWebSitesCollection(Me.txtIISServer.Text.Trim)

        Try
            With drpIISWebsite
                .DataSource = oWebSites
                .DisplayMember = "Name"
                .ValueMember = "PhysicalPath"
                .SelectedIndex = 0
            End With
            If Me.txtVirtualDirectory.Text = "" Then
                Me.txtPhysicalPath.Text = Me.drpIISWebsite.SelectedValue
            Else
                Me.txtPhysicalPath.Text = Me.drpIISWebsite.SelectedValue & "\" & Me.txtVirtualDirectory.Text
            End If
            Me.btnSetupVirtDirNext.Enabled = True

        Catch ex As Exception
            MsgBox("Error:  Loading IIS")
        End Try
    End Sub

    Private Sub txtIISServer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIISServer.TextChanged
        Me.btnSetupVirtDirNext.Enabled = False
    End Sub

    Private Sub frmVirtualDirectory_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        Application.Exit()
    End Sub

    Private Sub chkVirtualDirectory_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVirtualDirectory.CheckedChanged
        If Me.chkVirtualDirectory.Checked Then
            Me.txtVirtualDirectory.Text = "webvantage"
            Me.txtVirtualDirectory.Enabled = True
        Else
            Me.txtVirtualDirectory.Text = ""
            Me.txtVirtualDirectory.Enabled = False
        End If
        ChangePhysicalDir()

    End Sub

    Private Sub txtVirtualDirectory_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVirtualDirectory.TextChanged
        'Get the Physical path for the Web Virtual Directory

        ChangePhysicalDir()

    End Sub

    Private Function ChangePhysicalDir()
        If drpIISWebsite.SelectedValue <> String.Empty Then
            If Me.txtVirtualDirectory.Text = "" Then
                Me.txtPhysicalPath.Text = Me.drpIISWebsite.SelectedValue
            Else
                Me.txtPhysicalPath.Text = Me.drpIISWebsite.SelectedValue & "\" & Me.txtVirtualDirectory.Text
            End If
        End If
    End Function

    Private Sub drpIISWebsite_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drpIISWebsite.SelectedValueChanged
        If bnLoad = False Then
            ChangePhysicalDir()
        End If
    End Sub

    Private Sub LoadWebSitesCollection(ByVal pServer As String)
        Dim strConnstring As String = ""
        Dim oApplication As cApplication = New cApplication(strConnstring)
        Dim root As DirectoryEntry = New DirectoryEntry("IIS://" & pServer & "/W3SVC")
        Dim child As DirectoryEntry
        Dim root1 As DirectoryEntry
        Dim child1 As DirectoryEntry


        Try
            For Each child In root.Children
                If child.SchemaClassName = "IIsWebServer" Then
                    oWebSite = New nsWebsites.Website
                    oWebSite.Name = child.Properties("ServerComment").Value
                    oWebSite.WebSitePath = child.Path.ToString & "/Root"
                    'Get the Physical path for the Web Virtual Directory
                    root1 = New DirectoryEntry(child.Path.ToString)
                    For Each child1 In root1.Children
                        If child1.SchemaClassName = "IIsWebVirtualDir" Then
                            oWebSite.PhysicalPath = child1.Properties("Path").Value
                        End If
                    Next
                    oWebSites.Add(oWebSite)
                End If
            Next
        Catch
            'TODO Error Catch
        End Try

    End Sub

    Private Sub grpCreateWebVirtDir_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grpCreateWebVirtDir.Enter

    End Sub

    Private Sub drpIISWebsite_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpIISWebsite.SelectedIndexChanged

    End Sub
End Class
