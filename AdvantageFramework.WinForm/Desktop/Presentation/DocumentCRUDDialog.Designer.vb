Namespace Desktop.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class DocumentCRUDDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DocumentCRUDDialog))
            Me.ButtonForm_Close = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.Button1 = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Select = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Delete = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Add = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DocumentManagerControlForm_Documents = New AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl()
            Me.SuspendLayout()
            '
            'ButtonForm_Close
            '
            Me.ButtonForm_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Close.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Close.Location = New System.Drawing.Point(433, 335)
            Me.ButtonForm_Close.Name = "ButtonForm_Close"
            Me.ButtonForm_Close.SecurityEnabled = True
            Me.ButtonForm_Close.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Close.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Close.TabIndex = 13
            Me.ButtonForm_Close.Text = "Close"
            '
            'Button1
            '
            Me.Button1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Button1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.Button1.Location = New System.Drawing.Point(433, 335)
            Me.Button1.Name = "Button1"
            Me.Button1.SecurityEnabled = True
            Me.Button1.Size = New System.Drawing.Size(75, 20)
            Me.Button1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Button1.TabIndex = 12
            Me.Button1.Text = "Cancel"
            '
            'ButtonForm_Select
            '
            Me.ButtonForm_Select.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Select.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Select.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Select.Location = New System.Drawing.Point(352, 335)
            Me.ButtonForm_Select.Name = "ButtonForm_Select"
            Me.ButtonForm_Select.SecurityEnabled = True
            Me.ButtonForm_Select.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Select.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Select.TabIndex = 11
            Me.ButtonForm_Select.Text = "Select"
            '
            'ButtonForm_Delete
            '
            Me.ButtonForm_Delete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Delete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Delete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Delete.Location = New System.Drawing.Point(93, 335)
            Me.ButtonForm_Delete.Name = "ButtonForm_Delete"
            Me.ButtonForm_Delete.SecurityEnabled = True
            Me.ButtonForm_Delete.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Delete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Delete.TabIndex = 10
            Me.ButtonForm_Delete.Text = "Delete"
            '
            'ButtonForm_Add
            '
            Me.ButtonForm_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Add.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Add.Location = New System.Drawing.Point(12, 335)
            Me.ButtonForm_Add.Name = "ButtonForm_Add"
            Me.ButtonForm_Add.SecurityEnabled = True
            Me.ButtonForm_Add.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Add.TabIndex = 8
            Me.ButtonForm_Add.Text = "Add"
            '
            'DocumentManagerControlForm_Documents
            '
            Me.DocumentManagerControlForm_Documents.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DocumentManagerControlForm_Documents.Location = New System.Drawing.Point(15, 12)
            Me.DocumentManagerControlForm_Documents.Name = "DocumentManagerControlForm_Documents"
            Me.DocumentManagerControlForm_Documents.Size = New System.Drawing.Size(493, 317)
            Me.DocumentManagerControlForm_Documents.TabIndex = 14
            '
            'DocumentCRUDDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(520, 367)
            Me.Controls.Add(Me.DocumentManagerControlForm_Documents)
            Me.Controls.Add(Me.ButtonForm_Close)
            Me.Controls.Add(Me.Button1)
            Me.Controls.Add(Me.ButtonForm_Select)
            Me.Controls.Add(Me.ButtonForm_Delete)
            Me.Controls.Add(Me.ButtonForm_Add)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "DocumentCRUDDialog"
            Me.Text = "Documents"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Close As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents Button1 As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Select As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Delete As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Add As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DocumentManagerControlForm_Documents As AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl

    End Class

End Namespace