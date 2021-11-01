<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CRUDDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CRUDDialog))
        Me.DataGridViewForm_Objects = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
        Me.ButtonForm_Add = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonForm_Edit = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonForm_Delete = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonForm_Select = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonForm_Close = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.SuspendLayout()
        '
        'DataGridViewForm_Objects
        '
        Me.DataGridViewForm_Objects.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridViewForm_Objects.Location = New System.Drawing.Point(12, 12)
        Me.DataGridViewForm_Objects.Name = "DataGridViewForm_Objects"
        Me.DataGridViewForm_Objects.Size = New System.Drawing.Size(663, 344)
        Me.DataGridViewForm_Objects.TabIndex = 0
        Me.DataGridViewForm_Objects.DataSource = Nothing
        Me.DataGridViewForm_Objects.MultiSelect = True
        Me.DataGridViewForm_Objects.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.[Default]
        '
        'ButtonForm_Add
        '
        Me.ButtonForm_Add.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonForm_Add.Location = New System.Drawing.Point(12, 362)
        Me.ButtonForm_Add.Name = "ButtonForm_Add"
        Me.ButtonForm_Add.Size = New System.Drawing.Size(75, 20)
        Me.ButtonForm_Add.TabIndex = 1
        Me.ButtonForm_Add.Text = "Add"
        '
        'ButtonForm_Edit
        '
        Me.ButtonForm_Edit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonForm_Edit.Location = New System.Drawing.Point(93, 362)
        Me.ButtonForm_Edit.Name = "ButtonForm_Edit"
        Me.ButtonForm_Edit.Size = New System.Drawing.Size(75, 20)
        Me.ButtonForm_Edit.TabIndex = 2
        Me.ButtonForm_Edit.Text = "Edit"
        '
        'ButtonForm_Delete
        '
        Me.ButtonForm_Delete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonForm_Delete.Location = New System.Drawing.Point(174, 362)
        Me.ButtonForm_Delete.Name = "ButtonForm_Delete"
        Me.ButtonForm_Delete.Size = New System.Drawing.Size(75, 20)
        Me.ButtonForm_Delete.TabIndex = 3
        Me.ButtonForm_Delete.Text = "Delete"
        '
        'ButtonForm_Cancel
        '
        Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonForm_Cancel.Location = New System.Drawing.Point(600, 362)
        Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
        Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
        Me.ButtonForm_Cancel.TabIndex = 5
        Me.ButtonForm_Cancel.Text = "Cancel"
        '
        'ButtonForm_Select
        '
        Me.ButtonForm_Select.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonForm_Select.Location = New System.Drawing.Point(519, 362)
        Me.ButtonForm_Select.Name = "ButtonForm_Select"
        Me.ButtonForm_Select.Size = New System.Drawing.Size(75, 20)
        Me.ButtonForm_Select.TabIndex = 4
        Me.ButtonForm_Select.Text = "Select"
        '
        'ButtonForm_Close
        '
        Me.ButtonForm_Close.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonForm_Close.Location = New System.Drawing.Point(600, 362)
        Me.ButtonForm_Close.Name = "ButtonForm_Close"
        Me.ButtonForm_Close.Size = New System.Drawing.Size(75, 20)
        Me.ButtonForm_Close.TabIndex = 6
        Me.ButtonForm_Close.Text = "Close"
        '
        'CRUDDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(687, 394)
        Me.Controls.Add(Me.ButtonForm_Close)
        Me.Controls.Add(Me.ButtonForm_Cancel)
        Me.Controls.Add(Me.ButtonForm_Select)
        Me.Controls.Add(Me.ButtonForm_Delete)
        Me.Controls.Add(Me.ButtonForm_Edit)
        Me.Controls.Add(Me.ButtonForm_Add)
        Me.Controls.Add(Me.DataGridViewForm_Objects)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CRUDDialog"
        Me.Text = "CRUD Dialog"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridViewForm_Objects As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
    Friend WithEvents ButtonForm_Add As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents ButtonForm_Edit As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents ButtonForm_Delete As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents ButtonForm_Select As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents ButtonForm_Close As AdvantageFramework.WinForm.Presentation.Controls.Button
End Class
