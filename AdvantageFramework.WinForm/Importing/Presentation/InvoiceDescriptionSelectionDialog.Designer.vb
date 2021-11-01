Namespace Importing.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class InvoiceDescriptionSelectionDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InvoiceDescriptionSelectionDialog))
            Me.LabelForm_DefaultInvoiceDescription = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ComboBoxForm_DefaultInvoiceDescription = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.SuspendLayout()
            '
            'LabelForm_DefaultInvoiceDescription
            '
            Me.LabelForm_DefaultInvoiceDescription.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_DefaultInvoiceDescription.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_DefaultInvoiceDescription.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_DefaultInvoiceDescription.Name = "LabelForm_DefaultInvoiceDescription"
            Me.LabelForm_DefaultInvoiceDescription.Size = New System.Drawing.Size(146, 20)
            Me.LabelForm_DefaultInvoiceDescription.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_DefaultInvoiceDescription.TabIndex = 2
            Me.LabelForm_DefaultInvoiceDescription.Text = "Default Invoice Description:"
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(311, 45)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 5
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(392, 45)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 6
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ComboBoxForm_DefaultInvoiceDescription
            '
            Me.ComboBoxForm_DefaultInvoiceDescription.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_DefaultInvoiceDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_DefaultInvoiceDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_DefaultInvoiceDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_DefaultInvoiceDescription.AutoFindItemInDataSource = False
            Me.ComboBoxForm_DefaultInvoiceDescription.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_DefaultInvoiceDescription.BookmarkingEnabled = False
            Me.ComboBoxForm_DefaultInvoiceDescription.ClientCode = ""
            Me.ComboBoxForm_DefaultInvoiceDescription.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumObjects
            Me.ComboBoxForm_DefaultInvoiceDescription.DisableMouseWheel = False
            Me.ComboBoxForm_DefaultInvoiceDescription.DisplayMember = "Description"
            Me.ComboBoxForm_DefaultInvoiceDescription.DisplayName = ""
            Me.ComboBoxForm_DefaultInvoiceDescription.DivisionCode = ""
            Me.ComboBoxForm_DefaultInvoiceDescription.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_DefaultInvoiceDescription.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_DefaultInvoiceDescription.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_DefaultInvoiceDescription.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_DefaultInvoiceDescription.FocusHighlightEnabled = True
            Me.ComboBoxForm_DefaultInvoiceDescription.FormattingEnabled = True
            Me.ComboBoxForm_DefaultInvoiceDescription.ItemHeight = 14
            Me.ComboBoxForm_DefaultInvoiceDescription.Location = New System.Drawing.Point(164, 12)
            Me.ComboBoxForm_DefaultInvoiceDescription.Name = "ComboBoxForm_DefaultInvoiceDescription"
            Me.ComboBoxForm_DefaultInvoiceDescription.PreventEnterBeep = False
            Me.ComboBoxForm_DefaultInvoiceDescription.ReadOnly = False
            Me.ComboBoxForm_DefaultInvoiceDescription.SecurityEnabled = True
            Me.ComboBoxForm_DefaultInvoiceDescription.Size = New System.Drawing.Size(303, 20)
            Me.ComboBoxForm_DefaultInvoiceDescription.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_DefaultInvoiceDescription.TabIndex = 7
            Me.ComboBoxForm_DefaultInvoiceDescription.ValueMember = "Code"
            Me.ComboBoxForm_DefaultInvoiceDescription.WatermarkText = "Select"
            '
            'InvoiceDescriptionSelectionDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(479, 77)
            Me.Controls.Add(Me.ComboBoxForm_DefaultInvoiceDescription)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.LabelForm_DefaultInvoiceDescription)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "InvoiceDescriptionSelectionDialog"
            Me.Text = "Select Default Invoice Description"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents LabelForm_DefaultInvoiceDescription As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ComboBoxForm_DefaultInvoiceDescription As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
    End Class

End Namespace