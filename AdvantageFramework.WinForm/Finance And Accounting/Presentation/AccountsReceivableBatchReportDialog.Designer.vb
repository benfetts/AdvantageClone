Namespace FinanceAndAccounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AccountsReceivableBatchReportDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
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
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AccountsReceivableBatchReportDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_User = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_User = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_Batch = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_Batch = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Enabled = True
            Me.ButtonForm_OK.Location = New System.Drawing.Point(130, 68)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 8
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Enabled = True
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(211, 68)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 9
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'LabelForm_User
            '
            Me.LabelForm_User.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_User.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_User.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_User.Name = "LabelForm_User"
            Me.LabelForm_User.Size = New System.Drawing.Size(45, 20)
            Me.LabelForm_User.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_User.TabIndex = 2
            Me.LabelForm_User.Text = "User:"
            '
            'ComboBoxForm_User
            '
            Me.ComboBoxForm_User.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_User.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_User.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_User.AutoFindItemInDataSource = False
            Me.ComboBoxForm_User.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_User.BookmarkingEnabled = False
            Me.ComboBoxForm_User.ClientCode = ""
            Me.ComboBoxForm_User.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.User
            Me.ComboBoxForm_User.DisableMouseWheel = True
            Me.ComboBoxForm_User.DisplayMember = "Name"
            Me.ComboBoxForm_User.DisplayName = ""
            Me.ComboBoxForm_User.DivisionCode = ""
            Me.ComboBoxForm_User.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_User.Enabled = True
            Me.ComboBoxForm_User.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_User.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_User.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.ComboBoxForm_User.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_User.FocusHighlightEnabled = True
            Me.ComboBoxForm_User.FormattingEnabled = True
            Me.ComboBoxForm_User.ItemHeight = 14
            Me.ComboBoxForm_User.Location = New System.Drawing.Point(63, 12)
            Me.ComboBoxForm_User.Name = "ComboBoxForm_User"
            Me.ComboBoxForm_User.PreventEnterBeep = False
            Me.ComboBoxForm_User.ReadOnly = False
            Me.ComboBoxForm_User.SecurityEnabled = True
            Me.ComboBoxForm_User.Size = New System.Drawing.Size(223, 20)
            Me.ComboBoxForm_User.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_User.TabIndex = 3
            Me.ComboBoxForm_User.ValueMember = "Name"
            Me.ComboBoxForm_User.Visible = True
            Me.ComboBoxForm_User.WatermarkText = "Select User"
            '
            'LabelForm_Batch
            '
            Me.LabelForm_Batch.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Batch.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Batch.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_Batch.Name = "LabelForm_Batch"
            Me.LabelForm_Batch.Size = New System.Drawing.Size(45, 20)
            Me.LabelForm_Batch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Batch.TabIndex = 5
            Me.LabelForm_Batch.Text = "Batch:"
            '
            'ComboBoxForm_Batch
            '
            Me.ComboBoxForm_Batch.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Batch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Batch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Batch.AutoFindItemInDataSource = False
            Me.ComboBoxForm_Batch.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Batch.BookmarkingEnabled = False
            Me.ComboBoxForm_Batch.ClientCode = ""
            Me.ComboBoxForm_Batch.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.[Default]
            Me.ComboBoxForm_Batch.DisableMouseWheel = True
            Me.ComboBoxForm_Batch.DisplayMember = "BatchDate"
            Me.ComboBoxForm_Batch.DisplayName = "Batch"
            Me.ComboBoxForm_Batch.DivisionCode = ""
            Me.ComboBoxForm_Batch.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Batch.Enabled = True
            Me.ComboBoxForm_Batch.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_Batch.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_Batch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.ComboBoxForm_Batch.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Batch.FocusHighlightEnabled = True
            Me.ComboBoxForm_Batch.FormattingEnabled = True
            Me.ComboBoxForm_Batch.ItemHeight = 14
            Me.ComboBoxForm_Batch.Location = New System.Drawing.Point(63, 38)
            Me.ComboBoxForm_Batch.Name = "ComboBoxForm_Batch"
            Me.ComboBoxForm_Batch.PreventEnterBeep = False
            Me.ComboBoxForm_Batch.ReadOnly = False
            Me.ComboBoxForm_Batch.SecurityEnabled = True
            Me.ComboBoxForm_Batch.Size = New System.Drawing.Size(223, 20)
            Me.ComboBoxForm_Batch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Batch.TabIndex = 6
            Me.ComboBoxForm_Batch.ValueMember = "BatchDate"
            Me.ComboBoxForm_Batch.Visible = True
            '
            'AccountsReceivableBatchReportDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(298, 100)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.ComboBoxForm_User)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.LabelForm_User)
            Me.Controls.Add(Me.LabelForm_Batch)
            Me.Controls.Add(Me.ComboBoxForm_Batch)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "AccountsReceivableBatchReportDialog"
            Me.Text = "AR Batch Report Criteria"
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Private WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Private WithEvents LabelForm_User As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents ComboBoxForm_User As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Private WithEvents LabelForm_Batch As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents ComboBoxForm_Batch As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
    End Class

End Namespace