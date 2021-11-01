Namespace Maintenance.Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class NationalUniverseEditDialog
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
            Dim EditorButtonImageOptions1 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
            Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
            Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
            Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
            Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NationalUniverseEditDialog))
            Me.ButtonForm_Add = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Update = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.NumericInputForm_Year = New AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput()
            Me.LabelForm_MarketBreak = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelForm_Year = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.CheckBoxForm_IsHispanic = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.LabelForm_IsHispanic = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.SearchableComboBoxForm_MarketBreak = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxSpotTVViewControl_Market = New AdvantageFramework.WinForm.MVC.Presentation.Controls.GridView()
            CType(Me.NumericInputForm_Year.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxForm_MarketBreak.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxSpotTVViewControl_Market, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ButtonForm_Add
            '
            Me.ButtonForm_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Add.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Add.Location = New System.Drawing.Point(159, 92)
            Me.ButtonForm_Add.Name = "ButtonForm_Add"
            Me.ButtonForm_Add.SecurityEnabled = True
            Me.ButtonForm_Add.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Add.TabIndex = 6
            Me.ButtonForm_Add.Text = "Add"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(240, 92)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 7
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ButtonForm_Update
            '
            Me.ButtonForm_Update.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Update.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Update.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Update.Location = New System.Drawing.Point(159, 92)
            Me.ButtonForm_Update.Name = "ButtonForm_Update"
            Me.ButtonForm_Update.SecurityEnabled = True
            Me.ButtonForm_Update.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Update.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Update.TabIndex = 2
            Me.ButtonForm_Update.Text = "Update"
            '
            'NumericInputForm_Year
            '
            Me.NumericInputForm_Year.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputForm_Year.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput.Type.[Default]
            Me.NumericInputForm_Year.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputForm_Year.EnterMoveNextControl = True
            Me.NumericInputForm_Year.Location = New System.Drawing.Point(95, 12)
            Me.NumericInputForm_Year.Name = "NumericInputForm_Year"
            Me.NumericInputForm_Year.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
            Me.NumericInputForm_Year.Properties.Appearance.Options.UseTextOptions = True
            Me.NumericInputForm_Year.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Me.NumericInputForm_Year.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, True, False, False, EditorButtonImageOptions1, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, SerializableAppearanceObject2, SerializableAppearanceObject3, SerializableAppearanceObject4, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
            Me.NumericInputForm_Year.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputForm_Year.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_Year.Properties.EditFormat.FormatString = "f"
            Me.NumericInputForm_Year.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_Year.Properties.LookAndFeel.SkinName = "Office 2016 Colorful"
            Me.NumericInputForm_Year.Properties.LookAndFeel.UseDefaultLookAndFeel = False
            Me.NumericInputForm_Year.Properties.Mask.EditMask = "f"
            Me.NumericInputForm_Year.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputForm_Year.SecurityEnabled = True
            Me.NumericInputForm_Year.Size = New System.Drawing.Size(220, 20)
            Me.NumericInputForm_Year.TabIndex = 1
            '
            'LabelForm_MarketBreak
            '
            Me.LabelForm_MarketBreak.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_MarketBreak.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_MarketBreak.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_MarketBreak.Name = "LabelForm_MarketBreak"
            Me.LabelForm_MarketBreak.Size = New System.Drawing.Size(77, 20)
            Me.LabelForm_MarketBreak.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_MarketBreak.TabIndex = 2
            Me.LabelForm_MarketBreak.Text = "Market Break:"
            '
            'LabelForm_Year
            '
            Me.LabelForm_Year.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Year.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Year.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_Year.Name = "LabelForm_Year"
            Me.LabelForm_Year.Size = New System.Drawing.Size(77, 20)
            Me.LabelForm_Year.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Year.TabIndex = 0
            Me.LabelForm_Year.Text = "Year:"
            '
            'CheckBoxForm_IsHispanic
            '
            '
            '
            '
            Me.CheckBoxForm_IsHispanic.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_IsHispanic.CheckValue = 0
            Me.CheckBoxForm_IsHispanic.CheckValueChecked = 1
            Me.CheckBoxForm_IsHispanic.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_IsHispanic.CheckValueUnchecked = 0
            Me.CheckBoxForm_IsHispanic.ChildControls = CType(resources.GetObject("CheckBoxForm_IsHispanic.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_IsHispanic.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_IsHispanic.Location = New System.Drawing.Point(95, 64)
            Me.CheckBoxForm_IsHispanic.Name = "CheckBoxForm_IsHispanic"
            Me.CheckBoxForm_IsHispanic.OldestSibling = Nothing
            Me.CheckBoxForm_IsHispanic.SecurityEnabled = True
            Me.CheckBoxForm_IsHispanic.SiblingControls = CType(resources.GetObject("CheckBoxForm_IsHispanic.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_IsHispanic.Size = New System.Drawing.Size(220, 20)
            Me.CheckBoxForm_IsHispanic.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_IsHispanic.TabIndex = 5
            Me.CheckBoxForm_IsHispanic.TabOnEnter = True
            '
            'LabelForm_IsHispanic
            '
            Me.LabelForm_IsHispanic.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_IsHispanic.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_IsHispanic.Location = New System.Drawing.Point(12, 64)
            Me.LabelForm_IsHispanic.Name = "LabelForm_IsHispanic"
            Me.LabelForm_IsHispanic.Size = New System.Drawing.Size(77, 20)
            Me.LabelForm_IsHispanic.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_IsHispanic.TabIndex = 4
            Me.LabelForm_IsHispanic.Text = "Is Hispanic:"
            '
            'SearchableComboBoxForm_MarketBreak
            '
            Me.SearchableComboBoxForm_MarketBreak.ActiveFilterString = ""
            Me.SearchableComboBoxForm_MarketBreak.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxForm_MarketBreak.AutoFillMode = False
            Me.SearchableComboBoxForm_MarketBreak.BookmarkingEnabled = False
            Me.SearchableComboBoxForm_MarketBreak.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.Type.MarketBreak
            Me.SearchableComboBoxForm_MarketBreak.DataSource = Nothing
            Me.SearchableComboBoxForm_MarketBreak.DisableMouseWheel = True
            Me.SearchableComboBoxForm_MarketBreak.DisplayName = ""
            Me.SearchableComboBoxForm_MarketBreak.EditValue = ""
            Me.SearchableComboBoxForm_MarketBreak.EnterMoveNextControl = True
            Me.SearchableComboBoxForm_MarketBreak.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxForm_MarketBreak.Location = New System.Drawing.Point(95, 38)
            Me.SearchableComboBoxForm_MarketBreak.Name = "SearchableComboBoxForm_MarketBreak"
            Me.SearchableComboBoxForm_MarketBreak.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxForm_MarketBreak.Properties.DisplayMember = "Category"
            Me.SearchableComboBoxForm_MarketBreak.Properties.NullText = "Select Market Break"
            Me.SearchableComboBoxForm_MarketBreak.Properties.PopupView = Me.SearchableComboBoxSpotTVViewControl_Market
            Me.SearchableComboBoxForm_MarketBreak.Properties.ShowClearButton = False
            Me.SearchableComboBoxForm_MarketBreak.Properties.ValueMember = "ID"
            Me.SearchableComboBoxForm_MarketBreak.SecurityEnabled = True
            Me.SearchableComboBoxForm_MarketBreak.SelectedValue = ""
            Me.SearchableComboBoxForm_MarketBreak.Size = New System.Drawing.Size(220, 20)
            Me.SearchableComboBoxForm_MarketBreak.TabIndex = 3
            '
            'SearchableComboBoxSpotTVViewControl_Market
            '
            Me.SearchableComboBoxSpotTVViewControl_Market.AFActiveFilterString = ""
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.EnableDisabledRows = False
            Me.SearchableComboBoxSpotTVViewControl_Market.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxSpotTVViewControl_Market.ModifyColumnSettingsOnEachDataSource = True
            Me.SearchableComboBoxSpotTVViewControl_Market.ModifyGridRowHeight = False
            Me.SearchableComboBoxSpotTVViewControl_Market.Name = "SearchableComboBoxSpotTVViewControl_Market"
            Me.SearchableComboBoxSpotTVViewControl_Market.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxSpotTVViewControl_Market.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxSpotTVViewControl_Market.OptionsBehavior.Editable = False
            Me.SearchableComboBoxSpotTVViewControl_Market.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxSpotTVViewControl_Market.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxSpotTVViewControl_Market.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxSpotTVViewControl_Market.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxSpotTVViewControl_Market.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxSpotTVViewControl_Market.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxSpotTVViewControl_Market.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxSpotTVViewControl_Market.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxSpotTVViewControl_Market.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboBoxSpotTVViewControl_Market.SkipSettingFontOnModifyColumn = False
            '
            'NationalUniverseEditDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(327, 122)
            Me.Controls.Add(Me.SearchableComboBoxForm_MarketBreak)
            Me.Controls.Add(Me.LabelForm_IsHispanic)
            Me.Controls.Add(Me.CheckBoxForm_IsHispanic)
            Me.Controls.Add(Me.NumericInputForm_Year)
            Me.Controls.Add(Me.LabelForm_MarketBreak)
            Me.Controls.Add(Me.LabelForm_Year)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.ButtonForm_Add)
            Me.Controls.Add(Me.ButtonForm_Update)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "NationalUniverseEditDialog"
            Me.Text = "National Universe"
            CType(Me.NumericInputForm_Year.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxForm_MarketBreak.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxSpotTVViewControl_Market, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Add As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Update As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents NumericInputForm_Year As WinForm.MVC.Presentation.Controls.NumericInput
        Friend WithEvents LabelForm_MarketBreak As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelForm_Year As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents CheckBoxForm_IsHispanic As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents LabelForm_IsHispanic As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxForm_MarketBreak As WinForm.MVC.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxSpotTVViewControl_Market As WinForm.MVC.Presentation.Controls.GridView
    End Class

End Namespace