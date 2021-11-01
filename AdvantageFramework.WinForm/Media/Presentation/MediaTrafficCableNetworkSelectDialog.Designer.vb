Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaTrafficCableNetworkSelectDialog
        Inherits AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaTrafficCableNetworkSelectDialog))
            Me.DataGridViewForm_CableNetwork = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.SuspendLayout()
            '
            'DataGridViewForm_CableNetwork
            '
            Me.DataGridViewForm_CableNetwork.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_CableNetwork.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_CableNetwork.AutoUpdateViewCaption = True
            Me.DataGridViewForm_CableNetwork.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_CableNetwork.ItemDescription = "Cable Network(s)"
            Me.DataGridViewForm_CableNetwork.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewForm_CableNetwork.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewForm_CableNetwork.ModifyGridRowHeight = False
            Me.DataGridViewForm_CableNetwork.MultiSelect = True
            Me.DataGridViewForm_CableNetwork.Name = "DataGridViewForm_CableNetwork"
            Me.DataGridViewForm_CableNetwork.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_CableNetwork.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewForm_CableNetwork.ShowRowSelectionIfHidden = True
            Me.DataGridViewForm_CableNetwork.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_CableNetwork.Size = New System.Drawing.Size(393, 451)
            Me.DataGridViewForm_CableNetwork.TabIndex = 4
            Me.DataGridViewForm_CableNetwork.UseEmbeddedNavigator = False
            Me.DataGridViewForm_CableNetwork.ViewCaptionHeight = -1
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(249, 469)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 7
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(330, 469)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 8
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'MediaTrafficCableNetworkSelectDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(417, 501)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.DataGridViewForm_CableNetwork)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaTrafficCableNetworkSelectDialog"
            Me.Text = "Media Traffic Cable Network Select"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewForm_CableNetwork As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents ButtonForm_OK As WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As WinForm.Presentation.Controls.Button
    End Class

End Namespace

