Namespace Maintenance.Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class CanadaUniverseEditDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CanadaUniverseEditDialog))
            Me.ButtonForm_Add = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Update = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_Year = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelForm_Market = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.ComboBoxForm_Market = New AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox()
            Me.NumericInputForm_Year = New AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput()
            Me.CheckBoxForm_AddAllMarkets = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            CType(Me.NumericInputForm_Year.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ButtonForm_Add
            '
            Me.ButtonForm_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Add.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Add.Location = New System.Drawing.Point(140, 90)
            Me.ButtonForm_Add.Name = "ButtonForm_Add"
            Me.ButtonForm_Add.SecurityEnabled = True
            Me.ButtonForm_Add.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Add.TabIndex = 5
            Me.ButtonForm_Add.Text = "Add"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(221, 90)
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
            Me.ButtonForm_Update.Location = New System.Drawing.Point(140, 90)
            Me.ButtonForm_Update.Name = "ButtonForm_Update"
            Me.ButtonForm_Update.SecurityEnabled = True
            Me.ButtonForm_Update.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Update.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Update.TabIndex = 6
            Me.ButtonForm_Update.Text = "Update"
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
            Me.LabelForm_Year.Size = New System.Drawing.Size(55, 20)
            Me.LabelForm_Year.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Year.TabIndex = 0
            Me.LabelForm_Year.Text = "Year:"
            '
            'LabelForm_Market
            '
            Me.LabelForm_Market.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Market.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Market.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_Market.Name = "LabelForm_Market"
            Me.LabelForm_Market.Size = New System.Drawing.Size(55, 20)
            Me.LabelForm_Market.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Market.TabIndex = 2
            Me.LabelForm_Market.Text = "Market:"
            '
            'ComboBoxForm_Market
            '
            Me.ComboBoxForm_Market.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Market.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_Market.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Market.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Market.AutoFindItemInDataSource = False
            Me.ComboBoxForm_Market.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Market.BookmarkingEnabled = False
            Me.ComboBoxForm_Market.DisableMouseWheel = False
            Me.ComboBoxForm_Market.DisplayMember = "Text"
            Me.ComboBoxForm_Market.DisplayName = ""
            Me.ComboBoxForm_Market.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Market.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_Market.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_Market.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Market.FocusHighlightEnabled = True
            Me.ComboBoxForm_Market.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxForm_Market.FormattingEnabled = True
            Me.ComboBoxForm_Market.ItemHeight = 14
            Me.ComboBoxForm_Market.Location = New System.Drawing.Point(73, 38)
            Me.ComboBoxForm_Market.Name = "ComboBoxForm_Market"
            Me.ComboBoxForm_Market.ReadOnly = False
            Me.ComboBoxForm_Market.SecurityEnabled = True
            Me.ComboBoxForm_Market.Size = New System.Drawing.Size(223, 20)
            Me.ComboBoxForm_Market.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Market.TabIndex = 3
            Me.ComboBoxForm_Market.TabOnEnter = True
            '
            'NumericInputForm_Year
            '
            Me.NumericInputForm_Year.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputForm_Year.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.NumericInputForm_Year.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput.Type.[Default]
            Me.NumericInputForm_Year.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputForm_Year.EnterMoveNextControl = True
            Me.NumericInputForm_Year.Location = New System.Drawing.Point(73, 12)
            Me.NumericInputForm_Year.Name = "NumericInputForm_Year"
            Me.NumericInputForm_Year.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
            Me.NumericInputForm_Year.Properties.Appearance.Options.UseTextOptions = True
            Me.NumericInputForm_Year.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
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
            Me.NumericInputForm_Year.Size = New System.Drawing.Size(78, 20)
            Me.NumericInputForm_Year.TabIndex = 1
            '
            'CheckBoxForm_AddAllMarkets
            '
            '
            '
            '
            Me.CheckBoxForm_AddAllMarkets.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_AddAllMarkets.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_AddAllMarkets.ChildControls = CType(resources.GetObject("CheckBoxForm_AddAllMarkets.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_AddAllMarkets.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_AddAllMarkets.Location = New System.Drawing.Point(73, 64)
            Me.CheckBoxForm_AddAllMarkets.Name = "CheckBoxForm_AddAllMarkets"
            Me.CheckBoxForm_AddAllMarkets.OldestSibling = Nothing
            Me.CheckBoxForm_AddAllMarkets.SecurityEnabled = True
            Me.CheckBoxForm_AddAllMarkets.SiblingControls = CType(resources.GetObject("CheckBoxForm_AddAllMarkets.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_AddAllMarkets.Size = New System.Drawing.Size(223, 20)
            Me.CheckBoxForm_AddAllMarkets.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_AddAllMarkets.TabIndex = 4
            Me.CheckBoxForm_AddAllMarkets.TabOnEnter = True
            Me.CheckBoxForm_AddAllMarkets.Text = "Add All Markets"
            '
            'CanadaUniverseEditDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(308, 122)
            Me.Controls.Add(Me.CheckBoxForm_AddAllMarkets)
            Me.Controls.Add(Me.NumericInputForm_Year)
            Me.Controls.Add(Me.LabelForm_Market)
            Me.Controls.Add(Me.ComboBoxForm_Market)
            Me.Controls.Add(Me.LabelForm_Year)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.ButtonForm_Add)
            Me.Controls.Add(Me.ButtonForm_Update)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "CanadaUniverseEditDialog"
            Me.Text = "Canada Universe"
            CType(Me.NumericInputForm_Year.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Add As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Update As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_Year As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelForm_Market As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_Market As WinForm.MVC.Presentation.Controls.ComboBox
        Friend WithEvents NumericInputForm_Year As WinForm.MVC.Presentation.Controls.NumericInput
        Friend WithEvents CheckBoxForm_AddAllMarkets As WinForm.MVC.Presentation.Controls.CheckBox
    End Class

End Namespace