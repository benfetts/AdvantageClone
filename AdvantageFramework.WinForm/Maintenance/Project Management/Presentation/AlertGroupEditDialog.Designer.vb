Namespace Maintenance.ProjectManagement.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AlertGroupEditDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AlertGroupEditDialog))
            Me.ButtonForm_Add = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_AlertGroup = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_AlertGroup = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.CheckBoxForm_Inactive = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.DataGridViewRightSection_AlertGroupEmployees = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.LabelForm_SelectEmployees = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'DefaultLookAndFeelOffice2010Blue
            '
            Me.DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
            '
            'ButtonForm_Add
            '
            Me.ButtonForm_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Add.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Add.Location = New System.Drawing.Point(458, 359)
            Me.ButtonForm_Add.Name = "ButtonForm_Add"
            Me.ButtonForm_Add.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Add.TabIndex = 2
            Me.ButtonForm_Add.Text = "Add"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(539, 359)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 3
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'LabelForm_AlertGroup
            '
            Me.LabelForm_AlertGroup.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_AlertGroup.BackgroundStyle.Class = ""
            Me.LabelForm_AlertGroup.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_AlertGroup.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_AlertGroup.Name = "LabelForm_AlertGroup"
            Me.LabelForm_AlertGroup.Size = New System.Drawing.Size(69, 20)
            Me.LabelForm_AlertGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_AlertGroup.TabIndex = 4
            Me.LabelForm_AlertGroup.Text = "Alert Group:"
            '
            'TextBoxForm_AlertGroup
            '
            '
            '
            '
            Me.TextBoxForm_AlertGroup.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_AlertGroup.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_AlertGroup.CheckSpellingOnValidate = False
            Me.TextBoxForm_AlertGroup.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_AlertGroup.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_AlertGroup.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_AlertGroup.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_AlertGroup.FocusHighlightEnabled = True
            Me.TextBoxForm_AlertGroup.Location = New System.Drawing.Point(87, 12)
            Me.TextBoxForm_AlertGroup.Name = "TextBoxForm_AlertGroup"
            Me.TextBoxForm_AlertGroup.Size = New System.Drawing.Size(454, 20)
            Me.TextBoxForm_AlertGroup.TabIndex = 5
            Me.TextBoxForm_AlertGroup.TabOnEnter = True
            '
            'CheckBoxForm_Inactive
            '
            '
            '
            '
            Me.CheckBoxForm_Inactive.BackgroundStyle.Class = ""
            Me.CheckBoxForm_Inactive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_Inactive.CheckValue = 0
            Me.CheckBoxForm_Inactive.CheckValueChecked = 1
            Me.CheckBoxForm_Inactive.CheckValueUnchecked = 0
            Me.CheckBoxForm_Inactive.ChildControls = CType(resources.GetObject("CheckBoxForm_Inactive.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Inactive.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_Inactive.Location = New System.Drawing.Point(547, 12)
            Me.CheckBoxForm_Inactive.Name = "CheckBoxForm_Inactive"
            Me.CheckBoxForm_Inactive.OldestSibling = Nothing
            Me.CheckBoxForm_Inactive.SiblingControls = CType(resources.GetObject("CheckBoxForm_Inactive.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Inactive.Size = New System.Drawing.Size(67, 20)
            Me.CheckBoxForm_Inactive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_Inactive.TabIndex = 6
            Me.CheckBoxForm_Inactive.Text = "Inactive"
            '
            'DataGridViewRightSection_AlertGroupEmployees
            '
            Me.DataGridViewRightSection_AlertGroupEmployees.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRightSection_AlertGroupEmployees.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewRightSection_AlertGroupEmployees.DataSource = Nothing
            Me.DataGridViewRightSection_AlertGroupEmployees.ItemDescription = ""
            Me.DataGridViewRightSection_AlertGroupEmployees.Location = New System.Drawing.Point(12, 64)
            Me.DataGridViewRightSection_AlertGroupEmployees.MultiSelect = True
            Me.DataGridViewRightSection_AlertGroupEmployees.Name = "DataGridViewRightSection_AlertGroupEmployees"
            Me.DataGridViewRightSection_AlertGroupEmployees.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewRightSection_AlertGroupEmployees.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRightSection_AlertGroupEmployees.Size = New System.Drawing.Size(602, 289)
            Me.DataGridViewRightSection_AlertGroupEmployees.TabIndex = 7
            '
            'LabelForm_SelectEmployees
            '
            Me.LabelForm_SelectEmployees.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_SelectEmployees.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_SelectEmployees.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_SelectEmployees.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelForm_SelectEmployees.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_SelectEmployees.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_SelectEmployees.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_SelectEmployees.BackgroundStyle.Class = ""
            Me.LabelForm_SelectEmployees.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_SelectEmployees.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelForm_SelectEmployees.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_SelectEmployees.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_SelectEmployees.Name = "LabelForm_SelectEmployees"
            Me.LabelForm_SelectEmployees.Size = New System.Drawing.Size(602, 20)
            Me.LabelForm_SelectEmployees.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_SelectEmployees.TabIndex = 25
            Me.LabelForm_SelectEmployees.Text = "Select Employees to add to the Alert Group (hold CTRL to select multiple)"
            '
            'AlertGroupEditDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(626, 391)
            Me.Controls.Add(Me.LabelForm_SelectEmployees)
            Me.Controls.Add(Me.DataGridViewRightSection_AlertGroupEmployees)
            Me.Controls.Add(Me.CheckBoxForm_Inactive)
            Me.Controls.Add(Me.TextBoxForm_AlertGroup)
            Me.Controls.Add(Me.LabelForm_AlertGroup)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.ButtonForm_Add)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "AlertGroupEditDialog"
            Me.Text = "Alert Group"
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Add As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_AlertGroup As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_AlertGroup As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents CheckBoxForm_Inactive As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents DataGridViewRightSection_AlertGroupEmployees As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents LabelForm_SelectEmployees As AdvantageFramework.WinForm.Presentation.Controls.Label
    End Class

End Namespace