Namespace FinanceAndAccounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class VoidInvoiceDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VoidInvoiceDialog))
            Me.TextBoxForm_Comment = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_Comment = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_PostingPeriod = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_PostingPeriod = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_InvoiceNumber = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Client = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_InvoicePostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_InvoicePostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxForm_Client = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxForm_InvoiceNumber = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.SuspendLayout()
            '
            'TextBoxForm_Comment
            '
            Me.TextBoxForm_Comment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxForm_Comment.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxForm_Comment.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Comment.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Comment.CheckSpellingOnValidate = False
            Me.TextBoxForm_Comment.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Comment.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_Comment.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Comment.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Comment.FocusHighlightEnabled = True
            Me.TextBoxForm_Comment.ForeColor = System.Drawing.Color.Black
            Me.TextBoxForm_Comment.Location = New System.Drawing.Point(100, 91)
            Me.TextBoxForm_Comment.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Comment.Multiline = True
            Me.TextBoxForm_Comment.Name = "TextBoxForm_Comment"
            Me.TextBoxForm_Comment.Size = New System.Drawing.Size(350, 111)
            Me.TextBoxForm_Comment.TabIndex = 9
            Me.TextBoxForm_Comment.TabOnEnter = True
            '
            'LabelForm_Comment
            '
            Me.LabelForm_Comment.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Comment.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Comment.Location = New System.Drawing.Point(12, 91)
            Me.LabelForm_Comment.Name = "LabelForm_Comment"
            Me.LabelForm_Comment.Size = New System.Drawing.Size(82, 20)
            Me.LabelForm_Comment.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Comment.TabIndex = 8
            Me.LabelForm_Comment.Text = "Comment:"
            '
            'ComboBoxForm_PostingPeriod
            '
            Me.ComboBoxForm_PostingPeriod.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_PostingPeriod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_PostingPeriod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_PostingPeriod.AutoFindItemInDataSource = False
            Me.ComboBoxForm_PostingPeriod.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_PostingPeriod.BookmarkingEnabled = False
            Me.ComboBoxForm_PostingPeriod.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.PostPeriod
            Me.ComboBoxForm_PostingPeriod.DisableMouseWheel = True
            Me.ComboBoxForm_PostingPeriod.DisplayMember = "Description"
            Me.ComboBoxForm_PostingPeriod.DisplayName = ""
            Me.ComboBoxForm_PostingPeriod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_PostingPeriod.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_PostingPeriod.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_PostingPeriod.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_PostingPeriod.FocusHighlightEnabled = True
            Me.ComboBoxForm_PostingPeriod.FormattingEnabled = True
            Me.ComboBoxForm_PostingPeriod.ItemHeight = 14
            Me.ComboBoxForm_PostingPeriod.Location = New System.Drawing.Point(100, 65)
            Me.ComboBoxForm_PostingPeriod.Name = "ComboBoxForm_PostingPeriod"
            Me.ComboBoxForm_PostingPeriod.PreventEnterBeep = False
            Me.ComboBoxForm_PostingPeriod.ReadOnly = False
            Me.ComboBoxForm_PostingPeriod.Size = New System.Drawing.Size(111, 20)
            Me.ComboBoxForm_PostingPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_PostingPeriod.TabIndex = 7
            Me.ComboBoxForm_PostingPeriod.ValueMember = "Code"
            Me.ComboBoxForm_PostingPeriod.WatermarkText = "Select Post Period"
            '
            'LabelForm_PostingPeriod
            '
            Me.LabelForm_PostingPeriod.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_PostingPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_PostingPeriod.Location = New System.Drawing.Point(12, 65)
            Me.LabelForm_PostingPeriod.Name = "LabelForm_PostingPeriod"
            Me.LabelForm_PostingPeriod.Size = New System.Drawing.Size(82, 20)
            Me.LabelForm_PostingPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_PostingPeriod.TabIndex = 6
            Me.LabelForm_PostingPeriod.Text = "Posting Period:"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(375, 208)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 11
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(294, 208)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 10
            Me.ButtonForm_OK.Text = "OK"
            '
            'LabelForm_InvoiceNumber
            '
            Me.LabelForm_InvoiceNumber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_InvoiceNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_InvoiceNumber.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_InvoiceNumber.Name = "LabelForm_InvoiceNumber"
            Me.LabelForm_InvoiceNumber.Size = New System.Drawing.Size(82, 20)
            Me.LabelForm_InvoiceNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_InvoiceNumber.TabIndex = 0
            Me.LabelForm_InvoiceNumber.Text = "Invoice Number:"
            '
            'LabelForm_Client
            '
            Me.LabelForm_Client.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Client.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Client.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_Client.Name = "LabelForm_Client"
            Me.LabelForm_Client.Size = New System.Drawing.Size(82, 20)
            Me.LabelForm_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Client.TabIndex = 4
            Me.LabelForm_Client.Text = "Client:"
            '
            'LabelForm_InvoicePostPeriod
            '
            Me.LabelForm_InvoicePostPeriod.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_InvoicePostPeriod.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_InvoicePostPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_InvoicePostPeriod.Location = New System.Drawing.Point(250, 12)
            Me.LabelForm_InvoicePostPeriod.Name = "LabelForm_InvoicePostPeriod"
            Me.LabelForm_InvoicePostPeriod.Size = New System.Drawing.Size(82, 20)
            Me.LabelForm_InvoicePostPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_InvoicePostPeriod.TabIndex = 2
            Me.LabelForm_InvoicePostPeriod.Text = "Posting Period:"
            '
            'TextBoxForm_InvoicePostPeriod
            '
            Me.TextBoxForm_InvoicePostPeriod.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxForm_InvoicePostPeriod.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_InvoicePostPeriod.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_InvoicePostPeriod.CheckSpellingOnValidate = False
            Me.TextBoxForm_InvoicePostPeriod.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_InvoicePostPeriod.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_InvoicePostPeriod.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_InvoicePostPeriod.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_InvoicePostPeriod.FocusHighlightEnabled = True
            Me.TextBoxForm_InvoicePostPeriod.Location = New System.Drawing.Point(338, 12)
            Me.TextBoxForm_InvoicePostPeriod.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_InvoicePostPeriod.Name = "TextBoxForm_InvoicePostPeriod"
            Me.TextBoxForm_InvoicePostPeriod.ReadOnly = True
            Me.TextBoxForm_InvoicePostPeriod.Size = New System.Drawing.Size(112, 20)
            Me.TextBoxForm_InvoicePostPeriod.TabIndex = 3
            Me.TextBoxForm_InvoicePostPeriod.TabOnEnter = True
            Me.TextBoxForm_InvoicePostPeriod.TabStop = False
            '
            'TextBoxForm_Client
            '
            Me.TextBoxForm_Client.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxForm_Client.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Client.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Client.CheckSpellingOnValidate = False
            Me.TextBoxForm_Client.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Client.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_Client.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Client.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Client.FocusHighlightEnabled = True
            Me.TextBoxForm_Client.Location = New System.Drawing.Point(100, 39)
            Me.TextBoxForm_Client.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Client.Name = "TextBoxForm_Client"
            Me.TextBoxForm_Client.ReadOnly = True
            Me.TextBoxForm_Client.Size = New System.Drawing.Size(350, 20)
            Me.TextBoxForm_Client.TabIndex = 5
            Me.TextBoxForm_Client.TabOnEnter = True
            Me.TextBoxForm_Client.TabStop = False
            '
            'TextBoxForm_InvoiceNumber
            '
            '
            '
            '
            Me.TextBoxForm_InvoiceNumber.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_InvoiceNumber.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_InvoiceNumber.CheckSpellingOnValidate = False
            Me.TextBoxForm_InvoiceNumber.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_InvoiceNumber.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_InvoiceNumber.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_InvoiceNumber.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_InvoiceNumber.FocusHighlightEnabled = True
            Me.TextBoxForm_InvoiceNumber.Location = New System.Drawing.Point(100, 12)
            Me.TextBoxForm_InvoiceNumber.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_InvoiceNumber.Name = "TextBoxForm_InvoiceNumber"
            Me.TextBoxForm_InvoiceNumber.ReadOnly = True
            Me.TextBoxForm_InvoiceNumber.Size = New System.Drawing.Size(111, 20)
            Me.TextBoxForm_InvoiceNumber.TabIndex = 1
            Me.TextBoxForm_InvoiceNumber.TabOnEnter = True
            Me.TextBoxForm_InvoiceNumber.TabStop = False
            '
            'VoidInvoiceDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(462, 240)
            Me.Controls.Add(Me.TextBoxForm_InvoiceNumber)
            Me.Controls.Add(Me.TextBoxForm_Client)
            Me.Controls.Add(Me.TextBoxForm_InvoicePostPeriod)
            Me.Controls.Add(Me.LabelForm_InvoicePostPeriod)
            Me.Controls.Add(Me.LabelForm_Client)
            Me.Controls.Add(Me.LabelForm_InvoiceNumber)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.TextBoxForm_Comment)
            Me.Controls.Add(Me.LabelForm_Comment)
            Me.Controls.Add(Me.ComboBoxForm_PostingPeriod)
            Me.Controls.Add(Me.LabelForm_PostingPeriod)
            Me.DoubleBuffered = True
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "VoidInvoiceDialog"
            Me.Text = "Void Client Invoice"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents TextBoxForm_Comment As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_Comment As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_PostingPeriod As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_PostingPeriod As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_InvoiceNumber As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Client As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_InvoicePostPeriod As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_InvoicePostPeriod As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxForm_Client As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxForm_InvoiceNumber As AdvantageFramework.WinForm.Presentation.Controls.TextBox
    End Class

End Namespace

