Namespace Desktop.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class DocumentUploadDialog
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
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DocumentUploadDialog))
            Me.ButtonForm_Upload = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelGeneral_LinkOrDocument = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxGeneral_LinkOrDocument = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelGeneral_FileDetails = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxGeneral_FileDetails = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelGeneral_FileType = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxGeneral_FileType = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.CheckBoxGeneral_Private = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelGeneral_Description = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxGeneral_Description = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelGeneral_Keywords = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxGeneral_Keywords = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelAlertOptions_SelectRecipients = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxAlertOptions_Subject = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.ComboBoxAlertOptions_Priority = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxAlertOptions_Category = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelAlertOptions_Subject = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelAlertOptions_Category = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelAlertOptions_Priority = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxGeneral_LinkName = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxGeneral_LinkURL = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelGeneral_LinkName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneral_LinkURL = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneral_OnlyOneFile = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneral_AddKeywords = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxGeneral_SendAlert = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TabControlControl_DocumentDetails = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelGeneralTab_General = New DevComponents.DotNetBar.TabControlPanel()
            Me.LabelGeneral_FilesLargerMessage = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxGeneral_AssociateToExpenseItems = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TabItemDocumentGeneral_GeneralTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelAlertOptionsTab_AlertOptions = New DevComponents.DotNetBar.TabControlPanel()
            Me.TreeListControlAlertOptions_Recepients = New AdvantageFramework.WinForm.Presentation.Controls.TreeListControl()
            Me.TabItemDocumentGeneral_AlertOptionsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelExpenseItemsTab_ExpenseItems = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewExpenseItems_ExpenseItems = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemDocumentGeneral_ExpenseItemsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            CType(Me.TabControlControl_DocumentDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlControl_DocumentDetails.SuspendLayout()
            Me.TabControlPanelGeneralTab_General.SuspendLayout()
            Me.TabControlPanelAlertOptionsTab_AlertOptions.SuspendLayout()
            CType(Me.TreeListControlAlertOptions_Recepients, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelExpenseItemsTab_ExpenseItems.SuspendLayout()
            Me.SuspendLayout()
            '
            'ButtonForm_Upload
            '
            Me.ButtonForm_Upload.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Upload.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Upload.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Upload.Location = New System.Drawing.Point(294, 366)
            Me.ButtonForm_Upload.Name = "ButtonForm_Upload"
            Me.ButtonForm_Upload.SecurityEnabled = True
            Me.ButtonForm_Upload.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Upload.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Upload.TabIndex = 2
            Me.ButtonForm_Upload.Text = "Upload"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(375, 366)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 3
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'LabelGeneral_LinkOrDocument
            '
            Me.LabelGeneral_LinkOrDocument.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_LinkOrDocument.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_LinkOrDocument.Location = New System.Drawing.Point(6, 6)
            Me.LabelGeneral_LinkOrDocument.Name = "LabelGeneral_LinkOrDocument"
            Me.LabelGeneral_LinkOrDocument.Size = New System.Drawing.Size(80, 20)
            Me.LabelGeneral_LinkOrDocument.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_LinkOrDocument.TabIndex = 0
            Me.LabelGeneral_LinkOrDocument.Text = "I want to add a:"
            '
            'ComboBoxGeneral_LinkOrDocument
            '
            Me.ComboBoxGeneral_LinkOrDocument.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxGeneral_LinkOrDocument.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxGeneral_LinkOrDocument.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxGeneral_LinkOrDocument.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxGeneral_LinkOrDocument.AutoFindItemInDataSource = False
            Me.ComboBoxGeneral_LinkOrDocument.AutoSelectSingleItemDatasource = False
            Me.ComboBoxGeneral_LinkOrDocument.BookmarkingEnabled = False
            Me.ComboBoxGeneral_LinkOrDocument.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumDataTable
            Me.ComboBoxGeneral_LinkOrDocument.DisableMouseWheel = False
            Me.ComboBoxGeneral_LinkOrDocument.DisplayMember = "Name"
            Me.ComboBoxGeneral_LinkOrDocument.DisplayName = ""
            Me.ComboBoxGeneral_LinkOrDocument.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxGeneral_LinkOrDocument.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxGeneral_LinkOrDocument.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxGeneral_LinkOrDocument.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxGeneral_LinkOrDocument.FocusHighlightEnabled = True
            Me.ComboBoxGeneral_LinkOrDocument.FormattingEnabled = True
            Me.ComboBoxGeneral_LinkOrDocument.ItemHeight = 14
            Me.ComboBoxGeneral_LinkOrDocument.Location = New System.Drawing.Point(92, 6)
            Me.ComboBoxGeneral_LinkOrDocument.Name = "ComboBoxGeneral_LinkOrDocument"
            Me.ComboBoxGeneral_LinkOrDocument.PreventEnterBeep = False
            Me.ComboBoxGeneral_LinkOrDocument.ReadOnly = False
            Me.ComboBoxGeneral_LinkOrDocument.SecurityEnabled = True
            Me.ComboBoxGeneral_LinkOrDocument.Size = New System.Drawing.Size(340, 20)
            Me.ComboBoxGeneral_LinkOrDocument.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxGeneral_LinkOrDocument.TabIndex = 1
            Me.ComboBoxGeneral_LinkOrDocument.ValueMember = "Value"
            Me.ComboBoxGeneral_LinkOrDocument.WatermarkText = "Select"
            '
            'LabelGeneral_FileDetails
            '
            Me.LabelGeneral_FileDetails.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_FileDetails.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_FileDetails.Location = New System.Drawing.Point(6, 32)
            Me.LabelGeneral_FileDetails.Name = "LabelGeneral_FileDetails"
            Me.LabelGeneral_FileDetails.Size = New System.Drawing.Size(80, 20)
            Me.LabelGeneral_FileDetails.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_FileDetails.TabIndex = 2
            Me.LabelGeneral_FileDetails.Text = "File Details:"
            '
            'TextBoxGeneral_FileDetails
            '
            Me.TextBoxGeneral_FileDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxGeneral_FileDetails.Border.Class = "TextBoxBorder"
            Me.TextBoxGeneral_FileDetails.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxGeneral_FileDetails.ButtonCustom.Visible = True
            Me.TextBoxGeneral_FileDetails.CheckSpellingOnValidate = False
            Me.TextBoxGeneral_FileDetails.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.File
            Me.TextBoxGeneral_FileDetails.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxGeneral_FileDetails.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxGeneral_FileDetails.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxGeneral_FileDetails.FocusHighlightEnabled = True
            Me.TextBoxGeneral_FileDetails.Location = New System.Drawing.Point(92, 32)
            Me.TextBoxGeneral_FileDetails.MaxFileSize = CType(0, Long)
            Me.TextBoxGeneral_FileDetails.Name = "TextBoxGeneral_FileDetails"
            Me.TextBoxGeneral_FileDetails.ShowSpellCheckCompleteMessage = True
            Me.TextBoxGeneral_FileDetails.Size = New System.Drawing.Size(340, 20)
            Me.TextBoxGeneral_FileDetails.TabIndex = 4
            Me.TextBoxGeneral_FileDetails.TabOnEnter = True
            '
            'LabelGeneral_FileType
            '
            Me.LabelGeneral_FileType.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_FileType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_FileType.Location = New System.Drawing.Point(6, 110)
            Me.LabelGeneral_FileType.Name = "LabelGeneral_FileType"
            Me.LabelGeneral_FileType.Size = New System.Drawing.Size(80, 20)
            Me.LabelGeneral_FileType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_FileType.TabIndex = 10
            Me.LabelGeneral_FileType.Text = "File Type:"
            '
            'ComboBoxGeneral_FileType
            '
            Me.ComboBoxGeneral_FileType.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxGeneral_FileType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxGeneral_FileType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxGeneral_FileType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxGeneral_FileType.AutoFindItemInDataSource = False
            Me.ComboBoxGeneral_FileType.AutoSelectSingleItemDatasource = False
            Me.ComboBoxGeneral_FileType.BookmarkingEnabled = False
            Me.ComboBoxGeneral_FileType.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.DocumentType
            Me.ComboBoxGeneral_FileType.DisableMouseWheel = False
            Me.ComboBoxGeneral_FileType.DisplayMember = "Description"
            Me.ComboBoxGeneral_FileType.DisplayName = ""
            Me.ComboBoxGeneral_FileType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxGeneral_FileType.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxGeneral_FileType.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxGeneral_FileType.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxGeneral_FileType.FocusHighlightEnabled = True
            Me.ComboBoxGeneral_FileType.FormattingEnabled = True
            Me.ComboBoxGeneral_FileType.ItemHeight = 14
            Me.ComboBoxGeneral_FileType.Location = New System.Drawing.Point(92, 110)
            Me.ComboBoxGeneral_FileType.Name = "ComboBoxGeneral_FileType"
            Me.ComboBoxGeneral_FileType.PreventEnterBeep = False
            Me.ComboBoxGeneral_FileType.ReadOnly = False
            Me.ComboBoxGeneral_FileType.SecurityEnabled = True
            Me.ComboBoxGeneral_FileType.Size = New System.Drawing.Size(272, 20)
            Me.ComboBoxGeneral_FileType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxGeneral_FileType.TabIndex = 11
            Me.ComboBoxGeneral_FileType.ValueMember = "ID"
            Me.ComboBoxGeneral_FileType.WatermarkText = "Select"
            '
            'CheckBoxGeneral_Private
            '
            Me.CheckBoxGeneral_Private.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxGeneral_Private.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxGeneral_Private.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxGeneral_Private.CheckValue = 0
            Me.CheckBoxGeneral_Private.CheckValueChecked = 1
            Me.CheckBoxGeneral_Private.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxGeneral_Private.CheckValueUnchecked = 0
            Me.CheckBoxGeneral_Private.ChildControls = Nothing
            Me.CheckBoxGeneral_Private.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxGeneral_Private.Location = New System.Drawing.Point(370, 110)
            Me.CheckBoxGeneral_Private.Name = "CheckBoxGeneral_Private"
            Me.CheckBoxGeneral_Private.OldestSibling = Nothing
            Me.CheckBoxGeneral_Private.SecurityEnabled = True
            Me.CheckBoxGeneral_Private.SiblingControls = Nothing
            Me.CheckBoxGeneral_Private.Size = New System.Drawing.Size(62, 20)
            Me.CheckBoxGeneral_Private.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxGeneral_Private.TabIndex = 12
            Me.CheckBoxGeneral_Private.Text = "Private"
            '
            'LabelGeneral_Description
            '
            Me.LabelGeneral_Description.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_Description.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_Description.Location = New System.Drawing.Point(6, 136)
            Me.LabelGeneral_Description.Name = "LabelGeneral_Description"
            Me.LabelGeneral_Description.Size = New System.Drawing.Size(80, 20)
            Me.LabelGeneral_Description.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_Description.TabIndex = 13
            Me.LabelGeneral_Description.Text = "Description:"
            '
            'TextBoxGeneral_Description
            '
            Me.TextBoxGeneral_Description.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxGeneral_Description.Border.Class = "TextBoxBorder"
            Me.TextBoxGeneral_Description.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxGeneral_Description.CheckSpellingOnValidate = False
            Me.TextBoxGeneral_Description.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxGeneral_Description.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxGeneral_Description.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxGeneral_Description.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxGeneral_Description.FocusHighlightEnabled = True
            Me.TextBoxGeneral_Description.Location = New System.Drawing.Point(92, 136)
            Me.TextBoxGeneral_Description.MaxFileSize = CType(0, Long)
            Me.TextBoxGeneral_Description.Multiline = True
            Me.TextBoxGeneral_Description.Name = "TextBoxGeneral_Description"
            Me.TextBoxGeneral_Description.ShowSpellCheckCompleteMessage = True
            Me.TextBoxGeneral_Description.Size = New System.Drawing.Size(340, 60)
            Me.TextBoxGeneral_Description.TabIndex = 14
            Me.TextBoxGeneral_Description.TabOnEnter = True
            '
            'LabelGeneral_Keywords
            '
            Me.LabelGeneral_Keywords.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_Keywords.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_Keywords.Location = New System.Drawing.Point(6, 202)
            Me.LabelGeneral_Keywords.Name = "LabelGeneral_Keywords"
            Me.LabelGeneral_Keywords.Size = New System.Drawing.Size(80, 20)
            Me.LabelGeneral_Keywords.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_Keywords.TabIndex = 15
            Me.LabelGeneral_Keywords.Text = "Keywords:"
            '
            'TextBoxGeneral_Keywords
            '
            Me.TextBoxGeneral_Keywords.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxGeneral_Keywords.Border.Class = "TextBoxBorder"
            Me.TextBoxGeneral_Keywords.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxGeneral_Keywords.CheckSpellingOnValidate = False
            Me.TextBoxGeneral_Keywords.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxGeneral_Keywords.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxGeneral_Keywords.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxGeneral_Keywords.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxGeneral_Keywords.FocusHighlightEnabled = True
            Me.TextBoxGeneral_Keywords.Location = New System.Drawing.Point(92, 202)
            Me.TextBoxGeneral_Keywords.MaxFileSize = CType(0, Long)
            Me.TextBoxGeneral_Keywords.Multiline = True
            Me.TextBoxGeneral_Keywords.Name = "TextBoxGeneral_Keywords"
            Me.TextBoxGeneral_Keywords.ShowSpellCheckCompleteMessage = True
            Me.TextBoxGeneral_Keywords.Size = New System.Drawing.Size(340, 60)
            Me.TextBoxGeneral_Keywords.TabIndex = 16
            Me.TextBoxGeneral_Keywords.TabOnEnter = True
            '
            'LabelAlertOptions_SelectRecipients
            '
            Me.LabelAlertOptions_SelectRecipients.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelAlertOptions_SelectRecipients.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAlertOptions_SelectRecipients.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelAlertOptions_SelectRecipients.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelAlertOptions_SelectRecipients.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelAlertOptions_SelectRecipients.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelAlertOptions_SelectRecipients.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelAlertOptions_SelectRecipients.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelAlertOptions_SelectRecipients.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAlertOptions_SelectRecipients.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelAlertOptions_SelectRecipients.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelAlertOptions_SelectRecipients.Location = New System.Drawing.Point(6, 58)
            Me.LabelAlertOptions_SelectRecipients.Name = "LabelAlertOptions_SelectRecipients"
            Me.LabelAlertOptions_SelectRecipients.Size = New System.Drawing.Size(426, 20)
            Me.LabelAlertOptions_SelectRecipients.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAlertOptions_SelectRecipients.TabIndex = 6
            Me.LabelAlertOptions_SelectRecipients.Text = "Select Recipients"
            '
            'TextBoxAlertOptions_Subject
            '
            Me.TextBoxAlertOptions_Subject.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxAlertOptions_Subject.Border.Class = "TextBoxBorder"
            Me.TextBoxAlertOptions_Subject.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxAlertOptions_Subject.CheckSpellingOnValidate = False
            Me.TextBoxAlertOptions_Subject.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxAlertOptions_Subject.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxAlertOptions_Subject.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxAlertOptions_Subject.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxAlertOptions_Subject.FocusHighlightEnabled = True
            Me.TextBoxAlertOptions_Subject.Location = New System.Drawing.Point(65, 6)
            Me.TextBoxAlertOptions_Subject.MaxFileSize = CType(0, Long)
            Me.TextBoxAlertOptions_Subject.Name = "TextBoxAlertOptions_Subject"
            Me.TextBoxAlertOptions_Subject.ShowSpellCheckCompleteMessage = True
            Me.TextBoxAlertOptions_Subject.Size = New System.Drawing.Size(367, 20)
            Me.TextBoxAlertOptions_Subject.TabIndex = 1
            Me.TextBoxAlertOptions_Subject.TabOnEnter = True
            Me.TextBoxAlertOptions_Subject.Text = "A new document has been uploaded."
            '
            'ComboBoxAlertOptions_Priority
            '
            Me.ComboBoxAlertOptions_Priority.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxAlertOptions_Priority.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxAlertOptions_Priority.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxAlertOptions_Priority.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxAlertOptions_Priority.AutoFindItemInDataSource = False
            Me.ComboBoxAlertOptions_Priority.AutoSelectSingleItemDatasource = False
            Me.ComboBoxAlertOptions_Priority.BookmarkingEnabled = False
            Me.ComboBoxAlertOptions_Priority.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumDataTable
            Me.ComboBoxAlertOptions_Priority.DisableMouseWheel = False
            Me.ComboBoxAlertOptions_Priority.DisplayMember = "Name"
            Me.ComboBoxAlertOptions_Priority.DisplayName = ""
            Me.ComboBoxAlertOptions_Priority.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxAlertOptions_Priority.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxAlertOptions_Priority.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxAlertOptions_Priority.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxAlertOptions_Priority.FocusHighlightEnabled = True
            Me.ComboBoxAlertOptions_Priority.FormattingEnabled = True
            Me.ComboBoxAlertOptions_Priority.ItemHeight = 14
            Me.ComboBoxAlertOptions_Priority.Location = New System.Drawing.Point(311, 32)
            Me.ComboBoxAlertOptions_Priority.Name = "ComboBoxAlertOptions_Priority"
            Me.ComboBoxAlertOptions_Priority.PreventEnterBeep = False
            Me.ComboBoxAlertOptions_Priority.ReadOnly = False
            Me.ComboBoxAlertOptions_Priority.SecurityEnabled = True
            Me.ComboBoxAlertOptions_Priority.Size = New System.Drawing.Size(121, 20)
            Me.ComboBoxAlertOptions_Priority.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxAlertOptions_Priority.TabIndex = 5
            Me.ComboBoxAlertOptions_Priority.ValueMember = "Value"
            Me.ComboBoxAlertOptions_Priority.WatermarkText = "Select"
            '
            'ComboBoxAlertOptions_Category
            '
            Me.ComboBoxAlertOptions_Category.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxAlertOptions_Category.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxAlertOptions_Category.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxAlertOptions_Category.AutoFindItemInDataSource = False
            Me.ComboBoxAlertOptions_Category.AutoSelectSingleItemDatasource = False
            Me.ComboBoxAlertOptions_Category.BookmarkingEnabled = False
            Me.ComboBoxAlertOptions_Category.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.AlertCategory
            Me.ComboBoxAlertOptions_Category.DisableMouseWheel = False
            Me.ComboBoxAlertOptions_Category.DisplayMember = "Description"
            Me.ComboBoxAlertOptions_Category.DisplayName = ""
            Me.ComboBoxAlertOptions_Category.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxAlertOptions_Category.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxAlertOptions_Category.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxAlertOptions_Category.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxAlertOptions_Category.FocusHighlightEnabled = True
            Me.ComboBoxAlertOptions_Category.FormattingEnabled = True
            Me.ComboBoxAlertOptions_Category.ItemHeight = 14
            Me.ComboBoxAlertOptions_Category.Location = New System.Drawing.Point(65, 32)
            Me.ComboBoxAlertOptions_Category.Name = "ComboBoxAlertOptions_Category"
            Me.ComboBoxAlertOptions_Category.PreventEnterBeep = False
            Me.ComboBoxAlertOptions_Category.ReadOnly = False
            Me.ComboBoxAlertOptions_Category.SecurityEnabled = True
            Me.ComboBoxAlertOptions_Category.Size = New System.Drawing.Size(190, 20)
            Me.ComboBoxAlertOptions_Category.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxAlertOptions_Category.TabIndex = 3
            Me.ComboBoxAlertOptions_Category.ValueMember = "ID"
            Me.ComboBoxAlertOptions_Category.WatermarkText = "Select"
            '
            'LabelAlertOptions_Subject
            '
            Me.LabelAlertOptions_Subject.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAlertOptions_Subject.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAlertOptions_Subject.Location = New System.Drawing.Point(6, 6)
            Me.LabelAlertOptions_Subject.Name = "LabelAlertOptions_Subject"
            Me.LabelAlertOptions_Subject.Size = New System.Drawing.Size(53, 20)
            Me.LabelAlertOptions_Subject.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAlertOptions_Subject.TabIndex = 0
            Me.LabelAlertOptions_Subject.Text = "Subject:"
            '
            'LabelAlertOptions_Category
            '
            Me.LabelAlertOptions_Category.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAlertOptions_Category.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAlertOptions_Category.Location = New System.Drawing.Point(6, 32)
            Me.LabelAlertOptions_Category.Name = "LabelAlertOptions_Category"
            Me.LabelAlertOptions_Category.Size = New System.Drawing.Size(53, 20)
            Me.LabelAlertOptions_Category.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAlertOptions_Category.TabIndex = 2
            Me.LabelAlertOptions_Category.Text = "Category:"
            '
            'LabelAlertOptions_Priority
            '
            Me.LabelAlertOptions_Priority.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAlertOptions_Priority.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAlertOptions_Priority.Location = New System.Drawing.Point(261, 32)
            Me.LabelAlertOptions_Priority.Name = "LabelAlertOptions_Priority"
            Me.LabelAlertOptions_Priority.Size = New System.Drawing.Size(44, 20)
            Me.LabelAlertOptions_Priority.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAlertOptions_Priority.TabIndex = 4
            Me.LabelAlertOptions_Priority.Text = "Priority:"
            '
            'TextBoxGeneral_LinkName
            '
            Me.TextBoxGeneral_LinkName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxGeneral_LinkName.Border.Class = "TextBoxBorder"
            Me.TextBoxGeneral_LinkName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxGeneral_LinkName.CheckSpellingOnValidate = False
            Me.TextBoxGeneral_LinkName.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxGeneral_LinkName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxGeneral_LinkName.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxGeneral_LinkName.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxGeneral_LinkName.FocusHighlightEnabled = True
            Me.TextBoxGeneral_LinkName.Location = New System.Drawing.Point(92, 32)
            Me.TextBoxGeneral_LinkName.MaxFileSize = CType(0, Long)
            Me.TextBoxGeneral_LinkName.Name = "TextBoxGeneral_LinkName"
            Me.TextBoxGeneral_LinkName.ShowSpellCheckCompleteMessage = True
            Me.TextBoxGeneral_LinkName.Size = New System.Drawing.Size(340, 20)
            Me.TextBoxGeneral_LinkName.TabIndex = 5
            Me.TextBoxGeneral_LinkName.TabOnEnter = True
            '
            'TextBoxGeneral_LinkURL
            '
            Me.TextBoxGeneral_LinkURL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxGeneral_LinkURL.Border.Class = "TextBoxBorder"
            Me.TextBoxGeneral_LinkURL.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxGeneral_LinkURL.CheckSpellingOnValidate = False
            Me.TextBoxGeneral_LinkURL.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxGeneral_LinkURL.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxGeneral_LinkURL.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxGeneral_LinkURL.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxGeneral_LinkURL.FocusHighlightEnabled = True
            Me.TextBoxGeneral_LinkURL.Location = New System.Drawing.Point(92, 58)
            Me.TextBoxGeneral_LinkURL.MaxFileSize = CType(0, Long)
            Me.TextBoxGeneral_LinkURL.Name = "TextBoxGeneral_LinkURL"
            Me.TextBoxGeneral_LinkURL.ShowSpellCheckCompleteMessage = True
            Me.TextBoxGeneral_LinkURL.Size = New System.Drawing.Size(340, 20)
            Me.TextBoxGeneral_LinkURL.TabIndex = 8
            Me.TextBoxGeneral_LinkURL.TabOnEnter = True
            '
            'LabelGeneral_LinkName
            '
            Me.LabelGeneral_LinkName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_LinkName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_LinkName.Location = New System.Drawing.Point(6, 32)
            Me.LabelGeneral_LinkName.Name = "LabelGeneral_LinkName"
            Me.LabelGeneral_LinkName.Size = New System.Drawing.Size(80, 20)
            Me.LabelGeneral_LinkName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_LinkName.TabIndex = 3
            Me.LabelGeneral_LinkName.Text = "Link Name:"
            '
            'LabelGeneral_LinkURL
            '
            Me.LabelGeneral_LinkURL.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_LinkURL.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_LinkURL.Location = New System.Drawing.Point(6, 58)
            Me.LabelGeneral_LinkURL.Name = "LabelGeneral_LinkURL"
            Me.LabelGeneral_LinkURL.Size = New System.Drawing.Size(80, 20)
            Me.LabelGeneral_LinkURL.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_LinkURL.TabIndex = 6
            Me.LabelGeneral_LinkURL.Text = "Link URL:"
            '
            'LabelGeneral_OnlyOneFile
            '
            Me.LabelGeneral_OnlyOneFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelGeneral_OnlyOneFile.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_OnlyOneFile.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_OnlyOneFile.Location = New System.Drawing.Point(92, 58)
            Me.LabelGeneral_OnlyOneFile.Name = "LabelGeneral_OnlyOneFile"
            Me.LabelGeneral_OnlyOneFile.Size = New System.Drawing.Size(340, 20)
            Me.LabelGeneral_OnlyOneFile.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_OnlyOneFile.TabIndex = 7
            Me.LabelGeneral_OnlyOneFile.Text = "Only one file can be uploaded at a time."
            '
            'LabelGeneral_AddKeywords
            '
            Me.LabelGeneral_AddKeywords.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelGeneral_AddKeywords.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_AddKeywords.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_AddKeywords.Location = New System.Drawing.Point(92, 268)
            Me.LabelGeneral_AddKeywords.Name = "LabelGeneral_AddKeywords"
            Me.LabelGeneral_AddKeywords.Size = New System.Drawing.Size(340, 20)
            Me.LabelGeneral_AddKeywords.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_AddKeywords.TabIndex = 17
            Me.LabelGeneral_AddKeywords.Text = "Add any keywords that may help someone find this document later."
            '
            'CheckBoxGeneral_SendAlert
            '
            Me.CheckBoxGeneral_SendAlert.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxGeneral_SendAlert.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxGeneral_SendAlert.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxGeneral_SendAlert.CheckValue = 0
            Me.CheckBoxGeneral_SendAlert.CheckValueChecked = 1
            Me.CheckBoxGeneral_SendAlert.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxGeneral_SendAlert.CheckValueUnchecked = 0
            Me.CheckBoxGeneral_SendAlert.ChildControls = Nothing
            Me.CheckBoxGeneral_SendAlert.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxGeneral_SendAlert.Location = New System.Drawing.Point(92, 294)
            Me.CheckBoxGeneral_SendAlert.Name = "CheckBoxGeneral_SendAlert"
            Me.CheckBoxGeneral_SendAlert.OldestSibling = Nothing
            Me.CheckBoxGeneral_SendAlert.SecurityEnabled = True
            Me.CheckBoxGeneral_SendAlert.SiblingControls = Nothing
            Me.CheckBoxGeneral_SendAlert.Size = New System.Drawing.Size(340, 20)
            Me.CheckBoxGeneral_SendAlert.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxGeneral_SendAlert.TabIndex = 18
            Me.CheckBoxGeneral_SendAlert.Text = "Send Alert"
            '
            'TabControlControl_DocumentDetails
            '
            Me.TabControlControl_DocumentDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlControl_DocumentDetails.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.TabControlControl_DocumentDetails.CanReorderTabs = False
            Me.TabControlControl_DocumentDetails.Controls.Add(Me.TabControlPanelGeneralTab_General)
            Me.TabControlControl_DocumentDetails.Controls.Add(Me.TabControlPanelAlertOptionsTab_AlertOptions)
            Me.TabControlControl_DocumentDetails.Controls.Add(Me.TabControlPanelExpenseItemsTab_ExpenseItems)
            Me.TabControlControl_DocumentDetails.Location = New System.Drawing.Point(12, 12)
            Me.TabControlControl_DocumentDetails.Name = "TabControlControl_DocumentDetails"
            Me.TabControlControl_DocumentDetails.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlControl_DocumentDetails.SelectedTabIndex = 0
            Me.TabControlControl_DocumentDetails.Size = New System.Drawing.Size(438, 348)
            Me.TabControlControl_DocumentDetails.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlControl_DocumentDetails.TabIndex = 0
            Me.TabControlControl_DocumentDetails.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlControl_DocumentDetails.Tabs.Add(Me.TabItemDocumentGeneral_GeneralTab)
            Me.TabControlControl_DocumentDetails.Tabs.Add(Me.TabItemDocumentGeneral_AlertOptionsTab)
            Me.TabControlControl_DocumentDetails.Tabs.Add(Me.TabItemDocumentGeneral_ExpenseItemsTab)
            Me.TabControlControl_DocumentDetails.Text = "TabControl1"
            '
            'TabControlPanelGeneralTab_General
            '
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_FilesLargerMessage)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_OnlyOneFile)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_FileDetails)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.TextBoxGeneral_FileDetails)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.CheckBoxGeneral_SendAlert)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.CheckBoxGeneral_AssociateToExpenseItems)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.TextBoxGeneral_LinkName)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_LinkOrDocument)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.TextBoxGeneral_LinkURL)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.ComboBoxGeneral_FileType)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_LinkName)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.CheckBoxGeneral_Private)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_LinkURL)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_FileType)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_Description)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_AddKeywords)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.TextBoxGeneral_Description)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.TextBoxGeneral_Keywords)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_Keywords)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.ComboBoxGeneral_LinkOrDocument)
            Me.TabControlPanelGeneralTab_General.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelGeneralTab_General.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelGeneralTab_General.Name = "TabControlPanelGeneralTab_General"
            Me.TabControlPanelGeneralTab_General.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelGeneralTab_General.Size = New System.Drawing.Size(438, 321)
            Me.TabControlPanelGeneralTab_General.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelGeneralTab_General.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelGeneralTab_General.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelGeneralTab_General.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelGeneralTab_General.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelGeneralTab_General.Style.GradientAngle = 90
            Me.TabControlPanelGeneralTab_General.TabIndex = 0
            Me.TabControlPanelGeneralTab_General.TabItem = Me.TabItemDocumentGeneral_GeneralTab
            '
            'LabelGeneral_FilesLargerMessage
            '
            Me.LabelGeneral_FilesLargerMessage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelGeneral_FilesLargerMessage.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_FilesLargerMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_FilesLargerMessage.Location = New System.Drawing.Point(92, 84)
            Me.LabelGeneral_FilesLargerMessage.Name = "LabelGeneral_FilesLargerMessage"
            Me.LabelGeneral_FilesLargerMessage.Size = New System.Drawing.Size(340, 20)
            Me.LabelGeneral_FilesLargerMessage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_FilesLargerMessage.TabIndex = 9
            Me.LabelGeneral_FilesLargerMessage.Text = "Files larger than 5MB will automatically be excluded."
            '
            'CheckBoxGeneral_AssociateToExpenseItems
            '
            Me.CheckBoxGeneral_AssociateToExpenseItems.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxGeneral_AssociateToExpenseItems.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxGeneral_AssociateToExpenseItems.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxGeneral_AssociateToExpenseItems.CheckValue = 0
            Me.CheckBoxGeneral_AssociateToExpenseItems.CheckValueChecked = 1
            Me.CheckBoxGeneral_AssociateToExpenseItems.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxGeneral_AssociateToExpenseItems.CheckValueUnchecked = 0
            Me.CheckBoxGeneral_AssociateToExpenseItems.ChildControls = Nothing
            Me.CheckBoxGeneral_AssociateToExpenseItems.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxGeneral_AssociateToExpenseItems.Location = New System.Drawing.Point(92, 294)
            Me.CheckBoxGeneral_AssociateToExpenseItems.Name = "CheckBoxGeneral_AssociateToExpenseItems"
            Me.CheckBoxGeneral_AssociateToExpenseItems.OldestSibling = Nothing
            Me.CheckBoxGeneral_AssociateToExpenseItems.SecurityEnabled = True
            Me.CheckBoxGeneral_AssociateToExpenseItems.SiblingControls = Nothing
            Me.CheckBoxGeneral_AssociateToExpenseItems.Size = New System.Drawing.Size(340, 20)
            Me.CheckBoxGeneral_AssociateToExpenseItems.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxGeneral_AssociateToExpenseItems.TabIndex = 19
            Me.CheckBoxGeneral_AssociateToExpenseItems.Text = "Associate to Expense Items"
            '
            'TabItemDocumentGeneral_GeneralTab
            '
            Me.TabItemDocumentGeneral_GeneralTab.AttachedControl = Me.TabControlPanelGeneralTab_General
            Me.TabItemDocumentGeneral_GeneralTab.Name = "TabItemDocumentGeneral_GeneralTab"
            Me.TabItemDocumentGeneral_GeneralTab.Text = "General"
            '
            'TabControlPanelAlertOptionsTab_AlertOptions
            '
            Me.TabControlPanelAlertOptionsTab_AlertOptions.Controls.Add(Me.LabelAlertOptions_SelectRecipients)
            Me.TabControlPanelAlertOptionsTab_AlertOptions.Controls.Add(Me.LabelAlertOptions_Subject)
            Me.TabControlPanelAlertOptionsTab_AlertOptions.Controls.Add(Me.TreeListControlAlertOptions_Recepients)
            Me.TabControlPanelAlertOptionsTab_AlertOptions.Controls.Add(Me.LabelAlertOptions_Priority)
            Me.TabControlPanelAlertOptionsTab_AlertOptions.Controls.Add(Me.TextBoxAlertOptions_Subject)
            Me.TabControlPanelAlertOptionsTab_AlertOptions.Controls.Add(Me.LabelAlertOptions_Category)
            Me.TabControlPanelAlertOptionsTab_AlertOptions.Controls.Add(Me.ComboBoxAlertOptions_Priority)
            Me.TabControlPanelAlertOptionsTab_AlertOptions.Controls.Add(Me.ComboBoxAlertOptions_Category)
            Me.TabControlPanelAlertOptionsTab_AlertOptions.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelAlertOptionsTab_AlertOptions.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelAlertOptionsTab_AlertOptions.Name = "TabControlPanelAlertOptionsTab_AlertOptions"
            Me.TabControlPanelAlertOptionsTab_AlertOptions.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelAlertOptionsTab_AlertOptions.Size = New System.Drawing.Size(438, 321)
            Me.TabControlPanelAlertOptionsTab_AlertOptions.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelAlertOptionsTab_AlertOptions.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelAlertOptionsTab_AlertOptions.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelAlertOptionsTab_AlertOptions.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelAlertOptionsTab_AlertOptions.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelAlertOptionsTab_AlertOptions.Style.GradientAngle = 90
            Me.TabControlPanelAlertOptionsTab_AlertOptions.TabIndex = 1
            Me.TabControlPanelAlertOptionsTab_AlertOptions.TabItem = Me.TabItemDocumentGeneral_AlertOptionsTab
            '
            'TreeListControlAlertOptions_Recepients
            '
            Me.TreeListControlAlertOptions_Recepients.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TreeListControlAlertOptions_Recepients.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TreeListControl.Type.[Default]
            Me.TreeListControlAlertOptions_Recepients.Location = New System.Drawing.Point(6, 84)
            Me.TreeListControlAlertOptions_Recepients.Name = "TreeListControlAlertOptions_Recepients"
            Me.TreeListControlAlertOptions_Recepients.OptionsNavigation.AutoMoveRowFocus = True
            Me.TreeListControlAlertOptions_Recepients.OptionsBehavior.Editable = False
            Me.TreeListControlAlertOptions_Recepients.OptionsNavigation.UseTabKey = True
            Me.TreeListControlAlertOptions_Recepients.Size = New System.Drawing.Size(426, 233)
            Me.TreeListControlAlertOptions_Recepients.TabIndex = 1
            '
            'TabItemDocumentGeneral_AlertOptionsTab
            '
            Me.TabItemDocumentGeneral_AlertOptionsTab.AttachedControl = Me.TabControlPanelAlertOptionsTab_AlertOptions
            Me.TabItemDocumentGeneral_AlertOptionsTab.Name = "TabItemDocumentGeneral_AlertOptionsTab"
            Me.TabItemDocumentGeneral_AlertOptionsTab.Text = "Alert Options"
            '
            'TabControlPanelExpenseItemsTab_ExpenseItems
            '
            Me.TabControlPanelExpenseItemsTab_ExpenseItems.Controls.Add(Me.DataGridViewExpenseItems_ExpenseItems)
            Me.TabControlPanelExpenseItemsTab_ExpenseItems.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelExpenseItemsTab_ExpenseItems.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelExpenseItemsTab_ExpenseItems.Name = "TabControlPanelExpenseItemsTab_ExpenseItems"
            Me.TabControlPanelExpenseItemsTab_ExpenseItems.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelExpenseItemsTab_ExpenseItems.Size = New System.Drawing.Size(438, 321)
            Me.TabControlPanelExpenseItemsTab_ExpenseItems.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelExpenseItemsTab_ExpenseItems.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelExpenseItemsTab_ExpenseItems.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelExpenseItemsTab_ExpenseItems.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelExpenseItemsTab_ExpenseItems.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelExpenseItemsTab_ExpenseItems.Style.GradientAngle = 90
            Me.TabControlPanelExpenseItemsTab_ExpenseItems.TabIndex = 2
            Me.TabControlPanelExpenseItemsTab_ExpenseItems.TabItem = Me.TabItemDocumentGeneral_ExpenseItemsTab
            '
            'DataGridViewExpenseItems_ExpenseItems
            '
            Me.DataGridViewExpenseItems_ExpenseItems.AllowSelectGroupHeaderRow = True
            Me.DataGridViewExpenseItems_ExpenseItems.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewExpenseItems_ExpenseItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewExpenseItems_ExpenseItems.AutoFilterLookupColumns = False
            Me.DataGridViewExpenseItems_ExpenseItems.AutoloadRepositoryDatasource = True
            Me.DataGridViewExpenseItems_ExpenseItems.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewExpenseItems_ExpenseItems.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewExpenseItems_ExpenseItems.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewExpenseItems_ExpenseItems.ItemDescription = "Item(s)"
            Me.DataGridViewExpenseItems_ExpenseItems.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewExpenseItems_ExpenseItems.MultiSelect = True
            Me.DataGridViewExpenseItems_ExpenseItems.Name = "DataGridViewExpenseItems_ExpenseItems"
            Me.DataGridViewExpenseItems_ExpenseItems.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewExpenseItems_ExpenseItems.RunStandardValidation = True
            Me.DataGridViewExpenseItems_ExpenseItems.ShowSelectDeselectAllButtons = False
            Me.DataGridViewExpenseItems_ExpenseItems.Size = New System.Drawing.Size(430, 313)
            Me.DataGridViewExpenseItems_ExpenseItems.TabIndex = 0
            Me.DataGridViewExpenseItems_ExpenseItems.UseEmbeddedNavigator = False
            Me.DataGridViewExpenseItems_ExpenseItems.ViewCaptionHeight = -1
            '
            'TabItemDocumentGeneral_ExpenseItemsTab
            '
            Me.TabItemDocumentGeneral_ExpenseItemsTab.AttachedControl = Me.TabControlPanelExpenseItemsTab_ExpenseItems
            Me.TabItemDocumentGeneral_ExpenseItemsTab.Name = "TabItemDocumentGeneral_ExpenseItemsTab"
            Me.TabItemDocumentGeneral_ExpenseItemsTab.Text = "Expense Items"
            '
            'DocumentUploadDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(462, 398)
            Me.Controls.Add(Me.TabControlControl_DocumentDetails)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.ButtonForm_Upload)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "DocumentUploadDialog"
            Me.Text = "Document Upload"
            CType(Me.TabControlControl_DocumentDetails, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlControl_DocumentDetails.ResumeLayout(False)
            Me.TabControlPanelGeneralTab_General.ResumeLayout(False)
            Me.TabControlPanelAlertOptionsTab_AlertOptions.ResumeLayout(False)
            CType(Me.TreeListControlAlertOptions_Recepients, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelExpenseItemsTab_ExpenseItems.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Upload As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelGeneral_LinkOrDocument As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxGeneral_LinkOrDocument As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelGeneral_FileDetails As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxGeneral_FileDetails As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelGeneral_FileType As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxGeneral_FileType As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents CheckBoxGeneral_Private As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelGeneral_Description As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxGeneral_Description As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelGeneral_Keywords As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxGeneral_Keywords As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxAlertOptions_Subject As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents ComboBoxAlertOptions_Priority As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxAlertOptions_Category As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelAlertOptions_Subject As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelAlertOptions_Category As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelAlertOptions_Priority As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxGeneral_SendAlert As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelGeneral_LinkURL As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGeneral_OnlyOneFile As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGeneral_AddKeywords As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxGeneral_LinkName As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxGeneral_LinkURL As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelGeneral_LinkName As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelAlertOptions_SelectRecipients As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TabControlControl_DocumentDetails As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelAlertOptionsTab_AlertOptions As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemDocumentGeneral_AlertOptionsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelGeneralTab_General As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemDocumentGeneral_GeneralTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelExpenseItemsTab_ExpenseItems As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewExpenseItems_ExpenseItems As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TabItemDocumentGeneral_ExpenseItemsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents CheckBoxGeneral_AssociateToExpenseItems As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents TreeListControlAlertOptions_Recepients As AdvantageFramework.WinForm.Presentation.Controls.TreeListControl
        Friend WithEvents LabelGeneral_FilesLargerMessage As AdvantageFramework.WinForm.Presentation.Controls.Label

    End Class

End Namespace