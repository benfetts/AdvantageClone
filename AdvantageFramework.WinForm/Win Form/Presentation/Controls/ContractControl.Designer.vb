Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ContractControl
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ContractControl))
            Me.TabControlControl_ContractSetup = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelReportsDocumentsTab_ReportsDocuments = New DevComponents.DotNetBar.TabControlPanel()
            Me.DocumentManagerControlReportsDocuments_ReportsDocuments = New AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl()
            Me.TabItemContractSetup_ReportsDocumentsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelDocumentsTab_Documents = New DevComponents.DotNetBar.TabControlPanel()
            Me.DocumentManagerControlDocuments_ContractDocuments = New AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl()
            Me.TabItemContractSetup_DocumentsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelValueAdded_ValueAdded = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewValueAdded_ValueAdded = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemContractSetup_ValueAddedTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelReportsTab_Reports = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewReports_Reports = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemContractSetup_ReportsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelGeneral_General = New DevComponents.DotNetBar.TabControlPanel()
            Me.SearchableComboBoxGeneral_Product = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewGeneral_Product = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelGeneral_Product = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxGeneral_Division = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewGeneral_Division = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxGeneral_Client = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewGeneral_Client = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.DateTimePickerGeneral_EndDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerGeneral_StartDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelGeneralEndDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxGeneral_COType = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.RadioButtonCOType_Opportunity = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonCOType_Contract = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.LabelGeneralStartDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.AddressControlGeneral_Address = New AdvantageFramework.WinForm.Presentation.Controls.AddressControl()
            Me.CheckBoxGeneral_NewBusiness = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelGeneral_Code = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneral_Client = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneral_Division = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxGeneral_Inactive = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TextBoxGeneral_Code = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxGeneral_Description = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelGeneral_Name = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemContractSetup_GeneralTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelComments_Comments = New DevComponents.DotNetBar.TabControlPanel()
            Me.LabelComments_EstimatingTerms = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxComments_EstimatingTerms = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxComments_BillingTerms = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelComments_BillingTerms = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxComments_BillingRateComment = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelComments_BillingRateComment = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemContractSetup_CommentsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelContactsTab_Contacts = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewInternalContacts_Contacts = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemContractSetup_InternalContactsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelRatesTerms_RatesTerms = New DevComponents.DotNetBar.TabControlPanel()
            Me.ButtonRateTerm_UpdateFeeRetainer = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.NumericInputRateTerms_Hours = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelRateTerm_Hours = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.NumericInputRateTerms_TotalContractValue = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputRateTerms_ProductionCommission = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputRateTerms_MediaCommission = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputRateTerms_FeeProjectHourly = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputRateTerms_FeeRoyalty = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputRateTerms_FeeIncentiveBonus = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputRateTerms_FeeRetainer = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelRateTerm_TotalContractValue = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelRateTerm_ProductCommission = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelRateTerm_MediaCommission = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelRateTerm_ProjectHourlyTotal = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelRateTerm_FeeRoyalty = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelRateTerm_FeeIncentiveBonus = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelRateTerm_FeeRetainer = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DataGridViewRateTerm_ContractFees = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.GroupBoxRateTerm_ContractType = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.NumericInputContractType_BlendedHourlyBillingRate = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelContractType_BlendedHourlyBillingRate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxContractType_Fee = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxContractType_ProjectHourly = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TabItemContractSetup_RatesTermsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.LabelComments_Comments = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxComments_Comments = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            CType(Me.TabControlControl_ContractSetup, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlControl_ContractSetup.SuspendLayout()
            Me.TabControlPanelReportsDocumentsTab_ReportsDocuments.SuspendLayout()
            Me.TabControlPanelDocumentsTab_Documents.SuspendLayout()
            Me.TabControlPanelValueAdded_ValueAdded.SuspendLayout()
            Me.TabControlPanelReportsTab_Reports.SuspendLayout()
            Me.TabControlPanelGeneral_General.SuspendLayout()
            CType(Me.SearchableComboBoxGeneral_Product.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewGeneral_Product, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxGeneral_Division.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewGeneral_Division, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxGeneral_Client.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewGeneral_Client, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerGeneral_EndDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerGeneral_StartDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxGeneral_COType, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxGeneral_COType.SuspendLayout()
            Me.TabControlPanelComments_Comments.SuspendLayout()
            Me.TabControlPanelContactsTab_Contacts.SuspendLayout()
            Me.TabControlPanelRatesTerms_RatesTerms.SuspendLayout()
            CType(Me.NumericInputRateTerms_Hours.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputRateTerms_TotalContractValue.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputRateTerms_ProductionCommission.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputRateTerms_MediaCommission.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputRateTerms_FeeProjectHourly.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputRateTerms_FeeRoyalty.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputRateTerms_FeeIncentiveBonus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputRateTerms_FeeRetainer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxRateTerm_ContractType, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxRateTerm_ContractType.SuspendLayout()
            CType(Me.NumericInputContractType_BlendedHourlyBillingRate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'TabControlControl_ContractSetup
            '
            Me.TabControlControl_ContractSetup.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.TabControlControl_ContractSetup.CanReorderTabs = False
            Me.TabControlControl_ContractSetup.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlControl_ContractSetup.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlControl_ContractSetup.Controls.Add(Me.TabControlPanelComments_Comments)
            Me.TabControlControl_ContractSetup.Controls.Add(Me.TabControlPanelGeneral_General)
            Me.TabControlControl_ContractSetup.Controls.Add(Me.TabControlPanelReportsDocumentsTab_ReportsDocuments)
            Me.TabControlControl_ContractSetup.Controls.Add(Me.TabControlPanelDocumentsTab_Documents)
            Me.TabControlControl_ContractSetup.Controls.Add(Me.TabControlPanelValueAdded_ValueAdded)
            Me.TabControlControl_ContractSetup.Controls.Add(Me.TabControlPanelReportsTab_Reports)
            Me.TabControlControl_ContractSetup.Controls.Add(Me.TabControlPanelContactsTab_Contacts)
            Me.TabControlControl_ContractSetup.Controls.Add(Me.TabControlPanelRatesTerms_RatesTerms)
            Me.TabControlControl_ContractSetup.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlControl_ContractSetup.Location = New System.Drawing.Point(0, 0)
            Me.TabControlControl_ContractSetup.Name = "TabControlControl_ContractSetup"
            Me.TabControlControl_ContractSetup.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlControl_ContractSetup.SelectedTabIndex = 0
            Me.TabControlControl_ContractSetup.Size = New System.Drawing.Size(602, 623)
            Me.TabControlControl_ContractSetup.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlControl_ContractSetup.TabIndex = 0
            Me.TabControlControl_ContractSetup.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlControl_ContractSetup.Tabs.Add(Me.TabItemContractSetup_GeneralTab)
            Me.TabControlControl_ContractSetup.Tabs.Add(Me.TabItemContractSetup_RatesTermsTab)
            Me.TabControlControl_ContractSetup.Tabs.Add(Me.TabItemContractSetup_CommentsTab)
            Me.TabControlControl_ContractSetup.Tabs.Add(Me.TabItemContractSetup_InternalContactsTab)
            Me.TabControlControl_ContractSetup.Tabs.Add(Me.TabItemContractSetup_ReportsTab)
            Me.TabControlControl_ContractSetup.Tabs.Add(Me.TabItemContractSetup_ReportsDocumentsTab)
            Me.TabControlControl_ContractSetup.Tabs.Add(Me.TabItemContractSetup_ValueAddedTab)
            Me.TabControlControl_ContractSetup.Tabs.Add(Me.TabItemContractSetup_DocumentsTab)
            Me.TabControlControl_ContractSetup.Text = "TabControl1"
            '
            'TabControlPanelReportsDocumentsTab_ReportsDocuments
            '
            Me.TabControlPanelReportsDocumentsTab_ReportsDocuments.Controls.Add(Me.DocumentManagerControlReportsDocuments_ReportsDocuments)
            Me.TabControlPanelReportsDocumentsTab_ReportsDocuments.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelReportsDocumentsTab_ReportsDocuments.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelReportsDocumentsTab_ReportsDocuments.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelReportsDocumentsTab_ReportsDocuments.Name = "TabControlPanelReportsDocumentsTab_ReportsDocuments"
            Me.TabControlPanelReportsDocumentsTab_ReportsDocuments.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelReportsDocumentsTab_ReportsDocuments.Size = New System.Drawing.Size(602, 596)
            Me.TabControlPanelReportsDocumentsTab_ReportsDocuments.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelReportsDocumentsTab_ReportsDocuments.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelReportsDocumentsTab_ReportsDocuments.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelReportsDocumentsTab_ReportsDocuments.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelReportsDocumentsTab_ReportsDocuments.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelReportsDocumentsTab_ReportsDocuments.Style.GradientAngle = 90
            Me.TabControlPanelReportsDocumentsTab_ReportsDocuments.TabIndex = 15
            Me.TabControlPanelReportsDocumentsTab_ReportsDocuments.TabItem = Me.TabItemContractSetup_ReportsDocumentsTab
            '
            'DocumentManagerControlReportsDocuments_ReportsDocuments
            '
            Me.DocumentManagerControlReportsDocuments_ReportsDocuments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DocumentManagerControlReportsDocuments_ReportsDocuments.Location = New System.Drawing.Point(6, 6)
            Me.DocumentManagerControlReportsDocuments_ReportsDocuments.Margin = New System.Windows.Forms.Padding(4)
            Me.DocumentManagerControlReportsDocuments_ReportsDocuments.Name = "DocumentManagerControlReportsDocuments_ReportsDocuments"
            Me.DocumentManagerControlReportsDocuments_ReportsDocuments.Size = New System.Drawing.Size(590, 586)
            Me.DocumentManagerControlReportsDocuments_ReportsDocuments.TabIndex = 1
            '
            'TabItemContractSetup_ReportsDocumentsTab
            '
            Me.TabItemContractSetup_ReportsDocumentsTab.AttachedControl = Me.TabControlPanelReportsDocumentsTab_ReportsDocuments
            Me.TabItemContractSetup_ReportsDocumentsTab.Name = "TabItemContractSetup_ReportsDocumentsTab"
            Me.TabItemContractSetup_ReportsDocumentsTab.Text = "Reports Documents"
            '
            'TabControlPanelDocumentsTab_Documents
            '
            Me.TabControlPanelDocumentsTab_Documents.Controls.Add(Me.DocumentManagerControlDocuments_ContractDocuments)
            Me.TabControlPanelDocumentsTab_Documents.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelDocumentsTab_Documents.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelDocumentsTab_Documents.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelDocumentsTab_Documents.Name = "TabControlPanelDocumentsTab_Documents"
            Me.TabControlPanelDocumentsTab_Documents.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelDocumentsTab_Documents.Size = New System.Drawing.Size(602, 596)
            Me.TabControlPanelDocumentsTab_Documents.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelDocumentsTab_Documents.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDocumentsTab_Documents.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelDocumentsTab_Documents.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelDocumentsTab_Documents.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelDocumentsTab_Documents.Style.GradientAngle = 90
            Me.TabControlPanelDocumentsTab_Documents.TabIndex = 7
            Me.TabControlPanelDocumentsTab_Documents.TabItem = Me.TabItemContractSetup_DocumentsTab
            '
            'DocumentManagerControlDocuments_ContractDocuments
            '
            Me.DocumentManagerControlDocuments_ContractDocuments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DocumentManagerControlDocuments_ContractDocuments.Location = New System.Drawing.Point(6, 6)
            Me.DocumentManagerControlDocuments_ContractDocuments.Margin = New System.Windows.Forms.Padding(4)
            Me.DocumentManagerControlDocuments_ContractDocuments.Name = "DocumentManagerControlDocuments_ContractDocuments"
            Me.DocumentManagerControlDocuments_ContractDocuments.Size = New System.Drawing.Size(590, 586)
            Me.DocumentManagerControlDocuments_ContractDocuments.TabIndex = 0
            '
            'TabItemContractSetup_DocumentsTab
            '
            Me.TabItemContractSetup_DocumentsTab.AttachedControl = Me.TabControlPanelDocumentsTab_Documents
            Me.TabItemContractSetup_DocumentsTab.Name = "TabItemContractSetup_DocumentsTab"
            Me.TabItemContractSetup_DocumentsTab.Text = "Documents"
            '
            'TabControlPanelValueAdded_ValueAdded
            '
            Me.TabControlPanelValueAdded_ValueAdded.Controls.Add(Me.DataGridViewValueAdded_ValueAdded)
            Me.TabControlPanelValueAdded_ValueAdded.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelValueAdded_ValueAdded.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelValueAdded_ValueAdded.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelValueAdded_ValueAdded.Name = "TabControlPanelValueAdded_ValueAdded"
            Me.TabControlPanelValueAdded_ValueAdded.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelValueAdded_ValueAdded.Size = New System.Drawing.Size(602, 596)
            Me.TabControlPanelValueAdded_ValueAdded.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelValueAdded_ValueAdded.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelValueAdded_ValueAdded.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelValueAdded_ValueAdded.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelValueAdded_ValueAdded.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelValueAdded_ValueAdded.Style.GradientAngle = 90
            Me.TabControlPanelValueAdded_ValueAdded.TabIndex = 13
            Me.TabControlPanelValueAdded_ValueAdded.TabItem = Me.TabItemContractSetup_ValueAddedTab
            '
            'DataGridViewValueAdded_ValueAdded
            '
            Me.DataGridViewValueAdded_ValueAdded.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewValueAdded_ValueAdded.AllowDragAndDrop = False
            Me.DataGridViewValueAdded_ValueAdded.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewValueAdded_ValueAdded.AllowSelectGroupHeaderRow = True
            Me.DataGridViewValueAdded_ValueAdded.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewValueAdded_ValueAdded.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewValueAdded_ValueAdded.AutoFilterLookupColumns = False
            Me.DataGridViewValueAdded_ValueAdded.AutoloadRepositoryDatasource = True
            Me.DataGridViewValueAdded_ValueAdded.AutoUpdateViewCaption = True
            Me.DataGridViewValueAdded_ValueAdded.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewValueAdded_ValueAdded.DataSource = Nothing
            Me.DataGridViewValueAdded_ValueAdded.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewValueAdded_ValueAdded.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewValueAdded_ValueAdded.ItemDescription = "Value(s) Added"
            Me.DataGridViewValueAdded_ValueAdded.Location = New System.Drawing.Point(6, 6)
            Me.DataGridViewValueAdded_ValueAdded.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewValueAdded_ValueAdded.MultiSelect = False
            Me.DataGridViewValueAdded_ValueAdded.Name = "DataGridViewValueAdded_ValueAdded"
            Me.DataGridViewValueAdded_ValueAdded.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewValueAdded_ValueAdded.RunStandardValidation = True
            Me.DataGridViewValueAdded_ValueAdded.ShowColumnMenuOnRightClick = False
            Me.DataGridViewValueAdded_ValueAdded.ShowSelectDeselectAllButtons = False
            Me.DataGridViewValueAdded_ValueAdded.Size = New System.Drawing.Size(590, 586)
            Me.DataGridViewValueAdded_ValueAdded.TabIndex = 18
            Me.DataGridViewValueAdded_ValueAdded.UseEmbeddedNavigator = False
            Me.DataGridViewValueAdded_ValueAdded.ViewCaptionHeight = -1
            '
            'TabItemContractSetup_ValueAddedTab
            '
            Me.TabItemContractSetup_ValueAddedTab.AttachedControl = Me.TabControlPanelValueAdded_ValueAdded
            Me.TabItemContractSetup_ValueAddedTab.Name = "TabItemContractSetup_ValueAddedTab"
            Me.TabItemContractSetup_ValueAddedTab.Text = "Value Added"
            '
            'TabControlPanelReportsTab_Reports
            '
            Me.TabControlPanelReportsTab_Reports.Controls.Add(Me.DataGridViewReports_Reports)
            Me.TabControlPanelReportsTab_Reports.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelReportsTab_Reports.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelReportsTab_Reports.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelReportsTab_Reports.Name = "TabControlPanelReportsTab_Reports"
            Me.TabControlPanelReportsTab_Reports.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelReportsTab_Reports.Size = New System.Drawing.Size(602, 596)
            Me.TabControlPanelReportsTab_Reports.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelReportsTab_Reports.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelReportsTab_Reports.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelReportsTab_Reports.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelReportsTab_Reports.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelReportsTab_Reports.Style.GradientAngle = 90
            Me.TabControlPanelReportsTab_Reports.TabIndex = 14
            Me.TabControlPanelReportsTab_Reports.TabItem = Me.TabItemContractSetup_ReportsTab
            '
            'DataGridViewReports_Reports
            '
            Me.DataGridViewReports_Reports.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewReports_Reports.AllowDragAndDrop = False
            Me.DataGridViewReports_Reports.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewReports_Reports.AllowSelectGroupHeaderRow = True
            Me.DataGridViewReports_Reports.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewReports_Reports.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewReports_Reports.AutoFilterLookupColumns = False
            Me.DataGridViewReports_Reports.AutoloadRepositoryDatasource = True
            Me.DataGridViewReports_Reports.AutoUpdateViewCaption = True
            Me.DataGridViewReports_Reports.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewReports_Reports.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewReports_Reports.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewReports_Reports.ItemDescription = "Report(s)"
            Me.DataGridViewReports_Reports.Location = New System.Drawing.Point(6, 6)
            Me.DataGridViewReports_Reports.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewReports_Reports.MultiSelect = False
            Me.DataGridViewReports_Reports.Name = "DataGridViewReports_Reports"
            Me.DataGridViewReports_Reports.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewReports_Reports.RunStandardValidation = True
            Me.DataGridViewReports_Reports.ShowColumnMenuOnRightClick = False
            Me.DataGridViewReports_Reports.ShowSelectDeselectAllButtons = False
            Me.DataGridViewReports_Reports.Size = New System.Drawing.Size(590, 586)
            Me.DataGridViewReports_Reports.TabIndex = 18
            Me.DataGridViewReports_Reports.UseEmbeddedNavigator = False
            Me.DataGridViewReports_Reports.ViewCaptionHeight = -1
            '
            'TabItemContractSetup_ReportsTab
            '
            Me.TabItemContractSetup_ReportsTab.AttachedControl = Me.TabControlPanelReportsTab_Reports
            Me.TabItemContractSetup_ReportsTab.Name = "TabItemContractSetup_ReportsTab"
            Me.TabItemContractSetup_ReportsTab.Text = "Reports"
            '
            'TabControlPanelGeneral_General
            '
            Me.TabControlPanelGeneral_General.Controls.Add(Me.SearchableComboBoxGeneral_Product)
            Me.TabControlPanelGeneral_General.Controls.Add(Me.LabelGeneral_Product)
            Me.TabControlPanelGeneral_General.Controls.Add(Me.SearchableComboBoxGeneral_Division)
            Me.TabControlPanelGeneral_General.Controls.Add(Me.SearchableComboBoxGeneral_Client)
            Me.TabControlPanelGeneral_General.Controls.Add(Me.DateTimePickerGeneral_EndDate)
            Me.TabControlPanelGeneral_General.Controls.Add(Me.DateTimePickerGeneral_StartDate)
            Me.TabControlPanelGeneral_General.Controls.Add(Me.LabelGeneralEndDate)
            Me.TabControlPanelGeneral_General.Controls.Add(Me.GroupBoxGeneral_COType)
            Me.TabControlPanelGeneral_General.Controls.Add(Me.LabelGeneralStartDate)
            Me.TabControlPanelGeneral_General.Controls.Add(Me.AddressControlGeneral_Address)
            Me.TabControlPanelGeneral_General.Controls.Add(Me.CheckBoxGeneral_NewBusiness)
            Me.TabControlPanelGeneral_General.Controls.Add(Me.LabelGeneral_Code)
            Me.TabControlPanelGeneral_General.Controls.Add(Me.LabelGeneral_Client)
            Me.TabControlPanelGeneral_General.Controls.Add(Me.LabelGeneral_Division)
            Me.TabControlPanelGeneral_General.Controls.Add(Me.CheckBoxGeneral_Inactive)
            Me.TabControlPanelGeneral_General.Controls.Add(Me.TextBoxGeneral_Code)
            Me.TabControlPanelGeneral_General.Controls.Add(Me.TextBoxGeneral_Description)
            Me.TabControlPanelGeneral_General.Controls.Add(Me.LabelGeneral_Name)
            Me.TabControlPanelGeneral_General.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelGeneral_General.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelGeneral_General.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelGeneral_General.Name = "TabControlPanelGeneral_General"
            Me.TabControlPanelGeneral_General.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelGeneral_General.Size = New System.Drawing.Size(602, 443)
            Me.TabControlPanelGeneral_General.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelGeneral_General.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelGeneral_General.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelGeneral_General.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelGeneral_General.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelGeneral_General.Style.GradientAngle = 90
            Me.TabControlPanelGeneral_General.TabIndex = 0
            Me.TabControlPanelGeneral_General.TabItem = Me.TabItemContractSetup_GeneralTab
            '
            'SearchableComboBoxGeneral_Product
            '
            Me.SearchableComboBoxGeneral_Product.ActiveFilterString = ""
            Me.SearchableComboBoxGeneral_Product.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxGeneral_Product.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxGeneral_Product.AutoFillMode = False
            Me.SearchableComboBoxGeneral_Product.BookmarkingEnabled = False
            Me.SearchableComboBoxGeneral_Product.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Product
            Me.SearchableComboBoxGeneral_Product.DataSource = Nothing
            Me.SearchableComboBoxGeneral_Product.DisableMouseWheel = True
            Me.SearchableComboBoxGeneral_Product.DisplayName = ""
            Me.SearchableComboBoxGeneral_Product.EditValue = ""
            Me.SearchableComboBoxGeneral_Product.EnterMoveNextControl = True
            Me.SearchableComboBoxGeneral_Product.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxGeneral_Product.Location = New System.Drawing.Point(61, 110)
            Me.SearchableComboBoxGeneral_Product.Name = "SearchableComboBoxGeneral_Product"
            Me.SearchableComboBoxGeneral_Product.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxGeneral_Product.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxGeneral_Product.Properties.NullText = "Select Product"
            Me.SearchableComboBoxGeneral_Product.Properties.ShowClearButton = False
            Me.SearchableComboBoxGeneral_Product.Properties.ValueMember = "Code"
            Me.SearchableComboBoxGeneral_Product.Properties.View = Me.SearchableComboBoxViewGeneral_Product
            Me.SearchableComboBoxGeneral_Product.SecurityEnabled = True
            Me.SearchableComboBoxGeneral_Product.SelectedValue = ""
            Me.SearchableComboBoxGeneral_Product.Size = New System.Drawing.Size(535, 20)
            Me.SearchableComboBoxGeneral_Product.TabIndex = 11
            '
            'SearchableComboBoxViewGeneral_Product
            '
            Me.SearchableComboBoxViewGeneral_Product.AFActiveFilterString = ""
            Me.SearchableComboBoxViewGeneral_Product.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewGeneral_Product.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Product.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Product.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Product.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Product.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Product.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Product.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Product.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Product.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Product.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Product.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Product.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Product.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Product.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Product.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Product.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Product.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Product.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Product.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Product.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Product.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Product.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Product.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Product.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Product.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Product.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Product.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Product.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Product.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Product.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Product.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Product.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Product.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Product.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Product.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Product.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Product.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Product.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewGeneral_Product.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewGeneral_Product.DataSourceClearing = False
            Me.SearchableComboBoxViewGeneral_Product.EnableDisabledRows = False
            Me.SearchableComboBoxViewGeneral_Product.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewGeneral_Product.Name = "SearchableComboBoxViewGeneral_Product"
            Me.SearchableComboBoxViewGeneral_Product.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewGeneral_Product.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewGeneral_Product.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewGeneral_Product.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewGeneral_Product.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewGeneral_Product.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewGeneral_Product.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewGeneral_Product.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewGeneral_Product.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewGeneral_Product.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewGeneral_Product.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewGeneral_Product.RunStandardValidation = True
            '
            'LabelGeneral_Product
            '
            Me.LabelGeneral_Product.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_Product.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_Product.Location = New System.Drawing.Point(6, 108)
            Me.LabelGeneral_Product.Name = "LabelGeneral_Product"
            Me.LabelGeneral_Product.Size = New System.Drawing.Size(49, 20)
            Me.LabelGeneral_Product.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_Product.TabIndex = 10
            Me.LabelGeneral_Product.Text = "Product:"
            '
            'SearchableComboBoxGeneral_Division
            '
            Me.SearchableComboBoxGeneral_Division.ActiveFilterString = ""
            Me.SearchableComboBoxGeneral_Division.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxGeneral_Division.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxGeneral_Division.AutoFillMode = False
            Me.SearchableComboBoxGeneral_Division.BookmarkingEnabled = False
            Me.SearchableComboBoxGeneral_Division.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Division
            Me.SearchableComboBoxGeneral_Division.DataSource = Nothing
            Me.SearchableComboBoxGeneral_Division.DisableMouseWheel = True
            Me.SearchableComboBoxGeneral_Division.DisplayName = ""
            Me.SearchableComboBoxGeneral_Division.EditValue = ""
            Me.SearchableComboBoxGeneral_Division.EnterMoveNextControl = True
            Me.SearchableComboBoxGeneral_Division.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxGeneral_Division.Location = New System.Drawing.Point(61, 84)
            Me.SearchableComboBoxGeneral_Division.Name = "SearchableComboBoxGeneral_Division"
            Me.SearchableComboBoxGeneral_Division.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxGeneral_Division.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxGeneral_Division.Properties.NullText = "Select Division"
            Me.SearchableComboBoxGeneral_Division.Properties.ShowClearButton = False
            Me.SearchableComboBoxGeneral_Division.Properties.ValueMember = "Code"
            Me.SearchableComboBoxGeneral_Division.Properties.View = Me.SearchableComboBoxViewGeneral_Division
            Me.SearchableComboBoxGeneral_Division.SecurityEnabled = True
            Me.SearchableComboBoxGeneral_Division.SelectedValue = ""
            Me.SearchableComboBoxGeneral_Division.Size = New System.Drawing.Size(535, 20)
            Me.SearchableComboBoxGeneral_Division.TabIndex = 9
            '
            'SearchableComboBoxViewGeneral_Division
            '
            Me.SearchableComboBoxViewGeneral_Division.AFActiveFilterString = ""
            Me.SearchableComboBoxViewGeneral_Division.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewGeneral_Division.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Division.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Division.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Division.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Division.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Division.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Division.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Division.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Division.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Division.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Division.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Division.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Division.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Division.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Division.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Division.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Division.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Division.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Division.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Division.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Division.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Division.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Division.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Division.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Division.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Division.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Division.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Division.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Division.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Division.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Division.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Division.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Division.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Division.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Division.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Division.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Division.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Division.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewGeneral_Division.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewGeneral_Division.DataSourceClearing = False
            Me.SearchableComboBoxViewGeneral_Division.EnableDisabledRows = False
            Me.SearchableComboBoxViewGeneral_Division.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewGeneral_Division.Name = "SearchableComboBoxViewGeneral_Division"
            Me.SearchableComboBoxViewGeneral_Division.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewGeneral_Division.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewGeneral_Division.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewGeneral_Division.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewGeneral_Division.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewGeneral_Division.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewGeneral_Division.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewGeneral_Division.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewGeneral_Division.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewGeneral_Division.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewGeneral_Division.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewGeneral_Division.RunStandardValidation = True
            '
            'SearchableComboBoxGeneral_Client
            '
            Me.SearchableComboBoxGeneral_Client.ActiveFilterString = ""
            Me.SearchableComboBoxGeneral_Client.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxGeneral_Client.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxGeneral_Client.AutoFillMode = False
            Me.SearchableComboBoxGeneral_Client.BookmarkingEnabled = False
            Me.SearchableComboBoxGeneral_Client.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Client
            Me.SearchableComboBoxGeneral_Client.DataSource = Nothing
            Me.SearchableComboBoxGeneral_Client.DisableMouseWheel = True
            Me.SearchableComboBoxGeneral_Client.DisplayName = ""
            Me.SearchableComboBoxGeneral_Client.EnterMoveNextControl = True
            Me.SearchableComboBoxGeneral_Client.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxGeneral_Client.Location = New System.Drawing.Point(61, 56)
            Me.SearchableComboBoxGeneral_Client.Name = "SearchableComboBoxGeneral_Client"
            Me.SearchableComboBoxGeneral_Client.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxGeneral_Client.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxGeneral_Client.Properties.NullText = "Select Client"
            Me.SearchableComboBoxGeneral_Client.Properties.ShowClearButton = False
            Me.SearchableComboBoxGeneral_Client.Properties.ValueMember = "Code"
            Me.SearchableComboBoxGeneral_Client.Properties.View = Me.SearchableComboBoxViewGeneral_Client
            Me.SearchableComboBoxGeneral_Client.SecurityEnabled = True
            Me.SearchableComboBoxGeneral_Client.SelectedValue = Nothing
            Me.SearchableComboBoxGeneral_Client.Size = New System.Drawing.Size(535, 20)
            Me.SearchableComboBoxGeneral_Client.TabIndex = 7
            '
            'SearchableComboBoxViewGeneral_Client
            '
            Me.SearchableComboBoxViewGeneral_Client.AFActiveFilterString = ""
            Me.SearchableComboBoxViewGeneral_Client.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewGeneral_Client.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGeneral_Client.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewGeneral_Client.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewGeneral_Client.DataSourceClearing = False
            Me.SearchableComboBoxViewGeneral_Client.EnableDisabledRows = False
            Me.SearchableComboBoxViewGeneral_Client.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewGeneral_Client.Name = "SearchableComboBoxViewGeneral_Client"
            Me.SearchableComboBoxViewGeneral_Client.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewGeneral_Client.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewGeneral_Client.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewGeneral_Client.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewGeneral_Client.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewGeneral_Client.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewGeneral_Client.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewGeneral_Client.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewGeneral_Client.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewGeneral_Client.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewGeneral_Client.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewGeneral_Client.RunStandardValidation = True
            '
            'DateTimePickerGeneral_EndDate
            '
            Me.DateTimePickerGeneral_EndDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerGeneral_EndDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerGeneral_EndDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneral_EndDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerGeneral_EndDate.ButtonDropDown.Visible = True
            Me.DateTimePickerGeneral_EndDate.ButtonFreeText.Checked = True
            Me.DateTimePickerGeneral_EndDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerGeneral_EndDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerGeneral_EndDate.DisplayName = ""
            Me.DateTimePickerGeneral_EndDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerGeneral_EndDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerGeneral_EndDate.FocusHighlightEnabled = True
            Me.DateTimePickerGeneral_EndDate.FreeTextEntryMode = True
            Me.DateTimePickerGeneral_EndDate.IsPopupCalendarOpen = False
            Me.DateTimePickerGeneral_EndDate.Location = New System.Drawing.Point(61, 218)
            Me.DateTimePickerGeneral_EndDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerGeneral_EndDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerGeneral_EndDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerGeneral_EndDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneral_EndDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerGeneral_EndDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerGeneral_EndDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerGeneral_EndDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerGeneral_EndDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerGeneral_EndDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerGeneral_EndDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerGeneral_EndDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerGeneral_EndDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneral_EndDate.MonthCalendar.DisplayMonth = New Date(2012, 5, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerGeneral_EndDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerGeneral_EndDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerGeneral_EndDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerGeneral_EndDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneral_EndDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerGeneral_EndDate.Name = "DateTimePickerGeneral_EndDate"
            Me.DateTimePickerGeneral_EndDate.ReadOnly = False
            Me.DateTimePickerGeneral_EndDate.Size = New System.Drawing.Size(125, 20)
            Me.DateTimePickerGeneral_EndDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerGeneral_EndDate.TabIndex = 18
            Me.DateTimePickerGeneral_EndDate.TabOnEnter = True
            Me.DateTimePickerGeneral_EndDate.Value = New Date(2013, 11, 20, 9, 22, 37, 992)
            '
            'DateTimePickerGeneral_StartDate
            '
            Me.DateTimePickerGeneral_StartDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerGeneral_StartDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerGeneral_StartDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneral_StartDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerGeneral_StartDate.ButtonDropDown.Visible = True
            Me.DateTimePickerGeneral_StartDate.ButtonFreeText.Checked = True
            Me.DateTimePickerGeneral_StartDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerGeneral_StartDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerGeneral_StartDate.DisplayName = ""
            Me.DateTimePickerGeneral_StartDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerGeneral_StartDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerGeneral_StartDate.FocusHighlightEnabled = True
            Me.DateTimePickerGeneral_StartDate.FreeTextEntryMode = True
            Me.DateTimePickerGeneral_StartDate.IsPopupCalendarOpen = False
            Me.DateTimePickerGeneral_StartDate.Location = New System.Drawing.Point(61, 192)
            Me.DateTimePickerGeneral_StartDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerGeneral_StartDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerGeneral_StartDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerGeneral_StartDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneral_StartDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerGeneral_StartDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerGeneral_StartDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerGeneral_StartDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerGeneral_StartDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerGeneral_StartDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerGeneral_StartDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerGeneral_StartDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerGeneral_StartDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneral_StartDate.MonthCalendar.DisplayMonth = New Date(2012, 5, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerGeneral_StartDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerGeneral_StartDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerGeneral_StartDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerGeneral_StartDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneral_StartDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerGeneral_StartDate.Name = "DateTimePickerGeneral_StartDate"
            Me.DateTimePickerGeneral_StartDate.ReadOnly = False
            Me.DateTimePickerGeneral_StartDate.Size = New System.Drawing.Size(125, 20)
            Me.DateTimePickerGeneral_StartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerGeneral_StartDate.TabIndex = 16
            Me.DateTimePickerGeneral_StartDate.TabOnEnter = True
            Me.DateTimePickerGeneral_StartDate.Value = New Date(2013, 11, 20, 9, 22, 38, 23)
            '
            'LabelGeneralEndDate
            '
            Me.LabelGeneralEndDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneralEndDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneralEndDate.Location = New System.Drawing.Point(6, 218)
            Me.LabelGeneralEndDate.Name = "LabelGeneralEndDate"
            Me.LabelGeneralEndDate.Size = New System.Drawing.Size(49, 20)
            Me.LabelGeneralEndDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneralEndDate.TabIndex = 17
            Me.LabelGeneralEndDate.Text = "End Date:"
            '
            'GroupBoxGeneral_COType
            '
            Me.GroupBoxGeneral_COType.Controls.Add(Me.RadioButtonCOType_Opportunity)
            Me.GroupBoxGeneral_COType.Controls.Add(Me.RadioButtonCOType_Contract)
            Me.GroupBoxGeneral_COType.Location = New System.Drawing.Point(61, 136)
            Me.GroupBoxGeneral_COType.Name = "GroupBoxGeneral_COType"
            Me.GroupBoxGeneral_COType.Size = New System.Drawing.Size(249, 50)
            Me.GroupBoxGeneral_COType.TabIndex = 12
            Me.GroupBoxGeneral_COType.Text = "Contract / Opportunity:"
            '
            'RadioButtonCOType_Opportunity
            '
            Me.RadioButtonCOType_Opportunity.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonCOType_Opportunity.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonCOType_Opportunity.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonCOType_Opportunity.Location = New System.Drawing.Point(106, 24)
            Me.RadioButtonCOType_Opportunity.Name = "RadioButtonCOType_Opportunity"
            Me.RadioButtonCOType_Opportunity.SecurityEnabled = True
            Me.RadioButtonCOType_Opportunity.Size = New System.Drawing.Size(97, 20)
            Me.RadioButtonCOType_Opportunity.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonCOType_Opportunity.TabIndex = 14
            Me.RadioButtonCOType_Opportunity.TabOnEnter = True
            Me.RadioButtonCOType_Opportunity.TabStop = False
            Me.RadioButtonCOType_Opportunity.Text = "Opportunity"
            '
            'RadioButtonCOType_Contract
            '
            Me.RadioButtonCOType_Contract.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonCOType_Contract.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonCOType_Contract.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonCOType_Contract.Checked = True
            Me.RadioButtonCOType_Contract.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonCOType_Contract.CheckValue = "Y"
            Me.RadioButtonCOType_Contract.Location = New System.Drawing.Point(4, 24)
            Me.RadioButtonCOType_Contract.Name = "RadioButtonCOType_Contract"
            Me.RadioButtonCOType_Contract.SecurityEnabled = True
            Me.RadioButtonCOType_Contract.Size = New System.Drawing.Size(100, 20)
            Me.RadioButtonCOType_Contract.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonCOType_Contract.TabIndex = 13
            Me.RadioButtonCOType_Contract.TabOnEnter = True
            Me.RadioButtonCOType_Contract.Text = "Contract"
            '
            'LabelGeneralStartDate
            '
            Me.LabelGeneralStartDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneralStartDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneralStartDate.Location = New System.Drawing.Point(6, 192)
            Me.LabelGeneralStartDate.Name = "LabelGeneralStartDate"
            Me.LabelGeneralStartDate.Size = New System.Drawing.Size(56, 20)
            Me.LabelGeneralStartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneralStartDate.TabIndex = 15
            Me.LabelGeneralStartDate.Text = "Start Date:"
            '
            'AddressControlGeneral_Address
            '
            Me.AddressControlGeneral_Address.Address = Nothing
            Me.AddressControlGeneral_Address.Address2 = Nothing
            Me.AddressControlGeneral_Address.Address3 = Nothing
            Me.AddressControlGeneral_Address.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.AddressControlGeneral_Address.City = Nothing
            Me.AddressControlGeneral_Address.Country = Nothing
            Me.AddressControlGeneral_Address.County = Nothing
            Me.AddressControlGeneral_Address.DisableCountry = False
            Me.AddressControlGeneral_Address.DisableCounty = False
            Me.AddressControlGeneral_Address.Location = New System.Drawing.Point(316, 136)
            Me.AddressControlGeneral_Address.Margin = New System.Windows.Forms.Padding(4)
            Me.AddressControlGeneral_Address.Name = "AddressControlGeneral_Address"
            Me.AddressControlGeneral_Address.ReadOnly = True
            Me.AddressControlGeneral_Address.ShowCountry = True
            Me.AddressControlGeneral_Address.ShowCounty = True
            Me.AddressControlGeneral_Address.Size = New System.Drawing.Size(280, 181)
            Me.AddressControlGeneral_Address.State = Nothing
            Me.AddressControlGeneral_Address.TabIndex = 19
            Me.AddressControlGeneral_Address.TabStop = False
            Me.AddressControlGeneral_Address.Title = "Address"
            Me.AddressControlGeneral_Address.Zip = Nothing
            '
            'CheckBoxGeneral_NewBusiness
            '
            Me.CheckBoxGeneral_NewBusiness.AutoCheck = False
            Me.CheckBoxGeneral_NewBusiness.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxGeneral_NewBusiness.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxGeneral_NewBusiness.CheckValue = 0
            Me.CheckBoxGeneral_NewBusiness.CheckValueChecked = 1
            Me.CheckBoxGeneral_NewBusiness.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxGeneral_NewBusiness.CheckValueUnchecked = 0
            Me.CheckBoxGeneral_NewBusiness.ChildControls = CType(resources.GetObject("CheckBoxGeneral_NewBusiness.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxGeneral_NewBusiness.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxGeneral_NewBusiness.Location = New System.Drawing.Point(142, 4)
            Me.CheckBoxGeneral_NewBusiness.Name = "CheckBoxGeneral_NewBusiness"
            Me.CheckBoxGeneral_NewBusiness.OldestSibling = Nothing
            Me.CheckBoxGeneral_NewBusiness.SecurityEnabled = True
            Me.CheckBoxGeneral_NewBusiness.SiblingControls = CType(resources.GetObject("CheckBoxGeneral_NewBusiness.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxGeneral_NewBusiness.Size = New System.Drawing.Size(99, 20)
            Me.CheckBoxGeneral_NewBusiness.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxGeneral_NewBusiness.TabIndex = 2
            Me.CheckBoxGeneral_NewBusiness.TabOnEnter = True
            Me.CheckBoxGeneral_NewBusiness.TabStop = False
            Me.CheckBoxGeneral_NewBusiness.Text = "New Business"
            '
            'LabelGeneral_Code
            '
            Me.LabelGeneral_Code.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_Code.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_Code.Location = New System.Drawing.Point(6, 4)
            Me.LabelGeneral_Code.Name = "LabelGeneral_Code"
            Me.LabelGeneral_Code.Size = New System.Drawing.Size(49, 20)
            Me.LabelGeneral_Code.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_Code.TabIndex = 0
            Me.LabelGeneral_Code.Text = "Code:"
            '
            'LabelGeneral_Client
            '
            Me.LabelGeneral_Client.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_Client.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_Client.Location = New System.Drawing.Point(6, 56)
            Me.LabelGeneral_Client.Name = "LabelGeneral_Client"
            Me.LabelGeneral_Client.Size = New System.Drawing.Size(49, 20)
            Me.LabelGeneral_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_Client.TabIndex = 6
            Me.LabelGeneral_Client.Text = "Client: "
            '
            'LabelGeneral_Division
            '
            Me.LabelGeneral_Division.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_Division.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_Division.Location = New System.Drawing.Point(6, 82)
            Me.LabelGeneral_Division.Name = "LabelGeneral_Division"
            Me.LabelGeneral_Division.Size = New System.Drawing.Size(49, 20)
            Me.LabelGeneral_Division.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_Division.TabIndex = 8
            Me.LabelGeneral_Division.Text = "Division: "
            '
            'CheckBoxGeneral_Inactive
            '
            Me.CheckBoxGeneral_Inactive.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxGeneral_Inactive.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxGeneral_Inactive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxGeneral_Inactive.CheckValue = 0
            Me.CheckBoxGeneral_Inactive.CheckValueChecked = 1
            Me.CheckBoxGeneral_Inactive.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxGeneral_Inactive.CheckValueUnchecked = 0
            Me.CheckBoxGeneral_Inactive.ChildControls = CType(resources.GetObject("CheckBoxGeneral_Inactive.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxGeneral_Inactive.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxGeneral_Inactive.Location = New System.Drawing.Point(530, 30)
            Me.CheckBoxGeneral_Inactive.Name = "CheckBoxGeneral_Inactive"
            Me.CheckBoxGeneral_Inactive.OldestSibling = Nothing
            Me.CheckBoxGeneral_Inactive.SecurityEnabled = True
            Me.CheckBoxGeneral_Inactive.SiblingControls = CType(resources.GetObject("CheckBoxGeneral_Inactive.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxGeneral_Inactive.Size = New System.Drawing.Size(66, 20)
            Me.CheckBoxGeneral_Inactive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxGeneral_Inactive.TabIndex = 5
            Me.CheckBoxGeneral_Inactive.TabOnEnter = True
            Me.CheckBoxGeneral_Inactive.Text = "Inactive"
            '
            'TextBoxGeneral_Code
            '
            '
            '
            '
            Me.TextBoxGeneral_Code.Border.Class = "TextBoxBorder"
            Me.TextBoxGeneral_Code.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxGeneral_Code.CheckSpellingOnValidate = False
            Me.TextBoxGeneral_Code.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxGeneral_Code.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxGeneral_Code.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxGeneral_Code.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxGeneral_Code.FocusHighlightEnabled = True
            Me.TextBoxGeneral_Code.Location = New System.Drawing.Point(61, 4)
            Me.TextBoxGeneral_Code.MaxFileSize = CType(0, Long)
            Me.TextBoxGeneral_Code.Name = "TextBoxGeneral_Code"
            Me.TextBoxGeneral_Code.SecurityEnabled = True
            Me.TextBoxGeneral_Code.ShowSpellCheckCompleteMessage = True
            Me.TextBoxGeneral_Code.Size = New System.Drawing.Size(75, 20)
            Me.TextBoxGeneral_Code.StartingFolderName = Nothing
            Me.TextBoxGeneral_Code.TabIndex = 1
            Me.TextBoxGeneral_Code.TabOnEnter = True
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
            Me.TextBoxGeneral_Description.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxGeneral_Description.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxGeneral_Description.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxGeneral_Description.FocusHighlightEnabled = True
            Me.TextBoxGeneral_Description.Location = New System.Drawing.Point(61, 30)
            Me.TextBoxGeneral_Description.MaxFileSize = CType(0, Long)
            Me.TextBoxGeneral_Description.Name = "TextBoxGeneral_Description"
            Me.TextBoxGeneral_Description.SecurityEnabled = True
            Me.TextBoxGeneral_Description.ShowSpellCheckCompleteMessage = True
            Me.TextBoxGeneral_Description.Size = New System.Drawing.Size(463, 20)
            Me.TextBoxGeneral_Description.StartingFolderName = Nothing
            Me.TextBoxGeneral_Description.TabIndex = 4
            Me.TextBoxGeneral_Description.TabOnEnter = True
            '
            'LabelGeneral_Name
            '
            Me.LabelGeneral_Name.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_Name.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_Name.Location = New System.Drawing.Point(6, 30)
            Me.LabelGeneral_Name.Name = "LabelGeneral_Name"
            Me.LabelGeneral_Name.Size = New System.Drawing.Size(49, 20)
            Me.LabelGeneral_Name.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_Name.TabIndex = 3
            Me.LabelGeneral_Name.Text = "Name:"
            '
            'TabItemContractSetup_GeneralTab
            '
            Me.TabItemContractSetup_GeneralTab.AttachedControl = Me.TabControlPanelGeneral_General
            Me.TabItemContractSetup_GeneralTab.Name = "TabItemContractSetup_GeneralTab"
            Me.TabItemContractSetup_GeneralTab.Text = "General"
            '
            'TabControlPanelComments_Comments
            '
            Me.TabControlPanelComments_Comments.Controls.Add(Me.LabelComments_Comments)
            Me.TabControlPanelComments_Comments.Controls.Add(Me.TextBoxComments_Comments)
            Me.TabControlPanelComments_Comments.Controls.Add(Me.LabelComments_EstimatingTerms)
            Me.TabControlPanelComments_Comments.Controls.Add(Me.TextBoxComments_EstimatingTerms)
            Me.TabControlPanelComments_Comments.Controls.Add(Me.TextBoxComments_BillingTerms)
            Me.TabControlPanelComments_Comments.Controls.Add(Me.LabelComments_BillingTerms)
            Me.TabControlPanelComments_Comments.Controls.Add(Me.TextBoxComments_BillingRateComment)
            Me.TabControlPanelComments_Comments.Controls.Add(Me.LabelComments_BillingRateComment)
            Me.TabControlPanelComments_Comments.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelComments_Comments.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelComments_Comments.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelComments_Comments.Name = "TabControlPanelComments_Comments"
            Me.TabControlPanelComments_Comments.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelComments_Comments.Size = New System.Drawing.Size(602, 596)
            Me.TabControlPanelComments_Comments.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelComments_Comments.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelComments_Comments.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelComments_Comments.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelComments_Comments.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelComments_Comments.Style.GradientAngle = 90
            Me.TabControlPanelComments_Comments.TabIndex = 12
            Me.TabControlPanelComments_Comments.TabItem = Me.TabItemContractSetup_CommentsTab
            '
            'LabelComments_EstimatingTerms
            '
            Me.LabelComments_EstimatingTerms.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelComments_EstimatingTerms.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelComments_EstimatingTerms.Location = New System.Drawing.Point(6, 290)
            Me.LabelComments_EstimatingTerms.Name = "LabelComments_EstimatingTerms"
            Me.LabelComments_EstimatingTerms.Size = New System.Drawing.Size(119, 20)
            Me.LabelComments_EstimatingTerms.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelComments_EstimatingTerms.TabIndex = 4
            Me.LabelComments_EstimatingTerms.Text = "Estimating Terms:"
            '
            'TextBoxComments_EstimatingTerms
            '
            Me.TextBoxComments_EstimatingTerms.AcceptsReturn = True
            Me.TextBoxComments_EstimatingTerms.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxComments_EstimatingTerms.Border.Class = "TextBoxBorder"
            Me.TextBoxComments_EstimatingTerms.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxComments_EstimatingTerms.CheckSpellingOnValidate = False
            Me.TextBoxComments_EstimatingTerms.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxComments_EstimatingTerms.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxComments_EstimatingTerms.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxComments_EstimatingTerms.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxComments_EstimatingTerms.FocusHighlightEnabled = True
            Me.TextBoxComments_EstimatingTerms.Location = New System.Drawing.Point(131, 290)
            Me.TextBoxComments_EstimatingTerms.MaxFileSize = CType(0, Long)
            Me.TextBoxComments_EstimatingTerms.Multiline = True
            Me.TextBoxComments_EstimatingTerms.Name = "TextBoxComments_EstimatingTerms"
            Me.TextBoxComments_EstimatingTerms.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.TextBoxComments_EstimatingTerms.SecurityEnabled = True
            Me.TextBoxComments_EstimatingTerms.ShowSpellCheckCompleteMessage = True
            Me.TextBoxComments_EstimatingTerms.Size = New System.Drawing.Size(465, 149)
            Me.TextBoxComments_EstimatingTerms.StartingFolderName = Nothing
            Me.TextBoxComments_EstimatingTerms.TabIndex = 5
            Me.TextBoxComments_EstimatingTerms.TabOnEnter = True
            '
            'TextBoxComments_BillingTerms
            '
            Me.TextBoxComments_BillingTerms.AcceptsReturn = True
            Me.TextBoxComments_BillingTerms.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxComments_BillingTerms.Border.Class = "TextBoxBorder"
            Me.TextBoxComments_BillingTerms.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxComments_BillingTerms.CheckSpellingOnValidate = False
            Me.TextBoxComments_BillingTerms.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxComments_BillingTerms.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxComments_BillingTerms.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxComments_BillingTerms.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxComments_BillingTerms.FocusHighlightEnabled = True
            Me.TextBoxComments_BillingTerms.Location = New System.Drawing.Point(131, 148)
            Me.TextBoxComments_BillingTerms.MaxFileSize = CType(0, Long)
            Me.TextBoxComments_BillingTerms.Multiline = True
            Me.TextBoxComments_BillingTerms.Name = "TextBoxComments_BillingTerms"
            Me.TextBoxComments_BillingTerms.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.TextBoxComments_BillingTerms.SecurityEnabled = True
            Me.TextBoxComments_BillingTerms.ShowSpellCheckCompleteMessage = True
            Me.TextBoxComments_BillingTerms.Size = New System.Drawing.Size(465, 136)
            Me.TextBoxComments_BillingTerms.StartingFolderName = Nothing
            Me.TextBoxComments_BillingTerms.TabIndex = 3
            Me.TextBoxComments_BillingTerms.TabOnEnter = True
            '
            'LabelComments_BillingTerms
            '
            Me.LabelComments_BillingTerms.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelComments_BillingTerms.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelComments_BillingTerms.Location = New System.Drawing.Point(6, 148)
            Me.LabelComments_BillingTerms.Name = "LabelComments_BillingTerms"
            Me.LabelComments_BillingTerms.Size = New System.Drawing.Size(119, 20)
            Me.LabelComments_BillingTerms.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelComments_BillingTerms.TabIndex = 2
            Me.LabelComments_BillingTerms.Text = "Billing Terms:"
            '
            'TextBoxComments_BillingRateComment
            '
            Me.TextBoxComments_BillingRateComment.AcceptsReturn = True
            Me.TextBoxComments_BillingRateComment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxComments_BillingRateComment.Border.Class = "TextBoxBorder"
            Me.TextBoxComments_BillingRateComment.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxComments_BillingRateComment.CheckSpellingOnValidate = False
            Me.TextBoxComments_BillingRateComment.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxComments_BillingRateComment.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxComments_BillingRateComment.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxComments_BillingRateComment.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxComments_BillingRateComment.FocusHighlightEnabled = True
            Me.TextBoxComments_BillingRateComment.Location = New System.Drawing.Point(131, 6)
            Me.TextBoxComments_BillingRateComment.MaxFileSize = CType(0, Long)
            Me.TextBoxComments_BillingRateComment.Multiline = True
            Me.TextBoxComments_BillingRateComment.Name = "TextBoxComments_BillingRateComment"
            Me.TextBoxComments_BillingRateComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.TextBoxComments_BillingRateComment.SecurityEnabled = True
            Me.TextBoxComments_BillingRateComment.ShowSpellCheckCompleteMessage = True
            Me.TextBoxComments_BillingRateComment.Size = New System.Drawing.Size(465, 136)
            Me.TextBoxComments_BillingRateComment.StartingFolderName = Nothing
            Me.TextBoxComments_BillingRateComment.TabIndex = 1
            Me.TextBoxComments_BillingRateComment.TabOnEnter = True
            '
            'LabelComments_BillingRateComment
            '
            Me.LabelComments_BillingRateComment.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelComments_BillingRateComment.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelComments_BillingRateComment.Location = New System.Drawing.Point(6, 6)
            Me.LabelComments_BillingRateComment.Name = "LabelComments_BillingRateComment"
            Me.LabelComments_BillingRateComment.Size = New System.Drawing.Size(119, 20)
            Me.LabelComments_BillingRateComment.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelComments_BillingRateComment.TabIndex = 0
            Me.LabelComments_BillingRateComment.Text = "Billing Rate Comment:"
            '
            'TabItemContractSetup_CommentsTab
            '
            Me.TabItemContractSetup_CommentsTab.AttachedControl = Me.TabControlPanelComments_Comments
            Me.TabItemContractSetup_CommentsTab.Name = "TabItemContractSetup_CommentsTab"
            Me.TabItemContractSetup_CommentsTab.Text = "Comments"
            '
            'TabControlPanelContactsTab_Contacts
            '
            Me.TabControlPanelContactsTab_Contacts.Controls.Add(Me.DataGridViewInternalContacts_Contacts)
            Me.TabControlPanelContactsTab_Contacts.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelContactsTab_Contacts.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelContactsTab_Contacts.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelContactsTab_Contacts.Name = "TabControlPanelContactsTab_Contacts"
            Me.TabControlPanelContactsTab_Contacts.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelContactsTab_Contacts.Size = New System.Drawing.Size(602, 596)
            Me.TabControlPanelContactsTab_Contacts.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelContactsTab_Contacts.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelContactsTab_Contacts.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelContactsTab_Contacts.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelContactsTab_Contacts.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelContactsTab_Contacts.Style.GradientAngle = 90
            Me.TabControlPanelContactsTab_Contacts.TabIndex = 9
            Me.TabControlPanelContactsTab_Contacts.TabItem = Me.TabItemContractSetup_InternalContactsTab
            '
            'DataGridViewInternalContacts_Contacts
            '
            Me.DataGridViewInternalContacts_Contacts.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewInternalContacts_Contacts.AllowDragAndDrop = False
            Me.DataGridViewInternalContacts_Contacts.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewInternalContacts_Contacts.AllowSelectGroupHeaderRow = True
            Me.DataGridViewInternalContacts_Contacts.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewInternalContacts_Contacts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewInternalContacts_Contacts.AutoFilterLookupColumns = False
            Me.DataGridViewInternalContacts_Contacts.AutoloadRepositoryDatasource = True
            Me.DataGridViewInternalContacts_Contacts.AutoUpdateViewCaption = True
            Me.DataGridViewInternalContacts_Contacts.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewInternalContacts_Contacts.DataSource = Nothing
            Me.DataGridViewInternalContacts_Contacts.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewInternalContacts_Contacts.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewInternalContacts_Contacts.ItemDescription = "Internal Contact(s)"
            Me.DataGridViewInternalContacts_Contacts.Location = New System.Drawing.Point(6, 6)
            Me.DataGridViewInternalContacts_Contacts.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewInternalContacts_Contacts.MultiSelect = False
            Me.DataGridViewInternalContacts_Contacts.Name = "DataGridViewInternalContacts_Contacts"
            Me.DataGridViewInternalContacts_Contacts.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewInternalContacts_Contacts.RunStandardValidation = True
            Me.DataGridViewInternalContacts_Contacts.ShowColumnMenuOnRightClick = False
            Me.DataGridViewInternalContacts_Contacts.ShowSelectDeselectAllButtons = False
            Me.DataGridViewInternalContacts_Contacts.Size = New System.Drawing.Size(590, 586)
            Me.DataGridViewInternalContacts_Contacts.TabIndex = 17
            Me.DataGridViewInternalContacts_Contacts.UseEmbeddedNavigator = False
            Me.DataGridViewInternalContacts_Contacts.ViewCaptionHeight = -1
            '
            'TabItemContractSetup_InternalContactsTab
            '
            Me.TabItemContractSetup_InternalContactsTab.AttachedControl = Me.TabControlPanelContactsTab_Contacts
            Me.TabItemContractSetup_InternalContactsTab.Name = "TabItemContractSetup_InternalContactsTab"
            Me.TabItemContractSetup_InternalContactsTab.Text = "Internal Contacts"
            '
            'TabControlPanelRatesTerms_RatesTerms
            '
            Me.TabControlPanelRatesTerms_RatesTerms.Controls.Add(Me.ButtonRateTerm_UpdateFeeRetainer)
            Me.TabControlPanelRatesTerms_RatesTerms.Controls.Add(Me.NumericInputRateTerms_Hours)
            Me.TabControlPanelRatesTerms_RatesTerms.Controls.Add(Me.LabelRateTerm_Hours)
            Me.TabControlPanelRatesTerms_RatesTerms.Controls.Add(Me.NumericInputRateTerms_TotalContractValue)
            Me.TabControlPanelRatesTerms_RatesTerms.Controls.Add(Me.NumericInputRateTerms_ProductionCommission)
            Me.TabControlPanelRatesTerms_RatesTerms.Controls.Add(Me.NumericInputRateTerms_MediaCommission)
            Me.TabControlPanelRatesTerms_RatesTerms.Controls.Add(Me.NumericInputRateTerms_FeeProjectHourly)
            Me.TabControlPanelRatesTerms_RatesTerms.Controls.Add(Me.NumericInputRateTerms_FeeRoyalty)
            Me.TabControlPanelRatesTerms_RatesTerms.Controls.Add(Me.NumericInputRateTerms_FeeIncentiveBonus)
            Me.TabControlPanelRatesTerms_RatesTerms.Controls.Add(Me.NumericInputRateTerms_FeeRetainer)
            Me.TabControlPanelRatesTerms_RatesTerms.Controls.Add(Me.LabelRateTerm_TotalContractValue)
            Me.TabControlPanelRatesTerms_RatesTerms.Controls.Add(Me.LabelRateTerm_ProductCommission)
            Me.TabControlPanelRatesTerms_RatesTerms.Controls.Add(Me.LabelRateTerm_MediaCommission)
            Me.TabControlPanelRatesTerms_RatesTerms.Controls.Add(Me.LabelRateTerm_ProjectHourlyTotal)
            Me.TabControlPanelRatesTerms_RatesTerms.Controls.Add(Me.LabelRateTerm_FeeRoyalty)
            Me.TabControlPanelRatesTerms_RatesTerms.Controls.Add(Me.LabelRateTerm_FeeIncentiveBonus)
            Me.TabControlPanelRatesTerms_RatesTerms.Controls.Add(Me.LabelRateTerm_FeeRetainer)
            Me.TabControlPanelRatesTerms_RatesTerms.Controls.Add(Me.DataGridViewRateTerm_ContractFees)
            Me.TabControlPanelRatesTerms_RatesTerms.Controls.Add(Me.GroupBoxRateTerm_ContractType)
            Me.TabControlPanelRatesTerms_RatesTerms.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelRatesTerms_RatesTerms.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelRatesTerms_RatesTerms.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelRatesTerms_RatesTerms.Name = "TabControlPanelRatesTerms_RatesTerms"
            Me.TabControlPanelRatesTerms_RatesTerms.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelRatesTerms_RatesTerms.Size = New System.Drawing.Size(602, 596)
            Me.TabControlPanelRatesTerms_RatesTerms.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelRatesTerms_RatesTerms.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelRatesTerms_RatesTerms.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelRatesTerms_RatesTerms.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelRatesTerms_RatesTerms.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelRatesTerms_RatesTerms.Style.GradientAngle = 90
            Me.TabControlPanelRatesTerms_RatesTerms.TabIndex = 0
            Me.TabControlPanelRatesTerms_RatesTerms.TabItem = Me.TabItemContractSetup_RatesTermsTab
            '
            'ButtonRateTerm_UpdateFeeRetainer
            '
            Me.ButtonRateTerm_UpdateFeeRetainer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRateTerm_UpdateFeeRetainer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRateTerm_UpdateFeeRetainer.Location = New System.Drawing.Point(264, 72)
            Me.ButtonRateTerm_UpdateFeeRetainer.Name = "ButtonRateTerm_UpdateFeeRetainer"
            Me.ButtonRateTerm_UpdateFeeRetainer.SecurityEnabled = True
            Me.ButtonRateTerm_UpdateFeeRetainer.Size = New System.Drawing.Size(50, 20)
            Me.ButtonRateTerm_UpdateFeeRetainer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRateTerm_UpdateFeeRetainer.TabIndex = 3
            Me.ButtonRateTerm_UpdateFeeRetainer.TabStop = False
            Me.ButtonRateTerm_UpdateFeeRetainer.Text = "Refresh"
            '
            'NumericInputRateTerms_Hours
            '
            Me.NumericInputRateTerms_Hours.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputRateTerms_Hours.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputRateTerms_Hours.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputRateTerms_Hours.EnterMoveNextControl = True
            Me.NumericInputRateTerms_Hours.Location = New System.Drawing.Point(307, 150)
            Me.NumericInputRateTerms_Hours.Name = "NumericInputRateTerms_Hours"
            Me.NumericInputRateTerms_Hours.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputRateTerms_Hours.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputRateTerms_Hours.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputRateTerms_Hours.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputRateTerms_Hours.Properties.EditFormat.FormatString = "f"
            Me.NumericInputRateTerms_Hours.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputRateTerms_Hours.Properties.Mask.EditMask = "f"
            Me.NumericInputRateTerms_Hours.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputRateTerms_Hours.SecurityEnabled = True
            Me.NumericInputRateTerms_Hours.Size = New System.Drawing.Size(94, 20)
            Me.NumericInputRateTerms_Hours.TabIndex = 11
            '
            'LabelRateTerm_Hours
            '
            Me.LabelRateTerm_Hours.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRateTerm_Hours.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRateTerm_Hours.Location = New System.Drawing.Point(264, 150)
            Me.LabelRateTerm_Hours.Name = "LabelRateTerm_Hours"
            Me.LabelRateTerm_Hours.Size = New System.Drawing.Size(37, 20)
            Me.LabelRateTerm_Hours.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRateTerm_Hours.TabIndex = 10
            Me.LabelRateTerm_Hours.Text = "Hours:"
            '
            'NumericInputRateTerms_TotalContractValue
            '
            Me.NumericInputRateTerms_TotalContractValue.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputRateTerms_TotalContractValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.NumericInputRateTerms_TotalContractValue.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputRateTerms_TotalContractValue.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputRateTerms_TotalContractValue.EnterMoveNextControl = True
            Me.NumericInputRateTerms_TotalContractValue.Location = New System.Drawing.Point(471, 124)
            Me.NumericInputRateTerms_TotalContractValue.Name = "NumericInputRateTerms_TotalContractValue"
            Me.NumericInputRateTerms_TotalContractValue.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputRateTerms_TotalContractValue.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputRateTerms_TotalContractValue.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputRateTerms_TotalContractValue.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputRateTerms_TotalContractValue.Properties.EditFormat.FormatString = "f"
            Me.NumericInputRateTerms_TotalContractValue.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputRateTerms_TotalContractValue.Properties.Mask.EditMask = "f"
            Me.NumericInputRateTerms_TotalContractValue.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputRateTerms_TotalContractValue.Properties.ReadOnly = True
            Me.NumericInputRateTerms_TotalContractValue.SecurityEnabled = True
            Me.NumericInputRateTerms_TotalContractValue.Size = New System.Drawing.Size(125, 20)
            Me.NumericInputRateTerms_TotalContractValue.TabIndex = 17
            Me.NumericInputRateTerms_TotalContractValue.TabStop = False
            '
            'NumericInputRateTerms_ProductionCommission
            '
            Me.NumericInputRateTerms_ProductionCommission.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputRateTerms_ProductionCommission.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.NumericInputRateTerms_ProductionCommission.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputRateTerms_ProductionCommission.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputRateTerms_ProductionCommission.EnterMoveNextControl = True
            Me.NumericInputRateTerms_ProductionCommission.Location = New System.Drawing.Point(471, 98)
            Me.NumericInputRateTerms_ProductionCommission.Name = "NumericInputRateTerms_ProductionCommission"
            Me.NumericInputRateTerms_ProductionCommission.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputRateTerms_ProductionCommission.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputRateTerms_ProductionCommission.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputRateTerms_ProductionCommission.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputRateTerms_ProductionCommission.Properties.EditFormat.FormatString = "f"
            Me.NumericInputRateTerms_ProductionCommission.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputRateTerms_ProductionCommission.Properties.Mask.EditMask = "f"
            Me.NumericInputRateTerms_ProductionCommission.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputRateTerms_ProductionCommission.SecurityEnabled = True
            Me.NumericInputRateTerms_ProductionCommission.Size = New System.Drawing.Size(125, 20)
            Me.NumericInputRateTerms_ProductionCommission.TabIndex = 15
            '
            'NumericInputRateTerms_MediaCommission
            '
            Me.NumericInputRateTerms_MediaCommission.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputRateTerms_MediaCommission.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.NumericInputRateTerms_MediaCommission.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputRateTerms_MediaCommission.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputRateTerms_MediaCommission.EnterMoveNextControl = True
            Me.NumericInputRateTerms_MediaCommission.Location = New System.Drawing.Point(471, 72)
            Me.NumericInputRateTerms_MediaCommission.Name = "NumericInputRateTerms_MediaCommission"
            Me.NumericInputRateTerms_MediaCommission.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputRateTerms_MediaCommission.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputRateTerms_MediaCommission.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputRateTerms_MediaCommission.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputRateTerms_MediaCommission.Properties.EditFormat.FormatString = "f"
            Me.NumericInputRateTerms_MediaCommission.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputRateTerms_MediaCommission.Properties.Mask.EditMask = "f"
            Me.NumericInputRateTerms_MediaCommission.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputRateTerms_MediaCommission.SecurityEnabled = True
            Me.NumericInputRateTerms_MediaCommission.Size = New System.Drawing.Size(125, 20)
            Me.NumericInputRateTerms_MediaCommission.TabIndex = 13
            '
            'NumericInputRateTerms_FeeProjectHourly
            '
            Me.NumericInputRateTerms_FeeProjectHourly.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputRateTerms_FeeProjectHourly.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputRateTerms_FeeProjectHourly.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputRateTerms_FeeProjectHourly.EnterMoveNextControl = True
            Me.NumericInputRateTerms_FeeProjectHourly.Location = New System.Drawing.Point(133, 150)
            Me.NumericInputRateTerms_FeeProjectHourly.Name = "NumericInputRateTerms_FeeProjectHourly"
            Me.NumericInputRateTerms_FeeProjectHourly.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputRateTerms_FeeProjectHourly.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputRateTerms_FeeProjectHourly.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputRateTerms_FeeProjectHourly.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputRateTerms_FeeProjectHourly.Properties.EditFormat.FormatString = "f"
            Me.NumericInputRateTerms_FeeProjectHourly.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputRateTerms_FeeProjectHourly.Properties.Mask.EditMask = "f"
            Me.NumericInputRateTerms_FeeProjectHourly.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputRateTerms_FeeProjectHourly.SecurityEnabled = True
            Me.NumericInputRateTerms_FeeProjectHourly.Size = New System.Drawing.Size(125, 20)
            Me.NumericInputRateTerms_FeeProjectHourly.TabIndex = 9
            '
            'NumericInputRateTerms_FeeRoyalty
            '
            Me.NumericInputRateTerms_FeeRoyalty.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputRateTerms_FeeRoyalty.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputRateTerms_FeeRoyalty.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputRateTerms_FeeRoyalty.EnterMoveNextControl = True
            Me.NumericInputRateTerms_FeeRoyalty.Location = New System.Drawing.Point(133, 124)
            Me.NumericInputRateTerms_FeeRoyalty.Name = "NumericInputRateTerms_FeeRoyalty"
            Me.NumericInputRateTerms_FeeRoyalty.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputRateTerms_FeeRoyalty.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputRateTerms_FeeRoyalty.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputRateTerms_FeeRoyalty.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputRateTerms_FeeRoyalty.Properties.EditFormat.FormatString = "f"
            Me.NumericInputRateTerms_FeeRoyalty.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputRateTerms_FeeRoyalty.Properties.Mask.EditMask = "f"
            Me.NumericInputRateTerms_FeeRoyalty.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputRateTerms_FeeRoyalty.SecurityEnabled = True
            Me.NumericInputRateTerms_FeeRoyalty.Size = New System.Drawing.Size(125, 20)
            Me.NumericInputRateTerms_FeeRoyalty.TabIndex = 7
            '
            'NumericInputRateTerms_FeeIncentiveBonus
            '
            Me.NumericInputRateTerms_FeeIncentiveBonus.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputRateTerms_FeeIncentiveBonus.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputRateTerms_FeeIncentiveBonus.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputRateTerms_FeeIncentiveBonus.EnterMoveNextControl = True
            Me.NumericInputRateTerms_FeeIncentiveBonus.Location = New System.Drawing.Point(133, 98)
            Me.NumericInputRateTerms_FeeIncentiveBonus.Name = "NumericInputRateTerms_FeeIncentiveBonus"
            Me.NumericInputRateTerms_FeeIncentiveBonus.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputRateTerms_FeeIncentiveBonus.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputRateTerms_FeeIncentiveBonus.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputRateTerms_FeeIncentiveBonus.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputRateTerms_FeeIncentiveBonus.Properties.EditFormat.FormatString = "f"
            Me.NumericInputRateTerms_FeeIncentiveBonus.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputRateTerms_FeeIncentiveBonus.Properties.Mask.EditMask = "f"
            Me.NumericInputRateTerms_FeeIncentiveBonus.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputRateTerms_FeeIncentiveBonus.SecurityEnabled = True
            Me.NumericInputRateTerms_FeeIncentiveBonus.Size = New System.Drawing.Size(125, 20)
            Me.NumericInputRateTerms_FeeIncentiveBonus.TabIndex = 5
            '
            'NumericInputRateTerms_FeeRetainer
            '
            Me.NumericInputRateTerms_FeeRetainer.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputRateTerms_FeeRetainer.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputRateTerms_FeeRetainer.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputRateTerms_FeeRetainer.EnterMoveNextControl = True
            Me.NumericInputRateTerms_FeeRetainer.Location = New System.Drawing.Point(133, 72)
            Me.NumericInputRateTerms_FeeRetainer.Name = "NumericInputRateTerms_FeeRetainer"
            Me.NumericInputRateTerms_FeeRetainer.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputRateTerms_FeeRetainer.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputRateTerms_FeeRetainer.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputRateTerms_FeeRetainer.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputRateTerms_FeeRetainer.Properties.EditFormat.FormatString = "f"
            Me.NumericInputRateTerms_FeeRetainer.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputRateTerms_FeeRetainer.Properties.Mask.EditMask = "f"
            Me.NumericInputRateTerms_FeeRetainer.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputRateTerms_FeeRetainer.SecurityEnabled = True
            Me.NumericInputRateTerms_FeeRetainer.Size = New System.Drawing.Size(125, 20)
            Me.NumericInputRateTerms_FeeRetainer.TabIndex = 2
            '
            'LabelRateTerm_TotalContractValue
            '
            Me.LabelRateTerm_TotalContractValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelRateTerm_TotalContractValue.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRateTerm_TotalContractValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRateTerm_TotalContractValue.Location = New System.Drawing.Point(344, 124)
            Me.LabelRateTerm_TotalContractValue.Name = "LabelRateTerm_TotalContractValue"
            Me.LabelRateTerm_TotalContractValue.Size = New System.Drawing.Size(121, 20)
            Me.LabelRateTerm_TotalContractValue.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRateTerm_TotalContractValue.TabIndex = 16
            Me.LabelRateTerm_TotalContractValue.Text = "Total Contract Value:"
            '
            'LabelRateTerm_ProductCommission
            '
            Me.LabelRateTerm_ProductCommission.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelRateTerm_ProductCommission.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRateTerm_ProductCommission.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRateTerm_ProductCommission.Location = New System.Drawing.Point(344, 98)
            Me.LabelRateTerm_ProductCommission.Name = "LabelRateTerm_ProductCommission"
            Me.LabelRateTerm_ProductCommission.Size = New System.Drawing.Size(121, 20)
            Me.LabelRateTerm_ProductCommission.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRateTerm_ProductCommission.TabIndex = 14
            Me.LabelRateTerm_ProductCommission.Text = "Production Commission:"
            '
            'LabelRateTerm_MediaCommission
            '
            Me.LabelRateTerm_MediaCommission.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelRateTerm_MediaCommission.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRateTerm_MediaCommission.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRateTerm_MediaCommission.Location = New System.Drawing.Point(344, 72)
            Me.LabelRateTerm_MediaCommission.Name = "LabelRateTerm_MediaCommission"
            Me.LabelRateTerm_MediaCommission.Size = New System.Drawing.Size(121, 20)
            Me.LabelRateTerm_MediaCommission.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRateTerm_MediaCommission.TabIndex = 12
            Me.LabelRateTerm_MediaCommission.Text = "Media Commission:"
            '
            'LabelRateTerm_ProjectHourlyTotal
            '
            Me.LabelRateTerm_ProjectHourlyTotal.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRateTerm_ProjectHourlyTotal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRateTerm_ProjectHourlyTotal.Location = New System.Drawing.Point(6, 150)
            Me.LabelRateTerm_ProjectHourlyTotal.Name = "LabelRateTerm_ProjectHourlyTotal"
            Me.LabelRateTerm_ProjectHourlyTotal.Size = New System.Drawing.Size(121, 20)
            Me.LabelRateTerm_ProjectHourlyTotal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRateTerm_ProjectHourlyTotal.TabIndex = 8
            Me.LabelRateTerm_ProjectHourlyTotal.Text = "Project / Hourly Total:"
            '
            'LabelRateTerm_FeeRoyalty
            '
            Me.LabelRateTerm_FeeRoyalty.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRateTerm_FeeRoyalty.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRateTerm_FeeRoyalty.Location = New System.Drawing.Point(6, 124)
            Me.LabelRateTerm_FeeRoyalty.Name = "LabelRateTerm_FeeRoyalty"
            Me.LabelRateTerm_FeeRoyalty.Size = New System.Drawing.Size(121, 20)
            Me.LabelRateTerm_FeeRoyalty.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRateTerm_FeeRoyalty.TabIndex = 6
            Me.LabelRateTerm_FeeRoyalty.Text = "Fee Royalty:"
            '
            'LabelRateTerm_FeeIncentiveBonus
            '
            Me.LabelRateTerm_FeeIncentiveBonus.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRateTerm_FeeIncentiveBonus.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRateTerm_FeeIncentiveBonus.Location = New System.Drawing.Point(6, 98)
            Me.LabelRateTerm_FeeIncentiveBonus.Name = "LabelRateTerm_FeeIncentiveBonus"
            Me.LabelRateTerm_FeeIncentiveBonus.Size = New System.Drawing.Size(121, 20)
            Me.LabelRateTerm_FeeIncentiveBonus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRateTerm_FeeIncentiveBonus.TabIndex = 4
            Me.LabelRateTerm_FeeIncentiveBonus.Text = "Fee Incentive / Bonus:"
            '
            'LabelRateTerm_FeeRetainer
            '
            Me.LabelRateTerm_FeeRetainer.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRateTerm_FeeRetainer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRateTerm_FeeRetainer.Location = New System.Drawing.Point(6, 72)
            Me.LabelRateTerm_FeeRetainer.Name = "LabelRateTerm_FeeRetainer"
            Me.LabelRateTerm_FeeRetainer.Size = New System.Drawing.Size(121, 20)
            Me.LabelRateTerm_FeeRetainer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRateTerm_FeeRetainer.TabIndex = 1
            Me.LabelRateTerm_FeeRetainer.Text = "Fee / Retainer:"
            '
            'DataGridViewRateTerm_ContractFees
            '
            Me.DataGridViewRateTerm_ContractFees.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewRateTerm_ContractFees.AllowDragAndDrop = False
            Me.DataGridViewRateTerm_ContractFees.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewRateTerm_ContractFees.AllowSelectGroupHeaderRow = True
            Me.DataGridViewRateTerm_ContractFees.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewRateTerm_ContractFees.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRateTerm_ContractFees.AutoFilterLookupColumns = False
            Me.DataGridViewRateTerm_ContractFees.AutoloadRepositoryDatasource = True
            Me.DataGridViewRateTerm_ContractFees.AutoUpdateViewCaption = True
            Me.DataGridViewRateTerm_ContractFees.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewRateTerm_ContractFees.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewRateTerm_ContractFees.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRateTerm_ContractFees.ItemDescription = "Fee(s)"
            Me.DataGridViewRateTerm_ContractFees.Location = New System.Drawing.Point(6, 176)
            Me.DataGridViewRateTerm_ContractFees.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewRateTerm_ContractFees.MultiSelect = False
            Me.DataGridViewRateTerm_ContractFees.Name = "DataGridViewRateTerm_ContractFees"
            Me.DataGridViewRateTerm_ContractFees.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewRateTerm_ContractFees.RunStandardValidation = True
            Me.DataGridViewRateTerm_ContractFees.ShowColumnMenuOnRightClick = False
            Me.DataGridViewRateTerm_ContractFees.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRateTerm_ContractFees.Size = New System.Drawing.Size(590, 416)
            Me.DataGridViewRateTerm_ContractFees.TabIndex = 18
            Me.DataGridViewRateTerm_ContractFees.UseEmbeddedNavigator = False
            Me.DataGridViewRateTerm_ContractFees.ViewCaptionHeight = -1
            '
            'GroupBoxRateTerm_ContractType
            '
            Me.GroupBoxRateTerm_ContractType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxRateTerm_ContractType.Controls.Add(Me.NumericInputContractType_BlendedHourlyBillingRate)
            Me.GroupBoxRateTerm_ContractType.Controls.Add(Me.LabelContractType_BlendedHourlyBillingRate)
            Me.GroupBoxRateTerm_ContractType.Controls.Add(Me.CheckBoxContractType_Fee)
            Me.GroupBoxRateTerm_ContractType.Controls.Add(Me.CheckBoxContractType_ProjectHourly)
            Me.GroupBoxRateTerm_ContractType.Location = New System.Drawing.Point(6, 6)
            Me.GroupBoxRateTerm_ContractType.Name = "GroupBoxRateTerm_ContractType"
            Me.GroupBoxRateTerm_ContractType.Size = New System.Drawing.Size(590, 60)
            Me.GroupBoxRateTerm_ContractType.TabIndex = 0
            Me.GroupBoxRateTerm_ContractType.Text = "Contract Type"
            '
            'NumericInputContractType_BlendedHourlyBillingRate
            '
            Me.NumericInputContractType_BlendedHourlyBillingRate.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputContractType_BlendedHourlyBillingRate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputContractType_BlendedHourlyBillingRate.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputContractType_BlendedHourlyBillingRate.EnterMoveNextControl = True
            Me.NumericInputContractType_BlendedHourlyBillingRate.Location = New System.Drawing.Point(344, 24)
            Me.NumericInputContractType_BlendedHourlyBillingRate.Name = "NumericInputContractType_BlendedHourlyBillingRate"
            Me.NumericInputContractType_BlendedHourlyBillingRate.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputContractType_BlendedHourlyBillingRate.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputContractType_BlendedHourlyBillingRate.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputContractType_BlendedHourlyBillingRate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputContractType_BlendedHourlyBillingRate.Properties.EditFormat.FormatString = "f"
            Me.NumericInputContractType_BlendedHourlyBillingRate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputContractType_BlendedHourlyBillingRate.Properties.Mask.EditMask = "f"
            Me.NumericInputContractType_BlendedHourlyBillingRate.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputContractType_BlendedHourlyBillingRate.SecurityEnabled = True
            Me.NumericInputContractType_BlendedHourlyBillingRate.Size = New System.Drawing.Size(94, 20)
            Me.NumericInputContractType_BlendedHourlyBillingRate.TabIndex = 3
            '
            'LabelContractType_BlendedHourlyBillingRate
            '
            Me.LabelContractType_BlendedHourlyBillingRate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelContractType_BlendedHourlyBillingRate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelContractType_BlendedHourlyBillingRate.Location = New System.Drawing.Point(194, 24)
            Me.LabelContractType_BlendedHourlyBillingRate.Name = "LabelContractType_BlendedHourlyBillingRate"
            Me.LabelContractType_BlendedHourlyBillingRate.Size = New System.Drawing.Size(144, 20)
            Me.LabelContractType_BlendedHourlyBillingRate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelContractType_BlendedHourlyBillingRate.TabIndex = 2
            Me.LabelContractType_BlendedHourlyBillingRate.Text = "Blended Hourly Billing Rate:"
            '
            'CheckBoxContractType_Fee
            '
            Me.CheckBoxContractType_Fee.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxContractType_Fee.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxContractType_Fee.CheckValue = 0
            Me.CheckBoxContractType_Fee.CheckValueChecked = 1
            Me.CheckBoxContractType_Fee.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxContractType_Fee.CheckValueUnchecked = 0
            Me.CheckBoxContractType_Fee.ChildControls = CType(resources.GetObject("CheckBoxContractType_Fee.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxContractType_Fee.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxContractType_Fee.Location = New System.Drawing.Point(5, 24)
            Me.CheckBoxContractType_Fee.Name = "CheckBoxContractType_Fee"
            Me.CheckBoxContractType_Fee.OldestSibling = Nothing
            Me.CheckBoxContractType_Fee.SecurityEnabled = True
            Me.CheckBoxContractType_Fee.SiblingControls = CType(resources.GetObject("CheckBoxContractType_Fee.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxContractType_Fee.Size = New System.Drawing.Size(53, 20)
            Me.CheckBoxContractType_Fee.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxContractType_Fee.TabIndex = 0
            Me.CheckBoxContractType_Fee.TabOnEnter = True
            Me.CheckBoxContractType_Fee.Text = "Fee"
            '
            'CheckBoxContractType_ProjectHourly
            '
            Me.CheckBoxContractType_ProjectHourly.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxContractType_ProjectHourly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxContractType_ProjectHourly.CheckValue = 0
            Me.CheckBoxContractType_ProjectHourly.CheckValueChecked = 1
            Me.CheckBoxContractType_ProjectHourly.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxContractType_ProjectHourly.CheckValueUnchecked = 0
            Me.CheckBoxContractType_ProjectHourly.ChildControls = CType(resources.GetObject("CheckBoxContractType_ProjectHourly.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxContractType_ProjectHourly.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxContractType_ProjectHourly.Location = New System.Drawing.Point(64, 24)
            Me.CheckBoxContractType_ProjectHourly.Name = "CheckBoxContractType_ProjectHourly"
            Me.CheckBoxContractType_ProjectHourly.OldestSibling = Nothing
            Me.CheckBoxContractType_ProjectHourly.SecurityEnabled = True
            Me.CheckBoxContractType_ProjectHourly.SiblingControls = CType(resources.GetObject("CheckBoxContractType_ProjectHourly.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxContractType_ProjectHourly.Size = New System.Drawing.Size(102, 20)
            Me.CheckBoxContractType_ProjectHourly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxContractType_ProjectHourly.TabIndex = 1
            Me.CheckBoxContractType_ProjectHourly.TabOnEnter = True
            Me.CheckBoxContractType_ProjectHourly.Text = "Project / Hourly"
            '
            'TabItemContractSetup_RatesTermsTab
            '
            Me.TabItemContractSetup_RatesTermsTab.AttachedControl = Me.TabControlPanelRatesTerms_RatesTerms
            Me.TabItemContractSetup_RatesTermsTab.Name = "TabItemContractSetup_RatesTermsTab"
            Me.TabItemContractSetup_RatesTermsTab.Text = "Rates / Terms"
            '
            'LabelComments_Comments
            '
            Me.LabelComments_Comments.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelComments_Comments.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelComments_Comments.Location = New System.Drawing.Point(6, 444)
            Me.LabelComments_Comments.Name = "LabelComments_Comments"
            Me.LabelComments_Comments.Size = New System.Drawing.Size(119, 20)
            Me.LabelComments_Comments.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelComments_Comments.TabIndex = 6
            Me.LabelComments_Comments.Text = "Comments:"
            '
            'TextBoxComments_Comments
            '
            Me.TextBoxComments_Comments.AcceptsReturn = True
            Me.TextBoxComments_Comments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
            Me.TextBoxComments_Comments.Location = New System.Drawing.Point(131, 444)
            Me.TextBoxComments_Comments.MaxFileSize = CType(0, Long)
            Me.TextBoxComments_Comments.Multiline = True
            Me.TextBoxComments_Comments.Name = "TextBoxComments_Comments"
            Me.TextBoxComments_Comments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.TextBoxComments_Comments.SecurityEnabled = True
            Me.TextBoxComments_Comments.ShowSpellCheckCompleteMessage = True
            Me.TextBoxComments_Comments.Size = New System.Drawing.Size(465, 149)
            Me.TextBoxComments_Comments.StartingFolderName = Nothing
            Me.TextBoxComments_Comments.TabIndex = 7
            Me.TextBoxComments_Comments.TabOnEnter = True
            '
            'ContractControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.TabControlControl_ContractSetup)
            Me.Name = "ContractControl"
            Me.Size = New System.Drawing.Size(602, 623)
            CType(Me.TabControlControl_ContractSetup, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlControl_ContractSetup.ResumeLayout(False)
            Me.TabControlPanelReportsDocumentsTab_ReportsDocuments.ResumeLayout(False)
            Me.TabControlPanelDocumentsTab_Documents.ResumeLayout(False)
            Me.TabControlPanelValueAdded_ValueAdded.ResumeLayout(False)
            Me.TabControlPanelReportsTab_Reports.ResumeLayout(False)
            Me.TabControlPanelGeneral_General.ResumeLayout(False)
            CType(Me.SearchableComboBoxGeneral_Product.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewGeneral_Product, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxGeneral_Division.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewGeneral_Division, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxGeneral_Client.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewGeneral_Client, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerGeneral_EndDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerGeneral_StartDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxGeneral_COType, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxGeneral_COType.ResumeLayout(False)
            Me.TabControlPanelComments_Comments.ResumeLayout(False)
            Me.TabControlPanelContactsTab_Contacts.ResumeLayout(False)
            Me.TabControlPanelRatesTerms_RatesTerms.ResumeLayout(False)
            CType(Me.NumericInputRateTerms_Hours.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputRateTerms_TotalContractValue.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputRateTerms_ProductionCommission.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputRateTerms_MediaCommission.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputRateTerms_FeeProjectHourly.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputRateTerms_FeeRoyalty.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputRateTerms_FeeIncentiveBonus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputRateTerms_FeeRetainer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxRateTerm_ContractType, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxRateTerm_ContractType.ResumeLayout(False)
            CType(Me.NumericInputContractType_BlendedHourlyBillingRate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents TabControlControl_ContractSetup As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelGeneral_General As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemContractSetup_GeneralTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelDocumentsTab_Documents As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemContractSetup_DocumentsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents DocumentManagerControlDocuments_ContractDocuments As AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl
        Friend WithEvents TabControlPanelContactsTab_Contacts As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemContractSetup_InternalContactsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelRatesTerms_RatesTerms As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemContractSetup_RatesTermsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents AddressControlGeneral_Address As AdvantageFramework.WinForm.Presentation.Controls.AddressControl
        Friend WithEvents CheckBoxGeneral_NewBusiness As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelGeneral_Code As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGeneral_Client As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGeneral_Division As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxGeneral_Inactive As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents TextBoxGeneral_Code As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxGeneral_Description As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelGeneral_Name As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGeneralStartDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxGeneral_COType As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonCOType_Opportunity As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonCOType_Contract As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents LabelGeneralEndDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerGeneral_EndDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerGeneral_StartDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents TabControlPanelComments_Comments As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents LabelComments_BillingRateComment As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TabItemContractSetup_CommentsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents LabelComments_EstimatingTerms As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxComments_EstimatingTerms As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxComments_BillingTerms As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelComments_BillingTerms As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxComments_BillingRateComment As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents SearchableComboBoxGeneral_Division As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewGeneral_Division As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxGeneral_Client As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewGeneral_Client As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents GroupBoxRateTerm_ContractType As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents CheckBoxContractType_ProjectHourly As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelRateTerm_TotalContractValue As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelRateTerm_ProductCommission As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelRateTerm_MediaCommission As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelRateTerm_ProjectHourlyTotal As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelRateTerm_FeeRoyalty As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelRateTerm_FeeIncentiveBonus As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelRateTerm_FeeRetainer As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DataGridViewRateTerm_ContractFees As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents SearchableComboBoxGeneral_Product As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewGeneral_Product As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelGeneral_Product As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxContractType_Fee As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents NumericInputRateTerms_TotalContractValue As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputRateTerms_ProductionCommission As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputRateTerms_MediaCommission As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputRateTerms_FeeProjectHourly As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputRateTerms_FeeRoyalty As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputRateTerms_FeeIncentiveBonus As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputRateTerms_FeeRetainer As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents TabControlPanelValueAdded_ValueAdded As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemContractSetup_ValueAddedTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents DataGridViewValueAdded_ValueAdded As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewInternalContacts_Contacts As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TabControlPanelReportsTab_Reports As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemContractSetup_ReportsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents DataGridViewReports_Reports As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents NumericInputRateTerms_Hours As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents LabelRateTerm_Hours As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents NumericInputContractType_BlendedHourlyBillingRate As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents LabelContractType_BlendedHourlyBillingRate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonRateTerm_UpdateFeeRetainer As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents TabControlPanelReportsDocumentsTab_ReportsDocuments As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemContractSetup_ReportsDocumentsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents DocumentManagerControlReportsDocuments_ReportsDocuments As AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl
        Friend WithEvents LabelComments_Comments As Label
        Friend WithEvents TextBoxComments_Comments As TextBox
    End Class

End Namespace
