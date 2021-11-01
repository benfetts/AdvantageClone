Namespace Security.Setup.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class UserEditDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserEditDialog))
            Me.ButtonForm_Update = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Add = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_Employee = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_Employee = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.CheckBoxForm_CheckForUserAccess = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelForm_UserName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_UserName = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.CheckBoxUserSettings_IsWebvantageUserOnly = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.SuspendLayout()
            '
            'ButtonForm_Update
            '
            Me.ButtonForm_Update.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Update.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Update.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Update.Location = New System.Drawing.Point(304, 91)
            Me.ButtonForm_Update.Name = "ButtonForm_Update"
            Me.ButtonForm_Update.SecurityEnabled = True
            Me.ButtonForm_Update.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Update.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Update.TabIndex = 7
            Me.ButtonForm_Update.Text = "Update"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(385, 91)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 8
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ButtonForm_Add
            '
            Me.ButtonForm_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Add.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Add.Location = New System.Drawing.Point(304, 91)
            Me.ButtonForm_Add.Name = "ButtonForm_Add"
            Me.ButtonForm_Add.SecurityEnabled = True
            Me.ButtonForm_Add.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Add.TabIndex = 6
            Me.ButtonForm_Add.Text = "Add"
            '
            'LabelForm_Employee
            '
            Me.LabelForm_Employee.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Employee.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Employee.Location = New System.Drawing.Point(12, 65)
            Me.LabelForm_Employee.Name = "LabelForm_Employee"
            Me.LabelForm_Employee.Size = New System.Drawing.Size(59, 20)
            Me.LabelForm_Employee.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Employee.TabIndex = 4
            Me.LabelForm_Employee.Text = "Employee:"
            '
            'ComboBoxForm_Employee
            '
            Me.ComboBoxForm_Employee.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Employee.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Employee.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Employee.AutoFindItemInDataSource = False
            Me.ComboBoxForm_Employee.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Employee.BookmarkingEnabled = False
            Me.ComboBoxForm_Employee.ClientCode = ""
            Me.ComboBoxForm_Employee.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Employee
            Me.ComboBoxForm_Employee.DisableMouseWheel = False
            Me.ComboBoxForm_Employee.DisplayMember = "FullName"
            Me.ComboBoxForm_Employee.DisplayName = ""
            Me.ComboBoxForm_Employee.DivisionCode = ""
            Me.ComboBoxForm_Employee.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Employee.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_Employee.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_Employee.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Employee.FocusHighlightEnabled = True
            Me.ComboBoxForm_Employee.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxForm_Employee.ItemHeight = 14
            Me.ComboBoxForm_Employee.Location = New System.Drawing.Point(77, 65)
            Me.ComboBoxForm_Employee.Name = "ComboBoxForm_Employee"
            Me.ComboBoxForm_Employee.ReadOnly = False
            Me.ComboBoxForm_Employee.SecurityEnabled = True
            Me.ComboBoxForm_Employee.Size = New System.Drawing.Size(383, 20)
            Me.ComboBoxForm_Employee.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Employee.TabIndex = 5
            Me.ComboBoxForm_Employee.TabOnEnter = True
            Me.ComboBoxForm_Employee.ValueMember = "Code"
            Me.ComboBoxForm_Employee.WatermarkText = "Select Employee"
            '
            'CheckBoxForm_CheckForUserAccess
            '
            '
            '
            '
            Me.CheckBoxForm_CheckForUserAccess.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_CheckForUserAccess.CheckValue = 0
            Me.CheckBoxForm_CheckForUserAccess.CheckValueChecked = 1
            Me.CheckBoxForm_CheckForUserAccess.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_CheckForUserAccess.CheckValueUnchecked = 0
            Me.CheckBoxForm_CheckForUserAccess.ChildControls = CType(resources.GetObject("CheckBoxForm_CheckForUserAccess.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_CheckForUserAccess.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_CheckForUserAccess.Location = New System.Drawing.Point(77, 38)
            Me.CheckBoxForm_CheckForUserAccess.Name = "CheckBoxForm_CheckForUserAccess"
            Me.CheckBoxForm_CheckForUserAccess.OldestSibling = Nothing
            Me.CheckBoxForm_CheckForUserAccess.SecurityEnabled = True
            Me.CheckBoxForm_CheckForUserAccess.SiblingControls = CType(resources.GetObject("CheckBoxForm_CheckForUserAccess.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_CheckForUserAccess.Size = New System.Drawing.Size(150, 20)
            Me.CheckBoxForm_CheckForUserAccess.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_CheckForUserAccess.TabIndex = 2
            Me.CheckBoxForm_CheckForUserAccess.TabOnEnter = True
            Me.CheckBoxForm_CheckForUserAccess.Text = "Check For User Access"
            '
            'LabelForm_UserName
            '
            Me.LabelForm_UserName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_UserName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_UserName.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_UserName.Name = "LabelForm_UserName"
            Me.LabelForm_UserName.Size = New System.Drawing.Size(59, 20)
            Me.LabelForm_UserName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_UserName.TabIndex = 0
            Me.LabelForm_UserName.Text = "User Code:"
            '
            'TextBoxForm_UserName
            '
            Me.TextBoxForm_UserName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxForm_UserName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxForm_UserName.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_UserName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_UserName.CheckSpellingOnValidate = False
            Me.TextBoxForm_UserName.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_UserName.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxForm_UserName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_UserName.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_UserName.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_UserName.FocusHighlightEnabled = True
            Me.TextBoxForm_UserName.ForeColor = System.Drawing.Color.Black
            Me.TextBoxForm_UserName.Location = New System.Drawing.Point(77, 12)
            Me.TextBoxForm_UserName.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_UserName.Name = "TextBoxForm_UserName"
            Me.TextBoxForm_UserName.PreventEnterBeep = True
            Me.TextBoxForm_UserName.SecurityEnabled = True
            Me.TextBoxForm_UserName.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_UserName.Size = New System.Drawing.Size(383, 20)
            Me.TextBoxForm_UserName.StartingFolderName = Nothing
            Me.TextBoxForm_UserName.TabIndex = 1
            Me.TextBoxForm_UserName.TabOnEnter = True
            '
            'CheckBoxUserSettings_IsWebvantageUserOnly
            '
            Me.CheckBoxUserSettings_IsWebvantageUserOnly.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.CheckBoxUserSettings_IsWebvantageUserOnly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxUserSettings_IsWebvantageUserOnly.BackgroundStyle.WordWrap = True
            Me.CheckBoxUserSettings_IsWebvantageUserOnly.CheckValue = 0
            Me.CheckBoxUserSettings_IsWebvantageUserOnly.CheckValueChecked = 1
            Me.CheckBoxUserSettings_IsWebvantageUserOnly.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxUserSettings_IsWebvantageUserOnly.CheckValueUnchecked = 0
            Me.CheckBoxUserSettings_IsWebvantageUserOnly.ChildControls = CType(resources.GetObject("CheckBoxUserSettings_IsWebvantageUserOnly.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxUserSettings_IsWebvantageUserOnly.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxUserSettings_IsWebvantageUserOnly.Location = New System.Drawing.Point(233, 38)
            Me.CheckBoxUserSettings_IsWebvantageUserOnly.Name = "CheckBoxUserSettings_IsWebvantageUserOnly"
            Me.CheckBoxUserSettings_IsWebvantageUserOnly.OldestSibling = Nothing
            Me.CheckBoxUserSettings_IsWebvantageUserOnly.SecurityEnabled = True
            Me.CheckBoxUserSettings_IsWebvantageUserOnly.SiblingControls = CType(resources.GetObject("CheckBoxUserSettings_IsWebvantageUserOnly.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxUserSettings_IsWebvantageUserOnly.Size = New System.Drawing.Size(227, 20)
            Me.CheckBoxUserSettings_IsWebvantageUserOnly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxUserSettings_IsWebvantageUserOnly.TabIndex = 3
            Me.CheckBoxUserSettings_IsWebvantageUserOnly.TabOnEnter = True
            Me.CheckBoxUserSettings_IsWebvantageUserOnly.Text = "Is Webvantage User Only"
            '
            'UserEditDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(472, 123)
            Me.Controls.Add(Me.CheckBoxUserSettings_IsWebvantageUserOnly)
            Me.Controls.Add(Me.TextBoxForm_UserName)
            Me.Controls.Add(Me.LabelForm_UserName)
            Me.Controls.Add(Me.CheckBoxForm_CheckForUserAccess)
            Me.Controls.Add(Me.ComboBoxForm_Employee)
            Me.Controls.Add(Me.LabelForm_Employee)
            Me.Controls.Add(Me.ButtonForm_Add)
            Me.Controls.Add(Me.ButtonForm_Update)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "UserEditDialog"
            Me.Text = "Add User"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Update As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Add As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_Employee As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_Employee As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents CheckBoxForm_CheckForUserAccess As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelForm_UserName As WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_UserName As WinForm.Presentation.Controls.TextBox
        Friend WithEvents CheckBoxUserSettings_IsWebvantageUserOnly As WinForm.Presentation.Controls.CheckBox
    End Class

End Namespace