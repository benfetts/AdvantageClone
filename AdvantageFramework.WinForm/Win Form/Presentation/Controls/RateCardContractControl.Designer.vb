Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class RateCardContractControl
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RateCardContractControl))
            Me.TabControlControl_GeneralInformation = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelGeneralInformationTab_GeneralInformation = New DevComponents.DotNetBar.TabControlPanel()
            Me.SearchableComboBoxGeneralInformation_Vendor = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView1 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.GroupBoxGeneralInformation_DefaultInformation = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.NumericInputDefaultInformation_VendorCommissionPercentage = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputDefaultInformation_SpaceCloseDays = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputDefaultInformation_MaterialCloseDays = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelDefaultInformation_SpaceCloseDays = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelDefaultInformation_MaterialCloseDays = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelDefaultInformation_VendorCommissionPercentage = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DateTimePickerGeneralInformation_DateTo = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelGeneralInformation_To = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneralInformation_EffectiveDates = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxGeneralInformation_Type = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.LabelType_Client = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.RadioButtonType_ContractRateCard = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonType_StandardRateCard = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.LabelGeneralInformation_Vendor = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxGeneralInformation_Inactive = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.DateTimePickerGeneralInformation_DateFrom = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelGeneralInformation_Description = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxGeneralInformation_Description = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelGeneralInformation_RateCard = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxGeneralInformation_Code = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TabItemRateCardDetails_GeneralInformationTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelCommentsTab_Comments = New DevComponents.DotNetBar.TabControlPanel()
            Me.LabelComments_ContractInfo = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelComments_MiscInfo = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelComments_RateInfo = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelComments_CloseInfo = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxComments_ContractInfo = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxComments_MiscInfo = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxComments_RateInfo = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxComments_CloseInfo = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxComments_PositionInfo = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelComments_PositionInfo = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemRateCardDetails_CommentsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelOtherRateInformationTab_OtherRateInformation = New DevComponents.DotNetBar.TabControlPanel()
            Me.GroupBoxOtherRateInformation_RateCharges = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.LabelRateCharges_PremiumPercent = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelRateCharges_PositionPercent = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.NumericInputRateCharges_PremiumPercent = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputRateCharges_PositionPercent = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputRateCharges_BleedPercent = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelRateCharges_BleedPercent = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxOtherRateInformation_FlatChargesDiscounts = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.NumericInputFlatChargesDiscounts_NetDiscount = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelFlatChargesDiscounts_NetCharge = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxFlatChargesDiscounts_NetDiscountDescription = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelFlatChargesDiscounts_NetDiscount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxFlatChargesDiscounts_NetChargeDescription = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.NumericInputFlatChargesDiscounts_NetCharge = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.TabItemRateCardDetails_OtherRateInformationTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelColorChargesTab_ColorCharges = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewColorCharges_ColorCharges = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemRateCardDetails_ColorChargesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelRateDetailTab_RateDetail = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewRateDetail_RateDetails = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemRateCardDetails_RateDetailTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.SearchableComboBoxType_Client = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView2 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            CType(Me.TabControlControl_GeneralInformation, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlControl_GeneralInformation.SuspendLayout()
            Me.TabControlPanelGeneralInformationTab_GeneralInformation.SuspendLayout()
            CType(Me.SearchableComboBoxGeneralInformation_Vendor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxGeneralInformation_DefaultInformation, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxGeneralInformation_DefaultInformation.SuspendLayout()
            CType(Me.NumericInputDefaultInformation_VendorCommissionPercentage.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputDefaultInformation_SpaceCloseDays.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputDefaultInformation_MaterialCloseDays.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerGeneralInformation_DateTo, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxGeneralInformation_Type, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxGeneralInformation_Type.SuspendLayout()
            CType(Me.DateTimePickerGeneralInformation_DateFrom, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelCommentsTab_Comments.SuspendLayout()
            Me.TabControlPanelOtherRateInformationTab_OtherRateInformation.SuspendLayout()
            CType(Me.GroupBoxOtherRateInformation_RateCharges, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxOtherRateInformation_RateCharges.SuspendLayout()
            CType(Me.NumericInputRateCharges_PremiumPercent.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputRateCharges_PositionPercent.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputRateCharges_BleedPercent.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxOtherRateInformation_FlatChargesDiscounts, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxOtherRateInformation_FlatChargesDiscounts.SuspendLayout()
            CType(Me.NumericInputFlatChargesDiscounts_NetDiscount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputFlatChargesDiscounts_NetCharge.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelColorChargesTab_ColorCharges.SuspendLayout()
            Me.TabControlPanelRateDetailTab_RateDetail.SuspendLayout()
            CType(Me.SearchableComboBoxType_Client.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'TabControlControl_GeneralInformation
            '
            Me.TabControlControl_GeneralInformation.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
            Me.TabControlControl_GeneralInformation.CanReorderTabs = False
            Me.TabControlControl_GeneralInformation.Controls.Add(Me.TabControlPanelGeneralInformationTab_GeneralInformation)
            Me.TabControlControl_GeneralInformation.Controls.Add(Me.TabControlPanelCommentsTab_Comments)
            Me.TabControlControl_GeneralInformation.Controls.Add(Me.TabControlPanelOtherRateInformationTab_OtherRateInformation)
            Me.TabControlControl_GeneralInformation.Controls.Add(Me.TabControlPanelColorChargesTab_ColorCharges)
            Me.TabControlControl_GeneralInformation.Controls.Add(Me.TabControlPanelRateDetailTab_RateDetail)
            Me.TabControlControl_GeneralInformation.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlControl_GeneralInformation.Location = New System.Drawing.Point(0, 0)
            Me.TabControlControl_GeneralInformation.Name = "TabControlControl_GeneralInformation"
            Me.TabControlControl_GeneralInformation.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlControl_GeneralInformation.SelectedTabIndex = 0
            Me.TabControlControl_GeneralInformation.Size = New System.Drawing.Size(774, 525)
            Me.TabControlControl_GeneralInformation.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlControl_GeneralInformation.TabIndex = 0
            Me.TabControlControl_GeneralInformation.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlControl_GeneralInformation.Tabs.Add(Me.TabItemRateCardDetails_GeneralInformationTab)
            Me.TabControlControl_GeneralInformation.Tabs.Add(Me.TabItemRateCardDetails_RateDetailTab)
            Me.TabControlControl_GeneralInformation.Tabs.Add(Me.TabItemRateCardDetails_ColorChargesTab)
            Me.TabControlControl_GeneralInformation.Tabs.Add(Me.TabItemRateCardDetails_OtherRateInformationTab)
            Me.TabControlControl_GeneralInformation.Tabs.Add(Me.TabItemRateCardDetails_CommentsTab)
            '
            'TabControlPanelGeneralInformationTab_GeneralInformation
            '
            Me.TabControlPanelGeneralInformationTab_GeneralInformation.Controls.Add(Me.SearchableComboBoxGeneralInformation_Vendor)
            Me.TabControlPanelGeneralInformationTab_GeneralInformation.Controls.Add(Me.GroupBoxGeneralInformation_DefaultInformation)
            Me.TabControlPanelGeneralInformationTab_GeneralInformation.Controls.Add(Me.DateTimePickerGeneralInformation_DateTo)
            Me.TabControlPanelGeneralInformationTab_GeneralInformation.Controls.Add(Me.LabelGeneralInformation_To)
            Me.TabControlPanelGeneralInformationTab_GeneralInformation.Controls.Add(Me.LabelGeneralInformation_EffectiveDates)
            Me.TabControlPanelGeneralInformationTab_GeneralInformation.Controls.Add(Me.GroupBoxGeneralInformation_Type)
            Me.TabControlPanelGeneralInformationTab_GeneralInformation.Controls.Add(Me.LabelGeneralInformation_Vendor)
            Me.TabControlPanelGeneralInformationTab_GeneralInformation.Controls.Add(Me.CheckBoxGeneralInformation_Inactive)
            Me.TabControlPanelGeneralInformationTab_GeneralInformation.Controls.Add(Me.DateTimePickerGeneralInformation_DateFrom)
            Me.TabControlPanelGeneralInformationTab_GeneralInformation.Controls.Add(Me.LabelGeneralInformation_Description)
            Me.TabControlPanelGeneralInformationTab_GeneralInformation.Controls.Add(Me.TextBoxGeneralInformation_Description)
            Me.TabControlPanelGeneralInformationTab_GeneralInformation.Controls.Add(Me.LabelGeneralInformation_RateCard)
            Me.TabControlPanelGeneralInformationTab_GeneralInformation.Controls.Add(Me.TextBoxGeneralInformation_Code)
            Me.TabControlPanelGeneralInformationTab_GeneralInformation.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelGeneralInformationTab_GeneralInformation.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelGeneralInformationTab_GeneralInformation.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelGeneralInformationTab_GeneralInformation.Name = "TabControlPanelGeneralInformationTab_GeneralInformation"
            Me.TabControlPanelGeneralInformationTab_GeneralInformation.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelGeneralInformationTab_GeneralInformation.Size = New System.Drawing.Size(774, 498)
            Me.TabControlPanelGeneralInformationTab_GeneralInformation.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelGeneralInformationTab_GeneralInformation.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelGeneralInformationTab_GeneralInformation.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelGeneralInformationTab_GeneralInformation.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelGeneralInformationTab_GeneralInformation.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelGeneralInformationTab_GeneralInformation.Style.GradientAngle = 90
            Me.TabControlPanelGeneralInformationTab_GeneralInformation.TabIndex = 0
            Me.TabControlPanelGeneralInformationTab_GeneralInformation.TabItem = Me.TabItemRateCardDetails_GeneralInformationTab
            '
            'SearchableComboBoxGeneralInformation_Vendor
            '
            Me.SearchableComboBoxGeneralInformation_Vendor.ActiveFilterString = ""
            Me.SearchableComboBoxGeneralInformation_Vendor.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxGeneralInformation_Vendor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxGeneralInformation_Vendor.AutoFillMode = False
            Me.SearchableComboBoxGeneralInformation_Vendor.BookmarkingEnabled = False
            Me.SearchableComboBoxGeneralInformation_Vendor.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Vendor
            Me.SearchableComboBoxGeneralInformation_Vendor.DataSource = Nothing
            Me.SearchableComboBoxGeneralInformation_Vendor.DisableMouseWheel = False
            Me.SearchableComboBoxGeneralInformation_Vendor.DisplayName = ""
            Me.SearchableComboBoxGeneralInformation_Vendor.EnterMoveNextControl = True
            Me.SearchableComboBoxGeneralInformation_Vendor.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxGeneralInformation_Vendor.Location = New System.Drawing.Point(74, 4)
            Me.SearchableComboBoxGeneralInformation_Vendor.Name = "SearchableComboBoxGeneralInformation_Vendor"
            Me.SearchableComboBoxGeneralInformation_Vendor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxGeneralInformation_Vendor.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxGeneralInformation_Vendor.Properties.NullText = "Select Vendor"
            Me.SearchableComboBoxGeneralInformation_Vendor.Properties.ValueMember = "Code"
            Me.SearchableComboBoxGeneralInformation_Vendor.Properties.View = Me.GridView1
            Me.SearchableComboBoxGeneralInformation_Vendor.SecurityEnabled = True
            Me.SearchableComboBoxGeneralInformation_Vendor.SelectedValue = Nothing
            Me.SearchableComboBoxGeneralInformation_Vendor.Size = New System.Drawing.Size(618, 20)
            Me.SearchableComboBoxGeneralInformation_Vendor.TabIndex = 1
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
            'GroupBoxGeneralInformation_DefaultInformation
            '
            Me.GroupBoxGeneralInformation_DefaultInformation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxGeneralInformation_DefaultInformation.Controls.Add(Me.NumericInputDefaultInformation_VendorCommissionPercentage)
            Me.GroupBoxGeneralInformation_DefaultInformation.Controls.Add(Me.NumericInputDefaultInformation_SpaceCloseDays)
            Me.GroupBoxGeneralInformation_DefaultInformation.Controls.Add(Me.NumericInputDefaultInformation_MaterialCloseDays)
            Me.GroupBoxGeneralInformation_DefaultInformation.Controls.Add(Me.LabelDefaultInformation_SpaceCloseDays)
            Me.GroupBoxGeneralInformation_DefaultInformation.Controls.Add(Me.LabelDefaultInformation_MaterialCloseDays)
            Me.GroupBoxGeneralInformation_DefaultInformation.Controls.Add(Me.LabelDefaultInformation_VendorCommissionPercentage)
            Me.GroupBoxGeneralInformation_DefaultInformation.Location = New System.Drawing.Point(4, 177)
            Me.GroupBoxGeneralInformation_DefaultInformation.Name = "GroupBoxGeneralInformation_DefaultInformation"
            Me.GroupBoxGeneralInformation_DefaultInformation.Size = New System.Drawing.Size(766, 102)
            Me.GroupBoxGeneralInformation_DefaultInformation.TabIndex = 12
            Me.GroupBoxGeneralInformation_DefaultInformation.Text = "Default Information"
            '
            'NumericInputDefaultInformation_VendorCommissionPercentage
            '
            Me.NumericInputDefaultInformation_VendorCommissionPercentage.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDefaultInformation_VendorCommissionPercentage.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputDefaultInformation_VendorCommissionPercentage.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDefaultInformation_VendorCommissionPercentage.EnterMoveNextControl = True
            Me.NumericInputDefaultInformation_VendorCommissionPercentage.Location = New System.Drawing.Point(196, 25)
            Me.NumericInputDefaultInformation_VendorCommissionPercentage.Name = "NumericInputDefaultInformation_VendorCommissionPercentage"
            Me.NumericInputDefaultInformation_VendorCommissionPercentage.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputDefaultInformation_VendorCommissionPercentage.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputDefaultInformation_VendorCommissionPercentage.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDefaultInformation_VendorCommissionPercentage.Properties.EditFormat.FormatString = "f"
            Me.NumericInputDefaultInformation_VendorCommissionPercentage.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDefaultInformation_VendorCommissionPercentage.Properties.Mask.EditMask = "f"
            Me.NumericInputDefaultInformation_VendorCommissionPercentage.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDefaultInformation_VendorCommissionPercentage.SecurityEnabled = True
            Me.NumericInputDefaultInformation_VendorCommissionPercentage.Size = New System.Drawing.Size(88, 20)
            Me.NumericInputDefaultInformation_VendorCommissionPercentage.TabIndex = 1
            '
            'NumericInputDefaultInformation_SpaceCloseDays
            '
            Me.NumericInputDefaultInformation_SpaceCloseDays.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDefaultInformation_SpaceCloseDays.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputDefaultInformation_SpaceCloseDays.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDefaultInformation_SpaceCloseDays.EnterMoveNextControl = True
            Me.NumericInputDefaultInformation_SpaceCloseDays.Location = New System.Drawing.Point(196, 77)
            Me.NumericInputDefaultInformation_SpaceCloseDays.Name = "NumericInputDefaultInformation_SpaceCloseDays"
            Me.NumericInputDefaultInformation_SpaceCloseDays.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputDefaultInformation_SpaceCloseDays.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputDefaultInformation_SpaceCloseDays.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDefaultInformation_SpaceCloseDays.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputDefaultInformation_SpaceCloseDays.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDefaultInformation_SpaceCloseDays.Properties.IsFloatValue = False
            Me.NumericInputDefaultInformation_SpaceCloseDays.Properties.Mask.EditMask = "f0"
            Me.NumericInputDefaultInformation_SpaceCloseDays.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDefaultInformation_SpaceCloseDays.Properties.MaxLength = 11
            Me.NumericInputDefaultInformation_SpaceCloseDays.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputDefaultInformation_SpaceCloseDays.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputDefaultInformation_SpaceCloseDays.SecurityEnabled = True
            Me.NumericInputDefaultInformation_SpaceCloseDays.Size = New System.Drawing.Size(88, 20)
            Me.NumericInputDefaultInformation_SpaceCloseDays.TabIndex = 5
            '
            'NumericInputDefaultInformation_MaterialCloseDays
            '
            Me.NumericInputDefaultInformation_MaterialCloseDays.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDefaultInformation_MaterialCloseDays.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputDefaultInformation_MaterialCloseDays.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDefaultInformation_MaterialCloseDays.EnterMoveNextControl = True
            Me.NumericInputDefaultInformation_MaterialCloseDays.Location = New System.Drawing.Point(196, 51)
            Me.NumericInputDefaultInformation_MaterialCloseDays.Name = "NumericInputDefaultInformation_MaterialCloseDays"
            Me.NumericInputDefaultInformation_MaterialCloseDays.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputDefaultInformation_MaterialCloseDays.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputDefaultInformation_MaterialCloseDays.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDefaultInformation_MaterialCloseDays.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputDefaultInformation_MaterialCloseDays.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDefaultInformation_MaterialCloseDays.Properties.IsFloatValue = False
            Me.NumericInputDefaultInformation_MaterialCloseDays.Properties.Mask.EditMask = "f0"
            Me.NumericInputDefaultInformation_MaterialCloseDays.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDefaultInformation_MaterialCloseDays.Properties.MaxLength = 11
            Me.NumericInputDefaultInformation_MaterialCloseDays.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputDefaultInformation_MaterialCloseDays.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputDefaultInformation_MaterialCloseDays.SecurityEnabled = True
            Me.NumericInputDefaultInformation_MaterialCloseDays.Size = New System.Drawing.Size(88, 20)
            Me.NumericInputDefaultInformation_MaterialCloseDays.TabIndex = 3
            '
            'LabelDefaultInformation_SpaceCloseDays
            '
            Me.LabelDefaultInformation_SpaceCloseDays.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDefaultInformation_SpaceCloseDays.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDefaultInformation_SpaceCloseDays.Location = New System.Drawing.Point(5, 77)
            Me.LabelDefaultInformation_SpaceCloseDays.Name = "LabelDefaultInformation_SpaceCloseDays"
            Me.LabelDefaultInformation_SpaceCloseDays.Size = New System.Drawing.Size(185, 20)
            Me.LabelDefaultInformation_SpaceCloseDays.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDefaultInformation_SpaceCloseDays.TabIndex = 4
            Me.LabelDefaultInformation_SpaceCloseDays.Text = "Space Close Days:"
            '
            'LabelDefaultInformation_MaterialCloseDays
            '
            Me.LabelDefaultInformation_MaterialCloseDays.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDefaultInformation_MaterialCloseDays.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDefaultInformation_MaterialCloseDays.Location = New System.Drawing.Point(5, 51)
            Me.LabelDefaultInformation_MaterialCloseDays.Name = "LabelDefaultInformation_MaterialCloseDays"
            Me.LabelDefaultInformation_MaterialCloseDays.Size = New System.Drawing.Size(185, 20)
            Me.LabelDefaultInformation_MaterialCloseDays.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDefaultInformation_MaterialCloseDays.TabIndex = 2
            Me.LabelDefaultInformation_MaterialCloseDays.Text = "Material Close Days:"
            '
            'LabelDefaultInformation_VendorCommissionPercentage
            '
            Me.LabelDefaultInformation_VendorCommissionPercentage.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDefaultInformation_VendorCommissionPercentage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDefaultInformation_VendorCommissionPercentage.Location = New System.Drawing.Point(5, 25)
            Me.LabelDefaultInformation_VendorCommissionPercentage.Name = "LabelDefaultInformation_VendorCommissionPercentage"
            Me.LabelDefaultInformation_VendorCommissionPercentage.Size = New System.Drawing.Size(185, 20)
            Me.LabelDefaultInformation_VendorCommissionPercentage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDefaultInformation_VendorCommissionPercentage.TabIndex = 0
            Me.LabelDefaultInformation_VendorCommissionPercentage.Text = "Vendor Commission Percentage:"
            '
            'DateTimePickerGeneralInformation_DateTo
            '
            Me.DateTimePickerGeneralInformation_DateTo.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerGeneralInformation_DateTo.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerGeneralInformation_DateTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneralInformation_DateTo.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerGeneralInformation_DateTo.ButtonDropDown.Visible = True
            Me.DateTimePickerGeneralInformation_DateTo.ButtonFreeText.Checked = True
            Me.DateTimePickerGeneralInformation_DateTo.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerGeneralInformation_DateTo.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerGeneralInformation_DateTo.DisplayName = ""
            Me.DateTimePickerGeneralInformation_DateTo.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerGeneralInformation_DateTo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerGeneralInformation_DateTo.FocusHighlightEnabled = True
            Me.DateTimePickerGeneralInformation_DateTo.FreeTextEntryMode = True
            Me.DateTimePickerGeneralInformation_DateTo.IsPopupCalendarOpen = False
            Me.DateTimePickerGeneralInformation_DateTo.Location = New System.Drawing.Point(229, 151)
            Me.DateTimePickerGeneralInformation_DateTo.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerGeneralInformation_DateTo.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerGeneralInformation_DateTo.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerGeneralInformation_DateTo.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerGeneralInformation_DateTo.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneralInformation_DateTo.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerGeneralInformation_DateTo.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerGeneralInformation_DateTo.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerGeneralInformation_DateTo.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerGeneralInformation_DateTo.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerGeneralInformation_DateTo.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerGeneralInformation_DateTo.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerGeneralInformation_DateTo.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneralInformation_DateTo.MonthCalendar.DisplayMonth = New Date(2012, 5, 1, 0, 0, 0, 0)
            Me.DateTimePickerGeneralInformation_DateTo.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerGeneralInformation_DateTo.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerGeneralInformation_DateTo.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerGeneralInformation_DateTo.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerGeneralInformation_DateTo.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerGeneralInformation_DateTo.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneralInformation_DateTo.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerGeneralInformation_DateTo.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerGeneralInformation_DateTo.Name = "DateTimePickerGeneralInformation_DateTo"
            Me.DateTimePickerGeneralInformation_DateTo.ReadOnly = False
            Me.DateTimePickerGeneralInformation_DateTo.Size = New System.Drawing.Size(88, 20)
            Me.DateTimePickerGeneralInformation_DateTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerGeneralInformation_DateTo.TabIndex = 11
            Me.DateTimePickerGeneralInformation_DateTo.TabOnEnter = True
            Me.DateTimePickerGeneralInformation_DateTo.Value = New Date(2015, 7, 27, 16, 43, 57, 393)
            '
            'LabelGeneralInformation_To
            '
            Me.LabelGeneralInformation_To.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneralInformation_To.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneralInformation_To.Location = New System.Drawing.Point(203, 151)
            Me.LabelGeneralInformation_To.Name = "LabelGeneralInformation_To"
            Me.LabelGeneralInformation_To.Size = New System.Drawing.Size(20, 20)
            Me.LabelGeneralInformation_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneralInformation_To.TabIndex = 10
            Me.LabelGeneralInformation_To.Text = "To:"
            '
            'LabelGeneralInformation_EffectiveDates
            '
            Me.LabelGeneralInformation_EffectiveDates.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneralInformation_EffectiveDates.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneralInformation_EffectiveDates.Location = New System.Drawing.Point(4, 151)
            Me.LabelGeneralInformation_EffectiveDates.Name = "LabelGeneralInformation_EffectiveDates"
            Me.LabelGeneralInformation_EffectiveDates.Size = New System.Drawing.Size(96, 20)
            Me.LabelGeneralInformation_EffectiveDates.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneralInformation_EffectiveDates.TabIndex = 8
            Me.LabelGeneralInformation_EffectiveDates.Text = "Effective Dates:"
            '
            'GroupBoxGeneralInformation_Type
            '
            Me.GroupBoxGeneralInformation_Type.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxGeneralInformation_Type.Controls.Add(Me.SearchableComboBoxType_Client)
            Me.GroupBoxGeneralInformation_Type.Controls.Add(Me.LabelType_Client)
            Me.GroupBoxGeneralInformation_Type.Controls.Add(Me.RadioButtonType_ContractRateCard)
            Me.GroupBoxGeneralInformation_Type.Controls.Add(Me.RadioButtonType_StandardRateCard)
            Me.GroupBoxGeneralInformation_Type.Location = New System.Drawing.Point(4, 56)
            Me.GroupBoxGeneralInformation_Type.Name = "GroupBoxGeneralInformation_Type"
            Me.GroupBoxGeneralInformation_Type.Size = New System.Drawing.Size(766, 88)
            Me.GroupBoxGeneralInformation_Type.TabIndex = 7
            Me.GroupBoxGeneralInformation_Type.Text = "Type:"
            '
            'LabelType_Client
            '
            Me.LabelType_Client.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelType_Client.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelType_Client.Location = New System.Drawing.Point(4, 51)
            Me.LabelType_Client.Name = "LabelType_Client"
            Me.LabelType_Client.Size = New System.Drawing.Size(60, 20)
            Me.LabelType_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelType_Client.TabIndex = 2
            Me.LabelType_Client.Text = "Client:"
            '
            'RadioButtonType_ContractRateCard
            '
            Me.RadioButtonType_ContractRateCard.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonType_ContractRateCard.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonType_ContractRateCard.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonType_ContractRateCard.CheckValue = "0"
            Me.RadioButtonType_ContractRateCard.CheckValueChecked = "3"
            Me.RadioButtonType_ContractRateCard.CheckValueUnchecked = "0"
            Me.RadioButtonType_ContractRateCard.Location = New System.Drawing.Point(196, 25)
            Me.RadioButtonType_ContractRateCard.Name = "RadioButtonType_ContractRateCard"
            Me.RadioButtonType_ContractRateCard.SecurityEnabled = True
            Me.RadioButtonType_ContractRateCard.Size = New System.Drawing.Size(163, 20)
            Me.RadioButtonType_ContractRateCard.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonType_ContractRateCard.TabIndex = 1
            Me.RadioButtonType_ContractRateCard.TabOnEnter = True
            Me.RadioButtonType_ContractRateCard.TabStop = False
            Me.RadioButtonType_ContractRateCard.Text = "Contract Rate Card"
            '
            'RadioButtonType_StandardRateCard
            '
            Me.RadioButtonType_StandardRateCard.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonType_StandardRateCard.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonType_StandardRateCard.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonType_StandardRateCard.Checked = True
            Me.RadioButtonType_StandardRateCard.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonType_StandardRateCard.CheckValue = "1"
            Me.RadioButtonType_StandardRateCard.CheckValueChecked = "1"
            Me.RadioButtonType_StandardRateCard.CheckValueUnchecked = "0"
            Me.RadioButtonType_StandardRateCard.Location = New System.Drawing.Point(70, 25)
            Me.RadioButtonType_StandardRateCard.Name = "RadioButtonType_StandardRateCard"
            Me.RadioButtonType_StandardRateCard.SecurityEnabled = True
            Me.RadioButtonType_StandardRateCard.Size = New System.Drawing.Size(120, 20)
            Me.RadioButtonType_StandardRateCard.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonType_StandardRateCard.TabIndex = 0
            Me.RadioButtonType_StandardRateCard.TabOnEnter = True
            Me.RadioButtonType_StandardRateCard.Text = "Standard Rate Card"
            '
            'LabelGeneralInformation_Vendor
            '
            Me.LabelGeneralInformation_Vendor.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneralInformation_Vendor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneralInformation_Vendor.Location = New System.Drawing.Point(4, 4)
            Me.LabelGeneralInformation_Vendor.Name = "LabelGeneralInformation_Vendor"
            Me.LabelGeneralInformation_Vendor.Size = New System.Drawing.Size(64, 20)
            Me.LabelGeneralInformation_Vendor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneralInformation_Vendor.TabIndex = 0
            Me.LabelGeneralInformation_Vendor.Text = "Vendor:"
            '
            'CheckBoxGeneralInformation_Inactive
            '
            Me.CheckBoxGeneralInformation_Inactive.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxGeneralInformation_Inactive.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxGeneralInformation_Inactive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxGeneralInformation_Inactive.CheckValue = 0
            Me.CheckBoxGeneralInformation_Inactive.CheckValueChecked = 1
            Me.CheckBoxGeneralInformation_Inactive.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxGeneralInformation_Inactive.CheckValueUnchecked = 0
            Me.CheckBoxGeneralInformation_Inactive.ChildControls = CType(resources.GetObject("CheckBoxGeneralInformation_Inactive.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxGeneralInformation_Inactive.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxGeneralInformation_Inactive.Location = New System.Drawing.Point(698, 4)
            Me.CheckBoxGeneralInformation_Inactive.Name = "CheckBoxGeneralInformation_Inactive"
            Me.CheckBoxGeneralInformation_Inactive.OldestSibling = Nothing
            Me.CheckBoxGeneralInformation_Inactive.SecurityEnabled = True
            Me.CheckBoxGeneralInformation_Inactive.SiblingControls = CType(resources.GetObject("CheckBoxGeneralInformation_Inactive.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxGeneralInformation_Inactive.Size = New System.Drawing.Size(72, 20)
            Me.CheckBoxGeneralInformation_Inactive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxGeneralInformation_Inactive.TabIndex = 2
            Me.CheckBoxGeneralInformation_Inactive.TabOnEnter = True
            Me.CheckBoxGeneralInformation_Inactive.Text = "Inactive"
            '
            'DateTimePickerGeneralInformation_DateFrom
            '
            Me.DateTimePickerGeneralInformation_DateFrom.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerGeneralInformation_DateFrom.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerGeneralInformation_DateFrom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneralInformation_DateFrom.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerGeneralInformation_DateFrom.ButtonDropDown.Visible = True
            Me.DateTimePickerGeneralInformation_DateFrom.ButtonFreeText.Checked = True
            Me.DateTimePickerGeneralInformation_DateFrom.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerGeneralInformation_DateFrom.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerGeneralInformation_DateFrom.DisplayName = ""
            Me.DateTimePickerGeneralInformation_DateFrom.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerGeneralInformation_DateFrom.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerGeneralInformation_DateFrom.FocusHighlightEnabled = True
            Me.DateTimePickerGeneralInformation_DateFrom.FreeTextEntryMode = True
            Me.DateTimePickerGeneralInformation_DateFrom.IsPopupCalendarOpen = False
            Me.DateTimePickerGeneralInformation_DateFrom.Location = New System.Drawing.Point(106, 151)
            Me.DateTimePickerGeneralInformation_DateFrom.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerGeneralInformation_DateFrom.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerGeneralInformation_DateFrom.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerGeneralInformation_DateFrom.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerGeneralInformation_DateFrom.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneralInformation_DateFrom.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerGeneralInformation_DateFrom.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerGeneralInformation_DateFrom.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerGeneralInformation_DateFrom.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerGeneralInformation_DateFrom.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerGeneralInformation_DateFrom.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerGeneralInformation_DateFrom.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerGeneralInformation_DateFrom.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneralInformation_DateFrom.MonthCalendar.DisplayMonth = New Date(2012, 5, 1, 0, 0, 0, 0)
            Me.DateTimePickerGeneralInformation_DateFrom.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerGeneralInformation_DateFrom.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerGeneralInformation_DateFrom.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerGeneralInformation_DateFrom.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerGeneralInformation_DateFrom.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerGeneralInformation_DateFrom.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneralInformation_DateFrom.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerGeneralInformation_DateFrom.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerGeneralInformation_DateFrom.Name = "DateTimePickerGeneralInformation_DateFrom"
            Me.DateTimePickerGeneralInformation_DateFrom.ReadOnly = False
            Me.DateTimePickerGeneralInformation_DateFrom.Size = New System.Drawing.Size(88, 20)
            Me.DateTimePickerGeneralInformation_DateFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerGeneralInformation_DateFrom.TabIndex = 9
            Me.DateTimePickerGeneralInformation_DateFrom.TabOnEnter = True
            Me.DateTimePickerGeneralInformation_DateFrom.Value = New Date(2015, 7, 27, 16, 43, 57, 509)
            '
            'LabelGeneralInformation_Description
            '
            Me.LabelGeneralInformation_Description.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneralInformation_Description.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneralInformation_Description.Location = New System.Drawing.Point(161, 30)
            Me.LabelGeneralInformation_Description.Name = "LabelGeneralInformation_Description"
            Me.LabelGeneralInformation_Description.Size = New System.Drawing.Size(70, 20)
            Me.LabelGeneralInformation_Description.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneralInformation_Description.TabIndex = 5
            Me.LabelGeneralInformation_Description.Text = "Description:"
            '
            'TextBoxGeneralInformation_Description
            '
            Me.TextBoxGeneralInformation_Description.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxGeneralInformation_Description.Border.Class = "TextBoxBorder"
            Me.TextBoxGeneralInformation_Description.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxGeneralInformation_Description.CheckSpellingOnValidate = False
            Me.TextBoxGeneralInformation_Description.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxGeneralInformation_Description.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxGeneralInformation_Description.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxGeneralInformation_Description.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxGeneralInformation_Description.FocusHighlightEnabled = True
            Me.TextBoxGeneralInformation_Description.Location = New System.Drawing.Point(237, 30)
            Me.TextBoxGeneralInformation_Description.MaxFileSize = CType(0, Long)
            Me.TextBoxGeneralInformation_Description.Name = "TextBoxGeneralInformation_Description"
            Me.TextBoxGeneralInformation_Description.SecurityEnabled = True
            Me.TextBoxGeneralInformation_Description.ShowSpellCheckCompleteMessage = True
            Me.TextBoxGeneralInformation_Description.Size = New System.Drawing.Size(533, 20)
            Me.TextBoxGeneralInformation_Description.StartingFolderName = Nothing
            Me.TextBoxGeneralInformation_Description.TabIndex = 6
            Me.TextBoxGeneralInformation_Description.TabOnEnter = True
            '
            'LabelGeneralInformation_RateCard
            '
            Me.LabelGeneralInformation_RateCard.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneralInformation_RateCard.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneralInformation_RateCard.Location = New System.Drawing.Point(4, 30)
            Me.LabelGeneralInformation_RateCard.Name = "LabelGeneralInformation_RateCard"
            Me.LabelGeneralInformation_RateCard.Size = New System.Drawing.Size(64, 20)
            Me.LabelGeneralInformation_RateCard.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneralInformation_RateCard.TabIndex = 3
            Me.LabelGeneralInformation_RateCard.Text = "Rate Card:"
            '
            'TextBoxGeneralInformation_Code
            '
            Me.TextBoxGeneralInformation_Code.BackColor = System.Drawing.SystemColors.Window
            '
            '
            '
            Me.TextBoxGeneralInformation_Code.Border.Class = "TextBoxBorder"
            Me.TextBoxGeneralInformation_Code.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxGeneralInformation_Code.CheckSpellingOnValidate = False
            Me.TextBoxGeneralInformation_Code.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxGeneralInformation_Code.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxGeneralInformation_Code.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxGeneralInformation_Code.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxGeneralInformation_Code.FocusHighlightEnabled = True
            Me.TextBoxGeneralInformation_Code.Location = New System.Drawing.Point(74, 30)
            Me.TextBoxGeneralInformation_Code.MaxFileSize = CType(0, Long)
            Me.TextBoxGeneralInformation_Code.Name = "TextBoxGeneralInformation_Code"
            Me.TextBoxGeneralInformation_Code.SecurityEnabled = True
            Me.TextBoxGeneralInformation_Code.ShowSpellCheckCompleteMessage = True
            Me.TextBoxGeneralInformation_Code.Size = New System.Drawing.Size(81, 20)
            Me.TextBoxGeneralInformation_Code.StartingFolderName = Nothing
            Me.TextBoxGeneralInformation_Code.TabIndex = 4
            Me.TextBoxGeneralInformation_Code.TabOnEnter = True
            '
            'TabItemRateCardDetails_GeneralInformationTab
            '
            Me.TabItemRateCardDetails_GeneralInformationTab.AttachedControl = Me.TabControlPanelGeneralInformationTab_GeneralInformation
            Me.TabItemRateCardDetails_GeneralInformationTab.Name = "TabItemRateCardDetails_GeneralInformationTab"
            Me.TabItemRateCardDetails_GeneralInformationTab.Text = "General Information"
            '
            'TabControlPanelCommentsTab_Comments
            '
            Me.TabControlPanelCommentsTab_Comments.Controls.Add(Me.LabelComments_ContractInfo)
            Me.TabControlPanelCommentsTab_Comments.Controls.Add(Me.LabelComments_MiscInfo)
            Me.TabControlPanelCommentsTab_Comments.Controls.Add(Me.LabelComments_RateInfo)
            Me.TabControlPanelCommentsTab_Comments.Controls.Add(Me.LabelComments_CloseInfo)
            Me.TabControlPanelCommentsTab_Comments.Controls.Add(Me.TextBoxComments_ContractInfo)
            Me.TabControlPanelCommentsTab_Comments.Controls.Add(Me.TextBoxComments_MiscInfo)
            Me.TabControlPanelCommentsTab_Comments.Controls.Add(Me.TextBoxComments_RateInfo)
            Me.TabControlPanelCommentsTab_Comments.Controls.Add(Me.TextBoxComments_CloseInfo)
            Me.TabControlPanelCommentsTab_Comments.Controls.Add(Me.TextBoxComments_PositionInfo)
            Me.TabControlPanelCommentsTab_Comments.Controls.Add(Me.LabelComments_PositionInfo)
            Me.TabControlPanelCommentsTab_Comments.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelCommentsTab_Comments.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelCommentsTab_Comments.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelCommentsTab_Comments.Name = "TabControlPanelCommentsTab_Comments"
            Me.TabControlPanelCommentsTab_Comments.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelCommentsTab_Comments.Size = New System.Drawing.Size(774, 498)
            Me.TabControlPanelCommentsTab_Comments.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelCommentsTab_Comments.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelCommentsTab_Comments.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelCommentsTab_Comments.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelCommentsTab_Comments.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelCommentsTab_Comments.Style.GradientAngle = 90
            Me.TabControlPanelCommentsTab_Comments.TabIndex = 4
            Me.TabControlPanelCommentsTab_Comments.TabItem = Me.TabItemRateCardDetails_CommentsTab
            '
            'LabelComments_ContractInfo
            '
            Me.LabelComments_ContractInfo.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelComments_ContractInfo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelComments_ContractInfo.Location = New System.Drawing.Point(5, 392)
            Me.LabelComments_ContractInfo.Name = "LabelComments_ContractInfo"
            Me.LabelComments_ContractInfo.Size = New System.Drawing.Size(70, 20)
            Me.LabelComments_ContractInfo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelComments_ContractInfo.TabIndex = 14
            Me.LabelComments_ContractInfo.Text = "Contract Info:"
            '
            'LabelComments_MiscInfo
            '
            Me.LabelComments_MiscInfo.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelComments_MiscInfo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelComments_MiscInfo.Location = New System.Drawing.Point(4, 296)
            Me.LabelComments_MiscInfo.Name = "LabelComments_MiscInfo"
            Me.LabelComments_MiscInfo.Size = New System.Drawing.Size(70, 20)
            Me.LabelComments_MiscInfo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelComments_MiscInfo.TabIndex = 13
            Me.LabelComments_MiscInfo.Text = "Misc Info:"
            '
            'LabelComments_RateInfo
            '
            Me.LabelComments_RateInfo.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelComments_RateInfo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelComments_RateInfo.Location = New System.Drawing.Point(5, 199)
            Me.LabelComments_RateInfo.Name = "LabelComments_RateInfo"
            Me.LabelComments_RateInfo.Size = New System.Drawing.Size(70, 20)
            Me.LabelComments_RateInfo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelComments_RateInfo.TabIndex = 12
            Me.LabelComments_RateInfo.Text = "Rate Info:"
            '
            'LabelComments_CloseInfo
            '
            Me.LabelComments_CloseInfo.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelComments_CloseInfo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelComments_CloseInfo.Location = New System.Drawing.Point(5, 102)
            Me.LabelComments_CloseInfo.Name = "LabelComments_CloseInfo"
            Me.LabelComments_CloseInfo.Size = New System.Drawing.Size(70, 20)
            Me.LabelComments_CloseInfo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelComments_CloseInfo.TabIndex = 11
            Me.LabelComments_CloseInfo.Text = "Close Info:"
            '
            'TextBoxComments_ContractInfo
            '
            Me.TextBoxComments_ContractInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxComments_ContractInfo.Border.Class = "TextBoxBorder"
            Me.TextBoxComments_ContractInfo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxComments_ContractInfo.CheckSpellingOnValidate = False
            Me.TextBoxComments_ContractInfo.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxComments_ContractInfo.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxComments_ContractInfo.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxComments_ContractInfo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxComments_ContractInfo.FocusHighlightEnabled = True
            Me.TextBoxComments_ContractInfo.Location = New System.Drawing.Point(80, 393)
            Me.TextBoxComments_ContractInfo.MaxFileSize = CType(0, Long)
            Me.TextBoxComments_ContractInfo.Multiline = True
            Me.TextBoxComments_ContractInfo.Name = "TextBoxComments_ContractInfo"
            Me.TextBoxComments_ContractInfo.SecurityEnabled = True
            Me.TextBoxComments_ContractInfo.ShowSpellCheckCompleteMessage = True
            Me.TextBoxComments_ContractInfo.Size = New System.Drawing.Size(690, 91)
            Me.TextBoxComments_ContractInfo.StartingFolderName = Nothing
            Me.TextBoxComments_ContractInfo.TabIndex = 10
            Me.TextBoxComments_ContractInfo.TabOnEnter = True
            '
            'TextBoxComments_MiscInfo
            '
            Me.TextBoxComments_MiscInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxComments_MiscInfo.Border.Class = "TextBoxBorder"
            Me.TextBoxComments_MiscInfo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxComments_MiscInfo.CheckSpellingOnValidate = False
            Me.TextBoxComments_MiscInfo.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxComments_MiscInfo.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxComments_MiscInfo.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxComments_MiscInfo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxComments_MiscInfo.FocusHighlightEnabled = True
            Me.TextBoxComments_MiscInfo.Location = New System.Drawing.Point(80, 296)
            Me.TextBoxComments_MiscInfo.MaxFileSize = CType(0, Long)
            Me.TextBoxComments_MiscInfo.Multiline = True
            Me.TextBoxComments_MiscInfo.Name = "TextBoxComments_MiscInfo"
            Me.TextBoxComments_MiscInfo.SecurityEnabled = True
            Me.TextBoxComments_MiscInfo.ShowSpellCheckCompleteMessage = True
            Me.TextBoxComments_MiscInfo.Size = New System.Drawing.Size(690, 91)
            Me.TextBoxComments_MiscInfo.StartingFolderName = Nothing
            Me.TextBoxComments_MiscInfo.TabIndex = 9
            Me.TextBoxComments_MiscInfo.TabOnEnter = True
            '
            'TextBoxComments_RateInfo
            '
            Me.TextBoxComments_RateInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxComments_RateInfo.Border.Class = "TextBoxBorder"
            Me.TextBoxComments_RateInfo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxComments_RateInfo.CheckSpellingOnValidate = False
            Me.TextBoxComments_RateInfo.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxComments_RateInfo.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxComments_RateInfo.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxComments_RateInfo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxComments_RateInfo.FocusHighlightEnabled = True
            Me.TextBoxComments_RateInfo.Location = New System.Drawing.Point(80, 199)
            Me.TextBoxComments_RateInfo.MaxFileSize = CType(0, Long)
            Me.TextBoxComments_RateInfo.Multiline = True
            Me.TextBoxComments_RateInfo.Name = "TextBoxComments_RateInfo"
            Me.TextBoxComments_RateInfo.SecurityEnabled = True
            Me.TextBoxComments_RateInfo.ShowSpellCheckCompleteMessage = True
            Me.TextBoxComments_RateInfo.Size = New System.Drawing.Size(690, 91)
            Me.TextBoxComments_RateInfo.StartingFolderName = Nothing
            Me.TextBoxComments_RateInfo.TabIndex = 8
            Me.TextBoxComments_RateInfo.TabOnEnter = True
            '
            'TextBoxComments_CloseInfo
            '
            Me.TextBoxComments_CloseInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxComments_CloseInfo.Border.Class = "TextBoxBorder"
            Me.TextBoxComments_CloseInfo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxComments_CloseInfo.CheckSpellingOnValidate = False
            Me.TextBoxComments_CloseInfo.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxComments_CloseInfo.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxComments_CloseInfo.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxComments_CloseInfo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxComments_CloseInfo.FocusHighlightEnabled = True
            Me.TextBoxComments_CloseInfo.Location = New System.Drawing.Point(81, 102)
            Me.TextBoxComments_CloseInfo.MaxFileSize = CType(0, Long)
            Me.TextBoxComments_CloseInfo.Multiline = True
            Me.TextBoxComments_CloseInfo.Name = "TextBoxComments_CloseInfo"
            Me.TextBoxComments_CloseInfo.SecurityEnabled = True
            Me.TextBoxComments_CloseInfo.ShowSpellCheckCompleteMessage = True
            Me.TextBoxComments_CloseInfo.Size = New System.Drawing.Size(690, 91)
            Me.TextBoxComments_CloseInfo.StartingFolderName = Nothing
            Me.TextBoxComments_CloseInfo.TabIndex = 7
            Me.TextBoxComments_CloseInfo.TabOnEnter = True
            '
            'TextBoxComments_PositionInfo
            '
            Me.TextBoxComments_PositionInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxComments_PositionInfo.Border.Class = "TextBoxBorder"
            Me.TextBoxComments_PositionInfo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxComments_PositionInfo.CheckSpellingOnValidate = False
            Me.TextBoxComments_PositionInfo.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxComments_PositionInfo.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxComments_PositionInfo.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxComments_PositionInfo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxComments_PositionInfo.FocusHighlightEnabled = True
            Me.TextBoxComments_PositionInfo.Location = New System.Drawing.Point(80, 5)
            Me.TextBoxComments_PositionInfo.MaxFileSize = CType(0, Long)
            Me.TextBoxComments_PositionInfo.Multiline = True
            Me.TextBoxComments_PositionInfo.Name = "TextBoxComments_PositionInfo"
            Me.TextBoxComments_PositionInfo.SecurityEnabled = True
            Me.TextBoxComments_PositionInfo.ShowSpellCheckCompleteMessage = True
            Me.TextBoxComments_PositionInfo.Size = New System.Drawing.Size(690, 91)
            Me.TextBoxComments_PositionInfo.StartingFolderName = Nothing
            Me.TextBoxComments_PositionInfo.TabIndex = 6
            Me.TextBoxComments_PositionInfo.TabOnEnter = True
            '
            'LabelComments_PositionInfo
            '
            Me.LabelComments_PositionInfo.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelComments_PositionInfo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelComments_PositionInfo.Location = New System.Drawing.Point(4, 4)
            Me.LabelComments_PositionInfo.Name = "LabelComments_PositionInfo"
            Me.LabelComments_PositionInfo.Size = New System.Drawing.Size(70, 20)
            Me.LabelComments_PositionInfo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelComments_PositionInfo.TabIndex = 5
            Me.LabelComments_PositionInfo.Text = "Position Info:"
            '
            'TabItemRateCardDetails_CommentsTab
            '
            Me.TabItemRateCardDetails_CommentsTab.AttachedControl = Me.TabControlPanelCommentsTab_Comments
            Me.TabItemRateCardDetails_CommentsTab.Name = "TabItemRateCardDetails_CommentsTab"
            Me.TabItemRateCardDetails_CommentsTab.Text = "Comments"
            '
            'TabControlPanelOtherRateInformationTab_OtherRateInformation
            '
            Me.TabControlPanelOtherRateInformationTab_OtherRateInformation.Controls.Add(Me.GroupBoxOtherRateInformation_RateCharges)
            Me.TabControlPanelOtherRateInformationTab_OtherRateInformation.Controls.Add(Me.GroupBoxOtherRateInformation_FlatChargesDiscounts)
            Me.TabControlPanelOtherRateInformationTab_OtherRateInformation.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelOtherRateInformationTab_OtherRateInformation.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelOtherRateInformationTab_OtherRateInformation.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelOtherRateInformationTab_OtherRateInformation.Name = "TabControlPanelOtherRateInformationTab_OtherRateInformation"
            Me.TabControlPanelOtherRateInformationTab_OtherRateInformation.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelOtherRateInformationTab_OtherRateInformation.Size = New System.Drawing.Size(774, 498)
            Me.TabControlPanelOtherRateInformationTab_OtherRateInformation.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelOtherRateInformationTab_OtherRateInformation.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelOtherRateInformationTab_OtherRateInformation.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelOtherRateInformationTab_OtherRateInformation.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelOtherRateInformationTab_OtherRateInformation.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelOtherRateInformationTab_OtherRateInformation.Style.GradientAngle = 90
            Me.TabControlPanelOtherRateInformationTab_OtherRateInformation.TabIndex = 3
            Me.TabControlPanelOtherRateInformationTab_OtherRateInformation.TabItem = Me.TabItemRateCardDetails_OtherRateInformationTab
            '
            'GroupBoxOtherRateInformation_RateCharges
            '
            Me.GroupBoxOtherRateInformation_RateCharges.Controls.Add(Me.LabelRateCharges_PremiumPercent)
            Me.GroupBoxOtherRateInformation_RateCharges.Controls.Add(Me.LabelRateCharges_PositionPercent)
            Me.GroupBoxOtherRateInformation_RateCharges.Controls.Add(Me.NumericInputRateCharges_PremiumPercent)
            Me.GroupBoxOtherRateInformation_RateCharges.Controls.Add(Me.NumericInputRateCharges_PositionPercent)
            Me.GroupBoxOtherRateInformation_RateCharges.Controls.Add(Me.NumericInputRateCharges_BleedPercent)
            Me.GroupBoxOtherRateInformation_RateCharges.Controls.Add(Me.LabelRateCharges_BleedPercent)
            Me.GroupBoxOtherRateInformation_RateCharges.Location = New System.Drawing.Point(4, 86)
            Me.GroupBoxOtherRateInformation_RateCharges.Name = "GroupBoxOtherRateInformation_RateCharges"
            Me.GroupBoxOtherRateInformation_RateCharges.Size = New System.Drawing.Size(766, 102)
            Me.GroupBoxOtherRateInformation_RateCharges.TabIndex = 6
            Me.GroupBoxOtherRateInformation_RateCharges.Text = "Rate Charges"
            '
            'LabelRateCharges_PremiumPercent
            '
            Me.LabelRateCharges_PremiumPercent.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRateCharges_PremiumPercent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRateCharges_PremiumPercent.Location = New System.Drawing.Point(6, 77)
            Me.LabelRateCharges_PremiumPercent.Name = "LabelRateCharges_PremiumPercent"
            Me.LabelRateCharges_PremiumPercent.Size = New System.Drawing.Size(80, 20)
            Me.LabelRateCharges_PremiumPercent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRateCharges_PremiumPercent.TabIndex = 10
            Me.LabelRateCharges_PremiumPercent.Text = "Premium Pct:"
            '
            'LabelRateCharges_PositionPercent
            '
            Me.LabelRateCharges_PositionPercent.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRateCharges_PositionPercent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRateCharges_PositionPercent.Location = New System.Drawing.Point(6, 51)
            Me.LabelRateCharges_PositionPercent.Name = "LabelRateCharges_PositionPercent"
            Me.LabelRateCharges_PositionPercent.Size = New System.Drawing.Size(80, 20)
            Me.LabelRateCharges_PositionPercent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRateCharges_PositionPercent.TabIndex = 9
            Me.LabelRateCharges_PositionPercent.Text = "Position Pct:"
            '
            'NumericInputRateCharges_PremiumPercent
            '
            Me.NumericInputRateCharges_PremiumPercent.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputRateCharges_PremiumPercent.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Default]
            Me.NumericInputRateCharges_PremiumPercent.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputRateCharges_PremiumPercent.EnterMoveNextControl = True
            Me.NumericInputRateCharges_PremiumPercent.Location = New System.Drawing.Point(92, 77)
            Me.NumericInputRateCharges_PremiumPercent.Name = "NumericInputRateCharges_PremiumPercent"
            Me.NumericInputRateCharges_PremiumPercent.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputRateCharges_PremiumPercent.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputRateCharges_PremiumPercent.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputRateCharges_PremiumPercent.Properties.EditFormat.FormatString = "f"
            Me.NumericInputRateCharges_PremiumPercent.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputRateCharges_PremiumPercent.Properties.Mask.EditMask = "f"
            Me.NumericInputRateCharges_PremiumPercent.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputRateCharges_PremiumPercent.SecurityEnabled = True
            Me.NumericInputRateCharges_PremiumPercent.Size = New System.Drawing.Size(129, 20)
            Me.NumericInputRateCharges_PremiumPercent.TabIndex = 8
            '
            'NumericInputRateCharges_PositionPercent
            '
            Me.NumericInputRateCharges_PositionPercent.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputRateCharges_PositionPercent.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Default]
            Me.NumericInputRateCharges_PositionPercent.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputRateCharges_PositionPercent.EnterMoveNextControl = True
            Me.NumericInputRateCharges_PositionPercent.Location = New System.Drawing.Point(92, 51)
            Me.NumericInputRateCharges_PositionPercent.Name = "NumericInputRateCharges_PositionPercent"
            Me.NumericInputRateCharges_PositionPercent.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputRateCharges_PositionPercent.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputRateCharges_PositionPercent.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputRateCharges_PositionPercent.Properties.EditFormat.FormatString = "f"
            Me.NumericInputRateCharges_PositionPercent.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputRateCharges_PositionPercent.Properties.Mask.EditMask = "f"
            Me.NumericInputRateCharges_PositionPercent.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputRateCharges_PositionPercent.SecurityEnabled = True
            Me.NumericInputRateCharges_PositionPercent.Size = New System.Drawing.Size(129, 20)
            Me.NumericInputRateCharges_PositionPercent.TabIndex = 7
            '
            'NumericInputRateCharges_BleedPercent
            '
            Me.NumericInputRateCharges_BleedPercent.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputRateCharges_BleedPercent.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Default]
            Me.NumericInputRateCharges_BleedPercent.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputRateCharges_BleedPercent.EnterMoveNextControl = True
            Me.NumericInputRateCharges_BleedPercent.Location = New System.Drawing.Point(92, 25)
            Me.NumericInputRateCharges_BleedPercent.Name = "NumericInputRateCharges_BleedPercent"
            Me.NumericInputRateCharges_BleedPercent.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputRateCharges_BleedPercent.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputRateCharges_BleedPercent.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputRateCharges_BleedPercent.Properties.EditFormat.FormatString = "f"
            Me.NumericInputRateCharges_BleedPercent.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputRateCharges_BleedPercent.Properties.Mask.EditMask = "f"
            Me.NumericInputRateCharges_BleedPercent.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputRateCharges_BleedPercent.SecurityEnabled = True
            Me.NumericInputRateCharges_BleedPercent.Size = New System.Drawing.Size(129, 20)
            Me.NumericInputRateCharges_BleedPercent.TabIndex = 6
            '
            'LabelRateCharges_BleedPercent
            '
            Me.LabelRateCharges_BleedPercent.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRateCharges_BleedPercent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRateCharges_BleedPercent.Location = New System.Drawing.Point(6, 25)
            Me.LabelRateCharges_BleedPercent.Name = "LabelRateCharges_BleedPercent"
            Me.LabelRateCharges_BleedPercent.Size = New System.Drawing.Size(80, 20)
            Me.LabelRateCharges_BleedPercent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRateCharges_BleedPercent.TabIndex = 5
            Me.LabelRateCharges_BleedPercent.Text = "Bleed Pct:"
            '
            'GroupBoxOtherRateInformation_FlatChargesDiscounts
            '
            Me.GroupBoxOtherRateInformation_FlatChargesDiscounts.Controls.Add(Me.NumericInputFlatChargesDiscounts_NetDiscount)
            Me.GroupBoxOtherRateInformation_FlatChargesDiscounts.Controls.Add(Me.LabelFlatChargesDiscounts_NetCharge)
            Me.GroupBoxOtherRateInformation_FlatChargesDiscounts.Controls.Add(Me.TextBoxFlatChargesDiscounts_NetDiscountDescription)
            Me.GroupBoxOtherRateInformation_FlatChargesDiscounts.Controls.Add(Me.LabelFlatChargesDiscounts_NetDiscount)
            Me.GroupBoxOtherRateInformation_FlatChargesDiscounts.Controls.Add(Me.TextBoxFlatChargesDiscounts_NetChargeDescription)
            Me.GroupBoxOtherRateInformation_FlatChargesDiscounts.Controls.Add(Me.NumericInputFlatChargesDiscounts_NetCharge)
            Me.GroupBoxOtherRateInformation_FlatChargesDiscounts.Location = New System.Drawing.Point(4, 4)
            Me.GroupBoxOtherRateInformation_FlatChargesDiscounts.Name = "GroupBoxOtherRateInformation_FlatChargesDiscounts"
            Me.GroupBoxOtherRateInformation_FlatChargesDiscounts.Size = New System.Drawing.Size(766, 76)
            Me.GroupBoxOtherRateInformation_FlatChargesDiscounts.TabIndex = 5
            Me.GroupBoxOtherRateInformation_FlatChargesDiscounts.Text = "Flat Charges && Discounts"
            '
            'NumericInputFlatChargesDiscounts_NetDiscount
            '
            Me.NumericInputFlatChargesDiscounts_NetDiscount.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputFlatChargesDiscounts_NetDiscount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Default]
            Me.NumericInputFlatChargesDiscounts_NetDiscount.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputFlatChargesDiscounts_NetDiscount.EnterMoveNextControl = True
            Me.NumericInputFlatChargesDiscounts_NetDiscount.Location = New System.Drawing.Point(92, 51)
            Me.NumericInputFlatChargesDiscounts_NetDiscount.Name = "NumericInputFlatChargesDiscounts_NetDiscount"
            Me.NumericInputFlatChargesDiscounts_NetDiscount.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputFlatChargesDiscounts_NetDiscount.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputFlatChargesDiscounts_NetDiscount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputFlatChargesDiscounts_NetDiscount.Properties.EditFormat.FormatString = "f"
            Me.NumericInputFlatChargesDiscounts_NetDiscount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputFlatChargesDiscounts_NetDiscount.Properties.Mask.EditMask = "f"
            Me.NumericInputFlatChargesDiscounts_NetDiscount.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputFlatChargesDiscounts_NetDiscount.SecurityEnabled = True
            Me.NumericInputFlatChargesDiscounts_NetDiscount.Size = New System.Drawing.Size(129, 20)
            Me.NumericInputFlatChargesDiscounts_NetDiscount.TabIndex = 3
            '
            'LabelFlatChargesDiscounts_NetCharge
            '
            Me.LabelFlatChargesDiscounts_NetCharge.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelFlatChargesDiscounts_NetCharge.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelFlatChargesDiscounts_NetCharge.Location = New System.Drawing.Point(5, 25)
            Me.LabelFlatChargesDiscounts_NetCharge.Name = "LabelFlatChargesDiscounts_NetCharge"
            Me.LabelFlatChargesDiscounts_NetCharge.Size = New System.Drawing.Size(81, 20)
            Me.LabelFlatChargesDiscounts_NetCharge.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelFlatChargesDiscounts_NetCharge.TabIndex = 4
            Me.LabelFlatChargesDiscounts_NetCharge.Text = "Net Charge:"
            '
            'TextBoxFlatChargesDiscounts_NetDiscountDescription
            '
            Me.TextBoxFlatChargesDiscounts_NetDiscountDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxFlatChargesDiscounts_NetDiscountDescription.Border.Class = "TextBoxBorder"
            Me.TextBoxFlatChargesDiscounts_NetDiscountDescription.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxFlatChargesDiscounts_NetDiscountDescription.CheckSpellingOnValidate = False
            Me.TextBoxFlatChargesDiscounts_NetDiscountDescription.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxFlatChargesDiscounts_NetDiscountDescription.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxFlatChargesDiscounts_NetDiscountDescription.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxFlatChargesDiscounts_NetDiscountDescription.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxFlatChargesDiscounts_NetDiscountDescription.FocusHighlightEnabled = True
            Me.TextBoxFlatChargesDiscounts_NetDiscountDescription.Location = New System.Drawing.Point(227, 51)
            Me.TextBoxFlatChargesDiscounts_NetDiscountDescription.MaxFileSize = CType(0, Long)
            Me.TextBoxFlatChargesDiscounts_NetDiscountDescription.Name = "TextBoxFlatChargesDiscounts_NetDiscountDescription"
            Me.TextBoxFlatChargesDiscounts_NetDiscountDescription.SecurityEnabled = True
            Me.TextBoxFlatChargesDiscounts_NetDiscountDescription.ShowSpellCheckCompleteMessage = True
            Me.TextBoxFlatChargesDiscounts_NetDiscountDescription.Size = New System.Drawing.Size(533, 21)
            Me.TextBoxFlatChargesDiscounts_NetDiscountDescription.StartingFolderName = Nothing
            Me.TextBoxFlatChargesDiscounts_NetDiscountDescription.TabIndex = 4
            Me.TextBoxFlatChargesDiscounts_NetDiscountDescription.TabOnEnter = True
            '
            'LabelFlatChargesDiscounts_NetDiscount
            '
            Me.LabelFlatChargesDiscounts_NetDiscount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelFlatChargesDiscounts_NetDiscount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelFlatChargesDiscounts_NetDiscount.Location = New System.Drawing.Point(5, 51)
            Me.LabelFlatChargesDiscounts_NetDiscount.Name = "LabelFlatChargesDiscounts_NetDiscount"
            Me.LabelFlatChargesDiscounts_NetDiscount.Size = New System.Drawing.Size(81, 20)
            Me.LabelFlatChargesDiscounts_NetDiscount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelFlatChargesDiscounts_NetDiscount.TabIndex = 2
            Me.LabelFlatChargesDiscounts_NetDiscount.Text = "Net Discount:"
            '
            'TextBoxFlatChargesDiscounts_NetChargeDescription
            '
            Me.TextBoxFlatChargesDiscounts_NetChargeDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxFlatChargesDiscounts_NetChargeDescription.Border.Class = "TextBoxBorder"
            Me.TextBoxFlatChargesDiscounts_NetChargeDescription.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxFlatChargesDiscounts_NetChargeDescription.CheckSpellingOnValidate = False
            Me.TextBoxFlatChargesDiscounts_NetChargeDescription.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxFlatChargesDiscounts_NetChargeDescription.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxFlatChargesDiscounts_NetChargeDescription.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxFlatChargesDiscounts_NetChargeDescription.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxFlatChargesDiscounts_NetChargeDescription.FocusHighlightEnabled = True
            Me.TextBoxFlatChargesDiscounts_NetChargeDescription.Location = New System.Drawing.Point(227, 25)
            Me.TextBoxFlatChargesDiscounts_NetChargeDescription.MaxFileSize = CType(0, Long)
            Me.TextBoxFlatChargesDiscounts_NetChargeDescription.Name = "TextBoxFlatChargesDiscounts_NetChargeDescription"
            Me.TextBoxFlatChargesDiscounts_NetChargeDescription.SecurityEnabled = True
            Me.TextBoxFlatChargesDiscounts_NetChargeDescription.ShowSpellCheckCompleteMessage = True
            Me.TextBoxFlatChargesDiscounts_NetChargeDescription.Size = New System.Drawing.Size(534, 21)
            Me.TextBoxFlatChargesDiscounts_NetChargeDescription.StartingFolderName = Nothing
            Me.TextBoxFlatChargesDiscounts_NetChargeDescription.TabIndex = 1
            Me.TextBoxFlatChargesDiscounts_NetChargeDescription.TabOnEnter = True
            '
            'NumericInputFlatChargesDiscounts_NetCharge
            '
            Me.NumericInputFlatChargesDiscounts_NetCharge.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputFlatChargesDiscounts_NetCharge.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Default]
            Me.NumericInputFlatChargesDiscounts_NetCharge.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputFlatChargesDiscounts_NetCharge.EnterMoveNextControl = True
            Me.NumericInputFlatChargesDiscounts_NetCharge.Location = New System.Drawing.Point(92, 25)
            Me.NumericInputFlatChargesDiscounts_NetCharge.Name = "NumericInputFlatChargesDiscounts_NetCharge"
            Me.NumericInputFlatChargesDiscounts_NetCharge.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputFlatChargesDiscounts_NetCharge.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputFlatChargesDiscounts_NetCharge.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputFlatChargesDiscounts_NetCharge.Properties.EditFormat.FormatString = "f"
            Me.NumericInputFlatChargesDiscounts_NetCharge.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputFlatChargesDiscounts_NetCharge.Properties.Mask.EditMask = "f"
            Me.NumericInputFlatChargesDiscounts_NetCharge.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputFlatChargesDiscounts_NetCharge.SecurityEnabled = True
            Me.NumericInputFlatChargesDiscounts_NetCharge.Size = New System.Drawing.Size(129, 20)
            Me.NumericInputFlatChargesDiscounts_NetCharge.TabIndex = 0
            '
            'TabItemRateCardDetails_OtherRateInformationTab
            '
            Me.TabItemRateCardDetails_OtherRateInformationTab.AttachedControl = Me.TabControlPanelOtherRateInformationTab_OtherRateInformation
            Me.TabItemRateCardDetails_OtherRateInformationTab.Name = "TabItemRateCardDetails_OtherRateInformationTab"
            Me.TabItemRateCardDetails_OtherRateInformationTab.Text = "Other Rate Information"
            '
            'TabControlPanelColorChargesTab_ColorCharges
            '
            Me.TabControlPanelColorChargesTab_ColorCharges.Controls.Add(Me.DataGridViewColorCharges_ColorCharges)
            Me.TabControlPanelColorChargesTab_ColorCharges.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelColorChargesTab_ColorCharges.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelColorChargesTab_ColorCharges.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelColorChargesTab_ColorCharges.Name = "TabControlPanelColorChargesTab_ColorCharges"
            Me.TabControlPanelColorChargesTab_ColorCharges.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelColorChargesTab_ColorCharges.Size = New System.Drawing.Size(774, 498)
            Me.TabControlPanelColorChargesTab_ColorCharges.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelColorChargesTab_ColorCharges.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelColorChargesTab_ColorCharges.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelColorChargesTab_ColorCharges.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelColorChargesTab_ColorCharges.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelColorChargesTab_ColorCharges.Style.GradientAngle = 90
            Me.TabControlPanelColorChargesTab_ColorCharges.TabIndex = 2
            Me.TabControlPanelColorChargesTab_ColorCharges.TabItem = Me.TabItemRateCardDetails_ColorChargesTab
            '
            'DataGridViewColorCharges_ColorCharges
            '
            Me.DataGridViewColorCharges_ColorCharges.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewColorCharges_ColorCharges.AllowDragAndDrop = False
            Me.DataGridViewColorCharges_ColorCharges.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewColorCharges_ColorCharges.AllowSelectGroupHeaderRow = True
            Me.DataGridViewColorCharges_ColorCharges.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewColorCharges_ColorCharges.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewColorCharges_ColorCharges.AutoFilterLookupColumns = False
            Me.DataGridViewColorCharges_ColorCharges.AutoloadRepositoryDatasource = True
            Me.DataGridViewColorCharges_ColorCharges.AutoUpdateViewCaption = True
            Me.DataGridViewColorCharges_ColorCharges.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewColorCharges_ColorCharges.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewColorCharges_ColorCharges.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewColorCharges_ColorCharges.ItemDescription = ""
            Me.DataGridViewColorCharges_ColorCharges.Location = New System.Drawing.Point(6, 6)
            Me.DataGridViewColorCharges_ColorCharges.MultiSelect = True
            Me.DataGridViewColorCharges_ColorCharges.Name = "DataGridViewColorCharges_ColorCharges"
            Me.DataGridViewColorCharges_ColorCharges.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewColorCharges_ColorCharges.RunStandardValidation = True
            Me.DataGridViewColorCharges_ColorCharges.ShowColumnMenuOnRightClick = False
            Me.DataGridViewColorCharges_ColorCharges.ShowSelectDeselectAllButtons = False
            Me.DataGridViewColorCharges_ColorCharges.Size = New System.Drawing.Size(762, 486)
            Me.DataGridViewColorCharges_ColorCharges.TabIndex = 7
            Me.DataGridViewColorCharges_ColorCharges.UseEmbeddedNavigator = False
            Me.DataGridViewColorCharges_ColorCharges.ViewCaptionHeight = -1
            '
            'TabItemRateCardDetails_ColorChargesTab
            '
            Me.TabItemRateCardDetails_ColorChargesTab.AttachedControl = Me.TabControlPanelColorChargesTab_ColorCharges
            Me.TabItemRateCardDetails_ColorChargesTab.Name = "TabItemRateCardDetails_ColorChargesTab"
            Me.TabItemRateCardDetails_ColorChargesTab.Text = "Color Charges"
            '
            'TabControlPanelRateDetailTab_RateDetail
            '
            Me.TabControlPanelRateDetailTab_RateDetail.Controls.Add(Me.DataGridViewRateDetail_RateDetails)
            Me.TabControlPanelRateDetailTab_RateDetail.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelRateDetailTab_RateDetail.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelRateDetailTab_RateDetail.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelRateDetailTab_RateDetail.Name = "TabControlPanelRateDetailTab_RateDetail"
            Me.TabControlPanelRateDetailTab_RateDetail.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelRateDetailTab_RateDetail.Size = New System.Drawing.Size(774, 498)
            Me.TabControlPanelRateDetailTab_RateDetail.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelRateDetailTab_RateDetail.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelRateDetailTab_RateDetail.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelRateDetailTab_RateDetail.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelRateDetailTab_RateDetail.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelRateDetailTab_RateDetail.Style.GradientAngle = 90
            Me.TabControlPanelRateDetailTab_RateDetail.TabIndex = 1
            Me.TabControlPanelRateDetailTab_RateDetail.TabItem = Me.TabItemRateCardDetails_RateDetailTab
            '
            'DataGridViewRateDetail_RateDetails
            '
            Me.DataGridViewRateDetail_RateDetails.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewRateDetail_RateDetails.AllowDragAndDrop = False
            Me.DataGridViewRateDetail_RateDetails.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewRateDetail_RateDetails.AllowSelectGroupHeaderRow = True
            Me.DataGridViewRateDetail_RateDetails.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewRateDetail_RateDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRateDetail_RateDetails.AutoFilterLookupColumns = False
            Me.DataGridViewRateDetail_RateDetails.AutoloadRepositoryDatasource = True
            Me.DataGridViewRateDetail_RateDetails.AutoUpdateViewCaption = True
            Me.DataGridViewRateDetail_RateDetails.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewRateDetail_RateDetails.DataSource = Nothing
            Me.DataGridViewRateDetail_RateDetails.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewRateDetail_RateDetails.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRateDetail_RateDetails.ItemDescription = ""
            Me.DataGridViewRateDetail_RateDetails.Location = New System.Drawing.Point(6, 6)
            Me.DataGridViewRateDetail_RateDetails.MultiSelect = True
            Me.DataGridViewRateDetail_RateDetails.Name = "DataGridViewRateDetail_RateDetails"
            Me.DataGridViewRateDetail_RateDetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewRateDetail_RateDetails.RunStandardValidation = True
            Me.DataGridViewRateDetail_RateDetails.ShowColumnMenuOnRightClick = False
            Me.DataGridViewRateDetail_RateDetails.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRateDetail_RateDetails.Size = New System.Drawing.Size(762, 486)
            Me.DataGridViewRateDetail_RateDetails.TabIndex = 0
            Me.DataGridViewRateDetail_RateDetails.UseEmbeddedNavigator = False
            Me.DataGridViewRateDetail_RateDetails.ViewCaptionHeight = -1
            '
            'TabItemRateCardDetails_RateDetailTab
            '
            Me.TabItemRateCardDetails_RateDetailTab.AttachedControl = Me.TabControlPanelRateDetailTab_RateDetail
            Me.TabItemRateCardDetails_RateDetailTab.Name = "TabItemRateCardDetails_RateDetailTab"
            Me.TabItemRateCardDetails_RateDetailTab.Text = "Rate Detail"
            '
            'SearchableComboBoxType_Client
            '
            Me.SearchableComboBoxType_Client.ActiveFilterString = ""
            Me.SearchableComboBoxType_Client.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxType_Client.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxType_Client.AutoFillMode = False
            Me.SearchableComboBoxType_Client.BookmarkingEnabled = False
            Me.SearchableComboBoxType_Client.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Client
            Me.SearchableComboBoxType_Client.DataSource = Nothing
            Me.SearchableComboBoxType_Client.DisableMouseWheel = False
            Me.SearchableComboBoxType_Client.DisplayName = ""
            Me.SearchableComboBoxType_Client.EnterMoveNextControl = True
            Me.SearchableComboBoxType_Client.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxType_Client.Location = New System.Drawing.Point(70, 51)
            Me.SearchableComboBoxType_Client.Name = "SearchableComboBoxType_Client"
            Me.SearchableComboBoxType_Client.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxType_Client.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxType_Client.Properties.NullText = "Select Client"
            Me.SearchableComboBoxType_Client.Properties.ValueMember = "Code"
            Me.SearchableComboBoxType_Client.Properties.View = Me.GridView2
            Me.SearchableComboBoxType_Client.SecurityEnabled = True
            Me.SearchableComboBoxType_Client.SelectedValue = Nothing
            Me.SearchableComboBoxType_Client.Size = New System.Drawing.Size(691, 20)
            Me.SearchableComboBoxType_Client.TabIndex = 3
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
            'RateCardContractControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.TabControlControl_GeneralInformation)
            Me.Name = "RateCardContractControl"
            Me.Size = New System.Drawing.Size(774, 525)
            CType(Me.TabControlControl_GeneralInformation, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlControl_GeneralInformation.ResumeLayout(False)
            Me.TabControlPanelGeneralInformationTab_GeneralInformation.ResumeLayout(False)
            CType(Me.SearchableComboBoxGeneralInformation_Vendor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxGeneralInformation_DefaultInformation, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxGeneralInformation_DefaultInformation.ResumeLayout(False)
            CType(Me.NumericInputDefaultInformation_VendorCommissionPercentage.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputDefaultInformation_SpaceCloseDays.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputDefaultInformation_MaterialCloseDays.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerGeneralInformation_DateTo, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxGeneralInformation_Type, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxGeneralInformation_Type.ResumeLayout(False)
            CType(Me.DateTimePickerGeneralInformation_DateFrom, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelCommentsTab_Comments.ResumeLayout(False)
            Me.TabControlPanelOtherRateInformationTab_OtherRateInformation.ResumeLayout(False)
            CType(Me.GroupBoxOtherRateInformation_RateCharges, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxOtherRateInformation_RateCharges.ResumeLayout(False)
            CType(Me.NumericInputRateCharges_PremiumPercent.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputRateCharges_PositionPercent.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputRateCharges_BleedPercent.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxOtherRateInformation_FlatChargesDiscounts, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxOtherRateInformation_FlatChargesDiscounts.ResumeLayout(False)
            CType(Me.NumericInputFlatChargesDiscounts_NetDiscount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputFlatChargesDiscounts_NetCharge.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelColorChargesTab_ColorCharges.ResumeLayout(False)
            Me.TabControlPanelRateDetailTab_RateDetail.ResumeLayout(False)
            CType(Me.SearchableComboBoxType_Client.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents TabControlControl_GeneralInformation As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelGeneralInformationTab_GeneralInformation As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents LabelGeneralInformation_Description As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxGeneralInformation_Description As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelGeneralInformation_RateCard As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxGeneralInformation_Code As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents CheckBoxGeneralInformation_Inactive As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents TabItemRateCardDetails_GeneralInformationTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents DateTimePickerGeneralInformation_DateFrom As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents LabelGeneralInformation_Vendor As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TabControlPanelRateDetailTab_RateDetail As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemRateCardDetails_RateDetailTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelColorChargesTab_ColorCharges As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabControlPanelOtherRateInformationTab_OtherRateInformation As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemRateCardDetails_OtherRateInformationTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents LabelFlatChargesDiscounts_NetDiscount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelFlatChargesDiscounts_NetCharge As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxFlatChargesDiscounts_NetChargeDescription As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents GroupBoxGeneralInformation_Type As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents LabelType_Client As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents RadioButtonType_ContractRateCard As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonType_StandardRateCard As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents GroupBoxGeneralInformation_DefaultInformation As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents LabelDefaultInformation_SpaceCloseDays As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelDefaultInformation_MaterialCloseDays As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelDefaultInformation_VendorCommissionPercentage As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerGeneralInformation_DateTo As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents LabelGeneralInformation_To As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGeneralInformation_EffectiveDates As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents NumericInputDefaultInformation_VendorCommissionPercentage As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputDefaultInformation_SpaceCloseDays As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputDefaultInformation_MaterialCloseDays As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputFlatChargesDiscounts_NetDiscount As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputFlatChargesDiscounts_NetCharge As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents TextBoxFlatChargesDiscounts_NetDiscountDescription As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TabControlPanelCommentsTab_Comments As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemRateCardDetails_CommentsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents LabelComments_ContractInfo As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelComments_MiscInfo As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelComments_RateInfo As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelComments_CloseInfo As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxComments_ContractInfo As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxComments_MiscInfo As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxComments_RateInfo As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxComments_CloseInfo As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxComments_PositionInfo As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelComments_PositionInfo As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents DataGridViewRateDetail_RateDetails As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Private WithEvents DataGridViewColorCharges_ColorCharges As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TabItemRateCardDetails_ColorChargesTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents GroupBoxOtherRateInformation_RateCharges As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents LabelRateCharges_PremiumPercent As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelRateCharges_PositionPercent As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents NumericInputRateCharges_PremiumPercent As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputRateCharges_PositionPercent As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputRateCharges_BleedPercent As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents LabelRateCharges_BleedPercent As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxOtherRateInformation_FlatChargesDiscounts As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents SearchableComboBoxGeneralInformation_Vendor As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView1 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxType_Client As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView2 As AdvantageFramework.WinForm.Presentation.Controls.GridView

    End Class

End Namespace
