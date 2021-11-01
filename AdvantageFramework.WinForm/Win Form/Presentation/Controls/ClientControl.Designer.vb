Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class ClientControl
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClientControl))
            Me.TabControlControl_ClientDetails = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelGeneralTab_General = New DevComponents.DotNetBar.TabControlPanel()
            Me.LabelGeneral_QuickbooksCustomer = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxGeneral_QuickBooksCustomer = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView11 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.CheckBoxRightColumn_NewBusiness = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxRightColumn_Inactive = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TableLayoutPanelGeneral_General = New System.Windows.Forms.TableLayoutPanel()
            Me.PanelGeneral_TopLeftColumn = New System.Windows.Forms.Panel()
            Me.GroupBoxLeftColumn_NewClientOptions = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.SearchableComboBoxNewClientOptions_Office = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBox1View = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelNewClientOptions_Office = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxNewClientOptions_DuplicateForProduct = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxNewClientOptions_DuplicateForDivision = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.AddressControlLeftColumn_Address = New AdvantageFramework.WinForm.Presentation.Controls.AddressControl()
            Me.PanelGeneral_TopRightColumn = New System.Windows.Forms.Panel()
            Me.DataGridViewTopRightColumn_ClientSortKeys = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.LabelGeneral_Name = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxGeneral_Name = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelGeneral_Code = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxGeneral_Code = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TabItemClientDetails_GeneralTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelMediaIntegrationsSettingsTab_Settings = New DevComponents.DotNetBar.TabControlPanel()
            Me.CheckBoxMediaIntegrationSettings_EnableDoubleClick = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.NumericInputDoubleClick_ReportID = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputDoubleClick_ProfileID = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelDoubleClick_ReportID = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelDoubleClick_ProfileID = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemClientDetails_MediaIntegrationSettings = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelProductionTab_Production = New DevComponents.DotNetBar.TabControlPanel()
            Me.CheckBoxProduction_LimitTimeFunctionsToBillingHierarchy = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.SearchableComboBoxProduction_ClientDiscount = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView8 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelProduction_ClientDiscount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxProduction_ProductionEstimateFormat = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.LabelProductionEstimateFormat_StandardFormat = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelProductionEstimateFormat_Type = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxProductionEstimateFormat_Type = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.NumericInputProduction_DaysToPay = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.GroupBoxProduction_ProductionInvoiceFormat = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.SearchableComboBoxProductionInvoiceFormat_Format = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView1 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelProductionInvoiceFormat_StandardFormat = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelProductionInvoiceFormat_Format = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelProductionInvoiceFormat_Type = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxProductionInvoiceFormat_Type = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelProduction_DaysToPay = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelProduction_InvoiceFooterComments = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxProduction_InvoiceFooterComments = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelProduction_AttentionLine = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxProduction_AttentionLine = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.GroupBoxProduction_AssignProductionInvoicesBy = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.RadioButtonControlAssignProductionInvoicesBy_ProductClientPO = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlAssignProductionInvoicesBy_ProductSalesClass = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlAssignProductionInvoicesBy_Product = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlAssignProductionInvoicesBy_Job = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlAssignProductionInvoicesBy_Division = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlAssignProductionInvoicesBy_Client = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlAssignProductionInvoicesBy_JobComponent = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlAssignProductionInvoicesBy_Campaign = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TabItemClientDetails_ProductionTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelMediaTab_Media = New DevComponents.DotNetBar.TabControlPanel()
            Me.CheckBoxMedia_ClientResponsibleForMediaTrafficInstructions = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxNewClientOptions_TvUnitProductSplit = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.NumericInputMedia_DaysToPay = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelMedia_DaysToPay = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxMedia_AssignMediaInvoicesBy = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.RadioButtonControlAssignMediaInvoicesBy_OrderType = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlAssignMediaInvoicesBy_OrderNumber = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlAssignMediaInvoicesBy_Market = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlAssignMediaInvoicesBy_ClientPO = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlAssignMediaInvoicesBy_SalesClass = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlAssignMediaInvoicesBy_Campaign = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TextBoxMedia_AttentionLine = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelMedia_InvoiceFooterComments = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelMedia_AttentionLine = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxMedia_InvoiceFooterComments = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TabItemClientDetails_MediaTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelDivisionTab_Division = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelDivision_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ButtonRightSection_Delete = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonRightSection_Add = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonRightSection_Edit = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonRightSection_ProductCopy = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonItemProductCopy_From = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemProductCopy_To = New DevComponents.DotNetBar.ButtonItem()
            Me.DataGridViewRightSection_Products = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterControlDivision_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelDivision_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ButtonLeftSection_Delete = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonLeftSection_DivisionCopy = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonItemDivisionCopy_From = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemDivisionCopy_To = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonLeftSection_Edit = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonLeftSection_Add = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewLeftSection_Divisions = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemClientDetails_DivisionProductTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelAutomatedAssignmentsTab_AutomatedAssignments = New DevComponents.DotNetBar.TabControlPanel()
            Me.LabelAutomatedAssignments_Job = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxAutomatedAssignments_Job = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView10 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelAutomatedAssignments_JobComponent = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxAutomatedAssignments_JobComponent = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView9 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.TabItemClientDetails_AutomatedAssignmentsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelBillingTab_Billing = New DevComponents.DotNetBar.TabControlPanel()
            Me.GroupBoxBilling_LatePaymentFee = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.NumericInputLatePaymentFee_Percentage = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelLatePaymentFee_Percentage = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxLatePaymentFee_Calculate = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.GroupBoxBilling_ARComment = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.TextBoxARComment_ARComment = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.GroupBoxBilling_AssignComboInvoicesBy = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.RadioButtonControlAssignComboInvoicesBy_ClientDivision = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.CheckBoxAssignComboInvoicesBy_MediaOnly = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.RadioButtonControlAssignComboInvoicesBy_ClientDivisionProductCampaign = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlAssignComboInvoicesBy_ClientDivisionProduct = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlAssignComboInvoicesBy_Client = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlAssignComboInvoicesBy_ClientCampaign = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlAssignComboInvoicesBy_None = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.LabelBilling_Location = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxBilling_Avalara = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.TextBoxBilling_VATNumber = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelBilling_VATNumber = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxAvalara_TaxExempt = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.SearchableComboBoxAvalara_SalesClassCode = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboboxViewAvalara_SalesClass = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelAvalara_SalesClass = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxBilling_Options = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.ComboBoxOptions_Biller = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.DateTimePickerOptions_ContractExpirationDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelOptions_ContractExpirationDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelOptions_Biller = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxOptions_Currency = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelOptions_Currency = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.NumericInputOptions_CreditLimit = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelOptions_FiscalStartMonth = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxOptions_FiscalStartMonth = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelOptions_CreditLimit = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TableLayoutPanelBilling_AddressLayout = New System.Windows.Forms.TableLayoutPanel()
            Me.PanelAddressLayout_LeftColumn = New System.Windows.Forms.Panel()
            Me.ButtonLeftColumn_RefreshBilling = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonItemRefreshBilling_Address = New DevComponents.DotNetBar.ButtonItem()
            Me.AddressControlLeftColumn_BillingAddress = New AdvantageFramework.WinForm.Presentation.Controls.AddressControl()
            Me.PanelAddressLayout_RightColumn = New System.Windows.Forms.Panel()
            Me.AddressControlRightColumn_StatementAddress = New AdvantageFramework.WinForm.Presentation.Controls.AddressControl()
            Me.ButtonRightColumn_RefreshStatement = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonItemRefreshStatement_Address = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemRefreshStatement_Billing = New DevComponents.DotNetBar.ButtonItem()
            Me.SearchableComboBoxBilling_Location = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboboxGridViewBilling_Location = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.TabItemClientDetails_BillingTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelContactTab_Contacts = New DevComponents.DotNetBar.TabControlPanel()
            Me.ClientContactManagerControlContacts_ClientContacts = New AdvantageFramework.WinForm.Presentation.Controls.ClientContactManagerControl()
            Me.TabItemClientDetails_ContactsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelWebsiteTab_Websites = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewWebsites_Websites = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemClientDetails_WebsitesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelRequiredFieldsTab_RequiredFields = New DevComponents.DotNetBar.TabControlPanel()
            Me.GroupBoxRequiredFields_UserSelectedRequiredFields = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxRequiredFields_RequireTimeComments = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TableLayoutPanelUserSelectedRequiredFields_RequiredFields = New System.Windows.Forms.TableLayoutPanel()
            Me.PanelUserSelectedRequiredFields_RightColumn = New System.Windows.Forms.Panel()
            Me.CheckBoxRightColumn_JobComponentCustom5 = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxRightColumn_JobLogCustom1 = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxRightColumn_JobComponentCustom4 = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxRightColumn_JobLogCustom2 = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxRightColumn_JobComponentCustom3 = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxRightColumn_JobLogCustom3 = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxRightColumn_JobComponentCustom2 = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxRightColumn_JobLogCustom4 = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxRightColumn_JobComponentCustom1 = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxRightColumn_JobLogCustom5 = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.PanelUserSelectedRequiredFields_MiddleColumn = New System.Windows.Forms.Panel()
            Me.CheckBoxMiddleColumn_ServiceFeeType = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMiddleColumn_DeptTeam = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxLeftColumn_DateOpened = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMiddleColumn_JobType = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMiddleColumn_Promotion = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMiddleColumn_FormatAdSize = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMiddleColumn_DueDate = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMiddleColumn_MarketCode = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMiddleColumn_SCFormat = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.PanelUserSelectedRequiredFields_LeftColumn = New System.Windows.Forms.Panel()
            Me.CheckBoxLeftColumn_Blackplate2 = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxLeftColumn_Blackplate1 = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxLeftColumn_ComponentBudget = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMiddleColumn_ProductContact = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxLeftColumn_ClientReference = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxLeftColumn_AdNumber = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxLeftColumn_CoopBillingCode = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxLeftColumn_AlertGroup = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxLeftColumn_ComplexityCode = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxLeftColumn_AccountNumber = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxUserSelectedRequiredFields_OverrideAgencySettings = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxRequiredFields_RequireProductCategorySelectionInTimesheet = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.GroupBoxUserSelectedRequiredFields_JobsAndMedia = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxJobsAndMedia_FiscalPeriod = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxJobsAndMedia_CampaignCode = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TabItemClientDetails_RequiredFieldsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelClientDetails_MediaInvoiceFormat = New DevComponents.DotNetBar.TabControlPanel()
            Me.GroupBoxMediaInvoiceFormat_Radio = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.LabelRadioInvoiceFormat_Note = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxRadioInvoiceFormat_Format = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView6 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelRadioInvoiceFormat_Format = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelRadioInvoiceFormat_Type = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxRadioInvoiceFormat_Type = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.GroupBoxMediaInvoiceFormat_Newspaper = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.LabelNewspaperInvoiceFormat_Note = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelNewspaperInvoiceFormat_Format = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelNewspaperInvoiceFormat_Type = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxNewspaperInvoiceFormat_Type = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.SearchableComboBoxNewspaperInvoiceFormat_Format = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView3 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.GroupBoxMediaInvoiceFormat_OutOfHome = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.LabelOutOfHomeInvoiceFormat_Note = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelOutOfHomeInvoiceFormat_Format = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxOutOfHomeInvoiceFormat_Format = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView5 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelOutOfHomeInvoiceFormat_Type = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxOutOfHomeInvoiceFormat_Type = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.GroupBoxMediaInvoiceFormat_Magazine = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.LabelMagazineInvoiceFormat_Note = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelMagazineInvoiceFormat_Format = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelMagazineInvoiceFormat_Type = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxMagazineInvoiceFormat_Type = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.SearchableComboBoxMagazineInvoiceFormat_Format = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView2 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.GroupBoxMediaInvoiceFormat_Internet = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.LabelInternetInvoiceFormat_Note = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelInternetInvoiceFormat_Format = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelInternetInvoiceFormat_Type = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxInternetInvoiceFormat_Format = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView4 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.ComboBoxInternetInvoiceFormat_Type = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.GroupBoxMediaInvoiceFormat_TV = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.SearchableComboBoxTVInvoiceFormat_Format = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView7 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelTelevsionInvoiceFormat_Note = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTelevisionInvoiceFormat_Format = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTelevisionInvoiceFormat_Type = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxTVInvoiceFormat_Type = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.TabItemClientDetails_MediaInvoiceFormatTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelContractTab_Contracts = New DevComponents.DotNetBar.TabControlPanel()
            Me.ContractManagerControlContractTab_Contracts = New AdvantageFramework.WinForm.Presentation.Controls.ContractManagerControl()
            Me.TabItemClientDetails_ContractsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelDocumentsTab_Documents = New DevComponents.DotNetBar.TabControlPanel()
            Me.DocumentManagerControlDocuments_ClientDocuments = New AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl()
            Me.TabItemClientDetails_DocumentsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            CType(Me.TabControlControl_ClientDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlControl_ClientDetails.SuspendLayout()
            Me.TabControlPanelGeneralTab_General.SuspendLayout()
            CType(Me.SearchableComboBoxGeneral_QuickBooksCustomer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView11, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TableLayoutPanelGeneral_General.SuspendLayout()
            Me.PanelGeneral_TopLeftColumn.SuspendLayout()
            CType(Me.GroupBoxLeftColumn_NewClientOptions, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxLeftColumn_NewClientOptions.SuspendLayout()
            CType(Me.SearchableComboBoxNewClientOptions_Office.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBox1View, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelGeneral_TopRightColumn.SuspendLayout()
            Me.TabControlPanelMediaIntegrationsSettingsTab_Settings.SuspendLayout()
            CType(Me.NumericInputDoubleClick_ReportID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputDoubleClick_ProfileID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelProductionTab_Production.SuspendLayout()
            CType(Me.SearchableComboBoxProduction_ClientDiscount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView8, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxProduction_ProductionEstimateFormat, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxProduction_ProductionEstimateFormat.SuspendLayout()
            CType(Me.NumericInputProduction_DaysToPay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxProduction_ProductionInvoiceFormat, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxProduction_ProductionInvoiceFormat.SuspendLayout()
            CType(Me.SearchableComboBoxProductionInvoiceFormat_Format.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxProduction_AssignProductionInvoicesBy, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxProduction_AssignProductionInvoicesBy.SuspendLayout()
            Me.TabControlPanelMediaTab_Media.SuspendLayout()
            CType(Me.NumericInputMedia_DaysToPay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxMedia_AssignMediaInvoicesBy, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxMedia_AssignMediaInvoicesBy.SuspendLayout()
            Me.TabControlPanelDivisionTab_Division.SuspendLayout()
            CType(Me.PanelDivision_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelDivision_RightSection.SuspendLayout()
            CType(Me.PanelDivision_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelDivision_LeftSection.SuspendLayout()
            Me.TabControlPanelAutomatedAssignmentsTab_AutomatedAssignments.SuspendLayout()
            CType(Me.SearchableComboBoxAutomatedAssignments_Job.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView10, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxAutomatedAssignments_JobComponent.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView9, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelBillingTab_Billing.SuspendLayout()
            CType(Me.GroupBoxBilling_LatePaymentFee, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxBilling_LatePaymentFee.SuspendLayout()
            CType(Me.NumericInputLatePaymentFee_Percentage.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxBilling_ARComment, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxBilling_ARComment.SuspendLayout()
            CType(Me.GroupBoxBilling_AssignComboInvoicesBy, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxBilling_AssignComboInvoicesBy.SuspendLayout()
            CType(Me.GroupBoxBilling_Avalara, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxBilling_Avalara.SuspendLayout()
            CType(Me.SearchableComboBoxAvalara_SalesClassCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboboxViewAvalara_SalesClass, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxBilling_Options, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxBilling_Options.SuspendLayout()
            CType(Me.DateTimePickerOptions_ContractExpirationDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputOptions_CreditLimit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TableLayoutPanelBilling_AddressLayout.SuspendLayout()
            Me.PanelAddressLayout_LeftColumn.SuspendLayout()
            Me.PanelAddressLayout_RightColumn.SuspendLayout()
            CType(Me.SearchableComboBoxBilling_Location.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboboxGridViewBilling_Location, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelContactTab_Contacts.SuspendLayout()
            Me.TabControlPanelWebsiteTab_Websites.SuspendLayout()
            Me.TabControlPanelRequiredFieldsTab_RequiredFields.SuspendLayout()
            CType(Me.GroupBoxRequiredFields_UserSelectedRequiredFields, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxRequiredFields_UserSelectedRequiredFields.SuspendLayout()
            Me.TableLayoutPanelUserSelectedRequiredFields_RequiredFields.SuspendLayout()
            Me.PanelUserSelectedRequiredFields_RightColumn.SuspendLayout()
            Me.PanelUserSelectedRequiredFields_MiddleColumn.SuspendLayout()
            Me.PanelUserSelectedRequiredFields_LeftColumn.SuspendLayout()
            CType(Me.GroupBoxUserSelectedRequiredFields_JobsAndMedia, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxUserSelectedRequiredFields_JobsAndMedia.SuspendLayout()
            Me.TabControlPanelClientDetails_MediaInvoiceFormat.SuspendLayout()
            CType(Me.GroupBoxMediaInvoiceFormat_Radio, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxMediaInvoiceFormat_Radio.SuspendLayout()
            CType(Me.SearchableComboBoxRadioInvoiceFormat_Format.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView6, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxMediaInvoiceFormat_Newspaper, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxMediaInvoiceFormat_Newspaper.SuspendLayout()
            CType(Me.SearchableComboBoxNewspaperInvoiceFormat_Format.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxMediaInvoiceFormat_OutOfHome, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxMediaInvoiceFormat_OutOfHome.SuspendLayout()
            CType(Me.SearchableComboBoxOutOfHomeInvoiceFormat_Format.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxMediaInvoiceFormat_Magazine, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxMediaInvoiceFormat_Magazine.SuspendLayout()
            CType(Me.SearchableComboBoxMagazineInvoiceFormat_Format.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxMediaInvoiceFormat_Internet, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxMediaInvoiceFormat_Internet.SuspendLayout()
            CType(Me.SearchableComboBoxInternetInvoiceFormat_Format.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxMediaInvoiceFormat_TV, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxMediaInvoiceFormat_TV.SuspendLayout()
            CType(Me.SearchableComboBoxTVInvoiceFormat_Format.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView7, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelContractTab_Contracts.SuspendLayout()
            Me.TabControlPanelDocumentsTab_Documents.SuspendLayout()
            Me.SuspendLayout()
            '
            'TabControlControl_ClientDetails
            '
            Me.TabControlControl_ClientDetails.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
            Me.TabControlControl_ClientDetails.CanReorderTabs = True
            Me.TabControlControl_ClientDetails.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlControl_ClientDetails.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlControl_ClientDetails.Controls.Add(Me.TabControlPanelGeneralTab_General)
            Me.TabControlControl_ClientDetails.Controls.Add(Me.TabControlPanelMediaIntegrationsSettingsTab_Settings)
            Me.TabControlControl_ClientDetails.Controls.Add(Me.TabControlPanelProductionTab_Production)
            Me.TabControlControl_ClientDetails.Controls.Add(Me.TabControlPanelMediaTab_Media)
            Me.TabControlControl_ClientDetails.Controls.Add(Me.TabControlPanelDivisionTab_Division)
            Me.TabControlControl_ClientDetails.Controls.Add(Me.TabControlPanelAutomatedAssignmentsTab_AutomatedAssignments)
            Me.TabControlControl_ClientDetails.Controls.Add(Me.TabControlPanelBillingTab_Billing)
            Me.TabControlControl_ClientDetails.Controls.Add(Me.TabControlPanelContactTab_Contacts)
            Me.TabControlControl_ClientDetails.Controls.Add(Me.TabControlPanelWebsiteTab_Websites)
            Me.TabControlControl_ClientDetails.Controls.Add(Me.TabControlPanelRequiredFieldsTab_RequiredFields)
            Me.TabControlControl_ClientDetails.Controls.Add(Me.TabControlPanelClientDetails_MediaInvoiceFormat)
            Me.TabControlControl_ClientDetails.Controls.Add(Me.TabControlPanelContractTab_Contracts)
            Me.TabControlControl_ClientDetails.Controls.Add(Me.TabControlPanelDocumentsTab_Documents)
            Me.TabControlControl_ClientDetails.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlControl_ClientDetails.ForeColor = System.Drawing.Color.Black
            Me.TabControlControl_ClientDetails.Location = New System.Drawing.Point(0, 0)
            Me.TabControlControl_ClientDetails.Name = "TabControlControl_ClientDetails"
            Me.TabControlControl_ClientDetails.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlControl_ClientDetails.SelectedTabIndex = 0
            Me.TabControlControl_ClientDetails.Size = New System.Drawing.Size(845, 532)
            Me.TabControlControl_ClientDetails.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlControl_ClientDetails.TabIndex = 1
            Me.TabControlControl_ClientDetails.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlControl_ClientDetails.Tabs.Add(Me.TabItemClientDetails_GeneralTab)
            Me.TabControlControl_ClientDetails.Tabs.Add(Me.TabItemClientDetails_BillingTab)
            Me.TabControlControl_ClientDetails.Tabs.Add(Me.TabItemClientDetails_ProductionTab)
            Me.TabControlControl_ClientDetails.Tabs.Add(Me.TabItemClientDetails_MediaTab)
            Me.TabControlControl_ClientDetails.Tabs.Add(Me.TabItemClientDetails_MediaIntegrationSettings)
            Me.TabControlControl_ClientDetails.Tabs.Add(Me.TabItemClientDetails_MediaInvoiceFormatTab)
            Me.TabControlControl_ClientDetails.Tabs.Add(Me.TabItemClientDetails_RequiredFieldsTab)
            Me.TabControlControl_ClientDetails.Tabs.Add(Me.TabItemClientDetails_WebsitesTab)
            Me.TabControlControl_ClientDetails.Tabs.Add(Me.TabItemClientDetails_ContactsTab)
            Me.TabControlControl_ClientDetails.Tabs.Add(Me.TabItemClientDetails_ContractsTab)
            Me.TabControlControl_ClientDetails.Tabs.Add(Me.TabItemClientDetails_DocumentsTab)
            Me.TabControlControl_ClientDetails.Tabs.Add(Me.TabItemClientDetails_AutomatedAssignmentsTab)
            Me.TabControlControl_ClientDetails.Tabs.Add(Me.TabItemClientDetails_DivisionProductTab)
            '
            'TabControlPanelGeneralTab_General
            '
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_QuickbooksCustomer)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.SearchableComboBoxGeneral_QuickBooksCustomer)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.CheckBoxRightColumn_NewBusiness)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.CheckBoxRightColumn_Inactive)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.TableLayoutPanelGeneral_General)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_Name)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.TextBoxGeneral_Name)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_Code)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.TextBoxGeneral_Code)
            Me.TabControlPanelGeneralTab_General.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelGeneralTab_General.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelGeneralTab_General.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelGeneralTab_General.Name = "TabControlPanelGeneralTab_General"
            Me.TabControlPanelGeneralTab_General.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelGeneralTab_General.Size = New System.Drawing.Size(845, 505)
            Me.TabControlPanelGeneralTab_General.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelGeneralTab_General.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelGeneralTab_General.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelGeneralTab_General.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelGeneralTab_General.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelGeneralTab_General.Style.GradientAngle = 90
            Me.TabControlPanelGeneralTab_General.TabIndex = 0
            Me.TabControlPanelGeneralTab_General.TabItem = Me.TabItemClientDetails_GeneralTab
            '
            'LabelGeneral_QuickbooksCustomer
            '
            Me.LabelGeneral_QuickbooksCustomer.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_QuickbooksCustomer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_QuickbooksCustomer.Location = New System.Drawing.Point(256, 6)
            Me.LabelGeneral_QuickbooksCustomer.Name = "LabelGeneral_QuickbooksCustomer"
            Me.LabelGeneral_QuickbooksCustomer.Size = New System.Drawing.Size(121, 20)
            Me.LabelGeneral_QuickbooksCustomer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_QuickbooksCustomer.TabIndex = 11
            Me.LabelGeneral_QuickbooksCustomer.Text = "QuickBooks Customer:"
            '
            'SearchableComboBoxGeneral_QuickBooksCustomer
            '
            Me.SearchableComboBoxGeneral_QuickBooksCustomer.ActiveFilterString = ""
            Me.SearchableComboBoxGeneral_QuickBooksCustomer.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxGeneral_QuickBooksCustomer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxGeneral_QuickBooksCustomer.AutoFillMode = False
            Me.SearchableComboBoxGeneral_QuickBooksCustomer.BookmarkingEnabled = False
            Me.SearchableComboBoxGeneral_QuickBooksCustomer.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.QuickbookCustomer
            Me.SearchableComboBoxGeneral_QuickBooksCustomer.DataSource = Nothing
            Me.SearchableComboBoxGeneral_QuickBooksCustomer.DisableMouseWheel = False
            Me.SearchableComboBoxGeneral_QuickBooksCustomer.DisplayName = ""
            Me.SearchableComboBoxGeneral_QuickBooksCustomer.EnterMoveNextControl = True
            Me.SearchableComboBoxGeneral_QuickBooksCustomer.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxGeneral_QuickBooksCustomer.Location = New System.Drawing.Point(383, 6)
            Me.SearchableComboBoxGeneral_QuickBooksCustomer.Name = "SearchableComboBoxGeneral_QuickBooksCustomer"
            Me.SearchableComboBoxGeneral_QuickBooksCustomer.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxGeneral_QuickBooksCustomer.Properties.DisplayMember = "DisplayName"
            Me.SearchableComboBoxGeneral_QuickBooksCustomer.Properties.NullText = "Select Customer"
            Me.SearchableComboBoxGeneral_QuickBooksCustomer.Properties.PopupView = Me.GridView11
            Me.SearchableComboBoxGeneral_QuickBooksCustomer.Properties.ValueMember = "ID"
            Me.SearchableComboBoxGeneral_QuickBooksCustomer.SecurityEnabled = True
            Me.SearchableComboBoxGeneral_QuickBooksCustomer.SelectedValue = Nothing
            Me.SearchableComboBoxGeneral_QuickBooksCustomer.Size = New System.Drawing.Size(456, 20)
            Me.SearchableComboBoxGeneral_QuickBooksCustomer.TabIndex = 10
            '
            'GridView11
            '
            Me.GridView11.AFActiveFilterString = ""
            Me.GridView11.AllowExtraItemsInGridLookupEdits = True
            Me.GridView11.AutoFilterLookupColumns = False
            Me.GridView11.AutoloadRepositoryDatasource = True
            Me.GridView11.DataSourceClearing = False
            Me.GridView11.EnableDisabledRows = False
            Me.GridView11.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView11.Name = "GridView11"
            Me.GridView11.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView11.OptionsView.ShowGroupPanel = False
            Me.GridView11.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView11.RunStandardValidation = True
            Me.GridView11.SkipAddingControlsOnModifyColumn = False
            Me.GridView11.SkipSettingFontOnModifyColumn = False
            '
            'CheckBoxRightColumn_NewBusiness
            '
            Me.CheckBoxRightColumn_NewBusiness.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxRightColumn_NewBusiness.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxRightColumn_NewBusiness.CheckValue = 0
            Me.CheckBoxRightColumn_NewBusiness.CheckValueChecked = 1
            Me.CheckBoxRightColumn_NewBusiness.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxRightColumn_NewBusiness.CheckValueUnchecked = 0
            Me.CheckBoxRightColumn_NewBusiness.ChildControls = CType(resources.GetObject("CheckBoxRightColumn_NewBusiness.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRightColumn_NewBusiness.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxRightColumn_NewBusiness.Location = New System.Drawing.Point(150, 4)
            Me.CheckBoxRightColumn_NewBusiness.Name = "CheckBoxRightColumn_NewBusiness"
            Me.CheckBoxRightColumn_NewBusiness.OldestSibling = Nothing
            Me.CheckBoxRightColumn_NewBusiness.SecurityEnabled = True
            Me.CheckBoxRightColumn_NewBusiness.SiblingControls = CType(resources.GetObject("CheckBoxRightColumn_NewBusiness.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRightColumn_NewBusiness.Size = New System.Drawing.Size(100, 20)
            Me.CheckBoxRightColumn_NewBusiness.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxRightColumn_NewBusiness.TabIndex = 2
            Me.CheckBoxRightColumn_NewBusiness.TabOnEnter = True
            Me.CheckBoxRightColumn_NewBusiness.Text = "New Business"
            '
            'CheckBoxRightColumn_Inactive
            '
            Me.CheckBoxRightColumn_Inactive.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxRightColumn_Inactive.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxRightColumn_Inactive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxRightColumn_Inactive.CheckValue = 0
            Me.CheckBoxRightColumn_Inactive.CheckValueChecked = 1
            Me.CheckBoxRightColumn_Inactive.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxRightColumn_Inactive.CheckValueUnchecked = 0
            Me.CheckBoxRightColumn_Inactive.ChildControls = CType(resources.GetObject("CheckBoxRightColumn_Inactive.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRightColumn_Inactive.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxRightColumn_Inactive.Location = New System.Drawing.Point(773, 30)
            Me.CheckBoxRightColumn_Inactive.Name = "CheckBoxRightColumn_Inactive"
            Me.CheckBoxRightColumn_Inactive.OldestSibling = Nothing
            Me.CheckBoxRightColumn_Inactive.SecurityEnabled = True
            Me.CheckBoxRightColumn_Inactive.SiblingControls = CType(resources.GetObject("CheckBoxRightColumn_Inactive.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRightColumn_Inactive.Size = New System.Drawing.Size(66, 20)
            Me.CheckBoxRightColumn_Inactive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxRightColumn_Inactive.TabIndex = 5
            Me.CheckBoxRightColumn_Inactive.TabOnEnter = True
            Me.CheckBoxRightColumn_Inactive.Text = "Inactive"
            '
            'TableLayoutPanelGeneral_General
            '
            Me.TableLayoutPanelGeneral_General.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TableLayoutPanelGeneral_General.BackColor = System.Drawing.Color.White
            Me.TableLayoutPanelGeneral_General.ColumnCount = 2
            Me.TableLayoutPanelGeneral_General.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanelGeneral_General.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanelGeneral_General.Controls.Add(Me.PanelGeneral_TopLeftColumn, 0, 0)
            Me.TableLayoutPanelGeneral_General.Controls.Add(Me.PanelGeneral_TopRightColumn, 1, 0)
            Me.TableLayoutPanelGeneral_General.Location = New System.Drawing.Point(6, 56)
            Me.TableLayoutPanelGeneral_General.Name = "TableLayoutPanelGeneral_General"
            Me.TableLayoutPanelGeneral_General.RowCount = 1
            Me.TableLayoutPanelGeneral_General.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 59.11458!))
            Me.TableLayoutPanelGeneral_General.Size = New System.Drawing.Size(833, 301)
            Me.TableLayoutPanelGeneral_General.TabIndex = 8
            '
            'PanelGeneral_TopLeftColumn
            '
            Me.PanelGeneral_TopLeftColumn.Controls.Add(Me.GroupBoxLeftColumn_NewClientOptions)
            Me.PanelGeneral_TopLeftColumn.Controls.Add(Me.AddressControlLeftColumn_Address)
            Me.PanelGeneral_TopLeftColumn.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelGeneral_TopLeftColumn.Location = New System.Drawing.Point(0, 0)
            Me.PanelGeneral_TopLeftColumn.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelGeneral_TopLeftColumn.Name = "PanelGeneral_TopLeftColumn"
            Me.PanelGeneral_TopLeftColumn.Size = New System.Drawing.Size(416, 301)
            Me.PanelGeneral_TopLeftColumn.TabIndex = 1
            '
            'GroupBoxLeftColumn_NewClientOptions
            '
            Me.GroupBoxLeftColumn_NewClientOptions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxLeftColumn_NewClientOptions.Controls.Add(Me.SearchableComboBoxNewClientOptions_Office)
            Me.GroupBoxLeftColumn_NewClientOptions.Controls.Add(Me.LabelNewClientOptions_Office)
            Me.GroupBoxLeftColumn_NewClientOptions.Controls.Add(Me.CheckBoxNewClientOptions_DuplicateForProduct)
            Me.GroupBoxLeftColumn_NewClientOptions.Controls.Add(Me.CheckBoxNewClientOptions_DuplicateForDivision)
            Me.GroupBoxLeftColumn_NewClientOptions.Location = New System.Drawing.Point(6, 186)
            Me.GroupBoxLeftColumn_NewClientOptions.Name = "GroupBoxLeftColumn_NewClientOptions"
            Me.GroupBoxLeftColumn_NewClientOptions.Size = New System.Drawing.Size(407, 105)
            Me.GroupBoxLeftColumn_NewClientOptions.TabIndex = 2
            Me.GroupBoxLeftColumn_NewClientOptions.Text = "New Client Options"
            '
            'SearchableComboBoxNewClientOptions_Office
            '
            Me.SearchableComboBoxNewClientOptions_Office.ActiveFilterString = ""
            Me.SearchableComboBoxNewClientOptions_Office.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxNewClientOptions_Office.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxNewClientOptions_Office.AutoFillMode = False
            Me.SearchableComboBoxNewClientOptions_Office.BookmarkingEnabled = False
            Me.SearchableComboBoxNewClientOptions_Office.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Office
            Me.SearchableComboBoxNewClientOptions_Office.DataSource = Nothing
            Me.SearchableComboBoxNewClientOptions_Office.DisableMouseWheel = False
            Me.SearchableComboBoxNewClientOptions_Office.DisplayName = ""
            Me.SearchableComboBoxNewClientOptions_Office.EnterMoveNextControl = True
            Me.SearchableComboBoxNewClientOptions_Office.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxNewClientOptions_Office.Location = New System.Drawing.Point(57, 77)
            Me.SearchableComboBoxNewClientOptions_Office.Name = "SearchableComboBoxNewClientOptions_Office"
            Me.SearchableComboBoxNewClientOptions_Office.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxNewClientOptions_Office.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxNewClientOptions_Office.Properties.NullText = "Select Office"
            Me.SearchableComboBoxNewClientOptions_Office.Properties.PopupView = Me.SearchableComboBox1View
            Me.SearchableComboBoxNewClientOptions_Office.Properties.ValueMember = "Code"
            Me.SearchableComboBoxNewClientOptions_Office.SecurityEnabled = True
            Me.SearchableComboBoxNewClientOptions_Office.SelectedValue = Nothing
            Me.SearchableComboBoxNewClientOptions_Office.Size = New System.Drawing.Size(345, 20)
            Me.SearchableComboBoxNewClientOptions_Office.TabIndex = 4
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
            Me.SearchableComboBox1View.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboBox1View.SkipSettingFontOnModifyColumn = False
            '
            'LabelNewClientOptions_Office
            '
            Me.LabelNewClientOptions_Office.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelNewClientOptions_Office.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelNewClientOptions_Office.Location = New System.Drawing.Point(6, 77)
            Me.LabelNewClientOptions_Office.Name = "LabelNewClientOptions_Office"
            Me.LabelNewClientOptions_Office.Size = New System.Drawing.Size(45, 20)
            Me.LabelNewClientOptions_Office.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelNewClientOptions_Office.TabIndex = 3
            Me.LabelNewClientOptions_Office.Text = "Office:"
            '
            'CheckBoxNewClientOptions_DuplicateForProduct
            '
            Me.CheckBoxNewClientOptions_DuplicateForProduct.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxNewClientOptions_DuplicateForProduct.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxNewClientOptions_DuplicateForProduct.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxNewClientOptions_DuplicateForProduct.CheckValue = 0
            Me.CheckBoxNewClientOptions_DuplicateForProduct.CheckValueChecked = 1
            Me.CheckBoxNewClientOptions_DuplicateForProduct.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxNewClientOptions_DuplicateForProduct.CheckValueUnchecked = 0
            Me.CheckBoxNewClientOptions_DuplicateForProduct.ChildControls = CType(resources.GetObject("CheckBoxNewClientOptions_DuplicateForProduct.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxNewClientOptions_DuplicateForProduct.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxNewClientOptions_DuplicateForProduct.Location = New System.Drawing.Point(6, 51)
            Me.CheckBoxNewClientOptions_DuplicateForProduct.Name = "CheckBoxNewClientOptions_DuplicateForProduct"
            Me.CheckBoxNewClientOptions_DuplicateForProduct.OldestSibling = Nothing
            Me.CheckBoxNewClientOptions_DuplicateForProduct.SecurityEnabled = True
            Me.CheckBoxNewClientOptions_DuplicateForProduct.SiblingControls = CType(resources.GetObject("CheckBoxNewClientOptions_DuplicateForProduct.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxNewClientOptions_DuplicateForProduct.Size = New System.Drawing.Size(396, 20)
            Me.CheckBoxNewClientOptions_DuplicateForProduct.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxNewClientOptions_DuplicateForProduct.TabIndex = 2
            Me.CheckBoxNewClientOptions_DuplicateForProduct.TabOnEnter = True
            Me.CheckBoxNewClientOptions_DuplicateForProduct.Text = "Duplicate for Product"
            '
            'CheckBoxNewClientOptions_DuplicateForDivision
            '
            Me.CheckBoxNewClientOptions_DuplicateForDivision.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxNewClientOptions_DuplicateForDivision.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxNewClientOptions_DuplicateForDivision.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxNewClientOptions_DuplicateForDivision.CheckValue = 0
            Me.CheckBoxNewClientOptions_DuplicateForDivision.CheckValueChecked = 1
            Me.CheckBoxNewClientOptions_DuplicateForDivision.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxNewClientOptions_DuplicateForDivision.CheckValueUnchecked = 0
            Me.CheckBoxNewClientOptions_DuplicateForDivision.ChildControls = CType(resources.GetObject("CheckBoxNewClientOptions_DuplicateForDivision.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxNewClientOptions_DuplicateForDivision.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxNewClientOptions_DuplicateForDivision.Location = New System.Drawing.Point(6, 25)
            Me.CheckBoxNewClientOptions_DuplicateForDivision.Name = "CheckBoxNewClientOptions_DuplicateForDivision"
            Me.CheckBoxNewClientOptions_DuplicateForDivision.OldestSibling = Nothing
            Me.CheckBoxNewClientOptions_DuplicateForDivision.SecurityEnabled = True
            Me.CheckBoxNewClientOptions_DuplicateForDivision.SiblingControls = CType(resources.GetObject("CheckBoxNewClientOptions_DuplicateForDivision.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxNewClientOptions_DuplicateForDivision.Size = New System.Drawing.Size(396, 20)
            Me.CheckBoxNewClientOptions_DuplicateForDivision.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxNewClientOptions_DuplicateForDivision.TabIndex = 1
            Me.CheckBoxNewClientOptions_DuplicateForDivision.TabOnEnter = True
            Me.CheckBoxNewClientOptions_DuplicateForDivision.Text = "Duplicate for Division"
            '
            'AddressControlLeftColumn_Address
            '
            Me.AddressControlLeftColumn_Address.Address = Nothing
            Me.AddressControlLeftColumn_Address.Address2 = Nothing
            Me.AddressControlLeftColumn_Address.Address3 = Nothing
            Me.AddressControlLeftColumn_Address.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.AddressControlLeftColumn_Address.City = Nothing
            Me.AddressControlLeftColumn_Address.Country = Nothing
            Me.AddressControlLeftColumn_Address.County = Nothing
            Me.AddressControlLeftColumn_Address.DisableCountry = False
            Me.AddressControlLeftColumn_Address.DisableCounty = False
            Me.AddressControlLeftColumn_Address.Location = New System.Drawing.Point(6, 0)
            Me.AddressControlLeftColumn_Address.Name = "AddressControlLeftColumn_Address"
            Me.AddressControlLeftColumn_Address.ReadOnly = False
            Me.AddressControlLeftColumn_Address.ShowCountry = True
            Me.AddressControlLeftColumn_Address.ShowCounty = True
            Me.AddressControlLeftColumn_Address.Size = New System.Drawing.Size(407, 181)
            Me.AddressControlLeftColumn_Address.State = Nothing
            Me.AddressControlLeftColumn_Address.TabIndex = 1
            Me.AddressControlLeftColumn_Address.Title = "Address"
            Me.AddressControlLeftColumn_Address.Zip = Nothing
            '
            'PanelGeneral_TopRightColumn
            '
            Me.PanelGeneral_TopRightColumn.Controls.Add(Me.DataGridViewTopRightColumn_ClientSortKeys)
            Me.PanelGeneral_TopRightColumn.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelGeneral_TopRightColumn.Location = New System.Drawing.Point(416, 0)
            Me.PanelGeneral_TopRightColumn.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelGeneral_TopRightColumn.Name = "PanelGeneral_TopRightColumn"
            Me.PanelGeneral_TopRightColumn.Size = New System.Drawing.Size(417, 301)
            Me.PanelGeneral_TopRightColumn.TabIndex = 2
            '
            'DataGridViewTopRightColumn_ClientSortKeys
            '
            Me.DataGridViewTopRightColumn_ClientSortKeys.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewTopRightColumn_ClientSortKeys.AllowDragAndDrop = False
            Me.DataGridViewTopRightColumn_ClientSortKeys.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewTopRightColumn_ClientSortKeys.AllowSelectGroupHeaderRow = True
            Me.DataGridViewTopRightColumn_ClientSortKeys.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewTopRightColumn_ClientSortKeys.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewTopRightColumn_ClientSortKeys.AutoFilterLookupColumns = False
            Me.DataGridViewTopRightColumn_ClientSortKeys.AutoloadRepositoryDatasource = True
            Me.DataGridViewTopRightColumn_ClientSortKeys.AutoUpdateViewCaption = True
            Me.DataGridViewTopRightColumn_ClientSortKeys.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewTopRightColumn_ClientSortKeys.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewTopRightColumn_ClientSortKeys.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewTopRightColumn_ClientSortKeys.ItemDescription = "Sort Option(s)"
            Me.DataGridViewTopRightColumn_ClientSortKeys.Location = New System.Drawing.Point(3, 4)
            Me.DataGridViewTopRightColumn_ClientSortKeys.MultiSelect = True
            Me.DataGridViewTopRightColumn_ClientSortKeys.Name = "DataGridViewTopRightColumn_ClientSortKeys"
            Me.DataGridViewTopRightColumn_ClientSortKeys.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewTopRightColumn_ClientSortKeys.RunStandardValidation = True
            Me.DataGridViewTopRightColumn_ClientSortKeys.ShowColumnMenuOnRightClick = False
            Me.DataGridViewTopRightColumn_ClientSortKeys.ShowSelectDeselectAllButtons = False
            Me.DataGridViewTopRightColumn_ClientSortKeys.Size = New System.Drawing.Size(409, 177)
            Me.DataGridViewTopRightColumn_ClientSortKeys.TabIndex = 1
            Me.DataGridViewTopRightColumn_ClientSortKeys.UseEmbeddedNavigator = False
            Me.DataGridViewTopRightColumn_ClientSortKeys.ViewCaptionHeight = -1
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
            Me.LabelGeneral_Name.Size = New System.Drawing.Size(51, 20)
            Me.LabelGeneral_Name.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_Name.TabIndex = 3
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
            Me.TextBoxGeneral_Name.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxGeneral_Name.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxGeneral_Name.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxGeneral_Name.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxGeneral_Name.FocusHighlightEnabled = True
            Me.TextBoxGeneral_Name.ForeColor = System.Drawing.Color.Black
            Me.TextBoxGeneral_Name.Location = New System.Drawing.Point(63, 30)
            Me.TextBoxGeneral_Name.MaxFileSize = CType(0, Long)
            Me.TextBoxGeneral_Name.Name = "TextBoxGeneral_Name"
            Me.TextBoxGeneral_Name.SecurityEnabled = True
            Me.TextBoxGeneral_Name.ShowSpellCheckCompleteMessage = True
            Me.TextBoxGeneral_Name.Size = New System.Drawing.Size(704, 20)
            Me.TextBoxGeneral_Name.StartingFolderName = Nothing
            Me.TextBoxGeneral_Name.TabIndex = 4
            Me.TextBoxGeneral_Name.TabOnEnter = True
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
            Me.LabelGeneral_Code.Size = New System.Drawing.Size(51, 20)
            Me.LabelGeneral_Code.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_Code.TabIndex = 0
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
            Me.TextBoxGeneral_Code.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxGeneral_Code.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxGeneral_Code.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxGeneral_Code.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxGeneral_Code.FocusHighlightEnabled = True
            Me.TextBoxGeneral_Code.ForeColor = System.Drawing.Color.Black
            Me.TextBoxGeneral_Code.Location = New System.Drawing.Point(63, 4)
            Me.TextBoxGeneral_Code.MaxFileSize = CType(0, Long)
            Me.TextBoxGeneral_Code.Name = "TextBoxGeneral_Code"
            Me.TextBoxGeneral_Code.ReadOnly = True
            Me.TextBoxGeneral_Code.SecurityEnabled = True
            Me.TextBoxGeneral_Code.ShowSpellCheckCompleteMessage = True
            Me.TextBoxGeneral_Code.Size = New System.Drawing.Size(81, 20)
            Me.TextBoxGeneral_Code.StartingFolderName = Nothing
            Me.TextBoxGeneral_Code.TabIndex = 1
            Me.TextBoxGeneral_Code.TabOnEnter = True
            '
            'TabItemClientDetails_GeneralTab
            '
            Me.TabItemClientDetails_GeneralTab.AttachedControl = Me.TabControlPanelGeneralTab_General
            Me.TabItemClientDetails_GeneralTab.Name = "TabItemClientDetails_GeneralTab"
            Me.TabItemClientDetails_GeneralTab.Text = "General"
            '
            'TabControlPanelMediaIntegrationsSettingsTab_Settings
            '
            Me.TabControlPanelMediaIntegrationsSettingsTab_Settings.Controls.Add(Me.CheckBoxMediaIntegrationSettings_EnableDoubleClick)
            Me.TabControlPanelMediaIntegrationsSettingsTab_Settings.Controls.Add(Me.NumericInputDoubleClick_ReportID)
            Me.TabControlPanelMediaIntegrationsSettingsTab_Settings.Controls.Add(Me.NumericInputDoubleClick_ProfileID)
            Me.TabControlPanelMediaIntegrationsSettingsTab_Settings.Controls.Add(Me.LabelDoubleClick_ReportID)
            Me.TabControlPanelMediaIntegrationsSettingsTab_Settings.Controls.Add(Me.LabelDoubleClick_ProfileID)
            Me.TabControlPanelMediaIntegrationsSettingsTab_Settings.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelMediaIntegrationsSettingsTab_Settings.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelMediaIntegrationsSettingsTab_Settings.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelMediaIntegrationsSettingsTab_Settings.Name = "TabControlPanelMediaIntegrationsSettingsTab_Settings"
            Me.TabControlPanelMediaIntegrationsSettingsTab_Settings.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelMediaIntegrationsSettingsTab_Settings.Size = New System.Drawing.Size(845, 505)
            Me.TabControlPanelMediaIntegrationsSettingsTab_Settings.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelMediaIntegrationsSettingsTab_Settings.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelMediaIntegrationsSettingsTab_Settings.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelMediaIntegrationsSettingsTab_Settings.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelMediaIntegrationsSettingsTab_Settings.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelMediaIntegrationsSettingsTab_Settings.Style.GradientAngle = 90
            Me.TabControlPanelMediaIntegrationsSettingsTab_Settings.TabIndex = 49
            Me.TabControlPanelMediaIntegrationsSettingsTab_Settings.TabItem = Me.TabItemClientDetails_MediaIntegrationSettings
            '
            'CheckBoxMediaIntegrationSettings_EnableDoubleClick
            '
            Me.CheckBoxMediaIntegrationSettings_EnableDoubleClick.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxMediaIntegrationSettings_EnableDoubleClick.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxMediaIntegrationSettings_EnableDoubleClick.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMediaIntegrationSettings_EnableDoubleClick.CheckValue = 0
            Me.CheckBoxMediaIntegrationSettings_EnableDoubleClick.CheckValueChecked = 1
            Me.CheckBoxMediaIntegrationSettings_EnableDoubleClick.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxMediaIntegrationSettings_EnableDoubleClick.CheckValueUnchecked = 0
            Me.CheckBoxMediaIntegrationSettings_EnableDoubleClick.ChildControls = CType(resources.GetObject("CheckBoxMediaIntegrationSettings_EnableDoubleClick.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMediaIntegrationSettings_EnableDoubleClick.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMediaIntegrationSettings_EnableDoubleClick.Location = New System.Drawing.Point(6, 6)
            Me.CheckBoxMediaIntegrationSettings_EnableDoubleClick.MinimumSize = New System.Drawing.Size(151, 20)
            Me.CheckBoxMediaIntegrationSettings_EnableDoubleClick.Name = "CheckBoxMediaIntegrationSettings_EnableDoubleClick"
            Me.CheckBoxMediaIntegrationSettings_EnableDoubleClick.OldestSibling = Nothing
            Me.CheckBoxMediaIntegrationSettings_EnableDoubleClick.SecurityEnabled = True
            Me.CheckBoxMediaIntegrationSettings_EnableDoubleClick.SiblingControls = CType(resources.GetObject("CheckBoxMediaIntegrationSettings_EnableDoubleClick.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMediaIntegrationSettings_EnableDoubleClick.Size = New System.Drawing.Size(277, 20)
            Me.CheckBoxMediaIntegrationSettings_EnableDoubleClick.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMediaIntegrationSettings_EnableDoubleClick.TabIndex = 9
            Me.CheckBoxMediaIntegrationSettings_EnableDoubleClick.TabOnEnter = True
            Me.CheckBoxMediaIntegrationSettings_EnableDoubleClick.Text = "Enable DoubleClick Integration"
            '
            'NumericInputDoubleClick_ReportID
            '
            Me.NumericInputDoubleClick_ReportID.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDoubleClick_ReportID.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Long]
            Me.NumericInputDoubleClick_ReportID.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDoubleClick_ReportID.EnterMoveNextControl = True
            Me.NumericInputDoubleClick_ReportID.Location = New System.Drawing.Point(138, 56)
            Me.NumericInputDoubleClick_ReportID.Name = "NumericInputDoubleClick_ReportID"
            Me.NumericInputDoubleClick_ReportID.Properties.AllowMouseWheel = False
            Me.NumericInputDoubleClick_ReportID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputDoubleClick_ReportID.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputDoubleClick_ReportID.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputDoubleClick_ReportID.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputDoubleClick_ReportID.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDoubleClick_ReportID.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputDoubleClick_ReportID.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDoubleClick_ReportID.Properties.IsFloatValue = False
            Me.NumericInputDoubleClick_ReportID.Properties.Mask.EditMask = "f0"
            Me.NumericInputDoubleClick_ReportID.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDoubleClick_ReportID.Properties.MaxValue = New Decimal(New Integer() {-1, 2147483647, 0, 0})
            Me.NumericInputDoubleClick_ReportID.Properties.MinValue = New Decimal(New Integer() {-1, 2147483647, 0, -2147483648})
            Me.NumericInputDoubleClick_ReportID.SecurityEnabled = True
            Me.NumericInputDoubleClick_ReportID.Size = New System.Drawing.Size(143, 20)
            Me.NumericInputDoubleClick_ReportID.TabIndex = 7
            '
            'NumericInputDoubleClick_ProfileID
            '
            Me.NumericInputDoubleClick_ProfileID.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDoubleClick_ProfileID.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Long]
            Me.NumericInputDoubleClick_ProfileID.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDoubleClick_ProfileID.EnterMoveNextControl = True
            Me.NumericInputDoubleClick_ProfileID.Location = New System.Drawing.Point(138, 30)
            Me.NumericInputDoubleClick_ProfileID.Name = "NumericInputDoubleClick_ProfileID"
            Me.NumericInputDoubleClick_ProfileID.Properties.AllowMouseWheel = False
            Me.NumericInputDoubleClick_ProfileID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputDoubleClick_ProfileID.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputDoubleClick_ProfileID.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputDoubleClick_ProfileID.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputDoubleClick_ProfileID.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDoubleClick_ProfileID.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputDoubleClick_ProfileID.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDoubleClick_ProfileID.Properties.IsFloatValue = False
            Me.NumericInputDoubleClick_ProfileID.Properties.Mask.EditMask = "f0"
            Me.NumericInputDoubleClick_ProfileID.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDoubleClick_ProfileID.Properties.MaxValue = New Decimal(New Integer() {-1, 2147483647, 0, 0})
            Me.NumericInputDoubleClick_ProfileID.Properties.MinValue = New Decimal(New Integer() {-1, 2147483647, 0, -2147483648})
            Me.NumericInputDoubleClick_ProfileID.SecurityEnabled = True
            Me.NumericInputDoubleClick_ProfileID.Size = New System.Drawing.Size(143, 20)
            Me.NumericInputDoubleClick_ProfileID.TabIndex = 5
            '
            'LabelDoubleClick_ReportID
            '
            Me.LabelDoubleClick_ReportID.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDoubleClick_ReportID.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDoubleClick_ReportID.Location = New System.Drawing.Point(6, 56)
            Me.LabelDoubleClick_ReportID.Name = "LabelDoubleClick_ReportID"
            Me.LabelDoubleClick_ReportID.Size = New System.Drawing.Size(126, 20)
            Me.LabelDoubleClick_ReportID.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDoubleClick_ReportID.TabIndex = 6
            Me.LabelDoubleClick_ReportID.Text = "DoubleClick Report ID:"
            '
            'LabelDoubleClick_ProfileID
            '
            Me.LabelDoubleClick_ProfileID.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDoubleClick_ProfileID.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDoubleClick_ProfileID.Location = New System.Drawing.Point(6, 30)
            Me.LabelDoubleClick_ProfileID.Name = "LabelDoubleClick_ProfileID"
            Me.LabelDoubleClick_ProfileID.Size = New System.Drawing.Size(126, 20)
            Me.LabelDoubleClick_ProfileID.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDoubleClick_ProfileID.TabIndex = 4
            Me.LabelDoubleClick_ProfileID.Text = "DoubleClick Profile ID:"
            '
            'TabItemClientDetails_MediaIntegrationSettings
            '
            Me.TabItemClientDetails_MediaIntegrationSettings.AttachedControl = Me.TabControlPanelMediaIntegrationsSettingsTab_Settings
            Me.TabItemClientDetails_MediaIntegrationSettings.Name = "TabItemClientDetails_MediaIntegrationSettings"
            Me.TabItemClientDetails_MediaIntegrationSettings.Text = "Media Integration Settings"
            '
            'TabControlPanelProductionTab_Production
            '
            Me.TabControlPanelProductionTab_Production.Controls.Add(Me.CheckBoxProduction_LimitTimeFunctionsToBillingHierarchy)
            Me.TabControlPanelProductionTab_Production.Controls.Add(Me.SearchableComboBoxProduction_ClientDiscount)
            Me.TabControlPanelProductionTab_Production.Controls.Add(Me.LabelProduction_ClientDiscount)
            Me.TabControlPanelProductionTab_Production.Controls.Add(Me.GroupBoxProduction_ProductionEstimateFormat)
            Me.TabControlPanelProductionTab_Production.Controls.Add(Me.NumericInputProduction_DaysToPay)
            Me.TabControlPanelProductionTab_Production.Controls.Add(Me.GroupBoxProduction_ProductionInvoiceFormat)
            Me.TabControlPanelProductionTab_Production.Controls.Add(Me.LabelProduction_DaysToPay)
            Me.TabControlPanelProductionTab_Production.Controls.Add(Me.LabelProduction_InvoiceFooterComments)
            Me.TabControlPanelProductionTab_Production.Controls.Add(Me.TextBoxProduction_InvoiceFooterComments)
            Me.TabControlPanelProductionTab_Production.Controls.Add(Me.LabelProduction_AttentionLine)
            Me.TabControlPanelProductionTab_Production.Controls.Add(Me.TextBoxProduction_AttentionLine)
            Me.TabControlPanelProductionTab_Production.Controls.Add(Me.GroupBoxProduction_AssignProductionInvoicesBy)
            Me.TabControlPanelProductionTab_Production.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelProductionTab_Production.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelProductionTab_Production.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelProductionTab_Production.Name = "TabControlPanelProductionTab_Production"
            Me.TabControlPanelProductionTab_Production.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelProductionTab_Production.Size = New System.Drawing.Size(845, 505)
            Me.TabControlPanelProductionTab_Production.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelProductionTab_Production.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelProductionTab_Production.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelProductionTab_Production.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelProductionTab_Production.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelProductionTab_Production.Style.GradientAngle = 90
            Me.TabControlPanelProductionTab_Production.TabIndex = 1
            Me.TabControlPanelProductionTab_Production.TabItem = Me.TabItemClientDetails_ProductionTab
            '
            'CheckBoxProduction_LimitTimeFunctionsToBillingHierarchy
            '
            Me.CheckBoxProduction_LimitTimeFunctionsToBillingHierarchy.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxProduction_LimitTimeFunctionsToBillingHierarchy.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxProduction_LimitTimeFunctionsToBillingHierarchy.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxProduction_LimitTimeFunctionsToBillingHierarchy.CheckValue = 0
            Me.CheckBoxProduction_LimitTimeFunctionsToBillingHierarchy.CheckValueChecked = 1
            Me.CheckBoxProduction_LimitTimeFunctionsToBillingHierarchy.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxProduction_LimitTimeFunctionsToBillingHierarchy.CheckValueUnchecked = 0
            Me.CheckBoxProduction_LimitTimeFunctionsToBillingHierarchy.ChildControls = Nothing
            Me.CheckBoxProduction_LimitTimeFunctionsToBillingHierarchy.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxProduction_LimitTimeFunctionsToBillingHierarchy.Location = New System.Drawing.Point(6, 331)
            Me.CheckBoxProduction_LimitTimeFunctionsToBillingHierarchy.Name = "CheckBoxProduction_LimitTimeFunctionsToBillingHierarchy"
            Me.CheckBoxProduction_LimitTimeFunctionsToBillingHierarchy.OldestSibling = Nothing
            Me.CheckBoxProduction_LimitTimeFunctionsToBillingHierarchy.SecurityEnabled = True
            Me.CheckBoxProduction_LimitTimeFunctionsToBillingHierarchy.SiblingControls = Nothing
            Me.CheckBoxProduction_LimitTimeFunctionsToBillingHierarchy.Size = New System.Drawing.Size(833, 20)
            Me.CheckBoxProduction_LimitTimeFunctionsToBillingHierarchy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxProduction_LimitTimeFunctionsToBillingHierarchy.TabIndex = 23
            Me.CheckBoxProduction_LimitTimeFunctionsToBillingHierarchy.TabOnEnter = True
            Me.CheckBoxProduction_LimitTimeFunctionsToBillingHierarchy.Text = "Limit Time Functions to Billing Hierarchy"
            '
            'SearchableComboBoxProduction_ClientDiscount
            '
            Me.SearchableComboBoxProduction_ClientDiscount.ActiveFilterString = ""
            Me.SearchableComboBoxProduction_ClientDiscount.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxProduction_ClientDiscount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxProduction_ClientDiscount.AutoFillMode = False
            Me.SearchableComboBoxProduction_ClientDiscount.BookmarkingEnabled = False
            Me.SearchableComboBoxProduction_ClientDiscount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.ClientDiscount
            Me.SearchableComboBoxProduction_ClientDiscount.DataSource = Nothing
            Me.SearchableComboBoxProduction_ClientDiscount.DisableMouseWheel = False
            Me.SearchableComboBoxProduction_ClientDiscount.DisplayName = ""
            Me.SearchableComboBoxProduction_ClientDiscount.EnterMoveNextControl = True
            Me.SearchableComboBoxProduction_ClientDiscount.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.None
            Me.SearchableComboBoxProduction_ClientDiscount.Location = New System.Drawing.Point(157, 249)
            Me.SearchableComboBoxProduction_ClientDiscount.Name = "SearchableComboBoxProduction_ClientDiscount"
            Me.SearchableComboBoxProduction_ClientDiscount.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxProduction_ClientDiscount.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxProduction_ClientDiscount.Properties.NullText = "Select Client Discount"
            Me.SearchableComboBoxProduction_ClientDiscount.Properties.PopupView = Me.GridView8
            Me.SearchableComboBoxProduction_ClientDiscount.Properties.ShowClearButton = False
            Me.SearchableComboBoxProduction_ClientDiscount.Properties.ValueMember = "Code"
            Me.SearchableComboBoxProduction_ClientDiscount.SecurityEnabled = True
            Me.SearchableComboBoxProduction_ClientDiscount.SelectedValue = Nothing
            Me.SearchableComboBoxProduction_ClientDiscount.Size = New System.Drawing.Size(678, 20)
            Me.SearchableComboBoxProduction_ClientDiscount.TabIndex = 21
            '
            'GridView8
            '
            Me.GridView8.AFActiveFilterString = ""
            Me.GridView8.AllowExtraItemsInGridLookupEdits = True
            Me.GridView8.AutoFilterLookupColumns = False
            Me.GridView8.AutoloadRepositoryDatasource = True
            Me.GridView8.DataSourceClearing = False
            Me.GridView8.EnableDisabledRows = False
            Me.GridView8.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView8.Name = "GridView8"
            Me.GridView8.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView8.OptionsView.ShowGroupPanel = False
            Me.GridView8.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView8.RunStandardValidation = True
            Me.GridView8.SkipAddingControlsOnModifyColumn = False
            Me.GridView8.SkipSettingFontOnModifyColumn = False
            '
            'LabelProduction_ClientDiscount
            '
            Me.LabelProduction_ClientDiscount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelProduction_ClientDiscount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelProduction_ClientDiscount.Location = New System.Drawing.Point(6, 249)
            Me.LabelProduction_ClientDiscount.Name = "LabelProduction_ClientDiscount"
            Me.LabelProduction_ClientDiscount.Size = New System.Drawing.Size(145, 20)
            Me.LabelProduction_ClientDiscount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelProduction_ClientDiscount.TabIndex = 22
            Me.LabelProduction_ClientDiscount.Text = "Client Discount:"
            '
            'GroupBoxProduction_ProductionEstimateFormat
            '
            Me.GroupBoxProduction_ProductionEstimateFormat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxProduction_ProductionEstimateFormat.Controls.Add(Me.LabelProductionEstimateFormat_StandardFormat)
            Me.GroupBoxProduction_ProductionEstimateFormat.Controls.Add(Me.LabelProductionEstimateFormat_Type)
            Me.GroupBoxProduction_ProductionEstimateFormat.Controls.Add(Me.ComboBoxProductionEstimateFormat_Type)
            Me.GroupBoxProduction_ProductionEstimateFormat.Location = New System.Drawing.Point(6, 275)
            Me.GroupBoxProduction_ProductionEstimateFormat.Name = "GroupBoxProduction_ProductionEstimateFormat"
            Me.GroupBoxProduction_ProductionEstimateFormat.Size = New System.Drawing.Size(833, 51)
            Me.GroupBoxProduction_ProductionEstimateFormat.TabIndex = 20
            Me.GroupBoxProduction_ProductionEstimateFormat.Text = "Production Estimate Format"
            '
            'LabelProductionEstimateFormat_StandardFormat
            '
            Me.LabelProductionEstimateFormat_StandardFormat.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelProductionEstimateFormat_StandardFormat.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelProductionEstimateFormat_StandardFormat.Location = New System.Drawing.Point(226, 25)
            Me.LabelProductionEstimateFormat_StandardFormat.Name = "LabelProductionEstimateFormat_StandardFormat"
            Me.LabelProductionEstimateFormat_StandardFormat.Size = New System.Drawing.Size(530, 20)
            Me.LabelProductionEstimateFormat_StandardFormat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelProductionEstimateFormat_StandardFormat.TabIndex = 14
            Me.LabelProductionEstimateFormat_StandardFormat.Text = "(Standard Format is established and configured in 'Estimate Printing')"
            '
            'LabelProductionEstimateFormat_Type
            '
            Me.LabelProductionEstimateFormat_Type.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelProductionEstimateFormat_Type.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelProductionEstimateFormat_Type.Location = New System.Drawing.Point(6, 25)
            Me.LabelProductionEstimateFormat_Type.Name = "LabelProductionEstimateFormat_Type"
            Me.LabelProductionEstimateFormat_Type.Size = New System.Drawing.Size(47, 20)
            Me.LabelProductionEstimateFormat_Type.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelProductionEstimateFormat_Type.TabIndex = 10
            Me.LabelProductionEstimateFormat_Type.Text = "Type:"
            '
            'ComboBoxProductionEstimateFormat_Type
            '
            Me.ComboBoxProductionEstimateFormat_Type.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxProductionEstimateFormat_Type.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxProductionEstimateFormat_Type.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxProductionEstimateFormat_Type.AutoFindItemInDataSource = False
            Me.ComboBoxProductionEstimateFormat_Type.AutoSelectSingleItemDatasource = False
            Me.ComboBoxProductionEstimateFormat_Type.BookmarkingEnabled = False
            Me.ComboBoxProductionEstimateFormat_Type.ClientCode = ""
            Me.ComboBoxProductionEstimateFormat_Type.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.InvoiceFormat
            Me.ComboBoxProductionEstimateFormat_Type.DisableMouseWheel = False
            Me.ComboBoxProductionEstimateFormat_Type.DisplayMember = "Description"
            Me.ComboBoxProductionEstimateFormat_Type.DisplayName = ""
            Me.ComboBoxProductionEstimateFormat_Type.DivisionCode = ""
            Me.ComboBoxProductionEstimateFormat_Type.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxProductionEstimateFormat_Type.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxProductionEstimateFormat_Type.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxProductionEstimateFormat_Type.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxProductionEstimateFormat_Type.FocusHighlightEnabled = True
            Me.ComboBoxProductionEstimateFormat_Type.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxProductionEstimateFormat_Type.FormattingEnabled = True
            Me.ComboBoxProductionEstimateFormat_Type.ItemHeight = 16
            Me.ComboBoxProductionEstimateFormat_Type.Location = New System.Drawing.Point(60, 25)
            Me.ComboBoxProductionEstimateFormat_Type.Name = "ComboBoxProductionEstimateFormat_Type"
            Me.ComboBoxProductionEstimateFormat_Type.ReadOnly = False
            Me.ComboBoxProductionEstimateFormat_Type.SecurityEnabled = True
            Me.ComboBoxProductionEstimateFormat_Type.Size = New System.Drawing.Size(160, 22)
            Me.ComboBoxProductionEstimateFormat_Type.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxProductionEstimateFormat_Type.TabIndex = 1
            Me.ComboBoxProductionEstimateFormat_Type.TabOnEnter = True
            Me.ComboBoxProductionEstimateFormat_Type.ValueMember = "Code"
            Me.ComboBoxProductionEstimateFormat_Type.WatermarkText = "Select Invoice Format"
            '
            'NumericInputProduction_DaysToPay
            '
            Me.NumericInputProduction_DaysToPay.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputProduction_DaysToPay.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputProduction_DaysToPay.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputProduction_DaysToPay.EnterMoveNextControl = True
            Me.NumericInputProduction_DaysToPay.Location = New System.Drawing.Point(157, 223)
            Me.NumericInputProduction_DaysToPay.Name = "NumericInputProduction_DaysToPay"
            Me.NumericInputProduction_DaysToPay.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputProduction_DaysToPay.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputProduction_DaysToPay.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputProduction_DaysToPay.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputProduction_DaysToPay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputProduction_DaysToPay.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputProduction_DaysToPay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputProduction_DaysToPay.Properties.IsFloatValue = False
            Me.NumericInputProduction_DaysToPay.Properties.Mask.EditMask = "f0"
            Me.NumericInputProduction_DaysToPay.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputProduction_DaysToPay.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputProduction_DaysToPay.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputProduction_DaysToPay.SecurityEnabled = True
            Me.NumericInputProduction_DaysToPay.Size = New System.Drawing.Size(75, 20)
            Me.NumericInputProduction_DaysToPay.TabIndex = 19
            '
            'GroupBoxProduction_ProductionInvoiceFormat
            '
            Me.GroupBoxProduction_ProductionInvoiceFormat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxProduction_ProductionInvoiceFormat.Controls.Add(Me.SearchableComboBoxProductionInvoiceFormat_Format)
            Me.GroupBoxProduction_ProductionInvoiceFormat.Controls.Add(Me.LabelProductionInvoiceFormat_StandardFormat)
            Me.GroupBoxProduction_ProductionInvoiceFormat.Controls.Add(Me.LabelProductionInvoiceFormat_Format)
            Me.GroupBoxProduction_ProductionInvoiceFormat.Controls.Add(Me.LabelProductionInvoiceFormat_Type)
            Me.GroupBoxProduction_ProductionInvoiceFormat.Controls.Add(Me.ComboBoxProductionInvoiceFormat_Type)
            Me.GroupBoxProduction_ProductionInvoiceFormat.Location = New System.Drawing.Point(6, 88)
            Me.GroupBoxProduction_ProductionInvoiceFormat.Name = "GroupBoxProduction_ProductionInvoiceFormat"
            Me.GroupBoxProduction_ProductionInvoiceFormat.Size = New System.Drawing.Size(833, 77)
            Me.GroupBoxProduction_ProductionInvoiceFormat.TabIndex = 9
            Me.GroupBoxProduction_ProductionInvoiceFormat.Text = "Production Invoice Format"
            '
            'SearchableComboBoxProductionInvoiceFormat_Format
            '
            Me.SearchableComboBoxProductionInvoiceFormat_Format.ActiveFilterString = ""
            Me.SearchableComboBoxProductionInvoiceFormat_Format.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxProductionInvoiceFormat_Format.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxProductionInvoiceFormat_Format.AutoFillMode = False
            Me.SearchableComboBoxProductionInvoiceFormat_Format.BookmarkingEnabled = False
            Me.SearchableComboBoxProductionInvoiceFormat_Format.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.CustomReport
            Me.SearchableComboBoxProductionInvoiceFormat_Format.DataSource = Nothing
            Me.SearchableComboBoxProductionInvoiceFormat_Format.DisableMouseWheel = False
            Me.SearchableComboBoxProductionInvoiceFormat_Format.DisplayName = ""
            Me.SearchableComboBoxProductionInvoiceFormat_Format.EnterMoveNextControl = True
            Me.SearchableComboBoxProductionInvoiceFormat_Format.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxProductionInvoiceFormat_Format.Location = New System.Drawing.Point(60, 50)
            Me.SearchableComboBoxProductionInvoiceFormat_Format.Name = "SearchableComboBoxProductionInvoiceFormat_Format"
            Me.SearchableComboBoxProductionInvoiceFormat_Format.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxProductionInvoiceFormat_Format.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxProductionInvoiceFormat_Format.Properties.NullText = "Select Report"
            Me.SearchableComboBoxProductionInvoiceFormat_Format.Properties.PopupView = Me.GridView1
            Me.SearchableComboBoxProductionInvoiceFormat_Format.Properties.ShowClearButton = False
            Me.SearchableComboBoxProductionInvoiceFormat_Format.Properties.ValueMember = "Code"
            Me.SearchableComboBoxProductionInvoiceFormat_Format.SecurityEnabled = True
            Me.SearchableComboBoxProductionInvoiceFormat_Format.SelectedValue = Nothing
            Me.SearchableComboBoxProductionInvoiceFormat_Format.Size = New System.Drawing.Size(767, 20)
            Me.SearchableComboBoxProductionInvoiceFormat_Format.TabIndex = 4
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
            'LabelProductionInvoiceFormat_StandardFormat
            '
            Me.LabelProductionInvoiceFormat_StandardFormat.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelProductionInvoiceFormat_StandardFormat.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelProductionInvoiceFormat_StandardFormat.Location = New System.Drawing.Point(226, 25)
            Me.LabelProductionInvoiceFormat_StandardFormat.Name = "LabelProductionInvoiceFormat_StandardFormat"
            Me.LabelProductionInvoiceFormat_StandardFormat.Size = New System.Drawing.Size(530, 20)
            Me.LabelProductionInvoiceFormat_StandardFormat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelProductionInvoiceFormat_StandardFormat.TabIndex = 14
            Me.LabelProductionInvoiceFormat_StandardFormat.Text = "(Standard Format is established and configured in 'Invoice Printing')"
            '
            'LabelProductionInvoiceFormat_Format
            '
            Me.LabelProductionInvoiceFormat_Format.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelProductionInvoiceFormat_Format.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelProductionInvoiceFormat_Format.Location = New System.Drawing.Point(7, 50)
            Me.LabelProductionInvoiceFormat_Format.Name = "LabelProductionInvoiceFormat_Format"
            Me.LabelProductionInvoiceFormat_Format.Size = New System.Drawing.Size(47, 20)
            Me.LabelProductionInvoiceFormat_Format.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelProductionInvoiceFormat_Format.TabIndex = 12
            Me.LabelProductionInvoiceFormat_Format.Text = "Format:"
            '
            'LabelProductionInvoiceFormat_Type
            '
            Me.LabelProductionInvoiceFormat_Type.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelProductionInvoiceFormat_Type.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelProductionInvoiceFormat_Type.Location = New System.Drawing.Point(6, 25)
            Me.LabelProductionInvoiceFormat_Type.Name = "LabelProductionInvoiceFormat_Type"
            Me.LabelProductionInvoiceFormat_Type.Size = New System.Drawing.Size(47, 20)
            Me.LabelProductionInvoiceFormat_Type.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelProductionInvoiceFormat_Type.TabIndex = 10
            Me.LabelProductionInvoiceFormat_Type.Text = "Type:"
            '
            'ComboBoxProductionInvoiceFormat_Type
            '
            Me.ComboBoxProductionInvoiceFormat_Type.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxProductionInvoiceFormat_Type.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxProductionInvoiceFormat_Type.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxProductionInvoiceFormat_Type.AutoFindItemInDataSource = False
            Me.ComboBoxProductionInvoiceFormat_Type.AutoSelectSingleItemDatasource = False
            Me.ComboBoxProductionInvoiceFormat_Type.BookmarkingEnabled = False
            Me.ComboBoxProductionInvoiceFormat_Type.ClientCode = ""
            Me.ComboBoxProductionInvoiceFormat_Type.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.InvoiceFormat
            Me.ComboBoxProductionInvoiceFormat_Type.DisableMouseWheel = False
            Me.ComboBoxProductionInvoiceFormat_Type.DisplayMember = "Description"
            Me.ComboBoxProductionInvoiceFormat_Type.DisplayName = ""
            Me.ComboBoxProductionInvoiceFormat_Type.DivisionCode = ""
            Me.ComboBoxProductionInvoiceFormat_Type.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxProductionInvoiceFormat_Type.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxProductionInvoiceFormat_Type.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxProductionInvoiceFormat_Type.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxProductionInvoiceFormat_Type.FocusHighlightEnabled = True
            Me.ComboBoxProductionInvoiceFormat_Type.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxProductionInvoiceFormat_Type.FormattingEnabled = True
            Me.ComboBoxProductionInvoiceFormat_Type.ItemHeight = 16
            Me.ComboBoxProductionInvoiceFormat_Type.Location = New System.Drawing.Point(60, 25)
            Me.ComboBoxProductionInvoiceFormat_Type.Name = "ComboBoxProductionInvoiceFormat_Type"
            Me.ComboBoxProductionInvoiceFormat_Type.ReadOnly = False
            Me.ComboBoxProductionInvoiceFormat_Type.SecurityEnabled = True
            Me.ComboBoxProductionInvoiceFormat_Type.Size = New System.Drawing.Size(160, 22)
            Me.ComboBoxProductionInvoiceFormat_Type.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxProductionInvoiceFormat_Type.TabIndex = 1
            Me.ComboBoxProductionInvoiceFormat_Type.TabOnEnter = True
            Me.ComboBoxProductionInvoiceFormat_Type.ValueMember = "Code"
            Me.ComboBoxProductionInvoiceFormat_Type.WatermarkText = "Select Invoice Format"
            '
            'LabelProduction_DaysToPay
            '
            Me.LabelProduction_DaysToPay.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelProduction_DaysToPay.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelProduction_DaysToPay.Location = New System.Drawing.Point(6, 223)
            Me.LabelProduction_DaysToPay.Name = "LabelProduction_DaysToPay"
            Me.LabelProduction_DaysToPay.Size = New System.Drawing.Size(145, 20)
            Me.LabelProduction_DaysToPay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelProduction_DaysToPay.TabIndex = 18
            Me.LabelProduction_DaysToPay.Text = "Days to Pay:"
            '
            'LabelProduction_InvoiceFooterComments
            '
            Me.LabelProduction_InvoiceFooterComments.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelProduction_InvoiceFooterComments.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelProduction_InvoiceFooterComments.Location = New System.Drawing.Point(6, 197)
            Me.LabelProduction_InvoiceFooterComments.Name = "LabelProduction_InvoiceFooterComments"
            Me.LabelProduction_InvoiceFooterComments.Size = New System.Drawing.Size(145, 20)
            Me.LabelProduction_InvoiceFooterComments.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelProduction_InvoiceFooterComments.TabIndex = 16
            Me.LabelProduction_InvoiceFooterComments.Text = "Invoice Footer Comments:"
            '
            'TextBoxProduction_InvoiceFooterComments
            '
            Me.TextBoxProduction_InvoiceFooterComments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxProduction_InvoiceFooterComments.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxProduction_InvoiceFooterComments.Border.Class = "TextBoxBorder"
            Me.TextBoxProduction_InvoiceFooterComments.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxProduction_InvoiceFooterComments.CheckSpellingOnValidate = False
            Me.TextBoxProduction_InvoiceFooterComments.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxProduction_InvoiceFooterComments.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxProduction_InvoiceFooterComments.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxProduction_InvoiceFooterComments.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxProduction_InvoiceFooterComments.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxProduction_InvoiceFooterComments.FocusHighlightEnabled = True
            Me.TextBoxProduction_InvoiceFooterComments.ForeColor = System.Drawing.Color.Black
            Me.TextBoxProduction_InvoiceFooterComments.Location = New System.Drawing.Point(157, 197)
            Me.TextBoxProduction_InvoiceFooterComments.MaxFileSize = CType(0, Long)
            Me.TextBoxProduction_InvoiceFooterComments.Name = "TextBoxProduction_InvoiceFooterComments"
            Me.TextBoxProduction_InvoiceFooterComments.SecurityEnabled = True
            Me.TextBoxProduction_InvoiceFooterComments.ShowSpellCheckCompleteMessage = True
            Me.TextBoxProduction_InvoiceFooterComments.Size = New System.Drawing.Size(677, 20)
            Me.TextBoxProduction_InvoiceFooterComments.StartingFolderName = Nothing
            Me.TextBoxProduction_InvoiceFooterComments.TabIndex = 17
            Me.TextBoxProduction_InvoiceFooterComments.TabOnEnter = True
            '
            'LabelProduction_AttentionLine
            '
            Me.LabelProduction_AttentionLine.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelProduction_AttentionLine.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelProduction_AttentionLine.Location = New System.Drawing.Point(6, 171)
            Me.LabelProduction_AttentionLine.Name = "LabelProduction_AttentionLine"
            Me.LabelProduction_AttentionLine.Size = New System.Drawing.Size(145, 20)
            Me.LabelProduction_AttentionLine.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelProduction_AttentionLine.TabIndex = 14
            Me.LabelProduction_AttentionLine.Text = "Attention Line:"
            '
            'TextBoxProduction_AttentionLine
            '
            Me.TextBoxProduction_AttentionLine.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxProduction_AttentionLine.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxProduction_AttentionLine.Border.Class = "TextBoxBorder"
            Me.TextBoxProduction_AttentionLine.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxProduction_AttentionLine.CheckSpellingOnValidate = False
            Me.TextBoxProduction_AttentionLine.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxProduction_AttentionLine.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxProduction_AttentionLine.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxProduction_AttentionLine.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxProduction_AttentionLine.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxProduction_AttentionLine.FocusHighlightEnabled = True
            Me.TextBoxProduction_AttentionLine.ForeColor = System.Drawing.Color.Black
            Me.TextBoxProduction_AttentionLine.Location = New System.Drawing.Point(157, 171)
            Me.TextBoxProduction_AttentionLine.MaxFileSize = CType(0, Long)
            Me.TextBoxProduction_AttentionLine.Name = "TextBoxProduction_AttentionLine"
            Me.TextBoxProduction_AttentionLine.SecurityEnabled = True
            Me.TextBoxProduction_AttentionLine.ShowSpellCheckCompleteMessage = True
            Me.TextBoxProduction_AttentionLine.Size = New System.Drawing.Size(677, 20)
            Me.TextBoxProduction_AttentionLine.StartingFolderName = Nothing
            Me.TextBoxProduction_AttentionLine.TabIndex = 15
            Me.TextBoxProduction_AttentionLine.TabOnEnter = True
            '
            'GroupBoxProduction_AssignProductionInvoicesBy
            '
            Me.GroupBoxProduction_AssignProductionInvoicesBy.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxProduction_AssignProductionInvoicesBy.Controls.Add(Me.RadioButtonControlAssignProductionInvoicesBy_ProductClientPO)
            Me.GroupBoxProduction_AssignProductionInvoicesBy.Controls.Add(Me.RadioButtonControlAssignProductionInvoicesBy_ProductSalesClass)
            Me.GroupBoxProduction_AssignProductionInvoicesBy.Controls.Add(Me.RadioButtonControlAssignProductionInvoicesBy_Product)
            Me.GroupBoxProduction_AssignProductionInvoicesBy.Controls.Add(Me.RadioButtonControlAssignProductionInvoicesBy_Job)
            Me.GroupBoxProduction_AssignProductionInvoicesBy.Controls.Add(Me.RadioButtonControlAssignProductionInvoicesBy_Division)
            Me.GroupBoxProduction_AssignProductionInvoicesBy.Controls.Add(Me.RadioButtonControlAssignProductionInvoicesBy_Client)
            Me.GroupBoxProduction_AssignProductionInvoicesBy.Controls.Add(Me.RadioButtonControlAssignProductionInvoicesBy_JobComponent)
            Me.GroupBoxProduction_AssignProductionInvoicesBy.Controls.Add(Me.RadioButtonControlAssignProductionInvoicesBy_Campaign)
            Me.GroupBoxProduction_AssignProductionInvoicesBy.Location = New System.Drawing.Point(6, 6)
            Me.GroupBoxProduction_AssignProductionInvoicesBy.Name = "GroupBoxProduction_AssignProductionInvoicesBy"
            Me.GroupBoxProduction_AssignProductionInvoicesBy.Size = New System.Drawing.Size(833, 76)
            Me.GroupBoxProduction_AssignProductionInvoicesBy.TabIndex = 0
            Me.GroupBoxProduction_AssignProductionInvoicesBy.TabStop = True
            Me.GroupBoxProduction_AssignProductionInvoicesBy.Text = "Assign Production Invoices By"
            '
            'RadioButtonControlAssignProductionInvoicesBy_ProductClientPO
            '
            Me.RadioButtonControlAssignProductionInvoicesBy_ProductClientPO.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlAssignProductionInvoicesBy_ProductClientPO.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlAssignProductionInvoicesBy_ProductClientPO.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlAssignProductionInvoicesBy_ProductClientPO.Location = New System.Drawing.Point(481, 50)
            Me.RadioButtonControlAssignProductionInvoicesBy_ProductClientPO.Name = "RadioButtonControlAssignProductionInvoicesBy_ProductClientPO"
            Me.RadioButtonControlAssignProductionInvoicesBy_ProductClientPO.SecurityEnabled = True
            Me.RadioButtonControlAssignProductionInvoicesBy_ProductClientPO.Size = New System.Drawing.Size(143, 20)
            Me.RadioButtonControlAssignProductionInvoicesBy_ProductClientPO.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlAssignProductionInvoicesBy_ProductClientPO.TabIndex = 8
            Me.RadioButtonControlAssignProductionInvoicesBy_ProductClientPO.TabOnEnter = True
            Me.RadioButtonControlAssignProductionInvoicesBy_ProductClientPO.TabStop = False
            Me.RadioButtonControlAssignProductionInvoicesBy_ProductClientPO.Text = "Product / Client PO"
            '
            'RadioButtonControlAssignProductionInvoicesBy_ProductSalesClass
            '
            Me.RadioButtonControlAssignProductionInvoicesBy_ProductSalesClass.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlAssignProductionInvoicesBy_ProductSalesClass.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlAssignProductionInvoicesBy_ProductSalesClass.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlAssignProductionInvoicesBy_ProductSalesClass.Location = New System.Drawing.Point(324, 50)
            Me.RadioButtonControlAssignProductionInvoicesBy_ProductSalesClass.Name = "RadioButtonControlAssignProductionInvoicesBy_ProductSalesClass"
            Me.RadioButtonControlAssignProductionInvoicesBy_ProductSalesClass.SecurityEnabled = True
            Me.RadioButtonControlAssignProductionInvoicesBy_ProductSalesClass.Size = New System.Drawing.Size(143, 20)
            Me.RadioButtonControlAssignProductionInvoicesBy_ProductSalesClass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlAssignProductionInvoicesBy_ProductSalesClass.TabIndex = 7
            Me.RadioButtonControlAssignProductionInvoicesBy_ProductSalesClass.TabOnEnter = True
            Me.RadioButtonControlAssignProductionInvoicesBy_ProductSalesClass.TabStop = False
            Me.RadioButtonControlAssignProductionInvoicesBy_ProductSalesClass.Text = "Product / Sales Class"
            '
            'RadioButtonControlAssignProductionInvoicesBy_Product
            '
            Me.RadioButtonControlAssignProductionInvoicesBy_Product.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlAssignProductionInvoicesBy_Product.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlAssignProductionInvoicesBy_Product.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlAssignProductionInvoicesBy_Product.Location = New System.Drawing.Point(167, 50)
            Me.RadioButtonControlAssignProductionInvoicesBy_Product.Name = "RadioButtonControlAssignProductionInvoicesBy_Product"
            Me.RadioButtonControlAssignProductionInvoicesBy_Product.SecurityEnabled = True
            Me.RadioButtonControlAssignProductionInvoicesBy_Product.Size = New System.Drawing.Size(143, 20)
            Me.RadioButtonControlAssignProductionInvoicesBy_Product.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlAssignProductionInvoicesBy_Product.TabIndex = 6
            Me.RadioButtonControlAssignProductionInvoicesBy_Product.TabOnEnter = True
            Me.RadioButtonControlAssignProductionInvoicesBy_Product.TabStop = False
            Me.RadioButtonControlAssignProductionInvoicesBy_Product.Text = "Product"
            '
            'RadioButtonControlAssignProductionInvoicesBy_Job
            '
            Me.RadioButtonControlAssignProductionInvoicesBy_Job.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlAssignProductionInvoicesBy_Job.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlAssignProductionInvoicesBy_Job.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlAssignProductionInvoicesBy_Job.Checked = True
            Me.RadioButtonControlAssignProductionInvoicesBy_Job.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonControlAssignProductionInvoicesBy_Job.CheckValue = "Y"
            Me.RadioButtonControlAssignProductionInvoicesBy_Job.Location = New System.Drawing.Point(481, 25)
            Me.RadioButtonControlAssignProductionInvoicesBy_Job.Name = "RadioButtonControlAssignProductionInvoicesBy_Job"
            Me.RadioButtonControlAssignProductionInvoicesBy_Job.SecurityEnabled = True
            Me.RadioButtonControlAssignProductionInvoicesBy_Job.Size = New System.Drawing.Size(143, 20)
            Me.RadioButtonControlAssignProductionInvoicesBy_Job.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlAssignProductionInvoicesBy_Job.TabIndex = 4
            Me.RadioButtonControlAssignProductionInvoicesBy_Job.TabOnEnter = True
            Me.RadioButtonControlAssignProductionInvoicesBy_Job.Text = "Job"
            '
            'RadioButtonControlAssignProductionInvoicesBy_Division
            '
            Me.RadioButtonControlAssignProductionInvoicesBy_Division.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlAssignProductionInvoicesBy_Division.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlAssignProductionInvoicesBy_Division.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlAssignProductionInvoicesBy_Division.Location = New System.Drawing.Point(324, 25)
            Me.RadioButtonControlAssignProductionInvoicesBy_Division.Name = "RadioButtonControlAssignProductionInvoicesBy_Division"
            Me.RadioButtonControlAssignProductionInvoicesBy_Division.SecurityEnabled = True
            Me.RadioButtonControlAssignProductionInvoicesBy_Division.Size = New System.Drawing.Size(143, 20)
            Me.RadioButtonControlAssignProductionInvoicesBy_Division.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlAssignProductionInvoicesBy_Division.TabIndex = 3
            Me.RadioButtonControlAssignProductionInvoicesBy_Division.TabOnEnter = True
            Me.RadioButtonControlAssignProductionInvoicesBy_Division.TabStop = False
            Me.RadioButtonControlAssignProductionInvoicesBy_Division.Text = "Division"
            '
            'RadioButtonControlAssignProductionInvoicesBy_Client
            '
            Me.RadioButtonControlAssignProductionInvoicesBy_Client.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlAssignProductionInvoicesBy_Client.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlAssignProductionInvoicesBy_Client.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlAssignProductionInvoicesBy_Client.Location = New System.Drawing.Point(167, 25)
            Me.RadioButtonControlAssignProductionInvoicesBy_Client.Name = "RadioButtonControlAssignProductionInvoicesBy_Client"
            Me.RadioButtonControlAssignProductionInvoicesBy_Client.SecurityEnabled = True
            Me.RadioButtonControlAssignProductionInvoicesBy_Client.Size = New System.Drawing.Size(143, 20)
            Me.RadioButtonControlAssignProductionInvoicesBy_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlAssignProductionInvoicesBy_Client.TabIndex = 2
            Me.RadioButtonControlAssignProductionInvoicesBy_Client.TabOnEnter = True
            Me.RadioButtonControlAssignProductionInvoicesBy_Client.TabStop = False
            Me.RadioButtonControlAssignProductionInvoicesBy_Client.Text = "Client"
            '
            'RadioButtonControlAssignProductionInvoicesBy_JobComponent
            '
            Me.RadioButtonControlAssignProductionInvoicesBy_JobComponent.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlAssignProductionInvoicesBy_JobComponent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlAssignProductionInvoicesBy_JobComponent.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlAssignProductionInvoicesBy_JobComponent.Location = New System.Drawing.Point(10, 50)
            Me.RadioButtonControlAssignProductionInvoicesBy_JobComponent.Name = "RadioButtonControlAssignProductionInvoicesBy_JobComponent"
            Me.RadioButtonControlAssignProductionInvoicesBy_JobComponent.SecurityEnabled = True
            Me.RadioButtonControlAssignProductionInvoicesBy_JobComponent.Size = New System.Drawing.Size(143, 20)
            Me.RadioButtonControlAssignProductionInvoicesBy_JobComponent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlAssignProductionInvoicesBy_JobComponent.TabIndex = 5
            Me.RadioButtonControlAssignProductionInvoicesBy_JobComponent.TabOnEnter = True
            Me.RadioButtonControlAssignProductionInvoicesBy_JobComponent.TabStop = False
            Me.RadioButtonControlAssignProductionInvoicesBy_JobComponent.Text = "Job Component"
            '
            'RadioButtonControlAssignProductionInvoicesBy_Campaign
            '
            Me.RadioButtonControlAssignProductionInvoicesBy_Campaign.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlAssignProductionInvoicesBy_Campaign.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlAssignProductionInvoicesBy_Campaign.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlAssignProductionInvoicesBy_Campaign.Location = New System.Drawing.Point(10, 25)
            Me.RadioButtonControlAssignProductionInvoicesBy_Campaign.Name = "RadioButtonControlAssignProductionInvoicesBy_Campaign"
            Me.RadioButtonControlAssignProductionInvoicesBy_Campaign.SecurityEnabled = True
            Me.RadioButtonControlAssignProductionInvoicesBy_Campaign.Size = New System.Drawing.Size(143, 20)
            Me.RadioButtonControlAssignProductionInvoicesBy_Campaign.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlAssignProductionInvoicesBy_Campaign.TabIndex = 1
            Me.RadioButtonControlAssignProductionInvoicesBy_Campaign.TabOnEnter = True
            Me.RadioButtonControlAssignProductionInvoicesBy_Campaign.TabStop = False
            Me.RadioButtonControlAssignProductionInvoicesBy_Campaign.Text = "Campaign"
            '
            'TabItemClientDetails_ProductionTab
            '
            Me.TabItemClientDetails_ProductionTab.AttachedControl = Me.TabControlPanelProductionTab_Production
            Me.TabItemClientDetails_ProductionTab.Name = "TabItemClientDetails_ProductionTab"
            Me.TabItemClientDetails_ProductionTab.Text = "Production"
            '
            'TabControlPanelMediaTab_Media
            '
            Me.TabControlPanelMediaTab_Media.Controls.Add(Me.CheckBoxMedia_ClientResponsibleForMediaTrafficInstructions)
            Me.TabControlPanelMediaTab_Media.Controls.Add(Me.CheckBoxNewClientOptions_TvUnitProductSplit)
            Me.TabControlPanelMediaTab_Media.Controls.Add(Me.NumericInputMedia_DaysToPay)
            Me.TabControlPanelMediaTab_Media.Controls.Add(Me.LabelMedia_DaysToPay)
            Me.TabControlPanelMediaTab_Media.Controls.Add(Me.GroupBoxMedia_AssignMediaInvoicesBy)
            Me.TabControlPanelMediaTab_Media.Controls.Add(Me.TextBoxMedia_AttentionLine)
            Me.TabControlPanelMediaTab_Media.Controls.Add(Me.LabelMedia_InvoiceFooterComments)
            Me.TabControlPanelMediaTab_Media.Controls.Add(Me.LabelMedia_AttentionLine)
            Me.TabControlPanelMediaTab_Media.Controls.Add(Me.TextBoxMedia_InvoiceFooterComments)
            Me.TabControlPanelMediaTab_Media.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelMediaTab_Media.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelMediaTab_Media.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelMediaTab_Media.Name = "TabControlPanelMediaTab_Media"
            Me.TabControlPanelMediaTab_Media.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelMediaTab_Media.Size = New System.Drawing.Size(845, 505)
            Me.TabControlPanelMediaTab_Media.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelMediaTab_Media.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelMediaTab_Media.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelMediaTab_Media.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelMediaTab_Media.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelMediaTab_Media.Style.GradientAngle = 90
            Me.TabControlPanelMediaTab_Media.TabIndex = 3
            Me.TabControlPanelMediaTab_Media.TabItem = Me.TabItemClientDetails_MediaTab
            '
            'CheckBoxMedia_ClientResponsibleForMediaTrafficInstructions
            '
            Me.CheckBoxMedia_ClientResponsibleForMediaTrafficInstructions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxMedia_ClientResponsibleForMediaTrafficInstructions.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxMedia_ClientResponsibleForMediaTrafficInstructions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMedia_ClientResponsibleForMediaTrafficInstructions.CheckValue = 0
            Me.CheckBoxMedia_ClientResponsibleForMediaTrafficInstructions.CheckValueChecked = 1
            Me.CheckBoxMedia_ClientResponsibleForMediaTrafficInstructions.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxMedia_ClientResponsibleForMediaTrafficInstructions.CheckValueUnchecked = 0
            Me.CheckBoxMedia_ClientResponsibleForMediaTrafficInstructions.ChildControls = CType(resources.GetObject("CheckBoxMedia_ClientResponsibleForMediaTrafficInstructions.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMedia_ClientResponsibleForMediaTrafficInstructions.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMedia_ClientResponsibleForMediaTrafficInstructions.Location = New System.Drawing.Point(6, 166)
            Me.CheckBoxMedia_ClientResponsibleForMediaTrafficInstructions.MinimumSize = New System.Drawing.Size(151, 20)
            Me.CheckBoxMedia_ClientResponsibleForMediaTrafficInstructions.Name = "CheckBoxMedia_ClientResponsibleForMediaTrafficInstructions"
            Me.CheckBoxMedia_ClientResponsibleForMediaTrafficInstructions.OldestSibling = Nothing
            Me.CheckBoxMedia_ClientResponsibleForMediaTrafficInstructions.SecurityEnabled = True
            Me.CheckBoxMedia_ClientResponsibleForMediaTrafficInstructions.SiblingControls = CType(resources.GetObject("CheckBoxMedia_ClientResponsibleForMediaTrafficInstructions.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMedia_ClientResponsibleForMediaTrafficInstructions.Size = New System.Drawing.Size(271, 20)
            Me.CheckBoxMedia_ClientResponsibleForMediaTrafficInstructions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMedia_ClientResponsibleForMediaTrafficInstructions.TabIndex = 8
            Me.CheckBoxMedia_ClientResponsibleForMediaTrafficInstructions.TabOnEnter = True
            Me.CheckBoxMedia_ClientResponsibleForMediaTrafficInstructions.Text = "Client Responsible for Media Traffic Instructions"
            '
            'CheckBoxNewClientOptions_TvUnitProductSplit
            '
            Me.CheckBoxNewClientOptions_TvUnitProductSplit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxNewClientOptions_TvUnitProductSplit.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxNewClientOptions_TvUnitProductSplit.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxNewClientOptions_TvUnitProductSplit.CheckValue = 0
            Me.CheckBoxNewClientOptions_TvUnitProductSplit.CheckValueChecked = 1
            Me.CheckBoxNewClientOptions_TvUnitProductSplit.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxNewClientOptions_TvUnitProductSplit.CheckValueUnchecked = 0
            Me.CheckBoxNewClientOptions_TvUnitProductSplit.ChildControls = CType(resources.GetObject("CheckBoxNewClientOptions_TvUnitProductSplit.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxNewClientOptions_TvUnitProductSplit.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxNewClientOptions_TvUnitProductSplit.Location = New System.Drawing.Point(6, 140)
            Me.CheckBoxNewClientOptions_TvUnitProductSplit.MinimumSize = New System.Drawing.Size(151, 20)
            Me.CheckBoxNewClientOptions_TvUnitProductSplit.Name = "CheckBoxNewClientOptions_TvUnitProductSplit"
            Me.CheckBoxNewClientOptions_TvUnitProductSplit.OldestSibling = Nothing
            Me.CheckBoxNewClientOptions_TvUnitProductSplit.SecurityEnabled = True
            Me.CheckBoxNewClientOptions_TvUnitProductSplit.SiblingControls = CType(resources.GetObject("CheckBoxNewClientOptions_TvUnitProductSplit.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxNewClientOptions_TvUnitProductSplit.Size = New System.Drawing.Size(271, 20)
            Me.CheckBoxNewClientOptions_TvUnitProductSplit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxNewClientOptions_TvUnitProductSplit.TabIndex = 7
            Me.CheckBoxNewClientOptions_TvUnitProductSplit.TabOnEnter = True
            Me.CheckBoxNewClientOptions_TvUnitProductSplit.Text = "TV Billing Split by Units"
            '
            'NumericInputMedia_DaysToPay
            '
            Me.NumericInputMedia_DaysToPay.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputMedia_DaysToPay.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputMedia_DaysToPay.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputMedia_DaysToPay.EnterMoveNextControl = True
            Me.NumericInputMedia_DaysToPay.Location = New System.Drawing.Point(162, 114)
            Me.NumericInputMedia_DaysToPay.Name = "NumericInputMedia_DaysToPay"
            Me.NumericInputMedia_DaysToPay.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputMedia_DaysToPay.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputMedia_DaysToPay.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputMedia_DaysToPay.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputMedia_DaysToPay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputMedia_DaysToPay.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputMedia_DaysToPay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputMedia_DaysToPay.Properties.IsFloatValue = False
            Me.NumericInputMedia_DaysToPay.Properties.Mask.EditMask = "f0"
            Me.NumericInputMedia_DaysToPay.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputMedia_DaysToPay.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputMedia_DaysToPay.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputMedia_DaysToPay.SecurityEnabled = True
            Me.NumericInputMedia_DaysToPay.Size = New System.Drawing.Size(75, 20)
            Me.NumericInputMedia_DaysToPay.TabIndex = 6
            '
            'LabelMedia_DaysToPay
            '
            Me.LabelMedia_DaysToPay.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMedia_DaysToPay.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMedia_DaysToPay.Location = New System.Drawing.Point(6, 114)
            Me.LabelMedia_DaysToPay.Name = "LabelMedia_DaysToPay"
            Me.LabelMedia_DaysToPay.Size = New System.Drawing.Size(150, 20)
            Me.LabelMedia_DaysToPay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMedia_DaysToPay.TabIndex = 5
            Me.LabelMedia_DaysToPay.Text = "Days to Pay:"
            '
            'GroupBoxMedia_AssignMediaInvoicesBy
            '
            Me.GroupBoxMedia_AssignMediaInvoicesBy.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxMedia_AssignMediaInvoicesBy.Controls.Add(Me.RadioButtonControlAssignMediaInvoicesBy_OrderType)
            Me.GroupBoxMedia_AssignMediaInvoicesBy.Controls.Add(Me.RadioButtonControlAssignMediaInvoicesBy_OrderNumber)
            Me.GroupBoxMedia_AssignMediaInvoicesBy.Controls.Add(Me.RadioButtonControlAssignMediaInvoicesBy_Market)
            Me.GroupBoxMedia_AssignMediaInvoicesBy.Controls.Add(Me.RadioButtonControlAssignMediaInvoicesBy_ClientPO)
            Me.GroupBoxMedia_AssignMediaInvoicesBy.Controls.Add(Me.RadioButtonControlAssignMediaInvoicesBy_SalesClass)
            Me.GroupBoxMedia_AssignMediaInvoicesBy.Controls.Add(Me.RadioButtonControlAssignMediaInvoicesBy_Campaign)
            Me.GroupBoxMedia_AssignMediaInvoicesBy.Location = New System.Drawing.Point(6, 6)
            Me.GroupBoxMedia_AssignMediaInvoicesBy.Name = "GroupBoxMedia_AssignMediaInvoicesBy"
            Me.GroupBoxMedia_AssignMediaInvoicesBy.Size = New System.Drawing.Size(833, 50)
            Me.GroupBoxMedia_AssignMediaInvoicesBy.TabIndex = 0
            Me.GroupBoxMedia_AssignMediaInvoicesBy.Text = "Assign Media Invoices By"
            '
            'RadioButtonControlAssignMediaInvoicesBy_OrderType
            '
            Me.RadioButtonControlAssignMediaInvoicesBy_OrderType.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlAssignMediaInvoicesBy_OrderType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlAssignMediaInvoicesBy_OrderType.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlAssignMediaInvoicesBy_OrderType.Checked = True
            Me.RadioButtonControlAssignMediaInvoicesBy_OrderType.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonControlAssignMediaInvoicesBy_OrderType.CheckValue = "4"
            Me.RadioButtonControlAssignMediaInvoicesBy_OrderType.CheckValueChecked = "4"
            Me.RadioButtonControlAssignMediaInvoicesBy_OrderType.CheckValueUnchecked = "0"
            Me.RadioButtonControlAssignMediaInvoicesBy_OrderType.Location = New System.Drawing.Point(540, 25)
            Me.RadioButtonControlAssignMediaInvoicesBy_OrderType.Name = "RadioButtonControlAssignMediaInvoicesBy_OrderType"
            Me.RadioButtonControlAssignMediaInvoicesBy_OrderType.SecurityEnabled = True
            Me.RadioButtonControlAssignMediaInvoicesBy_OrderType.Size = New System.Drawing.Size(101, 20)
            Me.RadioButtonControlAssignMediaInvoicesBy_OrderType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlAssignMediaInvoicesBy_OrderType.TabIndex = 6
            Me.RadioButtonControlAssignMediaInvoicesBy_OrderType.TabOnEnter = True
            Me.RadioButtonControlAssignMediaInvoicesBy_OrderType.TabStop = False
            Me.RadioButtonControlAssignMediaInvoicesBy_OrderType.Text = "Order Type"
            '
            'RadioButtonControlAssignMediaInvoicesBy_OrderNumber
            '
            Me.RadioButtonControlAssignMediaInvoicesBy_OrderNumber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlAssignMediaInvoicesBy_OrderNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlAssignMediaInvoicesBy_OrderNumber.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlAssignMediaInvoicesBy_OrderNumber.Checked = True
            Me.RadioButtonControlAssignMediaInvoicesBy_OrderNumber.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonControlAssignMediaInvoicesBy_OrderNumber.CheckValue = "4"
            Me.RadioButtonControlAssignMediaInvoicesBy_OrderNumber.CheckValueChecked = "4"
            Me.RadioButtonControlAssignMediaInvoicesBy_OrderNumber.CheckValueUnchecked = "0"
            Me.RadioButtonControlAssignMediaInvoicesBy_OrderNumber.Location = New System.Drawing.Point(433, 25)
            Me.RadioButtonControlAssignMediaInvoicesBy_OrderNumber.Name = "RadioButtonControlAssignMediaInvoicesBy_OrderNumber"
            Me.RadioButtonControlAssignMediaInvoicesBy_OrderNumber.SecurityEnabled = True
            Me.RadioButtonControlAssignMediaInvoicesBy_OrderNumber.Size = New System.Drawing.Size(101, 20)
            Me.RadioButtonControlAssignMediaInvoicesBy_OrderNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlAssignMediaInvoicesBy_OrderNumber.TabIndex = 5
            Me.RadioButtonControlAssignMediaInvoicesBy_OrderNumber.TabOnEnter = True
            Me.RadioButtonControlAssignMediaInvoicesBy_OrderNumber.TabStop = False
            Me.RadioButtonControlAssignMediaInvoicesBy_OrderNumber.Text = "Order #"
            '
            'RadioButtonControlAssignMediaInvoicesBy_Market
            '
            Me.RadioButtonControlAssignMediaInvoicesBy_Market.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlAssignMediaInvoicesBy_Market.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlAssignMediaInvoicesBy_Market.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlAssignMediaInvoicesBy_Market.Checked = True
            Me.RadioButtonControlAssignMediaInvoicesBy_Market.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonControlAssignMediaInvoicesBy_Market.CheckValue = "3"
            Me.RadioButtonControlAssignMediaInvoicesBy_Market.CheckValueChecked = "3"
            Me.RadioButtonControlAssignMediaInvoicesBy_Market.CheckValueUnchecked = "0"
            Me.RadioButtonControlAssignMediaInvoicesBy_Market.Location = New System.Drawing.Point(112, 25)
            Me.RadioButtonControlAssignMediaInvoicesBy_Market.Name = "RadioButtonControlAssignMediaInvoicesBy_Market"
            Me.RadioButtonControlAssignMediaInvoicesBy_Market.SecurityEnabled = True
            Me.RadioButtonControlAssignMediaInvoicesBy_Market.Size = New System.Drawing.Size(101, 20)
            Me.RadioButtonControlAssignMediaInvoicesBy_Market.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlAssignMediaInvoicesBy_Market.TabIndex = 2
            Me.RadioButtonControlAssignMediaInvoicesBy_Market.TabOnEnter = True
            Me.RadioButtonControlAssignMediaInvoicesBy_Market.TabStop = False
            Me.RadioButtonControlAssignMediaInvoicesBy_Market.Text = "Market"
            '
            'RadioButtonControlAssignMediaInvoicesBy_ClientPO
            '
            Me.RadioButtonControlAssignMediaInvoicesBy_ClientPO.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlAssignMediaInvoicesBy_ClientPO.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlAssignMediaInvoicesBy_ClientPO.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlAssignMediaInvoicesBy_ClientPO.Checked = True
            Me.RadioButtonControlAssignMediaInvoicesBy_ClientPO.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonControlAssignMediaInvoicesBy_ClientPO.CheckValue = "2"
            Me.RadioButtonControlAssignMediaInvoicesBy_ClientPO.CheckValueChecked = "2"
            Me.RadioButtonControlAssignMediaInvoicesBy_ClientPO.CheckValueUnchecked = "0"
            Me.RadioButtonControlAssignMediaInvoicesBy_ClientPO.Location = New System.Drawing.Point(326, 25)
            Me.RadioButtonControlAssignMediaInvoicesBy_ClientPO.Name = "RadioButtonControlAssignMediaInvoicesBy_ClientPO"
            Me.RadioButtonControlAssignMediaInvoicesBy_ClientPO.SecurityEnabled = True
            Me.RadioButtonControlAssignMediaInvoicesBy_ClientPO.Size = New System.Drawing.Size(101, 20)
            Me.RadioButtonControlAssignMediaInvoicesBy_ClientPO.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlAssignMediaInvoicesBy_ClientPO.TabIndex = 4
            Me.RadioButtonControlAssignMediaInvoicesBy_ClientPO.TabOnEnter = True
            Me.RadioButtonControlAssignMediaInvoicesBy_ClientPO.TabStop = False
            Me.RadioButtonControlAssignMediaInvoicesBy_ClientPO.Text = "Client P.O."
            '
            'RadioButtonControlAssignMediaInvoicesBy_SalesClass
            '
            Me.RadioButtonControlAssignMediaInvoicesBy_SalesClass.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlAssignMediaInvoicesBy_SalesClass.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlAssignMediaInvoicesBy_SalesClass.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlAssignMediaInvoicesBy_SalesClass.Checked = True
            Me.RadioButtonControlAssignMediaInvoicesBy_SalesClass.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonControlAssignMediaInvoicesBy_SalesClass.CheckValue = "1"
            Me.RadioButtonControlAssignMediaInvoicesBy_SalesClass.CheckValueChecked = "1"
            Me.RadioButtonControlAssignMediaInvoicesBy_SalesClass.CheckValueUnchecked = "0"
            Me.RadioButtonControlAssignMediaInvoicesBy_SalesClass.Location = New System.Drawing.Point(5, 25)
            Me.RadioButtonControlAssignMediaInvoicesBy_SalesClass.Name = "RadioButtonControlAssignMediaInvoicesBy_SalesClass"
            Me.RadioButtonControlAssignMediaInvoicesBy_SalesClass.SecurityEnabled = True
            Me.RadioButtonControlAssignMediaInvoicesBy_SalesClass.Size = New System.Drawing.Size(101, 20)
            Me.RadioButtonControlAssignMediaInvoicesBy_SalesClass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlAssignMediaInvoicesBy_SalesClass.TabIndex = 1
            Me.RadioButtonControlAssignMediaInvoicesBy_SalesClass.TabOnEnter = True
            Me.RadioButtonControlAssignMediaInvoicesBy_SalesClass.TabStop = False
            Me.RadioButtonControlAssignMediaInvoicesBy_SalesClass.Text = "Sales Class"
            '
            'RadioButtonControlAssignMediaInvoicesBy_Campaign
            '
            Me.RadioButtonControlAssignMediaInvoicesBy_Campaign.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlAssignMediaInvoicesBy_Campaign.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlAssignMediaInvoicesBy_Campaign.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlAssignMediaInvoicesBy_Campaign.Checked = True
            Me.RadioButtonControlAssignMediaInvoicesBy_Campaign.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonControlAssignMediaInvoicesBy_Campaign.CheckValue = "5"
            Me.RadioButtonControlAssignMediaInvoicesBy_Campaign.CheckValueChecked = "5"
            Me.RadioButtonControlAssignMediaInvoicesBy_Campaign.CheckValueUnchecked = "0"
            Me.RadioButtonControlAssignMediaInvoicesBy_Campaign.Location = New System.Drawing.Point(219, 25)
            Me.RadioButtonControlAssignMediaInvoicesBy_Campaign.Name = "RadioButtonControlAssignMediaInvoicesBy_Campaign"
            Me.RadioButtonControlAssignMediaInvoicesBy_Campaign.SecurityEnabled = True
            Me.RadioButtonControlAssignMediaInvoicesBy_Campaign.Size = New System.Drawing.Size(101, 20)
            Me.RadioButtonControlAssignMediaInvoicesBy_Campaign.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlAssignMediaInvoicesBy_Campaign.TabIndex = 3
            Me.RadioButtonControlAssignMediaInvoicesBy_Campaign.TabOnEnter = True
            Me.RadioButtonControlAssignMediaInvoicesBy_Campaign.TabStop = False
            Me.RadioButtonControlAssignMediaInvoicesBy_Campaign.Text = "Campaign"
            '
            'TextBoxMedia_AttentionLine
            '
            Me.TextBoxMedia_AttentionLine.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxMedia_AttentionLine.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxMedia_AttentionLine.Border.Class = "TextBoxBorder"
            Me.TextBoxMedia_AttentionLine.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxMedia_AttentionLine.CheckSpellingOnValidate = False
            Me.TextBoxMedia_AttentionLine.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxMedia_AttentionLine.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxMedia_AttentionLine.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxMedia_AttentionLine.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxMedia_AttentionLine.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxMedia_AttentionLine.FocusHighlightEnabled = True
            Me.TextBoxMedia_AttentionLine.ForeColor = System.Drawing.Color.Black
            Me.TextBoxMedia_AttentionLine.Location = New System.Drawing.Point(162, 62)
            Me.TextBoxMedia_AttentionLine.MaxFileSize = CType(0, Long)
            Me.TextBoxMedia_AttentionLine.Name = "TextBoxMedia_AttentionLine"
            Me.TextBoxMedia_AttentionLine.SecurityEnabled = True
            Me.TextBoxMedia_AttentionLine.ShowSpellCheckCompleteMessage = True
            Me.TextBoxMedia_AttentionLine.Size = New System.Drawing.Size(677, 20)
            Me.TextBoxMedia_AttentionLine.StartingFolderName = Nothing
            Me.TextBoxMedia_AttentionLine.TabIndex = 2
            Me.TextBoxMedia_AttentionLine.TabOnEnter = True
            '
            'LabelMedia_InvoiceFooterComments
            '
            Me.LabelMedia_InvoiceFooterComments.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMedia_InvoiceFooterComments.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMedia_InvoiceFooterComments.Location = New System.Drawing.Point(6, 88)
            Me.LabelMedia_InvoiceFooterComments.Name = "LabelMedia_InvoiceFooterComments"
            Me.LabelMedia_InvoiceFooterComments.Size = New System.Drawing.Size(150, 20)
            Me.LabelMedia_InvoiceFooterComments.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMedia_InvoiceFooterComments.TabIndex = 3
            Me.LabelMedia_InvoiceFooterComments.Text = "Invoice Footer Comments:"
            '
            'LabelMedia_AttentionLine
            '
            Me.LabelMedia_AttentionLine.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMedia_AttentionLine.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMedia_AttentionLine.Location = New System.Drawing.Point(6, 62)
            Me.LabelMedia_AttentionLine.Name = "LabelMedia_AttentionLine"
            Me.LabelMedia_AttentionLine.Size = New System.Drawing.Size(150, 20)
            Me.LabelMedia_AttentionLine.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMedia_AttentionLine.TabIndex = 1
            Me.LabelMedia_AttentionLine.Text = "Attention Line:"
            '
            'TextBoxMedia_InvoiceFooterComments
            '
            Me.TextBoxMedia_InvoiceFooterComments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxMedia_InvoiceFooterComments.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxMedia_InvoiceFooterComments.Border.Class = "TextBoxBorder"
            Me.TextBoxMedia_InvoiceFooterComments.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxMedia_InvoiceFooterComments.CheckSpellingOnValidate = False
            Me.TextBoxMedia_InvoiceFooterComments.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxMedia_InvoiceFooterComments.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxMedia_InvoiceFooterComments.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxMedia_InvoiceFooterComments.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxMedia_InvoiceFooterComments.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxMedia_InvoiceFooterComments.FocusHighlightEnabled = True
            Me.TextBoxMedia_InvoiceFooterComments.ForeColor = System.Drawing.Color.Black
            Me.TextBoxMedia_InvoiceFooterComments.Location = New System.Drawing.Point(162, 88)
            Me.TextBoxMedia_InvoiceFooterComments.MaxFileSize = CType(0, Long)
            Me.TextBoxMedia_InvoiceFooterComments.Name = "TextBoxMedia_InvoiceFooterComments"
            Me.TextBoxMedia_InvoiceFooterComments.SecurityEnabled = True
            Me.TextBoxMedia_InvoiceFooterComments.ShowSpellCheckCompleteMessage = True
            Me.TextBoxMedia_InvoiceFooterComments.Size = New System.Drawing.Size(677, 20)
            Me.TextBoxMedia_InvoiceFooterComments.StartingFolderName = Nothing
            Me.TextBoxMedia_InvoiceFooterComments.TabIndex = 4
            Me.TextBoxMedia_InvoiceFooterComments.TabOnEnter = True
            '
            'TabItemClientDetails_MediaTab
            '
            Me.TabItemClientDetails_MediaTab.AttachedControl = Me.TabControlPanelMediaTab_Media
            Me.TabItemClientDetails_MediaTab.Name = "TabItemClientDetails_MediaTab"
            Me.TabItemClientDetails_MediaTab.Text = "Media"
            '
            'TabControlPanelDivisionTab_Division
            '
            Me.TabControlPanelDivisionTab_Division.Controls.Add(Me.PanelDivision_RightSection)
            Me.TabControlPanelDivisionTab_Division.Controls.Add(Me.ExpandableSplitterControlDivision_LeftRight)
            Me.TabControlPanelDivisionTab_Division.Controls.Add(Me.PanelDivision_LeftSection)
            Me.TabControlPanelDivisionTab_Division.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelDivisionTab_Division.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelDivisionTab_Division.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelDivisionTab_Division.Name = "TabControlPanelDivisionTab_Division"
            Me.TabControlPanelDivisionTab_Division.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelDivisionTab_Division.Size = New System.Drawing.Size(845, 505)
            Me.TabControlPanelDivisionTab_Division.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelDivisionTab_Division.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDivisionTab_Division.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelDivisionTab_Division.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelDivisionTab_Division.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelDivisionTab_Division.Style.GradientAngle = 90
            Me.TabControlPanelDivisionTab_Division.TabIndex = 4
            Me.TabControlPanelDivisionTab_Division.TabItem = Me.TabItemClientDetails_DivisionProductTab
            '
            'PanelDivision_RightSection
            '
            Me.PanelDivision_RightSection.Controls.Add(Me.ButtonRightSection_Delete)
            Me.PanelDivision_RightSection.Controls.Add(Me.ButtonRightSection_Add)
            Me.PanelDivision_RightSection.Controls.Add(Me.ButtonRightSection_Edit)
            Me.PanelDivision_RightSection.Controls.Add(Me.ButtonRightSection_ProductCopy)
            Me.PanelDivision_RightSection.Controls.Add(Me.DataGridViewRightSection_Products)
            Me.PanelDivision_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelDivision_RightSection.Location = New System.Drawing.Point(367, 1)
            Me.PanelDivision_RightSection.Name = "PanelDivision_RightSection"
            Me.PanelDivision_RightSection.Size = New System.Drawing.Size(477, 503)
            Me.PanelDivision_RightSection.TabIndex = 0
            '
            'ButtonRightSection_Delete
            '
            Me.ButtonRightSection_Delete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_Delete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonRightSection_Delete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_Delete.Location = New System.Drawing.Point(397, 478)
            Me.ButtonRightSection_Delete.Name = "ButtonRightSection_Delete"
            Me.ButtonRightSection_Delete.SecurityEnabled = True
            Me.ButtonRightSection_Delete.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightSection_Delete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_Delete.TabIndex = 8
            Me.ButtonRightSection_Delete.Text = "Delete"
            Me.ButtonRightSection_Delete.Visible = False
            '
            'ButtonRightSection_Add
            '
            Me.ButtonRightSection_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_Add.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonRightSection_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_Add.Location = New System.Drawing.Point(154, 478)
            Me.ButtonRightSection_Add.Name = "ButtonRightSection_Add"
            Me.ButtonRightSection_Add.SecurityEnabled = True
            Me.ButtonRightSection_Add.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightSection_Add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_Add.TabIndex = 1
            Me.ButtonRightSection_Add.Text = "Add"
            Me.ButtonRightSection_Add.Visible = False
            '
            'ButtonRightSection_Edit
            '
            Me.ButtonRightSection_Edit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_Edit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonRightSection_Edit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_Edit.Location = New System.Drawing.Point(235, 478)
            Me.ButtonRightSection_Edit.Name = "ButtonRightSection_Edit"
            Me.ButtonRightSection_Edit.SecurityEnabled = True
            Me.ButtonRightSection_Edit.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightSection_Edit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_Edit.TabIndex = 2
            Me.ButtonRightSection_Edit.Text = "Edit"
            Me.ButtonRightSection_Edit.Visible = False
            '
            'ButtonRightSection_ProductCopy
            '
            Me.ButtonRightSection_ProductCopy.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_ProductCopy.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonRightSection_ProductCopy.AutoExpandOnClick = True
            Me.ButtonRightSection_ProductCopy.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_ProductCopy.Location = New System.Drawing.Point(316, 478)
            Me.ButtonRightSection_ProductCopy.Name = "ButtonRightSection_ProductCopy"
            Me.ButtonRightSection_ProductCopy.SecurityEnabled = True
            Me.ButtonRightSection_ProductCopy.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightSection_ProductCopy.SplitButton = True
            Me.ButtonRightSection_ProductCopy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_ProductCopy.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemProductCopy_From, Me.ButtonItemProductCopy_To})
            Me.ButtonRightSection_ProductCopy.TabIndex = 3
            Me.ButtonRightSection_ProductCopy.Text = "Copy"
            Me.ButtonRightSection_ProductCopy.Visible = False
            '
            'ButtonItemProductCopy_From
            '
            Me.ButtonItemProductCopy_From.GlobalItem = False
            Me.ButtonItemProductCopy_From.Name = "ButtonItemProductCopy_From"
            Me.ButtonItemProductCopy_From.Text = "From"
            '
            'ButtonItemProductCopy_To
            '
            Me.ButtonItemProductCopy_To.GlobalItem = False
            Me.ButtonItemProductCopy_To.Name = "ButtonItemProductCopy_To"
            Me.ButtonItemProductCopy_To.Text = "To"
            '
            'DataGridViewRightSection_Products
            '
            Me.DataGridViewRightSection_Products.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewRightSection_Products.AllowDragAndDrop = False
            Me.DataGridViewRightSection_Products.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewRightSection_Products.AllowSelectGroupHeaderRow = True
            Me.DataGridViewRightSection_Products.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewRightSection_Products.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRightSection_Products.AutoFilterLookupColumns = False
            Me.DataGridViewRightSection_Products.AutoloadRepositoryDatasource = True
            Me.DataGridViewRightSection_Products.AutoUpdateViewCaption = True
            Me.DataGridViewRightSection_Products.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewRightSection_Products.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewRightSection_Products.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRightSection_Products.ItemDescription = ""
            Me.DataGridViewRightSection_Products.Location = New System.Drawing.Point(6, 6)
            Me.DataGridViewRightSection_Products.MultiSelect = True
            Me.DataGridViewRightSection_Products.Name = "DataGridViewRightSection_Products"
            Me.DataGridViewRightSection_Products.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewRightSection_Products.RunStandardValidation = True
            Me.DataGridViewRightSection_Products.ShowColumnMenuOnRightClick = False
            Me.DataGridViewRightSection_Products.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRightSection_Products.Size = New System.Drawing.Size(466, 466)
            Me.DataGridViewRightSection_Products.TabIndex = 0
            Me.DataGridViewRightSection_Products.UseEmbeddedNavigator = False
            Me.DataGridViewRightSection_Products.ViewCaptionHeight = -1
            '
            'ExpandableSplitterControlDivision_LeftRight
            '
            Me.ExpandableSplitterControlDivision_LeftRight.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlDivision_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlDivision_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlDivision_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControlDivision_LeftRight.ExpandableControl = Me.PanelDivision_LeftSection
            Me.ExpandableSplitterControlDivision_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlDivision_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlDivision_LeftRight.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlDivision_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlDivision_LeftRight.ForeColor = System.Drawing.Color.Black
            Me.ExpandableSplitterControlDivision_LeftRight.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlDivision_LeftRight.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlDivision_LeftRight.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlDivision_LeftRight.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlDivision_LeftRight.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControlDivision_LeftRight.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControlDivision_LeftRight.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControlDivision_LeftRight.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControlDivision_LeftRight.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlDivision_LeftRight.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlDivision_LeftRight.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlDivision_LeftRight.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlDivision_LeftRight.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlDivision_LeftRight.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlDivision_LeftRight.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlDivision_LeftRight.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlDivision_LeftRight.Location = New System.Drawing.Point(361, 1)
            Me.ExpandableSplitterControlDivision_LeftRight.Name = "ExpandableSplitterControlDivision_LeftRight"
            Me.ExpandableSplitterControlDivision_LeftRight.Size = New System.Drawing.Size(6, 503)
            Me.ExpandableSplitterControlDivision_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlDivision_LeftRight.TabIndex = 1
            Me.ExpandableSplitterControlDivision_LeftRight.TabStop = False
            '
            'PanelDivision_LeftSection
            '
            Me.PanelDivision_LeftSection.Controls.Add(Me.ButtonLeftSection_Delete)
            Me.PanelDivision_LeftSection.Controls.Add(Me.ButtonLeftSection_DivisionCopy)
            Me.PanelDivision_LeftSection.Controls.Add(Me.ButtonLeftSection_Edit)
            Me.PanelDivision_LeftSection.Controls.Add(Me.ButtonLeftSection_Add)
            Me.PanelDivision_LeftSection.Controls.Add(Me.DataGridViewLeftSection_Divisions)
            Me.PanelDivision_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelDivision_LeftSection.Location = New System.Drawing.Point(1, 1)
            Me.PanelDivision_LeftSection.Name = "PanelDivision_LeftSection"
            Me.PanelDivision_LeftSection.Size = New System.Drawing.Size(360, 503)
            Me.PanelDivision_LeftSection.TabIndex = 0
            '
            'ButtonLeftSection_Delete
            '
            Me.ButtonLeftSection_Delete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonLeftSection_Delete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonLeftSection_Delete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonLeftSection_Delete.Location = New System.Drawing.Point(279, 478)
            Me.ButtonLeftSection_Delete.Name = "ButtonLeftSection_Delete"
            Me.ButtonLeftSection_Delete.SecurityEnabled = True
            Me.ButtonLeftSection_Delete.Size = New System.Drawing.Size(75, 20)
            Me.ButtonLeftSection_Delete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonLeftSection_Delete.TabIndex = 7
            Me.ButtonLeftSection_Delete.Text = "Delete"
            Me.ButtonLeftSection_Delete.Visible = False
            '
            'ButtonLeftSection_DivisionCopy
            '
            Me.ButtonLeftSection_DivisionCopy.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonLeftSection_DivisionCopy.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonLeftSection_DivisionCopy.AutoExpandOnClick = True
            Me.ButtonLeftSection_DivisionCopy.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonLeftSection_DivisionCopy.Location = New System.Drawing.Point(198, 478)
            Me.ButtonLeftSection_DivisionCopy.Name = "ButtonLeftSection_DivisionCopy"
            Me.ButtonLeftSection_DivisionCopy.SecurityEnabled = True
            Me.ButtonLeftSection_DivisionCopy.Size = New System.Drawing.Size(75, 20)
            Me.ButtonLeftSection_DivisionCopy.SplitButton = True
            Me.ButtonLeftSection_DivisionCopy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonLeftSection_DivisionCopy.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDivisionCopy_From, Me.ButtonItemDivisionCopy_To})
            Me.ButtonLeftSection_DivisionCopy.TabIndex = 6
            Me.ButtonLeftSection_DivisionCopy.Text = "Copy"
            Me.ButtonLeftSection_DivisionCopy.Visible = False
            '
            'ButtonItemDivisionCopy_From
            '
            Me.ButtonItemDivisionCopy_From.GlobalItem = False
            Me.ButtonItemDivisionCopy_From.Name = "ButtonItemDivisionCopy_From"
            Me.ButtonItemDivisionCopy_From.Text = "From"
            '
            'ButtonItemDivisionCopy_To
            '
            Me.ButtonItemDivisionCopy_To.GlobalItem = False
            Me.ButtonItemDivisionCopy_To.Name = "ButtonItemDivisionCopy_To"
            Me.ButtonItemDivisionCopy_To.Text = "To"
            '
            'ButtonLeftSection_Edit
            '
            Me.ButtonLeftSection_Edit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonLeftSection_Edit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonLeftSection_Edit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonLeftSection_Edit.Location = New System.Drawing.Point(117, 478)
            Me.ButtonLeftSection_Edit.Name = "ButtonLeftSection_Edit"
            Me.ButtonLeftSection_Edit.SecurityEnabled = True
            Me.ButtonLeftSection_Edit.Size = New System.Drawing.Size(75, 20)
            Me.ButtonLeftSection_Edit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonLeftSection_Edit.TabIndex = 5
            Me.ButtonLeftSection_Edit.Text = "Edit"
            Me.ButtonLeftSection_Edit.Visible = False
            '
            'ButtonLeftSection_Add
            '
            Me.ButtonLeftSection_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonLeftSection_Add.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonLeftSection_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonLeftSection_Add.Location = New System.Drawing.Point(36, 478)
            Me.ButtonLeftSection_Add.Name = "ButtonLeftSection_Add"
            Me.ButtonLeftSection_Add.SecurityEnabled = True
            Me.ButtonLeftSection_Add.Size = New System.Drawing.Size(75, 20)
            Me.ButtonLeftSection_Add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonLeftSection_Add.TabIndex = 4
            Me.ButtonLeftSection_Add.Text = "Add"
            Me.ButtonLeftSection_Add.Visible = False
            '
            'DataGridViewLeftSection_Divisions
            '
            Me.DataGridViewLeftSection_Divisions.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewLeftSection_Divisions.AllowDragAndDrop = False
            Me.DataGridViewLeftSection_Divisions.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewLeftSection_Divisions.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_Divisions.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_Divisions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_Divisions.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_Divisions.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_Divisions.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_Divisions.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_Divisions.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_Divisions.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_Divisions.ItemDescription = ""
            Me.DataGridViewLeftSection_Divisions.Location = New System.Drawing.Point(4, 6)
            Me.DataGridViewLeftSection_Divisions.MultiSelect = True
            Me.DataGridViewLeftSection_Divisions.Name = "DataGridViewLeftSection_Divisions"
            Me.DataGridViewLeftSection_Divisions.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_Divisions.RunStandardValidation = True
            Me.DataGridViewLeftSection_Divisions.ShowColumnMenuOnRightClick = False
            Me.DataGridViewLeftSection_Divisions.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_Divisions.Size = New System.Drawing.Size(350, 466)
            Me.DataGridViewLeftSection_Divisions.TabIndex = 0
            Me.DataGridViewLeftSection_Divisions.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_Divisions.ViewCaptionHeight = -1
            '
            'TabItemClientDetails_DivisionProductTab
            '
            Me.TabItemClientDetails_DivisionProductTab.AttachedControl = Me.TabControlPanelDivisionTab_Division
            Me.TabItemClientDetails_DivisionProductTab.Name = "TabItemClientDetails_DivisionProductTab"
            Me.TabItemClientDetails_DivisionProductTab.Text = "Division / Product"
            '
            'TabControlPanelAutomatedAssignmentsTab_AutomatedAssignments
            '
            Me.TabControlPanelAutomatedAssignmentsTab_AutomatedAssignments.Controls.Add(Me.LabelAutomatedAssignments_Job)
            Me.TabControlPanelAutomatedAssignmentsTab_AutomatedAssignments.Controls.Add(Me.SearchableComboBoxAutomatedAssignments_Job)
            Me.TabControlPanelAutomatedAssignmentsTab_AutomatedAssignments.Controls.Add(Me.LabelAutomatedAssignments_JobComponent)
            Me.TabControlPanelAutomatedAssignmentsTab_AutomatedAssignments.Controls.Add(Me.SearchableComboBoxAutomatedAssignments_JobComponent)
            Me.TabControlPanelAutomatedAssignmentsTab_AutomatedAssignments.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelAutomatedAssignmentsTab_AutomatedAssignments.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelAutomatedAssignmentsTab_AutomatedAssignments.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelAutomatedAssignmentsTab_AutomatedAssignments.Name = "TabControlPanelAutomatedAssignmentsTab_AutomatedAssignments"
            Me.TabControlPanelAutomatedAssignmentsTab_AutomatedAssignments.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelAutomatedAssignmentsTab_AutomatedAssignments.Size = New System.Drawing.Size(845, 505)
            Me.TabControlPanelAutomatedAssignmentsTab_AutomatedAssignments.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelAutomatedAssignmentsTab_AutomatedAssignments.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelAutomatedAssignmentsTab_AutomatedAssignments.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelAutomatedAssignmentsTab_AutomatedAssignments.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelAutomatedAssignmentsTab_AutomatedAssignments.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelAutomatedAssignmentsTab_AutomatedAssignments.Style.GradientAngle = 90
            Me.TabControlPanelAutomatedAssignmentsTab_AutomatedAssignments.TabIndex = 36
            Me.TabControlPanelAutomatedAssignmentsTab_AutomatedAssignments.TabItem = Me.TabItemClientDetails_AutomatedAssignmentsTab
            '
            'LabelAutomatedAssignments_Job
            '
            Me.LabelAutomatedAssignments_Job.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAutomatedAssignments_Job.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAutomatedAssignments_Job.Location = New System.Drawing.Point(4, 5)
            Me.LabelAutomatedAssignments_Job.Name = "LabelAutomatedAssignments_Job"
            Me.LabelAutomatedAssignments_Job.Size = New System.Drawing.Size(142, 20)
            Me.LabelAutomatedAssignments_Job.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAutomatedAssignments_Job.TabIndex = 0
            Me.LabelAutomatedAssignments_Job.Text = "Default Job:"
            '
            'SearchableComboBoxAutomatedAssignments_Job
            '
            Me.SearchableComboBoxAutomatedAssignments_Job.ActiveFilterString = ""
            Me.SearchableComboBoxAutomatedAssignments_Job.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxAutomatedAssignments_Job.AutoFillMode = False
            Me.SearchableComboBoxAutomatedAssignments_Job.BookmarkingEnabled = False
            Me.SearchableComboBoxAutomatedAssignments_Job.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Job
            Me.SearchableComboBoxAutomatedAssignments_Job.DataSource = Nothing
            Me.SearchableComboBoxAutomatedAssignments_Job.DisableMouseWheel = False
            Me.SearchableComboBoxAutomatedAssignments_Job.DisplayName = ""
            Me.SearchableComboBoxAutomatedAssignments_Job.EnterMoveNextControl = True
            Me.SearchableComboBoxAutomatedAssignments_Job.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxAutomatedAssignments_Job.Location = New System.Drawing.Point(152, 6)
            Me.SearchableComboBoxAutomatedAssignments_Job.Name = "SearchableComboBoxAutomatedAssignments_Job"
            Me.SearchableComboBoxAutomatedAssignments_Job.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxAutomatedAssignments_Job.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxAutomatedAssignments_Job.Properties.NullText = "Select Job"
            Me.SearchableComboBoxAutomatedAssignments_Job.Properties.PopupView = Me.GridView10
            Me.SearchableComboBoxAutomatedAssignments_Job.Properties.ShowClearButton = False
            Me.SearchableComboBoxAutomatedAssignments_Job.Properties.ValueMember = "Number"
            Me.SearchableComboBoxAutomatedAssignments_Job.SecurityEnabled = True
            Me.SearchableComboBoxAutomatedAssignments_Job.SelectedValue = Nothing
            Me.SearchableComboBoxAutomatedAssignments_Job.Size = New System.Drawing.Size(300, 20)
            Me.SearchableComboBoxAutomatedAssignments_Job.TabIndex = 1
            '
            'GridView10
            '
            Me.GridView10.AFActiveFilterString = ""
            Me.GridView10.AllowExtraItemsInGridLookupEdits = True
            Me.GridView10.AutoFilterLookupColumns = False
            Me.GridView10.AutoloadRepositoryDatasource = True
            Me.GridView10.DataSourceClearing = False
            Me.GridView10.EnableDisabledRows = False
            Me.GridView10.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView10.Name = "GridView10"
            Me.GridView10.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView10.OptionsView.ShowGroupPanel = False
            Me.GridView10.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView10.RunStandardValidation = True
            Me.GridView10.SkipAddingControlsOnModifyColumn = False
            Me.GridView10.SkipSettingFontOnModifyColumn = False
            '
            'LabelAutomatedAssignments_JobComponent
            '
            Me.LabelAutomatedAssignments_JobComponent.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAutomatedAssignments_JobComponent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAutomatedAssignments_JobComponent.Location = New System.Drawing.Point(5, 31)
            Me.LabelAutomatedAssignments_JobComponent.Name = "LabelAutomatedAssignments_JobComponent"
            Me.LabelAutomatedAssignments_JobComponent.Size = New System.Drawing.Size(141, 20)
            Me.LabelAutomatedAssignments_JobComponent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAutomatedAssignments_JobComponent.TabIndex = 2
            Me.LabelAutomatedAssignments_JobComponent.Text = "Default Job Component:"
            '
            'SearchableComboBoxAutomatedAssignments_JobComponent
            '
            Me.SearchableComboBoxAutomatedAssignments_JobComponent.ActiveFilterString = ""
            Me.SearchableComboBoxAutomatedAssignments_JobComponent.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxAutomatedAssignments_JobComponent.AutoFillMode = False
            Me.SearchableComboBoxAutomatedAssignments_JobComponent.BookmarkingEnabled = False
            Me.SearchableComboBoxAutomatedAssignments_JobComponent.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.JobComponent
            Me.SearchableComboBoxAutomatedAssignments_JobComponent.DataSource = Nothing
            Me.SearchableComboBoxAutomatedAssignments_JobComponent.DisableMouseWheel = False
            Me.SearchableComboBoxAutomatedAssignments_JobComponent.DisplayName = ""
            Me.SearchableComboBoxAutomatedAssignments_JobComponent.EnterMoveNextControl = True
            Me.SearchableComboBoxAutomatedAssignments_JobComponent.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxAutomatedAssignments_JobComponent.Location = New System.Drawing.Point(152, 31)
            Me.SearchableComboBoxAutomatedAssignments_JobComponent.Name = "SearchableComboBoxAutomatedAssignments_JobComponent"
            Me.SearchableComboBoxAutomatedAssignments_JobComponent.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxAutomatedAssignments_JobComponent.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxAutomatedAssignments_JobComponent.Properties.NullText = "Select Job Component"
            Me.SearchableComboBoxAutomatedAssignments_JobComponent.Properties.PopupView = Me.GridView9
            Me.SearchableComboBoxAutomatedAssignments_JobComponent.Properties.ShowClearButton = False
            Me.SearchableComboBoxAutomatedAssignments_JobComponent.Properties.ValueMember = "Number"
            Me.SearchableComboBoxAutomatedAssignments_JobComponent.SecurityEnabled = True
            Me.SearchableComboBoxAutomatedAssignments_JobComponent.SelectedValue = Nothing
            Me.SearchableComboBoxAutomatedAssignments_JobComponent.Size = New System.Drawing.Size(300, 20)
            Me.SearchableComboBoxAutomatedAssignments_JobComponent.TabIndex = 3
            '
            'GridView9
            '
            Me.GridView9.AFActiveFilterString = ""
            Me.GridView9.AllowExtraItemsInGridLookupEdits = True
            Me.GridView9.AutoFilterLookupColumns = False
            Me.GridView9.AutoloadRepositoryDatasource = True
            Me.GridView9.DataSourceClearing = False
            Me.GridView9.EnableDisabledRows = False
            Me.GridView9.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView9.Name = "GridView9"
            Me.GridView9.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView9.OptionsView.ShowGroupPanel = False
            Me.GridView9.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView9.RunStandardValidation = True
            Me.GridView9.SkipAddingControlsOnModifyColumn = False
            Me.GridView9.SkipSettingFontOnModifyColumn = False
            '
            'TabItemClientDetails_AutomatedAssignmentsTab
            '
            Me.TabItemClientDetails_AutomatedAssignmentsTab.AttachedControl = Me.TabControlPanelAutomatedAssignmentsTab_AutomatedAssignments
            Me.TabItemClientDetails_AutomatedAssignmentsTab.Name = "TabItemClientDetails_AutomatedAssignmentsTab"
            Me.TabItemClientDetails_AutomatedAssignmentsTab.Text = "Automated Assignments"
            '
            'TabControlPanelBillingTab_Billing
            '
            Me.TabControlPanelBillingTab_Billing.Controls.Add(Me.GroupBoxBilling_LatePaymentFee)
            Me.TabControlPanelBillingTab_Billing.Controls.Add(Me.GroupBoxBilling_ARComment)
            Me.TabControlPanelBillingTab_Billing.Controls.Add(Me.GroupBoxBilling_AssignComboInvoicesBy)
            Me.TabControlPanelBillingTab_Billing.Controls.Add(Me.LabelBilling_Location)
            Me.TabControlPanelBillingTab_Billing.Controls.Add(Me.GroupBoxBilling_Avalara)
            Me.TabControlPanelBillingTab_Billing.Controls.Add(Me.GroupBoxBilling_Options)
            Me.TabControlPanelBillingTab_Billing.Controls.Add(Me.TableLayoutPanelBilling_AddressLayout)
            Me.TabControlPanelBillingTab_Billing.Controls.Add(Me.SearchableComboBoxBilling_Location)
            Me.TabControlPanelBillingTab_Billing.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelBillingTab_Billing.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelBillingTab_Billing.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelBillingTab_Billing.Name = "TabControlPanelBillingTab_Billing"
            Me.TabControlPanelBillingTab_Billing.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelBillingTab_Billing.Size = New System.Drawing.Size(845, 505)
            Me.TabControlPanelBillingTab_Billing.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelBillingTab_Billing.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelBillingTab_Billing.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelBillingTab_Billing.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelBillingTab_Billing.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelBillingTab_Billing.Style.GradientAngle = 90
            Me.TabControlPanelBillingTab_Billing.TabIndex = 5
            Me.TabControlPanelBillingTab_Billing.TabItem = Me.TabItemClientDetails_BillingTab
            '
            'GroupBoxBilling_LatePaymentFee
            '
            Me.GroupBoxBilling_LatePaymentFee.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxBilling_LatePaymentFee.Controls.Add(Me.NumericInputLatePaymentFee_Percentage)
            Me.GroupBoxBilling_LatePaymentFee.Controls.Add(Me.LabelLatePaymentFee_Percentage)
            Me.GroupBoxBilling_LatePaymentFee.Controls.Add(Me.CheckBoxLatePaymentFee_Calculate)
            Me.GroupBoxBilling_LatePaymentFee.Location = New System.Drawing.Point(260, 331)
            Me.GroupBoxBilling_LatePaymentFee.Name = "GroupBoxBilling_LatePaymentFee"
            Me.GroupBoxBilling_LatePaymentFee.Size = New System.Drawing.Size(579, 51)
            Me.GroupBoxBilling_LatePaymentFee.TabIndex = 7
            Me.GroupBoxBilling_LatePaymentFee.Text = "Late Payment Fee"
            '
            'NumericInputLatePaymentFee_Percentage
            '
            Me.NumericInputLatePaymentFee_Percentage.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputLatePaymentFee_Percentage.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputLatePaymentFee_Percentage.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputLatePaymentFee_Percentage.EnterMoveNextControl = True
            Me.NumericInputLatePaymentFee_Percentage.Location = New System.Drawing.Point(193, 24)
            Me.NumericInputLatePaymentFee_Percentage.Name = "NumericInputLatePaymentFee_Percentage"
            Me.NumericInputLatePaymentFee_Percentage.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputLatePaymentFee_Percentage.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputLatePaymentFee_Percentage.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputLatePaymentFee_Percentage.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputLatePaymentFee_Percentage.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputLatePaymentFee_Percentage.Properties.EditFormat.FormatString = "f"
            Me.NumericInputLatePaymentFee_Percentage.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputLatePaymentFee_Percentage.Properties.Mask.EditMask = "f"
            Me.NumericInputLatePaymentFee_Percentage.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputLatePaymentFee_Percentage.SecurityEnabled = True
            Me.NumericInputLatePaymentFee_Percentage.Size = New System.Drawing.Size(125, 20)
            Me.NumericInputLatePaymentFee_Percentage.TabIndex = 7
            '
            'LabelLatePaymentFee_Percentage
            '
            Me.LabelLatePaymentFee_Percentage.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelLatePaymentFee_Percentage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelLatePaymentFee_Percentage.Location = New System.Drawing.Point(107, 24)
            Me.LabelLatePaymentFee_Percentage.Name = "LabelLatePaymentFee_Percentage"
            Me.LabelLatePaymentFee_Percentage.Size = New System.Drawing.Size(80, 20)
            Me.LabelLatePaymentFee_Percentage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelLatePaymentFee_Percentage.TabIndex = 6
            Me.LabelLatePaymentFee_Percentage.Text = "Percentage:"
            '
            'CheckBoxLatePaymentFee_Calculate
            '
            Me.CheckBoxLatePaymentFee_Calculate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxLatePaymentFee_Calculate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxLatePaymentFee_Calculate.CheckValue = 0
            Me.CheckBoxLatePaymentFee_Calculate.CheckValueChecked = 1
            Me.CheckBoxLatePaymentFee_Calculate.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxLatePaymentFee_Calculate.CheckValueUnchecked = 0
            Me.CheckBoxLatePaymentFee_Calculate.ChildControls = Nothing
            Me.CheckBoxLatePaymentFee_Calculate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxLatePaymentFee_Calculate.Location = New System.Drawing.Point(10, 24)
            Me.CheckBoxLatePaymentFee_Calculate.Name = "CheckBoxLatePaymentFee_Calculate"
            Me.CheckBoxLatePaymentFee_Calculate.OldestSibling = Nothing
            Me.CheckBoxLatePaymentFee_Calculate.SecurityEnabled = True
            Me.CheckBoxLatePaymentFee_Calculate.SiblingControls = Nothing
            Me.CheckBoxLatePaymentFee_Calculate.Size = New System.Drawing.Size(91, 20)
            Me.CheckBoxLatePaymentFee_Calculate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxLatePaymentFee_Calculate.TabIndex = 4
            Me.CheckBoxLatePaymentFee_Calculate.TabOnEnter = True
            Me.CheckBoxLatePaymentFee_Calculate.Text = "Calculate"
            '
            'GroupBoxBilling_ARComment
            '
            Me.GroupBoxBilling_ARComment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxBilling_ARComment.Controls.Add(Me.TextBoxARComment_ARComment)
            Me.GroupBoxBilling_ARComment.Location = New System.Drawing.Point(260, 388)
            Me.GroupBoxBilling_ARComment.Name = "GroupBoxBilling_ARComment"
            Me.GroupBoxBilling_ARComment.Size = New System.Drawing.Size(579, 106)
            Me.GroupBoxBilling_ARComment.TabIndex = 6
            Me.GroupBoxBilling_ARComment.Text = "A/R Comment"
            '
            'TextBoxARComment_ARComment
            '
            Me.TextBoxARComment_ARComment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxARComment_ARComment.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxARComment_ARComment.Border.Class = "TextBoxBorder"
            Me.TextBoxARComment_ARComment.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxARComment_ARComment.CheckSpellingOnValidate = False
            Me.TextBoxARComment_ARComment.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxARComment_ARComment.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxARComment_ARComment.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxARComment_ARComment.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxARComment_ARComment.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxARComment_ARComment.FocusHighlightEnabled = True
            Me.TextBoxARComment_ARComment.ForeColor = System.Drawing.Color.Black
            Me.TextBoxARComment_ARComment.Location = New System.Drawing.Point(6, 26)
            Me.TextBoxARComment_ARComment.MaxFileSize = CType(0, Long)
            Me.TextBoxARComment_ARComment.Multiline = True
            Me.TextBoxARComment_ARComment.Name = "TextBoxARComment_ARComment"
            Me.TextBoxARComment_ARComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.TextBoxARComment_ARComment.SecurityEnabled = True
            Me.TextBoxARComment_ARComment.ShowSpellCheckCompleteMessage = True
            Me.TextBoxARComment_ARComment.Size = New System.Drawing.Size(568, 75)
            Me.TextBoxARComment_ARComment.StartingFolderName = Nothing
            Me.TextBoxARComment_ARComment.TabIndex = 0
            Me.TextBoxARComment_ARComment.TabOnEnter = True
            '
            'GroupBoxBilling_AssignComboInvoicesBy
            '
            Me.GroupBoxBilling_AssignComboInvoicesBy.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxBilling_AssignComboInvoicesBy.Controls.Add(Me.RadioButtonControlAssignComboInvoicesBy_ClientDivision)
            Me.GroupBoxBilling_AssignComboInvoicesBy.Controls.Add(Me.CheckBoxAssignComboInvoicesBy_MediaOnly)
            Me.GroupBoxBilling_AssignComboInvoicesBy.Controls.Add(Me.RadioButtonControlAssignComboInvoicesBy_ClientDivisionProductCampaign)
            Me.GroupBoxBilling_AssignComboInvoicesBy.Controls.Add(Me.RadioButtonControlAssignComboInvoicesBy_ClientDivisionProduct)
            Me.GroupBoxBilling_AssignComboInvoicesBy.Controls.Add(Me.RadioButtonControlAssignComboInvoicesBy_Client)
            Me.GroupBoxBilling_AssignComboInvoicesBy.Controls.Add(Me.RadioButtonControlAssignComboInvoicesBy_ClientCampaign)
            Me.GroupBoxBilling_AssignComboInvoicesBy.Controls.Add(Me.RadioButtonControlAssignComboInvoicesBy_None)
            Me.GroupBoxBilling_AssignComboInvoicesBy.Location = New System.Drawing.Point(260, 223)
            Me.GroupBoxBilling_AssignComboInvoicesBy.Name = "GroupBoxBilling_AssignComboInvoicesBy"
            Me.GroupBoxBilling_AssignComboInvoicesBy.Size = New System.Drawing.Size(579, 102)
            Me.GroupBoxBilling_AssignComboInvoicesBy.TabIndex = 5
            Me.GroupBoxBilling_AssignComboInvoicesBy.TabStop = True
            Me.GroupBoxBilling_AssignComboInvoicesBy.Text = "Assign Combo Invoices By"
            '
            'RadioButtonControlAssignComboInvoicesBy_ClientDivision
            '
            Me.RadioButtonControlAssignComboInvoicesBy_ClientDivision.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlAssignComboInvoicesBy_ClientDivision.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlAssignComboInvoicesBy_ClientDivision.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlAssignComboInvoicesBy_ClientDivision.Location = New System.Drawing.Point(113, 51)
            Me.RadioButtonControlAssignComboInvoicesBy_ClientDivision.Name = "RadioButtonControlAssignComboInvoicesBy_ClientDivision"
            Me.RadioButtonControlAssignComboInvoicesBy_ClientDivision.SecurityEnabled = True
            Me.RadioButtonControlAssignComboInvoicesBy_ClientDivision.Size = New System.Drawing.Size(160, 20)
            Me.RadioButtonControlAssignComboInvoicesBy_ClientDivision.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlAssignComboInvoicesBy_ClientDivision.TabIndex = 6
            Me.RadioButtonControlAssignComboInvoicesBy_ClientDivision.TabOnEnter = True
            Me.RadioButtonControlAssignComboInvoicesBy_ClientDivision.TabStop = False
            Me.RadioButtonControlAssignComboInvoicesBy_ClientDivision.Tag = ""
            Me.RadioButtonControlAssignComboInvoicesBy_ClientDivision.Text = "Client - Division"
            '
            'CheckBoxAssignComboInvoicesBy_MediaOnly
            '
            Me.CheckBoxAssignComboInvoicesBy_MediaOnly.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxAssignComboInvoicesBy_MediaOnly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxAssignComboInvoicesBy_MediaOnly.CheckValue = 0
            Me.CheckBoxAssignComboInvoicesBy_MediaOnly.CheckValueChecked = 1
            Me.CheckBoxAssignComboInvoicesBy_MediaOnly.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxAssignComboInvoicesBy_MediaOnly.CheckValueUnchecked = 0
            Me.CheckBoxAssignComboInvoicesBy_MediaOnly.ChildControls = Nothing
            Me.CheckBoxAssignComboInvoicesBy_MediaOnly.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxAssignComboInvoicesBy_MediaOnly.Location = New System.Drawing.Point(10, 51)
            Me.CheckBoxAssignComboInvoicesBy_MediaOnly.Name = "CheckBoxAssignComboInvoicesBy_MediaOnly"
            Me.CheckBoxAssignComboInvoicesBy_MediaOnly.OldestSibling = Nothing
            Me.CheckBoxAssignComboInvoicesBy_MediaOnly.SecurityEnabled = True
            Me.CheckBoxAssignComboInvoicesBy_MediaOnly.SiblingControls = Nothing
            Me.CheckBoxAssignComboInvoicesBy_MediaOnly.Size = New System.Drawing.Size(91, 20)
            Me.CheckBoxAssignComboInvoicesBy_MediaOnly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxAssignComboInvoicesBy_MediaOnly.TabIndex = 3
            Me.CheckBoxAssignComboInvoicesBy_MediaOnly.TabOnEnter = True
            Me.CheckBoxAssignComboInvoicesBy_MediaOnly.Text = "Media Only"
            '
            'RadioButtonControlAssignComboInvoicesBy_ClientDivisionProductCampaign
            '
            Me.RadioButtonControlAssignComboInvoicesBy_ClientDivisionProductCampaign.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlAssignComboInvoicesBy_ClientDivisionProductCampaign.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlAssignComboInvoicesBy_ClientDivisionProductCampaign.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlAssignComboInvoicesBy_ClientDivisionProductCampaign.Location = New System.Drawing.Point(279, 51)
            Me.RadioButtonControlAssignComboInvoicesBy_ClientDivisionProductCampaign.Name = "RadioButtonControlAssignComboInvoicesBy_ClientDivisionProductCampaign"
            Me.RadioButtonControlAssignComboInvoicesBy_ClientDivisionProductCampaign.SecurityEnabled = True
            Me.RadioButtonControlAssignComboInvoicesBy_ClientDivisionProductCampaign.Size = New System.Drawing.Size(221, 20)
            Me.RadioButtonControlAssignComboInvoicesBy_ClientDivisionProductCampaign.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlAssignComboInvoicesBy_ClientDivisionProductCampaign.TabIndex = 5
            Me.RadioButtonControlAssignComboInvoicesBy_ClientDivisionProductCampaign.TabOnEnter = True
            Me.RadioButtonControlAssignComboInvoicesBy_ClientDivisionProductCampaign.TabStop = False
            Me.RadioButtonControlAssignComboInvoicesBy_ClientDivisionProductCampaign.Tag = ""
            Me.RadioButtonControlAssignComboInvoicesBy_ClientDivisionProductCampaign.Text = "Client - Division - Product / Campaign"
            '
            'RadioButtonControlAssignComboInvoicesBy_ClientDivisionProduct
            '
            Me.RadioButtonControlAssignComboInvoicesBy_ClientDivisionProduct.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlAssignComboInvoicesBy_ClientDivisionProduct.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlAssignComboInvoicesBy_ClientDivisionProduct.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlAssignComboInvoicesBy_ClientDivisionProduct.Location = New System.Drawing.Point(113, 77)
            Me.RadioButtonControlAssignComboInvoicesBy_ClientDivisionProduct.Name = "RadioButtonControlAssignComboInvoicesBy_ClientDivisionProduct"
            Me.RadioButtonControlAssignComboInvoicesBy_ClientDivisionProduct.SecurityEnabled = True
            Me.RadioButtonControlAssignComboInvoicesBy_ClientDivisionProduct.Size = New System.Drawing.Size(160, 20)
            Me.RadioButtonControlAssignComboInvoicesBy_ClientDivisionProduct.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlAssignComboInvoicesBy_ClientDivisionProduct.TabIndex = 4
            Me.RadioButtonControlAssignComboInvoicesBy_ClientDivisionProduct.TabOnEnter = True
            Me.RadioButtonControlAssignComboInvoicesBy_ClientDivisionProduct.TabStop = False
            Me.RadioButtonControlAssignComboInvoicesBy_ClientDivisionProduct.Tag = ""
            Me.RadioButtonControlAssignComboInvoicesBy_ClientDivisionProduct.Text = "Client - Division - Product"
            '
            'RadioButtonControlAssignComboInvoicesBy_Client
            '
            Me.RadioButtonControlAssignComboInvoicesBy_Client.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlAssignComboInvoicesBy_Client.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlAssignComboInvoicesBy_Client.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlAssignComboInvoicesBy_Client.Location = New System.Drawing.Point(113, 25)
            Me.RadioButtonControlAssignComboInvoicesBy_Client.Name = "RadioButtonControlAssignComboInvoicesBy_Client"
            Me.RadioButtonControlAssignComboInvoicesBy_Client.SecurityEnabled = True
            Me.RadioButtonControlAssignComboInvoicesBy_Client.Size = New System.Drawing.Size(160, 20)
            Me.RadioButtonControlAssignComboInvoicesBy_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlAssignComboInvoicesBy_Client.TabIndex = 1
            Me.RadioButtonControlAssignComboInvoicesBy_Client.TabOnEnter = True
            Me.RadioButtonControlAssignComboInvoicesBy_Client.TabStop = False
            Me.RadioButtonControlAssignComboInvoicesBy_Client.Tag = ""
            Me.RadioButtonControlAssignComboInvoicesBy_Client.Text = "Client"
            '
            'RadioButtonControlAssignComboInvoicesBy_ClientCampaign
            '
            Me.RadioButtonControlAssignComboInvoicesBy_ClientCampaign.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlAssignComboInvoicesBy_ClientCampaign.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlAssignComboInvoicesBy_ClientCampaign.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlAssignComboInvoicesBy_ClientCampaign.Location = New System.Drawing.Point(279, 24)
            Me.RadioButtonControlAssignComboInvoicesBy_ClientCampaign.Name = "RadioButtonControlAssignComboInvoicesBy_ClientCampaign"
            Me.RadioButtonControlAssignComboInvoicesBy_ClientCampaign.SecurityEnabled = True
            Me.RadioButtonControlAssignComboInvoicesBy_ClientCampaign.Size = New System.Drawing.Size(221, 20)
            Me.RadioButtonControlAssignComboInvoicesBy_ClientCampaign.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlAssignComboInvoicesBy_ClientCampaign.TabIndex = 2
            Me.RadioButtonControlAssignComboInvoicesBy_ClientCampaign.TabOnEnter = True
            Me.RadioButtonControlAssignComboInvoicesBy_ClientCampaign.TabStop = False
            Me.RadioButtonControlAssignComboInvoicesBy_ClientCampaign.Tag = ""
            Me.RadioButtonControlAssignComboInvoicesBy_ClientCampaign.Text = "Client / Campaign"
            '
            'RadioButtonControlAssignComboInvoicesBy_None
            '
            Me.RadioButtonControlAssignComboInvoicesBy_None.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlAssignComboInvoicesBy_None.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlAssignComboInvoicesBy_None.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlAssignComboInvoicesBy_None.Location = New System.Drawing.Point(10, 25)
            Me.RadioButtonControlAssignComboInvoicesBy_None.Name = "RadioButtonControlAssignComboInvoicesBy_None"
            Me.RadioButtonControlAssignComboInvoicesBy_None.SecurityEnabled = True
            Me.RadioButtonControlAssignComboInvoicesBy_None.Size = New System.Drawing.Size(91, 20)
            Me.RadioButtonControlAssignComboInvoicesBy_None.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlAssignComboInvoicesBy_None.TabIndex = 0
            Me.RadioButtonControlAssignComboInvoicesBy_None.TabOnEnter = True
            Me.RadioButtonControlAssignComboInvoicesBy_None.TabStop = False
            Me.RadioButtonControlAssignComboInvoicesBy_None.Tag = ""
            Me.RadioButtonControlAssignComboInvoicesBy_None.Text = "None"
            '
            'LabelBilling_Location
            '
            Me.LabelBilling_Location.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelBilling_Location.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelBilling_Location.Location = New System.Drawing.Point(267, 478)
            Me.LabelBilling_Location.Name = "LabelBilling_Location"
            Me.LabelBilling_Location.Size = New System.Drawing.Size(51, 20)
            Me.LabelBilling_Location.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelBilling_Location.TabIndex = 1
            Me.LabelBilling_Location.Text = "Location:"
            Me.LabelBilling_Location.Visible = False
            '
            'GroupBoxBilling_Avalara
            '
            Me.GroupBoxBilling_Avalara.Controls.Add(Me.TextBoxBilling_VATNumber)
            Me.GroupBoxBilling_Avalara.Controls.Add(Me.LabelBilling_VATNumber)
            Me.GroupBoxBilling_Avalara.Controls.Add(Me.CheckBoxAvalara_TaxExempt)
            Me.GroupBoxBilling_Avalara.Controls.Add(Me.SearchableComboBoxAvalara_SalesClassCode)
            Me.GroupBoxBilling_Avalara.Controls.Add(Me.LabelAvalara_SalesClass)
            Me.GroupBoxBilling_Avalara.Location = New System.Drawing.Point(5, 388)
            Me.GroupBoxBilling_Avalara.Name = "GroupBoxBilling_Avalara"
            Me.GroupBoxBilling_Avalara.Size = New System.Drawing.Size(248, 106)
            Me.GroupBoxBilling_Avalara.TabIndex = 4
            Me.GroupBoxBilling_Avalara.Text = "Avalara"
            '
            'TextBoxBilling_VATNumber
            '
            Me.TextBoxBilling_VATNumber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxBilling_VATNumber.Border.Class = "TextBoxBorder"
            Me.TextBoxBilling_VATNumber.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxBilling_VATNumber.CheckSpellingOnValidate = False
            Me.TextBoxBilling_VATNumber.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxBilling_VATNumber.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxBilling_VATNumber.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxBilling_VATNumber.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxBilling_VATNumber.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxBilling_VATNumber.FocusHighlightEnabled = True
            Me.TextBoxBilling_VATNumber.ForeColor = System.Drawing.Color.Black
            Me.TextBoxBilling_VATNumber.Location = New System.Drawing.Point(83, 77)
            Me.TextBoxBilling_VATNumber.MaxFileSize = CType(0, Long)
            Me.TextBoxBilling_VATNumber.Name = "TextBoxBilling_VATNumber"
            Me.TextBoxBilling_VATNumber.SecurityEnabled = True
            Me.TextBoxBilling_VATNumber.ShowSpellCheckCompleteMessage = True
            Me.TextBoxBilling_VATNumber.Size = New System.Drawing.Size(160, 21)
            Me.TextBoxBilling_VATNumber.StartingFolderName = Nothing
            Me.TextBoxBilling_VATNumber.TabIndex = 4
            Me.TextBoxBilling_VATNumber.TabOnEnter = True
            '
            'LabelBilling_VATNumber
            '
            Me.LabelBilling_VATNumber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelBilling_VATNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelBilling_VATNumber.Location = New System.Drawing.Point(6, 77)
            Me.LabelBilling_VATNumber.Name = "LabelBilling_VATNumber"
            Me.LabelBilling_VATNumber.Size = New System.Drawing.Size(71, 20)
            Me.LabelBilling_VATNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelBilling_VATNumber.TabIndex = 3
            Me.LabelBilling_VATNumber.Text = "VAT Number:"
            '
            'CheckBoxAvalara_TaxExempt
            '
            Me.CheckBoxAvalara_TaxExempt.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxAvalara_TaxExempt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxAvalara_TaxExempt.CheckValue = 0
            Me.CheckBoxAvalara_TaxExempt.CheckValueChecked = 1
            Me.CheckBoxAvalara_TaxExempt.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxAvalara_TaxExempt.CheckValueUnchecked = 0
            Me.CheckBoxAvalara_TaxExempt.ChildControls = Nothing
            Me.CheckBoxAvalara_TaxExempt.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxAvalara_TaxExempt.Location = New System.Drawing.Point(83, 51)
            Me.CheckBoxAvalara_TaxExempt.Name = "CheckBoxAvalara_TaxExempt"
            Me.CheckBoxAvalara_TaxExempt.OldestSibling = Nothing
            Me.CheckBoxAvalara_TaxExempt.SecurityEnabled = True
            Me.CheckBoxAvalara_TaxExempt.SiblingControls = Nothing
            Me.CheckBoxAvalara_TaxExempt.Size = New System.Drawing.Size(160, 20)
            Me.CheckBoxAvalara_TaxExempt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxAvalara_TaxExempt.TabIndex = 2
            Me.CheckBoxAvalara_TaxExempt.TabOnEnter = True
            Me.CheckBoxAvalara_TaxExempt.Text = "Tax Exempt"
            '
            'SearchableComboBoxAvalara_SalesClassCode
            '
            Me.SearchableComboBoxAvalara_SalesClassCode.ActiveFilterString = ""
            Me.SearchableComboBoxAvalara_SalesClassCode.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxAvalara_SalesClassCode.AutoFillMode = False
            Me.SearchableComboBoxAvalara_SalesClassCode.BookmarkingEnabled = False
            Me.SearchableComboBoxAvalara_SalesClassCode.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.SalesClass
            Me.SearchableComboBoxAvalara_SalesClassCode.DataSource = Nothing
            Me.SearchableComboBoxAvalara_SalesClassCode.DisableMouseWheel = False
            Me.SearchableComboBoxAvalara_SalesClassCode.DisplayName = ""
            Me.SearchableComboBoxAvalara_SalesClassCode.EnterMoveNextControl = True
            Me.SearchableComboBoxAvalara_SalesClassCode.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.None
            Me.SearchableComboBoxAvalara_SalesClassCode.Location = New System.Drawing.Point(83, 25)
            Me.SearchableComboBoxAvalara_SalesClassCode.Name = "SearchableComboBoxAvalara_SalesClassCode"
            Me.SearchableComboBoxAvalara_SalesClassCode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxAvalara_SalesClassCode.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxAvalara_SalesClassCode.Properties.NullText = "Select Sales Class"
            Me.SearchableComboBoxAvalara_SalesClassCode.Properties.PopupView = Me.SearchableComboboxViewAvalara_SalesClass
            Me.SearchableComboBoxAvalara_SalesClassCode.Properties.ShowClearButton = False
            Me.SearchableComboBoxAvalara_SalesClassCode.Properties.ValueMember = "Code"
            Me.SearchableComboBoxAvalara_SalesClassCode.SecurityEnabled = True
            Me.SearchableComboBoxAvalara_SalesClassCode.SelectedValue = Nothing
            Me.SearchableComboBoxAvalara_SalesClassCode.Size = New System.Drawing.Size(160, 20)
            Me.SearchableComboBoxAvalara_SalesClassCode.TabIndex = 1
            '
            'SearchableComboboxViewAvalara_SalesClass
            '
            Me.SearchableComboboxViewAvalara_SalesClass.AFActiveFilterString = ""
            Me.SearchableComboboxViewAvalara_SalesClass.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboboxViewAvalara_SalesClass.AutoFilterLookupColumns = False
            Me.SearchableComboboxViewAvalara_SalesClass.AutoloadRepositoryDatasource = True
            Me.SearchableComboboxViewAvalara_SalesClass.DataSourceClearing = False
            Me.SearchableComboboxViewAvalara_SalesClass.EnableDisabledRows = False
            Me.SearchableComboboxViewAvalara_SalesClass.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboboxViewAvalara_SalesClass.Name = "SearchableComboboxViewAvalara_SalesClass"
            Me.SearchableComboboxViewAvalara_SalesClass.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboboxViewAvalara_SalesClass.OptionsView.ShowGroupPanel = False
            Me.SearchableComboboxViewAvalara_SalesClass.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboboxViewAvalara_SalesClass.RunStandardValidation = True
            Me.SearchableComboboxViewAvalara_SalesClass.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboboxViewAvalara_SalesClass.SkipSettingFontOnModifyColumn = False
            '
            'LabelAvalara_SalesClass
            '
            Me.LabelAvalara_SalesClass.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAvalara_SalesClass.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAvalara_SalesClass.Location = New System.Drawing.Point(6, 24)
            Me.LabelAvalara_SalesClass.Name = "LabelAvalara_SalesClass"
            Me.LabelAvalara_SalesClass.Size = New System.Drawing.Size(71, 20)
            Me.LabelAvalara_SalesClass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAvalara_SalesClass.TabIndex = 0
            Me.LabelAvalara_SalesClass.Text = "Sales Class:"
            '
            'GroupBoxBilling_Options
            '
            Me.GroupBoxBilling_Options.Controls.Add(Me.ComboBoxOptions_Biller)
            Me.GroupBoxBilling_Options.Controls.Add(Me.DateTimePickerOptions_ContractExpirationDate)
            Me.GroupBoxBilling_Options.Controls.Add(Me.LabelOptions_ContractExpirationDate)
            Me.GroupBoxBilling_Options.Controls.Add(Me.LabelOptions_Biller)
            Me.GroupBoxBilling_Options.Controls.Add(Me.ComboBoxOptions_Currency)
            Me.GroupBoxBilling_Options.Controls.Add(Me.LabelOptions_Currency)
            Me.GroupBoxBilling_Options.Controls.Add(Me.NumericInputOptions_CreditLimit)
            Me.GroupBoxBilling_Options.Controls.Add(Me.LabelOptions_FiscalStartMonth)
            Me.GroupBoxBilling_Options.Controls.Add(Me.ComboBoxOptions_FiscalStartMonth)
            Me.GroupBoxBilling_Options.Controls.Add(Me.LabelOptions_CreditLimit)
            Me.GroupBoxBilling_Options.Location = New System.Drawing.Point(6, 223)
            Me.GroupBoxBilling_Options.Name = "GroupBoxBilling_Options"
            Me.GroupBoxBilling_Options.Size = New System.Drawing.Size(248, 159)
            Me.GroupBoxBilling_Options.TabIndex = 3
            Me.GroupBoxBilling_Options.Text = "Options"
            '
            'ComboBoxOptions_Biller
            '
            Me.ComboBoxOptions_Biller.AddInactiveItemsOnSelectedValue = True
            Me.ComboBoxOptions_Biller.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxOptions_Biller.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxOptions_Biller.AutoFindItemInDataSource = False
            Me.ComboBoxOptions_Biller.AutoSelectSingleItemDatasource = False
            Me.ComboBoxOptions_Biller.BookmarkingEnabled = False
            Me.ComboBoxOptions_Biller.ClientCode = ""
            Me.ComboBoxOptions_Biller.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Employee
            Me.ComboBoxOptions_Biller.DisableMouseWheel = False
            Me.ComboBoxOptions_Biller.DisplayMember = "FullName"
            Me.ComboBoxOptions_Biller.DisplayName = ""
            Me.ComboBoxOptions_Biller.DivisionCode = ""
            Me.ComboBoxOptions_Biller.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxOptions_Biller.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.BottomLeft
            Me.ComboBoxOptions_Biller.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxOptions_Biller.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxOptions_Biller.FocusHighlightEnabled = True
            Me.ComboBoxOptions_Biller.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxOptions_Biller.FormattingEnabled = True
            Me.ComboBoxOptions_Biller.ItemHeight = 16
            Me.ComboBoxOptions_Biller.Location = New System.Drawing.Point(118, 104)
            Me.ComboBoxOptions_Biller.Name = "ComboBoxOptions_Biller"
            Me.ComboBoxOptions_Biller.ReadOnly = False
            Me.ComboBoxOptions_Biller.SecurityEnabled = True
            Me.ComboBoxOptions_Biller.Size = New System.Drawing.Size(125, 22)
            Me.ComboBoxOptions_Biller.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxOptions_Biller.TabIndex = 7
            Me.ComboBoxOptions_Biller.TabOnEnter = True
            Me.ComboBoxOptions_Biller.ValueMember = "Code"
            Me.ComboBoxOptions_Biller.WatermarkText = "Select Employee"
            '
            'DateTimePickerOptions_ContractExpirationDate
            '
            Me.DateTimePickerOptions_ContractExpirationDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerOptions_ContractExpirationDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerOptions_ContractExpirationDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerOptions_ContractExpirationDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerOptions_ContractExpirationDate.ButtonDropDown.Visible = True
            Me.DateTimePickerOptions_ContractExpirationDate.ButtonFreeText.Checked = True
            Me.DateTimePickerOptions_ContractExpirationDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerOptions_ContractExpirationDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerOptions_ContractExpirationDate.DisplayName = ""
            Me.DateTimePickerOptions_ContractExpirationDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerOptions_ContractExpirationDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerOptions_ContractExpirationDate.FocusHighlightEnabled = True
            Me.DateTimePickerOptions_ContractExpirationDate.FreeTextEntryMode = True
            Me.DateTimePickerOptions_ContractExpirationDate.IsPopupCalendarOpen = False
            Me.DateTimePickerOptions_ContractExpirationDate.Location = New System.Drawing.Point(118, 132)
            Me.DateTimePickerOptions_ContractExpirationDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerOptions_ContractExpirationDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerOptions_ContractExpirationDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerOptions_ContractExpirationDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerOptions_ContractExpirationDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerOptions_ContractExpirationDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerOptions_ContractExpirationDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerOptions_ContractExpirationDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerOptions_ContractExpirationDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerOptions_ContractExpirationDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerOptions_ContractExpirationDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerOptions_ContractExpirationDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerOptions_ContractExpirationDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerOptions_ContractExpirationDate.MonthCalendar.DisplayMonth = New Date(2012, 5, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerOptions_ContractExpirationDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerOptions_ContractExpirationDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerOptions_ContractExpirationDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerOptions_ContractExpirationDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerOptions_ContractExpirationDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerOptions_ContractExpirationDate.Name = "DateTimePickerOptions_ContractExpirationDate"
            Me.DateTimePickerOptions_ContractExpirationDate.ReadOnly = False
            Me.DateTimePickerOptions_ContractExpirationDate.Size = New System.Drawing.Size(125, 21)
            Me.DateTimePickerOptions_ContractExpirationDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerOptions_ContractExpirationDate.TabIndex = 9
            Me.DateTimePickerOptions_ContractExpirationDate.TabOnEnter = True
            Me.DateTimePickerOptions_ContractExpirationDate.Value = New Date(2013, 5, 1, 14, 17, 6, 473)
            Me.DateTimePickerOptions_ContractExpirationDate.Visible = False
            '
            'LabelOptions_ContractExpirationDate
            '
            Me.LabelOptions_ContractExpirationDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelOptions_ContractExpirationDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelOptions_ContractExpirationDate.Location = New System.Drawing.Point(7, 132)
            Me.LabelOptions_ContractExpirationDate.Name = "LabelOptions_ContractExpirationDate"
            Me.LabelOptions_ContractExpirationDate.Size = New System.Drawing.Size(106, 20)
            Me.LabelOptions_ContractExpirationDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOptions_ContractExpirationDate.TabIndex = 8
            Me.LabelOptions_ContractExpirationDate.Text = "Contract Expiration: "
            Me.LabelOptions_ContractExpirationDate.Visible = False
            '
            'LabelOptions_Biller
            '
            Me.LabelOptions_Biller.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelOptions_Biller.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelOptions_Biller.Location = New System.Drawing.Point(6, 104)
            Me.LabelOptions_Biller.Name = "LabelOptions_Biller"
            Me.LabelOptions_Biller.Size = New System.Drawing.Size(106, 20)
            Me.LabelOptions_Biller.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOptions_Biller.TabIndex = 6
            Me.LabelOptions_Biller.Text = "Biller:"
            '
            'ComboBoxOptions_Currency
            '
            Me.ComboBoxOptions_Currency.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxOptions_Currency.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxOptions_Currency.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxOptions_Currency.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxOptions_Currency.AutoFindItemInDataSource = False
            Me.ComboBoxOptions_Currency.AutoSelectSingleItemDatasource = False
            Me.ComboBoxOptions_Currency.BookmarkingEnabled = False
            Me.ComboBoxOptions_Currency.ClientCode = ""
            Me.ComboBoxOptions_Currency.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.CurrencyCode
            Me.ComboBoxOptions_Currency.DisableMouseWheel = False
            Me.ComboBoxOptions_Currency.DisplayMember = "Description"
            Me.ComboBoxOptions_Currency.DisplayName = ""
            Me.ComboBoxOptions_Currency.DivisionCode = ""
            Me.ComboBoxOptions_Currency.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxOptions_Currency.Enabled = False
            Me.ComboBoxOptions_Currency.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxOptions_Currency.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxOptions_Currency.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxOptions_Currency.FocusHighlightEnabled = True
            Me.ComboBoxOptions_Currency.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxOptions_Currency.FormattingEnabled = True
            Me.ComboBoxOptions_Currency.ItemHeight = 16
            Me.ComboBoxOptions_Currency.Location = New System.Drawing.Point(118, 26)
            Me.ComboBoxOptions_Currency.Name = "ComboBoxOptions_Currency"
            Me.ComboBoxOptions_Currency.ReadOnly = False
            Me.ComboBoxOptions_Currency.SecurityEnabled = True
            Me.ComboBoxOptions_Currency.Size = New System.Drawing.Size(125, 22)
            Me.ComboBoxOptions_Currency.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxOptions_Currency.TabIndex = 1
            Me.ComboBoxOptions_Currency.TabOnEnter = True
            Me.ComboBoxOptions_Currency.ValueMember = "Code"
            Me.ComboBoxOptions_Currency.WatermarkText = "Select Currency Code"
            '
            'LabelOptions_Currency
            '
            Me.LabelOptions_Currency.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelOptions_Currency.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelOptions_Currency.Location = New System.Drawing.Point(5, 26)
            Me.LabelOptions_Currency.Name = "LabelOptions_Currency"
            Me.LabelOptions_Currency.Size = New System.Drawing.Size(106, 20)
            Me.LabelOptions_Currency.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOptions_Currency.TabIndex = 0
            Me.LabelOptions_Currency.Text = "Currency:"
            '
            'NumericInputOptions_CreditLimit
            '
            Me.NumericInputOptions_CreditLimit.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputOptions_CreditLimit.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputOptions_CreditLimit.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputOptions_CreditLimit.EnterMoveNextControl = True
            Me.NumericInputOptions_CreditLimit.Location = New System.Drawing.Point(118, 78)
            Me.NumericInputOptions_CreditLimit.Name = "NumericInputOptions_CreditLimit"
            Me.NumericInputOptions_CreditLimit.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputOptions_CreditLimit.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputOptions_CreditLimit.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputOptions_CreditLimit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputOptions_CreditLimit.Properties.EditFormat.FormatString = "f"
            Me.NumericInputOptions_CreditLimit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputOptions_CreditLimit.Properties.Mask.EditMask = "f"
            Me.NumericInputOptions_CreditLimit.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputOptions_CreditLimit.SecurityEnabled = True
            Me.NumericInputOptions_CreditLimit.Size = New System.Drawing.Size(125, 20)
            Me.NumericInputOptions_CreditLimit.TabIndex = 5
            '
            'LabelOptions_FiscalStartMonth
            '
            Me.LabelOptions_FiscalStartMonth.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelOptions_FiscalStartMonth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelOptions_FiscalStartMonth.Location = New System.Drawing.Point(6, 52)
            Me.LabelOptions_FiscalStartMonth.Name = "LabelOptions_FiscalStartMonth"
            Me.LabelOptions_FiscalStartMonth.Size = New System.Drawing.Size(106, 20)
            Me.LabelOptions_FiscalStartMonth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOptions_FiscalStartMonth.TabIndex = 2
            Me.LabelOptions_FiscalStartMonth.Text = "Fiscal Start Month:"
            '
            'ComboBoxOptions_FiscalStartMonth
            '
            Me.ComboBoxOptions_FiscalStartMonth.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxOptions_FiscalStartMonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxOptions_FiscalStartMonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxOptions_FiscalStartMonth.AutoFindItemInDataSource = False
            Me.ComboBoxOptions_FiscalStartMonth.AutoSelectSingleItemDatasource = False
            Me.ComboBoxOptions_FiscalStartMonth.BookmarkingEnabled = False
            Me.ComboBoxOptions_FiscalStartMonth.ClientCode = ""
            Me.ComboBoxOptions_FiscalStartMonth.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Month
            Me.ComboBoxOptions_FiscalStartMonth.DisableMouseWheel = False
            Me.ComboBoxOptions_FiscalStartMonth.DisplayMember = "Value"
            Me.ComboBoxOptions_FiscalStartMonth.DisplayName = ""
            Me.ComboBoxOptions_FiscalStartMonth.DivisionCode = ""
            Me.ComboBoxOptions_FiscalStartMonth.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxOptions_FiscalStartMonth.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.BottomLeft
            Me.ComboBoxOptions_FiscalStartMonth.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxOptions_FiscalStartMonth.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxOptions_FiscalStartMonth.FocusHighlightEnabled = True
            Me.ComboBoxOptions_FiscalStartMonth.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxOptions_FiscalStartMonth.FormattingEnabled = True
            Me.ComboBoxOptions_FiscalStartMonth.ItemHeight = 16
            Me.ComboBoxOptions_FiscalStartMonth.Location = New System.Drawing.Point(118, 52)
            Me.ComboBoxOptions_FiscalStartMonth.Name = "ComboBoxOptions_FiscalStartMonth"
            Me.ComboBoxOptions_FiscalStartMonth.ReadOnly = False
            Me.ComboBoxOptions_FiscalStartMonth.SecurityEnabled = True
            Me.ComboBoxOptions_FiscalStartMonth.Size = New System.Drawing.Size(125, 22)
            Me.ComboBoxOptions_FiscalStartMonth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxOptions_FiscalStartMonth.TabIndex = 3
            Me.ComboBoxOptions_FiscalStartMonth.TabOnEnter = True
            Me.ComboBoxOptions_FiscalStartMonth.ValueMember = "Key"
            Me.ComboBoxOptions_FiscalStartMonth.WatermarkText = "Select Month"
            '
            'LabelOptions_CreditLimit
            '
            Me.LabelOptions_CreditLimit.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelOptions_CreditLimit.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelOptions_CreditLimit.Location = New System.Drawing.Point(6, 78)
            Me.LabelOptions_CreditLimit.Name = "LabelOptions_CreditLimit"
            Me.LabelOptions_CreditLimit.Size = New System.Drawing.Size(106, 20)
            Me.LabelOptions_CreditLimit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOptions_CreditLimit.TabIndex = 4
            Me.LabelOptions_CreditLimit.Text = "Credit Limit: "
            '
            'TableLayoutPanelBilling_AddressLayout
            '
            Me.TableLayoutPanelBilling_AddressLayout.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TableLayoutPanelBilling_AddressLayout.BackColor = System.Drawing.Color.White
            Me.TableLayoutPanelBilling_AddressLayout.ColumnCount = 2
            Me.TableLayoutPanelBilling_AddressLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanelBilling_AddressLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanelBilling_AddressLayout.Controls.Add(Me.PanelAddressLayout_LeftColumn, 0, 0)
            Me.TableLayoutPanelBilling_AddressLayout.Controls.Add(Me.PanelAddressLayout_RightColumn, 1, 0)
            Me.TableLayoutPanelBilling_AddressLayout.Location = New System.Drawing.Point(6, 6)
            Me.TableLayoutPanelBilling_AddressLayout.Name = "TableLayoutPanelBilling_AddressLayout"
            Me.TableLayoutPanelBilling_AddressLayout.RowCount = 1
            Me.TableLayoutPanelBilling_AddressLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanelBilling_AddressLayout.Size = New System.Drawing.Size(833, 211)
            Me.TableLayoutPanelBilling_AddressLayout.TabIndex = 0
            '
            'PanelAddressLayout_LeftColumn
            '
            Me.PanelAddressLayout_LeftColumn.Controls.Add(Me.ButtonLeftColumn_RefreshBilling)
            Me.PanelAddressLayout_LeftColumn.Controls.Add(Me.AddressControlLeftColumn_BillingAddress)
            Me.PanelAddressLayout_LeftColumn.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelAddressLayout_LeftColumn.Location = New System.Drawing.Point(0, 0)
            Me.PanelAddressLayout_LeftColumn.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelAddressLayout_LeftColumn.Name = "PanelAddressLayout_LeftColumn"
            Me.PanelAddressLayout_LeftColumn.Size = New System.Drawing.Size(416, 211)
            Me.PanelAddressLayout_LeftColumn.TabIndex = 1
            '
            'ButtonLeftColumn_RefreshBilling
            '
            Me.ButtonLeftColumn_RefreshBilling.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonLeftColumn_RefreshBilling.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonLeftColumn_RefreshBilling.AutoExpandOnClick = True
            Me.ButtonLeftColumn_RefreshBilling.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonLeftColumn_RefreshBilling.Location = New System.Drawing.Point(336, 0)
            Me.ButtonLeftColumn_RefreshBilling.Name = "ButtonLeftColumn_RefreshBilling"
            Me.ButtonLeftColumn_RefreshBilling.SecurityEnabled = True
            Me.ButtonLeftColumn_RefreshBilling.Size = New System.Drawing.Size(75, 20)
            Me.ButtonLeftColumn_RefreshBilling.SplitButton = True
            Me.ButtonLeftColumn_RefreshBilling.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonLeftColumn_RefreshBilling.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemRefreshBilling_Address})
            Me.ButtonLeftColumn_RefreshBilling.TabIndex = 2
            Me.ButtonLeftColumn_RefreshBilling.Text = "Refresh"
            '
            'ButtonItemRefreshBilling_Address
            '
            Me.ButtonItemRefreshBilling_Address.Name = "ButtonItemRefreshBilling_Address"
            Me.ButtonItemRefreshBilling_Address.Text = "Client"
            '
            'AddressControlLeftColumn_BillingAddress
            '
            Me.AddressControlLeftColumn_BillingAddress.Address = Nothing
            Me.AddressControlLeftColumn_BillingAddress.Address2 = Nothing
            Me.AddressControlLeftColumn_BillingAddress.Address3 = Nothing
            Me.AddressControlLeftColumn_BillingAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.AddressControlLeftColumn_BillingAddress.City = Nothing
            Me.AddressControlLeftColumn_BillingAddress.Country = Nothing
            Me.AddressControlLeftColumn_BillingAddress.County = Nothing
            Me.AddressControlLeftColumn_BillingAddress.DisableCountry = False
            Me.AddressControlLeftColumn_BillingAddress.DisableCounty = False
            Me.AddressControlLeftColumn_BillingAddress.Location = New System.Drawing.Point(0, 26)
            Me.AddressControlLeftColumn_BillingAddress.Name = "AddressControlLeftColumn_BillingAddress"
            Me.AddressControlLeftColumn_BillingAddress.ReadOnly = False
            Me.AddressControlLeftColumn_BillingAddress.ShowCountry = True
            Me.AddressControlLeftColumn_BillingAddress.ShowCounty = True
            Me.AddressControlLeftColumn_BillingAddress.Size = New System.Drawing.Size(411, 181)
            Me.AddressControlLeftColumn_BillingAddress.State = Nothing
            Me.AddressControlLeftColumn_BillingAddress.TabIndex = 3
            Me.AddressControlLeftColumn_BillingAddress.Title = "Billing Address"
            Me.AddressControlLeftColumn_BillingAddress.Zip = Nothing
            '
            'PanelAddressLayout_RightColumn
            '
            Me.PanelAddressLayout_RightColumn.Controls.Add(Me.AddressControlRightColumn_StatementAddress)
            Me.PanelAddressLayout_RightColumn.Controls.Add(Me.ButtonRightColumn_RefreshStatement)
            Me.PanelAddressLayout_RightColumn.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelAddressLayout_RightColumn.Location = New System.Drawing.Point(416, 0)
            Me.PanelAddressLayout_RightColumn.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelAddressLayout_RightColumn.Name = "PanelAddressLayout_RightColumn"
            Me.PanelAddressLayout_RightColumn.Size = New System.Drawing.Size(417, 211)
            Me.PanelAddressLayout_RightColumn.TabIndex = 4
            '
            'AddressControlRightColumn_StatementAddress
            '
            Me.AddressControlRightColumn_StatementAddress.Address = Nothing
            Me.AddressControlRightColumn_StatementAddress.Address2 = Nothing
            Me.AddressControlRightColumn_StatementAddress.Address3 = Nothing
            Me.AddressControlRightColumn_StatementAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.AddressControlRightColumn_StatementAddress.City = Nothing
            Me.AddressControlRightColumn_StatementAddress.Country = Nothing
            Me.AddressControlRightColumn_StatementAddress.County = Nothing
            Me.AddressControlRightColumn_StatementAddress.DisableCountry = False
            Me.AddressControlRightColumn_StatementAddress.DisableCounty = False
            Me.AddressControlRightColumn_StatementAddress.Location = New System.Drawing.Point(2, 26)
            Me.AddressControlRightColumn_StatementAddress.Name = "AddressControlRightColumn_StatementAddress"
            Me.AddressControlRightColumn_StatementAddress.ReadOnly = False
            Me.AddressControlRightColumn_StatementAddress.ShowCountry = True
            Me.AddressControlRightColumn_StatementAddress.ShowCounty = True
            Me.AddressControlRightColumn_StatementAddress.Size = New System.Drawing.Size(415, 181)
            Me.AddressControlRightColumn_StatementAddress.State = Nothing
            Me.AddressControlRightColumn_StatementAddress.TabIndex = 6
            Me.AddressControlRightColumn_StatementAddress.Title = "Statement Address"
            Me.AddressControlRightColumn_StatementAddress.Zip = Nothing
            '
            'ButtonRightColumn_RefreshStatement
            '
            Me.ButtonRightColumn_RefreshStatement.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightColumn_RefreshStatement.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonRightColumn_RefreshStatement.AutoExpandOnClick = True
            Me.ButtonRightColumn_RefreshStatement.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightColumn_RefreshStatement.Location = New System.Drawing.Point(342, 0)
            Me.ButtonRightColumn_RefreshStatement.Name = "ButtonRightColumn_RefreshStatement"
            Me.ButtonRightColumn_RefreshStatement.SecurityEnabled = True
            Me.ButtonRightColumn_RefreshStatement.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightColumn_RefreshStatement.SplitButton = True
            Me.ButtonRightColumn_RefreshStatement.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightColumn_RefreshStatement.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemRefreshStatement_Address, Me.ButtonItemRefreshStatement_Billing})
            Me.ButtonRightColumn_RefreshStatement.TabIndex = 5
            Me.ButtonRightColumn_RefreshStatement.Text = "Refresh"
            '
            'ButtonItemRefreshStatement_Address
            '
            Me.ButtonItemRefreshStatement_Address.Name = "ButtonItemRefreshStatement_Address"
            Me.ButtonItemRefreshStatement_Address.Text = "Client"
            '
            'ButtonItemRefreshStatement_Billing
            '
            Me.ButtonItemRefreshStatement_Billing.Name = "ButtonItemRefreshStatement_Billing"
            Me.ButtonItemRefreshStatement_Billing.Text = "Billing"
            '
            'SearchableComboBoxBilling_Location
            '
            Me.SearchableComboBoxBilling_Location.ActiveFilterString = ""
            Me.SearchableComboBoxBilling_Location.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxBilling_Location.AutoFillMode = False
            Me.SearchableComboBoxBilling_Location.BookmarkingEnabled = False
            Me.SearchableComboBoxBilling_Location.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Location
            Me.SearchableComboBoxBilling_Location.DataSource = Nothing
            Me.SearchableComboBoxBilling_Location.DisableMouseWheel = False
            Me.SearchableComboBoxBilling_Location.DisplayName = ""
            Me.SearchableComboBoxBilling_Location.EnterMoveNextControl = True
            Me.SearchableComboBoxBilling_Location.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.None
            Me.SearchableComboBoxBilling_Location.Location = New System.Drawing.Point(329, 481)
            Me.SearchableComboBoxBilling_Location.Name = "SearchableComboBoxBilling_Location"
            Me.SearchableComboBoxBilling_Location.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxBilling_Location.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxBilling_Location.Properties.NullText = "Select Location"
            Me.SearchableComboBoxBilling_Location.Properties.PopupView = Me.SearchableComboboxGridViewBilling_Location
            Me.SearchableComboBoxBilling_Location.Properties.ShowClearButton = False
            Me.SearchableComboBoxBilling_Location.Properties.ValueMember = "ID"
            Me.SearchableComboBoxBilling_Location.SecurityEnabled = True
            Me.SearchableComboBoxBilling_Location.SelectedValue = Nothing
            Me.SearchableComboBoxBilling_Location.Size = New System.Drawing.Size(191, 20)
            Me.SearchableComboBoxBilling_Location.TabIndex = 2
            Me.SearchableComboBoxBilling_Location.Visible = False
            '
            'SearchableComboboxGridViewBilling_Location
            '
            Me.SearchableComboboxGridViewBilling_Location.AFActiveFilterString = ""
            Me.SearchableComboboxGridViewBilling_Location.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboboxGridViewBilling_Location.AutoFilterLookupColumns = False
            Me.SearchableComboboxGridViewBilling_Location.AutoloadRepositoryDatasource = True
            Me.SearchableComboboxGridViewBilling_Location.DataSourceClearing = False
            Me.SearchableComboboxGridViewBilling_Location.EnableDisabledRows = False
            Me.SearchableComboboxGridViewBilling_Location.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboboxGridViewBilling_Location.Name = "SearchableComboboxGridViewBilling_Location"
            Me.SearchableComboboxGridViewBilling_Location.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboboxGridViewBilling_Location.OptionsView.ShowGroupPanel = False
            Me.SearchableComboboxGridViewBilling_Location.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboboxGridViewBilling_Location.RunStandardValidation = True
            Me.SearchableComboboxGridViewBilling_Location.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboboxGridViewBilling_Location.SkipSettingFontOnModifyColumn = False
            '
            'TabItemClientDetails_BillingTab
            '
            Me.TabItemClientDetails_BillingTab.AttachedControl = Me.TabControlPanelBillingTab_Billing
            Me.TabItemClientDetails_BillingTab.Name = "TabItemClientDetails_BillingTab"
            Me.TabItemClientDetails_BillingTab.Text = "Billing"
            '
            'TabControlPanelContactTab_Contacts
            '
            Me.TabControlPanelContactTab_Contacts.Controls.Add(Me.ClientContactManagerControlContacts_ClientContacts)
            Me.TabControlPanelContactTab_Contacts.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelContactTab_Contacts.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelContactTab_Contacts.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelContactTab_Contacts.Name = "TabControlPanelContactTab_Contacts"
            Me.TabControlPanelContactTab_Contacts.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelContactTab_Contacts.Size = New System.Drawing.Size(845, 505)
            Me.TabControlPanelContactTab_Contacts.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelContactTab_Contacts.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelContactTab_Contacts.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelContactTab_Contacts.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelContactTab_Contacts.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelContactTab_Contacts.Style.GradientAngle = 90
            Me.TabControlPanelContactTab_Contacts.TabIndex = 8
            Me.TabControlPanelContactTab_Contacts.TabItem = Me.TabItemClientDetails_ContactsTab
            '
            'ClientContactManagerControlContacts_ClientContacts
            '
            Me.ClientContactManagerControlContacts_ClientContacts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ClientContactManagerControlContacts_ClientContacts.Location = New System.Drawing.Point(6, 6)
            Me.ClientContactManagerControlContacts_ClientContacts.Name = "ClientContactManagerControlContacts_ClientContacts"
            Me.ClientContactManagerControlContacts_ClientContacts.Size = New System.Drawing.Size(833, 494)
            Me.ClientContactManagerControlContacts_ClientContacts.TabIndex = 0
            '
            'TabItemClientDetails_ContactsTab
            '
            Me.TabItemClientDetails_ContactsTab.AttachedControl = Me.TabControlPanelContactTab_Contacts
            Me.TabItemClientDetails_ContactsTab.Name = "TabItemClientDetails_ContactsTab"
            Me.TabItemClientDetails_ContactsTab.Text = "Contacts"
            '
            'TabControlPanelWebsiteTab_Websites
            '
            Me.TabControlPanelWebsiteTab_Websites.Controls.Add(Me.DataGridViewWebsites_Websites)
            Me.TabControlPanelWebsiteTab_Websites.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelWebsiteTab_Websites.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelWebsiteTab_Websites.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelWebsiteTab_Websites.Name = "TabControlPanelWebsiteTab_Websites"
            Me.TabControlPanelWebsiteTab_Websites.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelWebsiteTab_Websites.Size = New System.Drawing.Size(845, 505)
            Me.TabControlPanelWebsiteTab_Websites.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelWebsiteTab_Websites.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelWebsiteTab_Websites.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelWebsiteTab_Websites.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelWebsiteTab_Websites.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelWebsiteTab_Websites.Style.GradientAngle = 90
            Me.TabControlPanelWebsiteTab_Websites.TabIndex = 6
            Me.TabControlPanelWebsiteTab_Websites.TabItem = Me.TabItemClientDetails_WebsitesTab
            '
            'DataGridViewWebsites_Websites
            '
            Me.DataGridViewWebsites_Websites.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewWebsites_Websites.AllowDragAndDrop = False
            Me.DataGridViewWebsites_Websites.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewWebsites_Websites.AllowSelectGroupHeaderRow = True
            Me.DataGridViewWebsites_Websites.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewWebsites_Websites.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewWebsites_Websites.AutoFilterLookupColumns = False
            Me.DataGridViewWebsites_Websites.AutoloadRepositoryDatasource = True
            Me.DataGridViewWebsites_Websites.AutoUpdateViewCaption = True
            Me.DataGridViewWebsites_Websites.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewWebsites_Websites.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewWebsites_Websites.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewWebsites_Websites.ItemDescription = ""
            Me.DataGridViewWebsites_Websites.Location = New System.Drawing.Point(6, 6)
            Me.DataGridViewWebsites_Websites.MultiSelect = True
            Me.DataGridViewWebsites_Websites.Name = "DataGridViewWebsites_Websites"
            Me.DataGridViewWebsites_Websites.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewWebsites_Websites.RunStandardValidation = True
            Me.DataGridViewWebsites_Websites.ShowColumnMenuOnRightClick = False
            Me.DataGridViewWebsites_Websites.ShowSelectDeselectAllButtons = False
            Me.DataGridViewWebsites_Websites.Size = New System.Drawing.Size(833, 494)
            Me.DataGridViewWebsites_Websites.TabIndex = 5
            Me.DataGridViewWebsites_Websites.UseEmbeddedNavigator = False
            Me.DataGridViewWebsites_Websites.ViewCaptionHeight = -1
            '
            'TabItemClientDetails_WebsitesTab
            '
            Me.TabItemClientDetails_WebsitesTab.AttachedControl = Me.TabControlPanelWebsiteTab_Websites
            Me.TabItemClientDetails_WebsitesTab.Name = "TabItemClientDetails_WebsitesTab"
            Me.TabItemClientDetails_WebsitesTab.Text = "Websites"
            '
            'TabControlPanelRequiredFieldsTab_RequiredFields
            '
            Me.TabControlPanelRequiredFieldsTab_RequiredFields.Controls.Add(Me.GroupBoxRequiredFields_UserSelectedRequiredFields)
            Me.TabControlPanelRequiredFieldsTab_RequiredFields.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelRequiredFieldsTab_RequiredFields.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelRequiredFieldsTab_RequiredFields.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelRequiredFieldsTab_RequiredFields.Name = "TabControlPanelRequiredFieldsTab_RequiredFields"
            Me.TabControlPanelRequiredFieldsTab_RequiredFields.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelRequiredFieldsTab_RequiredFields.Size = New System.Drawing.Size(845, 505)
            Me.TabControlPanelRequiredFieldsTab_RequiredFields.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelRequiredFieldsTab_RequiredFields.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelRequiredFieldsTab_RequiredFields.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelRequiredFieldsTab_RequiredFields.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelRequiredFieldsTab_RequiredFields.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelRequiredFieldsTab_RequiredFields.Style.GradientAngle = 90
            Me.TabControlPanelRequiredFieldsTab_RequiredFields.TabIndex = 0
            Me.TabControlPanelRequiredFieldsTab_RequiredFields.TabItem = Me.TabItemClientDetails_RequiredFieldsTab
            '
            'GroupBoxRequiredFields_UserSelectedRequiredFields
            '
            Me.GroupBoxRequiredFields_UserSelectedRequiredFields.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxRequiredFields_UserSelectedRequiredFields.Controls.Add(Me.CheckBoxRequiredFields_RequireTimeComments)
            Me.GroupBoxRequiredFields_UserSelectedRequiredFields.Controls.Add(Me.TableLayoutPanelUserSelectedRequiredFields_RequiredFields)
            Me.GroupBoxRequiredFields_UserSelectedRequiredFields.Controls.Add(Me.CheckBoxUserSelectedRequiredFields_OverrideAgencySettings)
            Me.GroupBoxRequiredFields_UserSelectedRequiredFields.Controls.Add(Me.CheckBoxRequiredFields_RequireProductCategorySelectionInTimesheet)
            Me.GroupBoxRequiredFields_UserSelectedRequiredFields.Controls.Add(Me.GroupBoxUserSelectedRequiredFields_JobsAndMedia)
            Me.GroupBoxRequiredFields_UserSelectedRequiredFields.Location = New System.Drawing.Point(6, 6)
            Me.GroupBoxRequiredFields_UserSelectedRequiredFields.Name = "GroupBoxRequiredFields_UserSelectedRequiredFields"
            Me.GroupBoxRequiredFields_UserSelectedRequiredFields.Size = New System.Drawing.Size(833, 419)
            Me.GroupBoxRequiredFields_UserSelectedRequiredFields.TabIndex = 0
            Me.GroupBoxRequiredFields_UserSelectedRequiredFields.Text = "User Selected Required Fields"
            '
            'CheckBoxRequiredFields_RequireTimeComments
            '
            Me.CheckBoxRequiredFields_RequireTimeComments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxRequiredFields_RequireTimeComments.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxRequiredFields_RequireTimeComments.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxRequiredFields_RequireTimeComments.CheckValue = 0
            Me.CheckBoxRequiredFields_RequireTimeComments.CheckValueChecked = 1
            Me.CheckBoxRequiredFields_RequireTimeComments.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxRequiredFields_RequireTimeComments.CheckValueUnchecked = 0
            Me.CheckBoxRequiredFields_RequireTimeComments.ChildControls = CType(resources.GetObject("CheckBoxRequiredFields_RequireTimeComments.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRequiredFields_RequireTimeComments.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxRequiredFields_RequireTimeComments.Location = New System.Drawing.Point(7, 368)
            Me.CheckBoxRequiredFields_RequireTimeComments.Name = "CheckBoxRequiredFields_RequireTimeComments"
            Me.CheckBoxRequiredFields_RequireTimeComments.OldestSibling = Nothing
            Me.CheckBoxRequiredFields_RequireTimeComments.SecurityEnabled = True
            Me.CheckBoxRequiredFields_RequireTimeComments.SiblingControls = CType(resources.GetObject("CheckBoxRequiredFields_RequireTimeComments.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRequiredFields_RequireTimeComments.Size = New System.Drawing.Size(820, 20)
            Me.CheckBoxRequiredFields_RequireTimeComments.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxRequiredFields_RequireTimeComments.TabIndex = 5
            Me.CheckBoxRequiredFields_RequireTimeComments.TabOnEnter = True
            Me.CheckBoxRequiredFields_RequireTimeComments.Text = "Require time comments"
            '
            'TableLayoutPanelUserSelectedRequiredFields_RequiredFields
            '
            Me.TableLayoutPanelUserSelectedRequiredFields_RequiredFields.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TableLayoutPanelUserSelectedRequiredFields_RequiredFields.BackColor = System.Drawing.Color.White
            Me.TableLayoutPanelUserSelectedRequiredFields_RequiredFields.ColumnCount = 3
            Me.TableLayoutPanelUserSelectedRequiredFields_RequiredFields.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
            Me.TableLayoutPanelUserSelectedRequiredFields_RequiredFields.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
            Me.TableLayoutPanelUserSelectedRequiredFields_RequiredFields.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.0!))
            Me.TableLayoutPanelUserSelectedRequiredFields_RequiredFields.Controls.Add(Me.PanelUserSelectedRequiredFields_RightColumn, 2, 0)
            Me.TableLayoutPanelUserSelectedRequiredFields_RequiredFields.Controls.Add(Me.PanelUserSelectedRequiredFields_MiddleColumn, 1, 0)
            Me.TableLayoutPanelUserSelectedRequiredFields_RequiredFields.Controls.Add(Me.PanelUserSelectedRequiredFields_LeftColumn, 0, 0)
            Me.TableLayoutPanelUserSelectedRequiredFields_RequiredFields.Location = New System.Drawing.Point(7, 56)
            Me.TableLayoutPanelUserSelectedRequiredFields_RequiredFields.Name = "TableLayoutPanelUserSelectedRequiredFields_RequiredFields"
            Me.TableLayoutPanelUserSelectedRequiredFields_RequiredFields.RowCount = 1
            Me.TableLayoutPanelUserSelectedRequiredFields_RequiredFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanelUserSelectedRequiredFields_RequiredFields.Size = New System.Drawing.Size(821, 254)
            Me.TableLayoutPanelUserSelectedRequiredFields_RequiredFields.TabIndex = 2
            '
            'PanelUserSelectedRequiredFields_RightColumn
            '
            Me.PanelUserSelectedRequiredFields_RightColumn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelUserSelectedRequiredFields_RightColumn.Controls.Add(Me.CheckBoxRightColumn_JobComponentCustom5)
            Me.PanelUserSelectedRequiredFields_RightColumn.Controls.Add(Me.CheckBoxRightColumn_JobLogCustom1)
            Me.PanelUserSelectedRequiredFields_RightColumn.Controls.Add(Me.CheckBoxRightColumn_JobComponentCustom4)
            Me.PanelUserSelectedRequiredFields_RightColumn.Controls.Add(Me.CheckBoxRightColumn_JobLogCustom2)
            Me.PanelUserSelectedRequiredFields_RightColumn.Controls.Add(Me.CheckBoxRightColumn_JobComponentCustom3)
            Me.PanelUserSelectedRequiredFields_RightColumn.Controls.Add(Me.CheckBoxRightColumn_JobLogCustom3)
            Me.PanelUserSelectedRequiredFields_RightColumn.Controls.Add(Me.CheckBoxRightColumn_JobComponentCustom2)
            Me.PanelUserSelectedRequiredFields_RightColumn.Controls.Add(Me.CheckBoxRightColumn_JobLogCustom4)
            Me.PanelUserSelectedRequiredFields_RightColumn.Controls.Add(Me.CheckBoxRightColumn_JobComponentCustom1)
            Me.PanelUserSelectedRequiredFields_RightColumn.Controls.Add(Me.CheckBoxRightColumn_JobLogCustom5)
            Me.PanelUserSelectedRequiredFields_RightColumn.Location = New System.Drawing.Point(540, 0)
            Me.PanelUserSelectedRequiredFields_RightColumn.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelUserSelectedRequiredFields_RightColumn.Name = "PanelUserSelectedRequiredFields_RightColumn"
            Me.PanelUserSelectedRequiredFields_RightColumn.Size = New System.Drawing.Size(281, 254)
            Me.PanelUserSelectedRequiredFields_RightColumn.TabIndex = 2
            '
            'CheckBoxRightColumn_JobComponentCustom5
            '
            Me.CheckBoxRightColumn_JobComponentCustom5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxRightColumn_JobComponentCustom5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxRightColumn_JobComponentCustom5.CheckValue = CType(0, Short)
            Me.CheckBoxRightColumn_JobComponentCustom5.CheckValueChecked = CType(1, Short)
            Me.CheckBoxRightColumn_JobComponentCustom5.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxRightColumn_JobComponentCustom5.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxRightColumn_JobComponentCustom5.ChildControls = CType(resources.GetObject("CheckBoxRightColumn_JobComponentCustom5.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRightColumn_JobComponentCustom5.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxRightColumn_JobComponentCustom5.Location = New System.Drawing.Point(0, 234)
            Me.CheckBoxRightColumn_JobComponentCustom5.Name = "CheckBoxRightColumn_JobComponentCustom5"
            Me.CheckBoxRightColumn_JobComponentCustom5.OldestSibling = Nothing
            Me.CheckBoxRightColumn_JobComponentCustom5.SecurityEnabled = True
            Me.CheckBoxRightColumn_JobComponentCustom5.SiblingControls = CType(resources.GetObject("CheckBoxRightColumn_JobComponentCustom5.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRightColumn_JobComponentCustom5.Size = New System.Drawing.Size(278, 20)
            Me.CheckBoxRightColumn_JobComponentCustom5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxRightColumn_JobComponentCustom5.TabIndex = 41
            Me.CheckBoxRightColumn_JobComponentCustom5.TabOnEnter = True
            Me.CheckBoxRightColumn_JobComponentCustom5.Text = "Job Component Custom 5"
            '
            'CheckBoxRightColumn_JobLogCustom1
            '
            Me.CheckBoxRightColumn_JobLogCustom1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxRightColumn_JobLogCustom1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxRightColumn_JobLogCustom1.CheckValue = CType(0, Short)
            Me.CheckBoxRightColumn_JobLogCustom1.CheckValueChecked = CType(1, Short)
            Me.CheckBoxRightColumn_JobLogCustom1.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxRightColumn_JobLogCustom1.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxRightColumn_JobLogCustom1.ChildControls = CType(resources.GetObject("CheckBoxRightColumn_JobLogCustom1.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRightColumn_JobLogCustom1.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxRightColumn_JobLogCustom1.Location = New System.Drawing.Point(0, 0)
            Me.CheckBoxRightColumn_JobLogCustom1.Name = "CheckBoxRightColumn_JobLogCustom1"
            Me.CheckBoxRightColumn_JobLogCustom1.OldestSibling = Nothing
            Me.CheckBoxRightColumn_JobLogCustom1.SecurityEnabled = True
            Me.CheckBoxRightColumn_JobLogCustom1.SiblingControls = CType(resources.GetObject("CheckBoxRightColumn_JobLogCustom1.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRightColumn_JobLogCustom1.Size = New System.Drawing.Size(278, 20)
            Me.CheckBoxRightColumn_JobLogCustom1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxRightColumn_JobLogCustom1.TabIndex = 32
            Me.CheckBoxRightColumn_JobLogCustom1.TabOnEnter = True
            Me.CheckBoxRightColumn_JobLogCustom1.Text = "Job Log Custom 1"
            '
            'CheckBoxRightColumn_JobComponentCustom4
            '
            Me.CheckBoxRightColumn_JobComponentCustom4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxRightColumn_JobComponentCustom4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxRightColumn_JobComponentCustom4.CheckValue = CType(0, Short)
            Me.CheckBoxRightColumn_JobComponentCustom4.CheckValueChecked = CType(1, Short)
            Me.CheckBoxRightColumn_JobComponentCustom4.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxRightColumn_JobComponentCustom4.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxRightColumn_JobComponentCustom4.ChildControls = CType(resources.GetObject("CheckBoxRightColumn_JobComponentCustom4.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRightColumn_JobComponentCustom4.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxRightColumn_JobComponentCustom4.Location = New System.Drawing.Point(0, 208)
            Me.CheckBoxRightColumn_JobComponentCustom4.Name = "CheckBoxRightColumn_JobComponentCustom4"
            Me.CheckBoxRightColumn_JobComponentCustom4.OldestSibling = Nothing
            Me.CheckBoxRightColumn_JobComponentCustom4.SecurityEnabled = True
            Me.CheckBoxRightColumn_JobComponentCustom4.SiblingControls = CType(resources.GetObject("CheckBoxRightColumn_JobComponentCustom4.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRightColumn_JobComponentCustom4.Size = New System.Drawing.Size(278, 20)
            Me.CheckBoxRightColumn_JobComponentCustom4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxRightColumn_JobComponentCustom4.TabIndex = 40
            Me.CheckBoxRightColumn_JobComponentCustom4.TabOnEnter = True
            Me.CheckBoxRightColumn_JobComponentCustom4.Text = "Job Component Custom 4"
            '
            'CheckBoxRightColumn_JobLogCustom2
            '
            Me.CheckBoxRightColumn_JobLogCustom2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxRightColumn_JobLogCustom2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxRightColumn_JobLogCustom2.CheckValue = CType(0, Short)
            Me.CheckBoxRightColumn_JobLogCustom2.CheckValueChecked = CType(1, Short)
            Me.CheckBoxRightColumn_JobLogCustom2.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxRightColumn_JobLogCustom2.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxRightColumn_JobLogCustom2.ChildControls = CType(resources.GetObject("CheckBoxRightColumn_JobLogCustom2.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRightColumn_JobLogCustom2.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxRightColumn_JobLogCustom2.Location = New System.Drawing.Point(0, 26)
            Me.CheckBoxRightColumn_JobLogCustom2.Name = "CheckBoxRightColumn_JobLogCustom2"
            Me.CheckBoxRightColumn_JobLogCustom2.OldestSibling = Nothing
            Me.CheckBoxRightColumn_JobLogCustom2.SecurityEnabled = True
            Me.CheckBoxRightColumn_JobLogCustom2.SiblingControls = CType(resources.GetObject("CheckBoxRightColumn_JobLogCustom2.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRightColumn_JobLogCustom2.Size = New System.Drawing.Size(278, 20)
            Me.CheckBoxRightColumn_JobLogCustom2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxRightColumn_JobLogCustom2.TabIndex = 33
            Me.CheckBoxRightColumn_JobLogCustom2.TabOnEnter = True
            Me.CheckBoxRightColumn_JobLogCustom2.Text = "Job Log Custom 2"
            '
            'CheckBoxRightColumn_JobComponentCustom3
            '
            Me.CheckBoxRightColumn_JobComponentCustom3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxRightColumn_JobComponentCustom3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxRightColumn_JobComponentCustom3.CheckValue = CType(0, Short)
            Me.CheckBoxRightColumn_JobComponentCustom3.CheckValueChecked = CType(1, Short)
            Me.CheckBoxRightColumn_JobComponentCustom3.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxRightColumn_JobComponentCustom3.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxRightColumn_JobComponentCustom3.ChildControls = CType(resources.GetObject("CheckBoxRightColumn_JobComponentCustom3.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRightColumn_JobComponentCustom3.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxRightColumn_JobComponentCustom3.Location = New System.Drawing.Point(0, 182)
            Me.CheckBoxRightColumn_JobComponentCustom3.Name = "CheckBoxRightColumn_JobComponentCustom3"
            Me.CheckBoxRightColumn_JobComponentCustom3.OldestSibling = Nothing
            Me.CheckBoxRightColumn_JobComponentCustom3.SecurityEnabled = True
            Me.CheckBoxRightColumn_JobComponentCustom3.SiblingControls = CType(resources.GetObject("CheckBoxRightColumn_JobComponentCustom3.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRightColumn_JobComponentCustom3.Size = New System.Drawing.Size(278, 20)
            Me.CheckBoxRightColumn_JobComponentCustom3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxRightColumn_JobComponentCustom3.TabIndex = 39
            Me.CheckBoxRightColumn_JobComponentCustom3.TabOnEnter = True
            Me.CheckBoxRightColumn_JobComponentCustom3.Text = "Job Component Custom 3"
            '
            'CheckBoxRightColumn_JobLogCustom3
            '
            Me.CheckBoxRightColumn_JobLogCustom3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxRightColumn_JobLogCustom3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxRightColumn_JobLogCustom3.CheckValue = CType(0, Short)
            Me.CheckBoxRightColumn_JobLogCustom3.CheckValueChecked = CType(1, Short)
            Me.CheckBoxRightColumn_JobLogCustom3.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxRightColumn_JobLogCustom3.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxRightColumn_JobLogCustom3.ChildControls = CType(resources.GetObject("CheckBoxRightColumn_JobLogCustom3.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRightColumn_JobLogCustom3.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxRightColumn_JobLogCustom3.Location = New System.Drawing.Point(0, 52)
            Me.CheckBoxRightColumn_JobLogCustom3.Name = "CheckBoxRightColumn_JobLogCustom3"
            Me.CheckBoxRightColumn_JobLogCustom3.OldestSibling = Nothing
            Me.CheckBoxRightColumn_JobLogCustom3.SecurityEnabled = True
            Me.CheckBoxRightColumn_JobLogCustom3.SiblingControls = CType(resources.GetObject("CheckBoxRightColumn_JobLogCustom3.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRightColumn_JobLogCustom3.Size = New System.Drawing.Size(278, 20)
            Me.CheckBoxRightColumn_JobLogCustom3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxRightColumn_JobLogCustom3.TabIndex = 34
            Me.CheckBoxRightColumn_JobLogCustom3.TabOnEnter = True
            Me.CheckBoxRightColumn_JobLogCustom3.Text = "Job Log Custom 3"
            '
            'CheckBoxRightColumn_JobComponentCustom2
            '
            Me.CheckBoxRightColumn_JobComponentCustom2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxRightColumn_JobComponentCustom2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxRightColumn_JobComponentCustom2.CheckValue = CType(0, Short)
            Me.CheckBoxRightColumn_JobComponentCustom2.CheckValueChecked = CType(1, Short)
            Me.CheckBoxRightColumn_JobComponentCustom2.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxRightColumn_JobComponentCustom2.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxRightColumn_JobComponentCustom2.ChildControls = CType(resources.GetObject("CheckBoxRightColumn_JobComponentCustom2.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRightColumn_JobComponentCustom2.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxRightColumn_JobComponentCustom2.Location = New System.Drawing.Point(0, 156)
            Me.CheckBoxRightColumn_JobComponentCustom2.Name = "CheckBoxRightColumn_JobComponentCustom2"
            Me.CheckBoxRightColumn_JobComponentCustom2.OldestSibling = Nothing
            Me.CheckBoxRightColumn_JobComponentCustom2.SecurityEnabled = True
            Me.CheckBoxRightColumn_JobComponentCustom2.SiblingControls = CType(resources.GetObject("CheckBoxRightColumn_JobComponentCustom2.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRightColumn_JobComponentCustom2.Size = New System.Drawing.Size(278, 20)
            Me.CheckBoxRightColumn_JobComponentCustom2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxRightColumn_JobComponentCustom2.TabIndex = 38
            Me.CheckBoxRightColumn_JobComponentCustom2.TabOnEnter = True
            Me.CheckBoxRightColumn_JobComponentCustom2.Text = "Job Component Custom 2"
            '
            'CheckBoxRightColumn_JobLogCustom4
            '
            Me.CheckBoxRightColumn_JobLogCustom4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxRightColumn_JobLogCustom4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxRightColumn_JobLogCustom4.CheckValue = CType(0, Short)
            Me.CheckBoxRightColumn_JobLogCustom4.CheckValueChecked = CType(1, Short)
            Me.CheckBoxRightColumn_JobLogCustom4.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxRightColumn_JobLogCustom4.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxRightColumn_JobLogCustom4.ChildControls = CType(resources.GetObject("CheckBoxRightColumn_JobLogCustom4.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRightColumn_JobLogCustom4.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxRightColumn_JobLogCustom4.Location = New System.Drawing.Point(0, 78)
            Me.CheckBoxRightColumn_JobLogCustom4.Name = "CheckBoxRightColumn_JobLogCustom4"
            Me.CheckBoxRightColumn_JobLogCustom4.OldestSibling = Nothing
            Me.CheckBoxRightColumn_JobLogCustom4.SecurityEnabled = True
            Me.CheckBoxRightColumn_JobLogCustom4.SiblingControls = CType(resources.GetObject("CheckBoxRightColumn_JobLogCustom4.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRightColumn_JobLogCustom4.Size = New System.Drawing.Size(278, 20)
            Me.CheckBoxRightColumn_JobLogCustom4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxRightColumn_JobLogCustom4.TabIndex = 35
            Me.CheckBoxRightColumn_JobLogCustom4.TabOnEnter = True
            Me.CheckBoxRightColumn_JobLogCustom4.Text = "Job Log Custom 4"
            '
            'CheckBoxRightColumn_JobComponentCustom1
            '
            Me.CheckBoxRightColumn_JobComponentCustom1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxRightColumn_JobComponentCustom1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxRightColumn_JobComponentCustom1.CheckValue = CType(0, Short)
            Me.CheckBoxRightColumn_JobComponentCustom1.CheckValueChecked = CType(1, Short)
            Me.CheckBoxRightColumn_JobComponentCustom1.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxRightColumn_JobComponentCustom1.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxRightColumn_JobComponentCustom1.ChildControls = CType(resources.GetObject("CheckBoxRightColumn_JobComponentCustom1.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRightColumn_JobComponentCustom1.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxRightColumn_JobComponentCustom1.Location = New System.Drawing.Point(0, 130)
            Me.CheckBoxRightColumn_JobComponentCustom1.Name = "CheckBoxRightColumn_JobComponentCustom1"
            Me.CheckBoxRightColumn_JobComponentCustom1.OldestSibling = Nothing
            Me.CheckBoxRightColumn_JobComponentCustom1.SecurityEnabled = True
            Me.CheckBoxRightColumn_JobComponentCustom1.SiblingControls = CType(resources.GetObject("CheckBoxRightColumn_JobComponentCustom1.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRightColumn_JobComponentCustom1.Size = New System.Drawing.Size(278, 20)
            Me.CheckBoxRightColumn_JobComponentCustom1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxRightColumn_JobComponentCustom1.TabIndex = 37
            Me.CheckBoxRightColumn_JobComponentCustom1.TabOnEnter = True
            Me.CheckBoxRightColumn_JobComponentCustom1.Text = "Job Component Custom 1"
            '
            'CheckBoxRightColumn_JobLogCustom5
            '
            Me.CheckBoxRightColumn_JobLogCustom5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxRightColumn_JobLogCustom5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxRightColumn_JobLogCustom5.CheckValue = CType(0, Short)
            Me.CheckBoxRightColumn_JobLogCustom5.CheckValueChecked = CType(1, Short)
            Me.CheckBoxRightColumn_JobLogCustom5.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxRightColumn_JobLogCustom5.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxRightColumn_JobLogCustom5.ChildControls = CType(resources.GetObject("CheckBoxRightColumn_JobLogCustom5.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRightColumn_JobLogCustom5.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxRightColumn_JobLogCustom5.Location = New System.Drawing.Point(0, 104)
            Me.CheckBoxRightColumn_JobLogCustom5.Name = "CheckBoxRightColumn_JobLogCustom5"
            Me.CheckBoxRightColumn_JobLogCustom5.OldestSibling = Nothing
            Me.CheckBoxRightColumn_JobLogCustom5.SecurityEnabled = True
            Me.CheckBoxRightColumn_JobLogCustom5.SiblingControls = CType(resources.GetObject("CheckBoxRightColumn_JobLogCustom5.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRightColumn_JobLogCustom5.Size = New System.Drawing.Size(278, 20)
            Me.CheckBoxRightColumn_JobLogCustom5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxRightColumn_JobLogCustom5.TabIndex = 36
            Me.CheckBoxRightColumn_JobLogCustom5.TabOnEnter = True
            Me.CheckBoxRightColumn_JobLogCustom5.Text = "Job Log Custom 5"
            '
            'PanelUserSelectedRequiredFields_MiddleColumn
            '
            Me.PanelUserSelectedRequiredFields_MiddleColumn.Controls.Add(Me.CheckBoxMiddleColumn_ServiceFeeType)
            Me.PanelUserSelectedRequiredFields_MiddleColumn.Controls.Add(Me.CheckBoxMiddleColumn_DeptTeam)
            Me.PanelUserSelectedRequiredFields_MiddleColumn.Controls.Add(Me.CheckBoxLeftColumn_DateOpened)
            Me.PanelUserSelectedRequiredFields_MiddleColumn.Controls.Add(Me.CheckBoxMiddleColumn_JobType)
            Me.PanelUserSelectedRequiredFields_MiddleColumn.Controls.Add(Me.CheckBoxMiddleColumn_Promotion)
            Me.PanelUserSelectedRequiredFields_MiddleColumn.Controls.Add(Me.CheckBoxMiddleColumn_FormatAdSize)
            Me.PanelUserSelectedRequiredFields_MiddleColumn.Controls.Add(Me.CheckBoxMiddleColumn_DueDate)
            Me.PanelUserSelectedRequiredFields_MiddleColumn.Controls.Add(Me.CheckBoxMiddleColumn_MarketCode)
            Me.PanelUserSelectedRequiredFields_MiddleColumn.Controls.Add(Me.CheckBoxMiddleColumn_SCFormat)
            Me.PanelUserSelectedRequiredFields_MiddleColumn.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelUserSelectedRequiredFields_MiddleColumn.Location = New System.Drawing.Point(270, 0)
            Me.PanelUserSelectedRequiredFields_MiddleColumn.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelUserSelectedRequiredFields_MiddleColumn.Name = "PanelUserSelectedRequiredFields_MiddleColumn"
            Me.PanelUserSelectedRequiredFields_MiddleColumn.Size = New System.Drawing.Size(270, 254)
            Me.PanelUserSelectedRequiredFields_MiddleColumn.TabIndex = 1
            '
            'CheckBoxMiddleColumn_ServiceFeeType
            '
            Me.CheckBoxMiddleColumn_ServiceFeeType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxMiddleColumn_ServiceFeeType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMiddleColumn_ServiceFeeType.CheckValue = CType(0, Short)
            Me.CheckBoxMiddleColumn_ServiceFeeType.CheckValueChecked = CType(1, Short)
            Me.CheckBoxMiddleColumn_ServiceFeeType.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxMiddleColumn_ServiceFeeType.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxMiddleColumn_ServiceFeeType.ChildControls = CType(resources.GetObject("CheckBoxMiddleColumn_ServiceFeeType.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMiddleColumn_ServiceFeeType.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMiddleColumn_ServiceFeeType.Location = New System.Drawing.Point(0, 208)
            Me.CheckBoxMiddleColumn_ServiceFeeType.Name = "CheckBoxMiddleColumn_ServiceFeeType"
            Me.CheckBoxMiddleColumn_ServiceFeeType.OldestSibling = Nothing
            Me.CheckBoxMiddleColumn_ServiceFeeType.SecurityEnabled = True
            Me.CheckBoxMiddleColumn_ServiceFeeType.SiblingControls = CType(resources.GetObject("CheckBoxMiddleColumn_ServiceFeeType.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMiddleColumn_ServiceFeeType.Size = New System.Drawing.Size(267, 20)
            Me.CheckBoxMiddleColumn_ServiceFeeType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMiddleColumn_ServiceFeeType.TabIndex = 30
            Me.CheckBoxMiddleColumn_ServiceFeeType.TabOnEnter = True
            Me.CheckBoxMiddleColumn_ServiceFeeType.Text = "Service Fee Type"
            '
            'CheckBoxMiddleColumn_DeptTeam
            '
            Me.CheckBoxMiddleColumn_DeptTeam.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxMiddleColumn_DeptTeam.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMiddleColumn_DeptTeam.CheckValue = CType(0, Short)
            Me.CheckBoxMiddleColumn_DeptTeam.CheckValueChecked = CType(1, Short)
            Me.CheckBoxMiddleColumn_DeptTeam.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxMiddleColumn_DeptTeam.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxMiddleColumn_DeptTeam.ChildControls = CType(resources.GetObject("CheckBoxMiddleColumn_DeptTeam.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMiddleColumn_DeptTeam.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMiddleColumn_DeptTeam.Location = New System.Drawing.Point(0, 26)
            Me.CheckBoxMiddleColumn_DeptTeam.Name = "CheckBoxMiddleColumn_DeptTeam"
            Me.CheckBoxMiddleColumn_DeptTeam.OldestSibling = Nothing
            Me.CheckBoxMiddleColumn_DeptTeam.SecurityEnabled = True
            Me.CheckBoxMiddleColumn_DeptTeam.SiblingControls = CType(resources.GetObject("CheckBoxMiddleColumn_DeptTeam.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMiddleColumn_DeptTeam.Size = New System.Drawing.Size(267, 20)
            Me.CheckBoxMiddleColumn_DeptTeam.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMiddleColumn_DeptTeam.TabIndex = 23
            Me.CheckBoxMiddleColumn_DeptTeam.TabOnEnter = True
            Me.CheckBoxMiddleColumn_DeptTeam.Text = "Dept / Team"
            '
            'CheckBoxLeftColumn_DateOpened
            '
            Me.CheckBoxLeftColumn_DateOpened.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxLeftColumn_DateOpened.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxLeftColumn_DateOpened.CheckValue = CType(0, Short)
            Me.CheckBoxLeftColumn_DateOpened.CheckValueChecked = CType(1, Short)
            Me.CheckBoxLeftColumn_DateOpened.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxLeftColumn_DateOpened.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxLeftColumn_DateOpened.ChildControls = CType(resources.GetObject("CheckBoxLeftColumn_DateOpened.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLeftColumn_DateOpened.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxLeftColumn_DateOpened.Location = New System.Drawing.Point(0, 0)
            Me.CheckBoxLeftColumn_DateOpened.Name = "CheckBoxLeftColumn_DateOpened"
            Me.CheckBoxLeftColumn_DateOpened.OldestSibling = Nothing
            Me.CheckBoxLeftColumn_DateOpened.SecurityEnabled = True
            Me.CheckBoxLeftColumn_DateOpened.SiblingControls = CType(resources.GetObject("CheckBoxLeftColumn_DateOpened.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLeftColumn_DateOpened.Size = New System.Drawing.Size(267, 20)
            Me.CheckBoxLeftColumn_DateOpened.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxLeftColumn_DateOpened.TabIndex = 22
            Me.CheckBoxLeftColumn_DateOpened.TabOnEnter = True
            Me.CheckBoxLeftColumn_DateOpened.Text = "Date Opened"
            '
            'CheckBoxMiddleColumn_JobType
            '
            Me.CheckBoxMiddleColumn_JobType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxMiddleColumn_JobType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMiddleColumn_JobType.CheckValue = CType(0, Short)
            Me.CheckBoxMiddleColumn_JobType.CheckValueChecked = CType(1, Short)
            Me.CheckBoxMiddleColumn_JobType.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxMiddleColumn_JobType.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxMiddleColumn_JobType.ChildControls = CType(resources.GetObject("CheckBoxMiddleColumn_JobType.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMiddleColumn_JobType.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMiddleColumn_JobType.Location = New System.Drawing.Point(0, 104)
            Me.CheckBoxMiddleColumn_JobType.Name = "CheckBoxMiddleColumn_JobType"
            Me.CheckBoxMiddleColumn_JobType.OldestSibling = Nothing
            Me.CheckBoxMiddleColumn_JobType.SecurityEnabled = True
            Me.CheckBoxMiddleColumn_JobType.SiblingControls = CType(resources.GetObject("CheckBoxMiddleColumn_JobType.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMiddleColumn_JobType.Size = New System.Drawing.Size(267, 20)
            Me.CheckBoxMiddleColumn_JobType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMiddleColumn_JobType.TabIndex = 26
            Me.CheckBoxMiddleColumn_JobType.TabOnEnter = True
            Me.CheckBoxMiddleColumn_JobType.Text = "Job Type"
            '
            'CheckBoxMiddleColumn_Promotion
            '
            Me.CheckBoxMiddleColumn_Promotion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxMiddleColumn_Promotion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMiddleColumn_Promotion.CheckValue = CType(0, Short)
            Me.CheckBoxMiddleColumn_Promotion.CheckValueChecked = CType(1, Short)
            Me.CheckBoxMiddleColumn_Promotion.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxMiddleColumn_Promotion.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxMiddleColumn_Promotion.ChildControls = CType(resources.GetObject("CheckBoxMiddleColumn_Promotion.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMiddleColumn_Promotion.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMiddleColumn_Promotion.Location = New System.Drawing.Point(0, 156)
            Me.CheckBoxMiddleColumn_Promotion.Name = "CheckBoxMiddleColumn_Promotion"
            Me.CheckBoxMiddleColumn_Promotion.OldestSibling = Nothing
            Me.CheckBoxMiddleColumn_Promotion.SecurityEnabled = True
            Me.CheckBoxMiddleColumn_Promotion.SiblingControls = CType(resources.GetObject("CheckBoxMiddleColumn_Promotion.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMiddleColumn_Promotion.Size = New System.Drawing.Size(267, 20)
            Me.CheckBoxMiddleColumn_Promotion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMiddleColumn_Promotion.TabIndex = 28
            Me.CheckBoxMiddleColumn_Promotion.TabOnEnter = True
            Me.CheckBoxMiddleColumn_Promotion.Text = "Promotion"
            '
            'CheckBoxMiddleColumn_FormatAdSize
            '
            Me.CheckBoxMiddleColumn_FormatAdSize.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxMiddleColumn_FormatAdSize.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMiddleColumn_FormatAdSize.CheckValue = CType(0, Short)
            Me.CheckBoxMiddleColumn_FormatAdSize.CheckValueChecked = CType(1, Short)
            Me.CheckBoxMiddleColumn_FormatAdSize.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxMiddleColumn_FormatAdSize.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxMiddleColumn_FormatAdSize.ChildControls = CType(resources.GetObject("CheckBoxMiddleColumn_FormatAdSize.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMiddleColumn_FormatAdSize.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMiddleColumn_FormatAdSize.Location = New System.Drawing.Point(0, 78)
            Me.CheckBoxMiddleColumn_FormatAdSize.Name = "CheckBoxMiddleColumn_FormatAdSize"
            Me.CheckBoxMiddleColumn_FormatAdSize.OldestSibling = Nothing
            Me.CheckBoxMiddleColumn_FormatAdSize.SecurityEnabled = True
            Me.CheckBoxMiddleColumn_FormatAdSize.SiblingControls = CType(resources.GetObject("CheckBoxMiddleColumn_FormatAdSize.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMiddleColumn_FormatAdSize.Size = New System.Drawing.Size(267, 20)
            Me.CheckBoxMiddleColumn_FormatAdSize.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMiddleColumn_FormatAdSize.TabIndex = 25
            Me.CheckBoxMiddleColumn_FormatAdSize.TabOnEnter = True
            Me.CheckBoxMiddleColumn_FormatAdSize.Text = "Format"
            '
            'CheckBoxMiddleColumn_DueDate
            '
            Me.CheckBoxMiddleColumn_DueDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxMiddleColumn_DueDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMiddleColumn_DueDate.CheckValue = CType(0, Short)
            Me.CheckBoxMiddleColumn_DueDate.CheckValueChecked = CType(1, Short)
            Me.CheckBoxMiddleColumn_DueDate.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxMiddleColumn_DueDate.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxMiddleColumn_DueDate.ChildControls = CType(resources.GetObject("CheckBoxMiddleColumn_DueDate.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMiddleColumn_DueDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMiddleColumn_DueDate.Location = New System.Drawing.Point(0, 52)
            Me.CheckBoxMiddleColumn_DueDate.Name = "CheckBoxMiddleColumn_DueDate"
            Me.CheckBoxMiddleColumn_DueDate.OldestSibling = Nothing
            Me.CheckBoxMiddleColumn_DueDate.SecurityEnabled = True
            Me.CheckBoxMiddleColumn_DueDate.SiblingControls = CType(resources.GetObject("CheckBoxMiddleColumn_DueDate.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMiddleColumn_DueDate.Size = New System.Drawing.Size(267, 20)
            Me.CheckBoxMiddleColumn_DueDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMiddleColumn_DueDate.TabIndex = 24
            Me.CheckBoxMiddleColumn_DueDate.TabOnEnter = True
            Me.CheckBoxMiddleColumn_DueDate.Text = "Due Date"
            '
            'CheckBoxMiddleColumn_MarketCode
            '
            Me.CheckBoxMiddleColumn_MarketCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxMiddleColumn_MarketCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMiddleColumn_MarketCode.CheckValue = CType(0, Short)
            Me.CheckBoxMiddleColumn_MarketCode.CheckValueChecked = CType(1, Short)
            Me.CheckBoxMiddleColumn_MarketCode.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxMiddleColumn_MarketCode.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxMiddleColumn_MarketCode.ChildControls = CType(resources.GetObject("CheckBoxMiddleColumn_MarketCode.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMiddleColumn_MarketCode.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMiddleColumn_MarketCode.Location = New System.Drawing.Point(0, 130)
            Me.CheckBoxMiddleColumn_MarketCode.Name = "CheckBoxMiddleColumn_MarketCode"
            Me.CheckBoxMiddleColumn_MarketCode.OldestSibling = Nothing
            Me.CheckBoxMiddleColumn_MarketCode.SecurityEnabled = True
            Me.CheckBoxMiddleColumn_MarketCode.SiblingControls = CType(resources.GetObject("CheckBoxMiddleColumn_MarketCode.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMiddleColumn_MarketCode.Size = New System.Drawing.Size(267, 20)
            Me.CheckBoxMiddleColumn_MarketCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMiddleColumn_MarketCode.TabIndex = 27
            Me.CheckBoxMiddleColumn_MarketCode.TabOnEnter = True
            Me.CheckBoxMiddleColumn_MarketCode.Text = "Market"
            '
            'CheckBoxMiddleColumn_SCFormat
            '
            Me.CheckBoxMiddleColumn_SCFormat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxMiddleColumn_SCFormat.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMiddleColumn_SCFormat.CheckValue = CType(0, Short)
            Me.CheckBoxMiddleColumn_SCFormat.CheckValueChecked = CType(1, Short)
            Me.CheckBoxMiddleColumn_SCFormat.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxMiddleColumn_SCFormat.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxMiddleColumn_SCFormat.ChildControls = CType(resources.GetObject("CheckBoxMiddleColumn_SCFormat.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMiddleColumn_SCFormat.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMiddleColumn_SCFormat.Location = New System.Drawing.Point(0, 182)
            Me.CheckBoxMiddleColumn_SCFormat.Name = "CheckBoxMiddleColumn_SCFormat"
            Me.CheckBoxMiddleColumn_SCFormat.OldestSibling = Nothing
            Me.CheckBoxMiddleColumn_SCFormat.SecurityEnabled = True
            Me.CheckBoxMiddleColumn_SCFormat.SiblingControls = CType(resources.GetObject("CheckBoxMiddleColumn_SCFormat.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMiddleColumn_SCFormat.Size = New System.Drawing.Size(267, 20)
            Me.CheckBoxMiddleColumn_SCFormat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMiddleColumn_SCFormat.TabIndex = 29
            Me.CheckBoxMiddleColumn_SCFormat.TabOnEnter = True
            Me.CheckBoxMiddleColumn_SCFormat.Text = "Sales Class Format"
            '
            'PanelUserSelectedRequiredFields_LeftColumn
            '
            Me.PanelUserSelectedRequiredFields_LeftColumn.Controls.Add(Me.CheckBoxLeftColumn_Blackplate2)
            Me.PanelUserSelectedRequiredFields_LeftColumn.Controls.Add(Me.CheckBoxLeftColumn_Blackplate1)
            Me.PanelUserSelectedRequiredFields_LeftColumn.Controls.Add(Me.CheckBoxLeftColumn_ComponentBudget)
            Me.PanelUserSelectedRequiredFields_LeftColumn.Controls.Add(Me.CheckBoxMiddleColumn_ProductContact)
            Me.PanelUserSelectedRequiredFields_LeftColumn.Controls.Add(Me.CheckBoxLeftColumn_ClientReference)
            Me.PanelUserSelectedRequiredFields_LeftColumn.Controls.Add(Me.CheckBoxLeftColumn_AdNumber)
            Me.PanelUserSelectedRequiredFields_LeftColumn.Controls.Add(Me.CheckBoxLeftColumn_CoopBillingCode)
            Me.PanelUserSelectedRequiredFields_LeftColumn.Controls.Add(Me.CheckBoxLeftColumn_AlertGroup)
            Me.PanelUserSelectedRequiredFields_LeftColumn.Controls.Add(Me.CheckBoxLeftColumn_ComplexityCode)
            Me.PanelUserSelectedRequiredFields_LeftColumn.Controls.Add(Me.CheckBoxLeftColumn_AccountNumber)
            Me.PanelUserSelectedRequiredFields_LeftColumn.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelUserSelectedRequiredFields_LeftColumn.Location = New System.Drawing.Point(0, 0)
            Me.PanelUserSelectedRequiredFields_LeftColumn.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelUserSelectedRequiredFields_LeftColumn.Name = "PanelUserSelectedRequiredFields_LeftColumn"
            Me.PanelUserSelectedRequiredFields_LeftColumn.Size = New System.Drawing.Size(270, 254)
            Me.PanelUserSelectedRequiredFields_LeftColumn.TabIndex = 0
            '
            'CheckBoxLeftColumn_Blackplate2
            '
            Me.CheckBoxLeftColumn_Blackplate2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxLeftColumn_Blackplate2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxLeftColumn_Blackplate2.CheckValue = CType(0, Short)
            Me.CheckBoxLeftColumn_Blackplate2.CheckValueChecked = CType(1, Short)
            Me.CheckBoxLeftColumn_Blackplate2.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxLeftColumn_Blackplate2.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxLeftColumn_Blackplate2.ChildControls = CType(resources.GetObject("CheckBoxLeftColumn_Blackplate2.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLeftColumn_Blackplate2.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxLeftColumn_Blackplate2.Location = New System.Drawing.Point(0, 104)
            Me.CheckBoxLeftColumn_Blackplate2.Name = "CheckBoxLeftColumn_Blackplate2"
            Me.CheckBoxLeftColumn_Blackplate2.OldestSibling = Nothing
            Me.CheckBoxLeftColumn_Blackplate2.SecurityEnabled = True
            Me.CheckBoxLeftColumn_Blackplate2.SiblingControls = CType(resources.GetObject("CheckBoxLeftColumn_Blackplate2.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLeftColumn_Blackplate2.Size = New System.Drawing.Size(267, 20)
            Me.CheckBoxLeftColumn_Blackplate2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxLeftColumn_Blackplate2.TabIndex = 16
            Me.CheckBoxLeftColumn_Blackplate2.TabOnEnter = True
            Me.CheckBoxLeftColumn_Blackplate2.Text = "Blackplate 2"
            '
            'CheckBoxLeftColumn_Blackplate1
            '
            Me.CheckBoxLeftColumn_Blackplate1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxLeftColumn_Blackplate1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxLeftColumn_Blackplate1.CheckValue = CType(0, Short)
            Me.CheckBoxLeftColumn_Blackplate1.CheckValueChecked = CType(1, Short)
            Me.CheckBoxLeftColumn_Blackplate1.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxLeftColumn_Blackplate1.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxLeftColumn_Blackplate1.ChildControls = CType(resources.GetObject("CheckBoxLeftColumn_Blackplate1.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLeftColumn_Blackplate1.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxLeftColumn_Blackplate1.Location = New System.Drawing.Point(0, 78)
            Me.CheckBoxLeftColumn_Blackplate1.Name = "CheckBoxLeftColumn_Blackplate1"
            Me.CheckBoxLeftColumn_Blackplate1.OldestSibling = Nothing
            Me.CheckBoxLeftColumn_Blackplate1.SecurityEnabled = True
            Me.CheckBoxLeftColumn_Blackplate1.SiblingControls = CType(resources.GetObject("CheckBoxLeftColumn_Blackplate1.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLeftColumn_Blackplate1.Size = New System.Drawing.Size(267, 20)
            Me.CheckBoxLeftColumn_Blackplate1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxLeftColumn_Blackplate1.TabIndex = 15
            Me.CheckBoxLeftColumn_Blackplate1.TabOnEnter = True
            Me.CheckBoxLeftColumn_Blackplate1.Text = "Blackplate 1"
            '
            'CheckBoxLeftColumn_ComponentBudget
            '
            Me.CheckBoxLeftColumn_ComponentBudget.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxLeftColumn_ComponentBudget.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxLeftColumn_ComponentBudget.CheckValue = CType(0, Short)
            Me.CheckBoxLeftColumn_ComponentBudget.CheckValueChecked = CType(1, Short)
            Me.CheckBoxLeftColumn_ComponentBudget.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxLeftColumn_ComponentBudget.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxLeftColumn_ComponentBudget.ChildControls = CType(resources.GetObject("CheckBoxLeftColumn_ComponentBudget.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLeftColumn_ComponentBudget.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxLeftColumn_ComponentBudget.Location = New System.Drawing.Point(0, 130)
            Me.CheckBoxLeftColumn_ComponentBudget.Name = "CheckBoxLeftColumn_ComponentBudget"
            Me.CheckBoxLeftColumn_ComponentBudget.OldestSibling = Nothing
            Me.CheckBoxLeftColumn_ComponentBudget.SecurityEnabled = True
            Me.CheckBoxLeftColumn_ComponentBudget.SiblingControls = CType(resources.GetObject("CheckBoxLeftColumn_ComponentBudget.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLeftColumn_ComponentBudget.Size = New System.Drawing.Size(267, 20)
            Me.CheckBoxLeftColumn_ComponentBudget.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxLeftColumn_ComponentBudget.TabIndex = 17
            Me.CheckBoxLeftColumn_ComponentBudget.TabOnEnter = True
            Me.CheckBoxLeftColumn_ComponentBudget.Text = "Budget"
            '
            'CheckBoxMiddleColumn_ProductContact
            '
            Me.CheckBoxMiddleColumn_ProductContact.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxMiddleColumn_ProductContact.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMiddleColumn_ProductContact.CheckValue = CType(0, Short)
            Me.CheckBoxMiddleColumn_ProductContact.CheckValueChecked = CType(1, Short)
            Me.CheckBoxMiddleColumn_ProductContact.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxMiddleColumn_ProductContact.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxMiddleColumn_ProductContact.ChildControls = CType(resources.GetObject("CheckBoxMiddleColumn_ProductContact.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMiddleColumn_ProductContact.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMiddleColumn_ProductContact.Location = New System.Drawing.Point(0, 208)
            Me.CheckBoxMiddleColumn_ProductContact.Name = "CheckBoxMiddleColumn_ProductContact"
            Me.CheckBoxMiddleColumn_ProductContact.OldestSibling = Nothing
            Me.CheckBoxMiddleColumn_ProductContact.SecurityEnabled = True
            Me.CheckBoxMiddleColumn_ProductContact.SiblingControls = CType(resources.GetObject("CheckBoxMiddleColumn_ProductContact.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMiddleColumn_ProductContact.Size = New System.Drawing.Size(267, 20)
            Me.CheckBoxMiddleColumn_ProductContact.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMiddleColumn_ProductContact.TabIndex = 20
            Me.CheckBoxMiddleColumn_ProductContact.TabOnEnter = True
            Me.CheckBoxMiddleColumn_ProductContact.Text = "Contact"
            '
            'CheckBoxLeftColumn_ClientReference
            '
            Me.CheckBoxLeftColumn_ClientReference.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxLeftColumn_ClientReference.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxLeftColumn_ClientReference.CheckValue = CType(0, Short)
            Me.CheckBoxLeftColumn_ClientReference.CheckValueChecked = CType(1, Short)
            Me.CheckBoxLeftColumn_ClientReference.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxLeftColumn_ClientReference.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxLeftColumn_ClientReference.ChildControls = CType(resources.GetObject("CheckBoxLeftColumn_ClientReference.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLeftColumn_ClientReference.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxLeftColumn_ClientReference.Location = New System.Drawing.Point(0, 156)
            Me.CheckBoxLeftColumn_ClientReference.Name = "CheckBoxLeftColumn_ClientReference"
            Me.CheckBoxLeftColumn_ClientReference.OldestSibling = Nothing
            Me.CheckBoxLeftColumn_ClientReference.SecurityEnabled = True
            Me.CheckBoxLeftColumn_ClientReference.SiblingControls = CType(resources.GetObject("CheckBoxLeftColumn_ClientReference.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLeftColumn_ClientReference.Size = New System.Drawing.Size(267, 20)
            Me.CheckBoxLeftColumn_ClientReference.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxLeftColumn_ClientReference.TabIndex = 18
            Me.CheckBoxLeftColumn_ClientReference.TabOnEnter = True
            Me.CheckBoxLeftColumn_ClientReference.Text = "Client Reference"
            '
            'CheckBoxLeftColumn_AdNumber
            '
            Me.CheckBoxLeftColumn_AdNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxLeftColumn_AdNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxLeftColumn_AdNumber.CheckValue = CType(0, Short)
            Me.CheckBoxLeftColumn_AdNumber.CheckValueChecked = CType(1, Short)
            Me.CheckBoxLeftColumn_AdNumber.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxLeftColumn_AdNumber.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxLeftColumn_AdNumber.ChildControls = CType(resources.GetObject("CheckBoxLeftColumn_AdNumber.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLeftColumn_AdNumber.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxLeftColumn_AdNumber.Location = New System.Drawing.Point(0, 26)
            Me.CheckBoxLeftColumn_AdNumber.Name = "CheckBoxLeftColumn_AdNumber"
            Me.CheckBoxLeftColumn_AdNumber.OldestSibling = Nothing
            Me.CheckBoxLeftColumn_AdNumber.SecurityEnabled = True
            Me.CheckBoxLeftColumn_AdNumber.SiblingControls = CType(resources.GetObject("CheckBoxLeftColumn_AdNumber.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLeftColumn_AdNumber.Size = New System.Drawing.Size(267, 20)
            Me.CheckBoxLeftColumn_AdNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxLeftColumn_AdNumber.TabIndex = 13
            Me.CheckBoxLeftColumn_AdNumber.TabOnEnter = True
            Me.CheckBoxLeftColumn_AdNumber.Text = "Ad Number"
            '
            'CheckBoxLeftColumn_CoopBillingCode
            '
            Me.CheckBoxLeftColumn_CoopBillingCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxLeftColumn_CoopBillingCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxLeftColumn_CoopBillingCode.CheckValue = CType(0, Short)
            Me.CheckBoxLeftColumn_CoopBillingCode.CheckValueChecked = CType(1, Short)
            Me.CheckBoxLeftColumn_CoopBillingCode.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxLeftColumn_CoopBillingCode.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxLeftColumn_CoopBillingCode.ChildControls = CType(resources.GetObject("CheckBoxLeftColumn_CoopBillingCode.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLeftColumn_CoopBillingCode.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxLeftColumn_CoopBillingCode.Location = New System.Drawing.Point(0, 234)
            Me.CheckBoxLeftColumn_CoopBillingCode.Name = "CheckBoxLeftColumn_CoopBillingCode"
            Me.CheckBoxLeftColumn_CoopBillingCode.OldestSibling = Nothing
            Me.CheckBoxLeftColumn_CoopBillingCode.SecurityEnabled = True
            Me.CheckBoxLeftColumn_CoopBillingCode.SiblingControls = CType(resources.GetObject("CheckBoxLeftColumn_CoopBillingCode.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLeftColumn_CoopBillingCode.Size = New System.Drawing.Size(267, 20)
            Me.CheckBoxLeftColumn_CoopBillingCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxLeftColumn_CoopBillingCode.TabIndex = 21
            Me.CheckBoxLeftColumn_CoopBillingCode.TabOnEnter = True
            Me.CheckBoxLeftColumn_CoopBillingCode.Text = "Coop Billing"
            '
            'CheckBoxLeftColumn_AlertGroup
            '
            Me.CheckBoxLeftColumn_AlertGroup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxLeftColumn_AlertGroup.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxLeftColumn_AlertGroup.CheckValue = CType(0, Short)
            Me.CheckBoxLeftColumn_AlertGroup.CheckValueChecked = CType(1, Short)
            Me.CheckBoxLeftColumn_AlertGroup.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxLeftColumn_AlertGroup.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxLeftColumn_AlertGroup.ChildControls = CType(resources.GetObject("CheckBoxLeftColumn_AlertGroup.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLeftColumn_AlertGroup.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxLeftColumn_AlertGroup.Location = New System.Drawing.Point(0, 52)
            Me.CheckBoxLeftColumn_AlertGroup.Name = "CheckBoxLeftColumn_AlertGroup"
            Me.CheckBoxLeftColumn_AlertGroup.OldestSibling = Nothing
            Me.CheckBoxLeftColumn_AlertGroup.SecurityEnabled = True
            Me.CheckBoxLeftColumn_AlertGroup.SiblingControls = CType(resources.GetObject("CheckBoxLeftColumn_AlertGroup.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLeftColumn_AlertGroup.Size = New System.Drawing.Size(267, 20)
            Me.CheckBoxLeftColumn_AlertGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxLeftColumn_AlertGroup.TabIndex = 14
            Me.CheckBoxLeftColumn_AlertGroup.TabOnEnter = True
            Me.CheckBoxLeftColumn_AlertGroup.Text = "Alert Group"
            '
            'CheckBoxLeftColumn_ComplexityCode
            '
            Me.CheckBoxLeftColumn_ComplexityCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxLeftColumn_ComplexityCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxLeftColumn_ComplexityCode.CheckValue = CType(0, Short)
            Me.CheckBoxLeftColumn_ComplexityCode.CheckValueChecked = CType(1, Short)
            Me.CheckBoxLeftColumn_ComplexityCode.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxLeftColumn_ComplexityCode.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxLeftColumn_ComplexityCode.ChildControls = CType(resources.GetObject("CheckBoxLeftColumn_ComplexityCode.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLeftColumn_ComplexityCode.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxLeftColumn_ComplexityCode.Location = New System.Drawing.Point(0, 182)
            Me.CheckBoxLeftColumn_ComplexityCode.Name = "CheckBoxLeftColumn_ComplexityCode"
            Me.CheckBoxLeftColumn_ComplexityCode.OldestSibling = Nothing
            Me.CheckBoxLeftColumn_ComplexityCode.SecurityEnabled = True
            Me.CheckBoxLeftColumn_ComplexityCode.SiblingControls = CType(resources.GetObject("CheckBoxLeftColumn_ComplexityCode.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLeftColumn_ComplexityCode.Size = New System.Drawing.Size(267, 20)
            Me.CheckBoxLeftColumn_ComplexityCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxLeftColumn_ComplexityCode.TabIndex = 19
            Me.CheckBoxLeftColumn_ComplexityCode.TabOnEnter = True
            Me.CheckBoxLeftColumn_ComplexityCode.Text = "Complexity"
            '
            'CheckBoxLeftColumn_AccountNumber
            '
            Me.CheckBoxLeftColumn_AccountNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxLeftColumn_AccountNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxLeftColumn_AccountNumber.CheckValue = CType(0, Short)
            Me.CheckBoxLeftColumn_AccountNumber.CheckValueChecked = CType(1, Short)
            Me.CheckBoxLeftColumn_AccountNumber.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxLeftColumn_AccountNumber.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxLeftColumn_AccountNumber.ChildControls = CType(resources.GetObject("CheckBoxLeftColumn_AccountNumber.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLeftColumn_AccountNumber.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxLeftColumn_AccountNumber.Location = New System.Drawing.Point(0, 0)
            Me.CheckBoxLeftColumn_AccountNumber.Name = "CheckBoxLeftColumn_AccountNumber"
            Me.CheckBoxLeftColumn_AccountNumber.OldestSibling = Nothing
            Me.CheckBoxLeftColumn_AccountNumber.SecurityEnabled = True
            Me.CheckBoxLeftColumn_AccountNumber.SiblingControls = CType(resources.GetObject("CheckBoxLeftColumn_AccountNumber.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLeftColumn_AccountNumber.Size = New System.Drawing.Size(267, 20)
            Me.CheckBoxLeftColumn_AccountNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxLeftColumn_AccountNumber.TabIndex = 12
            Me.CheckBoxLeftColumn_AccountNumber.TabOnEnter = True
            Me.CheckBoxLeftColumn_AccountNumber.Text = "Account Number"
            '
            'CheckBoxUserSelectedRequiredFields_OverrideAgencySettings
            '
            Me.CheckBoxUserSelectedRequiredFields_OverrideAgencySettings.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxUserSelectedRequiredFields_OverrideAgencySettings.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.CheckBoxUserSelectedRequiredFields_OverrideAgencySettings.BackgroundStyle.BorderBottomColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarCaptionText
            Me.CheckBoxUserSelectedRequiredFields_OverrideAgencySettings.BackgroundStyle.BorderBottomWidth = 1
            Me.CheckBoxUserSelectedRequiredFields_OverrideAgencySettings.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarCaptionText
            Me.CheckBoxUserSelectedRequiredFields_OverrideAgencySettings.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.CheckBoxUserSelectedRequiredFields_OverrideAgencySettings.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.CheckBoxUserSelectedRequiredFields_OverrideAgencySettings.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.CheckBoxUserSelectedRequiredFields_OverrideAgencySettings.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxUserSelectedRequiredFields_OverrideAgencySettings.CheckValue = CType(0, Short)
            Me.CheckBoxUserSelectedRequiredFields_OverrideAgencySettings.CheckValueChecked = CType(1, Short)
            Me.CheckBoxUserSelectedRequiredFields_OverrideAgencySettings.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxUserSelectedRequiredFields_OverrideAgencySettings.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxUserSelectedRequiredFields_OverrideAgencySettings.ChildControls = CType(resources.GetObject("CheckBoxUserSelectedRequiredFields_OverrideAgencySettings.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxUserSelectedRequiredFields_OverrideAgencySettings.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxUserSelectedRequiredFields_OverrideAgencySettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CheckBoxUserSelectedRequiredFields_OverrideAgencySettings.Location = New System.Drawing.Point(5, 25)
            Me.CheckBoxUserSelectedRequiredFields_OverrideAgencySettings.Name = "CheckBoxUserSelectedRequiredFields_OverrideAgencySettings"
            Me.CheckBoxUserSelectedRequiredFields_OverrideAgencySettings.OldestSibling = Nothing
            Me.CheckBoxUserSelectedRequiredFields_OverrideAgencySettings.SecurityEnabled = True
            Me.CheckBoxUserSelectedRequiredFields_OverrideAgencySettings.SiblingControls = CType(resources.GetObject("CheckBoxUserSelectedRequiredFields_OverrideAgencySettings.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxUserSelectedRequiredFields_OverrideAgencySettings.Size = New System.Drawing.Size(823, 23)
            Me.CheckBoxUserSelectedRequiredFields_OverrideAgencySettings.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxUserSelectedRequiredFields_OverrideAgencySettings.TabIndex = 1
            Me.CheckBoxUserSelectedRequiredFields_OverrideAgencySettings.TabOnEnter = True
            Me.CheckBoxUserSelectedRequiredFields_OverrideAgencySettings.Text = "Override Agency Settings"
            '
            'CheckBoxRequiredFields_RequireProductCategorySelectionInTimesheet
            '
            Me.CheckBoxRequiredFields_RequireProductCategorySelectionInTimesheet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxRequiredFields_RequireProductCategorySelectionInTimesheet.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxRequiredFields_RequireProductCategorySelectionInTimesheet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxRequiredFields_RequireProductCategorySelectionInTimesheet.CheckValue = CType(0, Short)
            Me.CheckBoxRequiredFields_RequireProductCategorySelectionInTimesheet.CheckValueChecked = CType(1, Short)
            Me.CheckBoxRequiredFields_RequireProductCategorySelectionInTimesheet.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxRequiredFields_RequireProductCategorySelectionInTimesheet.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxRequiredFields_RequireProductCategorySelectionInTimesheet.ChildControls = CType(resources.GetObject("CheckBoxRequiredFields_RequireProductCategorySelectionInTimesheet.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRequiredFields_RequireProductCategorySelectionInTimesheet.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxRequiredFields_RequireProductCategorySelectionInTimesheet.Location = New System.Drawing.Point(7, 394)
            Me.CheckBoxRequiredFields_RequireProductCategorySelectionInTimesheet.Name = "CheckBoxRequiredFields_RequireProductCategorySelectionInTimesheet"
            Me.CheckBoxRequiredFields_RequireProductCategorySelectionInTimesheet.OldestSibling = Nothing
            Me.CheckBoxRequiredFields_RequireProductCategorySelectionInTimesheet.SecurityEnabled = True
            Me.CheckBoxRequiredFields_RequireProductCategorySelectionInTimesheet.SiblingControls = CType(resources.GetObject("CheckBoxRequiredFields_RequireProductCategorySelectionInTimesheet.SiblingControls" &
        ""), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRequiredFields_RequireProductCategorySelectionInTimesheet.Size = New System.Drawing.Size(820, 20)
            Me.CheckBoxRequiredFields_RequireProductCategorySelectionInTimesheet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxRequiredFields_RequireProductCategorySelectionInTimesheet.TabIndex = 4
            Me.CheckBoxRequiredFields_RequireProductCategorySelectionInTimesheet.TabOnEnter = True
            Me.CheckBoxRequiredFields_RequireProductCategorySelectionInTimesheet.Text = "Require product category selection in timesheet"
            Me.CheckBoxRequiredFields_RequireProductCategorySelectionInTimesheet.Visible = False
            '
            'GroupBoxUserSelectedRequiredFields_JobsAndMedia
            '
            Me.GroupBoxUserSelectedRequiredFields_JobsAndMedia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxUserSelectedRequiredFields_JobsAndMedia.Controls.Add(Me.CheckBoxJobsAndMedia_FiscalPeriod)
            Me.GroupBoxUserSelectedRequiredFields_JobsAndMedia.Controls.Add(Me.CheckBoxJobsAndMedia_CampaignCode)
            Me.GroupBoxUserSelectedRequiredFields_JobsAndMedia.Location = New System.Drawing.Point(7, 314)
            Me.GroupBoxUserSelectedRequiredFields_JobsAndMedia.Name = "GroupBoxUserSelectedRequiredFields_JobsAndMedia"
            Me.GroupBoxUserSelectedRequiredFields_JobsAndMedia.Size = New System.Drawing.Size(820, 48)
            Me.GroupBoxUserSelectedRequiredFields_JobsAndMedia.TabIndex = 3
            Me.GroupBoxUserSelectedRequiredFields_JobsAndMedia.Text = "Jobs and Media"
            '
            'CheckBoxJobsAndMedia_FiscalPeriod
            '
            '
            '
            '
            Me.CheckBoxJobsAndMedia_FiscalPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxJobsAndMedia_FiscalPeriod.CheckValue = CType(0, Short)
            Me.CheckBoxJobsAndMedia_FiscalPeriod.CheckValueChecked = CType(1, Short)
            Me.CheckBoxJobsAndMedia_FiscalPeriod.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxJobsAndMedia_FiscalPeriod.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxJobsAndMedia_FiscalPeriod.ChildControls = CType(resources.GetObject("CheckBoxJobsAndMedia_FiscalPeriod.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxJobsAndMedia_FiscalPeriod.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxJobsAndMedia_FiscalPeriod.Location = New System.Drawing.Point(115, 25)
            Me.CheckBoxJobsAndMedia_FiscalPeriod.Name = "CheckBoxJobsAndMedia_FiscalPeriod"
            Me.CheckBoxJobsAndMedia_FiscalPeriod.OldestSibling = Nothing
            Me.CheckBoxJobsAndMedia_FiscalPeriod.SecurityEnabled = True
            Me.CheckBoxJobsAndMedia_FiscalPeriod.SiblingControls = CType(resources.GetObject("CheckBoxJobsAndMedia_FiscalPeriod.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxJobsAndMedia_FiscalPeriod.Size = New System.Drawing.Size(104, 20)
            Me.CheckBoxJobsAndMedia_FiscalPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxJobsAndMedia_FiscalPeriod.TabIndex = 34
            Me.CheckBoxJobsAndMedia_FiscalPeriod.TabOnEnter = True
            Me.CheckBoxJobsAndMedia_FiscalPeriod.Text = "Fiscal Period"
            '
            'CheckBoxJobsAndMedia_CampaignCode
            '
            '
            '
            '
            Me.CheckBoxJobsAndMedia_CampaignCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxJobsAndMedia_CampaignCode.CheckValue = CType(0, Short)
            Me.CheckBoxJobsAndMedia_CampaignCode.CheckValueChecked = CType(1, Short)
            Me.CheckBoxJobsAndMedia_CampaignCode.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxJobsAndMedia_CampaignCode.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxJobsAndMedia_CampaignCode.ChildControls = CType(resources.GetObject("CheckBoxJobsAndMedia_CampaignCode.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxJobsAndMedia_CampaignCode.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxJobsAndMedia_CampaignCode.Location = New System.Drawing.Point(5, 25)
            Me.CheckBoxJobsAndMedia_CampaignCode.Name = "CheckBoxJobsAndMedia_CampaignCode"
            Me.CheckBoxJobsAndMedia_CampaignCode.OldestSibling = Nothing
            Me.CheckBoxJobsAndMedia_CampaignCode.SecurityEnabled = True
            Me.CheckBoxJobsAndMedia_CampaignCode.SiblingControls = CType(resources.GetObject("CheckBoxJobsAndMedia_CampaignCode.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxJobsAndMedia_CampaignCode.Size = New System.Drawing.Size(104, 20)
            Me.CheckBoxJobsAndMedia_CampaignCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxJobsAndMedia_CampaignCode.TabIndex = 33
            Me.CheckBoxJobsAndMedia_CampaignCode.TabOnEnter = True
            Me.CheckBoxJobsAndMedia_CampaignCode.Text = "Campaign"
            '
            'TabItemClientDetails_RequiredFieldsTab
            '
            Me.TabItemClientDetails_RequiredFieldsTab.AttachedControl = Me.TabControlPanelRequiredFieldsTab_RequiredFields
            Me.TabItemClientDetails_RequiredFieldsTab.Name = "TabItemClientDetails_RequiredFieldsTab"
            Me.TabItemClientDetails_RequiredFieldsTab.Text = "Required Fields"
            '
            'TabControlPanelClientDetails_MediaInvoiceFormat
            '
            Me.TabControlPanelClientDetails_MediaInvoiceFormat.AutoScroll = True
            Me.TabControlPanelClientDetails_MediaInvoiceFormat.Controls.Add(Me.GroupBoxMediaInvoiceFormat_Radio)
            Me.TabControlPanelClientDetails_MediaInvoiceFormat.Controls.Add(Me.GroupBoxMediaInvoiceFormat_Newspaper)
            Me.TabControlPanelClientDetails_MediaInvoiceFormat.Controls.Add(Me.GroupBoxMediaInvoiceFormat_OutOfHome)
            Me.TabControlPanelClientDetails_MediaInvoiceFormat.Controls.Add(Me.GroupBoxMediaInvoiceFormat_Magazine)
            Me.TabControlPanelClientDetails_MediaInvoiceFormat.Controls.Add(Me.GroupBoxMediaInvoiceFormat_Internet)
            Me.TabControlPanelClientDetails_MediaInvoiceFormat.Controls.Add(Me.GroupBoxMediaInvoiceFormat_TV)
            Me.TabControlPanelClientDetails_MediaInvoiceFormat.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelClientDetails_MediaInvoiceFormat.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelClientDetails_MediaInvoiceFormat.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelClientDetails_MediaInvoiceFormat.Name = "TabControlPanelClientDetails_MediaInvoiceFormat"
            Me.TabControlPanelClientDetails_MediaInvoiceFormat.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelClientDetails_MediaInvoiceFormat.Size = New System.Drawing.Size(845, 505)
            Me.TabControlPanelClientDetails_MediaInvoiceFormat.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelClientDetails_MediaInvoiceFormat.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelClientDetails_MediaInvoiceFormat.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelClientDetails_MediaInvoiceFormat.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelClientDetails_MediaInvoiceFormat.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelClientDetails_MediaInvoiceFormat.Style.GradientAngle = 90
            Me.TabControlPanelClientDetails_MediaInvoiceFormat.TabIndex = 0
            Me.TabControlPanelClientDetails_MediaInvoiceFormat.TabItem = Me.TabItemClientDetails_MediaInvoiceFormatTab
            '
            'GroupBoxMediaInvoiceFormat_Radio
            '
            Me.GroupBoxMediaInvoiceFormat_Radio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxMediaInvoiceFormat_Radio.Controls.Add(Me.LabelRadioInvoiceFormat_Note)
            Me.GroupBoxMediaInvoiceFormat_Radio.Controls.Add(Me.SearchableComboBoxRadioInvoiceFormat_Format)
            Me.GroupBoxMediaInvoiceFormat_Radio.Controls.Add(Me.LabelRadioInvoiceFormat_Format)
            Me.GroupBoxMediaInvoiceFormat_Radio.Controls.Add(Me.LabelRadioInvoiceFormat_Type)
            Me.GroupBoxMediaInvoiceFormat_Radio.Controls.Add(Me.ComboBoxRadioInvoiceFormat_Type)
            Me.GroupBoxMediaInvoiceFormat_Radio.Location = New System.Drawing.Point(6, 338)
            Me.GroupBoxMediaInvoiceFormat_Radio.Name = "GroupBoxMediaInvoiceFormat_Radio"
            Me.GroupBoxMediaInvoiceFormat_Radio.Size = New System.Drawing.Size(835, 77)
            Me.GroupBoxMediaInvoiceFormat_Radio.TabIndex = 4
            Me.GroupBoxMediaInvoiceFormat_Radio.Text = "Radio Invoice Format"
            '
            'LabelRadioInvoiceFormat_Note
            '
            Me.LabelRadioInvoiceFormat_Note.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRadioInvoiceFormat_Note.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRadioInvoiceFormat_Note.Location = New System.Drawing.Point(226, 25)
            Me.LabelRadioInvoiceFormat_Note.Name = "LabelRadioInvoiceFormat_Note"
            Me.LabelRadioInvoiceFormat_Note.Size = New System.Drawing.Size(530, 20)
            Me.LabelRadioInvoiceFormat_Note.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRadioInvoiceFormat_Note.TabIndex = 20
            Me.LabelRadioInvoiceFormat_Note.Text = "(Standard Format is established and configured in 'Invoice Printing')"
            '
            'SearchableComboBoxRadioInvoiceFormat_Format
            '
            Me.SearchableComboBoxRadioInvoiceFormat_Format.ActiveFilterString = ""
            Me.SearchableComboBoxRadioInvoiceFormat_Format.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxRadioInvoiceFormat_Format.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxRadioInvoiceFormat_Format.AutoFillMode = False
            Me.SearchableComboBoxRadioInvoiceFormat_Format.BookmarkingEnabled = False
            Me.SearchableComboBoxRadioInvoiceFormat_Format.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.CustomReport
            Me.SearchableComboBoxRadioInvoiceFormat_Format.DataSource = Nothing
            Me.SearchableComboBoxRadioInvoiceFormat_Format.DisableMouseWheel = False
            Me.SearchableComboBoxRadioInvoiceFormat_Format.DisplayName = ""
            Me.SearchableComboBoxRadioInvoiceFormat_Format.EnterMoveNextControl = True
            Me.SearchableComboBoxRadioInvoiceFormat_Format.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxRadioInvoiceFormat_Format.Location = New System.Drawing.Point(60, 50)
            Me.SearchableComboBoxRadioInvoiceFormat_Format.Name = "SearchableComboBoxRadioInvoiceFormat_Format"
            Me.SearchableComboBoxRadioInvoiceFormat_Format.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxRadioInvoiceFormat_Format.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxRadioInvoiceFormat_Format.Properties.NullText = "Select Report"
            Me.SearchableComboBoxRadioInvoiceFormat_Format.Properties.PopupView = Me.GridView6
            Me.SearchableComboBoxRadioInvoiceFormat_Format.Properties.ShowClearButton = False
            Me.SearchableComboBoxRadioInvoiceFormat_Format.Properties.ValueMember = "Code"
            Me.SearchableComboBoxRadioInvoiceFormat_Format.SecurityEnabled = True
            Me.SearchableComboBoxRadioInvoiceFormat_Format.SelectedValue = Nothing
            Me.SearchableComboBoxRadioInvoiceFormat_Format.Size = New System.Drawing.Size(769, 20)
            Me.SearchableComboBoxRadioInvoiceFormat_Format.TabIndex = 4
            '
            'GridView6
            '
            Me.GridView6.AFActiveFilterString = ""
            Me.GridView6.AllowExtraItemsInGridLookupEdits = True
            Me.GridView6.AutoFilterLookupColumns = False
            Me.GridView6.AutoloadRepositoryDatasource = True
            Me.GridView6.DataSourceClearing = False
            Me.GridView6.EnableDisabledRows = False
            Me.GridView6.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView6.Name = "GridView6"
            Me.GridView6.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView6.OptionsView.ShowGroupPanel = False
            Me.GridView6.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView6.RunStandardValidation = True
            Me.GridView6.SkipAddingControlsOnModifyColumn = False
            Me.GridView6.SkipSettingFontOnModifyColumn = False
            '
            'LabelRadioInvoiceFormat_Format
            '
            Me.LabelRadioInvoiceFormat_Format.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRadioInvoiceFormat_Format.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRadioInvoiceFormat_Format.Location = New System.Drawing.Point(7, 50)
            Me.LabelRadioInvoiceFormat_Format.Name = "LabelRadioInvoiceFormat_Format"
            Me.LabelRadioInvoiceFormat_Format.Size = New System.Drawing.Size(47, 20)
            Me.LabelRadioInvoiceFormat_Format.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRadioInvoiceFormat_Format.TabIndex = 23
            Me.LabelRadioInvoiceFormat_Format.Text = "Format:"
            '
            'LabelRadioInvoiceFormat_Type
            '
            Me.LabelRadioInvoiceFormat_Type.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRadioInvoiceFormat_Type.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRadioInvoiceFormat_Type.Location = New System.Drawing.Point(6, 25)
            Me.LabelRadioInvoiceFormat_Type.Name = "LabelRadioInvoiceFormat_Type"
            Me.LabelRadioInvoiceFormat_Type.Size = New System.Drawing.Size(47, 20)
            Me.LabelRadioInvoiceFormat_Type.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRadioInvoiceFormat_Type.TabIndex = 21
            Me.LabelRadioInvoiceFormat_Type.Text = "Type:"
            '
            'ComboBoxRadioInvoiceFormat_Type
            '
            Me.ComboBoxRadioInvoiceFormat_Type.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxRadioInvoiceFormat_Type.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxRadioInvoiceFormat_Type.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxRadioInvoiceFormat_Type.AutoFindItemInDataSource = False
            Me.ComboBoxRadioInvoiceFormat_Type.AutoSelectSingleItemDatasource = False
            Me.ComboBoxRadioInvoiceFormat_Type.BookmarkingEnabled = False
            Me.ComboBoxRadioInvoiceFormat_Type.ClientCode = ""
            Me.ComboBoxRadioInvoiceFormat_Type.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.InvoiceFormat
            Me.ComboBoxRadioInvoiceFormat_Type.DisableMouseWheel = False
            Me.ComboBoxRadioInvoiceFormat_Type.DisplayMember = "Description"
            Me.ComboBoxRadioInvoiceFormat_Type.DisplayName = ""
            Me.ComboBoxRadioInvoiceFormat_Type.DivisionCode = ""
            Me.ComboBoxRadioInvoiceFormat_Type.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxRadioInvoiceFormat_Type.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxRadioInvoiceFormat_Type.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxRadioInvoiceFormat_Type.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxRadioInvoiceFormat_Type.FocusHighlightEnabled = True
            Me.ComboBoxRadioInvoiceFormat_Type.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxRadioInvoiceFormat_Type.FormattingEnabled = True
            Me.ComboBoxRadioInvoiceFormat_Type.ItemHeight = 16
            Me.ComboBoxRadioInvoiceFormat_Type.Location = New System.Drawing.Point(60, 25)
            Me.ComboBoxRadioInvoiceFormat_Type.Name = "ComboBoxRadioInvoiceFormat_Type"
            Me.ComboBoxRadioInvoiceFormat_Type.ReadOnly = False
            Me.ComboBoxRadioInvoiceFormat_Type.SecurityEnabled = True
            Me.ComboBoxRadioInvoiceFormat_Type.Size = New System.Drawing.Size(160, 22)
            Me.ComboBoxRadioInvoiceFormat_Type.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxRadioInvoiceFormat_Type.TabIndex = 1
            Me.ComboBoxRadioInvoiceFormat_Type.TabOnEnter = True
            Me.ComboBoxRadioInvoiceFormat_Type.ValueMember = "Code"
            Me.ComboBoxRadioInvoiceFormat_Type.WatermarkText = "Select Invoice Format"
            '
            'GroupBoxMediaInvoiceFormat_Newspaper
            '
            Me.GroupBoxMediaInvoiceFormat_Newspaper.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxMediaInvoiceFormat_Newspaper.Controls.Add(Me.LabelNewspaperInvoiceFormat_Note)
            Me.GroupBoxMediaInvoiceFormat_Newspaper.Controls.Add(Me.LabelNewspaperInvoiceFormat_Format)
            Me.GroupBoxMediaInvoiceFormat_Newspaper.Controls.Add(Me.LabelNewspaperInvoiceFormat_Type)
            Me.GroupBoxMediaInvoiceFormat_Newspaper.Controls.Add(Me.ComboBoxNewspaperInvoiceFormat_Type)
            Me.GroupBoxMediaInvoiceFormat_Newspaper.Controls.Add(Me.SearchableComboBoxNewspaperInvoiceFormat_Format)
            Me.GroupBoxMediaInvoiceFormat_Newspaper.Location = New System.Drawing.Point(6, 89)
            Me.GroupBoxMediaInvoiceFormat_Newspaper.Name = "GroupBoxMediaInvoiceFormat_Newspaper"
            Me.GroupBoxMediaInvoiceFormat_Newspaper.Size = New System.Drawing.Size(835, 77)
            Me.GroupBoxMediaInvoiceFormat_Newspaper.TabIndex = 1
            Me.GroupBoxMediaInvoiceFormat_Newspaper.Text = "Newspaper Invoice Format"
            '
            'LabelNewspaperInvoiceFormat_Note
            '
            Me.LabelNewspaperInvoiceFormat_Note.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelNewspaperInvoiceFormat_Note.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelNewspaperInvoiceFormat_Note.Location = New System.Drawing.Point(226, 25)
            Me.LabelNewspaperInvoiceFormat_Note.Name = "LabelNewspaperInvoiceFormat_Note"
            Me.LabelNewspaperInvoiceFormat_Note.Size = New System.Drawing.Size(530, 20)
            Me.LabelNewspaperInvoiceFormat_Note.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelNewspaperInvoiceFormat_Note.TabIndex = 15
            Me.LabelNewspaperInvoiceFormat_Note.Text = "(Standard Format is established and configured in 'Invoice Printing')"
            '
            'LabelNewspaperInvoiceFormat_Format
            '
            Me.LabelNewspaperInvoiceFormat_Format.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelNewspaperInvoiceFormat_Format.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelNewspaperInvoiceFormat_Format.Location = New System.Drawing.Point(7, 50)
            Me.LabelNewspaperInvoiceFormat_Format.Name = "LabelNewspaperInvoiceFormat_Format"
            Me.LabelNewspaperInvoiceFormat_Format.Size = New System.Drawing.Size(47, 20)
            Me.LabelNewspaperInvoiceFormat_Format.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelNewspaperInvoiceFormat_Format.TabIndex = 3
            Me.LabelNewspaperInvoiceFormat_Format.Text = "Format:"
            '
            'LabelNewspaperInvoiceFormat_Type
            '
            Me.LabelNewspaperInvoiceFormat_Type.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelNewspaperInvoiceFormat_Type.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelNewspaperInvoiceFormat_Type.Location = New System.Drawing.Point(6, 25)
            Me.LabelNewspaperInvoiceFormat_Type.Name = "LabelNewspaperInvoiceFormat_Type"
            Me.LabelNewspaperInvoiceFormat_Type.Size = New System.Drawing.Size(47, 20)
            Me.LabelNewspaperInvoiceFormat_Type.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelNewspaperInvoiceFormat_Type.TabIndex = 1
            Me.LabelNewspaperInvoiceFormat_Type.Text = "Type:"
            '
            'ComboBoxNewspaperInvoiceFormat_Type
            '
            Me.ComboBoxNewspaperInvoiceFormat_Type.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxNewspaperInvoiceFormat_Type.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxNewspaperInvoiceFormat_Type.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxNewspaperInvoiceFormat_Type.AutoFindItemInDataSource = False
            Me.ComboBoxNewspaperInvoiceFormat_Type.AutoSelectSingleItemDatasource = False
            Me.ComboBoxNewspaperInvoiceFormat_Type.BookmarkingEnabled = False
            Me.ComboBoxNewspaperInvoiceFormat_Type.ClientCode = ""
            Me.ComboBoxNewspaperInvoiceFormat_Type.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.InvoiceFormat
            Me.ComboBoxNewspaperInvoiceFormat_Type.DisableMouseWheel = False
            Me.ComboBoxNewspaperInvoiceFormat_Type.DisplayMember = "Description"
            Me.ComboBoxNewspaperInvoiceFormat_Type.DisplayName = ""
            Me.ComboBoxNewspaperInvoiceFormat_Type.DivisionCode = ""
            Me.ComboBoxNewspaperInvoiceFormat_Type.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxNewspaperInvoiceFormat_Type.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxNewspaperInvoiceFormat_Type.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxNewspaperInvoiceFormat_Type.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxNewspaperInvoiceFormat_Type.FocusHighlightEnabled = True
            Me.ComboBoxNewspaperInvoiceFormat_Type.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxNewspaperInvoiceFormat_Type.FormattingEnabled = True
            Me.ComboBoxNewspaperInvoiceFormat_Type.ItemHeight = 16
            Me.ComboBoxNewspaperInvoiceFormat_Type.Location = New System.Drawing.Point(60, 25)
            Me.ComboBoxNewspaperInvoiceFormat_Type.Name = "ComboBoxNewspaperInvoiceFormat_Type"
            Me.ComboBoxNewspaperInvoiceFormat_Type.ReadOnly = False
            Me.ComboBoxNewspaperInvoiceFormat_Type.SecurityEnabled = True
            Me.ComboBoxNewspaperInvoiceFormat_Type.Size = New System.Drawing.Size(160, 22)
            Me.ComboBoxNewspaperInvoiceFormat_Type.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxNewspaperInvoiceFormat_Type.TabIndex = 1
            Me.ComboBoxNewspaperInvoiceFormat_Type.TabOnEnter = True
            Me.ComboBoxNewspaperInvoiceFormat_Type.ValueMember = "Code"
            Me.ComboBoxNewspaperInvoiceFormat_Type.WatermarkText = "Select Invoice Format"
            '
            'SearchableComboBoxNewspaperInvoiceFormat_Format
            '
            Me.SearchableComboBoxNewspaperInvoiceFormat_Format.ActiveFilterString = ""
            Me.SearchableComboBoxNewspaperInvoiceFormat_Format.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxNewspaperInvoiceFormat_Format.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxNewspaperInvoiceFormat_Format.AutoFillMode = False
            Me.SearchableComboBoxNewspaperInvoiceFormat_Format.BookmarkingEnabled = False
            Me.SearchableComboBoxNewspaperInvoiceFormat_Format.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.CustomReport
            Me.SearchableComboBoxNewspaperInvoiceFormat_Format.DataSource = Nothing
            Me.SearchableComboBoxNewspaperInvoiceFormat_Format.DisableMouseWheel = False
            Me.SearchableComboBoxNewspaperInvoiceFormat_Format.DisplayName = ""
            Me.SearchableComboBoxNewspaperInvoiceFormat_Format.EnterMoveNextControl = True
            Me.SearchableComboBoxNewspaperInvoiceFormat_Format.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxNewspaperInvoiceFormat_Format.Location = New System.Drawing.Point(60, 50)
            Me.SearchableComboBoxNewspaperInvoiceFormat_Format.Name = "SearchableComboBoxNewspaperInvoiceFormat_Format"
            Me.SearchableComboBoxNewspaperInvoiceFormat_Format.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxNewspaperInvoiceFormat_Format.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxNewspaperInvoiceFormat_Format.Properties.NullText = "Select Report"
            Me.SearchableComboBoxNewspaperInvoiceFormat_Format.Properties.PopupView = Me.GridView3
            Me.SearchableComboBoxNewspaperInvoiceFormat_Format.Properties.ShowClearButton = False
            Me.SearchableComboBoxNewspaperInvoiceFormat_Format.Properties.ValueMember = "Code"
            Me.SearchableComboBoxNewspaperInvoiceFormat_Format.SecurityEnabled = True
            Me.SearchableComboBoxNewspaperInvoiceFormat_Format.SelectedValue = Nothing
            Me.SearchableComboBoxNewspaperInvoiceFormat_Format.Size = New System.Drawing.Size(769, 20)
            Me.SearchableComboBoxNewspaperInvoiceFormat_Format.TabIndex = 4
            '
            'GridView3
            '
            Me.GridView3.AFActiveFilterString = ""
            Me.GridView3.AllowExtraItemsInGridLookupEdits = True
            Me.GridView3.AutoFilterLookupColumns = False
            Me.GridView3.AutoloadRepositoryDatasource = True
            Me.GridView3.DataSourceClearing = False
            Me.GridView3.EnableDisabledRows = False
            Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView3.Name = "GridView3"
            Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView3.OptionsView.ShowGroupPanel = False
            Me.GridView3.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView3.RunStandardValidation = True
            Me.GridView3.SkipAddingControlsOnModifyColumn = False
            Me.GridView3.SkipSettingFontOnModifyColumn = False
            '
            'GroupBoxMediaInvoiceFormat_OutOfHome
            '
            Me.GroupBoxMediaInvoiceFormat_OutOfHome.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxMediaInvoiceFormat_OutOfHome.Controls.Add(Me.LabelOutOfHomeInvoiceFormat_Note)
            Me.GroupBoxMediaInvoiceFormat_OutOfHome.Controls.Add(Me.LabelOutOfHomeInvoiceFormat_Format)
            Me.GroupBoxMediaInvoiceFormat_OutOfHome.Controls.Add(Me.SearchableComboBoxOutOfHomeInvoiceFormat_Format)
            Me.GroupBoxMediaInvoiceFormat_OutOfHome.Controls.Add(Me.LabelOutOfHomeInvoiceFormat_Type)
            Me.GroupBoxMediaInvoiceFormat_OutOfHome.Controls.Add(Me.ComboBoxOutOfHomeInvoiceFormat_Type)
            Me.GroupBoxMediaInvoiceFormat_OutOfHome.Location = New System.Drawing.Point(6, 255)
            Me.GroupBoxMediaInvoiceFormat_OutOfHome.Name = "GroupBoxMediaInvoiceFormat_OutOfHome"
            Me.GroupBoxMediaInvoiceFormat_OutOfHome.Size = New System.Drawing.Size(835, 77)
            Me.GroupBoxMediaInvoiceFormat_OutOfHome.TabIndex = 3
            Me.GroupBoxMediaInvoiceFormat_OutOfHome.Text = "Out of Home Invoice Format"
            '
            'LabelOutOfHomeInvoiceFormat_Note
            '
            Me.LabelOutOfHomeInvoiceFormat_Note.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelOutOfHomeInvoiceFormat_Note.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelOutOfHomeInvoiceFormat_Note.Location = New System.Drawing.Point(226, 25)
            Me.LabelOutOfHomeInvoiceFormat_Note.Name = "LabelOutOfHomeInvoiceFormat_Note"
            Me.LabelOutOfHomeInvoiceFormat_Note.Size = New System.Drawing.Size(530, 20)
            Me.LabelOutOfHomeInvoiceFormat_Note.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOutOfHomeInvoiceFormat_Note.TabIndex = 17
            Me.LabelOutOfHomeInvoiceFormat_Note.Text = "(Standard Format is established and configured in 'Invoice Printing')"
            '
            'LabelOutOfHomeInvoiceFormat_Format
            '
            Me.LabelOutOfHomeInvoiceFormat_Format.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelOutOfHomeInvoiceFormat_Format.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelOutOfHomeInvoiceFormat_Format.Location = New System.Drawing.Point(7, 50)
            Me.LabelOutOfHomeInvoiceFormat_Format.Name = "LabelOutOfHomeInvoiceFormat_Format"
            Me.LabelOutOfHomeInvoiceFormat_Format.Size = New System.Drawing.Size(47, 20)
            Me.LabelOutOfHomeInvoiceFormat_Format.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOutOfHomeInvoiceFormat_Format.TabIndex = 13
            Me.LabelOutOfHomeInvoiceFormat_Format.Text = "Format:"
            '
            'SearchableComboBoxOutOfHomeInvoiceFormat_Format
            '
            Me.SearchableComboBoxOutOfHomeInvoiceFormat_Format.ActiveFilterString = ""
            Me.SearchableComboBoxOutOfHomeInvoiceFormat_Format.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxOutOfHomeInvoiceFormat_Format.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxOutOfHomeInvoiceFormat_Format.AutoFillMode = False
            Me.SearchableComboBoxOutOfHomeInvoiceFormat_Format.BookmarkingEnabled = False
            Me.SearchableComboBoxOutOfHomeInvoiceFormat_Format.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.CustomReport
            Me.SearchableComboBoxOutOfHomeInvoiceFormat_Format.DataSource = Nothing
            Me.SearchableComboBoxOutOfHomeInvoiceFormat_Format.DisableMouseWheel = False
            Me.SearchableComboBoxOutOfHomeInvoiceFormat_Format.DisplayName = ""
            Me.SearchableComboBoxOutOfHomeInvoiceFormat_Format.EnterMoveNextControl = True
            Me.SearchableComboBoxOutOfHomeInvoiceFormat_Format.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxOutOfHomeInvoiceFormat_Format.Location = New System.Drawing.Point(60, 50)
            Me.SearchableComboBoxOutOfHomeInvoiceFormat_Format.Name = "SearchableComboBoxOutOfHomeInvoiceFormat_Format"
            Me.SearchableComboBoxOutOfHomeInvoiceFormat_Format.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxOutOfHomeInvoiceFormat_Format.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxOutOfHomeInvoiceFormat_Format.Properties.NullText = "Select Report"
            Me.SearchableComboBoxOutOfHomeInvoiceFormat_Format.Properties.PopupView = Me.GridView5
            Me.SearchableComboBoxOutOfHomeInvoiceFormat_Format.Properties.ShowClearButton = False
            Me.SearchableComboBoxOutOfHomeInvoiceFormat_Format.Properties.ValueMember = "Code"
            Me.SearchableComboBoxOutOfHomeInvoiceFormat_Format.SecurityEnabled = True
            Me.SearchableComboBoxOutOfHomeInvoiceFormat_Format.SelectedValue = Nothing
            Me.SearchableComboBoxOutOfHomeInvoiceFormat_Format.Size = New System.Drawing.Size(769, 20)
            Me.SearchableComboBoxOutOfHomeInvoiceFormat_Format.TabIndex = 4
            '
            'GridView5
            '
            Me.GridView5.AFActiveFilterString = ""
            Me.GridView5.AllowExtraItemsInGridLookupEdits = True
            Me.GridView5.AutoFilterLookupColumns = False
            Me.GridView5.AutoloadRepositoryDatasource = True
            Me.GridView5.DataSourceClearing = False
            Me.GridView5.EnableDisabledRows = False
            Me.GridView5.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView5.Name = "GridView5"
            Me.GridView5.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView5.OptionsView.ShowGroupPanel = False
            Me.GridView5.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView5.RunStandardValidation = True
            Me.GridView5.SkipAddingControlsOnModifyColumn = False
            Me.GridView5.SkipSettingFontOnModifyColumn = False
            '
            'LabelOutOfHomeInvoiceFormat_Type
            '
            Me.LabelOutOfHomeInvoiceFormat_Type.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelOutOfHomeInvoiceFormat_Type.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelOutOfHomeInvoiceFormat_Type.Location = New System.Drawing.Point(6, 25)
            Me.LabelOutOfHomeInvoiceFormat_Type.Name = "LabelOutOfHomeInvoiceFormat_Type"
            Me.LabelOutOfHomeInvoiceFormat_Type.Size = New System.Drawing.Size(47, 20)
            Me.LabelOutOfHomeInvoiceFormat_Type.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOutOfHomeInvoiceFormat_Type.TabIndex = 11
            Me.LabelOutOfHomeInvoiceFormat_Type.Text = "Type:"
            '
            'ComboBoxOutOfHomeInvoiceFormat_Type
            '
            Me.ComboBoxOutOfHomeInvoiceFormat_Type.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxOutOfHomeInvoiceFormat_Type.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxOutOfHomeInvoiceFormat_Type.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxOutOfHomeInvoiceFormat_Type.AutoFindItemInDataSource = False
            Me.ComboBoxOutOfHomeInvoiceFormat_Type.AutoSelectSingleItemDatasource = False
            Me.ComboBoxOutOfHomeInvoiceFormat_Type.BookmarkingEnabled = False
            Me.ComboBoxOutOfHomeInvoiceFormat_Type.ClientCode = ""
            Me.ComboBoxOutOfHomeInvoiceFormat_Type.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.InvoiceFormat
            Me.ComboBoxOutOfHomeInvoiceFormat_Type.DisableMouseWheel = False
            Me.ComboBoxOutOfHomeInvoiceFormat_Type.DisplayMember = "Description"
            Me.ComboBoxOutOfHomeInvoiceFormat_Type.DisplayName = ""
            Me.ComboBoxOutOfHomeInvoiceFormat_Type.DivisionCode = ""
            Me.ComboBoxOutOfHomeInvoiceFormat_Type.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxOutOfHomeInvoiceFormat_Type.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxOutOfHomeInvoiceFormat_Type.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxOutOfHomeInvoiceFormat_Type.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxOutOfHomeInvoiceFormat_Type.FocusHighlightEnabled = True
            Me.ComboBoxOutOfHomeInvoiceFormat_Type.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxOutOfHomeInvoiceFormat_Type.FormattingEnabled = True
            Me.ComboBoxOutOfHomeInvoiceFormat_Type.ItemHeight = 16
            Me.ComboBoxOutOfHomeInvoiceFormat_Type.Location = New System.Drawing.Point(60, 25)
            Me.ComboBoxOutOfHomeInvoiceFormat_Type.Name = "ComboBoxOutOfHomeInvoiceFormat_Type"
            Me.ComboBoxOutOfHomeInvoiceFormat_Type.ReadOnly = False
            Me.ComboBoxOutOfHomeInvoiceFormat_Type.SecurityEnabled = True
            Me.ComboBoxOutOfHomeInvoiceFormat_Type.Size = New System.Drawing.Size(160, 22)
            Me.ComboBoxOutOfHomeInvoiceFormat_Type.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxOutOfHomeInvoiceFormat_Type.TabIndex = 1
            Me.ComboBoxOutOfHomeInvoiceFormat_Type.TabOnEnter = True
            Me.ComboBoxOutOfHomeInvoiceFormat_Type.ValueMember = "Code"
            Me.ComboBoxOutOfHomeInvoiceFormat_Type.WatermarkText = "Select Invoice Format"
            '
            'GroupBoxMediaInvoiceFormat_Magazine
            '
            Me.GroupBoxMediaInvoiceFormat_Magazine.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxMediaInvoiceFormat_Magazine.Controls.Add(Me.LabelMagazineInvoiceFormat_Note)
            Me.GroupBoxMediaInvoiceFormat_Magazine.Controls.Add(Me.LabelMagazineInvoiceFormat_Format)
            Me.GroupBoxMediaInvoiceFormat_Magazine.Controls.Add(Me.LabelMagazineInvoiceFormat_Type)
            Me.GroupBoxMediaInvoiceFormat_Magazine.Controls.Add(Me.ComboBoxMagazineInvoiceFormat_Type)
            Me.GroupBoxMediaInvoiceFormat_Magazine.Controls.Add(Me.SearchableComboBoxMagazineInvoiceFormat_Format)
            Me.GroupBoxMediaInvoiceFormat_Magazine.Location = New System.Drawing.Point(6, 6)
            Me.GroupBoxMediaInvoiceFormat_Magazine.Name = "GroupBoxMediaInvoiceFormat_Magazine"
            Me.GroupBoxMediaInvoiceFormat_Magazine.Size = New System.Drawing.Size(835, 77)
            Me.GroupBoxMediaInvoiceFormat_Magazine.TabIndex = 0
            Me.GroupBoxMediaInvoiceFormat_Magazine.Text = "Magazine Invoice Format"
            '
            'LabelMagazineInvoiceFormat_Note
            '
            Me.LabelMagazineInvoiceFormat_Note.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMagazineInvoiceFormat_Note.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMagazineInvoiceFormat_Note.Location = New System.Drawing.Point(226, 25)
            Me.LabelMagazineInvoiceFormat_Note.Name = "LabelMagazineInvoiceFormat_Note"
            Me.LabelMagazineInvoiceFormat_Note.Size = New System.Drawing.Size(530, 20)
            Me.LabelMagazineInvoiceFormat_Note.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMagazineInvoiceFormat_Note.TabIndex = 16
            Me.LabelMagazineInvoiceFormat_Note.Text = "(Standard Format is established and configured in 'Invoice Printing')"
            '
            'LabelMagazineInvoiceFormat_Format
            '
            Me.LabelMagazineInvoiceFormat_Format.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMagazineInvoiceFormat_Format.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMagazineInvoiceFormat_Format.Location = New System.Drawing.Point(7, 50)
            Me.LabelMagazineInvoiceFormat_Format.Name = "LabelMagazineInvoiceFormat_Format"
            Me.LabelMagazineInvoiceFormat_Format.Size = New System.Drawing.Size(47, 20)
            Me.LabelMagazineInvoiceFormat_Format.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMagazineInvoiceFormat_Format.TabIndex = 8
            Me.LabelMagazineInvoiceFormat_Format.Text = "Format:"
            '
            'LabelMagazineInvoiceFormat_Type
            '
            Me.LabelMagazineInvoiceFormat_Type.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMagazineInvoiceFormat_Type.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMagazineInvoiceFormat_Type.Location = New System.Drawing.Point(6, 25)
            Me.LabelMagazineInvoiceFormat_Type.Name = "LabelMagazineInvoiceFormat_Type"
            Me.LabelMagazineInvoiceFormat_Type.Size = New System.Drawing.Size(47, 20)
            Me.LabelMagazineInvoiceFormat_Type.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMagazineInvoiceFormat_Type.TabIndex = 6
            Me.LabelMagazineInvoiceFormat_Type.Text = "Type:"
            '
            'ComboBoxMagazineInvoiceFormat_Type
            '
            Me.ComboBoxMagazineInvoiceFormat_Type.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxMagazineInvoiceFormat_Type.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxMagazineInvoiceFormat_Type.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxMagazineInvoiceFormat_Type.AutoFindItemInDataSource = False
            Me.ComboBoxMagazineInvoiceFormat_Type.AutoSelectSingleItemDatasource = False
            Me.ComboBoxMagazineInvoiceFormat_Type.BookmarkingEnabled = False
            Me.ComboBoxMagazineInvoiceFormat_Type.ClientCode = ""
            Me.ComboBoxMagazineInvoiceFormat_Type.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.InvoiceFormat
            Me.ComboBoxMagazineInvoiceFormat_Type.DisableMouseWheel = False
            Me.ComboBoxMagazineInvoiceFormat_Type.DisplayMember = "Description"
            Me.ComboBoxMagazineInvoiceFormat_Type.DisplayName = ""
            Me.ComboBoxMagazineInvoiceFormat_Type.DivisionCode = ""
            Me.ComboBoxMagazineInvoiceFormat_Type.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxMagazineInvoiceFormat_Type.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxMagazineInvoiceFormat_Type.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxMagazineInvoiceFormat_Type.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxMagazineInvoiceFormat_Type.FocusHighlightEnabled = True
            Me.ComboBoxMagazineInvoiceFormat_Type.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxMagazineInvoiceFormat_Type.FormattingEnabled = True
            Me.ComboBoxMagazineInvoiceFormat_Type.ItemHeight = 16
            Me.ComboBoxMagazineInvoiceFormat_Type.Location = New System.Drawing.Point(60, 25)
            Me.ComboBoxMagazineInvoiceFormat_Type.Name = "ComboBoxMagazineInvoiceFormat_Type"
            Me.ComboBoxMagazineInvoiceFormat_Type.ReadOnly = False
            Me.ComboBoxMagazineInvoiceFormat_Type.SecurityEnabled = True
            Me.ComboBoxMagazineInvoiceFormat_Type.Size = New System.Drawing.Size(160, 22)
            Me.ComboBoxMagazineInvoiceFormat_Type.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxMagazineInvoiceFormat_Type.TabIndex = 1
            Me.ComboBoxMagazineInvoiceFormat_Type.TabOnEnter = True
            Me.ComboBoxMagazineInvoiceFormat_Type.ValueMember = "Code"
            Me.ComboBoxMagazineInvoiceFormat_Type.WatermarkText = "Select Invoice Format"
            '
            'SearchableComboBoxMagazineInvoiceFormat_Format
            '
            Me.SearchableComboBoxMagazineInvoiceFormat_Format.ActiveFilterString = ""
            Me.SearchableComboBoxMagazineInvoiceFormat_Format.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxMagazineInvoiceFormat_Format.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxMagazineInvoiceFormat_Format.AutoFillMode = False
            Me.SearchableComboBoxMagazineInvoiceFormat_Format.BookmarkingEnabled = False
            Me.SearchableComboBoxMagazineInvoiceFormat_Format.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.CustomReport
            Me.SearchableComboBoxMagazineInvoiceFormat_Format.DataSource = Nothing
            Me.SearchableComboBoxMagazineInvoiceFormat_Format.DisableMouseWheel = False
            Me.SearchableComboBoxMagazineInvoiceFormat_Format.DisplayName = ""
            Me.SearchableComboBoxMagazineInvoiceFormat_Format.EnterMoveNextControl = True
            Me.SearchableComboBoxMagazineInvoiceFormat_Format.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxMagazineInvoiceFormat_Format.Location = New System.Drawing.Point(60, 50)
            Me.SearchableComboBoxMagazineInvoiceFormat_Format.Name = "SearchableComboBoxMagazineInvoiceFormat_Format"
            Me.SearchableComboBoxMagazineInvoiceFormat_Format.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxMagazineInvoiceFormat_Format.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxMagazineInvoiceFormat_Format.Properties.NullText = "Select Report"
            Me.SearchableComboBoxMagazineInvoiceFormat_Format.Properties.PopupView = Me.GridView2
            Me.SearchableComboBoxMagazineInvoiceFormat_Format.Properties.ShowClearButton = False
            Me.SearchableComboBoxMagazineInvoiceFormat_Format.Properties.ValueMember = "Code"
            Me.SearchableComboBoxMagazineInvoiceFormat_Format.SecurityEnabled = True
            Me.SearchableComboBoxMagazineInvoiceFormat_Format.SelectedValue = Nothing
            Me.SearchableComboBoxMagazineInvoiceFormat_Format.Size = New System.Drawing.Size(769, 20)
            Me.SearchableComboBoxMagazineInvoiceFormat_Format.TabIndex = 3
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
            Me.GridView2.SkipAddingControlsOnModifyColumn = False
            Me.GridView2.SkipSettingFontOnModifyColumn = False
            '
            'GroupBoxMediaInvoiceFormat_Internet
            '
            Me.GroupBoxMediaInvoiceFormat_Internet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxMediaInvoiceFormat_Internet.Controls.Add(Me.LabelInternetInvoiceFormat_Note)
            Me.GroupBoxMediaInvoiceFormat_Internet.Controls.Add(Me.LabelInternetInvoiceFormat_Format)
            Me.GroupBoxMediaInvoiceFormat_Internet.Controls.Add(Me.LabelInternetInvoiceFormat_Type)
            Me.GroupBoxMediaInvoiceFormat_Internet.Controls.Add(Me.SearchableComboBoxInternetInvoiceFormat_Format)
            Me.GroupBoxMediaInvoiceFormat_Internet.Controls.Add(Me.ComboBoxInternetInvoiceFormat_Type)
            Me.GroupBoxMediaInvoiceFormat_Internet.Location = New System.Drawing.Point(6, 172)
            Me.GroupBoxMediaInvoiceFormat_Internet.Name = "GroupBoxMediaInvoiceFormat_Internet"
            Me.GroupBoxMediaInvoiceFormat_Internet.Size = New System.Drawing.Size(835, 77)
            Me.GroupBoxMediaInvoiceFormat_Internet.TabIndex = 2
            Me.GroupBoxMediaInvoiceFormat_Internet.Text = "Internet Invoice Format"
            '
            'LabelInternetInvoiceFormat_Note
            '
            Me.LabelInternetInvoiceFormat_Note.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelInternetInvoiceFormat_Note.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelInternetInvoiceFormat_Note.Location = New System.Drawing.Point(226, 25)
            Me.LabelInternetInvoiceFormat_Note.Name = "LabelInternetInvoiceFormat_Note"
            Me.LabelInternetInvoiceFormat_Note.Size = New System.Drawing.Size(530, 20)
            Me.LabelInternetInvoiceFormat_Note.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelInternetInvoiceFormat_Note.TabIndex = 18
            Me.LabelInternetInvoiceFormat_Note.Text = "(Standard Format is established and configured in 'Invoice Printing')"
            '
            'LabelInternetInvoiceFormat_Format
            '
            Me.LabelInternetInvoiceFormat_Format.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelInternetInvoiceFormat_Format.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelInternetInvoiceFormat_Format.Location = New System.Drawing.Point(7, 50)
            Me.LabelInternetInvoiceFormat_Format.Name = "LabelInternetInvoiceFormat_Format"
            Me.LabelInternetInvoiceFormat_Format.Size = New System.Drawing.Size(47, 20)
            Me.LabelInternetInvoiceFormat_Format.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelInternetInvoiceFormat_Format.TabIndex = 18
            Me.LabelInternetInvoiceFormat_Format.Text = "Format:"
            '
            'LabelInternetInvoiceFormat_Type
            '
            Me.LabelInternetInvoiceFormat_Type.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelInternetInvoiceFormat_Type.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelInternetInvoiceFormat_Type.Location = New System.Drawing.Point(6, 25)
            Me.LabelInternetInvoiceFormat_Type.Name = "LabelInternetInvoiceFormat_Type"
            Me.LabelInternetInvoiceFormat_Type.Size = New System.Drawing.Size(47, 20)
            Me.LabelInternetInvoiceFormat_Type.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelInternetInvoiceFormat_Type.TabIndex = 16
            Me.LabelInternetInvoiceFormat_Type.Text = "Type:"
            '
            'SearchableComboBoxInternetInvoiceFormat_Format
            '
            Me.SearchableComboBoxInternetInvoiceFormat_Format.ActiveFilterString = ""
            Me.SearchableComboBoxInternetInvoiceFormat_Format.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxInternetInvoiceFormat_Format.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxInternetInvoiceFormat_Format.AutoFillMode = False
            Me.SearchableComboBoxInternetInvoiceFormat_Format.BookmarkingEnabled = False
            Me.SearchableComboBoxInternetInvoiceFormat_Format.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.CustomReport
            Me.SearchableComboBoxInternetInvoiceFormat_Format.DataSource = Nothing
            Me.SearchableComboBoxInternetInvoiceFormat_Format.DisableMouseWheel = False
            Me.SearchableComboBoxInternetInvoiceFormat_Format.DisplayName = ""
            Me.SearchableComboBoxInternetInvoiceFormat_Format.EnterMoveNextControl = True
            Me.SearchableComboBoxInternetInvoiceFormat_Format.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxInternetInvoiceFormat_Format.Location = New System.Drawing.Point(60, 50)
            Me.SearchableComboBoxInternetInvoiceFormat_Format.Name = "SearchableComboBoxInternetInvoiceFormat_Format"
            Me.SearchableComboBoxInternetInvoiceFormat_Format.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxInternetInvoiceFormat_Format.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxInternetInvoiceFormat_Format.Properties.NullText = "Select Report"
            Me.SearchableComboBoxInternetInvoiceFormat_Format.Properties.PopupView = Me.GridView4
            Me.SearchableComboBoxInternetInvoiceFormat_Format.Properties.ShowClearButton = False
            Me.SearchableComboBoxInternetInvoiceFormat_Format.Properties.ValueMember = "Code"
            Me.SearchableComboBoxInternetInvoiceFormat_Format.SecurityEnabled = True
            Me.SearchableComboBoxInternetInvoiceFormat_Format.SelectedValue = Nothing
            Me.SearchableComboBoxInternetInvoiceFormat_Format.Size = New System.Drawing.Size(769, 20)
            Me.SearchableComboBoxInternetInvoiceFormat_Format.TabIndex = 4
            '
            'GridView4
            '
            Me.GridView4.AFActiveFilterString = ""
            Me.GridView4.AllowExtraItemsInGridLookupEdits = True
            Me.GridView4.AutoFilterLookupColumns = False
            Me.GridView4.AutoloadRepositoryDatasource = True
            Me.GridView4.DataSourceClearing = False
            Me.GridView4.EnableDisabledRows = False
            Me.GridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView4.Name = "GridView4"
            Me.GridView4.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView4.OptionsView.ShowGroupPanel = False
            Me.GridView4.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView4.RunStandardValidation = True
            Me.GridView4.SkipAddingControlsOnModifyColumn = False
            Me.GridView4.SkipSettingFontOnModifyColumn = False
            '
            'ComboBoxInternetInvoiceFormat_Type
            '
            Me.ComboBoxInternetInvoiceFormat_Type.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxInternetInvoiceFormat_Type.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxInternetInvoiceFormat_Type.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxInternetInvoiceFormat_Type.AutoFindItemInDataSource = False
            Me.ComboBoxInternetInvoiceFormat_Type.AutoSelectSingleItemDatasource = False
            Me.ComboBoxInternetInvoiceFormat_Type.BookmarkingEnabled = False
            Me.ComboBoxInternetInvoiceFormat_Type.ClientCode = ""
            Me.ComboBoxInternetInvoiceFormat_Type.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.InvoiceFormat
            Me.ComboBoxInternetInvoiceFormat_Type.DisableMouseWheel = False
            Me.ComboBoxInternetInvoiceFormat_Type.DisplayMember = "Description"
            Me.ComboBoxInternetInvoiceFormat_Type.DisplayName = ""
            Me.ComboBoxInternetInvoiceFormat_Type.DivisionCode = ""
            Me.ComboBoxInternetInvoiceFormat_Type.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxInternetInvoiceFormat_Type.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxInternetInvoiceFormat_Type.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxInternetInvoiceFormat_Type.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxInternetInvoiceFormat_Type.FocusHighlightEnabled = True
            Me.ComboBoxInternetInvoiceFormat_Type.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxInternetInvoiceFormat_Type.FormattingEnabled = True
            Me.ComboBoxInternetInvoiceFormat_Type.ItemHeight = 16
            Me.ComboBoxInternetInvoiceFormat_Type.Location = New System.Drawing.Point(60, 25)
            Me.ComboBoxInternetInvoiceFormat_Type.Name = "ComboBoxInternetInvoiceFormat_Type"
            Me.ComboBoxInternetInvoiceFormat_Type.ReadOnly = False
            Me.ComboBoxInternetInvoiceFormat_Type.SecurityEnabled = True
            Me.ComboBoxInternetInvoiceFormat_Type.Size = New System.Drawing.Size(160, 22)
            Me.ComboBoxInternetInvoiceFormat_Type.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxInternetInvoiceFormat_Type.TabIndex = 1
            Me.ComboBoxInternetInvoiceFormat_Type.TabOnEnter = True
            Me.ComboBoxInternetInvoiceFormat_Type.ValueMember = "Code"
            Me.ComboBoxInternetInvoiceFormat_Type.WatermarkText = "Select Invoice Format"
            '
            'GroupBoxMediaInvoiceFormat_TV
            '
            Me.GroupBoxMediaInvoiceFormat_TV.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxMediaInvoiceFormat_TV.Controls.Add(Me.SearchableComboBoxTVInvoiceFormat_Format)
            Me.GroupBoxMediaInvoiceFormat_TV.Controls.Add(Me.LabelTelevsionInvoiceFormat_Note)
            Me.GroupBoxMediaInvoiceFormat_TV.Controls.Add(Me.LabelTelevisionInvoiceFormat_Format)
            Me.GroupBoxMediaInvoiceFormat_TV.Controls.Add(Me.LabelTelevisionInvoiceFormat_Type)
            Me.GroupBoxMediaInvoiceFormat_TV.Controls.Add(Me.ComboBoxTVInvoiceFormat_Type)
            Me.GroupBoxMediaInvoiceFormat_TV.Location = New System.Drawing.Point(6, 421)
            Me.GroupBoxMediaInvoiceFormat_TV.Name = "GroupBoxMediaInvoiceFormat_TV"
            Me.GroupBoxMediaInvoiceFormat_TV.Size = New System.Drawing.Size(835, 77)
            Me.GroupBoxMediaInvoiceFormat_TV.TabIndex = 5
            Me.GroupBoxMediaInvoiceFormat_TV.Text = "Television Invoice Format"
            '
            'SearchableComboBoxTVInvoiceFormat_Format
            '
            Me.SearchableComboBoxTVInvoiceFormat_Format.ActiveFilterString = ""
            Me.SearchableComboBoxTVInvoiceFormat_Format.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxTVInvoiceFormat_Format.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxTVInvoiceFormat_Format.AutoFillMode = False
            Me.SearchableComboBoxTVInvoiceFormat_Format.BookmarkingEnabled = False
            Me.SearchableComboBoxTVInvoiceFormat_Format.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.CustomReport
            Me.SearchableComboBoxTVInvoiceFormat_Format.DataSource = Nothing
            Me.SearchableComboBoxTVInvoiceFormat_Format.DisableMouseWheel = False
            Me.SearchableComboBoxTVInvoiceFormat_Format.DisplayName = ""
            Me.SearchableComboBoxTVInvoiceFormat_Format.EnterMoveNextControl = True
            Me.SearchableComboBoxTVInvoiceFormat_Format.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxTVInvoiceFormat_Format.Location = New System.Drawing.Point(60, 50)
            Me.SearchableComboBoxTVInvoiceFormat_Format.Name = "SearchableComboBoxTVInvoiceFormat_Format"
            Me.SearchableComboBoxTVInvoiceFormat_Format.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxTVInvoiceFormat_Format.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxTVInvoiceFormat_Format.Properties.NullText = "Select Report"
            Me.SearchableComboBoxTVInvoiceFormat_Format.Properties.PopupView = Me.GridView7
            Me.SearchableComboBoxTVInvoiceFormat_Format.Properties.ShowClearButton = False
            Me.SearchableComboBoxTVInvoiceFormat_Format.Properties.ValueMember = "Code"
            Me.SearchableComboBoxTVInvoiceFormat_Format.SecurityEnabled = True
            Me.SearchableComboBoxTVInvoiceFormat_Format.SelectedValue = Nothing
            Me.SearchableComboBoxTVInvoiceFormat_Format.Size = New System.Drawing.Size(768, 20)
            Me.SearchableComboBoxTVInvoiceFormat_Format.TabIndex = 4
            '
            'GridView7
            '
            Me.GridView7.AFActiveFilterString = ""
            Me.GridView7.AllowExtraItemsInGridLookupEdits = True
            Me.GridView7.AutoFilterLookupColumns = False
            Me.GridView7.AutoloadRepositoryDatasource = True
            Me.GridView7.DataSourceClearing = False
            Me.GridView7.EnableDisabledRows = False
            Me.GridView7.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView7.Name = "GridView7"
            Me.GridView7.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView7.OptionsView.ShowGroupPanel = False
            Me.GridView7.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView7.RunStandardValidation = True
            Me.GridView7.SkipAddingControlsOnModifyColumn = False
            Me.GridView7.SkipSettingFontOnModifyColumn = False
            '
            'LabelTelevsionInvoiceFormat_Note
            '
            Me.LabelTelevsionInvoiceFormat_Note.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTelevsionInvoiceFormat_Note.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTelevsionInvoiceFormat_Note.Location = New System.Drawing.Point(226, 25)
            Me.LabelTelevsionInvoiceFormat_Note.Name = "LabelTelevsionInvoiceFormat_Note"
            Me.LabelTelevsionInvoiceFormat_Note.Size = New System.Drawing.Size(530, 20)
            Me.LabelTelevsionInvoiceFormat_Note.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTelevsionInvoiceFormat_Note.TabIndex = 26
            Me.LabelTelevsionInvoiceFormat_Note.Text = "(Standard Format is established and configured in 'Invoice Printing')"
            '
            'LabelTelevisionInvoiceFormat_Format
            '
            Me.LabelTelevisionInvoiceFormat_Format.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTelevisionInvoiceFormat_Format.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTelevisionInvoiceFormat_Format.Location = New System.Drawing.Point(7, 50)
            Me.LabelTelevisionInvoiceFormat_Format.Name = "LabelTelevisionInvoiceFormat_Format"
            Me.LabelTelevisionInvoiceFormat_Format.Size = New System.Drawing.Size(47, 20)
            Me.LabelTelevisionInvoiceFormat_Format.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTelevisionInvoiceFormat_Format.TabIndex = 28
            Me.LabelTelevisionInvoiceFormat_Format.Text = "Format:"
            '
            'LabelTelevisionInvoiceFormat_Type
            '
            Me.LabelTelevisionInvoiceFormat_Type.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTelevisionInvoiceFormat_Type.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTelevisionInvoiceFormat_Type.Location = New System.Drawing.Point(6, 25)
            Me.LabelTelevisionInvoiceFormat_Type.Name = "LabelTelevisionInvoiceFormat_Type"
            Me.LabelTelevisionInvoiceFormat_Type.Size = New System.Drawing.Size(47, 20)
            Me.LabelTelevisionInvoiceFormat_Type.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTelevisionInvoiceFormat_Type.TabIndex = 26
            Me.LabelTelevisionInvoiceFormat_Type.Text = "Type:"
            '
            'ComboBoxTVInvoiceFormat_Type
            '
            Me.ComboBoxTVInvoiceFormat_Type.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxTVInvoiceFormat_Type.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxTVInvoiceFormat_Type.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxTVInvoiceFormat_Type.AutoFindItemInDataSource = False
            Me.ComboBoxTVInvoiceFormat_Type.AutoSelectSingleItemDatasource = False
            Me.ComboBoxTVInvoiceFormat_Type.BookmarkingEnabled = False
            Me.ComboBoxTVInvoiceFormat_Type.ClientCode = ""
            Me.ComboBoxTVInvoiceFormat_Type.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.InvoiceFormat
            Me.ComboBoxTVInvoiceFormat_Type.DisableMouseWheel = False
            Me.ComboBoxTVInvoiceFormat_Type.DisplayMember = "Description"
            Me.ComboBoxTVInvoiceFormat_Type.DisplayName = ""
            Me.ComboBoxTVInvoiceFormat_Type.DivisionCode = ""
            Me.ComboBoxTVInvoiceFormat_Type.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxTVInvoiceFormat_Type.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxTVInvoiceFormat_Type.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxTVInvoiceFormat_Type.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxTVInvoiceFormat_Type.FocusHighlightEnabled = True
            Me.ComboBoxTVInvoiceFormat_Type.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxTVInvoiceFormat_Type.FormattingEnabled = True
            Me.ComboBoxTVInvoiceFormat_Type.ItemHeight = 16
            Me.ComboBoxTVInvoiceFormat_Type.Location = New System.Drawing.Point(60, 25)
            Me.ComboBoxTVInvoiceFormat_Type.Name = "ComboBoxTVInvoiceFormat_Type"
            Me.ComboBoxTVInvoiceFormat_Type.ReadOnly = False
            Me.ComboBoxTVInvoiceFormat_Type.SecurityEnabled = True
            Me.ComboBoxTVInvoiceFormat_Type.Size = New System.Drawing.Size(160, 22)
            Me.ComboBoxTVInvoiceFormat_Type.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxTVInvoiceFormat_Type.TabIndex = 1
            Me.ComboBoxTVInvoiceFormat_Type.TabOnEnter = True
            Me.ComboBoxTVInvoiceFormat_Type.ValueMember = "Code"
            Me.ComboBoxTVInvoiceFormat_Type.WatermarkText = "Select Invoice Format"
            '
            'TabItemClientDetails_MediaInvoiceFormatTab
            '
            Me.TabItemClientDetails_MediaInvoiceFormatTab.AttachedControl = Me.TabControlPanelClientDetails_MediaInvoiceFormat
            Me.TabItemClientDetails_MediaInvoiceFormatTab.Name = "TabItemClientDetails_MediaInvoiceFormatTab"
            Me.TabItemClientDetails_MediaInvoiceFormatTab.Text = "Media Invoice Format"
            '
            'TabControlPanelContractTab_Contracts
            '
            Me.TabControlPanelContractTab_Contracts.Controls.Add(Me.ContractManagerControlContractTab_Contracts)
            Me.TabControlPanelContractTab_Contracts.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelContractTab_Contracts.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelContractTab_Contracts.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelContractTab_Contracts.Name = "TabControlPanelContractTab_Contracts"
            Me.TabControlPanelContractTab_Contracts.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelContractTab_Contracts.Size = New System.Drawing.Size(845, 505)
            Me.TabControlPanelContractTab_Contracts.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelContractTab_Contracts.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelContractTab_Contracts.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelContractTab_Contracts.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelContractTab_Contracts.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelContractTab_Contracts.Style.GradientAngle = 90
            Me.TabControlPanelContractTab_Contracts.TabIndex = 9
            Me.TabControlPanelContractTab_Contracts.TabItem = Me.TabItemClientDetails_ContractsTab
            '
            'ContractManagerControlContractTab_Contracts
            '
            Me.ContractManagerControlContractTab_Contracts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ContractManagerControlContractTab_Contracts.Location = New System.Drawing.Point(6, 6)
            Me.ContractManagerControlContractTab_Contracts.Name = "ContractManagerControlContractTab_Contracts"
            Me.ContractManagerControlContractTab_Contracts.Size = New System.Drawing.Size(833, 494)
            Me.ContractManagerControlContractTab_Contracts.TabIndex = 0
            '
            'TabItemClientDetails_ContractsTab
            '
            Me.TabItemClientDetails_ContractsTab.AttachedControl = Me.TabControlPanelContractTab_Contracts
            Me.TabItemClientDetails_ContractsTab.Name = "TabItemClientDetails_ContractsTab"
            Me.TabItemClientDetails_ContractsTab.Text = "Contracts / Opportunities"
            Me.TabItemClientDetails_ContractsTab.Visible = False
            '
            'TabControlPanelDocumentsTab_Documents
            '
            Me.TabControlPanelDocumentsTab_Documents.Controls.Add(Me.DocumentManagerControlDocuments_ClientDocuments)
            Me.TabControlPanelDocumentsTab_Documents.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelDocumentsTab_Documents.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelDocumentsTab_Documents.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelDocumentsTab_Documents.Name = "TabControlPanelDocumentsTab_Documents"
            Me.TabControlPanelDocumentsTab_Documents.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelDocumentsTab_Documents.Size = New System.Drawing.Size(845, 505)
            Me.TabControlPanelDocumentsTab_Documents.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelDocumentsTab_Documents.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDocumentsTab_Documents.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelDocumentsTab_Documents.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelDocumentsTab_Documents.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelDocumentsTab_Documents.Style.GradientAngle = 90
            Me.TabControlPanelDocumentsTab_Documents.TabIndex = 7
            Me.TabControlPanelDocumentsTab_Documents.TabItem = Me.TabItemClientDetails_DocumentsTab
            '
            'DocumentManagerControlDocuments_ClientDocuments
            '
            Me.DocumentManagerControlDocuments_ClientDocuments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DocumentManagerControlDocuments_ClientDocuments.Location = New System.Drawing.Point(6, 6)
            Me.DocumentManagerControlDocuments_ClientDocuments.Name = "DocumentManagerControlDocuments_ClientDocuments"
            Me.DocumentManagerControlDocuments_ClientDocuments.Size = New System.Drawing.Size(833, 494)
            Me.DocumentManagerControlDocuments_ClientDocuments.TabIndex = 0
            '
            'TabItemClientDetails_DocumentsTab
            '
            Me.TabItemClientDetails_DocumentsTab.AttachedControl = Me.TabControlPanelDocumentsTab_Documents
            Me.TabItemClientDetails_DocumentsTab.Name = "TabItemClientDetails_DocumentsTab"
            Me.TabItemClientDetails_DocumentsTab.Text = "Documents"
            '
            'ClientControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.TabControlControl_ClientDetails)
            Me.Name = "ClientControl"
            Me.Size = New System.Drawing.Size(845, 532)
            CType(Me.TabControlControl_ClientDetails, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlControl_ClientDetails.ResumeLayout(False)
            Me.TabControlPanelGeneralTab_General.ResumeLayout(False)
            CType(Me.SearchableComboBoxGeneral_QuickBooksCustomer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView11, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TableLayoutPanelGeneral_General.ResumeLayout(False)
            Me.PanelGeneral_TopLeftColumn.ResumeLayout(False)
            CType(Me.GroupBoxLeftColumn_NewClientOptions, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxLeftColumn_NewClientOptions.ResumeLayout(False)
            CType(Me.SearchableComboBoxNewClientOptions_Office.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBox1View, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelGeneral_TopRightColumn.ResumeLayout(False)
            Me.TabControlPanelMediaIntegrationsSettingsTab_Settings.ResumeLayout(False)
            CType(Me.NumericInputDoubleClick_ReportID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputDoubleClick_ProfileID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelProductionTab_Production.ResumeLayout(False)
            CType(Me.SearchableComboBoxProduction_ClientDiscount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView8, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxProduction_ProductionEstimateFormat, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxProduction_ProductionEstimateFormat.ResumeLayout(False)
            CType(Me.NumericInputProduction_DaysToPay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxProduction_ProductionInvoiceFormat, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxProduction_ProductionInvoiceFormat.ResumeLayout(False)
            CType(Me.SearchableComboBoxProductionInvoiceFormat_Format.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxProduction_AssignProductionInvoicesBy, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxProduction_AssignProductionInvoicesBy.ResumeLayout(False)
            Me.TabControlPanelMediaTab_Media.ResumeLayout(False)
            CType(Me.NumericInputMedia_DaysToPay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxMedia_AssignMediaInvoicesBy, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxMedia_AssignMediaInvoicesBy.ResumeLayout(False)
            Me.TabControlPanelDivisionTab_Division.ResumeLayout(False)
            CType(Me.PanelDivision_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelDivision_RightSection.ResumeLayout(False)
            CType(Me.PanelDivision_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelDivision_LeftSection.ResumeLayout(False)
            Me.TabControlPanelAutomatedAssignmentsTab_AutomatedAssignments.ResumeLayout(False)
            CType(Me.SearchableComboBoxAutomatedAssignments_Job.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView10, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxAutomatedAssignments_JobComponent.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView9, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelBillingTab_Billing.ResumeLayout(False)
            CType(Me.GroupBoxBilling_LatePaymentFee, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxBilling_LatePaymentFee.ResumeLayout(False)
            CType(Me.NumericInputLatePaymentFee_Percentage.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxBilling_ARComment, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxBilling_ARComment.ResumeLayout(False)
            CType(Me.GroupBoxBilling_AssignComboInvoicesBy, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxBilling_AssignComboInvoicesBy.ResumeLayout(False)
            CType(Me.GroupBoxBilling_Avalara, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxBilling_Avalara.ResumeLayout(False)
            CType(Me.SearchableComboBoxAvalara_SalesClassCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboboxViewAvalara_SalesClass, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxBilling_Options, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxBilling_Options.ResumeLayout(False)
            CType(Me.DateTimePickerOptions_ContractExpirationDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputOptions_CreditLimit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TableLayoutPanelBilling_AddressLayout.ResumeLayout(False)
            Me.PanelAddressLayout_LeftColumn.ResumeLayout(False)
            Me.PanelAddressLayout_RightColumn.ResumeLayout(False)
            CType(Me.SearchableComboBoxBilling_Location.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboboxGridViewBilling_Location, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelContactTab_Contacts.ResumeLayout(False)
            Me.TabControlPanelWebsiteTab_Websites.ResumeLayout(False)
            Me.TabControlPanelRequiredFieldsTab_RequiredFields.ResumeLayout(False)
            CType(Me.GroupBoxRequiredFields_UserSelectedRequiredFields, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxRequiredFields_UserSelectedRequiredFields.ResumeLayout(False)
            Me.TableLayoutPanelUserSelectedRequiredFields_RequiredFields.ResumeLayout(False)
            Me.PanelUserSelectedRequiredFields_RightColumn.ResumeLayout(False)
            Me.PanelUserSelectedRequiredFields_MiddleColumn.ResumeLayout(False)
            Me.PanelUserSelectedRequiredFields_LeftColumn.ResumeLayout(False)
            CType(Me.GroupBoxUserSelectedRequiredFields_JobsAndMedia, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxUserSelectedRequiredFields_JobsAndMedia.ResumeLayout(False)
            Me.TabControlPanelClientDetails_MediaInvoiceFormat.ResumeLayout(False)
            CType(Me.GroupBoxMediaInvoiceFormat_Radio, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxMediaInvoiceFormat_Radio.ResumeLayout(False)
            CType(Me.SearchableComboBoxRadioInvoiceFormat_Format.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView6, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxMediaInvoiceFormat_Newspaper, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxMediaInvoiceFormat_Newspaper.ResumeLayout(False)
            CType(Me.SearchableComboBoxNewspaperInvoiceFormat_Format.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxMediaInvoiceFormat_OutOfHome, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxMediaInvoiceFormat_OutOfHome.ResumeLayout(False)
            CType(Me.SearchableComboBoxOutOfHomeInvoiceFormat_Format.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxMediaInvoiceFormat_Magazine, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxMediaInvoiceFormat_Magazine.ResumeLayout(False)
            CType(Me.SearchableComboBoxMagazineInvoiceFormat_Format.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxMediaInvoiceFormat_Internet, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxMediaInvoiceFormat_Internet.ResumeLayout(False)
            CType(Me.SearchableComboBoxInternetInvoiceFormat_Format.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxMediaInvoiceFormat_TV, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxMediaInvoiceFormat_TV.ResumeLayout(False)
            CType(Me.SearchableComboBoxTVInvoiceFormat_Format.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView7, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelContractTab_Contracts.ResumeLayout(False)
            Me.TabControlPanelDocumentsTab_Documents.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents TabControlControl_ClientDetails As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelGeneralTab_General As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents AddressControlLeftColumn_Address As AdvantageFramework.WinForm.Presentation.Controls.AddressControl
        Friend WithEvents LabelGeneral_Name As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxGeneral_Name As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelGeneral_Code As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxGeneral_Code As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents CheckBoxRightColumn_NewBusiness As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxRightColumn_Inactive As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents ComboBoxOptions_FiscalStartMonth As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelOptions_CreditLimit As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelOptions_FiscalStartMonth As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TabItemClientDetails_GeneralTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelRequiredFieldsTab_RequiredFields As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents CheckBoxRequiredFields_RequireProductCategorySelectionInTimesheet As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents GroupBoxRequiredFields_UserSelectedRequiredFields As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents GroupBoxUserSelectedRequiredFields_JobsAndMedia As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents CheckBoxJobsAndMedia_FiscalPeriod As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxJobsAndMedia_CampaignCode As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxUserSelectedRequiredFields_OverrideAgencySettings As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents TabItemClientDetails_RequiredFieldsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelDivisionTab_Division As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents PanelDivision_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ButtonRightSection_ProductCopy As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonRightSection_Edit As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonRightSection_Add As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewRightSection_Products As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ExpandableSplitterControlDivision_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelDivision_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ButtonLeftSection_DivisionCopy As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonLeftSection_Edit As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonLeftSection_Add As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewLeftSection_Divisions As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TabItemClientDetails_DivisionProductTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelClientDetails_MediaInvoiceFormat As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemClientDetails_MediaInvoiceFormatTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelMediaTab_Media As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents LabelMedia_DaysToPay As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxMedia_AssignMediaInvoicesBy As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonControlAssignMediaInvoicesBy_OrderNumber As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlAssignMediaInvoicesBy_Market As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlAssignMediaInvoicesBy_ClientPO As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlAssignMediaInvoicesBy_SalesClass As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlAssignMediaInvoicesBy_Campaign As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents TextBoxMedia_AttentionLine As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelMedia_InvoiceFooterComments As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelMedia_AttentionLine As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxMedia_InvoiceFooterComments As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TabItemClientDetails_MediaTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelProductionTab_Production As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents LabelProduction_DaysToPay As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelProduction_InvoiceFooterComments As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxProduction_InvoiceFooterComments As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelProduction_AttentionLine As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxProduction_AttentionLine As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents GroupBoxProduction_AssignProductionInvoicesBy As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents TabItemClientDetails_ProductionTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents GroupBoxMediaInvoiceFormat_TV As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents LabelTelevisionInvoiceFormat_Format As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTelevisionInvoiceFormat_Type As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxTVInvoiceFormat_Type As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents GroupBoxMediaInvoiceFormat_Radio As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents LabelRadioInvoiceFormat_Format As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelRadioInvoiceFormat_Type As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxRadioInvoiceFormat_Type As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents GroupBoxMediaInvoiceFormat_Newspaper As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents LabelNewspaperInvoiceFormat_Format As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelNewspaperInvoiceFormat_Type As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxNewspaperInvoiceFormat_Type As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents GroupBoxMediaInvoiceFormat_OutOfHome As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents LabelOutOfHomeInvoiceFormat_Format As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelOutOfHomeInvoiceFormat_Type As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxOutOfHomeInvoiceFormat_Type As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents GroupBoxMediaInvoiceFormat_Magazine As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents LabelMagazineInvoiceFormat_Format As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelMagazineInvoiceFormat_Type As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxMagazineInvoiceFormat_Type As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents GroupBoxMediaInvoiceFormat_Internet As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents LabelInternetInvoiceFormat_Format As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelInternetInvoiceFormat_Type As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxInternetInvoiceFormat_Type As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents GroupBoxProduction_ProductionInvoiceFormat As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents LabelProductionInvoiceFormat_Format As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelProductionInvoiceFormat_Type As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxProductionInvoiceFormat_Type As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ButtonRightSection_Delete As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonLeftSection_Delete As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents GroupBoxLeftColumn_NewClientOptions As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents TabControlPanelBillingTab_Billing As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents ButtonRightColumn_RefreshStatement As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonItemRefreshStatement_Address As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemRefreshStatement_Billing As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonLeftColumn_RefreshBilling As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonItemRefreshBilling_Address As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents AddressControlRightColumn_StatementAddress As AdvantageFramework.WinForm.Presentation.Controls.AddressControl
        Friend WithEvents AddressControlLeftColumn_BillingAddress As AdvantageFramework.WinForm.Presentation.Controls.AddressControl
        Friend WithEvents GroupBoxBilling_ARComment As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents TextBoxARComment_ARComment As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TabItemClientDetails_BillingTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents LabelNewClientOptions_Office As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxNewClientOptions_DuplicateForProduct As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxNewClientOptions_DuplicateForDivision As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelRadioInvoiceFormat_Note As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelNewspaperInvoiceFormat_Note As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelOutOfHomeInvoiceFormat_Note As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelMagazineInvoiceFormat_Note As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelInternetInvoiceFormat_Note As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTelevsionInvoiceFormat_Note As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelProductionInvoiceFormat_StandardFormat As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents RadioButtonControlAssignProductionInvoicesBy_ProductClientPO As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlAssignProductionInvoicesBy_ProductSalesClass As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlAssignProductionInvoicesBy_Product As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlAssignProductionInvoicesBy_Job As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlAssignProductionInvoicesBy_Division As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlAssignProductionInvoicesBy_Client As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlAssignProductionInvoicesBy_JobComponent As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlAssignProductionInvoicesBy_Campaign As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents TableLayoutPanelBilling_AddressLayout As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents PanelAddressLayout_LeftColumn As System.Windows.Forms.Panel
        Friend WithEvents PanelAddressLayout_RightColumn As System.Windows.Forms.Panel
        Friend WithEvents TableLayoutPanelUserSelectedRequiredFields_RequiredFields As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents PanelUserSelectedRequiredFields_RightColumn As System.Windows.Forms.Panel
        Friend WithEvents CheckBoxRightColumn_JobComponentCustom5 As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxRightColumn_JobLogCustom1 As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxRightColumn_JobComponentCustom4 As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxRightColumn_JobLogCustom2 As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxRightColumn_JobComponentCustom3 As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxRightColumn_JobLogCustom3 As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxRightColumn_JobComponentCustom2 As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxRightColumn_JobLogCustom4 As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxRightColumn_JobComponentCustom1 As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxRightColumn_JobLogCustom5 As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents PanelUserSelectedRequiredFields_MiddleColumn As System.Windows.Forms.Panel
        Friend WithEvents CheckBoxMiddleColumn_ServiceFeeType As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxMiddleColumn_DeptTeam As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxMiddleColumn_JobType As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxMiddleColumn_ProductContact As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxMiddleColumn_Promotion As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxMiddleColumn_FormatAdSize As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxMiddleColumn_DueDate As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxMiddleColumn_MarketCode As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxMiddleColumn_SCFormat As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents PanelUserSelectedRequiredFields_LeftColumn As System.Windows.Forms.Panel
        Friend WithEvents CheckBoxLeftColumn_Blackplate2 As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxLeftColumn_Blackplate1 As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxLeftColumn_ComponentBudget As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxLeftColumn_DateOpened As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxLeftColumn_ClientReference As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxLeftColumn_AdNumber As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxLeftColumn_CoopBillingCode As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxLeftColumn_AlertGroup As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxLeftColumn_ComplexityCode As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxLeftColumn_AccountNumber As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents TableLayoutPanelGeneral_General As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents PanelGeneral_TopLeftColumn As System.Windows.Forms.Panel
        Friend WithEvents PanelGeneral_TopRightColumn As System.Windows.Forms.Panel
        Friend WithEvents CheckBoxRequiredFields_RequireTimeComments As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents ButtonItemDivisionCopy_From As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemDivisionCopy_To As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemProductCopy_To As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemProductCopy_From As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents TabControlPanelWebsiteTab_Websites As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemClientDetails_WebsitesTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents DataGridViewWebsites_Websites As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents DateTimePickerOptions_ContractExpirationDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents LabelOptions_ContractExpirationDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TabControlPanelDocumentsTab_Documents As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemClientDetails_DocumentsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents DocumentManagerControlDocuments_ClientDocuments As AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl
        Friend WithEvents GroupBoxBilling_Options As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents DataGridViewTopRightColumn_ClientSortKeys As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RadioButtonControlAssignMediaInvoicesBy_OrderType As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents NumericInputMedia_DaysToPay As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputProduction_DaysToPay As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents TabControlPanelContactTab_Contacts As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemClientDetails_ContactsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents ClientContactManagerControlContacts_ClientContacts As AdvantageFramework.WinForm.Presentation.Controls.ClientContactManagerControl
        Friend WithEvents TabControlPanelContractTab_Contracts As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemClientDetails_ContractsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents ContractManagerControlContractTab_Contracts As AdvantageFramework.WinForm.Presentation.Controls.ContractManagerControl
        Friend WithEvents NumericInputOptions_CreditLimit As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents GroupBoxBilling_Avalara As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents LabelAvalara_SalesClass As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxAvalara_SalesClassCode As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboboxViewAvalara_SalesClass As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents CheckBoxAvalara_TaxExempt As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents SearchableComboBoxBilling_Location As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboboxGridViewBilling_Location As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelBilling_Location As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxNewClientOptions_Office As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBox1View As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxProductionInvoiceFormat_Format As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView1 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxTVInvoiceFormat_Format As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView7 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxRadioInvoiceFormat_Format As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView6 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxOutOfHomeInvoiceFormat_Format As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView5 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxInternetInvoiceFormat_Format As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView4 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxNewspaperInvoiceFormat_Format As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView3 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxMagazineInvoiceFormat_Format As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView2 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents GroupBoxProduction_ProductionEstimateFormat As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents LabelProductionEstimateFormat_StandardFormat As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelProductionEstimateFormat_Type As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxProductionEstimateFormat_Type As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents GroupBoxBilling_AssignComboInvoicesBy As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonControlAssignComboInvoicesBy_ClientDivisionProductCampaign As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlAssignComboInvoicesBy_ClientDivisionProduct As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlAssignComboInvoicesBy_Client As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlAssignComboInvoicesBy_ClientCampaign As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlAssignComboInvoicesBy_None As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents CheckBoxAssignComboInvoicesBy_MediaOnly As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelOptions_Currency As Label
        Friend WithEvents ComboBoxOptions_Currency As ComboBox
        Friend WithEvents RadioButtonControlAssignComboInvoicesBy_ClientDivision As RadioButtonControl
        Friend WithEvents LabelOptions_Biller As Label
        Friend WithEvents ComboBoxOptions_Biller As ComboBox
        Friend WithEvents SearchableComboBoxProduction_ClientDiscount As SearchableComboBox
        Friend WithEvents GridView8 As GridView
        Friend WithEvents LabelProduction_ClientDiscount As Label
        Friend WithEvents CheckBoxProduction_LimitTimeFunctionsToBillingHierarchy As CheckBox
        Friend WithEvents CheckBoxNewClientOptions_TvUnitProductSplit As CheckBox
        Friend WithEvents GroupBoxBilling_LatePaymentFee As GroupBox
        Friend WithEvents NumericInputLatePaymentFee_Percentage As NumericInput
        Friend WithEvents LabelLatePaymentFee_Percentage As Label
        Friend WithEvents CheckBoxLatePaymentFee_Calculate As CheckBox
        Friend WithEvents TabControlPanelAutomatedAssignmentsTab_AutomatedAssignments As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents LabelAutomatedAssignments_JobComponent As Label
        Friend WithEvents SearchableComboBoxAutomatedAssignments_JobComponent As SearchableComboBox
        Friend WithEvents GridView9 As GridView
        Friend WithEvents TabItemClientDetails_AutomatedAssignmentsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents LabelAutomatedAssignments_Job As Label
        Friend WithEvents SearchableComboBoxAutomatedAssignments_Job As SearchableComboBox
        Friend WithEvents GridView10 As GridView
        Friend WithEvents TextBoxBilling_VATNumber As TextBox
        Friend WithEvents LabelBilling_VATNumber As Label
        Friend WithEvents CheckBoxMedia_ClientResponsibleForMediaTrafficInstructions As CheckBox
        Friend WithEvents TabControlPanelMediaIntegrationsSettingsTab_Settings As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents CheckBoxMediaIntegrationSettings_EnableDoubleClick As CheckBox
        Friend WithEvents NumericInputDoubleClick_ReportID As NumericInput
        Friend WithEvents NumericInputDoubleClick_ProfileID As NumericInput
        Friend WithEvents LabelDoubleClick_ReportID As Label
        Friend WithEvents LabelDoubleClick_ProfileID As Label
        Friend WithEvents TabItemClientDetails_MediaIntegrationSettings As DevComponents.DotNetBar.TabItem
        Friend WithEvents SearchableComboBoxGeneral_QuickBooksCustomer As SearchableComboBox
        Friend WithEvents GridView11 As GridView
        Friend WithEvents LabelGeneral_QuickbooksCustomer As Label
    End Class

End Namespace
