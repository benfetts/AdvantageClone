Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class MediaPlanDetailUserDefinedColumnEditDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm

        'Form overrides dispose to clean up the component list.
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaPlanDetailUserDefinedColumnEditDialog))
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Add = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ComboBoxForm_SalesClass = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxForm_MediaType = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_SalesClass = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_MediaType = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Color = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxPrintAndOutOfHome_BillingNotes = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.TextBoxPrintAndOutOfHomeBillingNotes_BillingNotes = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.ColorPickerForm_Color = New DevComponents.DotNetBar.ColorPickerButton()
            Me.ButtonForm_Update = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxPrintAndOutOfHome_BillingNotes, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxPrintAndOutOfHome_BillingNotes.SuspendLayout()
            Me.SuspendLayout()
            '
            'DefaultLookAndFeelOffice2010Blue
            '
            Me.DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(330, 272)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 7
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ButtonForm_Add
            '
            Me.ButtonForm_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Add.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Add.Location = New System.Drawing.Point(249, 272)
            Me.ButtonForm_Add.Name = "ButtonForm_Add"
            Me.ButtonForm_Add.SecurityEnabled = True
            Me.ButtonForm_Add.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Add.TabIndex = 5
            Me.ButtonForm_Add.Text = "Add"
            '
            'ComboBoxForm_SalesClass
            '
            Me.ComboBoxForm_SalesClass.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_SalesClass.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_SalesClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_SalesClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_SalesClass.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_SalesClass.BookmarkingEnabled = False
            Me.ComboBoxForm_SalesClass.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.SalesClass
            Me.ComboBoxForm_SalesClass.DisableMouseWheel = False
            Me.ComboBoxForm_SalesClass.DisplayMember = "Description"
            Me.ComboBoxForm_SalesClass.DisplayName = ""
            Me.ComboBoxForm_SalesClass.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_SalesClass.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_SalesClass.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_SalesClass.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_SalesClass.FocusHighlightEnabled = True
            Me.ComboBoxForm_SalesClass.FormattingEnabled = True
            Me.ComboBoxForm_SalesClass.ItemHeight = 14
            Me.ComboBoxForm_SalesClass.Location = New System.Drawing.Point(85, 38)
            Me.ComboBoxForm_SalesClass.Name = "ComboBoxForm_SalesClass"
            Me.ComboBoxForm_SalesClass.PreventEnterBeep = False
            Me.ComboBoxForm_SalesClass.ReadOnly = False
            Me.ComboBoxForm_SalesClass.Size = New System.Drawing.Size(320, 20)
            Me.ComboBoxForm_SalesClass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_SalesClass.TabIndex = 3
            Me.ComboBoxForm_SalesClass.ValueMember = "Code"
            Me.ComboBoxForm_SalesClass.WatermarkText = "Select Job"
            '
            'ComboBoxForm_MediaType
            '
            Me.ComboBoxForm_MediaType.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_MediaType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_MediaType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_MediaType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_MediaType.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_MediaType.BookmarkingEnabled = False
            Me.ComboBoxForm_MediaType.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.[Default]
            Me.ComboBoxForm_MediaType.DisableMouseWheel = False
            Me.ComboBoxForm_MediaType.DisplayMember = "Description"
            Me.ComboBoxForm_MediaType.DisplayName = ""
            Me.ComboBoxForm_MediaType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_MediaType.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_MediaType.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_MediaType.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_MediaType.FocusHighlightEnabled = True
            Me.ComboBoxForm_MediaType.FormattingEnabled = True
            Me.ComboBoxForm_MediaType.ItemHeight = 14
            Me.ComboBoxForm_MediaType.Location = New System.Drawing.Point(85, 12)
            Me.ComboBoxForm_MediaType.Name = "ComboBoxForm_MediaType"
            Me.ComboBoxForm_MediaType.PreventEnterBeep = False
            Me.ComboBoxForm_MediaType.ReadOnly = False
            Me.ComboBoxForm_MediaType.Size = New System.Drawing.Size(320, 20)
            Me.ComboBoxForm_MediaType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_MediaType.TabIndex = 1
            Me.ComboBoxForm_MediaType.ValueMember = "Code"
            Me.ComboBoxForm_MediaType.WatermarkText = "Select"
            '
            'LabelForm_SalesClass
            '
            Me.LabelForm_SalesClass.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_SalesClass.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_SalesClass.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_SalesClass.Name = "LabelForm_SalesClass"
            Me.LabelForm_SalesClass.Size = New System.Drawing.Size(67, 20)
            Me.LabelForm_SalesClass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_SalesClass.TabIndex = 2
            Me.LabelForm_SalesClass.Text = "Sales Class:"
            '
            'LabelForm_MediaType
            '
            Me.LabelForm_MediaType.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_MediaType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_MediaType.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_MediaType.Name = "LabelForm_MediaType"
            Me.LabelForm_MediaType.Size = New System.Drawing.Size(67, 20)
            Me.LabelForm_MediaType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_MediaType.TabIndex = 0
            Me.LabelForm_MediaType.Text = "Media Type:"
            '
            'LabelForm_Color
            '
            Me.LabelForm_Color.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Color.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Color.Location = New System.Drawing.Point(12, 64)
            Me.LabelForm_Color.Name = "LabelForm_Color"
            Me.LabelForm_Color.Size = New System.Drawing.Size(67, 20)
            Me.LabelForm_Color.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Color.TabIndex = 7
            Me.LabelForm_Color.Text = "Color:"
            '
            'GroupBoxPrintAndOutOfHome_BillingNotes
            '
            Me.GroupBoxPrintAndOutOfHome_BillingNotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxPrintAndOutOfHome_BillingNotes.Controls.Add(Me.TextBoxPrintAndOutOfHomeBillingNotes_BillingNotes)
            Me.GroupBoxPrintAndOutOfHome_BillingNotes.Location = New System.Drawing.Point(12, 90)
            Me.GroupBoxPrintAndOutOfHome_BillingNotes.Name = "GroupBoxPrintAndOutOfHome_BillingNotes"
            Me.GroupBoxPrintAndOutOfHome_BillingNotes.Size = New System.Drawing.Size(393, 176)
            Me.GroupBoxPrintAndOutOfHome_BillingNotes.TabIndex = 9
            Me.GroupBoxPrintAndOutOfHome_BillingNotes.Text = "Billing Notes"
            '
            'TextBoxPrintAndOutOfHomeBillingNotes_BillingNotes
            '
            Me.TextBoxPrintAndOutOfHomeBillingNotes_BillingNotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxPrintAndOutOfHomeBillingNotes_BillingNotes.Border.Class = "TextBoxBorder"
            Me.TextBoxPrintAndOutOfHomeBillingNotes_BillingNotes.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPrintAndOutOfHomeBillingNotes_BillingNotes.CheckSpellingOnValidate = False
            Me.TextBoxPrintAndOutOfHomeBillingNotes_BillingNotes.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPrintAndOutOfHomeBillingNotes_BillingNotes.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxPrintAndOutOfHomeBillingNotes_BillingNotes.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPrintAndOutOfHomeBillingNotes_BillingNotes.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPrintAndOutOfHomeBillingNotes_BillingNotes.FocusHighlightEnabled = True
            Me.TextBoxPrintAndOutOfHomeBillingNotes_BillingNotes.Location = New System.Drawing.Point(5, 24)
            Me.TextBoxPrintAndOutOfHomeBillingNotes_BillingNotes.Multiline = True
            Me.TextBoxPrintAndOutOfHomeBillingNotes_BillingNotes.Name = "TextBoxPrintAndOutOfHomeBillingNotes_BillingNotes"
            Me.TextBoxPrintAndOutOfHomeBillingNotes_BillingNotes.Size = New System.Drawing.Size(383, 147)
            Me.TextBoxPrintAndOutOfHomeBillingNotes_BillingNotes.TabIndex = 0
            Me.TextBoxPrintAndOutOfHomeBillingNotes_BillingNotes.TabOnEnter = True
            '
            'ColorPickerForm_Color
            '
            Me.ColorPickerForm_Color.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ColorPickerForm_Color.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ColorPickerForm_Color.Image = CType(resources.GetObject("ColorPickerForm_Color.Image"), System.Drawing.Image)
            Me.ColorPickerForm_Color.Location = New System.Drawing.Point(85, 64)
            Me.ColorPickerForm_Color.Name = "ColorPickerForm_Color"
            Me.ColorPickerForm_Color.SelectedColorImageRectangle = New System.Drawing.Rectangle(2, 2, 12, 12)
            Me.ColorPickerForm_Color.Size = New System.Drawing.Size(37, 20)
            Me.ColorPickerForm_Color.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ColorPickerForm_Color.TabIndex = 8
            '
            'ButtonForm_Update
            '
            Me.ButtonForm_Update.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Update.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Update.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Update.Location = New System.Drawing.Point(249, 272)
            Me.ButtonForm_Update.Name = "ButtonForm_Update"
            Me.ButtonForm_Update.SecurityEnabled = True
            Me.ButtonForm_Update.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Update.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Update.TabIndex = 6
            Me.ButtonForm_Update.Text = "Update"
            '
            'MediaPlanDetailEditDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(417, 304)
            Me.Controls.Add(Me.LabelForm_Color)
            Me.Controls.Add(Me.ColorPickerForm_Color)
            Me.Controls.Add(Me.GroupBoxPrintAndOutOfHome_BillingNotes)
            Me.Controls.Add(Me.ComboBoxForm_SalesClass)
            Me.Controls.Add(Me.ComboBoxForm_MediaType)
            Me.Controls.Add(Me.LabelForm_SalesClass)
            Me.Controls.Add(Me.LabelForm_MediaType)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.ButtonForm_Add)
            Me.Controls.Add(Me.ButtonForm_Update)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaPlanDetailEditDialog"
            Me.Text = "User Defined Column"
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxPrintAndOutOfHome_BillingNotes, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxPrintAndOutOfHome_BillingNotes.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Add As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ComboBoxForm_SalesClass As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxForm_MediaType As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_SalesClass As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_MediaType As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Color As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxPrintAndOutOfHome_BillingNotes As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents TextBoxPrintAndOutOfHomeBillingNotes_BillingNotes As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents ColorPickerForm_Color As DevComponents.DotNetBar.ColorPickerButton
        Friend WithEvents ButtonForm_Update As AdvantageFramework.WinForm.Presentation.Controls.Button
    End Class

End Namespace