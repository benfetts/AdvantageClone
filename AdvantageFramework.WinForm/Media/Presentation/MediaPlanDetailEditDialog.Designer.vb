Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaPlanDetailEditDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaPlanDetailEditDialog))
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Add = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ComboBoxForm_SalesClass = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxForm_MediaType = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_SalesClass = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_MediaType = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Color = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxForm_Comment = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.TextBoxComment_Comment = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.ColorPickerForm_Color = New DevComponents.DotNetBar.ColorPickerButton()
            Me.ButtonForm_Update = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ComboBoxForm_Campaign = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_Campaign = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Name = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_Name = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_EstimateIDData = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_EstimateID = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Buyer = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxForm_Buyer = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewForm_Buyer = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelForm_GrossBudgetAmount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.NumericInputForm_GrossBudgetAmount = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.CheckBoxForm_IsCable = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_AllowCampaignLevel = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelForm_PeriodType = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_PeriodType = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_EstimateTemplate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBox_EstimateTemplate = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView1 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxForm_Demo = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewForm_Demo = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelForm_Demo = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxForm_Auto = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.SuperTooltip = New DevComponents.DotNetBar.SuperTooltip()
            CType(Me.GroupBoxForm_Comment, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxForm_Comment.SuspendLayout()
            CType(Me.SearchableComboBoxForm_Buyer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewForm_Buyer, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputForm_GrossBudgetAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBox_EstimateTemplate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxForm_Demo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewForm_Demo, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(370, 541)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 29
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ButtonForm_Add
            '
            Me.ButtonForm_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Add.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Add.Location = New System.Drawing.Point(289, 541)
            Me.ButtonForm_Add.Name = "ButtonForm_Add"
            Me.ButtonForm_Add.SecurityEnabled = True
            Me.ButtonForm_Add.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Add.TabIndex = 27
            Me.ButtonForm_Add.Text = "Add"
            '
            'ComboBoxForm_SalesClass
            '
            Me.ComboBoxForm_SalesClass.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_SalesClass.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_SalesClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_SalesClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_SalesClass.AutoFindItemInDataSource = False
            Me.ComboBoxForm_SalesClass.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_SalesClass.BookmarkingEnabled = False
            Me.ComboBoxForm_SalesClass.ClientCode = ""
            Me.ComboBoxForm_SalesClass.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.SalesClass
            Me.ComboBoxForm_SalesClass.DisableMouseWheel = False
            Me.ComboBoxForm_SalesClass.DisplayMember = "Description"
            Me.ComboBoxForm_SalesClass.DisplayName = ""
            Me.ComboBoxForm_SalesClass.DivisionCode = ""
            Me.ComboBoxForm_SalesClass.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_SalesClass.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_SalesClass.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_SalesClass.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_SalesClass.FocusHighlightEnabled = True
            Me.ComboBoxForm_SalesClass.FormattingEnabled = True
            Me.ComboBoxForm_SalesClass.ItemHeight = 14
            Me.ComboBoxForm_SalesClass.Location = New System.Drawing.Point(143, 38)
            Me.ComboBoxForm_SalesClass.Name = "ComboBoxForm_SalesClass"
            Me.ComboBoxForm_SalesClass.ReadOnly = False
            Me.ComboBoxForm_SalesClass.SecurityEnabled = True
            Me.ComboBoxForm_SalesClass.Size = New System.Drawing.Size(302, 20)
            Me.ComboBoxForm_SalesClass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_SalesClass.TabIndex = 4
            Me.ComboBoxForm_SalesClass.TabOnEnter = True
            Me.ComboBoxForm_SalesClass.ValueMember = "Code"
            Me.ComboBoxForm_SalesClass.WatermarkText = "Select Job"
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
            Me.ComboBoxForm_MediaType.ClientCode = ""
            Me.ComboBoxForm_MediaType.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.[Default]
            Me.ComboBoxForm_MediaType.DisableMouseWheel = False
            Me.ComboBoxForm_MediaType.DisplayMember = "Description"
            Me.ComboBoxForm_MediaType.DisplayName = ""
            Me.ComboBoxForm_MediaType.DivisionCode = ""
            Me.ComboBoxForm_MediaType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_MediaType.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_MediaType.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_MediaType.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_MediaType.FocusHighlightEnabled = True
            Me.ComboBoxForm_MediaType.FormattingEnabled = True
            Me.ComboBoxForm_MediaType.ItemHeight = 14
            Me.ComboBoxForm_MediaType.Location = New System.Drawing.Point(142, 12)
            Me.ComboBoxForm_MediaType.Name = "ComboBoxForm_MediaType"
            Me.ComboBoxForm_MediaType.ReadOnly = False
            Me.ComboBoxForm_MediaType.SecurityEnabled = True
            Me.ComboBoxForm_MediaType.Size = New System.Drawing.Size(207, 20)
            Me.ComboBoxForm_MediaType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_MediaType.TabIndex = 1
            Me.ComboBoxForm_MediaType.TabOnEnter = True
            Me.ComboBoxForm_MediaType.ValueMember = "Code"
            Me.ComboBoxForm_MediaType.WatermarkText = "Select"
            '
            'LabelForm_SalesClass
            '
            Me.LabelForm_SalesClass.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_SalesClass.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_SalesClass.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_SalesClass.Name = "LabelForm_SalesClass"
            Me.LabelForm_SalesClass.Size = New System.Drawing.Size(125, 20)
            Me.LabelForm_SalesClass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_SalesClass.TabIndex = 3
            Me.LabelForm_SalesClass.Text = "Sales Class:"
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
            Me.LabelForm_MediaType.Size = New System.Drawing.Size(125, 20)
            Me.LabelForm_MediaType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_MediaType.TabIndex = 0
            Me.LabelForm_MediaType.Text = "Media Type:"
            '
            'LabelForm_Color
            '
            Me.LabelForm_Color.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_Color.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Color.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Color.Location = New System.Drawing.Point(355, 142)
            Me.LabelForm_Color.Name = "LabelForm_Color"
            Me.LabelForm_Color.Size = New System.Drawing.Size(47, 20)
            Me.LabelForm_Color.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Color.TabIndex = 12
            Me.LabelForm_Color.Text = "Color:"
            '
            'GroupBoxForm_Comment
            '
            Me.GroupBoxForm_Comment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxForm_Comment.Controls.Add(Me.TextBoxComment_Comment)
            Me.GroupBoxForm_Comment.Location = New System.Drawing.Point(12, 298)
            Me.GroupBoxForm_Comment.Name = "GroupBoxForm_Comment"
            Me.GroupBoxForm_Comment.Size = New System.Drawing.Size(433, 237)
            Me.GroupBoxForm_Comment.TabIndex = 26
            Me.GroupBoxForm_Comment.Text = "Comment"
            '
            'TextBoxComment_Comment
            '
            Me.TextBoxComment_Comment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxComment_Comment.Border.Class = "TextBoxBorder"
            Me.TextBoxComment_Comment.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxComment_Comment.CheckSpellingOnValidate = False
            Me.TextBoxComment_Comment.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxComment_Comment.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxComment_Comment.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxComment_Comment.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxComment_Comment.FocusHighlightEnabled = True
            Me.TextBoxComment_Comment.Location = New System.Drawing.Point(5, 24)
            Me.TextBoxComment_Comment.MaxFileSize = CType(0, Long)
            Me.TextBoxComment_Comment.Multiline = True
            Me.TextBoxComment_Comment.Name = "TextBoxComment_Comment"
            Me.TextBoxComment_Comment.SecurityEnabled = True
            Me.TextBoxComment_Comment.ShowSpellCheckCompleteMessage = True
            Me.TextBoxComment_Comment.Size = New System.Drawing.Size(423, 208)
            Me.TextBoxComment_Comment.StartingFolderName = Nothing
            Me.TextBoxComment_Comment.TabIndex = 0
            Me.TextBoxComment_Comment.TabOnEnter = False
            '
            'ColorPickerForm_Color
            '
            Me.ColorPickerForm_Color.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ColorPickerForm_Color.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ColorPickerForm_Color.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ColorPickerForm_Color.Image = CType(resources.GetObject("ColorPickerForm_Color.Image"), System.Drawing.Image)
            Me.ColorPickerForm_Color.Location = New System.Drawing.Point(408, 142)
            Me.ColorPickerForm_Color.Name = "ColorPickerForm_Color"
            Me.ColorPickerForm_Color.SelectedColorImageRectangle = New System.Drawing.Rectangle(2, 2, 12, 12)
            Me.ColorPickerForm_Color.Size = New System.Drawing.Size(37, 20)
            Me.ColorPickerForm_Color.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ColorPickerForm_Color.TabIndex = 13
            '
            'ButtonForm_Update
            '
            Me.ButtonForm_Update.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Update.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Update.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Update.Location = New System.Drawing.Point(289, 541)
            Me.ButtonForm_Update.Name = "ButtonForm_Update"
            Me.ButtonForm_Update.SecurityEnabled = True
            Me.ButtonForm_Update.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Update.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Update.TabIndex = 28
            Me.ButtonForm_Update.Text = "Update"
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
            Me.ComboBoxForm_Campaign.Location = New System.Drawing.Point(143, 90)
            Me.ComboBoxForm_Campaign.Name = "ComboBoxForm_Campaign"
            Me.ComboBoxForm_Campaign.ReadOnly = False
            Me.ComboBoxForm_Campaign.SecurityEnabled = True
            Me.ComboBoxForm_Campaign.Size = New System.Drawing.Size(302, 20)
            Me.ComboBoxForm_Campaign.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Campaign.TabIndex = 7
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
            Me.LabelForm_Campaign.Location = New System.Drawing.Point(12, 90)
            Me.LabelForm_Campaign.Name = "LabelForm_Campaign"
            Me.LabelForm_Campaign.Size = New System.Drawing.Size(125, 20)
            Me.LabelForm_Campaign.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Campaign.TabIndex = 6
            Me.LabelForm_Campaign.Text = "Campaign:"
            '
            'LabelForm_Name
            '
            Me.LabelForm_Name.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Name.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Name.Location = New System.Drawing.Point(12, 116)
            Me.LabelForm_Name.Name = "LabelForm_Name"
            Me.LabelForm_Name.Size = New System.Drawing.Size(125, 20)
            Me.LabelForm_Name.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Name.TabIndex = 8
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
            Me.TextBoxForm_Name.Location = New System.Drawing.Point(143, 116)
            Me.TextBoxForm_Name.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Name.Name = "TextBoxForm_Name"
            Me.TextBoxForm_Name.SecurityEnabled = True
            Me.TextBoxForm_Name.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Name.Size = New System.Drawing.Size(302, 20)
            Me.TextBoxForm_Name.StartingFolderName = Nothing
            Me.TextBoxForm_Name.TabIndex = 9
            Me.TextBoxForm_Name.TabOnEnter = True
            '
            'LabelForm_EstimateIDData
            '
            Me.LabelForm_EstimateIDData.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_EstimateIDData.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_EstimateIDData.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_EstimateIDData.Location = New System.Drawing.Point(143, 142)
            Me.LabelForm_EstimateIDData.Name = "LabelForm_EstimateIDData"
            Me.LabelForm_EstimateIDData.Size = New System.Drawing.Size(206, 20)
            Me.LabelForm_EstimateIDData.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_EstimateIDData.TabIndex = 11
            '
            'LabelForm_EstimateID
            '
            Me.LabelForm_EstimateID.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_EstimateID.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_EstimateID.Location = New System.Drawing.Point(12, 142)
            Me.LabelForm_EstimateID.Name = "LabelForm_EstimateID"
            Me.LabelForm_EstimateID.Size = New System.Drawing.Size(125, 20)
            Me.LabelForm_EstimateID.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_EstimateID.TabIndex = 10
            Me.LabelForm_EstimateID.Text = "Estimate ID:"
            '
            'LabelForm_Buyer
            '
            Me.LabelForm_Buyer.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Buyer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Buyer.Location = New System.Drawing.Point(12, 168)
            Me.LabelForm_Buyer.Name = "LabelForm_Buyer"
            Me.LabelForm_Buyer.Size = New System.Drawing.Size(125, 20)
            Me.LabelForm_Buyer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Buyer.TabIndex = 14
            Me.LabelForm_Buyer.Text = "Buyer:"
            '
            'SearchableComboBoxForm_Buyer
            '
            Me.SearchableComboBoxForm_Buyer.ActiveFilterString = ""
            Me.SearchableComboBoxForm_Buyer.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxForm_Buyer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxForm_Buyer.AutoFillMode = False
            Me.SearchableComboBoxForm_Buyer.BookmarkingEnabled = False
            Me.SearchableComboBoxForm_Buyer.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Employee
            Me.SearchableComboBoxForm_Buyer.DataSource = Nothing
            Me.SearchableComboBoxForm_Buyer.DisableMouseWheel = False
            Me.SearchableComboBoxForm_Buyer.DisplayName = ""
            Me.SearchableComboBoxForm_Buyer.EnterMoveNextControl = True
            Me.SearchableComboBoxForm_Buyer.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxForm_Buyer.Location = New System.Drawing.Point(143, 168)
            Me.SearchableComboBoxForm_Buyer.Name = "SearchableComboBoxForm_Buyer"
            Me.SearchableComboBoxForm_Buyer.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxForm_Buyer.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxForm_Buyer.Properties.NullText = "Select Buyer"
            Me.SearchableComboBoxForm_Buyer.Properties.PopupView = Me.SearchableComboBoxViewForm_Buyer
            Me.SearchableComboBoxForm_Buyer.Properties.ShowClearButton = False
            Me.SearchableComboBoxForm_Buyer.Properties.ValueMember = "Code"
            Me.SearchableComboBoxForm_Buyer.SecurityEnabled = True
            Me.SearchableComboBoxForm_Buyer.SelectedValue = Nothing
            Me.SearchableComboBoxForm_Buyer.Size = New System.Drawing.Size(302, 20)
            Me.SearchableComboBoxForm_Buyer.TabIndex = 15
            '
            'SearchableComboBoxViewForm_Buyer
            '
            Me.SearchableComboBoxViewForm_Buyer.AFActiveFilterString = ""
            Me.SearchableComboBoxViewForm_Buyer.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewForm_Buyer.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewForm_Buyer.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewForm_Buyer.DataSourceClearing = False
            Me.SearchableComboBoxViewForm_Buyer.EnableDisabledRows = False
            Me.SearchableComboBoxViewForm_Buyer.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewForm_Buyer.Name = "SearchableComboBoxViewForm_Buyer"
            Me.SearchableComboBoxViewForm_Buyer.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewForm_Buyer.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewForm_Buyer.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewForm_Buyer.RunStandardValidation = True
            Me.SearchableComboBoxViewForm_Buyer.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboBoxViewForm_Buyer.SkipSettingFontOnModifyColumn = False
            '
            'LabelForm_GrossBudgetAmount
            '
            Me.LabelForm_GrossBudgetAmount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_GrossBudgetAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_GrossBudgetAmount.Location = New System.Drawing.Point(12, 194)
            Me.LabelForm_GrossBudgetAmount.Name = "LabelForm_GrossBudgetAmount"
            Me.LabelForm_GrossBudgetAmount.Size = New System.Drawing.Size(125, 20)
            Me.LabelForm_GrossBudgetAmount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_GrossBudgetAmount.TabIndex = 16
            Me.LabelForm_GrossBudgetAmount.Text = "Estimate Budget:"
            '
            'NumericInputForm_GrossBudgetAmount
            '
            Me.NumericInputForm_GrossBudgetAmount.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputForm_GrossBudgetAmount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.Currency
            Me.NumericInputForm_GrossBudgetAmount.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputForm_GrossBudgetAmount.EnterMoveNextControl = True
            Me.NumericInputForm_GrossBudgetAmount.Location = New System.Drawing.Point(143, 194)
            Me.NumericInputForm_GrossBudgetAmount.Name = "NumericInputForm_GrossBudgetAmount"
            Me.NumericInputForm_GrossBudgetAmount.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
            Me.NumericInputForm_GrossBudgetAmount.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputForm_GrossBudgetAmount.Properties.DisplayFormat.FormatString = "c2"
            Me.NumericInputForm_GrossBudgetAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_GrossBudgetAmount.Properties.EditFormat.FormatString = "c2"
            Me.NumericInputForm_GrossBudgetAmount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_GrossBudgetAmount.Properties.IsFloatValue = False
            Me.NumericInputForm_GrossBudgetAmount.Properties.Mask.EditMask = "c2"
            Me.NumericInputForm_GrossBudgetAmount.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputForm_GrossBudgetAmount.SecurityEnabled = True
            Me.NumericInputForm_GrossBudgetAmount.Size = New System.Drawing.Size(102, 20)
            Me.NumericInputForm_GrossBudgetAmount.TabIndex = 17
            '
            'CheckBoxForm_IsCable
            '
            Me.CheckBoxForm_IsCable.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxForm_IsCable.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_IsCable.CheckValue = 0
            Me.CheckBoxForm_IsCable.CheckValueChecked = 1
            Me.CheckBoxForm_IsCable.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_IsCable.CheckValueUnchecked = 0
            Me.CheckBoxForm_IsCable.ChildControls = CType(resources.GetObject("CheckBoxForm_IsCable.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_IsCable.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_IsCable.Location = New System.Drawing.Point(355, 12)
            Me.CheckBoxForm_IsCable.Name = "CheckBoxForm_IsCable"
            Me.CheckBoxForm_IsCable.OldestSibling = Nothing
            Me.CheckBoxForm_IsCable.SecurityEnabled = True
            Me.CheckBoxForm_IsCable.SiblingControls = CType(resources.GetObject("CheckBoxForm_IsCable.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_IsCable.Size = New System.Drawing.Size(90, 20)
            Me.CheckBoxForm_IsCable.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_IsCable.TabIndex = 2
            Me.CheckBoxForm_IsCable.TabOnEnter = True
            Me.CheckBoxForm_IsCable.Text = "Cable"
            '
            'CheckBoxForm_AllowCampaignLevel
            '
            Me.CheckBoxForm_AllowCampaignLevel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxForm_AllowCampaignLevel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_AllowCampaignLevel.CheckValue = 0
            Me.CheckBoxForm_AllowCampaignLevel.CheckValueChecked = 1
            Me.CheckBoxForm_AllowCampaignLevel.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_AllowCampaignLevel.CheckValueUnchecked = 0
            Me.CheckBoxForm_AllowCampaignLevel.ChildControls = CType(resources.GetObject("CheckBoxForm_AllowCampaignLevel.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_AllowCampaignLevel.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_AllowCampaignLevel.Location = New System.Drawing.Point(143, 64)
            Me.CheckBoxForm_AllowCampaignLevel.Name = "CheckBoxForm_AllowCampaignLevel"
            Me.CheckBoxForm_AllowCampaignLevel.OldestSibling = Nothing
            Me.CheckBoxForm_AllowCampaignLevel.SecurityEnabled = True
            Me.CheckBoxForm_AllowCampaignLevel.SiblingControls = CType(resources.GetObject("CheckBoxForm_AllowCampaignLevel.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_AllowCampaignLevel.Size = New System.Drawing.Size(302, 20)
            Me.CheckBoxForm_AllowCampaignLevel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_AllowCampaignLevel.TabIndex = 5
            Me.CheckBoxForm_AllowCampaignLevel.TabOnEnter = True
            Me.CheckBoxForm_AllowCampaignLevel.Text = "Allow Campaign Level"
            '
            'LabelForm_PeriodType
            '
            Me.LabelForm_PeriodType.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_PeriodType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_PeriodType.Location = New System.Drawing.Point(12, 220)
            Me.LabelForm_PeriodType.Name = "LabelForm_PeriodType"
            Me.LabelForm_PeriodType.Size = New System.Drawing.Size(125, 20)
            Me.LabelForm_PeriodType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_PeriodType.TabIndex = 18
            Me.LabelForm_PeriodType.Text = "Period Type:"
            '
            'ComboBoxForm_PeriodType
            '
            Me.ComboBoxForm_PeriodType.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_PeriodType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_PeriodType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_PeriodType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_PeriodType.AutoFindItemInDataSource = False
            Me.ComboBoxForm_PeriodType.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_PeriodType.BookmarkingEnabled = False
            Me.ComboBoxForm_PeriodType.ClientCode = ""
            Me.ComboBoxForm_PeriodType.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumObjects
            Me.ComboBoxForm_PeriodType.DisableMouseWheel = False
            Me.ComboBoxForm_PeriodType.DisplayMember = "Description"
            Me.ComboBoxForm_PeriodType.DisplayName = ""
            Me.ComboBoxForm_PeriodType.DivisionCode = ""
            Me.ComboBoxForm_PeriodType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_PeriodType.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_PeriodType.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_PeriodType.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_PeriodType.FocusHighlightEnabled = True
            Me.ComboBoxForm_PeriodType.FormattingEnabled = True
            Me.ComboBoxForm_PeriodType.ItemHeight = 14
            Me.ComboBoxForm_PeriodType.Location = New System.Drawing.Point(143, 220)
            Me.ComboBoxForm_PeriodType.Name = "ComboBoxForm_PeriodType"
            Me.ComboBoxForm_PeriodType.ReadOnly = False
            Me.ComboBoxForm_PeriodType.SecurityEnabled = True
            Me.ComboBoxForm_PeriodType.Size = New System.Drawing.Size(302, 20)
            Me.ComboBoxForm_PeriodType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_PeriodType.TabIndex = 19
            Me.ComboBoxForm_PeriodType.TabOnEnter = True
            Me.ComboBoxForm_PeriodType.ValueMember = "Code"
            Me.ComboBoxForm_PeriodType.WatermarkText = "Select"
            '
            'LabelForm_EstimateTemplate
            '
            Me.LabelForm_EstimateTemplate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_EstimateTemplate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_EstimateTemplate.Location = New System.Drawing.Point(12, 246)
            Me.LabelForm_EstimateTemplate.Name = "LabelForm_EstimateTemplate"
            Me.LabelForm_EstimateTemplate.Size = New System.Drawing.Size(125, 20)
            Me.LabelForm_EstimateTemplate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_EstimateTemplate.TabIndex = 20
            Me.LabelForm_EstimateTemplate.Text = "Mix and Rate Template:"
            '
            'SearchableComboBox_EstimateTemplate
            '
            Me.SearchableComboBox_EstimateTemplate.ActiveFilterString = ""
            Me.SearchableComboBox_EstimateTemplate.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBox_EstimateTemplate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBox_EstimateTemplate.AutoFillMode = False
            Me.SearchableComboBox_EstimateTemplate.BookmarkingEnabled = False
            Me.SearchableComboBox_EstimateTemplate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.MediaPlanEstimateTemplate
            Me.SearchableComboBox_EstimateTemplate.DataSource = Nothing
            Me.SearchableComboBox_EstimateTemplate.DisableMouseWheel = False
            Me.SearchableComboBox_EstimateTemplate.DisplayName = ""
            Me.SearchableComboBox_EstimateTemplate.EnterMoveNextControl = True
            Me.SearchableComboBox_EstimateTemplate.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBox_EstimateTemplate.Location = New System.Drawing.Point(143, 246)
            Me.SearchableComboBox_EstimateTemplate.Name = "SearchableComboBox_EstimateTemplate"
            Me.SearchableComboBox_EstimateTemplate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBox_EstimateTemplate.Properties.DisplayMember = "Description"
            Me.SearchableComboBox_EstimateTemplate.Properties.NullText = "Select Template"
            Me.SearchableComboBox_EstimateTemplate.Properties.PopupView = Me.GridView1
            Me.SearchableComboBox_EstimateTemplate.Properties.ShowClearButton = False
            Me.SearchableComboBox_EstimateTemplate.Properties.ValueMember = "ID"
            Me.SearchableComboBox_EstimateTemplate.SecurityEnabled = True
            Me.SearchableComboBox_EstimateTemplate.SelectedValue = Nothing
            Me.SearchableComboBox_EstimateTemplate.Size = New System.Drawing.Size(246, 20)
            Me.SearchableComboBox_EstimateTemplate.TabIndex = 21
            '
            'GridView1
            '
            Me.GridView1.AFActiveFilterString = ""
            Me.GridView1.AllowExtraItemsInGridLookupEdits = True
            Me.GridView1.AutoFilterLookupColumns = False
            Me.GridView1.AutoloadRepositoryDatasource = True
            Me.GridView1.DataSourceClearing = False
            Me.GridView1.EnableDisabledRows = False
            Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView1.Name = "GridView1"
            Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView1.OptionsView.ShowGroupPanel = False
            Me.GridView1.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView1.RunStandardValidation = True
            Me.GridView1.SkipAddingControlsOnModifyColumn = False
            Me.GridView1.SkipSettingFontOnModifyColumn = False
            '
            'SearchableComboBoxForm_Demo
            '
            Me.SearchableComboBoxForm_Demo.ActiveFilterString = ""
            Me.SearchableComboBoxForm_Demo.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxForm_Demo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxForm_Demo.AutoFillMode = False
            Me.SearchableComboBoxForm_Demo.BookmarkingEnabled = False
            Me.SearchableComboBoxForm_Demo.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.MediaDemographic
            Me.SearchableComboBoxForm_Demo.DataSource = Nothing
            Me.SearchableComboBoxForm_Demo.DisableMouseWheel = True
            Me.SearchableComboBoxForm_Demo.DisplayName = ""
            Me.SearchableComboBoxForm_Demo.EditValue = ""
            Me.SearchableComboBoxForm_Demo.EnterMoveNextControl = True
            Me.SearchableComboBoxForm_Demo.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxForm_Demo.Location = New System.Drawing.Point(143, 272)
            Me.SearchableComboBoxForm_Demo.Name = "SearchableComboBoxForm_Demo"
            Me.SearchableComboBoxForm_Demo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxForm_Demo.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxForm_Demo.Properties.NullText = "Select Demographic"
            Me.SearchableComboBoxForm_Demo.Properties.PopupView = Me.SearchableComboBoxViewForm_Demo
            Me.SearchableComboBoxForm_Demo.Properties.ValueMember = "ID"
            Me.SearchableComboBoxForm_Demo.SecurityEnabled = True
            Me.SearchableComboBoxForm_Demo.SelectedValue = ""
            Me.SearchableComboBoxForm_Demo.Size = New System.Drawing.Size(302, 20)
            Me.SearchableComboBoxForm_Demo.TabIndex = 25
            '
            'SearchableComboBoxViewForm_Demo
            '
            Me.SearchableComboBoxViewForm_Demo.AFActiveFilterString = ""
            Me.SearchableComboBoxViewForm_Demo.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewForm_Demo.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Demo.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Demo.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Demo.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Demo.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Demo.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Demo.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Demo.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Demo.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Demo.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Demo.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Demo.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Demo.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Demo.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Demo.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Demo.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Demo.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Demo.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Demo.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Demo.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Demo.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Demo.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Demo.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Demo.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Demo.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Demo.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Demo.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Demo.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Demo.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Demo.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Demo.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Demo.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Demo.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Demo.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Demo.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Demo.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Demo.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Demo.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewForm_Demo.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewForm_Demo.DataSourceClearing = False
            Me.SearchableComboBoxViewForm_Demo.EnableDisabledRows = False
            Me.SearchableComboBoxViewForm_Demo.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewForm_Demo.Name = "SearchableComboBoxViewForm_Demo"
            Me.SearchableComboBoxViewForm_Demo.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewForm_Demo.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewForm_Demo.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewForm_Demo.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewForm_Demo.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewForm_Demo.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewForm_Demo.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewForm_Demo.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewForm_Demo.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewForm_Demo.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewForm_Demo.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewForm_Demo.RunStandardValidation = True
            Me.SearchableComboBoxViewForm_Demo.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboBoxViewForm_Demo.SkipSettingFontOnModifyColumn = False
            '
            'LabelForm_Demo
            '
            Me.LabelForm_Demo.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Demo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Demo.Location = New System.Drawing.Point(12, 272)
            Me.LabelForm_Demo.Name = "LabelForm_Demo"
            Me.LabelForm_Demo.Size = New System.Drawing.Size(125, 20)
            Me.LabelForm_Demo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Demo.TabIndex = 24
            Me.LabelForm_Demo.Text = "Demo:"
            '
            'CheckBoxForm_Auto
            '
            Me.CheckBoxForm_Auto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxForm_Auto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_Auto.CheckValue = 0
            Me.CheckBoxForm_Auto.CheckValueChecked = 1
            Me.CheckBoxForm_Auto.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_Auto.CheckValueUnchecked = 0
            Me.CheckBoxForm_Auto.ChildControls = CType(resources.GetObject("CheckBoxForm_Auto.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Auto.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_Auto.Location = New System.Drawing.Point(395, 246)
            Me.CheckBoxForm_Auto.Name = "CheckBoxForm_Auto"
            Me.CheckBoxForm_Auto.OldestSibling = Nothing
            Me.CheckBoxForm_Auto.SecurityEnabled = True
            Me.CheckBoxForm_Auto.SiblingControls = CType(resources.GetObject("CheckBoxForm_Auto.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Auto.Size = New System.Drawing.Size(50, 20)
            Me.CheckBoxForm_Auto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_Auto.TabIndex = 30
            Me.CheckBoxForm_Auto.TabOnEnter = True
            Me.CheckBoxForm_Auto.Text = "Auto"
            '
            'SuperTooltip
            '
            Me.SuperTooltip.DefaultTooltipSettings = New DevComponents.DotNetBar.SuperTooltipInfo("", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray)
            Me.SuperTooltip.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            '
            'MediaPlanDetailEditDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(457, 573)
            Me.Controls.Add(Me.CheckBoxForm_Auto)
            Me.Controls.Add(Me.SearchableComboBoxForm_Demo)
            Me.Controls.Add(Me.LabelForm_Demo)
            Me.Controls.Add(Me.SearchableComboBox_EstimateTemplate)
            Me.Controls.Add(Me.LabelForm_EstimateTemplate)
            Me.Controls.Add(Me.ComboBoxForm_PeriodType)
            Me.Controls.Add(Me.LabelForm_PeriodType)
            Me.Controls.Add(Me.CheckBoxForm_AllowCampaignLevel)
            Me.Controls.Add(Me.CheckBoxForm_IsCable)
            Me.Controls.Add(Me.LabelForm_GrossBudgetAmount)
            Me.Controls.Add(Me.NumericInputForm_GrossBudgetAmount)
            Me.Controls.Add(Me.SearchableComboBoxForm_Buyer)
            Me.Controls.Add(Me.LabelForm_Buyer)
            Me.Controls.Add(Me.LabelForm_EstimateIDData)
            Me.Controls.Add(Me.LabelForm_EstimateID)
            Me.Controls.Add(Me.TextBoxForm_Name)
            Me.Controls.Add(Me.LabelForm_Name)
            Me.Controls.Add(Me.ComboBoxForm_Campaign)
            Me.Controls.Add(Me.LabelForm_Campaign)
            Me.Controls.Add(Me.LabelForm_Color)
            Me.Controls.Add(Me.ColorPickerForm_Color)
            Me.Controls.Add(Me.GroupBoxForm_Comment)
            Me.Controls.Add(Me.ComboBoxForm_SalesClass)
            Me.Controls.Add(Me.ComboBoxForm_MediaType)
            Me.Controls.Add(Me.LabelForm_SalesClass)
            Me.Controls.Add(Me.LabelForm_MediaType)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.ButtonForm_Add)
            Me.Controls.Add(Me.ButtonForm_Update)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaPlanDetailEditDialog"
            Me.Text = "Estimate"
            CType(Me.GroupBoxForm_Comment, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxForm_Comment.ResumeLayout(False)
            CType(Me.SearchableComboBoxForm_Buyer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewForm_Buyer, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputForm_GrossBudgetAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBox_EstimateTemplate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxForm_Demo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewForm_Demo, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Add As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ComboBoxForm_SalesClass As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxForm_MediaType As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_SalesClass As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_MediaType As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Color As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxForm_Comment As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents TextBoxComment_Comment As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents ColorPickerForm_Color As DevComponents.DotNetBar.ColorPickerButton
        Friend WithEvents ButtonForm_Update As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ComboBoxForm_Campaign As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_Campaign As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Name As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_Name As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_EstimateIDData As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_EstimateID As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Buyer As WinForm.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxForm_Buyer As WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewForm_Buyer As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelForm_GrossBudgetAmount As WinForm.Presentation.Controls.Label
        Friend WithEvents NumericInputForm_GrossBudgetAmount As WinForm.Presentation.Controls.NumericInput
        Friend WithEvents CheckBoxForm_IsCable As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_AllowCampaignLevel As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelForm_PeriodType As WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_PeriodType As WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_EstimateTemplate As WinForm.Presentation.Controls.Label
        Friend WithEvents SearchableComboBox_EstimateTemplate As WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView1 As WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxForm_Demo As WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewForm_Demo As WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelForm_Demo As WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxForm_Auto As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents SuperTooltip As DevComponents.DotNetBar.SuperTooltip
    End Class

End Namespace
