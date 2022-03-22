Namespace Reporting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class BroadcastInvoiceReportInitialLoadingDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BroadcastInvoiceReportInitialLoadingDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.BroadcastInvoiceControl = New AdvantageFramework.WinForm.Presentation.Controls.BroadcastInvoiceControl()
            Me.LabelForm_Report = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_Report = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(541, 324)
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
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(622, 324)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 4
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'BroadcastInvoiceControl
            '
            Me.BroadcastInvoiceControl.Location = New System.Drawing.Point(17, 42)
            Me.BroadcastInvoiceControl.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.BroadcastInvoiceControl.Name = "BroadcastInvoiceControl"
            Me.BroadcastInvoiceControl.Size = New System.Drawing.Size(680, 272)
            Me.BroadcastInvoiceControl.TabIndex = 2
            '
            'LabelForm_Report
            '
            Me.LabelForm_Report.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Report.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Report.Location = New System.Drawing.Point(17, 12)
            Me.LabelForm_Report.Name = "LabelForm_Report"
            Me.LabelForm_Report.Size = New System.Drawing.Size(54, 20)
            Me.LabelForm_Report.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Report.TabIndex = 0
            Me.LabelForm_Report.Text = "Report:"
            '
            'ComboBoxForm_Report
            '
            Me.ComboBoxForm_Report.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Report.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_Report.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Report.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Report.AutoFindItemInDataSource = False
            Me.ComboBoxForm_Report.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Report.BookmarkingEnabled = False
            Me.ComboBoxForm_Report.ClientCode = ""
            Me.ComboBoxForm_Report.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumObjects
            Me.ComboBoxForm_Report.DisableMouseWheel = False
            Me.ComboBoxForm_Report.DisplayMember = "Description"
            Me.ComboBoxForm_Report.DisplayName = ""
            Me.ComboBoxForm_Report.DivisionCode = ""
            Me.ComboBoxForm_Report.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Report.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_Report.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_Report.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Report.FocusHighlightEnabled = True
            Me.ComboBoxForm_Report.FormattingEnabled = True
            Me.ComboBoxForm_Report.ItemHeight = 14
            Me.ComboBoxForm_Report.Location = New System.Drawing.Point(77, 12)
            Me.ComboBoxForm_Report.Name = "ComboBoxForm_Report"
            Me.ComboBoxForm_Report.ReadOnly = False
            Me.ComboBoxForm_Report.SecurityEnabled = True
            Me.ComboBoxForm_Report.Size = New System.Drawing.Size(620, 20)
            Me.ComboBoxForm_Report.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Report.TabIndex = 1
            Me.ComboBoxForm_Report.TabOnEnter = True
            Me.ComboBoxForm_Report.ValueMember = "Code"
            Me.ComboBoxForm_Report.WatermarkText = "Select"
            '
            'BroadcastInvoiceReportInitialLoadingDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(709, 356)
            Me.Controls.Add(Me.ComboBoxForm_Report)
            Me.Controls.Add(Me.LabelForm_Report)
            Me.Controls.Add(Me.BroadcastInvoiceControl)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "BroadcastInvoiceReportInitialLoadingDialog"
            Me.Text = "Broadcast Invoice Reports"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents BroadcastInvoiceControl As WinForm.Presentation.Controls.BroadcastInvoiceControl
        Friend WithEvents LabelForm_Report As WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_Report As WinForm.Presentation.Controls.ComboBox
    End Class

End Namespace
