Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaBroadcastWorksheetMarketReplaceBuyerDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaBroadcastWorksheetMarketReplaceBuyerDialog))
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.LabelForm_Find = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.Label1 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.SearchableComboBoxForm_FindBuyer = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewForm_Buyer = New AdvantageFramework.WinForm.MVC.Presentation.Controls.GridView()
            Me.SearchableComboBoxForm_ReplaceBuyer = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox()
            Me.GridView1 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.GridView()
            CType(Me.SearchableComboBoxForm_FindBuyer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewForm_Buyer, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxForm_ReplaceBuyer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(372, 72)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 5
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(291, 72)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 4
            Me.ButtonForm_OK.Text = "OK"
            '
            'LabelForm_Find
            '
            Me.LabelForm_Find.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Find.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Find.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_Find.Name = "LabelForm_Find"
            Me.LabelForm_Find.Size = New System.Drawing.Size(81, 20)
            Me.LabelForm_Find.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Find.TabIndex = 0
            Me.LabelForm_Find.Text = "Find Buyer:"
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.Label1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label1.Location = New System.Drawing.Point(12, 38)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(81, 20)
            Me.Label1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label1.TabIndex = 2
            Me.Label1.Text = "Replace With:"
            '
            'SearchableComboBoxForm_FindBuyer
            '
            Me.SearchableComboBoxForm_FindBuyer.ActiveFilterString = ""
            Me.SearchableComboBoxForm_FindBuyer.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxForm_FindBuyer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxForm_FindBuyer.AutoFillMode = False
            Me.SearchableComboBoxForm_FindBuyer.BookmarkingEnabled = False
            Me.SearchableComboBoxForm_FindBuyer.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.Type.Employee
            Me.SearchableComboBoxForm_FindBuyer.DataSource = Nothing
            Me.SearchableComboBoxForm_FindBuyer.DisableMouseWheel = True
            Me.SearchableComboBoxForm_FindBuyer.DisplayName = "Find Buyer"
            Me.SearchableComboBoxForm_FindBuyer.EditValue = "Select Buyer"
            Me.SearchableComboBoxForm_FindBuyer.EnterMoveNextControl = True
            Me.SearchableComboBoxForm_FindBuyer.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxForm_FindBuyer.Location = New System.Drawing.Point(99, 12)
            Me.SearchableComboBoxForm_FindBuyer.Name = "SearchableComboBoxForm_FindBuyer"
            Me.SearchableComboBoxForm_FindBuyer.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxForm_FindBuyer.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxForm_FindBuyer.Properties.NullText = "Select Buyer"
            Me.SearchableComboBoxForm_FindBuyer.Properties.PopupView = Me.SearchableComboBoxViewForm_Buyer
            Me.SearchableComboBoxForm_FindBuyer.Properties.ValueMember = "Code"
            Me.SearchableComboBoxForm_FindBuyer.SecurityEnabled = True
            Me.SearchableComboBoxForm_FindBuyer.SelectedValue = "Select Buyer"
            Me.SearchableComboBoxForm_FindBuyer.Size = New System.Drawing.Size(348, 20)
            Me.SearchableComboBoxForm_FindBuyer.TabIndex = 1
            '
            'SearchableComboBoxViewForm_Buyer
            '
            Me.SearchableComboBoxViewForm_Buyer.AFActiveFilterString = ""
            Me.SearchableComboBoxViewForm_Buyer.EnableDisabledRows = False
            Me.SearchableComboBoxViewForm_Buyer.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewForm_Buyer.ModifyColumnSettingsOnEachDataSource = True
            Me.SearchableComboBoxViewForm_Buyer.ModifyGridRowHeight = False
            Me.SearchableComboBoxViewForm_Buyer.Name = "SearchableComboBoxViewForm_Buyer"
            Me.SearchableComboBoxViewForm_Buyer.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewForm_Buyer.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewForm_Buyer.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewForm_Buyer.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboBoxViewForm_Buyer.SkipSettingFontOnModifyColumn = False
            '
            'SearchableComboBoxForm_ReplaceBuyer
            '
            Me.SearchableComboBoxForm_ReplaceBuyer.ActiveFilterString = ""
            Me.SearchableComboBoxForm_ReplaceBuyer.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxForm_ReplaceBuyer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxForm_ReplaceBuyer.AutoFillMode = False
            Me.SearchableComboBoxForm_ReplaceBuyer.BookmarkingEnabled = False
            Me.SearchableComboBoxForm_ReplaceBuyer.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.Type.Employee
            Me.SearchableComboBoxForm_ReplaceBuyer.DataSource = Nothing
            Me.SearchableComboBoxForm_ReplaceBuyer.DisableMouseWheel = True
            Me.SearchableComboBoxForm_ReplaceBuyer.DisplayName = "Replace With Buyer"
            Me.SearchableComboBoxForm_ReplaceBuyer.EnterMoveNextControl = True
            Me.SearchableComboBoxForm_ReplaceBuyer.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.Nothing
            Me.SearchableComboBoxForm_ReplaceBuyer.Location = New System.Drawing.Point(99, 38)
            Me.SearchableComboBoxForm_ReplaceBuyer.Name = "SearchableComboBoxForm_ReplaceBuyer"
            Me.SearchableComboBoxForm_ReplaceBuyer.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxForm_ReplaceBuyer.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxForm_ReplaceBuyer.Properties.NullText = "Select Buyer"
            Me.SearchableComboBoxForm_ReplaceBuyer.Properties.PopupView = Me.GridView1
            Me.SearchableComboBoxForm_ReplaceBuyer.Properties.ShowClearButton = False
            Me.SearchableComboBoxForm_ReplaceBuyer.Properties.ValueMember = "Code"
            Me.SearchableComboBoxForm_ReplaceBuyer.SecurityEnabled = True
            Me.SearchableComboBoxForm_ReplaceBuyer.SelectedValue = "Select Buyer"
            Me.SearchableComboBoxForm_ReplaceBuyer.Size = New System.Drawing.Size(348, 20)
            Me.SearchableComboBoxForm_ReplaceBuyer.TabIndex = 3
            '
            'GridView1
            '
            Me.GridView1.AFActiveFilterString = ""
            Me.GridView1.EnableDisabledRows = False
            Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView1.ModifyColumnSettingsOnEachDataSource = True
            Me.GridView1.ModifyGridRowHeight = False
            Me.GridView1.Name = "GridView1"
            Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView1.OptionsView.ShowGroupPanel = False
            Me.GridView1.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView1.SkipAddingControlsOnModifyColumn = False
            Me.GridView1.SkipSettingFontOnModifyColumn = False
            '
            'MediaBroadcastWorksheetMarketReplaceBuyerDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(459, 104)
            Me.Controls.Add(Me.SearchableComboBoxForm_ReplaceBuyer)
            Me.Controls.Add(Me.SearchableComboBoxForm_FindBuyer)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.LabelForm_Find)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaBroadcastWorksheetMarketReplaceBuyerDialog"
            Me.Text = "Media Broadcast Worksheet Market Find and Replace Buyer"
            CType(Me.SearchableComboBoxForm_FindBuyer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewForm_Buyer, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxForm_ReplaceBuyer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents LabelForm_Find As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents Label1 As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxForm_FindBuyer As WinForm.MVC.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewForm_Buyer As WinForm.MVC.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxForm_ReplaceBuyer As WinForm.MVC.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView1 As WinForm.MVC.Presentation.Controls.GridView
    End Class

End Namespace
