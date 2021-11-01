Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaBroadcastWorksheetMarketDetailSubmarketDemoDialog
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
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaBroadcastWorksheetMarketDetailSubmarketDemoDialog))
            Me.ToolTipController = New DevExpress.Utils.ToolTipController(Me.components)
            Me.BandedDataGridViewForm_MarketDetails = New AdvantageFramework.WinForm.MVC.Presentation.Controls.BandedDataGridView()
            Me.ButtonForm_Ratings = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonForm_GRP = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonForm_Imps = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonForm_Percentage = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonForm_Allocation = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonForm_GIMP = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonForm_Export = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.SuspendLayout()
            '
            'BandedDataGridViewForm_MarketDetails
            '
            Me.BandedDataGridViewForm_MarketDetails.AllowSelectGroupHeaderRow = True
            Me.BandedDataGridViewForm_MarketDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.BandedDataGridViewForm_MarketDetails.AutoUpdateViewCaption = True
            Me.BandedDataGridViewForm_MarketDetails.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.BandedDataGridViewForm_MarketDetails.ItemDescription = "Item(s)"
            Me.BandedDataGridViewForm_MarketDetails.Location = New System.Drawing.Point(12, 64)
            Me.BandedDataGridViewForm_MarketDetails.ModifyColumnSettingsOnEachDataSource = True
            Me.BandedDataGridViewForm_MarketDetails.ModifyGridRowHeight = True
            Me.BandedDataGridViewForm_MarketDetails.MultiSelect = True
            Me.BandedDataGridViewForm_MarketDetails.Name = "BandedDataGridViewForm_MarketDetails"
            Me.BandedDataGridViewForm_MarketDetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.BandedDataGridViewForm_MarketDetails.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.BandedDataGridViewForm_MarketDetails.ShowRowSelectionIfHidden = True
            Me.BandedDataGridViewForm_MarketDetails.ShowSelectDeselectAllButtons = False
            Me.BandedDataGridViewForm_MarketDetails.Size = New System.Drawing.Size(647, 393)
            Me.BandedDataGridViewForm_MarketDetails.TabIndex = 7
            Me.BandedDataGridViewForm_MarketDetails.UseEmbeddedNavigator = False
            Me.BandedDataGridViewForm_MarketDetails.ViewCaptionHeight = -1
            '
            'ButtonForm_Ratings
            '
            Me.ButtonForm_Ratings.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Ratings.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Ratings.Checked = True
            Me.ButtonForm_Ratings.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Ratings.Location = New System.Drawing.Point(422, 12)
            Me.ButtonForm_Ratings.Name = "ButtonForm_Ratings"
            Me.ButtonForm_Ratings.SecurityEnabled = True
            Me.ButtonForm_Ratings.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Ratings.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Ratings.TabIndex = 1
            Me.ButtonForm_Ratings.Text = "Ratings"
            '
            'ButtonForm_GRP
            '
            Me.ButtonForm_GRP.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_GRP.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_GRP.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_GRP.Location = New System.Drawing.Point(503, 12)
            Me.ButtonForm_GRP.Name = "ButtonForm_GRP"
            Me.ButtonForm_GRP.SecurityEnabled = True
            Me.ButtonForm_GRP.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_GRP.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_GRP.TabIndex = 2
            Me.ButtonForm_GRP.Text = "GRP"
            '
            'ButtonForm_Imps
            '
            Me.ButtonForm_Imps.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Imps.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Imps.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Imps.Location = New System.Drawing.Point(584, 12)
            Me.ButtonForm_Imps.Name = "ButtonForm_Imps"
            Me.ButtonForm_Imps.SecurityEnabled = True
            Me.ButtonForm_Imps.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Imps.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Imps.TabIndex = 3
            Me.ButtonForm_Imps.Text = "Imps (000)"
            '
            'ButtonForm_Percentage
            '
            Me.ButtonForm_Percentage.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Percentage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Percentage.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Percentage.Location = New System.Drawing.Point(584, 38)
            Me.ButtonForm_Percentage.Name = "ButtonForm_Percentage"
            Me.ButtonForm_Percentage.SecurityEnabled = True
            Me.ButtonForm_Percentage.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Percentage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Percentage.TabIndex = 6
            Me.ButtonForm_Percentage.Text = "$ Percentage"
            '
            'ButtonForm_Allocation
            '
            Me.ButtonForm_Allocation.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Allocation.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Allocation.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Allocation.Location = New System.Drawing.Point(503, 38)
            Me.ButtonForm_Allocation.Name = "ButtonForm_Allocation"
            Me.ButtonForm_Allocation.SecurityEnabled = True
            Me.ButtonForm_Allocation.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Allocation.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Allocation.TabIndex = 5
            Me.ButtonForm_Allocation.Text = "$ Allocation"
            '
            'ButtonForm_GIMP
            '
            Me.ButtonForm_GIMP.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_GIMP.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_GIMP.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_GIMP.Location = New System.Drawing.Point(422, 38)
            Me.ButtonForm_GIMP.Name = "ButtonForm_GIMP"
            Me.ButtonForm_GIMP.SecurityEnabled = True
            Me.ButtonForm_GIMP.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_GIMP.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_GIMP.TabIndex = 4
            Me.ButtonForm_GIMP.Text = "GIMP"
            '
            'ButtonForm_Export
            '
            Me.ButtonForm_Export.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Export.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Export.Location = New System.Drawing.Point(12, 12)
            Me.ButtonForm_Export.Name = "ButtonForm_Export"
            Me.ButtonForm_Export.SecurityEnabled = True
            Me.ButtonForm_Export.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Export.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Export.TabIndex = 0
            Me.ButtonForm_Export.Text = "Export"
            '
            'MediaBroadcastWorksheetMarketDetailSubmarketDemoDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(671, 469)
            Me.Controls.Add(Me.ButtonForm_Export)
            Me.Controls.Add(Me.ButtonForm_Percentage)
            Me.Controls.Add(Me.ButtonForm_Allocation)
            Me.Controls.Add(Me.ButtonForm_GIMP)
            Me.Controls.Add(Me.ButtonForm_Imps)
            Me.Controls.Add(Me.ButtonForm_GRP)
            Me.Controls.Add(Me.ButtonForm_Ratings)
            Me.Controls.Add(Me.BandedDataGridViewForm_MarketDetails)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaBroadcastWorksheetMarketDetailSubmarketDemoDialog"
            Me.ShowInTaskbar = False
            Me.Text = "Market Demos"
            Me.TopMost = True
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ToolTipController As DevExpress.Utils.ToolTipController
        Friend WithEvents BandedDataGridViewForm_MarketDetails As WinForm.MVC.Presentation.Controls.BandedDataGridView
        Friend WithEvents ButtonForm_Ratings As WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ButtonForm_GRP As WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Imps As WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Percentage As WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Allocation As WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ButtonForm_GIMP As WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Export As WinForm.MVC.Presentation.Controls.Button
    End Class

End Namespace