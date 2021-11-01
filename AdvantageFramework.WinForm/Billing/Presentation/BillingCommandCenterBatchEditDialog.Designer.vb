Namespace Billing.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class BillingCommandCenterBatchEditDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BillingCommandCenterBatchEditDialog))
            Me.TextBoxForm_BatchName = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_Description = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Add = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Update = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.SuspendLayout()
            '
            'TextBoxForm_BatchName
            '
            Me.TextBoxForm_BatchName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxForm_BatchName.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_BatchName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_BatchName.CheckSpellingOnValidate = False
            Me.TextBoxForm_BatchName.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_BatchName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxForm_BatchName.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_BatchName.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_BatchName.FocusHighlightEnabled = True
            Me.TextBoxForm_BatchName.Location = New System.Drawing.Point(121, 12)
            Me.TextBoxForm_BatchName.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_BatchName.Name = "TextBoxForm_BatchName"
            Me.TextBoxForm_BatchName.SecurityEnabled = True
            Me.TextBoxForm_BatchName.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_BatchName.Size = New System.Drawing.Size(250, 20)
            Me.TextBoxForm_BatchName.StartingFolderName = Nothing
            Me.TextBoxForm_BatchName.TabIndex = 1
            Me.TextBoxForm_BatchName.TabOnEnter = True
            '
            'LabelForm_Description
            '
            Me.LabelForm_Description.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Description.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Description.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_Description.Name = "LabelForm_Description"
            Me.LabelForm_Description.Size = New System.Drawing.Size(103, 20)
            Me.LabelForm_Description.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Description.TabIndex = 0
            Me.LabelForm_Description.Text = "Batch Name:"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(296, 44)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 3
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ButtonForm_Add
            '
            Me.ButtonForm_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Add.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Add.Location = New System.Drawing.Point(215, 44)
            Me.ButtonForm_Add.Name = "ButtonForm_Add"
            Me.ButtonForm_Add.SecurityEnabled = True
            Me.ButtonForm_Add.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Add.TabIndex = 2
            Me.ButtonForm_Add.Text = "Add"
            '
            'ButtonForm_Update
            '
            Me.ButtonForm_Update.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Update.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Update.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Update.Location = New System.Drawing.Point(215, 44)
            Me.ButtonForm_Update.Name = "ButtonForm_Update"
            Me.ButtonForm_Update.SecurityEnabled = True
            Me.ButtonForm_Update.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Update.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Update.TabIndex = 2
            Me.ButtonForm_Update.Text = "Update"
            '
            'BillingCommandCenterBatchEditDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(383, 76)
            Me.Controls.Add(Me.ButtonForm_Update)
            Me.Controls.Add(Me.TextBoxForm_BatchName)
            Me.Controls.Add(Me.LabelForm_Description)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.ButtonForm_Add)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "BillingCommandCenterBatchEditDialog"
            Me.Text = "New Batch"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents TextBoxForm_BatchName As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_Description As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Add As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Update As AdvantageFramework.WinForm.Presentation.Controls.Button
    End Class

End Namespace