Namespace Maintenance.Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AssociateCopyDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AssociateCopyDialog))
            Me.ButtonForm_Copy = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ComboBoxForm_MediaType = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_MediaType = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_Product = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxForm_Division = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxForm_Client = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_Product = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Division = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Client = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'DefaultLookAndFeelOffice2010Blue
            '
            Me.DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
            '
            'ButtonForm_Copy
            '
            Me.ButtonForm_Copy.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Copy.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Copy.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Copy.Location = New System.Drawing.Point(229, 116)
            Me.ButtonForm_Copy.Name = "ButtonForm_Copy"
            Me.ButtonForm_Copy.SecurityEnabled = True
            Me.ButtonForm_Copy.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Copy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Copy.TabIndex = 8
            Me.ButtonForm_Copy.Text = "Copy"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(310, 116)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 9
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ComboBoxForm_MediaType
            '
            Me.ComboBoxForm_MediaType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_MediaType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_MediaType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_MediaType.BookmarkingEnabled = False
            Me.ComboBoxForm_MediaType.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.MediaType
            Me.ComboBoxForm_MediaType.DisplayMember = "Description"
            Me.ComboBoxForm_MediaType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_MediaType.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_MediaType.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_MediaType.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_MediaType.FocusHighlightEnabled = True
            Me.ComboBoxForm_MediaType.FormattingEnabled = True
            Me.ComboBoxForm_MediaType.ItemHeight = 14
            Me.ComboBoxForm_MediaType.Location = New System.Drawing.Point(86, 90)
            Me.ComboBoxForm_MediaType.Name = "ComboBoxForm_MediaType"
            Me.ComboBoxForm_MediaType.PreventEnterBeep = False
            Me.ComboBoxForm_MediaType.Size = New System.Drawing.Size(299, 20)
            Me.ComboBoxForm_MediaType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_MediaType.TabIndex = 7
            Me.ComboBoxForm_MediaType.ValueMember = "Code"
            Me.ComboBoxForm_MediaType.WatermarkText = "Select Media Type"
            '
            'LabelForm_MediaType
            '
            Me.LabelForm_MediaType.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_MediaType.BackgroundStyle.Class = ""
            Me.LabelForm_MediaType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_MediaType.Location = New System.Drawing.Point(12, 90)
            Me.LabelForm_MediaType.Name = "LabelForm_MediaType"
            Me.LabelForm_MediaType.Size = New System.Drawing.Size(68, 20)
            Me.LabelForm_MediaType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_MediaType.TabIndex = 6
            Me.LabelForm_MediaType.Text = "Media Type:"
            '
            'ComboBoxForm_Product
            '
            Me.ComboBoxForm_Product.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_Product.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Product.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Product.BookmarkingEnabled = False
            Me.ComboBoxForm_Product.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Product
            Me.ComboBoxForm_Product.DisplayMember = "Name"
            Me.ComboBoxForm_Product.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Product.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_Product.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_Product.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Product.FocusHighlightEnabled = True
            Me.ComboBoxForm_Product.FormattingEnabled = True
            Me.ComboBoxForm_Product.ItemHeight = 14
            Me.ComboBoxForm_Product.Location = New System.Drawing.Point(86, 64)
            Me.ComboBoxForm_Product.Name = "ComboBoxForm_Product"
            Me.ComboBoxForm_Product.PreventEnterBeep = False
            Me.ComboBoxForm_Product.Size = New System.Drawing.Size(299, 20)
            Me.ComboBoxForm_Product.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Product.TabIndex = 5
            Me.ComboBoxForm_Product.ValueMember = "Code"
            Me.ComboBoxForm_Product.WatermarkText = "Select Product"
            '
            'ComboBoxForm_Division
            '
            Me.ComboBoxForm_Division.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_Division.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Division.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Division.BookmarkingEnabled = False
            Me.ComboBoxForm_Division.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Division
            Me.ComboBoxForm_Division.DisplayMember = "Description"
            Me.ComboBoxForm_Division.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Division.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_Division.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_Division.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Division.FocusHighlightEnabled = True
            Me.ComboBoxForm_Division.FormattingEnabled = True
            Me.ComboBoxForm_Division.ItemHeight = 14
            Me.ComboBoxForm_Division.Location = New System.Drawing.Point(86, 38)
            Me.ComboBoxForm_Division.Name = "ComboBoxForm_Division"
            Me.ComboBoxForm_Division.PreventEnterBeep = False
            Me.ComboBoxForm_Division.Size = New System.Drawing.Size(299, 20)
            Me.ComboBoxForm_Division.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Division.TabIndex = 3
            Me.ComboBoxForm_Division.ValueMember = "Code"
            Me.ComboBoxForm_Division.WatermarkText = "Select Division"
            '
            'ComboBoxForm_Client
            '
            Me.ComboBoxForm_Client.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_Client.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Client.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Client.BookmarkingEnabled = False
            Me.ComboBoxForm_Client.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Client
            Me.ComboBoxForm_Client.DisplayMember = "Name"
            Me.ComboBoxForm_Client.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Client.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_Client.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_Client.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Client.FocusHighlightEnabled = True
            Me.ComboBoxForm_Client.FormattingEnabled = True
            Me.ComboBoxForm_Client.ItemHeight = 14
            Me.ComboBoxForm_Client.Location = New System.Drawing.Point(86, 12)
            Me.ComboBoxForm_Client.Name = "ComboBoxForm_Client"
            Me.ComboBoxForm_Client.PreventEnterBeep = False
            Me.ComboBoxForm_Client.Size = New System.Drawing.Size(299, 20)
            Me.ComboBoxForm_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Client.TabIndex = 1
            Me.ComboBoxForm_Client.ValueMember = "Code"
            Me.ComboBoxForm_Client.WatermarkText = "Select Client"
            '
            'LabelForm_Product
            '
            Me.LabelForm_Product.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Product.BackgroundStyle.Class = ""
            Me.LabelForm_Product.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Product.Location = New System.Drawing.Point(12, 64)
            Me.LabelForm_Product.Name = "LabelForm_Product"
            Me.LabelForm_Product.Size = New System.Drawing.Size(68, 20)
            Me.LabelForm_Product.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Product.TabIndex = 4
            Me.LabelForm_Product.Text = "Product:"
            '
            'LabelForm_Division
            '
            Me.LabelForm_Division.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Division.BackgroundStyle.Class = ""
            Me.LabelForm_Division.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Division.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_Division.Name = "LabelForm_Division"
            Me.LabelForm_Division.Size = New System.Drawing.Size(68, 20)
            Me.LabelForm_Division.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Division.TabIndex = 2
            Me.LabelForm_Division.Text = "Division:"
            '
            'LabelForm_Client
            '
            Me.LabelForm_Client.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Client.BackgroundStyle.Class = ""
            Me.LabelForm_Client.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Client.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_Client.Name = "LabelForm_Client"
            Me.LabelForm_Client.Size = New System.Drawing.Size(68, 20)
            Me.LabelForm_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Client.TabIndex = 0
            Me.LabelForm_Client.Text = "Client:"
            '
            'AssociateCopyDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(397, 148)
            Me.Controls.Add(Me.LabelForm_MediaType)
            Me.Controls.Add(Me.ComboBoxForm_Product)
            Me.Controls.Add(Me.ComboBoxForm_MediaType)
            Me.Controls.Add(Me.ComboBoxForm_Division)
            Me.Controls.Add(Me.ComboBoxForm_Client)
            Me.Controls.Add(Me.LabelForm_Product)
            Me.Controls.Add(Me.LabelForm_Division)
            Me.Controls.Add(Me.LabelForm_Client)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.ButtonForm_Copy)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "AssociateCopyDialog"
            Me.Text = "Copy Associates To..."
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Copy As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ComboBoxForm_MediaType As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_MediaType As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_Product As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxForm_Division As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxForm_Client As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_Product As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Division As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Client As AdvantageFramework.WinForm.Presentation.Controls.Label
    End Class

End Namespace