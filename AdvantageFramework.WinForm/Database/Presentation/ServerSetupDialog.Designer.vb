Namespace Database.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ServerSetupDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ServerSetupDialog))
            Me.LabelForm_DatabaseServerInstance = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ButtonForm_RefreshDatabaseServersInstances = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_UserName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Password = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ButtonForm_RefreshDatabases = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_Database = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_UserName = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxForm_Password = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_TestConnection = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ComboBoxForm_DatabaseServerInstance = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxForm_Database = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.RadioButtonForm_WindowsAuthentication = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonForm_DatabaseServerAuthentication = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'DefaultLookAndFeelOffice2010Blue
            '
            Me.DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
            '
            'LabelForm_DatabaseServerInstance
            '
            Me.LabelForm_DatabaseServerInstance.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_DatabaseServerInstance.BackgroundStyle.Class = ""
            Me.LabelForm_DatabaseServerInstance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_DatabaseServerInstance.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_DatabaseServerInstance.Name = "LabelForm_DatabaseServerInstance"
            Me.LabelForm_DatabaseServerInstance.Size = New System.Drawing.Size(136, 20)
            Me.LabelForm_DatabaseServerInstance.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_DatabaseServerInstance.TabIndex = 0
            Me.LabelForm_DatabaseServerInstance.Text = "Database Server Instance:"
            '
            'ButtonForm_RefreshDatabaseServersInstances
            '
            Me.ButtonForm_RefreshDatabaseServersInstances.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_RefreshDatabaseServersInstances.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_RefreshDatabaseServersInstances.Location = New System.Drawing.Point(405, 12)
            Me.ButtonForm_RefreshDatabaseServersInstances.Name = "ButtonForm_RefreshDatabaseServersInstances"
            Me.ButtonForm_RefreshDatabaseServersInstances.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_RefreshDatabaseServersInstances.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_RefreshDatabaseServersInstances.TabIndex = 2
            Me.ButtonForm_RefreshDatabaseServersInstances.Text = "Refresh"
            '
            'LabelForm_UserName
            '
            Me.LabelForm_UserName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_UserName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_UserName.BackgroundStyle.Class = ""
            Me.LabelForm_UserName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_UserName.Location = New System.Drawing.Point(12, 91)
            Me.LabelForm_UserName.Name = "LabelForm_UserName"
            Me.LabelForm_UserName.Size = New System.Drawing.Size(136, 20)
            Me.LabelForm_UserName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_UserName.TabIndex = 5
            Me.LabelForm_UserName.Text = "User Name:"
            '
            'LabelForm_Password
            '
            Me.LabelForm_Password.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_Password.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Password.BackgroundStyle.Class = ""
            Me.LabelForm_Password.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Password.Location = New System.Drawing.Point(12, 117)
            Me.LabelForm_Password.Name = "LabelForm_Password"
            Me.LabelForm_Password.Size = New System.Drawing.Size(136, 20)
            Me.LabelForm_Password.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Password.TabIndex = 7
            Me.LabelForm_Password.Text = "Password:"
            '
            'ButtonForm_RefreshDatabases
            '
            Me.ButtonForm_RefreshDatabases.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_RefreshDatabases.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_RefreshDatabases.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_RefreshDatabases.Enabled = False
            Me.ButtonForm_RefreshDatabases.Location = New System.Drawing.Point(405, 143)
            Me.ButtonForm_RefreshDatabases.Name = "ButtonForm_RefreshDatabases"
            Me.ButtonForm_RefreshDatabases.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_RefreshDatabases.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_RefreshDatabases.TabIndex = 11
            Me.ButtonForm_RefreshDatabases.Text = "Refresh"
            '
            'LabelForm_Database
            '
            Me.LabelForm_Database.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_Database.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Database.BackgroundStyle.Class = ""
            Me.LabelForm_Database.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Database.Location = New System.Drawing.Point(12, 143)
            Me.LabelForm_Database.Name = "LabelForm_Database"
            Me.LabelForm_Database.Size = New System.Drawing.Size(136, 20)
            Me.LabelForm_Database.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Database.TabIndex = 9
            Me.LabelForm_Database.Text = "Database:"
            '
            'TextBoxForm_UserName
            '
            Me.TextBoxForm_UserName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxForm_UserName.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_UserName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_UserName.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_UserName.Enabled = False
            Me.TextBoxForm_UserName.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_UserName.FocusHighlightEnabled = True
            Me.TextBoxForm_UserName.Location = New System.Drawing.Point(154, 91)
            Me.TextBoxForm_UserName.Name = "TextBoxForm_UserName"
            Me.TextBoxForm_UserName.Size = New System.Drawing.Size(245, 20)
            Me.TextBoxForm_UserName.TabIndex = 6
            Me.TextBoxForm_UserName.TabOnEnter = True
            '
            'TextBoxForm_Password
            '
            Me.TextBoxForm_Password.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxForm_Password.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Password.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Password.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Password.Enabled = False
            Me.TextBoxForm_Password.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Password.FocusHighlightEnabled = True
            Me.TextBoxForm_Password.Location = New System.Drawing.Point(154, 117)
            Me.TextBoxForm_Password.Name = "TextBoxForm_Password"
            Me.TextBoxForm_Password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
            Me.TextBoxForm_Password.Size = New System.Drawing.Size(245, 21)
            Me.TextBoxForm_Password.TabIndex = 8
            Me.TextBoxForm_Password.TabOnEnter = True
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(405, 170)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 14
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(324, 170)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 13
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonForm_TestConnection
            '
            Me.ButtonForm_TestConnection.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_TestConnection.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_TestConnection.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_TestConnection.Enabled = False
            Me.ButtonForm_TestConnection.Location = New System.Drawing.Point(243, 170)
            Me.ButtonForm_TestConnection.Name = "ButtonForm_TestConnection"
            Me.ButtonForm_TestConnection.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_TestConnection.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_TestConnection.TabIndex = 12
            Me.ButtonForm_TestConnection.Text = "Test"
            '
            'ComboBoxForm_DatabaseServerInstance
            '
            Me.ComboBoxForm_DatabaseServerInstance.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_DatabaseServerInstance.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_DatabaseServerInstance.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.DatabaseServerInstance
            Me.ComboBoxForm_DatabaseServerInstance.DisplayMember = "ServerAndInstanceName"
            Me.ComboBoxForm_DatabaseServerInstance.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_DatabaseServerInstance.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_DatabaseServerInstance.FocusHighlightEnabled = True
            Me.ComboBoxForm_DatabaseServerInstance.ItemHeight = 14
            Me.ComboBoxForm_DatabaseServerInstance.Location = New System.Drawing.Point(154, 12)
            Me.ComboBoxForm_DatabaseServerInstance.Name = "ComboBoxForm_DatabaseServerInstance"
            Me.ComboBoxForm_DatabaseServerInstance.PreventEnterBeep = False
            Me.ComboBoxForm_DatabaseServerInstance.Size = New System.Drawing.Size(245, 20)
            Me.ComboBoxForm_DatabaseServerInstance.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_DatabaseServerInstance.TabIndex = 1
            Me.ComboBoxForm_DatabaseServerInstance.ValueMember = "ServerAndInstanceName"
            Me.ComboBoxForm_DatabaseServerInstance.WatermarkText = "Select Server"
            '
            'ComboBoxForm_Database
            '
            Me.ComboBoxForm_Database.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Database.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Database.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Database
            Me.ComboBoxForm_Database.DisplayMember = "Name"
            Me.ComboBoxForm_Database.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Database.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_Database.FocusHighlightEnabled = True
            Me.ComboBoxForm_Database.ItemHeight = 14
            Me.ComboBoxForm_Database.Location = New System.Drawing.Point(154, 143)
            Me.ComboBoxForm_Database.Name = "ComboBoxForm_Database"
            Me.ComboBoxForm_Database.PreventEnterBeep = False
            Me.ComboBoxForm_Database.Size = New System.Drawing.Size(245, 20)
            Me.ComboBoxForm_Database.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Database.TabIndex = 10
            Me.ComboBoxForm_Database.ValueMember = "ID"
            Me.ComboBoxForm_Database.WatermarkText = "Select Database"
            '
            'RadioButtonForm_WindowsAuthentication
            '
            Me.RadioButtonForm_WindowsAuthentication.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonForm_WindowsAuthentication.BackgroundStyle.Class = ""
            Me.RadioButtonForm_WindowsAuthentication.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonForm_WindowsAuthentication.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonForm_WindowsAuthentication.Checked = True
            Me.RadioButtonForm_WindowsAuthentication.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonForm_WindowsAuthentication.CheckValue = "Y"
            Me.RadioButtonForm_WindowsAuthentication.Location = New System.Drawing.Point(154, 38)
            Me.RadioButtonForm_WindowsAuthentication.Name = "RadioButtonForm_WindowsAuthentication"
            Me.RadioButtonForm_WindowsAuthentication.Size = New System.Drawing.Size(245, 20)
            Me.RadioButtonForm_WindowsAuthentication.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonForm_WindowsAuthentication.TabIndex = 3
            Me.RadioButtonForm_WindowsAuthentication.Text = "Windows Authentication"
            '
            'RadioButtonForm_DatabaseServerAuthentication
            '
            Me.RadioButtonForm_DatabaseServerAuthentication.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonForm_DatabaseServerAuthentication.BackgroundStyle.Class = ""
            Me.RadioButtonForm_DatabaseServerAuthentication.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonForm_DatabaseServerAuthentication.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonForm_DatabaseServerAuthentication.Location = New System.Drawing.Point(154, 64)
            Me.RadioButtonForm_DatabaseServerAuthentication.Name = "RadioButtonForm_DatabaseServerAuthentication"
            Me.RadioButtonForm_DatabaseServerAuthentication.Size = New System.Drawing.Size(245, 20)
            Me.RadioButtonForm_DatabaseServerAuthentication.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonForm_DatabaseServerAuthentication.TabIndex = 4
            Me.RadioButtonForm_DatabaseServerAuthentication.Text = "Database Server Authentication"
            '
            'ServerSetupDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(492, 202)
            Me.Controls.Add(Me.RadioButtonForm_WindowsAuthentication)
            Me.Controls.Add(Me.RadioButtonForm_DatabaseServerAuthentication)
            Me.Controls.Add(Me.ComboBoxForm_Database)
            Me.Controls.Add(Me.ComboBoxForm_DatabaseServerInstance)
            Me.Controls.Add(Me.ButtonForm_TestConnection)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.TextBoxForm_Password)
            Me.Controls.Add(Me.TextBoxForm_UserName)
            Me.Controls.Add(Me.ButtonForm_RefreshDatabases)
            Me.Controls.Add(Me.LabelForm_Database)
            Me.Controls.Add(Me.LabelForm_Password)
            Me.Controls.Add(Me.LabelForm_UserName)
            Me.Controls.Add(Me.ButtonForm_RefreshDatabaseServersInstances)
            Me.Controls.Add(Me.LabelForm_DatabaseServerInstance)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ServerSetupDialog"
            Me.Text = "Database Server Setup"
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents LabelForm_DatabaseServerInstance As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonForm_RefreshDatabaseServersInstances As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_UserName As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Password As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonForm_RefreshDatabases As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_Database As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_UserName As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxForm_Password As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_TestConnection As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ComboBoxForm_DatabaseServerInstance As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxForm_Database As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents RadioButtonForm_WindowsAuthentication As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonForm_DatabaseServerAuthentication As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
    End Class

End Namespace