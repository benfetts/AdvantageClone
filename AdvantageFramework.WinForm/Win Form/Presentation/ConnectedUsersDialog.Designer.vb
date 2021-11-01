Namespace WinForm.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ConnectedUsersDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConnectedUsersDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewForm_ConnectedUsers = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'DefaultLookAndFeelOffice2010Blue
            '
            Me.DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(487, 341)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 3
            Me.ButtonForm_OK.Text = "OK"
            '
            'DataGridViewForm_ConnectedUsers
            '
            Me.DataGridViewForm_ConnectedUsers.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.[Default]
            Me.DataGridViewForm_ConnectedUsers.DataSource = Nothing
            Me.DataGridViewForm_ConnectedUsers.ItemDescription = ""
            Me.DataGridViewForm_ConnectedUsers.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewForm_ConnectedUsers.MultiSelect = True
            Me.DataGridViewForm_ConnectedUsers.Name = "DataGridViewForm_ConnectedUsers"
            Me.DataGridViewForm_ConnectedUsers.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_ConnectedUsers.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_ConnectedUsers.Size = New System.Drawing.Size(550, 323)
            Me.DataGridViewForm_ConnectedUsers.TabIndex = 4
            '
            'ConnectedUsersDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(574, 373)
            Me.Controls.Add(Me.DataGridViewForm_ConnectedUsers)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ConnectedUsersDialog"
            Me.Text = "Connected Users"
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewForm_ConnectedUsers As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
    End Class

End Namespace