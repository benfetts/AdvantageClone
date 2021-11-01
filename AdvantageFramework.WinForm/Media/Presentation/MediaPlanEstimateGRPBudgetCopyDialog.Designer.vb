Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaPlanEstimateGRPBudgetCopyDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaPlanEstimateGRPBudgetCopyDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewForm_AvailableMarkets = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewForm_SelectedMarkets = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.ButtonRightSection_RemoveMarket = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonRightSection_AddMarket = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(631, 499)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 10
            Me.ButtonForm_OK.Text = "OK"
            '
            'DataGridViewForm_AvailableMarkets
            '
            Me.DataGridViewForm_AvailableMarkets.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_AvailableMarkets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_AvailableMarkets.AutoUpdateViewCaption = True
            Me.DataGridViewForm_AvailableMarkets.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_AvailableMarkets.ItemDescription = "Available"
            Me.DataGridViewForm_AvailableMarkets.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewForm_AvailableMarkets.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewForm_AvailableMarkets.ModifyGridRowHeight = False
            Me.DataGridViewForm_AvailableMarkets.MultiSelect = False
            Me.DataGridViewForm_AvailableMarkets.Name = "DataGridViewForm_AvailableMarkets"
            Me.DataGridViewForm_AvailableMarkets.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_AvailableMarkets.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewForm_AvailableMarkets.ShowRowSelectionIfHidden = True
            Me.DataGridViewForm_AvailableMarkets.ShowSelectDeselectAllButtons = True
            Me.DataGridViewForm_AvailableMarkets.Size = New System.Drawing.Size(333, 481)
            Me.DataGridViewForm_AvailableMarkets.TabIndex = 6
            Me.DataGridViewForm_AvailableMarkets.UseEmbeddedNavigator = False
            Me.DataGridViewForm_AvailableMarkets.ViewCaptionHeight = -1
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(712, 499)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 11
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'DataGridViewForm_SelectedMarkets
            '
            Me.DataGridViewForm_SelectedMarkets.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_SelectedMarkets.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_SelectedMarkets.AutoUpdateViewCaption = True
            Me.DataGridViewForm_SelectedMarkets.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_SelectedMarkets.ItemDescription = "Selected"
            Me.DataGridViewForm_SelectedMarkets.Location = New System.Drawing.Point(432, 12)
            Me.DataGridViewForm_SelectedMarkets.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewForm_SelectedMarkets.ModifyGridRowHeight = False
            Me.DataGridViewForm_SelectedMarkets.MultiSelect = True
            Me.DataGridViewForm_SelectedMarkets.Name = "DataGridViewForm_SelectedMarkets"
            Me.DataGridViewForm_SelectedMarkets.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_SelectedMarkets.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewForm_SelectedMarkets.ShowRowSelectionIfHidden = True
            Me.DataGridViewForm_SelectedMarkets.ShowSelectDeselectAllButtons = True
            Me.DataGridViewForm_SelectedMarkets.Size = New System.Drawing.Size(355, 481)
            Me.DataGridViewForm_SelectedMarkets.TabIndex = 7
            Me.DataGridViewForm_SelectedMarkets.UseEmbeddedNavigator = False
            Me.DataGridViewForm_SelectedMarkets.ViewCaptionHeight = -1
            '
            'ButtonRightSection_RemoveMarket
            '
            Me.ButtonRightSection_RemoveMarket.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_RemoveMarket.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_RemoveMarket.Location = New System.Drawing.Point(351, 38)
            Me.ButtonRightSection_RemoveMarket.Name = "ButtonRightSection_RemoveMarket"
            Me.ButtonRightSection_RemoveMarket.SecurityEnabled = True
            Me.ButtonRightSection_RemoveMarket.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightSection_RemoveMarket.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_RemoveMarket.TabIndex = 13
            Me.ButtonRightSection_RemoveMarket.Text = "<"
            '
            'ButtonRightSection_AddMarket
            '
            Me.ButtonRightSection_AddMarket.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_AddMarket.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_AddMarket.Location = New System.Drawing.Point(351, 12)
            Me.ButtonRightSection_AddMarket.Name = "ButtonRightSection_AddMarket"
            Me.ButtonRightSection_AddMarket.SecurityEnabled = True
            Me.ButtonRightSection_AddMarket.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightSection_AddMarket.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_AddMarket.TabIndex = 12
            Me.ButtonRightSection_AddMarket.Text = ">"
            '
            'MediaPlanEstimateGRPBudgetCopyDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(799, 531)
            Me.Controls.Add(Me.ButtonRightSection_RemoveMarket)
            Me.Controls.Add(Me.ButtonRightSection_AddMarket)
            Me.Controls.Add(Me.DataGridViewForm_SelectedMarkets)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.DataGridViewForm_AvailableMarkets)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaPlanEstimateGRPBudgetCopyDialog"
            Me.Text = "Media Plan Estimate GRP Allocation Copy"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewForm_AvailableMarkets As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewForm_SelectedMarkets As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents ButtonRightSection_RemoveMarket As WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ButtonRightSection_AddMarket As WinForm.MVC.Presentation.Controls.Button
    End Class

End Namespace
