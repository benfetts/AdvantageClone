Namespace Security.Setup.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class GroupEditDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GroupEditDialog))
            Me.TextBoxForm_Name = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_Name = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_Description = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_Description = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ButtonForm_Update = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Add = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.SuspendLayout()
            '
            'TextBoxForm_Name
            '
            Me.TextBoxForm_Name.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Name.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Name.Location = New System.Drawing.Point(78, 12)
            Me.TextBoxForm_Name.Name = "TextBoxForm_Name"
            Me.TextBoxForm_Name.Size = New System.Drawing.Size(382, 20)
            Me.TextBoxForm_Name.TabIndex = 1
            '
            'LabelForm_Name
            '
            Me.LabelForm_Name.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_Name.Name = "LabelForm_Name"
            Me.LabelForm_Name.Size = New System.Drawing.Size(60, 20)
            Me.LabelForm_Name.TabIndex = 0
            Me.LabelForm_Name.Text = "Name:"
            '
            'TextBoxForm_Description
            '
            Me.TextBoxForm_Description.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Description.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Description.Location = New System.Drawing.Point(78, 38)
            Me.TextBoxForm_Description.Name = "TextBoxForm_Description"
            Me.TextBoxForm_Description.Size = New System.Drawing.Size(382, 20)
            Me.TextBoxForm_Description.TabIndex = 3
            '
            'LabelForm_Description
            '
            Me.LabelForm_Description.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_Description.Name = "LabelForm_Description"
            Me.LabelForm_Description.Size = New System.Drawing.Size(60, 20)
            Me.LabelForm_Description.TabIndex = 2
            Me.LabelForm_Description.Text = "Description:"
            '
            'ButtonForm_Update
            '
            Me.ButtonForm_Update.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Update.Location = New System.Drawing.Point(304, 64)
            Me.ButtonForm_Update.Name = "ButtonForm_Update"
            Me.ButtonForm_Update.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Update.TabIndex = 5
            Me.ButtonForm_Update.Text = "Update"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(385, 64)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.TabIndex = 6
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ButtonForm_Add
            '
            Me.ButtonForm_Add.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Add.Location = New System.Drawing.Point(304, 64)
            Me.ButtonForm_Add.Name = "ButtonForm_Add"
            Me.ButtonForm_Add.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Add.TabIndex = 4
            Me.ButtonForm_Add.Text = "Add"
            '
            'GroupEditDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(472, 96)
            Me.Controls.Add(Me.ButtonForm_Add)
            Me.Controls.Add(Me.ButtonForm_Update)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.TextBoxForm_Name)
            Me.Controls.Add(Me.LabelForm_Name)
            Me.Controls.Add(Me.TextBoxForm_Description)
            Me.Controls.Add(Me.LabelForm_Description)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "GroupEditDialog"
            Me.Text = "Add Group"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents TextBoxForm_Name As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_Name As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_Description As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_Description As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonForm_Update As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Add As AdvantageFramework.WinForm.Presentation.Controls.Button
    End Class

End Namespace