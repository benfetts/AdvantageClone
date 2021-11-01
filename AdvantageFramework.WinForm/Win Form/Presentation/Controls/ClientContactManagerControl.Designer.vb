Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ClientContactManagerControl
        Inherits AdvantageFramework.WinForm.Presentation.Controls.BaseControls.BaseUserControl

        'UserControl overrides dispose to clean up the component list.
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
            Me.DataGridViewControl_Contacts = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.SuspendLayout()
            '
            'DataGridViewControl_Contacts
            '
            Me.DataGridViewControl_Contacts.AllowSelectGroupHeaderRow = True
            Me.DataGridViewControl_Contacts.AutoFilterLookupColumns = False
            Me.DataGridViewControl_Contacts.AutoloadRepositoryDatasource = True
            Me.DataGridViewControl_Contacts.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.[Default]
            Me.DataGridViewControl_Contacts.DataSource = Nothing
            Me.DataGridViewControl_Contacts.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DataGridViewControl_Contacts.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewControl_Contacts.ItemDescription = "Contact(s)"
            Me.DataGridViewControl_Contacts.Location = New System.Drawing.Point(0, 0)
            Me.DataGridViewControl_Contacts.MultiSelect = True
            Me.DataGridViewControl_Contacts.Name = "DataGridViewControl_Contacts"
            Me.DataGridViewControl_Contacts.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewControl_Contacts.ShowSelectDeselectAllButtons = False
            Me.DataGridViewControl_Contacts.Size = New System.Drawing.Size(603, 341)
            Me.DataGridViewControl_Contacts.TabIndex = 2
            Me.DataGridViewControl_Contacts.UseEmbeddedNavigator = False
            Me.DataGridViewControl_Contacts.ViewCaptionHeight = -1
            '
            'ClientContactManagerControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.DataGridViewControl_Contacts)
            Me.Name = "ClientContactManagerControl"
            Me.Size = New System.Drawing.Size(603, 341)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewControl_Contacts As AdvantageFramework.WinForm.Presentation.Controls.DataGridView

    End Class

End Namespace
