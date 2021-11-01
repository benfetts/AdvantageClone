Namespace Importing.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ImportCSVTemplateDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImportCSVTemplateDialog))
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Add = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_File = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_File = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_Name = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_Name = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.ButtonForm_LoadFile = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewForm_Items = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.LabelForm_LoadingFileMessage = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ButtonForm_Reset = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Update = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_DefaultDirectory = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_DefaultDirectory = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_RecordSource = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_RecordSource = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.SuspendLayout()
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(405, 481)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 14
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ButtonForm_Add
            '
            Me.ButtonForm_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Add.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Add.Location = New System.Drawing.Point(324, 481)
            Me.ButtonForm_Add.Name = "ButtonForm_Add"
            Me.ButtonForm_Add.SecurityEnabled = True
            Me.ButtonForm_Add.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Add.TabIndex = 13
            Me.ButtonForm_Add.Text = "Add"
            '
            'LabelForm_File
            '
            Me.LabelForm_File.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_File.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_File.Location = New System.Drawing.Point(12, 90)
            Me.LabelForm_File.Name = "LabelForm_File"
            Me.LabelForm_File.Size = New System.Drawing.Size(96, 20)
            Me.LabelForm_File.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_File.TabIndex = 6
            Me.LabelForm_File.Text = "File:"
            '
            'TextBoxForm_File
            '
            Me.TextBoxForm_File.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxForm_File.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_File.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_File.ButtonCustom.Visible = True
            Me.TextBoxForm_File.CheckSpellingOnValidate = False
            Me.TextBoxForm_File.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.File
            Me.TextBoxForm_File.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxForm_File.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.CSV
            Me.TextBoxForm_File.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_File.FocusHighlightEnabled = True
            Me.TextBoxForm_File.Location = New System.Drawing.Point(114, 90)
            Me.TextBoxForm_File.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_File.Name = "TextBoxForm_File"
            Me.TextBoxForm_File.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_File.Size = New System.Drawing.Size(285, 20)
            Me.TextBoxForm_File.TabIndex = 7
            Me.TextBoxForm_File.TabOnEnter = True
            '
            'LabelForm_Name
            '
            Me.LabelForm_Name.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Name.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Name.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_Name.Name = "LabelForm_Name"
            Me.LabelForm_Name.Size = New System.Drawing.Size(96, 20)
            Me.LabelForm_Name.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Name.TabIndex = 0
            Me.LabelForm_Name.Text = "Name:"
            '
            'TextBoxForm_Name
            '
            Me.TextBoxForm_Name.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxForm_Name.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Name.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Name.CheckSpellingOnValidate = False
            Me.TextBoxForm_Name.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Name.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxForm_Name.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Name.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Name.FocusHighlightEnabled = True
            Me.TextBoxForm_Name.Location = New System.Drawing.Point(114, 12)
            Me.TextBoxForm_Name.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Name.Name = "TextBoxForm_Name"
            Me.TextBoxForm_Name.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Name.Size = New System.Drawing.Size(366, 20)
            Me.TextBoxForm_Name.TabIndex = 1
            Me.TextBoxForm_Name.TabOnEnter = True
            '
            'ButtonForm_LoadFile
            '
            Me.ButtonForm_LoadFile.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_LoadFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_LoadFile.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_LoadFile.Location = New System.Drawing.Point(405, 91)
            Me.ButtonForm_LoadFile.Name = "ButtonForm_LoadFile"
            Me.ButtonForm_LoadFile.SecurityEnabled = True
            Me.ButtonForm_LoadFile.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_LoadFile.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_LoadFile.TabIndex = 8
            Me.ButtonForm_LoadFile.Text = "Load"
            '
            'DataGridViewForm_Items
            '
            Me.DataGridViewForm_Items.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_Items.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_Items.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_Items.AutoFilterLookupColumns = False
            Me.DataGridViewForm_Items.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_Items.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_Items.DataSource = Nothing
            Me.DataGridViewForm_Items.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_Items.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_Items.ItemDescription = ""
            Me.DataGridViewForm_Items.Location = New System.Drawing.Point(12, 143)
            Me.DataGridViewForm_Items.MultiSelect = True
            Me.DataGridViewForm_Items.Name = "DataGridViewForm_Items"
            Me.DataGridViewForm_Items.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_Items.RunStandardValidation = True
            Me.DataGridViewForm_Items.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_Items.Size = New System.Drawing.Size(468, 332)
            Me.DataGridViewForm_Items.TabIndex = 10
            Me.DataGridViewForm_Items.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Items.ViewCaptionHeight = -1
            '
            'LabelForm_LoadingFileMessage
            '
            Me.LabelForm_LoadingFileMessage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_LoadingFileMessage.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_LoadingFileMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_LoadingFileMessage.Location = New System.Drawing.Point(114, 117)
            Me.LabelForm_LoadingFileMessage.Name = "LabelForm_LoadingFileMessage"
            Me.LabelForm_LoadingFileMessage.Size = New System.Drawing.Size(366, 20)
            Me.LabelForm_LoadingFileMessage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_LoadingFileMessage.TabIndex = 9
            Me.LabelForm_LoadingFileMessage.Text = "* Loading a file allows you to build a template using a CSV file."
            '
            'ButtonForm_Reset
            '
            Me.ButtonForm_Reset.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Reset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Reset.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Reset.Location = New System.Drawing.Point(243, 481)
            Me.ButtonForm_Reset.Name = "ButtonForm_Reset"
            Me.ButtonForm_Reset.SecurityEnabled = True
            Me.ButtonForm_Reset.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Reset.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Reset.TabIndex = 11
            Me.ButtonForm_Reset.Text = "Reset"
            '
            'ButtonForm_Update
            '
            Me.ButtonForm_Update.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Update.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Update.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Update.Location = New System.Drawing.Point(324, 481)
            Me.ButtonForm_Update.Name = "ButtonForm_Update"
            Me.ButtonForm_Update.SecurityEnabled = True
            Me.ButtonForm_Update.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Update.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Update.TabIndex = 12
            Me.ButtonForm_Update.Text = "Update"
            '
            'LabelForm_DefaultDirectory
            '
            Me.LabelForm_DefaultDirectory.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_DefaultDirectory.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_DefaultDirectory.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_DefaultDirectory.Name = "LabelForm_DefaultDirectory"
            Me.LabelForm_DefaultDirectory.Size = New System.Drawing.Size(96, 20)
            Me.LabelForm_DefaultDirectory.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_DefaultDirectory.TabIndex = 2
            Me.LabelForm_DefaultDirectory.Text = "Default Directory:"
            '
            'TextBoxForm_DefaultDirectory
            '
            Me.TextBoxForm_DefaultDirectory.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxForm_DefaultDirectory.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_DefaultDirectory.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_DefaultDirectory.ButtonCustom.Visible = True
            Me.TextBoxForm_DefaultDirectory.CheckSpellingOnValidate = False
            Me.TextBoxForm_DefaultDirectory.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.Folder
            Me.TextBoxForm_DefaultDirectory.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxForm_DefaultDirectory.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.CSV
            Me.TextBoxForm_DefaultDirectory.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_DefaultDirectory.FocusHighlightEnabled = True
            Me.TextBoxForm_DefaultDirectory.Location = New System.Drawing.Point(114, 38)
            Me.TextBoxForm_DefaultDirectory.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_DefaultDirectory.Name = "TextBoxForm_DefaultDirectory"
            Me.TextBoxForm_DefaultDirectory.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_DefaultDirectory.Size = New System.Drawing.Size(366, 20)
            Me.TextBoxForm_DefaultDirectory.TabIndex = 3
            Me.TextBoxForm_DefaultDirectory.TabOnEnter = True
            '
            'LabelForm_RecordSource
            '
            Me.LabelForm_RecordSource.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_RecordSource.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_RecordSource.Location = New System.Drawing.Point(12, 64)
            Me.LabelForm_RecordSource.Name = "LabelForm_RecordSource"
            Me.LabelForm_RecordSource.Size = New System.Drawing.Size(96, 20)
            Me.LabelForm_RecordSource.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_RecordSource.TabIndex = 4
            Me.LabelForm_RecordSource.Text = "Record Source:"
            '
            'ComboBoxForm_RecordSource
            '
            Me.ComboBoxForm_RecordSource.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_RecordSource.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_RecordSource.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_RecordSource.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_RecordSource.AutoFindItemInDataSource = False
            Me.ComboBoxForm_RecordSource.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_RecordSource.BookmarkingEnabled = False
            Me.ComboBoxForm_RecordSource.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.RecordSource
            Me.ComboBoxForm_RecordSource.DisableMouseWheel = False
            Me.ComboBoxForm_RecordSource.DisplayMember = "Name"
            Me.ComboBoxForm_RecordSource.DisplayName = ""
            Me.ComboBoxForm_RecordSource.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_RecordSource.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_RecordSource.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.None
            Me.ComboBoxForm_RecordSource.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_RecordSource.FocusHighlightEnabled = True
            Me.ComboBoxForm_RecordSource.FormattingEnabled = True
            Me.ComboBoxForm_RecordSource.ItemHeight = 14
            Me.ComboBoxForm_RecordSource.Location = New System.Drawing.Point(114, 64)
            Me.ComboBoxForm_RecordSource.Name = "ComboBoxForm_RecordSource"
            Me.ComboBoxForm_RecordSource.PreventEnterBeep = False
            Me.ComboBoxForm_RecordSource.ReadOnly = False
            Me.ComboBoxForm_RecordSource.SecurityEnabled = True
            Me.ComboBoxForm_RecordSource.Size = New System.Drawing.Size(366, 20)
            Me.ComboBoxForm_RecordSource.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_RecordSource.TabIndex = 5
            Me.ComboBoxForm_RecordSource.ValueMember = "ID"
            Me.ComboBoxForm_RecordSource.WatermarkText = "Select Record Source"
            '
            'ImportCSVTemplateDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(492, 513)
            Me.Controls.Add(Me.ComboBoxForm_RecordSource)
            Me.Controls.Add(Me.LabelForm_RecordSource)
            Me.Controls.Add(Me.TextBoxForm_DefaultDirectory)
            Me.Controls.Add(Me.LabelForm_DefaultDirectory)
            Me.Controls.Add(Me.ButtonForm_Update)
            Me.Controls.Add(Me.ButtonForm_Reset)
            Me.Controls.Add(Me.DataGridViewForm_Items)
            Me.Controls.Add(Me.TextBoxForm_Name)
            Me.Controls.Add(Me.LabelForm_LoadingFileMessage)
            Me.Controls.Add(Me.LabelForm_Name)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.TextBoxForm_File)
            Me.Controls.Add(Me.ButtonForm_LoadFile)
            Me.Controls.Add(Me.ButtonForm_Add)
            Me.Controls.Add(Me.LabelForm_File)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ImportCSVTemplateDialog"
            Me.Text = "Expense Import Template"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Add As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_File As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_File As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_Name As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_Name As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents ButtonForm_LoadFile As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewForm_Items As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents LabelForm_LoadingFileMessage As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonForm_Reset As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Update As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_DefaultDirectory As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_DefaultDirectory As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_RecordSource As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_RecordSource As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
    End Class

End Namespace