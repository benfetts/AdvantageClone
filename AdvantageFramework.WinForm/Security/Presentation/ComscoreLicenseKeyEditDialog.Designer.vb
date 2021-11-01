Namespace Security.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class ComscoreLicenseKeyEditDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
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
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ComscoreLicenseKeyEditDialog))
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Create = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.CheckBoxForm_CreateFileAfterKeyCreated = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelForm_ClientID = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_ClientID = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxForm_AgencyName = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_AgencyName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SuspendLayout()
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(385, 80)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 6
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ButtonForm_Create
            '
            Me.ButtonForm_Create.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Create.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Create.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Create.Location = New System.Drawing.Point(304, 80)
            Me.ButtonForm_Create.Name = "ButtonForm_Create"
            Me.ButtonForm_Create.SecurityEnabled = True
            Me.ButtonForm_Create.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Create.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Create.TabIndex = 5
            Me.ButtonForm_Create.Text = "Create"
            '
            'CheckBoxForm_CreateFileAfterKeyCreated
            '
            Me.CheckBoxForm_CreateFileAfterKeyCreated.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxForm_CreateFileAfterKeyCreated.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_CreateFileAfterKeyCreated.CheckValue = 0
            Me.CheckBoxForm_CreateFileAfterKeyCreated.CheckValueChecked = 1
            Me.CheckBoxForm_CreateFileAfterKeyCreated.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_CreateFileAfterKeyCreated.CheckValueUnchecked = 0
            Me.CheckBoxForm_CreateFileAfterKeyCreated.ChildControls = CType(resources.GetObject("CheckBoxForm_CreateFileAfterKeyCreated.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_CreateFileAfterKeyCreated.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_CreateFileAfterKeyCreated.Location = New System.Drawing.Point(12, 80)
            Me.CheckBoxForm_CreateFileAfterKeyCreated.Name = "CheckBoxForm_CreateFileAfterKeyCreated"
            Me.CheckBoxForm_CreateFileAfterKeyCreated.OldestSibling = Nothing
            Me.CheckBoxForm_CreateFileAfterKeyCreated.SecurityEnabled = True
            Me.CheckBoxForm_CreateFileAfterKeyCreated.SiblingControls = CType(resources.GetObject("CheckBoxForm_CreateFileAfterKeyCreated.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_CreateFileAfterKeyCreated.Size = New System.Drawing.Size(286, 20)
            Me.CheckBoxForm_CreateFileAfterKeyCreated.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_CreateFileAfterKeyCreated.TabIndex = 4
            Me.CheckBoxForm_CreateFileAfterKeyCreated.TabOnEnter = True
            Me.CheckBoxForm_CreateFileAfterKeyCreated.Text = "Create File After Key Created"
            '
            'LabelForm_ClientID
            '
            Me.LabelForm_ClientID.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_ClientID.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_ClientID.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_ClientID.Name = "LabelForm_ClientID"
            Me.LabelForm_ClientID.Size = New System.Drawing.Size(105, 20)
            Me.LabelForm_ClientID.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ClientID.TabIndex = 2
            Me.LabelForm_ClientID.Text = "Comscore Client ID:"
            '
            'TextBoxForm_ClientID
            '
            Me.TextBoxForm_ClientID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxForm_ClientID.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxForm_ClientID.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_ClientID.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_ClientID.CheckSpellingOnValidate = False
            Me.TextBoxForm_ClientID.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_ClientID.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxForm_ClientID.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_ClientID.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_ClientID.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_ClientID.FocusHighlightEnabled = True
            Me.TextBoxForm_ClientID.ForeColor = System.Drawing.Color.Black
            Me.TextBoxForm_ClientID.Location = New System.Drawing.Point(123, 39)
            Me.TextBoxForm_ClientID.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_ClientID.MaxLength = 40
            Me.TextBoxForm_ClientID.Name = "TextBoxForm_ClientID"
            Me.TextBoxForm_ClientID.SecurityEnabled = True
            Me.TextBoxForm_ClientID.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_ClientID.Size = New System.Drawing.Size(337, 20)
            Me.TextBoxForm_ClientID.StartingFolderName = Nothing
            Me.TextBoxForm_ClientID.TabIndex = 3
            Me.TextBoxForm_ClientID.TabOnEnter = True
            '
            'TextBoxForm_AgencyName
            '
            Me.TextBoxForm_AgencyName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxForm_AgencyName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxForm_AgencyName.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_AgencyName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_AgencyName.CheckSpellingOnValidate = False
            Me.TextBoxForm_AgencyName.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_AgencyName.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxForm_AgencyName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_AgencyName.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_AgencyName.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_AgencyName.FocusHighlightEnabled = True
            Me.TextBoxForm_AgencyName.ForeColor = System.Drawing.Color.Black
            Me.TextBoxForm_AgencyName.Location = New System.Drawing.Point(123, 13)
            Me.TextBoxForm_AgencyName.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_AgencyName.MaxLength = 40
            Me.TextBoxForm_AgencyName.Name = "TextBoxForm_AgencyName"
            Me.TextBoxForm_AgencyName.SecurityEnabled = True
            Me.TextBoxForm_AgencyName.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_AgencyName.Size = New System.Drawing.Size(337, 20)
            Me.TextBoxForm_AgencyName.StartingFolderName = Nothing
            Me.TextBoxForm_AgencyName.TabIndex = 1
            Me.TextBoxForm_AgencyName.TabOnEnter = True
            '
            'LabelForm_AgencyName
            '
            Me.LabelForm_AgencyName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_AgencyName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_AgencyName.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_AgencyName.Name = "LabelForm_AgencyName"
            Me.LabelForm_AgencyName.Size = New System.Drawing.Size(105, 20)
            Me.LabelForm_AgencyName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_AgencyName.TabIndex = 0
            Me.LabelForm_AgencyName.Text = "Agency Name:"
            '
            'ComscoreLicenseKeyEditDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(472, 112)
            Me.Controls.Add(Me.TextBoxForm_AgencyName)
            Me.Controls.Add(Me.LabelForm_AgencyName)
            Me.Controls.Add(Me.TextBoxForm_ClientID)
            Me.Controls.Add(Me.LabelForm_ClientID)
            Me.Controls.Add(Me.ButtonForm_Create)
            Me.Controls.Add(Me.CheckBoxForm_CreateFileAfterKeyCreated)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ComscoreLicenseKeyEditDialog"
            Me.Text = "Create Comscore License Key"
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents ButtonForm_Cancel As WinForm.Presentation.Controls.Button
        Private WithEvents ButtonForm_Create As WinForm.Presentation.Controls.Button
        Private WithEvents CheckBoxForm_CreateFileAfterKeyCreated As WinForm.Presentation.Controls.CheckBox
        Private WithEvents LabelForm_ClientID As WinForm.Presentation.Controls.Label
        Private WithEvents TextBoxForm_ClientID As WinForm.Presentation.Controls.TextBox
        Private WithEvents TextBoxForm_AgencyName As WinForm.Presentation.Controls.TextBox
        Private WithEvents LabelForm_AgencyName As WinForm.Presentation.Controls.Label
    End Class

End Namespace
