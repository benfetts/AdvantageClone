Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class PurchaseOrderControl
        Inherits AdvantageFramework.WinForm.Presentation.Controls.BaseControls.BaseUserControl

        'UserControl overrides dispose to clean up the component list.
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PurchaseOrderControl))
            Me.ExpandablePanelControl_General = New DevComponents.DotNetBar.ExpandablePanel()
            Me.TextBoxGeneralInfo_PayTo = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelGeneralInfo_PayTo = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.Label_Void = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxControl_MessageDetails = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelGeneralInfo_Message = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneralInfo_ModifiedDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneralInfo_ModifiedBy = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneralInfo_ModifiedByLabel = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneralInfo_ModifiedDateLabel = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxGeneralInfo_VendorContact = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView2 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxGeneralInfo_IssuedTo = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView1 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxGeneralInfo_IssuedBy = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBox1View = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelControl_PONumber = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.NumericInputControl_POTotal = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.TextBoxControl_PONumber = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.NumericInputControl_EmployeeLimit = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelControl_Description = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxControl_EmailAddress = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxControl_Description = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelControl_Revision = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DateTimePickerControl_DueDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelControl_IssuedBy = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DateTimePickerControl_DateIssued = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelControl_IssuedTo = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelControl_EmployeeLimit = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.AddressControlControl_VendorAddress = New AdvantageFramework.WinForm.Presentation.Controls.AddressControl()
            Me.LabelControl_POTotal = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelControl_DateIssued = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelControl_VendorContact = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxControl_WorkComplete = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelControl_EmailAddress = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelControl_DueDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabControlControl_PODetails = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelDetailsTab_Details = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewDetails_PODetails = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemPODetails_DetailsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelFooterCommentsTab_FooterComments = New DevComponents.DotNetBar.TabControlPanel()
            Me.RadioButtonControlFooter_UseCustom = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlFooter_UseStandardComment = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlFooter_UseAgencyDefined = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TextBoxFooterComments_FooterComments = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TabItemPODetails_FooterCommentsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelShippingInstructionsTab_ShippingInstructions = New DevComponents.DotNetBar.TabControlPanel()
            Me.TextBoxShippingInstructions_ShippingInstructions = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TabItemPODetails_ShippingInstructionsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelPOInstructionsTab_POInstructions = New DevComponents.DotNetBar.TabControlPanel()
            Me.TextBoxPOInstructions_Instructions = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TabItemPODetails_POInstructionsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.NumericInputControl_Revision = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.ExpandablePanelControl_General.SuspendLayout()
            CType(Me.SearchableComboBoxGeneralInfo_VendorContact.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxGeneralInfo_IssuedTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxGeneralInfo_IssuedBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBox1View, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputControl_POTotal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputControl_EmployeeLimit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerControl_DueDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerControl_DateIssued, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.TabControlControl_PODetails, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlControl_PODetails.SuspendLayout()
            Me.TabControlPanelDetailsTab_Details.SuspendLayout()
            Me.TabControlPanelFooterCommentsTab_FooterComments.SuspendLayout()
            Me.TabControlPanelShippingInstructionsTab_ShippingInstructions.SuspendLayout()
            Me.TabControlPanelPOInstructionsTab_POInstructions.SuspendLayout()
            CType(Me.NumericInputControl_Revision.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ExpandablePanelControl_General
            '
            Me.ExpandablePanelControl_General.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
            Me.ExpandablePanelControl_General.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ExpandablePanelControl_General.Controls.Add(Me.NumericInputControl_Revision)
            Me.ExpandablePanelControl_General.Controls.Add(Me.TextBoxGeneralInfo_PayTo)
            Me.ExpandablePanelControl_General.Controls.Add(Me.LabelGeneralInfo_PayTo)
            Me.ExpandablePanelControl_General.Controls.Add(Me.Label_Void)
            Me.ExpandablePanelControl_General.Controls.Add(Me.TextBoxControl_MessageDetails)
            Me.ExpandablePanelControl_General.Controls.Add(Me.LabelGeneralInfo_Message)
            Me.ExpandablePanelControl_General.Controls.Add(Me.LabelGeneralInfo_ModifiedDate)
            Me.ExpandablePanelControl_General.Controls.Add(Me.LabelGeneralInfo_ModifiedBy)
            Me.ExpandablePanelControl_General.Controls.Add(Me.LabelGeneralInfo_ModifiedByLabel)
            Me.ExpandablePanelControl_General.Controls.Add(Me.LabelGeneralInfo_ModifiedDateLabel)
            Me.ExpandablePanelControl_General.Controls.Add(Me.SearchableComboBoxGeneralInfo_VendorContact)
            Me.ExpandablePanelControl_General.Controls.Add(Me.SearchableComboBoxGeneralInfo_IssuedTo)
            Me.ExpandablePanelControl_General.Controls.Add(Me.SearchableComboBoxGeneralInfo_IssuedBy)
            Me.ExpandablePanelControl_General.Controls.Add(Me.LabelControl_PONumber)
            Me.ExpandablePanelControl_General.Controls.Add(Me.NumericInputControl_POTotal)
            Me.ExpandablePanelControl_General.Controls.Add(Me.TextBoxControl_PONumber)
            Me.ExpandablePanelControl_General.Controls.Add(Me.NumericInputControl_EmployeeLimit)
            Me.ExpandablePanelControl_General.Controls.Add(Me.LabelControl_Description)
            Me.ExpandablePanelControl_General.Controls.Add(Me.TextBoxControl_EmailAddress)
            Me.ExpandablePanelControl_General.Controls.Add(Me.TextBoxControl_Description)
            Me.ExpandablePanelControl_General.Controls.Add(Me.LabelControl_Revision)
            Me.ExpandablePanelControl_General.Controls.Add(Me.DateTimePickerControl_DueDate)
            Me.ExpandablePanelControl_General.Controls.Add(Me.LabelControl_IssuedBy)
            Me.ExpandablePanelControl_General.Controls.Add(Me.DateTimePickerControl_DateIssued)
            Me.ExpandablePanelControl_General.Controls.Add(Me.LabelControl_IssuedTo)
            Me.ExpandablePanelControl_General.Controls.Add(Me.LabelControl_EmployeeLimit)
            Me.ExpandablePanelControl_General.Controls.Add(Me.AddressControlControl_VendorAddress)
            Me.ExpandablePanelControl_General.Controls.Add(Me.LabelControl_POTotal)
            Me.ExpandablePanelControl_General.Controls.Add(Me.LabelControl_DateIssued)
            Me.ExpandablePanelControl_General.Controls.Add(Me.LabelControl_VendorContact)
            Me.ExpandablePanelControl_General.Controls.Add(Me.CheckBoxControl_WorkComplete)
            Me.ExpandablePanelControl_General.Controls.Add(Me.LabelControl_EmailAddress)
            Me.ExpandablePanelControl_General.Controls.Add(Me.LabelControl_DueDate)
            Me.ExpandablePanelControl_General.DisabledBackColor = System.Drawing.Color.Empty
            Me.ExpandablePanelControl_General.Dock = System.Windows.Forms.DockStyle.Top
            Me.ExpandablePanelControl_General.HideControlsWhenCollapsed = True
            Me.ExpandablePanelControl_General.Location = New System.Drawing.Point(0, 0)
            Me.ExpandablePanelControl_General.Name = "ExpandablePanelControl_General"
            Me.ExpandablePanelControl_General.Size = New System.Drawing.Size(791, 320)
            Me.ExpandablePanelControl_General.Style.Alignment = System.Drawing.StringAlignment.Center
            Me.ExpandablePanelControl_General.Style.BackColor1.Color = System.Drawing.Color.White
            Me.ExpandablePanelControl_General.Style.BackColor2.Color = System.Drawing.Color.White
            Me.ExpandablePanelControl_General.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.ExpandablePanelControl_General.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(154, Byte), Integer))
            Me.ExpandablePanelControl_General.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandablePanelControl_General.Style.GradientAngle = 90
            Me.ExpandablePanelControl_General.TabIndex = 1
            Me.ExpandablePanelControl_General.TextDockConstrained = False
            Me.ExpandablePanelControl_General.TitleStyle.Alignment = System.Drawing.StringAlignment.Center
            Me.ExpandablePanelControl_General.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandablePanelControl_General.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
            Me.ExpandablePanelControl_General.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandablePanelControl_General.TitleStyle.ForeColor.Color = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(154, Byte), Integer))
            Me.ExpandablePanelControl_General.TitleStyle.GradientAngle = 90
            Me.ExpandablePanelControl_General.TitleText = "General Info"
            '
            'TextBoxGeneralInfo_PayTo
            '
            Me.TextBoxGeneralInfo_PayTo.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxGeneralInfo_PayTo.Border.Class = "TextBoxBorder"
            Me.TextBoxGeneralInfo_PayTo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxGeneralInfo_PayTo.CheckSpellingOnValidate = False
            Me.TextBoxGeneralInfo_PayTo.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxGeneralInfo_PayTo.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxGeneralInfo_PayTo.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxGeneralInfo_PayTo.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxGeneralInfo_PayTo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxGeneralInfo_PayTo.FocusHighlightEnabled = True
            Me.TextBoxGeneralInfo_PayTo.ForeColor = System.Drawing.Color.Black
            Me.TextBoxGeneralInfo_PayTo.Location = New System.Drawing.Point(75, 109)
            Me.TextBoxGeneralInfo_PayTo.MaxFileSize = CType(0, Long)
            Me.TextBoxGeneralInfo_PayTo.Name = "TextBoxGeneralInfo_PayTo"
            Me.TextBoxGeneralInfo_PayTo.ReadOnly = True
            Me.TextBoxGeneralInfo_PayTo.SecurityEnabled = True
            Me.TextBoxGeneralInfo_PayTo.ShowSpellCheckCompleteMessage = True
            Me.TextBoxGeneralInfo_PayTo.Size = New System.Drawing.Size(286, 20)
            Me.TextBoxGeneralInfo_PayTo.StartingFolderName = Nothing
            Me.TextBoxGeneralInfo_PayTo.TabIndex = 11
            Me.TextBoxGeneralInfo_PayTo.TabOnEnter = True
            '
            'LabelGeneralInfo_PayTo
            '
            Me.LabelGeneralInfo_PayTo.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneralInfo_PayTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneralInfo_PayTo.Location = New System.Drawing.Point(4, 108)
            Me.LabelGeneralInfo_PayTo.Name = "LabelGeneralInfo_PayTo"
            Me.LabelGeneralInfo_PayTo.Size = New System.Drawing.Size(65, 20)
            Me.LabelGeneralInfo_PayTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneralInfo_PayTo.TabIndex = 10
            Me.LabelGeneralInfo_PayTo.Text = "Pay To:"
            '
            'Label_Void
            '
            Me.Label_Void.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Label_Void.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.Label_Void.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label_Void.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_Void.ForeColor = System.Drawing.Color.Red
            Me.Label_Void.Location = New System.Drawing.Point(734, 59)
            Me.Label_Void.Name = "Label_Void"
            Me.Label_Void.Size = New System.Drawing.Size(53, 20)
            Me.Label_Void.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label_Void.TabIndex = 36
            Me.Label_Void.Text = "VOID"
            Me.Label_Void.TextAlignment = System.Drawing.StringAlignment.Center
            Me.Label_Void.Visible = False
            '
            'TextBoxControl_MessageDetails
            '
            Me.TextBoxControl_MessageDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxControl_MessageDetails.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxControl_MessageDetails.Border.Class = "TextBoxBorder"
            Me.TextBoxControl_MessageDetails.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxControl_MessageDetails.CheckSpellingOnValidate = False
            Me.TextBoxControl_MessageDetails.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxControl_MessageDetails.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxControl_MessageDetails.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxControl_MessageDetails.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxControl_MessageDetails.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxControl_MessageDetails.FocusHighlightEnabled = True
            Me.TextBoxControl_MessageDetails.ForeColor = System.Drawing.Color.Black
            Me.TextBoxControl_MessageDetails.Location = New System.Drawing.Point(457, 239)
            Me.TextBoxControl_MessageDetails.MaxFileSize = CType(0, Long)
            Me.TextBoxControl_MessageDetails.Multiline = True
            Me.TextBoxControl_MessageDetails.Name = "TextBoxControl_MessageDetails"
            Me.TextBoxControl_MessageDetails.ReadOnly = True
            Me.TextBoxControl_MessageDetails.SecurityEnabled = True
            Me.TextBoxControl_MessageDetails.ShowSpellCheckCompleteMessage = True
            Me.TextBoxControl_MessageDetails.Size = New System.Drawing.Size(330, 77)
            Me.TextBoxControl_MessageDetails.StartingFolderName = Nothing
            Me.TextBoxControl_MessageDetails.TabIndex = 31
            Me.TextBoxControl_MessageDetails.TabOnEnter = True
            Me.TextBoxControl_MessageDetails.TabStop = False
            '
            'LabelGeneralInfo_Message
            '
            Me.LabelGeneralInfo_Message.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneralInfo_Message.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneralInfo_Message.Location = New System.Drawing.Point(367, 239)
            Me.LabelGeneralInfo_Message.Name = "LabelGeneralInfo_Message"
            Me.LabelGeneralInfo_Message.Size = New System.Drawing.Size(84, 20)
            Me.LabelGeneralInfo_Message.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneralInfo_Message.TabIndex = 30
            Me.LabelGeneralInfo_Message.Text = "Message:"
            '
            'LabelGeneralInfo_ModifiedDate
            '
            Me.LabelGeneralInfo_ModifiedDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelGeneralInfo_ModifiedDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneralInfo_ModifiedDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneralInfo_ModifiedDate.Location = New System.Drawing.Point(663, 213)
            Me.LabelGeneralInfo_ModifiedDate.Name = "LabelGeneralInfo_ModifiedDate"
            Me.LabelGeneralInfo_ModifiedDate.Size = New System.Drawing.Size(124, 20)
            Me.LabelGeneralInfo_ModifiedDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneralInfo_ModifiedDate.TabIndex = 29
            Me.LabelGeneralInfo_ModifiedDate.Text = "{0}"
            '
            'LabelGeneralInfo_ModifiedBy
            '
            Me.LabelGeneralInfo_ModifiedBy.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelGeneralInfo_ModifiedBy.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneralInfo_ModifiedBy.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneralInfo_ModifiedBy.Location = New System.Drawing.Point(663, 187)
            Me.LabelGeneralInfo_ModifiedBy.Name = "LabelGeneralInfo_ModifiedBy"
            Me.LabelGeneralInfo_ModifiedBy.Size = New System.Drawing.Size(124, 20)
            Me.LabelGeneralInfo_ModifiedBy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneralInfo_ModifiedBy.TabIndex = 25
            Me.LabelGeneralInfo_ModifiedBy.Text = "{0}"
            '
            'LabelGeneralInfo_ModifiedByLabel
            '
            Me.LabelGeneralInfo_ModifiedByLabel.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneralInfo_ModifiedByLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneralInfo_ModifiedByLabel.Location = New System.Drawing.Point(584, 187)
            Me.LabelGeneralInfo_ModifiedByLabel.Name = "LabelGeneralInfo_ModifiedByLabel"
            Me.LabelGeneralInfo_ModifiedByLabel.Size = New System.Drawing.Size(73, 20)
            Me.LabelGeneralInfo_ModifiedByLabel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneralInfo_ModifiedByLabel.TabIndex = 24
            Me.LabelGeneralInfo_ModifiedByLabel.Text = "Modified By:"
            '
            'LabelGeneralInfo_ModifiedDateLabel
            '
            Me.LabelGeneralInfo_ModifiedDateLabel.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneralInfo_ModifiedDateLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneralInfo_ModifiedDateLabel.Location = New System.Drawing.Point(584, 213)
            Me.LabelGeneralInfo_ModifiedDateLabel.Name = "LabelGeneralInfo_ModifiedDateLabel"
            Me.LabelGeneralInfo_ModifiedDateLabel.Size = New System.Drawing.Size(73, 20)
            Me.LabelGeneralInfo_ModifiedDateLabel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneralInfo_ModifiedDateLabel.TabIndex = 28
            Me.LabelGeneralInfo_ModifiedDateLabel.Text = "Modified Date:"
            '
            'SearchableComboBoxGeneralInfo_VendorContact
            '
            Me.SearchableComboBoxGeneralInfo_VendorContact.ActiveFilterString = ""
            Me.SearchableComboBoxGeneralInfo_VendorContact.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxGeneralInfo_VendorContact.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxGeneralInfo_VendorContact.AutoFillMode = False
            Me.SearchableComboBoxGeneralInfo_VendorContact.BookmarkingEnabled = False
            Me.SearchableComboBoxGeneralInfo_VendorContact.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.VendorContact
            Me.SearchableComboBoxGeneralInfo_VendorContact.DataSource = Nothing
            Me.SearchableComboBoxGeneralInfo_VendorContact.DisableMouseWheel = False
            Me.SearchableComboBoxGeneralInfo_VendorContact.DisplayName = ""
            Me.SearchableComboBoxGeneralInfo_VendorContact.EnterMoveNextControl = True
            Me.SearchableComboBoxGeneralInfo_VendorContact.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxGeneralInfo_VendorContact.Location = New System.Drawing.Point(457, 135)
            Me.SearchableComboBoxGeneralInfo_VendorContact.Name = "SearchableComboBoxGeneralInfo_VendorContact"
            Me.SearchableComboBoxGeneralInfo_VendorContact.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxGeneralInfo_VendorContact.Properties.DisplayMember = "FullName"
            Me.SearchableComboBoxGeneralInfo_VendorContact.Properties.NullText = "Select Vendor Contact"
            Me.SearchableComboBoxGeneralInfo_VendorContact.Properties.PopupView = Me.GridView2
            Me.SearchableComboBoxGeneralInfo_VendorContact.Properties.ValueMember = "Code"
            Me.SearchableComboBoxGeneralInfo_VendorContact.SecurityEnabled = True
            Me.SearchableComboBoxGeneralInfo_VendorContact.SelectedValue = Nothing
            Me.SearchableComboBoxGeneralInfo_VendorContact.Size = New System.Drawing.Size(330, 20)
            Me.SearchableComboBoxGeneralInfo_VendorContact.TabIndex = 19
            '
            'GridView2
            '
            Me.GridView2.AFActiveFilterString = ""
            Me.GridView2.AllowExtraItemsInGridLookupEdits = True
            Me.GridView2.AutoFilterLookupColumns = False
            Me.GridView2.AutoloadRepositoryDatasource = True
            Me.GridView2.DataSourceClearing = False
            Me.GridView2.EnableDisabledRows = False
            Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView2.Name = "GridView2"
            Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView2.OptionsView.ShowGroupPanel = False
            Me.GridView2.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView2.RunStandardValidation = True
            '
            'SearchableComboBoxGeneralInfo_IssuedTo
            '
            Me.SearchableComboBoxGeneralInfo_IssuedTo.ActiveFilterString = ""
            Me.SearchableComboBoxGeneralInfo_IssuedTo.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxGeneralInfo_IssuedTo.AutoFillMode = False
            Me.SearchableComboBoxGeneralInfo_IssuedTo.BookmarkingEnabled = False
            Me.SearchableComboBoxGeneralInfo_IssuedTo.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Vendor
            Me.SearchableComboBoxGeneralInfo_IssuedTo.DataSource = Nothing
            Me.SearchableComboBoxGeneralInfo_IssuedTo.DisableMouseWheel = False
            Me.SearchableComboBoxGeneralInfo_IssuedTo.DisplayName = ""
            Me.SearchableComboBoxGeneralInfo_IssuedTo.EnterMoveNextControl = True
            Me.SearchableComboBoxGeneralInfo_IssuedTo.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxGeneralInfo_IssuedTo.Location = New System.Drawing.Point(74, 82)
            Me.SearchableComboBoxGeneralInfo_IssuedTo.Name = "SearchableComboBoxGeneralInfo_IssuedTo"
            Me.SearchableComboBoxGeneralInfo_IssuedTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxGeneralInfo_IssuedTo.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxGeneralInfo_IssuedTo.Properties.NullText = "Select Vendor"
            Me.SearchableComboBoxGeneralInfo_IssuedTo.Properties.PopupView = Me.GridView1
            Me.SearchableComboBoxGeneralInfo_IssuedTo.Properties.ShowClearButton = False
            Me.SearchableComboBoxGeneralInfo_IssuedTo.Properties.ValueMember = "Code"
            Me.SearchableComboBoxGeneralInfo_IssuedTo.SecurityEnabled = True
            Me.SearchableComboBoxGeneralInfo_IssuedTo.SelectedValue = Nothing
            Me.SearchableComboBoxGeneralInfo_IssuedTo.Size = New System.Drawing.Size(287, 20)
            Me.SearchableComboBoxGeneralInfo_IssuedTo.TabIndex = 9
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
            '
            'SearchableComboBoxGeneralInfo_IssuedBy
            '
            Me.SearchableComboBoxGeneralInfo_IssuedBy.ActiveFilterString = ""
            Me.SearchableComboBoxGeneralInfo_IssuedBy.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxGeneralInfo_IssuedBy.AutoFillMode = False
            Me.SearchableComboBoxGeneralInfo_IssuedBy.BookmarkingEnabled = False
            Me.SearchableComboBoxGeneralInfo_IssuedBy.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Employee
            Me.SearchableComboBoxGeneralInfo_IssuedBy.DataSource = Nothing
            Me.SearchableComboBoxGeneralInfo_IssuedBy.DisableMouseWheel = False
            Me.SearchableComboBoxGeneralInfo_IssuedBy.DisplayName = ""
            Me.SearchableComboBoxGeneralInfo_IssuedBy.EnterMoveNextControl = True
            Me.SearchableComboBoxGeneralInfo_IssuedBy.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxGeneralInfo_IssuedBy.Location = New System.Drawing.Point(74, 56)
            Me.SearchableComboBoxGeneralInfo_IssuedBy.Name = "SearchableComboBoxGeneralInfo_IssuedBy"
            Me.SearchableComboBoxGeneralInfo_IssuedBy.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxGeneralInfo_IssuedBy.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxGeneralInfo_IssuedBy.Properties.NullText = "Select Employee"
            Me.SearchableComboBoxGeneralInfo_IssuedBy.Properties.PopupView = Me.SearchableComboBox1View
            Me.SearchableComboBoxGeneralInfo_IssuedBy.Properties.ShowClearButton = False
            Me.SearchableComboBoxGeneralInfo_IssuedBy.Properties.ValueMember = "Code"
            Me.SearchableComboBoxGeneralInfo_IssuedBy.SecurityEnabled = True
            Me.SearchableComboBoxGeneralInfo_IssuedBy.SelectedValue = Nothing
            Me.SearchableComboBoxGeneralInfo_IssuedBy.Size = New System.Drawing.Size(287, 20)
            Me.SearchableComboBoxGeneralInfo_IssuedBy.TabIndex = 7
            '
            'SearchableComboBox1View
            '
            Me.SearchableComboBox1View.AFActiveFilterString = ""
            Me.SearchableComboBox1View.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBox1View.AutoFilterLookupColumns = False
            Me.SearchableComboBox1View.AutoloadRepositoryDatasource = True
            Me.SearchableComboBox1View.DataSourceClearing = False
            Me.SearchableComboBox1View.EnableDisabledRows = False
            Me.SearchableComboBox1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBox1View.Name = "SearchableComboBox1View"
            Me.SearchableComboBox1View.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBox1View.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBox1View.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBox1View.RunStandardValidation = True
            '
            'LabelControl_PONumber
            '
            Me.LabelControl_PONumber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_PONumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_PONumber.Location = New System.Drawing.Point(3, 30)
            Me.LabelControl_PONumber.Name = "LabelControl_PONumber"
            Me.LabelControl_PONumber.Size = New System.Drawing.Size(65, 20)
            Me.LabelControl_PONumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_PONumber.TabIndex = 0
            Me.LabelControl_PONumber.Text = "Number:"
            '
            'NumericInputControl_POTotal
            '
            Me.NumericInputControl_POTotal.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputControl_POTotal.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.Currency
            Me.NumericInputControl_POTotal.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputControl_POTotal.EnterMoveNextControl = True
            Me.NumericInputControl_POTotal.Location = New System.Drawing.Point(457, 213)
            Me.NumericInputControl_POTotal.Name = "NumericInputControl_POTotal"
            Me.NumericInputControl_POTotal.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputControl_POTotal.Properties.DisplayFormat.FormatString = "c2"
            Me.NumericInputControl_POTotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_POTotal.Properties.EditFormat.FormatString = "c2"
            Me.NumericInputControl_POTotal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_POTotal.Properties.IsFloatValue = False
            Me.NumericInputControl_POTotal.Properties.Mask.EditMask = "c2"
            Me.NumericInputControl_POTotal.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputControl_POTotal.SecurityEnabled = True
            Me.NumericInputControl_POTotal.Size = New System.Drawing.Size(121, 20)
            Me.NumericInputControl_POTotal.TabIndex = 27
            '
            'TextBoxControl_PONumber
            '
            Me.TextBoxControl_PONumber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxControl_PONumber.Border.Class = "TextBoxBorder"
            Me.TextBoxControl_PONumber.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxControl_PONumber.CheckSpellingOnValidate = False
            Me.TextBoxControl_PONumber.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxControl_PONumber.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxControl_PONumber.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxControl_PONumber.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxControl_PONumber.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxControl_PONumber.FocusHighlightEnabled = True
            Me.TextBoxControl_PONumber.ForeColor = System.Drawing.Color.Black
            Me.TextBoxControl_PONumber.Location = New System.Drawing.Point(74, 30)
            Me.TextBoxControl_PONumber.MaxFileSize = CType(0, Long)
            Me.TextBoxControl_PONumber.Name = "TextBoxControl_PONumber"
            Me.TextBoxControl_PONumber.ReadOnly = True
            Me.TextBoxControl_PONumber.SecurityEnabled = True
            Me.TextBoxControl_PONumber.ShowSpellCheckCompleteMessage = True
            Me.TextBoxControl_PONumber.Size = New System.Drawing.Size(77, 20)
            Me.TextBoxControl_PONumber.StartingFolderName = Nothing
            Me.TextBoxControl_PONumber.TabIndex = 1
            Me.TextBoxControl_PONumber.TabOnEnter = True
            '
            'NumericInputControl_EmployeeLimit
            '
            Me.NumericInputControl_EmployeeLimit.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputControl_EmployeeLimit.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.Currency
            Me.NumericInputControl_EmployeeLimit.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputControl_EmployeeLimit.EnterMoveNextControl = True
            Me.NumericInputControl_EmployeeLimit.Location = New System.Drawing.Point(457, 187)
            Me.NumericInputControl_EmployeeLimit.Name = "NumericInputControl_EmployeeLimit"
            Me.NumericInputControl_EmployeeLimit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputControl_EmployeeLimit.Properties.DisplayFormat.FormatString = "c2"
            Me.NumericInputControl_EmployeeLimit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_EmployeeLimit.Properties.EditFormat.FormatString = "c2"
            Me.NumericInputControl_EmployeeLimit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_EmployeeLimit.Properties.IsFloatValue = False
            Me.NumericInputControl_EmployeeLimit.Properties.Mask.EditMask = "c2"
            Me.NumericInputControl_EmployeeLimit.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputControl_EmployeeLimit.SecurityEnabled = True
            Me.NumericInputControl_EmployeeLimit.Size = New System.Drawing.Size(121, 20)
            Me.NumericInputControl_EmployeeLimit.TabIndex = 23
            '
            'LabelControl_Description
            '
            Me.LabelControl_Description.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_Description.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_Description.Location = New System.Drawing.Point(157, 30)
            Me.LabelControl_Description.Name = "LabelControl_Description"
            Me.LabelControl_Description.Size = New System.Drawing.Size(65, 20)
            Me.LabelControl_Description.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_Description.TabIndex = 2
            Me.LabelControl_Description.Text = "Description:"
            '
            'TextBoxControl_EmailAddress
            '
            Me.TextBoxControl_EmailAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxControl_EmailAddress.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxControl_EmailAddress.Border.Class = "TextBoxBorder"
            Me.TextBoxControl_EmailAddress.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxControl_EmailAddress.CheckSpellingOnValidate = False
            Me.TextBoxControl_EmailAddress.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxControl_EmailAddress.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxControl_EmailAddress.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxControl_EmailAddress.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxControl_EmailAddress.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxControl_EmailAddress.FocusHighlightEnabled = True
            Me.TextBoxControl_EmailAddress.ForeColor = System.Drawing.Color.Black
            Me.TextBoxControl_EmailAddress.Location = New System.Drawing.Point(457, 161)
            Me.TextBoxControl_EmailAddress.MaxFileSize = CType(0, Long)
            Me.TextBoxControl_EmailAddress.Name = "TextBoxControl_EmailAddress"
            Me.TextBoxControl_EmailAddress.SecurityEnabled = True
            Me.TextBoxControl_EmailAddress.ShowSpellCheckCompleteMessage = True
            Me.TextBoxControl_EmailAddress.Size = New System.Drawing.Size(330, 20)
            Me.TextBoxControl_EmailAddress.StartingFolderName = Nothing
            Me.TextBoxControl_EmailAddress.TabIndex = 21
            Me.TextBoxControl_EmailAddress.TabOnEnter = True
            '
            'TextBoxControl_Description
            '
            Me.TextBoxControl_Description.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxControl_Description.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxControl_Description.Border.Class = "TextBoxBorder"
            Me.TextBoxControl_Description.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxControl_Description.CheckSpellingOnValidate = False
            Me.TextBoxControl_Description.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxControl_Description.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxControl_Description.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxControl_Description.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxControl_Description.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxControl_Description.FocusHighlightEnabled = True
            Me.TextBoxControl_Description.ForeColor = System.Drawing.Color.Black
            Me.TextBoxControl_Description.Location = New System.Drawing.Point(228, 30)
            Me.TextBoxControl_Description.MaxFileSize = CType(0, Long)
            Me.TextBoxControl_Description.Name = "TextBoxControl_Description"
            Me.TextBoxControl_Description.SecurityEnabled = True
            Me.TextBoxControl_Description.ShowSpellCheckCompleteMessage = True
            Me.TextBoxControl_Description.Size = New System.Drawing.Size(437, 20)
            Me.TextBoxControl_Description.StartingFolderName = Nothing
            Me.TextBoxControl_Description.TabIndex = 3
            Me.TextBoxControl_Description.TabOnEnter = True
            '
            'LabelControl_Revision
            '
            Me.LabelControl_Revision.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelControl_Revision.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_Revision.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_Revision.Location = New System.Drawing.Point(671, 30)
            Me.LabelControl_Revision.Name = "LabelControl_Revision"
            Me.LabelControl_Revision.Size = New System.Drawing.Size(53, 20)
            Me.LabelControl_Revision.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_Revision.TabIndex = 4
            Me.LabelControl_Revision.Text = "Revision:"
            '
            'DateTimePickerControl_DueDate
            '
            Me.DateTimePickerControl_DueDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerControl_DueDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerControl_DueDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerControl_DueDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerControl_DueDate.ButtonDropDown.Visible = True
            Me.DateTimePickerControl_DueDate.ButtonFreeText.Checked = True
            Me.DateTimePickerControl_DueDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerControl_DueDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerControl_DueDate.DisplayName = ""
            Me.DateTimePickerControl_DueDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerControl_DueDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerControl_DueDate.FocusHighlightEnabled = True
            Me.DateTimePickerControl_DueDate.FreeTextEntryMode = True
            Me.DateTimePickerControl_DueDate.IsPopupCalendarOpen = False
            Me.DateTimePickerControl_DueDate.Location = New System.Drawing.Point(457, 83)
            Me.DateTimePickerControl_DueDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerControl_DueDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerControl_DueDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerControl_DueDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerControl_DueDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerControl_DueDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerControl_DueDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerControl_DueDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerControl_DueDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerControl_DueDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerControl_DueDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerControl_DueDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerControl_DueDate.MonthCalendar.DisplayMonth = New Date(2013, 6, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerControl_DueDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerControl_DueDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerControl_DueDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerControl_DueDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerControl_DueDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerControl_DueDate.Name = "DateTimePickerControl_DueDate"
            Me.DateTimePickerControl_DueDate.ReadOnly = False
            Me.DateTimePickerControl_DueDate.Size = New System.Drawing.Size(121, 20)
            Me.DateTimePickerControl_DueDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerControl_DueDate.TabIndex = 16
            Me.DateTimePickerControl_DueDate.TabOnEnter = True
            Me.DateTimePickerControl_DueDate.Value = New Date(2013, 6, 25, 8, 2, 32, 676)
            '
            'LabelControl_IssuedBy
            '
            Me.LabelControl_IssuedBy.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_IssuedBy.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_IssuedBy.Location = New System.Drawing.Point(3, 56)
            Me.LabelControl_IssuedBy.Name = "LabelControl_IssuedBy"
            Me.LabelControl_IssuedBy.Size = New System.Drawing.Size(65, 20)
            Me.LabelControl_IssuedBy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_IssuedBy.TabIndex = 6
            Me.LabelControl_IssuedBy.Text = "Issued By:"
            '
            'DateTimePickerControl_DateIssued
            '
            Me.DateTimePickerControl_DateIssued.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerControl_DateIssued.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerControl_DateIssued.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerControl_DateIssued.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerControl_DateIssued.ButtonDropDown.Visible = True
            Me.DateTimePickerControl_DateIssued.ButtonFreeText.Checked = True
            Me.DateTimePickerControl_DateIssued.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerControl_DateIssued.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerControl_DateIssued.DisplayName = ""
            Me.DateTimePickerControl_DateIssued.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerControl_DateIssued.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerControl_DateIssued.FocusHighlightEnabled = True
            Me.DateTimePickerControl_DateIssued.FreeTextEntryMode = True
            Me.DateTimePickerControl_DateIssued.IsPopupCalendarOpen = False
            Me.DateTimePickerControl_DateIssued.Location = New System.Drawing.Point(457, 57)
            Me.DateTimePickerControl_DateIssued.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerControl_DateIssued.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerControl_DateIssued.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerControl_DateIssued.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerControl_DateIssued.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerControl_DateIssued.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerControl_DateIssued.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerControl_DateIssued.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerControl_DateIssued.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerControl_DateIssued.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerControl_DateIssued.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerControl_DateIssued.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerControl_DateIssued.MonthCalendar.DisplayMonth = New Date(2013, 6, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerControl_DateIssued.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerControl_DateIssued.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerControl_DateIssued.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerControl_DateIssued.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerControl_DateIssued.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerControl_DateIssued.Name = "DateTimePickerControl_DateIssued"
            Me.DateTimePickerControl_DateIssued.ReadOnly = False
            Me.DateTimePickerControl_DateIssued.Size = New System.Drawing.Size(121, 20)
            Me.DateTimePickerControl_DateIssued.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerControl_DateIssued.TabIndex = 14
            Me.DateTimePickerControl_DateIssued.TabOnEnter = True
            Me.DateTimePickerControl_DateIssued.Value = New Date(2013, 6, 25, 8, 2, 32, 658)
            '
            'LabelControl_IssuedTo
            '
            Me.LabelControl_IssuedTo.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_IssuedTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_IssuedTo.Location = New System.Drawing.Point(3, 82)
            Me.LabelControl_IssuedTo.Name = "LabelControl_IssuedTo"
            Me.LabelControl_IssuedTo.Size = New System.Drawing.Size(65, 20)
            Me.LabelControl_IssuedTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_IssuedTo.TabIndex = 8
            Me.LabelControl_IssuedTo.Text = "Issued To: "
            '
            'LabelControl_EmployeeLimit
            '
            Me.LabelControl_EmployeeLimit.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_EmployeeLimit.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_EmployeeLimit.Location = New System.Drawing.Point(367, 187)
            Me.LabelControl_EmployeeLimit.Name = "LabelControl_EmployeeLimit"
            Me.LabelControl_EmployeeLimit.Size = New System.Drawing.Size(84, 20)
            Me.LabelControl_EmployeeLimit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_EmployeeLimit.TabIndex = 22
            Me.LabelControl_EmployeeLimit.Text = "Employee Limit:"
            '
            'AddressControlControl_VendorAddress
            '
            Me.AddressControlControl_VendorAddress.Address = Nothing
            Me.AddressControlControl_VendorAddress.Address2 = Nothing
            Me.AddressControlControl_VendorAddress.Address3 = Nothing
            Me.AddressControlControl_VendorAddress.City = Nothing
            Me.AddressControlControl_VendorAddress.Country = Nothing
            Me.AddressControlControl_VendorAddress.County = Nothing
            Me.AddressControlControl_VendorAddress.DisableCountry = False
            Me.AddressControlControl_VendorAddress.DisableCounty = False
            Me.AddressControlControl_VendorAddress.Location = New System.Drawing.Point(4, 135)
            Me.AddressControlControl_VendorAddress.Name = "AddressControlControl_VendorAddress"
            Me.AddressControlControl_VendorAddress.ReadOnly = True
            Me.AddressControlControl_VendorAddress.ShowCountry = True
            Me.AddressControlControl_VendorAddress.ShowCounty = True
            Me.AddressControlControl_VendorAddress.Size = New System.Drawing.Size(357, 181)
            Me.AddressControlControl_VendorAddress.State = Nothing
            Me.AddressControlControl_VendorAddress.TabIndex = 12
            Me.AddressControlControl_VendorAddress.TabStop = False
            Me.AddressControlControl_VendorAddress.Title = "Address"
            Me.AddressControlControl_VendorAddress.Zip = Nothing
            '
            'LabelControl_POTotal
            '
            Me.LabelControl_POTotal.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_POTotal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_POTotal.Location = New System.Drawing.Point(367, 213)
            Me.LabelControl_POTotal.Name = "LabelControl_POTotal"
            Me.LabelControl_POTotal.Size = New System.Drawing.Size(84, 20)
            Me.LabelControl_POTotal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_POTotal.TabIndex = 26
            Me.LabelControl_POTotal.Text = "P.O. Total: "
            '
            'LabelControl_DateIssued
            '
            Me.LabelControl_DateIssued.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_DateIssued.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_DateIssued.Location = New System.Drawing.Point(367, 56)
            Me.LabelControl_DateIssued.Name = "LabelControl_DateIssued"
            Me.LabelControl_DateIssued.Size = New System.Drawing.Size(84, 20)
            Me.LabelControl_DateIssued.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_DateIssued.TabIndex = 13
            Me.LabelControl_DateIssued.Text = "Date Issued:"
            '
            'LabelControl_VendorContact
            '
            Me.LabelControl_VendorContact.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_VendorContact.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_VendorContact.Location = New System.Drawing.Point(367, 135)
            Me.LabelControl_VendorContact.Name = "LabelControl_VendorContact"
            Me.LabelControl_VendorContact.Size = New System.Drawing.Size(84, 20)
            Me.LabelControl_VendorContact.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_VendorContact.TabIndex = 18
            Me.LabelControl_VendorContact.Text = "Vendor Contact:"
            '
            'CheckBoxControl_WorkComplete
            '
            Me.CheckBoxControl_WorkComplete.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxControl_WorkComplete.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxControl_WorkComplete.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxControl_WorkComplete.CheckValue = 0
            Me.CheckBoxControl_WorkComplete.CheckValueChecked = 1
            Me.CheckBoxControl_WorkComplete.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxControl_WorkComplete.CheckValueUnchecked = 0
            Me.CheckBoxControl_WorkComplete.ChildControls = CType(resources.GetObject("CheckBoxControl_WorkComplete.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxControl_WorkComplete.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxControl_WorkComplete.Location = New System.Drawing.Point(457, 109)
            Me.CheckBoxControl_WorkComplete.Name = "CheckBoxControl_WorkComplete"
            Me.CheckBoxControl_WorkComplete.OldestSibling = Nothing
            Me.CheckBoxControl_WorkComplete.SecurityEnabled = True
            Me.CheckBoxControl_WorkComplete.SiblingControls = CType(resources.GetObject("CheckBoxControl_WorkComplete.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxControl_WorkComplete.Size = New System.Drawing.Size(330, 20)
            Me.CheckBoxControl_WorkComplete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxControl_WorkComplete.TabIndex = 17
            Me.CheckBoxControl_WorkComplete.TabOnEnter = True
            Me.CheckBoxControl_WorkComplete.Text = "Work Complete"
            '
            'LabelControl_EmailAddress
            '
            Me.LabelControl_EmailAddress.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_EmailAddress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_EmailAddress.Location = New System.Drawing.Point(367, 161)
            Me.LabelControl_EmailAddress.Name = "LabelControl_EmailAddress"
            Me.LabelControl_EmailAddress.Size = New System.Drawing.Size(84, 20)
            Me.LabelControl_EmailAddress.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_EmailAddress.TabIndex = 20
            Me.LabelControl_EmailAddress.Text = "E-Mail Address: "
            '
            'LabelControl_DueDate
            '
            Me.LabelControl_DueDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_DueDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_DueDate.Location = New System.Drawing.Point(367, 82)
            Me.LabelControl_DueDate.Name = "LabelControl_DueDate"
            Me.LabelControl_DueDate.Size = New System.Drawing.Size(84, 20)
            Me.LabelControl_DueDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_DueDate.TabIndex = 15
            Me.LabelControl_DueDate.Text = "Due Date:"
            '
            'TabControlControl_PODetails
            '
            Me.TabControlControl_PODetails.BackColor = System.Drawing.Color.White
            Me.TabControlControl_PODetails.CanReorderTabs = True
            Me.TabControlControl_PODetails.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlControl_PODetails.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlControl_PODetails.Controls.Add(Me.TabControlPanelDetailsTab_Details)
            Me.TabControlControl_PODetails.Controls.Add(Me.TabControlPanelFooterCommentsTab_FooterComments)
            Me.TabControlControl_PODetails.Controls.Add(Me.TabControlPanelShippingInstructionsTab_ShippingInstructions)
            Me.TabControlControl_PODetails.Controls.Add(Me.TabControlPanelPOInstructionsTab_POInstructions)
            Me.TabControlControl_PODetails.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlControl_PODetails.ForeColor = System.Drawing.Color.Black
            Me.TabControlControl_PODetails.Location = New System.Drawing.Point(0, 320)
            Me.TabControlControl_PODetails.Name = "TabControlControl_PODetails"
            Me.TabControlControl_PODetails.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlControl_PODetails.SelectedTabIndex = 3
            Me.TabControlControl_PODetails.Size = New System.Drawing.Size(791, 214)
            Me.TabControlControl_PODetails.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlControl_PODetails.TabIndex = 2
            Me.TabControlControl_PODetails.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlControl_PODetails.Tabs.Add(Me.TabItemPODetails_DetailsTab)
            Me.TabControlControl_PODetails.Tabs.Add(Me.TabItemPODetails_POInstructionsTab)
            Me.TabControlControl_PODetails.Tabs.Add(Me.TabItemPODetails_ShippingInstructionsTab)
            Me.TabControlControl_PODetails.Tabs.Add(Me.TabItemPODetails_FooterCommentsTab)
            Me.TabControlControl_PODetails.Text = "TabControl1"
            '
            'TabControlPanelDetailsTab_Details
            '
            Me.TabControlPanelDetailsTab_Details.Controls.Add(Me.DataGridViewDetails_PODetails)
            Me.TabControlPanelDetailsTab_Details.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelDetailsTab_Details.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelDetailsTab_Details.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelDetailsTab_Details.Name = "TabControlPanelDetailsTab_Details"
            Me.TabControlPanelDetailsTab_Details.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelDetailsTab_Details.Size = New System.Drawing.Size(791, 187)
            Me.TabControlPanelDetailsTab_Details.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelDetailsTab_Details.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDetailsTab_Details.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelDetailsTab_Details.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelDetailsTab_Details.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelDetailsTab_Details.Style.GradientAngle = 90
            Me.TabControlPanelDetailsTab_Details.TabIndex = 1
            Me.TabControlPanelDetailsTab_Details.TabItem = Me.TabItemPODetails_DetailsTab
            '
            'DataGridViewDetails_PODetails
            '
            Me.DataGridViewDetails_PODetails.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewDetails_PODetails.AllowDragAndDrop = False
            Me.DataGridViewDetails_PODetails.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewDetails_PODetails.AllowSelectGroupHeaderRow = True
            Me.DataGridViewDetails_PODetails.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewDetails_PODetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewDetails_PODetails.AutoFilterLookupColumns = False
            Me.DataGridViewDetails_PODetails.AutoloadRepositoryDatasource = True
            Me.DataGridViewDetails_PODetails.AutoUpdateViewCaption = True
            Me.DataGridViewDetails_PODetails.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewDetails_PODetails.DataSource = Nothing
            Me.DataGridViewDetails_PODetails.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewDetails_PODetails.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewDetails_PODetails.ItemDescription = "Item(s)"
            Me.DataGridViewDetails_PODetails.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewDetails_PODetails.MultiSelect = True
            Me.DataGridViewDetails_PODetails.Name = "DataGridViewDetails_PODetails"
            Me.DataGridViewDetails_PODetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewDetails_PODetails.RunStandardValidation = True
            Me.DataGridViewDetails_PODetails.ShowColumnMenuOnRightClick = False
            Me.DataGridViewDetails_PODetails.ShowSelectDeselectAllButtons = False
            Me.DataGridViewDetails_PODetails.Size = New System.Drawing.Size(783, 179)
            Me.DataGridViewDetails_PODetails.TabIndex = 0
            Me.DataGridViewDetails_PODetails.UseEmbeddedNavigator = False
            Me.DataGridViewDetails_PODetails.ViewCaptionHeight = -1
            '
            'TabItemPODetails_DetailsTab
            '
            Me.TabItemPODetails_DetailsTab.AttachedControl = Me.TabControlPanelDetailsTab_Details
            Me.TabItemPODetails_DetailsTab.Name = "TabItemPODetails_DetailsTab"
            Me.TabItemPODetails_DetailsTab.Text = "Details"
            '
            'TabControlPanelFooterCommentsTab_FooterComments
            '
            Me.TabControlPanelFooterCommentsTab_FooterComments.Controls.Add(Me.RadioButtonControlFooter_UseCustom)
            Me.TabControlPanelFooterCommentsTab_FooterComments.Controls.Add(Me.RadioButtonControlFooter_UseStandardComment)
            Me.TabControlPanelFooterCommentsTab_FooterComments.Controls.Add(Me.RadioButtonControlFooter_UseAgencyDefined)
            Me.TabControlPanelFooterCommentsTab_FooterComments.Controls.Add(Me.TextBoxFooterComments_FooterComments)
            Me.TabControlPanelFooterCommentsTab_FooterComments.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelFooterCommentsTab_FooterComments.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelFooterCommentsTab_FooterComments.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelFooterCommentsTab_FooterComments.Name = "TabControlPanelFooterCommentsTab_FooterComments"
            Me.TabControlPanelFooterCommentsTab_FooterComments.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelFooterCommentsTab_FooterComments.Size = New System.Drawing.Size(791, 187)
            Me.TabControlPanelFooterCommentsTab_FooterComments.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelFooterCommentsTab_FooterComments.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelFooterCommentsTab_FooterComments.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelFooterCommentsTab_FooterComments.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelFooterCommentsTab_FooterComments.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelFooterCommentsTab_FooterComments.Style.GradientAngle = 90
            Me.TabControlPanelFooterCommentsTab_FooterComments.TabIndex = 4
            Me.TabControlPanelFooterCommentsTab_FooterComments.TabItem = Me.TabItemPODetails_FooterCommentsTab
            '
            'RadioButtonControlFooter_UseCustom
            '
            Me.RadioButtonControlFooter_UseCustom.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlFooter_UseCustom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlFooter_UseCustom.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlFooter_UseCustom.Location = New System.Drawing.Point(332, 4)
            Me.RadioButtonControlFooter_UseCustom.Name = "RadioButtonControlFooter_UseCustom"
            Me.RadioButtonControlFooter_UseCustom.SecurityEnabled = True
            Me.RadioButtonControlFooter_UseCustom.Size = New System.Drawing.Size(158, 20)
            Me.RadioButtonControlFooter_UseCustom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlFooter_UseCustom.TabIndex = 3
            Me.RadioButtonControlFooter_UseCustom.TabOnEnter = True
            Me.RadioButtonControlFooter_UseCustom.TabStop = False
            Me.RadioButtonControlFooter_UseCustom.Text = "Use Customized Text"
            '
            'RadioButtonControlFooter_UseStandardComment
            '
            Me.RadioButtonControlFooter_UseStandardComment.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlFooter_UseStandardComment.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlFooter_UseStandardComment.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlFooter_UseStandardComment.Location = New System.Drawing.Point(168, 4)
            Me.RadioButtonControlFooter_UseStandardComment.Name = "RadioButtonControlFooter_UseStandardComment"
            Me.RadioButtonControlFooter_UseStandardComment.SecurityEnabled = True
            Me.RadioButtonControlFooter_UseStandardComment.Size = New System.Drawing.Size(158, 20)
            Me.RadioButtonControlFooter_UseStandardComment.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlFooter_UseStandardComment.TabIndex = 2
            Me.RadioButtonControlFooter_UseStandardComment.TabOnEnter = True
            Me.RadioButtonControlFooter_UseStandardComment.TabStop = False
            Me.RadioButtonControlFooter_UseStandardComment.Text = "Use Standard Comment"
            '
            'RadioButtonControlFooter_UseAgencyDefined
            '
            Me.RadioButtonControlFooter_UseAgencyDefined.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlFooter_UseAgencyDefined.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlFooter_UseAgencyDefined.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlFooter_UseAgencyDefined.Location = New System.Drawing.Point(4, 4)
            Me.RadioButtonControlFooter_UseAgencyDefined.Name = "RadioButtonControlFooter_UseAgencyDefined"
            Me.RadioButtonControlFooter_UseAgencyDefined.SecurityEnabled = True
            Me.RadioButtonControlFooter_UseAgencyDefined.Size = New System.Drawing.Size(158, 20)
            Me.RadioButtonControlFooter_UseAgencyDefined.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlFooter_UseAgencyDefined.TabIndex = 1
            Me.RadioButtonControlFooter_UseAgencyDefined.TabOnEnter = True
            Me.RadioButtonControlFooter_UseAgencyDefined.TabStop = False
            Me.RadioButtonControlFooter_UseAgencyDefined.Text = "Use Agency Defined Text"
            '
            'TextBoxFooterComments_FooterComments
            '
            Me.TextBoxFooterComments_FooterComments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxFooterComments_FooterComments.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxFooterComments_FooterComments.Border.Class = "TextBoxBorder"
            Me.TextBoxFooterComments_FooterComments.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxFooterComments_FooterComments.CheckSpellingOnValidate = False
            Me.TextBoxFooterComments_FooterComments.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxFooterComments_FooterComments.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxFooterComments_FooterComments.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxFooterComments_FooterComments.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxFooterComments_FooterComments.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxFooterComments_FooterComments.FocusHighlightEnabled = True
            Me.TextBoxFooterComments_FooterComments.ForeColor = System.Drawing.Color.Black
            Me.TextBoxFooterComments_FooterComments.Location = New System.Drawing.Point(4, 30)
            Me.TextBoxFooterComments_FooterComments.MaxFileSize = CType(0, Long)
            Me.TextBoxFooterComments_FooterComments.Multiline = True
            Me.TextBoxFooterComments_FooterComments.Name = "TextBoxFooterComments_FooterComments"
            Me.TextBoxFooterComments_FooterComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.TextBoxFooterComments_FooterComments.SecurityEnabled = True
            Me.TextBoxFooterComments_FooterComments.ShowSpellCheckCompleteMessage = True
            Me.TextBoxFooterComments_FooterComments.Size = New System.Drawing.Size(783, 127)
            Me.TextBoxFooterComments_FooterComments.StartingFolderName = Nothing
            Me.TextBoxFooterComments_FooterComments.TabIndex = 4
            Me.TextBoxFooterComments_FooterComments.TabOnEnter = False
            '
            'TabItemPODetails_FooterCommentsTab
            '
            Me.TabItemPODetails_FooterCommentsTab.AttachedControl = Me.TabControlPanelFooterCommentsTab_FooterComments
            Me.TabItemPODetails_FooterCommentsTab.Name = "TabItemPODetails_FooterCommentsTab"
            Me.TabItemPODetails_FooterCommentsTab.Text = "Footer Comments"
            '
            'TabControlPanelShippingInstructionsTab_ShippingInstructions
            '
            Me.TabControlPanelShippingInstructionsTab_ShippingInstructions.Controls.Add(Me.TextBoxShippingInstructions_ShippingInstructions)
            Me.TabControlPanelShippingInstructionsTab_ShippingInstructions.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelShippingInstructionsTab_ShippingInstructions.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelShippingInstructionsTab_ShippingInstructions.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelShippingInstructionsTab_ShippingInstructions.Name = "TabControlPanelShippingInstructionsTab_ShippingInstructions"
            Me.TabControlPanelShippingInstructionsTab_ShippingInstructions.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelShippingInstructionsTab_ShippingInstructions.Size = New System.Drawing.Size(791, 187)
            Me.TabControlPanelShippingInstructionsTab_ShippingInstructions.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelShippingInstructionsTab_ShippingInstructions.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelShippingInstructionsTab_ShippingInstructions.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelShippingInstructionsTab_ShippingInstructions.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelShippingInstructionsTab_ShippingInstructions.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelShippingInstructionsTab_ShippingInstructions.Style.GradientAngle = 90
            Me.TabControlPanelShippingInstructionsTab_ShippingInstructions.TabIndex = 3
            Me.TabControlPanelShippingInstructionsTab_ShippingInstructions.TabItem = Me.TabItemPODetails_ShippingInstructionsTab
            '
            'TextBoxShippingInstructions_ShippingInstructions
            '
            Me.TextBoxShippingInstructions_ShippingInstructions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxShippingInstructions_ShippingInstructions.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxShippingInstructions_ShippingInstructions.Border.Class = "TextBoxBorder"
            Me.TextBoxShippingInstructions_ShippingInstructions.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxShippingInstructions_ShippingInstructions.CheckSpellingOnValidate = False
            Me.TextBoxShippingInstructions_ShippingInstructions.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxShippingInstructions_ShippingInstructions.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxShippingInstructions_ShippingInstructions.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxShippingInstructions_ShippingInstructions.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxShippingInstructions_ShippingInstructions.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxShippingInstructions_ShippingInstructions.FocusHighlightEnabled = True
            Me.TextBoxShippingInstructions_ShippingInstructions.ForeColor = System.Drawing.Color.Black
            Me.TextBoxShippingInstructions_ShippingInstructions.Location = New System.Drawing.Point(4, 4)
            Me.TextBoxShippingInstructions_ShippingInstructions.MaxFileSize = CType(0, Long)
            Me.TextBoxShippingInstructions_ShippingInstructions.Multiline = True
            Me.TextBoxShippingInstructions_ShippingInstructions.Name = "TextBoxShippingInstructions_ShippingInstructions"
            Me.TextBoxShippingInstructions_ShippingInstructions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.TextBoxShippingInstructions_ShippingInstructions.SecurityEnabled = True
            Me.TextBoxShippingInstructions_ShippingInstructions.ShowSpellCheckCompleteMessage = True
            Me.TextBoxShippingInstructions_ShippingInstructions.Size = New System.Drawing.Size(783, 179)
            Me.TextBoxShippingInstructions_ShippingInstructions.StartingFolderName = Nothing
            Me.TextBoxShippingInstructions_ShippingInstructions.TabIndex = 1
            Me.TextBoxShippingInstructions_ShippingInstructions.TabOnEnter = False
            '
            'TabItemPODetails_ShippingInstructionsTab
            '
            Me.TabItemPODetails_ShippingInstructionsTab.AttachedControl = Me.TabControlPanelShippingInstructionsTab_ShippingInstructions
            Me.TabItemPODetails_ShippingInstructionsTab.Name = "TabItemPODetails_ShippingInstructionsTab"
            Me.TabItemPODetails_ShippingInstructionsTab.Text = "Shipping Instructions"
            '
            'TabControlPanelPOInstructionsTab_POInstructions
            '
            Me.TabControlPanelPOInstructionsTab_POInstructions.Controls.Add(Me.TextBoxPOInstructions_Instructions)
            Me.TabControlPanelPOInstructionsTab_POInstructions.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelPOInstructionsTab_POInstructions.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelPOInstructionsTab_POInstructions.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelPOInstructionsTab_POInstructions.Name = "TabControlPanelPOInstructionsTab_POInstructions"
            Me.TabControlPanelPOInstructionsTab_POInstructions.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelPOInstructionsTab_POInstructions.Size = New System.Drawing.Size(791, 187)
            Me.TabControlPanelPOInstructionsTab_POInstructions.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelPOInstructionsTab_POInstructions.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelPOInstructionsTab_POInstructions.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelPOInstructionsTab_POInstructions.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelPOInstructionsTab_POInstructions.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelPOInstructionsTab_POInstructions.Style.GradientAngle = 90
            Me.TabControlPanelPOInstructionsTab_POInstructions.TabIndex = 2
            Me.TabControlPanelPOInstructionsTab_POInstructions.TabItem = Me.TabItemPODetails_POInstructionsTab
            '
            'TextBoxPOInstructions_Instructions
            '
            Me.TextBoxPOInstructions_Instructions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxPOInstructions_Instructions.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxPOInstructions_Instructions.Border.Class = "TextBoxBorder"
            Me.TextBoxPOInstructions_Instructions.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPOInstructions_Instructions.CheckSpellingOnValidate = False
            Me.TextBoxPOInstructions_Instructions.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPOInstructions_Instructions.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxPOInstructions_Instructions.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxPOInstructions_Instructions.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPOInstructions_Instructions.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPOInstructions_Instructions.FocusHighlightEnabled = True
            Me.TextBoxPOInstructions_Instructions.ForeColor = System.Drawing.Color.Black
            Me.TextBoxPOInstructions_Instructions.Location = New System.Drawing.Point(4, 4)
            Me.TextBoxPOInstructions_Instructions.MaxFileSize = CType(0, Long)
            Me.TextBoxPOInstructions_Instructions.Multiline = True
            Me.TextBoxPOInstructions_Instructions.Name = "TextBoxPOInstructions_Instructions"
            Me.TextBoxPOInstructions_Instructions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.TextBoxPOInstructions_Instructions.SecurityEnabled = True
            Me.TextBoxPOInstructions_Instructions.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPOInstructions_Instructions.Size = New System.Drawing.Size(783, 179)
            Me.TextBoxPOInstructions_Instructions.StartingFolderName = Nothing
            Me.TextBoxPOInstructions_Instructions.TabIndex = 0
            Me.TextBoxPOInstructions_Instructions.TabOnEnter = False
            '
            'TabItemPODetails_POInstructionsTab
            '
            Me.TabItemPODetails_POInstructionsTab.AttachedControl = Me.TabControlPanelPOInstructionsTab_POInstructions
            Me.TabItemPODetails_POInstructionsTab.Name = "TabItemPODetails_POInstructionsTab"
            Me.TabItemPODetails_POInstructionsTab.Text = "P.O. Instructions"
            '
            'NumericInputControl_Revision
            '
            Me.NumericInputControl_Revision.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputControl_Revision.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.NumericInputControl_Revision.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Short]
            Me.NumericInputControl_Revision.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputControl_Revision.EnterMoveNextControl = True
            Me.NumericInputControl_Revision.Location = New System.Drawing.Point(730, 30)
            Me.NumericInputControl_Revision.Name = "NumericInputControl_Revision"
            Me.NumericInputControl_Revision.Properties.AllowMouseWheel = False
            Me.NumericInputControl_Revision.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputControl_Revision.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputControl_Revision.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputControl_Revision.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_Revision.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputControl_Revision.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_Revision.Properties.IsFloatValue = False
            Me.NumericInputControl_Revision.Properties.Mask.EditMask = "f0"
            Me.NumericInputControl_Revision.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputControl_Revision.Properties.MaxValue = New Decimal(New Integer() {32767, 0, 0, 0})
            Me.NumericInputControl_Revision.Properties.MinValue = New Decimal(New Integer() {32768, 0, 0, -2147483648})
            Me.NumericInputControl_Revision.SecurityEnabled = True
            Me.NumericInputControl_Revision.Size = New System.Drawing.Size(57, 20)
            Me.NumericInputControl_Revision.TabIndex = 5
            '
            'PurchaseOrderControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.TabControlControl_PODetails)
            Me.Controls.Add(Me.ExpandablePanelControl_General)
            Me.Name = "PurchaseOrderControl"
            Me.Size = New System.Drawing.Size(791, 534)
            Me.ExpandablePanelControl_General.ResumeLayout(False)
            CType(Me.SearchableComboBoxGeneralInfo_VendorContact.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxGeneralInfo_IssuedTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxGeneralInfo_IssuedBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBox1View, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputControl_POTotal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputControl_EmployeeLimit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerControl_DueDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerControl_DateIssued, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.TabControlControl_PODetails, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlControl_PODetails.ResumeLayout(False)
            Me.TabControlPanelDetailsTab_Details.ResumeLayout(False)
            Me.TabControlPanelFooterCommentsTab_FooterComments.ResumeLayout(False)
            Me.TabControlPanelShippingInstructionsTab_ShippingInstructions.ResumeLayout(False)
            Me.TabControlPanelPOInstructionsTab_POInstructions.ResumeLayout(False)
            CType(Me.NumericInputControl_Revision.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents LabelControl_IssuedBy As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelControl_PONumber As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxControl_PONumber As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelControl_IssuedTo As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxControl_WorkComplete As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelControl_Description As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxControl_Description As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelControl_Revision As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents AddressControlControl_VendorAddress As AdvantageFramework.WinForm.Presentation.Controls.AddressControl
        Friend WithEvents LabelControl_DateIssued As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelControl_DueDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelControl_VendorContact As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelControl_EmailAddress As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelControl_EmployeeLimit As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelControl_POTotal As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DataGridViewDetails_PODetails As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents DateTimePickerControl_DateIssued As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerControl_DueDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents TextBoxControl_EmailAddress As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents NumericInputControl_EmployeeLimit As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputControl_POTotal As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents ExpandablePanelControl_General As DevComponents.DotNetBar.ExpandablePanel
        Friend WithEvents TabControlControl_PODetails As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelDetailsTab_Details As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemPODetails_DetailsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelPOInstructionsTab_POInstructions As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TextBoxPOInstructions_Instructions As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxShippingInstructions_ShippingInstructions As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TabItemPODetails_POInstructionsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelShippingInstructionsTab_ShippingInstructions As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemPODetails_ShippingInstructionsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelFooterCommentsTab_FooterComments As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TextBoxFooterComments_FooterComments As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TabItemPODetails_FooterCommentsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents SearchableComboBoxGeneralInfo_IssuedBy As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBox1View As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxGeneralInfo_IssuedTo As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView1 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxGeneralInfo_VendorContact As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView2 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelGeneralInfo_ModifiedDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGeneralInfo_ModifiedBy As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGeneralInfo_ModifiedByLabel As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGeneralInfo_ModifiedDateLabel As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGeneralInfo_Message As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxControl_MessageDetails As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents RadioButtonControlFooter_UseCustom As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlFooter_UseStandardComment As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlFooter_UseAgencyDefined As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents Label_Void As Label
        Friend WithEvents TextBoxGeneralInfo_PayTo As TextBox
        Friend WithEvents LabelGeneralInfo_PayTo As Label
        Friend WithEvents NumericInputControl_Revision As NumericInput
    End Class

End Namespace
