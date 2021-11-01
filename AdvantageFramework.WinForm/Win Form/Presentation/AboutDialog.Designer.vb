Namespace WinForm.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AboutDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AboutDialog))
            Me.LabelForm_CollationMessage = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Description = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Copyright = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_SoftwareVersion = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Application = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_WVUsers = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_WVUsersConnected = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_PowerUsersConnected = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_PowerUsers = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_User = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Agency = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_DatabaseName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_CPUsersConnected = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_CPUsers = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_ApplicationHeader = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_VersionDescription = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_WebvantageDatabaseVersion = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_AdvantageDatabaseVersion = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_LastDatabaseUpdate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_ServerName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_SQLServerAppName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Locale = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_MediaToolsUsers = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_APIUsers = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_ProofingToolEnabled = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SuspendLayout()
            '
            'LabelForm_CollationMessage
            '
            Me.LabelForm_CollationMessage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_CollationMessage.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_CollationMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_CollationMessage.ForeColor = System.Drawing.SystemColors.HotTrack
            Me.LabelForm_CollationMessage.Location = New System.Drawing.Point(12, 246)
            Me.LabelForm_CollationMessage.Name = "LabelForm_CollationMessage"
            Me.LabelForm_CollationMessage.Size = New System.Drawing.Size(454, 20)
            Me.LabelForm_CollationMessage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_CollationMessage.TabIndex = 5
            '
            'LabelForm_Description
            '
            Me.LabelForm_Description.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_Description.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Description.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Description.ForeColor = System.Drawing.SystemColors.HotTrack
            Me.LabelForm_Description.Location = New System.Drawing.Point(12, 194)
            Me.LabelForm_Description.Name = "LabelForm_Description"
            Me.LabelForm_Description.Size = New System.Drawing.Size(454, 20)
            Me.LabelForm_Description.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Description.TabIndex = 4
            Me.LabelForm_Description.Text = "Description: {0}"
            '
            'LabelForm_Copyright
            '
            Me.LabelForm_Copyright.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_Copyright.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Copyright.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Copyright.ForeColor = System.Drawing.SystemColors.HotTrack
            Me.LabelForm_Copyright.Location = New System.Drawing.Point(12, 220)
            Me.LabelForm_Copyright.Name = "LabelForm_Copyright"
            Me.LabelForm_Copyright.Size = New System.Drawing.Size(454, 20)
            Me.LabelForm_Copyright.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Copyright.TabIndex = 3
            '
            'LabelForm_SoftwareVersion
            '
            Me.LabelForm_SoftwareVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_SoftwareVersion.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_SoftwareVersion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_SoftwareVersion.ForeColor = System.Drawing.SystemColors.HotTrack
            Me.LabelForm_SoftwareVersion.Location = New System.Drawing.Point(472, 298)
            Me.LabelForm_SoftwareVersion.Name = "LabelForm_SoftwareVersion"
            Me.LabelForm_SoftwareVersion.Size = New System.Drawing.Size(305, 20)
            Me.LabelForm_SoftwareVersion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_SoftwareVersion.TabIndex = 2
            Me.LabelForm_SoftwareVersion.Text = "Software Version: {0}"
            '
            'LabelForm_Application
            '
            Me.LabelForm_Application.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_Application.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Application.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Application.ForeColor = System.Drawing.SystemColors.HotTrack
            Me.LabelForm_Application.Location = New System.Drawing.Point(12, 168)
            Me.LabelForm_Application.Name = "LabelForm_Application"
            Me.LabelForm_Application.Size = New System.Drawing.Size(454, 20)
            Me.LabelForm_Application.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Application.TabIndex = 1
            Me.LabelForm_Application.Text = "Application: {0}"
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(702, 506)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 0
            Me.ButtonForm_OK.Text = "OK"
            '
            'LabelForm_WVUsers
            '
            Me.LabelForm_WVUsers.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_WVUsers.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_WVUsers.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_WVUsers.ForeColor = System.Drawing.SystemColors.HotTrack
            Me.LabelForm_WVUsers.Location = New System.Drawing.Point(472, 116)
            Me.LabelForm_WVUsers.Name = "LabelForm_WVUsers"
            Me.LabelForm_WVUsers.Size = New System.Drawing.Size(305, 20)
            Me.LabelForm_WVUsers.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_WVUsers.TabIndex = 7
            Me.LabelForm_WVUsers.Text = "WV Users: {0}"
            '
            'LabelForm_WVUsersConnected
            '
            Me.LabelForm_WVUsersConnected.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_WVUsersConnected.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_WVUsersConnected.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_WVUsersConnected.ForeColor = System.Drawing.SystemColors.HotTrack
            Me.LabelForm_WVUsersConnected.Location = New System.Drawing.Point(472, 142)
            Me.LabelForm_WVUsersConnected.Name = "LabelForm_WVUsersConnected"
            Me.LabelForm_WVUsersConnected.Size = New System.Drawing.Size(305, 20)
            Me.LabelForm_WVUsersConnected.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_WVUsersConnected.TabIndex = 8
            Me.LabelForm_WVUsersConnected.Text = "<a name=""WVUserConnected"">Connected</a>: {0}"
            '
            'LabelForm_PowerUsersConnected
            '
            Me.LabelForm_PowerUsersConnected.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_PowerUsersConnected.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_PowerUsersConnected.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_PowerUsersConnected.ForeColor = System.Drawing.SystemColors.HotTrack
            Me.LabelForm_PowerUsersConnected.Location = New System.Drawing.Point(472, 90)
            Me.LabelForm_PowerUsersConnected.Name = "LabelForm_PowerUsersConnected"
            Me.LabelForm_PowerUsersConnected.Size = New System.Drawing.Size(305, 20)
            Me.LabelForm_PowerUsersConnected.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_PowerUsersConnected.TabIndex = 10
            Me.LabelForm_PowerUsersConnected.Text = "<a name=""PowerUserConnected"">Connected</a>: {0}"
            '
            'LabelForm_PowerUsers
            '
            Me.LabelForm_PowerUsers.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_PowerUsers.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_PowerUsers.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_PowerUsers.ForeColor = System.Drawing.SystemColors.HotTrack
            Me.LabelForm_PowerUsers.Location = New System.Drawing.Point(472, 64)
            Me.LabelForm_PowerUsers.Name = "LabelForm_PowerUsers"
            Me.LabelForm_PowerUsers.Size = New System.Drawing.Size(305, 20)
            Me.LabelForm_PowerUsers.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_PowerUsers.TabIndex = 9
            Me.LabelForm_PowerUsers.Text = "Power Users: {0}"
            '
            'LabelForm_User
            '
            Me.LabelForm_User.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_User.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_User.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_User.ForeColor = System.Drawing.SystemColors.HotTrack
            Me.LabelForm_User.Location = New System.Drawing.Point(12, 480)
            Me.LabelForm_User.Name = "LabelForm_User"
            Me.LabelForm_User.Size = New System.Drawing.Size(454, 20)
            Me.LabelForm_User.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_User.TabIndex = 11
            Me.LabelForm_User.Text = "User: {0}"
            '
            'LabelForm_Agency
            '
            Me.LabelForm_Agency.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_Agency.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Agency.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Agency.ForeColor = System.Drawing.SystemColors.HotTrack
            Me.LabelForm_Agency.Location = New System.Drawing.Point(472, 38)
            Me.LabelForm_Agency.Name = "LabelForm_Agency"
            Me.LabelForm_Agency.Size = New System.Drawing.Size(305, 20)
            Me.LabelForm_Agency.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Agency.TabIndex = 12
            Me.LabelForm_Agency.Text = "Agency: {0}"
            Me.LabelForm_Agency.UseMnemonic = False
            '
            'LabelForm_DatabaseName
            '
            Me.LabelForm_DatabaseName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_DatabaseName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_DatabaseName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_DatabaseName.ForeColor = System.Drawing.SystemColors.HotTrack
            Me.LabelForm_DatabaseName.Location = New System.Drawing.Point(472, 428)
            Me.LabelForm_DatabaseName.Name = "LabelForm_DatabaseName"
            Me.LabelForm_DatabaseName.Size = New System.Drawing.Size(305, 20)
            Me.LabelForm_DatabaseName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_DatabaseName.TabIndex = 13
            Me.LabelForm_DatabaseName.Text = "Database Name: {0}"
            '
            'LabelForm_CPUsersConnected
            '
            Me.LabelForm_CPUsersConnected.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_CPUsersConnected.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_CPUsersConnected.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_CPUsersConnected.ForeColor = System.Drawing.SystemColors.HotTrack
            Me.LabelForm_CPUsersConnected.Location = New System.Drawing.Point(472, 194)
            Me.LabelForm_CPUsersConnected.Name = "LabelForm_CPUsersConnected"
            Me.LabelForm_CPUsersConnected.Size = New System.Drawing.Size(305, 20)
            Me.LabelForm_CPUsersConnected.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_CPUsersConnected.TabIndex = 15
            Me.LabelForm_CPUsersConnected.Text = "<a name=""CPUserConnected"">Connected</a>: {0}"
            '
            'LabelForm_CPUsers
            '
            Me.LabelForm_CPUsers.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_CPUsers.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_CPUsers.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_CPUsers.ForeColor = System.Drawing.SystemColors.HotTrack
            Me.LabelForm_CPUsers.Location = New System.Drawing.Point(472, 168)
            Me.LabelForm_CPUsers.Name = "LabelForm_CPUsers"
            Me.LabelForm_CPUsers.Size = New System.Drawing.Size(305, 20)
            Me.LabelForm_CPUsers.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_CPUsers.TabIndex = 14
            Me.LabelForm_CPUsers.Text = "CP Users: {0}"
            '
            'LabelForm_ApplicationHeader
            '
            Me.LabelForm_ApplicationHeader.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_ApplicationHeader.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_ApplicationHeader.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_ApplicationHeader.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_ApplicationHeader.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_ApplicationHeader.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_ApplicationHeader.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_ApplicationHeader.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_ApplicationHeader.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_ApplicationHeader.Location = New System.Drawing.Point(472, 12)
            Me.LabelForm_ApplicationHeader.Name = "LabelForm_ApplicationHeader"
            Me.LabelForm_ApplicationHeader.Size = New System.Drawing.Size(305, 20)
            Me.LabelForm_ApplicationHeader.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ApplicationHeader.TabIndex = 16
            Me.LabelForm_ApplicationHeader.Text = "Application"
            '
            'LabelForm_VersionDescription
            '
            Me.LabelForm_VersionDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_VersionDescription.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_VersionDescription.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_VersionDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelForm_VersionDescription.ForeColor = System.Drawing.SystemColors.HotTrack
            Me.LabelForm_VersionDescription.Location = New System.Drawing.Point(12, 142)
            Me.LabelForm_VersionDescription.Name = "LabelForm_VersionDescription"
            Me.LabelForm_VersionDescription.Size = New System.Drawing.Size(454, 20)
            Me.LabelForm_VersionDescription.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_VersionDescription.TabIndex = 17
            Me.LabelForm_VersionDescription.Text = "{0}"
            Me.LabelForm_VersionDescription.TextAlignment = System.Drawing.StringAlignment.Center
            '
            'LabelForm_WebvantageDatabaseVersion
            '
            Me.LabelForm_WebvantageDatabaseVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_WebvantageDatabaseVersion.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_WebvantageDatabaseVersion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_WebvantageDatabaseVersion.ForeColor = System.Drawing.SystemColors.HotTrack
            Me.LabelForm_WebvantageDatabaseVersion.Location = New System.Drawing.Point(472, 324)
            Me.LabelForm_WebvantageDatabaseVersion.Name = "LabelForm_WebvantageDatabaseVersion"
            Me.LabelForm_WebvantageDatabaseVersion.Size = New System.Drawing.Size(305, 20)
            Me.LabelForm_WebvantageDatabaseVersion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_WebvantageDatabaseVersion.TabIndex = 18
            Me.LabelForm_WebvantageDatabaseVersion.Text = "Webvantage Database Version: {0}"
            '
            'LabelForm_AdvantageDatabaseVersion
            '
            Me.LabelForm_AdvantageDatabaseVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_AdvantageDatabaseVersion.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_AdvantageDatabaseVersion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_AdvantageDatabaseVersion.ForeColor = System.Drawing.SystemColors.HotTrack
            Me.LabelForm_AdvantageDatabaseVersion.Location = New System.Drawing.Point(472, 350)
            Me.LabelForm_AdvantageDatabaseVersion.Name = "LabelForm_AdvantageDatabaseVersion"
            Me.LabelForm_AdvantageDatabaseVersion.Size = New System.Drawing.Size(305, 20)
            Me.LabelForm_AdvantageDatabaseVersion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_AdvantageDatabaseVersion.TabIndex = 19
            Me.LabelForm_AdvantageDatabaseVersion.Text = "Advantage Database Version: {0}"
            '
            'LabelForm_LastDatabaseUpdate
            '
            Me.LabelForm_LastDatabaseUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_LastDatabaseUpdate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_LastDatabaseUpdate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_LastDatabaseUpdate.ForeColor = System.Drawing.SystemColors.HotTrack
            Me.LabelForm_LastDatabaseUpdate.Location = New System.Drawing.Point(472, 376)
            Me.LabelForm_LastDatabaseUpdate.Name = "LabelForm_LastDatabaseUpdate"
            Me.LabelForm_LastDatabaseUpdate.Size = New System.Drawing.Size(305, 20)
            Me.LabelForm_LastDatabaseUpdate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_LastDatabaseUpdate.TabIndex = 21
            Me.LabelForm_LastDatabaseUpdate.Text = "Last Database Update: {0}"
            '
            'LabelForm_ServerName
            '
            Me.LabelForm_ServerName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_ServerName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_ServerName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_ServerName.ForeColor = System.Drawing.SystemColors.HotTrack
            Me.LabelForm_ServerName.Location = New System.Drawing.Point(472, 402)
            Me.LabelForm_ServerName.Name = "LabelForm_ServerName"
            Me.LabelForm_ServerName.Size = New System.Drawing.Size(305, 20)
            Me.LabelForm_ServerName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ServerName.TabIndex = 22
            Me.LabelForm_ServerName.Text = "Server Name: {0}"
            '
            'LabelForm_SQLServerAppName
            '
            Me.LabelForm_SQLServerAppName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_SQLServerAppName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_SQLServerAppName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_SQLServerAppName.ForeColor = System.Drawing.SystemColors.HotTrack
            Me.LabelForm_SQLServerAppName.Location = New System.Drawing.Point(472, 454)
            Me.LabelForm_SQLServerAppName.Name = "LabelForm_SQLServerAppName"
            Me.LabelForm_SQLServerAppName.Size = New System.Drawing.Size(305, 20)
            Me.LabelForm_SQLServerAppName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_SQLServerAppName.TabIndex = 23
            Me.LabelForm_SQLServerAppName.Text = "SQL Server App Name: {0}"
            '
            'LabelForm_Locale
            '
            Me.LabelForm_Locale.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_Locale.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Locale.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Locale.ForeColor = System.Drawing.SystemColors.HotTrack
            Me.LabelForm_Locale.Location = New System.Drawing.Point(472, 480)
            Me.LabelForm_Locale.Name = "LabelForm_Locale"
            Me.LabelForm_Locale.Size = New System.Drawing.Size(305, 20)
            Me.LabelForm_Locale.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Locale.TabIndex = 24
            Me.LabelForm_Locale.Text = "Locale: {0}"
            '
            'LabelForm_MediaToolsUsers
            '
            Me.LabelForm_MediaToolsUsers.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_MediaToolsUsers.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_MediaToolsUsers.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_MediaToolsUsers.ForeColor = System.Drawing.SystemColors.HotTrack
            Me.LabelForm_MediaToolsUsers.Location = New System.Drawing.Point(472, 220)
            Me.LabelForm_MediaToolsUsers.Name = "LabelForm_MediaToolsUsers"
            Me.LabelForm_MediaToolsUsers.Size = New System.Drawing.Size(305, 20)
            Me.LabelForm_MediaToolsUsers.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_MediaToolsUsers.TabIndex = 25
            Me.LabelForm_MediaToolsUsers.Text = "<a name=""MediaToolsUsers"">Media Tools Users</a>: {0}"
            '
            'LabelForm_APIUsers
            '
            Me.LabelForm_APIUsers.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_APIUsers.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_APIUsers.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_APIUsers.ForeColor = System.Drawing.SystemColors.HotTrack
            Me.LabelForm_APIUsers.Location = New System.Drawing.Point(472, 246)
            Me.LabelForm_APIUsers.Name = "LabelForm_APIUsers"
            Me.LabelForm_APIUsers.Size = New System.Drawing.Size(305, 20)
            Me.LabelForm_APIUsers.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_APIUsers.TabIndex = 26
            Me.LabelForm_APIUsers.Text = "<a name=""APIUsers"">API Users</a>: {0}"
            '
            'LabelForm_ProofingToolEnabled
            '
            Me.LabelForm_ProofingToolEnabled.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_ProofingToolEnabled.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_ProofingToolEnabled.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_ProofingToolEnabled.ForeColor = System.Drawing.SystemColors.HotTrack
            Me.LabelForm_ProofingToolEnabled.Location = New System.Drawing.Point(472, 272)
            Me.LabelForm_ProofingToolEnabled.Name = "LabelForm_ProofingToolEnabled"
            Me.LabelForm_ProofingToolEnabled.Size = New System.Drawing.Size(305, 20)
            Me.LabelForm_ProofingToolEnabled.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ProofingToolEnabled.TabIndex = 27
            Me.LabelForm_ProofingToolEnabled.Text = "Proofing Tool Enabled: {0}"
            '
            'AboutDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.White
            Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
            Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
            Me.BottomLeftCornerSize = 0
            Me.BottomRightCornerSize = 0
            Me.ClientSize = New System.Drawing.Size(789, 538)
            Me.ControlBox = False
            Me.Controls.Add(Me.LabelForm_ProofingToolEnabled)
            Me.Controls.Add(Me.LabelForm_APIUsers)
            Me.Controls.Add(Me.LabelForm_MediaToolsUsers)
            Me.Controls.Add(Me.LabelForm_AdvantageDatabaseVersion)
            Me.Controls.Add(Me.LabelForm_SQLServerAppName)
            Me.Controls.Add(Me.LabelForm_Locale)
            Me.Controls.Add(Me.LabelForm_ServerName)
            Me.Controls.Add(Me.LabelForm_LastDatabaseUpdate)
            Me.Controls.Add(Me.LabelForm_WebvantageDatabaseVersion)
            Me.Controls.Add(Me.LabelForm_VersionDescription)
            Me.Controls.Add(Me.LabelForm_ApplicationHeader)
            Me.Controls.Add(Me.LabelForm_Agency)
            Me.Controls.Add(Me.LabelForm_Description)
            Me.Controls.Add(Me.LabelForm_DatabaseName)
            Me.Controls.Add(Me.LabelForm_CPUsers)
            Me.Controls.Add(Me.LabelForm_CPUsersConnected)
            Me.Controls.Add(Me.LabelForm_User)
            Me.Controls.Add(Me.LabelForm_CollationMessage)
            Me.Controls.Add(Me.LabelForm_PowerUsersConnected)
            Me.Controls.Add(Me.LabelForm_PowerUsers)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.LabelForm_Copyright)
            Me.Controls.Add(Me.LabelForm_SoftwareVersion)
            Me.Controls.Add(Me.LabelForm_Application)
            Me.Controls.Add(Me.LabelForm_WVUsersConnected)
            Me.Controls.Add(Me.LabelForm_WVUsers)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "AboutDialog"
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.TopLeftCornerSize = 0
            Me.TopRightCornerSize = 0
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_Application As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_SoftwareVersion As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Copyright As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Description As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_CollationMessage As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_WVUsers As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_WVUsersConnected As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_PowerUsersConnected As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_PowerUsers As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_User As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Agency As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_DatabaseName As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_CPUsersConnected As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_CPUsers As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_ApplicationHeader As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_VersionDescription As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_WebvantageDatabaseVersion As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_AdvantageDatabaseVersion As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_LastDatabaseUpdate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_ServerName As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_SQLServerAppName As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Locale As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_MediaToolsUsers As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_APIUsers As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_ProofingToolEnabled As Controls.Label
    End Class

End Namespace
