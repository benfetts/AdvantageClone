Namespace Maintenance.General.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class AgencyTestEmailDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AgencyTestEmailDialog))
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Send = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_Employee = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_Employee = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.CheckBoxForm_UseCurrent = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelForm_EmailTo = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_Email = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.CheckBoxForm_UseSES = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.SuspendLayout()
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(384, 64)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 6
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ButtonForm_Send
            '
            Me.ButtonForm_Send.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Send.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Send.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Send.Location = New System.Drawing.Point(303, 64)
            Me.ButtonForm_Send.Name = "ButtonForm_Send"
            Me.ButtonForm_Send.SecurityEnabled = True
            Me.ButtonForm_Send.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Send.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Send.TabIndex = 5
            Me.ButtonForm_Send.Text = "Send"
            '
            'LabelForm_Employee
            '
            Me.LabelForm_Employee.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Employee.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Employee.Location = New System.Drawing.Point(111, 12)
            Me.LabelForm_Employee.Name = "LabelForm_Employee"
            Me.LabelForm_Employee.Size = New System.Drawing.Size(59, 20)
            Me.LabelForm_Employee.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Employee.TabIndex = 1
            Me.LabelForm_Employee.Text = "Employee:"
            '
            'ComboBoxForm_Employee
            '
            Me.ComboBoxForm_Employee.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Employee.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
            Me.ComboBoxForm_Employee.Enabled = False
            Me.ComboBoxForm_Employee.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_Employee.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_Employee.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Employee.FocusHighlightEnabled = True
            Me.ComboBoxForm_Employee.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxForm_Employee.ItemHeight = 14
            Me.ComboBoxForm_Employee.Location = New System.Drawing.Point(176, 12)
            Me.ComboBoxForm_Employee.Name = "ComboBoxForm_Employee"
            Me.ComboBoxForm_Employee.ReadOnly = False
            Me.ComboBoxForm_Employee.SecurityEnabled = True
            Me.ComboBoxForm_Employee.Size = New System.Drawing.Size(284, 20)
            Me.ComboBoxForm_Employee.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Employee.TabIndex = 2
            Me.ComboBoxForm_Employee.TabOnEnter = True
            Me.ComboBoxForm_Employee.ValueMember = "Code"
            Me.ComboBoxForm_Employee.WatermarkText = "Select Employee"
            '
            'CheckBoxForm_UseCurrent
            '
            '
            '
            '
            Me.CheckBoxForm_UseCurrent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_UseCurrent.CheckValue = 0
            Me.CheckBoxForm_UseCurrent.CheckValueChecked = 1
            Me.CheckBoxForm_UseCurrent.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_UseCurrent.CheckValueUnchecked = 0
            Me.CheckBoxForm_UseCurrent.ChildControls = CType(resources.GetObject("CheckBoxForm_UseCurrent.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_UseCurrent.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_UseCurrent.Location = New System.Drawing.Point(12, 12)
            Me.CheckBoxForm_UseCurrent.Name = "CheckBoxForm_UseCurrent"
            Me.CheckBoxForm_UseCurrent.OldestSibling = Nothing
            Me.CheckBoxForm_UseCurrent.SecurityEnabled = True
            Me.CheckBoxForm_UseCurrent.SiblingControls = CType(resources.GetObject("CheckBoxForm_UseCurrent.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_UseCurrent.Size = New System.Drawing.Size(93, 20)
            Me.CheckBoxForm_UseCurrent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_UseCurrent.TabIndex = 0
            Me.CheckBoxForm_UseCurrent.TabOnEnter = True
            Me.CheckBoxForm_UseCurrent.Text = "Use Current"
            '
            'LabelForm_EmailTo
            '
            Me.LabelForm_EmailTo.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_EmailTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_EmailTo.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_EmailTo.Name = "LabelForm_EmailTo"
            Me.LabelForm_EmailTo.Size = New System.Drawing.Size(93, 20)
            Me.LabelForm_EmailTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_EmailTo.TabIndex = 3
            Me.LabelForm_EmailTo.Text = "Email To:"
            '
            'TextBoxForm_Email
            '
            Me.TextBoxForm_Email.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxForm_Email.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxForm_Email.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Email.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Email.CheckSpellingOnValidate = False
            Me.TextBoxForm_Email.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.Email
            Me.TextBoxForm_Email.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxForm_Email.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_Email.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Email.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Email.FocusHighlightEnabled = True
            Me.TextBoxForm_Email.ForeColor = System.Drawing.Color.Black
            Me.TextBoxForm_Email.Location = New System.Drawing.Point(111, 38)
            Me.TextBoxForm_Email.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Email.Name = "TextBoxForm_Email"
            Me.TextBoxForm_Email.PreventEnterBeep = True
            Me.TextBoxForm_Email.SecurityEnabled = True
            Me.TextBoxForm_Email.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Email.Size = New System.Drawing.Size(348, 20)
            Me.TextBoxForm_Email.StartingFolderName = Nothing
            Me.TextBoxForm_Email.TabIndex = 4
            Me.TextBoxForm_Email.TabOnEnter = True
            '
            'CheckBoxForm_UseSES
            '
            Me.CheckBoxForm_UseSES.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxForm_UseSES.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_UseSES.CheckValue = 0
            Me.CheckBoxForm_UseSES.CheckValueChecked = 1
            Me.CheckBoxForm_UseSES.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_UseSES.CheckValueUnchecked = 0
            Me.CheckBoxForm_UseSES.ChildControls = CType(resources.GetObject("CheckBoxForm_UseSES.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_UseSES.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_UseSES.Location = New System.Drawing.Point(12, 64)
            Me.CheckBoxForm_UseSES.Name = "CheckBoxForm_UseSES"
            Me.CheckBoxForm_UseSES.OldestSibling = Nothing
            Me.CheckBoxForm_UseSES.SecurityEnabled = True
            Me.CheckBoxForm_UseSES.SiblingControls = CType(resources.GetObject("CheckBoxForm_UseSES.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_UseSES.Size = New System.Drawing.Size(285, 20)
            Me.CheckBoxForm_UseSES.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_UseSES.TabIndex = 7
            Me.CheckBoxForm_UseSES.TabOnEnter = True
            Me.CheckBoxForm_UseSES.Text = "Use SES"
            '
            'AgencyTestEmailDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(471, 96)
            Me.Controls.Add(Me.CheckBoxForm_UseSES)
            Me.Controls.Add(Me.TextBoxForm_Email)
            Me.Controls.Add(Me.LabelForm_EmailTo)
            Me.Controls.Add(Me.CheckBoxForm_UseCurrent)
            Me.Controls.Add(Me.ComboBoxForm_Employee)
            Me.Controls.Add(Me.LabelForm_Employee)
            Me.Controls.Add(Me.ButtonForm_Send)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "AgencyTestEmailDialog"
            Me.Text = "Test Email"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Send As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_Employee As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_Employee As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents CheckBoxForm_UseCurrent As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelForm_EmailTo As WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_Email As WinForm.Presentation.Controls.TextBox
        Friend WithEvents CheckBoxForm_UseSES As WinForm.Presentation.Controls.CheckBox
    End Class

End Namespace
