Namespace Maintenance.General.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class DocumentsEditDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DocumentsEditDialog))
            Me.ButtonForm_Add = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.CheckBoxOptions_TopLevelLabel = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.Label1 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxOptions_LabelInactive = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TextBoxLabelInformation_Description = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxLabelInformation_Name = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelContactInformation_Title = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelContactInformation_LastName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelContactInformation_FirstName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DevCompColor = New DevComponents.DotNetBar.ColorPickerButton()
            Me.PictureBox1 = New System.Windows.Forms.PictureBox()
            CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ButtonForm_Add
            '
            Me.ButtonForm_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Add.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Add.Location = New System.Drawing.Point(412, 132)
            Me.ButtonForm_Add.Name = "ButtonForm_Add"
            Me.ButtonForm_Add.SecurityEnabled = True
            Me.ButtonForm_Add.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Add.TabIndex = 6
            Me.ButtonForm_Add.Text = "Add"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(493, 132)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 7
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'CheckBoxOptions_TopLevelLabel
            '
            '
            '
            '
            Me.CheckBoxOptions_TopLevelLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxOptions_TopLevelLabel.CheckValue = 0
            Me.CheckBoxOptions_TopLevelLabel.CheckValueChecked = 1
            Me.CheckBoxOptions_TopLevelLabel.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxOptions_TopLevelLabel.CheckValueUnchecked = 0
            Me.CheckBoxOptions_TopLevelLabel.ChildControls = CType(resources.GetObject("CheckBoxOptions_TopLevelLabel.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxOptions_TopLevelLabel.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxOptions_TopLevelLabel.Location = New System.Drawing.Point(107, 11)
            Me.CheckBoxOptions_TopLevelLabel.Name = "CheckBoxOptions_TopLevelLabel"
            Me.CheckBoxOptions_TopLevelLabel.OldestSibling = Nothing
            Me.CheckBoxOptions_TopLevelLabel.SecurityEnabled = True
            Me.CheckBoxOptions_TopLevelLabel.SiblingControls = CType(resources.GetObject("CheckBoxOptions_TopLevelLabel.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxOptions_TopLevelLabel.Size = New System.Drawing.Size(80, 20)
            Me.CheckBoxOptions_TopLevelLabel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxOptions_TopLevelLabel.TabIndex = 1
            Me.CheckBoxOptions_TopLevelLabel.TabOnEnter = True
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.Label1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label1.Location = New System.Drawing.Point(12, 12)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(89, 20)
            Me.Label1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label1.TabIndex = 13
            Me.Label1.Text = "Top Level Label:"
            '
            'CheckBoxOptions_LabelInactive
            '
            '
            '
            '
            Me.CheckBoxOptions_LabelInactive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxOptions_LabelInactive.CheckValue = 0
            Me.CheckBoxOptions_LabelInactive.CheckValueChecked = 1
            Me.CheckBoxOptions_LabelInactive.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxOptions_LabelInactive.CheckValueUnchecked = 0
            Me.CheckBoxOptions_LabelInactive.ChildControls = CType(resources.GetObject("CheckBoxOptions_LabelInactive.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxOptions_LabelInactive.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxOptions_LabelInactive.Location = New System.Drawing.Point(521, 37)
            Me.CheckBoxOptions_LabelInactive.Name = "CheckBoxOptions_LabelInactive"
            Me.CheckBoxOptions_LabelInactive.OldestSibling = Nothing
            Me.CheckBoxOptions_LabelInactive.SecurityEnabled = True
            Me.CheckBoxOptions_LabelInactive.SiblingControls = CType(resources.GetObject("CheckBoxOptions_LabelInactive.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxOptions_LabelInactive.Size = New System.Drawing.Size(80, 20)
            Me.CheckBoxOptions_LabelInactive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxOptions_LabelInactive.TabIndex = 3
            Me.CheckBoxOptions_LabelInactive.TabOnEnter = True
            Me.CheckBoxOptions_LabelInactive.Text = "Active"
            '
            'TextBoxLabelInformation_Description
            '
            '
            '
            '
            Me.TextBoxLabelInformation_Description.Border.Class = "TextBoxBorder"
            Me.TextBoxLabelInformation_Description.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxLabelInformation_Description.CheckSpellingOnValidate = False
            Me.TextBoxLabelInformation_Description.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxLabelInformation_Description.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxLabelInformation_Description.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxLabelInformation_Description.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxLabelInformation_Description.FocusHighlightEnabled = True
            Me.TextBoxLabelInformation_Description.Location = New System.Drawing.Point(107, 63)
            Me.TextBoxLabelInformation_Description.MaxFileSize = CType(0, Long)
            Me.TextBoxLabelInformation_Description.MaxLength = 100
            Me.TextBoxLabelInformation_Description.Name = "TextBoxLabelInformation_Description"
            Me.TextBoxLabelInformation_Description.SecurityEnabled = True
            Me.TextBoxLabelInformation_Description.ShowSpellCheckCompleteMessage = True
            Me.TextBoxLabelInformation_Description.Size = New System.Drawing.Size(408, 20)
            Me.TextBoxLabelInformation_Description.StartingFolderName = Nothing
            Me.TextBoxLabelInformation_Description.TabIndex = 4
            Me.TextBoxLabelInformation_Description.TabOnEnter = True
            '
            'TextBoxLabelInformation_Name
            '
            '
            '
            '
            Me.TextBoxLabelInformation_Name.Border.Class = "TextBoxBorder"
            Me.TextBoxLabelInformation_Name.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxLabelInformation_Name.CheckSpellingOnValidate = False
            Me.TextBoxLabelInformation_Name.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxLabelInformation_Name.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxLabelInformation_Name.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxLabelInformation_Name.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxLabelInformation_Name.FocusHighlightEnabled = True
            Me.TextBoxLabelInformation_Name.Location = New System.Drawing.Point(107, 37)
            Me.TextBoxLabelInformation_Name.MaxFileSize = CType(0, Long)
            Me.TextBoxLabelInformation_Name.MaxLength = 30
            Me.TextBoxLabelInformation_Name.Name = "TextBoxLabelInformation_Name"
            Me.TextBoxLabelInformation_Name.SecurityEnabled = True
            Me.TextBoxLabelInformation_Name.ShowSpellCheckCompleteMessage = True
            Me.TextBoxLabelInformation_Name.Size = New System.Drawing.Size(408, 20)
            Me.TextBoxLabelInformation_Name.StartingFolderName = Nothing
            Me.TextBoxLabelInformation_Name.TabIndex = 2
            Me.TextBoxLabelInformation_Name.TabOnEnter = True
            '
            'LabelContactInformation_Title
            '
            Me.LabelContactInformation_Title.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelContactInformation_Title.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelContactInformation_Title.Location = New System.Drawing.Point(12, 90)
            Me.LabelContactInformation_Title.Name = "LabelContactInformation_Title"
            Me.LabelContactInformation_Title.Size = New System.Drawing.Size(89, 20)
            Me.LabelContactInformation_Title.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelContactInformation_Title.TabIndex = 7
            Me.LabelContactInformation_Title.Text = "Color:"
            '
            'LabelContactInformation_LastName
            '
            Me.LabelContactInformation_LastName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelContactInformation_LastName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelContactInformation_LastName.Location = New System.Drawing.Point(12, 64)
            Me.LabelContactInformation_LastName.Name = "LabelContactInformation_LastName"
            Me.LabelContactInformation_LastName.Size = New System.Drawing.Size(89, 20)
            Me.LabelContactInformation_LastName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelContactInformation_LastName.TabIndex = 5
            Me.LabelContactInformation_LastName.Text = "Description:"
            '
            'LabelContactInformation_FirstName
            '
            Me.LabelContactInformation_FirstName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelContactInformation_FirstName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelContactInformation_FirstName.Location = New System.Drawing.Point(12, 38)
            Me.LabelContactInformation_FirstName.Name = "LabelContactInformation_FirstName"
            Me.LabelContactInformation_FirstName.Size = New System.Drawing.Size(89, 20)
            Me.LabelContactInformation_FirstName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelContactInformation_FirstName.TabIndex = 1
            Me.LabelContactInformation_FirstName.Text = "Name:"
            '
            'DevCompColor
            '
            Me.DevCompColor.AccessibleRole = System.Windows.Forms.AccessibleRole.Text
            Me.DevCompColor.DisplayMoreColors = False
            Me.DevCompColor.DisplayThemeColors = False
            Me.DevCompColor.Location = New System.Drawing.Point(235, 90)
            Me.DevCompColor.Name = "DevCompColor"
            Me.DevCompColor.Size = New System.Drawing.Size(14, 21)
            Me.DevCompColor.SplitButton = True
            Me.DevCompColor.TabIndex = 15
            '
            'PictureBox1
            '
            Me.PictureBox1.BackColor = System.Drawing.Color.White
            Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.PictureBox1.Location = New System.Drawing.Point(107, 90)
            Me.PictureBox1.Name = "PictureBox1"
            Me.PictureBox1.Size = New System.Drawing.Size(125, 21)
            Me.PictureBox1.TabIndex = 16
            Me.PictureBox1.TabStop = False
            '
            'DocumentsEditDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(580, 164)
            Me.Controls.Add(Me.PictureBox1)
            Me.Controls.Add(Me.DevCompColor)
            Me.Controls.Add(Me.CheckBoxOptions_TopLevelLabel)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.CheckBoxOptions_LabelInactive)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.TextBoxLabelInformation_Description)
            Me.Controls.Add(Me.ButtonForm_Add)
            Me.Controls.Add(Me.TextBoxLabelInformation_Name)
            Me.Controls.Add(Me.LabelContactInformation_FirstName)
            Me.Controls.Add(Me.LabelContactInformation_Title)
            Me.Controls.Add(Me.LabelContactInformation_LastName)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "DocumentsEditDialog"
            Me.Text = "Document Label"
            CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Add As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents CheckBoxOptions_LabelInactive As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents TextBoxLabelInformation_Description As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxLabelInformation_Name As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelContactInformation_Title As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelContactInformation_LastName As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelContactInformation_FirstName As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxOptions_TopLevelLabel As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents Label1 As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DevCompColor As DevComponents.DotNetBar.ColorPickerButton
        Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
    End Class

End Namespace