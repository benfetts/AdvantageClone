Namespace ProjectManagement.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class CampaignEditDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CampaignEditDialog))
            Me.ButtonForm_Add = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Update = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_Office = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_CampaignType = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_Client = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxForm_Product = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxForm_Division = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_Product = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Division = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Client = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_Office = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_Name = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_Name = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_Code = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_Code = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.ComboBoxForm_AlertGroup = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_AlertGroup = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.RadioButtonForm_AssignedToJobsAndOrders = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonForm_Overall = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.SuspendLayout()
            '
            'ButtonForm_Add
            '
            Me.ButtonForm_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Add.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Add.Location = New System.Drawing.Point(378, 220)
            Me.ButtonForm_Add.Name = "ButtonForm_Add"
            Me.ButtonForm_Add.SecurityEnabled = True
            Me.ButtonForm_Add.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Add.TabIndex = 18
            Me.ButtonForm_Add.Text = "Add"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(459, 220)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 19
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ButtonForm_Update
            '
            Me.ButtonForm_Update.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Update.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Update.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Update.Location = New System.Drawing.Point(378, 220)
            Me.ButtonForm_Update.Name = "ButtonForm_Update"
            Me.ButtonForm_Update.SecurityEnabled = True
            Me.ButtonForm_Update.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Update.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Update.TabIndex = 17
            Me.ButtonForm_Update.Text = "Update"
            '
            'LabelForm_Office
            '
            Me.LabelForm_Office.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Office.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Office.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_Office.Name = "LabelForm_Office"
            Me.LabelForm_Office.Size = New System.Drawing.Size(87, 20)
            Me.LabelForm_Office.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Office.TabIndex = 0
            Me.LabelForm_Office.Text = "Office:"
            '
            'LabelForm_CampaignType
            '
            Me.LabelForm_CampaignType.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_CampaignType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_CampaignType.Location = New System.Drawing.Point(12, 168)
            Me.LabelForm_CampaignType.Name = "LabelForm_CampaignType"
            Me.LabelForm_CampaignType.Size = New System.Drawing.Size(87, 20)
            Me.LabelForm_CampaignType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_CampaignType.TabIndex = 14
            Me.LabelForm_CampaignType.Text = "Campaign Type:"
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
            Me.ComboBoxForm_Client.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Client
            Me.ComboBoxForm_Client.DisableMouseWheel = False
            Me.ComboBoxForm_Client.DisplayMember = "Name"
            Me.ComboBoxForm_Client.DisplayName = ""
            Me.ComboBoxForm_Client.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Client.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_Client.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_Client.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Client.FocusHighlightEnabled = True
            Me.ComboBoxForm_Client.FormattingEnabled = True
            Me.ComboBoxForm_Client.ItemHeight = 14
            Me.ComboBoxForm_Client.Location = New System.Drawing.Point(105, 38)
            Me.ComboBoxForm_Client.Name = "ComboBoxForm_Client"
            Me.ComboBoxForm_Client.PreventEnterBeep = False
            Me.ComboBoxForm_Client.ReadOnly = False
            Me.ComboBoxForm_Client.Size = New System.Drawing.Size(429, 20)
            Me.ComboBoxForm_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Client.TabIndex = 3
            Me.ComboBoxForm_Client.ValueMember = "Code"
            Me.ComboBoxForm_Client.WatermarkText = "Select Client"
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
            Me.ComboBoxForm_Product.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Product
            Me.ComboBoxForm_Product.DisableMouseWheel = False
            Me.ComboBoxForm_Product.DisplayMember = "Name"
            Me.ComboBoxForm_Product.DisplayName = ""
            Me.ComboBoxForm_Product.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Product.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_Product.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_Product.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Product.FocusHighlightEnabled = True
            Me.ComboBoxForm_Product.FormattingEnabled = True
            Me.ComboBoxForm_Product.ItemHeight = 14
            Me.ComboBoxForm_Product.Location = New System.Drawing.Point(105, 90)
            Me.ComboBoxForm_Product.Name = "ComboBoxForm_Product"
            Me.ComboBoxForm_Product.PreventEnterBeep = False
            Me.ComboBoxForm_Product.ReadOnly = False
            Me.ComboBoxForm_Product.Size = New System.Drawing.Size(429, 20)
            Me.ComboBoxForm_Product.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Product.TabIndex = 7
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
            Me.ComboBoxForm_Division.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Division
            Me.ComboBoxForm_Division.DisableMouseWheel = False
            Me.ComboBoxForm_Division.DisplayMember = "Description"
            Me.ComboBoxForm_Division.DisplayName = ""
            Me.ComboBoxForm_Division.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Division.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_Division.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_Division.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Division.FocusHighlightEnabled = True
            Me.ComboBoxForm_Division.FormattingEnabled = True
            Me.ComboBoxForm_Division.ItemHeight = 14
            Me.ComboBoxForm_Division.Location = New System.Drawing.Point(105, 64)
            Me.ComboBoxForm_Division.Name = "ComboBoxForm_Division"
            Me.ComboBoxForm_Division.PreventEnterBeep = False
            Me.ComboBoxForm_Division.ReadOnly = False
            Me.ComboBoxForm_Division.Size = New System.Drawing.Size(429, 20)
            Me.ComboBoxForm_Division.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Division.TabIndex = 5
            Me.ComboBoxForm_Division.ValueMember = "Code"
            Me.ComboBoxForm_Division.WatermarkText = "Division"
            '
            'LabelForm_Product
            '
            Me.LabelForm_Product.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Product.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Product.Location = New System.Drawing.Point(12, 90)
            Me.LabelForm_Product.Name = "LabelForm_Product"
            Me.LabelForm_Product.Size = New System.Drawing.Size(87, 20)
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
            Me.LabelForm_Division.Location = New System.Drawing.Point(12, 64)
            Me.LabelForm_Division.Name = "LabelForm_Division"
            Me.LabelForm_Division.Size = New System.Drawing.Size(87, 20)
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
            Me.LabelForm_Client.Size = New System.Drawing.Size(87, 20)
            Me.LabelForm_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Client.TabIndex = 2
            Me.LabelForm_Client.Text = "Client:"
            '
            'ComboBoxForm_Office
            '
            Me.ComboBoxForm_Office.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Office.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_Office.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Office.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Office.AutoFindItemInDataSource = False
            Me.ComboBoxForm_Office.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Office.BookmarkingEnabled = False
            Me.ComboBoxForm_Office.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Office
            Me.ComboBoxForm_Office.DisableMouseWheel = False
            Me.ComboBoxForm_Office.DisplayMember = "Name"
            Me.ComboBoxForm_Office.DisplayName = ""
            Me.ComboBoxForm_Office.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Office.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_Office.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_Office.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Office.FocusHighlightEnabled = True
            Me.ComboBoxForm_Office.FormattingEnabled = True
            Me.ComboBoxForm_Office.ItemHeight = 14
            Me.ComboBoxForm_Office.Location = New System.Drawing.Point(105, 12)
            Me.ComboBoxForm_Office.Name = "ComboBoxForm_Office"
            Me.ComboBoxForm_Office.PreventEnterBeep = False
            Me.ComboBoxForm_Office.ReadOnly = False
            Me.ComboBoxForm_Office.Size = New System.Drawing.Size(429, 20)
            Me.ComboBoxForm_Office.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Office.TabIndex = 1
            Me.ComboBoxForm_Office.ValueMember = "Code"
            Me.ComboBoxForm_Office.WatermarkText = "Select Office"
            '
            'LabelForm_Name
            '
            Me.LabelForm_Name.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Name.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Name.Location = New System.Drawing.Point(201, 116)
            Me.LabelForm_Name.Name = "LabelForm_Name"
            Me.LabelForm_Name.Size = New System.Drawing.Size(35, 20)
            Me.LabelForm_Name.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Name.TabIndex = 10
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
            Me.TextBoxForm_Name.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_Name.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Name.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Name.FocusHighlightEnabled = True
            Me.TextBoxForm_Name.Location = New System.Drawing.Point(242, 116)
            Me.TextBoxForm_Name.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Name.Name = "TextBoxForm_Name"
            Me.TextBoxForm_Name.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Name.Size = New System.Drawing.Size(292, 20)
            Me.TextBoxForm_Name.TabIndex = 11
            Me.TextBoxForm_Name.TabOnEnter = True
            '
            'LabelForm_Code
            '
            Me.LabelForm_Code.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Code.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Code.Location = New System.Drawing.Point(12, 116)
            Me.LabelForm_Code.Name = "LabelForm_Code"
            Me.LabelForm_Code.Size = New System.Drawing.Size(87, 20)
            Me.LabelForm_Code.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Code.TabIndex = 8
            Me.LabelForm_Code.Text = "Code:"
            '
            'TextBoxForm_Code
            '
            '
            '
            '
            Me.TextBoxForm_Code.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Code.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Code.CheckSpellingOnValidate = False
            Me.TextBoxForm_Code.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Code.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_Code.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Code.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Code.FocusHighlightEnabled = True
            Me.TextBoxForm_Code.Location = New System.Drawing.Point(105, 116)
            Me.TextBoxForm_Code.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Code.Name = "TextBoxForm_Code"
            Me.TextBoxForm_Code.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Code.Size = New System.Drawing.Size(90, 20)
            Me.TextBoxForm_Code.TabIndex = 9
            Me.TextBoxForm_Code.TabOnEnter = True
            '
            'ComboBoxForm_AlertGroup
            '
            Me.ComboBoxForm_AlertGroup.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_AlertGroup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_AlertGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_AlertGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_AlertGroup.AutoFindItemInDataSource = False
            Me.ComboBoxForm_AlertGroup.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_AlertGroup.BookmarkingEnabled = False
            Me.ComboBoxForm_AlertGroup.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.AlertGroup
            Me.ComboBoxForm_AlertGroup.DisableMouseWheel = False
            Me.ComboBoxForm_AlertGroup.DisplayMember = "Description"
            Me.ComboBoxForm_AlertGroup.DisplayName = ""
            Me.ComboBoxForm_AlertGroup.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_AlertGroup.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_AlertGroup.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_AlertGroup.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_AlertGroup.FocusHighlightEnabled = True
            Me.ComboBoxForm_AlertGroup.FormattingEnabled = True
            Me.ComboBoxForm_AlertGroup.ItemHeight = 14
            Me.ComboBoxForm_AlertGroup.Location = New System.Drawing.Point(105, 142)
            Me.ComboBoxForm_AlertGroup.Name = "ComboBoxForm_AlertGroup"
            Me.ComboBoxForm_AlertGroup.PreventEnterBeep = False
            Me.ComboBoxForm_AlertGroup.ReadOnly = False
            Me.ComboBoxForm_AlertGroup.Size = New System.Drawing.Size(429, 20)
            Me.ComboBoxForm_AlertGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_AlertGroup.TabIndex = 13
            Me.ComboBoxForm_AlertGroup.ValueMember = "Code"
            Me.ComboBoxForm_AlertGroup.WatermarkText = "Select Alert Group"
            '
            'LabelForm_AlertGroup
            '
            Me.LabelForm_AlertGroup.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_AlertGroup.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_AlertGroup.Location = New System.Drawing.Point(12, 142)
            Me.LabelForm_AlertGroup.Name = "LabelForm_AlertGroup"
            Me.LabelForm_AlertGroup.Size = New System.Drawing.Size(87, 20)
            Me.LabelForm_AlertGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_AlertGroup.TabIndex = 12
            Me.LabelForm_AlertGroup.Text = "Alert Group:"
            '
            'RadioButtonForm_AssignedToJobsAndOrders
            '
            Me.RadioButtonForm_AssignedToJobsAndOrders.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.RadioButtonForm_AssignedToJobsAndOrders.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonForm_AssignedToJobsAndOrders.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonForm_AssignedToJobsAndOrders.Checked = True
            Me.RadioButtonForm_AssignedToJobsAndOrders.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonForm_AssignedToJobsAndOrders.CheckValue = "Y"
            Me.RadioButtonForm_AssignedToJobsAndOrders.Location = New System.Drawing.Point(105, 168)
            Me.RadioButtonForm_AssignedToJobsAndOrders.Name = "RadioButtonForm_AssignedToJobsAndOrders"
            Me.RadioButtonForm_AssignedToJobsAndOrders.Size = New System.Drawing.Size(429, 20)
            Me.RadioButtonForm_AssignedToJobsAndOrders.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonForm_AssignedToJobsAndOrders.TabIndex = 15
            Me.RadioButtonForm_AssignedToJobsAndOrders.Text = "Assigned to Jobs and Orders"
            '
            'RadioButtonForm_Overall
            '
            Me.RadioButtonForm_Overall.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.RadioButtonForm_Overall.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonForm_Overall.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonForm_Overall.Location = New System.Drawing.Point(105, 194)
            Me.RadioButtonForm_Overall.Name = "RadioButtonForm_Overall"
            Me.RadioButtonForm_Overall.Size = New System.Drawing.Size(429, 20)
            Me.RadioButtonForm_Overall.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonForm_Overall.TabIndex = 16
            Me.RadioButtonForm_Overall.TabStop = False
            Me.RadioButtonForm_Overall.Text = "Overall"
            '
            'CampaignEditDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(546, 252)
            Me.Controls.Add(Me.RadioButtonForm_Overall)
            Me.Controls.Add(Me.RadioButtonForm_AssignedToJobsAndOrders)
            Me.Controls.Add(Me.ComboBoxForm_AlertGroup)
            Me.Controls.Add(Me.LabelForm_AlertGroup)
            Me.Controls.Add(Me.LabelForm_Name)
            Me.Controls.Add(Me.TextBoxForm_Name)
            Me.Controls.Add(Me.LabelForm_Code)
            Me.Controls.Add(Me.TextBoxForm_Code)
            Me.Controls.Add(Me.ComboBoxForm_Office)
            Me.Controls.Add(Me.ComboBoxForm_Client)
            Me.Controls.Add(Me.ComboBoxForm_Product)
            Me.Controls.Add(Me.ComboBoxForm_Division)
            Me.Controls.Add(Me.LabelForm_Product)
            Me.Controls.Add(Me.LabelForm_Division)
            Me.Controls.Add(Me.LabelForm_Client)
            Me.Controls.Add(Me.LabelForm_CampaignType)
            Me.Controls.Add(Me.LabelForm_Office)
            Me.Controls.Add(Me.ButtonForm_Update)
            Me.Controls.Add(Me.ButtonForm_Add)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.DoubleBuffered = True
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "CampaignEditDialog"
            Me.Text = "Campaign"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Add As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Update As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_Office As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_CampaignType As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_Client As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxForm_Product As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxForm_Division As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_Product As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Division As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Client As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_Office As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_Name As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_Name As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_Code As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_Code As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents ComboBoxForm_AlertGroup As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_AlertGroup As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents RadioButtonForm_AssignedToJobsAndOrders As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonForm_Overall As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
    End Class

End Namespace