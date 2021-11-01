Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaPlanUpdateDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaPlanUpdateDialog))
            Me.ComboBoxForm_ClientContact = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.TextBoxForm_Description = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_Description = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_ClientContact = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Update = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ComboBoxForm_Product = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxForm_Division = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxForm_Client = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_Product = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Division = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Client = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_EndDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_StartDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.NumericInputForm_GrossBudgetAmount = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelForm_GrossBudgetAmount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Comment = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_Comment = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.CheckBoxForm_SyncEstimateSettings = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_IsInactive = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.DateEditForm_EndDate = New AdvantageFramework.WinForm.Presentation.Controls.DateEdit()
            Me.DateEditForm_StartDate = New AdvantageFramework.WinForm.Presentation.Controls.DateEdit()
            Me.CheckBoxForm_SyncFieldWidths = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_IsTemplate = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.ComboBoxForm_Campaign = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_Campaign = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Country = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_Country = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            CType(Me.NumericInputForm_GrossBudgetAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateEditForm_EndDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateEditForm_EndDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateEditForm_StartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateEditForm_StartDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ComboBoxForm_ClientContact
            '
            Me.ComboBoxForm_ClientContact.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_ClientContact.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_ClientContact.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_ClientContact.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_ClientContact.AutoFindItemInDataSource = False
            Me.ComboBoxForm_ClientContact.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_ClientContact.BookmarkingEnabled = False
            Me.ComboBoxForm_ClientContact.ClientCode = ""
            Me.ComboBoxForm_ClientContact.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.ClientContact
            Me.ComboBoxForm_ClientContact.DisableMouseWheel = False
            Me.ComboBoxForm_ClientContact.DisplayMember = "FullNameFML"
            Me.ComboBoxForm_ClientContact.DisplayName = ""
            Me.ComboBoxForm_ClientContact.DivisionCode = ""
            Me.ComboBoxForm_ClientContact.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_ClientContact.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_ClientContact.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_ClientContact.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_ClientContact.FocusHighlightEnabled = True
            Me.ComboBoxForm_ClientContact.FormattingEnabled = True
            Me.ComboBoxForm_ClientContact.ItemHeight = 14
            Me.ComboBoxForm_ClientContact.Location = New System.Drawing.Point(121, 114)
            Me.ComboBoxForm_ClientContact.Name = "ComboBoxForm_ClientContact"
            Me.ComboBoxForm_ClientContact.ReadOnly = False
            Me.ComboBoxForm_ClientContact.SecurityEnabled = True
            Me.ComboBoxForm_ClientContact.Size = New System.Drawing.Size(335, 20)
            Me.ComboBoxForm_ClientContact.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_ClientContact.TabIndex = 9
            Me.ComboBoxForm_ClientContact.TabOnEnter = True
            Me.ComboBoxForm_ClientContact.ValueMember = "ID"
            Me.ComboBoxForm_ClientContact.WatermarkText = "Select Client Contact"
            '
            'TextBoxForm_Description
            '
            Me.TextBoxForm_Description.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxForm_Description.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Description.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Description.CheckSpellingOnValidate = False
            Me.TextBoxForm_Description.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Description.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxForm_Description.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Description.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Description.FocusHighlightEnabled = True
            Me.TextBoxForm_Description.Location = New System.Drawing.Point(121, 12)
            Me.TextBoxForm_Description.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Description.Name = "TextBoxForm_Description"
            Me.TextBoxForm_Description.SecurityEnabled = True
            Me.TextBoxForm_Description.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Description.Size = New System.Drawing.Size(335, 20)
            Me.TextBoxForm_Description.StartingFolderName = Nothing
            Me.TextBoxForm_Description.TabIndex = 1
            Me.TextBoxForm_Description.TabOnEnter = True
            '
            'LabelForm_Description
            '
            Me.LabelForm_Description.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Description.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Description.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_Description.Name = "LabelForm_Description"
            Me.LabelForm_Description.Size = New System.Drawing.Size(103, 20)
            Me.LabelForm_Description.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Description.TabIndex = 0
            Me.LabelForm_Description.Text = "Description:"
            '
            'LabelForm_ClientContact
            '
            Me.LabelForm_ClientContact.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_ClientContact.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_ClientContact.Location = New System.Drawing.Point(12, 114)
            Me.LabelForm_ClientContact.Name = "LabelForm_ClientContact"
            Me.LabelForm_ClientContact.Size = New System.Drawing.Size(103, 20)
            Me.LabelForm_ClientContact.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ClientContact.TabIndex = 8
            Me.LabelForm_ClientContact.Text = "Client Contact:"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(381, 441)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 27
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ButtonForm_Update
            '
            Me.ButtonForm_Update.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Update.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Update.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Update.Location = New System.Drawing.Point(300, 441)
            Me.ButtonForm_Update.Name = "ButtonForm_Update"
            Me.ButtonForm_Update.SecurityEnabled = True
            Me.ButtonForm_Update.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Update.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Update.TabIndex = 26
            Me.ButtonForm_Update.Text = "Update"
            '
            'ComboBoxForm_Product
            '
            Me.ComboBoxForm_Product.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Product.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_Product.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Product.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Product.AutoFindItemInDataSource = False
            Me.ComboBoxForm_Product.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Product.BookmarkingEnabled = False
            Me.ComboBoxForm_Product.ClientCode = ""
            Me.ComboBoxForm_Product.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Product
            Me.ComboBoxForm_Product.DisableMouseWheel = False
            Me.ComboBoxForm_Product.DisplayMember = "Name"
            Me.ComboBoxForm_Product.DisplayName = ""
            Me.ComboBoxForm_Product.DivisionCode = ""
            Me.ComboBoxForm_Product.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Product.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_Product.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_Product.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Product.FocusHighlightEnabled = True
            Me.ComboBoxForm_Product.FormattingEnabled = True
            Me.ComboBoxForm_Product.ItemHeight = 14
            Me.ComboBoxForm_Product.Location = New System.Drawing.Point(121, 88)
            Me.ComboBoxForm_Product.Name = "ComboBoxForm_Product"
            Me.ComboBoxForm_Product.ReadOnly = False
            Me.ComboBoxForm_Product.SecurityEnabled = True
            Me.ComboBoxForm_Product.Size = New System.Drawing.Size(335, 20)
            Me.ComboBoxForm_Product.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Product.TabIndex = 7
            Me.ComboBoxForm_Product.TabOnEnter = True
            Me.ComboBoxForm_Product.ValueMember = "Code"
            Me.ComboBoxForm_Product.WatermarkText = "Product"
            '
            'ComboBoxForm_Division
            '
            Me.ComboBoxForm_Division.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Division.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_Division.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Division.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Division.AutoFindItemInDataSource = False
            Me.ComboBoxForm_Division.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Division.BookmarkingEnabled = False
            Me.ComboBoxForm_Division.ClientCode = ""
            Me.ComboBoxForm_Division.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Division
            Me.ComboBoxForm_Division.DisableMouseWheel = False
            Me.ComboBoxForm_Division.DisplayMember = "Description"
            Me.ComboBoxForm_Division.DisplayName = ""
            Me.ComboBoxForm_Division.DivisionCode = ""
            Me.ComboBoxForm_Division.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Division.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_Division.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_Division.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Division.FocusHighlightEnabled = True
            Me.ComboBoxForm_Division.FormattingEnabled = True
            Me.ComboBoxForm_Division.ItemHeight = 14
            Me.ComboBoxForm_Division.Location = New System.Drawing.Point(121, 63)
            Me.ComboBoxForm_Division.Name = "ComboBoxForm_Division"
            Me.ComboBoxForm_Division.ReadOnly = False
            Me.ComboBoxForm_Division.SecurityEnabled = True
            Me.ComboBoxForm_Division.Size = New System.Drawing.Size(335, 20)
            Me.ComboBoxForm_Division.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Division.TabIndex = 5
            Me.ComboBoxForm_Division.TabOnEnter = True
            Me.ComboBoxForm_Division.ValueMember = "Code"
            Me.ComboBoxForm_Division.WatermarkText = "Division"
            '
            'ComboBoxForm_Client
            '
            Me.ComboBoxForm_Client.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Client.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_Client.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Client.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Client.AutoFindItemInDataSource = False
            Me.ComboBoxForm_Client.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Client.BookmarkingEnabled = False
            Me.ComboBoxForm_Client.ClientCode = ""
            Me.ComboBoxForm_Client.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Client
            Me.ComboBoxForm_Client.DisableMouseWheel = False
            Me.ComboBoxForm_Client.DisplayMember = "Name"
            Me.ComboBoxForm_Client.DisplayName = ""
            Me.ComboBoxForm_Client.DivisionCode = ""
            Me.ComboBoxForm_Client.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Client.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_Client.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_Client.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Client.FocusHighlightEnabled = True
            Me.ComboBoxForm_Client.FormattingEnabled = True
            Me.ComboBoxForm_Client.ItemHeight = 14
            Me.ComboBoxForm_Client.Location = New System.Drawing.Point(121, 38)
            Me.ComboBoxForm_Client.Name = "ComboBoxForm_Client"
            Me.ComboBoxForm_Client.ReadOnly = False
            Me.ComboBoxForm_Client.SecurityEnabled = True
            Me.ComboBoxForm_Client.Size = New System.Drawing.Size(335, 20)
            Me.ComboBoxForm_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Client.TabIndex = 3
            Me.ComboBoxForm_Client.TabOnEnter = True
            Me.ComboBoxForm_Client.ValueMember = "Code"
            Me.ComboBoxForm_Client.WatermarkText = "Select Client"
            '
            'LabelForm_Product
            '
            Me.LabelForm_Product.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Product.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Product.Location = New System.Drawing.Point(12, 88)
            Me.LabelForm_Product.Name = "LabelForm_Product"
            Me.LabelForm_Product.Size = New System.Drawing.Size(103, 20)
            Me.LabelForm_Product.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Product.TabIndex = 6
            Me.LabelForm_Product.Text = "Product:"
            '
            'LabelForm_Division
            '
            Me.LabelForm_Division.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Division.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Division.Location = New System.Drawing.Point(12, 63)
            Me.LabelForm_Division.Name = "LabelForm_Division"
            Me.LabelForm_Division.Size = New System.Drawing.Size(103, 20)
            Me.LabelForm_Division.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Division.TabIndex = 4
            Me.LabelForm_Division.Text = "Division:"
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
            Me.LabelForm_Client.Size = New System.Drawing.Size(103, 20)
            Me.LabelForm_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Client.TabIndex = 2
            Me.LabelForm_Client.Text = "Client:"
            '
            'LabelForm_EndDate
            '
            Me.LabelForm_EndDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_EndDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_EndDate.Location = New System.Drawing.Point(12, 166)
            Me.LabelForm_EndDate.Name = "LabelForm_EndDate"
            Me.LabelForm_EndDate.Size = New System.Drawing.Size(103, 20)
            Me.LabelForm_EndDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_EndDate.TabIndex = 13
            Me.LabelForm_EndDate.Text = "End Date:"
            '
            'LabelForm_StartDate
            '
            Me.LabelForm_StartDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_StartDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_StartDate.Location = New System.Drawing.Point(12, 140)
            Me.LabelForm_StartDate.Name = "LabelForm_StartDate"
            Me.LabelForm_StartDate.Size = New System.Drawing.Size(103, 20)
            Me.LabelForm_StartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_StartDate.TabIndex = 10
            Me.LabelForm_StartDate.Text = "Start Date:"
            '
            'NumericInputForm_GrossBudgetAmount
            '
            Me.NumericInputForm_GrossBudgetAmount.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputForm_GrossBudgetAmount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.Currency
            Me.NumericInputForm_GrossBudgetAmount.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputForm_GrossBudgetAmount.EnterMoveNextControl = True
            Me.NumericInputForm_GrossBudgetAmount.Location = New System.Drawing.Point(121, 218)
            Me.NumericInputForm_GrossBudgetAmount.Name = "NumericInputForm_GrossBudgetAmount"
            Me.NumericInputForm_GrossBudgetAmount.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputForm_GrossBudgetAmount.Properties.DisplayFormat.FormatString = "c2"
            Me.NumericInputForm_GrossBudgetAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_GrossBudgetAmount.Properties.EditFormat.FormatString = "c2"
            Me.NumericInputForm_GrossBudgetAmount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_GrossBudgetAmount.Properties.IsFloatValue = False
            Me.NumericInputForm_GrossBudgetAmount.Properties.Mask.EditMask = "c2"
            Me.NumericInputForm_GrossBudgetAmount.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputForm_GrossBudgetAmount.SecurityEnabled = True
            Me.NumericInputForm_GrossBudgetAmount.Size = New System.Drawing.Size(124, 20)
            Me.NumericInputForm_GrossBudgetAmount.TabIndex = 18
            '
            'LabelForm_GrossBudgetAmount
            '
            Me.LabelForm_GrossBudgetAmount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_GrossBudgetAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_GrossBudgetAmount.Location = New System.Drawing.Point(12, 218)
            Me.LabelForm_GrossBudgetAmount.Name = "LabelForm_GrossBudgetAmount"
            Me.LabelForm_GrossBudgetAmount.Size = New System.Drawing.Size(103, 20)
            Me.LabelForm_GrossBudgetAmount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_GrossBudgetAmount.TabIndex = 17
            Me.LabelForm_GrossBudgetAmount.Text = "Budget Amount:"
            '
            'LabelForm_Comment
            '
            Me.LabelForm_Comment.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Comment.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Comment.Location = New System.Drawing.Point(12, 296)
            Me.LabelForm_Comment.Name = "LabelForm_Comment"
            Me.LabelForm_Comment.Size = New System.Drawing.Size(103, 20)
            Me.LabelForm_Comment.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Comment.TabIndex = 23
            Me.LabelForm_Comment.Text = "Comment:"
            '
            'TextBoxForm_Comment
            '
            Me.TextBoxForm_Comment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxForm_Comment.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Comment.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Comment.CheckSpellingOnValidate = False
            Me.TextBoxForm_Comment.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Comment.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxForm_Comment.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Comment.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Comment.FocusHighlightEnabled = True
            Me.TextBoxForm_Comment.Location = New System.Drawing.Point(121, 296)
            Me.TextBoxForm_Comment.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Comment.Multiline = True
            Me.TextBoxForm_Comment.Name = "TextBoxForm_Comment"
            Me.TextBoxForm_Comment.SecurityEnabled = True
            Me.TextBoxForm_Comment.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Comment.Size = New System.Drawing.Size(335, 139)
            Me.TextBoxForm_Comment.StartingFolderName = Nothing
            Me.TextBoxForm_Comment.TabIndex = 24
            Me.TextBoxForm_Comment.TabOnEnter = False
            '
            'CheckBoxForm_SyncEstimateSettings
            '
            '
            '
            '
            Me.CheckBoxForm_SyncEstimateSettings.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_SyncEstimateSettings.CheckValue = 0
            Me.CheckBoxForm_SyncEstimateSettings.CheckValueChecked = 1
            Me.CheckBoxForm_SyncEstimateSettings.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_SyncEstimateSettings.CheckValueUnchecked = 0
            Me.CheckBoxForm_SyncEstimateSettings.ChildControls = CType(resources.GetObject("CheckBoxForm_SyncEstimateSettings.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_SyncEstimateSettings.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_SyncEstimateSettings.Location = New System.Drawing.Point(121, 270)
            Me.CheckBoxForm_SyncEstimateSettings.Name = "CheckBoxForm_SyncEstimateSettings"
            Me.CheckBoxForm_SyncEstimateSettings.OldestSibling = Nothing
            Me.CheckBoxForm_SyncEstimateSettings.SecurityEnabled = True
            Me.CheckBoxForm_SyncEstimateSettings.SiblingControls = CType(resources.GetObject("CheckBoxForm_SyncEstimateSettings.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_SyncEstimateSettings.Size = New System.Drawing.Size(149, 20)
            Me.CheckBoxForm_SyncEstimateSettings.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_SyncEstimateSettings.TabIndex = 21
            Me.CheckBoxForm_SyncEstimateSettings.TabOnEnter = True
            Me.CheckBoxForm_SyncEstimateSettings.Text = "Sync Estimate Settings"
            '
            'CheckBoxForm_IsInactive
            '
            Me.CheckBoxForm_IsInactive.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxForm_IsInactive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_IsInactive.CheckValue = 0
            Me.CheckBoxForm_IsInactive.CheckValueChecked = 1
            Me.CheckBoxForm_IsInactive.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_IsInactive.CheckValueUnchecked = 0
            Me.CheckBoxForm_IsInactive.ChildControls = CType(resources.GetObject("CheckBoxForm_IsInactive.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_IsInactive.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_IsInactive.Location = New System.Drawing.Point(121, 441)
            Me.CheckBoxForm_IsInactive.Name = "CheckBoxForm_IsInactive"
            Me.CheckBoxForm_IsInactive.OldestSibling = Nothing
            Me.CheckBoxForm_IsInactive.SecurityEnabled = True
            Me.CheckBoxForm_IsInactive.SiblingControls = CType(resources.GetObject("CheckBoxForm_IsInactive.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_IsInactive.Size = New System.Drawing.Size(173, 20)
            Me.CheckBoxForm_IsInactive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_IsInactive.TabIndex = 25
            Me.CheckBoxForm_IsInactive.TabOnEnter = True
            Me.CheckBoxForm_IsInactive.Text = "Inactive"
            '
            'DateEditForm_EndDate
            '
            Me.DateEditForm_EndDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateEdit.Type.[Default]
            Me.DateEditForm_EndDate.DisplayName = ""
            Me.DateEditForm_EndDate.EditValue = Nothing
            Me.DateEditForm_EndDate.Location = New System.Drawing.Point(121, 166)
            Me.DateEditForm_EndDate.Name = "DateEditForm_EndDate"
            Me.DateEditForm_EndDate.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.[False]
            Me.DateEditForm_EndDate.Properties.AllowMouseWheel = False
            Me.DateEditForm_EndDate.Properties.Appearance.BackColor = System.Drawing.Color.White
            Me.DateEditForm_EndDate.Properties.Appearance.Options.UseBackColor = True
            Me.DateEditForm_EndDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.DateEditForm_EndDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.DateEditForm_EndDate.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista
            Me.DateEditForm_EndDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
            Me.DateEditForm_EndDate.Properties.MaxValue = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateEditForm_EndDate.Properties.MinValue = New Date(1900, 1, 1, 0, 0, 0, 0)
            Me.DateEditForm_EndDate.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[True]
            Me.DateEditForm_EndDate.SecurityEnabled = True
            Me.DateEditForm_EndDate.Size = New System.Drawing.Size(124, 20)
            Me.DateEditForm_EndDate.TabIndex = 14
            Me.DateEditForm_EndDate.TabOnEnter = True
            Me.DateEditForm_EndDate.Tag = "9/2/2015"
            '
            'DateEditForm_StartDate
            '
            Me.DateEditForm_StartDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateEdit.Type.[Default]
            Me.DateEditForm_StartDate.DisplayName = ""
            Me.DateEditForm_StartDate.EditValue = Nothing
            Me.DateEditForm_StartDate.Location = New System.Drawing.Point(121, 140)
            Me.DateEditForm_StartDate.Name = "DateEditForm_StartDate"
            Me.DateEditForm_StartDate.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.[False]
            Me.DateEditForm_StartDate.Properties.AllowMouseWheel = False
            Me.DateEditForm_StartDate.Properties.Appearance.BackColor = System.Drawing.Color.White
            Me.DateEditForm_StartDate.Properties.Appearance.Options.UseBackColor = True
            Me.DateEditForm_StartDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.DateEditForm_StartDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.DateEditForm_StartDate.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista
            Me.DateEditForm_StartDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
            Me.DateEditForm_StartDate.Properties.MaxValue = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateEditForm_StartDate.Properties.MinValue = New Date(1900, 1, 1, 0, 0, 0, 0)
            Me.DateEditForm_StartDate.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[True]
            Me.DateEditForm_StartDate.SecurityEnabled = True
            Me.DateEditForm_StartDate.Size = New System.Drawing.Size(124, 20)
            Me.DateEditForm_StartDate.TabIndex = 11
            Me.DateEditForm_StartDate.TabOnEnter = True
            Me.DateEditForm_StartDate.Tag = "9/2/2015"
            '
            'CheckBoxForm_SyncFieldWidths
            '
            Me.CheckBoxForm_SyncFieldWidths.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxForm_SyncFieldWidths.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_SyncFieldWidths.CheckValue = 0
            Me.CheckBoxForm_SyncFieldWidths.CheckValueChecked = 1
            Me.CheckBoxForm_SyncFieldWidths.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_SyncFieldWidths.CheckValueUnchecked = 0
            Me.CheckBoxForm_SyncFieldWidths.ChildControls = CType(resources.GetObject("CheckBoxForm_SyncFieldWidths.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_SyncFieldWidths.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_SyncFieldWidths.Location = New System.Drawing.Point(276, 270)
            Me.CheckBoxForm_SyncFieldWidths.Name = "CheckBoxForm_SyncFieldWidths"
            Me.CheckBoxForm_SyncFieldWidths.OldestSibling = Nothing
            Me.CheckBoxForm_SyncFieldWidths.SecurityEnabled = True
            Me.CheckBoxForm_SyncFieldWidths.SiblingControls = CType(resources.GetObject("CheckBoxForm_SyncFieldWidths.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_SyncFieldWidths.Size = New System.Drawing.Size(180, 20)
            Me.CheckBoxForm_SyncFieldWidths.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_SyncFieldWidths.TabIndex = 22
            Me.CheckBoxForm_SyncFieldWidths.TabOnEnter = True
            Me.CheckBoxForm_SyncFieldWidths.Text = "Sync Field Widths"
            '
            'CheckBoxForm_IsTemplate
            '
            Me.CheckBoxForm_IsTemplate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxForm_IsTemplate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_IsTemplate.CheckValue = 0
            Me.CheckBoxForm_IsTemplate.CheckValueChecked = 1
            Me.CheckBoxForm_IsTemplate.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_IsTemplate.CheckValueUnchecked = 0
            Me.CheckBoxForm_IsTemplate.ChildControls = CType(resources.GetObject("CheckBoxForm_IsTemplate.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_IsTemplate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_IsTemplate.Location = New System.Drawing.Point(251, 140)
            Me.CheckBoxForm_IsTemplate.Name = "CheckBoxForm_IsTemplate"
            Me.CheckBoxForm_IsTemplate.OldestSibling = Nothing
            Me.CheckBoxForm_IsTemplate.SecurityEnabled = True
            Me.CheckBoxForm_IsTemplate.SiblingControls = CType(resources.GetObject("CheckBoxForm_IsTemplate.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_IsTemplate.Size = New System.Drawing.Size(205, 20)
            Me.CheckBoxForm_IsTemplate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_IsTemplate.TabIndex = 12
            Me.CheckBoxForm_IsTemplate.TabOnEnter = True
            Me.CheckBoxForm_IsTemplate.Text = "Is Template"
            '
            'ComboBoxForm_Campaign
            '
            Me.ComboBoxForm_Campaign.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Campaign.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_Campaign.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Campaign.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Campaign.AutoFindItemInDataSource = False
            Me.ComboBoxForm_Campaign.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Campaign.BookmarkingEnabled = False
            Me.ComboBoxForm_Campaign.ClientCode = ""
            Me.ComboBoxForm_Campaign.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Campaign
            Me.ComboBoxForm_Campaign.DisableMouseWheel = False
            Me.ComboBoxForm_Campaign.DisplayMember = "Name"
            Me.ComboBoxForm_Campaign.DisplayName = ""
            Me.ComboBoxForm_Campaign.DivisionCode = ""
            Me.ComboBoxForm_Campaign.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Campaign.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_Campaign.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_Campaign.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Campaign.FocusHighlightEnabled = True
            Me.ComboBoxForm_Campaign.FormattingEnabled = True
            Me.ComboBoxForm_Campaign.ItemHeight = 14
            Me.ComboBoxForm_Campaign.Location = New System.Drawing.Point(121, 192)
            Me.ComboBoxForm_Campaign.Name = "ComboBoxForm_Campaign"
            Me.ComboBoxForm_Campaign.ReadOnly = False
            Me.ComboBoxForm_Campaign.SecurityEnabled = True
            Me.ComboBoxForm_Campaign.Size = New System.Drawing.Size(335, 20)
            Me.ComboBoxForm_Campaign.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Campaign.TabIndex = 16
            Me.ComboBoxForm_Campaign.TabOnEnter = True
            Me.ComboBoxForm_Campaign.ValueMember = "Code"
            Me.ComboBoxForm_Campaign.WatermarkText = "Select Campaign"
            '
            'LabelForm_Campaign
            '
            Me.LabelForm_Campaign.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Campaign.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Campaign.Location = New System.Drawing.Point(12, 192)
            Me.LabelForm_Campaign.Name = "LabelForm_Campaign"
            Me.LabelForm_Campaign.Size = New System.Drawing.Size(103, 20)
            Me.LabelForm_Campaign.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Campaign.TabIndex = 15
            Me.LabelForm_Campaign.Text = "Campaign:"
            '
            'LabelForm_Country
            '
            Me.LabelForm_Country.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Country.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Country.Location = New System.Drawing.Point(12, 244)
            Me.LabelForm_Country.Name = "LabelForm_Country"
            Me.LabelForm_Country.Size = New System.Drawing.Size(103, 20)
            Me.LabelForm_Country.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Country.TabIndex = 19
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
            Me.ComboBoxForm_Country.ClientCode = ""
            Me.ComboBoxForm_Country.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Country
            Me.ComboBoxForm_Country.DisableMouseWheel = False
            Me.ComboBoxForm_Country.DisplayMember = "Name"
            Me.ComboBoxForm_Country.DisplayName = ""
            Me.ComboBoxForm_Country.DivisionCode = ""
            Me.ComboBoxForm_Country.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Country.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_Country.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_Country.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Country.FocusHighlightEnabled = True
            Me.ComboBoxForm_Country.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxForm_Country.FormattingEnabled = True
            Me.ComboBoxForm_Country.ItemHeight = 14
            Me.ComboBoxForm_Country.Location = New System.Drawing.Point(121, 244)
            Me.ComboBoxForm_Country.Name = "ComboBoxForm_Country"
            Me.ComboBoxForm_Country.ReadOnly = False
            Me.ComboBoxForm_Country.SecurityEnabled = True
            Me.ComboBoxForm_Country.Size = New System.Drawing.Size(335, 20)
            Me.ComboBoxForm_Country.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Country.TabIndex = 20
            Me.ComboBoxForm_Country.TabOnEnter = True
            Me.ComboBoxForm_Country.ValueMember = "ID"
            Me.ComboBoxForm_Country.WatermarkText = "Select Country"
            '
            'MediaPlanUpdateDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(468, 473)
            Me.Controls.Add(Me.LabelForm_Country)
            Me.Controls.Add(Me.ComboBoxForm_Country)
            Me.Controls.Add(Me.ComboBoxForm_Campaign)
            Me.Controls.Add(Me.LabelForm_Campaign)
            Me.Controls.Add(Me.CheckBoxForm_IsTemplate)
            Me.Controls.Add(Me.CheckBoxForm_SyncFieldWidths)
            Me.Controls.Add(Me.DateEditForm_EndDate)
            Me.Controls.Add(Me.DateEditForm_StartDate)
            Me.Controls.Add(Me.CheckBoxForm_IsInactive)
            Me.Controls.Add(Me.CheckBoxForm_SyncEstimateSettings)
            Me.Controls.Add(Me.TextBoxForm_Comment)
            Me.Controls.Add(Me.LabelForm_Comment)
            Me.Controls.Add(Me.LabelForm_GrossBudgetAmount)
            Me.Controls.Add(Me.NumericInputForm_GrossBudgetAmount)
            Me.Controls.Add(Me.LabelForm_EndDate)
            Me.Controls.Add(Me.LabelForm_StartDate)
            Me.Controls.Add(Me.ComboBoxForm_Product)
            Me.Controls.Add(Me.ComboBoxForm_Division)
            Me.Controls.Add(Me.ComboBoxForm_Client)
            Me.Controls.Add(Me.LabelForm_Product)
            Me.Controls.Add(Me.LabelForm_Division)
            Me.Controls.Add(Me.LabelForm_Client)
            Me.Controls.Add(Me.ComboBoxForm_ClientContact)
            Me.Controls.Add(Me.TextBoxForm_Description)
            Me.Controls.Add(Me.LabelForm_Description)
            Me.Controls.Add(Me.LabelForm_ClientContact)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.ButtonForm_Update)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaPlanUpdateDialog"
            Me.Text = "Update Media Plan"
            CType(Me.NumericInputForm_GrossBudgetAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateEditForm_EndDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateEditForm_EndDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateEditForm_StartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateEditForm_StartDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ComboBoxForm_ClientContact As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents TextBoxForm_Description As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_Description As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_ClientContact As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Update As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ComboBoxForm_Product As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxForm_Division As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxForm_Client As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_Product As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Division As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Client As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_EndDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_StartDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents NumericInputForm_GrossBudgetAmount As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents LabelForm_GrossBudgetAmount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Comment As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_Comment As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents CheckBoxForm_SyncEstimateSettings As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_IsInactive As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents DateEditForm_EndDate As AdvantageFramework.WinForm.Presentation.Controls.DateEdit
        Friend WithEvents DateEditForm_StartDate As AdvantageFramework.WinForm.Presentation.Controls.DateEdit
        Friend WithEvents CheckBoxForm_SyncFieldWidths As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_IsTemplate As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents ComboBoxForm_Campaign As WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_Campaign As WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Country As WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_Country As WinForm.Presentation.Controls.ComboBox
    End Class

End Namespace
