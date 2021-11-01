Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class CampaignControl
        Inherits AdvantageFramework.WinForm.Presentation.Controls.BaseControls.BaseUserControl

        'UserControl overrides dispose to clean up the component list.
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
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CampaignControl))
            Me.CheckBoxGeneral_Closed = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TabControlControl_CampaignDetails = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelGeneralTab_General = New DevComponents.DotNetBar.TabControlPanel()
            Me.SearchableComboBoxGeneral_LandingPage = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewGeneral_LandingPage = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelGeneral_LandingPage = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneral_ID = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneral_IDLabel = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxGeneral_JobComponent = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelGeneral_JobComponent = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxGeneral_Market = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelGeneral_Market = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxGeneral_AdNumber = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelGeneral_AdNumber = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DateTimePickerGeneral_BeginningDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerGeneral_EndingDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelGeneral_BeginningDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxGeneral_Product = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxGeneral_Division = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelGeneral_EndingDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxGeneral_Client = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.GroupBoxGeneral_Comments = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.TextBoxComments_Comments = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.GroupBoxGeneral_MediaTypes = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.TextBoxMediaTypes_Other = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.CheckBoxMediaTypes_Other = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMediaTypes_DirectResponse = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMediaTypes_PrintCollateral = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMediaTypes_Television = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMediaTypes_Radio = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMediaTypes_OutOfHome = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMediaTypes_Internet = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMediaTypes_Newspaper = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMediaTypes_Magazine = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelGeneral_Name = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxGeneral_Name = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.RadioButtonGeneral_Overall = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonGeneral_AssignedToJobsAndOrders = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.ComboBoxGeneral_AlertGroup = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelGeneral_AlertGroup = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneral_Code = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxGeneral_Code = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.ComboBoxGeneral_Office = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelGeneral_Product = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneral_Division = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneral_Client = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneral_CampaignType = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneral_Office = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemCampaignDetails_GeneralTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelDocumentsTab_Documents = New DevComponents.DotNetBar.TabControlPanel()
            Me.DocumentManagerControlDocuments_CampaignDocuments = New AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl()
            Me.TabItemCampaignDetails_DocumentsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelJobsAndMediaOrdersTab_JobsAndMediaOrders = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelJobsAndMediaOrders_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ButtonRightSection_AddJobsAndMediaOrders = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonRightSection_RemoveJobsAndMediaOrders = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewRightSection_JobsAndMediaOrders = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterJobsAndMediaOrders_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelJobsAndMediaOrders_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_AvailableJobsAndMediaOrders = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemCampaignDetails_JobsAndMediaOrdersTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelCampaignDetailsTab_CampaignDetails = New DevComponents.DotNetBar.TabControlPanel()
            Me.LabelCampaignDetails_IncomeTotalAllocatedAmount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCampaignDetails_IncomeCombinedBudgetAmount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCampaignDetails_IncomeProductionBudgetAmount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCampaignDetails_IncomeMediaBudgetAmount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCampaignDetails_IncomeTotalAllocated = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCampaignDetails_IncomeCombinedBudget = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCampaignDetails_IncomeProductionBudget = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCampaignDetails_IncomeMediaBudget = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCampaignDetails_BillingTotalAllocatedAmount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCampaignDetails_BillingCombinedBudgetAmount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCampaignDetails_BillingProductionBudgetAmount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCampaignDetails_BillingMediaBudgetAmount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCampaignDetails_BillingTotalAllocated = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCampaignDetails_BillingCombinedBudget = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCampaignDetails_BillingProductionBudget = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCampaignDetails_IncomeAmountTotals = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCampaignDetails_BillingAmountTotals = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCampaignDetails_BillingMediaBudget = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DataGridViewCampaignDetails_CampaignDetails = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.NumericInputCampaignDetails_TotalIncome = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputCampaignDetails_TotalBilling = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelCampaignDetails_TotalIncome = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCampaignDetails_TotalBilling = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemCampaignDetails_CampaignDetailsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.LabelGeneral_WebsiteName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxGeneral_WebsiteName = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            CType(Me.TabControlControl_CampaignDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlControl_CampaignDetails.SuspendLayout()
            Me.TabControlPanelGeneralTab_General.SuspendLayout()
            CType(Me.SearchableComboBoxGeneral_LandingPage.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewGeneral_LandingPage, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerGeneral_BeginningDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerGeneral_EndingDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxGeneral_Comments, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxGeneral_Comments.SuspendLayout()
            CType(Me.GroupBoxGeneral_MediaTypes, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxGeneral_MediaTypes.SuspendLayout()
            Me.TabControlPanelDocumentsTab_Documents.SuspendLayout()
            Me.TabControlPanelJobsAndMediaOrdersTab_JobsAndMediaOrders.SuspendLayout()
            CType(Me.PanelJobsAndMediaOrders_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelJobsAndMediaOrders_RightSection.SuspendLayout()
            CType(Me.PanelJobsAndMediaOrders_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelJobsAndMediaOrders_LeftSection.SuspendLayout()
            Me.TabControlPanelCampaignDetailsTab_CampaignDetails.SuspendLayout()
            CType(Me.NumericInputCampaignDetails_TotalIncome.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputCampaignDetails_TotalBilling.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'CheckBoxGeneral_Closed
            '
            Me.CheckBoxGeneral_Closed.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxGeneral_Closed.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxGeneral_Closed.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxGeneral_Closed.CheckValue = 0
            Me.CheckBoxGeneral_Closed.CheckValueChecked = 1
            Me.CheckBoxGeneral_Closed.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxGeneral_Closed.CheckValueUnchecked = 0
            Me.CheckBoxGeneral_Closed.ChildControls = Nothing
            Me.CheckBoxGeneral_Closed.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxGeneral_Closed.Location = New System.Drawing.Point(586, 3)
            Me.CheckBoxGeneral_Closed.Name = "CheckBoxGeneral_Closed"
            Me.CheckBoxGeneral_Closed.OldestSibling = Nothing
            Me.CheckBoxGeneral_Closed.SecurityEnabled = True
            Me.CheckBoxGeneral_Closed.SiblingControls = Nothing
            Me.CheckBoxGeneral_Closed.Size = New System.Drawing.Size(119, 22)
            Me.CheckBoxGeneral_Closed.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxGeneral_Closed.TabIndex = 1
            Me.CheckBoxGeneral_Closed.TabOnEnter = True
            Me.CheckBoxGeneral_Closed.Text = "Closed"
            '
            'TabControlControl_CampaignDetails
            '
            Me.TabControlControl_CampaignDetails.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
            Me.TabControlControl_CampaignDetails.CanReorderTabs = False
            Me.TabControlControl_CampaignDetails.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlControl_CampaignDetails.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlControl_CampaignDetails.Controls.Add(Me.TabControlPanelGeneralTab_General)
            Me.TabControlControl_CampaignDetails.Controls.Add(Me.TabControlPanelDocumentsTab_Documents)
            Me.TabControlControl_CampaignDetails.Controls.Add(Me.TabControlPanelJobsAndMediaOrdersTab_JobsAndMediaOrders)
            Me.TabControlControl_CampaignDetails.Controls.Add(Me.TabControlPanelCampaignDetailsTab_CampaignDetails)
            Me.TabControlControl_CampaignDetails.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlControl_CampaignDetails.ForeColor = System.Drawing.Color.Black
            Me.TabControlControl_CampaignDetails.Location = New System.Drawing.Point(0, 0)
            Me.TabControlControl_CampaignDetails.Name = "TabControlControl_CampaignDetails"
            Me.TabControlControl_CampaignDetails.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlControl_CampaignDetails.SelectedTabIndex = 0
            Me.TabControlControl_CampaignDetails.Size = New System.Drawing.Size(706, 527)
            Me.TabControlControl_CampaignDetails.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlControl_CampaignDetails.TabIndex = 0
            Me.TabControlControl_CampaignDetails.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlControl_CampaignDetails.Tabs.Add(Me.TabItemCampaignDetails_GeneralTab)
            Me.TabControlControl_CampaignDetails.Tabs.Add(Me.TabItemCampaignDetails_CampaignDetailsTab)
            Me.TabControlControl_CampaignDetails.Tabs.Add(Me.TabItemCampaignDetails_JobsAndMediaOrdersTab)
            Me.TabControlControl_CampaignDetails.Tabs.Add(Me.TabItemCampaignDetails_DocumentsTab)
            '
            'TabControlPanelGeneralTab_General
            '
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.TextBoxGeneral_WebsiteName)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_WebsiteName)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.SearchableComboBoxGeneral_LandingPage)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_LandingPage)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_ID)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_IDLabel)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.ComboBoxGeneral_JobComponent)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_JobComponent)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.ComboBoxGeneral_Market)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_Market)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.ComboBoxGeneral_AdNumber)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_AdNumber)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.DateTimePickerGeneral_BeginningDate)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.DateTimePickerGeneral_EndingDate)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_BeginningDate)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.TextBoxGeneral_Product)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.TextBoxGeneral_Division)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_EndingDate)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.TextBoxGeneral_Client)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.GroupBoxGeneral_Comments)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.GroupBoxGeneral_MediaTypes)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_Name)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.TextBoxGeneral_Name)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.RadioButtonGeneral_Overall)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.RadioButtonGeneral_AssignedToJobsAndOrders)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.ComboBoxGeneral_AlertGroup)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_AlertGroup)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_Code)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.TextBoxGeneral_Code)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.ComboBoxGeneral_Office)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_Product)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_Division)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_Client)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_CampaignType)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_Office)
            Me.TabControlPanelGeneralTab_General.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelGeneralTab_General.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelGeneralTab_General.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelGeneralTab_General.Name = "TabControlPanelGeneralTab_General"
            Me.TabControlPanelGeneralTab_General.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelGeneralTab_General.Size = New System.Drawing.Size(706, 500)
            Me.TabControlPanelGeneralTab_General.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelGeneralTab_General.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelGeneralTab_General.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelGeneralTab_General.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelGeneralTab_General.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelGeneralTab_General.Style.GradientAngle = 90
            Me.TabControlPanelGeneralTab_General.TabIndex = 0
            Me.TabControlPanelGeneralTab_General.TabItem = Me.TabItemCampaignDetails_GeneralTab
            '
            'SearchableComboBoxGeneral_LandingPage
            '
            Me.SearchableComboBoxGeneral_LandingPage.ActiveFilterString = ""
            Me.SearchableComboBoxGeneral_LandingPage.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxGeneral_LandingPage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxGeneral_LandingPage.AutoFillMode = False
            Me.SearchableComboBoxGeneral_LandingPage.BookmarkingEnabled = False
            Me.SearchableComboBoxGeneral_LandingPage.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.ClientWebsite
            Me.SearchableComboBoxGeneral_LandingPage.DataSource = Nothing
            Me.SearchableComboBoxGeneral_LandingPage.DisableMouseWheel = True
            Me.SearchableComboBoxGeneral_LandingPage.DisplayName = ""
            Me.SearchableComboBoxGeneral_LandingPage.EditValue = ""
            Me.SearchableComboBoxGeneral_LandingPage.EnterMoveNextControl = True
            Me.SearchableComboBoxGeneral_LandingPage.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxGeneral_LandingPage.Location = New System.Drawing.Point(99, 342)
            Me.SearchableComboBoxGeneral_LandingPage.Name = "SearchableComboBoxGeneral_LandingPage"
            Me.SearchableComboBoxGeneral_LandingPage.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxGeneral_LandingPage.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxGeneral_LandingPage.Properties.NullText = "Select Website"
            Me.SearchableComboBoxGeneral_LandingPage.Properties.ShowClearButton = False
            Me.SearchableComboBoxGeneral_LandingPage.Properties.ValueMember = "ID"
            Me.SearchableComboBoxGeneral_LandingPage.Properties.View = Me.SearchableComboBoxViewGeneral_LandingPage
            Me.SearchableComboBoxGeneral_LandingPage.SecurityEnabled = True
            Me.SearchableComboBoxGeneral_LandingPage.SelectedValue = ""
            Me.SearchableComboBoxGeneral_LandingPage.Size = New System.Drawing.Size(603, 20)
            Me.SearchableComboBoxGeneral_LandingPage.TabIndex = 29
            '
            'SearchableComboBoxViewGeneral_LandingPage
            '
            Me.SearchableComboBoxViewGeneral_LandingPage.AFActiveFilterString = ""
            Me.SearchableComboBoxViewGeneral_LandingPage.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewGeneral_LandingPage.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_LandingPage.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_LandingPage.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_LandingPage.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_LandingPage.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_LandingPage.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_LandingPage.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_LandingPage.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_LandingPage.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_LandingPage.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_LandingPage.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_LandingPage.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_LandingPage.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_LandingPage.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_LandingPage.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_LandingPage.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_LandingPage.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_LandingPage.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_LandingPage.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_LandingPage.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_LandingPage.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_LandingPage.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_LandingPage.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_LandingPage.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_LandingPage.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_LandingPage.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_LandingPage.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_LandingPage.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_LandingPage.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_LandingPage.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_LandingPage.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_LandingPage.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_LandingPage.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_LandingPage.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_LandingPage.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_LandingPage.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_LandingPage.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_LandingPage.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewGeneral_LandingPage.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewGeneral_LandingPage.DataSourceClearing = False
            Me.SearchableComboBoxViewGeneral_LandingPage.EnableDisabledRows = False
            Me.SearchableComboBoxViewGeneral_LandingPage.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewGeneral_LandingPage.Name = "SearchableComboBoxViewGeneral_LandingPage"
            Me.SearchableComboBoxViewGeneral_LandingPage.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewGeneral_LandingPage.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewGeneral_LandingPage.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewGeneral_LandingPage.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewGeneral_LandingPage.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewGeneral_LandingPage.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewGeneral_LandingPage.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewGeneral_LandingPage.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewGeneral_LandingPage.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewGeneral_LandingPage.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewGeneral_LandingPage.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewGeneral_LandingPage.RunStandardValidation = True
            '
            'LabelGeneral_LandingPage
            '
            Me.LabelGeneral_LandingPage.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_LandingPage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_LandingPage.Location = New System.Drawing.Point(6, 342)
            Me.LabelGeneral_LandingPage.Name = "LabelGeneral_LandingPage"
            Me.LabelGeneral_LandingPage.Size = New System.Drawing.Size(87, 20)
            Me.LabelGeneral_LandingPage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_LandingPage.TabIndex = 28
            Me.LabelGeneral_LandingPage.Text = "Landing Page:"
            '
            'LabelGeneral_ID
            '
            Me.LabelGeneral_ID.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_ID.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_ID.Location = New System.Drawing.Point(97, 108)
            Me.LabelGeneral_ID.Name = "LabelGeneral_ID"
            Me.LabelGeneral_ID.Size = New System.Drawing.Size(64, 20)
            Me.LabelGeneral_ID.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_ID.TabIndex = 30
            '
            'LabelGeneral_IDLabel
            '
            Me.LabelGeneral_IDLabel.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_IDLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_IDLabel.Location = New System.Drawing.Point(4, 108)
            Me.LabelGeneral_IDLabel.Name = "LabelGeneral_IDLabel"
            Me.LabelGeneral_IDLabel.Size = New System.Drawing.Size(87, 20)
            Me.LabelGeneral_IDLabel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_IDLabel.TabIndex = 29
            Me.LabelGeneral_IDLabel.Text = "ID:"
            '
            'ComboBoxGeneral_JobComponent
            '
            Me.ComboBoxGeneral_JobComponent.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxGeneral_JobComponent.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxGeneral_JobComponent.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxGeneral_JobComponent.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxGeneral_JobComponent.AutoFindItemInDataSource = False
            Me.ComboBoxGeneral_JobComponent.AutoSelectSingleItemDatasource = False
            Me.ComboBoxGeneral_JobComponent.BookmarkingEnabled = False
            Me.ComboBoxGeneral_JobComponent.ClientCode = ""
            Me.ComboBoxGeneral_JobComponent.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.JobAndJobComponent
            Me.ComboBoxGeneral_JobComponent.DisableMouseWheel = False
            Me.ComboBoxGeneral_JobComponent.DisplayMember = "Description"
            Me.ComboBoxGeneral_JobComponent.DisplayName = ""
            Me.ComboBoxGeneral_JobComponent.DivisionCode = ""
            Me.ComboBoxGeneral_JobComponent.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxGeneral_JobComponent.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxGeneral_JobComponent.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxGeneral_JobComponent.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxGeneral_JobComponent.FocusHighlightEnabled = True
            Me.ComboBoxGeneral_JobComponent.FormattingEnabled = True
            Me.ComboBoxGeneral_JobComponent.ItemHeight = 14
            Me.ComboBoxGeneral_JobComponent.Location = New System.Drawing.Point(97, 212)
            Me.ComboBoxGeneral_JobComponent.Name = "ComboBoxGeneral_JobComponent"
            Me.ComboBoxGeneral_JobComponent.ReadOnly = False
            Me.ComboBoxGeneral_JobComponent.SecurityEnabled = True
            Me.ComboBoxGeneral_JobComponent.Size = New System.Drawing.Size(605, 20)
            Me.ComboBoxGeneral_JobComponent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxGeneral_JobComponent.TabIndex = 19
            Me.ComboBoxGeneral_JobComponent.TabOnEnter = True
            Me.ComboBoxGeneral_JobComponent.ValueMember = "JobComponent"
            Me.ComboBoxGeneral_JobComponent.WatermarkText = "Select Job Component"
            '
            'LabelGeneral_JobComponent
            '
            Me.LabelGeneral_JobComponent.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_JobComponent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_JobComponent.Location = New System.Drawing.Point(4, 212)
            Me.LabelGeneral_JobComponent.Name = "LabelGeneral_JobComponent"
            Me.LabelGeneral_JobComponent.Size = New System.Drawing.Size(87, 20)
            Me.LabelGeneral_JobComponent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_JobComponent.TabIndex = 18
            Me.LabelGeneral_JobComponent.Text = "Job/Component:"
            '
            'ComboBoxGeneral_Market
            '
            Me.ComboBoxGeneral_Market.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxGeneral_Market.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxGeneral_Market.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxGeneral_Market.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxGeneral_Market.AutoFindItemInDataSource = False
            Me.ComboBoxGeneral_Market.AutoSelectSingleItemDatasource = False
            Me.ComboBoxGeneral_Market.BookmarkingEnabled = False
            Me.ComboBoxGeneral_Market.ClientCode = ""
            Me.ComboBoxGeneral_Market.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Market
            Me.ComboBoxGeneral_Market.DisableMouseWheel = False
            Me.ComboBoxGeneral_Market.DisplayMember = "Description"
            Me.ComboBoxGeneral_Market.DisplayName = ""
            Me.ComboBoxGeneral_Market.DivisionCode = ""
            Me.ComboBoxGeneral_Market.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxGeneral_Market.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxGeneral_Market.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxGeneral_Market.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxGeneral_Market.FocusHighlightEnabled = True
            Me.ComboBoxGeneral_Market.FormattingEnabled = True
            Me.ComboBoxGeneral_Market.ItemHeight = 14
            Me.ComboBoxGeneral_Market.Location = New System.Drawing.Point(97, 186)
            Me.ComboBoxGeneral_Market.Name = "ComboBoxGeneral_Market"
            Me.ComboBoxGeneral_Market.ReadOnly = False
            Me.ComboBoxGeneral_Market.SecurityEnabled = True
            Me.ComboBoxGeneral_Market.Size = New System.Drawing.Size(605, 20)
            Me.ComboBoxGeneral_Market.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxGeneral_Market.TabIndex = 17
            Me.ComboBoxGeneral_Market.TabOnEnter = True
            Me.ComboBoxGeneral_Market.ValueMember = "Code"
            Me.ComboBoxGeneral_Market.WatermarkText = "Select Market"
            '
            'LabelGeneral_Market
            '
            Me.LabelGeneral_Market.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_Market.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_Market.Location = New System.Drawing.Point(4, 186)
            Me.LabelGeneral_Market.Name = "LabelGeneral_Market"
            Me.LabelGeneral_Market.Size = New System.Drawing.Size(87, 20)
            Me.LabelGeneral_Market.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_Market.TabIndex = 16
            Me.LabelGeneral_Market.Text = "Market:"
            '
            'ComboBoxGeneral_AdNumber
            '
            Me.ComboBoxGeneral_AdNumber.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxGeneral_AdNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxGeneral_AdNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxGeneral_AdNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxGeneral_AdNumber.AutoFindItemInDataSource = False
            Me.ComboBoxGeneral_AdNumber.AutoSelectSingleItemDatasource = False
            Me.ComboBoxGeneral_AdNumber.BookmarkingEnabled = False
            Me.ComboBoxGeneral_AdNumber.ClientCode = ""
            Me.ComboBoxGeneral_AdNumber.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Ad
            Me.ComboBoxGeneral_AdNumber.DisableMouseWheel = False
            Me.ComboBoxGeneral_AdNumber.DisplayMember = "Description"
            Me.ComboBoxGeneral_AdNumber.DisplayName = ""
            Me.ComboBoxGeneral_AdNumber.DivisionCode = ""
            Me.ComboBoxGeneral_AdNumber.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxGeneral_AdNumber.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxGeneral_AdNumber.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxGeneral_AdNumber.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxGeneral_AdNumber.FocusHighlightEnabled = True
            Me.ComboBoxGeneral_AdNumber.FormattingEnabled = True
            Me.ComboBoxGeneral_AdNumber.ItemHeight = 14
            Me.ComboBoxGeneral_AdNumber.Location = New System.Drawing.Point(97, 160)
            Me.ComboBoxGeneral_AdNumber.Name = "ComboBoxGeneral_AdNumber"
            Me.ComboBoxGeneral_AdNumber.ReadOnly = False
            Me.ComboBoxGeneral_AdNumber.SecurityEnabled = True
            Me.ComboBoxGeneral_AdNumber.Size = New System.Drawing.Size(605, 20)
            Me.ComboBoxGeneral_AdNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxGeneral_AdNumber.TabIndex = 15
            Me.ComboBoxGeneral_AdNumber.TabOnEnter = True
            Me.ComboBoxGeneral_AdNumber.ValueMember = "Number"
            Me.ComboBoxGeneral_AdNumber.WatermarkText = "Select Ad"
            '
            'LabelGeneral_AdNumber
            '
            Me.LabelGeneral_AdNumber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_AdNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_AdNumber.Location = New System.Drawing.Point(4, 160)
            Me.LabelGeneral_AdNumber.Name = "LabelGeneral_AdNumber"
            Me.LabelGeneral_AdNumber.Size = New System.Drawing.Size(87, 20)
            Me.LabelGeneral_AdNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_AdNumber.TabIndex = 14
            Me.LabelGeneral_AdNumber.Text = "Ad Number:"
            '
            'DateTimePickerGeneral_BeginningDate
            '
            Me.DateTimePickerGeneral_BeginningDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerGeneral_BeginningDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerGeneral_BeginningDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneral_BeginningDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerGeneral_BeginningDate.ButtonDropDown.Visible = True
            Me.DateTimePickerGeneral_BeginningDate.ButtonFreeText.Checked = True
            Me.DateTimePickerGeneral_BeginningDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerGeneral_BeginningDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerGeneral_BeginningDate.DisplayName = ""
            Me.DateTimePickerGeneral_BeginningDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerGeneral_BeginningDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerGeneral_BeginningDate.FocusHighlightEnabled = True
            Me.DateTimePickerGeneral_BeginningDate.FreeTextEntryMode = True
            Me.DateTimePickerGeneral_BeginningDate.IsPopupCalendarOpen = False
            Me.DateTimePickerGeneral_BeginningDate.Location = New System.Drawing.Point(99, 290)
            Me.DateTimePickerGeneral_BeginningDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerGeneral_BeginningDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerGeneral_BeginningDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerGeneral_BeginningDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneral_BeginningDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerGeneral_BeginningDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerGeneral_BeginningDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerGeneral_BeginningDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerGeneral_BeginningDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerGeneral_BeginningDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerGeneral_BeginningDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerGeneral_BeginningDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneral_BeginningDate.MonthCalendar.DisplayMonth = New Date(2012, 2, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerGeneral_BeginningDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerGeneral_BeginningDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerGeneral_BeginningDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerGeneral_BeginningDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneral_BeginningDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerGeneral_BeginningDate.Name = "DateTimePickerGeneral_BeginningDate"
            Me.DateTimePickerGeneral_BeginningDate.ReadOnly = False
            Me.DateTimePickerGeneral_BeginningDate.Size = New System.Drawing.Size(126, 20)
            Me.DateTimePickerGeneral_BeginningDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerGeneral_BeginningDate.TabIndex = 24
            Me.DateTimePickerGeneral_BeginningDate.TabOnEnter = True
            Me.DateTimePickerGeneral_BeginningDate.Value = New Date(2013, 9, 12, 11, 30, 35, 371)
            '
            'DateTimePickerGeneral_EndingDate
            '
            Me.DateTimePickerGeneral_EndingDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerGeneral_EndingDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerGeneral_EndingDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneral_EndingDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerGeneral_EndingDate.ButtonDropDown.Visible = True
            Me.DateTimePickerGeneral_EndingDate.ButtonFreeText.Checked = True
            Me.DateTimePickerGeneral_EndingDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerGeneral_EndingDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerGeneral_EndingDate.DisplayName = ""
            Me.DateTimePickerGeneral_EndingDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerGeneral_EndingDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerGeneral_EndingDate.FocusHighlightEnabled = True
            Me.DateTimePickerGeneral_EndingDate.FreeTextEntryMode = True
            Me.DateTimePickerGeneral_EndingDate.IsPopupCalendarOpen = False
            Me.DateTimePickerGeneral_EndingDate.Location = New System.Drawing.Point(99, 316)
            Me.DateTimePickerGeneral_EndingDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerGeneral_EndingDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerGeneral_EndingDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerGeneral_EndingDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneral_EndingDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerGeneral_EndingDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerGeneral_EndingDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerGeneral_EndingDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerGeneral_EndingDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerGeneral_EndingDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerGeneral_EndingDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerGeneral_EndingDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneral_EndingDate.MonthCalendar.DisplayMonth = New Date(2012, 2, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerGeneral_EndingDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerGeneral_EndingDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerGeneral_EndingDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerGeneral_EndingDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneral_EndingDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerGeneral_EndingDate.Name = "DateTimePickerGeneral_EndingDate"
            Me.DateTimePickerGeneral_EndingDate.ReadOnly = False
            Me.DateTimePickerGeneral_EndingDate.Size = New System.Drawing.Size(126, 20)
            Me.DateTimePickerGeneral_EndingDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerGeneral_EndingDate.TabIndex = 26
            Me.DateTimePickerGeneral_EndingDate.TabOnEnter = True
            Me.DateTimePickerGeneral_EndingDate.Value = New Date(2013, 9, 12, 11, 30, 35, 384)
            '
            'LabelGeneral_BeginningDate
            '
            Me.LabelGeneral_BeginningDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_BeginningDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_BeginningDate.Location = New System.Drawing.Point(6, 290)
            Me.LabelGeneral_BeginningDate.Name = "LabelGeneral_BeginningDate"
            Me.LabelGeneral_BeginningDate.Size = New System.Drawing.Size(87, 20)
            Me.LabelGeneral_BeginningDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_BeginningDate.TabIndex = 23
            Me.LabelGeneral_BeginningDate.Text = "Beginning Date:"
            '
            'TextBoxGeneral_Product
            '
            Me.TextBoxGeneral_Product.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxGeneral_Product.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxGeneral_Product.Border.Class = "TextBoxBorder"
            Me.TextBoxGeneral_Product.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxGeneral_Product.CheckSpellingOnValidate = False
            Me.TextBoxGeneral_Product.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxGeneral_Product.Enabled = False
            Me.TextBoxGeneral_Product.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxGeneral_Product.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxGeneral_Product.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxGeneral_Product.FocusHighlightEnabled = True
            Me.TextBoxGeneral_Product.ForeColor = System.Drawing.Color.Black
            Me.TextBoxGeneral_Product.Location = New System.Drawing.Point(97, 82)
            Me.TextBoxGeneral_Product.MaxFileSize = CType(0, Long)
            Me.TextBoxGeneral_Product.Name = "TextBoxGeneral_Product"
            Me.TextBoxGeneral_Product.ReadOnly = True
            Me.TextBoxGeneral_Product.SecurityEnabled = True
            Me.TextBoxGeneral_Product.ShowSpellCheckCompleteMessage = True
            Me.TextBoxGeneral_Product.Size = New System.Drawing.Size(605, 20)
            Me.TextBoxGeneral_Product.StartingFolderName = Nothing
            Me.TextBoxGeneral_Product.TabIndex = 7
            Me.TextBoxGeneral_Product.TabOnEnter = True
            '
            'TextBoxGeneral_Division
            '
            Me.TextBoxGeneral_Division.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxGeneral_Division.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxGeneral_Division.Border.Class = "TextBoxBorder"
            Me.TextBoxGeneral_Division.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxGeneral_Division.CheckSpellingOnValidate = False
            Me.TextBoxGeneral_Division.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxGeneral_Division.Enabled = False
            Me.TextBoxGeneral_Division.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxGeneral_Division.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxGeneral_Division.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxGeneral_Division.FocusHighlightEnabled = True
            Me.TextBoxGeneral_Division.ForeColor = System.Drawing.Color.Black
            Me.TextBoxGeneral_Division.Location = New System.Drawing.Point(97, 56)
            Me.TextBoxGeneral_Division.MaxFileSize = CType(0, Long)
            Me.TextBoxGeneral_Division.Name = "TextBoxGeneral_Division"
            Me.TextBoxGeneral_Division.ReadOnly = True
            Me.TextBoxGeneral_Division.SecurityEnabled = True
            Me.TextBoxGeneral_Division.ShowSpellCheckCompleteMessage = True
            Me.TextBoxGeneral_Division.Size = New System.Drawing.Size(605, 20)
            Me.TextBoxGeneral_Division.StartingFolderName = Nothing
            Me.TextBoxGeneral_Division.TabIndex = 5
            Me.TextBoxGeneral_Division.TabOnEnter = True
            '
            'LabelGeneral_EndingDate
            '
            Me.LabelGeneral_EndingDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_EndingDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_EndingDate.Location = New System.Drawing.Point(6, 316)
            Me.LabelGeneral_EndingDate.Name = "LabelGeneral_EndingDate"
            Me.LabelGeneral_EndingDate.Size = New System.Drawing.Size(87, 20)
            Me.LabelGeneral_EndingDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_EndingDate.TabIndex = 25
            Me.LabelGeneral_EndingDate.Text = "Ending Date:"
            '
            'TextBoxGeneral_Client
            '
            Me.TextBoxGeneral_Client.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxGeneral_Client.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxGeneral_Client.Border.Class = "TextBoxBorder"
            Me.TextBoxGeneral_Client.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxGeneral_Client.CheckSpellingOnValidate = False
            Me.TextBoxGeneral_Client.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxGeneral_Client.Enabled = False
            Me.TextBoxGeneral_Client.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxGeneral_Client.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxGeneral_Client.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxGeneral_Client.FocusHighlightEnabled = True
            Me.TextBoxGeneral_Client.ForeColor = System.Drawing.Color.Black
            Me.TextBoxGeneral_Client.Location = New System.Drawing.Point(97, 30)
            Me.TextBoxGeneral_Client.MaxFileSize = CType(0, Long)
            Me.TextBoxGeneral_Client.Name = "TextBoxGeneral_Client"
            Me.TextBoxGeneral_Client.ReadOnly = True
            Me.TextBoxGeneral_Client.SecurityEnabled = True
            Me.TextBoxGeneral_Client.ShowSpellCheckCompleteMessage = True
            Me.TextBoxGeneral_Client.Size = New System.Drawing.Size(605, 20)
            Me.TextBoxGeneral_Client.StartingFolderName = Nothing
            Me.TextBoxGeneral_Client.TabIndex = 3
            Me.TextBoxGeneral_Client.TabOnEnter = True
            '
            'GroupBoxGeneral_Comments
            '
            Me.GroupBoxGeneral_Comments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxGeneral_Comments.Controls.Add(Me.TextBoxComments_Comments)
            Me.GroupBoxGeneral_Comments.Location = New System.Drawing.Point(4, 394)
            Me.GroupBoxGeneral_Comments.Name = "GroupBoxGeneral_Comments"
            Me.GroupBoxGeneral_Comments.Size = New System.Drawing.Size(698, 102)
            Me.GroupBoxGeneral_Comments.TabIndex = 32
            Me.GroupBoxGeneral_Comments.Text = "Comments"
            '
            'TextBoxComments_Comments
            '
            Me.TextBoxComments_Comments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxComments_Comments.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxComments_Comments.Border.Class = "TextBoxBorder"
            Me.TextBoxComments_Comments.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxComments_Comments.CheckSpellingOnValidate = False
            Me.TextBoxComments_Comments.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxComments_Comments.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxComments_Comments.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxComments_Comments.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxComments_Comments.FocusHighlightEnabled = True
            Me.TextBoxComments_Comments.ForeColor = System.Drawing.Color.Black
            Me.TextBoxComments_Comments.Location = New System.Drawing.Point(5, 25)
            Me.TextBoxComments_Comments.MaxFileSize = CType(0, Long)
            Me.TextBoxComments_Comments.Multiline = True
            Me.TextBoxComments_Comments.Name = "TextBoxComments_Comments"
            Me.TextBoxComments_Comments.SecurityEnabled = True
            Me.TextBoxComments_Comments.ShowSpellCheckCompleteMessage = True
            Me.TextBoxComments_Comments.Size = New System.Drawing.Size(688, 72)
            Me.TextBoxComments_Comments.StartingFolderName = Nothing
            Me.TextBoxComments_Comments.TabIndex = 0
            Me.TextBoxComments_Comments.TabOnEnter = True
            '
            'GroupBoxGeneral_MediaTypes
            '
            Me.GroupBoxGeneral_MediaTypes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxGeneral_MediaTypes.Controls.Add(Me.TextBoxMediaTypes_Other)
            Me.GroupBoxGeneral_MediaTypes.Controls.Add(Me.CheckBoxMediaTypes_Other)
            Me.GroupBoxGeneral_MediaTypes.Controls.Add(Me.CheckBoxMediaTypes_DirectResponse)
            Me.GroupBoxGeneral_MediaTypes.Controls.Add(Me.CheckBoxMediaTypes_PrintCollateral)
            Me.GroupBoxGeneral_MediaTypes.Controls.Add(Me.CheckBoxMediaTypes_Television)
            Me.GroupBoxGeneral_MediaTypes.Controls.Add(Me.CheckBoxMediaTypes_Radio)
            Me.GroupBoxGeneral_MediaTypes.Controls.Add(Me.CheckBoxMediaTypes_OutOfHome)
            Me.GroupBoxGeneral_MediaTypes.Controls.Add(Me.CheckBoxMediaTypes_Internet)
            Me.GroupBoxGeneral_MediaTypes.Controls.Add(Me.CheckBoxMediaTypes_Newspaper)
            Me.GroupBoxGeneral_MediaTypes.Controls.Add(Me.CheckBoxMediaTypes_Magazine)
            Me.GroupBoxGeneral_MediaTypes.Location = New System.Drawing.Point(278, 238)
            Me.GroupBoxGeneral_MediaTypes.Name = "GroupBoxGeneral_MediaTypes"
            Me.GroupBoxGeneral_MediaTypes.Size = New System.Drawing.Size(424, 102)
            Me.GroupBoxGeneral_MediaTypes.TabIndex = 27
            Me.GroupBoxGeneral_MediaTypes.Text = "Media Types"
            '
            'TextBoxMediaTypes_Other
            '
            Me.TextBoxMediaTypes_Other.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxMediaTypes_Other.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxMediaTypes_Other.Border.Class = "TextBoxBorder"
            Me.TextBoxMediaTypes_Other.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxMediaTypes_Other.CheckSpellingOnValidate = False
            Me.TextBoxMediaTypes_Other.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxMediaTypes_Other.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxMediaTypes_Other.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxMediaTypes_Other.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxMediaTypes_Other.FocusHighlightEnabled = True
            Me.TextBoxMediaTypes_Other.ForeColor = System.Drawing.Color.Black
            Me.TextBoxMediaTypes_Other.Location = New System.Drawing.Point(86, 77)
            Me.TextBoxMediaTypes_Other.MaxFileSize = CType(0, Long)
            Me.TextBoxMediaTypes_Other.Name = "TextBoxMediaTypes_Other"
            Me.TextBoxMediaTypes_Other.SecurityEnabled = True
            Me.TextBoxMediaTypes_Other.ShowSpellCheckCompleteMessage = True
            Me.TextBoxMediaTypes_Other.Size = New System.Drawing.Size(333, 21)
            Me.TextBoxMediaTypes_Other.StartingFolderName = Nothing
            Me.TextBoxMediaTypes_Other.TabIndex = 9
            Me.TextBoxMediaTypes_Other.TabOnEnter = True
            '
            'CheckBoxMediaTypes_Other
            '
            Me.CheckBoxMediaTypes_Other.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxMediaTypes_Other.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMediaTypes_Other.CheckValue = 0
            Me.CheckBoxMediaTypes_Other.CheckValueChecked = 1
            Me.CheckBoxMediaTypes_Other.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxMediaTypes_Other.CheckValueUnchecked = 0
            Me.CheckBoxMediaTypes_Other.ChildControls = CType(resources.GetObject("CheckBoxMediaTypes_Other.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMediaTypes_Other.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMediaTypes_Other.Location = New System.Drawing.Point(5, 77)
            Me.CheckBoxMediaTypes_Other.Name = "CheckBoxMediaTypes_Other"
            Me.CheckBoxMediaTypes_Other.OldestSibling = Nothing
            Me.CheckBoxMediaTypes_Other.SecurityEnabled = True
            Me.CheckBoxMediaTypes_Other.SiblingControls = CType(resources.GetObject("CheckBoxMediaTypes_Other.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMediaTypes_Other.Size = New System.Drawing.Size(75, 20)
            Me.CheckBoxMediaTypes_Other.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMediaTypes_Other.TabIndex = 8
            Me.CheckBoxMediaTypes_Other.TabOnEnter = True
            Me.CheckBoxMediaTypes_Other.Text = "Other"
            '
            'CheckBoxMediaTypes_DirectResponse
            '
            '
            '
            '
            Me.CheckBoxMediaTypes_DirectResponse.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMediaTypes_DirectResponse.CheckValue = 0
            Me.CheckBoxMediaTypes_DirectResponse.CheckValueChecked = 1
            Me.CheckBoxMediaTypes_DirectResponse.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxMediaTypes_DirectResponse.CheckValueUnchecked = 0
            Me.CheckBoxMediaTypes_DirectResponse.ChildControls = CType(resources.GetObject("CheckBoxMediaTypes_DirectResponse.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMediaTypes_DirectResponse.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMediaTypes_DirectResponse.Location = New System.Drawing.Point(266, 51)
            Me.CheckBoxMediaTypes_DirectResponse.Name = "CheckBoxMediaTypes_DirectResponse"
            Me.CheckBoxMediaTypes_DirectResponse.OldestSibling = Nothing
            Me.CheckBoxMediaTypes_DirectResponse.SecurityEnabled = True
            Me.CheckBoxMediaTypes_DirectResponse.SiblingControls = CType(resources.GetObject("CheckBoxMediaTypes_DirectResponse.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMediaTypes_DirectResponse.Size = New System.Drawing.Size(106, 20)
            Me.CheckBoxMediaTypes_DirectResponse.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMediaTypes_DirectResponse.TabIndex = 7
            Me.CheckBoxMediaTypes_DirectResponse.TabOnEnter = True
            Me.CheckBoxMediaTypes_DirectResponse.Text = "Direct Response"
            '
            'CheckBoxMediaTypes_PrintCollateral
            '
            '
            '
            '
            Me.CheckBoxMediaTypes_PrintCollateral.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMediaTypes_PrintCollateral.CheckValue = 0
            Me.CheckBoxMediaTypes_PrintCollateral.CheckValueChecked = 1
            Me.CheckBoxMediaTypes_PrintCollateral.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxMediaTypes_PrintCollateral.CheckValueUnchecked = 0
            Me.CheckBoxMediaTypes_PrintCollateral.ChildControls = CType(resources.GetObject("CheckBoxMediaTypes_PrintCollateral.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMediaTypes_PrintCollateral.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMediaTypes_PrintCollateral.Location = New System.Drawing.Point(167, 51)
            Me.CheckBoxMediaTypes_PrintCollateral.Name = "CheckBoxMediaTypes_PrintCollateral"
            Me.CheckBoxMediaTypes_PrintCollateral.OldestSibling = Nothing
            Me.CheckBoxMediaTypes_PrintCollateral.SecurityEnabled = True
            Me.CheckBoxMediaTypes_PrintCollateral.SiblingControls = CType(resources.GetObject("CheckBoxMediaTypes_PrintCollateral.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMediaTypes_PrintCollateral.Size = New System.Drawing.Size(93, 20)
            Me.CheckBoxMediaTypes_PrintCollateral.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMediaTypes_PrintCollateral.TabIndex = 6
            Me.CheckBoxMediaTypes_PrintCollateral.TabOnEnter = True
            Me.CheckBoxMediaTypes_PrintCollateral.Text = "Print/Collateral"
            '
            'CheckBoxMediaTypes_Television
            '
            '
            '
            '
            Me.CheckBoxMediaTypes_Television.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMediaTypes_Television.CheckValue = 0
            Me.CheckBoxMediaTypes_Television.CheckValueChecked = 1
            Me.CheckBoxMediaTypes_Television.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxMediaTypes_Television.CheckValueUnchecked = 0
            Me.CheckBoxMediaTypes_Television.ChildControls = CType(resources.GetObject("CheckBoxMediaTypes_Television.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMediaTypes_Television.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMediaTypes_Television.Location = New System.Drawing.Point(86, 51)
            Me.CheckBoxMediaTypes_Television.Name = "CheckBoxMediaTypes_Television"
            Me.CheckBoxMediaTypes_Television.OldestSibling = Nothing
            Me.CheckBoxMediaTypes_Television.SecurityEnabled = True
            Me.CheckBoxMediaTypes_Television.SiblingControls = CType(resources.GetObject("CheckBoxMediaTypes_Television.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMediaTypes_Television.Size = New System.Drawing.Size(75, 20)
            Me.CheckBoxMediaTypes_Television.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMediaTypes_Television.TabIndex = 5
            Me.CheckBoxMediaTypes_Television.TabOnEnter = True
            Me.CheckBoxMediaTypes_Television.Text = "Television"
            '
            'CheckBoxMediaTypes_Radio
            '
            '
            '
            '
            Me.CheckBoxMediaTypes_Radio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMediaTypes_Radio.CheckValue = 0
            Me.CheckBoxMediaTypes_Radio.CheckValueChecked = 1
            Me.CheckBoxMediaTypes_Radio.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxMediaTypes_Radio.CheckValueUnchecked = 0
            Me.CheckBoxMediaTypes_Radio.ChildControls = CType(resources.GetObject("CheckBoxMediaTypes_Radio.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMediaTypes_Radio.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMediaTypes_Radio.Location = New System.Drawing.Point(5, 51)
            Me.CheckBoxMediaTypes_Radio.Name = "CheckBoxMediaTypes_Radio"
            Me.CheckBoxMediaTypes_Radio.OldestSibling = Nothing
            Me.CheckBoxMediaTypes_Radio.SecurityEnabled = True
            Me.CheckBoxMediaTypes_Radio.SiblingControls = CType(resources.GetObject("CheckBoxMediaTypes_Radio.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMediaTypes_Radio.Size = New System.Drawing.Size(75, 20)
            Me.CheckBoxMediaTypes_Radio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMediaTypes_Radio.TabIndex = 4
            Me.CheckBoxMediaTypes_Radio.TabOnEnter = True
            Me.CheckBoxMediaTypes_Radio.Text = "Radio"
            '
            'CheckBoxMediaTypes_OutOfHome
            '
            '
            '
            '
            Me.CheckBoxMediaTypes_OutOfHome.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMediaTypes_OutOfHome.CheckValue = 0
            Me.CheckBoxMediaTypes_OutOfHome.CheckValueChecked = 1
            Me.CheckBoxMediaTypes_OutOfHome.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxMediaTypes_OutOfHome.CheckValueUnchecked = 0
            Me.CheckBoxMediaTypes_OutOfHome.ChildControls = CType(resources.GetObject("CheckBoxMediaTypes_OutOfHome.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMediaTypes_OutOfHome.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMediaTypes_OutOfHome.Location = New System.Drawing.Point(167, 25)
            Me.CheckBoxMediaTypes_OutOfHome.Name = "CheckBoxMediaTypes_OutOfHome"
            Me.CheckBoxMediaTypes_OutOfHome.OldestSibling = Nothing
            Me.CheckBoxMediaTypes_OutOfHome.SecurityEnabled = True
            Me.CheckBoxMediaTypes_OutOfHome.SiblingControls = CType(resources.GetObject("CheckBoxMediaTypes_OutOfHome.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMediaTypes_OutOfHome.Size = New System.Drawing.Size(93, 20)
            Me.CheckBoxMediaTypes_OutOfHome.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMediaTypes_OutOfHome.TabIndex = 2
            Me.CheckBoxMediaTypes_OutOfHome.TabOnEnter = True
            Me.CheckBoxMediaTypes_OutOfHome.Text = "Out Of Home"
            '
            'CheckBoxMediaTypes_Internet
            '
            '
            '
            '
            Me.CheckBoxMediaTypes_Internet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMediaTypes_Internet.CheckValue = 0
            Me.CheckBoxMediaTypes_Internet.CheckValueChecked = 1
            Me.CheckBoxMediaTypes_Internet.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxMediaTypes_Internet.CheckValueUnchecked = 0
            Me.CheckBoxMediaTypes_Internet.ChildControls = CType(resources.GetObject("CheckBoxMediaTypes_Internet.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMediaTypes_Internet.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMediaTypes_Internet.Location = New System.Drawing.Point(266, 25)
            Me.CheckBoxMediaTypes_Internet.Name = "CheckBoxMediaTypes_Internet"
            Me.CheckBoxMediaTypes_Internet.OldestSibling = Nothing
            Me.CheckBoxMediaTypes_Internet.SecurityEnabled = True
            Me.CheckBoxMediaTypes_Internet.SiblingControls = CType(resources.GetObject("CheckBoxMediaTypes_Internet.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMediaTypes_Internet.Size = New System.Drawing.Size(93, 20)
            Me.CheckBoxMediaTypes_Internet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMediaTypes_Internet.TabIndex = 3
            Me.CheckBoxMediaTypes_Internet.TabOnEnter = True
            Me.CheckBoxMediaTypes_Internet.Text = "Internet"
            '
            'CheckBoxMediaTypes_Newspaper
            '
            '
            '
            '
            Me.CheckBoxMediaTypes_Newspaper.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMediaTypes_Newspaper.CheckValue = 0
            Me.CheckBoxMediaTypes_Newspaper.CheckValueChecked = 1
            Me.CheckBoxMediaTypes_Newspaper.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxMediaTypes_Newspaper.CheckValueUnchecked = 0
            Me.CheckBoxMediaTypes_Newspaper.ChildControls = CType(resources.GetObject("CheckBoxMediaTypes_Newspaper.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMediaTypes_Newspaper.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMediaTypes_Newspaper.Location = New System.Drawing.Point(5, 25)
            Me.CheckBoxMediaTypes_Newspaper.Name = "CheckBoxMediaTypes_Newspaper"
            Me.CheckBoxMediaTypes_Newspaper.OldestSibling = Nothing
            Me.CheckBoxMediaTypes_Newspaper.SecurityEnabled = True
            Me.CheckBoxMediaTypes_Newspaper.SiblingControls = CType(resources.GetObject("CheckBoxMediaTypes_Newspaper.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMediaTypes_Newspaper.Size = New System.Drawing.Size(75, 20)
            Me.CheckBoxMediaTypes_Newspaper.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMediaTypes_Newspaper.TabIndex = 0
            Me.CheckBoxMediaTypes_Newspaper.TabOnEnter = True
            Me.CheckBoxMediaTypes_Newspaper.Text = "Newspaper"
            '
            'CheckBoxMediaTypes_Magazine
            '
            '
            '
            '
            Me.CheckBoxMediaTypes_Magazine.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMediaTypes_Magazine.CheckValue = 0
            Me.CheckBoxMediaTypes_Magazine.CheckValueChecked = 1
            Me.CheckBoxMediaTypes_Magazine.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxMediaTypes_Magazine.CheckValueUnchecked = 0
            Me.CheckBoxMediaTypes_Magazine.ChildControls = CType(resources.GetObject("CheckBoxMediaTypes_Magazine.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMediaTypes_Magazine.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMediaTypes_Magazine.Location = New System.Drawing.Point(86, 25)
            Me.CheckBoxMediaTypes_Magazine.Name = "CheckBoxMediaTypes_Magazine"
            Me.CheckBoxMediaTypes_Magazine.OldestSibling = Nothing
            Me.CheckBoxMediaTypes_Magazine.SecurityEnabled = True
            Me.CheckBoxMediaTypes_Magazine.SiblingControls = CType(resources.GetObject("CheckBoxMediaTypes_Magazine.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMediaTypes_Magazine.Size = New System.Drawing.Size(75, 20)
            Me.CheckBoxMediaTypes_Magazine.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMediaTypes_Magazine.TabIndex = 1
            Me.CheckBoxMediaTypes_Magazine.TabOnEnter = True
            Me.CheckBoxMediaTypes_Magazine.Text = "Magazine"
            '
            'LabelGeneral_Name
            '
            Me.LabelGeneral_Name.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_Name.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_Name.Location = New System.Drawing.Point(303, 108)
            Me.LabelGeneral_Name.Name = "LabelGeneral_Name"
            Me.LabelGeneral_Name.Size = New System.Drawing.Size(35, 20)
            Me.LabelGeneral_Name.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_Name.TabIndex = 10
            Me.LabelGeneral_Name.Text = "Name:"
            '
            'TextBoxGeneral_Name
            '
            Me.TextBoxGeneral_Name.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxGeneral_Name.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxGeneral_Name.Border.Class = "TextBoxBorder"
            Me.TextBoxGeneral_Name.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxGeneral_Name.CheckSpellingOnValidate = False
            Me.TextBoxGeneral_Name.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxGeneral_Name.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxGeneral_Name.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxGeneral_Name.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxGeneral_Name.FocusHighlightEnabled = True
            Me.TextBoxGeneral_Name.ForeColor = System.Drawing.Color.Black
            Me.TextBoxGeneral_Name.Location = New System.Drawing.Point(344, 108)
            Me.TextBoxGeneral_Name.MaxFileSize = CType(0, Long)
            Me.TextBoxGeneral_Name.Name = "TextBoxGeneral_Name"
            Me.TextBoxGeneral_Name.SecurityEnabled = True
            Me.TextBoxGeneral_Name.ShowSpellCheckCompleteMessage = True
            Me.TextBoxGeneral_Name.Size = New System.Drawing.Size(358, 20)
            Me.TextBoxGeneral_Name.StartingFolderName = Nothing
            Me.TextBoxGeneral_Name.TabIndex = 11
            Me.TextBoxGeneral_Name.TabOnEnter = True
            '
            'RadioButtonGeneral_Overall
            '
            Me.RadioButtonGeneral_Overall.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonGeneral_Overall.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonGeneral_Overall.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonGeneral_Overall.Location = New System.Drawing.Point(99, 264)
            Me.RadioButtonGeneral_Overall.Name = "RadioButtonGeneral_Overall"
            Me.RadioButtonGeneral_Overall.SecurityEnabled = True
            Me.RadioButtonGeneral_Overall.Size = New System.Drawing.Size(173, 20)
            Me.RadioButtonGeneral_Overall.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonGeneral_Overall.TabIndex = 22
            Me.RadioButtonGeneral_Overall.TabOnEnter = True
            Me.RadioButtonGeneral_Overall.TabStop = False
            Me.RadioButtonGeneral_Overall.Text = "Overall"
            '
            'RadioButtonGeneral_AssignedToJobsAndOrders
            '
            Me.RadioButtonGeneral_AssignedToJobsAndOrders.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonGeneral_AssignedToJobsAndOrders.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonGeneral_AssignedToJobsAndOrders.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonGeneral_AssignedToJobsAndOrders.Checked = True
            Me.RadioButtonGeneral_AssignedToJobsAndOrders.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonGeneral_AssignedToJobsAndOrders.CheckValue = "Y"
            Me.RadioButtonGeneral_AssignedToJobsAndOrders.Location = New System.Drawing.Point(99, 238)
            Me.RadioButtonGeneral_AssignedToJobsAndOrders.Name = "RadioButtonGeneral_AssignedToJobsAndOrders"
            Me.RadioButtonGeneral_AssignedToJobsAndOrders.SecurityEnabled = True
            Me.RadioButtonGeneral_AssignedToJobsAndOrders.Size = New System.Drawing.Size(173, 20)
            Me.RadioButtonGeneral_AssignedToJobsAndOrders.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonGeneral_AssignedToJobsAndOrders.TabIndex = 21
            Me.RadioButtonGeneral_AssignedToJobsAndOrders.TabOnEnter = True
            Me.RadioButtonGeneral_AssignedToJobsAndOrders.Text = "Assigned to Jobs and Orders"
            '
            'ComboBoxGeneral_AlertGroup
            '
            Me.ComboBoxGeneral_AlertGroup.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxGeneral_AlertGroup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxGeneral_AlertGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxGeneral_AlertGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxGeneral_AlertGroup.AutoFindItemInDataSource = False
            Me.ComboBoxGeneral_AlertGroup.AutoSelectSingleItemDatasource = False
            Me.ComboBoxGeneral_AlertGroup.BookmarkingEnabled = False
            Me.ComboBoxGeneral_AlertGroup.ClientCode = ""
            Me.ComboBoxGeneral_AlertGroup.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.AlertGroup
            Me.ComboBoxGeneral_AlertGroup.DisableMouseWheel = False
            Me.ComboBoxGeneral_AlertGroup.DisplayMember = "Description"
            Me.ComboBoxGeneral_AlertGroup.DisplayName = ""
            Me.ComboBoxGeneral_AlertGroup.DivisionCode = ""
            Me.ComboBoxGeneral_AlertGroup.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxGeneral_AlertGroup.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxGeneral_AlertGroup.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxGeneral_AlertGroup.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxGeneral_AlertGroup.FocusHighlightEnabled = True
            Me.ComboBoxGeneral_AlertGroup.FormattingEnabled = True
            Me.ComboBoxGeneral_AlertGroup.ItemHeight = 14
            Me.ComboBoxGeneral_AlertGroup.Location = New System.Drawing.Point(97, 134)
            Me.ComboBoxGeneral_AlertGroup.Name = "ComboBoxGeneral_AlertGroup"
            Me.ComboBoxGeneral_AlertGroup.ReadOnly = False
            Me.ComboBoxGeneral_AlertGroup.SecurityEnabled = True
            Me.ComboBoxGeneral_AlertGroup.Size = New System.Drawing.Size(605, 20)
            Me.ComboBoxGeneral_AlertGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxGeneral_AlertGroup.TabIndex = 13
            Me.ComboBoxGeneral_AlertGroup.TabOnEnter = True
            Me.ComboBoxGeneral_AlertGroup.ValueMember = "Code"
            Me.ComboBoxGeneral_AlertGroup.WatermarkText = "Select Alert Group"
            '
            'LabelGeneral_AlertGroup
            '
            Me.LabelGeneral_AlertGroup.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_AlertGroup.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_AlertGroup.Location = New System.Drawing.Point(4, 134)
            Me.LabelGeneral_AlertGroup.Name = "LabelGeneral_AlertGroup"
            Me.LabelGeneral_AlertGroup.Size = New System.Drawing.Size(87, 20)
            Me.LabelGeneral_AlertGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_AlertGroup.TabIndex = 12
            Me.LabelGeneral_AlertGroup.Text = "Alert Group:"
            '
            'LabelGeneral_Code
            '
            Me.LabelGeneral_Code.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_Code.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_Code.Location = New System.Drawing.Point(167, 108)
            Me.LabelGeneral_Code.Name = "LabelGeneral_Code"
            Me.LabelGeneral_Code.Size = New System.Drawing.Size(34, 20)
            Me.LabelGeneral_Code.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_Code.TabIndex = 8
            Me.LabelGeneral_Code.Text = "Code:"
            '
            'TextBoxGeneral_Code
            '
            Me.TextBoxGeneral_Code.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxGeneral_Code.Border.Class = "TextBoxBorder"
            Me.TextBoxGeneral_Code.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxGeneral_Code.CheckSpellingOnValidate = False
            Me.TextBoxGeneral_Code.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxGeneral_Code.Enabled = False
            Me.TextBoxGeneral_Code.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxGeneral_Code.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxGeneral_Code.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxGeneral_Code.FocusHighlightEnabled = True
            Me.TextBoxGeneral_Code.ForeColor = System.Drawing.Color.Black
            Me.TextBoxGeneral_Code.Location = New System.Drawing.Point(207, 108)
            Me.TextBoxGeneral_Code.MaxFileSize = CType(0, Long)
            Me.TextBoxGeneral_Code.Name = "TextBoxGeneral_Code"
            Me.TextBoxGeneral_Code.ReadOnly = True
            Me.TextBoxGeneral_Code.SecurityEnabled = True
            Me.TextBoxGeneral_Code.ShowSpellCheckCompleteMessage = True
            Me.TextBoxGeneral_Code.Size = New System.Drawing.Size(90, 20)
            Me.TextBoxGeneral_Code.StartingFolderName = Nothing
            Me.TextBoxGeneral_Code.TabIndex = 9
            Me.TextBoxGeneral_Code.TabOnEnter = True
            '
            'ComboBoxGeneral_Office
            '
            Me.ComboBoxGeneral_Office.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxGeneral_Office.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxGeneral_Office.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxGeneral_Office.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxGeneral_Office.AutoFindItemInDataSource = False
            Me.ComboBoxGeneral_Office.AutoSelectSingleItemDatasource = False
            Me.ComboBoxGeneral_Office.BookmarkingEnabled = False
            Me.ComboBoxGeneral_Office.ClientCode = ""
            Me.ComboBoxGeneral_Office.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Office
            Me.ComboBoxGeneral_Office.DisableMouseWheel = False
            Me.ComboBoxGeneral_Office.DisplayMember = "Name"
            Me.ComboBoxGeneral_Office.DisplayName = ""
            Me.ComboBoxGeneral_Office.DivisionCode = ""
            Me.ComboBoxGeneral_Office.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxGeneral_Office.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxGeneral_Office.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxGeneral_Office.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxGeneral_Office.FocusHighlightEnabled = True
            Me.ComboBoxGeneral_Office.FormattingEnabled = True
            Me.ComboBoxGeneral_Office.ItemHeight = 14
            Me.ComboBoxGeneral_Office.Location = New System.Drawing.Point(97, 4)
            Me.ComboBoxGeneral_Office.Name = "ComboBoxGeneral_Office"
            Me.ComboBoxGeneral_Office.ReadOnly = False
            Me.ComboBoxGeneral_Office.SecurityEnabled = True
            Me.ComboBoxGeneral_Office.Size = New System.Drawing.Size(605, 20)
            Me.ComboBoxGeneral_Office.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxGeneral_Office.TabIndex = 1
            Me.ComboBoxGeneral_Office.TabOnEnter = True
            Me.ComboBoxGeneral_Office.ValueMember = "Code"
            Me.ComboBoxGeneral_Office.WatermarkText = "Select Office"
            '
            'LabelGeneral_Product
            '
            Me.LabelGeneral_Product.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_Product.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_Product.Location = New System.Drawing.Point(4, 82)
            Me.LabelGeneral_Product.Name = "LabelGeneral_Product"
            Me.LabelGeneral_Product.Size = New System.Drawing.Size(87, 20)
            Me.LabelGeneral_Product.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_Product.TabIndex = 6
            Me.LabelGeneral_Product.Text = "Product:"
            '
            'LabelGeneral_Division
            '
            Me.LabelGeneral_Division.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_Division.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_Division.Location = New System.Drawing.Point(4, 56)
            Me.LabelGeneral_Division.Name = "LabelGeneral_Division"
            Me.LabelGeneral_Division.Size = New System.Drawing.Size(87, 20)
            Me.LabelGeneral_Division.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_Division.TabIndex = 4
            Me.LabelGeneral_Division.Text = "Division:"
            '
            'LabelGeneral_Client
            '
            Me.LabelGeneral_Client.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_Client.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_Client.Location = New System.Drawing.Point(4, 30)
            Me.LabelGeneral_Client.Name = "LabelGeneral_Client"
            Me.LabelGeneral_Client.Size = New System.Drawing.Size(87, 20)
            Me.LabelGeneral_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_Client.TabIndex = 2
            Me.LabelGeneral_Client.Text = "Client:"
            '
            'LabelGeneral_CampaignType
            '
            Me.LabelGeneral_CampaignType.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_CampaignType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_CampaignType.Location = New System.Drawing.Point(6, 238)
            Me.LabelGeneral_CampaignType.Name = "LabelGeneral_CampaignType"
            Me.LabelGeneral_CampaignType.Size = New System.Drawing.Size(87, 20)
            Me.LabelGeneral_CampaignType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_CampaignType.TabIndex = 20
            Me.LabelGeneral_CampaignType.Text = "Campaign Type:"
            '
            'LabelGeneral_Office
            '
            Me.LabelGeneral_Office.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_Office.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_Office.Location = New System.Drawing.Point(4, 4)
            Me.LabelGeneral_Office.Name = "LabelGeneral_Office"
            Me.LabelGeneral_Office.Size = New System.Drawing.Size(87, 20)
            Me.LabelGeneral_Office.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_Office.TabIndex = 0
            Me.LabelGeneral_Office.Text = "Office:"
            '
            'TabItemCampaignDetails_GeneralTab
            '
            Me.TabItemCampaignDetails_GeneralTab.AttachedControl = Me.TabControlPanelGeneralTab_General
            Me.TabItemCampaignDetails_GeneralTab.Name = "TabItemCampaignDetails_GeneralTab"
            Me.TabItemCampaignDetails_GeneralTab.Text = "General"
            '
            'TabControlPanelDocumentsTab_Documents
            '
            Me.TabControlPanelDocumentsTab_Documents.Controls.Add(Me.DocumentManagerControlDocuments_CampaignDocuments)
            Me.TabControlPanelDocumentsTab_Documents.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelDocumentsTab_Documents.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelDocumentsTab_Documents.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelDocumentsTab_Documents.Name = "TabControlPanelDocumentsTab_Documents"
            Me.TabControlPanelDocumentsTab_Documents.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelDocumentsTab_Documents.Size = New System.Drawing.Size(706, 500)
            Me.TabControlPanelDocumentsTab_Documents.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelDocumentsTab_Documents.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDocumentsTab_Documents.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelDocumentsTab_Documents.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelDocumentsTab_Documents.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelDocumentsTab_Documents.Style.GradientAngle = 90
            Me.TabControlPanelDocumentsTab_Documents.TabIndex = 3
            Me.TabControlPanelDocumentsTab_Documents.TabItem = Me.TabItemCampaignDetails_DocumentsTab
            '
            'DocumentManagerControlDocuments_CampaignDocuments
            '
            Me.DocumentManagerControlDocuments_CampaignDocuments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DocumentManagerControlDocuments_CampaignDocuments.Location = New System.Drawing.Point(6, 4)
            Me.DocumentManagerControlDocuments_CampaignDocuments.Name = "DocumentManagerControlDocuments_CampaignDocuments"
            Me.DocumentManagerControlDocuments_CampaignDocuments.Size = New System.Drawing.Size(694, 492)
            Me.DocumentManagerControlDocuments_CampaignDocuments.TabIndex = 0
            '
            'TabItemCampaignDetails_DocumentsTab
            '
            Me.TabItemCampaignDetails_DocumentsTab.AttachedControl = Me.TabControlPanelDocumentsTab_Documents
            Me.TabItemCampaignDetails_DocumentsTab.Name = "TabItemCampaignDetails_DocumentsTab"
            Me.TabItemCampaignDetails_DocumentsTab.Text = "Documents"
            '
            'TabControlPanelJobsAndMediaOrdersTab_JobsAndMediaOrders
            '
            Me.TabControlPanelJobsAndMediaOrdersTab_JobsAndMediaOrders.Controls.Add(Me.PanelJobsAndMediaOrders_RightSection)
            Me.TabControlPanelJobsAndMediaOrdersTab_JobsAndMediaOrders.Controls.Add(Me.ExpandableSplitterJobsAndMediaOrders_LeftRight)
            Me.TabControlPanelJobsAndMediaOrdersTab_JobsAndMediaOrders.Controls.Add(Me.PanelJobsAndMediaOrders_LeftSection)
            Me.TabControlPanelJobsAndMediaOrdersTab_JobsAndMediaOrders.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelJobsAndMediaOrdersTab_JobsAndMediaOrders.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelJobsAndMediaOrdersTab_JobsAndMediaOrders.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelJobsAndMediaOrdersTab_JobsAndMediaOrders.Name = "TabControlPanelJobsAndMediaOrdersTab_JobsAndMediaOrders"
            Me.TabControlPanelJobsAndMediaOrdersTab_JobsAndMediaOrders.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelJobsAndMediaOrdersTab_JobsAndMediaOrders.Size = New System.Drawing.Size(706, 500)
            Me.TabControlPanelJobsAndMediaOrdersTab_JobsAndMediaOrders.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelJobsAndMediaOrdersTab_JobsAndMediaOrders.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelJobsAndMediaOrdersTab_JobsAndMediaOrders.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelJobsAndMediaOrdersTab_JobsAndMediaOrders.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelJobsAndMediaOrdersTab_JobsAndMediaOrders.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelJobsAndMediaOrdersTab_JobsAndMediaOrders.Style.GradientAngle = 90
            Me.TabControlPanelJobsAndMediaOrdersTab_JobsAndMediaOrders.TabIndex = 2
            Me.TabControlPanelJobsAndMediaOrdersTab_JobsAndMediaOrders.TabItem = Me.TabItemCampaignDetails_JobsAndMediaOrdersTab
            '
            'PanelJobsAndMediaOrders_RightSection
            '
            Me.PanelJobsAndMediaOrders_RightSection.Controls.Add(Me.ButtonRightSection_AddJobsAndMediaOrders)
            Me.PanelJobsAndMediaOrders_RightSection.Controls.Add(Me.ButtonRightSection_RemoveJobsAndMediaOrders)
            Me.PanelJobsAndMediaOrders_RightSection.Controls.Add(Me.DataGridViewRightSection_JobsAndMediaOrders)
            Me.PanelJobsAndMediaOrders_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelJobsAndMediaOrders_RightSection.Location = New System.Drawing.Point(347, 1)
            Me.PanelJobsAndMediaOrders_RightSection.Name = "PanelJobsAndMediaOrders_RightSection"
            Me.PanelJobsAndMediaOrders_RightSection.Size = New System.Drawing.Size(358, 498)
            Me.PanelJobsAndMediaOrders_RightSection.TabIndex = 2
            '
            'ButtonRightSection_AddJobsAndMediaOrders
            '
            Me.ButtonRightSection_AddJobsAndMediaOrders.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_AddJobsAndMediaOrders.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_AddJobsAndMediaOrders.Location = New System.Drawing.Point(5, 5)
            Me.ButtonRightSection_AddJobsAndMediaOrders.Name = "ButtonRightSection_AddJobsAndMediaOrders"
            Me.ButtonRightSection_AddJobsAndMediaOrders.SecurityEnabled = True
            Me.ButtonRightSection_AddJobsAndMediaOrders.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightSection_AddJobsAndMediaOrders.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_AddJobsAndMediaOrders.TabIndex = 0
            Me.ButtonRightSection_AddJobsAndMediaOrders.Text = ">"
            '
            'ButtonRightSection_RemoveJobsAndMediaOrders
            '
            Me.ButtonRightSection_RemoveJobsAndMediaOrders.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_RemoveJobsAndMediaOrders.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_RemoveJobsAndMediaOrders.Location = New System.Drawing.Point(5, 31)
            Me.ButtonRightSection_RemoveJobsAndMediaOrders.Name = "ButtonRightSection_RemoveJobsAndMediaOrders"
            Me.ButtonRightSection_RemoveJobsAndMediaOrders.SecurityEnabled = True
            Me.ButtonRightSection_RemoveJobsAndMediaOrders.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightSection_RemoveJobsAndMediaOrders.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_RemoveJobsAndMediaOrders.TabIndex = 1
            Me.ButtonRightSection_RemoveJobsAndMediaOrders.Text = "<"
            '
            'DataGridViewRightSection_JobsAndMediaOrders
            '
            Me.DataGridViewRightSection_JobsAndMediaOrders.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewRightSection_JobsAndMediaOrders.AllowDragAndDrop = False
            Me.DataGridViewRightSection_JobsAndMediaOrders.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewRightSection_JobsAndMediaOrders.AllowSelectGroupHeaderRow = True
            Me.DataGridViewRightSection_JobsAndMediaOrders.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewRightSection_JobsAndMediaOrders.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRightSection_JobsAndMediaOrders.AutoFilterLookupColumns = False
            Me.DataGridViewRightSection_JobsAndMediaOrders.AutoloadRepositoryDatasource = True
            Me.DataGridViewRightSection_JobsAndMediaOrders.AutoUpdateViewCaption = True
            Me.DataGridViewRightSection_JobsAndMediaOrders.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewRightSection_JobsAndMediaOrders.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewRightSection_JobsAndMediaOrders.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRightSection_JobsAndMediaOrders.ItemDescription = "Associated Jobs and Media Orders"
            Me.DataGridViewRightSection_JobsAndMediaOrders.Location = New System.Drawing.Point(86, 5)
            Me.DataGridViewRightSection_JobsAndMediaOrders.MultiSelect = True
            Me.DataGridViewRightSection_JobsAndMediaOrders.Name = "DataGridViewRightSection_JobsAndMediaOrders"
            Me.DataGridViewRightSection_JobsAndMediaOrders.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewRightSection_JobsAndMediaOrders.RunStandardValidation = True
            Me.DataGridViewRightSection_JobsAndMediaOrders.ShowColumnMenuOnRightClick = False
            Me.DataGridViewRightSection_JobsAndMediaOrders.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRightSection_JobsAndMediaOrders.Size = New System.Drawing.Size(267, 488)
            Me.DataGridViewRightSection_JobsAndMediaOrders.TabIndex = 2
            Me.DataGridViewRightSection_JobsAndMediaOrders.UseEmbeddedNavigator = False
            Me.DataGridViewRightSection_JobsAndMediaOrders.ViewCaptionHeight = -1
            '
            'ExpandableSplitterJobsAndMediaOrders_LeftRight
            '
            Me.ExpandableSplitterJobsAndMediaOrders_LeftRight.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterJobsAndMediaOrders_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterJobsAndMediaOrders_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterJobsAndMediaOrders_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterJobsAndMediaOrders_LeftRight.ExpandableControl = Me.PanelJobsAndMediaOrders_LeftSection
            Me.ExpandableSplitterJobsAndMediaOrders_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterJobsAndMediaOrders_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterJobsAndMediaOrders_LeftRight.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterJobsAndMediaOrders_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterJobsAndMediaOrders_LeftRight.ForeColor = System.Drawing.Color.Black
            Me.ExpandableSplitterJobsAndMediaOrders_LeftRight.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterJobsAndMediaOrders_LeftRight.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterJobsAndMediaOrders_LeftRight.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterJobsAndMediaOrders_LeftRight.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterJobsAndMediaOrders_LeftRight.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterJobsAndMediaOrders_LeftRight.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterJobsAndMediaOrders_LeftRight.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterJobsAndMediaOrders_LeftRight.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterJobsAndMediaOrders_LeftRight.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterJobsAndMediaOrders_LeftRight.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterJobsAndMediaOrders_LeftRight.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterJobsAndMediaOrders_LeftRight.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterJobsAndMediaOrders_LeftRight.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterJobsAndMediaOrders_LeftRight.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterJobsAndMediaOrders_LeftRight.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterJobsAndMediaOrders_LeftRight.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterJobsAndMediaOrders_LeftRight.Location = New System.Drawing.Point(341, 1)
            Me.ExpandableSplitterJobsAndMediaOrders_LeftRight.Name = "ExpandableSplitterJobsAndMediaOrders_LeftRight"
            Me.ExpandableSplitterJobsAndMediaOrders_LeftRight.Size = New System.Drawing.Size(6, 498)
            Me.ExpandableSplitterJobsAndMediaOrders_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterJobsAndMediaOrders_LeftRight.TabIndex = 1
            Me.ExpandableSplitterJobsAndMediaOrders_LeftRight.TabStop = False
            '
            'PanelJobsAndMediaOrders_LeftSection
            '
            Me.PanelJobsAndMediaOrders_LeftSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelJobsAndMediaOrders_LeftSection.Appearance.Options.UseBackColor = True
            Me.PanelJobsAndMediaOrders_LeftSection.Controls.Add(Me.DataGridViewLeftSection_AvailableJobsAndMediaOrders)
            Me.PanelJobsAndMediaOrders_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelJobsAndMediaOrders_LeftSection.Location = New System.Drawing.Point(1, 1)
            Me.PanelJobsAndMediaOrders_LeftSection.Name = "PanelJobsAndMediaOrders_LeftSection"
            Me.PanelJobsAndMediaOrders_LeftSection.Size = New System.Drawing.Size(340, 498)
            Me.PanelJobsAndMediaOrders_LeftSection.TabIndex = 0
            '
            'DataGridViewLeftSection_AvailableJobsAndMediaOrders
            '
            Me.DataGridViewLeftSection_AvailableJobsAndMediaOrders.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewLeftSection_AvailableJobsAndMediaOrders.AllowDragAndDrop = False
            Me.DataGridViewLeftSection_AvailableJobsAndMediaOrders.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewLeftSection_AvailableJobsAndMediaOrders.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_AvailableJobsAndMediaOrders.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_AvailableJobsAndMediaOrders.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_AvailableJobsAndMediaOrders.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_AvailableJobsAndMediaOrders.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_AvailableJobsAndMediaOrders.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_AvailableJobsAndMediaOrders.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_AvailableJobsAndMediaOrders.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_AvailableJobsAndMediaOrders.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_AvailableJobsAndMediaOrders.ItemDescription = "Available Jobs and Media Orders"
            Me.DataGridViewLeftSection_AvailableJobsAndMediaOrders.Location = New System.Drawing.Point(5, 5)
            Me.DataGridViewLeftSection_AvailableJobsAndMediaOrders.MultiSelect = True
            Me.DataGridViewLeftSection_AvailableJobsAndMediaOrders.Name = "DataGridViewLeftSection_AvailableJobsAndMediaOrders"
            Me.DataGridViewLeftSection_AvailableJobsAndMediaOrders.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_AvailableJobsAndMediaOrders.RunStandardValidation = True
            Me.DataGridViewLeftSection_AvailableJobsAndMediaOrders.ShowColumnMenuOnRightClick = False
            Me.DataGridViewLeftSection_AvailableJobsAndMediaOrders.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_AvailableJobsAndMediaOrders.Size = New System.Drawing.Size(329, 488)
            Me.DataGridViewLeftSection_AvailableJobsAndMediaOrders.TabIndex = 0
            Me.DataGridViewLeftSection_AvailableJobsAndMediaOrders.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_AvailableJobsAndMediaOrders.ViewCaptionHeight = -1
            '
            'TabItemCampaignDetails_JobsAndMediaOrdersTab
            '
            Me.TabItemCampaignDetails_JobsAndMediaOrdersTab.AttachedControl = Me.TabControlPanelJobsAndMediaOrdersTab_JobsAndMediaOrders
            Me.TabItemCampaignDetails_JobsAndMediaOrdersTab.Name = "TabItemCampaignDetails_JobsAndMediaOrdersTab"
            Me.TabItemCampaignDetails_JobsAndMediaOrdersTab.Text = "Job / Media Orders"
            '
            'TabControlPanelCampaignDetailsTab_CampaignDetails
            '
            Me.TabControlPanelCampaignDetailsTab_CampaignDetails.Controls.Add(Me.LabelCampaignDetails_IncomeTotalAllocatedAmount)
            Me.TabControlPanelCampaignDetailsTab_CampaignDetails.Controls.Add(Me.LabelCampaignDetails_IncomeCombinedBudgetAmount)
            Me.TabControlPanelCampaignDetailsTab_CampaignDetails.Controls.Add(Me.LabelCampaignDetails_IncomeProductionBudgetAmount)
            Me.TabControlPanelCampaignDetailsTab_CampaignDetails.Controls.Add(Me.LabelCampaignDetails_IncomeMediaBudgetAmount)
            Me.TabControlPanelCampaignDetailsTab_CampaignDetails.Controls.Add(Me.LabelCampaignDetails_IncomeTotalAllocated)
            Me.TabControlPanelCampaignDetailsTab_CampaignDetails.Controls.Add(Me.LabelCampaignDetails_IncomeCombinedBudget)
            Me.TabControlPanelCampaignDetailsTab_CampaignDetails.Controls.Add(Me.LabelCampaignDetails_IncomeProductionBudget)
            Me.TabControlPanelCampaignDetailsTab_CampaignDetails.Controls.Add(Me.LabelCampaignDetails_IncomeMediaBudget)
            Me.TabControlPanelCampaignDetailsTab_CampaignDetails.Controls.Add(Me.LabelCampaignDetails_BillingTotalAllocatedAmount)
            Me.TabControlPanelCampaignDetailsTab_CampaignDetails.Controls.Add(Me.LabelCampaignDetails_BillingCombinedBudgetAmount)
            Me.TabControlPanelCampaignDetailsTab_CampaignDetails.Controls.Add(Me.LabelCampaignDetails_BillingProductionBudgetAmount)
            Me.TabControlPanelCampaignDetailsTab_CampaignDetails.Controls.Add(Me.LabelCampaignDetails_BillingMediaBudgetAmount)
            Me.TabControlPanelCampaignDetailsTab_CampaignDetails.Controls.Add(Me.LabelCampaignDetails_BillingTotalAllocated)
            Me.TabControlPanelCampaignDetailsTab_CampaignDetails.Controls.Add(Me.LabelCampaignDetails_BillingCombinedBudget)
            Me.TabControlPanelCampaignDetailsTab_CampaignDetails.Controls.Add(Me.LabelCampaignDetails_BillingProductionBudget)
            Me.TabControlPanelCampaignDetailsTab_CampaignDetails.Controls.Add(Me.LabelCampaignDetails_IncomeAmountTotals)
            Me.TabControlPanelCampaignDetailsTab_CampaignDetails.Controls.Add(Me.LabelCampaignDetails_BillingAmountTotals)
            Me.TabControlPanelCampaignDetailsTab_CampaignDetails.Controls.Add(Me.LabelCampaignDetails_BillingMediaBudget)
            Me.TabControlPanelCampaignDetailsTab_CampaignDetails.Controls.Add(Me.DataGridViewCampaignDetails_CampaignDetails)
            Me.TabControlPanelCampaignDetailsTab_CampaignDetails.Controls.Add(Me.NumericInputCampaignDetails_TotalIncome)
            Me.TabControlPanelCampaignDetailsTab_CampaignDetails.Controls.Add(Me.NumericInputCampaignDetails_TotalBilling)
            Me.TabControlPanelCampaignDetailsTab_CampaignDetails.Controls.Add(Me.LabelCampaignDetails_TotalIncome)
            Me.TabControlPanelCampaignDetailsTab_CampaignDetails.Controls.Add(Me.LabelCampaignDetails_TotalBilling)
            Me.TabControlPanelCampaignDetailsTab_CampaignDetails.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelCampaignDetailsTab_CampaignDetails.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelCampaignDetailsTab_CampaignDetails.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelCampaignDetailsTab_CampaignDetails.Name = "TabControlPanelCampaignDetailsTab_CampaignDetails"
            Me.TabControlPanelCampaignDetailsTab_CampaignDetails.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelCampaignDetailsTab_CampaignDetails.Size = New System.Drawing.Size(706, 500)
            Me.TabControlPanelCampaignDetailsTab_CampaignDetails.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelCampaignDetailsTab_CampaignDetails.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelCampaignDetailsTab_CampaignDetails.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelCampaignDetailsTab_CampaignDetails.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelCampaignDetailsTab_CampaignDetails.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelCampaignDetailsTab_CampaignDetails.Style.GradientAngle = 90
            Me.TabControlPanelCampaignDetailsTab_CampaignDetails.TabIndex = 1
            Me.TabControlPanelCampaignDetailsTab_CampaignDetails.TabItem = Me.TabItemCampaignDetails_CampaignDetailsTab
            '
            'LabelCampaignDetails_IncomeTotalAllocatedAmount
            '
            Me.LabelCampaignDetails_IncomeTotalAllocatedAmount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCampaignDetails_IncomeTotalAllocatedAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCampaignDetails_IncomeTotalAllocatedAmount.Location = New System.Drawing.Point(356, 134)
            Me.LabelCampaignDetails_IncomeTotalAllocatedAmount.Name = "LabelCampaignDetails_IncomeTotalAllocatedAmount"
            Me.LabelCampaignDetails_IncomeTotalAllocatedAmount.Size = New System.Drawing.Size(142, 20)
            Me.LabelCampaignDetails_IncomeTotalAllocatedAmount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCampaignDetails_IncomeTotalAllocatedAmount.TabIndex = 28
            Me.LabelCampaignDetails_IncomeTotalAllocatedAmount.Text = "$0.00"
            '
            'LabelCampaignDetails_IncomeCombinedBudgetAmount
            '
            Me.LabelCampaignDetails_IncomeCombinedBudgetAmount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCampaignDetails_IncomeCombinedBudgetAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCampaignDetails_IncomeCombinedBudgetAmount.Location = New System.Drawing.Point(356, 108)
            Me.LabelCampaignDetails_IncomeCombinedBudgetAmount.Name = "LabelCampaignDetails_IncomeCombinedBudgetAmount"
            Me.LabelCampaignDetails_IncomeCombinedBudgetAmount.Size = New System.Drawing.Size(142, 20)
            Me.LabelCampaignDetails_IncomeCombinedBudgetAmount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCampaignDetails_IncomeCombinedBudgetAmount.TabIndex = 27
            Me.LabelCampaignDetails_IncomeCombinedBudgetAmount.Text = "$0.00"
            '
            'LabelCampaignDetails_IncomeProductionBudgetAmount
            '
            Me.LabelCampaignDetails_IncomeProductionBudgetAmount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCampaignDetails_IncomeProductionBudgetAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCampaignDetails_IncomeProductionBudgetAmount.Location = New System.Drawing.Point(356, 82)
            Me.LabelCampaignDetails_IncomeProductionBudgetAmount.Name = "LabelCampaignDetails_IncomeProductionBudgetAmount"
            Me.LabelCampaignDetails_IncomeProductionBudgetAmount.Size = New System.Drawing.Size(142, 20)
            Me.LabelCampaignDetails_IncomeProductionBudgetAmount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCampaignDetails_IncomeProductionBudgetAmount.TabIndex = 26
            Me.LabelCampaignDetails_IncomeProductionBudgetAmount.Text = "$0.00"
            '
            'LabelCampaignDetails_IncomeMediaBudgetAmount
            '
            Me.LabelCampaignDetails_IncomeMediaBudgetAmount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCampaignDetails_IncomeMediaBudgetAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCampaignDetails_IncomeMediaBudgetAmount.Location = New System.Drawing.Point(356, 56)
            Me.LabelCampaignDetails_IncomeMediaBudgetAmount.Name = "LabelCampaignDetails_IncomeMediaBudgetAmount"
            Me.LabelCampaignDetails_IncomeMediaBudgetAmount.Size = New System.Drawing.Size(142, 20)
            Me.LabelCampaignDetails_IncomeMediaBudgetAmount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCampaignDetails_IncomeMediaBudgetAmount.TabIndex = 25
            Me.LabelCampaignDetails_IncomeMediaBudgetAmount.Text = "$0.00"
            '
            'LabelCampaignDetails_IncomeTotalAllocated
            '
            Me.LabelCampaignDetails_IncomeTotalAllocated.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCampaignDetails_IncomeTotalAllocated.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCampaignDetails_IncomeTotalAllocated.Location = New System.Drawing.Point(254, 134)
            Me.LabelCampaignDetails_IncomeTotalAllocated.Name = "LabelCampaignDetails_IncomeTotalAllocated"
            Me.LabelCampaignDetails_IncomeTotalAllocated.Size = New System.Drawing.Size(96, 20)
            Me.LabelCampaignDetails_IncomeTotalAllocated.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCampaignDetails_IncomeTotalAllocated.TabIndex = 24
            Me.LabelCampaignDetails_IncomeTotalAllocated.Text = "Total Allocated:"
            '
            'LabelCampaignDetails_IncomeCombinedBudget
            '
            Me.LabelCampaignDetails_IncomeCombinedBudget.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCampaignDetails_IncomeCombinedBudget.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCampaignDetails_IncomeCombinedBudget.Location = New System.Drawing.Point(254, 108)
            Me.LabelCampaignDetails_IncomeCombinedBudget.Name = "LabelCampaignDetails_IncomeCombinedBudget"
            Me.LabelCampaignDetails_IncomeCombinedBudget.Size = New System.Drawing.Size(96, 20)
            Me.LabelCampaignDetails_IncomeCombinedBudget.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCampaignDetails_IncomeCombinedBudget.TabIndex = 23
            Me.LabelCampaignDetails_IncomeCombinedBudget.Text = "Combined Budget:"
            '
            'LabelCampaignDetails_IncomeProductionBudget
            '
            Me.LabelCampaignDetails_IncomeProductionBudget.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCampaignDetails_IncomeProductionBudget.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCampaignDetails_IncomeProductionBudget.Location = New System.Drawing.Point(254, 82)
            Me.LabelCampaignDetails_IncomeProductionBudget.Name = "LabelCampaignDetails_IncomeProductionBudget"
            Me.LabelCampaignDetails_IncomeProductionBudget.Size = New System.Drawing.Size(96, 20)
            Me.LabelCampaignDetails_IncomeProductionBudget.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCampaignDetails_IncomeProductionBudget.TabIndex = 22
            Me.LabelCampaignDetails_IncomeProductionBudget.Text = "Production Budget:"
            '
            'LabelCampaignDetails_IncomeMediaBudget
            '
            Me.LabelCampaignDetails_IncomeMediaBudget.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCampaignDetails_IncomeMediaBudget.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCampaignDetails_IncomeMediaBudget.Location = New System.Drawing.Point(254, 56)
            Me.LabelCampaignDetails_IncomeMediaBudget.Name = "LabelCampaignDetails_IncomeMediaBudget"
            Me.LabelCampaignDetails_IncomeMediaBudget.Size = New System.Drawing.Size(96, 20)
            Me.LabelCampaignDetails_IncomeMediaBudget.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCampaignDetails_IncomeMediaBudget.TabIndex = 21
            Me.LabelCampaignDetails_IncomeMediaBudget.Text = "Media Budget:"
            '
            'LabelCampaignDetails_BillingTotalAllocatedAmount
            '
            Me.LabelCampaignDetails_BillingTotalAllocatedAmount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCampaignDetails_BillingTotalAllocatedAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCampaignDetails_BillingTotalAllocatedAmount.Location = New System.Drawing.Point(106, 134)
            Me.LabelCampaignDetails_BillingTotalAllocatedAmount.Name = "LabelCampaignDetails_BillingTotalAllocatedAmount"
            Me.LabelCampaignDetails_BillingTotalAllocatedAmount.Size = New System.Drawing.Size(142, 20)
            Me.LabelCampaignDetails_BillingTotalAllocatedAmount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCampaignDetails_BillingTotalAllocatedAmount.TabIndex = 20
            Me.LabelCampaignDetails_BillingTotalAllocatedAmount.Text = "$0.00"
            '
            'LabelCampaignDetails_BillingCombinedBudgetAmount
            '
            Me.LabelCampaignDetails_BillingCombinedBudgetAmount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCampaignDetails_BillingCombinedBudgetAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCampaignDetails_BillingCombinedBudgetAmount.Location = New System.Drawing.Point(106, 108)
            Me.LabelCampaignDetails_BillingCombinedBudgetAmount.Name = "LabelCampaignDetails_BillingCombinedBudgetAmount"
            Me.LabelCampaignDetails_BillingCombinedBudgetAmount.Size = New System.Drawing.Size(142, 20)
            Me.LabelCampaignDetails_BillingCombinedBudgetAmount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCampaignDetails_BillingCombinedBudgetAmount.TabIndex = 19
            Me.LabelCampaignDetails_BillingCombinedBudgetAmount.Text = "$0.00"
            '
            'LabelCampaignDetails_BillingProductionBudgetAmount
            '
            Me.LabelCampaignDetails_BillingProductionBudgetAmount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCampaignDetails_BillingProductionBudgetAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCampaignDetails_BillingProductionBudgetAmount.Location = New System.Drawing.Point(106, 82)
            Me.LabelCampaignDetails_BillingProductionBudgetAmount.Name = "LabelCampaignDetails_BillingProductionBudgetAmount"
            Me.LabelCampaignDetails_BillingProductionBudgetAmount.Size = New System.Drawing.Size(142, 20)
            Me.LabelCampaignDetails_BillingProductionBudgetAmount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCampaignDetails_BillingProductionBudgetAmount.TabIndex = 18
            Me.LabelCampaignDetails_BillingProductionBudgetAmount.Text = "$0.00"
            '
            'LabelCampaignDetails_BillingMediaBudgetAmount
            '
            Me.LabelCampaignDetails_BillingMediaBudgetAmount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCampaignDetails_BillingMediaBudgetAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCampaignDetails_BillingMediaBudgetAmount.Location = New System.Drawing.Point(106, 56)
            Me.LabelCampaignDetails_BillingMediaBudgetAmount.Name = "LabelCampaignDetails_BillingMediaBudgetAmount"
            Me.LabelCampaignDetails_BillingMediaBudgetAmount.Size = New System.Drawing.Size(142, 20)
            Me.LabelCampaignDetails_BillingMediaBudgetAmount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCampaignDetails_BillingMediaBudgetAmount.TabIndex = 17
            Me.LabelCampaignDetails_BillingMediaBudgetAmount.Text = "$0.00"
            '
            'LabelCampaignDetails_BillingTotalAllocated
            '
            Me.LabelCampaignDetails_BillingTotalAllocated.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCampaignDetails_BillingTotalAllocated.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCampaignDetails_BillingTotalAllocated.Location = New System.Drawing.Point(4, 134)
            Me.LabelCampaignDetails_BillingTotalAllocated.Name = "LabelCampaignDetails_BillingTotalAllocated"
            Me.LabelCampaignDetails_BillingTotalAllocated.Size = New System.Drawing.Size(96, 20)
            Me.LabelCampaignDetails_BillingTotalAllocated.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCampaignDetails_BillingTotalAllocated.TabIndex = 16
            Me.LabelCampaignDetails_BillingTotalAllocated.Text = "Total Allocated:"
            '
            'LabelCampaignDetails_BillingCombinedBudget
            '
            Me.LabelCampaignDetails_BillingCombinedBudget.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCampaignDetails_BillingCombinedBudget.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCampaignDetails_BillingCombinedBudget.Location = New System.Drawing.Point(4, 108)
            Me.LabelCampaignDetails_BillingCombinedBudget.Name = "LabelCampaignDetails_BillingCombinedBudget"
            Me.LabelCampaignDetails_BillingCombinedBudget.Size = New System.Drawing.Size(96, 20)
            Me.LabelCampaignDetails_BillingCombinedBudget.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCampaignDetails_BillingCombinedBudget.TabIndex = 15
            Me.LabelCampaignDetails_BillingCombinedBudget.Text = "Combined Budget:"
            '
            'LabelCampaignDetails_BillingProductionBudget
            '
            Me.LabelCampaignDetails_BillingProductionBudget.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCampaignDetails_BillingProductionBudget.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCampaignDetails_BillingProductionBudget.Location = New System.Drawing.Point(4, 82)
            Me.LabelCampaignDetails_BillingProductionBudget.Name = "LabelCampaignDetails_BillingProductionBudget"
            Me.LabelCampaignDetails_BillingProductionBudget.Size = New System.Drawing.Size(96, 20)
            Me.LabelCampaignDetails_BillingProductionBudget.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCampaignDetails_BillingProductionBudget.TabIndex = 14
            Me.LabelCampaignDetails_BillingProductionBudget.Text = "Production Budget:"
            '
            'LabelCampaignDetails_IncomeAmountTotals
            '
            Me.LabelCampaignDetails_IncomeAmountTotals.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCampaignDetails_IncomeAmountTotals.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelCampaignDetails_IncomeAmountTotals.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelCampaignDetails_IncomeAmountTotals.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelCampaignDetails_IncomeAmountTotals.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelCampaignDetails_IncomeAmountTotals.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelCampaignDetails_IncomeAmountTotals.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelCampaignDetails_IncomeAmountTotals.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCampaignDetails_IncomeAmountTotals.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelCampaignDetails_IncomeAmountTotals.Location = New System.Drawing.Point(254, 30)
            Me.LabelCampaignDetails_IncomeAmountTotals.Name = "LabelCampaignDetails_IncomeAmountTotals"
            Me.LabelCampaignDetails_IncomeAmountTotals.Size = New System.Drawing.Size(244, 20)
            Me.LabelCampaignDetails_IncomeAmountTotals.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCampaignDetails_IncomeAmountTotals.TabIndex = 13
            Me.LabelCampaignDetails_IncomeAmountTotals.Text = "Income Amount Totals"
            '
            'LabelCampaignDetails_BillingAmountTotals
            '
            Me.LabelCampaignDetails_BillingAmountTotals.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCampaignDetails_BillingAmountTotals.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelCampaignDetails_BillingAmountTotals.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelCampaignDetails_BillingAmountTotals.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelCampaignDetails_BillingAmountTotals.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelCampaignDetails_BillingAmountTotals.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelCampaignDetails_BillingAmountTotals.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelCampaignDetails_BillingAmountTotals.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCampaignDetails_BillingAmountTotals.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelCampaignDetails_BillingAmountTotals.Location = New System.Drawing.Point(4, 30)
            Me.LabelCampaignDetails_BillingAmountTotals.Name = "LabelCampaignDetails_BillingAmountTotals"
            Me.LabelCampaignDetails_BillingAmountTotals.Size = New System.Drawing.Size(244, 20)
            Me.LabelCampaignDetails_BillingAmountTotals.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCampaignDetails_BillingAmountTotals.TabIndex = 12
            Me.LabelCampaignDetails_BillingAmountTotals.Text = "Billing Amount Totals"
            '
            'LabelCampaignDetails_BillingMediaBudget
            '
            Me.LabelCampaignDetails_BillingMediaBudget.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCampaignDetails_BillingMediaBudget.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCampaignDetails_BillingMediaBudget.Location = New System.Drawing.Point(4, 56)
            Me.LabelCampaignDetails_BillingMediaBudget.Name = "LabelCampaignDetails_BillingMediaBudget"
            Me.LabelCampaignDetails_BillingMediaBudget.Size = New System.Drawing.Size(96, 20)
            Me.LabelCampaignDetails_BillingMediaBudget.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCampaignDetails_BillingMediaBudget.TabIndex = 11
            Me.LabelCampaignDetails_BillingMediaBudget.Text = "Media Budget:"
            '
            'DataGridViewCampaignDetails_CampaignDetails
            '
            Me.DataGridViewCampaignDetails_CampaignDetails.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewCampaignDetails_CampaignDetails.AllowDragAndDrop = False
            Me.DataGridViewCampaignDetails_CampaignDetails.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewCampaignDetails_CampaignDetails.AllowSelectGroupHeaderRow = True
            Me.DataGridViewCampaignDetails_CampaignDetails.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewCampaignDetails_CampaignDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewCampaignDetails_CampaignDetails.AutoFilterLookupColumns = False
            Me.DataGridViewCampaignDetails_CampaignDetails.AutoloadRepositoryDatasource = True
            Me.DataGridViewCampaignDetails_CampaignDetails.AutoUpdateViewCaption = True
            Me.DataGridViewCampaignDetails_CampaignDetails.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewCampaignDetails_CampaignDetails.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewCampaignDetails_CampaignDetails.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewCampaignDetails_CampaignDetails.ItemDescription = ""
            Me.DataGridViewCampaignDetails_CampaignDetails.Location = New System.Drawing.Point(4, 160)
            Me.DataGridViewCampaignDetails_CampaignDetails.MultiSelect = True
            Me.DataGridViewCampaignDetails_CampaignDetails.Name = "DataGridViewCampaignDetails_CampaignDetails"
            Me.DataGridViewCampaignDetails_CampaignDetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewCampaignDetails_CampaignDetails.RunStandardValidation = True
            Me.DataGridViewCampaignDetails_CampaignDetails.ShowColumnMenuOnRightClick = False
            Me.DataGridViewCampaignDetails_CampaignDetails.ShowSelectDeselectAllButtons = False
            Me.DataGridViewCampaignDetails_CampaignDetails.Size = New System.Drawing.Size(698, 336)
            Me.DataGridViewCampaignDetails_CampaignDetails.TabIndex = 10
            Me.DataGridViewCampaignDetails_CampaignDetails.UseEmbeddedNavigator = False
            Me.DataGridViewCampaignDetails_CampaignDetails.ViewCaptionHeight = -1
            '
            'NumericInputCampaignDetails_TotalIncome
            '
            Me.NumericInputCampaignDetails_TotalIncome.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputCampaignDetails_TotalIncome.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.Currency
            Me.NumericInputCampaignDetails_TotalIncome.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputCampaignDetails_TotalIncome.EnterMoveNextControl = True
            Me.NumericInputCampaignDetails_TotalIncome.Location = New System.Drawing.Point(347, 4)
            Me.NumericInputCampaignDetails_TotalIncome.Name = "NumericInputCampaignDetails_TotalIncome"
            Me.NumericInputCampaignDetails_TotalIncome.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputCampaignDetails_TotalIncome.Properties.DisplayFormat.FormatString = "c2"
            Me.NumericInputCampaignDetails_TotalIncome.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputCampaignDetails_TotalIncome.Properties.EditFormat.FormatString = "c2"
            Me.NumericInputCampaignDetails_TotalIncome.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputCampaignDetails_TotalIncome.Properties.IsFloatValue = False
            Me.NumericInputCampaignDetails_TotalIncome.Properties.Mask.EditMask = "c2"
            Me.NumericInputCampaignDetails_TotalIncome.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputCampaignDetails_TotalIncome.SecurityEnabled = True
            Me.NumericInputCampaignDetails_TotalIncome.Size = New System.Drawing.Size(151, 20)
            Me.NumericInputCampaignDetails_TotalIncome.TabIndex = 9
            '
            'NumericInputCampaignDetails_TotalBilling
            '
            Me.NumericInputCampaignDetails_TotalBilling.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputCampaignDetails_TotalBilling.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.Currency
            Me.NumericInputCampaignDetails_TotalBilling.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputCampaignDetails_TotalBilling.EnterMoveNextControl = True
            Me.NumericInputCampaignDetails_TotalBilling.Location = New System.Drawing.Point(97, 4)
            Me.NumericInputCampaignDetails_TotalBilling.Name = "NumericInputCampaignDetails_TotalBilling"
            Me.NumericInputCampaignDetails_TotalBilling.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputCampaignDetails_TotalBilling.Properties.DisplayFormat.FormatString = "c2"
            Me.NumericInputCampaignDetails_TotalBilling.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputCampaignDetails_TotalBilling.Properties.EditFormat.FormatString = "c2"
            Me.NumericInputCampaignDetails_TotalBilling.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputCampaignDetails_TotalBilling.Properties.IsFloatValue = False
            Me.NumericInputCampaignDetails_TotalBilling.Properties.Mask.EditMask = "c2"
            Me.NumericInputCampaignDetails_TotalBilling.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputCampaignDetails_TotalBilling.SecurityEnabled = True
            Me.NumericInputCampaignDetails_TotalBilling.Size = New System.Drawing.Size(151, 20)
            Me.NumericInputCampaignDetails_TotalBilling.TabIndex = 7
            '
            'LabelCampaignDetails_TotalIncome
            '
            Me.LabelCampaignDetails_TotalIncome.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCampaignDetails_TotalIncome.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCampaignDetails_TotalIncome.Location = New System.Drawing.Point(254, 4)
            Me.LabelCampaignDetails_TotalIncome.Name = "LabelCampaignDetails_TotalIncome"
            Me.LabelCampaignDetails_TotalIncome.Size = New System.Drawing.Size(87, 20)
            Me.LabelCampaignDetails_TotalIncome.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCampaignDetails_TotalIncome.TabIndex = 8
            Me.LabelCampaignDetails_TotalIncome.Text = "Total Income:"
            '
            'LabelCampaignDetails_TotalBilling
            '
            Me.LabelCampaignDetails_TotalBilling.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCampaignDetails_TotalBilling.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCampaignDetails_TotalBilling.Location = New System.Drawing.Point(4, 4)
            Me.LabelCampaignDetails_TotalBilling.Name = "LabelCampaignDetails_TotalBilling"
            Me.LabelCampaignDetails_TotalBilling.Size = New System.Drawing.Size(87, 20)
            Me.LabelCampaignDetails_TotalBilling.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCampaignDetails_TotalBilling.TabIndex = 6
            Me.LabelCampaignDetails_TotalBilling.Text = "Total Billing:"
            '
            'TabItemCampaignDetails_CampaignDetailsTab
            '
            Me.TabItemCampaignDetails_CampaignDetailsTab.AttachedControl = Me.TabControlPanelCampaignDetailsTab_CampaignDetails
            Me.TabItemCampaignDetails_CampaignDetailsTab.Name = "TabItemCampaignDetails_CampaignDetailsTab"
            Me.TabItemCampaignDetails_CampaignDetailsTab.Text = "Campaign Details"
            '
            'LabelGeneral_WebsiteName
            '
            Me.LabelGeneral_WebsiteName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_WebsiteName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_WebsiteName.Location = New System.Drawing.Point(6, 368)
            Me.LabelGeneral_WebsiteName.Name = "LabelGeneral_WebsiteName"
            Me.LabelGeneral_WebsiteName.Size = New System.Drawing.Size(87, 20)
            Me.LabelGeneral_WebsiteName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_WebsiteName.TabIndex = 30
            Me.LabelGeneral_WebsiteName.Text = "Website Name:"
            '
            'TextBoxGeneral_WebsiteName
            '
            Me.TextBoxGeneral_WebsiteName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxGeneral_WebsiteName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxGeneral_WebsiteName.Border.Class = "TextBoxBorder"
            Me.TextBoxGeneral_WebsiteName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxGeneral_WebsiteName.CheckSpellingOnValidate = False
            Me.TextBoxGeneral_WebsiteName.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxGeneral_WebsiteName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxGeneral_WebsiteName.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxGeneral_WebsiteName.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxGeneral_WebsiteName.FocusHighlightEnabled = True
            Me.TextBoxGeneral_WebsiteName.ForeColor = System.Drawing.Color.Black
            Me.TextBoxGeneral_WebsiteName.Location = New System.Drawing.Point(99, 368)
            Me.TextBoxGeneral_WebsiteName.MaxFileSize = CType(0, Long)
            Me.TextBoxGeneral_WebsiteName.Name = "TextBoxGeneral_WebsiteName"
            Me.TextBoxGeneral_WebsiteName.ReadOnly = True
            Me.TextBoxGeneral_WebsiteName.SecurityEnabled = True
            Me.TextBoxGeneral_WebsiteName.ShowSpellCheckCompleteMessage = True
            Me.TextBoxGeneral_WebsiteName.Size = New System.Drawing.Size(603, 20)
            Me.TextBoxGeneral_WebsiteName.StartingFolderName = Nothing
            Me.TextBoxGeneral_WebsiteName.TabIndex = 31
            Me.TextBoxGeneral_WebsiteName.TabOnEnter = True
            '
            'CampaignControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.CheckBoxGeneral_Closed)
            Me.Controls.Add(Me.TabControlControl_CampaignDetails)
            Me.Name = "CampaignControl"
            Me.Size = New System.Drawing.Size(706, 527)
            CType(Me.TabControlControl_CampaignDetails, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlControl_CampaignDetails.ResumeLayout(False)
            Me.TabControlPanelGeneralTab_General.ResumeLayout(False)
            CType(Me.SearchableComboBoxGeneral_LandingPage.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewGeneral_LandingPage, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerGeneral_BeginningDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerGeneral_EndingDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxGeneral_Comments, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxGeneral_Comments.ResumeLayout(False)
            CType(Me.GroupBoxGeneral_MediaTypes, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxGeneral_MediaTypes.ResumeLayout(False)
            Me.TabControlPanelDocumentsTab_Documents.ResumeLayout(False)
            Me.TabControlPanelJobsAndMediaOrdersTab_JobsAndMediaOrders.ResumeLayout(False)
            CType(Me.PanelJobsAndMediaOrders_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelJobsAndMediaOrders_RightSection.ResumeLayout(False)
            CType(Me.PanelJobsAndMediaOrders_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelJobsAndMediaOrders_LeftSection.ResumeLayout(False)
            Me.TabControlPanelCampaignDetailsTab_CampaignDetails.ResumeLayout(False)
            CType(Me.NumericInputCampaignDetails_TotalIncome.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputCampaignDetails_TotalBilling.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents CheckBoxGeneral_Closed As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents TabControlControl_CampaignDetails As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelDocumentsTab_Documents As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DocumentManagerControlDocuments_CampaignDocuments As AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl
        Friend WithEvents TabItemCampaignDetails_DocumentsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelJobsAndMediaOrdersTab_JobsAndMediaOrders As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents PanelJobsAndMediaOrders_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ButtonRightSection_AddJobsAndMediaOrders As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonRightSection_RemoveJobsAndMediaOrders As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewRightSection_JobsAndMediaOrders As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ExpandableSplitterJobsAndMediaOrders_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelJobsAndMediaOrders_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewLeftSection_AvailableJobsAndMediaOrders As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TabItemCampaignDetails_JobsAndMediaOrdersTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelCampaignDetailsTab_CampaignDetails As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents LabelCampaignDetails_IncomeTotalAllocatedAmount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCampaignDetails_IncomeCombinedBudgetAmount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCampaignDetails_IncomeProductionBudgetAmount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCampaignDetails_IncomeMediaBudgetAmount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCampaignDetails_IncomeTotalAllocated As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCampaignDetails_IncomeCombinedBudget As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCampaignDetails_IncomeProductionBudget As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCampaignDetails_IncomeMediaBudget As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCampaignDetails_BillingTotalAllocatedAmount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCampaignDetails_BillingCombinedBudgetAmount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCampaignDetails_BillingProductionBudgetAmount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCampaignDetails_BillingMediaBudgetAmount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCampaignDetails_BillingTotalAllocated As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCampaignDetails_BillingCombinedBudget As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCampaignDetails_BillingProductionBudget As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCampaignDetails_IncomeAmountTotals As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCampaignDetails_BillingAmountTotals As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCampaignDetails_BillingMediaBudget As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DataGridViewCampaignDetails_CampaignDetails As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents NumericInputCampaignDetails_TotalIncome As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputCampaignDetails_TotalBilling As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents LabelCampaignDetails_TotalIncome As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCampaignDetails_TotalBilling As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TabItemCampaignDetails_CampaignDetailsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelGeneralTab_General As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents ComboBoxGeneral_JobComponent As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelGeneral_JobComponent As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxGeneral_Market As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelGeneral_Market As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxGeneral_AdNumber As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelGeneral_AdNumber As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerGeneral_BeginningDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerGeneral_EndingDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents LabelGeneral_BeginningDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxGeneral_Product As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxGeneral_Division As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelGeneral_EndingDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxGeneral_Client As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents GroupBoxGeneral_Comments As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents TextBoxComments_Comments As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents GroupBoxGeneral_MediaTypes As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents TextBoxMediaTypes_Other As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents CheckBoxMediaTypes_Other As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxMediaTypes_DirectResponse As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxMediaTypes_PrintCollateral As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxMediaTypes_Television As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxMediaTypes_Radio As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxMediaTypes_OutOfHome As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxMediaTypes_Internet As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxMediaTypes_Newspaper As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxMediaTypes_Magazine As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelGeneral_Name As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxGeneral_Name As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents RadioButtonGeneral_Overall As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonGeneral_AssignedToJobsAndOrders As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents ComboBoxGeneral_AlertGroup As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelGeneral_AlertGroup As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGeneral_Code As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxGeneral_Code As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents ComboBoxGeneral_Office As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelGeneral_Product As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGeneral_Division As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGeneral_Client As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGeneral_CampaignType As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGeneral_Office As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TabItemCampaignDetails_GeneralTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents LabelGeneral_ID As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGeneral_IDLabel As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGeneral_LandingPage As Label
        Friend WithEvents SearchableComboBoxGeneral_LandingPage As SearchableComboBox
        Friend WithEvents SearchableComboBoxViewGeneral_LandingPage As GridView
        Friend WithEvents TextBoxGeneral_WebsiteName As TextBox
        Friend WithEvents LabelGeneral_WebsiteName As Label
    End Class

End Namespace
