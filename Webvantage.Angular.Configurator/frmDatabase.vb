Public Class frmDatabase
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        Dim num_files As Integer
        Dim files() As String
        Dim file_name As String

        Dim strDirectory = Application.StartupPath & "\Scripts\"

        Try
            file_name = Dir$(strDirectory)

            Do While Len(file_name) > 0
                ' See if we should skip this file.
                ' Save the file.
                Me.cboDatabaseScript.Items.Add(file_name)
                ' Get the next file.
                file_name = Dir$()
            Loop
        Catch ex As Exception
            MsgBox("Error:  Loading Scripts")
        End Try
        'Add any initialization after the InitializeComponent() call

        Me.btnDatabaseNext.Enabled = False

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
    Friend WithEvents grpDatabase As System.Windows.Forms.GroupBox
    Friend WithEvents cboDatabaseScript As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnTestConnection As System.Windows.Forms.Button
    Friend WithEvents txtDatabaseName As System.Windows.Forms.TextBox
    Friend WithEvents lblDatabaseName As System.Windows.Forms.Label
    Friend WithEvents grpAuthentication As System.Windows.Forms.GroupBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rbSSA As System.Windows.Forms.RadioButton
    Friend WithEvents rbWIA As System.Windows.Forms.RadioButton
    Friend WithEvents lblconnectSQL As System.Windows.Forms.Label
    Friend WithEvents grpDatabaseServer As System.Windows.Forms.GroupBox
    Friend WithEvents txtSQLServerName As System.Windows.Forms.TextBox
    Friend WithEvents lblSQLServerName As System.Windows.Forms.Label
    Friend WithEvents btnDatabaseNext As System.Windows.Forms.Button
    Friend WithEvents btnDatabaseCancel As System.Windows.Forms.Button
    Friend WithEvents btnDatabaseSetup As System.Windows.Forms.Button
    Friend WithEvents lblDatabaseVersion As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpDatabase = New System.Windows.Forms.GroupBox
        Me.lblDatabaseVersion = New System.Windows.Forms.Label
        Me.btnDatabaseSetup = New System.Windows.Forms.Button
        Me.btnDatabaseCancel = New System.Windows.Forms.Button
        Me.cboDatabaseScript = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.btnDatabaseNext = New System.Windows.Forms.Button
        Me.txtDatabaseName = New System.Windows.Forms.TextBox
        Me.lblDatabaseName = New System.Windows.Forms.Label
        Me.btnTestConnection = New System.Windows.Forms.Button
        Me.grpAuthentication = New System.Windows.Forms.GroupBox
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.txtUserName = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.rbSSA = New System.Windows.Forms.RadioButton
        Me.rbWIA = New System.Windows.Forms.RadioButton
        Me.lblconnectSQL = New System.Windows.Forms.Label
        Me.grpDatabaseServer = New System.Windows.Forms.GroupBox
        Me.txtSQLServerName = New System.Windows.Forms.TextBox
        Me.lblSQLServerName = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.grpDatabase.SuspendLayout()
        Me.grpAuthentication.SuspendLayout()
        Me.grpDatabaseServer.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpDatabase
        '
        Me.grpDatabase.Controls.Add(Me.lblDatabaseVersion)
        Me.grpDatabase.Controls.Add(Me.btnDatabaseSetup)
        Me.grpDatabase.Controls.Add(Me.btnDatabaseCancel)
        Me.grpDatabase.Controls.Add(Me.cboDatabaseScript)
        Me.grpDatabase.Controls.Add(Me.Label8)
        Me.grpDatabase.Controls.Add(Me.btnDatabaseNext)
        Me.grpDatabase.Controls.Add(Me.txtDatabaseName)
        Me.grpDatabase.Controls.Add(Me.lblDatabaseName)
        Me.grpDatabase.Controls.Add(Me.btnTestConnection)
        Me.grpDatabase.Location = New System.Drawing.Point(8, 254)
        Me.grpDatabase.Name = "grpDatabase"
        Me.grpDatabase.Size = New System.Drawing.Size(376, 136)
        Me.grpDatabase.TabIndex = 7
        Me.grpDatabase.TabStop = False
        Me.grpDatabase.Text = "3. Connect to Existing Database"
        '
        'lblDatabaseVersion
        '
        Me.lblDatabaseVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDatabaseVersion.Location = New System.Drawing.Point(208, 0)
        Me.lblDatabaseVersion.Name = "lblDatabaseVersion"
        Me.lblDatabaseVersion.Size = New System.Drawing.Size(144, 16)
        Me.lblDatabaseVersion.TabIndex = 9
        Me.lblDatabaseVersion.Text = "No Database Version"
        Me.lblDatabaseVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnDatabaseSetup
        '
        Me.btnDatabaseSetup.Enabled = False
        Me.btnDatabaseSetup.Location = New System.Drawing.Point(136, 104)
        Me.btnDatabaseSetup.Name = "btnDatabaseSetup"
        Me.btnDatabaseSetup.TabIndex = 8
        Me.btnDatabaseSetup.Text = "Setup"
        '
        'btnDatabaseCancel
        '
        Me.btnDatabaseCancel.Location = New System.Drawing.Point(296, 104)
        Me.btnDatabaseCancel.Name = "btnDatabaseCancel"
        Me.btnDatabaseCancel.TabIndex = 7
        Me.btnDatabaseCancel.Text = "Cancel"
        '
        'cboDatabaseScript
        '
        Me.cboDatabaseScript.ItemHeight = 13
        Me.cboDatabaseScript.Location = New System.Drawing.Point(144, 64)
        Me.cboDatabaseScript.Name = "cboDatabaseScript"
        Me.cboDatabaseScript.Size = New System.Drawing.Size(224, 21)
        Me.cboDatabaseScript.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(40, 64)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 16)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Database Script:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnDatabaseNext
        '
        Me.btnDatabaseNext.Enabled = False
        Me.btnDatabaseNext.Location = New System.Drawing.Point(216, 104)
        Me.btnDatabaseNext.Name = "btnDatabaseNext"
        Me.btnDatabaseNext.TabIndex = 5
        Me.btnDatabaseNext.Text = "Next"
        '
        'txtDatabaseName
        '
        Me.txtDatabaseName.Location = New System.Drawing.Point(144, 32)
        Me.txtDatabaseName.Name = "txtDatabaseName"
        Me.txtDatabaseName.Size = New System.Drawing.Size(224, 20)
        Me.txtDatabaseName.TabIndex = 1
        Me.txtDatabaseName.Text = ""
        '
        'lblDatabaseName
        '
        Me.lblDatabaseName.Location = New System.Drawing.Point(40, 32)
        Me.lblDatabaseName.Name = "lblDatabaseName"
        Me.lblDatabaseName.Size = New System.Drawing.Size(100, 16)
        Me.lblDatabaseName.TabIndex = 0
        Me.lblDatabaseName.Text = "Database Name:"
        Me.lblDatabaseName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnTestConnection
        '
        Me.btnTestConnection.Location = New System.Drawing.Point(8, 104)
        Me.btnTestConnection.Name = "btnTestConnection"
        Me.btnTestConnection.Size = New System.Drawing.Size(112, 23)
        Me.btnTestConnection.TabIndex = 4
        Me.btnTestConnection.Text = "Test Connection"
        '
        'grpAuthentication
        '
        Me.grpAuthentication.Controls.Add(Me.txtPassword)
        Me.grpAuthentication.Controls.Add(Me.txtUserName)
        Me.grpAuthentication.Controls.Add(Me.Label3)
        Me.grpAuthentication.Controls.Add(Me.Label2)
        Me.grpAuthentication.Controls.Add(Me.rbSSA)
        Me.grpAuthentication.Controls.Add(Me.rbWIA)
        Me.grpAuthentication.Location = New System.Drawing.Point(8, 118)
        Me.grpAuthentication.Name = "grpAuthentication"
        Me.grpAuthentication.Size = New System.Drawing.Size(376, 128)
        Me.grpAuthentication.TabIndex = 6
        Me.grpAuthentication.TabStop = False
        Me.grpAuthentication.Text = "2. Select the Authentication Type"
        '
        'txtPassword
        '
        Me.txtPassword.Enabled = False
        Me.txtPassword.Location = New System.Drawing.Point(192, 104)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(144, 20)
        Me.txtPassword.TabIndex = 3
        Me.txtPassword.Text = ""
        '
        'txtUserName
        '
        Me.txtUserName.Enabled = False
        Me.txtUserName.Location = New System.Drawing.Point(192, 80)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(144, 20)
        Me.txtUserName.TabIndex = 2
        Me.txtUserName.Text = ""
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(120, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Password:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(120, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "User Name:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'rbSSA
        '
        Me.rbSSA.Location = New System.Drawing.Point(40, 48)
        Me.rbSSA.Name = "rbSSA"
        Me.rbSSA.Size = New System.Drawing.Size(272, 24)
        Me.rbSSA.TabIndex = 1
        Me.rbSSA.Text = "Use SQL Server Authentication"
        '
        'rbWIA
        '
        Me.rbWIA.Checked = True
        Me.rbWIA.Location = New System.Drawing.Point(40, 24)
        Me.rbWIA.Name = "rbWIA"
        Me.rbWIA.Size = New System.Drawing.Size(272, 24)
        Me.rbWIA.TabIndex = 0
        Me.rbWIA.TabStop = True
        Me.rbWIA.Text = "Use Windows Integrated Authentication"
        '
        'lblconnectSQL
        '
        Me.lblconnectSQL.Location = New System.Drawing.Point(16, 32)
        Me.lblconnectSQL.Name = "lblconnectSQL"
        Me.lblconnectSQL.Size = New System.Drawing.Size(176, 16)
        Me.lblconnectSQL.TabIndex = 5
        Me.lblconnectSQL.Text = "Connect directly to a SQL Server."
        '
        'grpDatabaseServer
        '
        Me.grpDatabaseServer.Controls.Add(Me.txtSQLServerName)
        Me.grpDatabaseServer.Controls.Add(Me.lblSQLServerName)
        Me.grpDatabaseServer.Location = New System.Drawing.Point(8, 56)
        Me.grpDatabaseServer.Name = "grpDatabaseServer"
        Me.grpDatabaseServer.Size = New System.Drawing.Size(376, 56)
        Me.grpDatabaseServer.TabIndex = 4
        Me.grpDatabaseServer.TabStop = False
        Me.grpDatabaseServer.Text = "1. Select the Database Server"
        '
        'txtSQLServerName
        '
        Me.txtSQLServerName.Location = New System.Drawing.Point(144, 24)
        Me.txtSQLServerName.Name = "txtSQLServerName"
        Me.txtSQLServerName.Size = New System.Drawing.Size(224, 20)
        Me.txtSQLServerName.TabIndex = 1
        Me.txtSQLServerName.Text = ""
        '
        'lblSQLServerName
        '
        Me.lblSQLServerName.Location = New System.Drawing.Point(40, 24)
        Me.lblSQLServerName.Name = "lblSQLServerName"
        Me.lblSQLServerName.Size = New System.Drawing.Size(100, 16)
        Me.lblSQLServerName.TabIndex = 0
        Me.lblSQLServerName.Text = "SQL Server Name:"
        Me.lblSQLServerName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(360, 16)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "*NOTE: This screen can only be executed from a machine with SQL Server loaded."
        '
        'frmDatabase
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(392, 405)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.grpDatabase)
        Me.Controls.Add(Me.grpAuthentication)
        Me.Controls.Add(Me.lblconnectSQL)
        Me.Controls.Add(Me.grpDatabaseServer)
        Me.Name = "frmDatabase"
        Me.Text = g_PageTitle & " - Database Setup"
        Me.grpDatabase.ResumeLayout(False)
        Me.grpAuthentication.ResumeLayout(False)
        Me.grpDatabaseServer.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnDatabaseNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDatabaseNext.Click
        Me.Cursor.Current = Cursors.WaitCursor
        Dim strConnString As String = ""
        Dim oApplication As cApplication = New cApplication(strConnString)
        Dim odbInstaller As dbInstaller = New dbInstaller
        Dim script As String = Application.StartupPath & "\Scripts\" & Me.cboDatabaseScript.Text.Trim
        Try
            If Me.txtDatabaseName.Text.Trim = "" Then
                MsgBox("Please enter a valid Database Name.", MsgBoxStyle.Critical, "Database Script Error")
                Me.txtDatabaseName.Focus()
                Exit Sub
            End If
            If Me.cboDatabaseScript.Text.Trim = "" Then
                MsgBox("Please enter a valid Database Script.", MsgBoxStyle.Critical, "Database Script Error")
                Me.cboDatabaseScript.Focus()
                Exit Sub
            End If

            If Me.rbWIA.Checked = True Then
                ' use Windows integrated authentication security
                odbInstaller.ExecuteSQLScript(Me.txtSQLServerName.Text.Trim, Me.txtDatabaseName.Text.Trim, Me.txtUserName.Text.Trim, Me.txtPassword.Text.Trim, script, Me.rbWIA.Checked)
            Else
                ' use SQL Server's authentication security
                If Me.txtUserName.Text.Trim = "" Then
                    MsgBox("Please enter a valid User Name.", MsgBoxStyle.Critical, "Database Script Error")
                    Me.txtUserName.Focus()
                    Exit Sub
                End If
                If Me.txtPassword.Text.Trim = "" Then
                    MsgBox("Please enter a valid password.", MsgBoxStyle.Critical, "Database Script Error")
                    Me.txtPassword.Focus()
                    Exit Sub
                End If
                odbInstaller.ExecuteSQLScript(Me.txtSQLServerName.Text.Trim, Me.txtDatabaseName.Text.Trim, Me.txtUserName.Text.Trim, Me.txtPassword.Text.Trim, script, Me.rbWIA.Checked)
            End If
            MsgBox("Process Completed!", MsgBoxStyle.OKOnly, "Database Script")
            Me.Cursor.Current = Cursors.Default
            Dim frmvirtualdirectory As frmVirtualDirectory = New frmVirtualDirectory
            frmvirtualdirectory.Show()
            Me.Hide()
        Catch
            MsgBox("Process Failed!", MsgBoxStyle.Critical, "Database Script")
            Me.Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub btnTestConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTestConnection.Click
        Dim strConnString As String
        Dim oApplication As cApplication
        Dim strReturn As String

        If Me.txtSQLServerName.Text.Trim = "" Then
            MsgBox("Please enter a valid SQL Server Name.", MsgBoxStyle.Critical, "Test Connection")
            Me.txtSQLServerName.Focus()
            Exit Sub
        End If

        If Me.rbWIA.Checked = True Then
            strConnString = "Persist Security Info=False;Data Source=" & Me.txtSQLServerName.Text.Trim
            strConnString &= ";Initial Catalog=" & Me.txtDatabaseName.Text.Trim
            strConnString &= ";Trusted_Connection=yes;"
        Else
            If Me.txtUserName.Text.Trim = "" Then
                MsgBox("Please enter a valid User Name.", MsgBoxStyle.Critical, "Test Connection")
                Me.txtUserName.Focus()
                Exit Sub
            End If
            If Me.txtPassword.Text.Trim = "" Then
                MsgBox("Please enter a valid password.", MsgBoxStyle.Critical, "Test Connection")
                Me.txtPassword.Focus()
                Exit Sub
            End If
            strConnString = "Persist Security Info=False;Data Source=" & Me.txtSQLServerName.Text.Trim
            strConnString &= ";Initial Catalog=" & Me.txtDatabaseName.Text.Trim
            strConnString &= ";User ID=" & Me.txtUserName.Text.Trim & ";Password=" & Me.txtPassword.Text.Trim
        End If

        oApplication = New cApplication(strConnString)

        strReturn = oApplication.dbTestConnection()

        If strReturn IsNot Nothing Then
            MsgBox("Test successful!  Database version: " & strReturn, MsgBoxStyle.OkOnly, "Test Connection")
            Me.lblDatabaseVersion.Text = "Database Version: " & strReturn
            Me.btnDatabaseNext.Enabled = True
            Me.btnDatabaseSetup.Enabled = True
        Else
            MsgBox("Test Failed!" & Err.Description, MsgBoxStyle.OkOnly, "Test Connection")
            Me.lblDatabaseVersion.Text = " No Database Version"
            Me.btnDatabaseNext.Enabled = False
            Me.btnDatabaseSetup.Enabled = False
        End If
    End Sub

    Private Sub btnDatabaseCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDatabaseCancel.Click
        Close()
        Application.Exit()
    End Sub

    Private Sub rbSSA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSSA.CheckedChanged
        Me.txtUserName.Enabled = True
        Me.txtPassword.Enabled = True
    End Sub

    Private Sub rbWIA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbWIA.CheckedChanged
        Me.txtUserName.Enabled = False
        Me.txtPassword.Enabled = False
    End Sub

    Private Sub frmDatabase_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        Application.Exit()
    End Sub

    Private Sub btnDatabaseSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDatabaseSetup.Click
        Me.Cursor.Current = Cursors.WaitCursor
        Dim strConnString As String = ""
        Dim oApplication As cApplication = New cApplication(strConnString)
        Dim odbInstaller As dbInstaller = New dbInstaller
        Dim script As String = Application.StartupPath & "\Scripts\" & Me.cboDatabaseScript.Text.Trim
        Try
            If Me.txtDatabaseName.Text.Trim = "" Then
                MsgBox("Please enter a valid Database Name.", MsgBoxStyle.Critical, "Database Script Error")
                Me.txtDatabaseName.Focus()
                Exit Sub
            End If
            If Me.cboDatabaseScript.Text.Trim = "" Then
                MsgBox("Please enter a valid Database Script.", MsgBoxStyle.Critical, "Database Script Error")
                Me.cboDatabaseScript.Focus()
                Exit Sub
            End If

            If Me.rbWIA.Checked = True Then
                ' use Windows integrated authentication security
                odbInstaller.ExecuteSQLScript(Me.txtSQLServerName.Text.Trim, Me.txtDatabaseName.Text.Trim, Me.txtUserName.Text.Trim, Me.txtPassword.Text.Trim, script, Me.rbWIA.Checked)
            Else
                ' use SQL Server's authentication security
                If Me.txtUserName.Text.Trim = "" Then
                    MsgBox("Please enter a valid User Name.", MsgBoxStyle.Critical, "Database Script Error")
                    Me.txtUserName.Focus()
                    Exit Sub
                End If
                If Me.txtPassword.Text.Trim = "" Then
                    MsgBox("Please enter a valid password.", MsgBoxStyle.Critical, "Database Script Error")
                    Me.txtPassword.Focus()
                    Exit Sub
                End If
                odbInstaller.ExecuteSQLScript(Me.txtSQLServerName.Text.Trim, Me.txtDatabaseName.Text.Trim, Me.txtUserName.Text.Trim, Me.txtPassword.Text.Trim, script, Me.rbWIA.Checked)
            End If
            MsgBox("Process Completed!", MsgBoxStyle.OKOnly, "Database Script")
            Me.Cursor.Current = Cursors.Default
        Catch
            MsgBox("Process Failed!", MsgBoxStyle.Critical, "Database Script")
            Me.Cursor.Current = Cursors.Default
        End Try
        Me.btnDatabaseSetup.Enabled = False
    End Sub
End Class
