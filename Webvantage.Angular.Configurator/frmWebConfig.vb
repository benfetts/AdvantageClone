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
Imports Microsoft.Web.Administration

Public Class frmWebConfig
    Inherits System.Windows.Forms.Form

#Region " Constants "

    Public Const TempFolder As String = "C:\ADV_TMP"
    Public Const RegistryPath As String = "HKEY_LOCAL_MACHINE\SOFTWARE\Advantage\Connections\"
    Public Const RegistryPathWOW6432 As String = "HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Advantage\Connections\"
    Public Const BaseNode As String = "Connections" 'Connections or Servers (change above too, I'm lazy)
#End Region

#Region " Enum "

    Public Enum App

        Webvantage
        ClientPortal
        MobileDataservices

    End Enum

#End Region

#Region " Variables "

    Dim bnLoad As Boolean
    Dim oWebSite As nsWebsites.Website
    Dim oWebSites As nsWebsites.WebSites = New nsWebsites.WebSites
    Dim iParentID As Integer = 0
    Private Const MAX_CTL As Integer = 3

    Friend WithEvents Label16 As System.Windows.Forms.Label
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
    Friend WithEvents TreeViewImageList As System.Windows.Forms.ImageList
    Friend WithEvents Button1 As System.Windows.Forms.Button

    Private m_FilterSelected(MAX_CTL) As Integer
    Private GlobalConnString As String = ""
    'Public Shared isClientPortal As Boolean = False
    Friend WithEvents ButtonExit As System.Windows.Forms.Button
    Friend WithEvents ButtonBack As System.Windows.Forms.Button
    Friend WithEvents XtraTabControlMain As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPageApplication As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPageRegistry As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPageDatabase As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPageWebServices As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPageSMTP As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents txtSessionTimeout As System.Windows.Forms.TextBox
    Friend WithEvents LabelIISTimeOut As System.Windows.Forms.Label
    Friend WithEvents chkVirtualDirectory As System.Windows.Forms.CheckBox
    Friend WithEvents txtPhysicalPath As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtVirtualDirectory As System.Windows.Forms.TextBox
    Friend WithEvents lblWebconfig As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtwebconfig1 As System.Windows.Forms.TextBox
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents btnChangeSMTPSettings As System.Windows.Forms.Button
    Friend WithEvents lblRegistryWarn As System.Windows.Forms.Label
    Friend WithEvents txtRegistryDatabase As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtRegistryServer As System.Windows.Forms.TextBox
    Friend WithEvents btnDeleteReg As System.Windows.Forms.Button
    Friend WithEvents btnAddReg As System.Windows.Forms.Button
    Friend WithEvents btnSaveRegistry As System.Windows.Forms.Button
    Friend WithEvents txtAdminPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtAdminUsername As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents tvRegistry As System.Windows.Forms.TreeView
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cboDatabaseScript As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnRun As System.Windows.Forms.Button
    Friend WithEvents btnTestConnection As System.Windows.Forms.Button
    Friend WithEvents lblDatabaseVersion As System.Windows.Forms.Label
    Friend WithEvents txtDatabaseName As System.Windows.Forms.TextBox
    Friend WithEvents lblDatabaseName As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rbSSA As System.Windows.Forms.RadioButton
    Friend WithEvents rbWIA As System.Windows.Forms.RadioButton
    Friend WithEvents lblconnectSQL As System.Windows.Forms.Label
    Friend WithEvents txtSQLServerName As System.Windows.Forms.TextBox
    Friend WithEvents lblSQLServerName As System.Windows.Forms.Label
    Friend WithEvents lblWarning As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents btnCreate As System.Windows.Forms.Button
    Friend WithEvents txtURL As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents btnSmtpInstall As System.Windows.Forms.Button
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents GroupControlGeneralApplicationSettings As DevExpress.XtraEditors.GroupControl
    Friend WithEvents cboCustomErrors As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents TxtTimeOutMinutes As System.Windows.Forms.TextBox
    Friend WithEvents LabelTimeOut As System.Windows.Forms.Label
    Friend WithEvents chkUpperCaseDatabase As System.Windows.Forms.CheckBox
    Friend WithEvents chkSQLControledAdmin As System.Windows.Forms.CheckBox
    Friend WithEvents chkUpperCaseUser As System.Windows.Forms.CheckBox
    Friend WithEvents chkChooseServer As System.Windows.Forms.CheckBox
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControlAlertRefreshRate As DevExpress.XtraEditors.GroupControl
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TxtAlertRefresh As System.Windows.Forms.TextBox
    Friend WithEvents GroupControlAuthentication As DevExpress.XtraEditors.GroupControl
    Friend WithEvents Chk_NTAuth_UserCode_IgnoreCase As System.Windows.Forms.CheckBox
    Friend WithEvents rbSqlAuthentication As System.Windows.Forms.RadioButton
    Friend WithEvents rbNTAuthentication As System.Windows.Forms.RadioButton
    Friend WithEvents GroupControlVirtualDirectory As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControlIISWebSites As DevExpress.XtraEditors.GroupControl
    Friend WithEvents btnLoadWebsites As System.Windows.Forms.Button
    Friend WithEvents drpIISWebsite As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtIISServer As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents XtraTabPageIIS As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GroupControlTools As DevExpress.XtraEditors.GroupControl
    Friend WithEvents ButtonSetMachineConfig As System.Windows.Forms.Button
    Friend WithEvents ButtonDeleteTempFiles As System.Windows.Forms.Button
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents lblProgress As System.Windows.Forms.Label
    Friend WithEvents PBarIIS As System.Windows.Forms.ProgressBar
    Friend WithEvents btnSetupVirtDir As System.Windows.Forms.Button
    Friend WithEvents GroupControlRegistryEditor As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControlConnectToDatabase As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControlSelectAuthentication As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControlSelectDatabaseServer As DevExpress.XtraEditors.GroupControl

    Private _EventLogName As String = "Webvantage"
    Private _EventSource As String = "Application_Error Event"
    Private _ProofingEventLogName As String = "Adv Proofing"
    Friend WithEvents XtraTabPageSystem As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents ButtonInstallNETCoreRuntime As Button
    Friend WithEvents ButtonCreateProofingEventLog As Button
    Friend WithEvents LabelNETVersion As Label
    Private _ProofingEventSource As String = "Adv Proofing Event"

#End Region

#Region " Properties "

    Public Property SelectedApplication As App = App.Webvantage

#End Region

#Region " Methods "

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

        Dim strDirectory = Windows.Forms.Application.StartupPath & "\Scripts\"

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
    Friend WithEvents btnHelp As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents dlgFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtwebconfig As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtemailpassword As System.Windows.Forms.TextBox
    Friend WithEvents txtEmailUserName As System.Windows.Forms.TextBox
    Friend WithEvents txtEmailFromAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtSMTPAddress As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmWebConfig))
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Home")
        Me.btnHelp = New System.Windows.Forms.Button()
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
        Me.TreeViewImageList = New System.Windows.Forms.ImageList(Me.components)
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
        Me.ButtonBack = New System.Windows.Forms.Button()
        Me.ButtonExit = New System.Windows.Forms.Button()
        Me.XtraTabControlMain = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPageIIS = New DevExpress.XtraTab.XtraTabPage()
        Me.GroupControlVirtualDirectory = New DevExpress.XtraEditors.GroupControl()
        Me.txtSessionTimeout = New System.Windows.Forms.TextBox()
        Me.chkVirtualDirectory = New System.Windows.Forms.CheckBox()
        Me.LabelIISTimeOut = New System.Windows.Forms.Label()
        Me.lblWebconfig = New System.Windows.Forms.Label()
        Me.txtVirtualDirectory = New System.Windows.Forms.TextBox()
        Me.txtPhysicalPath = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupControlTools = New DevExpress.XtraEditors.GroupControl()
        Me.ButtonSetMachineConfig = New System.Windows.Forms.Button()
        Me.ButtonDeleteTempFiles = New System.Windows.Forms.Button()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.GroupControlIISWebSites = New DevExpress.XtraEditors.GroupControl()
        Me.btnLoadWebsites = New System.Windows.Forms.Button()
        Me.drpIISWebsite = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtIISServer = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblProgress = New System.Windows.Forms.Label()
        Me.PBarIIS = New System.Windows.Forms.ProgressBar()
        Me.btnSetupVirtDir = New System.Windows.Forms.Button()
        Me.XtraTabPageApplication = New DevExpress.XtraTab.XtraTabPage()
        Me.GroupControlGeneralApplicationSettings = New DevExpress.XtraEditors.GroupControl()
        Me.cboCustomErrors = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TxtTimeOutMinutes = New System.Windows.Forms.TextBox()
        Me.LabelTimeOut = New System.Windows.Forms.Label()
        Me.chkUpperCaseDatabase = New System.Windows.Forms.CheckBox()
        Me.chkSQLControledAdmin = New System.Windows.Forms.CheckBox()
        Me.chkUpperCaseUser = New System.Windows.Forms.CheckBox()
        Me.chkChooseServer = New System.Windows.Forms.CheckBox()
        Me.GroupControlAuthentication = New DevExpress.XtraEditors.GroupControl()
        Me.Chk_NTAuth_UserCode_IgnoreCase = New System.Windows.Forms.CheckBox()
        Me.rbSqlAuthentication = New System.Windows.Forms.RadioButton()
        Me.rbNTAuthentication = New System.Windows.Forms.RadioButton()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtwebconfig1 = New System.Windows.Forms.TextBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.btnChangeSMTPSettings = New System.Windows.Forms.Button()
        Me.XtraTabPageRegistry = New DevExpress.XtraTab.XtraTabPage()
        Me.GroupControlRegistryEditor = New DevExpress.XtraEditors.GroupControl()
        Me.txtRegistryDatabase = New System.Windows.Forms.TextBox()
        Me.tvRegistry = New System.Windows.Forms.TreeView()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtAdminUsername = New System.Windows.Forms.TextBox()
        Me.txtRegistryServer = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.btnDeleteReg = New System.Windows.Forms.Button()
        Me.txtAdminPassword = New System.Windows.Forms.TextBox()
        Me.btnAddReg = New System.Windows.Forms.Button()
        Me.btnSaveRegistry = New System.Windows.Forms.Button()
        Me.lblRegistryWarn = New System.Windows.Forms.Label()
        Me.XtraTabPageDatabase = New DevExpress.XtraTab.XtraTabPage()
        Me.GroupControlConnectToDatabase = New DevExpress.XtraEditors.GroupControl()
        Me.cboDatabaseScript = New System.Windows.Forms.ComboBox()
        Me.lblDatabaseName = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtDatabaseName = New System.Windows.Forms.TextBox()
        Me.btnRun = New System.Windows.Forms.Button()
        Me.lblDatabaseVersion = New System.Windows.Forms.Label()
        Me.btnTestConnection = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GroupControlSelectAuthentication = New DevExpress.XtraEditors.GroupControl()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.rbWIA = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.rbSSA = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblconnectSQL = New System.Windows.Forms.Label()
        Me.GroupControlSelectDatabaseServer = New DevExpress.XtraEditors.GroupControl()
        Me.txtSQLServerName = New System.Windows.Forms.TextBox()
        Me.lblSQLServerName = New System.Windows.Forms.Label()
        Me.XtraTabPageWebServices = New DevExpress.XtraTab.XtraTabPage()
        Me.lblWarning = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.btnCreate = New System.Windows.Forms.Button()
        Me.txtURL = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.XtraTabPageSMTP = New DevExpress.XtraTab.XtraTabPage()
        Me.btnSmtpInstall = New System.Windows.Forms.Button()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.XtraTabPageSystem = New DevExpress.XtraTab.XtraTabPage()
        Me.ButtonInstallNETCoreRuntime = New System.Windows.Forms.Button()
        Me.ButtonCreateProofingEventLog = New System.Windows.Forms.Button()
        Me.GroupControlAlertRefreshRate = New DevExpress.XtraEditors.GroupControl()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TxtAlertRefresh = New System.Windows.Forms.TextBox()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.LabelNETVersion = New System.Windows.Forms.Label()
        Me.gbWebFarm.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.epEmailPassword, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.epSMTPAddress, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.epEmailAddress, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.XtraTabControlMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControlMain.SuspendLayout()
        Me.XtraTabPageIIS.SuspendLayout()
        CType(Me.GroupControlVirtualDirectory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlVirtualDirectory.SuspendLayout()
        CType(Me.GroupControlTools, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlTools.SuspendLayout()
        CType(Me.GroupControlIISWebSites, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlIISWebSites.SuspendLayout()
        Me.XtraTabPageApplication.SuspendLayout()
        CType(Me.GroupControlGeneralApplicationSettings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlGeneralApplicationSettings.SuspendLayout()
        CType(Me.GroupControlAuthentication, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlAuthentication.SuspendLayout()
        Me.XtraTabPageRegistry.SuspendLayout()
        CType(Me.GroupControlRegistryEditor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlRegistryEditor.SuspendLayout()
        Me.XtraTabPageDatabase.SuspendLayout()
        CType(Me.GroupControlConnectToDatabase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlConnectToDatabase.SuspendLayout()
        CType(Me.GroupControlSelectAuthentication, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlSelectAuthentication.SuspendLayout()
        CType(Me.GroupControlSelectDatabaseServer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlSelectDatabaseServer.SuspendLayout()
        Me.XtraTabPageWebServices.SuspendLayout()
        Me.XtraTabPageSMTP.SuspendLayout()
        Me.XtraTabPageSystem.SuspendLayout()
        CType(Me.GroupControlAlertRefreshRate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlAlertRefreshRate.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnHelp
        '
        Me.btnHelp.Location = New System.Drawing.Point(250, 572)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(75, 23)
        Me.btnHelp.TabIndex = 3
        Me.btnHelp.Text = "Help"
        '
        'gbWebFarm
        '
        Me.gbWebFarm.Controls.Add(Me.Label11)
        Me.gbWebFarm.Controls.Add(Me.TxtAdmDatabaseName)
        Me.gbWebFarm.Controls.Add(Me.ChkBxUseSysLogon)
        Me.gbWebFarm.Controls.Add(Me.ChkBxIsOnWebFarm)
        Me.gbWebFarm.Location = New System.Drawing.Point(1113, 44)
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
        Me.GroupBox2.Location = New System.Drawing.Point(1113, 163)
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
        'TreeViewImageList
        '
        Me.TreeViewImageList.ImageStream = CType(resources.GetObject("TreeViewImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.TreeViewImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.TreeViewImageList.Images.SetKeyName(0, "client_network.png")
        Me.TreeViewImageList.Images.SetKeyName(1, "data.png")
        Me.TreeViewImageList.Images.SetKeyName(2, "server.png")
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
        Me.Label17.Location = New System.Drawing.Point(1113, 450)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(119, 13)
        Me.Label17.TabIndex = 27
        Me.Label17.Text = "Administrator Password:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(1113, 411)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(121, 13)
        Me.Label15.TabIndex = 26
        Me.Label15.Text = "Administrator Username:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1113, 330)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 13)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Database Server Name:"
        '
        'TxtAdmPassword
        '
        Me.TxtAdmPassword.Location = New System.Drawing.Point(1113, 465)
        Me.TxtAdmPassword.Name = "TxtAdmPassword"
        Me.TxtAdmPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtAdmPassword.Size = New System.Drawing.Size(342, 20)
        Me.TxtAdmPassword.TabIndex = 24
        '
        'TxtAdmUserName
        '
        Me.TxtAdmUserName.Location = New System.Drawing.Point(1113, 427)
        Me.TxtAdmUserName.Name = "TxtAdmUserName"
        Me.TxtAdmUserName.Size = New System.Drawing.Size(342, 20)
        Me.TxtAdmUserName.TabIndex = 23
        '
        'TxtAdmServerName
        '
        Me.TxtAdmServerName.Location = New System.Drawing.Point(1113, 346)
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
        'ButtonBack
        '
        Me.ButtonBack.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.ButtonBack.FlatAppearance.BorderSize = 0
        Me.ButtonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonBack.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonBack.ForeColor = System.Drawing.Color.White
        Me.ButtonBack.Location = New System.Drawing.Point(12, 491)
        Me.ButtonBack.Name = "ButtonBack"
        Me.ButtonBack.Size = New System.Drawing.Size(184, 38)
        Me.ButtonBack.TabIndex = 28
        Me.ButtonBack.Text = "Back"
        Me.ButtonBack.UseVisualStyleBackColor = False
        Me.ButtonBack.Visible = False
        '
        'ButtonExit
        '
        Me.ButtonExit.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.ButtonExit.FlatAppearance.BorderSize = 0
        Me.ButtonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonExit.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonExit.ForeColor = System.Drawing.Color.White
        Me.ButtonExit.Location = New System.Drawing.Point(207, 490)
        Me.ButtonExit.Name = "ButtonExit"
        Me.ButtonExit.Size = New System.Drawing.Size(199, 38)
        Me.ButtonExit.TabIndex = 29
        Me.ButtonExit.Text = "Exit"
        Me.ButtonExit.UseVisualStyleBackColor = False
        '
        'XtraTabControlMain
        '
        Me.XtraTabControlMain.Location = New System.Drawing.Point(12, 12)
        Me.XtraTabControlMain.Name = "XtraTabControlMain"
        Me.XtraTabControlMain.SelectedTabPage = Me.XtraTabPageIIS
        Me.XtraTabControlMain.Size = New System.Drawing.Size(395, 473)
        Me.XtraTabControlMain.TabIndex = 30
        Me.XtraTabControlMain.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPageIIS, Me.XtraTabPageApplication, Me.XtraTabPageRegistry, Me.XtraTabPageDatabase, Me.XtraTabPageWebServices, Me.XtraTabPageSMTP, Me.XtraTabPageSystem})
        '
        'XtraTabPageIIS
        '
        Me.XtraTabPageIIS.Controls.Add(Me.GroupControlVirtualDirectory)
        Me.XtraTabPageIIS.Controls.Add(Me.GroupControlTools)
        Me.XtraTabPageIIS.Controls.Add(Me.GroupControlIISWebSites)
        Me.XtraTabPageIIS.Controls.Add(Me.lblProgress)
        Me.XtraTabPageIIS.Controls.Add(Me.PBarIIS)
        Me.XtraTabPageIIS.Controls.Add(Me.btnSetupVirtDir)
        Me.XtraTabPageIIS.Name = "XtraTabPageIIS"
        Me.XtraTabPageIIS.Size = New System.Drawing.Size(393, 448)
        Me.XtraTabPageIIS.Text = "IIS"
        '
        'GroupControlVirtualDirectory
        '
        Me.GroupControlVirtualDirectory.Controls.Add(Me.txtSessionTimeout)
        Me.GroupControlVirtualDirectory.Controls.Add(Me.chkVirtualDirectory)
        Me.GroupControlVirtualDirectory.Controls.Add(Me.LabelIISTimeOut)
        Me.GroupControlVirtualDirectory.Controls.Add(Me.lblWebconfig)
        Me.GroupControlVirtualDirectory.Controls.Add(Me.txtVirtualDirectory)
        Me.GroupControlVirtualDirectory.Controls.Add(Me.txtPhysicalPath)
        Me.GroupControlVirtualDirectory.Controls.Add(Me.Label9)
        Me.GroupControlVirtualDirectory.Location = New System.Drawing.Point(7, 123)
        Me.GroupControlVirtualDirectory.Name = "GroupControlVirtualDirectory"
        Me.GroupControlVirtualDirectory.Size = New System.Drawing.Size(375, 163)
        Me.GroupControlVirtualDirectory.TabIndex = 34
        Me.GroupControlVirtualDirectory.Text = "Virtual Directory"
        '
        'txtSessionTimeout
        '
        Me.txtSessionTimeout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSessionTimeout.Location = New System.Drawing.Point(133, 137)
        Me.txtSessionTimeout.Name = "txtSessionTimeout"
        Me.txtSessionTimeout.Size = New System.Drawing.Size(53, 21)
        Me.txtSessionTimeout.TabIndex = 18
        Me.txtSessionTimeout.Text = "120"
        Me.txtSessionTimeout.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chkVirtualDirectory
        '
        Me.chkVirtualDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkVirtualDirectory.Location = New System.Drawing.Point(5, 24)
        Me.chkVirtualDirectory.Name = "chkVirtualDirectory"
        Me.chkVirtualDirectory.Size = New System.Drawing.Size(280, 24)
        Me.chkVirtualDirectory.TabIndex = 16
        Me.chkVirtualDirectory.Text = "Create Webvantage Virtual Directory"
        '
        'LabelIISTimeOut
        '
        Me.LabelIISTimeOut.AutoSize = True
        Me.LabelIISTimeOut.Location = New System.Drawing.Point(5, 140)
        Me.LabelIISTimeOut.Name = "LabelIISTimeOut"
        Me.LabelIISTimeOut.Size = New System.Drawing.Size(100, 13)
        Me.LabelIISTimeOut.TabIndex = 17
        Me.LabelIISTimeOut.Text = "Time out (minutes):"
        '
        'lblWebconfig
        '
        Me.lblWebconfig.Location = New System.Drawing.Point(5, 91)
        Me.lblWebconfig.Name = "lblWebconfig"
        Me.lblWebconfig.Size = New System.Drawing.Size(232, 16)
        Me.lblWebconfig.TabIndex = 12
        Me.lblWebconfig.Text = "Virtual Directory:"
        '
        'txtVirtualDirectory
        '
        Me.txtVirtualDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVirtualDirectory.Location = New System.Drawing.Point(5, 107)
        Me.txtVirtualDirectory.Name = "txtVirtualDirectory"
        Me.txtVirtualDirectory.Size = New System.Drawing.Size(342, 21)
        Me.txtVirtualDirectory.TabIndex = 13
        Me.txtVirtualDirectory.Text = "webvantage"
        '
        'txtPhysicalPath
        '
        Me.txtPhysicalPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPhysicalPath.Location = New System.Drawing.Point(5, 67)
        Me.txtPhysicalPath.Name = "txtPhysicalPath"
        Me.txtPhysicalPath.Size = New System.Drawing.Size(342, 21)
        Me.txtPhysicalPath.TabIndex = 15
        Me.txtPhysicalPath.Text = "C:\Inetpub\wwwroot\webvantage"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(5, 51)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(232, 16)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Copy files to:"
        '
        'GroupControlTools
        '
        Me.GroupControlTools.Controls.Add(Me.ButtonSetMachineConfig)
        Me.GroupControlTools.Controls.Add(Me.ButtonDeleteTempFiles)
        Me.GroupControlTools.Controls.Add(Me.Label34)
        Me.GroupControlTools.Location = New System.Drawing.Point(5, 343)
        Me.GroupControlTools.Name = "GroupControlTools"
        Me.GroupControlTools.Size = New System.Drawing.Size(375, 89)
        Me.GroupControlTools.TabIndex = 35
        Me.GroupControlTools.Text = "Tools"
        '
        'ButtonSetMachineConfig
        '
        Me.ButtonSetMachineConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSetMachineConfig.Location = New System.Drawing.Point(185, 24)
        Me.ButtonSetMachineConfig.Name = "ButtonSetMachineConfig"
        Me.ButtonSetMachineConfig.Size = New System.Drawing.Size(167, 23)
        Me.ButtonSetMachineConfig.TabIndex = 13
        Me.ButtonSetMachineConfig.Text = "Set machine.config *"
        Me.ButtonSetMachineConfig.UseVisualStyleBackColor = True
        Me.ButtonSetMachineConfig.Visible = False
        '
        'ButtonDeleteTempFiles
        '
        Me.ButtonDeleteTempFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonDeleteTempFiles.Location = New System.Drawing.Point(8, 24)
        Me.ButtonDeleteTempFiles.Name = "ButtonDeleteTempFiles"
        Me.ButtonDeleteTempFiles.Size = New System.Drawing.Size(171, 23)
        Me.ButtonDeleteTempFiles.TabIndex = 11
        Me.ButtonDeleteTempFiles.Text = "Delete Temp Files *"
        Me.ButtonDeleteTempFiles.UseVisualStyleBackColor = True
        Me.ButtonDeleteTempFiles.Visible = False
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(11, 61)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(177, 13)
        Me.Label34.TabIndex = 12
        Me.Label34.Text = "* IIS will be stopped and restarted!"
        '
        'GroupControlIISWebSites
        '
        Me.GroupControlIISWebSites.Controls.Add(Me.btnLoadWebsites)
        Me.GroupControlIISWebSites.Controls.Add(Me.drpIISWebsite)
        Me.GroupControlIISWebSites.Controls.Add(Me.Label12)
        Me.GroupControlIISWebSites.Controls.Add(Me.txtIISServer)
        Me.GroupControlIISWebSites.Controls.Add(Me.Label10)
        Me.GroupControlIISWebSites.Location = New System.Drawing.Point(6, 6)
        Me.GroupControlIISWebSites.Name = "GroupControlIISWebSites"
        Me.GroupControlIISWebSites.Size = New System.Drawing.Size(375, 111)
        Me.GroupControlIISWebSites.TabIndex = 33
        Me.GroupControlIISWebSites.Text = "IIS Web Sites"
        '
        'btnLoadWebsites
        '
        Me.btnLoadWebsites.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadWebsites.Location = New System.Drawing.Point(239, 40)
        Me.btnLoadWebsites.Name = "btnLoadWebsites"
        Me.btnLoadWebsites.Size = New System.Drawing.Size(120, 21)
        Me.btnLoadWebsites.TabIndex = 15
        Me.btnLoadWebsites.Text = "Load Web Sites"
        '
        'drpIISWebsite
        '
        Me.drpIISWebsite.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.drpIISWebsite.Location = New System.Drawing.Point(5, 82)
        Me.drpIISWebsite.Name = "drpIISWebsite"
        Me.drpIISWebsite.Size = New System.Drawing.Size(344, 21)
        Me.drpIISWebsite.TabIndex = 14
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(5, 63)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(232, 16)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "IIS Web Site:"
        '
        'txtIISServer
        '
        Me.txtIISServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIISServer.Location = New System.Drawing.Point(5, 40)
        Me.txtIISServer.Name = "txtIISServer"
        Me.txtIISServer.Size = New System.Drawing.Size(220, 21)
        Me.txtIISServer.TabIndex = 11
        Me.txtIISServer.Text = "localhost"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(5, 21)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(232, 16)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "IIS Server IP Address or Server Name:"
        '
        'lblProgress
        '
        Me.lblProgress.AutoSize = True
        Me.lblProgress.Location = New System.Drawing.Point(9, 295)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(53, 13)
        Me.lblProgress.TabIndex = 18
        Me.lblProgress.Text = "Progress:"
        '
        'PBarIIS
        '
        Me.PBarIIS.ForeColor = System.Drawing.Color.Teal
        Me.PBarIIS.Location = New System.Drawing.Point(9, 314)
        Me.PBarIIS.Name = "PBarIIS"
        Me.PBarIIS.Size = New System.Drawing.Size(269, 23)
        Me.PBarIIS.TabIndex = 17
        '
        'btnSetupVirtDir
        '
        Me.btnSetupVirtDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSetupVirtDir.Location = New System.Drawing.Point(284, 314)
        Me.btnSetupVirtDir.Name = "btnSetupVirtDir"
        Me.btnSetupVirtDir.Size = New System.Drawing.Size(97, 23)
        Me.btnSetupVirtDir.TabIndex = 15
        Me.btnSetupVirtDir.Text = "Setup"
        '
        'XtraTabPageApplication
        '
        Me.XtraTabPageApplication.Controls.Add(Me.GroupControlGeneralApplicationSettings)
        Me.XtraTabPageApplication.Controls.Add(Me.GroupControlAuthentication)
        Me.XtraTabPageApplication.Controls.Add(Me.Label13)
        Me.XtraTabPageApplication.Controls.Add(Me.txtwebconfig1)
        Me.XtraTabPageApplication.Controls.Add(Me.btnBrowse)
        Me.XtraTabPageApplication.Controls.Add(Me.btnChangeSMTPSettings)
        Me.XtraTabPageApplication.Name = "XtraTabPageApplication"
        Me.XtraTabPageApplication.Size = New System.Drawing.Size(393, 448)
        Me.XtraTabPageApplication.Text = "Application"
        '
        'GroupControlGeneralApplicationSettings
        '
        Me.GroupControlGeneralApplicationSettings.Controls.Add(Me.cboCustomErrors)
        Me.GroupControlGeneralApplicationSettings.Controls.Add(Me.Label22)
        Me.GroupControlGeneralApplicationSettings.Controls.Add(Me.TxtTimeOutMinutes)
        Me.GroupControlGeneralApplicationSettings.Controls.Add(Me.LabelTimeOut)
        Me.GroupControlGeneralApplicationSettings.Controls.Add(Me.chkUpperCaseDatabase)
        Me.GroupControlGeneralApplicationSettings.Controls.Add(Me.chkSQLControledAdmin)
        Me.GroupControlGeneralApplicationSettings.Controls.Add(Me.chkUpperCaseUser)
        Me.GroupControlGeneralApplicationSettings.Controls.Add(Me.chkChooseServer)
        Me.GroupControlGeneralApplicationSettings.Location = New System.Drawing.Point(3, 51)
        Me.GroupControlGeneralApplicationSettings.Name = "GroupControlGeneralApplicationSettings"
        Me.GroupControlGeneralApplicationSettings.Size = New System.Drawing.Size(375, 169)
        Me.GroupControlGeneralApplicationSettings.TabIndex = 31
        Me.GroupControlGeneralApplicationSettings.Text = "General Application Settings"
        '
        'cboCustomErrors
        '
        Me.cboCustomErrors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCustomErrors.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCustomErrors.FormattingEnabled = True
        Me.cboCustomErrors.Items.AddRange(New Object() {"Off", "On", "RemoteOnly"})
        Me.cboCustomErrors.Location = New System.Drawing.Point(121, 135)
        Me.cboCustomErrors.MaxDropDownItems = 3
        Me.cboCustomErrors.Name = "cboCustomErrors"
        Me.cboCustomErrors.Size = New System.Drawing.Size(96, 21)
        Me.cboCustomErrors.TabIndex = 19
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(10, 140)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(108, 13)
        Me.Label22.TabIndex = 18
        Me.Label22.Text = "Custom Errors Mode:"
        '
        'TxtTimeOutMinutes
        '
        Me.TxtTimeOutMinutes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTimeOutMinutes.Location = New System.Drawing.Point(144, 106)
        Me.TxtTimeOutMinutes.Name = "TxtTimeOutMinutes"
        Me.TxtTimeOutMinutes.Size = New System.Drawing.Size(73, 21)
        Me.TxtTimeOutMinutes.TabIndex = 17
        Me.TxtTimeOutMinutes.Text = "120"
        Me.TxtTimeOutMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelTimeOut
        '
        Me.LabelTimeOut.AutoSize = True
        Me.LabelTimeOut.Location = New System.Drawing.Point(12, 108)
        Me.LabelTimeOut.Name = "LabelTimeOut"
        Me.LabelTimeOut.Size = New System.Drawing.Size(100, 13)
        Me.LabelTimeOut.TabIndex = 16
        Me.LabelTimeOut.Text = "Time out (minutes):"
        '
        'chkUpperCaseDatabase
        '
        Me.chkUpperCaseDatabase.BackColor = System.Drawing.Color.Transparent
        Me.chkUpperCaseDatabase.Checked = True
        Me.chkUpperCaseDatabase.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkUpperCaseDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkUpperCaseDatabase.Location = New System.Drawing.Point(5, 43)
        Me.chkUpperCaseDatabase.Name = "chkUpperCaseDatabase"
        Me.chkUpperCaseDatabase.Size = New System.Drawing.Size(288, 24)
        Me.chkUpperCaseDatabase.TabIndex = 15
        Me.chkUpperCaseDatabase.Text = "Default Database name to always use upper case"
        Me.chkUpperCaseDatabase.UseVisualStyleBackColor = False
        '
        'chkSQLControledAdmin
        '
        Me.chkSQLControledAdmin.BackColor = System.Drawing.Color.Transparent
        Me.chkSQLControledAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkSQLControledAdmin.Location = New System.Drawing.Point(5, 62)
        Me.chkSQLControledAdmin.Name = "chkSQLControledAdmin"
        Me.chkSQLControledAdmin.Size = New System.Drawing.Size(288, 24)
        Me.chkSQLControledAdmin.TabIndex = 14
        Me.chkSQLControledAdmin.Text = "Allow Admin to be controlled from SQL Server"
        Me.chkSQLControledAdmin.UseVisualStyleBackColor = False
        '
        'chkUpperCaseUser
        '
        Me.chkUpperCaseUser.BackColor = System.Drawing.Color.Transparent
        Me.chkUpperCaseUser.Checked = True
        Me.chkUpperCaseUser.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkUpperCaseUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkUpperCaseUser.Location = New System.Drawing.Point(5, 24)
        Me.chkUpperCaseUser.Name = "chkUpperCaseUser"
        Me.chkUpperCaseUser.Size = New System.Drawing.Size(288, 24)
        Me.chkUpperCaseUser.TabIndex = 12
        Me.chkUpperCaseUser.Text = "Default user ID to always use upper case"
        Me.chkUpperCaseUser.UseVisualStyleBackColor = False
        '
        'chkChooseServer
        '
        Me.chkChooseServer.BackColor = System.Drawing.Color.Transparent
        Me.chkChooseServer.Checked = True
        Me.chkChooseServer.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkChooseServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkChooseServer.Location = New System.Drawing.Point(5, 81)
        Me.chkChooseServer.Name = "chkChooseServer"
        Me.chkChooseServer.Size = New System.Drawing.Size(368, 24)
        Me.chkChooseServer.TabIndex = 13
        Me.chkChooseServer.Text = "Allow user to select server (if unchecked registry needs to be edited)"
        Me.chkChooseServer.UseVisualStyleBackColor = False
        '
        'GroupControlAuthentication
        '
        Me.GroupControlAuthentication.Controls.Add(Me.Chk_NTAuth_UserCode_IgnoreCase)
        Me.GroupControlAuthentication.Controls.Add(Me.rbSqlAuthentication)
        Me.GroupControlAuthentication.Controls.Add(Me.rbNTAuthentication)
        Me.GroupControlAuthentication.Location = New System.Drawing.Point(4, 226)
        Me.GroupControlAuthentication.Name = "GroupControlAuthentication"
        Me.GroupControlAuthentication.Size = New System.Drawing.Size(375, 91)
        Me.GroupControlAuthentication.TabIndex = 33
        Me.GroupControlAuthentication.Text = "Authentication"
        '
        'Chk_NTAuth_UserCode_IgnoreCase
        '
        Me.Chk_NTAuth_UserCode_IgnoreCase.BackColor = System.Drawing.Color.Transparent
        Me.Chk_NTAuth_UserCode_IgnoreCase.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Chk_NTAuth_UserCode_IgnoreCase.Location = New System.Drawing.Point(166, 51)
        Me.Chk_NTAuth_UserCode_IgnoreCase.Name = "Chk_NTAuth_UserCode_IgnoreCase"
        Me.Chk_NTAuth_UserCode_IgnoreCase.Size = New System.Drawing.Size(195, 24)
        Me.Chk_NTAuth_UserCode_IgnoreCase.TabIndex = 5
        Me.Chk_NTAuth_UserCode_IgnoreCase.Text = "Ignore case for User Code"
        Me.Chk_NTAuth_UserCode_IgnoreCase.UseVisualStyleBackColor = False
        '
        'rbSqlAuthentication
        '
        Me.rbSqlAuthentication.BackColor = System.Drawing.Color.Transparent
        Me.rbSqlAuthentication.Checked = True
        Me.rbSqlAuthentication.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbSqlAuthentication.Location = New System.Drawing.Point(14, 23)
        Me.rbSqlAuthentication.Name = "rbSqlAuthentication"
        Me.rbSqlAuthentication.Size = New System.Drawing.Size(136, 24)
        Me.rbSqlAuthentication.TabIndex = 4
        Me.rbSqlAuthentication.TabStop = True
        Me.rbSqlAuthentication.Text = "SQL Authentication"
        Me.rbSqlAuthentication.UseVisualStyleBackColor = False
        '
        'rbNTAuthentication
        '
        Me.rbNTAuthentication.BackColor = System.Drawing.Color.Transparent
        Me.rbNTAuthentication.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbNTAuthentication.Location = New System.Drawing.Point(166, 23)
        Me.rbNTAuthentication.Name = "rbNTAuthentication"
        Me.rbNTAuthentication.Size = New System.Drawing.Size(162, 24)
        Me.rbNTAuthentication.TabIndex = 3
        Me.rbNTAuthentication.Text = "Windows Authentication"
        Me.rbNTAuthentication.UseVisualStyleBackColor = False
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(11, 7)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(364, 16)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "Location of the Webvantage web.config file:"
        '
        'txtwebconfig1
        '
        Me.txtwebconfig1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtwebconfig1.Location = New System.Drawing.Point(11, 23)
        Me.txtwebconfig1.Name = "txtwebconfig1"
        Me.txtwebconfig1.Size = New System.Drawing.Size(280, 21)
        Me.txtwebconfig1.TabIndex = 17
        '
        'btnBrowse
        '
        Me.btnBrowse.BackColor = System.Drawing.SystemColors.Control
        Me.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBrowse.Location = New System.Drawing.Point(304, 23)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(75, 21)
        Me.btnBrowse.TabIndex = 18
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = False
        '
        'btnChangeSMTPSettings
        '
        Me.btnChangeSMTPSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChangeSMTPSettings.Location = New System.Drawing.Point(8, 402)
        Me.btnChangeSMTPSettings.Name = "btnChangeSMTPSettings"
        Me.btnChangeSMTPSettings.Size = New System.Drawing.Size(371, 33)
        Me.btnChangeSMTPSettings.TabIndex = 16
        Me.btnChangeSMTPSettings.Text = "Change Settings"
        '
        'XtraTabPageRegistry
        '
        Me.XtraTabPageRegistry.Controls.Add(Me.GroupControlRegistryEditor)
        Me.XtraTabPageRegistry.Controls.Add(Me.lblRegistryWarn)
        Me.XtraTabPageRegistry.Name = "XtraTabPageRegistry"
        Me.XtraTabPageRegistry.Size = New System.Drawing.Size(393, 448)
        Me.XtraTabPageRegistry.Text = "Registry"
        '
        'GroupControlRegistryEditor
        '
        Me.GroupControlRegistryEditor.Controls.Add(Me.txtRegistryDatabase)
        Me.GroupControlRegistryEditor.Controls.Add(Me.tvRegistry)
        Me.GroupControlRegistryEditor.Controls.Add(Me.Label29)
        Me.GroupControlRegistryEditor.Controls.Add(Me.Label24)
        Me.GroupControlRegistryEditor.Controls.Add(Me.Label28)
        Me.GroupControlRegistryEditor.Controls.Add(Me.txtAdminUsername)
        Me.GroupControlRegistryEditor.Controls.Add(Me.txtRegistryServer)
        Me.GroupControlRegistryEditor.Controls.Add(Me.Label25)
        Me.GroupControlRegistryEditor.Controls.Add(Me.btnDeleteReg)
        Me.GroupControlRegistryEditor.Controls.Add(Me.txtAdminPassword)
        Me.GroupControlRegistryEditor.Controls.Add(Me.btnAddReg)
        Me.GroupControlRegistryEditor.Controls.Add(Me.btnSaveRegistry)
        Me.GroupControlRegistryEditor.Location = New System.Drawing.Point(7, 27)
        Me.GroupControlRegistryEditor.Name = "GroupControlRegistryEditor"
        Me.GroupControlRegistryEditor.Size = New System.Drawing.Size(375, 330)
        Me.GroupControlRegistryEditor.TabIndex = 33
        Me.GroupControlRegistryEditor.Text = "Registry Editor"
        '
        'txtRegistryDatabase
        '
        Me.txtRegistryDatabase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRegistryDatabase.Location = New System.Drawing.Point(223, 84)
        Me.txtRegistryDatabase.Name = "txtRegistryDatabase"
        Me.txtRegistryDatabase.Size = New System.Drawing.Size(141, 21)
        Me.txtRegistryDatabase.TabIndex = 16
        '
        'tvRegistry
        '
        Me.tvRegistry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tvRegistry.FullRowSelect = True
        Me.tvRegistry.HideSelection = False
        Me.tvRegistry.HotTracking = True
        Me.tvRegistry.Location = New System.Drawing.Point(6, 27)
        Me.tvRegistry.Name = "tvRegistry"
        TreeNode4.Name = "Home"
        TreeNode4.Text = "Home"
        Me.tvRegistry.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode4})
        Me.tvRegistry.Size = New System.Drawing.Size(214, 167)
        Me.tvRegistry.TabIndex = 0
        '
        'Label29
        '
        Me.Label29.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label29.ImageList = Me.TreeViewImageList
        Me.Label29.Location = New System.Drawing.Point(223, 68)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(62, 13)
        Me.Label29.TabIndex = 15
        Me.Label29.Text = "Database:"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(6, 208)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(59, 13)
        Me.Label24.TabIndex = 1
        Me.Label24.Text = "Username:"
        '
        'Label28
        '
        Me.Label28.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label28.ImageList = Me.TreeViewImageList
        Me.Label28.Location = New System.Drawing.Point(223, 26)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(55, 13)
        Me.Label28.TabIndex = 14
        Me.Label28.Text = "Server:"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtAdminUsername
        '
        Me.txtAdminUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAdminUsername.Enabled = False
        Me.txtAdminUsername.Location = New System.Drawing.Point(9, 234)
        Me.txtAdminUsername.Name = "txtAdminUsername"
        Me.txtAdminUsername.Size = New System.Drawing.Size(168, 21)
        Me.txtAdminUsername.TabIndex = 2
        '
        'txtRegistryServer
        '
        Me.txtRegistryServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRegistryServer.Location = New System.Drawing.Point(223, 43)
        Me.txtRegistryServer.Name = "txtRegistryServer"
        Me.txtRegistryServer.Size = New System.Drawing.Size(141, 21)
        Me.txtRegistryServer.TabIndex = 13
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(189, 208)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(57, 13)
        Me.Label25.TabIndex = 3
        Me.Label25.Text = "Password:"
        '
        'btnDeleteReg
        '
        Me.btnDeleteReg.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeleteReg.Location = New System.Drawing.Point(223, 171)
        Me.btnDeleteReg.Name = "btnDeleteReg"
        Me.btnDeleteReg.Size = New System.Drawing.Size(141, 23)
        Me.btnDeleteReg.TabIndex = 12
        Me.btnDeleteReg.Text = "Delete"
        '
        'txtAdminPassword
        '
        Me.txtAdminPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAdminPassword.Enabled = False
        Me.txtAdminPassword.Location = New System.Drawing.Point(192, 234)
        Me.txtAdminPassword.Name = "txtAdminPassword"
        Me.txtAdminPassword.Size = New System.Drawing.Size(172, 21)
        Me.txtAdminPassword.TabIndex = 4
        Me.txtAdminPassword.UseSystemPasswordChar = True
        '
        'btnAddReg
        '
        Me.btnAddReg.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddReg.Location = New System.Drawing.Point(223, 142)
        Me.btnAddReg.Name = "btnAddReg"
        Me.btnAddReg.Size = New System.Drawing.Size(141, 23)
        Me.btnAddReg.TabIndex = 11
        Me.btnAddReg.Text = "Add"
        '
        'btnSaveRegistry
        '
        Me.btnSaveRegistry.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveRegistry.Location = New System.Drawing.Point(8, 277)
        Me.btnSaveRegistry.Name = "btnSaveRegistry"
        Me.btnSaveRegistry.Size = New System.Drawing.Size(356, 36)
        Me.btnSaveRegistry.TabIndex = 9
        Me.btnSaveRegistry.Text = "Save"
        '
        'lblRegistryWarn
        '
        Me.lblRegistryWarn.AutoSize = True
        Me.lblRegistryWarn.Location = New System.Drawing.Point(10, 7)
        Me.lblRegistryWarn.Name = "lblRegistryWarn"
        Me.lblRegistryWarn.Size = New System.Drawing.Size(320, 13)
        Me.lblRegistryWarn.TabIndex = 3
        Me.lblRegistryWarn.Text = "To display, uncheck ""Allow user to select server"" on previous tab "
        '
        'XtraTabPageDatabase
        '
        Me.XtraTabPageDatabase.Controls.Add(Me.GroupControlConnectToDatabase)
        Me.XtraTabPageDatabase.Controls.Add(Me.Label14)
        Me.XtraTabPageDatabase.Controls.Add(Me.GroupControlSelectAuthentication)
        Me.XtraTabPageDatabase.Controls.Add(Me.lblconnectSQL)
        Me.XtraTabPageDatabase.Controls.Add(Me.GroupControlSelectDatabaseServer)
        Me.XtraTabPageDatabase.Name = "XtraTabPageDatabase"
        Me.XtraTabPageDatabase.Size = New System.Drawing.Size(393, 448)
        Me.XtraTabPageDatabase.Text = "Database"
        '
        'GroupControlConnectToDatabase
        '
        Me.GroupControlConnectToDatabase.Controls.Add(Me.cboDatabaseScript)
        Me.GroupControlConnectToDatabase.Controls.Add(Me.lblDatabaseName)
        Me.GroupControlConnectToDatabase.Controls.Add(Me.Label8)
        Me.GroupControlConnectToDatabase.Controls.Add(Me.txtDatabaseName)
        Me.GroupControlConnectToDatabase.Controls.Add(Me.btnRun)
        Me.GroupControlConnectToDatabase.Controls.Add(Me.lblDatabaseVersion)
        Me.GroupControlConnectToDatabase.Controls.Add(Me.btnTestConnection)
        Me.GroupControlConnectToDatabase.Location = New System.Drawing.Point(6, 306)
        Me.GroupControlConnectToDatabase.Name = "GroupControlConnectToDatabase"
        Me.GroupControlConnectToDatabase.Size = New System.Drawing.Size(375, 150)
        Me.GroupControlConnectToDatabase.TabIndex = 35
        Me.GroupControlConnectToDatabase.Text = "Connect To Database"
        '
        'cboDatabaseScript
        '
        Me.cboDatabaseScript.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboDatabaseScript.ItemHeight = 13
        Me.cboDatabaseScript.Location = New System.Drawing.Point(137, 69)
        Me.cboDatabaseScript.Name = "cboDatabaseScript"
        Me.cboDatabaseScript.Size = New System.Drawing.Size(224, 21)
        Me.cboDatabaseScript.TabIndex = 2
        Me.cboDatabaseScript.Visible = False
        '
        'lblDatabaseName
        '
        Me.lblDatabaseName.Location = New System.Drawing.Point(33, 37)
        Me.lblDatabaseName.Name = "lblDatabaseName"
        Me.lblDatabaseName.Size = New System.Drawing.Size(100, 16)
        Me.lblDatabaseName.TabIndex = 0
        Me.lblDatabaseName.Text = "Database Name:"
        Me.lblDatabaseName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(33, 69)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 16)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Database Script:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label8.Visible = False
        '
        'txtDatabaseName
        '
        Me.txtDatabaseName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDatabaseName.Location = New System.Drawing.Point(137, 37)
        Me.txtDatabaseName.Name = "txtDatabaseName"
        Me.txtDatabaseName.Size = New System.Drawing.Size(224, 21)
        Me.txtDatabaseName.TabIndex = 1
        '
        'btnRun
        '
        Me.btnRun.Enabled = False
        Me.btnRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRun.Location = New System.Drawing.Point(281, 109)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(75, 23)
        Me.btnRun.TabIndex = 5
        Me.btnRun.Text = "Run"
        '
        'lblDatabaseVersion
        '
        Me.lblDatabaseVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDatabaseVersion.Location = New System.Drawing.Point(1, 109)
        Me.lblDatabaseVersion.Name = "lblDatabaseVersion"
        Me.lblDatabaseVersion.Size = New System.Drawing.Size(144, 16)
        Me.lblDatabaseVersion.TabIndex = 3
        Me.lblDatabaseVersion.Text = "No Database Version"
        Me.lblDatabaseVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblDatabaseVersion.Visible = False
        '
        'btnTestConnection
        '
        Me.btnTestConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTestConnection.Location = New System.Drawing.Point(161, 109)
        Me.btnTestConnection.Name = "btnTestConnection"
        Me.btnTestConnection.Size = New System.Drawing.Size(112, 23)
        Me.btnTestConnection.TabIndex = 4
        Me.btnTestConnection.Text = "Test Connection"
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(13, 15)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(368, 16)
        Me.Label14.TabIndex = 9
        Me.Label14.Text = "*NOTE: This tab can only be executed from a machine with SQL Server."
        Me.Label14.Visible = False
        '
        'GroupControlSelectAuthentication
        '
        Me.GroupControlSelectAuthentication.Controls.Add(Me.txtPassword)
        Me.GroupControlSelectAuthentication.Controls.Add(Me.txtUserName)
        Me.GroupControlSelectAuthentication.Controls.Add(Me.rbWIA)
        Me.GroupControlSelectAuthentication.Controls.Add(Me.Label3)
        Me.GroupControlSelectAuthentication.Controls.Add(Me.rbSSA)
        Me.GroupControlSelectAuthentication.Controls.Add(Me.Label2)
        Me.GroupControlSelectAuthentication.Location = New System.Drawing.Point(5, 146)
        Me.GroupControlSelectAuthentication.Name = "GroupControlSelectAuthentication"
        Me.GroupControlSelectAuthentication.Size = New System.Drawing.Size(375, 149)
        Me.GroupControlSelectAuthentication.TabIndex = 34
        Me.GroupControlSelectAuthentication.Text = "Select Authentication"
        '
        'txtPassword
        '
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPassword.Location = New System.Drawing.Point(161, 112)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(144, 21)
        Me.txtPassword.TabIndex = 3
        '
        'txtUserName
        '
        Me.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUserName.Location = New System.Drawing.Point(161, 88)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(144, 21)
        Me.txtUserName.TabIndex = 2
        '
        'rbWIA
        '
        Me.rbWIA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbWIA.Location = New System.Drawing.Point(9, 32)
        Me.rbWIA.Name = "rbWIA"
        Me.rbWIA.Size = New System.Drawing.Size(272, 24)
        Me.rbWIA.TabIndex = 0
        Me.rbWIA.Text = "Use Windows Integrated Authentication"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(89, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Password:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'rbSSA
        '
        Me.rbSSA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbSSA.Location = New System.Drawing.Point(9, 56)
        Me.rbSSA.Name = "rbSSA"
        Me.rbSSA.Size = New System.Drawing.Size(272, 24)
        Me.rbSSA.TabIndex = 1
        Me.rbSSA.Text = "Use SQL Server Authentication"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(89, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "User Name:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblconnectSQL
        '
        Me.lblconnectSQL.Location = New System.Drawing.Point(21, 39)
        Me.lblconnectSQL.Name = "lblconnectSQL"
        Me.lblconnectSQL.Size = New System.Drawing.Size(176, 16)
        Me.lblconnectSQL.TabIndex = 6
        Me.lblconnectSQL.Text = "Connect directly to a SQL Server."
        '
        'GroupControlSelectDatabaseServer
        '
        Me.GroupControlSelectDatabaseServer.Controls.Add(Me.txtSQLServerName)
        Me.GroupControlSelectDatabaseServer.Controls.Add(Me.lblSQLServerName)
        Me.GroupControlSelectDatabaseServer.Location = New System.Drawing.Point(7, 59)
        Me.GroupControlSelectDatabaseServer.Name = "GroupControlSelectDatabaseServer"
        Me.GroupControlSelectDatabaseServer.Size = New System.Drawing.Size(375, 76)
        Me.GroupControlSelectDatabaseServer.TabIndex = 33
        Me.GroupControlSelectDatabaseServer.Text = "Select Database Server"
        '
        'txtSQLServerName
        '
        Me.txtSQLServerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSQLServerName.Location = New System.Drawing.Point(113, 35)
        Me.txtSQLServerName.Name = "txtSQLServerName"
        Me.txtSQLServerName.Size = New System.Drawing.Size(224, 21)
        Me.txtSQLServerName.TabIndex = 1
        '
        'lblSQLServerName
        '
        Me.lblSQLServerName.Location = New System.Drawing.Point(9, 35)
        Me.lblSQLServerName.Name = "lblSQLServerName"
        Me.lblSQLServerName.Size = New System.Drawing.Size(100, 16)
        Me.lblSQLServerName.TabIndex = 0
        Me.lblSQLServerName.Text = "SQL Server Name:"
        Me.lblSQLServerName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'XtraTabPageWebServices
        '
        Me.XtraTabPageWebServices.Controls.Add(Me.lblWarning)
        Me.XtraTabPageWebServices.Controls.Add(Me.Label32)
        Me.XtraTabPageWebServices.Controls.Add(Me.Label31)
        Me.XtraTabPageWebServices.Controls.Add(Me.btnCreate)
        Me.XtraTabPageWebServices.Controls.Add(Me.txtURL)
        Me.XtraTabPageWebServices.Controls.Add(Me.Label30)
        Me.XtraTabPageWebServices.Name = "XtraTabPageWebServices"
        Me.XtraTabPageWebServices.Size = New System.Drawing.Size(393, 448)
        Me.XtraTabPageWebServices.Text = "Web Services"
        '
        'lblWarning
        '
        Me.lblWarning.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWarning.ForeColor = System.Drawing.Color.Red
        Me.lblWarning.Location = New System.Drawing.Point(17, 156)
        Me.lblWarning.Name = "lblWarning"
        Me.lblWarning.Size = New System.Drawing.Size(251, 40)
        Me.lblWarning.TabIndex = 19
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(18, 124)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(213, 13)
        Me.Label32.TabIndex = 18
        Me.Label32.Text = "Example: https://webvantage.agency.com"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(18, 111)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(181, 13)
        Me.Label31.TabIndex = 17
        Me.Label31.Text = "Example: http://server/webvantage"
        '
        'btnCreate
        '
        Me.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCreate.Location = New System.Drawing.Point(6, 69)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(368, 33)
        Me.btnCreate.TabIndex = 16
        Me.btnCreate.Text = "&Apply"
        '
        'txtURL
        '
        Me.txtURL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtURL.Location = New System.Drawing.Point(5, 29)
        Me.txtURL.Name = "txtURL"
        Me.txtURL.Size = New System.Drawing.Size(369, 21)
        Me.txtURL.TabIndex = 15
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(3, 13)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(141, 13)
        Me.Label30.TabIndex = 14
        Me.Label30.Text = "Enter URL for Webvantage:"
        '
        'XtraTabPageSMTP
        '
        Me.XtraTabPageSMTP.Controls.Add(Me.btnSmtpInstall)
        Me.XtraTabPageSMTP.Controls.Add(Me.Label33)
        Me.XtraTabPageSMTP.Name = "XtraTabPageSMTP"
        Me.XtraTabPageSMTP.Size = New System.Drawing.Size(393, 448)
        Me.XtraTabPageSMTP.Text = "SMTP"
        '
        'btnSmtpInstall
        '
        Me.btnSmtpInstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSmtpInstall.Location = New System.Drawing.Point(15, 39)
        Me.btnSmtpInstall.Name = "btnSmtpInstall"
        Me.btnSmtpInstall.Size = New System.Drawing.Size(359, 37)
        Me.btnSmtpInstall.TabIndex = 3
        Me.btnSmtpInstall.Text = "Install SMTP Component"
        Me.btnSmtpInstall.UseVisualStyleBackColor = True
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(12, 14)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(350, 13)
        Me.Label33.TabIndex = 2
        Me.Label33.Text = "To install the SMTP dll for either 32bit or 64bit click the following button:"
        '
        'XtraTabPageSystem
        '
        Me.XtraTabPageSystem.Controls.Add(Me.LabelNETVersion)
        Me.XtraTabPageSystem.Controls.Add(Me.ButtonInstallNETCoreRuntime)
        Me.XtraTabPageSystem.Controls.Add(Me.ButtonCreateProofingEventLog)
        Me.XtraTabPageSystem.Name = "XtraTabPageSystem"
        Me.XtraTabPageSystem.Size = New System.Drawing.Size(393, 448)
        Me.XtraTabPageSystem.Text = "System"
        '
        'ButtonInstallNETCoreRuntime
        '
        Me.ButtonInstallNETCoreRuntime.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonInstallNETCoreRuntime.Location = New System.Drawing.Point(16, 35)
        Me.ButtonInstallNETCoreRuntime.Name = "ButtonInstallNETCoreRuntime"
        Me.ButtonInstallNETCoreRuntime.Size = New System.Drawing.Size(358, 50)
        Me.ButtonInstallNETCoreRuntime.TabIndex = 37
        Me.ButtonInstallNETCoreRuntime.Text = "Install .NET Core Runtime"
        '
        'ButtonCreateProofingEventLog
        '
        Me.ButtonCreateProofingEventLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCreateProofingEventLog.Location = New System.Drawing.Point(16, 102)
        Me.ButtonCreateProofingEventLog.Name = "ButtonCreateProofingEventLog"
        Me.ButtonCreateProofingEventLog.Size = New System.Drawing.Size(358, 50)
        Me.ButtonCreateProofingEventLog.TabIndex = 36
        Me.ButtonCreateProofingEventLog.Text = "Create Proofing Event Log"
        '
        'GroupControlAlertRefreshRate
        '
        Me.GroupControlAlertRefreshRate.Controls.Add(Me.Label21)
        Me.GroupControlAlertRefreshRate.Controls.Add(Me.Label20)
        Me.GroupControlAlertRefreshRate.Controls.Add(Me.Label19)
        Me.GroupControlAlertRefreshRate.Controls.Add(Me.TxtAlertRefresh)
        Me.GroupControlAlertRefreshRate.Location = New System.Drawing.Point(620, 349)
        Me.GroupControlAlertRefreshRate.Name = "GroupControlAlertRefreshRate"
        Me.GroupControlAlertRefreshRate.Size = New System.Drawing.Size(375, 88)
        Me.GroupControlAlertRefreshRate.TabIndex = 34
        Me.GroupControlAlertRefreshRate.Text = "Alert Refresh Rate"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(5, 64)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(134, 13)
        Me.Label21.TabIndex = 13
        Me.Label21.Text = " Minimum 3 minute interval."
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(5, 51)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(184, 13)
        Me.Label20.TabIndex = 12
        Me.Label20.Text = "*Leave blank or set to zero to disable."
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(5, 31)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(128, 13)
        Me.Label19.TabIndex = 11
        Me.Label19.Text = "Refresh every (minutes):"
        '
        'TxtAlertRefresh
        '
        Me.TxtAlertRefresh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtAlertRefresh.Location = New System.Drawing.Point(136, 27)
        Me.TxtAlertRefresh.Name = "TxtAlertRefresh"
        Me.TxtAlertRefresh.Size = New System.Drawing.Size(53, 21)
        Me.TxtAlertRefresh.TabIndex = 10
        Me.TxtAlertRefresh.Text = "10"
        Me.TxtAlertRefresh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupControl1
        '
        Me.GroupControl1.Location = New System.Drawing.Point(824, 509)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(375, 194)
        Me.GroupControl1.TabIndex = 32
        Me.GroupControl1.Text = "General Application Settings"
        '
        'LabelNETVersion
        '
        Me.LabelNETVersion.AutoSize = True
        Me.LabelNETVersion.Location = New System.Drawing.Point(13, 17)
        Me.LabelNETVersion.Name = "LabelNETVersion"
        Me.LabelNETVersion.Size = New System.Drawing.Size(68, 13)
        Me.LabelNETVersion.TabIndex = 38
        Me.LabelNETVersion.Text = ".NET version"
        '
        'frmWebConfig
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(412, 533)
        Me.Controls.Add(Me.GroupControlAlertRefreshRate)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.XtraTabControlMain)
        Me.Controls.Add(Me.ButtonExit)
        Me.Controls.Add(Me.ButtonBack)
        Me.Controls.Add(Me.gbWebFarm)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtAdmPassword)
        Me.Controls.Add(Me.TxtAdmUserName)
        Me.Controls.Add(Me.TxtAdmServerName)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.BtnDeleteCache)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.btnHelp)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmWebConfig"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.gbWebFarm.ResumeLayout(False)
        Me.gbWebFarm.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.epEmailPassword, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.epSMTPAddress, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.epEmailAddress, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.XtraTabControlMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControlMain.ResumeLayout(False)
        Me.XtraTabPageIIS.ResumeLayout(False)
        Me.XtraTabPageIIS.PerformLayout()
        CType(Me.GroupControlVirtualDirectory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlVirtualDirectory.ResumeLayout(False)
        Me.GroupControlVirtualDirectory.PerformLayout()
        CType(Me.GroupControlTools, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlTools.ResumeLayout(False)
        Me.GroupControlTools.PerformLayout()
        CType(Me.GroupControlIISWebSites, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlIISWebSites.ResumeLayout(False)
        Me.GroupControlIISWebSites.PerformLayout()
        Me.XtraTabPageApplication.ResumeLayout(False)
        Me.XtraTabPageApplication.PerformLayout()
        CType(Me.GroupControlGeneralApplicationSettings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlGeneralApplicationSettings.ResumeLayout(False)
        Me.GroupControlGeneralApplicationSettings.PerformLayout()
        CType(Me.GroupControlAuthentication, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlAuthentication.ResumeLayout(False)
        Me.XtraTabPageRegistry.ResumeLayout(False)
        Me.XtraTabPageRegistry.PerformLayout()
        CType(Me.GroupControlRegistryEditor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlRegistryEditor.ResumeLayout(False)
        Me.GroupControlRegistryEditor.PerformLayout()
        Me.XtraTabPageDatabase.ResumeLayout(False)
        CType(Me.GroupControlConnectToDatabase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlConnectToDatabase.ResumeLayout(False)
        Me.GroupControlConnectToDatabase.PerformLayout()
        CType(Me.GroupControlSelectAuthentication, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlSelectAuthentication.ResumeLayout(False)
        Me.GroupControlSelectAuthentication.PerformLayout()
        CType(Me.GroupControlSelectDatabaseServer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlSelectDatabaseServer.ResumeLayout(False)
        Me.GroupControlSelectDatabaseServer.PerformLayout()
        Me.XtraTabPageWebServices.ResumeLayout(False)
        Me.XtraTabPageWebServices.PerformLayout()
        Me.XtraTabPageSMTP.ResumeLayout(False)
        Me.XtraTabPageSMTP.PerformLayout()
        Me.XtraTabPageSystem.ResumeLayout(False)
        Me.XtraTabPageSystem.PerformLayout()
        CType(Me.GroupControlAlertRefreshRate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlAlertRefreshRate.ResumeLayout(False)
        Me.GroupControlAlertRefreshRate.PerformLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
#Region " Controls "

    Private Sub ButtonBack_Click(sender As Object, e As EventArgs) Handles ButtonBack.Click

        Dim splash As frmWelcome = New frmWelcome
        splash.Show()
        Me.Hide()

    End Sub
    Private Sub ButtonExit_Click(sender As Object, e As EventArgs) Handles ButtonExit.Click

        Me.Close()
        Windows.Forms.Application.Exit()

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
            strConnString = "Server=" & Me.txtSQLServerName.Text.Trim
            strConnString &= ";Database=" & Me.txtDatabaseName.Text.Trim
            strConnString &= ";User ID=" & Me.txtUserName.Text.Trim & ";Password=" & Me.txtPassword.Text.Trim
        End If
        Me.GlobalConnString = strConnString
        oApplication = New cApplication(strConnString)

        strReturn = oApplication.dbTestConnection()

        If strReturn IsNot Nothing Then
            MsgBox("Test successful!  Database version: " & strReturn, MsgBoxStyle.OkOnly, "Test Connection")
            Me.lblDatabaseVersion.Text = "Database Version: " & strReturn
            Me.btnRun.Enabled = True
        Else
            MsgBox("Test Failed!" & Err.Description, MsgBoxStyle.OkOnly, "Test Connection")
            Me.lblDatabaseVersion.Text = " No Database Version"
            Me.btnRun.Enabled = False
        End If
    End Sub
    Private Sub btnRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRun.Click

        Dim strConnString As String
        Dim oApplication As cApplication

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
            strConnString = "Server=" & Me.txtSQLServerName.Text.Trim
            strConnString &= ";Database=" & Me.txtDatabaseName.Text.Trim
            strConnString &= ";User ID=" & Me.txtUserName.Text.Trim & ";Password=" & Me.txtPassword.Text.Trim
        End If
        Me.GlobalConnString = strConnString



        If Me.txtVirtualDirectory.Text.Trim = "" Then
            MsgBox("Please enter a valid Virtual Directory.", MsgBoxStyle.Critical, "Setup Virtual Directory")
            Me.txtVirtualDirectory.Focus()
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


        oApplication = New cApplication(Me.GlobalConnString)

        oApplication.ExecuteScalar(CommandType.Text, "UPDATE AGENCY SET PROOFING_URL='http://" & Me.txtIISServer.Text.Trim & "/" & Me.txtVirtualDirectory.Text.Trim & "'")

        'Me.Disco()
        'Me.Cursor.Current = Cursors.WaitCursor
        'Dim strConnString As String = ""
        'Dim oApplication As cApplication = New cApplication(strConnString)
        'Dim odbInstaller As dbInstaller = New dbInstaller
        'Dim script As String = Application.StartupPath & "\Scripts\" & Me.cboDatabaseScript.Text.Trim
        'Try
        '    If Me.txtDatabaseName.Text.Trim = "" Then
        '        MsgBox("Please enter a valid Database Name.", MsgBoxStyle.Critical, "Database Script Error")
        '        Me.txtDatabaseName.Focus()
        '        Exit Sub
        '    End If
        '    If Me.cboDatabaseScript.Text.Trim = "" Then
        '        MsgBox("Please enter a valid Database Script.", MsgBoxStyle.Critical, "Database Script Error")
        '        Me.cboDatabaseScript.Focus()
        '        Exit Sub
        '    End If

        '    If Me.rbWIA.Checked = True Then
        '        ' use Windows integrated authentication security
        '        odbInstaller.ExecuteSQLScript(Me.txtSQLServerName.Text.Trim, Me.txtDatabaseName.Text.Trim, Me.txtUserName.Text.Trim, Me.txtPassword.Text.Trim, script, Me.rbWIA.Checked)
        '    Else
        '        ' use SQL Server's authentication security
        '        If Me.txtUserName.Text.Trim = "" Then
        '            MsgBox("Please enter a valid User Name.", MsgBoxStyle.Critical, "Database Script Error")
        '            Me.txtUserName.Focus()
        '            Exit Sub
        '        End If
        '        If Me.txtPassword.Text.Trim = "" Then
        '            MsgBox("Please enter a valid password.", MsgBoxStyle.Critical, "Database Script Error")
        '            Me.txtPassword.Focus()
        '            Exit Sub
        '        End If
        '        odbInstaller.ExecuteSQLScript(Me.txtSQLServerName.Text.Trim, Me.txtDatabaseName.Text.Trim, Me.txtUserName.Text.Trim, Me.txtPassword.Text.Trim, script, Me.rbWIA.Checked)
        '    End If
        '    MsgBox("Process Completed!", MsgBoxStyle.OkOnly, "Database Script")

        'Catch
        '    MsgBox("Process Failed!", MsgBoxStyle.Critical, "Database Script")
        'End Try
        'Me.Cursor.Current = Cursors.Default

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
        Windows.Forms.Application.DoEvents()
        Dim IsUpgrading As Boolean = False

        If Me.chkVirtualDirectory.Checked Then
            Me.Cursor.Current = Cursors.WaitCursor
            'Remove old copy if exists.
            If Directory.Exists(txtPhysicalPath.Text.Trim) = True Then
                If MessageBox.Show("Directory exists. Would you like to delete and upgrade?", "Directory Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    IsUpgrading = True
                    Me.lblProgress.Text = "Progress: Stopping IIS."
                    Windows.Forms.Application.DoEvents()
                    STOPIIS()

                    Threading.Thread.Sleep(iisShutdownWaitTime)
                    Me.lblProgress.Text = "Progress: Deleting virtual directory."
                    Windows.Forms.Application.DoEvents()
                    ProcessTree(txtPhysicalPath.Text.Trim)
                    Threading.Thread.Sleep(1000)

                    Try

                        Directory.Delete(txtPhysicalPath.Text.Trim, True)

                    Catch DeleteX As Exception

                        MessageBox.Show(DeleteX.Message, "Error Deleting")

                    End Try

                    PBarIIS.Value = 3

                Else

                    Me.btnSetupVirtDir.Enabled = True
                    Me.Cursor = Cursors.Default
                    Exit Sub

                End If

            End If

            'Add mime types
            Me.lblProgress.Text = "Progress: Creating Mime Types."
            IISAddMimeType("res", "application/octet-stream")
            Windows.Forms.Application.DoEvents()
            IISAddMimeType("wasm", "application/wasm")
            Windows.Forms.Application.DoEvents()
            IISAddMimeType("pexe", "application/x-pnacl")
            Windows.Forms.Application.DoEvents()
            IISAddMimeType("nmf", "application/octet-stream")
            Windows.Forms.Application.DoEvents()
            IISAddMimeType("mem", "application/octet-stream")
            Windows.Forms.Application.DoEvents()

            Me.lblProgress.Text = "Progress: Creating directory."
            Windows.Forms.Application.DoEvents()
            'copy file to inetpub.
            Try

                Directory.CreateDirectory(Me.txtPhysicalPath.Text.Trim)
            Catch ex As Exception

                'directory already exists.
                MessageBox.Show(ex.Message, "Error Createing Directory")

            End Try

            PBarIIS.Value = 4
            Windows.Forms.Application.DoEvents()

            Me.lblProgress.Text = "Progress: Copying Files."

            Select Case Me.SelectedApplication

                Case App.Webvantage, App.MobileDataservices

                    CopyDirectory(Windows.Forms.Application.StartupPath + "\WebvantageAngularCore", Me.txtPhysicalPath.Text.Trim)

                    Dim newPath = Me.txtPhysicalPath.Text.Trim

                    newPath = newPath.Substring(0, newPath.LastIndexOf("\")) & "\wv-resources"

                    CopyDirectory(Windows.Forms.Application.StartupPath + "\WebvantageAngularCore\ClientApp\dist\wv-resources", newPath)

                Case App.ClientPortal

                    CopyDirectoryCP(Windows.Forms.Application.StartupPath, Me.txtPhysicalPath.Text.Trim)

            End Select

            Me.Cursor.Current = Cursors.Default

            If Not IsNumeric(txtSessionTimeout.Text) Then

                MessageBox.Show("You must select a valid numeric value for session timeout.")
                Me.btnSetupVirtDir.Enabled = True
                Me.Cursor = Cursors.Default
                Exit Sub

            End If

            'Create Virtual Directory
            Me.lblProgress.Text = "Progress: Creating virtual directory."
            Windows.Forms.Application.DoEvents()

            Dim s As String = ""
            If Me.SelectedApplication = App.MobileDataservices Then

                s = "DataService.svc"

            Else

                s = "Default.aspx"

            End If

            oApplication.CreateVirtualDir(oWebSites(Me.drpIISWebsite.SelectedIndex).WebSitePath, txtVirtualDirectory.Text, Me.txtPhysicalPath.Text.Trim, txtSessionTimeout.Text, s)
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

        PBarIIS.Maximum = 4

        PBarIIS.Value = 1
        Me.lblProgress.Text = "Progress: Update Base HREF."
        Windows.Forms.Application.DoEvents()

        UpdateBaseHREF()

        PBarIIS.Value = 2
        Me.lblProgress.Text = "Progress: Starting IIS."

        PBarIIS.Value = 3
        Windows.Forms.Application.DoEvents()

        STARTIIS()
        PBarIIS.Value = 4

        Me.lblProgress.Text = "Progress: Complete."

        Me.btnSetupVirtDir.Enabled = True

        Me.Cursor = Cursors.Default

        Me.DeleteDirectory(TempFolder)

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
    Private Sub txtIISServer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIISServer.TextChanged
        Me.btnSetupVirtDir.Enabled = False
    End Sub
    Private Sub btnChangeSMTPSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeSMTPSettings.Click
        Dim ds As DataSet
        If Me.txtwebconfig1.Text.Trim = "" Then
            MsgBox("Please select a valid web.config file.", MsgBoxStyle.Critical, "Save Settings")
            Me.txtwebconfig1.Focus()
            Exit Sub
        End If
        Dim IntTimeOut As Integer = 0
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
            If Me.rbNTAuthentication.Checked = True Then
                strAuth = "Windows"
            Else
                strAuth = "Forms"
            End If
            Dim boolImp As Boolean
            'If Me.rbNTAuthentication.Checked = True Then
            '    boolImp = True
            'Else
            '    boolImp = False
            'End If
            Dim AlertRefresh As Double
            If IsNumeric(Me.TxtAlertRefresh.Text) Then
                AlertRefresh = CType(Me.TxtAlertRefresh.Text, Double)
                If AlertRefresh < 3 Then 'Set 3 minute minimum
                    AlertRefresh = -1
                    Me.TxtAlertRefresh.Text = 0
                Else
                    AlertRefresh = AlertRefresh * 60 * 1000 'minutes to milliseconds
                End If
            Else
                AlertRefresh = -1
            End If
            writeAppSettings(Me.txtwebconfig1.Text.Trim, strAuth, "http://" & Me.txtConfigReportingServices.Text.Trim & "/reportserver/", Me.txtSMTPAddress.Text.Trim, Me.txtEmailFromAddress.Text.Trim, Me.txtEmailUserName.Text.Trim, Me.txtemailpassword.Text.Trim, Me.chkUpperCaseUser.Checked, Me.chkUpperCaseDatabase.Checked, Me.chkChooseServer.Checked, Me.chkSQLControledAdmin.Checked.ToString, boolImp, Me.ChkBxIsOnWebFarm.Checked.ToString().ToLower(), Me.ChkBxUseSysLogon.Checked.ToString, Me.TxtAdmDatabaseName.Text, IntTimeOut, AlertRefresh, Me.cboCustomErrors.Text, Me.Chk_NTAuth_UserCode_IgnoreCase.Checked)
        Catch
            MsgBox("Change settings failed!", MsgBoxStyle.Critical, "Change Settings")
        End Try
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
    Private Sub ChkBxIsOnWebFarm_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkBxIsOnWebFarm.CheckedChanged
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
    Private Sub ChkBxUseSysLogon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkBxUseSysLogon.CheckedChanged
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

        If chkChooseServer.Checked = False Then

            Me.XtraTabPageRegistry.PageVisible = True
            lblRegistryWarn.Visible = False
            FillRegistryPage()

        Else

            If Me.rbNTAuthentication.Checked = False Then

                'Me.XtraTabPageRegistry.PageVisible = False
                lblRegistryWarn.Visible = False

            End If

        End If

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
            Dim arData(20) As String        'array to hold data so we don't have to load single value. plus keep it a little cleaner looking
            Dim strPhysicalPathToWebConfig As String = Me.txtwebconfig1.Text.ToString

            myConfig.Load(strPhysicalPathToWebConfig) 'load the webconfig

            'Added by Adam Corriher Issue #143
            'Setup an Xml Namespace to read web.config values
            Dim nsmgr As XmlNamespaceManager = New XmlNamespaceManager(myConfig.NameTable)
            nsmgr.AddNamespace("web", "")
            Dim x As XmlNode
            Dim r As XmlElement = myConfig.DocumentElement
            'get the values from webconfig into form
            arData(0) = r.SelectSingleNode("//web:add[@key='Authentication']/@value", nsmgr).Value
            arData(8) = r.SelectSingleNode("//web:add[@key='SQLControledAdmin']/@value", nsmgr).Value
            arData(7) = r.SelectSingleNode("//web:add[@key='ChooseServer']/@value", nsmgr).Value
            arData(11) = r.SelectSingleNode("//web:add[@key='UpperCaseDatabase']/@value", nsmgr).Value
            arData(6) = r.SelectSingleNode("//web:add[@key='UpperCaseUser']/@value", nsmgr).Value
            arData(19) = r.SelectSingleNode("//web:add[@key='NTAuthIgnoreCase']/@value", nsmgr).Value

            If Me.SelectedApplication <> App.MobileDataservices Then

                arData(15) = r.SelectSingleNode("//web:add[@key='TimeOutUserInMinutes']/@value", nsmgr).Value
                arData(17) = r.SelectSingleNode("//web:add[@key='AlertRefresh']/@value", nsmgr).Value
                arData(18) = r.SelectSingleNode("//web:customErrors/@mode", nsmgr).Value
                arData(1) = r.SelectSingleNode("//web:add[@key='ReportServerPath']/@value", nsmgr).Value
                arData(9) = r.SelectSingleNode("//web:authentication/@mode", nsmgr).Value
                arData(10) = r.SelectSingleNode("//web:identity/@impersonate", nsmgr).Value

            End If
            'This authentication is also tied to impersonation when the value is written
            'choosing windows means rb is checked means impersonate is set to true!
            If arData(0) = "Windows" Then
                rbNTAuthentication.Checked = True
            Else
                rbSqlAuthentication.Checked = True
            End If

            'Me.txtConfigReportingServices.Text = arData(1).Substring(7, arData(1).Length - 21)

            Select Case Me.SelectedApplication
                Case App.Webvantage
                    Me.chkUpperCaseUser.Checked = CType(arData(6), Boolean)
                    Me.chkChooseServer.Checked = CType(arData(7), Boolean)
                Case App.ClientPortal
                Case App.MobileDataservices
                    Me.chkUpperCaseUser.Checked = CType(arData(6), Boolean)
                    Me.chkChooseServer.Checked = CType(arData(7), Boolean)
            End Select

            Me.chkSQLControledAdmin.Checked = CType(arData(8), Boolean)
            Me.chkUpperCaseDatabase.Checked = CType(arData(11), Boolean)
            Me.Chk_NTAuth_UserCode_IgnoreCase.Checked = CType(arData(19), Boolean)

            If Me.SelectedApplication <> App.MobileDataservices Then

                Me.TxtTimeOutMinutes.Text = arData(15)

                If arData(17) = "-1" Then

                    Me.TxtAlertRefresh.Text = "0"

                Else

                    If IsNumeric(arData(17)) Then

                        Me.TxtAlertRefresh.Text = CType(arData(17), Double) / 60 / 1000

                    Else

                        Me.TxtAlertRefresh.Text = "0"

                    End If

                End If

                Me.cboCustomErrors.SelectedIndex = Me.cboCustomErrors.FindString(arData(18))

            End If

        Catch

            MsgBox("Error reading web.config file. " & Err.Number & "  " & Err.Description)

        End Try
    End Sub
    Private Sub drpIISWebsite_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drpIISWebsite.SelectedIndexChanged
        If bnLoad = False Then
            ChangePhysicalDir()
        End If
    End Sub
    Private Sub tvRegistry_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvRegistry.AfterSelect

        If Not IsNothing(tvRegistry.SelectedNode.Tag.ToString) Then

            Dim aRegData() As String = Split(tvRegistry.SelectedNode.Tag.ToString, "\")

            If aRegData(aRegData.GetUpperBound(0) - 2) = BaseNode Then

                Me.txtRegistryServer.Text = aRegData(aRegData.GetUpperBound(0) - 1)
                Me.txtRegistryDatabase.Text = aRegData(aRegData.GetUpperBound(0))
                EntryEnable(True)
                tvRegistry.SelectedImageIndex = 1

            Else

                Me.txtRegistryServer.Text = aRegData(aRegData.GetUpperBound(0))
                Me.txtRegistryDatabase.Text = ""
                EntryEnable(False)
                tvRegistry.SelectedImageIndex = 0

            End If

            Me.txtRegistryServer.Text = Me.txtRegistryServer.Text.Replace("#", "\")

            If tvRegistry.SelectedNode.GetNodeCount(True) = 0 Then

                Try
                    Me.txtAdminUsername.Text = My.Computer.Registry.GetValue(tvRegistry.SelectedNode.Tag.ToString, "Username", Nothing).ToString
                    Me.txtAdminPassword.Text = Decrypt(My.Computer.Registry.GetValue(tvRegistry.SelectedNode.Tag.ToString, "Password", Nothing).ToString)

                Catch x As Exception
                    Me.txtAdminUsername.Text = ""
                    Me.txtAdminPassword.Text = ""
                    EntryEnable(False)
                End Try

            End If

        End If

        tvRegistry.ExpandAll()

    End Sub
    Private Function SetRegistryValue(ByVal Key As String, ByVal Value As String) As Boolean

        Try

            My.Computer.Registry.SetValue(Me.RegistryPath & Me.txtRegistryServer.Text.Replace("\", "#") & "\" & Me.txtRegistryDatabase.Text, Key, Value)
            My.Computer.Registry.SetValue(Me.RegistryPathWOW6432 & Me.txtRegistryServer.Text.Replace("\", "#") & "\" & Me.txtRegistryDatabase.Text, Key, Value)

            Return True

        Catch ex As Exception
            Return False
        End Try

    End Function
    Private Sub btnSaveRegistry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveRegistry.Click
        Try

            If Me.txtRegistryDatabase.Text.Length > 0 And Me.txtRegistryServer.Text.Length > 0 Then

                Me.SetRegistryValue("Username", Me.txtAdminUsername.Text)
                Me.SetRegistryValue("Password", AdvantageFramework.Security.Encryption.Encrypt(Me.txtAdminPassword.Text))

            Else

                MessageBox.Show("You must select a valid database")
                Exit Sub

            End If

        Catch x As Exception
            MessageBox.Show(x.Message, "Data was NOT saved!")
            Exit Sub
        Finally
        End Try

        FillRegistryPage()

        MessageBox.Show("Data saved!")

    End Sub
    Private Sub btnAddReg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddReg.Click

        If Me.txtRegistryDatabase.Text.Length > 0 And Me.txtRegistryServer.Text.Length > 0 Then

            Dim sServer As String = txtRegistryServer.Text.ToString.Replace("\", "#")
            Dim sDatabase As String = txtRegistryDatabase.Text.ToString.Replace("\", "#")

            If IsNothing(My.Computer.Registry.GetValue(Me.RegistryPath & sServer & "\" & sDatabase, "Username", Nothing)) Then

                Me.SetRegistryValue("Username", "")
                Me.SetRegistryValue("Password", "")

            Else

                MessageBox.Show("Server and Database are already added!")

            End If

        Else

            MessageBox.Show("You must have both a Server and a Database entered!")

        End If

        FillRegistryPage()
        tvRegistry.SelectedNode = GetNode(Me.txtRegistryServer.Text, Me.txtRegistryDatabase.Text, tvRegistry.Nodes)

    End Sub
    Private Sub btnDeleteReg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteReg.Click

        'Delete the 64 bit
        If Me.txtRegistryDatabase.Text.Length > 0 And Me.txtRegistryServer.Text.Length > 0 Then

            Try

                Dim oReg As Microsoft.Win32.RegistryKey

                oReg = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Advantage\" & Me.BaseNode & "\" & Me.txtRegistryServer.Text.Replace("\", "#"), True)
                oReg.DeleteSubKeyTree(Me.txtRegistryDatabase.Text)
                oReg.Close()

            Catch x As Exception
                MessageBox.Show(x.Message.ToString, "Unable to delete.")
            End Try

        Else

            If Me.txtRegistryServer.Text.Length > 0 Then

                Try

                    Dim oReg As Microsoft.Win32.RegistryKey

                    oReg = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Advantage\" & Me.BaseNode, True)
                    oReg.DeleteSubKeyTree(Me.txtRegistryServer.Text.Replace("\", "#"))
                    oReg.Close()

                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString, "Unable to delete.")
                End Try

            End If

        End If
        'Delete 32 bit WOW
        If Me.txtRegistryDatabase.Text.Length > 0 AndAlso Me.txtRegistryServer.Text.Length > 0 Then

            Try

                Dim oReg As Microsoft.Win32.RegistryKey

                oReg = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\WOW6432Node\Advantage\" & Me.BaseNode & "\" & Me.txtRegistryServer.Text.Replace("\", "#"), True)
                oReg.DeleteSubKeyTree(Me.txtRegistryDatabase.Text)
                oReg.Close()

            Catch x As Exception
                MessageBox.Show(x.Message.ToString, "Unable to delete.")
            End Try

        Else

            If Me.txtRegistryServer.Text.Length > 0 Then

                Try

                    Dim oReg As Microsoft.Win32.RegistryKey

                    oReg = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\WOW6432Node\Advantage\" & Me.BaseNode, True)
                    oReg.DeleteSubKeyTree(Me.txtRegistryServer.Text.Replace("\", "#"))
                    oReg.Close()

                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString, "Unable to delete.")
                End Try
            End If

        End If

        'Reload
        FillRegistryPage()
        Me.txtRegistryServer.Text = ""
        Me.txtRegistryDatabase.Text = ""
        EntryEnable(False)

    End Sub
    Private Sub btnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreate.Click
        btnCreate.Enabled = False
        Me.Cursor = Cursors.WaitCursor
        Dim strURL As String = Me.txtURL.Text
        Process.Start(strURL)
        If MessageBox.Show("Has the website started?", "Starting Web Site", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
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

        If Me.rbNTAuthentication.Checked = True Then

            Me.Chk_NTAuth_UserCode_IgnoreCase.Enabled = True
            Me.XtraTabPageRegistry.PageVisible = True
            lblRegistryWarn.Visible = False

            FillRegistryPage()

        Else

            Me.Chk_NTAuth_UserCode_IgnoreCase.Checked = False
            Me.Chk_NTAuth_UserCode_IgnoreCase.Enabled = False
            If chkChooseServer.Checked = True Then

                'Me.XtraTabPageRegistry.PageVisible = False
                lblRegistryWarn.Visible = True

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
        ' Dim sSystem32Directory As String = System.Environment.ExpandEnvironmentVariables("%SystemRoot%\System32")

        Try
            Dim Exists As Boolean = False
            If is64Bit() = True Then
                Dim sSystem32Directory As String = System.Environment.ExpandEnvironmentVariables("%SystemRoot%")
                Try
                    File.Copy(Windows.Forms.Application.StartupPath & "\SMTP\Mailbee64.dll", sSystem32Directory & "\System32\Mailbee64.dll")
                    Exists = True
                Catch ex As Exception

                    If ex.Message.ToString().Contains("already exists") Then
                        'MsgBox("DLL is already in System32 directory")
                        Exists = True
                    Else
                        Exists = False
                        MsgBox(ex.Message.ToString())
                    End If

                End Try
                Try
                    If Exists = True Then
                        Process.Start("Regsvr32.exe", sSystem32Directory & "\System32\Mailbee64.dll")
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message.ToString())
                End Try
                Exists = False
                Try

                    File.Copy(Windows.Forms.Application.StartupPath & "\SMTP\Mailbee.dll", sSystem32Directory & "\SysWow64\Mailbee.dll")
                    Exists = True

                Catch ex As Exception

                    If ex.Message.ToString().Contains("already exists") Then
                        'MsgBox("DLL is already in SysWow64 directory")
                        Exists = True
                    Else
                        MsgBox(ex.Message.ToString())
                        Exists = False
                    End If

                End Try
                Try

                    If Exists = True Then
                        Process.Start("Regsvr32.exe", sSystem32Directory & "\SysWow64\Mailbee.dll")
                    End If

                Catch ex As Exception
                    MsgBox(ex.Message.ToString())

                End Try
            Else
                Exists = False
                Dim sSystem32Directory As String = System.Environment.ExpandEnvironmentVariables("%SystemRoot%")
                Try

                    File.Copy(Windows.Forms.Application.StartupPath & "\SMTP\Mailbee.dll", sSystem32Directory & "\System32\Mailbee.dll")
                    Exists = True

                Catch ex As Exception

                    If ex.Message.ToString().Contains("already exists") Then
                        Exists = True
                        'MsgBox("DLL is already in System32 directory")
                    Else
                        Exists = False
                        MsgBox(ex.Message.ToString())
                    End If

                End Try
                Try

                    If Exists = True Then

                        Process.Start("Regsvr32.exe", sSystem32Directory & "\System32\Mailbee.dll")

                    End If

                Catch ex As Exception

                    MsgBox(ex.Message.ToString())

                End Try

            End If

        Catch x As Exception

            MsgBox(x.Message.ToString())

        End Try
    End Sub
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

#End Region
#Region " Form "

    Private Sub frmWebConfig_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        DebugPrint("Debug mode is ON you can turn it off via Configurator.Config file")

        Try

            Me.ButtonSetMachineConfig.Enabled = Me.MachineConfigNeedsUpdating()

        Catch ex As Exception
        End Try

        Me.XtraTabPageSMTP.PageVisible = False

        Try
            Select Case Me.SelectedApplication
                Case App.ClientPortal

                    Me.Text = "Configure Client Portal"
                    Me.txtVirtualDirectory.Text = "clientportal"
                    Me.GroupControlVirtualDirectory.Text = "Client Portal Virtual Directory"
                    Me.chkVirtualDirectory.Text = "Create Client Portal Virtual Directory"
                    Me.chkUpperCaseUser.Visible = False
                    Me.chkChooseServer.Checked = False
                    Me.chkChooseServer.Visible = False
                    Me.Label30.Text = "Enter URL for Client Portal:"
                    Me.Label13.Text = "Location of the Client Portal web.config file:"
                    Me.chkSQLControledAdmin.Visible = False
                    Me.GroupControlAuthentication.Visible = False
                    Me.XtraTabPageDatabase.PageVisible = False
                    Me.XtraTabPageWebServices.PageVisible = False

                Case App.MobileDataservices

                    Me.Text = "Configure Proofing"

                    Me.txtVirtualDirectory.Text = "Webvantage.Angular"
                    Me.GroupControlVirtualDirectory.Text = "Proofing Virtual Directory"
                    Me.chkVirtualDirectory.Text = "Create Proofing Virtual Directory"
                    Me.chkUpperCaseUser.Visible = True
                    Me.chkChooseServer.Checked = True
                    Me.chkChooseServer.Visible = True
                    Me.Label30.Text = "Enter URL for Proofing:"
                    Me.Label13.Text = "Location of the Proofing web.config file:"
                    Me.chkSQLControledAdmin.Visible = True
                    Me.GroupControlAuthentication.Visible = True
                    Me.XtraTabPageWebServices.PageVisible = False

                    'Me.LabelIISTimeOut.Visible = False
                    'Me.txtSessionTimeout.Visible = False
                    Me.LabelTimeOut.Visible = False
                    Me.TxtTimeOutMinutes.Visible = False

                    Me._EventSource = "Adv Dataservice Message"

                Case App.Webvantage

                    Me.Text = "Configure Webvantage"
                    Me.GroupControlVirtualDirectory.Text = "Webvantage Virtual Directory"

            End Select

            Me.rbWIA.Checked = True
            Me.txtUserName.Enabled = False
            Me.txtPassword.Enabled = False
            Me.txtPhysicalPath.Text = Me.drpIISWebsite.SelectedValue & "\" & Me.txtVirtualDirectory.Text
            txtwebconfig1.Text = Me.drpIISWebsite.SelectedValue & "\" & Me.txtVirtualDirectory.Text

        Catch ex As Exception
        End Try
        Try

            If chkChooseServer.Checked = False Then

                lblRegistryWarn.Visible = False
                Me.XtraTabPageRegistry.PageVisible = True
                FillRegistryPage()

            Else

                lblRegistryWarn.Visible = True
                'Me.XtraTabPageRegistry.PageVisible = False

            End If
        Catch ex As Exception
        End Try

        Me.XtraTabPageDatabase.PageVisible = True
        Me.XtraTabPageRegistry.PageVisible = False
        Me.XtraTabPageApplication.PageVisible = False
        lblRegistryWarn.Visible = False

        FillRegistryPage()

        Dim NETVersion As String = ListNETVersions()

        Me.LabelNETVersion.Text = "Latest .NET Runtime " & NETVersion

        CreateProofingEventLog()

        Me.ButtonCreateProofingEventLog.Visible = False
        Me.ButtonInstallNETCoreRuntime.Visible = False

        'If System.Diagnostics.EventLog.SourceExists(_ProofingEventSource) = False Then

        '    Me.ButtonCreateProofingEventLog.Enabled = True

        'Else

        '    Me.ButtonCreateProofingEventLog.Enabled = False

        'End If

        'Try

        '    Me.ButtonCreateProofingEventLog.Enabled = System.Diagnostics.EventLog.SourceExists(_ProofingEventSource) = False

        'Catch ex As Exception
        '    Me.ButtonCreateProofingEventLog.Enabled = True
        'End Try

        'If ListNETVersions().Contains("5.0.9") = False Then

        '    MsgBox("Please go to the 'System' tab and install the .NET Core Runtime")
        '    Me.ButtonInstallNETCoreRuntime.Enabled = True

        'Else

        Me.ButtonInstallNETCoreRuntime.Enabled = False

        'End If


    End Sub
    Private Sub frmWebConfig_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        Windows.Forms.Application.Exit()
    End Sub

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
                StrCmdLine = Windows.Forms.Application.StartupPath & "\disco " & StrWVURL ' " & Chr(34) & StrWVURL & Chr(34)
                Dim p As Process = Process.Start(StrCmdLine)
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString() & Environment.NewLine & StrCmdLine, MsgBoxStyle.OkOnly, "Disco did not run")
        End Try
    End Sub
    Public Sub FillRegistryPage()
        Try
            tvRegistry.Nodes.Clear()
            PopulateTreeView(0, Nothing)
            tvRegistry.ExpandAll()

        Catch ex As Exception

        End Try
    End Sub
    Public Sub PopulateTreeView(ByVal iParentID As Integer, ByVal oTreeNode As TreeNode)

        Try

            If is64Bit() = False Then

                Dim regkey As RegistryKey = My.Computer.Registry.LocalMachine.OpenSubKey("Software\Advantage\" & Me.BaseNode)

                Try

                    GetSubKeys(regkey, iParentID, oTreeNode)
                    regkey.Close()

                Catch x As Exception
                End Try

            Else '\WOW6432Node

                Dim regkey As RegistryKey = My.Computer.Registry.LocalMachine.OpenSubKey("Software\WOW6432Node\Advantage\" & Me.BaseNode)

                Try

                    GetSubKeys(regkey, iParentID, oTreeNode)
                    regkey.Close()

                Catch x As Exception
                End Try

            End If

        Catch ex As Exception
        End Try

    End Sub
    Public Sub GetSubKeys(ByVal rkey As RegistryKey, ByVal iParentID As Integer, ByVal oTreeNode As TreeNode)
        ' Retrieve all the subkeys for the specified key and there value
        ' name and values
        Try

            Dim names As String() = rkey.GetSubKeyNames()
            Dim subkey As String = String.Empty

            tvRegistry.ImageList = Me.TreeViewImageList

            For Each subkey In names

                Dim regkey As RegistryKey
                regkey = rkey.OpenSubKey(subkey)

                If IsNothing(oTreeNode) Then

                    oTreeNode = tvRegistry.Nodes.Add(subkey.Replace("#", "\"))
                    oTreeNode.Tag = regkey.Name.ToString
                    oTreeNode.ImageIndex = 0

                Else

                    oTreeNode = oTreeNode.Nodes.Add(subkey.Replace("#", "\"))
                    oTreeNode.Tag = regkey.Name.ToString
                    oTreeNode.ImageIndex = 1

                End If

                GetSubKeys(regkey, iParentID, oTreeNode)

                regkey.Close()
                oTreeNode = oTreeNode.Parent

            Next subkey

        Catch x As Exception
            'no items in nodes.
        End Try
    End Sub
    Public Sub DebugPrint(ByVal sMessage As String)
        Try
            Dim isInDebugMode As Boolean = CBool(System.Configuration.ConfigurationManager.AppSettings("DEBUG"))
            If isInDebugMode = True Then
                MessageBox.Show(sMessage, "DEBUG", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
        End Try
    End Sub
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
                    MessageBox.Show(E.Message, "Error")
                End Try
            Next

            Dim DirectoryName As DirectoryInfo

            For Each DirectoryName In Dirs
                Try
                    ProcessTree(DirectoryName.FullName)
                Catch E As Exception
                    Console.WriteLine("Error accessing {0}", DirectoryName.FullName)
                    Console.WriteLine("Error: {0}", E.Message)
                    MessageBox.Show(E.Message, "Error")
                End Try
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error")
        End Try
    End Sub
    Public Function CopyDirectory(ByVal source As String, ByVal destination As String)
        Try

            Dim currentDirectory As DirectoryInfo = New DirectoryInfo(source)
            Dim file As FileInfo

            For Each file In currentDirectory.GetFiles()

                Me.lblProgress.Text = "Copying: " & Path.Combine(destination, file.Name).ToString
                Windows.Forms.Application.DoEvents()
                file.CopyTo(Path.Combine(destination, file.Name), True)

            Next

            Dim di As DirectoryInfo

            For Each di In currentDirectory.GetDirectories()

                Dim subDirectory As String = Path.Combine(destination, di.Name)
                Directory.CreateDirectory(subDirectory)
                CopyDirectory(di.FullName, subDirectory)

            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Copying Directory")
        End Try

    End Function
    Public Function CopyDirectoryCP(ByVal source As String, ByVal destination As String)
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
                   file.Name.Contains("Resources") = False And
                   file.Name.Contains("Timesheet") = False And
                   file.Name.Contains("VendorQuote") = False And
                   file.Name.Contains("Campaign") = False And
                   file.Name.Contains("DirectTime") = False And
                   file.Name.Contains("MySettings") = False And
                   file.Name.Contains("Security") = False And
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
                   file.Name.Contains("InOutBoard") = False And
                   file.Name.Contains("JobStatistics") = False And
                   file.Name.Contains("QvA") = False And
                   file.Name.Contains("agencyGoals") = False And
                   file.Name.Contains("arcashforecast") = False And
                   file.Name.Contains("billing_trends") = False And
                   file.Name.Contains("clientaging") = False And
                   file.Name.Contains("currentratio") = False And
                   file.Name.Contains("inoutboard") = False And
                   file.Name.Contains("qva") = False And
                   file.Name.Contains("np_time_emp") = False And
                   file.Name.Contains("PurchaseOrder") = False And
                   file.Name.Contains("purchaseOrder") = False Then
                    Me.lblProgress.Text = "Copying: " & Path.Combine(destination, file.Name).ToString
                    Windows.Forms.Application.DoEvents()
                    file.CopyTo(Path.Combine(destination, file.Name), True)
                End If
            Next
            Dim di As DirectoryInfo
            For Each di In currentDirectory.GetDirectories()
                Dim subDirectory As String = Path.Combine(destination, di.Name)
                Directory.CreateDirectory(subDirectory)
                CopyDirectoryCP(di.FullName, subDirectory)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Copying Directory")
        End Try
    End Function
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
            MessageBox.Show(ex.Message, "Error Stopping IIS")
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
            MessageBox.Show(ex.Message, "Error Starting IIS")
            Return False
        End Try
    End Function

    Private Sub IISAddMimeType(ByVal ExtensionToAdd As String, ByVal MimeTypeToAdd As String)
        Dim serverManager As ServerManager = New ServerManager
        Dim config As Configuration = serverManager.GetWebConfiguration(oWebSites(Me.drpIISWebsite.SelectedIndex).Name)
        Dim staticContentSection As ConfigurationSection = config.GetSection("system.webServer/staticContent")
        Dim staticContentCollection As ConfigurationElementCollection = staticContentSection.GetCollection

        ' Check to see if the mime type already exists
        For Each MimeType In staticContentCollection
            If MimeType("fileExtension") = "." + ExtensionToAdd Then
                Return
            End If
        Next

        ' add the new mime type
        Try

            Dim mimeMapElement As ConfigurationElement = staticContentCollection.CreateElement("mimeMap")
            mimeMapElement("fileExtension") = ExtensionToAdd
            mimeMapElement("mimeType") = MimeTypeToAdd
            staticContentCollection.Add(mimeMapElement)
        Catch ex As Exception
            'hopefully it just already exists
        End Try

        ' save the changes
        serverManager.CommitChanges()
    End Sub
    
    'Public Function SetACEPermissions(ByVal sPhysicalPath As String, ByVal strConnString As String) As Boolean
    '    Try
    '        Dim sUser As String = ""
    '        Dim bReturn = True
    '        Dim Directories() As String '= Split(System.Configuration.ConfigurationManager.AppSettings("ACEs"), ",")

    '        If Me.SelectedApplication = App.MobileDataservices Then

    '            Directories = Split(System.Configuration.ConfigurationManager.AppSettings("ACEsMobileData"), ",")

    '        Else

    '            Directories = Split(System.Configuration.ConfigurationManager.AppSettings("ACEs"), ",")

    '        End If

    '        For Each Folder As String In Directories

    '            If Folder IsNot Nothing AndAlso Folder.Length > 0 Then

    '                Try

    '                    Dim oApplication As New cApplication(strConnString)

    '                    DebugPrint("SetACEPermissions on : " & Folder)

    '                    If frmWelcome.CheckVersionOfIIS().StartsWith("7") OrElse frmWelcome.CheckVersionOfIIS().StartsWith("8") OrElse frmWelcome.CheckVersionOfIIS().StartsWith("9") Then

    '                        sUser = System.Configuration.ConfigurationManager.AppSettings("FileRightsUser2008".ToString())

    '                    Else

    '                        sUser = System.Environment.MachineName & "\" & System.Configuration.ConfigurationManager.AppSettings("FileRightsUser2003".ToString())

    '                    End If

    '                    oApplication.AddDirectorySecurity(sPhysicalPath & "\" & Folder, sUser, Security.AccessControl.FileSystemRights.FullControl, Security.AccessControl.AccessControlType.Allow)

    '                Catch ex As Exception

    '                    MsgBox("Folder: " & Folder & Environment.NewLine & ex.Message.ToString(), MsgBoxStyle.OkOnly, "Error Setting Permissions")
    '                    bReturn = False

    '                End Try

    '            End If

    '        Next

    '        Return bReturn

    '    Catch ex As Exception

    '        MsgBox("SetACEPermissions" & Environment.NewLine & ex.Message.ToString(), MsgBoxStyle.OkOnly, "Error Setting Permissions")
    '        Return False

    '    End Try
    'End Function
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
                        oWebSite.WebSitePath = child.Path.ToString() & "/Root"
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
            End Try
        Catch ex As Exception
        End Try
    End Sub
    Public Sub writeAppSettings(ByVal strPhysicalPathToWebConfig As String,
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
                                    ByVal boolNTAuthIgnoreCase As Boolean)

        Try

            Try

                Dim attribute As System.IO.FileAttributes = FileAttributes.Normal
                File.SetAttributes("strPhysicalPathToWebConfig", attribute)

            Catch eError As Exception
                'couldnt set file to normal
            End Try

            Dim myConfig As New XmlDocument
            Dim myAttribute As XmlAttribute

            'Added code by Adam Corriher Issue #143
            'Setup an Xml Namespace to write web.config values

            myConfig.Load(strPhysicalPathToWebConfig)
            Dim nsmgr As XmlNamespaceManager = New XmlNamespaceManager(myConfig.NameTable)
            nsmgr.AddNamespace("web", "")
            Dim x As XmlNode
            Dim r As XmlElement = myConfig.DocumentElement

            'appSettings section
            myAttribute = r.SelectSingleNode("//web:add[@key='Authentication']/@value", nsmgr)
            If myAttribute IsNot Nothing Then myAttribute.Value = strAuthentication

            myAttribute = r.SelectSingleNode("//web:add[@key='UpperCaseUser']/@value", nsmgr)
            If myAttribute IsNot Nothing Then myAttribute.Value = boolUpperCaseUser.ToString().ToLower()

            myAttribute = r.SelectSingleNode("//web:add[@key='UpperCaseDatabase']/@value", nsmgr)
            If myAttribute IsNot Nothing Then myAttribute.Value = boolUpperCaseDatabase.ToString().ToLower()

            myAttribute = r.SelectSingleNode("//web:add[@key='ChooseServer']/@value", nsmgr)
            If myAttribute IsNot Nothing Then myAttribute.Value = boolChooseServer.ToString().ToLower()

            myAttribute = r.SelectSingleNode("//web:add[@key='SQLControledAdmin']/@value", nsmgr)
            If myAttribute IsNot Nothing Then myAttribute.Value = boolSQLControledAdmin.ToString().ToLower()

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
            If myAttribute IsNot Nothing Then myAttribute.Value = IntTimeoutMinutes.ToString()

            myAttribute = r.SelectSingleNode("//web:sessionState/@timeout", nsmgr)
            If myAttribute IsNot Nothing Then myAttribute.Value = IntTimeoutMinutes.ToString()

            myAttribute = r.SelectSingleNode("//web:compilation/@debug", nsmgr)
            If myAttribute IsNot Nothing Then myAttribute.Value = "false"

            If String.IsNullOrWhiteSpace(strCustomErrorsMode) = False Then

                If strCustomErrorsMode = "On" OrElse strCustomErrorsMode = "Off" OrElse strCustomErrorsMode = "RemoteOnly" Then

                    myAttribute = r.SelectSingleNode("//web:customErrors/@mode", nsmgr)
                    If myAttribute IsNot Nothing Then myAttribute.Value = strCustomErrorsMode

                Else

                    myAttribute = r.SelectSingleNode("//web:customErrors/@mode", nsmgr)
                    If myAttribute IsNot Nothing Then myAttribute.Value = "Off"

                End If

            Else

                myAttribute = r.SelectSingleNode("//web:customErrors/@mode", nsmgr)
                If myAttribute IsNot Nothing Then myAttribute.Value = "Off"

            End If

            myAttribute = r.SelectSingleNode("//web:add[@key='AlertRefresh']/@value", nsmgr)
            If myAttribute IsNot Nothing Then myAttribute.Value = AlertRefresh.ToString()

            myAttribute = r.SelectSingleNode("//web:add[@key='NTAuthIgnoreCase']/@value", nsmgr)
            If myAttribute IsNot Nothing Then myAttribute.Value = boolNTAuthIgnoreCase.ToString().ToLower()

            Select Case SelectedApplication
                Case App.MobileDataservices

                    'If strAuthentication = "Forms" Then

                    myAttribute = r.SelectSingleNode("//web:identity/@impersonate", nsmgr)
                    If myAttribute IsNot Nothing Then myAttribute.Value = "false"
                    myAttribute = r.SelectSingleNode("//web:anonymousAuthentication/@enabled", nsmgr)
                    If myAttribute IsNot Nothing Then myAttribute.Value = "true"
                    myAttribute = r.SelectSingleNode("//web:basicAuthentication/@enabled", nsmgr)
                    If myAttribute IsNot Nothing Then myAttribute.Value = "false"

                    'Else

                    '    myAttribute = r.SelectSingleNode("//web:identity/@impersonate", nsmgr)
                    '    If myAttribute IsNot Nothing Then myAttribute.Value = "true"
                    '    myAttribute = r.SelectSingleNode("//web:anonymousAuthentication/@enabled", nsmgr)
                    '    If myAttribute IsNot Nothing Then myAttribute.Value = "false"
                    '    myAttribute = r.SelectSingleNode("//web:basicAuthentication/@enabled", nsmgr)
                    '    If myAttribute IsNot Nothing Then myAttribute.Value = "true"

                    'End If

            End Select

            myConfig.Save(strPhysicalPathToWebConfig)

            MsgBox("Settings saved to web.config!", MsgBoxStyle.OkOnly, "Configurator")

        Catch ex As Exception

            MsgBox("Error writing to web.config!" & vbCrLf & ex.Message.ToString)
            Throw ex
        Finally

        End Try
    End Sub
    Public Sub EntryEnable(ByVal bSwitch)

        If bSwitch = True Then

            Me.txtAdminUsername.Enabled = True
            Me.txtAdminPassword.Enabled = True

        Else

            Me.txtAdminUsername.Enabled = False
            Me.txtAdminPassword.Enabled = False

        End If

    End Sub
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
                ProcessProperties.Arguments = "/out:" & Me.txtPhysicalPath.Text & " " & strURL & "/GetRepositoryDoc.asmx"
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
            MessageBox.Show("Error: " & x.Message, "Error")
        End Try
    End Function
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

    Private Function UpdateBaseHREF()
        Dim FilePath As String
        Dim Line As String

        FilePath = Me.txtPhysicalPath.Text.Trim & "\ClientApp\dist\index.html"

        My.Computer.FileSystem.RenameFile(FilePath, "index.html.temp")

        Using reader As StreamReader = New StreamReader(FilePath & ".temp")
            Using writer As StreamWriter = New StreamWriter(FilePath)
                Line = reader.ReadLine()
                While Line IsNot Nothing

                    If (Line.Contains("<base href=")) Then
                        Line = vbTab & vbTab & "<base href=""/" & Me.txtVirtualDirectory.Text.Trim & "/"">"
                    End If

                    writer.WriteLine(Line)

                    Line = reader.ReadLine()
                End While

            End Using
        End Using

        My.Computer.FileSystem.DeleteFile(FilePath & ".temp")

    End Function

    Private Sub ButtonCreateProofingEventLog_Click(sender As Object, e As EventArgs) Handles ButtonCreateProofingEventLog.Click

        Try

            System.Diagnostics.EventLog.CreateEventSource(_ProofingEventSource, _ProofingEventLogName)
            Me.ButtonCreateProofingEventLog.Enabled = False

        Catch ex As Exception
            MsgBox("Error creating Proofing Event Log:" & Environment.NewLine & ex.Message.ToString())
        End Try

    End Sub

    Private Sub CreateProofingEventLog()

        If System.Diagnostics.EventLog.SourceExists(_ProofingEventSource) = False Then

            Try

                System.Diagnostics.EventLog.CreateEventSource(_ProofingEventSource, _ProofingEventLogName)

            Catch ex As Exception
                MsgBox("Error creating Proofing Event Log:" & Environment.NewLine & ex.Message.ToString())
            End Try

        End If

    End Sub

#Region " Install .NET Hosting Bundle "

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
    Private Sub ButtonInstallNETCoreRuntime_Click(sender As Object, e As EventArgs) Handles ButtonInstallNETCoreRuntime.Click

        Dim startInfo As ProcessStartInfo = New ProcessStartInfo()

        startInfo.FileName = My.Application.Info.DirectoryPath.Replace("bin", "") & "\Resources\dotnet-hosting-5.0.9-win.exe"
        Process.Start(startInfo)

    End Sub


#End Region

#End Region

End Class
