Option Explicit On

Imports System.DirectoryServices
Imports System.IO
Imports Microsoft.Win32
Imports System.Xml
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Windows.Forms
Imports System.Drawing
Imports System.ServiceProcess

Public Class frmWebConfig
    Inherits System.Windows.Forms.Form

#Region " Constants "

    Private Const _ConstConnectionStringBaseSQLAuthentication As String = "Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3};"

#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Dim bnLoad As Boolean
    Dim oWebSite As nsWebsites.Website
    Dim oWebSites As nsWebsites.WebSites = New nsWebsites.WebSites
    Dim iParentID As Integer = 0
    Private Const MAX_CTL As Integer = 3
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents chkUpperCaseDatabase As System.Windows.Forms.CheckBox
    Friend WithEvents txtretypeemailpassword As System.Windows.Forms.TextBox
    Friend WithEvents epEmailPassword As System.Windows.Forms.ErrorProvider
    Friend WithEvents epSMTPAddress As System.Windows.Forms.ErrorProvider
    Friend WithEvents epEmailAddress As System.Windows.Forms.ErrorProvider
    Friend WithEvents BtnDeleteCache As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtConfigReportingServices As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtAdmPassword As System.Windows.Forms.TextBox
    Friend WithEvents TxtAdmUserName As System.Windows.Forms.TextBox
    Friend WithEvents TxtAdmServerName As System.Windows.Forms.TextBox
    Friend WithEvents gbWebFarm As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtAdmDatabaseName As System.Windows.Forms.TextBox
    Friend WithEvents ChkBxUseSysLogon As System.Windows.Forms.CheckBox
    Friend WithEvents ChkBxIsOnWebFarm As System.Windows.Forms.CheckBox
    Friend WithEvents TxtTimeOutMinutes As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TxtAlertRefresh As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cboCustomErrors As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtSessionTimeout As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents tbRegistry As System.Windows.Forms.TabPage
    Friend WithEvents gbRegistry As System.Windows.Forms.GroupBox
    Friend WithEvents tvRegistry As System.Windows.Forms.TreeView
    Friend WithEvents txtAdminUsername As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtAdminPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtClientPortalPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtClientPortalUsername As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents btnSaveRegistry As System.Windows.Forms.Button
    Friend WithEvents btnAddReg As System.Windows.Forms.Button
    Friend WithEvents btnDeleteReg As System.Windows.Forms.Button
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtRegistryServer As System.Windows.Forms.TextBox
    Friend WithEvents txtRegistryDatabase As System.Windows.Forms.TextBox
    Friend WithEvents lblRegistryWarn As System.Windows.Forms.Label
    Friend WithEvents TreeViewImageList As System.Windows.Forms.ImageList
    Friend WithEvents tabWebServices As System.Windows.Forms.TabPage
    Friend WithEvents btnCreate As System.Windows.Forms.Button
    Friend WithEvents txtURL As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents lblWarning As System.Windows.Forms.Label
    Friend WithEvents PBarIIS As System.Windows.Forms.ProgressBar
    Friend WithEvents lblProgress As System.Windows.Forms.Label
    Friend WithEvents Chk_NTAuth_UserCode_IgnoreCase As System.Windows.Forms.CheckBox
    Friend WithEvents TabSMTP As System.Windows.Forms.TabPage
    Friend WithEvents btnSmtpInstall As System.Windows.Forms.Button
    Friend WithEvents ButtonDeleteTempFiles As System.Windows.Forms.Button
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents ButtonSetMachineConfig As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Private m_FilterSelected(MAX_CTL) As Integer
    Private GlobalConnString As String = ""
    Public Shared isClientPortal As Boolean = False
    Public Shared ClientPortalKey As String = ""
    Friend WithEvents ButtonCreateEventLog As System.Windows.Forms.Button
    Friend WithEvents ButtonAddFavicon As System.Windows.Forms.Button
    Friend WithEvents CheckBoxRequireSSL As CheckBox
    Friend WithEvents GroupBoxChatDB As GroupBox
    Friend WithEvents Label40 As Label
    Friend WithEvents Label39 As Label
    Friend WithEvents TextBoxChatPassword As TextBox
    Friend WithEvents Label37 As Label
    Friend WithEvents TextBoxChatUsername As TextBox
    Friend WithEvents Label36 As Label
    Friend WithEvents TextBoxChatDatabaseName As TextBox
    Friend WithEvents Label35 As Label
    Friend WithEvents TextBoxChatServerName As TextBox
    Friend WithEvents Label38 As Label
    Friend WithEvents TabPageConnection As TabPage
    Friend WithEvents ButtonDelete As Button
    Friend WithEvents ButtonConnectionSave As Button
    Friend WithEvents TextBoxPassword As TextBox
    Friend WithEvents LabelPassword As Label
    Friend WithEvents TextBoxUserName As TextBox
    Friend WithEvents LabelUserName As Label
    Friend WithEvents ButtonAddDatabase As Button
    Friend WithEvents ButtonAddServer As Button
    Friend WithEvents TreeViewConnections As TreeView
    Friend WithEvents ButtonTest As Button
    Friend WithEvents LabelLatestVersion2 As Label
    Friend WithEvents LabelLatestVersion1 As Label
    Friend WithEvents LabelInstalledVersion2 As Label
    Friend WithEvents LabelInstalledVersion1 As Label
    Private _ConnectionDatabaseProfiles As Generic.List(Of Database.ConnectionDatabaseProfile) = Nothing
    Friend WithEvents ButtonProofingEventLog As Button
    Private _WebvantageEventLogName As String = "Webvantage"
    Private _WebvantageEventSource As String = "Application_Error Event"
    Private _ProofingEventLogName As String = "Adv Proofing"
    Friend WithEvents Button2 As Button
    Private _ProofingEventSource As String = "Adv Proofing Event"

#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region " Controls "

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Close()
        Application.Exit()
    End Sub
    Private Sub btnSaveSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim strConnection As String = ""
        Dim oApplication As cApplication = New cApplication(strConnection)
        Dim retval As Double
        Dim ds As DataSet
        ds = New DataSet

        'If Me.txtReportServerPath.Text.Trim = "" Then
        '    MsgBox("Please enter a valid Report Server Path.", MsgBoxStyle.Critical, "Save Settings")
        '    Me.txtReportServerPath.Focus()
        '    Exit Sub
        'End If
        If Me.txtPhysicalPath.Text.Trim = "" Then
            MsgBox("Please enter a valid Physical Path.", MsgBoxStyle.Critical, "Save Settings")
            Me.txtPhysicalPath.Focus()
            Exit Sub
        End If
        'If Me.txtMSSQLServer.Text.Trim = "" Then
        '    MsgBox("Please enter a valid MS SQL Reporting Services Path.", MsgBoxStyle.Critical, "Save Settings")
        '    Me.txtMSSQLServer.Focus()
        '    Exit Sub
        'End If
        'If Me.txtwebconfig1.Text.Trim = "" Then
        '    MsgBox("Please select a valid web.config file.", MsgBoxStyle.Critical, "Save Settings")
        '    Me.txtwebconfig1.Focus()
        '    Exit Sub
        'End If

        'using the DOM to edit the rsReportServer.config
        'Dim xmlpath As String = Me.txtMSSQLServer.Text.Trim & "\ReportServer\rsReportServer.config"
        'oApplication.UpdateRSReportServer(xmlpath)

        ''''using the file IO to edit the rssrvpolicy.config
        '''Dim r As Integer, ckprt As Integer = 0
        '''Dim xmlrssrvpolicypath As String = Me.txtMSSQLServer.Text.Trim & "\ReportServer\rssrvpolicy.config"
        '''Dim textline As String
        '''If System.IO.File.Exists(xmlrssrvpolicypath) = True Then
        '''    Dim objReader As New System.IO.StreamReader(xmlrssrvpolicypath)
        '''    Do While objReader.Peek() <> -1
        '''        textline = textline & objReader.ReadLine() & vbNewLine
        '''        r = textline.IndexOf("Zone=""MyComputer""")
        '''        If r > 0 And ckprt = 0 Then
        '''            textline = textline & "<CodeGroup" & vbNewLine
        '''            textline = textline & "class=""UnionCodeGroup"" " & vbNewLine
        '''            textline = textline & "version=""1"" PermissionSetName=""FullTrust"" " & vbNewLine
        '''            textline = textline & "Name=""wvSQLDBCodeGroup"" " & vbNewLine
        '''            textline = textline & "Description=""Code group the Boost wv SQLDB Information data processing extension"">" & vbNewLine
        '''            textline = textline & " <IMembershipCondition " & vbNewLine
        '''            textline = textline & "class=""UrlMembershipCondition"" " & vbNewLine
        '''            textline = textline & "version=""1"" " & vbNewLine
        '''            textline = textline & "Url=""" & Me.txtMSSQLServer.Text.Trim & "\ReportServer\bin\wvSQLDB.dll" & """/>" & vbNewLine
        '''            textline = textline & "</CodeGroup> " & vbNewLine
        '''            ckprt = 1
        '''        End If
        '''    Loop

        '''    TextBox1.Text = textline
        '''    objReader.Close()
        '''Else
        '''    MsgBox("File " & xmlrssrvpolicypath & "Does Not Exist")
        '''End If

        '''If System.IO.File.Exists(xmlrssrvpolicypath) = True Then
        '''    Dim objWriter As New System.IO.StreamWriter(xmlrssrvpolicypath)
        '''    objWriter.Write(TextBox1.Text)
        '''    objWriter.Close()
        '''Else
        '''    MsgBox("File Does Not Exist")
        '''End If


        'copy wvSQLDB.dll to SQL Server Reporting Services
        'Dim strwvSQLDB As String = Application.StartupPath & "\InstallScripts\wvSQLDB.dll"
        'Dim strRSReportServer As String = Me.txtMSSQLServer.Text.Trim & "\ReportServer\bin"
        'Dim strRSReportManager As String = Me.txtMSSQLServer.Text.Trim & "\ReportManager\Bin"
        'Dim strServer As String = "cmd /c copy  " & """" & strwvSQLDB & """" & " " & """" & strRSReportServer & """"
        'Dim strManager As String = "cmd /c copy  " & """" & strwvSQLDB & """" & " " & """" & strRSReportManager & """"
        'Dim strReportServices As String = "rs -i " & """" & Application.StartupPath & "\InstallScripts\PublishWebvantageReports.rss" & """" & " -s http://" & Me.txtReportServerPath.Text.Trim & "/reportserver -v filePath=" & """" & Application.StartupPath & "\Reports" & """" & " -v parentFolder=" & """" & "Reports" & """" & " -v sqlServerName=" & """" & Me.txtReportServerPath.Text.Trim & """"

        'retval = Shell(strServer, vbNormalFocus)
        'retval = Shell(strManager, vbNormalFocus)
        'retval = Shell("cmd /c copy ""C:\Inetpub\wwwroot\webvantage2005\wvSQLDB.dll""  ""C:\Program Files\Microsoft SQL Server\MSSQL\Reporting Services\ReportManager\Bin""", vbNormalFocus)

        'run rss script.

        'retval = Shell(strReportServices, vbNormalFocus)
        'rs -i PublishWebvantageReports.rss -s http://localhost/reportserver -v filePath="C:\Inetpub\wwwroot\webvantage2005\REPORTS\Reports" -v parentFolder="Reports" -v sqlServerName="Programming"

    End Sub
    Private Sub btnTestConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTestConnection.Click

        Dim strConnString As String
        Dim oApplication As cApplication
        Dim dblReturn As Double

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
            If Database.ContainsIllegalCharacters(Me.txtPassword.Text.Trim) = True Then

                MsgBox("Password cannot include characters:  ?, #, /, or & .", MsgBoxStyle.Critical, "Test Connection")
                Me.txtPassword.Focus()
                Exit Sub

            End If

            strConnString = "Persist Security Info=False;Data Source=" & Me.txtSQLServerName.Text.Trim
            strConnString &= ";Initial Catalog=" & Me.txtDatabaseName.Text.Trim
            strConnString &= ";User ID=" & Me.txtUserName.Text.Trim & ";Password=" & Me.txtPassword.Text.Trim

        End If

        Me.GlobalConnString = strConnString
        oApplication = New cApplication(strConnString)
        dblReturn = oApplication.dbTestConnection()

        'AC: Code needs to be clean up!
        If dblReturn = -1 Then
            MsgBox("Test Failed!" & Err.Description, MsgBoxStyle.OkOnly, "Test Connection")
            Me.lblDatabaseVersion.Text = " No Database Version"
            Me.btnRun.Enabled = False
        Else
            If dblReturn = -2 Then
                MsgBox("Test Failed! You need to upgrade Advantage to version 5.4.1", MsgBoxStyle.OkOnly, "Test Connection")
                Me.lblDatabaseVersion.Text = " No Database Version"
                Me.btnRun.Enabled = False
            Else
                If dblReturn <= 0 Then
                    MsgBox("Test successful!  No Database version", MsgBoxStyle.OkOnly, "Test Connection")
                    Me.lblDatabaseVersion.Text = "No Database Version"
                    Me.btnRun.Enabled = True
                Else
                    MsgBox("Test successful!  Database version: " & dblReturn, MsgBoxStyle.OkOnly, "Test Connection")
                    Me.lblDatabaseVersion.Text = "Database Version: " & dblReturn
                    Me.btnRun.Enabled = True
                End If
            End If
        End If
    End Sub
    Private Sub btnRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRun.Click
        'Me.Disco()
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
            MsgBox("Process Completed!", MsgBoxStyle.OkOnly, "Database Script")

        Catch
            MsgBox("Process Failed!", MsgBoxStyle.Critical, "Database Script")
        End Try
        Me.Cursor.Current = Cursors.Default

    End Sub
    Private Sub btnSetupVirtDir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetupVirtDir.Click
        Me.btnSetupVirtDir.Enabled = False
        Me.Cursor = Cursors.WaitCursor
        Dim strConnString As String = ""
        PBarIIS.Maximum = 5
        PBarIIS.Minimum = 1
        PBarIIS.Value = 1

        Dim iisShutdownWaitTime As Integer = 10000
        Try
            iisShutdownWaitTime = CInt(System.Configuration.ConfigurationManager.AppSettings("IISSHUTDOWNWAIT"))
        Catch iisx As Exception

        End Try

        If Me.txtVirtualDirectory.Text.Trim = "" Then
            MsgBox("Please enter a valid Virtual Directory.", MsgBoxStyle.Critical, "Setup Virtual Directory")
            Me.txtVirtualDirectory.Focus()
            Me.btnSetupVirtDir.Enabled = True
            Me.Cursor = Cursors.Default

            Exit Sub
        End If
        If Me.txtPhysicalPath.Text.Trim = "" Then
            MsgBox("Please enter a valid Physical Path.", MsgBoxStyle.Critical, "Setup Virtual Directory")
            Me.txtPhysicalPath.Focus()
            Me.btnSetupVirtDir.Enabled = True
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        If Me.txtIISServer.Text.Trim = "" Then
            MsgBox("Please enter a valid IIS Server Name.", MsgBoxStyle.Critical, "Setup Virtual Directory")
            Me.txtIISServer.Focus()
            Me.btnSetupVirtDir.Enabled = True
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        Dim oApplication As cApplication = New cApplication(strConnString)
        PBarIIS.Value = 2
        Me.lblProgress.Text = "Progress: Checking virtual directory."
        Application.DoEvents()
        If Me.chkVirtualDirectory.Checked Then
            Me.Cursor.Current = Cursors.WaitCursor
            'Remove old copy if exists.
            If Directory.Exists(txtPhysicalPath.Text.Trim) = True Then
                If MessageBox.Show("Directory exists. Would you like to delete and upgrade?", "Directory Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    Me.lblProgress.Text = "Progress: Stopping IIS."
                    Application.DoEvents()
                    STOPIIS()

                    Threading.Thread.Sleep(iisShutdownWaitTime)
                    Me.lblProgress.Text = "Progress: Deleting virtual directory."
                    Application.DoEvents()
                    'System.IO.File.SetAttributes(txtPhysicalPath.Text.Trim, System.IO.FileAttributes.Normal)
                    ProcessTree(txtPhysicalPath.Text.Trim)
                    Threading.Thread.Sleep(1000)
                    Try
                        DebugPrint("Temp Directory for RadControls spell: " + txtPhysicalPath.Text.Trim + "\App_Data\RadSpell\") '"\RadControls\Spell\TDF\")
                        If Not Directory.Exists("C:\advtemp") Then
                            Directory.CreateDirectory("C:\advtemp")
                        End If
                        CopyDirectoryWithGraphics(txtPhysicalPath.Text.Trim + "\App_Data\RadSpell\", "C:\advTemp\")
                        Threading.Thread.Sleep(5000)

                        Dim currentDirectory As DirectoryInfo = New DirectoryInfo(txtPhysicalPath.Text.Trim)

                        For Each di As DirectoryInfo In currentDirectory.GetDirectories.ToList

                            If di.Name.ToUpper = "TEMP".ToUpper OrElse di.Name.ToUpper = "CacheDependency".ToUpper Then

                                'do nothing

                            Else

                                Directory.Delete(di.FullName, True)

                            End If

                        Next

                        For Each FileInfo As FileInfo In currentDirectory.GetFiles().ToList

                            If FileInfo.Name.ToUpper = "Web.config".ToUpper Then

                                'do nothing

                            Else

                                FileInfo.Delete()

                            End If

                        Next

                        'Directory.Delete(txtPhysicalPath.Text.Trim, True)
                    Catch DeleteX As Exception
                        MessageBox.Show(DeleteX.Message, "Error Deleting")
                    End Try
                    PBarIIS.Value = 3
                Else
                    Me.btnSetupVirtDir.Enabled = True
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
            Else
                'No longer stop iis if Advantage isnt on the system.
                'Me.lblProgress.Text = "Progress: Stopping IIS."
                ' Application.DoEvents()
                'STOPIIS()
                ' Threading.Thread.Sleep(iisShutdownWaitTime)
            End If

            'copy file to inetpub.

            Try
                Me.lblProgress.Text = "Progress: Creating directory."
                Application.DoEvents()
                Directory.CreateDirectory(Me.txtPhysicalPath.Text.Trim)
                PBarIIS.Value = 4
                Application.DoEvents()
                Me.lblProgress.Text = "Progress: Copying Files."
                If isClientPortal = True Then
                    CopyDirectoryWithGraphicsCP(Application.StartupPath, Me.txtPhysicalPath.Text.Trim)
                Else
                    CopyDirectoryWithGraphicsWV(Application.StartupPath, Me.txtPhysicalPath.Text.Trim)
                End If
                'Copy Spell TDF back.
                DebugPrint("Copying TDF from c:\advtemp to " + txtPhysicalPath.Text.Trim + "\App_Data\RadSpell\")
                CopyDirectoryWithGraphics("C:\advTemp\", txtPhysicalPath.Text.Trim + "\App_Data\RadSpell\")
                'oApplication.CopyDirectory(Application.StartupPath & "\ig_common", Me.txtIGCopyFiles.Text.Trim)
            Catch
                'directory already exists.
            End Try
            Me.Cursor.Current = Cursors.Default
            If Not IsNumeric(txtSessionTimeout.Text) Then
                MessageBox.Show("You must select a valid numeric value for session timeout.")
                Me.btnSetupVirtDir.Enabled = True
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
            'Create Virtual Directory
            'oApplication.set_WebVirtDir(Me.txtVirtualDirectory.Text.Trim, Me.txtPhysicalPath.Text.Trim, oWebSites(Me.drpIISWebsite.SelectedIndex).WebSitePath)
            Me.lblProgress.Text = "Progress: Creating virtual directory."
            Application.DoEvents()
            oApplication.CreateVirtualDir(oWebSites(Me.drpIISWebsite.SelectedIndex).WebSitePath, txtVirtualDirectory.Text, Me.txtPhysicalPath.Text.Trim, txtSessionTimeout.Text)
            PBarIIS.Value = 5
            If Err.Number <> 0 Then
                MsgBox("An error occurred while installing the Webvantage Virtual Directory - " & vbCrLf &
                    "     - Error Details: " & Err.Description & " [Number:" &
                    Hex(Err.Number) & "]", vbCritical, g_PageTitle)
                Me.btnSetupVirtDir.Enabled = True
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

        End If
        'If Me.chkIGCommon.Checked = True Then
        '    oApplication.set_WebVirtDir("ig_common", Me.txtIGCopyFiles.Text.Trim, oWebSites(Me.drpIISWebsite.SelectedIndex).WebSitePath)

        '    If Err.Number <> 0 Then
        '        MsgBox("An error occurred while installing the ig_common Virtual Directory - " & vbCrLf & _
        '            "     - Error Details: " & Err.Description & " [Number:" & _
        '            Hex(Err.Number) & "]", vbCritical, g_PageTitle)
        '        Exit Sub
        '    End If
        'End If
        PBarIIS.Maximum = 4

        PBarIIS.Value = 1
        Me.lblProgress.Text = "Progress: Setting permissions."
        Application.DoEvents()
        If SetACEPermissions(txtPhysicalPath.Text.Trim, strConnString) = False Then
            MsgBox("Could not set directory permissions.")
        End If
        PBarIIS.Value = 2
        Me.lblProgress.Text = "Progress: Starting IIS."
        PBarIIS.Value = 3
        Application.DoEvents()
        STARTIIS()
        PBarIIS.Value = 4
        'If Me.IsStateServiceRunning() = False Then
        '    PBarIIS.Value = 5
        'End If
        Me.lblProgress.Text = "Progress: Complete."
        Me.PBarIIS.Value = 1
        'MsgBox("Web Virtual Directory Created!", MsgBoxStyle.OkOnly, "Create Web Virtual Directory")
        Me.btnSetupVirtDir.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub btnHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHelp.Click
        Try
            Dim frmhelp As frmHelp = New frmHelp
            frmhelp.Show()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btnLoadWebsites_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadWebsites.Click
        Try
            LoadWebSitesCollection("localhost")
            Try
                With drpIISWebsite
                    .DataSource = oWebSites
                    .DisplayMember = "Name"
                    .ValueMember = "PhysicalPath"
                    .SelectedIndex = 0
                End With
                If Me.txtVirtualDirectory.Text = "" Then
                    Me.txtPhysicalPath.Text = Me.drpIISWebsite.SelectedValue & "\webvantage"
                Else
                    Me.txtPhysicalPath.Text = Me.drpIISWebsite.SelectedValue & "\" & Me.txtVirtualDirectory.Text
                End If
                Me.btnSetupVirtDir.Enabled = True

            Catch ex As Exception
                MsgBox("Error:  Loading IIS")
            End Try
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbSSA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSSA.CheckedChanged
        Try
            Me.txtUserName.Enabled = True
            Me.txtPassword.Enabled = True
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbWIA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbWIA.CheckedChanged
        Try
            Me.txtUserName.Enabled = False
            Me.txtPassword.Enabled = False
        Catch ex As Exception
        End Try
    End Sub
    Private Sub txtIISServer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.btnSetupVirtDir.Enabled = False
    End Sub
    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click

        Dim btn As Button = DirectCast(sender, Button)
        Dim index As Integer = CType(btn.Tag, Integer)

        dlgFile.CheckFileExists = True
        dlgFile.ShowReadOnly = False
        dlgFile.Filter = "Web Config (*.config)|*.config|Text Files (*.txt)|*.txt|VB .NET Files (*.vb, *.resx, *.sln, *.vbproj)|*.vb;*.resx;*.sln;*.vbproj|Bitmaps (*.bmp)|*.bmp|All Files (*.*)|*.*"
        dlgFile.FileName = " "

        If System.IO.Directory.Exists(Me.txtwebconfig1.Text) Then

            dlgFile.InitialDirectory = Me.txtwebconfig1.Text

        End If

        If dlgFile.ShowDialog() = DialogResult.OK Then

            Me.txtwebconfig1.Text = dlgFile.FileName

        End If

        Try

            Dim myConfig As New XmlDocument 'webconfig is xml
            Dim strPhysicalPathToWebConfig As String = Me.txtwebconfig1.Text.ToString

            myConfig.Load(strPhysicalPathToWebConfig) 'load the webconfig

            Dim nsmgr As XmlNamespaceManager = New XmlNamespaceManager(myConfig.NameTable)
            nsmgr.AddNamespace("web", "")
            Dim x As XmlNode
            Dim r As XmlElement = myConfig.DocumentElement

            rbNTAuthentication.Checked = r.SelectSingleNode("//web:add[@key='Authentication']/@value", nsmgr).Value = "Windows"

            Me.chkUpperCaseUser.Checked = CType(r.SelectSingleNode("//web:add[@key='UpperCaseUser']/@value", nsmgr).Value, Boolean)
            Me.chkChooseServer.Checked = CType(r.SelectSingleNode("//web:add[@key='ChooseServer']/@value", nsmgr).Value, Boolean)
            Me.chkSQLControledAdmin.Checked = CType(r.SelectSingleNode("//web:add[@key='SQLControledAdmin']/@value", nsmgr).Value, Boolean)
            Me.chkUpperCaseDatabase.Checked = CType(r.SelectSingleNode("//web:add[@key='UpperCaseDatabase']/@value", nsmgr).Value, Boolean)
            Me.TxtTimeOutMinutes.Text = r.SelectSingleNode("//web:add[@key='TimeOutUserInMinutes']/@value", nsmgr).Value

            Me.Chk_NTAuth_UserCode_IgnoreCase.Checked = CType(r.SelectSingleNode("//web:add[@key='NTAuthIgnoreCase']/@value", nsmgr).Value, Boolean)
            Me.cboCustomErrors.SelectedIndex = Me.cboCustomErrors.FindString(r.SelectSingleNode("//web:customErrors/@mode", nsmgr).Value)

            Me.CheckBoxRequireSSL.Checked = CType(r.SelectSingleNode("//web:httpCookies/@requireSSL", nsmgr).Value, Boolean)

            ClientPortalKey = r.SelectSingleNode("//web:add[@key='VCtrlCP']/@value", nsmgr).Value

        Catch ex As Exception

            MsgBox("Error reading web.config file. " & Environment.NewLine & ex.Message.ToString())
            Exit Sub

        End Try

        If isClientPortal = False Then

            LoadChatDatabaseInfoFromRegistry()

        End If

    End Sub
    Private Sub btnChangeSMTPSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeSMTPSettings.Click

        Dim ds As DataSet
        Dim IntTimeOut As Integer = 0

        If Me.txtwebconfig1.Text.Trim = "" Then

            MsgBox("Please select a valid web.config file.", MsgBoxStyle.Critical, "Save Settings")
            Me.txtwebconfig1.Focus()

            Exit Sub

        End If
        Try

            If Me.TxtTimeOutMinutes.Text = "" Or IsNumeric(Me.TxtTimeOutMinutes.Text) = False Then

                MsgBox("Please enter a valid time out in minutes", MsgBoxStyle.Critical, "Save Settings")
                Me.TxtTimeOutMinutes.Focus()
                Exit Sub

            Else

                IntTimeOut = CType(Me.TxtTimeOutMinutes.Text, Integer)

            End If

        Catch ex As Exception
            IntTimeOut = 20
        End Try
        Try

            Dim strAuth As String = String.Empty
            Dim boolImp As Boolean
            Dim AlertRefresh As Double

            If Me.rbNTAuthentication.Checked = True Then

                strAuth = "Windows"

            Else

                strAuth = "Forms"

            End If

            boolImp = Me.rbNTAuthentication.Checked

            ConfigureAppAuthentication(boolImp)
            ConfigureWebConfigs(boolImp)

            writeAppSettings(Me.txtwebconfig1.Text.Trim, strAuth, "http://" & Me.txtConfigReportingServices.Text.Trim & "/reportserver/",
                             Me.txtSMTPAddress.Text.Trim, Me.txtEmailFromAddress.Text.Trim, Me.txtEmailUserName.Text.Trim, Me.txtemailpassword.Text.Trim,
                             Me.chkUpperCaseUser.Checked, Me.chkUpperCaseDatabase.Checked, Me.chkChooseServer.Checked, Me.chkSQLControledAdmin.Checked.ToString, boolImp,
                             Me.ChkBxIsOnWebFarm.Checked.ToString.ToLower, Me.ChkBxUseSysLogon.Checked.ToString, Me.TxtAdmDatabaseName.Text, IntTimeOut, -1,
                             Me.cboCustomErrors.Text, Me.Chk_NTAuth_UserCode_IgnoreCase.Checked,
                             Me.TextBoxChatServerName.Text, Me.TextBoxChatDatabaseName.Text, Me.TextBoxChatUsername.Text, Me.TextBoxChatPassword.Text,
                             Me.CheckBoxRequireSSL.Checked)

        Catch
            MsgBox("Change settings failed!", MsgBoxStyle.Critical, "Change Settings")
        End Try

        If SaveChatDatabaseInfo() = True Then


        End If

    End Sub
    Private Sub chkVirtualDirectory_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVirtualDirectory.CheckedChanged
        Try
            If Me.chkVirtualDirectory.Checked Then
                Me.txtVirtualDirectory.Enabled = True
                Me.txtPhysicalPath.Enabled = True
            Else
                Me.txtVirtualDirectory.Enabled = False
                Me.txtPhysicalPath.Enabled = False
            End If
            ChangePhysicalDir()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub txtVirtualDirectory_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVirtualDirectory.TextChanged
        Try
            ChangePhysicalDir()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub drpIISWebsite_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drpIISWebsite.SelectedIndexChanged
        If bnLoad = False Then
            ChangePhysicalDir()
        End If
    End Sub
    Private Sub txtEmailFromAddress_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtEmailFromAddress.Validating
        Dim re As RegularExpressions.Regex = New RegularExpressions.Regex("^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$")
        If re.IsMatch(txtEmailFromAddress.Text) = False Then
            epEmailAddress.SetError(txtEmailFromAddress, "Email not in correct format.")
            e.Cancel = True
            Return
        End If
        epEmailAddress.SetError(txtEmailFromAddress, "")
    End Sub
    Private Sub txtretypeemailpassword_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtretypeemailpassword.Validating
        If (txtemailpassword.Text.Trim <> txtretypeemailpassword.Text.Trim) Then
            epEmailPassword.SetError(txtretypeemailpassword, "Passwords do not match! Password above is '" & txtemailpassword.Text.Trim & "'")
            e.Cancel = True
            Return
        End If
        epEmailPassword.SetError(txtretypeemailpassword, "")
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDeleteCache.Click
        Dim di As New System.IO.DirectoryInfo("C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\Temporary ASP.NET Files")
        di.Delete(True)
    End Sub
    Private Sub ChkBxIsOnWebFarm_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.ChkBxIsOnWebFarm.Checked = True Then
            Me.ChkBxUseSysLogon.Checked = False
            Me.ChkBxUseSysLogon.Enabled = False
            Me.TxtAdmServerName.Text = ""
            Me.TxtAdmServerName.Enabled = False
            Me.TxtAdmDatabaseName.Text = ""
            Me.TxtAdmDatabaseName.Enabled = False
            Me.TxtAdmUserName.Text = ""
            Me.TxtAdmUserName.Enabled = False
            Me.TxtAdmPassword.Text = ""
            Me.TxtAdmPassword.Enabled = False
        Else
            Me.ChkBxUseSysLogon.Checked = True
            Me.ChkBxUseSysLogon.Enabled = True
            Me.TxtAdmServerName.Enabled = True
            Me.TxtAdmDatabaseName.Enabled = True
            Me.TxtAdmUserName.Enabled = True
            Me.TxtAdmPassword.Enabled = True
        End If
    End Sub
    Private Sub ChkBxUseSysLogon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.ChkBxUseSysLogon.Checked = True Then
            Me.TxtAdmServerName.Text = ""
            Me.TxtAdmServerName.Enabled = False
            Me.TxtAdmDatabaseName.Text = ""
            Me.TxtAdmDatabaseName.Enabled = False
            Me.TxtAdmUserName.Text = ""
            Me.TxtAdmUserName.Enabled = False
            Me.TxtAdmPassword.Text = ""
            Me.TxtAdmPassword.Enabled = False
        Else
            Me.TxtAdmServerName.Enabled = True
            Me.TxtAdmDatabaseName.Enabled = True
            Me.TxtAdmUserName.Enabled = True
            Me.TxtAdmPassword.Enabled = True
        End If
    End Sub
    Private Sub txtPhysicalPath_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPhysicalPath.TextChanged
        txtwebconfig1.Text = txtPhysicalPath.Text
    End Sub
    Private Sub chkChooseServer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkChooseServer.CheckedChanged

        If isClientPortal = False Then

            If chkChooseServer.Checked = False Then

                gbRegistry.Visible = True
                lblRegistryWarn.Visible = False
                FillRegistryPage()

            Else

                If Me.rbNTAuthentication.Checked = False Then

                    gbRegistry.Visible = False
                    lblRegistryWarn.Visible = True

                End If

            End If

        End If

    End Sub
    Private Sub tvRegistry_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvRegistry.AfterSelect
        If Not IsNothing(tvRegistry.SelectedNode.Tag.ToString) Then

            Dim aRegData() As String = Split(tvRegistry.SelectedNode.Tag.ToString, "\")
            If aRegData(aRegData.GetUpperBound(0) - 2) = "Servers" Then
                Me.txtRegistryServer.Text = aRegData(aRegData.GetUpperBound(0) - 1)
                Me.txtRegistryDatabase.Text = aRegData(aRegData.GetUpperBound(0))
                EntryEnable(True)
                tvRegistry.SelectedImageIndex = 1
                'Me.txtRegistryDatabase.Enabled = True
            Else
                Me.txtRegistryServer.Text = aRegData(aRegData.GetUpperBound(0))
                Me.txtRegistryDatabase.Text = ""
                EntryEnable(False)
                tvRegistry.SelectedImageIndex = 0
                'Me.txtRegistryDatabase.Enabled = False
            End If



            If tvRegistry.SelectedNode.GetNodeCount(True) = 0 Then
                'MessageBox.Show(tvRegistry.SelectedNode.Tag.ToString)
                Try
                    Me.txtAdminUsername.Text = My.Computer.Registry.GetValue(tvRegistry.SelectedNode.Tag.ToString, "Username", Nothing).ToString
                    Me.txtAdminPassword.Text = Decrypt(My.Computer.Registry.GetValue(tvRegistry.SelectedNode.Tag.ToString, "Password", Nothing).ToString)
                    Me.txtClientPortalUsername.Text = My.Computer.Registry.GetValue(tvRegistry.SelectedNode.Tag.ToString, "CPUsername", Nothing).ToString
                    Me.txtClientPortalPassword.Text = Decrypt(My.Computer.Registry.GetValue(tvRegistry.SelectedNode.Tag.ToString, "CPPassword", Nothing).ToString)

                Catch x As Exception
                    Me.txtAdminUsername.Text = ""
                    Me.txtAdminPassword.Text = ""
                    Me.txtClientPortalUsername.Text = ""
                    Me.txtClientPortalPassword.Text = ""
                    EntryEnable(False)

                End Try
            End If
        End If
        tvRegistry.ExpandAll()
    End Sub
    Private Sub btnSaveRegistry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveRegistry.Click
        'If is64Bit() = False Then
        '    Try
        '        If Me.txtRegistryDatabase.Text.Length > 0 And Me.txtRegistryServer.Text.Length > 0 Then
        '            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Advantage\Servers\" + Me.txtRegistryServer.Text + "\" + Me.txtRegistryDatabase.Text, "Username", Me.txtAdminUsername.Text)
        '            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Advantage\Servers\" + Me.txtRegistryServer.Text + "\" + Me.txtRegistryDatabase.Text, "Password", Me.txtAdminPassword.Text)
        '            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Advantage\Servers\" + Me.txtRegistryServer.Text + "\" + Me.txtRegistryDatabase.Text, "CPUsername", Me.txtClientPortalUsername.Text)
        '            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Advantage\Servers\" + Me.txtRegistryServer.Text + "\" + Me.txtRegistryDatabase.Text, "CPPassword", Me.txtClientPortalPassword.Text)
        '        Else
        '            MessageBox.Show("You must select a valid database")
        '            Exit Sub
        '        End If
        '    Catch x As Exception
        '        MessageBox.Show(x.Message, "Data was NOT saved!")
        '        Exit Sub
        '    Finally
        '        FillRegistryPage()
        '    End Try
        '    MessageBox.Show("Data saved!")
        'Else '\WOW6432Node
        '    Try
        '        If Me.txtRegistryDatabase.Text.Length > 0 And Me.txtRegistryServer.Text.Length > 0 Then
        '            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Advantage\Servers\" + Me.txtRegistryServer.Text + "\" + Me.txtRegistryDatabase.Text, "Username", Me.txtAdminUsername.Text)
        '            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Advantage\Servers\" + Me.txtRegistryServer.Text + "\" + Me.txtRegistryDatabase.Text, "Password", Me.txtAdminPassword.Text)
        '            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Advantage\Servers\" + Me.txtRegistryServer.Text + "\" + Me.txtRegistryDatabase.Text, "CPUsername", Me.txtClientPortalUsername.Text)
        '            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Advantage\Servers\" + Me.txtRegistryServer.Text + "\" + Me.txtRegistryDatabase.Text, "CPPassword", Me.txtClientPortalPassword.Text)
        '        Else
        '            MessageBox.Show("You must select a valid database")
        '            Exit Sub
        '        End If
        '    Catch x As Exception
        '        MessageBox.Show(x.Message, "Data was NOT saved!")
        '        Exit Sub
        '    Finally
        '        FillRegistryPage()
        '    End Try
        '    MessageBox.Show("Data saved!")
        'End If

        Try
            If Me.txtRegistryDatabase.Text.Length > 0 And Me.txtRegistryServer.Text.Length > 0 Then
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Advantage\Servers\" + Me.txtRegistryServer.Text + "\" + Me.txtRegistryDatabase.Text, "Username", Me.txtAdminUsername.Text)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Advantage\Servers\" + Me.txtRegistryServer.Text + "\" + Me.txtRegistryDatabase.Text, "Password", Encrypt(Me.txtAdminPassword.Text))
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Advantage\Servers\" + Me.txtRegistryServer.Text + "\" + Me.txtRegistryDatabase.Text, "CPUsername", Me.txtClientPortalUsername.Text)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Advantage\Servers\" + Me.txtRegistryServer.Text + "\" + Me.txtRegistryDatabase.Text, "CPPassword", Encrypt(Me.txtClientPortalPassword.Text))
            Else
                MessageBox.Show("You must select a valid database")
                Exit Sub
            End If
        Catch x As Exception
            MessageBox.Show(x.Message, "Data was NOT saved!")
            Exit Sub
        Finally
        End Try

        Try
            If is64Bit() = True Then

                If Me.txtRegistryDatabase.Text.Length > 0 And Me.txtRegistryServer.Text.Length > 0 Then
                    My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Advantage\Servers\" + Me.txtRegistryServer.Text + "\" + Me.txtRegistryDatabase.Text, "Username", Me.txtAdminUsername.Text)
                    My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Advantage\Servers\" + Me.txtRegistryServer.Text + "\" + Me.txtRegistryDatabase.Text, "Password", Encrypt(Me.txtAdminPassword.Text))
                    My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Advantage\Servers\" + Me.txtRegistryServer.Text + "\" + Me.txtRegistryDatabase.Text, "CPUsername", Me.txtClientPortalUsername.Text)
                    My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Advantage\Servers\" + Me.txtRegistryServer.Text + "\" + Me.txtRegistryDatabase.Text, "CPPassword", Encrypt(Me.txtClientPortalPassword.Text))
                End If

            End If

        Catch x As Exception
        Finally
        End Try

        FillRegistryPage()
        MessageBox.Show("Data saved!")

    End Sub
    Private Sub btnAddReg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddReg.Click
        'If is64Bit() = False Then
        '    If Me.txtRegistryDatabase.Text.Length > 0 And Me.txtRegistryServer.Text.Length > 0 Then
        '        Dim sServer As String = txtRegistryServer.Text.ToString.Replace("\", "#")
        '        Dim sDatabase As String = txtRegistryDatabase.Text.ToString.Replace("\", "#")
        '        If IsNothing(My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Advantage\Servers\" + sServer + "\" + sDatabase, "Username", Nothing)) Then
        '            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Advantage\Servers\" + sServer + "\" + sDatabase, "Username", "")
        '            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Advantage\Servers\" + sServer + "\" + sDatabase, "Password", "")
        '            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Advantage\Servers\" + sServer + "\" + sDatabase, "CPUsername", "")
        '            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Advantage\Servers\" + sServer + "\" + sDatabase, "CPPassword", "")
        '        Else
        '            MessageBox.Show("Server and Database are already added!")
        '        End If
        '    Else
        '        MessageBox.Show("You must have both a Server and a Database entered!")
        '    End If
        '    FillRegistryPage()

        '    tvRegistry.SelectedNode = GetNode(Me.txtRegistryServer.Text, Me.txtRegistryDatabase.Text, tvRegistry.Nodes)
        'Else
        '    If Me.txtRegistryDatabase.Text.Length > 0 And Me.txtRegistryServer.Text.Length > 0 Then
        '        Dim sServer As String = txtRegistryServer.Text.ToString.Replace("\", "#")
        '        Dim sDatabase As String = txtRegistryDatabase.Text.ToString.Replace("\", "#")
        '        If IsNothing(My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Advantage\Servers\" + sServer + "\" + sDatabase, "Username", Nothing)) Then
        '            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Advantage\Servers\" + sServer + "\" + sDatabase, "Username", "")
        '            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Advantage\Servers\" + sServer + "\" + sDatabase, "Password", "")
        '            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Advantage\Servers\" + sServer + "\" + sDatabase, "CPUsername", "")
        '            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Advantage\Servers\" + sServer + "\" + sDatabase, "CPPassword", "")
        '        Else
        '            MessageBox.Show("Server and Database are already added!")
        '        End If
        '    Else
        '        MessageBox.Show("You must have both a Server and a Database entered!")
        '    End If
        '    FillRegistryPage()
        '    tvRegistry.SelectedNode = GetNode(Me.txtRegistryServer.Text, Me.txtRegistryDatabase.Text, tvRegistry.Nodes)

        'End If

        If Me.txtRegistryDatabase.Text.Length > 0 And Me.txtRegistryServer.Text.Length > 0 Then
            Dim sServer As String = txtRegistryServer.Text.ToString.Replace("\", "#")
            Dim sDatabase As String = txtRegistryDatabase.Text.ToString.Replace("\", "#")
            If IsNothing(My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Advantage\Servers\" + sServer + "\" + sDatabase, "Username", Nothing)) Then
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Advantage\Servers\" + sServer + "\" + sDatabase, "Username", "")
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Advantage\Servers\" + sServer + "\" + sDatabase, "Password", "")
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Advantage\Servers\" + sServer + "\" + sDatabase, "CPUsername", "")
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Advantage\Servers\" + sServer + "\" + sDatabase, "CPPassword", "")
            Else
                MessageBox.Show("Server and Database are already added!")
            End If
        Else
            MessageBox.Show("You must have both a Server and a Database entered!")
        End If
        Try
            If is64Bit() = True Then
                Dim sServer As String = txtRegistryServer.Text.ToString.Replace("\", "#")
                Dim sDatabase As String = txtRegistryDatabase.Text.ToString.Replace("\", "#")
                If IsNothing(My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Advantage\Servers\" + sServer + "\" + sDatabase, "Username", Nothing)) Then
                    My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Advantage\Servers\" + sServer + "\" + sDatabase, "Username", "")
                    My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Advantage\Servers\" + sServer + "\" + sDatabase, "Password", "")
                    My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Advantage\Servers\" + sServer + "\" + sDatabase, "CPUsername", "")
                    My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Advantage\Servers\" + sServer + "\" + sDatabase, "CPPassword", "")
                End If
            End If
        Catch ex As Exception
        End Try

        FillRegistryPage()
        tvRegistry.SelectedNode = GetNode(Me.txtRegistryServer.Text, Me.txtRegistryDatabase.Text, tvRegistry.Nodes)

    End Sub
    Private Sub btnDeleteReg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteReg.Click

        If is64Bit() = False Then
            If Me.txtRegistryDatabase.Text.Length > 0 And Me.txtRegistryServer.Text.Length > 0 Then
                Try
                    Dim oReg As Microsoft.Win32.RegistryKey
                    oReg = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Advantage\Servers\" + Me.txtRegistryServer.Text, True)
                    oReg.DeleteSubKeyTree(Me.txtRegistryDatabase.Text)
                    oReg.Close()
                Catch x As Exception
                    MessageBox.Show(x.Message.ToString, "Unable to delete.")
                End Try
            Else
                If Me.txtRegistryServer.Text.Length > 0 Then
                    Try
                        Dim oReg As Microsoft.Win32.RegistryKey
                        oReg = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Advantage\Servers", True)
                        oReg.DeleteSubKeyTree(Me.txtRegistryServer.Text)
                    Catch ex As Exception
                        MessageBox.Show(ex.Message.ToString, "Unable to delete.")
                    End Try
                End If
            End If
            FillRegistryPage()
            Me.txtRegistryServer.Text = ""
            Me.txtRegistryDatabase.Text = ""
            EntryEnable(False)
        Else
            If Me.txtRegistryDatabase.Text.Length > 0 And Me.txtRegistryServer.Text.Length > 0 Then
                Try
                    Dim oReg As Microsoft.Win32.RegistryKey
                    oReg = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\WOW6432Node\Advantage\Servers\" + Me.txtRegistryServer.Text, True)
                    oReg.DeleteSubKeyTree(Me.txtRegistryDatabase.Text)
                    oReg.Close()
                Catch x As Exception
                    MessageBox.Show(x.Message.ToString, "Unable to delete.")
                End Try
            Else
                If Me.txtRegistryServer.Text.Length > 0 Then
                    Try
                        Dim oReg As Microsoft.Win32.RegistryKey
                        oReg = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\WOW6432Node\Advantage\Servers", True)
                        oReg.DeleteSubKeyTree(Me.txtRegistryServer.Text)
                    Catch ex As Exception
                        MessageBox.Show(ex.Message.ToString, "Unable to delete.")
                    End Try
                End If
            End If
            FillRegistryPage()
            Me.txtRegistryServer.Text = ""
            Me.txtRegistryDatabase.Text = ""
            EntryEnable(False)

        End If
    End Sub
    Private Sub btnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreate.Click
        btnCreate.Enabled = False
        Me.Cursor = Cursors.WaitCursor
        Dim strURL As String = Me.txtURL.Text
        Process.Start(strURL)
        If MessageBox.Show("Has the website started?", "Starting Web Site", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Threading.Thread.Sleep(5000)

            If File.Exists(".\disco.exe") Then
            Else
                MsgBox("Please ensure that the disco.exe file is located" & vbCrLf & "in the Webvantage directory and try again.", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Dim fY As New Font(Me.lblWarning.Font, FontStyle.Regular)
            If RunDisco() Then
                With Me.lblWarning
                    .ForeColor = Color.Black
                    .Font = fY
                    .Text = "The operation was successful!"
                End With
            Else
                With Me.lblWarning
                    .ForeColor = Color.Red
                    .Font = fY
                    .Text = "The operation failed!" & vbCrLf & "Please check the URL and try again" & vbCrLf & "Please report all issues to Advantage Tech Support."
                End With
            End If
        Else
            MessageBox.Show("Please access the site once before setting web services url.")
        End If
        btnCreate.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub txtURL_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtURL.TextChanged
        Dim strURL As String = Me.txtURL.Text = Me.txtURL.Text.ToLower
        If Not Me.txtURL.Text.StartsWith("http") And Me.txtURL.Text.Length() > 3 Then
            Dim fN As New Font(Me.lblWarning.Font, FontStyle.Italic)
            Me.txtURL.ForeColor = Color.Red
            With Me.lblWarning
                .ForeColor = Color.Red
                .Font = fN
                .Text = "The URL must start with ""http:"" or ""https:"""
            End With
        Else
            If Me.txtURL.Text.Length() < 4 Then
                Me.btnCreate.Enabled = False
            Else

                Dim fY As New Font(Me.lblWarning.Font, FontStyle.Regular)
                Me.txtURL.ForeColor = Color.Black
                With Me.lblWarning
                    .ForeColor = Color.Black
                    .Font = fY
                    .Text = ""
                End With
                Me.btnCreate.Enabled = True
            End If
        End If
    End Sub
    Private Sub rbNTAuthentication_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbNTAuthentication.CheckedChanged
        If isClientPortal = False Then

            If Me.rbNTAuthentication.Checked = True Then
                Me.Chk_NTAuth_UserCode_IgnoreCase.Enabled = True
                gbRegistry.Visible = True
                lblRegistryWarn.Visible = False
                FillRegistryPage()
            Else
                Me.Chk_NTAuth_UserCode_IgnoreCase.Checked = False
                Me.Chk_NTAuth_UserCode_IgnoreCase.Enabled = False
                If chkChooseServer.Checked = True Then
                    gbRegistry.Visible = False
                    lblRegistryWarn.Visible = True
                End If
            End If

        End If
    End Sub
    Private Sub rbSqlAuthentication_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSqlAuthentication.CheckedChanged
        If Me.rbSqlAuthentication.Checked = True Then
            Me.Chk_NTAuth_UserCode_IgnoreCase.Checked = False
            Me.Chk_NTAuth_UserCode_IgnoreCase.Enabled = False
        Else
            Me.Chk_NTAuth_UserCode_IgnoreCase.Enabled = True
        End If
    End Sub
    Private Sub btnSmtpInstall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSmtpInstall.Click

        Try

            Dim sSystem32Directory As String = System.Environment.ExpandEnvironmentVariables("%SystemRoot%")

            If is64Bit() = True Then

                Dim Installed64Path As String = sSystem32Directory + "\System32\Mailbee64.dll"
                Dim Installed32Path As String = sSystem32Directory + "\SysWow64\Mailbee.dll"
                Dim App64Path As String = Application.StartupPath & "\SMTP\Mailbee64.dll"
                Dim App32Path As String = Application.StartupPath & "\SMTP\Mailbee.dll"

                File.Copy(Application.StartupPath & "\SMTP\Mailbee64.dll", sSystem32Directory + "\System32\Mailbee64.dll", True)
                File.Copy(Application.StartupPath & "\SMTP\Mailbee.dll", sSystem32Directory + "\SysWow64\Mailbee.dll", True)
                Process.Start("Regsvr32.exe", sSystem32Directory + "\System32\Mailbee64.dll")
                Process.Start("Regsvr32.exe", sSystem32Directory + "\SysWow64\Mailbee.dll")

            Else

                Dim InstalledPath As String = sSystem32Directory + "\System32\Mailbee.dll"
                Dim AppPath As String = Application.StartupPath & "\SMTP\Mailbee.dll"

                File.Copy(Application.StartupPath & "\SMTP\Mailbee.dll", sSystem32Directory + "\System32\Mailbee.dll", True)
                Process.Start("Regsvr32.exe", sSystem32Directory + "\System32\Mailbee.dll")

            End If

        Catch x As Exception
            DebugPrint(x.Message.ToString())
            'MsgBox("SMTP component is already present.")
        End Try

    End Sub
    Private Sub GetSmtpVersionInfo()

        Try

            Dim sSystem32Directory As String = System.Environment.ExpandEnvironmentVariables("%SystemRoot%")

            If is64Bit() = True Then

                Dim Installed64Path As String = sSystem32Directory + "\System32\Mailbee64.dll"
                Dim App64Path As String = Application.StartupPath & "\SMTP\Mailbee64.dll"

                Dim Installed32Path As String = sSystem32Directory + "\SysWow64\Mailbee.dll"
                Dim App32Path As String = Application.StartupPath & "\SMTP\Mailbee.dll"

                LabelInstalledVersion1.Text = "Installed version (64-bit):  " & GetVersion(Installed64Path)
                LabelLatestVersion1.Text = "Latest version (64-bit):  " & GetVersion(App64Path)

                LabelInstalledVersion2.Text = "Installed version (32-bit):  " & GetVersion(Installed32Path)
                LabelLatestVersion2.Text = "Latest version (32-bit):  " & GetVersion(App32Path)

            Else

                Dim InstalledPath As String = sSystem32Directory + "\System32\Mailbee.dll"
                Dim AppPath As String = Application.StartupPath & "\SMTP\Mailbee.dll"

                LabelInstalledVersion1.Text = "Installed version:  " & GetVersion(InstalledPath)
                LabelLatestVersion1.Text = "Latest version:  " & GetVersion(AppPath)

                LabelInstalledVersion2.Visible = False
                LabelLatestVersion2.Visible = False

            End If

        Catch x As Exception
            DebugPrint(x.Message.ToString())
            'MsgBox("SMTP component is already present.")
        End Try

    End Sub
    Private Function GetVersion(ByVal filename As String) As String

        'Return Version.Parse(FileVersionInfo.GetVersionInfo(filename).FileVersion).ToString()
        Return FileVersionInfo.GetVersionInfo(filename).FileVersion.Replace(",", ".").Replace(" ", "")

    End Function
    Private Sub ButtonDeleteTempFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDeleteTempFiles.Click
        Me.STOPIIS()
        Dim WindowsPath As String = Environment.GetEnvironmentVariable("SystemRoot")
        Dim ThirtyTwoBitPath As String = "\Microsoft.NET\Framework\v4.0.30319\Temporary ASP.NET Files\"
        Dim SixtyFourBitPath As String = "\Microsoft.NET\Framework64\v4.0.30319\Temporary ASP.NET Files\"
        Dim VirtualDirectoryName As String = Me.txtVirtualDirectory.Text
        Try
            Me.DeleteDirectory(WindowsPath & ThirtyTwoBitPath & VirtualDirectoryName)
        Catch ex As Exception
        End Try
        Try
            Me.DeleteDirectory(WindowsPath & SixtyFourBitPath & VirtualDirectoryName)
        Catch ex As Exception
        End Try
        Me.STARTIIS()
        MsgBox("Temporary folders and files deleted")
    End Sub
    Private Sub ButtonSetMachineConfig_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSetMachineConfig.Click
        Me.SetMachineConfig()
        Try
            Me.ButtonSetMachineConfig.Enabled = Me.MachineConfigNeedsUpdating()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ButtonCreateEventLog_Click(sender As Object, e As System.EventArgs) Handles ButtonCreateEventLog.Click
        Try
            System.Diagnostics.EventLog.CreateEventSource(_WebvantageEventSource, _WebvantageEventLogName)
            ButtonCreateEventLog.Enabled = False
        Catch ex As Exception
            MsgBox("Error creating Event Log:" & Environment.NewLine & ex.Message.ToString())
        End Try
    End Sub
    Private Sub ButtonAddFavicon_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAddFavicon.Click

    End Sub
    Private Sub tabWebServices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabWebServices.Click

    End Sub

#End Region
#Region " Form "

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()
        bnLoad = True
        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Me.txtPhysicalPath.Text = Application.StartupPath
        Dim strConnstring As String = ""
        Dim oApplication As cApplication = New cApplication(strConnstring)

        Dim num_files As Integer
        Dim files() As String
        Dim file_name As String

        Dim strDirectory = Application.StartupPath & "\Scripts\"

        Me.Text = g_PageTitle

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

        'set default.
        Me.chkVirtualDirectory.Checked = True
        Me.txtVirtualDirectory.Text = ""
        Me.txtVirtualDirectory.Enabled = True

        'get the Sql Server install path
        Dim regKey As RegistryKey
        Dim regSubKey1 As RegistryKey
        Dim regSubKey2 As RegistryKey
        Dim regSubKey3 As RegistryKey
        Dim regSubKey4 As RegistryKey
        Dim regSubKey5 As RegistryKey

        '''Try
        '''    regKey = Registry.LocalMachine

        '''    regSubKey1 = regKey.CreateSubKey("SOFTWARE")
        '''    regSubKey2 = regSubKey1.CreateSubKey("Microsoft")
        '''    regSubKey3 = regSubKey2.CreateSubKey("Microsoft SQL Server")
        '''    regSubKey4 = regSubKey3.CreateSubKey("80")
        '''    regSubKey5 = regSubKey4.CreateSubKey("Reporting Services")
        '''    Dim strreportconfig As String = (regSubKey5.GetValue("RSConfigFilePath")) 'Server Config File
        '''    Dim r As Integer = strreportconfig.IndexOf("\ReportServer")
        '''    'Me.txtMSSQLServer.Text = strreportconfig.Substring(0, r)
        '''Catch ex As Exception
        '''    MsgBox("Error:  Report Services is not installed on this server.")
        '''End Try

        'get the web.config settings

        Me.chkVirtualDirectory.Checked = True
        Me.txtVirtualDirectory.Text = "webvantage"
        Me.txtVirtualDirectory.Enabled = True

        bnLoad = False
        Me.btnSetupVirtDir.Enabled = True

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
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnHelp As System.Windows.Forms.Button
    Friend WithEvents tbDatabase As System.Windows.Forms.TabPage
    Friend WithEvents grpDatabase As System.Windows.Forms.GroupBox
    Friend WithEvents cboDatabaseScript As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnRun As System.Windows.Forms.Button
    Friend WithEvents btnTestConnection As System.Windows.Forms.Button
    Friend WithEvents lblDatabaseVersion As System.Windows.Forms.Label
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
    Friend WithEvents tcWebvantageConfig As System.Windows.Forms.TabControl
    Friend WithEvents grpApplicationAuthentication As System.Windows.Forms.GroupBox
    Friend WithEvents rbNTAuthentication As System.Windows.Forms.RadioButton
    Friend WithEvents rbSqlAuthentication As System.Windows.Forms.RadioButton
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents dlgFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtwebconfig As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents grpCreateWebVirtDir As System.Windows.Forms.GroupBox
    Friend WithEvents btnLoadWebsites As System.Windows.Forms.Button
    Friend WithEvents drpIISWebsite As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtIISServer As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnSetupVirtDir As System.Windows.Forms.Button
    Friend WithEvents gpGeneralSettings As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtemailpassword As System.Windows.Forms.TextBox
    Friend WithEvents txtEmailUserName As System.Windows.Forms.TextBox
    Friend WithEvents txtEmailFromAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtSMTPAddress As System.Windows.Forms.TextBox
    Friend WithEvents btnChangeSMTPSettings As System.Windows.Forms.Button
    Friend WithEvents chkUpperCaseUser As System.Windows.Forms.CheckBox
    Friend WithEvents chkChooseServer As System.Windows.Forms.CheckBox
    Friend WithEvents chkSQLControledAdmin As System.Windows.Forms.CheckBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtwebconfig1 As System.Windows.Forms.TextBox
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents tbApp As System.Windows.Forms.TabPage
    Friend WithEvents tbIIS As System.Windows.Forms.TabPage
    Friend WithEvents gbWVVirtualDir As System.Windows.Forms.GroupBox
    Friend WithEvents chkVirtualDirectory As System.Windows.Forms.CheckBox
    Friend WithEvents txtPhysicalPath As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtVirtualDirectory As System.Windows.Forms.TextBox
    Friend WithEvents lblWebconfig As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmWebConfig))
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Home")
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.tbApp = New System.Windows.Forms.TabPage()
        Me.ButtonProofingEventLog = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtwebconfig1 = New System.Windows.Forms.TextBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.gpGeneralSettings = New System.Windows.Forms.GroupBox()
        Me.CheckBoxRequireSSL = New System.Windows.Forms.CheckBox()
        Me.ButtonAddFavicon = New System.Windows.Forms.Button()
        Me.ButtonCreateEventLog = New System.Windows.Forms.Button()
        Me.cboCustomErrors = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TxtTimeOutMinutes = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.chkUpperCaseDatabase = New System.Windows.Forms.CheckBox()
        Me.chkSQLControledAdmin = New System.Windows.Forms.CheckBox()
        Me.chkUpperCaseUser = New System.Windows.Forms.CheckBox()
        Me.chkChooseServer = New System.Windows.Forms.CheckBox()
        Me.btnChangeSMTPSettings = New System.Windows.Forms.Button()
        Me.grpApplicationAuthentication = New System.Windows.Forms.GroupBox()
        Me.Chk_NTAuth_UserCode_IgnoreCase = New System.Windows.Forms.CheckBox()
        Me.rbSqlAuthentication = New System.Windows.Forms.RadioButton()
        Me.rbNTAuthentication = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TxtAlertRefresh = New System.Windows.Forms.TextBox()
        Me.gbWebFarm = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TxtAdmDatabaseName = New System.Windows.Forms.TextBox()
        Me.ChkBxUseSysLogon = New System.Windows.Forms.CheckBox()
        Me.ChkBxIsOnWebFarm = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtretypeemailpassword = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtemailpassword = New System.Windows.Forms.TextBox()
        Me.txtEmailUserName = New System.Windows.Forms.TextBox()
        Me.txtEmailFromAddress = New System.Windows.Forms.TextBox()
        Me.txtSMTPAddress = New System.Windows.Forms.TextBox()
        Me.tbDatabase = New System.Windows.Forms.TabPage()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.grpDatabase = New System.Windows.Forms.GroupBox()
        Me.cboDatabaseScript = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnRun = New System.Windows.Forms.Button()
        Me.btnTestConnection = New System.Windows.Forms.Button()
        Me.lblDatabaseVersion = New System.Windows.Forms.Label()
        Me.txtDatabaseName = New System.Windows.Forms.TextBox()
        Me.lblDatabaseName = New System.Windows.Forms.Label()
        Me.grpAuthentication = New System.Windows.Forms.GroupBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rbSSA = New System.Windows.Forms.RadioButton()
        Me.rbWIA = New System.Windows.Forms.RadioButton()
        Me.lblconnectSQL = New System.Windows.Forms.Label()
        Me.grpDatabaseServer = New System.Windows.Forms.GroupBox()
        Me.txtSQLServerName = New System.Windows.Forms.TextBox()
        Me.lblSQLServerName = New System.Windows.Forms.Label()
        Me.tcWebvantageConfig = New System.Windows.Forms.TabControl()
        Me.tbIIS = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ButtonSetMachineConfig = New System.Windows.Forms.Button()
        Me.ButtonDeleteTempFiles = New System.Windows.Forms.Button()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.lblProgress = New System.Windows.Forms.Label()
        Me.PBarIIS = New System.Windows.Forms.ProgressBar()
        Me.gbWVVirtualDir = New System.Windows.Forms.GroupBox()
        Me.txtSessionTimeout = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.chkVirtualDirectory = New System.Windows.Forms.CheckBox()
        Me.txtPhysicalPath = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtVirtualDirectory = New System.Windows.Forms.TextBox()
        Me.lblWebconfig = New System.Windows.Forms.Label()
        Me.btnSetupVirtDir = New System.Windows.Forms.Button()
        Me.grpCreateWebVirtDir = New System.Windows.Forms.GroupBox()
        Me.btnLoadWebsites = New System.Windows.Forms.Button()
        Me.drpIISWebsite = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtIISServer = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TabPageConnection = New System.Windows.Forms.TabPage()
        Me.ButtonTest = New System.Windows.Forms.Button()
        Me.ButtonDelete = New System.Windows.Forms.Button()
        Me.ButtonConnectionSave = New System.Windows.Forms.Button()
        Me.TextBoxPassword = New System.Windows.Forms.TextBox()
        Me.LabelPassword = New System.Windows.Forms.Label()
        Me.TextBoxUserName = New System.Windows.Forms.TextBox()
        Me.LabelUserName = New System.Windows.Forms.Label()
        Me.ButtonAddDatabase = New System.Windows.Forms.Button()
        Me.ButtonAddServer = New System.Windows.Forms.Button()
        Me.TreeViewConnections = New System.Windows.Forms.TreeView()
        Me.TreeViewImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.TabSMTP = New System.Windows.Forms.TabPage()
        Me.LabelLatestVersion2 = New System.Windows.Forms.Label()
        Me.LabelLatestVersion1 = New System.Windows.Forms.Label()
        Me.LabelInstalledVersion2 = New System.Windows.Forms.Label()
        Me.LabelInstalledVersion1 = New System.Windows.Forms.Label()
        Me.btnSmtpInstall = New System.Windows.Forms.Button()
        Me.tbRegistry = New System.Windows.Forms.TabPage()
        Me.lblRegistryWarn = New System.Windows.Forms.Label()
        Me.gbRegistry = New System.Windows.Forms.GroupBox()
        Me.txtRegistryDatabase = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtRegistryServer = New System.Windows.Forms.TextBox()
        Me.btnDeleteReg = New System.Windows.Forms.Button()
        Me.btnAddReg = New System.Windows.Forms.Button()
        Me.btnSaveRegistry = New System.Windows.Forms.Button()
        Me.txtClientPortalPassword = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtClientPortalUsername = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtAdminPassword = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtAdminUsername = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.tvRegistry = New System.Windows.Forms.TreeView()
        Me.tabWebServices = New System.Windows.Forms.TabPage()
        Me.lblWarning = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.btnCreate = New System.Windows.Forms.Button()
        Me.txtURL = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.BtnDeleteCache = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.dlgFile = New System.Windows.Forms.OpenFileDialog()
        Me.epEmailPassword = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.epSMTPAddress = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.epEmailAddress = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.txtConfigReportingServices = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtAdmPassword = New System.Windows.Forms.TextBox()
        Me.TxtAdmUserName = New System.Windows.Forms.TextBox()
        Me.TxtAdmServerName = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBoxChatDB = New System.Windows.Forms.GroupBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.TextBoxChatPassword = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.TextBoxChatUsername = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.TextBoxChatDatabaseName = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.TextBoxChatServerName = New System.Windows.Forms.TextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.tbApp.SuspendLayout()
        Me.gpGeneralSettings.SuspendLayout()
        Me.grpApplicationAuthentication.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gbWebFarm.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.tbDatabase.SuspendLayout()
        Me.grpDatabase.SuspendLayout()
        Me.grpAuthentication.SuspendLayout()
        Me.grpDatabaseServer.SuspendLayout()
        Me.tcWebvantageConfig.SuspendLayout()
        Me.tbIIS.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.gbWVVirtualDir.SuspendLayout()
        Me.grpCreateWebVirtDir.SuspendLayout()
        Me.TabPageConnection.SuspendLayout()
        Me.TabSMTP.SuspendLayout()
        Me.tbRegistry.SuspendLayout()
        Me.gbRegistry.SuspendLayout()
        Me.tabWebServices.SuspendLayout()
        CType(Me.epEmailPassword, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.epSMTPAddress, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.epEmailAddress, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBoxChatDB.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(612, 479)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(134, 23)
        Me.btnExit.TabIndex = 1
        Me.btnExit.Text = "E&xit"
        '
        'btnHelp
        '
        Me.btnHelp.Location = New System.Drawing.Point(250, 572)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(75, 23)
        Me.btnHelp.TabIndex = 3
        Me.btnHelp.Text = "Help"
        '
        'tbApp
        '
        Me.tbApp.Controls.Add(Me.Button2)
        Me.tbApp.Controls.Add(Me.ButtonProofingEventLog)
        Me.tbApp.Controls.Add(Me.Label13)
        Me.tbApp.Controls.Add(Me.txtwebconfig1)
        Me.tbApp.Controls.Add(Me.btnBrowse)
        Me.tbApp.Controls.Add(Me.gpGeneralSettings)
        Me.tbApp.Controls.Add(Me.btnChangeSMTPSettings)
        Me.tbApp.Controls.Add(Me.grpApplicationAuthentication)
        Me.tbApp.Location = New System.Drawing.Point(4, 22)
        Me.tbApp.Name = "tbApp"
        Me.tbApp.Size = New System.Drawing.Size(743, 445)
        Me.tbApp.TabIndex = 0
        Me.tbApp.Text = "Application"
        Me.tbApp.UseVisualStyleBackColor = True
        '
        'ButtonProofingEventLog
        '
        Me.ButtonProofingEventLog.Location = New System.Drawing.Point(400, 239)
        Me.ButtonProofingEventLog.Name = "ButtonProofingEventLog"
        Me.ButtonProofingEventLog.Size = New System.Drawing.Size(171, 23)
        Me.ButtonProofingEventLog.TabIndex = 13
        Me.ButtonProofingEventLog.Text = "Create Proofing Event Log"
        Me.ButtonProofingEventLog.Visible = False
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(16, 8)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(256, 16)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "Location of the Webvantage web.config file:"
        '
        'txtwebconfig1
        '
        Me.txtwebconfig1.Location = New System.Drawing.Point(16, 24)
        Me.txtwebconfig1.Name = "txtwebconfig1"
        Me.txtwebconfig1.Size = New System.Drawing.Size(642, 20)
        Me.txtwebconfig1.TabIndex = 10
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(664, 21)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowse.TabIndex = 11
        Me.btnBrowse.Text = "Browse"
        '
        'gpGeneralSettings
        '
        Me.gpGeneralSettings.Controls.Add(Me.CheckBoxRequireSSL)
        Me.gpGeneralSettings.Controls.Add(Me.ButtonAddFavicon)
        Me.gpGeneralSettings.Controls.Add(Me.ButtonCreateEventLog)
        Me.gpGeneralSettings.Controls.Add(Me.cboCustomErrors)
        Me.gpGeneralSettings.Controls.Add(Me.Label22)
        Me.gpGeneralSettings.Controls.Add(Me.TxtTimeOutMinutes)
        Me.gpGeneralSettings.Controls.Add(Me.Label18)
        Me.gpGeneralSettings.Controls.Add(Me.chkUpperCaseDatabase)
        Me.gpGeneralSettings.Controls.Add(Me.chkSQLControledAdmin)
        Me.gpGeneralSettings.Controls.Add(Me.chkUpperCaseUser)
        Me.gpGeneralSettings.Controls.Add(Me.chkChooseServer)
        Me.gpGeneralSettings.Location = New System.Drawing.Point(8, 50)
        Me.gpGeneralSettings.Name = "gpGeneralSettings"
        Me.gpGeneralSettings.Size = New System.Drawing.Size(376, 222)
        Me.gpGeneralSettings.TabIndex = 3
        Me.gpGeneralSettings.TabStop = False
        Me.gpGeneralSettings.Text = "General Application Settings"
        '
        'CheckBoxRequireSSL
        '
        Me.CheckBoxRequireSSL.BackColor = System.Drawing.Color.Transparent
        Me.CheckBoxRequireSSL.Location = New System.Drawing.Point(8, 95)
        Me.CheckBoxRequireSSL.Name = "CheckBoxRequireSSL"
        Me.CheckBoxRequireSSL.Size = New System.Drawing.Size(368, 24)
        Me.CheckBoxRequireSSL.TabIndex = 12
        Me.CheckBoxRequireSSL.Text = "Require SSL/HTTPS"
        Me.CheckBoxRequireSSL.UseVisualStyleBackColor = False
        '
        'ButtonAddFavicon
        '
        Me.ButtonAddFavicon.Location = New System.Drawing.Point(192, 189)
        Me.ButtonAddFavicon.Name = "ButtonAddFavicon"
        Me.ButtonAddFavicon.Size = New System.Drawing.Size(171, 23)
        Me.ButtonAddFavicon.TabIndex = 11
        Me.ButtonAddFavicon.Text = "Add Default favicon"
        Me.ButtonAddFavicon.Visible = False
        '
        'ButtonCreateEventLog
        '
        Me.ButtonCreateEventLog.Location = New System.Drawing.Point(11, 189)
        Me.ButtonCreateEventLog.Name = "ButtonCreateEventLog"
        Me.ButtonCreateEventLog.Size = New System.Drawing.Size(171, 23)
        Me.ButtonCreateEventLog.TabIndex = 10
        Me.ButtonCreateEventLog.Text = "Create Event Log"
        '
        'cboCustomErrors
        '
        Me.cboCustomErrors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCustomErrors.FormattingEnabled = True
        Me.cboCustomErrors.Items.AddRange(New Object() {"Off", "On", "RemoteOnly"})
        Me.cboCustomErrors.Location = New System.Drawing.Point(120, 162)
        Me.cboCustomErrors.MaxDropDownItems = 3
        Me.cboCustomErrors.Name = "cboCustomErrors"
        Me.cboCustomErrors.Size = New System.Drawing.Size(96, 21)
        Me.cboCustomErrors.TabIndex = 7
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(9, 167)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(105, 13)
        Me.Label22.TabIndex = 6
        Me.Label22.Text = "Custom Errors Mode:"
        '
        'TxtTimeOutMinutes
        '
        Me.TxtTimeOutMinutes.Location = New System.Drawing.Point(120, 132)
        Me.TxtTimeOutMinutes.Name = "TxtTimeOutMinutes"
        Me.TxtTimeOutMinutes.Size = New System.Drawing.Size(53, 20)
        Me.TxtTimeOutMinutes.TabIndex = 5
        Me.TxtTimeOutMinutes.Text = "120"
        Me.TxtTimeOutMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(18, 135)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(96, 13)
        Me.Label18.TabIndex = 4
        Me.Label18.Text = "Time out (minutes):"
        '
        'chkUpperCaseDatabase
        '
        Me.chkUpperCaseDatabase.BackColor = System.Drawing.Color.Transparent
        Me.chkUpperCaseDatabase.Location = New System.Drawing.Point(8, 35)
        Me.chkUpperCaseDatabase.Name = "chkUpperCaseDatabase"
        Me.chkUpperCaseDatabase.Size = New System.Drawing.Size(288, 24)
        Me.chkUpperCaseDatabase.TabIndex = 3
        Me.chkUpperCaseDatabase.Text = "Default Database name to always use upper case"
        Me.chkUpperCaseDatabase.UseVisualStyleBackColor = False
        '
        'chkSQLControledAdmin
        '
        Me.chkSQLControledAdmin.BackColor = System.Drawing.Color.Transparent
        Me.chkSQLControledAdmin.Location = New System.Drawing.Point(8, 54)
        Me.chkSQLControledAdmin.Name = "chkSQLControledAdmin"
        Me.chkSQLControledAdmin.Size = New System.Drawing.Size(288, 24)
        Me.chkSQLControledAdmin.TabIndex = 2
        Me.chkSQLControledAdmin.Text = "Allow Admin to be controlled from SQL Server"
        Me.chkSQLControledAdmin.UseVisualStyleBackColor = False
        '
        'chkUpperCaseUser
        '
        Me.chkUpperCaseUser.BackColor = System.Drawing.Color.Transparent
        Me.chkUpperCaseUser.Location = New System.Drawing.Point(8, 16)
        Me.chkUpperCaseUser.Name = "chkUpperCaseUser"
        Me.chkUpperCaseUser.Size = New System.Drawing.Size(288, 24)
        Me.chkUpperCaseUser.TabIndex = 0
        Me.chkUpperCaseUser.Text = "Default user ID to always use upper case"
        Me.chkUpperCaseUser.UseVisualStyleBackColor = False
        '
        'chkChooseServer
        '
        Me.chkChooseServer.BackColor = System.Drawing.Color.Transparent
        Me.chkChooseServer.Checked = True
        Me.chkChooseServer.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkChooseServer.Location = New System.Drawing.Point(8, 73)
        Me.chkChooseServer.Name = "chkChooseServer"
        Me.chkChooseServer.Size = New System.Drawing.Size(368, 24)
        Me.chkChooseServer.TabIndex = 1
        Me.chkChooseServer.Text = "Allow user to select server (if unchecked registry needs to be edited)"
        Me.chkChooseServer.UseVisualStyleBackColor = False
        '
        'btnChangeSMTPSettings
        '
        Me.btnChangeSMTPSettings.Location = New System.Drawing.Point(7, 373)
        Me.btnChangeSMTPSettings.Name = "btnChangeSMTPSettings"
        Me.btnChangeSMTPSettings.Size = New System.Drawing.Size(732, 60)
        Me.btnChangeSMTPSettings.TabIndex = 9
        Me.btnChangeSMTPSettings.Text = "Change Settings"
        '
        'grpApplicationAuthentication
        '
        Me.grpApplicationAuthentication.Controls.Add(Me.Chk_NTAuth_UserCode_IgnoreCase)
        Me.grpApplicationAuthentication.Controls.Add(Me.rbSqlAuthentication)
        Me.grpApplicationAuthentication.Controls.Add(Me.rbNTAuthentication)
        Me.grpApplicationAuthentication.Location = New System.Drawing.Point(8, 286)
        Me.grpApplicationAuthentication.Name = "grpApplicationAuthentication"
        Me.grpApplicationAuthentication.Size = New System.Drawing.Size(376, 68)
        Me.grpApplicationAuthentication.TabIndex = 2
        Me.grpApplicationAuthentication.TabStop = False
        Me.grpApplicationAuthentication.Text = "Application Authentication"
        '
        'Chk_NTAuth_UserCode_IgnoreCase
        '
        Me.Chk_NTAuth_UserCode_IgnoreCase.BackColor = System.Drawing.Color.Transparent
        Me.Chk_NTAuth_UserCode_IgnoreCase.Location = New System.Drawing.Point(168, 44)
        Me.Chk_NTAuth_UserCode_IgnoreCase.Name = "Chk_NTAuth_UserCode_IgnoreCase"
        Me.Chk_NTAuth_UserCode_IgnoreCase.Size = New System.Drawing.Size(195, 24)
        Me.Chk_NTAuth_UserCode_IgnoreCase.TabIndex = 2
        Me.Chk_NTAuth_UserCode_IgnoreCase.Text = "Ignore case for User Code"
        Me.Chk_NTAuth_UserCode_IgnoreCase.UseVisualStyleBackColor = False
        '
        'rbSqlAuthentication
        '
        Me.rbSqlAuthentication.BackColor = System.Drawing.Color.Transparent
        Me.rbSqlAuthentication.Checked = True
        Me.rbSqlAuthentication.Location = New System.Drawing.Point(16, 16)
        Me.rbSqlAuthentication.Name = "rbSqlAuthentication"
        Me.rbSqlAuthentication.Size = New System.Drawing.Size(136, 24)
        Me.rbSqlAuthentication.TabIndex = 1
        Me.rbSqlAuthentication.TabStop = True
        Me.rbSqlAuthentication.Text = "SQL Authentication"
        Me.rbSqlAuthentication.UseVisualStyleBackColor = False
        '
        'rbNTAuthentication
        '
        Me.rbNTAuthentication.BackColor = System.Drawing.Color.Transparent
        Me.rbNTAuthentication.Location = New System.Drawing.Point(168, 16)
        Me.rbNTAuthentication.Name = "rbNTAuthentication"
        Me.rbNTAuthentication.Size = New System.Drawing.Size(136, 24)
        Me.rbNTAuthentication.TabIndex = 0
        Me.rbNTAuthentication.Text = "NT Authentication"
        Me.rbNTAuthentication.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.TxtAlertRefresh)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 733)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(376, 64)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Alert Refresh Rate"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(13, 49)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(134, 13)
        Me.Label21.TabIndex = 9
        Me.Label21.Text = " Minimum 3 minute interval."
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(13, 36)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(184, 13)
        Me.Label20.TabIndex = 8
        Me.Label20.Text = "*Leave blank or set to zero to disable."
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(13, 16)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(121, 13)
        Me.Label19.TabIndex = 7
        Me.Label19.Text = "Refresh every (minutes):"
        '
        'TxtAlertRefresh
        '
        Me.TxtAlertRefresh.Location = New System.Drawing.Point(140, 13)
        Me.TxtAlertRefresh.Name = "TxtAlertRefresh"
        Me.TxtAlertRefresh.Size = New System.Drawing.Size(53, 20)
        Me.TxtAlertRefresh.TabIndex = 6
        Me.TxtAlertRefresh.Text = "10"
        Me.TxtAlertRefresh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'gbWebFarm
        '
        Me.gbWebFarm.Controls.Add(Me.Label11)
        Me.gbWebFarm.Controls.Add(Me.TxtAdmDatabaseName)
        Me.gbWebFarm.Controls.Add(Me.ChkBxUseSysLogon)
        Me.gbWebFarm.Controls.Add(Me.ChkBxIsOnWebFarm)
        Me.gbWebFarm.Location = New System.Drawing.Point(462, 638)
        Me.gbWebFarm.Name = "gbWebFarm"
        Me.gbWebFarm.Size = New System.Drawing.Size(376, 113)
        Me.gbWebFarm.TabIndex = 13
        Me.gbWebFarm.TabStop = False
        Me.gbWebFarm.Text = "Web Farming / Clear Licenses"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 64)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(87, 13)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "Database Name:"
        '
        'TxtAdmDatabaseName
        '
        Me.TxtAdmDatabaseName.Location = New System.Drawing.Point(12, 81)
        Me.TxtAdmDatabaseName.Name = "TxtAdmDatabaseName"
        Me.TxtAdmDatabaseName.Size = New System.Drawing.Size(342, 20)
        Me.TxtAdmDatabaseName.TabIndex = 15
        '
        'ChkBxUseSysLogon
        '
        Me.ChkBxUseSysLogon.AutoSize = True
        Me.ChkBxUseSysLogon.Location = New System.Drawing.Point(15, 44)
        Me.ChkBxUseSysLogon.Name = "ChkBxUseSysLogon"
        Me.ChkBxUseSysLogon.Size = New System.Drawing.Size(313, 17)
        Me.ChkBxUseSysLogon.TabIndex = 1
        Me.ChkBxUseSysLogon.Text = "Require System Administrator Logon after Server/IIS Re-boot"
        Me.ChkBxUseSysLogon.UseVisualStyleBackColor = True
        '
        'ChkBxIsOnWebFarm
        '
        Me.ChkBxIsOnWebFarm.AutoSize = True
        Me.ChkBxIsOnWebFarm.Checked = True
        Me.ChkBxIsOnWebFarm.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkBxIsOnWebFarm.Location = New System.Drawing.Point(15, 20)
        Me.ChkBxIsOnWebFarm.Name = "ChkBxIsOnWebFarm"
        Me.ChkBxIsOnWebFarm.Size = New System.Drawing.Size(297, 17)
        Me.ChkBxIsOnWebFarm.TabIndex = 0
        Me.ChkBxIsOnWebFarm.Text = "Webvantage is on a Web Farm (Disable license clearing.)"
        Me.ChkBxIsOnWebFarm.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtretypeemailpassword)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtemailpassword)
        Me.GroupBox2.Controls.Add(Me.txtEmailUserName)
        Me.GroupBox2.Controls.Add(Me.txtEmailFromAddress)
        Me.GroupBox2.Controls.Add(Me.txtSMTPAddress)
        Me.GroupBox2.Location = New System.Drawing.Point(462, 757)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(376, 145)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "SMTP Settings"
        '
        'txtretypeemailpassword
        '
        Me.txtretypeemailpassword.Location = New System.Drawing.Point(120, 120)
        Me.txtretypeemailpassword.Name = "txtretypeemailpassword"
        Me.txtretypeemailpassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtretypeemailpassword.Size = New System.Drawing.Size(234, 20)
        Me.txtretypeemailpassword.TabIndex = 9
        Me.txtretypeemailpassword.Text = "password"
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(16, 120)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(100, 16)
        Me.Label16.TabIndex = 8
        Me.Label16.Text = "Re-type Password:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(16, 96)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 16)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Email Password:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(16, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 16)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Email User Name:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(0, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(115, 16)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Email From Address:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "SMTP Address:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtemailpassword
        '
        Me.txtemailpassword.Location = New System.Drawing.Point(120, 96)
        Me.txtemailpassword.Name = "txtemailpassword"
        Me.txtemailpassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtemailpassword.Size = New System.Drawing.Size(234, 20)
        Me.txtemailpassword.TabIndex = 5
        Me.txtemailpassword.Text = "password"
        '
        'txtEmailUserName
        '
        Me.txtEmailUserName.Location = New System.Drawing.Point(120, 72)
        Me.txtEmailUserName.Name = "txtEmailUserName"
        Me.txtEmailUserName.Size = New System.Drawing.Size(234, 20)
        Me.txtEmailUserName.TabIndex = 4
        Me.txtEmailUserName.Text = "jsmith"
        '
        'txtEmailFromAddress
        '
        Me.txtEmailFromAddress.Location = New System.Drawing.Point(120, 48)
        Me.txtEmailFromAddress.Name = "txtEmailFromAddress"
        Me.txtEmailFromAddress.Size = New System.Drawing.Size(234, 20)
        Me.txtEmailFromAddress.TabIndex = 3
        Me.txtEmailFromAddress.Text = "jsmith@yourcompany.com"
        '
        'txtSMTPAddress
        '
        Me.txtSMTPAddress.Location = New System.Drawing.Point(120, 24)
        Me.txtSMTPAddress.Name = "txtSMTPAddress"
        Me.txtSMTPAddress.Size = New System.Drawing.Size(234, 20)
        Me.txtSMTPAddress.TabIndex = 2
        Me.txtSMTPAddress.Text = "smtp.yourcompany.com"
        '
        'tbDatabase
        '
        Me.tbDatabase.Controls.Add(Me.Label14)
        Me.tbDatabase.Controls.Add(Me.grpDatabase)
        Me.tbDatabase.Controls.Add(Me.grpAuthentication)
        Me.tbDatabase.Controls.Add(Me.lblconnectSQL)
        Me.tbDatabase.Controls.Add(Me.grpDatabaseServer)
        Me.tbDatabase.Location = New System.Drawing.Point(4, 22)
        Me.tbDatabase.Name = "tbDatabase"
        Me.tbDatabase.Size = New System.Drawing.Size(743, 445)
        Me.tbDatabase.TabIndex = 1
        Me.tbDatabase.Text = "Database"
        Me.tbDatabase.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(8, 8)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(368, 16)
        Me.Label14.TabIndex = 4
        Me.Label14.Text = "*NOTE: This tab can only be executed from a machine with SQL Server."
        Me.Label14.Visible = False
        '
        'grpDatabase
        '
        Me.grpDatabase.Controls.Add(Me.cboDatabaseScript)
        Me.grpDatabase.Controls.Add(Me.Label8)
        Me.grpDatabase.Controls.Add(Me.btnRun)
        Me.grpDatabase.Controls.Add(Me.btnTestConnection)
        Me.grpDatabase.Controls.Add(Me.lblDatabaseVersion)
        Me.grpDatabase.Controls.Add(Me.txtDatabaseName)
        Me.grpDatabase.Controls.Add(Me.lblDatabaseName)
        Me.grpDatabase.Location = New System.Drawing.Point(8, 256)
        Me.grpDatabase.Name = "grpDatabase"
        Me.grpDatabase.Size = New System.Drawing.Size(719, 166)
        Me.grpDatabase.TabIndex = 3
        Me.grpDatabase.TabStop = False
        Me.grpDatabase.Text = "3. Connect to Existing Database"
        '
        'cboDatabaseScript
        '
        Me.cboDatabaseScript.ItemHeight = 13
        Me.cboDatabaseScript.Location = New System.Drawing.Point(144, 64)
        Me.cboDatabaseScript.Name = "cboDatabaseScript"
        Me.cboDatabaseScript.Size = New System.Drawing.Size(558, 21)
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
        'btnRun
        '
        Me.btnRun.Enabled = False
        Me.btnRun.Location = New System.Drawing.Point(627, 104)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(75, 36)
        Me.btnRun.TabIndex = 5
        Me.btnRun.Text = "Run"
        '
        'btnTestConnection
        '
        Me.btnTestConnection.Location = New System.Drawing.Point(509, 104)
        Me.btnTestConnection.Name = "btnTestConnection"
        Me.btnTestConnection.Size = New System.Drawing.Size(112, 36)
        Me.btnTestConnection.TabIndex = 4
        Me.btnTestConnection.Text = "Test Connection"
        '
        'lblDatabaseVersion
        '
        Me.lblDatabaseVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDatabaseVersion.Location = New System.Drawing.Point(11, 114)
        Me.lblDatabaseVersion.Name = "lblDatabaseVersion"
        Me.lblDatabaseVersion.Size = New System.Drawing.Size(259, 26)
        Me.lblDatabaseVersion.TabIndex = 3
        Me.lblDatabaseVersion.Text = "No Database Version"
        Me.lblDatabaseVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblDatabaseVersion.Visible = False
        '
        'txtDatabaseName
        '
        Me.txtDatabaseName.Location = New System.Drawing.Point(144, 32)
        Me.txtDatabaseName.Name = "txtDatabaseName"
        Me.txtDatabaseName.Size = New System.Drawing.Size(558, 20)
        Me.txtDatabaseName.TabIndex = 1
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
        'grpAuthentication
        '
        Me.grpAuthentication.Controls.Add(Me.txtPassword)
        Me.grpAuthentication.Controls.Add(Me.txtUserName)
        Me.grpAuthentication.Controls.Add(Me.Label3)
        Me.grpAuthentication.Controls.Add(Me.Label2)
        Me.grpAuthentication.Controls.Add(Me.rbSSA)
        Me.grpAuthentication.Controls.Add(Me.rbWIA)
        Me.grpAuthentication.Location = New System.Drawing.Point(8, 120)
        Me.grpAuthentication.Name = "grpAuthentication"
        Me.grpAuthentication.Size = New System.Drawing.Size(719, 128)
        Me.grpAuthentication.TabIndex = 2
        Me.grpAuthentication.TabStop = False
        Me.grpAuthentication.Text = "2. Select the Authentication Type"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(192, 104)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(510, 20)
        Me.txtPassword.TabIndex = 3
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(192, 80)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(510, 20)
        Me.txtUserName.TabIndex = 2
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
        Me.rbWIA.Location = New System.Drawing.Point(40, 24)
        Me.rbWIA.Name = "rbWIA"
        Me.rbWIA.Size = New System.Drawing.Size(272, 24)
        Me.rbWIA.TabIndex = 0
        Me.rbWIA.Text = "Use Windows Integrated Authentication"
        '
        'lblconnectSQL
        '
        Me.lblconnectSQL.Location = New System.Drawing.Point(16, 32)
        Me.lblconnectSQL.Name = "lblconnectSQL"
        Me.lblconnectSQL.Size = New System.Drawing.Size(176, 16)
        Me.lblconnectSQL.TabIndex = 1
        Me.lblconnectSQL.Text = "Connect directly to a SQL Server."
        '
        'grpDatabaseServer
        '
        Me.grpDatabaseServer.Controls.Add(Me.txtSQLServerName)
        Me.grpDatabaseServer.Controls.Add(Me.lblSQLServerName)
        Me.grpDatabaseServer.Location = New System.Drawing.Point(8, 56)
        Me.grpDatabaseServer.Name = "grpDatabaseServer"
        Me.grpDatabaseServer.Size = New System.Drawing.Size(719, 56)
        Me.grpDatabaseServer.TabIndex = 0
        Me.grpDatabaseServer.TabStop = False
        Me.grpDatabaseServer.Text = "1. Select the Database Server"
        '
        'txtSQLServerName
        '
        Me.txtSQLServerName.Location = New System.Drawing.Point(144, 24)
        Me.txtSQLServerName.Name = "txtSQLServerName"
        Me.txtSQLServerName.Size = New System.Drawing.Size(558, 20)
        Me.txtSQLServerName.TabIndex = 1
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
        'tcWebvantageConfig
        '
        Me.tcWebvantageConfig.Controls.Add(Me.tbIIS)
        Me.tcWebvantageConfig.Controls.Add(Me.tbApp)
        Me.tcWebvantageConfig.Controls.Add(Me.TabPageConnection)
        Me.tcWebvantageConfig.Controls.Add(Me.TabSMTP)
        Me.tcWebvantageConfig.ImageList = Me.TreeViewImageList
        Me.tcWebvantageConfig.ItemSize = New System.Drawing.Size(49, 18)
        Me.tcWebvantageConfig.Location = New System.Drawing.Point(3, 2)
        Me.tcWebvantageConfig.Name = "tcWebvantageConfig"
        Me.tcWebvantageConfig.SelectedIndex = 0
        Me.tcWebvantageConfig.Size = New System.Drawing.Size(751, 471)
        Me.tcWebvantageConfig.TabIndex = 0
        '
        'tbIIS
        '
        Me.tbIIS.Controls.Add(Me.GroupBox3)
        Me.tbIIS.Controls.Add(Me.lblProgress)
        Me.tbIIS.Controls.Add(Me.PBarIIS)
        Me.tbIIS.Controls.Add(Me.gbWVVirtualDir)
        Me.tbIIS.Controls.Add(Me.btnSetupVirtDir)
        Me.tbIIS.Controls.Add(Me.grpCreateWebVirtDir)
        Me.tbIIS.Location = New System.Drawing.Point(4, 22)
        Me.tbIIS.Name = "tbIIS"
        Me.tbIIS.Size = New System.Drawing.Size(743, 445)
        Me.tbIIS.TabIndex = 4
        Me.tbIIS.Text = "IIS"
        Me.tbIIS.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ButtonSetMachineConfig)
        Me.GroupBox3.Controls.Add(Me.ButtonDeleteTempFiles)
        Me.GroupBox3.Controls.Add(Me.Label34)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 356)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(717, 80)
        Me.GroupBox3.TabIndex = 14
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Tools"
        '
        'ButtonSetMachineConfig
        '
        Me.ButtonSetMachineConfig.Location = New System.Drawing.Point(376, 16)
        Me.ButtonSetMachineConfig.Name = "ButtonSetMachineConfig"
        Me.ButtonSetMachineConfig.Size = New System.Drawing.Size(304, 34)
        Me.ButtonSetMachineConfig.TabIndex = 13
        Me.ButtonSetMachineConfig.Text = "Set machine.config *"
        Me.ButtonSetMachineConfig.UseVisualStyleBackColor = True
        '
        'ButtonDeleteTempFiles
        '
        Me.ButtonDeleteTempFiles.Location = New System.Drawing.Point(27, 16)
        Me.ButtonDeleteTempFiles.Name = "ButtonDeleteTempFiles"
        Me.ButtonDeleteTempFiles.Size = New System.Drawing.Size(304, 34)
        Me.ButtonDeleteTempFiles.TabIndex = 11
        Me.ButtonDeleteTempFiles.Text = "Delete Temp Files *"
        Me.ButtonDeleteTempFiles.UseVisualStyleBackColor = True
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(9, 53)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(168, 13)
        Me.Label34.TabIndex = 12
        Me.Label34.Text = "* IIS will be stopped and restarted!"
        '
        'lblProgress
        '
        Me.lblProgress.AutoSize = True
        Me.lblProgress.Location = New System.Drawing.Point(8, 299)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(51, 13)
        Me.lblProgress.TabIndex = 10
        Me.lblProgress.Text = "Progress:"
        '
        'PBarIIS
        '
        Me.PBarIIS.Location = New System.Drawing.Point(8, 318)
        Me.PBarIIS.Name = "PBarIIS"
        Me.PBarIIS.Size = New System.Drawing.Size(591, 23)
        Me.PBarIIS.TabIndex = 9
        '
        'gbWVVirtualDir
        '
        Me.gbWVVirtualDir.Controls.Add(Me.txtSessionTimeout)
        Me.gbWVVirtualDir.Controls.Add(Me.Label23)
        Me.gbWVVirtualDir.Controls.Add(Me.chkVirtualDirectory)
        Me.gbWVVirtualDir.Controls.Add(Me.txtPhysicalPath)
        Me.gbWVVirtualDir.Controls.Add(Me.Label9)
        Me.gbWVVirtualDir.Controls.Add(Me.txtVirtualDirectory)
        Me.gbWVVirtualDir.Controls.Add(Me.lblWebconfig)
        Me.gbWVVirtualDir.Location = New System.Drawing.Point(8, 124)
        Me.gbWVVirtualDir.Name = "gbWVVirtualDir"
        Me.gbWVVirtualDir.Size = New System.Drawing.Size(723, 170)
        Me.gbWVVirtualDir.TabIndex = 8
        Me.gbWVVirtualDir.TabStop = False
        Me.gbWVVirtualDir.Text = "Webvantage Virtual Directory"
        '
        'txtSessionTimeout
        '
        Me.txtSessionTimeout.Location = New System.Drawing.Point(123, 128)
        Me.txtSessionTimeout.Name = "txtSessionTimeout"
        Me.txtSessionTimeout.Size = New System.Drawing.Size(53, 20)
        Me.txtSessionTimeout.TabIndex = 18
        Me.txtSessionTimeout.Text = "120"
        Me.txtSessionTimeout.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(21, 131)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(96, 13)
        Me.Label23.TabIndex = 17
        Me.Label23.Text = "Time out (minutes):"
        '
        'chkVirtualDirectory
        '
        Me.chkVirtualDirectory.Location = New System.Drawing.Point(30, 17)
        Me.chkVirtualDirectory.Name = "chkVirtualDirectory"
        Me.chkVirtualDirectory.Size = New System.Drawing.Size(280, 24)
        Me.chkVirtualDirectory.TabIndex = 16
        Me.chkVirtualDirectory.Text = "Create Webvantage Virtual Directory"
        '
        'txtPhysicalPath
        '
        Me.txtPhysicalPath.Location = New System.Drawing.Point(26, 58)
        Me.txtPhysicalPath.Name = "txtPhysicalPath"
        Me.txtPhysicalPath.Size = New System.Drawing.Size(565, 20)
        Me.txtPhysicalPath.TabIndex = 15
        Me.txtPhysicalPath.Text = "C:\Inetpub\wwwroot\webvantage"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(26, 42)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(232, 16)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Copy files to:"
        '
        'txtVirtualDirectory
        '
        Me.txtVirtualDirectory.Location = New System.Drawing.Point(26, 98)
        Me.txtVirtualDirectory.Name = "txtVirtualDirectory"
        Me.txtVirtualDirectory.Size = New System.Drawing.Size(565, 20)
        Me.txtVirtualDirectory.TabIndex = 13
        Me.txtVirtualDirectory.Text = "webvantage"
        '
        'lblWebconfig
        '
        Me.lblWebconfig.Location = New System.Drawing.Point(26, 82)
        Me.lblWebconfig.Name = "lblWebconfig"
        Me.lblWebconfig.Size = New System.Drawing.Size(232, 16)
        Me.lblWebconfig.TabIndex = 12
        Me.lblWebconfig.Text = "Virtual Directory:"
        '
        'btnSetupVirtDir
        '
        Me.btnSetupVirtDir.Location = New System.Drawing.Point(605, 309)
        Me.btnSetupVirtDir.Name = "btnSetupVirtDir"
        Me.btnSetupVirtDir.Size = New System.Drawing.Size(120, 41)
        Me.btnSetupVirtDir.TabIndex = 7
        Me.btnSetupVirtDir.Text = "Setup"
        '
        'grpCreateWebVirtDir
        '
        Me.grpCreateWebVirtDir.Controls.Add(Me.btnLoadWebsites)
        Me.grpCreateWebVirtDir.Controls.Add(Me.drpIISWebsite)
        Me.grpCreateWebVirtDir.Controls.Add(Me.Label12)
        Me.grpCreateWebVirtDir.Controls.Add(Me.txtIISServer)
        Me.grpCreateWebVirtDir.Controls.Add(Me.Label10)
        Me.grpCreateWebVirtDir.Location = New System.Drawing.Point(8, 8)
        Me.grpCreateWebVirtDir.Name = "grpCreateWebVirtDir"
        Me.grpCreateWebVirtDir.Size = New System.Drawing.Size(723, 110)
        Me.grpCreateWebVirtDir.TabIndex = 2
        Me.grpCreateWebVirtDir.TabStop = False
        Me.grpCreateWebVirtDir.Text = "IIS WebSites"
        '
        'btnLoadWebsites
        '
        Me.btnLoadWebsites.Location = New System.Drawing.Point(597, 36)
        Me.btnLoadWebsites.Name = "btnLoadWebsites"
        Me.btnLoadWebsites.Size = New System.Drawing.Size(120, 23)
        Me.btnLoadWebsites.TabIndex = 10
        Me.btnLoadWebsites.Text = "Load Web Sites"
        '
        'drpIISWebsite
        '
        Me.drpIISWebsite.Location = New System.Drawing.Point(24, 81)
        Me.drpIISWebsite.Name = "drpIISWebsite"
        Me.drpIISWebsite.Size = New System.Drawing.Size(567, 21)
        Me.drpIISWebsite.TabIndex = 9
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(24, 62)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(232, 16)
        Me.Label12.TabIndex = 8
        Me.Label12.Text = "IIS Web Site:"
        '
        'txtIISServer
        '
        Me.txtIISServer.Location = New System.Drawing.Point(24, 39)
        Me.txtIISServer.Name = "txtIISServer"
        Me.txtIISServer.Size = New System.Drawing.Size(567, 20)
        Me.txtIISServer.TabIndex = 1
        Me.txtIISServer.Text = "localhost"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(24, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(232, 16)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "IIS Server IP Address or Server Name:"
        '
        'TabPageConnection
        '
        Me.TabPageConnection.Controls.Add(Me.ButtonTest)
        Me.TabPageConnection.Controls.Add(Me.ButtonDelete)
        Me.TabPageConnection.Controls.Add(Me.ButtonConnectionSave)
        Me.TabPageConnection.Controls.Add(Me.TextBoxPassword)
        Me.TabPageConnection.Controls.Add(Me.LabelPassword)
        Me.TabPageConnection.Controls.Add(Me.TextBoxUserName)
        Me.TabPageConnection.Controls.Add(Me.LabelUserName)
        Me.TabPageConnection.Controls.Add(Me.ButtonAddDatabase)
        Me.TabPageConnection.Controls.Add(Me.ButtonAddServer)
        Me.TabPageConnection.Controls.Add(Me.TreeViewConnections)
        Me.TabPageConnection.Location = New System.Drawing.Point(4, 22)
        Me.TabPageConnection.Name = "TabPageConnection"
        Me.TabPageConnection.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageConnection.Size = New System.Drawing.Size(743, 445)
        Me.TabPageConnection.TabIndex = 8
        Me.TabPageConnection.Text = "Connection"
        Me.TabPageConnection.UseVisualStyleBackColor = True
        '
        'ButtonTest
        '
        Me.ButtonTest.Location = New System.Drawing.Point(386, 288)
        Me.ButtonTest.Name = "ButtonTest"
        Me.ButtonTest.Size = New System.Drawing.Size(350, 35)
        Me.ButtonTest.TabIndex = 9
        Me.ButtonTest.Text = "Test"
        '
        'ButtonDelete
        '
        Me.ButtonDelete.Location = New System.Drawing.Point(591, 8)
        Me.ButtonDelete.Name = "ButtonDelete"
        Me.ButtonDelete.Size = New System.Drawing.Size(145, 23)
        Me.ButtonDelete.TabIndex = 2
        Me.ButtonDelete.Text = "Delete"
        '
        'ButtonConnectionSave
        '
        Me.ButtonConnectionSave.Location = New System.Drawing.Point(8, 288)
        Me.ButtonConnectionSave.Name = "ButtonConnectionSave"
        Me.ButtonConnectionSave.Size = New System.Drawing.Size(372, 35)
        Me.ButtonConnectionSave.TabIndex = 8
        Me.ButtonConnectionSave.Text = "Save"
        '
        'TextBoxPassword
        '
        Me.TextBoxPassword.Enabled = False
        Me.TextBoxPassword.Location = New System.Drawing.Point(8, 262)
        Me.TextBoxPassword.Name = "TextBoxPassword"
        Me.TextBoxPassword.Size = New System.Drawing.Size(372, 20)
        Me.TextBoxPassword.TabIndex = 7
        Me.TextBoxPassword.UseSystemPasswordChar = True
        '
        'LabelPassword
        '
        Me.LabelPassword.Location = New System.Drawing.Point(8, 246)
        Me.LabelPassword.Name = "LabelPassword"
        Me.LabelPassword.Size = New System.Drawing.Size(115, 13)
        Me.LabelPassword.TabIndex = 6
        Me.LabelPassword.Text = "Password:"
        '
        'TextBoxUserName
        '
        Me.TextBoxUserName.Enabled = False
        Me.TextBoxUserName.Location = New System.Drawing.Point(8, 223)
        Me.TextBoxUserName.Name = "TextBoxUserName"
        Me.TextBoxUserName.Size = New System.Drawing.Size(372, 20)
        Me.TextBoxUserName.TabIndex = 5
        '
        'LabelUserName
        '
        Me.LabelUserName.Location = New System.Drawing.Point(8, 207)
        Me.LabelUserName.Name = "LabelUserName"
        Me.LabelUserName.Size = New System.Drawing.Size(117, 13)
        Me.LabelUserName.TabIndex = 4
        Me.LabelUserName.Text = "User Name:"
        '
        'ButtonAddDatabase
        '
        Me.ButtonAddDatabase.Location = New System.Drawing.Point(159, 8)
        Me.ButtonAddDatabase.Name = "ButtonAddDatabase"
        Me.ButtonAddDatabase.Size = New System.Drawing.Size(145, 23)
        Me.ButtonAddDatabase.TabIndex = 1
        Me.ButtonAddDatabase.Text = "Add Database"
        '
        'ButtonAddServer
        '
        Me.ButtonAddServer.Location = New System.Drawing.Point(8, 8)
        Me.ButtonAddServer.Name = "ButtonAddServer"
        Me.ButtonAddServer.Size = New System.Drawing.Size(145, 23)
        Me.ButtonAddServer.TabIndex = 0
        Me.ButtonAddServer.Text = "Add Server"
        '
        'TreeViewConnections
        '
        Me.TreeViewConnections.FullRowSelect = True
        Me.TreeViewConnections.HideSelection = False
        Me.TreeViewConnections.HotTracking = True
        Me.TreeViewConnections.ImageIndex = 0
        Me.TreeViewConnections.ImageList = Me.TreeViewImageList
        Me.TreeViewConnections.Location = New System.Drawing.Point(8, 37)
        Me.TreeViewConnections.Name = "TreeViewConnections"
        Me.TreeViewConnections.SelectedImageIndex = 3
        Me.TreeViewConnections.Size = New System.Drawing.Size(728, 167)
        Me.TreeViewConnections.TabIndex = 3
        '
        'TreeViewImageList
        '
        Me.TreeViewImageList.ImageStream = CType(resources.GetObject("TreeViewImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.TreeViewImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.TreeViewImageList.Images.SetKeyName(0, "client_network.png")
        Me.TreeViewImageList.Images.SetKeyName(1, "data.png")
        Me.TreeViewImageList.Images.SetKeyName(2, "server.png")
        Me.TreeViewImageList.Images.SetKeyName(3, "DiaryEditIcon.ico")
        '
        'TabSMTP
        '
        Me.TabSMTP.Controls.Add(Me.LabelLatestVersion2)
        Me.TabSMTP.Controls.Add(Me.LabelLatestVersion1)
        Me.TabSMTP.Controls.Add(Me.LabelInstalledVersion2)
        Me.TabSMTP.Controls.Add(Me.LabelInstalledVersion1)
        Me.TabSMTP.Controls.Add(Me.btnSmtpInstall)
        Me.TabSMTP.Location = New System.Drawing.Point(4, 22)
        Me.TabSMTP.Name = "TabSMTP"
        Me.TabSMTP.Size = New System.Drawing.Size(743, 445)
        Me.TabSMTP.TabIndex = 7
        Me.TabSMTP.Text = "SMTP"
        Me.TabSMTP.UseVisualStyleBackColor = True
        '
        'LabelLatestVersion2
        '
        Me.LabelLatestVersion2.AutoSize = True
        Me.LabelLatestVersion2.Location = New System.Drawing.Point(265, 42)
        Me.LabelLatestVersion2.Name = "LabelLatestVersion2"
        Me.LabelLatestVersion2.Size = New System.Drawing.Size(76, 13)
        Me.LabelLatestVersion2.TabIndex = 5
        Me.LabelLatestVersion2.Text = "Latest version:"
        '
        'LabelLatestVersion1
        '
        Me.LabelLatestVersion1.AutoSize = True
        Me.LabelLatestVersion1.Location = New System.Drawing.Point(13, 42)
        Me.LabelLatestVersion1.Name = "LabelLatestVersion1"
        Me.LabelLatestVersion1.Size = New System.Drawing.Size(76, 13)
        Me.LabelLatestVersion1.TabIndex = 4
        Me.LabelLatestVersion1.Text = "Latest version:"
        '
        'LabelInstalledVersion2
        '
        Me.LabelInstalledVersion2.AutoSize = True
        Me.LabelInstalledVersion2.Location = New System.Drawing.Point(265, 21)
        Me.LabelInstalledVersion2.Name = "LabelInstalledVersion2"
        Me.LabelInstalledVersion2.Size = New System.Drawing.Size(86, 13)
        Me.LabelInstalledVersion2.TabIndex = 3
        Me.LabelInstalledVersion2.Text = "Installed version:"
        '
        'LabelInstalledVersion1
        '
        Me.LabelInstalledVersion1.AutoSize = True
        Me.LabelInstalledVersion1.Location = New System.Drawing.Point(13, 20)
        Me.LabelInstalledVersion1.Name = "LabelInstalledVersion1"
        Me.LabelInstalledVersion1.Size = New System.Drawing.Size(86, 13)
        Me.LabelInstalledVersion1.TabIndex = 2
        Me.LabelInstalledVersion1.Text = "Installed version:"
        '
        'btnSmtpInstall
        '
        Me.btnSmtpInstall.Location = New System.Drawing.Point(11, 76)
        Me.btnSmtpInstall.Name = "btnSmtpInstall"
        Me.btnSmtpInstall.Size = New System.Drawing.Size(712, 118)
        Me.btnSmtpInstall.TabIndex = 1
        Me.btnSmtpInstall.Text = "Click to Install/Upgrade SMTP Component"
        Me.btnSmtpInstall.UseVisualStyleBackColor = True
        '
        'tbRegistry
        '
        Me.tbRegistry.Controls.Add(Me.lblRegistryWarn)
        Me.tbRegistry.Controls.Add(Me.gbRegistry)
        Me.tbRegistry.Location = New System.Drawing.Point(4, 22)
        Me.tbRegistry.Name = "tbRegistry"
        Me.tbRegistry.Size = New System.Drawing.Size(743, 445)
        Me.tbRegistry.TabIndex = 5
        Me.tbRegistry.Text = "Registry"
        Me.tbRegistry.ToolTipText = "Allows editing of the registry."
        Me.tbRegistry.UseVisualStyleBackColor = True
        '
        'lblRegistryWarn
        '
        Me.lblRegistryWarn.AutoSize = True
        Me.lblRegistryWarn.Location = New System.Drawing.Point(16, 4)
        Me.lblRegistryWarn.Name = "lblRegistryWarn"
        Me.lblRegistryWarn.Size = New System.Drawing.Size(318, 13)
        Me.lblRegistryWarn.TabIndex = 1
        Me.lblRegistryWarn.Text = "To display, uncheck ""Allow user to select server"" on previous tab "
        '
        'gbRegistry
        '
        Me.gbRegistry.Controls.Add(Me.txtRegistryDatabase)
        Me.gbRegistry.Controls.Add(Me.Label29)
        Me.gbRegistry.Controls.Add(Me.Label28)
        Me.gbRegistry.Controls.Add(Me.txtRegistryServer)
        Me.gbRegistry.Controls.Add(Me.btnDeleteReg)
        Me.gbRegistry.Controls.Add(Me.btnAddReg)
        Me.gbRegistry.Controls.Add(Me.btnSaveRegistry)
        Me.gbRegistry.Controls.Add(Me.txtClientPortalPassword)
        Me.gbRegistry.Controls.Add(Me.Label27)
        Me.gbRegistry.Controls.Add(Me.txtClientPortalUsername)
        Me.gbRegistry.Controls.Add(Me.Label26)
        Me.gbRegistry.Controls.Add(Me.txtAdminPassword)
        Me.gbRegistry.Controls.Add(Me.Label25)
        Me.gbRegistry.Controls.Add(Me.txtAdminUsername)
        Me.gbRegistry.Controls.Add(Me.Label24)
        Me.gbRegistry.Controls.Add(Me.tvRegistry)
        Me.gbRegistry.Location = New System.Drawing.Point(9, 20)
        Me.gbRegistry.Name = "gbRegistry"
        Me.gbRegistry.Size = New System.Drawing.Size(722, 411)
        Me.gbRegistry.TabIndex = 0
        Me.gbRegistry.TabStop = False
        Me.gbRegistry.Text = "Registry Editor"
        '
        'txtRegistryDatabase
        '
        Me.txtRegistryDatabase.Location = New System.Drawing.Point(405, 79)
        Me.txtRegistryDatabase.Name = "txtRegistryDatabase"
        Me.txtRegistryDatabase.Size = New System.Drawing.Size(299, 20)
        Me.txtRegistryDatabase.TabIndex = 16
        '
        'Label29
        '
        Me.Label29.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label29.ImageIndex = 1
        Me.Label29.ImageList = Me.TreeViewImageList
        Me.Label29.Location = New System.Drawing.Point(405, 63)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(100, 13)
        Me.Label29.TabIndex = 15
        Me.Label29.Text = "Database:"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label28
        '
        Me.Label28.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label28.ImageIndex = 0
        Me.Label28.ImageList = Me.TreeViewImageList
        Me.Label28.Location = New System.Drawing.Point(405, 22)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(90, 13)
        Me.Label28.TabIndex = 14
        Me.Label28.Text = "Server:"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtRegistryServer
        '
        Me.txtRegistryServer.Location = New System.Drawing.Point(405, 38)
        Me.txtRegistryServer.Name = "txtRegistryServer"
        Me.txtRegistryServer.Size = New System.Drawing.Size(299, 20)
        Me.txtRegistryServer.TabIndex = 13
        '
        'btnDeleteReg
        '
        Me.btnDeleteReg.Location = New System.Drawing.Point(559, 116)
        Me.btnDeleteReg.Name = "btnDeleteReg"
        Me.btnDeleteReg.Size = New System.Drawing.Size(145, 23)
        Me.btnDeleteReg.TabIndex = 12
        Me.btnDeleteReg.Text = "Delete"
        '
        'btnAddReg
        '
        Me.btnAddReg.Location = New System.Drawing.Point(405, 116)
        Me.btnAddReg.Name = "btnAddReg"
        Me.btnAddReg.Size = New System.Drawing.Size(145, 23)
        Me.btnAddReg.TabIndex = 11
        Me.btnAddReg.Text = "Add"
        '
        'btnSaveRegistry
        '
        Me.btnSaveRegistry.Location = New System.Drawing.Point(10, 361)
        Me.btnSaveRegistry.Name = "btnSaveRegistry"
        Me.btnSaveRegistry.Size = New System.Drawing.Size(372, 35)
        Me.btnSaveRegistry.TabIndex = 9
        Me.btnSaveRegistry.Text = "Save"
        '
        'txtClientPortalPassword
        '
        Me.txtClientPortalPassword.Enabled = False
        Me.txtClientPortalPassword.Location = New System.Drawing.Point(10, 335)
        Me.txtClientPortalPassword.Name = "txtClientPortalPassword"
        Me.txtClientPortalPassword.Size = New System.Drawing.Size(372, 20)
        Me.txtClientPortalPassword.TabIndex = 8
        Me.txtClientPortalPassword.UseSystemPasswordChar = True
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(7, 319)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(115, 13)
        Me.Label27.TabIndex = 7
        Me.Label27.Text = "Client Portal Password:"
        '
        'txtClientPortalUsername
        '
        Me.txtClientPortalUsername.Enabled = False
        Me.txtClientPortalUsername.Location = New System.Drawing.Point(10, 296)
        Me.txtClientPortalUsername.Name = "txtClientPortalUsername"
        Me.txtClientPortalUsername.Size = New System.Drawing.Size(372, 20)
        Me.txtClientPortalUsername.TabIndex = 6
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(7, 280)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(117, 13)
        Me.Label26.TabIndex = 5
        Me.Label26.Text = "Client Portal Username:"
        '
        'txtAdminPassword
        '
        Me.txtAdminPassword.Enabled = False
        Me.txtAdminPassword.Location = New System.Drawing.Point(10, 257)
        Me.txtAdminPassword.Name = "txtAdminPassword"
        Me.txtAdminPassword.Size = New System.Drawing.Size(372, 20)
        Me.txtAdminPassword.TabIndex = 4
        Me.txtAdminPassword.UseSystemPasswordChar = True
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(7, 241)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(88, 13)
        Me.Label25.TabIndex = 3
        Me.Label25.Text = "Admin Password:"
        '
        'txtAdminUsername
        '
        Me.txtAdminUsername.Enabled = False
        Me.txtAdminUsername.Location = New System.Drawing.Point(10, 218)
        Me.txtAdminUsername.Name = "txtAdminUsername"
        Me.txtAdminUsername.Size = New System.Drawing.Size(372, 20)
        Me.txtAdminUsername.TabIndex = 2
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(7, 201)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(90, 13)
        Me.Label24.TabIndex = 1
        Me.Label24.Text = "Admin Username:"
        '
        'tvRegistry
        '
        Me.tvRegistry.FullRowSelect = True
        Me.tvRegistry.HideSelection = False
        Me.tvRegistry.HotTracking = True
        Me.tvRegistry.Location = New System.Drawing.Point(7, 20)
        Me.tvRegistry.Name = "tvRegistry"
        TreeNode2.Name = "Home"
        TreeNode2.Text = "Home"
        Me.tvRegistry.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode2})
        Me.tvRegistry.Size = New System.Drawing.Size(375, 167)
        Me.tvRegistry.TabIndex = 0
        '
        'tabWebServices
        '
        Me.tabWebServices.Controls.Add(Me.lblWarning)
        Me.tabWebServices.Controls.Add(Me.Label32)
        Me.tabWebServices.Controls.Add(Me.Label31)
        Me.tabWebServices.Controls.Add(Me.btnCreate)
        Me.tabWebServices.Controls.Add(Me.txtURL)
        Me.tabWebServices.Controls.Add(Me.Label30)
        Me.tabWebServices.Location = New System.Drawing.Point(4, 22)
        Me.tabWebServices.Name = "tabWebServices"
        Me.tabWebServices.Size = New System.Drawing.Size(743, 445)
        Me.tabWebServices.TabIndex = 6
        Me.tabWebServices.Text = "Web Services"
        Me.tabWebServices.UseVisualStyleBackColor = True
        '
        'lblWarning
        '
        Me.lblWarning.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWarning.ForeColor = System.Drawing.Color.Red
        Me.lblWarning.Location = New System.Drawing.Point(10, 101)
        Me.lblWarning.Name = "lblWarning"
        Me.lblWarning.Size = New System.Drawing.Size(251, 59)
        Me.lblWarning.TabIndex = 13
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(17, 173)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(209, 13)
        Me.Label32.TabIndex = 12
        Me.Label32.Text = "Example: https://webvantage.agency.com"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(17, 160)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(177, 13)
        Me.Label31.TabIndex = 11
        Me.Label31.Text = "Example: http://server/webvantage"
        '
        'btnCreate
        '
        Me.btnCreate.Location = New System.Drawing.Point(14, 75)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(710, 23)
        Me.btnCreate.TabIndex = 10
        Me.btnCreate.Text = "&Apply"
        '
        'txtURL
        '
        Me.txtURL.Location = New System.Drawing.Point(14, 52)
        Me.txtURL.Name = "txtURL"
        Me.txtURL.Size = New System.Drawing.Size(710, 20)
        Me.txtURL.TabIndex = 1
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(11, 35)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(140, 13)
        Me.Label30.TabIndex = 0
        Me.Label30.Text = "Enter URL for Webvantage:"
        '
        'BtnDeleteCache
        '
        Me.BtnDeleteCache.Location = New System.Drawing.Point(4, 616)
        Me.BtnDeleteCache.Name = "BtnDeleteCache"
        Me.BtnDeleteCache.Size = New System.Drawing.Size(224, 23)
        Me.BtnDeleteCache.TabIndex = 10
        Me.BtnDeleteCache.Text = "Clear ASP.Net 2.0 Temporary Cache"
        Me.BtnDeleteCache.UseVisualStyleBackColor = True
        Me.BtnDeleteCache.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(1, 46)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox1.Size = New System.Drawing.Size(376, 16)
        Me.TextBox1.TabIndex = 4
        Me.TextBox1.Text = "TextBox1"
        Me.TextBox1.Visible = False
        '
        'epEmailPassword
        '
        Me.epEmailPassword.ContainerControl = Me
        '
        'epSMTPAddress
        '
        Me.epSMTPAddress.ContainerControl = Me
        '
        'epEmailAddress
        '
        Me.epEmailAddress.ContainerControl = Me
        '
        'txtConfigReportingServices
        '
        Me.txtConfigReportingServices.Location = New System.Drawing.Point(8, 20)
        Me.txtConfigReportingServices.Name = "txtConfigReportingServices"
        Me.txtConfigReportingServices.Size = New System.Drawing.Size(360, 20)
        Me.txtConfigReportingServices.TabIndex = 1
        Me.txtConfigReportingServices.Text = "LocalHost"
        Me.txtConfigReportingServices.Visible = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtConfigReportingServices)
        Me.GroupBox4.Controls.Add(Me.TextBox1)
        Me.GroupBox4.Location = New System.Drawing.Point(10, 655)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(376, 48)
        Me.GroupBox4.TabIndex = 13
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Name or IP Address of SQL Reporting Server"
        Me.GroupBox4.Visible = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(462, 1044)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(119, 13)
        Me.Label17.TabIndex = 27
        Me.Label17.Text = "Administrator Password:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(462, 1005)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(121, 13)
        Me.Label15.TabIndex = 26
        Me.Label15.Text = "Administrator Username:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(462, 924)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 13)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Database Server Name:"
        '
        'TxtAdmPassword
        '
        Me.TxtAdmPassword.Location = New System.Drawing.Point(462, 1059)
        Me.TxtAdmPassword.Name = "TxtAdmPassword"
        Me.TxtAdmPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtAdmPassword.Size = New System.Drawing.Size(342, 20)
        Me.TxtAdmPassword.TabIndex = 24
        '
        'TxtAdmUserName
        '
        Me.TxtAdmUserName.Location = New System.Drawing.Point(462, 1021)
        Me.TxtAdmUserName.Name = "TxtAdmUserName"
        Me.TxtAdmUserName.Size = New System.Drawing.Size(342, 20)
        Me.TxtAdmUserName.TabIndex = 23
        '
        'TxtAdmServerName
        '
        Me.TxtAdmServerName.Location = New System.Drawing.Point(462, 940)
        Me.TxtAdmServerName.Name = "TxtAdmServerName"
        Me.TxtAdmServerName.Size = New System.Drawing.Size(342, 20)
        Me.TxtAdmServerName.TabIndex = 22
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(284, 357)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(99, 23)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "Set machine.config"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBoxChatDB
        '
        Me.GroupBoxChatDB.Controls.Add(Me.Label40)
        Me.GroupBoxChatDB.Controls.Add(Me.Label39)
        Me.GroupBoxChatDB.Controls.Add(Me.TextBoxChatPassword)
        Me.GroupBoxChatDB.Controls.Add(Me.Label37)
        Me.GroupBoxChatDB.Controls.Add(Me.TextBoxChatUsername)
        Me.GroupBoxChatDB.Controls.Add(Me.Label36)
        Me.GroupBoxChatDB.Controls.Add(Me.TextBoxChatDatabaseName)
        Me.GroupBoxChatDB.Controls.Add(Me.Label35)
        Me.GroupBoxChatDB.Controls.Add(Me.TextBoxChatServerName)
        Me.GroupBoxChatDB.Controls.Add(Me.Label38)
        Me.GroupBoxChatDB.Location = New System.Drawing.Point(933, 497)
        Me.GroupBoxChatDB.Name = "GroupBoxChatDB"
        Me.GroupBoxChatDB.Size = New System.Drawing.Size(349, 304)
        Me.GroupBoxChatDB.TabIndex = 28
        Me.GroupBoxChatDB.TabStop = False
        Me.GroupBoxChatDB.Text = "Chat Database*"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(17, 222)
        Me.Label40.MaximumSize = New System.Drawing.Size(300, 0)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(192, 13)
        Me.Label40.TabIndex = 11
        Me.Label40.Text = "** Clear all values to delete registry key!"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(17, 173)
        Me.Label39.MaximumSize = New System.Drawing.Size(300, 0)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(299, 39)
        Me.Label39.TabIndex = 10
        Me.Label39.Text = "* Chat requires its own database separate from the Advantage database.  If you ha" &
    "ve not already done so, create a blank database and enter the information for it" &
    " above!"
        '
        'TextBoxChatPassword
        '
        Me.TextBoxChatPassword.Location = New System.Drawing.Point(106, 134)
        Me.TextBoxChatPassword.Name = "TextBoxChatPassword"
        Me.TextBoxChatPassword.Size = New System.Drawing.Size(224, 20)
        Me.TextBoxChatPassword.TabIndex = 9
        Me.TextBoxChatPassword.UseSystemPasswordChar = True
        '
        'Label37
        '
        Me.Label37.Location = New System.Drawing.Point(2, 134)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(100, 16)
        Me.Label37.TabIndex = 8
        Me.Label37.Text = "Password:"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxChatUsername
        '
        Me.TextBoxChatUsername.Location = New System.Drawing.Point(106, 103)
        Me.TextBoxChatUsername.Name = "TextBoxChatUsername"
        Me.TextBoxChatUsername.Size = New System.Drawing.Size(224, 20)
        Me.TextBoxChatUsername.TabIndex = 7
        '
        'Label36
        '
        Me.Label36.Location = New System.Drawing.Point(2, 103)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(100, 16)
        Me.Label36.TabIndex = 6
        Me.Label36.Text = "Username:"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxChatDatabaseName
        '
        Me.TextBoxChatDatabaseName.Location = New System.Drawing.Point(106, 61)
        Me.TextBoxChatDatabaseName.Name = "TextBoxChatDatabaseName"
        Me.TextBoxChatDatabaseName.Size = New System.Drawing.Size(224, 20)
        Me.TextBoxChatDatabaseName.TabIndex = 5
        '
        'Label35
        '
        Me.Label35.Location = New System.Drawing.Point(2, 61)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(100, 16)
        Me.Label35.TabIndex = 4
        Me.Label35.Text = "Database Name:"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxChatServerName
        '
        Me.TextBoxChatServerName.Location = New System.Drawing.Point(106, 28)
        Me.TextBoxChatServerName.Name = "TextBoxChatServerName"
        Me.TextBoxChatServerName.Size = New System.Drawing.Size(224, 20)
        Me.TextBoxChatServerName.TabIndex = 3
        '
        'Label38
        '
        Me.Label38.Location = New System.Drawing.Point(2, 28)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(100, 16)
        Me.Label38.TabIndex = 2
        Me.Label38.Text = "SQL Server Name:"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(400, 208)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(171, 23)
        Me.Button2.TabIndex = 14
        Me.Button2.Text = "Check .NET"
        Me.Button2.Visible = False
        '
        'frmWebConfig
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(755, 509)
        Me.Controls.Add(Me.GroupBoxChatDB)
        Me.Controls.Add(Me.gbWebFarm)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtAdmPassword)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.TxtAdmUserName)
        Me.Controls.Add(Me.TxtAdmServerName)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.BtnDeleteCache)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.tcWebvantageConfig)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmWebConfig"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.tbApp.ResumeLayout(False)
        Me.tbApp.PerformLayout()
        Me.gpGeneralSettings.ResumeLayout(False)
        Me.gpGeneralSettings.PerformLayout()
        Me.grpApplicationAuthentication.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbWebFarm.ResumeLayout(False)
        Me.gbWebFarm.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.tbDatabase.ResumeLayout(False)
        Me.grpDatabase.ResumeLayout(False)
        Me.grpDatabase.PerformLayout()
        Me.grpAuthentication.ResumeLayout(False)
        Me.grpAuthentication.PerformLayout()
        Me.grpDatabaseServer.ResumeLayout(False)
        Me.grpDatabaseServer.PerformLayout()
        Me.tcWebvantageConfig.ResumeLayout(False)
        Me.tbIIS.ResumeLayout(False)
        Me.tbIIS.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.gbWVVirtualDir.ResumeLayout(False)
        Me.gbWVVirtualDir.PerformLayout()
        Me.grpCreateWebVirtDir.ResumeLayout(False)
        Me.grpCreateWebVirtDir.PerformLayout()
        Me.TabPageConnection.ResumeLayout(False)
        Me.TabPageConnection.PerformLayout()
        Me.TabSMTP.ResumeLayout(False)
        Me.TabSMTP.PerformLayout()
        Me.tbRegistry.ResumeLayout(False)
        Me.tbRegistry.PerformLayout()
        Me.gbRegistry.ResumeLayout(False)
        Me.gbRegistry.PerformLayout()
        Me.tabWebServices.ResumeLayout(False)
        Me.tabWebServices.PerformLayout()
        CType(Me.epEmailPassword, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.epSMTPAddress, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.epEmailAddress, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBoxChatDB.ResumeLayout(False)
        Me.GroupBoxChatDB.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub frmWebConfig_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DebugPrint("Debug mode is ON you can turn it off via Configurator.Config file")
        Try
            Me.ButtonSetMachineConfig.Enabled = Me.MachineConfigNeedsUpdating()
        Catch ex As Exception
        End Try

        Try
            If CheckForASPNET() = False Then
                If MessageBox.Show("ASP.NET 4.0 not installed. Continue anyway?", "Warning.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No Then
                    Application.Exit()
                End If
            End If
        Catch ex As Exception
        End Try
        Try
            If CheckVersionOfIIS().StartsWith("7") Then
                If CheckForCompatabilityMode() = False Then
                    If MessageBox.Show("IIS 6 Management Compatibility not installed. Continue anyway?", "Warning.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No Then
                        Application.Exit()
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
        Try
            If isClientPortal = True Then

                Me.txtVirtualDirectory.Text = "clientportal"
                Me.gbWVVirtualDir.Text = "Client Portal Virtual Directory"
                Me.chkVirtualDirectory.Text = "Create Client Portal Virtual Directory"
                Me.chkUpperCaseUser.Visible = False
                Me.chkChooseServer.Checked = False
                Me.chkChooseServer.Visible = False
                Me.Label30.Text = "Enter URL for Client Portal:"
                Me.Label13.Text = "Location of the Client Portal web.config file:"
                Me.chkSQLControledAdmin.Visible = False
                Me.grpApplicationAuthentication.Visible = False
                Me.Text = "Client Portal Configurator"
                Me.tbDatabase.Enabled = False
                Me.tabWebServices.Enabled = False
                Me.GroupBoxChatDB.Visible = False

            End If

            Me.rbWIA.Checked = True
            Me.txtUserName.Enabled = False
            Me.txtPassword.Enabled = False
            Me.txtPhysicalPath.Text = Me.drpIISWebsite.SelectedValue & "\" & Me.txtVirtualDirectory.Text
            txtwebconfig1.Text = Me.drpIISWebsite.SelectedValue & "\" & Me.txtVirtualDirectory.Text

        Catch ex As Exception
        End Try
        Try
            If isClientPortal = True Then

                lblRegistryWarn.Visible = False
                gbRegistry.Visible = True
                FillRegistryPage()
                LoadConnectionDatabaseProfiles()

            Else

                If chkChooseServer.Checked = False Then

                    lblRegistryWarn.Visible = False
                    gbRegistry.Visible = True
                    FillRegistryPage()
                    LoadConnectionDatabaseProfiles()

                Else

                    lblRegistryWarn.Visible = True
                    gbRegistry.Visible = False
                    LoadConnectionDatabaseProfiles()

                End If

            End If

        Catch ex As Exception
        End Try
        Try
            Me.ButtonCreateEventLog.Enabled = System.Diagnostics.EventLog.SourceExists(_WebvantageEventSource) = False
        Catch ex As Exception
            Me.ButtonCreateEventLog.Enabled = True
        End Try
        Try
            Me.ButtonProofingEventLog.Enabled = System.Diagnostics.EventLog.SourceExists(_ProofingEventSource) = False
        Catch ex As Exception
            Me.ButtonProofingEventLog.Enabled = True
        End Try
        LoadChatDatabaseInfoFromRegistry()
        GetSmtpVersionInfo()
    End Sub
    Private Sub frmWebConfig_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        Application.Exit()
    End Sub

#End Region

#End Region

    Private Sub Disco()
        Dim StrCmdLine As String = ""
        Try
            If GlobalConnString = "" Then Exit Sub
            Dim StrWVURL As String = ""
            Using MyConn As New SqlConnection(GlobalConnString)
                MyConn.Open()
                Dim MyCmd As New SqlCommand("SELECT WEBVANTAGE_URL FROM AGENCY WITH(NOLOCK)", MyConn)
                Try
                    StrWVURL = MyCmd.ExecuteScalar()
                Catch ex As Exception
                    StrWVURL = ""
                Finally
                    If MyConn.State = ConnectionState.Open Then MyConn.Close()
                End Try
            End Using
            If StrWVURL <> "" Then 'proceed with disco
                StrWVURL &= "/GetRepositoryDoc.asmx"
                StrCmdLine = Application.StartupPath & "\disco " & StrWVURL ' " & Chr(34) & StrWVURL & Chr(34)
                Dim p As Process = Process.Start(StrCmdLine)
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString() & Environment.NewLine & StrCmdLine, MsgBoxStyle.OkOnly, "Disco did not run")
        End Try
    End Sub
    Public Sub FillRegistryPage()
        Try
            tvRegistry.Nodes.Clear()
            'tvRegistry.Nodes.Add(New TreeNode("Home"))
            'Dim tvNode As New TreeNode
            'tvNode = tvRegistry.Nodes(0)
            PopulateTreeView(0, Nothing)
            'tvNode.Expand()
            tvRegistry.ExpandAll()

        Catch ex As Exception

        End Try
    End Sub
    Public Sub PopulateTreeView(ByVal iParentID As Integer, ByVal oTreeNode As TreeNode)
        Try

            Dim regkey As RegistryKey

            If is64Bit() = False Then

                regkey = My.Computer.Registry.LocalMachine.OpenSubKey("Software\Advantage\Servers")

            Else

                regkey = My.Computer.Registry.LocalMachine.OpenSubKey("Software\WOW6432Node\Advantage\Servers")

            End If

            Try

                PrintKeys2(regkey, iParentID, oTreeNode)
                regkey.Close()

            Catch x As Exception
            End Try

        Catch ex As Exception
        End Try

    End Sub
    Public Sub PrintKeys2(ByVal rkey As RegistryKey, ByVal iParentID As Integer, ByVal oTreeNode As TreeNode)
        ' Retrieve all the subkeys for the specified key and there value
        ' name and values
        Try
            Dim names As String() = rkey.GetSubKeyNames()
            Dim subkey As String

            tvRegistry.ImageList = Me.TreeViewImageList

            ' Open the next subkey if any and call myself.
            For Each subkey In names

                Dim regkey As RegistryKey

                regkey = rkey.OpenSubKey(subkey)

                If regkey.Name.Contains(globals.ChatDBConstant) = False Then

                    If IsNothing(oTreeNode) Then

                        oTreeNode = tvRegistry.Nodes.Add(subkey)
                        oTreeNode.Tag = regkey.Name.ToString
                        oTreeNode.ImageIndex = 0

                    Else

                        oTreeNode = oTreeNode.Nodes.Add(subkey)
                        oTreeNode.Tag = regkey.Name.ToString
                        oTreeNode.ImageIndex = 1

                    End If

                End If

                PrintKeys2(regkey, iParentID, oTreeNode)

                regkey.Close()

                oTreeNode = oTreeNode.Parent

            Next subkey

        Catch x As Exception
            'no items in nodes.
        End Try
    End Sub
    Public Function CheckForCompatabilityMode() As Boolean
        Try
            'HKLM\Software\Microsoft\ASP.NET\2.0.50727.0
            'Check to see if we have asp.net 2.0 installed.
            Dim bReturn As Boolean = False
            Dim sValue As String
            Try
                sValue = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\InetStp\Components\", "Metabase", Nothing)
                DebugPrint("Compatability switch is set to: " + sValue.ToString())
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
    Public Sub DebugPrint(ByVal sMessage As String)
        Try
            Dim isInDebugMode As Boolean = CBool(System.Configuration.ConfigurationManager.AppSettings("DEBUG"))
            If isInDebugMode = True Then
                MessageBox.Show(sMessage, "DEBUG", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Function CheckVersionOfIIS() As String
        Try
            ' FileVersionInfo verinfo = FileVersionInfo.GetVersionInfo(System.Environment.SystemDirectory + @"\inetsrv\inetinfo.exe"); 
            Dim sReturn As String = "0"
            If Directory.Exists(System.Environment.SystemDirectory + "\inetsrv\") Then
                If File.Exists(System.Environment.SystemDirectory + "\inetsrv\w3wp.exe") Then
                    Dim VerInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(System.Environment.SystemDirectory + "\inetsrv\w3wp.exe")
                    DebugPrint(VerInfo.ToString())
                    sReturn = VerInfo.FileVersion().ToString()
                End If
                If File.Exists(System.Environment.SystemDirectory + "\inetsrv\inetinfo.exe") Then
                    Dim VerInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(System.Environment.SystemDirectory + "\inetsrv\inetinfo.exe")
                    DebugPrint(VerInfo.ToString())
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
                'sValue = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\ASP.NET\2.0.50727.0", "Path", Nothing)
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
    Private Function IsStateServiceRunning() As Boolean
        Try
            Dim controller As New ServiceController("ASP.NET State Service")
            If controller.Status.Equals(ServiceControllerStatus.Stopped) = True Then

                MsgBox("The ASP.NET State Service is required")
                Return False

            Else

                Return True

            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        End Try
    End Function
    Public Sub ProcessTree(ByVal Dir As String)
        Try
            Dim DirObj As New DirectoryInfo(Dir)

            Dim Files As FileInfo() = DirObj.GetFiles("*.*")
            Dim Dirs As DirectoryInfo() = DirObj.GetDirectories("*.*")

            Dim Filename As FileInfo

            For Each Filename In Files
                Try
                    'If (Filename.Attributes And FileAttributes.ReadOnly) Then
                    Filename.Attributes = (Filename.Attributes And Not FileAttributes.ReadOnly And Not FileAttributes.Hidden)
                    'End If
                Catch E As Exception
                    Console.WriteLine("Error changing attribute for {0}", Filename.FullName)
                    Console.WriteLine("Error: {0}", E.Message)
                End Try
            Next

            Dim DirectoryName As DirectoryInfo

            For Each DirectoryName In Dirs
                Try
                    ProcessTree(DirectoryName.FullName)
                Catch E As Exception
                    Console.WriteLine("Error accessing {0}", DirectoryName.FullName)
                    Console.WriteLine("Error: {0}", E.Message)
                End Try
            Next

        Catch ex As Exception
        End Try
    End Sub
    Private Sub ConfigureWebConfigs(Checked As Boolean)
        Try
            'Fetch the physical path of the website and configure that web.config
            If Checked Then
                ConfigureWebConfigForAnonymousAuthentication(txtwebconfig1.Text)
            End If

        Catch ex As Exception
            MsgBox("Error finding or reading web.config file.")
        End Try
    End Sub
    Private Sub ConfigureWebConfigForAnonymousAuthentication(WebConfigFilePath As String)
        'Find the associated Web.Config file for alteration
        Dim XmlDocumentWebConfigDoc As New Xml.XmlDocument
        Dim XmlLocationNode As XmlNode
        Dim XmlNodePathAttributes(16) As String

        If Not System.IO.File.Exists(WebConfigFilePath) Then
            Throw New FileLoadException("File Not Found")
        End If

        ' Make backup of Web.Config file in case FUBAR....
        CopyFileToNewFilename(WebConfigFilePath, $"{WebConfigFilePath}.{DateTime.Now.Month}{DateTime.Now.Day}{DateTime.Now.Hour}{DateTime.Now.Minute}")
        'Initialize String Array with Node Names
        XmlNodePathAttributes(0) = "TEMP"
        XmlNodePathAttributes(1) = "JScripts"
        XmlNodePathAttributes(2) = "Scripts"
        XmlNodePathAttributes(3) = "CSS"
        XmlNodePathAttributes(4) = "MediaManager"
        XmlNodePathAttributes(5) = "Media/MediaManager"
        XmlNodePathAttributes(6) = "Media/MakegoodDelivery"
        XmlNodePathAttributes(7) = "Media/MediaTraffic"
        XmlNodePathAttributes(8) = "Document"
        XmlNodePathAttributes(9) = "Utilities/Document"
        XmlNodePathAttributes(10) = "Content"
        XmlNodePathAttributes(11) = "bundles"
        XmlNodePathAttributes(12) = "theme"
        XmlNodePathAttributes(13) = "favicon.ico"
        XmlNodePathAttributes(14) = "fonts"
        XmlNodePathAttributes(15) = "Images"

        ' Read config file as .XML
        XmlDocumentWebConfigDoc.Load(WebConfigFilePath)
        'Loop through each Node Attribute
        For Each XmlNodePathAttribute As String In XmlNodePathAttributes

            If String.IsNullOrWhiteSpace(XmlNodePathAttribute) = False Then

                XmlLocationNode = XmlDocumentWebConfigDoc.SelectSingleNode($"configuration/location[@path='{XmlNodePathAttribute}']")

                If XmlLocationNode Is Nothing Then

                    CreateWebConfigNodeForAnonymousAuthentication(XmlNodePathAttribute, XmlDocumentWebConfigDoc)

                Else

                    ConfigureWebConfigNodeForAnonymousAuthentication(XmlLocationNode)

                End If

            End If

        Next

        'Save changes to web.config
        XmlDocumentWebConfigDoc.Save(WebConfigFilePath)

    End Sub
    Private Sub CreateWebConfigNodeForAnonymousAuthentication(XmlLocationNodePath As String, ByRef XmlWebConfigLocationNodeList As XmlDocument)

        Dim WebConfigLocationWebServerSecurityNodeAttributes As String = "<system.webServer><security><authentication><anonymousAuthentication enabled=""true"" /></authentication></security></system.webServer>"
        Dim WebConfigLocationAuthorizationNodeAttributes As String = "<system.web><authorization><allow users = ""*"" /></authorization></system.web>"
        Dim WebConfigLocationNode As XmlNode = XmlWebConfigLocationNodeList.SelectSingleNode("configuration/location")
        Dim WebConfigXmlElementInfo As XmlElement = XmlWebConfigLocationNodeList.CreateElement("location")

        WebConfigXmlElementInfo.SetAttribute("path", XmlLocationNodePath)
        WebConfigXmlElementInfo.InnerXml = $"{WebConfigLocationWebServerSecurityNodeAttributes}{WebConfigLocationAuthorizationNodeAttributes}"
        WebConfigLocationNode.ParentNode.AppendChild(WebConfigXmlElementInfo)
    End Sub
    Private Sub ConfigureWebConfigNodeForAnonymousAuthentication(ByRef WebConfigXmlNode As XmlNode)
        Dim SystemServerWebAttributes As String =
            "<system.webServer><security><authentication><anonymousAuthentication enabled=""true"" /></authentication></security></system.webServer>"

        If Not WebConfigXmlNode.InnerXml.Contains(SystemServerWebAttributes) Then
            WebConfigXmlNode.InnerXml = $"{SystemServerWebAttributes}{WebConfigXmlNode.InnerXml}"
        End If

    End Sub
    Private Sub ConfigureAppAuthentication(Checked As Boolean)
        Try

            Dim SaveChangesToApplicationHostConfig As Boolean = False
            Dim ApplicationHost_Config As String = String.Empty
            Dim XmlDocumentApplicationConfigDoc As New Xml.XmlDocument

            If Checked Then ' Use AnonymousAuthentication
                ' Find the applicationHost config file in the Windows32 directory
                ApplicationHost_Config = $"{Environment.SystemDirectory}\inetsrv\config\applicationHost.config"

                If Not System.IO.File.Exists(ApplicationHost_Config) Then
                    Throw New FileLoadException("File Not Found")
                End If

                ' Read config file as .XML
                XmlDocumentApplicationConfigDoc.Load(ApplicationHost_Config)

                'Loop through the selected Nodes.
                For Each xmlAnonymousAuthenticationNode As XmlNode In XmlDocumentApplicationConfigDoc.SelectNodes("configuration/configSections/sectionGroup/sectionGroup/sectionGroup/section")
                    'Fetch the Node and Attribute values.
                    If xmlAnonymousAuthenticationNode.Attributes("name").Value.Equals("anonymousAuthentication") And
                       xmlAnonymousAuthenticationNode.Attributes("overrideModeDefault").Value.Equals("Deny") Then

                        SaveChangesToApplicationHostConfig = True

                        xmlAnonymousAuthenticationNode.Attributes("overrideModeDefault").InnerText = "Allow"

                    End If
                Next
                'Save changes if any
                If SaveChangesToApplicationHostConfig Then XmlDocumentApplicationConfigDoc.Save(ApplicationHost_Config)

            End If
        Catch ex As Exception
            MsgBox("Error finding Or reading applicationHost.config file.")
        End Try
    End Sub
    Public Function CopyDirectoryWithGraphics(ByVal source As String, ByVal destination As String)
        Try
            Dim currentDirectory As DirectoryInfo = New DirectoryInfo(source)
            Dim file As FileInfo
            For Each file In currentDirectory.GetFiles()
                Me.lblProgress.Text = "Copying: " + Path.Combine(destination, file.Name).ToString
                Application.DoEvents()
                file.CopyTo(Path.Combine(destination, file.Name), True)
            Next
            Dim di As DirectoryInfo
            For Each di In currentDirectory.GetDirectories()
                Dim subDirectory As String = Path.Combine(destination, di.Name)
                Directory.CreateDirectory(subDirectory)
                CopyDirectoryWithGraphics(di.FullName, subDirectory)
            Next
        Catch ex As Exception
        End Try
    End Function
    Public Function CopyDirectoryWithGraphicsWV(ByVal source As String, ByVal destination As String)
        Try
            Dim currentDirectory As DirectoryInfo = New DirectoryInfo(source)


            For Each FileInfo As FileInfo In currentDirectory.GetFiles()

                Me.lblProgress.Text = "Copying: " + Path.Combine(destination, FileInfo.Name).ToString
                Application.DoEvents()

                If FileInfo.Name.ToUpper = "Web.config".ToUpper Then

                    If File.Exists(Path.Combine(destination, FileInfo.Name)) = False Then

                        FileInfo.CopyTo(Path.Combine(destination, FileInfo.Name), True)

                    End If

                Else

                    FileInfo.CopyTo(Path.Combine(destination, FileInfo.Name), True)

                End If

            Next

            For Each di As DirectoryInfo In currentDirectory.GetDirectories

                If di.Name.ToUpper = "TEMP".ToUpper OrElse di.Name.ToUpper = "CacheDependency".ToUpper Then

                    If Directory.Exists(Path.Combine(destination, di.Name)) = False Then

                        Directory.CreateDirectory(Path.Combine(destination, di.Name))

                    End If

                Else

                    Dim subDirectory As String = Path.Combine(destination, di.Name)
                    Directory.CreateDirectory(subDirectory)
                    CopyDirectoryWithGraphicsWV(di.FullName, subDirectory)

                End If

            Next

        Catch ex As Exception
        End Try
    End Function
    Public Function CopyDirectoryWithGraphicsCP(ByVal source As String, ByVal destination As String)
        Try
            Dim currentDirectory As DirectoryInfo = New DirectoryInfo(source)
            Dim file As FileInfo
            For Each file In currentDirectory.GetFiles()
                If file.Name.Contains("BillingApproval") = False And
                   file.Name.Contains("DashboardClient") = False And
                   file.Name.Contains("DashboardProduction") = False And
                   file.Name.Contains("DashboardRealization") = False And
                   file.Name.Contains("DashboardProject") = False And
                   file.Name.Contains("DashboardPrint") = False And
                   file.Name.Contains("EmployeeTimeForecast") = False And
                   file.Name.Contains("Estimating") = False And
                   file.Name.Contains("Expense") = False And
                   file.Name.Contains("Maintenance") = False And
                   file.Name.Contains("purchaseorder") = False And
                   file.Name.Contains("QuoteVsActual") = False And
                   file.Name.Contains("Reporting_Initial") = False And
                   file.Name.Contains("Reporting_Dynamic") = False And
                   file.Name.Contains("Reporting_Filter") = False And
                   file.Name.Contains("Reporting_Job") = False And
                   file.Name.Contains("Reporting_Save") = False And
                   file.Name.Contains("Reporting_User") = False And
                   file.Name.Contains("Reporting_View") = False And
                   file.Name.Contains("Resources_") = False And
                   file.Name.Contains("Timesheet") = False And
                   file.Name.Contains("VendorQuote") = False And
                   file.Name.Contains("Campaign") = False And
                   file.Name.Contains("DirectTime") = False And
                   file.Name.Contains("Security_") = False And
                   file.Name.Contains("ARStatements") = False And
                   file.Name.Contains("ClientAging") = False And
                   file.Name.Contains("CurrentRatio") = False And
                   file.Name.Contains("ARCashForecast") = False And
                   file.Name.Contains("AgencyGoals") = False And
                   file.Name.Contains("AgencyLinks") = False And
                   file.Name.Contains("BillableHoursGoal") = False And
                   file.Name.Contains("BillingTrends") = False And
                   file.Name.Contains("CashBalance") = False And
                   file.Name.Contains("EmployeeIndirectTime") = False And
                   file.Name.Contains("ExecutiveLinks") = False And
                   file.Name.Contains("DesktopInOutBoard") = False And
                   file.Name.Contains("JobStatistics") = False And
                   file.Name.Contains("QvA") = False And
                   file.Name.Contains("agencyGoals") = False And
                   file.Name.Contains("arcashforecast") = False And
                   file.Name.Contains("billing_trends") = False And
                   file.Name.Contains("clientaging") = False And
                   file.Name.Contains("currentratio") = False And
                   file.Name.Contains("Desktopinoutboard") = False And
                   file.Name.Contains("qva") = False And
                   file.Name.Contains("np_time_emp") = False And
                   file.Name.Contains("PurchaseOrder") = False And
                   file.Name.Contains("purchaseOrder") = False Then
                    Me.lblProgress.Text = "Copying: " + Path.Combine(destination, file.Name).ToString
                    Application.DoEvents()
                    file.CopyTo(Path.Combine(destination, file.Name), True)
                End If
            Next
            Dim di As DirectoryInfo
            For Each di In currentDirectory.GetDirectories()
                Dim subDirectory As String = Path.Combine(destination, di.Name)
                Directory.CreateDirectory(subDirectory)
                CopyDirectoryWithGraphicsCP(di.FullName, subDirectory)
            Next
        Catch ex As Exception
        End Try
    End Function
    Private Sub CopyFileToNewFilename(OriginalFilename As String, NewFilename As String)
        Try
            If System.IO.File.Exists(OriginalFilename) = True Then
                System.IO.File.Copy(OriginalFilename, NewFilename)
            End If
        Catch ex As Exception
            Throw New FileLoadException("Cannot Copy File.")
        End Try

    End Sub
    Private Function STOPIIS() As Boolean
        Try
            Dim strURL As String = Me.txtURL.Text
            Dim ProcessProperties As New ProcessStartInfo
            ProcessProperties.FileName = "NET"
            ProcessProperties.Arguments = "STOP W3SVC"
            ProcessProperties.WindowStyle = ProcessWindowStyle.Hidden
            Dim procDisco As Process = Process.Start(ProcessProperties)
            procDisco.WaitForExit()
            If procDisco.ExitCode = 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function STARTIIS()
        Try
            Dim strURL As String = Me.txtURL.Text
            Dim ProcessProperties As New ProcessStartInfo
            ProcessProperties.FileName = "NET"
            ProcessProperties.Arguments = "START W3SVC"
            ProcessProperties.WindowStyle = ProcessWindowStyle.Hidden
            Dim procDisco As Process = Process.Start(ProcessProperties)
            procDisco.WaitForExit()
            If procDisco.ExitCode = 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function SetACEPermissions(ByVal sPhysicalPath As String, ByVal strConnString As String) As Boolean
        Try
            Dim sUser As String
            Dim bReturn = False
            Dim aDirectories() As String = Split(System.Configuration.ConfigurationManager.AppSettings("ACEs"), ",")
            For i As Integer = 0 To aDirectories.GetUpperBound(0)
                Try
                    Dim oApplication As New cApplication(strConnString)
                    DebugPrint("SetACEPermissions on : " + aDirectories(i).ToString())
                    If CheckVersionOfIIS().StartsWith("7") Then
                        sUser = System.Configuration.ConfigurationManager.AppSettings("FileRightsUser2008".ToString())
                    Else
                        sUser = System.Environment.MachineName + "\" + System.Configuration.ConfigurationManager.AppSettings("FileRightsUser2003".ToString())
                    End If
                    oApplication.AddDirectorySecurity(sPhysicalPath + "\" + aDirectories(i), sUser, Security.AccessControl.FileSystemRights.FullControl, Security.AccessControl.AccessControlType.Allow)
                    bReturn = True
                Catch ex As Exception
                    DebugPrint("SetAcePermissions Error: " + ex.Message.ToString())
                    bReturn = False
                End Try
            Next
            Return bReturn
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function ChangePhysicalDir()
        Try
            If drpIISWebsite.SelectedValue <> String.Empty Then
                Me.txtPhysicalPath.Text = Me.drpIISWebsite.SelectedValue & "\" & Me.txtVirtualDirectory.Text
            End If
        Catch ex As Exception
        End Try
    End Function
    Private Sub LoadWebSitesCollection(ByVal pServer As String)
        Try
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
                        root1 = New DirectoryEntry(child.Path.ToString)
                        For Each child1 In root1.Children
                            If child1.SchemaClassName = "IIsWebVirtualDir" Then
                                oWebSite.PhysicalPath = child1.Properties("Path").Value
                            End If
                        Next
                        oWebSites.Add(oWebSite)
                    End If
                Next

            Catch ex As Exception

            End Try
        Catch ex As Exception
        End Try
    End Sub
    Public Shared Sub writeAppSettings(ByVal strPhysicalPathToWebConfig As String,
                                       ByVal strAuthentication As String,
                                       ByVal strReportServerPath As String,
                                       ByVal strSMTPAddress As String,
                                       ByVal strSMTPFromAddress As String,
                                       ByVal strSMTPUsername As String,
                                       ByVal strSMTPPassword As String,
                                       ByVal boolUpperCaseUser As Boolean,
                                       ByVal boolUpperCaseDatabase As Boolean,
                                       ByVal boolChooseServer As Boolean,
                                       ByVal boolSQLControledAdmin As Boolean,
                                       ByVal boolImpersonate As Boolean,
                                       ByVal boolIsOnWebFarm As Boolean,
                                       ByVal boolClearWhenAdminLogsOn As Boolean,
                                       ByVal strAdmDatabaseName As String,
                                       ByVal IntTimeoutMinutes As Integer,
                                       ByVal AlertRefresh As Double,
                                       ByVal strCustomErrorsMode As String,
                                       ByVal boolNTAuthIgnoreCase As Boolean,
                                       ByVal ChatServerName As String,
                                       ByVal ChatDatabaseName As String,
                                       ByVal ChatUserName As String,
                                       ByVal ChatPassword As String,
                                       ByVal boolRequireSSL As Boolean)

        Try

            Try

                Dim attribute As System.IO.FileAttributes = FileAttributes.Normal
                File.SetAttributes("strPhysicalPathToWebConfig", attribute)

            Catch eError As Exception

                'couldnt set file to normal

            End Try

            Dim myConfig As New XmlDocument
            Dim myAttribute As XmlAttribute

            myConfig.Load(strPhysicalPathToWebConfig)

            Dim nsmgr As XmlNamespaceManager = New XmlNamespaceManager(myConfig.NameTable)
            nsmgr.AddNamespace("web", "")

            Dim x As XmlNode
            Dim r As XmlElement = myConfig.DocumentElement

            'appSettings section
            myAttribute = r.SelectSingleNode("//web:add[@key='Authentication']/@value", nsmgr)
            If myAttribute IsNot Nothing Then myAttribute.Value = strAuthentication

            myAttribute = r.SelectSingleNode("//web:add[@key='UpperCaseUser']/@value", nsmgr)
            If myAttribute IsNot Nothing Then myAttribute.Value = boolUpperCaseUser.ToString.ToLower

            myAttribute = r.SelectSingleNode("//web:add[@key='UpperCaseDatabase']/@value", nsmgr)
            If myAttribute IsNot Nothing Then myAttribute.Value = boolUpperCaseDatabase.ToString.ToLower

            myAttribute = r.SelectSingleNode("//web:add[@key='ChooseServer']/@value", nsmgr)
            If isClientPortal = False Then

                If myAttribute IsNot Nothing Then myAttribute.Value = boolChooseServer.ToString.ToLower

            Else

                If myAttribute IsNot Nothing Then myAttribute.Value = "false"

            End If

            myAttribute = r.SelectSingleNode("//web:add[@key='SQLControledAdmin']/@value", nsmgr)
            If myAttribute IsNot Nothing Then myAttribute.Value = boolSQLControledAdmin.ToString.ToLower

            myAttribute = r.SelectSingleNode("//web:authentication/@mode", nsmgr)
            If myAttribute IsNot Nothing Then myAttribute.Value = strAuthentication

            myAttribute = r.SelectSingleNode("//web:identity/@impersonate", nsmgr)
            If myAttribute IsNot Nothing Then myAttribute.Value = boolImpersonate.ToString.ToLower

            'new keys for db and license maintenance
            myAttribute = r.SelectSingleNode("//web:add[@key='IsWebFarm']/@value", nsmgr)
            If myAttribute IsNot Nothing Then myAttribute.Value = "true"

            myAttribute = r.SelectSingleNode("//web:add[@key='NewRegistryStructure']/@value", nsmgr)
            If myAttribute IsNot Nothing Then myAttribute.Value = "true"

            myAttribute = r.SelectSingleNode("//web:add[@key='ClearWhenAdminLogsOn']/@value", nsmgr)
            If myAttribute IsNot Nothing Then myAttribute.Value = "false"

            myAttribute = r.SelectSingleNode("//web:add[@key='SQLAdminDBName']/@value", nsmgr)
            If myAttribute IsNot Nothing Then myAttribute.Value = strAdmDatabaseName

            myAttribute = r.SelectSingleNode("//web:add[@key='TimeOutUserInMinutes']/@value", nsmgr)
            If myAttribute IsNot Nothing Then myAttribute.Value = IntTimeoutMinutes.ToString

            myAttribute = r.SelectSingleNode("//web:sessionState/@timeout", nsmgr)
            If myAttribute IsNot Nothing Then myAttribute.Value = IntTimeoutMinutes.ToString

            myAttribute = r.SelectSingleNode("//web:compilation/@debug", nsmgr)
            If myAttribute IsNot Nothing Then myAttribute.Value = "false"

            myAttribute = r.SelectSingleNode("//web:customErrors/@mode", nsmgr)
            If myAttribute IsNot Nothing Then myAttribute.Value = "RemoteOnly"

            myAttribute = r.SelectSingleNode("//web:add[@key='AlertRefresh']/@value", nsmgr)
            If myAttribute IsNot Nothing Then myAttribute.Value = "0"

            myAttribute = r.SelectSingleNode("//web:customErrors/@mode", nsmgr)
            If myAttribute IsNot Nothing Then myAttribute.Value = strCustomErrorsMode

            myAttribute = r.SelectSingleNode("//web:add[@key='NTAuthIgnoreCase']/@value", nsmgr)
            If myAttribute IsNot Nothing Then myAttribute.Value = boolNTAuthIgnoreCase

            If isClientPortal = True AndAlso String.IsNullOrEmpty(ClientPortalKey) = False Then

                myAttribute = r.SelectSingleNode("//web:add[@key='VCtrl']/@value", nsmgr)
                If myAttribute IsNot Nothing Then myAttribute.Value = ClientPortalKey

            End If

            myAttribute = r.SelectSingleNode("//web:httpCookies/@requireSSL", nsmgr)
            If myAttribute IsNot Nothing Then

                myAttribute.Value = boolRequireSSL.ToString.ToLower

            End If

            myAttribute = r.SelectSingleNode("//web:authentication/forms/@requireSSL", nsmgr)
            If myAttribute IsNot Nothing Then

                myAttribute.Value = boolRequireSSL.ToString.ToLower

            End If

            myConfig.Save(strPhysicalPathToWebConfig)

            MsgBox("Settings saved to web.config!", MsgBoxStyle.OkOnly, "Configurator")

        Catch ex As Exception

            MsgBox("Error writing to web.config!" & vbCrLf & ex.Message.ToString)

        Finally

        End Try

    End Sub
    Private Sub HideTabPage(ByVal tp As TabPage)
        If tcWebvantageConfig.TabPages.Contains(tp) Then tcWebvantageConfig.TabPages.Remove(tp)
    End Sub
    Private Sub ShowTabPage(ByVal tp As TabPage)
        ShowTabPage(tp, tcWebvantageConfig.TabPages.Count)
    End Sub
    Private Sub ShowTabPage(ByVal tp As TabPage, ByVal index As Integer)
        If tcWebvantageConfig.TabPages.Contains(tp) Then Return
        InsertTabPage(tp, index)
    End Sub
    Private Sub InsertTabPage(ByVal [tabpage] As TabPage, ByVal [index] As Integer)
        If [index] < 0 Or [index] > tcWebvantageConfig.TabCount Then
            Throw New ArgumentException("Index out of Range.")
        End If
        tcWebvantageConfig.TabPages.Add([tabpage])
        If [index] < tcWebvantageConfig.TabCount - 1 Then
            Do While tcWebvantageConfig.TabPages.IndexOf([tabpage]) <> [index]
                SwapTabPages([tabpage], (tcWebvantageConfig.TabPages(tcWebvantageConfig.TabPages.IndexOf([tabpage]) - 1)))
            Loop
        End If
        tcWebvantageConfig.SelectedTab = [tabpage]
    End Sub
    Private Sub SwapTabPages(ByVal tp1 As TabPage, ByVal tp2 As TabPage)
        If tcWebvantageConfig.TabPages.Contains(tp1) = False Or tcWebvantageConfig.TabPages.Contains(tp2) = False Then
            Throw New ArgumentException("TabPages must be in the TabCotrols TabPageCollection.")
        End If
        Dim Index1 As Integer = tcWebvantageConfig.TabPages.IndexOf(tp1)
        Dim Index2 As Integer = tcWebvantageConfig.TabPages.IndexOf(tp2)
        tcWebvantageConfig.TabPages(Index1) = tp2
        tcWebvantageConfig.TabPages(Index2) = tp1

        'Uncomment the following section to overcome bugs in the Compact Framework
        'TabControl1.SelectedIndex = TabControl1.SelectedIndex 
        'Dim tp1Text, tp2Text As String
        'tp1Text = tp1.Text
        'tp2Text = tp2.Text
        'tp1.Text=tp2Text
        'tp2.Text=tp1Text

    End Sub
    Public Sub EntryEnable(ByVal bSwitch)
        If bSwitch = True Then
            Me.txtAdminUsername.Enabled = True
            Me.txtAdminPassword.Enabled = True
            Me.txtClientPortalUsername.Enabled = True
            Me.txtClientPortalPassword.Enabled = True
        Else
            Me.txtAdminUsername.Enabled = False
            Me.txtAdminPassword.Enabled = False
            Me.txtClientPortalUsername.Enabled = False
            Me.txtClientPortalPassword.Enabled = False

        End If

    End Sub
    Public Function is64Bit() As Boolean
        Dim breturn As Boolean = False
        If IntPtr.Size = 4 Then
            '32bit
            breturn = False
        Else
            '64bit
            breturn = True
        End If
        Return breturn
    End Function
    Private Function GetNode(ByVal sParent As String, ByVal sChild As String, ByVal parentCollection As TreeNodeCollection) As TreeNode
        Dim ret As TreeNode
        Dim child As TreeNode
        For Each child In parentCollection 'step through the parentcollection
            Try
                If child.Text = sParent Then
                    For Each Node As TreeNode In child.Nodes
                        If Node.Text = sChild Then
                            Return Node
                        End If
                    Next
                End If
            Catch x As Exception

            End Try
        Next
        Return ret
    End Function
    Sub EnsureNodeIsVisible(ByVal node As TreeNode)
        Dim tvw As TreeView = node.TreeView
        tvw.SelectedNode = node
        ' expand this node and all its ancestors
        Do Until node.Parent Is Nothing
            node = node.Parent
            node.Expand()
        Loop
        tvw.SelectedNode.EnsureVisible()
    End Sub
    Private Function RunDisco()
        Try
            Dim strURL As String = Me.txtURL.Text
            Dim ProcessProperties As New ProcessStartInfo
            ProcessProperties.FileName = ".\disco.exe"
            If Directory.Exists(Me.txtPhysicalPath.Text) Then
                'ProcessProperties.FileName = ".\disco.exe"
                ProcessProperties.Arguments = "/out:" + Me.txtPhysicalPath.Text + " " + strURL & "/GetRepositoryDoc.asmx"
            Else
                ProcessProperties.Arguments = strURL & "/GetRepositoryDoc.asmx"
            End If
            ProcessProperties.WindowStyle = ProcessWindowStyle.Hidden
            Dim procDisco As Process = Process.Start(ProcessProperties)
            procDisco.WaitForExit()
            If procDisco.ExitCode = 0 Then
                Return True
            Else
                Return False
            End If
        Catch x As Exception
            MessageBox.Show("Error: " + x.Message, "Error")
        End Try
    End Function
    Private Sub DeleteDirectory(ByVal DirectoryName As String)
        Try
            If System.IO.Directory.Exists(DirectoryName) = True Then
                Try
                    System.IO.Directory.Delete(DirectoryName, True)
                Catch ex As Exception
                End Try
                DeleteDirectory(DirectoryName)
            Else
                Exit Sub
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub SetMachineConfig()
        Dim WindowsPath As String = Environment.GetEnvironmentVariable("SystemRoot")
        Dim FileName As String = "\machine.config"
        Try
            Dim ThirtyTwoBitPath As String = "\Microsoft.NET\Framework\v4.0.30319\Config"
            If System.IO.Directory.Exists(WindowsPath & ThirtyTwoBitPath) = True Then
                Dim MachineConfig As XmlDocument = New XmlDocument()
                MachineConfig.Load(WindowsPath & ThirtyTwoBitPath & FileName)
                Dim nsmgr As XmlNamespaceManager = New XmlNamespaceManager(MachineConfig.NameTable)
                nsmgr.AddNamespace("web", "")
                Dim root As XmlElement = MachineConfig.DocumentElement
                Dim ProcessModel As XmlNode
                ProcessModel = root.SelectSingleNode("descendant::section[@name='processModel']/@allowDefinition", nsmgr)
                ProcessModel.Value = "MachineToApplication"
                MachineConfig.Save(WindowsPath & ThirtyTwoBitPath & FileName)
            End If
        Catch ex As Exception
            MsgBox("Could not set 32-bit machine.config")
        End Try
        Try
            Dim SixtyFourBitPath As String = "\Microsoft.NET\Framework64\v4.0.30319\Config"
            If System.IO.Directory.Exists(WindowsPath & SixtyFourBitPath) = True Then
                Dim MachineConfig As XmlDocument = New XmlDocument()
                MachineConfig.Load(WindowsPath & SixtyFourBitPath & FileName)
                Dim nsmgr As XmlNamespaceManager = New XmlNamespaceManager(MachineConfig.NameTable)
                nsmgr.AddNamespace("web", "")
                Dim root As XmlElement = MachineConfig.DocumentElement
                Dim ProcessModel As XmlNode
                ProcessModel = root.SelectSingleNode("descendant::section[@name='processModel']/@allowDefinition", nsmgr)
                ProcessModel.Value = "MachineToApplication"
                MachineConfig.Save(WindowsPath & SixtyFourBitPath & FileName)
            End If
        Catch ex As Exception
            MsgBox("Could not set 64-bit machine.config")
        End Try
    End Sub
    Private Function MachineConfigNeedsUpdating() As Boolean
        Try
            Dim ThirtyTwoBitOkay As Boolean = False
            Dim SixtyFourBitOkay As Boolean = False
            Dim WindowsPath As String = Environment.GetEnvironmentVariable("SystemRoot")
            Dim FileName As String = "\machine.config"
            Try
                Dim ThirtyTwoBitPath As String = "\Microsoft.NET\Framework\v4.0.30319\Config"
                If System.IO.Directory.Exists(WindowsPath & ThirtyTwoBitPath) = True Then
                    Dim MachineConfig As XmlDocument = New XmlDocument()
                    MachineConfig.Load(WindowsPath & ThirtyTwoBitPath & FileName)
                    Dim nsmgr As XmlNamespaceManager = New XmlNamespaceManager(MachineConfig.NameTable)
                    nsmgr.AddNamespace("web", "")
                    Dim root As XmlElement = MachineConfig.DocumentElement
                    Dim ProcessModel As XmlNode
                    ProcessModel = root.SelectSingleNode("descendant::section[@name='processModel']/@allowDefinition", nsmgr)
                    ThirtyTwoBitOkay = ProcessModel.Value = "MachineToApplication"
                End If
            Catch ex As Exception
            End Try
            Try
                Dim SixtyFourBitPath As String = "\Microsoft.NET\Framework64\v4.0.30319\Config"
                If System.IO.Directory.Exists(WindowsPath & SixtyFourBitPath) = True Then
                    Dim MachineConfig As XmlDocument = New XmlDocument()
                    MachineConfig.Load(WindowsPath & SixtyFourBitPath & FileName)
                    Dim nsmgr As XmlNamespaceManager = New XmlNamespaceManager(MachineConfig.NameTable)
                    nsmgr.AddNamespace("web", "")
                    Dim root As XmlElement = MachineConfig.DocumentElement
                    Dim ProcessModel As XmlNode
                    ProcessModel = root.SelectSingleNode("descendant::section[@name='processModel']/@allowDefinition", nsmgr)
                    SixtyFourBitOkay = ProcessModel.Value = "MachineToApplication"
                Else
                    SixtyFourBitOkay = True
                End If
            Catch ex As Exception
            End Try
            If ThirtyTwoBitOkay = False Or SixtyFourBitOkay = False Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return True
        End Try
    End Function

    Private Function LoadChatDatabaseInfoFromRegistry() As Boolean
        'For chat db info to registry
        Dim AdvantageServersKey As RegistryKey
        Dim ChatInfoFound As Boolean = False
        Dim RegistryKeyPath As String = "HKEY_LOCAL_MACHINE\Software\WOW6432Node\Advantage\Servers\STRAN-NB\SQL2014\ST670"
        Dim AdvantagePath As String = ""

        If is64Bit() = False Then

            AdvantagePath = "Software\Advantage\Servers"

        Else

            AdvantagePath = "Software\WOW6432Node\Advantage\Servers"

        End If

        AdvantageServersKey = My.Computer.Registry.LocalMachine.OpenSubKey(AdvantagePath)

        If AdvantageServersKey IsNot Nothing Then

            Dim Servers As String() = AdvantageServersKey.GetSubKeyNames()

            If Servers IsNot Nothing AndAlso Servers.Length > 0 Then

                For Each Server As String In Servers

                    If ChatInfoFound = True Then

                        Exit For

                    Else

                        Dim ServerRegKey As RegistryKey
                        ServerRegKey = AdvantageServersKey.OpenSubKey(Server)

                        Dim Databases As String() = ServerRegKey.GetSubKeyNames()

                        If Databases IsNot Nothing AndAlso Databases.Length > 0 Then

                            For Each Database As String In Databases

                                If Database.Contains(globals.ChatDBConstant) = True Then

                                    'Get Values
                                    Me.TextBoxChatServerName.Text = Server.Replace("#", "\")
                                    Me.TextBoxChatDatabaseName.Text = Database.Replace(globals.ChatDBConstant, "")
                                    Me.TextBoxChatUsername.Text = My.Computer.Registry.GetValue(String.Format("HKEY_LOCAL_MACHINE\{0}\{1}\{2}", AdvantagePath, Server, Database), "Username", Nothing)
                                    Me.TextBoxChatPassword.Text = My.Computer.Registry.GetValue(String.Format("HKEY_LOCAL_MACHINE\{0}\{1}\{2}", AdvantagePath, Server, Database), "Password", Nothing)
                                    Me.TextBoxChatPassword.Text = Decrypt(Me.TextBoxChatPassword.Text)

                                    ChatInfoFound = True
                                    Exit For

                                End If

                            Next

                        End If

                    End If

                Next

            End If

        End If

        Return ChatInfoFound

    End Function
    Private Sub SetSQlServerServiceBrokerForChatDB()

        Try

            Dim ChatServerName As String = String.Empty
            Dim ChatDatabaseName As String = String.Empty
            Dim ChatUsername As String = String.Empty
            Dim ChatPassword As String = String.Empty

            If String.IsNullOrEmpty(Me.TextBoxChatServerName.Text.Trim()) = False Then ChatServerName = Me.TextBoxChatServerName.Text.Trim()
            If String.IsNullOrEmpty(Me.TextBoxChatDatabaseName.Text.Trim()) = False Then ChatDatabaseName = Me.TextBoxChatDatabaseName.Text.Trim()
            If String.IsNullOrEmpty(Me.TextBoxChatUsername.Text.Trim()) = False Then ChatUsername = Me.TextBoxChatUsername.Text.Trim()
            If String.IsNullOrEmpty(Me.TextBoxChatPassword.Text.Trim()) = False Then ChatPassword = Me.TextBoxChatPassword.Text.Trim()

            If String.IsNullOrEmpty(ChatServerName) = False AndAlso String.IsNullOrEmpty(ChatDatabaseName) = False AndAlso
                String.IsNullOrEmpty(ChatUsername) = False AndAlso String.IsNullOrEmpty(ChatPassword) = False Then

                Dim ConnectionString As String = String.Format(_ConstConnectionStringBaseSQLAuthentication, ChatServerName, ChatDatabaseName, ChatUsername, ChatPassword, "Webvantage")

                Using MyConn As New SqlConnection(ConnectionString)

                    Dim MyCommand As New SqlCommand()
                    With MyCommand

                        .CommandType = CommandType.Text
                        .CommandText = String.Format("ALTER DATABASE {0} SET NEW_BROKER WITH ROLLBACK IMMEDIATE", ChatDatabaseName)
                        .Connection = MyConn

                    End With

                    MyConn.Open()

                    MyCommand.ExecuteNonQuery()

                    MsgBox("Service Broker enabled for chat database!", MsgBoxStyle.OkOnly, "Configurator")

                End Using

            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Function SaveChatDatabaseInfo() As Boolean

        Dim Success As Boolean = True

        Try

            Dim ChatServerName As String = String.Empty
            Dim ChatDatabaseName As String = String.Empty
            Dim ChatUsername As String = String.Empty
            Dim ChatPassword As String = String.Empty

            If String.IsNullOrEmpty(Me.TextBoxChatServerName.Text.Trim()) = False Then ChatServerName = Me.TextBoxChatServerName.Text.Trim()
            If String.IsNullOrEmpty(Me.TextBoxChatDatabaseName.Text.Trim()) = False Then ChatDatabaseName = Me.TextBoxChatDatabaseName.Text.Trim()
            If String.IsNullOrEmpty(Me.TextBoxChatUsername.Text.Trim()) = False Then ChatUsername = Me.TextBoxChatUsername.Text.Trim()
            If String.IsNullOrEmpty(Me.TextBoxChatPassword.Text.Trim()) = False Then ChatPassword = Me.TextBoxChatPassword.Text.Trim()

            If String.IsNullOrEmpty(ChatServerName) = False AndAlso String.IsNullOrEmpty(ChatDatabaseName) = False AndAlso
                String.IsNullOrEmpty(ChatUsername) = False AndAlso String.IsNullOrEmpty(ChatPassword) = False Then

                'test connection
                Dim Connected As Boolean = True
                Dim TestConn As String = String.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3};APP=Chat", ChatServerName, ChatDatabaseName, ChatUsername, ChatPassword)

                Try

                    Dim oSql As SqlHelper
                    If CType(oSql.ExecuteScalar(TestConn, CommandType.Text, String.Format("SELECT COUNT(name) FROM master.dbo.sysdatabases WHERE name = '{0}';", ChatDatabaseName)), Integer) = 0 Then

                        Connected = False

                    End If

                Catch ex As Exception
                    Connected = False
                End Try

                If Connected = True Then

                    RemoveOtherChatDBFromRegistry(Me.TextBoxChatDatabaseName.Text.Trim())

                    ChatServerName = ChatServerName.Replace("\", "#")
                    ChatDatabaseName = ChatDatabaseName.Replace("\", "#")

                    ChatDatabaseName = globals.ChatDBConstant & ChatDatabaseName

                    ChatPassword = Encrypt(ChatPassword)

                    Try

                        If is64Bit() = True Then

                            If IsNothing(My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Advantage\Servers\" + ChatServerName + "\" + ChatDatabaseName, "Username", Nothing)) Then

                                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Advantage\Servers\" + ChatServerName + "\" + ChatDatabaseName, "Username", ChatUsername)
                                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Advantage\Servers\" + ChatServerName + "\" + ChatDatabaseName, "Password", ChatPassword)

                            End If

                        Else

                            If IsNothing(My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Advantage\Servers\" + ChatServerName + "\" + ChatDatabaseName, "Username", Nothing)) Then

                                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Advantage\Servers\" + ChatServerName + "\" + ChatDatabaseName, "Username", ChatUsername)
                                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Advantage\Servers\" + ChatServerName + "\" + ChatDatabaseName, "Password", ChatPassword)

                            End If

                        End If

                    Catch ex As Exception
                        Success = False
                    End Try

                Else

                    MsgBox("Cannot connect to chat database.  Please check your settings.", MsgBoxStyle.OkOnly, "Configurator")
                    Success = False

                End If

            Else

                Success = False
                RemoveOtherChatDBFromRegistry("")

            End If

        Catch ex As Exception
            MsgBox("Chat database info failed to save!" & Environment.NewLine & ex.Message.ToString(), MsgBoxStyle.OkOnly, "Configurator")
            Success = False
        End Try

        If Success = True Then

            MsgBox("Chat database info saved to registry!", MsgBoxStyle.OkOnly, "Configurator")
            SetSQlServerServiceBrokerForChatDB()

        End If

        Return Success

    End Function
    Private Sub RemoveOtherChatDBFromRegistry(ByVal ChatDatabaseName As String)
        'For chat db info to registry
        Dim AdvantageServersKey As RegistryKey
        Dim RegistryKeyPath As String = "HKEY_LOCAL_MACHINE\Software\WOW6432Node\Advantage\Servers\STRAN-NB\SQL2014\ST670"
        Dim AdvantagePath As String = ""

        If is64Bit() = False Then

            AdvantagePath = "Software\Advantage\Servers"

        Else

            AdvantagePath = "Software\WOW6432Node\Advantage\Servers"

        End If

        AdvantageServersKey = My.Computer.Registry.LocalMachine.OpenSubKey(AdvantagePath)

        If AdvantageServersKey IsNot Nothing Then

            Dim Servers As String() = AdvantageServersKey.GetSubKeyNames()

            If Servers IsNot Nothing AndAlso Servers.Length > 0 Then

                For Each Server As String In Servers

                    Dim ThisServerName As String = Server.Replace("#", "\")
                    Dim ServerRegKey As RegistryKey
                    ServerRegKey = AdvantageServersKey.OpenSubKey(Server)

                    Dim Databases As String() = ServerRegKey.GetSubKeyNames()

                    If Databases IsNot Nothing AndAlso Databases.Length > 0 Then

                        For Each Database As String In Databases

                            If Database.Contains(globals.ChatDBConstant) = True Then

                                Dim ThisDatabaseName As String = Database.Replace(globals.ChatDBConstant, "")

                                If ThisDatabaseName <> ChatDatabaseName Then

                                    Dim RegistryKeyToDelete As Microsoft.Win32.RegistryKey
                                    RegistryKeyToDelete = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(String.Format("{0}\{1}\", AdvantagePath, Server), True)
                                    RegistryKeyToDelete.DeleteSubKeyTree(Database)
                                    RegistryKeyToDelete.Close()

                                End If

                            End If

                        Next

                    End If

                Next

            End If

        End If

    End Sub

#Region " Connection Tab"

    Public Sub LoadConnectionDatabaseProfiles()

        'objects
        Dim ServerNames As Generic.List(Of String) = Nothing
        Dim ServerTreeNode As Windows.Forms.TreeNode = Nothing
        Dim DatabaseTreeNode As Windows.Forms.TreeNode = Nothing

        _ConnectionDatabaseProfiles = Database.LoadConnectionDatabaseProfiles

        If _ConnectionDatabaseProfiles IsNot Nothing AndAlso _ConnectionDatabaseProfiles.Count > 0 Then

            ServerNames = _ConnectionDatabaseProfiles.Select(Function(Entity) Entity.ServerName).Distinct.ToList

        End If

        If ServerNames IsNot Nothing AndAlso ServerNames.Count > 0 Then

            For Each ServerName As String In ServerNames

                ServerTreeNode = TreeViewConnections.Nodes.Add(ServerName)

                ServerTreeNode.ImageIndex = 0
                ServerTreeNode.SelectedImageIndex = 0

                For Each ConnectionDatabaseProfile As Database.ConnectionDatabaseProfile In _ConnectionDatabaseProfiles.Where(Function(Entity) Entity.ServerName = ServerName).OrderBy(Function(Entity) Entity.DatabaseName).ToList

                    DatabaseTreeNode = ServerTreeNode.Nodes.Add(ConnectionDatabaseProfile.DatabaseName)

                    DatabaseTreeNode.ImageIndex = 1
                    DatabaseTreeNode.SelectedImageIndex = 1

                Next

            Next

        End If

        TreeViewConnections.ExpandAll()
        TreeViewConnections.ShowPlusMinus = False

        If TreeViewConnections.Nodes.Count > 0 Then

            TreeViewConnections.SelectedNode = TreeViewConnections.Nodes(0)

        End If

    End Sub
    Private Sub TreeViewConnections_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeViewConnections.AfterSelect

        Dim ServerName As String = String.Empty
        Dim DatabaseName As String = String.Empty
        Dim ConnectionDatabaseProfile As Database.ConnectionDatabaseProfile = Nothing

        If e.Node IsNot Nothing Then

            ButtonDelete.Enabled = True

            If e.Node.Level = 0 Then

                ButtonAddDatabase.Enabled = True

                ButtonConnectionSave.Enabled = False
                ButtonTest.Enabled = False

                TextBoxUserName.Text = String.Empty
                TextBoxPassword.Text = String.Empty

                TextBoxUserName.Enabled = False
                TextBoxPassword.Enabled = False

            Else

                ButtonAddDatabase.Enabled = False

                ButtonConnectionSave.Enabled = True
                ButtonTest.Enabled = True

                TextBoxUserName.Enabled = True
                TextBoxPassword.Enabled = True

                DatabaseName = e.Node.Text
                ServerName = e.Node.Parent.Text

                Try

                    ConnectionDatabaseProfile = _ConnectionDatabaseProfiles.SingleOrDefault(Function(Entity) Entity.ServerName = ServerName AndAlso Entity.DatabaseName = DatabaseName)

                Catch ex As Exception
                    ConnectionDatabaseProfile = Nothing
                End Try

                If ConnectionDatabaseProfile IsNot Nothing Then

                    TextBoxUserName.Text = ConnectionDatabaseProfile.UserName
                    TextBoxPassword.Text = ConnectionDatabaseProfile.Password

                Else

                    TextBoxUserName.Text = String.Empty
                    TextBoxPassword.Text = String.Empty

                End If

            End If

        Else

            ButtonDelete.Enabled = False

            ButtonAddDatabase.Enabled = False

            ButtonConnectionSave.Enabled = False
            ButtonTest.Enabled = False

            TextBoxUserName.Text = String.Empty
            TextBoxPassword.Text = String.Empty

            TextBoxUserName.Enabled = False
            TextBoxPassword.Enabled = False

        End If

    End Sub
    Private Sub ButtonAddServer_Click(sender As Object, e As EventArgs) Handles ButtonAddServer.Click

        Dim ServerName As String = String.Empty
        Dim ServerTreeNode As Windows.Forms.TreeNode = Nothing

        ServerName = InputBox("Enter Server Name")

        If String.IsNullOrWhiteSpace(ServerName) = False Then

            ServerTreeNode = TreeViewConnections.Nodes.Add(ServerName)

            ServerTreeNode.ImageIndex = 0
            ServerTreeNode.SelectedImageIndex = 0

            TreeViewConnections.SelectedNode = ServerTreeNode

        End If

    End Sub
    Private Sub ButtonAddDatabase_Click(sender As Object, e As EventArgs) Handles ButtonAddDatabase.Click

        Dim DatabaseName As String = String.Empty
        Dim DatabaseTreeNode As Windows.Forms.TreeNode = Nothing
        Dim HasUniqueDatabaseName As Boolean = True

        If TreeViewConnections.SelectedNode IsNot Nothing AndAlso TreeViewConnections.SelectedNode.Level = 0 Then

            DatabaseName = InputBox("Enter Database Name")

            If String.IsNullOrWhiteSpace(DatabaseName) = False Then

                For Each Node As TreeNode In TreeViewConnections.Nodes.OfType(Of TreeNode).ToList

                    If Node.Level = 0 Then

                        For Each SubNode As TreeNode In Node.Nodes

                            If SubNode.Text.ToUpper = DatabaseName.ToUpper Then

                                HasUniqueDatabaseName = False
                                Exit For

                            End If

                        Next

                        If HasUniqueDatabaseName = False Then

                            Exit For

                        End If

                    End If

                Next

                If HasUniqueDatabaseName Then

                    DatabaseTreeNode = TreeViewConnections.SelectedNode.Nodes.Add(DatabaseName)

                    DatabaseTreeNode.ImageIndex = 1
                    DatabaseTreeNode.SelectedImageIndex = 1

                    TreeViewConnections.SelectedNode = DatabaseTreeNode

                Else

                    MessageBox.Show("Please enter an unique database name.")

                End If

            End If

        End If

    End Sub
    Private Sub ButtonDelete_Click(sender As Object, e As EventArgs) Handles ButtonDelete.Click

        Dim ServerName As String = String.Empty
        Dim DatabaseName As String = String.Empty
        Dim ConnectionDatabaseProfiles As Generic.List(Of Database.ConnectionDatabaseProfile) = Nothing

        If TreeViewConnections.SelectedNode IsNot Nothing Then

            If TreeViewConnections.SelectedNode.Level = 0 Then

                ServerName = TreeViewConnections.SelectedNode.Text

                ConnectionDatabaseProfiles = _ConnectionDatabaseProfiles.Where(Function(Entity) Entity.ServerName = ServerName).ToList

            ElseIf TreeViewConnections.SelectedNode.Level = 1 Then

                DatabaseName = TreeViewConnections.SelectedNode.Text
                ServerName = TreeViewConnections.SelectedNode.Parent.Text

                ConnectionDatabaseProfiles = _ConnectionDatabaseProfiles.Where(Function(Entity) Entity.ServerName = ServerName AndAlso Entity.DatabaseName = DatabaseName).ToList

            End If

            If ConnectionDatabaseProfiles IsNot Nothing AndAlso ConnectionDatabaseProfiles.Count > 0 Then

                For Each ConnectionDatabaseProfile As Database.ConnectionDatabaseProfile In ConnectionDatabaseProfiles

                    Database.DeleteConnectionDatabaseProfile(ConnectionDatabaseProfile.DatabaseName)
                    _ConnectionDatabaseProfiles.Remove(ConnectionDatabaseProfile)

                Next

            End If

            If TreeViewConnections.SelectedNode.Level = 0 Then

                TreeViewConnections.Nodes.Remove(TreeViewConnections.SelectedNode)

            ElseIf TreeViewConnections.SelectedNode.Level = 1 Then

                TreeViewConnections.SelectedNode.Parent.Nodes.Remove(TreeViewConnections.SelectedNode)

            End If

            If TreeViewConnections.Nodes.Count > 0 Then

                TreeViewConnections.SelectedNode = TreeViewConnections.Nodes(0)

            End If

        End If

    End Sub
    Private Sub ButtonConnectionSave_Click(sender As Object, e As EventArgs) Handles ButtonConnectionSave.Click

        Dim ServerName As String = String.Empty
        Dim DatabaseName As String = String.Empty
        Dim ConnectionDatabaseProfile As Database.ConnectionDatabaseProfile = Nothing

        If Database.ContainsIllegalCharacters(Me.TextBoxPassword.Text.Trim) = True Then

            MsgBox("Password cannot include characters:  ?, #, /, or & .", MsgBoxStyle.Critical, "Save Connection")
            Me.TextBoxPassword.Focus()
            Exit Sub

        Else

            If TreeViewConnections.SelectedNode IsNot Nothing AndAlso TreeViewConnections.SelectedNode.Level = 1 Then

                DatabaseName = TreeViewConnections.SelectedNode.Text
                ServerName = TreeViewConnections.SelectedNode.Parent.Text

                ConnectionDatabaseProfile = _ConnectionDatabaseProfiles.SingleOrDefault(Function(Entity) Entity.ServerName = ServerName AndAlso Entity.DatabaseName = DatabaseName)

                If ConnectionDatabaseProfile IsNot Nothing Then


                    ConnectionDatabaseProfile.UserName = TextBoxUserName.Text
                    ConnectionDatabaseProfile.Password = TextBoxPassword.Text

                    Database.SaveConnectionDatabaseProfile(ConnectionDatabaseProfile, True)

                Else

                    ConnectionDatabaseProfile = New Database.ConnectionDatabaseProfile

                    ConnectionDatabaseProfile.ServerName = ServerName.Replace("#", "\")
                    ConnectionDatabaseProfile.DatabaseName = DatabaseName
                    ConnectionDatabaseProfile.UserName = TextBoxUserName.Text
                    ConnectionDatabaseProfile.Password = TextBoxPassword.Text

                    Database.SaveConnectionDatabaseProfile(ConnectionDatabaseProfile, False)

                    _ConnectionDatabaseProfiles.Add(ConnectionDatabaseProfile)

                End If

            End If

        End If

    End Sub
    Private Sub ButtonTest_Click(sender As Object, e As EventArgs) Handles ButtonTest.Click

        Dim ServerName As String = String.Empty
        Dim DatabaseName As String = String.Empty
        Dim ConnectionDatabaseProfile As Database.ConnectionDatabaseProfile = Nothing
        Dim CopyConnectionDatabaseProfile As Database.ConnectionDatabaseProfile = Nothing

        If Database.ContainsIllegalCharacters(Me.TextBoxPassword.Text.Trim) = True Then

            MsgBox("Password cannot include characters:  ?, #, /, or & .", MsgBoxStyle.Critical, "Test Connection")
            Me.TextBoxPassword.Focus()
            Exit Sub

        Else

            If TreeViewConnections.SelectedNode IsNot Nothing AndAlso TreeViewConnections.SelectedNode.Level = 1 Then

                DatabaseName = TreeViewConnections.SelectedNode.Text
                ServerName = TreeViewConnections.SelectedNode.Parent.Text

                ConnectionDatabaseProfile = _ConnectionDatabaseProfiles.SingleOrDefault(Function(Entity) Entity.ServerName = ServerName AndAlso Entity.DatabaseName = DatabaseName)

                If ConnectionDatabaseProfile IsNot Nothing Then

                    CopyConnectionDatabaseProfile = ConnectionDatabaseProfile.Copy

                    CopyConnectionDatabaseProfile.UserName = TextBoxUserName.Text
                    CopyConnectionDatabaseProfile.Password = TextBoxPassword.Text

                Else

                    CopyConnectionDatabaseProfile = New Database.ConnectionDatabaseProfile

                    CopyConnectionDatabaseProfile.ServerName = ServerName.Replace("#", "\")
                    CopyConnectionDatabaseProfile.DatabaseName = DatabaseName
                    CopyConnectionDatabaseProfile.UserName = TextBoxUserName.Text
                    CopyConnectionDatabaseProfile.Password = TextBoxPassword.Text

                End If

                If Database.TestConnectionString(CopyConnectionDatabaseProfile.GetConnectionString) Then

                    MessageBox.Show("Connection is valid.")

                Else


                    MessageBox.Show("Connection is not valid!")

                End If

            End If

        End If

    End Sub

    Private Sub ButtonProofingEventLog_Click(sender As Object, e As EventArgs) Handles ButtonProofingEventLog.Click

        Try

            System.Diagnostics.EventLog.CreateEventSource(_ProofingEventSource, _ProofingEventLogName)
            ButtonProofingEventLog.Enabled = False

        Catch ex As Exception
            MsgBox("Error creating Proofing Event Log:" & Environment.NewLine & ex.Message.ToString())
        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        'Dim sb As New System.Text.StringBuilder
        'Dim proc As New Process
        'proc.StartInfo.FileName = "cmd.exe"
        'proc.StartInfo.Arguments = "/k ipconfig"
        'proc.StartInfo.CreateNoWindow = True
        'proc.StartInfo.UseShellExecute = False
        'proc.StartInfo.RedirectStandardOutput = True
        'proc.Start()
        'proc.WaitForExit()

        'Dim output() As String = proc.StandardOutput.ReadToEnd.Split(CChar(vbLf))

        'For Each ln As String In output

        '    sb.AppendLine(ln & vbNewLine)

        'Next

        'MsgBox(sb.ToString())
        'Get45or451FromRegistry()
        If ListNETVersions().Contains("5.0.9") = False Then

            MsgBox("Need to install")

        Else

            MsgBox("Already exists")

        End If
    End Sub

    Const FrameworkKey As String = "SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\"
    Const FrameworkSubKey As String = "SOFTWARE\dotnet\Setup\InstalledVersions"
    Const HostSubKey As String = "sharedhost"

    Private Function ListNETVersions() As String

        Dim sb As New System.Text.StringBuilder

        Using FrameworkKey As RegistryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(FrameworkSubKey)

            If FrameworkKey IsNot Nothing AndAlso FrameworkKey.SubKeyCount > 0 Then

                For Each platformKey In FrameworkKey.GetSubKeyNames

                    Using platform = FrameworkKey.OpenSubKey(platformKey)

                        If platform.SubKeyCount > 0 Then

                            Dim sharedHost = platform.OpenSubKey(HostSubKey)

                            If sharedHost IsNot Nothing Then

                                For Each version In sharedHost.GetValueNames()

                                    sb.AppendFormat("{0,-8}: {1}", version, sharedHost.GetValue(version))
                                    sb.Append(vbCrLf)

                                Next

                            End If

                        End If

                    End Using

                Next

            End If

            Return sb.ToString()

        End Using

    End Function

#End Region

End Class
