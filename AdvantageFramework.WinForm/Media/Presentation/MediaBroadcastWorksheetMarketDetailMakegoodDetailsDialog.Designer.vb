Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaBroadcastWorksheetMarketDetailMakegoodDetailsDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaBroadcastWorksheetMarketDetailMakegoodDetailsDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.BandedDataGridViewForm_MakegoodDetails = New AdvantageFramework.WinForm.MVC.Presentation.Controls.BandedDataGridView()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(710, 450)
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
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(791, 450)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 8
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'BandedDataGridViewForm_MakegoodDetails
            '
            Me.BandedDataGridViewForm_MakegoodDetails.AllowSelectGroupHeaderRow = True
            Me.BandedDataGridViewForm_MakegoodDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.BandedDataGridViewForm_MakegoodDetails.AutoUpdateViewCaption = True
            Me.BandedDataGridViewForm_MakegoodDetails.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.BandedDataGridViewForm_MakegoodDetails.ItemDescription = "Makegood Detail(s)"
            Me.BandedDataGridViewForm_MakegoodDetails.Location = New System.Drawing.Point(12, 12)
            Me.BandedDataGridViewForm_MakegoodDetails.ModifyColumnSettingsOnEachDataSource = True
            Me.BandedDataGridViewForm_MakegoodDetails.ModifyGridRowHeight = True
            Me.BandedDataGridViewForm_MakegoodDetails.MultiSelect = True
            Me.BandedDataGridViewForm_MakegoodDetails.Name = "BandedDataGridViewForm_MakegoodDetails"
            Me.BandedDataGridViewForm_MakegoodDetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.BandedDataGridViewForm_MakegoodDetails.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.BandedDataGridViewForm_MakegoodDetails.ShowRowSelectionIfHidden = True
            Me.BandedDataGridViewForm_MakegoodDetails.ShowSelectDeselectAllButtons = False
            Me.BandedDataGridViewForm_MakegoodDetails.Size = New System.Drawing.Size(854, 432)
            Me.BandedDataGridViewForm_MakegoodDetails.TabIndex = 9
            Me.BandedDataGridViewForm_MakegoodDetails.UseEmbeddedNavigator = False
            Me.BandedDataGridViewForm_MakegoodDetails.ViewCaptionHeight = -1
            '
            'MediaBroadcastWorksheetMarketDetailMakegoodDetailsDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(878, 482)
            Me.Controls.Add(Me.BandedDataGridViewForm_MakegoodDetails)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaBroadcastWorksheetMarketDetailMakegoodDetailsDialog"
            Me.Text = "Makegood Details"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents BandedDataGridViewForm_MakegoodDetails As WinForm.MVC.Presentation.Controls.BandedDataGridView
    End Class

End Namespace