Namespace Maintenance.Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MarketGroupEditDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MarketGroupEditDialog))
            Me.ButtonForm_Add = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Update = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.TextBoxForm_Name = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.LabelForm_Name = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.ComboBoxForm_MediaType = New AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox()
            Me.LabelForm_MediaType = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelForm_Country = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.ComboBoxForm_Country = New AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox()
            Me.SuspendLayout()
            '
            'ButtonForm_Add
            '
            Me.ButtonForm_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Add.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Add.Location = New System.Drawing.Point(140, 91)
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
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(221, 91)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 8
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ButtonForm_Update
            '
            Me.ButtonForm_Update.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Update.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Update.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Update.Location = New System.Drawing.Point(140, 91)
            Me.ButtonForm_Update.Name = "ButtonForm_Update"
            Me.ButtonForm_Update.SecurityEnabled = True
            Me.ButtonForm_Update.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Update.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Update.TabIndex = 7
            Me.ButtonForm_Update.Text = "Update"
            '
            'TextBoxForm_Name
            '
            Me.TextBoxForm_Name.AgencyImportPath = Nothing
            Me.TextBoxForm_Name.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxForm_Name.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxForm_Name.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Name.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Name.CheckSpellingOnValidate = False
            Me.TextBoxForm_Name.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Name.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxForm_Name.DisplayName = ""
            Me.TextBoxForm_Name.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_Name.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Name.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Name.FocusHighlightEnabled = True
            Me.TextBoxForm_Name.ForeColor = System.Drawing.Color.Black
            Me.TextBoxForm_Name.Location = New System.Drawing.Point(99, 64)
            Me.TextBoxForm_Name.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Name.Name = "TextBoxForm_Name"
            Me.TextBoxForm_Name.SecurityEnabled = True
            Me.TextBoxForm_Name.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Name.Size = New System.Drawing.Size(197, 20)
            Me.TextBoxForm_Name.StartingFolderName = Nothing
            Me.TextBoxForm_Name.TabIndex = 5
            Me.TextBoxForm_Name.TabOnEnter = True
            '
            'LabelForm_Name
            '
            Me.LabelForm_Name.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Name.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Name.Location = New System.Drawing.Point(12, 64)
            Me.LabelForm_Name.Name = "LabelForm_Name"
            Me.LabelForm_Name.Size = New System.Drawing.Size(81, 20)
            Me.LabelForm_Name.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Name.TabIndex = 4
            Me.LabelForm_Name.Text = "Name:"
            '
            'ComboBoxForm_MediaType
            '
            Me.ComboBoxForm_MediaType.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_MediaType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_MediaType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_MediaType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_MediaType.AutoFindItemInDataSource = False
            Me.ComboBoxForm_MediaType.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_MediaType.BookmarkingEnabled = False
            Me.ComboBoxForm_MediaType.DisableMouseWheel = False
            Me.ComboBoxForm_MediaType.DisplayMember = "Text"
            Me.ComboBoxForm_MediaType.DisplayName = ""
            Me.ComboBoxForm_MediaType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_MediaType.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_MediaType.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_MediaType.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_MediaType.FocusHighlightEnabled = True
            Me.ComboBoxForm_MediaType.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxForm_MediaType.FormattingEnabled = True
            Me.ComboBoxForm_MediaType.ItemHeight = 14
            Me.ComboBoxForm_MediaType.Location = New System.Drawing.Point(99, 12)
            Me.ComboBoxForm_MediaType.Name = "ComboBoxForm_MediaType"
            Me.ComboBoxForm_MediaType.ReadOnly = False
            Me.ComboBoxForm_MediaType.SecurityEnabled = True
            Me.ComboBoxForm_MediaType.Size = New System.Drawing.Size(197, 20)
            Me.ComboBoxForm_MediaType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_MediaType.TabIndex = 1
            Me.ComboBoxForm_MediaType.TabOnEnter = True
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
            Me.LabelForm_MediaType.Size = New System.Drawing.Size(81, 20)
            Me.LabelForm_MediaType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_MediaType.TabIndex = 0
            Me.LabelForm_MediaType.Text = "Media Type:"
            '
            'LabelForm_Country
            '
            Me.LabelForm_Country.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Country.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Country.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_Country.Name = "LabelForm_Country"
            Me.LabelForm_Country.Size = New System.Drawing.Size(81, 20)
            Me.LabelForm_Country.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Country.TabIndex = 2
            Me.LabelForm_Country.Text = "Country:"
            '
            'ComboBoxForm_Country
            '
            Me.ComboBoxForm_Country.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Country.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_Country.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Country.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Country.AutoFindItemInDataSource = False
            Me.ComboBoxForm_Country.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Country.BookmarkingEnabled = False
            Me.ComboBoxForm_Country.DisableMouseWheel = False
            Me.ComboBoxForm_Country.DisplayMember = "Text"
            Me.ComboBoxForm_Country.DisplayName = ""
            Me.ComboBoxForm_Country.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Country.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_Country.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_Country.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Country.FocusHighlightEnabled = True
            Me.ComboBoxForm_Country.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxForm_Country.FormattingEnabled = True
            Me.ComboBoxForm_Country.ItemHeight = 14
            Me.ComboBoxForm_Country.Location = New System.Drawing.Point(99, 38)
            Me.ComboBoxForm_Country.Name = "ComboBoxForm_Country"
            Me.ComboBoxForm_Country.ReadOnly = False
            Me.ComboBoxForm_Country.SecurityEnabled = True
            Me.ComboBoxForm_Country.Size = New System.Drawing.Size(197, 20)
            Me.ComboBoxForm_Country.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Country.TabIndex = 3
            Me.ComboBoxForm_Country.TabOnEnter = True
            '
            'MarketGroupEditDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(308, 123)
            Me.Controls.Add(Me.LabelForm_Country)
            Me.Controls.Add(Me.ComboBoxForm_Country)
            Me.Controls.Add(Me.LabelForm_MediaType)
            Me.Controls.Add(Me.ComboBoxForm_MediaType)
            Me.Controls.Add(Me.TextBoxForm_Name)
            Me.Controls.Add(Me.LabelForm_Name)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.ButtonForm_Add)
            Me.Controls.Add(Me.ButtonForm_Update)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MarketGroupEditDialog"
            Me.Text = "Market Group"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Add As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Update As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents TextBoxForm_Name As WinForm.MVC.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_Name As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_MediaType As WinForm.MVC.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_MediaType As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelForm_Country As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_Country As WinForm.MVC.Presentation.Controls.ComboBox
    End Class

End Namespace