Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaBroadcastWorksheetMarketDetailRateDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaBroadcastWorksheetMarketDetailRateDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.DataGridViewForm_LineDateRate = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(561, 79)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 1
            Me.ButtonForm_OK.Text = "OK"
            '
            'DataGridViewForm_LineDateRate
            '
            Me.DataGridViewForm_LineDateRate.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_LineDateRate.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_LineDateRate.AutoUpdateViewCaption = True
            Me.DataGridViewForm_LineDateRate.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_LineDateRate.ItemDescription = "Date Rate(s)"
            Me.DataGridViewForm_LineDateRate.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewForm_LineDateRate.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewForm_LineDateRate.ModifyGridRowHeight = False
            Me.DataGridViewForm_LineDateRate.MultiSelect = False
            Me.DataGridViewForm_LineDateRate.Name = "DataGridViewForm_LineDateRate"
            Me.DataGridViewForm_LineDateRate.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_LineDateRate.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewForm_LineDateRate.ShowRowSelectionIfHidden = True
            Me.DataGridViewForm_LineDateRate.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_LineDateRate.Size = New System.Drawing.Size(624, 61)
            Me.DataGridViewForm_LineDateRate.TabIndex = 0
            Me.DataGridViewForm_LineDateRate.UseEmbeddedNavigator = False
            Me.DataGridViewForm_LineDateRate.ViewCaptionHeight = -1
            '
            'MediaBroadcastWorksheetMarketDetailRateDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(648, 111)
            Me.Controls.Add(Me.DataGridViewForm_LineDateRate)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaBroadcastWorksheetMarketDetailRateDialog"
            Me.Text = "Date Rates"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents DataGridViewForm_LineDateRate As WinForm.MVC.Presentation.Controls.DataGridView
    End Class

End Namespace