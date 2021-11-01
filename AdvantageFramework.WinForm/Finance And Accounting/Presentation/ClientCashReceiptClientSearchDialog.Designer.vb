Namespace FinanceAndAccounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class ClientCashReceiptClientSearchDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClientCashReceiptClientSearchDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.SearchableComboBoxForm_Criteria = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewCriteria_Criteria = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.RadioButtonForm_InvoiceNumber = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            CType(Me.SearchableComboBoxForm_Criteria.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewCriteria_Criteria, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(193, 76)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 3
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(274, 76)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 4
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'SearchableComboBoxForm_Criteria
            '
            Me.SearchableComboBoxForm_Criteria.ActiveFilterString = ""
            Me.SearchableComboBoxForm_Criteria.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxForm_Criteria.AutoFillMode = False
            Me.SearchableComboBoxForm_Criteria.BookmarkingEnabled = False
            Me.SearchableComboBoxForm_Criteria.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.[Default]
            Me.SearchableComboBoxForm_Criteria.DataSource = Nothing
            Me.SearchableComboBoxForm_Criteria.DisableMouseWheel = True
            Me.SearchableComboBoxForm_Criteria.DisplayName = ""
            Me.SearchableComboBoxForm_Criteria.EditValue = "Select AR Invoice Number"
            Me.SearchableComboBoxForm_Criteria.EnterMoveNextControl = True
            Me.SearchableComboBoxForm_Criteria.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxForm_Criteria.Location = New System.Drawing.Point(12, 38)
            Me.SearchableComboBoxForm_Criteria.Name = "SearchableComboBoxForm_Criteria"
            Me.SearchableComboBoxForm_Criteria.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxForm_Criteria.Properties.NullText = ""
            Me.SearchableComboBoxForm_Criteria.Properties.ShowClearButton = False
            Me.SearchableComboBoxForm_Criteria.Properties.View = Me.SearchableComboBoxViewCriteria_Criteria
            Me.SearchableComboBoxForm_Criteria.SecurityEnabled = True
            Me.SearchableComboBoxForm_Criteria.SelectedValue = "Select AR Invoice Number"
            Me.SearchableComboBoxForm_Criteria.Size = New System.Drawing.Size(337, 20)
            Me.SearchableComboBoxForm_Criteria.TabIndex = 2
            '
            'SearchableComboBoxViewCriteria_Criteria
            '
            Me.SearchableComboBoxViewCriteria_Criteria.AFActiveFilterString = ""
            Me.SearchableComboBoxViewCriteria_Criteria.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewCriteria_Criteria.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewCriteria_Criteria.DataSourceClearing = False
            Me.SearchableComboBoxViewCriteria_Criteria.EnableDisabledRows = False
            Me.SearchableComboBoxViewCriteria_Criteria.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewCriteria_Criteria.Name = "SearchableComboBoxViewCriteria_Criteria"
            Me.SearchableComboBoxViewCriteria_Criteria.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewCriteria_Criteria.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewCriteria_Criteria.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewCriteria_Criteria.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewCriteria_Criteria.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewCriteria_Criteria.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewCriteria_Criteria.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewCriteria_Criteria.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewCriteria_Criteria.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewCriteria_Criteria.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewCriteria_Criteria.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewCriteria_Criteria.RunStandardValidation = True
            '
            'RadioButtonForm_InvoiceNumber
            '
            Me.RadioButtonForm_InvoiceNumber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonForm_InvoiceNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonForm_InvoiceNumber.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonForm_InvoiceNumber.Checked = True
            Me.RadioButtonForm_InvoiceNumber.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonForm_InvoiceNumber.CheckValue = "Y"
            Me.RadioButtonForm_InvoiceNumber.Location = New System.Drawing.Point(12, 12)
            Me.RadioButtonForm_InvoiceNumber.Name = "RadioButtonForm_InvoiceNumber"
            Me.RadioButtonForm_InvoiceNumber.SecurityEnabled = True
            Me.RadioButtonForm_InvoiceNumber.Size = New System.Drawing.Size(149, 20)
            Me.RadioButtonForm_InvoiceNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonForm_InvoiceNumber.TabIndex = 30
            Me.RadioButtonForm_InvoiceNumber.TabOnEnter = True
            Me.RadioButtonForm_InvoiceNumber.Text = "By AR Invoice Number"
            '
            'ClientCashReceiptClientSearchDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(361, 108)
            Me.Controls.Add(Me.RadioButtonForm_InvoiceNumber)
            Me.Controls.Add(Me.SearchableComboBoxForm_Criteria)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ClientCashReceiptClientSearchDialog"
            Me.Text = "Client Search"
            CType(Me.SearchableComboBoxForm_Criteria.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewCriteria_Criteria, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents SearchableComboBoxForm_Criteria As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewCriteria_Criteria As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents RadioButtonForm_InvoiceNumber As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
    End Class

End Namespace